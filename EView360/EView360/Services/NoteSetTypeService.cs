using EView360Models.Core;
using EView360.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Blazorise;
using static EView360.Data.Enumerations;
using Common.ViewModel;

namespace EView360.Services
{
    public class NoteSetTypeService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private INotificationService _notificationService;
        private AuditLogService auditService { get; set; }

        private static string? BaseUrl { get; set; }

        public NoteSetTypeService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger, INotificationService notificationService, AuditLogService auditService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.NoteSetType}NoteSetType/").ToString();
            _logger = logger;
            _notificationService = notificationService;
            this.auditService = auditService;
        }

        public async Task<List<NoteSetType>> GetNoteSetTypeListAsync()
        {
            bool isError = false;
            List<NoteSetType> noteSetTypes = new();            
            try
            {
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetNoteSetTypeByUserId  : {DateTime.Now.ToString()}");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetNoteSetTypeByUserId/{UserId}");
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from GetNoteSetTypeByUserId  : {DateTime.Now.ToString()}");

                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    noteSetTypes = JsonConvert.DeserializeObject<List<NoteSetType>>(responseBody);
                    if (noteSetTypes?.Count > 0)
                    {
                        foreach (NoteSetType item in noteSetTypes)
                        {
                            if (item.DenominationType1 == 0)
                                item.DenominationType1 = null;
                            if (item.DenominationType2 == 0)
                                item.DenominationType2 = null;
                            if (item.DenominationType3 == 0)
                                item.DenominationType3 = null;
                            if (item.DenominationType4 == 0)
                                item.DenominationType4 = null;
                            if (item.DenominationType5 == 0)
                                item.DenominationType5 = null;
                            if (item.DenominationType6 == 0)
                                item.DenominationType6 = null;
                            if (item.DenominationType7 == 0)
                                item.DenominationType7 = null;
                        }
                    }
                }
                else
                {
                    isError = true;
                    _logger.LogError($"API error at NoteSetType, GetNoteSetTypeByUserId: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                isError = true;
                _logger.LogError($"Exception at GetNoteSetTypeListAsync as: {ex.Message}");
            }

            if (isError) 
            {
                await _notificationService.Error($"An error occured, check logs..", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return noteSetTypes;
        }

        public async Task<string> IfAtmExistForNoteSetType(long id)
        {
            try
            {
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in IfAtmExistForNoteSetType  : {DateTime.Now.ToString()}");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}IfAtmExistForNoteSetType?noteSetTypeId={id}");
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from IfAtmExistForNoteSetType  : {DateTime.Now.ToString()}");

                
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return responseBody;

                _logger.LogError($"API error at NoteSetType, IfAtmExistForNoteSetType: {responseBody}");                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
            }
            return "Error occured in checking if atm exist for current note set type";
        }
        public async Task<string> InsertNoteSetType(NoteSetType noteSetType)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(noteSetType);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in CreateNoteSetType  : {DateTime.Now.ToString()}");
                HttpResponseMessage result = await client.PostAsync($"{BaseUrl}CreateNoteSetType", content);
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from CreateNoteSetType  : {DateTime.Now.ToString()}");

                                
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await auditService.InsertAuditLogEntry($"{noteSetType.NoteSetTypeName} noteset type created.", UserId, (long)Permissions.CreateNoteSetType);
                    return "success";
                }

                _logger.LogError($"API error at NoteSetType, CreateNoteSetType: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at InsertNoteSetType: {ex.Message}");
            }
            return "Error occured during creation, check the logs..";
        }

        public async Task<string> UpdateNoteSetType(NoteSetType noteSetType)
        {
            try
            {
                AuditLogViewModel auditData = new AuditLogViewModel() { UserId = UserId, RightId = (int)Permissions.ModifyNoteSetType, Message = $"{noteSetType.NoteSetTypeName} noteset type updated." };

                PostContentViewModel postContent = new PostContentViewModel() { AuditData = auditData, PostObj = noteSetType };

                var jsonContent = JsonConvert.SerializeObject(postContent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateNoteSetType  : {DateTime.Now.ToString()}");
                HttpResponseMessage result = await client.PutAsync($"{BaseUrl}UpdateNoteSetType/{noteSetType.NoteSetTypeId}", content);
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateNoteSetType  : {DateTime.Now.ToString()}");
                                
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return "success";
                }

                _logger.LogError($"API error at NoteSetType, UpdateNoteSetType: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateNoteSetType: {ex.Message}");
            }
            return "Error occured during update, check the logs..";
        }

        public async Task<string> DeleteNoteSetType(long id, string notesetTypeName)
        {
            try
            {
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in DeleteNoteSetType  : {DateTime.Now.ToString()}");
                using HttpResponseMessage result = client.DeleteAsync($"{BaseUrl}DeleteNoteSetType/{id}").Result;
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from DeleteNoteSetType  : {DateTime.Now.ToString()}");
                                
                var responseBody = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    await auditService.InsertAuditLogEntry($"{notesetTypeName} noteset type deleted.", UserId, (long)Permissions.DeleteNoteSetType);
                    return "success";
                }

                _logger.LogError($"API error at NoteSetType, DeleteNoteSetType: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeleteNoteSetType: {ex.Message}");
            }
            return "Error occured during deletion, check the logs..";
        }

        public async Task<EView360Models.ViewModels.ReplenishmentViewModel> GetAtmNoteSetType(long atmId)
        {
            EView360Models.ViewModels.ReplenishmentViewModel noteSetType = new();
            try
            {
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetNoteSetTypeByAtmId  : {DateTime.Now.ToString()}");
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetNoteSetTypeByAtmId/{atmId}");
                _logger.LogWarning($"NoteSetTypeService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from GetNoteSetTypeByAtmId  : {DateTime.Now.ToString()}");

                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    noteSetType = JsonConvert.DeserializeObject<EView360Models.ViewModels.ReplenishmentViewModel>(responseBody);
                }
                else
                {
                    await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at NoteSetType, GetAtmNoteSetType: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at NoteSetType as: {ex.Message}");
            }
            return noteSetType;
        }
    }
}
