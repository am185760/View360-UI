using Blazorise;
using DataRequestor;
using DataRequestorMiddleware.Services.Admin;
using DataRequestorMiddleware.Services.Operations;
using EView360.Common;
using EView360.Data;
using EView360.Pages.Operations;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;
using static EView360.Common.Constants;

namespace EView360.Services.Operations.DashBoard
{
    public class AtmTaskDashboardService
    {
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private TaskService _taskService { get; set; }
        public AtmTaskDashboardService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, TaskService taskService)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _taskService = taskService;
        }

        public void GetAtmTaskDashboard(bool isRegionSelected, string noteSetTypeId,  Executor executor,string? values = null, string? archiveYear = null)
        {
            try
            {
                List<long>? selectedAtmIds = new();
                if (isRegionSelected)
                {
                    string a = string.Empty, b = string.Empty;
                    _atmTreeService.GetAtmAndRegionList(ref a, ref b);
                    //atm =   1,2,3,4
                    //region= 1,2,3,4
                    List<long> regionIds = values.Replace("(","").Replace(")", "").Split(',').ToList().ConvertAll(long.Parse);
                    selectedAtmIds = _atmTreeService.AtmList.Where(x => regionIds.Any(y => x.RegionId == y)).Select(z => z.AtmId).ToList();
                }
                else
                {
                    selectedAtmIds = new List<long> { long.Parse(values.Replace("(", "").Replace(")", "")) };
                }
                string errorMsg = string.Empty;

                if (selectedAtmIds?.Count > 0)
                {
                    _logger.LogWarning($"AtmTaskDashboardService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetAtmTaskDashboard  : {DateTime.Now.ToString()}");
                    _taskService.GetAtmTaskDashboard(noteSetTypeId ?? "", "", selectedAtmIds.ConvertAll(x => x.ToString()), executor, archiveYear);                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmTaskDashboard as: {ex.Message}");
            }
        }
    }
}
