using Common.RequestModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EView360Models.RequestModel;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class LowBalanceReportServiveMw
    {
        //private Executor _executor { get; set; }
        //public LowBalanceReportServiveMw(Executor executor)
        //{
        //    _executor = executor;
        //}
        private ILogger<LowBalanceReportServiveMw> _logger;
        public LowBalanceReportServiveMw(ILogger<LowBalanceReportServiveMw> logger)
        {
            _logger = logger;
        }
        public async Task<BaseModel> GetLowBalance(LowBalanceReportRequestModel lowBalance)
        {
            var response = new BaseModel();
            string filter = "";
            DataTable dt = new DataTable();
            string archiveYear = lowBalance.ArchiveYear != string.Empty ? $"_{lowBalance.ArchiveYear}" : "";
            filter += " and user_ATMs.user_id =" + lowBalance.UserId;

            if (lowBalance.isDeadATMExcluded)
                filter += " and outerATM.atm_id in (select ATM_id from vHeartBeat where heart_beat_received_at >=convert(datetime,'" + lowBalance.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and " +
                                     "heart_beat_received_at <=convert(datetime,'" + lowBalance.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103))";

            if (lowBalance.NoteSetTypeIds.Count > 0)
            {
                filter += " and outerATM.note_set_type_id in ( " + string.Join(",", lowBalance.NoteSetTypeIds) + " ) ";
            }

            if (lowBalance.SelectedRegionIds != null || lowBalance.SelectedRegionIds?.Count > 0)
                filter += "and outerATM.region_id in (" + string.Join(",", lowBalance.SelectedRegionIds) + ") and outerATM.IS_ACTIVE = 1";
            else
                filter += "and  outerATM.atm_id in (" + string.Join(",", lowBalance.SelectedAtms) + ")";

            if (lowBalance.minThreshold > 0 && (lowBalance.maxThreshold == null || lowBalance.maxThreshold == 0))
            {
                filter += $"and (select CAST(ISNULL(note_set_type.denomination_type_1,0) as numeric(18,2)) * CAST(ISNULL(cassette1_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_2,0) as numeric(18,2)) * CAST(ISNULL(cassette2_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_3,0) as numeric(18,2)) * CAST(ISNULL(cassette3_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_4,0) as numeric(18,2)) * CAST(ISNULL(cassette4_notes,0) as numeric(18,2)) from Cash" + archiveYear + ".dbo.vCashPosition,atm , note_set_type " +
                                    "where vCashPosition.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and vCashPosition.atm_id = outerATM.atm_id " +
                                    "and last_trxn_at = (select max(last_trxn_at) from Cash" + archiveYear + ".dbo.vCashPosition where atm_id = outerATM.atm_id)) >= " + lowBalance.minThreshold;
            }
            else if (lowBalance.maxThreshold > 0 && (lowBalance.minThreshold == null || lowBalance.minThreshold == 0))
            {
                filter += $"and (select CAST(ISNULL(note_set_type.denomination_type_1,0) as numeric(18,2)) * CAST(ISNULL(cassette1_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_2,0) as numeric(18,2)) * CAST(ISNULL(cassette2_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_3,0) as numeric(18,2)) * CAST(ISNULL(cassette3_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_4,0) as numeric(18,2)) * CAST(ISNULL(cassette4_notes,0) as numeric(18,2)) from Cash" + archiveYear + ".dbo.vCashPosition,atm , note_set_type " +
                                    "where vCashPosition.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and vCashPosition.atm_id = outerATM.atm_id " +
                                    "and last_trxn_at = (select max(last_trxn_at) from Cash" + archiveYear + ".dbo.vCashPosition where atm_id = outerATM.atm_id)) <= " + lowBalance.minThreshold;
            }
            else if (lowBalance.maxThreshold > 0 && lowBalance.minThreshold > 0)
            {
                filter += $" and (select CAST(ISNULL(note_set_type.denomination_type_1,0) as numeric(18,2)) * CAST(ISNULL(cassette1_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_2,0) as numeric(18,2)) * CAST(ISNULL(cassette2_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_3,0) as numeric(18,2)) * CAST(ISNULL(cassette3_notes,0) as numeric(18,2)) +" +
                                    "CAST(ISNULL(note_set_type.denomination_type_4,0) as numeric(18,2)) * CAST(ISNULL(cassette4_notes,0) as numeric(18,2)) from Cash" + archiveYear + ".dbo.vCashPosition,atm , note_set_type " +
                                    "where vCashPosition.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and vCashPosition.atm_id = outerATM.atm_id " +
                                    $"and last_trxn_at = (select max(last_trxn_at) from Cash" + archiveYear + ".dbo.vCashPosition where atm_id = outerATM.atm_id)) between " + lowBalance.minThreshold + " and " + lowBalance.maxThreshold;
            }
            else 
            {
                filter += $" and (select CAST(ISNULL(note_set_type.denomination_type_1,0) as numeric(18,2)) * CAST(ISNULL(cassette1_notes,0) as numeric(18,2)) +" +
                                      "CAST(ISNULL(note_set_type.denomination_type_2,0) as numeric(18,2)) * CAST(ISNULL(cassette2_notes,0) as numeric(18,2)) +" +
                                      "CAST(ISNULL(note_set_type.denomination_type_3,0) as numeric(18,2)) * CAST(ISNULL(cassette3_notes,0) as numeric(18,2)) +" +
                                      "CAST(ISNULL(note_set_type.denomination_type_4,0) as numeric(18,2)) * CAST(ISNULL(cassette4_notes,0) as numeric(18,2)) from Cash" + archiveYear + ".dbo.vCashPosition,atm , note_set_type " +
                                      "where vCashPosition.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and vCashPosition.atm_id = outerATM.atm_id " +
                                      $"and last_trxn_at = (select max(last_trxn_at) from Cash" + archiveYear + ".dbo.vCashPosition where atm_id = outerATM.atm_id)) > outerATM.out_of_cash_threshold";

            }
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    //new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", lowBalance.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = lowBalance.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = lowBalance.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@IsCurrent", SqlDbType = SqlDbType.Bit, Value = lowBalance.IsCurrent},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = archiveYear}
            };
            Executor _executor = new Executor();
            _logger.LogWarning($"LowBalanceReportServiceMw:GetLowBalance] going to execute GetLowBalanceReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetLowBalanceReport", sqlParameters, lowBalance.SelectedAtms, string.Join(",", lowBalance.SelectedAtms));
            _logger.LogWarning($"LowBalanceReportServiceMw:GetLowBalance] return from  GetLowBalanceReport sp");

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

