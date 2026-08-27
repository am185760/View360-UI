using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlertMonitoringReportController : ControllerBase
    {
        private AlertMonitoringReportService alertMonitoringReportService;
        public AlertMonitoringReportController(AlertMonitoringReportService alertMonitoringReportService)
        {
            this.alertMonitoringReportService = alertMonitoringReportService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetAlertMonitoringReport(AlertMonitoringReportRequestModel filter)
        {
            try
            {
                var response = alertMonitoringReportService.GetAlertMonitoringReport(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
