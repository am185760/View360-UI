using Blazorise;
using EView360.Data;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using EView360.Common;
using EView360.Pages.Operations;
using EView360Models.Core;
using EView360Models.Cash;
using EView360Models.Trx;
using Microsoft.JSInterop;
using DataRequestorMiddleware.Services.Operations;
using static Azure.Core.HttpHeader;
using DataRequestor;

namespace EView360.Services.Operations
{
    public class EJReplenishmentService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private ATMTreeViewRepository treeService;
        private AtmService atmService;
        private static string BaseUrl { get; set; }
        private ReplenishmentServiceMW service { get; set; }
        private CommonServices common { get; set; }


        public List<EView360Models.Core.Atm> userAtmList { get; set; }
        private NoteSetTypeService noteSetTypeService;

        public EJReplenishmentService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ReplenishmentService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, NoteSetTypeService noteSetTypeService, AtmService atmService, ReplenishmentServiceMW service, CommonServices common)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}Replenishment/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.treeService = treeService;
            this.noteSetTypeService = noteSetTypeService;
            this.atmService = atmService;
            this.service = service;
            this.common = common;
        }

        public async void GetReplenishments(Executor _executor, ReplenishmentFilter filter)
        {
            //List<ReplenishmentViewModel> replenishments = new();
            try
            {
                //var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    _logger.LogError($"Exception at GetReplenishments as: {selectAtmResponse.Message}");
                //    await RenderErrorBox("Error", selectAtmResponse.Message);
                //}
                //else
                //{
                //    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //    if (selectedAtmIds?.Count > 0)
                //    {

                (filter.SelectedAtmIds, filter.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();

                _logger.LogWarning("[ReplenishmentService:GetReplenishments] going in GetReplenishments middleware service");
                service.GetReplenishments(_executor, filter);
                _logger.LogWarning("[ReplenishmentService:GetReplenishments] returning from GetReplenishments middleware service");

                //if (responseModel.IsSuccess)
                //{
                //    replenishments = (List<ReplenishmentViewModel>)responseModel.Data;
                //}
                //else
                //{
                //    if (responseModel.Data != null)
                //    {
                //        replenishments = (List<ReplenishmentViewModel>)responseModel.Data;
                //    }
                //    _logger.LogError($"Exception at GetReplenishments as: {responseModel.Message}");
                //    await RenderErrorBox("Error", responseModel.Message);

                //    return replenishments;
                //}
                //if (responseModel.IsSuccess && (replenishments is null || replenishments.Count == 0))
                //{
                //    await RenderSuccessBox("Success", "No record found");
                //}
                //}
                //else
                //{
                //    _logger.LogError($"API error at Replenishment, GetReplenishments: {responseBody}");
                //    await RenderErrorBox("Error", "Something went wrong please check log.");
                //}
                //}
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReplenishments as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            //return replenishments;
        }


        public async Task RenderErrorBox(string title, string message)
        {
            await _notificationService.Error(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }

        public async Task RenderSuccessBox(string title, string message)
        {
            await _notificationService.Success(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }
    }


}
