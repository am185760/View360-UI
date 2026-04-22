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
using EView360Models.Core;
using EView360.Services.Operations;
using EView360.Services;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using static EView360.Data.Enumerations;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using System.Data;

namespace EView360.Pages.Operations
{
    public partial class WithdrawalTransaction
    {
        [Parameter]
        public string? mode { get; set; }

        private List<long>? selectedTreeAtm;
        private long? selectedTreeRegion;
        int ArchiveYear;
        private List<int> archiveYears = new();
        private string Atm = "Please, select an ATM";
        private bool showSpinner = false;
        private bool showGrid = false;
        private bool showTransactionsBetweenReplenishmentsRow = false;
        private bool showFromDateAndToDateRow = false;
        private Modal? modalRef;
        string duration = string.Empty;
        private List<EView360Models.Core.Atm> userAtms = new();
        string cancelButtonText = string.Empty;
        bool showCancelBtn = false;
        int indexId, orderId = 0;
        DatePicker<DateTime> dateRef;
        static DateTime currentTime = DateTime.Now;
        DateTime fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
        DateTime toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
        int? purgedFrom, purgedTo, amountFrom, amountTo, dispensed1, dispensed2, dispensed3, dispensed4;
        int numberOfCycle = 2;
        public List<WithdrawalTransactionViewModel> WithdrawalTransactions = new();
        private List<WithdrawalTransactionViewModel> remove = new();
        private DataGrid<WithdrawalTransactionViewModel>? dataGridRef;
        private List<EView360Models.Core.NoteSetType>? noteSetType;
        private SortDirection sortDirection = new();
        private string sortField = string.Empty;
        string? orderby = string.Empty;
        Executor executor = new();
        private string? filterNoteSetTypeBy = "*";
        [Inject]
        INotificationService NotificationService { get; set; }

        [Inject]
        IMessageService MessageService { get; set; }

        private DotNetObjectReference<WithdrawalTransaction>? objRef;
        private List<WithdrawalTransactionViewModel>? filteredWithdrawalTransaction = null;
        private bool IsDisabled = false;
        //paging
        private int pageNo { get; set; }
        private int maxPageNo { get; set; }
        private int totalRecords { get; set; }
        EView360Models.Core.AppUser appUser { get; set; }
        protected override async Task OnInitializedAsync()
        {
            executor.RaiseCustomEvent += PopulateModel;
            objRef = DotNetObjectReference.Create(this);
            appUser = await localStorage.GetItemAsync<EView360Models.Core.AppUser>("AppUser");
            if (appUser is not null)
            {
                service.UserId = appUser.UserId;
                noteSetTypeService.UserId = appUser.UserId;
            }

            service.userAtmList = await treeService.GetAtmList();
            noteSetType = await noteSetTypeService.GetNoteSetTypeListAsync();
            notifyService.OnAtmChange += AtmSelected;
            notifyService.OnRegionChange += RegionSelected;
            if (mode is not null && mode.Equals("Archive"))
            {
                archiveYears = yearService.GetLastNYears(5);
                ArchiveYear = archiveYears.FirstOrDefault();
                fromDate = new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second, 0, 0, 0);
                toDate = new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second);
                await this.InvokeAsync(() => this.StateHasChanged());
            }
            else
            {
                fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
                toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                ArchiveYear = 0;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await jsRuntime.InvokeVoidAsync("handleDatePicker", objRef);
                }

                showTransactionsBetweenReplenishmentsRow = showFromDateAndToDateRow = false;
                if (indexId == 0)
                {
                    showFromDateAndToDateRow = true;
                }

                if (indexId == 2)
                {
                    showTransactionsBetweenReplenishmentsRow = true;
                }

                await this.InvokeAsync(() => this.StateHasChanged());
                if (firstRender && (WithdrawalTransactions is null || WithdrawalTransactions.Count == 0))
                {
                    //await LoadData();
                }

