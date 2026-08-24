

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
    public class Package
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Package() { }
        public Package(int package_id)
        {
        }
        public Package(string package_title, string package_physcial_path, DateTime? package_creation_time, DateTime? package_modification_time, int? created_by, int? modified_by, string package_hash, int? package_size)
        {
            this.package_title = package_title;
            this.package_titleChanged = true;
            this.package_physcial_path = package_physcial_path;
            this.package_physcial_pathChanged = true;
            this.package_creation_time = package_creation_time;
            this.package_creation_timeChanged = true;
            this.package_modification_time = package_modification_time;
            this.package_modification_timeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.package_hash = package_hash;
            this.package_hashChanged = true;
            this.package_size = package_size;
            this.package_sizeChanged = true;
        }
        private Package(int package_id, string package_title, string package_physcial_path, DateTime? package_creation_time, DateTime? package_modification_time, int? created_by, int? modified_by, string package_hash, int? package_size)
        {
            this.package_id = package_id;
            this.package_idChanged = true;
            this.package_title = package_title;
            this.package_titleChanged = true;
            this.package_physcial_path = package_physcial_path;
            this.package_physcial_pathChanged = true;
            this.package_creation_time = package_creation_time;
            this.package_creation_timeChanged = true;
            this.package_modification_time = package_modification_time;
            this.package_modification_timeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.package_hash = package_hash;
            this.package_hashChanged = true;
            this.package_size = package_size;
            this.package_sizeChanged = true;
        }

        #region members and properties for columns

        #region PackageId
        private bool package_idChanged = false;
        private int package_id;
        public int PackageId
        {
            get { return package_id; }
            set
            {
                package_id = value;
                package_idChanged = true;
            }
        }
        private string package_idDbString
        {
            get
            {
                return package_id.ToString();
            }
        }
        #endregion
        #region PackageTitle
        private bool package_titleChanged = false;
        private string package_title;
        public string PackageTitle
        {
            get { return package_title; }
            set
            {
                package_title = value;
                package_titleChanged = true;
            }
        }
        private string package_titleDbString
        {
            get
            {
                if (this.package_title != null)
                    return string.Format("'{0}'", package_title);
                else
                    return "null";
            }
        }
        #endregion
        #region PackagePhyscialPath
        private bool package_physcial_pathChanged = false;
        private string package_physcial_path;
        public string PackagePhyscialPath
        {
            get { return package_physcial_path; }
            set
            {
                package_physcial_path = value;
                package_physcial_pathChanged = true;
            }
        }
        private string package_physcial_pathDbString
        {
            get
            {
                if (this.package_physcial_path != null)
                    return string.Format("'{0}'", package_physcial_path);
                else
                    return "null";
            }
        }
        #endregion
        #region PackageCreationTime
        private bool package_creation_timeChanged = false;
        private DateTime? package_creation_time;
        public DateTime? PackageCreationTime
        {
            get { return package_creation_time; }
            set
            {
                package_creation_time = value;
                package_creation_timeChanged = true;
            }
        }
        private string package_creation_timeDbString
        {
            get
            {
                if (this.package_creation_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", package_creation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region PackageModificationTime
        private bool package_modification_timeChanged = false;
        private DateTime? package_modification_time;
        public DateTime? PackageModificationTime
        {
            get { return package_modification_time; }
            set
            {
                package_modification_time = value;
                package_modification_timeChanged = true;
            }
        }
        private string package_modification_timeDbString
        {
            get
            {
                if (this.package_modification_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", package_modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private int? created_by;
        public int? CreatedBy
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
                if (this.created_by.HasValue)
                    return created_by.ToString();
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
        #region PackageHash
        private bool package_hashChanged = false;
        private string package_hash;
        public string PackageHash
        {
            get { return package_hash; }
            set
            {
                package_hash = value;
                package_hashChanged = true;
            }
        }
        private string package_hashDbString
        {
            get
            {
                if (this.package_hash != null)
                    return string.Format("'{0}'", package_hash);
                else
                    return "null";
            }
        }
        #endregion
        #region PackageSize
        private bool package_sizeChanged = false;
        private int? package_size;
        public int? PackageSize
        {
            get { return package_size; }
            set
            {
                package_size = value;
                package_sizeChanged = true;
            }
        }
        private string package_sizeDbString
        {
            get
            {
                if (this.package_size.HasValue)
                    return package_size.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region PackageReader
        public class PackageReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Package currentPackage;
            Columns columns;
            bool partialRead = false;
            private PackageReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public PackageReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public PackageReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentPackage; }

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
                    currentPackage = new Package();
                    if (partialRead)
                    {
                        if ((columns & Columns.package_id) == Columns.package_id && reader["package_id"] != DBNull.Value)
                            currentPackage.package_id = (int)reader["package_id"];
                        if ((columns & Columns.package_title) == Columns.package_title && reader["package_title"] != DBNull.Value)
                            currentPackage.package_title = (string)reader["package_title"];
                        if ((columns & Columns.package_physcial_path) == Columns.package_physcial_path && reader["package_physcial_path"] != DBNull.Value)
                            currentPackage.package_physcial_path = (string)reader["package_physcial_path"];
                        if ((columns & Columns.package_creation_time) == Columns.package_creation_time && reader["package_creation_time"] != DBNull.Value)
                            currentPackage.package_creation_time = (DateTime?)reader["package_creation_time"];
                        if ((columns & Columns.package_modification_time) == Columns.package_modification_time && reader["package_modification_time"] != DBNull.Value)
                            currentPackage.package_modification_time = (DateTime?)reader["package_modification_time"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentPackage.created_by = (int?)reader["created_by"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentPackage.modified_by = (int?)reader["modified_by"];
                        if ((columns & Columns.package_hash) == Columns.package_hash && reader["package_hash"] != DBNull.Value)
                            currentPackage.package_hash = (string)reader["package_hash"];
                        if ((columns & Columns.package_size) == Columns.package_size && reader["package_size"] != DBNull.Value)
                            currentPackage.package_size = (int?)reader["package_size"];

                    }
                    else
                    {
                        if (reader["package_id"] != DBNull.Value)
                            currentPackage.package_id = (int)reader["package_id"];
                        if (reader["package_title"] != DBNull.Value)
                            currentPackage.package_title = (string)reader["package_title"];
                        if (reader["package_physcial_path"] != DBNull.Value)
                            currentPackage.package_physcial_path = (string)reader["package_physcial_path"];
                        if (reader["package_creation_time"] != DBNull.Value)
                            currentPackage.package_creation_time = (DateTime?)reader["package_creation_time"];
                        if (reader["package_modification_time"] != DBNull.Value)
                            currentPackage.package_modification_time = (DateTime?)reader["package_modification_time"];
                        if (reader["created_by"] != DBNull.Value)
                            currentPackage.created_by = (int?)reader["created_by"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentPackage.modified_by = (int?)reader["modified_by"];
                        if (reader["package_hash"] != DBNull.Value)
                            currentPackage.package_hash = (string)reader["package_hash"];
                        if (reader["package_size"] != DBNull.Value)
                            currentPackage.package_size = (int?)reader["package_size"];
                    }

                    currentPackage.isNewEntity = false;
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

            public Package CurrentPackage
            {
                get { return currentPackage; }
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


        #region Package functions

        public static PackageReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.package_id == (Columns.package_id & columns))
                qry.Append("package_id,");
            if (Columns.package_title == (Columns.package_title & columns))
                qry.Append("package_title,");
            if (Columns.package_physcial_path == (Columns.package_physcial_path & columns))
                qry.Append("package_physcial_path,");
            if (Columns.package_creation_time == (Columns.package_creation_time & columns))
                qry.Append("package_creation_time,");
            if (Columns.package_modification_time == (Columns.package_modification_time & columns))
                qry.Append("package_modification_time,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.package_hash == (Columns.package_hash & columns))
                qry.Append("package_hash,");
            if (Columns.package_size == (Columns.package_size & columns))
                qry.Append("package_size,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Package ");

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
            return new PackageReader(cmd.ExecuteReader(), conn, columns);
        }

        static public PackageReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static PackageReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select package_id,package_title,package_physcial_path,package_creation_time,package_modification_time,created_by,modified_by,package_hash,package_size from Package ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new PackageReader(cmd.ExecuteReader(), conn);
        }

        static public PackageReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static Package LoadPackage(string where)
        {
            PackageReader reader = Package.ExecuteReader(where);
            Package _package = null;
            if (reader.Read())
                _package = reader.CurrentPackage;
            reader.Close();
            return _package;
        }

        public static Package LoadPackage(string where, IDbConnection conn)
        {
            PackageReader reader = Package.ExecuteReader(where, conn);
            Package _package = null;
            if (reader.Read())
                _package = reader.CurrentPackage;
            reader.Close(false);
            return _package;
        }

        public static Package LoadPackageByPk(int package_id)
        {
            return LoadPackage("package_id=" + package_id);
        }

        public static Package LoadPackageByPk(int package_id, IDbConnection conn)
        {
            return LoadPackage(" package_id=" + package_id, conn);
        }

        public void Save()
        {
            if (package_idChanged || package_titleChanged || package_physcial_pathChanged || package_creation_timeChanged || package_modification_timeChanged || created_byChanged || modified_byChanged || package_hashChanged || package_sizeChanged)
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
            if (package_idChanged || package_titleChanged || package_physcial_pathChanged || package_creation_timeChanged || package_modification_timeChanged || created_byChanged || modified_byChanged || package_hashChanged || package_sizeChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Package(package_id,package_title,package_physcial_path,package_creation_time,package_modification_time,created_by,modified_by,package_hash,package_size) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.package_id = ConnectionFactory.GetNextId();
                        qry.Append(this.package_id);
                    } qry.Append(",");
                    qry.Append(package_titleDbString + ",");
                    qry.Append(package_physcial_pathDbString + ",");
                    qry.Append(package_creation_timeDbString + ",");
                    qry.Append(package_modification_timeDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(package_hashDbString + ",");
                    qry.Append(package_sizeDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(package_idChanged || package_titleChanged || package_physcial_pathChanged || package_creation_timeChanged || package_modification_timeChanged || created_byChanged || modified_byChanged || package_hashChanged || package_sizeChanged))
                        return;
                    qry.Append("UPDATE Package set "); if (package_titleChanged)
                    {
                        qry.Append("package_title =" + package_titleDbString);
                        qry.Append(",");
                    }

                    if (package_physcial_pathChanged)
                    {
                        qry.Append("package_physcial_path =" + package_physcial_pathDbString);
                        qry.Append(",");
                    }

                    if (package_creation_timeChanged)
                    {
                        qry.Append("package_creation_time =" + package_creation_timeDbString);
                        qry.Append(",");
                    }

                    if (package_modification_timeChanged)
                    {
                        qry.Append("package_modification_time =" + package_modification_timeDbString);
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

                    if (package_hashChanged)
                    {
                        qry.Append("package_hash =" + package_hashDbString);
                        qry.Append(",");
                    }

                    if (package_sizeChanged)
                    {
                        qry.Append("package_size =" + package_sizeDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("package_id = " + package_idDbString);
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
            cmd.CommandText = "DELETE Package wherepackage_id= " + package_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeletePackages(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Package where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            package_id = 1,
            package_title = 2,
            package_physcial_path = 4,
            package_creation_time = 8,
            package_modification_time = 16,
            created_by = 32,
            modified_by = 64,
            package_hash = 128,
            package_size = 256
        }
        #endregion
        public void BulkSave(List<Package> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Package";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Package.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Package> transList, ref DataTable dt)
        {
            foreach (Package tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["package_id"] = ConnectionFactory.GetNextId();
                Row["package_title"] = tran.PackageTitle;
                Row["package_physcial_path"] = tran.PackagePhyscialPath;
                Row["package_creation_time"] = tran.PackageCreationTime;
                Row["package_modification_time"] = tran.PackageModificationTime;
                Row["created_by"] = tran.CreatedBy;
                Row["modified_by"] = tran.ModifiedBy;
                Row["package_hash"] = tran.PackageHash;
                Row["package_size"] = tran.PackageSize;
                dt.Rows.Add(Row);
            }
        }
    }
}


