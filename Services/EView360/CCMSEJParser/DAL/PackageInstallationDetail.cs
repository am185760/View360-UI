using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;
using System.Data.SqlClient;

namespace Avanza.iSuite.DAL
{
    [Serializable()]
    public class PackageInstallationDetail
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public PackageInstallationDetail() { }
        public PackageInstallationDetail(int package_installation_detail_id, int package_id)
        {
            this.package_id = package_id;
            this.package_idChanged = true;
        }
        public PackageInstallationDetail(int package_id, string process_install_command, string process_install_logfile, string process_install_keyword, string process_uninstall_command, string process_uninstall_logfile, string process_uninstall_keyword, bool? process_requires_restart, string extract_replace_path)
        {
            this.package_id = package_id;
            this.package_idChanged = true;
            this.process_install_command = process_install_command;
            this.process_install_commandChanged = true;
            this.process_install_logfile = process_install_logfile;
            this.process_install_logfileChanged = true;
            this.process_install_keyword = process_install_keyword;
            this.process_install_keywordChanged = true;
            this.process_uninstall_command = process_uninstall_command;
            this.process_uninstall_commandChanged = true;
            this.process_uninstall_logfile = process_uninstall_logfile;
            this.process_uninstall_logfileChanged = true;
            this.process_uninstall_keyword = process_uninstall_keyword;
            this.process_uninstall_keywordChanged = true;
            this.process_requires_restart = process_requires_restart;
            this.process_requires_restartChanged = true;
            this.extract_replace_path = extract_replace_path;
            this.extract_replace_pathChanged = true;
        }
        private PackageInstallationDetail(int package_installation_detail_id, int package_id, string process_install_command, string process_install_logfile, string process_install_keyword, string process_uninstall_command, string process_uninstall_logfile, string process_uninstall_keyword, bool? process_requires_restart, string extract_replace_path)
        {
            this.package_installation_detail_id = package_installation_detail_id;
            this.package_installation_detail_idChanged = true;
            this.package_id = package_id;
            this.package_idChanged = true;
            this.process_install_command = process_install_command;
            this.process_install_commandChanged = true;
            this.process_install_logfile = process_install_logfile;
            this.process_install_logfileChanged = true;
            this.process_install_keyword = process_install_keyword;
            this.process_install_keywordChanged = true;
            this.process_uninstall_command = process_uninstall_command;
            this.process_uninstall_commandChanged = true;
            this.process_uninstall_logfile = process_uninstall_logfile;
            this.process_uninstall_logfileChanged = true;
            this.process_uninstall_keyword = process_uninstall_keyword;
            this.process_uninstall_keywordChanged = true;
            this.process_requires_restart = process_requires_restart;
            this.process_requires_restartChanged = true;
            this.extract_replace_path = extract_replace_path;
            this.extract_replace_pathChanged = true;
        }

        #region members and properties for columns

