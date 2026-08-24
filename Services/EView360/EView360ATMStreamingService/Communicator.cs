using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ATM360
{
    class Communicator
    {
        int bytesRead = -1;
        byte[] fileData = new byte[1024];
        static Socket socket = null;
        TcpClient tcpClient;
        SslStream sslStream;
        LogableTask task;
        string filename = null;
        long index = 0;
        public Communicator()
        {
            //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            task = LogableTask.NewTask("StartTransfer");
        }

        public static byte[] Decompress(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {

                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }
                    return outputStream.ToArray();
                }
            }
        }


        public void Upload(string filename)
        {
            string command = null;
            FileStream fileStream = null;
            //while (true)
            // {
            //EView360ATMStreaming.manualResetEvent.WaitOne();

            LogableTask.LogMonoActivityTask("DoUpload", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to upload file " + filename);
            //SendString("download=" + Path.GetFileName(fileInfo.FullName) + "_" + new FileInfo(fileInfo.FullName).Length);
            //command = ReceiveString();
            //LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "recieved from server:" + command);
            //if (command.StartsWith("OK"))
            //{

            SendString("download=" + Path.GetFileName(filename));
            LogableTask.LogMonoActivityTask("DoUpload", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "waiting for server response");

            command = ReceiveString();
            LogableTask.LogMonoActivityTask("DoUpload", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "server replied:" + command);

            try
            {
                if (command.Equals("OK"))
                {
                    fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    fileStream.Seek(index, SeekOrigin.Current);

                    while ((bytesRead = fileStream.Read(fileData, 0, 1023)) > 0)
                    {
                        //byte[] compressedFileData = Compress(fileData);
                        if (!EView360ATMStreaming.isSSLEnabled)
                        {
                            //socket.Send(compressedFileData, 0, compressedFileData.Length, SocketFlags.None);
                            socket.Send(fileData, 0, bytesRead, SocketFlags.None);
                            command = ReceiveString();

                        }

                        else
                            sslStream.Write(fileData, 0, bytesRead);
                    }
                }
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
            if (command.StartsWith("OK"))
            {
                if (!Directory.Exists(EView360ATMStreaming.processedPath))
                    Directory.CreateDirectory(EView360ATMStreaming.processedPath);

                if (File.Exists(EView360ATMStreaming.processedPath + "\\" + Path.GetFileName(filename)))
                    File.Delete(EView360ATMStreaming.processedPath + "\\" + Path.GetFileName(filename));

                File.Move(filename, EView360ATMStreaming.processedPath + "\\" + Path.GetFileName(filename));

            }
            //}

            //SendString("SENT");


            //if (command.StartsWith("start-send file"))
            //{
            //    //start - send file = chunk_12062016155619_4728096.zip_524366; from = 0;
            //    string[] parts = command.Split(';');

            //    filename = parts[0].Split('=')[1];
            //    index = long.Parse(parts[1].Split('=')[1]);
            //    SendString("ready;");

            //}
            //else if (command.StartsWith("file-received"))
            //{
            //    File.Move(EView360ATMStreaming.TransportQueuePath + "\\" + filename, EView360ATMStreaming.uploadedFilePath + "\\" + filename);
            //    if (socket != null)
            //        socket.Close();
            //    else
            //    {
            //        sslStream.Close();
            //        tcpClient.Close();
            //    }
            //    break;
            //}


            //else if (command.StartsWith("start-now"))
            //{
            //    FileStream fileStream = null;
            //    byte[] fileData = new byte[1024];
            //    string[] parts = command.Split(';');
            //    string fileToSend = EView360ATMStreaming.TransportQueuePath + "\\" + filename;
            //    // long index = long.Parse(parts[1].Split('=')[1]);
            //    int bytesRead = 0;
            //    try
            //    {
            //        fileStream = new FileStream(fileToSend, FileMode.Open, FileAccess.Read);
            //        fileStream.Seek(index, SeekOrigin.Current);

            //        while ((bytesRead = fileStream.Read(fileData, 0, 1023)) > 0)
            //        {
            //            if (!EView360ATMStreaming.isSSLEnabled)
            //                socket.Send(fileData, 0, bytesRead, SocketFlags.None);
            //            else
            //                sslStream.Write(fileData, 0, bytesRead);
            //        }
            //    }
            //    finally
            //    {
            //        if (fileStream != null)
            //            fileStream.Close();
            //    }
            //}
            //else if (command.StartsWith("quit") || command.Length == 0)
            //{
            //    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "quit received from server or command length=0");
            //    break;
            //}
            //else
            //{
            //    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "unknown command received");
            //}
            //  Thread.Sleep(1000 * 2);

            //   EView360ATMStreaming.manualResetEvent.Reset();

            //}
        }
        public void Disconnect()
        {
            SendString("disconnect");
            string command = ReceiveString();

            if (command.Equals("OK"))
            {
                if (socket != null)
                    socket.Close();
                else
                {
                    if (sslStream != null)
                        sslStream.Close();

                    if (tcpClient != null)
                        tcpClient.Close();
                }
            }

        }
        private static X509Certificate getServerCert()
        {
            X509Store store = new X509Store(StoreName.My,
               StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2 foundCertificate = null;
            foreach (X509Certificate2 currentCertificate
               in store.Certificates)
            {
                LogableTask.LogMonoActivityTask("d", MethodBase.GetCurrentMethod(), TraceLevel.Info, "iss name:" + currentCertificate.IssuerName.Name);
                if (currentCertificate.IssuerName.Name
                   != null && currentCertificate.IssuerName.
                   Name.Equals("CN=NCRMSISSUECA1"))
                {
                    foundCertificate = currentCertificate;
                    break;
                }
            }


            return foundCertificate;
        }

        public void Connect(string ip, int port)
        {
            try
            {
                LogableTask.LogMonoActivityTask("Talk", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Connecting to " + ip + ":" + port);
                if (EView360ATMStreaming.isSSLEnabled)
                {
                    tcpClient = new TcpClient(ip, port);
                    tcpClient.SendTimeout = 20 * 1000;
                    tcpClient.ReceiveTimeout = 20 * 1000;

                    sslStream = new SslStream(tcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                    sslStream.AuthenticateAsClient(EView360ATMStreaming.hostname, null, SslProtocols.Tls12, false);
                }
                else
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ip, port);
                    LogableTask.LogMonoActivityTask("Talk", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Connection established");

                }
                //ProcessCommands();

            }

            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                if (ex.InnerException != null)
                    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.InnerException.Message);
                EView360ATMStreaming.timerUploader.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 1, 0));
            }
            finally
            {
                if (tcpClient != null)
                    tcpClient.Close();
            }

        }

        public void SendHeartBeat(string ip, int port)
        {
            try
            {
                LogableTask.LogMonoActivityTask("Talk", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Sending heartbeat to " + ip + ":" + port);
                if (EView360ATMStreaming.isSSLEnabled)
                {
                    tcpClient = new TcpClient(ip, port);
                    tcpClient.SendTimeout = 20 * 1000;
                    sslStream = new SslStream(tcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                    sslStream.AuthenticateAsClient(EView360ATMStreaming.hostname, null, SslProtocols.Tls12, false);
                }
                else
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ip, port);
                }
                SendString("SSHeartbeat");
                LogableTask.LogMonoActivityTask("SendHeartBeat", MethodBase.GetCurrentMethod(), TraceLevel.Info, "heartbeat sent successfully!");

            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("SendHeartBeat", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                if (ex.InnerException != null)
                    LogableTask.LogMonoActivityTask("SendHeartBeat", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.InnerException.Message);
            }
            finally
            {
                if (tcpClient != null)
                    tcpClient.Close();

                if (sslStream != null)
                    sslStream.Close();
            }

        }


        void SendString(string stringToSend)
        {
            byte[] stringToSendInBytes = Encoding.ASCII.GetBytes(stringToSend);
            if (EView360ATMStreaming.isSSLEnabled)
            {
                sslStream.Write(stringToSendInBytes);
                sslStream.Flush();
            }
            else
            {
                socket.Send(stringToSendInBytes);
            }
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "sent message = " + stringToSend);
        }

        string ReceiveString()
        {
            StringBuilder messageData = new StringBuilder();

            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            byte[] buffer = new byte[2048];
            if (EView360ATMStreaming.isSSLEnabled)
            {
                int bytes = -1;
                //do
                //{
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
            }
            else
            {
                byte[] DecompressedBytes = null;
                int length = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                //DecompressedBytes = Decompress(buffer);
                //                messageData.Append(ASCIIEncoding.ASCII.GetString(DecompressedBytes, 0, DecompressedBytes.Length));
                messageData.Append(ASCIIEncoding.ASCII.GetString(buffer, 0, length));

                while (socket.Available > 0 && length > 0)
                {
                    length = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                    //DecompressedBytes = Decompress(buffer);
                    messageData.Append(ASCIIEncoding.ASCII.GetString(buffer, 0, length));
                }
            }
            // Check for EOF.
            //if (messageData.ToString().IndexOf("<EOF>") != -1)
            //{
            //    break;
            //}
            //} while (bytes != 0);
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "received string = " + messageData.ToString());
            return messageData.ToString();
        }

        //string ReceiveString()
        //{
        //    byte[] buff = new byte[1024];
        //    int length = this.socket.Receive(buff, buff.Length, SocketFlags.None);
        //    string str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
        //    while (this.socket.Available > 0 && length > 0)
        //    {
        //        length = socket.Receive(buff, buff.Length, SocketFlags.None);
        //        str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
        //        Thread.Sleep(5 * 1000);
        //    }
        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "received string = " + str);
        //    return str;
        //}

        private X509Certificate GetCertificate()
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByIssuerName, "NCRMSISSUECA1", true);
            LogableTask.LogMonoActivityTask("certcount", MethodBase.GetCurrentMethod(), TraceLevel.Info, "cert count:" + certs.Count);

            for (int i = 0; i < certs.Count; i++)
                LogableTask.LogMonoActivityTask("certcount", MethodBase.GetCurrentMethod(), TraceLevel.Info, "cert count:" + certs[i].Issuer);

            store.Close();
            return certs[0];
        }
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            LogableTask.LogMonoActivityTask("App_CertificateValidation", MethodBase.GetCurrentMethod(), TraceLevel.Info, sslPolicyErrors.ToString());

            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) { return true; }

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
    }
}
