using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Encryption;
using DataRequestor;
using ServicesDAL;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using Renci.SshNet;
using DailyFeedMerger.Models;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.Server;
using System.Threading;
using System.ServiceProcess;

namespace DailyFeedMerger
{
    public class DailyFeedMerger : ServiceBase
    {
        public string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
        string DailyFeedFilePrefix = ConfigurationManager.AppSettings["DailyFeedFilePrefix"];
        private Executor _executor { get; set; }
        public string errorMsg = string.Empty;
        public StringBuilder DFFVersion2Builder = new StringBuilder();
        public static AppSetting appSetting = null;
        DataRequestor.LogableTask task;
        public bool isCompleteAtmDataAvailable = true;
        Timer timerScheduleThreadForExecution;
        Timer timer;
        Timer timerUploadDFs;
        private DateTime? _lastRunDate = null;

        public DailyFeedMerger()
        {
            _executor = new Executor();
            connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");
            ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Core);
            ConnectionFactory.Initialize(connectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);
            appSetting = AppSetting.LoadAppSetting("1=1");
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 2), new TimeSpan(0, 0, 0, 0, -1));
                EventLog.WriteEntry("DailyFeedMerger", "Service Started Successfully");
            }
            catch (Exception ex)
            {
                try
                {
                    //Event log might be full.
                    EventLog.WriteEntry("DailyFeedMerger", ex.Message);
                }
                catch (Exception innerException)
                {
                }
            }
        }

        void ScheduleThreadForExecution(object state)
        {
            try
            {
                DataRequestor.XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\DailyFeedMerger_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");



                timer = new Timer(new TimerCallback(MergeDailyFeedFromAllServers), null, new TimeSpan(0, 0, 5),
                                         new TimeSpan(0, 0, 0, 0, -1));//25 was the time


                timerUploadDFs = new Timer(new TimerCallback(UploadDfs), null, new TimeSpan(0, 2, 0),
                         new TimeSpan(0, 0, 0, 0, -1));

                EventLog.WriteEntry("dailyFeedMerger", "Service Started Successfully", EventLogEntryType.Information);

            }
            catch (Exception ex)
            {
                //trying to log error in event log if its not full.
                try
                {
                    EventLog.WriteEntry("DailyFeedGenerator", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    //EventLog.WriteEntry("CurrencyMngServer", "Service is idle", EventLogEntryType.Warning);
                    timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception innerException)
                {
                    EventLog.WriteEntry("DailyFeedGenerator", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                }
            }
        }
        public List<long> GetAllAtms()
        {
            Atm.AtmReader atmReader = null;
            List<long> list = new List<long>();

            atmReader = Atm.ExecuteReader("is_active=1");
            while (atmReader.Read())
                list.Add(atmReader.CurrentAtm.ATMId);

            return list;
        }

        public void MergeDailyFeedFromAllServers(object state)
        {
            try
            {
                timer.Change(-1, -1);
                task = DataRequestor.LogableTask.NewTask("MergeDailyFeedFromAllServers Started");

                appSetting = AppSetting.LoadAppSetting("1=1");
                TimeSpan targetTimeOfDay = appSetting.DailyFeedGenerationTime.Value.TimeOfDay;
                bool alreadyRanToday = _lastRunDate.HasValue && _lastRunDate.Value.Date == DateTime.Now.Date;
                bool isTimeToRun = DateTime.Now.TimeOfDay >= targetTimeOfDay;

                if (!alreadyRanToday && isTimeToRun)
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "getting all ATMs" + DateTime.Now.ToString());
                    List<long> allAtmLst = GetAllAtms();
                    if (allAtmLst.Count > 0)
                    {
                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Got ATM lst" + DateTime.Now.ToString());
                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to DataReq. for all DFFs" + DateTime.Now.ToString());
                        string allServerdFFContent = string.Empty;


                        DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetDffContent", new SqlParameter[] { }, allAtmLst.ConvertAll(x => x.ToString()));
                        if (!string.IsNullOrEmpty(result.ExceptionMessage))
                        {
                            errorMsg = result.ExceptionMessage;
                            EventLog.WriteEntry("DailyFeedMerger", "Error msg from DataReq. as: " + errorMsg);
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, errorMsg + DateTime.Now.ToString());
                        }
                        if (result.Table.Rows.Count > 0)
                        {
                            DataTable dt = result.Table;

                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Got DFFs from Server's" + DateTime.Now.ToString());
                            EventLog.WriteEntry("DailyFeedMerger", "DFF found for: " + DateTime.Now);

                            if (dt.AsEnumerable().Any(singleRow => singleRow.Field<bool>("is_dff_ready") == false))
                            {
                                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, "Dff not found from servers ");

                                isCompleteAtmDataAvailable = false;
                                List<DataRow> dataRows = dt.AsEnumerable().Where(singleRow => singleRow.Field<bool>("is_dff_ready") == false).ToList();
                                StringBuilder error = new StringBuilder();
                                error.Append("DFF can not be processed due to Servers: ");
                                foreach (DataRow row in dataRows)
                                {
                                    error.Append(row["ServerName"].ToString() + "\t with created for Date: " + row["created_for_date"].ToString() + "\t");
                                }

                                AtmAlert atmAlert = AtmAlert.LoadAtmAlert(" alert_type_id = 63 and resolve_at IS NULL");

                                if (atmAlert != null)
                                {
                                    atmAlert.EventCount = atmAlert.EventCount + 1;
                                    atmAlert.Save();
                                }
                                else
                                {
                                    AtmAlert newAtmAlert = new AtmAlert()
                                    {
                                        GeneratedAt = DateTime.Now,
                                        AlertTypeId = 63,
                                        FailureReason = error.ToString(),
                                        EventCount = 1
                                    };
                                    newAtmAlert.Save();
                                }
                            }
                            else
                            {
                                List<DateTime> datetTimes = (from DataRow row in dt.Rows select (DateTime)row["created_for_date"]).ToList();
                                datetTimes = datetTimes.Select(d => { d = d.Date; return d; }).ToList().GroupBy(x => x.Date).SelectMany(z => z).ToList().Distinct().ToList();

                                List<string> atmIds = new List<string>();

                                foreach (DateTime dateTime in datetTimes)
                                {
                                    DFFVersion2Builder = new StringBuilder();
                                    DFFVersion2Builder.Append("CASHP_ID\tCP_TYPE\tCYCLE_TYPE\tCRNCY_ID\tCRCY_TYP\tCOMP_ID\tDENOM_ID\tDATE\tCASSETTE\tOPEN_BAL\tNOPEN_BAL\tNORM_DEL\tNNORM_DEL\tNORM_RTR\tNNORM_RTR\tUNPL_DEL\tNUNPL_DEL\tUNPL_RTR\tNUNPL_RTR\tWITH_TRAN\tWTHDRWLS\tNWTHDRWLS\tPRE_SRV\tNPRE_SRV\tDEP_TRAN\tDEPOSITS\tNDEPOSITS\tCLOS_BAL\tNCLOS_BAL\tBAL_DISP\tBAL_ESCR\tBAL_UNAV\tOPR_STAT\tEXCLD_FL\r\n");

                                    foreach (DataRow row in dt.AsEnumerable().Where(singleRow => singleRow.Field<DateTime>("created_for_date").ToString("dd/MM/yyyy") == dateTime.ToString("dd/MM/yyyy")))
                                    {
                                        string singleDffContent = Unzip(!DBNull.Value.Equals(row["contents"]) ? (byte[])row["contents"] : new byte[0]);
                                        if (!string.IsNullOrEmpty(singleDffContent))
                                            DFFVersion2Builder.Append(singleDffContent);

                                        atmIds.Add(row["atm_id"].ToString());
                                    }
                                    string outputFilePath = appSetting.DailyFeedOutputFilePath + "\\" + DailyFeedFilePrefix + dateTime.ToString("yyyyMMdd") + ".atm.wrk";

                                    if (!Directory.Exists(appSetting.DailyFeedOutputFilePath))
                                        Directory.CreateDirectory(appSetting.DailyFeedOutputFilePath);

                                    if (File.Exists(outputFilePath))
                                        File.Delete(outputFilePath);

                                    if (!Directory.Exists(appSetting.DailyFeedOutputFilePath + "\\PendingUpload"))
                                        Directory.CreateDirectory(appSetting.DailyFeedOutputFilePath + "\\PendingUpload");

                                    string filePath = appSetting.DailyFeedOutputFilePath + "\\PendingUpload\\" + Path.GetFileName(outputFilePath);
                                    File.WriteAllText(outputFilePath, DFFVersion2Builder.ToString());
                                    if (File.Exists(filePath))
                                        File.Delete(filePath);

                                    HandleFtpFileInfo(outputFilePath, filePath);

                                    SqlParameter param = new SqlParameter()
                                    {
                                        ParameterName = "@CreatedForDate",
                                        SqlDbType = SqlDbType.DateTime,
                                        Value = dateTime
                                    };
                                    DataTableResult result2 = _executor.ExecuteDSRequest<DataTableResult>("UpdateDffUploadStatus", new SqlParameter[] { param }, allAtmLst.ConvertAll(x => x.ToString()));
                                    if (!string.IsNullOrEmpty(result2.ExceptionMessage))
                                    {
                                        EventLog.WriteEntry("DailyFeedMerger", "Error msg from DataReq. while updating as: " + result2.ExceptionMessage);
                                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, result2.ExceptionMessage + DateTime.Now.ToString());
                                    }
                                }

                                _lastRunDate = DateTime.Now.Date;
                            }
                        }
                        else
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "Not a single DFF received from any server's");
                        }
                    }
                    else
                    {
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "Got null or 0 ATMs from Core Table");
                    }
                }
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                EventLog.WriteEntry("DailyFeedMerger", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
            }
            finally
            {
                try
                {
                    if (appSetting != null)
                        timer.Change(new TimeSpan(0, (int)appSetting.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                    else
                        timer.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));

                    EventLog.WriteEntry("DailyFeedMerger", "function MergeDailyFeedFromAllServers ended" + DateTime.Now);
                    task.EndTask();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("DailyFeedMerger", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                }
            }
        }

        public void HandleFtpFileInfo(string outputFilePath, string filePath)
        {
            File.Move(outputFilePath, filePath);
            FtpFileInfo ftpFileInfo = new FtpFileInfo();
            ftpFileInfo.CreationTime = DateTime.Now;
            ftpFileInfo.FtpFilename = filePath;
            ftpFileInfo.RetryCount = appSetting.RetryCountDffUpload;
            ftpFileInfo.Status = UploadStates.scheduled.ToString();
            ftpFileInfo.TaskTypeId = (int)EnumTaskType.DailyFeedUpload;
            ftpFileInfo.Save();
        }

        private void UploadDfs(object obj)
        {
            timerUploadDFs.Change(-1, -1);
            DataRequestor.LogableTask task = DataRequestor.LogableTask.NewTask("uploadDFs");
            FtpFileInfo.FtpFileInfoReader reader = null;
            try
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to read uploading jobs");
                reader = FtpFileInfo.ExecuteReader("status = '" + FTPUploadStatus.scheduled.ToString() + "' and retry_count > 0 and task_type_id = " + (int)EnumTaskType.DailyFeedUpload);
                while (reader.Read())
                {
                    reader.CurrentFtpFileInfo.RetryCount--;
                    reader.CurrentFtpFileInfo.LastInvokedAt = DateTime.Now;
                    reader.CurrentFtpFileInfo.Status = "Processing";
                    reader.CurrentFtpFileInfo.Save();


                    try
                    {
                        string FileName = reader.CurrentFtpFileInfo.FtpFilename;
                        if (!File.Exists(FileName))
                            throw new Exception("file " + FileName + " does not exists");
                        long organization_id = reader.CurrentFtpFileInfo.RegionId;
                        //Region region = Region.LoadRegion("region_id=" + organization_id);
                        if (appSetting.IsSecuredAccess.HasValue && appSetting.IsSecuredAccess.Value)
                        {
                            string remoteFilePrefix = null;
                            string remoteFileName = null;
                            //Scp scp = new Scp();
                            int port = 22;
                            string[] parts = appSetting.DailyFeedFtpUri.Split(':');
                            string[] subParts = parts[0].Split('/');
                            string server = subParts[0];
                            if (subParts.Length > 1)
                                remoteFilePrefix = parts[0].Substring(parts[0].IndexOf('/'));

                            if (parts.Length > 1)
                                port = int.Parse(parts[1]);

                            if (remoteFilePrefix != null)
                                remoteFileName = remoteFilePrefix + "/" + Path.GetFileName(FileName);
                            else
                                remoteFileName = Path.GetFileName(FileName);


                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + FileName);
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Remote File Name: " + remoteFileName);
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Remote File prefix: " + remoteFilePrefix);
                            UploadSFTPFile(server, appSetting.DailyFeedFtpUsername, appSetting.DailyFeedFtpPassword, FileName, remoteFileName, port, remoteFilePrefix);
                            //scp.DoWork(FileName, server, remoteFileName,
                            //region.DailyFeedFtpUsername, Cryptic.DecryptString(region.DailyFeedFtpPassword), port, remoteFileName.Substring(0, remoteFileName.IndexOf(".wrk")));
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded,Permissions Changed and Renamed Operation Completed Successfully");

                        }
                        else
                        {
                            FTPManager ftpManager = new FTPManager();
                            ftpManager.FtpPassword = appSetting.DailyFeedFtpPassword;
                            ftpManager.FtpServerIP = appSetting.DailyFeedFtpUri;
                            ftpManager.FtpUserId = appSetting.DailyFeedFtpUsername;


                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + FileName);
                            ftpManager.UploadFile(FileName); // already there :)
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded Successfully");


                            string currentFileName = Path.GetFileName(FileName);
                            ftpManager.RenameFile(currentFileName, currentFileName.Substring(0, currentFileName.IndexOf(".wrk")));
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Renamed Successfully on FTP server");
                        }



                        string outputArchiveFolderPath = appSetting.DailyFeedOutputFilePath + "\\OutputArchive";
                        if (!Directory.Exists(outputArchiveFolderPath))
                            Directory.CreateDirectory(outputArchiveFolderPath);

                        if (File.Exists(outputArchiveFolderPath + "\\" + Path.GetFileName(FileName)))
                            File.Delete(outputArchiveFolderPath + "\\" + Path.GetFileName(FileName));

                        File.Move(FileName, outputArchiveFolderPath + "\\" + Path.GetFileName(FileName));



                        reader.CurrentFtpFileInfo.Status = FTPUploadStatus.completed.ToString();
                        reader.CurrentFtpFileInfo.EndTime = DateTime.Now;
                        reader.CurrentFtpFileInfo.FailureReason = "";
                        reader.CurrentFtpFileInfo.Save();
                        //AlertManager.GenerateCCMSEvent
                        //                        (EventType.DFFGeneration.ToString(), EventType.DFFGeneration.ToString(), Event_Type.Alert.ToString(),
                        //                       organization_id.ToString(), EntityType.Organization.ToString(),
                        //                        Actors.CCMS.ToString(), Actors.CCMS.ToString(), null);

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
                            //AlertManager.GenerateOrganizationAlert(reader.CurrentFtpFileInfo.FtpFileInfoId, (int)EnumAlertType.DailyFeedUpload, null, Event_Type.Error, reader.CurrentFtpFileInfo.RegionId);
                            //AlertManager.GenerateCCMSEvent
                            //                    (EventType.DFFUploadFailed.ToString(), EventType.DFFUploadFailed.ToString(),
                            //                    Event_Type.Error.ToString(),
                            //                   reader.CurrentFtpFileInfo.RegionId.ToString(), EntityType.Organization.ToString(),
                            //                    Actors.CCMS.ToString(), Actors.OPTICash.ToString(), null);


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

                    if (appSetting != null)
                        timerUploadDFs.Change(new TimeSpan(0, (int)appSetting.RefreshInterval * 10, 0), new TimeSpan(0, 0, 0, 0, -1));
                    else
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        public void UploadSFTPFile(string host, string username,
        string password, string sourcefile, string destinationpath, int port, string changeDir)
        {
            int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["DFFConnectTimeout"]);

            using (SftpClient client = new SftpClient(host, port, username, password))
            {
                try
                {
                    client.KeepAliveInterval = TimeSpan.FromMinutes(timeout);
                    client.ConnectionInfo.Timeout = TimeSpan.FromMinutes(timeout);
                    client.OperationTimeout = TimeSpan.FromMinutes(timeout);
                    client.Connect();
                    client.ChangeDirectory(changeDir);
                    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fs, Path.GetFileName(sourcefile));
                        DataRequestor.LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to Rename file:" + destinationpath);
                        //client.ChangePermissions(destinationpath, (short)System.Security.AccessControl.FileSystemRights.FullControl);
                        client.ChangePermissions(destinationpath, 7);
                        client.RenameFile(destinationpath, destinationpath.Split(new string[] { ".wrk" }, StringSplitOptions.None)[0]);
                        DataRequestor.LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Renamed: " + destinationpath);
                    }
                }
                catch (Exception ex)
                {
                    client.Disconnect();
                    DataRequestor.LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
                    if (ex.InnerException != null)
                    {
                        DataRequestor.LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.InnerException.Message);
                    }
                }
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
    }
}
