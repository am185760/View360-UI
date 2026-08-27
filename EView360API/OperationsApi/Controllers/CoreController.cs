using EView360Models.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoreController : Controller
    {
        private readonly CoreContext _context;

        public CoreController(CoreContext context)
        {
            _context = context;
        }


        [HttpGet("GetFileTypes")]
        public async Task<IActionResult> GetFileTypes()
        {
            try
            {
                return Ok(await _context.FileTypes.ToListAsync());
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("GetDashboardRefreshInterval")]
        public async Task<IActionResult> GetDashboardRefreshInterval()
        {
            try
            {
                return Ok(_context.AppSettings.FirstOrDefault()?.DashboardRefreshInterval);
            }
            catch (Exception ex) { throw; }
        }
    }
}
