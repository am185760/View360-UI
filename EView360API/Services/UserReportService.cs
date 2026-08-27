using Azure;
using Common.RequestModel;
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
    public class UserReportService
    {
        //private Executor _executor { get; set; }

        //public UserReportService(Executor executor)
        //{
        //    _executor = executor;
        //}
        public BaseModel GetUsersReport(UserReportRequestModel userReportRequestModel)
        {
            string filter = "";
            var response = new BaseModel();
            if (userReportRequestModel.UserId != string.Empty)
                filter += " and user_id = " + userReportRequestModel.UserId;

            if (userReportRequestModel.FullName != string.Empty)
                filter += "and user_full_name like '%" + userReportRequestModel.FullName + "%'";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = filter}
            };
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetUsersDetail", sqlParameters, userReportRequestModel.SelectedAtmIds);


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
