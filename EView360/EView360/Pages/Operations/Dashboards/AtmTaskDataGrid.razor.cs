using Azure;
using Blazorise;
using Blazorise.DataGrid;
using DataRequestor;
using EView360Models.Core;
using EView360Models.ViewModels;
using global::Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;
using System.Dynamic;
using System.Reflection;

namespace EView360.Pages.Operations.Dashboards
{
    public partial class AtmTaskDataGrid
    {
        [Parameter]
        public string? NoteSetTypeId { get; set; }

        [Parameter]
        public string? ArchiveYear { get; set; }

        [Parameter]
        public string? FilterValues { get; set; }

        [Parameter]
        public bool IsRegion { get; set; }

        private bool showSpinner = true;
        private bool showGrid = false;
        public List<AtmTaskViewModel>? atmTaskViews = new();
        public List<AtmTaskViewModel>? _atmTaskViews = new();
        private DataGrid<AtmTaskViewModel>? dataGridRef;
        [Inject]
        INotificationService NotificationService { get; set; }

        private static System.Timers.Timer aTimer;
        private int dashboardRefreshInterval = 0;
        private int counter = 0;
        private string refreshCurrentTime = string.Empty;
        private Executor executor = new Executor();
        AppUser appUser = new();
        public void StartTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += CountDownTimer;
            aTimer.Enabled = true;
        }

