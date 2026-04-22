using global::Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Blazorise;
using Blazorise.DataGrid;
using EView360.Common;
using EView360Models.Core;
using EView360Models.ViewModels;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;
using System.Collections.Concurrent;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static EView360.Data.Enumerations;
using DataRequestor;
using EView360.Data;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Metadata;
using EView360Models.Cash;
using Microsoft.EntityFrameworkCore;

namespace EView360.Pages.Operations
{
    public partial class AtmTask
    {
        private bool showSpinner = false;
        private bool showGrid = false;
        private Modal? modalRef;
        private Modal? DwnldFilemodalRef;
        private Modal? ViewTaskModalRef;
        string dataFile = string.Empty;
        string tempFolder = string.Empty;
        string duration = string.Empty;
        string selectedAtmText = string.Empty;
        string cancelButtonText = string.Empty;
        bool showCancelBtn = false;
        static DateTime currentTime = DateTime.Now;
        DateTime fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
        DateTime toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 0);
        public List<AtmTaskViewModel> atmTasks = new();
        public List<AtmTaskViewModel> _atmTasks = new();
        public List<FileTypeViewModel> fileTypes = new();
        public AtmTaskViewModel taskDetail = new();
        private List<AtmTaskViewModel> filteredAtmTasks = new();
        private DataGrid<AtmTaskViewModel>? dataGridRef;
        private AtmTaskFilterViewModel filterView = new();
        private string? fileType = string.Empty;
        [Inject]
        INotificationService NotificationService { get; set; }

        [Inject]
        IMessageService MessageService { get; set; }

        //private HubConnection hubConnection;
        DatePicker<DateTime>? dateRef;
        private DotNetObjectReference<AtmTask>? objRef;
        private long? selectedTreeRegion;
        private List<long>? selectedTreeAtm;
        string viewFileHeading = string.Empty;
        bool visible = false;
        string alertText = string.Empty;
        int totalRecordPerPage = 0;
        //archive
        [Parameter]
        public string? mode { get; set; }

        bool isArchive = false;
        public List<AppUserDropdownViewModel> appUsers { get; set; } = new List<AppUserDropdownViewModel>();

        public List<string> taskStatusList = new();
        public List<TaskTypeViewModel> taskTypes = new();
        public List<TerminalType> atmTerminalTypes = new();
        public List<string> atmTypeList = new();
        //paging
        private int pageNo { get; set; }
        private int maxPageNo { get; set; }
        private int totalRecords { get; set; }

        private bool IsDisabled = false;
        private List<int> archiveYears = new();
        int ArchiveYear;
        Dictionary<int, string> userRights;

        private Executor executor = new Executor();

        string orderByFilter = string.Empty;
        private string sortField = string.Empty;
        private SortDirection sortDirection = new();


