using Common.RequestModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class AlertMonitoringReportServiceMW
    {
        ILogger<AlertMonitoringReportServiceMW> logger;
        public AlertMonitoringReportServiceMW(ILogger<AlertMonitoringReportServiceMW> logger)
        {
            this.logger = logger;
        }

        public BaseModel GetAlertMonitoringReport(AlertMonitoringReportRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                queryFilter += " and atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ") and user_ATMs.user_id = " + filter.UserId + " and atm.is_active=1 ";
            else
                queryFilter += " and atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";

            if (filter.fromDate.HasValue)
                queryFilter += " and generated_at >= convert(datetime,'" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            if (filter.toDate.HasValue)
                queryFilter += " and generated_at <= convert(datetime, '" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "', 103) ";

            if (!filter.type.Equals("*"))
                queryFilter += " and alert_type.alert_type_name = '" + filter.type + "'";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };
            Executor _executor = new Executor();

            logger.LogWarning("[AlertMonitoringReportServiceMW:GetAlertMonitoringReport] executing GetAlertsReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetAlertsReport", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[AlertMonitoringReportServiceMW:GetAlertMonitoringReport] returning from GetAlertsReport sp");

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = result.Table;
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = result.Table };
        }
    }
}
