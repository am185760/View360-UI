using EView360Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class TreeResponseViewModel
    {
        public List<Region>? RegionList { get; set; }
        public List<AtmViewModel>? AtmList { get; set; }
    }
}
