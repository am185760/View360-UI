using global::Microsoft.AspNetCore.Components;
using Blazorise;
using Blazorise.DataGrid;
using EView360Models.Core;
using EView360Models.ViewModels;
using DataRequestor;
using System.Data;
using System.Collections.Concurrent;

namespace EView360.Pages.Operations.Dashboards
{
    public partial class TransactionsHourlyAnalysis
    {
        private bool showSpinner = false;
        private bool showGrid = false;
        private int? threshold;
        public List<ViewTransHourlyViewModel>? transHourlyViewModels = new();
        public List<ViewTransHourlyViewModel>? filtertransHourlyViewModels = new();
        private DataGrid<ViewTransHourlyViewModel>? dataGridRef;
        [Inject]
        INotificationService NotificationService { get; set; }

        private bool IsDisabled = false;

        private Executor executor = new Executor();
        private List<Atm>? AtmList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            AppUser appUser = await localStorage.GetItemAsync<AppUser>("AppUser");
            executor.RaiseCustomEvent += PopulateModel;


            if (appUser is not null)
            {
                service.UserId = appUser.UserId;
            }
            notifyService.OnAtmChange += AtmSelected;
            notifyService.OnRegionChange += RegionSelected;

            AtmList = await atmRepository.GetAtmList();
        }

        public async void PopulateModel(object sender, DataRequestor.CustomEventArgs args)
        {
            logger.LogWarning($"TransactionsHourlyAnalysis: PopulateModel ---  Data Count = {args?._data?.Rows?.Count}  -- {DateTime.Now.ToString()}");
            string error = string.Empty;
            if (args?._data?.Rows?.Count > 0)
            {
                List<TransHourlyResponseViewModel> transHourlyResponses = new();
                foreach (DataRow row in args._data.Rows)
                {
                    TransHourlyResponseViewModel transHourlyResponse = new()
                    {
                        AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                        TrnxDateTime = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                        LastHeartBeatAt = !DBNull.Value.Equals(row["last_heart_beat_at"]) ? Convert.ToDateTime(row["last_heart_beat_at"]) : null,
                        Amount = !DBNull.Value.Equals(row["amount"]) ? Convert.ToDecimal(row["amount"]) : null,
                    };
                    transHourlyResponses.Add(transHourlyResponse);
                }
                if (transHourlyResponses?.Count > 0)
                {
                    ConcurrentBag<ViewTransHourlyViewModel> viewBag = new();
                    Parallel.ForEach(transHourlyResponses, transHourlyResponse =>
                    {
                        if (transHourlyResponse.TrnxDateTime.Value.AddHours(threshold.Value) < DateTime.Now)
                        {
                            ViewTransHourlyViewModel view = new()
                            {
                                AtmId = transHourlyResponse.AtmId,
                                Amount = transHourlyResponse.Amount,
                                GenerationTime = transHourlyResponse.TrnxDateTime,
                                LastHeartBeatAt = transHourlyResponse.LastHeartBeatAt,
                                Title = AtmList.FirstOrDefault(x => x.AtmId == transHourlyResponse.AtmId)?.Title,
                                IsHealthy = AtmList.FirstOrDefault(x => x.AtmId == transHourlyResponse.AtmId)?.IsHealthy,
                                Ip = AtmList.FirstOrDefault(x => x.AtmId == transHourlyResponse.AtmId)?.Ip,
                                Location = AtmList.FirstOrDefault(x => x.AtmId == transHourlyResponse.AtmId)?.Location
                            };
                            viewBag.Add(view);
                        }
                    });
                    if (viewBag?.Count > 0)
                        transHourlyViewModels = viewBag.ToList();
                }
                filtertransHourlyViewModels = transHourlyViewModels;
            }

            if (args._exception != null && !string.IsNullOrEmpty(args._exception.Message))
            {
                logger.LogError($"Exception at TransactionsHourlyAnalysis, PopulateModel as: {args._exception.Message}");
                await common.RenderErrorBox(args._exception.Message);

                if (args._exception.InnerException != null && !string.IsNullOrEmpty(args._exception.InnerException.Message))
                {
                    logger.LogError($"Exception at TransactionsHourlyAnalysis, PopulateModel as: {args._exception.InnerException.Message}");
                    await common.RenderErrorBox(args._exception.InnerException.Message);
                }
            }
            else if (transHourlyViewModels is null || transHourlyViewModels.Count == 0)
            {
                await NotificationService.Info("Check Filter, if records are not appearing", "Information", (options) =>
                {
                    options.IntervalBeforeClose = 5000;
                });
            }

            IsDisabled = false;
            if (!showGrid)
            {
                showGrid = true;
                showSpinner = false;                
            }
            await this.InvokeAsync(() => this.StateHasChanged());
        }

        public void Dispose()
        {
            notifyService.OnAtmChange -= AtmSelected;
            notifyService.OnRegionChange -= RegionSelected;
        }

        private async void AtmSelected()
        {
            await LoadData();
        }

        private async void RegionSelected()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            transHourlyViewModels = filtertransHourlyViewModels = new List<ViewTransHourlyViewModel>();
            string filter = string.Empty;
            List<string> atmIDs = new();
            List<string> regionIDs = new();
            showSpinner = true;
            showGrid = false;
            IsDisabled = true;
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

            if (threshold.HasValue && atmRepository.SelectedAtmIds?.Count > 0)
            {
                service.GetTransHourlyResponse(executor, filter);
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
            threshold = null;
            transHourlyViewModels = filtertransHourlyViewModels = new();
            await this.InvokeAsync(() => this.StateHasChanged());
        }
    }
}