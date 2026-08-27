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
    public class GroupRightsApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public GroupRightsApprover() { }
        public GroupRightsApprover(int group_id, int right_id)
        {
            this.group_id = group_id;
            this.group_idChanged = true;
            this.right_id = right_id;
            this.right_idChanged = true;
        }

        #region members and properties for columns

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
        #region RightId
        private bool right_idChanged = false;
        private int right_id;
        public int RightId
        {
            get { return right_id; }
            set
            {
                right_id = value;
                right_idChanged = true;
            }
        }
        private string right_idDbString
        {
            get
            {
                return right_id.ToString();
            }
        }
        #endregion
        #endregion

        #region GroupRightsApproverReader
        public class GroupRightsApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            GroupRightsApprover currentGroupRightsApprover;
            Columns columns;
            bool partialRead = false;
            private GroupRightsApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public GroupRightsApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public GroupRightsApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentGroupRightsApprover; }

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
                    currentGroupRightsApprover = new GroupRightsApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.group_id) == Columns.group_id && reader["group_id"] != DBNull.Value)
                            currentGroupRightsApprover.group_id = (int)reader["group_id"];
                        if ((columns & Columns.right_id) == Columns.right_id && reader["right_id"] != DBNull.Value)
                            currentGroupRightsApprover.right_id = (int)reader["right_id"];

                    }
                    else
                    {
                        if (reader["group_id"] != DBNull.Value)
                            currentGroupRightsApprover.group_id = (int)reader["group_id"];
                        if (reader["right_id"] != DBNull.Value)
                            currentGroupRightsApprover.right_id = (int)reader["right_id"];
                    }

                    currentGroupRightsApprover.isNewEntity = false;
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

            public GroupRightsApprover CurrentGroupRightsApprover
            {
                get { return currentGroupRightsApprover; }
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


        #region GroupRightsApprover functions

        public static GroupRightsApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.group_id == (Columns.group_id & columns))
                qry.Append("group_id,");
            if (Columns.right_id == (Columns.right_id & columns))
                qry.Append("right_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Group_rights_approver ");

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
            return new GroupRightsApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public GroupRightsApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static GroupRightsApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select group_id,right_id from Group_rights_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new GroupRightsApproverReader(cmd.ExecuteReader(), conn);
        }

        static public GroupRightsApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static GroupRightsApprover LoadGroupRightsApprover(string where)
        {
            GroupRightsApproverReader reader = GroupRightsApprover.ExecuteReader(where);
            GroupRightsApprover _grouprightsapprover = null;
            if (reader.Read())
                _grouprightsapprover = reader.CurrentGroupRightsApprover;
            reader.Close();
            return _grouprightsapprover;
        }

        public static GroupRightsApprover LoadGroupRightsApprover(string where, IDbConnection conn)
        {
            GroupRightsApproverReader reader = GroupRightsApprover.ExecuteReader(where, conn);
            GroupRightsApprover _grouprightsapprover = null;
            if (reader.Read())
                _grouprightsapprover = reader.CurrentGroupRightsApprover;
            reader.Close(false);
            return _grouprightsapprover;
        }


        public void Save()
        {
            if (group_idChanged || right_idChanged)
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
            if (group_idChanged || right_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Group_rights_approver( group_id,right_id ) values(");
                    qry.Append(group_idDbString + ",");
                    qry.Append(right_idDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update Group_rights_approver!");
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

        public static void DeleteGroupRightsApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Group_rights_approver where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            group_id = 1,
            right_id = 2
        }
        #endregion
        public void BulkSave(List<GroupRightsApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Group_rights_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(GroupRightsApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<GroupRightsApprover> transList, ref DataTable dt)
        {
            foreach (GroupRightsApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["group_id"] = tran.GroupId;
                Row["right_id"] = tran.RightId;
                dt.Rows.Add(Row);
            }
        }
    }
}
