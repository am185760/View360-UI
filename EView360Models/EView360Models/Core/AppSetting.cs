using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EView360Models.Core;

public partial class AppSetting
{
    public long AppSettingId { get; set; }

    [Required]
    public string CashDataStoresLocation { get; set; } = null!;

    [Required]
    public int DefaltAtmPort { get; set; }

    [Required]
    public int RefreshInterval { get; set; }

    [Required]
    public string TemporaryFolder { get; set; } = null!;

    [Required]
    public string LogFilePath { get; set; } = null!;

    public bool ParsingEnabled { get; set; }

    public string? LicenseKey { get; set; }

    public bool ApplyPasswordPolicy { get; set; }

    public string UiLogLevel { get; set; } = null!;

    public string ServiceLogLevel { get; set; } = null!;

    [Required]
    public int HeartBeatRefreshInterval { get; set; }

    public string? SmtpUsername { get; set; }

    public string? SmtpPassword { get; set; }

    public string? SmtpServer { get; set; }

    public short? SmtpPort { get; set; }

    public bool? SmtpRequiresAuthentication { get; set; }

    [Required]
    public string DownloadedFilePath { get; set; } = null!;

    [Required]
    public string ServerIp { get; set; } = null!;

    [Required]
    public int ServerPort { get; set; }

    public int? ArchivalDays { get; set; }

    public string? ArchivalServer { get; set; }

    public string? ArchivalDatabase { get; set; }

    public string? ArchivalUsername { get; set; }

    public string? ArchivalPassword { get; set; }

    public int DashboardRefreshInterval { get; set; }

    public DateTime CashOrderExecutionTime { get; set; }

    public int? ThresholdForAlert { get; set; }

    public int? ThresholdForFtp { get; set; }

    public int? ThresholdForTask { get; set; }

    public int? ThresholdForCashorder { get; set; }

    public bool HoldOtherDfTasks { get; set; }

    public int? AlertExpirationTime { get; set; }

    public bool? IsCipheredComm { get; set; }

    public DateTime? VaultDayBalanceExecutionTime { get; set; }

    [Required]
    public int RetryCountCashOrderUpload { get; set; }

    [Required]
    public int RetryCountCashOrderDownload { get; set; }

    [Required]
    public int RetryCountDffUpload { get; set; }

    [Required]
    public int RetryCountConfUpload { get; set; }

    [Required]
    public int RetryCountCounterFile { get; set; }

    [Required]
    public int RetryCountRestartSchedule { get; set; }

    [Required]
    public int RetryCountDatetimeSchedule { get; set; }

    public int CutOverLogFileInterval { get; set; }

    public int RetryCountAlert { get; set; }

    public DateTime? LastEjSummaryGeneratedAt { get; set; }

    public int? FailedToParseThreshold { get; set; }

    public string? ActiveDirectoryDomain { get; set; }

    public bool? IsSuspectedRepTaskDisabled { get; set; }

    public string? RepTimeDiff { get; set; }

    public string? RepStartTime { get; set; }

    public string? RepEndTime { get; set; }

    public int? NotesDifference { get; set; }

    public bool? IsDuplicateCheckingEnabled { get; set; }

    public int AllowedNoOfDaysForMismatchedTrxnProcessing { get; set; }

    public bool? IsDffHalted { get; set; }

    public bool IsLedgerAutoCreated { get; set; }

    public string? InitEjExecTime { get; set; }

    public int? ServerPort2 { get; set; }

    public bool? IsGoogleMapEnabled { get; set; }

    public int? CcmsParserRefreshInterval { get; set; }

    public DateTime? CashOrderGenerationTime { get; set; }

    public int? CurrencyServerRefreshInterval { get; set; }

    public string? CurrencyMngPassword { get; set; }

    public string? ExchangePassword { get; set; }

    public string? ExchangePopPassword { get; set; }

    public string? EjParserZipPassword { get; set; }

    public string? EjParserFtpPassword { get; set; }

    public string? BankName { get; set; }

    public string? SmsToken { get; set; }

    public DateTime? SmsTokenGeneratedAt { get; set; }

    public int? CustomerTransactionAmountThresholdLow { get; set; }

    public int? CustomerTransactionAmountThresholdMedium { get; set; }

    public byte[]? ServersInfo { get; set; }

    public bool? IsSecuredAccess { get; set; }

    public string? DailyFeedFtpUri { get; set; }

    public string? DailyFeedFtpUsername { get; set; }

    public string? DailyFeedFtpPassword { get; set; }

    public DateTime? DailyFeedGenerationTime { get; set; }

    public string? DailyFeedOutputFilePath { get; set; }

    public int? DailyFeedGenerationDelay { get; set; }

    public bool? IsEdited { get; set; }

    public string? CoreDbName { get; set; }

    public string? CashDbName { get; set; }

    public string? TxDbName { get; set; }

    public int? AtmDataStreamingHeartbeatPort { get; set; }

    public int? AtmDataStreamingPort { get; set; }

    public int? AtmOnDemandRequestPort { get; set; }

    public int? AtmOnDemandRequestHearbeatPort { get; set; }
    public int Tcptimeout { get; set; } = 20000;
}
