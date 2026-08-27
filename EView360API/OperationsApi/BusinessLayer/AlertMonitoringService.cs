using Azure;
using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace OperationsApi.BusinessLayer
{
    public class AlertMonitoringService
    {
        private Executor executor { get; set; }
        public AlertMonitoringService(Executor executor) 
        {
            this.executor = executor;
        }
        public BaseModel GetAlerts(AlertMonitoringFilter filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.fromDate.HasValue)
                queryFilter += "generated_at >= convert(datetime, '" + filter.fromDate.Value.ToString("dd/MM/yyyy") + "',103) and ";

            if (filter.toDate.HasValue)
                queryFilter += "generated_at <= convert(datetime, '" + filter.toDate.Value.ToString("dd/MM/yyyy") + " 23:59:59', 103) and ";

            if (!filter.type.Equals("*"))
                queryFilter += "alert_type.alert_type_name = \'" + filter.type + "\' and ";

            queryFilter += " atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";

            List<AlertMonitoringViewModel> alerts = new();

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = queryFilter;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = "title asc";

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@ArchiveYear";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = filter?.ArchiveYear != 0? "_"+ filter.ArchiveYear.ToString():"";

            DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("GetAlert", new SqlParameter[] { param1, param2, param3}, filter.SelectedAtmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = alerts = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = alerts };
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
