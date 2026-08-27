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
    public class CcmsUserCitApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsUserCitApprover() { }
        public CcmsUserCitApprover(long user_id, long cit_id)
        {
            this.user_id = user_id;
            this.user_idChanged = true;
            this.cit_id = cit_id;
            this.cit_idChanged = true;
        }
        public CcmsUserCitApprover(int id)
        {
            this.id = id;
            this.idChanged = true;
        }
        public CcmsUserCitApprover(int id, long? user_id, long? cit_id)
        {
            this.id = id;
            this.idChanged = true;
            this.user_id = user_id;
            this.user_idChanged = true;
            this.cit_id = cit_id;
            this.cit_idChanged = true;
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
        #region UserId
        private bool user_idChanged = false;
        private long? user_id;
        public long? UserId
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
                if (this.user_id.HasValue)
                    return user_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CitId
        private bool cit_idChanged = false;
        private long? cit_id;
        public long? CitId
        {
            get { return cit_id; }
            set
            {
                cit_id = value;
                cit_idChanged = true;
            }
        }
        private string cit_idDbString
        {
            get
            {
                if (this.cit_id.HasValue)
                    return cit_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region CcmsUserCitApproverReader
        public class CcmsUserCitApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsUserCitApprover currentCcmsUserCitApprover;
            Columns columns;
            bool partialRead = false;
            private CcmsUserCitApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsUserCitApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsUserCitApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsUserCitApprover; }

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
                    currentCcmsUserCitApprover = new CcmsUserCitApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsUserCitApprover.id = (int)reader["id"];
                        if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"] != DBNull.Value)
                            currentCcmsUserCitApprover.user_id = (int?)reader["user_id"];
                        if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"] != DBNull.Value)
                            currentCcmsUserCitApprover.cit_id = (int?)reader["cit_id"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsUserCitApprover.id = (int)reader["id"];
                        if (reader["user_id"] != DBNull.Value)
                            currentCcmsUserCitApprover.user_id = (int?)reader["user_id"];
                        if (reader["cit_id"] != DBNull.Value)
                            currentCcmsUserCitApprover.cit_id = (int?)reader["cit_id"];
                    }

                    currentCcmsUserCitApprover.isNewEntity = false;
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

            public CcmsUserCitApprover CurrentCcmsUserCitApprover
            {
                get { return currentCcmsUserCitApprover; }
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


        #region CcmsUserCitApprover functions

        public static CcmsUserCitApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.user_id == (Columns.user_id & columns))
                qry.Append("user_id,");
            if (Columns.cit_id == (Columns.cit_id & columns))
                qry.Append("cit_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ccms_user_cit_approver ");

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
            return new CcmsUserCitApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsUserCitApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsUserCitApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,user_id,cit_id from Ccms_user_cit_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CcmsUserCitApproverReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsUserCitApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CcmsUserCitApprover LoadCcmsUserCitApprover(string where)
        {
            CcmsUserCitApproverReader reader = CcmsUserCitApprover.ExecuteReader(where);
            CcmsUserCitApprover _ccmsusercitapprover = null;
            if (reader.Read())
                _ccmsusercitapprover = reader.CurrentCcmsUserCitApprover;
            reader.Close();
            return _ccmsusercitapprover;
        }

        public static CcmsUserCitApprover LoadCcmsUserCitApprover(string where, IDbConnection conn)
        {
            CcmsUserCitApproverReader reader = CcmsUserCitApprover.ExecuteReader(where, conn);
            CcmsUserCitApprover _ccmsusercitapprover = null;
            if (reader.Read())
                _ccmsusercitapprover = reader.CurrentCcmsUserCitApprover;
            reader.Close(false);
            return _ccmsusercitapprover;
        }


        public void Save()
        {
            if (idChanged || user_idChanged || cit_idChanged)
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
            if (idChanged || user_idChanged || cit_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ccms_user_cit_approver( id,user_id,cit_id ) values(");
                    qry.Append(idDbString + ",");
                    qry.Append(user_idDbString + ",");
                    qry.Append(cit_idDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update Ccms_user_cit_approver!");
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

        public static void DeleteCcmsUserCitApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_user_cit_approver where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            user_id = 2,
            cit_id = 4
        }
        #endregion
        public void BulkSave(List<CcmsUserCitApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_user_cit_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsUserCitApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsUserCitApprover> transList, ref DataTable dt)
        {
            foreach (CcmsUserCitApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = tran.Id;
                Row["user_id"] = tran.UserId;
                Row["cit_id"] = tran.CitId;
                dt.Rows.Add(Row);
            }
        }
    }
}
