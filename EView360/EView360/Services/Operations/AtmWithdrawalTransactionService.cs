using EView360.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Blazorise;
using EView360.Common;
using EView360Models.Core;
using EView360Models.ViewModels;
using EView360Models.RequestModel;
using EView360.Pages.Operations;
using EView360.Pages.Audit_Log;
using System.Collections.Generic;
using DataRequestorMiddleware.Services.Operations;
using DataRequestor;

namespace EView360.Services.Operations
{
    public class AtmWithdrawalTransactionService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }

        private INotificationService _notificationService;

        private ATMTreeViewRepository treeService;

        private AtmService atmService;

        public List<Atm> userAtmList { get; set; }

        private string BaseURl;
        private WithdrawalTransactionService service;
        private readonly IConfiguration _configuration;
        private readonly CommonServices commonServices;
        private readonly ILogger<AtmWithdrawalTransactionService> logger;

        public AtmWithdrawalTransactionService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<AtmWithdrawalTransactionService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, WithdrawalTransactionService service, IConfiguration configuration, CommonServices commonServices)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            //client.BaseAddress = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}WithdrawalTransaction/");
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}WithdrawalTransaction/").ToString();
            this.treeService = treeService;
            this.atmService = atmService;
            this.service = service;
            this._configuration = configuration;
            this.commonServices = commonServices;
        }


        public async Task GetAtmWithdrawalTransaction(WithdrawalTransactionFilter withdrawalTransaction,Executor executor)
        {
            List<WithdrawalTransactionViewModel> atmWithdrawalTransaction = new();
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (withdrawalTransaction.indexId == 2 && !selectAtmResponse.IsSuccess)
                //{
                //    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                //   {
                //       options.IntervalBeforeClose = 4000;
                //   });
                //}
                //else
                //{
                //withdrawalTransaction.UserAtmIds = (List<string>)selectAtmResponse.Data;
                //withdrawalTransaction.UserAtmIds = (List<string>)selectAtmResponse.Data;
                withdrawalTransaction.rowCount = _configuration.GetValue<int>("RecordPerPage");

                (withdrawalTransaction.UserAtmIds, withdrawalTransaction.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (withdrawalTransaction.UserAtmIds?.Count > 0)
                {

                    //withdrawalTransaction.UserAtmIds = commonServices.ConverAtmtListToDataTable(selectedAtms).Copy();


                    //withdrawalTransaction.SelectedAtm = withdrawalTransaction.indexId == 2 ? selectAtmResponse.Data.ToString() : "";

                    //var jsonContent = JsonConvert.SerializeObject(withdrawalTransaction);
                    //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = await client.PutAsync($"{BaseURl}ATMTransactions", content);
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    //{

                    //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    _logger.LogWarning("[AtmWithdrawalTransactionService:GetAtmWithdrawalTransaction] going in GetATMTransactions middleware service");
                     await service.GetATMTransactions(withdrawalTransaction, executor);
                    _logger.LogWarning("[AtmWithdrawalTransactionService:GetAtmWithdrawalTransaction] return from GetATMTransactions middleware service");

                    //if (responseModel.IsSuccess)
                    //{
                    //    atmWithdrawalTransaction = (List<WithdrawalTransactionViewModel>)responseModel.Data;
                    //}
                    //else
                    //{
                    //    atmWithdrawalTransaction = responseModel.Data == null ? new List<WithdrawalTransactionViewModel>() : (List<WithdrawalTransactionViewModel>)responseModel.Data;
                    //    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //    if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                    //    {
                    //        _logger.LogError($"Exception at GetAtmWithdrawalTransaction as: {responseModel.Message}");
                    //    }
                    //}

                    //if (responseModel.IsSuccess && (atmWithdrawalTransaction is null || atmWithdrawalTransaction.Count == 0))
                    //{
                    //    await _notificationService.Success("No record found", "Succes", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //}
                    //return (atmWithdrawalTransaction, responseModel.TotalRecords);

                    //}
                    //else
                    //{
                    //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at AtmWithdrwalService, GetAtmWithdrawalTransaction: {responseBody}");
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
                _logger.LogError($"Exception at GetAtmWithdrawalTransaction as: {ex.Message}");
            }
            //return (atmWithdrawalTransaction, 0);
        }

        public async Task<BaseModel> GetSelectedAtm()
        {
            List<long>? selectedAtmIds = await treeService.GetSelectedAtmId();
            if (selectedAtmIds is null || !selectedAtmIds.Any())
            {
                return new BaseModel { Message = Constants.Messages.AtmSelectionMsg };
            }
            else if (selectedAtmIds.Count > 1)
            {
                return new BaseModel { Message = Constants.Messages.AtmSingleSelectionMsg };
            }
            else
            {
                return new BaseModel { Data = selectedAtmIds.FirstOrDefault().ToString(), IsSuccess = true };
            }
        }
    }
}
