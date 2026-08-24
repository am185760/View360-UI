//using Avanza.CCMS.Parser;
using Encryption;
using EView360Consumer;
using Microsoft.Win32;
using Newtonsoft.Json;
using ServicesDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Avanza.CCMS
{

    public partial class EView360CashDataParser : ServiceBase
    {
        List<int> msgProc = new List<int>();
        long taskID = 0;
        DataTable dtRegions = new DataTable();
        Timer timerScheduleThreadForExecution;
        //public static string keepOneCashDataStoreName = System.Configuration.ConfigurationManager.AppSettings["keepOneCashDataStoreName"];
        public static string processingOrder = System.Configuration.ConfigurationManager.AppSettings["processingOrder"];
        System.Threading.Timer timer;
        LogableTask task;
        public static AppSetting appSetting = null;
        int maxUnzippedFileSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxUnzippedFileSizeToParse"]);
        int maxProcessor = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxProcessor"]);
        //string outputArchiveFolderPath;
        string ejfile = string.Empty;
        SqlTransaction trxn = null;
        SqlConnection conn = null;
        //private static MessageQueue queue = new MessageQueue($@".\private$\{ConfigurationManager.AppSettings["CounterParserQueueName"]}");

        //protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        DoWork();
        //        //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //        await System.Threading.Tasks.Task.Delay(5*60*1000, stoppingToken);//TODO: to be changed later
        //    }
        //}
        void ScheduleThreadForExecution(object state)
        {
            try
            {
                string connStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
                connStr = Cryptic.DecryptString(connStr, Helper.ConstractKey(false)).Replace("\0", "");
                ConnectionFactory.Initialize(connStr, false, DatabaseName.Core);
                ConnectionFactory.Initialize(connStr.Replace("Core", "cash"), false, DatabaseName.Cash);
                appSetting = AppSetting.LoadAppSetting("1=1");
                if (appSetting == null)
                    throw new Exception("appSetting table is empty.");
                XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\EView360CashDataParser_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                LogableTask.DefaultTraceLevel = (TraceLevel)Enum.Parse(typeof(TraceLevel), appSetting.ServiceLogLevel);
                LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EView360CashDataParser Build 1.0.0.0 Build Date :18 Mar 2023");


                timer = new System.Threading.Timer(new System.Threading.TimerCallback(DoWork), null, new TimeSpan(0, 0, 5),
                                       new TimeSpan(0, 0, 0, 0, -1));
                //ExecuteQueue();

                EventLog.WriteEntry("EView360CashDataParser", "Service Started Successfully", EventLogEntryType.Information);                
            }
            catch (Exception ex)
            {
                //trying to log error in event log if its not full.
                try
                {
                    EventLog.WriteEntry("EView360CashDataParser", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    //EventLog.WriteEntry("CurrencyMngServer", "Service is idle", EventLogEntryType.Warning);
                    timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception innerException)
                {
                }
            }
        }


        protected override void OnStart(string[] args)
        {
            timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 5), new TimeSpan(0, 0, 0, 0, -1));
            EventLog.WriteEntry("EView360CashDataParser", "Thread schedular sent startup request", EventLogEntryType.Information);

        }

        protected override void OnStop()
        {
            try
            {
                timer.Dispose();

                LogableTask task = LogableTask.NewTask("Service Stopped");
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Warning, "Stopping");
                task.EndTask();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("CCMSEJPARSER", "Error in OnStop(). detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
            }
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        //public void ExecuteQueue()
        //{
        //    try
        //    {
        //        if (queue != null)
        //        {
        //            queue.ReceiveCompleted += Queue_ReceiveCompleted;
        //            queue.BeginReceive();
        //        }
        //        else
        //            LogableTask.LogMonoActivityTask("ExecuteQueue", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, "CashDataParser Queue do not exist");
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("CashDataParser - ExecuteQueue", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
        //        LogableTask.LogMonoActivityTask("ExecuteQueue", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //    }
        //}


        //private async void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        //{
        //    try
        //    {
        //        Message message = queue.EndReceive(e.AsyncResult);
        //        message.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
        //        FileDetail fileDetail = JsonConvert.DeserializeObject<FileDetail>(message.Body.ToString());
        //        string respone = ParseDataForMessageBus(fileDetail.fileContent, fileDetail.atmIp);
        //        if (respone == "success")
        //        {
        //            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
        //            string url = ConfigurationManager.AppSettings["View360Url"];
        //            WebRequest request = WebRequest.Create(url);
        //            using (WebResponse response = await request.GetResponseAsync())
        //            {
        //                // Process the response if needed
        //            }
        //            ServicePointManager.ServerCertificateValidationCallback = null;
        //            File.Delete(fileDetail.fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogableTask.LogMonoActivityTask("Queue_ReceiveCompleted", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

        //    }
        //    finally
        //    {
        //        try
        //        {
        //            queue.BeginReceive();

        //        }
        //        catch (Exception ex)
        //        {
        //            LogableTask.LogMonoActivityTask("Queue_ReceiveCompleted", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //        }
        //    }
        //}

        //private void CreateRequiredDir()
        //{

        //    if (appSetting.DailyFeedOutputFilePath == null)
        //        throw new Exception("Output Folder Path is not defined!");

        //    outputArchiveFolderPath = appSetting.DailyFeedOutputFilePath + "\\OutputArchive";

        //    if (!Directory.Exists(outputArchiveFolderPath))
        //        Directory.CreateDirectory(outputArchiveFolderPath);


        //    if (!Directory.Exists(appSetting.DailyFeedOutputFilePath))
        //        Directory.CreateDirectory(appSetting.DailyFeedOutputFilePath);



        //}




        //        private void ExecuteDFSchedules(object state)
        //        {
        //            int schemeCount = 0;
        //            LogableTask task = LogableTask.NewTask("ExecuteDailyFeedSchedules");
        //            timerExecuteDFSchedules.Change(-1, -1);
        //            DailyFeedSchedule.DailyFeedScheduleReader reader = null;
        //            int count = 0;
        //            try
        //            {

        //                if (!(DateTime.Today.Hour >= fromExecTime && DateTime.Today.Hour<=toExecTime ))
        //                {
        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Will be executed from "+fromExecTime + " to "+toExecTime);
        //                    return;
        //                }

        //                CMS cms = null;

        //                reader = DailyFeedSchedule.ExecuteReader("is_executed = 0 and retry_count>0 and (schedule_date is null or schedule_date<=getdate())");
        //                while (reader.Read())
        //                {

        //                    if (count == 0)
        //                    {
        //                        if (appSetting.HoldOtherDfTasks)
        //                        {
        //                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Other DF Generation job is in process state.");
        //                            return;
        //                        }
        //                        appSetting.HoldOtherDfTasks = true;
        //                        appSetting.Save();
        //                        count = 1;
        //                    }


        //                    reader.CurrentDailyFeedSchedule.RetryCount--;
        //                    reader.CurrentDailyFeedSchedule.Save();


        //                    if (cms == null)
        //                        cms = new CMS();

        //                    //string mcn = reader.CurrentDailyFeedSchedule.Mcn;
        //                    DateTime dateFrom = reader.CurrentDailyFeedSchedule.DateFrom;
        //                    DateTime dateTo = reader.CurrentDailyFeedSchedule.DateTo;
        //                    TimeSpan timeSpan = dateTo - dateFrom;
        //                    int numberOfDays = timeSpan.Days;
        //                    for (int i = 0; i <= numberOfDays; i++)
        //                    {
        //                        cms.SetSummaryDay = dateFrom;
        //                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to generate summary for Day : " + dateFrom);
        //                        schemeCount = 0;


        //                        if (reader.CurrentDailyFeedSchedule.Mcn.Length > 0)
        //                        {
        //                            DailyFeedScheme.DailyFeedSchemeReader readerDailyFeedScheme = DailyFeedScheme.ExecuteReader("mcn='" + reader.CurrentDailyFeedSchedule.Mcn + "'");
        //                            //Region.RegionReader regionReader = Region.ExecuteReader("mcn = '" + mcn + "' and is_active=1");                      
        //                            //while (regionReader.Read())
        //                            //{
        //                            while (readerDailyFeedScheme.Read())
        //                            {
        //                                List<int> list = new List<int>();
        //                                string mcn = readerDailyFeedScheme.CurrentDailyFeedScheme.Mcn;
        //                                bool isSplitByCountry = readerDailyFeedScheme.CurrentDailyFeedScheme.IsSplitByCountry;

        //                                if (isSplitByCountry)
        //                                {
        //                                    SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
        //                                    cmd.CommandText = @"SELECT atm_id,region.mcn,country,region.region_id FROM 
        //                                                        MCN_ATMS, region
        //                                                        where region.region_id = mcn_atms.region_id 
        //                                                        and region.mcn = '" + mcn + "'";

        //                                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //                                    DataTable dt = new DataTable();
        //                                    adapter.Fill(dt);

        //                                    cmd.CommandText = "select daily_feed_file_prefix,region_id from daily_feed_config where daily_feed_scheme_id =" + readerDailyFeedScheme.CurrentDailyFeedScheme.DailyFeedSchemeId;
        //                                    adapter.SelectCommand = cmd;
        //                                    DataTable dtConfig = new DataTable();
        //                                    adapter.Fill(dtConfig);

        //                                    if (dtConfig.Rows.Count == 0)
        //                                        throw new Exception("daily feed config is undefined");

        //                                    DataRowCollection coll = dt.DefaultView.ToTable(true, new string[] { "country" }).Rows;
        //                                    for (int j = 0; j < coll.Count; j++)
        //                                    {
        //                                        DataRow[] drArray = dt.Select("country='" + coll[j][0] + "'");
        //                                        DataRow[] drConfigArray = dtConfig.Select("region_id=" + drArray[0][3]);
        //                                        foreach (DataRow dr in drArray)
        //                                        {
        //                                            list.Add(int.Parse(dr[0].ToString()));
        //                                        }


        //                                        cms.Initialize();
        //                                        cms.BuildSummary(task, list, null, reader.CurrentDailyFeedSchedule.DeleteCurrentData.Value, reader.CurrentDailyFeedSchedule.EnableDffGeneration.Value);
        //                                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");

        //                                        Region region = Region.LoadRegion("is_organization=1 and is_Active=1 and region_id=" + drArray[0][3]);

        //                                        string outputFilePath = region.DailyFeedOutputFilePath + "\\" + drConfigArray[0][0].ToString() + dateFrom.ToString("yyyyMMdd") + ".atm.wrk";

        //                                        if (!Directory.Exists(region.DailyFeedOutputFilePath))
        //                                            Directory.CreateDirectory(region.DailyFeedOutputFilePath);

        //                                        if (File.Exists(outputFilePath))
        //                                            File.Delete(outputFilePath);

        //                                        if (!Directory.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload"))
        //                                            Directory.CreateDirectory(region.DailyFeedOutputFilePath + "\\PendingUpload");

        //                                        if (region.IsDffVersion2Configured)
        //                                            File.WriteAllText(outputFilePath, cms.FormatToDFFVersion2());
        //                                        else
        //                                            File.WriteAllText(outputFilePath, cms.GetOutput());

        //                                        if (File.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath)))
        //                                            File.Delete(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));

        //                                        File.Move(outputFilePath, region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));


        //                                        FtpFileInfo ftpFileInfo = new FtpFileInfo();
        //                                        ftpFileInfo.CreationTime = DateTime.Now;
        //                                        ftpFileInfo.FtpFilename = region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
        //                                        ftpFileInfo.RegionId = int.Parse(drConfigArray[0][1].ToString());
        //                                        ftpFileInfo.RetryCount = region.RetryCountDffUpload;
        //                                        //Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
        //                                        //if (server == null) throw new Exception("Server configuration is missing.");
        //                                        //ftpFileInfo.ServerId = server.ServerId;
        //                                        ftpFileInfo.Status = UploadStates.scheduled.ToString();
        //                                        ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
        //                                        ftpFileInfo.Save();

        //                                        AlertManager.GenerateCCMSEvent(
        //                                            EventType.ManualDFFGeneration.ToString(),
        //                                            EventType.ManualDFFGeneration.ToString(),
        //                                            Event_Type.Alert.ToString(),
        //                                            ftpFileInfo.RegionId.ToString(),
        //                                            EntityType.Organization.ToString(),
        //                                            Actors.BANK.ToString(),
        //                                            Actors.CCMS.ToString(), null);


        //                                    }

        //                                }
        //                                else
        //                                {
        //                                    McnAtms.McnAtmsReader mcnAtmsReader = McnAtms.ExecuteReader("mcn='" + mcn + "'");
        //                                    while (mcnAtmsReader.Read())
        //                                    {
        //                                        list.Add(mcnAtmsReader.CurrentMcnAtms.AtmId);
        //                                    }
        //                                    mcnAtmsReader.Close();

        //                                    cms.Initialize();
        //                                    cms.BuildSummary(task, list, null, reader.CurrentDailyFeedSchedule.DeleteCurrentData.Value, reader.CurrentDailyFeedSchedule.EnableDffGeneration.Value);
        //                                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");

        //                                    DailyFeedConfig dailyFeedConfig = DailyFeedConfig.LoadDailyFeedConfig("daily_feed_scheme_id=" + readerDailyFeedScheme.CurrentDailyFeedScheme.DailyFeedSchemeId);
        //                                    if (dailyFeedConfig == null)
        //                                        throw new Exception("daily feed config is undefined");
        //                                    int maxRegionId = (int)ConnectionFactory.ExecuteScalar("select max(region_id) from region where mcn='" + mcn + "'");

        //                                    Region region = Region.LoadRegionByPk(maxRegionId);
        //                                    // int region_id = region.RegionId.Value;

        //                                    string outputFilePath = region.DailyFeedOutputFilePath + "\\" + dailyFeedConfig.DailyFeedFilePrefix + dateFrom.ToString("yyyyMMdd") + ".atm.wrk";
        //                                    if (!Directory.Exists(region.DailyFeedOutputFilePath))
        //                                        Directory.CreateDirectory(region.DailyFeedOutputFilePath);

        //                                    if (File.Exists(outputFilePath))
        //                                        File.Delete(outputFilePath);

        //                                    if (!Directory.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload"))
        //                                        Directory.CreateDirectory(region.DailyFeedOutputFilePath + "\\PendingUpload");

        //                                    if (region.IsDffVersion2Configured)
        //                                        File.WriteAllText(outputFilePath, cms.FormatToDFFVersion2());
        //                                    else
        //                                        File.WriteAllText(outputFilePath, cms.GetOutput());

        //                                    //File.WriteAllText(outputFilePath + "_1", cms.FormatToDFFVersion2());
        //                                    if (File.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath)))
        //                                        File.Delete(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));

        //                                    File.Move(outputFilePath, region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));
        //                                    FtpFileInfo ftpFileInfo = new FtpFileInfo();
        //                                    ftpFileInfo.CreationTime = DateTime.Now;
        //                                    ftpFileInfo.FtpFilename = region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
        //                                    ftpFileInfo.RegionId = region.RegionId;
        //                                    ftpFileInfo.RetryCount = region.RetryCountDffUpload;

        //                                    //Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
        //                                    //if (server == null) throw new Exception("Server configuration is missing.");
        //                                    //ftpFileInfo.ServerId = server.ServerId;

        //                                    ftpFileInfo.Status = UploadStates.scheduled.ToString();
        //                                    ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
        //                                    ftpFileInfo.Save();
        //                                    AlertManager.GenerateCCMSEvent(
        //                     EventType.ManualDFFGeneration.ToString(),
        //                     EventType.ManualDFFGeneration.ToString(),
        //                     Event_Type.Alert.ToString(),
        //                     ftpFileInfo.RegionId.ToString(),
        //                     EntityType.Organization.ToString(),
        //                     Actors.BANK.ToString(),
        //                     Actors.CCMS.ToString(), null);

        //                                }

        //                                schemeCount++;
        //                            }

        //                            readerDailyFeedScheme.Close();
        //                        }
        //                        else
        //                        {
        //                            List<int> list = new List<int>();
        //                            list.Add(reader.CurrentDailyFeedSchedule.AtmId.Value);
        //                            cms.Initialize();
        //                            cms.BuildSummary(task, list, true, reader.CurrentDailyFeedSchedule.DeleteCurrentData.Value, reader.CurrentDailyFeedSchedule.EnableDffGeneration.Value);
        //                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated from schedule for atm" +
        //                                reader.CurrentDailyFeedSchedule.AtmId.Value + " for the date" + reader.CurrentDailyFeedSchedule.DateFrom);
        //                        }


        //                        dateFrom = dateFrom.AddDays(1);
        //                    }
        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "scheme count: " + schemeCount);

        //                    if (reader.CurrentDailyFeedSchedule.AtmId == null || (reader.CurrentDailyFeedSchedule.AtmId != null && !cms.isEmptyDataGenerated))
        //                    {
        //                        reader.CurrentDailyFeedSchedule.IsExecuted = true;
        //                        reader.CurrentDailyFeedSchedule.Save();
        //                        if (reader.CurrentDailyFeedSchedule.AtmId != null)
        //                            AlertManager.GenerateTerminalAlert(reader.CurrentDailyFeedSchedule.AtmId.Value, (int)EnumAlertType.SummaryDataRegenerated, "", Event_Type.Information);
        //                    }

        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                try
        //                {
        //                    //if (reader.CurrentDailyFeedSchedule.RetryCount == 0)
        //                    //{
        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, ex);
        //                    reader.CurrentDailyFeedSchedule.FailureReason = ex.Message;
        //                    reader.CurrentDailyFeedSchedule.Save();
        //                    //s}
        //                }
        //                catch (Exception innerEx)
        //                {
        //                    try
        //                    {
        //                        EventLog.WriteEntry("EView360CashDataParser", innerEx.Message + " " + innerEx.StackTrace);
        //                    }
        //                    catch (Exception Ex)
        //                    {
        //                    }
        //                }

        //            }
        //            finally
        //            {

        //                try
        //                {
        //                    timerExecuteDFSchedules.Change(new TimeSpan(0, (int)appSetting.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));



        //                    appSetting.HoldOtherDfTasks = false;
        //                    appSetting.Save();


        //                    task.EndTask();
        //                    if (reader != null)
        //                        reader.Close();
        //                }
        //                catch (Exception ex)
        //                {
        //                    try
        //                    {
        //                        EventLog.WriteEntry("EView360CashDataParser", ex.Message + " " + ex.StackTrace);
        //                    }
        //                    catch (Exception innerEx)
        //                    {
        //                    }
        //                }
        //            }
        //        }

        //private void UploadDfs(object obj)
        //{
        //    LogableTask task = LogableTask.NewTask("uploadDFs");
        //    timerUploadDFs.Change(-1, -1);
        //    FtpFileInfo.FtpFileInfoReader reader = null;
        //    try
        //    {
        //        reader = FtpFileInfo.ExecuteReader("status = '" + FTPUploadStatus.scheduled.ToString() + "' and retry_count > 0 and task_type_id = " + (int)EnumTaskType.DailyFeedUpload);
        //        while (reader.Read())
        //        {
        //            reader.CurrentFtpFileInfo.RetryCount--;
        //            reader.CurrentFtpFileInfo.LastInvokedAt = DateTime.Now;
        //            reader.CurrentFtpFileInfo.Save();


        //            try
        //            {
        //                string FileName = reader.CurrentFtpFileInfo.FtpFilename;
        //                if (!File.Exists(FileName))
        //                    throw new Exception("file " + FileName + " does not exists");
        //                int organization_id = reader.CurrentFtpFileInfo.RegionId;
        //                Region region = Region.LoadRegion("region_id=" + organization_id);
        //                if (region.IsSecuredAccess.Value)
        //                {
        //                    string remoteFilePrefix = null;
        //                    string remoteFileName = null;
        //                    Scp scp = new Scp();
        //                    int port = 22;
        //                    string[] parts = region.DailyFeedFtpUri.Split(':');
        //                    string[] subParts = parts[0].Split('/');
        //                    string server = subParts[0];
        //                    if (subParts.Length > 1)
        //                        remoteFilePrefix = parts[0].Substring(parts[0].IndexOf('/') + 1);

        //                    if (parts.Length > 1)
        //                        port = int.Parse(parts[1]);

        //                    if (remoteFilePrefix != null)
        //                        remoteFileName = remoteFilePrefix + "/" + Path.GetFileName(FileName);
        //                    else
        //                        remoteFileName = Path.GetFileName(FileName);


        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + FileName);
        //                    scp.DoWork(FileName, server, remoteFileName,
        //                       region.DailyFeedFtpUsername, Cryptic.DecryptString(region.DailyFeedFtpPassword), port, remoteFileName.Substring(0, remoteFileName.IndexOf(".wrk")));
        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded,Permissions Changed and Renamed Operation Completed Successfully");

        //                }
        //                else
        //                {
        //                    FTPManager ftpManager = new FTPManager();
        //                    ftpManager.FtpPassword = Cryptic.DecryptString(region.DailyFeedFtpPassword);
        //                    ftpManager.FtpServerIP = region.DailyFeedFtpUri;
        //                    ftpManager.FtpUserId = region.DailyFeedFtpUsername;


        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + FileName);
        //                    ftpManager.UploadFile(FileName); // already there :)
        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded Successfully");


        //                    string currentFileName = Path.GetFileName(FileName);
        //                    ftpManager.RenameFile(currentFileName, currentFileName.Substring(0, currentFileName.IndexOf(".wrk")));
        //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Renamed Successfully on FTP server");
        //                }



        //                if (File.Exists(outputArchiveFolderPath + "\\" + Path.GetFileName(FileName)))
        //                    File.Delete(outputArchiveFolderPath + "\\" + Path.GetFileName(FileName));

        //                File.Move(FileName, outputArchiveFolderPath + "\\" + Path.GetFileName(FileName));



        //                reader.CurrentFtpFileInfo.Status = FTPUploadStatus.completed.ToString();
        //                reader.CurrentFtpFileInfo.EndTime = DateTime.Now;
        //                reader.CurrentFtpFileInfo.FailureReason = "";
        //                reader.CurrentFtpFileInfo.Save();
        //                AlertManager.GenerateCCMSEvent
        //                                        (EventType.DFFGeneration.ToString(), EventType.DFFGeneration.ToString(), Event_Type.Alert.ToString(),
        //                                       organization_id.ToString(), EntityType.Organization.ToString(),
        //                                        Actors.CCMS.ToString(), Actors.CCMS.ToString(), null);

        //            }
        //            catch (Exception ex)
        //            {
        //                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //                if (ex.Message.Replace("'", "''").Length > 255)
        //                    reader.CurrentFtpFileInfo.FailureReason = ex.Message.Replace("'", "''").Substring(0, 255);
        //                else
        //                    reader.CurrentFtpFileInfo.FailureReason = ex.Message.Replace("'", "''");

        //                if (reader.CurrentFtpFileInfo.RetryCount == 0)
        //                {
        //                    reader.CurrentFtpFileInfo.Status = FTPUploadStatus.failed.ToString();
        //                    //time to generate alert;
        //                    AlertManager.GenerateOrganizationAlert(reader.CurrentFtpFileInfo.FtpFileInfoId, (int)EnumAlertType.DailyFeedUpload, null, Event_Type.Error, reader.CurrentFtpFileInfo.RegionId);
        //                    AlertManager.GenerateCCMSEvent
        //                                        (EventType.DFFUploadFailed.ToString(), EventType.DFFUploadFailed.ToString(),
        //                                        Event_Type.Error.ToString(),
        //                                       reader.CurrentFtpFileInfo.RegionId.ToString(), EntityType.Organization.ToString(),
        //                                        Actors.CCMS.ToString(), Actors.OPTICash.ToString(), null);


        //                    //Alert alert = new Alert();
        //                    //alert.GeneratedA = DateTime.Now;
        //                    //alert.AlertTypeId = (int)EnumAlertType.DailyFeedUpload;
        //                    ////alert.Source = "RaiseAlertIfNeeded";
        //                    //alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

        //                    //alert.FtpFileInfoId = reader.CurrentFtpFileInfo.FtpFileInfoId;
        //                    //alert.Save();

        //                    //Notification notify = new Notification();
        //                    //notify.AlertId = alert.AlertId;
        //                    ////notify.NotificationMsg = "Daily Feed Upload Failed";
        //                    //notify.RetryRemaining = appSetting.MaxTries;
        //                    //notify.NotificationSent = false;
        //                    //notify.Save();

        //                    //                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert and notification added");

        //                }
        //                reader.CurrentFtpFileInfo.Save();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //    }

        //    finally
        //    {
        //        try
        //        {
        //            if (reader != null)
        //                reader.Close();
        //            timerUploadDFs.Change(new TimeSpan(0, (int)appSetting.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
        //            task.EndTask();
        //        }
        //        catch (Exception ex)
        //        {
        //            try
        //            {
        //                EventLog.WriteEntry("EView360CashDataParser", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
        //            }
        //            catch (Exception innerException)
        //            {
        //            }

        //        }
        //    }
        //}


        private void DoWork(object state)
        {
            timer.Change(-1, -1);
            try
            {                
                if (appSetting.ParsingEnabled)
                {
                    DateTime dtStart = DateTime.Now;
                    for (int i = 0; i < maxProcessor; i++)
                    {
                        if (!msgProc.Contains(i + 1))
                        {
                            msgProc.Add(i + 1);
                            LogableTask.LogMonoActivityTask("parsing", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to start parsing");
                            /// LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Thread Created for message processor Id = " + msgProc[i]);
                            Thread thread = new Thread(ParseCashData);
                            thread.Start(i + 1);
                            //threads.Add(thread);

                            //Change done by IK on 05-10-2015.
                            //To avoid multiple threads ,parsing same file issue in NBE
                            Thread.Sleep(2000);
                        }
                    }
                    

                }
                else
                    LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Parsing is turned off");             

            }
            catch (Exception ex)
            {
                try
                {
                    LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

                    if (trxn != null)
                        trxn.Rollback();
                }
                catch (Exception innerException)
                {
                }

            }
            finally
            {
                try
                {
                   
                    if (conn != null)
                        conn.Close();

                    if (appSetting != null)
                    {
                        LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep for " + appSetting.CcmsParserRefreshInterval + " min");
                        timer.Change(new TimeSpan(0, appSetting.CcmsParserRefreshInterval.Value, 0), new TimeSpan(0, 0, 0, 0, -1));
                    }                        
                }
                catch (Exception ex)
                {
                    try
                    {
                        EventLog.WriteEntry("EView360CashDataParser", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    }
                    catch (Exception innerException)
                    {
                    }

                }

            }

        }

        private string GetConnectionByAtmIp(string ip)
        {
            string connStr = string.Empty;
            DataRequestor.ConnectionInitializer initializer = new DataRequestor.ConnectionInitializer();
            List<string> RequestsInfo = initializer.FilterRequest(new List<string> { ip }, true);
            if (RequestsInfo?.Count > 0)
            {
                DataRequestor.DBServerInfo server = new DataRequestor.DBServerInfo
                {
                    ServerConnection = initializer.DBServers[0].ServerConnection,
                    ServerCredentials = initializer.DBServers[0].ServerCredentials
                };
                connStr = Cryptic.DecryptString(server.ServerConnection, Helper.ConstractKey(false)).TrimEnd('\0') + Cryptic.DecryptString(server.ServerCredentials, Helper.ConstractKey(false)).TrimEnd('\0');
            }
            return connStr;
        }

        public string ParseDataForMessageBus(string ejString, string atmIp)
        {
            string response = string.Empty;
            Avanza.CCMS.Parser.Parser parser = new Avanza.CCMS.Parser.Parser();
            LogableTask parseCashDataTask = LogableTask.NewTask("ParseTxDataForMessageBus");
            Task dbTask = new Task();
            SqlTransaction dbTrx = null;
            try
            {
                Atm atm = Atm.LoadAtm(" IP = '" + atmIp + "'");

                string connectionStr = GetConnectionByAtmIp(atmIp);
                ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Core);
                ConnectionFactory.Initialize(connectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);
                ConnectionFactory.Initialize(connectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);

                dbTask.ATMId = atm.ATMId;
                dbTask.TaskId = -1;
                
                parser.ParseAndSave(dbTrx, dbTask.ATMId, ejString.Replace("\0", ""), dbTask.TaskId);

                //dbTask.Status = DownloadStates.completed.ToString();
                //dbTask.FailureReason = string.Empty;
                //dbTask.Parsed = true;
                //dbTask.Save(DatabaseName.Cash);

                response = "success";
            }
            catch (Exception ex1)
            {
                response = ex1.Message;

                if (dbTrx != null)
                    dbTrx.Rollback();

                //dbTask.Parsed = false;

                //if (!dbTask.FailedToParseCount.HasValue)
                //    dbTask.FailedToParseCount = 0;

                //if (!appSetting.FailedToParseThreshold.HasValue)
                //    appSetting.FailedToParseThreshold = 3;

                //if (dbTask.FailedToParseCount < appSetting.FailedToParseThreshold)
                //{
                //    dbTask.FailedToParseCount++;
                //    dbTask.Status = DownloadStates.downloadedParsePending.ToString();
                //}
                //else
                //{
                //    dbTask.Status = DownloadStates.parsingFailed.ToString();
                //    // AlertManager.GenerateTerminalAlert(dbTask.ATMId, (int)EnumAlertType.ATMFileParsingFailed, "Parsing failed for terminal " + Atm.LoadAtmByPk(dbTask.ATMId).Title + " for task created on " + dbTask.CreationTime.ToString("dd/MM/yyyy HH:mm:ss"), Event_Type.Error);

                //    //Generate Alert.
                //}

                //dbTask.FailureReason += " " + ex1.Message;
                //dbTask.FailureReason = (dbTask.FailureReason.Length > 512) ? dbTask.FailureReason.Substring(0, 511) : dbTask.FailureReason;
                //dbTask.FailureReason = dbTask.FailureReason.Replace("'", "''");
                //dbTask.Save(DatabaseName.Cash);
                parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex1);

            }
            finally
            {
                parseCashDataTask.EndTask();
            }
            return response;
        }

        private void ParseCashData(object messageProcessorId)
        {
            LogableTask task = LogableTask.NewTask("ParseCashData");
            SqlConnection conn = null;
            Avanza.CCMS.Parser.Parser parser = new Avanza.CCMS.Parser.Parser();
            SqlConnection cashDataConnection = null;
            bool isCashDataConnectionOpened = false;
            SqlCommand cmd = null;
            try
            {   //**************************************************
                //Order by task_id added so that file will be parsed in order.
                //**************************************************

                //string SQL = "select task_id from task with (nolock) where atm_id in (select atm_id from atm where message_processor_id = " + messageProcessorId.ToString() + ") " +
                //    " and unzipped_file_size <=" + maxUnzippedFileSize + " and task_id in ( select task_id from task inner join file_type on file_type.file_type_id = task.file_type_id"
                //+ " where is_ejlog=1 and parsed=0 and retry_remaining>0 and task.file_type_id not in (2,3,4,5,13,14,15,19,16,17,18,10) and (status ='downloadedParsePending' or (status ='downloadedParsing'  and last_invoked < dateadd(hh,-3, getdate())))) order by task_id "+ processingOrder;


                //Task.TaskReader cashDataReader = Task.ExecuteReader();
                conn = ConnectionFactory.GetNewConnection(DatabaseName.Cash);
                SqlCommand cmdDb = conn.CreateCommand();
                cmdDb.CommandText = "FetchTask";
                LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), TraceLevel.Info, "command timeout set to 300");
                cmdDb.CommandTimeout = 300;

                //cmdDb.Parameters.Add("messageProcessorID", messageProcessorId);
                //cmdDb.Parameters.Add("maxUnzippedFileSize", maxUnzippedFileSize);
                //cmdDb.Parameters.Add("processingOrder", processingOrder);

                cmdDb.Parameters.Add("messageProcessorID", SqlDbType.Int);
                cmdDb.Parameters[0].Value = messageProcessorId;

                //cmdDb.Parameters.Add("maxUnzippedFileSize", SqlDbType.Int);
                //cmdDb.Parameters[1].Value = maxUnzippedFileSize;


                cmdDb.Parameters.Add("processingOrder", SqlDbType.VarChar);
                cmdDb.Parameters[1].Value = processingOrder;


                cmdDb.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapterTask = new SqlDataAdapter(cmdDb);
                DataTable dt = new DataTable();
                adapterTask.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                    if (!isCashDataConnectionOpened)
                    {
                        cashDataConnection = ConnectionFactory.GetNewConnection(DatabaseName.Cash);
                        cashDataConnection.Open();
                        cmd = cashDataConnection.CreateCommand();
                        conn.Open();
                        isCashDataConnectionOpened = true;
                    }

                    Task dbTask = Task.LoadTaskByPk(long.Parse(dr[0].ToString()),DatabaseName.Cash);


                    //}


                    //while (cashDataReader.Read())
                    //{

                    LogableTask parseCashDataTask = null;
                    SqlTransaction dbTrx = null;
                    if (dbTask.RetryRemaining > 0)
                        dbTask.RetryRemaining--;
                    taskID = dbTask.TaskId;
                    try
                    {

                        parseCashDataTask = LogableTask.NewTask("Parse Counter File, TaskId=" + dbTask.TaskId);


                        LogableTask.LogMonoActivityTask("Parse EJ", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Parse Cash Data, TaskId=" + dbTask.TaskId);
                        //EjStatus ejStatus = EjStatus.LoadEjStatus("atm_id = " + dbTask.ATMId + " and ejDateTime = convert(datetime,'" + dbTask.EndTime.Value.ToString("dd/MM/yyyy") + "',103)");
                        //if (ejStatus == null)
                        //{
                        //    ejStatus = new EjStatus();
                        //    ejStatus.AtmId = dbTask.ATMId;
                        //    ejStatus.EjDateTime = new DateTime(dbTask.EndTime.Value.Year,
                        //        dbTask.EndTime.Value.Month, dbTask.EndTime.Value.Day);
                        //    ejStatus.RecordedAt = DateTime.Now;
                        //    ejStatus.Save();
                        //}
                        dbTask.LastInvoked = DateTime.Now;
                        dbTask.Status = DownloadStates.downloadedParsing.ToString();
                        dbTask.Save(DatabaseName.Cash);

                        //if (keepOneCashDataStoreName.Length == 0)
                        cashDataConnection.ChangeDatabase("CashDataStore_" + dbTask.CreationTime.Year.ToString());

                        // else
                        //   cashDataConnection.ChangeDatabase(keepOneCashDataStoreName);
                        StringBuilder builder = new StringBuilder(); 
                        cmd.CommandText = "select convert(varchar(MAX),cash_data_file) from cashDataTasks where task_id =" + dbTask.TaskId+ " order by file_creation_time, seq";
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dtCashDataFiles = new DataTable();
                        adapter.Fill(dtCashDataFiles);

                        foreach (DataRow drCashDataFiles in dtCashDataFiles.Rows)
                        {
                            builder.Append(drCashDataFiles[0].ToString().Replace("\0",""));
                        }
                        //byte[] ejData = (byte[])cmd.ExecuteScalar();

                        //if (ejData == null)
                        //{
                        //    throw new Exception("no data found in the CashDataStore for task_id = " + dbTask.TaskId);
                        //}

                        //MemoryStream memStream = new MemoryStream(ejData, false);
                        //ZipInputStream zipStream = new ZipInputStream(memStream);


                        //LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get next entry");
                        //ZipEntry entry = zipStream.GetNextEntry();//only one file expected,ie ej file
                        //LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Next entry extracted");
                        //byte[] unZippedEJ = new byte[entry.Size];
                        //int totalLength = unZippedEJ.Length;
                        //int readByteCount = 0;
                        //LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to populate data in arr");
                        //while (readByteCount < unZippedEJ.Length)
                        //    readByteCount += zipStream.Read(unZippedEJ, readByteCount, unZippedEJ.Length);
                        //LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "arr populated");
                        //zipStream.Close();
                        //parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "EJ unziped");

                        string ejString = builder.ToString();
                        //ejString = Encoding.ASCII.GetString(ejData);


                       // dbTrx = conn.BeginTransaction();
                        cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = "set transaction isolation level read uncommitted";
                        //cmd.ExecuteNonQuery();

                        parser.ParseAndSave(dbTrx, dbTask.ATMId, ejString, dbTask.TaskId);

                        // else
                        //   throw new Exception("Parsing not supported for file Type :" + dbTask.FileTypeId);

                        //dbTrx.Commit();
                        dbTask.Status = DownloadStates.completed.ToString();
                        dbTask.FailureReason = string.Empty;
                        dbTask.Parsed = true;
                        dbTask.Save(DatabaseName.Cash);

                    }
                    catch (Exception ex1)
                    {
                        if (dbTrx != null)
                            dbTrx.Rollback();

                        dbTask.Parsed = false;

                        if (!dbTask.FailedToParseCount.HasValue)
                            dbTask.FailedToParseCount = 0;

                        if (!appSetting.FailedToParseThreshold.HasValue)
                            appSetting.FailedToParseThreshold = 3;

                        if (dbTask.FailedToParseCount < appSetting.FailedToParseThreshold)
                        {
                            dbTask.FailedToParseCount++;
                            dbTask.Status = DownloadStates.downloadedParsePending.ToString();
                        }
                        else
                        {
                            dbTask.Status = DownloadStates.parsingFailed.ToString();
                            // AlertManager.GenerateTerminalAlert(dbTask.ATMId, (int)EnumAlertType.ATMFileParsingFailed, "Parsing failed for terminal " + Atm.LoadAtmByPk(dbTask.ATMId).Title + " for task created on " + dbTask.CreationTime.ToString("dd/MM/yyyy HH:mm:ss"), Event_Type.Error);

                            //Generate Alert.
                        }

                        dbTask.FailureReason += " " + ex1.Message;
                        dbTask.FailureReason = (dbTask.FailureReason.Length > 512) ? dbTask.FailureReason.Substring(0, 511) : dbTask.FailureReason;
                        dbTask.FailureReason = dbTask.FailureReason.Replace("'", "''");
                        dbTask.Save(DatabaseName.Cash);
                        parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex1);

                    }
                    finally
                    {
                        parseCashDataTask.EndTask();
                    }
                }
                // cashDataReader.Close();

            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                if (cashDataConnection != null)
                    cashDataConnection.Close();
                if (conn != null)
                    conn.Close();
                task.EndTask();
                msgProc.Remove((int)messageProcessorId);
                //manualResetEvent.Set();
            }
        }



    

   




    }
    class BankInfo
    {
        public string organizations;
        public string regionsAndOrganizations;
        public string outputFolderPath;
        public string FTPUploadPath;
        public string dailyFeedFilePrefix;
        public List<int> atmIds = new List<int>();
    }
    class FTPManager
    {
        string ftpServerIP;
        string ftpUserID;
        string ftpPassword;

        public string FtpServerIP
        {
            set
            {
                ftpServerIP = value;
            }
        }
        public string FtpUserId
        {
            set
            {
                ftpUserID = value;
            }
        }
        public string FtpPassword
        {
            set
            {
                ftpPassword = value;
            }
        }


        public void RenameFile(string currentFilename, string newFilename)
        {
            DeleteFileAtRemoteEnd(ftpServerIP + "/" + newFilename);

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpServerIP + "/" + currentFilename));
            reqFTP.Method = WebRequestMethods.Ftp.Rename;
            reqFTP.RenameTo = newFilename;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();

            ftpStream.Close();
            response.Close();
        }
        private void DeleteFileAtRemoteEnd(string remoteFilePath)
        {
            LogableTask task = LogableTask.NewTask("DeleteFileAtRemoteEnd");
            FtpWebResponse response = null;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(remoteFilePath)); //Get the object used to communicate with the server.

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                request.KeepAlive = false;
                response = (FtpWebResponse)request.GetResponse();
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, String.Format("File: {0} successfully deleted from FTP", remoteFilePath));
                //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Archival Process complete");
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                //throw new Exception("An exception occured while deleting file");
            }
            finally
            {
                if (response != null)
                    response.Close();

                task.EndTask();
            }
        }
        public void UploadFile(string filePath)
        {
            FileInfo fileInf = new FileInfo(filePath);
            string uri = ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            DeleteFileAtRemoteEnd(uri);
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
                      uri));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID,
                                                       ftpPassword);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read 
            //the file to be uploaded

            FileStream fs = null;
            Stream strm = null;
            try
            {
                fs = fileInf.OpenRead();


                // Stream to which the file to be upload is written
                strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the 
                    // FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            // Close the file stream and the Request Stream
            finally
            {
                if (strm != null)
                    strm.Close();
                if (fs != null)
                    fs.Close();
            }

        }
    }
}
