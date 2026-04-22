using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
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
    public class GroupReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private DataSetService _dataSetService;
        private string BaseURl;
        private GroupReportServiceMW service;

        public GroupReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<GroupReportService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, GroupReportServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}GroupReport/").ToString();
            this.service = service;
        }


        public async Task<DataTable> GetGroupListReport(GroupReportViewModel filter)
        {
            DataTable dt = new DataTable();
            try
            {
                //string serializedData = JsonConvert.SerializeObject(filter);
                ////var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURl}GetGroupListReport", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                _logger.LogWarning("[GroupReportService:GetGroupListReport] going in GetGroupListReport middleware service");
                var responseModel = service.GetGroupListReport(filter);
                _logger.LogWarning("[GroupReportService:GetGroupListReport] returning from GetGroupListReport middleware service");

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

                    if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                    {
                        _logger.LogError($"Exception at GetGroupListReport as: {responseModel.Message}");
                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
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

                //    _logger.LogError($"API error at GetGroupListReport, responseBody: {responseBody}");
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetGroupListReport as: {ex.Message}");
                await _notificationService.Error($"{ex.Message}", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return dt;
        }
    }
}
