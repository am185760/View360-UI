
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using ServicesDAL;
namespace Avanza.CCMS
{
    public class Uploader
    {
        Socket soc;
        LogableTask task;
        //CashOrders cashOrders;
        DateTime connectedAT;
        ServicesDAL.Task uploadTask;
        byte[] buff = new byte[1024];
        Atm atm;
        string reply = null;
        string version = "CCMS";

        public Uploader(ServicesDAL.Task uploadTask)
        {
            //cashOrders = _cashOrder;
            atm = Atm.LoadAtmByPk((int)uploadTask.ATMId);
            this.uploadTask = uploadTask;
        }

        public void Start()
        {
            LogableTask taskCashOrders = LogableTask.NewTask("StartSendingCashOrders");
            try
            {
                if (atm == null)
                {
                    uploadTask.FailureReason = "ATM does not exists";
                    //LogableTask.LogMonoActivityTask("UploadConfigOrCashOrder", MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATM does not exists");
                    uploadTask.Status = UploadStates.failed.ToString();
                    uploadTask.Save(DatabaseName.Cash);
                    throw new Exception("ATM does not exists");
                }
                taskCashOrders.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Connecting to : " + atm.IP);
                soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                uploadTask.LastInvoked = DateTime.Now;
                if (uploadTask.Status == UploadStates.scheduled.ToString())
                    uploadTask.Status = UploadStates.initiating.ToString();
                uploadTask.Save(DatabaseName.Cash);
                soc.ReceiveTimeout = 60000;
                //if (EView360Server.isAsyncUploadDisabled == "1")
                //{
                    try
                    {
                        soc.Connect(atm.IP, (int)atm.Port);
                        connectedAT = DateTime.Now;
                        taskCashOrders.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, atm.IP + " Connected.");
                        //task = taskCashOrders;
                        Thread thread = new Thread(new ThreadStart(HandleUploadRequest));
                        thread.Start();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            taskCashOrders.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                            uploadTask.Status = UploadStates.uploadingDisconnected.ToString();
                            uploadTask.FailureReason = "Can not connect to " + atm.IP; ;
                            taskCashOrders.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "Can not connect to " + atm.IP);

                            uploadTask.Save(DatabaseName.Cash);
                            //task.EndTask();
                            return;
                        }
                        catch (Exception exception)
                        {
                            EventLog.WriteEntry("EView360Server", String.Format("Error in OnConnected() first catch block. detail: {0}{1}", exception.Message, exception.StackTrace), EventLogEntryType.Error);
                        }
                    }