                if (firstRender && (service.userAtmList is null || service.userAtmList.Count == 0))
                {
                    service.userAtmList = await treeService.GetAtmList();
                }
                //Atm = taskService.GetSelectedAtm();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at WithDrawalTransaction, OnAfterRenderAsync as: {ex.Message}");
                await NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        private async Task LoadData()
        {
            WithdrawalTransactions = filteredWithdrawalTransaction = new();
            showSpinner = true;
            showGrid = false;
            IsDisabled = true;
            totalRecords = 0;
            maxPageNo = common.GetMaxPageNo(totalRecords);
            await this.InvokeAsync(() => this.StateHasChanged());
            await common.TaskDelay();
            var withdrawalTransactionFilter = new WithdrawalTransactionFilter
            {
                amountFrom = amountFrom,
                amountTo = amountTo,
                dispensed1 = dispensed1,
                dispensed2 = dispensed2,
                dispensed3 = dispensed3,
                dispensed4 = dispensed4,
                fromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second) : fromDate,
                toDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second) : toDate,
                purgedFrom = purgedFrom,
                purgedTo = purgedTo,
                indexId = indexId,
                UserId = appUser.UserId,
                numberOfCycle = numberOfCycle,
                noteSetTypeId = filterNoteSetTypeBy != "*" ? int.Parse(filterNoteSetTypeBy) : 0,
                ArchiveYear = ArchiveYear == 0 ? string.Empty : ArchiveYear.ToString(),
                offset = common.GetDatabaseOffset(pageNo <= 0 ? 1 : pageNo),
                Orderby = orderby
            };
            logger.LogWarning($"[WithdrawalTransactionPage:LoadData] going in GetAtmWithdrawalTransaction ");
            await service.GetAtmWithdrawalTransaction(withdrawalTransactionFilter, executor);
            logger.LogWarning($"[WithdrawalTransactionPage:LoadData] return from GetAtmWithdrawalTransaction ");
            //filteredWithdrawalTransaction = WithdrawalTransactions = response.data;
            //maxPageNo = common.GetMaxPageNo(response.totalRecords);
            //totalRecords = response.totalRecords;
            ////ResetFilter();
            //showSpinner = false;
            //showGrid = true;
            //IsDisabled = false;
            //await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void FilterSubmit()
        {
            pageNo = 1;
            //await Task.Run(LoadData);
            await LoadData();
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void ResetFilter()
        {
            ArchiveYear = (mode is not null && mode.Contains("Archive")) ? archiveYears.FirstOrDefault() : 0;
            fromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second) : fromDate;
            toDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second) : toDate;
            purgedFrom = purgedTo = amountFrom = amountTo = dispensed1 = dispensed2 = dispensed3 = dispensed4 = null;
            numberOfCycle = 2;
            //await LoadData();
            filterNoteSetTypeBy = "*";
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void AtmSelected()
        {
            showSpinner = true;
            //selectedTreeAtm = await atmRepository.GetSelectedAtmId();
            //filteredWithdrawalTransaction = WithdrawalTransactions;
            //filteredWithdrawalTransaction = filteredWithdrawalTransaction.Where(x => x.AtmId == selectedTreeAtm.First()).ToList();
            //await Task.Run(LoadData);
            await LoadData();
            //showSpinner = false;
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void RegionSelected()
        {
            //showSpinner = true;
            //selectedTreeRegion = await atmRepository.GetSelectedRegionId();
            //selectedTreeAtm = await atmRepository.GetSelectedAtmId();
            //filteredWithdrawalTransaction = WithdrawalTransactions;
            //filteredWithdrawalTransaction = filteredWithdrawalTransaction.Where(x => selectedTreeAtm.Contains(x.AtmId)).ToList();
            //showSpinner = false;
            await LoadData();
            //await Task.Run(LoadData);
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        public void Dispose()
        {
            objRef?.Dispose();
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

        protected override void OnParametersSet()
        {
            if (mode is not null && mode.Equals("Archive"))
            {
                archiveYears = common.GetLastNYears();
                ArchiveYear = archiveYears.FirstOrDefault();
                fromDate = new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second);
                toDate = new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second);
            }
            else
            {
                fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
                toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                ArchiveYear = 0;
            }

            purgedFrom = purgedTo = amountFrom = amountTo = dispensed1 = dispensed2 = dispensed3 = dispensed4 = null;
            numberOfCycle = 2;
            filterNoteSetTypeBy = "*";
            this.InvokeAsync(() => this.StateHasChanged());
        }

        private async Task GetDataByPageNo(int thisPageNo)
        {
            pageNo = thisPageNo;
            //await Task.Run(LoadData);
            await LoadData();
        }

        public List<WithdrawalTransactionViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<WithdrawalTransactionViewModel> atmWithdrawalTransactions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    WithdrawalTransactionViewModel atmWithdrawalTransaction = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                        Tittle = !DBNull.Value.Equals(row["TITLE"]) ? row["TITLE"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IsBillDispenser = !DBNull.Value.Equals(row["IsBillDispenser"]) ? (Convert.ToBoolean(row["IsBillDispenser"]) == true ? "yes" : "No") : string.Empty,
                        IP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        Group = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
                        DateTime = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                        ProcessingDateTime = !DBNull.Value.Equals(row["processing_datetime"]) ? Convert.ToDateTime(row["processing_datetime"]) : null,
                        Amount = !DBNull.Value.Equals(row["amount"]) ? row["amount"].ToString() : string.Empty,
                        Purged1 = !DBNull.Value.Equals(row["cash_purged1"]) ? Convert.ToInt32(row["cash_purged1"]) : 0,
                        Purged2 = !DBNull.Value.Equals(row["cash_purged2"]) ? Convert.ToInt32(row["cash_purged2"]) : 0,
                        Purged3 = !DBNull.Value.Equals(row["cash_purged3"]) ? Convert.ToInt32(row["cash_purged3"]) : 0,
                        Purged4 = !DBNull.Value.Equals(row["cash_purged4"]) ? Convert.ToInt32(row["cash_purged4"]) : 0,
                        Dispensed1 = !DBNull.Value.Equals(row["cash_dispensed1"]) ? Convert.ToInt32(row["cash_dispensed1"]) : 0,
                        Dispensed2 = !DBNull.Value.Equals(row["cash_dispensed2"]) ? Convert.ToInt32(row["cash_dispensed2"]) : 0,
                        Dispensed3 = !DBNull.Value.Equals(row["cash_dispensed3"]) ? Convert.ToInt32(row["cash_dispensed3"]) : 0,
                        Dispensed4 = !DBNull.Value.Equals(row["cash_dispensed4"]) ? Convert.ToInt32(row["cash_dispensed4"]) : 0,
                        Remaining1 = !DBNull.Value.Equals(row["cash_remaining1"]) ? Convert.ToInt32(row["cash_remaining1"]) : 0,
                        Remaining2 = !DBNull.Value.Equals(row["cash_remaining2"]) ? Convert.ToInt32(row["cash_remaining2"]) : 0,
                        Remaining3 = !DBNull.Value.Equals(row["cash_remaining3"]) ? Convert.ToInt32(row["cash_remaining3"]) : 0,
                        Remaining4 = !DBNull.Value.Equals(row["cash_remaining4"]) ? Convert.ToInt32(row["cash_remaining4"]) : 0,
                        PurgedNotes = !DBNull.Value.Equals(row["cash_purgedTotal"]) ? Convert.ToInt32(row["cash_purgedTotal"]) : 0,

                    };
                    atmWithdrawalTransactions.Add(atmWithdrawalTransaction);
                }
            }
            return atmWithdrawalTransactions;

        }
        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"WithdrawalTransactionPage: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            string error = string.Empty;

            if (args?._data?.Rows?.Count > 0)
            {
                WithdrawalTransactions = ConvertDataTableToList(args._data);

                filteredWithdrawalTransaction.AddRange(WithdrawalTransactions);
                totalRecords += filteredWithdrawalTransaction.FirstOrDefault().RowCount;
                maxPageNo = common.GetMaxPageNo(Convert.ToInt32(totalRecords));
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at WithdrawalTransactionPage, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);
            }
            else if (args._exception?.InnerException != null && !string.IsNullOrEmpty(args._exception?.InnerException.Message))
            {
                logger.LogError($"Exception at WithdrawalTransactionPage, PopulateModel as: {args._exception.InnerException.Message}");
                await common.RenderErrorBox(args._exception.InnerException.Message);
            }
            //else if (filteredBalanceInvestigation is null || filteredBalanceInvestigation.Count == 0)
            //{
            //    await NotificationService.Info("Check Filter, if records are not appearing", "Information", (options) =>
            //    {
            //        options.IntervalBeforeClose = 5000;
            //    });
            //}

            IsDisabled = false;
            if (!showGrid)
            {
                showGrid = true;
                showSpinner = false;
            }
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortedDirection = e.SortDirection;
            orderby = string.Empty;
            WithdrawalTransactionViewModel withdrawalTransaction = new();

            if (this.sortDirection != sortedDirection || !this.sortField.Equals(sortedColumn))
            {

                if (sortedColumn.Equals(nameof(withdrawalTransaction.Tittle)))
                    orderby += "TITLE";
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.IP)))
                {
                    orderby += "IP";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Location)))
                {
                    orderby += "location";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Group)))
                {
                    orderby += "note_set_type_name";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.DateTime)))
                {
                    orderby += "cassette1_deposit";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.ProcessingDateTime)))
                {
                    orderby += "processing_datetime";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Amount)))
                {
                    orderby += "amount";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Dispensed1)))
                {
                    orderby += "cash_dispensed1";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Dispensed2)))
                {
                    orderby += "cash_dispensed2";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Dispensed3)))
                {
                    orderby += "cash_dispensed3";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Dispensed4)))
                {
                    orderby += "cash_dispensed4";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Purged1)))
                {
                    orderby += "cash_purged1";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Purged2)))
                {
                    orderby += "cash_purged2";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Purged3)))
                {
                    orderby += "cash_purged3";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Purged4)))
                {
                    orderby += "cash_purged4";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.PurgedNotes)))
                {
                    orderby += "cash_purgedTotal";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Remaining1)))
                {
                    orderby += "cash_remaining1";
                }
                else if (sortedColumn.Equals(nameof(withdrawalTransaction.Remaining2)))
                {
                    orderby += "cash_remaining2";
                }else if (sortedColumn.Equals(nameof(withdrawalTransaction.Remaining3)))
                {
                    orderby += "cash_remaining3";
                }else if (sortedColumn.Equals(nameof(withdrawalTransaction.Remaining4)))
                {
                    orderby += "cash_remaining4";
                }else if (sortedColumn.Equals(nameof(withdrawalTransaction.IsBillDispenser)))
                {
                    orderby += "IsBillDispenser";
                }


                //For Atm Fields
                if (sortedDirection == SortDirection.Ascending && !string.IsNullOrEmpty(orderby))
                    orderby += " asc";

                else if (sortedDirection == SortDirection.Descending && !string.IsNullOrEmpty(orderby))
                    orderby += " desc";

                else if (sortedDirection == SortDirection.Default && !string.IsNullOrEmpty(orderby))
                    orderby = string.Empty;

                this.sortDirection = sortedDirection;
                this.sortField = sortedColumn;
                await LoadData();
            }
        }
    }
}