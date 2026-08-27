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
    public class UserOrganizationApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public UserOrganizationApprover() { }
        public UserOrganizationApprover(int user_id, string org_mcn)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
            this.org_mcn = org_mcn;
            this.org_mcnChanged = true;
        }
        public UserOrganizationApprover(int user_org_id, int user_id, string org_mcn)
        {
            this.user_org_id = user_org_id;
            this.user_org_idChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.org_mcn = org_mcn;
            this.org_mcnChanged = true;
        }

        #region members and properties for columns

        #region UserOrgId
        private bool user_org_idChanged = false;
        private int user_org_id;
        public int UserOrgId
        {
            get { return user_org_id; }
            set
            {
                user_org_id = value;
                user_org_idChanged = true;
            }
        }
        private string user_org_idDbString
        {
            get
            {
                return user_org_id.ToString();
            }
        }
        #endregion
        #region UserId
        private bool user_idChanged = false;
        private int user_id;
        public int UserId
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
                return user_id.ToString();
            }
        }
        #endregion
        #region OrgMcn
        private bool org_mcnChanged = false;
        private string org_mcn;
        public string OrgMcn
        {
            get { return org_mcn; }
            set
            {
                org_mcn = value;
                org_mcnChanged = true;
            }
        }
        private string org_mcnDbString
        {
            get
            {
                if (this.org_mcn != null)
                    return string.Format("'{0}'", org_mcn);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region UserOrganizationApproverReader
        public class UserOrganizationApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            UserOrganizationApprover currentUserOrganizationApprover;
            Columns columns;
            bool partialRead = false;
            private UserOrganizationApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public UserOrganizationApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public UserOrganizationApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentUserOrganizationApprover; }

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
                    currentUserOrganizationApprover = new UserOrganizationApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.user_org_id) == Columns.user_org_id && reader["user_org_id"] != DBNull.Value)
                            currentUserOrganizationApprover.user_org_id = (int)reader["user_org_id"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentUserOrganizationApprover.user_id = (int)reader["user_id"];
                        if ((columns & Columns.org_mcn) == Columns.org_mcn && reader["org_mcn"] != DBNull.Value)
                            currentUserOrganizationApprover.org_mcn = (string)reader["org_mcn"];

                    }
                    else
                    {
                        if (reader["user_org_id"] != DBNull.Value)
                            currentUserOrganizationApprover.user_org_id = (int)reader["user_org_id"];
                        if (reader["user_id"] != DBNull.Value)
                            currentUserOrganizationApprover.user_id = (int)reader["user_id"];
                        if (reader["org_mcn"] != DBNull.Value)
                            currentUserOrganizationApprover.org_mcn = (string)reader["org_mcn"];
                    }

                    currentUserOrganizationApprover.isNewEntity = false;
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

            public UserOrganizationApprover CurrentUserOrganizationApprover
            {
                get { return currentUserOrganizationApprover; }
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


        #region UserOrganizationApprover functions

        public static UserOrganizationApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.user_org_id == (Columns.user_org_id & columns))
                qry.Append("user_org_id,");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.org_mcn == (Columns.org_mcn & columns))
                qry.Append("org_mcn,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from User_organization_approver ");

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
            return new UserOrganizationApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public UserOrganizationApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static UserOrganizationApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select user_org_id,user_id,org_mcn from User_organization_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new UserOrganizationApproverReader(cmd.ExecuteReader(), conn);
        }

        static public UserOrganizationApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static UserOrganizationApprover LoadUserOrganizationApprover(string where)
        {
            UserOrganizationApproverReader reader = UserOrganizationApprover.ExecuteReader(where);
            UserOrganizationApprover _userorganizationapprover = null;
            if (reader.Read())
                _userorganizationapprover = reader.CurrentUserOrganizationApprover;
            reader.Close();
            return _userorganizationapprover;
        }

        public static UserOrganizationApprover LoadUserOrganizationApprover(string where, IDbConnection conn)
        {
            UserOrganizationApproverReader reader = UserOrganizationApprover.ExecuteReader(where, conn);
            UserOrganizationApprover _userorganizationapprover = null;
            if (reader.Read())
                _userorganizationapprover = reader.CurrentUserOrganizationApprover;
            reader.Close(false);
            return _userorganizationapprover;
        }


        public void Save()
        {
            if (user_org_idChanged || user_idChanged || org_mcnChanged)
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
            if (user_org_idChanged || user_idChanged || org_mcnChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into User_organization_approver( user_org_id,user_id,org_mcn ) values(");
                    qry.Append(user_org_idDbString + ",");
                    qry.Append(user_idDbString + ",");
                    qry.Append(org_mcnDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update User_organization_approver!");
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

        public static void DeleteUserOrganizationApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete User_organization_approver where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            user_org_id = 1,
            user_id = 2,
            org_mcn = 4
        }
        #endregion
        public void BulkSave(List<UserOrganizationApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "User_organization_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(UserOrganizationApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<UserOrganizationApprover> transList, ref DataTable dt)
        {
            foreach (UserOrganizationApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["user_org_id"] = tran.UserOrgId;
                Row["user_id"] = tran.UserId;
                Row["org_mcn"] = tran.OrgMcn;
                dt.Rows.Add(Row);
            }
        }
    }
}
