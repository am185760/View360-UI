using DataRequestor;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using Common.RequestModel;
using Newtonsoft.Json;
using DataRequestorMiddleware.Services.Reports;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Analytics
{
    public class CashUtilizationAnalysisService
    {
        private Executor _executor { get; set; }
        private ILogger<CashUtilizationAnalysisService> logger;

        public CashUtilizationAnalysisService(ILogger<CashUtilizationAnalysisService> _logger)
        {
            logger = _logger;
        }

        public List<CashUtilizationViewModel> GetAtmUtilizationDetail(DateTime fromDate, DateTime toDate, List<string> atmIds, string filter, ref string errorMsg)
        {
            List<CashUtilizationViewModel> cashUtilizations = new();
            _executor = new Executor();
            if (atmIds?.Count > 0)
            {
                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FromDate",SqlDbType = SqlDbType.DateTime,Value = fromDate},
                    new SqlParameter() {ParameterName = "@ToDate",SqlDbType = SqlDbType.DateTime,Value = toDate},
                    new SqlParameter() {ParameterName = "@Filter",SqlDbType = SqlDbType.VarChar,Value = filter}
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("ATMUtilization", paramArray, atmIds, string.Join(",",atmIds));
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    cashUtilizations = GetModelLst(result.Table);
                }
            }
            return cashUtilizations;
        }

        public List<CashUtilizationViewModel> GetModelLst(DataTable dt)
        {
            List<CashUtilizationViewModel> cashUtilizationViews = new();

            foreach (DataRow row in dt.Rows)
            {
                CashUtilizationViewModel cashUtilizationView = new()
                {
                    Date = !DBNull.Value.Equals(row["thisDate"]) ? Convert.ToDateTime(row["thisDate"]) : null,
                    result = !DBNull.Value.Equals(row["result"]) ? Convert.ToDecimal(row["result"]) : 0
                };
                cashUtilizationViews.Add(cashUtilizationView);
            }
            return cashUtilizationViews;
        }

        public List<CashUtilizationViewModel> GetCashUtilization(CashUtilizationReportRequestModel cashUtilizationReport, ref string errorMsg)
        {
            string filter = "";
            List<CashUtilizationViewModel> cashUtilizations = new();

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

            logger.LogWarning($"CashUtilizationAnalysisService:GetCashUtilization] going to execute GetCashUtilizationGraph sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetCashUtilizationGraph", sqlParameters, cashUtilizationReport.SelectedAtms, string.Join(",", cashUtilizationReport.SelectedAtms));
            logger.LogWarning($"CashUtilizationAnalysisService:GetCashUtilization] return from to GetCashUtilizationGraph sp");


            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                errorMsg = result.ExceptionMessage;
            }
            if (result?.Table?.Rows?.Count > 0)
            {
                cashUtilizations = GetModelLst(result.Table);
            }
            return cashUtilizations;
        }

    }
}
