using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestorMiddleware.Services.Analytics
{
    public class TransactionAnalyticsServiceMw
    {
        //private Executor _executor { get; set; }
        //public TransactionAnalyticsServiceMw(Executor executor = null)
        //{
        //    _executor = executor;
        //}

        public async Task<BaseModel> GetAtmTransactionDetail(DateTime fromDate, DateTime toDate, List<string> atmIds, List<string> regionIds)
        {
            var response = new BaseModel();
            List<TransactionAnalyticsViewModel> transactionAnalytics = new();
            if (atmIds?.Count > 0)
            {
                string filter= string.Empty;
                if (regionIds != null || regionIds?.Count > 0)
                    filter += " and atm.region_id in (" + string.Join(",", regionIds) + ") and atm.IS_ACTIVE = 1 ";
                else
                    filter += " and atm.atm_id in (" + string.Join(",", atmIds) + ") ";

                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FromDate",SqlDbType = SqlDbType.DateTime,Value = fromDate},
                    new SqlParameter() {ParameterName = "@ToDate",SqlDbType = SqlDbType.DateTime,Value = toDate},
                    new SqlParameter() {ParameterName = "@filter",SqlDbType = SqlDbType.VarChar,Value = filter}
                };
                Executor _executor = new Executor();
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("TransactionVersusHour", paramArray, atmIds,string.Join(",", atmIds));

                if (result?.Table?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        TransactionAnalyticsViewModel transactionAnalaytic = new()
                        {
                            Counter = !DBNull.Value.Equals(row["counter"]) ? Convert.ToInt64(row["counter"]) : 0,
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
