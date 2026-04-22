using EView360Models.Core;
using EView360Models.ViewModels;
using EView360.Common;
using EView360.Data;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Dynamic;
using Blazorise;
using EView360Models.RequestModel;
using Common.RequestModel;
using static EView360.Data.Enumerations;
using EView360.Pages.Operations;
using BitMiracle.LibTiff.Classic;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.AspNetCore.Http.HttpResults;
using Azure;
using DataRequestor;
using NPOI.HPSF;

namespace EView360.Services.Operations
{
    public class AtmTaskService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private AtmService atmService { get; set; }

        private INotificationService _notificationService;

        private readonly IConfiguration _configuration;
        private List<Atm>? AtmList { get; set; }
        private static string? BaseUrl { get; set; }
        private CommonServices _commonServices { get; set; }
        private TaskService _taskService { get; set; }
        private AuditLogService _auditService { get; set; }
        public AtmTaskService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, IConfiguration configuration, INotificationService notificationService, AtmService atmService, CommonServices commonServices, TaskService taskService, AuditLogService auditService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + _apiUrl.Operations).ToString();
            _logger = logger;
            _atmTreeService = atmTreeService;
            _configuration = configuration;
            _notificationService = notificationService;
            this.atmService = atmService;
            _commonServices = commonServices;
            _taskService = taskService;
            _auditService = auditService;
        }
        public async Task GetAtmList()
        {
            AtmList = await _atmTreeService.GetAtmList();
        }


        public async Task<List<TaskTypeViewModel>> GetTaskTypes()
        {
            List<TaskTypeViewModel> responseList = new();
            try
            {
                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in Task/GetTaskTypes  : {DateTime.Now.ToString()}");

                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}Task/GetTaskTypes");
                string responseBody = await response.Content.ReadAsStringAsync();

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from Task/GetTaskTypes  : {DateTime.Now.ToString()}");

                
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<TaskTypeViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Task, GetTaskTypes: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetTaskTypes as: {ex.Message}");
            }
            return responseList;
        }



        public async void GetAtmTasksAsync(Executor _executor, int pageNo, DateTime fromDate, DateTime toDate, string filter, string orderBy, bool readFromCache, int? archiveYear = null)
        {
            try
            {
                int offSet = _commonServices.GetDatabaseOffset(pageNo);
                List<long>? selectedAtmIds = await _atmTreeService?.GetSelectedAtmId();
                if (selectedAtmIds?.Count > 0)
                {
                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.GetAtmTask  : {DateTime.Now.ToString()}");
                    _taskService.GetAtmTask(_executor, fromDate, toDate, filter, orderBy, offSet, _configuration.GetValue<int>("RecordPerPage"), selectedAtmIds.ConvertAll(x => x.ToString()), readFromCache, archiveYear);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmTasksAsync as: {ex.Message}");
            }
        }

        public async Task<(bool isSucess, string DataFile)> GetDataFileAsync(long taskId, long? fileTypeId, long atmId, long taskTypeId)
        {
            string dataFile = string.Empty;
            try
            {
                string errorMsg = string.Empty;

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.GetDataFile  : {DateTime.Now.ToString()}");

                List<string> dataFiles = _taskService.GetDataFile(taskId.ToString(), fileTypeId.ToString(), atmId.ToString(), taskTypeId.ToString(), ref errorMsg);

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.GetDataFile  : {DateTime.Now.ToString()}");

                if (!string.IsNullOrEmpty(errorMsg))
                {
                    _logger.LogError($"Error at GetDataFileAsync as: {errorMsg}");
                }

                if (dataFiles?.Count > 0)
                {
                    dataFile = dataFiles.Count > 1 ? string.Concat(dataFiles) : dataFiles[0];                  

                    return (isSucess: true, dataFile);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetDataFileAsync as: {ex.Message}");
            }
            return (isSucess: false, dataFile);
        }

        public async Task<List<FileTypeViewModel>> GetAllFileTypeAsync()
        {
            List<FileTypeViewModel>? fileTypes = new();
            try
            {

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in Core/GetFileTypes  : {DateTime.Now.ToString()}");

                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}Core/GetFileTypes");

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from Core/GetFileTypes  : {DateTime.Now.ToString()}");
                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    fileTypes = JsonConvert.DeserializeObject<List<FileTypeViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Operation, Core: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAllFileTypeAsync as: {ex.Message}");
            }
            return fileTypes;
        }

        public async Task<string> UpdateTaskStatus(long id, long? fileTypeId, string status, long atmId)
        {
            try
            {
                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.UpdateTaskStatus  : {DateTime.Now.ToString()}");

                string response = _taskService.UpdateTaskStatus(id, fileTypeId, status, new List<string>() { atmId.ToString() });

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.UpdateTaskStatus  : {DateTime.Now.ToString()}");

                
                if (response == "success") return response;

                _logger.LogError($"API error at Task, UpdateTaskStatus: {response}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateTaskStatus: {ex.Message}");
            }
            return "Error occured during update, check the logs..";
        }

        public async Task<string?> GetSelectedAtm()
        {
            List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
            if (selectedAtmIds is null || !selectedAtmIds.Any())
            {
                return Constants.Messages.AtmSelectionMsg;
            }
            else if (selectedAtmIds.Count > 1)
            {
                return Constants.Messages.AtmSingleSelectionMsg;
            }
            else
            {
                return AtmList?.FirstOrDefault(x => x.AtmId == selectedAtmIds.First())?.Title;
            }
        }
        public async Task<string> DownloadFileTask(long fileTypeId)
        {
            try
            {
                List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
                if (selectedAtmIds is null || !selectedAtmIds.Any())
                {
                    return Constants.Messages.AtmSelectionMsg;
                }
                else if (selectedAtmIds.Count > 1)
                {
                    return Constants.Messages.AtmSingleSelectionMsg;
                }
                else
                {
                    string errorMsg = string.Empty;

                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.CheckTaskExistForAtms  : {DateTime.Now.ToString()}");

                    List<AtmTaskViewModel> atmTasks = _taskService.CheckTaskExistForAtms("25", fileTypeId.ToString(), selectedAtmIds.ConvertAll(x => x.ToString()), ref errorMsg);

                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.CheckTaskExistForAtms  : {DateTime.Now.ToString()}");

                    
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        _logger.LogError($"issue at Task, CheckTaskExistForAtms as: {errorMsg}");
                        //return "Error occured during DownloadFileTask, check the logs..";
                    }
                    if (atmTasks?.Count > 0)
                    {
                        return Constants.Messages.AtmAlreadyDwnldMsg;
                    }
                    else
                    {
                        _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.CreateDownloadFileTask  : {DateTime.Now.ToString()}");

                        string response = _taskService.CreateDownloadFileTask(UserId, fileTypeId, selectedAtmIds[0].ToString());

                        _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.CreateDownloadFileTask  : {DateTime.Now.ToString()}");


                        if (response == "success")
                        {
                            string fileName = fileTypeId == 1 ? "Counters" : "EJ-Data";
                            await _auditService.InsertAuditLogEntry($"Download {fileName} File Task created for Atm:  {_atmTreeService.AtmList.FirstOrDefault(x => x.AtmId == selectedAtmIds[0])?.Title} ", UserId, (long)Permissions.ScheduleFileDownload);
                            return "success";
                        }                                                   

                        _logger.LogError($"API issue at Task, CreateDownloadFileTask as: {response}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DownloadFileTask: {ex.Message}");
            }
            return "Error occured during DownloadFileTask, check the logs..";
        }

        public async Task<string> ScheduleConfiguration(List<long>? selectedAtmIds = null)
        {
            try
            {
                if (selectedAtmIds is null || !selectedAtmIds.Any())
                    selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
                
                if (selectedAtmIds is null || !selectedAtmIds.Any())
                {
                    return Constants.Messages.AtmSelectionMsg;
                }
                else
                {
                    string errorMsg = string.Empty;

                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.CheckTaskExistForAtms  : {DateTime.Now.ToString()}");
                    List<AtmTaskViewModel> atmTasks = _taskService.CheckTaskExistForAtms("5", "1", selectedAtmIds.ConvertAll(x => x.ToString()), ref errorMsg);
                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.CheckTaskExistForAtms  : {DateTime.Now.ToString()}");

                    
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        _logger.LogError($"issue at Task, CheckTaskExistForAtms as: {errorMsg}");
                        //return "Error occured during DownloadFileTask, check the logs..";
                    }
                    List<long> atmsThatAreNotSchedule = selectedAtmIds;
                    List<long> atmsThatAreSchedule = new();
                    if (atmTasks?.Count > 0)
                    {
                        atmsThatAreSchedule = atmTasks.Select(x => x.AtmId).ToList();
                        atmsThatAreNotSchedule = atmsThatAreNotSchedule.Where(x => atmTasks.All(y => y.AtmId != x)).ToList();
                    }
                    if (atmsThatAreNotSchedule?.Count > 0)
                    {
                        string createTaskResponse = await CreateConfigurationTask(atmsThatAreNotSchedule);
                        if (createTaskResponse == "success")
                        {
                            string atmTitles = string.Join(",", _atmTreeService.AtmList.Where(x => atmsThatAreNotSchedule.Any(y => y == x.AtmId)).Select(x => x.Title).ToList());
                            await _auditService.InsertAuditLogEntry($"Create Configuration Task for Atm's:  {atmTitles}", UserId, (long)Permissions.ScheduleConfiguration);

                            if (atmsThatAreSchedule?.Count > 0)
                                _logger.LogError($"following atm/s are already schedule for configuration: {string.Join(",", atmsThatAreSchedule)}");
                            return (atmsThatAreSchedule?.Count > 0) ? Constants.Messages.AllAtmSucessWithExceptMsg : Constants.Messages.AllAtmSucessMsg;
                        }
                    }
                    else if (atmsThatAreSchedule?.Count > 0)
                    {
                        return Constants.Messages.AtmAlreadyScheduleMsg;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at ScheduleConfiguration: {ex.Message}");
            }
            return "Error occured during ScheduleConfiguration, check the logs..";
        }

        public async Task<string> CreateConfigurationTask(List<long> atmIds)
        {
            try
            {
                if (atmIds?.Count > 0)
                {
                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.CreateConfigurationTask  : {DateTime.Now.ToString()}");
                    string response = _taskService.CreateConfigurationTask(UserId, atmIds.ConvertAll(x => x.ToString()));
                    _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.CreateConfigurationTask  : {DateTime.Now.ToString()}");
                    
                    if (response == "success")
                        return "success";

                    _logger.LogError($"Issue at Task, CreateConfigurationTask as: {response}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CreateConfigurationTask : {ex.Message}");
            }
            return "An error occured while scheduling conf. task";
        }

        public async Task<string> ReparseTask(long id, long atmId)
        {
            try
            {
                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.ReparseTask  : {DateTime.Now.ToString()}");
                string response = _taskService.ReparseTask(id, new List<string>() { atmId.ToString() });
                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.ReparseTask  : {DateTime.Now.ToString()}");
                
                if (response == "success") return "success";

                _logger.LogError($"API error at Task, ReparseTask: {response}");                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at ReparseTask: {ex.Message}");
            }
            return "Error occured during reparse task, check the logs..";
        }

        public async Task<List<string>> GetStatusFriendlyName()
        {
            List<string> status = new();
            try
            {
                var statusRequestModel = new StatusRequestModel();
                var downloadStates = Enum.GetValues(typeof(DownloadStates));
                var uploadStates = Enum.GetValues(typeof(UploadStates));
                string error = string.Empty;
                
                List<string> enumString = new List<string>();

                for (int counter = 0; counter < downloadStates.Length; counter++)
                {
                    string tempString = downloadStates.GetValue(counter).ToString();
                    enumString.Add(tempString);
                }
                for (int counter = 0; counter < uploadStates.Length; counter++)
                {
                    string tempString = uploadStates.GetValue(counter).ToString();
                    enumString.Add(tempString);
                }

                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _taskService.GetAllTaskStatus  : {DateTime.Now.ToString()}");
                status = _taskService.GetAllTaskStatus(enumString, ref error);
                _logger.LogWarning($"AtmTaskService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _taskService.GetAllTaskStatus  : {DateTime.Now.ToString()}");
                

                if (!string.IsNullOrEmpty(error))
                {
                    await _notificationService.Error(error, "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at TaskService, GetAllTaskStatus: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetStatusFriendlyName as: {ex.Message}");
            }
            return status;
        }


    }
}
