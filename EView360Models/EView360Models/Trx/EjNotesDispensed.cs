using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjNotesDispensed
{
    public long EjNotesDispensedId { get; set; }

    public int? NotesDispensedType1 { get; set; }

    public int? NotesDispensedType2 { get; set; }

    public int? NotesDispensedType3 { get; set; }

    public int? NotesDispensedType4 { get; set; }

    public long? AtmId { get; set; }

    public long? TaskId { get; set; }

    public DateTime? ProcessingDatetime { get; set; }

    public DateTime ClearingDatetime { get; set; }

    public int? NotesRemainingType1 { get; set; }

    public int? NotesRemainingType2 { get; set; }

    public int? NotesRemainingType3 { get; set; }

    public int? NotesRemainingType4 { get; set; }

    public int? StartIndex { get; set; }

    public int? EndIndex { get; set; }

    public int? NotesDispensedType5 { get; set; }

    public int? NotesDispensedType6 { get; set; }

    public int? NotesDispensedType7 { get; set; }

    public int? NotesRemainingType5 { get; set; }

    public int? NotesRemainingType6 { get; set; }

    public int? NotesRemainingType7 { get; set; }
}
