using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class TaskStatusReportViewModel
    {
        public string AtmTittle { get; set; }

        public string AtmLocation { get; set; }

        public string CreationTime { get; set; }

        public string EndTime { get; set; }

        public string LastInvoked { get; set; }

        public string Status { get; set; }

        public string TaskType { get; set; }

        public string FailureReason { get; set; }
    }
}
