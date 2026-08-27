using DataRequestor;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace Dashboard.BusinessLayer
{
    public class TransHourlyAnalysisService
    {
        //private Executor _executor { get; set; }

        //public TransHourlyAnalysisService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public List<TransHourlyResponseViewModel> GetTransHourlyResponse(List<string> atmIds, ref string errorMsg)
        {
            List<TransHourlyResponseViewModel> transHourlyResponses = new();
            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@AtmId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };
                Executor _executor = new Executor();
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("ViewTransactionsHourlyAnalysis", new SqlParameter[] { param1 } , atmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        TransHourlyResponseViewModel transHourlyResponse = new()
                        {
                            AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                            TrnxDateTime = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                            LastHeartBeatAt = !DBNull.Value.Equals(row["last_heart_beat_at"]) ? Convert.ToDateTime(row["last_heart_beat_at"]) : null,
                            Amount = !DBNull.Value.Equals(row["amount"]) ? Convert.ToDecimal(row["amount"]) : null,
                        };
                        transHourlyResponses.Add(transHourlyResponse);
                    }
                }
            }

            return transHourlyResponses;
        }
    }
}
