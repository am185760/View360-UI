using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class BnaTransactionDashboardViewModel
    {
        public long AtmId { get; set; }

        public DateTime? LastBNAClearedAt { get; set; }

        public string? ATM { get; set; }

        public string? Region { get; set; }

        public string? DenominationDetail { get; set; }

        public DateTime? LastBNADeposit { get; set; }

        public double Cassette1 { get; set; }

        public double Cassette2 { get; set; }

        public double Cassette3 { get; set; }

        public double Cassette4 { get; set; }

        public double Cassette5 { get; set; }

        public double Total { get; set; }

        public string Location { get; set; }

        public string IP { get; set; }

    }
}
