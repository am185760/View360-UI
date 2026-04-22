using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class FileTypeViewModel
    {
        public int FileTypeId { get; set; }

        public string PathAtAtm { get; set; } = null!;

        public string FileTypeTitle { get; set; } = null!;

        public string CopyType { get; set; } = null!;

        public bool IsEjlog { get; set; }
    }
}