        #region PackageInstallationDetailId
        private bool package_installation_detail_idChanged = false;
        private int package_installation_detail_id;
        public int PackageInstallationDetailId
        {
            get { return package_installation_detail_id; }
            set
            {
                package_installation_detail_id = value;
                package_installation_detail_idChanged = true;
            }
        }
        private string package_installation_detail_idDbString
        {
            get
            {
                return package_installation_detail_id.ToString();
            }
        }
        #endregion
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
        #region ProcessInstallCommand
        private bool process_install_commandChanged = false;
        private string process_install_command;
        public string ProcessInstallCommand
        {
            get { return process_install_command; }
            set
            {
                process_install_command = value;
                process_install_commandChanged = true;
            }
        }
        private string process_install_commandDbString
        {
            get
            {
                if (this.process_install_command != null)
                    return string.Format("'{0}'", process_install_command);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessInstallLogfile
        private bool process_install_logfileChanged = false;
        private string process_install_logfile;
        public string ProcessInstallLogfile
        {
            get { return process_install_logfile; }
            set
            {
                process_install_logfile = value;
                process_install_logfileChanged = true;
            }
        }
        private string process_install_logfileDbString
        {
            get
            {
                if (this.process_install_logfile != null)
                    return string.Format("'{0}'", process_install_logfile);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessInstallKeyword
        private bool process_install_keywordChanged = false;
        private string process_install_keyword;
        public string ProcessInstallKeyword
        {
            get { return process_install_keyword; }
            set
            {
                process_install_keyword = value;
                process_install_keywordChanged = true;
            }
        }
        private string process_install_keywordDbString
        {
            get
            {
                if (this.process_install_keyword != null)
                    return string.Format("'{0}'", process_install_keyword);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessUninstallCommand
        private bool process_uninstall_commandChanged = false;
        private string process_uninstall_command;
        public string ProcessUninstallCommand
        {
            get { return process_uninstall_command; }
            set
            {
                process_uninstall_command = value;
                process_uninstall_commandChanged = true;
            }
        }
        private string process_uninstall_commandDbString
        {
            get
            {
                if (this.process_uninstall_command != null)
                    return string.Format("'{0}'", process_uninstall_command);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessUninstallLogfile
        private bool process_uninstall_logfileChanged = false;
        private string process_uninstall_logfile;
        public string ProcessUninstallLogfile
        {
            get { return process_uninstall_logfile; }
            set
            {
                process_uninstall_logfile = value;
                process_uninstall_logfileChanged = true;
            }
        }
        private string process_uninstall_logfileDbString
        {
            get
            {
                if (this.process_uninstall_logfile != null)
                    return string.Format("'{0}'", process_uninstall_logfile);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessUninstallKeyword
        private bool process_uninstall_keywordChanged = false;
        private string process_uninstall_keyword;
        public string ProcessUninstallKeyword
        {
            get { return process_uninstall_keyword; }
            set
            {
                process_uninstall_keyword = value;
                process_uninstall_keywordChanged = true;
            }
        }
        private string process_uninstall_keywordDbString
        {
            get
            {
                if (this.process_uninstall_keyword != null)
                    return string.Format("'{0}'", process_uninstall_keyword);
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessRequiresRestart
        private bool process_requires_restartChanged = false;
        private bool? process_requires_restart;
        public bool? ProcessRequiresRestart
        {
            get { return process_requires_restart; }
            set
            {
                process_requires_restart = value;
                process_requires_restartChanged = true;
            }
        }
        private string process_requires_restartDbString
        {
            get
            {
                if (this.process_requires_restart.HasValue)
                    return process_requires_restart.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region ExtractReplacePath
        private bool extract_replace_pathChanged = false;
        private string extract_replace_path;
        public string ExtractReplacePath
        {
            get { return extract_replace_path; }
            set
            {
                extract_replace_path = value;
                extract_replace_pathChanged = true;
            }
        }
        private string extract_replace_pathDbString
        {
            get
            {
                if (this.extract_replace_path != null)
                    return string.Format("'{0}'", extract_replace_path);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region PackageInstallationDetailReader
        public class PackageInstallationDetailReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            PackageInstallationDetail currentPackageInstallationDetail;
            Columns columns;
            bool partialRead = false;
            private PackageInstallationDetailReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public PackageInstallationDetailReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public PackageInstallationDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentPackageInstallationDetail; }

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
                    currentPackageInstallationDetail = new PackageInstallationDetail();
                    if (partialRead)
                    {
                        if ((columns & Columns.package_installation_detail_id) == Columns.package_installation_detail_id && reader["package_installation_detail_id"] != DBNull.Value)
                            currentPackageInstallationDetail.package_installation_detail_id = (int)reader["package_installation_detail_id"];
                        if ((columns & Columns.package_id) == Columns.package_id && reader["package_id"] != DBNull.Value)
                            currentPackageInstallationDetail.package_id = (int)reader["package_id"];
                        if ((columns & Columns.process_install_command) == Columns.process_install_command && reader["process_install_command"] != DBNull.Value)
                            currentPackageInstallationDetail.process_install_command = (string)reader["process_install_command"];
                        if ((columns & Columns.process_install_logfile) == Columns.process_install_logfile && reader["process_install_logfile"] != DBNull.Value)
                            currentPackageInstallationDetail.process_install_logfile = (string)reader["process_install_logfile"];
                        if ((columns & Columns.process_install_keyword) == Columns.process_install_keyword && reader["process_install_keyword"] != DBNull.Value)
                            currentPackageInstallationDetail.process_install_keyword = (string)reader["process_install_keyword"];
                        if ((columns & Columns.process_uninstall_command) == Columns.process_uninstall_command && reader["process_uninstall_command"] != DBNull.Value)
                            currentPackageInstallationDetail.process_uninstall_command = (string)reader["process_uninstall_command"];
                        if ((columns & Columns.process_uninstall_logfile) == Columns.process_uninstall_logfile && reader["process_uninstall_logfile"] != DBNull.Value)
                            currentPackageInstallationDetail.process_uninstall_logfile = (string)reader["process_uninstall_logfile"];
                        if ((columns & Columns.process_uninstall_keyword) == Columns.process_uninstall_keyword && reader["process_uninstall_keyword"] != DBNull.Value)
                            currentPackageInstallationDetail.process_uninstall_keyword = (string)reader["process_uninstall_keyword"];
                        if ((columns & Columns.process_requires_restart) == Columns.process_requires_restart && reader["process_requires_restart"] != DBNull.Value)
                            currentPackageInstallationDetail.process_requires_restart = (bool?)reader["process_requires_restart"];
                        if ((columns & Columns.extract_replace_path) == Columns.extract_replace_path && reader["extract_replace_path"] != DBNull.Value)
                            currentPackageInstallationDetail.extract_replace_path = (string)reader["extract_replace_path"];

                    }
                    else
                    {
                        if (reader["package_installation_detail_id"] != DBNull.Value)
                            currentPackageInstallationDetail.package_installation_detail_id = (int)reader["package_installation_detail_id"];
                        if (reader["package_id"] != DBNull.Value)
                            currentPackageInstallationDetail.package_id = (int)reader["package_id"];
                        if (reader["process_install_command"] != DBNull.Value)
                            currentPackageInstallationDetail.process_install_command = (string)reader["process_install_command"];
                        if (reader["process_install_logfile"] != DBNull.Value)
                            currentPackageInstallationDetail.process_install_logfile = (string)reader["process_install_logfile"];
                        if (reader["process_install_keyword"] != DBNull.Value)
                            currentPackageInstallationDetail.process_install_keyword = (string)reader["process_install_keyword"];
                        if (reader["process_uninstall_command"] != DBNull.Value)
                            currentPackageInstallationDetail.process_uninstall_command = (string)reader["process_uninstall_command"];
                        if (reader["process_uninstall_logfile"] != DBNull.Value)
                            currentPackageInstallationDetail.process_uninstall_logfile = (string)reader["process_uninstall_logfile"];
                        if (reader["process_uninstall_keyword"] != DBNull.Value)
                            currentPackageInstallationDetail.process_uninstall_keyword = (string)reader["process_uninstall_keyword"];
                        if (reader["process_requires_restart"] != DBNull.Value)
                            currentPackageInstallationDetail.process_requires_restart = (bool?)reader["process_requires_restart"];
                        if (reader["extract_replace_path"] != DBNull.Value)
                            currentPackageInstallationDetail.extract_replace_path = (string)reader["extract_replace_path"];
                    }

                    currentPackageInstallationDetail.isNewEntity = false;
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

            public PackageInstallationDetail CurrentPackageInstallationDetail
            {
                get { return currentPackageInstallationDetail; }
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


        #region PackageInstallationDetail functions

        public static PackageInstallationDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.package_installation_detail_id == (Columns.package_installation_detail_id & columns))
                qry.Append("package_installation_detail_id,");
            if (Columns.package_id == (Columns.package_id & columns))
                qry.Append("package_id,");
            if (Columns.process_install_command == (Columns.process_install_command & columns))
                qry.Append("process_install_command,");
            if (Columns.process_install_logfile == (Columns.process_install_logfile & columns))
                qry.Append("process_install_logfile,");
            if (Columns.process_install_keyword == (Columns.process_install_keyword & columns))
                qry.Append("process_install_keyword,");
            if (Columns.process_uninstall_command == (Columns.process_uninstall_command & columns))
                qry.Append("process_uninstall_command,");
            if (Columns.process_uninstall_logfile == (Columns.process_uninstall_logfile & columns))
                qry.Append("process_uninstall_logfile,");
            if (Columns.process_uninstall_keyword == (Columns.process_uninstall_keyword & columns))
                qry.Append("process_uninstall_keyword,");
            if (Columns.process_requires_restart == (Columns.process_requires_restart & columns))
                qry.Append("process_requires_restart,");
            if (Columns.extract_replace_path == (Columns.extract_replace_path & columns))
                qry.Append("extract_replace_path,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Package_installation_detail ");

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
            return new PackageInstallationDetailReader(cmd.ExecuteReader(), conn, columns);
        }

        static public PackageInstallationDetailReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static PackageInstallationDetailReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select package_installation_detail_id,package_id,process_install_command,process_install_logfile,process_install_keyword,process_uninstall_command,process_uninstall_logfile,process_uninstall_keyword,process_requires_restart,extract_replace_path from Package_installation_detail ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new PackageInstallationDetailReader(cmd.ExecuteReader(), conn);
        }

        static public PackageInstallationDetailReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static PackageInstallationDetail LoadPackageInstallationDetail(string where)
        {
            PackageInstallationDetailReader reader = PackageInstallationDetail.ExecuteReader(where);
            PackageInstallationDetail _packageinstallationdetail = null;
            if (reader.Read())
                _packageinstallationdetail = reader.CurrentPackageInstallationDetail;
            reader.Close();
            return _packageinstallationdetail;
        }

        public static PackageInstallationDetail LoadPackageInstallationDetail(string where, IDbConnection conn)
        {
            PackageInstallationDetailReader reader = PackageInstallationDetail.ExecuteReader(where, conn);
            PackageInstallationDetail _packageinstallationdetail = null;
            if (reader.Read())
                _packageinstallationdetail = reader.CurrentPackageInstallationDetail;
            reader.Close(false);
            return _packageinstallationdetail;
        }

        public static PackageInstallationDetail LoadPackageInstallationDetailByPk(int package_installation_detail_id)
        {
            return LoadPackageInstallationDetail("package_installation_detail_id=" + package_installation_detail_id);
        }

        public static PackageInstallationDetail LoadPackageInstallationDetailByPk(int package_installation_detail_id, IDbConnection conn)
        {
            return LoadPackageInstallationDetail(" package_installation_detail_id=" + package_installation_detail_id, conn);
        }

        public void Save()
        {
            if (package_installation_detail_idChanged || package_idChanged || process_install_commandChanged || process_install_logfileChanged || process_install_keywordChanged || process_uninstall_commandChanged || process_uninstall_logfileChanged || process_uninstall_keywordChanged || process_requires_restartChanged || extract_replace_pathChanged)
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
            if (package_installation_detail_idChanged || package_idChanged || process_install_commandChanged || process_install_logfileChanged || process_install_keywordChanged || process_uninstall_commandChanged || process_uninstall_logfileChanged || process_uninstall_keywordChanged || process_requires_restartChanged || extract_replace_pathChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Package_installation_detail(package_installation_detail_id,package_id,process_install_command,process_install_logfile,process_install_keyword,process_uninstall_command,process_uninstall_logfile,process_uninstall_keyword,process_requires_restart,extract_replace_path) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.package_installation_detail_id = ConnectionFactory.GetNextId();
                        qry.Append(this.package_installation_detail_id);
                    } qry.Append(",");
                    qry.Append(package_idDbString + ",");
                    qry.Append(process_install_commandDbString + ",");
                    qry.Append(process_install_logfileDbString + ",");
                    qry.Append(process_install_keywordDbString + ",");
                    qry.Append(process_uninstall_commandDbString + ",");
                    qry.Append(process_uninstall_logfileDbString + ",");
                    qry.Append(process_uninstall_keywordDbString + ",");
                    qry.Append(process_requires_restartDbString + ",");
                    qry.Append(extract_replace_pathDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(package_installation_detail_idChanged || package_idChanged || process_install_commandChanged || process_install_logfileChanged || process_install_keywordChanged || process_uninstall_commandChanged || process_uninstall_logfileChanged || process_uninstall_keywordChanged || process_requires_restartChanged || extract_replace_pathChanged))
                        return;
                    qry.Append("UPDATE Package_installation_detail set "); if (package_idChanged)
                    {
                        qry.Append("package_id =" + package_idDbString);
                        qry.Append(",");
                    }

                    if (process_install_commandChanged)
                    {
                        qry.Append("process_install_command =" + process_install_commandDbString);
                        qry.Append(",");
                    }

                    if (process_install_logfileChanged)
                    {
                        qry.Append("process_install_logfile =" + process_install_logfileDbString);
                        qry.Append(",");
                    }

                    if (process_install_keywordChanged)
                    {
                        qry.Append("process_install_keyword =" + process_install_keywordDbString);
                        qry.Append(",");
                    }

                    if (process_uninstall_commandChanged)
                    {
                        qry.Append("process_uninstall_command =" + process_uninstall_commandDbString);
                        qry.Append(",");
                    }

                    if (process_uninstall_logfileChanged)
                    {
                        qry.Append("process_uninstall_logfile =" + process_uninstall_logfileDbString);
                        qry.Append(",");
                    }

                    if (process_uninstall_keywordChanged)
                    {
                        qry.Append("process_uninstall_keyword =" + process_uninstall_keywordDbString);
                        qry.Append(",");
                    }

                    if (process_requires_restartChanged)
                    {
                        qry.Append("process_requires_restart =" + process_requires_restartDbString);
                        qry.Append(",");
                    }

                    if (extract_replace_pathChanged)
                    {
                        qry.Append("extract_replace_path =" + extract_replace_pathDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("package_installation_detail_id = " + package_installation_detail_idDbString);
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
            cmd.CommandText = "DELETE Package_installation_detail wherepackage_installation_detail_id= " + package_installation_detail_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeletePackageInstallationDetails(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Package_installation_detail where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            package_installation_detail_id = 1,
            package_id = 2,
            process_install_command = 4,
            process_install_logfile = 8,
            process_install_keyword = 16,
            process_uninstall_command = 32,
            process_uninstall_logfile = 64,
            process_uninstall_keyword = 128,
            process_requires_restart = 256,
            extract_replace_path = 512
        }
        #endregion
        public void BulkSave(List<PackageInstallationDetail> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Package_installation_detail";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(PackageInstallationDetail.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<PackageInstallationDetail> transList, ref DataTable dt)
        {
            foreach (PackageInstallationDetail tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["package_installation_detail_id"] = ConnectionFactory.GetNextId();
                Row["package_id"] = tran.PackageId;
                Row["process_install_command"] = tran.ProcessInstallCommand;
                Row["process_install_logfile"] = tran.ProcessInstallLogfile;
                Row["process_install_keyword"] = tran.ProcessInstallKeyword;
                Row["process_uninstall_command"] = tran.ProcessUninstallCommand;
                Row["process_uninstall_logfile"] = tran.ProcessUninstallLogfile;
                Row["process_uninstall_keyword"] = tran.ProcessUninstallKeyword;
                Row["process_requires_restart"] = tran.ProcessRequiresRestart;
                Row["extract_replace_path"] = tran.ExtractReplacePath;
                dt.Rows.Add(Row);
            }
        }
    }
}