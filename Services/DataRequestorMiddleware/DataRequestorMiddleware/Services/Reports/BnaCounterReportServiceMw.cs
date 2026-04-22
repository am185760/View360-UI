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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class BnaCounterReportServiceMw
    {

        private readonly IConfiguration _configuration;
        private ILogger<BnaCounterReportServiceMw> _logger;

        public BnaCounterReportServiceMw(IConfiguration configuration, ILogger<BnaCounterReportServiceMw> logger = null)
        {
            _configuration = configuration;
            _logger = logger;
        }

        //private Executor _executor { get; set; }
        //public BnaCounterReportServiceMw(Executor executor)
        //{
        //    _executor = executor;
        //}

        public async Task<BaseModel> GetBnaCounterReport(BnaCounterReportRequestModel bnaCounterReportRequest)
        {
            string filter = "";
            var response = new BaseModel();
            DataTable dt = new DataTable();

            filter += " and user_ATMs.user_id =" + bnaCounterReportRequest.UserId;
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

            if (bnaCounterReportRequest.SelectedRegionIds != null || bnaCounterReportRequest.SelectedRegionIds?.Count > 0)
                filter += "and region_id in (" + string.Join(",", bnaCounterReportRequest.SelectedRegionIds) + ") ";
            else
                filter += "and  atm_id in (" + string.Join(",", bnaCounterReportRequest.SelectedAtms) + ")";

            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    //new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", bnaCounterReportRequest.SelectedAtms)},
                    new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                    new SqlParameter() {ParameterName = "@ReportTypeId", SqlDbType = SqlDbType.Int, Value = bnaCounterReportRequest.ReportTypeId},
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                    new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ArchiveYear != string.Empty ? $"_{bnaCounterReportRequest.ArchiveYear}" : ""}

                };
            Executor _executor = new Executor();

            _logger.LogWarning("[BnaCounterReportServiceMw:GetBnaCounterReport] going to execute GetBnaCounterReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBnaCounterReport", sqlParameters, bnaCounterReportRequest.SelectedAtms,string.Join(",", bnaCounterReportRequest.SelectedAtms));
            _logger.LogWarning("[BnaCounterReportServiceMw:GetBnaCounterReport] return from  GetBnaCounterReport sp");


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
                SetDepositsAmount(dt);
                response.Data = JsonConvert.SerializeObject(dt);
            }


            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(dt) };
        }
        private void SetDepositsAmount(DataTable pDataTable)
        {
            for (int i = 0; i < pDataTable.Rows.Count; i++)
            {
                pDataTable.Rows[i]["total"] = Convert.ToInt32(pDataTable.Rows[i]["bna_cassette1"].ToString()) + Convert.ToInt32(pDataTable.Rows[i]["bna_cassette2"].ToString()) + Convert.ToInt32(pDataTable.Rows[i]["bna_cassette3"].ToString()) + Convert.ToInt32(pDataTable.Rows[i]["bna_cassette4"].ToString())+ Convert.ToInt32(pDataTable.Rows[i]["bna_cassette5"].ToString());
            }
        }

        private int[] ParseCassetteDetail(string pCassetteDetail)
        {

            string[] cassetteDetails = null;
            string[] seperator = { "<br>" };
            cassetteDetails = pCassetteDetail.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            int[] cassettecount = new int[cassetteDetails.Length];
            for (int i = 0; i < cassetteDetails.Length - 1; i++)
            {

                string[] temp = cassetteDetails[i].Split('*');
                cassettecount[i] = int.Parse(temp[1]);
            }

            return cassettecount;
        }

        private int ParseCassettetotal(string pCassetteDetail)
        {
            int cassetteAmount = 0;
            string[] cassetteDetails = null;

            if (pCassetteDetail.Contains("="))
            {
                cassetteDetails = pCassetteDetail.Split('=');
                cassetteAmount = int.Parse(cassetteDetails[1].Trim());
            }


            return cassetteAmount;
        }
        private string ExtractDepositAmount(string pCassette1Detail, string pCassette2Detail, string pCassette3Detail, string pCassette4Detail)
        {

            int[] cassette1 = !string.IsNullOrEmpty(pCassette1Detail) ? ParseCassetteDetail(pCassette1Detail) : new int[0];
            int[] cassette2 = !string.IsNullOrEmpty(pCassette2Detail) ? ParseCassetteDetail(pCassette2Detail) : new int[0];
            int[] cassette3 = !string.IsNullOrEmpty(pCassette3Detail) ? ParseCassetteDetail(pCassette3Detail) : new int[0];
            int[] cassette4 = !string.IsNullOrEmpty(pCassette4Detail) ? ParseCassetteDetail(pCassette4Detail) : new int[0];
            int cassette1total = !string.IsNullOrEmpty(pCassette1Detail) ? ParseCassettetotal(pCassette1Detail) : 0;
            int cassette2total = !string.IsNullOrEmpty(pCassette2Detail) ? ParseCassettetotal(pCassette2Detail) : 0;
            int cassette3total = !string.IsNullOrEmpty(pCassette3Detail) ? ParseCassettetotal(pCassette3Detail) : 0;
            int cassette4total = !string.IsNullOrEmpty(pCassette4Detail) ? ParseCassettetotal(pCassette4Detail) : 0;
            int[] cassette = ParseCassette(pCassette1Detail);

            int[] cassetteDetailTotal = new int[cassette1.Length];
            for (int i = 0; i < cassette1.Length; i++)
            {
                cassetteDetailTotal[i] = cassette1[i] + cassette2[i] + cassette3[i] + cassette4[i];
            }

            int cassettetotal = cassette1total + cassette2total + cassette3total + cassette4total;

            string data = null;
            //if (System.Web.Configuration.WebConfigurationManager.AppSettings["IsDisplayDepositDenomination"] == "true")
            if (false)
            {

                for (int i = 0; i < cassetteDetailTotal.Length - 1; i++)
                {
                    data += cassette[i].ToString() + "*" + cassetteDetailTotal[i].ToString() + "<br>";
                }

                data += "=" + cassettetotal.ToString();
            }
            else
            {
                data = cassettetotal.ToString();
            }


            return data;
        }

        private int[] ParseCassette(string pCassetteDetail)
        {

            string[] cassetteDetails = null;
            string[] seperator = { "<br>" };
            cassetteDetails = pCassetteDetail.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            int[] cassettecount = new int[cassetteDetails.Length];
            for (int i = 0; i < cassetteDetails.Length - 1; i++)
            {

                string[] temp = cassetteDetails[i].Split('*');
                cassettecount[i] = int.Parse(temp[0]);
            }

            return cassettecount;
        }
        public async Task<BaseModel> GetBnaCounterSubReportReport(BnaCounterReportRequestModel bnaCounterReportRequest)
        {
            //if (rptModel.ReportTypeId == 1)
            //{
            //        dsSubReport = new DataSet();
            string filter = string.Empty;
            var response = new BaseModel();
            filter += " and user_ATMs.user_id =" + bnaCounterReportRequest.UserId;

            filter += " and atm.atm_id in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy") + "',103) and " +
                     "heart_beat_received_at <=convert(datetime,'" + bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy") + " 23:59:59',103))";

            if (bnaCounterReportRequest.isDeadATMExcluded)
                filter += " and atm.atm_id in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy") + "',103) and " +
                                     "heart_beat_received_at <=convert(datetime,'" + bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy") + " 23:59:59',103))";

            if (bnaCounterReportRequest.SelectedRegionIds != null || bnaCounterReportRequest.SelectedRegionIds?.Count > 0)
                filter += "and atm.region_id in (" + string.Join(",", bnaCounterReportRequest.SelectedRegionIds) + ") ";
            else
                filter += "and  atm.atm_id in (" + string.Join(",", bnaCounterReportRequest.SelectedAtms) + ")";

            SqlParameter[] sqlParameters2 = new SqlParameter[]
            {
                        //new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", bnaCounterReportRequest.SelectedAtms)},
                        new SqlParameter() {ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.FromDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ToDate.ToString("dd/MM/yyyy HH:mm:ss")},
                        new SqlParameter() {ParameterName = "@IsCurrent", SqlDbType = SqlDbType.Bit, Value = bnaCounterReportRequest.IsCurrent},
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter},
                        new SqlParameter() {ParameterName = "@ArchiveYear", SqlDbType = SqlDbType.VarChar, Value = bnaCounterReportRequest.ArchiveYear != string.Empty ? $"_{bnaCounterReportRequest.ArchiveYear}" : ""}
            };
            Executor _executor = new Executor();

            _logger.LogWarning("[BnaCounterReportServiceMw:GetBnaCounterSubReportReport] going to execute GetBnaCounterSubReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBnaCounterSubReport", sqlParameters2, bnaCounterReportRequest.SelectedAtms);
            _logger.LogWarning("[BnaCounterReportServiceMw:GetBnaCounterSubReportReport] return from GetBnaCounterSubReport sp");

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
