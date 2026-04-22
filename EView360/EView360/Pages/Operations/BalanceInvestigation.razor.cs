//using Azure;
using Blazorise;
using Blazorise.DataGrid;
using DataRequestor;
using EView360.Services;
using EView360Models.Core;
using global::Common.RequestModel;
using global::Common.ViewModel;
using global::Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.JSInterop;
using System.Data;

namespace EView360.Pages.Operations
{
    public partial class BalanceInvestigation
    {
        [Parameter]
        public string? mode { get; set; }

        int ArchiveYear;
        [Inject]
        INotificationService NotificationService { get; set; }

        [Inject]
        IMessageService MessageService { get; set; }
        [Inject]
        private IConfiguration _configuration { get; set; }
        [Inject]
        AtmService atmService { get; set; }

        private bool showSpinner = false;
        private List<int> archiveYears = new();
        private bool showGrid = false;
        private bool showTransactionsBetweenReplenishmentsRow = false;
        private bool showFromDateAndToDateRow = false;
        private Modal? postRepModalRef;
        static DateTime currentTime = DateTime.Now;
        DateTime fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
        DateTime toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
        DatePicker<DateTime> dateRef;
        public List<BalanceInvestigationViewModel> BalanceInvestigations = new List<BalanceInvestigationViewModel>();
        private DataGrid<BalanceInvestigationViewModel>? dataGridRef;
        private List<NoteSetTypeViewModel> noteSetType;
        private string? filterNoteSetTypeBy = "*";
        private string? atmIP = string.Empty;
        private EView360Models.ViewModels.ReplenishmentViewModel postRep = new();
        private EditContext? editContext;
        private ValidationMessageStore? messageStore;
        private DotNetObjectReference<BalanceInvestigation>? objRef;
        private List<long>? selectedTreeAtm;
        private List<BalanceInvestigationViewModel>? filteredBalanceInvestigation = new List<BalanceInvestigationViewModel>();
        Executor executor = new Executor();
        private SortDirection sortDirection = new();
        private string sortField = string.Empty;
        
        private bool IsDisabled = false;
        private bool ShowBillColumn = false;
        //paging
        private int pageNo { get; set; }
        private int maxPageNo { get; set; }
        private int totalRecords { get; set; }
        string? orderby = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            ShowBillColumn = _configuration.GetValue<bool>("ShowBillCoulumnsInBalanceInvestigation");
            executor.RaiseCustomEvent += PopulateModel;
            objRef = DotNetObjectReference.Create(this);
            fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
            await this.InvokeAsync(() => this.StateHasChanged());
            editContext = new(postRep);
            editContext.OnValidationRequested += CustomValidations;
            messageStore = new(editContext);
            notifyService.OnAtmChange += AtmSelected;
            notifyService.OnRegionChange += RegionSelected;
        }

