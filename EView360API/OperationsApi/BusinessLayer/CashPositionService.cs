using DataRequestor;
using System.Data.SqlClient;
using System.Data;
using EView360Models.ViewModels;
using EView360Models.RequestModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OperationsApi.BusinessLayer
{
    public class CashPositionService
    {
        private Executor _executor { get; set; }

        public CashPositionService(Executor executor)
        {
            _executor = executor;
        }

        public List<CashPositionViewModel> GetDashboardCashPosition(CashPositionFilter cashPositionFilter, ref string errorMsg)
        {
            List<CashPositionViewModel> cashPositions = new();
            if (cashPositionFilter?.AtmIds?.Count > 0)
            {
                SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@Date",SqlDbType = SqlDbType.DateTime,Value = cashPositionFilter.date},
                    new SqlParameter() {ParameterName = "@NoteSetTypeId",SqlDbType = SqlDbType.Int,Value = cashPositionFilter.NoteSetTypeIds?.First()},
                    new SqlParameter() {ParameterName = "@MinNotesAlertExists",SqlDbType = SqlDbType.Int,Value = cashPositionFilter.MinNotesAlertExists},
                    new SqlParameter() {ParameterName = "@OrderBy",SqlDbType = SqlDbType.VarChar,Value = cashPositionFilter.OrderBy},
                    new SqlParameter() {ParameterName = "@AtmId",SqlDbType = SqlDbType.VarChar,Value = string.Join(",", cashPositionFilter.AtmIds)},
                    new SqlParameter() {ParameterName = "@ArchiveYear",SqlDbType = SqlDbType.VarChar,Value = cashPositionFilter.archiveYear != null ? '_' + cashPositionFilter.archiveYear : ""},
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>(cashPositionFilter.SpName, paramArray, cashPositionFilter.AtmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    cashPositions = BuildDashboardCashPosition(result.Table);
                }                
            }
            return cashPositions;
        }

        public List<CashPositionViewModel> BuildDashboardCashPosition(DataTable dataTable)
        {
            List<CashPositionViewModel> cashPositions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    CashPositionViewModel cashPosition = new()
                    {
                        AtmTitle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        LastTrxnAt = !DBNull.Value.Equals(row["last_trxn_at"]) ? Convert.ToDateTime(row["last_trxn_at"]) : DateTime.Now,
                        LastReplenishmentAt = !DBNull.Value.Equals(row["last_replenished_at"]) ? Convert.ToDateTime(row["last_replenished_at"]) : DateTime.Now,
                        DenominationType1 = !DBNull.Value.Equals(row["denomination_type_1"]) ? Convert.ToInt32(row["denomination_type_1"]) : null,
                        Cassette1Denomination = !DBNull.Value.Equals(row["cassette1_notes"]) ? Convert.ToInt32(row["cassette1_notes"]) : 0,
                        DenominationType2 = !DBNull.Value.Equals(row["denomination_type_2"]) ? Convert.ToInt32(row["denomination_type_2"]) : null,
                        Cassette2Denomination = !DBNull.Value.Equals(row["cassette2_notes"]) ? Convert.ToInt32(row["cassette2_notes"]) : 0,
                        DenominationType3 = !DBNull.Value.Equals(row["denomination_type_3"]) ? Convert.ToInt32(row["denomination_type_3"]) : null,
                        Cassette3Denomination = !DBNull.Value.Equals(row["cassette3_notes"]) ? Convert.ToInt32(row["cassette3_notes"]) : 0,
                        DenominationType4 = !DBNull.Value.Equals(row["denomination_type_4"]) ? Convert.ToInt32(row["denomination_type_4"]) : null,
                        Cassette4Denomination = !DBNull.Value.Equals(row["cassette4_notes"]) ? Convert.ToInt32(row["cassette4_notes"]) : 0,
                        TotalRemaining = !DBNull.Value.Equals(row["total_text"]) ? Convert.ToDecimal(row["total_text"]) : null,
                        PurgedNotes = !DBNull.Value.Equals(row["purged_counts"]) ? Convert.ToInt32(row["purged_counts"]) : null,
                        PurgedAmount = !DBNull.Value.Equals(row["purged_amount"]) ? Convert.ToInt32(row["purged_amount"]) : null,
                    };
                    cashPositions.Add(cashPosition);
                }
            }
            return cashPositions;
        }

        public List<CashPositionViewModel> GetCashPositions(ref int totalRecord, CashPositionFilter cashPositionFilter, ref string errorMsg)
        {
            List<CashPositionViewModel> cashPositions = new();
            if (cashPositionFilter?.AtmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@AtmIds",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", cashPositionFilter.AtmIds)
                };

                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@FromDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = cashPositionFilter.fromDate
                };

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@ToDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = cashPositionFilter.toDate
                };

                SqlParameter param4 = new SqlParameter()
                {
                    ParameterName = "@NoteSetTypeIds",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", cashPositionFilter.NoteSetTypeIds) ?? null
                };

                SqlParameter param5 = new SqlParameter()
                {
                    ParameterName = "@ArchiveYear",
                    SqlDbType = SqlDbType.VarChar,
                    Value = cashPositionFilter.archiveYear != null ? '_' + cashPositionFilter.archiveYear : ""
                };

                SqlParameter param6 = new SqlParameter()
                {
                    ParameterName = "@offset",
                    SqlDbType = SqlDbType.Int,
                    Value = cashPositionFilter.offset
                };

                SqlParameter param7 = new SqlParameter()
                {
                    ParameterName = "@RowCount",
                    SqlDbType = SqlDbType.Int,
                    Value = cashPositionFilter.rowCount
                };

                DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>(cashPositionFilter.SpName, new SqlParameter[] { param1, param2, param3, param4, param5, param6, param7 }, cashPositionFilter.AtmIds);
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.Table?.Rows?.Count > 0)
                {
                    cashPositions = BuildCashPosition(result.Table);
                    totalRecord = cashPositions.FirstOrDefault().RowCount;
                }
            }
            return cashPositions;
        }
        public List<CashPositionViewModel> BuildCashPosition(DataTable dataTable)
        {
            List<CashPositionViewModel> cashPositions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    CashPositionViewModel cashPosition = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0,
                        AtmTitle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Ip = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        NoteSetTypeName = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
                        LastTrxnAt = !DBNull.Value.Equals(row["last_trxn_at"]) ? Convert.ToDateTime(row["last_trxn_at"]) : DateTime.Now,
                        LastSuccessfulTrxnAt = !DBNull.Value.Equals(row["last_successful_trxn_at"]) ? Convert.ToDateTime(row["last_successful_trxn_at"]) : DateTime.Now,
                        LastReplenishmentAt = !DBNull.Value.Equals(row["last_replenishment_at"]) ? Convert.ToDateTime(row["last_replenishment_at"]) : DateTime.Now,
                        DenominationType1 = !DBNull.Value.Equals(row["denomination_type_1"]) ? Convert.ToInt32(row["denomination_type_1"]) : null,
                        Cassette1Denomination = !DBNull.Value.Equals(row["cassette1_notes"]) ? Convert.ToInt32(row["cassette1_notes"]) : 0,
                        PurgeCassette1Notes = !DBNull.Value.Equals(row["purge_cassette1_notes"]) ? Convert.ToInt32(row["purge_cassette1_notes"]) : null,
                        DenominationType2 = !DBNull.Value.Equals(row["denomination_type_2"]) ? Convert.ToInt32(row["denomination_type_2"]) : null,
                        Cassette2Denomination = !DBNull.Value.Equals(row["cassette2_notes"]) ? Convert.ToInt32(row["cassette2_notes"]) : 0,
                        PurgeCassette2Notes = !DBNull.Value.Equals(row["purge_cassette2_notes"]) ? Convert.ToInt32(row["purge_cassette2_notes"]) : null,
                        DenominationType3 = !DBNull.Value.Equals(row["denomination_type_3"]) ? Convert.ToInt32(row["denomination_type_3"]) : null,
                        Cassette3Denomination = !DBNull.Value.Equals(row["cassette3_notes"]) ? Convert.ToInt32(row["cassette3_notes"]) : 0,
                        PurgeCassette3Notes = !DBNull.Value.Equals(row["purge_cassette3_notes"]) ? Convert.ToInt32(row["purge_cassette3_notes"]) : null,
                        DenominationType4 = !DBNull.Value.Equals(row["denomination_type_4"]) ? Convert.ToInt32(row["denomination_type_4"]) : null,
                        Cassette4Denomination = !DBNull.Value.Equals(row["cassette4_notes"]) ? Convert.ToInt32(row["cassette4_notes"]) : 0,
                        PurgeCassette4Notes = !DBNull.Value.Equals(row["purge_cassette4_notes"]) ? Convert.ToInt32(row["purge_cassette4_notes"]) : null,
                        DenominationType5 = !DBNull.Value.Equals(row["denomination_type_5"]) ? Convert.ToInt32(row["denomination_type_5"]) : null,
                        Cassette5Denomination = !DBNull.Value.Equals(row["cassette5_notes"]) ? Convert.ToInt32(row["cassette5_notes"]) : 0,
                        PurgeCassette5Notes = !DBNull.Value.Equals(row["purge_cassette5_notes"]) ? Convert.ToInt32(row["purge_cassette5_notes"]) : null,
                        DenominationType6 = !DBNull.Value.Equals(row["denomination_type_6"]) ? Convert.ToInt32(row["denomination_type_6"]) : null,
                        Cassette6Denomination = !DBNull.Value.Equals(row["cassette6_notes"]) ? Convert.ToInt32(row["cassette6_notes"]) : 0,
                        PurgeCassette6Notes = !DBNull.Value.Equals(row["purge_cassette6_notes"]) ? Convert.ToInt32(row["purge_cassette6_notes"]) : null,
                        DenominationType7 = !DBNull.Value.Equals(row["denomination_type_7"]) ? Convert.ToInt32(row["denomination_type_7"]) : null,
                        Cassette7Denomination = !DBNull.Value.Equals(row["cassette7_notes"]) ? Convert.ToInt32(row["cassette7_notes"]) : 0,
                        PurgeCassette7Notes = !DBNull.Value.Equals(row["purge_cassette7_notes"]) ? Convert.ToInt32(row["purge_cassette7_notes"]) : null,
                        TotalRemaining = !DBNull.Value.Equals(row["total_text"]) ? Convert.ToDecimal(row["total_text"]) : null,
                        TotalPurgedCashBalance = !DBNull.Value.Equals(row["totalPurged"]) ? Convert.ToDecimal(row["totalPurged"]) : null,
                        NextReplenishmentAt = !DBNull.Value.Equals(row["next_replenishment_at"]) ? Convert.ToDateTime(row["next_replenishment_at"]) : null,
                        Amount = !DBNull.Value.Equals(row["amount"]) ? Convert.ToDecimal(row["amount"]) : null
                    };
                    cashPositions.Add(cashPosition);
                }
            }
            return cashPositions;
        }
    }
}
