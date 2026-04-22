using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ReplenishmentAnalysisViewModel
    {
        public string? Day { get; set; }
        public int Total { get; set; }
        public string? Title { get; set; }
        public string? ReplenishmentDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class ReplenishmentAnalysisResponseViewModel
    {
        public bool IsSucess { get; set; }
        public List<ReplenishmentAnalysisViewModel>? ReplenishmentViews { get; set; }
    }
}
