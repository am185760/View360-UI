using Azure;
using Common.RequestModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AlertMonitoringReportService
    {
        //private Executor _executor { get; set; }

        //public AlertMonitoringReportService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetAlertMonitoringReport(AlertMonitoringReportRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.fromDate.HasValue)
                queryFilter += " and generated_at >= convert(datetime,'" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            if (filter.toDate.HasValue)
                queryFilter += " and generated_at <= convert(datetime, '" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "', 103) ";

            if (!filter.type.Equals("*"))
                queryFilter += " and alert_type.alert_type_name = '" + filter.type + "'";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", filter.SelectedAtmIds)},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReportAlerts", sqlParameters, filter.SelectedAtmIds);

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = JsonConvert.SerializeObject(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(result.Table) };
        }
    }
}
 