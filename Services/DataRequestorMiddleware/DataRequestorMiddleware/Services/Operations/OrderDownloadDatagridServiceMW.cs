using DataRequestor;
using EView360Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption;
using Microsoft.Win32;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Operations
{
    public class OrderDownloadDatagridServiceMW
    {
        //private Executor executor { get; set; }
        //public OrderDownloadDatagridServiceMW(Executor executor)
        //{
        //    this.executor = executor;
        //}
        //public BaseModel GetDailyFeed(List<string> SelectedAtmIds)
        //{
        //    DataTableResult FtpThresholdResult = executor.ExecuteDSRequest<DataTableResult>("GetFtpThreshold", new SqlParameter[] { }, SelectedAtmIds);
        //    int FtpThreshold = (int)FtpThresholdResult.Table.Rows[0]["threshold_for_ftp"];

        //    string queryFilter = "";
        //    var response = new BaseModel();

        //    if (FtpThreshold != -1)
        //        queryFilter += " and f.creation_time >= convert(datetime,'" + DateTime.Today.AddDays(-FtpThreshold).ToString("dd/MM/yyyy") + "',103) " +
        //               " and f.creation_time <=convert(datetime,'" + DateTime.Today.AddDays(-FtpThreshold).ToString("dd/MM/yyyy") + " 23:59:59',103) ";

        //    List<DailyFeedStatusViewModel> feeds = new();

        //    SqlParameter param1 = new SqlParameter();
        //    param1.ParameterName = "@Filter";
        //    param1.SqlDbType = SqlDbType.VarChar;
        //    param1.Value = queryFilter;

        //    SqlParameter param2 = new SqlParameter();
        //    param2.ParameterName = "@OrderBy";
        //    param2.SqlDbType = SqlDbType.VarChar;
        //    param2.Value = "creation_time desc";

        //    DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("GetOrders", new SqlParameter[] { param1, param2 }, SelectedAtmIds);
        //    if (result?.Table?.Rows?.Count > 0)
        //    {
        //        response.Data = feeds = ConvertDataTableToList(result.Table);
        //    }
        //    if (!string.IsNullOrEmpty(result.ExceptionMessage))
        //    {
        //        response.Message = result.ExceptionMessage;
        //        return response;
        //    }
        //    return new BaseModel { IsSuccess = true, Data = feeds };
        //}
        ILogger<OrderDownloadDatagridServiceMW> logger;

        public OrderDownloadDatagridServiceMW(ILogger<OrderDownloadDatagridServiceMW> logger)
        {
            this.logger = logger;
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
                        FailureReason = !DBNull.Value.Equals(row["failure_reason"]) ? row["failure_reason"].ToString() : string.Empty,
                        RetryCount = !DBNull.Value.Equals(row["retry_count"]) ? Convert.ToInt32(row["retry_count"]) : 0,

                    };
                    feeds.Add(feed);
                }
            }
            return feeds;
        }

        public BaseModel GetDailyFeed()
        {
            string queryFilter = "";
            var response = new BaseModel();

            queryFilter += " and f.creation_time >= CAST(CONVERT(date, DATEADD (day,-(select TOP 1 threshold_for_ftp from Core.dbo.app_setting),GETDATE())) AS DATETIME)  and f.creation_time <= CAST(CONVERT(VARCHAR,CONVERT(date, GETDATE() ,103)) +' 23:59:59' AS DATETIME) ";

            List<DailyFeedStatusViewModel> feeds = new();

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
            logger.LogWarning("[OrderDownloadDatagridServiceMW:GetDailyFeed] opening connection and executing GetDailyFeed sp");
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
            logger.LogWarning("[OrderDownloadDatagridServiceMW:GetDailyFeed] closing connection and returning from GetDailyFeed sp");

            if (result?.Rows?.Count > 0)
            {
                response.Data = feeds = ConvertDataTableToList(result);
            }

            return new BaseModel { IsSuccess = true, Data = feeds };
        }
    }
}
