using Blazorise;
using DataRequestorMiddleware.Services.Summary;
using EView360.Data;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace EView360.Services.Summary
{
    public class BnaStatusService
    {
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private INotificationService _notificationService;
        private BnaAtmStatusService _service { get; set; }
        public BnaStatusService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, INotificationService notificationService, BnaAtmStatusService service)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _notificationService = notificationService;
            _service = service;
        }


        public async Task<(bool isSucess, List<string>? atmTitles, int totalNotesDepositMachines)> GetBnaTransactingATMTitle()
        {
            List<string>? atmTitles = new();
            int totalNotesDepositMachines = 0;
            string errorMsg = string.Empty;
            try
            {
                string filter = string.Empty;
                List<string> atmIDs = new();
                List<string> regionIDs = new();

                List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
                (atmIDs, regionIDs) = await _atmTreeService.GetSelectedAtmOrRegionList();

                if (regionIDs?.Count > 0)
                {
                    filter = " and atm.region_id in " + "(" + string.Join(",", regionIDs) + ")";
                }
                else
                {
                    filter = " and atm.atm_id in " + "(" + string.Join(",", atmIDs) + ")";
                }

                if (selectedAtmIds?.Count > 0)
                {
                    totalNotesDepositMachines = _atmTreeService.AtmList.Where(x => selectedAtmIds?.Contains(x.AtmId) == true && x.IsCdm.HasValue && x.IsCdm.Value).Count();

                    _logger.LogWarning($"BnaStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetBNATransactingATMTitle  : {DateTime.Now.ToString()}");
                    atmTitles = _service.GetBNATransactingATMTitle(UserId, selectedAtmIds.ConvertAll(x => x.ToString()), filter, ref errorMsg);
                    _logger.LogWarning($"BnaStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from GetBNATransactingATMTitle  : {DateTime.Now.ToString()}");

                    
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        await _notificationService.Error(errorMsg, "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        _logger.LogError($"Error at Summary, BnaStatus: {errorMsg}");
                    }
                    return (isSucess: true, atmTitles, totalNotesDepositMachines);
                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });

                _logger.LogError($"Exception at GetBnaTransactingATMTitle as: {ex.Message}");
            }
            return (isSucess: false, atmTitles, totalNotesDepositMachines);
        }
    }
}
