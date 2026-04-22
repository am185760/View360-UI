using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using EView360;
using EView360.Shared;
using Blazorise;
using Blazorise.DataGrid;
using Blazorise.Components;
using Blazorise.Snackbar;
using Blazorise.Charts;
using EView360.Common;
using EView360.Services;
using EView360.Services.Operations.DashBoard;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using global::Common.ViewModel;
using static EView360.Common.Constants;
using DataRequestor;
using static Azure.Core.HttpHeader;
using System.Data;
using EView360.Data;

namespace EView360.Pages.Operations.Dashboards
{
    public partial class MinimumThresholdDashboardDataGrid
    {
        [Parameter]
        public int? NoteSetTypeId { get; set; }

        [Parameter]
        public string? FilterValues { get; set; }

        [Parameter]
        public bool IsRegion { get; set; }
        public int pageSize { get; set; }

        private bool showSpinner = true;
        private bool showGrid = false;
        public List<MinimumThresholdViewModel>? minimumThresholdDashboard = new();
        public List<MinimumThresholdViewModel>? _minimumThresholdDashboard = new();
        public List<Atm>? Atms = new();
        private DataGrid<MinimumThresholdViewModel>? dataGridRef;
        PeriodicTimer timer;
        private int counter = 0;
        private string refreshCurrentTime = string.Empty;
        private static System.Timers.Timer aTimer;
        int dashboardRefreshInterval = 0;
        [Inject]
        INotificationService NotificationService { get; set; }

        private Executor executor = new Executor();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                executor.RaiseCustomEvent += PopulateModel;

            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at minimumThresholdDashboard : OnInitializedAsync as: {ex.Message}");
                await commonService.RenderErrorBox(ex.Message);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    dashboardRefreshInterval = await commonService.GetDashhboardRefreshInterval();
                    // await RefreshDashboard();
                    if (minimumThresholdDashboard is null || minimumThresholdDashboard.Count == 0)
                    {
                        await LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at minimumThresholdDashboard DataGrid, OnAfterRenderAsync as: {ex.Message}");
                await commonService.RenderErrorBox(ex.Message);
            }
        }

        private async Task LoadData()
        {
            showGrid = false;
            showSpinner = true;
            await this.InvokeAsync(() => this.StateHasChanged());
            await commonService.TaskDelay();
            EView360Models.Core.AppUser appUser = await localStorage.GetItemAsync<EView360Models.Core.AppUser>("AppUser");

            //var selectedAtms = await localStorage.GetItemAsync<List<long>>(SessionStorageKeys.SelectedtAtmId);
            //var selectedAtmsIds = selectedAtms.ConvertAll(x => x.ToString());
            //var selectedAtmsIds = (await treeService.GetSelectedAtmId()).ConvertAll(x => x.ToString());
            logger.LogWarning("[MinimumThresholdDashboardDataGrid:LoadData] going in GetMinimumThresholdDashboard");
            await service.GetMinimumThresholdDashboard(FilterValues, appUser.UserId, IsRegion, executor);
            logger.LogWarning("[MinimumThresholdDashboardDataGrid:LoadData] return from GetMinimumThresholdDashboard");
            // counter = dashboardRefreshInterval * 60;
            // refreshCurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            // StartTimer();
            // showSpinner = false;
            // showGrid = true;
            // await this.InvokeAsync(() => this.StateHasChanged());
            // await jsRuntime.InvokeVoidAsync("handleDashboardSpinner");
        }

        private async Task RefreshDashboard()
        {
            while (await timer.WaitForNextTickAsync())
            {
                await LoadData();
            }
        }

        public void Dispose()
        {
            if (aTimer != null)
            {
                aTimer.Dispose();
            }
        }

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

        private async Task OnReadData(DataGridReadDataEventArgs<MinimumThresholdViewModel> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                List<MinimumThresholdViewModel> response = null;
                if (e.ReadDataMode is DataGridReadDataMode.Virtualize)
                    response = minimumThresholdDashboard?.Skip(e.VirtualizeOffset).Take(e.VirtualizeCount).ToList();
                else
                    throw new Exception("Unhandled ReadDataMode");
                if (!e.CancellationToken.IsCancellationRequested)
                {
                    _minimumThresholdDashboard = new List<MinimumThresholdViewModel>(response); // an actual data for the current page
                }
            }
        }
        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            List<MinimumThresholdViewModel> minimumThresholds = new();

            if (args._data != null)
            {
                foreach (DataRow row in args._data.Rows)
                {
                    MinimumThresholdViewModel minimumThreshold = new()
                    {
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        MinimumThresholdBalance = !DBNull.Value.Equals(row["min_operating_balance"]) ? Convert.ToDouble(row["min_operating_balance"].ToString()) : 0,
                        RemainingAmount = !DBNull.Value.Equals(row["total"]) ? Convert.ToInt32(row["total"].ToString()) : 0,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IpAddress = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        NoteSetTypeName = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
                    };

                    minimumThresholds.Add(minimumThreshold);
                }
            }

            if (minimumThresholds?.Count > 0)
            {
                minimumThresholdDashboard.AddRange(minimumThresholds);
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at minimumThresholdDashboard DataGrid, PopulateModel as: {args._exception.Message}");
                await commonService.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at minimumThresholdDashboard DataGrid, PopulateModel as: {args._exception.InnerException.Message}");
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
        private void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortDirection = e.SortDirection;

            if (sortDirection == SortDirection.Ascending)
            {
                minimumThresholdDashboard = minimumThresholdDashboard.OrderBy(item => item.GetType()
                .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
            else if (sortDirection == SortDirection.Descending)
            {
                minimumThresholdDashboard = minimumThresholdDashboard.OrderByDescending(item => item.GetType()
                .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
        }
    }
}