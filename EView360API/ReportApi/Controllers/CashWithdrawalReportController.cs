using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CashWithdrawalReportController : ControllerBase
    {
        private CashWithdrawalReportService cashWithdrawalReportService;
        public CashWithdrawalReportController(CashWithdrawalReportService cashWithdrawalReportService)
        {
            this.cashWithdrawalReportService = cashWithdrawalReportService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetCashWithdrawalReport(CashWithdrawalReportRequestModel filter)
        {
            try
            {
                var response = cashWithdrawalReportService.GetCashWithdrawalReport(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
