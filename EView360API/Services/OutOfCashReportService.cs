using Common.RequestModel;
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
    public class OutOfCashReportService
    {
        //private Executor _executor { get; set; }

        //public OutOfCashReportService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetOutOfCashReport(OutOfCashReportRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.isDeadATMExcluded)
                queryFilter += " and outerATM.atm_id in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + filter.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and " + "heart_beat_received_at <=convert(datetime,'" + filter.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103))";

            if (filter.NoteSetTypeIds.Count > 0)
            {
                queryFilter += " and outerATM.note_set_type_id in ( " + string.Join(",", filter.NoteSetTypeIds) + " ) ";
            }

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", filter.SelectedAtms)},
                        new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = filter.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = filter.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@IsCurrent", SqlDbType = SqlDbType.Bit, Value = filter.IsCurrent},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetOutOfCashReport", sqlParameters, filter.SelectedAtms);

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
