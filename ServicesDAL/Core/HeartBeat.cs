using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServicesDAL
{
    [Serializable()]
    public class HeartBeat
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public HeartBeat() { }
        public HeartBeat(long heart_beat_id, long atm_id, DateTime heart_beat_received_at
        )
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.heart_beat_received_at = heart_beat_received_at;
            this.heart_beat_received_atChanged = true;
        }
        public HeartBeat(long atm_id, DateTime heart_beat_received_at, bool? is_service_manager)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.heart_beat_received_at = heart_beat_received_at;
            this.heart_beat_received_atChanged = true;
            this.is_service_manager = is_service_manager;
            this.is_service_managerChanged = true;
        }
        private HeartBeat(long heart_beat_id, long atm_id, DateTime heart_beat_received_at, bool? is_service_manager)
        {
            this.heart_beat_id = heart_beat_id;
            this.heart_beat_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.heart_beat_received_at = heart_beat_received_at;
            this.heart_beat_received_atChanged = true;
            this.is_service_manager = is_service_manager;
            this.is_service_managerChanged = true;
        }

        #region members and properties for columns

        #region HeartBeatId
        private bool heart_beat_idChanged = false;
        private long heart_beat_id;
        public long HeartBeatId
        {
            get { return heart_beat_id; }
            set
            {
                heart_beat_id = value;
                heart_beat_idChanged = true;
            }
        }
        private string heart_beat_idDbString
        {
            get
            {
                return heart_beat_id.ToString();
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
        #region HeartBeatReceivedAt
        private bool heart_beat_received_atChanged = false;
        private DateTime heart_beat_received_at;
        public DateTime HeartBeatReceivedAt
        {
            get { return heart_beat_received_at; }
            set
            {
                heart_beat_received_at = value;
                heart_beat_received_atChanged = true;
            }
        }
        private string heart_beat_received_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", heart_beat_received_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region IsServiceManager
        private bool is_service_managerChanged = false;
        private bool? is_service_manager;
        public bool? IsServiceManager
        {
            get { return is_service_manager; }
            set
            {
                is_service_manager = value;
                is_service_managerChanged = true;
            }
        }
        private string is_service_managerDbString
        {
            get
            {
                if (this.is_service_manager.HasValue)
                    return is_service_manager.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region HeartBeatReader
        public class HeartBeatReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            HeartBeat currentHeartBeat;
            Columns columns;
            bool partialRead = false;
            private HeartBeatReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public HeartBeatReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public HeartBeatReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentHeartBeat; }

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
                    currentHeartBeat = new HeartBeat();
                    if (partialRead)
                    {
                        if ((columns & Columns.heart_beat_id) == Columns.heart_beat_id && reader["heart_beat_id"] != DBNull.Value)
                            currentHeartBeat.heart_beat_id = (long)reader["heart_beat_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentHeartBeat.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.heart_beat_received_at) == Columns.heart_beat_received_at && reader["heart_beat_received_at"] != DBNull.Value)
                            currentHeartBeat.heart_beat_received_at = (DateTime)reader["heart_beat_received_at"];
                        if ((columns & Columns.is_service_manager) == Columns.is_service_manager && reader["is_service_manager"] != DBNull.Value)
                            currentHeartBeat.is_service_manager = (bool?)reader["is_service_manager"];

                    }
                    else
                    {
                        if (reader["heart_beat_id"] != DBNull.Value)
                            currentHeartBeat.heart_beat_id = (long)reader["heart_beat_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentHeartBeat.atm_id = (long)reader["atm_id"];
                        if (reader["heart_beat_received_at"] != DBNull.Value)
                            currentHeartBeat.heart_beat_received_at = (DateTime)reader["heart_beat_received_at"];
                        if (reader["is_service_manager"] != DBNull.Value)
                            currentHeartBeat.is_service_manager = (bool?)reader["is_service_manager"];
                    }

                    currentHeartBeat.isNewEntity = false;
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

            public HeartBeat CurrentHeartBeat
            {
                get { return currentHeartBeat; }
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


        #region HeartBeat functions

        public static HeartBeatReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.heart_beat_id == (Columns.heart_beat_id & columns))
                qry.Append("heart_beat_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.heart_beat_received_at == (Columns.heart_beat_received_at & columns))
                qry.Append("heart_beat_received_at,");
            if (Columns.is_service_manager == (Columns.is_service_manager & columns))
                qry.Append("is_service_manager,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Heart_beat ");

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
            return new HeartBeatReader(cmd.ExecuteReader(), conn, columns);
        }

        static public HeartBeatReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static HeartBeatReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select heart_beat_id,atm_id,heart_beat_received_at,is_service_manager from Heart_beat ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new HeartBeatReader(cmd.ExecuteReader(), conn);
        }

        static public HeartBeatReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static HeartBeat LoadHeartBeat(string where)
        {
            HeartBeatReader reader = HeartBeat.ExecuteReader(where);
            HeartBeat _heartbeat = null;
            if (reader.Read())
                _heartbeat = reader.CurrentHeartBeat;
            reader.Close();
            return _heartbeat;
        }

        public static HeartBeat LoadHeartBeat(string where, IDbConnection conn)
        {
            HeartBeatReader reader = HeartBeat.ExecuteReader(where, conn);
            HeartBeat _heartbeat = null;
            if (reader.Read())
                _heartbeat = reader.CurrentHeartBeat;
            reader.Close(false);
            return _heartbeat;
        }

        public static HeartBeat LoadHeartBeatByPk(long heart_beat_id)
        {
            return LoadHeartBeat("heart_beat_id=" + heart_beat_id);
        }

        public static HeartBeat LoadHeartBeatByPk(long heart_beat_id, IDbConnection conn)
        {
            return LoadHeartBeat(" heart_beat_id=" + heart_beat_id, conn);
        }

        public void Save()
        {
            if (heart_beat_idChanged || atm_idChanged || heart_beat_received_atChanged || is_service_managerChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Core).CreateCommand());
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
            if (heart_beat_idChanged || atm_idChanged || heart_beat_received_atChanged || is_service_managerChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Heart_beat(heart_beat_id,atm_id,heart_beat_received_at,is_service_manager) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.heart_beat_id = ConnectionFactory.GetNextId(DatabaseName.Core);
                        qry.Append(this.heart_beat_id);
                    }
                    qry.Append(",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(heart_beat_received_atDbString + ",");
                    qry.Append(is_service_managerDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(heart_beat_idChanged || atm_idChanged || heart_beat_received_atChanged || is_service_managerChanged))
                        return;
                    qry.Append("UPDATE Heart_beat set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (heart_beat_received_atChanged)
                    {
                        qry.Append("heart_beat_received_at =" + heart_beat_received_atDbString);
                        qry.Append(",");
                    }

                    if (is_service_managerChanged)
                    {
                        qry.Append("is_service_manager =" + is_service_managerDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("heart_beat_id = " + heart_beat_idDbString);
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Heart_beat whereheart_beat_id= " + heart_beat_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteHeartBeats(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Heart_beat where " + where, DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            heart_beat_id = 0,
            atm_id = 1,
            heart_beat_received_at = 2,
            is_service_manager = 3
        }
        #endregion
        public DataTable BulkSave(List<HeartBeat> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Heart_beat";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(HeartBeat.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<HeartBeat> transList, ref DataTable dt)
        {
            foreach (HeartBeat tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["heart_beat_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                Row["atm_id"] = tran.AtmId;
                Row["heart_beat_received_at"] = tran.HeartBeatReceivedAt;
                Row["is_service_manager"] = tran.IsServiceManager;
                dt.Rows.Add(Row);
            }
        }
    }
}


