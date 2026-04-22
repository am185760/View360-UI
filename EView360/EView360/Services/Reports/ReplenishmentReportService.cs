using Blazorise;
using Common.RequestModel;
using DataRequestorMiddleware.Services.Reports;
using EView360.Data;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using MVC.Service;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace EView360.Services.Reports
{
    public class ReplenishmentReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private DataSetService _dataSetService;
        private string BaseURl;
        private ReplenishmentReportServiceMW service;
        private ATMTreeViewRepository treeService;

        public ReplenishmentReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<AlertMonitoringReportService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, ReplenishmentReportServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}ReplenishmentReport/").ToString();
            this.service = service;
            this.treeService = treeService;
        }


        public async Task<DataTable> GetReplenishmentReport(ReplenishmentReportRequestModel filter)
        {
            DataTable dt = new DataTable();
            try
            {
                //string serializedData = JsonConvert.SerializeObject(filter);
                ////var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURl}GetReplenishmentReport", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                (filter.SelectedAtmIds, filter.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();

                _logger.LogWarning("[ReplenishmentReportService:GetReplenishmentReport] going in GetReplenishmentReport middleware service");
                var responseModel = service.GetReplenishmentReport(filter);
                _logger.LogWarning("[ReplenishmentReportService:GetReplenishmentReport] returning from GetReplenishmentReport middleware service");

                if (responseModel.IsSuccess)
                {
                    dt = (DataTable)responseModel.Data;
                }
                else
                {
                    if (responseModel.Data != null)
                    {
                        dt = (DataTable)responseModel.Data;
                    }
                    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                    if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                    {
                        _logger.LogError($"Exception at GetReplenishmentReport as: {responseModel.Message}");
                    }
                    return dt;
                }


                if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
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

                //    _logger.LogError($"API error at GetReplenishmentReport, responseBody: {responseBody}");
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReplenishmentReport as: {ex.Message}");
            }
            return dt;
        }
    }
}
