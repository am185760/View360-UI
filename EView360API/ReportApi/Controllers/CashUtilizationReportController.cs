using Common.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class CashUtilizationReportController : Controller
    {
        CashUtilizationService cashUtilizationService;

        public CashUtilizationReportController(CashUtilizationService cashUtilizationService)
        {
            this.cashUtilizationService = cashUtilizationService;
        }
        
        [HttpPost("GetCashUtilzation")]
        public IActionResult GetCashUtilzation(CashUtilizationReportRequestModel cashUtilizationReport)
        {
            try
            {
                var response = cashUtilizationService.GetCashUtilzation(cashUtilizationReport);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
