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
    public class CapturedTransactions
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CapturedTransactions() { }
        public CapturedTransactions(long captured_transactions_id, long transaction_rule_id, long transaction_id, DateTime captured_at)
        {
            this.transaction_rule_id = transaction_rule_id;
            this.transaction_rule_idChanged = true;
            this.transaction_id = transaction_id;
            this.transaction_idChanged = true;
            this.captured_at = captured_at;
            this.captured_atChanged = true;
        }
        public CapturedTransactions(long transaction_rule_id, long transaction_id, DateTime captured_at, DateTime? expiration_time, long? user_id, string comments, long? ej_captured_card_id, decimal? amount_claimed, long? ej_parsed_bna_transactions_id, string trxn_status, long? ej_parsed_transactions_id, long? ej_parsed_cpm_transactions_id, long? task_id, bool? is_locked, decimal? amount_credited, string internal_team_comment, DateTime? locked_datetime, decimal? amount, string modified_by)
        {
            this.transaction_rule_id = transaction_rule_id;
            this.transaction_rule_idChanged = true;
            this.transaction_id = transaction_id;
            this.transaction_idChanged = true;
            this.captured_at = captured_at;
            this.captured_atChanged = true;
            this.expiration_time = expiration_time;
            this.expiration_timeChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.comments = comments;
            this.commentsChanged = true;
            this.ej_captured_card_id = ej_captured_card_id;
            this.ej_captured_card_idChanged = true;
            this.amount_claimed = amount_claimed;
            this.amount_claimedChanged = true;
            this.ej_parsed_bna_transactions_id = ej_parsed_bna_transactions_id;
            this.ej_parsed_bna_transactions_idChanged = true;
            this.trxn_status = trxn_status;
            this.trxn_statusChanged = true;
            this.ej_parsed_transactions_id = ej_parsed_transactions_id;
            this.ej_parsed_transactions_idChanged = true;
            this.ej_parsed_cpm_transactions_id = ej_parsed_cpm_transactions_id;
            this.ej_parsed_cpm_transactions_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_locked = is_locked;
            this.is_lockedChanged = true;
            this.amount_credited = amount_credited;
            this.amount_creditedChanged = true;
            this.internal_team_comment = internal_team_comment;
            this.internal_team_commentChanged = true;
            this.locked_datetime = locked_datetime;
            this.locked_datetimeChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
        }
        private CapturedTransactions(long captured_transactions_id, long transaction_rule_id, long transaction_id, DateTime captured_at, DateTime? expiration_time, long? user_id, string comments, long? ej_captured_card_id, decimal? amount_claimed, long? ej_parsed_bna_transactions_id, string trxn_status, long? ej_parsed_transactions_id, long? ej_parsed_cpm_transactions_id, long? task_id, bool? is_locked, decimal? amount_credited, string internal_team_comment, DateTime? locked_datetime, decimal? amount, string modified_by)
        {
            this.captured_transactions_id = captured_transactions_id;
            this.captured_transactions_idChanged = true;
            this.transaction_rule_id = transaction_rule_id;
            this.transaction_rule_idChanged = true;
            this.transaction_id = transaction_id;
            this.transaction_idChanged = true;
            this.captured_at = captured_at;
            this.captured_atChanged = true;
            this.expiration_time = expiration_time;
            this.expiration_timeChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.comments = comments;
            this.commentsChanged = true;
            this.ej_captured_card_id = ej_captured_card_id;
            this.ej_captured_card_idChanged = true;
            this.amount_claimed = amount_claimed;
            this.amount_claimedChanged = true;
            this.ej_parsed_bna_transactions_id = ej_parsed_bna_transactions_id;
            this.ej_parsed_bna_transactions_idChanged = true;
            this.trxn_status = trxn_status;
            this.trxn_statusChanged = true;
            this.ej_parsed_transactions_id = ej_parsed_transactions_id;
            this.ej_parsed_transactions_idChanged = true;
            this.ej_parsed_cpm_transactions_id = ej_parsed_cpm_transactions_id;
            this.ej_parsed_cpm_transactions_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_locked = is_locked;
            this.is_lockedChanged = true;
            this.amount_credited = amount_credited;
            this.amount_creditedChanged = true;
            this.internal_team_comment = internal_team_comment;
            this.internal_team_commentChanged = true;
            this.locked_datetime = locked_datetime;
            this.locked_datetimeChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
        }

        #region members and properties for columns

        #region CapturedTransactionsId
        private bool captured_transactions_idChanged = false;
        private long captured_transactions_id;
        public long CapturedTransactionsId
        {
            get { return captured_transactions_id; }
            set
            {
                captured_transactions_id = value;
                captured_transactions_idChanged = true;
            }
        }
        private string captured_transactions_idDbString
        {
            get
            {
                return captured_transactions_id.ToString();
            }
        }
        #endregion
        #region TransactionRuleId
        private bool transaction_rule_idChanged = false;
        private long transaction_rule_id;
        public long TransactionRuleId
        {
            get { return transaction_rule_id; }
            set
            {
                transaction_rule_id = value;
                transaction_rule_idChanged = true;
            }
        }
        private string transaction_rule_idDbString
        {
            get
            {
                return transaction_rule_id.ToString();
            }
        }
        #endregion
        #region TransactionId
        private bool transaction_idChanged = false;
        private long transaction_id;
        public long TransactionId
        {
            get { return transaction_id; }
            set
            {
                transaction_id = value;
                transaction_idChanged = true;
            }
        }
        private string transaction_idDbString
        {
            get
            {
                return transaction_id.ToString();
            }
        }
        #endregion
        #region CapturedAt
        private bool captured_atChanged = false;
        private DateTime captured_at;
        public DateTime CapturedAt
        {
            get { return captured_at; }
            set
            {
                captured_at = value;
                captured_atChanged = true;
            }
        }
        private string captured_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", captured_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region ExpirationTime
        private bool expiration_timeChanged = false;
        private DateTime? expiration_time;
        public DateTime? ExpirationTime
        {
            get { return expiration_time; }
            set
            {
                expiration_time = value;
                expiration_timeChanged = true;
            }
        }
        private string expiration_timeDbString
        {
            get
            {
                if (this.expiration_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", expiration_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region UserId
        private bool user_idChanged = false;
        private long? user_id;
        public long? UserId
        {
            get { return user_id; }
            set
            {
                user_id = value;
                user_idChanged = true;
            }
        }
        private string user_idDbString
        {
            get
            {
                if (this.user_id.HasValue)
                    return user_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Comments
        private bool commentsChanged = false;
        private string comments;
        public string Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                commentsChanged = true;
            }
        }
        private string commentsDbString
        {
            get
            {
                if (this.comments != null)
                    return string.Format("'{0}'", comments);
                else
                    return "null";
            }
        }
        #endregion
        #region EjCapturedCardId
        private bool ej_captured_card_idChanged = false;
        private long? ej_captured_card_id;
        public long? EjCapturedCardId
        {
            get { return ej_captured_card_id; }
            set
            {
                ej_captured_card_id = value;
                ej_captured_card_idChanged = true;
            }
        }
        private string ej_captured_card_idDbString
        {
            get
            {
                if (this.ej_captured_card_id.HasValue)
                    return ej_captured_card_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AmountClaimed
        private bool amount_claimedChanged = false;
        private decimal? amount_claimed;
        public decimal? AmountClaimed
        {
            get { return amount_claimed; }
            set
            {
                amount_claimed = value;
                amount_claimedChanged = true;
            }
        }
        private string amount_claimedDbString
        {
            get
            {
                if (this.amount_claimed.HasValue)
                    return amount_claimed.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EjParsedBnaTransactionsId
        private bool ej_parsed_bna_transactions_idChanged = false;
        private long? ej_parsed_bna_transactions_id;
        public long? EjParsedBnaTransactionsId
        {
            get { return ej_parsed_bna_transactions_id; }
            set
            {
                ej_parsed_bna_transactions_id = value;
                ej_parsed_bna_transactions_idChanged = true;
            }
        }
        private string ej_parsed_bna_transactions_idDbString
        {
            get
            {
                if (this.ej_parsed_bna_transactions_id.HasValue)
                    return ej_parsed_bna_transactions_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TrxnStatus
        private bool trxn_statusChanged = false;
        private string trxn_status;
        public string TrxnStatus
        {
            get { return trxn_status; }
            set
            {
                trxn_status = value;
                trxn_statusChanged = true;
            }
        }
        private string trxn_statusDbString
        {
            get
            {
                if (this.trxn_status != null)
                    return string.Format("'{0}'", trxn_status);
                else
                    return "null";
            }
        }
        #endregion
        #region EjParsedTransactionsId
        private bool ej_parsed_transactions_idChanged = false;
        private long? ej_parsed_transactions_id;
        public long? EjParsedTransactionsId
        {
            get { return ej_parsed_transactions_id; }
            set
            {
                ej_parsed_transactions_id = value;
                ej_parsed_transactions_idChanged = true;
            }
        }
        private string ej_parsed_transactions_idDbString
        {
            get
            {
                if (this.ej_parsed_transactions_id.HasValue)
                    return ej_parsed_transactions_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EjParsedCpmTransactionsId
        private bool ej_parsed_cpm_transactions_idChanged = false;
        private long? ej_parsed_cpm_transactions_id;
        public long? EjParsedCpmTransactionsId
        {
            get { return ej_parsed_cpm_transactions_id; }
            set
            {
                ej_parsed_cpm_transactions_id = value;
                ej_parsed_cpm_transactions_idChanged = true;
            }
        }
        private string ej_parsed_cpm_transactions_idDbString
        {
            get
            {
                if (this.ej_parsed_cpm_transactions_id.HasValue)
                    return ej_parsed_cpm_transactions_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TaskId
        private bool task_idChanged = false;
        private long? task_id;
        public long? TaskId
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
                if (this.task_id.HasValue)
                    return task_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsLocked
        private bool is_lockedChanged = false;
        private bool? is_locked;
        public bool? IsLocked
        {
            get { return is_locked; }
            set
            {
                is_locked = value;
                is_lockedChanged = true;
            }
        }
        private string is_lockedDbString
        {
            get
            {
                if (this.is_locked.HasValue)
                    return is_locked.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region AmountCredited
        private bool amount_creditedChanged = false;
        private decimal? amount_credited;
        public decimal? AmountCredited
        {
            get { return amount_credited; }
            set
            {
                amount_credited = value;
                amount_creditedChanged = true;
            }
        }
        private string amount_creditedDbString
        {
            get
            {
                if (this.amount_credited.HasValue)
                    return amount_credited.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region InternalTeamComment
        private bool internal_team_commentChanged = false;
        private string internal_team_comment;
        public string InternalTeamComment
        {
            get { return internal_team_comment; }
            set
            {
                internal_team_comment = value;
                internal_team_commentChanged = true;
            }
        }
        private string internal_team_commentDbString
        {
            get
            {
                if (this.internal_team_comment != null)
                    return string.Format("'{0}'", internal_team_comment);
                else
                    return "null";
            }
        }
        #endregion
        #region LockedDatetime
        private bool locked_datetimeChanged = false;
        private DateTime? locked_datetime;
        public DateTime? LockedDatetime
        {
            get { return locked_datetime; }
            set
            {
                locked_datetime = value;
                locked_datetimeChanged = true;
            }
        }
        private string locked_datetimeDbString
        {
            get
            {
                if (this.locked_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", locked_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Amount
        private bool amountChanged = false;
        private decimal? amount;
        public decimal? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                amountChanged = true;
            }
        }
        private string amountDbString
        {
            get
            {
                if (this.amount.HasValue)
                    return amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ModifiedBy
        private bool modified_byChanged = false;
        private string modified_by;
        public string ModifiedBy
        {
            get { return modified_by; }
            set
            {
                modified_by = value;
                modified_byChanged = true;
            }
        }
        private string modified_byDbString
        {
            get
            {
                if (this.modified_by != null)
                    return string.Format("'{0}'", modified_by);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region CapturedTransactionsReader
        public class CapturedTransactionsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CapturedTransactions currentCapturedTransactions;
            Columns columns;
            bool partialRead = false;
            private CapturedTransactionsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CapturedTransactionsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CapturedTransactionsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCapturedTransactions; }

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
                    currentCapturedTransactions = new CapturedTransactions();
                    if (partialRead)
                    {
                        if ((columns & Columns.captured_transactions_id) == Columns.captured_transactions_id && reader["captured_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.captured_transactions_id = (long)reader["captured_transactions_id"];
                        if ((columns & Columns.transaction_rule_id) == Columns.transaction_rule_id && reader["transaction_rule_id"] != DBNull.Value)
                            currentCapturedTransactions.transaction_rule_id = (long)reader["transaction_rule_id"];
                        if ((columns & Columns.transaction_id) == Columns.transaction_id && reader["transaction_id"] != DBNull.Value)
                            currentCapturedTransactions.transaction_id = (long)reader["transaction_id"];
                        if ((columns & Columns.captured_at) == Columns.captured_at && reader["captured_at"] != DBNull.Value)
                            currentCapturedTransactions.captured_at = (DateTime)reader["captured_at"];
                        if ((columns & Columns.expiration_time) == Columns.expiration_time && reader["expiration_time"] != DBNull.Value)
                            currentCapturedTransactions.expiration_time = (DateTime?)reader["expiration_time"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentCapturedTransactions.user_id = (long?)reader["user_id"];
                        if ((columns & Columns.comments) == Columns.comments && reader["comments"] != DBNull.Value)
                            currentCapturedTransactions.comments = (string)reader["comments"];
                        if ((columns & Columns.ej_captured_card_id) == Columns.ej_captured_card_id && reader["ej_captured_card_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_captured_card_id = (long?)reader["ej_captured_card_id"];
                        if ((columns & Columns.amount_claimed) == Columns.amount_claimed && reader["amount_claimed"] != DBNull.Value)
                            currentCapturedTransactions.amount_claimed = (decimal?)reader["amount_claimed"];
                        if ((columns & Columns.ej_parsed_bna_transactions_id) == Columns.ej_parsed_bna_transactions_id && reader["ej_parsed_bna_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_parsed_bna_transactions_id = (long?)reader["ej_parsed_bna_transactions_id"];
                        if ((columns & Columns.trxn_status) == Columns.trxn_status && reader["trxn_status"] != DBNull.Value)
                            currentCapturedTransactions.trxn_status = (string)reader["trxn_status"];
                        if ((columns & Columns.ej_parsed_transactions_id) == Columns.ej_parsed_transactions_id && reader["ej_parsed_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_parsed_transactions_id = (long?)reader["ej_parsed_transactions_id"];
                        if ((columns & Columns.ej_parsed_cpm_transactions_id) == Columns.ej_parsed_cpm_transactions_id && reader["ej_parsed_cpm_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_parsed_cpm_transactions_id = (long?)reader["ej_parsed_cpm_transactions_id"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentCapturedTransactions.task_id = (long?)reader["task_id"];
                        if ((columns & Columns.is_locked) == Columns.is_locked && reader["is_locked"] != DBNull.Value)
                            currentCapturedTransactions.is_locked = (bool?)reader["is_locked"];
                        if ((columns & Columns.amount_credited) == Columns.amount_credited && reader["amount_credited"] != DBNull.Value)
                            currentCapturedTransactions.amount_credited = (decimal?)reader["amount_credited"];
                        if ((columns & Columns.internal_team_comment) == Columns.internal_team_comment && reader["internal_team_comment"] != DBNull.Value)
                            currentCapturedTransactions.internal_team_comment = (string)reader["internal_team_comment"];
                        if ((columns & Columns.locked_datetime) == Columns.locked_datetime && reader["locked_datetime"] != DBNull.Value)
                            currentCapturedTransactions.locked_datetime = (DateTime?)reader["locked_datetime"];
                        if ((columns & Columns.amount) == Columns.amount && reader["amount"] != DBNull.Value)
                            currentCapturedTransactions.amount = (decimal?)reader["amount"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentCapturedTransactions.modified_by = (string)reader["modified_by"];

                    }
                    else
                    {
                        if (reader["captured_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.captured_transactions_id = (long)reader["captured_transactions_id"];
                        if (reader["transaction_rule_id"] != DBNull.Value)
                            currentCapturedTransactions.transaction_rule_id = (long)reader["transaction_rule_id"];
                        if (reader["transaction_id"] != DBNull.Value)
                            currentCapturedTransactions.transaction_id = (long)reader["transaction_id"];
                        if (reader["captured_at"] != DBNull.Value)
                            currentCapturedTransactions.captured_at = (DateTime)reader["captured_at"];
                        if (reader["expiration_time"] != DBNull.Value)
                            currentCapturedTransactions.expiration_time = (DateTime?)reader["expiration_time"];
                        if (reader["user_id"] != DBNull.Value)
                            currentCapturedTransactions.user_id = (long?)reader["user_id"];
                        if (reader["comments"] != DBNull.Value)
                            currentCapturedTransactions.comments = (string)reader["comments"];
                        if (reader["ej_captured_card_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_captured_card_id = (long?)reader["ej_captured_card_id"];
                        if (reader["amount_claimed"] != DBNull.Value)
                            currentCapturedTransactions.amount_claimed = (decimal?)reader["amount_claimed"];
                        if (reader["ej_parsed_bna_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_parsed_bna_transactions_id = (long?)reader["ej_parsed_bna_transactions_id"];
                        if (reader["trxn_status"] != DBNull.Value)
                            currentCapturedTransactions.trxn_status = (string)reader["trxn_status"];
                        if (reader["ej_parsed_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_parsed_transactions_id = (long?)reader["ej_parsed_transactions_id"];
                        if (reader["ej_parsed_cpm_transactions_id"] != DBNull.Value)
                            currentCapturedTransactions.ej_parsed_cpm_transactions_id = (long?)reader["ej_parsed_cpm_transactions_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentCapturedTransactions.task_id = (long?)reader["task_id"];
                        if (reader["is_locked"] != DBNull.Value)
                            currentCapturedTransactions.is_locked = (bool?)reader["is_locked"];
                        if (reader["amount_credited"] != DBNull.Value)
                            currentCapturedTransactions.amount_credited = (decimal?)reader["amount_credited"];
                        if (reader["internal_team_comment"] != DBNull.Value)
                            currentCapturedTransactions.internal_team_comment = (string)reader["internal_team_comment"];
                        if (reader["locked_datetime"] != DBNull.Value)
                            currentCapturedTransactions.locked_datetime = (DateTime?)reader["locked_datetime"];
                        if (reader["amount"] != DBNull.Value)
                            currentCapturedTransactions.amount = (decimal?)reader["amount"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentCapturedTransactions.modified_by = (string)reader["modified_by"];
                    }

                    currentCapturedTransactions.isNewEntity = false;
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

            public CapturedTransactions CurrentCapturedTransactions
            {
                get { return currentCapturedTransactions; }
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


        #region CapturedTransactions functions

        public static CapturedTransactionsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.captured_transactions_id == (Columns.captured_transactions_id & columns))
                qry.Append("captured_transactions_id,");
            if (Columns.transaction_rule_id == (Columns.transaction_rule_id & columns))
                qry.Append("transaction_rule_id,");
            if (Columns.transaction_id == (Columns.transaction_id & columns))
                qry.Append("transaction_id,");
            if (Columns.captured_at == (Columns.captured_at & columns))
                qry.Append("captured_at,");
            if (Columns.expiration_time == (Columns.expiration_time & columns))
                qry.Append("expiration_time,");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.comments == (Columns.comments & columns))
                qry.Append("comments,");
            if (Columns.ej_captured_card_id == (Columns.ej_captured_card_id & columns))
                qry.Append("ej_captured_card_id,");
            if (Columns.amount_claimed == (Columns.amount_claimed & columns))
                qry.Append("amount_claimed,");
            if (Columns.ej_parsed_bna_transactions_id == (Columns.ej_parsed_bna_transactions_id & columns))
                qry.Append("ej_parsed_bna_transactions_id,");
            if (Columns.trxn_status == (Columns.trxn_status & columns))
                qry.Append("trxn_status,");
            if (Columns.ej_parsed_transactions_id == (Columns.ej_parsed_transactions_id & columns))
                qry.Append("ej_parsed_transactions_id,");
            if (Columns.ej_parsed_cpm_transactions_id == (Columns.ej_parsed_cpm_transactions_id & columns))
                qry.Append("ej_parsed_cpm_transactions_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.is_locked == (Columns.is_locked & columns))
                qry.Append("is_locked,");
            if (Columns.amount_credited == (Columns.amount_credited & columns))
                qry.Append("amount_credited,");
            if (Columns.internal_team_comment == (Columns.internal_team_comment & columns))
                qry.Append("internal_team_comment,");
            if (Columns.locked_datetime == (Columns.locked_datetime & columns))
                qry.Append("locked_datetime,");
            if (Columns.amount == (Columns.amount & columns))
                qry.Append("amount,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Captured_transactions ");

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
            return new CapturedTransactionsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CapturedTransactionsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CapturedTransactionsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select captured_transactions_id,transaction_rule_id,transaction_id,captured_at,expiration_time,user_id,comments,ej_captured_card_id,amount_claimed,ej_parsed_bna_transactions_id,trxn_status,ej_parsed_transactions_id,ej_parsed_cpm_transactions_id,task_id,is_locked,amount_credited,internal_team_comment,locked_datetime,amount,modified_b from Captured_transactions ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CapturedTransactionsReader(cmd.ExecuteReader(), conn);
        }

        static public CapturedTransactionsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static CapturedTransactions LoadCapturedTransactions(string where)
        {
            CapturedTransactionsReader reader = CapturedTransactions.ExecuteReader(where);
            CapturedTransactions _capturedtransactions = null;
            if (reader.Read())
                _capturedtransactions = reader.CurrentCapturedTransactions;
            reader.Close();
            return _capturedtransactions;
        }

        public static CapturedTransactions LoadCapturedTransactions(string where, IDbConnection conn)
        {
            CapturedTransactionsReader reader = CapturedTransactions.ExecuteReader(where, conn);
            CapturedTransactions _capturedtransactions = null;
            if (reader.Read())
                _capturedtransactions = reader.CurrentCapturedTransactions;
            reader.Close(false);
            return _capturedtransactions;
        }

        public static CapturedTransactions LoadCapturedTransactionsByPk(long captured_transactions_id, DateTime captured_at)
        {
            return LoadCapturedTransactions("captured_transactions_id=" + captured_transactions_id + " and captured_at=Convert(datetime,'" + captured_at.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)");
        }

        public static CapturedTransactions LoadCapturedTransactionsByPk(long captured_transactions_id, DateTime captured_at, IDbConnection conn)
        {
            return LoadCapturedTransactions(" captured_transactions_id=" + captured_transactions_id + " and captured_at=Convert(datetime,'" + captured_at.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)", conn);
        }

        public void Save()
        {
            if (captured_transactions_idChanged || transaction_rule_idChanged || transaction_idChanged || captured_atChanged || expiration_timeChanged || user_idChanged || commentsChanged || ej_captured_card_idChanged || amount_claimedChanged || ej_parsed_bna_transactions_idChanged || trxn_statusChanged || ej_parsed_transactions_idChanged || ej_parsed_cpm_transactions_idChanged || task_idChanged || is_lockedChanged || amount_creditedChanged || internal_team_commentChanged || locked_datetimeChanged || amountChanged || modified_byChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Cash).CreateCommand());
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
            if (captured_transactions_idChanged || transaction_rule_idChanged || transaction_idChanged || captured_atChanged || expiration_timeChanged || user_idChanged || commentsChanged || ej_captured_card_idChanged || amount_claimedChanged || ej_parsed_bna_transactions_idChanged || trxn_statusChanged || ej_parsed_transactions_idChanged || ej_parsed_cpm_transactions_idChanged || task_idChanged || is_lockedChanged || amount_creditedChanged || internal_team_commentChanged || locked_datetimeChanged || amountChanged || modified_byChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Captured_transactions(captured_transactions_id,transaction_rule_id,transaction_id,captured_at,expiration_time,user_id,comments,ej_captured_card_id,amount_claimed,ej_parsed_bna_transactions_id,trxn_status,ej_parsed_transactions_id,ej_parsed_cpm_transactions_id,task_id,is_locked,amount_credited,internal_team_comment,locked_datetime,amount,modified_by) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.captured_transactions_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.captured_transactions_id);
                    }
                    qry.Append(",");
                    qry.Append(transaction_rule_idDbString + ",");
                    qry.Append(transaction_idDbString + ",");
                    qry.Append(captured_atDbString + ",");
                    qry.Append(expiration_timeDbString + ",");
                    qry.Append(user_idDbString + ",");
                    qry.Append(commentsDbString + ",");
                    qry.Append(ej_captured_card_idDbString + ",");
                    qry.Append(amount_claimedDbString + ",");
                    qry.Append(ej_parsed_bna_transactions_idDbString + ",");
                    qry.Append(trxn_statusDbString + ",");
                    qry.Append(ej_parsed_transactions_idDbString + ",");
                    qry.Append(ej_parsed_cpm_transactions_idDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(is_lockedDbString + ",");
                    qry.Append(amount_creditedDbString + ",");
                    qry.Append(internal_team_commentDbString + ",");
                    qry.Append(locked_datetimeDbString + ",");
                    qry.Append(amountDbString + ",");
                    qry.Append(modified_byDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(captured_transactions_idChanged || transaction_rule_idChanged || transaction_idChanged || captured_atChanged || expiration_timeChanged || user_idChanged || commentsChanged || ej_captured_card_idChanged || amount_claimedChanged || ej_parsed_bna_transactions_idChanged || trxn_statusChanged || ej_parsed_transactions_idChanged || ej_parsed_cpm_transactions_idChanged || task_idChanged || is_lockedChanged || amount_creditedChanged || internal_team_commentChanged || locked_datetimeChanged || amountChanged || modified_byChanged))
                        return;
                    qry.Append("UPDATE Captured_transactions set "); if (transaction_rule_idChanged)
                    {
                        qry.Append("transaction_rule_id =" + transaction_rule_idDbString);
                        qry.Append(",");
                    }

                    if (transaction_idChanged)
                    {
                        qry.Append("transaction_id =" + transaction_idDbString);
                        qry.Append(",");
                    }

                    if (expiration_timeChanged)
                    {
                        qry.Append("expiration_time =" + expiration_timeDbString);
                        qry.Append(",");
                    }

                    if (user_idChanged)
                    {
                        qry.Append("user_id =" + user_idDbString);
                        qry.Append(",");
                    }

                    if (commentsChanged)
                    {
                        qry.Append("comments =" + commentsDbString);
                        qry.Append(",");
                    }

                    if (ej_captured_card_idChanged)
                    {
                        qry.Append("ej_captured_card_id =" + ej_captured_card_idDbString);
                        qry.Append(",");
                    }

                    if (amount_claimedChanged)
                    {
                        qry.Append("amount_claimed =" + amount_claimedDbString);
                        qry.Append(",");
                    }

                    if (ej_parsed_bna_transactions_idChanged)
                    {
                        qry.Append("ej_parsed_bna_transactions_id =" + ej_parsed_bna_transactions_idDbString);
                        qry.Append(",");
                    }

                    if (trxn_statusChanged)
                    {
                        qry.Append("trxn_status =" + trxn_statusDbString);
                        qry.Append(",");
                    }

                    if (ej_parsed_transactions_idChanged)
                    {
                        qry.Append("ej_parsed_transactions_id =" + ej_parsed_transactions_idDbString);
                        qry.Append(",");
                    }

                    if (ej_parsed_cpm_transactions_idChanged)
                    {
                        qry.Append("ej_parsed_cpm_transactions_id =" + ej_parsed_cpm_transactions_idDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (is_lockedChanged)
                    {
                        qry.Append("is_locked =" + is_lockedDbString);
                        qry.Append(",");
                    }

                    if (amount_creditedChanged)
                    {
                        qry.Append("amount_credited =" + amount_creditedDbString);
                        qry.Append(",");
                    }

                    if (internal_team_commentChanged)
                    {
                        qry.Append("internal_team_comment =" + internal_team_commentDbString);
                        qry.Append(",");
                    }

                    if (locked_datetimeChanged)
                    {
                        qry.Append("locked_datetime =" + locked_datetimeDbString);
                        qry.Append(",");
                    }

                    if (amountChanged)
                    {
                        qry.Append("amount =" + amountDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("captured_transactions_id = " + captured_transactions_idDbString);
                    qry.Append(" and captured_at = " + captured_atDbString);
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Captured_transactions wherecaptured_transactions_id= " + captured_transactions_id + " and captured_at= " + captured_at;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCapturedTransactionss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Captured_transactions where " + where, DatabaseName.Cash); ;
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            captured_transactions_id = 0,
            transaction_rule_id = 1,
            transaction_id = 2,
            captured_at = 3,
            expiration_time = 4,
            user_id = 5,
            comments = 6,
            ej_captured_card_id = 7,
            amount_claimed = 8,
            ej_parsed_bna_transactions_id = 9,
            trxn_status = 10,
            ej_parsed_transactions_id = 11,
            ej_parsed_cpm_transactions_id = 12,
            task_id = 13,
            is_locked = 14,
            amount_credited = 15,
            internal_team_comment = 16,
            locked_datetime = 17,
            amount = 18,
            modified_by = 19
        }
        #endregion
        public DataTable BulkSave(List<CapturedTransactions> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Captured_transactions";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CapturedTransactions.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CapturedTransactions> transList, ref DataTable dt)
        {
            foreach (CapturedTransactions tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["captured_transactions_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["transaction_rule_id"] = tran.TransactionRuleId;
                Row["transaction_id"] = tran.TransactionId;
                Row["captured_at"] = tran.CapturedAt;
                Row["expiration_time"] = tran.ExpirationTime;
                Row["user_id"] = tran.UserId;
                Row["comments"] = tran.Comments;
                Row["ej_captured_card_id"] = tran.EjCapturedCardId;
                Row["amount_claimed"] = tran.AmountClaimed;
                Row["ej_parsed_bna_transactions_id"] = tran.EjParsedBnaTransactionsId;
                Row["trxn_status"] = tran.TrxnStatus;
                Row["ej_parsed_transactions_id"] = tran.EjParsedTransactionsId;
                Row["ej_parsed_cpm_transactions_id"] = tran.EjParsedCpmTransactionsId;
                Row["task_id"] = tran.TaskId;
                Row["is_locked"] = tran.IsLocked;
                Row["amount_credited"] = tran.AmountCredited;
                Row["internal_team_comment"] = tran.InternalTeamComment;
                Row["locked_datetime"] = tran.LockedDatetime;
                Row["amount"] = tran.Amount;
                Row["modified_by"] = tran.ModifiedBy;
                dt.Rows.Add(Row);
            }
        }
    }
}
