using global::Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Blazorise;
using Blazorise.DataGrid;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using System.Data;

namespace EView360.Pages.Operations
{
    public partial class CashPositions
    {
        private bool showSpinner = false;
        private bool showGrid = false;
        bool showCancelBtn = false;
        static DateTime currentTime = DateTime.Now;
        DateTime fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
        DateTime toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 0);
        public List<CashPositionViewModel>? cashPositions = new();
        public List<CashPositionViewModel>? _cashPositions = new();
        public List<CashPositionViewModel>? filteredCashPositions = new();
        public List<NoteSetTypeViewModel>? noteSetTypes = new();
        private DataGrid<CashPositionViewModel>? dataGridRef;
        [Inject]
        INotificationService NotificationService { get; set; }

        [Inject]
        IMessageService MessageService { get; set; }

        DatePicker<DateTime>? dateRef;
        private long? selectedTreeRegion;
        private List<long>? selectedTreeAtm;
        private DotNetObjectReference<CashPositions>? objRef;
        //archive
        [Parameter]
        public string? mode { get; set; }

        bool isArchive = false;
        int ArchiveYear;
        [Parameter]
        public bool? IsRecycler { get; set; }
        //paging
        private int pageNo { get; set; }
        private int maxPageNo { get; set; }
        private int totalRecords { get; set; }

        private bool IsDisabled = false;
        private List<int> archiveYears = new();

        int totalRecordPerPage = 0;
        private Executor executor = new Executor();

        string orderByFilter = string.Empty;
        private string sortField = string.Empty;
        private SortDirection sortDirection = new();
        protected override async Task OnInitializedAsync()
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: OnInitializedAsync : {DateTime.Now.ToString()}");
            objRef = DotNetObjectReference.Create(this);
            totalRecordPerPage = _configuration.GetValue<int>("RecordPerPage");
            executor.RaiseCustomEvent += PopulateModel;

            if (!string.IsNullOrEmpty(mode) && mode.Equals("Archive"))
            {
                isArchive = true;
            }

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

            AppUser appUser = await localStorage.GetItemAsync<AppUser>("AppUser");
            notifyService.OnAtmChange += AtmSelected;
            notifyService.OnRegionChange += RegionSelected;
            if (appUser is not null)
            {
                service.UserId = appUser.UserId;
            }

            noteSetTypes = await service.GetNoteSetTypeAsync();
            if (noteSetTypes is null || !noteSetTypes.Any())
            {
                await RenderInfoBox("Information", "Note set types not found");
            }
            else
            {
                noteSetTypes.Select(x =>
                {
                    x.IsSelected = true;
                    return x;
                }).ToList();
            }

