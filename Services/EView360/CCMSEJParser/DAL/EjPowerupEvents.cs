

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
    public class EjPowerupEvents
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjPowerupEvents() { }
        public EjPowerupEvents(int ej_powerup_events_id)
        {
        }
        public EjPowerupEvents(int? atm_id, DateTime? powerup_time, int? tsn)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.powerup_time = powerup_time;
            this.powerup_timeChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
        }
        private EjPowerupEvents(int ej_powerup_events_id, int? atm_id, DateTime? powerup_time, int? tsn)
        {
            this.ej_powerup_events_id = ej_powerup_events_id;
            this.ej_powerup_events_idChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.powerup_time = powerup_time;
            this.powerup_timeChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
        }

        #region members and properties for columns

        #region EjPowerupEventsId
        private bool ej_powerup_events_idChanged = false;
        private int ej_powerup_events_id;
        public int EjPowerupEventsId
        {
            get { return ej_powerup_events_id; }
            set
            {
                ej_powerup_events_id = value;
                ej_powerup_events_idChanged = true;
            }
        }
        private string ej_powerup_events_idDbString
        {
            get
            {
                return ej_powerup_events_id.ToString();
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private int? atm_id;
        public int? AtmId
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
                if (this.atm_id.HasValue)
                    return atm_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PowerupTime
        private bool powerup_timeChanged = false;
        private DateTime? powerup_time;
        public DateTime? PowerupTime
        {
            get { return powerup_time; }
            set
            {
                powerup_time = value;
                powerup_timeChanged = true;
            }
        }
        private string powerup_timeDbString
        {
            get
            {
                if (this.powerup_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", powerup_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Tsn
        private bool tsnChanged = false;
        private int? tsn;
        public int? Tsn
        {
            get { return tsn; }
            set
            {
                tsn = value;
                tsnChanged = true;
            }
        }
        private string tsnDbString
        {
            get
            {
                if (this.tsn.HasValue)
                    return tsn.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region EjPowerupEventsReader
        public class EjPowerupEventsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjPowerupEvents currentEjPowerupEvents;
            Columns columns;
            bool partialRead = false;
            private EjPowerupEventsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjPowerupEventsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjPowerupEventsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjPowerupEvents; }

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
                    currentEjPowerupEvents = new EjPowerupEvents();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_powerup_events_id) == Columns.ej_powerup_events_id && reader["ej_powerup_events_id"] != DBNull.Value)
                            currentEjPowerupEvents.ej_powerup_events_id = (int)reader["ej_powerup_events_id"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentEjPowerupEvents.atm_id = (int?)reader["atm_id"];
                        if ((columns & Columns.powerup_time) == Columns.powerup_time && reader["powerup_time"] != DBNull.Value)
                            currentEjPowerupEvents.powerup_time = (DateTime?)reader["powerup_time"];
                        if ((columns & Columns.tsn) == Columns.tsn && reader["tsn"] != DBNull.Value)
                            currentEjPowerupEvents.tsn = (int?)reader["tsn"];

                    }
                    else
                    {
                        if (reader["ej_powerup_events_id"] != DBNull.Value)
                            currentEjPowerupEvents.ej_powerup_events_id = (int)reader["ej_powerup_events_id"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentEjPowerupEvents.atm_id = (int?)reader["atm_id"];
                        if (reader["powerup_time"] != DBNull.Value)
                            currentEjPowerupEvents.powerup_time = (DateTime?)reader["powerup_time"];
                        if (reader["tsn"] != DBNull.Value)
                            currentEjPowerupEvents.tsn = (int?)reader["tsn"];
                    }

                    currentEjPowerupEvents.isNewEntity = false;
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

            public EjPowerupEvents CurrentEjPowerupEvents
            {
                get { return currentEjPowerupEvents; }
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


        #region EjPowerupEvents functions

        public static EjPowerupEventsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_powerup_events_id == (Columns.ej_powerup_events_id & columns))
                qry.Append("ej_powerup_events_id,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.powerup_time == (Columns.powerup_time & columns))
                qry.Append("powerup_time,");
            if (Columns.tsn == (Columns.tsn & columns))
                qry.Append("tsn,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_powerup_events ");

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
            return new EjPowerupEventsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjPowerupEventsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjPowerupEventsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select ej_powerup_events_id,atm_id,powerup_time,tsn from Ej_powerup_events ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjPowerupEventsReader(cmd.ExecuteReader(), conn);
        }

        static public EjPowerupEventsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static EjPowerupEvents LoadEjPowerupEvents(string where)
        {
            EjPowerupEventsReader reader = EjPowerupEvents.ExecuteReader(where);
            EjPowerupEvents _ejpowerupevents = null;
            if (reader.Read())
                _ejpowerupevents = reader.CurrentEjPowerupEvents;
            reader.Close();
            return _ejpowerupevents;
        }

        public static EjPowerupEvents LoadEjPowerupEvents(string where, IDbConnection conn)
        {
            EjPowerupEventsReader reader = EjPowerupEvents.ExecuteReader(where, conn);
            EjPowerupEvents _ejpowerupevents = null;
            if (reader.Read())
                _ejpowerupevents = reader.CurrentEjPowerupEvents;
            reader.Close(false);
            return _ejpowerupevents;
        }

        public static EjPowerupEvents LoadEjPowerupEventsByPk(int ej_powerup_events_id)
        {
            return LoadEjPowerupEvents(" ej_powerup_events_id=" + ej_powerup_events_id);
        }

        public static EjPowerupEvents LoadEjPowerupEventsByPk(int ej_powerup_events_id, IDbConnection conn)
        {
            return LoadEjPowerupEvents(" ej_powerup_events_id=" + ej_powerup_events_id, conn);
        }

        public void Save()
        {
            if (ej_powerup_events_idChanged || atm_idChanged || powerup_timeChanged || tsnChanged)
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
            if (ej_powerup_events_idChanged || atm_idChanged || powerup_timeChanged || tsnChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_powerup_events( ej_powerup_events_id,atm_id,powerup_time,tsn ) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.ej_powerup_events_id = ConnectionFactory.GetNextId();
                        qry.Append(this.ej_powerup_events_id);
                    } qry.Append(",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(powerup_timeDbString + ",");
                    qry.Append(tsnDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_powerup_events_idChanged || atm_idChanged || powerup_timeChanged || tsnChanged))
                        return;
                    qry.Append("UPDATE Ej_powerup_events set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (powerup_timeChanged)
                    {
                        qry.Append("powerup_time =" + powerup_timeDbString);
                        qry.Append(",");
                    }

                    if (tsnChanged)
                    {
                        qry.Append("tsn =" + tsnDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_powerup_events_id = " + ej_powerup_events_idDbString);
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
            cmd.CommandText = "DELETE Ej_powerup_events where ej_powerup_events_id = " + ej_powerup_events_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjPowerupEventss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_powerup_events where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            ej_powerup_events_id = 1,
            atm_id = 2,
            powerup_time = 4,
            tsn = 8
        }
        #endregion
        public void BulkSave(List<EjPowerupEvents> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_powerup_events";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjPowerupEvents.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjPowerupEvents> transList, ref DataTable dt)
        {
            foreach (EjPowerupEvents tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_powerup_events_id"] = ConnectionFactory.GetNextId();
                Row["atm_id"] = tran.AtmId;
                Row["powerup_time"] = tran.PowerupTime;
                Row["tsn"] = tran.Tsn;
                dt.Rows.Add(Row);
            }
        }
    }
}


