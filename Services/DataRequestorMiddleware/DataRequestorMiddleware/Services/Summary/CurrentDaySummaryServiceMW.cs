using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Summary
{
    public class CurrentDaySummaryServiceMW
    {
        private Executor _executor { get; set; }
        ILogger<CurrentDaySummaryServiceMW> logger;
        public CurrentDaySummaryServiceMW(Executor executor, ILogger<CurrentDaySummaryServiceMW> logger)
        {
            _executor = executor;
            this.logger = logger;
        }

        public BaseModel GetCurrentDaySummary(List<string> selectedAtmIds, List<string> selectedRegionIds, long userId)
        {
            //a.atm_id in (' +@atmIDs +') and 
            string queryFilter = "";

            if (selectedRegionIds != null || selectedRegionIds?.Count > 0)
                queryFilter += " and atm.region_id in (" + string.Join(",", selectedRegionIds) + ") and user_ATMs.user_id = " + userId + " and atm.is_active=1 ";
            else
                queryFilter += " and atm.atm_id in (" + string.Join(",", selectedAtmIds) + ")";
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@Filter",
                SqlDbType = SqlDbType.VarChar,
                Value = queryFilter
            };

            var response = new BaseModel();

            List<CurrentDaySummaryViewModel> CurrentDaySummary = new();

            logger.LogWarning("[CurrentDaySummaryServiceMW:GetCurrentDaySummary] executing GetSummaryOfTodaysAlert sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetSummaryOfTodaysAlert", new SqlParameter[] { param1 }, selectedAtmIds, string.Join(",", selectedAtmIds));
            logger.LogWarning("[CurrentDaySummaryServiceMW:GetCurrentDaySummary] returning from GetSummaryOfTodaysAlert sp");
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = CurrentDaySummary = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = CurrentDaySummary };
        }

        public BaseModel GetDetailedCurrentDaySummary(string alertType, List<string> selectedAtmIds, List<string> selectedRegionIds, long userId)
        {
            //and b.alert_type_name =  ''' +@alertType +''' and a.atm_id in (' +@atmIDs +') 
            string queryFilter = "";

            if (selectedRegionIds != null || selectedRegionIds?.Count > 0)
                queryFilter += " and atm.region_id in (" + string.Join(",", selectedRegionIds) + ") and user_ATMs.user_id = " + userId + " and atm.is_active=1 ";
            else
                queryFilter += " and atm.atm_id in (" + string.Join(",", selectedAtmIds) + ")";

            if (!string.IsNullOrEmpty(alertType))
                queryFilter += "and b.alert_type_name =  '" +@alertType +"' ";

            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@Filter",
                SqlDbType = SqlDbType.VarChar,
                Value = queryFilter
            };

            var response = new BaseModel();

            List<DetailedCurrentDaySummaryViewModel> DetailedCurrentDaySummary = new();

            logger.LogWarning("[CurrentDaySummaryServiceMW:GetDetailedCurrentDaySummary] executing GetDetailedSummaryOfTodaysAlert sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetDetailedSummaryOfTodaysAlert", new SqlParameter[] { param1 }, selectedAtmIds, string.Join(",", selectedAtmIds));
            logger.LogWarning("[CurrentDaySummaryServiceMW:GetDetailedCurrentDaySummary] returning from GetDetailedSummaryOfTodaysAlert sp");

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = DetailedCurrentDaySummary = ConvertDetailedDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = DetailedCurrentDaySummary };
        }

        public List<CurrentDaySummaryViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<CurrentDaySummaryViewModel> CurrentDaySummarys = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentDaySummaryViewModel CurrentDaySummary = new()
                    {
                        Task = !DBNull.Value.Equals(row["alert_type_name"]) ? row["alert_type_name"].ToString() : string.Empty,
                        Resolved = !DBNull.Value.Equals(row["resolved"]) ? Convert.ToInt32(row["resolved"]) : 0,
                        Unresolved = !DBNull.Value.Equals(row["unresolved"]) ? Convert.ToInt32(row["unresolved"]) : 0,
                        Total = !DBNull.Value.Equals(row["total"]) ? Convert.ToInt32(row["total"]) : 0,
                    };
                    CurrentDaySummarys.Add(CurrentDaySummary);
                }
            }
            return CurrentDaySummarys;
        }

        public List<DetailedCurrentDaySummaryViewModel> ConvertDetailedDataTableToList(DataTable dataTable)
        {
            List<DetailedCurrentDaySummaryViewModel> DetailedCurrentDaySummarys = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DetailedCurrentDaySummaryViewModel DetailedCurrentDaySummary = new()
                    {
                        AtmTitle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        AlertType = !DBNull.Value.Equals(row["alert_type_name"]) ? row["alert_type_name"].ToString() : string.Empty,
                        GeneratedAt = !DBNull.Value.Equals(row["generated_at"]) ? Convert.ToDateTime(row["generated_at"]) : null,
                        ResolvedAt = !DBNull.Value.Equals(row["resolve_at"]) ? Convert.ToDateTime(row["resolve_at"]) : null,
                    };
                    DetailedCurrentDaySummarys.Add(DetailedCurrentDaySummary);
                }
            }
            return DetailedCurrentDaySummarys;
        }
    }
}
