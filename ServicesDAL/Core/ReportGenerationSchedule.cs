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
    public class ReportGenerationSchedule
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ReportGenerationSchedule() { }
        public ReportGenerationSchedule(DateTime next_generation_at, long report_schedule_id)
        {
            this.next_generation_at = next_generation_at;
            this.next_generation_atChanged = true;
            this.report_schedule_id = report_schedule_id;
            this.report_schedule_idChanged = true;
        }
        private ReportGenerationSchedule(long report_generation_schedule_id, DateTime next_generation_at, long report_schedule_id)
        {
            this.report_generation_schedule_id = report_generation_schedule_id;
            this.report_generation_schedule_idChanged = true;
            this.next_generation_at = next_generation_at;
            this.next_generation_atChanged = true;
            this.report_schedule_id = report_schedule_id;
            this.report_schedule_idChanged = true;
        }

        #region members and properties for columns

        #region ReportGenerationScheduleId
        private bool report_generation_schedule_idChanged = false;
        private long report_generation_schedule_id;
        public long ReportGenerationScheduleId
        {
            get { return report_generation_schedule_id; }
            set
            {
                report_generation_schedule_id = value;
                report_generation_schedule_idChanged = true;
            }
        }
        private string report_generation_schedule_idDbString
        {
            get
            {
                return report_generation_schedule_id.ToString();
            }
        }
        #endregion
        #region NextGenerationAt
        private bool next_generation_atChanged = false;
        private DateTime next_generation_at;
        public DateTime NextGenerationAt
        {
            get { return next_generation_at; }
            set
            {
                next_generation_at = value;
                next_generation_atChanged = true;
            }
        }
        private string next_generation_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", next_generation_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region ReportScheduleId
        private bool report_schedule_idChanged = false;
        private long report_schedule_id;
        public long ReportScheduleId
        {
            get { return report_schedule_id; }
            set
            {
                report_schedule_id = value;
                report_schedule_idChanged = true;
            }
        }
        private string report_schedule_idDbString
        {
            get
            {
                return report_schedule_id.ToString();
            }
        }
        #endregion
        #endregion

        #region ReportGenerationScheduleReader
        public class ReportGenerationScheduleReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ReportGenerationSchedule currentReportGenerationSchedule;
            Columns columns;
            bool partialRead = false;
            private ReportGenerationScheduleReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ReportGenerationScheduleReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ReportGenerationScheduleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentReportGenerationSchedule; }

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
                    currentReportGenerationSchedule = new ReportGenerationSchedule();
                    if (partialRead)
                    {
                        if ((columns & Columns.report_generation_schedule_id) == Columns.report_generation_schedule_id && reader["report_generation_schedule_id"] != DBNull.Value)
                            currentReportGenerationSchedule.report_generation_schedule_id = (long)reader["report_generation_schedule_id"];
                        if ((columns & Columns.next_generation_at) == Columns.next_generation_at && reader["next_generation_at"] != DBNull.Value)
                            currentReportGenerationSchedule.next_generation_at = (DateTime)reader["next_generation_at"];
                        if ((columns & Columns.report_schedule_id) == Columns.report_schedule_id && reader["report_schedule_id"] != DBNull.Value)
                            currentReportGenerationSchedule.report_schedule_id = (long)reader["report_schedule_id"];

                    }
                    else
                    {
                        if (reader["report_generation_schedule_id"] != DBNull.Value)
                            currentReportGenerationSchedule.report_generation_schedule_id = (long)reader["report_generation_schedule_id"];
                        if (reader["next_generation_at"] != DBNull.Value)
                            currentReportGenerationSchedule.next_generation_at = (DateTime)reader["next_generation_at"];
                        if (reader["report_schedule_id"] != DBNull.Value)
                            currentReportGenerationSchedule.report_schedule_id = (long)reader["report_schedule_id"];
                    }

                    currentReportGenerationSchedule.isNewEntity = false;
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

            public ReportGenerationSchedule CurrentReportGenerationSchedule
            {
                get { return currentReportGenerationSchedule; }
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


        #region ReportGenerationSchedule functions

        public static ReportGenerationScheduleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.report_generation_schedule_id == (Columns.report_generation_schedule_id & columns))
                qry.Append("report_generation_schedule_id,");
            if (Columns.next_generation_at == (Columns.next_generation_at & columns))
                qry.Append("next_generation_at,");
            if (Columns.report_schedule_id == (Columns.report_schedule_id & columns))
                qry.Append("report_schedule_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Report_generation_schedule ");

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
            return new ReportGenerationScheduleReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ReportGenerationScheduleReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ReportGenerationScheduleReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select report_generation_schedule_id,next_generation_at,report_schedule_id from Report_generation_schedule ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ReportGenerationScheduleReader(cmd.ExecuteReader(), conn);
        }

        static public ReportGenerationScheduleReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static ReportGenerationSchedule LoadReportGenerationSchedule(string where)
        {
            ReportGenerationScheduleReader reader = ReportGenerationSchedule.ExecuteReader(where);
            ReportGenerationSchedule _reportgenerationschedule = null;
            if (reader.Read())
                _reportgenerationschedule = reader.CurrentReportGenerationSchedule;
            reader.Close();
            return _reportgenerationschedule;
        }

        public static ReportGenerationSchedule LoadReportGenerationSchedule(string where, IDbConnection conn)
        {
            ReportGenerationScheduleReader reader = ReportGenerationSchedule.ExecuteReader(where, conn);
            ReportGenerationSchedule _reportgenerationschedule = null;
            if (reader.Read())
                _reportgenerationschedule = reader.CurrentReportGenerationSchedule;
            reader.Close(false);
            return _reportgenerationschedule;
        }

        public static ReportGenerationSchedule LoadReportGenerationScheduleByPk(long report_generation_schedule_id)
        {
            return LoadReportGenerationSchedule("report_generation_schedule_id=" + report_generation_schedule_id);
        }

        public static ReportGenerationSchedule LoadReportGenerationScheduleByPk(long report_generation_schedule_id, IDbConnection conn)
        {
            return LoadReportGenerationSchedule(" report_generation_schedule_id=" + report_generation_schedule_id, conn);
        }

        public void Save()
        {
            if (report_generation_schedule_idChanged || next_generation_atChanged || report_schedule_idChanged)
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
            if (report_generation_schedule_idChanged || next_generation_atChanged || report_schedule_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Report_generation_schedule(report_generation_schedule_id,next_generation_at,report_schedule_id) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.report_generation_schedule_id = ConnectionFactory.GetNextId(DatabaseName.Core);
                        qry.Append(this.report_generation_schedule_id);
                    }
                    qry.Append(",");
                    qry.Append(next_generation_atDbString + ",");
                    qry.Append(report_schedule_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(report_generation_schedule_idChanged || next_generation_atChanged || report_schedule_idChanged))
                        return;
                    qry.Append("UPDATE Report_generation_schedule set "); if (next_generation_atChanged)
                    {
                        qry.Append("next_generation_at =" + next_generation_atDbString);
                        qry.Append(",");
                    }

                    if (report_schedule_idChanged)
                    {
                        qry.Append("report_schedule_id =" + report_schedule_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("report_generation_schedule_id = " + report_generation_schedule_idDbString);
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
            cmd.CommandText = "DELETE Report_generation_schedule wherereport_generation_schedule_id= " + report_generation_schedule_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteReportGenerationSchedules(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Report_generation_schedule where " + where,DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            report_generation_schedule_id = 0,
            next_generation_at = 1,
            report_schedule_id = 2
        }
        #endregion
        public DataTable BulkSave(List<ReportGenerationSchedule> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Report_generation_schedule";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ReportGenerationSchedule.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ReportGenerationSchedule> transList, ref DataTable dt)
        {
            foreach (ReportGenerationSchedule tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["report_generation_schedule_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                Row["next_generation_at"] = tran.NextGenerationAt;
                Row["report_schedule_id"] = tran.ReportScheduleId;
                dt.Rows.Add(Row);
            }
        }
    }
}