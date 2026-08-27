using Azure;
using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace OperationsApi.BusinessLayer
{
    public class DailyFeedStatusService
    {
        private Executor executor { get; set; }
        public DailyFeedStatusService(Executor executor)
        {
            this.executor = executor;
        }
        public BaseModel GetDailyFeed(DailyFeedStatusFilter filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.CreationFrom.HasValue)
                queryFilter += " and F.creation_time >= convert(datetime,'" + filter.CreationFrom.Value.ToString("dd/MM/yyyy") + "',103)";
            else
                queryFilter += " and F.creation_time >= getdate() - 3";

            if (filter.CreationTo.HasValue)
                queryFilter += " and F.creation_time <= convert(datetime,'" + filter.CreationTo.Value.ToString("dd/MM/yyyy") + " 23:59:59',103)";

            if (filter.EndFrom.HasValue)
                queryFilter += " and F.end_time >= convert(datetime,'" + filter.EndFrom.Value.ToString("dd/MM/yyyy") + "',103)"; ;

            if (filter.EndTo.HasValue)
                queryFilter += " and F.end_time <= convert(datetime,'" + filter.EndTo.Value.ToString("dd/MM/yyyy") + " 23:59:59',103)";

            if (!filter.TaskType.Equals("*"))
                queryFilter += " and t.task_type_name = '" + filter.TaskType + "'";

            if (!filter.Status.Equals("*"))
                queryFilter += " and F.status = '" + filter.Status + "'";

            List<DailyFeedStatusViewModel> feeds = new();

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = queryFilter;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = "creation_time desc";

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@ArchiveYear";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = "";//filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "";

            DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("GetDailyFeed", new SqlParameter[] { param1, param2, param3 }, new List<string>() { "sdf" });
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = feeds = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = feeds };
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
                        CreationTime =!DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : null,
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
