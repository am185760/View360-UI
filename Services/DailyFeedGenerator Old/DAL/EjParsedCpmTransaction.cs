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
    public class EjParsedCpmTransaction
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedCpmTransaction() { }
        public EjParsedCpmTransaction(int ej_parsed_cpm_transaction_id, int atm_id, DateTime generated_at, int start_index, int end_index, int task_id, bool is_eligible)
        {
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
        public EjParsedCpmTransaction(DateTime? trxn_datetime, string terminal_id, string seq, string account_type, string pan, decimal? deposit_amount, string result, string consumer_message_id, string dispute_status, string status, string comment, string reject_reason, string processed_tran, int atm_id, DateTime generated_at, decimal? dispense_amount, int start_index, int end_index, int task_id, bool is_eligible, bool? is_disputed_transaction, string host_tsn, string account_no, string micr, int? transaction_type_id, bool? is_cardless, string bank_name, string eida_name)
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
            this.deposit_amount = deposit_amount;
            this.deposit_amountChanged = true;
            this.result = result;
            this.resultChanged = true;
            this.consumer_message_id = consumer_message_id;
            this.consumer_message_idChanged = true;
            this.dispute_status = dispute_status;
            this.dispute_statusChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.comment = comment;
            this.commentChanged = true;
            this.reject_reason = reject_reason;
            this.reject_reasonChanged = true;
            this.processed_tran = processed_tran;
            this.processed_tranChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.dispense_amount = dispense_amount;
            this.dispense_amountChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.is_disputed_transaction = is_disputed_transaction;
            this.is_disputed_transactionChanged = true;
            this.host_tsn = host_tsn;
            this.host_tsnChanged = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.micr = micr;
            this.micrChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
            this.is_cardless = is_cardless;
            this.is_cardlessChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
            this.eida_name = eida_name;
            this.eida_nameChanged = true;
        }
        private EjParsedCpmTransaction(int ej_parsed_cpm_transaction_id, DateTime? trxn_datetime, string terminal_id, string seq, string account_type, string pan, decimal? deposit_amount, string result, string consumer_message_id, string dispute_status, string status, string comment, string reject_reason, string processed_tran, int atm_id, DateTime generated_at, decimal? dispense_amount, int start_index, int end_index, int task_id, bool is_eligible, bool? is_disputed_transaction, string host_tsn, string account_no, string micr, int? transaction_type_id, bool? is_cardless, string bank_name, string eida_name)
        {
            this.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_id;
            this.ej_parsed_cpm_transaction_idChanged = true;
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
            this.deposit_amount = deposit_amount;
            this.deposit_amountChanged = true;
            this.result = result;
            this.resultChanged = true;
            this.consumer_message_id = consumer_message_id;
            this.consumer_message_idChanged = true;
            this.dispute_status = dispute_status;
            this.dispute_statusChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.comment = comment;
            this.commentChanged = true;
            this.reject_reason = reject_reason;
            this.reject_reasonChanged = true;
            this.processed_tran = processed_tran;
            this.processed_tranChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.dispense_amount = dispense_amount;
            this.dispense_amountChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.is_disputed_transaction = is_disputed_transaction;
            this.is_disputed_transactionChanged = true;
            this.host_tsn = host_tsn;
            this.host_tsnChanged = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.micr = micr;
            this.micrChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
            this.is_cardless = is_cardless;
            this.is_cardlessChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
            this.eida_name = eida_name;
            this.eida_nameChanged = true;
        }

        #region members and properties for columns

        #region EjParsedCpmTransactionId
        private bool ej_parsed_cpm_transaction_idChanged = false;
        private int ej_parsed_cpm_transaction_id;
        public int EjParsedCpmTransactionId
        {
            get { return ej_parsed_cpm_transaction_id; }
            set
            {
                ej_parsed_cpm_transaction_id = value;
                ej_parsed_cpm_transaction_idChanged = true;
            }
        }
        private string ej_parsed_cpm_transaction_idDbString
        {
            get
            {
                return ej_parsed_cpm_transaction_id.ToString();
            }
        }
        #endregion
        #region TrxnDatetime
        private bool trxn_datetimeChanged = false;
        private DateTime? trxn_datetime;
        public DateTime? TrxnDatetime
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
                if (this.trxn_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", trxn_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
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
        #region DepositAmount
        private bool deposit_amountChanged = false;
        private decimal? deposit_amount;
        public decimal? DepositAmount
        {
            get { return deposit_amount; }
            set
            {
                deposit_amount = value;
                deposit_amountChanged = true;
            }
        }
        private string deposit_amountDbString
        {
            get
            {
                if (this.deposit_amount.HasValue)
                    return deposit_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Result
        private bool resultChanged = false;
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                resultChanged = true;
            }
        }
        private string resultDbString
        {
            get
            {
                if (this.result != null)
                    return string.Format("'{0}'", result);
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
        #region RejectReason
        private bool reject_reasonChanged = false;
        private string reject_reason;
        public string RejectReason
        {
            get { return reject_reason; }
            set
            {
                reject_reason = value;
                reject_reasonChanged = true;
            }
        }
        private string reject_reasonDbString
        {
            get
            {
                if (this.reject_reason != null)
                    return string.Format("'{0}'", reject_reason);
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
        #region DispenseAmount
        private bool dispense_amountChanged = false;
        private decimal? dispense_amount;
        public decimal? DispenseAmount
        {
            get { return dispense_amount; }
            set
            {
                dispense_amount = value;
                dispense_amountChanged = true;
            }
        }
        private string dispense_amountDbString
        {
            get
            {
                if (this.dispense_amount.HasValue)
                    return dispense_amount.ToString();
                else
                    return "null";
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
        private int task_id;
        public int TaskId
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
        #region Micr
        private bool micrChanged = false;
        private string micr;
        public string Micr
        {
            get { return micr; }
            set
            {
                micr = value;
                micrChanged = true;
            }
        }
        private string micrDbString
        {
            get
            {
                if (this.micr != null)
                    return string.Format("'{0}'", micr);
                else
                    return "null";
            }
        }
        #endregion
        #region TransactionTypeId
        private bool transaction_type_idChanged = false;
        private int? transaction_type_id;
        public int? TransactionTypeId
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
        #region EidaName
        private bool eida_nameChanged = false;
        private string eida_name;
        public string EidaName
        {
            get { return eida_name; }
            set
            {
                eida_name = value;
                eida_nameChanged = true;
            }
        }
        private string eida_nameDbString
        {
            get
            {
                if (this.eida_name != null)
                    return string.Format("'{0}'", eida_name);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region EjParsedCpmTransactionReader
        public class EjParsedCpmTransactionReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjParsedCpmTransaction currentEjParsedCpmTransaction;
            Columns columns;
            bool partialRead = false;
            private EjParsedCpmTransactionReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjParsedCpmTransactionReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjParsedCpmTransactionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjParsedCpmTransaction; }

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
                    currentEjParsedCpmTransaction = new EjParsedCpmTransaction();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_parsed_cpm_transaction_id) == Columns.ej_parsed_cpm_transaction_id && reader["ej_parsed_cpm_transaction_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.ej_parsed_cpm_transaction_id = (int)reader["ej_parsed_cpm_transaction_id"];
                        if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"] != DBNull.Value)
                            currentEjParsedCpmTransaction.trxn_datetime = (DateTime?)reader["trxn_datetime"];
                        if ((columns & Columns.terminal_id) == Columns.terminal_id && reader["terminal_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.terminal_id = (string)reader["terminal_id"];
                        if ((columns & Columns.seq) == Columns.seq && reader["seq"] != DBNull.Value)
                            currentEjParsedCpmTransaction.seq = (string)reader["seq"];
                        if ((columns & Columns.account_type) == Columns.account_type && reader["account_type"] != DBNull.Value)
                            currentEjParsedCpmTransaction.account_type = (string)reader["account_type"];
                        if ((columns & Columns.pan) == Columns.pan && reader["pan"] != DBNull.Value)
                            currentEjParsedCpmTransaction.pan = (string)reader["pan"];
                        if ((columns & Columns.deposit_amount) == Columns.deposit_amount && reader["deposit_amount"] != DBNull.Value)
                            currentEjParsedCpmTransaction.deposit_amount = (decimal?)reader["deposit_amount"];
                        if ((columns & Columns.result) == Columns.result && reader["result"] != DBNull.Value)
                            currentEjParsedCpmTransaction.result = (string)reader["result"];
                        if ((columns & Columns.consumer_message_id) == Columns.consumer_message_id && reader["consumer_message_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.consumer_message_id = (string)reader["consumer_message_id"];
                        if ((columns & Columns.dispute_status) == Columns.dispute_status && reader["dispute_status"] != DBNull.Value)
                            currentEjParsedCpmTransaction.dispute_status = (string)reader["dispute_status"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentEjParsedCpmTransaction.status = (string)reader["status"];
                        if ((columns & Columns.comment) == Columns.comment && reader["comment"] != DBNull.Value)
                            currentEjParsedCpmTransaction.comment = (string)reader["comment"];
                        if ((columns & Columns.reject_reason) == Columns.reject_reason && reader["reject_reason"] != DBNull.Value)
                            currentEjParsedCpmTransaction.reject_reason = (string)reader["reject_reason"];
                        if ((columns & Columns.processed_tran) == Columns.processed_tran && reader["processed_tran"] != DBNull.Value)
                            currentEjParsedCpmTransaction.processed_tran = (string)reader["processed_tran"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.atm_id = (int)reader["atm_id"];
                        if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"] != DBNull.Value)
                            currentEjParsedCpmTransaction.generated_at = (DateTime)reader["generated_at"];
                        if ((columns & Columns.dispense_amount) == Columns.dispense_amount && reader["dispense_amount"] != DBNull.Value)
                            currentEjParsedCpmTransaction.dispense_amount = (decimal?)reader["dispense_amount"];
                        if ((columns & Columns.start_index) == Columns.start_index && reader["start_index"] != DBNull.Value)
                            currentEjParsedCpmTransaction.start_index = (int)reader["start_index"];
                        if ((columns & Columns.end_index) == Columns.end_index && reader["end_index"] != DBNull.Value)
                            currentEjParsedCpmTransaction.end_index = (int)reader["end_index"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.task_id = (int)reader["task_id"];
                        if ((columns & Columns.is_eligible) == Columns.is_eligible && reader["is_eligible"] != DBNull.Value)
                            currentEjParsedCpmTransaction.is_eligible = (bool)reader["is_eligible"];
                        if ((columns & Columns.is_disputed_transaction) == Columns.is_disputed_transaction && reader["is_disputed_transaction"] != DBNull.Value)
                            currentEjParsedCpmTransaction.is_disputed_transaction = (bool?)reader["is_disputed_transaction"];
                        if ((columns & Columns.host_tsn) == Columns.host_tsn && reader["host_tsn"] != DBNull.Value)
                            currentEjParsedCpmTransaction.host_tsn = (string)reader["host_tsn"];
                        if ((columns & Columns.account_no) == Columns.account_no && reader["account_no"] != DBNull.Value)
                            currentEjParsedCpmTransaction.account_no = (string)reader["account_no"];
                        if ((columns & Columns.micr) == Columns.micr && reader["micr"] != DBNull.Value)
                            currentEjParsedCpmTransaction.micr = (string)reader["micr"];
                        if ((columns & Columns.transaction_type_id) == Columns.transaction_type_id && reader["transaction_type_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.transaction_type_id = (int?)reader["transaction_type_id"];
                        if ((columns & Columns.is_cardless) == Columns.is_cardless && reader["is_cardless"] != DBNull.Value)
                            currentEjParsedCpmTransaction.is_cardless = (bool?)reader["is_cardless"];
                        if ((columns & Columns.bank_name) == Columns.bank_name && reader["bank_name"] != DBNull.Value)
                            currentEjParsedCpmTransaction.bank_name = (string)reader["bank_name"];
                        if ((columns & Columns.eida_name) == Columns.eida_name && reader["eida_name"] != DBNull.Value)
                            currentEjParsedCpmTransaction.eida_name = (string)reader["eida_name"];

                    }
                    else
                    {
                        if (reader["ej_parsed_cpm_transaction_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.ej_parsed_cpm_transaction_id = (int)reader["ej_parsed_cpm_transaction_id"];
                        if (reader["trxn_datetime"] != DBNull.Value)
                            currentEjParsedCpmTransaction.trxn_datetime = (DateTime?)reader["trxn_datetime"];
                        if (reader["terminal_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.terminal_id = (string)reader["terminal_id"];
                        if (reader["seq"] != DBNull.Value)
                            currentEjParsedCpmTransaction.seq = (string)reader["seq"];
                        if (reader["account_type"] != DBNull.Value)
                            currentEjParsedCpmTransaction.account_type = (string)reader["account_type"];
                        if (reader["pan"] != DBNull.Value)
                            currentEjParsedCpmTransaction.pan = (string)reader["pan"];
                        if (reader["deposit_amount"] != DBNull.Value)
                            currentEjParsedCpmTransaction.deposit_amount = (decimal?)reader["deposit_amount"];
                        if (reader["result"] != DBNull.Value)
                            currentEjParsedCpmTransaction.result = (string)reader["result"];
                        if (reader["consumer_message_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.consumer_message_id = (string)reader["consumer_message_id"];
                        if (reader["dispute_status"] != DBNull.Value)
                            currentEjParsedCpmTransaction.dispute_status = (string)reader["dispute_status"];
                        if (reader["status"] != DBNull.Value)
                            currentEjParsedCpmTransaction.status = (string)reader["status"];
                        if (reader["comment"] != DBNull.Value)
                            currentEjParsedCpmTransaction.comment = (string)reader["comment"];
                        if (reader["reject_reason"] != DBNull.Value)
                            currentEjParsedCpmTransaction.reject_reason = (string)reader["reject_reason"];
                        if (reader["processed_tran"] != DBNull.Value)
                            currentEjParsedCpmTransaction.processed_tran = (string)reader["processed_tran"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.atm_id = (int)reader["atm_id"];
                        if (reader["generated_at"] != DBNull.Value)
                            currentEjParsedCpmTransaction.generated_at = (DateTime)reader["generated_at"];
                        if (reader["dispense_amount"] != DBNull.Value)
                            currentEjParsedCpmTransaction.dispense_amount = (decimal?)reader["dispense_amount"];
                        if (reader["start_index"] != DBNull.Value)
                            currentEjParsedCpmTransaction.start_index = (int)reader["start_index"];
                        if (reader["end_index"] != DBNull.Value)
                            currentEjParsedCpmTransaction.end_index = (int)reader["end_index"];
                        if (reader["task_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.task_id = (int)reader["task_id"];
                        if (reader["is_eligible"] != DBNull.Value)
                            currentEjParsedCpmTransaction.is_eligible = (bool)reader["is_eligible"];
                        if (reader["is_disputed_transaction"] != DBNull.Value)
                            currentEjParsedCpmTransaction.is_disputed_transaction = (bool?)reader["is_disputed_transaction"];
                        if (reader["host_tsn"] != DBNull.Value)
                            currentEjParsedCpmTransaction.host_tsn = (string)reader["host_tsn"];
                        if (reader["account_no"] != DBNull.Value)
                            currentEjParsedCpmTransaction.account_no = (string)reader["account_no"];
                        if (reader["micr"] != DBNull.Value)
                            currentEjParsedCpmTransaction.micr = (string)reader["micr"];
                        if (reader["transaction_type_id"] != DBNull.Value)
                            currentEjParsedCpmTransaction.transaction_type_id = (int?)reader["transaction_type_id"];
                        if (reader["is_cardless"] != DBNull.Value)
                            currentEjParsedCpmTransaction.is_cardless = (bool?)reader["is_cardless"];
                        if (reader["bank_name"] != DBNull.Value)
                            currentEjParsedCpmTransaction.bank_name = (string)reader["bank_name"];
                        if (reader["eida_name"] != DBNull.Value)
                            currentEjParsedCpmTransaction.eida_name = (string)reader["eida_name"];
                    }

                    currentEjParsedCpmTransaction.isNewEntity = false;
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

            public EjParsedCpmTransaction CurrentEjParsedCpmTransaction
            {
                get { return currentEjParsedCpmTransaction; }
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


        #region EjParsedCpmTransaction functions

        public static EjParsedCpmTransactionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_parsed_cpm_transaction_id == (Columns.ej_parsed_cpm_transaction_id & columns))
                qry.Append("ej_parsed_cpm_transaction_id,");
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
            if (Columns.deposit_amount == (Columns.deposit_amount & columns))
                qry.Append("deposit_amount,");
            if (Columns.result == (Columns.result & columns))
                qry.Append("result,");
            if (Columns.consumer_message_id == (Columns.consumer_message_id & columns))
                qry.Append("consumer_message_id,");
            if (Columns.dispute_status == (Columns.dispute_status & columns))
                qry.Append("dispute_status,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.comment == (Columns.comment & columns))
                qry.Append("comment,");
            if (Columns.reject_reason == (Columns.reject_reason & columns))
                qry.Append("reject_reason,");
            if (Columns.processed_tran == (Columns.processed_tran & columns))
                qry.Append("processed_tran,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.generated_at == (Columns.generated_at & columns))
                qry.Append("generated_at,");
            if (Columns.dispense_amount == (Columns.dispense_amount & columns))
                qry.Append("dispense_amount,");
            if (Columns.start_index == (Columns.start_index & columns))
                qry.Append("start_index,");
            if (Columns.end_index == (Columns.end_index & columns))
                qry.Append("end_index,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.is_eligible == (Columns.is_eligible & columns))
                qry.Append("is_eligible,");
            if (Columns.is_disputed_transaction == (Columns.is_disputed_transaction & columns))
                qry.Append("is_disputed_transaction,");
            if (Columns.host_tsn == (Columns.host_tsn & columns))
                qry.Append("host_tsn,");
            if (Columns.account_no == (Columns.account_no & columns))
                qry.Append("account_no,");
            if (Columns.micr == (Columns.micr & columns))
                qry.Append("micr,");
            if (Columns.transaction_type_id == (Columns.transaction_type_id & columns))
                qry.Append("transaction_type_id,");
            if (Columns.is_cardless == (Columns.is_cardless & columns))
                qry.Append("is_cardless,");
            if (Columns.bank_name == (Columns.bank_name & columns))
                qry.Append("bank_name,");
            if (Columns.eida_name == (Columns.eida_name & columns))
                qry.Append("eida_name,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_parsed_cpm_transaction ");

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
            return new EjParsedCpmTransactionReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjParsedCpmTransactionReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjParsedCpmTransactionReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select ej_parsed_cpm_transaction_id,trxn_datetime,terminal_id,seq,account_type,pan,deposit_amount,result,consumer_message_id,dispute_status,status,comment,reject_reason,processed_tran,atm_id,generated_at,dispense_amount,start_index,end_index,task_id,is_eligible,is_disputed_transaction,host_tsn,account_no,micr,transaction_type_id,is_cardless,bank_name,eida_name from Ej_parsed_cpm_transaction ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedCpmTransactionReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedCpmTransactionReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static EjParsedCpmTransaction LoadEjParsedCpmTransaction(string where)
        {
            EjParsedCpmTransactionReader reader = EjParsedCpmTransaction.ExecuteReader(where);
            EjParsedCpmTransaction _ejparsedcpmtransaction = null;
            if (reader.Read())
                _ejparsedcpmtransaction = reader.CurrentEjParsedCpmTransaction;
            reader.Close();
            return _ejparsedcpmtransaction;
        }

        public static EjParsedCpmTransaction LoadEjParsedCpmTransaction(string where, IDbConnection conn)
        {
            EjParsedCpmTransactionReader reader = EjParsedCpmTransaction.ExecuteReader(where, conn);
            EjParsedCpmTransaction _ejparsedcpmtransaction = null;
            if (reader.Read())
                _ejparsedcpmtransaction = reader.CurrentEjParsedCpmTransaction;
            reader.Close(false);
            return _ejparsedcpmtransaction;
        }

        public static EjParsedCpmTransaction LoadEjParsedCpmTransactionByPk(int ej_parsed_cpm_transaction_id)
        {
            return LoadEjParsedCpmTransaction("ej_parsed_cpm_transaction_id=" + ej_parsed_cpm_transaction_id);
        }

        public static EjParsedCpmTransaction LoadEjParsedCpmTransactionByPk(int ej_parsed_cpm_transaction_id, IDbConnection conn)
        {
            return LoadEjParsedCpmTransaction(" ej_parsed_cpm_transaction_id=" + ej_parsed_cpm_transaction_id, conn);
        }

        public void Save()
        {
            if (ej_parsed_cpm_transaction_idChanged || trxn_datetimeChanged || terminal_idChanged || seqChanged || account_typeChanged || panChanged || deposit_amountChanged || resultChanged || consumer_message_idChanged || dispute_statusChanged || statusChanged || commentChanged || reject_reasonChanged || processed_tranChanged || atm_idChanged || generated_atChanged || dispense_amountChanged || start_indexChanged || end_indexChanged || task_idChanged || is_eligibleChanged || is_disputed_transactionChanged || host_tsnChanged || account_noChanged || micrChanged || transaction_type_idChanged || is_cardlessChanged || bank_nameChanged || eida_nameChanged)
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
            if (ej_parsed_cpm_transaction_idChanged || trxn_datetimeChanged || terminal_idChanged || seqChanged || account_typeChanged || panChanged || deposit_amountChanged || resultChanged || consumer_message_idChanged || dispute_statusChanged || statusChanged || commentChanged || reject_reasonChanged || processed_tranChanged || atm_idChanged || generated_atChanged || dispense_amountChanged || start_indexChanged || end_indexChanged || task_idChanged || is_eligibleChanged || is_disputed_transactionChanged || host_tsnChanged || account_noChanged || micrChanged || transaction_type_idChanged || is_cardlessChanged || bank_nameChanged || eida_nameChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_cpm_transaction(ej_parsed_cpm_transaction_id,trxn_datetime,terminal_id,seq,account_type,pan,deposit_amount,result,consumer_message_id,dispute_status,status,comment,reject_reason,processed_tran,atm_id,generated_at,dispense_amount,start_index,end_index,task_id,is_eligible,is_disputed_transaction,host_tsn,account_no,micr,transaction_type_id,is_cardless,bank_name,eida_name) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.ej_parsed_cpm_transaction_id = ConnectionFactory.GetNextId();
                        qry.Append(this.ej_parsed_cpm_transaction_id);
                    } qry.Append(",");
                    qry.Append(trxn_datetimeDbString + ",");
                    qry.Append(terminal_idDbString + ",");
                    qry.Append(seqDbString + ",");
                    qry.Append(account_typeDbString + ",");
                    qry.Append(panDbString + ",");
                    qry.Append(deposit_amountDbString + ",");
                    qry.Append(resultDbString + ",");
                    qry.Append(consumer_message_idDbString + ",");
                    qry.Append(dispute_statusDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(commentDbString + ",");
                    qry.Append(reject_reasonDbString + ",");
                    qry.Append(processed_tranDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(generated_atDbString + ",");
                    qry.Append(dispense_amountDbString + ",");
                    qry.Append(start_indexDbString + ",");
                    qry.Append(end_indexDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(is_eligibleDbString + ",");
                    qry.Append(is_disputed_transactionDbString + ",");
                    qry.Append(host_tsnDbString + ",");
                    qry.Append(account_noDbString + ",");
                    qry.Append(micrDbString + ",");
                    qry.Append(transaction_type_idDbString + ",");
                    qry.Append(is_cardlessDbString + ",");
                    qry.Append(bank_nameDbString + ",");
                    qry.Append(eida_nameDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_cpm_transaction_idChanged || trxn_datetimeChanged || terminal_idChanged || seqChanged || account_typeChanged || panChanged || deposit_amountChanged || resultChanged || consumer_message_idChanged || dispute_statusChanged || statusChanged || commentChanged || reject_reasonChanged || processed_tranChanged || atm_idChanged || generated_atChanged || dispense_amountChanged || start_indexChanged || end_indexChanged || task_idChanged || is_eligibleChanged || is_disputed_transactionChanged || host_tsnChanged || account_noChanged || micrChanged || transaction_type_idChanged || is_cardlessChanged || bank_nameChanged || eida_nameChanged))
                        return;
                    qry.Append("UPDATE Ej_parsed_cpm_transaction set "); if (trxn_datetimeChanged)
                    {
                        qry.Append("trxn_datetime =" + trxn_datetimeDbString);
                        qry.Append(",");
                    }

                    if (terminal_idChanged)
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

                    if (deposit_amountChanged)
                    {
                        qry.Append("deposit_amount =" + deposit_amountDbString);
                        qry.Append(",");
                    }

                    if (resultChanged)
                    {
                        qry.Append("result =" + resultDbString);
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

                    if (reject_reasonChanged)
                    {
                        qry.Append("reject_reason =" + reject_reasonDbString);
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

                    if (dispense_amountChanged)
                    {
                        qry.Append("dispense_amount =" + dispense_amountDbString);
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

                    if (micrChanged)
                    {
                        qry.Append("micr =" + micrDbString);
                        qry.Append(",");
                    }

                    if (transaction_type_idChanged)
                    {
                        qry.Append("transaction_type_id =" + transaction_type_idDbString);
                        qry.Append(",");
                    }

                    if (is_cardlessChanged)
                    {
                        qry.Append("is_cardless =" + is_cardlessDbString);
                        qry.Append(",");
                    }

                    if (bank_nameChanged)
                    {
                        qry.Append("bank_name =" + bank_nameDbString);
                        qry.Append(",");
                    }

                    if (eida_nameChanged)
                    {
                        qry.Append("eida_name =" + eida_nameDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_parsed_cpm_transaction_id = " + ej_parsed_cpm_transaction_idDbString);
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
            cmd.CommandText = "DELETE Ej_parsed_cpm_transaction where ej_parsed_cpm_transaction_id= " + ej_parsed_cpm_transaction_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjParsedCpmTransactions(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_cpm_transaction where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_parsed_cpm_transaction_id = 1,
            trxn_datetime = 2,
            terminal_id = 4,
            seq = 8,
            account_type = 16,
            pan = 32,
            deposit_amount = 64,
            result = 128,
            consumer_message_id = 256,
            dispute_status = 512,
            status = 1024,
            comment = 2048,
            reject_reason = 4096,
            processed_tran = 8192,
            atm_id = 16384,
            generated_at = 32768,
            dispense_amount = 65536,
            start_index = 131072,
            end_index = 262144,
            task_id = 524288,
            is_eligible = 1048576,
            is_disputed_transaction = 2097152,
            host_tsn = 4194304,
            account_no = 8388608,
            micr = 16777216,
            transaction_type_id = 33554432,
            is_cardless = 67108864,
            bank_name = 134217728,
            eida_name = 268435456
        }
        #endregion
        public DataTable BulkSave(List<EjParsedCpmTransaction> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_parsed_cpm_transaction";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjParsedCpmTransaction.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjParsedCpmTransaction> transList, ref DataTable dt)
        {
            foreach (EjParsedCpmTransaction tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_parsed_cpm_transaction_id"] = ConnectionFactory.GetNextId();
                Row["trxn_datetime"] = tran.TrxnDatetime;
                Row["terminal_id"] = tran.TerminalId;
                Row["seq"] = tran.Seq;
                Row["account_type"] = tran.AccountType;
                Row["pan"] = tran.Pan;
                Row["deposit_amount"] = tran.DepositAmount;
                Row["result"] = tran.Result;
                Row["consumer_message_id"] = tran.ConsumerMessageId;
                Row["dispute_status"] = tran.DisputeStatus;
                Row["status"] = tran.Status;
                Row["comment"] = tran.Comment;
                Row["reject_reason"] = tran.RejectReason;
                Row["processed_tran"] = tran.ProcessedTran;
                Row["atm_id"] = tran.AtmId;
                Row["generated_at"] = tran.GeneratedAt;
                Row["dispense_amount"] = tran.DispenseAmount;
                Row["start_index"] = tran.StartIndex;
                Row["end_index"] = tran.EndIndex;
                Row["task_id"] = tran.TaskId;
                Row["is_eligible"] = tran.IsEligible;
                Row["is_disputed_transaction"] = tran.IsDisputedTransaction;
                Row["host_tsn"] = tran.HostTsn;
                Row["account_no"] = tran.AccountNo;
                Row["micr"] = tran.Micr;
                Row["transaction_type_id"] = tran.TransactionTypeId;
                Row["is_cardless"] = tran.IsCardless;
                Row["bank_name"] = tran.BankName;
                Row["eida_name"] = tran.EidaName;
                dt.Rows.Add(Row);
            }
        }
    }
}