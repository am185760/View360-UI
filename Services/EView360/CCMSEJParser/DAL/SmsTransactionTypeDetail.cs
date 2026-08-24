using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;
using System.Data.SqlClient;

namespace Avanza.CCMS.DAL
{
    [Serializable()]
    public class SmsTransactionTypeDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public SmsTransactionTypeDetail() { }
        public SmsTransactionTypeDetail(int sms_transaction_type_detail_id)
        {
        }
        public SmsTransactionTypeDetail(string action_code, int? transaction_type_id)
        {
            this.action_code = action_code;
            this.action_codeChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
        }
        private SmsTransactionTypeDetail(int sms_transaction_type_detail_id, string action_code, int? transaction_type_id)
        {
            this.sms_transaction_type_detail_id = sms_transaction_type_detail_id;
            this.sms_transaction_type_detail_idChanged = true;
            this.action_code = action_code;
            this.action_codeChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
        }

        #region members and properties for columns

        #region SmsTransactionTypeDetailId
        private bool sms_transaction_type_detail_idChanged = false;
        private int sms_transaction_type_detail_id;
        public int SmsTransactionTypeDetailId
        {
            get { return sms_transaction_type_detail_id; }
            set
            {
                sms_transaction_type_detail_id = value;
                sms_transaction_type_detail_idChanged = true;
            }
        }
        private string sms_transaction_type_detail_idDbString
        {
            get
            {
                return sms_transaction_type_detail_id.ToString();
            }
        }
        #endregion
        #region ActionCode
        private bool action_codeChanged = false;
        private string action_code;
        public string ActionCode
        {
            get { return action_code; }
            set
            {
                action_code = value;
                action_codeChanged = true;
            }
        }
        private string action_codeDbString
        {
            get
            {
                if (this.action_code != null)
                    return string.Format("'{0}'", action_code);
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
        #endregion

        #region SmsTransactionTypeDetailReader
        public class SmsTransactionTypeDetailReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            SmsTransactionTypeDetail currentSmsTransactionTypeDetail;
            Columns columns;
            bool partialRead = false;
            private SmsTransactionTypeDetailReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public SmsTransactionTypeDetailReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public SmsTransactionTypeDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentSmsTransactionTypeDetail; }

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
                    currentSmsTransactionTypeDetail = new SmsTransactionTypeDetail();
                    if (partialRead)
                    {
                        if ((columns & Columns.sms_transaction_type_detail_id) == Columns.sms_transaction_type_detail_id && reader["sms_transaction_type_detail_id"] != DBNull.Value)
                            currentSmsTransactionTypeDetail.sms_transaction_type_detail_id = (int)reader["sms_transaction_type_detail_id"];
                        if ((columns & Columns.action_code) == Columns.action_code && reader["action_code"] != DBNull.Value)
                            currentSmsTransactionTypeDetail.action_code = (string)reader["action_code"];
                        if ((columns & Columns.transaction_type_id) == Columns.transaction_type_id && reader["transaction_type_id"] != DBNull.Value)
                            currentSmsTransactionTypeDetail.transaction_type_id = (int?)reader["transaction_type_id"];

                    }
                    else
                    {
                        if (reader["sms_transaction_type_detail_id"] != DBNull.Value)
                            currentSmsTransactionTypeDetail.sms_transaction_type_detail_id = (int)reader["sms_transaction_type_detail_id"];
                        if (reader["action_code"] != DBNull.Value)
                            currentSmsTransactionTypeDetail.action_code = (string)reader["action_code"];
                        if (reader["transaction_type_id"] != DBNull.Value)
                            currentSmsTransactionTypeDetail.transaction_type_id = (int?)reader["transaction_type_id"];
                    }

                    currentSmsTransactionTypeDetail.isNewEntity = false;
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

            public SmsTransactionTypeDetail CurrentSmsTransactionTypeDetail
            {
                get { return currentSmsTransactionTypeDetail; }
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


        #region SmsTransactionTypeDetail functions

        public static SmsTransactionTypeDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.sms_transaction_type_detail_id == (Columns.sms_transaction_type_detail_id & columns))
                qry.Append("sms_transaction_type_detail_id,");
            if (Columns.action_code == (Columns.action_code & columns))
                qry.Append("action_code,");
            if (Columns.transaction_type_id == (Columns.transaction_type_id & columns))
                qry.Append("transaction_type_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Sms_transaction_type_detail ");

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
            return new SmsTransactionTypeDetailReader(cmd.ExecuteReader(), conn, columns);
        }

        static public SmsTransactionTypeDetailReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static SmsTransactionTypeDetailReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select sms_transaction_type_detail_id,action_code,transaction_type_id from Sms_transaction_type_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new SmsTransactionTypeDetailReader(cmd.ExecuteReader(), conn);
        }

        static public SmsTransactionTypeDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static SmsTransactionTypeDetail LoadSmsTransactionTypeDetail(string where)
        {
            SmsTransactionTypeDetailReader reader = SmsTransactionTypeDetail.ExecuteReader(where);
            SmsTransactionTypeDetail _smstransactiontypedetail = null;
            if (reader.Read())
                _smstransactiontypedetail = reader.CurrentSmsTransactionTypeDetail;
            reader.Close();
            return _smstransactiontypedetail;
        }

        public static SmsTransactionTypeDetail LoadSmsTransactionTypeDetail(string where, IDbConnection conn)
        {
            SmsTransactionTypeDetailReader reader = SmsTransactionTypeDetail.ExecuteReader(where, conn);
            SmsTransactionTypeDetail _smstransactiontypedetail = null;
            if (reader.Read())
                _smstransactiontypedetail = reader.CurrentSmsTransactionTypeDetail;
            reader.Close(false);
            return _smstransactiontypedetail;
        }

        public static SmsTransactionTypeDetail LoadSmsTransactionTypeDetailByPk(int sms_transaction_type_detail_id)
        {
            return LoadSmsTransactionTypeDetail(" sms_transaction_type_detail_id=" + sms_transaction_type_detail_id);
        }

        public static SmsTransactionTypeDetail LoadSmsTransactionTypeDetailByPk(int sms_transaction_type_detail_id, IDbConnection conn)
        {
            return LoadSmsTransactionTypeDetail(" sms_transaction_type_detail_id=" + sms_transaction_type_detail_id, conn);
        }

        public void Save()
        {
            if (sms_transaction_type_detail_idChanged || action_codeChanged || transaction_type_idChanged)
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
            if (sms_transaction_type_detail_idChanged || action_codeChanged || transaction_type_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Sms_transaction_type_detail( sms_transaction_type_detail_id,action_code,transaction_type_id ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.sms_transaction_type_detail_id = ConnectionFactory.GetNextId();
                        qry.Append(this.sms_transaction_type_detail_id);
                    } qry.Append(",");
                    qry.Append(action_codeDbString + ",");
                    qry.Append(transaction_type_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(sms_transaction_type_detail_idChanged || action_codeChanged || transaction_type_idChanged))
                        return;
                    qry.Append("UPDATE Sms_transaction_type_detail set "); if (action_codeChanged)
                    {
                        qry.Append("action_code =" + action_codeDbString);
                        qry.Append(",");
                    }

                    if (transaction_type_idChanged)
                    {
                        qry.Append("transaction_type_id =" + transaction_type_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("sms_transaction_type_detail_id = " + sms_transaction_type_detail_idDbString);
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
            cmd.CommandText = "DELETE Sms_transaction_type_detail where sms_transaction_type_detail_id = " + sms_transaction_type_detail_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteSmsTransactionTypeDetails(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Sms_transaction_type_detail where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            sms_transaction_type_detail_id = 1,
            action_code = 2,
            transaction_type_id = 4
        }
        #endregion
        public void BulkSave(List<SmsTransactionTypeDetail> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Sms_transaction_type_detail";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(SmsTransactionTypeDetail.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<SmsTransactionTypeDetail> transList, ref DataTable dt)
        {
            foreach (SmsTransactionTypeDetail tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["sms_transaction_type_detail_id"] = ConnectionFactory.GetNextId();
                Row["action_code"] = tran.ActionCode;
                Row["transaction_type_id"] = tran.TransactionTypeId;
                dt.Rows.Add(Row);
            }
        }
    }
}


