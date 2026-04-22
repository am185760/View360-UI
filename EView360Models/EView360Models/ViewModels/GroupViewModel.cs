using EView360Models.Core;

namespace EView360Models.ViewModels
{
    public class GroupViewModel
    {
        public Group? group { get; set; }
        public List<string>? groupUsers { get; set; }

        public List<string>? groupRights { get; set; }

    }
}
