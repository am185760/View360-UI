using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class RightsViewModel
    {
        public List<long> AdminRights { get; set;}
        public List<long> OperationRights { get; set; }
        public List<long> ReportRights { get; set; }
        public List<long> ArchiveRights { get; set; }
    }
}
