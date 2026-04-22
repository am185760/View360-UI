using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Data;
using EView360.Services.Operations;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace EView360.Services
{
    public class BalanceInvestigationService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        string? BaseURL;
        private ILogger _logger { get; set; }
        public List<Atm> userAtmList { get; set; }
        private INotificationService _notificationService;
        private BalanceInvestigationMw MwSerive;
        private readonly IConfiguration _configuration;
        private AtmService atmService;
        private ATMTreeViewRepository treeService;
        public BalanceInvestigationService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, AtmService atmService, BalanceInvestigationMw mwSerive, IConfiguration configuration, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}BalanceInvestigation/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            MwSerive = mwSerive;
            _configuration = configuration;
            this.treeService = treeService;
        }

        public async Task<(List<BalanceInvestigationViewModel> data, int totalRecords)> GetBalanceInvestigation(BalanceInvestigationRequestModel balanceInvestigation,Executor executor)
        {
            List<BalanceInvestigationViewModel> BalanceInvestigations = new();
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
                (balanceInvestigation.SelectedAtmIds, balanceInvestigation.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                //List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                if (balanceInvestigation.SelectedAtmIds?.Count > 0)
                {
                    balanceInvestigation.rowCount = _configuration.GetValue<int>("RecordPerPage");

                    //var jsonContent = JsonConvert.SerializeObject(balanceInvestigation);
                    //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetBalanceInvestigation", content);
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    //{
                    _logger.LogWarning("[BalanceInvestigationService:GetBalanceInvestigation] going in GetBalanceInvestigation middleware service");
                     await MwSerive.GetBalanceInvestigation(balanceInvestigation, executor);
                    _logger.LogWarning("[BalanceInvestigationService:GetBalanceInvestigation] going in GetBalanceInvestigation middleware service");
                    //if (responseModel.IsSuccess)
                    //{
                    //    BalanceInvestigations = (List<BalanceInvestigationViewModel>)responseModel.Data;
                    //}
                    //else
                    //{
                    //    if (responseModel.Data != null)
                    //    {
                    //        BalanceInvestigations = (List<BalanceInvestigationViewModel>)responseModel.Data;
                    //    }
                    //    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    //{
                    //    options.IntervalBeforeClose = 4000;
                    //});
                    //    if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                    //    {
                    //        _logger.LogError($"Exception at GetBalanceInvestigation as: {responseModel.Message}");
                    //    }
                    //    return (BalanceInvestigations, responseModel.TotalRecords);
                    //}


                    //if (responseModel.IsSuccess && (BalanceInvestigations is null || BalanceInvestigations.Count == 0))
                    //{
                    //    await _notificationService.Success("No record found", "Succes", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //}
                    //return (BalanceInvestigations, responseModel.TotalRecords);

                    //}
                    //else
                    //{
                    //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at GetBalanceInvestigation, responseBody: {responseBody}");
                    //}
                }

                //}
            }
            catch (Exception ex)
            {
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                            {
                                options.IntervalBeforeClose = 4000;
                            });
                _logger.LogError($"Exception at GetBalanceInvestigation as: {ex.Message}");
            }
            return (BalanceInvestigations, 0);
        }

    }
}
