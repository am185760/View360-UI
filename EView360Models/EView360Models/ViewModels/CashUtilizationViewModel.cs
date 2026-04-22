using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class CashUtilizationViewModel
    {
        public DateTime? Date { get; set; }
        public decimal? result { get; set; }
    }

    public class CashUtilRespViewModel
    {
        public string? Title { get; set; }
        public DateTime? RepDateTime { get; set; }
        public decimal? RepAmount { get; set; }
        public decimal? ReturnAmount { get; set; }
    }

    public class CashUtilRespWrapper
    {
        public List<CashUtilizationViewModel>? cashUtilizationViews { get; set; }
        public bool IsSucess { get; set; }
        public string? Error { get; set; }
    }
}
