using Blazorise;
using Common.RequestModel;
using Common.ViewModel;
using DataRequestorMiddleware.Services.Analytics;
using EView360.Common;
using EView360.Data;
using EView360Models.Cash;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;
using static Azure.Core.HttpHeader;

namespace EView360.Services.Analytics
{
    public class DenominationUtilizationAnalysisService
    {
        private static HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private AtmService _atmService { get; set; }
        private List<string>? AtmList { get; set; }
        private static string? BaseUrl { get; set; }
        private CommonServices common { get; set; }
        private DenominationUtilizationAnalysisServiceMW service { get; set; }
        private ATMTreeViewRepository treeService;

        private INotificationService _notificationService;

        public DenominationUtilizationAnalysisService(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ReplenishmentAnalysisService> logger, AtmService atmService, INotificationService notificationService, CommonServices common, DenominationUtilizationAnalysisServiceMW service, ATMTreeViewRepository treeService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.Analytics}DenominationUtilizationAnalysis/").ToString();
            _logger = logger;
            _atmService = atmService;
            _notificationService = notificationService;
            this.common = common;
            this.service = service;
            this.treeService = treeService;
        }

        public async Task<List<DenominationUtilizationAnalysisViewModel>?> GetDenominationUtilization(DenominationUtilizationAnalysisRequestModel filter)
        {
            List<DenominationUtilizationAnalysisViewModel> denominationUtilizations = new();
            try
            {
                //var selectAtmResponse = await _atmService.GetMultipleSelectedAtms();
                //if (!selectAtmResponse.IsSuccess)
                //{
                //    _logger.LogError($"Exception at GetDenominationUtilization as: {selectAtmResponse.Message}");
                //    await common.RenderErrorBox(selectAtmResponse.Message);
                //}
                //else
                //{
                //    List<string> selectedAtmIds = (List<string>)selectAtmResponse.Data;
                //    if (selectedAtmIds?.Count > 0)
                //    {
                //filter.SelectedAtmIds = selectedAtmIds;

                //var jsonContent = JsonConvert.SerializeObject(filter);
                //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetDenominationUtilizationAnalysis", content);
                //string responseBody = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                //{
                (filter.SelectedAtmIds, filter.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();

                _logger.LogWarning("[DenominationUtilizationAnalysisService:GetDenominationUtilization] going in GetDenominationUtilizationAnalysis middleware service");
                var responseModel = service.GetDenominationUtilizationAnalysis(filter);
                _logger.LogWarning("[DenominationUtilizationAnalysisService:GetDenominationUtilization] returning from GetDenominationUtilizationAnalysis middleware service");
                
                if (responseModel.IsSuccess)
                {
                    denominationUtilizations = (List<DenominationUtilizationAnalysisViewModel>)responseModel.Data;
                }
                else
                {
                    if (responseModel.Data != null)
                    {
                        denominationUtilizations = (List<DenominationUtilizationAnalysisViewModel>)responseModel.Data;
                    }

                    _logger.LogError($"API error at DenominationUtilizationAnalysis, GetDenominationUtilization: {responseModel.Message}");
                    await common.RenderErrorBox(responseModel.Message);
                    return denominationUtilizations;
                }

                if (responseModel.IsSuccess && (denominationUtilizations is null || denominationUtilizations.Count == 0))
                {
                    await common.RenderSuccessBox("No record found");
                }
                //}
                //else
                //{
                //    _logger.LogError($"API error at DenominationUtilizationAnalysis, GetDenominationUtilization: {responseBody}");
                //    await common.RenderErrorBox(responseBody);
                //}
                //    }

                //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetDenominationUtilization as: {ex.Message}");
            }
            return denominationUtilizations;
        }

        public async Task<List<List<double>>> GetLineChartData(List<DenominationUtilizationAnalysisViewModel> denominationUtilizations)
        {
            List<List<double>> denominationUtilizationLineChartList = new();
            try
            {
                int notesDispensed1 = 0;
                int notesDispensed2 = 0;
                int notesDispensed3 = 0;
                int notesDispensed4 = 0;
                int totalNotesDispensed = 0;
                double notesDispensed1Perc = 0.0;
                double notesDispensed2Perc = 0.0;
                double notesDispensed3Perc = 0.0;
                double notesDispensed4Perc = 0.0;
                List<double> listNotes1DispensedPerc = new List<double>();
                List<double> listNotes2DispensedPerc = new List<double>();
                List<double> listNotes3DispensedPerc = new List<double>();
                List<double> listNotes4DispensedPerc = new List<double>();

                foreach (var denominationUtilization in denominationUtilizations)
                {
                    notesDispensed1 = denominationUtilization.NotesDispensed1;
                    notesDispensed2 = denominationUtilization.NotesDispensed2;
                    notesDispensed3 = denominationUtilization.NotesDispensed3;
                    notesDispensed4 = denominationUtilization.NotesDispensed4;

                    totalNotesDispensed = notesDispensed1 + notesDispensed2 + notesDispensed3 + notesDispensed4;

                    if (totalNotesDispensed != 0)
                        notesDispensed1Perc = Math.Round((double)((((double)notesDispensed1) / ((double)totalNotesDispensed)) * 100.0));
                    else
                        notesDispensed1Perc = -1.0;

                    if (totalNotesDispensed != 0)
                        notesDispensed2Perc = Math.Round((double)((((double)notesDispensed2) / ((double)totalNotesDispensed)) * 100.0));
                    else
                        notesDispensed2Perc = -1.0;

                    if (totalNotesDispensed != 0)
                        notesDispensed3Perc = Math.Round((double)((((double)notesDispensed3) / ((double)totalNotesDispensed)) * 100.0));
                    else
                        notesDispensed3Perc = -1.0;

                    if (totalNotesDispensed != 0)
                        notesDispensed4Perc = Math.Round((double)((((double)notesDispensed4) / ((double)totalNotesDispensed)) * 100.0));
                    else
                        notesDispensed4Perc = -1.0;

                    if (notesDispensed1Perc > -1.0)
                        listNotes1DispensedPerc.Add(notesDispensed1Perc);

                    if (notesDispensed2Perc > -1.0)
                        listNotes2DispensedPerc.Add(notesDispensed2Perc);

                    if (notesDispensed3Perc > -1.0)
                        listNotes3DispensedPerc.Add(notesDispensed3Perc);

                    if (notesDispensed4Perc > -1.0)
                        listNotes4DispensedPerc.Add(notesDispensed4Perc);
                }

                denominationUtilizationLineChartList.Add(listNotes1DispensedPerc);
                denominationUtilizationLineChartList.Add(listNotes2DispensedPerc);
                denominationUtilizationLineChartList.Add(listNotes3DispensedPerc);
                denominationUtilizationLineChartList.Add(listNotes4DispensedPerc);
            }
            catch (Exception ex)
            {
                _logger.LogError($"API error at DenominationUtilizationAnalysis, GetLineChartList: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
            return denominationUtilizationLineChartList;
        }

        public async Task<List<float>> GetPieAndBarChartData(List<List<double>> LineChartList)
        {
            List<float> piePiece = new();
            int l = 0;
            double var = 0.0;

            for (int i = 0; i < LineChartList.Count; i++)
            {
                var = 0.0;
                l = 0;
                while (l < LineChartList[i].Count)
                {
                    var += LineChartList[i][l];
                    l++;
                }
                if (l != 0)
                {
                    piePiece.Add((float)Math.Round((double)(var / ((double)l))));
                }
            }
            return piePiece;
        }

        //public async Task<List<NotesetTypeAnalyticsViewModel>> GetNotesetTypesByAtmIds(List<long> selectedAtmIds)
        //{
        //    List<NotesetTypeAnalyticsViewModel> notesetTypes = new();
        //    try
        //    {
        //        if (selectedAtmIds?.Count > 0)
        //        {
        //            //var jsonContent = JsonConvert.SerializeObject(selectedAtmIds);
        //            //HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //            //HttpResponseMessage response = await client.PostAsync($"{BaseUrl}GetNotesetTypesByAtmIds", content);
        //            //string responseBody = await response.Content.ReadAsStringAsync();
        //            //if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
        //            //{

        //            var responseModel = service.GetNotesetTypesByAtmIds(selectedAtmIds); //JsonConvert.DeserializeObject<BaseModel>(responseBody);
        //            if (responseModel.IsSuccess)
        //            {
        //                notesetTypes = (List<NotesetTypeAnalyticsViewModel>)responseModel.Data;
        //            }
        //            else
        //            {
        //                if (responseModel.Data != null)
        //                {
        //                    notesetTypes = (List<NotesetTypeAnalyticsViewModel>)responseModel.Data;

        //                }

        //                _logger.LogError($"API error at DenominationUtilizationAnalysisService, GetNotesetTypesByAtmIds: {responseModel.Message}");
        //                await common.RenderErrorBox(responseModel.Message);

        //                return notesetTypes;
        //            }

        //            if (responseModel.IsSuccess && (notesetTypes is null || notesetTypes.Count == 0))
        //            {
        //                await common.RenderSuccessBox("No record found");
        //            }
        //            //}
        //            //else
        //            //{
        //            //    _logger.LogError($"API error at DenominationUtilizationAnalysisService, GetNotesetTypesByAtmIds: {responseBody}");
        //            //    await common.RenderErrorBox(responseBody);
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exception at GetNotesetTypesByAtmIds as: {ex.Message}");
        //        await common.RenderErrorBox(ex.Message);

        //    }
        //    return notesetTypes;
        //}

        public async Task<List<NotesetTypeAnalyticsViewModel>?> GetNoteSetTypesByUser(long userId)
        {
            List<NotesetTypeAnalyticsViewModel>? responseList = new();
            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{_apiUrl.BaseUrl}{_apiUrl.NoteSetType}NoteSetType/GetNoteSetTypeByUserId/{userId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseBody))
                {
                    responseList = JsonConvert.DeserializeObject<List<NotesetTypeAnalyticsViewModel>>(responseBody);
                }
                else
                {
                    _logger.LogError($"API error at DenominationUtilizationAnalysisService, GetNoteSetTypesByUser: {responseBody}");
                    await common.RenderErrorBox(responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetNoteSetTypesByUser as: {ex.Message}");
                await common.RenderErrorBox(ex.Message);
            }
            return responseList;
        }
    }
}