        protected override async Task OnInitializedAsync()
        {
            try
            {
                logger.LogWarning($"Atm Task Page: OnInitializedAsync : {DateTime.Now.ToString()}");
                objRef = DotNetObjectReference.Create(this);
                userRights = await localStorage.GetItemAsync<Dictionary<int, string>>("userRights");
                totalRecordPerPage = _configuration.GetValue<int>("RecordPerPage");
                executor.RaiseCustomEvent += PopulateModel;
                if (appUsers is null || appUsers.Count == 0)
                {
                    appUsers = await userManagementService.GetAllUsers();
                }

                if (taskTypes is null || taskTypes.Count == 0)
                {
                    taskTypes = await service.GetTaskTypes();
                }

                if (atmTerminalTypes is null || atmTerminalTypes.Count == 0)
                {
                    atmTerminalTypes = await atmSetupService.GetAtmTerminalType();
                    if (atmTerminalTypes?.Count > 0)
                    {
                        atmTypeList = atmTerminalTypes.Select(x => x.Name).ToList();
                    }
                }

                if (taskStatusList is null || taskStatusList.Count == 0)
                {
                    taskStatusList = await service.GetStatusFriendlyName();
                }

                if (!string.IsNullOrEmpty(mode) && mode.Equals("Archive"))
                {
                    isArchive = true;
                }

                notifyService.OnAtmChange += AtmSelected;
                notifyService.OnRegionChange += RegionSelected;
                //    var hubConnectionBuilder = new HubConnectionBuilder()
                //.WithUrl("https://localhost/EView360/broadcastHub", options =>
                //{
                //    options.HttpMessageHandlerFactory = (handler) =>
                //    {
                //        if (handler is HttpClientHandler httpClientHandler)
                //        {
                //            // Bypass SSL certificate validation
                //            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                //        }
                //        return handler;
                //    };
                //    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
                //});
                //hubConnection = hubConnectionBuilder.Build();
                //await hubConnection.StartAsync();
                AppUser appUser = await localStorage.GetItemAsync<AppUser>("AppUser");
                if (appUser is not null)
                {
                    service.UserId = appUser.UserId;
                }

                await service.GetAtmList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, OnInitializedAsync as: {ex.Message}");
                await NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            logger.LogWarning($"Atm Task Page: SetParametersAsync : {DateTime.Now.ToString()}");
            filteredAtmTasks = atmTasks = new List<AtmTaskViewModel>();
            pageNo = 1;
            await base.SetParametersAsync(parameters);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender && (atmTasks is null || atmTasks.Count == 0))
                {
                    logger.LogWarning($"Atm Task Page: OnAfterRenderAsync : {DateTime.Now.ToString()}");
                    filterView.filterTaskTypes = "-1";
                    filterView.filterUser = "-1";
                    filterView.filterTaskStatus = "-1";
                    filterView.filterAtmType = "-1";
                    filterView.filterFileType = "-1";

                    orderByFilter = "Order by F.creation_time desc";

                    await jsRuntime.InvokeVoidAsync("handleDatePicker", objRef);

                    //await LoadData();
                    fileTypes = await service.GetAllFileTypeAsync();
                    if (fileTypes is null || fileTypes.Count == 0)
                    {
                        await NotificationService.Error("unable to load file types, check logs for error", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                    else
                    {
                        fileType = fileTypes.FirstOrDefault().FileTypeTitle;
                    }

                    tempFolder = await appConfService.GetTemporaryFolderPathAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, OnAfterRenderAsync as: {ex.Message}");
                await NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        //Task SendMessage() => hubConnection.SendAsync("SendMessage");
        //public bool IsConnected =>
        //    hubConnection.State == HubConnectionState.Connected;
        protected override Task OnParametersSetAsync()
        {
            logger.LogWarning($"Atm Task Page: OnParametersSetAsync : {DateTime.Now.ToString()}");
            filterView.filterTaskTypes = "-1";
            filterView.filterUser = "-1";
            filterView.filterTaskStatus = "-1";
            filterView.filterAtmType = "-1";
            pageNo = 1;

            isArchive = (!string.IsNullOrEmpty(mode) && mode.Equals("Archive")) ? true : false;
            if (isArchive)
            {
                archiveYears = common.GetLastNYears();
                ArchiveYear = archiveYears.FirstOrDefault();
            }
            else
            {
                fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
                toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                ArchiveYear = 0;
            }

            this.InvokeAsync(() => this.StateHasChanged());
            return Task.CompletedTask;
        }

        private bool CheckPermission(int right)
        {
            try
            {
                if (userRights is not null)
                    return userRights.ContainsKey(right);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at TaskScreen, CheckPermission as: {ex.Message}");

                NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return false;
        }

        private async void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortedDirection = e.SortDirection;
            string? orderby = "Order by ";
            AtmTaskViewModel atmTaskView = new();

            if (this.sortDirection != sortedDirection || !this.sortField.Equals(sortedColumn))
            {

                if (sortedColumn.Equals(nameof(atmTaskView.AtmTitle)))
                    orderby += " core.dbo.atm.title";

                else if (sortedColumn.Equals(nameof(atmTaskView.AtmIP)))
                    orderby += " core.dbo.atm.IP";

                else if (sortedColumn.Equals(nameof(atmTaskView.Location)))
                    orderby += " core.dbo.atm.location";

                else if (sortedColumn.Equals(nameof(atmTaskView.AtmType)))
                    orderby += " core.dbo.atm.atm_type";


                else if (sortedColumn.Equals(nameof(atmTaskView.CreationTime)))
                    orderby += "F.creation_time";

                else if (sortedColumn.Equals(nameof(atmTaskView.EndTime)))
                    orderby += "end_time";

                else if (sortedColumn.Equals(nameof(atmTaskView.BytesTransferred)))
                    orderby += "F.bytes_transferred";

                else if (sortedColumn.Equals(nameof(atmTaskView.TaskTypeName)))
                    orderby += "task_type.task_type_name";

                else if (sortedColumn.Equals(nameof(atmTaskView.FileTypeTitle)))
                    orderby += "file_type_title";


                //Appending Sorting Direction
                if (sortDirection == SortDirection.Ascending && !string.IsNullOrEmpty(orderby))
                    orderby += " asc";

                else if (sortDirection == SortDirection.Descending && !string.IsNullOrEmpty(orderby))
                    orderby += " desc";

                orderByFilter = orderby;

                this.sortDirection = sortedDirection;
                this.sortField = sortedColumn;
                await LoadData();
            }
        }

        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"AtmTaskHist: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            string error = string.Empty;

            if (args?._dataSet?.Tables?.Count > 0 && args._dataSet.Tables[0].Rows?.Count > 0)
            {
                _atmTasks = BuildAtmTask(args._dataSet.Tables[0]);

                if (args._dataSet.Tables[1].Rows?.Count > 0)
                {
                    List<AtmTaskViewModel> _modelLst = new();
                    foreach (DataRow row in args._dataSet.Tables[1].Rows)
                    {
                        AtmTaskViewModel atmTaskView = new()
                        {
                            TaskId = !DBNull.Value.Equals(row["task_id"]) ? Convert.ToInt64(row["task_id"]) : 0,
                            DataFileCount = !DBNull.Value.Equals(row["DataFileCount"]) ? Convert.ToInt32(row["DataFileCount"]) : 0,
                            DataFileCount2 = !DBNull.Value.Equals(row["DataFileCount2"]) ? Convert.ToInt32(row["DataFileCount2"]) : 0,
                            FileTypeId = !DBNull.Value.Equals(row["file_type_id"]) ? Convert.ToInt64(row["file_type_id"]) : null,
                        };
                        atmTaskView.DataFileCount += atmTaskView.DataFileCount2;
                        _modelLst.Add(atmTaskView);
                    }
                    if (_modelLst?.Count > 0)
                    {
                        foreach (AtmTaskViewModel atmTask in _atmTasks)
                        {
                            atmTask.DataFileCount = _modelLst.FirstOrDefault(x => x.TaskId == atmTask.TaskId && x.FileTypeId == atmTask.FileTypeId)?.DataFileCount ?? 0;
                        }
                    }
                }

                atmTasks.AddRange(_atmTasks);
                filteredAtmTasks = atmTasks;
                totalRecords += filteredAtmTasks.Max(x => x.RowCount);
                maxPageNo = common.GetMaxPageNo(Convert.ToInt32(totalRecords));
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at AtmTaskHist, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at AtmTaskHist, PopulateModel as: {args._exception.InnerException.Message}");
                    //await common.RenderErrorBox(args._exception.InnerException.Message);
                }
            }
            else if (atmTasks is null || atmTasks.Count == 0)
            {
                await NotificationService.Info("Check Filter, if records are not appearing", "Information", (options) =>
                {
                    options.IntervalBeforeClose = 5000;
                });
            }

            IsDisabled = false;
            showGrid = true;
            showSpinner = false;            
            await this.InvokeAsync(() => this.StateHasChanged());
            await dataGridRef?.Sort(sortField, sortDirection);
        }

        public async void Dispose()
        {
            notifyService.OnAtmChange -= AtmSelected;
            notifyService.OnRegionChange -= RegionSelected;
        }

        private async void AtmSelected()
        {
            logger.LogWarning($"Atm Task Page: AtmSelected : {DateTime.Now.ToString()}");
            await LoadData();
        }

        private async void RegionSelected()
        {
            logger.LogWarning($"Atm Task Page: RegionSelected : {DateTime.Now.ToString()}");
            await LoadData();
        }

        private async Task<string> GetFilter()
        {
            string filter = string.Empty;
            List<string> atmIDs = new();
            List<string> regionIDs = new();
            filteredAtmTasks = atmTasks;
            (atmIDs, regionIDs) = await atmRepository.GetSelectedAtmOrRegionList();
            if (regionIDs?.Count > 0)
            {
                filter = " and ATM.region_id in " + "(" + string.Join(",", regionIDs) + ")";
            }
            else
            {
                filter = " and ATM.atm_id in " + "(" + string.Join(",", atmIDs) + ")";
            }

            //task type
            if (filterView.filterTaskTypes != "-1")
            {
                filter += " and task_type.task_type_id  = " + filterView.filterTaskTypes;
            }

            //user
            if (filterView.filterUser != "-1")
            {
                filter += " and F.created_by = " + filterView.filterUser;
            }

            //status
            if (filterView.filterTaskStatus != "-1")
            {
                filter += " and status = '" + filterView.filterTaskStatus + "'";
            }

            //atmType
            if (filterView.filterAtmType != "-1")
            {
                filter += " and atm_type = '" + filterView.filterAtmType + "'";
            }

            //fileType
            if (filterView.filterFileType != "-1")
            {
                filter += " and file_type.file_type_id = '" + filterView.filterFileType + "'";
            }

            return filter;
        }

        private async Task GetDataByPageNo(int thisPageNo)
        {
            logger.LogWarning($"Atm Task Page: GetDataByPageNo : {DateTime.Now.ToString()}");
            pageNo = thisPageNo;
            await LoadData();
        }

        private async Task LoadData(bool readFromCache = true)
        {
            logger.LogWarning($"Atm Task Page: ** LoadData ** : {DateTime.Now.ToString()}");
            atmTasks = filteredAtmTasks = new List<AtmTaskViewModel>();
            showSpinner = true;
            showGrid = false;
            IsDisabled = true;
            totalRecords = 0;
            await this.InvokeAsync(() => this.StateHasChanged());
            await Task.Delay(5);
            if (isArchive)
            {
                fromDate = new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second);
                toDate = new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second);
            }

            if (atmRepository.SelectedAtmIds?.Count > 0)
            {
                service.GetAtmTasksAsync(executor, pageNo, fromDate, toDate, await GetFilter(), orderByFilter, readFromCache, isArchive ? ArchiveYear : null);
            }
            else
            {
                await NotificationService.Info("Check Filter, if records are not appearing", "Information", (options) =>
                {
                    options.IntervalBeforeClose = 5000;
                });

                IsDisabled = false;
                showGrid = true;
                showSpinner = false;                
                await this.InvokeAsync(() => this.StateHasChanged());
            }
        }

