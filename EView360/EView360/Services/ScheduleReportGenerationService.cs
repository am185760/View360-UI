using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using EView360.Data;
using EView360.Services.Operations;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace EView360.Services
{
    public class ScheduleReportGenerationService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }

        private ATMTreeViewRepository aTMTreeViewRepository { get; set; }

        string? BaseURL;
        private ILogger _logger { get; set; }
        public List<Atm> userAtmList { get; set; }
        private INotificationService _notificationService;

        private AtmService atmService;
        public ScheduleReportGenerationService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<BnaTranactionsService> logger, INotificationService notificationService, AtmService atmService, ATMTreeViewRepository aTMTreeViewRepository)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseURL = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Operations}ScheduleReports/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.atmService = atmService;
            this.aTMTreeViewRepository = aTMTreeViewRepository;
        }

        public async Task<List<ScheduleReportsViewModel>> GetScheduleReportGeneration()
        {
            List<ScheduleReportsViewModel> scheduleReports = new();
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                if (!selectAtmResponse.IsSuccess)
                {
                    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                    await Task.Delay(2000);
                    var selectedRegionId = aTMTreeViewRepository.GetSelectedRegionId();
                    if (selectedRegionId == null)
                    {
                        await _notificationService.Error($"Please Select atm", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return scheduleReports;
                    }

                    if (selectedAtmIds?.Count > 0)
                    {
                        var scheduleReportsRequestModel = new ScheduleReportsRequestModel();
                        scheduleReportsRequestModel.AtmIds = selectedAtmIds;
                        scheduleReportsRequestModel.RegionIds = selectedRegionId.ToString();
                        var jsonContent = JsonConvert.SerializeObject(scheduleReportsRequestModel);
                        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetScheduleReports", content);
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

                            _logger.LogError($"API error at GetScheduleReportGeneration, responseBody: {responseBody}");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetScheduleReportGeneration as: {ex.Message}");
            }
            return scheduleReports;
        }

        public async Task<List<ReportGenerationViewModel>> GetReportGeneration(int scheduleReportId)
        {
            List<ReportGenerationViewModel> scheduleReports = new();
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                if (!selectAtmResponse.IsSuccess)
                {
                    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                    var selectedRegionId = aTMTreeViewRepository.GetSelectedRegionId();
                    if (selectedRegionId == null)
                    {
                        await _notificationService.Error($"Please Select atm", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return scheduleReports;
                    }

                    if (selectedAtmIds?.Count > 0)
                    {
                        var scheduleReportsRequestModel = new ReportGenerationRequestModel();
                        scheduleReportsRequestModel.selectedAtms = selectedAtmIds;
                        scheduleReportsRequestModel.ScheduleReportId = scheduleReportId;
                        var jsonContent = JsonConvert.SerializeObject(scheduleReportsRequestModel);
                        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync($"{BaseURL}GetReportGenerationSchedule", content);
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                        {

                            var responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                            if (responseModel.IsSuccess)
                            {
                                scheduleReports = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());
                            }
                            else
                            {
                                scheduleReports = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());

                                await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                                {
                                    options.IntervalBeforeClose = 4000;
                                });
                                return scheduleReports;
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

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReportGeneration as: {ex.Message}");
            }
            return scheduleReports;
        }

        public async Task UpdateReportGeneration(ScheduleReportsViewModel scheduleReport, List<string> reportGenerationTime)
        {
            try
            {
                var selectAtmResponse = await atmService.GetMultipleSelectedAtms();
                if (!selectAtmResponse.IsSuccess)
                {
                    await _notificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                    var selectedRegionId = aTMTreeViewRepository.GetSelectedRegionId();
                    if (selectedRegionId == null)
                    {
                        await _notificationService.Error($"Please Select atm", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        return;
                    }

                    if (selectedAtmIds?.Count > 0)
                    {
                        var scheduleReportsModel = new UpdateScheduleReportRequestModel();
                        //scheduleReportsModel.SelectedAtms = selectedAtmIds;
                        //scheduleReportsModel.ScheduleReportId = scheduleReport.ReportScheduleId;
                        scheduleReportsModel.ScheduleReportTime = reportGenerationTime;
                        scheduleReportsModel.Recipitents = scheduleReport.Recipitents;
                        scheduleReportsModel.ReportFriendlyName = scheduleReport.ReportFriendlyName;
                        scheduleReportsModel.ReportName = scheduleReport.ReportName;
                        scheduleReportsModel.RetryCount = scheduleReport.RetryCount;
                        //scheduleReportsModel.ExportDataOlderThan = scheduleReport.ExportDataOlderThan;
                        //scheduleReportsModel.MinutesToScheduleAgain = scheduleReport.MinutesToScheduleAgain;
                        scheduleReportsModel.ReportsPhysicalPath = scheduleReport.ReportsPhysicalPath;
                        scheduleReportsModel.ReportstTempPath = scheduleReport.ReportstTempPath;
                        scheduleReportsModel.ExportExcelChecked = scheduleReport.ExportExcelChecked;
                        scheduleReportsModel.ExportPDFChecked = scheduleReport.ExportPDFChecked;
                        scheduleReportsModel.ScheduleType = scheduleReport.ScheduleType;
                        //scheduleReportsModel.ExportType = scheduleReport.ExportType;

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
                            }
                            else
                            {
                                //scheduleReports = JsonConvert.DeserializeObject<List<ReportGenerationViewModel>>(responseModel.Data.ToString());

                                await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                                {
                                    options.IntervalBeforeClose = 4000;
                                });
                                return;
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

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetReportGeneration as: {ex.Message}");
            }
            return;
        }

        public async Task<bool> DeleteScheduleReport(long scheduleReportId)
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
