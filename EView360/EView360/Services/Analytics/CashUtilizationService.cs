using Blazorise;
using Common.RequestModel;
using DataRequestorMiddleware.Services.Analytics;
using DataRequestorMiddleware.Services.Reports;
using EView360.Data;
using EView360.Pages.Operations;
using EView360.Services.Reports;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Data;
using System.Dynamic;
using System.Text;
using static EView360.Data.Enumerations;

namespace EView360.Services.Analytics
{
    public class CashUtilizationService
    {
        public long UserId { get; set; }
        public int totalAtms { get; set; }
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private CashUtilizationAnalysisService _graphService { get; set; }

        public CashUtilizationService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, CashUtilizationAnalysisService graphService)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _graphService = graphService;
        }


        public async Task<CashUtilRespWrapper> GetTodayCashUtilization(DateTime fromDate, DateTime toDate)
        {
            CashUtilRespWrapper responseWrapper = new();
            List<CashUtilizationViewModel>? cashUtilizations = new();
            string errorMsg = string.Empty;
            try
            {
                string filter = string.Empty;
                List<string> atmIDs = new();
                List<string> regionIDs = new();

                List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
                (atmIDs, regionIDs) = await _atmTreeService.GetSelectedAtmOrRegionList();

                filter = " and ua.user_id = " + UserId;

                if (regionIDs?.Count > 0)
                {
                    filter += " and outerATM.region_id in " + "(" + string.Join(",", regionIDs) + ")";
                }
                else
                {
                    filter += " and outerATM.atm_id in " + "(" + string.Join(",", atmIDs) + ")";
                }

                if (selectedAtmIds?.Count > 0)
                {
                    _logger.LogWarning($"CashUtilizationService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _graphService.GetAtmUtilizationDetail  : {DateTime.Now.ToString()}");
                    cashUtilizations = _graphService.GetAtmUtilizationDetail(fromDate, toDate, atmIDs, filter, ref errorMsg);
                    _logger.LogWarning($"CashUtilizationService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _graphService.GetAtmUtilizationDetail  : {DateTime.Now.ToString()}");

                    
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        _logger.LogError($"Error at Analyt. CashUtilize, GetAtmUtilizationDetail: {errorMsg}");
                        responseWrapper.Error = errorMsg;
                    }
                    responseWrapper.IsSucess = (string.IsNullOrEmpty(errorMsg) || cashUtilizations?.Count > 0) ? true : false;
                    responseWrapper.cashUtilizationViews = cashUtilizations;
                    return responseWrapper;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCashUtilization as: {ex.Message}");
            }

            responseWrapper.IsSucess = false;
            responseWrapper.cashUtilizationViews = cashUtilizations;
            return responseWrapper;
        }

        public async Task<CashUtilRespWrapper> GetCashUtilization(DateTime fromDate, DateTime toDate)
        {
            CashUtilRespWrapper responseWrapper = new();
            List<CashUtilizationViewModel>? cashUtilizations = new();
            string errorMsg = string.Empty;
            try
            {
                List<string> atmIDs = new();
                List<string> regionIDs = new();
                (atmIDs, regionIDs) = await _atmTreeService.GetSelectedAtmOrRegionList();

                if (atmIDs?.Count > 0)
                {
                    CashUtilizationReportRequestModel requestModel = new()
                    {
                        FromDate = fromDate,
                        ToDate = toDate,
                        SelectedAtms = atmIDs,
                        ArchiveYear = string.Empty,
                        NoteSetTypeIds = new List<long>(),
                        SelectedRegionIds = regionIDs
                    };
                    DataTable dt = new DataTable("utilizations");

                    _logger.LogWarning($"CashUtilizationService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _graphService.GetCashUtilzation  : {DateTime.Now.ToString()}");
                    cashUtilizations = _graphService.GetCashUtilization(requestModel, ref errorMsg);
                    _logger.LogWarning($"CashUtilizationService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _graphService.GetCashUtilzation  : {DateTime.Now.ToString()}");

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        _logger.LogError($"Error at Analytics CashUtilize, GetAtmUtilizationDetail: {errorMsg}");
                        responseWrapper.Error = errorMsg;
                    }
                    responseWrapper.IsSucess = (string.IsNullOrEmpty(errorMsg) || cashUtilizations?.Count > 0) ? true : false;
                    responseWrapper.cashUtilizationViews = cashUtilizations;
                    return responseWrapper;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCashUtilization as: {ex.Message}");
            }
            responseWrapper.cashUtilizationViews = cashUtilizations;
            responseWrapper.IsSucess = false;
            return responseWrapper;
        }
    }
}
