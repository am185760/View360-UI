using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class MinimumThresholdViewModel
    {
        public string? ATM { get; set; }

        public double? MinimumThresholdBalance { get; set; }

        public int? RemainingAmount { get; set; }
        
        public string? Location { get; set; }
        
        public string? IpAddress { get; set; }

        public string? NoteSetTypeName { get; set; }
    }
}
