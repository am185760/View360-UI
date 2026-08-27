using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace SummaryApi.BusinessLayer
{
    public class CurrentDaySummaryService
    {
        private Executor _executor { get; set; }

        public CurrentDaySummaryService(Executor executor)
        {
            _executor = executor;
        }

        public BaseModel GetCurrentDaySummary(List<string> atmIds)
        {
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@atmIDs",
                SqlDbType = SqlDbType.VarChar,
                Value = string.Join(",", atmIds)
            };

            var response = new BaseModel();

            List<CurrentDaySummaryViewModel> CurrentDaySummary = new();

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetSummaryOfTodaysAlert", new SqlParameter[] { param1 }, atmIds);
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
        
        public BaseModel GetDetailedCurrentDaySummary(string alertType, List<string> atmIds)
        {
            
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@alertType",
                SqlDbType = SqlDbType.VarChar,
                Value = alertType
            };

            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "@atmIDs",
                SqlDbType = SqlDbType.VarChar,
                Value = string.Join(",", atmIds)
            };

            var response = new BaseModel();

            List<DetailedCurrentDaySummaryViewModel> DetailedCurrentDaySummary = new();

            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetDetailedSummaryOfTodaysAlert", new SqlParameter[] { param1, param2 }, atmIds);
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
