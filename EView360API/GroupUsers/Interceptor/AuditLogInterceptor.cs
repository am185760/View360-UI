using EView360Models.Core;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Common.ViewModel;

namespace GroupUsers.Interceptor
{
    public class AuditLogInterceptor
    {
        public long InsertActivity(DbContext dbContext, AuditLogViewModel auditData)
        {
            long pk = 0;
            IEnumerable<EntityEntry<Group>> entries = dbContext.ChangeTracker.Entries<Group>();

            foreach (EntityEntry<Group> entityEntry in entries.ToList())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Modified:

                        AuditLog auditLogEntry = new AuditLog()
                        {
                            ActivityTime = DateTime.Now,
                            RightId = auditData.RightId,
                            UserId = auditData.UserId,
                            Message = auditData.Message,
                        };

                        dbContext.Add(auditLogEntry);

                        entityEntry.State = EntityState.Unchanged;
                        dbContext.SaveChanges();
                        entityEntry.State = EntityState.Modified;

                        pk = auditLogEntry.AuditLogId;

                        foreach (var property in entityEntry.Metadata.GetProperties())
                        {
                            var newValue = entityEntry.Property(property.Name).CurrentValue == null ? string.Empty : entityEntry.Property(property.Name).CurrentValue.ToString();

                            var oldValue = entityEntry.GetDatabaseValues()?.GetValue<object>(property.Name) == null ? string.Empty : entityEntry.GetDatabaseValues()?.GetValue<object>(property.Name).ToString();

                            if (!oldValue.Equals(newValue))
                            {
                                AuditLogDetail auditLogDetail = new AuditLogDetail()
                                {
                                    AuditLogId = auditLogEntry.AuditLogId,
                                    FieldName = property.Name,
                                    OldValue = oldValue,
                                    NewValue = newValue
                                };

                                dbContext.Add(auditLogDetail);
                            }
                        }
                        break;
                }
            }
            dbContext.SaveChanges();
            return pk;
        }
    }
}
