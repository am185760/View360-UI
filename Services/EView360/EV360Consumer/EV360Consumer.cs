using DataRequestor;
using Encryption;
using Microsoft.Win32;
using ServicesDAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
//using SharpSsh;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;


namespace EV360Consumer
{
    public static class ThreadExtension
    {
        public static void WaitAll(this IEnumerable<Thread> threads)
        {
            if (threads != null)
            {
                foreach (Thread thread in threads)
                {
                    bool finished = thread.Join(EV360Consumer.threadTimeout);
                    if (!finished)
                        thread.Abort();
                }
            }
        }
    }
    public partial class EV360Consumer : ServiceBase
    {

        #region declarations       
        public static Timer timerListener;
        public static string CurrentEJStore = "";
        public static DateTime serviceStartedAt = DateTime.Now;
        public static DateTime appSettingLastLoadedAt = DateTime.Now;
        public static int workerThreadsCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["workerThreadsCount"]);
        public static string uploadFolder = System.Configuration.ConfigurationManager.AppSettings["uploadFolder"];
        public static string cashDB = System.Configuration.ConfigurationManager.AppSettings["CashDB"];
        public static string txDB = System.Configuration.ConfigurationManager.AppSettings["TxDB"];
        public static int maxThreads = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxThreads"]);
        public static int threadTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ThreadTimeOut"]);
        Timer timerScheduleThreadForExecution;
        Timer timerFileProcessor;
        Timer timerFileProcessor2;
        public static AppSetting appSettings;
        FileSystemWatcher watcher = null;
        private BlockingCollection<string> queue = new BlockingCollection<string>();
        private ConcurrentDictionary<string, DateTime> processedFileMap = new ConcurrentDictionary<string, DateTime>();
        private readonly ConcurrentDictionary<string, bool> _processingFiles = new ConcurrentDictionary<string, bool>();


        #endregion


        private bool IsFileReady(string filename)
        {
            try
            {
                using (FileStream stream = File.Open(
                    filename,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None))
                {
                    return stream.Length > 0;
                }
            }
            catch
            {
                return false;
            }
        }


        private void ConfigureWatcher()
        {
            watcher = new FileSystemWatcher(appSettings.TemporaryFolder + "\\Uploads");
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += (_, e) => queue.Add(e.FullPath);
            watcher.Created += (_, e) => queue.Add(e.FullPath);
            //watcher.Created += OnCreated;
            //watcher.Changed += OnCreated;
            //watcher.Filter = "counter*.dll";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        //  Timer timerFileProcessor;


        //protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        DoWorkForFileProcessor();
        //        //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //        await System.Threading.Tasks.Task.Delay(5 * 60 * 1000, stoppingToken);//TODO: to be changed later
        //    }
        //}


        private void QueueProcessor()
        {
            ServicesDAL.LogableTask.LogMonoActivityTask("QueueProcessor", MethodBase.GetCurrentMethod(), TraceLevel.Info, "QueueProcessor started.");

            while (!queue.IsCompleted)
            {
                try
                {
                    string fileToRead = queue.Take();

                    if (!File.Exists(fileToRead))
                    {
                        ServicesDAL.LogableTask.LogMonoActivityTask("QueueProcessor", MethodBase.GetCurrentMethod(), TraceLevel.Warning, $"File not found: {fileToRead}");
                        continue;
                    }

                    DateTime lastWriteTime = File.GetLastWriteTime(fileToRead);

                    if (processedFileMap.TryGetValue(fileToRead, out DateTime processedWithModDate) && processedWithModDate == lastWriteTime)
                    {
                        ServicesDAL.LogableTask.LogMonoActivityTask("QueueProcessor", MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Ignoring duplicate change event for file: {fileToRead}");
                        continue;
                    }

                    // Mark as processed BEFORE calling SaveToDB so queue duplicates won't reprocess
                    processedFileMap[fileToRead] = lastWriteTime;

                    ServicesDAL.LogableTask.LogMonoActivityTask("QueueProcessor", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                        processedWithModDate == default ? $"Processing file for first time: {fileToRead}" : $"File modified again, reprocessing: {fileToRead}");

                    SaveToDB(fileToRead); // Call processing
                }
                catch (Exception ex)
                {
                    ServicesDAL.LogableTask.LogMonoActivityTask("QueueProcessor", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                }
            }

            ServicesDAL.LogableTask.LogMonoActivityTask("QueueProcessor", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "QueueProcessor stopped.");
        }



        public void OnDebug()
        {
            OnStart(null);
        }
        void ScheduleThreadForExecution(object state)
        {
            try
            {

                string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
                coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));
                ConnectionFactory.Initialize(coreConnectionStr, true, DatabaseName.Core);
                ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);
                ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);
                appSettings = AppSetting.LoadAppSetting("1=1");
                appSettingLastLoadedAt = DateTime.Now;
                ServicesDAL.XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360Consumer_{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                ServicesDAL.LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EV360Consumer 1.0.0.0, Build date 18-03-2023");
                ServicesDAL.LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");

                timerFileProcessor = new Timer(DoWorkForFileProcessor, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));

                ConfigureWatcher();
                System.Threading.Tasks.Task.Run(() => QueueProcessor());
                EventLog.WriteEntry("EV360Consumer", "EV360Consumer Service Started Successfully", EventLogEntryType.Information);

                timerFileProcessor2 = new Timer(DoWorkForAtmPendingFiles, null, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0, 0, -1));
                EventLog.WriteEntry("EV360Consumer", "AtmPendingFileHandler Service Started Successfully", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                try
                {
                    EventLog.WriteEntry("EV360Consumer", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception innerException)
                {
                }
            }
        }

