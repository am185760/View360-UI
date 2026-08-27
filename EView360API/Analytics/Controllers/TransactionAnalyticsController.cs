using Analytics.BusinessLayer;
using Common.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Analytics.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionAnalyticsController : ControllerBase
    {
        private TransactionAnalyticsService transactionAnalyticsService;

        public TransactionAnalyticsController(TransactionAnalyticsService transactionAnalyticsService)
        {
            this.transactionAnalyticsService = transactionAnalyticsService;
        }

        [HttpPost("GetAtmTransactionDetail")]
        public async Task<IActionResult> GetAtmTransactionDetail(DateTime fromDate, DateTime toDate, List<string> atmIds)
            {
            try
            {
                var response = transactionAnalyticsService.GetAtmTransactionDetail(fromDate, toDate, atmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
