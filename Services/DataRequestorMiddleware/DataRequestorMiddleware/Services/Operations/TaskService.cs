using Encryption;
using EView360Models.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRequestor;
using EView360Models.ViewModels;
using ICSharpCode.SharpZipLib.Zip;

namespace DataRequestorMiddleware.Services.Operations
{
    public class TaskService
    {
        //private Executor _executor { get; set; }
        //public TaskService()
        //{
        //    _executor = new();
        //}

        public void GetAtmTask(Executor _executor, DateTime fromDate, DateTime toDate, string filter, string orderBy, int offset, int rowCount, List<string> atmIds, bool readFromCache, int? archiveYear = null)
        {
            if (atmIds?.Count > 0)
            {
                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@FromDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = fromDate
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@ToDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = toDate
                };

                SqlParameter param4 = new SqlParameter()
                {
                    ParameterName = "@ArchiveYear",
                    SqlDbType = SqlDbType.VarChar,
                    Value = archiveYear != null ? '_' + archiveYear.ToString() : ""
                };

                SqlParameter param5 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = filter == null ? "" : filter
                };

                SqlParameter orderByParam = new SqlParameter()
                {
                    ParameterName = "@OrderBy",
                    SqlDbType = SqlDbType.VarChar,
                    Value = orderBy == null ? "" : orderBy
                };

                SqlParameter param6 = new SqlParameter()
                {
                    ParameterName = "@offset",
                    SqlDbType = SqlDbType.Int,
                    Value = offset
                };

                SqlParameter param7 = new SqlParameter()
                {
                    ParameterName = "@RowCount",
                    SqlDbType = SqlDbType.Int,
                    Value = rowCount
                };

