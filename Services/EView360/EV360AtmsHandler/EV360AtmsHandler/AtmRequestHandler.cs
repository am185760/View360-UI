using DataRequestor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EV360AtmsHandler
{
    public class AtmRequestHandler
    {
        Socket soc;
        string reply = "HeartBeat";
        byte[] buff = new byte[1024];
        private static Semaphore semaphore = new System.Threading.Semaphore(3, 3);
        bool isSemaphoreTaken = false;

        public AtmRequestHandler(Socket socket)
        {
            soc = socket;
        }


        public void Talk(object state)
        {
            LogableTask task = null;
            SqlCommand cmd = null;
            SqlTransaction trxn = null;
            try
            {
                task = LogableTask.NewTask("ATMRequest");
                reply = ReceiveVersion();
                string remoteEndPoint = soc.RemoteEndPoint.ToString();
                soc.Close();
                //int index = UpdateAndGetAtmStatusIndexByIP(remoteEndPoint.Split(':')[0], reply);


                // index must be in the list...

                //if (index < 0)
                //    throw new Exception(string.Format("Terminal IP{0} is not defined in the database",
                //        remoteEndPoint));



                //HeartBeat|<OrderId>|<RemainingSuggestedCountsOfCassette1>...|<RemainingSuggestedCountsOfCassette7>;
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, reply);
                //Atm atm = Atm.LoadAtmByPk(EView360HealthMonitoring.listAtmStatus[index].atm_id);
                //atm.IsHealthy = true;
                //HeartBeat heartBeat = new HeartBeat();
                //heartBeat.AtmId = EView360HealthMonitoring.listAtmStatus[index].atm_id;
                ////heartBeat.CashOrderId = orderID;
                //heartBeat.HeartBeatReceivedAt = DateTime.Now;
                //if (reply.Contains("CCMSServiceManager"))
                //{
                //    heartBeat.IsServiceManager = true;
                //    //atm.CcmsservicemanagerLastReportedHeartbeat = DateTime.Now;
                //}
                //else
                //{
                //    heartBeat.IsServiceManager = false;
                //    //atm.CcmsagentLastReportedHeartbeat = DateTime.Now;
                //}
                ////heartBeat.Cassette1RemainingNotes = cas1RemainingAmt;
                ////heartBeat.Cassette2RemainingNotes = cas2RemainingAmt;
                ////heartBeat.Cassette3RemainingNotes = cas3RemainingAmt;
                ////heartBeat.Cassette4RemainingNotes = cas4RemainingAmt;
                ////heartBeat.Cassette5RemainingNotes = cas5RemainingAmt;
                ////heartBeat.Cassette6RemainingNotes = cas6RemainingAmt;
                ////heartBeat.Cassette7RemainingNotes = cas7RemainingAmt;
                //heartBeat.Save();
                //atm.Save();
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
                try
                {
                    task.EndTask();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("CCMSNotifier", ex.Message + ex.StackTrace, EventLogEntryType.Error);
                }
            }
        }


        string ReceiveVersion()
        {
            byte[] arr = null;
            int length = this.soc.Receive(buff, buff.Length, SocketFlags.None);
            string str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
            while (this.soc.Available > 0 && length > 0)
            {
                length = soc.Receive(buff, buff.Length, SocketFlags.None);
                str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
            }

            if (!str.Contains("Heartbeat"))
            {
                if (!str.Contains("Batch"))
                {

                    arr = Encoding.ASCII.GetBytes(str);
                    SimpleDecrypt(ref arr);
                    str = Encoding.ASCII.GetString(arr);
                }
            }


            return str;
        }

        void SimpleDecrypt(ref byte[] sourceArray)
        {
            for (int counter = 0; counter < sourceArray.Length; counter++)
                sourceArray[counter] = (byte)(sourceArray[counter] + ((counter + 1) % 10));
        }

    }
}
