using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RecreateDailyFeedApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecreateDailyFeedController : ControllerBase
    {
        private readonly CoreContext _context;
        public RecreateDailyFeedController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDailyFeedSchedules(string fromDate, string toDate)
        {
            try
            {
                DateTime startDate = Convert.ToDateTime(fromDate);
                DateTime endDate = Convert.ToDateTime(toDate);

                var result = from s in _context.DailyFeedSchedules
                             where s.CreationTime.Date >= startDate.Date && s.CreationTime.Date <= endDate.Date
                             orderby s.Mcn ascending
                             select s;

                return Ok(result);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetRetryCount()
        {
            try
            {
                var result = (from x in _context.AppSettings select x.RetryCountDffUpload).FirstOrDefault();

                return Ok(result);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewSchedule(DailyFeedSchedule schedule)
        {
            try
            {
                _context.DailyFeedSchedules.Add(schedule);
                await _context.SaveChangesAsync();

                return Ok(new BaseModel { IsSuccess = true, Message = "Schedule successfully added" } );
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("[action]/{scheduleId}")]
        public async Task<IActionResult> DeleteSchedule(long scheduleId)
        {
            try
            {
                var schedule = await _context.DailyFeedSchedules.FindAsync(scheduleId);
                if (schedule == null)
                {
                    return NotFound();
                }
                _context.DailyFeedSchedules.Remove(schedule);
                await _context.SaveChangesAsync();

                return Ok(new BaseModel { IsSuccess = true, Message = "Schedule successfully deleted" });
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
