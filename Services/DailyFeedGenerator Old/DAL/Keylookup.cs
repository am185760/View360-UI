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
    public class Keylookup
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Keylookup() { }
        public Keylookup(int keylookup_id, string key_name, DateTime created_at, int created_by)
        {
            this.key_name = key_name;
            this.key_nameChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
        }
        public Keylookup(string key_name, string key_value, bool? is_key_value_enabled, DateTime created_at, int created_by)
        {
            this.key_name = key_name;
            this.key_nameChanged = true;
            this.key_value = key_value;
            this.key_valueChanged = true;
            this.is_key_value_enabled = is_key_value_enabled;
            this.is_key_value_enabledChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
        }
        private Keylookup(int keylookup_id, string key_name, string key_value, bool? is_key_value_enabled, DateTime created_at, int created_by)
        {
            this.keylookup_id = keylookup_id;
            this.keylookup_idChanged = true;
            this.key_name = key_name;
            this.key_nameChanged = true;
            this.key_value = key_value;
            this.key_valueChanged = true;
            this.is_key_value_enabled = is_key_value_enabled;
            this.is_key_value_enabledChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
        }

        #region members and properties for columns

        #region KeylookupId
        private bool keylookup_idChanged = false;
        private int keylookup_id;
        public int KeylookupId
        {
            get { return keylookup_id; }
            set
            {
                keylookup_id = value;
                keylookup_idChanged = true;
            }
        }
        private string keylookup_idDbString
        {
            get
            {
                return keylookup_id.ToString();
            }
        }
        #endregion
        #region KeyName
        private bool key_nameChanged = false;
        private string key_name;
        public string KeyName
        {
            get { return key_name; }
            set
            {
                key_name = value;
                key_nameChanged = true;
            }
        }
        private string key_nameDbString
        {
            get
            {
                if (this.key_name != null)
                    return string.Format("'{0}'", key_name);
                else
                    return "null";
            }
        }
        #endregion
        #region KeyValue
        private bool key_valueChanged = false;
        private string key_value;
        public string KeyValue
        {
            get { return key_value; }
            set
            {
                key_value = value;
                key_valueChanged = true;
            }
        }
        private string key_valueDbString
        {
            get
            {
                if (this.key_value != null)
                    return string.Format("'{0}'", key_value);
                else
                    return "null";
            }
        }
        #endregion
        #region IsKeyValueEnabled
        private bool is_key_value_enabledChanged = false;
        private bool? is_key_value_enabled;
        public bool? IsKeyValueEnabled
        {
            get { return is_key_value_enabled; }
            set
            {
                is_key_value_enabled = value;
                is_key_value_enabledChanged = true;
            }
        }
        private string is_key_value_enabledDbString
        {
            get
            {
                if (this.is_key_value_enabled.HasValue)
                    return is_key_value_enabled.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedAt
        private bool created_atChanged = false;
        private DateTime created_at;
        public DateTime CreatedAt
        {
            get { return created_at; }
            set
            {
                created_at = value;
                created_atChanged = true;
            }
        }
        private string created_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", created_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private int created_by;
        public int CreatedBy
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
        #endregion

        #region KeylookupReader
        public class KeylookupReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Keylookup currentKeylookup;
            Columns columns;
            bool partialRead = false;
            private KeylookupReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public KeylookupReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public KeylookupReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentKeylookup; }

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
                    currentKeylookup = new Keylookup();
                    if (partialRead)
                    {
                        if ((columns & Columns.keylookup_id) == Columns.keylookup_id && reader["keylookup_id"] != DBNull.Value)
                            currentKeylookup.keylookup_id = (int)reader["keylookup_id"];
                        if ((columns & Columns.key_name) == Columns.key_name && reader["key_name"] != DBNull.Value)
                            currentKeylookup.key_name = (string)reader["key_name"];
                        if ((columns & Columns.key_value) == Columns.key_value && reader["key_value"] != DBNull.Value)
                            currentKeylookup.key_value = (string)reader["key_value"];
                        if ((columns & Columns.is_key_value_enabled) == Columns.is_key_value_enabled && reader["is_key_value_enabled"] != DBNull.Value)
                            currentKeylookup.is_key_value_enabled = (bool?)reader["is_key_value_enabled"];
                        if ((columns & Columns.created_at) == Columns.created_at && reader["created_at"] != DBNull.Value)
                            currentKeylookup.created_at = (DateTime)reader["created_at"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentKeylookup.created_by = (int)reader["created_by"];

                    }
                    else
                    {
                        if (reader["keylookup_id"] != DBNull.Value)
                            currentKeylookup.keylookup_id = (int)reader["keylookup_id"];
                        if (reader["key_name"] != DBNull.Value)
                            currentKeylookup.key_name = (string)reader["key_name"];
                        if (reader["key_value"] != DBNull.Value)
                            currentKeylookup.key_value = (string)reader["key_value"];
                        if (reader["is_key_value_enabled"] != DBNull.Value)
                            currentKeylookup.is_key_value_enabled = (bool?)reader["is_key_value_enabled"];
                        if (reader["created_at"] != DBNull.Value)
                            currentKeylookup.created_at = (DateTime)reader["created_at"];
                        if (reader["created_by"] != DBNull.Value)
                            currentKeylookup.created_by = (int)reader["created_by"];
                    }

                    currentKeylookup.isNewEntity = false;
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

            public Keylookup CurrentKeylookup
            {
                get { return currentKeylookup; }
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


        #region Keylookup functions

        public static KeylookupReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.keylookup_id == (Columns.keylookup_id & columns))
                qry.Append("keylookup_id,");
            if (Columns.key_name == (Columns.key_name & columns))
                qry.Append("key_name,");
            if (Columns.key_value == (Columns.key_value & columns))
                qry.Append("key_value,");
            if (Columns.is_key_value_enabled == (Columns.is_key_value_enabled & columns))
                qry.Append("is_key_value_enabled,");
            if (Columns.created_at == (Columns.created_at & columns))
                qry.Append("created_at,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Keylookup ");

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
            return new KeylookupReader(cmd.ExecuteReader(), conn, columns);
        }

        static public KeylookupReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static KeylookupReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select keylookup_id,key_name,key_value,is_key_value_enabled,created_at,created_by from Keylookup ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new KeylookupReader(cmd.ExecuteReader(), conn);
        }

        static public KeylookupReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static Keylookup LoadKeylookup(string where)
        {
            KeylookupReader reader = Keylookup.ExecuteReader(where);
            Keylookup _keylookup = null;
            if (reader.Read())
                _keylookup = reader.CurrentKeylookup;
            reader.Close();
            return _keylookup;
        }

        public static Keylookup LoadKeylookup(string where, IDbConnection conn)
        {
            KeylookupReader reader = Keylookup.ExecuteReader(where, conn);
            Keylookup _keylookup = null;
            if (reader.Read())
                _keylookup = reader.CurrentKeylookup;
            reader.Close(false);
            return _keylookup;
        }

        public static Keylookup LoadKeylookupByPk(int keylookup_id)
        {
            return LoadKeylookup(" keylookup_id=" + keylookup_id);
        }

        public static Keylookup LoadKeylookupByPk(int keylookup_id, IDbConnection conn)
        {
            return LoadKeylookup(" keylookup_id=" + keylookup_id, conn);
        }

        public void Save()
        {
            if (keylookup_idChanged || key_nameChanged || key_valueChanged || is_key_value_enabledChanged || created_atChanged || created_byChanged)
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
            if (keylookup_idChanged || key_nameChanged || key_valueChanged || is_key_value_enabledChanged || created_atChanged || created_byChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Keylookup( keylookup_id,key_name,key_value,is_key_value_enabled,created_at,created_by ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.keylookup_id = ConnectionFactory.GetNextId();
                        qry.Append(this.keylookup_id);
                    } qry.Append(",");
                    qry.Append(key_nameDbString + ",");
                    qry.Append(key_valueDbString + ",");
                    qry.Append(is_key_value_enabledDbString + ",");
                    qry.Append(created_atDbString + ",");
                    qry.Append(created_byDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(keylookup_idChanged || key_nameChanged || key_valueChanged || is_key_value_enabledChanged || created_atChanged || created_byChanged))
                        return;
                    qry.Append("UPDATE Keylookup set "); if (key_nameChanged)
                    {
                        qry.Append("key_name =" + key_nameDbString);
                        qry.Append(",");
                    }

                    if (key_valueChanged)
                    {
                        qry.Append("key_value =" + key_valueDbString);
                        qry.Append(",");
                    }

                    if (is_key_value_enabledChanged)
                    {
                        qry.Append("is_key_value_enabled =" + is_key_value_enabledDbString);
                        qry.Append(",");
                    }

                    if (created_atChanged)
                    {
                        qry.Append("created_at =" + created_atDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("keylookup_id = " + keylookup_idDbString);
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
            cmd.CommandText = "DELETE Keylookup where keylookup_id = " + keylookup_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteKeylookups(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Keylookup where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            keylookup_id = 1,
            key_name = 2,
            key_value = 4,
            is_key_value_enabled = 8,
            created_at = 16,
            created_by = 32
        }
        #endregion
        public void BulkSave(List<Keylookup> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Keylookup";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Keylookup.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Keylookup> transList, ref DataTable dt)
        {
            foreach (Keylookup tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["keylookup_id"] = ConnectionFactory.GetNextId();
                Row["key_name"] = tran.KeyName;
                Row["key_value"] = tran.KeyValue;
                Row["is_key_value_enabled"] = tran.IsKeyValueEnabled;
                Row["created_at"] = tran.CreatedAt;
                Row["created_by"] = tran.CreatedBy;
                dt.Rows.Add(Row);
            }
        }
    }
}

