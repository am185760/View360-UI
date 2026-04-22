using EView360.Data;
using System.Data;
using EView360Models.Core;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;
using EView360Models.ViewModels;
using EView360.Pages;
using NPOI.SS.Formula.Functions;
using Blazorise;
using static EView360.Common.Constants;
using DataRequestorMiddleware.Services.Admin;

namespace EView360.Services
{
    public class ATMTreeViewRepository
    {

        private HttpClient client { get; set; }
        private ApiUrl _apiUrl { get; }
        public List<Region> RegionList { get; set; }
        public List<AtmViewModel> AtmList { get; set; }
        public List<long> SelectedAtmIds { get; set; }
        public List<long> SelectedtAtmParentId { get; set; }
        public List<long> SelectedRegionIdWithAllChildRegions { get; set; }
        public string SelectedType { get; set; }
        public long? SelectedRegionId { get; set; }

        private bool isTreeviewNodeExpanded = false; // make it in config..
        private ILogger _logger { get; set; }
        private string? BaseUrl { get; set; }
        public static long UserId { get; set; }

        private AtmTreeService _atmTreeService { get; set; }
        private RegionService _regionService { get; set; }
        public Blazored.LocalStorage.ILocalStorageService _localStorage { get; set; }

        public ATMTreeViewRepository(HttpClient httpClient, IOptions<ApiUrl> apiUrl, ILogger<ATMTreeViewRepository> logger, AtmTreeService atmTreeService, RegionService regionService)
        {
            _apiUrl = apiUrl.Value;
            client = httpClient;
            BaseUrl = new Uri(_apiUrl.BaseUrl + $"{_apiUrl.TreeBuilder}TreeBuilder/").ToString();
            _logger = logger;
            _atmTreeService = atmTreeService;
            _regionService = regionService;
        }



