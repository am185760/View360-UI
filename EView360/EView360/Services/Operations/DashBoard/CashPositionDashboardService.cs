using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Data;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace EView360.Services.Operations.DashBoard
{
    public class CashPositionDashboardService
    {
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private CashPositionsService _service { get; set; }
        public CashPositionDashboardService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, CashPositionsService service)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _service = service;
        }

        public void GetDashboardCashPosition(CashPositionFilter cashPositionFilter, Executor _executor)
        {
            try
            {
                List<long>? selectedAtmIds = new();
                string a = string.Empty, b = string.Empty;
                _atmTreeService.GetAtmAndRegionList(ref a, ref b);
                if (cashPositionFilter.isRegionSelected)
                {
                    List<long> regionIds = cashPositionFilter.Values.Replace("(", "").Replace(")", "").Split(',').ToList().ConvertAll(long.Parse);
                    selectedAtmIds = _atmTreeService.AtmList.Where(x => regionIds.Any(y => x.RegionId == y)).Select(z => z.AtmId).ToList();
                }
                else
                {
                    selectedAtmIds = new List<long> { long.Parse(cashPositionFilter.Values.Replace("(", "").Replace(")", "")) };
                }

                if (selectedAtmIds?.Count > 0)
                {
                    cashPositionFilter.AtmIds = selectedAtmIds.ConvertAll(x => x.ToString());

                    _logger.LogWarning($"CashPositionDashboardService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetDashboardCashPosition  : {DateTime.Now.ToString()}");
                    _service.GetDashboardCashPosition(cashPositionFilter, _executor);                   
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetDashboardCashPosition as: {ex.Message}");
            }
        }
    }
}
