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
    public class NoCashWIthdrawalReportServiceMW
    {
        ILogger<NoCashWIthdrawalReportServiceMW> logger;
        public NoCashWIthdrawalReportServiceMW(ILogger<NoCashWIthdrawalReportServiceMW> logger)
        {
            this.logger = logger;
        }
        public BaseModel GetNoCashWIthdrawalReport(NoCashWithdrawalReportRequestModel filter)
        {
            string atmFilter = "";
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.fromDate.HasValue)
                atmFilter += " and trxn_datetime >= convert(datetime,'" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (filter.toDate.HasValue)
                atmFilter += " and trxn_datetime <= convert(datetime,'" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", filter.SelectedAtmIds)},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = atmFilter},
                        new SqlParameter() {ParameterName = "@UserId", SqlDbType = SqlDbType.VarChar, Value = filter.UserId.ToString()},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            }; Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetSearchAtms", sqlParameters, filter.SelectedAtmIds);

            List<long> atmList = result.Table.Rows.OfType<DataRow>().Select(dr => (long)dr["atm_id"]).ToList();

            if (filter.isDeadATMExcluded)
                queryFilter = " and ATM_id not in (select ATM_id from vHeartBeat where heart_beat_received_at >=convert(datetime,'" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and " + "heart_beat_received_at <=convert(datetime,'" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103))";

            sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@SearchAtms", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", atmList)},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };

            logger.LogWarning("[NoCashWIthdrawalReportServiceMW:GetNoCashWIthdrawalReport] executing GetNoCashWithdrawalReport sp");
            result = _executor.ExecuteDSRequest<DataTableResult>("GetNoCashWithdrawalReport", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[NoCashWIthdrawalReportServiceMW:GetNoCashWIthdrawalReport] returning from GetNoCashWithdrawalReport sp");


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
