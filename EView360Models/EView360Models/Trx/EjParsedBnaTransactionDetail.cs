using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjParsedBnaTransactionDetail
{
    public long EjParsedBnaTransactionDetailId { get; set; }

    public long EjParsedBnaTransactionId { get; set; }

    public int NoteType { get; set; }

    public int NotesCount { get; set; }
}
