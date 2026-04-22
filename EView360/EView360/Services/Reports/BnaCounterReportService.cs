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
    public class BnaCounterReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger<BnaCounterReportService> _logger { get; set; }
        private AtmService atmService;
        private BnaCounterReportServiceMw serviceMw;
        private ATMTreeViewRepository treeService;
        string BaseUrl { get; set; }

        private INotificationService notificationService;

        public BnaCounterReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaCounterReportService> logger, INotificationService notificationService, AtmService atmService, BnaCounterReportServiceMw serviceMw, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}BnaCounter/").ToString();
            _logger = logger;
            this.notificationService = notificationService;
            this.atmService = atmService;
            this.serviceMw = serviceMw;
            this.treeService = treeService;
        }


        public async Task<DataTable> GetBnaCounterReport(BnaCounterReportRequestModel bnaCounterReportRequest)
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
                //bnaCounterReportRequest.SelectedAtms = (List<string>)selectAtmResponse.Data;
                //string serializedData = JsonConvert.SerializeObject(bnaCounterReportRequest);
                ////var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetBNACounterDetail", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                (bnaCounterReportRequest.SelectedAtms, bnaCounterReportRequest.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (bnaCounterReportRequest?.SelectedAtms?.Count > 0)
                {

                    _logger.LogWarning($"BnaCounterReportService:GetBnaCounterReport] going in GetBnaCounterReport middleware service");

                    var responseModel = await serviceMw.GetBnaCounterReport(bnaCounterReportRequest);
                    _logger.LogWarning($"BnaCounterReportService:GetBnaCounterReport] return from GetBnaCounterReport middleware service");

                    if (responseModel.IsSuccess)
                    {
                        dt = JsonConvert.DeserializeObject<DataTable>(responseModel.Data.ToString());
                    }
                    else
                    {
                        if (responseModel.Data != null)
                        {
                            dt = JsonConvert.DeserializeObject<DataTable>(responseModel.Data.ToString());
                        }
                        await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                        {
                            _logger.LogError($"Exception at GetBnaCounterReport as: {responseModel.Message}");
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

                    //    _logger.LogError($"API error at GetBnaCounterReport, responseBody: {responseBody}");
                    //}
                    //}
                }
                else 
                {
                    await notificationService.Error($"Please Select atm.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetBnaCounterReport as: {ex.Message}");
                await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });

            }
            return dt;
        }

        public async Task<DataTable> GetBnaCounterSubReportReport(BnaCounterReportRequestModel bnaCounterReportRequest)
        {
            //List<TaskStatusReportViewModel> taskStatusReport = new();
            (bnaCounterReportRequest.SelectedAtms, bnaCounterReportRequest.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();

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
                //    bnaCounterReportRequest.SelectedAtms = (List<string>)selectAtmResponse.Data;
                //string serializedData = JsonConvert.SerializeObject(bnaCounterReportRequest);
                ////var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetBnaCounterSubReportReport", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                (bnaCounterReportRequest.SelectedAtms, bnaCounterReportRequest.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (bnaCounterReportRequest?.SelectedAtms?.Count > 0)
                {
                    _logger.LogWarning("[BnaCounterReportService:GetBnaCounterSubReportReport] going in GetBnaCounterSubReportReport middleware service");
                    var responseModel = await serviceMw.GetBnaCounterSubReportReport(bnaCounterReportRequest);
                    _logger.LogWarning("[BnaCounterReportService:GetBnaCounterSubReportReport] return from GetBnaCounterSubReportReport middleware service");

                    if (responseModel.IsSuccess)
                    {
                        dt = JsonConvert.DeserializeObject<DataTable>(responseModel.Data.ToString());
                    }
                    else
                    {
                        if (responseModel.Data != null)
                        {
                            dt = JsonConvert.DeserializeObject<DataTable>(responseModel.Data.ToString());
                        }
                        await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                        {
                            _logger.LogError($"Exception at GetBnaCounterSummaryReport as: {responseModel.Message}");
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

                    //    _logger.LogError($"API error at GetBnaCounterSummaryReport, responseBody: {responseBody}");
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
                _logger.LogError($"Exception at GetBnaCounterReport as: {ex.Message}");
            }
            return dt;
        }
    }

}
