using Microsoft.AspNetCore.Mvc;
using SummaryApi.BusinessLayer;
using System.Dynamic;

namespace SummaryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RemDenQtyController : Controller
    {
        private RemDenQtyService _service { get; set; }

        public RemDenQtyController(RemDenQtyService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetRemainingNotes(List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<string> cassette_Sum = _service.GetRemainingNotes(atmIds, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.Cassette_Sum = cassette_Sum;
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
