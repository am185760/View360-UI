using Blazorise;
using Common.RequestModel;
using DataRequestorMiddleware.Services.Reports;
using EView360.Data;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace EView360.Services.Reports
{
    public class CashUtilizationReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public int UserId { get; set; }
        private ILogger<CashUtilizationReportService> _logger { get; set; }
        private AtmService atmService;
        private CashUtilizationReportMw serviceMw;
        private ATMTreeViewRepository treeService;
        public CashUtilizationReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<CashUtilizationReportService> logger, INotificationService notificationService, AtmService atmService, CashUtilizationReportMw serviceMw, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}CashUtilizationReport/").ToString();
            _logger = logger;
            this.notificationService = notificationService;
            this.atmService = atmService;
            this.serviceMw = serviceMw;
            this.treeService = treeService;
        }

        string BaseUrl { get; set; }

        private INotificationService notificationService;


        public async Task<DataTable> GetCashUtilizationReport(CashUtilizationReportRequestModel cashUtilizationReportRequestModel)
        {
            //List<TaskStatusReportViewModel> taskStatusReport = new();
            DataTable dt = new DataTable();
            try
            {
                //var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    await notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });
                //}
                //else
                //{
                //cashUtilizationReportRequestModel.SelectedAtms = (List<string>)selectAtmResponse.Data;
                //string serializedData = JsonConvert.SerializeObject(cashUtilizationReportRequestModel);
                ////var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetCashUtilzation", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                (cashUtilizationReportRequestModel.SelectedAtms, cashUtilizationReportRequestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (cashUtilizationReportRequestModel?.SelectedAtms?.Count > 0)
                {
                    _logger.LogWarning($"CashUtilizationReportService:GetCashUtilizationReport] going in GetCashUtilization middleware service");

                    var responseModel = await serviceMw.GetCashUtilization(cashUtilizationReportRequestModel);
                    _logger.LogWarning($"CashUtilizationReportService:GetCashUtilizationReport] return from GetCashUtilization middleware service");

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
                        await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                        {
                            _logger.LogError($"Exception at GetCashUtilizationReport as: {responseModel.Message}");
                        }
                        return dt;
                    }


                    if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
                    {
                        await notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                    //}
                    //else
                    //{
                    //    await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at GetCashUtilizationReport, responseBody: {responseBody}");
                    //}
                    //}
                }
                else 
                {
                    await notificationService.Error($"Please select atm.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCashUtilizationReport as: {ex.Message}");
                await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return dt;
        }
    }
}
