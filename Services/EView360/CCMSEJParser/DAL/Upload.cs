
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
public class Upload
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Upload() { }
public Upload(int upload_id,DateTime start_time,DateTime creation_time,string status,int created_by,int retry_remaining,DateTime execution_time,int atm_id,string path_at_atm,int uploaded_bytes,DateTime upload_time,int timeout) 
{
this.start_time = start_time;
this.start_timeChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.status = status;
this.statusChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.execution_time = execution_time;
this.execution_timeChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.path_at_atm = path_at_atm;
this.path_at_atmChanged = true;
this.uploaded_bytes = uploaded_bytes;
this.uploaded_bytesChanged = true;
this.upload_time = upload_time;
this.upload_timeChanged = true;
this.timeout = timeout;
this.timeoutChanged = true;
}
public Upload(DateTime start_time,DateTime creation_time,string status,DateTime? end_time,int created_by,int retry_remaining,DateTime? last_invoked,string failure_reason,DateTime execution_time,int atm_id,string path_at_atm,int uploaded_bytes,DateTime upload_time,int timeout,int? package_id)
{
this.start_time = start_time;
this.start_timeChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.status = status;
this.statusChanged = true;
this.end_time = end_time;
this.end_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.last_invoked = last_invoked;
this.last_invokedChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.execution_time = execution_time;
this.execution_timeChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.path_at_atm = path_at_atm;
this.path_at_atmChanged = true;
this.uploaded_bytes = uploaded_bytes;
this.uploaded_bytesChanged = true;
this.upload_time = upload_time;
this.upload_timeChanged = true;
this.timeout = timeout;
this.timeoutChanged = true;
this.package_id = package_id;
this.package_idChanged = true;
}
private Upload(int upload_id,DateTime start_time,DateTime creation_time,string status,DateTime? end_time,int created_by,int retry_remaining,DateTime? last_invoked,string failure_reason,DateTime execution_time,int atm_id,string path_at_atm,int uploaded_bytes,DateTime upload_time,int timeout,int? package_id)
{
this.upload_id = upload_id;
this.upload_idChanged = true;
this.start_time = start_time;
this.start_timeChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.status = status;
this.statusChanged = true;
this.end_time = end_time;
this.end_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.last_invoked = last_invoked;
this.last_invokedChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.execution_time = execution_time;
this.execution_timeChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.path_at_atm = path_at_atm;
this.path_at_atmChanged = true;
this.uploaded_bytes = uploaded_bytes;
this.uploaded_bytesChanged = true;
this.upload_time = upload_time;
this.upload_timeChanged = true;
this.timeout = timeout;
this.timeoutChanged = true;
this.package_id = package_id;
this.package_idChanged = true;
}

#region members and properties for columns

