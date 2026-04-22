using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class BnaTransactionViewModel
    {
        public int RowCount { get; set; }

        public string? ATM { get; set; }

        public DateTime?   LastBNADeposit { get; set; }
        
        public int Cassette1 { get; set; }
        
        public int Cassette2 { get; set; }
        
        public int Cassette3 { get; set; }
        
        public int Cassette4 { get; set; }
        
        public int Cassette5 { get; set; }

        public int Total { get; set; } 

        public string Location { get; set; } 

        public string IP { get; set; }
        public long AtmId { get; set; }

    }
}
