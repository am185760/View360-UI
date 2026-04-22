using Blazorise;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Data;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;

namespace EView360.Services.Operations.DashBoard
{
    public class OrderDownloadDashboardService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private static string? BaseUrl { get; set; }
        private AtmService atmService;
        private Executor executor { get; set; }
        private OrderDownloadDatagridServiceMW service { get; set; }


        public OrderDownloadDashboardService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<OrderDownloadDashboardService> logger, INotificationService notificationService, AtmService atmService, Executor executor, OrderDownloadDatagridServiceMW service)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Dashboard}OrderDownload/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.executor = executor;
            this.service = service;
        }

        //public async Task<List<DailyFeedStatusViewModel>> GetDailyFeed(List<string> selectedAtms)
        //{
        //    List<DailyFeedStatusViewModel> feeds = new();
        //    try
        //    {
        //            if (selectedAtms?.Count > 0)
        //            {
        //                DataTableResult FtpThresholdResult = executor.ExecuteDSRequest<DataTableResult>("GetFtpThreshold", new SqlParameter[] { }, selectedAtms);
        //                int FtpThreshold = (int)FtpThresholdResult.Table.Rows[0]["threshold_for_ftp"];

        //                string queryFilter = "";
        //                var response = new BaseModel();

        //                if (FtpThreshold != -1)
        //                    queryFilter += " and f.creation_time >= convert(datetime,'" + DateTime.Today.AddDays(-FtpThreshold).ToString("dd/MM/yyyy") + "',103) " +
        //                           " and f.creation_time <=convert(datetime,'" + DateTime.Today.AddDays(-FtpThreshold).ToString("dd/MM/yyyy") + " 23:59:59',103) ";

        //                SqlParameter param1 = new SqlParameter();
        //                param1.ParameterName = "@Filter";
        //                param1.SqlDbType = SqlDbType.VarChar;
        //                param1.Value = queryFilter;

        //                SqlParameter param2 = new SqlParameter();
        //                param2.ParameterName = "@OrderBy";
        //                param2.SqlDbType = SqlDbType.VarChar;
        //                param2.Value = "creation_time desc";

        //                DataTableResult result = executor.ExecuteDSRequest<DataTableResult>("GetOrders", new SqlParameter[] { param1, param2 }, selectedAtms);
        //                if (result?.Table?.Rows?.Count > 0)
        //                {
        //                    feeds = ConvertDataTableToList(result.Table);
        //                }
        //            else
        //            {
        //                await _notificationService.Success("No record found", "Succes", (options) =>
        //                {
        //                    options.IntervalBeforeClose = 4000;
        //                });
        //            }
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exception at GetDailyFeed as: {ex.Message}");
        //        await _notificationService.Error(ex.Message, "Error", (options) =>
        //        {
        //            options.IntervalBeforeClose = 4000;
        //        });
        //    }
        //    return feeds;
        //}

        public async Task<List<DailyFeedStatusViewModel>> GetDailyFeed()
        {
            List<DailyFeedStatusViewModel> feeds = new();
            try
            {
                _logger.LogWarning("[OrderDownloadDashboardService:GetDailyFeed] going in GetDailyFeed middleware service");
                var responseModel = service.GetDailyFeed();
                _logger.LogWarning("[OrderDownloadDashboardService:GetDailyFeed] returning from GetDailyFeed middleware service");

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

                    _logger.LogError($"Exception at GetDailyFeed as: {responseModel.Message}");
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
