using DataRequestor;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using Common.ViewModel;

namespace Analytics.BusinessLayer
{
    public class TransactionAnalyticsService
    {
        private Executor _executor { get; set; }

        public TransactionAnalyticsService(Executor executor)
        {
            _executor = executor;
        }

        public BaseModel GetAtmTransactionDetail(DateTime fromDate, DateTime toDate, List<string> atmIds)
        {
            var response = new BaseModel();
            List<TransactionAnalyticsViewModel> transactionAnalytics = new();
            if (atmIds?.Count > 0)
            {
                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FromDate",SqlDbType = SqlDbType.DateTime,Value = fromDate},
                    new SqlParameter() {ParameterName = "@ToDate",SqlDbType = SqlDbType.DateTime,Value = toDate},
                    new SqlParameter() {ParameterName = "@AtmIds",SqlDbType = SqlDbType.VarChar,Value = string.Join(",", atmIds)}
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("TransactionVersusHour", paramArray, atmIds);

                if (result?.Table?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        TransactionAnalyticsViewModel transactionAnalaytic = new()
                        {
                            Counter = !DBNull.Value.Equals(row["counter"]) ? Convert.ToInt32(row["counter"]) : 0,
                            Hr = !DBNull.Value.Equals(row["hr"]) ? Convert.ToInt32(row["hr"]) : 0
                        };
                        transactionAnalytics.Add(transactionAnalaytic);
                    }
                }
                response.Data = transactionAnalytics;
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    response.Message = result.ExceptionMessage;
                    return response;
                }
            }
            return new BaseModel { IsSuccess = true, Data = transactionAnalytics };
        }
    }
}
