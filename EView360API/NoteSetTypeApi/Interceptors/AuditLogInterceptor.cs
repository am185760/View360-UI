using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using EView360Models.Core;
using Common.ViewModel;

namespace NoteSetTypeApi.Interceptors
{
    public class AuditLogInterceptor : SaveChangesInterceptor
    {
        public static AuditLogViewModel? auditData { get; set; }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;
            if (dbContext == null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);


            IEnumerable<EntityEntry<NoteSetType>> entries = dbContext.ChangeTracker.Entries<NoteSetType>();
            
            foreach (EntityEntry<NoteSetType> entityEntry in entries.ToList())
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

            //OnBeforeSaveChanges(dbContext);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
