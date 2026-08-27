using Azure;
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
    public class ReplenishmentReturnReportService
    {
        //private Executor _executor { get; set; }

        //public ReplenishmentReturnReportService(Executor executor)
        //{
        //    _executor = executor;
        //}
        public BaseModel GetReplenishmentReturn(ReplenishmentReturnReportRequestModel replenishmentReport)
        {
            string filter = "";
            var response = new BaseModel();
            if (replenishmentReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= convert(datetime,'" + replenishmentReport.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (replenishmentReport.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime <= convert(datetime,'" + replenishmentReport.ToDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (replenishmentReport.NoteSetTypeIds.Count > 0)
            {
                filter += " and atm.note_set_type_id in ( " + string.Join(",", replenishmentReport.NoteSetTypeIds) + " ) ";
            }
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", replenishmentReport.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = replenishmentReport.ArchiveYear != string.Empty ? $"_{replenishmentReport.ArchiveYear}" : ""}
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishmentReturnReport", sqlParameters, replenishmentReport.SelectedAtms);
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
