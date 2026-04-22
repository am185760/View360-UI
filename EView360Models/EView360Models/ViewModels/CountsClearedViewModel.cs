namespace EView360Models.ViewModels
{
    public class CountsClearedViewModel
    {
        public int AtmId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int NotesDispensedType1 { get; set; } = 0;
        public int NotesDispensedType2 { get; set; } = 0;
        public int NotesDispensedType3 { get; set; } = 0;
        public int NotesDispensedType4 { get; set; } = 0;
        public int NotesDispensedType5 { get; set; } = 0;
        public int NotesDispensedType6 { get; set; } = 0;
        public int NotesDispensedType7 { get; set; } = 0;
        public int NotesRemainingType1 { get; set; } = 0;
        public int NotesRemainingType2 { get; set; } = 0;
        public int NotesRemainingType3 { get; set; } = 0;
        public int NotesRemainingType4 { get; set; } = 0;
        public int NotesRemainingType5 { get; set; } = 0;
        public int NotesRemainingType6 { get; set; } = 0;
        public int NotesRemainingType7 { get; set; } = 0;
        public DateTime? ClearingDatetime { get; set; }
        public int RowCount { get; set; }

    }
}
