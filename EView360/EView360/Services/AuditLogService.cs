using Blazorise;
using EView360.Common;
using EView360.Data;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.Text;

namespace EView360.Services
{
    public class AuditLogService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public int UserId { get; set; }
        private ILogger<AuditLogService> _logger { get; set; }
        private CommonServices common { get; set; }

        string BaseUrl { get; set; }    

        private INotificationService notificationService;

        public AuditLogService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<AuditLogService> logger, INotificationService notificationService, CommonServices common)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.AppConf}AuditLog/").ToString();
            _logger = logger;
            this.notificationService = notificationService;
            this.common = common;
        }


        //public static IActionResult Excel()
        //{
        //    using (var workbook = new XLWorkbook())
        //    {
        //        var worksheet = workbook.Worksheets.Add("Users");
        //        var currentRow = 1;
        //        worksheet.Cell(currentRow, 1).Value = "Id";
        //        worksheet.Cell(currentRow, 2).Value = "Username";


        //        using (var stream = new MemoryStream())
        //        {
        //            workbook.SaveAs(stream);
        //            var content = stream.ToArray();

        //            return File(
        //                content,
        //                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //                "users.xlsx");
        //        }
        //    }
        //}


        public async Task<List<AuditLogViewModel>> GetAuditLog(DateTime? fromDate, DateTime? toDate, int? rightId, int? userId)
        {
            List<AuditLogViewModel> auditLog = new();
            BaseModel responseModel = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAuditLog?fromDate={fromDate.Value.ToString("MM/dd/yyyy")}&toDate={toDate.Value.ToString("MM/dd/yyyy")}&userId={userId}&rightId={rightId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        auditLog = JsonConvert.DeserializeObject<List<AuditLogViewModel>>(responseModel.Data.ToString());
                    }
                    else
                    {
                        await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });

                        return auditLog;
                    }

                    if (responseModel.IsSuccess && (auditLog is null || auditLog.Count == 0))
                    {
                        await notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                }
                else
                {
                    await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at GetAuditLog, responseBody: {responseBody}, message : {responseModel.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAuditLog as: {ex.Message}");
            }
            return auditLog;
        }

        //public async Task<List<AuditLogDetail>?> GetDetailedAuditLog(long auditLogId)
        //{
        //    List<AuditLogDetail>? auditLogDetails = new();
        //    BaseModel responseModel = new();
        //    try
        //    {
        //        using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAuditLogDetails?auditLogId={auditLogId}");
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
        //        {
        //            responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
        //            if (responseModel.IsSuccess)
        //            {
        //                auditLogDetails = JsonConvert.DeserializeObject<List<AuditLogDetail>>(responseModel.Data.ToString());
        //            }
        //            else
        //            {
        //                await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
        //                {
        //                    options.IntervalBeforeClose = 4000;
        //                });

        //                return auditLogDetails;
        //            }

        //            if (responseModel.IsSuccess && (auditLogDetails is null || auditLogDetails.Count == 0))
        //            {
        //                await notificationService.Success("No record found", "Succes", (options) =>
        //                {
        //                    options.IntervalBeforeClose = 4000;
        //                });
        //            }
        //        }
        //        else
        //        {
        //            await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
        //            {
        //                options.IntervalBeforeClose = 4000;
        //            });

        //            _logger.LogError($"API error at GetDetailedAuditLog, responseBody: {responseBody}, message : {responseModel.Message}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exception at GetDetailedAuditLog as: {ex.Message}");
        //    }
        //    return auditLogDetails;
        //}

        public async Task<List<AuditLogDetail>> GetDetailedAuditLog(long auditLogId)
        {
            List<AuditLogDetail> responseList = new();
            try
            {
                _logger.LogWarning("[AuditLogService:GetDetailedAuditLog] going in GetAuditLogDetails Audit Log API");
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAuditLogDetailById?auditLogId={auditLogId}");
                _logger.LogWarning("[AuditLogService:GetDetailedAuditLog] returning from GetAuditLogDetails Audit Log  API");

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<AuditLogDetail>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at AuditLog, GetDetailedAuditLog: {responseBody}");
                    await common.RenderErrorBox(responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetDetailedAuditLog as: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
            return responseList;
        }

        public async Task<DataTable> GetAuditLogReport(DateTime? fromDate, DateTime? toDate, int? rightId, int? userId)
        {
            DataTable dt = new();
            BaseModel responseModel = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAuditLog?fromDate={fromDate.Value.ToString("MM/dd/yyyy")}&toDate={toDate.Value.ToString("MM/dd/yyyy")}&userId={userId}&rightId={rightId}&IsReport={true}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        dt = JsonConvert.DeserializeObject<DataTable>(responseModel.Data.ToString());
                    }
                    else
                    {
                        await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });

                        return dt;
                    }

                    if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
                    {
                        await notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                }
                else
                {
                    await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at GetAuditLogReport, responseBody: {responseBody}, message : {responseModel.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAuditLogReport as: {ex.Message}");
            }
            return dt;
        }

        public async Task<DataTable> GetAuditLogDetailReport(DateTime? fromDate, DateTime? toDate, int? rightId, int? userId)
        {
            DataTable dt = new();
            BaseModel responseModel = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetAuditLogDetails?fromDate={fromDate.Value.ToString("MM/dd/yyyy")}&toDate={toDate.Value.ToString("MM/dd/yyyy")}&userId={userId}&rightId={rightId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseModel = JsonConvert.DeserializeObject<BaseModel>(responseBody);
                    if (responseModel.IsSuccess)
                    {
                        dt = JsonConvert.DeserializeObject<DataTable>(responseModel.Data.ToString());
                    }
                    else
                    {
                        await notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });

                        return dt;
                    }

                    if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
                    {
                        await notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                }
                else
                {
                    await notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });

                    _logger.LogError($"API error at GetAuditLogDetailReport, responseBody: {responseBody}, message : {responseModel.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetAuditLogDetailReport as: {ex.Message}");
            }
            return dt;
        }

        public static DataTable ConvertListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);         //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static void ExportDataTableToCsv(string downloadFilePath, DataTable dtExport)
        {
            StringBuilder sbFileContent = new StringBuilder(); IEnumerable<string> columnNames = dtExport.Columns.Cast<DataColumn>().
            Select(column => column.ColumnName);
            sbFileContent.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dtExport.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sbFileContent.AppendLine(string.Join(",", fields));
            }
            dtExport.Clear();
            System.IO.File.WriteAllText(downloadFilePath, sbFileContent.ToString());
            sbFileContent.Clear();
        }

        public async Task<string> InsertAuditLogEntry(String message, long userid, long rightid)
        {
            try
            {
                AuditLogViewModel audit = new AuditLogViewModel() { Message = message, UserId = userid, RightId = (int)rightid, ActivityTime = DateTime.Now };
                var jsonContent = JsonConvert.SerializeObject(audit);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}BuildAuditLog", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode) return "success";

                _logger.LogError($"API error at Login, BuildAuditLog: {responseBody}");
            }
            catch (Exception ex)
            {
                //RenderErrorBox("Error", ex.Message);
                _logger.LogError($"Exception at BuildAuditLog: {ex.Message}");
            }
            return "Error occured during creation, check the logs..";
        }

    }
}
