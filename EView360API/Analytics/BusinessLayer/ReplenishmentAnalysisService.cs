using DataRequestor;
using System.Data.SqlClient;
using System.Data;
using Common.ViewModel;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Analytics.BusinessLayer
{
    public class ReplenishmentAnalysisService
    {
        //private Executor _executor { get; set; }
        //public ReplenishmentAnalysisService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public List<ReplenishmentAnalysisViewModel> GetReplenishmentAnalysis(DateTime fromDate, DateTime toDate, List<string> atmIds, ref string errorMsg)
        {
            List<ReplenishmentAnalysisViewModel> replenishments = new();
            if (atmIds?.Count > 0)
            {
                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FromDate",SqlDbType = SqlDbType.DateTime,Value = fromDate},
                    new SqlParameter() {ParameterName = "@ToDate",SqlDbType = SqlDbType.DateTime,Value = toDate},
                    new SqlParameter() {ParameterName = "@AtmIds",SqlDbType = SqlDbType.VarChar,Value = string.Join(",", atmIds)}
                };
                Executor _executor = new Executor();
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("Replenishments", paramArray, atmIds);
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
            }
            return replenishments;
        }

        public List<ReplenishmentAnalysisViewModel> GetReplenishmentDatagrid(DateTime fromDate, DateTime toDate, List<string> atmIds, ref string errorMsg)
        {
            List<ReplenishmentAnalysisViewModel> replenishments = new();
            if (atmIds?.Count > 0)
            {
                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FromDate",SqlDbType = SqlDbType.DateTime,Value = fromDate},
                    new SqlParameter() {ParameterName = "@ToDate",SqlDbType = SqlDbType.DateTime,Value = toDate},
                    new SqlParameter() {ParameterName = "@AtmIds",SqlDbType = SqlDbType.VarChar,Value = string.Join(",", atmIds)}
                };
                Executor _executor = new Executor();
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentDatagrid", paramArray, atmIds);
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
                            Amount = !DBNull.Value.Equals(row["amount"]) ? Convert.ToInt32(row["amount"]) : 0,
                            ReplenishmentDate = !DBNull.Value.Equals(row["rep_dateTime"]) ? row["rep_dateTime"].ToString() : null,
                        };
                        replenishments.Add(replenishment);
                    }
                }
            }
            return replenishments;
        }
    }
}
