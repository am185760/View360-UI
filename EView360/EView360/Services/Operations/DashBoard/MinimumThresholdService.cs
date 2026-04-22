using Blazorise;
using Common.ViewModel;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Data;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Text;

namespace EView360.Services.Operations.DashBoard
{
    public class MinimumThresholdService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        string? BaseURL;
        private ILogger _logger { get; set; }
        private MinimumThresholdServiceMw serviceMw { get; set; }
        private ATMTreeViewRepository treeService;
        private INotificationService _notificationService;

        private AtmService atmService;
        public MinimumThresholdService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, AtmService atmService, MinimumThresholdServiceMw serviceMw, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            //BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Dashboard}MinimumThreshold/").ToString();
            //client.BaseAddress = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.MinimumThresholdDashboard}MinimumThreshold/");
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.serviceMw = serviceMw;
            this.treeService = treeService;
        }

        public async Task GetMinimumThresholdDashboard(string values, long UserId, bool isRegionSelected, Executor executor)
        {
            List<MinimumThresholdViewModel> MinimumThresholds = new();
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
                List<string> RegionIds = new List<string>();
                List<string> selectedAtms = new List<string>();
                if (isRegionSelected)
                {
                    string a = string.Empty, b = string.Empty;
                    treeService.GetAtmAndRegionList(ref a, ref b);
                    RegionIds = values.Replace("(", "").Replace(")", "").Split(',').ToList();
                    List<long> regionIds = values.Replace("(", "").Replace(")", "").Split(',').ToList().ConvertAll(long.Parse);
                    selectedAtms = treeService.AtmList.Where(x => regionIds.Any(y => x.RegionId == y)).Select(z => z.AtmId).ToList().ConvertAll(x => x.ToString());
                }
                else
                {
                    selectedAtms = new List<string> { values.Replace("(", "").Replace(")", "") };
                }
                if (selectedAtms?.Count > 0)
                {
                    //var SelectedAtmIds = selectedAtmIds;
                    //var SelectedAtmIds = selectedAtms;
                    //var jsonContent = JsonConvert.SerializeObject(SelectedAtmIds);
                    //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = await client.PostAsync($"{BaseURL}MinimumThresholdDashboard", content);
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    //{

                    //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);

                    _logger.LogWarning("[MinimumThresholdService:GetMinimumThresholdDashboard] going in GetMinimumThreshold middleware service");
                    await serviceMw.GetMinimumThreshold(selectedAtms, UserId, RegionIds, executor);
                    _logger.LogWarning("[MinimumThresholdService:GetMinimumThresholdDashboard]  return from GetMinimumThreshold middleware service");

                    //if (responseModel.IsSuccess)
                    //{
                    //    MinimumThresholds = (List<MinimumThresholdViewModel>)responseModel.Data;
                    //}
                    //else
                    //{


                    //    if (responseModel.Data != null)
                    //    {
                    //        MinimumThresholds = (List<MinimumThresholdViewModel>)responseModel.Data;
                    //    }

                    //    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at GetMinimumThresholdDashboardService, GetMinimumThresholdDashboard: {responseModel.Message}");

                    //    return MinimumThresholds;
                    //}


                    //if (responseModel.IsSuccess && (MinimumThresholds is null || MinimumThresholds.Count == 0))
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

                    //    _logger.LogError($"API error at GetMinimumThresholdDashboardService, GetMinimumThresholdDashboard: {responseBody}");
                    //}
                    //}

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetMinimumThresholdDashboard as: {ex.Message}");
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                            {
                                options.IntervalBeforeClose = 4000;
                            });
            }
            //return MinimumThresholds;
        }

    }
}
