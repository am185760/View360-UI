using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class GroupReportViewModel
    {
        public string? GroupName { get; set; }

        public List<string> SelectedAtmIds { get; set; }
    }
}
