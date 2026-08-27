using EView360Models.Core;
using Microsoft.AspNetCore.Mvc;
using EView360Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Common.ViewModel;
using NoteSetTypeApi.Interceptors;

namespace NoteSetTypeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteSetTypeController : Controller
    {
        private readonly CoreContext _context;

        public NoteSetTypeController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet("GetNoteSetTypeByUserId/{id}")]
        public async Task<IActionResult> GetNoteSetTypeByUserId(long id)
        {
            try
            {

                var noteSetTypes = from n in _context.NoteSetTypes
                                   //join u in _context.AppUsers on n.CreatedBy equals u.UserId
                                   //where u.UserId == id
                                   select new
                                   {
                                       n.NoteSetTypeName,
                                       n.DenominationType1Title,
                                       n.DenominationType2Title,
                                       n.DenominationType3Title,
                                       n.DenominationType4Title,
                                       //u.UserId,
                                       n.IsType1Recycler,
                                       n.IsType2Recycler,
                                       n.IsType3Recycler,
                                       n.IsType4Recycler,
                                       n.NoteSetTypeId,
                                       n.CreationTime,
                                       n.CreatedBy,
                                       n.DenominationType1,
                                       n.DenominationType2,
                                       n.DenominationType3,
                                       n.DenominationType4,
                                       n.IsType1MultiCurrency,
                                       n.IsType2MultiCurrency,
                                       n.IsType3MultiCurrency,
                                       n.IsType4MultiCurrency,
                                       //CreatedByName = u.UserLogin
                                   };                

                return Ok(noteSetTypes);

                //List < NoteSetType > noteSetTypes = await _context.NoteSetTypes.Where(x => x.CreatedBy == id).ToListAsync();
                //List<AppUser> appUsers = await _context.AppUsers.ToListAsync();
                //if (appUsers is not null && appUsers.Any())
                //{
                //    noteSetTypes.Select(c => { c.CreatedByName = appUsers.Where(x => x.UserId == c.CreatedBy)?.FirstOrDefault()?.UserLogin; return c; }).ToList();
                //}                
                //return Ok(noteSetTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("IfAtmExistForNoteSetType")]
        public async Task<IActionResult> IfAtmExistForNoteSetType(long noteSetTypeId)
        {
            try
            {
                return Ok(await _context.Atms.AnyAsync(x => x.NoteSetTypeId == noteSetTypeId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpdateNoteSetType/{id}")]
        public async Task<IActionResult> PutNoteSetType(long id, PostContentViewModel postContent)
        {
            try
            {
                NoteSetType? noteSetType = JsonConvert.DeserializeObject<NoteSetType>(postContent.PostObj.ToString());

                if (noteSetType.DenominationType1 == null)
                    noteSetType.DenominationType1 = 0;
                if (noteSetType.DenominationType2 == null)
                    noteSetType.DenominationType2 = 0;
                if (noteSetType.DenominationType3 == null)
                    noteSetType.DenominationType3 = 0;
                if (noteSetType.DenominationType4 == null)
                    noteSetType.DenominationType4 = 0;
                if (noteSetType.DenominationType5 == null)
                    noteSetType.DenominationType5 = 0;
                if (noteSetType.DenominationType6 == null)
                    noteSetType.DenominationType6 = 0;
                if (noteSetType.DenominationType7 == null)
                    noteSetType.DenominationType7 = 0;

                if (noteSetType.DenominationType1Title == null)
                    noteSetType.DenominationType1Title = string.Empty;
                if (noteSetType.DenominationType2Title == null)
                    noteSetType.DenominationType2Title = string.Empty;
                if (noteSetType.DenominationType3Title == null)
                    noteSetType.DenominationType3Title = string.Empty;
                if (noteSetType.DenominationType4Title == null)
                    noteSetType.DenominationType4Title = string.Empty;
                if (noteSetType.DenominationType5Title == null)
                    noteSetType.DenominationType5Title = string.Empty;
                if (noteSetType.DenominationType6Title == null)
                    noteSetType.DenominationType6Title = string.Empty;
                if (noteSetType.DenominationType7Title == null)
                    noteSetType.DenominationType7Title = string.Empty;

                noteSetType.IsEdited = true;
                if (id != noteSetType.NoteSetTypeId)
                {
                    return BadRequest();
                }
                else if (_context.NoteSetTypes.Any(x => x.NoteSetTypeId == id))
                {
                    _context.Entry(noteSetType).State = EntityState.Modified;
                }
                else
                {
                    return BadRequest();
                }

                AuditLogInterceptor.auditData = postContent.AuditData;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CreateNoteSetType")]
        public async Task<IActionResult> PostNoteSetType(NoteSetType noteSetType)
        {
            try
            {
                if (noteSetType.DenominationType1 == null)
                    noteSetType.DenominationType1 = 0;
                if (noteSetType.DenominationType2 == null)
                    noteSetType.DenominationType2 = 0;
                if (noteSetType.DenominationType3 == null)
                    noteSetType.DenominationType3 = 0;
                if (noteSetType.DenominationType4 == null)
                    noteSetType.DenominationType4 = 0;
                if (noteSetType.DenominationType5 == null)
                    noteSetType.DenominationType5 = 0;
                if (noteSetType.DenominationType6 == null)
                    noteSetType.DenominationType6 = 0;
                if (noteSetType.DenominationType7 == null)
                    noteSetType.DenominationType7 = 0;

                if (noteSetType.DenominationType1Title == null)
                    noteSetType.DenominationType1Title = string.Empty;
                if (noteSetType.DenominationType2Title == null)
                    noteSetType.DenominationType2Title = string.Empty;
                if (noteSetType.DenominationType3Title == null)
                    noteSetType.DenominationType3Title = string.Empty;
                if (noteSetType.DenominationType4Title == null)
                    noteSetType.DenominationType4Title = string.Empty;
                if (noteSetType.DenominationType5Title == null)
                    noteSetType.DenominationType5Title = string.Empty;
                if (noteSetType.DenominationType6Title == null)
                    noteSetType.DenominationType6Title = string.Empty;
                if (noteSetType.DenominationType7Title == null)
                    noteSetType.DenominationType7Title = string.Empty;

                _context.NoteSetTypes.Add(noteSetType);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("DeleteNoteSetType/{id}")]
        public async Task<IActionResult> DeleteNoteSetType(long id)
        {
            try
            {
                var noteSetType = await _context.NoteSetTypes.FindAsync(id);
                if (noteSetType == null)
                {
                    return NotFound();
                }
                _context.NoteSetTypes.Remove(noteSetType);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpGet("GetNoteSetTypeByAtmId/{atmId}")]
        public async Task<IActionResult> GetNoteSetTypeByAtmId(long atmId)
        {
            try
            {
                var noteSetTypes = from n in _context.NoteSetTypes
                                   join u in _context.Atms on n.NoteSetTypeId equals u.NoteSetTypeId
                                   where u.AtmId == atmId
                                   select new ReplenishmentViewModel
                                   {
                                       Title = u.Title,
                                       DenominationType1 = (int)((n.DenominationType1.HasValue) ? n.DenominationType1:0),
                                       DenominationType2 = (int)((n.DenominationType2.HasValue) ? n.DenominationType2 : 0),
                                       DenominationType3 = (int)((n.DenominationType3.HasValue) ? n.DenominationType3 : 0),
                                       DenominationType4 = (int)((n.DenominationType4.HasValue) ? n.DenominationType4 : 0),
                                   };
                return Ok(noteSetTypes.First());

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
