using Blazorise;
using DataRequestor;
using EView360.Data;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DataRequestorMiddleware;
using DataRequestorMiddleware.Services.Operations;

namespace EView360.Services.Operations
{
    public class DailyFeedStatusService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private static string BaseUrl { get; set; }
        private AtmService atmService;
        private Executor executor { get; set; }
        private DailyFeedStatusServiceMW service { get; set; }

        public DailyFeedStatusService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<DailyFeedStatusService> logger, INotificationService notificationService, AtmService atmService, Executor executor, DailyFeedStatusServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}DailyFeedStatus/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.executor = executor;
            this.service = service;
        }

        public async Task<List<DailyFeedStatusViewModel>> GetDailyFeed(DailyFeedStatusFilter filter)
        {
            List<DailyFeedStatusViewModel> feeds = new();
            try
            {
                _logger.LogWarning("[DailyFeedStatusService:GetDailyFeed] going in GetDailyFeed middleware service");
                var responseModel = service.GetDailyFeed(filter);
                _logger.LogWarning("[DailyFeedStatusService:GetDailyFeed] returning from GetDailyFeed middleware service");
                if (responseModel.IsSuccess)
                {
                    feeds = (List<DailyFeedStatusViewModel>)responseModel.Data;
                }
                else
                {
                    if (responseModel.Data != null)
                    {
                        feeds = (List<DailyFeedStatusViewModel>)responseModel.Data;
                    }
                    _logger.LogError($"API error at DailyFeedStatusService, GetDailyFeed: {responseModel.Message}");

                    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    return feeds;
                }

                if (responseModel.IsSuccess && (feeds is null || feeds.Count == 0))
                {
                    await _notificationService.Success("No record found", "Success", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetDailyFeed as: {ex.Message}");

                await _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return feeds;
        }

    }
}
