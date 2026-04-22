

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
    public class AtmStats
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public AtmStats() { }
        public AtmStats(long atm_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
        }
        public AtmStats(long atm_id, long? task_id, long? offline_task_id, DateTime? max_trxn_at, DateTime? max_rep_at)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.offline_task_id = offline_task_id;
            this.offline_task_idChanged = true;
            this.max_trxn_at = max_trxn_at;
            this.max_trxn_atChanged = true;
            this.max_rep_at = max_rep_at;
            this.max_rep_atChanged = true;
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
        #region OfflineTaskId
        private bool offline_task_idChanged = false;
        private long? offline_task_id;
        public long? OfflineTaskId
        {
            get { return offline_task_id; }
            set
            {
                offline_task_id = value;
                offline_task_idChanged = true;
            }
        }
        private string offline_task_idDbString
        {
            get
            {
                if (this.offline_task_id.HasValue)
                    return offline_task_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MaxTrxnAt
        private bool max_trxn_atChanged = false;
        private DateTime? max_trxn_at;
        public DateTime? MaxTrxnAt
        {
            get { return max_trxn_at; }
            set
            {
                max_trxn_at = value;
                max_trxn_atChanged = true;
            }
        }
        private string max_trxn_atDbString
        {
            get
            {
                if (this.max_trxn_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", max_trxn_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region MaxRepAt
        private bool max_rep_atChanged = false;
        private DateTime? max_rep_at;
        public DateTime? MaxRepAt
        {
            get { return max_rep_at; }
            set
            {
                max_rep_at = value;
                max_rep_atChanged = true;
            }
        }
        private string max_rep_atDbString
        {
            get
            {
                if (this.max_rep_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", max_rep_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region AtmStatsReader
        public class AtmStatsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            AtmStats currentAtmStats;
            Columns columns;
            bool partialRead = false;
            private AtmStatsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AtmStatsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AtmStatsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAtmStats; }

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
                    currentAtmStats = new AtmStats();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentAtmStats.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentAtmStats.task_id = (long?)reader["task_id"];
                        if ((columns & Columns.offline_task_id) == Columns.offline_task_id && reader["offline_task_id"] != DBNull.Value)
                            currentAtmStats.offline_task_id = (long?)reader["offline_task_id"];
                        if ((columns & Columns.max_trxn_at) == Columns.max_trxn_at && reader["max_trxn_at"] != DBNull.Value)
                            currentAtmStats.max_trxn_at = (DateTime?)reader["max_trxn_at"];
                        if ((columns & Columns.max_rep_at) == Columns.max_rep_at && reader["max_rep_at"] != DBNull.Value)
                            currentAtmStats.max_rep_at = (DateTime?)reader["max_rep_at"];

                    }
                    else
                    {
                        if (reader["atm_id"] != DBNull.Value)
                            currentAtmStats.atm_id = (long)reader["atm_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentAtmStats.task_id = (long?)reader["task_id"];
                        if (reader["offline_task_id"] != DBNull.Value)
                            currentAtmStats.offline_task_id = (long?)reader["offline_task_id"];
                        if (reader["max_trxn_at"] != DBNull.Value)
                            currentAtmStats.max_trxn_at = (DateTime?)reader["max_trxn_at"];
                        if (reader["max_rep_at"] != DBNull.Value)
                            currentAtmStats.max_rep_at = (DateTime?)reader["max_rep_at"];
                    }

                    currentAtmStats.isNewEntity = false;
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

            public AtmStats CurrentAtmStats
            {
                get { return currentAtmStats; }
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


        #region AtmStats functions

        public static AtmStatsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.offline_task_id == (Columns.offline_task_id & columns))
                qry.Append("offline_task_id,");
            if (Columns.max_trxn_at == (Columns.max_trxn_at & columns))
                qry.Append("max_trxn_at,");
            if (Columns.max_rep_at == (Columns.max_rep_at & columns))
                qry.Append("max_rep_at,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Atm_stats ");

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
            return new AtmStatsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AtmStatsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AtmStatsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_id,task_id,offline_task_id,max_trxn_at,max_rep_at from Atm_stats ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmStatsReader(cmd.ExecuteReader(), conn);
        }

        static public AtmStatsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Tx));
        }

        public static AtmStats LoadAtmStats(string where)
        {
            AtmStatsReader reader = AtmStats.ExecuteReader(where);
            AtmStats _atmstats = null;
            if (reader.Read())
                _atmstats = reader.CurrentAtmStats;
            reader.Close();
            return _atmstats;
        }

        public static AtmStats LoadAtmStats(string where, IDbConnection conn)
        {
            AtmStatsReader reader = AtmStats.ExecuteReader(where, conn);
            AtmStats _atmstats = null;
            if (reader.Read())
                _atmstats = reader.CurrentAtmStats;
            reader.Close(false);
            return _atmstats;
        }

        public static AtmStats LoadAtmStatsByPk(long atm_id)
        {
            return LoadAtmStats("atm_id=" + atm_id);
        }

        public static AtmStats LoadAtmStatsByPk(long atm_id, IDbConnection conn)
        {
            return LoadAtmStats(" atm_id=" + atm_id, conn);
        }

        public void Save()
        {
            if (atm_idChanged || task_idChanged || offline_task_idChanged || max_trxn_atChanged || max_rep_atChanged)
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
            if (atm_idChanged || task_idChanged || offline_task_idChanged || max_trxn_atChanged || max_rep_atChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm_stats(atm_id,task_id,offline_task_id,max_trxn_at,max_rep_at) values(");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(offline_task_idDbString + ",");
                    qry.Append(max_trxn_atDbString + ",");
                    qry.Append(max_rep_atDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_idChanged || task_idChanged || offline_task_idChanged || max_trxn_atChanged || max_rep_atChanged))
                        return;
                    qry.Append("UPDATE Atm_stats set "); if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (offline_task_idChanged)
                    {
                        qry.Append("offline_task_id =" + offline_task_idDbString);
                        qry.Append(",");
                    }

                    if (max_trxn_atChanged)
                    {
                        qry.Append("max_trxn_at =" + max_trxn_atDbString);
                        qry.Append(",");
                    }

                    if (max_rep_atChanged)
                    {
                        qry.Append("max_rep_at =" + max_rep_atDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("atm_id = " + atm_idDbString);
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
            cmd.CommandText = "DELETE Atm_stats whereatm_id= " + atm_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAtmStatss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Atm_stats where " + where,DatabaseName.Tx);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_id = 0,
            task_id = 1,
            offline_task_id = 2,
            max_trxn_at = 3,
            max_rep_at = 4
        }
        #endregion
        public DataTable BulkSave(List<AtmStats> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringTx);
            bulk.DestinationTableName = "Atm_stats";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(AtmStats.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<AtmStats> transList, ref DataTable dt)
        {
            foreach (AtmStats tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_id"] = tran.AtmId;
                Row["task_id"] = tran.TaskId;
                Row["offline_task_id"] = tran.OfflineTaskId;
                Row["max_trxn_at"] = tran.MaxTrxnAt;
                Row["max_rep_at"] = tran.MaxRepAt;
                dt.Rows.Add(Row);
            }
        }
    }
}

 
