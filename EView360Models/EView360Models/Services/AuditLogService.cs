
using EView360Models.Core;
using EView360Models.Repository;
using EView360Models.RequestModel;
using EView360Models.ServiceInterface;
using EView360Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace EView360Models.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly UnitOfWork _unitOfWork;

        public AuditLogService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseModel> Create(BuildAuditLogViewModel buildAuditLogViewModel)
        {
            _unitOfWork.AuditLogRepository.Insert((AuditLog)buildAuditLogViewModel);
            _unitOfWork.Save();
            return new BaseModel
            {
                IsSuccess = true,
                Message = $"Record is succesfully Added.",
                Data = buildAuditLogViewModel,
            };
        }

        public async Task<BaseModel> GetAll(DateTime fromDate, DateTime toDate, int? rightId, int userId, bool isReport, string search = null)
        {
            IQueryable<AuditLog>? queryable = new AuditLog[] { }.AsQueryable();
            queryable= _unitOfWork.AuditLogRepository.Get();
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
            queryable = queryable.OrderByDescending(x => x.ActivityTime);  
            var auditLogs = queryable.ToList().ConvertAll(x => (AuditLogViewModel)x);
            auditLogs.Select(x => { x.UserLoginName = _unitOfWork.AppUserRepository.Get(u => u.UserId == x.UserId).FirstOrDefault()?.UserLogin; return x; }).ToList();


            return new BaseModel
            {
                IsSuccess = true,
                Message = $"Successfully retrieved all records.",
                Data = isReport ? JsonConvert.SerializeObject( ConvertListToDataTable(auditLogs)) : auditLogs,
            };
        }


        public DataTable ConvertListToDataTable(List<AuditLogViewModel> auditLogs) 
        { 
            DataTable dt = new DataTable();
            dt.Columns.Add("audit_log_id");
            dt.Columns.Add("activity_time");
            dt.Columns.Add("user_full_name");
            dt.Columns.Add("message");

            for (int i = 0; i < auditLogs.Count; i++)
            {

                DataRow dr = dt.NewRow();
                dr["audit_log_id"] = auditLogs[i].AuditLogId;
                dr["activity_time"] = auditLogs[i].ActivityTime;
                dr["message"] = auditLogs[i].Message;
                dr["user_full_name"] = auditLogs[i].UserLoginName;

                dt.Rows.Add(dr);
            }

            return dt;  
        }
        

    }
}
