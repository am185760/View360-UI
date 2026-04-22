using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AtmViewModel
    {
        public long AtmId { get; set; }
        public string Title { get; set; }
        public string Ip { get; set; }
        public string AtmType { get; set; }
        public bool? IsAtm { get; set; }
        public bool? IsCdm { get; set; }
        public bool? IsRecycler { get; set; }
        public long? RegionId { get; set; }
        public string? Location { get; set; }
        public bool IsHealthy { get; set; }
        public long NoteSetTypeId { get; set; }
        public decimal? MinOperatingBalance { get; set; }
    }
}
