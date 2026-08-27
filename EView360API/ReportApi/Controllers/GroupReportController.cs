using Common.RequestModel;
using Common.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupReportController : ControllerBase
    {
        private GroupReportService groupReportService;
        public GroupReportController(GroupReportService groupReportService)
        {
            this.groupReportService = groupReportService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetGroupListReport(GroupReportViewModel filter)
        {
            try
            {
                var response = groupReportService.GetGroupListReport(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
