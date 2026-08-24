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
    public class CcmsOrder
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public CcmsOrder() { }
        public CcmsOrder(long id)
        {
            this.id = id;
            this.idChanged = true;
        }
        public CcmsOrder(long id, string order_number, long? atm_id, DateTime? order_date, string status, string source, DateTime? created_on, long? created_by, bool? is_validated, bool? is_deleted, DateTime? modified_on, long? modified_by, long? cit_id, long? batch_id)
        {
            this.id = id;
            this.idChanged = true;
            this.order_number = order_number;
            this.order_numberChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.order_date = order_date;
            this.order_dateChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.source = source;
            this.sourceChanged = true;
            this.created_on = created_on;
            this.created_onChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.is_validated = is_validated;
            this.is_validatedChanged = true;
            this.is_deleted = is_deleted;
            this.is_deletedChanged = true;
            this.modified_on = modified_on;
            this.modified_onChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.cit_id = cit_id;
            this.cit_idChanged = true;
            this.batch_id = batch_id;
            this.batch_idChanged = true;
        }

        #region members and properties for columns

        #region Id
        private bool idChanged = false;
        private long id;
        public long Id
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
        #region OrderNumber
        private bool order_numberChanged = false;
        private string order_number;
        public string OrderNumber
        {
            get { return order_number; }
            set
            {
                order_number = value;
                order_numberChanged = true;
            }
        }
        private string order_numberDbString
        {
            get
            {
                if (this.order_number != null)
                    return string.Format("'{0}'", order_number);
                else
                    return "null";
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private long? atm_id;
        public long? AtmId
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
        #region OrderDate
        private bool order_dateChanged = false;
        private DateTime? order_date;
        public DateTime? OrderDate
        {
            get { return order_date; }
            set
            {
                order_date = value;
                order_dateChanged = true;
            }
        }
        private string order_dateDbString
        {
            get
            {
                if (this.order_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", order_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Status
        private bool statusChanged = false;
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                statusChanged = true;
            }
        }
        private string statusDbString
        {
            get
            {
                if (this.status != null)
                    return string.Format("'{0}'", status);
                else
                    return "null";
            }
        }
        #endregion
        #region Source
        private bool sourceChanged = false;
        private string source;
        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                sourceChanged = true;
            }
        }
        private string sourceDbString
        {
            get
            {
                if (this.source != null)
                    return string.Format("'{0}'", source);
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedOn
        private bool created_onChanged = false;
        private DateTime? created_on;
        public DateTime? CreatedOn
        {
            get { return created_on; }
            set
            {
                created_on = value;
                created_onChanged = true;
            }
        }
        private string created_onDbString
        {
            get
            {
                if (this.created_on.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", created_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private long? created_by;
        public long? CreatedBy
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
        #region IsValidated
        private bool is_validatedChanged = false;
        private bool? is_validated;
        public bool? IsValidated
        {
            get { return is_validated; }
            set
            {
                is_validated = value;
                is_validatedChanged = true;
            }
        }
        private string is_validatedDbString
        {
            get
            {
                if (this.is_validated.HasValue)
                    return is_validated.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsDeleted
        private bool is_deletedChanged = false;
        private bool? is_deleted;
        public bool? IsDeleted
        {
            get { return is_deleted; }
            set
            {
                is_deleted = value;
                is_deletedChanged = true;
            }
        }
        private string is_deletedDbString
        {
            get
            {
                if (this.is_deleted.HasValue)
                    return is_deleted.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region ModifiedOn
        private bool modified_onChanged = false;
        private DateTime? modified_on;
        public DateTime? ModifiedOn
        {
            get { return modified_on; }
            set
            {
                modified_on = value;
                modified_onChanged = true;
            }
        }
        private string modified_onDbString
        {
            get
            {
                if (this.modified_on.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region ModifiedBy
        private bool modified_byChanged = false;
        private long? modified_by;
        public long? ModifiedBy
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
        #region BatchId
        private bool batch_idChanged = false;
        private long? batch_id;
        public long? BatchId
        {
            get { return batch_id; }
            set
            {
                batch_id = value;
                batch_idChanged = true;
            }
        }
        private string batch_idDbString
        {
            get
            {
                if (this.batch_id.HasValue)
                    return batch_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region CcmsOrderReader
        public class CcmsOrderReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            CcmsOrder currentCcmsOrder;
            Columns columns;
            bool partialRead = false;
            private CcmsOrderReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public CcmsOrderReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public CcmsOrderReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentCcmsOrder; }

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
                    currentCcmsOrder = new CcmsOrder();
                    if (partialRead)
                    {
                        if ((columns & Columns.id) == Columns.id && reader["id"] != DBNull.Value)
                            currentCcmsOrder.id = (long)reader["id"];
                        if ((columns & Columns.order_number) == Columns.order_number && reader["order_number"] != DBNull.Value)
                            currentCcmsOrder.order_number = (string)reader["order_number"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentCcmsOrder.atm_id = (long?)reader["atm_id"];
                        if ((columns & Columns.order_date) == Columns.order_date && reader["order_date"] != DBNull.Value)
                            currentCcmsOrder.order_date = (DateTime?)reader["order_date"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentCcmsOrder.status = (string)reader["status"];
                        if ((columns & Columns.source) == Columns.source && reader["source"] != DBNull.Value)
                            currentCcmsOrder.source = (string)reader["source"];
                        if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"] != DBNull.Value)
                            currentCcmsOrder.created_on = (DateTime?)reader["created_on"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentCcmsOrder.created_by = (long?)reader["created_by"];
                        if ((columns & Columns.is_validated) == Columns.is_validated && reader["is_validated"] != DBNull.Value)
                            currentCcmsOrder.is_validated = (bool?)reader["is_validated"];
                        if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"] != DBNull.Value)
                            currentCcmsOrder.is_deleted = (bool?)reader["is_deleted"];
                        if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"] != DBNull.Value)
                            currentCcmsOrder.modified_on = (DateTime?)reader["modified_on"];
                        if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"] != DBNull.Value)
                            currentCcmsOrder.modified_by = (long?)reader["modified_by"];
                        if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"] != DBNull.Value)
                            currentCcmsOrder.cit_id = (long?)reader["cit_id"];
                        if ((columns & Columns.batch_id) == Columns.batch_id && reader["batch_id"] != DBNull.Value)
                            currentCcmsOrder.batch_id = (long?)reader["batch_id"];

                    }
                    else
                    {
                        if (reader["id"] != DBNull.Value)
                            currentCcmsOrder.id = (long)reader["id"];
                        if (reader["order_number"] != DBNull.Value)
                            currentCcmsOrder.order_number = (string)reader["order_number"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentCcmsOrder.atm_id = (long?)reader["atm_id"];
                        if (reader["order_date"] != DBNull.Value)
                            currentCcmsOrder.order_date = (DateTime?)reader["order_date"];
                        if (reader["status"] != DBNull.Value)
                            currentCcmsOrder.status = (string)reader["status"];
                        if (reader["source"] != DBNull.Value)
                            currentCcmsOrder.source = (string)reader["source"];
                        if (reader["created_on"] != DBNull.Value)
                            currentCcmsOrder.created_on = (DateTime?)reader["created_on"];
                        if (reader["created_by"] != DBNull.Value)
                            currentCcmsOrder.created_by = (long?)reader["created_by"];
                        if (reader["is_validated"] != DBNull.Value)
                            currentCcmsOrder.is_validated = (bool?)reader["is_validated"];
                        if (reader["is_deleted"] != DBNull.Value)
                            currentCcmsOrder.is_deleted = (bool?)reader["is_deleted"];
                        if (reader["modified_on"] != DBNull.Value)
                            currentCcmsOrder.modified_on = (DateTime?)reader["modified_on"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentCcmsOrder.modified_by = (long?)reader["modified_by"];
                        if (reader["cit_id"] != DBNull.Value)
                            currentCcmsOrder.cit_id = (long?)reader["cit_id"];
                        if (reader["batch_id"] != DBNull.Value)
                            currentCcmsOrder.batch_id = (long?)reader["batch_id"];
                    }

                    currentCcmsOrder.isNewEntity = false;
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

            public CcmsOrder CurrentCcmsOrder
            {
                get { return currentCcmsOrder; }
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


        #region CcmsOrder functions

        public static CcmsOrderReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.id == (Columns.id & columns))
                qry.Append("id,");
            if (Columns.order_number == (Columns.order_number & columns))
                qry.Append("order_number,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.order_date == (Columns.order_date & columns))
                qry.Append("order_date,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.source == (Columns.source & columns))
                qry.Append("source,");
            if (Columns.created_on == (Columns.created_on & columns))
                qry.Append("created_on,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.is_validated == (Columns.is_validated & columns))
                qry.Append("is_validated,");
            if (Columns.is_deleted == (Columns.is_deleted & columns))
                qry.Append("is_deleted,");
            if (Columns.modified_on == (Columns.modified_on & columns))
                qry.Append("modified_on,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.cit_id == (Columns.cit_id & columns))
                qry.Append("cit_id,");
            if (Columns.batch_id == (Columns.batch_id & columns))
                qry.Append("batch_id,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ccms_order ");

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
            return new CcmsOrderReader(cmd.ExecuteReader(), conn, columns);
        }

        static public CcmsOrderReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static CcmsOrderReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select id,order_number,atm_id,order_date,status,source,created_on,created_by,is_validated,is_deleted,modified_on,modified_by,cit_id,batch_id from Ccms_order ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new CcmsOrderReader(cmd.ExecuteReader(), conn);
        }

        static public CcmsOrderReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static CcmsOrder LoadCcmsOrder(string where)
        {
            CcmsOrderReader reader = CcmsOrder.ExecuteReader(where);
            CcmsOrder _ccmsorder = null;
            if (reader.Read())
                _ccmsorder = reader.CurrentCcmsOrder;
            reader.Close();
            return _ccmsorder;
        }

        public static CcmsOrder LoadCcmsOrder(string where, IDbConnection conn)
        {
            CcmsOrderReader reader = CcmsOrder.ExecuteReader(where, conn);
            CcmsOrder _ccmsorder = null;
            if (reader.Read())
                _ccmsorder = reader.CurrentCcmsOrder;
            reader.Close(false);
            return _ccmsorder;
        }

        public static CcmsOrder LoadCcmsOrderByPk(long id)
        {
            return LoadCcmsOrder(" id=" + id);
        }

        public static CcmsOrder LoadCcmsOrderByPk(long id, IDbConnection conn)
        {
            return LoadCcmsOrder(" id=" + id, conn);
        }

        public void Save()
        {
            if (idChanged || order_numberChanged || atm_idChanged || order_dateChanged || statusChanged || sourceChanged || created_onChanged || created_byChanged || is_validatedChanged || is_deletedChanged || modified_onChanged || modified_byChanged || cit_idChanged || batch_idChanged)
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
            if (idChanged || order_numberChanged || atm_idChanged || order_dateChanged || statusChanged || sourceChanged || created_onChanged || created_byChanged || is_validatedChanged || is_deletedChanged || modified_onChanged || modified_byChanged || cit_idChanged || batch_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ccms_order( order_number,atm_id,order_date,status,source,created_on,created_by,is_validated,is_deleted,modified_on,modified_by,cit_id,batch_id ) values(");
                    
                    qry.Append(order_numberDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(order_dateDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(sourceDbString + ",");
                    qry.Append(created_onDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(is_validatedDbString + ",");
                    qry.Append(is_deletedDbString + ",");
                    qry.Append(modified_onDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(cit_idDbString + ",");
                    qry.Append(batch_idDbString);
                    qry.Append(");SELECT scope_identity()");

                }
                else
                {
                    if (!(idChanged || order_numberChanged || atm_idChanged || order_dateChanged || statusChanged || sourceChanged || created_onChanged || created_byChanged || is_validatedChanged || is_deletedChanged || modified_onChanged || modified_byChanged || cit_idChanged || batch_idChanged))
                        return;
                    qry.Append("UPDATE Ccms_order set "); if (order_numberChanged)
                    {
                        qry.Append("order_number =" + order_numberDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (order_dateChanged)
                    {
                        qry.Append("order_date =" + order_dateDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (sourceChanged)
                    {
                        qry.Append("source =" + sourceDbString);
                        qry.Append(",");
                    }

                    if (created_onChanged)
                    {
                        qry.Append("created_on =" + created_onDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (is_validatedChanged)
                    {
                        qry.Append("is_validated =" + is_validatedDbString);
                        qry.Append(",");
                    }

                    if (is_deletedChanged)
                    {
                        qry.Append("is_deleted =" + is_deletedDbString);
                        qry.Append(",");
                    }

                    if (modified_onChanged)
                    {
                        qry.Append("modified_on =" + modified_onDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }

                    if (cit_idChanged)
                    {
                        qry.Append("cit_id =" + cit_idDbString);
                        qry.Append(",");
                    }

                    if (batch_idChanged)
                    {
                        qry.Append("batch_id =" + batch_idDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("id = " + idDbString);
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
                    object res = cmd.ExecuteScalar();
                    if (res == DBNull.Value)
                        id = 1;
                    else
                        id = int.Parse(res.ToString());
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
            cmd.CommandText = "DELETE Ccms_order where id = " + id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteCcmsOrders(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ccms_order where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            id = 1,
            order_number = 2,
            atm_id = 4,
            order_date = 8,
            status = 16,
            source = 32,
            created_on = 64,
            created_by = 128,
            is_validated = 256,
            is_deleted = 512,
            modified_on = 1024,
            modified_by = 2048,
            cit_id = 4096,
            batch_id = 8192
        }
        #endregion
        public void BulkSave(List<CcmsOrder> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ccms_order";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(CcmsOrder.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<CcmsOrder> transList, ref DataTable dt)
        {
            foreach (CcmsOrder tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["id"] = tran.Id;
                Row["order_number"] = tran.OrderNumber;
                Row["atm_id"] = tran.AtmId;
                Row["order_date"] = tran.OrderDate;
                Row["status"] = tran.Status;
                Row["source"] = tran.Source;
                Row["created_on"] = tran.CreatedOn;
                Row["created_by"] = tran.CreatedBy;
                Row["is_validated"] = tran.IsValidated;
                Row["is_deleted"] = tran.IsDeleted;
                Row["modified_on"] = tran.ModifiedOn;
                Row["modified_by"] = tran.ModifiedBy;
                Row["cit_id"] = tran.CitId;
                Row["batch_id"] = tran.BatchId;
                dt.Rows.Add(Row);
            }
        }
    }
}
