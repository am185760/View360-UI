using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.IO;
using System.Data.SqlClient;

namespace Encryption
{
    public static class Helper
    {
        public static string GetValueFromRegistry(string keyName, string value)
        {
            string val = (string)Microsoft.Win32.Registry.GetValue(keyName, value, "");
            return val;
        }

        public static string GetKeySecondaryPart(string ZipFilePath, string password)
        {
            ZipFile file = null;
            string EncPK = "";
            try
            {
                FileStream fs = File.OpenRead(ZipFilePath);
                file = new ZipFile(fs);

                if (!String.IsNullOrEmpty(password))
                {
                    // AES encrypted entries are handled automatically
                    file.Password = password;
                }

                foreach (ZipEntry zipEntry in file)
                {
                    if (zipEntry.IsFile && zipEntry.Name.Equals("Seckey.txt"))
                    {
                        Stream zipStream = file.GetInputStream(zipEntry);
                        StreamReader reader = new StreamReader(zipStream);
                        EncPK = reader.ReadToEnd();
                    }
                }
                return EncPK;
            }
            finally
            {
                if (file != null)
                {
                    file.IsStreamOwner = true;
                    file.Close();
                }
            }
        }
    
        public static string ConstractKey(bool isMasterKey)
        {
            string RegKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\EV360";
            string ConnectionZipPass = GetValue(GetValueFromRegistry(RegKey, "ConnectionZip"));
            string MasterZipPass = GetValue(GetValueFromRegistry(RegKey, "MasterZip"));

            string Key;
            if (isMasterKey)
            {
                if (String.IsNullOrEmpty(Cryptic.MasterZipFile))
                {
                    string reg = GetValue(GetValueFromRegistry(RegKey, "ZipDir"));
                    Cryptic.MasterZipFile = Path.Combine(reg, "MasterZip.zip");
                }
                Key = "P+" + GetValue(GetKeySecondaryPart(Cryptic.MasterZipFile, MasterZipPass)); ;
            }
            else
            {
                if (String.IsNullOrEmpty(Cryptic.ConnectionZipFile))
                {
                    string reg = GetValue(GetValueFromRegistry(RegKey, "ZipDir"));
                    Cryptic.ConnectionZipFile = Path.Combine(reg, "ConnectionZip.zip");
                }
                Key = "P+" + GetValue(GetKeySecondaryPart(Cryptic.ConnectionZipFile, ConnectionZipPass));
            }
            return Key;
        }

        public static string GetEncryptedDataKeyFromDB(string ConnectionStr)
        {
            string key = "";
            SqlConnection connection;
            SqlCommand command;
            string sql = "select d_key from dbo.app_setting";
            connection = new SqlConnection(ConnectionStr);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                key = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open connection ! " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return key;
        }

        public static string ASCIItoHEX(string ascii)
        {
            string hex = "";
            for (int i = 0; i < ascii.Length; i++)
            {
                char ch = ascii[i];
                int tmp = (int)ch;
                string part = tmp.ToString("X"); ;
                hex += part;
            }
            return hex;
        }
        public static String GetValue(String hex)
        {
            String ascii = "";
            for (int i = 0; i < hex.Length; i += 2)
            {
                String part = hex.Substring(i, 2);
                char ch = (char)Convert.ToInt32(part, 16); ;
                ascii += ch;
            }
            return ascii;
        }

        /// <summary>
        /// Method that compress all the files inside a folder (non-recursive) into a zip file.
        /// </summary>
        /// <param name="OutputFilePath"></param>
        /// <param name="CompressionLevel"></param>
        public static void CreateProtectedZipFile(string data,string OutputFilePath, string Password = null, int CompressionLevel = 9)
        {
            try
            {
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "Seckey.txt");
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (FileStream fs = File.Create(fileName))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(data);
                    fs.Write(title, 0, title.Length);
                }

                using (ZipOutputStream OutputStream = new ZipOutputStream(File.Create(OutputFilePath)))
                {
                    OutputStream.Password = Password;
                    OutputStream.SetLevel(CompressionLevel);
                    byte[] buffer = new byte[4096];

                    ZipEntry entry = new ZipEntry(Path.GetFileName(fileName));
                    entry.DateTime = DateTime.Now;
                    OutputStream.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(fileName))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            OutputStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                    OutputStream.Finish();
                    OutputStream.Close();
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    Console.WriteLine("File successfully compressed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);
            }
        }
    }
}
