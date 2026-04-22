using EView360Models.Core;
using EView360.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using EView360Models.ViewModels;

namespace EView360.Services
{
    public class AlertTemplateService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private static string? BaseUrl { get; set; }
        private ILogger _logger { get; set; }
        public AlertTemplateService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.AlertTemplate}AlertTemplate/").ToString();
            _logger = logger;
        }


        public async Task<List<AlertTypeViewModel>> GetAlertTypesAsync()
        {
            List<AlertTypeViewModel> alertTypes = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAlertTypes");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    alertTypes = JsonConvert.DeserializeObject<List<AlertTypeViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AlertTemplate, GetAlertTypes: {responseBody}");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception at GetAlertTypesAsync: {ex.Message}");
            }
            
            return alertTypes;
        }

        public async Task<string> UpdateAlertType(AlertTypeViewModel alertType)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(alertType);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateAlertType", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) { return "success"; }
                _logger.LogError($"API error at AlertTemplate, UpdateAlertType: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateAlertType: {ex.Message}");
            }
            return "error";
        }
    }
}
