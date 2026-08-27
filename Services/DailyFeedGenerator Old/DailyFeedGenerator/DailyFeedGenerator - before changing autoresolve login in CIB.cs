using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Data.OleDb;
using Avanza.CCMS.DAL;
using Avanza.iSuite.DAL;
using Microsoft.Win32;
using Encryption;
using System.Reflection;
using System.Threading;
using SharpSsh;


namespace DailyFeedGenerator
{

    public partial class DailyFeedGenerator : ServiceBase
    {

        int taskID = 0;
        DataTable dtRegions = new DataTable();

        System.Threading.Timer timer;
        System.Threading.Timer timerExecuteDFSchedules;
        System.Threading.Timer timerUploadDFs;
        System.Threading.Timer timerAutoResolveUserTasks;
        LogableTask task;
        public static AppSetting appSetting = null;
        int fromExecTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DFFSchedulesFromExecutionTime"]);
        int toExecTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DFFSchedulesToExecutionTime"]);
        string outputArchiveFolderPath = "";
        SqlTransaction trxn = null;
        SqlConnection conn = null;

        public DailyFeedGenerator()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                timer = new System.Threading.Timer(new System.Threading.TimerCallback(DoWork), null, new TimeSpan(0, 0, 25),
                                         new TimeSpan(0, 0, 0, 0, -1));

                timerExecuteDFSchedules = new System.Threading.Timer(new System.Threading.TimerCallback(ExecuteDFSchedules), null, new TimeSpan(0, 3, 0),
                                         new TimeSpan(0, 0, 0, 0, -1));

                timerUploadDFs = new System.Threading.Timer(new System.Threading.TimerCallback(UploadDfs), null, new TimeSpan(0, 2, 0),
                         new TimeSpan(0, 0, 0, 0, -1));

                //timerAutoResolveUserTasks = new System.Threading.Timer(new System.Threading.TimerCallback(AutoResolveUserTasks), null, new TimeSpan(0, 4, 0),
                //                         new TimeSpan(0, 0, 0, 0, -1));


