using Common.ViewModel;
using DataRequestor;
using System.Data.SqlClient;
using System.Data;
using EView360Models.RequestModel;
using System;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Analytics
{
    public class ReplenishmentAnalysisServiceMW
    {
        ILogger<ReplenishmentAnalysisServiceMW> logger;
        public ReplenishmentAnalysisServiceMW(ILogger<ReplenishmentAnalysisServiceMW> logger)
        {
            this.logger = logger;
        }
        public List<ReplenishmentAnalysisViewModel> GetReplenishmentAnalysis(DateTime? fromDate, DateTime? toDate, List<string> atmIds, List<string>? regionIds, long userId, ref string errorMsg)
        {
            List<ReplenishmentAnalysisViewModel> replenishments = new();
            string filter = "";

            if (fromDate.HasValue)
                filter += "rep_datetime >= convert(datetime, '" + fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
            else
                filter += "1=1";

            if (toDate.HasValue)
                filter += "and rep_datetime <= convert(datetime, '" + toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            if (regionIds != null || regionIds?.Count > 0)
                filter += " and atm.region_id in (" + string.Join(",", regionIds) + ") and user_ATMs.user_id = " + userId + " and atm.is_active=1 ";

            else
                filter += " and atm.atm_id in (" + string.Join(",", atmIds) + ")";

            SqlParameter[] paramArray = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@Filter",SqlDbType = SqlDbType.VarChar,Value = filter}
            };
            Executor _executor = new Executor();
            logger.LogWarning($"[ReplenishmentAnalysisServiceMW:GetReplenishmentAnalysis] executing GetReplenishmentAnalysis sp for {fromDate.Value.Date.ToString()} - {toDate.Value.Date.ToString()}");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentAnalysis", paramArray, atmIds, string.Join(",", atmIds));
            logger.LogWarning($"[ReplenishmentAnalysisServiceMW:GetReplenishmentAnalysis] returning from GetReplenishmentAnalysis sp for {fromDate.Value.Date.ToString()} - {toDate.Value.Date.ToString()}");
            
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                errorMsg = result.ExceptionMessage;
            }
            if (result?.Table?.Rows?.Count > 0)
            {
                foreach (DataRow row in result.Table.Rows)
                {
                    ReplenishmentAnalysisViewModel replenishment = new()
                    {
                        Day = !DBNull.Value.Equals(row["day"]) ? row["day"].ToString() : string.Empty,
                        Total = !DBNull.Value.Equals(row["total"]) ? Convert.ToInt32(row["total"]) : 0,
                    };
                    replenishments.Add(replenishment);
                }
            }
            return replenishments;
        }

        public List<ReplenishmentAnalysisViewModel> GetReplenishmentDatagrid(DateTime? fromDate, DateTime? toDate, List<string> atmIds, List<string>? regionIds, long userId, ref string errorMsg)
        {
            List<ReplenishmentAnalysisViewModel> replenishments = new();
            string filter = "";

            if (fromDate.HasValue)
                filter += " rep_datetime >= convert(datetime, '" + fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
            else
                filter += " 1=1 ";

            if (toDate.HasValue)
                filter += " and rep_datetime <= convert(datetime, '" + toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            if (regionIds != null || regionIds?.Count > 0)
                filter += " and atm.region_id in (" + string.Join(",", regionIds) + ") and user_ATMs.user_id = " + userId + " and atm.is_active=1 ";

            else
                filter += " and atm.atm_id in (" + string.Join(",", atmIds) + ")";

            SqlParameter[] paramArray = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@Filter",SqlDbType = SqlDbType.VarChar,Value = filter}
            };
            
            Executor _executor = new Executor();
            logger.LogWarning("[ReplenishmentAnalysisServiceMW:GetReplenishmentDatagrid] executing GetReplenishmentDatagrid sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentDatagrid", paramArray, atmIds, string.Join(",", atmIds));
            logger.LogWarning("[ReplenishmentAnalysisServiceMW:GetReplenishmentDatagrid] returning from GetReplenishmentDatagrid sp");

            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                errorMsg = result.ExceptionMessage;
            }
            if (result?.Table?.Rows?.Count > 0)
            {
                foreach (DataRow row in result.Table.Rows)
                {
                    ReplenishmentAnalysisViewModel replenishment = new()
                    {
                        Title = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Amount = !DBNull.Value.Equals(row["amount"]) ? Convert.ToDecimal(row["amount"]) : 0,
                        ReplenishmentDate = !DBNull.Value.Equals(row["rep_dateTime"]) ? row["rep_dateTime"].ToString() : null,
                    };
                    replenishments.Add(replenishment);
                }
            }
            return replenishments;
        }
    }
}