        private void CustomValidations(object? sender, ValidationRequestedEventArgs args)
        {
            try
            {
                messageStore?.Clear();
                if (postRep.RepDatetime == null)
                {
                    messageStore?.Add(() => postRep.CashAdded1, "Replenishment date & time is required");
                }

                if (postRep.CashAdded1 == null)
                {
                    messageStore?.Add(() => postRep.CashAdded1, "Cash added in cassatte 1 is required");
                }

                if (postRep.CashAdded2 == null)
                {
                    messageStore?.Add(() => postRep.CashAdded1, "Cash added in cassatte 2 is required");
                }

                if (postRep.CashAdded3 == null)
                {
                    messageStore?.Add(() => postRep.CashAdded1, "Cash added in cassatte 3 is required");
                }

                if (postRep.CashAdded4 == null)
                {
                    messageStore?.Add(() => postRep.CashAdded1, "Cash added in cassatte 4 is required");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at BalanceIvestigation, CheckName as: {ex.Message}");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                EView360Models.Core.AppUser appUser = await localStorage.GetItemAsync<EView360Models.Core.AppUser>("AppUser");
                if (appUser is not null)
                {
                    noteSetTypeService.UserId = appUser.UserId;
                }

                if (firstRender)
                {
                    await jsRuntime.InvokeVoidAsync("handleDatePicker", objRef);
                    fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
                    toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                    ArchiveYear = (mode is not null && mode.Contains("Archive")) ? archiveYears.FirstOrDefault() : 0;
                    fromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, 0, 0, 0) : fromDate;
                    toDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Month, toDate.Day, 23, 59, 59) : toDate;
                    noteSetType = await groupService.GetNoteSetTypesByUser(appUser.UserId);
                    await this.InvokeAsync(() => this.StateHasChanged());
                }

                if (firstRender && (BalanceInvestigations is null || BalanceInvestigations.Count == 0))
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
                logger.LogError($"Exception at BalanceInvestigation , OnAfterRenderAsync as: {ex.Message}");
                await NotificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        private async Task LoadData()
        {
            var appUser = await localStorage.GetItemAsync<EView360Models.Core.AppUser>("AppUser");
            long UserId = appUser.UserId;   
            BalanceInvestigations = filteredBalanceInvestigation = new();
            showSpinner = true;
            showGrid = false;
            IsDisabled = true;
            totalRecords = 0;
            maxPageNo = common.GetMaxPageNo(totalRecords);
            await this.InvokeAsync(() => this.StateHasChanged());
            await common.TaskDelay();
            var balanceInvestigation = new BalanceInvestigationRequestModel
            {
                ShowBillColumn = ShowBillColumn,
                FromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second) : fromDate,
                ToDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second) : toDate,
                AtmIP = atmIP,
                NoteSetTypeIds = noteSetType.Where(x => x.isSelected).Select(x => x.NoteSetTypeId).ToList(),
                ArchiveYear = ArchiveYear,
                offset = common.GetDatabaseOffset(pageNo <= 0 ? 1 : pageNo),
                Orderby = orderby,
            };
            logger.LogWarning("[BalanceInvestigationPage:LoadData] going in GetBalanceInvestigation");
            balanceInvestigation.UserId = UserId;
            await service.GetBalanceInvestigation(balanceInvestigation, executor);
            logger.LogWarning("[BalanceInvestigationPage:LoadData] return from GetBalanceInvestigation");
            //filteredBalanceInvestigation = BalanceInvestigations = response.data;
            //maxPageNo = common.GetMaxPageNo(response.totalRecords);
            //totalRecords = response.totalRecords;
            ////await common.TaskDelay();
            //showSpinner = false;
            //showGrid = true;
            //IsDisabled = false;
            //await this.InvokeAsync(() => this.StateHasChanged());

            //Add sorting direction icons via sort
            await dataGridRef.Sort(sortField, sortDirection);
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

