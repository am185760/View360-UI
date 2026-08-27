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
    public class CcmsAlertNotificationApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsAlertNotificationApprover() { }
        public CcmsAlertNotificationApprover(long id, long? user_id)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
        }
        public CcmsAlertNotificationApprover(long? alert_type_id, long? organization_id, long? user_id)
        {
            this.alert_type_id = alert_type_id;
            this.alert_type_idChanged = true;
            this.organization_id = organization_id;
            this.organization_idChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
        }
        public CcmsAlertNotificationApprover(int? id, long? alert_type_id, long? organization_id, long? user_id)
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
        private int? id;
        public int? Id
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
                if (this.id.HasValue)
                    return id.ToString();
                else
                    return "null";
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

        #region CcmsAlertNotificationApproverReader
        public class CcmsAlertNotificationApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsAlertNotificationApprover currentCcmsAlertNotificationApprover;
            Columns columns;
            bool partialRead = false;
            private CcmsAlertNotificationApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsAlertNotificationApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsAlertNotificationApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsAlertNotificationApprover; }

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
                    currentCcmsAlertNotificationApprover = new CcmsAlertNotificationApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.id = (int?)reader["id"];
                        if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.alert_type_id = (int?)reader["alert_type_id"];
                        if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.organization_id = (int?)reader["organization_id"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.user_id = (int?)reader["user_id"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.id = (int?)reader["id"];
                        if (reader["alert_type_id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.alert_type_id = (int?)reader["alert_type_id"];
                        if (reader["organization_id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.organization_id = (int?)reader["organization_id"];
                        if (reader["user_id"] != DBNull.Value)
                            currentCcmsAlertNotificationApprover.user_id = (int?)reader["user_id"];
                    }

                    currentCcmsAlertNotificationApprover.isNewEntity = false;
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

            public CcmsAlertNotificationApprover CurrentCcmsAlertNotificationApprover
            {
                get { return currentCcmsAlertNotificationApprover; }
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


        #region CcmsAlertNotificationApprover functions

        public static CcmsAlertNotificationApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
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
            qry.Append("from Ccms_alert_notification_approver ");

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
            return new CcmsAlertNotificationApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsAlertNotificationApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsAlertNotificationApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,alert_type_id,organization_id,user_id from Ccms_alert_notification_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);
            var abc = cmd.ExecuteReader();
            
            return new CcmsAlertNotificationApproverReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsAlertNotificationApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CcmsAlertNotificationApprover LoadCcmsAlertNotificationApprover(string where)
        {
            CcmsAlertNotificationApproverReader reader = CcmsAlertNotificationApprover.ExecuteReader(where);
            CcmsAlertNotificationApprover _ccmsalertnotificationapprover = null;
            if (reader.Read())
                _ccmsalertnotificationapprover = reader.CurrentCcmsAlertNotificationApprover;
            reader.Close();
            return _ccmsalertnotificationapprover;
        }

        public static CcmsAlertNotificationApprover LoadCcmsAlertNotificationApprover(string where, IDbConnection conn)
        {
            CcmsAlertNotificationApproverReader reader = CcmsAlertNotificationApprover.ExecuteReader(where, conn);
            CcmsAlertNotificationApprover _ccmsalertnotificationapprover = null;
            if (reader.Read())
                _ccmsalertnotificationapprover = reader.CurrentCcmsAlertNotificationApprover;
            reader.Close(false);
            return _ccmsalertnotificationapprover;
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
                    qry.Append(@"insert into Ccms_alert_notification_approver( id,alert_type_id,organization_id,user_id ) values(");
                    qry.Append(idDbString + ",");
                    qry.Append(alert_type_idDbString + ",");
                    qry.Append(organization_idDbString + ",");
                    qry.Append(user_idDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update Ccms_alert_notification_approver!");
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
            throw new Exception("Could not delete because no primary key is defined");
        }

        public static void DeleteCcmsAlertNotificationApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_alert_notification_approver where " + where);
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
        public void BulkSave(List<CcmsAlertNotificationApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_alert_notification_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsAlertNotificationApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsAlertNotificationApprover> transList, ref DataTable dt)
        {
            foreach (CcmsAlertNotificationApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = tran.Id;
                Row["alert_type_id"] = tran.AlertTypeId;
                Row["organization_id"] = tran.OrganizationId;
                Row["user_id"] = tran.UserId;
                dt.Rows.Add(Row);
            }
        }
    }
}
