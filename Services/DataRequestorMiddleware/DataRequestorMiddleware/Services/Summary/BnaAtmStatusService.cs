using DataRequestor;
using System.Data;
using System.Data.SqlClient;

namespace DataRequestorMiddleware.Services.Summary
{
    public class BnaAtmStatusService
    {
        private Executor _executor { get; set; }

        public List<string> GetBNATransactingATMTitle(long userId, List<string> atmIds, string filter, ref string errorMsg)
        {
            List<string> atmTiles = new();
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
                    Value = DateTime.Now.ToString()
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = filter
                };

                SqlParameter param4 = new SqlParameter()
                {
                    ParameterName = "@UserId",
                    SqlDbType = SqlDbType.BigInt,
                    Value = userId
                };
                _executor = new();
                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBNAAtmsForNoteAcceptorGraph", new SqlParameter[] { param1, param2, param3, param4 }, atmIds, string.Join(",", atmIds));
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
    }
}