        public async void CountDownTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (counter > 0)
            {
                counter -= 1;
            }
            else
            {
                if (aTimer != null && aTimer.Enabled)
                {
                    aTimer.Dispose();
                    await LoadData();
                }
            }
            await InvokeAsync(StateHasChanged);
        }

        //private HubConnection hubConnection;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                logger.LogWarning($"Atm TaskDataGrid: OnInitializedAsync : {DateTime.Now.ToString()}");

                executor.RaiseCustomEvent += PopulateModel;
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
                //hubConnection.On("ReceiveMessage", () =>
                //{
                //    CallLoadData();
                //    //InvokeAsync(StateHasChanged);
                //});
                //await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at ATM Task Dashboard DataGrid, OnInitializedAsync as: {ex.Message}");
                await commonService.RenderErrorBox(ex.Message);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    logger.LogWarning($"Atm TaskDataGrid: OnAfterRenderAsync : {DateTime.Now.ToString()}");

                    appUser = await localStorage.GetItemAsync<AppUser>("AppUser");

                    dashboardRefreshInterval = await commonService.GetDashhboardRefreshInterval();
                    if (atmTaskViews is null || atmTaskViews.Count == 0)
                    {
                        await LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at ATM Task Dashboard DataGrid, OnAfterRenderAsync as: {ex.Message}");
                await commonService.RenderErrorBox(ex.Message);
            }
        }
        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"Atm TaskDataGrid: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            List<AtmTaskViewModel>? lst = new();

            foreach (DataRow row in args?._data?.Rows)
            {
                AtmTaskViewModel atmTaskView = new()
                {
                    AtmId = !DBNull.Value.Equals(row["ATM_ID"]) ? Convert.ToInt32(row["ATM_ID"]) : 0,
                    LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? Convert.ToDateTime(row["last_invoked"]) : null,
                    AtmType = !DBNull.Value.Equals(row["atm_type"]) ? row["atm_type"].ToString() : string.Empty,
                    AtmIP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                    FileTypeTitle = !DBNull.Value.Equals(row["file_type_title"]) ? row["file_type_title"].ToString() : string.Empty,
                    AtmTitle = !DBNull.Value.Equals(row["TITLE"]) ? row["TITLE"].ToString() : string.Empty,
                    CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? Convert.ToDateTime(row["creation_time"]) : DateTime.Now,
                    TaskTypeName = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                    Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                    EndTime = !DBNull.Value.Equals(row["end_time"]) ? Convert.ToDateTime(row["end_time"]) : null,
                    RetryRemaining = !DBNull.Value.Equals(row["retry_remaining"]) ? Convert.ToInt32(row["retry_remaining"]) : 0,
                    FailureReason = !DBNull.Value.Equals(row["failure_reason"]) ? row["failure_reason"].ToString() : string.Empty,
                };

                lst.Add(atmTaskView);                
            }

            if (lst?.Count > 0)
            {
                var groupLst = lst
                    .GroupBy(c => c.AtmId)
                    .Select(grp => new
                    {
                        grp.Key,
                        LastAccess = grp
                         .OrderByDescending(x => x.CreationTime)
                         .Select(x => x.CreationTime)
                         .FirstOrDefault()
                    }).ToList();

                if (groupLst?.Count > 0)
                {
                    atmTaskViews.AddRange(lst.Where(x => groupLst.Any(y => y.LastAccess == x.CreationTime)).ToList());
                }
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at ATM Task Dashboard DataGrid, PopulateModel as: {args._exception.Message}");
                await commonService.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at ATM Task Dashboard DataGrid, PopulateModel as: {args._exception.InnerException.Message}");
                    await commonService.RenderErrorBox(args._exception.InnerException.Message);
                }
            }

            if (!showGrid)
            {
                showGrid = true;
                showSpinner = false;
                counter = dashboardRefreshInterval * 60;
                refreshCurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                StartTimer();                
            }
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        //public class GridSortHelper<TItem>
        //{
        //    public List<TItem> SortData(IEnumerable<TItem> data, string sortBy, SortDirection sortDirection)
        //    {
        //        var sortedData = data.ToList();

        //        // Implement your custom sorting logic here.
        //        // For example, you can sort the data based on the "sortBy" field and "sortDirection".

        //        return sortedData;
        //    }
        //}

        private void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortDirection = e.SortDirection;

            if (sortDirection == SortDirection.Ascending)
            {
                atmTaskViews = atmTaskViews.OrderBy(item => item.GetType()
                    .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
            else if (sortDirection == SortDirection.Descending)
            {
                atmTaskViews = atmTaskViews.OrderByDescending(item => item.GetType()
                    .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
        }



        private async Task OnReadData(DataGridReadDataEventArgs<AtmTaskViewModel> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                List<AtmTaskViewModel> response = null;
                // this can be call to anything, in this case we're calling a fictional api
                //var response = await Http.GetJsonAsync<Employee[]>( $"some-api/employees?page={e.Page}&pageSize={e.PageSize}" );
                if (e.ReadDataMode is DataGridReadDataMode.Virtualize)
                    response = atmTaskViews.Skip(e.VirtualizeOffset).Take(e.VirtualizeCount).ToList();
                else
                    throw new Exception("Unhandled ReadDataMode");
                if (!e.CancellationToken.IsCancellationRequested)
                {
                    _atmTaskViews = new List<AtmTaskViewModel>(response); // an actual data for the current page
                }
            }
        }

        //public bool IsConnected =>
        //    hubConnection.State == HubConnectionState.Connected;s
        public void Dispose()
        {
            if (aTimer != null)
            {
                aTimer.Dispose();
            }
            //_ = hubConnection.DisposeAsync();
            //if (timer != null)
            //{
            //    timer.Dispose();
            //}
        }

        private async Task LoadData()
        {
            logger.LogWarning($"Atm TaskDataGrid: **LoadData** : {DateTime.Now.ToString()}");

            atmTaskViews = new();
            showSpinner = true;
            showGrid = false;
            await this.InvokeAsync(() => this.StateHasChanged());
            await Task.Delay(3);
            string filter = (!string.IsNullOrEmpty(NoteSetTypeId) && NoteSetTypeId != "0") ? $" and ATM.note_set_type_id ={NoteSetTypeId} " : string.Empty;
            filter += " and ua.user_id = " + appUser.UserId;
            filter += " and " + (IsRegion ? "atm.region_id in " : "atm.atm_id in ") + FilterValues;
            service.GetAtmTaskDashboard(IsRegion, filter, executor, FilterValues, null);
        }
    }
}