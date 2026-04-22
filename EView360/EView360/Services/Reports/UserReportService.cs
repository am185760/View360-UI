using Blazorise;
using ceTe.DynamicPDF.ReportWriter;
using Common.RequestModel;
using EView360.Data;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace EView360.Services.Reports
{
    public class UserReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger<UserReportService> _logger { get; set; }
        private AtmService atmService;
        string BaseUrl { get; set; }
        private INotificationService notificationService;
        public UserReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<UserReportService> logger, INotificationService notificationService, AtmService atmService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}UsersReport/").ToString();
            _logger = logger;
            this.notificationService = notificationService;
            this.atmService = atmService;
        }


        public async Task<DataTable> GetUsersReport(UserReportRequestModel reportRequestModel)
        {
            //List<TaskStatusReportViewModel> taskStatusReport = new();
            DataTable dt = new DataTable();
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                if (!selectAtmResponse.IsSuccess)
                {
                    await notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    reportRequestModel.SelectedAtmIds = (List<string>)selectAtmResponse.Data;
                    string serializedData = JsonConvert.SerializeObject(reportRequestModel);
                    //var jsonContent = JsonConvert.SerializeObject(serializedData);
                    HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                    _logger.LogWarning("[UserReportService:GetUsersReport] going to call  GetUsers API");

                    HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetUsers", content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    _logger.LogWarning("[UserReportService:GetUsersReport] return from  GetUsers API");

                    if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    {

                        var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
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
                                _logger.LogError($"Exception at GetUsersReport as: {responseModel.Message}");
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
                    }
                    else
                    {
                        await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });

                        if (!string.IsNullOrEmpty(responseBody))
                        {

                            _logger.LogError($"API error at GetUsersReport, responseBody: {responseBody}");

                        }
                        else
                        {
                            _logger.LogError($"API error at GetUsersReport, responseBody: {response.ToString()}");
                        }
                    }
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
