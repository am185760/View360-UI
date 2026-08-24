
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
    public class IncidentDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public IncidentDetail() { }
        public IncidentDetail(int incident_detail_id)
        {
        }
        public IncidentDetail(string token_name, string token_value, int? incident_id)
        {
            this.token_name = token_name;
            this.token_nameChanged = true;
            this.token_value = token_value;
            this.token_valueChanged = true;
            this.incident_id = incident_id;
            this.incident_idChanged = true;
        }
        private IncidentDetail(int incident_detail_id, string token_name, string token_value, int? incident_id)
        {
            this.incident_detail_id = incident_detail_id;
            this.incident_detail_idChanged = true;
            this.token_name = token_name;
            this.token_nameChanged = true;
            this.token_value = token_value;
            this.token_valueChanged = true;
            this.incident_id = incident_id;
            this.incident_idChanged = true;
        }

        #region members and properties for columns

        #region IncidentDetailId
        private bool incident_detail_idChanged = false;
        private int incident_detail_id;
        public int IncidentDetailId
        {
            get { return incident_detail_id; }
            set
            {
                incident_detail_id = value;
                incident_detail_idChanged = true;
            }
        }
        private string incident_detail_idDbString
        {
            get
            {
                return incident_detail_id.ToString();
            }
        }
        #endregion
        #region TokenName
        private bool token_nameChanged = false;
        private string token_name;
        public string TokenName
        {
            get { return token_name; }
            set
            {
                token_name = value;
                token_nameChanged = true;
            }
        }
        private string token_nameDbString
        {
            get
            {
                if (this.token_name != null)
                    return string.Format("'{0}'", token_name);
                else
                    return "null";
            }
        }
        #endregion
        #region TokenValue
        private bool token_valueChanged = false;
        private string token_value;
        public string TokenValue
        {
            get { return token_value; }
            set
            {
                token_value = value;
                token_valueChanged = true;
            }
        }
        private string token_valueDbString
        {
            get
            {
                if (this.token_value != null)
                    return string.Format("'{0}'", token_value);
                else
                    return "null";
            }
        }
        #endregion
        #region IncidentId
        private bool incident_idChanged = false;
        private int? incident_id;
        public int? IncidentId
        {
            get { return incident_id; }
            set
            {
                incident_id = value;
                incident_idChanged = true;
            }
        }
        private string incident_idDbString
        {
            get
            {
                if (this.incident_id.HasValue)
                    return incident_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region IncidentDetailReader
        public class IncidentDetailReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            IncidentDetail currentIncidentDetail;
            Columns columns;
            bool partialRead = false;
            private IncidentDetailReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public IncidentDetailReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public IncidentDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentIncidentDetail; }

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
                    currentIncidentDetail = new IncidentDetail();
                    if (partialRead)
                    {
                        if ((columns & Columns.incident_detail_id) == Columns.incident_detail_id && reader["incident_detail_id"] != DBNull.Value)
                            currentIncidentDetail.incident_detail_id = (int)reader["incident_detail_id"];
                        if ((columns & Columns.token_name) == Columns.token_name && reader["token_name"] != DBNull.Value)
                            currentIncidentDetail.token_name = (string)reader["token_name"];
                        if ((columns & Columns.token_value) == Columns.token_value && reader["token_value"] != DBNull.Value)
                            currentIncidentDetail.token_value = (string)reader["token_value"];
                        if ((columns & Columns.incident_id) == Columns.incident_id && reader["incident_id"] != DBNull.Value)
                            currentIncidentDetail.incident_id = (int?)reader["incident_id"];

                    }
                    else
                    {
                        if (reader["incident_detail_id"] != DBNull.Value)
                            currentIncidentDetail.incident_detail_id = (int)reader["incident_detail_id"];
                        if (reader["token_name"] != DBNull.Value)
                            currentIncidentDetail.token_name = (string)reader["token_name"];
                        if (reader["token_value"] != DBNull.Value)
                            currentIncidentDetail.token_value = (string)reader["token_value"];
                        if (reader["incident_id"] != DBNull.Value)
                            currentIncidentDetail.incident_id = (int?)reader["incident_id"];
                    }

                    currentIncidentDetail.isNewEntity = false;
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

            public IncidentDetail CurrentIncidentDetail
            {
                get { return currentIncidentDetail; }
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


        #region IncidentDetail functions

        public static IncidentDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.incident_detail_id == (Columns.incident_detail_id & columns))
                qry.Append("incident_detail_id,");
            if (Columns.token_name == (Columns.token_name & columns))
                qry.Append("token_name,");
            if (Columns.token_value == (Columns.token_value & columns))
                qry.Append("token_value,");
            if (Columns.incident_id == (Columns.incident_id & columns))
                qry.Append("incident_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Incident_detail ");

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
            return new IncidentDetailReader(cmd.ExecuteReader(), conn, columns);
        }

        static public IncidentDetailReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static IncidentDetailReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select incident_detail_id,token_name,token_value,incident_id from Incident_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new IncidentDetailReader(cmd.ExecuteReader(), conn);
        }

        static public IncidentDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static IncidentDetail LoadIncidentDetail(string where)
        {
            IncidentDetailReader reader = IncidentDetail.ExecuteReader(where);
            IncidentDetail _incidentdetail = null;
            if (reader.Read())
                _incidentdetail = reader.CurrentIncidentDetail;
            reader.Close();
            return _incidentdetail;
        }

        public static IncidentDetail LoadIncidentDetail(string where, IDbConnection conn)
        {
            IncidentDetailReader reader = IncidentDetail.ExecuteReader(where, conn);
            IncidentDetail _incidentdetail = null;
            if (reader.Read())
                _incidentdetail = reader.CurrentIncidentDetail;
            reader.Close(false);
            return _incidentdetail;
        }

        public static IncidentDetail LoadIncidentDetailByPk(int incident_detail_id)
        {
            return LoadIncidentDetail(" incident_detail_id=" + incident_detail_id);
        }

        public static IncidentDetail LoadIncidentDetailByPk(int incident_detail_id, IDbConnection conn)
        {
            return LoadIncidentDetail(" incident_detail_id=" + incident_detail_id, conn);
        }

        public void Save()
        {
            if (incident_detail_idChanged || token_nameChanged || token_valueChanged || incident_idChanged)
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
            if (incident_detail_idChanged || token_nameChanged || token_valueChanged || incident_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Incident_detail( incident_detail_id,token_name,token_value,incident_id ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.incident_detail_id = ConnectionFactory.GetNextId();
                        qry.Append(this.incident_detail_id);
                    } qry.Append(",");
                    qry.Append(token_nameDbString + ",");
                    qry.Append(token_valueDbString + ",");
                    qry.Append(incident_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(incident_detail_idChanged || token_nameChanged || token_valueChanged || incident_idChanged))
                        return;
                    qry.Append("UPDATE Incident_detail set "); if (token_nameChanged)
                    {
                        qry.Append("token_name =" + token_nameDbString);
                        qry.Append(",");
                    }

                    if (token_valueChanged)
                    {
                        qry.Append("token_value =" + token_valueDbString);
                        qry.Append(",");
                    }

                    if (incident_idChanged)
                    {
                        qry.Append("incident_id =" + incident_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("incident_detail_id = " + incident_detail_idDbString);
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
            cmd.CommandText = "DELETE Incident_detail where incident_detail_id = " + incident_detail_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteIncidentDetails(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Incident_detail where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            incident_detail_id = 1,
            token_name = 2,
            token_value = 4,
            incident_id = 8
        }
        #endregion
        public void BulkSave(List<IncidentDetail> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Incident_detail";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(IncidentDetail.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<IncidentDetail> transList, ref DataTable dt)
        {
            foreach (IncidentDetail tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["incident_detail_id"] = ConnectionFactory.GetNextId();
                Row["token_name"] = tran.TokenName;
                Row["token_value"] = tran.TokenValue;
                Row["incident_id"] = tran.IncidentId;
                dt.Rows.Add(Row);
            }
        }
    }
}


