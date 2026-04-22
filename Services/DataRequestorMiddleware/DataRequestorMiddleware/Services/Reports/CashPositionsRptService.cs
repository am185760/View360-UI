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
    public class CashPositionsRptService
    {
        public DataTableResult GetCashPositionsRpt(DeadAtmRptRequestModel rptModel)
        {
            Executor _executor = new();

            if (rptModel.isCurrent)
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                            new SqlParameter() { ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", rptModel.SelectedAtms) },
                            new SqlParameter() { ParameterName = "@NoteSetTypeIds", SqlDbType = SqlDbType.VarChar, Value = rptModel.SelectedNoteSetType },
                            new SqlParameter() { ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = rptModel.archiveYear != null ? '_' + rptModel.archiveYear.ToString() : "" }
                };

                return _executor.ExecuteDSRequest<DataTableResult>(rptModel.isRecycler? "GetCurrentRecyclerCashPositions" : "GetCurrentCashPositions", sqlParameters, rptModel.SelectedAtms, string.Join(",", rptModel.SelectedAtms));
            }
            else
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                            new SqlParameter() { ParameterName = "@CurrentDate", SqlDbType = SqlDbType.DateTime, Value = rptModel.FromDate },
                            new SqlParameter() { ParameterName = "@ToDate", SqlDbType = SqlDbType.DateTime, Value = rptModel.ToDate },
                            new SqlParameter() { ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", rptModel.SelectedAtms) },
                            new SqlParameter() { ParameterName = "@NoteSetTypeIds", SqlDbType = SqlDbType.VarChar, Value = rptModel.SelectedNoteSetType },
                            new SqlParameter() { ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = rptModel.archiveYear != null ? '_' + rptModel.archiveYear.ToString() : "" }
                };

                return _executor.ExecuteDSRequest<DataTableResult>(rptModel.isRecycler ? "GetDateSpecificRecyclerCashPositions" : "GetDateSpecificCashPositions", sqlParameters, rptModel.SelectedAtms, string.Join(",", rptModel.SelectedAtms));
            }
        }
    }
}
