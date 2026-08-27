using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using EView360Models.Core;
using Common.ViewModel;
using Microsoft.EntityFrameworkCore.Storage;

namespace AtmSetupApi.Interceptors
{
    public class AuditLogInterceptor : SaveChangesInterceptor
    {
        public static AuditLogViewModel? auditData { get; set; }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;
            if (dbContext == null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);


            //Auditing for changes in table: ATM
            IEnumerable<EntityEntry<Atm>> atmEntries = dbContext.ChangeTracker.Entries<Atm>();
            AuditLog auditLogEntry = new();

            foreach (EntityEntry<Atm> entityEntry in atmEntries.ToList())
            {
                switch (entityEntry.State)
                {
                    //for ATM deletion 
                    case EntityState.Deleted:
                    //no break, same as case for added

                    //for ATM creation
                    case EntityState.Added:
                        auditLogEntry = new AuditLog()
                        {
                            ActivityTime = DateTime.Now,
                            Message = auditData.Message,
                            RightId = auditData.RightId,
                            UserId = auditData.UserId,
                        };

                        dbContext.Add(auditLogEntry);
                        break;

                    //for ATM updation
                    case EntityState.Modified:

                        auditLogEntry = new AuditLog()
                        {
                            ActivityTime = DateTime.Now,
                            RightId = auditData.RightId,
                            UserId = auditData.UserId,
                            Message = auditData.Message,
                        };

                        dbContext.Add(auditLogEntry);

                        //temporarily change Atm table state to unchange to avoid saving its changes now and save changes other than Atm entries
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

        //tracker for all tables in Core database
        private void OnBeforeSaveChanges(DbContext? dbContext)
        {
            dbContext.ChangeTracker.DetectChanges();
            var auditLogEntry = new AuditLog();
            string auditMessage = string.Empty;


            foreach (var entry in dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                auditMessage += $"{entry.Entity.GetType().Name} ["; //TableName

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    string? newValue = property.CurrentValue == null ? string.Empty : property.CurrentValue.ToString();
                    string? oldValue = property.OriginalValue == null ? string.Empty : property.OriginalValue.ToString();

                    if (property.Metadata.IsPrimaryKey())
                    {
                        //auditEntry.NewValue = property.CurrentValue == null ? string.Empty : property.CurrentValue.ToString();
                        continue;
                    }


                    switch (entry.State)
                    {


                        case EntityState.Added:

                            break;

                        case EntityState.Deleted:

                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                if (!oldValue.Equals(newValue))
                                    auditMessage += $"{propertyName} {{ {oldValue}, {newValue} }}, ";

                            }
                            break;
                    }
                }

                auditMessage += "]";
            }

            if (auditLogEntry.UserId != 0)
                dbContext.Add(auditLogEntry);
        }


        //public static async void CustomSavingChangesAsync(CoreContext dbContext, AuditLogViewModel audit)
        //{
        //    auditData = audit;
        //    await dbContext.SaveChangesAsync();
        //}
    }
}
