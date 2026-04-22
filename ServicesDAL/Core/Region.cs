using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesDAL
{
    [Serializable()]
    public class Region
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Region() { }
        public Region(long region_id, string region_name, bool is_active, long created_by, DateTime creation_time)
        {
            this.region_name = region_name;
            this.region_nameChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
        }
        public Region(string region_name, long? parent_region_id, string location, string country, long? region_cit_id, bool is_active, long created_by, long? modified_by, DateTime creation_time)
        {
            this.region_name = region_name;
            this.region_nameChanged = true;
            this.parent_region_id = parent_region_id;
            this.parent_region_idChanged = true;
            this.location = location;
            this.locationChanged = true;
            this.country = country;
            this.countryChanged = true;
            this.region_cit_id = region_cit_id;
            this.region_cit_idChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
        }
        private Region(long region_id, string region_name, long? parent_region_id, string location, string country, long? region_cit_id, bool is_active, long created_by, long? modified_by, DateTime creation_time)
        {
            this.region_id = region_id;
            this.region_idChanged = true;
            this.region_name = region_name;
            this.region_nameChanged = true;
            this.parent_region_id = parent_region_id;
            this.parent_region_idChanged = true;
            this.location = location;
            this.locationChanged = true;
            this.country = country;
            this.countryChanged = true;
            this.region_cit_id = region_cit_id;
            this.region_cit_idChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
        }

        #region members and properties for columns

        #region RegionId
        private bool region_idChanged = false;
        private long region_id;
        public long RegionId
        {
            get { return region_id; }
            set
            {
                region_id = value;
                region_idChanged = true;
            }
        }
        private string region_idDbString
        {
            get
            {
                return region_id.ToString();
            }
        }
        #endregion
        #region RegionName
        private bool region_nameChanged = false;
        private string region_name;
        public string RegionName
        {
            get { return region_name; }
            set
            {
                region_name = value;
                region_nameChanged = true;
            }
        }
        private string region_nameDbString
        {
            get
            {
                if (this.region_name != null)
                    return string.Format("'{0}'", region_name);
                else
                    return "null";
            }
        }
        #endregion
        #region ParentRegionId
        private bool parent_region_idChanged = false;
        private long? parent_region_id;
        public long? ParentRegionId
        {
            get { return parent_region_id; }
            set
            {
                parent_region_id = value;
                parent_region_idChanged = true;
            }
        }
        private string parent_region_idDbString
        {
            get
            {
                if (this.parent_region_id.HasValue)
                    return parent_region_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Location
        private bool locationChanged = false;
        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                locationChanged = true;
            }
        }
        private string locationDbString
        {
            get
            {
                if (this.location != null)
                    return string.Format("'{0}'", location);
                else
                    return "null";
            }
        }
        #endregion
        #region Country
        private bool countryChanged = false;
        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                countryChanged = true;
            }
        }
        private string countryDbString
        {
            get
            {
                if (this.country != null)
                    return string.Format("'{0}'", country);
                else
                    return "null";
            }
        }
        #endregion
        #region RegionCitId
        private bool region_cit_idChanged = false;
        private long? region_cit_id;
        public long? RegionCitId
        {
            get { return region_cit_id; }
            set
            {
                region_cit_id = value;
                region_cit_idChanged = true;
            }
        }
        private string region_cit_idDbString
        {
            get
            {
                if (this.region_cit_id.HasValue)
                    return region_cit_id.ToString();
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
        #region CreatedBy
        private bool created_byChanged = false;
        private long created_by;
        public long CreatedBy
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
        #region ModifiedBy
        private bool modified_byChanged = false;
        private long? modified_by;
        public long? ModifiedBy
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
        #region CreationTime
        private bool creation_timeChanged = false;
        private DateTime creation_time;
        public DateTime CreationTime
        {
            get { return creation_time; }
            set
            {
                creation_time = value;
                creation_timeChanged = true;
            }
        }
        private string creation_timeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #endregion

        #region RegionReader
        public class RegionReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Region currentRegion;
            Columns columns;
            bool partialRead = false;
            private RegionReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public RegionReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public RegionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentRegion; }

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
                    currentRegion = new Region();
                    if (partialRead)
                    {
                        if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"] != DBNull.Value)
                            currentRegion.region_id = (long)reader["region_id"];
                        if ((columns & Columns.region_name) == Columns.region_name && reader["region_name"] != DBNull.Value)
                            currentRegion.region_name = (string)reader["region_name"];
                        if ((columns & Columns.parent_region_id) == Columns.parent_region_id && reader["parent_region_id"] != DBNull.Value)
                            currentRegion.parent_region_id = (long?)reader["parent_region_id"];
                        if ((columns & Columns.location) == Columns.location && reader["location"] != DBNull.Value)
                            currentRegion.location = (string)reader["location"];
                        if ((columns & Columns.country) == Columns.country && reader["country"] != DBNull.Value)
                            currentRegion.country = (string)reader["country"];
                        if ((columns & Columns.region_cit_id) == Columns.region_cit_id && reader["region_cit_id"] != DBNull.Value)
                            currentRegion.region_cit_id = (long?)reader["region_cit_id"];
                        if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"] != DBNull.Value)
                            currentRegion.is_active = (bool)reader["is_active"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentRegion.created_by = (long)reader["created_by"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentRegion.modified_by = (long?)reader["modified_by"];
                        if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"] != DBNull.Value)
                            currentRegion.creation_time = (DateTime)reader["creation_time"];

                    }
                    else
                    {
                        if (reader["region_id"] != DBNull.Value)
                            currentRegion.region_id = (long)reader["region_id"];
                        if (reader["region_name"] != DBNull.Value)
                            currentRegion.region_name = (string)reader["region_name"];
                        if (reader["parent_region_id"] != DBNull.Value)
                            currentRegion.parent_region_id = (long?)reader["parent_region_id"];
                        if (reader["location"] != DBNull.Value)
                            currentRegion.location = (string)reader["location"];
                        if (reader["country"] != DBNull.Value)
                            currentRegion.country = (string)reader["country"];
                        if (reader["region_cit_id"] != DBNull.Value)
                            currentRegion.region_cit_id = (long?)reader["region_cit_id"];
                        if (reader["is_active"] != DBNull.Value)
                            currentRegion.is_active = (bool)reader["is_active"];
                        if (reader["created_by"] != DBNull.Value)
                            currentRegion.created_by = (long)reader["created_by"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentRegion.modified_by = (long?)reader["modified_by"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentRegion.creation_time = (DateTime)reader["creation_time"];
                    }

                    currentRegion.isNewEntity = false;
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

            public Region CurrentRegion
            {
                get { return currentRegion; }
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


        #region Region functions

        public static RegionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.region_id == (Columns.region_id & columns))
                qry.Append("region_id,");
            if (Columns.region_name == (Columns.region_name & columns))
                qry.Append("region_name,");
            if (Columns.parent_region_id == (Columns.parent_region_id & columns))
                qry.Append("parent_region_id,");
            if (Columns.location == (Columns.location & columns))
                qry.Append("location,");
            if (Columns.country == (Columns.country & columns))
                qry.Append("country,");
            if (Columns.region_cit_id == (Columns.region_cit_id & columns))
                qry.Append("region_cit_id,");
            if (Columns.is_active == (Columns.is_active & columns))
                qry.Append("is_active,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Region ");

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
            return new RegionReader(cmd.ExecuteReader(), conn, columns);
        }

        static public RegionReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static RegionReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectregion_id,region_name,parent_region_id,location,country,region_cit_id,is_active,created_by,modified_by,creation_timefrom Region ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new RegionReader(cmd.ExecuteReader(), conn);
        }

        static public RegionReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static Region LoadRegion(string where)
        {
            RegionReader reader = Region.ExecuteReader(where);
            Region _region = null;
            if (reader.Read())
                _region = reader.CurrentRegion;
            reader.Close();
            return _region;
        }

        public static Region LoadRegion(string where, IDbConnection conn)
        {
            RegionReader reader = Region.ExecuteReader(where, conn);
            Region _region = null;
            if (reader.Read())
                _region = reader.CurrentRegion;
            reader.Close(false);
            return _region;
        }

        public static Region LoadRegionByPk(long region_id)
        {
            return LoadRegion("region_id=" + region_id);
        }

        public static Region LoadRegionByPk(long region_id, IDbConnection conn)
        {
            return LoadRegion(" region_id=" + region_id, conn);
        }

        public void Save()
        {
            if (region_idChanged || region_nameChanged || parent_region_idChanged || locationChanged || countryChanged || region_cit_idChanged || is_activeChanged || created_byChanged || modified_byChanged || creation_timeChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Core).CreateCommand());
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
            if (region_idChanged || region_nameChanged || parent_region_idChanged || locationChanged || countryChanged || region_cit_idChanged || is_activeChanged || created_byChanged || modified_byChanged || creation_timeChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Region(region_id,region_name,parent_region_id,location,country,region_cit_id,is_active,created_by,modified_by,creation_time) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.region_id = ConnectionFactory.GetNextId(DatabaseName.Core);
                        qry.Append(this.region_id);
                    }
                    qry.Append(",");
                    qry.Append(region_nameDbString + ",");
                    qry.Append(parent_region_idDbString + ",");
                    qry.Append(locationDbString + ",");
                    qry.Append(countryDbString + ",");
                    qry.Append(region_cit_idDbString + ",");
                    qry.Append(is_activeDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(creation_timeDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(region_idChanged || region_nameChanged || parent_region_idChanged || locationChanged || countryChanged || region_cit_idChanged || is_activeChanged || created_byChanged || modified_byChanged || creation_timeChanged))
                        return;
                    qry.Append("UPDATE Region set "); if (region_nameChanged)
                    {
                        qry.Append("region_name =" + region_nameDbString);
                        qry.Append(",");
                    }

                    if (parent_region_idChanged)
                    {
                        qry.Append("parent_region_id =" + parent_region_idDbString);
                        qry.Append(",");
                    }

                    if (locationChanged)
                    {
                        qry.Append("location =" + locationDbString);
                        qry.Append(",");
                    }

                    if (countryChanged)
                    {
                        qry.Append("country =" + countryDbString);
                        qry.Append(",");
                    }

                    if (region_cit_idChanged)
                    {
                        qry.Append("region_cit_id =" + region_cit_idDbString);
                        qry.Append(",");
                    }

                    if (is_activeChanged)
                    {
                        qry.Append("is_active =" + is_activeDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }

                    if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("region_id = " + region_idDbString);
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Region whereregion_id= " + region_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteRegions(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Region where " + where, DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            region_id = 0,
            region_name = 1,
            parent_region_id = 2,
            location = 3,
            country = 4,
            region_cit_id = 5,
            is_active = 6,
            created_by = 7,
            modified_by = 8,
            creation_time = 9
        }
        #endregion
        public DataTable BulkSave(List<Region> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Region";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Region.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Region> transList, ref DataTable dt)
        {
            foreach (Region tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["region_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                Row["region_name"] = tran.RegionName;
                Row["parent_region_id"] = tran.ParentRegionId;
                Row["location"] = tran.Location;
                Row["country"] = tran.Country;
                Row["region_cit_id"] = tran.RegionCitId;
                Row["is_active"] = tran.IsActive;
                Row["created_by"] = tran.CreatedBy;
                Row["modified_by"] = tran.ModifiedBy;
                Row["creation_time"] = tran.CreationTime;
                dt.Rows.Add(Row);
            }
        }
    }
}
