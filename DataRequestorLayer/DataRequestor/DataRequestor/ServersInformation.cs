using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestor
{
    public class ServersInformation
    {
        public string regKey { get; set; }
        public string InfoPath { get; set; }
        public List<DBServerInfo> DBServers { get; set; }
        public List<AppServerInfo> AppServers { get; set; }
    }
}
