namespace EView360Models.Core
{
    public class AuditLogDetail
    {
        public long AuditLogDetailId { get; set; }
        public long AuditLogId { get; set; }
        public string? FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
    }
}
