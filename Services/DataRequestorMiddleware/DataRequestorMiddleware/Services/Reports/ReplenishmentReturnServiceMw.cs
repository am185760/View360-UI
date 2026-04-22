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
using EView360Models.RequestModel;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace DataRequestorMiddleware.Services.Reports
{
    public class ReplenishmentReturnServiceMw
    {
        //private Executor _executor { get; set; }
        //public ReplenishmentReturnServiceMw(Executor executor)
        //{
        //    _executor = executor;
        //}
        private ILogger<ReplenishmentReturnServiceMw> _logger;

        public ReplenishmentReturnServiceMw(ILogger<ReplenishmentReturnServiceMw> logger)
        {
            _logger = logger;
        }

        public async Task<BaseModel> GetReplenishmentReturn(ReplenishmentReturnReportRequestModel replenishmentReport)
        {
            string filter = "";
            var response = new BaseModel();
            filter += " and user_ATMs.user_id =" + replenishmentReport.UserId;

            if (replenishmentReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= convert(datetime,'" + replenishmentReport.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (replenishmentReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime <= convert(datetime,'" + replenishmentReport.ToDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (replenishmentReport.NoteSetTypeIds.Count > 0)
            {
                filter += " and atm.note_set_type_id in ( " + string.Join(",", replenishmentReport.NoteSetTypeIds) + " ) ";
            }
            if (replenishmentReport.SelectedRegionIds != null || replenishmentReport.SelectedRegionIds?.Count > 0)
                filter += " and atm.region_id in (" + string.Join(",", replenishmentReport.SelectedRegionIds) + ") and atm.IS_ACTIVE = 1 ";
            else
                filter += "  and  atm.atm_id in (" + string.Join(",", replenishmentReport.SelectedAtms) + ")";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    //new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", replenishmentReport.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = replenishmentReport.ArchiveYear != string.Empty ? $"_{replenishmentReport.ArchiveYear}" : ""}
            };
            Executor _executor = new Executor();
            _logger.LogWarning($"ReplenishmentReturnPage:GenerateReport] going to execute  GetReplenishmentReturnReport sp");

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentReturnReport", sqlParameters, replenishmentReport.SelectedAtms, string.Join(",", replenishmentReport.SelectedAtms));
            _logger.LogWarning($"ReplenishmentReturnPage:GenerateReport] return from GetReplenishmentReturnReport sp");

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
