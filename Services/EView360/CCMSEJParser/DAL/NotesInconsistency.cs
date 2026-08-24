

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
    public class NotesInconsistency
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public NotesInconsistency() { }
        public NotesInconsistency(int notes_inconsistency_id, DateTime generated_at, int notes_diff_type1, int notes_diff_type2, int notes_diff_type3, int notes_diff_type4, int notes_diff_type5, int notes_diff_type6, int notes_diff_type7, int task_id, int atm_id)
        {
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.notes_diff_type1 = notes_diff_type1;
            this.notes_diff_type1Changed = true;
            this.notes_diff_type2 = notes_diff_type2;
            this.notes_diff_type2Changed = true;
            this.notes_diff_type3 = notes_diff_type3;
            this.notes_diff_type3Changed = true;
            this.notes_diff_type4 = notes_diff_type4;
            this.notes_diff_type4Changed = true;
            this.notes_diff_type5 = notes_diff_type5;
            this.notes_diff_type5Changed = true;
            this.notes_diff_type6 = notes_diff_type6;
            this.notes_diff_type6Changed = true;
            this.notes_diff_type7 = notes_diff_type7;
            this.notes_diff_type7Changed = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }
        public NotesInconsistency(DateTime generated_at, int notes_diff_type1, int notes_diff_type2, int notes_diff_type3, int notes_diff_type4, int notes_diff_type5, int notes_diff_type6, int notes_diff_type7, int task_id, string event_msg, int atm_id)
        {
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.notes_diff_type1 = notes_diff_type1;
            this.notes_diff_type1Changed = true;
            this.notes_diff_type2 = notes_diff_type2;
            this.notes_diff_type2Changed = true;
            this.notes_diff_type3 = notes_diff_type3;
            this.notes_diff_type3Changed = true;
            this.notes_diff_type4 = notes_diff_type4;
            this.notes_diff_type4Changed = true;
            this.notes_diff_type5 = notes_diff_type5;
            this.notes_diff_type5Changed = true;
            this.notes_diff_type6 = notes_diff_type6;
            this.notes_diff_type6Changed = true;
            this.notes_diff_type7 = notes_diff_type7;
            this.notes_diff_type7Changed = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.event_msg = event_msg;
            this.event_msgChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }
        private NotesInconsistency(int notes_inconsistency_id, DateTime generated_at, int notes_diff_type1, int notes_diff_type2, int notes_diff_type3, int notes_diff_type4, int notes_diff_type5, int notes_diff_type6, int notes_diff_type7, int task_id, string event_msg, int atm_id)
        {
            this.notes_inconsistency_id = notes_inconsistency_id;
            this.notes_inconsistency_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.notes_diff_type1 = notes_diff_type1;
            this.notes_diff_type1Changed = true;
            this.notes_diff_type2 = notes_diff_type2;
            this.notes_diff_type2Changed = true;
            this.notes_diff_type3 = notes_diff_type3;
            this.notes_diff_type3Changed = true;
            this.notes_diff_type4 = notes_diff_type4;
            this.notes_diff_type4Changed = true;
            this.notes_diff_type5 = notes_diff_type5;
            this.notes_diff_type5Changed = true;
            this.notes_diff_type6 = notes_diff_type6;
            this.notes_diff_type6Changed = true;
            this.notes_diff_type7 = notes_diff_type7;
            this.notes_diff_type7Changed = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.event_msg = event_msg;
            this.event_msgChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }

        #region members and properties for columns

        #region NotesInconsistencyId
        private bool notes_inconsistency_idChanged = false;
        private int notes_inconsistency_id;
        public int NotesInconsistencyId
        {
            get { return notes_inconsistency_id; }
            set
            {
                notes_inconsistency_id = value;
                notes_inconsistency_idChanged = true;
            }
        }
        private string notes_inconsistency_idDbString
        {
            get
            {
                return notes_inconsistency_id.ToString();
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
        #region NotesDiffType1
        private bool notes_diff_type1Changed = false;
        private int notes_diff_type1;
        public int NotesDiffType1
        {
            get { return notes_diff_type1; }
            set
            {
                notes_diff_type1 = value;
                notes_diff_type1Changed = true;
            }
        }
        private string notes_diff_type1DbString
        {
            get
            {
                return notes_diff_type1.ToString();
            }
        }
        #endregion
        #region NotesDiffType2
        private bool notes_diff_type2Changed = false;
        private int notes_diff_type2;
        public int NotesDiffType2
        {
            get { return notes_diff_type2; }
            set
            {
                notes_diff_type2 = value;
                notes_diff_type2Changed = true;
            }
        }
        private string notes_diff_type2DbString
        {
            get
            {
                return notes_diff_type2.ToString();
            }
        }
        #endregion
        #region NotesDiffType3
        private bool notes_diff_type3Changed = false;
        private int notes_diff_type3;
        public int NotesDiffType3
        {
            get { return notes_diff_type3; }
            set
            {
                notes_diff_type3 = value;
                notes_diff_type3Changed = true;
            }
        }
        private string notes_diff_type3DbString
        {
            get
            {
                return notes_diff_type3.ToString();
            }
        }
        #endregion
        #region NotesDiffType4
        private bool notes_diff_type4Changed = false;
        private int notes_diff_type4;
        public int NotesDiffType4
        {
            get { return notes_diff_type4; }
            set
            {
                notes_diff_type4 = value;
                notes_diff_type4Changed = true;
            }
        }
        private string notes_diff_type4DbString
        {
            get
            {
                return notes_diff_type4.ToString();
            }
        }
        #endregion
        #region NotesDiffType5
        private bool notes_diff_type5Changed = false;
        private int notes_diff_type5;
        public int NotesDiffType5
        {
            get { return notes_diff_type5; }
            set
            {
                notes_diff_type5 = value;
                notes_diff_type5Changed = true;
            }
        }
        private string notes_diff_type5DbString
        {
            get
            {
                return notes_diff_type5.ToString();
            }
        }
        #endregion
        #region NotesDiffType6
        private bool notes_diff_type6Changed = false;
        private int notes_diff_type6;
        public int NotesDiffType6
        {
            get { return notes_diff_type6; }
            set
            {
                notes_diff_type6 = value;
                notes_diff_type6Changed = true;
            }
        }
        private string notes_diff_type6DbString
        {
            get
            {
                return notes_diff_type6.ToString();
            }
        }
        #endregion
        #region NotesDiffType7
        private bool notes_diff_type7Changed = false;
        private int notes_diff_type7;
        public int NotesDiffType7
        {
            get { return notes_diff_type7; }
            set
            {
                notes_diff_type7 = value;
                notes_diff_type7Changed = true;
            }
        }
        private string notes_diff_type7DbString
        {
            get
            {
                return notes_diff_type7.ToString();
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
        #region EventMsg
        private bool event_msgChanged = false;
        private string event_msg;
        public string EventMsg
        {
            get { return event_msg; }
            set
            {
                event_msg = value;
                event_msgChanged = true;
            }
        }
        private string event_msgDbString
        {
            get
            {
                if (this.event_msg != null)
                    return string.Format("'{0}'", event_msg);
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

        #region NotesInconsistencyReader
        public class NotesInconsistencyReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            NotesInconsistency currentNotesInconsistency;
            Columns columns;
            bool partialRead = false;
            private NotesInconsistencyReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public NotesInconsistencyReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public NotesInconsistencyReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentNotesInconsistency; }

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
                    currentNotesInconsistency = new NotesInconsistency();
                    if (partialRead)
                    {
                        if ((columns & Columns.notes_inconsistency_id) == Columns.notes_inconsistency_id && reader["notes_inconsistency_id"] != DBNull.Value)
                            currentNotesInconsistency.notes_inconsistency_id = (int)reader["notes_inconsistency_id"];
                        if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"] != DBNull.Value)
                            currentNotesInconsistency.generated_at = (DateTime)reader["generated_at"];
                        if ((columns & Columns.notes_diff_type1) == Columns.notes_diff_type1 && reader["notes_diff_type1"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type1 = (int)reader["notes_diff_type1"];
                        if ((columns & Columns.notes_diff_type2) == Columns.notes_diff_type2 && reader["notes_diff_type2"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type2 = (int)reader["notes_diff_type2"];
                        if ((columns & Columns.notes_diff_type3) == Columns.notes_diff_type3 && reader["notes_diff_type3"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type3 = (int)reader["notes_diff_type3"];
                        if ((columns & Columns.notes_diff_type4) == Columns.notes_diff_type4 && reader["notes_diff_type4"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type4 = (int)reader["notes_diff_type4"];
                        if ((columns & Columns.notes_diff_type5) == Columns.notes_diff_type5 && reader["notes_diff_type5"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type5 = (int)reader["notes_diff_type5"];
                        if ((columns & Columns.notes_diff_type6) == Columns.notes_diff_type6 && reader["notes_diff_type6"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type6 = (int)reader["notes_diff_type6"];
                        if ((columns & Columns.notes_diff_type7) == Columns.notes_diff_type7 && reader["notes_diff_type7"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type7 = (int)reader["notes_diff_type7"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentNotesInconsistency.task_id = (int)reader["task_id"];
                        if ((columns & Columns.event_msg) == Columns.event_msg && reader["event_msg"] != DBNull.Value)
                            currentNotesInconsistency.event_msg = (string)reader["event_msg"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentNotesInconsistency.atm_id = (int)reader["atm_id"];

                    }
                    else
                    {
                        if (reader["notes_inconsistency_id"] != DBNull.Value)
                            currentNotesInconsistency.notes_inconsistency_id = (int)reader["notes_inconsistency_id"];
                        if (reader["generated_at"] != DBNull.Value)
                            currentNotesInconsistency.generated_at = (DateTime)reader["generated_at"];
                        if (reader["notes_diff_type1"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type1 = (int)reader["notes_diff_type1"];
                        if (reader["notes_diff_type2"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type2 = (int)reader["notes_diff_type2"];
                        if (reader["notes_diff_type3"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type3 = (int)reader["notes_diff_type3"];
                        if (reader["notes_diff_type4"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type4 = (int)reader["notes_diff_type4"];
                        if (reader["notes_diff_type5"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type5 = (int)reader["notes_diff_type5"];
                        if (reader["notes_diff_type6"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type6 = (int)reader["notes_diff_type6"];
                        if (reader["notes_diff_type7"] != DBNull.Value)
                            currentNotesInconsistency.notes_diff_type7 = (int)reader["notes_diff_type7"];
                        if (reader["task_id"] != DBNull.Value)
                            currentNotesInconsistency.task_id = (int)reader["task_id"];
                        if (reader["event_msg"] != DBNull.Value)
                            currentNotesInconsistency.event_msg = (string)reader["event_msg"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentNotesInconsistency.atm_id = (int)reader["atm_id"];
                    }

                    currentNotesInconsistency.isNewEntity = false;
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

            public NotesInconsistency CurrentNotesInconsistency
            {
                get { return currentNotesInconsistency; }
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


        #region NotesInconsistency functions

        public static NotesInconsistencyReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.notes_inconsistency_id == (Columns.notes_inconsistency_id & columns))
                qry.Append("notes_inconsistency_id,");
            if (Columns.generated_at == (Columns.generated_at & columns))
                qry.Append("generated_at,");
            if (Columns.notes_diff_type1 == (Columns.notes_diff_type1 & columns))
                qry.Append("notes_diff_type1,");
            if (Columns.notes_diff_type2 == (Columns.notes_diff_type2 & columns))
                qry.Append("notes_diff_type2,");
            if (Columns.notes_diff_type3 == (Columns.notes_diff_type3 & columns))
                qry.Append("notes_diff_type3,");
            if (Columns.notes_diff_type4 == (Columns.notes_diff_type4 & columns))
                qry.Append("notes_diff_type4,");
            if (Columns.notes_diff_type5 == (Columns.notes_diff_type5 & columns))
                qry.Append("notes_diff_type5,");
            if (Columns.notes_diff_type6 == (Columns.notes_diff_type6 & columns))
                qry.Append("notes_diff_type6,");
            if (Columns.notes_diff_type7 == (Columns.notes_diff_type7 & columns))
                qry.Append("notes_diff_type7,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.event_msg == (Columns.event_msg & columns))
                qry.Append("event_msg,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Notes_inconsistency ");

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
            return new NotesInconsistencyReader(cmd.ExecuteReader(), conn, columns);
        }

        static public NotesInconsistencyReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static NotesInconsistencyReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select notes_inconsistency_id,generated_at,notes_diff_type1,notes_diff_type2,notes_diff_type3,notes_diff_type4,notes_diff_type5,notes_diff_type6,notes_diff_type7,task_id,event_msg,atm_id from Notes_inconsistency ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new NotesInconsistencyReader(cmd.ExecuteReader(), conn);
        }

        static public NotesInconsistencyReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static NotesInconsistency LoadNotesInconsistency(string where)
        {
            NotesInconsistencyReader reader = NotesInconsistency.ExecuteReader(where);
            NotesInconsistency _notesinconsistency = null;
            if (reader.Read())
                _notesinconsistency = reader.CurrentNotesInconsistency;
            reader.Close();
            return _notesinconsistency;
        }

        public static NotesInconsistency LoadNotesInconsistency(string where, IDbConnection conn)
        {
            NotesInconsistencyReader reader = NotesInconsistency.ExecuteReader(where, conn);
            NotesInconsistency _notesinconsistency = null;
            if (reader.Read())
                _notesinconsistency = reader.CurrentNotesInconsistency;
            reader.Close(false);
            return _notesinconsistency;
        }

        public static NotesInconsistency LoadNotesInconsistencyByPk(int notes_inconsistency_id)
        {
            return LoadNotesInconsistency(" notes_inconsistency_id=" + notes_inconsistency_id);
        }

        public static NotesInconsistency LoadNotesInconsistencyByPk(int notes_inconsistency_id, IDbConnection conn)
        {
            return LoadNotesInconsistency(" notes_inconsistency_id=" + notes_inconsistency_id, conn);
        }

        public void Save()
        {
            if (notes_inconsistency_idChanged || generated_atChanged || notes_diff_type1Changed || notes_diff_type2Changed || notes_diff_type3Changed || notes_diff_type4Changed || notes_diff_type5Changed || notes_diff_type6Changed || notes_diff_type7Changed || task_idChanged || event_msgChanged || atm_idChanged)
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
            if (notes_inconsistency_idChanged || generated_atChanged || notes_diff_type1Changed || notes_diff_type2Changed || notes_diff_type3Changed || notes_diff_type4Changed || notes_diff_type5Changed || notes_diff_type6Changed || notes_diff_type7Changed || task_idChanged || event_msgChanged || atm_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Notes_inconsistency( notes_inconsistency_id,generated_at,notes_diff_type1,notes_diff_type2,notes_diff_type3,notes_diff_type4,notes_diff_type5,notes_diff_type6,notes_diff_type7,task_id,event_msg,atm_id ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.notes_inconsistency_id = ConnectionFactory.GetNextId();
                        qry.Append(this.notes_inconsistency_id);
                    } qry.Append(",");
                    qry.Append(generated_atDbString + ",");
                    qry.Append(notes_diff_type1DbString + ",");
                    qry.Append(notes_diff_type2DbString + ",");
                    qry.Append(notes_diff_type3DbString + ",");
                    qry.Append(notes_diff_type4DbString + ",");
                    qry.Append(notes_diff_type5DbString + ",");
                    qry.Append(notes_diff_type6DbString + ",");
                    qry.Append(notes_diff_type7DbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(event_msgDbString + ",");
                    qry.Append(atm_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(notes_inconsistency_idChanged || generated_atChanged || notes_diff_type1Changed || notes_diff_type2Changed || notes_diff_type3Changed || notes_diff_type4Changed || notes_diff_type5Changed || notes_diff_type6Changed || notes_diff_type7Changed || task_idChanged || event_msgChanged || atm_idChanged))
                        return;
                    qry.Append("UPDATE Notes_inconsistency set "); if (generated_atChanged)
                    {
                        qry.Append("generated_at =" + generated_atDbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type1Changed)
                    {
                        qry.Append("notes_diff_type1 =" + notes_diff_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type2Changed)
                    {
                        qry.Append("notes_diff_type2 =" + notes_diff_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type3Changed)
                    {
                        qry.Append("notes_diff_type3 =" + notes_diff_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type4Changed)
                    {
                        qry.Append("notes_diff_type4 =" + notes_diff_type4DbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type5Changed)
                    {
                        qry.Append("notes_diff_type5 =" + notes_diff_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type6Changed)
                    {
                        qry.Append("notes_diff_type6 =" + notes_diff_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_diff_type7Changed)
                    {
                        qry.Append("notes_diff_type7 =" + notes_diff_type7DbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (event_msgChanged)
                    {
                        qry.Append("event_msg =" + event_msgDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("notes_inconsistency_id = " + notes_inconsistency_idDbString);
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
            cmd.CommandText = "DELETE Notes_inconsistency where notes_inconsistency_id = " + notes_inconsistency_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteNotesInconsistencys(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Notes_inconsistency where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            notes_inconsistency_id = 1,
            generated_at = 2,
            notes_diff_type1 = 4,
            notes_diff_type2 = 8,
            notes_diff_type3 = 16,
            notes_diff_type4 = 32,
            notes_diff_type5 = 64,
            notes_diff_type6 = 128,
            notes_diff_type7 = 256,
            task_id = 512,
            event_msg = 1024,
            atm_id = 2048
        }
        #endregion
        public void BulkSave(List<NotesInconsistency> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Notes_inconsistency";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(NotesInconsistency.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<NotesInconsistency> transList, ref DataTable dt)
        {
            foreach (NotesInconsistency tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["notes_inconsistency_id"] = ConnectionFactory.GetNextId();
                Row["generated_at"] = tran.GeneratedAt;
                Row["notes_diff_type1"] = tran.NotesDiffType1;
                Row["notes_diff_type2"] = tran.NotesDiffType2;
                Row["notes_diff_type3"] = tran.NotesDiffType3;
                Row["notes_diff_type4"] = tran.NotesDiffType4;
                Row["notes_diff_type5"] = tran.NotesDiffType5;
                Row["notes_diff_type6"] = tran.NotesDiffType6;
                Row["notes_diff_type7"] = tran.NotesDiffType7;
                Row["task_id"] = tran.TaskId;
                Row["event_msg"] = tran.EventMsg;
                Row["atm_id"] = tran.AtmId;
                dt.Rows.Add(Row);
            }
        }
    }
}


