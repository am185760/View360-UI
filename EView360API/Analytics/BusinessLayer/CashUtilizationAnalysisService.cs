using DataRequestor;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace Analytics.BusinessLayer
{
    public class CashUtilizationAnalysisService
    {
        private Executor _executor { get; set; }

        public CashUtilizationAnalysisService(Executor executor)
        {
            _executor = executor;
        }

        public List<CashUtilizationViewModel> GetAtmUtilizationDetail(DateTime fromDate, DateTime toDate, List<string> atmIds, ref string errorMsg)
        {
            List<CashUtilizationViewModel> cashUtilizations = new();
            if (atmIds?.Count > 0)
            {
                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FromDate",SqlDbType = SqlDbType.DateTime,Value = fromDate},
                    new SqlParameter() {ParameterName = "@ToDate",SqlDbType = SqlDbType.DateTime,Value = toDate},
                    new SqlParameter() {ParameterName = "@AtmIds",SqlDbType = SqlDbType.VarChar,Value = string.Join(",", atmIds)}
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("ATMUtilization", paramArray, atmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        CashUtilizationViewModel cashUtilizationView = new()
                        {
                            Date = !DBNull.Value.Equals(row["thisDate"]) ? Convert.ToDateTime(row["thisDate"]) : null,
                            result = !DBNull.Value.Equals(row["result"]) ? Convert.ToDecimal(row["result"]) : 0
                        };
                        cashUtilizations.Add(cashUtilizationView);
                    }
                }
            }
            return cashUtilizations;
        }
    }
}