        private void SaveToDB(string filename)
        {
            if (!File.Exists(filename))
                return;

            // Prevent duplicate parallel processing
            if (!_processingFiles.TryAdd(filename, true))
                return;

            try
            {
                TaskExecutor TE = new TaskExecutor();

                // Wait until file is fully written (max 5 seconds)
                int retry = 0;
                while (!IsFileReady(filename) && retry < 10)
                {
                    Thread.Sleep(500);
                    retry++;
                }

                if (retry == 10)
                {
                    ServicesDAL.LogableTask.LogMonoActivityTask("SaveToDB", MethodBase.GetCurrentMethod(), TraceLevel.Warning, $"File locked too long, skipping: {filename}");
                    return;
                }

                List<string> direParts = filename.Split('\\').ToList();
                int ind = direParts.Count;
                string atmIP = new string(direParts[ind - 2].ToCharArray());
                string fileName = new string(direParts[ind - 1].ToCharArray());
                string fileContent = File.ReadAllText(filename).Replace("'", "''");

                bool result = TE.PushFileContent(atmIP, fileName, Encoding.Default.GetBytes(fileContent), cashDB, txDB, EV360Consumer.threadTimeout);

                if (result)
                {
                    File.Delete(filename);
                    ServicesDAL.LogableTask.LogMonoActivityTask("SaveToDB", MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Processed and deleted: {filename}");
                }
                else
                {
                    ServicesDAL.LogableTask.LogMonoActivityTask("SaveToDB", MethodBase.GetCurrentMethod(), TraceLevel.Error, $"DB insert failed: {filename}");
                }
            }
            catch (Exception ex)
            {
                ServicesDAL.LogableTask.LogMonoActivityTask("SaveToDB", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                _processingFiles.TryRemove(filename, out _);
            }
        }


        private async void SaveToCashDataStore()
        {
            string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
            coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));
            ConnectionFactory.Initialize(coreConnectionStr, true, DatabaseName.Core);
            ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);
            ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);


            appSettings = AppSetting.LoadAppSetting("1=1");
            appSettingLastLoadedAt = DateTime.Now;
            ServicesDAL.XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360Consumer_{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));

            TaskExecutor TE = new TaskExecutor();
            //TE.PushFileContent("3.9.0.0", "counter_09022023171600_3199_1.zip", Encoding.UTF8.GetBytes("Eslam"));
            List<string> atmsFiles = Directory.GetDirectories(uploadFolder).SelectMany(f => Directory.GetFiles(f)).ToList();
            //List<Thread> threads = new List<Thread>();
            try
            {
                for (int i = 0; i < atmsFiles.Count; i++)
                {
                    List<string> direParts = atmsFiles[i].Split('\\').ToList();
                    int ind = direParts.Count;
                    string atmIP = new string(direParts[ind - 2].ToCharArray());
                    string fileName = new string(direParts[ind - 1].ToCharArray());
                    string fileContent = File.ReadAllText(atmsFiles[i]).Replace("'", "''");
                    string filePath = new string(atmsFiles[i].ToCharArray());
                    //var tcs = new System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.Task>();

                    //var thread = new Thread(() =>
                    //{
                    try
                    {
                        //tcs.SetResult(
                        ServicesDAL.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing:" + fileName);

                        bool result = TE.PushFileContent(atmIP, fileName, Encoding.Default.GetBytes(fileContent), cashDB, txDB, EV360Consumer.threadTimeout);

                        //if (tcs.Task.Exception != null && string.IsNullOrEmpty(tcs.Task.Exception.Message))
                        //    DataRequestor.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Error, tcs.Task.Exception);
                        //else
                        //{
                        //    DataRequestor.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, " file saved");
                        if (result)
                        {
                            ServicesDAL.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processed and saved to DB:" + fileName);
                            File.Delete(filePath);
                        }
                        ServicesDAL.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "ignored:" + filePath);
                        Console.WriteLine("ignored:" + filePath);
                    }

                    catch (Exception e)
                    {
                        //          tcs.SetException(e);
                        ServicesDAL.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Error, e);
                    }

                    //);
                    //thread.SetApartmentState(ApartmentState.STA);
                    //Thread.Sleep(2000);
                    //thread.Start();
                    //threads.Add(thread);
                    // if (threads.Count == maxThreads)
                    //   threads.WaitAll();
                }
                //threads.WaitAll();

            }
            catch (Exception ex)
            {
                ServicesDAL.LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {

            }

        }

        void DoWorkForFileProcessor(object state)
        {
            timerFileProcessor.Change(-1, -1);

            try
            {
                SaveToCashDataStore();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("CurrencyMngServer", "Error in DoWorkForFileProcessor(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
            }
            finally
            {
                timerFileProcessor.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
            }
        }

        void DoWorkForAtmPendingFiles(object state)
        {
            timerFileProcessor2.Change(-1, -1);
            try
            {
                DateTime lastInvoked = DateTime.Now;
                string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
                coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));
                List<string> atmsFiles = Directory.GetDirectories(uploadFolder).SelectMany(f => Directory.GetFiles(f)).ToList();
                DataTable dt = new DataTable();

                dt.Columns.Add("IP", typeof(string));
                dt.Columns.Add("last_invoked", typeof(DateTime));
                dt.Columns.Add("file_name", typeof(string));
                dt.Columns.Add("file_creation_time", typeof(DateTime));
                dt.Columns.Add("file_size", typeof(long));


                for (int i = 0; i < atmsFiles.Count; i++)
                {
                    List<string> direParts = atmsFiles[i].Split('\\').ToList();
                    int ind = direParts.Count;
                    string fileName = new string(direParts[ind - 1].ToCharArray());
                    string fileContent = File.ReadAllText(atmsFiles[i]).Replace("'", "''");
                    string filePath = new string(atmsFiles[i].ToCharArray());
                    List<string> subDirParts = fileName.Split('_').ToList();
                    FileInfo fi = new FileInfo(filePath);

                    DataRow dataRow = dt.NewRow();
                    dataRow["IP"] = new string(direParts[ind - 2].ToCharArray());
                    dataRow["last_invoked"] = lastInvoked;
                    dataRow["file_name"] = new string(direParts[ind - 1].ToCharArray());
                    dataRow["file_creation_time"] = DateTime.ParseExact(subDirParts[1], "ddMMyyyyHHmmss", CultureInfo.InvariantCulture);
                    dataRow["file_size"] = fi.Length;
                    dt.Rows.Add(dataRow);
                }

                if (dt != null && dt.Rows != null && dt.Rows.Count > 0) 
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@files";
                    param1.SqlDbType = SqlDbType.Structured;
                    param1.Value = dt;

                    string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
                    connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");

                    using (SqlConnection connection = new SqlConnection(coreConnectionStr))
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "InsertAtmPendingFiles";
                        command.CommandTimeout = 90;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;
                        command.Parameters.AddRange(new SqlParameter[] { param1 });
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                //TODO -- Insert last_invoked in AppSetting.....
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("CurrencyMngServer", "Error in DoWorkForAtmPendingFiles(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
            }
            finally
            {
                timerFileProcessor2.Change(new TimeSpan(0, 1, 0), new TimeSpan(0, 0, 0, 0, -1));
            }
        }

        protected override void OnStart(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //To avoid delay of 500 milliseconds allocate more threads in advance.
            //Change done on 15Nov2015
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ThreadPool.SetMinThreads(workerThreadsCount, workerThreadsCount);
            timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));
            //EventLog.WriteEntry("EV360Consumer", "Thread schedular sent startup request", EventLogEntryType.Information);
        }

        //protected override void OnStop()
        //{
        //    try
        //    {
        //        //timerFetchCashOrders.Dispose();
        //        //timerExecCashOrderOrConfigTask.Dispose();

        //        //timerListener.Dispose();
        //        // timerNotifier.Dispose();
        //        //timerCashDataDownloader.Dispose();
        //        //timerScheduleThreadForExecution.Dispose();
        //        DataRequestor.LogableTask.LogMonoActivityTask("Stopping", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "Stopping");
        //        //DataRequestor.LogableTask task = DataRequestor.LogableTask.NewTask("Service Stopped");
        //        //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Warning, "Stopping");
        //        //task.EndTask();
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("EV360Consumer", "Error in OnStop(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
        //    }
        //}

        public static void InitLogger()
        {
            DataRequestor.XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360Consumer_{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));

            try
            {
                DataRequestor.LogableTask.DefaultTraceLevel = (TraceLevel)Enum.Parse(typeof(TraceLevel), appSettings.ServiceLogLevel);
            }
            catch
            {
                DataRequestor.LogableTask.DefaultTraceLevel = TraceLevel.Info;
                DataRequestor.LogableTask.LogMonoActivityTask("GetTraceLevel", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Failed to extract trace level from database");
            }
        }

    }
}
