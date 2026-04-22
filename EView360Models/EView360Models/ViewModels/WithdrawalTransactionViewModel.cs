using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class WithdrawalTransactionViewModel
    {
        public int RowCount { get; set; }

        public int AtmId { get; set; }
        
        public string Location { get; set; }
        
        public string Tittle { get; set; }

        public DateTime? DateTime { get; set; }

        public DateTime? ProcessingDateTime { get; set; }
    
        public string Amount { get; set; }

        public string Group { get; set; }
        public string IP { get; set; }

        public int Dispensed1 { get; set; }
        public int Dispensed2 { get; set; }
        public int Dispensed3 { get; set; }
        public int Dispensed4 { get; set; }
        public int Purged1 { get; set; }
        public int Purged2 { get; set; }
        public int Purged3 { get; set; }
        public int Purged4 { get; set; }
        public int PurgedNotes { get; set; }
        public int Remaining1 { get; set; }
        public int Remaining2 { get; set; }
        public int Remaining3 { get; set; }
        public int Remaining4 { get; set; }

        public string IsBillDispenser { get; set; }
    
    
    }
}
