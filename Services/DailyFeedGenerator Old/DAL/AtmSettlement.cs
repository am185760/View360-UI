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
    public class AtmSettlement
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public AtmSettlement() { }
        public AtmSettlement(int? atm_settlement_id, int atm_settlement_info_id)
        {
            this.atm_settlement_info_id = atm_settlement_info_id;
            this.atm_settlement_info_idChanged = true;
        }
        public AtmSettlement(string gl_no, DateTime? rep_datetime, string seal_number, int? cash_rep_denomination_type1, int? cash_rep_counters_type1, int? cash_rep_denomination_type2, int? cash_rep_counters_type2, int? cash_rep_denomination_type3, int? cash_rep_counters_type3, int? cash_rep_denomination_type4, int? cash_rep_counters_type4, int? cash_return_denomination_type1, int? cash_return_counters_type1, int? cash_return_denomination_type2, int? cash_return_counters_type2, int? cash_return_denomination_type3, int? cash_return_counters_type3, int? cash_return_denomination_type4, int? cash_return_counters_type4, int? cash_dispensed_denomination_type1, int? cash_dispensed_counters_type1, int? cash_dispensed_denomination_type2, int? cash_dispensed_counters_type2, int? cash_dispensed_denomination_type3, int? cash_dispensed_counters_type3, int? cash_dispensed_denomination_type4, int? cash_dispensed_counters_type4, int? cash_rejected_denomination_type1, int? cash_rejected_counters_type1, int? cash_rejected_denomination_type2, int? cash_rejected_counters_type2, int? cash_rejected_denomination_type3, int? cash_rejected_counters_type3, int? cash_rejected_denomination_type4, int? cash_rejected_counters_type4, int? uploaded_by, DateTime? upload_datetime, string atm_site_and_number, decimal? total_replenished, DateTime? date_of_old_replenised, string location, int? atm_no, decimal? total_returned, int? cash_rem_denomination_type1, int? cash_rem_counters_type1, int? cash_rem_denomination_type2, int? cash_rem_counters_type2, int? cash_rem_denomination_type3, int? cash_rem_counters_type3, int? cash_rem_denomination_type4, int? cash_rem_counters_type4, DateTime? previous_rep_date, int? journal_no, decimal? total_rejected, int? modified_by, DateTime? modified_on, int atm_settlement_info_id, int? cash_dep_total_type1, int? cash_dep_total_type2, int? cash_dep_total_type3, int? cash_dep_total_type4)
        {
            this.gl_no = gl_no;
            this.gl_noChanged = true;
            this.rep_datetime = rep_datetime;
            this.rep_datetimeChanged = true;
            this.seal_number = seal_number;
            this.seal_numberChanged = true;
            this.cash_rep_denomination_type1 = cash_rep_denomination_type1;
            this.cash_rep_denomination_type1Changed = true;
            this.cash_rep_counters_type1 = cash_rep_counters_type1;
            this.cash_rep_counters_type1Changed = true;
            this.cash_rep_denomination_type2 = cash_rep_denomination_type2;
            this.cash_rep_denomination_type2Changed = true;
            this.cash_rep_counters_type2 = cash_rep_counters_type2;
            this.cash_rep_counters_type2Changed = true;
            this.cash_rep_denomination_type3 = cash_rep_denomination_type3;
            this.cash_rep_denomination_type3Changed = true;
            this.cash_rep_counters_type3 = cash_rep_counters_type3;
            this.cash_rep_counters_type3Changed = true;
            this.cash_rep_denomination_type4 = cash_rep_denomination_type4;
            this.cash_rep_denomination_type4Changed = true;
            this.cash_rep_counters_type4 = cash_rep_counters_type4;
            this.cash_rep_counters_type4Changed = true;
            this.cash_return_denomination_type1 = cash_return_denomination_type1;
            this.cash_return_denomination_type1Changed = true;
            this.cash_return_counters_type1 = cash_return_counters_type1;
            this.cash_return_counters_type1Changed = true;
            this.cash_return_denomination_type2 = cash_return_denomination_type2;
            this.cash_return_denomination_type2Changed = true;
            this.cash_return_counters_type2 = cash_return_counters_type2;
            this.cash_return_counters_type2Changed = true;
            this.cash_return_denomination_type3 = cash_return_denomination_type3;
            this.cash_return_denomination_type3Changed = true;
            this.cash_return_counters_type3 = cash_return_counters_type3;
            this.cash_return_counters_type3Changed = true;
            this.cash_return_denomination_type4 = cash_return_denomination_type4;
            this.cash_return_denomination_type4Changed = true;
            this.cash_return_counters_type4 = cash_return_counters_type4;
            this.cash_return_counters_type4Changed = true;
            this.cash_dispensed_denomination_type1 = cash_dispensed_denomination_type1;
            this.cash_dispensed_denomination_type1Changed = true;
            this.cash_dispensed_counters_type1 = cash_dispensed_counters_type1;
            this.cash_dispensed_counters_type1Changed = true;
            this.cash_dispensed_denomination_type2 = cash_dispensed_denomination_type2;
            this.cash_dispensed_denomination_type2Changed = true;
            this.cash_dispensed_counters_type2 = cash_dispensed_counters_type2;
            this.cash_dispensed_counters_type2Changed = true;
            this.cash_dispensed_denomination_type3 = cash_dispensed_denomination_type3;
            this.cash_dispensed_denomination_type3Changed = true;
            this.cash_dispensed_counters_type3 = cash_dispensed_counters_type3;
            this.cash_dispensed_counters_type3Changed = true;
            this.cash_dispensed_denomination_type4 = cash_dispensed_denomination_type4;
            this.cash_dispensed_denomination_type4Changed = true;
            this.cash_dispensed_counters_type4 = cash_dispensed_counters_type4;
            this.cash_dispensed_counters_type4Changed = true;
            this.cash_rejected_denomination_type1 = cash_rejected_denomination_type1;
            this.cash_rejected_denomination_type1Changed = true;
            this.cash_rejected_counters_type1 = cash_rejected_counters_type1;
            this.cash_rejected_counters_type1Changed = true;
            this.cash_rejected_denomination_type2 = cash_rejected_denomination_type2;
            this.cash_rejected_denomination_type2Changed = true;
            this.cash_rejected_counters_type2 = cash_rejected_counters_type2;
            this.cash_rejected_counters_type2Changed = true;
            this.cash_rejected_denomination_type3 = cash_rejected_denomination_type3;
            this.cash_rejected_denomination_type3Changed = true;
            this.cash_rejected_counters_type3 = cash_rejected_counters_type3;
            this.cash_rejected_counters_type3Changed = true;
            this.cash_rejected_denomination_type4 = cash_rejected_denomination_type4;
            this.cash_rejected_denomination_type4Changed = true;
            this.cash_rejected_counters_type4 = cash_rejected_counters_type4;
            this.cash_rejected_counters_type4Changed = true;
            this.uploaded_by = uploaded_by;
            this.uploaded_byChanged = true;
            this.upload_datetime = upload_datetime;
            this.upload_datetimeChanged = true;
            this.atm_site_and_number = atm_site_and_number;
            this.atm_site_and_numberChanged = true;
            this.total_replenished = total_replenished;
            this.total_replenishedChanged = true;
            this.date_of_old_replenised = date_of_old_replenised;
            this.date_of_old_replenisedChanged = true;
            this.location = location;
            this.locationChanged = true;
            this.atm_no = atm_no;
            this.atm_noChanged = true;
            this.total_returned = total_returned;
            this.total_returnedChanged = true;
            this.cash_rem_denomination_type1 = cash_rem_denomination_type1;
            this.cash_rem_denomination_type1Changed = true;
            this.cash_rem_counters_type1 = cash_rem_counters_type1;
            this.cash_rem_counters_type1Changed = true;
            this.cash_rem_denomination_type2 = cash_rem_denomination_type2;
            this.cash_rem_denomination_type2Changed = true;
            this.cash_rem_counters_type2 = cash_rem_counters_type2;
            this.cash_rem_counters_type2Changed = true;
            this.cash_rem_denomination_type3 = cash_rem_denomination_type3;
            this.cash_rem_denomination_type3Changed = true;
            this.cash_rem_counters_type3 = cash_rem_counters_type3;
            this.cash_rem_counters_type3Changed = true;
            this.cash_rem_denomination_type4 = cash_rem_denomination_type4;
            this.cash_rem_denomination_type4Changed = true;
            this.cash_rem_counters_type4 = cash_rem_counters_type4;
            this.cash_rem_counters_type4Changed = true;
            this.previous_rep_date = previous_rep_date;
            this.previous_rep_dateChanged = true;
            this.journal_no = journal_no;
            this.journal_noChanged = true;
            this.total_rejected = total_rejected;
            this.total_rejectedChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.modified_on = modified_on;
            this.modified_onChanged = true;
            this.atm_settlement_info_id = atm_settlement_info_id;
            this.atm_settlement_info_idChanged = true;
            this.cash_dep_total_type1 = cash_dep_total_type1;
            this.cash_dep_total_type1Changed = true;
            this.cash_dep_total_type2 = cash_dep_total_type2;
            this.cash_dep_total_type2Changed = true;
            this.cash_dep_total_type3 = cash_dep_total_type3;
            this.cash_dep_total_type3Changed = true;
            this.cash_dep_total_type4 = cash_dep_total_type4;
            this.cash_dep_total_type4Changed = true;
        }
        private AtmSettlement(string gl_no, DateTime? rep_datetime, string seal_number, int? cash_rep_denomination_type1, int? cash_rep_counters_type1, int? cash_rep_denomination_type2, int? cash_rep_counters_type2, int? cash_rep_denomination_type3, int? cash_rep_counters_type3, int? cash_rep_denomination_type4, int? cash_rep_counters_type4, int? cash_return_denomination_type1, int? cash_return_counters_type1, int? cash_return_denomination_type2, int? cash_return_counters_type2, int? cash_return_denomination_type3, int? cash_return_counters_type3, int? cash_return_denomination_type4, int? cash_return_counters_type4, int? cash_dispensed_denomination_type1, int? cash_dispensed_counters_type1, int? cash_dispensed_denomination_type2, int? cash_dispensed_counters_type2, int? cash_dispensed_denomination_type3, int? cash_dispensed_counters_type3, int? cash_dispensed_denomination_type4, int? cash_dispensed_counters_type4, int? cash_rejected_denomination_type1, int? cash_rejected_counters_type1, int? cash_rejected_denomination_type2, int? cash_rejected_counters_type2, int? cash_rejected_denomination_type3, int? cash_rejected_counters_type3, int? cash_rejected_denomination_type4, int? cash_rejected_counters_type4, int? atm_settlement_id, int? uploaded_by, DateTime? upload_datetime, string atm_site_and_number, decimal? total_replenished, DateTime? date_of_old_replenised, string location, int? atm_no, decimal? total_returned, int? cash_rem_denomination_type1, int? cash_rem_counters_type1, int? cash_rem_denomination_type2, int? cash_rem_counters_type2, int? cash_rem_denomination_type3, int? cash_rem_counters_type3, int? cash_rem_denomination_type4, int? cash_rem_counters_type4, DateTime? previous_rep_date, int? journal_no, decimal? total_rejected, int? modified_by, DateTime? modified_on, int atm_settlement_info_id, int? cash_dep_total_type1, int? cash_dep_total_type2, int? cash_dep_total_type3, int? cash_dep_total_type4)
        {
            this.gl_no = gl_no;
            this.gl_noChanged = true;
            this.rep_datetime = rep_datetime;
            this.rep_datetimeChanged = true;
            this.seal_number = seal_number;
            this.seal_numberChanged = true;
            this.cash_rep_denomination_type1 = cash_rep_denomination_type1;
            this.cash_rep_denomination_type1Changed = true;
            this.cash_rep_counters_type1 = cash_rep_counters_type1;
            this.cash_rep_counters_type1Changed = true;
            this.cash_rep_denomination_type2 = cash_rep_denomination_type2;
            this.cash_rep_denomination_type2Changed = true;
            this.cash_rep_counters_type2 = cash_rep_counters_type2;
            this.cash_rep_counters_type2Changed = true;
            this.cash_rep_denomination_type3 = cash_rep_denomination_type3;
            this.cash_rep_denomination_type3Changed = true;
            this.cash_rep_counters_type3 = cash_rep_counters_type3;
            this.cash_rep_counters_type3Changed = true;
            this.cash_rep_denomination_type4 = cash_rep_denomination_type4;
            this.cash_rep_denomination_type4Changed = true;
            this.cash_rep_counters_type4 = cash_rep_counters_type4;
            this.cash_rep_counters_type4Changed = true;
            this.cash_return_denomination_type1 = cash_return_denomination_type1;
            this.cash_return_denomination_type1Changed = true;
            this.cash_return_counters_type1 = cash_return_counters_type1;
            this.cash_return_counters_type1Changed = true;
            this.cash_return_denomination_type2 = cash_return_denomination_type2;
            this.cash_return_denomination_type2Changed = true;
            this.cash_return_counters_type2 = cash_return_counters_type2;
            this.cash_return_counters_type2Changed = true;
            this.cash_return_denomination_type3 = cash_return_denomination_type3;
            this.cash_return_denomination_type3Changed = true;
            this.cash_return_counters_type3 = cash_return_counters_type3;
            this.cash_return_counters_type3Changed = true;
            this.cash_return_denomination_type4 = cash_return_denomination_type4;
            this.cash_return_denomination_type4Changed = true;
            this.cash_return_counters_type4 = cash_return_counters_type4;
            this.cash_return_counters_type4Changed = true;
            this.cash_dispensed_denomination_type1 = cash_dispensed_denomination_type1;
            this.cash_dispensed_denomination_type1Changed = true;
            this.cash_dispensed_counters_type1 = cash_dispensed_counters_type1;
            this.cash_dispensed_counters_type1Changed = true;
            this.cash_dispensed_denomination_type2 = cash_dispensed_denomination_type2;
            this.cash_dispensed_denomination_type2Changed = true;
            this.cash_dispensed_counters_type2 = cash_dispensed_counters_type2;
            this.cash_dispensed_counters_type2Changed = true;
            this.cash_dispensed_denomination_type3 = cash_dispensed_denomination_type3;
            this.cash_dispensed_denomination_type3Changed = true;
            this.cash_dispensed_counters_type3 = cash_dispensed_counters_type3;
            this.cash_dispensed_counters_type3Changed = true;
            this.cash_dispensed_denomination_type4 = cash_dispensed_denomination_type4;
            this.cash_dispensed_denomination_type4Changed = true;
            this.cash_dispensed_counters_type4 = cash_dispensed_counters_type4;
            this.cash_dispensed_counters_type4Changed = true;
            this.cash_rejected_denomination_type1 = cash_rejected_denomination_type1;
            this.cash_rejected_denomination_type1Changed = true;
            this.cash_rejected_counters_type1 = cash_rejected_counters_type1;
            this.cash_rejected_counters_type1Changed = true;
            this.cash_rejected_denomination_type2 = cash_rejected_denomination_type2;
            this.cash_rejected_denomination_type2Changed = true;
            this.cash_rejected_counters_type2 = cash_rejected_counters_type2;
            this.cash_rejected_counters_type2Changed = true;
            this.cash_rejected_denomination_type3 = cash_rejected_denomination_type3;
            this.cash_rejected_denomination_type3Changed = true;
            this.cash_rejected_counters_type3 = cash_rejected_counters_type3;
            this.cash_rejected_counters_type3Changed = true;
            this.cash_rejected_denomination_type4 = cash_rejected_denomination_type4;
            this.cash_rejected_denomination_type4Changed = true;
            this.cash_rejected_counters_type4 = cash_rejected_counters_type4;
            this.cash_rejected_counters_type4Changed = true;
            this.atm_settlement_id = atm_settlement_id;
            this.atm_settlement_idChanged = true;
            this.uploaded_by = uploaded_by;
            this.uploaded_byChanged = true;
            this.upload_datetime = upload_datetime;
            this.upload_datetimeChanged = true;
            this.atm_site_and_number = atm_site_and_number;
            this.atm_site_and_numberChanged = true;
            this.total_replenished = total_replenished;
            this.total_replenishedChanged = true;
            this.date_of_old_replenised = date_of_old_replenised;
            this.date_of_old_replenisedChanged = true;
            this.location = location;
            this.locationChanged = true;
            this.atm_no = atm_no;
            this.atm_noChanged = true;
            this.total_returned = total_returned;
            this.total_returnedChanged = true;
            this.cash_rem_denomination_type1 = cash_rem_denomination_type1;
            this.cash_rem_denomination_type1Changed = true;
            this.cash_rem_counters_type1 = cash_rem_counters_type1;
            this.cash_rem_counters_type1Changed = true;
            this.cash_rem_denomination_type2 = cash_rem_denomination_type2;
            this.cash_rem_denomination_type2Changed = true;
            this.cash_rem_counters_type2 = cash_rem_counters_type2;
            this.cash_rem_counters_type2Changed = true;
            this.cash_rem_denomination_type3 = cash_rem_denomination_type3;
            this.cash_rem_denomination_type3Changed = true;
            this.cash_rem_counters_type3 = cash_rem_counters_type3;
            this.cash_rem_counters_type3Changed = true;
            this.cash_rem_denomination_type4 = cash_rem_denomination_type4;
            this.cash_rem_denomination_type4Changed = true;
            this.cash_rem_counters_type4 = cash_rem_counters_type4;
            this.cash_rem_counters_type4Changed = true;
            this.previous_rep_date = previous_rep_date;
            this.previous_rep_dateChanged = true;
            this.journal_no = journal_no;
            this.journal_noChanged = true;
            this.total_rejected = total_rejected;
            this.total_rejectedChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.modified_on = modified_on;
            this.modified_onChanged = true;
            this.atm_settlement_info_id = atm_settlement_info_id;
            this.atm_settlement_info_idChanged = true;
            this.cash_dep_total_type1 = cash_dep_total_type1;
            this.cash_dep_total_type1Changed = true;
            this.cash_dep_total_type2 = cash_dep_total_type2;
            this.cash_dep_total_type2Changed = true;
            this.cash_dep_total_type3 = cash_dep_total_type3;
            this.cash_dep_total_type3Changed = true;
            this.cash_dep_total_type4 = cash_dep_total_type4;
            this.cash_dep_total_type4Changed = true;
        }

        #region members and properties for columns

        #region GlNo
        private bool gl_noChanged = false;
        private string gl_no;
        public string GlNo
        {
            get { return gl_no; }
            set
            {
                gl_no = value;
                gl_noChanged = true;
            }
        }
        private string gl_noDbString
        {
            get
            {
                if (this.gl_no != null)
                    return string.Format("'{0}'", gl_no);
                else
                    return "null";
            }
        }
        #endregion
        #region RepDatetime
        private bool rep_datetimeChanged = false;
        private DateTime? rep_datetime;
        public DateTime? RepDatetime
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
                if (this.rep_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", rep_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region SealNumber
        private bool seal_numberChanged = false;
        private string seal_number;
        public string SealNumber
        {
            get { return seal_number; }
            set
            {
                seal_number = value;
                seal_numberChanged = true;
            }
        }
        private string seal_numberDbString
        {
            get
            {
                if (this.seal_number != null)
                    return string.Format("'{0}'", seal_number);
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepDenominationType1
        private bool cash_rep_denomination_type1Changed = false;
        private int? cash_rep_denomination_type1;
        public int? CashRepDenominationType1
        {
            get { return cash_rep_denomination_type1; }
            set
            {
                cash_rep_denomination_type1 = value;
                cash_rep_denomination_type1Changed = true;
            }
        }
        private string cash_rep_denomination_type1DbString
        {
            get
            {
                if (this.cash_rep_denomination_type1.HasValue)
                    return cash_rep_denomination_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepCountersType1
        private bool cash_rep_counters_type1Changed = false;
        private int? cash_rep_counters_type1;
        public int? CashRepCountersType1
        {
            get { return cash_rep_counters_type1; }
            set
            {
                cash_rep_counters_type1 = value;
                cash_rep_counters_type1Changed = true;
            }
        }
        private string cash_rep_counters_type1DbString
        {
            get
            {
                if (this.cash_rep_counters_type1.HasValue)
                    return cash_rep_counters_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepDenominationType2
        private bool cash_rep_denomination_type2Changed = false;
        private int? cash_rep_denomination_type2;
        public int? CashRepDenominationType2
        {
            get { return cash_rep_denomination_type2; }
            set
            {
                cash_rep_denomination_type2 = value;
                cash_rep_denomination_type2Changed = true;
            }
        }
        private string cash_rep_denomination_type2DbString
        {
            get
            {
                if (this.cash_rep_denomination_type2.HasValue)
                    return cash_rep_denomination_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepCountersType2
        private bool cash_rep_counters_type2Changed = false;
        private int? cash_rep_counters_type2;
        public int? CashRepCountersType2
        {
            get { return cash_rep_counters_type2; }
            set
            {
                cash_rep_counters_type2 = value;
                cash_rep_counters_type2Changed = true;
            }
        }
        private string cash_rep_counters_type2DbString
        {
            get
            {
                if (this.cash_rep_counters_type2.HasValue)
                    return cash_rep_counters_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepDenominationType3
        private bool cash_rep_denomination_type3Changed = false;
        private int? cash_rep_denomination_type3;
        public int? CashRepDenominationType3
        {
            get { return cash_rep_denomination_type3; }
            set
            {
                cash_rep_denomination_type3 = value;
                cash_rep_denomination_type3Changed = true;
            }
        }
        private string cash_rep_denomination_type3DbString
        {
            get
            {
                if (this.cash_rep_denomination_type3.HasValue)
                    return cash_rep_denomination_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepCountersType3
        private bool cash_rep_counters_type3Changed = false;
        private int? cash_rep_counters_type3;
        public int? CashRepCountersType3
        {
            get { return cash_rep_counters_type3; }
            set
            {
                cash_rep_counters_type3 = value;
                cash_rep_counters_type3Changed = true;
            }
        }
        private string cash_rep_counters_type3DbString
        {
            get
            {
                if (this.cash_rep_counters_type3.HasValue)
                    return cash_rep_counters_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepDenominationType4
        private bool cash_rep_denomination_type4Changed = false;
        private int? cash_rep_denomination_type4;
        public int? CashRepDenominationType4
        {
            get { return cash_rep_denomination_type4; }
            set
            {
                cash_rep_denomination_type4 = value;
                cash_rep_denomination_type4Changed = true;
            }
        }
        private string cash_rep_denomination_type4DbString
        {
            get
            {
                if (this.cash_rep_denomination_type4.HasValue)
                    return cash_rep_denomination_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRepCountersType4
        private bool cash_rep_counters_type4Changed = false;
        private int? cash_rep_counters_type4;
        public int? CashRepCountersType4
        {
            get { return cash_rep_counters_type4; }
            set
            {
                cash_rep_counters_type4 = value;
                cash_rep_counters_type4Changed = true;
            }
        }
        private string cash_rep_counters_type4DbString
        {
            get
            {
                if (this.cash_rep_counters_type4.HasValue)
                    return cash_rep_counters_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnDenominationType1
        private bool cash_return_denomination_type1Changed = false;
        private int? cash_return_denomination_type1;
        public int? CashReturnDenominationType1
        {
            get { return cash_return_denomination_type1; }
            set
            {
                cash_return_denomination_type1 = value;
                cash_return_denomination_type1Changed = true;
            }
        }
        private string cash_return_denomination_type1DbString
        {
            get
            {
                if (this.cash_return_denomination_type1.HasValue)
                    return cash_return_denomination_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnCountersType1
        private bool cash_return_counters_type1Changed = false;
        private int? cash_return_counters_type1;
        public int? CashReturnCountersType1
        {
            get { return cash_return_counters_type1; }
            set
            {
                cash_return_counters_type1 = value;
                cash_return_counters_type1Changed = true;
            }
        }
        private string cash_return_counters_type1DbString
        {
            get
            {
                if (this.cash_return_counters_type1.HasValue)
                    return cash_return_counters_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnDenominationType2
        private bool cash_return_denomination_type2Changed = false;
        private int? cash_return_denomination_type2;
        public int? CashReturnDenominationType2
        {
            get { return cash_return_denomination_type2; }
            set
            {
                cash_return_denomination_type2 = value;
                cash_return_denomination_type2Changed = true;
            }
        }
        private string cash_return_denomination_type2DbString
        {
            get
            {
                if (this.cash_return_denomination_type2.HasValue)
                    return cash_return_denomination_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnCountersType2
        private bool cash_return_counters_type2Changed = false;
        private int? cash_return_counters_type2;
        public int? CashReturnCountersType2
        {
            get { return cash_return_counters_type2; }
            set
            {
                cash_return_counters_type2 = value;
                cash_return_counters_type2Changed = true;
            }
        }
        private string cash_return_counters_type2DbString
        {
            get
            {
                if (this.cash_return_counters_type2.HasValue)
                    return cash_return_counters_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnDenominationType3
        private bool cash_return_denomination_type3Changed = false;
        private int? cash_return_denomination_type3;
        public int? CashReturnDenominationType3
        {
            get { return cash_return_denomination_type3; }
            set
            {
                cash_return_denomination_type3 = value;
                cash_return_denomination_type3Changed = true;
            }
        }
        private string cash_return_denomination_type3DbString
        {
            get
            {
                if (this.cash_return_denomination_type3.HasValue)
                    return cash_return_denomination_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnCountersType3
        private bool cash_return_counters_type3Changed = false;
        private int? cash_return_counters_type3;
        public int? CashReturnCountersType3
        {
            get { return cash_return_counters_type3; }
            set
            {
                cash_return_counters_type3 = value;
                cash_return_counters_type3Changed = true;
            }
        }
        private string cash_return_counters_type3DbString
        {
            get
            {
                if (this.cash_return_counters_type3.HasValue)
                    return cash_return_counters_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnDenominationType4
        private bool cash_return_denomination_type4Changed = false;
        private int? cash_return_denomination_type4;
        public int? CashReturnDenominationType4
        {
            get { return cash_return_denomination_type4; }
            set
            {
                cash_return_denomination_type4 = value;
                cash_return_denomination_type4Changed = true;
            }
        }
        private string cash_return_denomination_type4DbString
        {
            get
            {
                if (this.cash_return_denomination_type4.HasValue)
                    return cash_return_denomination_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashReturnCountersType4
        private bool cash_return_counters_type4Changed = false;
        private int? cash_return_counters_type4;
        public int? CashReturnCountersType4
        {
            get { return cash_return_counters_type4; }
            set
            {
                cash_return_counters_type4 = value;
                cash_return_counters_type4Changed = true;
            }
        }
        private string cash_return_counters_type4DbString
        {
            get
            {
                if (this.cash_return_counters_type4.HasValue)
                    return cash_return_counters_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedDenominationType1
        private bool cash_dispensed_denomination_type1Changed = false;
        private int? cash_dispensed_denomination_type1;
        public int? CashDispensedDenominationType1
        {
            get { return cash_dispensed_denomination_type1; }
            set
            {
                cash_dispensed_denomination_type1 = value;
                cash_dispensed_denomination_type1Changed = true;
            }
        }
        private string cash_dispensed_denomination_type1DbString
        {
            get
            {
                if (this.cash_dispensed_denomination_type1.HasValue)
                    return cash_dispensed_denomination_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedCountersType1
        private bool cash_dispensed_counters_type1Changed = false;
        private int? cash_dispensed_counters_type1;
        public int? CashDispensedCountersType1
        {
            get { return cash_dispensed_counters_type1; }
            set
            {
                cash_dispensed_counters_type1 = value;
                cash_dispensed_counters_type1Changed = true;
            }
        }
        private string cash_dispensed_counters_type1DbString
        {
            get
            {
                if (this.cash_dispensed_counters_type1.HasValue)
                    return cash_dispensed_counters_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedDenominationType2
        private bool cash_dispensed_denomination_type2Changed = false;
        private int? cash_dispensed_denomination_type2;
        public int? CashDispensedDenominationType2
        {
            get { return cash_dispensed_denomination_type2; }
            set
            {
                cash_dispensed_denomination_type2 = value;
                cash_dispensed_denomination_type2Changed = true;
            }
        }
        private string cash_dispensed_denomination_type2DbString
        {
            get
            {
                if (this.cash_dispensed_denomination_type2.HasValue)
                    return cash_dispensed_denomination_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedCountersType2
        private bool cash_dispensed_counters_type2Changed = false;
        private int? cash_dispensed_counters_type2;
        public int? CashDispensedCountersType2
        {
            get { return cash_dispensed_counters_type2; }
            set
            {
                cash_dispensed_counters_type2 = value;
                cash_dispensed_counters_type2Changed = true;
            }
        }
        private string cash_dispensed_counters_type2DbString
        {
            get
            {
                if (this.cash_dispensed_counters_type2.HasValue)
                    return cash_dispensed_counters_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedDenominationType3
        private bool cash_dispensed_denomination_type3Changed = false;
        private int? cash_dispensed_denomination_type3;
        public int? CashDispensedDenominationType3
        {
            get { return cash_dispensed_denomination_type3; }
            set
            {
                cash_dispensed_denomination_type3 = value;
                cash_dispensed_denomination_type3Changed = true;
            }
        }
        private string cash_dispensed_denomination_type3DbString
        {
            get
            {
                if (this.cash_dispensed_denomination_type3.HasValue)
                    return cash_dispensed_denomination_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedCountersType3
        private bool cash_dispensed_counters_type3Changed = false;
        private int? cash_dispensed_counters_type3;
        public int? CashDispensedCountersType3
        {
            get { return cash_dispensed_counters_type3; }
            set
            {
                cash_dispensed_counters_type3 = value;
                cash_dispensed_counters_type3Changed = true;
            }
        }
        private string cash_dispensed_counters_type3DbString
        {
            get
            {
                if (this.cash_dispensed_counters_type3.HasValue)
                    return cash_dispensed_counters_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedDenominationType4
        private bool cash_dispensed_denomination_type4Changed = false;
        private int? cash_dispensed_denomination_type4;
        public int? CashDispensedDenominationType4
        {
            get { return cash_dispensed_denomination_type4; }
            set
            {
                cash_dispensed_denomination_type4 = value;
                cash_dispensed_denomination_type4Changed = true;
            }
        }
        private string cash_dispensed_denomination_type4DbString
        {
            get
            {
                if (this.cash_dispensed_denomination_type4.HasValue)
                    return cash_dispensed_denomination_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDispensedCountersType4
        private bool cash_dispensed_counters_type4Changed = false;
        private int? cash_dispensed_counters_type4;
        public int? CashDispensedCountersType4
        {
            get { return cash_dispensed_counters_type4; }
            set
            {
                cash_dispensed_counters_type4 = value;
                cash_dispensed_counters_type4Changed = true;
            }
        }
        private string cash_dispensed_counters_type4DbString
        {
            get
            {
                if (this.cash_dispensed_counters_type4.HasValue)
                    return cash_dispensed_counters_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedDenominationType1
        private bool cash_rejected_denomination_type1Changed = false;
        private int? cash_rejected_denomination_type1;
        public int? CashRejectedDenominationType1
        {
            get { return cash_rejected_denomination_type1; }
            set
            {
                cash_rejected_denomination_type1 = value;
                cash_rejected_denomination_type1Changed = true;
            }
        }
        private string cash_rejected_denomination_type1DbString
        {
            get
            {
                if (this.cash_rejected_denomination_type1.HasValue)
                    return cash_rejected_denomination_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedCountersType1
        private bool cash_rejected_counters_type1Changed = false;
        private int? cash_rejected_counters_type1;
        public int? CashRejectedCountersType1
        {
            get { return cash_rejected_counters_type1; }
            set
            {
                cash_rejected_counters_type1 = value;
                cash_rejected_counters_type1Changed = true;
            }
        }
        private string cash_rejected_counters_type1DbString
        {
            get
            {
                if (this.cash_rejected_counters_type1.HasValue)
                    return cash_rejected_counters_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedDenominationType2
        private bool cash_rejected_denomination_type2Changed = false;
        private int? cash_rejected_denomination_type2;
        public int? CashRejectedDenominationType2
        {
            get { return cash_rejected_denomination_type2; }
            set
            {
                cash_rejected_denomination_type2 = value;
                cash_rejected_denomination_type2Changed = true;
            }
        }
        private string cash_rejected_denomination_type2DbString
        {
            get
            {
                if (this.cash_rejected_denomination_type2.HasValue)
                    return cash_rejected_denomination_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedCountersType2
        private bool cash_rejected_counters_type2Changed = false;
        private int? cash_rejected_counters_type2;
        public int? CashRejectedCountersType2
        {
            get { return cash_rejected_counters_type2; }
            set
            {
                cash_rejected_counters_type2 = value;
                cash_rejected_counters_type2Changed = true;
            }
        }
        private string cash_rejected_counters_type2DbString
        {
            get
            {
                if (this.cash_rejected_counters_type2.HasValue)
                    return cash_rejected_counters_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedDenominationType3
        private bool cash_rejected_denomination_type3Changed = false;
        private int? cash_rejected_denomination_type3;
        public int? CashRejectedDenominationType3
        {
            get { return cash_rejected_denomination_type3; }
            set
            {
                cash_rejected_denomination_type3 = value;
                cash_rejected_denomination_type3Changed = true;
            }
        }
        private string cash_rejected_denomination_type3DbString
        {
            get
            {
                if (this.cash_rejected_denomination_type3.HasValue)
                    return cash_rejected_denomination_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedCountersType3
        private bool cash_rejected_counters_type3Changed = false;
        private int? cash_rejected_counters_type3;
        public int? CashRejectedCountersType3
        {
            get { return cash_rejected_counters_type3; }
            set
            {
                cash_rejected_counters_type3 = value;
                cash_rejected_counters_type3Changed = true;
            }
        }
        private string cash_rejected_counters_type3DbString
        {
            get
            {
                if (this.cash_rejected_counters_type3.HasValue)
                    return cash_rejected_counters_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedDenominationType4
        private bool cash_rejected_denomination_type4Changed = false;
        private int? cash_rejected_denomination_type4;
        public int? CashRejectedDenominationType4
        {
            get { return cash_rejected_denomination_type4; }
            set
            {
                cash_rejected_denomination_type4 = value;
                cash_rejected_denomination_type4Changed = true;
            }
        }
        private string cash_rejected_denomination_type4DbString
        {
            get
            {
                if (this.cash_rejected_denomination_type4.HasValue)
                    return cash_rejected_denomination_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRejectedCountersType4
        private bool cash_rejected_counters_type4Changed = false;
        private int? cash_rejected_counters_type4;
        public int? CashRejectedCountersType4
        {
            get { return cash_rejected_counters_type4; }
            set
            {
                cash_rejected_counters_type4 = value;
                cash_rejected_counters_type4Changed = true;
            }
        }
        private string cash_rejected_counters_type4DbString
        {
            get
            {
                if (this.cash_rejected_counters_type4.HasValue)
                    return cash_rejected_counters_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AtmSettlementId
        private bool atm_settlement_idChanged = false;
        private int? atm_settlement_id;
        public int? AtmSettlementId
        {
            get { return atm_settlement_id; }
            set
            {
                atm_settlement_id = value;
                atm_settlement_idChanged = true;
            }
        }
        private string atm_settlement_idDbString
        {
            get
            {
                if (this.atm_settlement_id.HasValue)
                    return atm_settlement_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region UploadedBy
        private bool uploaded_byChanged = false;
        private int? uploaded_by;
        public int? UploadedBy
        {
            get { return uploaded_by; }
            set
            {
                uploaded_by = value;
                uploaded_byChanged = true;
            }
        }
        private string uploaded_byDbString
        {
            get
            {
                if (this.uploaded_by.HasValue)
                    return uploaded_by.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region UploadDatetime
        private bool upload_datetimeChanged = false;
        private DateTime? upload_datetime;
        public DateTime? UploadDatetime
        {
            get { return upload_datetime; }
            set
            {
                upload_datetime = value;
                upload_datetimeChanged = true;
            }
        }
        private string upload_datetimeDbString
        {
            get
            {
                if (this.upload_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", upload_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region AtmSiteAndNumber
        private bool atm_site_and_numberChanged = false;
        private string atm_site_and_number;
        public string AtmSiteAndNumber
        {
            get { return atm_site_and_number; }
            set
            {
                atm_site_and_number = value;
                atm_site_and_numberChanged = true;
            }
        }
        private string atm_site_and_numberDbString
        {
            get
            {
                if (this.atm_site_and_number != null)
                    return string.Format("'{0}'", atm_site_and_number);
                else
                    return "null";
            }
        }
        #endregion
        #region TotalReplenished
        private bool total_replenishedChanged = false;
        private decimal? total_replenished;
        public decimal? TotalReplenished
        {
            get { return total_replenished; }
            set
            {
                total_replenished = value;
                total_replenishedChanged = true;
            }
        }
        private string total_replenishedDbString
        {
            get
            {
                if (this.total_replenished.HasValue)
                    return total_replenished.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DateOfOldReplenised
        private bool date_of_old_replenisedChanged = false;
        private DateTime? date_of_old_replenised;
        public DateTime? DateOfOldReplenised
        {
            get { return date_of_old_replenised; }
            set
            {
                date_of_old_replenised = value;
                date_of_old_replenisedChanged = true;
            }
        }
        private string date_of_old_replenisedDbString
        {
            get
            {
                if (this.date_of_old_replenised.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", date_of_old_replenised.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Location
        private bool locationChanged = false;
        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                locationChanged = true;
            }
        }
        private string locationDbString
        {
            get
            {
                if (this.location != null)
                    return string.Format("'{0}'", location);
                else
                    return "null";
            }
        }
        #endregion
        #region AtmNo
        private bool atm_noChanged = false;
        private int? atm_no;
        public int? AtmNo
        {
            get { return atm_no; }
            set
            {
                atm_no = value;
                atm_noChanged = true;
            }
        }
        private string atm_noDbString
        {
            get
            {
                if (this.atm_no.HasValue)
                    return atm_no.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TotalReturned
        private bool total_returnedChanged = false;
        private decimal? total_returned;
        public decimal? TotalReturned
        {
            get { return total_returned; }
            set
            {
                total_returned = value;
                total_returnedChanged = true;
            }
        }
        private string total_returnedDbString
        {
            get
            {
                if (this.total_returned.HasValue)
                    return total_returned.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemDenominationType1
        private bool cash_rem_denomination_type1Changed = false;
        private int? cash_rem_denomination_type1;
        public int? CashRemDenominationType1
        {
            get { return cash_rem_denomination_type1; }
            set
            {
                cash_rem_denomination_type1 = value;
                cash_rem_denomination_type1Changed = true;
            }
        }
        private string cash_rem_denomination_type1DbString
        {
            get
            {
                if (this.cash_rem_denomination_type1.HasValue)
                    return cash_rem_denomination_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemCountersType1
        private bool cash_rem_counters_type1Changed = false;
        private int? cash_rem_counters_type1;
        public int? CashRemCountersType1
        {
            get { return cash_rem_counters_type1; }
            set
            {
                cash_rem_counters_type1 = value;
                cash_rem_counters_type1Changed = true;
            }
        }
        private string cash_rem_counters_type1DbString
        {
            get
            {
                if (this.cash_rem_counters_type1.HasValue)
                    return cash_rem_counters_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemDenominationType2
        private bool cash_rem_denomination_type2Changed = false;
        private int? cash_rem_denomination_type2;
        public int? CashRemDenominationType2
        {
            get { return cash_rem_denomination_type2; }
            set
            {
                cash_rem_denomination_type2 = value;
                cash_rem_denomination_type2Changed = true;
            }
        }
        private string cash_rem_denomination_type2DbString
        {
            get
            {
                if (this.cash_rem_denomination_type2.HasValue)
                    return cash_rem_denomination_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemCountersType2
        private bool cash_rem_counters_type2Changed = false;
        private int? cash_rem_counters_type2;
        public int? CashRemCountersType2
        {
            get { return cash_rem_counters_type2; }
            set
            {
                cash_rem_counters_type2 = value;
                cash_rem_counters_type2Changed = true;
            }
        }
        private string cash_rem_counters_type2DbString
        {
            get
            {
                if (this.cash_rem_counters_type2.HasValue)
                    return cash_rem_counters_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemDenominationType3
        private bool cash_rem_denomination_type3Changed = false;
        private int? cash_rem_denomination_type3;
        public int? CashRemDenominationType3
        {
            get { return cash_rem_denomination_type3; }
            set
            {
                cash_rem_denomination_type3 = value;
                cash_rem_denomination_type3Changed = true;
            }
        }
        private string cash_rem_denomination_type3DbString
        {
            get
            {
                if (this.cash_rem_denomination_type3.HasValue)
                    return cash_rem_denomination_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemCountersType3
        private bool cash_rem_counters_type3Changed = false;
        private int? cash_rem_counters_type3;
        public int? CashRemCountersType3
        {
            get { return cash_rem_counters_type3; }
            set
            {
                cash_rem_counters_type3 = value;
                cash_rem_counters_type3Changed = true;
            }
        }
        private string cash_rem_counters_type3DbString
        {
            get
            {
                if (this.cash_rem_counters_type3.HasValue)
                    return cash_rem_counters_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemDenominationType4
        private bool cash_rem_denomination_type4Changed = false;
        private int? cash_rem_denomination_type4;
        public int? CashRemDenominationType4
        {
            get { return cash_rem_denomination_type4; }
            set
            {
                cash_rem_denomination_type4 = value;
                cash_rem_denomination_type4Changed = true;
            }
        }
        private string cash_rem_denomination_type4DbString
        {
            get
            {
                if (this.cash_rem_denomination_type4.HasValue)
                    return cash_rem_denomination_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemCountersType4
        private bool cash_rem_counters_type4Changed = false;
        private int? cash_rem_counters_type4;
        public int? CashRemCountersType4
        {
            get { return cash_rem_counters_type4; }
            set
            {
                cash_rem_counters_type4 = value;
                cash_rem_counters_type4Changed = true;
            }
        }
        private string cash_rem_counters_type4DbString
        {
            get
            {
                if (this.cash_rem_counters_type4.HasValue)
                    return cash_rem_counters_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PreviousRepDate
        private bool previous_rep_dateChanged = false;
        private DateTime? previous_rep_date;
        public DateTime? PreviousRepDate
        {
            get { return previous_rep_date; }
            set
            {
                previous_rep_date = value;
                previous_rep_dateChanged = true;
            }
        }
        private string previous_rep_dateDbString
        {
            get
            {
                if (this.previous_rep_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", previous_rep_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region JournalNo
        private bool journal_noChanged = false;
        private int? journal_no;
        public int? JournalNo
        {
            get { return journal_no; }
            set
            {
                journal_no = value;
                journal_noChanged = true;
            }
        }
        private string journal_noDbString
        {
            get
            {
                if (this.journal_no.HasValue)
                    return journal_no.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TotalRejected
        private bool total_rejectedChanged = false;
        private decimal? total_rejected;
        public decimal? TotalRejected
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
        #region ModifiedBy
        private bool modified_byChanged = false;
        private int? modified_by;
        public int? ModifiedBy
        {
            get { return modified_by; }
            set
            {
                modified_by = value;
                modified_byChanged = true;
            }
        }
        private string modified_byDbString
        {
            get
            {
                if (this.modified_by.HasValue)
                    return modified_by.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ModifiedOn
        private bool modified_onChanged = false;
        private DateTime? modified_on;
        public DateTime? ModifiedOn
        {
            get { return modified_on; }
            set
            {
                modified_on = value;
                modified_onChanged = true;
            }
        }
        private string modified_onDbString
        {
            get
            {
                if (this.modified_on.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region AtmSettlementInfoId
        private bool atm_settlement_info_idChanged = false;
        private int atm_settlement_info_id;
        public int AtmSettlementInfoId
        {
            get { return atm_settlement_info_id; }
            set
            {
                atm_settlement_info_id = value;
                atm_settlement_info_idChanged = true;
            }
        }
        private string atm_settlement_info_idDbString
        {
            get
            {
                return atm_settlement_info_id.ToString();
            }
        }
        #endregion
        #region CashDepTotalType1
        private bool cash_dep_total_type1Changed = false;
        private int? cash_dep_total_type1;
        public int? CashDepTotalType1
        {
            get { return cash_dep_total_type1; }
            set
            {
                cash_dep_total_type1 = value;
                cash_dep_total_type1Changed = true;
            }
        }
        private string cash_dep_total_type1DbString
        {
            get
            {
                if (this.cash_dep_total_type1.HasValue)
                    return cash_dep_total_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDepTotalType2
        private bool cash_dep_total_type2Changed = false;
        private int? cash_dep_total_type2;
        public int? CashDepTotalType2
        {
            get { return cash_dep_total_type2; }
            set
            {
                cash_dep_total_type2 = value;
                cash_dep_total_type2Changed = true;
            }
        }
        private string cash_dep_total_type2DbString
        {
            get
            {
                if (this.cash_dep_total_type2.HasValue)
                    return cash_dep_total_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDepTotalType3
        private bool cash_dep_total_type3Changed = false;
        private int? cash_dep_total_type3;
        public int? CashDepTotalType3
        {
            get { return cash_dep_total_type3; }
            set
            {
                cash_dep_total_type3 = value;
                cash_dep_total_type3Changed = true;
            }
        }
        private string cash_dep_total_type3DbString
        {
            get
            {
                if (this.cash_dep_total_type3.HasValue)
                    return cash_dep_total_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashDepTotalType4
        private bool cash_dep_total_type4Changed = false;
        private int? cash_dep_total_type4;
        public int? CashDepTotalType4
        {
            get { return cash_dep_total_type4; }
            set
            {
                cash_dep_total_type4 = value;
                cash_dep_total_type4Changed = true;
            }
        }
        private string cash_dep_total_type4DbString
        {
            get
            {
                if (this.cash_dep_total_type4.HasValue)
                    return cash_dep_total_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region AtmSettlementReader
        public class AtmSettlementReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            AtmSettlement currentAtmSettlement;
            Columns columns;
            bool partialRead = false;
            private AtmSettlementReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AtmSettlementReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AtmSettlementReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAtmSettlement; }

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
                    currentAtmSettlement = new AtmSettlement();
                    if (partialRead)
                    {
                        if ((columns & Columns.gl_no) == Columns.gl_no && reader["gl_no"] != DBNull.Value)
                            currentAtmSettlement.gl_no = (string)reader["gl_no"];
                        if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"] != DBNull.Value)
                            currentAtmSettlement.rep_datetime = (DateTime?)reader["rep_datetime"];
                        if ((columns & Columns.seal_number) == Columns.seal_number && reader["seal_number"] != DBNull.Value)
                            currentAtmSettlement.seal_number = (string)reader["seal_number"];
                        if ((columns & Columns.cash_rep_denomination_type1) == Columns.cash_rep_denomination_type1 && reader["cash_rep_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type1 = (int?)reader["cash_rep_denomination_type1"];
                        if ((columns & Columns.cash_rep_counters_type1) == Columns.cash_rep_counters_type1 && reader["cash_rep_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type1 = (int?)reader["cash_rep_counters_type1"];
                        if ((columns & Columns.cash_rep_denomination_type2) == Columns.cash_rep_denomination_type2 && reader["cash_rep_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type2 = (int?)reader["cash_rep_denomination_type2"];
                        if ((columns & Columns.cash_rep_counters_type2) == Columns.cash_rep_counters_type2 && reader["cash_rep_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type2 = (int?)reader["cash_rep_counters_type2"];
                        if ((columns & Columns.cash_rep_denomination_type3) == Columns.cash_rep_denomination_type3 && reader["cash_rep_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type3 = (int?)reader["cash_rep_denomination_type3"];
                        if ((columns & Columns.cash_rep_counters_type3) == Columns.cash_rep_counters_type3 && reader["cash_rep_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type3 = (int?)reader["cash_rep_counters_type3"];
                        if ((columns & Columns.cash_rep_denomination_type4) == Columns.cash_rep_denomination_type4 && reader["cash_rep_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type4 = (int?)reader["cash_rep_denomination_type4"];
                        if ((columns & Columns.cash_rep_counters_type4) == Columns.cash_rep_counters_type4 && reader["cash_rep_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type4 = (int?)reader["cash_rep_counters_type4"];
                        if ((columns & Columns.cash_return_denomination_type1) == Columns.cash_return_denomination_type1 && reader["cash_return_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type1 = (int?)reader["cash_return_denomination_type1"];
                        if ((columns & Columns.cash_return_counters_type1) == Columns.cash_return_counters_type1 && reader["cash_return_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type1 = (int?)reader["cash_return_counters_type1"];
                        if ((columns & Columns.cash_return_denomination_type2) == Columns.cash_return_denomination_type2 && reader["cash_return_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type2 = (int?)reader["cash_return_denomination_type2"];
                        if ((columns & Columns.cash_return_counters_type2) == Columns.cash_return_counters_type2 && reader["cash_return_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type2 = (int?)reader["cash_return_counters_type2"];
                        if ((columns & Columns.cash_return_denomination_type3) == Columns.cash_return_denomination_type3 && reader["cash_return_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type3 = (int?)reader["cash_return_denomination_type3"];
                        if ((columns & Columns.cash_return_counters_type3) == Columns.cash_return_counters_type3 && reader["cash_return_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type3 = (int?)reader["cash_return_counters_type3"];
                        if ((columns & Columns.cash_return_denomination_type4) == Columns.cash_return_denomination_type4 && reader["cash_return_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type4 = (int?)reader["cash_return_denomination_type4"];
                        if ((columns & Columns.cash_return_counters_type4) == Columns.cash_return_counters_type4 && reader["cash_return_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type4 = (int?)reader["cash_return_counters_type4"];
                        if ((columns & Columns.cash_dispensed_denomination_type1) == Columns.cash_dispensed_denomination_type1 && reader["cash_dispensed_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type1 = (int?)reader["cash_dispensed_denomination_type1"];
                        if ((columns & Columns.cash_dispensed_counters_type1) == Columns.cash_dispensed_counters_type1 && reader["cash_dispensed_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type1 = (int?)reader["cash_dispensed_counters_type1"];
                        if ((columns & Columns.cash_dispensed_denomination_type2) == Columns.cash_dispensed_denomination_type2 && reader["cash_dispensed_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type2 = (int?)reader["cash_dispensed_denomination_type2"];
                        if ((columns & Columns.cash_dispensed_counters_type2) == Columns.cash_dispensed_counters_type2 && reader["cash_dispensed_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type2 = (int?)reader["cash_dispensed_counters_type2"];
                        if ((columns & Columns.cash_dispensed_denomination_type3) == Columns.cash_dispensed_denomination_type3 && reader["cash_dispensed_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type3 = (int?)reader["cash_dispensed_denomination_type3"];
                        if ((columns & Columns.cash_dispensed_counters_type3) == Columns.cash_dispensed_counters_type3 && reader["cash_dispensed_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type3 = (int?)reader["cash_dispensed_counters_type3"];
                        if ((columns & Columns.cash_dispensed_denomination_type4) == Columns.cash_dispensed_denomination_type4 && reader["cash_dispensed_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type4 = (int?)reader["cash_dispensed_denomination_type4"];
                        if ((columns & Columns.cash_dispensed_counters_type4) == Columns.cash_dispensed_counters_type4 && reader["cash_dispensed_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type4 = (int?)reader["cash_dispensed_counters_type4"];
                        if ((columns & Columns.cash_rejected_denomination_type1) == Columns.cash_rejected_denomination_type1 && reader["cash_rejected_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type1 = (int?)reader["cash_rejected_denomination_type1"];
                        if ((columns & Columns.cash_rejected_counters_type1) == Columns.cash_rejected_counters_type1 && reader["cash_rejected_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type1 = (int?)reader["cash_rejected_counters_type1"];
                        if ((columns & Columns.cash_rejected_denomination_type2) == Columns.cash_rejected_denomination_type2 && reader["cash_rejected_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type2 = (int?)reader["cash_rejected_denomination_type2"];
                        if ((columns & Columns.cash_rejected_counters_type2) == Columns.cash_rejected_counters_type2 && reader["cash_rejected_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type2 = (int?)reader["cash_rejected_counters_type2"];
                        if ((columns & Columns.cash_rejected_denomination_type3) == Columns.cash_rejected_denomination_type3 && reader["cash_rejected_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type3 = (int?)reader["cash_rejected_denomination_type3"];
                        if ((columns & Columns.cash_rejected_counters_type3) == Columns.cash_rejected_counters_type3 && reader["cash_rejected_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type3 = (int?)reader["cash_rejected_counters_type3"];
                        if ((columns & Columns.cash_rejected_denomination_type4) == Columns.cash_rejected_denomination_type4 && reader["cash_rejected_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type4 = (int?)reader["cash_rejected_denomination_type4"];
                        if ((columns & Columns.cash_rejected_counters_type4) == Columns.cash_rejected_counters_type4 && reader["cash_rejected_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type4 = (int?)reader["cash_rejected_counters_type4"];
                        if ((columns & Columns.atm_settlement_id) == Columns.atm_settlement_id && reader["atm_settlement_id"] != DBNull.Value)
                            currentAtmSettlement.atm_settlement_id = (int?)reader["atm_settlement_id"];
                        if ((columns & Columns.uploaded_by) == Columns.uploaded_by && reader["uploaded_by"] != DBNull.Value)
                            currentAtmSettlement.uploaded_by = (int?)reader["uploaded_by"];
                        if ((columns & Columns.upload_datetime) == Columns.upload_datetime && reader["upload_datetime"] != DBNull.Value)
                            currentAtmSettlement.upload_datetime = (DateTime?)reader["upload_datetime"];
                        if ((columns & Columns.atm_site_and_number) == Columns.atm_site_and_number && reader["atm_site_and_number"] != DBNull.Value)
                            currentAtmSettlement.atm_site_and_number = (string)reader["atm_site_and_number"];
                        if ((columns & Columns.total_replenished) == Columns.total_replenished && reader["total_replenished"] != DBNull.Value)
                            currentAtmSettlement.total_replenished = (decimal?)reader["total_replenished"];
                        if ((columns & Columns.date_of_old_replenised) == Columns.date_of_old_replenised && reader["date_of_old_replenised"] != DBNull.Value)
                            currentAtmSettlement.date_of_old_replenised = (DateTime?)reader["date_of_old_replenised"];
                        if ((columns & Columns.location) == Columns.location && reader["location"] != DBNull.Value)
                            currentAtmSettlement.location = (string)reader["location"];
                        if ((columns & Columns.atm_no) == Columns.atm_no && reader["atm_no"] != DBNull.Value)
                            currentAtmSettlement.atm_no = (int?)reader["atm_no"];
                        if ((columns & Columns.total_returned) == Columns.total_returned && reader["total_returned"] != DBNull.Value)
                            currentAtmSettlement.total_returned = (decimal?)reader["total_returned"];
                        if ((columns & Columns.cash_rem_denomination_type1) == Columns.cash_rem_denomination_type1 && reader["cash_rem_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type1 = (int?)reader["cash_rem_denomination_type1"];
                        if ((columns & Columns.cash_rem_counters_type1) == Columns.cash_rem_counters_type1 && reader["cash_rem_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type1 = (int?)reader["cash_rem_counters_type1"];
                        if ((columns & Columns.cash_rem_denomination_type2) == Columns.cash_rem_denomination_type2 && reader["cash_rem_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type2 = (int?)reader["cash_rem_denomination_type2"];
                        if ((columns & Columns.cash_rem_counters_type2) == Columns.cash_rem_counters_type2 && reader["cash_rem_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type2 = (int?)reader["cash_rem_counters_type2"];
                        if ((columns & Columns.cash_rem_denomination_type3) == Columns.cash_rem_denomination_type3 && reader["cash_rem_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type3 = (int?)reader["cash_rem_denomination_type3"];
                        if ((columns & Columns.cash_rem_counters_type3) == Columns.cash_rem_counters_type3 && reader["cash_rem_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type3 = (int?)reader["cash_rem_counters_type3"];
                        if ((columns & Columns.cash_rem_denomination_type4) == Columns.cash_rem_denomination_type4 && reader["cash_rem_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type4 = (int?)reader["cash_rem_denomination_type4"];
                        if ((columns & Columns.cash_rem_counters_type4) == Columns.cash_rem_counters_type4 && reader["cash_rem_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type4 = (int?)reader["cash_rem_counters_type4"];
                        if ((columns & Columns.previous_rep_date) == Columns.previous_rep_date && reader["previous_rep_date"] != DBNull.Value)
                            currentAtmSettlement.previous_rep_date = (DateTime?)reader["previous_rep_date"];
                        if ((columns & Columns.journal_no) == Columns.journal_no && reader["journal_no"] != DBNull.Value)
                            currentAtmSettlement.journal_no = (int?)reader["journal_no"];
                        if ((columns & Columns.total_rejected) == Columns.total_rejected && reader["total_rejected"] != DBNull.Value)
                            currentAtmSettlement.total_rejected = (decimal?)reader["total_rejected"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentAtmSettlement.modified_by = (int?)reader["modified_by"];
                        if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"] != DBNull.Value)
                            currentAtmSettlement.modified_on = (DateTime?)reader["modified_on"];
                        if ((columns & Columns.atm_settlement_info_id) == Columns.atm_settlement_info_id && reader["atm_settlement_info_id"] != DBNull.Value)
                            currentAtmSettlement.atm_settlement_info_id = (int)reader["atm_settlement_info_id"];
                        if ((columns & Columns.cash_dep_total_type1) == Columns.cash_dep_total_type1 && reader["cash_dep_total_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type1 = (int?)reader["cash_dep_total_type1"];
                        if ((columns & Columns.cash_dep_total_type2) == Columns.cash_dep_total_type2 && reader["cash_dep_total_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type2 = (int?)reader["cash_dep_total_type2"];
                        if ((columns & Columns.cash_dep_total_type3) == Columns.cash_dep_total_type3 && reader["cash_dep_total_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type3 = (int?)reader["cash_dep_total_type3"];
                        if ((columns & Columns.cash_dep_total_type4) == Columns.cash_dep_total_type4 && reader["cash_dep_total_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type4 = (int?)reader["cash_dep_total_type4"];

                    }
                    else
                    {
                        if (reader["gl_no"] != DBNull.Value)
                            currentAtmSettlement.gl_no = (string)reader["gl_no"];
                        if (reader["rep_datetime"] != DBNull.Value)
                            currentAtmSettlement.rep_datetime = (DateTime?)reader["rep_datetime"];
                        if (reader["seal_number"] != DBNull.Value)
                            currentAtmSettlement.seal_number = (string)reader["seal_number"];
                        if (reader["cash_rep_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type1 = (int?)reader["cash_rep_denomination_type1"];
                        if (reader["cash_rep_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type1 = (int?)reader["cash_rep_counters_type1"];
                        if (reader["cash_rep_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type2 = (int?)reader["cash_rep_denomination_type2"];
                        if (reader["cash_rep_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type2 = (int?)reader["cash_rep_counters_type2"];
                        if (reader["cash_rep_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type3 = (int?)reader["cash_rep_denomination_type3"];
                        if (reader["cash_rep_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type3 = (int?)reader["cash_rep_counters_type3"];
                        if (reader["cash_rep_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_denomination_type4 = (int?)reader["cash_rep_denomination_type4"];
                        if (reader["cash_rep_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rep_counters_type4 = (int?)reader["cash_rep_counters_type4"];
                        if (reader["cash_return_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type1 = (int?)reader["cash_return_denomination_type1"];
                        if (reader["cash_return_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type1 = (int?)reader["cash_return_counters_type1"];
                        if (reader["cash_return_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type2 = (int?)reader["cash_return_denomination_type2"];
                        if (reader["cash_return_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type2 = (int?)reader["cash_return_counters_type2"];
                        if (reader["cash_return_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type3 = (int?)reader["cash_return_denomination_type3"];
                        if (reader["cash_return_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type3 = (int?)reader["cash_return_counters_type3"];
                        if (reader["cash_return_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_return_denomination_type4 = (int?)reader["cash_return_denomination_type4"];
                        if (reader["cash_return_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_return_counters_type4 = (int?)reader["cash_return_counters_type4"];
                        if (reader["cash_dispensed_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type1 = (int?)reader["cash_dispensed_denomination_type1"];
                        if (reader["cash_dispensed_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type1 = (int?)reader["cash_dispensed_counters_type1"];
                        if (reader["cash_dispensed_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type2 = (int?)reader["cash_dispensed_denomination_type2"];
                        if (reader["cash_dispensed_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type2 = (int?)reader["cash_dispensed_counters_type2"];
                        if (reader["cash_dispensed_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type3 = (int?)reader["cash_dispensed_denomination_type3"];
                        if (reader["cash_dispensed_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type3 = (int?)reader["cash_dispensed_counters_type3"];
                        if (reader["cash_dispensed_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_denomination_type4 = (int?)reader["cash_dispensed_denomination_type4"];
                        if (reader["cash_dispensed_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_dispensed_counters_type4 = (int?)reader["cash_dispensed_counters_type4"];
                        if (reader["cash_rejected_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type1 = (int?)reader["cash_rejected_denomination_type1"];
                        if (reader["cash_rejected_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type1 = (int?)reader["cash_rejected_counters_type1"];
                        if (reader["cash_rejected_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type2 = (int?)reader["cash_rejected_denomination_type2"];
                        if (reader["cash_rejected_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type2 = (int?)reader["cash_rejected_counters_type2"];
                        if (reader["cash_rejected_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type3 = (int?)reader["cash_rejected_denomination_type3"];
                        if (reader["cash_rejected_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type3 = (int?)reader["cash_rejected_counters_type3"];
                        if (reader["cash_rejected_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_denomination_type4 = (int?)reader["cash_rejected_denomination_type4"];
                        if (reader["cash_rejected_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rejected_counters_type4 = (int?)reader["cash_rejected_counters_type4"];
                        if (reader["atm_settlement_id"] != DBNull.Value)
                            currentAtmSettlement.atm_settlement_id = (int?)reader["atm_settlement_id"];
                        if (reader["uploaded_by"] != DBNull.Value)
                            currentAtmSettlement.uploaded_by = (int?)reader["uploaded_by"];
                        if (reader["upload_datetime"] != DBNull.Value)
                            currentAtmSettlement.upload_datetime = (DateTime?)reader["upload_datetime"];
                        if (reader["atm_site_and_number"] != DBNull.Value)
                            currentAtmSettlement.atm_site_and_number = (string)reader["atm_site_and_number"];
                        if (reader["total_replenished"] != DBNull.Value)
                            currentAtmSettlement.total_replenished = (decimal?)reader["total_replenished"];
                        if (reader["date_of_old_replenised"] != DBNull.Value)
                            currentAtmSettlement.date_of_old_replenised = (DateTime?)reader["date_of_old_replenised"];
                        if (reader["location"] != DBNull.Value)
                            currentAtmSettlement.location = (string)reader["location"];
                        if (reader["atm_no"] != DBNull.Value)
                            currentAtmSettlement.atm_no = (int?)reader["atm_no"];
                        if (reader["total_returned"] != DBNull.Value)
                            currentAtmSettlement.total_returned = (decimal?)reader["total_returned"];
                        if (reader["cash_rem_denomination_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type1 = (int?)reader["cash_rem_denomination_type1"];
                        if (reader["cash_rem_counters_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type1 = (int?)reader["cash_rem_counters_type1"];
                        if (reader["cash_rem_denomination_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type2 = (int?)reader["cash_rem_denomination_type2"];
                        if (reader["cash_rem_counters_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type2 = (int?)reader["cash_rem_counters_type2"];
                        if (reader["cash_rem_denomination_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type3 = (int?)reader["cash_rem_denomination_type3"];
                        if (reader["cash_rem_counters_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type3 = (int?)reader["cash_rem_counters_type3"];
                        if (reader["cash_rem_denomination_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_denomination_type4 = (int?)reader["cash_rem_denomination_type4"];
                        if (reader["cash_rem_counters_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_rem_counters_type4 = (int?)reader["cash_rem_counters_type4"];
                        if (reader["previous_rep_date"] != DBNull.Value)
                            currentAtmSettlement.previous_rep_date = (DateTime?)reader["previous_rep_date"];
                        if (reader["journal_no"] != DBNull.Value)
                            currentAtmSettlement.journal_no = (int?)reader["journal_no"];
                        if (reader["total_rejected"] != DBNull.Value)
                            currentAtmSettlement.total_rejected = (decimal?)reader["total_rejected"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentAtmSettlement.modified_by = (int?)reader["modified_by"];
                        if (reader["modified_on"] != DBNull.Value)
                            currentAtmSettlement.modified_on = (DateTime?)reader["modified_on"];
                        if (reader["atm_settlement_info_id"] != DBNull.Value)
                            currentAtmSettlement.atm_settlement_info_id = (int)reader["atm_settlement_info_id"];
                        if (reader["cash_dep_total_type1"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type1 = (int?)reader["cash_dep_total_type1"];
                        if (reader["cash_dep_total_type2"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type2 = (int?)reader["cash_dep_total_type2"];
                        if (reader["cash_dep_total_type3"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type3 = (int?)reader["cash_dep_total_type3"];
                        if (reader["cash_dep_total_type4"] != DBNull.Value)
                            currentAtmSettlement.cash_dep_total_type4 = (int?)reader["cash_dep_total_type4"];
                    }

                    currentAtmSettlement.isNewEntity = false;
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

            public AtmSettlement CurrentAtmSettlement
            {
                get { return currentAtmSettlement; }
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


        #region AtmSettlement functions

        public static AtmSettlementReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.gl_no == (Columns.gl_no & columns))
                qry.Append("gl_no,");
            if (Columns.rep_datetime == (Columns.rep_datetime & columns))
                qry.Append("rep_datetime,");
            if (Columns.seal_number == (Columns.seal_number & columns))
                qry.Append("seal_number,");
            if (Columns.cash_rep_denomination_type1 == (Columns.cash_rep_denomination_type1 & columns))
                qry.Append("cash_rep_denomination_type1,");
            if (Columns.cash_rep_counters_type1 == (Columns.cash_rep_counters_type1 & columns))
                qry.Append("cash_rep_counters_type1,");
            if (Columns.cash_rep_denomination_type2 == (Columns.cash_rep_denomination_type2 & columns))
                qry.Append("cash_rep_denomination_type2,");
            if (Columns.cash_rep_counters_type2 == (Columns.cash_rep_counters_type2 & columns))
                qry.Append("cash_rep_counters_type2,");
            if (Columns.cash_rep_denomination_type3 == (Columns.cash_rep_denomination_type3 & columns))
                qry.Append("cash_rep_denomination_type3,");
            if (Columns.cash_rep_counters_type3 == (Columns.cash_rep_counters_type3 & columns))
                qry.Append("cash_rep_counters_type3,");
            if (Columns.cash_rep_denomination_type4 == (Columns.cash_rep_denomination_type4 & columns))
                qry.Append("cash_rep_denomination_type4,");
            if (Columns.cash_rep_counters_type4 == (Columns.cash_rep_counters_type4 & columns))
                qry.Append("cash_rep_counters_type4,");
            if (Columns.cash_return_denomination_type1 == (Columns.cash_return_denomination_type1 & columns))
                qry.Append("cash_return_denomination_type1,");
            if (Columns.cash_return_counters_type1 == (Columns.cash_return_counters_type1 & columns))
                qry.Append("cash_return_counters_type1,");
            if (Columns.cash_return_denomination_type2 == (Columns.cash_return_denomination_type2 & columns))
                qry.Append("cash_return_denomination_type2,");
            if (Columns.cash_return_counters_type2 == (Columns.cash_return_counters_type2 & columns))
                qry.Append("cash_return_counters_type2,");
            if (Columns.cash_return_denomination_type3 == (Columns.cash_return_denomination_type3 & columns))
                qry.Append("cash_return_denomination_type3,");
            if (Columns.cash_return_counters_type3 == (Columns.cash_return_counters_type3 & columns))
                qry.Append("cash_return_counters_type3,");
            if (Columns.cash_return_denomination_type4 == (Columns.cash_return_denomination_type4 & columns))
                qry.Append("cash_return_denomination_type4,");
            if (Columns.cash_return_counters_type4 == (Columns.cash_return_counters_type4 & columns))
                qry.Append("cash_return_counters_type4,");
            if (Columns.cash_dispensed_denomination_type1 == (Columns.cash_dispensed_denomination_type1 & columns))
                qry.Append("cash_dispensed_denomination_type1,");
            if (Columns.cash_dispensed_counters_type1 == (Columns.cash_dispensed_counters_type1 & columns))
                qry.Append("cash_dispensed_counters_type1,");
            if (Columns.cash_dispensed_denomination_type2 == (Columns.cash_dispensed_denomination_type2 & columns))
                qry.Append("cash_dispensed_denomination_type2,");
            if (Columns.cash_dispensed_counters_type2 == (Columns.cash_dispensed_counters_type2 & columns))
                qry.Append("cash_dispensed_counters_type2,");
            if (Columns.cash_dispensed_denomination_type3 == (Columns.cash_dispensed_denomination_type3 & columns))
                qry.Append("cash_dispensed_denomination_type3,");
            if (Columns.cash_dispensed_counters_type3 == (Columns.cash_dispensed_counters_type3 & columns))
                qry.Append("cash_dispensed_counters_type3,");
            if (Columns.cash_dispensed_denomination_type4 == (Columns.cash_dispensed_denomination_type4 & columns))
                qry.Append("cash_dispensed_denomination_type4,");
            if (Columns.cash_dispensed_counters_type4 == (Columns.cash_dispensed_counters_type4 & columns))
                qry.Append("cash_dispensed_counters_type4,");
            if (Columns.cash_rejected_denomination_type1 == (Columns.cash_rejected_denomination_type1 & columns))
                qry.Append("cash_rejected_denomination_type1,");
            if (Columns.cash_rejected_counters_type1 == (Columns.cash_rejected_counters_type1 & columns))
                qry.Append("cash_rejected_counters_type1,");
            if (Columns.cash_rejected_denomination_type2 == (Columns.cash_rejected_denomination_type2 & columns))
                qry.Append("cash_rejected_denomination_type2,");
            if (Columns.cash_rejected_counters_type2 == (Columns.cash_rejected_counters_type2 & columns))
                qry.Append("cash_rejected_counters_type2,");
            if (Columns.cash_rejected_denomination_type3 == (Columns.cash_rejected_denomination_type3 & columns))
                qry.Append("cash_rejected_denomination_type3,");
            if (Columns.cash_rejected_counters_type3 == (Columns.cash_rejected_counters_type3 & columns))
                qry.Append("cash_rejected_counters_type3,");
            if (Columns.cash_rejected_denomination_type4 == (Columns.cash_rejected_denomination_type4 & columns))
                qry.Append("cash_rejected_denomination_type4,");
            if (Columns.cash_rejected_counters_type4 == (Columns.cash_rejected_counters_type4 & columns))
                qry.Append("cash_rejected_counters_type4,");
            if (Columns.atm_settlement_id == (Columns.atm_settlement_id & columns))
                qry.Append("atm_settlement_id,");
            if (Columns.uploaded_by == (Columns.uploaded_by & columns))
                qry.Append("uploaded_by,");
            if (Columns.upload_datetime == (Columns.upload_datetime & columns))
                qry.Append("upload_datetime,");
            if (Columns.atm_site_and_number == (Columns.atm_site_and_number & columns))
                qry.Append("atm_site_and_number,");
            if (Columns.total_replenished == (Columns.total_replenished & columns))
                qry.Append("total_replenished,");
            if (Columns.date_of_old_replenised == (Columns.date_of_old_replenised & columns))
                qry.Append("date_of_old_replenised,");
            if (Columns.location == (Columns.location & columns))
                qry.Append("location,");
            if (Columns.atm_no == (Columns.atm_no & columns))
                qry.Append("atm_no,");
            if (Columns.total_returned == (Columns.total_returned & columns))
                qry.Append("total_returned,");
            if (Columns.cash_rem_denomination_type1 == (Columns.cash_rem_denomination_type1 & columns))
                qry.Append("cash_rem_denomination_type1,");
            if (Columns.cash_rem_counters_type1 == (Columns.cash_rem_counters_type1 & columns))
                qry.Append("cash_rem_counters_type1,");
            if (Columns.cash_rem_denomination_type2 == (Columns.cash_rem_denomination_type2 & columns))
                qry.Append("cash_rem_denomination_type2,");
            if (Columns.cash_rem_counters_type2 == (Columns.cash_rem_counters_type2 & columns))
                qry.Append("cash_rem_counters_type2,");
            if (Columns.cash_rem_denomination_type3 == (Columns.cash_rem_denomination_type3 & columns))
                qry.Append("cash_rem_denomination_type3,");
            if (Columns.cash_rem_counters_type3 == (Columns.cash_rem_counters_type3 & columns))
                qry.Append("cash_rem_counters_type3,");
            if (Columns.cash_rem_denomination_type4 == (Columns.cash_rem_denomination_type4 & columns))
                qry.Append("cash_rem_denomination_type4,");
            if (Columns.cash_rem_counters_type4 == (Columns.cash_rem_counters_type4 & columns))
                qry.Append("cash_rem_counters_type4,");
            if (Columns.previous_rep_date == (Columns.previous_rep_date & columns))
                qry.Append("previous_rep_date,");
            if (Columns.journal_no == (Columns.journal_no & columns))
                qry.Append("journal_no,");
            if (Columns.total_rejected == (Columns.total_rejected & columns))
                qry.Append("total_rejected,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.modified_on == (Columns.modified_on & columns))
                qry.Append("modified_on,");
            if (Columns.atm_settlement_info_id == (Columns.atm_settlement_info_id & columns))
                qry.Append("atm_settlement_info_id,");
            if (Columns.cash_dep_total_type1 == (Columns.cash_dep_total_type1 & columns))
                qry.Append("cash_dep_total_type1,");
            if (Columns.cash_dep_total_type2 == (Columns.cash_dep_total_type2 & columns))
                qry.Append("cash_dep_total_type2,");
            if (Columns.cash_dep_total_type3 == (Columns.cash_dep_total_type3 & columns))
                qry.Append("cash_dep_total_type3,");
            if (Columns.cash_dep_total_type4 == (Columns.cash_dep_total_type4 & columns))
                qry.Append("cash_dep_total_type4,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Atm_settlement ");

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
            return new AtmSettlementReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AtmSettlementReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AtmSettlementReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select gl_no,rep_datetime,seal_number,cash_rep_denomination_type1,cash_rep_counters_type1,cash_rep_denomination_type2,cash_rep_counters_type2,cash_rep_denomination_type3,cash_rep_counters_type3,cash_rep_denomination_type4,cash_rep_counters_type4,cash_return_denomination_type1,cash_return_counters_type1,cash_return_denomination_type2,cash_return_counters_type2,cash_return_denomination_type3,cash_return_counters_type3,cash_return_denomination_type4,cash_return_counters_type4,cash_dispensed_denomination_type1,cash_dispensed_counters_type1,cash_dispensed_denomination_type2,cash_dispensed_counters_type2,cash_dispensed_denomination_type3,cash_dispensed_counters_type3,cash_dispensed_denomination_type4,cash_dispensed_counters_type4,cash_rejected_denomination_type1,cash_rejected_counters_type1,cash_rejected_denomination_type2,cash_rejected_counters_type2,cash_rejected_denomination_type3,cash_rejected_counters_type3,cash_rejected_denomination_type4,cash_rejected_counters_type4,atm_settlement_id,uploaded_by,upload_datetime,atm_site_and_number,total_replenished,date_of_old_replenised,location,atm_no,total_returned,cash_rem_denomination_type1,cash_rem_counters_type1,cash_rem_denomination_type2,cash_rem_counters_type2,cash_rem_denomination_type3,cash_rem_counters_type3,cash_rem_denomination_type4,cash_rem_counters_type4,previous_rep_date,journal_no,total_rejected,modified_by,modified_on,atm_settlement_info_id,cash_dep_total_type1,cash_dep_total_type2,cash_dep_total_type3,cash_dep_total_type4 from Atm_settlement ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmSettlementReader(cmd.ExecuteReader(), conn);
        }

        static public AtmSettlementReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static AtmSettlement LoadAtmSettlement(string where)
        {
            AtmSettlementReader reader = AtmSettlement.ExecuteReader(where);
            AtmSettlement _atmsettlement = null;
            if (reader.Read())
                _atmsettlement = reader.CurrentAtmSettlement;
            reader.Close();
            return _atmsettlement;
        }

        public static AtmSettlement LoadAtmSettlement(string where, IDbConnection conn)
        {
            AtmSettlementReader reader = AtmSettlement.ExecuteReader(where, conn);
            AtmSettlement _atmsettlement = null;
            if (reader.Read())
                _atmsettlement = reader.CurrentAtmSettlement;
            reader.Close(false);
            return _atmsettlement;
        }

        public static AtmSettlement LoadAtmSettlementByPk(int atm_settlement_id)
        {
            return LoadAtmSettlement(" atm_settlement_id=" + atm_settlement_id);
        }

        public static AtmSettlement LoadAtmSettlementByPk(int atm_settlement_id, IDbConnection conn)
        {
            return LoadAtmSettlement(" atm_settlement_id=" + atm_settlement_id, conn);
        }

        public void Save()
        {
            if (gl_noChanged || rep_datetimeChanged || seal_numberChanged || cash_rep_denomination_type1Changed || cash_rep_counters_type1Changed || cash_rep_denomination_type2Changed || cash_rep_counters_type2Changed || cash_rep_denomination_type3Changed || cash_rep_counters_type3Changed || cash_rep_denomination_type4Changed || cash_rep_counters_type4Changed || cash_return_denomination_type1Changed || cash_return_counters_type1Changed || cash_return_denomination_type2Changed || cash_return_counters_type2Changed || cash_return_denomination_type3Changed || cash_return_counters_type3Changed || cash_return_denomination_type4Changed || cash_return_counters_type4Changed || cash_dispensed_denomination_type1Changed || cash_dispensed_counters_type1Changed || cash_dispensed_denomination_type2Changed || cash_dispensed_counters_type2Changed || cash_dispensed_denomination_type3Changed || cash_dispensed_counters_type3Changed || cash_dispensed_denomination_type4Changed || cash_dispensed_counters_type4Changed || cash_rejected_denomination_type1Changed || cash_rejected_counters_type1Changed || cash_rejected_denomination_type2Changed || cash_rejected_counters_type2Changed || cash_rejected_denomination_type3Changed || cash_rejected_counters_type3Changed || cash_rejected_denomination_type4Changed || cash_rejected_counters_type4Changed || atm_settlement_idChanged || uploaded_byChanged || upload_datetimeChanged || atm_site_and_numberChanged || total_replenishedChanged || date_of_old_replenisedChanged || locationChanged || atm_noChanged || total_returnedChanged || cash_rem_denomination_type1Changed || cash_rem_counters_type1Changed || cash_rem_denomination_type2Changed || cash_rem_counters_type2Changed || cash_rem_denomination_type3Changed || cash_rem_counters_type3Changed || cash_rem_denomination_type4Changed || cash_rem_counters_type4Changed || previous_rep_dateChanged || journal_noChanged || total_rejectedChanged || modified_byChanged || modified_onChanged || atm_settlement_info_idChanged || cash_dep_total_type1Changed || cash_dep_total_type2Changed || cash_dep_total_type3Changed || cash_dep_total_type4Changed)
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
            if (gl_noChanged || rep_datetimeChanged || seal_numberChanged || cash_rep_denomination_type1Changed || cash_rep_counters_type1Changed || cash_rep_denomination_type2Changed || cash_rep_counters_type2Changed || cash_rep_denomination_type3Changed || cash_rep_counters_type3Changed || cash_rep_denomination_type4Changed || cash_rep_counters_type4Changed || cash_return_denomination_type1Changed || cash_return_counters_type1Changed || cash_return_denomination_type2Changed || cash_return_counters_type2Changed || cash_return_denomination_type3Changed || cash_return_counters_type3Changed || cash_return_denomination_type4Changed || cash_return_counters_type4Changed || cash_dispensed_denomination_type1Changed || cash_dispensed_counters_type1Changed || cash_dispensed_denomination_type2Changed || cash_dispensed_counters_type2Changed || cash_dispensed_denomination_type3Changed || cash_dispensed_counters_type3Changed || cash_dispensed_denomination_type4Changed || cash_dispensed_counters_type4Changed || cash_rejected_denomination_type1Changed || cash_rejected_counters_type1Changed || cash_rejected_denomination_type2Changed || cash_rejected_counters_type2Changed || cash_rejected_denomination_type3Changed || cash_rejected_counters_type3Changed || cash_rejected_denomination_type4Changed || cash_rejected_counters_type4Changed || atm_settlement_idChanged || uploaded_byChanged || upload_datetimeChanged || atm_site_and_numberChanged || total_replenishedChanged || date_of_old_replenisedChanged || locationChanged || atm_noChanged || total_returnedChanged || cash_rem_denomination_type1Changed || cash_rem_counters_type1Changed || cash_rem_denomination_type2Changed || cash_rem_counters_type2Changed || cash_rem_denomination_type3Changed || cash_rem_counters_type3Changed || cash_rem_denomination_type4Changed || cash_rem_counters_type4Changed || previous_rep_dateChanged || journal_noChanged || total_rejectedChanged || modified_byChanged || modified_onChanged || atm_settlement_info_idChanged || cash_dep_total_type1Changed || cash_dep_total_type2Changed || cash_dep_total_type3Changed || cash_dep_total_type4Changed)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm_settlement( gl_no,rep_datetime,seal_number,cash_rep_denomination_type1,cash_rep_counters_type1,cash_rep_denomination_type2,cash_rep_counters_type2,cash_rep_denomination_type3,cash_rep_counters_type3,cash_rep_denomination_type4,cash_rep_counters_type4,cash_return_denomination_type1,cash_return_counters_type1,cash_return_denomination_type2,cash_return_counters_type2,cash_return_denomination_type3,cash_return_counters_type3,cash_return_denomination_type4,cash_return_counters_type4,cash_dispensed_denomination_type1,cash_dispensed_counters_type1,cash_dispensed_denomination_type2,cash_dispensed_counters_type2,cash_dispensed_denomination_type3,cash_dispensed_counters_type3,cash_dispensed_denomination_type4,cash_dispensed_counters_type4,cash_rejected_denomination_type1,cash_rejected_counters_type1,cash_rejected_denomination_type2,cash_rejected_counters_type2,cash_rejected_denomination_type3,cash_rejected_counters_type3,cash_rejected_denomination_type4,cash_rejected_counters_type4,atm_settlement_id,uploaded_by,upload_datetime,atm_site_and_number,total_replenished,date_of_old_replenised,location,atm_no,total_returned,cash_rem_denomination_type1,cash_rem_counters_type1,cash_rem_denomination_type2,cash_rem_counters_type2,cash_rem_denomination_type3,cash_rem_counters_type3,cash_rem_denomination_type4,cash_rem_counters_type4,previous_rep_date,journal_no,total_rejected,modified_by,modified_on,atm_settlement_info_id,cash_dep_total_type1,cash_dep_total_type2,cash_dep_total_type3,cash_dep_total_type4 ) values(");
                    qry.Append(gl_noDbString + ",");
                    qry.Append(rep_datetimeDbString + ",");
                    qry.Append(seal_numberDbString + ",");
                    qry.Append(cash_rep_denomination_type1DbString + ",");
                    qry.Append(cash_rep_counters_type1DbString + ",");
                    qry.Append(cash_rep_denomination_type2DbString + ",");
                    qry.Append(cash_rep_counters_type2DbString + ",");
                    qry.Append(cash_rep_denomination_type3DbString + ",");
                    qry.Append(cash_rep_counters_type3DbString + ",");
                    qry.Append(cash_rep_denomination_type4DbString + ",");
                    qry.Append(cash_rep_counters_type4DbString + ",");
                    qry.Append(cash_return_denomination_type1DbString + ",");
                    qry.Append(cash_return_counters_type1DbString + ",");
                    qry.Append(cash_return_denomination_type2DbString + ",");
                    qry.Append(cash_return_counters_type2DbString + ",");
                    qry.Append(cash_return_denomination_type3DbString + ",");
                    qry.Append(cash_return_counters_type3DbString + ",");
                    qry.Append(cash_return_denomination_type4DbString + ",");
                    qry.Append(cash_return_counters_type4DbString + ",");
                    qry.Append(cash_dispensed_denomination_type1DbString + ",");
                    qry.Append(cash_dispensed_counters_type1DbString + ",");
                    qry.Append(cash_dispensed_denomination_type2DbString + ",");
                    qry.Append(cash_dispensed_counters_type2DbString + ",");
                    qry.Append(cash_dispensed_denomination_type3DbString + ",");
                    qry.Append(cash_dispensed_counters_type3DbString + ",");
                    qry.Append(cash_dispensed_denomination_type4DbString + ",");
                    qry.Append(cash_dispensed_counters_type4DbString + ",");
                    qry.Append(cash_rejected_denomination_type1DbString + ",");
                    qry.Append(cash_rejected_counters_type1DbString + ",");
                    qry.Append(cash_rejected_denomination_type2DbString + ",");
                    qry.Append(cash_rejected_counters_type2DbString + ",");
                    qry.Append(cash_rejected_denomination_type3DbString + ",");
                    qry.Append(cash_rejected_counters_type3DbString + ",");
                    qry.Append(cash_rejected_denomination_type4DbString + ",");
                    qry.Append(cash_rejected_counters_type4DbString + ",");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.atm_settlement_id = ConnectionFactory.GetNextId();
                        qry.Append(this.atm_settlement_id);
                    } qry.Append(",");
                    qry.Append(uploaded_byDbString + ",");
                    qry.Append(upload_datetimeDbString + ",");
                    qry.Append(atm_site_and_numberDbString + ",");
                    qry.Append(total_replenishedDbString + ",");
                    qry.Append(date_of_old_replenisedDbString + ",");
                    qry.Append(locationDbString + ",");
                    qry.Append(atm_noDbString + ",");
                    qry.Append(total_returnedDbString + ",");
                    qry.Append(cash_rem_denomination_type1DbString + ",");
                    qry.Append(cash_rem_counters_type1DbString + ",");
                    qry.Append(cash_rem_denomination_type2DbString + ",");
                    qry.Append(cash_rem_counters_type2DbString + ",");
                    qry.Append(cash_rem_denomination_type3DbString + ",");
                    qry.Append(cash_rem_counters_type3DbString + ",");
                    qry.Append(cash_rem_denomination_type4DbString + ",");
                    qry.Append(cash_rem_counters_type4DbString + ",");
                    qry.Append(previous_rep_dateDbString + ",");
                    qry.Append(journal_noDbString + ",");
                    qry.Append(total_rejectedDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(modified_onDbString + ",");
                    qry.Append(atm_settlement_info_idDbString + ",");
                    qry.Append(cash_dep_total_type1DbString + ",");
                    qry.Append(cash_dep_total_type2DbString + ",");
                    qry.Append(cash_dep_total_type3DbString + ",");
                    qry.Append(cash_dep_total_type4DbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(gl_noChanged || rep_datetimeChanged || seal_numberChanged || cash_rep_denomination_type1Changed || cash_rep_counters_type1Changed || cash_rep_denomination_type2Changed || cash_rep_counters_type2Changed || cash_rep_denomination_type3Changed || cash_rep_counters_type3Changed || cash_rep_denomination_type4Changed || cash_rep_counters_type4Changed || cash_return_denomination_type1Changed || cash_return_counters_type1Changed || cash_return_denomination_type2Changed || cash_return_counters_type2Changed || cash_return_denomination_type3Changed || cash_return_counters_type3Changed || cash_return_denomination_type4Changed || cash_return_counters_type4Changed || cash_dispensed_denomination_type1Changed || cash_dispensed_counters_type1Changed || cash_dispensed_denomination_type2Changed || cash_dispensed_counters_type2Changed || cash_dispensed_denomination_type3Changed || cash_dispensed_counters_type3Changed || cash_dispensed_denomination_type4Changed || cash_dispensed_counters_type4Changed || cash_rejected_denomination_type1Changed || cash_rejected_counters_type1Changed || cash_rejected_denomination_type2Changed || cash_rejected_counters_type2Changed || cash_rejected_denomination_type3Changed || cash_rejected_counters_type3Changed || cash_rejected_denomination_type4Changed || cash_rejected_counters_type4Changed || atm_settlement_idChanged || uploaded_byChanged || upload_datetimeChanged || atm_site_and_numberChanged || total_replenishedChanged || date_of_old_replenisedChanged || locationChanged || atm_noChanged || total_returnedChanged || cash_rem_denomination_type1Changed || cash_rem_counters_type1Changed || cash_rem_denomination_type2Changed || cash_rem_counters_type2Changed || cash_rem_denomination_type3Changed || cash_rem_counters_type3Changed || cash_rem_denomination_type4Changed || cash_rem_counters_type4Changed || previous_rep_dateChanged || journal_noChanged || total_rejectedChanged || modified_byChanged || modified_onChanged || atm_settlement_info_idChanged || cash_dep_total_type1Changed || cash_dep_total_type2Changed || cash_dep_total_type3Changed || cash_dep_total_type4Changed))
                        return;
                    qry.Append("UPDATE Atm_settlement set "); if (gl_noChanged)
                    {
                        qry.Append("gl_no =" + gl_noDbString);
                        qry.Append(",");
                    }

                    if (rep_datetimeChanged)
                    {
                        qry.Append("rep_datetime =" + rep_datetimeDbString);
                        qry.Append(",");
                    }

                    if (seal_numberChanged)
                    {
                        qry.Append("seal_number =" + seal_numberDbString);
                        qry.Append(",");
                    }

                    if (cash_rep_denomination_type1Changed)
                    {
                        qry.Append("cash_rep_denomination_type1 =" + cash_rep_denomination_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_counters_type1Changed)
                    {
                        qry.Append("cash_rep_counters_type1 =" + cash_rep_counters_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_denomination_type2Changed)
                    {
                        qry.Append("cash_rep_denomination_type2 =" + cash_rep_denomination_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_counters_type2Changed)
                    {
                        qry.Append("cash_rep_counters_type2 =" + cash_rep_counters_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_denomination_type3Changed)
                    {
                        qry.Append("cash_rep_denomination_type3 =" + cash_rep_denomination_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_counters_type3Changed)
                    {
                        qry.Append("cash_rep_counters_type3 =" + cash_rep_counters_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_denomination_type4Changed)
                    {
                        qry.Append("cash_rep_denomination_type4 =" + cash_rep_denomination_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_rep_counters_type4Changed)
                    {
                        qry.Append("cash_rep_counters_type4 =" + cash_rep_counters_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_return_denomination_type1Changed)
                    {
                        qry.Append("cash_return_denomination_type1 =" + cash_return_denomination_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_return_counters_type1Changed)
                    {
                        qry.Append("cash_return_counters_type1 =" + cash_return_counters_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_return_denomination_type2Changed)
                    {
                        qry.Append("cash_return_denomination_type2 =" + cash_return_denomination_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_return_counters_type2Changed)
                    {
                        qry.Append("cash_return_counters_type2 =" + cash_return_counters_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_return_denomination_type3Changed)
                    {
                        qry.Append("cash_return_denomination_type3 =" + cash_return_denomination_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_return_counters_type3Changed)
                    {
                        qry.Append("cash_return_counters_type3 =" + cash_return_counters_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_return_denomination_type4Changed)
                    {
                        qry.Append("cash_return_denomination_type4 =" + cash_return_denomination_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_return_counters_type4Changed)
                    {
                        qry.Append("cash_return_counters_type4 =" + cash_return_counters_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_denomination_type1Changed)
                    {
                        qry.Append("cash_dispensed_denomination_type1 =" + cash_dispensed_denomination_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_counters_type1Changed)
                    {
                        qry.Append("cash_dispensed_counters_type1 =" + cash_dispensed_counters_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_denomination_type2Changed)
                    {
                        qry.Append("cash_dispensed_denomination_type2 =" + cash_dispensed_denomination_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_counters_type2Changed)
                    {
                        qry.Append("cash_dispensed_counters_type2 =" + cash_dispensed_counters_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_denomination_type3Changed)
                    {
                        qry.Append("cash_dispensed_denomination_type3 =" + cash_dispensed_denomination_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_counters_type3Changed)
                    {
                        qry.Append("cash_dispensed_counters_type3 =" + cash_dispensed_counters_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_denomination_type4Changed)
                    {
                        qry.Append("cash_dispensed_denomination_type4 =" + cash_dispensed_denomination_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed_counters_type4Changed)
                    {
                        qry.Append("cash_dispensed_counters_type4 =" + cash_dispensed_counters_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_denomination_type1Changed)
                    {
                        qry.Append("cash_rejected_denomination_type1 =" + cash_rejected_denomination_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_counters_type1Changed)
                    {
                        qry.Append("cash_rejected_counters_type1 =" + cash_rejected_counters_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_denomination_type2Changed)
                    {
                        qry.Append("cash_rejected_denomination_type2 =" + cash_rejected_denomination_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_counters_type2Changed)
                    {
                        qry.Append("cash_rejected_counters_type2 =" + cash_rejected_counters_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_denomination_type3Changed)
                    {
                        qry.Append("cash_rejected_denomination_type3 =" + cash_rejected_denomination_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_counters_type3Changed)
                    {
                        qry.Append("cash_rejected_counters_type3 =" + cash_rejected_counters_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_denomination_type4Changed)
                    {
                        qry.Append("cash_rejected_denomination_type4 =" + cash_rejected_denomination_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_rejected_counters_type4Changed)
                    {
                        qry.Append("cash_rejected_counters_type4 =" + cash_rejected_counters_type4DbString);
                        qry.Append(",");
                    }

                    if (uploaded_byChanged)
                    {
                        qry.Append("uploaded_by =" + uploaded_byDbString);
                        qry.Append(",");
                    }

                    if (upload_datetimeChanged)
                    {
                        qry.Append("upload_datetime =" + upload_datetimeDbString);
                        qry.Append(",");
                    }

                    if (atm_site_and_numberChanged)
                    {
                        qry.Append("atm_site_and_number =" + atm_site_and_numberDbString);
                        qry.Append(",");
                    }

                    if (total_replenishedChanged)
                    {
                        qry.Append("total_replenished =" + total_replenishedDbString);
                        qry.Append(",");
                    }

                    if (date_of_old_replenisedChanged)
                    {
                        qry.Append("date_of_old_replenised =" + date_of_old_replenisedDbString);
                        qry.Append(",");
                    }

                    if (locationChanged)
                    {
                        qry.Append("location =" + locationDbString);
                        qry.Append(",");
                    }

                    if (atm_noChanged)
                    {
                        qry.Append("atm_no =" + atm_noDbString);
                        qry.Append(",");
                    }

                    if (total_returnedChanged)
                    {
                        qry.Append("total_returned =" + total_returnedDbString);
                        qry.Append(",");
                    }

                    if (cash_rem_denomination_type1Changed)
                    {
                        qry.Append("cash_rem_denomination_type1 =" + cash_rem_denomination_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_counters_type1Changed)
                    {
                        qry.Append("cash_rem_counters_type1 =" + cash_rem_counters_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_denomination_type2Changed)
                    {
                        qry.Append("cash_rem_denomination_type2 =" + cash_rem_denomination_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_counters_type2Changed)
                    {
                        qry.Append("cash_rem_counters_type2 =" + cash_rem_counters_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_denomination_type3Changed)
                    {
                        qry.Append("cash_rem_denomination_type3 =" + cash_rem_denomination_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_counters_type3Changed)
                    {
                        qry.Append("cash_rem_counters_type3 =" + cash_rem_counters_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_denomination_type4Changed)
                    {
                        qry.Append("cash_rem_denomination_type4 =" + cash_rem_denomination_type4DbString);
                        qry.Append(",");
                    }

                    if (cash_rem_counters_type4Changed)
                    {
                        qry.Append("cash_rem_counters_type4 =" + cash_rem_counters_type4DbString);
                        qry.Append(",");
                    }

                    if (previous_rep_dateChanged)
                    {
                        qry.Append("previous_rep_date =" + previous_rep_dateDbString);
                        qry.Append(",");
                    }

                    if (journal_noChanged)
                    {
                        qry.Append("journal_no =" + journal_noDbString);
                        qry.Append(",");
                    }

                    if (total_rejectedChanged)
                    {
                        qry.Append("total_rejected =" + total_rejectedDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }

                    if (modified_onChanged)
                    {
                        qry.Append("modified_on =" + modified_onDbString);
                        qry.Append(",");
                    }

                    if (atm_settlement_info_idChanged)
                    {
                        qry.Append("atm_settlement_info_id =" + atm_settlement_info_idDbString);
                        qry.Append(",");
                    }

                    if (cash_dep_total_type1Changed)
                    {
                        qry.Append("cash_dep_total_type1 =" + cash_dep_total_type1DbString);
                        qry.Append(",");
                    }

                    if (cash_dep_total_type2Changed)
                    {
                        qry.Append("cash_dep_total_type2 =" + cash_dep_total_type2DbString);
                        qry.Append(",");
                    }

                    if (cash_dep_total_type3Changed)
                    {
                        qry.Append("cash_dep_total_type3 =" + cash_dep_total_type3DbString);
                        qry.Append(",");
                    }

                    if (cash_dep_total_type4Changed)
                    {
                        qry.Append("cash_dep_total_type4 =" + cash_dep_total_type4DbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("atm_settlement_id = " + atm_settlement_idDbString);
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
            cmd.CommandText = "DELETE Atm_settlement where atm_settlement_id = " + atm_settlement_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAtmSettlements(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Atm_settlement where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            gl_no = 1,
            rep_datetime = 2,
            seal_number = 4,
            cash_rep_denomination_type1 = 8,
            cash_rep_counters_type1 = 16,
            cash_rep_denomination_type2 = 32,
            cash_rep_counters_type2 = 64,
            cash_rep_denomination_type3 = 128,
            cash_rep_counters_type3 = 256,
            cash_rep_denomination_type4 = 512,
            cash_rep_counters_type4 = 1024,
            cash_return_denomination_type1 = 2048,
            cash_return_counters_type1 = 4096,
            cash_return_denomination_type2 = 8192,
            cash_return_counters_type2 = 16384,
            cash_return_denomination_type3 = 32768,
            cash_return_counters_type3 = 65536,
            cash_return_denomination_type4 = 131072,
            cash_return_counters_type4 = 262144,
            cash_dispensed_denomination_type1 = 524288,
            cash_dispensed_counters_type1 = 1048576,
            cash_dispensed_denomination_type2 = 2097152,
            cash_dispensed_counters_type2 = 4194304,
            cash_dispensed_denomination_type3 = 8388608,
            cash_dispensed_counters_type3 = 16777216,
            cash_dispensed_denomination_type4 = 33554432,
            cash_dispensed_counters_type4 = 67108864,
            cash_rejected_denomination_type1 = 134217728,
            cash_rejected_counters_type1 = 268435456,
            cash_rejected_denomination_type2 = 536870912,
            cash_rejected_counters_type2 = 1073741824,
            cash_rejected_denomination_type3 = 2147483648,
            cash_rejected_counters_type3 = 4294967296,
            cash_rejected_denomination_type4 = 8589934592,
            cash_rejected_counters_type4 = 17179869184,
            atm_settlement_id = 34359738368,
            uploaded_by = 68719476736,
            upload_datetime = 137438953472,
            atm_site_and_number = 274877906944,
            total_replenished = 549755813888,
            date_of_old_replenised = 1099511627776,
            location = 2199023255552,
            atm_no = 4398046511104,
            total_returned = 8796093022208,
            cash_rem_denomination_type1 = 17592186044416,
            cash_rem_counters_type1 = 35184372088832,
            cash_rem_denomination_type2 = 70368744177664,
            cash_rem_counters_type2 = 140737488355328,
            cash_rem_denomination_type3 = 281474976710656,
            cash_rem_counters_type3 = 562949953421312,
            cash_rem_denomination_type4 = 1125899906842624,
            cash_rem_counters_type4 = 2251799813685248,
            previous_rep_date = 4503599627370496,
            journal_no = 9007199254740992,
            total_rejected = 18014398509481984,
            modified_by = 36028797018963968,
            modified_on = 72057594037927936,
            atm_settlement_info_id = 144115188075855872,
            cash_dep_total_type1 = 288230376151711744,
            cash_dep_total_type2 = 576460752303423488,
            cash_dep_total_type3 = 1152921504606846976,
            cash_dep_total_type4 = 2305843009213693952
        }
        #endregion
        public void BulkSave(List<AtmSettlement> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Atm_settlement";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(AtmSettlement.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<AtmSettlement> transList, ref DataTable dt)
        {
            foreach (AtmSettlement tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["gl_no"] = tran.GlNo;
                Row["rep_datetime"] = tran.RepDatetime;
                Row["seal_number"] = tran.SealNumber;
                Row["cash_rep_denomination_type1"] = tran.CashRepDenominationType1;
                Row["cash_rep_counters_type1"] = tran.CashRepCountersType1;
                Row["cash_rep_denomination_type2"] = tran.CashRepDenominationType2;
                Row["cash_rep_counters_type2"] = tran.CashRepCountersType2;
                Row["cash_rep_denomination_type3"] = tran.CashRepDenominationType3;
                Row["cash_rep_counters_type3"] = tran.CashRepCountersType3;
                Row["cash_rep_denomination_type4"] = tran.CashRepDenominationType4;
                Row["cash_rep_counters_type4"] = tran.CashRepCountersType4;
                Row["cash_return_denomination_type1"] = tran.CashReturnDenominationType1;
                Row["cash_return_counters_type1"] = tran.CashReturnCountersType1;
                Row["cash_return_denomination_type2"] = tran.CashReturnDenominationType2;
                Row["cash_return_counters_type2"] = tran.CashReturnCountersType2;
                Row["cash_return_denomination_type3"] = tran.CashReturnDenominationType3;
                Row["cash_return_counters_type3"] = tran.CashReturnCountersType3;
                Row["cash_return_denomination_type4"] = tran.CashReturnDenominationType4;
                Row["cash_return_counters_type4"] = tran.CashReturnCountersType4;
                Row["cash_dispensed_denomination_type1"] = tran.CashDispensedDenominationType1;
                Row["cash_dispensed_counters_type1"] = tran.CashDispensedCountersType1;
                Row["cash_dispensed_denomination_type2"] = tran.CashDispensedDenominationType2;
                Row["cash_dispensed_counters_type2"] = tran.CashDispensedCountersType2;
                Row["cash_dispensed_denomination_type3"] = tran.CashDispensedDenominationType3;
                Row["cash_dispensed_counters_type3"] = tran.CashDispensedCountersType3;
                Row["cash_dispensed_denomination_type4"] = tran.CashDispensedDenominationType4;
                Row["cash_dispensed_counters_type4"] = tran.CashDispensedCountersType4;
                Row["cash_rejected_denomination_type1"] = tran.CashRejectedDenominationType1;
                Row["cash_rejected_counters_type1"] = tran.CashRejectedCountersType1;
                Row["cash_rejected_denomination_type2"] = tran.CashRejectedDenominationType2;
                Row["cash_rejected_counters_type2"] = tran.CashRejectedCountersType2;
                Row["cash_rejected_denomination_type3"] = tran.CashRejectedDenominationType3;
                Row["cash_rejected_counters_type3"] = tran.CashRejectedCountersType3;
                Row["cash_rejected_denomination_type4"] = tran.CashRejectedDenominationType4;
                Row["cash_rejected_counters_type4"] = tran.CashRejectedCountersType4;
                Row["atm_settlement_id"] = ConnectionFactory.GetNextId();
                Row["uploaded_by"] = tran.UploadedBy;
                Row["upload_datetime"] = tran.UploadDatetime;
                Row["atm_site_and_number"] = tran.AtmSiteAndNumber;
                Row["total_replenished"] = tran.TotalReplenished;
                Row["date_of_old_replenised"] = tran.DateOfOldReplenised;
                Row["location"] = tran.Location;
                Row["atm_no"] = tran.AtmNo;
                Row["total_returned"] = tran.TotalReturned;
                Row["cash_rem_denomination_type1"] = tran.CashRemDenominationType1;
                Row["cash_rem_counters_type1"] = tran.CashRemCountersType1;
                Row["cash_rem_denomination_type2"] = tran.CashRemDenominationType2;
                Row["cash_rem_counters_type2"] = tran.CashRemCountersType2;
                Row["cash_rem_denomination_type3"] = tran.CashRemDenominationType3;
                Row["cash_rem_counters_type3"] = tran.CashRemCountersType3;
                Row["cash_rem_denomination_type4"] = tran.CashRemDenominationType4;
                Row["cash_rem_counters_type4"] = tran.CashRemCountersType4;
                Row["previous_rep_date"] = tran.PreviousRepDate;
                Row["journal_no"] = tran.JournalNo;
                Row["total_rejected"] = tran.TotalRejected;
                Row["modified_by"] = tran.ModifiedBy;
                Row["modified_on"] = tran.ModifiedOn;
                Row["atm_settlement_info_id"] = tran.AtmSettlementInfoId;
                Row["cash_dep_total_type1"] = tran.CashDepTotalType1;
                Row["cash_dep_total_type2"] = tran.CashDepTotalType2;
                Row["cash_dep_total_type3"] = tran.CashDepTotalType3;
                Row["cash_dep_total_type4"] = tran.CashDepTotalType4;
                dt.Rows.Add(Row);
            }
        }
    }
}