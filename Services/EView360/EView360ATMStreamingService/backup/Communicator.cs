using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM360
{
    class Communicator
    {

        Socket socket;
        LogableTask task;
        string filename = null;
        long index = 0;
        public Communicator()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                    string[] parts=command.Split(';');
                  
                    filename = parts[0].Split('=')[1];
                    index= long.Parse(parts[1].Split('=')[1]); 
                    SendString("ready;");

                }
                else if (command.StartsWith("file-received"))
                {
                    File.Delete(ATM360.tempFolderPath +filename);
                    socket.Close();
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
                            socket.Send(fileData, 0, bytesRead, SocketFlags.None);
                        }
                    }
                    finally
                    {
                        if (fileStream != null)
                            fileStream.Close();
                    }
                }
                else if (command.StartsWith("quit") || command.Length==0)
                {
                    socket.Close();
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
                socket.Connect(hostname, int.Parse(port));
                SendString("download=" + Path.GetFileName(filePath) + "_" + new FileInfo(filePath).Length);
                ProcessCommands();
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("Talk", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

            }
            finally
            { }

        }
        void SendString(string stringToSend)
        {
            byte[] stringToSendInBytes = Encoding.ASCII.GetBytes(stringToSend);
            socket.Send(stringToSendInBytes);
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "sent message = " + stringToSend);

        }
        string ReceiveString()
        {
            byte[] buff = new byte[1024];
            int length = this.socket.Receive(buff, buff.Length, SocketFlags.None);
            string str = ASCIIEncoding.ASCII.GetString(buff, 0, length);
            while (this.socket.Available > 0 && length > 0)
            {
                length = socket.Receive(buff, buff.Length, SocketFlags.None);
                str += ASCIIEncoding.ASCII.GetString(buff, 0, length);
                Thread.Sleep(5 * 1000);
            }
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "received string = " + str);
            return str;
        }
    }
}
