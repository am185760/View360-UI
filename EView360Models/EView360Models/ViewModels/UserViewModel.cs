using EView360Models.Core;

namespace EView360Models.ViewModels
{
    public class UserViewModel
    {
        public AppUser? User { get; set; }
        public List<AlertType> Alerts { get; set; }
        public List<Group>? Groups { get; set; }
        //public List<CcmsOrganization>? Organizations { get; set; }
        public string[]? AtmIds { get; set; }
    }
}
