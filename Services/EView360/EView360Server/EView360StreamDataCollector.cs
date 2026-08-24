using Encryption;
using Microsoft.Win32;
using ServicesDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;

namespace Avanza.CCMS
{
    public partial class EView360Server : ServiceBase
    {

        #region declarations
        private readonly bool _listen = true;
        public static Timer timerListener;
        public static string CurrentEJStore = "";
        public static DateTime serviceStartedAt = DateTime.Now;
        public static DateTime appSettingLastLoadedAt = DateTime.Now;
        public static int workerThreadsCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["workerThreadsCount"]);
        public static List<Downloader> ActiveDownloads = new List<Downloader>(50);

        Timer timerExecCashOrderOrConfigTask;
        Timer timerCashDataDownloader;
        Timer timerScheduleThreadForExecution;
        public static AppSetting appSettings;

        string scheduleTerminalIP;
        int processorCount = Environment.ProcessorCount;

        #endregion
        Timer timerFileProcessor;
        static bool init = false;
        //protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        if (!init)
        //        {
        //            try
        //            {
        //                string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
        //                coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));
        //                //string[] connectionStr = { coreConnectionStr, coreConnectionStr.Replace("Core", "Cash"), coreConnectionStr.Replace("Core", "Tx") };
        //                //ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Cash);
        //                ConnectionFactory.Initialize(coreConnectionStr, true, DatabaseName.Core);
        //                ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);
        //                ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);

        //                appSettings = AppSetting.LoadAppSetting("1=1");
        //                appSettingLastLoadedAt = DateTime.Now;
        //                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EView360Server{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
        //                //maxLicensedATMId = LicenseManager.MaxLicensedATMID();
        //                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EView360Server 1.0.0.0, Build date 11-Feb-2023");
        //                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 5 seconds.");

        //                //if (_listen)

        //                //{
        //                Listener Li = new Listener();
        //                timerListener = new Timer(Li.DoListen, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));
        //                timerExecCashOrderOrConfigTask = new Timer(ExecCashOrderOrConfigTask, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1)); //timer = 15 instead of 1
        //                timerFileProcessor = new Timer(DoWorkForFileProcessor, null, new TimeSpan(0, 0, 35), new TimeSpan(0, 0, 0, 0, -1));
        //                timerCashDataDownloader = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));

