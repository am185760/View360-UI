using EView360.Data;
using EView360Models.Core;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Blazorise;
using Microsoft.Extensions.Options;

namespace EView360.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private ApiUrl _apiUrl { get; }
        private readonly INotificationService _notificationService;
        private readonly string? _ApplicationID;
        private readonly string? _Group1, _Group2, _Group3, _Group4, _Group5;
        public readonly string? _IsEncodeSignIn, _isSecurityWebServiceEnabled, _SecurityWebUrl;
        private static string? BaseUrl { get; set; }

        private static ILogger _logger { get; set; }
        private static HttpClient client { get; set; }

        public UserService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, IConfiguration configuration, ILogger<UserService> logger, INotificationService notificationService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Login}Login/").ToString();
            _configuration = configuration;
            _notificationService = notificationService;
            _ApplicationID = _configuration.GetValue<string>("ApplicationID");
            _Group1 = _configuration.GetValue<string>("Group1");
            _Group2 = _configuration.GetValue<string>("Group2");
            _Group3 = _configuration.GetValue<string>("Group3");
            _Group4 = _configuration.GetValue<string>("Group4");
            _Group5 = _configuration.GetValue<string>("Group5");
            _IsEncodeSignIn = _configuration.GetValue<string>("IsEncodeSignIn");
            _isSecurityWebServiceEnabled = _configuration.GetValue<string>("isSecurityWebServiceEnabled");
            _SecurityWebUrl = _configuration.GetValue<string>("SecurityWebUrl");
            _logger = logger;
        }

        //get user from db via api call
        public async Task<AppUser> GetUserFromDbAsync(User user)
        {
            AppUser appUser = new AppUser() { UserId = -1 };
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetUser?userLogin={user.UserLogin}");
                ////response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    appUser = JsonConvert.DeserializeObject<AppUser>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Login, GetUserFromDbAsync: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                appUser = null;
                _logger.LogError($"Exception at GetUserFromDbAsync as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);

            }
            return appUser;
        }

        //get user rights from db
        public async Task<Dictionary<long, string>> GetUserRightsAsync(long userid)
        {
            Dictionary<long, string> userRights = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetUserRight?userId={userid}");
                //response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    userRights = JsonConvert.DeserializeObject<Dictionary<long, string>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Login, GetUserRightsAsync: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetUserRightsAsync as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);

            }
            return userRights;
        }

        //NBE security module autherization
        public bool ValidateWithNBESecurityModule()
        {
            bool result = true;
            try
            {
                //Service securityService = new Service();
                //if (securityService == null)
                //    throw new Exception("Unable to create service object");
                string uri = "https://localhost:44315/default?UID=2&UserID=admin&applicationID=1&groupID=2&ticketID=1&key=1";
                string UID = "1";//Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query).TryGetValue("id", out var type) ? type.First() : "";//Request.QueryString["UID"];
                string userID = "1";//Request.QueryString["UserID"];
                string applicationID = "1";//Request.QueryString["ApplicationID"];
                string groupID = "1";//Request.QueryString["GroupID"];
                string ticketID = "1"; //Request.QueryString["TicketID"];
                string key = "1";//Request.QueryString["Key"];


                string webApplicationID = _ApplicationID;
                string webGroupID1 = _Group1;
                string webGroupID2 = _Group2;
                string webGroupID3 = _Group3;
                string webGroupID4 = _Group4;
                string webGroupID5 = _Group5;

                //if (securityService.CheckTicket(decimal.Parse(ticketID), int.Parse(groupID), int.Parse(applicationID), int.Parse(UID), userID, key))
                //{
                //    result = true;
                //}

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        //check special characters in user
        public bool CheckSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] { ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            bool result = false;
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        //get retry attempts left for user
        public async Task<int> GetUserRetryAttempts(long userid)
        {
            int retryAttempts = 0;
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetRetryAttempt?userId={userid}");
                //response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseBody))
                {
                    retryAttempts = JsonConvert.DeserializeObject<int>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at Login, GetUserRetryAttempts: {responseBody}");
                    await RenderErrorBox("Error", responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetUserRetryAttempts as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return retryAttempts;
        }

        //get decreament user retry attempt
        public async Task<string> DeductUserRetryAttempt(long userid)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"{BaseUrl}DeductRetryAttempt/{userid}", null);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at Login, DeductUserRetryAttempt: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at DeductUserRetryAttempt: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";
        }

        //set user as inactive and update user modification time
        public async Task<string> SetUserAsInactive(long userid)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"{BaseUrl}SetUserAsInactive/{userid}", null);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at Login, SetUserAsInactive: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at SetUserAsInactive: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";
        }

        //set retry exhaust
        public async Task<string> ResetRetryAttempt(long userid)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"{BaseUrl}ResetRetryAttempt/{userid}", null);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at Login, ResetRetryAttempt: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at ResetRetryAttempt: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during update, check the logs..";
        }

        //make entry in audit log
        public async Task<string> BuildAuditLog(String message, long userid, long rightid)
        {
            try
            {
                AuditLog audit = new AuditLog() { /*IpAddress=GetIPAddress(),*/ Message = message, UserId = userid, RightId = rightid, ActivityTime = DateTime.Now };
                var jsonContent = JsonConvert.SerializeObject(audit);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}BuildAuditLog", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at Login, BuildAuditLog: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at BuildAuditLog: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
            return "Error occured during creation, check the logs..";
        }

        public string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public bool IsUserAlreadyLoggedIn(List<ActiveSession> list, int userID)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].userID == userID)
                    {
                        //User with the same id already logged in
                        return true;
                    }
                }
            }
            return false;
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
    }
}