                _executor.ExecuteDSRequestForDataSet<DataTableResult>("GetAtmTaskSchedule", new SqlParameter[] { param2, param3, param4, param5, orderByParam, param6, param7 }, atmIds, string.Join(",", atmIds), readFromCache);
            }
        }

        public void GetAtmTaskDashboard(string noteSetTypeFilter, string filter, List<string> atmIds, Executor _executor, string? archiveYear = null)
        {
            if (atmIds?.Count > 0)
            {
                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@NoteSetFilter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = noteSetTypeFilter
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = filter
                };

                SqlParameter param4 = new SqlParameter()
                {
                    ParameterName = "@OrderBy",
                    SqlDbType = SqlDbType.VarChar,
                    Value = "title asc"
                };

                SqlParameter param5 = new SqlParameter()
                {
                    ParameterName = "@ArchiveYear",
                    SqlDbType = SqlDbType.VarChar,
                    Value = archiveYear != null ? '_' + archiveYear : ""
                };
                _executor.ExecuteDSRequest<DataTableResult>("GetTasksDashboard", new SqlParameter[] { param2, param3, param4, param5 }, atmIds, string.Join(",", atmIds), false);
            }
        }

        public List<string> GetDataFile(string taskId, string fileTypeId, string atmId, string taskTypeId, ref string errorMsg)
        {
            List<string> dataFiles = new();

            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@TaskId",
                SqlDbType = SqlDbType.VarChar,
                Value = taskId
            };

            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "@FileTypeId",
                SqlDbType = SqlDbType.VarChar,
                Value = fileTypeId
            };

            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "@TaskTypeId",
                SqlDbType = SqlDbType.VarChar,
                Value = taskTypeId
            };

            Executor _executor = new Executor(); 
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetDataFile", new SqlParameter[] { param1, param2, param3 }, new List<string> { atmId }, atmId);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                errorMsg = result.ExceptionMessage;
            }
            if (result?.Table?.Rows?.Count > 0)
            {
                if (taskTypeId == "25") // zip File
                {
                    DataRow singleRow = result.Table.Rows[0];

                    //byte[] thisTest = GetUnCompressedBytes((byte[])singleRow["encoded"]);
                    string decodedContent = GetDecodedString(!DBNull.Value.Equals(singleRow["DataFile"]) ? (byte[])singleRow["DataFile"] : new byte[0]);
                    dataFiles.Add(decodedContent);
                }
                else
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        dataFiles.Add(!DBNull.Value.Equals(row["DataFile"]) ? row["DataFile"].ToString() : string.Empty);
                    }
                }
            }
            return dataFiles;
        }

        public string GetDecodedString(byte[] data)
        {
            int uncompressedLength;
            return Encoding.ASCII.GetString(GetUnCompressedBytes(data, out uncompressedLength), 0, uncompressedLength);
        }

        public static byte[] GetUnCompressedBytes(byte[] data, out int uncompressedLength)
        {
            MemoryStream ms = null;

            ms = new MemoryStream(data);

            ZipInputStream compressedBytes = new ZipInputStream(ms);
            //string pwd = System.Configuration.ConfigurationManager.AppSettings["zipPassword"];
            //if (pwd.Length > 0)
            //  compressedBytes.Password = pwd;
            ZipEntry entry = compressedBytes.GetNextEntry();
            byte[] uncompressedBytes = new byte[entry.Size];
            byte[] tempBuffer = new byte[2048];
            MemoryStream tempMemoryStream = new MemoryStream();
            int bytesRead = 0;

            if (uncompressedBytes.Length > 0)
            {
                do
                {
                    bytesRead = compressedBytes.Read(tempBuffer, 0, tempBuffer.Length);
                    tempMemoryStream.Write(tempBuffer, 0, bytesRead);
                } while (bytesRead > 0);
            }

            compressedBytes.Close();
            ms.Close();
            uncompressedLength = (int)tempMemoryStream.Length;

            return tempMemoryStream.GetBuffer();
        }

        public List<AtmTaskViewModel> CheckDataFileExistForTask(List<AtmTaskViewModel> atmTaskViews, ref string errorMsg, int? archiveYear = null)
        {
            List<AtmTaskViewModel> _atmTaskViews = new();
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@TaskId",
                SqlDbType = SqlDbType.VarChar,
                Value = string.Join(",", atmTaskViews.Select(x => x.TaskId))
            };

            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "@ArchiveYear",
                SqlDbType = SqlDbType.VarChar,
                Value = archiveYear != null ? '_' + archiveYear.ToString() : ""
            };

            Executor _executor = new Executor(); 
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("IfDataFileExistForTask", new SqlParameter[] { param1, param2 }, atmTaskViews.Select(x => x.AtmId.ToString()).ToList(), false);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                errorMsg = result.ExceptionMessage;
            }
            if (result?.Table?.Rows?.Count > 0)
            {
                foreach (DataRow row in result.Table.Rows)
                {
                    AtmTaskViewModel atmTaskView = new()
                    {
                        TaskId = !DBNull.Value.Equals(row["task_id"]) ? Convert.ToInt64(row["task_id"]) : 0,
                        DataFileCount = !DBNull.Value.Equals(row["DataFileCount"]) ? Convert.ToInt32(row["DataFileCount"]) : 0,
                        DataFileCount2 = !DBNull.Value.Equals(row["DataFileCount2"]) ? Convert.ToInt32(row["DataFileCount2"]) : 0,
                        FileTypeId = !DBNull.Value.Equals(row["file_type_id"]) ? Convert.ToInt64(row["file_type_id"]) : null,
                    };
                    atmTaskView.DataFileCount += atmTaskView.DataFileCount2;
                    _atmTaskViews.Add(atmTaskView);
                }
            }

            return _atmTaskViews;
        }


        public List<AtmTaskViewModel> BuildAtmTask(DataTable dataTable)
        {
            List<AtmTaskViewModel> atmTaskViews = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    AtmTaskViewModel atmTaskView = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        AtmId = !DBNull.Value.Equals(row["ATM_ID"]) ? Convert.ToInt64(row["ATM_ID"]) : 0,
                        EndTime = !DBNull.Value.Equals(row["end_time"]) ? Convert.ToDateTime(row["end_time"]) : null,
                        AtmType = !DBNull.Value.Equals(row["atm_type"]) ? row["atm_type"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        AtmIP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        AtmTitle = !DBNull.Value.Equals(row["TITLE"]) ? row["TITLE"].ToString() : string.Empty,
                        TaskId = !DBNull.Value.Equals(row["task_id"]) ? Convert.ToInt64(row["task_id"]) : 0,
                        FileTypeId = !DBNull.Value.Equals(row["file_type_id"]) ? Convert.ToInt64(row["file_type_id"]) : null,
                        CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : DateTime.Now,
                        TaskTypeId = !DBNull.Value.Equals(row["task_type_id"]) ? Convert.ToInt64(row["task_type_id"]) : 0,
                        TaskTypeName = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                        BytesTransferred = !DBNull.Value.Equals(row["bytes_transferred"]) ? Convert.ToInt32(row["bytes_transferred"]) : 0,
                        Parsed = !DBNull.Value.Equals(row["parsed"]) ? Convert.ToBoolean(row["parsed"]) : false,
                        DownloadTime = !DBNull.Value.Equals(row["download_time"]) ? Convert.ToDateTime(row["download_time"]) : null,
                        Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                        LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? Convert.ToDateTime(row["last_invoked"]) : null,
                        FailureReason = !DBNull.Value.Equals(row["reason"]) ? row["reason"].ToString() : string.Empty,
                        FailureReasonFull = !DBNull.Value.Equals(row["failure_reason_full"]) ? row["failure_reason_full"].ToString() : string.Empty,
                        FileTypeTitle = !DBNull.Value.Equals(row["file_type_title"]) ? row["file_type_title"].ToString() : string.Empty,
                        UserName = !DBNull.Value.Equals(row["user_login"]) ? row["user_login"].ToString() : string.Empty
                    };

                    atmTaskViews.Add(atmTaskView);
                }
            }
            return atmTaskViews;
        }

        public List<AtmTaskViewModel> BuildAtmTaskDashboard(DataTable dataTable)
        {
            List<AtmTaskViewModel> atmTaskViews = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    AtmTaskViewModel atmTaskView = new()
                    {
                        AtmId = !DBNull.Value.Equals(row["ATM_ID"]) ? Convert.ToInt32(row["ATM_ID"]) : 0,
                        LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? Convert.ToDateTime(row["last_invoked"]) : null,
                        AtmType = !DBNull.Value.Equals(row["atm_type"]) ? row["atm_type"].ToString() : string.Empty,
                        AtmIP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        FileTypeTitle = !DBNull.Value.Equals(row["file_type_title"]) ? row["file_type_title"].ToString() : string.Empty,
                        AtmTitle = !DBNull.Value.Equals(row["TITLE"]) ? row["TITLE"].ToString() : string.Empty,
                        CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : DateTime.Now,
                        TaskTypeName = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                        Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                        EndTime = !DBNull.Value.Equals(row["end_time"]) ? Convert.ToDateTime(row["end_time"]) : null,
                        RetryRemaining = !DBNull.Value.Equals(row["retry_remaining"]) ? Convert.ToInt32(row["retry_remaining"]) : 0,
                        FailureReason = !DBNull.Value.Equals(row["failure_reason"]) ? row["failure_reason"].ToString() : string.Empty,
                    };
                    atmTaskViews.Add(atmTaskView);
                }
            }
            return atmTaskViews;
        }


        public string UpdateTaskStatus(long taskId, long? fileTypeId, string status, List<string> atmIds)
        {
            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Status",
                    SqlDbType = SqlDbType.VarChar,
                    Value = status
                };
                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@TaskId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = taskId
                };
                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@FileTypeId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = fileTypeId
                };

                Executor _executor = new Executor(); 
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("UpdateTaskStatus", new SqlParameter[] { param1, param2, param3 }, atmIds, string.Join(",", atmIds), false);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                    return result.ExceptionMessage;

                if (result?.Table?.Rows?.Count > 0 && !DBNull.Value.Equals(result?.Table?.Rows?[0]["Response"]))
                    return result.Table.Rows[0]["Response"].ToString();
            }
            return "Error";
        }

        public string ReparseTask(long taskId, List<string> atmIds)
        {
            if (atmIds?.Count > 0)
            {
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@taskID",
                    SqlDbType = SqlDbType.BigInt,
                    Value = taskId
                };

                Executor _executor = new Executor(); 
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("Reparse", new SqlParameter[] { param }, atmIds, string.Join(",", atmIds), false);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                    return result.ExceptionMessage;

                if (result?.Table?.Rows?.Count > 0 && !DBNull.Value.Equals(result?.Table?.Rows?[0]["Response"]))
                    return result.Table.Rows[0]["Response"].ToString();
            }
            return "Error";
        }

        public List<AtmTaskViewModel> CheckTaskExistForAtms(string taskTypeId, string fileTypeId, List<string> atmIds, ref string errorMsg)
        {
            List<AtmTaskViewModel> atmTaskViews = new();

            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@atmIds",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };

                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@TaskTypeId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = taskTypeId
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@FileTypeId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = fileTypeId
                };

                Executor _executor = new Executor(); 
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("IfTaskExistForAtm", new SqlParameter[] { param1, param2, param3 }, atmIds, string.Join(",", atmIds), false);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                else
                {
                    if (result?.Table?.Rows?.Count > 0)
                    {
                        foreach (DataRow row in result.Table.Rows)
                        {
                            AtmTaskViewModel atmTaskView = new()
                            {
                                AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                                TaskExist = !DBNull.Value.Equals(row["TaskExist"]) ? Convert.ToBoolean(row["TaskExist"]) : false
                            };
                            atmTaskViews.Add(atmTaskView);
                        }
                    }
                }
            }
            return atmTaskViews;
        }

        public string CreateConfigurationTask(long createdBy, List<string> atmIds)
        {
            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@atmIds",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };
                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@CreatedBy",
                    SqlDbType = SqlDbType.BigInt,
                    Value = createdBy
                };

                Executor _executor = new Executor(); 
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("CreateConfigurationTask", new SqlParameter[] { param1, param2 }, atmIds, string.Join(",", atmIds), false);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                    return result.ExceptionMessage;

                if (result?.Table?.Rows?.Count > 0 && !DBNull.Value.Equals(result?.Table?.Rows?[0]["Response"]))
                    return result.Table.Rows[0]["Response"].ToString();
            }
            return "Error";
        }

        public string CreateDownloadFileTask(long createdBy, long fileTypeId, string atmId)
        {
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@Atm_Id",
                SqlDbType = SqlDbType.VarChar,
                Value = atmId
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "@CreatedBy",
                SqlDbType = SqlDbType.VarChar,
                Value = createdBy.ToString()
            };
            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "@FileTypeId",
                SqlDbType = SqlDbType.VarChar,
                Value = fileTypeId.ToString()
            };

            Executor _executor = new Executor(); 
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("CreateDownloadFileTask", new SqlParameter[] { param1, param2, param3 }, new List<string>() { atmId }, atmId, false);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return result.ExceptionMessage;

            if (result?.Table?.Rows?.Count > 0 && !DBNull.Value.Equals(result?.Table?.Rows?[0]["Response"]))
                return result.Table.Rows[0]["Response"].ToString();
            return "Error";
        }
        public List<string> GetAllTaskStatus(List<string> taskTypes, ref string error)
        {
            List<string> taskStatusLst = new();

            try
            {
                string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
                connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");

                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@statusList",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", taskTypes)
                };

                DataTable result = new();
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetAllTaskStatus", conn);
                    cmd.Parameters.AddRange(new SqlParameter[] { param1 });
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    conn.Close();
                    da.Dispose();
                }
                if (result?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        taskStatusLst.Add(!DBNull.Value.Equals(row["status_value"]) ? row["status_value"].ToString() : string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return taskStatusLst;
        }
    }
}
