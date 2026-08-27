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
    public class UserATMsApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public UserATMsApprover() { }
        public UserATMsApprover(int user_id, int aTM_id)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
            this.aTM_id = aTM_id;
            this.aTM_idChanged = true;
        }
        public UserATMsApprover(int user_id, int aTM_id, int user_ATM_id)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
            this.aTM_id = aTM_id;
            this.aTM_idChanged = true;
            this.user_ATM_id = user_ATM_id;
            this.user_ATM_idChanged = true;
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
        #region ATMId
        private bool aTM_idChanged = false;
        private int aTM_id;
        public int ATMId
        {
            get { return aTM_id; }
            set
            {
                aTM_id = value;
                aTM_idChanged = true;
            }
        }
        private string aTM_idDbString
        {
            get
            {
                return aTM_id.ToString();
            }
        }
        #endregion
        #region UserATMId
        private bool user_ATM_idChanged = false;
        private int user_ATM_id;
        public int UserATMId
        {
            get { return user_ATM_id; }
            set
            {
                user_ATM_id = value;
                user_ATM_idChanged = true;
            }
        }
        private string user_ATM_idDbString
        {
            get
            {
                return user_ATM_id.ToString();
            }
        }
        #endregion
        #endregion

        #region UserATMsApproverReader
        public class UserATMsApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            UserATMsApprover currentUserATMsApprover;
            Columns columns;
            bool partialRead = false;
            private UserATMsApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public UserATMsApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public UserATMsApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentUserATMsApprover; }

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
                    currentUserATMsApprover = new UserATMsApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentUserATMsApprover.user_id = (int)reader["user_id"];
                        if ((columns & Columns.ATM_id) == Columns.ATM_id && reader["ATM_id"] != DBNull.Value)
                            currentUserATMsApprover.aTM_id = (int)reader["ATM_id"];
                        if ((columns & Columns.user_ATM_id) == Columns.user_ATM_id && reader["user_ATM_id"] != DBNull.Value)
                            currentUserATMsApprover.user_ATM_id = (int)reader["user_ATM_id"];

                    }
                    else
                    {
                        if (reader["user_id"] != DBNull.Value)
                            currentUserATMsApprover.user_id = (int)reader["user_id"];
                        if (reader["ATM_id"] != DBNull.Value)
                            currentUserATMsApprover.aTM_id = (int)reader["ATM_id"];
                        if (reader["user_ATM_id"] != DBNull.Value)
                            currentUserATMsApprover.user_ATM_id = (int)reader["user_ATM_id"];
                    }

                    currentUserATMsApprover.isNewEntity = false;
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

            public UserATMsApprover CurrentUserATMsApprover
            {
                get { return currentUserATMsApprover; }
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


        #region UserATMsApprover functions

        public static UserATMsApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.ATM_id == (Columns.ATM_id & columns))
                qry.Append("ATM_id,");
            if (Columns.user_ATM_id == (Columns.user_ATM_id & columns))
                qry.Append("user_ATM_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from User_ATMs_approver ");

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
            return new UserATMsApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public UserATMsApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static UserATMsApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select user_id,ATM_id,user_ATM_id from User_ATMs_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new UserATMsApproverReader(cmd.ExecuteReader(), conn);
        }

        static public UserATMsApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static UserATMsApprover LoadUserATMsApprover(string where)
        {
            UserATMsApproverReader reader = UserATMsApprover.ExecuteReader(where);
            UserATMsApprover _useratmsapprover = null;
            if (reader.Read())
                _useratmsapprover = reader.CurrentUserATMsApprover;
            reader.Close();
            return _useratmsapprover;
        }

        public static UserATMsApprover LoadUserATMsApprover(string where, IDbConnection conn)
        {
            UserATMsApproverReader reader = UserATMsApprover.ExecuteReader(where, conn);
            UserATMsApprover _useratmsapprover = null;
            if (reader.Read())
                _useratmsapprover = reader.CurrentUserATMsApprover;
            reader.Close(false);
            return _useratmsapprover;
        }
        public static UserATMsApprover LoadUserATMsApproverByPk(int user_ATM_id)
        {
            return LoadUserATMsApprover(" user_ATM_id=" + user_ATM_id);
        }

        public static UserATMsApprover LoadUserATMsApproverByPk(int user_ATM_id, IDbConnection conn)
        {
            return LoadUserATMsApprover(" user_ATM_id=" + user_ATM_id, conn);
        }

        public void Save()
        {
            if (user_idChanged || aTM_idChanged || user_ATM_idChanged)
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
            if (user_idChanged || aTM_idChanged || user_ATM_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into User_ATMs_approver( user_id,ATM_id,user_ATM_id ) values(");
                    qry.Append(user_idDbString + ",");
                    qry.Append(aTM_idDbString + ",");
                    qry.Append(user_ATM_idDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update User_ATMs_approver!");
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

        public static void DeleteUserATMsApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete User_ATMs_approver where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            user_id = 1,
            ATM_id = 2,
            user_ATM_id = 4
        }
        #endregion
        public void BulkSave(List<UserATMsApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "User_ATMs_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(UserATMsApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<UserATMsApprover> transList, ref DataTable dt)
        {
            foreach (UserATMsApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["user_id"] = tran.UserId;
                Row["aTM_id"] = tran.ATMId;
                Row["user_ATM_id"] = tran.UserATMId;
                dt.Rows.Add(Row);
            }
        }
    }
}
