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
    public class DashboardGraph
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public DashboardGraph() { }
        public DashboardGraph(int id, string type, bool is_active, DateTime created_at, int created_by, int row_number, string query, string x_value, string y_value, string name)
        {
            this.type = type;
            this.typeChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.row_number = row_number;
            this.row_numberChanged = true;
            this.query = query;
            this.queryChanged = true;
            this.x_value = x_value;
            this.x_valueChanged = true;
            this.y_value = y_value;
            this.y_valueChanged = true;
            this.name = name;
            this.nameChanged = true;
        }
        public DashboardGraph(string type, bool is_active, DateTime created_at, int created_by, DateTime? modified_at, int? modified_by, int row_number, string query, string x_value, string y_value, string name, int? dashboard_id, string background_color)
        {
            this.type = type;
            this.typeChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_at = modified_at;
            this.modified_atChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.row_number = row_number;
            this.row_numberChanged = true;
            this.query = query;
            this.queryChanged = true;
            this.x_value = x_value;
            this.x_valueChanged = true;
            this.y_value = y_value;
            this.y_valueChanged = true;
            this.name = name;
            this.nameChanged = true;
            this.dashboard_id = dashboard_id;
            this.dashboard_idChanged = true;
            this.background_color = background_color;
            this.background_colorChanged = true;
        }
        private DashboardGraph(int id, string type, bool is_active, DateTime created_at, int created_by, DateTime? modified_at, int? modified_by, int row_number, string query, string x_value, string y_value, string name, int? dashboard_id, string background_color)
        {
            this.id = id;
            this.idChanged = true;
            this.type = type;
            this.typeChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_at = created_at;
            this.created_atChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_at = modified_at;
            this.modified_atChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.row_number = row_number;
            this.row_numberChanged = true;
            this.query = query;
            this.queryChanged = true;
            this.x_value = x_value;
            this.x_valueChanged = true;
            this.y_value = y_value;
            this.y_valueChanged = true;
            this.name = name;
            this.nameChanged = true;
            this.dashboard_id = dashboard_id;
            this.dashboard_idChanged = true;
            this.background_color = background_color;
            this.background_colorChanged = true;
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
        #region Type
        private bool typeChanged = false;
        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                typeChanged = true;
            }
        }
        private string typeDbString
        {
            get
            {
                if (this.type != null)
                    return string.Format("'{0}'", type);
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
        #region ModifiedAt
        private bool modified_atChanged = false;
        private DateTime? modified_at;
        public DateTime? ModifiedAt
        {
            get { return modified_at; }
            set
            {
                modified_at = value;
                modified_atChanged = true;
            }
        }
        private string modified_atDbString
        {
            get
            {
                if (this.modified_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", modified_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
        #region RowNumber
        private bool row_numberChanged = false;
        private int row_number;
        public int RowNumber
        {
            get { return row_number; }
            set
            {
                row_number = value;
                row_numberChanged = true;
            }
        }
        private string row_numberDbString
        {
            get
            {
                return row_number.ToString();
            }
        }
        #endregion
        #region Query
        private bool queryChanged = false;
        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                queryChanged = true;
            }
        }
        private string queryDbString
        {
            get
            {
                if (this.query != null)
                    return string.Format("'{0}'", query);
                else
                    return "null";
            }
        }
        #endregion
        #region XValue
        private bool x_valueChanged = false;
        private string x_value;
        public string XValue
        {
            get { return x_value; }
            set
            {
                x_value = value;
                x_valueChanged = true;
            }
        }
        private string x_valueDbString
        {
            get
            {
                if (this.x_value != null)
                    return string.Format("'{0}'", x_value);
                else
                    return "null";
            }
        }
        #endregion
        #region YValue
        private bool y_valueChanged = false;
        private string y_value;
        public string YValue
        {
            get { return y_value; }
            set
            {
                y_value = value;
                y_valueChanged = true;
            }
        }
        private string y_valueDbString
        {
            get
            {
                if (this.y_value != null)
                    return string.Format("'{0}'", y_value);
                else
                    return "null";
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
        #region DashboardId
        private bool dashboard_idChanged = false;
        private int? dashboard_id;
        public int? DashboardId
        {
            get { return dashboard_id; }
            set
            {
                dashboard_id = value;
                dashboard_idChanged = true;
            }
        }
        private string dashboard_idDbString
        {
            get
            {
                if (this.dashboard_id.HasValue)
                    return dashboard_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region BackgroundColor
        private bool background_colorChanged = false;
        private string background_color;
        public string BackgroundColor
        {
            get { return background_color; }
            set
            {
                background_color = value;
                background_colorChanged = true;
            }
        }
        private string background_colorDbString
        {
            get
            {
                if (this.background_color != null)
                    return string.Format("'{0}'", background_color);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region DashboardGraphReader
        public class DashboardGraphReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            DashboardGraph currentDashboardGraph;
            Columns columns;
            bool partialRead = false;
            private DashboardGraphReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public DashboardGraphReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public DashboardGraphReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentDashboardGraph; }

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
                    currentDashboardGraph = new DashboardGraph();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentDashboardGraph.id = (int)reader["id"];
                        if ((columns & Columns.type) == Columns.type && reader["type"] != DBNull.Value)
                            currentDashboardGraph.type = (string)reader["type"];
                        if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"] != DBNull.Value)
                            currentDashboardGraph.is_active = (bool)reader["is_active"];
                        if ((columns & Columns.created_at) == Columns.created_at && reader["created_at"] != DBNull.Value)
                            currentDashboardGraph.created_at = (DateTime)reader["created_at"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentDashboardGraph.created_by = (int)reader["created_by"];
                        if ((columns & Columns.modified_at) == Columns.modified_at && reader["modified_at"] != DBNull.Value)
                            currentDashboardGraph.modified_at = (DateTime?)reader["modified_at"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentDashboardGraph.modified_by = (int?)reader["modified_by"];
                        if ((columns & Columns.row_number) == Columns.row_number && reader["row_number"] != DBNull.Value)
                            currentDashboardGraph.row_number = (int)reader["row_number"];
                        if ((columns & Columns.query) == Columns.query && reader["query"] != DBNull.Value)
                            currentDashboardGraph.query = (string)reader["query"];
                        if ((columns & Columns.x_value) == Columns.x_value && reader["x_value"] != DBNull.Value)
                            currentDashboardGraph.x_value = (string)reader["x_value"];
                        if ((columns & Columns.y_value) == Columns.y_value && reader["y_value"] != DBNull.Value)
                            currentDashboardGraph.y_value = (string)reader["y_value"];
                        if ((columns & Columns.name) == Columns.name && reader["name"] != DBNull.Value)
                            currentDashboardGraph.name = (string)reader["name"];
                        if ((columns & Columns.dashboard_id) == Columns.dashboard_id && reader["dashboard_id"] != DBNull.Value)
                            currentDashboardGraph.dashboard_id = (int?)reader["dashboard_id"];
                        if ((columns & Columns.background_color) == Columns.background_color && reader["background_color"] != DBNull.Value)
                            currentDashboardGraph.background_color = (string)reader["background_color"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentDashboardGraph.id = (int)reader["id"];
                        if (reader["type"] != DBNull.Value)
                            currentDashboardGraph.type = (string)reader["type"];
                        if (reader["is_active"] != DBNull.Value)
                            currentDashboardGraph.is_active = (bool)reader["is_active"];
                        if (reader["created_at"] != DBNull.Value)
                            currentDashboardGraph.created_at = (DateTime)reader["created_at"];
                        if (reader["created_by"] != DBNull.Value)
                            currentDashboardGraph.created_by = (int)reader["created_by"];
                        if (reader["modified_at"] != DBNull.Value)
                            currentDashboardGraph.modified_at = (DateTime?)reader["modified_at"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentDashboardGraph.modified_by = (int?)reader["modified_by"];
                        if (reader["row_number"] != DBNull.Value)
                            currentDashboardGraph.row_number = (int)reader["row_number"];
                        if (reader["query"] != DBNull.Value)
                            currentDashboardGraph.query = (string)reader["query"];
                        if (reader["x_value"] != DBNull.Value)
                            currentDashboardGraph.x_value = (string)reader["x_value"];
                        if (reader["y_value"] != DBNull.Value)
                            currentDashboardGraph.y_value = (string)reader["y_value"];
                        if (reader["name"] != DBNull.Value)
                            currentDashboardGraph.name = (string)reader["name"];
                        if (reader["dashboard_id"] != DBNull.Value)
                            currentDashboardGraph.dashboard_id = (int?)reader["dashboard_id"];
                        if (reader["background_color"] != DBNull.Value)
                            currentDashboardGraph.background_color = (string)reader["background_color"];
                    }

                    currentDashboardGraph.isNewEntity = false;
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

            public DashboardGraph CurrentDashboardGraph
            {
                get { return currentDashboardGraph; }
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


        #region DashboardGraph functions

        public static DashboardGraphReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.type == (Columns.type & columns))
                qry.Append("type,");
            if (Columns.is_active == (Columns.is_active & columns))
                qry.Append("is_active,");
            if (Columns.created_at == (Columns.created_at & columns))
                qry.Append("created_at,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.modified_at == (Columns.modified_at & columns))
                qry.Append("modified_at,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.row_number == (Columns.row_number & columns))
                qry.Append("row_number,");
            if (Columns.query == (Columns.query & columns))
                qry.Append("query,");
            if (Columns.x_value == (Columns.x_value & columns))
                qry.Append("x_value,");
            if (Columns.y_value == (Columns.y_value & columns))
                qry.Append("y_value,");
            if (Columns.name == (Columns.name & columns))
                qry.Append("name,");
            if (Columns.dashboard_id == (Columns.dashboard_id & columns))
                qry.Append("dashboard_id,");
            if (Columns.background_color == (Columns.background_color & columns))
                qry.Append("background_color,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Dashboard_graph ");

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
            return new DashboardGraphReader(cmd.ExecuteReader(), conn, columns);
        }

        static public DashboardGraphReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static DashboardGraphReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,type,is_active,created_at,created_by,modified_at,modified_by,row_number,query,x_value,y_value,name,dashboard_id,background_color from Dashboard_graph ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new DashboardGraphReader(cmd.ExecuteReader(), conn);
        }

        static public DashboardGraphReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static DashboardGraph LoadDashboardGraph(string where)
        {
            DashboardGraphReader reader = DashboardGraph.ExecuteReader(where);
            DashboardGraph _dashboardgraph = null;
            if (reader.Read())
                _dashboardgraph = reader.CurrentDashboardGraph;
            reader.Close();
            return _dashboardgraph;
        }

        public static DashboardGraph LoadDashboardGraph(string where, IDbConnection conn)
        {
            DashboardGraphReader reader = DashboardGraph.ExecuteReader(where, conn);
            DashboardGraph _dashboardgraph = null;
            if (reader.Read())
                _dashboardgraph = reader.CurrentDashboardGraph;
            reader.Close(false);
            return _dashboardgraph;
        }

        public static DashboardGraph LoadDashboardGraphByPk(int id)
        {
            return LoadDashboardGraph(" id=" + id);
        }

        public static DashboardGraph LoadDashboardGraphByPk(int id, IDbConnection conn)
        {
            return LoadDashboardGraph(" id=" + id, conn);
        }

        public void Save()
        {
            if (idChanged || typeChanged || is_activeChanged || created_atChanged || created_byChanged || modified_atChanged || modified_byChanged || row_numberChanged || queryChanged || x_valueChanged || y_valueChanged || nameChanged || dashboard_idChanged || background_colorChanged)
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
            if (idChanged || typeChanged || is_activeChanged || created_atChanged || created_byChanged || modified_atChanged || modified_byChanged || row_numberChanged || queryChanged || x_valueChanged || y_valueChanged || nameChanged || dashboard_idChanged || background_colorChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Dashboard_graph( id,type,is_active,created_at,created_by,modified_at,modified_by,row_number,query,x_value,y_value,name,dashboard_id,background_color ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.id = ConnectionFactory.GetNextId();
                        qry.Append(this.id);
                    } qry.Append(",");
                    qry.Append(typeDbString + ",");
                    qry.Append(is_activeDbString + ",");
                    qry.Append(created_atDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(modified_atDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(row_numberDbString + ",");
                    qry.Append(queryDbString + ",");
                    qry.Append(x_valueDbString + ",");
                    qry.Append(y_valueDbString + ",");
                    qry.Append(nameDbString + ",");
                    qry.Append(dashboard_idDbString + ",");
                    qry.Append(background_colorDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(idChanged || typeChanged || is_activeChanged || created_atChanged || created_byChanged || modified_atChanged || modified_byChanged || row_numberChanged || queryChanged || x_valueChanged || y_valueChanged || nameChanged || dashboard_idChanged || background_colorChanged))
                        return;
                    qry.Append("UPDATE Dashboard_graph set "); if (typeChanged)
                    {
                        qry.Append("type =" + typeDbString);
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

                    if (modified_atChanged)
                    {
                        qry.Append("modified_at =" + modified_atDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }

                    if (row_numberChanged)
                    {
                        qry.Append("row_number =" + row_numberDbString);
                        qry.Append(",");
                    }

                    if (queryChanged)
                    {
                        qry.Append("query =" + queryDbString);
                        qry.Append(",");
                    }

                    if (x_valueChanged)
                    {
                        qry.Append("x_value =" + x_valueDbString);
                        qry.Append(",");
                    }

                    if (y_valueChanged)
                    {
                        qry.Append("y_value =" + y_valueDbString);
                        qry.Append(",");
                    }

                    if (nameChanged)
                    {
                        qry.Append("name =" + nameDbString);
                        qry.Append(",");
                    }

                    if (dashboard_idChanged)
                    {
                        qry.Append("dashboard_id =" + dashboard_idDbString);
                        qry.Append(",");
                    }

                    if (background_colorChanged)
                    {
                        qry.Append("background_color =" + background_colorDbString);
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
            cmd.CommandText = "DELETE Dashboard_graph where id = " + id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteDashboardGraphs(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Dashboard_graph where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            type = 2,
            is_active = 4,
            created_at = 8,
            created_by = 16,
            modified_at = 32,
            modified_by = 64,
            row_number = 128,
            query = 256,
            x_value = 512,
            y_value = 1024,
            name = 2048,
            dashboard_id = 4096,
            background_color = 8192
        }
        #endregion
        public void BulkSave(List<DashboardGraph> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Dashboard_graph";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(DashboardGraph.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<DashboardGraph> transList, ref DataTable dt)
        {
            foreach (DashboardGraph tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = ConnectionFactory.GetNextId();
                Row["type"] = tran.Type;
                Row["is_active"] = tran.IsActive;
                Row["created_at"] = tran.CreatedAt;
                Row["created_by"] = tran.CreatedBy;
                Row["modified_at"] = tran.ModifiedAt;
                Row["modified_by"] = tran.ModifiedBy;
                Row["row_number"] = tran.RowNumber;
                Row["query"] = tran.Query;
                Row["x_value"] = tran.XValue;
                Row["y_value"] = tran.YValue;
                Row["name"] = tran.Name;
                Row["dashboard_id"] = tran.DashboardId;
                Row["background_color"] = tran.BackgroundColor;
                dt.Rows.Add(Row);
            }
        }
    }
}