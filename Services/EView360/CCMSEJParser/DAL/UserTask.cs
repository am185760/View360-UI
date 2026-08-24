
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
 public class UserTask
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public UserTask() { }
 public UserTask( int user_task_id,DateTime creation_time,int created_by,string status,int task_type_id ) 
 {
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.task_type_id = task_type_id;
 this.task_type_idChanged = true;
 }
 public UserTask( DateTime creation_time,int created_by,string status,int? atm_settlement_id,int task_type_id,string reason,int? atm_alert_id,int? atm_id,string entity_type,int? entity_id,string task_desc,int? resolved_by,DateTime? resolution_time,int? task_id )
 {
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.atm_settlement_id = atm_settlement_id;
 this.atm_settlement_idChanged = true;
 this.task_type_id = task_type_id;
 this.task_type_idChanged = true;
 this.reason = reason;
 this.reasonChanged = true;
 this.atm_alert_id = atm_alert_id;
 this.atm_alert_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.entity_type = entity_type;
 this.entity_typeChanged = true;
 this.entity_id = entity_id;
 this.entity_idChanged = true;
 this.task_desc = task_desc;
 this.task_descChanged = true;
 this.resolved_by = resolved_by;
 this.resolved_byChanged = true;
 this.resolution_time = resolution_time;
 this.resolution_timeChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 }
 private UserTask( int user_task_id,DateTime creation_time,int created_by,string status,int? atm_settlement_id,int task_type_id,string reason,int? atm_alert_id,int? atm_id,string entity_type,int? entity_id,string task_desc,int? resolved_by,DateTime? resolution_time,int? task_id )
 {
 this.user_task_id = user_task_id;
 this.user_task_idChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.atm_settlement_id = atm_settlement_id;
 this.atm_settlement_idChanged = true;
 this.task_type_id = task_type_id;
 this.task_type_idChanged = true;
 this.reason = reason;
 this.reasonChanged = true;
 this.atm_alert_id = atm_alert_id;
 this.atm_alert_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.entity_type = entity_type;
 this.entity_typeChanged = true;
 this.entity_id = entity_id;
 this.entity_idChanged = true;
 this.task_desc = task_desc;
 this.task_descChanged = true;
 this.resolved_by = resolved_by;
 this.resolved_byChanged = true;
 this.resolution_time = resolution_time;
 this.resolution_timeChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 }

 #region members and properties for columns

 #region UserTaskId
 private bool user_task_idChanged = false;
 private int user_task_id;
 public int UserTaskId
 {
 get { return user_task_id; }
 set { 
user_task_id = value;
user_task_idChanged = true;
 }
 }
 private string user_task_idDbString
 {
 get
 {
 return user_task_id.ToString();
 }
 }
 #endregion
 #region CreationTime
 private bool creation_timeChanged = false;
 private DateTime creation_time;
 public DateTime CreationTime
 {
 get { return creation_time; }
 set { 
creation_time = value;
creation_timeChanged = true;
 }
 }
 private string creation_timeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region CreatedBy
 private bool created_byChanged = false;
 private int created_by;
 public int CreatedBy
 {
 get { return created_by; }
 set { 
created_by = value;
created_byChanged = true;
 }
 }
 private string created_byDbString
 {
 get
 {
 return created_by.ToString();
 }
 }
 #endregion
 #region Status
 private bool statusChanged = false;
 private string status;
 public string Status
 {
 get { return status; }
 set { 
status = value;
statusChanged = true;
 }
 }
 private string statusDbString
 {
 get
 {
 if (this.status!=null)
 return string.Format("'{0}'",status); else
 return "null";
 }
 }
 #endregion
 #region AtmSettlementId
 private bool atm_settlement_idChanged = false;
 private int? atm_settlement_id;
 public int? AtmSettlementId
 {
 get { return atm_settlement_id; }
 set { 
atm_settlement_id = value;
atm_settlement_idChanged = true;
 }
 }
 private string atm_settlement_idDbString
 {
 get
 {
 if (this.atm_settlement_id.HasValue)
 return atm_settlement_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region TaskTypeId
 private bool task_type_idChanged = false;
 private int task_type_id;
 public int TaskTypeId
 {
 get { return task_type_id; }
 set { 
task_type_id = value;
task_type_idChanged = true;
 }
 }
 private string task_type_idDbString
 {
 get
 {
 return task_type_id.ToString();
 }
 }
 #endregion
 #region Reason
 private bool reasonChanged = false;
 private string reason;
 public string Reason
 {
 get { return reason; }
 set { 
reason = value;
reasonChanged = true;
 }
 }
 private string reasonDbString
 {
 get
 {
 if (this.reason!=null)
 return string.Format("'{0}'",reason); else
 return "null";
 }
 }
 #endregion
 #region AtmAlertId
 private bool atm_alert_idChanged = false;
 private int? atm_alert_id;
 public int? AtmAlertId
 {
 get { return atm_alert_id; }
 set { 
atm_alert_id = value;
atm_alert_idChanged = true;
 }
 }
 private string atm_alert_idDbString
 {
 get
 {
 if (this.atm_alert_id.HasValue)
 return atm_alert_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region AtmId
 private bool atm_idChanged = false;
 private int? atm_id;
 public int? AtmId
 {
 get { return atm_id; }
 set { 
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
 #region EntityType
 private bool entity_typeChanged = false;
 private string entity_type;
 public string EntityType
 {
 get { return entity_type; }
 set { 
entity_type = value;
entity_typeChanged = true;
 }
 }
 private string entity_typeDbString
 {
 get
 {
 if (this.entity_type!=null)
 return string.Format("'{0}'",entity_type); else
 return "null";
 }
 }
 #endregion
 #region EntityId
 private bool entity_idChanged = false;
 private int? entity_id;
 public int? EntityId
 {
 get { return entity_id; }
 set { 
entity_id = value;
entity_idChanged = true;
 }
 }
 private string entity_idDbString
 {
 get
 {
 if (this.entity_id.HasValue)
 return entity_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region TaskDesc
 private bool task_descChanged = false;
 private string task_desc;
 public string TaskDesc
 {
 get { return task_desc; }
 set { 
task_desc = value;
task_descChanged = true;
 }
 }
 private string task_descDbString
 {
 get
 {
 if (this.task_desc!=null)
 return string.Format("'{0}'",task_desc); else
 return "null";
 }
 }
 #endregion
 #region ResolvedBy
 private bool resolved_byChanged = false;
 private int? resolved_by;
 public int? ResolvedBy
 {
 get { return resolved_by; }
 set { 
resolved_by = value;
resolved_byChanged = true;
 }
 }
 private string resolved_byDbString
 {
 get
 {
 if (this.resolved_by.HasValue)
 return resolved_by.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region ResolutionTime
 private bool resolution_timeChanged = false;
 private DateTime? resolution_time;
 public DateTime? ResolutionTime
 {
 get { return resolution_time; }
 set { 
resolution_time = value;
resolution_timeChanged = true;
 }
 }
 private string resolution_timeDbString
 {
 get
 {
 if (this.resolution_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",resolution_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region TaskId
 private bool task_idChanged = false;
 private int? task_id;
 public int? TaskId
 {
 get { return task_id; }
 set { 
task_id = value;
task_idChanged = true;
 }
 }
 private string task_idDbString
 {
 get
 {
 if (this.task_id.HasValue)
 return task_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region UserTaskReader
 public class UserTaskReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
UserTask currentUserTask;
 Columns columns;
 bool partialRead = false;
 private UserTaskReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public UserTaskReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public UserTaskReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentUserTask; }

 } public void Close()
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
 currentUserTask = new UserTask();
 if (partialRead)
 { if ((columns & Columns.user_task_id) == Columns.user_task_id && reader["user_task_id"]!=DBNull.Value)
 currentUserTask.user_task_id =(int) reader["user_task_id"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentUserTask.creation_time =(DateTime) reader["creation_time"]; 
 if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
 currentUserTask.created_by =(int) reader["created_by"]; 
 if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
 currentUserTask.status =(string) reader["status"]; 
 if ((columns & Columns.atm_settlement_id) == Columns.atm_settlement_id && reader["atm_settlement_id"]!=DBNull.Value)
 currentUserTask.atm_settlement_id =(int?) reader["atm_settlement_id"]; 
 if ((columns & Columns.task_type_id) == Columns.task_type_id && reader["task_type_id"]!=DBNull.Value)
 currentUserTask.task_type_id =(int) reader["task_type_id"]; 
 if ((columns & Columns.reason) == Columns.reason && reader["reason"]!=DBNull.Value)
 currentUserTask.reason =(string) reader["reason"]; 
 if ((columns & Columns.atm_alert_id) == Columns.atm_alert_id && reader["atm_alert_id"]!=DBNull.Value)
 currentUserTask.atm_alert_id =(int?) reader["atm_alert_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentUserTask.atm_id =(int?) reader["atm_id"]; 
 if ((columns & Columns.entity_type) == Columns.entity_type && reader["entity_type"]!=DBNull.Value)
 currentUserTask.entity_type =(string) reader["entity_type"]; 
 if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"]!=DBNull.Value)
 currentUserTask.entity_id =(int?) reader["entity_id"]; 
 if ((columns & Columns.task_desc) == Columns.task_desc && reader["task_desc"]!=DBNull.Value)
 currentUserTask.task_desc =(string) reader["task_desc"]; 
 if ((columns & Columns.resolved_by) == Columns.resolved_by && reader["resolved_by"]!=DBNull.Value)
 currentUserTask.resolved_by =(int?) reader["resolved_by"]; 
 if ((columns & Columns.resolution_time) == Columns.resolution_time && reader["resolution_time"]!=DBNull.Value)
 currentUserTask.resolution_time =(DateTime?) reader["resolution_time"]; 
 if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
 currentUserTask.task_id =(int?) reader["task_id"]; 

 } else
 {
 if (reader["user_task_id"] != DBNull.Value)
 currentUserTask.user_task_id = (int) reader["user_task_id"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentUserTask.creation_time = (DateTime) reader["creation_time"]; 
 if (reader["created_by"] != DBNull.Value)
 currentUserTask.created_by = (int) reader["created_by"]; 
 if (reader["status"] != DBNull.Value)
 currentUserTask.status = (string) reader["status"]; 
 if (reader["atm_settlement_id"] != DBNull.Value)
 currentUserTask.atm_settlement_id = (int?) reader["atm_settlement_id"]; 
 if (reader["task_type_id"] != DBNull.Value)
 currentUserTask.task_type_id = (int) reader["task_type_id"]; 
 if (reader["reason"] != DBNull.Value)
 currentUserTask.reason = (string) reader["reason"]; 
 if (reader["atm_alert_id"] != DBNull.Value)
 currentUserTask.atm_alert_id = (int?) reader["atm_alert_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentUserTask.atm_id = (int?) reader["atm_id"]; 
 if (reader["entity_type"] != DBNull.Value)
 currentUserTask.entity_type = (string) reader["entity_type"]; 
 if (reader["entity_id"] != DBNull.Value)
 currentUserTask.entity_id = (int?) reader["entity_id"]; 
 if (reader["task_desc"] != DBNull.Value)
 currentUserTask.task_desc = (string) reader["task_desc"]; 
 if (reader["resolved_by"] != DBNull.Value)
 currentUserTask.resolved_by = (int?) reader["resolved_by"]; 
 if (reader["resolution_time"] != DBNull.Value)
 currentUserTask.resolution_time = (DateTime?) reader["resolution_time"]; 
 if (reader["task_id"] != DBNull.Value)
 currentUserTask.task_id = (int?) reader["task_id"]; 
 } 

 currentUserTask.isNewEntity = false;
 return true;
 }
 else
 return false;
 }
 #region IEnumerable Members

 public IEnumerator GetEnumerator()
 { return this;
 } 
 #endregion


 #region IEnumerator Members

 public UserTask CurrentUserTask
 {
 get{ return currentUserTask; }
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


 #region UserTask functions

 public static UserTaskReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.user_task_id == (Columns.user_task_id & columns))
 qry.Append("user_task_id,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.created_by == (Columns.created_by & columns))
 qry.Append("created_by,");
 if (Columns.status == (Columns.status & columns))
 qry.Append("status,");
 if (Columns.atm_settlement_id == (Columns.atm_settlement_id & columns))
 qry.Append("atm_settlement_id,");
 if (Columns.task_type_id == (Columns.task_type_id & columns))
 qry.Append("task_type_id,");
 if (Columns.reason == (Columns.reason & columns))
 qry.Append("reason,");
 if (Columns.atm_alert_id == (Columns.atm_alert_id & columns))
 qry.Append("atm_alert_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.entity_type == (Columns.entity_type & columns))
 qry.Append("entity_type,");
 if (Columns.entity_id == (Columns.entity_id & columns))
 qry.Append("entity_id,");
 if (Columns.task_desc == (Columns.task_desc & columns))
 qry.Append("task_desc,");
 if (Columns.resolved_by == (Columns.resolved_by & columns))
 qry.Append("resolved_by,");
 if (Columns.resolution_time == (Columns.resolution_time & columns))
 qry.Append("resolution_time,");
 if (Columns.task_id == (Columns.task_id & columns))
 qry.Append("task_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from User_task ");

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
 return new UserTaskReader(cmd.ExecuteReader(), conn, columns);
 }

 static public UserTaskReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static UserTaskReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select user_task_id,creation_time,created_by,status,atm_settlement_id,task_type_id,reason,atm_alert_id,atm_id,entity_type,entity_id,task_desc,resolved_by,resolution_time,task_id from User_task ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new UserTaskReader(cmd.ExecuteReader(), conn);
 }

 static public UserTaskReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static UserTask LoadUserTask(string where)
 {
UserTaskReader reader = UserTask.ExecuteReader(where);
UserTask _usertask = null;
 if (reader.Read())
 _usertask = reader.CurrentUserTask;
 reader.Close();
 return _usertask;
 }

 public static UserTask LoadUserTask(string where, IDbConnection conn)
 {
UserTaskReader reader = UserTask.ExecuteReader(where, conn);
UserTask _usertask = null;
 if (reader.Read())
 _usertask = reader.CurrentUserTask;
 reader.Close(false);
 return _usertask;
 }

 public static UserTask LoadUserTaskByPk( int user_task_id )
 {
 return LoadUserTask( " user_task_id="+user_task_id );
 }

 public static UserTask LoadUserTaskByPk( int user_task_id , IDbConnection conn)
 {
 return LoadUserTask(" user_task_id="+user_task_id , conn);
 }

 public void Save()
 {
 if (user_task_idChanged || creation_timeChanged || created_byChanged || statusChanged || atm_settlement_idChanged || task_type_idChanged || reasonChanged || atm_alert_idChanged || atm_idChanged || entity_typeChanged || entity_idChanged || task_descChanged || resolved_byChanged || resolution_timeChanged || task_idChanged )
 ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());
 }

 public void Save(IDbConnection conn,IDbTransaction trx)
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
 private void ExcuteSave(IDbCommand cmd) {
 if (user_task_idChanged || creation_timeChanged || created_byChanged || statusChanged || atm_settlement_idChanged || task_type_idChanged || reasonChanged || atm_alert_idChanged || atm_idChanged || entity_typeChanged || entity_idChanged || task_descChanged || resolved_byChanged || resolution_timeChanged || task_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into User_task( user_task_id,creation_time,created_by,status,atm_settlement_id,task_type_id,reason,atm_alert_id,atm_id,entity_type,entity_id,task_desc,resolved_by,resolution_time,task_id ) values(");
 lock (ConnectionFactory.connectionString) { this.user_task_id = ConnectionFactory.GetNextId();
 qry.Append(this.user_task_id);
 } qry.Append(",");
 qry.Append(creation_timeDbString+",");
 qry.Append(created_byDbString+",");
 qry.Append(statusDbString+",");
 qry.Append(atm_settlement_idDbString+",");
 qry.Append(task_type_idDbString+",");
 qry.Append(reasonDbString+",");
 qry.Append(atm_alert_idDbString+",");
 qry.Append(atm_idDbString+",");
 qry.Append(entity_typeDbString+",");
 qry.Append(entity_idDbString+",");
 qry.Append(task_descDbString+",");
 qry.Append(resolved_byDbString+",");
 qry.Append(resolution_timeDbString+",");
 qry.Append(task_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(user_task_idChanged || creation_timeChanged || created_byChanged || statusChanged || atm_settlement_idChanged || task_type_idChanged || reasonChanged || atm_alert_idChanged || atm_idChanged || entity_typeChanged || entity_idChanged || task_descChanged || resolved_byChanged || resolution_timeChanged || task_idChanged ))
 return;
 qry.Append("UPDATE User_task set "); if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( created_byChanged )
 {
 qry.Append("created_by ="+created_byDbString);
 qry.Append(",");
 }

 if ( statusChanged )
 {
 qry.Append("status ="+statusDbString);
 qry.Append(",");
 }

 if ( atm_settlement_idChanged )
 {
 qry.Append("atm_settlement_id ="+atm_settlement_idDbString);
 qry.Append(",");
 }

 if ( task_type_idChanged )
 {
 qry.Append("task_type_id ="+task_type_idDbString);
 qry.Append(",");
 }

 if ( reasonChanged )
 {
 qry.Append("reason ="+reasonDbString);
 qry.Append(",");
 }

 if ( atm_alert_idChanged )
 {
 qry.Append("atm_alert_id ="+atm_alert_idDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( entity_typeChanged )
 {
 qry.Append("entity_type ="+entity_typeDbString);
 qry.Append(",");
 }

 if ( entity_idChanged )
 {
 qry.Append("entity_id ="+entity_idDbString);
 qry.Append(",");
 }

 if ( task_descChanged )
 {
 qry.Append("task_desc ="+task_descDbString);
 qry.Append(",");
 }

 if ( resolved_byChanged )
 {
 qry.Append("resolved_by ="+resolved_byDbString);
 qry.Append(",");
 }

 if ( resolution_timeChanged )
 {
 qry.Append("resolution_time ="+resolution_timeDbString);
 qry.Append(",");
 }

 if ( task_idChanged )
 {
 qry.Append("task_id ="+task_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("user_task_id = "+user_task_idDbString);
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
 cmd.CommandText = "DELETE User_task where user_task_id = "+ user_task_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteUserTasks(string where)
 {
 ConnectionFactory.ExecuteQuery("delete User_task where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
user_task_id= 1,
creation_time= 2,
created_by= 4,
status= 8,
atm_settlement_id= 16,
task_type_id= 32,
reason= 64,
atm_alert_id= 128,
atm_id= 256,
entity_type= 512,
entity_id= 1024,
task_desc= 2048,
resolved_by= 4096,
resolution_time= 8192,
task_id= 16384
 }
 #endregion
 public void BulkSave(List<UserTask> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "User_task";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(UserTask.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <UserTask> transList,ref DataTable dt)
 {
 foreach (UserTask tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["user_task_id"] =ConnectionFactory.GetNextId();
 Row["creation_time"] = tran.CreationTime;
 Row["created_by"] = tran.CreatedBy;
 Row["status"] = tran.Status;
 Row["atm_settlement_id"] = tran.AtmSettlementId;
 Row["task_type_id"] = tran.TaskTypeId;
 Row["reason"] = tran.Reason;
 Row["atm_alert_id"] = tran.AtmAlertId;
 Row["atm_id"] = tran.AtmId;
 Row["entity_type"] = tran.EntityType;
 Row["entity_id"] = tran.EntityId;
 Row["task_desc"] = tran.TaskDesc;
 Row["resolved_by"] = tran.ResolvedBy;
 Row["resolution_time"] = tran.ResolutionTime;
 Row["task_id"] = tran.TaskId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
