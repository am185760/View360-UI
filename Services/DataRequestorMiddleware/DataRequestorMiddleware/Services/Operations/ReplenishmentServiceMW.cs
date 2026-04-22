using DataRequestor;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DataRequestorMiddleware.Services.Operations
{
    public class ReplenishmentServiceMW
    {
        //private Executor _executor { get; set; }
        ILogger<ReplenishmentServiceMW> logger;

        public ReplenishmentServiceMW(Executor executor, ILogger<ReplenishmentServiceMW> logger)
        {
            //_executor = executor;
            this.logger = logger;
        }

        public void GetReplenishments(Executor _executor, ReplenishmentFilter replenishmentFilter)
        {
            string filter = "";
            var response = new BaseModel();

            if (replenishmentFilter.SelectedRegionIds != null || replenishmentFilter.SelectedRegionIds?.Count > 0)
                filter += " atm.region_id in (" + string.Join(",", replenishmentFilter.SelectedRegionIds) + ") and user_ATMs.user_id = " + replenishmentFilter.UserId + " and atm.is_active=1 ";
            else
                filter += " atm.atm_id in (" + string.Join(",", replenishmentFilter.SelectedAtmIds) + ")";

            if (replenishmentFilter.fromDate.HasValue)
                filter += " and rep_datetime >= convert(datetime,'" + replenishmentFilter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (replenishmentFilter.toDate.HasValue)
                filter += " and rep_datetime<= convert(datetime,'" + replenishmentFilter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            List<ReplenishmentViewModel> replenishments = new();

            //SqlParameter param1 = new SqlParameter();
            //param1.ParameterName = "@AtmId";
            //param1.SqlDbType = SqlDbType.VarChar;
            //param1.Value = string.Join(",", replenishmentFilter.SelectedAtmIds);

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = filter;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = string.IsNullOrEmpty(replenishmentFilter.Orderby) ? "rep_datetime desc" : replenishmentFilter.Orderby;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@ArchiveYear";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = replenishmentFilter?.ArchiveYear != 0 ? "_" + replenishmentFilter.ArchiveYear.ToString() : "";

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@Offset";
            param4.SqlDbType = SqlDbType.Int;
            param4.Value = replenishmentFilter.Offset;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@RowCount";
            param5.SqlDbType = SqlDbType.Int;
            param5.Value = replenishmentFilter.RowCount;

            logger.LogWarning("[ReplenishmentService:GetReplenishments] executing GetReplenishments sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReplenishments", new SqlParameter[] { param1, param2, param3, param4, param5 }, replenishmentFilter.SelectedAtmIds, string.Join(",", replenishmentFilter.SelectedAtmIds));
            logger.LogWarning("[ReplenishmentService:GetReplenishments] returning from GetReplenishments sp");

            //if (result?.Table?.Rows?.Count > 0)
            //{
            //    response.Data = replenishments = ConvertDataTableToList(result.Table);
            //}
            //if (!string.IsNullOrEmpty(result.ExceptionMessage))
            //{
            //    response.Message = result.ExceptionMessage;
            //    return response;
            //}

            //return new BaseModel { IsSuccess = true, Data = replenishments };
        }

        //public List<ReplenishmentViewModel> ConvertDataTableToList(DataTable dataTable)
        //{
        //    List<ReplenishmentViewModel> atmWithdrawalTransactions = new();

        //    if (dataTable != null)
        //    {
        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            ReplenishmentViewModel atmWithdrawalTransaction = new()
        //            {
        //                AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
        //                RepAmount = !DBNull.Value.Equals(row["amt_text"]) ? Convert.ToInt32(row["amt_text"]) : 0,
        //                GeneratedByName = !DBNull.Value.Equals(row["user_full_name"]) ? row["user_full_name"].ToString() : string.Empty,
        //                GenerationTime = !DBNull.Value.Equals(row["generated_at"]) ? Convert.ToDateTime(row["generated_at"]) : null,
        //                IsSwap = !DBNull.Value.Equals(row["is_swap"]) ? Convert.ToBoolean(row["is_swap"]) : false,
        //                LastTSN = !DBNull.Value.Equals(row["last_tsn"]) ? Convert.ToInt32(row["last_tsn"]) : 0,
        //                ReplenishedAt = !DBNull.Value.Equals(row["rep_datetime"]) ? Convert.ToDateTime(row["rep_datetime"]) : null,
        //                Status = !DBNull.Value.Equals(row["rep_status"]) ? row["rep_status"].ToString() : string.Empty,
        //                Title = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
        //                CashAdded1 = !DBNull.Value.Equals(row["cash_added1"]) ? Convert.ToInt32(row["cash_added1"]) : 0,
        //                CashAdded2 = !DBNull.Value.Equals(row["cash_added2"]) ? Convert.ToInt32(row["cash_added2"]) : 0,
        //                CashAdded3 = !DBNull.Value.Equals(row["cash_added3"]) ? Convert.ToInt32(row["cash_added3"]) : 0,
        //                CashAdded4 = !DBNull.Value.Equals(row["cash_added4"]) ? Convert.ToInt32(row["cash_added4"]) : 0,
        //                IsBillDispenser = !DBNull.Value.Equals(row["IsBillDispenser"]) ? Convert.ToBoolean(row["IsBillDispenser"]) : false,
        //            };
        //            atmWithdrawalTransactions.Add(atmWithdrawalTransaction);
        //        }
        //    }
        //    return atmWithdrawalTransactions;
        //}

        public BaseModel PostReplenishment(ReplenishmentViewModel postRep)
        {
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = postRep.AtmId;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@CashAdded1";
            param2.SqlDbType = SqlDbType.Int;
            param2.Value = postRep.CashAdded1;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@CashAdded2";
            param3.SqlDbType = SqlDbType.Int;
            param3.Value = postRep.CashAdded2;

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@CashAdded3";
            param4.SqlDbType = SqlDbType.Int;
            param4.Value = postRep.CashAdded3;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@CashAdded4";
            param5.SqlDbType = SqlDbType.Int;
            param5.Value = postRep.CashAdded4;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@RepDatetime";
            param6.SqlDbType = SqlDbType.DateTime;
            param6.Value = postRep.RepDatetime;

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@RepStatus";
            param7.SqlDbType = SqlDbType.NVarChar;
            param7.Value = postRep.RepStatus;

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@TaskId";
            param8.SqlDbType = SqlDbType.BigInt;
            param8.Value = postRep.TaskId;

            SqlParameter param9 = new SqlParameter();
            param9.ParameterName = "@IsSwap";
            param9.SqlDbType = SqlDbType.Bit;
            param9.Value = postRep.IsSwap;

            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "@Reason";
            param10.SqlDbType = SqlDbType.VarChar;
            param10.Value = postRep.Reason;

            SqlParameter param11 = new SqlParameter();
            param11.ParameterName = "@GeneratedAt";
            param11.SqlDbType = SqlDbType.DateTime;
            param11.Value = postRep.GeneratedAt;

            SqlParameter param12 = new SqlParameter();
            param12.ParameterName = "@GeneratedBy";
            param12.SqlDbType = SqlDbType.VarChar;
            param12.Value = postRep.GeneratedBy;

            SqlParameter param13 = new SqlParameter();
            param13.ParameterName = "@RepAmount";
            param13.SqlDbType = SqlDbType.Int;
            param13.Value = postRep.RepAmount;

            SqlParameter param14 = new SqlParameter();
            param14.ParameterName = "@IsBillDispenser";
            param14.SqlDbType = SqlDbType.Bit;
            param14.Value = postRep.IsBillDispenser;


            List<string> Atmlist = new List<string>();
            Atmlist.Add(postRep.AtmId.ToString());
            
            Executor executor = new Executor();
            DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("PostReplenishment", new SqlParameter[] { param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14 }, Atmlist, string.Join(",", Atmlist));

            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return new BaseModel { IsSuccess = false, Message = result.ExceptionMessage };
            else
                return new BaseModel { IsSuccess = true };
        }
    }
}
