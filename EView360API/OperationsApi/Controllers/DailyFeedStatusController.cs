using EView360Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DailyFeedStatusController : Controller
    {
        private DailyFeedStatusService dailyFeedStatusService { get; set; }

        public DailyFeedStatusController(DailyFeedStatusService dailyFeedStatusService)
        {
            this.dailyFeedStatusService= dailyFeedStatusService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> GetDailyFeed(DailyFeedStatusFilter filter)
        {
            try
            {
                var response = dailyFeedStatusService.GetDailyFeed(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