            await this.InvokeAsync(() => this.StateHasChanged());
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: SetParametersAsync : {DateTime.Now.ToString()}");
            filteredCashPositions = cashPositions = new List<CashPositionViewModel>();
            await base.SetParametersAsync(parameters);
        }

        protected override void OnParametersSet()
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: OnParametersSet : {DateTime.Now.ToString()}");
            ResetFilter();
            showSpinner = false;
            showGrid = false;
            pageNo = 1;
            if (!string.IsNullOrEmpty(mode) && mode.Equals("Archive"))
            {
                isArchive = true;
            }
            else
            {
                isArchive = false;
            }

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
            base.OnParametersSet();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                orderByFilter = " Order by last_trxn_at desc";
                logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: OnAfterRenderAsync : {DateTime.Now.ToString()}");
                await jsRuntime.InvokeVoidAsync("handleDatePicker", objRef);
            }
        }

        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"CashPositionHist: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            string error = string.Empty;

            if (args?._data?.Rows?.Count > 0)
            {
                _cashPositions = BuildCashPosition(args._data);

                cashPositions.AddRange(_cashPositions);
                filteredCashPositions = cashPositions;
                totalRecords += filteredCashPositions.FirstOrDefault().RowCount;
                maxPageNo = common.GetMaxPageNo(Convert.ToInt32(totalRecords));
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at CashPositionHist, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at CashPositionHist, PopulateModel as: {args._exception.InnerException.Message}");
                    await common.RenderErrorBox(args._exception.InnerException.Message);
                }
            }
            else if (cashPositions is null || cashPositions.Count == 0)
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

        public List<CashPositionViewModel> BuildCashPosition(DataTable dataTable)
        {
            List<CashPositionViewModel> cashPositions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    CashPositionViewModel cashPosition = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0,
                        AtmTitle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Ip = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        NoteSetTypeName = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
                        LastTrxnAt = !DBNull.Value.Equals(row["last_trxn_at"]) ? Convert.ToDateTime(row["last_trxn_at"]) : DateTime.Now,
                        LastSuccessfulTrxnAt = !DBNull.Value.Equals(row["last_successful_trxn_at"]) ? Convert.ToDateTime(row["last_successful_trxn_at"]) : DateTime.Now,
                        LastReplenishmentAt = !DBNull.Value.Equals(row["last_replenishment_at"]) ? Convert.ToDateTime(row["last_replenishment_at"]) : DateTime.Now,
                        DenominationType1 = !DBNull.Value.Equals(row["denomination_type_1"]) ? Convert.ToInt32(row["denomination_type_1"]) : null,
                        Cassette1Denomination = !DBNull.Value.Equals(row["cassette1_notes"]) ? Convert.ToInt32(row["cassette1_notes"]) : 0,
                        PurgeCassette1Notes = !DBNull.Value.Equals(row["purge_cassette1_notes"]) ? Convert.ToInt32(row["purge_cassette1_notes"]) : null,
                        DenominationType2 = !DBNull.Value.Equals(row["denomination_type_2"]) ? Convert.ToInt32(row["denomination_type_2"]) : null,
                        Cassette2Denomination = !DBNull.Value.Equals(row["cassette2_notes"]) ? Convert.ToInt32(row["cassette2_notes"]) : 0,
                        PurgeCassette2Notes = !DBNull.Value.Equals(row["purge_cassette2_notes"]) ? Convert.ToInt32(row["purge_cassette2_notes"]) : null,
                        DenominationType3 = !DBNull.Value.Equals(row["denomination_type_3"]) ? Convert.ToInt32(row["denomination_type_3"]) : null,
                        Cassette3Denomination = !DBNull.Value.Equals(row["cassette3_notes"]) ? Convert.ToInt32(row["cassette3_notes"]) : 0,
                        PurgeCassette3Notes = !DBNull.Value.Equals(row["purge_cassette3_notes"]) ? Convert.ToInt32(row["purge_cassette3_notes"]) : null,
                        DenominationType4 = !DBNull.Value.Equals(row["denomination_type_4"]) ? Convert.ToInt32(row["denomination_type_4"]) : null,
                        Cassette4Denomination = !DBNull.Value.Equals(row["cassette4_notes"]) ? Convert.ToInt32(row["cassette4_notes"]) : 0,
                        PurgeCassette4Notes = !DBNull.Value.Equals(row["purge_cassette4_notes"]) ? Convert.ToInt32(row["purge_cassette4_notes"]) : null,
                        DenominationType5 = !DBNull.Value.Equals(row["denomination_type_5"]) ? Convert.ToInt32(row["denomination_type_5"]) : null,
                        Cassette5Denomination = !DBNull.Value.Equals(row["cassette5_notes"]) ? Convert.ToInt32(row["cassette5_notes"]) : 0,
                        PurgeCassette5Notes = !DBNull.Value.Equals(row["purge_cassette5_notes"]) ? Convert.ToInt32(row["purge_cassette5_notes"]) : null,
                        DenominationType6 = !DBNull.Value.Equals(row["denomination_type_6"]) ? Convert.ToInt32(row["denomination_type_6"]) : null,
                        Cassette6Denomination = !DBNull.Value.Equals(row["cassette6_notes"]) ? Convert.ToInt32(row["cassette6_notes"]) : 0,
                        PurgeCassette6Notes = !DBNull.Value.Equals(row["purge_cassette6_notes"]) ? Convert.ToInt32(row["purge_cassette6_notes"]) : null,
                        DenominationType7 = !DBNull.Value.Equals(row["denomination_type_7"]) ? Convert.ToInt32(row["denomination_type_7"]) : null,
                        Cassette7Denomination = !DBNull.Value.Equals(row["cassette7_notes"]) ? Convert.ToInt32(row["cassette7_notes"]) : 0,
                        PurgeCassette7Notes = !DBNull.Value.Equals(row["purge_cassette7_notes"]) ? Convert.ToInt32(row["purge_cassette7_notes"]) : null,
                        TotalRemaining = !DBNull.Value.Equals(row["total_text"]) ? Convert.ToDecimal(row["total_text"]) : null,
                        TotalPurgedCashBalance = !DBNull.Value.Equals(row["totalPurged"]) ? Convert.ToDecimal(row["totalPurged"]) : null,
                        NextReplenishmentAt = !DBNull.Value.Equals(row["next_replenishment_at"]) ? Convert.ToDateTime(row["next_replenishment_at"]) : null,
                        Amount = !DBNull.Value.Equals(row["amount"]) ? Convert.ToDecimal(row["amount"]) : null
                    };
                    cashPositions.Add(cashPosition);
                }
            }
            return cashPositions;
        }

        private async void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortedDirection = e.SortDirection;
            string? orderby = "Order by ";
            CashPositionViewModel model = new();

            if (this.sortDirection != sortedDirection || !this.sortField.Equals(sortedColumn))
            {
                //For Atm Fields

                if (sortedColumn.Equals(nameof(model.AtmTitle)))
                    orderby += " outerATM.title";

                else if (sortedColumn.Equals(nameof(model.Ip)))
                    orderby += " outerATM.IP";

                else if (sortedColumn.Equals(nameof(model.Location)))
                    orderby += " outerATM.location";

                else if (sortedColumn.Equals(nameof(model.NoteSetTypeName)))
                    orderby += " note_set_type_name";

                else if (sortedColumn.Equals(nameof(model.LastTrxnAt)))
                    orderby += " last_trxn_at";

                else if (sortedColumn.Equals(nameof(model.LastReplenishmentAt)))
                    orderby += " last_replenishment_at";

                else if (sortedColumn.Equals(nameof(model.DenominationType1)))
                    orderby += " note_set_type.denomination_type_1";

                else if (sortedColumn.Equals(nameof(model.Cassette1Denomination)))
                    orderby += " p.cassette1_notes";

                else if (sortedColumn.Equals(nameof(model.PurgeCassette1Notes)))
                    orderby += " p.purge_cassette1_notes";

                else if (sortedColumn.Equals(nameof(model.DenominationType2)))
                    orderby += " note_set_type.denomination_type_2";

                else if (sortedColumn.Equals(nameof(model.Cassette2Denomination)))
                    orderby += " p.cassette2_notes";

                else if (sortedColumn.Equals(nameof(model.PurgeCassette2Notes)))
                    orderby += " p.purge_cassette2_notes";

                else if (sortedColumn.Equals(nameof(model.DenominationType3)))
                    orderby += " note_set_type.denomination_type_3";

                else if (sortedColumn.Equals(nameof(model.Cassette3Denomination)))
                    orderby += " p.cassette3_notes";

                else if (sortedColumn.Equals(nameof(model.PurgeCassette3Notes)))
                    orderby += " p.purge_cassette3_notes";

                else if (sortedColumn.Equals(nameof(model.DenominationType4)))
                    orderby += " note_set_type.denomination_type_4";

                else if (sortedColumn.Equals(nameof(model.Cassette4Denomination)))
                    orderby += " p.cassette4_notes";

                else if (sortedColumn.Equals(nameof(model.TotalRemaining)))
                    orderby += " total_text";

                else if (sortedColumn.Equals(nameof(model.TotalPurgedCashBalance)))
                    orderby += " totalPurged";

                else if (sortedColumn.Equals(nameof(model.Amount)))
                    orderby += " amount";

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

        private async Task GetDataByPageNo(int thisPageNo)
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: GetDataByPageNo : {DateTime.Now.ToString()}");
            pageNo = thisPageNo;
            await LoadData();
        }

        private async Task LoadData()
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: ** LoadData ** : {DateTime.Now.ToString()}");
            filteredCashPositions = cashPositions = new List<CashPositionViewModel>();
            string filter = string.Empty;
            List<string> atmIDs = new();
            List<string> regionIDs = new();
            showSpinner = true;
            showGrid = false;
            IsDisabled = true;
            totalRecords = 0;
            await this.InvokeAsync(() => this.StateHasChanged());
            await Task.Delay(5);

            (atmIDs, regionIDs) = await atmRepository.GetSelectedAtmOrRegionList();
            if (regionIDs?.Count > 0)
            {
                filter = " and ua.user_id = " + service.UserId;
                filter += " and outerATM.region_id in " + "(" + string.Join(",", regionIDs) + ")";
            }
            else
            {
                filter = " and ua.user_id = " + service.UserId;
                filter += " and outerATM.atm_id in " + "(" + string.Join(",", atmIDs) + ")";
            }

            if (isArchive)
            {
                fromDate = new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second);
                toDate = new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second);
            }

            CashPositionFilter cashPositionFilter = new()
            {
                fromDate = fromDate,
                toDate = toDate,
                NoteSetTypeIds = noteSetTypes?.Where(x => x.IsSelected == true)?.Select(y => y.NoteSetTypeId.ToString())?.ToList(),
                archiveYear = isArchive ? ArchiveYear : null,
                SpName = (IsRecycler.HasValue && IsRecycler.Value) ? "GetRecyclerCashPositions" : "GetCashPositions",
                Filter = filter,
                OrderBy = orderByFilter
            };

            if (atmRepository.SelectedAtmIds?.Count > 0)
            {
                service.GetCashPositionAsync(executor, pageNo, cashPositionFilter);
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

        private async Task ResetFilter()
        {
            noteSetTypes?.Select(x =>
            {
                x.IsSelected = true;
                return x;
            }).ToList();
            fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 0);
            //await LoadData();
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

        private async void AtmSelected()
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: AtmSelected : {DateTime.Now.ToString()}");
            await LoadData();
        }

        private async void RegionSelected()
        {
            logger.LogWarning($"{((IsRecycler.HasValue && IsRecycler.Value) ? "Recycler " : "")}Cash Positions Page: RegionSelected : {DateTime.Now.ToString()}");
            await LoadData();
        }

        public void Dispose()
        {
            notifyService.OnAtmChange -= AtmSelected;
            notifyService.OnRegionChange -= RegionSelected;
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