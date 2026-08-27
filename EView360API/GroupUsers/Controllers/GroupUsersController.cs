using Common.ViewModel;
using EView360Models.Core;
using EView360Models.ViewModels;
using GroupUsers.Interceptor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupUsers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupUsersController : Controller
    {
        private readonly CoreContext _context;

        public GroupUsersController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet("GetGroupDetails")]
        public async Task<IActionResult> GetGroupDetails()
        {
            List<GroupViewModel> groupViews = new();
            try
            {
                List<Group> groupList = (from g in _context.Groups
                                         select g)
                                        .Include(x => x.GroupUsers)
                                        .ThenInclude(y => y.User)
                                        .Include(x => x.GroupRights)
                                        .ThenInclude(y => y.Right)
                                        .ToList();                

                if (groupList is not null) 
                {
                    foreach(Group group in groupList) 
                    {
                        GroupViewModel groupView = new();
                        groupView.group = new()
                        {
                            GroupId = group.GroupId,
                            Description= group.Description,
                            GroupName= group.GroupName
                        };
                        groupView.groupRights = group.GroupRights?.Select(x => x.Right?.Name).ToList();
                        groupView.groupUsers = group.GroupUsers?.Select(x => x.User?.UserFullName).ToList();
                        groupViews.Add(groupView);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(groupViews);
        }

        [HttpGet("GetRights")]
        public async Task<IActionResult> GetRights()
        {
            try
            {
                return Ok(await _context.Rights.ToListAsync());
            }
            catch(Exception ex) 
            {
                throw;
            }            
        }


        [HttpPost("CreateGroup")]
        public async Task<ActionResult> PostGroup(Group group)
        {
            try
            {
                _context.Groups.Add(group);
                await _context.SaveChangesAsync();
                return Ok(group.GroupId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CreateGroupRights")]
        public async Task<ActionResult> PostGroupRights(List<GroupRight> groupRights)
        {
            try
            {
                _context.GroupRights.AddRange(groupRights);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut("UpdateGroup")]
        public async Task<IActionResult> PutGroup(Common.ViewModel.GroupRightVM groupVM)
        {
            try
            {
                AuditLogInterceptor auditLog = new AuditLogInterceptor();

                _context.Entry(groupVM.group).State = EntityState.Modified;
                long auditLogPk = auditLog.InsertActivity(_context, groupVM.AuditData);

                string oldValue = string.Empty, newValue = string.Empty;

                // Get existing (old) rights
                var grpRights = await _context.GroupRights
                    .Where(x => x.GroupId == groupVM.group.GroupId)
                    .ToListAsync();

                // Build old value for audit
                if (grpRights?.Count > 0)
                {
                    var oldRightIds = grpRights.Select(y => y.RightId).ToList();
                    List<string> currentRights = _context.Rights
                        .Where(x => oldRightIds.Contains(x.RightId))
                        .Select(z => z.Name)
                        .ToList();
                    if (currentRights?.Count > 0)
                        oldValue = string.Join(",", currentRights);
                }

                // Build new value for audit — use groupVM.groupRights, NOT grpRights
                if (groupVM.groupRights?.Count > 0)
                {
                    var newRightIds = groupVM.groupRights.Select(y => y.RightId).ToList(); // ← FIXED
                    List<string> newRights = _context.Rights
                        .Where(x => newRightIds.Contains(x.RightId))
                        .Select(z => z.Name)
                        .ToList();
                    if (newRights?.Count > 0)
                        newValue = string.Join(",", newRights);
                }

                // Always write audit + sync rights, regardless of old rights count
                AuditLogDetail auditLogDetail = new AuditLogDetail()
                {
                    AuditLogId = auditLogPk,
                    FieldName = "GroupRights",
                    OldValue = oldValue,
                    NewValue = newValue
                };
                _context.AuditLogDetails.Add(auditLogDetail);

                // Remove old rights (may be empty — RemoveRange handles that fine)
                if (grpRights?.Count > 0)
                    _context.GroupRights.RemoveRange(grpRights);

                // Add new rights (may be empty too)
                if (groupVM.groupRights?.Count > 0)
                    _context.GroupRights.AddRange(groupVM.groupRights);

                await _context.SaveChangesAsync(); // ← single save covers everything
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("DeleteGroupRights/{id}")]
        public async Task<ActionResult> DeleteGroupRights(long id)
        {
            try
            {
                var grpRights = await _context.GroupRights.Where(x => x.GroupId == id).ToListAsync();
                if (grpRights?.Count > 0)
                {
                    _context.GroupRights.RemoveRange(grpRights);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("DeleteGroup/{id}")]
        public async Task<ActionResult> DeleteGroup(long id)
        {
            try
            {
                var group = await _context.Groups.FindAsync(id);
                if (group == null)
                {   
                    return NotFound();
                }
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}
