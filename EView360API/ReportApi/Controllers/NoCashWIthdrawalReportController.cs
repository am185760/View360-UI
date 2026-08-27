using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoCashWIthdrawalReportController : ControllerBase
    {
        private NoCashWIthdrawalReportService noCashWIthdrawalReportService;
        public NoCashWIthdrawalReportController(NoCashWIthdrawalReportService noCashWIthdrawalReportService)
        {
            this.noCashWIthdrawalReportService = noCashWIthdrawalReportService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetNoCashWIthdrawalReport(NoCashWithdrawalReportRequestModel filter)
        {
            try
            {
                var response = noCashWIthdrawalReportService.GetNoCashWIthdrawalReport(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
