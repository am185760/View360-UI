using EView360Models.RequestModel;
using EView360Models.ViewModels;

namespace EView360Models.ServiceInterface
{
    public interface IAuditLogService
    {
        Task<BaseModel> GetAll(DateTime fromDate, DateTime toDate, int? rightId, int userId, bool isReport, string search = null);
       
        Task<BaseModel> Create(BuildAuditLogViewModel buildAuditLogViewModel);
    }
}