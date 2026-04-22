using Blazorise;
using Common.RequestModel;
using DataRequestorMiddleware.Services.Reports;
using EView360.Data;
using EView360.Pages.Reports;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace EView360.Services.Reports
{
    public class LowBalanceReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public int UserId { get; set; }
        private ILogger<LowBalanceReportService> _logger { get; set; }
        private AtmService atmService;
        private LowBalanceReportServiveMw serviceMw;
        private ATMTreeViewRepository treeService;
        public LowBalanceReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<LowBalanceReportService> logger, INotificationService notificationService, AtmService atmService, LowBalanceReportServiveMw serviceMw = null, ATMTreeViewRepository treeService = null)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}LowBalanceReport/").ToString();
            _logger = logger;
            this.notificationService = notificationService;
            this.atmService = atmService;
            this.serviceMw = serviceMw;
            this.treeService = treeService;
        }

        string BaseUrl { get; set; }

        private INotificationService notificationService;


        public async Task<DataTable> GetLowBalanceReport(LowBalanceReportRequestModel lowBalanceReportRequestModel)
        {
            //List<TaskStatusReportViewModel> taskStatusReport = new();
            DataTable dt = new DataTable();
            try
            {
                if (lowBalanceReportRequestModel.minThreshold > lowBalanceReportRequestModel.maxThreshold)
                {
                    await notificationService.Info("Max threshold must be greater than minimum threshold.", "Information", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    return dt;
                }
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
                //lowBalanceReportRequestModel.SelectedAtms = (List<string>)selectAtmResponse.Data;
                //string serializedData = JsonConvert.SerializeObject(lowBalanceReportRequestModel);
                ////var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = (bNATransactionRequestModel.SelectedAtmIds, bNATransactionRequestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                //await client.PostAsync($"{BaseUrl}GetLowBalance", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                (lowBalanceReportRequestModel.SelectedAtms, lowBalanceReportRequestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                if (lowBalanceReportRequestModel?.SelectedAtms?.Count > 0)
                {
                    _logger.LogWarning($"LowBalanceReportServiceUI:GetLowBalanceReport] going in GetLowBalance MiddlewareService");
                    var responseModel = await serviceMw.GetLowBalance(lowBalanceReportRequestModel);
                    _logger.LogWarning($"LowBalanceReportServiceUI:GetLowBalanceReport] going in GetLowBalance MiddlewareService");

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
                            _logger.LogError($"Exception at GetLowBalanceReport as: {responseModel.Message}");
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

                    //    _logger.LogError($"API error at GetLowBalanceReport, responseBody: {responseBody}");
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
                await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                _logger.LogError($"Exception at GetLowBalanceReport as: {ex.Message}");
            }
            return dt;
        }


    }
}
