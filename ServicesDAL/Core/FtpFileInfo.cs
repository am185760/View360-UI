using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class FtpFileInfo
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public FtpFileInfo() { }
        public FtpFileInfo(long ftp_file_info_id, DateTime creation_time, string status, long task_type_id, int retry_count, string ftp_filename, long region_id)
        {
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.task_type_id = task_type_id;
            this.task_type_idChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.ftp_filename = ftp_filename;
            this.ftp_filenameChanged = true;
            this.region_id = region_id;
            this.region_idChanged = true;
        }
        public FtpFileInfo(DateTime creation_time, DateTime? end_time, string status, long task_type_id, int retry_count, string failure_reason, string ftp_filename, long region_id, DateTime? last_invoked_at)
        {
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.task_type_id = task_type_id;
            this.task_type_idChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.ftp_filename = ftp_filename;
            this.ftp_filenameChanged = true;
            this.region_id = region_id;
            this.region_idChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
        }
        private FtpFileInfo(long ftp_file_info_id, DateTime creation_time, DateTime? end_time, string status, long task_type_id, int retry_count, string failure_reason, string ftp_filename, long region_id, DateTime? last_invoked_at)
        {
            this.ftp_file_info_id = ftp_file_info_id;
            this.ftp_file_info_idChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.end_time = end_time;
            this.end_timeChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.task_type_id = task_type_id;
            this.task_type_idChanged = true;
            this.retry_count = retry_count;
            this.retry_countChanged = true;
            this.failure_reason = failure_reason;
            this.failure_reasonChanged = true;
            this.ftp_filename = ftp_filename;
            this.ftp_filenameChanged = true;
            this.region_id = region_id;
            this.region_idChanged = true;
            this.last_invoked_at = last_invoked_at;
            this.last_invoked_atChanged = true;
        }

        #region members and properties for columns

        #region FtpFileInfoId
        private bool ftp_file_info_idChanged = false;
        private long ftp_file_info_id;
        public long FtpFileInfoId
        {
            get { return ftp_file_info_id; }
            set
            {
                ftp_file_info_id = value;
                ftp_file_info_idChanged = true;
            }
        }
        private string ftp_file_info_idDbString
        {
            get
            {
                return ftp_file_info_id.ToString();
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
        #region EndTime
        private bool end_timeChanged = false;
        private DateTime? end_time;
        public DateTime? EndTime
        {
            get { return end_time; }
            set
            {
                end_time = value;
                end_timeChanged = true;
            }
        }
        private string end_timeDbString
        {
            get
            {
                if (this.end_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", end_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Status
        private bool statusChanged = false;
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                statusChanged = true;
            }
        }
        private string statusDbString
        {
            get
            {
                if (this.status != null)
                    return string.Format("'{0}'", status);
                else
                    return "null";
            }
        }
        #endregion
        #region TaskTypeId
        private bool task_type_idChanged = false;
        private long task_type_id;
        public long TaskTypeId
        {
            get { return task_type_id; }
            set
            {
                task_type_id = value;
                task_type_idChanged = true;
            }
        }
        private string task_type_idDbString
        {
            get
            {
                return task_type_id.ToString();
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
        #region FtpFilename
        private bool ftp_filenameChanged = false;
        private string ftp_filename;
        public string FtpFilename
        {
            get { return ftp_filename; }
            set
            {
                ftp_filename = value;
                ftp_filenameChanged = true;
            }
        }
        private string ftp_filenameDbString
        {
            get
            {
                if (this.ftp_filename != null)
                    return string.Format("'{0}'", ftp_filename);
                else
                    return "null";
            }
        }
        #endregion
        #region RegionId
        private bool region_idChanged = false;
        private long region_id;
        public long RegionId
        {
            get { return region_id; }
            set
            {
                region_id = value;
                region_idChanged = true;
            }
        }
        private string region_idDbString
        {
            get
            {
                return region_id.ToString();
            }
        }
        #endregion
        #region LastInvokedAt
        private bool last_invoked_atChanged = false;
        private DateTime? last_invoked_at;
        public DateTime? LastInvokedAt
        {
            get { return last_invoked_at; }
            set
            {
                last_invoked_at = value;
                last_invoked_atChanged = true;
            }
        }
        private string last_invoked_atDbString
        {
            get
            {
                if (this.last_invoked_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_invoked_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region FtpFileInfoReader
        public class FtpFileInfoReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            FtpFileInfo currentFtpFileInfo;
            Columns columns;
            bool partialRead = false;
            private FtpFileInfoReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public FtpFileInfoReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public FtpFileInfoReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentFtpFileInfo; }

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
                    currentFtpFileInfo = new FtpFileInfo();
                    if (partialRead)
                    {
                        if ((columns & Columns.ftp_file_info_id) == Columns.ftp_file_info_id && reader["ftp_file_info_id"] != DBNull.Value)
                            currentFtpFileInfo.ftp_file_info_id = (long)reader["ftp_file_info_id"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentFtpFileInfo.creation_time = (DateTime)reader["creation_time"];
                        if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"] != DBNull.Value)
                            currentFtpFileInfo.end_time = (DateTime?)reader["end_time"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentFtpFileInfo.status = (string)reader["status"];
                        if ((columns & Columns.task_type_id) == Columns.task_type_id && reader["task_type_id"] != DBNull.Value)
                            currentFtpFileInfo.task_type_id = (long)reader["task_type_id"];
                        if ((columns & Columns.retry_count) == Columns.retry_count && reader["retry_count"] != DBNull.Value)
                            currentFtpFileInfo.retry_count = (int)reader["retry_count"];
                        if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"] != DBNull.Value)
                            currentFtpFileInfo.failure_reason = (string)reader["failure_reason"];
                        if ((columns & Columns.ftp_filename) == Columns.ftp_filename && reader["ftp_filename"] != DBNull.Value)
                            currentFtpFileInfo.ftp_filename = (string)reader["ftp_filename"];
                        if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"] != DBNull.Value)
                            currentFtpFileInfo.region_id = (long)reader["region_id"];
                        if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"] != DBNull.Value)
                            currentFtpFileInfo.last_invoked_at = (DateTime?)reader["last_invoked_at"];

                    }
                    else
                    {
                        if (reader["ftp_file_info_id"] != DBNull.Value)
                            currentFtpFileInfo.ftp_file_info_id = (long)reader["ftp_file_info_id"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentFtpFileInfo.creation_time = (DateTime)reader["creation_time"];
                        if (reader["end_time"] != DBNull.Value)
                            currentFtpFileInfo.end_time = (DateTime?)reader["end_time"];
                        if (reader["status"] != DBNull.Value)
                            currentFtpFileInfo.status = (string)reader["status"];
                        if (reader["task_type_id"] != DBNull.Value)
                            currentFtpFileInfo.task_type_id = (long)reader["task_type_id"];
                        if (reader["retry_count"] != DBNull.Value)
                            currentFtpFileInfo.retry_count = (int)reader["retry_count"];
                        if (reader["failure_reason"] != DBNull.Value)
                            currentFtpFileInfo.failure_reason = (string)reader["failure_reason"];
                        if (reader["ftp_filename"] != DBNull.Value)
                            currentFtpFileInfo.ftp_filename = (string)reader["ftp_filename"];
                        if (reader["region_id"] != DBNull.Value)
                            currentFtpFileInfo.region_id = (long)reader["region_id"];
                        if (reader["last_invoked_at"] != DBNull.Value)
                            currentFtpFileInfo.last_invoked_at = (DateTime?)reader["last_invoked_at"];
                    }

                    currentFtpFileInfo.isNewEntity = false;
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

            public FtpFileInfo CurrentFtpFileInfo
            {
                get { return currentFtpFileInfo; }
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


        #region FtpFileInfo functions

        public static FtpFileInfoReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ftp_file_info_id == (Columns.ftp_file_info_id & columns))
                qry.Append("ftp_file_info_id,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.end_time == (Columns.end_time & columns))
                qry.Append("end_time,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.task_type_id == (Columns.task_type_id & columns))
                qry.Append("task_type_id,");
            if (Columns.retry_count == (Columns.retry_count & columns))
                qry.Append("retry_count,");
            if (Columns.failure_reason == (Columns.failure_reason & columns))
                qry.Append("failure_reason,");
            if (Columns.ftp_filename == (Columns.ftp_filename & columns))
                qry.Append("ftp_filename,");
            if (Columns.region_id == (Columns.region_id & columns))
                qry.Append("region_id,");
            if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
                qry.Append("last_invoked_at,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ftp_file_info ");

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
            return new FtpFileInfoReader(cmd.ExecuteReader(), conn, columns);
        }

        static public FtpFileInfoReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static FtpFileInfoReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select ftp_file_info_id,creation_time,end_time,status,task_type_id,retry_count,failure_reason,ftp_filename,region_id,last_invoked_at from Ftp_file_info ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new FtpFileInfoReader(cmd.ExecuteReader(), conn);
        }

        static public FtpFileInfoReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static FtpFileInfo LoadFtpFileInfo(string where)
        {
            FtpFileInfoReader reader = FtpFileInfo.ExecuteReader(where);
            FtpFileInfo _ftpfileinfo = null;
            if (reader.Read())
                _ftpfileinfo = reader.CurrentFtpFileInfo;
            reader.Close();
            return _ftpfileinfo;
        }

        public static FtpFileInfo LoadFtpFileInfo(string where, IDbConnection conn)
        {
            FtpFileInfoReader reader = FtpFileInfo.ExecuteReader(where, conn);
            FtpFileInfo _ftpfileinfo = null;
            if (reader.Read())
                _ftpfileinfo = reader.CurrentFtpFileInfo;
            reader.Close(false);
            return _ftpfileinfo;
        }

        public static FtpFileInfo LoadFtpFileInfoByPk(long ftp_file_info_id)
        {
            return LoadFtpFileInfo("ftp_file_info_id=" + ftp_file_info_id);
        }

        public static FtpFileInfo LoadFtpFileInfoByPk(long ftp_file_info_id, IDbConnection conn)
        {
            return LoadFtpFileInfo(" ftp_file_info_id=" + ftp_file_info_id, conn);
        }

        public void Save()
        {
            if (ftp_file_info_idChanged || creation_timeChanged || end_timeChanged || statusChanged || task_type_idChanged || retry_countChanged || failure_reasonChanged || ftp_filenameChanged || region_idChanged || last_invoked_atChanged)
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
            if (ftp_file_info_idChanged || creation_timeChanged || end_timeChanged || statusChanged || task_type_idChanged || retry_countChanged || failure_reasonChanged || ftp_filenameChanged || region_idChanged || last_invoked_atChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ftp_file_info(ftp_file_info_id,creation_time,end_time,status,task_type_id,retry_count,failure_reason,ftp_filename,region_id,last_invoked_at) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.ftp_file_info_id = ConnectionFactory.GetNextId(DatabaseName.Core);
                        qry.Append(this.ftp_file_info_id);
                    }
                    qry.Append(",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(end_timeDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(task_type_idDbString + ",");
                    qry.Append(retry_countDbString + ",");
                    qry.Append(failure_reasonDbString + ",");
                    qry.Append(ftp_filenameDbString + ",");
                    qry.Append(region_idDbString + ",");
                    qry.Append(last_invoked_atDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ftp_file_info_idChanged || creation_timeChanged || end_timeChanged || statusChanged || task_type_idChanged || retry_countChanged || failure_reasonChanged || ftp_filenameChanged || region_idChanged || last_invoked_atChanged))
                        return;
                    qry.Append("UPDATE Ftp_file_info set "); if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }

                    if (end_timeChanged)
                    {
                        qry.Append("end_time =" + end_timeDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (task_type_idChanged)
                    {
                        qry.Append("task_type_id =" + task_type_idDbString);
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

                    if (ftp_filenameChanged)
                    {
                        qry.Append("ftp_filename =" + ftp_filenameDbString);
                        qry.Append(",");
                    }

                    if (region_idChanged)
                    {
                        qry.Append("region_id =" + region_idDbString);
                        qry.Append(",");
                    }

                    if (last_invoked_atChanged)
                    {
                        qry.Append("last_invoked_at =" + last_invoked_atDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ftp_file_info_id = " + ftp_file_info_idDbString);
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
            cmd.CommandText = "DELETE Ftp_file_info whereftp_file_info_id= " + ftp_file_info_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteFtpFileInfos(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ftp_file_info where " + where,DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ftp_file_info_id = 0,
            creation_time = 1,
            end_time = 2,
            status = 3,
            task_type_id = 4,
            retry_count = 5,
            failure_reason = 6,
            ftp_filename = 7,
            region_id = 8,
            last_invoked_at = 9
        }
        #endregion
        public DataTable BulkSave(List<FtpFileInfo> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ftp_file_info";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(FtpFileInfo.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<FtpFileInfo> transList, ref DataTable dt)
        {
            foreach (FtpFileInfo tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ftp_file_info_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                Row["creation_time"] = tran.CreationTime;
                Row["end_time"] = tran.EndTime;
                Row["status"] = tran.Status;
                Row["task_type_id"] = tran.TaskTypeId;
                Row["retry_count"] = tran.RetryCount;
                Row["failure_reason"] = tran.FailureReason;
                Row["ftp_filename"] = tran.FtpFilename;
                Row["region_id"] = tran.RegionId;
                Row["last_invoked_at"] = tran.LastInvokedAt;
                dt.Rows.Add(Row);
            }
        }
    }
}
