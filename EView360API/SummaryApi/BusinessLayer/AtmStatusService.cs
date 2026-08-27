using DataRequestor;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace SummaryApi.BusinessLayer
{
    public class AtmStatusService
    {
        private Executor _executor { get; set; }

        public AtmStatusService(Executor executor)
        {
            _executor = executor;
        }

        public List<string> GetTransactingATMTitle(List<string> atmIds, ref string errorMsg)
        {
            List<string> atmTiles = new();
            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@FromDate",
                    SqlDbType = SqlDbType.VarChar,
                    Value = DateTime.Today.ToString("dd/MM/yyyy")
                };

                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@ToDate",
                    SqlDbType = SqlDbType.VarChar,
                    Value = DateTime.Today.ToString("dd/MM/yyyy") + " 23:59:59"
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@atmIDs",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetTransactingATMTitle", new SqlParameter[] { param1, param2, param3 }, atmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        atmTiles.Add(!DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty);
                    }
                }
            }

            return atmTiles;
        }

        public int GetTrxnAtmCountToday(List<string> atmIds, ref string errorMsg)
        {
            int trnx_count = 0;

            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@FromDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = DateTime.Today.ToString()
                };

                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@ToDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = DateTime.Today.ToString()
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@atmIDs",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetTrxnCount", new SqlParameter[] { param1, param2, param3 }, atmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    DataRow row = result.Table.Rows[0];
                    trnx_count = !DBNull.Value.Equals(row["trnx_count"]) ? Convert.ToInt32(row["trnx_count"]) : 0;
                }
            }
            return trnx_count;
        }

        public int GetTrxnAtmCountYesterday(List<string> atmIds, ref string errorMsg)
        {
            int trnx_count = 0;

            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@FromDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = DateTime.Today.AddDays(-1).ToString()
                };

                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@ToDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = DateTime.Today.AddDays(-1).ToString()
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@atmIDs",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetTrxnCount", new SqlParameter[] { param1, param2, param3 }, atmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    DataRow row = result.Table.Rows[0];
                    trnx_count = !DBNull.Value.Equals(row["trnx_count"]) ? Convert.ToInt32(row["trnx_count"]) : 0;
                }
            }
            return trnx_count;
        }
    }
}
