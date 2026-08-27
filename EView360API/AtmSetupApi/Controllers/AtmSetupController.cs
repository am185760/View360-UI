using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EView360Models.Core;
using Common.ViewModel;
using AtmSetupApi.Interceptors;
using Newtonsoft.Json;
using DataRequestor;
using System.Data;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Azure;
using System.Runtime.CompilerServices;

namespace AtmSetupApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtmSetupController : ControllerBase
    {
        private readonly CoreContext _context;
        private Executor executor { get; set; }

        public AtmSetupController(CoreContext context, Executor executor)
        {
            _context = context;
            this.executor = executor;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAtmByUserId(int id)
        {
            try
            {

                var result = from a in _context.Atms
                             join b in _context.NoteSetTypes on a.NoteSetTypeId equals b.NoteSetTypeId
                             join c in _context.UserAtms on a.AtmId equals c.AtmId
                             join d in _context.AppUsers on c.UserId equals d.UserId
                             where c.UserId == id
                             select new { a.AtmId, a.Title, b.NoteSetTypeName, a.AtmType, a.Location, a.Ip, a.IsAtm, a.IsCdm, a.IsCcdm, a.IsActive, a.RegionId, a.CreationTime, b.NoteSetTypeId, a.IsRecycler, a.MinOperatingBalance, a.Tcptimeout, a.OutOfCashThreshold, a.RetryCountConfUpload, a.CreatedBy, d.UserFullName, a.Port, a.Cassette1Denomination, a.Cassette1Capacity, a.IsPurge1ThresholdSelected, a.Purge1Threshold, a.Type1MinNotesThreshold, a.Type1MinNotesThresholdValue, a.Cassette2Denomination, a.Cassette2Capacity, a.IsPurge2ThresholdSelected, a.Purge2Threshold, a.Type2MinNotesThreshold, a.Type2MinNotesThresholdValue, a.Cassette3Denomination, a.Cassette3Capacity, a.IsPurge3ThresholdSelected, a.Purge3Threshold, a.Type3MinNotesThreshold, a.Type3MinNotesThresholdValue, a.Cassette4Denomination, a.Cassette4Capacity, a.IsPurge4ThresholdSelected, a.Purge4Threshold, a.Type4MinNotesThreshold, a.Type4MinNotesThresholdValue, a.Cassette5Denomination, a.Cassette5Capacity, a.IsPurge5ThresholdSelected, a.Purge5Threshold, a.Type5MinNotesThreshold, a.Type5MinNotesThresholdValue, a.Cassette6Denomination, a.Cassette6Capacity, a.IsPurge6ThresholdSelected, a.Purge6Threshold, a.Type6MinNotesThreshold, a.Type6MinNotesThresholdValue, a.Cassette7Denomination, a.Cassette7Capacity, a.IsPurge7ThresholdSelected, a.Purge7Threshold, a.Type7MinNotesThreshold, a.Type7MinNotesThresholdValue, a.CdmCassette1Capacity, a.CdmCassette1Threshold, a.CdmCassette2Capacity, a.CdmCassette2Threshold, a.CdmCassette3Capacity, a.CdmCassette3Threshold, a.CdmCassette4Capacity, a.CdmCassette4Threshold, a.AllowedInactivityPeriod, a.CcdmCassette1Capacity, a.CcdmCassette1Threshold, a.CcdmCassette2Capacity, a.CcdmCassette2Threshold, a.CcdmCassette3Capacity, a.CcdmCassette3Threshold, a.CcdmCassette4Capacity, a.CcdmCassette4Threshold, a.ChequeAllowedInactivityPeriod, a.IsEdited, a.AssignedServer, a.MessageProcessorId, a.IsSwapDefaultReplenishment, a.SleepInterval, a.RetryCountCounterFile, a.IsHealthy, a.RecyclerType, a.RecyclerTower };

                return Ok(result);

                //List< Atm > atms = await _context.Atms.ToListAsync<Atm>();
                //List<NoteSetType> noteSetTypes = await _context.NoteSetTypes.ToListAsync<NoteSetType>();
                //List<AppUser> appUsers = await _context.AppUsers.ToListAsync();
                //List<UserAtm> userAtms = await _context.UserAtms.ToListAsync();

                //atms.Select(c => { c.NoteSetTypeName = noteSetTypes.Where(x => x.NoteSetTypeId == c.NoteSetTypeId)?.FirstOrDefault().NoteSetTypeName; c.CreatedByName = appUsers.Where(y => y.UserId == c.CreatedBy)?.FirstOrDefault()?.UserLogin; return c; }).ToList();
                //atms = atms.Where(x => userAtms.Any(y => y.AtmId == x.AtmId && y.UserId == id)).ToList();
                //return Ok(atms);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAtmFieldByUserId(int userId)
        {
            try
            {

                var result = from a in _context.Atms
                             join c in _context.UserAtms on a.AtmId equals c.AtmId
                             where c.UserId == userId
                             select new { a.AtmId, a.Title,  a.OutOfCashThreshold, a.MinOperatingBalance, a.RegionId };

                return Ok(result);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAtmUsers(long AtmId)
        {
            try
            {
                List<AppUser> AtmUsers = _context.AppUsers.ToList();
                if (AtmId != 0)
                {
                    foreach (AppUser user in AtmUsers)
                    {
                        if (_context.UserAtms.Any(a => a.UserId == user.UserId && a.AtmId == AtmId))
                        {
                            user.isSelected = true;
                        }
                    }
                }

                return Ok(AtmUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("GetATMInfo")]
        public async Task<IActionResult> GetATMInfo(long? createdBy, string? atmTitle, string? IP, string? atmType, bool? atmStatus, List<long> atmIds)
        {
            try
            {
                IQueryable<Atm>? queryable = new Atm[] { }.AsQueryable();

                queryable = _context.Atms;

                if (atmIds?.Count > 0)
                    queryable = queryable.Where(x => atmIds.Any(a => a == x.AtmId));

                if (createdBy != null)
                    queryable = queryable.Where(x => x.CreatedBy == createdBy);

                if (!string.IsNullOrEmpty(atmTitle))
                    queryable = queryable.Where(x => x.Title.ToLower().Contains(atmTitle.ToLower()) || atmTitle.ToLower().Contains(x.Title.ToLower()));

                if (!string.IsNullOrEmpty(IP))
                    queryable = queryable.Where(x => x.Ip.Contains(IP) || IP.Contains(x.Ip));

                if (!string.IsNullOrEmpty(atmType))
                    queryable = queryable.Where(x => x.AtmType.ToLower() == atmType.ToLower());

                if (atmStatus != null)
                    queryable = queryable.Where(x => x.IsActive == atmStatus);

                var result = from a in queryable
                             from app in _context.AppSettings
                             select new
                             {
                                 a.AtmId,
                                 a.Title,
                                 a.Ip,
                                 a.LastStatusReply,
                                 a.CreatedBy,
                                 a.IsActive,
                                 a.AtmType,
                                 a.Location,
                                 a.AtmOnDemandHeartbeatReceivedAt,
                                 a.AtmStreamingHeartbeatReceivedAt,
                                 app.AtmDataStreamingHeartbeatPort,
                                 app.AtmDataStreamingPort,
                                 app.AtmOnDemandRequestPort,
                                 app.AtmOnDemandRequestHearbeatPort
                             };

                return Ok(result);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<BaseModel>> CreateAtm(PostContentViewModel postContent)
        {
            try
            {
                Atm? atm = JsonConvert.DeserializeObject<Atm>(postContent.PostObj.ToString());
                string atmId = string.Empty;
                _context.Atms.Add(atm);



                AuditLogInterceptor.auditData = postContent.AuditData;
                await _context.SaveChangesAsync();
                //AuditLogInterceptor.CustomSavingChangesAsync(_context, tuple.Item2);

                //create user atm
                UserAtm userAtm = new UserAtm();
                userAtm.AtmId = atm.AtmId;
                userAtm.UserId = atm.CreatedBy;
                _context.UserAtms.Add(userAtm);
                await _context.SaveChangesAsync();

                //create new atm configuration task
                //string response = _taskService.CreateConfigurationTask(atm.CreatedBy, new List<string>() { atm.AtmId.ToString() } );
                //if (response != "success")
                //    throw new Exception("Error while creating configuration task");

                return Ok(atm.AtmId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("[action]/{atmId}/{UserId}/{rightId}/{message}")]
        public async Task<IActionResult> DeleteAtm(long atmId, long userId, int rightId, string message)
        {
            try
            {
                var atm = await _context.Atms.FindAsync(atmId);
                if (atm == null)
                {
                    return NotFound();
                }
                _context.Atms.Remove(atm);
                //remove user atm
                _context.UserAtms.RemoveRange(_context.UserAtms.Where(x => x.AtmId == atmId));

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@atm_id";
                param.SqlDbType = SqlDbType.Int;
                param.Value = atmId;

                DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("DeleteATM", new SqlParameter[] { param }, new List<string> { atmId.ToString() });

                if(!string.IsNullOrEmpty( result.ExceptionMessage))
                {
                    return BadRequest(result.ExceptionMessage);
                }
                else
                {
                    AuditLogInterceptor.auditData = new Common.ViewModel.AuditLogViewModel() { UserId = userId, RightId = rightId, Message = message };
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
        [Route("[action]")]
        public async Task<IActionResult> BulkUpdateAtm(PostContentViewModel postContent)
        {
            try
            {
                List<BulkUpdateAtmViewModel>? atmList = JsonConvert.DeserializeObject<List<BulkUpdateAtmViewModel>>(postContent.PostObj.ToString());
                foreach(BulkUpdateAtmViewModel atm in atmList)
                {
                    //if (_context.Atms.Any(x => x.AtmId == atm.AtmId))
                    //{
                        var dbAtm = _context.Atms.Find(atm.AtmId);
                        dbAtm.MinOperatingBalance = atm.MinOperatingBalance;
                        dbAtm.OutOfCashThreshold = atm.OutOfCashThreshold;
                        _context.Entry(dbAtm).State = EntityState.Modified;
                    //}
                }
                AuditLogInterceptor.auditData = postContent.AuditData;
                 _context.SaveChanges();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAtm(PostContentViewModel postContent)
        {
            try
            {
                Atm? atm = JsonConvert.DeserializeObject<Atm>(postContent.PostObj.ToString());
                atm.IsEdited = true;
                if (_context.Atms.Any(x => x.AtmId == atm.AtmId))
                {
                    _context.Entry(atm).State = EntityState.Modified;

                    AuditLogInterceptor.auditData = postContent.AuditData;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        [HttpPut("UpdateAtmPingStatus")]
        public async Task<IActionResult> UpdateAtmPingStatus(long atmId, DateTime LastPingExecutedAt, string status, Common.ViewModel.AuditLogViewModel auditData)
        {
            try
            {
                Atm atm = await _context.Atms.FindAsync(atmId);
                if (atm is not null)
                {
                    atm.LastPingExecutedAt = LastPingExecutedAt;
                    atm.LastPingStatus = status;
                    _context.Entry(atm).State = EntityState.Modified;
                    AuditLogInterceptor.auditData = auditData;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut("UpdateAtmTelnetStatus")]
        public async Task<IActionResult> UpdateAtmTelnetStatus(long atmId, DateTime LastTelnetExecutedAt, string status, Common.ViewModel.AuditLogViewModel auditData)
        {
            try
            {
                Atm atm = await _context.Atms.FindAsync(atmId);
                if (atm is not null)
                {
                    atm.LastTelnetExecutedAt = LastTelnetExecutedAt;
                    atm.LastTelnetStatus = status;
                    _context.Entry(atm).State = EntityState.Modified;
                    AuditLogInterceptor.auditData = auditData;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Cit>>> GetCitList()
        {
            return Ok(_context.Cits.ToList());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<TerminalType>>> GetVendorsList()
        {
            return Ok(_context.TerminalTypes.ToList());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<TaskType>>> GetAtmTaskType()
        {
            return Ok(_context.TaskTypes.ToList());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<NoteSetType>>> GetNoteSetTypeList()
        {
            return Ok(_context.NoteSetTypes.ToList());
        }


        [HttpPut]
        [Route("[action]/{appUsers}/{AtmId}")]
        public async Task<ActionResult> UpdateUserAtms(List<AppUser> appUsers, int AtmId)
        {
            try
            {
                foreach (var user in appUsers)
                {
                    if (user.isSelected)
                    {
                        if (!_context.UserAtms.Any(a => a.UserId == user.UserId && a.AtmId == AtmId))
                        {
                            UserAtm userAtm = new UserAtm { AtmId = AtmId, UserId = user.UserId };
                            _context.UserAtms.Add(userAtm);
                        }
                    }
                    else
                    {
                        if (_context.UserAtms.Any(a => a.UserId == user.UserId && a.AtmId == AtmId))
                        {
                            _context.UserAtms.RemoveRange(_context.UserAtms.Where(x => x.UserId == user.UserId && x.AtmId == AtmId));
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}