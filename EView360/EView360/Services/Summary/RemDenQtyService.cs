using Blazorise;
using DataRequestorMiddleware.Services.Summary;
using EView360.Data;
using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace EView360.Services.Summary
{
    public class RemDenQtyService
    {
        public long UserId { get; set; }
        public int totalAtms { get; set; }
        private ILogger _logger { get; set; }
        private ATMTreeViewRepository _atmTreeService { get; set; }
        private List<Atm>? AtmList { get; set; }
        private INotificationService _notificationService;
        private NoteSetTypeService _noteSetTypeService { get; set; }
        private AtmRemDenQtyService _service { get; set; }
        public RemDenQtyService(ILogger<ATMTreeViewRepository> logger, ATMTreeViewRepository atmTreeService,  INotificationService notificationService, NoteSetTypeService noteSetTypeService, AtmRemDenQtyService service)
        {
            _logger = logger;
            _atmTreeService = atmTreeService;
            _notificationService = notificationService;
            _noteSetTypeService = noteSetTypeService;
            _service = service;
        }

        public async Task<List<NoteSetTypeViewModel>?> GetNoteSetTypeAsync()
        {
            List<NoteSetTypeViewModel>? noteSets = new();
            try
            {
                await GetAtmList();
                _noteSetTypeService.UserId = UserId;
                List<NoteSetType> noteSetTypes = await _noteSetTypeService.GetNoteSetTypeListAsync();
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

        public async Task GetAtmList()
        {
            AtmList = await _atmTreeService.GetAtmList();
        }

        public async Task<(bool isSucess, List<string>? cassette_Sum)> GetRemainingNotes(long? noteSetTypeId = null)
        {
            List<string>? cassette_Sum = new();
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

                if (noteSetTypeId is not null)
                {
                    filter += " and outerATM.note_set_type_id = " + noteSetTypeId + " ";
                }

                totalAtms = selectedAtmIds.Count;

                if (selectedAtmIds?.Count > 0)
                {

                    _logger.LogWarning($"RemDenQtyService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _service.GetRemainingNotes  : {DateTime.Now.ToString()}");
                    cassette_Sum = _service.GetRemainingNotes(selectedAtmIds.ConvertAll(x => x.ToString()), filter, ref errorMsg);
                    _logger.LogWarning($"RemDenQtyService: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _service.GetRemainingNotes  : {DateTime.Now.ToString()}");

                    
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        await _notificationService.Error(errorMsg, "Error", (options) =>
                        {
                            options.IntervalBeforeClose = 4000;
                        });
                        _logger.LogError($"Error at Summary, GetRemainingNotes: {errorMsg}");
                    }
                    return (isSucess: true, cassette_Sum);
                }
            }
            catch (Exception ex)
            {
                await _notificationService.Error(ex.Message, "Error", (options) =>
                {
                    options.IntervalBeforeClose = 4000;
                });

                _logger.LogError($"Exception at GetBnaTransactingATMTitle as: {ex.Message}");
            }
            return (isSucess: false, cassette_Sum);
        }
    }
}
