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
    public class NoteSetType
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public NoteSetType() { }
        public NoteSetType(int region_id, string note_set_type_name, int note_set_type_id, int created_by, DateTime creation_time, bool is_type1_recycler, bool is_type2_recycler, bool is_type3_recycler, bool is_type4_recycler, bool is_type5_recycler, bool is_type6_recycler, bool is_type7_recycler)
        {
            this.region_id = region_id;
            this.region_idChanged = true;
            this.note_set_type_name = note_set_type_name;
            this.note_set_type_nameChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.is_type1_recycler = is_type1_recycler;
            this.is_type1_recyclerChanged = true;
            this.is_type2_recycler = is_type2_recycler;
            this.is_type2_recyclerChanged = true;
            this.is_type3_recycler = is_type3_recycler;
            this.is_type3_recyclerChanged = true;
            this.is_type4_recycler = is_type4_recycler;
            this.is_type4_recyclerChanged = true;
            this.is_type5_recycler = is_type5_recycler;
            this.is_type5_recyclerChanged = true;
            this.is_type6_recycler = is_type6_recycler;
            this.is_type6_recyclerChanged = true;
            this.is_type7_recycler = is_type7_recycler;
            this.is_type7_recyclerChanged = true;
        }
        public NoteSetType(int region_id, string note_set_type_name, int? denomination_type_1, int? denomination_type_2, int? denomination_type_3, int? denomination_type_4, int? denomination_type_5, int? denomination_type_6, int? denomination_type_7, int created_by, string denomination_type_1_title, string denomination_type_2_title, string denomination_type_3_title, string denomination_type_4_title, string denomination_type_5_title, string denomination_type_6_title, string denomination_type_7_title, DateTime creation_time, bool? is_type1_multi_currency, bool? is_type2_multi_currency, bool? is_type3_multi_currency, bool? is_type4_multi_currency, bool? is_type5_multi_currency, bool? is_type6_multi_currency, bool? is_type7_multi_currency, bool is_type1_recycler, bool is_type2_recycler, bool is_type3_recycler, bool is_type4_recycler, bool is_type5_recycler, bool is_type6_recycler, bool is_type7_recycler)
        {
            this.region_id = region_id;
            this.region_idChanged = true;
            this.note_set_type_name = note_set_type_name;
            this.note_set_type_nameChanged = true;
            this.denomination_type_1 = denomination_type_1;
            this.denomination_type_1Changed = true;
            this.denomination_type_2 = denomination_type_2;
            this.denomination_type_2Changed = true;
            this.denomination_type_3 = denomination_type_3;
            this.denomination_type_3Changed = true;
            this.denomination_type_4 = denomination_type_4;
            this.denomination_type_4Changed = true;
            this.denomination_type_5 = denomination_type_5;
            this.denomination_type_5Changed = true;
            this.denomination_type_6 = denomination_type_6;
            this.denomination_type_6Changed = true;
            this.denomination_type_7 = denomination_type_7;
            this.denomination_type_7Changed = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.denomination_type_1_title = denomination_type_1_title;
            this.denomination_type_1_titleChanged = true;
            this.denomination_type_2_title = denomination_type_2_title;
            this.denomination_type_2_titleChanged = true;
            this.denomination_type_3_title = denomination_type_3_title;
            this.denomination_type_3_titleChanged = true;
            this.denomination_type_4_title = denomination_type_4_title;
            this.denomination_type_4_titleChanged = true;
            this.denomination_type_5_title = denomination_type_5_title;
            this.denomination_type_5_titleChanged = true;
            this.denomination_type_6_title = denomination_type_6_title;
            this.denomination_type_6_titleChanged = true;
            this.denomination_type_7_title = denomination_type_7_title;
            this.denomination_type_7_titleChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.is_type1_multi_currency = is_type1_multi_currency;
            this.is_type1_multi_currencyChanged = true;
            this.is_type2_multi_currency = is_type2_multi_currency;
            this.is_type2_multi_currencyChanged = true;
            this.is_type3_multi_currency = is_type3_multi_currency;
            this.is_type3_multi_currencyChanged = true;
            this.is_type4_multi_currency = is_type4_multi_currency;
            this.is_type4_multi_currencyChanged = true;
            this.is_type5_multi_currency = is_type5_multi_currency;
            this.is_type5_multi_currencyChanged = true;
            this.is_type6_multi_currency = is_type6_multi_currency;
            this.is_type6_multi_currencyChanged = true;
            this.is_type7_multi_currency = is_type7_multi_currency;
            this.is_type7_multi_currencyChanged = true;
            this.is_type1_recycler = is_type1_recycler;
            this.is_type1_recyclerChanged = true;
            this.is_type2_recycler = is_type2_recycler;
            this.is_type2_recyclerChanged = true;
            this.is_type3_recycler = is_type3_recycler;
            this.is_type3_recyclerChanged = true;
            this.is_type4_recycler = is_type4_recycler;
            this.is_type4_recyclerChanged = true;
            this.is_type5_recycler = is_type5_recycler;
            this.is_type5_recyclerChanged = true;
            this.is_type6_recycler = is_type6_recycler;
            this.is_type6_recyclerChanged = true;
            this.is_type7_recycler = is_type7_recycler;
            this.is_type7_recyclerChanged = true;
        }
        private NoteSetType(int region_id, string note_set_type_name, int? denomination_type_1, int? denomination_type_2, int? denomination_type_3, int? denomination_type_4, int? denomination_type_5, int? denomination_type_6, int? denomination_type_7, int note_set_type_id, int created_by, string denomination_type_1_title, string denomination_type_2_title, string denomination_type_3_title, string denomination_type_4_title, string denomination_type_5_title, string denomination_type_6_title, string denomination_type_7_title, DateTime creation_time, bool? is_type1_multi_currency, bool? is_type2_multi_currency, bool? is_type3_multi_currency, bool? is_type4_multi_currency, bool? is_type5_multi_currency, bool? is_type6_multi_currency, bool? is_type7_multi_currency, bool is_type1_recycler, bool is_type2_recycler, bool is_type3_recycler, bool is_type4_recycler, bool is_type5_recycler, bool is_type6_recycler, bool is_type7_recycler)
        {
            this.region_id = region_id;
            this.region_idChanged = true;
            this.note_set_type_name = note_set_type_name;
            this.note_set_type_nameChanged = true;
            this.denomination_type_1 = denomination_type_1;
            this.denomination_type_1Changed = true;
            this.denomination_type_2 = denomination_type_2;
            this.denomination_type_2Changed = true;
            this.denomination_type_3 = denomination_type_3;
            this.denomination_type_3Changed = true;
            this.denomination_type_4 = denomination_type_4;
            this.denomination_type_4Changed = true;
            this.denomination_type_5 = denomination_type_5;
            this.denomination_type_5Changed = true;
            this.denomination_type_6 = denomination_type_6;
            this.denomination_type_6Changed = true;
            this.denomination_type_7 = denomination_type_7;
            this.denomination_type_7Changed = true;
            this.note_set_type_id = note_set_type_id;
            this.note_set_type_idChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.denomination_type_1_title = denomination_type_1_title;
            this.denomination_type_1_titleChanged = true;
            this.denomination_type_2_title = denomination_type_2_title;
            this.denomination_type_2_titleChanged = true;
            this.denomination_type_3_title = denomination_type_3_title;
            this.denomination_type_3_titleChanged = true;
            this.denomination_type_4_title = denomination_type_4_title;
            this.denomination_type_4_titleChanged = true;
            this.denomination_type_5_title = denomination_type_5_title;
            this.denomination_type_5_titleChanged = true;
            this.denomination_type_6_title = denomination_type_6_title;
            this.denomination_type_6_titleChanged = true;
            this.denomination_type_7_title = denomination_type_7_title;
            this.denomination_type_7_titleChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.is_type1_multi_currency = is_type1_multi_currency;
            this.is_type1_multi_currencyChanged = true;
            this.is_type2_multi_currency = is_type2_multi_currency;
            this.is_type2_multi_currencyChanged = true;
            this.is_type3_multi_currency = is_type3_multi_currency;
            this.is_type3_multi_currencyChanged = true;
            this.is_type4_multi_currency = is_type4_multi_currency;
            this.is_type4_multi_currencyChanged = true;
            this.is_type5_multi_currency = is_type5_multi_currency;
            this.is_type5_multi_currencyChanged = true;
            this.is_type6_multi_currency = is_type6_multi_currency;
            this.is_type6_multi_currencyChanged = true;
            this.is_type7_multi_currency = is_type7_multi_currency;
            this.is_type7_multi_currencyChanged = true;
            this.is_type1_recycler = is_type1_recycler;
            this.is_type1_recyclerChanged = true;
            this.is_type2_recycler = is_type2_recycler;
            this.is_type2_recyclerChanged = true;
            this.is_type3_recycler = is_type3_recycler;
            this.is_type3_recyclerChanged = true;
            this.is_type4_recycler = is_type4_recycler;
            this.is_type4_recyclerChanged = true;
            this.is_type5_recycler = is_type5_recycler;
            this.is_type5_recyclerChanged = true;
            this.is_type6_recycler = is_type6_recycler;
            this.is_type6_recyclerChanged = true;
            this.is_type7_recycler = is_type7_recycler;
            this.is_type7_recyclerChanged = true;
        }

        #region members and properties for columns

        #region RegionId
        private bool region_idChanged = false;
        private int region_id;
        public int RegionId
        {
            get { return region_id; }
            set
            {
                region_id = value;
                region_idChanged = true;
            }
        }
        private string region_idDbString
        {
            get
            {
                return region_id.ToString();
            }
        }
        #endregion
        #region NoteSetTypeName
        private bool note_set_type_nameChanged = false;
        private string note_set_type_name;
        public string NoteSetTypeName
        {
            get { return note_set_type_name; }
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
                if (this.note_set_type_name != null)
                    return string.Format("'{0}'", note_set_type_name);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType1
        private bool denomination_type_1Changed = false;
        private int? denomination_type_1;
        public int? DenominationType1
        {
            get { return denomination_type_1; }
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
                if (this.denomination_type_1.HasValue)
                    return denomination_type_1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType2
        private bool denomination_type_2Changed = false;
        private int? denomination_type_2;
        public int? DenominationType2
        {
            get { return denomination_type_2; }
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
                if (this.denomination_type_2.HasValue)
                    return denomination_type_2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType3
        private bool denomination_type_3Changed = false;
        private int? denomination_type_3;
        public int? DenominationType3
        {
            get { return denomination_type_3; }
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
                if (this.denomination_type_3.HasValue)
                    return denomination_type_3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType4
        private bool denomination_type_4Changed = false;
        private int? denomination_type_4;
        public int? DenominationType4
        {
            get { return denomination_type_4; }
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
                if (this.denomination_type_4.HasValue)
                    return denomination_type_4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType5
        private bool denomination_type_5Changed = false;
        private int? denomination_type_5;
        public int? DenominationType5
        {
            get { return denomination_type_5; }
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
                if (this.denomination_type_5.HasValue)
                    return denomination_type_5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType6
        private bool denomination_type_6Changed = false;
        private int? denomination_type_6;
        public int? DenominationType6
        {
            get { return denomination_type_6; }
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
                if (this.denomination_type_6.HasValue)
                    return denomination_type_6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType7
        private bool denomination_type_7Changed = false;
        private int? denomination_type_7;
        public int? DenominationType7
        {
            get { return denomination_type_7; }
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
                if (this.denomination_type_7.HasValue)
                    return denomination_type_7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NoteSetTypeId
        private bool note_set_type_idChanged = false;
        private int note_set_type_id;
        public int NoteSetTypeId
        {
            get { return note_set_type_id; }
            set
            {
                note_set_type_id = value;
                note_set_type_idChanged = true;
            }
        }
        private string note_set_type_idDbString
        {
            get
            {
                return note_set_type_id.ToString();
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private int created_by;
        public int CreatedBy
        {
            get { return created_by; }
            set
            {
                created_by = value;
                created_byChanged = true;
            }
        }
        private string created_byDbString
        {
            get
            {
                return created_by.ToString();
            }
        }
        #endregion
        #region DenominationType1Title
        private bool denomination_type_1_titleChanged = false;
        private string denomination_type_1_title;
        public string DenominationType1Title
        {
            get { return denomination_type_1_title; }
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
                if (this.denomination_type_1_title != null)
                    return string.Format("'{0}'", denomination_type_1_title);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType2Title
        private bool denomination_type_2_titleChanged = false;
        private string denomination_type_2_title;
        public string DenominationType2Title
        {
            get { return denomination_type_2_title; }
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
                if (this.denomination_type_2_title != null)
                    return string.Format("'{0}'", denomination_type_2_title);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType3Title
        private bool denomination_type_3_titleChanged = false;
        private string denomination_type_3_title;
        public string DenominationType3Title
        {
            get { return denomination_type_3_title; }
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
                if (this.denomination_type_3_title != null)
                    return string.Format("'{0}'", denomination_type_3_title);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType4Title
        private bool denomination_type_4_titleChanged = false;
        private string denomination_type_4_title;
        public string DenominationType4Title
        {
            get { return denomination_type_4_title; }
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
                if (this.denomination_type_4_title != null)
                    return string.Format("'{0}'", denomination_type_4_title);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType5Title
        private bool denomination_type_5_titleChanged = false;
        private string denomination_type_5_title;
        public string DenominationType5Title
        {
            get { return denomination_type_5_title; }
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
                if (this.denomination_type_5_title != null)
                    return string.Format("'{0}'", denomination_type_5_title);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType6Title
        private bool denomination_type_6_titleChanged = false;
        private string denomination_type_6_title;
        public string DenominationType6Title
        {
            get { return denomination_type_6_title; }
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
                if (this.denomination_type_6_title != null)
                    return string.Format("'{0}'", denomination_type_6_title);
                else
                    return "null";
            }
        }
        #endregion
        #region DenominationType7Title
        private bool denomination_type_7_titleChanged = false;
        private string denomination_type_7_title;
        public string DenominationType7Title
        {
            get { return denomination_type_7_title; }
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
                if (this.denomination_type_7_title != null)
                    return string.Format("'{0}'", denomination_type_7_title);
                else
                    return "null";
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
        #region IsType1MultiCurrency
        private bool is_type1_multi_currencyChanged = false;
        private bool? is_type1_multi_currency;
        public bool? IsType1MultiCurrency
        {
            get { return is_type1_multi_currency; }
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
                if (this.is_type1_multi_currency.HasValue)
                    return is_type1_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType2MultiCurrency
        private bool is_type2_multi_currencyChanged = false;
        private bool? is_type2_multi_currency;
        public bool? IsType2MultiCurrency
        {
            get { return is_type2_multi_currency; }
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
                if (this.is_type2_multi_currency.HasValue)
                    return is_type2_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType3MultiCurrency
        private bool is_type3_multi_currencyChanged = false;
        private bool? is_type3_multi_currency;
        public bool? IsType3MultiCurrency
        {
            get { return is_type3_multi_currency; }
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
                if (this.is_type3_multi_currency.HasValue)
                    return is_type3_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType4MultiCurrency
        private bool is_type4_multi_currencyChanged = false;
        private bool? is_type4_multi_currency;
        public bool? IsType4MultiCurrency
        {
            get { return is_type4_multi_currency; }
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
                if (this.is_type4_multi_currency.HasValue)
                    return is_type4_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType5MultiCurrency
        private bool is_type5_multi_currencyChanged = false;
        private bool? is_type5_multi_currency;
        public bool? IsType5MultiCurrency
        {
            get { return is_type5_multi_currency; }
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
                if (this.is_type5_multi_currency.HasValue)
                    return is_type5_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType6MultiCurrency
        private bool is_type6_multi_currencyChanged = false;
        private bool? is_type6_multi_currency;
        public bool? IsType6MultiCurrency
        {
            get { return is_type6_multi_currency; }
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
                if (this.is_type6_multi_currency.HasValue)
                    return is_type6_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType7MultiCurrency
        private bool is_type7_multi_currencyChanged = false;
        private bool? is_type7_multi_currency;
        public bool? IsType7MultiCurrency
        {
            get { return is_type7_multi_currency; }
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
                if (this.is_type7_multi_currency.HasValue)
                    return is_type7_multi_currency.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsType1Recycler
        private bool is_type1_recyclerChanged = false;
        private bool is_type1_recycler;
        public bool IsType1Recycler
        {
            get { return is_type1_recycler; }
            set
            {
                is_type1_recycler = value;
                is_type1_recyclerChanged = true;
            }
        }
        private string is_type1_recyclerDbString
        {
            get
            {
                return is_type1_recycler ? "1" : "0";
            }
        }
        #endregion
        #region IsType2Recycler
        private bool is_type2_recyclerChanged = false;
        private bool is_type2_recycler;
        public bool IsType2Recycler
        {
            get { return is_type2_recycler; }
            set
            {
                is_type2_recycler = value;
                is_type2_recyclerChanged = true;
            }
        }
        private string is_type2_recyclerDbString
        {
            get
            {
                return is_type2_recycler ? "1" : "0";
            }
        }
        #endregion
        #region IsType3Recycler
        private bool is_type3_recyclerChanged = false;
        private bool is_type3_recycler;
        public bool IsType3Recycler
        {
            get { return is_type3_recycler; }
            set
            {
                is_type3_recycler = value;
                is_type3_recyclerChanged = true;
            }
        }
        private string is_type3_recyclerDbString
        {
            get
            {
                return is_type3_recycler ? "1" : "0";
            }
        }
        #endregion
        #region IsType4Recycler
        private bool is_type4_recyclerChanged = false;
        private bool is_type4_recycler;
        public bool IsType4Recycler
        {
            get { return is_type4_recycler; }
            set
            {
                is_type4_recycler = value;
                is_type4_recyclerChanged = true;
            }
        }
        private string is_type4_recyclerDbString
        {
            get
            {
                return is_type4_recycler ? "1" : "0";
            }
        }
        #endregion
        #region IsType5Recycler
        private bool is_type5_recyclerChanged = false;
        private bool is_type5_recycler;
        public bool IsType5Recycler
        {
            get { return is_type5_recycler; }
            set
            {
                is_type5_recycler = value;
                is_type5_recyclerChanged = true;
            }
        }
        private string is_type5_recyclerDbString
        {
            get
            {
                return is_type5_recycler ? "1" : "0";
            }
        }
        #endregion
        #region IsType6Recycler
        private bool is_type6_recyclerChanged = false;
        private bool is_type6_recycler;
        public bool IsType6Recycler
        {
            get { return is_type6_recycler; }
            set
            {
                is_type6_recycler = value;
                is_type6_recyclerChanged = true;
            }
        }
        private string is_type6_recyclerDbString
        {
            get
            {
                return is_type6_recycler ? "1" : "0";
            }
        }
        #endregion
        #region IsType7Recycler
        private bool is_type7_recyclerChanged = false;
        private bool is_type7_recycler;
        public bool IsType7Recycler
        {
            get { return is_type7_recycler; }
            set
            {
                is_type7_recycler = value;
                is_type7_recyclerChanged = true;
            }
        }
        private string is_type7_recyclerDbString
        {
            get
            {
                return is_type7_recycler ? "1" : "0";
            }
        }
        #endregion
        #endregion

        #region NoteSetTypeReader
        public class NoteSetTypeReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            NoteSetType currentNoteSetType;
            Columns columns;
            bool partialRead = false;
            private NoteSetTypeReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
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
                get { return currentNoteSetType; }

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
                    currentNoteSetType = new NoteSetType();
                    if (partialRead)
                    {
                        if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"] != DBNull.Value)
                            currentNoteSetType.region_id = (int)reader["region_id"];
                        if ((columns & Columns.note_set_type_name) == Columns.note_set_type_name && reader["note_set_type_name"] != DBNull.Value)
                            currentNoteSetType.note_set_type_name = (string)reader["note_set_type_name"];
                        if ((columns & Columns.denomination_type_1) == Columns.denomination_type_1 && reader["denomination_type_1"] != DBNull.Value)
                            currentNoteSetType.denomination_type_1 = (int?)reader["denomination_type_1"];
                        if ((columns & Columns.denomination_type_2) == Columns.denomination_type_2 && reader["denomination_type_2"] != DBNull.Value)
                            currentNoteSetType.denomination_type_2 = (int?)reader["denomination_type_2"];
                        if ((columns & Columns.denomination_type_3) == Columns.denomination_type_3 && reader["denomination_type_3"] != DBNull.Value)
                            currentNoteSetType.denomination_type_3 = (int?)reader["denomination_type_3"];
                        if ((columns & Columns.denomination_type_4) == Columns.denomination_type_4 && reader["denomination_type_4"] != DBNull.Value)
                            currentNoteSetType.denomination_type_4 = (int?)reader["denomination_type_4"];
                        if ((columns & Columns.denomination_type_5) == Columns.denomination_type_5 && reader["denomination_type_5"] != DBNull.Value)
                            currentNoteSetType.denomination_type_5 = (int?)reader["denomination_type_5"];
                        if ((columns & Columns.denomination_type_6) == Columns.denomination_type_6 && reader["denomination_type_6"] != DBNull.Value)
                            currentNoteSetType.denomination_type_6 = (int?)reader["denomination_type_6"];
                        if ((columns & Columns.denomination_type_7) == Columns.denomination_type_7 && reader["denomination_type_7"] != DBNull.Value)
                            currentNoteSetType.denomination_type_7 = (int?)reader["denomination_type_7"];
                        if ((columns & Columns.note_set_type_id) == Columns.note_set_type_id && reader["note_set_type_id"] != DBNull.Value)
                            currentNoteSetType.note_set_type_id = (int)reader["note_set_type_id"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentNoteSetType.created_by = (int)reader["created_by"];
                        if ((columns & Columns.denomination_type_1_title) == Columns.denomination_type_1_title && reader["denomination_type_1_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_1_title = (string)reader["denomination_type_1_title"];
                        if ((columns & Columns.denomination_type_2_title) == Columns.denomination_type_2_title && reader["denomination_type_2_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_2_title = (string)reader["denomination_type_2_title"];
                        if ((columns & Columns.denomination_type_3_title) == Columns.denomination_type_3_title && reader["denomination_type_3_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_3_title = (string)reader["denomination_type_3_title"];
                        if ((columns & Columns.denomination_type_4_title) == Columns.denomination_type_4_title && reader["denomination_type_4_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_4_title = (string)reader["denomination_type_4_title"];
                        if ((columns & Columns.denomination_type_5_title) == Columns.denomination_type_5_title && reader["denomination_type_5_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_5_title = (string)reader["denomination_type_5_title"];
                        if ((columns & Columns.denomination_type_6_title) == Columns.denomination_type_6_title && reader["denomination_type_6_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_6_title = (string)reader["denomination_type_6_title"];
                        if ((columns & Columns.denomination_type_7_title) == Columns.denomination_type_7_title && reader["denomination_type_7_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_7_title = (string)reader["denomination_type_7_title"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentNoteSetType.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.is_type1_multi_currency) == Columns.is_type1_multi_currency && reader["is_type1_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type1_multi_currency = (bool?)reader["is_type1_multi_currency"];
                        if ((columns & Columns.is_type2_multi_currency) == Columns.is_type2_multi_currency && reader["is_type2_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type2_multi_currency = (bool?)reader["is_type2_multi_currency"];
                        if ((columns & Columns.is_type3_multi_currency) == Columns.is_type3_multi_currency && reader["is_type3_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type3_multi_currency = (bool?)reader["is_type3_multi_currency"];
                        if ((columns & Columns.is_type4_multi_currency) == Columns.is_type4_multi_currency && reader["is_type4_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type4_multi_currency = (bool?)reader["is_type4_multi_currency"];
                        if ((columns & Columns.is_type5_multi_currency) == Columns.is_type5_multi_currency && reader["is_type5_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type5_multi_currency = (bool?)reader["is_type5_multi_currency"];
                        if ((columns & Columns.is_type6_multi_currency) == Columns.is_type6_multi_currency && reader["is_type6_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type6_multi_currency = (bool?)reader["is_type6_multi_currency"];
                        if ((columns & Columns.is_type7_multi_currency) == Columns.is_type7_multi_currency && reader["is_type7_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type7_multi_currency = (bool?)reader["is_type7_multi_currency"];
                        if ((columns & Columns.is_type1_recycler) == Columns.is_type1_recycler && reader["is_type1_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type1_recycler = (bool)reader["is_type1_recycler"];
                        if ((columns & Columns.is_type2_recycler) == Columns.is_type2_recycler && reader["is_type2_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type2_recycler = (bool)reader["is_type2_recycler"];
                        if ((columns & Columns.is_type3_recycler) == Columns.is_type3_recycler && reader["is_type3_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type3_recycler = (bool)reader["is_type3_recycler"];
                        if ((columns & Columns.is_type4_recycler) == Columns.is_type4_recycler && reader["is_type4_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type4_recycler = (bool)reader["is_type4_recycler"];
                        if ((columns & Columns.is_type5_recycler) == Columns.is_type5_recycler && reader["is_type5_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type5_recycler = (bool)reader["is_type5_recycler"];
                        if ((columns & Columns.is_type6_recycler) == Columns.is_type6_recycler && reader["is_type6_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type6_recycler = (bool)reader["is_type6_recycler"];
                        if ((columns & Columns.is_type7_recycler) == Columns.is_type7_recycler && reader["is_type7_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type7_recycler = (bool)reader["is_type7_recycler"];

                    }
                    else
                    {
                        if (reader["region_id"] != DBNull.Value)
                            currentNoteSetType.region_id = (int)reader["region_id"];
                        if (reader["note_set_type_name"] != DBNull.Value)
                            currentNoteSetType.note_set_type_name = (string)reader["note_set_type_name"];
                        if (reader["denomination_type_1"] != DBNull.Value)
                            currentNoteSetType.denomination_type_1 = (int?)reader["denomination_type_1"];
                        if (reader["denomination_type_2"] != DBNull.Value)
                            currentNoteSetType.denomination_type_2 = (int?)reader["denomination_type_2"];
                        if (reader["denomination_type_3"] != DBNull.Value)
                            currentNoteSetType.denomination_type_3 = (int?)reader["denomination_type_3"];
                        if (reader["denomination_type_4"] != DBNull.Value)
                            currentNoteSetType.denomination_type_4 = (int?)reader["denomination_type_4"];
                        if (reader["denomination_type_5"] != DBNull.Value)
                            currentNoteSetType.denomination_type_5 = (int?)reader["denomination_type_5"];
                        if (reader["denomination_type_6"] != DBNull.Value)
                            currentNoteSetType.denomination_type_6 = (int?)reader["denomination_type_6"];
                        if (reader["denomination_type_7"] != DBNull.Value)
                            currentNoteSetType.denomination_type_7 = (int?)reader["denomination_type_7"];
                        if (reader["note_set_type_id"] != DBNull.Value)
                            currentNoteSetType.note_set_type_id = (int)reader["note_set_type_id"];
                        if (reader["created_by"] != DBNull.Value)
                            currentNoteSetType.created_by = (int)reader["created_by"];
                        if (reader["denomination_type_1_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_1_title = (string)reader["denomination_type_1_title"];
                        if (reader["denomination_type_2_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_2_title = (string)reader["denomination_type_2_title"];
                        if (reader["denomination_type_3_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_3_title = (string)reader["denomination_type_3_title"];
                        if (reader["denomination_type_4_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_4_title = (string)reader["denomination_type_4_title"];
                        if (reader["denomination_type_5_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_5_title = (string)reader["denomination_type_5_title"];
                        if (reader["denomination_type_6_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_6_title = (string)reader["denomination_type_6_title"];
                        if (reader["denomination_type_7_title"] != DBNull.Value)
                            currentNoteSetType.denomination_type_7_title = (string)reader["denomination_type_7_title"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentNoteSetType.creation_time = (DateTime)reader["creation_time"];
                        if (reader["is_type1_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type1_multi_currency = (bool?)reader["is_type1_multi_currency"];
                        if (reader["is_type2_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type2_multi_currency = (bool?)reader["is_type2_multi_currency"];
                        if (reader["is_type3_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type3_multi_currency = (bool?)reader["is_type3_multi_currency"];
                        if (reader["is_type4_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type4_multi_currency = (bool?)reader["is_type4_multi_currency"];
                        if (reader["is_type5_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type5_multi_currency = (bool?)reader["is_type5_multi_currency"];
                        if (reader["is_type6_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type6_multi_currency = (bool?)reader["is_type6_multi_currency"];
                        if (reader["is_type7_multi_currency"] != DBNull.Value)
                            currentNoteSetType.is_type7_multi_currency = (bool?)reader["is_type7_multi_currency"];
                        if (reader["is_type1_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type1_recycler = (bool)reader["is_type1_recycler"];
                        if (reader["is_type2_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type2_recycler = (bool)reader["is_type2_recycler"];
                        if (reader["is_type3_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type3_recycler = (bool)reader["is_type3_recycler"];
                        if (reader["is_type4_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type4_recycler = (bool)reader["is_type4_recycler"];
                        if (reader["is_type5_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type5_recycler = (bool)reader["is_type5_recycler"];
                        if (reader["is_type6_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type6_recycler = (bool)reader["is_type6_recycler"];
                        if (reader["is_type7_recycler"] != DBNull.Value)
                            currentNoteSetType.is_type7_recycler = (bool)reader["is_type7_recycler"];
                    }

                    currentNoteSetType.isNewEntity = false;
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

            public NoteSetType CurrentNoteSetType
            {
                get { return currentNoteSetType; }
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


        #region NoteSetType functions

        public static NoteSetTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.region_id == (Columns.region_id & columns))
                qry.Append("region_id,");
            if (Columns.note_set_type_name == (Columns.note_set_type_name & columns))
                qry.Append("note_set_type_name,");
            if (Columns.denomination_type_1 == (Columns.denomination_type_1 & columns))
                qry.Append("denomination_type_1,");
            if (Columns.denomination_type_2 == (Columns.denomination_type_2 & columns))
                qry.Append("denomination_type_2,");
            if (Columns.denomination_type_3 == (Columns.denomination_type_3 & columns))
                qry.Append("denomination_type_3,");
            if (Columns.denomination_type_4 == (Columns.denomination_type_4 & columns))
                qry.Append("denomination_type_4,");
            if (Columns.denomination_type_5 == (Columns.denomination_type_5 & columns))
                qry.Append("denomination_type_5,");
            if (Columns.denomination_type_6 == (Columns.denomination_type_6 & columns))
                qry.Append("denomination_type_6,");
            if (Columns.denomination_type_7 == (Columns.denomination_type_7 & columns))
                qry.Append("denomination_type_7,");
            if (Columns.note_set_type_id == (Columns.note_set_type_id & columns))
                qry.Append("note_set_type_id,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.denomination_type_1_title == (Columns.denomination_type_1_title & columns))
                qry.Append("denomination_type_1_title,");
            if (Columns.denomination_type_2_title == (Columns.denomination_type_2_title & columns))
                qry.Append("denomination_type_2_title,");
            if (Columns.denomination_type_3_title == (Columns.denomination_type_3_title & columns))
                qry.Append("denomination_type_3_title,");
            if (Columns.denomination_type_4_title == (Columns.denomination_type_4_title & columns))
                qry.Append("denomination_type_4_title,");
            if (Columns.denomination_type_5_title == (Columns.denomination_type_5_title & columns))
                qry.Append("denomination_type_5_title,");
            if (Columns.denomination_type_6_title == (Columns.denomination_type_6_title & columns))
                qry.Append("denomination_type_6_title,");
            if (Columns.denomination_type_7_title == (Columns.denomination_type_7_title & columns))
                qry.Append("denomination_type_7_title,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.is_type1_multi_currency == (Columns.is_type1_multi_currency & columns))
                qry.Append("is_type1_multi_currency,");
            if (Columns.is_type2_multi_currency == (Columns.is_type2_multi_currency & columns))
                qry.Append("is_type2_multi_currency,");
            if (Columns.is_type3_multi_currency == (Columns.is_type3_multi_currency & columns))
                qry.Append("is_type3_multi_currency,");
            if (Columns.is_type4_multi_currency == (Columns.is_type4_multi_currency & columns))
                qry.Append("is_type4_multi_currency,");
            if (Columns.is_type5_multi_currency == (Columns.is_type5_multi_currency & columns))
                qry.Append("is_type5_multi_currency,");
            if (Columns.is_type6_multi_currency == (Columns.is_type6_multi_currency & columns))
                qry.Append("is_type6_multi_currency,");
            if (Columns.is_type7_multi_currency == (Columns.is_type7_multi_currency & columns))
                qry.Append("is_type7_multi_currency,");
            if (Columns.is_type1_recycler == (Columns.is_type1_recycler & columns))
                qry.Append("is_type1_recycler,");
            if (Columns.is_type2_recycler == (Columns.is_type2_recycler & columns))
                qry.Append("is_type2_recycler,");
            if (Columns.is_type3_recycler == (Columns.is_type3_recycler & columns))
                qry.Append("is_type3_recycler,");
            if (Columns.is_type4_recycler == (Columns.is_type4_recycler & columns))
                qry.Append("is_type4_recycler,");
            if (Columns.is_type5_recycler == (Columns.is_type5_recycler & columns))
                qry.Append("is_type5_recycler,");
            if (Columns.is_type6_recycler == (Columns.is_type6_recycler & columns))
                qry.Append("is_type6_recycler,");
            if (Columns.is_type7_recycler == (Columns.is_type7_recycler & columns))
                qry.Append("is_type7_recycler,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Note_set_type ");

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
            return new NoteSetTypeReader(cmd.ExecuteReader(), conn, columns);
        }

        static public NoteSetTypeReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static NoteSetTypeReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select region_id,note_set_type_name,denomination_type_1,denomination_type_2,denomination_type_3,denomination_type_4,denomination_type_5,denomination_type_6,denomination_type_7,note_set_type_id,created_by,denomination_type_1_title,denomination_type_2_title,denomination_type_3_title,denomination_type_4_title,denomination_type_5_title,denomination_type_6_title,denomination_type_7_title,creation_time,is_type1_multi_currency,is_type2_multi_currency,is_type3_multi_currency,is_type4_multi_currency,is_type5_multi_currency,is_type6_multi_currency,is_type7_multi_currency,is_type1_recycler,is_type2_recycler,is_type3_recycler,is_type4_recycler,is_type5_recycler,is_type6_recycler,is_type7_recycler from Note_set_type ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new NoteSetTypeReader(cmd.ExecuteReader(), conn);
        }

        static public NoteSetTypeReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static NoteSetType LoadNoteSetType(string where)
        {
            NoteSetTypeReader reader = NoteSetType.ExecuteReader(where);
            NoteSetType _notesettype = null;
            if (reader.Read())
                _notesettype = reader.CurrentNoteSetType;
            reader.Close();
            return _notesettype;
        }

        public static NoteSetType LoadNoteSetType(string where, IDbConnection conn)
        {
            NoteSetTypeReader reader = NoteSetType.ExecuteReader(where, conn);
            NoteSetType _notesettype = null;
            if (reader.Read())
                _notesettype = reader.CurrentNoteSetType;
            reader.Close(false);
            return _notesettype;
        }

        public static NoteSetType LoadNoteSetTypeByPk(int note_set_type_id)
        {
            return LoadNoteSetType("note_set_type_id=" + note_set_type_id);
        }

        public static NoteSetType LoadNoteSetTypeByPk(int note_set_type_id, IDbConnection conn)
        {
            return LoadNoteSetType(" note_set_type_id=" + note_set_type_id, conn);
        }

        public void Save()
        {
            if (region_idChanged || note_set_type_nameChanged || denomination_type_1Changed || denomination_type_2Changed || denomination_type_3Changed || denomination_type_4Changed || denomination_type_5Changed || denomination_type_6Changed || denomination_type_7Changed || note_set_type_idChanged || created_byChanged || denomination_type_1_titleChanged || denomination_type_2_titleChanged || denomination_type_3_titleChanged || denomination_type_4_titleChanged || denomination_type_5_titleChanged || denomination_type_6_titleChanged || denomination_type_7_titleChanged || creation_timeChanged || is_type1_multi_currencyChanged || is_type2_multi_currencyChanged || is_type3_multi_currencyChanged || is_type4_multi_currencyChanged || is_type5_multi_currencyChanged || is_type6_multi_currencyChanged || is_type7_multi_currencyChanged || is_type1_recyclerChanged || is_type2_recyclerChanged || is_type3_recyclerChanged || is_type4_recyclerChanged || is_type5_recyclerChanged || is_type6_recyclerChanged || is_type7_recyclerChanged)
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
            if (region_idChanged || note_set_type_nameChanged || denomination_type_1Changed || denomination_type_2Changed || denomination_type_3Changed || denomination_type_4Changed || denomination_type_5Changed || denomination_type_6Changed || denomination_type_7Changed || note_set_type_idChanged || created_byChanged || denomination_type_1_titleChanged || denomination_type_2_titleChanged || denomination_type_3_titleChanged || denomination_type_4_titleChanged || denomination_type_5_titleChanged || denomination_type_6_titleChanged || denomination_type_7_titleChanged || creation_timeChanged || is_type1_multi_currencyChanged || is_type2_multi_currencyChanged || is_type3_multi_currencyChanged || is_type4_multi_currencyChanged || is_type5_multi_currencyChanged || is_type6_multi_currencyChanged || is_type7_multi_currencyChanged || is_type1_recyclerChanged || is_type2_recyclerChanged || is_type3_recyclerChanged || is_type4_recyclerChanged || is_type5_recyclerChanged || is_type6_recyclerChanged || is_type7_recyclerChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Note_set_type(region_id,note_set_type_name,denomination_type_1,denomination_type_2,denomination_type_3,denomination_type_4,denomination_type_5,denomination_type_6,denomination_type_7,note_set_type_id,created_by,denomination_type_1_title,denomination_type_2_title,denomination_type_3_title,denomination_type_4_title,denomination_type_5_title,denomination_type_6_title,denomination_type_7_title,creation_time,is_type1_multi_currency,is_type2_multi_currency,is_type3_multi_currency,is_type4_multi_currency,is_type5_multi_currency,is_type6_multi_currency,is_type7_multi_currency,is_type1_recycler,is_type2_recycler,is_type3_recycler,is_type4_recycler,is_type5_recycler,is_type6_recycler,is_type7_recycler) values(");
                    qry.Append(region_idDbString + ",");
                    qry.Append(note_set_type_nameDbString + ",");
                    qry.Append(denomination_type_1DbString + ",");
                    qry.Append(denomination_type_2DbString + ",");
                    qry.Append(denomination_type_3DbString + ",");
                    qry.Append(denomination_type_4DbString + ",");
                    qry.Append(denomination_type_5DbString + ",");
                    qry.Append(denomination_type_6DbString + ",");
                    qry.Append(denomination_type_7DbString + ",");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.note_set_type_id = ConnectionFactory.GetNextId();
                        qry.Append(this.note_set_type_id);
                    } qry.Append(",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(denomination_type_1_titleDbString + ",");
                    qry.Append(denomination_type_2_titleDbString + ",");
                    qry.Append(denomination_type_3_titleDbString + ",");
                    qry.Append(denomination_type_4_titleDbString + ",");
                    qry.Append(denomination_type_5_titleDbString + ",");
                    qry.Append(denomination_type_6_titleDbString + ",");
                    qry.Append(denomination_type_7_titleDbString + ",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(is_type1_multi_currencyDbString + ",");
                    qry.Append(is_type2_multi_currencyDbString + ",");
                    qry.Append(is_type3_multi_currencyDbString + ",");
                    qry.Append(is_type4_multi_currencyDbString + ",");
                    qry.Append(is_type5_multi_currencyDbString + ",");
                    qry.Append(is_type6_multi_currencyDbString + ",");
                    qry.Append(is_type7_multi_currencyDbString + ",");
                    qry.Append(is_type1_recyclerDbString + ",");
                    qry.Append(is_type2_recyclerDbString + ",");
                    qry.Append(is_type3_recyclerDbString + ",");
                    qry.Append(is_type4_recyclerDbString + ",");
                    qry.Append(is_type5_recyclerDbString + ",");
                    qry.Append(is_type6_recyclerDbString + ",");
                    qry.Append(is_type7_recyclerDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(region_idChanged || note_set_type_nameChanged || denomination_type_1Changed || denomination_type_2Changed || denomination_type_3Changed || denomination_type_4Changed || denomination_type_5Changed || denomination_type_6Changed || denomination_type_7Changed || note_set_type_idChanged || created_byChanged || denomination_type_1_titleChanged || denomination_type_2_titleChanged || denomination_type_3_titleChanged || denomination_type_4_titleChanged || denomination_type_5_titleChanged || denomination_type_6_titleChanged || denomination_type_7_titleChanged || creation_timeChanged || is_type1_multi_currencyChanged || is_type2_multi_currencyChanged || is_type3_multi_currencyChanged || is_type4_multi_currencyChanged || is_type5_multi_currencyChanged || is_type6_multi_currencyChanged || is_type7_multi_currencyChanged || is_type1_recyclerChanged || is_type2_recyclerChanged || is_type3_recyclerChanged || is_type4_recyclerChanged || is_type5_recyclerChanged || is_type6_recyclerChanged || is_type7_recyclerChanged))
                        return;
                    qry.Append("UPDATE Note_set_type set "); if (region_idChanged)
                    {
                        qry.Append("region_id =" + region_idDbString);
                        qry.Append(",");
                    }

                    if (note_set_type_nameChanged)
                    {
                        qry.Append("note_set_type_name =" + note_set_type_nameDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_1Changed)
                    {
                        qry.Append("denomination_type_1 =" + denomination_type_1DbString);
                        qry.Append(",");
                    }

                    if (denomination_type_2Changed)
                    {
                        qry.Append("denomination_type_2 =" + denomination_type_2DbString);
                        qry.Append(",");
                    }

                    if (denomination_type_3Changed)
                    {
                        qry.Append("denomination_type_3 =" + denomination_type_3DbString);
                        qry.Append(",");
                    }

                    if (denomination_type_4Changed)
                    {
                        qry.Append("denomination_type_4 =" + denomination_type_4DbString);
                        qry.Append(",");
                    }

                    if (denomination_type_5Changed)
                    {
                        qry.Append("denomination_type_5 =" + denomination_type_5DbString);
                        qry.Append(",");
                    }

                    if (denomination_type_6Changed)
                    {
                        qry.Append("denomination_type_6 =" + denomination_type_6DbString);
                        qry.Append(",");
                    }

                    if (denomination_type_7Changed)
                    {
                        qry.Append("denomination_type_7 =" + denomination_type_7DbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_1_titleChanged)
                    {
                        qry.Append("denomination_type_1_title =" + denomination_type_1_titleDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_2_titleChanged)
                    {
                        qry.Append("denomination_type_2_title =" + denomination_type_2_titleDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_3_titleChanged)
                    {
                        qry.Append("denomination_type_3_title =" + denomination_type_3_titleDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_4_titleChanged)
                    {
                        qry.Append("denomination_type_4_title =" + denomination_type_4_titleDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_5_titleChanged)
                    {
                        qry.Append("denomination_type_5_title =" + denomination_type_5_titleDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_6_titleChanged)
                    {
                        qry.Append("denomination_type_6_title =" + denomination_type_6_titleDbString);
                        qry.Append(",");
                    }

                    if (denomination_type_7_titleChanged)
                    {
                        qry.Append("denomination_type_7_title =" + denomination_type_7_titleDbString);
                        qry.Append(",");
                    }

                    if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }

                    if (is_type1_multi_currencyChanged)
                    {
                        qry.Append("is_type1_multi_currency =" + is_type1_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type2_multi_currencyChanged)
                    {
                        qry.Append("is_type2_multi_currency =" + is_type2_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type3_multi_currencyChanged)
                    {
                        qry.Append("is_type3_multi_currency =" + is_type3_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type4_multi_currencyChanged)
                    {
                        qry.Append("is_type4_multi_currency =" + is_type4_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type5_multi_currencyChanged)
                    {
                        qry.Append("is_type5_multi_currency =" + is_type5_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type6_multi_currencyChanged)
                    {
                        qry.Append("is_type6_multi_currency =" + is_type6_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type7_multi_currencyChanged)
                    {
                        qry.Append("is_type7_multi_currency =" + is_type7_multi_currencyDbString);
                        qry.Append(",");
                    }

                    if (is_type1_recyclerChanged)
                    {
                        qry.Append("is_type1_recycler =" + is_type1_recyclerDbString);
                        qry.Append(",");
                    }

                    if (is_type2_recyclerChanged)
                    {
                        qry.Append("is_type2_recycler =" + is_type2_recyclerDbString);
                        qry.Append(",");
                    }

                    if (is_type3_recyclerChanged)
                    {
                        qry.Append("is_type3_recycler =" + is_type3_recyclerDbString);
                        qry.Append(",");
                    }

                    if (is_type4_recyclerChanged)
                    {
                        qry.Append("is_type4_recycler =" + is_type4_recyclerDbString);
                        qry.Append(",");
                    }

                    if (is_type5_recyclerChanged)
                    {
                        qry.Append("is_type5_recycler =" + is_type5_recyclerDbString);
                        qry.Append(",");
                    }

                    if (is_type6_recyclerChanged)
                    {
                        qry.Append("is_type6_recycler =" + is_type6_recyclerDbString);
                        qry.Append(",");
                    }

                    if (is_type7_recyclerChanged)
                    {
                        qry.Append("is_type7_recycler =" + is_type7_recyclerDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("note_set_type_id = " + note_set_type_idDbString);
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
            cmd.CommandText = "DELETE Note_set_type where note_set_type_id= " + note_set_type_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public void Delete(IDbConnection conn, IDbTransaction trxn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Note_set_type where   note_set_type_id = " + note_set_type_id;
            cmd.Transaction = trxn;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteNoteSetTypes(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Note_set_type where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            region_id = 1,
            note_set_type_name = 2,
            denomination_type_1 = 4,
            denomination_type_2 = 8,
            denomination_type_3 = 16,
            denomination_type_4 = 32,
            denomination_type_5 = 64,
            denomination_type_6 = 128,
            denomination_type_7 = 256,
            note_set_type_id = 512,
            created_by = 1024,
            denomination_type_1_title = 2048,
            denomination_type_2_title = 4096,
            denomination_type_3_title = 8192,
            denomination_type_4_title = 16384,
            denomination_type_5_title = 32768,
            denomination_type_6_title = 65536,
            denomination_type_7_title = 131072,
            creation_time = 262144,
            is_type1_multi_currency = 524288,
            is_type2_multi_currency = 1048576,
            is_type3_multi_currency = 2097152,
            is_type4_multi_currency = 4194304,
            is_type5_multi_currency = 8388608,
            is_type6_multi_currency = 16777216,
            is_type7_multi_currency = 33554432,
            is_type1_recycler = 67108864,
            is_type2_recycler = 134217728,
            is_type3_recycler = 268435456,
            is_type4_recycler = 536870912,
            is_type5_recycler = 1073741824,
            is_type6_recycler = 2147483648,
            is_type7_recycler = 4294967296
        }
        #endregion
        public DataTable BulkSave(List<NoteSetType> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Note_set_type";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(NoteSetType.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<NoteSetType> transList, ref DataTable dt)
        {
            foreach (NoteSetType tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["region_id"] = tran.RegionId;
                Row["note_set_type_name"] = tran.NoteSetTypeName;
                Row["denomination_type_1"] = tran.DenominationType1;
                Row["denomination_type_2"] = tran.DenominationType2;
                Row["denomination_type_3"] = tran.DenominationType3;
                Row["denomination_type_4"] = tran.DenominationType4;
                Row["denomination_type_5"] = tran.DenominationType5;
                Row["denomination_type_6"] = tran.DenominationType6;
                Row["denomination_type_7"] = tran.DenominationType7;
                Row["note_set_type_id"] = ConnectionFactory.GetNextId();
                Row["created_by"] = tran.CreatedBy;
                Row["denomination_type_1_title"] = tran.DenominationType1Title;
                Row["denomination_type_2_title"] = tran.DenominationType2Title;
                Row["denomination_type_3_title"] = tran.DenominationType3Title;
                Row["denomination_type_4_title"] = tran.DenominationType4Title;
                Row["denomination_type_5_title"] = tran.DenominationType5Title;
                Row["denomination_type_6_title"] = tran.DenominationType6Title;
                Row["denomination_type_7_title"] = tran.DenominationType7Title;
                Row["creation_time"] = tran.CreationTime;
                Row["is_type1_multi_currency"] = tran.IsType1MultiCurrency;
                Row["is_type2_multi_currency"] = tran.IsType2MultiCurrency;
                Row["is_type3_multi_currency"] = tran.IsType3MultiCurrency;
                Row["is_type4_multi_currency"] = tran.IsType4MultiCurrency;
                Row["is_type5_multi_currency"] = tran.IsType5MultiCurrency;
                Row["is_type6_multi_currency"] = tran.IsType6MultiCurrency;
                Row["is_type7_multi_currency"] = tran.IsType7MultiCurrency;
                Row["is_type1_recycler"] = tran.IsType1Recycler;
                Row["is_type2_recycler"] = tran.IsType2Recycler;
                Row["is_type3_recycler"] = tran.IsType3Recycler;
                Row["is_type4_recycler"] = tran.IsType4Recycler;
                Row["is_type5_recycler"] = tran.IsType5Recycler;
                Row["is_type6_recycler"] = tran.IsType6Recycler;
                Row["is_type7_recycler"] = tran.IsType7Recycler;
                dt.Rows.Add(Row);
            }
        }
    }
}