
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
    public class ParsedTransaction
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ParsedTransaction() { }
        public ParsedTransaction(int atm_id, decimal amount, DateTime trxn_datetime, int cash_remaining1, int cash_remaining2, int cash_remaining3, int cash_remaining4, int cash_remaining5, int cash_remaining6, int cash_remaining7, int cash_dispensed1, int cash_dispensed2, int cash_dispensed3, int cash_dispensed4, int cash_dispensed5, int cash_dispensed6, int cash_dispensed7, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, int parsed_transaction_id, int task_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.cash_remaining1 = cash_remaining1;
            this.cash_remaining1Changed = true;
            this.cash_remaining2 = cash_remaining2;
            this.cash_remaining2Changed = true;
            this.cash_remaining3 = cash_remaining3;
            this.cash_remaining3Changed = true;
            this.cash_remaining4 = cash_remaining4;
            this.cash_remaining4Changed = true;
            this.cash_remaining5 = cash_remaining5;
            this.cash_remaining5Changed = true;
            this.cash_remaining6 = cash_remaining6;
            this.cash_remaining6Changed = true;
            this.cash_remaining7 = cash_remaining7;
            this.cash_remaining7Changed = true;
            this.cash_dispensed1 = cash_dispensed1;
            this.cash_dispensed1Changed = true;
            this.cash_dispensed2 = cash_dispensed2;
            this.cash_dispensed2Changed = true;
            this.cash_dispensed3 = cash_dispensed3;
            this.cash_dispensed3Changed = true;
            this.cash_dispensed4 = cash_dispensed4;
            this.cash_dispensed4Changed = true;
            this.cash_dispensed5 = cash_dispensed5;
            this.cash_dispensed5Changed = true;
            this.cash_dispensed6 = cash_dispensed6;
            this.cash_dispensed6Changed = true;
            this.cash_dispensed7 = cash_dispensed7;
            this.cash_dispensed7Changed = true;
            this.cash_purged1 = cash_purged1;
            this.cash_purged1Changed = true;
            this.cash_purged2 = cash_purged2;
            this.cash_purged2Changed = true;
            this.cash_purged3 = cash_purged3;
            this.cash_purged3Changed = true;
            this.cash_purged4 = cash_purged4;
            this.cash_purged4Changed = true;
            this.cash_purged5 = cash_purged5;
            this.cash_purged5Changed = true;
            this.cash_purged6 = cash_purged6;
            this.cash_purged6Changed = true;
            this.cash_purged7 = cash_purged7;
            this.cash_purged7Changed = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }
        public ParsedTransaction(int atm_id, decimal amount, DateTime trxn_datetime, int cash_remaining1, int cash_remaining2, int cash_remaining3, int cash_remaining4, int cash_remaining5, int cash_remaining6, int cash_remaining7, int cash_dispensed1, int cash_dispensed2, int cash_dispensed3, int cash_dispensed4, int cash_dispensed5, int cash_dispensed6, int cash_dispensed7, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, int task_id, string pan, string tsn, bool? is_auto_generated, DateTime? processing_datetime, bool? is_eligible)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.cash_remaining1 = cash_remaining1;
            this.cash_remaining1Changed = true;
            this.cash_remaining2 = cash_remaining2;
            this.cash_remaining2Changed = true;
            this.cash_remaining3 = cash_remaining3;
            this.cash_remaining3Changed = true;
            this.cash_remaining4 = cash_remaining4;
            this.cash_remaining4Changed = true;
            this.cash_remaining5 = cash_remaining5;
            this.cash_remaining5Changed = true;
            this.cash_remaining6 = cash_remaining6;
            this.cash_remaining6Changed = true;
            this.cash_remaining7 = cash_remaining7;
            this.cash_remaining7Changed = true;
            this.cash_dispensed1 = cash_dispensed1;
            this.cash_dispensed1Changed = true;
            this.cash_dispensed2 = cash_dispensed2;
            this.cash_dispensed2Changed = true;
            this.cash_dispensed3 = cash_dispensed3;
            this.cash_dispensed3Changed = true;
            this.cash_dispensed4 = cash_dispensed4;
            this.cash_dispensed4Changed = true;
            this.cash_dispensed5 = cash_dispensed5;
            this.cash_dispensed5Changed = true;
            this.cash_dispensed6 = cash_dispensed6;
            this.cash_dispensed6Changed = true;
            this.cash_dispensed7 = cash_dispensed7;
            this.cash_dispensed7Changed = true;
            this.cash_purged1 = cash_purged1;
            this.cash_purged1Changed = true;
            this.cash_purged2 = cash_purged2;
            this.cash_purged2Changed = true;
            this.cash_purged3 = cash_purged3;
            this.cash_purged3Changed = true;
            this.cash_purged4 = cash_purged4;
            this.cash_purged4Changed = true;
            this.cash_purged5 = cash_purged5;
            this.cash_purged5Changed = true;
            this.cash_purged6 = cash_purged6;
            this.cash_purged6Changed = true;
            this.cash_purged7 = cash_purged7;
            this.cash_purged7Changed = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
            this.is_auto_generated = is_auto_generated;
            this.is_auto_generatedChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
        }
        private ParsedTransaction(int atm_id, decimal amount, DateTime trxn_datetime, int cash_remaining1, int cash_remaining2, int cash_remaining3, int cash_remaining4, int cash_remaining5, int cash_remaining6, int cash_remaining7, int cash_dispensed1, int cash_dispensed2, int cash_dispensed3, int cash_dispensed4, int cash_dispensed5, int cash_dispensed6, int cash_dispensed7, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, int parsed_transaction_id, int task_id, string pan, string tsn, bool? is_auto_generated, DateTime? processing_datetime, bool? is_eligible)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.cash_remaining1 = cash_remaining1;
            this.cash_remaining1Changed = true;
            this.cash_remaining2 = cash_remaining2;
            this.cash_remaining2Changed = true;
            this.cash_remaining3 = cash_remaining3;
            this.cash_remaining3Changed = true;
            this.cash_remaining4 = cash_remaining4;
            this.cash_remaining4Changed = true;
            this.cash_remaining5 = cash_remaining5;
            this.cash_remaining5Changed = true;
            this.cash_remaining6 = cash_remaining6;
            this.cash_remaining6Changed = true;
            this.cash_remaining7 = cash_remaining7;
            this.cash_remaining7Changed = true;
            this.cash_dispensed1 = cash_dispensed1;
            this.cash_dispensed1Changed = true;
            this.cash_dispensed2 = cash_dispensed2;
            this.cash_dispensed2Changed = true;
            this.cash_dispensed3 = cash_dispensed3;
            this.cash_dispensed3Changed = true;
            this.cash_dispensed4 = cash_dispensed4;
            this.cash_dispensed4Changed = true;
            this.cash_dispensed5 = cash_dispensed5;
            this.cash_dispensed5Changed = true;
            this.cash_dispensed6 = cash_dispensed6;
            this.cash_dispensed6Changed = true;
            this.cash_dispensed7 = cash_dispensed7;
            this.cash_dispensed7Changed = true;
            this.cash_purged1 = cash_purged1;
            this.cash_purged1Changed = true;
            this.cash_purged2 = cash_purged2;
            this.cash_purged2Changed = true;
            this.cash_purged3 = cash_purged3;
            this.cash_purged3Changed = true;
            this.cash_purged4 = cash_purged4;
            this.cash_purged4Changed = true;
            this.cash_purged5 = cash_purged5;
            this.cash_purged5Changed = true;
            this.cash_purged6 = cash_purged6;
            this.cash_purged6Changed = true;
            this.cash_purged7 = cash_purged7;
            this.cash_purged7Changed = true;
            this.parsed_transaction_id = parsed_transaction_id;
            this.parsed_transaction_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
            this.is_auto_generated = is_auto_generated;
            this.is_auto_generatedChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
        }

        #region members and properties for columns

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
        #region Amount
        private bool amountChanged = false;
        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                amountChanged = true;
            }
        }
        private string amountDbString
        {
            get
            {
                return amount.ToString();
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
        #region CashRemaining1
        private bool cash_remaining1Changed = false;
        private int cash_remaining1;
        public int CashRemaining1
        {
            get { return cash_remaining1; }
            set
            {
                cash_remaining1 = value;
                cash_remaining1Changed = true;
            }
        }
        private string cash_remaining1DbString
        {
            get
            {
                return cash_remaining1.ToString();
            }
        }
        #endregion
        #region CashRemaining2
        private bool cash_remaining2Changed = false;
        private int cash_remaining2;
        public int CashRemaining2
        {
            get { return cash_remaining2; }
            set
            {
                cash_remaining2 = value;
                cash_remaining2Changed = true;
            }
        }
        private string cash_remaining2DbString
        {
            get
            {
                return cash_remaining2.ToString();
            }
        }
        #endregion
        #region CashRemaining3
        private bool cash_remaining3Changed = false;
        private int cash_remaining3;
        public int CashRemaining3
        {
            get { return cash_remaining3; }
            set
            {
                cash_remaining3 = value;
                cash_remaining3Changed = true;
            }
        }
        private string cash_remaining3DbString
        {
            get
            {
                return cash_remaining3.ToString();
            }
        }
        #endregion
        #region CashRemaining4
        private bool cash_remaining4Changed = false;
        private int cash_remaining4;
        public int CashRemaining4
        {
            get { return cash_remaining4; }
            set
            {
                cash_remaining4 = value;
                cash_remaining4Changed = true;
            }
        }
        private string cash_remaining4DbString
        {
            get
            {
                return cash_remaining4.ToString();
            }
        }
        #endregion
        #region CashRemaining5
        private bool cash_remaining5Changed = false;
        private int cash_remaining5;
        public int CashRemaining5
        {
            get { return cash_remaining5; }
            set
            {
                cash_remaining5 = value;
                cash_remaining5Changed = true;
            }
        }
        private string cash_remaining5DbString
        {
            get
            {
                return cash_remaining5.ToString();
            }
        }
        #endregion
        #region CashRemaining6
        private bool cash_remaining6Changed = false;
        private int cash_remaining6;
        public int CashRemaining6
        {
            get { return cash_remaining6; }
            set
            {
                cash_remaining6 = value;
                cash_remaining6Changed = true;
            }
        }
        private string cash_remaining6DbString
        {
            get
            {
                return cash_remaining6.ToString();
            }
        }
        #endregion
        #region CashRemaining7
        private bool cash_remaining7Changed = false;
        private int cash_remaining7;
        public int CashRemaining7
        {
            get { return cash_remaining7; }
            set
            {
                cash_remaining7 = value;
                cash_remaining7Changed = true;
            }
        }
        private string cash_remaining7DbString
        {
            get
            {
                return cash_remaining7.ToString();
            }
        }
        #endregion
        #region CashDispensed1
        private bool cash_dispensed1Changed = false;
        private int cash_dispensed1;
        public int CashDispensed1
        {
            get { return cash_dispensed1; }
            set
            {
                cash_dispensed1 = value;
                cash_dispensed1Changed = true;
            }
        }
        private string cash_dispensed1DbString
        {
            get
            {
                return cash_dispensed1.ToString();
            }
        }
        #endregion
        #region CashDispensed2
        private bool cash_dispensed2Changed = false;
        private int cash_dispensed2;
        public int CashDispensed2
        {
            get { return cash_dispensed2; }
            set
            {
                cash_dispensed2 = value;
                cash_dispensed2Changed = true;
            }
        }
        private string cash_dispensed2DbString
        {
            get
            {
                return cash_dispensed2.ToString();
            }
        }
        #endregion
        #region CashDispensed3
        private bool cash_dispensed3Changed = false;
        private int cash_dispensed3;
        public int CashDispensed3
        {
            get { return cash_dispensed3; }
            set
            {
                cash_dispensed3 = value;
                cash_dispensed3Changed = true;
            }
        }
        private string cash_dispensed3DbString
        {
            get
            {
                return cash_dispensed3.ToString();
            }
        }
        #endregion
        #region CashDispensed4
        private bool cash_dispensed4Changed = false;
        private int cash_dispensed4;
        public int CashDispensed4
        {
            get { return cash_dispensed4; }
            set
            {
                cash_dispensed4 = value;
                cash_dispensed4Changed = true;
            }
        }
        private string cash_dispensed4DbString
        {
            get
            {
                return cash_dispensed4.ToString();
            }
        }
        #endregion
        #region CashDispensed5
        private bool cash_dispensed5Changed = false;
        private int cash_dispensed5;
        public int CashDispensed5
        {
            get { return cash_dispensed5; }
            set
            {
                cash_dispensed5 = value;
                cash_dispensed5Changed = true;
            }
        }
        private string cash_dispensed5DbString
        {
            get
            {
                return cash_dispensed5.ToString();
            }
        }
        #endregion
        #region CashDispensed6
        private bool cash_dispensed6Changed = false;
        private int cash_dispensed6;
        public int CashDispensed6
        {
            get { return cash_dispensed6; }
            set
            {
                cash_dispensed6 = value;
                cash_dispensed6Changed = true;
            }
        }
        private string cash_dispensed6DbString
        {
            get
            {
                return cash_dispensed6.ToString();
            }
        }
        #endregion
        #region CashDispensed7
        private bool cash_dispensed7Changed = false;
        private int cash_dispensed7;
        public int CashDispensed7
        {
            get { return cash_dispensed7; }
            set
            {
                cash_dispensed7 = value;
                cash_dispensed7Changed = true;
            }
        }
        private string cash_dispensed7DbString
        {
            get
            {
                return cash_dispensed7.ToString();
            }
        }
        #endregion
        #region CashPurged1
        private bool cash_purged1Changed = false;
        private int cash_purged1;
        public int CashPurged1
        {
            get { return cash_purged1; }
            set
            {
                cash_purged1 = value;
                cash_purged1Changed = true;
            }
        }
        private string cash_purged1DbString
        {
            get
            {
                return cash_purged1.ToString();
            }
        }
        #endregion
        #region CashPurged2
        private bool cash_purged2Changed = false;
        private int cash_purged2;
        public int CashPurged2
        {
            get { return cash_purged2; }
            set
            {
                cash_purged2 = value;
                cash_purged2Changed = true;
            }
        }
        private string cash_purged2DbString
        {
            get
            {
                return cash_purged2.ToString();
            }
        }
        #endregion
        #region CashPurged3
        private bool cash_purged3Changed = false;
        private int cash_purged3;
        public int CashPurged3
        {
            get { return cash_purged3; }
            set
            {
                cash_purged3 = value;
                cash_purged3Changed = true;
            }
        }
        private string cash_purged3DbString
        {
            get
            {
                return cash_purged3.ToString();
            }
        }
        #endregion
        #region CashPurged4
        private bool cash_purged4Changed = false;
        private int cash_purged4;
        public int CashPurged4
        {
            get { return cash_purged4; }
            set
            {
                cash_purged4 = value;
                cash_purged4Changed = true;
            }
        }
        private string cash_purged4DbString
        {
            get
            {
                return cash_purged4.ToString();
            }
        }
        #endregion
        #region CashPurged5
        private bool cash_purged5Changed = false;
        private int cash_purged5;
        public int CashPurged5
        {
            get { return cash_purged5; }
            set
            {
                cash_purged5 = value;
                cash_purged5Changed = true;
            }
        }
        private string cash_purged5DbString
        {
            get
            {
                return cash_purged5.ToString();
            }
        }
        #endregion
        #region CashPurged6
        private bool cash_purged6Changed = false;
        private int cash_purged6;
        public int CashPurged6
        {
            get { return cash_purged6; }
            set
            {
                cash_purged6 = value;
                cash_purged6Changed = true;
            }
        }
        private string cash_purged6DbString
        {
            get
            {
                return cash_purged6.ToString();
            }
        }
        #endregion
        #region CashPurged7
        private bool cash_purged7Changed = false;
        private int cash_purged7;
        public int CashPurged7
        {
            get { return cash_purged7; }
            set
            {
                cash_purged7 = value;
                cash_purged7Changed = true;
            }
        }
        private string cash_purged7DbString
        {
            get
            {
                return cash_purged7.ToString();
            }
        }
        #endregion
        #region ParsedTransactionId
        private bool parsed_transaction_idChanged = false;
        private int parsed_transaction_id;
        public int ParsedTransactionId
        {
            get { return parsed_transaction_id; }
            set
            {
                parsed_transaction_id = value;
                parsed_transaction_idChanged = true;
            }
        }
        private string parsed_transaction_idDbString
        {
            get
            {
                return parsed_transaction_id.ToString();
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
        #region Pan
        private bool panChanged = false;
        private string pan;
        public string Pan
        {
            get { return pan; }
            set
            {
                pan = value;
                panChanged = true;
            }
        }
        private string panDbString
        {
            get
            {
                if (this.pan != null)
                    return string.Format("'{0}'", pan);
                else
                    return "null";
            }
        }
        #endregion
        #region Tsn
        private bool tsnChanged = false;
        private string tsn;
        public string Tsn
        {
            get { return tsn; }
            set
            {
                tsn = value;
                tsnChanged = true;
            }
        }
        private string tsnDbString
        {
            get
            {
                if (this.tsn != null)
                    return string.Format("'{0}'", tsn);
                else
                    return "null";
            }
        }
        #endregion
        #region IsAutoGenerated
        private bool is_auto_generatedChanged = false;
        private bool? is_auto_generated;
        public bool? IsAutoGenerated
        {
            get { return is_auto_generated; }
            set
            {
                is_auto_generated = value;
                is_auto_generatedChanged = true;
            }
        }
        private string is_auto_generatedDbString
        {
            get
            {
                if (this.is_auto_generated.HasValue)
                    return is_auto_generated.Value ? "1" : "0";
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
        #region IsEligible
        private bool is_eligibleChanged = false;
        private bool? is_eligible;
        public bool? IsEligible
        {
            get { return is_eligible; }
            set
            {
                is_eligible = value;
                is_eligibleChanged = true;
            }
        }
        private string is_eligibleDbString
        {
            get
            {
                if (this.is_eligible.HasValue)
                    return is_eligible.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region ParsedTransactionReader
        public class ParsedTransactionReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ParsedTransaction currentParsedTransaction;
            Columns columns;
            bool partialRead = false;
            private ParsedTransactionReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ParsedTransactionReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ParsedTransactionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentParsedTransaction; }

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
                    currentParsedTransaction = new ParsedTransaction();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentParsedTransaction.atm_id = (int)reader["atm_id"];
                        if ((columns & Columns.amount) == Columns.amount && reader["amount"] != DBNull.Value)
                            currentParsedTransaction.amount = (decimal)reader["amount"];
                        if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"] != DBNull.Value)
                            currentParsedTransaction.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if ((columns & Columns.cash_remaining1) == Columns.cash_remaining1 && reader["cash_remaining1"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining1 = (int)reader["cash_remaining1"];
                        if ((columns & Columns.cash_remaining2) == Columns.cash_remaining2 && reader["cash_remaining2"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining2 = (int)reader["cash_remaining2"];
                        if ((columns & Columns.cash_remaining3) == Columns.cash_remaining3 && reader["cash_remaining3"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining3 = (int)reader["cash_remaining3"];
                        if ((columns & Columns.cash_remaining4) == Columns.cash_remaining4 && reader["cash_remaining4"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining4 = (int)reader["cash_remaining4"];
                        if ((columns & Columns.cash_remaining5) == Columns.cash_remaining5 && reader["cash_remaining5"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining5 = (int)reader["cash_remaining5"];
                        if ((columns & Columns.cash_remaining6) == Columns.cash_remaining6 && reader["cash_remaining6"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining6 = (int)reader["cash_remaining6"];
                        if ((columns & Columns.cash_remaining7) == Columns.cash_remaining7 && reader["cash_remaining7"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining7 = (int)reader["cash_remaining7"];
                        if ((columns & Columns.cash_dispensed1) == Columns.cash_dispensed1 && reader["cash_dispensed1"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed1 = (int)reader["cash_dispensed1"];
                        if ((columns & Columns.cash_dispensed2) == Columns.cash_dispensed2 && reader["cash_dispensed2"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed2 = (int)reader["cash_dispensed2"];
                        if ((columns & Columns.cash_dispensed3) == Columns.cash_dispensed3 && reader["cash_dispensed3"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed3 = (int)reader["cash_dispensed3"];
                        if ((columns & Columns.cash_dispensed4) == Columns.cash_dispensed4 && reader["cash_dispensed4"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed4 = (int)reader["cash_dispensed4"];
                        if ((columns & Columns.cash_dispensed5) == Columns.cash_dispensed5 && reader["cash_dispensed5"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed5 = (int)reader["cash_dispensed5"];
                        if ((columns & Columns.cash_dispensed6) == Columns.cash_dispensed6 && reader["cash_dispensed6"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed6 = (int)reader["cash_dispensed6"];
                        if ((columns & Columns.cash_dispensed7) == Columns.cash_dispensed7 && reader["cash_dispensed7"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed7 = (int)reader["cash_dispensed7"];
                        if ((columns & Columns.cash_purged1) == Columns.cash_purged1 && reader["cash_purged1"] != DBNull.Value)
                            currentParsedTransaction.cash_purged1 = (int)reader["cash_purged1"];
                        if ((columns & Columns.cash_purged2) == Columns.cash_purged2 && reader["cash_purged2"] != DBNull.Value)
                            currentParsedTransaction.cash_purged2 = (int)reader["cash_purged2"];
                        if ((columns & Columns.cash_purged3) == Columns.cash_purged3 && reader["cash_purged3"] != DBNull.Value)
                            currentParsedTransaction.cash_purged3 = (int)reader["cash_purged3"];
                        if ((columns & Columns.cash_purged4) == Columns.cash_purged4 && reader["cash_purged4"] != DBNull.Value)
                            currentParsedTransaction.cash_purged4 = (int)reader["cash_purged4"];
                        if ((columns & Columns.cash_purged5) == Columns.cash_purged5 && reader["cash_purged5"] != DBNull.Value)
                            currentParsedTransaction.cash_purged5 = (int)reader["cash_purged5"];
                        if ((columns & Columns.cash_purged6) == Columns.cash_purged6 && reader["cash_purged6"] != DBNull.Value)
                            currentParsedTransaction.cash_purged6 = (int)reader["cash_purged6"];
                        if ((columns & Columns.cash_purged7) == Columns.cash_purged7 && reader["cash_purged7"] != DBNull.Value)
                            currentParsedTransaction.cash_purged7 = (int)reader["cash_purged7"];
                        if ((columns & Columns.parsed_transaction_id) == Columns.parsed_transaction_id && reader["parsed_transaction_id"] != DBNull.Value)
                            currentParsedTransaction.parsed_transaction_id = (int)reader["parsed_transaction_id"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentParsedTransaction.task_id = (int)reader["task_id"];
                        if ((columns & Columns.pan) == Columns.pan && reader["pan"] != DBNull.Value)
                            currentParsedTransaction.pan = (string)reader["pan"];
                        if ((columns & Columns.tsn) == Columns.tsn && reader["tsn"] != DBNull.Value)
                            currentParsedTransaction.tsn = (string)reader["tsn"];
                        if ((columns & Columns.is_auto_generated) == Columns.is_auto_generated && reader["is_auto_generated"] != DBNull.Value)
                            currentParsedTransaction.is_auto_generated = (bool?)reader["is_auto_generated"];
                        if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"] != DBNull.Value)
                            currentParsedTransaction.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if ((columns & Columns.is_eligible) == Columns.is_eligible && reader["is_eligible"] != DBNull.Value)
                            currentParsedTransaction.is_eligible = (bool?)reader["is_eligible"];

                    }
                    else
                    {
                        if (reader["atm_id"] != DBNull.Value)
                            currentParsedTransaction.atm_id = (int)reader["atm_id"];
                        if (reader["amount"] != DBNull.Value)
                            currentParsedTransaction.amount = (decimal)reader["amount"];
                        if (reader["trxn_datetime"] != DBNull.Value)
                            currentParsedTransaction.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if (reader["cash_remaining1"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining1 = (int)reader["cash_remaining1"];
                        if (reader["cash_remaining2"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining2 = (int)reader["cash_remaining2"];
                        if (reader["cash_remaining3"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining3 = (int)reader["cash_remaining3"];
                        if (reader["cash_remaining4"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining4 = (int)reader["cash_remaining4"];
                        if (reader["cash_remaining5"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining5 = (int)reader["cash_remaining5"];
                        if (reader["cash_remaining6"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining6 = (int)reader["cash_remaining6"];
                        if (reader["cash_remaining7"] != DBNull.Value)
                            currentParsedTransaction.cash_remaining7 = (int)reader["cash_remaining7"];
                        if (reader["cash_dispensed1"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed1 = (int)reader["cash_dispensed1"];
                        if (reader["cash_dispensed2"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed2 = (int)reader["cash_dispensed2"];
                        if (reader["cash_dispensed3"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed3 = (int)reader["cash_dispensed3"];
                        if (reader["cash_dispensed4"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed4 = (int)reader["cash_dispensed4"];
                        if (reader["cash_dispensed5"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed5 = (int)reader["cash_dispensed5"];
                        if (reader["cash_dispensed6"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed6 = (int)reader["cash_dispensed6"];
                        if (reader["cash_dispensed7"] != DBNull.Value)
                            currentParsedTransaction.cash_dispensed7 = (int)reader["cash_dispensed7"];
                        if (reader["cash_purged1"] != DBNull.Value)
                            currentParsedTransaction.cash_purged1 = (int)reader["cash_purged1"];
                        if (reader["cash_purged2"] != DBNull.Value)
                            currentParsedTransaction.cash_purged2 = (int)reader["cash_purged2"];
                        if (reader["cash_purged3"] != DBNull.Value)
                            currentParsedTransaction.cash_purged3 = (int)reader["cash_purged3"];
                        if (reader["cash_purged4"] != DBNull.Value)
                            currentParsedTransaction.cash_purged4 = (int)reader["cash_purged4"];
                        if (reader["cash_purged5"] != DBNull.Value)
                            currentParsedTransaction.cash_purged5 = (int)reader["cash_purged5"];
                        if (reader["cash_purged6"] != DBNull.Value)
                            currentParsedTransaction.cash_purged6 = (int)reader["cash_purged6"];
                        if (reader["cash_purged7"] != DBNull.Value)
                            currentParsedTransaction.cash_purged7 = (int)reader["cash_purged7"];
                        if (reader["parsed_transaction_id"] != DBNull.Value)
                            currentParsedTransaction.parsed_transaction_id = (int)reader["parsed_transaction_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentParsedTransaction.task_id = (int)reader["task_id"];
                        if (reader["pan"] != DBNull.Value)
                            currentParsedTransaction.pan = (string)reader["pan"];
                        if (reader["tsn"] != DBNull.Value)
                            currentParsedTransaction.tsn = (string)reader["tsn"];
                        if (reader["is_auto_generated"] != DBNull.Value)
                            currentParsedTransaction.is_auto_generated = (bool?)reader["is_auto_generated"];
                        if (reader["processing_datetime"] != DBNull.Value)
                            currentParsedTransaction.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if (reader["is_eligible"] != DBNull.Value)
                            currentParsedTransaction.is_eligible = (bool?)reader["is_eligible"];
                    }

                    currentParsedTransaction.isNewEntity = false;
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

            public ParsedTransaction CurrentParsedTransaction
            {
                get { return currentParsedTransaction; }
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


        #region ParsedTransaction functions

        public static ParsedTransactionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.amount == (Columns.amount & columns))
                qry.Append("amount,");
            if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
                qry.Append("trxn_datetime,");
            if (Columns.cash_remaining1 == (Columns.cash_remaining1 & columns))
                qry.Append("cash_remaining1,");
            if (Columns.cash_remaining2 == (Columns.cash_remaining2 & columns))
                qry.Append("cash_remaining2,");
            if (Columns.cash_remaining3 == (Columns.cash_remaining3 & columns))
                qry.Append("cash_remaining3,");
            if (Columns.cash_remaining4 == (Columns.cash_remaining4 & columns))
                qry.Append("cash_remaining4,");
            if (Columns.cash_remaining5 == (Columns.cash_remaining5 & columns))
                qry.Append("cash_remaining5,");
            if (Columns.cash_remaining6 == (Columns.cash_remaining6 & columns))
                qry.Append("cash_remaining6,");
            if (Columns.cash_remaining7 == (Columns.cash_remaining7 & columns))
                qry.Append("cash_remaining7,");
            if (Columns.cash_dispensed1 == (Columns.cash_dispensed1 & columns))
                qry.Append("cash_dispensed1,");
            if (Columns.cash_dispensed2 == (Columns.cash_dispensed2 & columns))
                qry.Append("cash_dispensed2,");
            if (Columns.cash_dispensed3 == (Columns.cash_dispensed3 & columns))
                qry.Append("cash_dispensed3,");
            if (Columns.cash_dispensed4 == (Columns.cash_dispensed4 & columns))
                qry.Append("cash_dispensed4,");
            if (Columns.cash_dispensed5 == (Columns.cash_dispensed5 & columns))
                qry.Append("cash_dispensed5,");
            if (Columns.cash_dispensed6 == (Columns.cash_dispensed6 & columns))
                qry.Append("cash_dispensed6,");
            if (Columns.cash_dispensed7 == (Columns.cash_dispensed7 & columns))
                qry.Append("cash_dispensed7,");
            if (Columns.cash_purged1 == (Columns.cash_purged1 & columns))
                qry.Append("cash_purged1,");
            if (Columns.cash_purged2 == (Columns.cash_purged2 & columns))
                qry.Append("cash_purged2,");
            if (Columns.cash_purged3 == (Columns.cash_purged3 & columns))
                qry.Append("cash_purged3,");
            if (Columns.cash_purged4 == (Columns.cash_purged4 & columns))
                qry.Append("cash_purged4,");
            if (Columns.cash_purged5 == (Columns.cash_purged5 & columns))
                qry.Append("cash_purged5,");
            if (Columns.cash_purged6 == (Columns.cash_purged6 & columns))
                qry.Append("cash_purged6,");
            if (Columns.cash_purged7 == (Columns.cash_purged7 & columns))
                qry.Append("cash_purged7,");
            if (Columns.parsed_transaction_id == (Columns.parsed_transaction_id & columns))
                qry.Append("parsed_transaction_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.pan == (Columns.pan & columns))
                qry.Append("pan,");
            if (Columns.tsn == (Columns.tsn & columns))
                qry.Append("tsn,");
            if (Columns.is_auto_generated == (Columns.is_auto_generated & columns))
                qry.Append("is_auto_generated,");
            if (Columns.processing_datetime == (Columns.processing_datetime & columns))
                qry.Append("processing_datetime,");
            if (Columns.is_eligible == (Columns.is_eligible & columns))
                qry.Append("is_eligible,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Parsed_transaction ");

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
            return new ParsedTransactionReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ParsedTransactionReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ParsedTransactionReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_id,amount,trxn_datetime,cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,cash_remaining5,cash_remaining6,cash_remaining7,cash_dispensed1,cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,cash_purged1,cash_purged2,cash_purged3,cash_purged4,cash_purged5,cash_purged6,cash_purged7,parsed_transaction_id,task_id,pan,tsn,is_auto_generated,processing_datetime,is_eligible from Parsed_transaction ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ParsedTransactionReader(cmd.ExecuteReader(), conn);
        }

        static public ParsedTransactionReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static ParsedTransaction LoadParsedTransaction(string where)
        {
            ParsedTransactionReader reader = ParsedTransaction.ExecuteReader(where);
            ParsedTransaction _parsedtransaction = null;
            if (reader.Read())
                _parsedtransaction = reader.CurrentParsedTransaction;
            reader.Close();
            return _parsedtransaction;
        }

        public static ParsedTransaction LoadParsedTransaction(string where, IDbConnection conn)
        {
            ParsedTransactionReader reader = ParsedTransaction.ExecuteReader(where, conn);
            ParsedTransaction _parsedtransaction = null;
            if (reader.Read())
                _parsedtransaction = reader.CurrentParsedTransaction;
            reader.Close(false);
            return _parsedtransaction;
        }

        public static ParsedTransaction LoadParsedTransactionByPk(int parsed_transaction_id)
        {
            return LoadParsedTransaction("parsed_transaction_id=" + parsed_transaction_id);
        }

        public static ParsedTransaction LoadParsedTransactionByPk(int parsed_transaction_id, IDbConnection conn)
        {
            return LoadParsedTransaction(" parsed_transaction_id=" + parsed_transaction_id, conn);
        }

        public void Save()
        {
            if (atm_idChanged || amountChanged || trxn_datetimeChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || cash_dispensed1Changed || cash_dispensed2Changed || cash_dispensed3Changed || cash_dispensed4Changed || cash_dispensed5Changed || cash_dispensed6Changed || cash_dispensed7Changed || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || parsed_transaction_idChanged || task_idChanged || panChanged || tsnChanged || is_auto_generatedChanged || processing_datetimeChanged || is_eligibleChanged)
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
            if (atm_idChanged || amountChanged || trxn_datetimeChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || cash_dispensed1Changed || cash_dispensed2Changed || cash_dispensed3Changed || cash_dispensed4Changed || cash_dispensed5Changed || cash_dispensed6Changed || cash_dispensed7Changed || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || parsed_transaction_idChanged || task_idChanged || panChanged || tsnChanged || is_auto_generatedChanged || processing_datetimeChanged || is_eligibleChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Parsed_transaction(atm_id,amount,trxn_datetime,cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,cash_remaining5,cash_remaining6,cash_remaining7,cash_dispensed1,cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,cash_purged1,cash_purged2,cash_purged3,cash_purged4,cash_purged5,cash_purged6,cash_purged7,parsed_transaction_id,task_id,pan,tsn,is_auto_generated,processing_datetime,is_eligible) values(");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(amountDbString + ",");
                    qry.Append(trxn_datetimeDbString + ",");
                    qry.Append(cash_remaining1DbString + ",");
                    qry.Append(cash_remaining2DbString + ",");
                    qry.Append(cash_remaining3DbString + ",");
                    qry.Append(cash_remaining4DbString + ",");
                    qry.Append(cash_remaining5DbString + ",");
                    qry.Append(cash_remaining6DbString + ",");
                    qry.Append(cash_remaining7DbString + ",");
                    qry.Append(cash_dispensed1DbString + ",");
                    qry.Append(cash_dispensed2DbString + ",");
                    qry.Append(cash_dispensed3DbString + ",");
                    qry.Append(cash_dispensed4DbString + ",");
                    qry.Append(cash_dispensed5DbString + ",");
                    qry.Append(cash_dispensed6DbString + ",");
                    qry.Append(cash_dispensed7DbString + ",");
                    qry.Append(cash_purged1DbString + ",");
                    qry.Append(cash_purged2DbString + ",");
                    qry.Append(cash_purged3DbString + ",");
                    qry.Append(cash_purged4DbString + ",");
                    qry.Append(cash_purged5DbString + ",");
                    qry.Append(cash_purged6DbString + ",");
                    qry.Append(cash_purged7DbString + ",");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.parsed_transaction_id = ConnectionFactory.GetNextId();
                        qry.Append(this.parsed_transaction_id);
                    } qry.Append(",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(panDbString + ",");
                    qry.Append(tsnDbString + ",");
                    qry.Append(is_auto_generatedDbString + ",");
                    qry.Append(processing_datetimeDbString + ",");
                    qry.Append(is_eligibleDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_idChanged || amountChanged || trxn_datetimeChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || cash_dispensed1Changed || cash_dispensed2Changed || cash_dispensed3Changed || cash_dispensed4Changed || cash_dispensed5Changed || cash_dispensed6Changed || cash_dispensed7Changed || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || parsed_transaction_idChanged || task_idChanged || panChanged || tsnChanged || is_auto_generatedChanged || processing_datetimeChanged || is_eligibleChanged))
                        return;
                    qry.Append("UPDATE Parsed_transaction set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (amountChanged)
                    {
                        qry.Append("amount =" + amountDbString);
                        qry.Append(",");
                    }

                    if (trxn_datetimeChanged)
                    {
                        qry.Append("trxn_datetime =" + trxn_datetimeDbString);
                        qry.Append(",");
                    }

                    if (cash_remaining1Changed)
                    {
                        qry.Append("cash_remaining1 =" + cash_remaining1DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining2Changed)
                    {
                        qry.Append("cash_remaining2 =" + cash_remaining2DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining3Changed)
                    {
                        qry.Append("cash_remaining3 =" + cash_remaining3DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining4Changed)
                    {
                        qry.Append("cash_remaining4 =" + cash_remaining4DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining5Changed)
                    {
                        qry.Append("cash_remaining5 =" + cash_remaining5DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining6Changed)
                    {
                        qry.Append("cash_remaining6 =" + cash_remaining6DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining7Changed)
                    {
                        qry.Append("cash_remaining7 =" + cash_remaining7DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed1Changed)
                    {
                        qry.Append("cash_dispensed1 =" + cash_dispensed1DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed2Changed)
                    {
                        qry.Append("cash_dispensed2 =" + cash_dispensed2DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed3Changed)
                    {
                        qry.Append("cash_dispensed3 =" + cash_dispensed3DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed4Changed)
                    {
                        qry.Append("cash_dispensed4 =" + cash_dispensed4DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed5Changed)
                    {
                        qry.Append("cash_dispensed5 =" + cash_dispensed5DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed6Changed)
                    {
                        qry.Append("cash_dispensed6 =" + cash_dispensed6DbString);
                        qry.Append(",");
                    }

                    if (cash_dispensed7Changed)
                    {
                        qry.Append("cash_dispensed7 =" + cash_dispensed7DbString);
                        qry.Append(",");
                    }

                    if (cash_purged1Changed)
                    {
                        qry.Append("cash_purged1 =" + cash_purged1DbString);
                        qry.Append(",");
                    }

                    if (cash_purged2Changed)
                    {
                        qry.Append("cash_purged2 =" + cash_purged2DbString);
                        qry.Append(",");
                    }

                    if (cash_purged3Changed)
                    {
                        qry.Append("cash_purged3 =" + cash_purged3DbString);
                        qry.Append(",");
                    }

                    if (cash_purged4Changed)
                    {
                        qry.Append("cash_purged4 =" + cash_purged4DbString);
                        qry.Append(",");
                    }

                    if (cash_purged5Changed)
                    {
                        qry.Append("cash_purged5 =" + cash_purged5DbString);
                        qry.Append(",");
                    }

                    if (cash_purged6Changed)
                    {
                        qry.Append("cash_purged6 =" + cash_purged6DbString);
                        qry.Append(",");
                    }

                    if (cash_purged7Changed)
                    {
                        qry.Append("cash_purged7 =" + cash_purged7DbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (panChanged)
                    {
                        qry.Append("pan =" + panDbString);
                        qry.Append(",");
                    }

                    if (tsnChanged)
                    {
                        qry.Append("tsn =" + tsnDbString);
                        qry.Append(",");
                    }

                    if (is_auto_generatedChanged)
                    {
                        qry.Append("is_auto_generated =" + is_auto_generatedDbString);
                        qry.Append(",");
                    }

                    if (processing_datetimeChanged)
                    {
                        qry.Append("processing_datetime =" + processing_datetimeDbString);
                        qry.Append(",");
                    }

                    if (is_eligibleChanged)
                    {
                        qry.Append("is_eligible =" + is_eligibleDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("parsed_transaction_id = " + parsed_transaction_idDbString);
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
            cmd.CommandText = "DELETE Parsed_transaction whereparsed_transaction_id= " + parsed_transaction_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteParsedTransactions(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Parsed_transaction where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_id = 1,
            amount = 2,
            trxn_datetime = 4,
            cash_remaining1 = 8,
            cash_remaining2 = 16,
            cash_remaining3 = 32,
            cash_remaining4 = 64,
            cash_remaining5 = 128,
            cash_remaining6 = 256,
            cash_remaining7 = 512,
            cash_dispensed1 = 1024,
            cash_dispensed2 = 2048,
            cash_dispensed3 = 4096,
            cash_dispensed4 = 8192,
            cash_dispensed5 = 16384,
            cash_dispensed6 = 32768,
            cash_dispensed7 = 65536,
            cash_purged1 = 131072,
            cash_purged2 = 262144,
            cash_purged3 = 524288,
            cash_purged4 = 1048576,
            cash_purged5 = 2097152,
            cash_purged6 = 4194304,
            cash_purged7 = 8388608,
            parsed_transaction_id = 16777216,
            task_id = 33554432,
            pan = 67108864,
            tsn = 134217728,
            is_auto_generated = 268435456,
            processing_datetime = 536870912,
            is_eligible = 1073741824
        }
        #endregion
        public DataTable BulkSave(List<ParsedTransaction> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Parsed_transaction";
            bulk.WriteToServer(dt);
            return dt;
        }

        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ParsedTransaction.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ParsedTransaction> transList, ref DataTable dt)
        {
            foreach (ParsedTransaction tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_id"] = tran.AtmId;
                Row["amount"] = tran.Amount;
                Row["trxn_datetime"] = tran.TrxnDatetime;
                Row["cash_remaining1"] = tran.CashRemaining1;
                Row["cash_remaining2"] = tran.CashRemaining2;
                Row["cash_remaining3"] = tran.CashRemaining3;
                Row["cash_remaining4"] = tran.CashRemaining4;
                Row["cash_remaining5"] = tran.CashRemaining5;
                Row["cash_remaining6"] = tran.CashRemaining6;
                Row["cash_remaining7"] = tran.CashRemaining7;
                Row["cash_dispensed1"] = tran.CashDispensed1;
                Row["cash_dispensed2"] = tran.CashDispensed2;
                Row["cash_dispensed3"] = tran.CashDispensed3;
                Row["cash_dispensed4"] = tran.CashDispensed4;
                Row["cash_dispensed5"] = tran.CashDispensed5;
                Row["cash_dispensed6"] = tran.CashDispensed6;
                Row["cash_dispensed7"] = tran.CashDispensed7;
                Row["cash_purged1"] = tran.CashPurged1;
                Row["cash_purged2"] = tran.CashPurged2;
                Row["cash_purged3"] = tran.CashPurged3;
                Row["cash_purged4"] = tran.CashPurged4;
                Row["cash_purged5"] = tran.CashPurged5;
                Row["cash_purged6"] = tran.CashPurged6;
                Row["cash_purged7"] = tran.CashPurged7;
                Row["parsed_transaction_id"] = ConnectionFactory.GetNextId();
                Row["task_id"] = tran.TaskId;
                Row["pan"] = tran.Pan;
                Row["tsn"] = tran.Tsn;
                Row["is_auto_generated"] = tran.IsAutoGenerated;
                Row["processing_datetime"] = tran.ProcessingDatetime;
                Row["is_eligible"] = tran.IsEligible;
                dt.Rows.Add(Row);
            }
        }
    }
}


