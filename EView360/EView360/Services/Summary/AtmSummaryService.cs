using Blazorise;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Summary;
using EView360.Data;
using EView360.Pages.Summary;
using EView360.Services.Operations;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Text;

namespace EView360.Services.Summary
{
    public class AtmSummaryService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        string? BaseURL;
        private ILogger _logger { get; set; }

        private INotificationService _notificationService;
        private Top10AtmServiceMw serviceMw;

        private AtmService atmService;
        public AtmSummaryService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, AtmService atmService, Top10AtmServiceMw serviceMw)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Summary}AtmStatus/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.serviceMw = serviceMw;
        }

        public async Task<List<Top10AtmViewModel>> GetTop10TransactionAtms()
        {
            List<Top10AtmViewModel> Top10Atms = new();
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                if (!selectAtmResponse.IsSuccess)
                {
                    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                    if (selectedAtmIds?.Count > 0)
                    {
                        var SelectedAtmIds = selectedAtmIds;
                        //var jsonContent = JsonConvert.SerializeObject(SelectedAtmIds);
                        //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        //HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetTop10TransactionAtms", content);
                        //string responseBody = await response.Content.ReadAsStringAsync();
                        //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                        //{

                        //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                        var responseModel = serviceMw.GetTop10TransactionAtms(SelectedAtmIds);
                        if (responseModel.IsSuccess)
                            {
                                Top10Atms = (List<Top10AtmViewModel>)responseModel.Data;
                            }
                            else
                            {
                                if (responseModel.Data != null)
                                {
                                    Top10Atms = (List<Top10AtmViewModel>)responseModel.Data;
                                }

                                await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                                {
                                    options.IntervalBeforeClose = 4000;
                                });
                                return Top10Atms;
                            }

                        //}
                        //else
                        //{
                        //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                        //    {
                        //        options.IntervalBeforeClose = 4000;
                        //    });

                        //    _logger.LogError($"API error at AtmSummaryService, GetTop10TransactionAtms: {responseBody}");
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });

                _logger.LogError($"Exception at GetTop10TransactionAtms as: {ex.Message}");
            }
            return Top10Atms;
        }
        public async Task<List<Top10AtmViewModel>> GetTop10LowTransactionAtms()
        {
            List<Top10AtmViewModel> Top10Atms = new();
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                if (!selectAtmResponse.IsSuccess)
                {
                    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                    if (selectedAtmIds?.Count > 0)
                    {
                        var SelectedAtmIds = selectedAtmIds;
                        //var jsonContent = JsonConvert.SerializeObject(SelectedAtmIds);
                        //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        //HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetTop10LowTransactionAtms", content);
                        //string responseBody = await response.Content.ReadAsStringAsync();
                        //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                        //{

                            //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                            var responseModel = serviceMw.GetTop10LowTransactionAtms(SelectedAtmIds);
                            if (responseModel.IsSuccess)
                            {
                                Top10Atms = (List<Top10AtmViewModel>)responseModel.Data;
                            }
                            else
                            {
                                if (responseModel.Data != null)
                                {
                                    Top10Atms = (List<Top10AtmViewModel>)responseModel.Data; ;
                                }

                                await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                                {
                                    options.IntervalBeforeClose = 4000;
                                });
                                return Top10Atms;
                            }

                        //}
                        //else
                        //{
                        //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                        //    {
                        //        options.IntervalBeforeClose = 4000;
                        //    });

                        //    _logger.LogError($"API error at GetTop10LowTransactionAtms, GetTop10Atms: {responseBody}");
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                _logger.LogError($"Exception at GetTop10LowTransactionAtms as: {ex.Message}");
            }
            return Top10Atms;
        }

    }
}
