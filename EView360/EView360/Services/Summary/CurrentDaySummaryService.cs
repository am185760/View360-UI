using Blazorise;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Summary;
using EView360.Data;
using EView360.Services.Operations;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Text;

namespace EView360.Services.Summary
{
    public class CurrentDaySummaryService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        string? BaseURL;
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private AtmService atmService;
        private CurrentDaySummaryServiceMW service { get; set; }
        private ATMTreeViewRepository treeService;

        public CurrentDaySummaryService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<CurrentDaySummaryService> logger, INotificationService notificationService, AtmService atmService, CurrentDaySummaryServiceMW service, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Summary}CurrentDaySummary/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.service = service;
            this.treeService = treeService;
        }

        public async Task<List<CurrentDaySummaryViewModel>> GetCurrentDaySummary(long userId)
        {
            List<CurrentDaySummaryViewModel> CurrentDaySummary = new();
            try
            {
                //var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });
                //}
                //else
                //{
                //    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //    if (selectedAtmIds?.Count > 0)
                //    {
                //        var SelectedAtmIds = selectedAtmIds;
                //var jsonContent = JsonConvert.SerializeObject(SelectedAtmIds);
                //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetCurrentDaySummary", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                (var selectedAtmIds, var selectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                _logger.LogWarning("[CurrentDaySummaryService:GetCurrentDaySummary] going in GetCurrentDaySummary middleware service");
                var responseModel = service.GetCurrentDaySummary(selectedAtmIds, selectedRegionIds, userId);
                _logger.LogWarning("[CurrentDaySummaryService:GetCurrentDaySummary] returning from GetCurrentDaySummary middleware service");
                if (responseModel.IsSuccess)
                {
                    CurrentDaySummary = (List<CurrentDaySummaryViewModel>)responseModel.Data;
                }
                else
                {


                    if (responseModel.Data != null)
                    {
                        CurrentDaySummary = (List<CurrentDaySummaryViewModel>)responseModel.Data;
                    }

                    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                    _logger.LogError($"API error at GetCurrentDaySummary, GetCurrentDaySummary: {responseModel.Message}");

                    return CurrentDaySummary;
                }


                //if (responseModel.IsSuccess && (CurrentDaySummary is null || CurrentDaySummary.Count == 0))
                //{
                //    await _notificationService.Success("No record found", "Succes", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });
                //}
                //}
                //else
                //{
                //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });

                //    _logger.LogError($"API error at GetCurrentDaySummary, GetCurrentDaySummary: {responseBody}");
                //}
                //}

                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCurrentDaySummary as: {ex.Message}");
            }
            return CurrentDaySummary;
        }

        public async Task<List<DetailedCurrentDaySummaryViewModel>> GetDetailedCurrentDaySummary(string alertType, long userId)
        {
            List<DetailedCurrentDaySummaryViewModel> DetailedCurrentDaySummary = new();
            try
            {
                //var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });
                //}
                //else
                //{
                //    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //    if (selectedAtmIds?.Count > 0)
                //    {
                //        var SelectedAtmIds = selectedAtmIds;
                //var jsonContent = JsonConvert.SerializeObject(SelectedAtmIds);
                //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetDetailedCurrentDaySummary?alertType={alertType}", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                (var selectedAtmIds, var selectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
               
                _logger.LogWarning("[CurrentDaySummaryService:GetDetailedCurrentDaySummary] going in GetDetailedCurrentDaySummary middleware service");
                var responseModel = service.GetDetailedCurrentDaySummary(alertType, selectedAtmIds, selectedRegionIds, userId);
                _logger.LogWarning("[CurrentDaySummaryService:GetDetailedCurrentDaySummary] returning from GetDetailedCurrentDaySummary middleware service");
                if (responseModel.IsSuccess)
                {
                    DetailedCurrentDaySummary = (List<DetailedCurrentDaySummaryViewModel>)responseModel.Data;
                }
                else
                {
                    DetailedCurrentDaySummary = (List<DetailedCurrentDaySummaryViewModel>)responseModel.Data;

                    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                    _logger.LogError($"Exception at GetCurrentDaySummary as: {responseModel.Data}");

                    return DetailedCurrentDaySummary;
                }


                if (responseModel.IsSuccess && (DetailedCurrentDaySummary is null || DetailedCurrentDaySummary.Count == 0))
                {
                    await _notificationService.Success("No record found", "Succes", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                //}
                //else
                //{
                //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });

                //    _logger.LogError($"API error at GetCurrentDaySummary, GetCurrentDaySummary: {responseBody}");
                //}
                //    }

                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCurrentDaySummary as: {ex.Message}");
                await _notificationService.Error($"{ex.Message}", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return DetailedCurrentDaySummary;
        }
    }
}
