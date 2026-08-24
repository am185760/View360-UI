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
    public class ScheduledDownloadsDetails
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ScheduledDownloadsDetails() { }
        public ScheduledDownloadsDetails(int scheduled_downloads_details_id, int scheduled_downloads_id)
        {
            this.scheduled_downloads_id = scheduled_downloads_id;
            this.scheduled_downloads_idChanged = true;
        }
        public ScheduledDownloadsDetails(int scheduled_downloads_id, DateTime? next_downloading_at)
        {
            this.scheduled_downloads_id = scheduled_downloads_id;
            this.scheduled_downloads_idChanged = true;
            this.next_downloading_at = next_downloading_at;
            this.next_downloading_atChanged = true;
        }
        private ScheduledDownloadsDetails(int scheduled_downloads_details_id, int scheduled_downloads_id, DateTime? next_downloading_at)
        {
            this.scheduled_downloads_details_id = scheduled_downloads_details_id;
            this.scheduled_downloads_details_idChanged = true;
            this.scheduled_downloads_id = scheduled_downloads_id;
            this.scheduled_downloads_idChanged = true;
            this.next_downloading_at = next_downloading_at;
            this.next_downloading_atChanged = true;
        }

        #region members and properties for columns

        #region ScheduledDownloadsDetailsId
        private bool scheduled_downloads_details_idChanged = false;
        private int scheduled_downloads_details_id;
        public int ScheduledDownloadsDetailsId
        {
            get { return scheduled_downloads_details_id; }
            set
            {
                scheduled_downloads_details_id = value;
                scheduled_downloads_details_idChanged = true;
            }
        }
        private string scheduled_downloads_details_idDbString
        {
            get
            {
                return scheduled_downloads_details_id.ToString();
            }
        }
        #endregion
        #region ScheduledDownloadsId
        private bool scheduled_downloads_idChanged = false;
        private int scheduled_downloads_id;
        public int ScheduledDownloadsId
        {
            get { return scheduled_downloads_id; }
            set
            {
                scheduled_downloads_id = value;
                scheduled_downloads_idChanged = true;
            }
        }
        private string scheduled_downloads_idDbString
        {
            get
            {
                return scheduled_downloads_id.ToString();
            }
        }
        #endregion
        #region NextDownloadingAt
        private bool next_downloading_atChanged = false;
        private DateTime? next_downloading_at;
        public DateTime? NextDownloadingAt
        {
            get { return next_downloading_at; }
            set
            {
                next_downloading_at = value;
                next_downloading_atChanged = true;
            }
        }
        private string next_downloading_atDbString
        {
            get
            {
                if (this.next_downloading_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", next_downloading_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region ScheduledDownloadsDetailsReader
        public class ScheduledDownloadsDetailsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ScheduledDownloadsDetails currentScheduledDownloadsDetails;
            Columns columns;
            bool partialRead = false;
            private ScheduledDownloadsDetailsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ScheduledDownloadsDetailsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ScheduledDownloadsDetailsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentScheduledDownloadsDetails; }

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
                    currentScheduledDownloadsDetails = new ScheduledDownloadsDetails();
                    if (partialRead)
                    {
                        if ((columns & Columns.scheduled_downloads_details_id) == Columns.scheduled_downloads_details_id && reader["scheduled_downloads_details_id"] != DBNull.Value)
                            currentScheduledDownloadsDetails.scheduled_downloads_details_id = (int)reader["scheduled_downloads_details_id"];
                        if ((columns & Columns.scheduled_downloads_id) == Columns.scheduled_downloads_id && reader["scheduled_downloads_id"] != DBNull.Value)
                            currentScheduledDownloadsDetails.scheduled_downloads_id = (int)reader["scheduled_downloads_id"];
                        if ((columns & Columns.next_downloading_at) == Columns.next_downloading_at && reader["next_downloading_at"] != DBNull.Value)
                            currentScheduledDownloadsDetails.next_downloading_at = (DateTime?)reader["next_downloading_at"];

                    }
                    else
                    {
                        if (reader["scheduled_downloads_details_id"] != DBNull.Value)
                            currentScheduledDownloadsDetails.scheduled_downloads_details_id = (int)reader["scheduled_downloads_details_id"];
                        if (reader["scheduled_downloads_id"] != DBNull.Value)
                            currentScheduledDownloadsDetails.scheduled_downloads_id = (int)reader["scheduled_downloads_id"];
                        if (reader["next_downloading_at"] != DBNull.Value)
                            currentScheduledDownloadsDetails.next_downloading_at = (DateTime?)reader["next_downloading_at"];
                    }

                    currentScheduledDownloadsDetails.isNewEntity = false;
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

            public ScheduledDownloadsDetails CurrentScheduledDownloadsDetails
            {
                get { return currentScheduledDownloadsDetails; }
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


        #region ScheduledDownloadsDetails functions

        public static ScheduledDownloadsDetailsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.scheduled_downloads_details_id == (Columns.scheduled_downloads_details_id & columns))
                qry.Append("scheduled_downloads_details_id,");
            if (Columns.scheduled_downloads_id == (Columns.scheduled_downloads_id & columns))
                qry.Append("scheduled_downloads_id,");
            if (Columns.next_downloading_at == (Columns.next_downloading_at & columns))
                qry.Append("next_downloading_at,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Scheduled_downloads_details ");

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
            return new ScheduledDownloadsDetailsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ScheduledDownloadsDetailsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ScheduledDownloadsDetailsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select scheduled_downloads_details_id,scheduled_downloads_id,next_downloading_at from Scheduled_downloads_details ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ScheduledDownloadsDetailsReader(cmd.ExecuteReader(), conn);
        }

        static public ScheduledDownloadsDetailsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static ScheduledDownloadsDetails LoadScheduledDownloadsDetails(string where)
        {
            ScheduledDownloadsDetailsReader reader = ScheduledDownloadsDetails.ExecuteReader(where);
            ScheduledDownloadsDetails _scheduleddownloadsdetails = null;
            if (reader.Read())
                _scheduleddownloadsdetails = reader.CurrentScheduledDownloadsDetails;
            reader.Close();
            return _scheduleddownloadsdetails;
        }

        public static ScheduledDownloadsDetails LoadScheduledDownloadsDetails(string where, IDbConnection conn)
        {
            ScheduledDownloadsDetailsReader reader = ScheduledDownloadsDetails.ExecuteReader(where, conn);
            ScheduledDownloadsDetails _scheduleddownloadsdetails = null;
            if (reader.Read())
                _scheduleddownloadsdetails = reader.CurrentScheduledDownloadsDetails;
            reader.Close(false);
            return _scheduleddownloadsdetails;
        }

        public static ScheduledDownloadsDetails LoadScheduledDownloadsDetailsByPk(int scheduled_downloads_details_id)
        {
            return LoadScheduledDownloadsDetails(" scheduled_downloads_details_id=" + scheduled_downloads_details_id);
        }

        public static ScheduledDownloadsDetails LoadScheduledDownloadsDetailsByPk(int scheduled_downloads_details_id, IDbConnection conn)
        {
            return LoadScheduledDownloadsDetails(" scheduled_downloads_details_id=" + scheduled_downloads_details_id, conn);
        }

        public void Save()
        {
            if (scheduled_downloads_details_idChanged || scheduled_downloads_idChanged || next_downloading_atChanged)
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
            if (scheduled_downloads_details_idChanged || scheduled_downloads_idChanged || next_downloading_atChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Scheduled_downloads_details( scheduled_downloads_details_id,scheduled_downloads_id,next_downloading_at ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.scheduled_downloads_details_id = ConnectionFactory.GetNextId();
                        qry.Append(this.scheduled_downloads_details_id);
                    } qry.Append(",");
                    qry.Append(scheduled_downloads_idDbString + ",");
                    qry.Append(next_downloading_atDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(scheduled_downloads_details_idChanged || scheduled_downloads_idChanged || next_downloading_atChanged))
                        return;
                    qry.Append("UPDATE Scheduled_downloads_details set "); if (scheduled_downloads_idChanged)
                    {
                        qry.Append("scheduled_downloads_id =" + scheduled_downloads_idDbString);
                        qry.Append(",");
                    }

                    if (next_downloading_atChanged)
                    {
                        qry.Append("next_downloading_at =" + next_downloading_atDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("scheduled_downloads_details_id = " + scheduled_downloads_details_idDbString);
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
            cmd.CommandText = "DELETE Scheduled_downloads_details where scheduled_downloads_details_id = " + scheduled_downloads_details_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteScheduledDownloadsDetailss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Scheduled_downloads_details where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            scheduled_downloads_details_id = 1,
            scheduled_downloads_id = 2,
            next_downloading_at = 4
        }
        #endregion
        public void BulkSave(List<ScheduledDownloadsDetails> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Scheduled_downloads_details";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ScheduledDownloadsDetails.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ScheduledDownloadsDetails> transList, ref DataTable dt)
        {
            foreach (ScheduledDownloadsDetails tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["scheduled_downloads_details_id"] = ConnectionFactory.GetNextId();
                Row["scheduled_downloads_id"] = tran.ScheduledDownloadsId;
                Row["next_downloading_at"] = tran.NextDownloadingAt;
                dt.Rows.Add(Row);
            }
        }
    }
}


