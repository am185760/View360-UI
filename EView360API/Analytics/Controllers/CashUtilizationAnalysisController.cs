using Analytics.BusinessLayer;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Analytics.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CashUtilizationAnalysisController : ControllerBase
    {
        private CashUtilizationAnalysisService _service { get; set; }
        public CashUtilizationAnalysisController(CashUtilizationAnalysisService service)
        {
            _service = service;
        }

        [HttpPost("GetAtmUtilizationDetail")]
        public async Task<IActionResult> GetAtmUtilizationDetail(DateTime fromDate, DateTime toDate, List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<CashUtilizationViewModel> cashUtilizations = _service.GetAtmUtilizationDetail(fromDate, toDate, atmIds, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.CashUtilizations = cashUtilizations;
                dynamicObj.ErrorMsg = errorMsg;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
