using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using Avanza.iSuite.DAL;

namespace Avanza.CCMS.DAL
{
    [Serializable()]
    public class ReconciliationBatch
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ReconciliationBatch() { }
        public ReconciliationBatch(int reconciliation_batch_id, DateTime creation_time, DateTime transaction_start_date, DateTime transaction_end_date, string status, int retry_count, int created_by, string acceptable_difference_type, int atm_id)
        {
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.transaction_start_date = transaction_start_date;
            this.transaction_start_dateChanged = true;
            this.transaction_end_date = transaction_end_date;
            this.transaction_end_dateChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.acceptable_difference_type = acceptable_difference_type;
            this.acceptable_difference_typeChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }
        public ReconciliationBatch(DateTime creation_time, DateTime transaction_start_date, DateTime transaction_end_date, decimal? acceptable_difference, string status, int? no_of_records_processed, int? no_of_records_reconciled, int? no_of_records_failed_to_reconciled, DateTime? last_invoked_at, string failure_reason, int retry_count, int created_by, DateTime? end_time, string batch_name, string batch_description, decimal? auto_reconciled_amount, decimal? manual_reconciled_amount, decimal? dropped_transaction_amount, string acceptable_difference_type, int atm_id)
        {
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.transaction_start_date = transaction_start_date;
            this.transaction_start_dateChanged = true;
            this.transaction_end_date = transaction_end_date;
            this.transaction_end_dateChanged = true;
            this.acceptable_difference = acceptable_difference;
            this.acceptable_differenceChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.no_of_records_processed = no_of_records_processed;
            this.no_of_records_processedChanged = true;
            this.no_of_records_reconciled = no_of_records_reconciled;
            this.no_of_records_reconciledChanged = true;
            this.no_of_records_failed_to_reconciled = no_of_records_failed_to_reconciled;
            this.no_of_records_failed_to_reconciledChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.batch_name = batch_name;
            this.batch_nameChanged = true;
            this.batch_description = batch_description;
            this.batch_descriptionChanged = true;
            this.auto_reconciled_amount = auto_reconciled_amount;
            this.auto_reconciled_amountChanged = true;
            this.manual_reconciled_amount = manual_reconciled_amount;
            this.manual_reconciled_amountChanged = true;
            this.dropped_transaction_amount = dropped_transaction_amount;
            this.dropped_transaction_amountChanged = true;
            this.acceptable_difference_type = acceptable_difference_type;
            this.acceptable_difference_typeChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }
        private ReconciliationBatch(int reconciliation_batch_id, DateTime creation_time, DateTime transaction_start_date, DateTime transaction_end_date, decimal? acceptable_difference, string status, int? no_of_records_processed, int? no_of_records_reconciled, int? no_of_records_failed_to_reconciled, DateTime? last_invoked_at, string failure_reason, int retry_count, int created_by, DateTime? end_time, string batch_name, string batch_description, decimal? auto_reconciled_amount, decimal? manual_reconciled_amount, decimal? dropped_transaction_amount, string acceptable_difference_type, int atm_id)
        {
            this.reconciliation_batch_id = reconciliation_batch_id;
            this.reconciliation_batch_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.transaction_start_date = transaction_start_date;
            this.transaction_start_dateChanged = true;
            this.transaction_end_date = transaction_end_date;
            this.transaction_end_dateChanged = true;
            this.acceptable_difference = acceptable_difference;
            this.acceptable_differenceChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.no_of_records_processed = no_of_records_processed;
            this.no_of_records_processedChanged = true;
            this.no_of_records_reconciled = no_of_records_reconciled;
            this.no_of_records_reconciledChanged = true;
            this.no_of_records_failed_to_reconciled = no_of_records_failed_to_reconciled;
            this.no_of_records_failed_to_reconciledChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.batch_name = batch_name;
            this.batch_nameChanged = true;
            this.batch_description = batch_description;
            this.batch_descriptionChanged = true;
            this.auto_reconciled_amount = auto_reconciled_amount;
            this.auto_reconciled_amountChanged = true;
            this.manual_reconciled_amount = manual_reconciled_amount;
            this.manual_reconciled_amountChanged = true;
            this.dropped_transaction_amount = dropped_transaction_amount;
            this.dropped_transaction_amountChanged = true;
            this.acceptable_difference_type = acceptable_difference_type;
            this.acceptable_difference_typeChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }

