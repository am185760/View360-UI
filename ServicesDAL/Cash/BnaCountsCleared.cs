
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
    public class BnaCountsCleared
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public BnaCountsCleared() { }
        public BnaCountsCleared(long bna_counts_cleared_id, long atm_id, DateTime counts_cleared_at, DateTime recorded_at)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.counts_cleared_at = counts_cleared_at;
            this.counts_cleared_atChanged = true;
            this.recorded_at = recorded_at;
            this.recorded_atChanged = true;
        }
        public BnaCountsCleared(long atm_id, DateTime counts_cleared_at, DateTime recorded_at, long? task_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.counts_cleared_at = counts_cleared_at;
            this.counts_cleared_atChanged = true;
            this.recorded_at = recorded_at;
            this.recorded_atChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }
        private BnaCountsCleared(long bna_counts_cleared_id, long atm_id, DateTime counts_cleared_at, DateTime recorded_at, long? task_id)
        {
            this.bna_counts_cleared_id = bna_counts_cleared_id;
            this.bna_counts_cleared_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.counts_cleared_at = counts_cleared_at;
            this.counts_cleared_atChanged = true;
            this.recorded_at = recorded_at;
            this.recorded_atChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }

        #region members and properties for columns

        #region BnaCountsClearedId
        private bool bna_counts_cleared_idChanged = false;
        private long bna_counts_cleared_id;
        public long BnaCountsClearedId
        {
            get { return bna_counts_cleared_id; }
            set
            {
                bna_counts_cleared_id = value;
                bna_counts_cleared_idChanged = true;
            }
        }
        private string bna_counts_cleared_idDbString
        {
            get
            {
                return bna_counts_cleared_id.ToString();
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
        #region CountsClearedAt
        private bool counts_cleared_atChanged = false;
        private DateTime counts_cleared_at;
        public DateTime CountsClearedAt
        {
            get { return counts_cleared_at; }
            set
            {
                counts_cleared_at = value;
                counts_cleared_atChanged = true;
            }
        }
        private string counts_cleared_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", counts_cleared_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region RecordedAt
        private bool recorded_atChanged = false;
        private DateTime recorded_at;
        public DateTime RecordedAt
        {
            get { return recorded_at; }
            set
            {
                recorded_at = value;
                recorded_atChanged = true;
            }
        }
        private string recorded_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", recorded_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #endregion

        #region BnaCountsClearedReader
        public class BnaCountsClearedReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            BnaCountsCleared currentBnaCountsCleared;
            Columns columns;
            bool partialRead = false;
            private BnaCountsClearedReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public BnaCountsClearedReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public BnaCountsClearedReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentBnaCountsCleared; }

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
                    currentBnaCountsCleared = new BnaCountsCleared();
                    if (partialRead)
                    {
                        if ((columns & Columns.bna_counts_cleared_id) == Columns.bna_counts_cleared_id && reader["bna_counts_cleared_id"] != DBNull.Value)
                            currentBnaCountsCleared.bna_counts_cleared_id = (long)reader["bna_counts_cleared_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentBnaCountsCleared.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.counts_cleared_at) == Columns.counts_cleared_at && reader["counts_cleared_at"] != DBNull.Value)
                            currentBnaCountsCleared.counts_cleared_at = (DateTime)reader["counts_cleared_at"];
                        if ((columns & Columns.recorded_at) == Columns.recorded_at && reader["recorded_at"] != DBNull.Value)
                            currentBnaCountsCleared.recorded_at = (DateTime)reader["recorded_at"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentBnaCountsCleared.task_id = (long?)reader["task_id"];

                    }
                    else
                    {
                        if (reader["bna_counts_cleared_id"] != DBNull.Value)
                            currentBnaCountsCleared.bna_counts_cleared_id = (long)reader["bna_counts_cleared_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentBnaCountsCleared.atm_id = (long)reader["atm_id"];
                        if (reader["counts_cleared_at"] != DBNull.Value)
                            currentBnaCountsCleared.counts_cleared_at = (DateTime)reader["counts_cleared_at"];
                        if (reader["recorded_at"] != DBNull.Value)
                            currentBnaCountsCleared.recorded_at = (DateTime)reader["recorded_at"];
                        if (reader["task_id"] != DBNull.Value)
                            currentBnaCountsCleared.task_id = (long?)reader["task_id"];
                    }

                    currentBnaCountsCleared.isNewEntity = false;
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

            public BnaCountsCleared CurrentBnaCountsCleared
            {
                get { return currentBnaCountsCleared; }
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


        #region BnaCountsCleared functions

        public static BnaCountsClearedReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.bna_counts_cleared_id == (Columns.bna_counts_cleared_id & columns))
                qry.Append("bna_counts_cleared_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.counts_cleared_at == (Columns.counts_cleared_at & columns))
                qry.Append("counts_cleared_at,");
            if (Columns.recorded_at == (Columns.recorded_at & columns))
                qry.Append("recorded_at,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Bna_counts_cleared ");

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
            return new BnaCountsClearedReader(cmd.ExecuteReader(), conn, columns);
        }

        static public BnaCountsClearedReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static BnaCountsClearedReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select bna_counts_cleared_id,atm_id,counts_cleared_at,recorded_at,task_id from Bna_counts_cleared ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new BnaCountsClearedReader(cmd.ExecuteReader(), conn);
        }

        static public BnaCountsClearedReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static BnaCountsCleared LoadBnaCountsCleared(string where)
        {
            BnaCountsClearedReader reader = BnaCountsCleared.ExecuteReader(where);
            BnaCountsCleared _bnacountscleared = null;
            if (reader.Read())
                _bnacountscleared = reader.CurrentBnaCountsCleared;
            reader.Close();
            return _bnacountscleared;
        }

        public static BnaCountsCleared LoadBnaCountsCleared(string where, IDbConnection conn)
        {
            BnaCountsClearedReader reader = BnaCountsCleared.ExecuteReader(where, conn);
            BnaCountsCleared _bnacountscleared = null;
            if (reader.Read())
                _bnacountscleared = reader.CurrentBnaCountsCleared;
            reader.Close(false);
            return _bnacountscleared;
        }

        public static BnaCountsCleared LoadBnaCountsClearedByPk(long bna_counts_cleared_id)
        {
            return LoadBnaCountsCleared("bna_counts_cleared_id=" + bna_counts_cleared_id);
        }

        public static BnaCountsCleared LoadBnaCountsClearedByPk(long bna_counts_cleared_id, IDbConnection conn)
        {
            return LoadBnaCountsCleared(" bna_counts_cleared_id=" + bna_counts_cleared_id, conn);
        }

        public void Save()
        {
            if (bna_counts_cleared_idChanged || atm_idChanged || counts_cleared_atChanged || recorded_atChanged || task_idChanged)
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
            if (bna_counts_cleared_idChanged || atm_idChanged || counts_cleared_atChanged || recorded_atChanged || task_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Bna_counts_cleared(bna_counts_cleared_id,atm_id,counts_cleared_at,recorded_at,task_id) values(");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.bna_counts_cleared_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.bna_counts_cleared_id);
                    }
                    qry.Append(",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(counts_cleared_atDbString + ",");
                    qry.Append(recorded_atDbString + ",");
                    qry.Append(task_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(bna_counts_cleared_idChanged || atm_idChanged || counts_cleared_atChanged || recorded_atChanged || task_idChanged))
                        return;
                    qry.Append("UPDATE Bna_counts_cleared set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (counts_cleared_atChanged)
                    {
                        qry.Append("counts_cleared_at =" + counts_cleared_atDbString);
                        qry.Append(",");
                    }

                    if (recorded_atChanged)
                    {
                        qry.Append("recorded_at =" + recorded_atDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("bna_counts_cleared_id = " + bna_counts_cleared_idDbString);
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
            cmd.CommandText = "DELETE Bna_counts_cleared wherebna_counts_cleared_id= " + bna_counts_cleared_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteBnaCountsCleareds(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Bna_counts_cleared where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            bna_counts_cleared_id = 0,
            atm_id = 1,
            counts_cleared_at = 2,
            recorded_at = 3,
            task_id = 4
        }
        #endregion
        public DataTable BulkSave(List<BnaCountsCleared> dataArray)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringCash);
            bulk.DestinationTableName = "Bna_counts_cleared";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(BnaCountsCleared.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<BnaCountsCleared> transList, ref DataTable dt)
        {
            foreach (BnaCountsCleared tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["bna_counts_cleared_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["atm_id"] = tran.AtmId;
                Row["counts_cleared_at"] = tran.CountsClearedAt;
                Row["recorded_at"] = tran.RecordedAt;
                Row["task_id"] = tran.TaskId;
                dt.Rows.Add(Row);
            }
        }
    }
}

 
