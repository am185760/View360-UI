using Azure;
using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using EView360.Data;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using static EView360.Data.Enumerations;
using AuditLogViewModel = Common.ViewModel.AuditLogViewModel;

namespace EView360.Services
{
    public class UserManagementService
    {
        private static HttpClient client { get; set; }
        private ILogger _logger { get; set; }
        private ApiUrl _apiUrl { get; }
        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;
        private static string? BaseUrl { get; set; }
        private AuditLogService auditService { get; set; }
        public long userId { get; set; }
        private AuditLogViewModel auditData;

        public UserManagementService(HttpClient httpClient, ILogger<Atm> logger, IOptions<ApiUrl> apiUrl, INotificationService notificationService, IMessageService messageService, AuditLogService auditService)
        {
            _logger = logger;
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Users}UserManagement/").ToString();
            _messageService = messageService;
            _notificationService = notificationService;
            this.auditService = auditService;
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            List<UserViewModel> responseList = new();
            try
            {
                _logger.LogWarning("[UserManagementService:GetAsync] going in GetAsync Users API");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetUsers");
                _logger.LogWarning("[UserManagementService:GetAsync] returning from GetAsync Users API");

                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<UserViewModel>>(responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception at GetUsers as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return await Task.FromResult(responseList);
        }

        public async Task<UserViewModel> GetNewUser()
        {
            UserViewModel responseList = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetNewUser");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<UserViewModel>(responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception at GetUsers as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return await Task.FromResult(responseList);
        }

        public async Task<List<string>> GetAlertTypes()
        {
            List<string> alerts = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAlertTypes");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    alerts = JsonConvert.DeserializeObject<List<string>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at User Management, GetAlertTypes: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAlertTypes as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
                    
            }
            return alerts;
        }

        public async Task<string> InsertUser(UserViewModel user)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync($"{BaseUrl}CreateUser", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Successfully Created", "User has been successfully created");
                    await auditService.InsertAuditLogEntry($"{user.User?.UserFullName} new user added", userId, (long)Permissions.CreateUser);
                    return "success";
                }

                _logger.LogError($"API error at User Management, InsertUser: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at InsertUser: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";

        }

        public async Task<string> UpdateUser(UserViewModel user)
        {
            try
            {
                //  auditData = new AuditLogViewModel() { UserId = userId, RightId = (int)Permissions.ModifyUser, Message = $"{user.User.UserFullName} user updated." };

                //PostContentViewModel postContent = new PostContentViewModel() { AuditData = auditData, PostObj = user };

                var jsonContent = JsonConvert.SerializeObject(user);

                //var jsonContent = JsonConvert.SerializeObject(postContent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateUser/{user}", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Successfully Updated", "User has been successfully updated");
                    await auditService.InsertAuditLogEntry($"{user.User?.UserFullName} user updated", userId, (long)Permissions.ModifyUser);
                    return "success";
                }

                _logger.LogError($"API error at User Management, UpdateUser: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateUser: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";

        }

        public async Task<string> UpdateUserPassword(ChangePasswordRequestModel user)
        {
            try
            {                
                var jsonContent = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateUserPassword/{user}", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Successfully Updated", "Password has been successfully updated");
                    await auditService.InsertAuditLogEntry($"{user.Password} user updated", userId, (long)Permissions.ModifyUser);
                    return "success";
                }
                else 
                {
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        await RenderErrorBox("Error", responseBody);

                    }
                    else
                    {
                        await RenderErrorBox("Error", result.ToString());
                    }

                }

                _logger.LogError($"API error at UserManagementService , UpdateUserPassword  response : {responseBody} , result : {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateUserPassword: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";

        }

        public async Task<string> DeleteUser(long id,string userName)
        {
            try
            {
                using HttpResponseMessage result = client.DeleteAsync($"{BaseUrl}DeleteUser/{id}").Result;
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Successfully Deleted", "User has been successfully deleted");
                    await auditService.InsertAuditLogEntry($"{userName} user deleted", userId, (long)Permissions.DeleteUser);
                    return "success";
                }

                _logger.LogError($"API error at User Management, DeleteUser: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeleteUser: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during deletion, check the logs..";
        }

        public async Task<string> ChangeUserStatus(long userId, bool status, string userName)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(userId);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}ChangeUserStatus/{userId}", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await RenderSuccessBox("Status successfully changed", $"User status set to {responseBody}");

                    if(status)
                        await auditService.InsertAuditLogEntry($"{userName} user status changed to inactive", userId, (long)Permissions.DeactivateUser);
                    else
                        await auditService.InsertAuditLogEntry($"{userName} user status changed to active", userId, (long)Permissions.ActivateUser);

                    return "success";
                }

                _logger.LogError($"API error at User Management, ChangeUserStatus: {responseBody}");
                await RenderErrorBox("Error", responseBody);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at ChangeUserStatus: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";
        }

        public async Task<RightsViewModel> GetRightsByType()
        {
            RightsViewModel rights = new();
            try
            {

                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetRightsByType");
                

                var responseBody = await response.Content.ReadAsStringAsync();                

                if (!string.IsNullOrEmpty(responseBody))
                {
                    rights = JsonConvert.DeserializeObject<RightsViewModel>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at User Management, GetRightsByType: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetRightsByType as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return rights;
        }

        public async Task<List<AppUserDropdownViewModel>> GetAllUsers()
        {
            List<AppUserDropdownViewModel> appUser = new List<AppUserDropdownViewModel>();

            try
            {
                BaseModel responseModel = new();
                HttpResponseMessage result = await client.GetAsync($"{BaseUrl}GetAllUsers");
                var responseBody = await result.Content.ReadAsStringAsync();

                _logger.LogInformation($"HTTP {(int)result.StatusCode} Response Body: {responseBody}");

                if (result.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        appUser = JsonConvert.DeserializeObject<List<AppUserDropdownViewModel>>(responseModel.Data.ToString());
                    }
                    else
                    {
                        _logger.LogError($"Exception at GetAllUsers as: {responseModel.Message}");
                        await RenderErrorBox("Error", responseModel.Message);
                    }
                }
                else
                {
                    _logger.LogError($"API error at GetAllUsers, responseBody: {responseBody}, message : {responseModel.Message}");
                    await RenderErrorBox("Error", responseBody);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAllUsers as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return appUser;
        }

        public async Task RenderSuccessBox(string title, string message)
        {
            await _notificationService.Success(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }

        public async Task RenderErrorBox(string title, string message)
        {
            await _notificationService.Error(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }
    }
}

