using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace OperationsApi.BusinessLayer
{
    public class BnaTransactionService
    {
        private Executor _executor { get; set; }
        private readonly IConfiguration configuration;

        public BnaTransactionService(Executor executor, IConfiguration configuration)
        {
            _executor = executor;
            this.configuration = configuration;
        }
        public BaseModel GetBnaTransaction(BNATransactionRequestModel bNATransactionRequestModel)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();

            var response = new BaseModel();

            if (bNATransactionRequestModel.fromDate != null)
                filter += $" and last_bna_deposit_at >= convert(datetime , '{bNATransactionRequestModel.fromDate.Value.ToString("dd/MM/yyyy HH: mm:ss")}' ,103)";

            if (bNATransactionRequestModel.toDate != null)
                filter += $" and last_bna_deposit_at <= convert(datetime, '{bNATransactionRequestModel.toDate.Value.ToString("dd/MM/yyyy HH: mm:ss")}',103)";


            List<BnaTransactionViewModel> bnaTransactions = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = string.Join(",", bNATransactionRequestModel.SelectedAtmIds);

            param2 = new SqlParameter();
            param2.ParameterName = "@Filter";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = filter;

            param3 = new SqlParameter();
            param3.ParameterName = "@OrderBy";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = "last_bna_deposit_at desc";

            param4 = new SqlParameter();
            param4.ParameterName = "@ArchiveYear";
            param4.SqlDbType = SqlDbType.VarChar;
            param4.Value = bNATransactionRequestModel?.ArchiveYear != string.Empty ? $"_{bNATransactionRequestModel.ArchiveYear}" : "";

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetBNATransaction", new SqlParameter[] { param1, param2, param3, param4 }, bNATransactionRequestModel.SelectedAtmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = bnaTransactions = ConvertBNATransactionDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = bnaTransactions };
        }

        public List<BnaTransactionViewModel> ConvertBNATransactionDataTableToList(DataTable dataTable)
        {
            List<BnaTransactionViewModel> bnaTransactions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    BnaTransactionViewModel bnaTransaction = new()
                    {
                        Cassette1 = !DBNull.Value.Equals(row["bna_cassette1"]) ? Convert.ToInt32(row["bna_cassette1"]) : 0,
                        Cassette2 = !DBNull.Value.Equals(row["bna_cassette2"]) ? Convert.ToInt32(row["bna_cassette2"]) : 0,
                        Cassette3 = !DBNull.Value.Equals(row["bna_cassette3"]) ? Convert.ToInt32(row["bna_cassette3"]) : 0,
                        Cassette4 = !DBNull.Value.Equals(row["bna_cassette4"]) ? Convert.ToInt32(row["bna_cassette4"]) : 0,
                        Cassette5 = !DBNull.Value.Equals(row["bna_cassette5"]) ? Convert.ToInt32(row["bna_cassette5"]) : 0,
                        LastBNADeposit = !DBNull.Value.Equals(row["last_bna_deposit_at"]) ? Convert.ToDateTime(row["last_bna_deposit_at"]) : null,
                        //Total = ExtractDepositAmount(row["cassette1_denomination_detail"].ToString(), row["cassette2_denomination_detail"].ToString(), row["cassette3_denomination_detail"].ToString(), row["cassette4_denomination_detail"].ToString()),
                        //Total = (Cassette1 + Cassette2 + Cassette3 + Cassette4 + Cassette5) ,
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0
                    };
                    bnaTransaction.Total = bnaTransaction.Cassette1 + bnaTransaction.Cassette2 + bnaTransaction.Cassette3 + bnaTransaction.Cassette4 + bnaTransaction.Cassette5;
                    bnaTransactions.Add(bnaTransaction);
                }
            }
            return bnaTransactions;

        }

        public List<BnaTransactionDashboardViewModel> ConvertBNATransactionDashboardDataTableToList(DataTable dataTable)
        {
            List<BnaTransactionDashboardViewModel> bnaTransactions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    BnaTransactionDashboardViewModel bnaTransaction = new()
                    {

                        AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt64(row["atm_id"]) : 0,
                        Cassette1 = !DBNull.Value.Equals(row["cassette1_deposit"]) ? Convert.ToInt32(row["cassette1_deposit"]) : 0,
                        Cassette2 = !DBNull.Value.Equals(row["cassette2_deposit"]) ? Convert.ToInt32(row["cassette2_deposit"]) : 0,
                        Cassette3 = !DBNull.Value.Equals(row["cassette3_deposit"]) ? Convert.ToInt32(row["cassette3_deposit"]) : 0,
                        Cassette4 = !DBNull.Value.Equals(row["cassette4_deposit"]) ? Convert.ToInt32(row["cassette4_deposit"]) : 0,
                        Cassette5 = !DBNull.Value.Equals(row["purge_deposit"]) ? Convert.ToInt32(row["purge_deposit"]) : 0,
                        LastBNADeposit = !DBNull.Value.Equals(row["last_bna_deposit_at"]) ? Convert.ToDateTime(row["last_bna_deposit_at"]) : null,
                        LastBNAClearedAt = !DBNull.Value.Equals(row["last_bna_cleared_at"]) ? Convert.ToDateTime(row["last_bna_cleared_at"]) : null,
                        //Total = ExtractDepositAmount(row["cassette1_deposit_value"].ToString(), row["cassette2_deposit_value"].ToString(), row["cassette3_deposit_value"].ToString(), row["cassette4_deposit_value"].ToString()),
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Region = !DBNull.Value.Equals(row["Region_name"]) ? row["Region_name"].ToString() : string.Empty,
                        //DenominationDetail = !DBNull.Value.Equals(row["cassette1_deposit_value"]) ? row["cassette1_deposit_value"].ToString() : string.Empty,
                    };
                    bnaTransaction.Total = bnaTransaction.Cassette1 + bnaTransaction.Cassette2 + bnaTransaction.Cassette3 + bnaTransaction.Cassette4 + bnaTransaction.Cassette5;
                    bnaTransactions.Add(bnaTransaction);

                }
            }
            return bnaTransactions;

        }

        public BaseModel GetAtmBnaDeposit(BNADepositRequestModel bNADepositRequestModel)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();

            var response = new BaseModel();

            if (bNADepositRequestModel.NodeSetTypeId > 0)
                filter += $" and outerATM.note_set_type_id = " + bNADepositRequestModel.NodeSetTypeId;

            List<BnaTransactionDashboardViewModel> bnaTransactions = new();
            param3 = new SqlParameter();
            param3.ParameterName = "@AtmId";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = string.Join(",", bNADepositRequestModel.SelectedAtmIds);

            param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = filter;

            param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = "last_bna_deposit_at desc";

            param4 = new SqlParameter();
            param4.ParameterName = "@ArchiveYear";
            param4.SqlDbType = SqlDbType.VarChar;
            param4.Value = bNADepositRequestModel?.ArchiveYear != string.Empty ? $"_{bNADepositRequestModel.ArchiveYear}" : "";

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("[GetDashboardBNADepositTransaction]", new SqlParameter[] { param1, param2, param3, param4 }, bNADepositRequestModel.SelectedAtmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = bnaTransactions = ConvertBNATransactionDashboardDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = bnaTransactions };
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

            if (configuration["IsDisplayDepositDenomination"] == "true")
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

    }
}
