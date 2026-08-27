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
    public class BnaCounterReportService
    {
        //private Executor _executor { get; set; }

        //public BnaCounterReportService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetBnaCounterReport(BnaCounterReportRequestModel bnaCounterReportRequest)
        {
            string filter = "";
            var response = new BaseModel();
            DataTable dt = new DataTable();
            if (!bnaCounterReportRequest.IsCurrent)
            {
                if (bnaCounterReportRequest.FromDate != null && bnaCounterReportRequest.FromDate != DateTime.MinValue)
                    filter += " and last_bna_deposit_at >= convert(datetime,'" + bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy HH:mm") + "',103) ";

                if (bnaCounterReportRequest.ToDate != null && bnaCounterReportRequest.ToDate != DateTime.MinValue)
                    filter += " and last_bna_deposit_at <= convert(datetime,'" + bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy HH:mm") + "',103)";
            }
            else
            {
                filter += " and last_bna_deposit_at in (select max(last_bna_deposit_at) from Cash.dbo.vDepositPosition where atm_id = deposited_notes.atm_id)";
            }

            if (bnaCounterReportRequest.NoteSetTypeIds.Count > 0)
                filter += " and note_set_type_id in ( " + string.Join(",", bnaCounterReportRequest.NoteSetTypeIds) + " ) ";

            if (bnaCounterReportRequest.isDeadATMExcluded)
                filter += " and ATM_id in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy") + "',103) and " +
                                     "heart_beat_received_at <=convert(datetime,'" + bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy") + " 23:59:59',103))";

            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", bnaCounterReportRequest.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@ReportTypeId", SqlDbType = SqlDbType.Int, Value = bnaCounterReportRequest.ReportTypeId},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ArchiveYear != string.Empty ? $"_{bnaCounterReportRequest.ArchiveYear}" : ""}

                };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBnaCounterReport", sqlParameters, bnaCounterReportRequest.SelectedAtms);

            if (result?.Table?.Rows?.Count > 0)
            {
                dt = result.Table.Copy();
                if (!ContainColumn("total_trxn", dt))
                {
                    dt.Columns.Add("total_trxn");
                }
                if (!ContainColumn("denomination_type_1", dt))
                {
                    dt.Columns.Add("denomination_type_1");
                }
                if (!ContainColumn("denomination_type_2", dt))
                {
                    dt.Columns.Add("denomination_type_2");
                }
                if (!ContainColumn("denomination_type_3", dt))
                {
                    dt.Columns.Add("denomination_type_3");
                }
                if (!ContainColumn("denomination_type_4", dt))
                {
                    dt.Columns.Add("denomination_type_4");
                }
                if (!ContainColumn("cassette1_denomination_detail", dt))
                {
                    dt.Columns.Add("cassette1_denomination_detail");
                }
                if (!ContainColumn("cassette1_denomination_detail", dt))
                {
                    dt.Columns.Add("cassette1_denomination_detail");
                }
                if (!ContainColumn("cassette2_denomination_detail", dt))
                {
                    dt.Columns.Add("cassette2_denomination_detail");
                }
                if (!ContainColumn("cassette3_denomination_detail", dt))
                {
                    dt.Columns.Add("cassette3_denomination_detail");
                }
                if (!ContainColumn("cassette4_denomination_detail", dt))
                {
                    dt.Columns.Add("cassette4_denomination_detail");
                }
                if (!ContainColumn("organization", dt))
                {
                    dt.Columns.Add("organization");
                }
                response.Data = JsonConvert.SerializeObject(dt);
            }


            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(dt) };
        }

        public BaseModel GetBnaCounterSubReportReport(BnaCounterReportRequestModel bnaCounterReportRequest)
        {
            //if (rptModel.ReportTypeId == 1)
            //{
            //        dsSubReport = new DataSet();
            string filter = string.Empty;
            var response = new BaseModel();

            if (bnaCounterReportRequest.isDeadATMExcluded)
                filter += " and atm.atm_id in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy") + "',103) and " +
                                     "heart_beat_received_at <=convert(datetime,'" + bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy") + " 23:59:59',103))";

            SqlParameter[] sqlParameters2 = new SqlParameter[]
            {
                        new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", bnaCounterReportRequest.SelectedAtms)},
                        new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@IsCurrent", SqlDbType = SqlDbType.Bit, Value = bnaCounterReportRequest.IsCurrent},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ArchiveYear != string.Empty ? $"_{bnaCounterReportRequest.ArchiveYear}" : ""}
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBnaCounterSubReport", sqlParameters2, bnaCounterReportRequest.SelectedAtms);

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = JsonConvert.SerializeObject(result?.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(result?.Table) };
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
