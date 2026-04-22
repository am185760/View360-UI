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
using EView360.Services.Operations;
using EView360.Common;
using EView360.Services;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using static EView360.Common.Constants;
using DataRequestor;
using System.Data;
using Common.ViewModel;
using EView360.Data;

namespace EView360.Pages.Operations.Dashboards
{
    public partial class BNATransactionDataGrid
    {
        [Parameter]
        public int? NoteSetTypeId { get; set; }

        [Parameter]
        public string? FilterValues { get; set; }

        [Parameter]
        public bool IsRegion { get; set; }

        [Parameter]
        public int? ArchiveYear { get; set; }
        public int pageSize { get; set; }

        private bool showSpinner = true;
        private bool showGrid = false;
        public List<BnaTransactionDashboardViewModel>? bNATransactionDashboard = new();
        public List<BnaTransactionDashboardViewModel>? _bNATransactionDashboard = new();
        public List<Atm>? Atms = new();
        private DataGrid<BnaTransactionDashboardViewModel>? dataGridRef;
        BNADepositRequestModel bNATransaction = new();
        PeriodicTimer timer;
        [Inject]
        INotificationService NotificationService { get; set; }

        private int counter = 0;
        private string refreshCurrentTime = string.Empty;
        private static System.Timers.Timer aTimer;
        int dashboardRefreshInterval = 0;
        private Executor executor = new Executor();
        private SortDirection sortDirection = new();
        private string sortField = string.Empty;
        string? orderby = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                executor.RaiseCustomEvent += PopulateModel;
                //Atms = await treeService.GetAtmList();
                if (bNATransactionDashboard is null || bNATransactionDashboard.Count == 0)
                {
                    bNATransaction = new()
                    {
                        NodeSetTypeId = this.NoteSetTypeId,
                        ArchiveYear = ArchiveYear == 0 ? string.Empty : ArchiveYear.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at BNA Transcation Dashboard DataGrid, OnInitializedAsync as: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    dashboardRefreshInterval = await common.GetDashhboardRefreshInterval();
                    await LoadData();
                    //counter = dashboardRefreshInterval * 60;
                    //timer = new PeriodicTimer(TimeSpan.FromMinutes(dashboardRefreshInterval));
                    //await RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at BNA Transaction Dashboard DataGrid, OnAfterRenderAsync as: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
        }

        private async Task LoadData()
        {
            logger.LogWarning($"BNATransactionDataGrid: **LoadData**");
            EView360Models.Core.AppUser appUser = await localStorage.GetItemAsync<EView360Models.Core.AppUser>("AppUser");
            showGrid = false;
            showSpinner = true;
            await this.InvokeAsync(() => this.StateHasChanged());
            await common.TaskDelay();
            bNATransaction.UserId = appUser.UserId;
            //var selectedAtms = await localStorage.GetItemAsync<List<long>?>("GlobalAtmSelected");
            //var selectedAtms = await localStorage.GetItemAsync<List<long>>(SessionStorageKeys.SelectedtAtmId);
            //List<long>? selectedAtmIds = await _atmTreeService?.GetSelectedAtmId()
            //bNATransaction.SelectedAtmIds = selectedAtms.ConvertAll(x => x.ToString());
            logger.LogWarning("[BnaTransactionDashboardDataGrid:LoadData] going in GetBNATransactionDashboard");
            await service.GetBNATransactionDashboard(bNATransaction, FilterValues, IsRegion, executor);
            logger.LogWarning("[BnaTransactionDashboardDataGrid:LoadData] return from GetBNATransactionDashboard");
            //counter = dashboardRefreshInterval * 60;
            //refreshCurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //StartTimer();
            //showSpinner = false;
            //showGrid = true;
            //await this.InvokeAsync(() => this.StateHasChanged());
            //await jsRuntime.InvokeVoidAsync("handleDashboardSpinner");
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

        private async Task OnReadData(DataGridReadDataEventArgs<BnaTransactionDashboardViewModel> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                List<BnaTransactionDashboardViewModel> response = null;
                // this can be call to anything, in this case we're calling a fictional api
                //var response = await Http.GetJsonAsync<Employee[]>( $"some-api/employees?page={e.Page}&pageSize={e.PageSize}" );
                if (e.ReadDataMode is DataGridReadDataMode.Virtualize)
                    response = bNATransactionDashboard?.Skip(e.VirtualizeOffset).Take(e.VirtualizeCount).ToList();
                else
                    throw new Exception("Unhandled ReadDataMode");
                if (!e.CancellationToken.IsCancellationRequested)
                {
                    _bNATransactionDashboard = new List<BnaTransactionDashboardViewModel>(response); // an actual data for the current page
                }
            }
        }
        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            List<BnaTransactionDashboardViewModel> bnaTransactions = new();

            if (args._data != null)
            {
                foreach (DataRow row in args._data.Rows)
                {
                    BnaTransactionDashboardViewModel bnaTransaction = new()
                    {

                        AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt64(row["atm_id"]) : 0,
                        Cassette1 = !DBNull.Value.Equals(row["cassette1_deposit"]) ? Convert.ToInt32(row["cassette1_deposit"]) : 0,
                        Cassette2 = !DBNull.Value.Equals(row["cassette2_deposit"]) ? Convert.ToInt32(row["cassette2_deposit"]) : 0,
                        Cassette3 = !DBNull.Value.Equals(row["cassette3_deposit"]) ? Convert.ToInt32(row["cassette3_deposit"]) : 0,
                        Cassette4 = !DBNull.Value.Equals(row["cassette4_deposit"]) ? Convert.ToInt32(row["cassette4_deposit"]) : 0,
                        Cassette5 = !DBNull.Value.Equals(row["purge_deposit"]) ? Convert.ToInt32(row["purge_deposit"]) : 0,
                        LastBNADeposit = !DBNull.Value.Equals(row["last_bna_deposit_at"]) ? Convert.ToDateTime(row["last_bna_deposit_at"]) : null,
                        LastBNAClearedAt = !DBNull.Value.Equals(row["last_bna_cleared_at"]) ? Convert.ToDateTime(row["last_bna_cleared_at"]) : null,
                        //Total = ExtractDepositAmount(row["cassette1_deposit_value"].ToString(), row["cassette2_deposit_value"].ToString(), row["cassette3_deposit_value"].ToString(), row["cassette4_deposit_value"].ToString()),
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Region = !DBNull.Value.Equals(row["Region_name"]) ? row["Region_name"].ToString() : string.Empty,
                        //DenominationDetail = !DBNull.Value.Equals(row["cassette1_deposit_value"]) ? row["cassette1_deposit_value"].ToString() : string.Empty,
                    };
                    bnaTransaction.Total = bnaTransaction.Cassette1 + bnaTransaction.Cassette2 + bnaTransaction.Cassette3 + bnaTransaction.Cassette4 + bnaTransaction.Cassette5;
                    bnaTransactions.Add(bnaTransaction);
                }
            }
            if (bnaTransactions?.Count > 0)
            {
                bNATransactionDashboard.AddRange(bnaTransactions);
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at Bna transaction Dashboard DataGrid, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at Bna transaction Dashboard DataGrid, PopulateModel as: {args._exception.InnerException.Message}");
                    await common.RenderErrorBox(args._exception.InnerException.Message);
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
                bNATransactionDashboard = bNATransactionDashboard.OrderBy(item => item.GetType()
                .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
            else if (sortDirection == SortDirection.Descending)
            {
                bNATransactionDashboard = bNATransactionDashboard.OrderByDescending(item => item.GetType()
                .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
        }
    }
}