using Blazorise;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Common;
using EView360.Data;
using EView360.Pages.Operations;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace EView360.Services.Operations
{
    public class AlertMonitoringService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private ATMTreeViewRepository treeService;
        private UserManagementService userService;
        private AtmService atmService;
        private static string BaseUrl { get; set; }
        private CommonServices common { get; set; }
        private AlertMonitoringServiceMW service { get; set; }

        public AlertMonitoringService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<AlertMonitoringService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, UserManagementService userService, AtmService atmService, CommonServices common, AlertMonitoringServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}AlertMonitoring/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.treeService = treeService;
            this.userService = userService;
            this.atmService = atmService;
            this.common = common;
            this.service = service;
        }

        public List<int> GetLastNYears(int N)
        {
            List<int> yearList = new();
            int year = DateTime.Now.Year;
            while (N > 0)
            {
                year--;
                yearList.Add(year);
                N--;
            }
            return yearList;
        }
        public async void GetAlerts(Executor _executor, AlertMonitoringFilter filter)
        {
            //List<AlertMonitoringViewModel> alerts = new();
            try
            {
                //var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    _logger.LogError($"Exception at GetAlerts as: {selectAtmResponse.Message}");
                //    await common.RenderErrorBox(selectAtmResponse.Message);
                //}
                //else
                //{
                //List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //if (selectedAtmIds?.Count > 0)
                //{
                (filter.SelectedAtmIds, filter.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                _logger.LogWarning("[AlertMonitoringService:GetAlerts] going in GetAlerts middleware service");
                service.GetAlerts(_executor, filter);
                _logger.LogWarning("[AlertMonitoringService:GetAlerts] returning from GetAlerts middleware service");
                //if (responseModel.IsSuccess)
                //{
                //    alerts = (List<AlertMonitoringViewModel>)responseModel.Data;
                //}
                //else
                //{
                //    if (responseModel.Data != null)
                //    {
                //        alerts = (List<AlertMonitoringViewModel>)responseModel.Data;
                //    }

                //    _logger.LogError($"API error at AlertMonitoringService, GetAlerts: {responseModel.Message}");
                //    await common.RenderErrorBox(responseModel.Message);

                //    return alerts;
                //}

                //if (responseModel.IsSuccess && (alerts is null || alerts.Count == 0))
                //{
                //    await common.RenderSuccessBox("No record found");
                //}
                //}

                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAlerts as: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
            //return alerts;
        }

        public async Task<List<string>> GetAlertTypes()
        {
            List<string> alertTypes = new();
            try
            {
                alertTypes = await userService.GetAlertTypes();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAlertTypes as: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
            return alertTypes;
        }
    }
}
