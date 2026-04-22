using Blazorise;
using DataRequestor;
using DataRequestorMiddleware.Services.Admin;
using DataRequestorMiddleware.Services.Operations;
using EView360.Data;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace EView360.Services.Operations
{
    public class BnaTranactionsService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }

        private INotificationService _notificationService;

        private ATMTreeViewRepository treeService;
        private BnaTransactionServiceMw service;
        private AtmService atmService;
        private readonly IConfiguration _configuration;

        private string? BaseURl;

        public List<Atm> userAtmList { get; set; }

        public BnaTranactionsService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, BnaTransactionServiceMw service = null, IConfiguration configuration = null)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}BNATransactions/").ToString();
            //client.BaseAddress = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}BNATransactions/");
            _logger = logger;
            _notificationService = notificationService;
            this.treeService = treeService;
            this.atmService = atmService;
            this.service = service;
            _configuration = configuration;
        }

        public async Task GetBNATransaction(BNATransactionRequestModel bNATransactionRequestModel,Executor executor)
        {
            List<BnaTransactionViewModel> bnaTransaction = new();
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
                //List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //List<string> selectedAtmIds =  treeService.GetSelectedAtmId().Result.ConvertAll(x => x.ToString()).ToList();
                (bNATransactionRequestModel.SelectedAtmIds, bNATransactionRequestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (bNATransactionRequestModel.SelectedAtmIds?.Count > 0)
                {
                    bNATransactionRequestModel.rowCount = _configuration.GetValue<int>("RecordPerPage");
                    bNATransactionRequestModel.UserId = UserId;
                    //var jsonContent = JsonConvert.SerializeObject(bNATransactionRequestModel);
                    //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = await client.PostAsync($"{BaseURl}BNATransactions", content);
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    //{

                    //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    _logger.LogWarning("[BnaTransactionsService:GetBNATransaction] going in GetBnaTransaction middleware service");
                     await service.GetBnaTransaction(bNATransactionRequestModel,executor);
                    _logger.LogWarning("[BnaTransactionsService:GetBNATransaction] return from GetBnaTransaction middleware service");

                    //if (responseModel.IsSuccess)
                    //{
                    //    bnaTransaction = (List<BnaTransactionViewModel>)responseModel.Data;
                    //}
                    //else
                    //{
                    //    if (responseModel.Data != null)
                    //    {
                    //        bnaTransaction = (List<BnaTransactionViewModel>)responseModel.Data;
                    //    }

                    //    if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                    //    {
                    //        _logger.LogError($"Exception at GetBNATransaction as: {responseModel.Message}");
                    //    }
                    //    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    return (bnaTransaction, responseModel.TotalRecords);
                    //}


                    //if (responseModel.IsSuccess && (bnaTransaction is null || bnaTransaction.Count == 0))
                    //{
                    //    await _notificationService.Success("No record found", "Succes", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //}

                    //return (bnaTransaction, responseModel.TotalRecords);
                    //}
                    //else
                    //{
                    //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at BNATransactionService, GetBNATransaction: {responseBody}");
                    //}
                    //}

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetBNATransaction as: {ex.Message}");
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });

            }
            //return (bnaTransaction, 0);
        }



        public async Task<List<BnaTransactionDashboardViewModel>> GetBNATransactionDashboard(BNADepositRequestModel bNATransactionRequestModel, string values, bool isRegionSelected, Executor executor)
        {
            List<BnaTransactionDashboardViewModel> bnaTransaction = new();
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


                if (isRegionSelected)
                {
                    string a = string.Empty, b = string.Empty;
                    treeService.GetAtmAndRegionList(ref a, ref b);
                    bNATransactionRequestModel.SelectedRegionIds = values.Replace("(", "").Replace(")", "").Split(',').ToList();
                    List<long> regionIds = values.Replace("(", "").Replace(")", "").Split(',').ToList().ConvertAll(long.Parse);
                    bNATransactionRequestModel.SelectedAtmIds = treeService.AtmList.Where(x => regionIds.Any(y => x.RegionId == y)).Select(z => z.AtmId).ToList().ConvertAll(x => x.ToString());
                }
                else
                {
                    bNATransactionRequestModel.SelectedAtmIds = new List<string> { values.Replace("(", "").Replace(")", "") };
                }
                //List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //    bNATransactionRequestModel.SelectedAtmIds = (await treeService.GetSelectedAtmId()).ConvertAll(x => x.ToString()).ToList();
                if (bNATransactionRequestModel.SelectedAtmIds.Count > 0)
                {
                    //bNATransactionRequestModel.SelectedAtmIds = selectedAtmIds;
                    //var jsonContent = JsonConvert.SerializeObject(bNATransactionRequestModel);
                    //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = await client.PostAsync($"{BaseURl}BNATransactionDashboard", content);
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    //{

                    //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    _logger.LogWarning("[BnaTranactionsService:GetBNATransactionDashboard] going in GetAtmBnaDeposit middleware service");
                     await service.GetAtmBnaDeposit(bNATransactionRequestModel,executor);
                    _logger.LogWarning("[BnaTranactionsService:GetBNATransactionDashboard] return from GetAtmBnaDeposit middleware service");

                    //if (responseModel.IsSuccess)
                    //{
                    //    //bnaTransaction = JsonConvert.DeserializeObject<List<BnaTransactionDashboardViewModel>>(responseModel.Data.ToString());
                    //    bnaTransaction = (List<BnaTransactionDashboardViewModel>)responseModel.Data;
                    //}
                    //else
                    //{
                    //    bnaTransaction = responseModel.Data == null ? new List<BnaTransactionDashboardViewModel>() : (List<BnaTransactionDashboardViewModel>)responseModel.Data; ;

                    //    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //    _logger.LogError($"Exception at BNATransactionService, GetBNATransactionDashboard: {responseModel.Message}");
                    //}


                    //if (responseModel.IsSuccess && (bnaTransaction is null || bnaTransaction.Count == 0))
                    //{
                    //    await _notificationService.Success("No record found", "Succes", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //}
                    //return bnaTransaction;
                    //}
                    //else
                    //{
                    //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at BNATransactionService, GetBNATransactionDashboard: {responseBody}");
                    //}
                    //}

                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
                _logger.LogError($"Exception at GetBNATransactionDashboard as: {ex.Message}");
            }
            return bnaTransaction;
        }

    }
}
