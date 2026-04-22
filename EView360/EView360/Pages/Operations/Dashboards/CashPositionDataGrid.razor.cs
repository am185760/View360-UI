using global::Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Blazorise;
using Blazorise.DataGrid;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using DataRequestor;
using System.Data;
using DataRequestorMiddleware.Services.Admin;
using EView360Models.Core;

namespace EView360.Pages.Operations.Dashboards
{
    public partial class CashPositionDataGrid
    {
        [Parameter]
        public long NoteSetTypeId { get; set; }

        [Parameter]
        public int minNoteThresholdReached { get; set; }

        [Parameter]
        public int ArchiveYear { get; set; }

        [Parameter]
        public bool IsRecycler { get; set; }

        [Parameter]
        public string? FilterValues { get; set; }

        [Parameter]
        public bool IsRegion { get; set; }

        private bool showSpinner = true;
        private bool showGrid = false;
        public List<CashPositionViewModel>? cashPositions = new();
        public List<CashPositionViewModel>? _cashPositions = new();
        private DataGrid<CashPositionViewModel>? dataGridRef;
        private Executor executor = new Executor();
        CashPositionFilter cashPositionFilter = new();
        [Inject]
        INotificationService NotificationService { get; set; }

        private static System.Timers.Timer aTimer;
        private int dashboardRefreshInterval = 0;
        private int counter = 0;
        private string refreshCurrentTime = string.Empty;
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

        protected override async Task OnInitializedAsync()
        {
            try
            {
                logger.LogWarning($"CashPost DataGrid: OnInitializedAsync : {DateTime.Now.ToString()}");
                executor.RaiseCustomEvent += PopulateModel;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Cash Position Dashboard DataGrid, OnInitializedAsync as: {ex.Message}");
                await commonService.RenderErrorBox(ex.Message);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    logger.LogWarning($"CashPost DataGrid: OnAfterRenderAsync : {DateTime.Now.ToString()}");

                    appUser = await localStorage.GetItemAsync<AppUser>("AppUser");

                    dashboardRefreshInterval = await commonService.GetDashhboardRefreshInterval();
                    if (cashPositions is null || cashPositions.Count == 0)
                    {
                        cashPositionFilter = new()
                        {
                            date = DateTime.Now,
                            NoteSetTypeIds = new List<string>()
                            {
                                NoteSetTypeId.ToString()
                            },
                            MinNotesAlertExists = minNoteThresholdReached,
                            OrderBy = "total asc",
                            archiveYear = (ArchiveYear != 0) ? ArchiveYear : null,
                            SpName = (IsRecycler) ? "GetDashboardRecyclerCashPosition" : "GetDashboardCashPosition",
                            isRegionSelected = IsRegion,
                            Filter = " and ua.user_id = " + appUser.UserId + " and " + (IsRegion ? "outerATM.region_id in " : "outerATM.atm_id in ") + FilterValues,
                            Values = FilterValues
                        };
                        await LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Cash Position Dashboard DataGrid, OnAfterRenderAsync as: {ex.Message}");
                await commonService.RenderErrorBox(ex.Message);
            }
        }

        private void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortDirection = e.SortDirection;

            if (sortDirection == SortDirection.Ascending)
            {
                cashPositions = cashPositions.OrderBy(item => item.GetType()
                    .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
            else if (sortDirection == SortDirection.Descending)
            {
                cashPositions = cashPositions.OrderByDescending(item => item.GetType()
                    .GetProperty(sortedColumn)
                    .GetValue(item, null)).ToList();
            }
        }

        private async Task OnReadData(DataGridReadDataEventArgs<CashPositionViewModel> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                List<CashPositionViewModel> response = null;
                // this can be call to anything, in this case we're calling a fictional api
                //var response = await Http.GetJsonAsync<Employee[]>( $"some-api/employees?page={e.Page}&pageSize={e.PageSize}" );
                if (e.ReadDataMode is DataGridReadDataMode.Virtualize)
                    response = cashPositions.Skip(e.VirtualizeOffset).Take(e.VirtualizeCount).ToList();
                else
                    throw new Exception("Unhandled ReadDataMode");
                if (!e.CancellationToken.IsCancellationRequested)
                {
                    _cashPositions = new List<CashPositionViewModel>(response); // an actual data for the current page
                }
            }
        }

        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"CashPost DataGrid: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");

            foreach (DataRow row in args?._data?.Rows)
            {
                CashPositionViewModel cashPosition = new()
                {
                    AtmTitle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                    LastTrxnAt = !DBNull.Value.Equals(row["last_trxn_at"]) ? Convert.ToDateTime(row["last_trxn_at"]) : DateTime.Now,
                    LastReplenishmentAt = !DBNull.Value.Equals(row["last_replenished_at"]) ? Convert.ToDateTime(row["last_replenished_at"]) : DateTime.Now,
                    DenominationType1 = !DBNull.Value.Equals(row["denomination_type_1"]) ? Convert.ToInt32(row["denomination_type_1"]) : null,
                    Cassette1Denomination = !DBNull.Value.Equals(row["cassette1_notes"]) ? Convert.ToInt32(row["cassette1_notes"]) : 0,
                    DenominationType2 = !DBNull.Value.Equals(row["denomination_type_2"]) ? Convert.ToInt32(row["denomination_type_2"]) : null,
                    Cassette2Denomination = !DBNull.Value.Equals(row["cassette2_notes"]) ? Convert.ToInt32(row["cassette2_notes"]) : 0,
                    DenominationType3 = !DBNull.Value.Equals(row["denomination_type_3"]) ? Convert.ToInt32(row["denomination_type_3"]) : null,
                    Cassette3Denomination = !DBNull.Value.Equals(row["cassette3_notes"]) ? Convert.ToInt32(row["cassette3_notes"]) : 0,
                    DenominationType4 = !DBNull.Value.Equals(row["denomination_type_4"]) ? Convert.ToInt32(row["denomination_type_4"]) : null,
                    Cassette4Denomination = !DBNull.Value.Equals(row["cassette4_notes"]) ? Convert.ToInt32(row["cassette4_notes"]) : 0,
                    TotalRemaining = !DBNull.Value.Equals(row["total_text"]) ? Convert.ToDecimal(row["total_text"]) : null,
                    PurgedNotes = !DBNull.Value.Equals(row["purged_counts"]) ? Convert.ToInt32(row["purged_counts"]) : null,
                    PurgedAmount = !DBNull.Value.Equals(row["purged_amount"]) ? Convert.ToInt32(row["purged_amount"]) : null,
                    MinOperatingBalance = (!IsRecycler && !DBNull.Value.Equals(row["min_operating_balance"])) ? Convert.ToDecimal(row["min_operating_balance"]) : null
                };
                cashPositions.Add(cashPosition);
            }
            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at CashPost DataGrid, PopulateModel as: {args._exception.Message}");
                await commonService.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at CashPost DataGrid, PopulateModel as: {args._exception.InnerException.Message}");
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

        private async Task LoadData()
        {
            logger.LogWarning($"CashPost DataGrid: **LoadData** : {DateTime.Now.ToString()}");

            cashPositions = new();
            showSpinner = true;
            showGrid = false;
            await this.InvokeAsync(() => this.StateHasChanged());
            await Task.Delay(3);

            service.GetDashboardCashPosition(cashPositionFilter, executor);
        }

        public void Dispose()
        {
            if (aTimer != null)
            {
                aTimer.Dispose();
            }
        }
    }
}