using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AtmNetworkViewModel
    {
        public long AtmId { get; set; }
        public string Title { get; set; }
        public string Ip { get; set; }
        public string? LastStatusReply { get; set; }
        public bool IsActive { get; set; }
        public string AtmType { get; set; }
        public long CreatedBy { get; set; }
        public string? Location { get; set; }
        public DateTime? AtmStreamingHeartbeatReceivedAt { get; set; }
        public DateTime? AtmOnDemandHeartbeatReceivedAt { get; set; }
        public int? AtmDataStreamingHeartbeatPort { get; set; }
        public int? AtmDataStreamingPort { get; set; }
        public int? AtmOnDemandRequestPort { get; set; }
        public int? AtmOnDemandRequestHearbeatPort { get; set; }
    }
}
