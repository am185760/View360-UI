using Azure;
using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace Dashboard.BusinessLayer
{
    public class OrderDownloadService
    {
        private Executor executor { get; set; }
        public OrderDownloadService(Executor executor)
        {
            this.executor = executor;
        }
        public BaseModel GetDailyFeed(List<string> SelectedAtmIds)
        {
            DataTableResult FtpThresholdResult = executor.ExecuteDSRequest<DataTableResult>("GetFtpThreshold", new SqlParameter[] {}, SelectedAtmIds);
            int FtpThreshold = (int)FtpThresholdResult.Table.Rows[0]["threshold_for_ftp"];
            
            string queryFilter = "";
            var response = new BaseModel();

            if (FtpThreshold != -1)
                queryFilter += " and f.creation_time >= convert(datetime,'" + DateTime.Today.AddDays(-FtpThreshold).ToString("dd/MM/yyyy") + "',103) " +
                       " and f.creation_time <=convert(datetime,'" + DateTime.Today.AddDays(-FtpThreshold).ToString("dd/MM/yyyy") + " 23:59:59',103) ";

            List<DailyFeedStatusViewModel> feeds = new();

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = queryFilter;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = "creation_time desc";

            DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("GetOrders", new SqlParameter[] { param1, param2 }, SelectedAtmIds);
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
                        //Region = !DBNull.Value.Equals(row["region_name"]) ? row["region_name"].ToString() : string.Empty,
                        CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : null,
                        TaskType = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                        Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                        EndTime = !DBNull.Value.Equals(row["end_time"]) ? Convert.ToDateTime(row["end_time"]) : null,
                        LastInvokedAt = !DBNull.Value.Equals(row["last_invoked_at"]) ? Convert.ToDateTime(row["last_invoked_at"]) : null,
                        FailureReason = !DBNull.Value.Equals(row["reason"]) ? row["reason"].ToString() : string.Empty,
                        RetryCount = !DBNull.Value.Equals(row["retry_count"]) ? Convert.ToInt32(row["retry_count"]) : 0,
                        
                    };
                    feeds.Add(feed);
                }
            }
            return feeds;
        }
    }
}
