using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class NoteSetTypeViewModel
    {
        public long RegionId { get; set; }

        public string NoteSetTypeName { get; set; } = null!;

        public int? DenominationType1 { get; set; }

        public int? DenominationType2 { get; set; }

        public int? DenominationType3 { get; set; }

        public int? DenominationType4 { get; set; }

        public int? DenominationType5 { get; set; }

        public int? DenominationType6 { get; set; }

        public int? DenominationType7 { get; set; }

        public long NoteSetTypeId { get; set; }

        public long CreatedBy { get; set; }

        public string? DenominationType1Title { get; set; }

        public string? DenominationType2Title { get; set; }

        public string? DenominationType3Title { get; set; }

        public string? DenominationType4Title { get; set; }

        public string? DenominationType5Title { get; set; }

        public string? DenominationType6Title { get; set; }

        public string? DenominationType7Title { get; set; }

        public DateTime CreationTime { get; set; }

        public bool? IsType1MultiCurrency { get; set; }

        public bool? IsType2MultiCurrency { get; set; }

        public bool? IsType3MultiCurrency { get; set; }

        public bool? IsType4MultiCurrency { get; set; }

        public bool? IsType5MultiCurrency { get; set; }

        public bool? IsType6MultiCurrency { get; set; }

        public bool? IsType7MultiCurrency { get; set; }

        public bool? IsType1Recycler { get; set; }

        public bool? IsType2Recycler { get; set; }

        public bool? IsType3Recycler { get; set; }

        public bool? IsType4Recycler { get; set; }

        public bool? IsType5Recycler { get; set; }

        public bool? IsType6Recycler { get; set; }

        public bool? IsType7Recycler { get; set; }

        public bool? IsSelected { get; set; }
    }
}
