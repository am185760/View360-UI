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
    public class EjParsedBnaTransaction
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedBnaTransaction() { }
        public EjParsedBnaTransaction(long ej_parsed_bna_transaction_id, DateTime trxn_datetime, long atm_id, DateTime generated_at, int start_index, int end_index, long task_id, bool is_eligible)
        {
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
        }
        public EjParsedBnaTransaction(DateTime trxn_datetime, string terminal_id, string seq, string account_type, string pan, string consumer_message_id, string dispute_status, decimal? amount_authorized, string status, string comment, string processed_tran, long atm_id, DateTime generated_at, int start_index, int end_index, long task_id, bool is_eligible, DateTime? transaction_start_time, string transaction_end_time, string card_taken_time, bool? is_disputed_transaction, string host_tsn, string account_no, DateTime? posting_date, string currency, long? transaction_type_id, string network, bool? is_cardless, long? customer_id, string bank_name)
        {
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.terminal_id = terminal_id;
            this.terminal_idChanged = true;
            this.seq = seq;
            this.seqChanged = true;
            this.account_type = account_type;
            this.account_typeChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.consumer_message_id = consumer_message_id;
            this.consumer_message_idChanged = true;
            this.dispute_status = dispute_status;
            this.dispute_statusChanged = true;
            this.amount_authorized = amount_authorized;
            this.amount_authorizedChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.comment = comment;
            this.commentChanged = true;
            this.processed_tran = processed_tran;
            this.processed_tranChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.transaction_start_time = transaction_start_time;
            this.transaction_start_timeChanged = true;
            this.transaction_end_time = transaction_end_time;
            this.transaction_end_timeChanged = true;
            this.card_taken_time = card_taken_time;
            this.card_taken_timeChanged = true;
            this.is_disputed_transaction = is_disputed_transaction;
            this.is_disputed_transactionChanged = true;
            this.host_tsn = host_tsn;
            this.host_tsnChanged = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.posting_date = posting_date;
            this.posting_dateChanged = true;
            this.currency = currency;
            this.currencyChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
            this.network = network;
            this.networkChanged = true;
            this.is_cardless = is_cardless;
            this.is_cardlessChanged = true;
            this.customer_id = customer_id;
            this.customer_idChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
        }
        private EjParsedBnaTransaction(long ej_parsed_bna_transaction_id, DateTime trxn_datetime, string terminal_id, string seq, string account_type, string pan, string consumer_message_id, string dispute_status, decimal? amount_authorized, string status, string comment, string processed_tran, long atm_id, DateTime generated_at, int start_index, int end_index, long task_id, bool is_eligible, DateTime? transaction_start_time, string transaction_end_time, string card_taken_time, bool? is_disputed_transaction, string host_tsn, string account_no, DateTime? posting_date, string currency, long? transaction_type_id, string network, bool? is_cardless, long? customer_id, string bank_name)
        {
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.terminal_id = terminal_id;
            this.terminal_idChanged = true;
            this.seq = seq;
            this.seqChanged = true;
            this.account_type = account_type;
            this.account_typeChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.consumer_message_id = consumer_message_id;
            this.consumer_message_idChanged = true;
            this.dispute_status = dispute_status;
            this.dispute_statusChanged = true;
            this.amount_authorized = amount_authorized;
            this.amount_authorizedChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.comment = comment;
            this.commentChanged = true;
            this.processed_tran = processed_tran;
            this.processed_tranChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.transaction_start_time = transaction_start_time;
            this.transaction_start_timeChanged = true;
            this.transaction_end_time = transaction_end_time;
            this.transaction_end_timeChanged = true;
            this.card_taken_time = card_taken_time;
            this.card_taken_timeChanged = true;
            this.is_disputed_transaction = is_disputed_transaction;
            this.is_disputed_transactionChanged = true;
            this.host_tsn = host_tsn;
            this.host_tsnChanged = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.posting_date = posting_date;
            this.posting_dateChanged = true;
            this.currency = currency;
            this.currencyChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
            this.network = network;
            this.networkChanged = true;
            this.is_cardless = is_cardless;
            this.is_cardlessChanged = true;
            this.customer_id = customer_id;
            this.customer_idChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
        }

        #region members and properties for columns

        #region EjParsedBnaTransactionId
        private bool ej_parsed_bna_transaction_idChanged = false;
        private long ej_parsed_bna_transaction_id;
        public long EjParsedBnaTransactionId
        {
            get { return ej_parsed_bna_transaction_id; }
            set
            {
                ej_parsed_bna_transaction_id = value;
                ej_parsed_bna_transaction_idChanged = true;
            }
        }
        private string ej_parsed_bna_transaction_idDbString
        {
            get
            {
                return ej_parsed_bna_transaction_id.ToString();
            }
        }
        #endregion
        #region TrxnDatetime
        private bool trxn_datetimeChanged = false;
        private DateTime trxn_datetime;
        public DateTime TrxnDatetime
        {
            get { return trxn_datetime; }
            set
            {
                trxn_datetime = value;
                trxn_datetimeChanged = true;
            }
        }
        private string trxn_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", trxn_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region TerminalId
        private bool terminal_idChanged = false;
        private string terminal_id;
        public string TerminalId
        {
            get { return terminal_id; }
            set
            {
                terminal_id = value;
                terminal_idChanged = true;
            }
        }
        private string terminal_idDbString
        {
            get
            {
                if (this.terminal_id != null)
                    return string.Format("'{0}'", terminal_id);
                else
                    return "null";
            }
        }
        #endregion
        #region Seq
        private bool seqChanged = false;
        private string seq;
        public string Seq
        {
            get { return seq; }
            set
            {
                seq = value;
                seqChanged = true;
            }
        }
        private string seqDbString
        {
            get
            {
                if (this.seq != null)
                    return string.Format("'{0}'", seq);
                else
                    return "null";
            }
        }
        #endregion
        #region AccountType
        private bool account_typeChanged = false;
        private string account_type;
        public string AccountType
        {
            get { return account_type; }
            set
            {
                account_type = value;
                account_typeChanged = true;
            }
        }
        private string account_typeDbString
        {
            get
            {
                if (this.account_type != null)
                    return string.Format("'{0}'", account_type);
                else
                    return "null";
            }
        }
        #endregion
        #region Pan
        private bool panChanged = false;
        private string pan;
        public string Pan
        {
            get { return pan; }
            set
            {
                pan = value;
                panChanged = true;
            }
        }
        private string panDbString
        {
            get
            {
                if (this.pan != null)
                    return string.Format("'{0}'", pan);
                else
                    return "null";
            }
        }
        #endregion
        #region ConsumerMessageId
        private bool consumer_message_idChanged = false;
        private string consumer_message_id;
        public string ConsumerMessageId
        {
            get { return consumer_message_id; }
            set
            {
                consumer_message_id = value;
                consumer_message_idChanged = true;
            }
        }
        private string consumer_message_idDbString
        {
            get
            {
                if (this.consumer_message_id != null)
                    return string.Format("'{0}'", consumer_message_id);
                else
                    return "null";
            }
        }
        #endregion
        #region DisputeStatus
        private bool dispute_statusChanged = false;
        private string dispute_status;
        public string DisputeStatus
        {
            get { return dispute_status; }
            set
            {
                dispute_status = value;
                dispute_statusChanged = true;
            }
        }
        private string dispute_statusDbString
        {
            get
            {
                if (this.dispute_status != null)
                    return string.Format("'{0}'", dispute_status);
                else
                    return "null";
            }
        }
        #endregion
        #region AmountAuthorized
        private bool amount_authorizedChanged = false;
        private decimal? amount_authorized;
        public decimal? AmountAuthorized
        {
            get { return amount_authorized; }
            set
            {
                amount_authorized = value;
                amount_authorizedChanged = true;
            }
        }
        private string amount_authorizedDbString
        {
            get
            {
                if (this.amount_authorized.HasValue)
                    return amount_authorized.ToString();
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
        #region Comment
        private bool commentChanged = false;
        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                commentChanged = true;
            }
        }
        private string commentDbString
        {
            get
            {
                if (this.comment != null)
                    return string.Format("'{0}'", comment);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessedTran
        private bool processed_tranChanged = false;
        private string processed_tran;
        public string ProcessedTran
        {
            get { return processed_tran; }
            set
            {
                processed_tran = value;
                processed_tranChanged = true;
            }
        }
        private string processed_tranDbString
        {
            get
            {
                if (this.processed_tran != null)
                    return string.Format("'{0}'", processed_tran);
                else
                    return "null";
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private long atm_id;
        public long AtmId
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
        #region GeneratedAt
        private bool generated_atChanged = false;
        private DateTime generated_at;
        public DateTime GeneratedAt
        {
            get { return generated_at; }
            set
            {
                generated_at = value;
                generated_atChanged = true;
            }
        }
        private string generated_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region StartIndex
        private bool start_indexChanged = false;
        private int start_index;
        public int StartIndex
        {
            get { return start_index; }
            set
            {
                start_index = value;
                start_indexChanged = true;
            }
        }
        private string start_indexDbString
        {
            get
            {
                return start_index.ToString();
            }
        }
        #endregion
        #region EndIndex
        private bool end_indexChanged = false;
        private int end_index;
        public int EndIndex
        {
            get { return end_index; }
            set
            {
                end_index = value;
                end_indexChanged = true;
            }
        }
        private string end_indexDbString
        {
            get
            {
                return end_index.ToString();
            }
        }
        #endregion
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
        #region IsEligible
        private bool is_eligibleChanged = false;
        private bool is_eligible;
        public bool IsEligible
        {
            get { return is_eligible; }
            set
            {
                is_eligible = value;
                is_eligibleChanged = true;
            }
        }
        private string is_eligibleDbString
        {
            get
            {
                return is_eligible ? "1" : "0";
            }
        }
        #endregion
        #region TransactionStartTime
        private bool transaction_start_timeChanged = false;
        private DateTime? transaction_start_time;
        public DateTime? TransactionStartTime
        {
            get { return transaction_start_time; }
            set
            {
                transaction_start_time = value;
                transaction_start_timeChanged = true;
            }
        }
        private string transaction_start_timeDbString
        {
            get
            {
                if (this.transaction_start_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", transaction_start_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region TransactionEndTime
        private bool transaction_end_timeChanged = false;
        private string transaction_end_time;
        public string TransactionEndTime
        {
            get { return transaction_end_time; }
            set
            {
                transaction_end_time = value;
                transaction_end_timeChanged = true;
            }
        }
        private string transaction_end_timeDbString
        {
            get
            {
                if (this.transaction_end_time != null)
                    return string.Format("'{0}'", transaction_end_time);
                else
                    return "null";
            }
        }
        #endregion
        #region CardTakenTime
        private bool card_taken_timeChanged = false;
        private string card_taken_time;
        public string CardTakenTime
        {
            get { return card_taken_time; }
            set
            {
                card_taken_time = value;
                card_taken_timeChanged = true;
            }
        }
        private string card_taken_timeDbString
        {
            get
            {
                if (this.card_taken_time != null)
                    return string.Format("'{0}'", card_taken_time);
                else
                    return "null";
            }
        }
        #endregion
        #region IsDisputedTransaction
        private bool is_disputed_transactionChanged = false;
        private bool? is_disputed_transaction;
        public bool? IsDisputedTransaction
        {
            get { return is_disputed_transaction; }
            set
            {
                is_disputed_transaction = value;
                is_disputed_transactionChanged = true;
            }
        }
        private string is_disputed_transactionDbString
        {
            get
            {
                if (this.is_disputed_transaction.HasValue)
                    return is_disputed_transaction.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region HostTsn
        private bool host_tsnChanged = false;
        private string host_tsn;
        public string HostTsn
        {
            get { return host_tsn; }
            set
            {
                host_tsn = value;
                host_tsnChanged = true;
            }
        }
        private string host_tsnDbString
        {
            get
            {
                if (this.host_tsn != null)
                    return string.Format("'{0}'", host_tsn);
                else
                    return "null";
            }
        }
        #endregion
        #region AccountNo
        private bool account_noChanged = false;
        private string account_no;
        public string AccountNo
        {
            get { return account_no; }
            set
            {
                account_no = value;
                account_noChanged = true;
            }
        }
        private string account_noDbString
        {
            get
            {
                if (this.account_no != null)
                    return string.Format("'{0}'", account_no);
                else
                    return "null";
            }
        }
        #endregion
        #region PostingDate
        private bool posting_dateChanged = false;
        private DateTime? posting_date;
        public DateTime? PostingDate
        {
            get { return posting_date; }
            set
            {
                posting_date = value;
                posting_dateChanged = true;
            }
        }
        private string posting_dateDbString
        {
            get
            {
                if (this.posting_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", posting_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Currency
        private bool currencyChanged = false;
        private string currency;
        public string Currency
        {
            get { return currency; }
            set
            {
                currency = value;
                currencyChanged = true;
            }
        }
        private string currencyDbString
        {
            get
            {
                if (this.currency != null)
                    return string.Format("'{0}'", currency);
                else
                    return "null";
            }
        }
        #endregion
        #region TransactionTypeId
        private bool transaction_type_idChanged = false;
        private long? transaction_type_id;
        public long? TransactionTypeId
        {
            get { return transaction_type_id; }
            set
            {
                transaction_type_id = value;
                transaction_type_idChanged = true;
            }
        }
        private string transaction_type_idDbString
        {
            get
            {
                if (this.transaction_type_id.HasValue)
                    return transaction_type_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Network
        private bool networkChanged = false;
        private string network;
        public string Network
        {
            get { return network; }
            set
            {
                network = value;
                networkChanged = true;
            }
        }
        private string networkDbString
        {
            get
            {
                if (this.network != null)
                    return string.Format("'{0}'", network);
                else
                    return "null";
            }
        }
        #endregion
        #region IsCardless
        private bool is_cardlessChanged = false;
        private bool? is_cardless;
        public bool? IsCardless
        {
            get { return is_cardless; }
            set
            {
                is_cardless = value;
                is_cardlessChanged = true;
            }
        }
        private string is_cardlessDbString
        {
            get
            {
                if (this.is_cardless.HasValue)
                    return is_cardless.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region CustomerId
        private bool customer_idChanged = false;
        private long? customer_id;
        public long? CustomerId
        {
            get { return customer_id; }
            set
            {
                customer_id = value;
                customer_idChanged = true;
            }
        }
        private string customer_idDbString
        {
            get
            {
                if (this.customer_id.HasValue)
                    return customer_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region BankName
        private bool bank_nameChanged = false;
        private string bank_name;
        public string BankName
        {
            get { return bank_name; }
            set
            {
                bank_name = value;
                bank_nameChanged = true;
            }
        }
        private string bank_nameDbString
        {
            get
            {
                if (this.bank_name != null)
                    return string.Format("'{0}'", bank_name);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region EjParsedBnaTransactionReader
        public class EjParsedBnaTransactionReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjParsedBnaTransaction currentEjParsedBnaTransaction;
            Columns columns;
            bool partialRead = false;
            private EjParsedBnaTransactionReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjParsedBnaTransactionReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjParsedBnaTransactionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjParsedBnaTransaction; }

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
                    currentEjParsedBnaTransaction = new EjParsedBnaTransaction();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_parsed_bna_transaction_id) == Columns.ej_parsed_bna_transaction_id && reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.ej_parsed_bna_transaction_id = (long)reader["ej_parsed_bna_transaction_id"];
                        if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"] != DBNull.Value)
                            currentEjParsedBnaTransaction.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if ((columns & Columns.terminal_id) == Columns.terminal_id && reader["terminal_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.terminal_id = (string)reader["terminal_id"];
                        if ((columns & Columns.seq) == Columns.seq && reader["seq"] != DBNull.Value)
                            currentEjParsedBnaTransaction.seq = (string)reader["seq"];
                        if ((columns & Columns.account_type) == Columns.account_type && reader["account_type"] != DBNull.Value)
                            currentEjParsedBnaTransaction.account_type = (string)reader["account_type"];
                        if ((columns & Columns.pan) == Columns.pan && reader["pan"] != DBNull.Value)
                            currentEjParsedBnaTransaction.pan = (string)reader["pan"];
                        if ((columns & Columns.consumer_message_id) == Columns.consumer_message_id && reader["consumer_message_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.consumer_message_id = (string)reader["consumer_message_id"];
                        if ((columns & Columns.dispute_status) == Columns.dispute_status && reader["dispute_status"] != DBNull.Value)
                            currentEjParsedBnaTransaction.dispute_status = (string)reader["dispute_status"];
                        if ((columns & Columns.amount_authorized) == Columns.amount_authorized && reader["amount_authorized"] != DBNull.Value)
                            currentEjParsedBnaTransaction.amount_authorized = (decimal?)reader["amount_authorized"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentEjParsedBnaTransaction.status = (string)reader["status"];
                        if ((columns & Columns.comment) == Columns.comment && reader["comment"] != DBNull.Value)
                            currentEjParsedBnaTransaction.comment = (string)reader["comment"];
                        if ((columns & Columns.processed_tran) == Columns.processed_tran && reader["processed_tran"] != DBNull.Value)
                            currentEjParsedBnaTransaction.processed_tran = (string)reader["processed_tran"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"] != DBNull.Value)
                            currentEjParsedBnaTransaction.generated_at = (DateTime)reader["generated_at"];
                        if ((columns & Columns.start_index) == Columns.start_index && reader["start_index"] != DBNull.Value)
                            currentEjParsedBnaTransaction.start_index = (int)reader["start_index"];
                        if ((columns & Columns.end_index) == Columns.end_index && reader["end_index"] != DBNull.Value)
                            currentEjParsedBnaTransaction.end_index = (int)reader["end_index"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.task_id = (long)reader["task_id"];
                        if ((columns & Columns.is_eligible) == Columns.is_eligible && reader["is_eligible"] != DBNull.Value)
                            currentEjParsedBnaTransaction.is_eligible = (bool)reader["is_eligible"];
                        if ((columns & Columns.transaction_start_time) == Columns.transaction_start_time && reader["transaction_start_time"] != DBNull.Value)
                            currentEjParsedBnaTransaction.transaction_start_time = (DateTime?)reader["transaction_start_time"];
                        if ((columns & Columns.transaction_end_time) == Columns.transaction_end_time && reader["transaction_end_time"] != DBNull.Value)
                            currentEjParsedBnaTransaction.transaction_end_time = (string)reader["transaction_end_time"];
                        if ((columns & Columns.card_taken_time) == Columns.card_taken_time && reader["card_taken_time"] != DBNull.Value)
                            currentEjParsedBnaTransaction.card_taken_time = (string)reader["card_taken_time"];
                        if ((columns & Columns.is_disputed_transaction) == Columns.is_disputed_transaction && reader["is_disputed_transaction"] != DBNull.Value)
                            currentEjParsedBnaTransaction.is_disputed_transaction = (bool?)reader["is_disputed_transaction"];
                        if ((columns & Columns.host_tsn) == Columns.host_tsn && reader["host_tsn"] != DBNull.Value)
                            currentEjParsedBnaTransaction.host_tsn = (string)reader["host_tsn"];
                        if ((columns & Columns.account_no) == Columns.account_no && reader["account_no"] != DBNull.Value)
                            currentEjParsedBnaTransaction.account_no = (string)reader["account_no"];
                        if ((columns & Columns.posting_date) == Columns.posting_date && reader["posting_date"] != DBNull.Value)
                            currentEjParsedBnaTransaction.posting_date = (DateTime?)reader["posting_date"];
                        if ((columns & Columns.currency) == Columns.currency && reader["currency"] != DBNull.Value)
                            currentEjParsedBnaTransaction.currency = (string)reader["currency"];
                        if ((columns & Columns.transaction_type_id) == Columns.transaction_type_id && reader["transaction_type_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.transaction_type_id = (long?)reader["transaction_type_id"];
                        if ((columns & Columns.network) == Columns.network && reader["network"] != DBNull.Value)
                            currentEjParsedBnaTransaction.network = (string)reader["network"];
                        if ((columns & Columns.is_cardless) == Columns.is_cardless && reader["is_cardless"] != DBNull.Value)
                            currentEjParsedBnaTransaction.is_cardless = (bool?)reader["is_cardless"];
                        if ((columns & Columns.customer_id) == Columns.customer_id && reader["customer_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.customer_id = (long?)reader["customer_id"];
                        if ((columns & Columns.bank_name) == Columns.bank_name && reader["bank_name"] != DBNull.Value)
                            currentEjParsedBnaTransaction.bank_name = (string)reader["bank_name"];

                    }
                    else
                    {
                        if (reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.ej_parsed_bna_transaction_id = (long)reader["ej_parsed_bna_transaction_id"];
                        if (reader["trxn_datetime"] != DBNull.Value)
                            currentEjParsedBnaTransaction.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if (reader["terminal_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.terminal_id = (string)reader["terminal_id"];
                        if (reader["seq"] != DBNull.Value)
                            currentEjParsedBnaTransaction.seq = (string)reader["seq"];
                        if (reader["account_type"] != DBNull.Value)
                            currentEjParsedBnaTransaction.account_type = (string)reader["account_type"];
                        if (reader["pan"] != DBNull.Value)
                            currentEjParsedBnaTransaction.pan = (string)reader["pan"];
                        if (reader["consumer_message_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.consumer_message_id = (string)reader["consumer_message_id"];
                        if (reader["dispute_status"] != DBNull.Value)
                            currentEjParsedBnaTransaction.dispute_status = (string)reader["dispute_status"];
                        if (reader["amount_authorized"] != DBNull.Value)
                            currentEjParsedBnaTransaction.amount_authorized = (decimal?)reader["amount_authorized"];
                        if (reader["status"] != DBNull.Value)
                            currentEjParsedBnaTransaction.status = (string)reader["status"];
                        if (reader["comment"] != DBNull.Value)
                            currentEjParsedBnaTransaction.comment = (string)reader["comment"];
                        if (reader["processed_tran"] != DBNull.Value)
                            currentEjParsedBnaTransaction.processed_tran = (string)reader["processed_tran"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.atm_id = (long)reader["atm_id"];
                        if (reader["generated_at"] != DBNull.Value)
                            currentEjParsedBnaTransaction.generated_at = (DateTime)reader["generated_at"];
                        if (reader["start_index"] != DBNull.Value)
                            currentEjParsedBnaTransaction.start_index = (int)reader["start_index"];
                        if (reader["end_index"] != DBNull.Value)
                            currentEjParsedBnaTransaction.end_index = (int)reader["end_index"];
                        if (reader["task_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.task_id = (long)reader["task_id"];
                        if (reader["is_eligible"] != DBNull.Value)
                            currentEjParsedBnaTransaction.is_eligible = (bool)reader["is_eligible"];
                        if (reader["transaction_start_time"] != DBNull.Value)
                            currentEjParsedBnaTransaction.transaction_start_time = (DateTime?)reader["transaction_start_time"];
                        if (reader["transaction_end_time"] != DBNull.Value)
                            currentEjParsedBnaTransaction.transaction_end_time = (string)reader["transaction_end_time"];
                        if (reader["card_taken_time"] != DBNull.Value)
                            currentEjParsedBnaTransaction.card_taken_time = (string)reader["card_taken_time"];
                        if (reader["is_disputed_transaction"] != DBNull.Value)
                            currentEjParsedBnaTransaction.is_disputed_transaction = (bool?)reader["is_disputed_transaction"];
                        if (reader["host_tsn"] != DBNull.Value)
                            currentEjParsedBnaTransaction.host_tsn = (string)reader["host_tsn"];
                        if (reader["account_no"] != DBNull.Value)
                            currentEjParsedBnaTransaction.account_no = (string)reader["account_no"];
                        if (reader["posting_date"] != DBNull.Value)
                            currentEjParsedBnaTransaction.posting_date = (DateTime?)reader["posting_date"];
                        if (reader["currency"] != DBNull.Value)
                            currentEjParsedBnaTransaction.currency = (string)reader["currency"];
                        if (reader["transaction_type_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.transaction_type_id = (long?)reader["transaction_type_id"];
                        if (reader["network"] != DBNull.Value)
                            currentEjParsedBnaTransaction.network = (string)reader["network"];
                        if (reader["is_cardless"] != DBNull.Value)
                            currentEjParsedBnaTransaction.is_cardless = (bool?)reader["is_cardless"];
                        if (reader["customer_id"] != DBNull.Value)
                            currentEjParsedBnaTransaction.customer_id = (long?)reader["customer_id"];
                        if (reader["bank_name"] != DBNull.Value)
                            currentEjParsedBnaTransaction.bank_name = (string)reader["bank_name"];
                    }

                    currentEjParsedBnaTransaction.isNewEntity = false;
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

            public EjParsedBnaTransaction CurrentEjParsedBnaTransaction
            {
                get { return currentEjParsedBnaTransaction; }
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


        #region EjParsedBnaTransaction functions

        public static EjParsedBnaTransactionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_parsed_bna_transaction_id == (Columns.ej_parsed_bna_transaction_id & columns))
                qry.Append("ej_parsed_bna_transaction_id,");
            if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
                qry.Append("trxn_datetime,");
            if (Columns.terminal_id == (Columns.terminal_id & columns))
                qry.Append("terminal_id,");
            if (Columns.seq == (Columns.seq & columns))
                qry.Append("seq,");
            if (Columns.account_type == (Columns.account_type & columns))
                qry.Append("account_type,");
            if (Columns.pan == (Columns.pan & columns))
                qry.Append("pan,");
            if (Columns.consumer_message_id == (Columns.consumer_message_id & columns))
                qry.Append("consumer_message_id,");
            if (Columns.dispute_status == (Columns.dispute_status & columns))
                qry.Append("dispute_status,");
            if (Columns.amount_authorized == (Columns.amount_authorized & columns))
                qry.Append("amount_authorized,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.comment == (Columns.comment & columns))
                qry.Append("comment,");
            if (Columns.processed_tran == (Columns.processed_tran & columns))
                qry.Append("processed_tran,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.generated_at == (Columns.generated_at & columns))
                qry.Append("generated_at,");
            if (Columns.start_index == (Columns.start_index & columns))
                qry.Append("start_index,");
            if (Columns.end_index == (Columns.end_index & columns))
                qry.Append("end_index,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.is_eligible == (Columns.is_eligible & columns))
                qry.Append("is_eligible,");
            if (Columns.transaction_start_time == (Columns.transaction_start_time & columns))
                qry.Append("transaction_start_time,");
            if (Columns.transaction_end_time == (Columns.transaction_end_time & columns))
                qry.Append("transaction_end_time,");
            if (Columns.card_taken_time == (Columns.card_taken_time & columns))
                qry.Append("card_taken_time,");
            if (Columns.is_disputed_transaction == (Columns.is_disputed_transaction & columns))
                qry.Append("is_disputed_transaction,");
            if (Columns.host_tsn == (Columns.host_tsn & columns))
                qry.Append("host_tsn,");
            if (Columns.account_no == (Columns.account_no & columns))
                qry.Append("account_no,");
            if (Columns.posting_date == (Columns.posting_date & columns))
                qry.Append("posting_date,");
            if (Columns.currency == (Columns.currency & columns))
                qry.Append("currency,");
            if (Columns.transaction_type_id == (Columns.transaction_type_id & columns))
                qry.Append("transaction_type_id,");
            if (Columns.network == (Columns.network & columns))
                qry.Append("network,");
            if (Columns.is_cardless == (Columns.is_cardless & columns))
                qry.Append("is_cardless,");
            if (Columns.customer_id == (Columns.customer_id & columns))
                qry.Append("customer_id,");
            if (Columns.bank_name == (Columns.bank_name & columns))
                qry.Append("bank_name,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_parsed_bna_transaction ");

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
            return new EjParsedBnaTransactionReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjParsedBnaTransactionReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjParsedBnaTransactionReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectej_parsed_bna_transaction_id,trxn_datetime,terminal_id,seq,account_type,pan,consumer_message_id,dispute_status,amount_authorized,status,comment,processed_tran,atm_id,generated_at,start_index,end_index,task_id,is_eligible,transaction_start_time,transaction_end_time,card_taken_time,is_disputed_transaction,host_tsn,account_no,posting_date,currency,transaction_type_id,network,is_cardless,customer_id,bank_namefrom Ej_parsed_bna_transaction ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedBnaTransactionReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedBnaTransactionReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public static EjParsedBnaTransaction LoadEjParsedBnaTransaction(string where)
        {
            EjParsedBnaTransactionReader reader = EjParsedBnaTransaction.ExecuteReader(where);
            EjParsedBnaTransaction _ejparsedbnatransaction = null;
            if (reader.Read())
                _ejparsedbnatransaction = reader.CurrentEjParsedBnaTransaction;
            reader.Close();
            return _ejparsedbnatransaction;
        }

        public static EjParsedBnaTransaction LoadEjParsedBnaTransaction(string where, IDbConnection conn)
        {
            EjParsedBnaTransactionReader reader = EjParsedBnaTransaction.ExecuteReader(where, conn);
            EjParsedBnaTransaction _ejparsedbnatransaction = null;
            if (reader.Read())
                _ejparsedbnatransaction = reader.CurrentEjParsedBnaTransaction;
            reader.Close(false);
            return _ejparsedbnatransaction;
        }

        public static EjParsedBnaTransaction LoadEjParsedBnaTransactionByPk(long ej_parsed_bna_transaction_id, DateTime trxn_datetime)
        {
            return LoadEjParsedBnaTransaction("ej_parsed_bna_transaction_id=" + ej_parsed_bna_transaction_id + " and trxn_datetime=Convert(datetime,'" + trxn_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)");
        }

        public static EjParsedBnaTransaction LoadEjParsedBnaTransactionByPk(long ej_parsed_bna_transaction_id, DateTime trxn_datetime, IDbConnection conn)
        {
            return LoadEjParsedBnaTransaction(" ej_parsed_bna_transaction_id=" + ej_parsed_bna_transaction_id + " and trxn_datetime=Convert(datetime,'" + trxn_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)", conn);
        }

        public void Save()
        {
            if (ej_parsed_bna_transaction_idChanged || trxn_datetimeChanged || terminal_idChanged || seqChanged || account_typeChanged || panChanged || consumer_message_idChanged || dispute_statusChanged || amount_authorizedChanged || statusChanged || commentChanged || processed_tranChanged || atm_idChanged || generated_atChanged || start_indexChanged || end_indexChanged || task_idChanged || is_eligibleChanged || transaction_start_timeChanged || transaction_end_timeChanged || card_taken_timeChanged || is_disputed_transactionChanged || host_tsnChanged || account_noChanged || posting_dateChanged || currencyChanged || transaction_type_idChanged || networkChanged || is_cardlessChanged || customer_idChanged || bank_nameChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Tx).CreateCommand());
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
            if (ej_parsed_bna_transaction_idChanged || trxn_datetimeChanged || terminal_idChanged || seqChanged || account_typeChanged || panChanged || consumer_message_idChanged || dispute_statusChanged || amount_authorizedChanged || statusChanged || commentChanged || processed_tranChanged || atm_idChanged || generated_atChanged || start_indexChanged || end_indexChanged || task_idChanged || is_eligibleChanged || transaction_start_timeChanged || transaction_end_timeChanged || card_taken_timeChanged || is_disputed_transactionChanged || host_tsnChanged || account_noChanged || posting_dateChanged || currencyChanged || transaction_type_idChanged || networkChanged || is_cardlessChanged || customer_idChanged || bank_nameChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_bna_transaction(ej_parsed_bna_transaction_id,trxn_datetime,terminal_id,seq,account_type,pan,consumer_message_id,dispute_status,amount_authorized,status,comment,processed_tran,atm_id,generated_at,start_index,end_index,task_id,is_eligible,transaction_start_time,transaction_end_time,card_taken_time,is_disputed_transaction,host_tsn,account_no,posting_date,currency,transaction_type_id,network,is_cardless,customer_id,bank_name) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.ej_parsed_bna_transaction_id = ConnectionFactory.GetNextId(DatabaseName.Tx);
                        qry.Append(this.ej_parsed_bna_transaction_id);
                    }
                    qry.Append(",");
                    qry.Append(trxn_datetimeDbString + ",");
                    qry.Append(terminal_idDbString + ",");
                    qry.Append(seqDbString + ",");
                    qry.Append(account_typeDbString + ",");
                    qry.Append(panDbString + ",");
                    qry.Append(consumer_message_idDbString + ",");
                    qry.Append(dispute_statusDbString + ",");
                    qry.Append(amount_authorizedDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(commentDbString + ",");
                    qry.Append(processed_tranDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(generated_atDbString + ",");
                    qry.Append(start_indexDbString + ",");
                    qry.Append(end_indexDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(is_eligibleDbString + ",");
                    qry.Append(transaction_start_timeDbString + ",");
                    qry.Append(transaction_end_timeDbString + ",");
                    qry.Append(card_taken_timeDbString + ",");
                    qry.Append(is_disputed_transactionDbString + ",");
                    qry.Append(host_tsnDbString + ",");
                    qry.Append(account_noDbString + ",");
                    qry.Append(posting_dateDbString + ",");
                    qry.Append(currencyDbString + ",");
                    qry.Append(transaction_type_idDbString + ",");
                    qry.Append(networkDbString + ",");
                    qry.Append(is_cardlessDbString + ",");
                    qry.Append(customer_idDbString + ",");
                    qry.Append(bank_nameDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_bna_transaction_idChanged || trxn_datetimeChanged || terminal_idChanged || seqChanged || account_typeChanged || panChanged || consumer_message_idChanged || dispute_statusChanged || amount_authorizedChanged || statusChanged || commentChanged || processed_tranChanged || atm_idChanged || generated_atChanged || start_indexChanged || end_indexChanged || task_idChanged || is_eligibleChanged || transaction_start_timeChanged || transaction_end_timeChanged || card_taken_timeChanged || is_disputed_transactionChanged || host_tsnChanged || account_noChanged || posting_dateChanged || currencyChanged || transaction_type_idChanged || networkChanged || is_cardlessChanged || customer_idChanged || bank_nameChanged))
                        return;
                    qry.Append("UPDATE Ej_parsed_bna_transaction set "); if (terminal_idChanged)
                    {
                        qry.Append("terminal_id =" + terminal_idDbString);
                        qry.Append(",");
                    }

                    if (seqChanged)
                    {
                        qry.Append("seq =" + seqDbString);
                        qry.Append(",");
                    }

                    if (account_typeChanged)
                    {
                        qry.Append("account_type =" + account_typeDbString);
                        qry.Append(",");
                    }

                    if (panChanged)
                    {
                        qry.Append("pan =" + panDbString);
                        qry.Append(",");
                    }

                    if (consumer_message_idChanged)
                    {
                        qry.Append("consumer_message_id =" + consumer_message_idDbString);
                        qry.Append(",");
                    }

                    if (dispute_statusChanged)
                    {
                        qry.Append("dispute_status =" + dispute_statusDbString);
                        qry.Append(",");
                    }

                    if (amount_authorizedChanged)
                    {
                        qry.Append("amount_authorized =" + amount_authorizedDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (commentChanged)
                    {
                        qry.Append("comment =" + commentDbString);
                        qry.Append(",");
                    }

                    if (processed_tranChanged)
                    {
                        qry.Append("processed_tran =" + processed_tranDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (generated_atChanged)
                    {
                        qry.Append("generated_at =" + generated_atDbString);
                        qry.Append(",");
                    }

                    if (start_indexChanged)
                    {
                        qry.Append("start_index =" + start_indexDbString);
                        qry.Append(",");
                    }

                    if (end_indexChanged)
                    {
                        qry.Append("end_index =" + end_indexDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (is_eligibleChanged)
                    {
                        qry.Append("is_eligible =" + is_eligibleDbString);
                        qry.Append(",");
                    }

                    if (transaction_start_timeChanged)
                    {
                        qry.Append("transaction_start_time =" + transaction_start_timeDbString);
                        qry.Append(",");
                    }

                    if (transaction_end_timeChanged)
                    {
                        qry.Append("transaction_end_time =" + transaction_end_timeDbString);
                        qry.Append(",");
                    }

                    if (card_taken_timeChanged)
                    {
                        qry.Append("card_taken_time =" + card_taken_timeDbString);
                        qry.Append(",");
                    }

                    if (is_disputed_transactionChanged)
                    {
                        qry.Append("is_disputed_transaction =" + is_disputed_transactionDbString);
                        qry.Append(",");
                    }

                    if (host_tsnChanged)
                    {
                        qry.Append("host_tsn =" + host_tsnDbString);
                        qry.Append(",");
                    }

                    if (account_noChanged)
                    {
                        qry.Append("account_no =" + account_noDbString);
                        qry.Append(",");
                    }

                    if (posting_dateChanged)
                    {
                        qry.Append("posting_date =" + posting_dateDbString);
                        qry.Append(",");
                    }

                    if (currencyChanged)
                    {
                        qry.Append("currency =" + currencyDbString);
                        qry.Append(",");
                    }

                    if (transaction_type_idChanged)
                    {
                        qry.Append("transaction_type_id =" + transaction_type_idDbString);
                        qry.Append(",");
                    }

                    if (networkChanged)
                    {
                        qry.Append("network =" + networkDbString);
                        qry.Append(",");
                    }

                    if (is_cardlessChanged)
                    {
                        qry.Append("is_cardless =" + is_cardlessDbString);
                        qry.Append(",");
                    }

                    if (customer_idChanged)
                    {
                        qry.Append("customer_id =" + customer_idDbString);
                        qry.Append(",");
                    }

                    if (bank_nameChanged)
                    {
                        qry.Append("bank_name =" + bank_nameDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_parsed_bna_transaction_id = " + ej_parsed_bna_transaction_idDbString);
                    qry.Append(" and trxn_datetime = " + trxn_datetimeDbString);
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Ej_parsed_bna_transaction whereej_parsed_bna_transaction_id= " + ej_parsed_bna_transaction_id + " and trxn_datetime= " + trxn_datetime;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjParsedBnaTransactions(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_bna_transaction where " + where, DatabaseName.Tx);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_parsed_bna_transaction_id = 0,
            trxn_datetime = 1,
            terminal_id = 2,
            seq = 3,
            account_type = 4,
            pan = 5,
            consumer_message_id = 6,
            dispute_status = 7,
            amount_authorized = 8,
            status = 9,
            comment = 10,
            processed_tran = 11,
            atm_id = 12,
            generated_at = 13,
            start_index = 14,
            end_index = 15,
            task_id = 16,
            is_eligible = 17,
            transaction_start_time = 18,
            transaction_end_time = 19,
            card_taken_time = 20,
            is_disputed_transaction = 21,
            host_tsn = 22,
            account_no = 23,
            posting_date = 24,
            currency = 25,
            transaction_type_id = 26,
            network = 27,
            is_cardless = 28,
            customer_id = 29,
            bank_name = 30
        }
        #endregion
        public DataTable BulkSave(List<EjParsedBnaTransaction> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_parsed_bna_transaction";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjParsedBnaTransaction.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjParsedBnaTransaction> transList, ref DataTable dt)
        {
            foreach (EjParsedBnaTransaction tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_parsed_bna_transaction_id"] = ConnectionFactory.GetNextId(DatabaseName.Tx);
                Row["trxn_datetime"] = tran.TrxnDatetime;
                Row["terminal_id"] = tran.TerminalId;
                Row["seq"] = tran.Seq;
                Row["account_type"] = tran.AccountType;
                Row["pan"] = tran.Pan;
                Row["consumer_message_id"] = tran.ConsumerMessageId;
                Row["dispute_status"] = tran.DisputeStatus;
                Row["amount_authorized"] = tran.AmountAuthorized;
                Row["status"] = tran.Status;
                Row["comment"] = tran.Comment;
                Row["processed_tran"] = tran.ProcessedTran;
                Row["atm_id"] = tran.AtmId;
                Row["generated_at"] = tran.GeneratedAt;
                Row["start_index"] = tran.StartIndex;
                Row["end_index"] = tran.EndIndex;
                Row["task_id"] = tran.TaskId;
                Row["is_eligible"] = tran.IsEligible;
                Row["transaction_start_time"] = tran.TransactionStartTime;
                Row["transaction_end_time"] = tran.TransactionEndTime;
                Row["card_taken_time"] = tran.CardTakenTime;
                Row["is_disputed_transaction"] = tran.IsDisputedTransaction;
                Row["host_tsn"] = tran.HostTsn;
                Row["account_no"] = tran.AccountNo;
                Row["posting_date"] = tran.PostingDate;
                Row["currency"] = tran.Currency;
                Row["transaction_type_id"] = tran.TransactionTypeId;
                Row["network"] = tran.Network;
                Row["is_cardless"] = tran.IsCardless;
                Row["customer_id"] = tran.CustomerId;
                Row["bank_name"] = tran.BankName;
                dt.Rows.Add(Row);
            }
        }
    }
}
