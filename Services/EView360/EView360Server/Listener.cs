using ServicesDAL;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Avanza.CCMS
{
    public class Listener
    {
        #region Private Fields
        private int currentQueueCount = 0;
        // private byte[] _buff = new byte[1024];
        private readonly bool _isSsl = System.Configuration.ConfigurationManager.AppSettings["IsSsl"] == "1";
        private readonly int _port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ListeningPort"]);
        private readonly string _certificatePath = System.Configuration.ConfigurationManager.AppSettings["CertificatePath"];
        private readonly string isFileTypeReportedInFilename = System.Configuration.ConfigurationManager.AppSettings["isFileTypeReportedInFilename"];


        //private string _reply = string.Empty;
        //  private Socket _soc;
        //   private TcpClient _client;
        private static X509Certificate _serverCertificate;
        private const string EndOfFileMarker = "<EOF>";

        #endregion Private Fields

        #region Public Methods

        public void DoListen(object state)
        {
            EView360Server.timerListener.Change(-1, -1);

            var taskStartListnet = LogableTask.NewTask("StartListner");
            Socket serverSoc = null;
            TcpListener listener = null;
            AppSetting appSettings = AppSetting.LoadAppSetting("1=1");

            try
            {
                if (_isSsl)
                {
                    //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Environment.OSVersion:" + Environment.OSVersion);
                    //_serverCertificate = new X509Certificate2(_certificatePath, ""appSettings.CurrencyMngPassword);
                    _serverCertificate = new X509Certificate2(_certificatePath, Encryption.Cryptic.DecryptString(appSettings.CurrencyMngPassword));


                    listener = new TcpListener(IPAddress.Any, _port);
                    listener.Start(1000);
                }
                else
                {
                    //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "No SSL");
                    serverSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    serverSoc.Bind(new IPEndPoint(IPAddress.Any, _port));
                    serverSoc.Listen(10);
                }
                taskStartListnet.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Listener started at port = " + _port);
            }
            catch (Exception ex)
            {
                taskStartListnet.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                return;
            }
            finally
            {
                try
                {
                    taskStartListnet.EndTask();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("EView360Server.Listner()", ex.Message + ex.StackTrace, EventLogEntryType.Error);
                }
            }

            while (true)
            {
                try
                {
                    EView360Server.InitLogger();
                    if (_isSsl)
                    {
                        if (listener != null)
                        {
                            var client = listener.AcceptTcpClient();
                            LogableTask.LogMonoActivityTask("ConnEstablished", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing:" + client.Client.RemoteEndPoint);
                            ThreadPool.QueueUserWorkItem(Talk, client);
                            Interlocked.Increment(ref currentQueueCount);
                        }
                    }
                    else
                    {
                        if (serverSoc != null)
                        {
                            var atmSocket = serverSoc.Accept();
                            LogableTask.LogMonoActivityTask("ConnEstablished", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing:" + atmSocket.RemoteEndPoint);
                            ThreadPool.QueueUserWorkItem(Talk, atmSocket);

                        }
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("EView360Server", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                }
            }
        }





        bool App_CertificateValidation(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None) { return true; }
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) { return true; } //we don't have a proper certificate tree
            LogableTask.LogMonoActivityTask("App_CertificateValidation", MethodBase.GetCurrentMethod(), TraceLevel.Info, sslPolicyErrors.ToString());
            return false;
        }
        public static byte[] Compress(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                {
                    gzipStream.Write(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }
        //public static byte[] Decompress(byte[] bytes, int len)
        //{
        //    using (var memoryStream = new MemoryStream(bytes, 0, len))
        //    {

        //        using (var outputStream = new MemoryStream())
        //        {
        //            using (var decompressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
        //            {
        //                decompressStream.CopyTo(outputStream);
        //            }
        //            return outputStream.ToArray();
        //        }
        //    }
        //}
        public void UnlimitedTalk(Socket _soc)
        {
            string _reply = null;
            string folderPath = "";
            string fileName = "";
            //int seq = 0;
            while (true)
            {
                _reply = ReceiveString(_soc);
                if (_reply.StartsWith("download"))
                {
                    LogableTask.LogMonoActivityTask("UnlimitedTalk", MethodBase.GetCurrentMethod(), TraceLevel.Info, _reply);

                    _soc.Send(Encoding.ASCII.GetBytes("OK"));
                    var remoteEndPoint = _soc.RemoteEndPoint.ToString();
                    folderPath = EView360Server.appSettings.TemporaryFolder + "\\Uploads\\" + remoteEndPoint.Split(':')[0];
                    fileName = _reply.Split('=')[1];
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                }
                else if (_reply.StartsWith("SENT"))
                {
                    _soc.Send(Encoding.ASCII.GetBytes("OK"));
                    LogableTask.LogMonoActivityTask("UnlimitedTalk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "OK sent to delete file");

                }
                else if (_reply.StartsWith("disconnect"))
                {
                    _soc.Send(Encoding.ASCII.GetBytes("OK"));
                    LogableTask.LogMonoActivityTask("UnlimitedTalk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "OK sent to close connection");
                    break;
                }

                else
                {
                    if (_reply.Length > 0)
                    {
                        //if (_reply.EndsWith("SENT"))
                        //{
                        //    File.AppendAllText(folderPath + "\\" + fileName, _reply.Substring(0, _reply.IndexOf("SENT")));
                        //    _soc.Send(Encoding.ASCII.GetBytes("OK"));
                        //}
                        //else
                        //{
                        //var remoteEndPoint = _soc.RemoteEndPoint.ToString();
                        //folderPath = EView360Server.appSettings.TemporaryFolder + "\\Uploads\\" + remoteEndPoint.Split(':')[0];
                        ////fileName = _reply.Split('=')[1];
                        //if (!Directory.Exists(folderPath))
                        //    Directory.CreateDirectory(folderPath);


                        //                        File.WriteAllText(folderPath + "\\" + _reply.Substring(0, _reply.IndexOf("@")), _reply.Substring(_reply.IndexOf("@") + 1));
                        File.WriteAllText(folderPath + "\\" + fileName, _reply);
                        _soc.Send(Encoding.ASCII.GetBytes("OK"));
                        //seq++;
                        //if (seq == int.MaxValue - 1)
                        //    seq = 0;
                        //}
                    }
                }
            }

        }

        public void Talk(object state)
        {
            //   LogableTask task = null;
            SslStream sslStream = null;
            TcpClient _client = null;
            Socket _soc = null;
            try
            {
                // task = LogableTask.NewTask("ATMRequest");

                if (_isSsl)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;//SecurityProtocolType.Tls12;// SecurityProtocolType.Tls| SecurityProtocolType.Ssl3;
                    _client = (TcpClient)state;
                    sslStream = new SslStream(_client.GetStream(), false);
                    sslStream.AuthenticateAsServer(_serverCertificate, false, SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12, true);
                    // Set timeouts for the read and write to 30 seconds.
                    //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "sslStream.SslProtocol:" + sslStream.SslProtocol);

                    sslStream.ReadTimeout = 500 * 1000;
                    sslStream.WriteTimeout = 500 * 1000;
                    //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to recv");
                    string _reply = ReceiveStringSsl(sslStream);
                    //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "_reply:" + _reply);
                    var remoteEndPoint = _client.Client.RemoteEndPoint.ToString();
                    //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to process remoteEndPoint:" + remoteEndPoint);
                    //To avoid simultaneous hits on db
                    //Thread.Sleep(2000);

                    if (currentQueueCount > 20)
                    {
                        LogableTask.LogMonoActivityTask("ConnEstablished", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Sleeping for 2 seconds");
                        Thread.Sleep(2 * 1000);
                    }

                    var atm = Atm.LoadAtm("ip='" + remoteEndPoint.Split(':')[0] + "'");
                    if (atm != null)
                    {
                        //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to process atm:" + atm.IP);
                        //PerformWorkSsl(_reply, atm, sslStream, _client);

                    }
                    else
                        LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Atm Ip is not defined in view360 database:" + remoteEndPoint);
                }
                else
                {

                    _soc = (Socket)state;
                    UnlimitedTalk(_soc);

                    //var atm = Atm.LoadAtm("ip='" + remoteEndPoint.Split(':')[0] + "'");
                    //if (atm != null)
                    //{
                    //    //       task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to Perform Work");
                    //    PerformWork(_reply, atm, _soc);
                    //}
                    //else
                    //    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Atm Ip is not defined in view360 database" + remoteEndPoint);

                }

            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Exception: " + ex);
                if (ex.InnerException != null)
                    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Inner exception: " + ex.InnerException);
            }
            finally
            {
                try
                {
                    if (sslStream != null)
                    {
                        sslStream.Close();
                        sslStream.Dispose();
                    }

                    if (_client != null)
                        _client.Close();

                    if (_soc != null)
                        _soc.Close();

                    Interlocked.Decrement(ref currentQueueCount);

                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("EView360Server", ex.Message + " " + ex.StackTrace);

                }
            }
        }

        #endregion Public Methods

        //#region Private Methods
        public static string GZipStringDecompress(string s)
        {
            var bytes = Convert.FromBase64String(s);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                }
                return Encoding.Unicode.GetString(mso.ToArray());
            }
        }
        public static byte[] Decompress(byte[] data, int bytesRead)
        {
            // Read the last 4 bytes to get the length
            byte[] lengthBuffer = new byte[4];
            Array.Copy(data, bytesRead - 4, lengthBuffer, 0, 4);
            int uncompressedSize = BitConverter.ToInt32(lengthBuffer, 0);

            var buffer = new byte[uncompressedSize];
            using (var ms = new MemoryStream(data))
            {
                using (var gzip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    gzip.Read(buffer, 0, uncompressedSize);
                }
            }
            return buffer;
        }


        private string ReceiveString(Socket _soc)
        {

            byte[] _buff = new byte[1024];
            byte[] DecompressedBytes = null;
            var length = _soc.Receive(_buff, _buff.Length, SocketFlags.None);
            bool isDecompressEnabled = false;
            // string str = GZipStringDecompress(Encoding.ASCII.GetString(_buff));
            var str = Encoding.ASCII.GetString(_buff, 0, length);
            if (!str.Contains("download")&& !str.Contains("disconnect"))
            {
                DecompressedBytes = Decompress(_buff, length);
                str = Encoding.ASCII.GetString(DecompressedBytes, 0, DecompressedBytes.Length);
                isDecompressEnabled = true;
            }
            while (_soc.Available > 0 && length > 0)
            {
                length = _soc.Receive(_buff, _buff.Length, SocketFlags.None);

                if (isDecompressEnabled)
                {
                    DecompressedBytes = Decompress(_buff, length);
                    str += Encoding.ASCII.GetString(DecompressedBytes, 0, DecompressedBytes.Length);
                }
                else
                    //DecompressedBytes = Decompress(_buff, length);
                    str += Encoding.ASCII.GetString(_buff, 0, length);
                //str = GZipStringDecompress(Convert.ToBase64String(_buff));

            }

            //arr = Encoding.ASCII.GetBytes(str);
            //SimpleDecrypt(ref arr);
            //str = Encoding.ASCII.GetString(arr);

            return str;
        }

        private static string ReceiveStringSsl(SslStream sslStream)
        {
            // Read the  message sent by the client.
            // The client signals the end of the message using the
            // "<EOF>" marker.
            var buffer = new byte[2048];
            var messageData = new StringBuilder();
            var bytes = -1;
            //do
            //{
            //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "reading sockets");
            // Read the client's test message.
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "bytes recv");
            // Use Decoder class to convert from bytes to UTF8
            // in case a character spans two buffers.
            var decoder = Encoding.UTF8.GetDecoder();
            var chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
            decoder.GetChars(buffer, 0, bytes, chars, 0);
            messageData.Append(chars);
            // Check for EOF or an empty message.
            //} while ( bytes != 0);

            //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "recv:" + messageData.ToString());
            return messageData.ToString();
        }


        //#endregion Private Methods
    }
}