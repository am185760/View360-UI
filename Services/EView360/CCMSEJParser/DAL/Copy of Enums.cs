
namespace Avanza.CCMS.DAL
{
    public enum UploadStates
    {
        scheduled,
        initiating,
        uploading,
        uploadingDisconnected,
        resumedUploading,
        cancelled,
        cancelledOrderExpired,
        completed,
        unknownError,
        retriesExhausted,
        cashOrderSuspended
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
    }
    public enum FTPDownloadStatus
    {
        scheduled,
        failed,
        completed,
        downloaded,
        downloadedImportFailed

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
        CashDataDownload=1,
        DailyFeedUpload=2,
        CashOrderDownload=3,
        CashOrderUpload=4,
        Configuration=5,
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
        LicenseThreshold=1,
        Configuration=2,
        CashOrderDownload=3,
        DailyFeedUpload=4,
        HardDiskSpaceThreshold=5,
        CashOrderUpload=6,

    }
}