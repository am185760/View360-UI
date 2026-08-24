
namespace Avanza.CCMS.DAL
{

    public enum EnumIncidentType
    {
        TMDNotification,
        MachineDownNotification,
        Base24Notification
    }
    public enum EventType
    {
        OrderFileNotDownloaded,
        OrderFileNotAvailable,
        InvalidOrderDenomination,
        ATMNotFound,
        CorruptOrderFile,
        OrderBelowThreshold,
        OrderDispatchingFailed,
        ManualOrderDispatching,
        OrderDispatchingEmail,
        NoATMOrderInReplenishment,
        ManualATMAgentLogDownloaded,
        ATMAgentLogNotDownloaded,
        DFFGeneration,
        DFFUploadFailed,
        ManualDFFGeneration,
        ReplenishmentAtATM,
        ATMOutOfCash,
        OrderDispatchedToATM,
        SuspiciousReplenishment,
        ATMResidualMismatch,
        ATMCounterMismatch
    };
    public enum StatusOptions
    {
        scheduled = 1,
        uploading = 2,
        source_not_found = 3,
        cancelled = 4,
        completed = 5,
        restarting = 6,
        uploaded_restart_pending = 7,
        taking_backup = 8,
        upload_skipped_file_exists = 9,
        Error = 10,
        uploading_disconnected = 11,
        restart_scheduled = 12,
    }

    public enum Event_Type
    {
        Alert,
        Notification,
        Warning,
        Error,
        Event,
        Information
    };


    public enum Actors
    {
        OPTICash,
        CCMS,
        NCR,
        BANK,
        CIT,
        ATM
    };

    public enum EntityType
    {
        Order, CIT, Organization, Replenishment,
        Vault, ATM, User, Alert, Cheque, Task,
        CashDifferenceInvestigation, PerformanceInvestigation,
        VaultLedger,
        VaultOrder, VaultTransfer, Application, VaultLedgerDetail
    };


    public enum SmsTaskStatus
    {
        Scheduled,
        InquiryPending,
        InquiryCompleted,
        InquiryFailed,
        SmsPending,
        SmsFailed,
        Completed
    }
    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Rejected,
        Closed
    }

    public enum UploadStates
    {
        scheduled,
        initiating,
        uploading,
        uploadingDisconnected,
        resumedUploading,
        cancelled,
        cancelledOrderExpired,
        cancelledEnoughCashOnATM,
        cancelledAnotherOrderPosted,
        completed,
        unknownError,
        retriesExhausted,
        cashOrderSuspended,
        failed

    }
    public enum DownloadStates
    {
        scheduled = 0,
        initiating = 1,
        nameReceived = 2,
        sizeReceived = 3,
        downloading = 4,
        downloadingDisconnected = 5,
        resumedDownloading = 6,
        downloadedParsePending = 7,
        downloadedParsing = 8,
        cancelled = 9,
        parsingFailed = 10,
        completed = 11,
        unknownError = 12,
        retriesExhausted = 13,
        failed = 14,
            downloadedStorePending = 15
    }
    public enum FTPDownloadStatus
    {
        scheduled,
        failed,
        completed,
        downloaded,
        downloadedImportFailed,
        completedWithExceptions

    }
    public enum EnumTransactionType
    {
        CashDepositTransaction,
        ChequeDepositTransaction,
        NormalTransaction,
        CaptureCardTransaction
    }
    public enum Entity
    {
        atm,
        user,
        region,
        organization
    }
    public enum Action
    {
        add,
        edit,
        remove
    }
    public enum FTPUploadStatus
    {
        scheduled,
        failed,
        completed,
        uploaded
    }

    public enum EnumTaskType
    {
        CashDataDownload = 1,
        DailyFeedUpload = 2,
        CashOrderDownload = 3,
        CashOrderUpload = 4,
        Configuration = 5,
        DateTimeSync = 6,
        Restart = 7,
        HeartbeatConfiguration = 8,
        BatchConfiguration = 9,
        OfflineFileProcessing = 10,
        ApproveSettlement = 11,
        FinalizeSuspectedReplenishment = 12,
        EJDailyFeedUpload = 13,
        ApproveCheque = 14,
        Inventory = 15,
        ApproveVaultAdjustment = 16,
        ApproveVaultSettlement = 17,
        UpdateInvestigation = 18,
        CaptureScreen = 19,
        GetApplicationName = 20,
        StartService = 21,
        StopService = 22,
        GetRunningServices = 23,
        ExecuteInitEj = 24
    }
    public enum EnumServer
    {
        ESR,
        CIT,
        Opticash,
        OpticashDF
    }
    public enum EnumAlertType
    {
        Licensing = 1,
        DailyFeedUpload = 2,
        CashOrderDownload = 3,
        HardDiskFreeSpace = 4,
        TCPConnectionDown = 5,
        TCPConnectionUp = 6,
        CashOrderUploadFailed = 7,
        ConfigurationUploadFailed = 8,
        CashOrderField20Missing = 9,
        TerminalNotLicensed = 10,
        DenominationMissing = 11,
        ConfigurationMismatch = 12,
        ATMCashLevelFileDownloadFailed = 13,
        ATMFriendlyNameMissing = 14,
        CashOrderImportFailed = 15,
        CashOrderImportCompletedWithExceptions = 16,
        CPMThresholdReached = 17,
        BNAThresholdReached = 18,
        DFFSuspect = 19,
        MinOperatingBalance = 20,
        ATMOutOfCash = 21,
        PurgeBinThresholdReached = 22,
        ATMCounterMismatch = 23,
        ATMCounterExploded = 24,
        OrderBelowThreshold = 25,
        ReplenishmentAtATM = 26,
        SuspiciousReplenishment = 27,
        ATMResidualMismatch = 28,
        ATMCounterClearedOrMachineReinstalled = 29,
        SummaryDataRegenerated = 30,
        ATMInactivityPeriodElapsed = 31,
        ATMCassetteFaulty = 32,
        ATMFileParsingFailed = 33,
        DuplicateOrder = 34,
        CounterDiscrepency = 35,
        CassetteDispensingFailed = 36,
        AddCashReplenishmentDetected = 37,
        BNAInactivityPeriodElapsed = 38,
        ChequeInactivityPeriodElapsed = 39,
        ATMEJInactivityPeriodElapsed = 40,
        VaultLowBalanceThresholdReached = 41,
        initEJExecutionFailure = 42,
        CCMSAgentDead = 43,
        CCMSServiceManagerDead = 44,
        ATMDead = 45,
        Type1MinNotesThresholdReached = 46,
        Type2MinNotesThresholdReached = 47,
        Type3MinNotesThresholdReached = 48,
        Type4MinNotesThresholdReached = 49,
        ReplenishmentReminderToCIT = 63,
        IMAlert = 64,
        EJCustomTransactionsAlert = 65,
        Base24MessageAlert = 66,
        TMDAlert = 67,
        MachineDownBeyondNHours = 68,
        ATMCleaning = 69,
        CCTV = 70,
        Type5MinNotesThresholdReached = 71,
    }

    public enum TransactionStatus
    {
        Successful = 0,
        Failed,
        Suspicious
    }

    public enum EnumFileType
    {
        Counters = 1,
        EJData = 2,
        EJBackup = 19
    }
}