using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class TaskStatusReportRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime? EndTimeFrom { get; set; }

        public DateTime? EndTimeTo { get; set; }
        
        public int UserId { get; set; }
        
        public int NoteSetTypeId { get; set; }
        
        public string? TaskType { get; set; }
        
        public string? Status { get; set; }
        
        public string? AtmType { get; set; }

        public List<string> SelectedAtms { get; set; }
        public List<string> SelectedRegionIds { get; set; }

        public string ArchiveYear { get; set; }

    }
}
