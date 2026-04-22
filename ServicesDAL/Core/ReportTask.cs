
using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Threading;
 using System.Data.SqlClient;

 namespace ServicesDAL
{
 [Serializable()]
 public class ReportTask
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ReportTask() { }
 public ReportTask( long report_task_id,long report_schedule_id,int retry_count,DateTime creation_time,string status,DateTime schedule_date ) 
 {
 this.report_schedule_id = report_schedule_id;
 this.report_schedule_idChanged = true;
 this.retry_count = retry_count;
 this.retry_countChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.schedule_date = schedule_date;
 this.schedule_dateChanged = true;
 }
 public ReportTask( long report_schedule_id,string file_path_attachment,int retry_count,string failure_reason,DateTime creation_time,DateTime? last_invoked_at,string status,DateTime schedule_date,DateTime? from_date,DateTime? to_date,int? atm_id )
 {
 this.report_schedule_id = report_schedule_id;
 this.report_schedule_idChanged = true;
 this.file_path_attachment = file_path_attachment;
 this.file_path_attachmentChanged = true;
 this.retry_count = retry_count;
 this.retry_countChanged = true;
 this.failure_reason = failure_reason;
 this.failure_reasonChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.last_invoked_at = last_invoked_at;
 this.last_invoked_atChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.schedule_date = schedule_date;
 this.schedule_dateChanged = true;
 this.from_date = from_date;
 this.from_dateChanged = true;
 this.to_date = to_date;
 this.to_dateChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }
 private ReportTask( long report_task_id,long report_schedule_id,string file_path_attachment,int retry_count,string failure_reason,DateTime creation_time,DateTime? last_invoked_at,string status,DateTime schedule_date,DateTime? from_date,DateTime? to_date,int? atm_id )
 {
 this.report_task_id = report_task_id;
 this.report_task_idChanged = true;
 this.report_schedule_id = report_schedule_id;
 this.report_schedule_idChanged = true;
 this.file_path_attachment = file_path_attachment;
 this.file_path_attachmentChanged = true;
 this.retry_count = retry_count;
 this.retry_countChanged = true;
 this.failure_reason = failure_reason;
 this.failure_reasonChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.last_invoked_at = last_invoked_at;
 this.last_invoked_atChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.schedule_date = schedule_date;
 this.schedule_dateChanged = true;
 this.from_date = from_date;
 this.from_dateChanged = true;
 this.to_date = to_date;
 this.to_dateChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }

 #region members and properties for columns

