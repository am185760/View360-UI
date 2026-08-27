using EView360Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlertMonitoringController : Controller
    {
        private AlertMonitoringService alertMonitoringService { get; set; }
        public AlertMonitoringController(AlertMonitoringService alertMonitoringService)
        {
            this.alertMonitoringService = alertMonitoringService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> GetAlerts(AlertMonitoringFilter filter)
        {
            try
            {
                var response = alertMonitoringService.GetAlerts(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
