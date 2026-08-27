using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummaryApi.BusinessLayer;
using System.Dynamic;

namespace SummaryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtmStatusController : Controller
    {
        private readonly CoreContext _context;
        private AtmStatusService _atmStatusService { get; set; }
        private AtmService _atmService { get; set; }

        public AtmStatusController(CoreContext context, AtmStatusService atmStatusService , AtmService atmService)
        {
            _context = context;
            _atmStatusService = atmStatusService;
            _atmService = atmService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAtmAlerts(List<long> atmIds)
        {
            try
            {
                return Ok(await _context.AtmAlerts.Where(x => atmIds.Contains(x.AtmId)).ToListAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("GetTransactingATMs")]
        public async Task<IActionResult> GetTransactingATMs(List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                string errorMsg2 = string.Empty;
                string errorMsg3 = string.Empty;

                List<string> atmTitles = _atmStatusService.GetTransactingATMTitle(atmIds, ref errorMsg);
                int trnxCountToday = _atmStatusService.GetTrxnAtmCountToday(atmIds, ref errorMsg2);
                int trnxCountYesterday = _atmStatusService.GetTrxnAtmCountYesterday(atmIds, ref errorMsg3);

                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.AtmTitles = atmTitles;
                dynamicObj.TrnxCountToday = trnxCountToday;
                dynamicObj.TrnxCountYesterday = trnxCountYesterday;
                dynamicObj.ErrorMsg = errorMsg +  "   " + errorMsg2 + "   " + errorMsg3;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("GetTop10TransactionAtms")]
        public async Task<IActionResult> GetTop10TransactionAtms(List<string> atmIds)
        {
            try
            {
                var response = _atmService.GetTop10TransactionAtms(atmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        [HttpPost("GetTop10LowTransactionAtms")]
        public async Task<IActionResult> GetTop10LowTransactionAtms(List<string> atmIds)
        {
            try
            {
                var response = _atmService.GetTop10LowTransactionAtms(atmIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
