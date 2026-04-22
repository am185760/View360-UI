using Common.ViewModel;
using EView360.Data;
using EView360Models.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.OpenXmlFormats.Dml.Chart;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using static EView360.Data.Enumerations;

namespace EView360.Services
{
    public class AtmNetworkInfoService
    {
        private static HttpClient client { get; set; }
        private ILogger _logger { get; set; }
        private ApiUrl _apiUrl { get; }
        private readonly IConfiguration _configuration;
        private AtmSetupService _atmSetupService;
        public long UserId { get; set; }
        private static string? BaseUrl { get; set; }
        private AuditLogViewModel auditData;
        private ATMTreeViewRepository _atmTreeService { get; set; }


        public AtmNetworkInfoService(HttpClient httpClient, ILogger<Atm> logger, IOptions<ApiUrl> apiUrl, AtmSetupService atmSetupService, ATMTreeViewRepository atmTreeService)
        {
            _logger = logger;
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.AtmSetup}AtmSetup/").ToString();
            _atmSetupService = atmSetupService;
            _atmTreeService = atmTreeService;
        }

        public async Task<List<EView360Models.ViewModels.AtmNetworkViewModel>> GetAtmNetworkInfoAsync(long? createdBy, string atmTitle, string IP, string atmType, bool? atmStatus)
        {
            List<EView360Models.ViewModels.AtmNetworkViewModel> responseList = new();
            try
            {
                List<long>? selectedAtmIds = await _atmTreeService?.GetSelectedAtmId();
                if (selectedAtmIds?.Count > 0)
                {
                    var jsonContent = JsonConvert.SerializeObject(selectedAtmIds);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetATMInfo  : {DateTime.Now.ToString()}");
                    using HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetATMInfo?createdBy={createdBy}&atmTitle={atmTitle}&IP={IP}&atmType={atmType}&atmStatus={atmStatus}", content);
                    _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from GetATMInfo  : {DateTime.Now.ToString()}");
                    
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                    {
                        responseList = JsonConvert.DeserializeObject<List<EView360Models.ViewModels.AtmNetworkViewModel>>(responseBody);
                    }
                    else
                    {
                        _logger.LogError($"API error at AtmSetup, GetAppSetting: {responseBody}");
                    }
                }                 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAtmNetworkInfoAsync as: {ex.Message}");
            }
            return responseList;
        }

        public async Task<string> PingAtm(EView360Models.ViewModels.AtmNetworkViewModel atm)
        {
            string status = string.Empty;
            try
            {
                Ping ping = new();

                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in ping.Send  : {DateTime.Now.ToString()}");
                PingReply reply = ping.Send(atm.Ip);
                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from ping.Send  : {DateTime.Now.ToString()}");
                                
                if (reply.Status.ToString() != "Success")
                {
                    status = $"Ping operation failed with status {reply.Status} on {atm.Title} [{atm.Ip}]";
                    _logger.LogError($"Ping operation failed with status {reply.Status} on {atm.Title} [{atm.Ip}]");
                }                    
                else
                {
                    status = $"Ping completed successfully on {reply.Status} on {atm.Title} [{atm.Ip}]";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"An Error occured on {atm.Title} [{atm.Ip}]  {ex.Message}");
                status = $"An Error occured on {atm.Title} [{atm.Ip}]  {ex.Message}";
            }
            return status;
        }

        public async Task<string> TelnetAtm(EView360Models.ViewModels.AtmNetworkViewModel atm)
        {
            string status = string.Empty;
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in socket.Connect  : {DateTime.Now.ToString()}");
                socket.Connect(atm.Ip, atm.AtmOnDemandRequestPort.Value);
                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from socket.Connect  : {DateTime.Now.ToString()}");
                                
                //socket.Disconnect(false);
                socket.Close(1000);
                status = $"Telnet completed successfully on {atm.Title} [{atm.Ip}]";
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Error occured on {atm.Title} [{atm.Ip}]  {ex.Message}");
                status = $"An Error occured on {atm.Title} [{atm.Ip}]  {ex.Message}";
            }
            return status;
        }

        public async Task<string> UpdateAtmPingStatus(long atmId, string atmTitle, DateTime LastPingExecutedAt, string status)
        {
            try
            {
                auditData = new AuditLogViewModel() { UserId = UserId, RightId = (int)Permissions.ModifyATM, Message = $"{atmTitle} ATM updated." };
                var jsonContent = JsonConvert.SerializeObject(auditData);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateAtmPingStatus  : {DateTime.Now.ToString()}");
                HttpResponseMessage response = await client.PutAsync($"{BaseUrl}UpdateAtmPingStatus?atmId={atmId}&LastPingExecutedAt={LastPingExecutedAt}&status={status}", content);
                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateAtmPingStatus  : {DateTime.Now.ToString()}");
                                
                if (response.IsSuccessStatusCode)
                {
                    return "Atm ping status updated successfully";
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error in api AtmSetup,UpdateAtmPingStatus as: {responseBody}");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception at UpdateAtmPingStatus: {ex.Message}");
            }
            return "An error occured while updating Atm ping status";
        }

        public async Task<string> UpdateAtmTelnetStatus(long atmId, string atmTitle, DateTime LastTelnetExecutedAt, string status)
        {
            try
            {
                auditData = new AuditLogViewModel() { UserId = UserId, RightId = (int)Permissions.ModifyATM, Message = $"{atmTitle} ATM updated." };
                var jsonContent = JsonConvert.SerializeObject(auditData);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateAtmTelnetStatus  : {DateTime.Now.ToString()}");
                HttpResponseMessage response = await client.PutAsync($"{BaseUrl}UpdateAtmTelnetStatus?atmId={atmId}&LastTelnetExecutedAt={LastTelnetExecutedAt}&status={status}", content);
                _logger.LogWarning($"AtmNetworkInfoService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateAtmTelnetStatus  : {DateTime.Now.ToString()}");
                                
                if (response.IsSuccessStatusCode)
                {
                    return "Atm telnet status updated successfully";
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error in api AtmSetup,UpdateAtmTelnetStatus as: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at UpdateAtmTelnetStatus: {ex.Message}");
            }
            return "An error occured while updating Atm telnet status";
        }        
    }
}
