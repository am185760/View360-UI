using Common.RequestModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace EView360.Services.Reports
{
    public class CashWithdrawalReportServiceMW
    {
        ILogger<CashWithdrawalReportServiceMW > logger;
        public CashWithdrawalReportServiceMW(ILogger<CashWithdrawalReportServiceMW> logger)
        {
            this.logger = logger;
        }
        public BaseModel GetCashWithdrawalReport(CashWithdrawalReportRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                queryFilter += " and atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ") and user_ATMs.user_id = " + filter.UserId + " and atm.is_active=1 ";
            else
                queryFilter += " and atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";

            if (filter.NoteSetTypeIds.Count > 0)
                queryFilter += " and atm.note_set_type_id  in ( " + filter.NoteSetTypeIds.ToString() + " ) ";

            if (filter.fromDate.HasValue)
                queryFilter += " and trxn_datetime >= convert(datetime,'" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (filter.toDate.HasValue)
                queryFilter += " and trxn_datetime <= convert(datetime,'" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (filter.reportType == 0)
            {
                if (filter.PurgeNoteFrom.HasValue)
                    queryFilter += " and (cash_purged1+cash_purged2+cash_purged3+cash_purged4+cash_purged5+cash_purged6+cash_purged7)>=" + filter.PurgeNoteFrom.Value.ToString();

                if (filter.PurgeNoteTo.HasValue)
                    queryFilter += " and (cash_purged1+cash_purged2+cash_purged3+cash_purged4+cash_purged5+cash_purged6+cash_purged7)<=" + filter.PurgeNoteTo.Value.ToString();


                if (filter.DispensedType1.HasValue)
                    queryFilter += " and cash_dispensed1 = " + filter.DispensedType1.ToString();

                if (filter.DispensedType2.HasValue)
                    queryFilter += " and cash_dispensed2 = " + filter.DispensedType2.ToString();

                if (filter.DispensedType3.HasValue)
                    queryFilter += " and cash_dispensed3 = " + filter.DispensedType3.ToString();

                if (filter.DispensedType4.HasValue)
                    queryFilter += " and cash_dispensed4 = " + filter.DispensedType4.ToString();


                if (filter.FromAmount.HasValue)
                    queryFilter += " and amount >= " + filter.FromAmount.ToString();

                if (filter.ToAmount.HasValue)
                    queryFilter += " and amount <= " + filter.ToAmount.ToString();
            }

            else
            {
                if (filter.Threshold.HasValue)
                    queryFilter += " and withdrawals<= " + filter.Threshold.ToString();
            }

            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
                };

            DataTableResult result;
            Executor _executor = new Executor();
            if (filter.reportType == 0)
            {
                logger.LogWarning("[CashWithdrawalReportServiceMW:GetCashWithdrawalReport] executing GetCashWithdrawalReport sp");
                result = _executor.ExecuteDSRequest<DataTableResult>("GetCashWithdrawalReport", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
                logger.LogWarning("[CashWithdrawalReportServiceMW:GetCashWithdrawalReport] returning from GetCashWithdrawalReport sp");
            }
            else
            {
                logger.LogWarning("[CashWithdrawalReportServiceMW:GetCashWithdrawalReport] executing GetCashWithdrawalSummary sp");
                result = _executor.ExecuteDSRequest<DataTableResult>("GetCashWithdrawalSummary", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
                logger.LogWarning("[CashWithdrawalReportServiceMW:GetCashWithdrawalReport] returning from GetCashWithdrawalSummary sp");
            }


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
