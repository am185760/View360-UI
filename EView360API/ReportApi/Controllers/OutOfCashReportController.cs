using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OutOfCashReportController : ControllerBase
    {
        private OutOfCashReportService outOfCashReportService;
        public OutOfCashReportController(OutOfCashReportService outOfCashReportService)
        {
            this.outOfCashReportService = outOfCashReportService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetOutOfCashReport(OutOfCashReportRequestModel filter)
        {
            try
            {
                var response = outOfCashReportService.GetOutOfCashReport(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
