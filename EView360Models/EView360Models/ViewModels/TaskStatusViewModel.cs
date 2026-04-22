using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class TaskStatusViewModel
    {
        public long AtmId { get; set; }
        public string? Status { get; set; }
        public DateTime? LastInvoked { get; set; }
    }
}
