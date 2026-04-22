using EView360Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly CoreContext context;
        private GenericRepository<AppUser> appUserRepository;
        private GenericRepository<AuditLog> auditLogRepository;
        private GenericRepository<ReportSchedule> reportScheduleRepository;
        private GenericRepository<ReportGenerationSchedule> reportScheduleGenerationRepository;
        private GenericRepository<ReportTask> reportTaskRepository;
        private GenericRepository<AuditLogDetail> auditLogDetailRepository;


        public UnitOfWork(CoreContext context)
        {
            this.context = context;
        }

        public GenericRepository<AppUser> AppUserRepository
        {
            get
            {

                if (this.appUserRepository == null)
                {
                    this.appUserRepository = new GenericRepository<AppUser>(context);
                }
                return appUserRepository;
            }
        }

        public GenericRepository<AuditLog> AuditLogRepository
        {
            get
            {

                if (this.auditLogRepository == null)
                {
                    this.auditLogRepository = new GenericRepository<AuditLog>(context);
                }
                return auditLogRepository;
            }
        }
        public GenericRepository<AuditLogDetail> AuditLogDetailRepository
        {
            get
            {

                if (this.auditLogDetailRepository == null)
                {
                    this.auditLogDetailRepository = new GenericRepository<AuditLogDetail>(context);
                }
                return auditLogDetailRepository;
            }
        }
        public GenericRepository<ReportSchedule> ReportScheduleRepository
        {
            get
            {

                if (this.reportScheduleRepository == null)
                {
                    this.reportScheduleRepository = new GenericRepository<ReportSchedule>(context);
                }
                return reportScheduleRepository;
            }
        }
        
        public GenericRepository<ReportGenerationSchedule> ReportScheduleGenerationRepository
        {
            get
            {

                if (this.reportScheduleGenerationRepository == null)
                {
                    this.reportScheduleGenerationRepository = new GenericRepository<ReportGenerationSchedule>(context);
                }
                return reportScheduleGenerationRepository;
            }
        }
        
        public GenericRepository<ReportTask> ReportTaskRepository
        {
            get
            {

                if (this.reportTaskRepository == null)
                {
                    this.reportTaskRepository = new GenericRepository<ReportTask>(context);
                }
                return reportTaskRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
