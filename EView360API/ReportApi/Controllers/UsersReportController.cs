using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersReportController : ControllerBase
    {
        private readonly UserReportService userReportService;
        public UsersReportController(UserReportService userReportService)
        {
            this.userReportService = userReportService;
        }

        [HttpPost("GetUsers")]
        public IActionResult GetUsers(UserReportRequestModel reportRequestModel)
        {
            try
            {
                var response = userReportService.GetUsersReport(reportRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
