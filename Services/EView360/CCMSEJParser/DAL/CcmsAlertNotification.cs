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
    public class CcmsAlertNotification
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsAlertNotification() { }
        public CcmsAlertNotification(long id, long? user_id)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
        }
        public CcmsAlertNotification(long? alert_type_id, long? organization_id, long? user_id)
        {
            this.alert_type_id = alert_type_id;
            this.alert_type_idChanged = true;
            this.organization_id = organization_id;
            this.organization_idChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
        }
        private CcmsAlertNotification(long id, long? alert_type_id, long? organization_id, long? user_id)
        {
            this.id = id;
            this.idChanged = true;
            this.alert_type_id = alert_type_id;
            this.alert_type_idChanged = true;
            this.organization_id = organization_id;
            this.organization_idChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
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
        #region AlertTypeId
        private bool alert_type_idChanged = false;
        private long? alert_type_id;
        public long? AlertTypeId
        {
            get { return alert_type_id; }
            set
            {
                alert_type_id = value;
                alert_type_idChanged = true;
            }
        }
        private string alert_type_idDbString
        {
            get
            {
                if (this.alert_type_id.HasValue)
                    return alert_type_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region OrganizationId
        private bool organization_idChanged = false;
        private long? organization_id;
        public long? OrganizationId
        {
            get { return organization_id; }
            set
            {
                organization_id = value;
                organization_idChanged = true;
            }
        }
        private string organization_idDbString
        {
            get
            {
                if (this.organization_id.HasValue)
                    return organization_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region UserId
        private bool user_idChanged = false;
        private long? user_id;
        public long? UserId
        {
            get { return user_id; }
            set
            {
                user_id = value;
                user_idChanged = true;
            }
        }
        private string user_idDbString
        {
            get
            {
                if (this.user_id.HasValue)
                    return user_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region CcmsAlertNotificationReader
        public class CcmsAlertNotificationReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsAlertNotification currentCcmsAlertNotification;
            Columns columns;
            bool partialRead = false;
            private CcmsAlertNotificationReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsAlertNotificationReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsAlertNotificationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsAlertNotification; }

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
                    currentCcmsAlertNotification = new CcmsAlertNotification();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsAlertNotification.id = (long)reader["id"];
                        if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"] != DBNull.Value)
                            currentCcmsAlertNotification.alert_type_id = (long?)reader["alert_type_id"];
                        if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"] != DBNull.Value)
                            currentCcmsAlertNotification.organization_id = (long?)reader["organization_id"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentCcmsAlertNotification.user_id = (long?)reader["user_id"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsAlertNotification.id = (long)reader["id"];
                        if (reader["alert_type_id"] != DBNull.Value)
                            currentCcmsAlertNotification.alert_type_id = (long?)reader["alert_type_id"];
                        if (reader["organization_id"] != DBNull.Value)
                            currentCcmsAlertNotification.organization_id = (long?)reader["organization_id"];
                        if (reader["user_id"] != DBNull.Value)
                            currentCcmsAlertNotification.user_id = (long?)reader["user_id"];
                    }

                    currentCcmsAlertNotification.isNewEntity = false;
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

            public CcmsAlertNotification CurrentCcmsAlertNotification
            {
                get { return currentCcmsAlertNotification; }
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


        #region CcmsAlertNotification functions

        public static CcmsAlertNotificationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.alert_type_id == (Columns.alert_type_id & columns))
                qry.Append("alert_type_id,");
            if (Columns.organization_id == (Columns.organization_id & columns))
                qry.Append("organization_id,");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ccms_alert_notification ");

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
            return new CcmsAlertNotificationReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsAlertNotificationReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsAlertNotificationReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,alert_type_id,organization_id,user_id from Ccms_alert_notification ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CcmsAlertNotificationReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsAlertNotificationReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CcmsAlertNotification LoadCcmsAlertNotification(string where)
        {
            CcmsAlertNotificationReader reader = CcmsAlertNotification.ExecuteReader(where);
            CcmsAlertNotification _ccmsalertnotification = null;
            if (reader.Read())
                _ccmsalertnotification = reader.CurrentCcmsAlertNotification;
            reader.Close();
            return _ccmsalertnotification;
        }

        public static CcmsAlertNotification LoadCcmsAlertNotification(string where, IDbConnection conn)
        {
            CcmsAlertNotificationReader reader = CcmsAlertNotification.ExecuteReader(where, conn);
            CcmsAlertNotification _ccmsalertnotification = null;
            if (reader.Read())
                _ccmsalertnotification = reader.CurrentCcmsAlertNotification;
            reader.Close(false);
            return _ccmsalertnotification;
        }

        public static CcmsAlertNotification LoadCcmsAlertNotificationByPk(long id)
        {
            return LoadCcmsAlertNotification(" id=" + id);
        }

        public static CcmsAlertNotification LoadCcmsAlertNotificationByPk(long id, IDbConnection conn)
        {
            return LoadCcmsAlertNotification(" id=" + id, conn);
        }

        public void Save()
        {
            if (idChanged || alert_type_idChanged || organization_idChanged || user_idChanged)
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
            if (idChanged || alert_type_idChanged || organization_idChanged || user_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ccms_alert_notification( alert_type_id,organization_id,user_id ) values(");
                   
                    qry.Append(alert_type_idDbString + ",");
                    qry.Append(organization_idDbString + ",");
                    qry.Append(user_idDbString);
                    qry.Append(");SELECT scope_identity()");

                }
                else
                {
                    if (!(idChanged || alert_type_idChanged || organization_idChanged || user_idChanged))
                        return;
                    qry.Append("UPDATE Ccms_alert_notification set "); if (alert_type_idChanged)
                    {
                        qry.Append("alert_type_id =" + alert_type_idDbString);
                        qry.Append(",");
                    }

                    if (organization_idChanged)
                    {
                        qry.Append("organization_id =" + organization_idDbString);
                        qry.Append(",");
                    }

                    if (user_idChanged)
                    {
                        qry.Append("user_id =" + user_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("id = " + idDbString);
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
                    object res = cmd.ExecuteScalar();
                    if (res == DBNull.Value)
                        id = 1;
                    else
                        id = int.Parse(res.ToString());
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
            cmd.CommandText = "DELETE Ccms_alert_notification where id = " + id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCcmsAlertNotifications(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_alert_notification where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            alert_type_id = 2,
            organization_id = 4,
            user_id = 8
        }
        #endregion
        public void BulkSave(List<CcmsAlertNotification> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_alert_notification";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsAlertNotification.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsAlertNotification> transList, ref DataTable dt)
        {
            foreach (CcmsAlertNotification tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = ConnectionFactory.GetNextId();
                Row["alert_type_id"] = tran.AlertTypeId;
                Row["organization_id"] = tran.OrganizationId;
                Row["user_id"] = tran.UserId;
                dt.Rows.Add(Row);
            }
        }
    }
}
