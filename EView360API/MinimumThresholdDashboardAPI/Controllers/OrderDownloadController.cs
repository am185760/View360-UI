using Dashboard.BusinessLayer;
using EView360Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDownloadController : ControllerBase
    {
        private OrderDownloadService orderDownloadService { get; set; }

        public OrderDownloadController(OrderDownloadService orderDownloadService)
        {
            this.orderDownloadService = orderDownloadService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> GetDailyFeed(List<string> SelectedAtmIds)
        {
            try
            {
                var response = orderDownloadService.GetDailyFeed(SelectedAtmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
