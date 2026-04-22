using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class ReportsRequestModel
    {
        public string redisKey { get; set; }

        public string redisKeySubReport { get; set; }
        
        public string dt { get; set; }

        public string? dtSubReport { get; set; }
    }
}
