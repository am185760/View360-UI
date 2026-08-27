
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
    public class ParserPostProcessingTask
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ParserPostProcessingTask() { }
        public ParserPostProcessingTask(int parser_post_processing_task_id, string event_type, int entity_id, DateTime event_occured_at, int task_id, int atm_id, DateTime creation_time)
        {
            this.event_type = event_type;
            this.event_typeChanged = true;
            this.entity_id = entity_id;
            this.entity_idChanged = true;
            this.event_occured_at = event_occured_at;
            this.event_occured_atChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
        }
        public ParserPostProcessingTask(string event_type, string event_info, int entity_id, DateTime event_occured_at, int task_id, int atm_id, DateTime creation_time, DateTime? processed_time)
        {
            this.event_type = event_type;
            this.event_typeChanged = true;
            this.event_info = event_info;
            this.event_infoChanged = true;
            this.entity_id = entity_id;
            this.entity_idChanged = true;
            this.event_occured_at = event_occured_at;
            this.event_occured_atChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.processed_time = processed_time;
            this.processed_timeChanged = true;
        }
        private ParserPostProcessingTask(int parser_post_processing_task_id, string event_type, string event_info, int entity_id, DateTime event_occured_at, int task_id, int atm_id, DateTime creation_time, DateTime? processed_time)
        {
            this.parser_post_processing_task_id = parser_post_processing_task_id;
            this.parser_post_processing_task_idChanged = true;
            this.event_type = event_type;
            this.event_typeChanged = true;
            this.event_info = event_info;
            this.event_infoChanged = true;
            this.entity_id = entity_id;
            this.entity_idChanged = true;
            this.event_occured_at = event_occured_at;
            this.event_occured_atChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.processed_time = processed_time;
            this.processed_timeChanged = true;
        }

        #region members and properties for columns

        #region ParserPostProcessingTaskId
        private bool parser_post_processing_task_idChanged = false;
        private int parser_post_processing_task_id;
        public int ParserPostProcessingTaskId
        {
            get { return parser_post_processing_task_id; }
            set
            {
                parser_post_processing_task_id = value;
                parser_post_processing_task_idChanged = true;
            }
        }
        private string parser_post_processing_task_idDbString
        {
            get
            {
                return parser_post_processing_task_id.ToString();
            }
        }
        #endregion
        #region EventType
        private bool event_typeChanged = false;
        private string event_type;
        public string EventType
        {
            get { return event_type; }
            set
            {
                event_type = value;
                event_typeChanged = true;
            }
        }
        private string event_typeDbString
        {
            get
            {
                if (this.event_type != null)
                    return string.Format("'{0}'", event_type);
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
        #region EntityId
        private bool entity_idChanged = false;
        private int entity_id;
        public int EntityId
        {
            get { return entity_id; }
            set
            {
                entity_id = value;
                entity_idChanged = true;
            }
        }
        private string entity_idDbString
        {
            get
            {
                return entity_id.ToString();
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
        #region CreationTime
        private bool creation_timeChanged = false;
        private DateTime creation_time;
        public DateTime CreationTime
        {
            get { return creation_time; }
            set
            {
                creation_time = value;
                creation_timeChanged = true;
            }
        }
        private string creation_timeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region ProcessedTime
        private bool processed_timeChanged = false;
        private DateTime? processed_time;
        public DateTime? ProcessedTime
        {
            get { return processed_time; }
            set
            {
                processed_time = value;
                processed_timeChanged = true;
            }
        }
        private string processed_timeDbString
        {
            get
            {
                if (this.processed_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", processed_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region ParserPostProcessingTaskReader
        public class ParserPostProcessingTaskReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ParserPostProcessingTask currentParserPostProcessingTask;
            Columns columns;
            bool partialRead = false;
            private ParserPostProcessingTaskReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ParserPostProcessingTaskReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ParserPostProcessingTaskReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentParserPostProcessingTask; }

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
                    currentParserPostProcessingTask = new ParserPostProcessingTask();
                    if (partialRead)
                    {
                        if ((columns & Columns.parser_post_processing_task_id) == Columns.parser_post_processing_task_id && reader["parser_post_processing_task_id"] != DBNull.Value)
                            currentParserPostProcessingTask.parser_post_processing_task_id = (int)reader["parser_post_processing_task_id"];
                        if ((columns & Columns.event_type) == Columns.event_type && reader["event_type"] != DBNull.Value)
                            currentParserPostProcessingTask.event_type = (string)reader["event_type"];
                        if ((columns & Columns.event_info) == Columns.event_info && reader["event_info"] != DBNull.Value)
                            currentParserPostProcessingTask.event_info = (string)reader["event_info"];
                        if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"] != DBNull.Value)
                            currentParserPostProcessingTask.entity_id = (int)reader["entity_id"];
                        if ((columns & Columns.event_occured_at) == Columns.event_occured_at && reader["event_occured_at"] != DBNull.Value)
                            currentParserPostProcessingTask.event_occured_at = (DateTime)reader["event_occured_at"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentParserPostProcessingTask.task_id = (int)reader["task_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentParserPostProcessingTask.atm_id = (int)reader["atm_id"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentParserPostProcessingTask.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.processed_time) == Columns.processed_time && reader["processed_time"] != DBNull.Value)
                            currentParserPostProcessingTask.processed_time = (DateTime?)reader["processed_time"];

                    }
                    else
                    {
                        if (reader["parser_post_processing_task_id"] != DBNull.Value)
                            currentParserPostProcessingTask.parser_post_processing_task_id = (int)reader["parser_post_processing_task_id"];
                        if (reader["event_type"] != DBNull.Value)
                            currentParserPostProcessingTask.event_type = (string)reader["event_type"];
                        if (reader["event_info"] != DBNull.Value)
                            currentParserPostProcessingTask.event_info = (string)reader["event_info"];
                        if (reader["entity_id"] != DBNull.Value)
                            currentParserPostProcessingTask.entity_id = (int)reader["entity_id"];
                        if (reader["event_occured_at"] != DBNull.Value)
                            currentParserPostProcessingTask.event_occured_at = (DateTime)reader["event_occured_at"];
                        if (reader["task_id"] != DBNull.Value)
                            currentParserPostProcessingTask.task_id = (int)reader["task_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentParserPostProcessingTask.atm_id = (int)reader["atm_id"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentParserPostProcessingTask.creation_time = (DateTime)reader["creation_time"];
                        if (reader["processed_time"] != DBNull.Value)
                            currentParserPostProcessingTask.processed_time = (DateTime?)reader["processed_time"];
                    }

                    currentParserPostProcessingTask.isNewEntity = false;
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

            public ParserPostProcessingTask CurrentParserPostProcessingTask
            {
                get { return currentParserPostProcessingTask; }
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


        #region ParserPostProcessingTask functions

        public static ParserPostProcessingTaskReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.parser_post_processing_task_id == (Columns.parser_post_processing_task_id & columns))
                qry.Append("parser_post_processing_task_id,");
            if (Columns.event_type == (Columns.event_type & columns))
                qry.Append("event_type,");
            if (Columns.event_info == (Columns.event_info & columns))
                qry.Append("event_info,");
            if (Columns.entity_id == (Columns.entity_id & columns))
                qry.Append("entity_id,");
            if (Columns.event_occured_at == (Columns.event_occured_at & columns))
                qry.Append("event_occured_at,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.processed_time == (Columns.processed_time & columns))
                qry.Append("processed_time,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Parser_post_processing_task ");

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
            return new ParserPostProcessingTaskReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ParserPostProcessingTaskReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ParserPostProcessingTaskReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select parser_post_processing_task_id,event_type,event_info,entity_id,event_occured_at,task_id,atm_id,creation_time,processed_time from Parser_post_processing_task ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ParserPostProcessingTaskReader(cmd.ExecuteReader(), conn);
        }

        static public ParserPostProcessingTaskReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static ParserPostProcessingTask LoadParserPostProcessingTask(string where)
        {
            ParserPostProcessingTaskReader reader = ParserPostProcessingTask.ExecuteReader(where);
            ParserPostProcessingTask _parserpostprocessingtask = null;
            if (reader.Read())
                _parserpostprocessingtask = reader.CurrentParserPostProcessingTask;
            reader.Close();
            return _parserpostprocessingtask;
        }

        public static ParserPostProcessingTask LoadParserPostProcessingTask(string where, IDbConnection conn)
        {
            ParserPostProcessingTaskReader reader = ParserPostProcessingTask.ExecuteReader(where, conn);
            ParserPostProcessingTask _parserpostprocessingtask = null;
            if (reader.Read())
                _parserpostprocessingtask = reader.CurrentParserPostProcessingTask;
            reader.Close(false);
            return _parserpostprocessingtask;
        }

        public static ParserPostProcessingTask LoadParserPostProcessingTaskByPk(int parser_post_processing_task_id)
        {
            return LoadParserPostProcessingTask(" parser_post_processing_task_id=" + parser_post_processing_task_id);
        }

        public static ParserPostProcessingTask LoadParserPostProcessingTaskByPk(int parser_post_processing_task_id, IDbConnection conn)
        {
            return LoadParserPostProcessingTask(" parser_post_processing_task_id=" + parser_post_processing_task_id, conn);
        }

        public void Save()
        {
            if (parser_post_processing_task_idChanged || event_typeChanged || event_infoChanged || entity_idChanged || event_occured_atChanged || task_idChanged || atm_idChanged || creation_timeChanged || processed_timeChanged)
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
            if (parser_post_processing_task_idChanged || event_typeChanged || event_infoChanged || entity_idChanged || event_occured_atChanged || task_idChanged || atm_idChanged || creation_timeChanged || processed_timeChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Parser_post_processing_task( parser_post_processing_task_id,event_type,event_info,entity_id,event_occured_at,task_id,atm_id,creation_time,processed_time ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.parser_post_processing_task_id = ConnectionFactory.GetNextId();
                        qry.Append(this.parser_post_processing_task_id);
                    } qry.Append(",");
                    qry.Append(event_typeDbString + ",");
                    qry.Append(event_infoDbString + ",");
                    qry.Append(entity_idDbString + ",");
                    qry.Append(event_occured_atDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(processed_timeDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(parser_post_processing_task_idChanged || event_typeChanged || event_infoChanged || entity_idChanged || event_occured_atChanged || task_idChanged || atm_idChanged || creation_timeChanged || processed_timeChanged))
                        return;
                    qry.Append("UPDATE Parser_post_processing_task set "); if (event_typeChanged)
                    {
                        qry.Append("event_type =" + event_typeDbString);
                        qry.Append(",");
                    }

                    if (event_infoChanged)
                    {
                        qry.Append("event_info =" + event_infoDbString);
                        qry.Append(",");
                    }

                    if (entity_idChanged)
                    {
                        qry.Append("entity_id =" + entity_idDbString);
                        qry.Append(",");
                    }

                    if (event_occured_atChanged)
                    {
                        qry.Append("event_occured_at =" + event_occured_atDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }

                    if (processed_timeChanged)
                    {
                        qry.Append("processed_time =" + processed_timeDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("parser_post_processing_task_id = " + parser_post_processing_task_idDbString);
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
            cmd.CommandText = "DELETE Parser_post_processing_task where parser_post_processing_task_id = " + parser_post_processing_task_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteParserPostProcessingTasks(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Parser_post_processing_task where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            parser_post_processing_task_id,
            event_type,
            event_info,
            entity_id,
            event_occured_at,
            task_id,
            atm_id,
            creation_time,
            processed_time
        }
        #endregion
        public void BulkSave(List<ParserPostProcessingTask> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Parser_post_processing_task";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ParserPostProcessingTask.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ParserPostProcessingTask> transList, ref DataTable dt)
        {
            foreach (ParserPostProcessingTask tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["parser_post_processing_task_id"] = ConnectionFactory.GetNextId();
                Row["event_type"] = tran.EventType;
                Row["event_info"] = tran.EventInfo;
                Row["entity_id"] = tran.EntityId;
                Row["event_occured_at"] = tran.EventOccuredAt;
                Row["task_id"] = tran.TaskId;
                Row["atm_id"] = tran.AtmId;
                Row["creation_time"] = tran.CreationTime;
                Row["processed_time"] = tran.ProcessedTime;
                dt.Rows.Add(Row);
            }
        }
    }
}


