using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class TodaysActivityRequestModel
    {
        public List<string> SelectedAtms { get; set; }

        public long UserId { get; set; }
    }
}
