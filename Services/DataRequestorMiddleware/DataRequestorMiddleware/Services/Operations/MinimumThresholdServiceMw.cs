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
using EView360Models.Core;
using EView360Models.RequestModel;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Operations
{
    public class MinimumThresholdServiceMw
    {
        ILogger<MinimumThresholdServiceMw> logger;

        public MinimumThresholdServiceMw(ILogger<MinimumThresholdServiceMw> logger)
        {
            this.logger = logger;
        }

        //private Executor _executor { get; set; }

        //public MinimumThresholdServiceMw()
        //{
        //    _executor = new Executor();
        //}
        public async Task GetMinimumThreshold(List<string> SelectedAtmIds,long UserId ,List<string> RegionIds, Executor executor)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();

            var response = new BaseModel();
            filter += " and user_ATMs.user_id =" + UserId;

            if (RegionIds?.Count > 0)
                filter += "and outerATM.region_id in (" + string.Join(",", RegionIds) + ")";
            else
                filter += "and  outerATM.atm_id in (" + string.Join(",", SelectedAtmIds) + ")";

            List<MinimumThresholdViewModel> minimumThreshold = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@Filter";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = filter;

            param2 = new SqlParameter();
            param2.ParameterName = "@OrderBy";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = "total asc";
            Executor _executor = new Executor();
            logger.LogWarning("[MinimumThresholdServiceMwGetMinimumThreshold] executing GetDashboardMinimumThreshold sp");
            executor.ExecuteDSRequest<DataTableResult>("GetDashboardMinimumThreshold", new SqlParameter[] { param1, param2 }, SelectedAtmIds,string.Join(",", SelectedAtmIds));
            logger.LogWarning("[MinimumThresholdServiceMwGetMinimumThreshold] return from GetDashboardMinimumThreshold sp");

            //if (result?.Table?.Rows?.Count > 0)
            //{
            //    response.Data = minimumThreshold = ConvertDataTableToList(result.Table);
            //}
            //if (!string.IsNullOrEmpty(result.ExceptionMessage))
            //{
            //    response.Message = result.ExceptionMessage;
            //    return response;
            //}


            //return new BaseModel { IsSuccess = true, Data = minimumThreshold };
        }

        public List<MinimumThresholdViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<MinimumThresholdViewModel> minimumThresholds = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    MinimumThresholdViewModel minimumThreshold = new()
                    {
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        MinimumThresholdBalance = !DBNull.Value.Equals(row["min_operating_balance"]) ? Convert.ToDouble(row["min_operating_balance"].ToString()) : 0,
                        RemainingAmount = !DBNull.Value.Equals(row["total"]) ? Convert.ToInt32(row["total"].ToString()) : 0,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IpAddress = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        NoteSetTypeName = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
                    };

                    minimumThresholds.Add(minimumThreshold);
                }
            }
            return minimumThresholds;

        }

    }
}
