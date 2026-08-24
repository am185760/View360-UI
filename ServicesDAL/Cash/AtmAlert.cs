
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
 using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class AtmAlert
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public AtmAlert() { }
        public AtmAlert(long atm_id, long atm_alert_id, DateTime generated_at, long alert_type_id, int generate_at_retry_remaining, int resolve_at_retry_remaining, bool generate_notification_sent)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.alert_type_id = alert_type_id;
            this.alert_type_idChanged = true;
            this.generate_at_retry_remaining = generate_at_retry_remaining;
            this.generate_at_retry_remainingChanged = true;
            this.resolve_at_retry_remaining = resolve_at_retry_remaining;
            this.resolve_at_retry_remainingChanged = true;
            this.generate_notification_sent = generate_notification_sent;
            this.generate_notification_sentChanged = true;
        }
        public AtmAlert(long atm_id, DateTime generated_at, DateTime? resolve_at, long alert_type_id, DateTime? expiration_time, int generate_at_retry_remaining, int resolve_at_retry_remaining, DateTime? last_invoked_at, bool generate_notification_sent, bool? resolve_notification_sent, string failure_reason, string alert_msg, long? task_id, string entity_type, long? entity_id, int? event_count)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.resolve_at = resolve_at;
            this.resolve_atChanged = true;
            this.alert_type_id = alert_type_id;
            this.alert_type_idChanged = true;
            this.expiration_time = expiration_time;
            this.expiration_timeChanged = true;
            this.generate_at_retry_remaining = generate_at_retry_remaining;
            this.generate_at_retry_remainingChanged = true;
            this.resolve_at_retry_remaining = resolve_at_retry_remaining;
            this.resolve_at_retry_remainingChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
            this.generate_notification_sent = generate_notification_sent;
            this.generate_notification_sentChanged = true;
            this.resolve_notification_sent = resolve_notification_sent;
            this.resolve_notification_sentChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.alert_msg = alert_msg;
            this.alert_msgChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.entity_type = entity_type;
            this.entity_typeChanged = true;
            this.entity_id = entity_id;
            this.entity_idChanged = true;
            this.event_count = event_count;
            this.event_countChanged = true;
        }
        private AtmAlert(long atm_id, long atm_alert_id, DateTime generated_at, DateTime? resolve_at, long alert_type_id, DateTime? expiration_time, int generate_at_retry_remaining, int resolve_at_retry_remaining, DateTime? last_invoked_at, bool generate_notification_sent, bool? resolve_notification_sent, string failure_reason, string alert_msg, long? task_id, string entity_type, long? entity_id, int? event_count)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.atm_alert_id = atm_alert_id;
            this.atm_alert_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.resolve_at = resolve_at;
            this.resolve_atChanged = true;
            this.alert_type_id = alert_type_id;
            this.alert_type_idChanged = true;
            this.expiration_time = expiration_time;
            this.expiration_timeChanged = true;
            this.generate_at_retry_remaining = generate_at_retry_remaining;
            this.generate_at_retry_remainingChanged = true;
            this.resolve_at_retry_remaining = resolve_at_retry_remaining;
            this.resolve_at_retry_remainingChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
            this.generate_notification_sent = generate_notification_sent;
            this.generate_notification_sentChanged = true;
            this.resolve_notification_sent = resolve_notification_sent;
            this.resolve_notification_sentChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.alert_msg = alert_msg;
            this.alert_msgChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.entity_type = entity_type;
            this.entity_typeChanged = true;
            this.entity_id = entity_id;
            this.entity_idChanged = true;
            this.event_count = event_count;
            this.event_countChanged = true;
        }

        #region members and properties for columns

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
        #region AtmAlertId
        private bool atm_alert_idChanged = false;
        private long atm_alert_id;
        public long AtmAlertId
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
                return atm_alert_id.ToString();
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
        #region ResolveAt
        private bool resolve_atChanged = false;
        private DateTime? resolve_at;
        public DateTime? ResolveAt
        {
            get { return resolve_at; }
            set
            {
                resolve_at = value;
                resolve_atChanged = true;
            }
        }
        private string resolve_atDbString
        {
            get
            {
                if (this.resolve_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", resolve_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region AlertTypeId
        private bool alert_type_idChanged = false;
        private long alert_type_id;
        public long AlertTypeId
        {
            get { return alert_type_id; }
            set
            {
                alert_type_id = value;
                alert_type_idChanged = true;
            }
        }
        private string alert_type_idDbString
        {
            get
            {
                return alert_type_id.ToString();
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
        #region GenerateAtRetryRemaining
        private bool generate_at_retry_remainingChanged = false;
        private int generate_at_retry_remaining;
        public int GenerateAtRetryRemaining
        {
            get { return generate_at_retry_remaining; }
            set
            {
                generate_at_retry_remaining = value;
                generate_at_retry_remainingChanged = true;
            }
        }
        private string generate_at_retry_remainingDbString
        {
            get
            {
                return generate_at_retry_remaining.ToString();
            }
        }
        #endregion
        #region ResolveAtRetryRemaining
        private bool resolve_at_retry_remainingChanged = false;
        private int resolve_at_retry_remaining;
        public int ResolveAtRetryRemaining
        {
            get { return resolve_at_retry_remaining; }
            set
            {
                resolve_at_retry_remaining = value;
                resolve_at_retry_remainingChanged = true;
            }
        }
        private string resolve_at_retry_remainingDbString
        {
            get
            {
                return resolve_at_retry_remaining.ToString();
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
        #region GenerateNotificationSent
        private bool generate_notification_sentChanged = false;
        private bool generate_notification_sent;
        public bool GenerateNotificationSent
        {
            get { return generate_notification_sent; }
            set
            {
                generate_notification_sent = value;
                generate_notification_sentChanged = true;
            }
        }
        private string generate_notification_sentDbString
        {
            get
            {
                return generate_notification_sent ? "1" : "0";
            }
        }
        #endregion
        #region ResolveNotificationSent
        private bool resolve_notification_sentChanged = false;
        private bool? resolve_notification_sent;
        public bool? ResolveNotificationSent
        {
            get { return resolve_notification_sent; }
            set
            {
                resolve_notification_sent = value;
                resolve_notification_sentChanged = true;
            }
        }
        private string resolve_notification_sentDbString
        {
            get
            {
                if (this.resolve_notification_sent.HasValue)
                    return resolve_notification_sent.Value ? "1" : "0";
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
        #region AlertMsg
        private bool alert_msgChanged = false;
        private string alert_msg;
        public string AlertMsg
        {
            get { return alert_msg; }
            set
            {
                alert_msg = value;
                alert_msgChanged = true;
            }
        }
        private string alert_msgDbString
        {
            get
            {
                if (this.alert_msg != null)
                    return string.Format("'{0}'", alert_msg);
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
        #region EntityType
        private bool entity_typeChanged = false;
        private string entity_type;
        public string EntityType
        {
            get { return entity_type; }
            set
            {
                entity_type = value;
                entity_typeChanged = true;
            }
        }
        private string entity_typeDbString
        {
            get
            {
                if (this.entity_type != null)
                    return string.Format("'{0}'", entity_type);
                else
                    return "null";
            }
        }
        #endregion
        #region EntityId
        private bool entity_idChanged = false;
        private long? entity_id;
        public long? EntityId
        {
            get { return entity_id; }
            set
            {
                entity_id = value;
                entity_idChanged = true;
            }
        }
        private string entity_idDbString
        {
            get
            {
                if (this.entity_id.HasValue)
                    return entity_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EventCount
        private bool event_countChanged = false;
        private int? event_count;
        public int? EventCount
        {
            get { return event_count; }
            set
            {
                event_count = value;
                event_countChanged = true;
            }
        }
        private string event_countDbString
        {
            get
            {
                if (this.event_count.HasValue)
                    return event_count.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region AtmAlertReader
        public class AtmAlertReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            AtmAlert currentAtmAlert;
            Columns columns;
            bool partialRead = false;
            private AtmAlertReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AtmAlertReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AtmAlertReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAtmAlert; }

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
                    currentAtmAlert = new AtmAlert();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentAtmAlert.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.atm_alert_id) == Columns.atm_alert_id && reader["atm_alert_id"] != DBNull.Value)
                            currentAtmAlert.atm_alert_id = (long)reader["atm_alert_id"];
                        if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"] != DBNull.Value)
                            currentAtmAlert.generated_at = (DateTime)reader["generated_at"];
                        if ((columns & Columns.resolve_at) == Columns.resolve_at && reader["resolve_at"] != DBNull.Value)
                            currentAtmAlert.resolve_at = (DateTime?)reader["resolve_at"];
                        if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"] != DBNull.Value)
                            currentAtmAlert.alert_type_id = (long)reader["alert_type_id"];
                        if ((columns & Columns.expiration_time) == Columns.expiration_time && reader["expiration_time"] != DBNull.Value)
                            currentAtmAlert.expiration_time = (DateTime?)reader["expiration_time"];
                        if ((columns & Columns.generate_at_retry_remaining) == Columns.generate_at_retry_remaining && reader["generate_at_retry_remaining"] != DBNull.Value)
                            currentAtmAlert.generate_at_retry_remaining = (int)reader["generate_at_retry_remaining"];
                        if ((columns & Columns.resolve_at_retry_remaining) == Columns.resolve_at_retry_remaining && reader["resolve_at_retry_remaining"] != DBNull.Value)
                            currentAtmAlert.resolve_at_retry_remaining = (int)reader["resolve_at_retry_remaining"];
                        if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"] != DBNull.Value)
                            currentAtmAlert.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                        if ((columns & Columns.generate_notification_sent) == Columns.generate_notification_sent && reader["generate_notification_sent"] != DBNull.Value)
                            currentAtmAlert.generate_notification_sent = (bool)reader["generate_notification_sent"];
                        if ((columns & Columns.resolve_notification_sent) == Columns.resolve_notification_sent && reader["resolve_notification_sent"] != DBNull.Value)
                            currentAtmAlert.resolve_notification_sent = (bool?)reader["resolve_notification_sent"];
                        if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"] != DBNull.Value)
                            currentAtmAlert.failure_reason = (string)reader["failure_reason"];
                        if ((columns & Columns.alert_msg) == Columns.alert_msg && reader["alert_msg"] != DBNull.Value)
                            currentAtmAlert.alert_msg = (string)reader["alert_msg"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentAtmAlert.task_id = (long?)reader["task_id"];
                        if ((columns & Columns.entity_type) == Columns.entity_type && reader["entity_type"] != DBNull.Value)
                            currentAtmAlert.entity_type = (string)reader["entity_type"];
                        if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"] != DBNull.Value)
                            currentAtmAlert.entity_id = (long?)reader["entity_id"];
                        if ((columns & Columns.event_count) == Columns.event_count && reader["event_count"] != DBNull.Value)
                            currentAtmAlert.event_count = (int?)reader["event_count"];

                    }
                    else
                    {
                        if (reader["atm_id"] != DBNull.Value)
                            currentAtmAlert.atm_id = (long)reader["atm_id"];
                        if (reader["atm_alert_id"] != DBNull.Value)
                            currentAtmAlert.atm_alert_id = (long)reader["atm_alert_id"];
                        if (reader["generated_at"] != DBNull.Value)
                            currentAtmAlert.generated_at = (DateTime)reader["generated_at"];
                        if (reader["resolve_at"] != DBNull.Value)
                            currentAtmAlert.resolve_at = (DateTime?)reader["resolve_at"];
                        if (reader["alert_type_id"] != DBNull.Value)
                            currentAtmAlert.alert_type_id = (long)reader["alert_type_id"];
                        if (reader["expiration_time"] != DBNull.Value)
                            currentAtmAlert.expiration_time = (DateTime?)reader["expiration_time"];
                        if (reader["generate_at_retry_remaining"] != DBNull.Value)
                            currentAtmAlert.generate_at_retry_remaining = (int)reader["generate_at_retry_remaining"];
                        if (reader["resolve_at_retry_remaining"] != DBNull.Value)
                            currentAtmAlert.resolve_at_retry_remaining = (int)reader["resolve_at_retry_remaining"];
                        if (reader["last_invoked_at"] != DBNull.Value)
                            currentAtmAlert.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                        if (reader["generate_notification_sent"] != DBNull.Value)
                            currentAtmAlert.generate_notification_sent = (bool)reader["generate_notification_sent"];
                        if (reader["resolve_notification_sent"] != DBNull.Value)
                            currentAtmAlert.resolve_notification_sent = (bool?)reader["resolve_notification_sent"];
                        if (reader["failure_reason"] != DBNull.Value)
                            currentAtmAlert.failure_reason = (string)reader["failure_reason"];
                        if (reader["alert_msg"] != DBNull.Value)
                            currentAtmAlert.alert_msg = (string)reader["alert_msg"];
                        if (reader["task_id"] != DBNull.Value)
                            currentAtmAlert.task_id = (long?)reader["task_id"];
                        if (reader["entity_type"] != DBNull.Value)
                            currentAtmAlert.entity_type = (string)reader["entity_type"];
                        if (reader["entity_id"] != DBNull.Value)
                            currentAtmAlert.entity_id = (long?)reader["entity_id"];
                        if (reader["event_count"] != DBNull.Value)
                            currentAtmAlert.event_count = (int?)reader["event_count"];
                    }

                    currentAtmAlert.isNewEntity = false;
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

            public AtmAlert CurrentAtmAlert
            {
                get { return currentAtmAlert; }
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


        #region AtmAlert functions

        public static AtmAlertReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.atm_alert_id == (Columns.atm_alert_id & columns))
                qry.Append("atm_alert_id,");
            if (Columns.generated_at == (Columns.generated_at & columns))
                qry.Append("generated_at,");
            if (Columns.resolve_at == (Columns.resolve_at & columns))
                qry.Append("resolve_at,");
            if (Columns.alert_type_id == (Columns.alert_type_id & columns))
                qry.Append("alert_type_id,");
            if (Columns.expiration_time == (Columns.expiration_time & columns))
                qry.Append("expiration_time,");
            if (Columns.generate_at_retry_remaining == (Columns.generate_at_retry_remaining & columns))
                qry.Append("generate_at_retry_remaining,");
            if (Columns.resolve_at_retry_remaining == (Columns.resolve_at_retry_remaining & columns))
                qry.Append("resolve_at_retry_remaining,");
            if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
                qry.Append("last_invoked_at,");
            if (Columns.generate_notification_sent == (Columns.generate_notification_sent & columns))
                qry.Append("generate_notification_sent,");
            if (Columns.resolve_notification_sent == (Columns.resolve_notification_sent & columns))
                qry.Append("resolve_notification_sent,");
            if (Columns.failure_reason == (Columns.failure_reason & columns))
                qry.Append("failure_reason,");
            if (Columns.alert_msg == (Columns.alert_msg & columns))
                qry.Append("alert_msg,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.entity_type == (Columns.entity_type & columns))
                qry.Append("entity_type,");
            if (Columns.entity_id == (Columns.entity_id & columns))
                qry.Append("entity_id,");
            if (Columns.event_count == (Columns.event_count & columns))
                qry.Append("event_count,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Atm_alert ");

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
            return new AtmAlertReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AtmAlertReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AtmAlertReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_id,atm_alert_id,generated_at,resolve_at,alert_type_id,expiration_time,generate_at_retry_remaining,resolve_at_retry_remaining,last_invoked_at,generate_notification_sent,resolve_notification_sent,failure_reason,alert_msg,task_id,entity_type,entity_id,event_count from Atm_alert ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmAlertReader(cmd.ExecuteReader(), conn);
        }

        static public AtmAlertReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static AtmAlert LoadAtmAlert(string where)
        {
            AtmAlertReader reader = AtmAlert.ExecuteReader(where);
            AtmAlert _atmalert = null;
            if (reader.Read())
                _atmalert = reader.CurrentAtmAlert;
            reader.Close();
            return _atmalert;
        }

        public static AtmAlert LoadAtmAlert(string where, IDbConnection conn)
        {
            AtmAlertReader reader = AtmAlert.ExecuteReader(where, conn);
            AtmAlert _atmalert = null;
            if (reader.Read())
                _atmalert = reader.CurrentAtmAlert;
            reader.Close(false);
            return _atmalert;
        }

        public static AtmAlert LoadAtmAlertByPk(long atm_alert_id)
        {
            return LoadAtmAlert("atm_alert_id=" + atm_alert_id);
        }

        public static AtmAlert LoadAtmAlertByPk(long atm_alert_id, IDbConnection conn)
        {
            return LoadAtmAlert(" atm_alert_id=" + atm_alert_id, conn);
        }

        public void Save()
        {
            if (atm_idChanged || atm_alert_idChanged || generated_atChanged || resolve_atChanged || alert_type_idChanged || expiration_timeChanged || generate_at_retry_remainingChanged || resolve_at_retry_remainingChanged || last_invoked_atChanged || generate_notification_sentChanged || resolve_notification_sentChanged || failure_reasonChanged || alert_msgChanged || task_idChanged || entity_typeChanged || entity_idChanged || event_countChanged)
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
            if (atm_idChanged || atm_alert_idChanged || generated_atChanged || resolve_atChanged || alert_type_idChanged || expiration_timeChanged || generate_at_retry_remainingChanged || resolve_at_retry_remainingChanged || last_invoked_atChanged || generate_notification_sentChanged || resolve_notification_sentChanged || failure_reasonChanged || alert_msgChanged || task_idChanged || entity_typeChanged || entity_idChanged || event_countChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm_alert(atm_id,atm_alert_id,generated_at,resolve_at,alert_type_id,expiration_time,generate_at_retry_remaining,resolve_at_retry_remaining,last_invoked_at,generate_notification_sent,resolve_notification_sent,failure_reason,alert_msg,task_id,entity_type,entity_id,event_count) values(");
                    qry.Append(atm_idDbString + ",");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.atm_alert_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.atm_alert_id);
                    }
                    qry.Append(",");
                    qry.Append(generated_atDbString + ",");
                    qry.Append(resolve_atDbString + ",");
                    qry.Append(alert_type_idDbString + ",");
                    qry.Append(expiration_timeDbString + ",");
                    qry.Append(generate_at_retry_remainingDbString + ",");
                    qry.Append(resolve_at_retry_remainingDbString + ",");
                    qry.Append(last_invoked_atDbString + ",");
                    qry.Append(generate_notification_sentDbString + ",");
                    qry.Append(resolve_notification_sentDbString + ",");
                    qry.Append(failure_reasonDbString + ",");
                    qry.Append(alert_msgDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(entity_typeDbString + ",");
                    qry.Append(entity_idDbString + ",");
                    qry.Append(event_countDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_idChanged || atm_alert_idChanged || generated_atChanged || resolve_atChanged || alert_type_idChanged || expiration_timeChanged || generate_at_retry_remainingChanged || resolve_at_retry_remainingChanged || last_invoked_atChanged || generate_notification_sentChanged || resolve_notification_sentChanged || failure_reasonChanged || alert_msgChanged || task_idChanged || entity_typeChanged || entity_idChanged || event_countChanged))
                        return;
                    qry.Append("UPDATE Atm_alert set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (generated_atChanged)
                    {
                        qry.Append("generated_at =" + generated_atDbString);
                        qry.Append(",");
                    }

                    if (resolve_atChanged)
                    {
                        qry.Append("resolve_at =" + resolve_atDbString);
                        qry.Append(",");
                    }

                    if (alert_type_idChanged)
                    {
                        qry.Append("alert_type_id =" + alert_type_idDbString);
                        qry.Append(",");
                    }

                    if (expiration_timeChanged)
                    {
                        qry.Append("expiration_time =" + expiration_timeDbString);
                        qry.Append(",");
                    }

                    if (generate_at_retry_remainingChanged)
                    {
                        qry.Append("generate_at_retry_remaining =" + generate_at_retry_remainingDbString);
                        qry.Append(",");
                    }

                    if (resolve_at_retry_remainingChanged)
                    {
                        qry.Append("resolve_at_retry_remaining =" + resolve_at_retry_remainingDbString);
                        qry.Append(",");
                    }

                    if (last_invoked_atChanged)
                    {
                        qry.Append("last_invoked_at =" + last_invoked_atDbString);
                        qry.Append(",");
                    }

                    if (generate_notification_sentChanged)
                    {
                        qry.Append("generate_notification_sent =" + generate_notification_sentDbString);
                        qry.Append(",");
                    }

                    if (resolve_notification_sentChanged)
                    {
                        qry.Append("resolve_notification_sent =" + resolve_notification_sentDbString);
                        qry.Append(",");
                    }

                    if (failure_reasonChanged)
                    {
                        qry.Append("failure_reason =" + failure_reasonDbString);
                        qry.Append(",");
                    }

                    if (alert_msgChanged)
                    {
                        qry.Append("alert_msg =" + alert_msgDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (entity_typeChanged)
                    {
                        qry.Append("entity_type =" + entity_typeDbString);
                        qry.Append(",");
                    }

                    if (entity_idChanged)
                    {
                        qry.Append("entity_id =" + entity_idDbString);
                        qry.Append(",");
                    }

                    if (event_countChanged)
                    {
                        qry.Append("event_count =" + event_countDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("atm_alert_id = " + atm_alert_idDbString);
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
            cmd.CommandText = "DELETE Atm_alert where atm_alert_id= " + atm_alert_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAtmAlerts(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Atm_alert where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_id = 0,
            atm_alert_id = 1,
            generated_at = 2,
            resolve_at = 3,
            alert_type_id = 4,
            expiration_time = 5,
            generate_at_retry_remaining = 6,
            resolve_at_retry_remaining = 7,
            last_invoked_at = 8,
            generate_notification_sent = 9,
            resolve_notification_sent = 10,
            failure_reason = 11,
            alert_msg = 12,
            task_id = 13,
            entity_type = 14,
            entity_id = 15,
            event_count = 16
        }
        #endregion
        public DataTable BulkSave(List<AtmAlert> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Atm_alert";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(AtmAlert.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<AtmAlert> transList, ref DataTable dt)
        {
            foreach (AtmAlert tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_id"] = tran.AtmId;
                Row["atm_alert_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["generated_at"] = tran.GeneratedAt;
                Row["resolve_at"] = tran.ResolveAt;
                Row["alert_type_id"] = tran.AlertTypeId;
                Row["expiration_time"] = tran.ExpirationTime;
                Row["generate_at_retry_remaining"] = tran.GenerateAtRetryRemaining;
                Row["resolve_at_retry_remaining"] = tran.ResolveAtRetryRemaining;
                Row["last_invoked_at"] = tran.LastInvokedAt;
                Row["generate_notification_sent"] = tran.GenerateNotificationSent;
                Row["resolve_notification_sent"] = tran.ResolveNotificationSent;
                Row["failure_reason"] = tran.FailureReason;
                Row["alert_msg"] = tran.AlertMsg;
                Row["task_id"] = tran.TaskId;
                Row["entity_type"] = tran.EntityType;
                Row["entity_id"] = tran.EntityId;
                Row["event_count"] = tran.EventCount;
                dt.Rows.Add(Row);
            }
        }
    }
}


