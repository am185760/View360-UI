using DataRequestor;
using System.Data.SqlClient;
using System.Data;
using EView360Models.ViewModels;
using EView360Models.RequestModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataRequestorMiddleware.Services.Operations
{
    public class CashPositionsService
    {
        public void GetDashboardCashPosition(CashPositionFilter cashPositionFilter, Executor _executor)
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
                    new SqlParameter() {ParameterName = "@ATM_WHERE_CLAUSE",SqlDbType = SqlDbType.VarChar,Value = string.Join(",", cashPositionFilter.Filter)},
                    new SqlParameter() {ParameterName = "@ArchiveYear",SqlDbType = SqlDbType.VarChar,Value = cashPositionFilter.archiveYear != null ? '_' + cashPositionFilter.archiveYear : ""},
                };

                _executor.ExecuteDSRequest<DataTableResult>(cashPositionFilter.SpName, paramArray, cashPositionFilter.AtmIds, string.Join(",", cashPositionFilter.AtmIds));               
            }
        }
        public void GetCashPositions(Executor _executor, CashPositionFilter cashPositionFilter)
        {
            if (cashPositionFilter?.AtmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = cashPositionFilter.Filter
                };

                SqlParameter orderByParam = new SqlParameter()
                {
                    ParameterName = "@OrderBy",
                    SqlDbType = SqlDbType.VarChar,
                    Value = cashPositionFilter.OrderBy
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
                    Value = cashPositionFilter.archiveYear != null ? '_' + cashPositionFilter.archiveYear.ToString() : ""
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
                _executor.ExecuteDSRequest<DataTableResult>(cashPositionFilter.SpName, new SqlParameter[] { param1, orderByParam, param2, param3, param4, param5, param6, param7 }, cashPositionFilter.AtmIds, string.Join(",", cashPositionFilter.AtmIds));
                
            }
        }
    }
}