                EventLog.WriteEntry("DailyFeedGenerator", "Service Started Successfully");
            }
            catch (Exception ex)
            {
                try
                {
                    //Event log might be full.
                    EventLog.WriteEntry("DailyFeedGenerator", ex.Message);
                }
                catch (Exception innerException)
                {
                }
            }
        }

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




        private void ExecuteDFSchedules(object state)
        {
            int schemeCount = 0;
            LogableTask task = LogableTask.NewTask("ExecuteDailyFeedSchedules");
            timerExecuteDFSchedules.Change(-1, -1);
            DailyFeedSchedule.DailyFeedScheduleReader reader = null;
            int count = 0;
            try
            {

                if (!(DateTime.Today.Hour >= fromExecTime && DateTime.Today.Hour <= toExecTime))
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Will be executed from " + fromExecTime + " to " + toExecTime);
                    return;
                }

                CMS cms = null;
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to read DFF jobs");
                reader = DailyFeedSchedule.ExecuteReader("is_executed = 0 and retry_count>0 and (schedule_date is null or schedule_date<=getdate())");
                while (reader.Read())
                {

                    if (count == 0)
                    {
                        if (appSetting.HoldOtherDfTasks)
                        {
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Other DF Generation job is in process state.");
                            return;
                        }
                        appSetting.HoldOtherDfTasks = true;
                        appSetting.Save();
                        count = 1;
                    }


                    reader.CurrentDailyFeedSchedule.RetryCount--;
                    reader.CurrentDailyFeedSchedule.Save();


                    if (cms == null)
                        cms = new CMS();

                    //string mcn = reader.CurrentDailyFeedSchedule.Mcn;
                    DateTime dateFrom = reader.CurrentDailyFeedSchedule.DateFrom;
                    DateTime dateTo = reader.CurrentDailyFeedSchedule.DateTo;
                    TimeSpan timeSpan = dateTo - dateFrom;
                    int numberOfDays = timeSpan.Days;
                    for (int i = 0; i <= numberOfDays; i++)
                    {
                        cms.SetSummaryDay = dateFrom;
                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to generate summary for Day : " + dateFrom);
                        schemeCount = 0;


                        if (reader.CurrentDailyFeedSchedule.Mcn.Length > 0)
                        {
                            DailyFeedScheme.DailyFeedSchemeReader readerDailyFeedScheme = DailyFeedScheme.ExecuteReader("mcn='" + reader.CurrentDailyFeedSchedule.Mcn + "'");
                            //Region.RegionReader regionReader = Region.ExecuteReader("mcn = '" + mcn + "' and is_active=1");                      
                            //while (regionReader.Read())
                            //{
                            while (readerDailyFeedScheme.Read())
                            {
                                List<int> list = new List<int>();
                                string mcn = readerDailyFeedScheme.CurrentDailyFeedScheme.Mcn;
                                bool isSplitByCountry = readerDailyFeedScheme.CurrentDailyFeedScheme.IsSplitByCountry;

                                if (isSplitByCountry)
                                {
                                    SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
                                    cmd.CommandText = @"SELECT atm_id,region.mcn,country,region.region_id FROM 
                                                        MCN_ATMS, region
                                                        where region.region_id = mcn_atms.region_id 
                                                        and region.mcn = '" + mcn + "'";

                                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    adapter.Fill(dt);

                                    cmd.CommandText = "select daily_feed_file_prefix,region_id from daily_feed_config where daily_feed_scheme_id =" + readerDailyFeedScheme.CurrentDailyFeedScheme.DailyFeedSchemeId;
                                    adapter.SelectCommand = cmd;
                                    DataTable dtConfig = new DataTable();
                                    adapter.Fill(dtConfig);

                                    if (dtConfig.Rows.Count == 0)
                                        throw new Exception("daily feed config is undefined");

                                    DataRowCollection coll = dt.DefaultView.ToTable(true, new string[] { "country" }).Rows;
                                    for (int j = 0; j < coll.Count; j++)
                                    {
                                        DataRow[] drArray = dt.Select("country='" + coll[j][0] + "'");
                                        DataRow[] drConfigArray = dtConfig.Select("region_id=" + drArray[0][3]);
                                        foreach (DataRow dr in drArray)
                                        {
                                            list.Add(int.Parse(dr[0].ToString()));
                                        }


                                        cms.Initialize();
                                        cms.BuildSummary(task, list, null, reader.CurrentDailyFeedSchedule.DeleteCurrentData.Value, reader.CurrentDailyFeedSchedule.EnableDffGeneration.Value);
                                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");

                                        Region region = Region.LoadRegion("is_organization=1 and is_Active=1 and region_id=" + drArray[0][3]);

                                        string outputFilePath = region.DailyFeedOutputFilePath + "\\" + drConfigArray[0][0].ToString() + dateFrom.ToString("yyyyMMdd") + ".atm.wrk";

                                        if (!Directory.Exists(region.DailyFeedOutputFilePath))
                                            Directory.CreateDirectory(region.DailyFeedOutputFilePath);

                                        if (File.Exists(outputFilePath))
                                            File.Delete(outputFilePath);

                                        if (!Directory.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload"))
                                            Directory.CreateDirectory(region.DailyFeedOutputFilePath + "\\PendingUpload");

                                        if (region.IsDffVersion2Configured)
                                            File.WriteAllText(outputFilePath, cms.FormatToDFFVersion2());
                                        else
                                            File.WriteAllText(outputFilePath, cms.GetOutput());

                                        if (File.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath)))
                                            File.Delete(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));

                                        File.Move(outputFilePath, region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));


                                        FtpFileInfo ftpFileInfo = new FtpFileInfo();
                                        ftpFileInfo.CreationTime = DateTime.Now;
                                        ftpFileInfo.FtpFilename = region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
                                        ftpFileInfo.RegionId = int.Parse(drConfigArray[0][1].ToString());
                                        ftpFileInfo.RetryCount = region.RetryCountDffUpload;
                                        //Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
                                        //if (server == null) throw new Exception("Server configuration is missing.");
                                        //ftpFileInfo.ServerId = server.ServerId;
                                        ftpFileInfo.Status = UploadStates.scheduled.ToString();
                                        ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
                                        ftpFileInfo.Save();

                                        AlertManager.GenerateCCMSEvent(
                                            EventType.ManualDFFGeneration.ToString(),
                                            EventType.ManualDFFGeneration.ToString(),
                                            Event_Type.Alert.ToString(),
                                            ftpFileInfo.RegionId.ToString(),
                                            EntityType.Organization.ToString(),
                                            Actors.BANK.ToString(),
                                            Actors.CCMS.ToString(), null);


                                    }

                                }
                                else
                                {
                                    McnAtms.McnAtmsReader mcnAtmsReader = McnAtms.ExecuteReader("mcn='" + mcn + "' and atm_id in (select atm_id from atm where is_active = 1 and is_dff_generation_halt = 0 and exclude_dff = 0) order by atm_id");
                                    //Change done on 22/05/2014
                                    //McnAtms.McnAtmsReader mcnAtmsReader = McnAtms.ExecuteReader("mcn='" + mcn + "'");
                                    while (mcnAtmsReader.Read())
                                    {
                                        list.Add(mcnAtmsReader.CurrentMcnAtms.AtmId);
                                    }
                                    mcnAtmsReader.Close();

                                    cms.Initialize();
                                    cms.BuildSummary(task, list, null, reader.CurrentDailyFeedSchedule.DeleteCurrentData.Value, reader.CurrentDailyFeedSchedule.EnableDffGeneration.Value);
                                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");

                                    DailyFeedConfig dailyFeedConfig = DailyFeedConfig.LoadDailyFeedConfig("daily_feed_scheme_id=" + readerDailyFeedScheme.CurrentDailyFeedScheme.DailyFeedSchemeId);
                                    if (dailyFeedConfig == null)
                                        throw new Exception("daily feed config is undefined");
                                    int maxRegionId = (int)ConnectionFactory.ExecuteScalar("select max(region_id) from region where mcn='" + mcn + "'");

                                    Region region = Region.LoadRegionByPk(maxRegionId);
                                    // int region_id = region.RegionId.Value;

                                    string outputFilePath = region.DailyFeedOutputFilePath + "\\" + dailyFeedConfig.DailyFeedFilePrefix + dateFrom.ToString("yyyyMMdd") + ".atm.wrk";
                                    if (!Directory.Exists(region.DailyFeedOutputFilePath))
                                        Directory.CreateDirectory(region.DailyFeedOutputFilePath);

                                    if (File.Exists(outputFilePath))
                                        File.Delete(outputFilePath);

                                    if (!Directory.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload"))
                                        Directory.CreateDirectory(region.DailyFeedOutputFilePath + "\\PendingUpload");

                                    if (region.IsDffVersion2Configured)
                                        File.WriteAllText(outputFilePath, cms.FormatToDFFVersion2());
                                    else
                                        File.WriteAllText(outputFilePath, cms.GetOutput());

                                    //File.WriteAllText(outputFilePath + "_1", cms.FormatToDFFVersion2());
                                    if (File.Exists(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath)))
                                        File.Delete(region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));

                                    File.Move(outputFilePath, region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));
                                    FtpFileInfo ftpFileInfo = new FtpFileInfo();
                                    ftpFileInfo.CreationTime = DateTime.Now;
                                    ftpFileInfo.FtpFilename = region.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
                                    ftpFileInfo.RegionId = region.RegionId;
                                    ftpFileInfo.RetryCount = region.RetryCountDffUpload;

                                    //Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
                                    //if (server == null) throw new Exception("Server configuration is missing.");
                                    //ftpFileInfo.ServerId = server.ServerId;

                                    ftpFileInfo.Status = UploadStates.scheduled.ToString();
                                    ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
                                    ftpFileInfo.Save();
                                    AlertManager.GenerateCCMSEvent(
                     EventType.ManualDFFGeneration.ToString(),
                     EventType.ManualDFFGeneration.ToString(),
                     Event_Type.Alert.ToString(),
                     ftpFileInfo.RegionId.ToString(),
                     EntityType.Organization.ToString(),
                     Actors.BANK.ToString(),
                     Actors.CCMS.ToString(), null);

                                }

                                schemeCount++;
                            }

                            readerDailyFeedScheme.Close();
                        }
                        else
                        {
                            List<int> list = new List<int>();
                            list.Add(reader.CurrentDailyFeedSchedule.AtmId.Value);
                            cms.Initialize();
                            cms.BuildSummary(task, list, true, reader.CurrentDailyFeedSchedule.DeleteCurrentData.Value, reader.CurrentDailyFeedSchedule.EnableDffGeneration.Value);
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated from schedule for atm" +
                                reader.CurrentDailyFeedSchedule.AtmId.Value + " for the date" + reader.CurrentDailyFeedSchedule.DateFrom);
                        }


                        dateFrom = dateFrom.AddDays(1);
                    }
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "scheme count: " + schemeCount);

                    if (reader.CurrentDailyFeedSchedule.AtmId == null || (reader.CurrentDailyFeedSchedule.AtmId != null && !cms.isEmptyDataGenerated))
                    {
                        reader.CurrentDailyFeedSchedule.IsExecuted = true;
                        reader.CurrentDailyFeedSchedule.Save();
                        if (reader.CurrentDailyFeedSchedule.AtmId != null)
                            AlertManager.GenerateTerminalAlert(reader.CurrentDailyFeedSchedule.AtmId.Value, (int)EnumAlertType.SummaryDataRegenerated, "", Event_Type.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                try
                {
                    //if (reader.CurrentDailyFeedSchedule.RetryCount == 0)
                    //{
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, ex);
                    reader.CurrentDailyFeedSchedule.FailureReason = ex.Message;
                    reader.CurrentDailyFeedSchedule.Save();
                    //s}
                }
                catch (Exception innerEx)
                {
                    try
                    {
                        EventLog.WriteEntry("DailyFeedGenerator", innerEx.Message + " " + innerEx.StackTrace);
                    }
                    catch (Exception Ex)
                    {
                    }
                }

            }
            finally
            {

                try
                {
                    if (appSetting != null)
                    {
                        timerExecuteDFSchedules.Change(new TimeSpan(0, (int)appSetting.RefreshInterval * 10, 0), new TimeSpan(0, 0, 0, 0, -1));

                        if (count == 1) // This means this thread has locked this table before so unlocking it if count>1.
                        {
                            appSetting.HoldOtherDfTasks = false;
                            appSetting.Save();
                        }


                        task.EndTask();
                    }
                    else
                        timerExecuteDFSchedules.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));


                    if (reader != null)
                        reader.Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                        EventLog.WriteEntry("DailyFeedGenerator", ex.Message + " " + ex.StackTrace);
                    }
                    catch (Exception innerEx)
                    {
                    }
                }
            }
        }




        private void DoWork(object state)
        {
            timer.Change(-1, -1);
            //            List<Thread> threads = new List<Thread>();

            try
            {
                string connStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\CCMS", false).GetValue("ConnectionString", "");
                connStr = Cryptic.DecryptString(connStr);
                ConnectionFactory.Initialize(connStr, false);
                appSetting = AppSetting.LoadAppSetting("1=1");
                if (appSetting == null)
                    throw new Exception("appSetting table is empty.");
                XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\DailyFeedGenerator_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                LogableTask.DefaultTraceLevel = (TraceLevel)Enum.Parse(typeof(TraceLevel), appSetting.ServiceLogLevel);
                LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : Daily Feed Generator Build 1.0.0.8, Modified date 5/5/2014");

                //if (appSetting.ParsingEnabled)
                //{
                //    LogableTask.LogMonoActivityTask("parsing", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to start parsing");
                //    LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Thread Created");
                //    Thread thread = new Thread(ParseCashData);
                //    thread.Start();
                //    DateTime dtStart = DateTime.Now;
                //    LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to wait for 10 hour");
                //    bool result = thread.Join(new TimeSpan(10, 0, 0));
                //    if (!result)
                //    {
                //        LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Stuck because of fileId=" + taskID);
                //        thread.Abort();
                //    }
                //    LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Returned after " + (DateTime.Now - dtStart).ToString());
                //}
                //else
                //    LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Parsing is turned off");

                bool oneTimeChk = false;
                Region.RegionReader regionReader = Region.ExecuteReader("region_id > 1 and is_active=1 and is_organization = 1");
                //Get all organizations
                while (regionReader.Read())
                {

                    task = LogableTask.NewTask("Processing organizaton :" + regionReader.CurrentRegion.RegionName);

                    if (regionReader.CurrentRegion.DailyFeedOutputFilePath == null)
                        throw new Exception("Output Folder Path is not defined!");
                    if (!Directory.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath))
                        Directory.CreateDirectory(regionReader.CurrentRegion.DailyFeedOutputFilePath);

                    outputArchiveFolderPath = regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\OutputArchive";
                    if (!Directory.Exists(outputArchiveFolderPath))
                        Directory.CreateDirectory(outputArchiveFolderPath);

                    DateTime SummaryDay = regionReader.CurrentRegion.DailyFeedGenerationTime.Value;
                    int lagInterval = regionReader.CurrentRegion.DailyFeedGenerationDelay.Value;
                    TimeSpan timeSpan = DateTime.Now - SummaryDay;

                    if (timeSpan.Days >= lagInterval)
                    {
                        if (appSetting.HoldOtherDfTasks)
                        {
                            LogableTask.LogMonoActivityTask("GenerateDFF", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Other DF Generation job is in process state.");
                            return;
                        }

                        if (!oneTimeChk)
                        {
                            appSetting.HoldOtherDfTasks = true;
                            appSetting.Save();
                            oneTimeChk = true;
                        }



                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "lag interval(Day): " + lagInterval);

                        if (DateTime.Now >= SummaryDay)
                        {
                            CMS cms = new CMS();

                            cms.SetSummaryDay = SummaryDay;
                            //run in a loop for each atm
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to generate summary for Day : " + SummaryDay);
                            try
                            {
                                int schemeCount = 0;
                                DailyFeedScheme.DailyFeedSchemeReader reader = DailyFeedScheme.ExecuteReader("mcn='" + regionReader.CurrentRegion.MCN + "'");
                                while (reader.Read())
                                {
                                    List<int> list = new List<int>();
                                    string mcn = reader.CurrentDailyFeedScheme.Mcn;
                                    bool isSplitByCountry = reader.CurrentDailyFeedScheme.IsSplitByCountry;
                                    string country = regionReader.CurrentRegion.Country;


                                    if (isSplitByCountry)
                                    {
                                        SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
                                        cmd.CommandText = @"SELECT atm_id,region.mcn,country,region.region_id FROM 
                                                        MCN_ATMS, region
                                                        where region.region_id = mcn_atms.region_id 
                                                        and region.mcn = '" + mcn + "' and region.country = '" + country + "'";

                                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        adapter.Fill(dt);

                                        cmd.CommandText = "select daily_feed_file_prefix,region_id from daily_feed_config where daily_feed_scheme_id =" + reader.CurrentDailyFeedScheme.DailyFeedSchemeId;
                                        adapter.SelectCommand = cmd;
                                        DataTable dtConfig = new DataTable();
                                        adapter.Fill(dtConfig);

                                        if (dtConfig.Rows.Count == 0)
                                            throw new Exception("daily feed config is undefined");

                                        DataRowCollection coll = dt.DefaultView.ToTable(true, new string[] { "country" }).Rows;
                                        for (int i = 0; i < coll.Count; i++)
                                        {
                                            DataRow[] drArray = dt.Select("country='" + coll[i][0] + "'");
                                            DataRow[] drConfigArray = dtConfig.Select("region_id=" + drArray[0][3]);
                                            foreach (DataRow dr in drArray)
                                            {
                                                list.Add(int.Parse(dr[0].ToString()));
                                            }


                                            cms.Initialize();
                                            cms.BuildSummary(task, list, null, true, false);
                                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");


                                            string outputFilePath = regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\" + drConfigArray[0][0].ToString() + SummaryDay.ToString("yyyyMMdd") + ".atm.wrk";

                                            if (!Directory.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath))
                                                Directory.CreateDirectory(regionReader.CurrentRegion.DailyFeedOutputFilePath);

                                            if (File.Exists(outputFilePath))
                                                File.Delete(outputFilePath);

                                            if (!Directory.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload"))
                                                Directory.CreateDirectory(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload");

                                            if (regionReader.CurrentRegion.IsDffVersion2Configured)
                                                File.WriteAllText(outputFilePath, cms.FormatToDFFVersion2());
                                            else
                                                File.WriteAllText(outputFilePath, cms.GetOutput());
                                            //File.WriteAllText(outputFilePath+"_1", cms.FormatToDFFVersion2());

                                            if (File.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath)))
                                                File.Delete(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));

                                            File.Move(outputFilePath, regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));


                                            FtpFileInfo ftpFileInfo = new FtpFileInfo();
                                            ftpFileInfo.CreationTime = DateTime.Now;
                                            ftpFileInfo.FtpFilename = regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
                                            ftpFileInfo.RegionId = int.Parse(drConfigArray[0][1].ToString());
                                            ftpFileInfo.RetryCount = regionReader.CurrentRegion.RetryCountDffUpload;
                                            //Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
                                            //if (server == null) throw new Exception("Server configuration is missing.");
                                            //ftpFileInfo.ServerId = server.ServerId;
                                            ftpFileInfo.Status = UploadStates.scheduled.ToString();
                                            ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
                                            ftpFileInfo.Save();

                                            AlertManager.GenerateCCMSEvent
                                                (EventType.DFFGeneration.ToString(), EventType.DFFGeneration.ToString(), Event_Type.Alert.ToString(),
                                                ftpFileInfo.RegionId.ToString(), EntityType.Organization.ToString(),
                                                Actors.CCMS.ToString(), Actors.CCMS.ToString(), null);



                                        }

                                    }
                                    else
                                    {

                                        int maxRegionId = (int)ConnectionFactory.ExecuteScalar("select max(region_id) from region where mcn='" + mcn + "'");
                                        if (maxRegionId != regionReader.CurrentRegion.RegionId)
                                        {
                                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary generation delayed for organization because of combined mode." + regionReader.CurrentRegion.RegionName);

                                            break;
                                        }
                                        McnAtms.McnAtmsReader mcnAtmsReader = McnAtms.ExecuteReader("mcn='" + mcn + "' and atm_id in (select atm_id from atm where is_active = 1 and is_dff_generation_halt = 0 and exclude_dff = 0) order by atm_id");
                                        while (mcnAtmsReader.Read())
                                        {
                                            list.Add(mcnAtmsReader.CurrentMcnAtms.AtmId);
                                        }
                                        mcnAtmsReader.Close();

                                        cms.Initialize();
                                        cms.BuildSummary(task, list, null, true, false);
                                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");

                                        DailyFeedConfig dailyFeedConfig = DailyFeedConfig.LoadDailyFeedConfig("daily_feed_scheme_id=" + reader.CurrentDailyFeedScheme.DailyFeedSchemeId);
                                        if (dailyFeedConfig == null)
                                            throw new Exception("daily feed config is undefined");
                                        //int region_id = Region.LoadRegion("mcn='" + mcn + "' and parent_region_id=1").RegionId;
                                        string outputFilePath = regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\" + dailyFeedConfig.DailyFeedFilePrefix + SummaryDay.ToString("yyyyMMdd") + ".atm.wrk";
                                        if (!Directory.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath))
                                            Directory.CreateDirectory(regionReader.CurrentRegion.DailyFeedOutputFilePath);

                                        if (File.Exists(outputFilePath))
                                            File.Delete(outputFilePath);

                                        if (!Directory.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload"))
                                            Directory.CreateDirectory(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload");

                                        if (regionReader.CurrentRegion.IsDffVersion2Configured)
                                            File.WriteAllText(outputFilePath, cms.FormatToDFFVersion2());
                                        else
                                            File.WriteAllText(outputFilePath, cms.GetOutput());

                                        //File.WriteAllText(outputFilePath, cms.GetOutput());
                                        //File.WriteAllText(outputFilePath + "_1", cms.FormatToDFFVersion2());
                                        if (File.Exists(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath)))
                                            File.Delete(regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));

                                        File.Move(outputFilePath, regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath));
                                        FtpFileInfo ftpFileInfo = new FtpFileInfo();
                                        ftpFileInfo.CreationTime = DateTime.Now;
                                        ftpFileInfo.FtpFilename = regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
                                        ftpFileInfo.RegionId = regionReader.CurrentRegion.RegionId;
                                        ftpFileInfo.RetryCount = regionReader.CurrentRegion.RetryCountDffUpload;
                                        //Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
                                        //if (server == null) throw new Exception("Server configuration is missing.");
                                        //ftpFileInfo.ServerId = server.ServerId;
                                        ftpFileInfo.Status = UploadStates.scheduled.ToString();
                                        ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
                                        ftpFileInfo.Save();
                                        AlertManager.GenerateCCMSEvent
                                                (EventType.DFFGeneration.ToString(), EventType.DFFGeneration.ToString(), Event_Type.Alert.ToString(),
                                                ftpFileInfo.RegionId.ToString(), EntityType.Organization.ToString(),
                                                Actors.CCMS.ToString(), Actors.CCMS.ToString(), null);


                                    }

                                    schemeCount++;
                                    regionReader.CurrentRegion.DailyFeedGenerationTime = regionReader.CurrentRegion.DailyFeedGenerationTime.Value.AddDays(1);
                                    regionReader.CurrentRegion.Save();
                                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "scheme count: " + schemeCount);
                                }
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message + "<br/>" + ex.StackTrace + "<br/> " + ex.InnerException);
                            }

                        }
                        else
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Its not " + SummaryDay);

                    }
                    else
                        LogableTask.LogMonoActivityTask("GenerateSummary", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Summary generation delayed for organization " + regionReader.CurrentRegion.RegionName + " time: " + regionReader.CurrentRegion.DailyFeedGenerationTime.ToString());
                    task.EndTask();
                }
                //Going to upload files
                //task = LogableTask.NewTask("FTPUploadEntries");
                //DirectoryInfo dirInfo = new DirectoryInfo(appSetting.DailyFeedOutputFilePath + "\\PendingUpload");

                //if (!Directory.Exists(appSetting.DailyFeedOutputFilePath + "\\PendingUpload"))
                //    Directory.CreateDirectory(appSetting.DailyFeedOutputFilePath + "\\PendingUpload");

                //FileInfo[] fileInfo = dirInfo.GetFiles();
                //task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Count:" + fileInfo.Length);
                //foreach (FileInfo _file in fileInfo)
                //{
                ////    try
                //    {
                //        //if (File.Exists(appSetting.DailyFeedOutputFilePath + "\\PendingUpload\\" + _file.Name))
                //        //    File.Delete(appSetting.DailyFeedOutputFilePath + "\\PendingUpload\\" + _file.Name);

                //        //File.Move(_file.FullName, appSetting.DailyFeedOutputFilePath + "\\PendingUpload\\" + _file.Name);

                //        FtpFileInfo ftpFileInfo = new FtpFileInfo();
                //        ftpFileInfo.CreationTime = DateTime.Now;
                //        ftpFileInfo.FtpFilename = _file.FullName;
                //        ftpFileInfo.RegionId = int.Parse(_file.FullName.Split('_')[1]);
                //        ftpFileInfo.RetryCount = appSetting.MaxTries;
                //        Server server = Server.LoadServer("server_name='" + EnumServer.OpticashDF.ToString() + "'");
                //        if (server == null) throw new Exception("Server configuration is missing.");
                //        ftpFileInfo.ServerId = server.ServerId;
                //        ftpFileInfo.Status = UploadStates.scheduled.ToString();
                //        ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
                //        ftpFileInfo.Save();



                //        //if (_file.Name == "processed.txt") continue;
                //        //if (filesProcesed != null) //has some entries
                //        //{
                //        //    if (Array.IndexOf(filesProcesed, _file.Name) >= 0)
                //        //    {
                //        //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "file already uploaded=" + _file.Name);
                //        //        continue;
                //        //    }
                //        //}
                //        //bool isRenamed = false;
                //        //if (_file.Extension == ".atm")
                //        //{
                //        //    File.Move(_file.FullName, _file.FullName + ".wrk");
                //        //    isRenamed = true;
                //        //}

                //        //if (deleteOutputFile)
                //        //{
                //        //    File.Delete(_file.FullName);
                //        //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File deleted successfully");
                //        //}
                //        //else
                //        //{
                //        //    File.Move(_file.FullName, outputArchiveFolderPath + "\\" + _file.Name);
                //        //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "file moved to archive folder successfully");
                //        //}

                //    }
                //    catch (Exception ex)
                //    {
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                //    }
                //}
                //task.EndTask();
                ////if (fileWriter != null)
                //    fileWriter.Close();



                //Sending Email

                //task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to send emails");



                //FileInfo[] _fileInfo;
                //dirInfo = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "\\pickup");
                //_fileInfo = dirInfo.GetFiles();
                //if (_fileInfo.Length > 0)
                //{

                //    SmtpClient client = new SmtpClient(
                //        System.Configuration.ConfigurationManager.AppSettings["SMTPServer"],
                //        int.Parse(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"]));


                //    using (MailMessage mailMsg = new MailMessage())
                //    {
                //        mailMsg.Subject = "BSF_CM_OUTPUT_FILES";
                //        mailMsg.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["SMTPUserName"]);
                //        client.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["SMTPUserName"],
                //                            System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"]);


                //        //Set CC for email
                //        MailAddressCollection mailCol = new MailAddressCollection();
                //        string[] emails = System.Configuration.ConfigurationManager.AppSettings["Recipient"].Split(',');
                //        foreach (string email in emails)
                //            mailMsg.To.Add(email);


                //        //Set Attachment for email


                //        //dirInfo = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "\\pickup");
                //        //_fileInfo = dirInfo.GetFiles();

                //        foreach (FileInfo files in _fileInfo)
                //            mailMsg.Attachments.Add(new Attachment(files.FullName));

                //        client.Send(mailMsg);
                //    }

                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Emails sent successfully");
                //    foreach (FileInfo files in _fileInfo)
                //        File.Move(files.FullName, System.AppDomain.CurrentDomain.BaseDirectory + "\\Archive\\pickup\\" + files.Name);
                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Files Moved To Archive Successfully");
                //}
                //else
                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "No files found in pickup folder");


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
                        timer.Change(new TimeSpan(0, (int)appSetting.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                        if (appSetting.HoldOtherDfTasks)
                        {
                            appSetting.HoldOtherDfTasks = false;
                            appSetting.Save();
                        }


                    }
                    else
                        timer.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                    //    task.EndTask();

                    if (appSetting!=null)
                        LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep for " + appSetting.RefreshInterval + " min");
                   // else
                     //   LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep for 5 min");
                    
                    //timer.Change(new TimeSpan(0, (int)appSetting.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception ex)
                {
                    try
                    {
                        EventLog.WriteEntry("DailyFeedGenerator", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    }
                    catch (Exception innerException)
                    {
                    }

                }

            }



        }

        List<List<BankInfo>> GetATMsList(string mcn)
        {
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id,mcn,parent_region_id, daily_feed_prefix,daily_feed_folder_name,daily_feed_file_prefix,is_split_by_country,country from region where is_active =1 and region_id >1";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            dtRegions = new DataTable();
            adapter.Fill(dtRegions);
            List<string> list = new List<string>();
            List<List<BankInfo>> result = new List<List<BankInfo>>();
            DataRowCollection coll = dtRegions.DefaultView.ToTable(true, new string[] { "mcn" }).Rows;
            for (int i = 0; i < coll.Count; i++)
            {

                if (coll[i][0].ToString().Length > 0)
                {
                    if (mcn.Length > 0)
                    {
                        if (mcn == coll[i][0].ToString())
                            list.Add(coll[i][0].ToString());
                    }
                    else
                        list.Add(coll[i][0].ToString());

                }

            }
            int outcome = 1;
            for (int i = 0; i < list.Count; i++)
            {
                outcome = 1;
                DataRow[] drArray = dtRegions.Select("mcn='" + list[i] + "'");
                foreach (DataRow dr in drArray)
                {
                    string isSplitByCountry = dr[6].ToString();
                    if (isSplitByCountry.Length > 0)
                        outcome *= (isSplitByCountry.ToLower() == "true" ? 1 : 0);

                }
                if (outcome == 0)
                {
                    result.Add(FindAllATMsRegionsByMCN(list[i]));
                }
                else
                {
                    result.Add(FindAllATMsRegionsByMCNAndCountry(list[i]));
                }
            }
            return result;

        }


        List<BankInfo> FindAllATMsRegionsByMCN(string requiredMCN)
        {
            //  SqlConnection conn = new SqlConnection("initial catalog=ccms; data source=.;user id =sa;pwd=;");
            // conn.Open();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id,mcn,parent_region_id, daily_feed_prefix,daily_feed_folder_name,daily_feed_file_prefix from region where is_active =1";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //conn.Close();
            List<string> list = new List<string>();
            List<BankInfo> result = new List<BankInfo>();
            DataRowCollection coll = dt.DefaultView.ToTable(true, new string[] { "mcn" }).Rows;
            for (int i = 0; i < coll.Count; i++)
            {
                if (coll[i][0].ToString().Length > 0)
                {
                    if (requiredMCN.Length > 0)
                    {
                        if (requiredMCN == coll[i][0].ToString())
                            list.Add(coll[i][0].ToString());
                    }
                    else
                        list.Add(coll[i][0].ToString());
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder builder = new StringBuilder();
                StringBuilder builderOutputFolderPath = new StringBuilder();
                StringBuilder builderFtpUploadFolderPath = new StringBuilder();
                StringBuilder builderDailyFeedPrefix = new StringBuilder();

                DataRow[] drArray = dt.Select("mcn = '" + list[i] + "'");
                foreach (DataRow dr in drArray)
                {
                    builder.Append(dr[0].ToString() + ",");
                    builderOutputFolderPath.Append(dr[4].ToString() + ",");
                    builderFtpUploadFolderPath.Append(dr[3].ToString() + ",");
                    builderDailyFeedPrefix.Append(dr[5].ToString() + ",");




                    if (dr[2] != DBNull.Value)
                    {
                        int parent_region_id = int.Parse(dr[2].ToString());
                        while (true)
                        {
                            DataRow[] innerArray = dt.Select("region_id=" + parent_region_id);
                            builder.Append(innerArray[0][0].ToString() + ",");
                            builderOutputFolderPath.Append(innerArray[0][4].ToString() + ",");
                            builderFtpUploadFolderPath.Append(innerArray[0][3].ToString() + ",");
                            builderDailyFeedPrefix.Append(innerArray[0][5].ToString() + ",");




                            if (innerArray[0][2] != DBNull.Value)
                                parent_region_id = int.Parse(innerArray[0][2].ToString());
                            else
                                break;
                        }
                    }
                }
                BankInfo bankInfo = new BankInfo();
                bankInfo.organizations = builder.ToString();
                if (builder.Length > 0)
                {
                    builder.Append("-1");
                    DataRow[] temp = dt.Select("region_id in (" + builder.ToString() + ") or parent_region_id in (" + builder.ToString() + ")");
                    builder = new StringBuilder();
                    for (int j = 0; j < temp.Length; j++)
                    {
                        builder.Append(temp[j][0] + ",");
                    }
                }
                bankInfo.regionsAndOrganizations = builder.ToString();
                try
                {
                    cmd.CommandText = "select atm_id from atm where is_active=1 and region_id in (" + builder.ToString() + "-1)";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bankInfo.atmIds.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                finally
                {
                    cmd.Connection.Close();
                }

                bankInfo.outputFolderPath = builderOutputFolderPath.ToString();
                bankInfo.FTPUploadPath = builderFtpUploadFolderPath.ToString();
                bankInfo.dailyFeedFilePrefix = builderDailyFeedPrefix.ToString();
                result.Add(bankInfo);
            }

            return result;

        }

        List<BankInfo> FindAllATMsRegionsByMCNAndCountry(string requiredMCN)
        {
            //    SqlConnection conn = new SqlConnection("initial catalog=ccms; data source=.;user id =sa;pwd=;");
            // conn.Open();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id,mcn,parent_region_id,country,daily_feed_prefix,daily_feed_folder_name,daily_feed_file_prefix,is_organization from region";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //  conn.Close();
            //play with dt;
            List<string> list = new List<string>();
            List<string> countries = new List<string>();
            List<BankInfo> result = new List<BankInfo>();
            DataRowCollection coll = dt.DefaultView.ToTable(true, new string[] { "mcn", "country" }).Rows;
            for (int i = 0; i < coll.Count; i++)
            {
                if (coll[i][0].ToString().Length > 0)
                {
                    if (requiredMCN.Length > 0)
                    {
                        if (requiredMCN == coll[i][0].ToString())
                        {
                            list.Add(coll[i][0].ToString());
                            countries.Add(coll[i][1].ToString());
                        }
                    }
                    else
                    {
                        list.Add(coll[i][0].ToString());
                        countries.Add(coll[i][1].ToString());
                    }
                }
            }

            // mcn = sa116,sa117,22
            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder builder = new StringBuilder();
                StringBuilder builderOutputFolderPath = new StringBuilder();
                StringBuilder builderFtpUploadFolderPath = new StringBuilder();
                StringBuilder builderDailyFeedPrefix = new StringBuilder();

                DataRow[] drArray = dt.Select("mcn = '" + list[i] + "' and country ='" + countries[i] + "'");
                foreach (DataRow dr in drArray)
                {
                    builder.Append(dr[0].ToString() + ",");
                    builderOutputFolderPath.Append(dr[5].ToString() + ",");
                    builderFtpUploadFolderPath.Append(dr[4].ToString() + ",");
                    builderDailyFeedPrefix.Append(dr[6].ToString() + ",");
                    //region_id,mcn,parent_region_id,country,daily_feed_prefix,daily_feed_folder_name,daily_feed_file_prefix from region

                    if (dr[2] != DBNull.Value)
                    {
                        int parent_region_id = int.Parse(dr[2].ToString());
                        while (true)
                        {
                            DataRow[] innerArray = dt.Select("region_id=" + parent_region_id);
                            builder.Append(innerArray[0][0].ToString() + ",");
                            builderOutputFolderPath.Append(innerArray[0][5].ToString() + ",");
                            builderFtpUploadFolderPath.Append(innerArray[0][4].ToString() + ",");
                            builderDailyFeedPrefix.Append(innerArray[0][6].ToString() + ",");

                            if (innerArray[0][2] != DBNull.Value)
                                parent_region_id = int.Parse(innerArray[0][2].ToString());
                            else
                                break;
                        }
                    }
                }

                BankInfo bankInfo = new BankInfo();
                bankInfo.organizations = builder.ToString();

                if (builder.Length > 0)
                {
                    builder.Append("-1");
                    DataRow[] temp = dt.Select("is_organization = False and (region_id in (" + builder.ToString() + ") or parent_region_id in (" + builder.ToString() + "))");
                    builder = new StringBuilder();
                    for (int j = 0; j < temp.Length; j++)
                    {
                        builder.Append(temp[j][0] + ",");
                    }
                }
                bankInfo.regionsAndOrganizations = builder.ToString();
                try
                {
                    cmd.CommandText = "select atm_id from atm where is_active=1 and region_id in (" + builder.ToString() + "-1)";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bankInfo.atmIds.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                finally
                {
                    cmd.Connection.Close();
                }

                bankInfo.outputFolderPath = builderOutputFolderPath.ToString();
                bankInfo.FTPUploadPath = builderFtpUploadFolderPath.ToString();
                bankInfo.dailyFeedFilePrefix = builderDailyFeedPrefix.ToString();
                result.Add(bankInfo);
            }

            return result;

        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            try
            {
                LogableTask.LogMonoActivityTask("OnStop()", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Service Stopped");
            }
            catch (Exception ex)
            {

            }

        }
        private void ExtractHardwareInfo(string content, int atmId, SqlTransaction trxn)
        {

            string[] parts = content.Replace("\0", "").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                AtmHardwareInventory hardware = new AtmHardwareInventory();
                hardware.AtmId = atmId;
                hardware.GeneratedAt = DateTime.Now;
                hardware.InstalledHardware = part.Replace("'", "''");
                hardware.Save(trxn.Connection, trxn);
            }
        }
        private void ExtractSoftwareInfo(string content, int atmId, SqlTransaction trxn)
        {
            string allApplications = content.Substring(content.IndexOf("Applications:"));
            string[] parts = allApplications.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < parts.Length; i++)
            {
                AtmSoftwareInventory inventory = new AtmSoftwareInventory();
                inventory.AtmId = atmId;
                inventory.GeneratedAt = DateTime.Now;
                inventory.InstalledProgram = parts[i].Replace("'", "''");
                inventory.Save(trxn.Connection, trxn);
            }

        }
        private void ExtractGeneralInfo(string content, int atmId, SqlTransaction trxn)
        {
            string[] subParts = null;
            string generalInfo = content.Substring(0, content.IndexOf("Applications:"));
            string[] parts = generalInfo.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < parts.Length; i++)
            {
                AtmGeneralInventory inventory = new AtmGeneralInventory();
                inventory.AtmId = atmId;
                inventory.GeneratedAt = DateTime.Now;
                subParts = parts[i].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                inventory.Name = subParts[0].Replace("'", "''"); ;
                inventory.FieldValue = subParts[1].Replace("'", "''").TrimStart();
                inventory.Save(trxn.Connection, trxn);
            }
        }



        private void UploadDfs(object obj)
        {
            LogableTask task = LogableTask.NewTask("uploadDFs");
            timerUploadDFs.Change(-1, -1);
            FtpFileInfo.FtpFileInfoReader reader = null;
            try
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to read uploading jobs");
                reader = FtpFileInfo.ExecuteReader("status = '" + FTPUploadStatus.scheduled.ToString() + "' and retry_count > 0 and task_type_id = " + (int)EnumTaskType.DailyFeedUpload);
                while (reader.Read())
                {
                    reader.CurrentFtpFileInfo.RetryCount--;
                    reader.CurrentFtpFileInfo.LastInvokedAt = DateTime.Now;
                    reader.CurrentFtpFileInfo.Save();


                    try
                    {
                        string FileName = reader.CurrentFtpFileInfo.FtpFilename;
                        if (!File.Exists(FileName))
                            throw new Exception("file " + FileName + " does not exists");
                        int organization_id = reader.CurrentFtpFileInfo.RegionId;
                        Region region = Region.LoadRegion("region_id=" + organization_id);
                        if (region.IsSecuredAccess.Value)
                        {
                            string remoteFilePrefix = null;
                            string remoteFileName = null;
                            Scp scp = new Scp();
                            int port = 22;
                            string[] parts = region.DailyFeedFtpUri.Split(':');
                            string[] subParts = parts[0].Split('/');
                            string server = subParts[0];
                            if (subParts.Length > 1)
                                remoteFilePrefix = parts[0].Substring(parts[0].IndexOf('/') + 1);

                            if (parts.Length > 1)
                                port = int.Parse(parts[1]);

                            if (remoteFilePrefix != null)
                                remoteFileName = remoteFilePrefix + "/" + Path.GetFileName(FileName);
                            else
                                remoteFileName = Path.GetFileName(FileName);


                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + FileName);
                            scp.DoWork(FileName, server, remoteFileName,
                               region.DailyFeedFtpUsername, Cryptic.DecryptString(region.DailyFeedFtpPassword), port, remoteFileName.Substring(0, remoteFileName.IndexOf(".wrk")));
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded,Permissions Changed and Renamed Operation Completed Successfully");

                        }
                        else
                        {
                            FTPManager ftpManager = new FTPManager();
                            ftpManager.FtpPassword = Cryptic.DecryptString(region.DailyFeedFtpPassword);
                            ftpManager.FtpServerIP = region.DailyFeedFtpUri;
                            ftpManager.FtpUserId = region.DailyFeedFtpUsername;


                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + FileName);
                            ftpManager.UploadFile(FileName); // already there :)
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded Successfully");


                            string currentFileName = Path.GetFileName(FileName);
                            ftpManager.RenameFile(currentFileName, currentFileName.Substring(0, currentFileName.IndexOf(".wrk")));
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Renamed Successfully on FTP server");
                        }



                        outputArchiveFolderPath = region.DailyFeedOutputFilePath + "\\OutputArchive";
                        if (!Directory.Exists(outputArchiveFolderPath))
                            Directory.CreateDirectory(outputArchiveFolderPath);

                        if (File.Exists(outputArchiveFolderPath + "\\" + Path.GetFileName(FileName)))
                            File.Delete(outputArchiveFolderPath + "\\" + Path.GetFileName(FileName));

                        File.Move(FileName, outputArchiveFolderPath + "\\" + Path.GetFileName(FileName));



                        reader.CurrentFtpFileInfo.Status = FTPUploadStatus.completed.ToString();
                        reader.CurrentFtpFileInfo.EndTime = DateTime.Now;
                        reader.CurrentFtpFileInfo.FailureReason = "";
                        reader.CurrentFtpFileInfo.Save();
                        AlertManager.GenerateCCMSEvent
                                                (EventType.DFFGeneration.ToString(), EventType.DFFGeneration.ToString(), Event_Type.Alert.ToString(),
                                               organization_id.ToString(), EntityType.Organization.ToString(),
                                                Actors.CCMS.ToString(), Actors.CCMS.ToString(), null);

                    }
                    catch (Exception ex)
                    {
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                        if (ex.Message.Replace("'", "''").Length > 255)
                            reader.CurrentFtpFileInfo.FailureReason = ex.Message.Replace("'", "''").Substring(0, 255);
                        else
                            reader.CurrentFtpFileInfo.FailureReason = ex.Message.Replace("'", "''");

                        if (reader.CurrentFtpFileInfo.RetryCount == 0)
                        {
                            reader.CurrentFtpFileInfo.Status = FTPUploadStatus.failed.ToString();
                            //time to generate alert;
                            AlertManager.GenerateOrganizationAlert(reader.CurrentFtpFileInfo.FtpFileInfoId, (int)EnumAlertType.DailyFeedUpload, null, Event_Type.Error, reader.CurrentFtpFileInfo.RegionId);
                            AlertManager.GenerateCCMSEvent
                                                (EventType.DFFUploadFailed.ToString(), EventType.DFFUploadFailed.ToString(),
                                                Event_Type.Error.ToString(),
                                               reader.CurrentFtpFileInfo.RegionId.ToString(), EntityType.Organization.ToString(),
                                                Actors.CCMS.ToString(), Actors.OPTICash.ToString(), null);


                            //Alert alert = new Alert();
                            //alert.GeneratedA = DateTime.Now;
                            //alert.AlertTypeId = (int)EnumAlertType.DailyFeedUpload;
                            ////alert.Source = "RaiseAlertIfNeeded";
                            //alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

                            //alert.FtpFileInfoId = reader.CurrentFtpFileInfo.FtpFileInfoId;
                            //alert.Save();

                            //Notification notify = new Notification();
                            //notify.AlertId = alert.AlertId;
                            ////notify.NotificationMsg = "Daily Feed Upload Failed";
                            //notify.RetryRemaining = appSetting.MaxTries;
                            //notify.NotificationSent = false;
                            //notify.Save();

                            //                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert and notification added");

                        }
                        reader.CurrentFtpFileInfo.Save();
                    }
                }

            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }

            finally
            {
                try
                {
                    if (reader != null)
                        reader.Close();
                    if (appSetting!=null)
                        timerUploadDFs.Change(new TimeSpan(0, (int)appSetting.RefreshInterval * 10, 0), new TimeSpan(0, 0, 0, 0, -1));
                    else
                        timerUploadDFs.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                    task.EndTask();
                }
                catch (Exception ex)
                {
                    try
                    {
                        EventLog.WriteEntry("DailyFeedGenerator", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    }
                    catch (Exception innerException)
                    {
                    }

                }
            }
        }
        private Avanza.CCMS.DAL.Replenishment ProcessReplenishment(AtmAlert atmAlert, Atm atm, UserTask userTask, int counterType1, int counterType2, int counterType3,
           int counterType4, string alertDatetime, SqlTransaction trxn, SqlCommand cmd, int rejectCounterType1, int rejectCounterType2, int rejectCounterType3, int rejectCounterType4)
        {
            LogableTask task = LogableTask.NewTask("ProcessReplenishments");
            try
            {
                NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                Avanza.CCMS.DAL.Replenishment replenishment;
                AtmAlert atmAlert1;
                replenishment = new Avanza.CCMS.DAL.Replenishment
                {
                    AtmId = atm.ATMId,
                    RepDatetime = DateTime.ParseExact(alertDatetime, "MM/dd/yyyy HH:mm:ss", null),
                    CashAdded1 = counterType1,
                    CashAdded2 = counterType2,
                    CashAdded3 = counterType3,
                    CashAdded4 = counterType4,
                    CashAdded5 = 0,
                    CashAdded6 = 0,
                    CashAdded7 = 0,
                    RepStatus = "OrderMissingForceFully",
                    IsSwap = true,
                    TaskId = atmAlert.TaskId.Value,
                    CashOrderId = -1,
                    GeneratedAt = DateTime.Now,
                    IsUpdated = false
                };


                replenishment.Save(trxn.Connection, trxn);

                ///Changes done on 08/Jan 2014 to add notes in purged bin
                TestCashPurgedNotes testCashPurgedNotes = new TestCashPurgedNotes();
                testCashPurgedNotes.ReplenishmentId = replenishment.ReplenishmentId;
                testCashPurgedNotes.TaskId = taskID;
                testCashPurgedNotes.TestCashDatetime = replenishment.RepDatetime;
                testCashPurgedNotes.CashPurged1 = rejectCounterType1;
                testCashPurgedNotes.CashPurged2 = rejectCounterType2;
                testCashPurgedNotes.CashPurged3 = rejectCounterType3;
                testCashPurgedNotes.CashPurged4 = rejectCounterType4;
                testCashPurgedNotes.CashPurged5 = 0;
                testCashPurgedNotes.CashPurged6 = 0;
                testCashPurgedNotes.CashPurged7 = 0;
                testCashPurgedNotes.AtmId = replenishment.AtmId;
                testCashPurgedNotes.Save(trxn.Connection, trxn);

                AlertManager.GenerateTerminalAlert(atm.ATMId, (int)EnumAlertType.ReplenishmentAtATM, "Repenishment At ATM", trxn, Event_Type.Information, atmAlert.TaskId.Value, replenishment.ReplenishmentId, "Replenishment");

                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch purge bin alert for atm_id = " + atm.ATMId);
                atmAlert1 = AtmAlert.LoadAtmAlert(string.Concat(new object[] { "alert_type_id=", 0x16, " and atm_id=", atm.ATMId, " and resolve_at is null" }));
                if (atmAlert1 != null)
                {
                    atmAlert1.ResolveAt = new DateTime?(DateTime.Now);
                    atmAlert1.Save(trxn.Connection, trxn);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert resolved for atm_id = " + atm.ATMId);
                    CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert1.AtmAlertId);
                    if (ccmsIntAlert != null)
                    {

                        //cmd = conn.CreateCommand();
                        //cmd.Transaction = trx;
                        cmd.CommandText = "update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id;
                        cmd.ExecuteNonQuery();
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                    }
                }
                //            }
                decimal replenishedAmount = (decimal)(replenishment.CashAdded1 * noteSetType.DenominationType1 +
                    replenishment.CashAdded2 * noteSetType.DenominationType2 +
                    replenishment.CashAdded3 * noteSetType.DenominationType3 +
                    replenishment.CashAdded4 * noteSetType.DenominationType4 +
                    replenishment.CashAdded5 * noteSetType.DenominationType5 +
                    replenishment.CashAdded6 * noteSetType.DenominationType6 +
                    replenishment.CashAdded7 * noteSetType.DenominationType7);


                if (replenishedAmount > atm.MinOperatingBalance)
                {
                    atmAlert1 = AtmAlert.LoadAtmAlert(string.Concat(new object[] { "alert_type_id=", 0x15, " and atm_id=", atm.ATMId, " and resolve_at is null" }));
                    if (atmAlert1 != null)
                    {
                        atmAlert1.ResolveAt = DateTime.Now;
                        atmAlert1.Save(trxn.Connection, trxn);
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert resolved for atm_id = " + atm.ATMId);
                        CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert1.AtmAlertId);
                        if (ccmsIntAlert != null)
                        {
                            //cmd = conn.CreateCommand();
                            //cmd.Transaction = trx;
                            cmd.CommandText = "update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id;
                            cmd.ExecuteNonQuery();
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                        }
                    }
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch low balance alert for atm_id = " + atm.ATMId);
                    atmAlert1 = AtmAlert.LoadAtmAlert(string.Concat(new object[] { "alert_type_id=", 20, " and atm_id=", atm.ATMId, " and resolve_at is null" }));
                    if (atmAlert1 != null)
                    {
                        atmAlert1.ResolveAt = DateTime.Now;
                        atmAlert1.Save(trxn.Connection, trxn);
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert resolved for atm_id = " + atm.ATMId);
                        CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert1.AtmAlertId);
                        if (ccmsIntAlert != null)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Transaction Object is null=" + (trxn.Connection == null ? "true" : "false"));


                            //cmd = conn.CreateCommand();
                            //cmd.Transaction = trx;
                            cmd.CommandText = "update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id;
                            cmd.ExecuteNonQuery();
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                        }

                    }
                }
                //Avanza.CCMS.DAL.UserTask userTask = Avanza.CCMS.DAL.UserTask.LoadUserTaskByPk(int.Parse(base.Request.QueryString["tid"]));
                userTask.Status = ApprovalStatus.Approved.ToString();
                userTask.ResolutionTime = DateTime.Now;
                userTask.ResolvedBy = 1;
                userTask.Save(trxn.Connection, trxn);
                //trx.Commit();
                //isTrxnCommited = true;
                //ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + atm.ATMId, trxn);
                return replenishment;


            }
            catch (Exception ex)
            {
                //if (!isTrxnCommited)
                //    trx.Rollback();

                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                throw;
            }
            finally
            {
                //if (conn != null)
                //    conn.Close();
                task.EndTask();
            }
        }

        private void AutoResolveUserTasks(object state)
        {
            timerAutoResolveUserTasks.Change(-1, -1);
            SqlCommand cmd = null;
            SqlTransaction trxn = null;
            UserTask.UserTaskReader userTaskReader = null;
            //LogableTask task = LogableTask.NewTask("AutoResolveUserTasks");

            try
            {
                cmd = ConnectionFactory.GetNewCommand(true);
                userTaskReader = UserTask.ExecuteReader("status = 'Pending' and task_type_id = 12 order by user_task_id");
                while (userTaskReader.Read())
                {
                    try
                    {
                        AtmAlert atmAlert = AtmAlert.LoadAtmAlertByPk(userTaskReader.CurrentUserTask.AtmAlertId.Value);
                        if (atmAlert != null)
                        {
                            if (!atmAlert.AlertMsg.Contains("Mismatch"))
                                continue;

                            Atm atm = Atm.LoadAtmByPk(atmAlert.AtmId.Value);
                            string[] parts = atmAlert.AlertMsg.Split(new char[] { '|' });

                            //int[] lastRemainingCounters = { int.Parse(parts[11]), int.Parse(parts[12]), int.Parse(parts[13]), int.Parse(parts[14]) };
                            //int[] lastDispensedCounters = { int.Parse(parts[0x12]), int.Parse(parts[0x13]), int.Parse(parts[20]), int.Parse(parts[0x15]) };
                            //int[] lastPurgedCounters = { int.Parse(parts[0x19]), int.Parse(parts[0x1a]), int.Parse(parts[0x1b]), int.Parse(parts[0x1c]) };
                            //int[] lastAddedCounters = { int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]) };

                            int[] currentRemainingCounters = { int.Parse(parts[0x27]), int.Parse(parts[40]), int.Parse(parts[0x29]), int.Parse(parts[0x2a]) };
                            int[] currentDispensedCounters = { int.Parse(parts[0x2e]), int.Parse(parts[0x2f]), int.Parse(parts[0x30]), int.Parse(parts[0x31]) };
                            int[] currentPurgedCounters = { int.Parse(parts[0x35]), int.Parse(parts[0x36]), int.Parse(parts[0x37]), int.Parse(parts[0x38]) };
                            int[] currentAddedCounters = { int.Parse(parts[0x20]), int.Parse(parts[0x21]), int.Parse(parts[0x22]), int.Parse(parts[0x23]) };

                            //************************************************************************************************************************************************
                            //Changes done on 2-jan-2014.
                            //Issue : If counters are cleared and there is a mismatch then below condition will fail and replenishment entry will be generated.
                            //TO DO :
                            //************************************************************************************************************************************************
                            if (currentDispensedCounters[0] == 0 && currentDispensedCounters[1] == 0 && currentDispensedCounters[2] == 0 && currentDispensedCounters[3] == 0
                                && (currentRemainingCounters[0] + currentPurgedCounters[0] == currentAddedCounters[0])
                                && (currentRemainingCounters[1] + currentPurgedCounters[1] == currentAddedCounters[1])
                                && (currentRemainingCounters[2] + currentPurgedCounters[2] == currentAddedCounters[2])
                                && (currentRemainingCounters[3] + currentPurgedCounters[3] == currentAddedCounters[3])

                                && (currentAddedCounters[0] + currentAddedCounters[1] + currentAddedCounters[2] + currentAddedCounters[3] != 0)
                                )
                            {//Its a swap...because dispensed counters =0;
                                trxn = cmd.Connection.BeginTransaction();
                                cmd.Transaction = trxn;

                                //Avanza.CCMS.DAL.Replenishment replenishment = ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, currentRemainingCounters[0],
                                //                   currentRemainingCounters[1], currentRemainingCounters[2], currentRemainingCounters[3], parts[0], trxn, cmd);

                                Avanza.CCMS.DAL.Replenishment replenishment = ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, currentAddedCounters[0],
                                                   currentAddedCounters[1], currentAddedCounters[2], currentAddedCounters[3], parts[0], trxn, cmd, currentPurgedCounters[0], currentPurgedCounters[1], currentPurgedCounters[2], currentPurgedCounters[3]);
                                //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Rep Extracted from taskid " + userTaskReader.CurrentUserTask.UserTaskId);

                                Avanza.CCMS.DAL.Replenishment lastReplenishment =
                                    Avanza.CCMS.DAL.Replenishment.LoadReplenishment(string.Format(" rep_datetime in (select max(rep_Datetime) from replenishment where rep_datetime>=convert(datetime,'{0}',103)" +
                                    " and rep_datetime<convert(datetime,'{2}',103) and atm_id={1}) and atm_id={1}",
                                    DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"), atmAlert.AtmId,
                                    DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss")));


                                if (lastReplenishment != null)
                                {//if counters are same or difference in rep time is <= 30 minutes..
                                    //  task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Last Replenishment extracted counters are " + lastReplenishment.CashAdded1 + " " + lastReplenishment.CashAdded2 + " " + lastReplenishment.CashAdded3 + " " + lastReplenishment.CashAdded4);
                                    if (lastReplenishment.CashAdded1 == replenishment.CashAdded1 &&
                                          lastReplenishment.CashAdded2 == replenishment.CashAdded2 &&
                                              lastReplenishment.CashAdded3 == replenishment.CashAdded3 &&
                                                  lastReplenishment.CashAdded4 == replenishment.CashAdded4 &&
                                                      lastReplenishment.CashAdded5 == replenishment.CashAdded5 &&
                                                          lastReplenishment.CashAdded6 == replenishment.CashAdded6 &&
                                                              lastReplenishment.CashAdded7 == replenishment.CashAdded7
                                         || (Math.Abs((lastReplenishment.RepDatetime - replenishment.RepDatetime).TotalMinutes) <= int.Parse(appSetting.RepTimeDiff))

                                        )
                                    {
                                        ConnectionFactory.ExecuteQuery("insert into replenishmentHistory select * from replenishment where replenishment_id = " + lastReplenishment.ReplenishmentId, trxn);
                                        replenishment.RepDatetime = lastReplenishment.RepDatetime; // Time is overwrite to fetch correct withdrawals entry to update replenishment counters
                                        //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Last replenishment deleted");
                                        //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, string.Format("Counter [{0}],[{1}],[{2}],[{3}]", lastReplenishment.CashAdded1, lastReplenishment.CashAdded2, lastReplenishment.CashAdded3, lastReplenishment.CashAdded4));
                                        lastReplenishment.Delete(trxn.Connection, trxn);

                                        AtmAlert.AtmAlertReader atmAlertReader = AtmAlert.ExecuteReader("entity_id=" + lastReplenishment.ReplenishmentId);
                                        while (atmAlertReader.Read())
                                        {
                                            CcmsIntegratedAlert ccmsIntalert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlertReader.CurrentAtmAlert.AtmAlertId);
                                            if (ccmsIntalert != null)
                                            {
                                                ccmsIntalert.Delete(trxn.Connection, trxn);
                                                //      task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " associated replenishments alert in ccms_integrated_alert also deleted");
                                            }
                                            atmAlertReader.CurrentAtmAlert.Delete(trxn.Connection, trxn);
                                            //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " associated replenishments alert also deleted");
                                        }
                                        atmAlertReader.Close();
                                    }

                                }
                                trxn.Commit();
                            }
                            else
                                LogableTask.LogMonoActivityTask("AutoResolveUserTask", MethodBase.GetCurrentMethod(), TraceLevel.Info, "atmAlert_id " + atmAlert.AtmAlertId + " msg is not consistent " + atmAlert.AlertMsg);
                        }

                    }
                    catch (Exception ex)
                    {
                        LogableTask.LogMonoActivityTask("AutoResolveUserTask", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                        if (trxn != null)
                            trxn.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("AutoResolveUserTask", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                timerAutoResolveUserTasks.Change(new TimeSpan(0, 20, 0), new TimeSpan(0, 0, 0, 0, -1));
                try
                {
                    if (userTaskReader != null)
                        userTaskReader.Close();
                    if (cmd != null)
                        if (cmd.Connection != null)
                            cmd.Connection.Close();

                    //  task.EndTask();
                }
                catch (Exception ex)
                {
                }
            }
            //}


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
