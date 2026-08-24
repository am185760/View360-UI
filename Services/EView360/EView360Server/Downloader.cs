using ServicesDAL;
using System;
//using ICSharpCode.SharpZipLib.Checksums;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Avanza.CCMS
{
    public class Downloader
    {
        DatabaseName dbName;
        private TcpClient _client;
        private SslStream _sslStream;
        Socket soc;
        LogableTask task;
        public DateTime requestInitiatedAT;
        public DateTime connectedAT;
        public Thread currentThread;
        string version = "CCMS";
        ServicesDAL.Task downloadTask;
        byte[] buff = new byte[2048];
        Atm atm;
        private bool _isSsl;
        private bool _listen;
        public static bool isIblEj = (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["isIblEj"]) && System.Configuration.ConfigurationManager.AppSettings["isIblEj"] == "1") ? true : false;
        public static string fileDateFormat = System.Configuration.ConfigurationManager.AppSettings["fileDateFormat"];

        private Downloader() { }
        public Downloader(ServicesDAL.Task downloadTask)
        {
            this.downloadTask = downloadTask;
            task = LogableTask.NewTask("Download");
            atm = Atm.LoadAtmByPk(downloadTask.ATMId);
        }

        #region Edited By: Syed Ali Mesam Title: Adding New Constructor for Listener

        public Downloader(ServicesDAL.Task downloadTask, Atm _atm, bool listen, Socket SOC)
        {
            this.downloadTask = downloadTask;
            task = LogableTask.NewTask("Download");
            atm = _atm;// Atm.LoadAtmByPk(downloadTask.ATMId);
            _listen = listen;
            soc = SOC;
            connectedAT = DateTime.Now;
        }

        public Downloader(ServicesDAL.Task downloadTask, Atm _atm, bool listen, TcpClient tcpClient, SslStream sslStream, bool isSsl)
        {
            this.downloadTask = downloadTask;
            task = LogableTask.NewTask("Download");
            atm = _atm;// Atm.LoadAtmByPk(downloadTask.ATMId);
            _listen = listen;
            _client = tcpClient;
            _sslStream = sslStream;
            _isSsl = isSsl;
            connectedAT = DateTime.Now;
        }

        #endregion Edited By: Syed Ali Mesam Title: Adding New Constructor for Listener


        public string ATMIP
        {
            get
            {
                if (atm == null)
                    throw new Exception("atm is null");
                else
                    return atm.IP;
            }
        }

        public bool Start(DatabaseName _dbName)
        {
            try
            {
                dbName = _dbName;
                soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                downloadTask.LastInvoked = DateTime.Now;
                if (downloadTask.Status == DownloadStates.scheduled.ToString())
                    downloadTask.Status = DownloadStates.initiating.ToString();
                downloadTask.Save(dbName);
                soc.ReceiveTimeout = 20000;

                LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                string.Format("Downloading request initiated for terminal {0}", this.atm.IP));

                soc.BeginConnect(atm.IP, (int)atm.Port, OnConnected, null);
            }
            catch (Exception ex)
            {
                lock (EView360Server.ActiveDownloads)
                {
                    EView360Server.ActiveDownloads.Remove(this);
                }
                return false;//throw;
            }
            return true;
        }

        void OnConnected(IAsyncResult arg)
        {
            try
            {
                LogableTask.LogMonoActivityTask("PerformDownload", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                string.Format("Callback executed for Terminal {0} ", this.atm.IP));

                currentThread = Thread.CurrentThread;
                soc.EndConnect(arg);
                //AlertManager.GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.TCPConnectionUp, null, AlertStatus.Up,Event_Type.Information);
                connectedAT = DateTime.Now;
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, this.atm.IP + " Connected.");
                LogableTask.LogMonoActivityTask("PerformDownload", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                string.Format("Terminal {0} connected", this.atm.IP));

            }
            catch
            {
                try
                {
                    // AlertManager.GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.TCPConnectionDown, null, AlertStatus.Down,Event_Type.Event);
                    lock (EView360Server.ActiveDownloads)
                    {
                        EView360Server.ActiveDownloads.Remove(this);
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "atm out ip :" + this.ATMIP);

                    }
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "Error while connecting to " + this.atm.IP);
                    downloadTask.Status = DownloadStates.downloadingDisconnected.ToString();
                    downloadTask.FailureReason = "Can not connect to " + this.atm.IP;

                    //if (downloadTask.RetryRemaining < 1)
                    //{
                    //    AlertManager.RaiseAlert((int)EnumAlertType.ATMCashLevelFileDownloadFailed, null, this.atm.ATMId, "Downloader",null,null);
                    //    downloadTask.Status = DownloadStates.retriesExhausted.ToString();
                    //    downloadTask.FailureReason = "Max retries exceeded. Can not connect to " + this.atm.IP;
                    //}
                    //else
                    //{

                    //    downloadTask.RetryRemaining = (byte)(downloadTask.RetryRemaining - 1);
                    //}
                    downloadTask.Save(dbName);
                    task.EndTask();
                    return;
                }
                catch (Exception exception)
                {
                    EventLog.WriteEntry("CurrencyMngServer", "Error in OnConnected() first catch block. detail: " + exception.Message + exception.StackTrace, EventLogEntryType.Error);
                }
            }

            try
            {
                if (downloadTask.RetryRemaining == 0)
                {
                    throw new Exception("task with retry count zero detected");
                }

                downloadTask.RetryRemaining = (byte)(downloadTask.RetryRemaining - 1);

                downloadTask.Save(dbName);
                LogableTask.LogMonoActivityTask("PerformDownload", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                string.Format("Going to receive version from terminal {0} ", this.atm.IP));
                version = ReceiveString();


                LoadAndDownload();

                //Changed on 12/10/2015 as observed issue in AJMAN BANK.
                //*   Cannot access a disposed object.Object name: 'System.Net.Sockets.Socket'.
                //LoadAndDownload();



            }
            catch (Exception ex)
            {
                try
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "ip =" + atm.IP + "Error while status " + downloadTask.Status.ToString());
                    //                    AlertManager.RaiseTCPAlertIfNeeded(AlertStatus.Down, this.atm.ATMId.Value, AlertMessages.failureMsg + " " + ex.Message, (int)EnumAlertType.TCPCashOrderDownload);
                    //if (ex.Message.StartsWith("error=Empty"))
                    //   task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
                    //else
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

                    if (ex.Message.Replace("'", "''").Length > 256)
                        downloadTask.FailureReason = ex.Message.Replace("'", "''").Substring(0, 256);
                    else
                        downloadTask.FailureReason = ex.Message.Replace("'", "''");

                    if (downloadTask.FailureReason.Contains("file is empty") || downloadTask.FailureReason.Contains("error=Unable to copy file") || downloadTask.FailureReason.Contains("error=Unable to move file") || downloadTask.FailureReason.Contains("does not matched"))
                    {
                        downloadTask.FailureReason = "File does not exists at terminal";
                        downloadTask.RetryRemaining = (byte)0;
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Retry count set");

                        //downloadTask.Status = DownloadStates.failed.ToString();
                    }
                    else if (downloadTask.FailureReason.Contains("error=There is no change in file") || downloadTask.FailureReason.Contains("cannot download today file"))
                        downloadTask.RetryRemaining = (byte)0;
                    //    if (ex is SocketException)
                    //   {
                    else if (downloadTask.FailureReason.Contains("error=Latest archive file is already downloaded")
                        || downloadTask.FailureReason.Contains("error=Backup folder is empty"))
                        downloadTask.RetryRemaining = (byte)0;



                    if (downloadTask.RetryRemaining == 0)
                    {
                        downloadTask.Status = DownloadStates.retriesExhausted.ToString();
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "status set to retries exhausted");



                        //AlertManager.GenerateCCMSEvent(
                        //EventType.ATMAgentLogNotDownloaded.ToString(),
                        //EventType.ATMAgentLogNotDownloaded.ToString(),
                        //Event_Type.Warning.ToString(),
                        //atm.ATMId.ToString(),
                        //EntityType.ATM.ToString(),
                        //Actors.ATM.ToString(),
                        //Actors.CCMS.ToString(),
                        //null);

                        // downloadTask.FailureReason = "Max retries exceeded. Can not connect to " + this.atm.IP;
                    }
                    else
                    {
                        downloadTask.Status = DownloadStates.downloadingDisconnected.ToString();
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "status set to downloading disconnected");
                    }




                    //    if (downloadTask.Status == DownloadStates.initiating.ToString())
                    //        downloadTask.Status = DownloadStates.unknownError.ToString();
                    //    else if (downloadTask.Status == DownloadStates.nameReceived.ToString())
                    //    {
                    //    }
                    //    else
                    //        downloadTask.Status = DownloadStates.downloadingDisconnected.ToString();
                    //
                    // }
                    //else
                    //   downloadTask.Status = DownloadStates.unknownError.ToString();

                    // total time is time - (1900/1/1) , initial DownloadTime with (1900/1/1)
                    downloadTask.DownloadTime = downloadTask.DownloadTime.Value + (DateTime.Now - connectedAT);
                    //downloadTask.RetryRemaining = (byte)(downloadTask.RetryRemaining - 1);
                    downloadTask.Save(dbName);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "task saved");

                    //Change done as CPU Utilization reaches to 100% in Alinma in case of timeout.
                    if (System.Configuration.ConfigurationManager.AppSettings["socClosedOnTimeout"] == "1")
                    {
                        if (this.soc.Connected)
                            this.soc.Close();
                    }
                    else
                    {
                        soc = null;
                    }


                }
                catch (Exception exception)
                {
                    EventLog.WriteEntry("CurrencyMngServer", "Error in OnConnected() second catch block. detail: " + exception.Message + exception.StackTrace, EventLogEntryType.Error);
                }
            }
            finally
            {
                try
                {
                    lock (EView360Server.ActiveDownloads)
                    {
                        EView360Server.ActiveDownloads.Remove(this);
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "atm out ip :" + this.ATMIP);
                    }
                    task.EndTask();

                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("CurrencyMngServer", "Error in OnConnected() finally  block. detail: " + ex.Message + ex.StackTrace, EventLogEntryType.Error);
                }

            }
        }

        public void LoadAndDownload()
        {
            downloadTask.LastInvoked = DateTime.Now;
            bool fileAlreadyTransferred = false;
            FileType fileType = FileType.LoadFileTypeByPk(downloadTask.FileTypeId.Value);

            // if it is not zipped yet



            if (downloadTask.Status == DownloadStates.initiating.ToString()
                 || (downloadTask.Status == DownloadStates.downloadingDisconnected.ToString() && downloadTask.FilePathAtATM == null))
            {
                // LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                // string.Format("Requesting file name for terminal{0}", this.atm.IP));
                GetFileName(fileType);
            }




            if (downloadTask.Status == DownloadStates.nameReceived.ToString() ||
                (downloadTask.Status == DownloadStates.downloadingDisconnected.ToString() && downloadTask.ZippedFileSize == null))
            {
                //   LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                //  string.Format("Requesting file size for terminal{0}", this.atm.IP));
                GetFileSize(fileType.FileTypeId);

            }



            if (downloadTask.Status == DownloadStates.sizeReceived.ToString()
                    || downloadTask.Status == DownloadStates.downloading.ToString()
                    || downloadTask.Status == DownloadStates.downloadingDisconnected.ToString())
            {
                if (downloadTask.BytesTransferred == downloadTask.ZippedFileSize)
                {
                    fileAlreadyTransferred = true;
                    SendString("quit;");
                    //downloadTask.Status = DownloadStates.downloadedParsePending.ToString();
                    //downloadTask.FailureReason = string.Empty;
                    //downloadTask.EndTime = DateTime.Now;
                    //downloadTask.Save();
                }
                else
                {
                    //   LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                    //string.Format("Request for download terminal{0}", this.atm.IP));
                    DownloadFile();
                }
            }

            this.soc.Shutdown(SocketShutdown.Both);
            this.soc.Close(1000);   // hopfully this is in milli secs

            //if (fileType.IsEJLog)
            //{
            //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to save ej in database");
            //    // to do use encription for connection string

            //    string EJStoreName = "CashDataStore_" + downloadTask.CreationTime.Year.ToString();

            //    if (CurrencyMngServer.keepOneCashDataStoreName.Length == 0)
            //        VerifyEJStore(EJStoreName.ToLower());
            //    else
            //        EJStoreName = CurrencyMngServer.keepOneCashDataStoreName;

            //    SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            //    cmd.Connection.Open();
            //    cmd.Connection.ChangeDatabase(EJStoreName);
            //    if (fileAlreadyTransferred)
            //    {
            //        if (!File.Exists(downloadTask.ServerFilepath))
            //        {
            //            //Check  it in the database
            //            cmd.CommandText = "select count(task_id) from cashdatafiles where task_id =" + downloadTask.TaskId;
            //            if ((int)cmd.ExecuteScalar() > 0)
            //            {
            //                //File Already Saved to database.
            //                downloadTask.Status = DownloadStates.downloadedParsePending.ToString();
            //                downloadTask.FailureReason = string.Empty;
            //                downloadTask.Save();


            //            }
            //            else
            //            {
            //                //not in file system & database..
            //                downloadTask.Status = DownloadStates.unknownError.ToString();
            //                downloadTask.Save();


            //            }
            //        }
            //        else
            //        {
            //            cmd.CommandText = "insert into CashDataFiles (task_id, cash_data_file) values(" + downloadTask.TaskId + ",@ej_file)";
            //            cmd.Parameters.Add("@ej_file", System.Data.SqlDbType.Binary);
            //            cmd.Parameters[0].Value = File.ReadAllBytes(downloadTask.ServerFilepath);
            //            cmd.ExecuteNonQuery();
            //            cmd.Connection.Close();
            //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "file saved");
            //            File.Delete(downloadTask.ServerFilepath);
            //            downloadTask.Status = DownloadStates.downloadedParsePending.ToString();
            //            downloadTask.Save();

            //        }
            //    }

            //    else
            //    {
            //        cmd.CommandText = "insert into CashDataFiles (task_id, cash_data_file) values(" + downloadTask.TaskId + ",@ej_file)";
            //        cmd.Parameters.Add("@ej_file", System.Data.SqlDbType.Binary);
            //        cmd.Parameters[0].Value = File.ReadAllBytes(downloadTask.ServerFilepath);
            //        cmd.ExecuteNonQuery();    
            //        cmd.Connection.Close();
            //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "file saved");
            //        File.Delete(downloadTask.ServerFilepath);
            //        downloadTask.Status = DownloadStates.downloadedParsePending.ToString();
            //        downloadTask.RetryRemaining = (byte)atm.RetryCountCounterFile;
            //        downloadTask.Save();

            //    }

            //    if (fileType.FileTypeId == 10)
            //        downloadTask.ServerFilepath = ((DateTime)atm.LastWincorSent).ToString("yyyyMMdd") + ".jrn;";
            //    else
            //        downloadTask.ServerFilepath = null;


            //}
            //else
            //{
            //    if (!Directory.Exists(CurrencyMngServer.appSettings.DownloadedFilePath + "\\" + downloadTask.ATMId))
            //        Directory.CreateDirectory(CurrencyMngServer.appSettings.DownloadedFilePath + "\\" + downloadTask.ATMId);
            //    string newFilePath = CurrencyMngServer.appSettings.DownloadedFilePath + "\\" + downloadTask.ATMId + "\\" +
            //       Path.GetFileName(downloadTask.ServerFilepath);
            //    File.Move(downloadTask.ServerFilepath, newFilePath);
            //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "file moved");
            //    downloadTask.ServerFilepath = newFilePath;
            //    downloadTask.FailureReason = "";
            //    if (fileType.FileTypeId == 3 || fileType.FileTypeId == 5 || fileType.FileTypeId == 13 || fileType.FileTypeId == 14 || fileType.FileTypeId == 15)
            //        downloadTask.Status = DownloadStates.downloadedParsePending.ToString();
            //    else
            //        downloadTask.Status = DownloadStates.completed.ToString();
            //}

            downloadTask.EndTime = DateTime.Now;
            downloadTask.DownloadTime = downloadTask.DownloadTime.Value + (DateTime.Now - connectedAT);

            downloadTask.Save(dbName);

            setAtmStats(ref downloadTask);

            //if (downloadTask.CreatedBy == 1)
            //    AlertManager.GenerateCCMSEvent(EventType.ManualATMAgentLogDownloaded.ToString(),
            //        EventType.ManualATMAgentLogDownloaded.ToString(), Event_Type.Alert.ToString(), downloadTask.ATMId.ToString(),
            //         EntityType.ATM.ToString(), Actors.NCR.ToString(), Actors.NCR.ToString(), null);

        }

        private void DownloadFile()
        {
            LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
            string.Format("start send file started for terminal{0}", this.atm.IP));

            SendString("start-send file=" + downloadTask.FilePathAtATM + ";from=" + downloadTask.BytesTransferred + ";");
            string startSendReply = ReceiveString();
            if (!startSendReply.StartsWith("ready;"))
                throw new Exception(startSendReply);
            //LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
            //string.Format("Going to send start-now for terminal{0}", this.atm.IP));

            SendString("start-now;");
            //AppSetting appSetting = AppSetting.LoadAppSetting("1=1");
            //string EJStoreName = "CashDataStore_" + downloadTask.CreationTime.Year.ToString();
            downloadTask.ServerFilepath = EView360Server.appSettings.TemporaryFolder + "\\" + downloadTask.FilePathAtATM + "_" + atm.ATMId;

            FileStream fileStream = null;
            try
            {


                fileStream = new FileStream(downloadTask.ServerFilepath, FileMode.OpenOrCreate, FileAccess.Write);
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Added on 08/11/2018 to suport passive DR.
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (fileStream.Length == 0)
                    fileStream.Position = 0;
                else
                    fileStream.Position = (int)downloadTask.BytesTransferred; // start broken  download
                downloadTask.LastInvoked = DateTime.Now;

                if (downloadTask.Status == DownloadStates.downloadingDisconnected.ToString())
                    downloadTask.Status = DownloadStates.resumedDownloading.ToString();
                else
                    downloadTask.Status = DownloadStates.downloading.ToString();

                byte[] buffer = new byte[10240];

                //LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                //string.Format("file retrieval started for terminal{0}", this.atm.IP));

                int length = 0;
                while (downloadTask.BytesTransferred < downloadTask.ZippedFileSize)
                {
                    if (soc != null)
                        length = this.soc.Receive(buffer, buffer.Length, SocketFlags.None);
                    else
                        length = _sslStream.Read(buffer, 0, buffer.Length);
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Changes done on 18/10/2016 by IK to resolve infinite loop issue.
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (length == 0)
                    {
                        //Changes done on 20/10/2016 by IK to resolve corrupt file issue.
                        downloadTask.BytesTransferred = 0;
                        throw new Exception(string.Format("Socket disconnected for {0}-{1}", atm.IP, atm.Title));
                    }
                    fileStream.Write(buffer, 0, length);
                    downloadTask.BytesTransferred += length;
                    if (DateTime.Now > ((DateTime)downloadTask.LastInvoked).AddMinutes(1))
                    {
                        downloadTask.LastInvoked = DateTime.Now;    // update time
                        fileStream.Flush();                             // save your data
                        downloadTask.Save(dbName);                        // update status
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                //new Exception(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

            downloadTask.FailureReason = string.Empty;
            downloadTask.Status = DownloadStates.downloadedStorePending.ToString();
            downloadTask.Save(dbName);

            LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Info,
            // string.Format("quit sent for terminal{0}", this.atm.IP));
            //Uncommnet below for normal process.This is done only for ATM360
            string.Format("file-received sent for terminal{0}", this.atm.IP));

            SendString("file-received;");
            //SendString("quit;");

            if (!_isSsl)
            {
                atm.LastStatusReply = ReceiveString();
                atm.Save();
                //Commented on 16/09 ...
                //Cannot be used as the repository folder will also contain some of the files that is already transferred on server.
                // and requestinng a file that was not transferred on time will cause registry name mismatch error in CCMSAgent.
                //try
                //{
                //    GetAndProcessPendingFilesList();
                //}
                //catch (Exception ex)
                //{
                //    LogableTask.LogMonoActivityTask("PerformDownloading", MethodBase.GetCurrentMethod(), TraceLevel.Error,
                //    ex);

                //}

                SendString("quit;");
            }
        }


        private void GetFileSize(long fileTypeID)
        {
            SendString("give-size;file-name=" + downloadTask.FilePathAtATM + ";");
            string giveSizeReply = ReceiveString();
            if (giveSizeReply.StartsWith("error="))
                throw new Exception(giveSizeReply);

            string[] parts = giveSizeReply.Split('=', ';', '|');
            downloadTask.ZippedFileSize = int.Parse(parts[1]);
            downloadTask.UnZippedFileSize = int.Parse(parts[2]);
            if (System.Configuration.ConfigurationManager.AppSettings["isSameFileSizeDownloadingProhibited"] == "1")
            {
                SqlCommand cmd = ConnectionFactory.GetNewCommand(false, DatabaseName.Cash);
                cmd.CommandText = "select top " + System.Configuration.ConfigurationManager.AppSettings["samplingSizeForProhibitedDownloads"] + " zipped_file_size from task where atm_id = " + downloadTask.ATMId + " and file_type_id = " + fileTypeID + " and (status in ('downloadedParsePending','downloadedParsing','parsingFailed','completed') or (status in ('downloading','downloadingDisconnected') and retry_remaining>0)) order by task_id desc";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Select("zipped_file_size = " + downloadTask.ZippedFileSize).Length > 0)
                    throw new Exception("error=There is no change in file.So cancelling this downloading schedule");
            }
            downloadTask.Status = DownloadStates.sizeReceived.ToString();
            downloadTask.Save(DatabaseName.Cash);
        }

        private void GetFileName(FileType fileType)
        {
            //if (fileType.FileTypeId == 13 || downloadTask.FileTypeId.Value == 15 || downloadTask.FileTypeId.Value == 19 || downloadTask.FileTypeId.Value == 20 || downloadTask.FileTypeId.Value == 21)// MDB Archives
            //    SendString("zip-" + fileType.CopyType + " file=" + downloadTask.ArchiveFilePathAtAtm + ";");
            //else if (fileType.FileTypeId == 10)// win cor 
            //    SendString("zip-" + fileType.CopyType + " file=" + fileType.PathAtATM + "\\" + ((DateTime)atm.LastWincorSent).ToString("yyyyMMdd") + ".jrn;");
            //else
            //    SendString("zip-" + fileType.CopyType + " file=" + fileType.PathAtATM + ";");

            //string zipDeleteReply = ReceiveString();
            //if (zipDeleteReply.StartsWith("error="))
            //    throw new Exception(zipDeleteReply);

            ////file-name=<name>;file-size=<n>;
            ////FilePathAtATM is file name in the upload folder
            //string[] replyParts = zipDeleteReply.Split(';', '=');
            //downloadTask.FilePathAtATM = Path.GetFileName(replyParts[1]);
            //downloadTask.Status = DownloadStates.nameReceived.ToString();
            //downloadTask.Save();

            SendString("zip-" + fileType.CopyType + " file=" + string.Format(fileType.PathAtATM, atm.Port) + ";");

            string zipDeleteReply = ReceiveString();
            if (zipDeleteReply.StartsWith("error="))
                throw new Exception(zipDeleteReply);

            //file-name=<name>;file-size=<n>;
            //FilePathAtATM is file name in the upload folder
            string[] replyParts = zipDeleteReply.Split(';', '=');
            downloadTask.FilePathAtATM = Path.GetFileName(replyParts[1]);
            downloadTask.Status = DownloadStates.nameReceived.ToString();
            downloadTask.Save(DatabaseName.Cash);

        }

        void SimpleEncrypt(ref byte[] sourceArray)
        {
            for (int counter = 0; counter < sourceArray.Length; counter++)
                sourceArray[counter] = (byte)(sourceArray[counter] - ((counter + 1) % 10));
        }

        void SimpleDecrypt(ref byte[] sourceArray)
        {
            for (int counter = 0; counter < sourceArray.Length; counter++)
                sourceArray[counter] = (byte)(sourceArray[counter] + ((counter + 1) % 10));
        }

        string ReceiveString()
        {
            var str = string.Empty;

            if (_isSsl)
            {
                // Read the message sent by the client. The client signals the end of the message
                // using the "<EOF>" marker.
                var buffer = new byte[2048];
                var messageData = new StringBuilder();
                var bytes = -1;
                //do
                //{
                // Read the client's test message.
                bytes = _sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8 in case a character spans two buffers.
                var decoder = Encoding.UTF8.GetDecoder();
                var chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                str = messageData.ToString();
                // Check for EOF or an empty message.
                //if (messageData.ToString().IndexOf("<EOF>", StringComparison.Ordinal) != -1)
                //{
                //    break;
                //}
                //} while (bytes != 0);

                //str = messageData.Replace(EndOfFileMarker, string.Empty).ToString();
            }
            else
            {
                byte[] arr = null;
                int length = this.soc.Receive(buff, buff.Length, SocketFlags.None);
                str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
                while (this.soc.Available > 0 && length > 0)
                {
                    length = soc.Receive(buff, buff.Length, SocketFlags.None);
                    str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
                    Thread.Sleep(5 * 1000);
                }

                if (!version.Contains("CCMS"))
                {
                    arr = Encoding.ASCII.GetBytes(str);
                    SimpleDecrypt(ref arr);
                    str = Encoding.ASCII.GetString(arr);
                }
            }
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "received string = " + str);
            return str;
        }

        void SendString(string stringToSend)
        {
            byte[] stringToSendInBytes = null;
            if (_isSsl)
            {
                //var message = Encoding.UTF8.GetBytes(new StringBuilder(stringToSend).Append(EndOfFileMarker).ToString());
                var message = Encoding.UTF8.GetBytes(stringToSend);
                _sslStream.Write(message);
                _sslStream.Flush();

            }
            else
            {
                stringToSendInBytes = Encoding.ASCII.GetBytes(stringToSend);
                if (!version.Contains("CCMS"))
                {
                    SimpleEncrypt(ref stringToSendInBytes);

                }
                soc.Send(stringToSendInBytes);
            }
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "sent message = " + stringToSend);

        }
        private void setAtmStats(ref ServicesDAL.Task downloadTask)
        {
            //DateTime lastTaskEndtime = DateTime.MinValue;
            if (downloadTask.TaskTypeId != 10)
            {
                if (downloadTask.FileTypeId == 2)
                {

                    object taskInfo = ConnectionFactory.ExecuteScalar("select task_id from task where atm_id = " + downloadTask.ATMId + " and end_time = (Select max(end_time) from task where file_type_id=2 and atm_id = " + downloadTask.ATMId + ") ;", dbName);
                    if (!DBNull.Value.Equals(taskInfo) && !string.IsNullOrEmpty(taskInfo.ToString()))
                    {
                        downloadTask.TaskInfo = taskInfo.ToString();
                    }
                    /*object atmstats = ConnectionFactory.ExecuteScalar("Select * from atm_stats  where atm_id = " + downloadTask.ATMId);
                    if (!DBNull.Value.Equals(atmstats) && atmstats != null && !string.IsNullOrEmpty(atmstats.ToString()))
                    {
                        object taskId = ConnectionFactory.ExecuteScalar("Select task_id from atm_stats  where atm_id = " + downloadTask.ATMId);
                        if (!DBNull.Value.Equals(taskId) && !string.IsNullOrEmpty(taskId.ToString()))
                        {
                            //downloadTask.TaskInfo = taskId.ToString();
                            object taskEndtime = ConnectionFactory.ExecuteScalar("Select max(end_time) from task where file_type_id=2 and atm_id = " + downloadTask.ATMId);
                            lastTaskEndtime = DateTime.ParseExact(taskEndtime.ToString(), "M/d/yyyy h:mm:ss tt", null);
                            if (lastTaskEndtime < downloadTask.EndTime)
                            {
                                ConnectionFactory.ExecuteQuery("update atm_stats set task_id = " + downloadTask.TaskId + "  where atm_id = " + downloadTask.ATMId + ";");
                            }
                            else
                            {
                                LogableTask.LogMonoActivityTask("Updating Task Id in Atm Stats Table", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Last End time: " + lastTaskEndtime + " is greater than Currently Processed task end time: " + downloadTask.TaskId);
                            }
                        }
                        else
                        {
                            ConnectionFactory.ExecuteQuery("update atm_stats set task_id = " + downloadTask.TaskId + "  where atm_id = " + downloadTask.ATMId + ";");
                        }

                    }
                    else
                    {
                        ConnectionFactory.ExecuteQuery("insert into atm_stats(atm_id,task_id) values ( " + downloadTask.ATMId + " ," + downloadTask.TaskId + ")");
                    }*/


                }
            }
        }



    }
}
