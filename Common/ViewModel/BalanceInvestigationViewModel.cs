using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class BalanceInvestigationViewModel
    {
        public int RowCount { get; set; }
        public string ATM { get; set; }

        public DateTime Date { get; set; }

        public string BillOpeningBalance { get; set; }
        public string BillClosingBalance { get; set; }
        public string BillPreWthdrawals { get; set; }
        public string BillWthdrawals { get; set; }
        public string BillReturns { get; set; }

        public string OperationBalance { get; set; }

        public string Replenishment { get; set; }
        
        public string PreWithdrawals { get; set; }
        
        public string Returns { get; set; }

        public string Withdrawals { get; set; }

        public string ClosingBalance { get; set; }
        
        public string CashPositionBalance { get; set; }
        
        public int SummaryId { get; set; }

        public DateTime? TxrnDateTime { get; set; }

        public string AtmIp { get; set; }

        public string AtmLocation { get; set; }

        public long AtmId { get; set; }

    
    }
}
