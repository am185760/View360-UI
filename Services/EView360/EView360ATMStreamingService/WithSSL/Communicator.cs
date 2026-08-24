using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM360
{
    class Communicator
    {

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
        public void ProcessCommands()
        {
            string command = null;
            while (true)
            {
                command = ReceiveString();
                if (command.StartsWith("start-send file"))
                {
                    //start - send file = chunk_12062016155619_4728096.zip_524366; from = 0;
                    string[] parts = command.Split(';');

                    filename = parts[0].Split('=')[1];
                    index = long.Parse(parts[1].Split('=')[1]);
                    SendString("ready;");

                }
                else if (command.StartsWith("file-received"))
                {
                    File.Delete(ATM360.tempFolderPath + filename);
                    tcpClient.Close();
                    break;
                }


                else if (command.StartsWith("start-now"))
                {
                    FileStream fileStream = null;
                    byte[] fileData = new byte[1024];
                    string[] parts = command.Split(';');
                    string fileToSend = ATM360.tempFolderPath + filename;
                    // long index = long.Parse(parts[1].Split('=')[1]);
                    int bytesRead = 0;
                    try
                    {
                        fileStream = new FileStream(fileToSend, FileMode.Open, FileAccess.Read);
                        fileStream.Seek(index, SeekOrigin.Current);

                        while ((bytesRead = fileStream.Read(fileData, 0, 1023)) > 0)
                        {
                          sslStream.Write(fileData, 0, bytesRead);
                        }
                    }
                    finally
                    {
                        if (fileStream != null)
                            fileStream.Close();
                    }
                }
                else if (command.StartsWith("quit") || command.Length == 0)
                {
                    sslStream.Close();
                    break;
                }
                else
                {
                    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Info, "unknown command received");
                }
            }
        }
        public void Talk(string hostname, string port, string filePath)
        {
            try
            {
                tcpClient = new TcpClient(hostname, int.Parse(port));
                sslStream = new SslStream(tcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient(ATM360.serverName);
                SendString("download=" + Path.GetFileName(filePath) + "_" + new FileInfo(filePath).Length);
                ProcessCommands();
            }

            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                if (ex.InnerException != null)
                    LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.InnerException.Message);
            }
            finally
            {
                tcpClient.Close();
            }

        }
        void SendString(string stringToSend)
        {
            byte[] stringToSendInBytes = Encoding.ASCII.GetBytes(stringToSend);
            sslStream.Write(stringToSendInBytes);
            sslStream.Flush();
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "sent message = " + stringToSend);

        }

        string ReceiveString()
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                // Check for EOF.
                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
            } while (bytes != 0);
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
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
    }
}
