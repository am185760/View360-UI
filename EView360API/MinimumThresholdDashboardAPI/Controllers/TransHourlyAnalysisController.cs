using Dashboard.BusinessLayer;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransHourlyAnalysisController : Controller
    {
        private TransHourlyAnalysisService _service { get; set; }
        public TransHourlyAnalysisController(TransHourlyAnalysisService service)
        {
            _service = service;
        }

        [HttpPost("GetTransHourlyResponse")]
        public async Task<IActionResult> GetTransHourlyResponse(List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<TransHourlyResponseViewModel> transHourlyResponses = _service.GetTransHourlyResponse(atmIds, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.TransHourlyResponse = transHourlyResponses;
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
