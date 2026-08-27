using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class GroupReportViewModel
    {
        public string GroupName { get; set; }

        public List<string> SelectedAtmIds { get; set; }
    }
}