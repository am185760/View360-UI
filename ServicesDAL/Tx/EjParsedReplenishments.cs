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
    public class EjParsedReplenishments
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedReplenishments() { }
        public EjParsedReplenishments(long ej_parsed_replenishments_id, DateTime rep_datetime)
        {
            this.rep_datetime = rep_datetime;
            this.rep_datetimeChanged = true;
        }
        public EjParsedReplenishments(long? atm_id, int? notes_added_type1, int? notes_added_type2, int? notes_added_type3, int? notes_added_type4, DateTime rep_datetime, long? task_id, DateTime? processing_datetime, int? start_index, int? end_index, int? last_tsn, int? notes_Added_type5, int? notes_Added_type6, int? notes_Added_type7)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.notes_added_type1 = notes_added_type1;
            this.notes_added_type1Changed = true;
            this.notes_added_type2 = notes_added_type2;
            this.notes_added_type2Changed = true;
            this.notes_added_type3 = notes_added_type3;
            this.notes_added_type3Changed = true;
            this.notes_added_type4 = notes_added_type4;
            this.notes_added_type4Changed = true;
            this.rep_datetime = rep_datetime;
            this.rep_datetimeChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.last_tsn = last_tsn;
            this.last_tsnChanged = true;
            this.notes_Added_type5 = notes_Added_type5;
            this.notes_Added_type5Changed = true;
            this.notes_Added_type6 = notes_Added_type6;
            this.notes_Added_type6Changed = true;
            this.notes_Added_type7 = notes_Added_type7;
            this.notes_Added_type7Changed = true;
        }
        private EjParsedReplenishments(long ej_parsed_replenishments_id, long? atm_id, int? notes_added_type1, int? notes_added_type2, int? notes_added_type3, int? notes_added_type4, DateTime rep_datetime, long? task_id, DateTime? processing_datetime, int? start_index, int? end_index, int? last_tsn, int? notes_Added_type5, int? notes_Added_type6, int? notes_Added_type7)
        {
            this.ej_parsed_replenishments_id = ej_parsed_replenishments_id;
            this.ej_parsed_replenishments_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.notes_added_type1 = notes_added_type1;
            this.notes_added_type1Changed = true;
            this.notes_added_type2 = notes_added_type2;
            this.notes_added_type2Changed = true;
            this.notes_added_type3 = notes_added_type3;
            this.notes_added_type3Changed = true;
            this.notes_added_type4 = notes_added_type4;
            this.notes_added_type4Changed = true;
            this.rep_datetime = rep_datetime;
            this.rep_datetimeChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.last_tsn = last_tsn;
            this.last_tsnChanged = true;
            this.notes_Added_type5 = notes_Added_type5;
            this.notes_Added_type5Changed = true;
            this.notes_Added_type6 = notes_Added_type6;
            this.notes_Added_type6Changed = true;
            this.notes_Added_type7 = notes_Added_type7;
            this.notes_Added_type7Changed = true;
        }

        #region members and properties for columns

        #region EjParsedReplenishmentsId
        private bool ej_parsed_replenishments_idChanged = false;
        private long ej_parsed_replenishments_id;
        public long EjParsedReplenishmentsId
        {
            get { return ej_parsed_replenishments_id; }
            set
            {
                ej_parsed_replenishments_id = value;
                ej_parsed_replenishments_idChanged = true;
            }
        }
        private string ej_parsed_replenishments_idDbString
        {
            get
            {
                return ej_parsed_replenishments_id.ToString();
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private long? atm_id;
        public long? AtmId
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
                if (this.atm_id.HasValue)
                    return atm_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType1
        private bool notes_added_type1Changed = false;
        private int? notes_added_type1;
        public int? NotesAddedType1
        {
            get { return notes_added_type1; }
            set
            {
                notes_added_type1 = value;
                notes_added_type1Changed = true;
            }
        }
        private string notes_added_type1DbString
        {
            get
            {
                if (this.notes_added_type1.HasValue)
                    return notes_added_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType2
        private bool notes_added_type2Changed = false;
        private int? notes_added_type2;
        public int? NotesAddedType2
        {
            get { return notes_added_type2; }
            set
            {
                notes_added_type2 = value;
                notes_added_type2Changed = true;
            }
        }
        private string notes_added_type2DbString
        {
            get
            {
                if (this.notes_added_type2.HasValue)
                    return notes_added_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType3
        private bool notes_added_type3Changed = false;
        private int? notes_added_type3;
        public int? NotesAddedType3
        {
            get { return notes_added_type3; }
            set
            {
                notes_added_type3 = value;
                notes_added_type3Changed = true;
            }
        }
        private string notes_added_type3DbString
        {
            get
            {
                if (this.notes_added_type3.HasValue)
                    return notes_added_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType4
        private bool notes_added_type4Changed = false;
        private int? notes_added_type4;
        public int? NotesAddedType4
        {
            get { return notes_added_type4; }
            set
            {
                notes_added_type4 = value;
                notes_added_type4Changed = true;
            }
        }
        private string notes_added_type4DbString
        {
            get
            {
                if (this.notes_added_type4.HasValue)
                    return notes_added_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region RepDatetime
        private bool rep_datetimeChanged = false;
        private DateTime rep_datetime;
        public DateTime RepDatetime
        {
            get { return rep_datetime; }
            set
            {
                rep_datetime = value;
                rep_datetimeChanged = true;
            }
        }
        private string rep_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", rep_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #region ProcessingDatetime
        private bool processing_datetimeChanged = false;
        private DateTime? processing_datetime;
        public DateTime? ProcessingDatetime
        {
            get { return processing_datetime; }
            set
            {
                processing_datetime = value;
                processing_datetimeChanged = true;
            }
        }
        private string processing_datetimeDbString
        {
            get
            {
                if (this.processing_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", processing_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region StartIndex
        private bool start_indexChanged = false;
        private int? start_index;
        public int? StartIndex
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
                if (this.start_index.HasValue)
                    return start_index.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EndIndex
        private bool end_indexChanged = false;
        private int? end_index;
        public int? EndIndex
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
                if (this.end_index.HasValue)
                    return end_index.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region LastTsn
        private bool last_tsnChanged = false;
        private int? last_tsn;
        public int? LastTsn
        {
            get { return last_tsn; }
            set
            {
                last_tsn = value;
                last_tsnChanged = true;
            }
        }
        private string last_tsnDbString
        {
            get
            {
                if (this.last_tsn.HasValue)
                    return last_tsn.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType5
        private bool notes_Added_type5Changed = false;
        private int? notes_Added_type5;
        public int? NotesAddedType5
        {
            get { return notes_Added_type5; }
            set
            {
                notes_Added_type5 = value;
                notes_Added_type5Changed = true;
            }
        }
        private string notes_Added_type5DbString
        {
            get
            {
                if (this.notes_Added_type5.HasValue)
                    return notes_Added_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType6
        private bool notes_Added_type6Changed = false;
        private int? notes_Added_type6;
        public int? NotesAddedType6
        {
            get { return notes_Added_type6; }
            set
            {
                notes_Added_type6 = value;
                notes_Added_type6Changed = true;
            }
        }
        private string notes_Added_type6DbString
        {
            get
            {
                if (this.notes_Added_type6.HasValue)
                    return notes_Added_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesAddedType7
        private bool notes_Added_type7Changed = false;
        private int? notes_Added_type7;
        public bool IsBillDispenser;
        public int? NotesAddedType7
        {
            get { return notes_Added_type7; }
            set
            {
                notes_Added_type7 = value;
                notes_Added_type7Changed = true;
            }
        }
        private string notes_Added_type7DbString
        {
            get
            {
                if (this.notes_Added_type7.HasValue)
                    return notes_Added_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region EjParsedReplenishmentsReader
        public class EjParsedReplenishmentsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjParsedReplenishments currentEjParsedReplenishments;
            Columns columns;
            bool partialRead = false;
            private EjParsedReplenishmentsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjParsedReplenishmentsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjParsedReplenishmentsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjParsedReplenishments; }

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
                    currentEjParsedReplenishments = new EjParsedReplenishments();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_parsed_replenishments_id) == Columns.ej_parsed_replenishments_id && reader["ej_parsed_replenishments_id"] != DBNull.Value)
                            currentEjParsedReplenishments.ej_parsed_replenishments_id = (long)reader["ej_parsed_replenishments_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentEjParsedReplenishments.atm_id = (long?)reader["atm_id"];
                        if ((columns & Columns.notes_added_type1) == Columns.notes_added_type1 && reader["notes_added_type1"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type1 = (int?)reader["notes_added_type1"];
                        if ((columns & Columns.notes_added_type2) == Columns.notes_added_type2 && reader["notes_added_type2"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type2 = (int?)reader["notes_added_type2"];
                        if ((columns & Columns.notes_added_type3) == Columns.notes_added_type3 && reader["notes_added_type3"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type3 = (int?)reader["notes_added_type3"];
                        if ((columns & Columns.notes_added_type4) == Columns.notes_added_type4 && reader["notes_added_type4"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type4 = (int?)reader["notes_added_type4"];
                        if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"] != DBNull.Value)
                            currentEjParsedReplenishments.rep_datetime = (DateTime)reader["rep_datetime"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentEjParsedReplenishments.task_id = (long?)reader["task_id"];
                        if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"] != DBNull.Value)
                            currentEjParsedReplenishments.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if ((columns & Columns.start_index) == Columns.start_index && reader["start_index"] != DBNull.Value)
                            currentEjParsedReplenishments.start_index = (int?)reader["start_index"];
                        if ((columns & Columns.end_index) == Columns.end_index && reader["end_index"] != DBNull.Value)
                            currentEjParsedReplenishments.end_index = (int?)reader["end_index"];
                        if ((columns & Columns.last_tsn) == Columns.last_tsn && reader["last_tsn"] != DBNull.Value)
                            currentEjParsedReplenishments.last_tsn = (int?)reader["last_tsn"];
                        if ((columns & Columns.notes_Added_type5) == Columns.notes_Added_type5 && reader["notes_Added_type5"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_Added_type5 = (int?)reader["notes_Added_type5"];
                        if ((columns & Columns.notes_Added_type6) == Columns.notes_Added_type6 && reader["notes_Added_type6"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_Added_type6 = (int?)reader["notes_Added_type6"];
                        if ((columns & Columns.notes_Added_type7) == Columns.notes_Added_type7 && reader["notes_Added_type7"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_Added_type7 = (int?)reader["notes_Added_type7"];

                    }
                    else
                    {
                        if (reader["ej_parsed_replenishments_id"] != DBNull.Value)
                            currentEjParsedReplenishments.ej_parsed_replenishments_id = (long)reader["ej_parsed_replenishments_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentEjParsedReplenishments.atm_id = (long?)reader["atm_id"];
                        if (reader["notes_added_type1"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type1 = (int?)reader["notes_added_type1"];
                        if (reader["notes_added_type2"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type2 = (int?)reader["notes_added_type2"];
                        if (reader["notes_added_type3"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type3 = (int?)reader["notes_added_type3"];
                        if (reader["notes_added_type4"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_added_type4 = (int?)reader["notes_added_type4"];
                        if (reader["rep_datetime"] != DBNull.Value)
                            currentEjParsedReplenishments.rep_datetime = (DateTime)reader["rep_datetime"];
                        if (reader["task_id"] != DBNull.Value)
                            currentEjParsedReplenishments.task_id = (long?)reader["task_id"];
                        if (reader["processing_datetime"] != DBNull.Value)
                            currentEjParsedReplenishments.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if (reader["start_index"] != DBNull.Value)
                            currentEjParsedReplenishments.start_index = (int?)reader["start_index"];
                        if (reader["end_index"] != DBNull.Value)
                            currentEjParsedReplenishments.end_index = (int?)reader["end_index"];
                        if (reader["last_tsn"] != DBNull.Value)
                            currentEjParsedReplenishments.last_tsn = (int?)reader["last_tsn"];
                        if (reader["notes_Added_type5"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_Added_type5 = (int?)reader["notes_Added_type5"];
                        if (reader["notes_Added_type6"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_Added_type6 = (int?)reader["notes_Added_type6"];
                        if (reader["notes_Added_type7"] != DBNull.Value)
                            currentEjParsedReplenishments.notes_Added_type7 = (int?)reader["notes_Added_type7"];
                    }

                    currentEjParsedReplenishments.isNewEntity = false;
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

            public EjParsedReplenishments CurrentEjParsedReplenishments
            {
                get { return currentEjParsedReplenishments; }
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


        #region EjParsedReplenishments functions

        public static EjParsedReplenishmentsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_parsed_replenishments_id == (Columns.ej_parsed_replenishments_id & columns))
                qry.Append("ej_parsed_replenishments_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.notes_added_type1 == (Columns.notes_added_type1 & columns))
                qry.Append("notes_added_type1,");
            if (Columns.notes_added_type2 == (Columns.notes_added_type2 & columns))
                qry.Append("notes_added_type2,");
            if (Columns.notes_added_type3 == (Columns.notes_added_type3 & columns))
                qry.Append("notes_added_type3,");
            if (Columns.notes_added_type4 == (Columns.notes_added_type4 & columns))
                qry.Append("notes_added_type4,");
            if (Columns.rep_datetime == (Columns.rep_datetime & columns))
                qry.Append("rep_datetime,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.processing_datetime == (Columns.processing_datetime & columns))
                qry.Append("processing_datetime,");
            if (Columns.start_index == (Columns.start_index & columns))
                qry.Append("start_index,");
            if (Columns.end_index == (Columns.end_index & columns))
                qry.Append("end_index,");
            if (Columns.last_tsn == (Columns.last_tsn & columns))
                qry.Append("last_tsn,");
            if (Columns.notes_Added_type5 == (Columns.notes_Added_type5 & columns))
                qry.Append("notes_Added_type5,");
            if (Columns.notes_Added_type6 == (Columns.notes_Added_type6 & columns))
                qry.Append("notes_Added_type6,");
            if (Columns.notes_Added_type7 == (Columns.notes_Added_type7 & columns))
                qry.Append("notes_Added_type7,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_parsed_replenishments ");

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
            return new EjParsedReplenishmentsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjParsedReplenishmentsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjParsedReplenishmentsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectej_parsed_replenishments_id,atm_id,notes_added_type1,notes_added_type2,notes_added_type3,notes_added_type4,rep_datetime,task_id,processing_datetime,start_index,end_index,last_tsn,notes_Added_type5,notes_Added_type6,notes_Added_type7from Ej_parsed_replenishments ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedReplenishmentsReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedReplenishmentsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public static EjParsedReplenishments LoadEjParsedReplenishments(string where)
        {
            EjParsedReplenishmentsReader reader = EjParsedReplenishments.ExecuteReader(where);
            EjParsedReplenishments _ejparsedreplenishments = null;
            if (reader.Read())
                _ejparsedreplenishments = reader.CurrentEjParsedReplenishments;
            reader.Close();
            return _ejparsedreplenishments;
        }

        public static EjParsedReplenishments LoadEjParsedReplenishments(string where, IDbConnection conn)
        {
            EjParsedReplenishmentsReader reader = EjParsedReplenishments.ExecuteReader(where, conn);
            EjParsedReplenishments _ejparsedreplenishments = null;
            if (reader.Read())
                _ejparsedreplenishments = reader.CurrentEjParsedReplenishments;
            reader.Close(false);
            return _ejparsedreplenishments;
        }

        public static EjParsedReplenishments LoadEjParsedReplenishmentsByPk(long ej_parsed_replenishments_id, DateTime rep_datetime)
        {
            return LoadEjParsedReplenishments("ej_parsed_replenishments_id=" + ej_parsed_replenishments_id + " and rep_datetime=Convert(datetime,'" + rep_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)");
        }

        public static EjParsedReplenishments LoadEjParsedReplenishmentsByPk(long ej_parsed_replenishments_id, DateTime rep_datetime, IDbConnection conn)
        {
            return LoadEjParsedReplenishments(" ej_parsed_replenishments_id=" + ej_parsed_replenishments_id + " and rep_datetime=Convert(datetime,'" + rep_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)", conn);
        }

        public void Save()
        {
            if (ej_parsed_replenishments_idChanged || atm_idChanged || notes_added_type1Changed || notes_added_type2Changed || notes_added_type3Changed || notes_added_type4Changed || rep_datetimeChanged || task_idChanged || processing_datetimeChanged || start_indexChanged || end_indexChanged || last_tsnChanged || notes_Added_type5Changed || notes_Added_type6Changed || notes_Added_type7Changed)
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
            if (ej_parsed_replenishments_idChanged || atm_idChanged || notes_added_type1Changed || notes_added_type2Changed || notes_added_type3Changed || notes_added_type4Changed || rep_datetimeChanged || task_idChanged || processing_datetimeChanged || start_indexChanged || end_indexChanged || last_tsnChanged || notes_Added_type5Changed || notes_Added_type6Changed || notes_Added_type7Changed)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_replenishments(ej_parsed_replenishments_id,atm_id,notes_added_type1,notes_added_type2,notes_added_type3,notes_added_type4,rep_datetime,task_id,processing_datetime,start_index,end_index,last_tsn,notes_Added_type5,notes_Added_type6,notes_Added_type7) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.ej_parsed_replenishments_id = ConnectionFactory.GetNextId(DatabaseName.Tx);
                        qry.Append(this.ej_parsed_replenishments_id);
                    }
                    qry.Append(",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(notes_added_type1DbString + ",");
                    qry.Append(notes_added_type2DbString + ",");
                    qry.Append(notes_added_type3DbString + ",");
                    qry.Append(notes_added_type4DbString + ",");
                    qry.Append(rep_datetimeDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(processing_datetimeDbString + ",");
                    qry.Append(start_indexDbString + ",");
                    qry.Append(end_indexDbString + ",");
                    qry.Append(last_tsnDbString + ",");
                    qry.Append(notes_Added_type5DbString + ",");
                    qry.Append(notes_Added_type6DbString + ",");
                    qry.Append(notes_Added_type7DbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_replenishments_idChanged || atm_idChanged || notes_added_type1Changed || notes_added_type2Changed || notes_added_type3Changed || notes_added_type4Changed || rep_datetimeChanged || task_idChanged || processing_datetimeChanged || start_indexChanged || end_indexChanged || last_tsnChanged || notes_Added_type5Changed || notes_Added_type6Changed || notes_Added_type7Changed))
                        return;
                    qry.Append("UPDATE Ej_parsed_replenishments set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (notes_added_type1Changed)
                    {
                        qry.Append("notes_added_type1 =" + notes_added_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_added_type2Changed)
                    {
                        qry.Append("notes_added_type2 =" + notes_added_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_added_type3Changed)
                    {
                        qry.Append("notes_added_type3 =" + notes_added_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_added_type4Changed)
                    {
                        qry.Append("notes_added_type4 =" + notes_added_type4DbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (processing_datetimeChanged)
                    {
                        qry.Append("processing_datetime =" + processing_datetimeDbString);
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

                    if (last_tsnChanged)
                    {
                        qry.Append("last_tsn =" + last_tsnDbString);
                        qry.Append(",");
                    }

                    if (notes_Added_type5Changed)
                    {
                        qry.Append("notes_Added_type5 =" + notes_Added_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_Added_type6Changed)
                    {
                        qry.Append("notes_Added_type6 =" + notes_Added_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_Added_type7Changed)
                    {
                        qry.Append("notes_Added_type7 =" + notes_Added_type7DbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_parsed_replenishments_id = " + ej_parsed_replenishments_idDbString);
                    qry.Append(" and rep_datetime = " + rep_datetimeDbString);
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
            cmd.CommandText = "DELETE Ej_parsed_replenishments whereej_parsed_replenishments_id= " + ej_parsed_replenishments_id + " and rep_datetime= " + rep_datetime;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjParsedReplenishmentss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_replenishments where " + where, DatabaseName.Tx);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_parsed_replenishments_id = 0,
            atm_id = 1,
            notes_added_type1 = 2,
            notes_added_type2 = 3,
            notes_added_type3 = 4,
            notes_added_type4 = 5,
            rep_datetime = 6,
            task_id = 7,
            processing_datetime = 8,
            start_index = 9,
            end_index = 10,
            last_tsn = 11,
            notes_Added_type5 = 12,
            notes_Added_type6 = 13,
            notes_Added_type7 = 14
        }
        #endregion
        public DataTable BulkSave(List<EjParsedReplenishments> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_parsed_replenishments";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjParsedReplenishments.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjParsedReplenishments> transList, ref DataTable dt)
        {
            foreach (EjParsedReplenishments tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_parsed_replenishments_id"] = ConnectionFactory.GetNextId(DatabaseName.Tx);
                Row["atm_id"] = tran.AtmId;
                Row["notes_added_type1"] = tran.NotesAddedType1;
                Row["notes_added_type2"] = tran.NotesAddedType2;
                Row["notes_added_type3"] = tran.NotesAddedType3;
                Row["notes_added_type4"] = tran.NotesAddedType4;
                Row["rep_datetime"] = tran.RepDatetime;
                Row["task_id"] = tran.TaskId;
                Row["processing_datetime"] = tran.ProcessingDatetime;
                Row["start_index"] = tran.StartIndex;
                Row["end_index"] = tran.EndIndex;
                Row["last_tsn"] = tran.LastTsn;
                Row["notes_Added_type5"] = tran.NotesAddedType5;
                Row["notes_Added_type6"] = tran.NotesAddedType6;
                Row["notes_Added_type7"] = tran.NotesAddedType7;
                dt.Rows.Add(Row);
            }
        }
    }
}
