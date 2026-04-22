namespace EView360Models.ViewModels
{
    public class AtmTaskViewModel
    {
        public int RowCount { get; set; }
        public int DataFileCount { get; set; }
        public int DataFileCount2 { get; set; }
        public long TaskId { get; set; }
        public bool? Parsed { get; set; }

        public int BytesTransferred { get; set; }

        public long AtmId { get; set; }

        public string? AtmIP { get; set; }
        public string? AtmTitle { get; set; }

        public string? Location { get; set; }

        public string? AtmType { get; set; }

        public long? FileTypeId { get; set; }

        public string? FileTypeTitle { get; set; }
        public DateTime CreationTime { get; set; }

        public string? UserName { get; set; }

        public DateTime? DownloadTime { get; set; }

        public DateTime? UploadTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Status { get; set; } = null!;

        public int? ZippedFileSize { get; set; }

        public int CreatedBy { get; set; }

        public int? UnZippedFileSize { get; set; }

        public DateTime? LastInvoked { get; set; }

        public int RetryRemaining { get; set; }

        public string? FailureReason { get; set; }
        public string? FailureReasonFull { get; set; }

        public string? ServerFilepath { get; set; }

        public long TaskTypeId { get; set; }

        public int? CashOrderId { get; set; }

        public int? DownloadingScheduleId { get; set; }

        public int? FailedToParseCount { get; set; }

        public string? ArchiveFilePathAtAtm { get; set; }

        public string? TaskInfo { get; set; }
        public string? TaskTypeName { get; set; }

        public bool? IsExported { get; set; }

        public string? EncodedCashDataFile { get; set; }
        public string? DecodedCashDataFile { get; set; }

        public bool TaskExist { get; set; }

        public List<string>? allAtmId { get; set; }
    }
}
