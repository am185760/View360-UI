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
    public class ReplenishmentReportService
    {
        //private Executor _executor { get; set; }

        //public ReplenishmentReportService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetReplenishmentReport(ReplenishmentReportRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.Status.Equals("Normal"))
                queryFilter += " and rep_status = '" + filter.Status + "' ";
            else if (filter.Status.Equals("Suspicious"))
                queryFilter += " and rep_status not in ('Normal') ";
            if (filter.NoteSetTypeIds.Count > 0)
                queryFilter += " and atm.note_set_type_id in ( " + string.Join(",", filter.NoteSetTypeIds) + " ) ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", filter.SelectedAtmIds)},
                        new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = filter.FromDate.Value.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = filter.ToDate.Value.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentReport", sqlParameters, filter.SelectedAtmIds);


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
