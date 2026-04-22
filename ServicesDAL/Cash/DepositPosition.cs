
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
    public class DepositPosition
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public DepositPosition() { }
        public DepositPosition(long atm_id, long deposit_position_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }
        public DepositPosition(long atm_id, int? cassette1_deposit, int? cassette2_deposit, int? cassette3_deposit, int? cassette4_deposit, int? purge_deposit, int? bin1, int? bin2, int? bin3, int? bin4, DateTime? last_cpm_deposit_at, DateTime? last_bna_deposit_at, string cassette1_deposit_value, string cassette2_deposit_value, string cassette3_deposit_value, string cassette4_deposit_value, string purge_deposit_value)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.cassette1_deposit = cassette1_deposit;
            this.cassette1_depositChanged = true;
            this.cassette2_deposit = cassette2_deposit;
            this.cassette2_depositChanged = true;
            this.cassette3_deposit = cassette3_deposit;
            this.cassette3_depositChanged = true;
            this.cassette4_deposit = cassette4_deposit;
            this.cassette4_depositChanged = true;
            this.purge_deposit = purge_deposit;
            this.purge_depositChanged = true;
            this.bin1 = bin1;
            this.bin1Changed = true;
            this.bin2 = bin2;
            this.bin2Changed = true;
            this.bin3 = bin3;
            this.bin3Changed = true;
            this.bin4 = bin4;
            this.bin4Changed = true;
            this.last_cpm_deposit_at = last_cpm_deposit_at;
            this.last_cpm_deposit_atChanged = true;
            this.last_bna_deposit_at = last_bna_deposit_at;
            this.last_bna_deposit_atChanged = true;
            this.cassette1_deposit_value = cassette1_deposit_value;
            this.cassette1_deposit_valueChanged = true;
            this.cassette2_deposit_value = cassette2_deposit_value;
            this.cassette2_deposit_valueChanged = true;
            this.cassette3_deposit_value = cassette3_deposit_value;
            this.cassette3_deposit_valueChanged = true;
            this.cassette4_deposit_value = cassette4_deposit_value;
            this.cassette4_deposit_valueChanged = true;
            this.purge_deposit_value = purge_deposit_value;
            this.purge_deposit_valueChanged = true;
        }
        private DepositPosition(long atm_id, long deposit_position_id, int? cassette1_deposit, int? cassette2_deposit, int? cassette3_deposit, int? cassette4_deposit, int? purge_deposit, int? bin1, int? bin2, int? bin3, int? bin4, DateTime? last_cpm_deposit_at, DateTime? last_bna_deposit_at, string cassette1_deposit_value, string cassette2_deposit_value, string cassette3_deposit_value, string cassette4_deposit_value, string purge_deposit_value)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.deposit_position_id = deposit_position_id;
            this.deposit_position_idChanged = true;
            this.cassette1_deposit = cassette1_deposit;
            this.cassette1_depositChanged = true;
            this.cassette2_deposit = cassette2_deposit;
            this.cassette2_depositChanged = true;
            this.cassette3_deposit = cassette3_deposit;
            this.cassette3_depositChanged = true;
            this.cassette4_deposit = cassette4_deposit;
            this.cassette4_depositChanged = true;
            this.purge_deposit = purge_deposit;
            this.purge_depositChanged = true;
            this.bin1 = bin1;
            this.bin1Changed = true;
            this.bin2 = bin2;
            this.bin2Changed = true;
            this.bin3 = bin3;
            this.bin3Changed = true;
            this.bin4 = bin4;
            this.bin4Changed = true;
            this.last_cpm_deposit_at = last_cpm_deposit_at;
            this.last_cpm_deposit_atChanged = true;
            this.last_bna_deposit_at = last_bna_deposit_at;
            this.last_bna_deposit_atChanged = true;
            this.cassette1_deposit_value = cassette1_deposit_value;
            this.cassette1_deposit_valueChanged = true;
            this.cassette2_deposit_value = cassette2_deposit_value;
            this.cassette2_deposit_valueChanged = true;
            this.cassette3_deposit_value = cassette3_deposit_value;
            this.cassette3_deposit_valueChanged = true;
            this.cassette4_deposit_value = cassette4_deposit_value;
            this.cassette4_deposit_valueChanged = true;
            this.purge_deposit_value = purge_deposit_value;
            this.purge_deposit_valueChanged = true;
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
        #region DepositPositionId
        private bool deposit_position_idChanged = false;
        private long deposit_position_id;
        public long DepositPositionId
        {
            get { return deposit_position_id; }
            set
            {
                deposit_position_id = value;
                deposit_position_idChanged = true;
            }
        }
        private string deposit_position_idDbString
        {
            get
            {
                return deposit_position_id.ToString();
            }
        }
        #endregion
        #region Cassette1Deposit
        private bool cassette1_depositChanged = false;
        private int? cassette1_deposit;
        public int? Cassette1Deposit
        {
            get { return cassette1_deposit; }
            set
            {
                cassette1_deposit = value;
                cassette1_depositChanged = true;
            }
        }
        private string cassette1_depositDbString
        {
            get
            {
                if (this.cassette1_deposit.HasValue)
                    return cassette1_deposit.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Deposit
        private bool cassette2_depositChanged = false;
        private int? cassette2_deposit;
        public int? Cassette2Deposit
        {
            get { return cassette2_deposit; }
            set
            {
                cassette2_deposit = value;
                cassette2_depositChanged = true;
            }
        }
        private string cassette2_depositDbString
        {
            get
            {
                if (this.cassette2_deposit.HasValue)
                    return cassette2_deposit.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Deposit
        private bool cassette3_depositChanged = false;
        private int? cassette3_deposit;
        public int? Cassette3Deposit
        {
            get { return cassette3_deposit; }
            set
            {
                cassette3_deposit = value;
                cassette3_depositChanged = true;
            }
        }
        private string cassette3_depositDbString
        {
            get
            {
                if (this.cassette3_deposit.HasValue)
                    return cassette3_deposit.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Deposit
        private bool cassette4_depositChanged = false;
        private int? cassette4_deposit;
        public int? Cassette4Deposit
        {
            get { return cassette4_deposit; }
            set
            {
                cassette4_deposit = value;
                cassette4_depositChanged = true;
            }
        }
        private string cassette4_depositDbString
        {
            get
            {
                if (this.cassette4_deposit.HasValue)
                    return cassette4_deposit.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeDeposit
        private bool purge_depositChanged = false;
        private int? purge_deposit;
        public int? PurgeDeposit
        {
            get { return purge_deposit; }
            set
            {
                purge_deposit = value;
                purge_depositChanged = true;
            }
        }
        private string purge_depositDbString
        {
            get
            {
                if (this.purge_deposit.HasValue)
                    return purge_deposit.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Bin1
        private bool bin1Changed = false;
        private int? bin1;
        public int? Bin1
        {
            get { return bin1; }
            set
            {
                bin1 = value;
                bin1Changed = true;
            }
        }
        private string bin1DbString
        {
            get
            {
                if (this.bin1.HasValue)
                    return bin1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Bin2
        private bool bin2Changed = false;
        private int? bin2;
        public int? Bin2
        {
            get { return bin2; }
            set
            {
                bin2 = value;
                bin2Changed = true;
            }
        }
        private string bin2DbString
        {
            get
            {
                if (this.bin2.HasValue)
                    return bin2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Bin3
        private bool bin3Changed = false;
        private int? bin3;
        public int? Bin3
        {
            get { return bin3; }
            set
            {
                bin3 = value;
                bin3Changed = true;
            }
        }
        private string bin3DbString
        {
            get
            {
                if (this.bin3.HasValue)
                    return bin3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Bin4
        private bool bin4Changed = false;
        private int? bin4;
        public int? Bin4
        {
            get { return bin4; }
            set
            {
                bin4 = value;
                bin4Changed = true;
            }
        }
        private string bin4DbString
        {
            get
            {
                if (this.bin4.HasValue)
                    return bin4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region LastCpmDepositAt
        private bool last_cpm_deposit_atChanged = false;
        private DateTime? last_cpm_deposit_at;
        public DateTime? LastCpmDepositAt
        {
            get { return last_cpm_deposit_at; }
            set
            {
                last_cpm_deposit_at = value;
                last_cpm_deposit_atChanged = true;
            }
        }
        private string last_cpm_deposit_atDbString
        {
            get
            {
                if (this.last_cpm_deposit_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_cpm_deposit_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region LastBnaDepositAt
        private bool last_bna_deposit_atChanged = false;
        private DateTime? last_bna_deposit_at;
        public DateTime? LastBnaDepositAt
        {
            get { return last_bna_deposit_at; }
            set
            {
                last_bna_deposit_at = value;
                last_bna_deposit_atChanged = true;
            }
        }
        private string last_bna_deposit_atDbString
        {
            get
            {
                if (this.last_bna_deposit_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_bna_deposit_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1DepositValue
        private bool cassette1_deposit_valueChanged = false;
        private string cassette1_deposit_value;
        public string Cassette1DepositValue
        {
            get { return cassette1_deposit_value; }
            set
            {
                cassette1_deposit_value = value;
                cassette1_deposit_valueChanged = true;
            }
        }
        private string cassette1_deposit_valueDbString
        {
            get
            {
                if (this.cassette1_deposit_value != null)
                    return string.Format("'{0}'", cassette1_deposit_value);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2DepositValue
        private bool cassette2_deposit_valueChanged = false;
        private string cassette2_deposit_value;
        public string Cassette2DepositValue
        {
            get { return cassette2_deposit_value; }
            set
            {
                cassette2_deposit_value = value;
                cassette2_deposit_valueChanged = true;
            }
        }
        private string cassette2_deposit_valueDbString
        {
            get
            {
                if (this.cassette2_deposit_value != null)
                    return string.Format("'{0}'", cassette2_deposit_value);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3DepositValue
        private bool cassette3_deposit_valueChanged = false;
        private string cassette3_deposit_value;
        public string Cassette3DepositValue
        {
            get { return cassette3_deposit_value; }
            set
            {
                cassette3_deposit_value = value;
                cassette3_deposit_valueChanged = true;
            }
        }
        private string cassette3_deposit_valueDbString
        {
            get
            {
                if (this.cassette3_deposit_value != null)
                    return string.Format("'{0}'", cassette3_deposit_value);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4DepositValue
        private bool cassette4_deposit_valueChanged = false;
        private string cassette4_deposit_value;
        public string Cassette4DepositValue
        {
            get { return cassette4_deposit_value; }
            set
            {
                cassette4_deposit_value = value;
                cassette4_deposit_valueChanged = true;
            }
        }
        private string cassette4_deposit_valueDbString
        {
            get
            {
                if (this.cassette4_deposit_value != null)
                    return string.Format("'{0}'", cassette4_deposit_value);
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeDepositValue
        private bool purge_deposit_valueChanged = false;
        private string purge_deposit_value;
        public string PurgeDepositValue
        {
            get { return purge_deposit_value; }
            set
            {
                purge_deposit_value = value;
                purge_deposit_valueChanged = true;
            }
        }
        private string purge_deposit_valueDbString
        {
            get
            {
                if (this.purge_deposit_value != null)
                    return string.Format("'{0}'", purge_deposit_value);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region DepositPositionReader
        public class DepositPositionReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            DepositPosition currentDepositPosition;
            Columns columns;
            bool partialRead = false;
            private DepositPositionReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public DepositPositionReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public DepositPositionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentDepositPosition; }

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
                    currentDepositPosition = new DepositPosition();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentDepositPosition.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.deposit_position_id) == Columns.deposit_position_id && reader["deposit_position_id"] != DBNull.Value)
                            currentDepositPosition.deposit_position_id = (long)reader["deposit_position_id"];
                        if ((columns & Columns.cassette1_deposit) == Columns.cassette1_deposit && reader["cassette1_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette1_deposit = (int?)reader["cassette1_deposit"];
                        if ((columns & Columns.cassette2_deposit) == Columns.cassette2_deposit && reader["cassette2_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette2_deposit = (int?)reader["cassette2_deposit"];
                        if ((columns & Columns.cassette3_deposit) == Columns.cassette3_deposit && reader["cassette3_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette3_deposit = (int?)reader["cassette3_deposit"];
                        if ((columns & Columns.cassette4_deposit) == Columns.cassette4_deposit && reader["cassette4_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette4_deposit = (int?)reader["cassette4_deposit"];
                        if ((columns & Columns.purge_deposit) == Columns.purge_deposit && reader["purge_deposit"] != DBNull.Value)
                            currentDepositPosition.purge_deposit = (int?)reader["purge_deposit"];
                        if ((columns & Columns.bin1) == Columns.bin1 && reader["bin1"] != DBNull.Value)
                            currentDepositPosition.bin1 = (int?)reader["bin1"];
                        if ((columns & Columns.bin2) == Columns.bin2 && reader["bin2"] != DBNull.Value)
                            currentDepositPosition.bin2 = (int?)reader["bin2"];
                        if ((columns & Columns.bin3) == Columns.bin3 && reader["bin3"] != DBNull.Value)
                            currentDepositPosition.bin3 = (int?)reader["bin3"];
                        if ((columns & Columns.bin4) == Columns.bin4 && reader["bin4"] != DBNull.Value)
                            currentDepositPosition.bin4 = (int?)reader["bin4"];
                        if ((columns & Columns.last_cpm_deposit_at) == Columns.last_cpm_deposit_at && reader["last_cpm_deposit_at"] != DBNull.Value)
                            currentDepositPosition.last_cpm_deposit_at = (DateTime?)reader["last_cpm_deposit_at"];
                        if ((columns & Columns.last_bna_deposit_at) == Columns.last_bna_deposit_at && reader["last_bna_deposit_at"] != DBNull.Value)
                            currentDepositPosition.last_bna_deposit_at = (DateTime?)reader["last_bna_deposit_at"];
                        if ((columns & Columns.cassette1_deposit_value) == Columns.cassette1_deposit_value && reader["cassette1_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette1_deposit_value = (string)reader["cassette1_deposit_value"];
                        if ((columns & Columns.cassette2_deposit_value) == Columns.cassette2_deposit_value && reader["cassette2_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette2_deposit_value = (string)reader["cassette2_deposit_value"];
                        if ((columns & Columns.cassette3_deposit_value) == Columns.cassette3_deposit_value && reader["cassette3_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette3_deposit_value = (string)reader["cassette3_deposit_value"];
                        if ((columns & Columns.cassette4_deposit_value) == Columns.cassette4_deposit_value && reader["cassette4_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette4_deposit_value = (string)reader["cassette4_deposit_value"];
                        if ((columns & Columns.purge_deposit_value) == Columns.purge_deposit_value && reader["purge_deposit_value"] != DBNull.Value)
                            currentDepositPosition.purge_deposit_value = (string)reader["purge_deposit_value"];

                    }
                    else
                    {
                        if (reader["atm_id"] != DBNull.Value)
                            currentDepositPosition.atm_id = (long)reader["atm_id"];
                        if (reader["deposit_position_id"] != DBNull.Value)
                            currentDepositPosition.deposit_position_id = (long)reader["deposit_position_id"];
                        if (reader["cassette1_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette1_deposit = (int?)reader["cassette1_deposit"];
                        if (reader["cassette2_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette2_deposit = (int?)reader["cassette2_deposit"];
                        if (reader["cassette3_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette3_deposit = (int?)reader["cassette3_deposit"];
                        if (reader["cassette4_deposit"] != DBNull.Value)
                            currentDepositPosition.cassette4_deposit = (int?)reader["cassette4_deposit"];
                        if (reader["purge_deposit"] != DBNull.Value)
                            currentDepositPosition.purge_deposit = (int?)reader["purge_deposit"];
                        if (reader["bin1"] != DBNull.Value)
                            currentDepositPosition.bin1 = (int?)reader["bin1"];
                        if (reader["bin2"] != DBNull.Value)
                            currentDepositPosition.bin2 = (int?)reader["bin2"];
                        if (reader["bin3"] != DBNull.Value)
                            currentDepositPosition.bin3 = (int?)reader["bin3"];
                        if (reader["bin4"] != DBNull.Value)
                            currentDepositPosition.bin4 = (int?)reader["bin4"];
                        if (reader["last_cpm_deposit_at"] != DBNull.Value)
                            currentDepositPosition.last_cpm_deposit_at = (DateTime?)reader["last_cpm_deposit_at"];
                        if (reader["last_bna_deposit_at"] != DBNull.Value)
                            currentDepositPosition.last_bna_deposit_at = (DateTime?)reader["last_bna_deposit_at"];
                        if (reader["cassette1_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette1_deposit_value = (string)reader["cassette1_deposit_value"];
                        if (reader["cassette2_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette2_deposit_value = (string)reader["cassette2_deposit_value"];
                        if (reader["cassette3_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette3_deposit_value = (string)reader["cassette3_deposit_value"];
                        if (reader["cassette4_deposit_value"] != DBNull.Value)
                            currentDepositPosition.cassette4_deposit_value = (string)reader["cassette4_deposit_value"];
                        if (reader["purge_deposit_value"] != DBNull.Value)
                            currentDepositPosition.purge_deposit_value = (string)reader["purge_deposit_value"];
                    }

                    currentDepositPosition.isNewEntity = false;
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

            public DepositPosition CurrentDepositPosition
            {
                get { return currentDepositPosition; }
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


        #region DepositPosition functions

        public static DepositPositionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.deposit_position_id == (Columns.deposit_position_id & columns))
                qry.Append("deposit_position_id,");
            if (Columns.cassette1_deposit == (Columns.cassette1_deposit & columns))
                qry.Append("cassette1_deposit,");
            if (Columns.cassette2_deposit == (Columns.cassette2_deposit & columns))
                qry.Append("cassette2_deposit,");
            if (Columns.cassette3_deposit == (Columns.cassette3_deposit & columns))
                qry.Append("cassette3_deposit,");
            if (Columns.cassette4_deposit == (Columns.cassette4_deposit & columns))
                qry.Append("cassette4_deposit,");
            if (Columns.purge_deposit == (Columns.purge_deposit & columns))
                qry.Append("purge_deposit,");
            if (Columns.bin1 == (Columns.bin1 & columns))
                qry.Append("bin1,");
            if (Columns.bin2 == (Columns.bin2 & columns))
                qry.Append("bin2,");
            if (Columns.bin3 == (Columns.bin3 & columns))
                qry.Append("bin3,");
            if (Columns.bin4 == (Columns.bin4 & columns))
                qry.Append("bin4,");
            if (Columns.last_cpm_deposit_at == (Columns.last_cpm_deposit_at & columns))
                qry.Append("last_cpm_deposit_at,");
            if (Columns.last_bna_deposit_at == (Columns.last_bna_deposit_at & columns))
                qry.Append("last_bna_deposit_at,");
            if (Columns.cassette1_deposit_value == (Columns.cassette1_deposit_value & columns))
                qry.Append("cassette1_deposit_value,");
            if (Columns.cassette2_deposit_value == (Columns.cassette2_deposit_value & columns))
                qry.Append("cassette2_deposit_value,");
            if (Columns.cassette3_deposit_value == (Columns.cassette3_deposit_value & columns))
                qry.Append("cassette3_deposit_value,");
            if (Columns.cassette4_deposit_value == (Columns.cassette4_deposit_value & columns))
                qry.Append("cassette4_deposit_value,");
            if (Columns.purge_deposit_value == (Columns.purge_deposit_value & columns))
                qry.Append("purge_deposit_value,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Deposit_position ");

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
            return new DepositPositionReader(cmd.ExecuteReader(), conn, columns);
        }

        static public DepositPositionReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static DepositPositionReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_id,deposit_position_id,cassette1_deposit,cassette2_deposit,cassette3_deposit,cassette4_deposit,purge_deposit,bin1,bin2,bin3,bin4,last_cpm_deposit_at,last_bna_deposit_at,cassette1_deposit_value,cassette2_deposit_value,cassette3_deposit_value,cassette4_deposit_value,purge_deposit_value from Deposit_position ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new DepositPositionReader(cmd.ExecuteReader(), conn);
        }

        static public DepositPositionReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static DepositPosition LoadDepositPosition(string where)
        {
            DepositPositionReader reader = DepositPosition.ExecuteReader(where);
            DepositPosition _depositposition = null;
            if (reader.Read())
                _depositposition = reader.CurrentDepositPosition;
            reader.Close();
            return _depositposition;
        }

        public static DepositPosition LoadDepositPosition(string where, IDbConnection conn)
        {
            DepositPositionReader reader = DepositPosition.ExecuteReader(where, conn);
            DepositPosition _depositposition = null;
            if (reader.Read())
                _depositposition = reader.CurrentDepositPosition;
            reader.Close(false);
            return _depositposition;
        }

        public static DepositPosition LoadDepositPositionByPk(long deposit_position_id)
        {
            return LoadDepositPosition("deposit_position_id=" + deposit_position_id);
        }

        public static DepositPosition LoadDepositPositionByPk(long deposit_position_id, IDbConnection conn)
        {
            return LoadDepositPosition(" deposit_position_id=" + deposit_position_id, conn);
        }

        public void Save()
        {
            if (atm_idChanged || deposit_position_idChanged || cassette1_depositChanged || cassette2_depositChanged || cassette3_depositChanged || cassette4_depositChanged || purge_depositChanged || bin1Changed || bin2Changed || bin3Changed || bin4Changed || last_cpm_deposit_atChanged || last_bna_deposit_atChanged || cassette1_deposit_valueChanged || cassette2_deposit_valueChanged || cassette3_deposit_valueChanged || cassette4_deposit_valueChanged || purge_deposit_valueChanged)
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
            if (atm_idChanged || deposit_position_idChanged || cassette1_depositChanged || cassette2_depositChanged || cassette3_depositChanged || cassette4_depositChanged || purge_depositChanged || bin1Changed || bin2Changed || bin3Changed || bin4Changed || last_cpm_deposit_atChanged || last_bna_deposit_atChanged || cassette1_deposit_valueChanged || cassette2_deposit_valueChanged || cassette3_deposit_valueChanged || cassette4_deposit_valueChanged || purge_deposit_valueChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Deposit_position(atm_id,deposit_position_id,cassette1_deposit,cassette2_deposit,cassette3_deposit,cassette4_deposit,purge_deposit,bin1,bin2,bin3,bin4,last_cpm_deposit_at,last_bna_deposit_at,cassette1_deposit_value,cassette2_deposit_value,cassette3_deposit_value,cassette4_deposit_value,purge_deposit_value) values(");
                    qry.Append(atm_idDbString + ",");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.deposit_position_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.deposit_position_id);
                    }
                    qry.Append(",");
                    qry.Append(cassette1_depositDbString + ",");
                    qry.Append(cassette2_depositDbString + ",");
                    qry.Append(cassette3_depositDbString + ",");
                    qry.Append(cassette4_depositDbString + ",");
                    qry.Append(purge_depositDbString + ",");
                    qry.Append(bin1DbString + ",");
                    qry.Append(bin2DbString + ",");
                    qry.Append(bin3DbString + ",");
                    qry.Append(bin4DbString + ",");
                    qry.Append(last_cpm_deposit_atDbString + ",");
                    qry.Append(last_bna_deposit_atDbString + ",");
                    qry.Append(cassette1_deposit_valueDbString + ",");
                    qry.Append(cassette2_deposit_valueDbString + ",");
                    qry.Append(cassette3_deposit_valueDbString + ",");
                    qry.Append(cassette4_deposit_valueDbString + ",");
                    qry.Append(purge_deposit_valueDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_idChanged || deposit_position_idChanged || cassette1_depositChanged || cassette2_depositChanged || cassette3_depositChanged || cassette4_depositChanged || purge_depositChanged || bin1Changed || bin2Changed || bin3Changed || bin4Changed || last_cpm_deposit_atChanged || last_bna_deposit_atChanged || cassette1_deposit_valueChanged || cassette2_deposit_valueChanged || cassette3_deposit_valueChanged || cassette4_deposit_valueChanged || purge_deposit_valueChanged))
                        return;
                    qry.Append("UPDATE Deposit_position set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (cassette1_depositChanged)
                    {
                        qry.Append("cassette1_deposit =" + cassette1_depositDbString);
                        qry.Append(",");
                    }

                    if (cassette2_depositChanged)
                    {
                        qry.Append("cassette2_deposit =" + cassette2_depositDbString);
                        qry.Append(",");
                    }

                    if (cassette3_depositChanged)
                    {
                        qry.Append("cassette3_deposit =" + cassette3_depositDbString);
                        qry.Append(",");
                    }

                    if (cassette4_depositChanged)
                    {
                        qry.Append("cassette4_deposit =" + cassette4_depositDbString);
                        qry.Append(",");
                    }

                    if (purge_depositChanged)
                    {
                        qry.Append("purge_deposit =" + purge_depositDbString);
                        qry.Append(",");
                    }

                    if (bin1Changed)
                    {
                        qry.Append("bin1 =" + bin1DbString);
                        qry.Append(",");
                    }

                    if (bin2Changed)
                    {
                        qry.Append("bin2 =" + bin2DbString);
                        qry.Append(",");
                    }

                    if (bin3Changed)
                    {
                        qry.Append("bin3 =" + bin3DbString);
                        qry.Append(",");
                    }

                    if (bin4Changed)
                    {
                        qry.Append("bin4 =" + bin4DbString);
                        qry.Append(",");
                    }

                    if (last_cpm_deposit_atChanged)
                    {
                        qry.Append("last_cpm_deposit_at =" + last_cpm_deposit_atDbString);
                        qry.Append(",");
                    }

                    if (last_bna_deposit_atChanged)
                    {
                        qry.Append("last_bna_deposit_at =" + last_bna_deposit_atDbString);
                        qry.Append(",");
                    }

                    if (cassette1_deposit_valueChanged)
                    {
                        qry.Append("cassette1_deposit_value =" + cassette1_deposit_valueDbString);
                        qry.Append(",");
                    }

                    if (cassette2_deposit_valueChanged)
                    {
                        qry.Append("cassette2_deposit_value =" + cassette2_deposit_valueDbString);
                        qry.Append(",");
                    }

                    if (cassette3_deposit_valueChanged)
                    {
                        qry.Append("cassette3_deposit_value =" + cassette3_deposit_valueDbString);
                        qry.Append(",");
                    }

                    if (cassette4_deposit_valueChanged)
                    {
                        qry.Append("cassette4_deposit_value =" + cassette4_deposit_valueDbString);
                        qry.Append(",");
                    }

                    if (purge_deposit_valueChanged)
                    {
                        qry.Append("purge_deposit_value =" + purge_deposit_valueDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("deposit_position_id = " + deposit_position_idDbString);
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
            cmd.CommandText = "DELETE Deposit_position wheredeposit_position_id= " + deposit_position_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteDepositPositions(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Deposit_position where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_id = 0,
            deposit_position_id = 1,
            cassette1_deposit = 2,
            cassette2_deposit = 3,
            cassette3_deposit = 4,
            cassette4_deposit = 5,
            purge_deposit = 6,
            bin1 = 7,
            bin2 = 8,
            bin3 = 9,
            bin4 = 10,
            last_cpm_deposit_at = 11,
            last_bna_deposit_at = 12,
            cassette1_deposit_value = 13,
            cassette2_deposit_value = 14,
            cassette3_deposit_value = 15,
            cassette4_deposit_value = 16,
            purge_deposit_value = 17
        }
        #endregion
        public DataTable BulkSave(List<DepositPosition> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringCash);
            bulk.DestinationTableName = "Deposit_position";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(DepositPosition.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<DepositPosition> transList, ref DataTable dt)
        {
            foreach (DepositPosition tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_id"] = tran.AtmId;
                Row["deposit_position_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["cassette1_deposit"] = tran.Cassette1Deposit;
                Row["cassette2_deposit"] = tran.Cassette2Deposit;
                Row["cassette3_deposit"] = tran.Cassette3Deposit;
                Row["cassette4_deposit"] = tran.Cassette4Deposit;
                Row["purge_deposit"] = tran.PurgeDeposit;
                Row["bin1"] = tran.Bin1;
                Row["bin2"] = tran.Bin2;
                Row["bin3"] = tran.Bin3;
                Row["bin4"] = tran.Bin4;
                Row["last_cpm_deposit_at"] = tran.LastCpmDepositAt;
                Row["last_bna_deposit_at"] = tran.LastBnaDepositAt;
                Row["cassette1_deposit_value"] = tran.Cassette1DepositValue;
                Row["cassette2_deposit_value"] = tran.Cassette2DepositValue;
                Row["cassette3_deposit_value"] = tran.Cassette3DepositValue;
                Row["cassette4_deposit_value"] = tran.Cassette4DepositValue;
                Row["purge_deposit_value"] = tran.PurgeDepositValue;
                dt.Rows.Add(Row);
            }
        }
    }
}

 
