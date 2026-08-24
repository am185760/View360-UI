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
    public class CcmsEvent
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsEvent() { }
        public CcmsEvent(long id)
        {
            this.id = id;
            this.idChanged = true;
        }
        public CcmsEvent(long id, string event_id, string event_name, string event_type, string entity_id, string entity_type, string sender, string recipient, string description)
        {
            this.id = id;
            this.idChanged = true;
            this.event_id = event_id;
            this.event_idChanged = true;
            this.event_name = event_name;
            this.event_nameChanged = true;
            this.event_type = event_type;
            this.event_typeChanged = true;
            this.entity_id = entity_id;
            this.entity_idChanged = true;
            this.entity_type = entity_type;
            this.entity_typeChanged = true;
            this.sender = sender;
            this.senderChanged = true;
            this.recipient = recipient;
            this.recipientChanged = true;
            this.description = description;
            this.descriptionChanged = true;
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
        #region EventId
        private bool event_idChanged = false;
        private string event_id;
        public string EventId
        {
            get { return event_id; }
            set
            {
                event_id = value;
                event_idChanged = true;
            }
        }
        private string event_idDbString
        {
            get
            {
                if (this.event_id != null)
                    return string.Format("'{0}'", event_id);
                else
                    return "null";
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
        #region EntityId
        private bool entity_idChanged = false;
        private string entity_id;
        public string EntityId
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
                if (this.entity_id != null)
                    return string.Format("'{0}'", entity_id);
                else
                    return "null";
            }
        }
        #endregion
        #region EntityType
        private bool entity_typeChanged = false;
        private string entity_type;
        public string EntityType
        {
            get { return entity_type; }
            set
            {
                entity_type = value;
                entity_typeChanged = true;
            }
        }
        private string entity_typeDbString
        {
            get
            {
                if (this.entity_type != null)
                    return string.Format("'{0}'", entity_type);
                else
                    return "null";
            }
        }
        #endregion
        #region Sender
        private bool senderChanged = false;
        private string sender;
        public string Sender
        {
            get { return sender; }
            set
            {
                sender = value;
                senderChanged = true;
            }
        }
        private string senderDbString
        {
            get
            {
                if (this.sender != null)
                    return string.Format("'{0}'", sender);
                else
                    return "null";
            }
        }
        #endregion
        #region Recipient
        private bool recipientChanged = false;
        private string recipient;
        public string Recipient
        {
            get { return recipient; }
            set
            {
                recipient = value;
                recipientChanged = true;
            }
        }
        private string recipientDbString
        {
            get
            {
                if (this.recipient != null)
                    return string.Format("'{0}'", recipient);
                else
                    return "null";
            }
        }
        #endregion
        #region Description
        private bool descriptionChanged = false;
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                descriptionChanged = true;
            }
        }
        private string descriptionDbString
        {
            get
            {
                if (this.description != null)
                    return string.Format("'{0}'", description);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region CcmsEventReader
        public class CcmsEventReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsEvent currentCcmsEvent;
            Columns columns;
            bool partialRead = false;
            private CcmsEventReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsEventReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsEventReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsEvent; }

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
                    currentCcmsEvent = new CcmsEvent();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsEvent.id = (long)reader["id"];
                        if ((columns & Columns.event_id) == Columns.event_id && reader["event_id"] != DBNull.Value)
                            currentCcmsEvent.event_id = (string)reader["event_id"];
                        if ((columns & Columns.event_name) == Columns.event_name && reader["event_name"] != DBNull.Value)
                            currentCcmsEvent.event_name = (string)reader["event_name"];
                        if ((columns & Columns.event_type) == Columns.event_type && reader["event_type"] != DBNull.Value)
                            currentCcmsEvent.event_type = (string)reader["event_type"];
                        if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"] != DBNull.Value)
                            currentCcmsEvent.entity_id = (string)reader["entity_id"];
                        if ((columns & Columns.entity_type) == Columns.entity_type && reader["entity_type"] != DBNull.Value)
                            currentCcmsEvent.entity_type = (string)reader["entity_type"];
                        if ((columns & Columns.sender) == Columns.sender && reader["sender"] != DBNull.Value)
                            currentCcmsEvent.sender = (string)reader["sender"];
                        if ((columns & Columns.recipient) == Columns.recipient && reader["recipient"] != DBNull.Value)
                            currentCcmsEvent.recipient = (string)reader["recipient"];
                        if ((columns & Columns.description) == Columns.description && reader["description"] != DBNull.Value)
                            currentCcmsEvent.description = (string)reader["description"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsEvent.id = (long)reader["id"];
                        if (reader["event_id"] != DBNull.Value)
                            currentCcmsEvent.event_id = (string)reader["event_id"];
                        if (reader["event_name"] != DBNull.Value)
                            currentCcmsEvent.event_name = (string)reader["event_name"];
                        if (reader["event_type"] != DBNull.Value)
                            currentCcmsEvent.event_type = (string)reader["event_type"];
                        if (reader["entity_id"] != DBNull.Value)
                            currentCcmsEvent.entity_id = (string)reader["entity_id"];
                        if (reader["entity_type"] != DBNull.Value)
                            currentCcmsEvent.entity_type = (string)reader["entity_type"];
                        if (reader["sender"] != DBNull.Value)
                            currentCcmsEvent.sender = (string)reader["sender"];
                        if (reader["recipient"] != DBNull.Value)
                            currentCcmsEvent.recipient = (string)reader["recipient"];
                        if (reader["description"] != DBNull.Value)
                            currentCcmsEvent.description = (string)reader["description"];
                    }

                    currentCcmsEvent.isNewEntity = false;
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

            public CcmsEvent CurrentCcmsEvent
            {
                get { return currentCcmsEvent; }
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


        #region CcmsEvent functions

        public static CcmsEventReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.event_id == (Columns.event_id & columns))
                qry.Append("event_id,");
            if (Columns.event_name == (Columns.event_name & columns))
                qry.Append("event_name,");
            if (Columns.event_type == (Columns.event_type & columns))
                qry.Append("event_type,");
            if (Columns.entity_id == (Columns.entity_id & columns))
                qry.Append("entity_id,");
            if (Columns.entity_type == (Columns.entity_type & columns))
                qry.Append("entity_type,");
            if (Columns.sender == (Columns.sender & columns))
                qry.Append("sender,");
            if (Columns.recipient == (Columns.recipient & columns))
                qry.Append("recipient,");
            if (Columns.description == (Columns.description & columns))
                qry.Append("description,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ccms_event ");

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
            return new CcmsEventReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsEventReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsEventReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,event_id,event_name,event_type,entity_id,entity_type,sender,recipient,description from Ccms_event ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CcmsEventReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsEventReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CcmsEvent LoadCcmsEvent(string where)
        {
            CcmsEventReader reader = CcmsEvent.ExecuteReader(where);
            CcmsEvent _ccmsevent = null;
            if (reader.Read())
                _ccmsevent = reader.CurrentCcmsEvent;
            reader.Close();
            return _ccmsevent;
        }

        public static CcmsEvent LoadCcmsEvent(string where, IDbConnection conn)
        {
            CcmsEventReader reader = CcmsEvent.ExecuteReader(where, conn);
            CcmsEvent _ccmsevent = null;
            if (reader.Read())
                _ccmsevent = reader.CurrentCcmsEvent;
            reader.Close(false);
            return _ccmsevent;
        }

        public static CcmsEvent LoadCcmsEventByPk(long id)
        {
            return LoadCcmsEvent(" id=" + id);
        }

        public static CcmsEvent LoadCcmsEventByPk(long id, IDbConnection conn)
        {
            return LoadCcmsEvent(" id=" + id, conn);
        }

        public void Save()
        {
            if (idChanged || event_idChanged || event_nameChanged || event_typeChanged || entity_idChanged || entity_typeChanged || senderChanged || recipientChanged || descriptionChanged)
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
            if (idChanged || event_idChanged || event_nameChanged || event_typeChanged || entity_idChanged || entity_typeChanged || senderChanged || recipientChanged || descriptionChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ccms_event( event_id,event_name,event_type,entity_id,entity_type,sender,recipient,description ) values(");
                    qry.Append(event_idDbString + ",");
                    qry.Append(event_nameDbString + ",");
                    qry.Append(event_typeDbString + ",");
                    qry.Append(entity_idDbString + ",");
                    qry.Append(entity_typeDbString + ",");
                    qry.Append(senderDbString + ",");
                    qry.Append(recipientDbString + ",");
                    qry.Append(descriptionDbString);
                    qry.Append(");SELECT scope_identity()");

                }
                else
                {
                    if (!(idChanged || event_idChanged || event_nameChanged || event_typeChanged || entity_idChanged || entity_typeChanged || senderChanged || recipientChanged || descriptionChanged))
                        return;
                    qry.Append("UPDATE Ccms_event set "); if (event_idChanged)
                    {
                        qry.Append("event_id =" + event_idDbString);
                        qry.Append(",");
                    }

                    if (event_nameChanged)
                    {
                        qry.Append("event_name =" + event_nameDbString);
                        qry.Append(",");
                    }

                    if (event_typeChanged)
                    {
                        qry.Append("event_type =" + event_typeDbString);
                        qry.Append(",");
                    }

                    if (entity_idChanged)
                    {
                        qry.Append("entity_id =" + entity_idDbString);
                        qry.Append(",");
                    }

                    if (entity_typeChanged)
                    {
                        qry.Append("entity_type =" + entity_typeDbString);
                        qry.Append(",");
                    }

                    if (senderChanged)
                    {
                        qry.Append("sender =" + senderDbString);
                        qry.Append(",");
                    }

                    if (recipientChanged)
                    {
                        qry.Append("recipient =" + recipientDbString);
                        qry.Append(",");
                    }

                    if (descriptionChanged)
                    {
                        qry.Append("description =" + descriptionDbString);
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
                    //cmd.ExecuteNonQuery();
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
            cmd.CommandText = "DELETE Ccms_event where id = " + id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCcmsEvents(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_event where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            event_id = 2,
            event_name = 4,
            event_type = 8,
            entity_id = 16,
            entity_type = 32,
            sender = 64,
            recipient = 128,
            description = 256
        }
        #endregion
        public void BulkSave(List<CcmsEvent> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_event";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsEvent.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsEvent> transList, ref DataTable dt)
        {
            foreach (CcmsEvent tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = tran.Id;
                Row["event_id"] = tran.EventId;
                Row["event_name"] = tran.EventName;
                Row["event_type"] = tran.EventType;
                Row["entity_id"] = tran.EntityId;
                Row["entity_type"] = tran.EntityType;
                Row["sender"] = tran.Sender;
                Row["recipient"] = tran.Recipient;
                Row["description"] = tran.Description;
                dt.Rows.Add(Row);
            }
        }
    }
}
