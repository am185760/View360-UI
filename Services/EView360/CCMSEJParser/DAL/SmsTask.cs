using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Data.SqlClient;

namespace Avanza.iSuite.DAL
{
    [Serializable()]
    public class SmsTask
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public SmsTask() { }
        public SmsTask(int sms_task_id, int retry_remaining, DateTime creation_time, int template_id, int atm_id, int user_id)
        {
            this.retry_remaining = retry_remaining;
            this.retry_remainingChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.template_id = template_id;
            this.template_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
        }
        public SmsTask(string refrence_no, int retry_remaining, DateTime creation_time, DateTime? last_invoked_at, string failure_reason, DateTime? end_time, int? atm_alert_id, int? captured_transaction_id, int template_id, string status, int atm_id, string transaction_friendly_name, string sms_service_ref_no, int user_id, string pan, string account_no, string tsn, int? task_id, bool? is_eligible, string bank_name)
        {
            this.refrence_no = refrence_no;
            this.refrence_noChanged = true;
            this.retry_remaining = retry_remaining;
            this.retry_remainingChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.atm_alert_id = atm_alert_id;
            this.atm_alert_idChanged = true;
            this.captured_transaction_id = captured_transaction_id;
            this.captured_transaction_idChanged = true;
            this.template_id = template_id;
            this.template_idChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.transaction_friendly_name = transaction_friendly_name;
            this.transaction_friendly_nameChanged = true;
            this.sms_service_ref_no = sms_service_ref_no;
            this.sms_service_ref_noChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
        }
        private SmsTask(int sms_task_id, string refrence_no, int retry_remaining, DateTime creation_time, DateTime? last_invoked_at, string failure_reason, DateTime? end_time, int? atm_alert_id, int? captured_transaction_id, int template_id, string status, int atm_id, string transaction_friendly_name, string sms_service_ref_no, int user_id, string pan, string account_no, string tsn, int? task_id, bool? is_eligible, string bank_name)
        {
            this.sms_task_id = sms_task_id;
            this.sms_task_idChanged = true;
            this.refrence_no = refrence_no;
            this.refrence_noChanged = true;
            this.retry_remaining = retry_remaining;
            this.retry_remainingChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.atm_alert_id = atm_alert_id;
            this.atm_alert_idChanged = true;
            this.captured_transaction_id = captured_transaction_id;
            this.captured_transaction_idChanged = true;
            this.template_id = template_id;
            this.template_idChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.transaction_friendly_name = transaction_friendly_name;
            this.transaction_friendly_nameChanged = true;
            this.sms_service_ref_no = sms_service_ref_no;
            this.sms_service_ref_noChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
        }

        #region members and properties for columns

