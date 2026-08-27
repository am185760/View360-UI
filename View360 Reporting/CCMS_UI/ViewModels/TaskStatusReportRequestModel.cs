using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class TaskStatusReportRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime? EndTimeFrom { get; set; }

        public DateTime? EndTimeTo { get; set; }

        public int UserId { get; set; }

        public int NoteSetTypeId { get; set; }

        public string TaskType { get; set; }

        public string Status { get; set; }

        public string AtmType { get; set; }

        public List<string> SelectedAtms { get; set; }
    }
}