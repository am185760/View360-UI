using EView360Models.Core;
using EView360Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.RequestModel
{
    public class BuildAuditLogViewModel
    {
        public string Message { get; set; } = null!;

        public long RightId { get; set; }

        public long UserId { get; set; }

        public DateTime ActivityTime { get; set; }


        public static explicit operator AuditLog(BuildAuditLogViewModel auditLog)
        {
            if (auditLog == null)
            {
                return null;
            }

            AuditLog result = new();
            result.RightId = auditLog.RightId;
            result.UserId = auditLog.UserId;
            result.ActivityTime = auditLog.ActivityTime;
            result.Message = auditLog.Message;
            return result;
        }

        public static explicit operator BuildAuditLogViewModel(AuditLog auditLog)
        {
            if (auditLog == null)
            {
                return null;
            }

            BuildAuditLogViewModel result = new BuildAuditLogViewModel();
            result.ActivityTime = auditLog.ActivityTime;
            result.Message = auditLog.Message;
            result.UserId = auditLog.UserId;
            return result;
        }
    }

}

