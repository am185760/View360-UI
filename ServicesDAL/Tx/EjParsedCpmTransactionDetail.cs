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
    public class EjParsedCpmTransactionDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedCpmTransactionDetail() { }
        public EjParsedCpmTransactionDetail(long ej_parsed_cpm_transaction_id, decimal check_amount)
        {
            this.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_id;
            this.ej_parsed_cpm_transaction_idChanged = true;
            this.check_amount = check_amount;
            this.check_amountChanged = true;
        }
        private EjParsedCpmTransactionDetail(long ej_parsed_cpm_transaction_detail_id, long ej_parsed_cpm_transaction_id, decimal check_amount)
        {
            this.ej_parsed_cpm_transaction_detail_id = ej_parsed_cpm_transaction_detail_id;
            this.ej_parsed_cpm_transaction_detail_idChanged = true;
            this.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_id;
            this.ej_parsed_cpm_transaction_idChanged = true;
            this.check_amount = check_amount;
            this.check_amountChanged = true;
        }

        #region members and properties for columns

        #region EjParsedCpmTransactionDetailId
        private bool ej_parsed_cpm_transaction_detail_idChanged = false;
        private long ej_parsed_cpm_transaction_detail_id;
        public long EjParsedCpmTransactionDetailId
        {
            get { return ej_parsed_cpm_transaction_detail_id; }
            set
            {
                ej_parsed_cpm_transaction_detail_id = value;
                ej_parsed_cpm_transaction_detail_idChanged = true;
            }
        }
        private string ej_parsed_cpm_transaction_detail_idDbString
        {
            get
            {
                return ej_parsed_cpm_transaction_detail_id.ToString();
            }
        }
        #endregion
        #region EjParsedCpmTransactionId
        private bool ej_parsed_cpm_transaction_idChanged = false;
        private long ej_parsed_cpm_transaction_id;
        public long EjParsedCpmTransactionId
        {
            get { return ej_parsed_cpm_transaction_id; }
            set
            {
                ej_parsed_cpm_transaction_id = value;
                ej_parsed_cpm_transaction_idChanged = true;
            }
        }
        private string ej_parsed_cpm_transaction_idDbString
        {
            get
            {
                return ej_parsed_cpm_transaction_id.ToString();
            }
        }
        #endregion
        #region CheckAmount
        private bool check_amountChanged = false;
        private decimal check_amount;
        public decimal CheckAmount
        {
            get { return check_amount; }
            set
            {
                check_amount = value;
                check_amountChanged = true;
            }
        }
        private string check_amountDbString
        {
            get
            {
                return check_amount.ToString();
            }
        }
        #endregion
        #endregion

        #region EjParsedCpmTransactionDetailReader
        public class EjParsedCpmTransactionDetailReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjParsedCpmTransactionDetail currentEjParsedCpmTransactionDetail;
            Columns columns;
            bool partialRead = false;
            private EjParsedCpmTransactionDetailReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjParsedCpmTransactionDetailReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjParsedCpmTransactionDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjParsedCpmTransactionDetail; }

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
                    currentEjParsedCpmTransactionDetail = new EjParsedCpmTransactionDetail();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_parsed_cpm_transaction_detail_id) == Columns.ej_parsed_cpm_transaction_detail_id && reader["ej_parsed_cpm_transaction_detail_id"] != DBNull.Value)
                            currentEjParsedCpmTransactionDetail.ej_parsed_cpm_transaction_detail_id = (long)reader["ej_parsed_cpm_transaction_detail_id"];
                        if ((columns & Columns.ej_parsed_cpm_transaction_id) == Columns.ej_parsed_cpm_transaction_id && reader["ej_parsed_cpm_transaction_id"] != DBNull.Value)
                            currentEjParsedCpmTransactionDetail.ej_parsed_cpm_transaction_id = (long)reader["ej_parsed_cpm_transaction_id"];
                        if ((columns & Columns.check_amount) == Columns.check_amount && reader["check_amount"] != DBNull.Value)
                            currentEjParsedCpmTransactionDetail.check_amount = (decimal)reader["check_amount"];

                    }
                    else
                    {
                        if (reader["ej_parsed_cpm_transaction_detail_id"] != DBNull.Value)
                            currentEjParsedCpmTransactionDetail.ej_parsed_cpm_transaction_detail_id = (long)reader["ej_parsed_cpm_transaction_detail_id"];
                        if (reader["ej_parsed_cpm_transaction_id"] != DBNull.Value)
                            currentEjParsedCpmTransactionDetail.ej_parsed_cpm_transaction_id = (long)reader["ej_parsed_cpm_transaction_id"];
                        if (reader["check_amount"] != DBNull.Value)
                            currentEjParsedCpmTransactionDetail.check_amount = (decimal)reader["check_amount"];
                    }

                    currentEjParsedCpmTransactionDetail.isNewEntity = false;
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

            public EjParsedCpmTransactionDetail CurrentEjParsedCpmTransactionDetail
            {
                get { return currentEjParsedCpmTransactionDetail; }
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


        #region EjParsedCpmTransactionDetail functions

        public static EjParsedCpmTransactionDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_parsed_cpm_transaction_detail_id == (Columns.ej_parsed_cpm_transaction_detail_id & columns))
                qry.Append("ej_parsed_cpm_transaction_detail_id,");
            if (Columns.ej_parsed_cpm_transaction_id == (Columns.ej_parsed_cpm_transaction_id & columns))
                qry.Append("ej_parsed_cpm_transaction_id,");
            if (Columns.check_amount == (Columns.check_amount & columns))
                qry.Append("check_amount,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_parsed_cpm_transaction_detail ");

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
            return new EjParsedCpmTransactionDetailReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjParsedCpmTransactionDetailReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjParsedCpmTransactionDetailReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectej_parsed_cpm_transaction_detail_id,ej_parsed_cpm_transaction_id,check_amountfrom Ej_parsed_cpm_transaction_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedCpmTransactionDetailReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedCpmTransactionDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public static EjParsedCpmTransactionDetail LoadEjParsedCpmTransactionDetail(string where)
        {
            EjParsedCpmTransactionDetailReader reader = EjParsedCpmTransactionDetail.ExecuteReader(where);
            EjParsedCpmTransactionDetail _ejparsedcpmtransactiondetail = null;
            if (reader.Read())
                _ejparsedcpmtransactiondetail = reader.CurrentEjParsedCpmTransactionDetail;
            reader.Close();
            return _ejparsedcpmtransactiondetail;
        }

        public static EjParsedCpmTransactionDetail LoadEjParsedCpmTransactionDetail(string where, IDbConnection conn)
        {
            EjParsedCpmTransactionDetailReader reader = EjParsedCpmTransactionDetail.ExecuteReader(where, conn);
            EjParsedCpmTransactionDetail _ejparsedcpmtransactiondetail = null;
            if (reader.Read())
                _ejparsedcpmtransactiondetail = reader.CurrentEjParsedCpmTransactionDetail;
            reader.Close(false);
            return _ejparsedcpmtransactiondetail;
        }

        public static EjParsedCpmTransactionDetail LoadEjParsedCpmTransactionDetailByPk(long ej_parsed_cpm_transaction_detail_id)
        {
            return LoadEjParsedCpmTransactionDetail("ej_parsed_cpm_transaction_detail_id=" + ej_parsed_cpm_transaction_detail_id);
        }

        public static EjParsedCpmTransactionDetail LoadEjParsedCpmTransactionDetailByPk(long ej_parsed_cpm_transaction_detail_id, IDbConnection conn)
        {
            return LoadEjParsedCpmTransactionDetail(" ej_parsed_cpm_transaction_detail_id=" + ej_parsed_cpm_transaction_detail_id, conn);
        }

        public void Save()
        {
            if (ej_parsed_cpm_transaction_detail_idChanged || ej_parsed_cpm_transaction_idChanged || check_amountChanged)
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
            if (ej_parsed_cpm_transaction_detail_idChanged || ej_parsed_cpm_transaction_idChanged || check_amountChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_cpm_transaction_detail(ej_parsed_cpm_transaction_detail_id,ej_parsed_cpm_transaction_id,check_amount) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.ej_parsed_cpm_transaction_detail_id = ConnectionFactory.GetNextId(DatabaseName.Tx);
                        qry.Append(this.ej_parsed_cpm_transaction_detail_id);
                    }
                    qry.Append(",");
                    qry.Append(ej_parsed_cpm_transaction_idDbString + ",");
                    qry.Append(check_amountDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_cpm_transaction_detail_idChanged || ej_parsed_cpm_transaction_idChanged || check_amountChanged))
                        return;
                    qry.Append("UPDATE Ej_parsed_cpm_transaction_detail set "); if (ej_parsed_cpm_transaction_idChanged)
                    {
                        qry.Append("ej_parsed_cpm_transaction_id =" + ej_parsed_cpm_transaction_idDbString);
                        qry.Append(",");
                    }

                    if (check_amountChanged)
                    {
                        qry.Append("check_amount =" + check_amountDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_parsed_cpm_transaction_detail_id = " + ej_parsed_cpm_transaction_detail_idDbString);
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
            cmd.CommandText = "DELETE Ej_parsed_cpm_transaction_detail whereej_parsed_cpm_transaction_detail_id= " + ej_parsed_cpm_transaction_detail_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjParsedCpmTransactionDetails(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_cpm_transaction_detail where " + where, DatabaseName.Tx);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_parsed_cpm_transaction_detail_id = 0,
            ej_parsed_cpm_transaction_id = 1,
            check_amount = 2
        }
        #endregion
        public DataTable BulkSave(List<EjParsedCpmTransactionDetail> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_parsed_cpm_transaction_detail";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjParsedCpmTransactionDetail.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjParsedCpmTransactionDetail> transList, ref DataTable dt)
        {
            foreach (EjParsedCpmTransactionDetail tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_parsed_cpm_transaction_detail_id"] = ConnectionFactory.GetNextId(DatabaseName.Tx);
                Row["ej_parsed_cpm_transaction_id"] = tran.EjParsedCpmTransactionId;
                Row["check_amount"] = tran.CheckAmount;
                dt.Rows.Add(Row);
            }
        }
    }
}
