using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Reports;
using EView360.Data;
using EView360.Services.Operations;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using MVC.Service;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using NoteSetTypeViewModel = Common.ViewModel.NoteSetTypeViewModel;

namespace EView360.Services.Reports
{
    public class OutOfCashReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private OutOfCashReportServiceMW service { get; set; }

        private INotificationService _notificationService;

        private ATMTreeViewRepository treeService;

        //private string BaseUrl;

        public OutOfCashReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<OutOfCashReportService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, OutOfCashReportServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            //BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}TaskStatusReport/").ToString();
            //BaseUrl = new Uri(_apiUrl.BaseUrl + $"Report/OutOfCashReport/").ToString();
            this.treeService = treeService;
            this.service = service;
        }

        public async Task<List<NoteSetTypeViewModel>?> GetNoteSetTypesByUser(long userId)
        {
            List<NoteSetTypeViewModel>? responseList = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{_apiUrl.BaseUrl}NoteSetType/NoteSetType/GetNoteSetTypeByUserId/{userId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<NoteSetTypeViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at OutOfCashReportService, GetNoteSetTypesByUser: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetNoteSetTypesByUser as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return responseList;
        }

        public async Task RenderErrorBox(string title, string message)
        {
            await _notificationService.Error(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }

        public async Task<DataTable> GetOutOfCashReport(OutOfCashReportRequestModel filter)
        {
            DataTable dt = new DataTable();
            try
            {
                //string serializedData = JsonConvert.SerializeObject(filter);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetOutOfCashReport", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                (filter.SelectedAtms, filter.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();

                _logger.LogWarning("[OutOfCashReportService:GetOutOfCashReport] going in GetOutOfCashReport middleware service");
                var responseModel = service.GetOutOfCashReport(filter);
                _logger.LogWarning("[OutOfCashReportService:GetOutOfCashReport] returning from GetOutOfCashReport middleware service");

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
                        _logger.LogError($"Exception at GetOutOfCashReport as: {responseModel.Message}");
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

                //    _logger.LogError($"API error at GetOutOfCashReport, responseBody: {responseBody}");
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetOutOfCashReport as: {ex.Message}");
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return dt;
        }
    }
}
