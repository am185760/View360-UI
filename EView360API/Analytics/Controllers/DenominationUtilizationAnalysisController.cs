using Analytics.BusinessLayer;
using Common.RequestModel;
using Common.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Analytics.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DenominationUtilizationAnalysisController : ControllerBase
    {
        private DenominationUtilizationAnalysisService _service { get; set; }
        public DenominationUtilizationAnalysisController(DenominationUtilizationAnalysisService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetDenominationUtilizationAnalysis(DenominationUtilizationAnalysisRequestModel filter)
        {
            try
            {
                var response = _service.GetDenominationUtilizationAnalysis(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetNotesetTypesByAtmIds(List<long> atmIds)
        {
            try
            {
                var response = _service.GetNotesetTypesByAtmIds(atmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
