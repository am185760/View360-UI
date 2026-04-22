using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.RequestModel
{
    public class WithdrawalTransactionRequestModel
    {
        public DateTime? fromDate { get; set; }
        
        public DateTime? toDate { get; set; }
        
        public int? purgedFrom { get; set; }
        
        public int? purgedTo { get; set; }
        
        public int? amountFrom { get; set; }
        
        public int? amountTo { get; set; }
        
        public int? dispensed1 { get; set; }
        
        public int? dispensed2 { get; set; }
        
        public int? dispensed3 { get; set; }
        
        public int? dispensed4 { get; set; }
        
        public int? noteSetTypeId { get; set; }
        
        public int? indexId { get; set; }

        public int? orderId { get; set; }

        public int numberOfCycle { get; set; }

        public string? SelectedAtm { get; set; }

        public List<string> UserAtmIds { get; set; }
        public string ArchiveYear { get; set; }

    }
}
