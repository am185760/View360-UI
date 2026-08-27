using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportTaskController : Controller
    {
        private readonly CoreContext _context;

        public ReportTaskController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports(DateTime fromDate, DateTime toDate, string? taskStatus = null)
        {
            try
            {

                List<ReportTaskViewModel> taskReports = (from rt in _context.ReportTasks
                                                         join rs in _context.ReportSchedules on rt.ReportScheduleId equals rs.ReportScheduleId
                                                         where rt.CreationTime >= fromDate && rt.CreationTime <= toDate
                                                         select new ReportTaskViewModel
                                                         {
                                                             CreationTime = rt.CreationTime,
                                                             ReportName = rs.ReportName,
                                                             Status = rt.Status,
                                                             FailureReason = rt.FailureReason,
                                                             RetryCount = rt.RetryCount
                                                         }).ToList();
                if (!string.IsNullOrEmpty(taskStatus))
                {
                    taskReports = taskReports.Where(x => x.Status == taskStatus).ToList();
                }
                return Ok(taskReports);
            }
            catch (Exception ex) { throw; }
        }
    }
}
