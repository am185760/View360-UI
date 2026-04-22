using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class FileType
{
    public long FileTypeId { get; set; }

    public string PathAtAtm { get; set; } = null!;

    public string FileTypeTitle { get; set; } = null!;

    public string CopyType { get; set; } = null!;

    public bool IsEjlog { get; set; }
}
