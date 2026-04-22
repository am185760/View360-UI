using Common.RequestModel;
using DataRequestor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestorMiddleware
{
    public class ATMWithoutTransaction24HourService
    {
        public DataTableResult GetATMWithoutTransaction24Hour(DeadAtmRptRequestModel model)
        {
            Executor _executor = new();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", model.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.DateTime, Value = model.FromDate},
                    new SqlParameter() {ParameterName = "@NoteSetTypeIds", SqlDbType = SqlDbType.VarChar, Value = model.SelectedNoteSetType}
            };
            return _executor.ExecuteDSRequest<DataTableResult>("GetATMWithoutTransaction24Hour", sqlParameters, model.SelectedAtms, string.Join(",", model.SelectedAtms));
        }
    }
}
