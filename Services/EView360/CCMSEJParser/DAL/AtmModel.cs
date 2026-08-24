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
    public class AtmModel
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public AtmModel() { }
        public AtmModel(string name)
        {
            this.name = name;
            this.nameChanged = true;
        }
        private AtmModel(int atm_model_id, string name)
        {
            this.atm_model_id = atm_model_id;
            this.atm_model_idChanged = true;
            this.name = name;
            this.nameChanged = true;
        }

        #region members and properties for columns

        #region AtmModelId
        private bool atm_model_idChanged = false;
        private int atm_model_id;
        public int AtmModelId
        {
            get { return atm_model_id; }
            set
            {
                atm_model_id = value;
                atm_model_idChanged = true;
            }
        }
        private string atm_model_idDbString
        {
            get
            {
                return atm_model_id.ToString();
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
        #endregion

        #region AtmModelReader
        public class AtmModelReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            AtmModel currentAtmModel;
            Columns columns;
            bool partialRead = false;
            private AtmModelReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AtmModelReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AtmModelReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAtmModel; }

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
                    currentAtmModel = new AtmModel();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_model_id) == Columns.atm_model_id && reader["atm_model_id"] != DBNull.Value)
                            currentAtmModel.atm_model_id = (int)reader["atm_model_id"];
                        if ((columns & Columns.name) == Columns.name && reader["name"] != DBNull.Value)
                            currentAtmModel.name = (string)reader["name"];

                    }
                    else
                    {
                        if (reader["atm_model_id"] != DBNull.Value)
                            currentAtmModel.atm_model_id = (int)reader["atm_model_id"];
                        if (reader["name"] != DBNull.Value)
                            currentAtmModel.name = (string)reader["name"];
                    }

                    currentAtmModel.isNewEntity = false;
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

            public AtmModel CurrentAtmModel
            {
                get { return currentAtmModel; }
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


        #region AtmModel functions

        public static AtmModelReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_model_id == (Columns.atm_model_id & columns))
                qry.Append("atm_model_id,");
            if (Columns.name == (Columns.name & columns))
                qry.Append("name,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Atm_model ");

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
            return new AtmModelReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AtmModelReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AtmModelReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_model_id,name from Atm_model ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmModelReader(cmd.ExecuteReader(), conn);
        }

        static public AtmModelReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static AtmModel LoadAtmModel(string where)
        {
            AtmModelReader reader = AtmModel.ExecuteReader(where);
            AtmModel _atmmodel = null;
            if (reader.Read())
                _atmmodel = reader.CurrentAtmModel;
            reader.Close();
            return _atmmodel;
        }

        public static AtmModel LoadAtmModel(string where, IDbConnection conn)
        {
            AtmModelReader reader = AtmModel.ExecuteReader(where, conn);
            AtmModel _atmmodel = null;
            if (reader.Read())
                _atmmodel = reader.CurrentAtmModel;
            reader.Close(false);
            return _atmmodel;
        }

        public static AtmModel LoadAtmModelByPk(int atm_model_id)
        {
            return LoadAtmModel("atm_model_id=" + atm_model_id);
        }

        public static AtmModel LoadAtmModelByPk(int atm_model_id, IDbConnection conn)
        {
            return LoadAtmModel(" atm_model_id=" + atm_model_id, conn);
        }

        public void Save()
        {
            if (atm_model_idChanged || nameChanged)
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
            if (atm_model_idChanged || nameChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm_model(atm_model_id,name) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.atm_model_id = ConnectionFactory.GetNextId();
                        qry.Append(this.atm_model_id);
                    } qry.Append(",");
                    qry.Append(nameDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_model_idChanged || nameChanged))
                        return;
                    qry.Append("UPDATE Atm_model set "); if (nameChanged)
                    {
                        qry.Append("name =" + nameDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("atm_model_id = " + atm_model_idDbString);
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
            cmd.CommandText = "DELETE Atm_model whereatm_model_id= " + atm_model_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAtmModels(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Atm_model where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_model_id = 1,
            name = 2
        }
        #endregion
        public void BulkSave(List<AtmModel> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Atm_model";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(AtmModel.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<AtmModel> transList, ref DataTable dt)
        {
            foreach (AtmModel tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_model_id"] = ConnectionFactory.GetNextId();
                Row["name"] = tran.Name;
                dt.Rows.Add(Row);
            }
        }
    }
}