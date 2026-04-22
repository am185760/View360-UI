using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjParsedReplenishment
{
    public long EjParsedReplenishmentsId { get; set; }

    public long? AtmId { get; set; }

    public int? NotesAddedType1 { get; set; }

    public int? NotesAddedType2 { get; set; }

    public int? NotesAddedType3 { get; set; }

    public int? NotesAddedType4 { get; set; }

    public DateTime RepDatetime { get; set; }

    public long? TaskId { get; set; }

    public DateTime? ProcessingDatetime { get; set; }

    public int? StartIndex { get; set; }

    public int? EndIndex { get; set; }

    public int? LastTsn { get; set; }

    public int? NotesAddedType5 { get; set; }

    public int? NotesAddedType6 { get; set; }

    public int? NotesAddedType7 { get; set; }
}
