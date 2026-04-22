using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using DocumentFormat.OpenXml.Math;
using EView360.Data;
using EView360Models.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Text;
using static EView360.Data.Enumerations;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using DataRequestorMiddleware.Services.Admin;

namespace EView360.Services
{
    public class AtmSetupService
    {
        private static HttpClient client { get; set; }

        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;

        private ILogger _logger { get; set; }
        private ApiUrl _apiUrl { get; }

        public long userId;
        private IJSRuntime JSRuntime { get; set; }
        private static string BaseUrl { get; set; }

        private AuditLogViewModel auditData;
        private IConfiguration configuration;
        public AtmSetupService(HttpClient httpClient, ILogger<Atm> logger, IOptions<ApiUrl> apiUrl, INotificationService notificationService, IMessageService messageService, IJSRuntime jSRuntime, IConfiguration configuration)
        {
            _apiUrl = apiUrl.Value;
            _logger = logger;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.AtmSetup}AtmSetup/").ToString();
            _messageService = messageService;
            _notificationService = notificationService;
            JSRuntime = jSRuntime;
            this.configuration = configuration;
        }
        public async Task<List<Atm>> GetAtmsListAsync()
        {
            List<Atm> atms = new();
            _logger.LogInformation($"Method: {MethodBase.GetCurrentMethod()?.ReflectedType?.Name}");
            try
            {
                atms = await GetAtmByUser(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmsListAsync as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return atms;
        }

        public async Task<List<Atm>> GetAtmByUser(long userId)
        {
            List<Atm> responseList = new();
            try
            {
                _logger.LogWarning("[AtmSetupService:GetAtmByUser] going in GetAtmByUserId Atm Setup API");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAtmByUserId?id={userId}");
                _logger.LogWarning("[AtmSetupService:GetAtmByUser] returning from GetAtmByUserId Atm Setup API");

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<Atm>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at ATMSetup, GetAtmByUser: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmByUser as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return responseList;
        }

        public async Task<List<BulkUpdateAtmViewModel>> GetAtmFieldByUserId()
        {
            List<BulkUpdateAtmViewModel> responseList = new();
            try
            {
                _logger.LogWarning("[AtmSetupService:GetAtmFieldByUserId] going in GetAtmFieldByUserId Atm Setup API");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAtmFieldByUserId?userId={userId}");
                _logger.LogWarning("[AtmSetupService:GetAtmFieldByUserId] returning from GetAtmFieldByUserId Atm Setup API");

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<BulkUpdateAtmViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at ATMSetup, GetAtmFieldByUserId: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmFieldByUserId as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return responseList;
        }

        public async Task<string[]> InsertAtm(Atm atm)
        {
            string responseBody = string.Empty;
            try
            {
               
                auditData = new AuditLogViewModel() { UserId = userId, RightId = (int)Permissions.CreateATMs, Message = $"{atm.Title} new ATM added." };

                PostContentViewModel postContent = new PostContentViewModel() { AuditData = auditData, PostObj = atm };

                var jsonContent = JsonConvert.SerializeObject(postContent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync($"{BaseUrl}CreateAtm", content);
                responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var serverMaxProcessors = configuration.GetSection("ServersMaxProcessor").Get<Dictionary<string, int>>();

                    var atmHandler = new AtmHandlerService();
                     var reponse = await atmHandler.HandleAtms(responseBody, serverMaxProcessors);
                    if (reponse.IsSuccess)
                    {
                        await RenderSuccessBox("Successfully Added", "Atm has been successfully added");
                    }
                    else
                    {
                        await RenderErrorBox("Successfully Added But Failed To Assign Server", reponse.Message);
                        _logger.LogError($"Exception at InsertAtm --> HandleAtms: {reponse.Message}");

                    }
                    return new string[] { "success", responseBody };
                }

                _logger.LogError($"API error at ATMSetup, InsertAtm: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at InsertAtm: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return new string[] { "Error occured during creation, check the logs..", responseBody };
        }
      
        public async Task<string> DeleteAtm(long id, string title)
        {
            try
            {
                auditData = new AuditLogViewModel() { UserId = userId, RightId = (int)Permissions.DeleteATM, Message = $"{title} ATM deleted." };



                using HttpResponseMessage result = await client.DeleteAsync($"{BaseUrl}DeleteAtm/{id}/{auditData.UserId}/{auditData.RightId}/{auditData.Message}");

                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Successfully Deleted", "Atm has been successfully deleted");
                    return "success";
                }

                _logger.LogError($"API error at AtmSetup, DeleteAtm: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeletAtm: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during deletion, check the logs..";
        }

        public async Task<string> UpdateAtm(Atm atm)
        {
            try
            {
                auditData = new AuditLogViewModel() { UserId = userId, RightId = (int)Permissions.ModifyATM, Message = $"{atm.Title} ATM updated." };

                PostContentViewModel postContent = new PostContentViewModel() { AuditData = auditData, PostObj = atm };

                var jsonContent = JsonConvert.SerializeObject(postContent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateAtm", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return "success";
                }

                _logger.LogError($"API error at AtmSetup, UpdateAtm: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateAtm: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";

        }

        public async Task BulkUpdateAtm(List<BulkUpdateAtmViewModel> atmList)
        {
            try
            {
                auditData = new AuditLogViewModel() { UserId = userId, RightId = (int)Permissions.ModifyATM, Message = $"Bulk ATM update." };

                PostContentViewModel postContent = new PostContentViewModel() { AuditData = auditData, PostObj = atmList };

                var jsonContent = JsonConvert.SerializeObject(postContent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}BulkUpdateAtm", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Success", "ATMs updated successfully.");
                }

                _logger.LogError($"API error at AtmSetup, UpdateAtm: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateAtm: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
        }

        public async Task<string> UpdateAtmUsers(List<AppUser> userAtms, long AtmId)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(userAtms);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateUserAtms/{userAtms}/{AtmId}", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return "success";
                }

                _logger.LogError($"API error at AtmSetup, UpdateUserAtms: {responseBody}");
                await RenderErrorBox("Error", responseBody);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateUserAtms: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";

        }

        public async Task<List<NoteSetType>> GetNoteSetTypeListAsync()
        {
            List<EView360Models.Core.NoteSetType> noteSetTypes = new();
            _logger.LogInformation($"Method: {MethodBase.GetCurrentMethod()?.ReflectedType?.Name}");

            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetNoteSetTypeList");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseBody))
                {
                    noteSetTypes = JsonConvert.DeserializeObject<List<EView360Models.Core.NoteSetType>>(responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception at GetNoteSetTypeListAsync: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return await Task.FromResult(noteSetTypes);
        }

        public async Task<List<Cit>> GetCitListAsync()
        {
            List<EView360Models.Core.Cit> cits = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetCitList");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    cits = JsonConvert.DeserializeObject<List<EView360Models.Core.Cit>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AtmSetup, GetCitListAsync: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception at GetCitListAsync as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return cits;
        }

        public async Task<List<TaskType>> GetAtmTaskType()
        {
            List<EView360Models.Core.TaskType> taskType = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAtmTaskType");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    taskType = JsonConvert.DeserializeObject<List<EView360Models.Core.TaskType>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AtmSetup, GetAtmTaskType: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception at GetAtmTaskType as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return taskType;
        }

        public async Task<List<AppUser>> GetAppUsersListAsync(long AtmId)
        {
            List<AppUser> appUsers = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAtmUsers/?AtmId={AtmId}");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    appUsers = JsonConvert.DeserializeObject<List<AppUser>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AtmSetup, GetCitListAsync: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception at GetCitListAsync as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return appUsers;
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

        public async Task<List<TerminalType>> GetAtmTerminalType()
        {
            List<TerminalType> responseList = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetVendorsList");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<TerminalType>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at ATMSetup, GetAtmTerminalType: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmTerminalType as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return responseList;
        }

    }

}
