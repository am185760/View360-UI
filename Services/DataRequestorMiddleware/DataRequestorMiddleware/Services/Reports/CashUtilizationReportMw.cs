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
using Microsoft.Extensions.Logging;
using EView360Models.RequestModel;

namespace DataRequestorMiddleware.Services.Reports
{
    public class CashUtilizationReportMw
    {
        //private Executor _executor { get; set; }
        //public CashUtilizationReportMw(Executor executor)
        //{
        //    _executor = executor;
        //}
        private ILogger<CashUtilizationReportMw> logger;

        public CashUtilizationReportMw(ILogger<CashUtilizationReportMw> logger)
        {
            this.logger = logger;
        }

        public async Task<BaseModel> GetCashUtilization(CashUtilizationReportRequestModel cashUtilizationReport)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();
            SqlParameter param5 = new SqlParameter();

            var response = new BaseModel();
           
            filter += " and user_ATMs.user_id =" + cashUtilizationReport.UserId;
            if (cashUtilizationReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= convert(datetime,'" + cashUtilizationReport.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (cashUtilizationReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime <= convert(datetime,'" + cashUtilizationReport.ToDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (cashUtilizationReport.NoteSetTypeIds.Count > 0)
            {
                filter += " and atm.note_set_type_id in ( " + string.Join(",", cashUtilizationReport.NoteSetTypeIds) + " ) ";
            }

            if (cashUtilizationReport.SelectedRegionIds != null || cashUtilizationReport.SelectedRegionIds?.Count > 0)
                filter += "and atm.region_id in (" + string.Join(",", cashUtilizationReport.SelectedRegionIds) + ") and atm.IS_ACTIVE = 1 ";
            else
                filter += "and  atm.atm_id in (" + string.Join(",", cashUtilizationReport.SelectedAtms) + ")";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    //new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", cashUtilizationReport.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = cashUtilizationReport.ArchiveYear != string.Empty ? $"_{cashUtilizationReport.ArchiveYear}" : ""
            }
            };
            Executor _executor = new Executor();

            logger.LogWarning($"CashUtilizationReportMw:GetCashUtilization] going to execute GetCashUtilizationReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetCashUtiizationReport", sqlParameters, cashUtilizationReport.SelectedAtms,string.Join(",", cashUtilizationReport.SelectedAtms));
            logger.LogWarning($"CashUtilizationReportMw:GetCashUtilization] return from to GetCashUtilizationReport sp");


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
