using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReplenishmentController : ControllerBase
    {
        private ReplenishmentService replenishmentService { get; set; }
        public ReplenishmentController(ReplenishmentService replenishmentService)
        {
            this.replenishmentService = replenishmentService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> GetReplenishments(ReplenishmentFilter replenishmentFilter)
        {
            try
            {
                var response = replenishmentService.GetReplenishments(replenishmentFilter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> PostReplenishment(ReplenishmentViewModel postRep)
        {
            try
            {
                var response = replenishmentService.PostReplenishment(postRep);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
