using EView360Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AuditLogDetailViewModel
    {
        public long AuditLogId { get; set; }
        public string? FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }


        public static explicit operator AuditLogDetail(AuditLogDetailViewModel auditLog)
        {
            if (auditLog == null)
            {
                return null;
            }

            AuditLogDetail result = new();
            result.AuditLogId = auditLog.AuditLogId;
            result.OldValue = auditLog.OldValue;
            result.NewValue = auditLog.NewValue;
            result.FieldName = auditLog.FieldName;
            return result;
        }

        public static explicit operator AuditLogDetailViewModel(AuditLogDetail auditLog)
        {
            if (auditLog == null)
            {
                return null;
            }

            AuditLogDetailViewModel result = new AuditLogDetailViewModel();
            result.AuditLogId = auditLog.AuditLogId;
            result.OldValue = auditLog.OldValue;
            result.NewValue = auditLog.NewValue;
            result.FieldName = auditLog.FieldName;
            return result;
        }

        //public static explicit operator AuditLogDetailViewModel(AuditLog v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
