using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServicesDAL
{
    [Serializable()]
    public class EjParsedBnaTransactionDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedBnaTransactionDetail() { }
        public EjParsedBnaTransactionDetail(long ej_parsed_bna_transaction_detail_id, long ej_parsed_bna_transaction_id, int note_type, int notes_count)
        {
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.note_type = note_type;
            this.note_typeChanged = true;
            this.notes_count = notes_count;
            this.notes_countChanged = true;
        }
        public EjParsedBnaTransactionDetail(long ej_parsed_bna_transaction_id, int note_type, int notes_count, int? total_remaining, int? total_rejected)
        {
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.note_type = note_type;
            this.note_typeChanged = true;
            this.notes_count = notes_count;
            this.notes_countChanged = true;
            this.total_remaining = total_remaining;
            this.total_remainingChanged = true;
            this.total_rejected = total_rejected;
            this.total_rejectedChanged = true;
        }
        private EjParsedBnaTransactionDetail(long ej_parsed_bna_transaction_detail_id, long ej_parsed_bna_transaction_id, int note_type, int notes_count, int? total_remaining, int? total_rejected)
        {
            this.ej_parsed_bna_transaction_detail_id = ej_parsed_bna_transaction_detail_id;
            this.ej_parsed_bna_transaction_detail_idChanged = true;
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.note_type = note_type;
            this.note_typeChanged = true;
            this.notes_count = notes_count;
            this.notes_countChanged = true;
            this.total_remaining = total_remaining;
            this.total_remainingChanged = true;
            this.total_rejected = total_rejected;
            this.total_rejectedChanged = true;
        }

        #region members and properties for columns

        #region EjParsedBnaTransactionDetailId
        private bool ej_parsed_bna_transaction_detail_idChanged = false;
        private long ej_parsed_bna_transaction_detail_id;
        public long EjParsedBnaTransactionDetailId
        {
            get { return ej_parsed_bna_transaction_detail_id; }
            set
            {
                ej_parsed_bna_transaction_detail_id = value;
                ej_parsed_bna_transaction_detail_idChanged = true;
            }
        }
        private string ej_parsed_bna_transaction_detail_idDbString
        {
            get
            {
                return ej_parsed_bna_transaction_detail_id.ToString();
            }
        }
        #endregion
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
        #region NoteType
        private bool note_typeChanged = false;
        private int note_type;
        public int NoteType
        {
            get { return note_type; }
            set
            {
                note_type = value;
                note_typeChanged = true;
            }
        }
        private string note_typeDbString
        {
            get
            {
                return note_type.ToString();
            }
        }
        #endregion
        #region NotesCount
        private bool notes_countChanged = false;
        private int notes_count;
        public int NotesCount
        {
            get { return notes_count; }
            set
            {
                notes_count = value;
                notes_countChanged = true;
            }
        }
        private string notes_countDbString
        {
            get
            {
                return notes_count.ToString();
            }
        }
        #endregion
        #region TotalRemaining
        private bool total_remainingChanged = false;
        private int? total_remaining;
        public int? TotalRemaining
        {
            get { return total_remaining; }
            set
            {
                total_remaining = value;
                total_remainingChanged = true;
            }
        }
        private string total_remainingDbString
        {
            get
            {
                if (this.total_remaining.HasValue)
                    return total_remaining.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TotalRejected
        private bool total_rejectedChanged = false;
        private int? total_rejected;
        public int? TotalRejected
        {
            get { return total_rejected; }
            set
            {
                total_rejected = value;
                total_rejectedChanged = true;
            }
        }
        private string total_rejectedDbString
        {
            get
            {
                if (this.total_rejected.HasValue)
                    return total_rejected.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region EjParsedBnaTransactionDetailReader
        public class EjParsedBnaTransactionDetailReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjParsedBnaTransactionDetail currentEjParsedBnaTransactionDetail;
            Columns columns;
            bool partialRead = false;
            private EjParsedBnaTransactionDetailReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjParsedBnaTransactionDetailReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjParsedBnaTransactionDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjParsedBnaTransactionDetail; }

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
                    currentEjParsedBnaTransactionDetail = new EjParsedBnaTransactionDetail();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_parsed_bna_transaction_detail_id) == Columns.ej_parsed_bna_transaction_detail_id && reader["ej_parsed_bna_transaction_detail_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_detail_id = (long)reader["ej_parsed_bna_transaction_detail_id"];
                        if ((columns & Columns.ej_parsed_bna_transaction_id) == Columns.ej_parsed_bna_transaction_id && reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_id = (long)reader["ej_parsed_bna_transaction_id"];
                        if ((columns & Columns.note_type) == Columns.note_type && reader["note_type"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.note_type = (int)reader["note_type"];
                        if ((columns & Columns.notes_count) == Columns.notes_count && reader["notes_count"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.notes_count = (int)reader["notes_count"];
                        if ((columns & Columns.total_remaining) == Columns.total_remaining && reader["total_remaining"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.total_remaining = (int?)reader["total_remaining"];
                        if ((columns & Columns.total_rejected) == Columns.total_rejected && reader["total_rejected"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.total_rejected = (int?)reader["total_rejected"];

                    }
                    else
                    {
                        if (reader["ej_parsed_bna_transaction_detail_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_detail_id = (long)reader["ej_parsed_bna_transaction_detail_id"];
                        if (reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_id = (long)reader["ej_parsed_bna_transaction_id"];
                        if (reader["note_type"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.note_type = (int)reader["note_type"];
                        if (reader["notes_count"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.notes_count = (int)reader["notes_count"];
                        if (reader["total_remaining"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.total_remaining = (int?)reader["total_remaining"];
                        if (reader["total_rejected"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.total_rejected = (int?)reader["total_rejected"];
                    }

                    currentEjParsedBnaTransactionDetail.isNewEntity = false;
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

            public EjParsedBnaTransactionDetail CurrentEjParsedBnaTransactionDetail
            {
                get { return currentEjParsedBnaTransactionDetail; }
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


        #region EjParsedBnaTransactionDetail functions

        public static EjParsedBnaTransactionDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_parsed_bna_transaction_detail_id == (Columns.ej_parsed_bna_transaction_detail_id & columns))
                qry.Append("ej_parsed_bna_transaction_detail_id,");
            if (Columns.ej_parsed_bna_transaction_id == (Columns.ej_parsed_bna_transaction_id & columns))
                qry.Append("ej_parsed_bna_transaction_id,");
            if (Columns.note_type == (Columns.note_type & columns))
                qry.Append("note_type,");
            if (Columns.notes_count == (Columns.notes_count & columns))
                qry.Append("notes_count,");
            if (Columns.total_remaining == (Columns.total_remaining & columns))
                qry.Append("total_remaining,");
            if (Columns.total_rejected == (Columns.total_rejected & columns))
                qry.Append("total_rejected,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_parsed_bna_transaction_detail ");

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
            return new EjParsedBnaTransactionDetailReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjParsedBnaTransactionDetailReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjParsedBnaTransactionDetailReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectej_parsed_bna_transaction_detail_id,ej_parsed_bna_transaction_id,note_type,notes_count,total_remaining,total_rejectedfrom Ej_parsed_bna_transaction_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedBnaTransactionDetailReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedBnaTransactionDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public static EjParsedBnaTransactionDetail LoadEjParsedBnaTransactionDetail(string where)
        {
            EjParsedBnaTransactionDetailReader reader = EjParsedBnaTransactionDetail.ExecuteReader(where);
            EjParsedBnaTransactionDetail _ejparsedbnatransactiondetail = null;
            if (reader.Read())
                _ejparsedbnatransactiondetail = reader.CurrentEjParsedBnaTransactionDetail;
            reader.Close();
            return _ejparsedbnatransactiondetail;
        }

        public static EjParsedBnaTransactionDetail LoadEjParsedBnaTransactionDetail(string where, IDbConnection conn)
        {
            EjParsedBnaTransactionDetailReader reader = EjParsedBnaTransactionDetail.ExecuteReader(where, conn);
            EjParsedBnaTransactionDetail _ejparsedbnatransactiondetail = null;
            if (reader.Read())
                _ejparsedbnatransactiondetail = reader.CurrentEjParsedBnaTransactionDetail;
            reader.Close(false);
            return _ejparsedbnatransactiondetail;
        }

        public static EjParsedBnaTransactionDetail LoadEjParsedBnaTransactionDetailByPk(long ej_parsed_bna_transaction_detail_id)
        {
            return LoadEjParsedBnaTransactionDetail("ej_parsed_bna_transaction_detail_id=" + ej_parsed_bna_transaction_detail_id);
        }

        public static EjParsedBnaTransactionDetail LoadEjParsedBnaTransactionDetailByPk(long ej_parsed_bna_transaction_detail_id, IDbConnection conn)
        {
            return LoadEjParsedBnaTransactionDetail(" ej_parsed_bna_transaction_detail_id=" + ej_parsed_bna_transaction_detail_id, conn);
        }

        public void Save()
        {
            if (ej_parsed_bna_transaction_detail_idChanged || ej_parsed_bna_transaction_idChanged || note_typeChanged || notes_countChanged || total_remainingChanged || total_rejectedChanged)
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
            if (ej_parsed_bna_transaction_detail_idChanged || ej_parsed_bna_transaction_idChanged || note_typeChanged || notes_countChanged || total_remainingChanged || total_rejectedChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_bna_transaction_detail(ej_parsed_bna_transaction_detail_id,ej_parsed_bna_transaction_id,note_type,notes_count,total_remaining,total_rejected) values(");
                    lock (ConnectionFactory.connectionStringTx)
                    {
                        this.ej_parsed_bna_transaction_detail_id = ConnectionFactory.GetNextId(DatabaseName.Tx);
                        qry.Append(this.ej_parsed_bna_transaction_detail_id);
                    }
                    qry.Append(",");
                    qry.Append(ej_parsed_bna_transaction_idDbString + ",");
                    qry.Append(note_typeDbString + ",");
                    qry.Append(notes_countDbString + ",");
                    qry.Append(total_remainingDbString + ",");
                    qry.Append(total_rejectedDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_bna_transaction_detail_idChanged || ej_parsed_bna_transaction_idChanged || note_typeChanged || notes_countChanged || total_remainingChanged || total_rejectedChanged))
                        return;
                    qry.Append("UPDATE Ej_parsed_bna_transaction_detail set "); if (ej_parsed_bna_transaction_idChanged)
                    {
                        qry.Append("ej_parsed_bna_transaction_id =" + ej_parsed_bna_transaction_idDbString);
                        qry.Append(",");
                    }

                    if (note_typeChanged)
                    {
                        qry.Append("note_type =" + note_typeDbString);
                        qry.Append(",");
                    }

                    if (notes_countChanged)
                    {
                        qry.Append("notes_count =" + notes_countDbString);
                        qry.Append(",");
                    }

                    if (total_remainingChanged)
                    {
                        qry.Append("total_remaining =" + total_remainingDbString);
                        qry.Append(",");
                    }

                    if (total_rejectedChanged)
                    {
                        qry.Append("total_rejected =" + total_rejectedDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_parsed_bna_transaction_detail_id = " + ej_parsed_bna_transaction_detail_idDbString);
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
            cmd.CommandText = "DELETE Ej_parsed_bna_transaction_detail whereej_parsed_bna_transaction_detail_id= " + ej_parsed_bna_transaction_detail_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjParsedBnaTransactionDetails(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_bna_transaction_detail where " + where, DatabaseName.Tx);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_parsed_bna_transaction_detail_id = 0,
            ej_parsed_bna_transaction_id = 1,
            note_type = 2,
            notes_count = 3,
            total_remaining = 4,
            total_rejected = 5
        }
        #endregion
        public DataTable BulkSave(List<EjParsedBnaTransactionDetail> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_parsed_bna_transaction_detail";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjParsedBnaTransactionDetail.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjParsedBnaTransactionDetail> transList, ref DataTable dt)
        {
            foreach (EjParsedBnaTransactionDetail tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_parsed_bna_transaction_detail_id"] = ConnectionFactory.GetNextId(DatabaseName.Tx);
                Row["ej_parsed_bna_transaction_id"] = tran.EjParsedBnaTransactionId;
                Row["note_type"] = tran.NoteType;
                Row["notes_count"] = tran.NotesCount;
                Row["total_remaining"] = tran.TotalRemaining;
                Row["total_rejected"] = tran.TotalRejected;
                dt.Rows.Add(Row);
            }
        }
    }
}
