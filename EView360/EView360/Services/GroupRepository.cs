using EView360Models.Core;
using EView360.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using EView360Models.ViewModels;
using Common.ViewModel;
using static EView360.Data.Enumerations;
using Blazorise;
using NoteSetTypeViewModel = Common.ViewModel.NoteSetTypeViewModel;

namespace EView360.Services
{
    public class GroupRepository
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        private static string? BaseUrl { get; set; }
        private ILogger _logger { get; set; }
        private AuditLogService auditService { get; set; }
        public long userId { get; set; }
        private INotificationService _notificationService;

        public GroupRepository(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger, AuditLogService auditService, INotificationService notificationService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Group}GroupUsers/").ToString();
            _logger = logger;
            this.auditService = auditService;
            _notificationService = notificationService;
        }


        public async Task<List<Right>> GetRightsAsync()
        {
            List<Right> rights = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetRights");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    rights = JsonConvert.DeserializeObject<List<Right>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at GroupUsers, GetRights: {responseBody}");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception at GetRightsAsync: {ex.Message}");
            }
            
            return rights;
        }

        public async Task<List<GroupViewModel>> GetGroupDetailAsync()
        {
            List<GroupViewModel> groupViews = new();
            _logger.LogInformation($"Method: {MethodBase.GetCurrentMethod()?.ReflectedType?.Name}");

            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetGroupDetails");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    groupViews = JsonConvert.DeserializeObject<List<GroupViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at GroupUsers, GetGroupDetails: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetGroupDetailAsync: {ex.Message}");
            }

            return groupViews;
        }

        public async Task<string> CreateGroupAndRights(Group group, List<GroupRight> groupRights)
        {
            try
            {
                string groupId = await CreateGroup(group);
                if (groupId == "error") { return groupId; }

                if (!string.IsNullOrEmpty(groupId))
                {
                    string createResponse = await CreateGroupRights(groupRights.Select(x => { x.GroupId = long.Parse(groupId); return x; }).ToList());
                    if (createResponse == "success")
                    {
                        await auditService.InsertAuditLogEntry($"{group.GroupName} group created.", userId, (long)Permissions.CreateGroup);
                        return createResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CreateGroupAndRights: {ex.Message}");
            }
            return "Error occured during creation, check the logs..";
        }

        public async Task<string> CreateGroup(Group group)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(group);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync($"{BaseUrl}CreateGroup", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) { return responseBody; }

                _logger.LogError($"API error at GroupUsers, CreateGroup: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CreateGroup: {ex.Message}");
            }
            return "error";
        }

        public async Task<string> CreateGroupRights(List<GroupRight> groupRights)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(groupRights);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync($"{BaseUrl}CreateGroupRights", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) 
                { 
                    return "success"; 
                }

                _logger.LogError($"API error at GroupUsers, CreateGroupRights: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CreateGroupRights: {ex.Message}");
            }
            return "error";
        }

        public async Task<string> UpdateGroup(GroupRightVM groupModel)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(groupModel);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateGroup", content);
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) { return "success"; }
                _logger.LogError($"API error at GroupUsers, UpdateGroup: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateGroup: {ex.Message}");
            }
            return "error";
        }

        public async Task<string> UpdateGroupAndRights(Group group, long groupId, List<GroupRight> groupRights)
        {
            try
            {
                GroupRightVM vM = new()
                {
                    group = group,
                    groupRights = groupRights,
                    AuditData = new()
                    {
                        UserId = userId,
                        RightId = (int)Permissions.ModifyGroup,
                        Message = $"group: {group.GroupName} updated."
                    }
                };
                string updateGrpResponse = await UpdateGroup(vM);
                return updateGrpResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateGroupAndRights: {ex.Message}");
            }
            return "error";
        }

        public async Task<string> DeleteGroup(long id)
        {
            try
            {
                using HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}DeleteGroup/{id}");
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode) { return "success"; }
                _logger.LogError($"API error at GroupUsers, DeleteGroupRights: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeleteGroup: {ex.Message}");
            }
            return "error";
        }

        public async Task<string> DeleteGroupRights(long groupId)
        {
            try
            {
                using HttpResponseMessage result = await client.DeleteAsync($"{BaseUrl}DeleteGroupRights/{groupId}");
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode) { return "success"; }
                _logger.LogError($"API error at GroupUsers, DeleteGroupRights: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeleteGroupRights: {ex.Message}");
            }
            return "error";
        }

        public async Task<string> DeleteGroupAndRights(long id, string groupName)
        {
            try
            {
                string response = await DeleteGroup(id);
                if (response == "success")
                {
                    string deleteResponse = await DeleteGroupRights(id);
                    if (deleteResponse == "success")
                    {
                        await auditService.InsertAuditLogEntry($"{groupName} group deleted.", userId, (long)Permissions.DeleteGroup);
                        return deleteResponse;
                    }
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeleteGroupAndRights: {ex.Message}");
            }
            return "error";
        }

        public async Task<List<NoteSetTypeViewModel>?> GetNoteSetTypesByUser(long userId)
        {
            List<NoteSetTypeViewModel>? responseList = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{_apiUrl.BaseUrl}NoteSetType/NoteSetType/GetNoteSetTypeByUserId/{userId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<NoteSetTypeViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at GroupRepository, GetNoteSetTypesByUser: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetNoteSetTypesByUser as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return responseList;
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
