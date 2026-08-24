using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Linq;
using System.IO.Compression;
using System.Text;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Web;
using System.Collections.Specialized;

namespace ATM360
{
    public partial class EView360ATMStreaming : ServiceBase
    {
        //FileSystemWatcher watcher = new FileSystemWatcher(@"C:\program files\ncr aptra\advance NDC\CCMSAgent");
        static string regKey = @"SOFTWARE\NCR\CCMSAgent";
        string countersFilePath = @"C:\program files\ncr aptra\advance NDC\CCMSAgent\counters.dll";
        string counters1FilePath = @"C:\program files\ncr aptra\advance NDC\CCMSAgent\counters1.dll";
        string logFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        public static string TransportQueuePath = AppDomain.CurrentDomain.BaseDirectory + "\\TransportQueue";
        public static string uploadedFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Uploaded";
        public static string processorPath = AppDomain.CurrentDomain.BaseDirectory + "\\Processor";
        public static string processedPath = AppDomain.CurrentDomain.BaseDirectory + "\\Processed";
        public static string backupPath = AppDomain.CurrentDomain.BaseDirectory + "\\Backup\\";

        public static readonly bool isSSLEnabled = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["isSSLEnabled"]);

        public static string hostname = null;
        int dataStreamingServerPort = 16328;
        string serverIP = null;
        int dataStreamingHeartBeatPort = 16329;
        int uploadRefreshInterval = 5;
        int cutOverIntervalDays = 5;
        int heartBeatRefreshInterval = 5;
        Timer timerCutOver;
        Timer timerDoWork;
        Timer timerSchedular;
        public static Timer timerUploader;
        public static Timer timerFileProcessor;

        Timer timerHeartBeat;

