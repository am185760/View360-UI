using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using EView360.Data;
using EView360.Services.Operations;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static EView360.Data.Enumerations;

namespace EView360.Services
{
    public class ScheduleReportService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }

        private ATMTreeViewRepository aTMTreeViewRepository { get; set; }

        string? BaseURL;
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private AuditLogService auditService { get; set; }
        public long userId { get; set; }

        private AtmService atmService;
        public ScheduleReportService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, AtmService atmService, ATMTreeViewRepository aTMTreeViewRepository, AuditLogService auditLogService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            //BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.ReportSchedule}ScheduleReports/").ToString();
            BaseURL = new Uri(_apiUrl.BaseUrl + $"{"ReportSchedule/"}ScheduleReports/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.aTMTreeViewRepository = aTMTreeViewRepository;
            this.auditService = auditLogService;
        }

        public async Task<List<ScheduleReportsViewModel>> GetScheduleReport()
        {
            List<ScheduleReportsViewModel> scheduleReports = new();
            try
            {
                //var selectedRegionId = aTMTreeViewRepository.GetSelectedRegionId();

                HttpResponseMessage response = await client.GetAsync($"{BaseURL}GetScheduleReports");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {

                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        scheduleReports = JsonConvert.DeserializeObject<List<ScheduleReportsViewModel>>(responseModel.Data.ToString());
                    }
                    else
                    {
                        scheduleReports = JsonConvert.DeserializeObject<List<ScheduleReportsViewModel>>(responseModel.Data.ToString());

                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return scheduleReports;
                    }


                    if (responseModel.IsSuccess && (scheduleReports is null || scheduleReports.Count == 0))
                    {
                        await _notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                }
                else
                {
                    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at GetScheduleReport, responseBody: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetScheduleReport as: {ex.Message}");
            }
            return scheduleReports;
        }
        public async Task<List<ReportGenerationViewModel>> GetScheduleReportGeneration(long scheduleReportId)
        {
            List<ReportGenerationViewModel> scheduleReportGeneration = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseURL}GetScheduleReportGeneration/{scheduleReportId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {

                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        scheduleReportGeneration = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());
                    }
                    else
                    {
                        scheduleReportGeneration = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());

                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return scheduleReportGeneration;
                    }


                    //if (responseModel.IsSuccess && (scheduleReportGeneration is null || scheduleReportGeneration.Count == 0))
                    //{
                    //    await _notificationService.Success("No record found", "Succes", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //}
                }
                else
                {
                    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at GetScheduleReportGeneration, responseBody: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetScheduleReportGeneration as: {ex.Message}");
            }
            return scheduleReportGeneration;
        }

        public async Task UpdateReportGeneration(ScheduleReportsViewModel scheduleReport, List<string> reportGenerationTime)
        {
            try
            {
                var scheduleReportsModel = new UpdateScheduleReportRequestModel();
                scheduleReportsModel.ScheduleReportId = scheduleReport.ReportScheduleId;
                scheduleReportsModel.ScheduleReportTime = reportGenerationTime;
                scheduleReportsModel.Recipitents = scheduleReport.Recipitents;
                scheduleReportsModel.ReportFriendlyName = scheduleReport.ReportFriendlyName;
                scheduleReportsModel.ReportName = scheduleReport.ReportName;
                scheduleReportsModel.RetryCount = scheduleReport.RetryCount;
                scheduleReportsModel.ExportDataOlderThan = (int)scheduleReport.ExportDataOlderThan;
                scheduleReportsModel.MinutesToScheduleAgain = (int)scheduleReport.MinutesToScheduleAgain;
                scheduleReportsModel.ReportsPhysicalPath = scheduleReport.ReportsPhysicalPath;
                scheduleReportsModel.ReportstTempPath = scheduleReport.ReportstTempPath;
                scheduleReportsModel.ExportExcelChecked = scheduleReport.ExportExcelChecked;
                scheduleReportsModel.ExportPDFChecked = scheduleReport.ExportPDFChecked;
                scheduleReportsModel.ScheduleType = scheduleReport.ScheduleType;
                scheduleReportsModel.ExportType = scheduleReport.ExportType;

                var jsonContent = JsonConvert.SerializeObject(scheduleReportsModel);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseURL}UpdateScheduleReport", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {

                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        //scheduleReports = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());
                        await _notificationService.Success($"Report Generation Schedule Updated Successfully", "Success", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        await auditService.InsertAuditLogEntry($"{scheduleReportsModel.ReportName} report updated.", userId, (long)Permissions.EditScheduleReports);
                    }
                    else
                    {
                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return;
                    }
                }
                else
                {
                    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at UpdateReportGeneration, responseBody: {responseBody}");
                }



            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateReportGeneration as: {ex.Message}");
            }
            return;
        }

        public async Task<bool> DeleteScheduleReport(long scheduleReportId, string ReportName)
        {
            try
            {

                var scheduleReportsModel = new DeleteScheduleReportRequestModel();
                //scheduleReportsModel.SelectedAtms = selectedAtmIds;
                scheduleReportsModel.ScheduleReportId = scheduleReportId;

                var jsonContent = JsonConvert.SerializeObject(scheduleReportsModel);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseURL}DeleteScheduleReport", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {

                    var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        //scheduleReports = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());
                        await _notificationService.Success($"Report Generation Schedule Updated Successfully", "Success", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        await auditService.InsertAuditLogEntry($"{ReportName} report deleted.", userId, (long)Permissions.DeleteReportSchedule);
                    }
                    else
                    {
                        //scheduleReports = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());

                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return false;
                    }


                    //if (responseModel.IsSuccess && (scheduleReports is null || scheduleReports.Count == 0))
                    //{
                    //    await _notificationService.Success("No record found", "Succes", (options) =>
                    //    {
                    //        options.IntervalBeforeClose = 4000;
                    //    });
                    //}
                }
                else
                {
                    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at GetReportGeneration, responseBody: {responseBody}");
                }



            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReportGeneration as: {ex.Message}");
            }
            return true;
        }

    }
}
