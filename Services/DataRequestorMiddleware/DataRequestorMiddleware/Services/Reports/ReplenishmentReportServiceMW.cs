using Common.RequestModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class ReplenishmentReportServiceMW
    {
        ILogger<ReplenishmentReportServiceMW> logger;
        public ReplenishmentReportServiceMW(ILogger<ReplenishmentReportServiceMW> logger)
        {
            this.logger = logger;
        }
        public BaseModel GetReplenishmentReport(ReplenishmentReportRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.FromDate.HasValue)
                queryFilter += " rep_datetime >= convert(datetime,'" + filter.FromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
            else
                queryFilter += " 1=1 ";

            if (filter.ToDate.HasValue)
                queryFilter += " and rep_datetime <= convert(datetime, '" + filter.ToDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "', 103) ";

            if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                queryFilter += " and atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ") and user_ATMs.user_id = " + filter.UserId + " and atm.is_active=1 ";
            else
                queryFilter += " and atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ") ";

            if (filter.Status.Equals("Normal"))
                queryFilter += " and rep_status = '" + filter.Status + "' ";

            else if (filter.Status.Equals("Suspicious"))
                queryFilter += " and rep_status not in ('Normal') ";
            
            if (filter.NoteSetTypeIds.Count > 0)
                queryFilter += " and atm.note_set_type_id in ( " + string.Join(",", filter.NoteSetTypeIds) + " ) ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };
            Executor _executor = new Executor();
            logger.LogWarning("[ReplenishmentReportServiceMW:GetReplenishmentReport] executing GetReplenishmentReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentReport", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[ReplenishmentReportServiceMW:GetReplenishmentReport] returning from GetReplenishmentReport sp");

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
