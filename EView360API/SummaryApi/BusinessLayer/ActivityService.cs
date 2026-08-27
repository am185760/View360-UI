using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SummaryApi.BusinessLayer
{
    public class ActivityService
    {
        private Executor _executor { get; set; }

        public ActivityService(Executor executor)
        {
            _executor = executor;
        }

        public BaseModel GetTodaysActivity(TodaysActivityRequestModel todaysActivityRequest)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "ForDate",
                SqlDbType = SqlDbType.DateTime,
                Value = DateTime.Today,
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "UserId",
                SqlDbType = SqlDbType.BigInt,
                Value = todaysActivityRequest.UserId,
            };
            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "AtmsIds",
                SqlDbType = SqlDbType.VarChar,
                Value = string.Join(",",todaysActivityRequest.SelectedAtms),
            };

            var response = new BaseModel();


            //if (balanceInvestigationViewModel.FromDate != null && balanceInvestigationViewModel.FromDate != DateTime.MinValue)
            //    filter += " and trxn_datetime >= Convert(datetime,'" + balanceInvestigationViewModel.FromDate.Value.ToString("dd/MM/yyyy") + @"',103) ";
            //if (balanceInvestigationViewModel.ToDate != null && balanceInvestigationViewModel.ToDate != DateTime.MinValue)
            //    filter += " and trxn_datetime <= Convert(datetime,'" + balanceInvestigationViewModel.ToDate.Value.ToString("dd/MM/yyyy") + @" 23:59:59',103) ";
            //if (balanceInvestigationViewModel.NoteSetTypeId > 0)
            //    filter += "and atm1.note_set_type_id =" + balanceInvestigationViewModel.NoteSetTypeId;
            //if (balanceInvestigationViewModel.AtmIP != string.Empty)
            //    filter += "and Atm1.ip='" + balanceInvestigationViewModel.AtmIP + "'";


            List<TodaysActivityViewModel> todaysActivity = new();

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetTodaysActivity", new SqlParameter[] { param1, param2,param3 }, todaysActivityRequest.SelectedAtms);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = todaysActivity = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = todaysActivity };
        }

        public List<TodaysActivityViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<TodaysActivityViewModel> todaysActivitys = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    TodaysActivityViewModel todayActivity = new()
                    {
                        Status = !DBNull.Value.Equals(row["Status"]) ? row["Status"].ToString() : string.Empty,
                        Task = !DBNull.Value.Equals(row["Task"]) ? row["Task"].ToString() : string.Empty,
                        Count = !DBNull.Value.Equals(row["Count"]) ? Convert.ToInt32( row["Count"]) : 0,
                    };
                    todaysActivitys.Add(todayActivity);
                }
            }
            return todaysActivitys;

        }
    }
}
