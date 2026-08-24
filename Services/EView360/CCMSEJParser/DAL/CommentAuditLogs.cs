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
    public class CommentAuditLogs
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CommentAuditLogs() { }
        public CommentAuditLogs(int comment_audit_logs_id, int captured_transactions_id)
        {
            this.captured_transactions_id = captured_transactions_id;
            this.captured_transactions_idChanged = true;
        }
        public CommentAuditLogs(string comment_text, DateTime? comment_entered_at, int? user_id, int captured_transactions_id, string trxn_status)
        {
            this.comment_text = comment_text;
            this.comment_textChanged = true;
            this.comment_entered_at = comment_entered_at;
            this.comment_entered_atChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.captured_transactions_id = captured_transactions_id;
            this.captured_transactions_idChanged = true;
            this.trxn_status = trxn_status;
            this.trxn_statusChanged = true;
        }
        private CommentAuditLogs(int comment_audit_logs_id, string comment_text, DateTime? comment_entered_at, int? user_id, int captured_transactions_id, string trxn_status)
        {
            this.comment_audit_logs_id = comment_audit_logs_id;
            this.comment_audit_logs_idChanged = true;
            this.comment_text = comment_text;
            this.comment_textChanged = true;
            this.comment_entered_at = comment_entered_at;
            this.comment_entered_atChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.captured_transactions_id = captured_transactions_id;
            this.captured_transactions_idChanged = true;
            this.trxn_status = trxn_status;
            this.trxn_statusChanged = true;
        }

        #region members and properties for columns

        #region CommentAuditLogsId
        private bool comment_audit_logs_idChanged = false;
        private int comment_audit_logs_id;
        public int CommentAuditLogsId
        {
            get { return comment_audit_logs_id; }
            set
            {
                comment_audit_logs_id = value;
                comment_audit_logs_idChanged = true;
            }
        }
        private string comment_audit_logs_idDbString
        {
            get
            {
                return comment_audit_logs_id.ToString();
            }
        }
        #endregion
        #region CommentText
        private bool comment_textChanged = false;
        private string comment_text;
        public string CommentText
        {
            get { return comment_text; }
            set
            {
                comment_text = value;
                comment_textChanged = true;
            }
        }
        private string comment_textDbString
        {
            get
            {
                if (this.comment_text != null)
                    return string.Format("'{0}'", comment_text);
                else
                    return "null";
            }
        }
        #endregion
        #region CommentEnteredAt
        private bool comment_entered_atChanged = false;
        private DateTime? comment_entered_at;
        public DateTime? CommentEnteredAt
        {
            get { return comment_entered_at; }
            set
            {
                comment_entered_at = value;
                comment_entered_atChanged = true;
            }
        }
        private string comment_entered_atDbString
        {
            get
            {
                if (this.comment_entered_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", comment_entered_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region UserId
        private bool user_idChanged = false;
        private int? user_id;
        public int? UserId
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
        #region CapturedTransactionsId
        private bool captured_transactions_idChanged = false;
        private int captured_transactions_id;
        public int CapturedTransactionsId
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
        #endregion

        #region CommentAuditLogsReader
        public class CommentAuditLogsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CommentAuditLogs currentCommentAuditLogs;
            Columns columns;
            bool partialRead = false;
            private CommentAuditLogsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CommentAuditLogsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CommentAuditLogsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCommentAuditLogs; }

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
                    currentCommentAuditLogs = new CommentAuditLogs();
                    if (partialRead)
                    {
                        if ((columns & Columns.comment_audit_logs_id) == Columns.comment_audit_logs_id && reader["comment_audit_logs_id"] != DBNull.Value)
                            currentCommentAuditLogs.comment_audit_logs_id = (int)reader["comment_audit_logs_id"];
                        if ((columns & Columns.comment_text) == Columns.comment_text && reader["comment_text"] != DBNull.Value)
                            currentCommentAuditLogs.comment_text = (string)reader["comment_text"];
                        if ((columns & Columns.comment_entered_at) == Columns.comment_entered_at && reader["comment_entered_at"] != DBNull.Value)
                            currentCommentAuditLogs.comment_entered_at = (DateTime?)reader["comment_entered_at"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentCommentAuditLogs.user_id = (int?)reader["user_id"];
                        if ((columns & Columns.captured_transactions_id) == Columns.captured_transactions_id && reader["captured_transactions_id"] != DBNull.Value)
                            currentCommentAuditLogs.captured_transactions_id = (int)reader["captured_transactions_id"];
                        if ((columns & Columns.trxn_status) == Columns.trxn_status && reader["trxn_status"] != DBNull.Value)
                            currentCommentAuditLogs.trxn_status = (string)reader["trxn_status"];

                    }
                    else
                    {
                        if (reader["comment_audit_logs_id"] != DBNull.Value)
                            currentCommentAuditLogs.comment_audit_logs_id = (int)reader["comment_audit_logs_id"];
                        if (reader["comment_text"] != DBNull.Value)
                            currentCommentAuditLogs.comment_text = (string)reader["comment_text"];
                        if (reader["comment_entered_at"] != DBNull.Value)
                            currentCommentAuditLogs.comment_entered_at = (DateTime?)reader["comment_entered_at"];
                        if (reader["user_id"] != DBNull.Value)
                            currentCommentAuditLogs.user_id = (int?)reader["user_id"];
                        if (reader["captured_transactions_id"] != DBNull.Value)
                            currentCommentAuditLogs.captured_transactions_id = (int)reader["captured_transactions_id"];
                        if (reader["trxn_status"] != DBNull.Value)
                            currentCommentAuditLogs.trxn_status = (string)reader["trxn_status"];
                    }

                    currentCommentAuditLogs.isNewEntity = false;
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

            public CommentAuditLogs CurrentCommentAuditLogs
            {
                get { return currentCommentAuditLogs; }
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


        #region CommentAuditLogs functions

        public static CommentAuditLogsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.comment_audit_logs_id == (Columns.comment_audit_logs_id & columns))
                qry.Append("comment_audit_logs_id,");
            if (Columns.comment_text == (Columns.comment_text & columns))
                qry.Append("comment_text,");
            if (Columns.comment_entered_at == (Columns.comment_entered_at & columns))
                qry.Append("comment_entered_at,");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.captured_transactions_id == (Columns.captured_transactions_id & columns))
                qry.Append("captured_transactions_id,");
            if (Columns.trxn_status == (Columns.trxn_status & columns))
                qry.Append("trxn_status,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Comment_audit_logs ");

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
            return new CommentAuditLogsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CommentAuditLogsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CommentAuditLogsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select comment_audit_logs_id,comment_text,comment_entered_at,user_id,captured_transactions_id,trxn_status from Comment_audit_logs ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CommentAuditLogsReader(cmd.ExecuteReader(), conn);
        }

        static public CommentAuditLogsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CommentAuditLogs LoadCommentAuditLogs(string where)
        {
            CommentAuditLogsReader reader = CommentAuditLogs.ExecuteReader(where);
            CommentAuditLogs _commentauditlogs = null;
            if (reader.Read())
                _commentauditlogs = reader.CurrentCommentAuditLogs;
            reader.Close();
            return _commentauditlogs;
        }

        public static CommentAuditLogs LoadCommentAuditLogs(string where, IDbConnection conn)
        {
            CommentAuditLogsReader reader = CommentAuditLogs.ExecuteReader(where, conn);
            CommentAuditLogs _commentauditlogs = null;
            if (reader.Read())
                _commentauditlogs = reader.CurrentCommentAuditLogs;
            reader.Close(false);
            return _commentauditlogs;
        }

        public static CommentAuditLogs LoadCommentAuditLogsByPk(int comment_audit_logs_id)
        {
            return LoadCommentAuditLogs("comment_audit_logs_id=" + comment_audit_logs_id);
        }

        public static CommentAuditLogs LoadCommentAuditLogsByPk(int comment_audit_logs_id, IDbConnection conn)
        {
            return LoadCommentAuditLogs(" comment_audit_logs_id=" + comment_audit_logs_id, conn);
        }

        public void Save()
        {
            if (comment_audit_logs_idChanged || comment_textChanged || comment_entered_atChanged || user_idChanged || captured_transactions_idChanged || trxn_statusChanged)
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
            if (comment_audit_logs_idChanged || comment_textChanged || comment_entered_atChanged || user_idChanged || captured_transactions_idChanged || trxn_statusChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Comment_audit_logs(comment_audit_logs_id,comment_text,comment_entered_at,user_id,captured_transactions_id,trxn_status) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.comment_audit_logs_id = ConnectionFactory.GetNextId();
                        qry.Append(this.comment_audit_logs_id);
                    } qry.Append(",");
                    qry.Append(comment_textDbString + ",");
                    qry.Append(comment_entered_atDbString + ",");
                    qry.Append(user_idDbString + ",");
                    qry.Append(captured_transactions_idDbString + ",");
                    qry.Append(trxn_statusDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(comment_audit_logs_idChanged || comment_textChanged || comment_entered_atChanged || user_idChanged || captured_transactions_idChanged || trxn_statusChanged))
                        return;
                    qry.Append("UPDATE Comment_audit_logs set "); if (comment_textChanged)
                    {
                        qry.Append("comment_text =" + comment_textDbString);
                        qry.Append(",");
                    }

                    if (comment_entered_atChanged)
                    {
                        qry.Append("comment_entered_at =" + comment_entered_atDbString);
                        qry.Append(",");
                    }

                    if (user_idChanged)
                    {
                        qry.Append("user_id =" + user_idDbString);
                        qry.Append(",");
                    }

                    if (captured_transactions_idChanged)
                    {
                        qry.Append("captured_transactions_id =" + captured_transactions_idDbString);
                        qry.Append(",");
                    }

                    if (trxn_statusChanged)
                    {
                        qry.Append("trxn_status =" + trxn_statusDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("comment_audit_logs_id = " + comment_audit_logs_idDbString);
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
            cmd.CommandText = "DELETE Comment_audit_logs wherecomment_audit_logs_id= " + comment_audit_logs_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCommentAuditLogss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Comment_audit_logs where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            comment_audit_logs_id = 1,
            comment_text = 2,
            comment_entered_at = 4,
            user_id = 8,
            captured_transactions_id = 16,
            trxn_status = 32
        }
        #endregion
        public DataTable BulkSave(List<CommentAuditLogs> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Comment_audit_logs";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CommentAuditLogs.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CommentAuditLogs> transList, ref DataTable dt)
        {
            foreach (CommentAuditLogs tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["comment_audit_logs_id"] = ConnectionFactory.GetNextId();
                Row["comment_text"] = tran.CommentText;
                Row["comment_entered_at"] = tran.CommentEnteredAt;
                Row["user_id"] = tran.UserId;
                Row["captured_transactions_id"] = tran.CapturedTransactionsId;
                Row["trxn_status"] = tran.TrxnStatus;
                dt.Rows.Add(Row);
            }
        }
    }
}