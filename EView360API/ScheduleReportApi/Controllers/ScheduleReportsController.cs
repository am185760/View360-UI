using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ScheduleReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleReportsController : ControllerBase
    {
        private ReportScheduleService reportScheduleService;

        public ScheduleReportsController(ReportScheduleService reportScheduleService)
        {
            this.reportScheduleService = reportScheduleService;
        }

        [HttpGet("GetScheduleReports")]
        public async Task<IActionResult> GetScheduleReports()
        {
            try
            {
                var response = await reportScheduleService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetScheduleReportGeneration/{scheduleReportId}")]
        public async Task<IActionResult> GetScheduleReportGeneration(long scheduleReportId)
        {
            try
            {
                var response = await reportScheduleService.GetAllScheduleReportGeneration(scheduleReportId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("UpdateScheduleReport")]
        public async Task<IActionResult> UpdateScheduleReport(UpdateScheduleReportRequestModel updateScheduleReportRequestModel)
        {
            try
            {
                var response = await reportScheduleService.UpdateScheduleReportGeneration(updateScheduleReportRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("DeleteScheduleReport")]
        public async Task<IActionResult> DeleteScheduleReport(DeleteScheduleReportRequestModel deleteScheduleReportRequest)
        {
            try
            {
                var response = reportScheduleService.DeleteScheduleReport(deleteScheduleReportRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
