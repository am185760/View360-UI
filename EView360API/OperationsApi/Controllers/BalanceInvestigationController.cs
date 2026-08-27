using Common.RequestModel;
using EView360Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class BalanceInvestigationController : Controller
    {
        private BalanceInvestigationService balanceInvestigationService;

        public BalanceInvestigationController(BalanceInvestigationService balanceInvestigationService)
        {
            this.balanceInvestigationService = balanceInvestigationService;
        }

        [HttpPost("GetBalanceInvestigation")]
        public async Task<IActionResult> BalanceInvestigation(BalanceInvestigationRequestModel balanceInvestigationRequestModel)
        {
            try
            {
                var response = balanceInvestigationService.GetBalanceInvestigation(balanceInvestigationRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
