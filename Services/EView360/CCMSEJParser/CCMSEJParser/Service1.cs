using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Avanza.iSuite.DAL;
using Avanza.CCMS.DAL;
using Microsoft.Win32;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;
using EJSummarizer;
using System.Net;
using System.Data.OleDb;
using Encryption;
using SharpSsh;
using Avanza.CCMS.Parsers;
namespace CCMSEJParser
{
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
        public void UploadFile(string filePath)
        {
            FileInfo fileInf = new FileInfo(filePath);
            string uri = ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

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
    public partial class Service1 : ServiceBase
    {
        string outputFolderPath = System.Configuration.ConfigurationManager.AppSettings["OutputFolderPath"];
        string outputArchiveFolderPath = System.Configuration.ConfigurationManager.AppSettings["OutputArchiveFolderPath"];
        string ftpURL = System.Configuration.ConfigurationManager.AppSettings["ftpURL"];
        string ftpUserName = System.Configuration.ConfigurationManager.AppSettings["ftpUsrName"];
        string ftpPwd = System.Configuration.ConfigurationManager.AppSettings["ftpPassword"];
        static Regex formattingChars = new Regex(@"([[]00p)|([[]05p)|([[]020t)|([[]0r[(]1[)]2[[]000p[[]040qe1w3h162)|([(]\D)|([(]\d)|([(]C)|([[]040)|([[]000p)|(/)|(q[(]I)|(q[(]1)|([(]7)|([(]>)|()|([(]>)|([(]C)|([(]1)|([(]D)|(\+)");
        string normalTransactionRegex = @"(NOTE/?S[ ]PRESENTED[ ](?<Notes>[\d,]*)\r?\n?)?\d{2}/\d{2}/\d{2}[ ](?<Date>\d{2}/\d{2}/\d{2})[ ]+(?<Time>\d{2}:\d{2})[ ]+(?<TerminalID>\d*)[ ]+(?<TSN>\d*)[ ]+(?<TransactionType>\d*)\r?\n?[ ]*(?<PAN>\d+-*\d+)[ ]+(?<Amount>[\d\.,]+)[ ]+(?<CurrencyCode>\d+)\r?\n?SURCHARGE:[ ]+[\d\.]+\r?\n?[ ]+(?<ResponseCode>\d+)";
        Timer timer;
        Timer timerScheduleThreadForExecution;
        Timer timerUploadDFs;
        public static AppSetting appSettings;
        string[] dateFormats = new string[] { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy h:mm:ss tt", "dd/M/yyyy h:mm:ss tt", 
                                              "MM/dd/yyyy HH:mm:ss","MM/dd/yyyy h:mm:ss tt","M/dd/yyyy h:mm:ss tt" };
        public Service1()
        {
            InitializeComponent();
        }
        void ScheduleThreadForExecution(object state)
        {
            try
            {

                string connectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\CCMS").GetValue("ConnectionString", "");
                connectionStr = Encryption.Cryptic.DecryptString(connectionStr);
                ConnectionFactory.Initialize(connectionStr, true);
                appSettings = AppSetting.LoadAppSetting("1=1");
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\CCMSEJParser{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : CCMSEJParser 1.0.0.0, Modified Date 03-May-2013");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");
                timer = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                timerUploadDFs = new System.Threading.Timer(new System.Threading.TimerCallback(UploadDfs), null, new TimeSpan(0, 0, 35),
                                         new TimeSpan(0, 0, 0, 0, -1));
                EventLog.WriteEntry("CCMSEJPARSER", "Service Started Successfully", EventLogEntryType.Information);

            }
            catch (Exception ex)
            {
                //trying to log error in event log if its not full.
                try
                {
                    EventLog.WriteEntry("CCMSEJPARSER", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    //EventLog.WriteEntry("CurrencyMngServer", "Service is idle", EventLogEntryType.Warning);
                    timerScheduleThreadForExecution.Change(new TimeSpan(0, appSettings.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception innerException)
                {
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 25), new TimeSpan(0, 0, 0, 0, -1));
            EventLog.WriteEntry("CCMSEJPARSER", "Thread schedular sent startup request", EventLogEntryType.Information);
        }

        private byte[] GetUnzippedBytes(byte[] ejData)
        {
            MemoryStream memStream = new MemoryStream(ejData, false);
            ZipInputStream zipStream = new ZipInputStream(memStream);
            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get next entry");
            ZipEntry entry = zipStream.GetNextEntry();//only one file expected,ie ej file
            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Next entry extracted");
            byte[] unZippedEJ = new byte[entry.Size];
            int totalLength = unZippedEJ.Length;
            int readByteCount = 0;
            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to populate data in arr");
            while (readByteCount < unZippedEJ.Length)
                readByteCount += zipStream.Read(unZippedEJ, readByteCount, unZippedEJ.Length);
            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "arr populated");
            zipStream.Close();
            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "EJ unziped");
            return unZippedEJ;
        }

        void DoWork(object state)
        {
            timer.Change(-1, -1);


            LogableTask task = LogableTask.NewTask("DoWork");
            SqlConnection conn = null;
            int taskID = -1;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\CCMSEJParser{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));

                //if (outputArchiveFolderPath.Length == 0)
                //    throw new Exception("Output Archive Folder Path is not defined!");

                //if (!Directory.Exists(outputArchiveFolderPath))
                //    Directory.CreateDirectory(outputArchiveFolderPath);

                //if (outputFolderPath.Length == 0)
                //    throw new Exception("Output Folder Path is not defined!");

                //if (!Directory.Exists(outputFolderPath))
                //    Directory.CreateDirectory(outputFolderPath);

                Task.TaskReader cashDataReader = Task.ExecuteReader(
                " task_id in ( select task_id from task inner join file_type on file_type.file_type_id = task.file_type_id"
            + " where task.file_type_id in (2,3) and retry_remaining>0 and (status ='downloadedParsePending' or (status ='downloadedParsing'  and last_invoked < dateadd(hh,-15, getdate())))) order by task_id");
                SqlConnection cashDataConnection = ConnectionFactory.GetNewConnection();
                cashDataConnection.Open();
                SqlCommand cmd = cashDataConnection.CreateCommand();
                conn = ConnectionFactory.GetNewConnection();
                conn.Open();
                int counter = 0;
                string fileContent = null;
                while (cashDataReader.Read())
                {

                    LogableTask parseCashDataTask = null;
                    SqlTransaction dbTrx = null;
                    if (cashDataReader.CurrentTask.RetryRemaining > 0)
                        cashDataReader.CurrentTask.RetryRemaining--;
                    taskID = cashDataReader.CurrentTask.TaskId;
                    try
                    {

                        parseCashDataTask = LogableTask.NewTask("Parse EJ, TaskId=" + cashDataReader.CurrentTask.TaskId);


                        LogableTask.LogMonoActivityTask("Parse EJ", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Parse EJ, TaskId=" + cashDataReader.CurrentTask.TaskId);
                        cashDataReader.CurrentTask.LastInvoked = DateTime.Now;


                        cashDataReader.CurrentTask.Status = DownloadStates.downloadedParsing.ToString();
                        cashDataReader.CurrentTask.Save();

                        EjFileDownloadStatus ejStatus = EjFileDownloadStatus.LoadEjFileDownloadStatus("atm_id = " + cashDataReader.CurrentTask.ATMId +
                            " and ej_file_download_time =convert(datetime,'" + cashDataReader.CurrentTask.EndTime.Value.ToString("dd/MM/yyyy") + "',103)");
                        if (ejStatus == null)
                        {
                            ejStatus = new EjFileDownloadStatus();
                            ejStatus.AtmId = cashDataReader.CurrentTask.ATMId;
                            ejStatus.EjFileDownloadTime = new DateTime(cashDataReader.CurrentTask.EndTime.Value.Year,
                                cashDataReader.CurrentTask.EndTime.Value.Month, cashDataReader.CurrentTask.EndTime.Value.Day);
                            ejStatus.ProcessingDatetime = DateTime.Now;
                            ejStatus.Save();
                        }
                        if (cashDataReader.CurrentTask.FileTypeId == 2)
                        {
                            cashDataConnection.ChangeDatabase("CashDataStore_" + cashDataReader.CurrentTask.CreationTime.Year.ToString());
                            cmd.CommandText = "select cash_data_file from cashDataFiles where task_id =" + cashDataReader.CurrentTask.TaskId;
                            byte[] ejData = (byte[])cmd.ExecuteScalar();

                            if (ejData == null)
                            {
                                throw new Exception("no data found in the CashDataStore for task_id = " + cashDataReader.CurrentTask.TaskId);
                            }

                            MemoryStream memStream = new MemoryStream(ejData, false);
                            ZipInputStream zipStream = new ZipInputStream(memStream);


                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get next entry");
                            ZipEntry entry = zipStream.GetNextEntry();//only one file expected,ie ej file
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Next entry extracted");
                            byte[] unZippedEJ = new byte[entry.Size];
                            int totalLength = unZippedEJ.Length;
                            int readByteCount = 0;
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to populate data in arr");
                            while (readByteCount < unZippedEJ.Length)
                                readByteCount += zipStream.Read(unZippedEJ, readByteCount, unZippedEJ.Length);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "arr populated");
                            zipStream.Close();
                            parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "EJ unziped");

                            dbTrx = conn.BeginTransaction();


                            fileContent = Encoding.ASCII.GetString(GetUnzippedBytes(ejData));
                            fileContent = formattingChars.Replace(fileContent, "");
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "EJ Formatted");
                            counter++;
                            //File.WriteAllText("C:\\"+counter.ToString(), fileContent);

                            ExtractCardCaptures(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            ReplenishmentExtractor replenishmentExtractor = new ReplenishmentExtractor();
                            replenishmentExtractor.ParseAndSaveReplenishment(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Rep extratced");
                            Parser parser = new Parser();
                            parser.ParseAndSaveEJ(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Normal trxn extratced");

                           
                            BNAParser BNAParser = new BNAParser();
                            BNAParser.ParseAndSaveEJ(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Dep extratced");

                        }
                        else if (cashDataReader.CurrentTask.FileTypeId == 3)
                        {

                            //string dirPath = appSettings.DownloadedFilePath + "\\" + cashDataReader.CurrentTask.ATMId;
                            //DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                            //                          FileInfo[] MDBfileInfos = ;//  directoryInfo.GetFiles("*.mdb");
                            //                            foreach (FileInfo MDBfileInfo in MDBfileInfos)

                            byte[] data = GetUnzippedBytes(File.ReadAllBytes(cashDataReader.CurrentTask.ServerFilepath));
                            string MDBFilePath = appSettings.DownloadedFilePath + "\\" + cashDataReader.CurrentTask.ATMId + "\\" +
                                Path.GetFileNameWithoutExtension(cashDataReader.CurrentTask.ServerFilepath) + ".mdb";
                            if (File.Exists(MDBFilePath))
                                File.Delete(MDBFilePath);
                            File.WriteAllBytes(MDBFilePath, data);
                            fileContent = PopulateDatabaseAndReturnEJ(MDBFilePath, cashDataReader.CurrentTask.ATMId, cashDataReader.CurrentTask.TaskId);
                            dbTrx = conn.BeginTransaction();

                            Parser parser = new Parser();
                            parser.ParseAndSaveEJ(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Normal trxn extratced");

                            ReplenishmentExtractor replenishmentExtractor = new ReplenishmentExtractor();
                            replenishmentExtractor.ParseAndSaveReplenishment(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Rep extratced");
                            BNAParser BNAParser = new BNAParser();

                            BNAParser.ParseAndSaveEJ(ref fileContent, cashDataReader.CurrentTask, parseCashDataTask, dbTrx);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Dep extratced");

                        }
                        else
                            throw new Exception("Parsing not supported for file Type :" + cashDataReader.CurrentTask.FileTypeId);

                        //dbTrx.Commit();
                        cashDataReader.CurrentTask.Status = DownloadStates.completed.ToString();
                        cashDataReader.CurrentTask.FailureReason = string.Empty;
                        cashDataReader.CurrentTask.Parsed = true;
                        cashDataReader.CurrentTask.Save();
                        dbTrx.Commit();

                    }
                    catch (Exception ex1)
                    {
                        if (dbTrx != null)
                            dbTrx.Rollback();

                        cashDataReader.CurrentTask.Parsed = false;
                        cashDataReader.CurrentTask.Status = DownloadStates.parsingFailed.ToString();
                        cashDataReader.CurrentTask.FailureReason += " " + ex1.Message;
                        cashDataReader.CurrentTask.FailureReason = (cashDataReader.CurrentTask.FailureReason.Length > 512) ? cashDataReader.CurrentTask.FailureReason.Substring(0, 511) : cashDataReader.CurrentTask.FailureReason;
                        cashDataReader.CurrentTask.FailureReason = cashDataReader.CurrentTask.FailureReason.Replace("'", "''");
                        cashDataReader.CurrentTask.Save();
                        parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex1);

                    }
                    finally
                    {
                        parseCashDataTask.EndTask();
                    }
                }
                cashDataReader.Close();
                cashDataConnection.Close();
                //bool oneTimeChk = false;
                Region.RegionReader regionReader = Region.ExecuteReader("region_id > 1 and is_active=1 and is_organization = 1 and is_ej_enabled=1 and priority=0");
                //Get all organizations
                while (regionReader.Read())
                {

                    //task = LogableTask.NewTask("Processing organizaton :" + regionReader.CurrentRegion.RegionName);

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
                        //if (!oneTimeChk)
                        //{
                        //    if (appSettings.HoldOtherDfTasks)
                        //    {
                        //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Other DF Generation job is in process state.");
                        //        return;
                        //    }
                        //    appSettings.HoldOtherDfTasks = true;
                        //    appSettings.Save();
                        //    oneTimeChk = true;
                        //}

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
                                        cmd = ConnectionFactory.GetNewCommand(false);
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
                                            cms.BuildSummary(task, list, false);
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
                                        McnAtms.McnAtmsReader mcnAtmsReader = McnAtms.ExecuteReader("mcn='" + mcn + "'");
                                        while (mcnAtmsReader.Read())
                                        {
                                            list.Add(mcnAtmsReader.CurrentMcnAtms.AtmId);
                                        }
                                        mcnAtmsReader.Close();

                                        cms.Initialize();
                                        cms.BuildSummary(task, list, false);

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
                                        ftpFileInfo.TaskTypeId = (int)EnumTaskType.EJDailyFeedUpload;
                                        ftpFileInfo.Save();
                                    }

                                    schemeCount++;
                                    regionReader.CurrentRegion.DailyFeedGenerationTime = regionReader.CurrentRegion.DailyFeedGenerationTime.Value.AddDays(1);
                                    regionReader.CurrentRegion.Save();
                                    
                                }
                                reader.Close();
                                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Org "+ regionReader.CurrentRegion.RegionName+ " ,scheme count: " + schemeCount);
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
                    //task.EndTask();
                }
                //cmd = conn.CreateCommand();
                //cmd.CommandText = "select last_ej_summary_generated_at from app_setting";
                //DateTime SummaryDay = (DateTime)cmd.ExecuteScalar();

                //int lagInterval = int.Parse(System.Configuration.ConfigurationManager.AppSettings["lagInterval"]);


                //TimeSpan timeSpan = DateTime.Now - SummaryDay;

                //if (timeSpan.Days >= lagInterval)
                //{
                //    task = LogableTask.NewTask("Going to build summary");
                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "lag interval(Day): " + lagInterval);

                //    if (DateTime.Now >= SummaryDay)
                //    {

                //        CMS cms = new CMS();

                //        cms.SetSummaryDay = SummaryDay;
                //        //run in a loop for each atm
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to generate summary for Day : " + SummaryDay);
                //        try
                //        {
                //            List<int> atmIds = new List<int>();
                //            Atm.AtmReader reader = Atm.ExecuteReader("");
                //            while (reader.Read())
                //                atmIds.Add(reader.CurrentAtm.ATMId);
                //            reader.Close();

                //            if (cms.BuildSummary(task, atmIds, false))
                //            {
                //                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary Generated");
                //                //get the required output...
                //                string outputFilePath = outputFolderPath + "\\BSF" + SummaryDay.ToString("yyyyMMdd") + ".atm.wrk";
                //                File.WriteAllText(outputFilePath, cms.GetOutput());
                //                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Output file generated");
                //                appSettings.LastEjSummaryGeneratedAt = appSettings.LastEjSummaryGeneratedAt.Value.AddDays(1);
                //                appSettings.Save();

                //            }
                //            else
                //                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "No data found for day :" + SummaryDay);
                //        }
                //        catch (Exception ex)
                //        {
                //            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message + "<br/>" + ex.StackTrace + "<br/> " + ex.InnerException);
                //        }

                //    }
                //    else
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Its not " + SummaryDay);
                //    task.EndTask();

                //}
                //else
                //    LogableTask.LogMonoActivityTask("GenerateSummary", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Summary generation delayed");
                //task = LogableTask.NewTask("Starting FTP Manager");

                //DirectoryInfo dirInfo = new DirectoryInfo(outputFolderPath);


                ////string[] filesProcesed = null;
                ////if (File.Exists(dirInfo.FullName + "\\processed.txt"))
                ////    filesProcesed = File.ReadAllText(dirInfo.FullName + "\\processed.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                ////StreamWriter fileWriter = new StreamWriter(new FileStream(dirInfo.FullName + "\\processed.txt", FileMode.Append, FileAccess.Write));

                //FileInfo[] fileInfo = dirInfo.GetFiles();
                //task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Count:" + fileInfo.Length);
                //foreach (FileInfo _file in fileInfo)
                //{
                //    try
                //    {
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

                //        FTPManager ftpManager = new FTPManager();

                //        ftpManager.FtpPassword = ftpPwd;
                //        ftpManager.FtpServerIP = ftpURL;
                //        ftpManager.FtpUserId = ftpUserName;


                //        //WebRequest request = System.Net.FtpWebRequest.Create(ftpURL + "/" + _file.Name + ".wrk");
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Uploading file:" + _file.Name);

                //        //if (isRenamed)
                //        //    ftpManager.UploadFile(_file.FullName + ".wrk");
                //        //else
                //        ftpManager.UploadFile(_file.FullName); // already there :)

                //        //request.Credentials = new NetworkCredential(ftpUserName, ftpPwd);
                //        //request.Method = WebRequestMethods.Ftp.UploadFile;
                //        //StreamWriter writer = new StreamWriter(request.GetRequestStream());
                //        //writer.WriteLine(File.ReadAllText(_file.FullName + ".wrk"));
                //        //writer.Close();
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Uploaded Successfully");

                //        //if (isRenamed)
                //        //    ftpManager.RenameFile(_file.Name + ".wrk", _file.Name);
                //        //else
                //        ftpManager.RenameFile(_file.Name, _file.Name.Substring(0, _file.Name.IndexOf(".wrk")));

                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Renamed Successfully on FTP server");
                //        //File.Move(_file.FullName + ".wrk", _file.FullName);
                //        //if (isRenamed)
                //        //    File.Move(_file.FullName + ".wrk", outputArchiveFolderPath + "\\" + _file.Name + ".wrk");
                //        //else
                //        if (File.Exists(outputArchiveFolderPath + "\\" + _file.Name))
                //            File.Delete(outputArchiveFolderPath + "\\" + _file.Name);

                //        File.Move(_file.FullName, outputArchiveFolderPath + "\\" + _file.Name);

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
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                try
                {
                    //if (appSettings.HoldOtherDfTasks)
                    //{
                    //    appSettings.HoldOtherDfTasks = false;
                    //    appSettings.Save();
                    //}

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Wake up after " + appSettings.RefreshInterval + " min");
                    task.EndTask();
                }
                catch (Exception ex)
                {
                    try
                    {
                        EventLog.WriteEntry("CCMSEJParser", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    }
                    catch (Exception innerException)
                    {
                    }

                }
                finally
                {
                    timer.Change(new TimeSpan(0, appSettings.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                }

            }

        }

        private string PopulateDatabaseAndReturnEJ(string fileName, int atmID, int taskID)
        {
            StringBuilder builder = new StringBuilder();
            OleDbCommand command = new OleDbCommand(@"select text,date,[module] from events", new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";"));
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            SqlCommand cmd = ConnectionFactory.GetNewCommand(true);
            DateTime transactionDateTime = DateTime.Now;
            long lineNo = 0;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lineNo++;
                    builder.Append(dr["text"].ToString() + "\r\n");
                    if (dr["module"].ToString() == "BWC_SupApp")
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "isEJEventExists";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("ejText", SqlDbType.VarChar));
                        cmd.Parameters.Add(new SqlParameter("ejDatetime", SqlDbType.VarChar));
                        cmd.Parameters[0].Value = atmID;
                        cmd.Parameters[1].Value = dr["text"];

                        DateTime.TryParseExact(dr["date"].ToString(), dateFormats, null, System.Globalization.DateTimeStyles.None, out transactionDateTime);

                        cmd.Parameters[2].Value = transactionDateTime.ToString("dd/MM/yyyy HH:mm:ss"); ;
                        //DateTime.ParseExact(dr["date"].ToString(),"dd/MM/yyyy HH:mm:ss",null).ToString("dd/MM/yyyy HH:mm:ss");


                        if ((int)cmd.ExecuteScalar() == 0)
                        {
                            EjEvents ejEvents = new EjEvents();
                            ejEvents.AtmId = atmID;
                            ejEvents.EjDatetime = transactionDateTime;// DateTime.ParseExact(dr["date"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                            ejEvents.EjText = dr["text"].ToString();
                            ejEvents.ProcessingDatetime = DateTime.Now;
                            ejEvents.TaskId = taskID;
                            ejEvents.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while processing line no " + lineNo + " " + ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                if (cmd.Connection != null)
                    cmd.Connection.Close();
            }



            return builder.ToString();
        }
        private void ExtractCardCaptures(ref string ejData, Task downloadTask, LogableTask task, SqlTransaction trxn)
        {
            //*406*04/01/2008*10:49*
            //     *
            //     *
            //     *CARD CAPTURED A/C
            //6391390103002355631*

            Regex regEx = new Regex(@"(\*(?<Stan>\d+)\*(?<Date>\d{2}/\d{2}/\d{4})\*(?<Time>\d{2}:\d{2})(\*\s+)*\*(?<Reason>CARD CAPTURED A/C)\s+(?<PAN>[\w\*]+))");
            Match match = regEx.Match(ejData);
            while (match.Success)
            {
                EjCapturedCard capturedCard = new EjCapturedCard();
                capturedCard.AtmId = downloadTask.ATMId;
                capturedCard.CaptureTime = DateTime.ParseExact(match.Groups["Date"].Captures[0].Value + " " + match.Groups["Time"].Captures[0].Value,
                                           Parser.CardCaptureDateTimeFormat, null);

                EjCapturedCard existingCapturedCard = EjCapturedCard.LoadEjCapturedCard("atm_id=" + downloadTask.ATMId + " and capture_time=convert(datetime,'" +
 capturedCard.CaptureTime.ToString("dd/MM/yyyy HH:mm:ss") + "',103)");
                if (existingCapturedCard != null)
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in ej_captured_card table");
                    match = match.NextMatch();
                    continue;
                }



                capturedCard.TSN = int.Parse(match.Groups["Stan"].Captures[0].Value);
                capturedCard.PAN = match.Groups["PAN"].Captures[0].Value.Remove(match.Groups["PAN"].Captures[0].Value.Length - 1);
                capturedCard.TaskId = downloadTask.TaskId;
                capturedCard.ProcessingDatetime = DateTime.Now;
                capturedCard.Save(trxn.Connection, trxn);
                match = match.NextMatch();
            }
            //  con.Close();            
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
        private void UploadDfs(object obj)
        {
            LogableTask task = LogableTask.NewTask("uploadDFs");
            timerUploadDFs.Change(-1, -1);
            FtpFileInfo.FtpFileInfoReader reader = null;
            try
            {
                reader = FtpFileInfo.ExecuteReader("status = '" + FTPUploadStatus.scheduled.ToString() + "' and retry_count > 0 and task_type_id = " + (int)EnumTaskType.EJDailyFeedUpload);
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
                           Utility.GenerateOrganizationAlert(reader.CurrentFtpFileInfo.FtpFileInfoId, (int)EnumAlertType.DailyFeedUpload, null, Event_Type.Error, reader.CurrentFtpFileInfo.RegionId,appSettings.AlertExpirationTime.Value);
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
                    timerUploadDFs.Change(new TimeSpan(0, (int)appSettings.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                    task.EndTask();
                }
                catch (Exception ex)
                {
                    try
                    {
                        EventLog.WriteEntry("CCMSEJParser", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    }
                    catch (Exception innerException)
                    {
                    }

                }
            }
        }
    }
}
