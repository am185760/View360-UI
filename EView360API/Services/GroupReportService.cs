using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GroupReportService
    {
        //private Executor _executor { get; set; }

        //public GroupReportService(Executor executor)
        //{
        //    _executor = executor;
        //}

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
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetGroupsDetail", sqlParameters, filter.SelectedAtmIds);

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = JsonConvert.SerializeObject(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(result.Table) };
        }
    }
}
