using EView360Models.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummaryApi.BusinessLayer;
using System.Dynamic;

namespace SummaryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BnaStatusController : Controller
    {
        private BnaStatusService _service { get; set; }

        public BnaStatusController(BnaStatusService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> GetBNATransactingATMTitle(int userId, List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<string> atmTitles = _service.GetBNATransactingATMTitle(userId, atmIds, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.AtmTitles = atmTitles;
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