        #region members and properties for columns

        #region ReconciliationBatchId
        private bool reconciliation_batch_idChanged = false;
        private int reconciliation_batch_id;
        public int ReconciliationBatchId
        {
            get { return reconciliation_batch_id; }
            set
            {
                reconciliation_batch_id = value;
                reconciliation_batch_idChanged = true;
            }
        }
        private string reconciliation_batch_idDbString
        {
            get
            {
                return reconciliation_batch_id.ToString();
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
        #region TransactionStartDate
        private bool transaction_start_dateChanged = false;
        private DateTime transaction_start_date;
        public DateTime TransactionStartDate
        {
            get { return transaction_start_date; }
            set
            {
                transaction_start_date = value;
                transaction_start_dateChanged = true;
            }
        }
        private string transaction_start_dateDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", transaction_start_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region TransactionEndDate
        private bool transaction_end_dateChanged = false;
        private DateTime transaction_end_date;
        public DateTime TransactionEndDate
        {
            get { return transaction_end_date; }
            set
            {
                transaction_end_date = value;
                transaction_end_dateChanged = true;
            }
        }
        private string transaction_end_dateDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", transaction_end_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region AcceptableDifference
        private bool acceptable_differenceChanged = false;
        private decimal? acceptable_difference;
        public decimal? AcceptableDifference
        {
            get { return acceptable_difference; }
            set
            {
                acceptable_difference = value;
                acceptable_differenceChanged = true;
            }
        }
        private string acceptable_differenceDbString
        {
            get
            {
                if (this.acceptable_difference.HasValue)
                    return acceptable_difference.ToString();
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
        #region NoOfRecordsProcessed
        private bool no_of_records_processedChanged = false;
        private int? no_of_records_processed;
        public int? NoOfRecordsProcessed
        {
            get { return no_of_records_processed; }
            set
            {
                no_of_records_processed = value;
                no_of_records_processedChanged = true;
            }
        }
        private string no_of_records_processedDbString
        {
            get
            {
                if (this.no_of_records_processed.HasValue)
                    return no_of_records_processed.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NoOfRecordsReconciled
        private bool no_of_records_reconciledChanged = false;
        private int? no_of_records_reconciled;
        public int? NoOfRecordsReconciled
        {
            get { return no_of_records_reconciled; }
            set
            {
                no_of_records_reconciled = value;
                no_of_records_reconciledChanged = true;
            }
        }
        private string no_of_records_reconciledDbString
        {
            get
            {
                if (this.no_of_records_reconciled.HasValue)
                    return no_of_records_reconciled.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NoOfRecordsFailedToReconciled
        private bool no_of_records_failed_to_reconciledChanged = false;
        private int? no_of_records_failed_to_reconciled;
        public int? NoOfRecordsFailedToReconciled
        {
            get { return no_of_records_failed_to_reconciled; }
            set
            {
                no_of_records_failed_to_reconciled = value;
                no_of_records_failed_to_reconciledChanged = true;
            }
        }
        private string no_of_records_failed_to_reconciledDbString
        {
            get
            {
                if (this.no_of_records_failed_to_reconciled.HasValue)
                    return no_of_records_failed_to_reconciled.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region LastInvokedAt
        private bool last_invoked_atChanged = false;
        private DateTime? last_invoked_at;
        public DateTime? LastInvokedAt
        {
            get { return last_invoked_at; }
            set
            {
                last_invoked_at = value;
                last_invoked_atChanged = true;
            }
        }
        private string last_invoked_atDbString
        {
            get
            {
                if (this.last_invoked_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_invoked_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
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
        #region RetryCount
        private bool retry_countChanged = false;
        private int retry_count;
        public int RetryCount
        {
            get { return retry_count; }
            set
            {
                retry_count = value;
                retry_countChanged = true;
            }
        }
        private string retry_countDbString
        {
            get
            {
                return retry_count.ToString();
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private int created_by;
        public int CreatedBy
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
        #region BatchName
        private bool batch_nameChanged = false;
        private string batch_name;
        public string BatchName
        {
            get { return batch_name; }
            set
            {
                batch_name = value;
                batch_nameChanged = true;
            }
        }
        private string batch_nameDbString
        {
            get
            {
                if (this.batch_name != null)
                    return string.Format("'{0}'", batch_name);
                else
                    return "null";
            }
        }
        #endregion
        #region BatchDescription
        private bool batch_descriptionChanged = false;
        private string batch_description;
        public string BatchDescription
        {
            get { return batch_description; }
            set
            {
                batch_description = value;
                batch_descriptionChanged = true;
            }
        }
        private string batch_descriptionDbString
        {
            get
            {
                if (this.batch_description != null)
                    return string.Format("'{0}'", batch_description);
                else
                    return "null";
            }
        }
        #endregion
        #region AutoReconciledAmount
        private bool auto_reconciled_amountChanged = false;
        private decimal? auto_reconciled_amount;
        public decimal? AutoReconciledAmount
        {
            get { return auto_reconciled_amount; }
            set
            {
                auto_reconciled_amount = value;
                auto_reconciled_amountChanged = true;
            }
        }
        private string auto_reconciled_amountDbString
        {
            get
            {
                if (this.auto_reconciled_amount.HasValue)
                    return auto_reconciled_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ManualReconciledAmount
        private bool manual_reconciled_amountChanged = false;
        private decimal? manual_reconciled_amount;
        public decimal? ManualReconciledAmount
        {
            get { return manual_reconciled_amount; }
            set
            {
                manual_reconciled_amount = value;
                manual_reconciled_amountChanged = true;
            }
        }
        private string manual_reconciled_amountDbString
        {
            get
            {
                if (this.manual_reconciled_amount.HasValue)
                    return manual_reconciled_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DroppedTransactionAmount
        private bool dropped_transaction_amountChanged = false;
        private decimal? dropped_transaction_amount;
        public decimal? DroppedTransactionAmount
        {
            get { return dropped_transaction_amount; }
            set
            {
                dropped_transaction_amount = value;
                dropped_transaction_amountChanged = true;
            }
        }
        private string dropped_transaction_amountDbString
        {
            get
            {
                if (this.dropped_transaction_amount.HasValue)
                    return dropped_transaction_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AcceptableDifferenceType
        private bool acceptable_difference_typeChanged = false;
        private string acceptable_difference_type;
        public string AcceptableDifferenceType
        {
            get { return acceptable_difference_type; }
            set
            {
                acceptable_difference_type = value;
                acceptable_difference_typeChanged = true;
            }
        }
        private string acceptable_difference_typeDbString
        {
            get
            {
                if (this.acceptable_difference_type != null)
                    return string.Format("'{0}'", acceptable_difference_type);
                else
                    return "null";
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private int atm_id;
        public int AtmId
        {
            get { return atm_id; }
            set
            {
                atm_id = value;
                atm_idChanged = true;
            }
        }
        private string atm_idDbString
        {
            get
            {
                return atm_id.ToString();
            }
        }
        #endregion
        #endregion

        #region ReconciliationBatchReader
        public class ReconciliationBatchReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ReconciliationBatch currentReconciliationBatch;
            Columns columns;
            bool partialRead = false;
            private ReconciliationBatchReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ReconciliationBatchReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ReconciliationBatchReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentReconciliationBatch; }

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
                    currentReconciliationBatch = new ReconciliationBatch();
                    if (partialRead)
                    {
                        if ((columns & Columns.reconciliation_batch_id) == Columns.reconciliation_batch_id && reader["reconciliation_batch_id"] != DBNull.Value)
                            currentReconciliationBatch.reconciliation_batch_id = (int)reader["reconciliation_batch_id"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentReconciliationBatch.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.transaction_start_date) == Columns.transaction_start_date && reader["transaction_start_date"] != DBNull.Value)
                            currentReconciliationBatch.transaction_start_date = (DateTime)reader["transaction_start_date"];
                        if ((columns & Columns.transaction_end_date) == Columns.transaction_end_date && reader["transaction_end_date"] != DBNull.Value)
                            currentReconciliationBatch.transaction_end_date = (DateTime)reader["transaction_end_date"];
                        if ((columns & Columns.acceptable_difference) == Columns.acceptable_difference && reader["acceptable_difference"] != DBNull.Value)
                            currentReconciliationBatch.acceptable_difference = (decimal?)reader["acceptable_difference"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentReconciliationBatch.status = (string)reader["status"];
                        if ((columns & Columns.no_of_records_processed) == Columns.no_of_records_processed && reader["no_of_records_processed"] != DBNull.Value)
                            currentReconciliationBatch.no_of_records_processed = (int?)reader["no_of_records_processed"];
                        if ((columns & Columns.no_of_records_reconciled) == Columns.no_of_records_reconciled && reader["no_of_records_reconciled"] != DBNull.Value)
                            currentReconciliationBatch.no_of_records_reconciled = (int?)reader["no_of_records_reconciled"];
                        if ((columns & Columns.no_of_records_failed_to_reconciled) == Columns.no_of_records_failed_to_reconciled && reader["no_of_records_failed_to_reconciled"] != DBNull.Value)
                            currentReconciliationBatch.no_of_records_failed_to_reconciled = (int?)reader["no_of_records_failed_to_reconciled"];
                        if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"] != DBNull.Value)
                            currentReconciliationBatch.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                        if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"] != DBNull.Value)
                            currentReconciliationBatch.failure_reason = (string)reader["failure_reason"];
                        if ((columns & Columns.retry_count) == Columns.retry_count && reader["retry_count"] != DBNull.Value)
                            currentReconciliationBatch.retry_count = (int)reader["retry_count"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentReconciliationBatch.created_by = (int)reader["created_by"];
                        if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"] != DBNull.Value)
                            currentReconciliationBatch.end_time = (DateTime?)reader["end_time"];
                        if ((columns & Columns.batch_name) == Columns.batch_name && reader["batch_name"] != DBNull.Value)
                            currentReconciliationBatch.batch_name = (string)reader["batch_name"];
                        if ((columns & Columns.batch_description) == Columns.batch_description && reader["batch_description"] != DBNull.Value)
                            currentReconciliationBatch.batch_description = (string)reader["batch_description"];
                        if ((columns & Columns.auto_reconciled_amount) == Columns.auto_reconciled_amount && reader["auto_reconciled_amount"] != DBNull.Value)
                            currentReconciliationBatch.auto_reconciled_amount = (decimal?)reader["auto_reconciled_amount"];
                        if ((columns & Columns.manual_reconciled_amount) == Columns.manual_reconciled_amount && reader["manual_reconciled_amount"] != DBNull.Value)
                            currentReconciliationBatch.manual_reconciled_amount = (decimal?)reader["manual_reconciled_amount"];
                        if ((columns & Columns.dropped_transaction_amount) == Columns.dropped_transaction_amount && reader["dropped_transaction_amount"] != DBNull.Value)
                            currentReconciliationBatch.dropped_transaction_amount = (decimal?)reader["dropped_transaction_amount"];
                        if ((columns & Columns.acceptable_difference_type) == Columns.acceptable_difference_type && reader["acceptable_difference_type"] != DBNull.Value)
                            currentReconciliationBatch.acceptable_difference_type = (string)reader["acceptable_difference_type"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentReconciliationBatch.atm_id = (int)reader["atm_id"];

                    }
                    else
                    {
                        if (reader["reconciliation_batch_id"] != DBNull.Value)
                            currentReconciliationBatch.reconciliation_batch_id = (int)reader["reconciliation_batch_id"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentReconciliationBatch.creation_time = (DateTime)reader["creation_time"];
                        if (reader["transaction_start_date"] != DBNull.Value)
                            currentReconciliationBatch.transaction_start_date = (DateTime)reader["transaction_start_date"];
                        if (reader["transaction_end_date"] != DBNull.Value)
                            currentReconciliationBatch.transaction_end_date = (DateTime)reader["transaction_end_date"];
                        if (reader["acceptable_difference"] != DBNull.Value)
                            currentReconciliationBatch.acceptable_difference = (decimal?)reader["acceptable_difference"];
                        if (reader["status"] != DBNull.Value)
                            currentReconciliationBatch.status = (string)reader["status"];
                        if (reader["no_of_records_processed"] != DBNull.Value)
                            currentReconciliationBatch.no_of_records_processed = (int?)reader["no_of_records_processed"];
                        if (reader["no_of_records_reconciled"] != DBNull.Value)
                            currentReconciliationBatch.no_of_records_reconciled = (int?)reader["no_of_records_reconciled"];
                        if (reader["no_of_records_failed_to_reconciled"] != DBNull.Value)
                            currentReconciliationBatch.no_of_records_failed_to_reconciled = (int?)reader["no_of_records_failed_to_reconciled"];
                        if (reader["last_invoked_at"] != DBNull.Value)
                            currentReconciliationBatch.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                        if (reader["failure_reason"] != DBNull.Value)
                            currentReconciliationBatch.failure_reason = (string)reader["failure_reason"];
                        if (reader["retry_count"] != DBNull.Value)
                            currentReconciliationBatch.retry_count = (int)reader["retry_count"];
                        if (reader["created_by"] != DBNull.Value)
                            currentReconciliationBatch.created_by = (int)reader["created_by"];
                        if (reader["end_time"] != DBNull.Value)
                            currentReconciliationBatch.end_time = (DateTime?)reader["end_time"];
                        if (reader["batch_name"] != DBNull.Value)
                            currentReconciliationBatch.batch_name = (string)reader["batch_name"];
                        if (reader["batch_description"] != DBNull.Value)
                            currentReconciliationBatch.batch_description = (string)reader["batch_description"];
                        if (reader["auto_reconciled_amount"] != DBNull.Value)
                            currentReconciliationBatch.auto_reconciled_amount = (decimal?)reader["auto_reconciled_amount"];
                        if (reader["manual_reconciled_amount"] != DBNull.Value)
                            currentReconciliationBatch.manual_reconciled_amount = (decimal?)reader["manual_reconciled_amount"];
                        if (reader["dropped_transaction_amount"] != DBNull.Value)
                            currentReconciliationBatch.dropped_transaction_amount = (decimal?)reader["dropped_transaction_amount"];
                        if (reader["acceptable_difference_type"] != DBNull.Value)
                            currentReconciliationBatch.acceptable_difference_type = (string)reader["acceptable_difference_type"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentReconciliationBatch.atm_id = (int)reader["atm_id"];
                    }

                    currentReconciliationBatch.isNewEntity = false;
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

            public ReconciliationBatch CurrentReconciliationBatch
            {
                get { return currentReconciliationBatch; }
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


        #region ReconciliationBatch functions

        public static ReconciliationBatchReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.reconciliation_batch_id == (Columns.reconciliation_batch_id & columns))
                qry.Append("reconciliation_batch_id,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.transaction_start_date == (Columns.transaction_start_date & columns))
                qry.Append("transaction_start_date,");
            if (Columns.transaction_end_date == (Columns.transaction_end_date & columns))
                qry.Append("transaction_end_date,");
            if (Columns.acceptable_difference == (Columns.acceptable_difference & columns))
                qry.Append("acceptable_difference,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.no_of_records_processed == (Columns.no_of_records_processed & columns))
                qry.Append("no_of_records_processed,");
            if (Columns.no_of_records_reconciled == (Columns.no_of_records_reconciled & columns))
                qry.Append("no_of_records_reconciled,");
            if (Columns.no_of_records_failed_to_reconciled == (Columns.no_of_records_failed_to_reconciled & columns))
                qry.Append("no_of_records_failed_to_reconciled,");
            if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
                qry.Append("last_invoked_at,");
            if (Columns.failure_reason == (Columns.failure_reason & columns))
                qry.Append("failure_reason,");
            if (Columns.retry_count == (Columns.retry_count & columns))
                qry.Append("retry_count,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.end_time == (Columns.end_time & columns))
                qry.Append("end_time,");
            if (Columns.batch_name == (Columns.batch_name & columns))
                qry.Append("batch_name,");
            if (Columns.batch_description == (Columns.batch_description & columns))
                qry.Append("batch_description,");
            if (Columns.auto_reconciled_amount == (Columns.auto_reconciled_amount & columns))
                qry.Append("auto_reconciled_amount,");
            if (Columns.manual_reconciled_amount == (Columns.manual_reconciled_amount & columns))
                qry.Append("manual_reconciled_amount,");
            if (Columns.dropped_transaction_amount == (Columns.dropped_transaction_amount & columns))
                qry.Append("dropped_transaction_amount,");
            if (Columns.acceptable_difference_type == (Columns.acceptable_difference_type & columns))
                qry.Append("acceptable_difference_type,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Reconciliation_batch ");

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
            return new ReconciliationBatchReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ReconciliationBatchReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ReconciliationBatchReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select reconciliation_batch_id,creation_time,transaction_start_date,transaction_end_date,acceptable_difference,status,no_of_records_processed,no_of_records_reconciled,no_of_records_failed_to_reconciled,last_invoked_at,failure_reason,retry_count,created_by,end_time,batch_name,batch_description,auto_reconciled_amount,manual_reconciled_amount,dropped_transaction_amount,acceptable_difference_type,atm_id from Reconciliation_batch ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ReconciliationBatchReader(cmd.ExecuteReader(), conn);
        }

        static public ReconciliationBatchReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static ReconciliationBatch LoadReconciliationBatch(string where)
        {
            ReconciliationBatchReader reader = ReconciliationBatch.ExecuteReader(where);
            ReconciliationBatch _reconciliationbatch = null;
            if (reader.Read())
                _reconciliationbatch = reader.CurrentReconciliationBatch;
            reader.Close();
            return _reconciliationbatch;
        }

        public static ReconciliationBatch LoadReconciliationBatch(string where, IDbConnection conn)
        {
            ReconciliationBatchReader reader = ReconciliationBatch.ExecuteReader(where, conn);
            ReconciliationBatch _reconciliationbatch = null;
            if (reader.Read())
                _reconciliationbatch = reader.CurrentReconciliationBatch;
            reader.Close(false);
            return _reconciliationbatch;
        }

        public static ReconciliationBatch LoadReconciliationBatchByPk(int reconciliation_batch_id)
        {
            return LoadReconciliationBatch(" reconciliation_batch_id=" + reconciliation_batch_id);
        }

        public static ReconciliationBatch LoadReconciliationBatchByPk(int reconciliation_batch_id, IDbConnection conn)
        {
            return LoadReconciliationBatch(" reconciliation_batch_id=" + reconciliation_batch_id, conn);
        }

        public void Save()
        {
            if (reconciliation_batch_idChanged || creation_timeChanged || transaction_start_dateChanged || transaction_end_dateChanged || acceptable_differenceChanged || statusChanged || no_of_records_processedChanged || no_of_records_reconciledChanged || no_of_records_failed_to_reconciledChanged || last_invoked_atChanged || failure_reasonChanged || retry_countChanged || created_byChanged || end_timeChanged || batch_nameChanged || batch_descriptionChanged || auto_reconciled_amountChanged || manual_reconciled_amountChanged || dropped_transaction_amountChanged || acceptable_difference_typeChanged || atm_idChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());
        }

        public void Save(IDbConnection conn, IDbTransaction trx)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.Transaction = trx;
            ExcuteSave(cmd);
        }

        public void Save(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            ExcuteSave(cmd);
        }

        /// an opened connection
        private void ExcuteSave(IDbCommand cmd)
        {
            if (reconciliation_batch_idChanged || creation_timeChanged || transaction_start_dateChanged || transaction_end_dateChanged || acceptable_differenceChanged || statusChanged || no_of_records_processedChanged || no_of_records_reconciledChanged || no_of_records_failed_to_reconciledChanged || last_invoked_atChanged || failure_reasonChanged || retry_countChanged || created_byChanged || end_timeChanged || batch_nameChanged || batch_descriptionChanged || auto_reconciled_amountChanged || manual_reconciled_amountChanged || dropped_transaction_amountChanged || acceptable_difference_typeChanged || atm_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Reconciliation_batch( reconciliation_batch_id,creation_time,transaction_start_date,transaction_end_date,acceptable_difference,status,no_of_records_processed,no_of_records_reconciled,no_of_records_failed_to_reconciled,last_invoked_at,failure_reason,retry_count,created_by,end_time,batch_name,batch_description,auto_reconciled_amount,manual_reconciled_amount,dropped_transaction_amount,acceptable_difference_type,atm_id ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.reconciliation_batch_id = ConnectionFactory.GetNextId();
                        qry.Append(this.reconciliation_batch_id);
                    } qry.Append(",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(transaction_start_dateDbString + ",");
                    qry.Append(transaction_end_dateDbString + ",");
                    qry.Append(acceptable_differenceDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(no_of_records_processedDbString + ",");
                    qry.Append(no_of_records_reconciledDbString + ",");
                    qry.Append(no_of_records_failed_to_reconciledDbString + ",");
                    qry.Append(last_invoked_atDbString + ",");
                    qry.Append(failure_reasonDbString + ",");
                    qry.Append(retry_countDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(end_timeDbString + ",");
                    qry.Append(batch_nameDbString + ",");
                    qry.Append(batch_descriptionDbString + ",");
                    qry.Append(auto_reconciled_amountDbString + ",");
                    qry.Append(manual_reconciled_amountDbString + ",");
                    qry.Append(dropped_transaction_amountDbString + ",");
                    qry.Append(acceptable_difference_typeDbString + ",");
                    qry.Append(atm_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(reconciliation_batch_idChanged || creation_timeChanged || transaction_start_dateChanged || transaction_end_dateChanged || acceptable_differenceChanged || statusChanged || no_of_records_processedChanged || no_of_records_reconciledChanged || no_of_records_failed_to_reconciledChanged || last_invoked_atChanged || failure_reasonChanged || retry_countChanged || created_byChanged || end_timeChanged || batch_nameChanged || batch_descriptionChanged || auto_reconciled_amountChanged || manual_reconciled_amountChanged || dropped_transaction_amountChanged || acceptable_difference_typeChanged || atm_idChanged))
                        return;
                    qry.Append("UPDATE Reconciliation_batch set "); if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }

                    if (transaction_start_dateChanged)
                    {
                        qry.Append("transaction_start_date =" + transaction_start_dateDbString);
                        qry.Append(",");
                    }

                    if (transaction_end_dateChanged)
                    {
                        qry.Append("transaction_end_date =" + transaction_end_dateDbString);
                        qry.Append(",");
                    }

                    if (acceptable_differenceChanged)
                    {
                        qry.Append("acceptable_difference =" + acceptable_differenceDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (no_of_records_processedChanged)
                    {
                        qry.Append("no_of_records_processed =" + no_of_records_processedDbString);
                        qry.Append(",");
                    }

                    if (no_of_records_reconciledChanged)
                    {
                        qry.Append("no_of_records_reconciled =" + no_of_records_reconciledDbString);
                        qry.Append(",");
                    }

                    if (no_of_records_failed_to_reconciledChanged)
                    {
                        qry.Append("no_of_records_failed_to_reconciled =" + no_of_records_failed_to_reconciledDbString);
                        qry.Append(",");
                    }

                    if (last_invoked_atChanged)
                    {
                        qry.Append("last_invoked_at =" + last_invoked_atDbString);
                        qry.Append(",");
                    }

                    if (failure_reasonChanged)
                    {
                        qry.Append("failure_reason =" + failure_reasonDbString);
                        qry.Append(",");
                    }

                    if (retry_countChanged)
                    {
                        qry.Append("retry_count =" + retry_countDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (end_timeChanged)
                    {
                        qry.Append("end_time =" + end_timeDbString);
                        qry.Append(",");
                    }

                    if (batch_nameChanged)
                    {
                        qry.Append("batch_name =" + batch_nameDbString);
                        qry.Append(",");
                    }

                    if (batch_descriptionChanged)
                    {
                        qry.Append("batch_description =" + batch_descriptionDbString);
                        qry.Append(",");
                    }

                    if (auto_reconciled_amountChanged)
                    {
                        qry.Append("auto_reconciled_amount =" + auto_reconciled_amountDbString);
                        qry.Append(",");
                    }

                    if (manual_reconciled_amountChanged)
                    {
                        qry.Append("manual_reconciled_amount =" + manual_reconciled_amountDbString);
                        qry.Append(",");
                    }

                    if (dropped_transaction_amountChanged)
                    {
                        qry.Append("dropped_transaction_amount =" + dropped_transaction_amountDbString);
                        qry.Append(",");
                    }

                    if (acceptable_difference_typeChanged)
                    {
                        qry.Append("acceptable_difference_type =" + acceptable_difference_typeDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("reconciliation_batch_id = " + reconciliation_batch_idDbString);
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

        public void Delete()
        {
            Delete(ConnectionFactory.GetNewConnection());
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Reconciliation_batch where reconciliation_batch_id = " + reconciliation_batch_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteReconciliationBatchs(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Reconciliation_batch where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            reconciliation_batch_id = 1,
            creation_time = 2,
            transaction_start_date = 4,
            transaction_end_date = 8,
            acceptable_difference = 16,
            status = 32,
            no_of_records_processed = 64,
            no_of_records_reconciled = 128,
            no_of_records_failed_to_reconciled = 256,
            last_invoked_at = 512,
            failure_reason = 1024,
            retry_count = 2048,
            created_by = 4096,
            end_time = 8192,
            batch_name = 16384,
            batch_description = 32768,
            auto_reconciled_amount = 65536,
            manual_reconciled_amount = 131072,
            dropped_transaction_amount = 262144,
            acceptable_difference_type = 524288,
            atm_id = 1048576
        }
        #endregion
        public DataTable BulkSave(List<ReconciliationBatch> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Reconciliation_batch";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ReconciliationBatch.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ReconciliationBatch> transList, ref DataTable dt)
        {
            foreach (ReconciliationBatch tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["reconciliation_batch_id"] = ConnectionFactory.GetNextId();
                Row["creation_time"] = tran.CreationTime;
                Row["transaction_start_date"] = tran.TransactionStartDate;
                Row["transaction_end_date"] = tran.TransactionEndDate;
                Row["acceptable_difference"] = tran.AcceptableDifference;
                Row["status"] = tran.Status;
                Row["no_of_records_processed"] = tran.NoOfRecordsProcessed;
                Row["no_of_records_reconciled"] = tran.NoOfRecordsReconciled;
                Row["no_of_records_failed_to_reconciled"] = tran.NoOfRecordsFailedToReconciled;
                Row["last_invoked_at"] = tran.LastInvokedAt;
                Row["failure_reason"] = tran.FailureReason;
                Row["retry_count"] = tran.RetryCount;
                Row["created_by"] = tran.CreatedBy;
                Row["end_time"] = tran.EndTime;
                Row["batch_name"] = tran.BatchName;
                Row["batch_description"] = tran.BatchDescription;
                Row["auto_reconciled_amount"] = tran.AutoReconciledAmount;
                Row["manual_reconciled_amount"] = tran.ManualReconciledAmount;
                Row["dropped_transaction_amount"] = tran.DroppedTransactionAmount;
                Row["acceptable_difference_type"] = tran.AcceptableDifferenceType;
                Row["atm_id"] = tran.AtmId;
                dt.Rows.Add(Row);
            }
        }
    }
}