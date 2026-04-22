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
    public class AtmStatusService
    {
        public long UserId { get; set; }
        public int totalAtms { get; set; }
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private INotificationService _notificationService;
        private AtmSummaryStatusService _service { get; set; }
        public AtmStatusService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, INotificationService notificationService, AtmSummaryStatusService service)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _notificationService = notificationService;
            _service = service;
        }

        //public async Task<List<AtmAlertViewModel>> GetAtmAlertsAsync()
        //{
        //    List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
        //    List<AtmAlertViewModel> atmAlerts = new();
        //    try
        //    {               

        //        if (selectedAtmIds?.Count > 0)
        //        {
        //            HttpContent content = new StringContent(JsonConvert.SerializeObject(selectedAtmIds.ConvertAll(x => x.ToString())), Encoding.UTF8, "application/json");
        //            _logger.LogWarning($"AtmStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in {BaseUrl}  : {DateTime.Now.ToString()}");
        //            HttpResponseMessage response = await client.PostAsync(BaseUrl, content);
        //            _logger.LogWarning($"AtmStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from {BaseUrl}  : {DateTime.Now.ToString()}");
                    
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
        //            {
        //                atmAlerts = JsonConvert.DeserializeObject<List<AtmAlertViewModel>>(responseBody);
        //            }
        //            else
        //            {
        //                _logger.LogError($"API error at Summary, AtmStatus: {responseBody}");
        //            }
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exception at GetAtmAlertsAsync: {ex.Message}");
        //    }

        //    return atmAlerts;
        //}

        public async Task<(bool isSucess, List<string>? atmTitles, long TrnxCountToday, long TrnxCountYesterday)> GetTransactingATMTitle()
        {
            _logger.LogWarning($"AtmStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} enter  : {DateTime.Now.ToString()}");

            List<string>? atmTitles = new();
            long trnxCountToday = 0;
            long trnxCountYesterday = 0;
            totalAtms = 0;
            string errorMsg = string.Empty;

            try
            {
                string filter = string.Empty;
                List<string> atmIDs = new();
                List<string> regionIDs = new();

                List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
                (atmIDs, regionIDs) = await _atmTreeService.GetSelectedAtmOrRegionList();

                filter = " and ua.user_id = " + UserId;

                if (regionIDs?.Count > 0)
                {
                    filter += " and atm.region_id in " + "(" + string.Join(",", regionIDs) + ")";
                }
                else
                {
                    filter += " and atm.atm_id in " + "(" + string.Join(",", atmIDs) + ")";
                }

                if (selectedAtmIds?.Count > 0)
                {

                    AtmSummaryStatusModel model = _service.GetTransactingATMTitle(selectedAtmIds.ConvertAll(x => x.ToString()), filter, ref errorMsg);
                    if (model != null) 
                    {
                        atmTitles = model.atmTiles;
                        trnxCountToday = model.trnx_count_today;
                        trnxCountYesterday = model.trnx_count_yesterday;
                    }

                    totalAtms = selectedAtmIds.Count();
                    if (!string.IsNullOrEmpty(errorMsg.Trim()))
                    {
                        await _notificationService.Error(errorMsg, "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        _logger.LogError($"Error at Summary, GetTransactingATMTitle: {errorMsg}");
                    }

                    _logger.LogWarning($"AtmStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} exit  : {DateTime.Now.ToString()}");
                    return (isSucess: true, atmTitles, trnxCountToday, trnxCountYesterday);
                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
                _logger.LogError($"Exception at GetTransactingATMTitle as: {ex.Message}");
            }

            _logger.LogWarning($"AtmStatusService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} exit  : {DateTime.Now.ToString()}");
            return (isSucess: false, atmTitles, trnxCountToday, trnxCountYesterday);
        }
    }
}
