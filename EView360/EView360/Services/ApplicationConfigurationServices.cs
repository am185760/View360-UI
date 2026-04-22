using EView360Models.Core;
using EView360.Data;
using EView360.Pages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Blazorise;
using static EView360.Data.Enumerations;
using Common.ViewModel;

namespace EView360.Services
{
    public class ApplicationConfigurationServices
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private static string? BaseUrl { get; set; }
        private readonly INotificationService _notificationService;
        public long UserId { get; set; }
        public ApplicationConfigurationServices(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger, INotificationService notificationService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.AppConf}AppConfiguration/").ToString();
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<AppSetting> GetAppSettingAsync()
        {
            AppSetting appSetting = new();
            try
            {
                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetAppSetting  : {DateTime.Now.ToString()}");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAppSetting");
                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from GetAppSetting  : {DateTime.Now.ToString()}");

                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    appSetting = JsonConvert.DeserializeObject<AppSetting>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AppConf, GetAppSetting: {responseBody}");
                    await _notificationService.Error(responseBody, "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAppSettingAsync as: {ex.Message}");
            }
            return appSetting;
        }


        public async Task<string> GetTemporaryFolderPathAsync()
        {
            string path = string.Empty;

            AppSetting appSetting = await GetAppSettingAsync();
            if (appSetting is not null)
            {
                path = appSetting.TemporaryFolder;
            }
            return path;
        }
        public async Task<List<CcmsService>> GetCCMSService()
        {
            List<CcmsService> responseList = new();
            try
            {
                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetCcmsServices  : {DateTime.Now.ToString()}");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetCcmsServices");
                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from GetCcmsServices  : {DateTime.Now.ToString()}");

                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<CcmsService>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AppConf, GetCcmsServices: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCCMSService as: {ex.Message}");
            }
            return responseList;
        }

        public async Task<string> UpdateAppSetting(AppSetting appSetting)
        {
            try
            {
                AuditLogViewModel auditData = new AuditLogViewModel() { UserId = UserId, RightId = (int)Permissions.ChangeConfiguration, Message = "AppConfig updated." };
                PostContentViewModel postContent = new PostContentViewModel() { AuditData = auditData, PostObj = appSetting };

                var jsonContent = JsonConvert.SerializeObject(postContent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in SaveApplicationSetting  : {DateTime.Now.ToString()}");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}SaveApplicationSetting", content);
                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from SaveApplicationSetting : {DateTime.Now.ToString()}");
                                
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at AppConf, SaveApplicationSetting: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateAppSetting: {ex.Message}");
            }
            return "Error occured during app setting update, check the logs..";
        }

        public async Task<string> UpdateCCMSServices(List<CcmsService> ccmsServices)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(ccmsServices);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in SaveCCMSServices  : {DateTime.Now.ToString()}");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}SaveCCMSServices", content);
                _logger.LogWarning($"ApplicationConfiguration: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from SaveCCMSServices  : {DateTime.Now.ToString()}");

                
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at AppConf, SaveCCMSServices: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateCCMSServices: {ex.Message}");
            }
            return "Error occured during ccms service update, check the logs..";
        }
    }
}
