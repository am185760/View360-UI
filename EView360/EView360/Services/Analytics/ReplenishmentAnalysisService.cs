using Blazorise;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Analytics;
using EView360.Data;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace EView360.Services.Analytics
{
    public class ReplenishmentAnalysisService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        public int totalAtms { get; set; }
        private ILogger _logger { get; set; }
        private AtmService _atmService { get; set; }
        private List<string>? AtmList { get; set; }
        private List<string>? RegionList { get; set; }
        private static string? BaseUrl { get; set; }
        private ReplenishmentAnalysisServiceMW service { get; set; }
        private INotificationService _notificationService;
        private ATMTreeViewRepository treeService;

        public ReplenishmentAnalysisService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ReplenishmentAnalysisService> logger, AtmService atmService, INotificationService notificationService, ReplenishmentAnalysisServiceMW service, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Analytics}ReplenishmentAnalysis/").ToString();
            _logger = logger;
            _atmService = atmService;
            _notificationService = notificationService;
            this.service = service;
            this.treeService = treeService;
        }


        public async Task<ReplenishmentAnalysisResponseViewModel> GetReplenishmentAnalysis(DateTime fromDate, DateTime toDate, long userId)
        {
            ReplenishmentAnalysisResponseViewModel responseWrapper = new();
            List<ReplenishmentAnalysisViewModel>? Replenishments = new();
            try
            {
                //var selectAtmResponse = await _atmService.GetMultipleSelectedAtms();
                //if (selectAtmResponse.IsSuccess)
                //{
                //    AtmList = (List<string>)selectAtmResponse.Data;
                //}

                //if (AtmList?.Count > 0)
                //{
                //var jsonContent = JsonConvert.SerializeObject(AtmList);
                //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetReplenishmentAnalysis?fromDate={fromDate}&toDate={toDate}", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                //dynamic dynamicObject = service.GetReplenishmentAnalysis(fromDate, toDate, AtmList, ref errorMsg); // JsonConvert.DeserializeObject<ExpandoObject>(responseBody)!;
                //    if (dynamicObject is not null)
                //    {
                //        string replenishmentJson = JsonConvert.SerializeObject(dynamicObject.Replenishments);
                (AtmList, RegionList) = await treeService.GetSelectedAtmOrRegionList();

                string errorMsg = string.Empty;
                _logger.LogWarning($"[ReplenishmentAnalysisService:GetReplenishmentAnalysis] going in GetReplenishmentAnalysis middleware service for {fromDate.Date.ToString()} - {toDate.Date.ToString()}");
                Replenishments = service.GetReplenishmentAnalysis(fromDate, toDate, AtmList, RegionList, userId, ref errorMsg);
                _logger.LogWarning($"[ReplenishmentAnalysisService:GetReplenishmentAnalysis] returning from GetReplenishmentAnalysis middleware service for {fromDate.Date.ToString()} - {toDate.Date.ToString()}");

                //errorMsg = dynamicObject.ErrorMsg;
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    _logger.LogError($"API error at ReplenishmentAnalysis, GetReplenishmentAnalysis: {errorMsg}");
                    await _notificationService.Error(errorMsg, "Error", (options) =>
                            {
                                options.IntervalBeforeClose = 4000;
                            });
                }
                //}

                responseWrapper.ReplenishmentViews = Replenishments;
                responseWrapper.IsSucess = true;
                return responseWrapper;
                //}
                //else
                //{
                //_logger.LogError($"API error at ReplenishmentAnalysis, GetReplenishmentAnalysis: {responseBody}");
                //await _notificationService.Error(errorMsg, "Error", (options) =>
                //{
                //    options.IntervalBeforeClose = 4000;
                //});
                //}
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReplenishmentAnalysis as: {ex.Message}");
                await _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            responseWrapper.ReplenishmentViews = Replenishments;
            responseWrapper.IsSucess = false;
            return responseWrapper;
        }

        public async Task<ReplenishmentAnalysisResponseViewModel> GetReplenishmentDatagrid(DateTime fromDate, DateTime toDate, long userId)
        {
            ReplenishmentAnalysisResponseViewModel responseWrapper = new();
            List<ReplenishmentAnalysisViewModel>? Replenishments = new();
            try
            {
                //var selectAtmResponse = await _atmService.GetMultipleSelectedAtms();
                //if (selectAtmResponse.IsSuccess)
                //{
                //    AtmList = (List<string>)selectAtmResponse.Data;
                //}

                //if (AtmList?.Count > 0)
                //{
                //var jsonContent = JsonConvert.SerializeObject(AtmList);
                //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetReplenishmentDatagrid?fromDate={fromDate}&toDate={toDate}", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                //    dynamic dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(responseBody)!;
                //    if (dynamicObject is not null)
                //    {
                //        string replenishmentJson = JsonConvert.SerializeObject(dynamicObject.Replenishments);
                (AtmList, RegionList) = await treeService.GetSelectedAtmOrRegionList();

                string errorMsg = string.Empty;
                _logger.LogWarning("[ReplenishmentAnalysisService:GetReplenishmentDatagrid] going in GetReplenishmentDatagrid middleware service");
                Replenishments = service.GetReplenishmentDatagrid(fromDate, toDate, AtmList, RegionList, userId, ref errorMsg);
                _logger.LogWarning("[ReplenishmentAnalysisService:GetReplenishmentDatagrid] returning from GetReplenishmentDatagrid middleware service");

                //string errorMsg = dynamicObject.ErrorMsg;
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    _logger.LogError($"API error at ReplenishmentAnalysis, GetReplenishmentDatagrid: {errorMsg}");

                    await _notificationService.Error(errorMsg, "Error", (options) =>
                            {
                                options.IntervalBeforeClose = 4000;
                            });
                }
                //    }
                responseWrapper.ReplenishmentViews = Replenishments;
                responseWrapper.IsSucess = true;
                return responseWrapper;
                //}
                //else
                //{
                //    _logger.LogError($"API error at ReplenishmentAnalysis, GetReplenishmentDatagrid: {responseBody}");
                //}
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReplenishmentDatagrid as: {ex.Message}");
                await _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            responseWrapper.ReplenishmentViews = Replenishments;
            responseWrapper.IsSucess = false;
            return responseWrapper;
        }
    }
}
