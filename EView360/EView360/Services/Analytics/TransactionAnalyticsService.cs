using Blazorise;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Analytics;
using EView360.Data;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace EView360.Services.Analytics
{
    public class TransactionAnalyticsService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        public int totalAtms { get; set; }
        private ILogger _logger { get; set; }
        private AtmService _atmService { get; set; }
        private List<string>? AtmList { get; set; }
        private static string? BaseUrl { get; set; }
        private INotificationService _notificationService;
        private TransactionAnalyticsServiceMw serviceMw;
        private ATMTreeViewRepository treeService;
        public TransactionAnalyticsService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger, AtmService atmService, INotificationService notificationService, TransactionAnalyticsServiceMw serviceMw = null, ATMTreeViewRepository treeService = null)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Analytics}TransactionAnalytics/GetAtmTransactionDetail").ToString();
            _logger = logger;
            _atmService = atmService;
            _notificationService = notificationService;
            this.serviceMw = serviceMw;
            this.treeService = treeService;
        }


        public async Task<List<TransactionAnalyticsViewModel>> GetTransactiomAnalytics(DateTime fromDate, DateTime toDate)
        {
            List<TransactionAnalyticsViewModel> transaction = new();
            //try
            //{
            //    var selectAtmResponse = _atmService.GetMultipleSelectedAtms();
            //    if (selectAtmResponse.IsSuccess)
            //    {
            //        AtmList = (List<string>)selectAtmResponse.Data;
            //    }

            //    if (AtmList?.Count > 0)
            //    {
            //        var jsonContent = JsonConvert.SerializeObject(AtmList);
            //        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //        HttpResponseMessage response = await client.PostAsync($"{BaseUrl}?fromDate={fromDate}&toDate={toDate}", content);
            //        string responseBody = await response.Content.ReadAsStringAsync();
            //        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
            //        {
            //            dynamic dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(responseBody)!;
            //            if (dynamicObject is not null)
            //            {
            //                string cashJson = JsonConvert.SerializeObject(dynamicObject.CashUtilizations);
            //                transaction = JsonConvert.DeserializeObject<List<TransactionAnalyticsViewModel>>(cashJson);

            //                string errorMsg = dynamicObject.ErrorMsg;
            //                if (!string.IsNullOrEmpty(errorMsg))
            //                {
            //                    await _notificationService.Error(errorMsg, "Error", (options) =>
            //                    {
            //                        options.IntervalBeforeClose = 4000;
            //                    });
            //                }
            //            }

            //            return (isSucess: true, transaction);
            //        }
            //        else
            //        {
            //            _logger.LogError($"API error at Task, GetAtmUtilizationDetail: {responseBody}");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Exception at GetCashUtilization as: {ex.Message}");
            //}
            //return (isSucess: false, transaction);


            //List<BnaTransactionDashboardViewModel> bnaTransaction = new();
            try
            {
                //var selectAtmResponse = await _atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });
                //}
                //else
                //{
                //List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                List<string> atmIds = new List<string>();   
                List<string> regionIds = new List<string>();
                (atmIds, regionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (atmIds?.Count > 0)
                    {
                        //bNATransactionRequestModel.SelectedAtmIds = selectedAtmIds;
                        //var jsonContent = JsonConvert.SerializeObject(bNATransactionRequestModel);
                        //var jsonContent = JsonConvert.SerializeObject(selectedAtmIds);
                        //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}?fromDate={fromDate}&toDate={toDate}", content);
                        //string responseBody = await response.Content.ReadAsStringAsync();
                        //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                        //{

                        var responseModel = await serviceMw.GetAtmTransactionDetail(fromDate, toDate, atmIds, regionIds);
                            if (responseModel.IsSuccess)
                            {
                                transaction = (List<TransactionAnalyticsViewModel>)responseModel.Data;
                            }
                            else
                            {
                                if (responseModel.Data != null)
                                {
                                    transaction = (List<TransactionAnalyticsViewModel>)responseModel.Data;
                                }


                                await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                                {
                                    options.IntervalBeforeClose = 4000;
                                });
                            _logger.LogError($"Exception at GetTransactiomAnalytics as: {responseModel.Message}");
                            return transaction;
                            }


                        //}
                        //else
                        //{
                        //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                        //    {
                        //        options.IntervalBeforeClose = 4000;
                        //    });

                        //    _logger.LogError($"API error at TransactionAnalyticsService, GetTransactiomAnalytics: {responseBody}");
                        //}
                    //}

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetTransactiomAnalytics as: {ex.Message}");
            }
            return transaction;
        }

    }
}
