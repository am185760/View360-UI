using EView360Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OperationsApi.Controllers.CurrencyAndCashManagement
{
    [Route("[controller]")]
    [ApiController]
    public class WithdrawalTransactionController : ControllerBase
    {
        private AtmTransactionService atmTransactionService { get; set; }

        public WithdrawalTransactionController(AtmTransactionService atmTransactionService)
        {
            this.atmTransactionService = atmTransactionService;
        }


        [HttpPut("ATMTransactions")]
        public async Task<IActionResult> ATMTransactions(WithdrawalTransactionRequestModel withdrawalTransactionFilter)
        {
            try
            {
                var response = atmTransactionService.GetATMTransactions(withdrawalTransactionFilter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;            
            }
        }
    }
}
