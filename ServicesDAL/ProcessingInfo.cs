using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesDAL
{
    [Serializable]
    public class ProcessingInfo
    {
        public string eventInfo;
        public long taskID;
        public long atmID;
    }
}
