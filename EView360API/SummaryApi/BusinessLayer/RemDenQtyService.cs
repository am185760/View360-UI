using DataRequestor;
using System.Data;
using System.Data.SqlClient;

namespace SummaryApi.BusinessLayer
{
    public class RemDenQtyService
    {
        private Executor _executor { get; set; }

        public RemDenQtyService(Executor executor)
        {
            _executor = executor;
        }

        public List<string> GetRemainingNotes(List<string> atmIds, ref string errorMsg)
        {
            List<string> noteSetTypeSum = new();
            if (atmIds?.Count > 0)
            {

                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@atmIDs",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetRemainingNotes", new SqlParameter[] { param }, atmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    foreach (DataRow row in result.Table.Rows)
                    {
                        noteSetTypeSum.Add(!DBNull.Value.Equals(row["cassette1_notes"]) ? row["cassette1_notes"].ToString() : string.Empty);
                        noteSetTypeSum.Add(!DBNull.Value.Equals(row["cassette2_notes"]) ? row["cassette2_notes"].ToString() : string.Empty);
                        noteSetTypeSum.Add(!DBNull.Value.Equals(row["cassette3_notes"]) ? row["cassette3_notes"].ToString() : string.Empty);
                        noteSetTypeSum.Add(!DBNull.Value.Equals(row["cassette4_notes"]) ? row["cassette4_notes"].ToString() : string.Empty);
                    }
                }
            }

            return noteSetTypeSum;
        }
    }
}
