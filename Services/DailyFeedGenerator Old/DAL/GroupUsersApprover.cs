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
    public class GroupUsersApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public GroupUsersApprover() { }
        public GroupUsersApprover(int user_id, int group_id)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
            this.group_id = group_id;
            this.group_idChanged = true;
        }

        #region members and properties for columns

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
        #region GroupId
        private bool group_idChanged = false;
        private int group_id;
        public int GroupId
        {
            get { return group_id; }
            set
            {
                group_id = value;
                group_idChanged = true;
            }
        }
        private string group_idDbString
        {
            get
            {
                return group_id.ToString();
            }
        }
        #endregion
        #endregion

        #region GroupUsersApproverReader
        public class GroupUsersApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            GroupUsersApprover currentGroupUsersApprover;
            Columns columns;
            bool partialRead = false;
            private GroupUsersApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public GroupUsersApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public GroupUsersApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentGroupUsersApprover; }

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
                    currentGroupUsersApprover = new GroupUsersApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentGroupUsersApprover.user_id = (int)reader["user_id"];
                        if ((columns & Columns.group_id) == Columns.group_id && reader["group_id"] != DBNull.Value)
                            currentGroupUsersApprover.group_id = (int)reader["group_id"];

                    }
                    else
                    {
                        if (reader["user_id"] != DBNull.Value)
                            currentGroupUsersApprover.user_id = (int)reader["user_id"];
                        if (reader["group_id"] != DBNull.Value)
                            currentGroupUsersApprover.group_id = (int)reader["group_id"];
                    }

                    currentGroupUsersApprover.isNewEntity = false;
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

            public GroupUsersApprover CurrentGroupUsersApprover
            {
                get { return currentGroupUsersApprover; }
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


        #region GroupUsersApprover functions

        public static GroupUsersApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.group_id == (Columns.group_id & columns))
                qry.Append("group_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Group_users_approver ");

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
            return new GroupUsersApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public GroupUsersApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static GroupUsersApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select user_id,group_id from Group_users_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new GroupUsersApproverReader(cmd.ExecuteReader(), conn);
        }

        static public GroupUsersApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static GroupUsersApprover LoadGroupUsersApprover(string where)
        {
            GroupUsersApproverReader reader = GroupUsersApprover.ExecuteReader(where);
            GroupUsersApprover _groupusersapprover = null;
            if (reader.Read())
                _groupusersapprover = reader.CurrentGroupUsersApprover;
            reader.Close();
            return _groupusersapprover;
        }

        public static GroupUsersApprover LoadGroupUsersApprover(string where, IDbConnection conn)
        {
            GroupUsersApproverReader reader = GroupUsersApprover.ExecuteReader(where, conn);
            GroupUsersApprover _groupusersapprover = null;
            if (reader.Read())
                _groupusersapprover = reader.CurrentGroupUsersApprover;
            reader.Close(false);
            return _groupusersapprover;
        }


        public void Save()
        {
            if (user_idChanged || group_idChanged)
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
            if (user_idChanged || group_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Group_users_approver( user_id,group_id ) values(");
                    qry.Append(user_idDbString + ",");
                    qry.Append(group_idDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update Group_users_approver!");
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

        public static void DeleteGroupUsersApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Group_users_approver where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            user_id = 1,
            group_id = 2
        }
        #endregion
        public void BulkSave(List<GroupUsersApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Group_users_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(GroupUsersApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<GroupUsersApprover> transList, ref DataTable dt)
        {
            foreach (GroupUsersApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["user_id"] = tran.UserId;
                Row["group_id"] = tran.GroupId;
                dt.Rows.Add(Row);
            }
        }
    }
}
