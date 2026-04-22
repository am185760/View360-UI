using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Operations
{
    public class AlertMonitoringServiceMW
    {
        //private Executor executor { get; set; }
        ILogger<AlertMonitoringServiceMW> logger;

        public AlertMonitoringServiceMW( ILogger<AlertMonitoringServiceMW> logger)
        {
            //this.executor = executor;
            this.logger = logger;
        }
        public void GetAlerts(Executor _executor, AlertMonitoringFilter filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.fromDate.HasValue)
                queryFilter += "generated_at >= convert(datetime, '" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and ";

            if (filter.toDate.HasValue)
                queryFilter += "generated_at <= convert(datetime, '" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and ";

            if (!filter.type.Equals("*"))
                queryFilter += "alert_type.alert_type_name = \'" + filter.type + "\' and ";

            if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                queryFilter += " atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ") and user_ATMs.user_id = " +filter.UserId +" and atm.is_active=1 ";
            else
                queryFilter += " atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";

            List<AlertMonitoringViewModel> alerts = new();

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = queryFilter;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = string.IsNullOrEmpty(filter.Orderby)? "title asc" : filter.Orderby;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@ArchiveYear";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "";

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@Offset";
            param4.SqlDbType = SqlDbType.Int;
            param4.Value = filter.Offset;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@RowCount";
            param5.SqlDbType = SqlDbType.Int;
            param5.Value = filter.RowCount;

            logger.LogWarning("[AlertMonitoringServiceMW:GetAlerts] executing GetAlert sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetAlert", new SqlParameter[] { param1, param2, param3, param4, param5 }, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[AlertMonitoringServiceMW:GetAlerts] returning from GetAlert sp");
            //if (result?.Table?.Rows?.Count > 0)
            //{
            //    response.Data = alerts = ConvertDataTableToList(result.Table);
            //}
            //if (!string.IsNullOrEmpty(result.ExceptionMessage))
            //{
            //    response.Message = result.ExceptionMessage;
            //    return response;
            //}

            //return new BaseModel { IsSuccess = true, Data = alerts };
        }


        public List<AlertMonitoringViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<AlertMonitoringViewModel> alerts = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    AlertMonitoringViewModel alert = new()
                    {
                        AlertTypeName = !DBNull.Value.Equals(row["alert_type_name"]) ? row["alert_type_name"].ToString() : string.Empty,
                        Title = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        RegionName = !DBNull.Value.Equals(row["region_name"]) ? row["region_name"].ToString() : string.Empty,
                        AlertMsg = !DBNull.Value.Equals(row["alert_msg"]) ? row["alert_msg"].ToString() : string.Empty,
                        GeneratedAt = !DBNull.Value.Equals(row["generated_at"]) ? Convert.ToDateTime(row["generated_at"]) : null,
                        ResolveAt = !DBNull.Value.Equals(row["resolve_at"]) ? Convert.ToDateTime(row["resolve_at"]) : null,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0
                    };
                    alerts.Add(alert);
                }
            }
            return alerts;
        }
    }
}