                //}
                //else
                //{
                //    soc.BeginConnect(atm.IP, (int)atm.Port, OnConnected, null);
                //}
            }
            catch (Exception ex)
            {
                taskCashOrders.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                taskCashOrders.EndTask();
            }
        }

        void OnConnected(IAsyncResult arg)
        {
            //    Task newDownloadTask = null;
            task = LogableTask.NewTask("OnConnected");

            try
            {
                soc.EndConnect(arg);
                connectedAT = DateTime.Now;
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, atm.IP + " Connected.");
            }
            catch (Exception ex)
            {
                try
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                    uploadTask.Status = UploadStates.uploadingDisconnected.ToString();
                    uploadTask.FailureReason = "Can not connect to " + atm.IP; ;
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "Can not connect to " + atm.IP);

                    uploadTask.Save(DatabaseName.Cash);
                    task.EndTask();
                    return;
                }
                catch (Exception exception)
                {
                    EventLog.WriteEntry("EView360Server", String.Format("Error in OnConnected() first catch block. detail: {0}{1}", exception.Message, exception.StackTrace), EventLogEntryType.Error);
                }
            }

            HandleUploadRequest();
        }

        private void HandleUploadRequest()
        {
            ServicesDAL.Task newDownloadTask = null;
            task = LogableTask.NewTask("HandleUploadRequest");
            try
            {

                uploadTask.RetryRemaining = (byte)(uploadTask.RetryRemaining - 1);
                uploadTask.Save(DatabaseName.Cash);


                version = ReceiveVersion();
                if (uploadTask.Status == UploadStates.uploadingDisconnected.ToString())
                    uploadTask.Status = UploadStates.resumedUploading.ToString();
                else
                    uploadTask.Status = UploadStates.uploading.ToString();
                uploadTask.Save(DatabaseName.Cash);

                string protocolString = "";

                NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                if (noteSetType == null)
                    throw new Exception("Note Set Type does not exists");



                if (uploadTask.TaskTypeId == (int)EnumTaskType.Configuration)
                {
                    if (EView360Server.appSettingLastLoadedAt.AddHours(1) < DateTime.Now)
                    {
                        lock (EView360Server.appSettings)
                        {
                            EView360Server.appSettingLastLoadedAt = DateTime.Now;
                            EView360Server.appSettings = AppSetting.LoadAppSetting("1=1");
                            LogableTask.LogMonoActivityTask("TimeToRefreshAppSetting", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Reloading appSetting");
                        }
                    }

                    Hashtable ht = new Hashtable();
                    ht.Add(atm.Cassette1Denomination, atm.Cassette1Capacity);

                    if (ht.Contains(atm.Cassette2Denomination))
                        ht[atm.Cassette2Denomination] = (int)ht[atm.Cassette2Denomination] + atm.Cassette2Capacity;
                    else
                        ht.Add(atm.Cassette2Denomination, atm.Cassette2Capacity);

                    if (ht.Contains(atm.Cassette3Denomination))
                        ht[atm.Cassette3Denomination] = (int)ht[atm.Cassette3Denomination] + atm.Cassette3Capacity;
                    else
                        ht.Add(atm.Cassette3Denomination, atm.Cassette3Capacity);

                    if (ht.Contains(atm.Cassette4Denomination))
                        ht[atm.Cassette4Denomination] = (int)ht[atm.Cassette4Denomination] + atm.Cassette4Capacity;
                    else
                        ht.Add(atm.Cassette4Denomination, atm.Cassette4Capacity);

                    if (ht.Contains(atm.Cassette5Denomination))
                        ht[atm.Cassette5Denomination] = (int)ht[atm.Cassette5Denomination] + atm.Cassette5Capacity;
                    else
                        ht.Add(atm.Cassette5Denomination, atm.Cassette5Capacity);

                    if (ht.Contains(atm.Cassette6Denomination))
                        ht[atm.Cassette6Denomination] = (int)ht[atm.Cassette6Denomination] + atm.Cassette6Capacity;
                    else
                        ht.Add(atm.Cassette6Denomination, atm.Cassette6Capacity);

                    if (ht.Contains(atm.Cassette7Denomination))
                        ht[atm.Cassette7Denomination] = (int)ht[atm.Cassette7Denomination] + atm.Cassette7Capacity;
                    else
                        ht.Add(atm.Cassette7Denomination, atm.Cassette7Capacity);

                    if (ht.Contains(noteSetType.DenominationType1.Value) == false ||
                    ht.Contains(noteSetType.DenominationType2.Value) == false ||
                    ht.Contains(noteSetType.DenominationType3.Value) == false ||
                    ht.Contains(noteSetType.DenominationType4.Value) == false )
                        //|| ht.Contains(noteSetType.DenominationType5.Value) == false ||
                    //ht.Contains(noteSetType.DenominationType6.Value) == false ||
                    //ht.Contains(noteSetType.DenominationType7.Value) == false)
                        throw new Exception("Mismatch in cassette logical and physical configuration");


                    bool is_ciphered_comm = EView360Server.appSettings.IsCipheredComm.Value;


                    // 29_07_26 fixed
                    protocolString =
                    String.Format("Configure|TCPTimeout={20}|SleepInterval={21}|" +
                    "StartupSleep={17}|IsCipheredComms={19}|DebugLevel={18}|PortNo={0}|ServerIP={1}|HeartBeatDelay={2}|" +
                    "Denomination_Cassette1={3}|Denomination_Cassette2={4}|Denomination_Cassette3={5}|" +
                    "Denomination_Cassette4={6}|Denomination_Cassette5={7}|Denomination_Cassette6={8}|" +
                    "Denomination_Cassette7={9}|Capacity_Cassette1={10}|Capacity_Cassette2={11}|" +
                    "Capacity_Cassette3={12}|Capacity_Cassette4={13}|Capacity_Cassette5={14}|" +
                    "Capacity_Cassette6={15}|Capacity_Cassette7={16}|DataStreaming_HeartBeat_Port={24}|DataStreaming_Port={25}|OnDemandRequest_Port={26}|OnDemandRequest_HeartBeat_Port={27}", EView360Server.appSettings.DefaltAtmPort,
                    EView360Server.appSettings.ServerIp,
                    EView360Server.appSettings.HeartBeatRefreshInterval * 60, noteSetType.DenominationType1,
                    noteSetType.DenominationType2, noteSetType.DenominationType3, noteSetType.DenominationType4,
                    noteSetType.DenominationType5, noteSetType.DenominationType6, noteSetType.DenominationType7,
                    (int)ht[noteSetType.DenominationType1], (int)ht[noteSetType.DenominationType2], (int)ht[noteSetType.DenominationType3], (int)ht[noteSetType.DenominationType4],
                    0, 0, 0,
                    atm.StartupSleepInterval.HasValue ? atm.StartupSleepInterval.Value : 60,
                    atm.DebugLevel.HasValue ? atm.DebugLevel : 2, is_ciphered_comm == true ? 1 : 0,
                     atm.TCPTimeout, atm.SleepInterval,
                    atm.IsCdm == true ? 1 : 0, atm.IsAtm == true ? 1 : 0,
                    EView360Server.appSettings.AtmDataStreamingHeartbeatPort,
                    EView360Server.appSettings.AtmDataStreamingPort, EView360Server.appSettings.AtmOnDemandRequestPort,
                    EView360Server.appSettings.AtmOnDemandRequestHearbeatPort
                    );


                    // it has issue

                    //protocolString =
                    //String.Format("Configure|TCPTimeout={21}|SleepInterval={22}|" +
                    //"StartupSleep={18}|IsCipheredComms={20}|DebugLevel={19}|PortNo={0}|ServerIP={1}|HeartBeatDelay={3}|" +
                    //"Denomination_Cassette1={4}|Denomination_Cassette2={5}|Denomination_Cassette3={6}|" +
                    //"Denomination_Cassette4={7}|Denomination_Cassette5=0|Denomination_Cassette6=0|" +
                    //"Denomination_Cassette7=0|Capacity_Cassette1={11}|Capacity_Cassette2={12}|" +
                    //"Capacity_Cassette3={13}|Capacity_Cassette4={14}|Capacity_Cassette5={15}|" +
                    //"Capacity_Cassette6={16}|Capacity_Cassette7={17}|DataStreaming_HeartBeat_Port={18},DataStreaming_Port={19},OnDemandRequest_Port={20},OnDemandRequest_HeartBeat_Port={21};", EView360Server.appSettings.DefaltAtmPort,

                    //EView360Server.appSettings.ServerIp,
                    //EView360Server.appSettings.HeartBeatRefreshInterval * 60, noteSetType.DenominationType1,
                    //noteSetType.DenominationType2, noteSetType.DenominationType3, noteSetType.DenominationType4,
                    //noteSetType.DenominationType5, noteSetType.DenominationType6, noteSetType.DenominationType7,
                    //(int)ht[noteSetType.DenominationType1], (int)ht[noteSetType.DenominationType2], (int)ht[noteSetType.DenominationType3], (int)ht[noteSetType.DenominationType4],
                    //0, 0, 0,
                    //atm.StartupSleepInterval.HasValue ? atm.StartupSleepInterval.Value : 60,
                    //atm.DebugLevel.HasValue ? atm.DebugLevel : 2, is_ciphered_comm == true ? 1 : 0,
                    // atm.TCPTimeout, atm.SleepInterval,
                    //atm.IsCdm == true ? 1 : 0, atm.IsAtm == true ? 1 : 0,
                    //EView360Server.appSettings.AtmDataStreamingHeartbeatPort,
                    //EView360Server.appSettings.AtmDataStreamingPort, EView360Server.appSettings.AtmOnDemandRequestPort,
                    //EView360Server.appSettings.AtmOnDemandRequestHearbeatPort
                    //);

                }
                
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.Inventory)
                {
                    protocolString = "INVENTORY|" + System.Configuration.ConfigurationManager.AppSettings["InventoryBatchFilePathOnATM"];
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.CaptureScreen)
                {
                    protocolString = "CaptureWindow";
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.GetApplicationName)
                {
                    protocolString = "GetAppName";
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.GetRunningServices)
                {
                    protocolString = "GetRunningServices";
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.StartService)
                {
                    protocolString = "StartService \"" + uploadTask.TaskInfo + "\"";
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.StopService)
                {
                    protocolString = "StopService \"" + uploadTask.TaskInfo + "\"";
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.ExecuteInitEj)
                {
                    protocolString = "ExecuteInitEj";
                }


                else if (uploadTask.TaskTypeId == (int)EnumTaskType.Restart)
                {
                    protocolString = string.Format("RESTART|{0}", "SHUTDOWN /r /f /t 0");

                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.DateTimeSync)
                {
                    protocolString = string.Format("SYNCDATETIME|{0}", "NET TIME \\\\" + EView360Server.appSettings.ServerIp + " /SET /YES");
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.HeartbeatConfiguration)
                {
                    StringBuilder builder = new StringBuilder();
                    //HeartBeatSchedule.HeartBeatScheduleReader heartBeatScheduleReader = HeartBeatSchedule.ExecuteReader("atm_id=" + atm.ATMId);
                    //while (heartBeatScheduleReader.Read())
                    //{
                    //    builder.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "|" + heartBeatScheduleReader.CurrentHeartBeatSchedule.Interval
                    //        + "|" + heartBeatScheduleReader.CurrentHeartBeatSchedule.EventName + "\r\n");
                    //}
                    //heartBeatScheduleReader.Close();
                    string heartBeatSchedule = builder.ToString();
                    heartBeatSchedule = heartBeatSchedule.Substring(0, heartBeatSchedule.Length - 2);
                    protocolString = string.Format("HEARTBEATSCHEDULE|{0}", heartBeatSchedule);
                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.BatchConfiguration)
                {
                    StringBuilder builder = new StringBuilder();
                    //BatchSchedule.BatchScheduleReader batchScheduleReader = BatchSchedule.ExecuteReader("atm_id=" + atm.ATMId);
                    //while (batchScheduleReader.Read())
                    //{
                    //    builder.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "|" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "|" +
                    //        batchScheduleReader.CurrentBatchSchedule.Interval
                    //        + "|" + batchScheduleReader.CurrentBatchSchedule.EventName + "\r\n");
                    //}
                    //batchScheduleReader.Close();
                    string batchSchedule = builder.ToString();
                    batchSchedule = batchSchedule.Substring(0, batchSchedule.Length - 2);
                    protocolString = string.Format("BATCHSCHEDULE|{0}", batchSchedule);
                }

                else
                {
                    throw new Exception("Unknown task found");
                }


                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "protocolString to send = " + protocolString);

                SendString(protocolString);
                reply = ReceiveString();

                SendString("quit;");
                soc.Shutdown(SocketShutdown.Both);
                soc.Close(1000);

                atm.LastStatusReply = reply;
                atm.Save();


                if (uploadTask.TaskTypeId == (int)EnumTaskType.Configuration)
                {
                    if (!reply.StartsWith("Configuration-Applied;"))
                        throw new Exception(String.Format("An error occured while sending configuration task at ATM {0},{1}", atm.IP, reply));

                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.HeartbeatConfiguration)
                {
                    if (!reply.StartsWith("Schedule-Created;"))
                        throw new Exception(String.Format("An error occured while sending heart beat configuration task at ATM {0},{1}", atm.IP, reply));

                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.BatchConfiguration)
                {
                    if (!reply.StartsWith("Schedule-Created;"))
                        throw new Exception(String.Format("An error occured while sending batch configuration task at ATM {0},{1}", atm.IP, reply));

                }
                //else if (uploadTask.TaskTypeId == (int)EnumTaskType.CashOrderUpload)
                //{
                //    if (!reply.StartsWith("Order-Applied;"))
                //        throw new Exception(String.Format("An error occured while sending cash order at ATM {0},{1}", atm.IP, reply));
                //    cashOrders.IsUploaded = true;
                //    cashOrders.Save();

                //    AlertManager.GenerateCCMSEvent(EventType.OrderDispatchedToATM.ToString(),
                //                    EventType.OrderDispatchedToATM.ToString(), Event_Type.Information.ToString(), cashOrders.AtmId.ToString(),
                //                    EntityType.ATM.ToString(), Actors.CCMS.ToString(),
                //                    Actors.ATM.ToString(), null);

                //}
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.DateTimeSync || uploadTask.TaskTypeId == (int)EnumTaskType.Restart || uploadTask.TaskTypeId == (int)EnumTaskType.ExecuteInitEj
                    || uploadTask.TaskTypeId == (int)EnumTaskType.StartService || uploadTask.TaskTypeId == (int)EnumTaskType.StopService
                    )
                {
                    if (!reply.Contains("Successful"))
                        throw new Exception(String.Format("An error occured while executing command at ATM IP[{0}],Last Reply[{1}]", atm.IP, reply));

                }
                else if (uploadTask.TaskTypeId == (int)EnumTaskType.GetApplicationName || uploadTask.TaskTypeId == (int)EnumTaskType.GetRunningServices
                    || uploadTask.TaskTypeId == (int)EnumTaskType.CaptureScreen
                    )
                {
                    if (!reply.Contains("Successful"))
                        throw new Exception(String.Format("An error occured while executing command at ATM IP[{0}],Last Reply[{1}]", atm.IP, reply));

                    if (uploadTask.TaskTypeId == (int)EnumTaskType.CaptureScreen)
                        CreateNewTask(16, 10);
                    else if (uploadTask.TaskTypeId == (int)EnumTaskType.GetApplicationName)
                        CreateNewTask(17, 10);
                    else if (uploadTask.TaskTypeId == (int)EnumTaskType.GetRunningServices)
                        CreateNewTask(18, 10);


                }

                else if (uploadTask.TaskTypeId == (int)EnumTaskType.Inventory)
                {
                    if (!reply.Contains("Successful"))
                        throw new Exception(String.Format("An error occured while executing command at ATM IP[{0}],Last Reply[{1}]", atm.IP, reply));
                    //Create tasks for 2 new files created with batch file.

                    if ((int)ConnectionFactory.ExecuteScalar("select count(file_type_id) from task where file_type_id=11 and status in ('scheduled','uploadingDisconnected') and atm_id =" + atm.ATMId, DatabaseName.Cash) == 0)
                    {
                        newDownloadTask = new ServicesDAL.Task();
                        newDownloadTask.ATMId = atm.ATMId;
                        newDownloadTask.BytesTransferred = 0;
                        newDownloadTask.CreationTime = DateTime.Now;
                        newDownloadTask.CreatedBy = 1;
                        newDownloadTask.DownloadTime = new DateTime(1900, 1, 1);
                        newDownloadTask.FileTypeId = 11;
                        newDownloadTask.Parsed = false;
                        //newDownloadTask.RetryRemaining = (byte)atm.RetryCountCounterFile;
                        newDownloadTask.Status = DownloadStates.scheduled.ToString();
                        newDownloadTask.TaskTypeId = 1;
                        newDownloadTask.Save(DatabaseName.Cash);
                    }

                    if ((int)ConnectionFactory.ExecuteScalar("select count(file_type_id) from task where file_type_id=12 and status in ('scheduled','uploadingDisconnected') and atm_id =" + atm.ATMId, DatabaseName.Cash) == 0)
                    {
                        //Create tasks for 2 new files created with batch file.
                        newDownloadTask = new ServicesDAL.Task();
                        newDownloadTask.ATMId = atm.ATMId;
                        newDownloadTask.BytesTransferred = 0;
                        newDownloadTask.CreationTime = DateTime.Now;
                        newDownloadTask.CreatedBy = 1;
                        newDownloadTask.DownloadTime = new DateTime(1900, 1, 1);
                        newDownloadTask.FileTypeId = 12;
                        newDownloadTask.TaskTypeId = 1;
                        newDownloadTask.Parsed = false;
                        //newDownloadTask.RetryRemaining = (byte)atm.RetryCountCounterFile;
                        newDownloadTask.Status = DownloadStates.scheduled.ToString();
                        newDownloadTask.Save(DatabaseName.Cash);
                    }
                    if ((int)ConnectionFactory.ExecuteScalar("select count(file_type_id) from task where file_type_id=50 and status in ('scheduled','uploadingDisconnected') and atm_id =" + atm.ATMId, DatabaseName.Cash) == 0)
                    {
                        //Create tasks for 2 new files created with batch file.
                        newDownloadTask = new ServicesDAL.Task();
                        newDownloadTask.ATMId = atm.ATMId;
                        newDownloadTask.BytesTransferred = 0;
                        newDownloadTask.CreationTime = DateTime.Now;
                        newDownloadTask.CreatedBy = 1;
                        newDownloadTask.DownloadTime = new DateTime(1900, 1, 1);
                        newDownloadTask.FileTypeId = 50;
                        newDownloadTask.TaskTypeId = 1;
                        newDownloadTask.Parsed = false;
                        //newDownloadTask.RetryRemaining = (byte)atm.RetryCountCounterFile;
                        newDownloadTask.Status = DownloadStates.scheduled.ToString();
                        newDownloadTask.Save(DatabaseName.Cash);
                    }


                }

                uploadTask.BytesTransferred = protocolString.Length;
                uploadTask.UploadTime = uploadTask.UploadTime.Value + (DateTime.Now - connectedAT);
                uploadTask.Status = UploadStates.completed.ToString();
                uploadTask.FailureReason = "";
                uploadTask.EndTime = DateTime.Now;
                uploadTask.Save(DatabaseName.Cash);
                SqlCommand cmd = null;
                if (uploadTask.TaskTypeId == (int)EnumTaskType.CashOrderUpload)
                {
                    try
                    {
                        cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
                        cmd.CommandText = @"update cash_order_monitoring 
                                    set current_order_delivered_at=convert(datetime,'" + uploadTask.EndTime.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) " +
                                            " where current_order_id = " + uploadTask.CashOrderId.Value;
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (cmd != null)
                            cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, String.Format("ip ={0} Error while status {1}", atm.IP, uploadTask.Status));
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                    //uploadTask.RetryRemaining = (byte)(uploadTask.RetryRemaining - 1);
                    //if (uploadTask.RetryRemaining == 0)
                    //{
                    //    uploadTask.Status = UploadStates.retriesExhausted.ToString();
                    //    if (uploadTask.TaskTypeId == (int)EnumTaskType.Configuration)
                    //        AlertManager.GenerateTerminalAlert(atm.ATMId, (int)EnumAlertType.ConfigurationUploadFailed, null, Event_Type.Error);

                    //    else if (uploadTask.TaskTypeId == (int)EnumTaskType.CashOrderUpload)
                    //    {
                    //        AlertManager.GenerateTerminalAlert(atm.ATMId, (int)EnumAlertType.CashOrderUploadFailed, null, Event_Type.Error);

                    //        //AlertManager.GenerateCCMSEvent(
                    //        //EventType.OrderDispatchingFailed.ToString(),
                    //        //EventType.OrderDispatchingFailed.ToString(),
                    //        //Event_Type.Error.ToString(),
                    //        //CashOrders.LoadCashOrdersByPk(uploadTask.CashOrderId.Value).OrderNumber.ToString(),
                    //        //EntityType.Order.ToString(),
                    //        //Actors.CCMS.ToString(),
                    //        //Actors.ATM.ToString(),
                    //        //null);
                    //    }
                    //}
                    //else
                    //    uploadTask.Status = UploadStates.uploadingDisconnected.ToString();


                    if (ex.Message.Replace("'", "''").Length > 256)
                        uploadTask.FailureReason = ex.Message.Replace("'", "''").Substring(0, 256);
                    else
                        uploadTask.FailureReason = ex.Message.Replace("'", "''");


                    uploadTask.Save(DatabaseName.Cash);

                    if (soc.Connected)
                        soc.Close();
                }
                catch (Exception exception)
                {
                    EventLog.WriteEntry("EView360Server", String.Format("Error in OnConnected() second catch block. detail: {0}{1}", exception.Message, exception.StackTrace), EventLogEntryType.Error);
                }
            }
            finally
            {
                try
                {
                    task.EndTask();

                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("EView360Server", String.Format("Error in OnConnected() finally  block. detail: {0}{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }

            }
            //return newDownloadTask;
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
            byte[] arr = null;
            int length = this.soc.Receive(buff, buff.Length, SocketFlags.None);
            string str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
            while (this.soc.Available > 0 && length > 0)
            {
                length = soc.Receive(buff, buff.Length, SocketFlags.None);
                str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
            }

            if (!version.Contains("CCMS"))
            {
                arr = Encoding.ASCII.GetBytes(str);
                SimpleDecrypt(ref arr);
                str = Encoding.ASCII.GetString(arr);
            }

            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "received string = " + str);
            return str;
        }
        string ReceiveVersion()
        {
            int length = this.soc.Receive(buff, buff.Length, SocketFlags.None);
            string str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
            while (this.soc.Available > 0 && length > 0)
            {
                length = soc.Receive(buff, buff.Length, SocketFlags.None);
                str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
            }

            //if (!str.Contains("CCMS"))
            //{
            //    arr = Encoding.ASCII.GetBytes(str);
            //    SimpleDecrypt(ref arr);
            //    str = Encoding.ASCII.GetString(arr);
            //}


            return str;
        }

        void SendString(string stringToSend)
        {
            byte[] stringToSendInBytes = Encoding.ASCII.GetBytes(stringToSend);
            if (!version.Contains("CCMS"))
            {
                SimpleEncrypt(ref stringToSendInBytes);

            }
            soc.Send(stringToSendInBytes);
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "sent message = " + stringToSend);

        }
        //string ReceiveString()
        //{
        //    int length = soc.Receive(buff, buff.Length, SocketFlags.None);
        //    string str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
        //    while (soc.Available > 0 && length > 0)
        //    {
        //        length = soc.Receive(buff, buff.Length, SocketFlags.None);
        //        str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
        //    }

        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "received string = " + str);
        //    return str;
        //}
        //void SendString(string stringToSend)
        //{
        //    byte[] stringToSendInBytes = Encoding.ASCII.GetBytes(stringToSend);
        //    soc.Send(stringToSendInBytes);
        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "sent message = " + stringToSend);
        //}

        private void CreateNewTask(int fileTypeID, int retryRemaining)
        {
            ServicesDAL.Task newDownloadTask = new ServicesDAL.Task();
            newDownloadTask.ATMId = atm.ATMId;
            newDownloadTask.BytesTransferred = 0;
            newDownloadTask.CreationTime = DateTime.Now;
            newDownloadTask.CreatedBy = 1;
            newDownloadTask.DownloadTime = new DateTime(1900, 1, 1);
            newDownloadTask.FileTypeId = fileTypeID;
            newDownloadTask.Parsed = false;
            newDownloadTask.RetryRemaining = (byte)retryRemaining;
            newDownloadTask.Status = DownloadStates.scheduled.ToString();
            newDownloadTask.TaskTypeId = 1;
            newDownloadTask.Save(DatabaseName.Cash);

        }
    }
}