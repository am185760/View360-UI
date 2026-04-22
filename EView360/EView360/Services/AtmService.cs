using EView360.Common;
using EView360Models.Core;
using EView360Models.ViewModels;

namespace EView360.Services
{
    public class AtmService
    {
        private readonly ATMTreeViewRepository treeService;

        public AtmService(ATMTreeViewRepository treeService)
        {
            this.treeService = treeService;
        }

        public async Task<BaseModel> GetSingleSelectedAtm()
        {
            List<long>? selectedAtmIds = await treeService.GetSelectedAtmId();
            if (selectedAtmIds is null || !selectedAtmIds.Any())
            {
                return new BaseModel { Message = Constants.Messages.AtmSelectionMsg };
            }
            else if (selectedAtmIds.Count > 1)
            {
                return new BaseModel { Message = Constants.Messages.AtmSingleSelectionMsg };
            }
            else
            {
                return new BaseModel { Data = selectedAtmIds.FirstOrDefault().ToString(), IsSuccess = true };
            }
        }

        public async Task<BaseModel> GetMultipleSelectedAtms()
        {
            List<long>? selectedAtmIds = await treeService.GetSelectedAtmId();
            if (selectedAtmIds is null || !selectedAtmIds.Any())
            {
                return new BaseModel { Data = (await treeService.GetAtmList()).Select(x =>x.AtmId).ToList().ConvertAll(x => x.ToString()), IsSuccess = true };
            }            
            else
            {
                return new BaseModel { Data = selectedAtmIds.ConvertAll(x => x.ToString()), IsSuccess = true };
            }
        }

        public async Task<BaseModel> GetAllAtms()
        {
                return new BaseModel { Data = (await treeService.GetAtmList()).Select(x => x.AtmId).ToList().ConvertAll(x => x.ToString()), IsSuccess = true };
        }
    }
}
