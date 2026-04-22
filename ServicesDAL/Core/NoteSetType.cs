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
    [Serializable]
    public class NoteSetType
    {
        public class NoteSetTypeReader : IEntityReader, IEnumerator, IEnumerable
        {
            private IDataReader reader;

            private IDbConnection conn;

            private NoteSetType currentNoteSetType;

            private Columns columns;

            private bool partialRead = false;

            public bool IsClosed => reader.IsClosed;

            public int Depth => reader.Depth;

            public int FieldCount => reader.FieldCount;

            public object Current => currentNoteSetType;

            public NoteSetType CurrentNoteSetType => currentNoteSetType;

            private NoteSetTypeReader()
            {
            }

            public NoteSetTypeReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }

            public NoteSetTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
            {
                this.reader = reader;
                this.conn = conn;
                this.columns = columns;
                partialRead = true;
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
                {
                    conn.Close();
                }
            }

            public bool Read()
            {
                if (reader.Read())
                {
                    currentNoteSetType = new NoteSetType();
                    if (partialRead)
                    {
                        if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"] != DBNull.Value)
                        {
                            currentNoteSetType.region_id = int.Parse(reader["region_id"].ToString());
                        }

                        if ((columns & Columns.note_set_type_name) == Columns.note_set_type_name && reader["note_set_type_name"] != DBNull.Value)
                        {
                            currentNoteSetType.note_set_type_name = (string)reader["note_set_type_name"];
                        }

                        if ((columns & Columns.denomination_type_1) == Columns.denomination_type_1 && reader["denomination_type_1"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_1 = int.Parse(reader["denomination_type_1"].ToString());
                        }

                        if ((columns & Columns.denomination_type_2) == Columns.denomination_type_2 && reader["denomination_type_2"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_2 = int.Parse(reader["denomination_type_2"].ToString());
                        }

                        if ((columns & Columns.denomination_type_3) == Columns.denomination_type_3 && reader["denomination_type_3"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_3 = int.Parse(reader["denomination_type_3"].ToString());
                        }

                        if ((columns & Columns.denomination_type_4) == Columns.denomination_type_4 && reader["denomination_type_4"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_4 = int.Parse(reader["denomination_type_4"].ToString());
                        }

                        if ((columns & Columns.denomination_type_5) == Columns.denomination_type_5 && reader["denomination_type_5"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_5 = int.Parse(reader["denomination_type_5"].ToString());
                        }

                        if ((columns & Columns.denomination_type_6) == Columns.denomination_type_6 && reader["denomination_type_6"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_6 = int.Parse(reader["denomination_type_6"].ToString());
                        }

                        if ((columns & Columns.denomination_type_7) == Columns.denomination_type_7 && reader["denomination_type_7"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_7 = int.Parse(reader["denomination_type_7"].ToString());
                        }

                        if ((columns & Columns.note_set_type_id) == Columns.note_set_type_id && reader["note_set_type_id"] != DBNull.Value)
                        {
                            currentNoteSetType.note_set_type_id = int.Parse(reader["note_set_type_id"].ToString());
                        }

                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                        {
                            currentNoteSetType.created_by = int.Parse(reader["created_by"].ToString());
                        }

                        if ((columns & Columns.denomination_type_1_title) == Columns.denomination_type_1_title && reader["denomination_type_1_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_1_title = (string)reader["denomination_type_1_title"];
                        }

                        if ((columns & Columns.denomination_type_2_title) == Columns.denomination_type_2_title && reader["denomination_type_2_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_2_title = (string)reader["denomination_type_2_title"];
                        }

                        if ((columns & Columns.denomination_type_3_title) == Columns.denomination_type_3_title && reader["denomination_type_3_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_3_title = (string)reader["denomination_type_3_title"];
                        }

                        if ((columns & Columns.denomination_type_4_title) == Columns.denomination_type_4_title && reader["denomination_type_4_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_4_title = (string)reader["denomination_type_4_title"];
                        }

                        if ((columns & Columns.denomination_type_5_title) == Columns.denomination_type_5_title && reader["denomination_type_5_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_5_title = (string)reader["denomination_type_5_title"];
                        }

                        if ((columns & Columns.denomination_type_6_title) == Columns.denomination_type_6_title && reader["denomination_type_6_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_6_title = (string)reader["denomination_type_6_title"];
                        }

                        if ((columns & Columns.denomination_type_7_title) == Columns.denomination_type_7_title && reader["denomination_type_7_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_7_title = (string)reader["denomination_type_7_title"];
                        }

                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                        {
                            currentNoteSetType.creation_time = (DateTime)reader["creation_time"];
                        }

                        if ((columns & Columns.is_type1_multi_currency) == Columns.is_type1_multi_currency && reader["is_type1_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type1_multi_currency = (bool?)reader["is_type1_multi_currency"];
                        }

                        if ((columns & Columns.is_type2_multi_currency) == Columns.is_type2_multi_currency && reader["is_type2_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type2_multi_currency = (bool?)reader["is_type2_multi_currency"];
                        }

                        if ((columns & Columns.is_type3_multi_currency) == Columns.is_type3_multi_currency && reader["is_type3_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type3_multi_currency = (bool?)reader["is_type3_multi_currency"];
                        }

                        if ((columns & Columns.is_type4_multi_currency) == Columns.is_type4_multi_currency && reader["is_type4_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type4_multi_currency = (bool?)reader["is_type4_multi_currency"];
                        }

                        if ((columns & Columns.is_type5_multi_currency) == Columns.is_type5_multi_currency && reader["is_type5_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type5_multi_currency = (bool?)reader["is_type5_multi_currency"];
                        }

                        if ((columns & Columns.is_type6_multi_currency) == Columns.is_type6_multi_currency && reader["is_type6_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type6_multi_currency = (bool?)reader["is_type6_multi_currency"];
                        }

                        if ((columns & Columns.is_type7_multi_currency) == Columns.is_type7_multi_currency && reader["is_type7_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type7_multi_currency = (bool?)reader["is_type7_multi_currency"];
                        }

                        if ((columns & Columns.is_type1_recycler) == Columns.is_type1_recycler && reader["is_type1_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type1_recycler = (bool)reader["is_type1_recycler"];
                        }

                        if ((columns & Columns.is_type2_recycler) == Columns.is_type2_recycler && reader["is_type2_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type2_recycler = (bool)reader["is_type2_recycler"];
                        }

                        if ((columns & Columns.is_type3_recycler) == Columns.is_type3_recycler && reader["is_type3_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type3_recycler = (bool)reader["is_type3_recycler"];
                        }

                        if ((columns & Columns.is_type4_recycler) == Columns.is_type4_recycler && reader["is_type4_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type4_recycler = (bool)reader["is_type4_recycler"];
                        }

                        if ((columns & Columns.is_type5_recycler) == Columns.is_type5_recycler && reader["is_type5_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type5_recycler = (bool)reader["is_type5_recycler"];
                        }

                        if ((columns & Columns.is_type6_recycler) == Columns.is_type6_recycler && reader["is_type6_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type6_recycler = (bool)reader["is_type6_recycler"];
                        }

                        if ((columns & Columns.is_type7_recycler) == Columns.is_type7_recycler && reader["is_type7_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type7_recycler = (bool)reader["is_type7_recycler"];
                        }
                    }
                    else
                    {
                        if (reader["region_id"] != DBNull.Value)
                        {
                            currentNoteSetType.region_id = int.Parse(reader["region_id"].ToString());
                        }

                        if (reader["note_set_type_name"] != DBNull.Value)
                        {
                            currentNoteSetType.note_set_type_name = (string)reader["note_set_type_name"];
                        }

                        if (reader["denomination_type_1"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_1 = int.Parse(reader["denomination_type_1"].ToString());
                        }

                        if (reader["denomination_type_2"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_2 = int.Parse(reader["denomination_type_2"].ToString());
                        }

                        if (reader["denomination_type_3"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_3 = int.Parse(reader["denomination_type_3"].ToString());
                        }

                        if (reader["denomination_type_4"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_4 = int.Parse(reader["denomination_type_4"].ToString());
                        }

                        if (reader["denomination_type_5"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_5 = int.Parse(reader["denomination_type_5"].ToString());
                        }

                        if (reader["denomination_type_6"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_6 = int.Parse(reader["denomination_type_6"].ToString());
                        }

                        if (reader["denomination_type_7"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_7 = int.Parse(reader["denomination_type_7"].ToString());
                        }

                        if (reader["note_set_type_id"] != DBNull.Value)
                        {
                            currentNoteSetType.note_set_type_id = int.Parse(reader["note_set_type_id"].ToString());
                        }

                        if (reader["created_by"] != DBNull.Value)
                        {
                            currentNoteSetType.created_by = int.Parse(reader["created_by"].ToString());
                        }

                        if (reader["denomination_type_1_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_1_title = (string)reader["denomination_type_1_title"];
                        }

                        if (reader["denomination_type_2_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_2_title = (string)reader["denomination_type_2_title"];
                        }

                        if (reader["denomination_type_3_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_3_title = (string)reader["denomination_type_3_title"];
                        }

                        if (reader["denomination_type_4_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_4_title = (string)reader["denomination_type_4_title"];
                        }

                        if (reader["denomination_type_5_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_5_title = (string)reader["denomination_type_5_title"];
                        }

                        if (reader["denomination_type_6_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_6_title = (string)reader["denomination_type_6_title"];
                        }

                        if (reader["denomination_type_7_title"] != DBNull.Value)
                        {
                            currentNoteSetType.denomination_type_7_title = (string)reader["denomination_type_7_title"];
                        }

                        if (reader["creation_time"] != DBNull.Value)
                        {
                            currentNoteSetType.creation_time = (DateTime)reader["creation_time"];
                        }

                        if (reader["is_type1_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type1_multi_currency = (bool?)reader["is_type1_multi_currency"];
                        }

                        if (reader["is_type2_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type2_multi_currency = (bool?)reader["is_type2_multi_currency"];
                        }

                        if (reader["is_type3_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type3_multi_currency = (bool?)reader["is_type3_multi_currency"];
                        }

                        if (reader["is_type4_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type4_multi_currency = (bool?)reader["is_type4_multi_currency"];
                        }

                        if (reader["is_type5_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type5_multi_currency = (bool?)reader["is_type5_multi_currency"];
                        }

                        if (reader["is_type6_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type6_multi_currency = (bool?)reader["is_type6_multi_currency"];
                        }

                        if (reader["is_type7_multi_currency"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type7_multi_currency = (bool?)reader["is_type7_multi_currency"];
                        }

                        if (reader["is_type1_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type1_recycler = (bool)reader["is_type1_recycler"];
                        }

                        if (reader["is_type2_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type2_recycler = (bool)reader["is_type2_recycler"];
                        }

                        if (reader["is_type3_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type3_recycler = (bool)reader["is_type3_recycler"];
                        }

                        if (reader["is_type4_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type4_recycler = (bool)reader["is_type4_recycler"];
                        }

                        if (reader["is_type5_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type5_recycler = (bool)reader["is_type5_recycler"];
                        }

                        if (reader["is_type6_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type6_recycler = (bool)reader["is_type6_recycler"];
                        }

                        if (reader["is_type7_recycler"] != DBNull.Value)
                        {
                            currentNoteSetType.is_type7_recycler = (bool)reader["is_type7_recycler"];
                        }
                    }

                    currentNoteSetType.isNewEntity = false;
                    return true;
                }

                return false;
            }

            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                return Read();
            }

            public void Reset()
            {
                throw new Exception("The method is not implemented.");
            }
        }

        public enum Columns : ulong
        {
            region_id = 1uL,
            note_set_type_name = 2uL,
            denomination_type_1 = 4uL,
            denomination_type_2 = 8uL,
            denomination_type_3 = 0x10uL,
            denomination_type_4 = 0x20uL,
            denomination_type_5 = 0x40uL,
            denomination_type_6 = 0x80uL,
            denomination_type_7 = 0x100uL,
            note_set_type_id = 0x200uL,
            created_by = 0x400uL,
            denomination_type_1_title = 0x800uL,
            denomination_type_2_title = 0x1000uL,
            denomination_type_3_title = 0x2000uL,
            denomination_type_4_title = 0x4000uL,
            denomination_type_5_title = 0x8000uL,
            denomination_type_6_title = 0x10000uL,
            denomination_type_7_title = 0x20000uL,
            creation_time = 0x40000uL,
            is_type1_multi_currency = 0x80000uL,
            is_type2_multi_currency = 0x100000uL,
            is_type3_multi_currency = 0x200000uL,
            is_type4_multi_currency = 0x400000uL,
            is_type5_multi_currency = 0x800000uL,
            is_type6_multi_currency = 0x1000000uL,
            is_type7_multi_currency = 0x2000000uL,
            is_type1_recycler = 0x4000000uL,
            is_type2_recycler = 0x8000000uL,
            is_type3_recycler = 0x10000000uL,
            is_type4_recycler = 0x20000000uL,
            is_type5_recycler = 0x40000000uL,
            is_type6_recycler = 0x80000000uL,
            is_type7_recycler = 0x100000000uL
        }

        private bool isNewEntity = true;

        private bool region_idChanged = false;

        private int region_id;

        private bool note_set_type_nameChanged = false;

        private string note_set_type_name;

        private bool denomination_type_1Changed = false;

        private int? denomination_type_1;

        private bool denomination_type_2Changed = false;

        private int? denomination_type_2;

        private bool denomination_type_3Changed = false;

        private int? denomination_type_3;

        private bool denomination_type_4Changed = false;

        private int? denomination_type_4;

        private bool denomination_type_5Changed = false;

        private int? denomination_type_5;

        private bool denomination_type_6Changed = false;

        private int? denomination_type_6;

        private bool denomination_type_7Changed = false;

        private int? denomination_type_7;

        private bool note_set_type_idChanged = false;

        private int note_set_type_id;

        private bool created_byChanged = false;

        private int created_by;

        private bool denomination_type_1_titleChanged = false;

        private string denomination_type_1_title;

        private bool denomination_type_2_titleChanged = false;

        private string denomination_type_2_title;

        private bool denomination_type_3_titleChanged = false;

        private string denomination_type_3_title;

        private bool denomination_type_4_titleChanged = false;

        private string denomination_type_4_title;

        private bool denomination_type_5_titleChanged = false;

        private string denomination_type_5_title;

        private bool denomination_type_6_titleChanged = false;

        private string denomination_type_6_title;

        private bool denomination_type_7_titleChanged = false;

        private string denomination_type_7_title;

        private bool creation_timeChanged = false;

        private DateTime creation_time;

        private bool is_type1_multi_currencyChanged = false;

        private bool? is_type1_multi_currency;

        private bool is_type2_multi_currencyChanged = false;

        private bool? is_type2_multi_currency;

        private bool is_type3_multi_currencyChanged = false;

        private bool? is_type3_multi_currency;

        private bool is_type4_multi_currencyChanged = false;

        private bool? is_type4_multi_currency;

        private bool is_type5_multi_currencyChanged = false;

        private bool? is_type5_multi_currency;

        private bool is_type6_multi_currencyChanged = false;

        private bool? is_type6_multi_currency;

        private bool is_type7_multi_currencyChanged = false;

        private bool? is_type7_multi_currency;

        private bool is_type1_recyclerChanged = false;

        private bool is_type1_recycler;

        private bool is_type2_recyclerChanged = false;

        private bool is_type2_recycler;

        private bool is_type3_recyclerChanged = false;

        private bool is_type3_recycler;

        private bool is_type4_recyclerChanged = false;

        private bool is_type4_recycler;

        private bool is_type5_recyclerChanged = false;

        private bool is_type5_recycler;

        private bool is_type6_recyclerChanged = false;

        private bool is_type6_recycler;

        private bool is_type7_recyclerChanged = false;

        private bool is_type7_recycler;

        private bool IsNewEntity => isNewEntity;

        public int RegionId
        {
            get
            {
                return region_id;
            }
            set
            {
                region_id = value;
                region_idChanged = true;
            }
        }

        private string region_idDbString => region_id.ToString();

        public string NoteSetTypeName
        {
            get
            {
                return note_set_type_name;
            }
            set
            {
                note_set_type_name = value;
                note_set_type_nameChanged = true;
            }
        }

        private string note_set_type_nameDbString
        {
            get
            {
                if (note_set_type_name != null)
                {
                    return $"'{note_set_type_name}'";
                }

                return "null";
            }
        }

        public int? DenominationType1
        {
            get
            {
                return denomination_type_1;
            }
            set
            {
                denomination_type_1 = value;
                denomination_type_1Changed = true;
            }
        }

        private string denomination_type_1DbString
        {
            get
            {
                if (denomination_type_1.HasValue)
                {
                    return denomination_type_1.ToString();
                }

                return "null";
            }
        }

        public int? DenominationType2
        {
            get
            {
                return denomination_type_2;
            }
            set
            {
                denomination_type_2 = value;
                denomination_type_2Changed = true;
            }
        }

        private string denomination_type_2DbString
        {
            get
            {
                if (denomination_type_2.HasValue)
                {
                    return denomination_type_2.ToString();
                }

                return "null";
            }
        }

        public int? DenominationType3
        {
            get
            {
                return denomination_type_3;
            }
            set
            {
                denomination_type_3 = value;
                denomination_type_3Changed = true;
            }
        }

        private string denomination_type_3DbString
        {
            get
            {
                if (denomination_type_3.HasValue)
                {
                    return denomination_type_3.ToString();
                }

                return "null";
            }
        }

        public int? DenominationType4
        {
            get
            {
                return denomination_type_4;
            }
            set
            {
                denomination_type_4 = value;
                denomination_type_4Changed = true;
            }
        }

        private string denomination_type_4DbString
        {
            get
            {
                if (denomination_type_4.HasValue)
                {
                    return denomination_type_4.ToString();
                }

                return "null";
            }
        }

        public int? DenominationType5
        {
            get
            {
                return denomination_type_5;
            }
            set
            {
                denomination_type_5 = value;
                denomination_type_5Changed = true;
            }
        }

        private string denomination_type_5DbString
        {
            get
            {
                if (denomination_type_5.HasValue)
                {
                    return denomination_type_5.ToString();
                }

                return "null";
            }
        }

        public int? DenominationType6
        {
            get
            {
                return denomination_type_6;
            }
            set
            {
                denomination_type_6 = value;
                denomination_type_6Changed = true;
            }
        }

        private string denomination_type_6DbString
        {
            get
            {
                if (denomination_type_6.HasValue)
                {
                    return denomination_type_6.ToString();
                }

                return "null";
            }
        }

        public int? DenominationType7
        {
            get
            {
                return denomination_type_7;
            }
            set
            {
                denomination_type_7 = value;
                denomination_type_7Changed = true;
            }
        }

        private string denomination_type_7DbString
        {
            get
            {
                if (denomination_type_7.HasValue)
                {
                    return denomination_type_7.ToString();
                }

                return "null";
            }
        }

        public int NoteSetTypeId
        {
            get
            {
                return note_set_type_id;
            }
            set
            {
                note_set_type_id = value;
                note_set_type_idChanged = true;
            }
        }

        private string note_set_type_idDbString => note_set_type_id.ToString();

        public int CreatedBy
        {
            get
            {
                return created_by;
            }
            set
            {
                created_by = value;
                created_byChanged = true;
            }
        }

        private string created_byDbString => created_by.ToString();

        public string DenominationType1Title
        {
            get
            {
                return denomination_type_1_title;
            }
            set
            {
                denomination_type_1_title = value;
                denomination_type_1_titleChanged = true;
            }
        }

        private string denomination_type_1_titleDbString
        {
            get
            {
                if (denomination_type_1_title != null)
                {
                    return $"'{denomination_type_1_title}'";
                }

                return "null";
            }
        }

        public string DenominationType2Title
        {
            get
            {
                return denomination_type_2_title;
            }
            set
            {
                denomination_type_2_title = value;
                denomination_type_2_titleChanged = true;
            }
        }

        private string denomination_type_2_titleDbString
        {
            get
            {
                if (denomination_type_2_title != null)
                {
                    return $"'{denomination_type_2_title}'";
                }

                return "null";
            }
        }

        public string DenominationType3Title
        {
            get
            {
                return denomination_type_3_title;
            }
            set
            {
                denomination_type_3_title = value;
                denomination_type_3_titleChanged = true;
            }
        }

        private string denomination_type_3_titleDbString
        {
            get
            {
                if (denomination_type_3_title != null)
                {
                    return $"'{denomination_type_3_title}'";
                }

                return "null";
            }
        }

        public string DenominationType4Title
        {
            get
            {
                return denomination_type_4_title;
            }
            set
            {
                denomination_type_4_title = value;
                denomination_type_4_titleChanged = true;
            }
        }

        private string denomination_type_4_titleDbString
        {
            get
            {
                if (denomination_type_4_title != null)
                {
                    return $"'{denomination_type_4_title}'";
                }

                return "null";
            }
        }

        public string DenominationType5Title
        {
            get
            {
                return denomination_type_5_title;
            }
            set
            {
                denomination_type_5_title = value;
                denomination_type_5_titleChanged = true;
            }
        }

        private string denomination_type_5_titleDbString
        {
            get
            {
                if (denomination_type_5_title != null)
                {
                    return $"'{denomination_type_5_title}'";
                }

                return "null";
            }
        }

        public string DenominationType6Title
        {
            get
            {
                return denomination_type_6_title;
            }
            set
            {
                denomination_type_6_title = value;
                denomination_type_6_titleChanged = true;
            }
        }

        private string denomination_type_6_titleDbString
        {
            get
            {
                if (denomination_type_6_title != null)
                {
                    return $"'{denomination_type_6_title}'";
                }

                return "null";
            }
        }

        public string DenominationType7Title
        {
            get
            {
                return denomination_type_7_title;
            }
            set
            {
                denomination_type_7_title = value;
                denomination_type_7_titleChanged = true;
            }
        }

        private string denomination_type_7_titleDbString
        {
            get
            {
                if (denomination_type_7_title != null)
                {
                    return $"'{denomination_type_7_title}'";
                }

                return "null";
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return creation_time;
            }
            set
            {
                creation_time = value;
                creation_timeChanged = true;
            }
        }

        private string creation_timeDbString => string.Format("Convert(datetime,'{0}',121)", creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));

        public bool? IsType1MultiCurrency
        {
            get
            {
                return is_type1_multi_currency;
            }
            set
            {
                is_type1_multi_currency = value;
                is_type1_multi_currencyChanged = true;
            }
        }

        private string is_type1_multi_currencyDbString
        {
            get
            {
                if (is_type1_multi_currency.HasValue)
                {
                    return is_type1_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool? IsType2MultiCurrency
        {
            get
            {
                return is_type2_multi_currency;
            }
            set
            {
                is_type2_multi_currency = value;
                is_type2_multi_currencyChanged = true;
            }
        }

        private string is_type2_multi_currencyDbString
        {
            get
            {
                if (is_type2_multi_currency.HasValue)
                {
                    return is_type2_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool? IsType3MultiCurrency
        {
            get
            {
                return is_type3_multi_currency;
            }
            set
            {
                is_type3_multi_currency = value;
                is_type3_multi_currencyChanged = true;
            }
        }

        private string is_type3_multi_currencyDbString
        {
            get
            {
                if (is_type3_multi_currency.HasValue)
                {
                    return is_type3_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool? IsType4MultiCurrency
        {
            get
            {
                return is_type4_multi_currency;
            }
            set
            {
                is_type4_multi_currency = value;
                is_type4_multi_currencyChanged = true;
            }
        }

        private string is_type4_multi_currencyDbString
        {
            get
            {
                if (is_type4_multi_currency.HasValue)
                {
                    return is_type4_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool? IsType5MultiCurrency
        {
            get
            {
                return is_type5_multi_currency;
            }
            set
            {
                is_type5_multi_currency = value;
                is_type5_multi_currencyChanged = true;
            }
        }

        private string is_type5_multi_currencyDbString
        {
            get
            {
                if (is_type5_multi_currency.HasValue)
                {
                    return is_type5_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool? IsType6MultiCurrency
        {
            get
            {
                return is_type6_multi_currency;
            }
            set
            {
                is_type6_multi_currency = value;
                is_type6_multi_currencyChanged = true;
            }
        }

        private string is_type6_multi_currencyDbString
        {
            get
            {
                if (is_type6_multi_currency.HasValue)
                {
                    return is_type6_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool? IsType7MultiCurrency
        {
            get
            {
                return is_type7_multi_currency;
            }
            set
            {
                is_type7_multi_currency = value;
                is_type7_multi_currencyChanged = true;
            }
        }

        private string is_type7_multi_currencyDbString
        {
            get
            {
                if (is_type7_multi_currency.HasValue)
                {
                    return is_type7_multi_currency.Value ? "1" : "0";
                }

                return "null";
            }
        }

        public bool IsType1Recycler
        {
            get
            {
                return is_type1_recycler;
            }
            set
            {
                is_type1_recycler = value;
                is_type1_recyclerChanged = true;
            }
        }

        private string is_type1_recyclerDbString => is_type1_recycler ? "1" : "0";

        public bool IsType2Recycler
        {
            get
            {
                return is_type2_recycler;
            }
            set
            {
                is_type2_recycler = value;
                is_type2_recyclerChanged = true;
            }
        }

        private string is_type2_recyclerDbString => is_type2_recycler ? "1" : "0";

        public bool IsType3Recycler
        {
            get
            {
                return is_type3_recycler;
            }
            set
            {
                is_type3_recycler = value;
                is_type3_recyclerChanged = true;
            }
        }

        private string is_type3_recyclerDbString => is_type3_recycler ? "1" : "0";

        public bool IsType4Recycler
        {
            get
            {
                return is_type4_recycler;
            }
            set
            {
                is_type4_recycler = value;
                is_type4_recyclerChanged = true;
            }
        }

        private string is_type4_recyclerDbString => is_type4_recycler ? "1" : "0";

        public bool IsType5Recycler
        {
            get
            {
                return is_type5_recycler;
            }
            set
            {
                is_type5_recycler = value;
                is_type5_recyclerChanged = true;
            }
        }

        private string is_type5_recyclerDbString => is_type5_recycler ? "1" : "0";

        public bool IsType6Recycler
        {
            get
            {
                return is_type6_recycler;
            }
            set
            {
                is_type6_recycler = value;
                is_type6_recyclerChanged = true;
            }
        }

        private string is_type6_recyclerDbString => is_type6_recycler ? "1" : "0";

        public bool IsType7Recycler
        {
            get
            {
                return is_type7_recycler;
            }
            set
            {
                is_type7_recycler = value;
                is_type7_recyclerChanged = true;
            }
        }

        private string is_type7_recyclerDbString => is_type7_recycler ? "1" : "0";

        public NoteSetType()
        {
        }

        public NoteSetType(int region_id, string note_set_type_name, int note_set_type_id, int created_by, DateTime creation_time, bool is_type1_recycler, bool is_type2_recycler, bool is_type3_recycler, bool is_type4_recycler, bool is_type5_recycler, bool is_type6_recycler, bool is_type7_recycler)
        {
            this.region_id = region_id;
            region_idChanged = true;
            this.note_set_type_name = note_set_type_name;
            note_set_type_nameChanged = true;
            this.created_by = created_by;
            created_byChanged = true;
            this.creation_time = creation_time;
            creation_timeChanged = true;
            this.is_type1_recycler = is_type1_recycler;
            is_type1_recyclerChanged = true;
            this.is_type2_recycler = is_type2_recycler;
            is_type2_recyclerChanged = true;
            this.is_type3_recycler = is_type3_recycler;
            is_type3_recyclerChanged = true;
            this.is_type4_recycler = is_type4_recycler;
            is_type4_recyclerChanged = true;
            this.is_type5_recycler = is_type5_recycler;
            is_type5_recyclerChanged = true;
            this.is_type6_recycler = is_type6_recycler;
            is_type6_recyclerChanged = true;
            this.is_type7_recycler = is_type7_recycler;
            is_type7_recyclerChanged = true;
        }

        public NoteSetType(int region_id, string note_set_type_name, int? denomination_type_1, int? denomination_type_2, int? denomination_type_3, int? denomination_type_4, int? denomination_type_5, int? denomination_type_6, int? denomination_type_7, int created_by, string denomination_type_1_title, string denomination_type_2_title, string denomination_type_3_title, string denomination_type_4_title, string denomination_type_5_title, string denomination_type_6_title, string denomination_type_7_title, DateTime creation_time, bool? is_type1_multi_currency, bool? is_type2_multi_currency, bool? is_type3_multi_currency, bool? is_type4_multi_currency, bool? is_type5_multi_currency, bool? is_type6_multi_currency, bool? is_type7_multi_currency, bool is_type1_recycler, bool is_type2_recycler, bool is_type3_recycler, bool is_type4_recycler, bool is_type5_recycler, bool is_type6_recycler, bool is_type7_recycler)
        {
            this.region_id = region_id;
            region_idChanged = true;
            this.note_set_type_name = note_set_type_name;
            note_set_type_nameChanged = true;
            this.denomination_type_1 = denomination_type_1;
            denomination_type_1Changed = true;
            this.denomination_type_2 = denomination_type_2;
            denomination_type_2Changed = true;
            this.denomination_type_3 = denomination_type_3;
            denomination_type_3Changed = true;
            this.denomination_type_4 = denomination_type_4;
            denomination_type_4Changed = true;
            this.denomination_type_5 = denomination_type_5;
            denomination_type_5Changed = true;
            this.denomination_type_6 = denomination_type_6;
            denomination_type_6Changed = true;
            this.denomination_type_7 = denomination_type_7;
            denomination_type_7Changed = true;
            this.created_by = created_by;
            created_byChanged = true;
            this.denomination_type_1_title = denomination_type_1_title;
            denomination_type_1_titleChanged = true;
            this.denomination_type_2_title = denomination_type_2_title;
            denomination_type_2_titleChanged = true;
            this.denomination_type_3_title = denomination_type_3_title;
            denomination_type_3_titleChanged = true;
            this.denomination_type_4_title = denomination_type_4_title;
            denomination_type_4_titleChanged = true;
            this.denomination_type_5_title = denomination_type_5_title;
            denomination_type_5_titleChanged = true;
            this.denomination_type_6_title = denomination_type_6_title;
            denomination_type_6_titleChanged = true;
            this.denomination_type_7_title = denomination_type_7_title;
            denomination_type_7_titleChanged = true;
            this.creation_time = creation_time;
            creation_timeChanged = true;
            this.is_type1_multi_currency = is_type1_multi_currency;
            is_type1_multi_currencyChanged = true;
            this.is_type2_multi_currency = is_type2_multi_currency;
            is_type2_multi_currencyChanged = true;
            this.is_type3_multi_currency = is_type3_multi_currency;
            is_type3_multi_currencyChanged = true;
            this.is_type4_multi_currency = is_type4_multi_currency;
            is_type4_multi_currencyChanged = true;
            this.is_type5_multi_currency = is_type5_multi_currency;
            is_type5_multi_currencyChanged = true;
            this.is_type6_multi_currency = is_type6_multi_currency;
            is_type6_multi_currencyChanged = true;
            this.is_type7_multi_currency = is_type7_multi_currency;
            is_type7_multi_currencyChanged = true;
            this.is_type1_recycler = is_type1_recycler;
            is_type1_recyclerChanged = true;
            this.is_type2_recycler = is_type2_recycler;
            is_type2_recyclerChanged = true;
            this.is_type3_recycler = is_type3_recycler;
            is_type3_recyclerChanged = true;
            this.is_type4_recycler = is_type4_recycler;
            is_type4_recyclerChanged = true;
            this.is_type5_recycler = is_type5_recycler;
            is_type5_recyclerChanged = true;
            this.is_type6_recycler = is_type6_recycler;
            is_type6_recyclerChanged = true;
            this.is_type7_recycler = is_type7_recycler;
            is_type7_recyclerChanged = true;
        }

        private NoteSetType(int region_id, string note_set_type_name, int? denomination_type_1, int? denomination_type_2, int? denomination_type_3, int? denomination_type_4, int? denomination_type_5, int? denomination_type_6, int? denomination_type_7, int note_set_type_id, int created_by, string denomination_type_1_title, string denomination_type_2_title, string denomination_type_3_title, string denomination_type_4_title, string denomination_type_5_title, string denomination_type_6_title, string denomination_type_7_title, DateTime creation_time, bool? is_type1_multi_currency, bool? is_type2_multi_currency, bool? is_type3_multi_currency, bool? is_type4_multi_currency, bool? is_type5_multi_currency, bool? is_type6_multi_currency, bool? is_type7_multi_currency, bool is_type1_recycler, bool is_type2_recycler, bool is_type3_recycler, bool is_type4_recycler, bool is_type5_recycler, bool is_type6_recycler, bool is_type7_recycler)
        {
            this.region_id = region_id;
            region_idChanged = true;
            this.note_set_type_name = note_set_type_name;
            note_set_type_nameChanged = true;
            this.denomination_type_1 = denomination_type_1;
            denomination_type_1Changed = true;
            this.denomination_type_2 = denomination_type_2;
            denomination_type_2Changed = true;
            this.denomination_type_3 = denomination_type_3;
            denomination_type_3Changed = true;
            this.denomination_type_4 = denomination_type_4;
            denomination_type_4Changed = true;
            this.denomination_type_5 = denomination_type_5;
            denomination_type_5Changed = true;
            this.denomination_type_6 = denomination_type_6;
            denomination_type_6Changed = true;
            this.denomination_type_7 = denomination_type_7;
            denomination_type_7Changed = true;
            this.note_set_type_id = note_set_type_id;
            note_set_type_idChanged = true;
            this.created_by = created_by;
            created_byChanged = true;
            this.denomination_type_1_title = denomination_type_1_title;
            denomination_type_1_titleChanged = true;
            this.denomination_type_2_title = denomination_type_2_title;
            denomination_type_2_titleChanged = true;
            this.denomination_type_3_title = denomination_type_3_title;
            denomination_type_3_titleChanged = true;
            this.denomination_type_4_title = denomination_type_4_title;
            denomination_type_4_titleChanged = true;
            this.denomination_type_5_title = denomination_type_5_title;
            denomination_type_5_titleChanged = true;
            this.denomination_type_6_title = denomination_type_6_title;
            denomination_type_6_titleChanged = true;
            this.denomination_type_7_title = denomination_type_7_title;
            denomination_type_7_titleChanged = true;
            this.creation_time = creation_time;
            creation_timeChanged = true;
            this.is_type1_multi_currency = is_type1_multi_currency;
            is_type1_multi_currencyChanged = true;
            this.is_type2_multi_currency = is_type2_multi_currency;
            is_type2_multi_currencyChanged = true;
            this.is_type3_multi_currency = is_type3_multi_currency;
            is_type3_multi_currencyChanged = true;
            this.is_type4_multi_currency = is_type4_multi_currency;
            is_type4_multi_currencyChanged = true;
            this.is_type5_multi_currency = is_type5_multi_currency;
            is_type5_multi_currencyChanged = true;
            this.is_type6_multi_currency = is_type6_multi_currency;
            is_type6_multi_currencyChanged = true;
            this.is_type7_multi_currency = is_type7_multi_currency;
            is_type7_multi_currencyChanged = true;
            this.is_type1_recycler = is_type1_recycler;
            is_type1_recyclerChanged = true;
            this.is_type2_recycler = is_type2_recycler;
            is_type2_recyclerChanged = true;
            this.is_type3_recycler = is_type3_recycler;
            is_type3_recyclerChanged = true;
            this.is_type4_recycler = is_type4_recycler;
            is_type4_recyclerChanged = true;
            this.is_type5_recycler = is_type5_recycler;
            is_type5_recyclerChanged = true;
            this.is_type6_recycler = is_type6_recycler;
            is_type6_recyclerChanged = true;
            this.is_type7_recycler = is_type7_recycler;
            is_type7_recyclerChanged = true;
        }

        public static NoteSetTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder stringBuilder = new StringBuilder(200);
            stringBuilder.Append("select ");
            if (Columns.region_id == (Columns.region_id & columns))
            {
                stringBuilder.Append("region_id,");
            }

            if (Columns.note_set_type_name == (Columns.note_set_type_name & columns))
            {
                stringBuilder.Append("note_set_type_name,");
            }

            if (Columns.denomination_type_1 == (Columns.denomination_type_1 & columns))
            {
                stringBuilder.Append("denomination_type_1,");
            }

            if (Columns.denomination_type_2 == (Columns.denomination_type_2 & columns))
            {
                stringBuilder.Append("denomination_type_2,");
            }

            if (Columns.denomination_type_3 == (Columns.denomination_type_3 & columns))
            {
                stringBuilder.Append("denomination_type_3,");
            }

            if (Columns.denomination_type_4 == (Columns.denomination_type_4 & columns))
            {
                stringBuilder.Append("denomination_type_4,");
            }

            if (Columns.denomination_type_5 == (Columns.denomination_type_5 & columns))
            {
                stringBuilder.Append("denomination_type_5,");
            }

            if (Columns.denomination_type_6 == (Columns.denomination_type_6 & columns))
            {
                stringBuilder.Append("denomination_type_6,");
            }

            if (Columns.denomination_type_7 == (Columns.denomination_type_7 & columns))
            {
                stringBuilder.Append("denomination_type_7,");
            }

            if (Columns.note_set_type_id == (Columns.note_set_type_id & columns))
            {
                stringBuilder.Append("note_set_type_id,");
            }

            if (Columns.created_by == (Columns.created_by & columns))
            {
                stringBuilder.Append("created_by,");
            }

            if (Columns.denomination_type_1_title == (Columns.denomination_type_1_title & columns))
            {
                stringBuilder.Append("denomination_type_1_title,");
            }

            if (Columns.denomination_type_2_title == (Columns.denomination_type_2_title & columns))
            {
                stringBuilder.Append("denomination_type_2_title,");
            }

            if (Columns.denomination_type_3_title == (Columns.denomination_type_3_title & columns))
            {
                stringBuilder.Append("denomination_type_3_title,");
            }

            if (Columns.denomination_type_4_title == (Columns.denomination_type_4_title & columns))
            {
                stringBuilder.Append("denomination_type_4_title,");
            }

            if (Columns.denomination_type_5_title == (Columns.denomination_type_5_title & columns))
            {
                stringBuilder.Append("denomination_type_5_title,");
            }

            if (Columns.denomination_type_6_title == (Columns.denomination_type_6_title & columns))
            {
                stringBuilder.Append("denomination_type_6_title,");
            }

            if (Columns.denomination_type_7_title == (Columns.denomination_type_7_title & columns))
            {
                stringBuilder.Append("denomination_type_7_title,");
            }

            if (Columns.creation_time == (Columns.creation_time & columns))
            {
                stringBuilder.Append("creation_time,");
            }

            if (Columns.is_type1_multi_currency == (Columns.is_type1_multi_currency & columns))
            {
                stringBuilder.Append("is_type1_multi_currency,");
            }

            if (Columns.is_type2_multi_currency == (Columns.is_type2_multi_currency & columns))
            {
                stringBuilder.Append("is_type2_multi_currency,");
            }

            if (Columns.is_type3_multi_currency == (Columns.is_type3_multi_currency & columns))
            {
                stringBuilder.Append("is_type3_multi_currency,");
            }

            if (Columns.is_type4_multi_currency == (Columns.is_type4_multi_currency & columns))
            {
                stringBuilder.Append("is_type4_multi_currency,");
            }

            if (Columns.is_type5_multi_currency == (Columns.is_type5_multi_currency & columns))
            {
                stringBuilder.Append("is_type5_multi_currency,");
            }

            if (Columns.is_type6_multi_currency == (Columns.is_type6_multi_currency & columns))
            {
                stringBuilder.Append("is_type6_multi_currency,");
            }

            if (Columns.is_type7_multi_currency == (Columns.is_type7_multi_currency & columns))
            {
                stringBuilder.Append("is_type7_multi_currency,");
            }

            if (Columns.is_type1_recycler == (Columns.is_type1_recycler & columns))
            {
                stringBuilder.Append("is_type1_recycler,");
            }

            if (Columns.is_type2_recycler == (Columns.is_type2_recycler & columns))
            {
                stringBuilder.Append("is_type2_recycler,");
            }

            if (Columns.is_type3_recycler == (Columns.is_type3_recycler & columns))
            {
                stringBuilder.Append("is_type3_recycler,");
            }

            if (Columns.is_type4_recycler == (Columns.is_type4_recycler & columns))
            {
                stringBuilder.Append("is_type4_recycler,");
            }

            if (Columns.is_type5_recycler == (Columns.is_type5_recycler & columns))
            {
                stringBuilder.Append("is_type5_recycler,");
            }

            if (Columns.is_type6_recycler == (Columns.is_type6_recycler & columns))
            {
                stringBuilder.Append("is_type6_recycler,");
            }

            if (Columns.is_type7_recycler == (Columns.is_type7_recycler & columns))
            {
                stringBuilder.Append("is_type7_recycler,");
            }

            stringBuilder.Replace(',', ' ', stringBuilder.Length - 1, 1);
            stringBuilder.Append("from Note_set_type ");
            if (where != null && where.Trim().Length > 0)
            {
                stringBuilder.Append(" where ");
                stringBuilder.Append(where);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            IDbCommand dbCommand = conn.CreateCommand();
            dbCommand.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ";
            dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = stringBuilder.ToString();
            return new NoteSetTypeReader(dbCommand.ExecuteReader(), conn, columns);
        }

        public static NoteSetTypeReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        public static NoteSetTypeReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            IDbCommand dbCommand = conn.CreateCommand();
            dbCommand.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = "Select region_id,note_set_type_name,denomination_type_1,denomination_type_2,denomination_type_3,denomination_type_4,denomination_type_5,denomination_type_6,denomination_type_7,note_set_type_id,created_by,denomination_type_1_title,denomination_type_2_title,denomination_type_3_title,denomination_type_4_title,denomination_type_5_title,denomination_type_6_title,denomination_type_7_title,creation_time,is_type1_multi_currency,is_type2_multi_currency,is_type3_multi_currency,is_type4_multi_currency,is_type5_multi_currency,is_type6_multi_currency,is_type7_multi_currency,is_type1_recycler,is_type2_recycler,is_type3_recycler,is_type4_recycler,is_type5_recycler,is_type6_recycler,is_type7_recycler from Note_set_type ";
            if (where != null && where.Trim().Length > 0)
            {
                dbCommand.CommandText = $"{dbCommand.CommandText} where {where}";
            }

            return new NoteSetTypeReader(dbCommand.ExecuteReader(), conn);
        }

        public static NoteSetTypeReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static NoteSetType LoadNoteSetType(string where)
        {
            NoteSetTypeReader noteSetTypeReader = ExecuteReader(where);
            NoteSetType result = null;
            if (noteSetTypeReader.Read())
            {
                result = noteSetTypeReader.CurrentNoteSetType;
            }

            noteSetTypeReader.Close();
            return result;
        }

        public static NoteSetType LoadNoteSetType(string where, IDbConnection conn)
        {
            NoteSetTypeReader noteSetTypeReader = ExecuteReader(where, conn);
            NoteSetType result = null;
            if (noteSetTypeReader.Read())
            {
                result = noteSetTypeReader.CurrentNoteSetType;
            }

            noteSetTypeReader.Close(closeConnection: false);
            return result;
        }

        public static NoteSetType LoadNoteSetTypeByPk(long note_set_type_id)
        {
            return LoadNoteSetType("note_set_type_id=" + note_set_type_id);
        }

        public static NoteSetType LoadNoteSetTypeByPk(long note_set_type_id, IDbConnection conn)
        {
            return LoadNoteSetType(" note_set_type_id=" + note_set_type_id, conn);
        }

        public void Save()
        {
            if (region_idChanged || note_set_type_nameChanged || denomination_type_1Changed || denomination_type_2Changed || denomination_type_3Changed || denomination_type_4Changed || denomination_type_5Changed || denomination_type_6Changed || denomination_type_7Changed || note_set_type_idChanged || created_byChanged || denomination_type_1_titleChanged || denomination_type_2_titleChanged || denomination_type_3_titleChanged || denomination_type_4_titleChanged || denomination_type_5_titleChanged || denomination_type_6_titleChanged || denomination_type_7_titleChanged || creation_timeChanged || is_type1_multi_currencyChanged || is_type2_multi_currencyChanged || is_type3_multi_currencyChanged || is_type4_multi_currencyChanged || is_type5_multi_currencyChanged || is_type6_multi_currencyChanged || is_type7_multi_currencyChanged || is_type1_recyclerChanged || is_type2_recyclerChanged || is_type3_recyclerChanged || is_type4_recyclerChanged || is_type5_recyclerChanged || is_type6_recyclerChanged || is_type7_recyclerChanged)
            {
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Core).CreateCommand());
            }
        }

        public void Save(IDbConnection conn, IDbTransaction trx)
        {
            IDbCommand dbCommand = conn.CreateCommand();
            dbCommand.Transaction = trx;
            ExcuteSave(dbCommand);
        }

        public void Save(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            ExcuteSave(cmd);
        }

        private void ExcuteSave(IDbCommand cmd)
        {
            if (!region_idChanged && !note_set_type_nameChanged && !denomination_type_1Changed && !denomination_type_2Changed && !denomination_type_3Changed && !denomination_type_4Changed && !denomination_type_5Changed && !denomination_type_6Changed && !denomination_type_7Changed && !note_set_type_idChanged && !created_byChanged && !denomination_type_1_titleChanged && !denomination_type_2_titleChanged && !denomination_type_3_titleChanged && !denomination_type_4_titleChanged && !denomination_type_5_titleChanged && !denomination_type_6_titleChanged && !denomination_type_7_titleChanged && !creation_timeChanged && !is_type1_multi_currencyChanged && !is_type2_multi_currencyChanged && !is_type3_multi_currencyChanged && !is_type4_multi_currencyChanged && !is_type5_multi_currencyChanged && !is_type6_multi_currencyChanged && !is_type7_multi_currencyChanged && !is_type1_recyclerChanged && !is_type2_recyclerChanged && !is_type3_recyclerChanged && !is_type4_recyclerChanged && !is_type5_recyclerChanged && !is_type6_recyclerChanged && !is_type7_recyclerChanged)
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder(500);
            if (isNewEntity)
            {
                stringBuilder.Append("insert into Note_set_type(region_id,note_set_type_name,denomination_type_1,denomination_type_2,denomination_type_3,denomination_type_4,denomination_type_5,denomination_type_6,denomination_type_7,note_set_type_id,created_by,denomination_type_1_title,denomination_type_2_title,denomination_type_3_title,denomination_type_4_title,denomination_type_5_title,denomination_type_6_title,denomination_type_7_title,creation_time,is_type1_multi_currency,is_type2_multi_currency,is_type3_multi_currency,is_type4_multi_currency,is_type5_multi_currency,is_type6_multi_currency,is_type7_multi_currency,is_type1_recycler,is_type2_recycler,is_type3_recycler,is_type4_recycler,is_type5_recycler,is_type6_recycler,is_type7_recycler) values(");
                stringBuilder.Append(region_idDbString + ",");
                stringBuilder.Append(note_set_type_nameDbString + ",");
                stringBuilder.Append(denomination_type_1DbString + ",");
                stringBuilder.Append(denomination_type_2DbString + ",");
                stringBuilder.Append(denomination_type_3DbString + ",");
                stringBuilder.Append(denomination_type_4DbString + ",");
                stringBuilder.Append(denomination_type_5DbString + ",");
                stringBuilder.Append(denomination_type_6DbString + ",");
                stringBuilder.Append(denomination_type_7DbString + ",");
                lock (ConnectionFactory.connectionStringCore)
                {
                    note_set_type_id = (int)ConnectionFactory.GetNextId(DatabaseName.Core);
                    stringBuilder.Append(note_set_type_id);
                }

                stringBuilder.Append(",");
                stringBuilder.Append(created_byDbString + ",");
                stringBuilder.Append(denomination_type_1_titleDbString + ",");
                stringBuilder.Append(denomination_type_2_titleDbString + ",");
                stringBuilder.Append(denomination_type_3_titleDbString + ",");
                stringBuilder.Append(denomination_type_4_titleDbString + ",");
                stringBuilder.Append(denomination_type_5_titleDbString + ",");
                stringBuilder.Append(denomination_type_6_titleDbString + ",");
                stringBuilder.Append(denomination_type_7_titleDbString + ",");
                stringBuilder.Append(creation_timeDbString + ",");
                stringBuilder.Append(is_type1_multi_currencyDbString + ",");
                stringBuilder.Append(is_type2_multi_currencyDbString + ",");
                stringBuilder.Append(is_type3_multi_currencyDbString + ",");
                stringBuilder.Append(is_type4_multi_currencyDbString + ",");
                stringBuilder.Append(is_type5_multi_currencyDbString + ",");
                stringBuilder.Append(is_type6_multi_currencyDbString + ",");
                stringBuilder.Append(is_type7_multi_currencyDbString + ",");
                stringBuilder.Append(is_type1_recyclerDbString + ",");
                stringBuilder.Append(is_type2_recyclerDbString + ",");
                stringBuilder.Append(is_type3_recyclerDbString + ",");
                stringBuilder.Append(is_type4_recyclerDbString + ",");
                stringBuilder.Append(is_type5_recyclerDbString + ",");
                stringBuilder.Append(is_type6_recyclerDbString + ",");
                stringBuilder.Append(is_type7_recyclerDbString);
                stringBuilder.Append(");");
            }
            else
            {
                if (!region_idChanged && !note_set_type_nameChanged && !denomination_type_1Changed && !denomination_type_2Changed && !denomination_type_3Changed && !denomination_type_4Changed && !denomination_type_5Changed && !denomination_type_6Changed && !denomination_type_7Changed && !note_set_type_idChanged && !created_byChanged && !denomination_type_1_titleChanged && !denomination_type_2_titleChanged && !denomination_type_3_titleChanged && !denomination_type_4_titleChanged && !denomination_type_5_titleChanged && !denomination_type_6_titleChanged && !denomination_type_7_titleChanged && !creation_timeChanged && !is_type1_multi_currencyChanged && !is_type2_multi_currencyChanged && !is_type3_multi_currencyChanged && !is_type4_multi_currencyChanged && !is_type5_multi_currencyChanged && !is_type6_multi_currencyChanged && !is_type7_multi_currencyChanged && !is_type1_recyclerChanged && !is_type2_recyclerChanged && !is_type3_recyclerChanged && !is_type4_recyclerChanged && !is_type5_recyclerChanged && !is_type6_recyclerChanged && !is_type7_recyclerChanged)
                {
                    return;
                }

                stringBuilder.Append("UPDATE Note_set_type set ");
                if (region_idChanged)
                {
                    stringBuilder.Append("region_id =" + region_idDbString);
                    stringBuilder.Append(",");
                }

                if (note_set_type_nameChanged)
                {
                    stringBuilder.Append("note_set_type_name =" + note_set_type_nameDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_1Changed)
                {
                    stringBuilder.Append("denomination_type_1 =" + denomination_type_1DbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_2Changed)
                {
                    stringBuilder.Append("denomination_type_2 =" + denomination_type_2DbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_3Changed)
                {
                    stringBuilder.Append("denomination_type_3 =" + denomination_type_3DbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_4Changed)
                {
                    stringBuilder.Append("denomination_type_4 =" + denomination_type_4DbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_5Changed)
                {
                    stringBuilder.Append("denomination_type_5 =" + denomination_type_5DbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_6Changed)
                {
                    stringBuilder.Append("denomination_type_6 =" + denomination_type_6DbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_7Changed)
                {
                    stringBuilder.Append("denomination_type_7 =" + denomination_type_7DbString);
                    stringBuilder.Append(",");
                }

                if (created_byChanged)
                {
                    stringBuilder.Append("created_by =" + created_byDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_1_titleChanged)
                {
                    stringBuilder.Append("denomination_type_1_title =" + denomination_type_1_titleDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_2_titleChanged)
                {
                    stringBuilder.Append("denomination_type_2_title =" + denomination_type_2_titleDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_3_titleChanged)
                {
                    stringBuilder.Append("denomination_type_3_title =" + denomination_type_3_titleDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_4_titleChanged)
                {
                    stringBuilder.Append("denomination_type_4_title =" + denomination_type_4_titleDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_5_titleChanged)
                {
                    stringBuilder.Append("denomination_type_5_title =" + denomination_type_5_titleDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_6_titleChanged)
                {
                    stringBuilder.Append("denomination_type_6_title =" + denomination_type_6_titleDbString);
                    stringBuilder.Append(",");
                }

                if (denomination_type_7_titleChanged)
                {
                    stringBuilder.Append("denomination_type_7_title =" + denomination_type_7_titleDbString);
                    stringBuilder.Append(",");
                }

                if (creation_timeChanged)
                {
                    stringBuilder.Append("creation_time =" + creation_timeDbString);
                    stringBuilder.Append(",");
                }

                if (is_type1_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type1_multi_currency =" + is_type1_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type2_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type2_multi_currency =" + is_type2_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type3_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type3_multi_currency =" + is_type3_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type4_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type4_multi_currency =" + is_type4_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type5_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type5_multi_currency =" + is_type5_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type6_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type6_multi_currency =" + is_type6_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type7_multi_currencyChanged)
                {
                    stringBuilder.Append("is_type7_multi_currency =" + is_type7_multi_currencyDbString);
                    stringBuilder.Append(",");
                }

                if (is_type1_recyclerChanged)
                {
                    stringBuilder.Append("is_type1_recycler =" + is_type1_recyclerDbString);
                    stringBuilder.Append(",");
                }

                if (is_type2_recyclerChanged)
                {
                    stringBuilder.Append("is_type2_recycler =" + is_type2_recyclerDbString);
                    stringBuilder.Append(",");
                }

                if (is_type3_recyclerChanged)
                {
                    stringBuilder.Append("is_type3_recycler =" + is_type3_recyclerDbString);
                    stringBuilder.Append(",");
                }

                if (is_type4_recyclerChanged)
                {
                    stringBuilder.Append("is_type4_recycler =" + is_type4_recyclerDbString);
                    stringBuilder.Append(",");
                }

                if (is_type5_recyclerChanged)
                {
                    stringBuilder.Append("is_type5_recycler =" + is_type5_recyclerDbString);
                    stringBuilder.Append(",");
                }

                if (is_type6_recyclerChanged)
                {
                    stringBuilder.Append("is_type6_recycler =" + is_type6_recyclerDbString);
                    stringBuilder.Append(",");
                }

                if (is_type7_recyclerChanged)
                {
                    stringBuilder.Append("is_type7_recycler =" + is_type7_recyclerDbString);
                    stringBuilder.Append(",");
                }

                stringBuilder.Replace(',', ' ', stringBuilder.Length - 1, 1);
                stringBuilder.Append(" where ");
                stringBuilder.Append("note_set_type_id = " + note_set_type_idDbString);
            }

            cmd.CommandText = stringBuilder.ToString();
            bool flag = false;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                flag = true;
            }

            if (isNewEntity)
            {
                cmd.ExecuteNonQuery();
                isNewEntity = false;
            }
            else
            {
                cmd.ExecuteNonQuery();
            }

            if (flag)
            {
                cmd.Connection.Close();
            }
        }

        public void Delete()
        {
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand dbCommand = conn.CreateCommand();
            dbCommand.CommandText = "DELETE Note_set_type where note_set_type_id= " + note_set_type_id;
            if (conn.State == ConnectionState.Closed)
            {
                dbCommand.Connection.Open();
                dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
            }
            else
            {
                dbCommand.ExecuteNonQuery();
            }
        }

        public void Delete(IDbConnection conn, IDbTransaction trxn)
        {
            IDbCommand dbCommand = conn.CreateCommand();
            dbCommand.CommandText = "DELETE Note_set_type where   note_set_type_id = " + note_set_type_id;
            dbCommand.Transaction = trxn;
            if (conn.State == ConnectionState.Closed)
            {
                dbCommand.Connection.Open();
                dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
            }
            else
            {
                dbCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteNoteSetTypes(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Note_set_type where " + where, DatabaseName.Core);
        }

        public DataTable BulkSave(List<NoteSetType> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            sqlBulkCopy.DestinationTableName = "Note_set_type";
            sqlBulkCopy.WriteToServer(dt);
            return dt;
        }

        public void CreateDataTable(DataTable dt)
        {
            string[] names = Enum.GetNames(typeof(Columns));
            for (int i = 0; i < names.Length; i++)
            {
                dt.Columns.Add(names[i]);
            }
        }

        public void AddToDataTable(List<NoteSetType> transList, ref DataTable dt)
        {
            foreach (NoteSetType trans in transList)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["region_id"] = trans.RegionId;
                dataRow["note_set_type_name"] = trans.NoteSetTypeName;
                dataRow["denomination_type_1"] = trans.DenominationType1;
                dataRow["denomination_type_2"] = trans.DenominationType2;
                dataRow["denomination_type_3"] = trans.DenominationType3;
                dataRow["denomination_type_4"] = trans.DenominationType4;
                dataRow["denomination_type_5"] = trans.DenominationType5;
                dataRow["denomination_type_6"] = trans.DenominationType6;
                dataRow["denomination_type_7"] = trans.DenominationType7;
                dataRow["note_set_type_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                dataRow["created_by"] = trans.CreatedBy;
                dataRow["denomination_type_1_title"] = trans.DenominationType1Title;
                dataRow["denomination_type_2_title"] = trans.DenominationType2Title;
                dataRow["denomination_type_3_title"] = trans.DenominationType3Title;
                dataRow["denomination_type_4_title"] = trans.DenominationType4Title;
                dataRow["denomination_type_5_title"] = trans.DenominationType5Title;
                dataRow["denomination_type_6_title"] = trans.DenominationType6Title;
                dataRow["denomination_type_7_title"] = trans.DenominationType7Title;
                dataRow["creation_time"] = trans.CreationTime;
                dataRow["is_type1_multi_currency"] = trans.IsType1MultiCurrency;
                dataRow["is_type2_multi_currency"] = trans.IsType2MultiCurrency;
                dataRow["is_type3_multi_currency"] = trans.IsType3MultiCurrency;
                dataRow["is_type4_multi_currency"] = trans.IsType4MultiCurrency;
                dataRow["is_type5_multi_currency"] = trans.IsType5MultiCurrency;
                dataRow["is_type6_multi_currency"] = trans.IsType6MultiCurrency;
                dataRow["is_type7_multi_currency"] = trans.IsType7MultiCurrency;
                dataRow["is_type1_recycler"] = trans.IsType1Recycler;
                dataRow["is_type2_recycler"] = trans.IsType2Recycler;
                dataRow["is_type3_recycler"] = trans.IsType3Recycler;
                dataRow["is_type4_recycler"] = trans.IsType4Recycler;
                dataRow["is_type5_recycler"] = trans.IsType5Recycler;
                dataRow["is_type6_recycler"] = trans.IsType6Recycler;
                dataRow["is_type7_recycler"] = trans.IsType7Recycler;
                dt.Rows.Add(dataRow);
            }
        }
    }
}
