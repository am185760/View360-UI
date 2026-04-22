using EView360.Data;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace EView360.Services.Operations
{
    public class ReportTaskService
    {
        private static HttpClient client { get; set; }
        private ILogger _logger { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private static string? BaseUrl { get; set; }


        public ReportTaskService(HttpClient httpClient, ILogger<Atm> logger, IOptions<ApiUrl> apiUrl)
        {
            _logger = logger;
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}ReportTask/").ToString();
        }

        public async Task<List<ReportTaskViewModel>> GetReports(DateTime? fromDate, DateTime? toDate, string? taskStatus = null)
        {
            List<ReportTaskViewModel> responseList = new();
            try
            {
                _logger.LogWarning($"ReportTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in Operations ReportTask API  : {DateTime.Now.ToString()}");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}?fromDate={fromDate}&toDate={toDate}&taskStatus={taskStatus}");
                _logger.LogWarning($"ReportTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from Operations ReportTask API  : {DateTime.Now.ToString()}");
                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<ReportTaskViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Operations, ReportTaskController: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReports as: {ex.Message}");
            }
            return responseList;
        }
    }
}
