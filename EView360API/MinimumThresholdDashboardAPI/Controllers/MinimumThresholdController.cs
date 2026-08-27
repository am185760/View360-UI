using EView360Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MinimumThresholdController : ControllerBase
    {
        private readonly MinimumThresholdService minimumThresholdService;

        public MinimumThresholdController(MinimumThresholdService minimumThresholdService)
        {
            this.minimumThresholdService = minimumThresholdService;
        }

        [HttpPost("MinimumThresholdDashboard")]
        public IActionResult GetMinimumThresholdDashboard(List<string> SelectedAtmIds)
        {
            try
            {
                var response = minimumThresholdService.GetMinimumThreshold(SelectedAtmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
