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
    public class NoCashWIthdrawalReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private DataSetService _dataSetService;
        private string BaseURl;
        private NoCashWIthdrawalReportServiceMW service;

        public NoCashWIthdrawalReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<NoCashWIthdrawalReportService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, NoCashWIthdrawalReportServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}NoCashWIthdrawalReport/").ToString();
            this.service = service;
        }


        public async Task<DataTable> GetNoCashWIthdrawalReport(NoCashWithdrawalReportRequestModel filter)
        {
            DataTable dt = new DataTable();
            try
            {
                //string serializedData = JsonConvert.SerializeObject(filter);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURl}GetNoCashWIthdrawalReport", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                _logger.LogWarning("[NoCashWIthdrawalReportService:GetNoCashWIthdrawalReport] going in GetNoCashWIthdrawalReport middleware service");
                var responseModel = service.GetNoCashWIthdrawalReport(filter);
                _logger.LogWarning("[NoCashWIthdrawalReportService:GetNoCashWIthdrawalReport] returning from GetNoCashWIthdrawalReport middleware service"); 

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
                        _logger.LogError($"Exception at GetNoCashWIthdrawalReport as: {responseModel.Message}");
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

                //    _logger.LogError($"API error at GetNoCashWIthdrawalReport, responseBody: {responseBody}");
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetNoCashWIthdrawalReport as: {ex.Message}");
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return dt;
        }
    }
}
