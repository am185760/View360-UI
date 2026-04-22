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
    public class EjNotesDispensed
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjNotesDispensed() { }
        public EjNotesDispensed(long ej_notes_dispensed_id, DateTime clearing_datetime)
        {
            this.clearing_datetime = clearing_datetime;
            this.clearing_datetimeChanged = true;
        }
        public EjNotesDispensed(int? notes_dispensed_type1, int? notes_dispensed_type2, int? notes_dispensed_type3, int? notes_dispensed_type4, long? atm_id, long? task_id, DateTime? processing_datetime, DateTime clearing_datetime, int? notes_remaining_type1, int? notes_remaining_type2, int? notes_remaining_type3, int? notes_remaining_type4, int? start_index, int? end_index, int? notes_dispensed_type5, int? notes_dispensed_type6, int? notes_dispensed_type7, int? notes_remaining_type5, int? notes_remaining_type6, int? notes_remaining_type7)
        {
            this.notes_dispensed_type1 = notes_dispensed_type1;
            this.notes_dispensed_type1Changed = true;
            this.notes_dispensed_type2 = notes_dispensed_type2;
            this.notes_dispensed_type2Changed = true;
            this.notes_dispensed_type3 = notes_dispensed_type3;
            this.notes_dispensed_type3Changed = true;
            this.notes_dispensed_type4 = notes_dispensed_type4;
            this.notes_dispensed_type4Changed = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.clearing_datetime = clearing_datetime;
            this.clearing_datetimeChanged = true;
            this.notes_remaining_type1 = notes_remaining_type1;
            this.notes_remaining_type1Changed = true;
            this.notes_remaining_type2 = notes_remaining_type2;
            this.notes_remaining_type2Changed = true;
            this.notes_remaining_type3 = notes_remaining_type3;
            this.notes_remaining_type3Changed = true;
            this.notes_remaining_type4 = notes_remaining_type4;
            this.notes_remaining_type4Changed = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.notes_dispensed_type5 = notes_dispensed_type5;
            this.notes_dispensed_type5Changed = true;
            this.notes_dispensed_type6 = notes_dispensed_type6;
            this.notes_dispensed_type6Changed = true;
            this.notes_dispensed_type7 = notes_dispensed_type7;
            this.notes_dispensed_type7Changed = true;
            this.notes_remaining_type5 = notes_remaining_type5;
            this.notes_remaining_type5Changed = true;
            this.notes_remaining_type6 = notes_remaining_type6;
            this.notes_remaining_type6Changed = true;
            this.notes_remaining_type7 = notes_remaining_type7;
            this.notes_remaining_type7Changed = true;
        }
        private EjNotesDispensed(long ej_notes_dispensed_id, int? notes_dispensed_type1, int? notes_dispensed_type2, int? notes_dispensed_type3, int? notes_dispensed_type4, long? atm_id, long? task_id, DateTime? processing_datetime, DateTime clearing_datetime, int? notes_remaining_type1, int? notes_remaining_type2, int? notes_remaining_type3, int? notes_remaining_type4, int? start_index, int? end_index, int? notes_dispensed_type5, int? notes_dispensed_type6, int? notes_dispensed_type7, int? notes_remaining_type5, int? notes_remaining_type6, int? notes_remaining_type7)
        {
            this.ej_notes_dispensed_id = ej_notes_dispensed_id;
            this.ej_notes_dispensed_idChanged = true;
            this.notes_dispensed_type1 = notes_dispensed_type1;
            this.notes_dispensed_type1Changed = true;
            this.notes_dispensed_type2 = notes_dispensed_type2;
            this.notes_dispensed_type2Changed = true;
            this.notes_dispensed_type3 = notes_dispensed_type3;
            this.notes_dispensed_type3Changed = true;
            this.notes_dispensed_type4 = notes_dispensed_type4;
            this.notes_dispensed_type4Changed = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.clearing_datetime = clearing_datetime;
            this.clearing_datetimeChanged = true;
            this.notes_remaining_type1 = notes_remaining_type1;
            this.notes_remaining_type1Changed = true;
            this.notes_remaining_type2 = notes_remaining_type2;
            this.notes_remaining_type2Changed = true;
            this.notes_remaining_type3 = notes_remaining_type3;
            this.notes_remaining_type3Changed = true;
            this.notes_remaining_type4 = notes_remaining_type4;
            this.notes_remaining_type4Changed = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.notes_dispensed_type5 = notes_dispensed_type5;
            this.notes_dispensed_type5Changed = true;
            this.notes_dispensed_type6 = notes_dispensed_type6;
            this.notes_dispensed_type6Changed = true;
            this.notes_dispensed_type7 = notes_dispensed_type7;
            this.notes_dispensed_type7Changed = true;
            this.notes_remaining_type5 = notes_remaining_type5;
            this.notes_remaining_type5Changed = true;
            this.notes_remaining_type6 = notes_remaining_type6;
            this.notes_remaining_type6Changed = true;
            this.notes_remaining_type7 = notes_remaining_type7;
            this.notes_remaining_type7Changed = true;
        }

        #region members and properties for columns

        #region EjNotesDispensedId
        private bool ej_notes_dispensed_idChanged = false;
        private long ej_notes_dispensed_id;
        public long EjNotesDispensedId
        {
            get { return ej_notes_dispensed_id; }
            set
            {
                ej_notes_dispensed_id = value;
                ej_notes_dispensed_idChanged = true;
            }
        }
        private string ej_notes_dispensed_idDbString
        {
            get
            {
                return ej_notes_dispensed_id.ToString();
            }
        }
        #endregion
        #region NotesDispensedType1
        private bool notes_dispensed_type1Changed = false;
        private int? notes_dispensed_type1;
        public int? NotesDispensedType1
        {
            get { return notes_dispensed_type1; }
            set
            {
                notes_dispensed_type1 = value;
                notes_dispensed_type1Changed = true;
            }
        }
        private string notes_dispensed_type1DbString
        {
            get
            {
                if (this.notes_dispensed_type1.HasValue)
                    return notes_dispensed_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType2
        private bool notes_dispensed_type2Changed = false;
        private int? notes_dispensed_type2;
        public int? NotesDispensedType2
        {
            get { return notes_dispensed_type2; }
            set
            {
                notes_dispensed_type2 = value;
                notes_dispensed_type2Changed = true;
            }
        }
        private string notes_dispensed_type2DbString
        {
            get
            {
                if (this.notes_dispensed_type2.HasValue)
                    return notes_dispensed_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType3
        private bool notes_dispensed_type3Changed = false;
        private int? notes_dispensed_type3;
        public int? NotesDispensedType3
        {
            get { return notes_dispensed_type3; }
            set
            {
                notes_dispensed_type3 = value;
                notes_dispensed_type3Changed = true;
            }
        }
        private string notes_dispensed_type3DbString
        {
            get
            {
                if (this.notes_dispensed_type3.HasValue)
                    return notes_dispensed_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType4
        private bool notes_dispensed_type4Changed = false;
        private int? notes_dispensed_type4;
        public int? NotesDispensedType4
        {
            get { return notes_dispensed_type4; }
            set
            {
                notes_dispensed_type4 = value;
                notes_dispensed_type4Changed = true;
            }
        }
        private string notes_dispensed_type4DbString
        {
            get
            {
                if (this.notes_dispensed_type4.HasValue)
                    return notes_dispensed_type4.ToString();
                else
                    return "null";
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
        #region ClearingDatetime
        private bool clearing_datetimeChanged = false;
        private DateTime clearing_datetime;
        public DateTime ClearingDatetime
        {
            get { return clearing_datetime; }
            set
            {
                clearing_datetime = value;
                clearing_datetimeChanged = true;
            }
        }
        private string clearing_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", clearing_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region NotesRemainingType1
        private bool notes_remaining_type1Changed = false;
        private int? notes_remaining_type1;
        public int? NotesRemainingType1
        {
            get { return notes_remaining_type1; }
            set
            {
                notes_remaining_type1 = value;
                notes_remaining_type1Changed = true;
            }
        }
        private string notes_remaining_type1DbString
        {
            get
            {
                if (this.notes_remaining_type1.HasValue)
                    return notes_remaining_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType2
        private bool notes_remaining_type2Changed = false;
        private int? notes_remaining_type2;
        public int? NotesRemainingType2
        {
            get { return notes_remaining_type2; }
            set
            {
                notes_remaining_type2 = value;
                notes_remaining_type2Changed = true;
            }
        }
        private string notes_remaining_type2DbString
        {
            get
            {
                if (this.notes_remaining_type2.HasValue)
                    return notes_remaining_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType3
        private bool notes_remaining_type3Changed = false;
        private int? notes_remaining_type3;
        public int? NotesRemainingType3
        {
            get { return notes_remaining_type3; }
            set
            {
                notes_remaining_type3 = value;
                notes_remaining_type3Changed = true;
            }
        }
        private string notes_remaining_type3DbString
        {
            get
            {
                if (this.notes_remaining_type3.HasValue)
                    return notes_remaining_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType4
        private bool notes_remaining_type4Changed = false;
        private int? notes_remaining_type4;
        public int? NotesRemainingType4
        {
            get { return notes_remaining_type4; }
            set
            {
                notes_remaining_type4 = value;
                notes_remaining_type4Changed = true;
            }
        }
        private string notes_remaining_type4DbString
        {
            get
            {
                if (this.notes_remaining_type4.HasValue)
                    return notes_remaining_type4.ToString();
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
        #region NotesDispensedType5
        private bool notes_dispensed_type5Changed = false;
        private int? notes_dispensed_type5;
        public int? NotesDispensedType5
        {
            get { return notes_dispensed_type5; }
            set
            {
                notes_dispensed_type5 = value;
                notes_dispensed_type5Changed = true;
            }
        }
        private string notes_dispensed_type5DbString
        {
            get
            {
                if (this.notes_dispensed_type5.HasValue)
                    return notes_dispensed_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType6
        private bool notes_dispensed_type6Changed = false;
        private int? notes_dispensed_type6;
        public int? NotesDispensedType6
        {
            get { return notes_dispensed_type6; }
            set
            {
                notes_dispensed_type6 = value;
                notes_dispensed_type6Changed = true;
            }
        }
        private string notes_dispensed_type6DbString
        {
            get
            {
                if (this.notes_dispensed_type6.HasValue)
                    return notes_dispensed_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType7
        private bool notes_dispensed_type7Changed = false;
        private int? notes_dispensed_type7;
        public int? NotesDispensedType7
        {
            get { return notes_dispensed_type7; }
            set
            {
                notes_dispensed_type7 = value;
                notes_dispensed_type7Changed = true;
            }
        }
        private string notes_dispensed_type7DbString
        {
            get
            {
                if (this.notes_dispensed_type7.HasValue)
                    return notes_dispensed_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType5
        private bool notes_remaining_type5Changed = false;
        private int? notes_remaining_type5;
        public int? NotesRemainingType5
        {
            get { return notes_remaining_type5; }
            set
            {
                notes_remaining_type5 = value;
                notes_remaining_type5Changed = true;
            }
        }
        private string notes_remaining_type5DbString
        {
            get
            {
                if (this.notes_remaining_type5.HasValue)
                    return notes_remaining_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType6
        private bool notes_remaining_type6Changed = false;
        private int? notes_remaining_type6;
        public int? NotesRemainingType6
        {
            get { return notes_remaining_type6; }
            set
            {
                notes_remaining_type6 = value;
                notes_remaining_type6Changed = true;
            }
        }
        private string notes_remaining_type6DbString
        {
            get
            {
                if (this.notes_remaining_type6.HasValue)
                    return notes_remaining_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType7
        private bool notes_remaining_type7Changed = false;
        private int? notes_remaining_type7;
        public int? NotesRemainingType7
        {
            get { return notes_remaining_type7; }
            set
            {
                notes_remaining_type7 = value;
                notes_remaining_type7Changed = true;
            }
        }
        private string notes_remaining_type7DbString
        {
            get
            {
                if (this.notes_remaining_type7.HasValue)
                    return notes_remaining_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region EjNotesDispensedReader
        public class EjNotesDispensedReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjNotesDispensed currentEjNotesDispensed;
            Columns columns;
            bool partialRead = false;
            private EjNotesDispensedReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjNotesDispensedReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjNotesDispensedReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjNotesDispensed; }

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
                    currentEjNotesDispensed = new EjNotesDispensed();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_notes_dispensed_id) == Columns.ej_notes_dispensed_id && reader["ej_notes_dispensed_id"] != DBNull.Value)
                            currentEjNotesDispensed.ej_notes_dispensed_id = (long)reader["ej_notes_dispensed_id"];
                        if ((columns & Columns.notes_dispensed_type1) == Columns.notes_dispensed_type1 && reader["notes_dispensed_type1"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type1 = (int?)reader["notes_dispensed_type1"];
                        if ((columns & Columns.notes_dispensed_type2) == Columns.notes_dispensed_type2 && reader["notes_dispensed_type2"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type2 = (int?)reader["notes_dispensed_type2"];
                        if ((columns & Columns.notes_dispensed_type3) == Columns.notes_dispensed_type3 && reader["notes_dispensed_type3"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type3 = (int?)reader["notes_dispensed_type3"];
                        if ((columns & Columns.notes_dispensed_type4) == Columns.notes_dispensed_type4 && reader["notes_dispensed_type4"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type4 = (int?)reader["notes_dispensed_type4"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentEjNotesDispensed.atm_id = (long?)reader["atm_id"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentEjNotesDispensed.task_id = (long?)reader["task_id"];
                        if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"] != DBNull.Value)
                            currentEjNotesDispensed.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if ((columns & Columns.clearing_datetime) == Columns.clearing_datetime && reader["clearing_datetime"] != DBNull.Value)
                            currentEjNotesDispensed.clearing_datetime = (DateTime)reader["clearing_datetime"];
                        if ((columns & Columns.notes_remaining_type1) == Columns.notes_remaining_type1 && reader["notes_remaining_type1"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type1 = (int?)reader["notes_remaining_type1"];
                        if ((columns & Columns.notes_remaining_type2) == Columns.notes_remaining_type2 && reader["notes_remaining_type2"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type2 = (int?)reader["notes_remaining_type2"];
                        if ((columns & Columns.notes_remaining_type3) == Columns.notes_remaining_type3 && reader["notes_remaining_type3"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type3 = (int?)reader["notes_remaining_type3"];
                        if ((columns & Columns.notes_remaining_type4) == Columns.notes_remaining_type4 && reader["notes_remaining_type4"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type4 = (int?)reader["notes_remaining_type4"];
                        if ((columns & Columns.start_index) == Columns.start_index && reader["start_index"] != DBNull.Value)
                            currentEjNotesDispensed.start_index = (int?)reader["start_index"];
                        if ((columns & Columns.end_index) == Columns.end_index && reader["end_index"] != DBNull.Value)
                            currentEjNotesDispensed.end_index = (int?)reader["end_index"];
                        if ((columns & Columns.notes_dispensed_type5) == Columns.notes_dispensed_type5 && reader["notes_dispensed_type5"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type5 = (int?)reader["notes_dispensed_type5"];
                        if ((columns & Columns.notes_dispensed_type6) == Columns.notes_dispensed_type6 && reader["notes_dispensed_type6"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type6 = (int?)reader["notes_dispensed_type6"];
                        if ((columns & Columns.notes_dispensed_type7) == Columns.notes_dispensed_type7 && reader["notes_dispensed_type7"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type7 = (int?)reader["notes_dispensed_type7"];
                        if ((columns & Columns.notes_remaining_type5) == Columns.notes_remaining_type5 && reader["notes_remaining_type5"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type5 = (int?)reader["notes_remaining_type5"];
                        if ((columns & Columns.notes_remaining_type6) == Columns.notes_remaining_type6 && reader["notes_remaining_type6"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type6 = (int?)reader["notes_remaining_type6"];
                        if ((columns & Columns.notes_remaining_type7) == Columns.notes_remaining_type7 && reader["notes_remaining_type7"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type7 = (int?)reader["notes_remaining_type7"];

                    }
                    else
                    {
                        if (reader["ej_notes_dispensed_id"] != DBNull.Value)
                            currentEjNotesDispensed.ej_notes_dispensed_id = (long)reader["ej_notes_dispensed_id"];
                        if (reader["notes_dispensed_type1"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type1 = (int?)reader["notes_dispensed_type1"];
                        if (reader["notes_dispensed_type2"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type2 = (int?)reader["notes_dispensed_type2"];
                        if (reader["notes_dispensed_type3"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type3 = (int?)reader["notes_dispensed_type3"];
                        if (reader["notes_dispensed_type4"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type4 = (int?)reader["notes_dispensed_type4"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentEjNotesDispensed.atm_id = (long?)reader["atm_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentEjNotesDispensed.task_id = (long?)reader["task_id"];
                        if (reader["processing_datetime"] != DBNull.Value)
                            currentEjNotesDispensed.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if (reader["clearing_datetime"] != DBNull.Value)
                            currentEjNotesDispensed.clearing_datetime = (DateTime)reader["clearing_datetime"];
                        if (reader["notes_remaining_type1"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type1 = (int?)reader["notes_remaining_type1"];
                        if (reader["notes_remaining_type2"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type2 = (int?)reader["notes_remaining_type2"];
                        if (reader["notes_remaining_type3"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type3 = (int?)reader["notes_remaining_type3"];
                        if (reader["notes_remaining_type4"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type4 = (int?)reader["notes_remaining_type4"];
                        if (reader["start_index"] != DBNull.Value)
                            currentEjNotesDispensed.start_index = (int?)reader["start_index"];
                        if (reader["end_index"] != DBNull.Value)
                            currentEjNotesDispensed.end_index = (int?)reader["end_index"];
                        if (reader["notes_dispensed_type5"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type5 = (int?)reader["notes_dispensed_type5"];
                        if (reader["notes_dispensed_type6"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type6 = (int?)reader["notes_dispensed_type6"];
                        if (reader["notes_dispensed_type7"] != DBNull.Value)
                            currentEjNotesDispensed.notes_dispensed_type7 = (int?)reader["notes_dispensed_type7"];
                        if (reader["notes_remaining_type5"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type5 = (int?)reader["notes_remaining_type5"];
                        if (reader["notes_remaining_type6"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type6 = (int?)reader["notes_remaining_type6"];
                        if (reader["notes_remaining_type7"] != DBNull.Value)
                            currentEjNotesDispensed.notes_remaining_type7 = (int?)reader["notes_remaining_type7"];
                    }

                    currentEjNotesDispensed.isNewEntity = false;
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

            public EjNotesDispensed CurrentEjNotesDispensed
            {
                get { return currentEjNotesDispensed; }
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


        #region EjNotesDispensed functions

        public static EjNotesDispensedReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_notes_dispensed_id == (Columns.ej_notes_dispensed_id & columns))
                qry.Append("ej_notes_dispensed_id,");
            if (Columns.notes_dispensed_type1 == (Columns.notes_dispensed_type1 & columns))
                qry.Append("notes_dispensed_type1,");
            if (Columns.notes_dispensed_type2 == (Columns.notes_dispensed_type2 & columns))
                qry.Append("notes_dispensed_type2,");
            if (Columns.notes_dispensed_type3 == (Columns.notes_dispensed_type3 & columns))
                qry.Append("notes_dispensed_type3,");
            if (Columns.notes_dispensed_type4 == (Columns.notes_dispensed_type4 & columns))
                qry.Append("notes_dispensed_type4,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.processing_datetime == (Columns.processing_datetime & columns))
                qry.Append("processing_datetime,");
            if (Columns.clearing_datetime == (Columns.clearing_datetime & columns))
                qry.Append("clearing_datetime,");
            if (Columns.notes_remaining_type1 == (Columns.notes_remaining_type1 & columns))
                qry.Append("notes_remaining_type1,");
            if (Columns.notes_remaining_type2 == (Columns.notes_remaining_type2 & columns))
                qry.Append("notes_remaining_type2,");
            if (Columns.notes_remaining_type3 == (Columns.notes_remaining_type3 & columns))
                qry.Append("notes_remaining_type3,");
            if (Columns.notes_remaining_type4 == (Columns.notes_remaining_type4 & columns))
                qry.Append("notes_remaining_type4,");
            if (Columns.start_index == (Columns.start_index & columns))
                qry.Append("start_index,");
            if (Columns.end_index == (Columns.end_index & columns))
                qry.Append("end_index,");
            if (Columns.notes_dispensed_type5 == (Columns.notes_dispensed_type5 & columns))
                qry.Append("notes_dispensed_type5,");
            if (Columns.notes_dispensed_type6 == (Columns.notes_dispensed_type6 & columns))
                qry.Append("notes_dispensed_type6,");
            if (Columns.notes_dispensed_type7 == (Columns.notes_dispensed_type7 & columns))
                qry.Append("notes_dispensed_type7,");
            if (Columns.notes_remaining_type5 == (Columns.notes_remaining_type5 & columns))
                qry.Append("notes_remaining_type5,");
            if (Columns.notes_remaining_type6 == (Columns.notes_remaining_type6 & columns))
                qry.Append("notes_remaining_type6,");
            if (Columns.notes_remaining_type7 == (Columns.notes_remaining_type7 & columns))
                qry.Append("notes_remaining_type7,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_notes_dispensed ");

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
            return new EjNotesDispensedReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjNotesDispensedReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjNotesDispensedReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectej_notes_dispensed_id,notes_dispensed_type1,notes_dispensed_type2,notes_dispensed_type3,notes_dispensed_type4,atm_id,task_id,processing_datetime,clearing_datetime,notes_remaining_type1,notes_remaining_type2,notes_remaining_type3,notes_remaining_type4,start_index,end_index,notes_dispensed_type5,notes_dispensed_type6,notes_dispensed_type7,notes_remaining_type5,notes_remaining_type6,notes_remaining_type7from Ej_notes_dispensed ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjNotesDispensedReader(cmd.ExecuteReader(), conn);
        }

        static public EjNotesDispensedReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public static EjNotesDispensed LoadEjNotesDispensed(string where)
        {
            EjNotesDispensedReader reader = EjNotesDispensed.ExecuteReader(where);
            EjNotesDispensed _ejnotesdispensed = null;
            if (reader.Read())
                _ejnotesdispensed = reader.CurrentEjNotesDispensed;
            reader.Close();
            return _ejnotesdispensed;
        }

        public static EjNotesDispensed LoadEjNotesDispensed(string where, IDbConnection conn)
        {
            EjNotesDispensedReader reader = EjNotesDispensed.ExecuteReader(where, conn);
            EjNotesDispensed _ejnotesdispensed = null;
            if (reader.Read())
                _ejnotesdispensed = reader.CurrentEjNotesDispensed;
            reader.Close(false);
            return _ejnotesdispensed;
        }

        public static EjNotesDispensed LoadEjNotesDispensedByPk(long ej_notes_dispensed_id, DateTime clearing_datetime)
        {
            return LoadEjNotesDispensed("ej_notes_dispensed_id=" + ej_notes_dispensed_id + " and clearing_datetime=Convert(datetime,'" + clearing_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)");
        }

        public static EjNotesDispensed LoadEjNotesDispensedByPk(long ej_notes_dispensed_id, DateTime clearing_datetime, IDbConnection conn)
        {
            return LoadEjNotesDispensed(" ej_notes_dispensed_id=" + ej_notes_dispensed_id + " and clearing_datetime=Convert(datetime,'" + clearing_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)", conn);
        }

        public void Save()
        {
            if (ej_notes_dispensed_idChanged || notes_dispensed_type1Changed || notes_dispensed_type2Changed || notes_dispensed_type3Changed || notes_dispensed_type4Changed || atm_idChanged || task_idChanged || processing_datetimeChanged || clearing_datetimeChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || start_indexChanged || end_indexChanged || notes_dispensed_type5Changed || notes_dispensed_type6Changed || notes_dispensed_type7Changed || notes_remaining_type5Changed || notes_remaining_type6Changed || notes_remaining_type7Changed)
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
            if (ej_notes_dispensed_idChanged || notes_dispensed_type1Changed || notes_dispensed_type2Changed || notes_dispensed_type3Changed || notes_dispensed_type4Changed || atm_idChanged || task_idChanged || processing_datetimeChanged || clearing_datetimeChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || start_indexChanged || end_indexChanged || notes_dispensed_type5Changed || notes_dispensed_type6Changed || notes_dispensed_type7Changed || notes_remaining_type5Changed || notes_remaining_type6Changed || notes_remaining_type7Changed)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_notes_dispensed(ej_notes_dispensed_id,notes_dispensed_type1,notes_dispensed_type2,notes_dispensed_type3,notes_dispensed_type4,atm_id,task_id,processing_datetime,clearing_datetime,notes_remaining_type1,notes_remaining_type2,notes_remaining_type3,notes_remaining_type4,start_index,end_index,notes_dispensed_type5,notes_dispensed_type6,notes_dispensed_type7,notes_remaining_type5,notes_remaining_type6,notes_remaining_type7) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.ej_notes_dispensed_id = ConnectionFactory.GetNextId(DatabaseName.Tx);
                        qry.Append(this.ej_notes_dispensed_id);
                    }
                    qry.Append(",");
                    qry.Append(notes_dispensed_type1DbString + ",");
                    qry.Append(notes_dispensed_type2DbString + ",");
                    qry.Append(notes_dispensed_type3DbString + ",");
                    qry.Append(notes_dispensed_type4DbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(processing_datetimeDbString + ",");
                    qry.Append(clearing_datetimeDbString + ",");
                    qry.Append(notes_remaining_type1DbString + ",");
                    qry.Append(notes_remaining_type2DbString + ",");
                    qry.Append(notes_remaining_type3DbString + ",");
                    qry.Append(notes_remaining_type4DbString + ",");
                    qry.Append(start_indexDbString + ",");
                    qry.Append(end_indexDbString + ",");
                    qry.Append(notes_dispensed_type5DbString + ",");
                    qry.Append(notes_dispensed_type6DbString + ",");
                    qry.Append(notes_dispensed_type7DbString + ",");
                    qry.Append(notes_remaining_type5DbString + ",");
                    qry.Append(notes_remaining_type6DbString + ",");
                    qry.Append(notes_remaining_type7DbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_notes_dispensed_idChanged || notes_dispensed_type1Changed || notes_dispensed_type2Changed || notes_dispensed_type3Changed || notes_dispensed_type4Changed || atm_idChanged || task_idChanged || processing_datetimeChanged || clearing_datetimeChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || start_indexChanged || end_indexChanged || notes_dispensed_type5Changed || notes_dispensed_type6Changed || notes_dispensed_type7Changed || notes_remaining_type5Changed || notes_remaining_type6Changed || notes_remaining_type7Changed))
                        return;
                    qry.Append("UPDATE Ej_notes_dispensed set "); if (notes_dispensed_type1Changed)
                    {
                        qry.Append("notes_dispensed_type1 =" + notes_dispensed_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type2Changed)
                    {
                        qry.Append("notes_dispensed_type2 =" + notes_dispensed_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type3Changed)
                    {
                        qry.Append("notes_dispensed_type3 =" + notes_dispensed_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type4Changed)
                    {
                        qry.Append("notes_dispensed_type4 =" + notes_dispensed_type4DbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
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

                    if (notes_remaining_type1Changed)
                    {
                        qry.Append("notes_remaining_type1 =" + notes_remaining_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type2Changed)
                    {
                        qry.Append("notes_remaining_type2 =" + notes_remaining_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type3Changed)
                    {
                        qry.Append("notes_remaining_type3 =" + notes_remaining_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type4Changed)
                    {
                        qry.Append("notes_remaining_type4 =" + notes_remaining_type4DbString);
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

                    if (notes_dispensed_type5Changed)
                    {
                        qry.Append("notes_dispensed_type5 =" + notes_dispensed_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type6Changed)
                    {
                        qry.Append("notes_dispensed_type6 =" + notes_dispensed_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type7Changed)
                    {
                        qry.Append("notes_dispensed_type7 =" + notes_dispensed_type7DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type5Changed)
                    {
                        qry.Append("notes_remaining_type5 =" + notes_remaining_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type6Changed)
                    {
                        qry.Append("notes_remaining_type6 =" + notes_remaining_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type7Changed)
                    {
                        qry.Append("notes_remaining_type7 =" + notes_remaining_type7DbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_notes_dispensed_id = " + ej_notes_dispensed_idDbString);
                    qry.Append(" and clearing_datetime = " + clearing_datetimeDbString);
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
            cmd.CommandText = "DELETE Ej_notes_dispensed whereej_notes_dispensed_id= " + ej_notes_dispensed_id + " and clearing_datetime= " + clearing_datetime;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjNotesDispenseds(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_notes_dispensed where " + where, DatabaseName.Tx);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_notes_dispensed_id = 0,
            notes_dispensed_type1 = 1,
            notes_dispensed_type2 = 2,
            notes_dispensed_type3 = 3,
            notes_dispensed_type4 = 4,
            atm_id = 5,
            task_id = 6,
            processing_datetime = 7,
            clearing_datetime = 8,
            notes_remaining_type1 = 9,
            notes_remaining_type2 = 10,
            notes_remaining_type3 = 11,
            notes_remaining_type4 = 12,
            start_index = 13,
            end_index = 14,
            notes_dispensed_type5 = 15,
            notes_dispensed_type6 = 16,
            notes_dispensed_type7 = 17,
            notes_remaining_type5 = 18,
            notes_remaining_type6 = 19,
            notes_remaining_type7 = 20
        }
        #endregion
        public DataTable BulkSave(List<EjNotesDispensed> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_notes_dispensed";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjNotesDispensed.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjNotesDispensed> transList, ref DataTable dt)
        {
            foreach (EjNotesDispensed tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_notes_dispensed_id"] = ConnectionFactory.GetNextId(DatabaseName.Tx);
                Row["notes_dispensed_type1"] = tran.NotesDispensedType1;
                Row["notes_dispensed_type2"] = tran.NotesDispensedType2;
                Row["notes_dispensed_type3"] = tran.NotesDispensedType3;
                Row["notes_dispensed_type4"] = tran.NotesDispensedType4;
                Row["atm_id"] = tran.AtmId;
                Row["task_id"] = tran.TaskId;
                Row["processing_datetime"] = tran.ProcessingDatetime;
                Row["clearing_datetime"] = tran.ClearingDatetime;
                Row["notes_remaining_type1"] = tran.NotesRemainingType1;
                Row["notes_remaining_type2"] = tran.NotesRemainingType2;
                Row["notes_remaining_type3"] = tran.NotesRemainingType3;
                Row["notes_remaining_type4"] = tran.NotesRemainingType4;
                Row["start_index"] = tran.StartIndex;
                Row["end_index"] = tran.EndIndex;
                Row["notes_dispensed_type5"] = tran.NotesDispensedType5;
                Row["notes_dispensed_type6"] = tran.NotesDispensedType6;
                Row["notes_dispensed_type7"] = tran.NotesDispensedType7;
                Row["notes_remaining_type5"] = tran.NotesRemainingType5;
                Row["notes_remaining_type6"] = tran.NotesRemainingType6;
                Row["notes_remaining_type7"] = tran.NotesRemainingType7;
                dt.Rows.Add(Row);
            }
        }
    }
}
