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
using System.Data;
using global::Common.ViewModel;

namespace EView360.Pages.Operations
{
    public partial class BnaTransaction
    {
        [Parameter]
        public string? mode { get; set; }

        private List<long>? selectedTreeAtm;
        private long? selectedTreeRegion;
        private bool showSpinner = false;
        private bool showGrid = false;
        private bool showTransactionsBetweenReplenishmentsRow = false;
        private bool showFromDateAndToDateRow = false;
        private Modal? modalRef;
        string duration = string.Empty;
        DateTime? fromDate, toDate;
        DatePicker<DateTime?> dateRef;
        static DateTime currentTime = DateTime.Now;
        private List<int> archiveYears = new();
        public List<BnaTransactionViewModel> BnaTransactions = new();
        private DataGrid<BnaTransactionViewModel>? dataGridRef;
        private List<EView360Models.Core.NoteSetType>? noteSetType;
        private string? filterNoteSetTypeBy = "*";
        Executor executor = new Executor();
        [Inject]
        INotificationService NotificationService { get; set; }

        [Inject]
        IMessageService MessageService { get; set; }

        int ArchiveYear;
        private DotNetObjectReference<BnaTransaction>? objRef;
        private List<BnaTransactionViewModel>? filteredBnaTransaction;
        private bool IsDisabled = false;
        //paging
        private int pageNo { get; set; }
        private int maxPageNo { get; set; }
        private int totalRecords { get; set; }
        private SortDirection sortDirection = new();
        private string sortField = string.Empty;

        string? orderby = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            executor.RaiseCustomEvent += PopulateModel;
            objRef = DotNetObjectReference.Create(this);
            fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
            await this.InvokeAsync(() => this.StateHasChanged());
            AppUser appUser = await localStorage.GetItemAsync<AppUser>("AppUser");
            if (appUser is not null)
            {
                service.UserId = appUser.UserId;
                noteSetTypeService.UserId = appUser.UserId;
            }

            notifyService.OnAtmChange += AtmSelected;
            notifyService.OnRegionChange += RegionSelected;
            //service.userAtmList = treeService.GetAtmList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await jsRuntime.InvokeVoidAsync("handleDatePicker", objRef);
                }

                if (firstRender && (BnaTransactions is null || BnaTransactions.Count == 0))
                {
                    //await LoadData();
                }

                if (firstRender && (service.userAtmList is null || service.userAtmList.Count == 0))
                {
                    service.userAtmList = await treeService.GetAtmList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at BNATransaction, OnAfterRenderAsync as: {ex.Message}");
                await NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        protected override void OnParametersSet()
        {
            if (mode is not null && mode.Equals("Archive"))
            {
                archiveYears = common.GetLastNYears();
                ArchiveYear = archiveYears.FirstOrDefault();
                fromDate = new DateTime(ArchiveYear, fromDate.Value.Month, fromDate.Value.Day, fromDate.Value.Hour, fromDate.Value.Minute, fromDate.Value.Second);
                toDate = new DateTime(ArchiveYear, toDate.Value.Month, toDate.Value.Day, toDate.Value.Hour, toDate.Value.Minute, toDate.Value.Second);
            }
            else
            {
                fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
                toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                ArchiveYear = 0;
            }

            filterNoteSetTypeBy = "*";
            BnaTransactions = filteredBnaTransaction = new();
            this.InvokeAsync(() => this.StateHasChanged());
        }

        private async Task LoadData()
        {
            showGrid = false;
            showSpinner = true;
            IsDisabled = true;
            await this.InvokeAsync(() => this.StateHasChanged());
            await common.TaskDelay();
            totalRecords = 0;
            //var bNATransaction = new BNATransactionRequestModel
            //    {
            //        fromDate = mode is not null && mode.Contains("Archive") ? Convert.ToDateTime($"{fromDate.Value.ToString("dd/MM")}/{ArchiveYear}") : fromDate,
            //        toDate = mode is not null && mode.Contains("Archive") ? Convert.ToDateTime($"{toDate.Value.ToString("dd/MM")}/{ArchiveYear}") : toDate,
            //        ArchiveYear = ArchiveYear == 0 ? string.Empty : ArchiveYear.ToString()
            //    };
            var bNATransaction = new BNATransactionRequestModel
            {
                fromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Value.Month, fromDate.Value.Day, fromDate.Value.Hour, fromDate.Value.Minute, fromDate.Value.Second) : fromDate,
                toDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Value.Month, toDate.Value.Day, toDate.Value.Hour, toDate.Value.Minute, toDate.Value.Second) : toDate,
                ArchiveYear = ArchiveYear == 0 ? string.Empty : ArchiveYear.ToString(),
                offset = common.GetDatabaseOffset(pageNo <= 0 ? 1 : pageNo),
                Orderby = orderby,
            };
            
