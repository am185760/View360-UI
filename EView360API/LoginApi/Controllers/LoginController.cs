using Azure.Core;
using EView360Models.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoginApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CoreContext _context;
        public LoginController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<int>> GetRetryAttempt(long userId)
        {
            try
            {
                var userRetryAttempts = (from a in _context.AppUsers
                                         where a.UserId == userId
                                         select a.RetryAttempt).FirstOrDefault();
                return Ok(userRetryAttempts);
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<AppUser>> GetUser(string userLogin)
        {
            try
            {
                AppUser user = await _context.AppUsers.SingleOrDefaultAsync(u => u.UserLogin == userLogin);

                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Dictionary<int, string>>> GetUserRight(long userId)
        {
            try
            {
                //SELECT distinct(NAME), RIGHTS.RIGHT_ID 
                //FROM GROUP_USERS, GROUP_RIGHTS, RIGHTS
                //WHERE GROUP_USERS.USER_ID = 2 AND GROUP_USERS.GROUP_ID = GROUP_RIGHTS.GROUP_ID AND GROUP_RIGHTS.RIGHT_ID = RIGHTS.RIGHT_ID

                var rights = (from gu in _context.GroupUsers
                              join gr in _context.GroupRights
                              on gu.GroupId equals gr.GroupId
                              join r in _context.Rights
                              on gr.RightId equals r.RightId
                              where gu.UserId == userId
                              select new { r.RightId, r.Name }
                                                 ).Distinct().ToDictionary(r => r.RightId, r => r.Name);
                return Ok(rights);
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPut]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> DeductRetryAttempt(long userId)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(userId);
                if (user == null)
                    return BadRequest("user not found");
                user.RetryAttempt -= 1;
                await _context.SaveChangesAsync();
                return Ok(user.RetryAttempt);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> SetUserAsInactive(long userId)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(userId);
                if (user == null)
                    return BadRequest("User not found");
                user.UserModificationTime = DateTime.Now;
                user.UserIsActive = false;
                await _context.SaveChangesAsync();
                return Ok(user.UserIsActive);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> ResetRetryAttempt(long userId)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(userId);
                if (user == null)
                    return BadRequest("user not found");
                user.RetryAttempt = 5;
                user.UserLastLoginTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(user.RetryAttempt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> BuildAuditLog(AuditLog auditLog)
        {
            try
            {
                _context.AuditLogs.Add(auditLog);

                await _context.SaveChangesAsync();
                return Ok("Audit Entry Success");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
