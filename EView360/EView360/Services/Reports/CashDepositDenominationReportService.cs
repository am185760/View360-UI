using Blazorise;
using Common.RequestModel;
using DataRequestorMiddleware.Services.Reports;
using System.Data;

namespace EView360.Services.Reports
{
    public class CashDepositDenominationReportService
    {
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private CashDepositDenominationDetailServiceMw service { get; set; }

        private INotificationService _notificationService;

        private ATMTreeViewRepository treeService;
        public CashDepositDenominationReportService(ILogger<CashDepositDenominationReportService> logger, INotificationService notificationService, ATMTreeViewRepository treeService, CashDepositDenominationDetailServiceMw service)
        {
            _logger = logger;
            _notificationService = notificationService;
            this.treeService = treeService;
            this.service = service;
        }

        public async Task<DataTable> GetCashDepositDenominationReport(CashDepositDenominationRequestModel requestModel)
        {
            DataTable dt = new DataTable();
            try
            {
                (requestModel.SelectedAtms, requestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
                if (requestModel?.SelectedAtms?.Count > 0)
                {
                    _logger.LogWarning($"CashUtilizationReportService:GetCashDepositDenominationReport] going in GetCashDepositDenominationDetailReport middleware service");

                    var responseModel = await service.GetCashDepositDenominationDetailReport(requestModel);
                    _logger.LogWarning($"CashUtilizationReportService:GetCashDepositDenominationReport] return from GetCashDepositDenominationDetailReport middleware service");

                    if (responseModel.IsSuccess)
                    {
                        dt = (DataTable)responseModel.Data;
                    }
                    else
                    {
                        if (responseModel.Data != null)
                        {
                            dt = (DataTable)responseModel.Data;
                        }
                        await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
                        {
                            _logger.LogError($"Exception at GetCashDepositDenominationReport as: {responseModel.Message}");
                        }
                        return dt;
                    }


                    if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
                    {
                        await _notificationService.Success("No record found", "Succes", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                    }
                }
                else
                {
                    await _notificationService.Error($"Please select atm.", "Error", (options) =>
                    {
                        options.IntervalBeforeClose = 4000;
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CashDepositDenominationReportService as: {ex.Message}");
                await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });
            }
            return dt;
        }

        //public async Task<DataTable> GetCashDepositNotesUtilizationDetail(CashDepositDenominationRequestModel requestModel)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        (requestModel.SelectedAtms, requestModel.SelectedRegionIds) = await treeService.GetSelectedAtmOrRegionList();
        //        if (requestModel?.SelectedAtms?.Count > 0)
        //        {
        //            _logger.LogWarning($"CashUtilizationReportService:GetCashDepositNotesUtilizationDetail] going in GetCashDepositNotesUtilizationDetail middleware service");

        //            var responseModel = await service.GetCashDepositNotesDepositUtilization(requestModel);
        //            _logger.LogWarning($"CashUtilizationReportService:GetCashDepositNotesUtilizationDetail] return from GetCashDepositNotesUtilizationDetail middleware service");

        //            if (responseModel.IsSuccess)
        //            {
        //                dt = (DataTable)responseModel.Data;
        //            }
        //            else
        //            {
        //                if (responseModel.Data != null)
        //                {
        //                    dt = (DataTable)responseModel.Data;
        //                }
        //                await _notificationService.Error($"{responseModel.Message}", "Error", (options) =>
        //                {
        //                    options.IntervalBeforeClose = 4000;
        //                });
        //                if (!responseModel.IsSuccess && !string.IsNullOrEmpty(responseModel.Message))
        //                {
        //                    _logger.LogError($"Exception at GetCashDepositNotesUtilizationDetail as: {responseModel.Message}");
        //                }
        //                return dt;
        //            }


        //            if (responseModel.IsSuccess && (dt is null || dt.Rows.Count == 0))
        //            {
        //                await _notificationService.Success("No record found", "Succes", (options) =>
        //                {
        //                    options.IntervalBeforeClose = 4000;
        //                });
        //            }
        //        }
        //        else
        //        {
        //            await _notificationService.Error($"Please select atm.", "Error", (options) =>
        //            {
        //                options.IntervalBeforeClose = 4000;
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exception at GetCashDepositNotesUtilizationDetail as: {ex.Message}");
        //        await _notificationService.Error($"Some went wrong please check log.", "Error", (options) =>
        //        {
        //            options.IntervalBeforeClose = 4000;
        //        });
        //    }
        //    return dt;
        //}


    }
}
