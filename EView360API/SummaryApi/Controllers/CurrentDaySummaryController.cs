using Microsoft.AspNetCore.Mvc;
using SummaryApi.BusinessLayer;

namespace SummaryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrentDaySummaryController : ControllerBase
    {
        private CurrentDaySummaryService _service { get; set; }

        public CurrentDaySummaryController(CurrentDaySummaryService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetCurrentDaySummary(List<string> atmIds)
        {
            try
            {
                var response = _service.GetCurrentDaySummary(atmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetDetailedCurrentDaySummary(string alertType, List<string> atmIds)
        {
            try
            {
                var response = _service.GetDetailedCurrentDaySummary(alertType,atmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
