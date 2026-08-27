using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServicesDAL;

namespace DailyFeedMerger.Models
{
    public class FTPManager
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
            DeleteFileAtRemoteEnd(ftpServerIP + "/" + newFilename);

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
        private void DeleteFileAtRemoteEnd(string remoteFilePath)
        {
            LogableTask task = LogableTask.NewTask("DeleteFileAtRemoteEnd");
            FtpWebResponse response = null;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(remoteFilePath)); //Get the object used to communicate with the server.

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                request.KeepAlive = false;
                response = (FtpWebResponse)request.GetResponse();
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, String.Format("File: {0} successfully deleted from FTP", remoteFilePath));
                //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Archival Process complete");
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                //throw new Exception("An exception occured while deleting file");
            }
            finally
            {
                if (response != null)
                    response.Close();

                task.EndTask();
            }
        }
        public void UploadFile(string filePath)
        {
            FileInfo fileInf = new FileInfo(filePath);
            string uri = ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            DeleteFileAtRemoteEnd(uri);
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
}
