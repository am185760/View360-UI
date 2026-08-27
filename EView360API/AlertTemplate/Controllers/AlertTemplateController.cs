using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AlertTemplate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlertTemplateController : Controller
    {
        private readonly CoreContext _context;

        public AlertTemplateController(CoreContext context)
        {
            _context = context;
        }

        [HttpGet("GetAlertTypes")]
        public async Task<IActionResult> GetAlertTypes()
        {
            try
            {
                List<AlertTypeViewModel> alertTypeViewModels = new();

                List<AlertType> alertTypes = await _context.AlertTypes.ToListAsync();
                if (alertTypes.Count > 0)
                {
                    string json = JsonConvert.SerializeObject(alertTypes);
                    alertTypeViewModels = JsonConvert.DeserializeObject<List<AlertTypeViewModel>>(json)!;
                }

                return Ok(alertTypeViewModels);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPut("UpdateAlertType")]
        public async Task<IActionResult> PutAlertType(AlertType alertType)
        {
            try
            {
                if (_context.AlertTypes.Any(x => x.AlertTypeId == alertType.AlertTypeId))
                {
                    _context.Entry(alertType).State = EntityState.Modified;
                }
                else
                {
                    return BadRequest();
                }
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
