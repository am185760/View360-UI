using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class StatusRequestModel
    {
        public List<string> SelectedAtmIds { get; set; }

        public List<string> TaskType { get; set; }
    }
}
