using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class AppSetting
{
    public long AppSettingId { get; set; }

    public string CashDataStoresLocation { get; set; } = null!;

    public int DefaltAtmPort { get; set; }

    public int RefreshInterval { get; set; }

    public string TemporaryFolder { get; set; } = null!;

    public string LogFilePath { get; set; } = null!;

    public bool ParsingEnabled { get; set; }

    public string? LicenseKey { get; set; }

    public bool ApplyPasswordPolicy { get; set; }

    public string UiLogLevel { get; set; } = null!;

    public string ServiceLogLevel { get; set; } = null!;

    public int HeartBeatRefreshInterval { get; set; }

    public string? SmtpUsername { get; set; }

    public string? SmtpPassword { get; set; }

    public string? SmtpServer { get; set; }

    public short? SmtpPort { get; set; }

    public bool? SmtpRequiresAuthentication { get; set; }

    public string DownloadedFilePath { get; set; } = null!;

    public string ServerIp { get; set; } = null!;

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

    public int RetryCountCashOrderUpload { get; set; }

    public int RetryCountCashOrderDownload { get; set; }

    public int RetryCountDffUpload { get; set; }

    public int RetryCountConfUpload { get; set; }

    public int RetryCountCounterFile { get; set; }

    public int RetryCountRestartSchedule { get; set; }

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
}
