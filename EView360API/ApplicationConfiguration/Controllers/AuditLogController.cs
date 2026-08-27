using EView360Models.Core;
using EView360Models.Repository;
using EView360Models.RequestModel;
using EView360Models.ServiceInterface;
using EView360Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationConfiguration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService auditLogService;    
        private readonly CoreContext _context;
        private readonly AuditLogDetailService auditLogDetailService;

        public AuditLogController(CoreContext context, IAuditLogService auditLogService, AuditLogDetailService auditLogDetailService)
        {
            _context = context;
            this.auditLogService = auditLogService;
            this.auditLogDetailService = auditLogDetailService;
        }


        [HttpGet("GetAuditLog")]
        public async Task<IActionResult> GetAuditLog(DateTime fromDate, DateTime toDate, int? rightId, int userId,bool isReport)
        {
            try
            {
                var response = await auditLogService.GetAll(fromDate, toDate, rightId, userId, isReport);

                return Ok(response);
            }

            catch (Exception ex) { throw; }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAuditLogDetailById(long auditLogId)
        {
            try
            {
                var result = from a in _context.AuditLogDetails
                             where a.AuditLogId == auditLogId
                             select new { a.FieldName, a.OldValue, a.NewValue };

                return Ok(result);
            }

            catch (Exception ex) { throw; }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> BuildAuditLog(BuildAuditLogViewModel auditLog)
        {
            try
            {
                var response = auditLogService.Create(auditLog);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAuditLogDetails(DateTime fromDate, DateTime toDate, int? rightId, int userId)
        {
            try
            {
                
                var result = await auditLogDetailService.GetAll(fromDate, toDate, rightId, userId);

                return Ok(result);
            }

            catch (Exception ex) { throw; }
        }
    }
}
