using Common.RequestModel;
using DataRequestor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestorMiddleware
{
    public class DeadAtmReportService
    {
        public DataTableResult GetDeadAtmReport(DeadAtmRptRequestModel rptModel)
        {

            Executor _executor = new();
            DataTableResult dtResult;

            SqlParameter[] sqlParameters = new SqlParameter[]
                        {
                        new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", rptModel.SelectedAtms)},
                        new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.DateTime, Value = rptModel.FromDate},
                        new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.DateTime, Value = rptModel.ToDate},
                        new SqlParameter() {ParameterName = "@NoteSetTypeIds", SqlDbType = SqlDbType.VarChar, Value = rptModel.SelectedNoteSetType},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = rptModel.archiveYear != null ? '_' + rptModel.archiveYear.ToString() : ""}
                        };

            return _executor.ExecuteDSRequest<DataTableResult>("GetDeadAtmsRpt", sqlParameters, rptModel.SelectedAtms, string.Join(",", rptModel.SelectedAtms));
        }
    }
}
