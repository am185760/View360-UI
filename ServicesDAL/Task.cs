using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesDAL
{
    [Serializable()]
    public class Task
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Task() { }
        //public Task(DatabaseName databaseName) { }
        public Task(long task_id, int bytes_transferred, long aTM_id, DateTime creation_time, string status, long created_by, byte retry_Remaining, long task_type_id)
        {
            this.bytes_transferred = bytes_transferred;
            this.bytes_transferredChanged = true;
            this.aTM_id = aTM_id;
            this.aTM_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.retry_Remaining = retry_Remaining;
            this.retry_RemainingChanged = true;
            this.task_type_id = task_type_id;
            this.task_type_idChanged = true;
        }
        public Task(bool? parsed, int bytes_transferred, string file_path_at_ATM, long aTM_id, long? file_type_id, DateTime creation_time, DateTime? download_time, DateTime? upload_time, DateTime? end_time, string status, int? zipped_file_size, long created_by, int? unZipped_file_size, DateTime? last_invoked, byte retry_Remaining, string failure_reason, string server_filepath, long task_type_id, long? cash_order_id, long? downloading_schedule_id, int? failed_to_parse_count, string archive_file_path_at_atm, string task_info)
        {
            this.parsed = parsed;
            this.parsedChanged = true;
            this.bytes_transferred = bytes_transferred;
            this.bytes_transferredChanged = true;
            this.file_path_at_ATM = file_path_at_ATM;
            this.file_path_at_ATMChanged = true;
            this.aTM_id = aTM_id;
            this.aTM_idChanged = true;
            this.file_type_id = file_type_id;
            this.file_type_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.download_time = download_time;
            this.download_timeChanged = true;
            this.upload_time = upload_time;
            this.upload_timeChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.zipped_file_size = zipped_file_size;
            this.zipped_file_sizeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.unZipped_file_size = unZipped_file_size;
            this.unZipped_file_sizeChanged = true;
            this.last_invoked = last_invoked;
            this.last_invokedChanged = true;
            this.retry_Remaining = retry_Remaining;
            this.retry_RemainingChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.server_filepath = server_filepath;
            this.server_filepathChanged = true;
            this.task_type_id = task_type_id;
            this.task_type_idChanged = true;
            this.cash_order_id = cash_order_id;
            this.cash_order_idChanged = true;
            this.downloading_schedule_id = downloading_schedule_id;
            this.downloading_schedule_idChanged = true;
            this.failed_to_parse_count = failed_to_parse_count;
            this.failed_to_parse_countChanged = true;
            this.archive_file_path_at_atm = archive_file_path_at_atm;
            this.archive_file_path_at_atmChanged = true;
            this.task_info = task_info;
            this.task_infoChanged = true;
        }
        private Task(long task_id, bool? parsed, int bytes_transferred, string file_path_at_ATM, long aTM_id, long? file_type_id, DateTime creation_time, DateTime? download_time, DateTime? upload_time, DateTime? end_time, string status, int? zipped_file_size, long created_by, int? unZipped_file_size, DateTime? last_invoked, byte retry_Remaining, string failure_reason, string server_filepath, long task_type_id, long? cash_order_id, long? downloading_schedule_id, int? failed_to_parse_count, string archive_file_path_at_atm, string task_info)
        {
            this.task_id = task_id;
            this.task_idChanged = true;
            this.parsed = parsed;
            this.parsedChanged = true;
            this.bytes_transferred = bytes_transferred;
            this.bytes_transferredChanged = true;
            this.file_path_at_ATM = file_path_at_ATM;
            this.file_path_at_ATMChanged = true;
            this.aTM_id = aTM_id;
            this.aTM_idChanged = true;
            this.file_type_id = file_type_id;
            this.file_type_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.download_time = download_time;
            this.download_timeChanged = true;
            this.upload_time = upload_time;
            this.upload_timeChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.zipped_file_size = zipped_file_size;
            this.zipped_file_sizeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.unZipped_file_size = unZipped_file_size;
            this.unZipped_file_sizeChanged = true;
            this.last_invoked = last_invoked;
            this.last_invokedChanged = true;
            this.retry_Remaining = retry_Remaining;
            this.retry_RemainingChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.server_filepath = server_filepath;
            this.server_filepathChanged = true;
            this.task_type_id = task_type_id;
            this.task_type_idChanged = true;
            this.cash_order_id = cash_order_id;
            this.cash_order_idChanged = true;
            this.downloading_schedule_id = downloading_schedule_id;
            this.downloading_schedule_idChanged = true;
            this.failed_to_parse_count = failed_to_parse_count;
            this.failed_to_parse_countChanged = true;
            this.archive_file_path_at_atm = archive_file_path_at_atm;
            this.archive_file_path_at_atmChanged = true;
            this.task_info = task_info;
            this.task_infoChanged = true;
        }

        #region members and properties for columns

        #region TaskId
        private bool task_idChanged = false;
        private long task_id;
        public long TaskId
        {
            get { return task_id; }
            set
            {
                task_id = value;
                task_idChanged = true;
            }
        }
        private string task_idDbString
        {
            get
            {
                return task_id.ToString();
            }
        }
        #endregion
        #region Parsed
        private bool parsedChanged = false;
        private bool? parsed;
        public bool? Parsed
        {
            get { return parsed; }
            set
            {
                parsed = value;
                parsedChanged = true;
            }
        }
        private string parsedDbString
        {
            get
            {
                if (this.parsed.HasValue)
                    return parsed.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region BytesTransferred
        private bool bytes_transferredChanged = false;
        private int bytes_transferred;
        public int BytesTransferred
        {
            get { return bytes_transferred; }
            set
            {
                bytes_transferred = value;
                bytes_transferredChanged = true;
            }
        }
        private string bytes_transferredDbString
        {
            get
            {
                return bytes_transferred.ToString();
            }
        }
        #endregion
        #region FilePathAtATM
        private bool file_path_at_ATMChanged = false;
        private string file_path_at_ATM;
        public string FilePathAtATM
        {
            get { return file_path_at_ATM; }
            set
            {
                file_path_at_ATM = value;
                file_path_at_ATMChanged = true;
            }
        }
        private string file_path_at_ATMDbString
        {
            get
            {
                if (this.file_path_at_ATM != null)
                    return string.Format("'{0}'", file_path_at_ATM);
                else
                    return "null";
            }
        }
        #endregion
        #region ATMId
        private bool aTM_idChanged = false;
        private long aTM_id;
        public long ATMId
        {
            get { return aTM_id; }
            set
            {
                aTM_id = value;
                aTM_idChanged = true;
            }
        }
        private string aTM_idDbString
        {
            get
            {
                return aTM_id.ToString();
            }
        }
        #endregion
        #region FileTypeId
        private bool file_type_idChanged = false;
        private long? file_type_id;
        public long? FileTypeId
        {
            get { return file_type_id; }
            set
            {
                file_type_id = value;
                file_type_idChanged = true;
            }
        }
        private string file_type_idDbString
        {
            get
            {
                if (this.file_type_id.HasValue)
                    return file_type_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CreationTime
        private bool creation_timeChanged = false;
        private DateTime creation_time;
        public DateTime CreationTime
        {
            get { return creation_time; }
            set
            {
                creation_time = value;
                creation_timeChanged = true;
            }
        }
        private string creation_timeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region DownloadTime
        private bool download_timeChanged = false;
        private DateTime? download_time;
        public DateTime? DownloadTime
        {
            get { return download_time; }
            set
            {
                download_time = value;
                download_timeChanged = true;
            }
        }
        private string download_timeDbString
        {
            get
            {
                if (this.download_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", download_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region UploadTime
        private bool upload_timeChanged = false;
        private DateTime? upload_time;
        public DateTime? UploadTime
        {
            get { return upload_time; }
            set
            {
                upload_time = value;
                upload_timeChanged = true;
            }
        }
        private string upload_timeDbString
        {
            get
            {
                if (this.upload_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", upload_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region EndTime
        private bool end_timeChanged = false;
        private DateTime? end_time;
        public DateTime? EndTime
        {
            get { return end_time; }
            set
            {
                end_time = value;
                end_timeChanged = true;
            }
        }
        private string end_timeDbString
        {
            get
            {
                if (this.end_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", end_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Status
        private bool statusChanged = false;
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                statusChanged = true;
            }
        }
        private string statusDbString
        {
            get
            {
                if (this.status != null)
                    return string.Format("'{0}'", status);
                else
                    return "null";
            }
        }
        #endregion
        #region ZippedFileSize
        private bool zipped_file_sizeChanged = false;
        private int? zipped_file_size;
        public int? ZippedFileSize
        {
            get { return zipped_file_size; }
            set
            {
                zipped_file_size = value;
                zipped_file_sizeChanged = true;
            }
        }
        private string zipped_file_sizeDbString
        {
            get
            {
                if (this.zipped_file_size.HasValue)
                    return zipped_file_size.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private long created_by;
        public long CreatedBy
        {
            get { return created_by; }
            set
            {
                created_by = value;
                created_byChanged = true;
            }
        }
        private string created_byDbString
        {
            get
            {
                return created_by.ToString();
            }
        }
        #endregion
        #region UnZippedFileSize
        private bool unZipped_file_sizeChanged = false;
        private int? unZipped_file_size;
        public int? UnZippedFileSize
        {
            get { return unZipped_file_size; }
            set
            {
                unZipped_file_size = value;
                unZipped_file_sizeChanged = true;
            }
        }
        private string unZipped_file_sizeDbString
        {
            get
            {
                if (this.unZipped_file_size.HasValue)
                    return unZipped_file_size.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region LastInvoked
        private bool last_invokedChanged = false;
        private DateTime? last_invoked;
        public DateTime? LastInvoked
        {
            get { return last_invoked; }
            set
            {
                last_invoked = value;
                last_invokedChanged = true;
            }
        }
        private string last_invokedDbString
        {
            get
            {
                if (this.last_invoked.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_invoked.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region RetryRemaining
        private bool retry_RemainingChanged = false;
        private byte retry_Remaining;
        public byte RetryRemaining
        {
            get { return retry_Remaining; }
            set
            {
                retry_Remaining = value;
                retry_RemainingChanged = true;
            }
        }
        private string retry_RemainingDbString
        {
            get
            {
                return retry_Remaining.ToString();
            }
        }
        #endregion
        #region FailureReason
        private bool failure_reasonChanged = false;
        private string failure_reason;
        public string FailureReason
        {
            get { return failure_reason; }
            set
            {
                failure_reason = value;
                failure_reasonChanged = true;
            }
        }
        private string failure_reasonDbString
        {
            get
            {
                if (this.failure_reason != null)
                    return string.Format("'{0}'", failure_reason);
                else
                    return "null";
            }
        }
        #endregion
        #region ServerFilepath
        private bool server_filepathChanged = false;
        private string server_filepath;
        public string ServerFilepath
        {
            get { return server_filepath; }
            set
            {
                server_filepath = value;
                server_filepathChanged = true;
            }
        }
        private string server_filepathDbString
        {
            get
            {
                if (this.server_filepath != null)
                    return string.Format("'{0}'", server_filepath);
                else
                    return "null";
            }
        }
        #endregion
        #region TaskTypeId
        private bool task_type_idChanged = false;
        private long task_type_id;
        public long TaskTypeId
        {
            get { return task_type_id; }
            set
            {
                task_type_id = value;
                task_type_idChanged = true;
            }
        }
        private string task_type_idDbString
        {
            get
            {
                return task_type_id.ToString();
            }
        }
        #endregion
        #region CashOrderId
        private bool cash_order_idChanged = false;
        private long? cash_order_id;
        public long? CashOrderId
        {
            get { return cash_order_id; }
            set
            {
                cash_order_id = value;
                cash_order_idChanged = true;
            }
        }
        private string cash_order_idDbString
        {
            get
            {
                if (this.cash_order_id.HasValue)
                    return cash_order_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DownloadingScheduleId
        private bool downloading_schedule_idChanged = false;
        private long? downloading_schedule_id;
        public long? DownloadingScheduleId
        {
            get { return downloading_schedule_id; }
            set
            {
                downloading_schedule_id = value;
                downloading_schedule_idChanged = true;
            }
        }
        private string downloading_schedule_idDbString
        {
            get
            {
                if (this.downloading_schedule_id.HasValue)
                    return downloading_schedule_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region FailedToParseCount
        private bool failed_to_parse_countChanged = false;
        private int? failed_to_parse_count;
        public int? FailedToParseCount
        {
            get { return failed_to_parse_count; }
            set
            {
                failed_to_parse_count = value;
                failed_to_parse_countChanged = true;
            }
        }
        private string failed_to_parse_countDbString
        {
            get
            {
                if (this.failed_to_parse_count.HasValue)
                    return failed_to_parse_count.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ArchiveFilePathAtAtm
        private bool archive_file_path_at_atmChanged = false;
        private string archive_file_path_at_atm;
        public string ArchiveFilePathAtAtm
        {
            get { return archive_file_path_at_atm; }
            set
            {
                archive_file_path_at_atm = value;
                archive_file_path_at_atmChanged = true;
            }
        }
        private string archive_file_path_at_atmDbString
        {
            get
            {
                if (this.archive_file_path_at_atm != null)
                    return string.Format("'{0}'", archive_file_path_at_atm);
                else
                    return "null";
            }
        }
        #endregion
        #region TaskInfo
        private bool task_infoChanged = false;
        private string task_info;
        public string TaskInfo
        {
            get { return task_info; }
            set
            {
                task_info = value;
                task_infoChanged = true;
            }
        }
        private string task_infoDbString
        {
            get
            {
                if (this.task_info != null)
                    return string.Format("'{0}'", task_info);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region TaskReader
        public class TaskReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Task currentTask;
            Columns columns;
            bool partialRead = false;
            private TaskReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public TaskReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public TaskReader(IDataReader reader, IDbConnection conn, Columns columns)
            {
                this.reader = reader;
                this.conn = conn;
                this.columns = columns;
                partialRead = true;
            }

            public bool IsClosed
            {
                get { return reader.IsClosed; }
            }
            public int Depth
            {
                get { return reader.Depth; }
            }
            public int FieldCount
            {
                get { return reader.FieldCount; }
            }

            public object Current
            {
                get { return currentTask; }

            }
            public void Close()
            {
                reader.Close();
                conn.Close();
            }
            public void Close(bool closeConnection)
            {
                reader.Close();
                if (closeConnection)
                    conn.Close();
            }

            public bool Read()
            {
                if (reader.Read())
                {
                    currentTask = new Task();
                    if (partialRead)
                    {
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentTask.task_id = (long)reader["task_id"];
                        if ((columns & Columns.parsed) == Columns.parsed && reader["parsed"] != DBNull.Value)
                            currentTask.parsed = (bool?)reader["parsed"];
                        if ((columns & Columns.bytes_transferred) == Columns.bytes_transferred && reader["bytes_transferred"] != DBNull.Value)
                            currentTask.bytes_transferred = (int)reader["bytes_transferred"];
                        if ((columns & Columns.file_path_at_ATM) == Columns.file_path_at_ATM && reader["file_path_at_ATM"] != DBNull.Value)
                            currentTask.file_path_at_ATM = (string)reader["file_path_at_ATM"];
                        if ((columns & Columns.ATM_id) == Columns.ATM_id && reader["ATM_id"] != DBNull.Value)
                            currentTask.aTM_id = (long)reader["ATM_id"];
                        if ((columns & Columns.file_type_id) == Columns.file_type_id && reader["file_type_id"] != DBNull.Value)
                            currentTask.file_type_id = (long?)reader["file_type_id"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentTask.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.download_time) == Columns.download_time && reader["download_time"] != DBNull.Value)
                            currentTask.download_time = (DateTime?)reader["download_time"];
                        if ((columns & Columns.upload_time) == Columns.upload_time && reader["upload_time"] != DBNull.Value)
                            currentTask.upload_time = (DateTime?)reader["upload_time"];
                        if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"] != DBNull.Value)
                            currentTask.end_time = (DateTime?)reader["end_time"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentTask.status = (string)reader["status"];
                        if ((columns & Columns.zipped_file_size) == Columns.zipped_file_size && reader["zipped_file_size"] != DBNull.Value)
                            currentTask.zipped_file_size = (int?)reader["zipped_file_size"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentTask.created_by = (long)reader["created_by"];
                        if ((columns & Columns.unZipped_file_size) == Columns.unZipped_file_size && reader["unZipped_file_size"] != DBNull.Value)
                            currentTask.unZipped_file_size = (int?)reader["unZipped_file_size"];
                        if ((columns & Columns.last_invoked) == Columns.last_invoked && reader["last_invoked"] != DBNull.Value)
                            currentTask.last_invoked = (DateTime?)reader["last_invoked"];
                        if ((columns & Columns.retry_Remaining) == Columns.retry_Remaining && reader["retry_Remaining"] != DBNull.Value)
                            currentTask.retry_Remaining = (byte)reader["retry_Remaining"];
                        if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"] != DBNull.Value)
                            currentTask.failure_reason = (string)reader["failure_reason"];
                        if ((columns & Columns.server_filepath) == Columns.server_filepath && reader["server_filepath"] != DBNull.Value)
                            currentTask.server_filepath = (string)reader["server_filepath"];
                        if ((columns & Columns.task_type_id) == Columns.task_type_id && reader["task_type_id"] != DBNull.Value)
                            currentTask.task_type_id = (long)reader["task_type_id"];
                        if ((columns & Columns.cash_order_id) == Columns.cash_order_id && reader["cash_order_id"] != DBNull.Value)
                            currentTask.cash_order_id = (long?)reader["cash_order_id"];
                        if ((columns & Columns.downloading_schedule_id) == Columns.downloading_schedule_id && reader["downloading_schedule_id"] != DBNull.Value)
                            currentTask.downloading_schedule_id = (long?)reader["downloading_schedule_id"];
                        if ((columns & Columns.failed_to_parse_count) == Columns.failed_to_parse_count && reader["failed_to_parse_count"] != DBNull.Value)
                            currentTask.failed_to_parse_count = (int?)reader["failed_to_parse_count"];
                        if ((columns & Columns.archive_file_path_at_atm) == Columns.archive_file_path_at_atm && reader["archive_file_path_at_atm"] != DBNull.Value)
                            currentTask.archive_file_path_at_atm = (string)reader["archive_file_path_at_atm"];
                        if ((columns & Columns.task_info) == Columns.task_info && reader["task_info"] != DBNull.Value)
                            currentTask.task_info = (string)reader["task_info"];

                    }
                    else
                    {
                        if (reader["task_id"] != DBNull.Value)
                            currentTask.task_id = (long)reader["task_id"];
                        if (reader["parsed"] != DBNull.Value)
                            currentTask.parsed = (bool?)reader["parsed"];
                        if (reader["bytes_transferred"] != DBNull.Value)
                            currentTask.bytes_transferred = (int)reader["bytes_transferred"];
                        if (reader["file_path_at_ATM"] != DBNull.Value)
                            currentTask.file_path_at_ATM = (string)reader["file_path_at_ATM"];
                        if (reader["ATM_id"] != DBNull.Value)
                            currentTask.aTM_id = (long)reader["ATM_id"];
                        if (reader["file_type_id"] != DBNull.Value)
                            currentTask.file_type_id = (long?)reader["file_type_id"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentTask.creation_time = (DateTime)reader["creation_time"];
                        if (reader["download_time"] != DBNull.Value)
                            currentTask.download_time = (DateTime?)reader["download_time"];
                        if (reader["upload_time"] != DBNull.Value)
                            currentTask.upload_time = (DateTime?)reader["upload_time"];
                        if (reader["end_time"] != DBNull.Value)
                            currentTask.end_time = (DateTime?)reader["end_time"];
                        if (reader["status"] != DBNull.Value)
                            currentTask.status = (string)reader["status"];
                        if (reader["zipped_file_size"] != DBNull.Value)
                            currentTask.zipped_file_size = (int?)reader["zipped_file_size"];
                        if (reader["created_by"] != DBNull.Value)
                            currentTask.created_by = (long)reader["created_by"];
                        if (reader["unZipped_file_size"] != DBNull.Value)
                            currentTask.unZipped_file_size = (int?)reader["unZipped_file_size"];
                        if (reader["last_invoked"] != DBNull.Value)
                            currentTask.last_invoked = (DateTime?)reader["last_invoked"];
                        if (reader["retry_Remaining"] != DBNull.Value)
                            currentTask.retry_Remaining = (byte)reader["retry_Remaining"];
                        if (reader["failure_reason"] != DBNull.Value)
                            currentTask.failure_reason = (string)reader["failure_reason"];
                        if (reader["server_filepath"] != DBNull.Value)
                            currentTask.server_filepath = (string)reader["server_filepath"];
                        if (reader["task_type_id"] != DBNull.Value)
                            currentTask.task_type_id = (long)reader["task_type_id"];
                        if (reader["cash_order_id"] != DBNull.Value)
                            currentTask.cash_order_id = (long?)reader["cash_order_id"];
                        if (reader["downloading_schedule_id"] != DBNull.Value)
                            currentTask.downloading_schedule_id = (long?)reader["downloading_schedule_id"];
                        if (reader["failed_to_parse_count"] != DBNull.Value)
                            currentTask.failed_to_parse_count = (int?)reader["failed_to_parse_count"];
                        if (reader["archive_file_path_at_atm"] != DBNull.Value)
                            currentTask.archive_file_path_at_atm = (string)reader["archive_file_path_at_atm"];
                        if (reader["task_info"] != DBNull.Value)
                            currentTask.task_info = (string)reader["task_info"];
                    }

                    currentTask.isNewEntity = false;
                    return true;
                }
                else
                    return false;
            }
            #region IEnumerable Members

            public IEnumerator GetEnumerator()
            {
                return this;
            }
            #endregion


            #region IEnumerator Members

            public Task CurrentTask
            {
                get { return currentTask; }
            }

            public bool MoveNext()
            {
                return Read();
            }

            public void Reset()
            {
                throw new Exception("The method is not implemented.");
            }

            #endregion
        }

        #endregion


        #region Task functions

        public static TaskReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.parsed == (Columns.parsed & columns))
                qry.Append("parsed,");
            if (Columns.bytes_transferred == (Columns.bytes_transferred & columns))
                qry.Append("bytes_transferred,");
            if (Columns.file_path_at_ATM == (Columns.file_path_at_ATM & columns))
                qry.Append("file_path_at_ATM,");
            if (Columns.ATM_id == (Columns.ATM_id & columns))
                qry.Append("ATM_id,");
            if (Columns.file_type_id == (Columns.file_type_id & columns))
                qry.Append("file_type_id,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.download_time == (Columns.download_time & columns))
                qry.Append("download_time,");
            if (Columns.upload_time == (Columns.upload_time & columns))
                qry.Append("upload_time,");
            if (Columns.end_time == (Columns.end_time & columns))
                qry.Append("end_time,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.zipped_file_size == (Columns.zipped_file_size & columns))
                qry.Append("zipped_file_size,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.unZipped_file_size == (Columns.unZipped_file_size & columns))
                qry.Append("unZipped_file_size,");
            if (Columns.last_invoked == (Columns.last_invoked & columns))
                qry.Append("last_invoked,");
            if (Columns.retry_Remaining == (Columns.retry_Remaining & columns))
                qry.Append("retry_Remaining,");
            if (Columns.failure_reason == (Columns.failure_reason & columns))
                qry.Append("failure_reason,");
            if (Columns.server_filepath == (Columns.server_filepath & columns))
                qry.Append("server_filepath,");
            if (Columns.task_type_id == (Columns.task_type_id & columns))
                qry.Append("task_type_id,");
            if (Columns.cash_order_id == (Columns.cash_order_id & columns))
                qry.Append("cash_order_id,");
            if (Columns.downloading_schedule_id == (Columns.downloading_schedule_id & columns))
                qry.Append("downloading_schedule_id,");
            if (Columns.failed_to_parse_count == (Columns.failed_to_parse_count & columns))
                qry.Append("failed_to_parse_count,");
            if (Columns.archive_file_path_at_atm == (Columns.archive_file_path_at_atm & columns))
                qry.Append("archive_file_path_at_atm,");
            if (Columns.task_info == (Columns.task_info & columns))
                qry.Append("task_info,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Task ");

            if (where != null && where.Trim().Length > 0)
            {
                qry.Append(" where ");
                qry.Append(where); ;
            }

            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = qry.ToString();
            return new TaskReader(cmd.ExecuteReader(), conn, columns);
        }

        static public TaskReader ExecuteReader(string where, Columns columns, DatabaseName databaseName)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(databaseName), columns);
        }

        public static TaskReader ExecuteReader(string where, IDbConnection conn)
        {
             if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select task_id,parsed,bytes_transferred,file_path_at_ATM,ATM_id,file_type_id,creation_time,download_time,upload_time,end_time,status,zipped_file_size,created_by,unZipped_file_size,last_invoked,retry_Remaining,failure_reason,server_filepath,task_type_id,cash_order_id,downloading_schedule_id,failed_to_parse_count,archive_file_path_at_atm,task_info from Task ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new TaskReader(cmd.ExecuteReader(), conn);
        }

        static public TaskReader ExecuteReader(string where, DatabaseName databaseName)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(databaseName));
        }

        public static Task LoadTask(string where, DatabaseName databaseName)
        {
            TaskReader reader = Task.ExecuteReader(where, databaseName);
            Task _task = null;
            if (reader.Read())
                _task = reader.CurrentTask;
            reader.Close();
            return _task;
        }

        public static Task LoadTask(string where, IDbConnection conn)
        {
            TaskReader reader = Task.ExecuteReader(where, conn);
            Task _task = null;
            if (reader.Read())
                _task = reader.CurrentTask;
            reader.Close(false);
            return _task;
        }

        public static Task LoadTaskByPk(long task_id, DatabaseName databaseName)
        {
            return LoadTask("task_id=" + task_id, databaseName);
        }

        public static Task LoadTaskByPk(long task_id, IDbConnection conn)
        {
            return LoadTask(" task_id=" + task_id, conn);
        }

        public void Save(DatabaseName databaseName)
        {
            if (task_idChanged || parsedChanged || bytes_transferredChanged || file_path_at_ATMChanged || aTM_idChanged || file_type_idChanged || creation_timeChanged || download_timeChanged || upload_timeChanged || end_timeChanged || statusChanged || zipped_file_sizeChanged || created_byChanged || unZipped_file_sizeChanged || last_invokedChanged || retry_RemainingChanged || failure_reasonChanged || server_filepathChanged || task_type_idChanged || cash_order_idChanged || downloading_schedule_idChanged || failed_to_parse_countChanged || archive_file_path_at_atmChanged || task_infoChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(databaseName).CreateCommand(), databaseName);
        }

        public void Save(IDbConnection conn, IDbTransaction trx, DatabaseName databaseName)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.Transaction = trx;
            ExcuteSave(cmd, databaseName);
        }

        public void Save(IDbConnection conn, DatabaseName databaseName)
        {
            IDbCommand cmd = conn.CreateCommand();
            ExcuteSave(cmd, databaseName);
        }

        /// an opened connection
        private void ExcuteSave(IDbCommand cmd, DatabaseName databaseName)
        {
            if (task_idChanged || parsedChanged || bytes_transferredChanged || file_path_at_ATMChanged || aTM_idChanged || file_type_idChanged || creation_timeChanged || download_timeChanged || upload_timeChanged || end_timeChanged || statusChanged || zipped_file_sizeChanged || created_byChanged || unZipped_file_sizeChanged || last_invokedChanged || retry_RemainingChanged || failure_reasonChanged || server_filepathChanged || task_type_idChanged || cash_order_idChanged || downloading_schedule_idChanged || failed_to_parse_countChanged || archive_file_path_at_atmChanged || task_infoChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Task(task_id,parsed,bytes_transferred,file_path_at_ATM,ATM_id,file_type_id,creation_time,download_time,upload_time,end_time,status,zipped_file_size,created_by,unZipped_file_size,last_invoked,retry_Remaining,failure_reason,server_filepath,task_type_id,cash_order_id,downloading_schedule_id,failed_to_parse_count,archive_file_path_at_atm,task_info) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.task_id = ConnectionFactory.GetNextId(databaseName);
                        qry.Append(this.task_id);
                    }
                    qry.Append(",");
                    qry.Append(parsedDbString + ",");
                    qry.Append(bytes_transferredDbString + ",");
                    qry.Append(file_path_at_ATMDbString + ",");
                    qry.Append(aTM_idDbString + ",");
                    qry.Append(file_type_idDbString + ",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(download_timeDbString + ",");
                    qry.Append(upload_timeDbString + ",");
                    qry.Append(end_timeDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(zipped_file_sizeDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(unZipped_file_sizeDbString + ",");
                    qry.Append(last_invokedDbString + ",");
                    qry.Append(retry_RemainingDbString + ",");
                    qry.Append(failure_reasonDbString + ",");
                    qry.Append(server_filepathDbString + ",");
                    qry.Append(task_type_idDbString + ",");
                    qry.Append(cash_order_idDbString + ",");
                    qry.Append(downloading_schedule_idDbString + ",");
                    qry.Append(failed_to_parse_countDbString + ",");
                    qry.Append(archive_file_path_at_atmDbString + ",");
                    qry.Append(task_infoDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(task_idChanged || parsedChanged || bytes_transferredChanged || file_path_at_ATMChanged || aTM_idChanged || file_type_idChanged || creation_timeChanged || download_timeChanged || upload_timeChanged || end_timeChanged || statusChanged || zipped_file_sizeChanged || created_byChanged || unZipped_file_sizeChanged || last_invokedChanged || retry_RemainingChanged || failure_reasonChanged || server_filepathChanged || task_type_idChanged || cash_order_idChanged || downloading_schedule_idChanged || failed_to_parse_countChanged || archive_file_path_at_atmChanged || task_infoChanged))
                        return;
                    qry.Append("UPDATE Task set "); if (parsedChanged)
                    {
                        qry.Append("parsed =" + parsedDbString);
                        qry.Append(",");
                    }

                    if (bytes_transferredChanged)
                    {
                        qry.Append("bytes_transferred =" + bytes_transferredDbString);
                        qry.Append(",");
                    }

                    if (file_path_at_ATMChanged)
                    {
                        qry.Append("file_path_at_ATM =" + file_path_at_ATMDbString);
                        qry.Append(",");
                    }

                    if (aTM_idChanged)
                    {
                        qry.Append("ATM_id =" + aTM_idDbString);
                        qry.Append(",");
                    }

                    if (file_type_idChanged)
                    {
                        qry.Append("file_type_id =" + file_type_idDbString);
                        qry.Append(",");
                    }

                    if (download_timeChanged)
                    {
                        qry.Append("download_time =" + download_timeDbString);
                        qry.Append(",");
                    }

                    if (upload_timeChanged)
                    {
                        qry.Append("upload_time =" + upload_timeDbString);
                        qry.Append(",");
                    }

                    if (end_timeChanged)
                    {
                        qry.Append("end_time =" + end_timeDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (zipped_file_sizeChanged)
                    {
                        qry.Append("zipped_file_size =" + zipped_file_sizeDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (unZipped_file_sizeChanged)
                    {
                        qry.Append("unZipped_file_size =" + unZipped_file_sizeDbString);
                        qry.Append(",");
                    }

                    if (last_invokedChanged)
                    {
                        qry.Append("last_invoked =" + last_invokedDbString);
                        qry.Append(",");
                    }

                    if (retry_RemainingChanged)
                    {
                        qry.Append("retry_Remaining =" + retry_RemainingDbString);
                        qry.Append(",");
                    }

                    if (failure_reasonChanged)
                    {
                        qry.Append("failure_reason =" + failure_reasonDbString);
                        qry.Append(",");
                    }

                    if (server_filepathChanged)
                    {
                        qry.Append("server_filepath =" + server_filepathDbString);
                        qry.Append(",");
                    }

                    if (task_type_idChanged)
                    {
                        qry.Append("task_type_id =" + task_type_idDbString);
                        qry.Append(",");
                    }

                    if (cash_order_idChanged)
                    {
                        qry.Append("cash_order_id =" + cash_order_idDbString);
                        qry.Append(",");
                    }

                    if (downloading_schedule_idChanged)
                    {
                        qry.Append("downloading_schedule_id =" + downloading_schedule_idDbString);
                        qry.Append(",");
                    }

                    if (failed_to_parse_countChanged)
                    {
                        qry.Append("failed_to_parse_count =" + failed_to_parse_countDbString);
                        qry.Append(",");
                    }

                    if (archive_file_path_at_atmChanged)
                    {
                        qry.Append("archive_file_path_at_atm =" + archive_file_path_at_atmDbString);
                        qry.Append(",");
                    }

                    if (task_infoChanged)
                    {
                        qry.Append("task_info =" + task_infoDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("task_id = " + task_idDbString);
                    qry.Append(" and creation_time = " + creation_timeDbString);
                }

                cmd.CommandText = qry.ToString();
                bool closeConnection = false;
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                    closeConnection = true;
                }
                if (this.isNewEntity)
                {
                    cmd.ExecuteNonQuery();
                    isNewEntity = false;
                }
                else
                    cmd.ExecuteNonQuery();

                if (closeConnection)
                    cmd.Connection.Close();
            }
        }

        public void Delete(DatabaseName databaseName)
        {
            Delete(ConnectionFactory.GetNewConnection(databaseName));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Task wheretask_id= " + task_id + " and creation_time= " + creation_time;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteTasks(string where, DatabaseName databaseName)
        {
            ConnectionFactory.ExecuteQuery("delete Task where " + where, databaseName);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            task_id = 0,
            parsed = 1,
            bytes_transferred = 2,
            file_path_at_ATM = 3,
            ATM_id = 4,
            file_type_id = 5,
            creation_time = 6,
            download_time = 7,
            upload_time = 8,
            end_time = 9,
            status = 10,
            zipped_file_size = 11,
            created_by = 12,
            unZipped_file_size = 13,
            last_invoked = 14,
            retry_Remaining = 15,
            failure_reason = 16,
            server_filepath = 17,
            task_type_id = 18,
            cash_order_id = 19,
            downloading_schedule_id = 20,
            failed_to_parse_count = 21,
            archive_file_path_at_atm = 22,
            task_info = 23
        }
        #endregion
        public DataTable BulkSave(List<Task> dataArray, SqlTransaction dbTrx, DatabaseName databaseName)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt, databaseName);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Task";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Task.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Task> transList, ref DataTable dt, DatabaseName databaseName)
        {
            foreach (Task tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["task_id"] = ConnectionFactory.GetNextId(databaseName);
                Row["parsed"] = tran.Parsed;
                Row["bytes_transferred"] = tran.BytesTransferred;
                Row["file_path_at_ATM"] = tran.FilePathAtATM;
                Row["aTM_id"] = tran.ATMId;
                Row["file_type_id"] = tran.FileTypeId;
                Row["creation_time"] = tran.CreationTime;
                Row["download_time"] = tran.DownloadTime;
                Row["upload_time"] = tran.UploadTime;
                Row["end_time"] = tran.EndTime;
                Row["status"] = tran.Status;
                Row["zipped_file_size"] = tran.ZippedFileSize;
                Row["created_by"] = tran.CreatedBy;
                Row["unZipped_file_size"] = tran.UnZippedFileSize;
                Row["last_invoked"] = tran.LastInvoked;
                Row["retry_Remaining"] = tran.RetryRemaining;
                Row["failure_reason"] = tran.FailureReason;
                Row["server_filepath"] = tran.ServerFilepath;
                Row["task_type_id"] = tran.TaskTypeId;
                Row["cash_order_id"] = tran.CashOrderId;
                Row["downloading_schedule_id"] = tran.DownloadingScheduleId;
                Row["failed_to_parse_count"] = tran.FailedToParseCount;
                Row["archive_file_path_at_atm"] = tran.ArchiveFilePathAtAtm;
                Row["task_info"] = tran.TaskInfo;
                dt.Rows.Add(Row);
            }
        }
    }
}
