using Common.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReplenishmentReturnController : Controller
    {
        private readonly ReplenishmentReturnReportService replenishmentReturnReportService;
        public ReplenishmentReturnController(ReplenishmentReturnReportService replenishmentReturnReportService)
        {
            this.replenishmentReturnReportService = replenishmentReturnReportService;
        }

        [HttpPost("GetReplenishmentReturn")]
        public IActionResult GetReplenishmentReturn(ReplenishmentReturnReportRequestModel replenishmentReport)
        {
            try
            {
                var response = replenishmentReturnReportService.GetReplenishmentReturn(replenishmentReport);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
