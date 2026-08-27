using ApplicationConfiguration.Interceptors;
using Common.ViewModel;
using EView360Models.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApplicationConfiguration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppConfigurationController : Controller
    {
        private readonly CoreContext _context;

        public AppConfigurationController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet("GetAppSetting")]
        public async Task<IActionResult> GetAppSetting()
        {
            try
            {
                return Ok(await _context.AppSettings.FirstOrDefaultAsync());
            }
            catch(Exception ex) { throw; }      
        }

        [HttpGet("GetCcmsServices")]
        public async Task<IActionResult> GetCcmsServices()
        {
            try
            {
                return Ok(await _context.CcmsServices.ToListAsync());
            }
            catch (Exception ex) { throw; }            
        }

        [HttpPut("SaveApplicationSetting")]
        public async Task<ActionResult> SaveApplicationSetting(PostContentViewModel postContent)
        {
            try
            {
                AppSetting? appSetting = JsonConvert.DeserializeObject<AppSetting>(postContent.PostObj.ToString());
                appSetting.IsEdited = true;
                if (_context.AppSettings.Any(x => x.AppSettingId == appSetting.AppSettingId))
                {
                    _context.Entry(appSetting).State = EntityState.Modified;
                }
                else
                {
                    return BadRequest();
                }

                AuditLogInterceptor.auditData = postContent.AuditData;

                Atm atm = _context.Atms.FirstOrDefault()!;
                if (atm.Port != appSetting.AtmOnDemandRequestPort)
                {
                    _context.Atms.ExecuteUpdate(s => s.SetProperty(e => e.Port, e => appSetting.AtmOnDemandRequestPort));
                }



                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut("SaveCCMSServices")]
        public async Task<ActionResult> SaveCCMSServices(List<CcmsService> ccmsServices)
        {
            try
            {
                if (ccmsServices is not null)
                {
                    foreach (CcmsService service in ccmsServices)
                    {
                        if (_context.CcmsServices.Any(x => x.CcmsServicesId == service.CcmsServicesId))
                        {
                            _context.Entry(service).State = EntityState.Modified;
                        }
                        else
                        {
                            return BadRequest();
                        }
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}