        public List<AtmTaskViewModel> BuildAtmTask(DataTable dataTable)
        {
            List<AtmTaskViewModel> atmTaskViews = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    AtmTaskViewModel atmTaskView = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        AtmId = !DBNull.Value.Equals(row["ATM_ID"]) ? Convert.ToInt64(row["ATM_ID"]) : 0,
                        EndTime = !DBNull.Value.Equals(row["end_time"]) ? Convert.ToDateTime(row["end_time"]) : null,
                        AtmType = !DBNull.Value.Equals(row["atm_type"]) ? row["atm_type"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        AtmIP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        AtmTitle = !DBNull.Value.Equals(row["TITLE"]) ? row["TITLE"].ToString() : string.Empty,
                        TaskId = !DBNull.Value.Equals(row["task_id"]) ? Convert.ToInt64(row["task_id"]) : 0,
                        FileTypeId = !DBNull.Value.Equals(row["file_type_id"]) ? Convert.ToInt64(row["file_type_id"]) : null,
                        CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : DateTime.Now,
                        TaskTypeId = !DBNull.Value.Equals(row["task_type_id"]) ? Convert.ToInt64(row["task_type_id"]) : 0,
                        TaskTypeName = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                        BytesTransferred = !DBNull.Value.Equals(row["bytes_transferred"]) ? Convert.ToInt32(row["bytes_transferred"]) : 0,
                        Parsed = !DBNull.Value.Equals(row["parsed"]) ? Convert.ToBoolean(row["parsed"]) : false,
                        DownloadTime = !DBNull.Value.Equals(row["download_time"]) ? Convert.ToDateTime(row["download_time"]) : null,
                        Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                        LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? Convert.ToDateTime(row["last_invoked"]) : null,
                        FailureReason = !DBNull.Value.Equals(row["reason"]) ? row["reason"].ToString() : string.Empty,
                        FailureReasonFull = !DBNull.Value.Equals(row["failure_reason_full"]) ? row["failure_reason_full"].ToString() : string.Empty,
                        FileTypeTitle = !DBNull.Value.Equals(row["file_type_title"]) ? row["file_type_title"].ToString() : string.Empty,
                        UserName = !DBNull.Value.Equals(row["user_login"]) ? row["user_login"].ToString() : string.Empty
                    };

                    atmTaskViews.Add(atmTaskView);
                }
            }
            return atmTaskViews;
        }

        private Task ShowModal()
        {
            return modalRef.Show();
        }

        private Task HideModal()
        {
            return modalRef.Hide();
        }

        private async Task<Task> ShowDwnldFileModal()
        {
            alertText = string.Empty;
            visible = false;
            selectedAtmText = await service.GetSelectedAtm();
            if (selectedAtmText.ToLower().Contains("please"))
            {
                alertText = selectedAtmText;
                visible = true;
            }

            return DwnldFilemodalRef.Show();
        }

        private Task HideDwnldFileModal()
        {
            return DwnldFilemodalRef.Hide();
        }

        private Task ShowViewTaskModal()
        {
            return ViewTaskModalRef.Show();
        }

        private Task HideViewTaskModal()
        {
            dataFile = string.Empty;
            return ViewTaskModalRef.Hide();
        }

        async Task OnCancelTask(long taskID, long? fileTypeId, long atmId)
        {
            logger.LogWarning($"Atm Task Page: OnCancelTask : {DateTime.Now.ToString()}");
            string response = await service.UpdateTaskStatus(taskID, fileTypeId, DownloadStates.cancelled.ToString(), atmId);
            if (!string.IsNullOrEmpty(response))
            {
                if (response != "success")
                {
                    await NotificationService.Error(response, "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    await NotificationService.Success("Task cancelled successfully", "Success", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }

                await Task.Delay(300);
                await HideModal();
                await LoadData(false);
            }
        }

        private async Task GetTaskDetail(AtmTaskViewModel task)
        {
            try
            {
                taskDetail = task;
                showCancelBtn = false;
                duration = cancelButtonText = string.Empty;
                if (task.FileTypeId != null)
                {
                    duration = task.DownloadTime.HasValue ? Math.Round(((TimeSpan)task.DownloadTime.Value.Subtract(new DateTime(1900, 1, 1))).TotalMinutes, 3) + " minutes" : "";
                }
                else
                {
                    duration = task.EndTime.HasValue ? Math.Round(((TimeSpan)task.UploadTime.Value.Subtract(new DateTime(1900, 1, 1))).TotalMinutes, 3) + " minutes" : "";
                }

                cancelButtonText = task.FileTypeId == 1 ? "Cancel this download" : "Cancel this upload";
                if (task.Status.ToLower() == DownloadStates.scheduled.ToString() || task.Status.ToLower() == DownloadStates.downloadingDisconnected.ToString() || task.Status.ToLower() == UploadStates.uploadingDisconnected.ToString())
                {
                    showCancelBtn = true;
                }

                await ShowModal();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, GetTaskDetail as: {ex.Message}");
                await NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        private async Task ViewTask(AtmTaskViewModel model)
        {
            var dataFileResponse = await service.GetDataFileAsync(model.TaskId, model.FileTypeId, model.AtmId, model.TaskTypeId);
            if (dataFileResponse.isSucess && string.IsNullOrEmpty(dataFileResponse.DataFile))
            {
                await RenderInfoBox("Information", "Data file not found");
            }
            else if (dataFileResponse.isSucess && !string.IsNullOrEmpty(dataFileResponse.DataFile))
            {
                dataFile = model.FileTypeId == 1 ? await FormatCashFile(dataFileResponse.DataFile.Replace("\0", "")) : await FormatEJFile(dataFileResponse.DataFile.Replace("\0", ""));
                viewFileHeading = model.FileTypeId == 1 ? "Cash Data Viewer" : "EJ Viewer";
                await ShowViewTaskModal();
            }
            else
            {
                await RenderErrorBox("Error", "And error occured, kindly check logs..");
            }
        }

        private async Task<string> FormatCashFile(string counterFile)
        {
            //UnicodeEncoding unicode = new UnicodeEncoding();
            //Byte[] encodedBytes = unicode.GetBytes(counterFile);
            //string decodedString = unicode.GetString(encodedBytes);
            return counterFile.Replace("\0", "");
        }

        private async Task<string> FormatEJFile(string ejFile)
        {
            ejFile = ejFile.Replace("\0", "");
            Regex formattingChars = new Regex(@"([[]00p)|([[]05p)|([[]020t)|([[]0r[(]1[)]2[[]000p[[]040qe1w3h162)|([(]\D)|([(]\d)|([(]C)|([[]040)|([[]000p)|(/)|(q[(]I)|(q[(]1)|([(]7)|([(]>)|()|([(]>)|([(]C)|([(]1)|([(]D)|(\+)|()");
            ejFile = formattingChars.Replace(ejFile, "");
            ejFile = ejFile.Replace("\r", "<br>");
            UnicodeEncoding unicode = new UnicodeEncoding();
            Byte[] encodedBytes = unicode.GetBytes(ejFile);
            string decodedString = unicode.GetString(encodedBytes);
            return decodedString;
        }

        public async Task DownLoadFile(string dataToDownload, string filePath, string title)
        {
            try
            {
                ceTe.DynamicPDF.Document doc = new ceTe.DynamicPDF.Document();
                StringReader strReader = new StringReader(dataToDownload);
                string line;
                //AppSetting appSetting = AppSetting.LoadAppSetting("1=1");
                ceTe.DynamicPDF.Page p;
                string pageText = "";
                int linecount = 0;
                while ((line = strReader.ReadLine()) != null)
                {
                    pageText += line + "\r";
                    linecount++;
                    if (linecount == 60)
                    {
                        linecount = 0;
                        p = new ceTe.DynamicPDF.Page(ceTe.DynamicPDF.PageSize.A3, ceTe.DynamicPDF.PageOrientation.Portrait, 10);
                        p.Elements.Add(new ceTe.DynamicPDF.PageElements.Label(pageText, 20, 20, 600, 700, ceTe.DynamicPDF.Font.TimesRoman, 10));
                        doc.Pages.Add(p);
                        pageText = "";
                    }
                }

                if (linecount > 0)
                {
                    linecount = 0;
                    p = new ceTe.DynamicPDF.Page(ceTe.DynamicPDF.PageSize.A3, ceTe.DynamicPDF.PageOrientation.Portrait, 10);
                    p.Elements.Add(new ceTe.DynamicPDF.PageElements.Label(pageText, 20, 20, 600, 700, ceTe.DynamicPDF.Font.TimesRoman, 10));
                    doc.Pages.Add(p);
                    pageText = "";
                }

                doc.Draw(filePath);
                strReader.Close();
                NavigationManager.NavigateTo($"{NavigationManager.BaseUri}File/DownloadPdf?filepath={filePath}", forceLoad: true);
                //FileController file = new();
                //file.DownloadPdf(filePath);
            }
            catch (Exception ex)
            {
            }
        }

        public void ExportToPdf(DataTable dt, string strFilePath, string title)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                widths[i] = 4f;
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));
            cell.Colspan = dt.Columns.Count;
            // Ignoring col. header
            //foreach (DataColumn c in dt.Columns)
            //{
            //    table.AddCell(new Phrase(c.ColumnName, font5));
            //}
            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Columns.Count; h++)
                    {
                        table.AddCell(new Phrase(r[h].ToString(), font5));
                    }
                }
            }

            document.Add(table);
            document.Close();
        }

        public async Task MergeAsPdf()
        {
            try
            {
                StringBuilder mergeData = new StringBuilder();
                ConcurrentBag<string> dataBag = new();
                ConcurrentBag<string> errorBag = new();
                if (filteredAtmTasks?.Count > 0 && filteredAtmTasks.Any(x => x.DataFileCount > 0))
                {
                    Parallel.ForEach(filteredAtmTasks.Where(x => x.DataFileCount > 0), async model =>
                    {
                        var dataFileResponse = await service.GetDataFileAsync(model.TaskId, model.FileTypeId, model.AtmId, model.TaskTypeId);
                        if (dataFileResponse.isSucess && string.IsNullOrEmpty(dataFileResponse.DataFile))
                        {
                            await RenderInfoBox("Information", "Data file not found");
                        }
                        else if (dataFileResponse.isSucess && !string.IsNullOrEmpty(dataFileResponse.DataFile))
                        {
                            dataBag.Add(dataFileResponse.DataFile);
                        }
                        else
                        {
                            errorBag.Add("error");
                            await RenderErrorBox("Error", "And error occured, kindly check logs..");
                        }
                    });
                }
                else
                {
                    await RenderInfoBox("Information", "Data file/s not found");
                }

                if (dataBag?.Count > 0)
                {
                    dataBag.ToList().ForEach(item => mergeData.Append(item + Environment.NewLine));
                    string mergeFileData = mergeData.ToString();
                    Regex regex1 = new Regex(@"\d+aLUNO123a");
                    System.Text.RegularExpressions.Match match = regex1.Match(mergeFileData);
                    if (match.Success)
                        mergeFileData = regex1.Replace(mergeFileData, "").Replace('a', '\r');
                    await DownLoadFile(await FormatCashFile(mergeFileData), @$"{tempFolder}\CashDataFile_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.pdf", @$"CashDataFile_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.pdf");
                    await RenderSuccessBox("Download success", $"File downloaded at {tempFolder}");
                }

                if (errorBag?.Count > 0)
                {
                    await RenderErrorBox("Error", "An error occured, kindly check logs..");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, GetTaskDetail as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
        }

        public async Task SaveAsPdf(AtmTaskViewModel model)
        {
            try
            {
                await NotificationService.Info("Downloading in progress..", "Information", (options) =>
                {
                    options.IntervalBeforeClose = 2000;
                });
                var dataFileResponse = await service.GetDataFileAsync(model.TaskId, model.FileTypeId, model.AtmId, model.TaskTypeId);
                if (dataFileResponse.isSucess && string.IsNullOrEmpty(dataFileResponse.DataFile))
                {
                    await RenderInfoBox("Information", "Data file not found");
                }
                else if (dataFileResponse.isSucess && !string.IsNullOrEmpty(dataFileResponse.DataFile))
                {
                    Regex regex1 = new Regex(@"\d+aLUNO123a");
                    System.Text.RegularExpressions.Match match = regex1.Match(dataFileResponse.DataFile);
                    if (match.Success)
                        dataFileResponse.DataFile = regex1.Replace(dataFileResponse.DataFile, "").Replace('a', '\r');
                    await DownLoadFile(await FormatCashFile(dataFileResponse.DataFile), @$"{tempFolder}\CashDataFile_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.pdf", @$"CashDataFile_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.pdf");
                    await RenderSuccessBox("Download success", $"File downloaded at {tempFolder}");
                }
                else
                {
                    await RenderErrorBox("Error", "And error occured, kindly check logs..");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, GetTaskDetail as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
        }

        public async Task MergeAsText()
        {
            try
            {
                StringBuilder mergeData = new StringBuilder();
                ConcurrentBag<string> dataBag = new();
                ConcurrentBag<string> errorBag = new();
                if (filteredAtmTasks?.Count > 0 && filteredAtmTasks.Any(x => x.DataFileCount > 0))
                {
                    Parallel.ForEach(filteredAtmTasks.Where(x => x.DataFileCount > 0), async model =>
                    {
                        var dataFileResponse = await service.GetDataFileAsync(model.TaskId, model.FileTypeId, model.AtmId, model.TaskTypeId);
                        if (dataFileResponse.isSucess && string.IsNullOrEmpty(dataFileResponse.DataFile))
                        {
                            await RenderInfoBox("Information", "Data file not found");
                        }
                        else if (dataFileResponse.isSucess && !string.IsNullOrEmpty(dataFileResponse.DataFile))
                        {
                            dataBag.Add(dataFileResponse.DataFile);
                        }
                        else
                        {
                            errorBag.Add("error");
                            await RenderErrorBox("Error", "And error occured, kindly check logs..");
                        }
                    });
                }
                else
                {
                    await RenderInfoBox("Information", "Data file/s not found");
                }

                if (dataBag?.Count > 0)
                {
                    dataBag.ToList().ForEach(item => mergeData.Append(item + Environment.NewLine));
                    await File.WriteAllLinesAsync(@$"{tempFolder}\CashDataFile_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.txt", new List<string> { mergeData.ToString() });
                    await jsRuntime.InvokeVoidAsync("downloadFile", mergeData.ToString(), @$"CashDataFile2_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.txt");
                    await RenderSuccessBox("Download success", $"File downloaded at {tempFolder}");
                }

                if (errorBag?.Count > 0)
                {
                    await RenderErrorBox("Error", "An error occured, kindly check logs..");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, GetTaskDetail as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
        }

        public async Task SaveAsText(AtmTaskViewModel model)
        {
            try
            {
                var dataFileResponse = await service.GetDataFileAsync(model.TaskId, model.FileTypeId, model.AtmId, model.TaskTypeId);
                if (dataFileResponse.isSucess && string.IsNullOrEmpty(dataFileResponse.DataFile))
                {
                    await RenderInfoBox("Information", "Data file not found");
                }
                else if (dataFileResponse.isSucess && !string.IsNullOrEmpty(dataFileResponse.DataFile))
                {
                    dataFile = dataFileResponse.DataFile;
                    await File.WriteAllLinesAsync(@$"{tempFolder}\CashDataFile_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.txt", new List<string> { dataFile });
                    await jsRuntime.InvokeVoidAsync("downloadFile", dataFile, @$"CashDataFile2_{DateTime.Now.ToString("MM_dd_yyyy_H_mm")}.txt");
                    await RenderSuccessBox("Download success", $"File downloaded at {tempFolder}");
                }
                else
                {
                    await RenderErrorBox("Error", "An error occured, kindly check logs..");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AtmTask, GetTaskDetail as: {ex.Message}");
                await RenderErrorBox("Error", ex.Message);
            }
        }

        private async Task Reparse(long taskID, long atmID)
        {
            await NotificationService.Info("Reparse in progress..", "Information", (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
            string response = await service.ReparseTask(taskID, atmID);
            if (!string.IsNullOrEmpty(response))
            {
                if (response != "success")
                {
                    await NotificationService.Error(response, "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else
                {
                    await NotificationService.Success("Reparse Task successfully", "Success", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }

                await Task.Delay(300);
                await HideModal();
                logger.LogWarning($"Atm Task Page: Reparse : {DateTime.Now.ToString()}");
                await LoadData(false);
            }
        }

        private async Task ScheduleConfiguration()
        {
            showSpinner = true;
            showGrid = false;
            await this.InvokeAsync(() => this.StateHasChanged());
            string response = await service.ScheduleConfiguration();
            if (!string.IsNullOrEmpty(response))
            {
                if (response == Common.Constants.Messages.AtmSelectionMsg)
                {
                    await NotificationService.Info(Common.Constants.Messages.AtmSelectionMsg, "Information", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else if (response == Common.Constants.Messages.AtmAlreadyScheduleMsg)
                {
                    await NotificationService.Info(Common.Constants.Messages.AtmAlreadyScheduleMsg, "Information", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
                else if (response == Common.Constants.Messages.AllAtmSucessMsg || response == Common.Constants.Messages.AllAtmSucessWithExceptMsg)
                {
                    await NotificationService.Success(response, "Success", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                    await Task.Delay(300);
                    logger.LogWarning($"Atm Task Page: ScheduleConfiguration : {DateTime.Now.ToString()}");
                    await LoadData(false);
                }
                else
                {
                    await NotificationService.Error(response, "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }

            showSpinner = false;
            showGrid = true;
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private void ResetFilter()
        {
            filterView.filterTaskTypes = filterView.filterUser = filterView.filterTaskStatus = filterView.filterAtmType = "-1";
            fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 0);
            //LoadData();
        }

        private async Task DownloadFileTask()
        {
            visible = false;
            alertText = string.Empty;
            string response = await service.DownloadFileTask(fileTypes.FirstOrDefault(x => x.FileTypeTitle == fileType).FileTypeId);
            if (!string.IsNullOrEmpty(response))
            {
                if (response != "success")
                {
                    alertText = response;
                    visible = true;
                }
                else if (response == "success")
                {
                    await HideDwnldFileModal();
                    await NotificationService.Success(Common.Constants.Messages.FileDwnldSucessMsg, "Success", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                    await Task.Delay(300);
                    logger.LogWarning($"Atm Task Page: DownloadFileTask : {DateTime.Now.ToString()}");
                    await LoadData(false);
                    //if (IsConnected) await SendMessage();
                }
                else
                {
                    await NotificationService.Error(response, "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
        }

        public async Task RenderSuccessBox(string title, string message)
        {
            await NotificationService.Success(message, title, (options) =>
            {
                options.IntervalBeforeClose = 4000;
            });
        }

        async Task RenderInfoBox(string title, string message)
        {
            await NotificationService.Info(message, title, (options) =>
            {
                options.IntervalBeforeClose = 3000;
            });
            await Task.CompletedTask;
        }

        public async Task RenderErrorBox(string title, string message)
        {
            await NotificationService.Error(message, title, (options) =>
            {
                options.IntervalBeforeClose = 5000;
            });
        }

        private Task DateChanged(int selectedYear)
        {
            ArchiveYear = selectedYear;
            fromDate = new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second);
            toDate = new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second);
            this.InvokeAsync(() => this.StateHasChanged());
            return Task.CompletedTask;
        }
    }
}