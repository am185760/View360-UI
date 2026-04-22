using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EView360Models.RequestModel;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Operations
{
    public class BalanceInvestigationMw
    {
        ILogger<BalanceInvestigationMw> logger;

        public BalanceInvestigationMw(ILogger<BalanceInvestigationMw> logger)
        {
            this.logger = logger;
        }

        //private Executor _executor { get; set; }

        //public BalanceInvestigationMw()
        //{
        //    _executor = new Executor();
        //}

        public async Task GetBalanceInvestigation(BalanceInvestigationRequestModel balanceInvestigationViewModel ,Executor executor)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();

            var response = new BaseModel();

            filter += " and user_ATMs.user_id =" + balanceInvestigationViewModel.UserId;
            if (balanceInvestigationViewModel.FromDate != null && balanceInvestigationViewModel.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= Convert(datetime,'" + balanceInvestigationViewModel.FromDate.Value.ToString("dd/MM/yyyy HH:mm") + "',103) ";
            if (balanceInvestigationViewModel.ToDate != null && balanceInvestigationViewModel.ToDate != DateTime.MinValue)
                filter += " and trxn_datetime <= Convert(datetime,'" + balanceInvestigationViewModel.ToDate.Value.ToString("dd/MM/yyyy HH:mm") + "',103) ";
            if (balanceInvestigationViewModel.NoteSetTypeIds.Count > 0)
                filter += "and atm1.note_set_type_id in ( " + string.Join(",", balanceInvestigationViewModel.NoteSetTypeIds) + " )";
            if (balanceInvestigationViewModel.AtmIP != string.Empty)
                filter += "and Atm1.ip='" + balanceInvestigationViewModel.AtmIP + "'";
            if (balanceInvestigationViewModel.SelectedRegionIds != null || balanceInvestigationViewModel.SelectedRegionIds?.Count > 0)
                filter += "and Atm1.region_id in (" + string.Join(",", balanceInvestigationViewModel.SelectedRegionIds) + ") and Atm1.IS_ACTIVE = 1   ";
            else
                filter += "and  Atm1.atm_id in (" + string.Join(",", balanceInvestigationViewModel.SelectedAtmIds) + ")";


            List<BalanceInvestigationViewModel> balanceInvestigations = new();
            //param1 = new SqlParameter();
            //param1.ParameterName = "@AtmId";
            //param1.SqlDbType = SqlDbType.VarChar;
            //param1.Value = string.Empty;

            param2 = new SqlParameter();
            param2.ParameterName = "@Filter";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = filter;

            param3 = new SqlParameter();
            param3.ParameterName = "@OrderBy";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = string.IsNullOrEmpty(balanceInvestigationViewModel.Orderby) ? "trxn_datetime asc" : balanceInvestigationViewModel.Orderby;

            param4 = new SqlParameter();
            param4.ParameterName = "@ArchiveYear";
            param4.SqlDbType = SqlDbType.VarChar;
            param4.Value = (balanceInvestigationViewModel?.ArchiveYear != null && balanceInvestigationViewModel?.ArchiveYear != 0) ? $"_{balanceInvestigationViewModel.ArchiveYear}" : "";


            SqlParameter param6 = new SqlParameter()
            {
                ParameterName = "@offset",
                SqlDbType = SqlDbType.Int,
                Value = balanceInvestigationViewModel.offset
            };

            SqlParameter param7 = new SqlParameter()
            {
                ParameterName = "@RowCount",
                SqlDbType = SqlDbType.Int,
                Value = balanceInvestigationViewModel.rowCount
            };

            //Executor _executor = new Executor();
            logger.LogWarning("[BalanceInvestigationMw:GetBalanceInvestigation] executing GetBalanceInvestigation sp");
            executor.ExecuteDSRequest<DataTableResult>("GetBalanceInvestigation", new SqlParameter[] { param2, param3, param4,param6,param7 }, balanceInvestigationViewModel.SelectedAtmIds,string.Join(",", balanceInvestigationViewModel.SelectedAtmIds));
            logger.LogWarning("[BalanceInvestigationMw:GetBalanceInvestigation] return from GetBalanceInvestigation sp");

            //if (result?.Table?.Rows?.Count > 0)
            //{
            //    response.Data = balanceInvestigations = ConvertDataTableToList(result.Table);
            //    response.TotalRecords = balanceInvestigations.GroupBy(x => x.RowCount).Select(x => x.Key).Sum(); 
            //}
            //if (!string.IsNullOrEmpty(result.ExceptionMessage))
            //{
            //    response.Message = result.ExceptionMessage;
            //    return response;
            //}


            //return new BaseModel { IsSuccess = true, Data = balanceInvestigations , TotalRecords = response.TotalRecords };
        }

        public List<BalanceInvestigationViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<BalanceInvestigationViewModel> balanceInvestigations = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    BalanceInvestigationViewModel balanceInvestigation = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        OperationBalance = !DBNull.Value.Equals(row["opening_balance"]) ? Convert.ToDecimal(row["opening_balance"]).ToString("N2") : "0",
                        Replenishment = !DBNull.Value.Equals(row["replenishment_amount"]) ? Convert.ToDecimal(row["replenishment_amount"]).ToString("N2") : "0",
                        PreWithdrawals = !DBNull.Value.Equals(row["pre_withdrawals"]) ? Convert.ToDecimal(row["pre_withdrawals"]).ToString("N2") : "0",
                        Returns = !DBNull.Value.Equals(row["return_amount"]) ? Convert.ToDecimal(row["return_amount"]).ToString("N2") : "0",
                        Withdrawals = !DBNull.Value.Equals(row["withdrawals"]) ? Convert.ToDecimal(row["withdrawals"]).ToString("N2") : "0",
                        ClosingBalance = !DBNull.Value.Equals(row["closing_balance"]) ? Convert.ToDecimal(row["closing_balance"]).ToString("N2") : "0",
                        CashPositionBalance = !DBNull.Value.Equals(row["cash_pos_balance"]) ? Convert.ToDecimal(row["cash_pos_balance"]).ToString("N2") : "0",
                        SummaryId = !DBNull.Value.Equals(row["summary_id"]) ? Convert.ToInt32(row["summary_id"]) : 0,
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        AtmIp = !DBNull.Value.Equals(row["ip"]) ? row["ip"].ToString() : string.Empty,
                        AtmLocation = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        TxrnDateTime = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0,
                    };
                    balanceInvestigations.Add(balanceInvestigation);
                }
            }
            return balanceInvestigations;

        }
    }
}
