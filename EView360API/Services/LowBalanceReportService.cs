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
    public class LowBalanceReportService
    {
        //private Executor _executor { get; set; }

        //public LowBalanceReportService(Executor executor)
        //{
        //    _executor = executor;
        //}
        public BaseModel GetLowBalance(LowBalanceReportRequestModel lowBalance)
        {
            var response = new BaseModel();
            string filter = "";
            DataTable dt = new DataTable();
            if (lowBalance.isDeadATMExcluded)
                filter += " and outerATM.atm_id in (select ATM_id from vHeartBeat where heart_beat_received_at >=convert(datetime,'" + lowBalance.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and " +
                                     "heart_beat_received_at <=convert(datetime,'" + lowBalance.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103))";

            if (lowBalance.NoteSetTypeIds.Count > 0)
            {
                filter += " and outerATM.note_set_type_id in ( " + string.Join(",", lowBalance.NoteSetTypeIds) + " ) ";
            }

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", lowBalance.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = lowBalance.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = lowBalance.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@IsCurrent", SqlDbType = SqlDbType.Bit, Value = lowBalance.IsCurrent},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = lowBalance.ArchiveYear != string.Empty ? $"_{lowBalance.ArchiveYear}" : ""}
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetLowBalanceReport", sqlParameters, lowBalance.SelectedAtms);
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
                response.Data = JsonConvert.SerializeObject(dt);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(dt) };

            //ds.Tables[0].TableName = "DataTable1";
            //rptDoc.SetDataSource(ds);

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