            filterNoteSetTypeBy = "*";
            BalanceInvestigations = filteredBalanceInvestigation = new();
        }

        private Task DateChanged(int selectedYear)
        {
            ArchiveYear = selectedYear;
            fromDate = new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second);
            toDate = new DateTime(ArchiveYear, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Second);
            this.InvokeAsync(() => this.StateHasChanged());
            return Task.CompletedTask;
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
            fromDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            toDate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
            ArchiveYear = (mode is not null && mode.Contains("Archive")) ? archiveYears.FirstOrDefault() : 0;
            fromDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, fromDate.Month, fromDate.Day, 0, 0, 0) : fromDate;
            toDate = (mode is not null && mode.Contains("Archive")) ? new DateTime(ArchiveYear, toDate.Month, toDate.Day, 23, 59, 59) : toDate;
            noteSetType.Select(x =>
            {
                x.isSelected = false;
                return x;
            }).ToList();
            filterNoteSetTypeBy = "*";
            //await LoadData();
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        private Task HideModal()
        {
            return postRepModalRef.Hide();
        }

        private async Task ShowModal(BalanceInvestigationViewModel balanceInvestigation)
        {
            var SelectedAtmIds = (List<string>)(await atmService.GetMultipleSelectedAtms()).Data;
            if (SelectedAtmIds != null && SelectedAtmIds.Count == 1)
            {
                postRep = await replanishmentService.GetAtmNoteSetType(Int32.Parse(SelectedAtmIds.FirstOrDefault()));
                postRep.RepDatetime = balanceInvestigation?.TxrnDateTime;
                postRepModalRef.Show();
            }
            else
            {
                await NotificationService.Error("Please select a single ATM from left tree", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
        }

        private async void Submit()
        {
            await HideModal();
            EView360Models.Core.AppUser appUser = await localStorage.GetItemAsync<EView360Models.Core.AppUser>("AppUser");
            if (appUser is not null)
            {
                postRep.GeneratedBy = appUser.UserId;
            }

            var selectAtmResponse = await atmService.GetSingleSelectedAtm();
            if (!selectAtmResponse.IsSuccess)
            {
                await NotificationService.Error($"{selectAtmResponse.Message}", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            else
            {
                postRep.TaskId = 0;
                postRep.AtmId = Convert.ToInt32(selectAtmResponse.Data);
                postRep.RepStatus = "Normal";
                postRep.GeneratedAt = DateTime.Now;
                postRep.GeneratedBy = appUser.UserId;
                postRep.RepAmount = (postRep.DenominationType1 * postRep.CashAdded1) + (postRep.DenominationType2 * postRep.CashAdded2) + (postRep.DenominationType3 * postRep.CashAdded3) + (postRep.DenominationType4 * postRep.CashAdded4);
                postRep.Reason = (postRep.Reason == null) ? string.Empty : postRep.Reason;
                EView360Models.ViewModels.BaseModel result = await replanishmentService.PostReplenishment(postRep);
                if (result.IsSuccess)
                {
                    //await Task.Run(LoadData);
                    await LoadData();
                }
            }
        }

        private void OnRowStyling(BalanceInvestigationViewModel balanceInvestigation, DataGridRowStyling styling)
        {
            string strOpeningBalance = balanceInvestigation.OperationBalance;
            string strWithdrawals = balanceInvestigation.Withdrawals;
            if (strOpeningBalance.Length > 0 && strWithdrawals.Length > 0)
            {
                decimal openingBalance = decimal.Parse(strOpeningBalance);
                decimal withdrawals = decimal.Parse(strWithdrawals);
                if (openingBalance < withdrawals)
                {
                    styling.Style = "background-color: yellow";
                }
                //else
                //e.Row.Cells[9].Text = "";
            }
        }

        private async void AtmSelected()
        {
            //selectedTreeAtm = await atmRepository.GetSelectedAtmId();
            //filteredBalanceInvestigation = BalanceInvestigations;
            //filteredBalanceInvestigation = filteredBalanceInvestigation.Where(x => x.AtmId == selectedTreeAtm.First()).ToList();
            await LoadData();
            //await Task.Run(LoadData);
            StateHasChanged();
        }

        private async void RegionSelected()
        {
            //selectedTreeAtm = await atmRepository.GetSelectedAtmId();
            //filteredBalanceInvestigation = BalanceInvestigations;
            //filteredBalanceInvestigation = filteredBalanceInvestigation.Where(x => selectedTreeAtm.Contains(x.AtmId)).ToList();
            await LoadData();
            //await Task.Run(LoadData);
            StateHasChanged();
        }

        private async Task GetDataByPageNo(int thisPageNo)
        {
            pageNo = thisPageNo;
            //await Task.Run(LoadData);
            await LoadData();
        }

        public void Dispose()
        {
            objRef?.Dispose();
            notifyService.OnAtmChange -= AtmSelected;
            notifyService.OnRegionChange -= RegionSelected;
        }

        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"BalanceInvestigationPage: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            string error = string.Empty;

            if (args?._data?.Rows?.Count > 0)
            {
                BalanceInvestigations = ConvertDataTableToList(args._data);

                filteredBalanceInvestigation.AddRange(BalanceInvestigations);
                totalRecords += filteredBalanceInvestigation.FirstOrDefault().RowCount;
                maxPageNo = common.GetMaxPageNo(Convert.ToInt32(totalRecords));
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at BalanceInvestigationPage, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);
            }
            else if (args._exception?.InnerException != null && !string.IsNullOrEmpty(args._exception?.InnerException.Message))
            {
                logger.LogError($"Exception at BalanceInvestigationPage, PopulateModel as: {args._exception.InnerException.Message}");
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

        public List<BalanceInvestigationViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<BalanceInvestigationViewModel> balanceInvestigations = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    BalanceInvestigationViewModel balanceInvestigation = new()
                    {
                        RowCount = !DBNull.Value.Equals(row["row_count"]) ? Convert.ToInt32(row["row_count"]) : 0,
                        OperationBalance = !DBNull.Value.Equals(row["opening_balance"]) ? Convert.ToDecimal(row["opening_balance"]).ToString("N2") : "0",
                        Replenishment = !DBNull.Value.Equals(row["replenishment_amount"]) ? Convert.ToDecimal(row["replenishment_amount"]).ToString("N2") : "0",
                        PreWithdrawals = !DBNull.Value.Equals(row["pre_withdrawals"]) ? Convert.ToDecimal(row["pre_withdrawals"]).ToString("N2") : "0",
                        Returns = !DBNull.Value.Equals(row["return_amount"]) ? Convert.ToDecimal(row["return_amount"]).ToString("N2") : "0",
                        Withdrawals = !DBNull.Value.Equals(row["withdrawals"]) ? Convert.ToDecimal(row["withdrawals"]).ToString("N2") : "0",
                        ClosingBalance = !DBNull.Value.Equals(row["closing_balance"]) ? Convert.ToDecimal(row["closing_balance"]).ToString("N2") : "0",
                        CashPositionBalance = !DBNull.Value.Equals(row["cash_pos_balance"]) ? Convert.ToDecimal(row["cash_pos_balance"]).ToString("N2") : "0",
                        SummaryId = !DBNull.Value.Equals(row["summary_id"]) ? Convert.ToInt32(row["summary_id"]) : 0,
                        ATM = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        AtmIp = !DBNull.Value.Equals(row["ip"]) ? row["ip"].ToString() : string.Empty,
                        AtmLocation = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        TxrnDateTime = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0,
                    };
                    balanceInvestigations.Add(balanceInvestigation);
                }
            }
            return balanceInvestigations;

        }

        private async void SortData(DataGridSortChangedEventArgs e)
        {
            string sortedColumn = e.FieldName;
            var sortedDirection = e.SortDirection;
            orderby = string.Empty;
            BalanceInvestigationViewModel balanceInvestigation = new();

            if (this.sortDirection != sortedDirection || !this.sortField.Equals(sortedColumn))
            {            
                if (sortedColumn.Equals(nameof(balanceInvestigation.ATM)))
                    orderby += "title";
                else if (sortedColumn.Equals(nameof(balanceInvestigation.AtmIp)))
                {
                    orderby += "Atm1.ip";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.AtmLocation)))
                {
                    orderby += "Atm1.location";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.TxrnDateTime)))
                {
                    orderby += "trxn_datetime";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.OperationBalance)))
                {
                    orderby += "opening_balance";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.Replenishment)))
                {
                    orderby += "replenishment_amount";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.PreWithdrawals)))
                {
                    orderby += "pre_withdrawals";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.Returns)))
                {
                    orderby += "return_amount";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.Withdrawals)))
                {
                    orderby += "withdrawals";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.CashPositionBalance)))
                {
                    orderby += "cash_pos_balance";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.ClosingBalance)))
                {
                    orderby += "closing_balance";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.BillClosingBalance)))
                {
                    orderby += "bill_closing_balance";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.BillOpeningBalance)))
                {
                    orderby += "bill_opening_balance";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.BillWthdrawals)))
                {
                    orderby += "bill_withdrawals";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.BillPreWthdrawals)))
                {
                    orderby += "bill_pre_withdrawals";
                }
                else if (sortedColumn.Equals(nameof(balanceInvestigation.BillPreWthdrawals)))
                {
                    orderby += "bill_return_amount";
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