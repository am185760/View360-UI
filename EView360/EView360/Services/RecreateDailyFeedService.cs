using Blazorise;
using EView360.Data;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace EView360.Services
{
    public class RecreateDailyFeedService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private static string? BaseUrl { get; set; }

        public RecreateDailyFeedService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<RecreateDailyFeedService> logger, INotificationService notificationService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.RecreateDailyFeed}RecreateDailyFeed/").ToString();
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<List<DailyFeedSchedule>> GetDailyFeedSchedules(DateTime fromDate, DateTime toDate)
        {
            List<DailyFeedSchedule>? DailyFeedSchedules = new();
            try
            {
                _logger.LogWarning("[RecreateDailyFeedService:GetDailyFeedSchedules] going in GetDailyFeedSchedules Recreate Daily Feed Service API");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetDailyFeedSchedules/?fromDate={fromDate.ToString()}&toDate={toDate.ToString()}");
                _logger.LogWarning("[RecreateDailyFeedService:GetDailyFeedSchedules] returning from GetDailyFeedSchedules Recreate Daily Feed API");

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    DailyFeedSchedules = JsonConvert.DeserializeObject<List<DailyFeedSchedule>>(responseBody);

                    if (DailyFeedSchedules is null || DailyFeedSchedules.Count == 0)
                    {
                        await RenderSuccessBox("Success", "No record found");
                    }
                }
                else
                {
                    _logger.LogError($"API error at Recreate Daily Feed Service, GetDailyFeedSchedules: {responseBody}");
                    await RenderErrorBox("Error", "An error occured, check logs..");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetDailyFeedSchedules as: {ex.Message}");
                await RenderErrorBox("Error", "An error occured, check logs..");
            }

            return DailyFeedSchedules;
        }

        public async Task<int> GetRetryCount()
        {
            int retryCount = 0;
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetRetryCount");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    retryCount = JsonConvert.DeserializeObject<int>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Recreate Daily Feed Service, GetRetryCount: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetRetryCount as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }

            return retryCount;
        }

        public async Task<BaseModel> CreateNewSchedule(DailyFeedSchedule schedule)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(schedule);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}CreateNewSchedule", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (!responseModel.IsSuccess)
                    {
                        _logger.LogError($"API error at Recreate Daily Feed Service, CreateNewSchedule: {responseModel.Message}");
                        await RenderErrorBox("Error", responseModel.Message);
                    }
                    return responseModel;
                }
                else
                {
                    _logger.LogError($"API error at Recreate Daily Feed Service, CreateNewSchedule: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CreateNewSchedule: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return new BaseModel { IsSuccess = false };
        }

        public async Task<BaseModel> DeleteSchedule(long scheduleId)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}DeleteSchedule/{scheduleId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (!responseModel.IsSuccess)
                    {
                        _logger.LogError($"API error at Recreate Daily Feed Service, DeleteSchedule: {responseModel.Message}");
                        await RenderErrorBox("Error", responseModel.Message);
                    }
                    return responseModel;
                }
                else
                {
                    _logger.LogError($"API error at Recreate Daily Feed Service, DeleteSchedule: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeleteSchedule: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return new BaseModel { IsSuccess = false };
        }

        public async Task RenderErrorBox(string title, string message)
        {
            await _notificationService.Error(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }
        public async Task RenderSuccessBox(string title, string message)
        {
            await _notificationService.Success(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }
    }
}
