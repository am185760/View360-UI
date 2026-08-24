
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
    public class AtmDffGenerationHaltHistory
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public AtmDffGenerationHaltHistory() { }
        public AtmDffGenerationHaltHistory(int atm_id, DateTime generated_at)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
        }
        private AtmDffGenerationHaltHistory(int atm_dff_generation_halt_history_id, int atm_id, DateTime generated_at)
        {
            this.atm_dff_generation_halt_history_id = atm_dff_generation_halt_history_id;
            this.atm_dff_generation_halt_history_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
        }

        #region members and properties for columns

        #region AtmDffGenerationHaltHistoryId
        private bool atm_dff_generation_halt_history_idChanged = false;
        private int atm_dff_generation_halt_history_id;
        public int AtmDffGenerationHaltHistoryId
        {
            get { return atm_dff_generation_halt_history_id; }
            set
            {
                atm_dff_generation_halt_history_id = value;
                atm_dff_generation_halt_history_idChanged = true;
            }
        }
        private string atm_dff_generation_halt_history_idDbString
        {
            get
            {
                return atm_dff_generation_halt_history_id.ToString();
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private int atm_id;
        public int AtmId
        {
            get { return atm_id; }
            set
            {
                atm_id = value;
                atm_idChanged = true;
            }
        }
        private string atm_idDbString
        {
            get
            {
                return atm_id.ToString();
            }
        }
        #endregion
        #region GeneratedAt
        private bool generated_atChanged = false;
        private DateTime generated_at;
        public DateTime GeneratedAt
        {
            get { return generated_at; }
            set
            {
                generated_at = value;
                generated_atChanged = true;
            }
        }
        private string generated_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #endregion

        #region AtmDffGenerationHaltHistoryReader
        public class AtmDffGenerationHaltHistoryReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            AtmDffGenerationHaltHistory currentAtmDffGenerationHaltHistory;
            Columns columns;
            bool partialRead = false;
            private AtmDffGenerationHaltHistoryReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AtmDffGenerationHaltHistoryReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AtmDffGenerationHaltHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAtmDffGenerationHaltHistory; }

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
                    currentAtmDffGenerationHaltHistory = new AtmDffGenerationHaltHistory();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_dff_generation_halt_history_id) == Columns.atm_dff_generation_halt_history_id && reader["atm_dff_generation_halt_history_id"] != DBNull.Value)
                            currentAtmDffGenerationHaltHistory.atm_dff_generation_halt_history_id = (int)reader["atm_dff_generation_halt_history_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentAtmDffGenerationHaltHistory.atm_id = (int)reader["atm_id"];
                        if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"] != DBNull.Value)
                            currentAtmDffGenerationHaltHistory.generated_at = (DateTime)reader["generated_at"];

                    }
                    else
                    {
                        if (reader["atm_dff_generation_halt_history_id"] != DBNull.Value)
                            currentAtmDffGenerationHaltHistory.atm_dff_generation_halt_history_id = (int)reader["atm_dff_generation_halt_history_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentAtmDffGenerationHaltHistory.atm_id = (int)reader["atm_id"];
                        if (reader["generated_at"] != DBNull.Value)
                            currentAtmDffGenerationHaltHistory.generated_at = (DateTime)reader["generated_at"];
                    }

                    currentAtmDffGenerationHaltHistory.isNewEntity = false;
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

            public AtmDffGenerationHaltHistory CurrentAtmDffGenerationHaltHistory
            {
                get { return currentAtmDffGenerationHaltHistory; }
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


        #region AtmDffGenerationHaltHistory functions

        public static AtmDffGenerationHaltHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_dff_generation_halt_history_id == (Columns.atm_dff_generation_halt_history_id & columns))
                qry.Append("atm_dff_generation_halt_history_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.generated_at == (Columns.generated_at & columns))
                qry.Append("generated_at,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Atm_dff_generation_halt_history ");

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
            return new AtmDffGenerationHaltHistoryReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AtmDffGenerationHaltHistoryReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AtmDffGenerationHaltHistoryReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_dff_generation_halt_history_id,atm_id,generated_at from Atm_dff_generation_halt_history ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmDffGenerationHaltHistoryReader(cmd.ExecuteReader(), conn);
        }

        static public AtmDffGenerationHaltHistoryReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static AtmDffGenerationHaltHistory LoadAtmDffGenerationHaltHistory(string where)
        {
            AtmDffGenerationHaltHistoryReader reader = AtmDffGenerationHaltHistory.ExecuteReader(where);
            AtmDffGenerationHaltHistory _atmdffgenerationhalthistory = null;
            if (reader.Read())
                _atmdffgenerationhalthistory = reader.CurrentAtmDffGenerationHaltHistory;
            reader.Close();
            return _atmdffgenerationhalthistory;
        }

        public static AtmDffGenerationHaltHistory LoadAtmDffGenerationHaltHistory(string where, IDbConnection conn)
        {
            AtmDffGenerationHaltHistoryReader reader = AtmDffGenerationHaltHistory.ExecuteReader(where, conn);
            AtmDffGenerationHaltHistory _atmdffgenerationhalthistory = null;
            if (reader.Read())
                _atmdffgenerationhalthistory = reader.CurrentAtmDffGenerationHaltHistory;
            reader.Close(false);
            return _atmdffgenerationhalthistory;
        }

        public static AtmDffGenerationHaltHistory LoadAtmDffGenerationHaltHistoryByPk(int atm_dff_generation_halt_history_id)
        {
            return LoadAtmDffGenerationHaltHistory(" atm_dff_generation_halt_history_id=" + atm_dff_generation_halt_history_id);
        }

        public static AtmDffGenerationHaltHistory LoadAtmDffGenerationHaltHistoryByPk(int atm_dff_generation_halt_history_id, IDbConnection conn)
        {
            return LoadAtmDffGenerationHaltHistory(" atm_dff_generation_halt_history_id=" + atm_dff_generation_halt_history_id, conn);
        }

        public void Save()
        {
            if (atm_dff_generation_halt_history_idChanged || atm_idChanged || generated_atChanged)
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
            if (atm_dff_generation_halt_history_idChanged || atm_idChanged || generated_atChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm_dff_generation_halt_history( atm_dff_generation_halt_history_id,atm_id,generated_at ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.atm_dff_generation_halt_history_id = ConnectionFactory.GetNextId();
                        qry.Append(this.atm_dff_generation_halt_history_id);
                    } qry.Append(",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(generated_atDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_dff_generation_halt_history_idChanged || atm_idChanged || generated_atChanged))
                        return;
                    qry.Append("UPDATE Atm_dff_generation_halt_history set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (generated_atChanged)
                    {
                        qry.Append("generated_at =" + generated_atDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("atm_dff_generation_halt_history_id = " + atm_dff_generation_halt_history_idDbString);
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
            cmd.CommandText = "DELETE Atm_dff_generation_halt_history where atm_dff_generation_halt_history_id = " + atm_dff_generation_halt_history_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAtmDffGenerationHaltHistorys(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Atm_dff_generation_halt_history where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            atm_dff_generation_halt_history_id = 1,
            atm_id = 2,
            generated_at = 4
        }
        #endregion
        public void BulkSave(List<AtmDffGenerationHaltHistory> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Atm_dff_generation_halt_history";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(AtmDffGenerationHaltHistory.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<AtmDffGenerationHaltHistory> transList, ref DataTable dt)
        {
            foreach (AtmDffGenerationHaltHistory tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_dff_generation_halt_history_id"] = ConnectionFactory.GetNextId();
                Row["atm_id"] = tran.AtmId;
                Row["generated_at"] = tran.GeneratedAt;
                dt.Rows.Add(Row);
            }
        }
    }
}


