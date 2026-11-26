using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class ParsedTransactionCdmDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ParsedTransactionCdmDetail() { }
        public ParsedTransactionCdmDetail(long parsed_transaction_cdm_detail_id, int atm_id, DateTime trxn_datetime)
        {
            this.parsed_transaction_cdm_detail_id = parsed_transaction_cdm_detail_id;
            this.parsed_transaction_cdm_detail_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
        }
        public ParsedTransactionCdmDetail(int atm_id, DateTime trxn_datetime, string cdm2_raw1, string cdm2_raw2, string cdm2_raw3, string cdm2_raw4, int? cdm2_denom1, int? cdm2_initial1, int? cdm2_dispensed1, int? cdm2_remaining1, int? cdm2_purged1, int? cdm2_denom2, int? cdm2_initial2, int? cdm2_dispensed2, int? cdm2_remaining2, int? cdm2_purged2, int? cdm2_denom3, int? cdm2_initial3, int? cdm2_dispensed3, int? cdm2_remaining3, int? cdm2_purged3, int? cdm2_denom4, int? cdm2_initial4, int? cdm2_dispensed4, int? cdm2_remaining4, int? cdm2_purged4, string cdm1_raw1, string cdm1_raw2, string cdm1_raw3, string cdm1_raw4, int? cdm1_denom1, int? cdm1_remaining1, int? cdm1_dispensed1, int? cdm1_denom2, int? cdm1_remaining2, int? cdm1_dispensed2, int? cdm1_denom3, int? cdm1_remaining3, int? cdm1_dispensed3, int? cdm1_denom4, int? cdm1_remaining4, int? cdm1_dispensed4, DateTime? processing_datetime)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.cdm2_raw1 = cdm2_raw1;
            this.cdm2_raw1Changed = true;
            this.cdm2_raw2 = cdm2_raw2;
            this.cdm2_raw2Changed = true;
            this.cdm2_raw3 = cdm2_raw3;
            this.cdm2_raw3Changed = true;
            this.cdm2_raw4 = cdm2_raw4;
            this.cdm2_raw4Changed = true;
            this.cdm2_denom1 = cdm2_denom1;
            this.cdm2_denom1Changed = true;
            this.cdm2_initial1 = cdm2_initial1;
            this.cdm2_initial1Changed = true;
            this.cdm2_dispensed1 = cdm2_dispensed1;
            this.cdm2_dispensed1Changed = true;
            this.cdm2_remaining1 = cdm2_remaining1;
            this.cdm2_remaining1Changed = true;
            this.cdm2_purged1 = cdm2_purged1;
            this.cdm2_purged1Changed = true;
            this.cdm2_denom2 = cdm2_denom2;
            this.cdm2_denom2Changed = true;
            this.cdm2_initial2 = cdm2_initial2;
            this.cdm2_initial2Changed = true;
            this.cdm2_dispensed2 = cdm2_dispensed2;
            this.cdm2_dispensed2Changed = true;
            this.cdm2_remaining2 = cdm2_remaining2;
            this.cdm2_remaining2Changed = true;
            this.cdm2_purged2 = cdm2_purged2;
            this.cdm2_purged2Changed = true;
            this.cdm2_denom3 = cdm2_denom3;
            this.cdm2_denom3Changed = true;
            this.cdm2_initial3 = cdm2_initial3;
            this.cdm2_initial3Changed = true;
            this.cdm2_dispensed3 = cdm2_dispensed3;
            this.cdm2_dispensed3Changed = true;
            this.cdm2_remaining3 = cdm2_remaining3;
            this.cdm2_remaining3Changed = true;
            this.cdm2_purged3 = cdm2_purged3;
            this.cdm2_purged3Changed = true;
            this.cdm2_denom4 = cdm2_denom4;
            this.cdm2_denom4Changed = true;
            this.cdm2_initial4 = cdm2_initial4;
            this.cdm2_initial4Changed = true;
            this.cdm2_dispensed4 = cdm2_dispensed4;
            this.cdm2_dispensed4Changed = true;
            this.cdm2_remaining4 = cdm2_remaining4;
            this.cdm2_remaining4Changed = true;
            this.cdm2_purged4 = cdm2_purged4;
            this.cdm2_purged4Changed = true;
            this.cdm1_raw1 = cdm1_raw1;
            this.cdm1_raw1Changed = true;
            this.cdm1_raw2 = cdm1_raw2;
            this.cdm1_raw2Changed = true;
            this.cdm1_raw3 = cdm1_raw3;
            this.cdm1_raw3Changed = true;
            this.cdm1_raw4 = cdm1_raw4;
            this.cdm1_raw4Changed = true;
            this.cdm1_denom1 = cdm1_denom1;
            this.cdm1_denom1Changed = true;
            this.cdm1_remaining1 = cdm1_remaining1;
            this.cdm1_remaining1Changed = true;
            this.cdm1_dispensed1 = cdm1_dispensed1;
            this.cdm1_dispensed1Changed = true;
            this.cdm1_denom2 = cdm1_denom2;
            this.cdm1_denom2Changed = true;
            this.cdm1_remaining2 = cdm1_remaining2;
            this.cdm1_remaining2Changed = true;
            this.cdm1_dispensed2 = cdm1_dispensed2;
            this.cdm1_dispensed2Changed = true;
            this.cdm1_denom3 = cdm1_denom3;
            this.cdm1_denom3Changed = true;
            this.cdm1_remaining3 = cdm1_remaining3;
            this.cdm1_remaining3Changed = true;
            this.cdm1_dispensed3 = cdm1_dispensed3;
            this.cdm1_dispensed3Changed = true;
            this.cdm1_denom4 = cdm1_denom4;
            this.cdm1_denom4Changed = true;
            this.cdm1_remaining4 = cdm1_remaining4;
            this.cdm1_remaining4Changed = true;
            this.cdm1_dispensed4 = cdm1_dispensed4;
            this.cdm1_dispensed4Changed = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
        }
        private ParsedTransactionCdmDetail(long parsed_transaction_cdm_detail_id, int atm_id, int? task_id, DateTime trxn_datetime, string cdm2_raw1, string cdm2_raw2, string cdm2_raw3, string cdm2_raw4, int? cdm2_denom1, int? cdm2_initial1, int? cdm2_dispensed1, int? cdm2_remaining1, int? cdm2_purged1, int? cdm2_denom2, int? cdm2_initial2, int? cdm2_dispensed2, int? cdm2_remaining2, int? cdm2_purged2, int? cdm2_denom3, int? cdm2_initial3, int? cdm2_dispensed3, int? cdm2_remaining3, int? cdm2_purged3, int? cdm2_denom4, int? cdm2_initial4, int? cdm2_dispensed4, int? cdm2_remaining4, int? cdm2_purged4, string cdm1_raw1, string cdm1_raw2, string cdm1_raw3, string cdm1_raw4, int? cdm1_denom1, int? cdm1_remaining1, int? cdm1_dispensed1, int? cdm1_denom2, int? cdm1_remaining2, int? cdm1_dispensed2, int? cdm1_denom3, int? cdm1_remaining3, int? cdm1_dispensed3, int? cdm1_denom4, int? cdm1_remaining4, int? cdm1_dispensed4, DateTime? processing_datetime)
        {
            this.parsed_transaction_cdm_detail_id = parsed_transaction_cdm_detail_id;
            this.parsed_transaction_cdm_detail_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.cdm2_raw1 = cdm2_raw1;
            this.cdm2_raw1Changed = true;
            this.cdm2_raw2 = cdm2_raw2;
            this.cdm2_raw2Changed = true;
            this.cdm2_raw3 = cdm2_raw3;
            this.cdm2_raw3Changed = true;
            this.cdm2_raw4 = cdm2_raw4;
            this.cdm2_raw4Changed = true;
            this.cdm2_denom1 = cdm2_denom1;
            this.cdm2_denom1Changed = true;
            this.cdm2_initial1 = cdm2_initial1;
            this.cdm2_initial1Changed = true;
            this.cdm2_dispensed1 = cdm2_dispensed1;
            this.cdm2_dispensed1Changed = true;
            this.cdm2_remaining1 = cdm2_remaining1;
            this.cdm2_remaining1Changed = true;
            this.cdm2_purged1 = cdm2_purged1;
            this.cdm2_purged1Changed = true;
            this.cdm2_denom2 = cdm2_denom2;
            this.cdm2_denom2Changed = true;
            this.cdm2_initial2 = cdm2_initial2;
            this.cdm2_initial2Changed = true;
            this.cdm2_dispensed2 = cdm2_dispensed2;
            this.cdm2_dispensed2Changed = true;
            this.cdm2_remaining2 = cdm2_remaining2;
            this.cdm2_remaining2Changed = true;
            this.cdm2_purged2 = cdm2_purged2;
            this.cdm2_purged2Changed = true;
            this.cdm2_denom3 = cdm2_denom3;
            this.cdm2_denom3Changed = true;
            this.cdm2_initial3 = cdm2_initial3;
            this.cdm2_initial3Changed = true;
            this.cdm2_dispensed3 = cdm2_dispensed3;
            this.cdm2_dispensed3Changed = true;
            this.cdm2_remaining3 = cdm2_remaining3;
            this.cdm2_remaining3Changed = true;
            this.cdm2_purged3 = cdm2_purged3;
            this.cdm2_purged3Changed = true;
            this.cdm2_denom4 = cdm2_denom4;
            this.cdm2_denom4Changed = true;
            this.cdm2_initial4 = cdm2_initial4;
            this.cdm2_initial4Changed = true;
            this.cdm2_dispensed4 = cdm2_dispensed4;
            this.cdm2_dispensed4Changed = true;
            this.cdm2_remaining4 = cdm2_remaining4;
            this.cdm2_remaining4Changed = true;
            this.cdm2_purged4 = cdm2_purged4;
            this.cdm2_purged4Changed = true;
            this.cdm1_raw1 = cdm1_raw1;
            this.cdm1_raw1Changed = true;
            this.cdm1_raw2 = cdm1_raw2;
            this.cdm1_raw2Changed = true;
            this.cdm1_raw3 = cdm1_raw3;
            this.cdm1_raw3Changed = true;
            this.cdm1_raw4 = cdm1_raw4;
            this.cdm1_raw4Changed = true;
            this.cdm1_denom1 = cdm1_denom1;
            this.cdm1_denom1Changed = true;
            this.cdm1_remaining1 = cdm1_remaining1;
            this.cdm1_remaining1Changed = true;
            this.cdm1_dispensed1 = cdm1_dispensed1;
            this.cdm1_dispensed1Changed = true;
            this.cdm1_denom2 = cdm1_denom2;
            this.cdm1_denom2Changed = true;
            this.cdm1_remaining2 = cdm1_remaining2;
            this.cdm1_remaining2Changed = true;
            this.cdm1_dispensed2 = cdm1_dispensed2;
            this.cdm1_dispensed2Changed = true;
            this.cdm1_denom3 = cdm1_denom3;
            this.cdm1_denom3Changed = true;
            this.cdm1_remaining3 = cdm1_remaining3;
            this.cdm1_remaining3Changed = true;
            this.cdm1_dispensed3 = cdm1_dispensed3;
            this.cdm1_dispensed3Changed = true;
            this.cdm1_denom4 = cdm1_denom4;
            this.cdm1_denom4Changed = true;
            this.cdm1_remaining4 = cdm1_remaining4;
            this.cdm1_remaining4Changed = true;
            this.cdm1_dispensed4 = cdm1_dispensed4;
            this.cdm1_dispensed4Changed = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }

        #region members and properties for columns

        #region ParsedTransactionCdmDetailID
        private bool parsed_transaction_cdm_detail_idChanged = false;
        private long parsed_transaction_cdm_detail_id;
        public long ParsedTransactionCdmDetailID
        {
            get { return parsed_transaction_cdm_detail_id; }
            set
            {
                parsed_transaction_cdm_detail_id = value;
                parsed_transaction_cdm_detail_idChanged = true;
            }
        }
        private string parsed_transaction_cdm_detail_idDbString
        {
            get
            {
                return parsed_transaction_cdm_detail_id.ToString();
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
        #region AtmId
        private bool atm_idChanged = false;
        private long atm_id;
        public long AtmId
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
        #region TrxnDatetime
        private bool trxn_datetimeChanged = false;
        private DateTime trxn_datetime;
        public DateTime TrxnDatetime
        {
            get { return trxn_datetime; }
            set
            {
                trxn_datetime = value;
                trxn_datetimeChanged = true;
            }
        }
        private string trxn_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", trxn_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region Cdm2Raw1
        private bool cdm2_raw1Changed = false;
        private string cdm2_raw1;
        public string Cdm2Raw1
        {
            get { return cdm2_raw1; }
            set
            {
                cdm2_raw1 = value;
                cdm2_raw1Changed = true;
            }
        }
        private string cdm2_raw1DbString
        {
            get
            {
                if (this.cdm2_raw1 != null)
                    return string.Format("'{0}'", cdm2_raw1);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Raw2
        private bool cdm2_raw2Changed = false;
        private string cdm2_raw2;
        public string Cdm2Raw2
        {
            get { return cdm2_raw2; }
            set
            {
                cdm2_raw2 = value;
                cdm2_raw2Changed = true;
            }
        }
        private string cdm2_raw2DbString
        {
            get
            {
                if (this.cdm2_raw2 != null)
                    return string.Format("'{0}'", cdm2_raw2);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Raw3
        private bool cdm2_raw3Changed = false;
        private string cdm2_raw3;
        public string Cdm2Raw3
        {
            get { return cdm2_raw3; }
            set
            {
                cdm2_raw3 = value;
                cdm2_raw3Changed = true;
            }
        }
        private string cdm2_raw3DbString
        {
            get
            {
                if (this.cdm2_raw3 != null)
                    return string.Format("'{0}'", cdm2_raw3);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Raw4
        private bool cdm2_raw4Changed = false;
        private string cdm2_raw4;
        public string Cdm2Raw4
        {
            get { return cdm2_raw4; }
            set
            {
                cdm2_raw4 = value;
                cdm2_raw4Changed = true;
            }
        }
        private string cdm2_raw4DbString
        {
            get
            {
                if (this.cdm2_raw4 != null)
                    return string.Format("'{0}'", cdm2_raw4);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Denom1
        private bool cdm2_denom1Changed = false;
        private int? cdm2_denom1;
        public int? Cdm2Denom1
        {
            get { return cdm2_denom1; }
            set
            {
                cdm2_denom1 = value;
                cdm2_denom1Changed = true;
            }
        }
        private string cdm2_denom1DbString
        {
            get
            {
                if (this.cdm2_denom1.HasValue)
                    return cdm2_denom1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Initial1
        private bool cdm2_initial1Changed = false;
        private int? cdm2_initial1;
        public int? Cdm2Initial1
        {
            get { return cdm2_initial1; }
            set
            {
                cdm2_initial1 = value;
                cdm2_initial1Changed = true;
            }
        }
        private string cdm2_initial1DbString
        {
            get
            {
                if (this.cdm2_initial1.HasValue)
                    return cdm2_initial1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Dispensed1
        private bool cdm2_dispensed1Changed = false;
        private int? cdm2_dispensed1;
        public int? Cdm2Dispensed1
        {
            get { return cdm2_dispensed1; }
            set
            {
                cdm2_dispensed1 = value;
                cdm2_dispensed1Changed = true;
            }
        }
        private string cdm2_dispensed1DbString
        {
            get
            {
                if (this.cdm2_dispensed1.HasValue)
                    return cdm2_dispensed1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Remaining1
        private bool cdm2_remaining1Changed = false;
        private int? cdm2_remaining1;
        public int? Cdm2Remaining1
        {
            get { return cdm2_remaining1; }
            set
            {
                cdm2_remaining1 = value;
                cdm2_remaining1Changed = true;
            }
        }
        private string cdm2_remaining1DbString
        {
            get
            {
                if (this.cdm2_remaining1.HasValue)
                    return cdm2_remaining1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Purged1
        private bool cdm2_purged1Changed = false;
        private int? cdm2_purged1;
        public int? Cdm2Purged1
        {
            get { return cdm2_purged1; }
            set
            {
                cdm2_purged1 = value;
                cdm2_purged1Changed = true;
            }
        }
        private string cdm2_purged1DbString
        {
            get
            {
                if (this.cdm2_purged1.HasValue)
                    return cdm2_purged1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Denom2
        private bool cdm2_denom2Changed = false;
        private int? cdm2_denom2;
        public int? Cdm2Denom2
        {
            get { return cdm2_denom2; }
            set
            {
                cdm2_denom2 = value;
                cdm2_denom2Changed = true;
            }
        }
        private string cdm2_denom2DbString
        {
            get
            {
                if (this.cdm2_denom2.HasValue)
                    return cdm2_denom2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Initial2
        private bool cdm2_initial2Changed = false;
        private int? cdm2_initial2;
        public int? Cdm2Initial2
        {
            get { return cdm2_initial2; }
            set
            {
                cdm2_initial2 = value;
                cdm2_initial2Changed = true;
            }
        }
        private string cdm2_initial2DbString
        {
            get
            {
                if (this.cdm2_initial2.HasValue)
                    return cdm2_initial2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Dispensed2
        private bool cdm2_dispensed2Changed = false;
        private int? cdm2_dispensed2;
        public int? Cdm2Dispensed2
        {
            get { return cdm2_dispensed2; }
            set
            {
                cdm2_dispensed2 = value;
                cdm2_dispensed2Changed = true;
            }
        }
        private string cdm2_dispensed2DbString
        {
            get
            {
                if (this.cdm2_dispensed2.HasValue)
                    return cdm2_dispensed2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Remaining2
        private bool cdm2_remaining2Changed = false;
        private int? cdm2_remaining2;
        public int? Cdm2Remaining2
        {
            get { return cdm2_remaining2; }
            set
            {
                cdm2_remaining2 = value;
                cdm2_remaining2Changed = true;
            }
        }
        private string cdm2_remaining2DbString
        {
            get
            {
                if (this.cdm2_remaining2.HasValue)
                    return cdm2_remaining2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Purged2
        private bool cdm2_purged2Changed = false;
        private int? cdm2_purged2;
        public int? Cdm2Purged2
        {
            get { return cdm2_purged2; }
            set
            {
                cdm2_purged2 = value;
                cdm2_purged2Changed = true;
            }
        }
        private string cdm2_purged2DbString
        {
            get
            {
                if (this.cdm2_purged2.HasValue)
                    return cdm2_purged2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Denom3
        private bool cdm2_denom3Changed = false;
        private int? cdm2_denom3;
        public int? Cdm2Denom3
        {
            get { return cdm2_denom3; }
            set
            {
                cdm2_denom3 = value;
                cdm2_denom3Changed = true;
            }
        }
        private string cdm2_denom3DbString
        {
            get
            {
                if (this.cdm2_denom3.HasValue)
                    return cdm2_denom3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Initial3
        private bool cdm2_initial3Changed = false;
        private int? cdm2_initial3;
        public int? Cdm2Initial3
        {
            get { return cdm2_initial3; }
            set
            {
                cdm2_initial3 = value;
                cdm2_initial3Changed = true;
            }
        }
        private string cdm2_initial3DbString
        {
            get
            {
                if (this.cdm2_initial3.HasValue)
                    return cdm2_initial3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Dispensed3
        private bool cdm2_dispensed3Changed = false;
        private int? cdm2_dispensed3;
        public int? Cdm2Dispensed3
        {
            get { return cdm2_dispensed3; }
            set
            {
                cdm2_dispensed3 = value;
                cdm2_dispensed3Changed = true;
            }
        }
        private string cdm2_dispensed3DbString
        {
            get
            {
                if (this.cdm2_dispensed3.HasValue)
                    return cdm2_dispensed3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Remaining3
        private bool cdm2_remaining3Changed = false;
        private int? cdm2_remaining3;
        public int? Cdm2Remaining3
        {
            get { return cdm2_remaining3; }
            set
            {
                cdm2_remaining3 = value;
                cdm2_remaining3Changed = true;
            }
        }
        private string cdm2_remaining3DbString
        {
            get
            {
                if (this.cdm2_remaining3.HasValue)
                    return cdm2_remaining3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Purged3
        private bool cdm2_purged3Changed = false;
        private int? cdm2_purged3;
        public int? Cdm2Purged3
        {
            get { return cdm2_purged3; }
            set
            {
                cdm2_purged3 = value;
                cdm2_purged3Changed = true;
            }
        }
        private string cdm2_purged3DbString
        {
            get
            {
                if (this.cdm2_purged3.HasValue)
                    return cdm2_purged3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Denom4
        private bool cdm2_denom4Changed = false;
        private int? cdm2_denom4;
        public int? Cdm2Denom4
        {
            get { return cdm2_denom4; }
            set
            {
                cdm2_denom4 = value;
                cdm2_denom4Changed = true;
            }
        }
        private string cdm2_denom4DbString
        {
            get
            {
                if (this.cdm2_denom4.HasValue)
                    return cdm2_denom4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Initial4
        private bool cdm2_initial4Changed = false;
        private int? cdm2_initial4;
        public int? Cdm2Initial4
        {
            get { return cdm2_initial4; }
            set
            {
                cdm2_initial4 = value;
                cdm2_initial4Changed = true;
            }
        }
        private string cdm2_initial4DbString
        {
            get
            {
                if (this.cdm2_initial4.HasValue)
                    return cdm2_initial4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Dispensed4
        private bool cdm2_dispensed4Changed = false;
        private int? cdm2_dispensed4;
        public int? Cdm2Dispensed4
        {
            get { return cdm2_dispensed4; }
            set
            {
                cdm2_dispensed4 = value;
                cdm2_dispensed4Changed = true;
            }
        }
        private string cdm2_dispensed4DbString
        {
            get
            {
                if (this.cdm2_dispensed4.HasValue)
                    return cdm2_dispensed4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Remaining4
        private bool cdm2_remaining4Changed = false;
        private int? cdm2_remaining4;
        public int? Cdm2Remaining4
        {
            get { return cdm2_remaining4; }
            set
            {
                cdm2_remaining4 = value;
                cdm2_remaining4Changed = true;
            }
        }
        private string cdm2_remaining4DbString
        {
            get
            {
                if (this.cdm2_remaining4.HasValue)
                    return cdm2_remaining4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm2Purged4
        private bool cdm2_purged4Changed = false;
        private int? cdm2_purged4;
        public int? Cdm2Purged4
        {
            get { return cdm2_purged4; }
            set
            {
                cdm2_purged4 = value;
                cdm2_purged4Changed = true;
            }
        }
        private string cdm2_purged4DbString
        {
            get
            {
                if (this.cdm2_purged4.HasValue)
                    return cdm2_purged4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Raw1
        private bool cdm1_raw1Changed = false;
        private string cdm1_raw1;
        public string Cdm1Raw1
        {
            get { return cdm1_raw1; }
            set
            {
                cdm1_raw1 = value;
                cdm1_raw1Changed = true;
            }
        }
        private string cdm1_raw1DbString
        {
            get
            {
                if (this.cdm1_raw1 != null)
                    return string.Format("'{0}'", cdm1_raw1);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Raw2
        private bool cdm1_raw2Changed = false;
        private string cdm1_raw2;
        public string Cdm1Raw2
        {
            get { return cdm1_raw2; }
            set
            {
                cdm1_raw2 = value;
                cdm1_raw2Changed = true;
            }
        }
        private string cdm1_raw2DbString
        {
            get
            {
                if (this.cdm1_raw2 != null)
                    return string.Format("'{0}'", cdm1_raw2);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Raw3
        private bool cdm1_raw3Changed = false;
        private string cdm1_raw3;
        public string Cdm1Raw3
        {
            get { return cdm1_raw3; }
            set
            {
                cdm1_raw3 = value;
                cdm1_raw3Changed = true;
            }
        }
        private string cdm1_raw3DbString
        {
            get
            {
                if (this.cdm1_raw3 != null)
                    return string.Format("'{0}'", cdm1_raw3);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Raw4
        private bool cdm1_raw4Changed = false;
        private string cdm1_raw4;
        public string Cdm1Raw4
        {
            get { return cdm1_raw4; }
            set
            {
                cdm1_raw4 = value;
                cdm1_raw4Changed = true;
            }
        }
        private string cdm1_raw4DbString
        {
            get
            {
                if (this.cdm1_raw4 != null)
                    return string.Format("'{0}'", cdm1_raw4);
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Denom1
        private bool cdm1_denom1Changed = false;
        private int? cdm1_denom1;
        public int? Cdm1Denom1
        {
            get { return cdm1_denom1; }
            set
            {
                cdm1_denom1 = value;
                cdm1_denom1Changed = true;
            }
        }
        private string cdm1_denom1DbString
        {
            get
            {
                if (this.cdm1_denom1.HasValue)
                    return cdm1_denom1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Remaining1
        private bool cdm1_remaining1Changed = false;
        private int? cdm1_remaining1;
        public int? Cdm1Remaining1
        {
            get { return cdm1_remaining1; }
            set
            {
                cdm1_remaining1 = value;
                cdm1_remaining1Changed = true;
            }
        }
        private string cdm1_remaining1DbString
        {
            get
            {
                if (this.cdm1_remaining1.HasValue)
                    return cdm1_remaining1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Dispensed1
        private bool cdm1_dispensed1Changed = false;
        private int? cdm1_dispensed1;
        public int? Cdm1Dispensed1
        {
            get { return cdm1_dispensed1; }
            set
            {
                cdm1_dispensed1 = value;
                cdm1_dispensed1Changed = true;
            }
        }
        private string cdm1_dispensed1DbString
        {
            get
            {
                if (this.cdm1_dispensed1.HasValue)
                    return cdm1_dispensed1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Denom2
        private bool cdm1_denom2Changed = false;
        private int? cdm1_denom2;
        public int? Cdm1Denom2
        {
            get { return cdm1_denom2; }
            set
            {
                cdm1_denom2 = value;
                cdm1_denom2Changed = true;
            }
        }
        private string cdm1_denom2DbString
        {
            get
            {
                if (this.cdm1_denom2.HasValue)
                    return cdm1_denom2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Remaining2
        private bool cdm1_remaining2Changed = false;
        private int? cdm1_remaining2;
        public int? Cdm1Remaining2
        {
            get { return cdm1_remaining2; }
            set
            {
                cdm1_remaining2 = value;
                cdm1_remaining2Changed = true;
            }
        }
        private string cdm1_remaining2DbString
        {
            get
            {
                if (this.cdm1_remaining2.HasValue)
                    return cdm1_remaining2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Dispensed2
        private bool cdm1_dispensed2Changed = false;
        private int? cdm1_dispensed2;
        public int? Cdm1Dispensed2
        {
            get { return cdm1_dispensed2; }
            set
            {
                cdm1_dispensed2 = value;
                cdm1_dispensed2Changed = true;
            }
        }
        private string cdm1_dispensed2DbString
        {
            get
            {
                if (this.cdm1_dispensed2.HasValue)
                    return cdm1_dispensed2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Denom3
        private bool cdm1_denom3Changed = false;
        private int? cdm1_denom3;
        public int? Cdm1Denom3
        {
            get { return cdm1_denom3; }
            set
            {
                cdm1_denom3 = value;
                cdm1_denom3Changed = true;
            }
        }
        private string cdm1_denom3DbString
        {
            get
            {
                if (this.cdm1_denom3.HasValue)
                    return cdm1_denom3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Remaining3
        private bool cdm1_remaining3Changed = false;
        private int? cdm1_remaining3;
        public int? Cdm1Remaining3
        {
            get { return cdm1_remaining3; }
            set
            {
                cdm1_remaining3 = value;
                cdm1_remaining3Changed = true;
            }
        }
        private string cdm1_remaining3DbString
        {
            get
            {
                if (this.cdm1_remaining3.HasValue)
                    return cdm1_remaining3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Dispensed3
        private bool cdm1_dispensed3Changed = false;
        private int? cdm1_dispensed3;
        public int? Cdm1Dispensed3
        {
            get { return cdm1_dispensed3; }
            set
            {
                cdm1_dispensed3 = value;
                cdm1_dispensed3Changed = true;
            }
        }
        private string cdm1_dispensed3DbString
        {
            get
            {
                if (this.cdm1_dispensed3.HasValue)
                    return cdm1_dispensed3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Denom4
        private bool cdm1_denom4Changed = false;
        private int? cdm1_denom4;
        public int? Cdm1Denom4
        {
            get { return cdm1_denom4; }
            set
            {
                cdm1_denom4 = value;
                cdm1_denom4Changed = true;
            }
        }
        private string cdm1_denom4DbString
        {
            get
            {
                if (this.cdm1_denom4.HasValue)
                    return cdm1_denom4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Remaining4
        private bool cdm1_remaining4Changed = false;
        private int? cdm1_remaining4;
        public int? Cdm1Remaining4
        {
            get { return cdm1_remaining4; }
            set
            {
                cdm1_remaining4 = value;
                cdm1_remaining4Changed = true;
            }
        }
        private string cdm1_remaining4DbString
        {
            get
            {
                if (this.cdm1_remaining4.HasValue)
                    return cdm1_remaining4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cdm1Dispensed4
        private bool cdm1_dispensed4Changed = false;
        private int? cdm1_dispensed4;
        public int? Cdm1Dispensed4
        {
            get { return cdm1_dispensed4; }
            set
            {
                cdm1_dispensed4 = value;
                cdm1_dispensed4Changed = true;
            }
        }
        private string cdm1_dispensed4DbString
        {
            get
            {
                if (this.cdm1_dispensed4.HasValue)
                    return cdm1_dispensed4.ToString();
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
        #endregion

        #region ParsedTransactionCdmDetailReader
        public class ParsedTransactionCdmDetailReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ParsedTransactionCdmDetail currentParsedTransactionCdmDetail;
            Columns columns;
            bool partialRead = false;
            private ParsedTransactionCdmDetailReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ParsedTransactionCdmDetailReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ParsedTransactionCdmDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentParsedTransactionCdmDetail; }

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
                    currentParsedTransactionCdmDetail = new ParsedTransactionCdmDetail();
                    if (partialRead)
                    {
                        if ((columns & Columns.parsed_transaction_cdm_detail_id) == Columns.parsed_transaction_cdm_detail_id && reader["parsed_transaction_cdm_detail_id"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.parsed_transaction_cdm_detail_id = (int)reader["parsed_transaction_cdm_detail_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.atm_id = (int)reader["atm_id"];
                        if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                        {
                            currentParsedTransactionCdmDetail.task_id =
                                (int?)reader["task_id"];
                        }
                        if ((columns & Columns.cdm2_raw1) == Columns.cdm2_raw1 && reader["cdm2_raw1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw1 = (string)reader["cdm2_raw1"];
                        if ((columns & Columns.cdm2_raw2) == Columns.cdm2_raw2 && reader["cdm2_raw2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw2 = (string)reader["cdm2_raw2"];
                        if ((columns & Columns.cdm2_raw3) == Columns.cdm2_raw3 && reader["cdm2_raw3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw3 = (string)reader["cdm2_raw3"];
                        if ((columns & Columns.cdm2_raw4) == Columns.cdm2_raw4 && reader["cdm2_raw4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw4 = (string)reader["cdm2_raw4"];
                        if ((columns & Columns.cdm2_denom1) == Columns.cdm2_denom1 && reader["cdm2_denom1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom1 = (int?)reader["cdm2_denom1"];
                        if ((columns & Columns.cdm2_initial1) == Columns.cdm2_initial1 && reader["cdm2_initial1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial1 = (int?)reader["cdm2_initial1"];
                        if ((columns & Columns.cdm2_dispensed1) == Columns.cdm2_dispensed1 && reader["cdm2_dispensed1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed1 = (int?)reader["cdm2_dispensed1"];
                        if ((columns & Columns.cdm2_remaining1) == Columns.cdm2_remaining1 && reader["cdm2_remaining1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining1 = (int?)reader["cdm2_remaining1"];
                        if ((columns & Columns.cdm2_purged1) == Columns.cdm2_purged1 && reader["cdm2_purged1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged1 = (int?)reader["cdm2_purged1"];
                        if ((columns & Columns.cdm2_denom2) == Columns.cdm2_denom2 && reader["cdm2_denom2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom2 = (int?)reader["cdm2_denom2"];
                        if ((columns & Columns.cdm2_initial2) == Columns.cdm2_initial2 && reader["cdm2_initial2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial2 = (int?)reader["cdm2_initial2"];
                        if ((columns & Columns.cdm2_dispensed2) == Columns.cdm2_dispensed2 && reader["cdm2_dispensed2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed2 = (int?)reader["cdm2_dispensed2"];
                        if ((columns & Columns.cdm2_remaining2) == Columns.cdm2_remaining2 && reader["cdm2_remaining2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining2 = (int?)reader["cdm2_remaining2"];
                        if ((columns & Columns.cdm2_purged2) == Columns.cdm2_purged2 && reader["cdm2_purged2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged2 = (int?)reader["cdm2_purged2"];
                        if ((columns & Columns.cdm2_denom3) == Columns.cdm2_denom3 && reader["cdm2_denom3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom3 = (int?)reader["cdm2_denom3"];
                        if ((columns & Columns.cdm2_initial3) == Columns.cdm2_initial3 && reader["cdm2_initial3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial3 = (int?)reader["cdm2_initial3"];
                        if ((columns & Columns.cdm2_dispensed3) == Columns.cdm2_dispensed3 && reader["cdm2_dispensed3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed3 = (int?)reader["cdm2_dispensed3"];
                        if ((columns & Columns.cdm2_remaining3) == Columns.cdm2_remaining3 && reader["cdm2_remaining3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining3 = (int?)reader["cdm2_remaining3"];
                        if ((columns & Columns.cdm2_purged3) == Columns.cdm2_purged3 && reader["cdm2_purged3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged3 = (int?)reader["cdm2_purged3"];
                        if ((columns & Columns.cdm2_denom4) == Columns.cdm2_denom4 && reader["cdm2_denom4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom4 = (int?)reader["cdm2_denom4"];
                        if ((columns & Columns.cdm2_initial4) == Columns.cdm2_initial4 && reader["cdm2_initial4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial4 = (int?)reader["cdm2_initial4"];
                        if ((columns & Columns.cdm2_dispensed4) == Columns.cdm2_dispensed4 && reader["cdm2_dispensed4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed4 = (int?)reader["cdm2_dispensed4"];
                        if ((columns & Columns.cdm2_remaining4) == Columns.cdm2_remaining4 && reader["cdm2_remaining4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining4 = (int?)reader["cdm2_remaining4"];
                        if ((columns & Columns.cdm2_purged4) == Columns.cdm2_purged4 && reader["cdm2_purged4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged4 = (int?)reader["cdm2_purged4"];
                        if ((columns & Columns.cdm1_raw1) == Columns.cdm1_raw1 && reader["cdm1_raw1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw1 = (string)reader["cdm1_raw1"];
                        if ((columns & Columns.cdm1_raw2) == Columns.cdm1_raw2 && reader["cdm1_raw2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw2 = (string)reader["cdm1_raw2"];
                        if ((columns & Columns.cdm1_raw3) == Columns.cdm1_raw3 && reader["cdm1_raw3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw3 = (string)reader["cdm1_raw3"];
                        if ((columns & Columns.cdm1_raw4) == Columns.cdm1_raw4 && reader["cdm1_raw4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw4 = (string)reader["cdm1_raw4"];
                        if ((columns & Columns.cdm1_denom1) == Columns.cdm1_denom1 && reader["cdm1_denom1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom1 = (int?)reader["cdm1_denom1"];
                        if ((columns & Columns.cdm1_remaining1) == Columns.cdm1_remaining1 && reader["cdm1_remaining1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining1 = (int?)reader["cdm1_remaining1"];
                        if ((columns & Columns.cdm1_dispensed1) == Columns.cdm1_dispensed1 && reader["cdm1_dispensed1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed1 = (int?)reader["cdm1_dispensed1"];
                        if ((columns & Columns.cdm1_denom2) == Columns.cdm1_denom2 && reader["cdm1_denom2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom2 = (int?)reader["cdm1_denom2"];
                        if ((columns & Columns.cdm1_remaining2) == Columns.cdm1_remaining2 && reader["cdm1_remaining2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining2 = (int?)reader["cdm1_remaining2"];
                        if ((columns & Columns.cdm1_dispensed2) == Columns.cdm1_dispensed2 && reader["cdm1_dispensed2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed2 = (int?)reader["cdm1_dispensed2"];
                        if ((columns & Columns.cdm1_denom3) == Columns.cdm1_denom3 && reader["cdm1_denom3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom3 = (int?)reader["cdm1_denom3"];
                        if ((columns & Columns.cdm1_remaining3) == Columns.cdm1_remaining3 && reader["cdm1_remaining3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining3 = (int?)reader["cdm1_remaining3"];
                        if ((columns & Columns.cdm1_dispensed3) == Columns.cdm1_dispensed3 && reader["cdm1_dispensed3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed3 = (int?)reader["cdm1_dispensed3"];
                        if ((columns & Columns.cdm1_denom4) == Columns.cdm1_denom4 && reader["cdm1_denom4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom4 = (int?)reader["cdm1_denom4"];
                        if ((columns & Columns.cdm1_remaining4) == Columns.cdm1_remaining4 && reader["cdm1_remaining4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining4 = (int?)reader["cdm1_remaining4"];
                        if ((columns & Columns.cdm1_dispensed4) == Columns.cdm1_dispensed4 && reader["cdm1_dispensed4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed4 = (int?)reader["cdm1_dispensed4"];
                        if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.processing_datetime = (DateTime?)reader["processing_datetime"];

                    }
                    else
                    {
                        if (reader["parsed_transaction_cdm_detail_id"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.parsed_transaction_cdm_detail_id = (int)reader["parsed_transaction_cdm_detail_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.atm_id = (int)reader["atm_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.task_id = (int?)reader["task_id"];
                        if (reader["trxn_datetime"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if (reader["cdm2_raw1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw1 = (string)reader["cdm2_raw1"];
                        if (reader["cdm2_raw2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw2 = (string)reader["cdm2_raw2"];
                        if (reader["cdm2_raw3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw3 = (string)reader["cdm2_raw3"];
                        if (reader["cdm2_raw4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_raw4 = (string)reader["cdm2_raw4"];
                        if (reader["cdm2_denom1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom1 = (int?)reader["cdm2_denom1"];
                        if (reader["cdm2_initial1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial1 = (int?)reader["cdm2_initial1"];
                        if (reader["cdm2_dispensed1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed1 = (int?)reader["cdm2_dispensed1"];
                        if (reader["cdm2_remaining1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining1 = (int?)reader["cdm2_remaining1"];
                        if (reader["cdm2_purged1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged1 = (int?)reader["cdm2_purged1"];
                        if (reader["cdm2_denom2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom2 = (int?)reader["cdm2_denom2"];
                        if (reader["cdm2_initial2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial2 = (int?)reader["cdm2_initial2"];
                        if (reader["cdm2_dispensed2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed2 = (int?)reader["cdm2_dispensed2"];
                        if (reader["cdm2_remaining2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining2 = (int?)reader["cdm2_remaining2"];
                        if (reader["cdm2_purged2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged2 = (int?)reader["cdm2_purged2"];
                        if (reader["cdm2_denom3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom3 = (int?)reader["cdm2_denom3"];
                        if (reader["cdm2_initial3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial3 = (int?)reader["cdm2_initial3"];
                        if (reader["cdm2_dispensed3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed3 = (int?)reader["cdm2_dispensed3"];
                        if (reader["cdm2_remaining3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining3 = (int?)reader["cdm2_remaining3"];
                        if (reader["cdm2_purged3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged3 = (int?)reader["cdm2_purged3"];
                        if (reader["cdm2_denom4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_denom4 = (int?)reader["cdm2_denom4"];
                        if (reader["cdm2_initial4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_initial4 = (int?)reader["cdm2_initial4"];
                        if (reader["cdm2_dispensed4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_dispensed4 = (int?)reader["cdm2_dispensed4"];
                        if (reader["cdm2_remaining4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_remaining4 = (int?)reader["cdm2_remaining4"];
                        if (reader["cdm2_purged4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm2_purged4 = (int?)reader["cdm2_purged4"];
                        if (reader["cdm1_raw1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw1 = (string)reader["cdm1_raw1"];
                        if (reader["cdm1_raw2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw2 = (string)reader["cdm1_raw2"];
                        if (reader["cdm1_raw3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw3 = (string)reader["cdm1_raw3"];
                        if (reader["cdm1_raw4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_raw4 = (string)reader["cdm1_raw4"];
                        if (reader["cdm1_denom1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom1 = (int?)reader["cdm1_denom1"];
                        if (reader["cdm1_remaining1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining1 = (int?)reader["cdm1_remaining1"];
                        if (reader["cdm1_dispensed1"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed1 = (int?)reader["cdm1_dispensed1"];
                        if (reader["cdm1_denom2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom2 = (int?)reader["cdm1_denom2"];
                        if (reader["cdm1_remaining2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining2 = (int?)reader["cdm1_remaining2"];
                        if (reader["cdm1_dispensed2"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed2 = (int?)reader["cdm1_dispensed2"];
                        if (reader["cdm1_denom3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom3 = (int?)reader["cdm1_denom3"];
                        if (reader["cdm1_remaining3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining3 = (int?)reader["cdm1_remaining3"];
                        if (reader["cdm1_dispensed3"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed3 = (int?)reader["cdm1_dispensed3"];
                        if (reader["cdm1_denom4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_denom4 = (int?)reader["cdm1_denom4"];
                        if (reader["cdm1_remaining4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_remaining4 = (int?)reader["cdm1_remaining4"];
                        if (reader["cdm1_dispensed4"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.cdm1_dispensed4 = (int?)reader["cdm1_dispensed4"];
                        if (reader["processing_datetime"] != DBNull.Value)
                            currentParsedTransactionCdmDetail.processing_datetime = (DateTime?)reader["processing_datetime"];
                    }

                    currentParsedTransactionCdmDetail.isNewEntity = false;
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

            public ParsedTransactionCdmDetail CurrentParsedTransactionCdmDetail
            {
                get { return currentParsedTransactionCdmDetail; }
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


        #region ParsedTransactionCdmDetail functions

        public static ParsedTransactionCdmDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.parsed_transaction_cdm_detail_id == (Columns.parsed_transaction_cdm_detail_id & columns))
                qry.Append("parsed_transaction_cdm_detail_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
                qry.Append("trxn_datetime,");
            if (Columns.task_id == (Columns.task_id & columns))
            {
                qry.Append("task_id,");
            }
            if (Columns.cdm2_raw1 == (Columns.cdm2_raw1 & columns))
                qry.Append("cdm2_raw1,");
            if (Columns.cdm2_raw2 == (Columns.cdm2_raw2 & columns))
                qry.Append("cdm2_raw2,");
            if (Columns.cdm2_raw3 == (Columns.cdm2_raw3 & columns))
                qry.Append("cdm2_raw3,");
            if (Columns.cdm2_raw4 == (Columns.cdm2_raw4 & columns))
                qry.Append("cdm2_raw4,");
            if (Columns.cdm2_denom1 == (Columns.cdm2_denom1 & columns))
                qry.Append("cdm2_denom1,");
            if (Columns.cdm2_initial1 == (Columns.cdm2_initial1 & columns))
                qry.Append("cdm2_initial1,");
            if (Columns.cdm2_dispensed1 == (Columns.cdm2_dispensed1 & columns))
                qry.Append("cdm2_dispensed1,");
            if (Columns.cdm2_remaining1 == (Columns.cdm2_remaining1 & columns))
                qry.Append("cdm2_remaining1,");
            if (Columns.cdm2_purged1 == (Columns.cdm2_purged1 & columns))
                qry.Append("cdm2_purged1,");
            if (Columns.cdm2_denom2 == (Columns.cdm2_denom2 & columns))
                qry.Append("cdm2_denom2,");
            if (Columns.cdm2_initial2 == (Columns.cdm2_initial2 & columns))
                qry.Append("cdm2_initial2,");
            if (Columns.cdm2_dispensed2 == (Columns.cdm2_dispensed2 & columns))
                qry.Append("cdm2_dispensed2,");
            if (Columns.cdm2_remaining2 == (Columns.cdm2_remaining2 & columns))
                qry.Append("cdm2_remaining2,");
            if (Columns.cdm2_purged2 == (Columns.cdm2_purged2 & columns))
                qry.Append("cdm2_purged2,");
            if (Columns.cdm2_denom3 == (Columns.cdm2_denom3 & columns))
                qry.Append("cdm2_denom3,");
            if (Columns.cdm2_initial3 == (Columns.cdm2_initial3 & columns))
                qry.Append("cdm2_initial3,");
            if (Columns.cdm2_dispensed3 == (Columns.cdm2_dispensed3 & columns))
                qry.Append("cdm2_dispensed3,");
            if (Columns.cdm2_remaining3 == (Columns.cdm2_remaining3 & columns))
                qry.Append("cdm2_remaining3,");
            if (Columns.cdm2_purged3 == (Columns.cdm2_purged3 & columns))
                qry.Append("cdm2_purged3,");
            if (Columns.cdm2_denom4 == (Columns.cdm2_denom4 & columns))
                qry.Append("cdm2_denom4,");
            if (Columns.cdm2_initial4 == (Columns.cdm2_initial4 & columns))
                qry.Append("cdm2_initial4,");
            if (Columns.cdm2_dispensed4 == (Columns.cdm2_dispensed4 & columns))
                qry.Append("cdm2_dispensed4,");
            if (Columns.cdm2_remaining4 == (Columns.cdm2_remaining4 & columns))
                qry.Append("cdm2_remaining4,");
            if (Columns.cdm2_purged4 == (Columns.cdm2_purged4 & columns))
                qry.Append("cdm2_purged4,");
            if (Columns.cdm1_raw1 == (Columns.cdm1_raw1 & columns))
                qry.Append("cdm1_raw1,");
            if (Columns.cdm1_raw2 == (Columns.cdm1_raw2 & columns))
                qry.Append("cdm1_raw2,");
            if (Columns.cdm1_raw3 == (Columns.cdm1_raw3 & columns))
                qry.Append("cdm1_raw3,");
            if (Columns.cdm1_raw4 == (Columns.cdm1_raw4 & columns))
                qry.Append("cdm1_raw4,");
            if (Columns.cdm1_denom1 == (Columns.cdm1_denom1 & columns))
                qry.Append("cdm1_denom1,");
            if (Columns.cdm1_remaining1 == (Columns.cdm1_remaining1 & columns))
                qry.Append("cdm1_remaining1,");
            if (Columns.cdm1_dispensed1 == (Columns.cdm1_dispensed1 & columns))
                qry.Append("cdm1_dispensed1,");
            if (Columns.cdm1_denom2 == (Columns.cdm1_denom2 & columns))
                qry.Append("cdm1_denom2,");
            if (Columns.cdm1_remaining2 == (Columns.cdm1_remaining2 & columns))
                qry.Append("cdm1_remaining2,");
            if (Columns.cdm1_dispensed2 == (Columns.cdm1_dispensed2 & columns))
                qry.Append("cdm1_dispensed2,");
            if (Columns.cdm1_denom3 == (Columns.cdm1_denom3 & columns))
                qry.Append("cdm1_denom3,");
            if (Columns.cdm1_remaining3 == (Columns.cdm1_remaining3 & columns))
                qry.Append("cdm1_remaining3,");
            if (Columns.cdm1_dispensed3 == (Columns.cdm1_dispensed3 & columns))
                qry.Append("cdm1_dispensed3,");
            if (Columns.cdm1_denom4 == (Columns.cdm1_denom4 & columns))
                qry.Append("cdm1_denom4,");
            if (Columns.cdm1_remaining4 == (Columns.cdm1_remaining4 & columns))
                qry.Append("cdm1_remaining4,");
            if (Columns.cdm1_dispensed4 == (Columns.cdm1_dispensed4 & columns))
                qry.Append("cdm1_dispensed4,");
            if (Columns.processing_datetime == (Columns.processing_datetime & columns))
                qry.Append("processing_datetime,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Parsed_transaction_cdm_detail ");

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
            return new ParsedTransactionCdmDetailReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ParsedTransactionCdmDetailReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ParsedTransactionCdmDetailReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select parsed_transaction_cdm_detail_id,atm_id,trxn_datetime,cdm2_raw1,cdm2_raw2,cdm2_raw3,cdm2_raw4,cdm2_denom1,cdm2_initial1,cdm2_dispensed1,cdm2_remaining1,cdm2_purged1,cdm2_denom2,cdm2_initial2,cdm2_dispensed2,cdm2_remaining2,cdm2_purged2,cdm2_denom3,cdm2_initial3,cdm2_dispensed3,cdm2_remaining3,cdm2_purged3,cdm2_denom4,cdm2_initial4,cdm2_dispensed4,cdm2_remaining4,cdm2_purged4,cdm1_raw1,cdm1_raw2,cdm1_raw3,cdm1_raw4,cdm1_denom1,cdm1_remaining1,cdm1_dispensed1,cdm1_denom2,cdm1_remaining2,cdm1_dispensed2,cdm1_denom3,cdm1_remaining3,cdm1_dispensed3,cdm1_denom4,cdm1_remaining4,cdm1_dispensed4,processing_datetime from Parsed_transaction_cdm_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ParsedTransactionCdmDetailReader(cmd.ExecuteReader(), conn);
        }

        static public ParsedTransactionCdmDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static ParsedTransactionCdmDetail LoadParsedTransactionCdmDetail(string where)
        {
            ParsedTransactionCdmDetailReader reader = ParsedTransactionCdmDetail.ExecuteReader(where);
            ParsedTransactionCdmDetail _parsedtransactioncdmdetail = null;
            if (reader.Read())
                _parsedtransactioncdmdetail = reader.CurrentParsedTransactionCdmDetail;
            reader.Close();
            return _parsedtransactioncdmdetail;
        }

        public static ParsedTransactionCdmDetail LoadParsedTransactionCdmDetail(string where, IDbConnection conn)
        {
            ParsedTransactionCdmDetailReader reader = ParsedTransactionCdmDetail.ExecuteReader(where, conn);
            ParsedTransactionCdmDetail _parsedtransactioncdmdetail = null;
            if (reader.Read())
                _parsedtransactioncdmdetail = reader.CurrentParsedTransactionCdmDetail;
            reader.Close(false);
            return _parsedtransactioncdmdetail;
        }

        public static ParsedTransactionCdmDetail LoadParsedTransactionCdmDetailByPk(long parsed_transaction_cdm_detail_id)
        {
            return LoadParsedTransactionCdmDetail(" parsed_transaction_cdm_detail_id=" + parsed_transaction_cdm_detail_id);
        }

        public static ParsedTransactionCdmDetail LoadParsedTransactionCdmDetailByPk(long parsed_transaction_cdm_detail_id, IDbConnection conn)
        {
            return LoadParsedTransactionCdmDetail(" parsed_transaction_cdm_detail_id=" + parsed_transaction_cdm_detail_id, conn);
        }

        public void Save()
        {
            if (parsed_transaction_cdm_detail_idChanged || atm_idChanged || trxn_datetimeChanged || cdm2_raw1Changed || cdm2_raw2Changed || cdm2_raw3Changed || cdm2_raw4Changed || cdm2_denom1Changed || cdm2_initial1Changed || cdm2_dispensed1Changed || cdm2_remaining1Changed || cdm2_purged1Changed || cdm2_denom2Changed || cdm2_initial2Changed || cdm2_dispensed2Changed || cdm2_remaining2Changed || cdm2_purged2Changed || cdm2_denom3Changed || cdm2_initial3Changed || cdm2_dispensed3Changed || cdm2_remaining3Changed || cdm2_purged3Changed || cdm2_denom4Changed || cdm2_initial4Changed || cdm2_dispensed4Changed || cdm2_remaining4Changed || cdm2_purged4Changed || cdm1_raw1Changed || cdm1_raw2Changed || cdm1_raw3Changed || cdm1_raw4Changed || cdm1_denom1Changed || cdm1_remaining1Changed || cdm1_dispensed1Changed || cdm1_denom2Changed || cdm1_remaining2Changed || cdm1_dispensed2Changed || cdm1_denom3Changed || cdm1_remaining3Changed || cdm1_dispensed3Changed || cdm1_denom4Changed || cdm1_remaining4Changed || cdm1_dispensed4Changed || processing_datetimeChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Cash).CreateCommand());
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
            if (parsed_transaction_cdm_detail_idChanged || task_idChanged || atm_idChanged || trxn_datetimeChanged || cdm2_raw1Changed || cdm2_raw2Changed || cdm2_raw3Changed || cdm2_raw4Changed || cdm2_denom1Changed || cdm2_initial1Changed || cdm2_dispensed1Changed || cdm2_remaining1Changed || cdm2_purged1Changed || cdm2_denom2Changed || cdm2_initial2Changed || cdm2_dispensed2Changed || cdm2_remaining2Changed || cdm2_purged2Changed || cdm2_denom3Changed || cdm2_initial3Changed || cdm2_dispensed3Changed || cdm2_remaining3Changed || cdm2_purged3Changed || cdm2_denom4Changed || cdm2_initial4Changed || cdm2_dispensed4Changed || cdm2_remaining4Changed || cdm2_purged4Changed || cdm1_raw1Changed || cdm1_raw2Changed || cdm1_raw3Changed || cdm1_raw4Changed || cdm1_denom1Changed || cdm1_remaining1Changed || cdm1_dispensed1Changed || cdm1_denom2Changed || cdm1_remaining2Changed || cdm1_dispensed2Changed || cdm1_denom3Changed || cdm1_remaining3Changed || cdm1_dispensed3Changed || cdm1_denom4Changed || cdm1_remaining4Changed || cdm1_dispensed4Changed || processing_datetimeChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Parsed_transaction_cdm_detail( parsed_transaction_cdm_detail_id,task_id,atm_id,trxn_datetime,cdm2_raw1,cdm2_raw2,cdm2_raw3,cdm2_raw4,cdm2_denom1,cdm2_initial1,cdm2_dispensed1,cdm2_remaining1,cdm2_purged1,cdm2_denom2,cdm2_initial2,cdm2_dispensed2,cdm2_remaining2,cdm2_purged2,cdm2_denom3,cdm2_initial3,cdm2_dispensed3,cdm2_remaining3,cdm2_purged3,cdm2_denom4,cdm2_initial4,cdm2_dispensed4,cdm2_remaining4,cdm2_purged4,cdm1_raw1,cdm1_raw2,cdm1_raw3,cdm1_raw4,cdm1_denom1,cdm1_remaining1,cdm1_dispensed1,cdm1_denom2,cdm1_remaining2,cdm1_dispensed2,cdm1_denom3,cdm1_remaining3,cdm1_dispensed3,cdm1_denom4,cdm1_remaining4,cdm1_dispensed4,processing_datetime ) values(");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.parsed_transaction_cdm_detail_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.parsed_transaction_cdm_detail_id);
                    }
                    qry.Append(",");
                    qry.Append(task_idDbString);
                    qry.Append(",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(trxn_datetimeDbString + ",");
                    qry.Append(cdm2_raw1DbString + ",");
                    qry.Append(cdm2_raw2DbString + ",");
                    qry.Append(cdm2_raw3DbString + ",");
                    qry.Append(cdm2_raw4DbString + ",");
                    qry.Append(cdm2_denom1DbString + ",");
                    qry.Append(cdm2_initial1DbString + ",");
                    qry.Append(cdm2_dispensed1DbString + ",");
                    qry.Append(cdm2_remaining1DbString + ",");
                    qry.Append(cdm2_purged1DbString + ",");
                    qry.Append(cdm2_denom2DbString + ",");
                    qry.Append(cdm2_initial2DbString + ",");
                    qry.Append(cdm2_dispensed2DbString + ",");
                    qry.Append(cdm2_remaining2DbString + ",");
                    qry.Append(cdm2_purged2DbString + ",");
                    qry.Append(cdm2_denom3DbString + ",");
                    qry.Append(cdm2_initial3DbString + ",");
                    qry.Append(cdm2_dispensed3DbString + ",");
                    qry.Append(cdm2_remaining3DbString + ",");
                    qry.Append(cdm2_purged3DbString + ",");
                    qry.Append(cdm2_denom4DbString + ",");
                    qry.Append(cdm2_initial4DbString + ",");
                    qry.Append(cdm2_dispensed4DbString + ",");
                    qry.Append(cdm2_remaining4DbString + ",");
                    qry.Append(cdm2_purged4DbString + ",");
                    qry.Append(cdm1_raw1DbString + ",");
                    qry.Append(cdm1_raw2DbString + ",");
                    qry.Append(cdm1_raw3DbString + ",");
                    qry.Append(cdm1_raw4DbString + ",");
                    qry.Append(cdm1_denom1DbString + ",");
                    qry.Append(cdm1_remaining1DbString + ",");
                    qry.Append(cdm1_dispensed1DbString + ",");
                    qry.Append(cdm1_denom2DbString + ",");
                    qry.Append(cdm1_remaining2DbString + ",");
                    qry.Append(cdm1_dispensed2DbString + ",");
                    qry.Append(cdm1_denom3DbString + ",");
                    qry.Append(cdm1_remaining3DbString + ",");
                    qry.Append(cdm1_dispensed3DbString + ",");
                    qry.Append(cdm1_denom4DbString + ",");
                    qry.Append(cdm1_remaining4DbString + ",");
                    qry.Append(cdm1_dispensed4DbString + ",");
                    qry.Append(processing_datetimeDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(parsed_transaction_cdm_detail_idChanged || atm_idChanged || task_idChanged || trxn_datetimeChanged || cdm2_raw1Changed || cdm2_raw2Changed || cdm2_raw3Changed || cdm2_raw4Changed || cdm2_denom1Changed || cdm2_initial1Changed || cdm2_dispensed1Changed || cdm2_remaining1Changed || cdm2_purged1Changed || cdm2_denom2Changed || cdm2_initial2Changed || cdm2_dispensed2Changed || cdm2_remaining2Changed || cdm2_purged2Changed || cdm2_denom3Changed || cdm2_initial3Changed || cdm2_dispensed3Changed || cdm2_remaining3Changed || cdm2_purged3Changed || cdm2_denom4Changed || cdm2_initial4Changed || cdm2_dispensed4Changed || cdm2_remaining4Changed || cdm2_purged4Changed || cdm1_raw1Changed || cdm1_raw2Changed || cdm1_raw3Changed || cdm1_raw4Changed || cdm1_denom1Changed || cdm1_remaining1Changed || cdm1_dispensed1Changed || cdm1_denom2Changed || cdm1_remaining2Changed || cdm1_dispensed2Changed || cdm1_denom3Changed || cdm1_remaining3Changed || cdm1_dispensed3Changed || cdm1_denom4Changed || cdm1_remaining4Changed || cdm1_dispensed4Changed || processing_datetimeChanged))
                        return;
                    qry.Append("UPDATE Parsed_transaction_cdm_detail set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (trxn_datetimeChanged)
                    {
                        qry.Append("trxn_datetime =" + trxn_datetimeDbString);
                        qry.Append(",");
                    }
                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }


                    if (cdm2_raw1Changed)
                    {
                        qry.Append("cdm2_raw1 =" + cdm2_raw1DbString);
                        qry.Append(",");
                    }

                    if (cdm2_raw2Changed)
                    {
                        qry.Append("cdm2_raw2 =" + cdm2_raw2DbString);
                        qry.Append(",");
                    }

                    if (cdm2_raw3Changed)
                    {
                        qry.Append("cdm2_raw3 =" + cdm2_raw3DbString);
                        qry.Append(",");
                    }

                    if (cdm2_raw4Changed)
                    {
                        qry.Append("cdm2_raw4 =" + cdm2_raw4DbString);
                        qry.Append(",");
                    }

                    if (cdm2_denom1Changed)
                    {
                        qry.Append("cdm2_denom1 =" + cdm2_denom1DbString);
                        qry.Append(",");
                    }

                    if (cdm2_initial1Changed)
                    {
                        qry.Append("cdm2_initial1 =" + cdm2_initial1DbString);
                        qry.Append(",");
                    }

                    if (cdm2_dispensed1Changed)
                    {
                        qry.Append("cdm2_dispensed1 =" + cdm2_dispensed1DbString);
                        qry.Append(",");
                    }

                    if (cdm2_remaining1Changed)
                    {
                        qry.Append("cdm2_remaining1 =" + cdm2_remaining1DbString);
                        qry.Append(",");
                    }

                    if (cdm2_purged1Changed)
                    {
                        qry.Append("cdm2_purged1 =" + cdm2_purged1DbString);
                        qry.Append(",");
                    }

                    if (cdm2_denom2Changed)
                    {
                        qry.Append("cdm2_denom2 =" + cdm2_denom2DbString);
                        qry.Append(",");
                    }

                    if (cdm2_initial2Changed)
                    {
                        qry.Append("cdm2_initial2 =" + cdm2_initial2DbString);
                        qry.Append(",");
                    }

                    if (cdm2_dispensed2Changed)
                    {
                        qry.Append("cdm2_dispensed2 =" + cdm2_dispensed2DbString);
                        qry.Append(",");
                    }

                    if (cdm2_remaining2Changed)
                    {
                        qry.Append("cdm2_remaining2 =" + cdm2_remaining2DbString);
                        qry.Append(",");
                    }

                    if (cdm2_purged2Changed)
                    {
                        qry.Append("cdm2_purged2 =" + cdm2_purged2DbString);
                        qry.Append(",");
                    }

                    if (cdm2_denom3Changed)
                    {
                        qry.Append("cdm2_denom3 =" + cdm2_denom3DbString);
                        qry.Append(",");
                    }

                    if (cdm2_initial3Changed)
                    {
                        qry.Append("cdm2_initial3 =" + cdm2_initial3DbString);
                        qry.Append(",");
                    }

                    if (cdm2_dispensed3Changed)
                    {
                        qry.Append("cdm2_dispensed3 =" + cdm2_dispensed3DbString);
                        qry.Append(",");
                    }

                    if (cdm2_remaining3Changed)
                    {
                        qry.Append("cdm2_remaining3 =" + cdm2_remaining3DbString);
                        qry.Append(",");
                    }

                    if (cdm2_purged3Changed)
                    {
                        qry.Append("cdm2_purged3 =" + cdm2_purged3DbString);
                        qry.Append(",");
                    }

                    if (cdm2_denom4Changed)
                    {
                        qry.Append("cdm2_denom4 =" + cdm2_denom4DbString);
                        qry.Append(",");
                    }

                    if (cdm2_initial4Changed)
                    {
                        qry.Append("cdm2_initial4 =" + cdm2_initial4DbString);
                        qry.Append(",");
                    }

                    if (cdm2_dispensed4Changed)
                    {
                        qry.Append("cdm2_dispensed4 =" + cdm2_dispensed4DbString);
                        qry.Append(",");
                    }

                    if (cdm2_remaining4Changed)
                    {
                        qry.Append("cdm2_remaining4 =" + cdm2_remaining4DbString);
                        qry.Append(",");
                    }

                    if (cdm2_purged4Changed)
                    {
                        qry.Append("cdm2_purged4 =" + cdm2_purged4DbString);
                        qry.Append(",");
                    }

                    if (cdm1_raw1Changed)
                    {
                        qry.Append("cdm1_raw1 =" + cdm1_raw1DbString);
                        qry.Append(",");
                    }

                    if (cdm1_raw2Changed)
                    {
                        qry.Append("cdm1_raw2 =" + cdm1_raw2DbString);
                        qry.Append(",");
                    }

                    if (cdm1_raw3Changed)
                    {
                        qry.Append("cdm1_raw3 =" + cdm1_raw3DbString);
                        qry.Append(",");
                    }

                    if (cdm1_raw4Changed)
                    {
                        qry.Append("cdm1_raw4 =" + cdm1_raw4DbString);
                        qry.Append(",");
                    }

                    if (cdm1_denom1Changed)
                    {
                        qry.Append("cdm1_denom1 =" + cdm1_denom1DbString);
                        qry.Append(",");
                    }

                    if (cdm1_remaining1Changed)
                    {
                        qry.Append("cdm1_remaining1 =" + cdm1_remaining1DbString);
                        qry.Append(",");
                    }

                    if (cdm1_dispensed1Changed)
                    {
                        qry.Append("cdm1_dispensed1 =" + cdm1_dispensed1DbString);
                        qry.Append(",");
                    }

                    if (cdm1_denom2Changed)
                    {
                        qry.Append("cdm1_denom2 =" + cdm1_denom2DbString);
                        qry.Append(",");
                    }

                    if (cdm1_remaining2Changed)
                    {
                        qry.Append("cdm1_remaining2 =" + cdm1_remaining2DbString);
                        qry.Append(",");
                    }

                    if (cdm1_dispensed2Changed)
                    {
                        qry.Append("cdm1_dispensed2 =" + cdm1_dispensed2DbString);
                        qry.Append(",");
                    }

                    if (cdm1_denom3Changed)
                    {
                        qry.Append("cdm1_denom3 =" + cdm1_denom3DbString);
                        qry.Append(",");
                    }

                    if (cdm1_remaining3Changed)
                    {
                        qry.Append("cdm1_remaining3 =" + cdm1_remaining3DbString);
                        qry.Append(",");
                    }

                    if (cdm1_dispensed3Changed)
                    {
                        qry.Append("cdm1_dispensed3 =" + cdm1_dispensed3DbString);
                        qry.Append(",");
                    }

                    if (cdm1_denom4Changed)
                    {
                        qry.Append("cdm1_denom4 =" + cdm1_denom4DbString);
                        qry.Append(",");
                    }

                    if (cdm1_remaining4Changed)
                    {
                        qry.Append("cdm1_remaining4 =" + cdm1_remaining4DbString);
                        qry.Append(",");
                    }

                    if (cdm1_dispensed4Changed)
                    {
                        qry.Append("cdm1_dispensed4 =" + cdm1_dispensed4DbString);
                        qry.Append(",");
                    }

                    if (processing_datetimeChanged)
                    {
                        qry.Append("processing_datetime =" + processing_datetimeDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("parsed_transaction_cdm_detail_id = " + parsed_transaction_cdm_detail_idDbString);
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Parsed_transaction_cdm_detail where parsed_transaction_cdm_detail_id = " + parsed_transaction_cdm_detail_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteParsedTransactionCdmDetails(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Parsed_transaction_cdm_detail_id where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            parsed_transaction_cdm_detail_id = 1,
            atm_id = 2,
            trxn_datetime = 4,
            cdm2_raw1 = 8,
            cdm2_raw2 = 16,
            cdm2_raw3 = 32,
            cdm2_raw4 = 64,
            cdm2_denom1 = 128,
            cdm2_initial1 = 256,
            cdm2_dispensed1 = 512,
            cdm2_remaining1 = 1024,
            cdm2_purged1 = 2048,
            cdm2_denom2 = 4096,
            cdm2_initial2 = 8192,
            cdm2_dispensed2 = 16384,
            cdm2_remaining2 = 32768,
            cdm2_purged2 = 65536,
            cdm2_denom3 = 131072,
            cdm2_initial3 = 262144,
            cdm2_dispensed3 = 524288,
            cdm2_remaining3 = 1048576,
            cdm2_purged3 = 2097152,
            cdm2_denom4 = 4194304,
            cdm2_initial4 = 8388608,
            cdm2_dispensed4 = 16777216,
            cdm2_remaining4 = 33554432,
            cdm2_purged4 = 67108864,
            cdm1_raw1 = 134217728,
            cdm1_raw2 = 268435456,
            cdm1_raw3 = 536870912,
            cdm1_raw4 = 1073741824,
            cdm1_denom1 = 2147483648,
            cdm1_remaining1 = 4294967296,
            cdm1_dispensed1 = 8589934592,
            cdm1_denom2 = 17179869184,
            cdm1_remaining2 = 34359738368,
            cdm1_dispensed2 = 68719476736,
            cdm1_denom3 = 137438953472,
            cdm1_remaining3 = 274877906944,
            cdm1_dispensed3 = 549755813888,
            cdm1_denom4 = 1099511627776,
            cdm1_remaining4 = 2199023255552,
            cdm1_dispensed4 = 4398046511104,
            processing_datetime = 8796093022208,
            task_id = 8796093022209
        }
        #endregion
        public DataTable BulkSave(List<ParsedTransactionCdmDetail> dataArray)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringCash, SqlBulkCopyOptions.FireTriggers);
            bulk.DestinationTableName = "Parsed_transaction_cdm_detail";
            bulk.WriteToServer(dt);
            return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ParsedTransactionCdmDetail.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ParsedTransactionCdmDetail> transList, ref DataTable dt)
        {
            foreach (ParsedTransactionCdmDetail tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["parsed_transaction_cdm_detail_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["atm_id"] = tran.AtmId;
                Row["task_id"] = tran.TaskId.HasValue? (object)tran.TaskId.Value: DBNull.Value;
                Row["trxn_datetime"] = tran.TrxnDatetime;
                Row["cdm2_raw1"] = tran.Cdm2Raw1;
                Row["cdm2_raw2"] = tran.Cdm2Raw2;
                Row["cdm2_raw3"] = tran.Cdm2Raw3;
                Row["cdm2_raw4"] = tran.Cdm2Raw4;
                Row["cdm2_denom1"] = tran.Cdm2Denom1;
                Row["cdm2_initial1"] = tran.Cdm2Initial1;
                Row["cdm2_dispensed1"] = tran.Cdm2Dispensed1;
                Row["cdm2_remaining1"] = tran.Cdm2Remaining1;
                Row["cdm2_purged1"] = tran.Cdm2Purged1;
                Row["cdm2_denom2"] = tran.Cdm2Denom2;
                Row["cdm2_initial2"] = tran.Cdm2Initial2;
                Row["cdm2_dispensed2"] = tran.Cdm2Dispensed2;
                Row["cdm2_remaining2"] = tran.Cdm2Remaining2;
                Row["cdm2_purged2"] = tran.Cdm2Purged2;
                Row["cdm2_denom3"] = tran.Cdm2Denom3;
                Row["cdm2_initial3"] = tran.Cdm2Initial3;
                Row["cdm2_dispensed3"] = tran.Cdm2Dispensed3;
                Row["cdm2_remaining3"] = tran.Cdm2Remaining3;
                Row["cdm2_purged3"] = tran.Cdm2Purged3;
                Row["cdm2_denom4"] = tran.Cdm2Denom4;
                Row["cdm2_initial4"] = tran.Cdm2Initial4;
                Row["cdm2_dispensed4"] = tran.Cdm2Dispensed4;
                Row["cdm2_remaining4"] = tran.Cdm2Remaining4;
                Row["cdm2_purged4"] = tran.Cdm2Purged4;
                Row["cdm1_raw1"] = tran.Cdm1Raw1;
                Row["cdm1_raw2"] = tran.Cdm1Raw2;
                Row["cdm1_raw3"] = tran.Cdm1Raw3;
                Row["cdm1_raw4"] = tran.Cdm1Raw4;
                Row["cdm1_denom1"] = tran.Cdm1Denom1;
                Row["cdm1_remaining1"] = tran.Cdm1Remaining1;
                Row["cdm1_dispensed1"] = tran.Cdm1Dispensed1;
                Row["cdm1_denom2"] = tran.Cdm1Denom2;
                Row["cdm1_remaining2"] = tran.Cdm1Remaining2;
                Row["cdm1_dispensed2"] = tran.Cdm1Dispensed2;
                Row["cdm1_denom3"] = tran.Cdm1Denom3;
                Row["cdm1_remaining3"] = tran.Cdm1Remaining3;
                Row["cdm1_dispensed3"] = tran.Cdm1Dispensed3;
                Row["cdm1_denom4"] = tran.Cdm1Denom4;
                Row["cdm1_remaining4"] = tran.Cdm1Remaining4;
                Row["cdm1_dispensed4"] = tran.Cdm1Dispensed4;
                Row["processing_datetime"] = tran.ProcessingDatetime;
                dt.Rows.Add(Row);
            }
        }
    }
}

