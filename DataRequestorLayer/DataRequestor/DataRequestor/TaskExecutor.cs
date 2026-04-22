using Encryption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestor
{
    public class TaskExecutor:ConnectionInitializer
    {
        public TaskExecutor() : base() { }

        public bool PushFileContent(string atmIP, string fileName, byte[] data, string cashDB, string txDB, int timeOut)
        {
            bool isSuccess = false;
            try
            {
                List<string> RequestsInfo = FilterRequest(new List<string> { atmIP }, true);
                List<string> parts = Path.GetFileNameWithoutExtension(fileName).Split('_').ToList();
                DateTime creationDate = DateTime.ParseExact(parts[1], "ddMMyyyyHHmmss", CultureInfo.InvariantCulture);
                int fileSize = Convert.ToInt32(parts[5]);
                int fileTypeId = Convert.ToInt32(parts[3]);
                //if (fileTypeId == 2)
                //{
                //    int c = 0;
                //}
                int sequenceNumber = Convert.ToInt32(parts[4]);
                bool isTx = fileTypeId == 1 ? false : true;
                for (int i = 0; i < RequestsInfo.Count; i++)
                {
                    if (!string.IsNullOrEmpty(RequestsInfo[i]))
                    {
                        string temp = string.Empty;
                        temp = new string(RequestsInfo[i].TrimEnd(',').ToCharArray());
                        DBServerInfo server = new DBServerInfo
                        {
                            ServerConnection = this.DBServers[i].ServerConnection,
                            ServerCredentials = this.DBServers[i].ServerCredentials
                        };
                        //AtmTask atmTask = new AtmTask(atmIP, fileName, creationDate, DateTime.Now, data, taskTypeId);
                        string connStr = Cryptic.DecryptString(server.ServerConnection, Helper.ConstractKey(false)).TrimEnd('\0') + Cryptic.DecryptString(server.ServerCredentials, Helper.ConstractKey(false)).TrimEnd('\0');

                        List<SqlParameter> sqlParams = new List<SqlParameter>
                        {
                            new SqlParameter { ParameterName = "fileCreationTime", SqlDbType = SqlDbType.DateTime, Value = creationDate },
                            new SqlParameter { ParameterName = "parsed", SqlDbType = SqlDbType.Int, Value = 0 },
                            new SqlParameter { ParameterName = "bytes_sent", SqlDbType = SqlDbType.Int, Value = fileSize },
                            new SqlParameter { ParameterName = "file_name", SqlDbType = SqlDbType.VarChar, Value = fileName },
                            new SqlParameter { ParameterName = "Atm_Id", SqlDbType = SqlDbType.VarChar, Value = temp },
                            new SqlParameter { ParameterName = "content", SqlDbType = SqlDbType.VarBinary, Value = data },
                            new SqlParameter { ParameterName = "file_type_id", SqlDbType = SqlDbType.BigInt, Value = fileTypeId },
                            new SqlParameter { ParameterName = "download_time", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now },
                            new SqlParameter { ParameterName = "end_time", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now },
                            new SqlParameter { ParameterName = "status", SqlDbType = SqlDbType.VarChar, Value = "downloadedParsePending" },
                            new SqlParameter { ParameterName = "user", SqlDbType = SqlDbType.Int, Value = 1 },
                            new SqlParameter { ParameterName = "unZip_file_size", SqlDbType = SqlDbType.Int, Value = fileSize },
                            new SqlParameter { ParameterName = "retry_count", SqlDbType = SqlDbType.Int, Value = 10 },
                            new SqlParameter { ParameterName = "seq", SqlDbType = SqlDbType.Int, Value = sequenceNumber },
                            new SqlParameter { ParameterName = "StatementType", SqlDbType = SqlDbType.VarChar, Value = "Update" },
                            new SqlParameter { ParameterName = "cashDB", SqlDbType = SqlDbType.VarChar, Value = cashDB },
                            new SqlParameter { ParameterName = "txDB", SqlDbType = SqlDbType.VarChar, Value = txDB }
                        };
                        var response = ConnectAndExecute(connStr, "AddOrUpdateTask", sqlParams);
                        if (response != null && response.ToString() == "success") isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                //LogTask.LogMonoActivityTask("PushFileContent", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                //Console.WriteLine(ex.Message);
            }
            return isSuccess;
        }
    }
}
