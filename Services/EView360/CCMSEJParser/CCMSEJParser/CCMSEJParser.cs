using Avanza.CCMS.Parser;
using Encryption;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using Newtonsoft.Json;
using ServicesDAL;
using System;
using System.CodeDom.Compiler;
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
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

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
        Regex regex = new Regex(@"<Date>" + DateTime.Today.Month.ToString().PadLeft(2, '0') + @"/\d+/" + DateTime.Today.Year + "</Date>");
        public static string keepOneCashDataStoreName = System.Configuration.ConfigurationManager.AppSettings["keepOneCashDataStoreName"];
        bool isEJSummaryEnabled = System.Configuration.ConfigurationManager.AppSettings["isEJSummaryEnabled"] == "1" ? true : false;
        bool mergeLastDownloadedEjEnabled = System.Configuration.ConfigurationManager.AppSettings["mergeLastDownloadedEjEnabled"] == "1" ? true : false;
        bool extractFailureReason = System.Configuration.ConfigurationManager.AppSettings["extractFailureReason"] == "1" ? true : false;
        string DFFGenerationTime = System.Configuration.ConfigurationManager.AppSettings["DFFGenerationTime"];
        int maxProcessor = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxProcessor"] ?? "1");
        string outputFolderPath = System.Configuration.ConfigurationManager.AppSettings["OutputFolderPath"];
        string outputArchiveFolderPath = System.Configuration.ConfigurationManager.AppSettings["OutputArchiveFolderPath"];
        string shortestJobProcessingEnabled = System.Configuration.ConfigurationManager.AppSettings["shortestJobProcessingEnabled"];
        bool isUnicode = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsUnicode"] ?? "false");
        bool IsBackCheckForReplenishment = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsBackCheckForReplenishment"] ?? "false");
        //Added for DP
        bool isUnicode_le_bom = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsUnicode_LE_BOM"] ?? "false");

        string ftpURL = System.Configuration.ConfigurationManager.AppSettings["ftpURL"];
        string ftpUserName = System.Configuration.ConfigurationManager.AppSettings["ftpUsrName"];
        string ftpPwd = System.Configuration.ConfigurationManager.AppSettings["ftpPassword"];
        Regex formattingChars = new Regex(@"([[]00p)|([[]05p)|([[]020t)|([[]0r[(]1[)]2[[]000p[[]040qe1w3h162)|([(]\D)|([(]\d)|([(]C)|([[]040)|([[]000p)|(/)|(q[(]I)|(q[(]1)|([(]7)|([(]>)|()|([(]>)|([(]C)|([(]1)|([(]D)|(\+)|()");

        Timer timer;
        Timer timerScheduleThreadForExecution;
        Timer timerUploadDFs;
        Timer timerInitEJFailureNotifier;
        int fromExecTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DFFSchedulesFromExecutionTime"] ?? "0");
        int toExecTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DFFSchedulesToExecutionTime"] ?? "0");
        System.Threading.Timer timerExecuteDFSchedules;
        //List<int> msgProc = new List<int>();
        
        // the MSMQ is disabled 
        //private static MessageQueue queue = new MessageQueue($@".\private$\{ConfigurationManager.AppSettings["EjParserQueueName"]}");

        public static AppSetting appSettings;

        string[] dateFormats = new string[] { "M/d/yyyy h:mm:ss tt" ,"MM/dd/yyyy h:mm:ss tt" ,"M/dd/yyyy h:mm:ss tt" ,"MM/d/yyyy h:mm:ss tt",
            "M/d/yyyy HH:mm:ss" ,"MM/dd/yyyy HH:mm:ss" ,"M/dd/yyyy HH:mm:ss" ,"MM/d/yyyy HH:mm:ss",
        "d/M/yyyy h:mm:ss tt" ,"dd/MM/yyyy h:mm:ss tt" ,"dd/M/yyyy h:mm:ss tt" ,"d/MM/yyyy h:mm:ss tt" ,
        "d/M/yyyy HH:mm:ss" ,"dd/MM/yyyy HH:mm:ss" ,"dd/M/yyyy HH:mm:ss" ,"d/MM/yyyy HH:mm:ss" };


        string[] dateFormats_DDMMYYYY = new string[] {
        "d/M/yyyy h:mm:ss tt" ,"dd/MM/yyyy h:mm:ss tt" ,"dd/M/yyyy h:mm:ss tt" ,"d/MM/yyyy h:mm:ss tt" ,
        "d/M/yyyy HH:mm:ss" ,"dd/MM/yyyy HH:mm:ss" ,"dd/M/yyyy HH:mm:ss" ,"d/MM/yyyy HH:mm:ss"};
        string[] dateFormats_MMDDYYYY = new string[] {
        "M/d/yyyy h:mm:ss tt" ,"MM/dd/yyyy h:mm:ss tt" ,"M/dd/yyyy h:mm:ss tt" ,"MM/d/yyyy h:mm:ss tt",
            "M/d/yyyy HH:mm:ss" ,"MM/dd/yyyy HH:mm:ss" ,"M/dd/yyyy HH:mm:ss" ,"MM/d/yyyy HH:mm:ss"};

        #region DeclerationsForMergineEJToGetCompleteRep
        /// <summary>
        /// Added by Ali Shah on 16March2017
        /// Merge ej files until complete replenishment extracted
        /// </summary>
        Regex regexRepStart = new Regex(@"SERVICEMODE[ ]*ENTERED");
        Regex regexTransaction = new Regex(@"TRANSACTION[ ]*END|(DATE[ ]+HOUR[ ]+OP\.?[ ]+ATM)");
        Match matchRepStart = null;
        Match matchTransaction = null;

        Regex regexReplenishEnd = new Regex(@"(\d+:\d+:\d+[ ]+CASH[ ]*COUNTERS[\w ]+SOP)|(SERVICEMODE[ ]*LEFT)");
        Match matchReplenishEnd = null;

        int MaxCountBackLoopProccesing = int.Parse(ConfigurationManager.AppSettings["MaxBackLoopProccessingForEJ"] != null ? ConfigurationManager.AppSettings["MaxBackLoopProccessingForEJ"] : "25");

        Regex regexMachineStart = new Regex(@"APPLICATION[ ]*STARTED");
        Match matchMachineStart = null;
        #endregion

        //Default value is 15 min if it is not defined in app.config
        int ThreadWaitTimeToAbortInMin = System.Configuration.ConfigurationManager.AppSettings["ThreadWaitTimeToAbortInMin"] != null ? int.Parse(System.Configuration.ConfigurationManager.AppSettings["ThreadWaitTimeToAbortInMin"]) : 15;
        //EncodingUsedInEJ
        string _Encoding = System.Configuration.ConfigurationManager.AppSettings["EncodingUsedInEJ"] != null ? System.Configuration.ConfigurationManager.AppSettings["EncodingUsedInEJ"] : "";

        bool checkEjDataForAlert = System.Configuration.ConfigurationManager.AppSettings["checkEjDataForAlert"] != null ? bool.Parse(System.Configuration.ConfigurationManager.AppSettings["checkEjDataForAlert"]) : false;

        int EJnotDownloadedForHours = System.Configuration.ConfigurationManager.AppSettings["EJnotDownloadedForHours"] != null ? int.Parse(System.Configuration.ConfigurationManager.AppSettings["EJnotDownloadedForHours"]) : 8;

        #region MultipleThreadingLogic
        List<ThreadStatus> listThreadStatus = new List<ThreadStatus>();
        #endregion


        string enableWithdrawalParsing = System.Configuration.ConfigurationManager.AppSettings["EnableWithdrawalParsing"];
        string enableDepositParsing = System.Configuration.ConfigurationManager.AppSettings["EnableDepositParsing"];

        public Service1()
        {
            InitializeComponent();
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
        //            LogableTask.LogMonoActivityTask("ExecuteQueue", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, "EjParser Queue do not exist");
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("CCMSEJPARSER - ExecuteQueue", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
        //        LogableTask.LogMonoActivityTask("ExecuteQueue", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //    }
        //}

        //private async void SendRequestToUI()
        //{
        //    ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
        //    string url = ConfigurationManager.AppSettings["View360Url"];
        //    WebRequest request = WebRequest.Create(url);
        //    using (WebResponse response = await request.GetResponseAsync())
        //    {
        //        // Process the response if needed
        //    }
        //    ServicePointManager.ServerCertificateValidationCallback = null;
        //}      

        //private async void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        //{
        //    try
        //    {
        //        Message message = queue.EndReceive(e.AsyncResult);
        //        message.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
        //        FileDetail fileDetail = JsonConvert.DeserializeObject<FileDetail>(message.Body.ToString());

        //        Atm atm = Atm.LoadAtm(" IP = '" + fileDetail.atmIp + "'");

        //        string respone = ParseDataForMessageBus(fileDetail.fileContent, fileDetail.atmIp, atm.ATMId);
        //        if (respone == "success")
        //        {
        //            _ = System.Threading.Tasks.Task.Run(() => SendRequestToUI());
        //            _ = System.Threading.Tasks.Task.Run(() => File.Delete(fileDetail.fileName));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogableTask.LogMonoActivityTask("Queue_ReceiveCompleted", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            queue.BeginReceive();
        //        }
        //        catch (Exception ex)
        //        {
        //            LogableTask.LogMonoActivityTask("Queue_ReceiveCompleted", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //        }
        //    }
        //}

        void ScheduleThreadForExecution(object state)
        {
            try
            {
                string connectionStr = Encryption.Cryptic.DecryptString((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", ""), Helper.ConstractKey(false));

                ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Core);
                ConnectionFactory.Initialize(connectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);
                ConnectionFactory.Initialize(connectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);

                

                appSettings = AppSetting.LoadAppSetting("1=1");
                appSettings.HoldOtherDfTasks = false;
                appSettings.Save();
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\CCMSEJParser{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : CCMSEJParser 2.0.0.1, Modified Date 29-Apr-2015");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");

                LogableTask.LogMonoActivityTask("EJParser", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to change Task's status to FileDownloaded");

                //timer = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                timer = new Timer(DoWork, null, new TimeSpan(0, 0, 5), new TimeSpan(0, 0, 0, 0, -1));
                
                //ExecuteQueue(); related to MSMQ..


                EventLog.WriteEntry("CCMSEJPARSER", "Service Started Successfully", EventLogEntryType.Information);

            }
            catch (Exception ex)
            {
                //trying to log error in event log if its not full.
                try
                {
                    EventLog.WriteEntry("CCMSEJPARSER", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                    if (appSettings != null)
                        timerScheduleThreadForExecution.Change(new TimeSpan(0, 0, appSettings.CcmsParserRefreshInterval.Value), new TimeSpan(0, 0, 0, 0, -1));
                    else
                        timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
                }
                catch (Exception innerException)
                {
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));
            //timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0, 0, -1));
            //EventLog.WriteEntry("CCMSEJPARSER", "Thread schedular sent startup request", EventLogEntryType.Information);
        }

        private byte[] GetUnzippedBytes(byte[] ejData)
        {
            MemoryStream memStream = new MemoryStream(ejData, false);
            ZipInputStream zipStream = new ZipInputStream(memStream);
            if (appSettings.EjParserZipPassword != "")
            {
                zipStream.Password = appSettings.EjParserZipPassword;
                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "zip password set");
            }

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

        private void ParseTxData(object messageProcessorId)
        {
            List<long> failedTaskATMIds = new List<long>();

            LogableTask task = LogableTask.NewTask("ParseCashData");
            SqlConnection conn = null;
            Parser parser = new Parser();
            SqlConnection cashDataConnection = null;
            bool isCashDataConnectionOpened = false;
            SqlCommand cmd = null;

            try
            {
                conn = ConnectionFactory.GetNewConnection(DatabaseName.Tx);
                SqlCommand cmdDb = conn.CreateCommand();
                cmdDb.CommandText = "FetchEjTask";
                LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), TraceLevel.Info, "command timeout set to 300");
                cmdDb.CommandTimeout = 300;


                cmdDb.Parameters.Add("messageProcessorID", SqlDbType.Int);
                cmdDb.Parameters[0].Value = messageProcessorId;


                cmdDb.Parameters.Add("processingOrder", SqlDbType.VarChar);
                cmdDb.Parameters[1].Value = "asc";//(shortestJobProcessingEnabled == "1" ? "unzipped_file_size" : "creation_time");


                cmdDb.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapterTask = new SqlDataAdapter(cmdDb);
                DataTable dt = new DataTable();
                adapterTask.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                    if (!isCashDataConnectionOpened)
                    {
                        cashDataConnection = ConnectionFactory.GetNewConnection(DatabaseName.Tx);
                        cashDataConnection.Open();
                        cmd = cashDataConnection.CreateCommand();
                        conn.Open();
                        isCashDataConnectionOpened = true;
                    }

                    ServicesDAL.Task dbTask = ServicesDAL.Task.LoadTask("task_id= " + long.Parse(dr[0].ToString()), DatabaseName.Tx);
                    int taskTypeId = int.Parse(dr[1].ToString());
                    string ejString = null;
                    LogableTask parseCashDataTask = null;
                    SqlTransaction dbTrx = null;
                    if (dbTask.RetryRemaining > 0)
                        dbTask.RetryRemaining--;
                    try
                    {

                        parseCashDataTask = LogableTask.NewTask("Parse Counter File, TaskId=" + dbTask.TaskId);


                        LogableTask.LogMonoActivityTask("Parse EJ", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Parse EJ Data, TaskId=" + dbTask.TaskId);

                        dbTask.LastInvoked = DateTime.Now;
                        dbTask.Status = DownloadStates.downloadedParsing.ToString();
                        dbTask.Save(DatabaseName.Tx);

                        cashDataConnection.ChangeDatabase("CashDataStore_" + dbTask.CreationTime.Year.ToString());
                        if (taskTypeId == 1)
                        {
                            StringBuilder builder = new StringBuilder();
                            cmd.CommandText = "select convert(varchar(MAX),Tx_data_file) from TxDataTasks where task_id =" + dbTask.TaskId + " order by file_creation_time, seq";
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dtCashDataFiles = new DataTable();
                            adapter.Fill(dtCashDataFiles);

                            foreach (DataRow drCashDataFiles in dtCashDataFiles.Rows)
                            {
                                builder.Append(drCashDataFiles[0].ToString().Replace("\0", ""));
                            }

                            ejString = builder.ToString();
                        }
                        else
                        {
                            if (!failedTaskATMIds.Contains(dbTask.ATMId))
                            {
                                if (dbTask.FileTypeId == 2)
                                {
                                    LogableTask.LogMonoActivityTask("Merging EJ", MethodBase.GetCurrentMethod(), TraceLevel.Info, "File Type id : " + dbTask.FileTypeId + " for task id: " + dbTask.TaskId);
                                    cashDataConnection.ChangeDatabase("CashDataStore_" + dbTask.CreationTime.Year.ToString());

                                    byte[] ejData = null;
                                    object lastProcessedTaskID = null;

                                    if (dbTask.TaskInfo != null)
                                    {
                                        lastProcessedTaskID = dbTask.TaskInfo;
                                        if (lastProcessedTaskID != null && lastProcessedTaskID != DBNull.Value && lastProcessedTaskID.ToString() != dbTask.TaskId.ToString())
                                        {
                                            cmd.CommandText = "select cash_data_file from cashDataFiles where task_id =" + int.Parse(lastProcessedTaskID.ToString());
                                            ejData = (byte[])cmd.ExecuteScalar();

                                            if (ejData == null)
                                                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "last downloaded ej file is missing");
                                            else
                                                ejString = HandlingEncoding(ejData);

                                        }
                                    }
                                    cmd.CommandText = "select cash_data_file from cashDataFiles where task_id =" + dbTask.TaskId;
                                    ejData = (byte[])cmd.ExecuteScalar();
                                    if (ejData == null)
                                        throw new Exception("no data found in the CashDataStore for task_id = " + dbTask.TaskId);
                                    ejString += HandlingEncoding(ejData);
                                }
                                else
                                    throw new Exception("Parsing not supported for file Type :" + dbTask.FileTypeId);

                            }
                            else
                                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "parent task is not completed for task id:" + dbTask.TaskId);

                        }

                        cmd.CommandType = CommandType.Text;



                        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

                        ejString = formattingChars.Replace(ejString, "");

                        //parse replenishments
                        LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "EJ Formatted");
                        ReplenishmentExtractor replenishmentExtractor = new ReplenishmentExtractor();
                        replenishmentExtractor.ParseAndSaveReplenishment(ref ejString, dbTask, parseCashDataTask);
                        LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Normal Rep extratced for Task Id: " + dbTask.TaskId);



                        //parse transactions (Withdrawal)
                        if (enableWithdrawalParsing == "1")
                        {
                            Parser ejParser = new Parser();
                            ejParser.ParseAndSaveEJ(ref ejString, dbTask, parseCashDataTask);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Normal trxn extratced for Task Id: " + dbTask.TaskId);

                        }

                        if (enableDepositParsing == "1")
                        {
                            //parse BNA transactions (Deposite)
                            BNAParser BNAParser = new BNAParser();
                            BNAParser.ParseAndSaveEJ(ref ejString, dbTask, parseCashDataTask);
                            LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Dep extratced for Task Id: " + dbTask.TaskId);
                        }


                        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

                        dbTask.Status = DownloadStates.completed.ToString();
                        dbTask.FailureReason = string.Empty;
                        dbTask.Parsed = true;
                        dbTask.Save(DatabaseName.Tx);

                    }
                    catch (Exception ex1)
                    {
                        if (mergeLastDownloadedEjEnabled)
                            failedTaskATMIds.Add(dbTask.ATMId);

                        if (dbTrx != null)
                            dbTrx.Rollback();


                        dbTask.Parsed = false;

                        if (!dbTask.FailedToParseCount.HasValue)
                            dbTask.FailedToParseCount = 0;

                        if (!appSettings.FailedToParseThreshold.HasValue)
                            appSettings.FailedToParseThreshold = 3;

                        if (dbTask.FailedToParseCount < appSettings.FailedToParseThreshold)
                        {
                            dbTask.FailedToParseCount++;
                            dbTask.Status = DownloadStates.downloadedParsePending.ToString();
                        }
                        else
                        {
                            dbTask.Status = DownloadStates.parsingFailed.ToString();
                        }

                        dbTask.FailureReason += " " + ex1.Message;
                        dbTask.FailureReason = (dbTask.FailureReason.Length > 512) ? dbTask.FailureReason.Substring(0, 511) : dbTask.FailureReason;
                        dbTask.FailureReason = dbTask.FailureReason.Replace("'", "''");
                        dbTask.Save(DatabaseName.Tx);
                        parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex1);

                    }
                    finally
                    {
                        parseCashDataTask.EndTask();
                    }
                }
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
                failedTaskATMIds.Clear();

                task.EndTask();
                //msgProc.Remove((int)messageProcessorId);
                lock (listThreadStatus)
                {
                    ThreadStatus result = listThreadStatus.Find(x => x.MessageProcessorId == Convert.ToInt16(messageProcessorId));
                    if (result != null)
                        listThreadStatus.Remove(result);
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

        // this is disabled..
        public string ParseDataForMessageBus(string ejString, string atmIp, long atmId)
        {
            string response = string.Empty;
            LogableTask parseCashDataTask = LogableTask.NewTask("ParseTxDataForMessageBus");
            Task dbTask = new Task();
            try
            {
                string connectionStr = GetConnectionByAtmIp(atmIp);
                ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Core);
                ConnectionFactory.Initialize(connectionStr.Replace("Core", "Tx"), true, DatabaseName.Tx);
                ConnectionFactory.Initialize(connectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);

                dbTask.ATMId = atmId;
                dbTask.TaskId = -1;
                ejString = formattingChars.Replace(ejString, "");

                //parse replenishments
                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "EJ Formatted");
                ReplenishmentExtractor replenishmentExtractor = new ReplenishmentExtractor();
                replenishmentExtractor.ParseAndSaveReplenishment(ref ejString, dbTask, parseCashDataTask);
                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Normal Rep extratced for Task Id: " + dbTask.TaskId);

                //parse transactions (Withdrawal)
                Parser ejParser = new Parser();
                string withResponse = ejParser.ParseAndSaveEJ(ref ejString, dbTask, parseCashDataTask);
                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Normal trxn extratced for Task Id: " + dbTask.TaskId);

                //parse BNA transactions (Deposite)
                BNAParser BNAParser = new BNAParser();
                string bnaResponse = BNAParser.ParseAndSaveEJ(ref ejString, dbTask, parseCashDataTask);
                LogableTask.LogMonoActivityTask("Extracting ej from db", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Dep extratced for Task Id: " + dbTask.TaskId);
                
                if (withResponse == "success" && bnaResponse == "success")
                    response = "success";
                else
                    response = "error";
            }
            catch (Exception ex)
            {
                response = ex.Message;
                parseCashDataTask.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            return response;
        }

        void DoWork(object state)
        {
            timer.Change(-1, -1);
            SqlCommand cmd = null;
            LogableTask task = LogableTask.NewTask("DoWork");
            List<Thread> threads = new List<Thread>();
            int maxProcessorIndex = 0;
            bool oneTimeChk = false;

            try
            {
                try
                {
                    LogableTask.DefaultTraceLevel = (TraceLevel)Enum.Parse(typeof(TraceLevel), appSettings.ServiceLogLevel);
                }
                catch
                {
                    LogableTask.DefaultTraceLevel = TraceLevel.Info;
                    LogableTask.LogMonoActivityTask("GetTraceLevel", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Failed to extract trace level from database");
                }


                if (appSettings.ParsingEnabled)
                {
                    DateTime dtStart = DateTime.Now;

                    LogableTask.LogMonoActivityTask("Threads Creation", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Creating threads to start parsing");

                    for (int i = 0; i < maxProcessor; i++)
                    {
                        ThreadStatus result = listThreadStatus.Find(x => x.MessageProcessorId == i + 1);
                        if (result == null)
                        {
                            maxProcessorIndex = i + 1;

                            LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Thread Created for message processor Id = " + maxProcessorIndex);

                            ThreadStatus threadStatus = new ThreadStatus();
                            threadStatus.thread = new Thread(ParseTxData);
                            threadStatus.thread.Start(maxProcessorIndex);
                            threadStatus.ThreadStartTime = DateTime.Now;
                            threadStatus.MessageProcessorId = maxProcessorIndex;
                            listThreadStatus.Add(threadStatus);
                        }
                        else
                        {
                            if (DateTime.Now.Subtract(result.ThreadStartTime).TotalMinutes > ThreadWaitTimeToAbortInMin)
                            {
                                LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Stuck so aborting this thread after " + ThreadWaitTimeToAbortInMin.ToString() + " minutes.");
                                listThreadStatus.Remove(result);
                                result.thread.Abort();
                            }
                            else
                                LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Thread for Message Processor Id: " + result.MessageProcessorId + " already in process. No new thread executed.");
                        }
                    }
                }
                else
                    LogableTask.LogMonoActivityTask("Parsing", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Parsing is turned off");

            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                try
                {

                    if (appSettings.HoldOtherDfTasks && oneTimeChk)
                    {
                        appSettings.HoldOtherDfTasks = false;
                        appSettings.Save();
                        LogableTask.LogMonoActivityTask("GenerateDFF", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "HoldOtherDfTasks=false;");

                    }
                    else
                        LogableTask.LogMonoActivityTask("GenerateDFF", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "HoldOtherDfTasks=not set to false;");


                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Wake up after " + appSettings.CcmsParserRefreshInterval + " sec");
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
                    timer.Change(new TimeSpan(0, appSettings.CcmsParserRefreshInterval.Value, 0), new TimeSpan(0, 0, 0, 0, -1));
                }

            }

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

        bool IsReplenishmentEndExtracted(string ejData, out int repEndInndex)
        {
            matchReplenishEnd = regexReplenishEnd.Match(ejData);
            repEndInndex = matchReplenishEnd.Index;
            return matchReplenishEnd.Success;
        }

        bool IsReplenishmentExtracted(string ejData, int repEndIndex)
        {
            bool lReturn = false;

            matchRepStart = regexRepStart.Match(ejData);
            matchTransaction = regexTransaction.Match(ejData);
            matchMachineStart = regexMachineStart.Match(ejData);
            lReturn = (matchRepStart.Success && (matchRepStart.Index < repEndIndex) && (!matchMachineStart.Success || matchMachineStart.Index > matchRepStart.Index)) || (matchTransaction.Success && matchTransaction.Index < repEndIndex);
            return lReturn;
        }

        private string HandlingEncoding(byte[] ejData)
        {
            string lFileContent = "";

            switch (_Encoding)
            {
                case "ASCII":
                    lFileContent = Encoding.ASCII.GetString(GetUnzippedBytes(ejData));
                    break;
                case "Unicode":
                case "Unicode_le_bom":
                    lFileContent = Encoding.Unicode.GetString(GetUnzippedBytes(ejData));
                    break;
                case "UTF8":
                    lFileContent = Encoding.UTF8.GetString(GetUnzippedBytes(ejData));
                    break;
                case "UTF7":
                    lFileContent = Encoding.UTF7.GetString(GetUnzippedBytes(ejData));
                    break;
                default:
                    lFileContent = Encoding.UTF8.GetString(GetUnzippedBytes(ejData));
                    break;
            }
            return lFileContent;
        }
    }
}