        public TreeResponseViewModel GetAtmAndRegionList(ref string atmRespone, ref string regionRespone)
        {
            TreeResponseViewModel treeResponse = new();

            try
            {
                if (AtmList is null || !AtmList.Any() || RegionList is null || !RegionList.Any())
                {
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _atmTreeService.GetAtmsByUser  : {DateTime.Now.ToString()}");
                    treeResponse.AtmList = _atmTreeService.GetAtmsByUser(UserId, ref atmRespone);
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _atmTreeService.GetAtmsByUser  : {DateTime.Now.ToString()}");

                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in _regionService.GetRegions  : {DateTime.Now.ToString()}");
                    treeResponse.RegionList = _regionService.GetRegions(ref regionRespone);
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from _regionService.GetRegions  : {DateTime.Now.ToString()}");
                                       

                    if (!string.IsNullOrEmpty(atmRespone))
                        _logger.LogError($"Error from GetAtmsByUser: {atmRespone}");

                    if (!string.IsNullOrEmpty(regionRespone))
                        _logger.LogError($"Error from GetRegions: {regionRespone}");


                    if (treeResponse != null)
                    {
                        if (treeResponse.AtmList?.Count > 0)
                        {
                            AtmList = treeResponse.AtmList;
                        }
                        if (treeResponse.RegionList?.Count > 0)
                        {
                            RegionList = treeResponse.RegionList;
                        }
                    }
                }
                else
                {
                    treeResponse.AtmList = AtmList;
                    treeResponse.RegionList = RegionList;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Exception at GetAtmAndRegionList: {ex.Message}");
            }           

            return treeResponse;
        }


        //public async Task<TreeResponseViewModel> GetATMAndRegionListByUser()
        //{
        //    TreeResponseViewModel treeResponse = new();
        //    try
        //    {
        //        using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}GetRegionAndAtmByUserId/{UserId}");
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            _logger.LogError($"Error at api TreeBuilder, GetRegionAndAtmByUserId as: {responseBody}");
        //        }
        //        if (!string.IsNullOrEmpty(responseBody))
        //        {
        //            treeResponse = JsonConvert.DeserializeObject<TreeResponseViewModel>(responseBody)!;
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        _logger.LogError($"Exception at GetATMRegionByUser: {ex.Message}");
        //    }
        //    return treeResponse;
        //}


        public async Task<Data.TreeView> BuidATMTreeView(List<Region>? regions, List<AtmViewModel>? atms)
        {
            RegionList = regions;
            AtmList = atms;

            Data.TreeView atmTreeView = new();
            try
            {
                List<TreeViewNode> nodeList = new();
                bool allowEditRegion = true; // make it from User Permissions...
                bool allowEditATM = true; // make it from User Permissions...

                if (RegionList?.Count > 0)
                {
                    foreach (Region region in RegionList)
                    {
                        if (region.ParentRegionId is null)
                        {
                            TreeViewNode node = CreateRegionNode(region.RegionName, isTreeviewNodeExpanded, region.RegionId, "fa fa-university fa-lg");
                            node.EditingEnabled = node.DraggingEnabled = allowEditRegion;
                            node.Type = "TreeRoot";
                            nodeList.Add(node);                            
                            PopulateSubTree(region, node, allowEditRegion, allowEditATM);
                        }
                    }
                }
                atmTreeView.treeNodes = nodeList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at BuidATMTreeView: {ex.Message}");
            }
            return await System.Threading.Tasks.Task.FromResult(atmTreeView);
        }

        public TreeViewNode CreateRegionNode(string text, bool expanded, long id, string icon)
        {
            TreeViewNode node = new()
            {
                Text = text,
                Id = $"r{id}",
                Icon = icon,
                DroppingEnabled = ($"r{id}" == "r1") ? false : true,
                Expanded = expanded,
                Type = "non_atm",
                HasChildren = (AtmList.Any(x => x.RegionId == id) || RegionList.Any(x => x.ParentRegionId == id)) ? true : false
            };

            return node;
        }

        public void PopulateSubTree(Region parentRegionRow, TreeViewNode node, bool allowEditingRegion, bool allowEditingATM)
        {
            try
            {
                if (parentRegionRow != null && node != null)
                {
                    foreach (Region region in RegionList.Where(x => x.ParentRegionId == parentRegionRow.RegionId).ToList())
                    {
                        TreeViewNode childNode = CreateRegionNode(region.RegionName, isTreeviewNodeExpanded, region.RegionId, "fas fa-sitemap");
                        node.Nodes = node.Nodes ?? new List<TreeViewNode>();
                        node.Nodes.Add(childNode);
                        childNode.EditingEnabled = childNode.DraggingEnabled = allowEditingRegion;
                        PopulateSubTree(region, childNode, allowEditingRegion, allowEditingATM);
                    }
                    int atmCount = 0;
                    if (AtmList?.Count > 0)
                    {
                        foreach (AtmViewModel atmNode in AtmList.Where(x => x.RegionId == parentRegionRow.RegionId).ToList())
                        {
                            atmCount++;
                            TreeViewNode childNode = CreateATMNode(atmNode.Title, atmNode.AtmId, (atmNode.Location ?? string.Empty), "fa fa-credit-card");
                            node.Nodes = node.Nodes ?? new List<TreeViewNode>();
                            node.Nodes.Add(childNode);
                            childNode.EditingEnabled = childNode.DraggingEnabled = allowEditingATM;
                        }
                        if (atmCount > 0)
                        {
                            node.ToolTip = "Total Atms = " + atmCount;
                        }
                        else
                        {
                            node.ToolTip = "Total Atms = 0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
            }
        }

        private TreeViewNode CreateATMNode(string text, long id, string location, string icon)
        {
            return new TreeViewNode()
            {
                Text = text,
                Id = $"a{id}",
                Icon = icon,
                DroppingEnabled = false,
                ToolTip = location,
                Type = "atm"
            };
        }

        public async Task<string> MoveNode(string currentNodeId, string parentNodeId)
        {
            try
            {
                long parentRegionId = long.Parse(parentNodeId.Substring(1));
                long nodeID = long.Parse(currentNodeId.Substring(1));
                string atmRespone = string.Empty, regionRespone = string.Empty;
                HttpResponseMessage response = new HttpResponseMessage();

                if (currentNodeId[0] == 'a' && parentNodeId[0] == 'r')
                {
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateAtmRegionId  : {DateTime.Now.ToString()}");
                    response = await client.PutAsync($"{BaseUrl}UpdateAtmRegionId?atmId={nodeID}&regionId={parentRegionId}", null);
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateAtmRegionId  : {DateTime.Now.ToString()}");
                                        
                }
                else if (currentNodeId[0] == 'r' && parentNodeId[0] == 'r')
                {
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateRegionParentId  : {DateTime.Now.ToString()}");
                    response = await client.PutAsync($"{BaseUrl}UpdateRegionParentId?regionId={nodeID}&parentRegionId={parentRegionId}", null);
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateRegionParentId  : {DateTime.Now.ToString()}");
                    
                }

                GetAtmAndRegionList(ref atmRespone, ref regionRespone);

                if (response.IsSuccessStatusCode)
                {
                    return "success";
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error in api TreeBuilder, (UpdateAtmRegionId,UpdateRegionParentId) as: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at MoveNode: {ex.Message}");
            }
            return "An error occured while moving the node";
        }

        public async Task<string> CreateRegion(string nodeName, string parentRegion)
        {
            try
            {
                Region region = new()
                {
                    RegionName = nodeName,
                    ParentRegionId = long.Parse(parentRegion.Substring(1)),
                    CreatedBy = UserId,
                    IsActive = true,
                    CreationTime = DateTime.Now
                };
                string atmRespone = string.Empty, regionRespone = string.Empty;
                var jsonContent = JsonConvert.SerializeObject(region);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in CreateRegion  : {DateTime.Now.ToString()}");
                HttpResponseMessage result = await client.PostAsync($"{BaseUrl}CreateRegion", content);
                _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from CreateRegion  : {DateTime.Now.ToString()}");
                                
                var responseBody = await result.Content.ReadAsStringAsync();
                GetAtmAndRegionList(ref atmRespone, ref regionRespone);

                if (result.IsSuccessStatusCode)
                {
                    return responseBody;
                }
                _logger.LogError($"Error in api TreeBuilder, CreateRegion : {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at CreateNode : {ex.Message}");
            }
            return "An error occured while creating the node";
        }


        public async Task<string> RenameNode(string currentNodeId, string newName, string oldName)
        {
            try
            {
                long nodeID = long.Parse(currentNodeId.Substring(1));
                string atmRespone = string.Empty, regionRespone = string.Empty;

                if (currentNodeId[0] == 'a')
                {
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in IfAtmExistByTitle  : {DateTime.Now.ToString()}");
                    using HttpResponseMessage response = client.GetAsync($"{BaseUrl}IfAtmExistByTitle?atmTitle={newName}").Result;
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from IfAtmExistByTitle  : {DateTime.Now.ToString()}");

                    
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"API error at Tree, IfAtmExistByTitle as: {responseBody}");
                        return "An error occured while renaming the node";
                    }
                    if (responseBody == "false")
                    {
                        _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateAtmTitle  : {DateTime.Now.ToString()}");
                        using HttpResponseMessage renameResponse = await client.PutAsync($"{BaseUrl}UpdateAtmTitle?atmId={nodeID}&atmTitle={newName}", null);
                        _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateAtmTitle  : {DateTime.Now.ToString()}");

                        
                        GetAtmAndRegionList(ref atmRespone, ref regionRespone);
                        if (renameResponse.IsSuccessStatusCode)
                        {
                            return "success";
                        }
                        else
                        {
                            string renameResponseBody = await renameResponse.Content.ReadAsStringAsync();
                            _logger.LogError($"Rename Issue from API as: {renameResponseBody}");
                        }
                    }
                    else
                    {
                        return "ATM already exists with the same name provided";
                    }
                }
                else if (currentNodeId[0] == 'r')
                {
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in UpdateRegionName  : {DateTime.Now.ToString()}");
                    using HttpResponseMessage renameResponse = await client.PutAsync($"{BaseUrl}UpdateRegionName?regionId={nodeID}&regionName={newName}", null);
                    _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from UpdateRegionName  : {DateTime.Now.ToString()}");

                    
                    if (renameResponse.IsSuccessStatusCode)
                    {
                        return "success";
                    }
                    else
                    {
                        string renameResponseBody = await renameResponse.Content.ReadAsStringAsync();
                        _logger.LogError($"Rename Issue from API as: {renameResponseBody}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at RenameNode: {ex.Message}");
            }
            return "An error occured while renaming the node";
        }

        public async Task<string> DeleteNode(string currentNodeId)
        {
            try
            {
                string atmRespone = string.Empty, regionRespone = string.Empty;

                _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} going in DeleteRegion  : {DateTime.Now.ToString()}");
                using HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}DeleteRegion?regionId={currentNodeId.Substring(1)}");
                _logger.LogWarning($"ATMTreeViewRepository: {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name} return from DeleteRegion  : {DateTime.Now.ToString()}");
                                
                GetAtmAndRegionList(ref atmRespone, ref regionRespone);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) return "success";

                string responseBody = await response.Content.ReadAsStringAsync();
                _logger.LogError($"API issue at Tree, DeleteRegion as: {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
            }
            return "An error occured while deleting the region";
        }

        public async Task<List<long>?> GetSelectedAtmId()
        {
            return SelectedAtmIds;
        }

        public async Task<long?> GetSelectedRegionId()
        {
            return SelectedRegionId;
        }

        public async Task<List<long>?> GetSelectedAtmParentId()
        {
            return SelectedtAtmParentId;
        }

        public async Task<string?> GetSelectedType()
        {
            return SelectedType;
        }
        public async Task<List<long>?> GetSelectedRegionIdWithAllChildRegions()
        {
            return SelectedRegionIdWithAllChildRegions;
        }
        public async Task<List<Atm>?> GetAtmList()
        {
            List<Atm> atms = new();

            List<AtmViewModel>? atmLst = AtmList;
            if (atmLst?.Count > 0)
            {
                string json = JsonConvert.SerializeObject(atmLst);
                atms = JsonConvert.DeserializeObject<List<Atm>>(json)!;
            }
            return atms;
        }

        public async Task<(List<string>? selectedAtmList,  List<string>? selectedRegionList)> GetSelectedAtmOrRegionList()
        {
            try
            {
                if((await GetSelectedType()) != null && (await GetSelectedType()).Equals(SessionStorageKeys.TypeRegion))
                {
                    //always pass atmIds since required by DataRequestor. Indentify by Region (if Region selected then RegionId.count>0 else RegionId=null)
                    return ((await GetSelectedAtmId())?.ConvertAll(x => x.ToString()), (await GetSelectedRegionIdWithAllChildRegions())?.ConvertAll(x => x.ToString()));
                }
                else
                {
                    return ((await GetSelectedAtmId())?.ConvertAll(x => x.ToString()), null);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception at GetSelectedAtmOrRegionList: {ex.Message}");
            }
            return (null, null);
        }
        public void ClearAtmRegionSessionValues()
        {
            AtmList = new();
            RegionList = new();
        }
        public async Task ClearAtmSessionValues()
        {
            AtmList = new();
            RegionList = new();
            SelectedRegionIdWithAllChildRegions = new();
            SelectedType = string.Empty;
            SelectedAtmIds = new();
            SelectedtAtmParentId = new();
        }
    }
}
