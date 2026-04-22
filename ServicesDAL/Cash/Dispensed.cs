
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;

using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class Dispensed
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Dispensed() { }
        public Dispensed(long atm_id, int cash_remaining1, int cash_remaining2, int cash_remaining3, int cash_remaining4, int cash_remaining5, int cash_remaining6, int cash_remaining7, int cash_dispensed1, int cash_dispensed2, int cash_dispensed3, int cash_dispensed4, int cash_dispensed5, int cash_dispensed6, int cash_dispensed7, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, DateTime clearing_datetime, long task_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
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
            this.clearing_datetime = clearing_datetime;
            this.clearing_datetimeChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }
        private Dispensed(long atm_id, int cash_remaining1, int cash_remaining2, int cash_remaining3, int cash_remaining4, int cash_remaining5, int cash_remaining6, int cash_remaining7, int cash_dispensed1, int cash_dispensed2, int cash_dispensed3, int cash_dispensed4, int cash_dispensed5, int cash_dispensed6, int cash_dispensed7, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, DateTime clearing_datetime, long dispensed_id, long task_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
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
            this.clearing_datetime = clearing_datetime;
            this.clearing_datetimeChanged = true;
            this.dispensed_id = dispensed_id;
            this.dispensed_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }

        #region members and properties for columns

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
        #region DispensedId
        private bool dispensed_idChanged = false;
        private long dispensed_id;
        public long DispensedId
        {
            get { return dispensed_id; }
            set
            {
                dispensed_id = value;
                dispensed_idChanged = true;
            }
        }
        private string dispensed_idDbString
        {
            get
            {
                return dispensed_id.ToString();
            }
        }
        #endregion
        #region TaskId
        private bool task_idChanged = false;
        private long task_id;
        public long TaskId
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
        #endregion

        #region DispensedReader
        public class DispensedReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Dispensed currentDispensed;
            Columns columns;
            bool partialRead = false;
            private DispensedReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public DispensedReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public DispensedReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentDispensed; }

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
                    currentDispensed = new Dispensed();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentDispensed.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.cash_remaining1) == Columns.cash_remaining1 && reader["cash_remaining1"] != DBNull.Value)
                            currentDispensed.cash_remaining1 = (int)reader["cash_remaining1"];
                        if ((columns & Columns.cash_remaining2) == Columns.cash_remaining2 && reader["cash_remaining2"] != DBNull.Value)
                            currentDispensed.cash_remaining2 = (int)reader["cash_remaining2"];
                        if ((columns & Columns.cash_remaining3) == Columns.cash_remaining3 && reader["cash_remaining3"] != DBNull.Value)
                            currentDispensed.cash_remaining3 = (int)reader["cash_remaining3"];
                        if ((columns & Columns.cash_remaining4) == Columns.cash_remaining4 && reader["cash_remaining4"] != DBNull.Value)
                            currentDispensed.cash_remaining4 = (int)reader["cash_remaining4"];
                        if ((columns & Columns.cash_remaining5) == Columns.cash_remaining5 && reader["cash_remaining5"] != DBNull.Value)
                            currentDispensed.cash_remaining5 = (int)reader["cash_remaining5"];
                        if ((columns & Columns.cash_remaining6) == Columns.cash_remaining6 && reader["cash_remaining6"] != DBNull.Value)
                            currentDispensed.cash_remaining6 = (int)reader["cash_remaining6"];
                        if ((columns & Columns.cash_remaining7) == Columns.cash_remaining7 && reader["cash_remaining7"] != DBNull.Value)
                            currentDispensed.cash_remaining7 = (int)reader["cash_remaining7"];
                        if ((columns & Columns.cash_dispensed1) == Columns.cash_dispensed1 && reader["cash_dispensed1"] != DBNull.Value)
                            currentDispensed.cash_dispensed1 = (int)reader["cash_dispensed1"];
                        if ((columns & Columns.cash_dispensed2) == Columns.cash_dispensed2 && reader["cash_dispensed2"] != DBNull.Value)
                            currentDispensed.cash_dispensed2 = (int)reader["cash_dispensed2"];
                        if ((columns & Columns.cash_dispensed3) == Columns.cash_dispensed3 && reader["cash_dispensed3"] != DBNull.Value)
                            currentDispensed.cash_dispensed3 = (int)reader["cash_dispensed3"];
                        if ((columns & Columns.cash_dispensed4) == Columns.cash_dispensed4 && reader["cash_dispensed4"] != DBNull.Value)
                            currentDispensed.cash_dispensed4 = (int)reader["cash_dispensed4"];
                        if ((columns & Columns.cash_dispensed5) == Columns.cash_dispensed5 && reader["cash_dispensed5"] != DBNull.Value)
                            currentDispensed.cash_dispensed5 = (int)reader["cash_dispensed5"];
                        if ((columns & Columns.cash_dispensed6) == Columns.cash_dispensed6 && reader["cash_dispensed6"] != DBNull.Value)
                            currentDispensed.cash_dispensed6 = (int)reader["cash_dispensed6"];
                        if ((columns & Columns.cash_dispensed7) == Columns.cash_dispensed7 && reader["cash_dispensed7"] != DBNull.Value)
                            currentDispensed.cash_dispensed7 = (int)reader["cash_dispensed7"];
                        if ((columns & Columns.cash_purged1) == Columns.cash_purged1 && reader["cash_purged1"] != DBNull.Value)
                            currentDispensed.cash_purged1 = (int)reader["cash_purged1"];
                        if ((columns & Columns.cash_purged2) == Columns.cash_purged2 && reader["cash_purged2"] != DBNull.Value)
                            currentDispensed.cash_purged2 = (int)reader["cash_purged2"];
                        if ((columns & Columns.cash_purged3) == Columns.cash_purged3 && reader["cash_purged3"] != DBNull.Value)
                            currentDispensed.cash_purged3 = (int)reader["cash_purged3"];
                        if ((columns & Columns.cash_purged4) == Columns.cash_purged4 && reader["cash_purged4"] != DBNull.Value)
                            currentDispensed.cash_purged4 = (int)reader["cash_purged4"];
                        if ((columns & Columns.cash_purged5) == Columns.cash_purged5 && reader["cash_purged5"] != DBNull.Value)
                            currentDispensed.cash_purged5 = (int)reader["cash_purged5"];
                        if ((columns & Columns.cash_purged6) == Columns.cash_purged6 && reader["cash_purged6"] != DBNull.Value)
                            currentDispensed.cash_purged6 = (int)reader["cash_purged6"];
                        if ((columns & Columns.cash_purged7) == Columns.cash_purged7 && reader["cash_purged7"] != DBNull.Value)
                            currentDispensed.cash_purged7 = (int)reader["cash_purged7"];
                        if ((columns & Columns.clearing_datetime) == Columns.clearing_datetime && reader["clearing_datetime"] != DBNull.Value)
                            currentDispensed.clearing_datetime = (DateTime)reader["clearing_datetime"];
                        if ((columns & Columns.dispensed_id) == Columns.dispensed_id && reader["dispensed_id"] != DBNull.Value)
                            currentDispensed.dispensed_id = (long)reader["dispensed_id"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentDispensed.task_id = (long)reader["task_id"];

                    }
                    else
                    {
                        if (reader["atm_id"] != DBNull.Value)
                            currentDispensed.atm_id = (long)reader["atm_id"];
                        if (reader["cash_remaining1"] != DBNull.Value)
                            currentDispensed.cash_remaining1 = (int)reader["cash_remaining1"];
                        if (reader["cash_remaining2"] != DBNull.Value)
                            currentDispensed.cash_remaining2 = (int)reader["cash_remaining2"];
                        if (reader["cash_remaining3"] != DBNull.Value)
                            currentDispensed.cash_remaining3 = (int)reader["cash_remaining3"];
                        if (reader["cash_remaining4"] != DBNull.Value)
                            currentDispensed.cash_remaining4 = (int)reader["cash_remaining4"];
                        if (reader["cash_remaining5"] != DBNull.Value)
                            currentDispensed.cash_remaining5 = (int)reader["cash_remaining5"];
                        if (reader["cash_remaining6"] != DBNull.Value)
                            currentDispensed.cash_remaining6 = (int)reader["cash_remaining6"];
                        if (reader["cash_remaining7"] != DBNull.Value)
                            currentDispensed.cash_remaining7 = (int)reader["cash_remaining7"];
                        if (reader["cash_dispensed1"] != DBNull.Value)
                            currentDispensed.cash_dispensed1 = (int)reader["cash_dispensed1"];
                        if (reader["cash_dispensed2"] != DBNull.Value)
                            currentDispensed.cash_dispensed2 = (int)reader["cash_dispensed2"];
                        if (reader["cash_dispensed3"] != DBNull.Value)
                            currentDispensed.cash_dispensed3 = (int)reader["cash_dispensed3"];
                        if (reader["cash_dispensed4"] != DBNull.Value)
                            currentDispensed.cash_dispensed4 = (int)reader["cash_dispensed4"];
                        if (reader["cash_dispensed5"] != DBNull.Value)
                            currentDispensed.cash_dispensed5 = (int)reader["cash_dispensed5"];
                        if (reader["cash_dispensed6"] != DBNull.Value)
                            currentDispensed.cash_dispensed6 = (int)reader["cash_dispensed6"];
                        if (reader["cash_dispensed7"] != DBNull.Value)
                            currentDispensed.cash_dispensed7 = (int)reader["cash_dispensed7"];
                        if (reader["cash_purged1"] != DBNull.Value)
                            currentDispensed.cash_purged1 = (int)reader["cash_purged1"];
                        if (reader["cash_purged2"] != DBNull.Value)
                            currentDispensed.cash_purged2 = (int)reader["cash_purged2"];
                        if (reader["cash_purged3"] != DBNull.Value)
                            currentDispensed.cash_purged3 = (int)reader["cash_purged3"];
                        if (reader["cash_purged4"] != DBNull.Value)
                            currentDispensed.cash_purged4 = (int)reader["cash_purged4"];
                        if (reader["cash_purged5"] != DBNull.Value)
                            currentDispensed.cash_purged5 = (int)reader["cash_purged5"];
                        if (reader["cash_purged6"] != DBNull.Value)
                            currentDispensed.cash_purged6 = (int)reader["cash_purged6"];
                        if (reader["cash_purged7"] != DBNull.Value)
                            currentDispensed.cash_purged7 = (int)reader["cash_purged7"];
                        if (reader["clearing_datetime"] != DBNull.Value)
                            currentDispensed.clearing_datetime = (DateTime)reader["clearing_datetime"];
                        if (reader["dispensed_id"] != DBNull.Value)
                            currentDispensed.dispensed_id = (long)reader["dispensed_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentDispensed.task_id = (long)reader["task_id"];
                    }

                    currentDispensed.isNewEntity = false;
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

            public Dispensed CurrentDispensed
            {
                get { return currentDispensed; }
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


        #region Dispensed functions

        public static DispensedReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
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
            if (Columns.clearing_datetime == (Columns.clearing_datetime & columns))
                qry.Append("clearing_datetime,");
            if (Columns.dispensed_id == (Columns.dispensed_id & columns))
                qry.Append("dispensed_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Dispensed ");

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
            return new DispensedReader(cmd.ExecuteReader(), conn, columns);
        }

        static public DispensedReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static DispensedReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_id,cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,cash_remaining5,cash_remaining6,cash_remaining7,cash_dispensed1,cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,cash_purged1,cash_purged2,cash_purged3,cash_purged4,cash_purged5,cash_purged6,cash_purged7,clearing_datetime,dispensed_id,task_id from Dispensed ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new DispensedReader(cmd.ExecuteReader(), conn);
        }

        static public DispensedReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static Dispensed LoadDispensed(string where)
        {
            DispensedReader reader = Dispensed.ExecuteReader(where);
            Dispensed _dispensed = null;
            if (reader.Read())
                _dispensed = reader.CurrentDispensed;
            reader.Close();
            return _dispensed;
        }

        public static Dispensed LoadDispensed(string where, IDbConnection conn)
        {
            DispensedReader reader = Dispensed.ExecuteReader(where, conn);
            Dispensed _dispensed = null;
            if (reader.Read())
                _dispensed = reader.CurrentDispensed;
            reader.Close(false);
            return _dispensed;
        }

        public static Dispensed LoadDispensedByPk(DateTime clearing_datetime, long dispensed_id)
        {
            return LoadDispensed("clearing_datetime=Convert(datetime,'" + clearing_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)" + " and dispensed_id=" + dispensed_id);
        }

        public static Dispensed LoadDispensedByPk(DateTime clearing_datetime, long dispensed_id, IDbConnection conn)
        {
            return LoadDispensed(" clearing_datetime=Convert(datetime,'" + clearing_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)" + " and dispensed_id=" + dispensed_id, conn);
        }

        public void Save()
        {
            if (atm_idChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || cash_dispensed1Changed || cash_dispensed2Changed || cash_dispensed3Changed || cash_dispensed4Changed || cash_dispensed5Changed || cash_dispensed6Changed || cash_dispensed7Changed || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || clearing_datetimeChanged || dispensed_idChanged || task_idChanged)
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
            if (atm_idChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || cash_dispensed1Changed || cash_dispensed2Changed || cash_dispensed3Changed || cash_dispensed4Changed || cash_dispensed5Changed || cash_dispensed6Changed || cash_dispensed7Changed || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || clearing_datetimeChanged || dispensed_idChanged || task_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Dispensed(atm_id,cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,cash_remaining5,cash_remaining6,cash_remaining7,cash_dispensed1,cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,cash_purged1,cash_purged2,cash_purged3,cash_purged4,cash_purged5,cash_purged6,cash_purged7,clearing_datetime,dispensed_id,task_id) values(");
                    qry.Append(atm_idDbString + ",");
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
                    qry.Append(clearing_datetimeDbString + ",");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.dispensed_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.dispensed_id);
                    }
                    qry.Append(",");
                    qry.Append(task_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_idChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || cash_dispensed1Changed || cash_dispensed2Changed || cash_dispensed3Changed || cash_dispensed4Changed || cash_dispensed5Changed || cash_dispensed6Changed || cash_dispensed7Changed || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || clearing_datetimeChanged || dispensed_idChanged || task_idChanged))
                        return;
                    qry.Append("UPDATE Dispensed set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
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


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("clearing_datetime = " + clearing_datetimeDbString);
                    qry.Append(" and dispensed_id = " + dispensed_idDbString);
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
            cmd.CommandText = "DELETE Dispensed whereclearing_datetime= " + clearing_datetime + " and dispensed_id= " + dispensed_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteDispenseds(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Dispensed where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_id = 0,
            cash_remaining1 = 1,
            cash_remaining2 = 2,
            cash_remaining3 = 3,
            cash_remaining4 = 4,
            cash_remaining5 = 5,
            cash_remaining6 = 6,
            cash_remaining7 = 7,
            cash_dispensed1 = 8,
            cash_dispensed2 = 9,
            cash_dispensed3 = 10,
            cash_dispensed4 = 11,
            cash_dispensed5 = 12,
            cash_dispensed6 = 13,
            cash_dispensed7 = 14,
            cash_purged1 = 15,
            cash_purged2 = 16,
            cash_purged3 = 17,
            cash_purged4 = 18,
            cash_purged5 = 19,
            cash_purged6 = 20,
            cash_purged7 = 21,
            clearing_datetime = 22,
            dispensed_id = 23,
            task_id = 24
        }
        #endregion
        public DataTable BulkSave(List<Dispensed> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringCash);
            bulk.DestinationTableName = "Dispensed";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Dispensed.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Dispensed> transList, ref DataTable dt)
        {
            foreach (Dispensed tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_id"] = tran.AtmId;
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
                Row["clearing_datetime"] = tran.ClearingDatetime;
                Row["dispensed_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["task_id"] = tran.TaskId;
                dt.Rows.Add(Row);
            }
        }
    }
}

 
