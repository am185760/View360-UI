using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace OperationsApi.BusinessLayer
{
    public class BalanceInvestigationService
    {
        private Executor _executor { get; set; }

        public BalanceInvestigationService(Executor executor)
        {
            _executor = executor;
        }

        public BaseModel GetBalanceInvestigation(BalanceInvestigationRequestModel balanceInvestigationViewModel)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();

            var response = new BaseModel();


            if (balanceInvestigationViewModel.FromDate != null && balanceInvestigationViewModel.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= Convert(datetime,'" + balanceInvestigationViewModel.FromDate.Value.ToString("dd/MM/yyyy HH:mm") +"',103) ";
            if (balanceInvestigationViewModel.ToDate != null && balanceInvestigationViewModel.ToDate != DateTime.MinValue)
                filter += " and trxn_datetime <= Convert(datetime,'" + balanceInvestigationViewModel.ToDate.Value.ToString("dd/MM/yyyy HH:mm") +"',103) ";
            if (balanceInvestigationViewModel.NoteSetTypeIds.Count > 0)
                filter += "and atm1.note_set_type_id in ( " + string.Join(",", balanceInvestigationViewModel.NoteSetTypeIds) + " )" ;
            if (balanceInvestigationViewModel.AtmIP != string.Empty)
                filter += "and Atm1.ip='" + balanceInvestigationViewModel.AtmIP + "'";


            List<BalanceInvestigationViewModel> balanceInvestigations = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = string.Join(",", balanceInvestigationViewModel.SelectedAtmIds);

            param2 = new SqlParameter();
            param2.ParameterName = "@Filter";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = filter;

            param3 = new SqlParameter();
            param3.ParameterName = "@OrderBy";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = "trxn_datetime desc";

            param4 = new SqlParameter();
            param4.ParameterName = "@ArchiveYear";
            param4.SqlDbType = SqlDbType.VarChar;
            param4.Value = (balanceInvestigationViewModel?.ArchiveYear != null && balanceInvestigationViewModel?.ArchiveYear != 0) ? $"_{balanceInvestigationViewModel.ArchiveYear}" : "";

            SqlParameter param5 = new SqlParameter()
            {
                ParameterName = "@offset",
                SqlDbType = SqlDbType.Int,
                Value = 1
            };

            SqlParameter param6 = new SqlParameter()
            {
                ParameterName = "@RowCount",
                SqlDbType = SqlDbType.Int,
                Value = 1
            };

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBalanceInvestigation", new SqlParameter[] { param1, param2, param3, param4 }, balanceInvestigationViewModel.SelectedAtmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = balanceInvestigations = ConvertDataTableToList(result.Table, balanceInvestigationViewModel.ShowBillColumn);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = balanceInvestigations };
        }

        public List<BalanceInvestigationViewModel> ConvertDataTableToList(DataTable dataTable,bool showBillCoulmn)
        {
            List<BalanceInvestigationViewModel> balanceInvestigations = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (showBillCoulmn)
                    {
                        BalanceInvestigationViewModel balanceInvestigation = new()
                        {

                            BillOpeningBalance = !DBNull.Value.Equals(row["bill_opening_balance"]) ? Convert.ToDecimal(row["bill_opening_balance"]).ToString("N2") : "0",
                            BillClosingBalance = !DBNull.Value.Equals(row["bill_closing_balance"]) ? Convert.ToDecimal(row["bill_closing_balance"]).ToString("N2") : "0",
                            BillPreWthdrawals = !DBNull.Value.Equals(row["bill_pre_withdrawals"]) ? Convert.ToDecimal(row["bill_pre_withdrawals"]).ToString("N2") : "0",
                            BillWthdrawals = !DBNull.Value.Equals(row["bill_withdrawals"]) ? Convert.ToDecimal(row["bill_withdrawals"]).ToString("N2") : "0",
                            BillReturns = !DBNull.Value.Equals(row["bill_return_amount"]) ? Convert.ToDecimal(row["bill_return_amount"]).ToString("N2") : "0",

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
                    else 
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
            }
            return balanceInvestigations;

        }

    }
}
