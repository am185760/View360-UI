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
    public class GroupsApprover
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public GroupsApprover() { }
        public GroupsApprover(int group_approver_id, int group_id, string group_name)
        {
            this.group_approver_id = group_approver_id;
            this.group_approver_idChanged = true;
            this.group_id = group_id;
            this.group_idChanged = true;
            this.group_name = group_name;
            this.group_nameChanged = true;
        }
        public GroupsApprover(int group_approver_id, int group_id, string group_name, string description, string entity_type, int? created_by, int? organization_id, bool? send_individual_alert, bool? is_added, bool? is_editied, bool? is_deleted, string status, string group_email)
        {
            this.group_approver_id = group_approver_id;
            this.group_approver_idChanged = true;
            this.group_id = group_id;
            this.group_idChanged = true;
            this.group_name = group_name;
            this.group_nameChanged = true;
            this.description = description;
            this.descriptionChanged = true;
            this.entity_type = entity_type;
            this.entity_typeChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.organization_id = organization_id;
            this.organization_idChanged = true;
            this.send_individual_alert = send_individual_alert;
            this.send_individual_alertChanged = true;
            this.is_added = is_added;
            this.is_addedChanged = true;
            this.is_editied = is_editied;
            this.is_editiedChanged = true;
            this.is_deleted = is_deleted;
            this.is_deletedChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.group_email = group_email;
            this.group_emailChanged = true;
        }

        #region members and properties for columns

        #region GroupApproverId
        private bool group_approver_idChanged = false;
        private int group_approver_id;
        public int GroupApproverId
        {
            get { return group_approver_id; }
            set
            {
                group_approver_id = value;
                group_approver_idChanged = true;
            }
        }
        private string group_approver_idDbString
        {
            get
            {
                return group_approver_id.ToString();
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
        #region GroupName
        private bool group_nameChanged = false;
        private string group_name;
        public string GroupName
        {
            get { return group_name; }
            set
            {
                group_name = value;
                group_nameChanged = true;
            }
        }
        private string group_nameDbString
        {
            get
            {
                if (this.group_name != null)
                    return string.Format("'{0}'", group_name);
                else
                    return "null";
            }
        }
        #endregion
        #region Description
        private bool descriptionChanged = false;
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                descriptionChanged = true;
            }
        }
        private string descriptionDbString
        {
            get
            {
                if (this.description != null)
                    return string.Format("'{0}'", description);
                else
                    return "null";
            }
        }
        #endregion
        #region EntityType
        private bool entity_typeChanged = false;
        private string entity_type;
        public string EntityType
        {
            get { return entity_type; }
            set
            {
                entity_type = value;
                entity_typeChanged = true;
            }
        }
        private string entity_typeDbString
        {
            get
            {
                if (this.entity_type != null)
                    return string.Format("'{0}'", entity_type);
                else
                    return "null";
            }
        }
        #endregion
        #region CreatedBy
        private bool created_byChanged = false;
        private int? created_by;
        public int? CreatedBy
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
        #region OrganizationId
        private bool organization_idChanged = false;
        private int? organization_id;
        public int? OrganizationId
        {
            get { return organization_id; }
            set
            {
                organization_id = value;
                organization_idChanged = true;
            }
        }
        private string organization_idDbString
        {
            get
            {
                if (this.organization_id.HasValue)
                    return organization_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region SendIndividualAlert
        private bool send_individual_alertChanged = false;
        private bool? send_individual_alert;
        public bool? SendIndividualAlert
        {
            get { return send_individual_alert; }
            set
            {
                send_individual_alert = value;
                send_individual_alertChanged = true;
            }
        }
        private string send_individual_alertDbString
        {
            get
            {
                if (this.send_individual_alert.HasValue)
                    return send_individual_alert.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsAdded
        private bool is_addedChanged = false;
        private bool? is_added;
        public bool? IsAdded
        {
            get { return is_added; }
            set
            {
                is_added = value;
                is_addedChanged = true;
            }
        }
        private string is_addedDbString
        {
            get
            {
                if (this.is_added.HasValue)
                    return is_added.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsEditied
        private bool is_editiedChanged = false;
        private bool? is_editied;
        public bool? IsEditied
        {
            get { return is_editied; }
            set
            {
                is_editied = value;
                is_editiedChanged = true;
            }
        }
        private string is_editiedDbString
        {
            get
            {
                if (this.is_editied.HasValue)
                    return is_editied.Value ? "1" : "0";
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
        #region GroupEmail
        private bool group_emailChanged = false;
        private string group_email;
        public string GroupEmail
        {
            get { return group_email; }
            set
            {
                group_email = value;
                group_emailChanged = true;
            }
        }
        private string group_emailDbString
        {
            get
            {
                if (this.group_email != null)
                    return string.Format("'{0}'", group_email);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region GroupsApproverReader
        public class GroupsApproverReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            GroupsApprover currentGroupsApprover;
            Columns columns;
            bool partialRead = false;
            private GroupsApproverReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public GroupsApproverReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public GroupsApproverReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentGroupsApprover; }

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
                    currentGroupsApprover = new GroupsApprover();
                    if (partialRead)
                    {
                        if ((columns & Columns.group_approver_id) == Columns.group_approver_id && reader["group_approver_id"] != DBNull.Value)
                            currentGroupsApprover.group_approver_id = (int)reader["group_approver_id"];
                        if ((columns & Columns.group_id) == Columns.group_id && reader["group_id"] != DBNull.Value)
                            currentGroupsApprover.group_id = (int)reader["group_id"];
                        if ((columns & Columns.group_name) == Columns.group_name && reader["group_name"] != DBNull.Value)
                            currentGroupsApprover.group_name = (string)reader["group_name"];
                        if ((columns & Columns.description) == Columns.description && reader["description"] != DBNull.Value)
                            currentGroupsApprover.description = (string)reader["description"];
                        if ((columns & Columns.entity_type) == Columns.entity_type && reader["entity_type"] != DBNull.Value)
                            currentGroupsApprover.entity_type = (string)reader["entity_type"];
                        if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"] != DBNull.Value)
                            currentGroupsApprover.created_by = (int?)reader["created_by"];
                        if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"] != DBNull.Value)
                            currentGroupsApprover.organization_id = (int?)reader["organization_id"];
                        if ((columns & Columns.send_individual_alert) == Columns.send_individual_alert && reader["send_individual_alert"] != DBNull.Value)
                            currentGroupsApprover.send_individual_alert = (bool?)reader["send_individual_alert"];
                        if ((columns & Columns.is_added) == Columns.is_added && reader["is_added"] != DBNull.Value)
                            currentGroupsApprover.is_added = (bool?)reader["is_added"];
                        if ((columns & Columns.is_editied) == Columns.is_editied && reader["is_editied"] != DBNull.Value)
                            currentGroupsApprover.is_editied = (bool?)reader["is_editied"];
                        if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"] != DBNull.Value)
                            currentGroupsApprover.is_deleted = (bool?)reader["is_deleted"];
                        if ((columns & Columns.Status) == Columns.Status && reader["Status"] != DBNull.Value)
                            currentGroupsApprover.status = (string)reader["Status"];
                        if ((columns & Columns.group_email) == Columns.group_email && reader["group_email"] != DBNull.Value)
                            currentGroupsApprover.group_email = (string)reader["group_email"];

                    }
                    else
                    {
                        if (reader["group_approver_id"] != DBNull.Value)
                            currentGroupsApprover.group_approver_id = (int)reader["group_approver_id"];
                        if (reader["group_id"] != DBNull.Value)
                            currentGroupsApprover.group_id = (int)reader["group_id"];
                        if (reader["group_name"] != DBNull.Value)
                            currentGroupsApprover.group_name = (string)reader["group_name"];
                        if (reader["description"] != DBNull.Value)
                            currentGroupsApprover.description = (string)reader["description"];
                        if (reader["entity_type"] != DBNull.Value)
                            currentGroupsApprover.entity_type = (string)reader["entity_type"];
                        if (reader["created_by"] != DBNull.Value)
                            currentGroupsApprover.created_by = (int?)reader["created_by"];
                        if (reader["organization_id"] != DBNull.Value)
                            currentGroupsApprover.organization_id = (int?)reader["organization_id"];
                        if (reader["send_individual_alert"] != DBNull.Value)
                            currentGroupsApprover.send_individual_alert = (bool?)reader["send_individual_alert"];
                        if (reader["is_added"] != DBNull.Value)
                            currentGroupsApprover.is_added = (bool?)reader["is_added"];
                        if (reader["is_editied"] != DBNull.Value)
                            currentGroupsApprover.is_editied = (bool?)reader["is_editied"];
                        if (reader["is_deleted"] != DBNull.Value)
                            currentGroupsApprover.is_deleted = (bool?)reader["is_deleted"];
                        if (reader["Status"] != DBNull.Value)
                            currentGroupsApprover.status = (string)reader["Status"];
                        if (reader["group_email"] != DBNull.Value)
                            currentGroupsApprover.group_email = (string)reader["group_email"];
                    }

                    currentGroupsApprover.isNewEntity = false;
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

            public GroupsApprover CurrentGroupsApprover
            {
                get { return currentGroupsApprover; }
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


        #region GroupsApprover functions

        public static GroupsApproverReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.group_approver_id == (Columns.group_approver_id & columns))
                qry.Append("group_approver_id,");
            if (Columns.group_id == (Columns.group_id & columns))
                qry.Append("group_id,");
            if (Columns.group_name == (Columns.group_name & columns))
                qry.Append("group_name,");
            if (Columns.description == (Columns.description & columns))
                qry.Append("description,");
            if (Columns.entity_type == (Columns.entity_type & columns))
                qry.Append("entity_type,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.organization_id == (Columns.organization_id & columns))
                qry.Append("organization_id,");
            if (Columns.send_individual_alert == (Columns.send_individual_alert & columns))
                qry.Append("send_individual_alert,");
            if (Columns.is_added == (Columns.is_added & columns))
                qry.Append("is_added,");
            if (Columns.is_editied == (Columns.is_editied & columns))
                qry.Append("is_editied,");
            if (Columns.is_deleted == (Columns.is_deleted & columns))
                qry.Append("is_deleted,");
            if (Columns.Status == (Columns.Status & columns))
                qry.Append("Status,");
            if (Columns.group_email == (Columns.group_email & columns))
                qry.Append("group_email,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Groups_approver ");

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
            return new GroupsApproverReader(cmd.ExecuteReader(), conn, columns);
        }

        static public GroupsApproverReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static GroupsApproverReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select group_approver_id,group_id,group_name,description,entity_type,created_by,organization_id,send_individual_alert,is_added,is_editied,is_deleted,Status,group_email from Groups_approver ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new GroupsApproverReader(cmd.ExecuteReader(), conn);
        }

        static public GroupsApproverReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static GroupsApprover LoadGroupsApprover(string where)
        {
            GroupsApproverReader reader = GroupsApprover.ExecuteReader(where);
            GroupsApprover _groupsapprover = null;
            if (reader.Read())
                _groupsapprover = reader.CurrentGroupsApprover;
            reader.Close();
            return _groupsapprover;
        }

        public static GroupsApprover LoadGroupsApprover(string where, IDbConnection conn)
        {
            GroupsApproverReader reader = GroupsApprover.ExecuteReader(where, conn);
            GroupsApprover _groupsapprover = null;
            if (reader.Read())
                _groupsapprover = reader.CurrentGroupsApprover;
            reader.Close(false);
            return _groupsapprover;
        }
        public static GroupsApprover LoadAppUseApproverrByGroupName(string group_name)
        {
            return LoadGroupsApprover(" group_name= '" + group_name + " ' ");
        }

        public void Save()
        {
            if (group_approver_idChanged || group_idChanged || group_nameChanged || descriptionChanged || entity_typeChanged || created_byChanged || organization_idChanged || send_individual_alertChanged || is_addedChanged || is_editiedChanged || is_deletedChanged || statusChanged || group_emailChanged)
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
            if (group_approver_idChanged || group_idChanged || group_nameChanged || descriptionChanged || entity_typeChanged || created_byChanged || organization_idChanged || send_individual_alertChanged || is_addedChanged || is_editiedChanged || is_deletedChanged || statusChanged || group_emailChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Groups_approver( group_approver_id,group_id,group_name,description,entity_type,created_by,organization_id,send_individual_alert,is_added,is_editied,is_deleted,Status,group_email ) values(");
                    qry.Append(group_approver_idDbString + ",");
                    qry.Append(group_idDbString + ",");
                    qry.Append(group_nameDbString + ",");
                    qry.Append(descriptionDbString + ",");
                    qry.Append(entity_typeDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(organization_idDbString + ",");
                    qry.Append(send_individual_alertDbString + ",");
                    qry.Append(is_addedDbString + ",");
                    qry.Append(is_editiedDbString + ",");
                    qry.Append(is_deletedDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(group_emailDbString);
                    qry.Append(");");

                }
                else
                {
                    throw new Exception("No primary key is defined, can not update Groups_approver!");
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

        public static void DeleteGroupsApprovers(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Groups_approver where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : uint
        {
            group_approver_id = 1,
            group_id = 2,
            group_name = 4,
            description = 8,
            entity_type = 16,
            created_by = 32,
            organization_id = 64,
            send_individual_alert = 128,
            is_added = 256,
            is_editied = 512,
            is_deleted = 1024,
            Status = 2048,
            group_email = 4096
        }
        #endregion
        public void BulkSave(List<GroupsApprover> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Groups_approver";
            bulk.WriteToServer(dt);
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(GroupsApprover.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<GroupsApprover> transList, ref DataTable dt)
        {
            foreach (GroupsApprover tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["group_approver_id"] = tran.GroupApproverId;
                Row["group_id"] = tran.GroupId;
                Row["group_name"] = tran.GroupName;
                Row["description"] = tran.Description;
                Row["entity_type"] = tran.EntityType;
                Row["created_by"] = tran.CreatedBy;
                Row["organization_id"] = tran.OrganizationId;
                Row["send_individual_alert"] = tran.SendIndividualAlert;
                Row["is_added"] = tran.IsAdded;
                Row["is_editied"] = tran.IsEditied;
                Row["is_deleted"] = tran.IsDeleted;
                Row["status"] = tran.Status;
                Row["group_email"] = tran.GroupEmail;
                dt.Rows.Add(Row);
            }
        }
    }
}
