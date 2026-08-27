using EView360Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;

namespace OperationsApi.Controllers.CurrencyAndCashManagement
{
    [Route("[controller]")]
    [ApiController]
    public class BNATransactionsController : ControllerBase
    {
        private BnaTransactionService bnaTransactionService;

        public BNATransactionsController(BnaTransactionService bnaTransactionService)
        {
            this.bnaTransactionService = bnaTransactionService;
        }

        [HttpPost("BNATransactions")]
        public async Task<IActionResult> BNATransactions(BNATransactionRequestModel bNATransactionRequestModel)
        {
            try
                {
                var response = bnaTransactionService.GetBnaTransaction(bNATransactionRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("BNATransactionDashboard")]
        public async Task<IActionResult> BNADeposit(BNADepositRequestModel bNADepositRequestModel)
        {
            try
            {
                var response = bnaTransactionService.GetAtmBnaDeposit(bNADepositRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
