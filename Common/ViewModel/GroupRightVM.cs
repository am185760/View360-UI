using EView360Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class GroupRightVM
    {
        public Group? group { get; set; }
        public List<GroupRight>? groupRights { get; set; }
        public AuditLogViewModel? AuditData { get; set; }
    }
}
