using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;
using Services;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleReportsController : ControllerBase
    {
        private ScheculeReportGenerationsService scheculeReportsService;
        public ScheduleReportsController(ScheculeReportGenerationsService scheculeReportsService)
        {
            this.scheculeReportsService = scheculeReportsService;
        }

        [HttpPost("GetScheduleReports")]
        public async Task<IActionResult> GetScheduleReports(ScheduleReportsRequestModel scheduleReportsRequestModel)
        {
            try
            {
                var response = scheculeReportsService.GetScheduleReports(scheduleReportsRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        
        [HttpPost("GetReportGenerationSchedule")]
        public async Task<IActionResult> GetReportGenerationSchedule(ReportGenerationRequestModel generationRequestModel)
        {
            try
            {
                var response = scheculeReportsService.GetReportGeneration(generationRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("UpdateScheduleReport")]
        public async Task<IActionResult> UpdateScheduleReport(UpdateScheduleReportRequestModel updateScheduleReportRequest)
        {
            try
            {
                //var response = scheculeReportsService.UpdateScheduleAndGenerationReport(updateScheduleReportRequest);
                //return Ok(response);
                return Ok();
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
                //var response = scheculeReportsService.DeleteScheduleReport(deleteScheduleReportRequest);
                //return Ok(response);
               return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
