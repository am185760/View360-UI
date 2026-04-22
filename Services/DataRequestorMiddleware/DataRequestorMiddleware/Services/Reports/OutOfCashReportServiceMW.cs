using Common.RequestModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class OutOfCashReportServiceMW
    {
        ILogger<OutOfCashReportServiceMW> logger;
        public OutOfCashReportServiceMW(ILogger<OutOfCashReportServiceMW> logger)
        {
            this.logger = logger;
        }
        public BaseModel GetOutOfCashReport(OutOfCashReportRequestModel filter)
        {
            string queryFilter = "";
            DataTable dt = new DataTable();
            var response = new BaseModel();

            if (filter.isDeadATMExcluded)
                queryFilter += " and outerATM.atm_id in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + filter.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and " + "heart_beat_received_at <=convert(datetime,'" + filter.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103))";

            if (filter.NoteSetTypeIds.Count > 0)
            {
                queryFilter += " and outerATM.note_set_type_id in ( " + string.Join(",", filter.NoteSetTypeIds) + " ) ";
            }

            if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                queryFilter += " and outerATM.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ") and user_ATMs.user_id = " + filter.UserId + " and outerATM.is_active=1 ";
            else
                queryFilter += " and outerATM.atm_id in (" + string.Join(",", filter.SelectedAtms) + ")";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = filter.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = filter.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@IsCurrent", SqlDbType = SqlDbType.Bit, Value = filter.IsCurrent},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = filter?.ArchiveYear != 0 ? "_" + filter.ArchiveYear.ToString() : "" }
            };
            Executor _executor = new Executor();
            logger.LogWarning("[OutOfCashReportServiceMW:GetOutOfCashReport] executing GetOutOfCashReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetOutOfCashReport", sqlParameters, filter.SelectedAtms, string.Join(",", filter.SelectedAtms));
            logger.LogWarning("[OutOfCashReportServiceMW:GetOutOfCashReport] returning from GetOutOfCashReport sp");
            dt = result.Table.Copy();

            //dt.Columns.Add("organization");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            if (!ContainColumn("alert_msg", dt))
            {
                dt.Columns.Add("alert_msg");
            }
            if (!ContainColumn("type1", dt))
            {
                dt.Columns.Add("type1");
            }
            if (!ContainColumn("type2", dt))
            {
                dt.Columns.Add("type2");
            }
            if (!ContainColumn("type3", dt))
            {
                dt.Columns.Add("type3");
            }
            if (!ContainColumn("type4", dt))
            {
                dt.Columns.Add("type4");
            }
            if (!ContainColumn("balance", dt))
            {
                dt.Columns.Add("balance");
            }

            SplitAlertMessageIntoColumns(dt);

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = dt;
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = dt };
        }
        private void SplitAlertMessageIntoColumns(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                string[] parts = dr["alert_msg"].ToString().Split(',');

                dr["type1"] = parts[0];
                dr["type2"] = parts[1];
                dr["type3"] = parts[2];
                dr["type4"] = parts[3];
                dr["balance"] = parts[7];
            }
        }

        private bool ContainColumn(string columnName, DataTable table)
        {
            DataColumnCollection columns = table.Columns;
            if (columns.Contains(columnName))
            {
                return true;
            }
            return false;
        }
    }
}
