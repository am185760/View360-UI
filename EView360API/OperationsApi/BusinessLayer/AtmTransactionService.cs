using DataRequestor;
using System.Data.SqlClient;
using System.Data;
using EView360Models.ViewModels;
using EView360Models.RequestModel;
using Azure;
using Microsoft.IdentityModel.Protocols;

namespace OperationsApi.BusinessLayer
{
    public class AtmTransactionService
    {
        private Executor _executor { get; set; }

        public AtmTransactionService(Executor executor)
        {
            _executor = executor;
        }


        public BaseModel GetATMTransactions(WithdrawalTransactionRequestModel withdrawalTransactionFilter)
            {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();

            var response = new BaseModel();

            if (withdrawalTransactionFilter.noteSetTypeId > 0)
                filter += " and note_set_type.note_set_type_id = " + withdrawalTransactionFilter.noteSetTypeId;

            if (withdrawalTransactionFilter.indexId == 0)
            {
                if (withdrawalTransactionFilter.fromDate != null)
                    filter += " and trxn_datetime >= convert(datetime,'" + withdrawalTransactionFilter.fromDate.Value.ToString("dd/MM/yyyy HH:mm") + "',103)";

                if (withdrawalTransactionFilter.toDate != null)
                    filter += " and trxn_datetime<= convert(datetime,'" + withdrawalTransactionFilter.toDate.Value.ToString("dd/MM/yyyy HH:mm") + "',103)";
            }
            else if (withdrawalTransactionFilter.indexId == 1)
            {
                filter += " and trxn_datetime>=(select max(rep_datetime) from cash..replenishment where atm_id=outerATM.atm_id)";
            }
            else if (withdrawalTransactionFilter.indexId == 2)
            {
                param1 = new SqlParameter();
                param1.ParameterName = "@Atm_Id";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = string.Join(",", withdrawalTransactionFilter.UserAtmIds);

                param2 = new SqlParameter();
                param2.ParameterName = "@NumberOfCycle";
                param2.SqlDbType = SqlDbType.NVarChar;
                param2.Value = withdrawalTransactionFilter.numberOfCycle;

                DataTableResult result2 = _executor.ExecuteDSRequest<DataTableResult>("ReplenishmentsMinAndMaxDateOfAtm", new SqlParameter[] { param1, param2 }, withdrawalTransactionFilter.UserAtmIds);

                DateTime upperLimit = new DateTime(1900, 1, 1);
                DateTime lowerLimit = new DateTime(1900, 1, 1);

                if (result2?.Table?.Rows?.Count > 0)
                {
                    upperLimit = !DBNull.Value.Equals(result2?.Table?.Rows[0]["max_date"]) ? Convert.ToDateTime(result2?.Table?.Rows[0]["max_date"]) : new DateTime(1900, 1, 1);
                    lowerLimit = !DBNull.Value.Equals(result2?.Table?.Rows[0]["min_date"]) ? Convert.ToDateTime(result2?.Table?.Rows[0]["min_date"]) : new DateTime(1900, 1, 1);
                }

                if (withdrawalTransactionFilter.indexId == 0)
                    filter += " and trxn_datetime >= convert(datetime,'" + lowerLimit.ToString("dd/MM/yyyy HH:mm:ss") + "',103) " +
                    " and trxn_datetime<= convert(datetime,'" + upperLimit.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                else
                    filter += " and trxn_datetime >= convert(datetime,'" + upperLimit.ToString("dd/MM/yyyy HH:mm:ss") + "',103) " +
                " and trxn_datetime<= convert(datetime,'" + lowerLimit.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            }

            if (withdrawalTransactionFilter.purgedFrom > 0)
                filter += " and (cash_purged1+cash_purged2+cash_purged3+cash_purged4+cash_purged5+cash_purged6+cash_purged7)>=" + withdrawalTransactionFilter.purgedFrom;

            if (withdrawalTransactionFilter.purgedTo > 0)
                filter += " and (cash_purged1+cash_purged2+cash_purged3+cash_purged4+cash_purged5+cash_purged6+cash_purged7)<=" + withdrawalTransactionFilter.purgedTo;

            if (withdrawalTransactionFilter.amountFrom > 0)
                filter += " and amount >= " + withdrawalTransactionFilter.amountFrom;

            if (withdrawalTransactionFilter.amountTo > 0)
                filter += " and amount <= " + withdrawalTransactionFilter.amountTo;

            if (withdrawalTransactionFilter.dispensed1 > 0)
                filter += " and cash_dispensed1 = " + withdrawalTransactionFilter.dispensed1;

            if (withdrawalTransactionFilter.dispensed2 > 0)
                filter += " and cash_dispensed2 = " + withdrawalTransactionFilter.dispensed2;

            if (withdrawalTransactionFilter.dispensed3 > 0)
                filter += " and cash_dispensed3 = " + withdrawalTransactionFilter.dispensed3;

            if (withdrawalTransactionFilter.dispensed4 > 0)
                filter += " and cash_dispensed4 = " + withdrawalTransactionFilter.dispensed4;


            List<WithdrawalTransactionViewModel> atmTaskViews = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = string.Join(",", withdrawalTransactionFilter.UserAtmIds);

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
            param4.Value = withdrawalTransactionFilter?.ArchiveYear != string.Empty ? $"_{withdrawalTransactionFilter.ArchiveYear}" : "";


            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetATMTransactions", new SqlParameter[] { param1, param2, param3, param4 }, withdrawalTransactionFilter.UserAtmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = atmTaskViews = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }
            return new BaseModel { IsSuccess = true, Data = atmTaskViews };
        }