        #region SmsTaskId
        private bool sms_task_idChanged = false;
        private int sms_task_id;
        public int SmsTaskId
        {
            get { return sms_task_id; }
            set
            {
                sms_task_id = value;
                sms_task_idChanged = true;
            }
        }
        private string sms_task_idDbString
        {
            get
            {
                return sms_task_id.ToString();
            }
        }
        #endregion
        #region RefrenceNo
        private bool refrence_noChanged = false;
        private string refrence_no;
        public string RefrenceNo
        {
            get { return refrence_no; }
            set
            {
                refrence_no = value;
                refrence_noChanged = true;
            }
        }
        private string refrence_noDbString
        {
            get
            {
                if (this.refrence_no != null)
                    return string.Format("'{0}'", refrence_no);
                else
                    return "null";
            }
        }
        #endregion
        #region RetryRemaining
        private bool retry_remainingChanged = false;
        private int retry_remaining;
        public int RetryRemaining
        {
            get { return retry_remaining; }
            set
            {
                retry_remaining = value;
                retry_remainingChanged = true;
            }
        }
        private string retry_remainingDbString
        {
            get
            {
                return retry_remaining.ToString();
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
        #region AtmAlertId
        private bool atm_alert_idChanged = false;
        private int? atm_alert_id;
        public int? AtmAlertId
        {
            get { return atm_alert_id; }
            set
            {
                atm_alert_id = value;
                atm_alert_idChanged = true;
            }
        }
        private string atm_alert_idDbString
        {
            get
            {
                if (this.atm_alert_id.HasValue)
                    return atm_alert_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CapturedTransactionId
        private bool captured_transaction_idChanged = false;
        private int? captured_transaction_id;
        public int? CapturedTransactionId
        {
            get { return captured_transaction_id; }
            set
            {
                captured_transaction_id = value;
                captured_transaction_idChanged = true;
            }
        }
        private string captured_transaction_idDbString
        {
            get
            {
                if (this.captured_transaction_id.HasValue)
                    return captured_transaction_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TemplateId
        private bool template_idChanged = false;
        private int template_id;
        public int TemplateId
        {
            get { return template_id; }
            set
            {
                template_id = value;
                template_idChanged = true;
            }
        }
        private string template_idDbString
        {
            get
            {
                return template_id.ToString();
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
        #region TransactionFriendlyName
        private bool transaction_friendly_nameChanged = false;
        private string transaction_friendly_name;
        public string TransactionFriendlyName
        {
            get { return transaction_friendly_name; }
            set
            {
                transaction_friendly_name = value;
                transaction_friendly_nameChanged = true;
            }
        }
        private string transaction_friendly_nameDbString
        {
            get
            {
                if (this.transaction_friendly_name != null)
                    return string.Format("'{0}'", transaction_friendly_name);
                else
                    return "null";
            }
        }
        #endregion
        #region SmsServiceRefNo
        private bool sms_service_ref_noChanged = false;
        private string sms_service_ref_no;
        public string SmsServiceRefNo
        {
            get { return sms_service_ref_no; }
            set
            {
                sms_service_ref_no = value;
                sms_service_ref_noChanged = true;
            }
        }
        private string sms_service_ref_noDbString
        {
            get
            {
                if (this.sms_service_ref_no != null)
                    return string.Format("'{0}'", sms_service_ref_no);
                else
                    return "null";
            }
        }
        #endregion
        #region UserId
        private bool user_idChanged = false;
        private int user_id;
        public int UserId
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
                return user_id.ToString();
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
        #region Tsn
        private bool tsnChanged = false;
        private string tsn;
        public string Tsn
        {
            get { return tsn; }
            set
            {
                tsn = value;
                tsnChanged = true;
            }
        }
        private string tsnDbString
        {
            get
            {
                if (this.tsn != null)
                    return string.Format("'{0}'", tsn);
                else
                    return "null";
            }
        }
        #endregion
        #region TaskId
        private bool task_idChanged = false;
        private int? task_id;
        public int? TaskId
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
        #region IsEligible
        private bool is_eligibleChanged = false;
        private bool? is_eligible;
        public bool? IsEligible
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
                if (this.is_eligible.HasValue)
                    return is_eligible.Value ? "1" : "0";
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

        #region SmsTaskReader
        public class SmsTaskReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            SmsTask currentSmsTask;
            Columns columns;
            bool partialRead = false;
            private SmsTaskReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public SmsTaskReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public SmsTaskReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentSmsTask; }

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
                    currentSmsTask = new SmsTask();
                    if (partialRead)
                    {
                        if ((columns & Columns.sms_task_id) == Columns.sms_task_id && reader["sms_task_id"] != DBNull.Value)
                            currentSmsTask.sms_task_id = (int)reader["sms_task_id"];
                        if ((columns & Columns.refrence_no) == Columns.refrence_no && reader["refrence_no"] != DBNull.Value)
                            currentSmsTask.refrence_no = (string)reader["refrence_no"];
                        if ((columns & Columns.retry_remaining) == Columns.retry_remaining && reader["retry_remaining"] != DBNull.Value)
                            currentSmsTask.retry_remaining = (int)reader["retry_remaining"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentSmsTask.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"] != DBNull.Value)
                            currentSmsTask.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                        if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"] != DBNull.Value)
                            currentSmsTask.failure_reason = (string)reader["failure_reason"];
                        if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"] != DBNull.Value)
                            currentSmsTask.end_time = (DateTime?)reader["end_time"];
                        if ((columns & Columns.atm_alert_id) == Columns.atm_alert_id && reader["atm_alert_id"] != DBNull.Value)
                            currentSmsTask.atm_alert_id = (int?)reader["atm_alert_id"];
                        if ((columns & Columns.captured_transaction_id) == Columns.captured_transaction_id && reader["captured_transaction_id"] != DBNull.Value)
                            currentSmsTask.captured_transaction_id = (int?)reader["captured_transaction_id"];
                        if ((columns & Columns.template_id) == Columns.template_id && reader["template_id"] != DBNull.Value)
                            currentSmsTask.template_id = (int)reader["template_id"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentSmsTask.status = (string)reader["status"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentSmsTask.atm_id = (int)reader["atm_id"];
                        if ((columns & Columns.transaction_friendly_name) == Columns.transaction_friendly_name && reader["transaction_friendly_name"] != DBNull.Value)
                            currentSmsTask.transaction_friendly_name = (string)reader["transaction_friendly_name"];
                        if ((columns & Columns.sms_service_ref_no) == Columns.sms_service_ref_no && reader["sms_service_ref_no"] != DBNull.Value)
                            currentSmsTask.sms_service_ref_no = (string)reader["sms_service_ref_no"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentSmsTask.user_id = (int)reader["user_id"];
                        if ((columns & Columns.pan) == Columns.pan && reader["pan"] != DBNull.Value)
                            currentSmsTask.pan = (string)reader["pan"];
                        if ((columns & Columns.account_no) == Columns.account_no && reader["account_no"] != DBNull.Value)
                            currentSmsTask.account_no = (string)reader["account_no"];
                        if ((columns & Columns.tsn) == Columns.tsn && reader["tsn"] != DBNull.Value)
                            currentSmsTask.tsn = (string)reader["tsn"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentSmsTask.task_id = (int?)reader["task_id"];
                        if ((columns & Columns.is_eligible) == Columns.is_eligible && reader["is_eligible"] != DBNull.Value)
                            currentSmsTask.is_eligible = (bool?)reader["is_eligible"];
                        if ((columns & Columns.bank_name) == Columns.bank_name && reader["bank_name"] != DBNull.Value)
                            currentSmsTask.bank_name = (string)reader["bank_name"];

                    }
                    else
                    {
                        if (reader["sms_task_id"] != DBNull.Value)
                            currentSmsTask.sms_task_id = (int)reader["sms_task_id"];
                        if (reader["refrence_no"] != DBNull.Value)
                            currentSmsTask.refrence_no = (string)reader["refrence_no"];
                        if (reader["retry_remaining"] != DBNull.Value)
                            currentSmsTask.retry_remaining = (int)reader["retry_remaining"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentSmsTask.creation_time = (DateTime)reader["creation_time"];
                        if (reader["last_invoked_at"] != DBNull.Value)
                            currentSmsTask.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                        if (reader["failure_reason"] != DBNull.Value)
                            currentSmsTask.failure_reason = (string)reader["failure_reason"];
                        if (reader["end_time"] != DBNull.Value)
                            currentSmsTask.end_time = (DateTime?)reader["end_time"];
                        if (reader["atm_alert_id"] != DBNull.Value)
                            currentSmsTask.atm_alert_id = (int?)reader["atm_alert_id"];
                        if (reader["captured_transaction_id"] != DBNull.Value)
                            currentSmsTask.captured_transaction_id = (int?)reader["captured_transaction_id"];
                        if (reader["template_id"] != DBNull.Value)
                            currentSmsTask.template_id = (int)reader["template_id"];
                        if (reader["status"] != DBNull.Value)
                            currentSmsTask.status = (string)reader["status"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentSmsTask.atm_id = (int)reader["atm_id"];
                        if (reader["transaction_friendly_name"] != DBNull.Value)
                            currentSmsTask.transaction_friendly_name = (string)reader["transaction_friendly_name"];
                        if (reader["sms_service_ref_no"] != DBNull.Value)
                            currentSmsTask.sms_service_ref_no = (string)reader["sms_service_ref_no"];
                        if (reader["user_id"] != DBNull.Value)
                            currentSmsTask.user_id = (int)reader["user_id"];
                        if (reader["pan"] != DBNull.Value)
                            currentSmsTask.pan = (string)reader["pan"];
                        if (reader["account_no"] != DBNull.Value)
                            currentSmsTask.account_no = (string)reader["account_no"];
                        if (reader["tsn"] != DBNull.Value)
                            currentSmsTask.tsn = (string)reader["tsn"];
                        if (reader["task_id"] != DBNull.Value)
                            currentSmsTask.task_id = (int?)reader["task_id"];
                        if (reader["is_eligible"] != DBNull.Value)
                            currentSmsTask.is_eligible = (bool?)reader["is_eligible"];
                        if (reader["bank_name"] != DBNull.Value)
                            currentSmsTask.bank_name = (string)reader["bank_name"];
                    }

                    currentSmsTask.isNewEntity = false;
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

            public SmsTask CurrentSmsTask
            {
                get { return currentSmsTask; }
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


        #region SmsTask functions

        public static SmsTaskReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.sms_task_id == (Columns.sms_task_id & columns))
                qry.Append("sms_task_id,");
            if (Columns.refrence_no == (Columns.refrence_no & columns))
                qry.Append("refrence_no,");
            if (Columns.retry_remaining == (Columns.retry_remaining & columns))
                qry.Append("retry_remaining,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
                qry.Append("last_invoked_at,");
            if (Columns.failure_reason == (Columns.failure_reason & columns))
                qry.Append("failure_reason,");
            if (Columns.end_time == (Columns.end_time & columns))
                qry.Append("end_time,");
            if (Columns.atm_alert_id == (Columns.atm_alert_id & columns))
                qry.Append("atm_alert_id,");
            if (Columns.captured_transaction_id == (Columns.captured_transaction_id & columns))
                qry.Append("captured_transaction_id,");
            if (Columns.template_id == (Columns.template_id & columns))
                qry.Append("template_id,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.transaction_friendly_name == (Columns.transaction_friendly_name & columns))
                qry.Append("transaction_friendly_name,");
            if (Columns.sms_service_ref_no == (Columns.sms_service_ref_no & columns))
                qry.Append("sms_service_ref_no,");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.pan == (Columns.pan & columns))
                qry.Append("pan,");
            if (Columns.account_no == (Columns.account_no & columns))
                qry.Append("account_no,");
            if (Columns.tsn == (Columns.tsn & columns))
                qry.Append("tsn,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.is_eligible == (Columns.is_eligible & columns))
                qry.Append("is_eligible,");
            if (Columns.bank_name == (Columns.bank_name & columns))
                qry.Append("bank_name,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Sms_task ");

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
            return new SmsTaskReader(cmd.ExecuteReader(), conn, columns);
        }

        static public SmsTaskReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static SmsTaskReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select sms_task_id,refrence_no,retry_remaining,creation_time,last_invoked_at,failure_reason,end_time,atm_alert_id,captured_transaction_id,template_id,status,atm_id,transaction_friendly_name,sms_service_ref_no,user_id,pan,account_no,tsn,task_id,is_eligible,bank_name from Sms_task ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new SmsTaskReader(cmd.ExecuteReader(), conn);
        }

        static public SmsTaskReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static SmsTask LoadSmsTask(string where)
        {
            SmsTaskReader reader = SmsTask.ExecuteReader(where);
            SmsTask _smstask = null;
            if (reader.Read())
                _smstask = reader.CurrentSmsTask;
            reader.Close();
            return _smstask;
        }

        public static SmsTask LoadSmsTask(string where, IDbConnection conn)
        {
            SmsTaskReader reader = SmsTask.ExecuteReader(where, conn);
            SmsTask _smstask = null;
            if (reader.Read())
                _smstask = reader.CurrentSmsTask;
            reader.Close(false);
            return _smstask;
        }

        public static SmsTask LoadSmsTaskByPk(int sms_task_id)
        {
            return LoadSmsTask("sms_task_id=" + sms_task_id);
        }

        public static SmsTask LoadSmsTaskByPk(int sms_task_id, IDbConnection conn)
        {
            return LoadSmsTask(" sms_task_id=" + sms_task_id, conn);
        }

        public void Save()
        {
            if (sms_task_idChanged || refrence_noChanged || retry_remainingChanged || creation_timeChanged || last_invoked_atChanged || failure_reasonChanged || end_timeChanged || atm_alert_idChanged || captured_transaction_idChanged || template_idChanged || statusChanged || atm_idChanged || transaction_friendly_nameChanged || sms_service_ref_noChanged || user_idChanged || panChanged || account_noChanged || tsnChanged || task_idChanged || is_eligibleChanged || bank_nameChanged)
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
            if (sms_task_idChanged || refrence_noChanged || retry_remainingChanged || creation_timeChanged || last_invoked_atChanged || failure_reasonChanged || end_timeChanged || atm_alert_idChanged || captured_transaction_idChanged || template_idChanged || statusChanged || atm_idChanged || transaction_friendly_nameChanged || sms_service_ref_noChanged || user_idChanged || panChanged || account_noChanged || tsnChanged || task_idChanged || is_eligibleChanged || bank_nameChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Sms_task(sms_task_id,refrence_no,retry_remaining,creation_time,last_invoked_at,failure_reason,end_time,atm_alert_id,captured_transaction_id,template_id,status,atm_id,transaction_friendly_name,sms_service_ref_no,user_id,pan,account_no,tsn,task_id,is_eligible,bank_name) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.sms_task_id = ConnectionFactory.GetNextId();
                        qry.Append(this.sms_task_id);
                    } qry.Append(",");
                    qry.Append(refrence_noDbString + ",");
                    qry.Append(retry_remainingDbString + ",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(last_invoked_atDbString + ",");
                    qry.Append(failure_reasonDbString + ",");
                    qry.Append(end_timeDbString + ",");
                    qry.Append(atm_alert_idDbString + ",");
                    qry.Append(captured_transaction_idDbString + ",");
                    qry.Append(template_idDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(transaction_friendly_nameDbString + ",");
                    qry.Append(sms_service_ref_noDbString + ",");
                    qry.Append(user_idDbString + ",");
                    qry.Append(panDbString + ",");
                    qry.Append(account_noDbString + ",");
                    qry.Append(tsnDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(is_eligibleDbString + ",");
                    qry.Append(bank_nameDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(sms_task_idChanged || refrence_noChanged || retry_remainingChanged || creation_timeChanged || last_invoked_atChanged || failure_reasonChanged || end_timeChanged || atm_alert_idChanged || captured_transaction_idChanged || template_idChanged || statusChanged || atm_idChanged || transaction_friendly_nameChanged || sms_service_ref_noChanged || user_idChanged || panChanged || account_noChanged || tsnChanged || task_idChanged || is_eligibleChanged || bank_nameChanged))
                        return;
                    qry.Append("UPDATE Sms_task set "); if (refrence_noChanged)
                    {
                        qry.Append("refrence_no =" + refrence_noDbString);
                        qry.Append(",");
                    }

                    if (retry_remainingChanged)
                    {
                        qry.Append("retry_remaining =" + retry_remainingDbString);
                        qry.Append(",");
                    }

                    if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
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

                    if (end_timeChanged)
                    {
                        qry.Append("end_time =" + end_timeDbString);
                        qry.Append(",");
                    }

                    if (atm_alert_idChanged)
                    {
                        qry.Append("atm_alert_id =" + atm_alert_idDbString);
                        qry.Append(",");
                    }

                    if (captured_transaction_idChanged)
                    {
                        qry.Append("captured_transaction_id =" + captured_transaction_idDbString);
                        qry.Append(",");
                    }

                    if (template_idChanged)
                    {
                        qry.Append("template_id =" + template_idDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (transaction_friendly_nameChanged)
                    {
                        qry.Append("transaction_friendly_name =" + transaction_friendly_nameDbString);
                        qry.Append(",");
                    }

                    if (sms_service_ref_noChanged)
                    {
                        qry.Append("sms_service_ref_no =" + sms_service_ref_noDbString);
                        qry.Append(",");
                    }

                    if (user_idChanged)
                    {
                        qry.Append("user_id =" + user_idDbString);
                        qry.Append(",");
                    }

                    if (panChanged)
                    {
                        qry.Append("pan =" + panDbString);
                        qry.Append(",");
                    }

                    if (account_noChanged)
                    {
                        qry.Append("account_no =" + account_noDbString);
                        qry.Append(",");
                    }

                    if (tsnChanged)
                    {
                        qry.Append("tsn =" + tsnDbString);
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

                    if (bank_nameChanged)
                    {
                        qry.Append("bank_name =" + bank_nameDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("sms_task_id = " + sms_task_idDbString);
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
            cmd.CommandText = "DELETE Sms_task wheresms_task_id= " + sms_task_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteSmsTasks(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Sms_task where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            sms_task_id = 1,
            refrence_no = 2,
            retry_remaining = 4,
            creation_time = 8,
            last_invoked_at = 16,
            failure_reason = 32,
            end_time = 64,
            atm_alert_id = 128,
            captured_transaction_id = 256,
            template_id = 512,
            status = 1024,
            atm_id = 2048,
            transaction_friendly_name = 4096,
            sms_service_ref_no = 8192,
            user_id = 16384,
            pan = 32768,
            account_no = 65536,
            tsn = 131072,
            task_id = 262144,
            is_eligible = 524288,
            bank_name = 1048576
        }
        #endregion
        public DataTable BulkSave(List<SmsTask> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Sms_task";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(SmsTask.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<SmsTask> transList, ref DataTable dt)
        {
            foreach (SmsTask tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["sms_task_id"] = ConnectionFactory.GetNextId();
                Row["refrence_no"] = tran.RefrenceNo;
                Row["retry_remaining"] = tran.RetryRemaining;
                Row["creation_time"] = tran.CreationTime;
                Row["last_invoked_at"] = tran.LastInvokedAt;
                Row["failure_reason"] = tran.FailureReason;
                Row["end_time"] = tran.EndTime;
                Row["atm_alert_id"] = tran.AtmAlertId;
                Row["captured_transaction_id"] = tran.CapturedTransactionId;
                Row["template_id"] = tran.TemplateId;
                Row["status"] = tran.Status;
                Row["atm_id"] = tran.AtmId;
                Row["transaction_friendly_name"] = tran.TransactionFriendlyName;
                Row["sms_service_ref_no"] = tran.SmsServiceRefNo;
                Row["user_id"] = tran.UserId;
                Row["pan"] = tran.Pan;
                Row["account_no"] = tran.AccountNo;
                Row["tsn"] = tran.Tsn;
                Row["task_id"] = tran.TaskId;
                Row["is_eligible"] = tran.IsEligible;
                Row["bank_name"] = tran.BankName;
                dt.Rows.Add(Row);
            }
        }
    }
}