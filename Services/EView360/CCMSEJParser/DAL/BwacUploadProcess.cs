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
    public class BwacUploadProcess
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public BwacUploadProcess() { }
        public BwacUploadProcess(int uploaded_by, DateTime upload_datetime, string upload_filename, DateTime print_date)
        {
            this.uploaded_by = uploaded_by;
            this.uploaded_byChanged = true;
            this.upload_datetime = upload_datetime;
            this.upload_datetimeChanged = true;
            this.upload_filename = upload_filename;
            this.upload_filenameChanged = true;
            this.print_date = print_date;
            this.print_dateChanged = true;
        }
        private BwacUploadProcess(int bwac_upload_process_id, int uploaded_by, DateTime upload_datetime, string upload_filename, DateTime print_date)
        {
            this.bwac_upload_process_id = bwac_upload_process_id;
            this.bwac_upload_process_idChanged = true;
            this.uploaded_by = uploaded_by;
            this.uploaded_byChanged = true;
            this.upload_datetime = upload_datetime;
            this.upload_datetimeChanged = true;
            this.upload_filename = upload_filename;
            this.upload_filenameChanged = true;
            this.print_date = print_date;
            this.print_dateChanged = true;
        }

        #region members and properties for columns

        #region BwacUploadProcessId
        private bool bwac_upload_process_idChanged = false;
        private int bwac_upload_process_id;
        public int BwacUploadProcessId
        {
            get { return bwac_upload_process_id; }
            set
            {
                bwac_upload_process_id = value;
                bwac_upload_process_idChanged = true;
            }
        }
        private string bwac_upload_process_idDbString
        {
            get
            {
                return bwac_upload_process_id.ToString();
            }
        }
        #endregion
        #region UploadedBy
        private bool uploaded_byChanged = false;
        private int uploaded_by;
        public int UploadedBy
        {
            get { return uploaded_by; }
            set
            {
                uploaded_by = value;
                uploaded_byChanged = true;
            }
        }
        private string uploaded_byDbString
        {
            get
            {
                return uploaded_by.ToString();
            }
        }
        #endregion
        #region UploadDatetime
        private bool upload_datetimeChanged = false;
        private DateTime upload_datetime;
        public DateTime UploadDatetime
        {
            get { return upload_datetime; }
            set
            {
                upload_datetime = value;
                upload_datetimeChanged = true;
            }
        }
        private string upload_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", upload_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region UploadFilename
        private bool upload_filenameChanged = false;
        private string upload_filename;
        public string UploadFilename
        {
            get { return upload_filename; }
            set
            {
                upload_filename = value;
                upload_filenameChanged = true;
            }
        }
        private string upload_filenameDbString
        {
            get
            {
                if (this.upload_filename != null)
                    return string.Format("'{0}'", upload_filename);
                else
                    return "null";
            }
        }
        #endregion
        #region PrintDate
        private bool print_dateChanged = false;
        private DateTime print_date;
        public DateTime PrintDate
        {
            get { return print_date; }
            set
            {
                print_date = value;
                print_dateChanged = true;
            }
        }
        private string print_dateDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", print_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #endregion

        #region BwacUploadProcessReader
        public class BwacUploadProcessReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            BwacUploadProcess currentBwacUploadProcess;
            Columns columns;
            bool partialRead = false;
            private BwacUploadProcessReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public BwacUploadProcessReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public BwacUploadProcessReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentBwacUploadProcess; }

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
                    currentBwacUploadProcess = new BwacUploadProcess();
                    if (partialRead)
                    {
                        if ((columns & Columns.bwac_upload_process_id) == Columns.bwac_upload_process_id && reader["bwac_upload_process_id"] != DBNull.Value)
                            currentBwacUploadProcess.bwac_upload_process_id = (int)reader["bwac_upload_process_id"];
                        if ((columns & Columns.uploaded_by) == Columns.uploaded_by && reader["uploaded_by"] != DBNull.Value)
                            currentBwacUploadProcess.uploaded_by = (int)reader["uploaded_by"];
                        if ((columns & Columns.upload_datetime) == Columns.upload_datetime && reader["upload_datetime"] != DBNull.Value)
                            currentBwacUploadProcess.upload_datetime = (DateTime)reader["upload_datetime"];
                        if ((columns & Columns.upload_filename) == Columns.upload_filename && reader["upload_filename"] != DBNull.Value)
                            currentBwacUploadProcess.upload_filename = (string)reader["upload_filename"];
                        if ((columns & Columns.print_date) == Columns.print_date && reader["print_date"] != DBNull.Value)
                            currentBwacUploadProcess.print_date = (DateTime)reader["print_date"];

                    }
                    else
                    {
                        if (reader["bwac_upload_process_id"] != DBNull.Value)
                            currentBwacUploadProcess.bwac_upload_process_id = (int)reader["bwac_upload_process_id"];
                        if (reader["uploaded_by"] != DBNull.Value)
                            currentBwacUploadProcess.uploaded_by = (int)reader["uploaded_by"];
                        if (reader["upload_datetime"] != DBNull.Value)
                            currentBwacUploadProcess.upload_datetime = (DateTime)reader["upload_datetime"];
                        if (reader["upload_filename"] != DBNull.Value)
                            currentBwacUploadProcess.upload_filename = (string)reader["upload_filename"];
                        if (reader["print_date"] != DBNull.Value)
                            currentBwacUploadProcess.print_date = (DateTime)reader["print_date"];
                    }

                    currentBwacUploadProcess.isNewEntity = false;
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

            public BwacUploadProcess CurrentBwacUploadProcess
            {
                get { return currentBwacUploadProcess; }
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


        #region BwacUploadProcess functions

        public static BwacUploadProcessReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.bwac_upload_process_id == (Columns.bwac_upload_process_id & columns))
                qry.Append("bwac_upload_process_id,");
            if (Columns.uploaded_by == (Columns.uploaded_by & columns))
                qry.Append("uploaded_by,");
            if (Columns.upload_datetime == (Columns.upload_datetime & columns))
                qry.Append("upload_datetime,");
            if (Columns.upload_filename == (Columns.upload_filename & columns))
                qry.Append("upload_filename,");
            if (Columns.print_date == (Columns.print_date & columns))
                qry.Append("print_date,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Bwac_upload_process ");

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
            return new BwacUploadProcessReader(cmd.ExecuteReader(), conn, columns);
        }

        static public BwacUploadProcessReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static BwacUploadProcessReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select bwac_upload_process_id,uploaded_by,upload_datetime,upload_filename,print_date from Bwac_upload_process ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new BwacUploadProcessReader(cmd.ExecuteReader(), conn);
        }

        static public BwacUploadProcessReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static BwacUploadProcess LoadBwacUploadProcess(string where)
        {
            BwacUploadProcessReader reader = BwacUploadProcess.ExecuteReader(where);
            BwacUploadProcess _bwacuploadprocess = null;
            if (reader.Read())
                _bwacuploadprocess = reader.CurrentBwacUploadProcess;
            reader.Close();
            return _bwacuploadprocess;
        }

        public static BwacUploadProcess LoadBwacUploadProcess(string where, IDbConnection conn)
        {
            BwacUploadProcessReader reader = BwacUploadProcess.ExecuteReader(where, conn);
            BwacUploadProcess _bwacuploadprocess = null;
            if (reader.Read())
                _bwacuploadprocess = reader.CurrentBwacUploadProcess;
            reader.Close(false);
            return _bwacuploadprocess;
        }

        public static BwacUploadProcess LoadBwacUploadProcessByPk(int bwac_upload_process_id)
        {
            return LoadBwacUploadProcess(" bwac_upload_process_id=" + bwac_upload_process_id);
        }

        public static BwacUploadProcess LoadBwacUploadProcessByPk(int bwac_upload_process_id, IDbConnection conn)
        {
            return LoadBwacUploadProcess(" bwac_upload_process_id=" + bwac_upload_process_id, conn);
        }

        public void Save()
        {
            if (bwac_upload_process_idChanged || uploaded_byChanged || upload_datetimeChanged || upload_filenameChanged || print_dateChanged)
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
            if (bwac_upload_process_idChanged || uploaded_byChanged || upload_datetimeChanged || upload_filenameChanged || print_dateChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Bwac_upload_process( bwac_upload_process_id,uploaded_by,upload_datetime,upload_filename,print_date ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.bwac_upload_process_id = ConnectionFactory.GetNextId();
                        qry.Append(this.bwac_upload_process_id);
                    } qry.Append(",");
                    qry.Append(uploaded_byDbString + ",");
                    qry.Append(upload_datetimeDbString + ",");
                    qry.Append(upload_filenameDbString + ",");
                    qry.Append(print_dateDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(bwac_upload_process_idChanged || uploaded_byChanged || upload_datetimeChanged || upload_filenameChanged || print_dateChanged))
                        return;
                    qry.Append("UPDATE Bwac_upload_process set "); if (uploaded_byChanged)
                    {
                        qry.Append("uploaded_by =" + uploaded_byDbString);
                        qry.Append(",");
                    }

                    if (upload_datetimeChanged)
                    {
                        qry.Append("upload_datetime =" + upload_datetimeDbString);
                        qry.Append(",");
                    }

                    if (upload_filenameChanged)
                    {
                        qry.Append("upload_filename =" + upload_filenameDbString);
                        qry.Append(",");
                    }

                    if (print_dateChanged)
                    {
                        qry.Append("print_date =" + print_dateDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("bwac_upload_process_id = " + bwac_upload_process_idDbString);
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
            cmd.CommandText = "DELETE Bwac_upload_process where bwac_upload_process_id = " + bwac_upload_process_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteBwacUploadProcesss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Bwac_upload_process where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            bwac_upload_process_id = 1,
            uploaded_by = 2,
            upload_datetime = 4,
            upload_filename = 8,
            print_date = 16
        }
        #endregion
        public void BulkSave(List<BwacUploadProcess> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Bwac_upload_process";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(BwacUploadProcess.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<BwacUploadProcess> transList, ref DataTable dt)
        {
            foreach (BwacUploadProcess tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["bwac_upload_process_id"] = ConnectionFactory.GetNextId();
                Row["uploaded_by"] = tran.UploadedBy;
                Row["upload_datetime"] = tran.UploadDatetime;
                Row["upload_filename"] = tran.UploadFilename;
                Row["print_date"] = tran.PrintDate;
                dt.Rows.Add(Row);
            }
        }
    }
}


