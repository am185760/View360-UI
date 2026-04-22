using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServicesDAL
{
    [Serializable()]
    public class TestCashPurgedNotes
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public TestCashPurgedNotes() { }
        public TestCashPurgedNotes(long test_cash_purged_notes_id, DateTime test_cash_datetime, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, long task_id, long replenishment_id, long atm_id, bool is_auto_generated)
        {
            this.test_cash_datetime = test_cash_datetime;
            this.test_cash_datetimeChanged = true;
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
            this.replenishment_id = replenishment_id;
            this.replenishment_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.is_auto_generated = is_auto_generated;
            this.is_auto_generatedChanged = true;
        }
        public TestCashPurgedNotes(DateTime test_cash_datetime, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, long task_id, long replenishment_id, long atm_id, bool is_auto_generated, bool? is_bill_dispenser)
        {
            this.test_cash_datetime = test_cash_datetime;
            this.test_cash_datetimeChanged = true;
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
            this.replenishment_id = replenishment_id;
            this.replenishment_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.is_auto_generated = is_auto_generated;
            this.is_auto_generatedChanged = true;
            this.is_bill_dispenser = is_bill_dispenser;
            this.is_bill_dispenserChanged = true;
        }
        private TestCashPurgedNotes(long test_cash_purged_notes_id, DateTime test_cash_datetime, int cash_purged1, int cash_purged2, int cash_purged3, int cash_purged4, int cash_purged5, int cash_purged6, int cash_purged7, long task_id, long replenishment_id, long atm_id, bool is_auto_generated, bool? is_bill_dispenser)
        {
            this.test_cash_purged_notes_id = test_cash_purged_notes_id;
            this.test_cash_purged_notes_idChanged = true;
            this.test_cash_datetime = test_cash_datetime;
            this.test_cash_datetimeChanged = true;
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
            this.replenishment_id = replenishment_id;
            this.replenishment_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.is_auto_generated = is_auto_generated;
            this.is_auto_generatedChanged = true;
            this.is_bill_dispenser = is_bill_dispenser;
            this.is_bill_dispenserChanged = true;
        }

        #region members and properties for columns

        #region TestCashPurgedNotesId
        private bool test_cash_purged_notes_idChanged = false;
        private long test_cash_purged_notes_id;
        public long TestCashPurgedNotesId
        {
            get { return test_cash_purged_notes_id; }
            set
            {
                test_cash_purged_notes_id = value;
                test_cash_purged_notes_idChanged = true;
            }
        }
        private string test_cash_purged_notes_idDbString
        {
            get
            {
                return test_cash_purged_notes_id.ToString();
            }
        }
        #endregion
        #region TestCashDatetime
        private bool test_cash_datetimeChanged = false;
        private DateTime test_cash_datetime;
        public DateTime TestCashDatetime
        {
            get { return test_cash_datetime; }
            set
            {
                test_cash_datetime = value;
                test_cash_datetimeChanged = true;
            }
        }
        private string test_cash_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", test_cash_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #region ReplenishmentId
        private bool replenishment_idChanged = false;
        private long replenishment_id;
        public long ReplenishmentId
        {
            get { return replenishment_id; }
            set
            {
                replenishment_id = value;
                replenishment_idChanged = true;
            }
        }
        private string replenishment_idDbString
        {
            get
            {
                return replenishment_id.ToString();
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
        #region IsAutoGenerated
        private bool is_auto_generatedChanged = false;
        private bool is_auto_generated;
        public bool IsAutoGenerated
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
                return is_auto_generated ? "1" : "0";
            }
        }
        #endregion
        #region IsBillDispenser
        private bool is_bill_dispenserChanged = false;
        private bool? is_bill_dispenser;
        public bool? IsBillDispenser
        {
            get { return is_bill_dispenser; }
            set
            {
                is_bill_dispenser = value;
                is_bill_dispenserChanged = true;
            }
        }
        private string is_bill_dispenserDbString
        {
            get
            {
                if (this.is_bill_dispenser.HasValue)
                    return is_bill_dispenser.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region TestCashPurgedNotesReader
        public class TestCashPurgedNotesReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            TestCashPurgedNotes currentTestCashPurgedNotes;
            Columns columns;
            bool partialRead = false;
            private TestCashPurgedNotesReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public TestCashPurgedNotesReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public TestCashPurgedNotesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentTestCashPurgedNotes; }

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
                    currentTestCashPurgedNotes = new TestCashPurgedNotes();
                    if (partialRead)
                    {
                        if ((columns & Columns.test_cash_purged_notes_id) == Columns.test_cash_purged_notes_id && reader["test_cash_purged_notes_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.test_cash_purged_notes_id = (long)reader["test_cash_purged_notes_id"];
                        if ((columns & Columns.test_cash_datetime) == Columns.test_cash_datetime && reader["test_cash_datetime"] != DBNull.Value)
                            currentTestCashPurgedNotes.test_cash_datetime = (DateTime)reader["test_cash_datetime"];
                        if ((columns & Columns.cash_purged1) == Columns.cash_purged1 && reader["cash_purged1"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged1 = (int)reader["cash_purged1"];
                        if ((columns & Columns.cash_purged2) == Columns.cash_purged2 && reader["cash_purged2"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged2 = (int)reader["cash_purged2"];
                        if ((columns & Columns.cash_purged3) == Columns.cash_purged3 && reader["cash_purged3"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged3 = (int)reader["cash_purged3"];
                        if ((columns & Columns.cash_purged4) == Columns.cash_purged4 && reader["cash_purged4"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged4 = (int)reader["cash_purged4"];
                        if ((columns & Columns.cash_purged5) == Columns.cash_purged5 && reader["cash_purged5"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged5 = (int)reader["cash_purged5"];
                        if ((columns & Columns.cash_purged6) == Columns.cash_purged6 && reader["cash_purged6"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged6 = (int)reader["cash_purged6"];
                        if ((columns & Columns.cash_purged7) == Columns.cash_purged7 && reader["cash_purged7"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged7 = (int)reader["cash_purged7"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.task_id = (long)reader["task_id"];
                        if ((columns & Columns.replenishment_id) == Columns.replenishment_id && reader["replenishment_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.replenishment_id = (long)reader["replenishment_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.is_auto_generated) == Columns.is_auto_generated && reader["is_auto_generated"] != DBNull.Value)
                            currentTestCashPurgedNotes.is_auto_generated = (bool)reader["is_auto_generated"];
                        if ((columns & Columns.is_bill_dispenser) == Columns.is_bill_dispenser && reader["is_bill_dispenser"] != DBNull.Value)
                            currentTestCashPurgedNotes.is_bill_dispenser = (bool?)reader["is_bill_dispenser"];

                    }
                    else
                    {
                        if (reader["test_cash_purged_notes_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.test_cash_purged_notes_id = (long)reader["test_cash_purged_notes_id"];
                        if (reader["test_cash_datetime"] != DBNull.Value)
                            currentTestCashPurgedNotes.test_cash_datetime = (DateTime)reader["test_cash_datetime"];
                        if (reader["cash_purged1"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged1 = (int)reader["cash_purged1"];
                        if (reader["cash_purged2"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged2 = (int)reader["cash_purged2"];
                        if (reader["cash_purged3"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged3 = (int)reader["cash_purged3"];
                        if (reader["cash_purged4"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged4 = (int)reader["cash_purged4"];
                        if (reader["cash_purged5"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged5 = (int)reader["cash_purged5"];
                        if (reader["cash_purged6"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged6 = (int)reader["cash_purged6"];
                        if (reader["cash_purged7"] != DBNull.Value)
                            currentTestCashPurgedNotes.cash_purged7 = (int)reader["cash_purged7"];
                        if (reader["task_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.task_id = (long)reader["task_id"];
                        if (reader["replenishment_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.replenishment_id = (long)reader["replenishment_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentTestCashPurgedNotes.atm_id = (long)reader["atm_id"];
                        if (reader["is_auto_generated"] != DBNull.Value)
                            currentTestCashPurgedNotes.is_auto_generated = (bool)reader["is_auto_generated"];
                        if (reader["is_bill_dispenser"] != DBNull.Value)
                            currentTestCashPurgedNotes.is_bill_dispenser = (bool?)reader["is_bill_dispenser"];
                    }

                    currentTestCashPurgedNotes.isNewEntity = false;
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

            public TestCashPurgedNotes CurrentTestCashPurgedNotes
            {
                get { return currentTestCashPurgedNotes; }
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


        #region TestCashPurgedNotes functions

        public static TestCashPurgedNotesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.test_cash_purged_notes_id == (Columns.test_cash_purged_notes_id & columns))
                qry.Append("test_cash_purged_notes_id,");
            if (Columns.test_cash_datetime == (Columns.test_cash_datetime & columns))
                qry.Append("test_cash_datetime,");
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
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.replenishment_id == (Columns.replenishment_id & columns))
                qry.Append("replenishment_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.is_auto_generated == (Columns.is_auto_generated & columns))
                qry.Append("is_auto_generated,");
            if (Columns.is_bill_dispenser == (Columns.is_bill_dispenser & columns))
                qry.Append("is_bill_dispenser,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Test_cash_purged_notes ");

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
            return new TestCashPurgedNotesReader(cmd.ExecuteReader(), conn, columns);
        }

        static public TestCashPurgedNotesReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static TestCashPurgedNotesReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select test_cash_purged_notes_id,test_cash_datetime,cash_purged1,cash_purged2,cash_purged3,cash_purged4,cash_purged5,cash_purged6,cash_purged7,task_id,replenishment_id,atm_id,is_auto_generated,is_bill_dispenser from Test_cash_purged_notes ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new TestCashPurgedNotesReader(cmd.ExecuteReader(), conn);
        }

        static public TestCashPurgedNotesReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static TestCashPurgedNotes LoadTestCashPurgedNotes(string where)
        {
            TestCashPurgedNotesReader reader = TestCashPurgedNotes.ExecuteReader(where);
            TestCashPurgedNotes _testcashpurgednotes = null;
            if (reader.Read())
                _testcashpurgednotes = reader.CurrentTestCashPurgedNotes;
            reader.Close();
            return _testcashpurgednotes;
        }

        public static TestCashPurgedNotes LoadTestCashPurgedNotes(string where, IDbConnection conn)
        {
            TestCashPurgedNotesReader reader = TestCashPurgedNotes.ExecuteReader(where, conn);
            TestCashPurgedNotes _testcashpurgednotes = null;
            if (reader.Read())
                _testcashpurgednotes = reader.CurrentTestCashPurgedNotes;
            reader.Close(false);
            return _testcashpurgednotes;
        }

        public static TestCashPurgedNotes LoadTestCashPurgedNotesByPk(long test_cash_purged_notes_id, DateTime test_cash_datetime)
        {
            return LoadTestCashPurgedNotes("test_cash_purged_notes_id=" + test_cash_purged_notes_id + " and test_cash_datetime=Convert(datetime,'" + test_cash_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)");
        }

        public static TestCashPurgedNotes LoadTestCashPurgedNotesByPk(long test_cash_purged_notes_id, DateTime test_cash_datetime, IDbConnection conn)
        {
            return LoadTestCashPurgedNotes(" test_cash_purged_notes_id=" + test_cash_purged_notes_id + " and test_cash_datetime=Convert(datetime,'" + test_cash_datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)", conn);
        }

        public void Save()
        {
            if (test_cash_purged_notes_idChanged || test_cash_datetimeChanged || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || task_idChanged || replenishment_idChanged || atm_idChanged || is_auto_generatedChanged || is_bill_dispenserChanged)
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
            if (test_cash_purged_notes_idChanged || test_cash_datetimeChanged || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || task_idChanged || replenishment_idChanged || atm_idChanged || is_auto_generatedChanged || is_bill_dispenserChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Test_cash_purged_notes(test_cash_purged_notes_id,test_cash_datetime,cash_purged1,cash_purged2,cash_purged3,cash_purged4,cash_purged5,cash_purged6,cash_purged7,task_id,replenishment_id,atm_id,is_auto_generated,is_bill_dispenser) values(");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.test_cash_purged_notes_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.test_cash_purged_notes_id);
                    }
                    qry.Append(",");
                    qry.Append(test_cash_datetimeDbString + ",");
                    qry.Append(cash_purged1DbString + ",");
                    qry.Append(cash_purged2DbString + ",");
                    qry.Append(cash_purged3DbString + ",");
                    qry.Append(cash_purged4DbString + ",");
                    qry.Append(cash_purged5DbString + ",");
                    qry.Append(cash_purged6DbString + ",");
                    qry.Append(cash_purged7DbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(replenishment_idDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(is_auto_generatedDbString + ",");
                    qry.Append(is_bill_dispenserDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(test_cash_purged_notes_idChanged || test_cash_datetimeChanged || cash_purged1Changed || cash_purged2Changed || cash_purged3Changed || cash_purged4Changed || cash_purged5Changed || cash_purged6Changed || cash_purged7Changed || task_idChanged || replenishment_idChanged || atm_idChanged || is_auto_generatedChanged || is_bill_dispenserChanged))
                        return;
                    qry.Append("UPDATE Test_cash_purged_notes set "); if (cash_purged1Changed)
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

                    if (replenishment_idChanged)
                    {
                        qry.Append("replenishment_id =" + replenishment_idDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (is_auto_generatedChanged)
                    {
                        qry.Append("is_auto_generated =" + is_auto_generatedDbString);
                        qry.Append(",");
                    }

                    if (is_bill_dispenserChanged)
                    {
                        qry.Append("is_bill_dispenser =" + is_bill_dispenserDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("test_cash_purged_notes_id = " + test_cash_purged_notes_idDbString);
                    qry.Append(" and test_cash_datetime = " + test_cash_datetimeDbString);
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
            cmd.CommandText = "DELETE Test_cash_purged_notes wheretest_cash_purged_notes_id= " + test_cash_purged_notes_id + " and test_cash_datetime= " + test_cash_datetime;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteTestCashPurgedNotess(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Test_cash_purged_notes where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            test_cash_purged_notes_id = 0,
            test_cash_datetime = 1,
            cash_purged1 = 2,
            cash_purged2 = 3,
            cash_purged3 = 4,
            cash_purged4 = 5,
            cash_purged5 = 6,
            cash_purged6 = 7,
            cash_purged7 = 8,
            task_id = 9,
            replenishment_id = 10,
            atm_id = 11,
            is_auto_generated = 12,
            is_bill_dispenser = 13
        }
        #endregion
        public DataTable BulkSave(List<TestCashPurgedNotes> dataArray)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringCash, SqlBulkCopyOptions.Default);
            bulk.DestinationTableName = "Test_cash_purged_notes";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(TestCashPurgedNotes.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<TestCashPurgedNotes> transList, ref DataTable dt)
        {
            foreach (TestCashPurgedNotes tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["test_cash_purged_notes_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["test_cash_datetime"] = tran.TestCashDatetime;
                Row["cash_purged1"] = tran.CashPurged1;
                Row["cash_purged2"] = tran.CashPurged2;
                Row["cash_purged3"] = tran.CashPurged3;
                Row["cash_purged4"] = tran.CashPurged4;
                Row["cash_purged5"] = tran.CashPurged5;
                Row["cash_purged6"] = tran.CashPurged6;
                Row["cash_purged7"] = tran.CashPurged7;
                Row["task_id"] = tran.TaskId;
                Row["replenishment_id"] = tran.ReplenishmentId;
                Row["atm_id"] = tran.AtmId;
                Row["is_auto_generated"] = tran.IsAutoGenerated;
                Row["is_bill_dispenser"] = tran.IsBillDispenser;
                dt.Rows.Add(Row);
            }
        }
    }
}
