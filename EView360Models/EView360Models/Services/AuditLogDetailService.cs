using EView360Models.Core;
using EView360Models.Repository;
using EView360Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.Services
{
    public class AuditLogDetailService
    {
        private readonly UnitOfWork _unitOfWork;
        public AuditLogDetailService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseModel> GetAll(DateTime fromDate, DateTime toDate, int? rightId, int userId)
        {
            IQueryable<AuditLog>? queryable = new AuditLog[] { }.AsQueryable();
            queryable = _unitOfWork.AuditLogRepository.Get();
            if (fromDate != DateTime.MinValue)
            {
                queryable = queryable.Where(x => x.ActivityTime.Date >= fromDate.Date);
            }

            if (toDate != DateTime.MinValue)
            {
                queryable = queryable.Where(x => x.ActivityTime.Date <= toDate.Date);
            }

            if (rightId != 0)
            {
                queryable = queryable.Where(x => x.RightId == rightId);
            }
            if (userId != 0)
            {
                queryable = queryable.Where(x => x.UserId == userId);
            }
            //queryable = queryable.Include(x => x.AuditLogDetails);
            //queryable = queryable.OrderByDescending(x => x.ActivityTime);
            //var auditLogDetails = queryable.Select(x => x.AuditLogDetails).ToList();
            //IQueryable<List<AuditLogDetail>> queryable1 = queryable.Select(x => x.AuditLogId);
            var AuditLogIds  = queryable.Select(x => x.AuditLogId).ToList();




            //List<AuditLogDetail> auditLogDetail = (List<AuditLogDetail>)queryable1;
            //auditLogs.Select(x => { x.UserLoginName = _unitOfWork.AppUserRepository.Get(u => u.UserId == x.UserId).FirstOrDefault()?.UserLogin; return x; }).ToList();
            //_unitOfWork.AuditLogDetailRepository.Get()



            //var details =  _unitOfWork.AuditLogDetailRepository.Get(x => auditLogs.ToList().Select(d => d.AuditLogId).Contains(x.AuditLogId)).ToList();
            var details = _unitOfWork.AuditLogDetailRepository.Get();
            var auditlogDetails = details.Where(x => AuditLogIds.Contains(x.AuditLogId)).Select(x => new { x.FieldName, x.OldValue, x.NewValue, x.AuditLogId });
            //IQueryable<AuditLogDetail>? queryable1 = new AuditLogDetail[] { }.AsQueryable();
            //Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<AuditLogDetail, AuditLog> includableQueryable = _unitOfWork.AuditLogDetailRepository.Get().Include(x => x.AuditLog);
            ////var queryable1 = includableQueryable;
            //if (fromDate != DateTime.MinValue)
            //{
            //    includableQueryable = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<AuditLogDetail, AuditLog>)includableQueryable.Where(x => x.AuditLog.ActivityTime.Date >= fromDate.Date);
            //}

            //if (toDate != DateTime.MinValue)
            //{
            //    queryable = queryable.Where(x => x.ActivityTime.Date <= toDate.Date);
            //}

            //if (rightId != 0)
            //{
            //    queryable = queryable.Where(x => x.RightId == rightId);
            //}
            //if (userId != 0)
            //{
            //    queryable = queryable.Where(x => x.UserId == userId);
            //}
            return new BaseModel
            {
                IsSuccess = true,
                Message = $"Successfully retrieved all records.",
                Data = auditlogDetails,
            };
        }

       
    }
}
