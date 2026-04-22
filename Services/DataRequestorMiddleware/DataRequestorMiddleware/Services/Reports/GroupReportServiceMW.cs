using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class GroupReportServiceMW
    {
        ILogger<GroupReportServiceMW> logger;
        public GroupReportServiceMW(ILogger<GroupReportServiceMW> logger)
        {
            this.logger = logger;
        }
        public BaseModel GetGroupListReport(GroupReportViewModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.GroupName != string.Empty)
                queryFilter += "and group_name like '%" + filter.GroupName + "%'";

            SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                        new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter}
                    };
            Executor _executor = new Executor();
            logger.LogWarning("[GroupReportServiceMW:GetGroupListReport] executing GetGroupsDetail sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetGroupsDetail", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[GroupReportServiceMW:GetGroupListReport] returning from GetGroupsDetail sp");

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = result.Table;
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = result.Table };
        }
    }
}
