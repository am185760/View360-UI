using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReplenishmentReportController : ControllerBase
    {
        private ReplenishmentReportService replenishmentReportService;
        public ReplenishmentReportController(ReplenishmentReportService replenishmentReportService)
        {
            this.replenishmentReportService = replenishmentReportService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetReplenishmentReport(ReplenishmentReportRequestModel filter)
        {
            try
            {
                var response = replenishmentReportService.GetReplenishmentReport(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