        //                init = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                EventLog.WriteEntry("EView360Server", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
        //            }
        //        }
        //        //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //        await System.Threading.Tasks.Task.Delay(5 * 60 * 1000, stoppingToken);//TODO: to be changed later
        //    }
        //}

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1)); //timer = 15 instead of 1
        }

        void ScheduleThreadForExecution(object state)
        {
            try
            {
                string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
                coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));
                //string[] connectionStr = { coreConnectionStr, coreConnectionStr.Replace("Core", "Cash"), coreConnectionStr.Replace("Core", "Tx") };
                //ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Cash);
                ConnectionFactory.Initialize(coreConnectionStr, true, DatabaseName.Core);
                ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);
                ConnectionFactory.Initialize(coreConnectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);

                appSettings = AppSetting.LoadAppSetting("1=1");
                appSettingLastLoadedAt = DateTime.Now;
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EView360Server{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                //maxLicensedATMId = LicenseManager.MaxLicensedATMID();
                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EView360Server 1.0.0.0, Build date 11-Feb-2023");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 5 seconds.");

                //if (_listen)

                //{
                Listener Li = new Listener();
                timerListener = new Timer(Li.DoListen, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));
                timerExecCashOrderOrConfigTask = new Timer(ExecCashOrderOrConfigTask, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1)); //timer = 15 instead of 1
                timerFileProcessor = new Timer(DoWorkForFileProcessor, null, new TimeSpan(0, 0, 35), new TimeSpan(0, 0, 0, 0, -1));
                timerCashDataDownloader = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));


                //string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
                //coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));
                ////string[] connectionStr = { coreConnectionStr, coreConnectionStr.Replace("Core", "Cash"), coreConnectionStr.Replace("Core", "Tx") };
                //ConnectionFactory.Initialize(coreConnectionStr, true, DatabaseName.Core);

                //appSettings = AppSetting.LoadAppSetting("1=1");
                //appSettingLastLoadedAt = DateTime.Now;
                //XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EView360Server{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                ////maxLicensedATMId = LicenseManager.MaxLicensedATMID();
                //LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EView360Server 1.0.0.0, Build date 11-Feb-2023");
                //LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 5 seconds.");

                ////if (_listen)

                ////{
                //Listener Li = new Listener();
                //timerListener = new Timer(Li.DoListen, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));
                //// }

                ////if(cashOrderExectionEnabled == "1")
                ////{
                ////    if (EView360Server.bankID != "1")

                //timerExecCashOrderOrConfigTask = new Timer(ExecCashOrderOrConfigTask, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1)); //timer = 15 instead of 1
                ////}
                ////if(cashDataDownloadingEnabled == "1")
                ////{
                ////     timerCashDataDownloader = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                ////}
                ////timerFileProcessor = new Timer(DoWorkForFileProcessor, null, new TimeSpan(0, 0, 35), new TimeSpan(0, 0, 0, 0, -1));

                //// timerNotifier = new Timer(Notifier.DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                ////timerListener = new Timer(Listener, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));

                ////timerLicenseThreshold = new Timer(AlertGenerationOnLicenseThreshold, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                ////timerHardDiskSpaceThreshold = new Timer(AlertGenerationOnHardDiskSpaceThreshold, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                //EventLog.WriteEntry("EView360Server", "Service Started Successfully", EventLogEntryType.Information);

            }
            catch (Exception ex)
            {
                //trying to log error in event log if its not full.
                try
                {
                    EventLog.WriteEntry("EView360Server", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    //EventLog.WriteEntry("EView360Server", "Service is idle", EventLogEntryType.Warning);
                    timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception innerException)
                {
                }
            }
        }

        void DoWorkForFileProcessor(object state)
        {
            timerFileProcessor.Change(-1, -1);
            try
            {
                SaveToCashDataStore(DatabaseName.Cash);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("EView360Server", "Error in DoWorkForFileProcessor(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
            }
            try
            {
                SaveToCashDataStore(DatabaseName.Tx);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("EView360Server", "Error in DoWorkForFileProcessor(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
            }

            finally
            {
                timerFileProcessor.Change(new TimeSpan(0, 1, 0), new TimeSpan(0, 0, 0, 0, -1));
            }
        }

        private void SaveToCashDataStore(DatabaseName dBName)
        {
            ServicesDAL.Task.TaskReader taskReader = ServicesDAL.Task.ExecuteReader("status = 'downloadedStorePending' and atm_id in (select atm_id from core..atm where is_active=1)", dBName);

            try
            {
                while (taskReader.Read())
                {
                    try
                    {
                        Atm atm = Atm.LoadAtmByPk(taskReader.CurrentTask.ATMId);
                        FileType fileType = FileType.LoadFileTypeByPk(taskReader.CurrentTask.FileTypeId.Value);
                        if (fileType != null)
                        {
                            if (fileType.IsEJLog)
                            {
                                LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to save ej in database");
                                // to do use encription for connection string

                                string EJStoreName = "CashDataStore_" + taskReader.CurrentTask.CreationTime.Year.ToString();

                                VerifyEJStore(EJStoreName.ToLower());

                                SqlCommand cmd = ConnectionFactory.GetNewCommand(false, dBName);
                                cmd.Connection.Open();
                                cmd.Connection.ChangeDatabase(EJStoreName);

                                //if (fileAlreadyTransferred)
                                //{
                                if (!File.Exists(taskReader.CurrentTask.ServerFilepath))
                                {
                                    //Check  it in the database
                                    cmd.CommandText = "select count(task_id) from cashdatafiles where task_id =" + taskReader.CurrentTask.TaskId;
                                    if ((int)cmd.ExecuteScalar() > 0)
                                    {
                                        //File Already Saved to database.
                                        taskReader.CurrentTask.Status = DownloadStates.downloadedParsePending.ToString();
                                        taskReader.CurrentTask.FailureReason = string.Empty;

                                        taskReader.CurrentTask.Save(dBName);


                                    }
                                    else
                                    {
                                        //not in file system & database..
                                        taskReader.CurrentTask.Status = DownloadStates.unknownError.ToString();
                                        taskReader.CurrentTask.Save(dBName);


                                    }
                                }
                                else
                                {
                                    //cmd.CommandText = "insert into CashDataFiles (task_id, cash_data_file) values(" + downloadTask.TaskId + ",@ej_file)";
                                    //cmd.Parameters.Add("@ej_file", System.Data.SqlDbType.Binary);
                                    //cmd.Parameters[0].Value = File.ReadAllBytes(downloadTask.ServerFilepath);
                                    //cmd.ExecuteNonQuery();
                                    //cmd.Connection.Close();
                                    //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "file saved");
                                    //File.Delete(downloadTask.ServerFilepath);
                                    //downloadTask.Status = DownloadStates.downloadedParsePending.ToString();
                                    //downloadTask.Save();
                                    try
                                    {
                                        cmd.CommandText = "insert into CashDataFiles (task_id, cash_data_file) values(" + taskReader.CurrentTask.TaskId + ",@ej_file)";
                                        cmd.Parameters.Add("@ej_file", System.Data.SqlDbType.Binary);
                                        cmd.Parameters[0].Value = File.ReadAllBytes(taskReader.CurrentTask.ServerFilepath);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "task id:" + taskReader.CurrentTask.TaskId + ",server filepath:" + taskReader.CurrentTask.ServerFilepath);
                                        if (!ex.Message.Contains("Violation of PRIMARY KEY"))
                                            throw;
                                    }
                                    finally
                                    {
                                        cmd.Connection.Close();
                                    }
                                    LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "file saved");
                                    File.Delete(taskReader.CurrentTask.ServerFilepath);
                                    taskReader.CurrentTask.Status = DownloadStates.downloadedParsePending.ToString();
                                    taskReader.CurrentTask.RetryRemaining = 10;// (byte)atm.RetryCountCounterFile;
                                    taskReader.CurrentTask.Save(dBName);

                                }
                                //}

                                //else
                                //{

                                //}


                                taskReader.CurrentTask.ServerFilepath = null;

                            }
                            else
                            {
                                if (!Directory.Exists(EView360Server.appSettings.DownloadedFilePath + "\\" + taskReader.CurrentTask.ATMId))
                                    Directory.CreateDirectory(EView360Server.appSettings.DownloadedFilePath + "\\" + taskReader.CurrentTask.ATMId);
                                string newFilePath = EView360Server.appSettings.DownloadedFilePath + "\\" + taskReader.CurrentTask.ATMId + "\\" +
                                   Path.GetFileName(taskReader.CurrentTask.ServerFilepath);
                                File.Move(taskReader.CurrentTask.ServerFilepath, newFilePath);
                                LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "file moved");
                                taskReader.CurrentTask.ServerFilepath = newFilePath;
                                taskReader.CurrentTask.FailureReason = "";
                                if (fileType.FileTypeId == 3 || fileType.FileTypeId == 5 || fileType.FileTypeId == 13 || fileType.FileTypeId == 14 || fileType.FileTypeId == 15)
                                    taskReader.CurrentTask.Status = DownloadStates.downloadedParsePending.ToString();
                                else
                                    taskReader.CurrentTask.Status = DownloadStates.completed.ToString();
                            }
                        }
                        else
                            LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Info, "file type id does not exists:" + taskReader.CurrentTask.FileTypeId);

                        //
                    }
                    catch (Exception ex)
                    {
                        LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

                    }
                }

            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("SaveToCashDataStore", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                if (taskReader != null)
                    taskReader.Close();
            }

        }



        public static void VerifyEJStore(string EJStoreName)
        {
            lock (EView360Server.CurrentEJStore)
            {
                EJStoreName = EJStoreName.ToLower();
                if (EView360Server.CurrentEJStore.ToLower() == EJStoreName)
                    return;
                SqlCommand cmd = (SqlCommand)ConnectionFactory.GetNewConnection(DatabaseName.Cash).CreateCommand();
                cmd.CommandText = "sp_helpdb";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                bool dbFound = false;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    if (EJStoreName == reader.GetString(0).ToLower())
                    {
                        dbFound = true;
                        break;
                    }
                reader.Close();

                if (!dbFound)
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("CREATE DATABASE {0} ON (  NAME = {0}, FILENAME = '{1}\\{0}.mdf' )" +
                        "LOG ON( NAME = '{0}_log',  FILENAME = '{1}\\{0}Log.ldf' )", EJStoreName, EView360Server.appSettings.CashDataStoresLocation);
                    cmd.ExecuteNonQuery();

                    cmd.Connection.ChangeDatabase(EJStoreName);
                    cmd.CommandText = "CREATE TABLE CashDataFiles (task_id int primary key ,cash_data_file image NULL ) ";
                    cmd.ExecuteNonQuery();
                }
                cmd.Connection.Close();

                EView360Server.CurrentEJStore = EJStoreName;
            }

        }








        public void ExecCashOrderOrConfigTask(object state)
        {
            timerExecCashOrderOrConfigTask.Change(-1, -1);
            LogableTask task = LogableTask.NewTask("ExecuteTasks");
            ServicesDAL.Task uploadingTask = null;
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                //commented on 22 october bcoz cash order execution time is set by system current date at the time of installation.

                //if (appSettings.CashOrderExecutionTime == null)
                //    throw new Exception("Cash Order Execution Time is not defined in application configuration.");

                //if (appSettings.CashOrderExecutionTime.Value.Date != DateTime.Now.Date)
                //{
                //    appSettings.CashOrderExecutionTime = appSettings.CashOrderExecutionTime.Value.AddDays(1);
                //    appSettings.Save();
                //}


                conn = ConnectionFactory.GetNewConnection(DatabaseName.Core);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"select task_id 
                                    from Cash.dbo.task inner join atm 
                                    on task.atm_id = atm.atm_id 
                                    where atm.is_active = 1
                                    and task_type_id in (" + (int)EnumTaskType.CashOrderUpload + "," + (int)EnumTaskType.Configuration + "," +
                                                           (int)EnumTaskType.DateTimeSync + "," + (int)EnumTaskType.Restart + "," +
                                                           (int)EnumTaskType.BatchConfiguration + "," + (int)EnumTaskType.HeartbeatConfiguration
                                                           + "," + (int)EnumTaskType.Inventory +
                                                           "," + (int)EnumTaskType.ExecuteInitEj +
                                                           "," + (int)EnumTaskType.CaptureScreen +
                                                           "," + (int)EnumTaskType.StartService +
                                                           "," + (int)EnumTaskType.StopService +
                                                           "," + (int)EnumTaskType.GetRunningServices +
                                                           "," + (int)EnumTaskType.GetApplicationName +
                                                           ") and atm.atm_id <= " + LicenseManager.MaxLicensedATMID()
                                   + " and (status in ('uploadingDisconnected','scheduled') " +
                                   " or (status in ('initiating','uploading','resumedUploading') " +
                                   " and last_invoked < dateadd(hh,-5,getdate()))) and retry_remaining > 0";

                reader = cmd.ExecuteReader();
                //reader = Task.ExecuteReader(String.Format(@");
                //CashOrders cashOrders = null;
                while (reader.Read())
                {
                    //string coreConnectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
                    //coreConnectionStr = Encryption.Cryptic.DecryptString(coreConnectionStr, Helper.ConstractKey(false));

                    //ConnectionFactory.connectionStringCash = coreConnectionStr.Replace("Core", "Cash");
                    uploadingTask = ServicesDAL.Task.LoadTaskByPk(reader.GetInt64(0), DatabaseName.Cash);
                    //uploadingTask = TxDAL.Task.LoadTaskByPk(reader.GetInt64(0), new DateTime(2023,7,10,15,16,30), DatabaseName.Cash); 

                    if (uploadingTask != null)
                    {
                        Uploader uploader = new Uploader(uploadingTask);
                        uploader.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                timerExecCashOrderOrConfigTask.Change(new TimeSpan(0, EView360Server.appSettings.RefreshInterval, 0), new TimeSpan(0, 1, 0));
                task.EndTask();
                if (conn != null)
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
            }
        }

        public static void InitLogger()
        {
            XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EView360Server{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));

            try
            {
                LogableTask.DefaultTraceLevel = (TraceLevel)Enum.Parse(typeof(TraceLevel), appSettings.ServiceLogLevel);
            }
            catch
            {
                LogableTask.DefaultTraceLevel = TraceLevel.Info;
                LogableTask.LogMonoActivityTask("GetTraceLevel", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Failed to extract trace level from database");
            }
        }

        void DoWork(object state)
        {
            timerCashDataDownloader.Change(-1, -1);

            try
            {
                //XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\CurrencyManagement_{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                InitLogger();

                if (appSettings.RefreshInterval == 0)
                    appSettings.RefreshInterval = 10;
                else if (appSettings.RefreshInterval > 720)
                    appSettings.RefreshInterval = 720;


                PerformDownloads(LicenseManager.MaxLicensedATMID(), DatabaseName.Cash);
                PerformDownloads(LicenseManager.MaxLicensedATMID(), DatabaseName.Tx);


            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("Dowork", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                EventLog.WriteEntry("EView360Server", "Error in DoWork(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
            }

            int defaultInterval = 5; //minutes
            try
            {
                if (appSettings == null)
                    EventLog.WriteEntry("EView360Server", "Error in DoWork(). detail: AppSettings not loaded");
                else
                {
                    defaultInterval = appSettings.CurrencyServerRefreshInterval.Value;
                    LogableTask.LogMonoActivityTask("Dowork", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep for " + defaultInterval + " seconds");
                }
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("Dowork", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                timerCashDataDownloader.Change(new TimeSpan(0, 0, defaultInterval), new TimeSpan(0, 0, 0, 0, -1));
            }
        }

        void PerformDownloads(int maxLicensedATMId, DatabaseName dbName)
        {
            LogableTask task = LogableTask.NewTask("PerformDownloads");
            //int count = 0;
            SqlConnection conn = null;
            List<long> atmIds = new List<long>();
            try
            {

                conn = ConnectionFactory.GetNewConnection(dbName);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandTimeout = 180;
                cmd.CommandText = @"select task_id, ip, task.created_by 
                                    from task inner join core..atm 
                                    on task.atm_id = atm.atm_id 
                                    and atm.is_active = 1 and atm.atm_id <=" + maxLicensedATMId +
                                    " and task_type_id =" + (int)EnumTaskType.OnDemandRequest +
                                    " and (status in ('downloadingDisconnected','scheduled','nameReceived','sizeReceived','initiating') " +
                                     " or (status in ('downloading','resumedDownloading') " +
                                     " and last_invoked < dateadd(hh,-5,getdate()))) " +
                                     " and retry_remaining >0 order by task.creation_time";
                SqlDataReader reader = cmd.ExecuteReader();

                //Task.TaskReader taskReader = Task.ExecuteReader(" task_type_id = " + (int)EnumTaskType.CashDataDownload + " and status in ('downloadingDisconnected','scheduled','nameReceived','sizeReceived') or (status in ('downloading','resumedDownloading') and last_invoked < dateadd(hh,-5,getdate())) and retry_remaining >0 order by creation_time");
                while (reader.Read())
                {
                    //      count++;

                    if (ActiveDownloads.Count > (10 * processorCount))
                    {
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "taking a minute off");
                        Thread.Sleep(15 * 1000);
                    }


                    ServicesDAL.Task downloadTask = ServicesDAL.Task.LoadTaskByPk(reader.GetInt64(0), dbName);

                    //if (downloadTask.ATMId > maxLicensedATMId)
                    //{
                    //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Warning, "ATM id " + downloadTask.ATMId + " is not licensed");
                    //    continue;
                    //}

                    if (!atmIds.Contains(downloadTask.ATMId))
                        atmIds.Add(downloadTask.ATMId);
                    else
                    {
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Already downloading");
                        continue;
                    }



                    scheduleTerminalIP = reader.GetString(1);
                    //Disabling this condition as its observed in production that on some ATMs files are not getting downloaded because of this check.
                    //**************************************************
                    //Changes done on 20/11/2013
                    //**************************************************
                    //if (!TerminalAlreadyConnected(scheduleTerminalIP))
                    //{

                    Downloader downloader = new Downloader(downloadTask);
                    downloader.requestInitiatedAT = DateTime.Now;
                    lock (EView360Server.ActiveDownloads)
                    {
                        ActiveDownloads.Add(downloader);
                    }
                    if (downloader.Start(dbName))
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info,
                        string.Format(" going to start download for {0} at {2}, {1} atms in queue ", downloader.ATMIP, ActiveDownloads.Count, downloader.requestInitiatedAT));
                    //**************************************************
                    //}
                    //else
                    //{
                    //    LogableTask.LogMonoActivityTask("ScheduleDownload", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                    //    string.Format(" Terminal {0} already connected,job id {1}, created by {2}", scheduleTerminalIP, reader.GetInt32(0), reader.GetInt32(2)));
                    //}
                    //**************************************************
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Commented on 15Nov2015 to avoid delay in downloading....
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (ActiveDownloads.Count > 3)
                        Thread.Sleep(3000); //to avoid boombardment of downloads

                }
                //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info,"Jobs found"+count);
                reader.Close();
                atmIds.Clear();
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                task.EndTask();
                if (conn != null)
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();

            }
        }



        bool TerminalAlreadyConnected(string scheduleTerminalIP)
        {
            for (int i = 0; i < ActiveDownloads.Count; i++)
            {
                if (ActiveDownloads[i].ATMIP == scheduleTerminalIP)
                {
                    if (ActiveDownloads[i].requestInitiatedAT < DateTime.Now.AddHours(-6))
                    {
                        try
                        {
                            if (ActiveDownloads[i].currentThread != null && ActiveDownloads[i].currentThread.IsAlive)
                            {
                                ActiveDownloads[i].currentThread.Abort();
                                LogableTask.LogMonoActivityTask("Scheduling", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, string.Format("Thread aborted for terminal {0}", ActiveDownloads[i].ATMIP));
                            }
                        }
                        catch (Exception ex)
                        {
                            LogableTask.LogMonoActivityTask("Scheduling", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, string.Format("Exception occured while trying to kill thread for terminal {0}-{1}", ActiveDownloads[i].ATMIP, ex.Message));
                        }

                        lock (EView360Server.ActiveDownloads)
                        {
                            ActiveDownloads.RemoveAt(i);
                            LogableTask.LogMonoActivityTask("Scheduling", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, string.Format("Terminal {0} removed because 6 hrs have been elapsed", ActiveDownloads[i].ATMIP));
                            i--;
                        }
                        return false;
                    }
                    else
                        return true;
                }
            }
            return false;
        }









    }
}
