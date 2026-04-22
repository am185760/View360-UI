using Blazorise;
using Common.RequestModel;
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
using System.Collections.Generic;
using System.Text;

namespace EView360.Services.Summary
{
    public class TodaysActivityService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        string? BaseURL;
        private ILogger _logger { get; set; }

        private INotificationService _notificationService;
        private TodaysActivityServiceMw serviceMw;

        private AtmService atmService;
        public TodaysActivityService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, AtmService atmService, TodaysActivityServiceMw serviceMw)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Summary}TodaysActivity/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.serviceMw = serviceMw;
        }

        public async Task<List<TodaysActivityViewModel>> GetTodaysActivity(TodaysActivityRequestModel requestModel)
        {
            BaseModel responseModel = new();
            List<TodaysActivityViewModel> TodaysActivitys = new();
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

                        //var SelectedAtmIds = selectedAtmIds;
                        requestModel.SelectedAtms = selectedAtmIds;
                        //var jsonContent = JsonConvert.SerializeObject(requestModel);
                        //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        //HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetTodaysActivity", content);
                        //string responseBody = await response.Content.ReadAsStringAsync();
                        //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                        //{

                        //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                         responseModel = serviceMw.GetTodaysActivity(requestModel);
                        if (responseModel.IsSuccess)
                        {
                            TodaysActivitys = (List<TodaysActivityViewModel>)responseModel.Data;
                        }
                        else
                        {
                            if (responseModel.Data != null)
                            {
                                TodaysActivitys = (List<TodaysActivityViewModel>)responseModel.Data;
                            }

                            await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                            {
                                options.IntervalBeforeClose = 4000;
                            });
                            return TodaysActivitys;
                        }

                        //}
                        //else
                        //{
                        //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                        //    {
                        //        options.IntervalBeforeClose = 4000;
                        //    });

                        //    _logger.LogError($"API error at GetTodaysActivity, reponseBody: {responseBody}");
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

                _logger.LogError($"Exception at GetTodaysActivity as: {ex.Message}");
            }

            if (TodaysActivitys.Count == 0 && string.IsNullOrEmpty(responseModel.Message))
            {
                await _notificationService.Success($"No record found.", "Succes", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return TodaysActivitys;
        }
    }
}
