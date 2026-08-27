using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CashUtilizationService
    {
        //private Executor _executor { get; set; }

        //public CashUtilizationService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetCashUtilzation(CashUtilizationReportRequestModel cashUtilizationReport)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();
            SqlParameter param5 = new SqlParameter();

            var response = new BaseModel();
            if (cashUtilizationReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= convert(datetime,'" + cashUtilizationReport.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (cashUtilizationReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime <= convert(datetime,'" + cashUtilizationReport.ToDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (cashUtilizationReport.NoteSetTypeIds.Count > 0)
            {
                filter += " and atm.note_set_type_id in ( " + string.Join(",", cashUtilizationReport.NoteSetTypeIds) + " ) ";
            }
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", cashUtilizationReport.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = cashUtilizationReport.ArchiveYear != string.Empty ? $"_{cashUtilizationReport.ArchiveYear}" : ""
            }
            };
            Executor _executor = new Executor(); 
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetCashUtiizationReport", sqlParameters, cashUtilizationReport.SelectedAtms);
           
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = JsonConvert.SerializeObject(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(result.Table) };
        }
    }
}
