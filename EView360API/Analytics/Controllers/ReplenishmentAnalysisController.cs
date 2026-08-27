using Analytics.BusinessLayer;
using Common.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Analytics.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReplenishmentAnalysisController : ControllerBase
    {
        private ReplenishmentAnalysisService _service { get; set; }
        public ReplenishmentAnalysisController(ReplenishmentAnalysisService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetReplenishmentAnalysis(DateTime fromDate, DateTime toDate, List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<ReplenishmentAnalysisViewModel> replenishments = _service.GetReplenishmentAnalysis(fromDate, toDate, atmIds, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.Replenishments = replenishments;
                dynamicObj.ErrorMsg = errorMsg;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetReplenishmentDatagrid(DateTime fromDate, DateTime toDate, List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<ReplenishmentAnalysisViewModel> replenishments = _service.GetReplenishmentDatagrid(fromDate, toDate, atmIds, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.Replenishments = replenishments;
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
