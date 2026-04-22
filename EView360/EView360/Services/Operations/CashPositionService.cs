using Blazorise;
using DataRequestor;
using DataRequestorMiddleware.Services.Operations;
using EView360.Common;
using EView360.Data;
using EView360.Pages.Operations;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;
using static EView360.Common.Constants;

namespace EView360.Services.Operations
{
    public class CashPositionService
    {
        public long UserId { get; set; }
        private ILogger _logger { get; set; }
        private CommonServices _commonServices { get; set; }
        private NoteSetTypeService _noteSetTypeService;
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private CashPositionsService _cashService { get; set; }
        private readonly IConfiguration _configuration;
        public CashPositionService(ILogger<ATMTreeViewRepository> logger, NoteSetTypeService noteSetTypeService, ATMTreeViewRepository atmTreeService, CommonServices commonServices, IConfiguration configuration, CashPositionsService cashPositions)
        {
            _logger = logger;
            _noteSetTypeService = noteSetTypeService;
            _atmTreeService = atmTreeService;
            _commonServices = commonServices;
            _configuration = configuration;
            _cashService = cashPositions;
        }

        public async Task<List<NoteSetTypeViewModel>?> GetNoteSetTypeAsync()
        {
            List<NoteSetTypeViewModel>? noteSets = new();
            try
            {
                _noteSetTypeService.UserId = UserId;
                List<NoteSetType>? noteSetTypes = await _noteSetTypeService?.GetNoteSetTypeListAsync();                
                if (noteSetTypes?.Count > 0)
                {
                    string json = JsonConvert.SerializeObject(noteSetTypes);
                    noteSets = JsonConvert.DeserializeObject<List<NoteSetTypeViewModel>>(json);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetNoteSetTypeAsync as: {ex.Message}");
            }
            return noteSets;
        }

        public async void GetCashPositionAsync(Executor _executor, int pageNo, CashPositionFilter cashPositionFilter)
        {
            List<CashPositionViewModel>? cashPositions = new();
            int totalRecord = 0;
            string errorMsg = string.Empty;
            try
            {
                cashPositionFilter.offset = _commonServices.GetDatabaseOffset(pageNo);
                cashPositionFilter.rowCount = _configuration.GetValue<int>("RecordPerPage");
                List<long>? selectedAtmIds = await _atmTreeService?.GetSelectedAtmId();
                if (selectedAtmIds?.Count > 0)
                {
                    cashPositionFilter.AtmIds = selectedAtmIds.ConvertAll(x => x.ToString());
                    _logger.LogWarning($"CashPositionService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _cashService.GetCashPositions  : {DateTime.Now.ToString()}");
                    _cashService.GetCashPositions(_executor, cashPositionFilter);
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetCashPositionAsync as: {ex.Message}");
            }
        }        
    }
}