#region UploadId
private bool upload_idChanged = false;
private int upload_id;
public int UploadId
{
get { return upload_id; }
set { 
upload_id = value;
upload_idChanged = true;
}
}
private string upload_idDbString
{
get
{
return upload_id.ToString();
}
}
#endregion
#region StartTime
private bool start_timeChanged = false;
private DateTime start_time;
public DateTime StartTime
{
get { return start_time; }
set { 
start_time = value;
start_timeChanged = true;
}
}
private string start_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",start_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
return string.Format("'{0}'",status);else
return "null";
}
}
#endregion
#region EndTime
private bool end_timeChanged = false;
private DateTime? end_time;
public DateTime? EndTime
{
get { return end_time; }
set { 
end_time = value;
end_timeChanged = true;
}
}
private string end_timeDbString
{
get
{
if (this.end_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",end_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
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
#region RetryRemaining
private bool retry_remainingChanged = false;
private int retry_remaining;
public int RetryRemaining
{
get { return retry_remaining; }
set { 
retry_remaining = value;
retry_remainingChanged = true;
}
}
private string retry_remainingDbString
{
get
{
return retry_remaining.ToString();
}
}
#endregion
#region LastInvoked
private bool last_invokedChanged = false;
private DateTime? last_invoked;
public DateTime? LastInvoked
{
get { return last_invoked; }
set { 
last_invoked = value;
last_invokedChanged = true;
}
}
private string last_invokedDbString
{
get
{
if (this.last_invoked.HasValue)
return string.Format("Convert(datetime,'{0}',121)",last_invoked.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
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
return string.Format("'{0}'",failure_reason);else
return "null";
}
}
#endregion
#region ExecutionTime
private bool execution_timeChanged = false;
private DateTime execution_time;
public DateTime ExecutionTime
{
get { return execution_time; }
set { 
execution_time = value;
execution_timeChanged = true;
}
}
private string execution_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",execution_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int atm_id;
public int AtmId
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
return atm_id.ToString();
}
}
#endregion
#region PathAtAtm
private bool path_at_atmChanged = false;
private string path_at_atm;
public string PathAtAtm
{
get { return path_at_atm; }
set { 
path_at_atm = value;
path_at_atmChanged = true;
}
}
private string path_at_atmDbString
{
get
{
if (this.path_at_atm!=null)
return string.Format("'{0}'",path_at_atm);else
return "null";
}
}
#endregion
#region UploadedBytes
private bool uploaded_bytesChanged = false;
private int uploaded_bytes;
public int UploadedBytes
{
get { return uploaded_bytes; }
set { 
uploaded_bytes = value;
uploaded_bytesChanged = true;
}
}
private string uploaded_bytesDbString
{
get
{
return uploaded_bytes.ToString();
}
}
#endregion
#region UploadTime
private bool upload_timeChanged = false;
private DateTime upload_time;
public DateTime UploadTime
{
get { return upload_time; }
set { 
upload_time = value;
upload_timeChanged = true;
}
}
private string upload_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",upload_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region Timeout
private bool timeoutChanged = false;
private int timeout;
public int Timeout
{
get { return timeout; }
set { 
timeout = value;
timeoutChanged = true;
}
}
private string timeoutDbString
{
get
{
return timeout.ToString();
}
}
#endregion
#region PackageId
private bool package_idChanged = false;
private int? package_id;
public int? PackageId
{
get { return package_id; }
set { 
package_id = value;
package_idChanged = true;
}
}
private string package_idDbString
{
get
{
if (this.package_id.HasValue)
return package_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region UploadReader
public class UploadReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Upload currentUpload;
Columns columns;
bool partialRead = false;
private UploadReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public UploadReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public UploadReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get{ return currentUpload; }

}public void Close()
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
currentUpload = new Upload();
if (partialRead)
{if ((columns & Columns.upload_id) == Columns.upload_id && reader["upload_id"]!=DBNull.Value)
currentUpload.upload_id =(int) reader["upload_id"]; 
if ((columns & Columns.start_time) == Columns.start_time && reader["start_time"]!=DBNull.Value)
currentUpload.start_time =(DateTime) reader["start_time"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentUpload.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentUpload.status =(string) reader["status"]; 
if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"]!=DBNull.Value)
currentUpload.end_time =(DateTime?) reader["end_time"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentUpload.created_by =(int) reader["created_by"]; 
if ((columns & Columns.retry_remaining) == Columns.retry_remaining && reader["retry_remaining"]!=DBNull.Value)
currentUpload.retry_remaining =(int) reader["retry_remaining"]; 
if ((columns & Columns.last_invoked) == Columns.last_invoked && reader["last_invoked"]!=DBNull.Value)
currentUpload.last_invoked =(DateTime?) reader["last_invoked"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentUpload.failure_reason =(string) reader["failure_reason"]; 
if ((columns & Columns.execution_time) == Columns.execution_time && reader["execution_time"]!=DBNull.Value)
currentUpload.execution_time =(DateTime) reader["execution_time"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentUpload.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.path_at_atm) == Columns.path_at_atm && reader["path_at_atm"]!=DBNull.Value)
currentUpload.path_at_atm =(string) reader["path_at_atm"]; 
if ((columns & Columns.uploaded_bytes) == Columns.uploaded_bytes && reader["uploaded_bytes"]!=DBNull.Value)
currentUpload.uploaded_bytes =(int) reader["uploaded_bytes"]; 
if ((columns & Columns.upload_time) == Columns.upload_time && reader["upload_time"]!=DBNull.Value)
currentUpload.upload_time =(DateTime) reader["upload_time"]; 
if ((columns & Columns.timeout) == Columns.timeout && reader["timeout"]!=DBNull.Value)
currentUpload.timeout =(int) reader["timeout"]; 
if ((columns & Columns.package_id) == Columns.package_id && reader["package_id"]!=DBNull.Value)
currentUpload.package_id =(int?) reader["package_id"]; 

}else
{
if (reader["upload_id"] != DBNull.Value)
currentUpload.upload_id = (int) reader["upload_id"]; 
if (reader["start_time"] != DBNull.Value)
currentUpload.start_time = (DateTime) reader["start_time"]; 
if (reader["creation_time"] != DBNull.Value)
currentUpload.creation_time = (DateTime) reader["creation_time"]; 
if (reader["status"] != DBNull.Value)
currentUpload.status = (string) reader["status"]; 
if (reader["end_time"] != DBNull.Value)
currentUpload.end_time = (DateTime?) reader["end_time"]; 
if (reader["created_by"] != DBNull.Value)
currentUpload.created_by = (int) reader["created_by"]; 
if (reader["retry_remaining"] != DBNull.Value)
currentUpload.retry_remaining = (int) reader["retry_remaining"]; 
if (reader["last_invoked"] != DBNull.Value)
currentUpload.last_invoked = (DateTime?) reader["last_invoked"]; 
if (reader["failure_reason"] != DBNull.Value)
currentUpload.failure_reason = (string) reader["failure_reason"]; 
if (reader["execution_time"] != DBNull.Value)
currentUpload.execution_time = (DateTime) reader["execution_time"]; 
if (reader["atm_id"] != DBNull.Value)
currentUpload.atm_id = (int) reader["atm_id"]; 
if (reader["path_at_atm"] != DBNull.Value)
currentUpload.path_at_atm = (string) reader["path_at_atm"]; 
if (reader["uploaded_bytes"] != DBNull.Value)
currentUpload.uploaded_bytes = (int) reader["uploaded_bytes"]; 
if (reader["upload_time"] != DBNull.Value)
currentUpload.upload_time = (DateTime) reader["upload_time"]; 
if (reader["timeout"] != DBNull.Value)
currentUpload.timeout = (int) reader["timeout"]; 
if (reader["package_id"] != DBNull.Value)
currentUpload.package_id = (int?) reader["package_id"]; 
} 

currentUpload.isNewEntity = false;
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

public Upload CurrentUpload
{
get{ return currentUpload; }
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


#region Upload functions

public static UploadReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.upload_id == (Columns.upload_id & columns))
qry.Append("upload_id,");
if (Columns.start_time == (Columns.start_time & columns))
qry.Append("start_time,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.end_time == (Columns.end_time & columns))
qry.Append("end_time,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.retry_remaining == (Columns.retry_remaining & columns))
qry.Append("retry_remaining,");
if (Columns.last_invoked == (Columns.last_invoked & columns))
qry.Append("last_invoked,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
if (Columns.execution_time == (Columns.execution_time & columns))
qry.Append("execution_time,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.path_at_atm == (Columns.path_at_atm & columns))
qry.Append("path_at_atm,");
if (Columns.uploaded_bytes == (Columns.uploaded_bytes & columns))
qry.Append("uploaded_bytes,");
if (Columns.upload_time == (Columns.upload_time & columns))
qry.Append("upload_time,");
if (Columns.timeout == (Columns.timeout & columns))
qry.Append("timeout,");
if (Columns.package_id == (Columns.package_id & columns))
qry.Append("package_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Upload ");

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
return new UploadReader(cmd.ExecuteReader(), conn, columns);
}

static public UploadReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static UploadReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select upload_id,start_time,creation_time,status,end_time,created_by,retry_remaining,last_invoked,failure_reason,execution_time,atm_id,path_at_atm,uploaded_bytes,upload_time,timeout,package_id from Upload ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new UploadReader(cmd.ExecuteReader(), conn);
}

static public UploadReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Upload LoadUpload(string where)
{
UploadReader reader = Upload.ExecuteReader(where);
Upload _upload = null;
if (reader.Read())
_upload = reader.CurrentUpload;
reader.Close();
return _upload;
}

public static Upload LoadUpload(string where, IDbConnection conn)
{
UploadReader reader = Upload.ExecuteReader(where, conn);
Upload _upload = null;
if (reader.Read())
_upload = reader.CurrentUpload;
reader.Close(false);
return _upload;
}

public static Upload LoadUploadByPk(int upload_id)
{
return LoadUpload("upload_id="+upload_id);
}

public static Upload LoadUploadByPk(int upload_id, IDbConnection conn)
{
return LoadUpload(" upload_id="+upload_id, conn);
}

public void Save()
{
if (upload_idChanged|| start_timeChanged|| creation_timeChanged|| statusChanged|| end_timeChanged|| created_byChanged|| retry_remainingChanged|| last_invokedChanged|| failure_reasonChanged|| execution_timeChanged|| atm_idChanged|| path_at_atmChanged|| uploaded_bytesChanged|| upload_timeChanged|| timeoutChanged|| package_idChanged)
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
private void ExcuteSave(IDbCommand cmd){
if (upload_idChanged|| start_timeChanged|| creation_timeChanged|| statusChanged|| end_timeChanged|| created_byChanged|| retry_remainingChanged|| last_invokedChanged|| failure_reasonChanged|| execution_timeChanged|| atm_idChanged|| path_at_atmChanged|| uploaded_bytesChanged|| upload_timeChanged|| timeoutChanged|| package_idChanged)
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Upload(upload_id,start_time,creation_time,status,end_time,created_by,retry_remaining,last_invoked,failure_reason,execution_time,atm_id,path_at_atm,uploaded_bytes,upload_time,timeout,package_id) values(");
lock (ConnectionFactory.connectionString){this.upload_id =ConnectionFactory.GetNextId();
qry.Append(this.upload_id);
}qry.Append(",");
qry.Append(start_timeDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(statusDbString+",");
qry.Append(end_timeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(retry_remainingDbString+",");
qry.Append(last_invokedDbString+",");
qry.Append(failure_reasonDbString+",");
qry.Append(execution_timeDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(path_at_atmDbString+",");
qry.Append(uploaded_bytesDbString+",");
qry.Append(upload_timeDbString+",");
qry.Append(timeoutDbString+",");
qry.Append(package_idDbString);
qry.Append(");");

}
else
{
if (!(upload_idChanged|| start_timeChanged|| creation_timeChanged|| statusChanged|| end_timeChanged|| created_byChanged|| retry_remainingChanged|| last_invokedChanged|| failure_reasonChanged|| execution_timeChanged|| atm_idChanged|| path_at_atmChanged|| uploaded_bytesChanged|| upload_timeChanged|| timeoutChanged|| package_idChanged))
return;
qry.Append("UPDATE Upload set ");if (start_timeChanged)
{
qry.Append("start_time ="+start_timeDbString);
qry.Append(",");
}

if (creation_timeChanged)
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if (statusChanged)
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if (end_timeChanged)
{
qry.Append("end_time ="+end_timeDbString);
qry.Append(",");
}

if (created_byChanged)
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if (retry_remainingChanged)
{
qry.Append("retry_remaining ="+retry_remainingDbString);
qry.Append(",");
}

if (last_invokedChanged)
{
qry.Append("last_invoked ="+last_invokedDbString);
qry.Append(",");
}

if (failure_reasonChanged)
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}

if (execution_timeChanged)
{
qry.Append("execution_time ="+execution_timeDbString);
qry.Append(",");
}

if (atm_idChanged)
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if (path_at_atmChanged)
{
qry.Append("path_at_atm ="+path_at_atmDbString);
qry.Append(",");
}

if (uploaded_bytesChanged)
{
qry.Append("uploaded_bytes ="+uploaded_bytesDbString);
qry.Append(",");
}

if (upload_timeChanged)
{
qry.Append("upload_time ="+upload_timeDbString);
qry.Append(",");
}

if (timeoutChanged)
{
qry.Append("timeout ="+timeoutDbString);
qry.Append(",");
}

if (package_idChanged)
{
qry.Append("package_id ="+package_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("upload_id = "+upload_idDbString);
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
cmd.CommandText = "DELETE Upload where upload_id= "+ upload_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteUploads(string where)
{
ConnectionFactory.ExecuteQuery("delete Upload where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
upload_id= 1,
start_time= 2,
creation_time= 4,
status= 8,
end_time= 16,
created_by= 32,
retry_remaining= 64,
last_invoked= 128,
failure_reason= 256,
execution_time= 512,
atm_id= 1024,
path_at_atm= 2048,
uploaded_bytes= 4096,
upload_time= 8192,
timeout= 16384,
package_id= 32768
}
#endregion
public void BulkSave(List<Upload>dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Upload";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Upload.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Upload>transList,ref DataTable dt)
{
foreach (Upload tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["upload_id"] =ConnectionFactory.GetNextId();
Row["start_time"] = tran.StartTime;
Row["creation_time"] = tran.CreationTime;
Row["status"] = tran.Status;
Row["end_time"] = tran.EndTime;
Row["created_by"] = tran.CreatedBy;
Row["retry_remaining"] = tran.RetryRemaining;
Row["last_invoked"] = tran.LastInvoked;
Row["failure_reason"] = tran.FailureReason;
Row["execution_time"] = tran.ExecutionTime;
Row["atm_id"] = tran.AtmId;
Row["path_at_atm"] = tran.PathAtAtm;
Row["uploaded_bytes"] = tran.UploadedBytes;
Row["upload_time"] = tran.UploadTime;
Row["timeout"] = tran.Timeout;
Row["package_id"] = tran.PackageId;
dt.Rows.Add(Row);
}}
}
}

 