 #region ReportTaskId
 private bool report_task_idChanged = false;
 private long report_task_id;
 public long ReportTaskId
 {
 get { return report_task_id; }
 set { 
report_task_id = value;
report_task_idChanged = true;
 }
 }
 private string report_task_idDbString
 {
 get
 {
 return report_task_id.ToString();
 }
 }
 #endregion
 #region ReportScheduleId
 private bool report_schedule_idChanged = false;
 private long report_schedule_id;
 public long ReportScheduleId
 {
 get { return report_schedule_id; }
 set { 
report_schedule_id = value;
report_schedule_idChanged = true;
 }
 }
 private string report_schedule_idDbString
 {
 get
 {
 return report_schedule_id.ToString();
 }
 }
 #endregion
 #region FilePathAttachment
 private bool file_path_attachmentChanged = false;
 private string file_path_attachment;
 public string FilePathAttachment
 {
 get { return file_path_attachment; }
 set { 
file_path_attachment = value;
file_path_attachmentChanged = true;
 }
 }
 private string file_path_attachmentDbString
 {
 get
 {
 if (this.file_path_attachment!=null)
 return string.Format("'{0}'",file_path_attachment); else
 return "null";
 }
 }
 #endregion
 #region RetryCount
 private bool retry_countChanged = false;
 private int retry_count;
 public int RetryCount
 {
 get { return retry_count; }
 set { 
retry_count = value;
retry_countChanged = true;
 }
 }
 private string retry_countDbString
 {
 get
 {
 return retry_count.ToString();
 }
 }
 #endregion
 #region FailureReason
 private bool failure_reasonChanged = false;
 private string failure_reason;
 public string FailureReason
 {
 get { return failure_reason; }
 set { 
failure_reason = value;
failure_reasonChanged = true;
 }
 }
 private string failure_reasonDbString
 {
 get
 {
 if (this.failure_reason!=null)
 return string.Format("'{0}'",failure_reason); else
 return "null";
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
 #region LastInvokedAt
 private bool last_invoked_atChanged = false;
 private DateTime? last_invoked_at;
 public DateTime? LastInvokedAt
 {
 get { return last_invoked_at; }
 set { 
last_invoked_at = value;
last_invoked_atChanged = true;
 }
 }
 private string last_invoked_atDbString
 {
 get
 {
 if (this.last_invoked_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",last_invoked_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
 #region ScheduleDate
 private bool schedule_dateChanged = false;
 private DateTime schedule_date;
 public DateTime ScheduleDate
 {
 get { return schedule_date; }
 set { 
schedule_date = value;
schedule_dateChanged = true;
 }
 }
 private string schedule_dateDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",schedule_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region FromDate
 private bool from_dateChanged = false;
 private DateTime? from_date;
 public DateTime? FromDate
 {
 get { return from_date; }
 set { 
from_date = value;
from_dateChanged = true;
 }
 }
 private string from_dateDbString
 {
 get
 {
 if (this.from_date.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",from_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region ToDate
 private bool to_dateChanged = false;
 private DateTime? to_date;
 public DateTime? ToDate
 {
 get { return to_date; }
 set { 
to_date = value;
to_dateChanged = true;
 }
 }
 private string to_dateDbString
 {
 get
 {
 if (this.to_date.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",to_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
 #endregion

 #region ReportTaskReader
 public class ReportTaskReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ReportTask currentReportTask;
 Columns columns;
 bool partialRead = false;
 private ReportTaskReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ReportTaskReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ReportTaskReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentReportTask; }

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
 currentReportTask = new ReportTask();
 if (partialRead)
 { if ((columns & Columns.report_task_id) == Columns.report_task_id && reader["report_task_id"]!=DBNull.Value)
 currentReportTask.report_task_id =(int) reader["report_task_id"]; 
 if ((columns & Columns.report_schedule_id) == Columns.report_schedule_id && reader["report_schedule_id"]!=DBNull.Value)
 currentReportTask.report_schedule_id =(int) reader["report_schedule_id"]; 
 if ((columns & Columns.file_path_attachment) == Columns.file_path_attachment && reader["file_path_attachment"]!=DBNull.Value)
 currentReportTask.file_path_attachment =(string) reader["file_path_attachment"]; 
 if ((columns & Columns.retry_count) == Columns.retry_count && reader["retry_count"]!=DBNull.Value)
 currentReportTask.retry_count =(int) reader["retry_count"]; 
 if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
 currentReportTask.failure_reason =(string) reader["failure_reason"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentReportTask.creation_time =(DateTime) reader["creation_time"]; 
 if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"]!=DBNull.Value)
 currentReportTask.last_invoked_at =(DateTime?) reader["last_invoked_at"]; 
 if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
 currentReportTask.status =(string) reader["status"]; 
 if ((columns & Columns.schedule_date) == Columns.schedule_date && reader["schedule_date"]!=DBNull.Value)
 currentReportTask.schedule_date =(DateTime) reader["schedule_date"]; 
 if ((columns & Columns.from_date) == Columns.from_date && reader["from_date"]!=DBNull.Value)
 currentReportTask.from_date =(DateTime?) reader["from_date"]; 
 if ((columns & Columns.to_date) == Columns.to_date && reader["to_date"]!=DBNull.Value)
 currentReportTask.to_date =(DateTime?) reader["to_date"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentReportTask.atm_id =(int?) reader["atm_id"]; 

 } else
 {
 if (reader["report_task_id"] != DBNull.Value)
 currentReportTask.report_task_id = (long) reader["report_task_id"]; 
 if (reader["report_schedule_id"] != DBNull.Value)
 currentReportTask.report_schedule_id = (long) reader["report_schedule_id"]; 
 if (reader["file_path_attachment"] != DBNull.Value)
 currentReportTask.file_path_attachment = (string) reader["file_path_attachment"]; 
 if (reader["retry_count"] != DBNull.Value)
 currentReportTask.retry_count = (int) reader["retry_count"]; 
 if (reader["failure_reason"] != DBNull.Value)
 currentReportTask.failure_reason = (string) reader["failure_reason"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentReportTask.creation_time = (DateTime) reader["creation_time"]; 
 if (reader["last_invoked_at"] != DBNull.Value)
 currentReportTask.last_invoked_at = (DateTime?) reader["last_invoked_at"]; 
 if (reader["status"] != DBNull.Value)
 currentReportTask.status = (string) reader["status"]; 
 if (reader["schedule_date"] != DBNull.Value)
 currentReportTask.schedule_date = (DateTime) reader["schedule_date"]; 
 if (reader["from_date"] != DBNull.Value)
 currentReportTask.from_date = (DateTime?) reader["from_date"]; 
 if (reader["to_date"] != DBNull.Value)
 currentReportTask.to_date = (DateTime?) reader["to_date"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentReportTask.atm_id = (int?) reader["atm_id"]; 
 } 

 currentReportTask.isNewEntity = false;
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

 public ReportTask CurrentReportTask
 {
 get{ return currentReportTask; }
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


 #region ReportTask functions

 public static ReportTaskReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.report_task_id == (Columns.report_task_id & columns))
 qry.Append("report_task_id,");
 if (Columns.report_schedule_id == (Columns.report_schedule_id & columns))
 qry.Append("report_schedule_id,");
 if (Columns.file_path_attachment == (Columns.file_path_attachment & columns))
 qry.Append("file_path_attachment,");
 if (Columns.retry_count == (Columns.retry_count & columns))
 qry.Append("retry_count,");
 if (Columns.failure_reason == (Columns.failure_reason & columns))
 qry.Append("failure_reason,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
 qry.Append("last_invoked_at,");
 if (Columns.status == (Columns.status & columns))
 qry.Append("status,");
 if (Columns.schedule_date == (Columns.schedule_date & columns))
 qry.Append("schedule_date,");
 if (Columns.from_date == (Columns.from_date & columns))
 qry.Append("from_date,");
 if (Columns.to_date == (Columns.to_date & columns))
 qry.Append("to_date,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Report_task ");

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
 return new ReportTaskReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ReportTaskReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ReportTaskReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select report_task_id,report_schedule_id,file_path_attachment,retry_count,failure_reason,creation_time,last_invoked_at,status,schedule_date,from_date,to_date,atm_id from Report_task ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ReportTaskReader(cmd.ExecuteReader(), conn);
 }

 static public ReportTaskReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
 }

 public static ReportTask LoadReportTask(string where)
 {
ReportTaskReader reader = ReportTask.ExecuteReader(where);
ReportTask _reporttask = null;
 if (reader.Read())
 _reporttask = reader.CurrentReportTask;
 reader.Close();
 return _reporttask;
 }

 public static ReportTask LoadReportTask(string where, IDbConnection conn)
 {
ReportTaskReader reader = ReportTask.ExecuteReader(where, conn);
ReportTask _reporttask = null;
 if (reader.Read())
 _reporttask = reader.CurrentReportTask;
 reader.Close(false);
 return _reporttask;
 }

 public static ReportTask LoadReportTaskByPk( long report_task_id )
 {
 return LoadReportTask( " report_task_id="+report_task_id );
 }

 public static ReportTask LoadReportTaskByPk( long report_task_id , IDbConnection conn)
 {
 return LoadReportTask(" report_task_id="+report_task_id , conn);
 }

 public void Save()
 {
 if (report_task_idChanged || report_schedule_idChanged || file_path_attachmentChanged || retry_countChanged || failure_reasonChanged || creation_timeChanged || last_invoked_atChanged || statusChanged || schedule_dateChanged || from_dateChanged || to_dateChanged || atm_idChanged )
 ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Core).CreateCommand());
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
 if (report_task_idChanged || report_schedule_idChanged || file_path_attachmentChanged || retry_countChanged || failure_reasonChanged || creation_timeChanged || last_invoked_atChanged || statusChanged || schedule_dateChanged || from_dateChanged || to_dateChanged || atm_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Report_task( report_task_id,report_schedule_id,file_path_attachment,retry_count,failure_reason,creation_time,last_invoked_at,status,schedule_date,from_date,to_date,atm_id ) values(");
 lock (ConnectionFactory.connectionStringCore) { this.report_task_id = ConnectionFactory.GetNextId(DatabaseName.Core);
 qry.Append(this.report_task_id);
 } qry.Append(",");
 qry.Append(report_schedule_idDbString+",");
 qry.Append(file_path_attachmentDbString+",");
 qry.Append(retry_countDbString+",");
 qry.Append(failure_reasonDbString+",");
 qry.Append(creation_timeDbString+",");
 qry.Append(last_invoked_atDbString+",");
 qry.Append(statusDbString+",");
 qry.Append(schedule_dateDbString+",");
 qry.Append(from_dateDbString+",");
 qry.Append(to_dateDbString+",");
 qry.Append(atm_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(report_task_idChanged || report_schedule_idChanged || file_path_attachmentChanged || retry_countChanged || failure_reasonChanged || creation_timeChanged || last_invoked_atChanged || statusChanged || schedule_dateChanged || from_dateChanged || to_dateChanged || atm_idChanged ))
 return;
 qry.Append("UPDATE Report_task set "); if ( report_schedule_idChanged )
 {
 qry.Append("report_schedule_id ="+report_schedule_idDbString);
 qry.Append(",");
 }

 if ( file_path_attachmentChanged )
 {
 qry.Append("file_path_attachment ="+file_path_attachmentDbString);
 qry.Append(",");
 }

 if ( retry_countChanged )
 {
 qry.Append("retry_count ="+retry_countDbString);
 qry.Append(",");
 }

 if ( failure_reasonChanged )
 {
 qry.Append("failure_reason ="+failure_reasonDbString);
 qry.Append(",");
 }

 if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( last_invoked_atChanged )
 {
 qry.Append("last_invoked_at ="+last_invoked_atDbString);
 qry.Append(",");
 }

 if ( statusChanged )
 {
 qry.Append("status ="+statusDbString);
 qry.Append(",");
 }

 if ( schedule_dateChanged )
 {
 qry.Append("schedule_date ="+schedule_dateDbString);
 qry.Append(",");
 }

 if ( from_dateChanged )
 {
 qry.Append("from_date ="+from_dateDbString);
 qry.Append(",");
 }

 if ( to_dateChanged )
 {
 qry.Append("to_date ="+to_dateDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("report_task_id = "+report_task_idDbString);
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
 Delete(ConnectionFactory.GetNewConnection(DatabaseName.Core));
 }

 public void Delete(IDbConnection conn)
 {
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "DELETE Report_task where report_task_id = "+ report_task_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteReportTasks(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Report_task where " + where,DatabaseName.Core);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
report_task_id= 1,
report_schedule_id= 2,
file_path_attachment= 4,
retry_count= 8,
failure_reason= 16,
creation_time= 32,
last_invoked_at= 64,
status= 128,
schedule_date= 256,
from_date= 512,
to_date= 1024,
atm_id= 2048
 }
 #endregion
 public void BulkSave(List<ReportTask> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Report_task";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ReportTask.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ReportTask> transList,ref DataTable dt)
 {
 foreach (ReportTask tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["report_task_id"] =ConnectionFactory.GetNextId(DatabaseName.Core);
 Row["report_schedule_id"] = tran.ReportScheduleId;
 Row["file_path_attachment"] = tran.FilePathAttachment;
 Row["retry_count"] = tran.RetryCount;
 Row["failure_reason"] = tran.FailureReason;
 Row["creation_time"] = tran.CreationTime;
 Row["last_invoked_at"] = tran.LastInvokedAt;
 Row["status"] = tran.Status;
 Row["schedule_date"] = tran.ScheduleDate;
 Row["from_date"] = tran.FromDate;
 Row["to_date"] = tran.ToDate;
 Row["atm_id"] = tran.AtmId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
