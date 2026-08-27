using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SummaryApi.BusinessLayer;

namespace SummaryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodaysActivityController : ControllerBase
    {
        ActivityService activityService;
        public TodaysActivityController(ActivityService activityService)
        {
            this.activityService = activityService;
        }
        [HttpPost("GetTodaysActivity")]
        public async Task<IActionResult> GetTodaysActivity(TodaysActivityRequestModel todaysActivityRequest)
        {
            try
            {
                var response = activityService.GetTodaysActivity(todaysActivityRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
