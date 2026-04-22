using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestor
{
    public class AppServerInfo
    {
        public string ServerName { set; get; }
        public string ServerIP { set; get; }
        public string ServerPort { set; get; }

        public AppServerInfo()
        {
            this.ServerName = string.Empty;
            this.ServerIP = string.Empty;
            this.ServerPort = string.Empty;
        }

        public AppServerInfo(string serverName, string serverIP, string serverPort)
        {
            this.ServerName = serverName;
            this.ServerIP = serverIP;
            this.ServerPort = serverPort;
        }
    }
}
