using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;

using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM360
{
    public partial class ATM360 : ServiceBase
    {
        string hostname = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("hostname", "");
        string port = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("port", "");
        string logFilePath = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("logFilePath", "");
        string lastProcessedSystemDate = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("lastProcessedSystemDate", "");
        string chunkFilePath = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("chunkFilePath", "");
        // string thirdSourceChunkFilePath;
        public static string tempFolderPath = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("tempFolderPath", "")+"\\";
        //string processedFolderPath = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\ATM360").GetValue("processedFolderPath", "");

        Timer timerDoWork;
        Timer timerSchedular;
        Timer timerUploader;

        public ATM360()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timerSchedular = new Timer(Schedular, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
        }

        private void Schedular(object state)
        {
            try
            {
                timerDoWork = new Timer(DoWork, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                timerUploader = new Timer(DoUpload, null, new TimeSpan(0, 0, 40), new TimeSpan(0, 0, 0, 0, -1));
            }
            catch (Exception ex)
            {

            }


        }
        protected override void OnStop()
        {
        }
        protected void DoWork(object state)
        {
            timerDoWork.Change(-1, -1);
            try
            {
                if (!Directory.Exists(tempFolderPath))
                    Directory.CreateDirectory(tempFolderPath);

                if (!Directory.Exists(logFilePath))
                    Directory.CreateDirectory(logFilePath);

                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\ATM360_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : ATM360 1.0.0.0, Build Date 12-Jun-2016");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");

                DoFileParse();


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

        
        private void DoFileParse()
        {

            //================================Read From Reg Again to get updated last read pointer values==================================================


            string sourceFilePath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", "sourceFilePath", "");
            string sourceFilePathReadPointer = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", "sourceFilePathReadPointer", "0");
            if (sourceFilePathReadPointer.Length == 0)
                sourceFilePathReadPointer = "0";
            string LastProcessedSourceFilePath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", "LastProcessedSourceFilePath", "");

            //string thirdSourceFilePath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", "ThirdAppPath", "");
            //string thirdSourceFilePointer = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", "ThirdAppReadPointer", "0");
            //if (thirdSourceFilePointer.Length == 0)
            //    thirdSourceFilePointer = "0";
            //string thirdSourceLastProcessedFilePath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", "LastProcessedThirdAppPath", "");
            //================================Read From Reg Again to get updated last read pointer values==================================================

            // InitializeKeyLookup();
            //LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Key Lookup Initialized");

            if (chunkFilePath.Length > 0)
                try
                {
                    Parse(sourceFilePath, LastProcessedSourceFilePath, sourceFilePathReadPointer, "sourceFilePathReadPointer", "LastProcessedSourceFilePath", chunkFilePath);
                }
                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                }
            //if (thirdSourceFilePath.Length > 0)
            //    try
            //    {
            //        Parse(thirdSourceFilePath, thirdSourceLastProcessedFilePath, thirdSourceFilePointer, "ThirdAppReadPointer", "LastProcessedThirdAppPath", thirdSourceChunkFilePath);
            //    }
            //    catch (Exception ex)
            //    {
            //        LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            //    }



        }
        private string ReadFileAsString(string sourceFilePath, string lastReadPosition, ref long fileLength)
        {
            FileStream fileStream = null;
            string data = null;
            StringBuilder builder = new StringBuilder();
            if (sourceFilePath.Length > 0)
            {
                byte[] fileData = new byte[1024];
                try
                {
                    fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
                    fileLength = fileStream.Length;
                    //fileStream.Seek(long.Parse(lastReadPosition), SeekOrigin.Current);

                    long tempLastReadPosition = long.Parse(lastReadPosition);
                    if (tempLastReadPosition > fileLength)
                        fileStream.Seek(0, SeekOrigin.Current);
                    else
                        fileStream.Seek(tempLastReadPosition, SeekOrigin.Current);

                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(fileData, 0, 1023)) > 0)
                        builder.Append(Encoding.ASCII.GetString(fileData, 0, bytesRead));
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Close();
                }
                data = builder.ToString();
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

        private void Parse(string fileToParse, string lastProcessedFile, string lastReadPointer, string fileToParseRegKey, string lastPrcoessedFileRegKey, string chunkFilePath)
        {
            long fileLength = 0;
            string generatedFileName = null;
            string data = null;
            generatedFileName = fileToParse;
            try
            {
                if (generatedFileName != null) //Null when start of pattern is ?.
                {
                    LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "File name generated " + generatedFileName);
                    if (File.Exists(generatedFileName))
                    {
                        if (generatedFileName != lastProcessedFile)
                            lastReadPointer = "0";
                        data = ReadFileAsString(generatedFileName, lastReadPointer, ref fileLength);
                        if (data.Length > 0)
                        {

                            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", fileToParseRegKey, fileLength);
                            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\ATM360", lastPrcoessedFileRegKey, generatedFileName);
                            if (chunkFilePath.Length > 0)
                            {
                                string chunkFileCompletePath = chunkFilePath + "\\chunk_" + DateTime.Now.ToString("ddMMyyyyHHmmss")+"_"+data.Length;
                                File.AppendAllText(chunkFileCompletePath, data);
                               
                                //ZipFile.CreateFromDirectory(chunkFilePath,chunkFileCompletePath + ".zip");
                                CreateZipFile(chunkFileCompletePath);
                                File.Delete(chunkFileCompletePath);
                            }
                            //LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to search file for keylookup records");
                            //FindAndNotify(data);
                        }
                        else
                        {
                            LogableTask.LogMonoActivityTask("DoFileParse", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Empty data returned");
                        }
                    }


                }
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
                DirectoryInfo dirInfo = new DirectoryInfo(tempFolderPath);
                FileInfo[] fileInfos = dirInfo.GetFiles("*.zip");
                foreach (FileInfo fileInfo in fileInfos)
                {
                    LogableTask.LogMonoActivityTask("DoUpload", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to upload file "+fileInfo.FullName);
                    Communicator communicator = new Communicator();
                    communicator.Talk(hostname, port, fileInfo.FullName);

                }

            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("DoWork", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                timerUploader.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 1, 0));
            }
        }
    }
}