            logger.LogWarning("[BnaTransactionPage:LoadData] going in GetBNATransaction");
            await service.GetBNATransaction(bNATransaction, executor);
            logger.LogWarning("[BnaTransactionPage:LoadData] going in GetBNATransaction");
            //filteredBnaTransaction = BnaTransactions = response.data;
            //maxPageNo = common.GetMaxPageNo(response.totalRecords);
            //totalRecords = response.totalRecords;
            //showSpinner = false;
            //showGrid = true;
            //IsDisabled = false;
            //await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void FilterSubmit()
        {
            pageNo = 1;
            await LoadData();
            //await Task.Run(LoadData);
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void ResetFilter()
        {
            fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
            ArchiveYear = (mode is not null && mode.Contains("Archive")) ? archiveYears.FirstOrDefault() : 0;
            fromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Value.Month, fromDate.Value.Day, fromDate.Value.Hour, fromDate.Value.Minute, fromDate.Value.Second) : fromDate;
            toDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Value.Month, toDate.Value.Day, toDate.Value.Hour, toDate.Value.Minute, toDate.Value.Second) : toDate;
            //await LoadData();
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void AtmSelected()
        {
            //selectedTreeAtm = await atmRepository.GetSelectedAtmId();
            //filteredBnaTransaction = BnaTransactions;
            //filteredBnaTransaction = filteredBnaTransaction.Where(x => x.AtmId == selectedTreeAtm.First()).ToList();
            await LoadData();
            //await Task.Run(LoadData);
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private async void RegionSelected()
        {
            //selectedTreeRegion = await atmRepository.GetSelectedRegionId();
            //selectedTreeAtm = await atmRepository.GetSelectedAtmId();
            //filteredBnaTransaction = BnaTransactions;
            //filteredBnaTransaction = filteredBnaTransaction.Where(x => selectedTreeAtm.Contains(x.AtmId)).ToList();
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
            fromDate = new DateTime(ArchiveYear, fromDate.Value.Month, fromDate.Value.Day, fromDate.Value.Hour, fromDate.Value.Minute, fromDate.Value.Second);
            toDate = new DateTime(ArchiveYear, toDate.Value.Month, toDate.Value.Day, toDate.Value.Hour, toDate.Value.Minute, toDate.Value.Second);
            this.InvokeAsync(() => this.StateHasChanged());
            return Task.CompletedTask;
        }

        private async Task GetDataByPageNo(int thisPageNo)
        {
            pageNo = thisPageNo;
            //await Task.Run(LoadData);
            await LoadData();
        }

        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"BnaTransactionPage: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            string error = string.Empty;

            if (args?._data?.Rows?.Count > 0)
            {
                BnaTransactions = ConvertDataTableToList(args._data);

                filteredBnaTransaction.AddRange(BnaTransactions);
                totalRecords += filteredBnaTransaction.FirstOrDefault().RowCount;
                maxPageNo = common.GetMaxPageNo(Convert.ToInt32(totalRecords));
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at BnaTransactionPage, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);
            }
            else if (args._exception?.InnerException != null && !string.IsNullOrEmpty(args._exception?.InnerException.Message))
            {
                logger.LogError($"Exception at BnaTransactionPage, PopulateModel as: {args._exception.InnerException.Message}");
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

        public List<BnaTransactionViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<BnaTransactionViewModel> bnaTransactions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    BnaTransactionViewModel bnaTransaction = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        Cassette1 = !DBNull.Value.Equals(row["bna_cassette1"]) ? Convert.ToInt32(row["bna_cassette1"]) : 0,
                        Cassette2 = !DBNull.Value.Equals(row["bna_cassette2"]) ? Convert.ToInt32(row["bna_cassette2"]) : 0,
                        Cassette3 = !DBNull.Value.Equals(row["bna_cassette3"]) ? Convert.ToInt32(row["bna_cassette3"]) : 0,
                        Cassette4 = !DBNull.Value.Equals(row["bna_cassette4"]) ? Convert.ToInt32(row["bna_cassette4"]) : 0,
                        Cassette5 = !DBNull.Value.Equals(row["bna_cassette5"]) ? Convert.ToInt32(row["bna_cassette5"]) : 0,
                        LastBNADeposit = !DBNull.Value.Equals(row["last_bna_deposit_at"]) ? Convert.ToDateTime(row["last_bna_deposit_at"]) : null,
                        //Total = ExtractDepositAmount(row["cassette1_denomination_detail"].ToString(), row["cassette2_denomination_detail"].ToString(), row["cassette3_denomination_detail"].ToString(), row["cassette4_denomination_detail"].ToString()),
                        //Total = (Cassette1 + Cassette2 + Cassette3 + Cassette4 + Cassette5) ,
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0
                    };
                    bnaTransaction.Total = bnaTransaction.Cassette1 + bnaTransaction.Cassette2 + bnaTransaction.Cassette3 + bnaTransaction.Cassette4 + bnaTransaction.Cassette5;
                    bnaTransactions.Add(bnaTransaction);
                }
            }
            return bnaTransactions;

        }

        private async void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortedDirection = e.SortDirection;
            orderby = string.Empty;
            BnaTransactionViewModel bnaTransactionViewModel = new();

            if (this.sortDirection != sortedDirection || !this.sortField.Equals(sortedColumn))
            {
                
                if (sortedColumn.Equals(nameof(bnaTransactionViewModel.ATM)))
                    orderby += "title";
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.ATM)))
                {
                    orderby += "IP";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.Location)))
                {
                    orderby += "location";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.LastBNADeposit)))
                {
                    orderby += "last_bna_deposit_at";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.Cassette1)))
                {
                    orderby += "cassette1_deposit";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.Cassette2)))
                {
                    orderby += "cassette2_deposit";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.Cassette3)))
                {
                    orderby += "cassette3_deposit";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.Cassette4)))
                {
                    orderby += "cassette4_deposit";
                }
                else if (sortedColumn.Equals(nameof(bnaTransactionViewModel.Cassette5)))
                {
                    orderby += "purge_deposit";
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