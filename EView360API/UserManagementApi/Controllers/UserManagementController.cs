using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.RequestModel;

namespace UserManagementApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly CoreContext _context;
        public UserManagementController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<UserViewModel>> GetUsers()
        {
            List<AppUser> userList = await _context.AppUsers.ToListAsync<AppUser>();
            List<UserViewModel> users = new List<UserViewModel>();
            List<AlertType> alertTypes = await _context.AlertTypes.ToListAsync<AlertType>();
            List<Group> groups = await _context.Groups.ToListAsync<Group>();
            //List<CcmsOrganization> organizations = await _context.CcmsOrganizations.ToListAsync<CcmsOrganization>();

            foreach (var user in userList)
            {
                UserViewModel userView = new UserViewModel();

                userView.User = user;
                List<AlertType> alerts = new List<AlertType>();
                foreach (var item in alertTypes)
                {
                    alerts.Add(new AlertType
                    {
                        AlertTypeName = item.AlertTypeName,
                        isSelected = item.isSelected,
                        AlertTypeId = item.AlertTypeId,
                        AlertDefaultText = item.AlertDefaultText,
                    });
                }

                userView.Alerts = alerts.Select(n => { if (_context.CcmsAlertNotifications.Any(a => a.UserId == user.UserId && a.AlertTypeId == n.AlertTypeId)) { n.isSelected = true; } return n; }).ToList();


                List<Group> groupslist = new List<Group>();
                foreach (var item in groups)
                {
                    groupslist.Add(new Group
                    {
                        GroupName = item.GroupName,
                        GroupId = item.GroupId,
                        isSelected = item.isSelected,
                    });
                }

                userView.Groups = groupslist.Select(n => { if (_context.GroupUsers.Any(a => a.UserId == user.UserId && a.GroupId == n.GroupId)) { n.isSelected = true; } return n; }).ToList();


                var userAtms = _context.UserAtms.Where(x => x.UserId == user.UserId).Select(x => x.AtmId).ToList();
                userView.AtmIds = userAtms.ConvertAll<String>(p => p.ToString()).ToArray<String>();

                users.Add(userView);
            }
            return users;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser(UserViewModel user)
        {
            try
            {
                user.User.UserCreationTime = DateTime.Now;
                user.User.UserIsActive = true;
                user.User.UserLastLoginTime = DateTime.Now;
                _context.AppUsers.Add(user.User);
                await _context.SaveChangesAsync();

                foreach (var alert in user.Alerts)
                {
                    if (alert.isSelected)
                    {
                        EView360Models.Core.CcmsAlertNotification x = new();
                        x.AlertTypeId = alert.AlertTypeId;
                        x.UserId = user.User.UserId;
                        _context.CcmsAlertNotifications.Add(x);
                    }
                }

                foreach (var group in user.Groups)
                {
                    if (group.isSelected)
                    {
                        EView360Models.Core.GroupUser x = new();
                        x.GroupId = group.GroupId;
                        x.UserId = user.User.UserId;
                        _context.GroupUsers.Add(x);
                    }
                }

                foreach (var atm in user.AtmIds)
                {
                    if (atm[0] == 'a')
                    {
                        long AtmId = long.Parse(atm.Substring(1));
                        _context.UserAtms.Add(new UserAtm() { UserId = user.User.UserId, AtmId = AtmId });
                    }
                }

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPut]
        [Route("[action]/{user}")]
        public async Task<IActionResult> UpdateUser(UserViewModel user)
        {
            try
            {
                if (_context.AppUsers.Any(x => x.UserId == user.User.UserId))
                {
                    _context.Entry(user.User).State = EntityState.Modified;

                    foreach (var alert in user.Alerts)
                    {
                        if (alert.isSelected)
                        {
                            if (!_context.CcmsAlertNotifications.Any(a => a.UserId == user.User.UserId && a.AlertTypeId == alert.AlertTypeId))
                            {
                                EView360Models.Core.CcmsAlertNotification x = new();
                                x.AlertTypeId = alert.AlertTypeId;
                                x.UserId = user.User.UserId;
                                _context.CcmsAlertNotifications.Add(x);
                            }
                        }
                        else
                        {
                            if (_context.CcmsAlertNotifications.Any(a => a.UserId == user.User.UserId && a.AlertTypeId == alert.AlertTypeId))
                            {
                                _context.CcmsAlertNotifications.Remove(_context.CcmsAlertNotifications.Where(x => x.UserId == user.User.UserId && x.AlertTypeId == alert.AlertTypeId).FirstOrDefault());
                            }
                        }
                    }

                    foreach (var group in user.Groups)
                    {
                        if (group.isSelected)
                        {
                            if (!_context.GroupUsers.Any(a => a.UserId == user.User.UserId && a.GroupId == group.GroupId))
                            {
                                EView360Models.Core.GroupUser x = new();
                                x.GroupId = group.GroupId;
                                x.UserId = user.User.UserId;
                                _context.GroupUsers.Add(x);
                            }
                        }
                        else
                        {
                            if (_context.GroupUsers.Any(a => a.UserId == user.User.UserId && a.GroupId == group.GroupId))
                            {
                                _context.GroupUsers.Remove(_context.GroupUsers.Where(x => x.UserId == user.User.UserId && x.GroupId == group.GroupId).FirstOrDefault());
                            }
                        }
                    }

                    _context.UserAtms.RemoveRange(_context.UserAtms.Where(a => a.UserId == user.User.UserId));
                    foreach (var atm in user.AtmIds)
                    {
                        if (atm.StartsWith('a'))
                        {
                            UserAtm userAtm = new UserAtm();
                            userAtm.AtmId = int.Parse(atm.Substring(1));
                            userAtm.UserId = user.User.UserId;
                            _context.UserAtms.Add(userAtm);
                        }

                    }
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    //_context.UserOrganizations.Remove(_context.UserOrganizations.Where(x => x.UserId == id).FirstOrDefault());
                    if (_context.CcmsAlertNotifications.Any(x => x.UserId == id))
                        _context.CcmsAlertNotifications.RemoveRange(_context.CcmsAlertNotifications.Where(x => x.UserId == id));
                    if (_context.GroupUsers.Any(x => x.UserId == id))
                        _context.GroupUsers.RemoveRange(_context.GroupUsers.Where(x => x.UserId == id));


                    _context.AppUsers.Remove(user);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok();
        }

        [HttpPut]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> ChangeUserStatus(long userId)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(userId);
                string response = string.Empty;
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    if (user.UserIsActive)
                    {
                        user.UserIsActive = false;
                        response = "Inactive";
                    }
                    else
                    {
                        user.UserIsActive = true;
                        response = "Active";
                    }
                }
                _context.SaveChanges();
                return Ok(response);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<UserViewModel> GetNewUser()
        {
            UserViewModel newUser = new UserViewModel();
            newUser.User = new();
            newUser.Alerts = await _context.AlertTypes.ToListAsync<AlertType>();
            newUser.Groups = await _context.Groups.ToListAsync<Group>();
            //newUser.Organizations = await _context.CcmsOrganizations.ToListAsync<CcmsOrganization>();
            return newUser;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var appUsers = _context.AppUsers.ToList().ConvertAll(x => (AppUserDropdownViewModel)x);
                var response = new BaseModel
                {
                    IsSuccess = true,
                    Message = "Succesfully fetch all records",
                    Data = appUsers
                };
                return Ok(response);

            }
            catch (Exception ex) { throw; }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAlertTypes()
        {
            try
            {
                return Ok(_context.AlertTypes.Select(x => x.AlertTypeName).ToList());
            }
            catch (Exception ex) { throw; }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetRightsByType()
        {
            try
            {
                RightsViewModel rights = new RightsViewModel()
                {
                    AdminRights = _context.Rights.Where(x => x.RightType == "Administration").Select(x => x.RightId).ToList(),
                    OperationRights = _context.Rights.Where(x => x.RightType == "Operations").Select(x => x.RightId).ToList(),
                    ReportRights = _context.Rights.Where(x => x.RightType == "Reports").Select(x => x.RightId).ToList(),
                    ArchiveRights = _context.Rights.Where(x => x.RightType == "Archive").Select(x => x.RightId).ToList()
                };

                return Ok(rights);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPut]
        [Route("UpdateUserPassword/{changePasswordRequest}")]
        public async Task<IActionResult> UpdateUserPassword(ChangePasswordRequestModel changePasswordRequest)
        {
            try
            {
                if (_context.AppUsers.Any(x => x.UserId == changePasswordRequest.UserId))
                {
                    var user = _context.AppUsers.FirstOrDefault(x => x.UserId == changePasswordRequest.UserId);
                    user.UserPassword =  changePasswordRequest.Password;
                    _context.Entry(user).State = EntityState.Modified;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest("User not found.");
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
    }
}