        public List<WithdrawalTransactionViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<WithdrawalTransactionViewModel> atmWithdrawalTransactions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    WithdrawalTransactionViewModel atmWithdrawalTransaction = new()
                    {
                        AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                        Tittle = !DBNull.Value.Equals(row["TITLE"]) ? row["TITLE"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IsBillDispenser = !DBNull.Value.Equals(row["IsBillDispenser"]) ? (Convert.ToBoolean( row["IsBillDispenser"])  == true?"yes":"No" ): string.Empty,
                        IP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        Group = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
                        DateTime = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                        ProcessingDateTime = !DBNull.Value.Equals(row["processing_datetime"]) ? Convert.ToDateTime(row["processing_datetime"]) : null,
                        Amount = !DBNull.Value.Equals(row["amount"]) ? row["amount"].ToString() : string.Empty,
                        Purged1 = !DBNull.Value.Equals(row["cash_purged1"]) ? Convert.ToInt32(row["cash_purged1"]) : 0,
                        Purged2 = !DBNull.Value.Equals(row["cash_purged2"]) ? Convert.ToInt32(row["cash_purged2"]) : 0,
                        Purged3 = !DBNull.Value.Equals(row["cash_purged3"]) ? Convert.ToInt32(row["cash_purged3"]) : 0,
                        Purged4 = !DBNull.Value.Equals(row["cash_purged4"]) ? Convert.ToInt32(row["cash_purged4"]) : 0,
                        Dispensed1 = !DBNull.Value.Equals(row["cash_dispensed1"]) ? Convert.ToInt32(row["cash_dispensed1"]) : 0,
                        Dispensed2 = !DBNull.Value.Equals(row["cash_dispensed2"]) ? Convert.ToInt32(row["cash_dispensed2"]) : 0,
                        Dispensed3 = !DBNull.Value.Equals(row["cash_dispensed3"]) ? Convert.ToInt32(row["cash_dispensed3"]) : 0,
                        Dispensed4 = !DBNull.Value.Equals(row["cash_dispensed4"]) ? Convert.ToInt32(row["cash_dispensed4"]) : 0,
                        Remaining1 = !DBNull.Value.Equals(row["cash_remaining1"]) ? Convert.ToInt32(row["cash_remaining1"]) : 0,
                        Remaining2 = !DBNull.Value.Equals(row["cash_remaining2"]) ? Convert.ToInt32(row["cash_remaining2"]) : 0,
                        Remaining3 = !DBNull.Value.Equals(row["cash_remaining3"]) ? Convert.ToInt32(row["cash_remaining3"]) : 0,
                        Remaining4 = !DBNull.Value.Equals(row["cash_remaining4"]) ? Convert.ToInt32(row["cash_remaining4"]) : 0,
                        PurgedNotes = !DBNull.Value.Equals(row["cash_purgedTotal"]) ? Convert.ToInt32(row["cash_purgedTotal"]) : 0,

                    };
                    atmWithdrawalTransactions.Add(atmWithdrawalTransaction);
                }
            }
            return atmWithdrawalTransactions;

        }
    }
}
