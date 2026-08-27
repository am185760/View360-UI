using DataRequestor;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using Common.ViewModel;

namespace Services
{
    public class MinimumThresholdService
    {
        //private Executor _executor { get; set; }

        //public MinimumThresholdService(Executor executor)
        //{
        //    _executor = executor;
        //}
        public BaseModel GetMinimumThreshold(List<string> SelectedAtmTds)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();

            var response = new BaseModel();


            List<MinimumThresholdViewModel> minimumThreshold = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = string.Join(",", SelectedAtmTds);

            param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = "total asc";
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetDashboardMinimumThreshold", new SqlParameter[] { param1, param2 }, SelectedAtmTds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = minimumThreshold = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = minimumThreshold };
        }

        public List<MinimumThresholdViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<MinimumThresholdViewModel> minimumThresholds = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    MinimumThresholdViewModel minimumThreshold = new()
                    {
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        MinimumThresholdBalance = !DBNull.Value.Equals(row["min_operating_balance"]) ? Convert.ToDouble( row["min_operating_balance"].ToString()) : 0,
                        RemainingAmount = !DBNull.Value.Equals(row["total"]) ? Convert.ToInt32( row["total"].ToString()) : 0,
                        Location = !DBNull.Value.Equals(row["location"]) ?  row["location"].ToString() : string.Empty,
                        IpAddress = !DBNull.Value.Equals(row["IP"]) ?  row["IP"].ToString() : string.Empty,
                        NoteSetTypeName = !DBNull.Value.Equals(row["note_set_type_name"]) ?  row["note_set_type_name"].ToString() : string.Empty,
                    };

                    minimumThresholds.Add(minimumThreshold);
                }
            }
            return minimumThresholds;

        }
    }
}