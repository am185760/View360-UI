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
    public class ReportTemplate
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ReportTemplate() { }
        public ReportTemplate(int report_id, string report_name, string report_query, bool is_active, DateTime create_date, int created_by)
        {
            this.report_name = report_name;
            this.report_nameChanged = true;
            this.report_query = report_query;
            this.report_queryChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.create_date = create_date;
            this.create_dateChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
        }
        public ReportTemplate(string report_name, string report_query, bool is_active, DateTime create_date, int created_by, DateTime? changed_date, int? changed_by)
        {
            this.report_name = report_name;
            this.report_nameChanged = true;
            this.report_query = report_query;
            this.report_queryChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.create_date = create_date;
            this.create_dateChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.changed_date = changed_date;
            this.changed_dateChanged = true;
            this.changed_by = changed_by;
            this.changed_byChanged = true;
        }
        private ReportTemplate(int report_id, string report_name, string report_query, bool is_active, DateTime create_date, int created_by, DateTime? changed_date, int? changed_by)
        {
            this.report_id = report_id;
            this.report_idChanged = true;
            this.report_name = report_name;
            this.report_nameChanged = true;
            this.report_query = report_query;
            this.report_queryChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.create_date = create_date;
            this.create_dateChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.changed_date = changed_date;
            this.changed_dateChanged = true;
            this.changed_by = changed_by;
            this.changed_byChanged = true;
        }

        #region members and properties for columns

        #region ReportId
        private bool report_idChanged = false;
        private int report_id;
        public int ReportId
        {
            get { return report_id; }
            set
            {
                report_id = value;
                report_idChanged = true;
            }
        }
        private string report_idDbString
        {
            get
            {
                return report_id.ToString();
            }
        }
        #endregion
        #region ReportName
        private bool report_nameChanged = false;
        private string report_name;
        public string ReportName
        {
            get { return report_name; }
            set
            {
                report_name = value;
                report_nameChanged = true;
            }
        }
        private string report_nameDbString
        {
            get
            {
                if (this.report_name != null)
                    return string.Format("'{0}'", report_name);
                else
                    return "null";
            }
        }
        #endregion
        #region ReportQuery
        private bool report_queryChanged = false;
        private string report_query;
        public string ReportQuery
        {
            get { return report_query; }
            set
            {
                report_query = value;
                report_queryChanged = true;
            }
        }
        private string report_queryDbString
        {
            get
            {
                if (this.report_query != null)
                    return string.Format("'{0}'", report_query);
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
        #region CreateDate
        private bool create_dateChanged = false;
        private DateTime create_date;
        public DateTime CreateDate
        {
            get { return create_date; }
            set
            {
                create_date = value;
                create_dateChanged = true;
            }
        }
        private string create_dateDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", create_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #region ChangedDate
        private bool changed_dateChanged = false;
        private DateTime? changed_date;
        public DateTime? ChangedDate
        {
            get { return changed_date; }
            set
            {
                changed_date = value;
                changed_dateChanged = true;
            }
        }
        private string changed_dateDbString
        {
            get
            {
                if (this.changed_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", changed_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #endregion

        #region ReportTemplateReader
        public class ReportTemplateReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ReportTemplate currentReportTemplate;
            Columns columns;
            bool partialRead = false;
            private ReportTemplateReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ReportTemplateReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ReportTemplateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentReportTemplate; }

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
                    currentReportTemplate = new ReportTemplate();
                    if (partialRead)
                    {
                        if ((columns & Columns.report_id) == Columns.report_id && reader["report_id"] != DBNull.Value)
                            currentReportTemplate.report_id = (int)reader["report_id"];
                        if ((columns & Columns.report_name) == Columns.report_name && reader["report_name"] != DBNull.Value)
                            currentReportTemplate.report_name = (string)reader["report_name"];
                        if ((columns & Columns.report_query) == Columns.report_query && reader["report_query"] != DBNull.Value)
                            currentReportTemplate.report_query = (string)reader["report_query"];
                        if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"] != DBNull.Value)
                            currentReportTemplate.is_active = (bool)reader["is_active"];
                        if ((columns & Columns.create_date) == Columns.create_date && reader["create_date"] != DBNull.Value)
                            currentReportTemplate.create_date = (DateTime)reader["create_date"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentReportTemplate.created_by = (int)reader["created_by"];
                        if ((columns & Columns.changed_date) == Columns.changed_date && reader["changed_date"] != DBNull.Value)
                            currentReportTemplate.changed_date = (DateTime?)reader["changed_date"];
                        if ((columns & Columns.changed_by) == Columns.changed_by && reader["changed_by"] != DBNull.Value)
                            currentReportTemplate.changed_by = (int?)reader["changed_by"];

                    }
                    else
                    {
                        if (reader["report_id"] != DBNull.Value)
                            currentReportTemplate.report_id = (int)reader["report_id"];
                        if (reader["report_name"] != DBNull.Value)
                            currentReportTemplate.report_name = (string)reader["report_name"];
                        if (reader["report_query"] != DBNull.Value)
                            currentReportTemplate.report_query = (string)reader["report_query"];
                        if (reader["is_active"] != DBNull.Value)
                            currentReportTemplate.is_active = (bool)reader["is_active"];
                        if (reader["create_date"] != DBNull.Value)
                            currentReportTemplate.create_date = (DateTime)reader["create_date"];
                        if (reader["created_by"] != DBNull.Value)
                            currentReportTemplate.created_by = (int)reader["created_by"];
                        if (reader["changed_date"] != DBNull.Value)
                            currentReportTemplate.changed_date = (DateTime?)reader["changed_date"];
                        if (reader["changed_by"] != DBNull.Value)
                            currentReportTemplate.changed_by = (int?)reader["changed_by"];
                    }

                    currentReportTemplate.isNewEntity = false;
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

            public ReportTemplate CurrentReportTemplate
            {
                get { return currentReportTemplate; }
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


        #region ReportTemplate functions

        public static ReportTemplateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.report_id == (Columns.report_id & columns))
                qry.Append("report_id,");
            if (Columns.report_name == (Columns.report_name & columns))
                qry.Append("report_name,");
            if (Columns.report_query == (Columns.report_query & columns))
                qry.Append("report_query,");
            if (Columns.is_active == (Columns.is_active & columns))
                qry.Append("is_active,");
            if (Columns.create_date == (Columns.create_date & columns))
                qry.Append("create_date,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.changed_date == (Columns.changed_date & columns))
                qry.Append("changed_date,");
            if (Columns.changed_by == (Columns.changed_by & columns))
                qry.Append("changed_by,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Report_template ");

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
            return new ReportTemplateReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ReportTemplateReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ReportTemplateReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select report_id,report_name,report_query,is_active,create_date,created_by,changed_date,changed_by from Report_template ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ReportTemplateReader(cmd.ExecuteReader(), conn);
        }

        static public ReportTemplateReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static ReportTemplate LoadReportTemplate(string where)
        {
            ReportTemplateReader reader = ReportTemplate.ExecuteReader(where);
            ReportTemplate _reporttemplate = null;
            if (reader.Read())
                _reporttemplate = reader.CurrentReportTemplate;
            reader.Close();
            return _reporttemplate;
        }

        public static ReportTemplate LoadReportTemplate(string where, IDbConnection conn)
        {
            ReportTemplateReader reader = ReportTemplate.ExecuteReader(where, conn);
            ReportTemplate _reporttemplate = null;
            if (reader.Read())
                _reporttemplate = reader.CurrentReportTemplate;
            reader.Close(false);
            return _reporttemplate;
        }

        public static ReportTemplate LoadReportTemplateByPk(int report_id)
        {
            return LoadReportTemplate(" report_id=" + report_id);
        }

        public static ReportTemplate LoadReportTemplateByPk(int report_id, IDbConnection conn)
        {
            return LoadReportTemplate(" report_id=" + report_id, conn);
        }

        public void Save()
        {
            if (report_idChanged || report_nameChanged || report_queryChanged || is_activeChanged || create_dateChanged || created_byChanged || changed_dateChanged || changed_byChanged)
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
            if (report_idChanged || report_nameChanged || report_queryChanged || is_activeChanged || create_dateChanged || created_byChanged || changed_dateChanged || changed_byChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Report_template( report_id,report_name,report_query,is_active,create_date,created_by,changed_date,changed_by ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.report_id = ConnectionFactory.GetNextId();
                        qry.Append(this.report_id);
                    } qry.Append(",");
                    qry.Append(report_nameDbString + ",");
                    qry.Append(report_queryDbString + ",");
                    qry.Append(is_activeDbString + ",");
                    qry.Append(create_dateDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(changed_dateDbString + ",");
                    qry.Append(changed_byDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(report_idChanged || report_nameChanged || report_queryChanged || is_activeChanged || create_dateChanged || created_byChanged || changed_dateChanged || changed_byChanged))
                        return;
                    qry.Append("UPDATE Report_template set "); if (report_nameChanged)
                    {
                        qry.Append("report_name =" + report_nameDbString);
                        qry.Append(",");
                    }

                    if (report_queryChanged)
                    {
                        qry.Append("report_query =" + report_queryDbString);
                        qry.Append(",");
                    }

                    if (is_activeChanged)
                    {
                        qry.Append("is_active =" + is_activeDbString);
                        qry.Append(",");
                    }

                    if (create_dateChanged)
                    {
                        qry.Append("create_date =" + create_dateDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (changed_dateChanged)
                    {
                        qry.Append("changed_date =" + changed_dateDbString);
                        qry.Append(",");
                    }

                    if (changed_byChanged)
                    {
                        qry.Append("changed_by =" + changed_byDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("report_id = " + report_idDbString);
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
            cmd.CommandText = "DELETE Report_template where report_id = " + report_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteReportTemplates(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Report_template where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            report_id = 1,
            report_name = 2,
            report_query = 4,
            is_active = 8,
            create_date = 16,
            created_by = 32,
            changed_date = 64,
            changed_by = 128
        }
        #endregion
        public void BulkSave(List<ReportTemplate> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Report_template";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ReportTemplate.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ReportTemplate> transList, ref DataTable dt)
        {
            foreach (ReportTemplate tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["report_id"] = ConnectionFactory.GetNextId();
                Row["report_name"] = tran.ReportName;
                Row["report_query"] = tran.ReportQuery;
                Row["is_active"] = tran.IsActive;
                Row["create_date"] = tran.CreateDate;
                Row["created_by"] = tran.CreatedBy;
                Row["changed_date"] = tran.ChangedDate;
                Row["changed_by"] = tran.ChangedBy;
                dt.Rows.Add(Row);
            }
        }
    }
}