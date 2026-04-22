using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestorMiddleware.Services.Reports
{
    public class CashDepositDenominationDetailServiceMw
    {
        private ILogger<TaskStatusReportServiceMw> _logger;

        public CashDepositDenominationDetailServiceMw(ILogger<TaskStatusReportServiceMw> logger)
        {
            _logger = logger;
        }


        public async Task<BaseModel> GetCashDepositDenominationDetailReport(CashDepositDenominationRequestModel requestModel)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();
            SqlParameter param5 = new SqlParameter();

            var response = new BaseModel();

            if (requestModel.FromDate != DateTime.MinValue)
                filter += " and trxn_datetime >= convert(datetime,'" + requestModel.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (requestModel.ToDate != DateTime.MinValue)
                filter += "  and trxn_datetime <= convert(datetime,'" + requestModel.ToDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (requestModel.status !=  null && requestModel.status != string.Empty)
                filter += " and vEjParsedBNATransaction.status = '" + requestModel.status + "'";

            if (requestModel.tsn != null && requestModel.tsn != string.Empty)
                filter += " and vEjParsedBNATransaction.seq = '" + requestModel.tsn + "'";

            //if (taskStatusReportRequest.Status != null && taskStatusReportRequest.Status != string.Empty)
            //    filter += " and status = '" + taskStatusReportRequest.Status + "'";

            //if (taskStatusReportRequest.AtmType != null && taskStatusReportRequest.AtmType != string.Empty)
            //    filter += " and atm_type = '" + taskStatusReportRequest.AtmType + "'";

            //if (taskStatusReportRequest.SelectedRegionIds != null || taskStatusReportRequest.SelectedRegionIds?.Count > 0)
            //    filter += "and atm.region_id in (" + string.Join(",", taskStatusReportRequest.SelectedRegionIds) + ") and atm.IS_ACTIVE = 1 ";
            //else
            //    filter += "and  atm.atm_id in (" + string.Join(",", taskStatusReportRequest.SelectedAtms) + ")";



            //param1 = new SqlParameter();
            //param1.ParameterName = "@AtmId";
            //param1.SqlDbType = SqlDbType.VarChar;
            //param1.Value = string.Join(",", taskStatusReportRequest.SelectedAtms);

            //param2 = new SqlParameter();
            //param2.ParameterName = "@OrderBy";
            //param2.SqlDbType = SqlDbType.VarChar;
            //param2.Value = "title asc"; 


            //param2 = new SqlParameter();
            //param2.ParameterName = "@FromDate";
            //param2.SqlDbType = SqlDbType.DateTime;
            //param2.Value = taskStatusReportRequest.FromDate;


            //param3 = new SqlParameter();
            //param3.ParameterName = "@ToDate";
            //param3.SqlDbType = SqlDbType.DateTime;
            //param3.Value = taskStatusReportRequest.ToDate;


            //param4.ParameterName = "@ArchiveYear";
            //param4.SqlDbType = SqlDbType.VarChar;
            //param4.Value = taskStatusReportRequest?.ArchiveYear != string.Empty ? $"_{taskStatusReportRequest.ArchiveYear}" : "";


            param5.ParameterName = "@Filter";
            param5.SqlDbType = SqlDbType.VarChar;
            param5.Value = filter;
            //SqlParameter param6 = new SqlParameter()
            //{
            //    ParameterName = "@offset",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1
            //};

            //SqlParameter param7 = new SqlParameter()
            //{
            //    ParameterName = "@RowCount",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 10000
            //};
            Executor _executor = new Executor();
            _logger.LogWarning("[CashDepositDenominationDetailServiceMw:GetCashDepositDenominationDetailReport] going to execute GetCashDepositDenominationDetail sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetCashDepositDenominationDetail", new SqlParameter[] { param5 }, requestModel.SelectedAtms,string.Join(",", requestModel.SelectedAtms));
            _logger.LogWarning("[CashDepositDenominationDetailServiceMw:GetCashDepositDenominationDetailReport] return from GetCashDepositDenominationDetail sp");

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = result.Table;
                //response.Data = JsonConvert.SerializeObject(result.Table);
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
