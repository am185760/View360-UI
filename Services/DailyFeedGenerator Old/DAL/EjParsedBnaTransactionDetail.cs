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
    public class EjParsedBnaTransactionDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedBnaTransactionDetail() { }
        public EjParsedBnaTransactionDetail(int ej_parsed_bna_transaction_detail_id, int ej_parsed_bna_transaction_id, int note_type, int notes_count, int cat_4_notes_total, int cat_3_notes_total, int cat_2_notes_total)
        {
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.note_type = note_type;
            this.note_typeChanged = true;
            this.notes_count = notes_count;
            this.notes_countChanged = true;
            this.cat_4_notes_total = cat_4_notes_total;
            this.cat_4_notes_totalChanged = true;
            this.cat_3_notes_total = cat_3_notes_total;
            this.cat_3_notes_totalChanged = true;
            this.cat_2_notes_total = cat_2_notes_total;
            this.cat_2_notes_totalChanged = true;
        }
        public EjParsedBnaTransactionDetail(int ej_parsed_bna_transaction_id, int note_type, int notes_count, string cat_4_notes_serials, int cat_4_notes_total, string cat_3_notes_serials, int cat_3_notes_total, string cat_2_notes_serials, int cat_2_notes_total)
        {
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.note_type = note_type;
            this.note_typeChanged = true;
            this.notes_count = notes_count;
            this.notes_countChanged = true;
            this.cat_4_notes_serials = cat_4_notes_serials;
            this.cat_4_notes_serialsChanged = true;
            this.cat_4_notes_total = cat_4_notes_total;
            this.cat_4_notes_totalChanged = true;
            this.cat_3_notes_serials = cat_3_notes_serials;
            this.cat_3_notes_serialsChanged = true;
            this.cat_3_notes_total = cat_3_notes_total;
            this.cat_3_notes_totalChanged = true;
            this.cat_2_notes_serials = cat_2_notes_serials;
            this.cat_2_notes_serialsChanged = true;
            this.cat_2_notes_total = cat_2_notes_total;
            this.cat_2_notes_totalChanged = true;
        }
        private EjParsedBnaTransactionDetail(int ej_parsed_bna_transaction_detail_id, int ej_parsed_bna_transaction_id, int note_type, int notes_count, string cat_4_notes_serials, int cat_4_notes_total, string cat_3_notes_serials, int cat_3_notes_total, string cat_2_notes_serials, int cat_2_notes_total)
        {
            this.ej_parsed_bna_transaction_detail_id = ej_parsed_bna_transaction_detail_id;
            this.ej_parsed_bna_transaction_detail_idChanged = true;
            this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
            this.ej_parsed_bna_transaction_idChanged = true;
            this.note_type = note_type;
            this.note_typeChanged = true;
            this.notes_count = notes_count;
            this.notes_countChanged = true;
            this.cat_4_notes_serials = cat_4_notes_serials;
            this.cat_4_notes_serialsChanged = true;
            this.cat_4_notes_total = cat_4_notes_total;
            this.cat_4_notes_totalChanged = true;
            this.cat_3_notes_serials = cat_3_notes_serials;
            this.cat_3_notes_serialsChanged = true;
            this.cat_3_notes_total = cat_3_notes_total;
            this.cat_3_notes_totalChanged = true;
            this.cat_2_notes_serials = cat_2_notes_serials;
            this.cat_2_notes_serialsChanged = true;
            this.cat_2_notes_total = cat_2_notes_total;
            this.cat_2_notes_totalChanged = true;
        }

        #region members and properties for columns

        #region EjParsedBnaTransactionDetailId
        private bool ej_parsed_bna_transaction_detail_idChanged = false;
        private int ej_parsed_bna_transaction_detail_id;
        public int EjParsedBnaTransactionDetailId
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
        private int ej_parsed_bna_transaction_id;
        public int EjParsedBnaTransactionId
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
        #region Cat4NotesSerials
        private bool cat_4_notes_serialsChanged = false;
        private string cat_4_notes_serials;
        public string Cat4NotesSerials
        {
            get { return cat_4_notes_serials; }
            set
            {
                cat_4_notes_serials = value;
                cat_4_notes_serialsChanged = true;
            }
        }
        private string cat_4_notes_serialsDbString
        {
            get
            {
                if (this.cat_4_notes_serials != null)
                    return string.Format("'{0}'", cat_4_notes_serials);
                else
                    return "null";
            }
        }
        #endregion
        #region Cat4NotesTotal
        private bool cat_4_notes_totalChanged = false;
        private int cat_4_notes_total;
        public int Cat4NotesTotal
        {
            get { return cat_4_notes_total; }
            set
            {
                cat_4_notes_total = value;
                cat_4_notes_totalChanged = true;
            }
        }
        private string cat_4_notes_totalDbString
        {
            get
            {
                return cat_4_notes_total.ToString();
            }
        }
        #endregion
        #region Cat3NotesSerials
        private bool cat_3_notes_serialsChanged = false;
        private string cat_3_notes_serials;
        public string Cat3NotesSerials
        {
            get { return cat_3_notes_serials; }
            set
            {
                cat_3_notes_serials = value;
                cat_3_notes_serialsChanged = true;
            }
        }
        private string cat_3_notes_serialsDbString
        {
            get
            {
                if (this.cat_3_notes_serials != null)
                    return string.Format("'{0}'", cat_3_notes_serials);
                else
                    return "null";
            }
        }
        #endregion
        #region Cat3NotesTotal
        private bool cat_3_notes_totalChanged = false;
        private int cat_3_notes_total;
        public int Cat3NotesTotal
        {
            get { return cat_3_notes_total; }
            set
            {
                cat_3_notes_total = value;
                cat_3_notes_totalChanged = true;
            }
        }
        private string cat_3_notes_totalDbString
        {
            get
            {
                return cat_3_notes_total.ToString();
            }
        }
        #endregion
        #region Cat2NotesSerials
        private bool cat_2_notes_serialsChanged = false;
        private string cat_2_notes_serials;
        public string Cat2NotesSerials
        {
            get { return cat_2_notes_serials; }
            set
            {
                cat_2_notes_serials = value;
                cat_2_notes_serialsChanged = true;
            }
        }
        private string cat_2_notes_serialsDbString
        {
            get
            {
                if (this.cat_2_notes_serials != null)
                    return string.Format("'{0}'", cat_2_notes_serials);
                else
                    return "null";
            }
        }
        #endregion
        #region Cat2NotesTotal
        private bool cat_2_notes_totalChanged = false;
        private int cat_2_notes_total;
        public int Cat2NotesTotal
        {
            get { return cat_2_notes_total; }
            set
            {
                cat_2_notes_total = value;
                cat_2_notes_totalChanged = true;
            }
        }
        private string cat_2_notes_totalDbString
        {
            get
            {
                return cat_2_notes_total.ToString();
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
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_detail_id = (int)reader["ej_parsed_bna_transaction_detail_id"];
                        if ((columns & Columns.ej_parsed_bna_transaction_id) == Columns.ej_parsed_bna_transaction_id && reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_id = (int)reader["ej_parsed_bna_transaction_id"];
                        if ((columns & Columns.note_type) == Columns.note_type && reader["note_type"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.note_type = (int)reader["note_type"];
                        if ((columns & Columns.notes_count) == Columns.notes_count && reader["notes_count"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.notes_count = (int)reader["notes_count"];
                        if ((columns & Columns.cat_4_notes_serials) == Columns.cat_4_notes_serials && reader["cat_4_notes_serials"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_4_notes_serials = (string)reader["cat_4_notes_serials"];
                        if ((columns & Columns.cat_4_notes_total) == Columns.cat_4_notes_total && reader["cat_4_notes_total"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_4_notes_total = (int)reader["cat_4_notes_total"];
                        if ((columns & Columns.cat_3_notes_serials) == Columns.cat_3_notes_serials && reader["cat_3_notes_serials"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_3_notes_serials = (string)reader["cat_3_notes_serials"];
                        if ((columns & Columns.cat_3_notes_total) == Columns.cat_3_notes_total && reader["cat_3_notes_total"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_3_notes_total = (int)reader["cat_3_notes_total"];
                        if ((columns & Columns.cat_2_notes_serials) == Columns.cat_2_notes_serials && reader["cat_2_notes_serials"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_2_notes_serials = (string)reader["cat_2_notes_serials"];
                        if ((columns & Columns.cat_2_notes_total) == Columns.cat_2_notes_total && reader["cat_2_notes_total"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_2_notes_total = (int)reader["cat_2_notes_total"];

                    }
                    else
                    {
                        if (reader["ej_parsed_bna_transaction_detail_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_detail_id = (int)reader["ej_parsed_bna_transaction_detail_id"];
                        if (reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.ej_parsed_bna_transaction_id = (int)reader["ej_parsed_bna_transaction_id"];
                        if (reader["note_type"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.note_type = (int)reader["note_type"];
                        if (reader["notes_count"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.notes_count = (int)reader["notes_count"];
                        if (reader["cat_4_notes_serials"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_4_notes_serials = (string)reader["cat_4_notes_serials"];
                        if (reader["cat_4_notes_total"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_4_notes_total = (int)reader["cat_4_notes_total"];
                        if (reader["cat_3_notes_serials"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_3_notes_serials = (string)reader["cat_3_notes_serials"];
                        if (reader["cat_3_notes_total"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_3_notes_total = (int)reader["cat_3_notes_total"];
                        if (reader["cat_2_notes_serials"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_2_notes_serials = (string)reader["cat_2_notes_serials"];
                        if (reader["cat_2_notes_total"] != DBNull.Value)
                            currentEjParsedBnaTransactionDetail.cat_2_notes_total = (int)reader["cat_2_notes_total"];
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
            if (Columns.cat_4_notes_serials == (Columns.cat_4_notes_serials & columns))
                qry.Append("cat_4_notes_serials,");
            if (Columns.cat_4_notes_total == (Columns.cat_4_notes_total & columns))
                qry.Append("cat_4_notes_total,");
            if (Columns.cat_3_notes_serials == (Columns.cat_3_notes_serials & columns))
                qry.Append("cat_3_notes_serials,");
            if (Columns.cat_3_notes_total == (Columns.cat_3_notes_total & columns))
                qry.Append("cat_3_notes_total,");
            if (Columns.cat_2_notes_serials == (Columns.cat_2_notes_serials & columns))
                qry.Append("cat_2_notes_serials,");
            if (Columns.cat_2_notes_total == (Columns.cat_2_notes_total & columns))
                qry.Append("cat_2_notes_total,");
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
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
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
            cmd.CommandText = "Select ej_parsed_bna_transaction_detail_id,ej_parsed_bna_transaction_id,note_type,notes_count,cat_4_notes_serials,cat_4_notes_total,cat_3_notes_serials,cat_3_notes_total,cat_2_notes_serials,cat_2_notes_total from Ej_parsed_bna_transaction_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedBnaTransactionDetailReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedBnaTransactionDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
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

        public static EjParsedBnaTransactionDetail LoadEjParsedBnaTransactionDetailByPk(int ej_parsed_bna_transaction_detail_id)
        {
            return LoadEjParsedBnaTransactionDetail("ej_parsed_bna_transaction_detail_id=" + ej_parsed_bna_transaction_detail_id);
        }

        public static EjParsedBnaTransactionDetail LoadEjParsedBnaTransactionDetailByPk(int ej_parsed_bna_transaction_detail_id, IDbConnection conn)
        {
            return LoadEjParsedBnaTransactionDetail(" ej_parsed_bna_transaction_detail_id=" + ej_parsed_bna_transaction_detail_id, conn);
        }

        public void Save()
        {
            if (ej_parsed_bna_transaction_detail_idChanged || ej_parsed_bna_transaction_idChanged || note_typeChanged || notes_countChanged || cat_4_notes_serialsChanged || cat_4_notes_totalChanged || cat_3_notes_serialsChanged || cat_3_notes_totalChanged || cat_2_notes_serialsChanged || cat_2_notes_totalChanged)
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
            if (ej_parsed_bna_transaction_detail_idChanged || ej_parsed_bna_transaction_idChanged || note_typeChanged || notes_countChanged || cat_4_notes_serialsChanged || cat_4_notes_totalChanged || cat_3_notes_serialsChanged || cat_3_notes_totalChanged || cat_2_notes_serialsChanged || cat_2_notes_totalChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_bna_transaction_detail(ej_parsed_bna_transaction_detail_id,ej_parsed_bna_transaction_id,note_type,notes_count,cat_4_notes_serials,cat_4_notes_total,cat_3_notes_serials,cat_3_notes_total,cat_2_notes_serials,cat_2_notes_total) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.ej_parsed_bna_transaction_detail_id = ConnectionFactory.GetNextId();
                        qry.Append(this.ej_parsed_bna_transaction_detail_id);
                    } qry.Append(",");
                    qry.Append(ej_parsed_bna_transaction_idDbString + ",");
                    qry.Append(note_typeDbString + ",");
                    qry.Append(notes_countDbString + ",");
                    qry.Append(cat_4_notes_serialsDbString + ",");
                    qry.Append(cat_4_notes_totalDbString + ",");
                    qry.Append(cat_3_notes_serialsDbString + ",");
                    qry.Append(cat_3_notes_totalDbString + ",");
                    qry.Append(cat_2_notes_serialsDbString + ",");
                    qry.Append(cat_2_notes_totalDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_bna_transaction_detail_idChanged || ej_parsed_bna_transaction_idChanged || note_typeChanged || notes_countChanged || cat_4_notes_serialsChanged || cat_4_notes_totalChanged || cat_3_notes_serialsChanged || cat_3_notes_totalChanged || cat_2_notes_serialsChanged || cat_2_notes_totalChanged))
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

                    if (cat_4_notes_serialsChanged)
                    {
                        qry.Append("cat_4_notes_serials =" + cat_4_notes_serialsDbString);
                        qry.Append(",");
                    }

                    if (cat_4_notes_totalChanged)
                    {
                        qry.Append("cat_4_notes_total =" + cat_4_notes_totalDbString);
                        qry.Append(",");
                    }

                    if (cat_3_notes_serialsChanged)
                    {
                        qry.Append("cat_3_notes_serials =" + cat_3_notes_serialsDbString);
                        qry.Append(",");
                    }

                    if (cat_3_notes_totalChanged)
                    {
                        qry.Append("cat_3_notes_total =" + cat_3_notes_totalDbString);
                        qry.Append(",");
                    }

                    if (cat_2_notes_serialsChanged)
                    {
                        qry.Append("cat_2_notes_serials =" + cat_2_notes_serialsDbString);
                        qry.Append(",");
                    }

                    if (cat_2_notes_totalChanged)
                    {
                        qry.Append("cat_2_notes_total =" + cat_2_notes_totalDbString);
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
            Delete(ConnectionFactory.GetNewConnection());
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Ej_parsed_bna_transaction_detail where ej_parsed_bna_transaction_detail_id= " + ej_parsed_bna_transaction_detail_id;
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
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_bna_transaction_detail where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_parsed_bna_transaction_detail_id = 1,
            ej_parsed_bna_transaction_id = 2,
            note_type = 4,
            notes_count = 8,
            cat_4_notes_serials = 16,
            cat_4_notes_total = 32,
            cat_3_notes_serials = 64,
            cat_3_notes_total = 128,
            cat_2_notes_serials = 256,
            cat_2_notes_total = 512
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
                Row["ej_parsed_bna_transaction_detail_id"] = ConnectionFactory.GetNextId();
                Row["ej_parsed_bna_transaction_id"] = tran.EjParsedBnaTransactionId;
                Row["note_type"] = tran.NoteType;
                Row["notes_count"] = tran.NotesCount;
                Row["cat_4_notes_serials"] = tran.Cat4NotesSerials;
                Row["cat_4_notes_total"] = tran.Cat4NotesTotal;
                Row["cat_3_notes_serials"] = tran.Cat3NotesSerials;
                Row["cat_3_notes_total"] = tran.Cat3NotesTotal;
                Row["cat_2_notes_serials"] = tran.Cat2NotesSerials;
                Row["cat_2_notes_total"] = tran.Cat2NotesTotal;
                dt.Rows.Add(Row);
            }
        }
    }
}