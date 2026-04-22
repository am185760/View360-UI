using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestor
{
    public class DBServerInfo
    {
        public string ServerName { set; get; }
        public string ServerConnection { set; get; }
        public string ServerCredentials { set; get; }
        public List<string> AtmIds { set; get; }
        public Dictionary<string, string> AtmInfo { set; get; }
        public string MaxATMs { set; get; }
        public string MaxPoolSize { set; get; }

        public DBServerInfo()
        {
            this.ServerName = string.Empty;
            this.ServerConnection = string.Empty;
            this.ServerCredentials = string.Empty;
            this.AtmIds = new List<string>();
            this.MaxATMs = string.Empty;
            this.MaxPoolSize = string.Empty;
        }
        public DBServerInfo(string server, string connStr, List<string> atms, string numOfAtms,string poolSize)
        {
            this.ServerName = server;
            this.ServerConnection = connStr;
            this.AtmIds = new List<string>(atms);
            this.MaxATMs = numOfAtms;
            this.MaxPoolSize = poolSize;
        }
    }
}