        public void OnDebug()
        {
            OnStart(null);
        }
        public EView360ATMStreaming()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timerSchedular = new Timer(Schedular, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));

        }

        private void DoInitFromRegistry()
        {
            hostname = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue("hostname", "");
            dataStreamingServerPort = int.Parse(Registry.LocalMachine.OpenSubKey(regKey).GetValue("DataStreaming_Port", "16328").ToString());
            serverIP = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue("ServerIP", "");
            dataStreamingHeartBeatPort = int.Parse(Registry.LocalMachine.OpenSubKey(regKey).GetValue("DataStreaming_HeartBeat_Port", "16329").ToString());

            uploadRefreshInterval = int.Parse(Registry.LocalMachine.OpenSubKey(regKey).GetValue("uploadRefreshInterval", "5").ToString());
            cutOverIntervalDays = int.Parse(Registry.LocalMachine.OpenSubKey(regKey).GetValue("CutOverInterval", "40").ToString());
            heartBeatRefreshInterval = int.Parse(Registry.LocalMachine.OpenSubKey(regKey).GetValue("HeartBeatDelay", "5").ToString());
        }
        private void Schedular(object state)
        {
            try
            {
                DoInitFromRegistry();
                timerDoWork = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                timerUploader = new Timer(DoUpload, null, new TimeSpan(0, 0, 16), new TimeSpan(0, 0, 0, 0, -1));
                timerCutOver = new Timer(DoCutOver, null, new TimeSpan(0, 0, 40), new TimeSpan(0, 0, 0, 0, -1));
                timerHeartBeat = new Timer(HeartBeat, null, new TimeSpan(0, 0, 40), new TimeSpan(0, 0, 0, 0, -1));
                timerFileProcessor = new Timer(FileProcessor, null, new TimeSpan(0, 0, 16), new TimeSpan(0, 0, 0, 0, -1));
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message);
            }
        }
        protected override void OnStop()
        {
            XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EView360ATMStreamingService{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
            LogableTask.LogMonoActivityTask("OnStop", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Warning, "Service Stopped");
        }
        protected void DoWork(object state)
        {
            timerDoWork.Change(-1, -1);
            try
            {
                if (!Directory.Exists(TransportQueuePath))
                    Directory.CreateDirectory(TransportQueuePath);

                if (!Directory.Exists(logFilePath))
                    Directory.CreateDirectory(logFilePath);

                if (!Directory.Exists(backupPath))
                    Directory.CreateDirectory(backupPath);

                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EView360ATMStreamingService{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EView360ATMStreamingService Version 1.0.0.0, Build Date 11-Feb-2023");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info,
                    string.Format("hostname:{0},logFilePath:{1},TransportQueuePath:{2},uploadRefreshInterval:{3},cutOverIntervalDays:{4}, heartBeatRefreshInterval:{5}",
                    hostname, logFilePath, TransportQueuePath, uploadRefreshInterval, cutOverIntervalDays, heartBeatRefreshInterval));
                ReadCounterFile(countersFilePath);
                ReadCounterFile(counters1FilePath);
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("DoWork", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                timerDoWork.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 1, 0));
            }
        }



        private string ReadFile(string sourceFilePath)
        {
            string data = null;

            if (sourceFilePath.Length > 0)
            {
                File.Move(sourceFilePath, sourceFilePath + "_");
                data = File.ReadAllText(sourceFilePath + "_", System.Text.Encoding.ASCII);
                File.Delete(sourceFilePath + "_"); //dangerous call.
            }
            return data;
        }

        static void CreateZipFile(string file)
        {
            LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to create Zipped file");
            FileStream fileStream = new FileStream(file + ".zip", FileMode.Create, FileAccess.Write);
            ZipOutputStream stream = new ZipOutputStream(fileStream);
            ZipEntry entry;
            entry = new ZipEntry(Path.GetFileName(file));
            byte[] filebytes = File.ReadAllBytes(file);
            entry.Size = filebytes.LongLength;
            stream.PutNextEntry(entry);
            stream.Write(filebytes, 0, filebytes.Length);
            stream.CloseEntry();
            stream.Close();
            LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Zipped Created Successufully.");
        }

        private void ReadCounterFile(string fileToRead)
        {
            string data = null;
            try
            {
                string currentMode = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue("currentMode", "");

                if (File.Exists(fileToRead) && currentMode!="supervisor")
                {
                    data = ReadFile(fileToRead);
                    if (data.Length > 0)
                    {
                        if (data.Length > 0)
                        {
                            string chunkFileCompletePath = TransportQueuePath + "\\Counters_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + data.Length + "_" + (fileToRead.Contains("1.dll") ? "2" : "1");
                            File.WriteAllText(chunkFileCompletePath, data, System.Text.Encoding.ASCII);
                            File.AppendAllText(backupPath + Path.GetFileName(fileToRead), data, System.Text.Encoding.ASCII);
                            LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File processed:"+ fileToRead);

                            //CreateZipFile(chunkFileCompletePath);
                            //File.Delete(chunkFileCompletePath);
                        }
                    }
                    else
                        LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Empty data returned");
                }
                else
                    LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File does not exists");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
        }

        protected void DoUpload(object state)
        {
            timerUploader.Change(-1, -1);
            try
            {
                Communicator communicator = new Communicator();
                communicator.Talk(serverIP, dataStreamingServerPort);


            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("DoWork", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                timerUploader.Change(new TimeSpan(0, uploadRefreshInterval, 0), new TimeSpan(0, 1, 0));

            }
            finally
            {
            }
        }


        protected void FileProcessor(object state)
        {
            timerFileProcessor.Change(-1, -1);
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(EView360ATMStreaming.TransportQueuePath);
                FileInfo[] fileInfos = dirInfo.GetFiles().OrderBy(f => f.CreationTime).ToArray();
                foreach (FileInfo fileInfo in fileInfos)
                    FileSplitter(fileInfo.FullName);
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("FileProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

            }
            finally
            {
                timerFileProcessor.Change(new TimeSpan(0, 1, 0), new TimeSpan(0, 1, 0));
            }
        }
        public static string GZipStringCompress(string s)
        {
            var bytes = Encoding.Unicode.GetBytes(s);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }
                return Convert.ToBase64String(mso.ToArray());
            }
        }

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

        public static byte[] Compress(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            // Read the last 4 bytes to get the length
            byte[] lengthBuffer = new byte[4];
            Array.Copy(data, data.Length - 4, lengthBuffer, 0, 4);
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
        private void FileSplitter(string fileName)
        {
            int bytesRead = 0;
            byte[] fileData = new byte[1024];
            string outputFilename = null;
            long totalSize = 0;
            int totalChunks = 0;
            List<byte[]> list = new List<byte[]>();

            if (!Directory.Exists(EView360ATMStreaming.processorPath))
                Directory.CreateDirectory(EView360ATMStreaming.processorPath);

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            fileStream.Seek(0, SeekOrigin.Current);

            // List<byte[]> listFileBytes = new List<byte[]>();
            while ((bytesRead = fileStream.Read(fileData, 0, 1023)) > 0)
            {
                //fileData = new byte[1024];
                //temp = System.Text.Encoding.Default.GetBytes(Path.GetFileName(fileName) + "_" + seq + "@");
                //temp.CopyTo(fileData, 0);
                //byte[] compressedFileData = Compress(fileData, fileData.Length);
                //file name format {Counters_DateTime_CompressChunkSize_FileType_Sequence_TotalSize_TotalChunks}
                totalSize += fileData.Length;
                list.Add(fileData);
                fileData = new byte[1024];
            }
            fileStream.Close();
            //string outputFilename = $"{EView360ATMStreaming.processorPath}\\{Path.GetFileName(fileName)}_{list[i][0]}_{totalSize}_{totalChunks}";
            totalChunks = list.Count;
            for (int i = 0; i < totalChunks; i++)
            {
                byte[] data = Compress(list[i]);
                outputFilename = $"{EView360ATMStreaming.processorPath}\\{Path.GetFileName(fileName)}_{i + 1}_{data.Length}_{totalChunks}";
                File.WriteAllBytes(outputFilename, data);
            }
            File.Delete(fileName);
        }

        //private void FileSplitter(string fileName)
        //{
        //    int seq = 0;
        //    int bytesRead = 0;
        //    int totalChunks = 0;
        //    byte[] fileData = new byte[1024];
        //    byte[] temp = System.Text.Encoding.Default.GetBytes(Path.GetFileName(fileName) + "@");
        //    string tempFileName = string.Empty;

        //    temp.CopyTo(fileData, 0);
        //    if (!Directory.Exists(EView360ATMStreaming.processorPath))
        //        Directory.CreateDirectory(EView360ATMStreaming.processorPath);

        //    FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    fileStream.Seek(0, SeekOrigin.Current);

        //    if (totalChunks == 0)
        //    {
        //        while ((bytesRead = fileStream.Read(fileData, temp.Length, 1023 - temp.Length)) > 0)
        //        {
        //            byte[] compressedFileData = Compress(fileData, fileData.Length);
        //            tempFileName = Path.GetFileName(fileName);
        //            tempFileName = tempFileName.Replace('_' + fileName.Split('_')[2] + '_', '_' + compressedFileData.Length.ToString() + '_');
        //            tempFileName = tempFileName + "_" + totalChunks + '_' + fileName.Split('_')[2] + '_' + totalChunks;
        //            totalChunks += 1;
        //            if (totalChunks > 0)
        //            {
        //                fileData = new byte[1024];
        //                temp = System.Text.Encoding.Default.GetBytes(Path.GetFileName(tempFileName) + "@");
        //                temp.CopyTo(fileData, 0);
        //            }
        //        }
        //    }
        //    fileStream.Close();

        //    fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    fileStream.Seek(0, SeekOrigin.Current);

        //    bytesRead = 0;
        //    fileData = new byte[1024];
        //    tempFileName = Path.GetFileName(fileName);
        //    tempFileName = tempFileName.Replace('_' + fileName.Split('_')[2] + '_', '_' + Compress(fileData, fileData.Length).Length.ToString() + '_');
        //    tempFileName = tempFileName + "_" + seq + '_' + fileName.Split('_')[2] + '_' + totalChunks;
        //    temp = System.Text.Encoding.Default.GetBytes(Path.GetFileName(tempFileName) + "@");
        //    temp.CopyTo(fileData, 0);

        //    //fileName=Counters_12072023161519_190079_1
        //    while ((bytesRead = fileStream.Read(fileData, temp.Length, 1023 - temp.Length)) > 0)
        //    {
        //        byte[] compressedFileData = Compress(fileData, fileData.Length);
        //        //byte[] decompressedFileData = Decompress(compressedFileData);

        //        tempFileName = Path.GetFileName(fileName);
        //        tempFileName = tempFileName.Replace('_' + fileName.Split('_')[2] + '_', '_' + compressedFileData.Length.ToString() + '_');
        //        tempFileName = tempFileName + "_" + seq + '_' + fileName.Split('_')[2] + '_' + totalChunks;


        //        //file name format {Counters_DateTime_CompressChunkSize_FileType_Sequence_TotalSize_TotalChunks}
        //        File.WriteAllBytes(EView360ATMStreaming.processorPath + "\\" + tempFileName, compressedFileData);

        //        seq++;
        //        if (seq > 0)
        //        {
        //            fileData = new byte[1024];
        //            tempFileName = tempFileName.Replace('_' + (seq - 1).ToString() + '_', '_' + seq.ToString() + '_');
        //            temp = System.Text.Encoding.Default.GetBytes(Path.GetFileName(tempFileName) + "@");
        //            temp.CopyTo(fileData, 0);
        //        }
        //    }

        //    fileStream.Close();
        //    File.Delete(fileName);
        //}


        protected void HeartBeat(object state)
        {
            timerHeartBeat.Change(-1, -1);
            try
            {
                Communicator communicator = new Communicator();
                communicator.SendHeartBeat(serverIP, dataStreamingHeartBeatPort);
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HeartBeat", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                timerHeartBeat.Change(new TimeSpan(0, 0, heartBeatRefreshInterval), new TimeSpan(0, 1, 0));
            }
        }




        void DoCutOver(object state)
        {
            timerCutOver.Change(-1, -1);
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(logFilePath);
                FileInfo[] fileInfos = dirInfo.GetFiles();
                DateTime cutOverDate = DateTime.Today.AddDays(-cutOverIntervalDays);
                foreach (FileInfo fileInfo in fileInfos)
                {
                    if (fileInfo.LastWriteTime < cutOverDate)
                    {
                        File.Delete(fileInfo.FullName);
                        LogableTask.LogMonoActivityTask("DoWork", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File " + fileInfo.FullName + " having modified date " + fileInfo.LastWriteTime + " deleted successfully");
                    }
                }
                LogableTask.LogMonoActivityTask("DoWork", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep for " + cutOverIntervalDays + " days");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("DoWork", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                timerCutOver.Change(new TimeSpan(cutOverIntervalDays * 24, 0, 0), new TimeSpan(0, 0, 0, 0, -1));
            }
        }
    }
}
