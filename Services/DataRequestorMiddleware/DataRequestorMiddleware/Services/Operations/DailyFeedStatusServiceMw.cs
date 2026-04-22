using System.Data.SqlClient;
using System.Data;
using EView360Models.ViewModels;
using EView360Models.RequestModel;
using Microsoft.Win32;
using Encryption;
using DataRequestor;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Operations
{
    public class DailyFeedStatusServiceMW
    {
        ILogger<DailyFeedStatusServiceMW> logger;

        public DailyFeedStatusServiceMW(ILogger<DailyFeedStatusServiceMW> logger)
        {
            this.logger = logger;
        }
        public BaseModel GetDailyFeed(DailyFeedStatusFilter filter)
        {
            List<DailyFeedStatusViewModel> feeds = new();
            var response = new BaseModel() { IsSuccess =true};

            try
            {
                string queryFilter = "";

                if (filter.CreationFrom.HasValue)
                    queryFilter += " and F.creation_time >= convert(datetime,'" + filter.CreationFrom.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                else
                    queryFilter += " and F.creation_time >= getdate() - 3";

                if (filter.CreationTo.HasValue)
                    queryFilter += " and F.creation_time <= convert(datetime,'" + filter.CreationTo.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

                if (filter.EndFrom.HasValue)
                    queryFilter += " and F.end_time >= convert(datetime,'" + filter.EndFrom.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)"; ;

                if (filter.EndTo.HasValue)
                    queryFilter += " and F.end_time <= convert(datetime,'" + filter.EndTo.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

                if (!filter.TaskType.Equals("*"))
                    queryFilter += " and t.task_type_name = '" + filter.TaskType + "'";

                if (!filter.Status.Equals("*"))
                    queryFilter += " and F.status = '" + filter.Status + "'";


                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Filter";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = queryFilter;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@OrderBy";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = "creation_time desc";

                string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
                connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");
                
                DataTable result = new();
                
                logger.LogWarning("[DailyFeedStatusServiceMW:GetDailyFeed] opening connection and executing GetDailyFeed sp");
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetDailyFeed", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(new SqlParameter[] { param1, param2 });
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    conn.Close();
                    da.Dispose();
                }
                logger.LogWarning("[DailyFeedStatusServiceMW:GetDailyFeed] closing connection and returning from GetDailyFeed sp");

                if (result?.Rows?.Count > 0)
                {
                    response.Data = ConvertDataTableToList(result);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public List<DailyFeedStatusViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<DailyFeedStatusViewModel> feeds = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DailyFeedStatusViewModel feed = new()
                    {
                        CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : null,
                        EndTime = !DBNull.Value.Equals(row["end_time"]) ? Convert.ToDateTime(row["end_time"]) : null,
                        LastInvokedAt = !DBNull.Value.Equals(row["last_invoked_at"]) ? Convert.ToDateTime(row["last_invoked_at"]) : null,
                        FtpFileId = !DBNull.Value.Equals(row["ftp_file_info_id"]) ? Convert.ToInt32(row["ftp_file_info_id"]) : 0,
                        FileName = !DBNull.Value.Equals(row["ftp_filename"]) ? row["ftp_filename"].ToString() : string.Empty,
                        TaskType = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                        Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                        FailureReason = !DBNull.Value.Equals(row["failure_reason"]) ? row["failure_reason"].ToString() : string.Empty,
                        RetryCount = !DBNull.Value.Equals(row["retry_count"]) ? Convert.ToInt32(row["retry_count"]) : 0,
                    };
                    feeds.Add(feed);
                }
            }
            return feeds;
        }
    }
}
