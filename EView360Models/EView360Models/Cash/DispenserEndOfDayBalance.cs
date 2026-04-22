using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class DispenserEndOfDayBalance
{
    public long DispenserEndOfDayBalanceId { get; set; }

    public long AtmId { get; set; }

    public DateTime CounterFileDatetime { get; set; }

    public int Cassette1RemainingNotes { get; set; }

    public int Cassette2RemainingNotes { get; set; }

    public int Cassette3RemainingNotes { get; set; }

    public int Cassette4RemainingNotes { get; set; }

    public int Cassette5RemainingNotes { get; set; }

    public int Cassette6RemainingNotes { get; set; }

    public int Cassette7RemainingNotes { get; set; }

    public int Cassette1DispensedNotes { get; set; }

    public int Cassette2DispensedNotes { get; set; }

    public int Cassette3DispensedNotes { get; set; }

    public int Cassette4DispensedNotes { get; set; }

    public int Cassette5DispensedNotes { get; set; }

    public int Cassette6DispensedNotes { get; set; }

    public int Cassette7DispensedNotes { get; set; }

    public int Cassette1PurgedNotes { get; set; }

    public int Cassette2PurgedNotes { get; set; }

    public int Cassette3PurgedNotes { get; set; }

    public int Cassette4PurgedNotes { get; set; }

    public int Cassette5PurgedNotes { get; set; }

    public int Cassette6PurgedNotes { get; set; }

    public int Cassette7PurgedNotes { get; set; }

    public DateTime ProcessedAtDatetime { get; set; }
}
