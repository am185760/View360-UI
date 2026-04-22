using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
 using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class DailyFeedSchedule
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public DailyFeedSchedule() { }
        public DailyFeedSchedule(long daily_feed_schedule_id, DateTime date_from, DateTime date_to, long created_by, DateTime creation_time, bool is_executed, string mcn, int retry_count)
        {
            this.date_from = date_from;
            this.date_fromChanged = true;
            this.date_to = date_to;
            this.date_toChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.is_executed = is_executed;
            this.is_executedChanged = true;
            this.mcn = mcn;
            this.mcnChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
        }
        public DailyFeedSchedule(DateTime date_from, DateTime date_to, long created_by, DateTime creation_time, bool is_executed, string mcn, int retry_count, string failure_reason, long? atm_id, DateTime? schedule_date, bool? delete_current_data, bool? enable_dff_generation)
        {
            this.date_from = date_from;
            this.date_fromChanged = true;
            this.date_to = date_to;
            this.date_toChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.is_executed = is_executed;
            this.is_executedChanged = true;
            this.mcn = mcn;
            this.mcnChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.schedule_date = schedule_date;
            this.schedule_dateChanged = true;
            this.delete_current_data = delete_current_data;
            this.delete_current_dataChanged = true;
            this.enable_dff_generation = enable_dff_generation;
            this.enable_dff_generationChanged = true;
        }
        private DailyFeedSchedule(long daily_feed_schedule_id, DateTime date_from, DateTime date_to, long created_by, DateTime creation_time, bool is_executed, string mcn, int retry_count, string failure_reason, long? atm_id, DateTime? schedule_date, bool? delete_current_data, bool? enable_dff_generation)
        {
            this.daily_feed_schedule_id = daily_feed_schedule_id;
            this.daily_feed_schedule_idChanged = true;
            this.date_from = date_from;
            this.date_fromChanged = true;
            this.date_to = date_to;
            this.date_toChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.is_executed = is_executed;
            this.is_executedChanged = true;
            this.mcn = mcn;
            this.mcnChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.schedule_date = schedule_date;
            this.schedule_dateChanged = true;
            this.delete_current_data = delete_current_data;
            this.delete_current_dataChanged = true;
            this.enable_dff_generation = enable_dff_generation;
            this.enable_dff_generationChanged = true;
        }

        #region members and properties for columns

        #region DailyFeedScheduleId
        private bool daily_feed_schedule_idChanged = false;
        private long daily_feed_schedule_id;
        public long DailyFeedScheduleId
        {
            get { return daily_feed_schedule_id; }
            set
            {
                daily_feed_schedule_id = value;
                daily_feed_schedule_idChanged = true;
            }
        }
        private string daily_feed_schedule_idDbString
        {
            get
            {
                return daily_feed_schedule_id.ToString();
            }
        }
        #endregion
        #region DateFrom
        private bool date_fromChanged = false;
        private DateTime date_from;
        public DateTime DateFrom
        {
            get { return date_from; }
            set
            {
                date_from = value;
                date_fromChanged = true;
            }
        }
        private string date_fromDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", date_from.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region DateTo
        private bool date_toChanged = false;
        private DateTime date_to;
        public DateTime DateTo
        {
            get { return date_to; }
            set
            {
                date_to = value;
                date_toChanged = true;
            }
        }
        private string date_toDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", date_to.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private long created_by;
        public long CreatedBy
        {
            get { return created_by; }
            set
            {
                created_by = value;
                created_byChanged = true;
            }
        }
        private string created_byDbString
        {
            get
            {
                return created_by.ToString();
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
        #region IsExecuted
        private bool is_executedChanged = false;
        private bool is_executed;
        public bool IsExecuted
        {
            get { return is_executed; }
            set
            {
                is_executed = value;
                is_executedChanged = true;
            }
        }
        private string is_executedDbString
        {
            get
            {
                return is_executed ? "1" : "0";
            }
        }
        #endregion
        #region Mcn
        private bool mcnChanged = false;
        private string mcn;
        public string Mcn
        {
            get { return mcn; }
            set
            {
                mcn = value;
                mcnChanged = true;
            }
        }
        private string mcnDbString
        {
            get
            {
                if (this.mcn != null)
                    return string.Format("'{0}'", mcn);
                else
                    return "null";
            }
        }
        #endregion
        #region RetryCount
        private bool retry_countChanged = false;
        private int retry_count;
        public int RetryCount
        {
            get { return retry_count; }
            set
            {
                retry_count = value;
                retry_countChanged = true;
            }
        }
        private string retry_countDbString
        {
            get
            {
                return retry_count.ToString();
            }
        }
        #endregion
        #region FailureReason
        private bool failure_reasonChanged = false;
        private string failure_reason;
        public string FailureReason
        {
            get { return failure_reason; }
            set
            {
                failure_reason = value;
                failure_reasonChanged = true;
            }
        }
        private string failure_reasonDbString
        {
            get
            {
                if (this.failure_reason != null)
                    return string.Format("'{0}'", failure_reason);
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
        #region ScheduleDate
        private bool schedule_dateChanged = false;
        private DateTime? schedule_date;
        public DateTime? ScheduleDate
        {
            get { return schedule_date; }
            set
            {
                schedule_date = value;
                schedule_dateChanged = true;
            }
        }
        private string schedule_dateDbString
        {
            get
            {
                if (this.schedule_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", schedule_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region DeleteCurrentData
        private bool delete_current_dataChanged = false;
        private bool? delete_current_data;
        public bool? DeleteCurrentData
        {
            get { return delete_current_data; }
            set
            {
                delete_current_data = value;
                delete_current_dataChanged = true;
            }
        }
        private string delete_current_dataDbString
        {
            get
            {
                if (this.delete_current_data.HasValue)
                    return delete_current_data.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region EnableDffGeneration
        private bool enable_dff_generationChanged = false;
        private bool? enable_dff_generation;
        public bool? EnableDffGeneration
        {
            get { return enable_dff_generation; }
            set
            {
                enable_dff_generation = value;
                enable_dff_generationChanged = true;
            }
        }
        private string enable_dff_generationDbString
        {
            get
            {
                if (this.enable_dff_generation.HasValue)
                    return enable_dff_generation.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region DailyFeedScheduleReader
        public class DailyFeedScheduleReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            DailyFeedSchedule currentDailyFeedSchedule;
            Columns columns;
            bool partialRead = false;
            private DailyFeedScheduleReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public DailyFeedScheduleReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public DailyFeedScheduleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentDailyFeedSchedule; }

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
                    currentDailyFeedSchedule = new DailyFeedSchedule();
                    if (partialRead)
                    {
                        if ((columns & Columns.daily_feed_schedule_id) == Columns.daily_feed_schedule_id && reader["daily_feed_schedule_id"] != DBNull.Value)
                            currentDailyFeedSchedule.daily_feed_schedule_id = (long)reader["daily_feed_schedule_id"];
                        if ((columns & Columns.date_from) == Columns.date_from && reader["date_from"] != DBNull.Value)
                            currentDailyFeedSchedule.date_from = (DateTime)reader["date_from"];
                        if ((columns & Columns.date_to) == Columns.date_to && reader["date_to"] != DBNull.Value)
                            currentDailyFeedSchedule.date_to = (DateTime)reader["date_to"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentDailyFeedSchedule.created_by = (long)reader["created_by"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentDailyFeedSchedule.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.is_executed) == Columns.is_executed && reader["is_executed"] != DBNull.Value)
                            currentDailyFeedSchedule.is_executed = (bool)reader["is_executed"];
                        if ((columns & Columns.mcn) == Columns.mcn && reader["mcn"] != DBNull.Value)
                            currentDailyFeedSchedule.mcn = (string)reader["mcn"];
                        if ((columns & Columns.retry_count) == Columns.retry_count && reader["retry_count"] != DBNull.Value)
                            currentDailyFeedSchedule.retry_count = (int)reader["retry_count"];
                        if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"] != DBNull.Value)
                            currentDailyFeedSchedule.failure_reason = (string)reader["failure_reason"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentDailyFeedSchedule.atm_id = (long?)reader["atm_id"];
                        if ((columns & Columns.schedule_date) == Columns.schedule_date && reader["schedule_date"] != DBNull.Value)
                            currentDailyFeedSchedule.schedule_date = (DateTime?)reader["schedule_date"];
                        if ((columns & Columns.delete_current_data) == Columns.delete_current_data && reader["delete_current_data"] != DBNull.Value)
                            currentDailyFeedSchedule.delete_current_data = (bool?)reader["delete_current_data"];
                        if ((columns & Columns.enable_dff_generation) == Columns.enable_dff_generation && reader["enable_dff_generation"] != DBNull.Value)
                            currentDailyFeedSchedule.enable_dff_generation = (bool?)reader["enable_dff_generation"];

                    }
                    else
                    {
                        if (reader["daily_feed_schedule_id"] != DBNull.Value)
                            currentDailyFeedSchedule.daily_feed_schedule_id = (long)reader["daily_feed_schedule_id"];
                        if (reader["date_from"] != DBNull.Value)
                            currentDailyFeedSchedule.date_from = (DateTime)reader["date_from"];
                        if (reader["date_to"] != DBNull.Value)
                            currentDailyFeedSchedule.date_to = (DateTime)reader["date_to"];
                        if (reader["created_by"] != DBNull.Value)
                            currentDailyFeedSchedule.created_by = (long)reader["created_by"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentDailyFeedSchedule.creation_time = (DateTime)reader["creation_time"];
                        if (reader["is_executed"] != DBNull.Value)
                            currentDailyFeedSchedule.is_executed = (bool)reader["is_executed"];
                        if (reader["mcn"] != DBNull.Value)
                            currentDailyFeedSchedule.mcn = (string)reader["mcn"];
                        if (reader["retry_count"] != DBNull.Value)
                            currentDailyFeedSchedule.retry_count = (int)reader["retry_count"];
                        if (reader["failure_reason"] != DBNull.Value)
                            currentDailyFeedSchedule.failure_reason = (string)reader["failure_reason"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentDailyFeedSchedule.atm_id = (long?)reader["atm_id"];
                        if (reader["schedule_date"] != DBNull.Value)
                            currentDailyFeedSchedule.schedule_date = (DateTime?)reader["schedule_date"];
                        if (reader["delete_current_data"] != DBNull.Value)
                            currentDailyFeedSchedule.delete_current_data = (bool?)reader["delete_current_data"];
                        if (reader["enable_dff_generation"] != DBNull.Value)
                            currentDailyFeedSchedule.enable_dff_generation = (bool?)reader["enable_dff_generation"];
                    }

                    currentDailyFeedSchedule.isNewEntity = false;
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

            public DailyFeedSchedule CurrentDailyFeedSchedule
            {
                get { return currentDailyFeedSchedule; }
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


        #region DailyFeedSchedule functions

        public static DailyFeedScheduleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.daily_feed_schedule_id == (Columns.daily_feed_schedule_id & columns))
                qry.Append("daily_feed_schedule_id,");
            if (Columns.date_from == (Columns.date_from & columns))
                qry.Append("date_from,");
            if (Columns.date_to == (Columns.date_to & columns))
                qry.Append("date_to,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.is_executed == (Columns.is_executed & columns))
                qry.Append("is_executed,");
            if (Columns.mcn == (Columns.mcn & columns))
                qry.Append("mcn,");
            if (Columns.retry_count == (Columns.retry_count & columns))
                qry.Append("retry_count,");
            if (Columns.failure_reason == (Columns.failure_reason & columns))
                qry.Append("failure_reason,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.schedule_date == (Columns.schedule_date & columns))
                qry.Append("schedule_date,");
            if (Columns.delete_current_data == (Columns.delete_current_data & columns))
                qry.Append("delete_current_data,");
            if (Columns.enable_dff_generation == (Columns.enable_dff_generation & columns))
                qry.Append("enable_dff_generation,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Daily_feed_schedule ");

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
            return new DailyFeedScheduleReader(cmd.ExecuteReader(), conn, columns);
        }

        static public DailyFeedScheduleReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static DailyFeedScheduleReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select daily_feed_schedule_id,date_from,date_to,created_by,creation_time,is_executed,mcn,retry_count,failure_reason,atm_id,schedule_date,delete_current_data,enable_dff_generation from Daily_feed_schedule ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new DailyFeedScheduleReader(cmd.ExecuteReader(), conn);
        }

        static public DailyFeedScheduleReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static DailyFeedSchedule LoadDailyFeedSchedule(string where)
        {
            DailyFeedScheduleReader reader = DailyFeedSchedule.ExecuteReader(where);
            DailyFeedSchedule _dailyfeedschedule = null;
            if (reader.Read())
                _dailyfeedschedule = reader.CurrentDailyFeedSchedule;
            reader.Close();
            return _dailyfeedschedule;
        }

        public static DailyFeedSchedule LoadDailyFeedSchedule(string where, IDbConnection conn)
        {
            DailyFeedScheduleReader reader = DailyFeedSchedule.ExecuteReader(where, conn);
            DailyFeedSchedule _dailyfeedschedule = null;
            if (reader.Read())
                _dailyfeedschedule = reader.CurrentDailyFeedSchedule;
            reader.Close(false);
            return _dailyfeedschedule;
        }

        public static DailyFeedSchedule LoadDailyFeedScheduleByPk(long daily_feed_schedule_id)
        {
            return LoadDailyFeedSchedule("daily_feed_schedule_id=" + daily_feed_schedule_id);
        }

        public static DailyFeedSchedule LoadDailyFeedScheduleByPk(long daily_feed_schedule_id, IDbConnection conn)
        {
            return LoadDailyFeedSchedule(" daily_feed_schedule_id=" + daily_feed_schedule_id, conn);
        }

        public void Save()
        {
            if (daily_feed_schedule_idChanged || date_fromChanged || date_toChanged || created_byChanged || creation_timeChanged || is_executedChanged || mcnChanged || retry_countChanged || failure_reasonChanged || atm_idChanged || schedule_dateChanged || delete_current_dataChanged || enable_dff_generationChanged)
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
            if (daily_feed_schedule_idChanged || date_fromChanged || date_toChanged || created_byChanged || creation_timeChanged || is_executedChanged || mcnChanged || retry_countChanged || failure_reasonChanged || atm_idChanged || schedule_dateChanged || delete_current_dataChanged || enable_dff_generationChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Daily_feed_schedule(daily_feed_schedule_id,date_from,date_to,created_by,creation_time,is_executed,mcn,retry_count,failure_reason,atm_id,schedule_date,delete_current_data,enable_dff_generation) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.daily_feed_schedule_id = ConnectionFactory.GetNextId(DatabaseName.Core);
                        qry.Append(this.daily_feed_schedule_id);
                    }
                    qry.Append(",");
                    qry.Append(date_fromDbString + ",");
                    qry.Append(date_toDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(is_executedDbString + ",");
                    qry.Append(mcnDbString + ",");
                    qry.Append(retry_countDbString + ",");
                    qry.Append(failure_reasonDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(schedule_dateDbString + ",");
                    qry.Append(delete_current_dataDbString + ",");
                    qry.Append(enable_dff_generationDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(daily_feed_schedule_idChanged || date_fromChanged || date_toChanged || created_byChanged || creation_timeChanged || is_executedChanged || mcnChanged || retry_countChanged || failure_reasonChanged || atm_idChanged || schedule_dateChanged || delete_current_dataChanged || enable_dff_generationChanged))
                        return;
                    qry.Append("UPDATE Daily_feed_schedule set "); if (date_fromChanged)
                    {
                        qry.Append("date_from =" + date_fromDbString);
                        qry.Append(",");
                    }

                    if (date_toChanged)
                    {
                        qry.Append("date_to =" + date_toDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }

                    if (is_executedChanged)
                    {
                        qry.Append("is_executed =" + is_executedDbString);
                        qry.Append(",");
                    }

                    if (mcnChanged)
                    {
                        qry.Append("mcn =" + mcnDbString);
                        qry.Append(",");
                    }

                    if (retry_countChanged)
                    {
                        qry.Append("retry_count =" + retry_countDbString);
                        qry.Append(",");
                    }

                    if (failure_reasonChanged)
                    {
                        qry.Append("failure_reason =" + failure_reasonDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (schedule_dateChanged)
                    {
                        qry.Append("schedule_date =" + schedule_dateDbString);
                        qry.Append(",");
                    }

                    if (delete_current_dataChanged)
                    {
                        qry.Append("delete_current_data =" + delete_current_dataDbString);
                        qry.Append(",");
                    }

                    if (enable_dff_generationChanged)
                    {
                        qry.Append("enable_dff_generation =" + enable_dff_generationDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("daily_feed_schedule_id = " + daily_feed_schedule_idDbString);
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
            cmd.CommandText = "DELETE Daily_feed_schedule wheredaily_feed_schedule_id= " + daily_feed_schedule_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteDailyFeedSchedules(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Daily_feed_schedule where " + where,DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            daily_feed_schedule_id = 0,
            date_from = 1,
            date_to = 2,
            created_by = 3,
            creation_time = 4,
            is_executed = 5,
            mcn = 6,
            retry_count = 7,
            failure_reason = 8,
            atm_id = 9,
            schedule_date = 10,
            delete_current_data = 11,
            enable_dff_generation = 12
        }
        #endregion
        public DataTable BulkSave(List<DailyFeedSchedule> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Daily_feed_schedule";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(DailyFeedSchedule.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<DailyFeedSchedule> transList, ref DataTable dt)
        {
            foreach (DailyFeedSchedule tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["daily_feed_schedule_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                Row["date_from"] = tran.DateFrom;
                Row["date_to"] = tran.DateTo;
                Row["created_by"] = tran.CreatedBy;
                Row["creation_time"] = tran.CreationTime;
                Row["is_executed"] = tran.IsExecuted;
                Row["mcn"] = tran.Mcn;
                Row["retry_count"] = tran.RetryCount;
                Row["failure_reason"] = tran.FailureReason;
                Row["atm_id"] = tran.AtmId;
                Row["schedule_date"] = tran.ScheduleDate;
                Row["delete_current_data"] = tran.DeleteCurrentData;
                Row["enable_dff_generation"] = tran.EnableDffGeneration;
                dt.Rows.Add(Row);
            }
        }
    }
}
