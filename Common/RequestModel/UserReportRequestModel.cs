using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class UserReportRequestModel
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public List<string> SelectedAtmIds { get; set; }
    }
}
