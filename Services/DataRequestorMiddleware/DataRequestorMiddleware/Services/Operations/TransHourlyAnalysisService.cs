using DataRequestor;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace DataRequestorMiddleware.Services.Operations
{
    public class TransHourlyAnalysisService
    {
        public void GetTransHourlyResponse(Executor _executor, List<string> atmIds, string filter, ref string errorMsg)
        {
            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = filter
                };
                _executor.ExecuteDSRequest<DataTableResult>("ViewTransactionsHourlyAnalysis", new SqlParameter[] { param1 } , atmIds, string.Join(",", atmIds));
            }
        }
    }
}
