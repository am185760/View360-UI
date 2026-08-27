using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskStatusReportController : ControllerBase
    {
        private TaskStatusReportService taskStatusReportService;
        public TaskStatusReportController(TaskStatusReportService taskStatusReportService)
        {
            this.taskStatusReportService = taskStatusReportService;
        }

        [HttpPost("GetTaskStatusReport")]
        public async Task<IActionResult> GetTaskStatusReport(TaskStatusReportRequestModel taskStatusReportRequestModel)
        {
            try
            {
                var response = taskStatusReportService.GetTaskStatusReport(taskStatusReportRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
