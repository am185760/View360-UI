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
    public class CcmsCit
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsCit() { }
        public CcmsCit(int id, string name, string code, DateTime created_on, int created_by, string email_id)
        {
            this.name = name;
            this.nameChanged = true;
            this.code = code;
            this.codeChanged = true;
            this.created_on = created_on;
            this.created_onChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.email_id = email_id;
            this.email_idChanged = true;
        }
        public CcmsCit(string name, string code, DateTime created_on, int created_by, DateTime? modified_on, int? modified_by, bool? is_deleted, bool? is_active, DateTime? order_dispatch_time, string email_id)
        {
            this.name = name;
            this.nameChanged = true;
            this.code = code;
            this.codeChanged = true;
            this.created_on = created_on;
            this.created_onChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_on = modified_on;
            this.modified_onChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.is_deleted = is_deleted;
            this.is_deletedChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.order_dispatch_time = order_dispatch_time;
            this.order_dispatch_timeChanged = true;
            this.email_id = email_id;
            this.email_idChanged = true;
        }
        private CcmsCit(int id, string name, string code, DateTime created_on, int created_by, DateTime? modified_on, int? modified_by, bool? is_deleted, bool? is_active, DateTime? order_dispatch_time, string email_id)
        {
            this.id = id;
            this.idChanged = true;
            this.name = name;
            this.nameChanged = true;
            this.code = code;
            this.codeChanged = true;
            this.created_on = created_on;
            this.created_onChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_on = modified_on;
            this.modified_onChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.is_deleted = is_deleted;
            this.is_deletedChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.order_dispatch_time = order_dispatch_time;
            this.order_dispatch_timeChanged = true;
            this.email_id = email_id;
            this.email_idChanged = true;
        }

        #region members and properties for columns

        #region Id
        private bool idChanged = false;
        private int id;
        public int Id
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
        #region Name
        private bool nameChanged = false;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                nameChanged = true;
            }
        }
        private string nameDbString
        {
            get
            {
                if (this.name != null)
                    return string.Format("'{0}'", name);
                else
                    return "null";
            }
        }
        #endregion
        #region Code
        private bool codeChanged = false;
        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                codeChanged = true;
            }
        }
        private string codeDbString
        {
            get
            {
                if (this.code != null)
                    return string.Format("'{0}'", code);
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedOn
        private bool created_onChanged = false;
        private DateTime created_on;
        public DateTime CreatedOn
        {
            get { return created_on; }
            set
            {
                created_on = value;
                created_onChanged = true;
            }
        }
        private string created_onDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", created_on.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #region ModifiedOn
        private bool modified_onChanged = false;
        private DateTime? modified_on;
        public DateTime? ModifiedOn
        {
            get { return modified_on; }
            set
            {
                modified_on = value;
                modified_onChanged = true;
            }
        }
        private string modified_onDbString
        {
            get
            {
                if (this.modified_on.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region ModifiedBy
        private bool modified_byChanged = false;
        private int? modified_by;
        public int? ModifiedBy
        {
            get { return modified_by; }
            set
            {
                modified_by = value;
                modified_byChanged = true;
            }
        }
        private string modified_byDbString
        {
            get
            {
                if (this.modified_by.HasValue)
                    return modified_by.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsDeleted
        private bool is_deletedChanged = false;
        private bool? is_deleted;
        public bool? IsDeleted
        {
            get { return is_deleted; }
            set
            {
                is_deleted = value;
                is_deletedChanged = true;
            }
        }
        private string is_deletedDbString
        {
            get
            {
                if (this.is_deleted.HasValue)
                    return is_deleted.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsActive
        private bool is_activeChanged = false;
        private bool? is_active;
        public bool? IsActive
        {
            get { return is_active; }
            set
            {
                is_active = value;
                is_activeChanged = true;
            }
        }
        private string is_activeDbString
        {
            get
            {
                if (this.is_active.HasValue)
                    return is_active.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region OrderDispatchTime
        private bool order_dispatch_timeChanged = false;
        private DateTime? order_dispatch_time;
        public DateTime? OrderDispatchTime
        {
            get { return order_dispatch_time; }
            set
            {
                order_dispatch_time = value;
                order_dispatch_timeChanged = true;
            }
        }
        private string order_dispatch_timeDbString
        {
            get
            {
                if (this.order_dispatch_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", order_dispatch_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region EmailId
        private bool email_idChanged = false;
        private string email_id;
        public string EmailId
        {
            get { return email_id; }
            set
            {
                email_id = value;
                email_idChanged = true;
            }
        }
        private string email_idDbString
        {
            get
            {
                if (this.email_id != null)
                    return string.Format("'{0}'", email_id);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region CcmsCitReader
        public class CcmsCitReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsCit currentCcmsCit;
            Columns columns;
            bool partialRead = false;
            private CcmsCitReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsCitReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsCitReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsCit; }

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
                    currentCcmsCit = new CcmsCit();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsCit.id = (int)reader["id"];
                        if ((columns & Columns.name) == Columns.name && reader["name"] != DBNull.Value)
                            currentCcmsCit.name = (string)reader["name"];
                        if ((columns & Columns.code) == Columns.code && reader["code"] != DBNull.Value)
                            currentCcmsCit.code = (string)reader["code"];
                        if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"] != DBNull.Value)
                            currentCcmsCit.created_on = (DateTime)reader["created_on"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentCcmsCit.created_by = (int)reader["created_by"];
                        if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"] != DBNull.Value)
                            currentCcmsCit.modified_on = (DateTime?)reader["modified_on"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentCcmsCit.modified_by = (int?)reader["modified_by"];
                        if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"] != DBNull.Value)
                            currentCcmsCit.is_deleted = (bool?)reader["is_deleted"];
                        if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"] != DBNull.Value)
                            currentCcmsCit.is_active = (bool?)reader["is_active"];
                        if ((columns & Columns.order_dispatch_time) == Columns.order_dispatch_time && reader["order_dispatch_time"] != DBNull.Value)
                            currentCcmsCit.order_dispatch_time = (DateTime?)reader["order_dispatch_time"];
                        if ((columns & Columns.email_id) == Columns.email_id && reader["email_id"] != DBNull.Value)
                            currentCcmsCit.email_id = (string)reader["email_id"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsCit.id = (int)reader["id"];
                        if (reader["name"] != DBNull.Value)
                            currentCcmsCit.name = (string)reader["name"];
                        if (reader["code"] != DBNull.Value)
                            currentCcmsCit.code = (string)reader["code"];
                        if (reader["created_on"] != DBNull.Value)
                            currentCcmsCit.created_on = (DateTime)reader["created_on"];
                        if (reader["created_by"] != DBNull.Value)
                            currentCcmsCit.created_by = (int)reader["created_by"];
                        if (reader["modified_on"] != DBNull.Value)
                            currentCcmsCit.modified_on = (DateTime?)reader["modified_on"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentCcmsCit.modified_by = (int?)reader["modified_by"];
                        if (reader["is_deleted"] != DBNull.Value)
                            currentCcmsCit.is_deleted = (bool?)reader["is_deleted"];
                        if (reader["is_active"] != DBNull.Value)
                            currentCcmsCit.is_active = (bool?)reader["is_active"];
                        if (reader["order_dispatch_time"] != DBNull.Value)
                            currentCcmsCit.order_dispatch_time = (DateTime?)reader["order_dispatch_time"];
                        if (reader["email_id"] != DBNull.Value)
                            currentCcmsCit.email_id = (string)reader["email_id"];
                    }

                    currentCcmsCit.isNewEntity = false;
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

            public CcmsCit CurrentCcmsCit
            {
                get { return currentCcmsCit; }
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


        #region CcmsCit functions

        public static CcmsCitReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.name == (Columns.name & columns))
                qry.Append("name,");
            if (Columns.code == (Columns.code & columns))
                qry.Append("code,");
            if (Columns.created_on == (Columns.created_on & columns))
                qry.Append("created_on,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.modified_on == (Columns.modified_on & columns))
                qry.Append("modified_on,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.is_deleted == (Columns.is_deleted & columns))
                qry.Append("is_deleted,");
            if (Columns.is_active == (Columns.is_active & columns))
                qry.Append("is_active,");
            if (Columns.order_dispatch_time == (Columns.order_dispatch_time & columns))
                qry.Append("order_dispatch_time,");
            if (Columns.email_id == (Columns.email_id & columns))
                qry.Append("email_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ccms_cit ");

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
            return new CcmsCitReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsCitReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsCitReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,name,code,created_on,created_by,modified_on,modified_by,is_deleted,is_active,order_dispatch_time,email_id from Ccms_cit ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CcmsCitReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsCitReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CcmsCit LoadCcmsCit(string where)
        {
            CcmsCitReader reader = CcmsCit.ExecuteReader(where);
            CcmsCit _ccmscit = null;
            if (reader.Read())
                _ccmscit = reader.CurrentCcmsCit;
            reader.Close();
            return _ccmscit;
        }

        public static CcmsCit LoadCcmsCit(string where, IDbConnection conn)
        {
            CcmsCitReader reader = CcmsCit.ExecuteReader(where, conn);
            CcmsCit _ccmscit = null;
            if (reader.Read())
                _ccmscit = reader.CurrentCcmsCit;
            reader.Close(false);
            return _ccmscit;
        }

        public static CcmsCit LoadCcmsCitByPk(int id)
        {
            return LoadCcmsCit(" id=" + id);
        }

        public static CcmsCit LoadCcmsCitByPk(int id, IDbConnection conn)
        {
            return LoadCcmsCit(" id=" + id, conn);
        }

        public void Save()
        {
            if (idChanged || nameChanged || codeChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || is_deletedChanged || is_activeChanged || order_dispatch_timeChanged || email_idChanged)
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
            if (idChanged || nameChanged || codeChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || is_deletedChanged || is_activeChanged || order_dispatch_timeChanged || email_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ccms_cit( id,name,code,created_on,created_by,modified_on,modified_by,is_deleted,is_active,order_dispatch_time,email_id ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.id = ConnectionFactory.GetNextId();
                        qry.Append(this.id);
                    } qry.Append(",");
                    qry.Append(nameDbString + ",");
                    qry.Append(codeDbString + ",");
                    qry.Append(created_onDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(modified_onDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(is_deletedDbString + ",");
                    qry.Append(is_activeDbString + ",");
                    qry.Append(order_dispatch_timeDbString + ",");
                    qry.Append(email_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(idChanged || nameChanged || codeChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || is_deletedChanged || is_activeChanged || order_dispatch_timeChanged || email_idChanged))
                        return;
                    qry.Append("UPDATE Ccms_cit set "); if (nameChanged)
                    {
                        qry.Append("name =" + nameDbString);
                        qry.Append(",");
                    }

                    if (codeChanged)
                    {
                        qry.Append("code =" + codeDbString);
                        qry.Append(",");
                    }

                    if (created_onChanged)
                    {
                        qry.Append("created_on =" + created_onDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (modified_onChanged)
                    {
                        qry.Append("modified_on =" + modified_onDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }

                    if (is_deletedChanged)
                    {
                        qry.Append("is_deleted =" + is_deletedDbString);
                        qry.Append(",");
                    }

                    if (is_activeChanged)
                    {
                        qry.Append("is_active =" + is_activeDbString);
                        qry.Append(",");
                    }

                    if (order_dispatch_timeChanged)
                    {
                        qry.Append("order_dispatch_time =" + order_dispatch_timeDbString);
                        qry.Append(",");
                    }

                    if (email_idChanged)
                    {
                        qry.Append("email_id =" + email_idDbString);
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
            cmd.CommandText = "DELETE Ccms_cit where id = " + id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCcmsCits(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_cit where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            name = 2,
            code = 4,
            created_on = 8,
            created_by = 16,
            modified_on = 32,
            modified_by = 64,
            is_deleted = 128,
            is_active = 256,
            order_dispatch_time = 512,
            email_id = 1024
        }
        #endregion
        public void BulkSave(List<CcmsCit> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_cit";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsCit.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsCit> transList, ref DataTable dt)
        {
            foreach (CcmsCit tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = ConnectionFactory.GetNextId();
                Row["name"] = tran.Name;
                Row["code"] = tran.Code;
                Row["created_on"] = tran.CreatedOn;
                Row["created_by"] = tran.CreatedBy;
                Row["modified_on"] = tran.ModifiedOn;
                Row["modified_by"] = tran.ModifiedBy;
                Row["is_deleted"] = tran.IsDeleted;
                Row["is_active"] = tran.IsActive;
                Row["order_dispatch_time"] = tran.OrderDispatchTime;
                Row["email_id"] = tran.EmailId;
                dt.Rows.Add(Row);
            }
        }
    }
}
