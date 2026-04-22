using Blazorise;
using EView360.Data;
using EView360.Services;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Data;
using System.Reflection;
using static EView360.Common.Constants;

namespace EView360.Common
{
    public class CommonServices
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private static string? BaseUrl { get; set; }
        private readonly IConfiguration _configuration;
        public Dictionary<int, string> userRight;

        public CommonServices(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<CommonServices> logger, INotificationService notificationService, IConfiguration configuration)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + _apiUrl.Operations).ToString();
            _logger = logger;
            _notificationService = notificationService;
            _configuration = configuration;
        }

        public int GetDatabaseOffset(int pageNo)
        {
            int recordPerPage = _configuration.GetValue<int>("RecordPerPage");
            return (pageNo - 1) * recordPerPage;
        }

        public int GetRecordPerPage()
        {
            return _configuration.GetValue<int>("RecordPerPage");
        }

        public int GetMaxPageNo(int totalCount)
        {
            double recordPerPage = _configuration.GetValue<double>("RecordPerPage");
            return Convert.ToInt32(Math.Ceiling(totalCount / recordPerPage));
        }

        public async Task<int> GetDashhboardRefreshInterval()
        {
            int refreshInterval = 0;
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}Core/GetDashboardRefreshInterval");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    refreshInterval = JsonConvert.DeserializeObject<int>(responseBody);
                }
                else
                {
                    await RenderErrorBox(responseBody);
                    _logger.LogError($"API error at Operation, Core: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                await RenderErrorBox(ex.Message);
                _logger.LogError($"Exception at GetAllFileTypeAsync as: {ex.Message}");
            }
            return refreshInterval;
        }

        public async Task RenderErrorBox(string message)
        {
            await _notificationService.Error(message, "Error", (options) =>
            {
                options.IntervalBeforeClose = 5000;
            });
        }

        public async Task RenderSuccessBox(string message)
        {
            await _notificationService.Success(message, "Success", (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }

        public async Task RenderCustomBox(RenderMessageType messageType, string title, string message)
        {
            if (messageType.Equals(RenderMessageType.Error))
            {
                await _notificationService.Error(message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 5000;
                });
            }
            if (messageType.Equals(RenderMessageType.Success))
            {
                await _notificationService.Success(message, "Success", (options) =>
                {
                    options.IntervalBeforeClose = 5000;
                });
            }
            if (messageType.Equals(RenderMessageType.Info))
            {
                await _notificationService.Info(message, "Info", (options) =>
                {
                    options.IntervalBeforeClose = 5000;
                });
            }
        }

        public List<int> GetLastNYears()
        {
            int N = _configuration.GetValue<int>("ArchiveLastNYears");
            List<int> yearList = new();
            int year = DateTime.Now.Year;
            while (N > 0)
            {
                year--;
                yearList.Add(year);
                N--;
            }
            return yearList;
        }

        public async Task TaskDelay()
        {
            await Task.Delay(_configuration.GetValue<int>("TaskDelayInMS"));
        }
        
        public async Task<int> GetDashboadrdDataGridPageSize()
        {
            return  _configuration.GetValue<int>("DashboardDataGridPageSize"); ;
        }

        public DataTable ConverAtmtListToDataTable<T>(List<T> list)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("atm_id");

            //foreach (var propInfo in typeof(T).GetProperties())
            //{
            //    dataTable.Columns.Add(propInfo.Name, propInfo.PropertyType);
            //}

            foreach (var item in list)
            {
                DataRow row = dataTable.NewRow();

                row["atm_id"] = item;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public bool CheckPermission(int right)
        {
            try
            {
                if (userRight is not null)
                    return userRight.ContainsKey(right);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CheckPermission as: {ex.Message}");

                _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return false;
        }
    }
}
