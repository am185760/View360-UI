using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EView360Models.Core;


public enum NumberOfTower
{
    OneTower,
    TwoTower
}

public enum RecyclerType
{
    ScalableRecycler,
    BRM,
    RecyclerAndDispenser,
    DualDipenser
}
public partial class Atm
{
    public long AtmId { get; set; }

    public string? LastStatusReply { get; set; }

    public long? RegionId { get; set; }

    [Required(ErrorMessage = "ATM ID is required")]
    [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "ATM ID should be exactly 8 characters")]
    [RegularExpression(@"[A-z][A-z][A-z][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "ATM ID should contain first 3 characters followed by 5 numberic digits")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "IP is required")]
    [RegularExpression(@"[0-9][0-9]*\.[0-9][0-9]*\.[0-9][0-9]*\.[0-9][0-9]*", ErrorMessage = "IP address is invalid.")]
    public string Ip { get; set; } = null!;

    [Required(ErrorMessage = "Port is required")]
    public int Port { get; set; } = 12600;

    public long? ModifiedBy { get; set; }

    public long CreatedBy { get; set; }

    [NotMapped]
    public string? UserFullName { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreationTime { get; set; }

    [Required(ErrorMessage = "Vendor is required")]
    public string AtmType { get; set; } = null!;

    [Required(ErrorMessage = "This field is required")]
    public int Cassette1Capacity { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette1Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette2Capacity { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette2Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette3Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette3Capacity { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette4Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette4Capacity { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette5Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette5Capacity { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette6Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette6Capacity { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette7Denomination { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int Cassette7Capacity { get; set; }

    public bool IsHealthy { get; set; }

    public string? Location { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int? MaxNotesPerCassette { get; set; }

    public long? MinOperatingBalance { get; set; } = 100000;

    public bool? IsAtm { get; set; }

    public bool? IsCdm { get; set; }

    public bool? IsCcdm { get; set; }

    public int? CdmCassette1Capacity { get; set; } = 2000;

    public int? CdmCassette2Capacity { get; set; } = 2000;

    public int? CdmCassette3Capacity { get; set; } = 2000;

    public int? CdmCassette4Capacity { get; set; } = 2000;

    public int? CcdmCassette1Capacity { get; set; }

    public int? CcdmCassette2Capacity { get; set; }

    public int? CcdmCassette3Capacity { get; set; }

    public int? CcdmCassette4Capacity { get; set; }

    public int? CdmCassette1Threshold { get; set; } = 100;

    public int? CdmCassette2Threshold { get; set; } = 100;

    public int? CdmCassette3Threshold { get; set; } = 100;

    public int? CdmCassette4Threshold { get; set; } = 100;

    public int? CcdmCassette1Threshold { get; set; }

    public int? CcdmCassette2Threshold { get; set; }

    public int? CcdmCassette3Threshold { get; set; }

    public int? CcdmCassette4Threshold { get; set; }

    [Required(ErrorMessage = "Note Set Type is required")]
    public long NoteSetTypeId { get; set; }

    [NotMapped]
    public string? NoteSetTypeName { get; set; }

    public int? CcdmCassette5Capacity { get; set; }

    public int? CcdmCassette5Threshold { get; set; }

    public int? StartupSleepInterval { get; set; }

    public byte? DebugLevel { get; set; }

    public int? Purge1Threshold { get; set; }

    public bool? IsPurge1ThresholdSelected { get; set; }

    public int? Purge2Threshold { get; set; }

    public bool? IsPurge2ThresholdSelected { get; set; }

    public int? Purge3Threshold { get; set; }

    public bool? IsPurge3ThresholdSelected { get; set; }

    public int? Purge4Threshold { get; set; }

    public bool? IsPurge4ThresholdSelected { get; set; }

    public int? Purge5Threshold { get; set; }

    public bool? IsPurge5ThresholdSelected { get; set; }

    public int? Purge6Threshold { get; set; }

    public bool? IsPurge6ThresholdSelected { get; set; }

    public int? Purge7Threshold { get; set; }

    public bool? IsPurge7ThresholdSelected { get; set; }

    public int RetryCountConfUpload { get; set; }

    public int Tcptimeout { get; set; } = 20000;

    public int SleepInterval { get; set; }

    public int Type1MinimumNotes { get; set; } = 1000;

    public int Type2MinimumNotes { get; set; } = 1000;

    public int Type3MinimumNotes { get; set; } = 1000;

    public int Type4MinimumNotes { get; set; } = 1000;

    public int Type5MinimumNotes { get; set; } = 1000;

    public int Type6MinimumNotes { get; set; } = 1000;

    public int Type7MinimumNotes { get; set; } = 1000;

    public int? AllowedInactivityPeriod { get; set; } = 43200;

    public string? Description { get; set; }

    public int? ChequeAllowedInactivityPeriod { get; set; }

    public int? BnaAllowedInactivityPeriod { get; set; }

    public int OutOfCashThreshold { get; set; } = 50000;

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    public bool? IsSwapDefaultReplenishment { get; set; }

    public long? MessageProcessorId { get; set; }

    public int? Type1MinNotesThreshold { get; set; }

    public int? Type2MinNotesThreshold { get; set; }

    public int? Type3MinNotesThreshold { get; set; }

    public int? Type4MinNotesThreshold { get; set; }

    [NotMapped]
    public int? Type5MinNotesThreshold { get; set; }

    [NotMapped]
    public int? Type6MinNotesThreshold { get; set; }

    [NotMapped]
    public int? Type7MinNotesThreshold { get; set; }

    public int? Type1MinNotesThresholdValue { get; set; }

    public int? Type2MinNotesThresholdValue { get; set; }

    public int? Type3MinNotesThresholdValue { get; set; }

    public int? Type4MinNotesThresholdValue { get; set; }

    [NotMapped]
    public int? Type5MinNotesThresholdValue { get; set; }

    [NotMapped]
    public int? Type6MinNotesThresholdValue { get; set; }

    [NotMapped]
    public int? Type7MinNotesThresholdValue { get; set; }

    public int? BnaAllowedInactivityPeriodNormalDays { get; set; }

    public int? BnaAllowedInactivityPeriodSalaryDays { get; set; }

    public int? ChequeAllowedInactivityPeriodNormalDays { get; set; }

    public int? ChequeAllowedInactivityPeriodSalaryDays { get; set; }

    public long? CitId { get; set; }

    public bool? IsRecycler { get; set; }

    public string? RecyclerType { get; set; }
        
    public string? RecyclerTower { get; set; }

    public string? LastPingStatus { get; set; }

    public DateTime? LastPingExecutedAt { get; set; }

    public string? LastTelnetStatus { get; set; }

    public DateTime? LastTelnetExecutedAt { get; set; }
    public int? AssignedServer { get; set; }

    public bool? IsEdited { get; set; }

    public int? RetryCountCounterFile { get; set; }

    public DateTime? AtmStreamingHeartbeatReceivedAt { get; set; }

    public DateTime? AtmOnDemandHeartbeatReceivedAt { get; set; }
}
