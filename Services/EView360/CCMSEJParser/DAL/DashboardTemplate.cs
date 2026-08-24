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
    public class DashboardTemplate
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public DashboardTemplate() { }
        public DashboardTemplate(int id, string title, bool is_active, DateTime created_at, int created_by)
        {
            this.title = title;
            this.titleChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
        }
        public DashboardTemplate(string title, bool is_active, DateTime created_at, int created_by, DateTime? changed_at, int? changed_by, int? refresh_duration_sec)
        {
            this.title = title;
            this.titleChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.changed_at = changed_at;
            this.changed_atChanged = true;
            this.changed_by = changed_by;
            this.changed_byChanged = true;
            this.refresh_duration_sec = refresh_duration_sec;
            this.refresh_duration_secChanged = true;
        }
        private DashboardTemplate(int id, string title, bool is_active, DateTime created_at, int created_by, DateTime? changed_at, int? changed_by, int? refresh_duration_sec)
        {
            this.id = id;
            this.idChanged = true;
            this.title = title;
            this.titleChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.changed_at = changed_at;
            this.changed_atChanged = true;
            this.changed_by = changed_by;
            this.changed_byChanged = true;
            this.refresh_duration_sec = refresh_duration_sec;
            this.refresh_duration_secChanged = true;
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
        #region Title
        private bool titleChanged = false;
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                titleChanged = true;
            }
        }
        private string titleDbString
        {
            get
            {
                if (this.title != null)
                    return string.Format("'{0}'", title);
                else
                    return "null";
            }
        }
        #endregion
        #region IsActive
        private bool is_activeChanged = false;
        private bool is_active;
        public bool IsActive
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
                return is_active ? "1" : "0";
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
        #region ChangedAt
        private bool changed_atChanged = false;
        private DateTime? changed_at;
        public DateTime? ChangedAt
        {
            get { return changed_at; }
            set
            {
                changed_at = value;
                changed_atChanged = true;
            }
        }
        private string changed_atDbString
        {
            get
            {
                if (this.changed_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", changed_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region ChangedBy
        private bool changed_byChanged = false;
        private int? changed_by;
        public int? ChangedBy
        {
            get { return changed_by; }
            set
            {
                changed_by = value;
                changed_byChanged = true;
            }
        }
        private string changed_byDbString
        {
            get
            {
                if (this.changed_by.HasValue)
                    return changed_by.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region RefreshDurationSec
        private bool refresh_duration_secChanged = false;
        private int? refresh_duration_sec;
        public int? RefreshDurationSec
        {
            get { return refresh_duration_sec; }
            set
            {
                refresh_duration_sec = value;
                refresh_duration_secChanged = true;
            }
        }
        private string refresh_duration_secDbString
        {
            get
            {
                if (this.refresh_duration_sec.HasValue)
                    return refresh_duration_sec.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region DashboardTemplateReader
        public class DashboardTemplateReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            DashboardTemplate currentDashboardTemplate;
            Columns columns;
            bool partialRead = false;
            private DashboardTemplateReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public DashboardTemplateReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public DashboardTemplateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentDashboardTemplate; }

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
                    currentDashboardTemplate = new DashboardTemplate();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentDashboardTemplate.id = (int)reader["id"];
                        if ((columns & Columns.title) == Columns.title && reader["title"] != DBNull.Value)
                            currentDashboardTemplate.title = (string)reader["title"];
                        if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"] != DBNull.Value)
                            currentDashboardTemplate.is_active = (bool)reader["is_active"];
                        if ((columns & Columns.created_at) == Columns.created_at && reader["created_at"] != DBNull.Value)
                            currentDashboardTemplate.created_at = (DateTime)reader["created_at"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentDashboardTemplate.created_by = (int)reader["created_by"];
                        if ((columns & Columns.changed_at) == Columns.changed_at && reader["changed_at"] != DBNull.Value)
                            currentDashboardTemplate.changed_at = (DateTime?)reader["changed_at"];
                        if ((columns & Columns.changed_by) == Columns.changed_by && reader["changed_by"] != DBNull.Value)
                            currentDashboardTemplate.changed_by = (int?)reader["changed_by"];
                        if ((columns & Columns.refresh_duration_sec) == Columns.refresh_duration_sec && reader["refresh_duration_sec"] != DBNull.Value)
                            currentDashboardTemplate.refresh_duration_sec = (int?)reader["refresh_duration_sec"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentDashboardTemplate.id = (int)reader["id"];
                        if (reader["title"] != DBNull.Value)
                            currentDashboardTemplate.title = (string)reader["title"];
                        if (reader["is_active"] != DBNull.Value)
                            currentDashboardTemplate.is_active = (bool)reader["is_active"];
                        if (reader["created_at"] != DBNull.Value)
                            currentDashboardTemplate.created_at = (DateTime)reader["created_at"];
                        if (reader["created_by"] != DBNull.Value)
                            currentDashboardTemplate.created_by = (int)reader["created_by"];
                        if (reader["changed_at"] != DBNull.Value)
                            currentDashboardTemplate.changed_at = (DateTime?)reader["changed_at"];
                        if (reader["changed_by"] != DBNull.Value)
                            currentDashboardTemplate.changed_by = (int?)reader["changed_by"];
                        if (reader["refresh_duration_sec"] != DBNull.Value)
                            currentDashboardTemplate.refresh_duration_sec = (int?)reader["refresh_duration_sec"];
                    }

                    currentDashboardTemplate.isNewEntity = false;
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

            public DashboardTemplate CurrentDashboardTemplate
            {
                get { return currentDashboardTemplate; }
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


        #region DashboardTemplate functions

        public static DashboardTemplateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.title == (Columns.title & columns))
                qry.Append("title,");
            if (Columns.is_active == (Columns.is_active & columns))
                qry.Append("is_active,");
            if (Columns.created_at == (Columns.created_at & columns))
                qry.Append("created_at,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.changed_at == (Columns.changed_at & columns))
                qry.Append("changed_at,");
            if (Columns.changed_by == (Columns.changed_by & columns))
                qry.Append("changed_by,");
            if (Columns.refresh_duration_sec == (Columns.refresh_duration_sec & columns))
                qry.Append("refresh_duration_sec,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Dashboard_template ");

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
            return new DashboardTemplateReader(cmd.ExecuteReader(), conn, columns);
        }

        static public DashboardTemplateReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static DashboardTemplateReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,title,is_active,created_at,created_by,changed_at,changed_by,refresh_duration_sec from Dashboard_template ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new DashboardTemplateReader(cmd.ExecuteReader(), conn);
        }

        static public DashboardTemplateReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static DashboardTemplate LoadDashboardTemplate(string where)
        {
            DashboardTemplateReader reader = DashboardTemplate.ExecuteReader(where);
            DashboardTemplate _dashboardtemplate = null;
            if (reader.Read())
                _dashboardtemplate = reader.CurrentDashboardTemplate;
            reader.Close();
            return _dashboardtemplate;
        }

        public static DashboardTemplate LoadDashboardTemplate(string where, IDbConnection conn)
        {
            DashboardTemplateReader reader = DashboardTemplate.ExecuteReader(where, conn);
            DashboardTemplate _dashboardtemplate = null;
            if (reader.Read())
                _dashboardtemplate = reader.CurrentDashboardTemplate;
            reader.Close(false);
            return _dashboardtemplate;
        }

        public static DashboardTemplate LoadDashboardTemplateByPk(int id)
        {
            return LoadDashboardTemplate(" id=" + id);
        }

        public static DashboardTemplate LoadDashboardTemplateByPk(int id, IDbConnection conn)
        {
            return LoadDashboardTemplate(" id=" + id, conn);
        }

        public void Save()
        {
            if (idChanged || titleChanged || is_activeChanged || created_atChanged || created_byChanged || changed_atChanged || changed_byChanged || refresh_duration_secChanged)
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
            if (idChanged || titleChanged || is_activeChanged || created_atChanged || created_byChanged || changed_atChanged || changed_byChanged || refresh_duration_secChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Dashboard_template( id,title,is_active,created_at,created_by,changed_at,changed_by,refresh_duration_sec ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.id = ConnectionFactory.GetNextId();
                        qry.Append(this.id);
                    } qry.Append(",");
                    qry.Append(titleDbString + ",");
                    qry.Append(is_activeDbString + ",");
                    qry.Append(created_atDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(changed_atDbString + ",");
                    qry.Append(changed_byDbString + ",");
                    qry.Append(refresh_duration_secDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(idChanged || titleChanged || is_activeChanged || created_atChanged || created_byChanged || changed_atChanged || changed_byChanged || refresh_duration_secChanged))
                        return;
                    qry.Append("UPDATE Dashboard_template set "); if (titleChanged)
                    {
                        qry.Append("title =" + titleDbString);
                        qry.Append(",");
                    }

                    if (is_activeChanged)
                    {
                        qry.Append("is_active =" + is_activeDbString);
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

                    if (changed_atChanged)
                    {
                        qry.Append("changed_at =" + changed_atDbString);
                        qry.Append(",");
                    }

                    if (changed_byChanged)
                    {
                        qry.Append("changed_by =" + changed_byDbString);
                        qry.Append(",");
                    }

                    if (refresh_duration_secChanged)
                    {
                        qry.Append("refresh_duration_sec =" + refresh_duration_secDbString);
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
            cmd.CommandText = "DELETE Dashboard_template where id = " + id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteDashboardTemplates(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Dashboard_template where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            title = 2,
            is_active = 4,
            created_at = 8,
            created_by = 16,
            changed_at = 32,
            changed_by = 64,
            refresh_duration_sec = 128
        }
        #endregion
        public void BulkSave(List<DashboardTemplate> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Dashboard_template";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(DashboardTemplate.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<DashboardTemplate> transList, ref DataTable dt)
        {
            foreach (DashboardTemplate tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = ConnectionFactory.GetNextId();
                Row["title"] = tran.Title;
                Row["is_active"] = tran.IsActive;
                Row["created_at"] = tran.CreatedAt;
                Row["created_by"] = tran.CreatedBy;
                Row["changed_at"] = tran.ChangedAt;
                Row["changed_by"] = tran.ChangedBy;
                Row["refresh_duration_sec"] = tran.RefreshDurationSec;
                dt.Rows.Add(Row);
            }
        }
    }
}