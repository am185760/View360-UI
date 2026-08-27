using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OperationsApi.BusinessLayer;
using System.Collections.Generic;
using System.Dynamic;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CashPositionController : Controller
    {
        private CashPositionService _service { get; set; }
        public CashPositionController(CashPositionService service)
        {
            _service = service;
        }


        [HttpPost("GetCashPositions")]
        public async Task<IActionResult> GetCashPositions(CashPositionFilter cashPositionFilter)
        {
            try
            {
                string errorMsg = string.Empty;
                int totalRecord = 0;
                List<CashPositionViewModel> cashPositions = _service.GetCashPositions(ref totalRecord, cashPositionFilter, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.CashPositions = cashPositions;
                dynamicObj.ErrorMsg = errorMsg;
                dynamicObj.TotalRecord = totalRecord;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("GetDashboardCashPosition")]
        public async Task<IActionResult> GetDashboardCashPosition(CashPositionFilter cashPositionFilter)
        {
            try
            {
                string errorMsg = string.Empty;
                List<CashPositionViewModel> cashPositions = _service.GetDashboardCashPosition(cashPositionFilter, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.CashPositions = cashPositions;
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
