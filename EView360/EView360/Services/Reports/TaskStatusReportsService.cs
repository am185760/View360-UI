using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Reports;
//using Demo.MVC.Net6.Models;
using EView360.Common;
using EView360.Data;
using EView360.Pages.Operations;
using EView360.Services.Operations;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using MVC.Service;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Json;
using System.Text;

namespace EView360.Services.Reports
{
    public class TaskStatusReportsService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }

        private INotificationService _notificationService;

        private ATMTreeViewRepository treeService;
        private DataSetService _dataSetService;
        readonly IWebHostEnvironment _hostingEnvironment;
        private AtmService atmService;
        private TaskStatusReportServiceMw ServiceMw;


        //public List<Atm> userAtmList { get; set; }

        private string BaseURl;

        public TaskStatusReportsService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<AtmWithdrawalTransactionService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, AtmService atmService, DataSetService dataSetService, IWebHostEnvironment hostingEnvironment, TaskStatusReportServiceMw serviceMw)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            _logger = logger;
            _notificationService = notificationService;
            //client.BaseAddress = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}WithdrawalTransaction/");
            BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}TaskStatusReport/").ToString();
            //BaseURl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Report}/TaskStatusReport/").ToString();
            this.treeService = treeService;
            this.atmService = atmService;
            _dataSetService = dataSetService;
            _hostingEnvironment = hostingEnvironment;
            ServiceMw = serviceMw;
        }

        #region commentedCode
        //public async Task<List<TaskStatusReportViewModel>> GetTaskStatusReports(TaskStatusReportRequestModel taskStatusReportRequestModel)
        //{
        //    List<TaskStatusReportViewModel> taskStatusReports = new();
        //    try
        //    {
        //        var selectAtmResponse = atmService.GetMultipleSelectedAtms();
        //        if (!selectAtmResponse.IsSuccess)
        //        {
        //            await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
        //            {
        //                options.IntervalBeforeClose = 4000;
        //            });
        //        }
        //        else
        //        {
        //            List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
        //            if (selectedAtmIds?.Count > 0)
        //            {
        //                taskStatusReportRequestModel.SelectedAtms = selectedAtmIds;
        //                var jsonContent = JsonConvert.SerializeObject(taskStatusReportRequestModel);
        //                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //                HttpResponseMessage response = await client.PostAsync($"{BaseURl}GetTaskStatusReport", content);
        //                string responseBody = await response.Content.ReadAsStringAsync();
        //                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
        //                {

        //                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
        //                    if (responseModel.IsSuccess)
        //                    {
        //                        taskStatusReports = JsonConvert.DeserializeObject<List<TaskStatusReportViewModel>>(responseModel.Data.ToString());
        //                    }
        //                    else
        //                    {
        //                        taskStatusReports = JsonConvert.DeserializeObject<List<TaskStatusReportViewModel>>(responseModel.Data.ToString());

        //                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
        //                        {
        //                            options.IntervalBeforeClose = 4000;
        //                        });
        //                        return taskStatusReports;
        //                    }


        //                    if (responseModel.IsSuccess && (taskStatusReports is null || taskStatusReports.Count == 0))
        //                    {
        //                        await _notificationService.Success("No record found", "Succes", (options) =>
        //                        {
        //                            options.IntervalBeforeClose = 4000;
        //                        });
        //                    }
        //                }
        //                else
        //                {
        //                    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
        //                    {
        //                        options.IntervalBeforeClose = 4000;
        //                    });

        //                    _logger.LogError($"API error at TaskStatusReportsService, GetTaskStatusReports: {responseBody}");
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exception at GetTaskStatusReports as: {ex.Message}");
        //    }
        //    return taskStatusReports;
        //}

        //public async Task<HomeModel> GetReport(int i)
        //{
        //    List<BnaTransactionViewModel> bnaTransaction = new();
        //    //try
        //    //{
        //    //    var selectAtmResponse = atmService.GetMultipleSelectedAtms();
        //    //    if (!selectAtmResponse.IsSuccess)
        //    //    {
        //    //        await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
        //    //        {
        //    //            options.IntervalBeforeClose = 4000;
        //    //        });
        //    //    }
        //    //    else
        //    //    {
        //    //        List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
        //    //        if (selectedAtmIds?.Count > 0)
        //    //        {
        //    //            bNATransactionRequestModel.SelectedAtmIds = selectedAtmIds;
        //    //            var jsonContent = JsonConvert.SerializeObject(bNATransactionRequestModel);
        //    //            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //    //            HttpResponseMessage response = await client.PostAsync($"{BaseURl}BNATransactions", content);
        //    //            string responseBody = await response.Content.ReadAsStringAsync();
        //    //            if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
        //    //            {

        //    //                var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
        //    //                if (responseModel.IsSuccess)
        //    //                {
        //    //                    bnaTransaction = JsonConvert.DeserializeObject<List<BnaTransactionViewModel>>(responseModel.Data.ToString());
        //    //                }
        //    //                else
        //    //                {
        //    //                    bnaTransaction = JsonConvert.DeserializeObject<List<BnaTransactionViewModel>>(responseModel.Data.ToString());

        //    //                    await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
        //    //                    {
        //    //                        options.IntervalBeforeClose = 4000;
        //    //                    });
        //    //                    return bnaTransaction;
        //    //                }


        //    //                if (responseModel.IsSuccess && (bnaTransaction is null || bnaTransaction.Count == 0))
        //    //                {
        //    //                    await _notificationService.Success("No record found", "Succes", (options) =>
        //    //                    {
        //    //                        options.IntervalBeforeClose = 4000;
        //    //                    });
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
        //    //                {
        //    //                    options.IntervalBeforeClose = 4000;
        //    //                });

        //    //                _logger.LogError($"API error at BNATransactionService, GetBNATransaction: {responseBody}");
        //    //            }
        //    //        }

        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    _logger.LogError($"Exception at GetBNATransaction as: {ex.Message}");
        //    //}

        //    //List<IList> responseList = new List<IList>();
        //    var homeModel = new HomeModel();
        //    try
        //    {
        //        using HttpResponseMessage response = client.GetAsync($"{BaseURl}1").Result;
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            _logger.LogError($"Error at api TreeBuilder, GetRegionAndAtmByUserId as: {responseBody}");
        //        }
        //        if (!string.IsNullOrEmpty(responseBody))
        //        {
        //            homeModel = JsonConvert.DeserializeObject<HomeModel>(responseBody);
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        _logger.LogError($"Exception at GetATMRegionByUser: {ex.Message}");
        //    }
        //    return homeModel;
        //}

        //public HomeModel OpenReport(int? reportIndex = 0)
        //{
        //    var model = new HomeModel()
        //    {
        //        WebReport = new WebReport(),
        //        ReportsList = new[]
        //            {
        //            "Simple List",
        //            "Labels",
        //            "Master-Detail",
        //            "Badges",
        //            "Interactive Report, 2-in-1",
        //            "Hyperlinks, Bookmarks",
        //            "Outline",
        //            "Complex (Hyperlinks, Outline, TOC)",
        //            "Drill-Down Groups",
        //            "Polygon",
        //            "Barcode",
        //        },
        //    };

        //    var reportToLoad = model.ReportsList[0];
        //    if (reportIndex >= 0 && reportIndex < model.ReportsList.Length)
        //        reportToLoad = model.ReportsList[reportIndex.Value];

        //    model.WebReport.Report.Load(Path.Combine(_dataSetService.ReportsPath, $"{reportToLoad}.frx"));

        //    model.WebReport.Report.RegisterData(_dataSetService.DataSet, "NorthWind");

        //    //model.WebReport.SinglePage = true;

        //    model.WebReport.DesignerPath = "/WebReportDesigner/index.html";
        //    //model.WebReport.Designer.SaveCallBack = "/SaveDesignedReport";
        //    model.WebReport.DesignerSaveMethod = (string reportID, string filename, string report) =>
        //    {
        //        string webRootPath = _hostingEnvironment.WebRootPath;

        //        string pathToSave = Path.Combine(webRootPath, "DesignedReports", filename);
        //        if (!Directory.Exists(pathToSave))
        //            Directory.CreateDirectory(Path.GetDirectoryName(pathToSave));

        //        System.IO.File.WriteAllTextAsync(pathToSave, report);

        //        return "OK";
        //    };

        //    return model;

        //}
        #endregion

        public async Task<DataTable> GetTaskStatusReport(TaskStatusReportRequestModel taskStatusReportRequest)
        {
            //List<TaskStatusReportViewModel> taskStatusReport = new();
            DataTable dt = new DataTable();
            //string url = $"http://localhost/CCMS/CCMS/ReportPopup.aspx?Report=TaskStatus.rpt&ReportTitle=Task%20Status%20Report&FromDate={taskStatusReportRequest.FromDate.Date.ToString("MM/dd/yyyy")}&ToDate={taskStatusReportRequest.ToDate.Date.ToString("MM/dd/yyyy")}&GeneratedBy={logedInUser}";
            try
            {
                //var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                //    {
                //        options.IntervalBeforeClose = 4000;
                //    });
                //}
                //else
                //{
                //taskStatusReportRequest.SelectedAtms = (List<string>)selectAtmResponse.Data;
                //string serializedData = JsonConvert.SerializeObject(taskStatusReportRequest);
                //var jsonContent = JsonConvert.SerializeObject(serializedData);
                //HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseURl}GetTaskStatusReport", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{

                //var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                (taskStatusReportRequest.SelectedAtms, taskStatusReportRequest.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (taskStatusReportRequest?.SelectedAtms?.Count > 0)
                {

                    _logger.LogWarning("[TaskStatusReportsService:GetTaskStatusReport] going in GetTaskStatusReport middleware service");
                    var responseModel = ServiceMw.GetTaskStatusReport(taskStatusReportRequest);
                    _logger.LogWarning("[TaskStatusReportsService:GetTaskStatusReport] return from GetTaskStatusReport middleware service");

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
                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                        {
                            _logger.LogError($"Exception at GetTaskStatusReport as: {responseModel.Message}");
                        }
                        return dt;
                    }


                    if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
                    {
                        await _notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                    //}
                    //else
                    //{
                    //    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });

                    //    _logger.LogError($"API error at GetTaskStatusReport, responseBody: {responseBody}");
                    //}
                    //}
                }
                else
                {
                    await _notificationService.Error($"Please select atm.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetTaskStatusReport as: {ex.Message}");
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });

            }
            return dt;
        }
    }

}
