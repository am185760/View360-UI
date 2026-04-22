using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AtmStatusViewModel
    {
        public long AtmId { get; set; }
        public string? Title { get; set; }
        public DateTime? LastTransaction { get; set; }
        public string? LastTaskStatus { get; set; }
        public DateTime? LastInvoked { get; set; }
    }
}
