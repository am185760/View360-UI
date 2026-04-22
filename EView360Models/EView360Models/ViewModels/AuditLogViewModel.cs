using EView360Models.Core;

namespace EView360Models.ViewModels
{
    public class AuditLogViewModel
    {
        public long AuditLogId { get; set; }

        public DateTime ActivityTime { get; set; }

        public string Message { get; set; } = null!;

        public long RightId { get; set; }

        public long  UserId { get; set; }

        public string? IpAddress { get; set; }

        public string UserLoginName { get; set; }

        public static explicit operator AuditLog(AuditLogViewModel auditLog)
        {
            if (auditLog == null)
            {
                return null;
            }

            AuditLog result = new();
            result.AuditLogId = auditLog.AuditLogId;
            result.RightId = auditLog.RightId;
            result.UserId = auditLog.UserId;
            result.ActivityTime = auditLog.ActivityTime;
            result.Message = auditLog.Message;
            return result;
        }

        public static explicit operator AuditLogViewModel(AuditLog auditLog)
        {
            if (auditLog == null)
            {
                return null;
            }

            AuditLogViewModel result = new AuditLogViewModel();
            result.AuditLogId = auditLog.AuditLogId;
            result.ActivityTime = auditLog.ActivityTime;
            result.Message = auditLog.Message;
            result.UserId = auditLog.UserId;
            return result;
        }
    }
}

