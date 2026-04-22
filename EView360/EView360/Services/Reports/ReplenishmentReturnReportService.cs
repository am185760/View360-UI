using Blazorise;
using Common.RequestModel;
using DataRequestorMiddleware.Services.Reports;
using EView360.Data;
using EView360.Services.Operations;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using MVC.Service;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace EView360.Services.Reports
{
    public class ReplenishmentReturnReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }

        private INotificationService _notificationService;

        private ATMTreeViewRepository treeService;
        private DataSetService _dataSetService;
        readonly IWebHostEnvironment _hostingEnvironment;
        private AtmService atmService;
        private ReplenishmentReturnServiceMw service;


        //public List<Atm> userAtmList { get; set; }

        private string BaseURl;

        public ReplenishmentReturnReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<AtmWithdrawalTransactionService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, DataSetService dataSetService, IWebHostEnvironment hostingEnvironment, ReplenishmentReturnServiceMw service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}ReplenishmentReturn/").ToString();
            this.treeService = treeService;
            this.atmService = atmService;
            _dataSetService = dataSetService;
            _hostingEnvironment = hostingEnvironment;
            this.service = service;
        }

        public async Task<DataTable> GetReplenishmentReturn(ReplenishmentReturnReportRequestModel returnReportRequestModel)
        {
            DataTable dt = new DataTable();
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
                //returnReportRequestModel.SelectedAtms = (List<string>)selectAtmResponse.Data;
                //string serializedData = JsonConvert.SerializeObject(returnReportRequestModel);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURl}GetReplenishmentReturn", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                (returnReportRequestModel.SelectedAtms, returnReportRequestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (returnReportRequestModel.SelectedAtms?.Count > 0)
                {
                    _logger.LogWarning($"ReplenishmentReturnReportService:GetReplenishmentReturn] going to GetReplenishmentReturn middleware service");

                    var responseModel = await service.GetReplenishmentReturn(returnReportRequestModel);
                    _logger.LogWarning($"ReplenishmentReturnReportService:GetReplenishmentReturn] return from GetReplenishmentReturn middleware service");

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
                            _logger.LogError($"Exception at GetReplenishmentReturn as: {responseModel.Message}");
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

                    //    _logger.LogError($"API error at GetReplenishmentReturn, responseBody: {responseBody}");
                    //}
                    //}
                }
                else 
                {
                    await _notificationService.Error($"Please select atm.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                   {
                       options.IntervalBeforeClose = 4000;
                   });

                _logger.LogError($"Exception at GetReplenishmentReturn as: {ex.Message}");
            }
            return dt;
        }
    }
}
