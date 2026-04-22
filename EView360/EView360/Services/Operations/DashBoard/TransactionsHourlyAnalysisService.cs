using Blazorise;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Data;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Text;
using static EView360.Data.Enumerations;

namespace EView360.Services.Operations.DashBoard
{
    public class TransactionsHourlyAnalysisService
    {
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private List<Atm>? AtmList { get; set; }
        private TransHourlyAnalysisService _transHourlyAnalysis { get; set; }
        public TransactionsHourlyAnalysisService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService, TransHourlyAnalysisService transHourlyAnalysis)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _transHourlyAnalysis= transHourlyAnalysis;
        }


        public async void GetTransHourlyResponse(Executor _executor, string filter)
        {
            List<ViewTransHourlyViewModel>? transHourlyViewModels = new();
            string errorMsg = string.Empty;
            try
            {
                List<long>? selectedAtmIds = await _atmTreeService.GetSelectedAtmId();
                if (selectedAtmIds?.Count > 0)
                {
                    _logger.LogWarning($"TransactionsHourlyAnalysisService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in GetTransHourlyResponse  : {DateTime.Now.ToString()}");
                    _transHourlyAnalysis.GetTransHourlyResponse(_executor, selectedAtmIds.ConvertAll(x => x.ToString()), filter, ref errorMsg);                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetTransHourlyResponse as: {ex.Message}");
            }
        }
    }
}
