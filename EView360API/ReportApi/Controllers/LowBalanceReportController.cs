using Common.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LowBalanceReportController : Controller
    {
        private LowBalanceReportService lowBalanceReportService;
        public LowBalanceReportController(LowBalanceReportService lowBalanceReportService)
        {
            this.lowBalanceReportService = lowBalanceReportService;
        }

        [HttpPost("GetLowBalance")]
        public IActionResult GetLowBalance(LowBalanceReportRequestModel lowBalanceReportRequest)
        {
            try
            {
                var response = lowBalanceReportService.GetLowBalance(lowBalanceReportRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
