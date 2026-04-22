using Common.RequestModel;
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

namespace DataRequestorMiddleware.Services.Summary
{
    public class Top10AtmServiceMw
    {
        //private Executor _executor { get; set; }
        //public Top10AtmServiceMw(Executor executor)
        //{
        //    _executor = executor;
        //}
        public BaseModel GetTop10TransactionAtms(List<string> atmIds)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "ForDate",
                DbType = DbType.DateTime,
                Value = DateTime.Today,
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "order",
                DbType = DbType.Int32,
                Value = 1,
            };
            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "atmIDs",
                DbType = DbType.String,
                Value = atmIds,
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


            List<Top10AtmViewModel> top10Atms = new();
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetTop10ATMs", new SqlParameter[] { param1, param2, param3 }, atmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = top10Atms = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = top10Atms };
        }

        public BaseModel GetTop10LowTransactionAtms(List<string> atmIds)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "ForDate",
                DbType = DbType.DateTime,
                Value = DateTime.Today,
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "order",
                DbType = DbType.Int32,
                Value = 0,
            };
            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "atmIDs",
                DbType = DbType.String,
                Value = atmIds,
            };

            var response = new BaseModel();

            List<Top10AtmViewModel> top10Atms = new();
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetTop10ATMs", new SqlParameter[] { param1, param2, param3 }, atmIds,string.Join(",",atmIds));
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = top10Atms = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = top10Atms };
        }

        public List<Top10AtmViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<Top10AtmViewModel> to10Atms = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Top10AtmViewModel atm = new()
                    {
                        Total = !DBNull.Value.Equals(row["total"]) ? Convert.ToDecimal(row["total"]).ToString() : "0",
                        Tittle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                    };
                    to10Atms.Add(atm);
                }
            }
            return to10Atms;

        }
    }
}
