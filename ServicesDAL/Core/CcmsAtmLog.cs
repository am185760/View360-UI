
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServicesDAL
{
    [Serializable()]
    public class CcmsAtmLog
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsAtmLog() { }
        public CcmsAtmLog(long id, DateTime event_occured_at, long task_id, DateTime processing_datetime)
        {
            this.event_occured_at = event_occured_at;
            this.event_occured_atChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
        }
        public CcmsAtmLog(string event_name, DateTime event_occured_at, string event_mode, string event_info, long? atm_id, string order_number, long task_id, DateTime processing_datetime)
        {
            this.event_name = event_name;
            this.event_nameChanged = true;
            this.event_occured_at = event_occured_at;
            this.event_occured_atChanged = true;
            this.event_mode = event_mode;
            this.event_modeChanged = true;
            this.event_info = event_info;
            this.event_infoChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.order_number = order_number;
            this.order_numberChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
        }
        private CcmsAtmLog(long id, string event_name, DateTime event_occured_at, string event_mode, string event_info, long? atm_id, string order_number, long task_id, DateTime processing_datetime)
        {
            this.id = id;
            this.idChanged = true;
            this.event_name = event_name;
            this.event_nameChanged = true;
            this.event_occured_at = event_occured_at;
            this.event_occured_atChanged = true;
            this.event_mode = event_mode;
            this.event_modeChanged = true;
            this.event_info = event_info;
            this.event_infoChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.order_number = order_number;
            this.order_numberChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
        }

        #region members and properties for columns

        #region Id
        private bool idChanged = false;
        private long id;
        public long Id
        {
            get { return id; }
            set
            {
                id = value;
                idChanged = true;
            }
        }
        private string idDbString
        {
            get
            {
                return id.ToString();
            }
        }
        #endregion
        #region EventName
        private bool event_nameChanged = false;
        private string event_name;
        public string EventName
        {
            get { return event_name; }
            set
            {
                event_name = value;
                event_nameChanged = true;
            }
        }
        private string event_nameDbString
        {
            get
            {
                if (this.event_name != null)
                    return string.Format("'{0}'", event_name);
                else
                    return "null";
            }
        }
        #endregion
        #region EventOccuredAt
        private bool event_occured_atChanged = false;
        private DateTime event_occured_at;
        public DateTime EventOccuredAt
        {
            get { return event_occured_at; }
            set
            {
                event_occured_at = value;
                event_occured_atChanged = true;
            }
        }
        private string event_occured_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", event_occured_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region EventMode
        private bool event_modeChanged = false;
        private string event_mode;
        public string EventMode
        {
            get { return event_mode; }
            set
            {
                event_mode = value;
                event_modeChanged = true;
            }
        }
        private string event_modeDbString
        {
            get
            {
                if (this.event_mode != null)
                    return string.Format("'{0}'", event_mode);
                else
                    return "null";
            }
        }
        #endregion
        #region EventInfo
        private bool event_infoChanged = false;
        private string event_info;
        public string EventInfo
        {
            get { return event_info; }
            set
            {
                event_info = value;
                event_infoChanged = true;
            }
        }
        private string event_infoDbString
        {
            get
            {
                if (this.event_info != null)
                    return string.Format("'{0}'", event_info);
                else
                    return "null";
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private long? atm_id;
        public long? AtmId
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
                if (this.atm_id.HasValue)
                    return atm_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region OrderNumber
        private bool order_numberChanged = false;
        private string order_number;
        public string OrderNumber
        {
            get { return order_number; }
            set
            {
                order_number = value;
                order_numberChanged = true;
            }
        }
        private string order_numberDbString
        {
            get
            {
                if (this.order_number != null)
                    return string.Format("'{0}'", order_number);
                else
                    return "null";
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
        #region ProcessingDatetime
        private bool processing_datetimeChanged = false;
        private DateTime processing_datetime;
        public DateTime ProcessingDatetime
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
                return string.Format("Convert(datetime,'{0}',121)", processing_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #endregion

        #region CcmsAtmLogReader
        public class CcmsAtmLogReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsAtmLog currentCcmsAtmLog;
            Columns columns;
            bool partialRead = false;
            private CcmsAtmLogReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsAtmLogReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsAtmLogReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsAtmLog; }

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
                    currentCcmsAtmLog = new CcmsAtmLog();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsAtmLog.id = (long)reader["id"];
                        if ((columns & Columns.event_name) == Columns.event_name && reader["event_name"] != DBNull.Value)
                            currentCcmsAtmLog.event_name = (string)reader["event_name"];
                        if ((columns & Columns.event_occured_at) == Columns.event_occured_at && reader["event_occured_at"] != DBNull.Value)
                            currentCcmsAtmLog.event_occured_at = (DateTime)reader["event_occured_at"];
                        if ((columns & Columns.event_mode) == Columns.event_mode && reader["event_mode"] != DBNull.Value)
                            currentCcmsAtmLog.event_mode = (string)reader["event_mode"];
                        if ((columns & Columns.event_info) == Columns.event_info && reader["event_info"] != DBNull.Value)
                            currentCcmsAtmLog.event_info = (string)reader["event_info"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentCcmsAtmLog.atm_id = (long?)reader["atm_id"];
                        if ((columns & Columns.order_number) == Columns.order_number && reader["order_number"] != DBNull.Value)
                            currentCcmsAtmLog.order_number = (string)reader["order_number"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentCcmsAtmLog.task_id = (long)reader["task_id"];
                        if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"] != DBNull.Value)
                            currentCcmsAtmLog.processing_datetime = (DateTime)reader["processing_datetime"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsAtmLog.id = (long)reader["id"];
                        if (reader["event_name"] != DBNull.Value)
                            currentCcmsAtmLog.event_name = (string)reader["event_name"];
                        if (reader["event_occured_at"] != DBNull.Value)
                            currentCcmsAtmLog.event_occured_at = (DateTime)reader["event_occured_at"];
                        if (reader["event_mode"] != DBNull.Value)
                            currentCcmsAtmLog.event_mode = (string)reader["event_mode"];
                        if (reader["event_info"] != DBNull.Value)
                            currentCcmsAtmLog.event_info = (string)reader["event_info"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentCcmsAtmLog.atm_id = (long?)reader["atm_id"];
                        if (reader["order_number"] != DBNull.Value)
                            currentCcmsAtmLog.order_number = (string)reader["order_number"];
                        if (reader["task_id"] != DBNull.Value)
                            currentCcmsAtmLog.task_id = (long)reader["task_id"];
                        if (reader["processing_datetime"] != DBNull.Value)
                            currentCcmsAtmLog.processing_datetime = (DateTime)reader["processing_datetime"];
                    }

                    currentCcmsAtmLog.isNewEntity = false;
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

            public CcmsAtmLog CurrentCcmsAtmLog
            {
                get { return currentCcmsAtmLog; }
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


        #region CcmsAtmLog functions

        public static CcmsAtmLogReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.event_name == (Columns.event_name & columns))
                qry.Append("event_name,");
            if (Columns.event_occured_at == (Columns.event_occured_at & columns))
                qry.Append("event_occured_at,");
            if (Columns.event_mode == (Columns.event_mode & columns))
                qry.Append("event_mode,");
            if (Columns.event_info == (Columns.event_info & columns))
                qry.Append("event_info,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.order_number == (Columns.order_number & columns))
                qry.Append("order_number,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.processing_datetime == (Columns.processing_datetime & columns))
                qry.Append("processing_datetime,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ccms_atm_log ");

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
            return new CcmsAtmLogReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsAtmLogReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsAtmLogReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectid,event_name,event_occured_at,event_mode,event_info,atm_id,order_number,task_id,processing_datetimefrom Ccms_atm_log ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CcmsAtmLogReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsAtmLogReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static CcmsAtmLog LoadCcmsAtmLog(string where)
        {
            CcmsAtmLogReader reader = CcmsAtmLog.ExecuteReader(where);
            CcmsAtmLog _ccmsatmlog = null;
            if (reader.Read())
                _ccmsatmlog = reader.CurrentCcmsAtmLog;
            reader.Close();
            return _ccmsatmlog;
        }

        public static CcmsAtmLog LoadCcmsAtmLog(string where, IDbConnection conn)
        {
            CcmsAtmLogReader reader = CcmsAtmLog.ExecuteReader(where, conn);
            CcmsAtmLog _ccmsatmlog = null;
            if (reader.Read())
                _ccmsatmlog = reader.CurrentCcmsAtmLog;
            reader.Close(false);
            return _ccmsatmlog;
        }

        public static CcmsAtmLog LoadCcmsAtmLogByPk(long id, DateTime event_occured_at)
        {
            return LoadCcmsAtmLog("id=" + id + " and event_occured_at=Convert(datetime,'" + event_occured_at.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)");
        }

        public static CcmsAtmLog LoadCcmsAtmLogByPk(long id, DateTime event_occured_at, IDbConnection conn)
        {
            return LoadCcmsAtmLog(" id=" + id + " and event_occured_at=Convert(datetime,'" + event_occured_at.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',121)", conn);
        }

        public void Save()
        {
            if (idChanged || event_nameChanged || event_occured_atChanged || event_modeChanged || event_infoChanged || atm_idChanged || order_numberChanged || task_idChanged || processing_datetimeChanged)
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
            if (idChanged || event_nameChanged || event_occured_atChanged || event_modeChanged || event_infoChanged || atm_idChanged || order_numberChanged || task_idChanged || processing_datetimeChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ccms_atm_log(id,event_name,event_occured_at,event_mode,event_info,atm_id,order_number,task_id,processing_datetime) values(");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.id);
                    }
                    qry.Append(",");
                    qry.Append(event_nameDbString + ",");
                    qry.Append(event_occured_atDbString + ",");
                    qry.Append(event_modeDbString + ",");
                    qry.Append(event_infoDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(order_numberDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(processing_datetimeDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(idChanged || event_nameChanged || event_occured_atChanged || event_modeChanged || event_infoChanged || atm_idChanged || order_numberChanged || task_idChanged || processing_datetimeChanged))
                        return;
                    qry.Append("UPDATE Ccms_atm_log set "); if (event_nameChanged)
                    {
                        qry.Append("event_name =" + event_nameDbString);
                        qry.Append(",");
                    }

                    if (event_modeChanged)
                    {
                        qry.Append("event_mode =" + event_modeDbString);
                        qry.Append(",");
                    }

                    if (event_infoChanged)
                    {
                        qry.Append("event_info =" + event_infoDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (order_numberChanged)
                    {
                        qry.Append("order_number =" + order_numberDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (processing_datetimeChanged)
                    {
                        qry.Append("processing_datetime =" + processing_datetimeDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("id = " + idDbString);
                    qry.Append(" and event_occured_at = " + event_occured_atDbString);
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
            cmd.CommandText = "DELETE Ccms_atm_log whereid= " + id + " and event_occured_at= " + event_occured_at;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCcmsAtmLogs(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_atm_log where " + where,DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 0,
            event_name = 1,
            event_occured_at = 2,
            event_mode = 3,
            event_info = 4,
            atm_id = 5,
            order_number = 6,
            task_id = 7,
            processing_datetime = 8
        }
        #endregion
        public DataTable BulkSave(List<CcmsAtmLog> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_atm_log";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsAtmLog.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsAtmLog> transList, ref DataTable dt)
        {
            foreach (CcmsAtmLog tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["event_name"] = tran.EventName;
                Row["event_occured_at"] = tran.EventOccuredAt;
                Row["event_mode"] = tran.EventMode;
                Row["event_info"] = tran.EventInfo;
                Row["atm_id"] = tran.AtmId;
                Row["order_number"] = tran.OrderNumber;
                Row["task_id"] = tran.TaskId;
                Row["processing_datetime"] = tran.ProcessingDatetime;
                dt.Rows.Add(Row);
            }
        }
    }
}

  
 
 


