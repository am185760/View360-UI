using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AllValueViewModel
    {        
        public string? AtmIP { get; set; }
        public DateTime? LastInvoked { get; set; }
        public string? FileName { get; set; }
        public DateTime? FileCreationDateTime { get; set; }
        public long FileSize { get; set; }
    }
    public class AtmPendingFileViewModel
    {
        public long AtmId { get; set; }
        public string AtmTitle { get; set; }
        public string AtmType { get; set; }
        public string Location { get; set; }
        public bool? IsAtm { get; set; }
        public bool? IsCdm { get; set; }
        public bool? IsRecycler { get; set; }
        public string? AtmIP { get; set; }
        public int PendingFilesCount { get; set; }
        public DateTime? LastInvoked { get; set; }
        public List<FileDetailViewModel> fileDetails { get; set; }
    }

    public class FileDetailViewModel
    {
        public string? FileName { get; set; }
        public DateTime? FileCreationDateTime { get; set; }
        public long FileSize { get; set; }
    }
}
