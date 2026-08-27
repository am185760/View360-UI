using Common.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReportApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BnaCounterController : Controller
    {
       private readonly BnaCounterReportService bnaCounterReportService;
        public BnaCounterController(BnaCounterReportService bnaCounterReportService)
        {
            this.bnaCounterReportService = bnaCounterReportService;
        }

        [HttpPost("GetBNACounterDetail")]
        public IActionResult GetBNACounterDetail(BnaCounterReportRequestModel reportRequestModel) 
        {
            try
            {
                var response = bnaCounterReportService.GetBnaCounterReport(reportRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("GetBnaCounterSubReportReport")]
        public IActionResult GetBnaCounterSubReportReport(BnaCounterReportRequestModel reportRequestModel) 
        {
            try
            {
                var response = bnaCounterReportService.GetBnaCounterSubReportReport(reportRequestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
