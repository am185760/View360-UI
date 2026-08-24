using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;

namespace Avanza.CCMS.DAL
{
[Serializable()]
public class FileInfo
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public FileInfo() { }
public FileInfo( int? file_info_id,int? bytes_transferred,int? aTM_id,DateTime? creation_time,DateTime? download_time,string status,int? created_by,byte? retry_Remaining,int? task_type_id ) 
{
this.bytes_transferred = bytes_transferred;
this.bytes_transferredChanged = true;
this.aTM_id = aTM_id;
this.aTM_idChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.download_time = download_time;
this.download_timeChanged = true;
this.status = status;
this.statusChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.retry_Remaining = retry_Remaining;
this.retry_RemainingChanged = true;
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
}
public FileInfo( bool? parsed,int? bytes_transferred,string file_path_at_ATM,int? aTM_id,int? file_type_id,DateTime? creation_time,DateTime? download_time,DateTime? end_time,string status,int? zipped_file_size,int? created_by,int? unZipped_file_size,DateTime? last_invoked,byte? retry_Remaining,string failure_reason,string server_filepath,int? task_type_id,int? cash_order_id )
{
this.parsed = parsed;
this.parsedChanged = true;
this.bytes_transferred = bytes_transferred;
this.bytes_transferredChanged = true;
this.file_path_at_ATM = file_path_at_ATM;
this.file_path_at_ATMChanged = true;
this.aTM_id = aTM_id;
this.aTM_idChanged = true;
this.file_type_id = file_type_id;
this.file_type_idChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.download_time = download_time;
this.download_timeChanged = true;
this.end_time = end_time;
this.end_timeChanged = true;
this.status = status;
this.statusChanged = true;
this.zipped_file_size = zipped_file_size;
this.zipped_file_sizeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.unZipped_file_size = unZipped_file_size;
this.unZipped_file_sizeChanged = true;
this.last_invoked = last_invoked;
this.last_invokedChanged = true;
this.retry_Remaining = retry_Remaining;
this.retry_RemainingChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.server_filepath = server_filepath;
this.server_filepathChanged = true;
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
this.cash_order_id = cash_order_id;
this.cash_order_idChanged = true;
}
private FileInfo( int? file_info_id,bool? parsed,int? bytes_transferred,string file_path_at_ATM,int? aTM_id,int? file_type_id,DateTime? creation_time,DateTime? download_time,DateTime? end_time,string status,int? zipped_file_size,int? created_by,int? unZipped_file_size,DateTime? last_invoked,byte? retry_Remaining,string failure_reason,string server_filepath,int? task_type_id,int? cash_order_id )
{
this.file_info_id = file_info_id;
this.file_info_idChanged = true;
this.parsed = parsed;
this.parsedChanged = true;
this.bytes_transferred = bytes_transferred;
this.bytes_transferredChanged = true;
this.file_path_at_ATM = file_path_at_ATM;
this.file_path_at_ATMChanged = true;
this.aTM_id = aTM_id;
this.aTM_idChanged = true;
this.file_type_id = file_type_id;
this.file_type_idChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.download_time = download_time;
this.download_timeChanged = true;
this.end_time = end_time;
this.end_timeChanged = true;
this.status = status;
this.statusChanged = true;
this.zipped_file_size = zipped_file_size;
this.zipped_file_sizeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.unZipped_file_size = unZipped_file_size;
this.unZipped_file_sizeChanged = true;
this.last_invoked = last_invoked;
this.last_invokedChanged = true;
this.retry_Remaining = retry_Remaining;
this.retry_RemainingChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.server_filepath = server_filepath;
this.server_filepathChanged = true;
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
this.cash_order_id = cash_order_id;
this.cash_order_idChanged = true;
}

#region members and properties for columns

#region FileInfoId
private bool file_info_idChanged = false;
private int? file_info_id;
public int? FileInfoId
{
get { return file_info_id; }
set { 
file_info_id = value;
file_info_idChanged = true;
}
}
private string file_info_idDbString
{
get
{
if (this.file_info_id.HasValue)
return file_info_id.ToString();
else
return "null";
}
}
#endregion
#region Parsed
private bool parsedChanged = false;
private bool? parsed;
public bool? Parsed
{
get { return parsed; }
set { 
parsed = value;
parsedChanged = true;
}
}
private string parsedDbString
{
get
{
if (this.parsed.HasValue)
return parsed.Value?"1":"0";
else
return "null";
}
}
#endregion
#region BytesTransferred
private bool bytes_transferredChanged = false;
private int? bytes_transferred;
public int? BytesTransferred
{
get { return bytes_transferred; }
set { 
bytes_transferred = value;
bytes_transferredChanged = true;
}
}
private string bytes_transferredDbString
{
get
{
if (this.bytes_transferred.HasValue)
return bytes_transferred.ToString();
else
return "null";
}
}
#endregion
#region FilePathAtATM
private bool file_path_at_ATMChanged = false;
private string file_path_at_ATM;
public string FilePathAtATM
{
get { return file_path_at_ATM; }
set { 
file_path_at_ATM = value;
file_path_at_ATMChanged = true;
}
}
private string file_path_at_ATMDbString
{
get
{
if (this.file_path_at_ATM!=null)
return string.Format("'{0}'",file_path_at_ATM); else
return "null";
}
}
#endregion
#region ATMId
private bool aTM_idChanged = false;
private int? aTM_id;
public int? ATMId
{
get { return aTM_id; }
set { 
aTM_id = value;
aTM_idChanged = true;
}
}
private string aTM_idDbString
{
get
{
if (this.aTM_id.HasValue)
return aTM_id.ToString();
else
return "null";
}
}
#endregion
#region FileTypeId
private bool file_type_idChanged = false;
private int? file_type_id;
public int? FileTypeId
{
get { return file_type_id; }
set { 
file_type_id = value;
file_type_idChanged = true;
}
}
private string file_type_idDbString
{
get
{
if (this.file_type_id.HasValue)
return file_type_id.ToString();
else
return "null";
}
}
#endregion
#region CreationTime
private bool creation_timeChanged = false;
private DateTime? creation_time;
public DateTime? CreationTime
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
if (this.creation_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",creation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region DownloadTime
private bool download_timeChanged = false;
private DateTime? download_time;
public DateTime? DownloadTime
{
get { return download_time; }
set { 
download_time = value;
download_timeChanged = true;
}
}
private string download_timeDbString
{
get
{
if (this.download_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",download_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
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
#region ZippedFileSize
private bool zipped_file_sizeChanged = false;
private int? zipped_file_size;
public int? ZippedFileSize
{
get { return zipped_file_size; }
set { 
zipped_file_size = value;
zipped_file_sizeChanged = true;
}
}
private string zipped_file_sizeDbString
{
get
{
if (this.zipped_file_size.HasValue)
return zipped_file_size.ToString();
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
set { 
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
#region UnZippedFileSize
private bool unZipped_file_sizeChanged = false;
private int? unZipped_file_size;
public int? UnZippedFileSize
{
get { return unZipped_file_size; }
set { 
unZipped_file_size = value;
unZipped_file_sizeChanged = true;
}
}
private string unZipped_file_sizeDbString
{
get
{
if (this.unZipped_file_size.HasValue)
return unZipped_file_size.ToString();
else
return "null";
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
#region RetryRemaining
private bool retry_RemainingChanged = false;
private byte? retry_Remaining;
public byte? RetryRemaining
{
get { return retry_Remaining; }
set { 
retry_Remaining = value;
retry_RemainingChanged = true;
}
}
private string retry_RemainingDbString
{
get
{
if (this.retry_Remaining.HasValue)
return retry_Remaining.ToString();
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
return string.Format("'{0}'",failure_reason); else
return "null";
}
}
#endregion
#region ServerFilepath
private bool server_filepathChanged = false;
private string server_filepath;
public string ServerFilepath
{
get { return server_filepath; }
set { 
server_filepath = value;
server_filepathChanged = true;
}
}
private string server_filepathDbString
{
get
{
if (this.server_filepath!=null)
return string.Format("'{0}'",server_filepath); else
return "null";
}
}
#endregion
#region TaskTypeId
private bool task_type_idChanged = false;
private int? task_type_id;
public int? TaskTypeId
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
if (this.task_type_id.HasValue)
return task_type_id.ToString();
else
return "null";
}
}
#endregion
#region CashOrderId
private bool cash_order_idChanged = false;
private int? cash_order_id;
public int? CashOrderId
{
get { return cash_order_id; }
set { 
cash_order_id = value;
cash_order_idChanged = true;
}
}
private string cash_order_idDbString
{
get
{
if (this.cash_order_id.HasValue)
return cash_order_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region FileInfoReader
public class FileInfoReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
FileInfo currentFileInfo;
Columns columns;
bool partialRead = false;
private FileInfoReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public FileInfoReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public FileInfoReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentFileInfo; }

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
currentFileInfo = new FileInfo();
if (partialRead)
{ if ((columns & Columns.file_info_id) == Columns.file_info_id && reader["file_info_id"]!=DBNull.Value)
currentFileInfo.file_info_id =(int?) reader["file_info_id"]; 
if ((columns & Columns.parsed) == Columns.parsed && reader["parsed"]!=DBNull.Value)
currentFileInfo.parsed =(bool?) reader["parsed"]; 
if ((columns & Columns.bytes_transferred) == Columns.bytes_transferred && reader["bytes_transferred"]!=DBNull.Value)
currentFileInfo.bytes_transferred =(int?) reader["bytes_transferred"]; 
if ((columns & Columns.file_path_at_ATM) == Columns.file_path_at_ATM && reader["file_path_at_ATM"]!=DBNull.Value)
currentFileInfo.file_path_at_ATM =(string) reader["file_path_at_ATM"]; 
if ((columns & Columns.ATM_id) == Columns.ATM_id && reader["ATM_id"]!=DBNull.Value)
currentFileInfo.aTM_id =(int?) reader["ATM_id"]; 
if ((columns & Columns.file_type_id) == Columns.file_type_id && reader["file_type_id"]!=DBNull.Value)
currentFileInfo.file_type_id =(int?) reader["file_type_id"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentFileInfo.creation_time =(DateTime?) reader["creation_time"]; 
if ((columns & Columns.download_time) == Columns.download_time && reader["download_time"]!=DBNull.Value)
currentFileInfo.download_time =(DateTime?) reader["download_time"]; 
if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"]!=DBNull.Value)
currentFileInfo.end_time =(DateTime?) reader["end_time"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentFileInfo.status =(string) reader["status"]; 
if ((columns & Columns.zipped_file_size) == Columns.zipped_file_size && reader["zipped_file_size"]!=DBNull.Value)
currentFileInfo.zipped_file_size =(int?) reader["zipped_file_size"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentFileInfo.created_by =(int?) reader["created_by"]; 
if ((columns & Columns.unZipped_file_size) == Columns.unZipped_file_size && reader["unZipped_file_size"]!=DBNull.Value)
currentFileInfo.unZipped_file_size =(int?) reader["unZipped_file_size"]; 
if ((columns & Columns.last_invoked) == Columns.last_invoked && reader["last_invoked"]!=DBNull.Value)
currentFileInfo.last_invoked =(DateTime?) reader["last_invoked"]; 
if ((columns & Columns.retry_Remaining) == Columns.retry_Remaining && reader["retry_Remaining"]!=DBNull.Value)
currentFileInfo.retry_Remaining =(byte?) reader["retry_Remaining"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentFileInfo.failure_reason =(string) reader["failure_reason"]; 
if ((columns & Columns.server_filepath) == Columns.server_filepath && reader["server_filepath"]!=DBNull.Value)
currentFileInfo.server_filepath =(string) reader["server_filepath"]; 
if ((columns & Columns.task_type_id) == Columns.task_type_id && reader["task_type_id"]!=DBNull.Value)
currentFileInfo.task_type_id =(int?) reader["task_type_id"]; 
if ((columns & Columns.cash_order_id) == Columns.cash_order_id && reader["cash_order_id"]!=DBNull.Value)
currentFileInfo.cash_order_id =(int?) reader["cash_order_id"]; 

} else
{
if (reader["file_info_id"] != DBNull.Value)
currentFileInfo.file_info_id = (int?) reader["file_info_id"]; 
if (reader["parsed"] != DBNull.Value)
currentFileInfo.parsed = (bool?) reader["parsed"]; 
if (reader["bytes_transferred"] != DBNull.Value)
currentFileInfo.bytes_transferred = (int?) reader["bytes_transferred"]; 
if (reader["file_path_at_ATM"] != DBNull.Value)
currentFileInfo.file_path_at_ATM = (string) reader["file_path_at_ATM"]; 
if (reader["ATM_id"] != DBNull.Value)
currentFileInfo.aTM_id = (int?) reader["ATM_id"]; 
if (reader["file_type_id"] != DBNull.Value)
currentFileInfo.file_type_id = (int?) reader["file_type_id"]; 
if (reader["creation_time"] != DBNull.Value)
currentFileInfo.creation_time = (DateTime?) reader["creation_time"]; 
if (reader["download_time"] != DBNull.Value)
currentFileInfo.download_time = (DateTime?) reader["download_time"]; 
if (reader["end_time"] != DBNull.Value)
currentFileInfo.end_time = (DateTime?) reader["end_time"]; 
if (reader["status"] != DBNull.Value)
currentFileInfo.status = (string) reader["status"]; 
if (reader["zipped_file_size"] != DBNull.Value)
currentFileInfo.zipped_file_size = (int?) reader["zipped_file_size"]; 
if (reader["created_by"] != DBNull.Value)
currentFileInfo.created_by = (int?) reader["created_by"]; 
if (reader["unZipped_file_size"] != DBNull.Value)
currentFileInfo.unZipped_file_size = (int?) reader["unZipped_file_size"]; 
if (reader["last_invoked"] != DBNull.Value)
currentFileInfo.last_invoked = (DateTime?) reader["last_invoked"]; 
if (reader["retry_Remaining"] != DBNull.Value)
currentFileInfo.retry_Remaining = (byte?) reader["retry_Remaining"]; 
if (reader["failure_reason"] != DBNull.Value)
currentFileInfo.failure_reason = (string) reader["failure_reason"]; 
if (reader["server_filepath"] != DBNull.Value)
currentFileInfo.server_filepath = (string) reader["server_filepath"]; 
if (reader["task_type_id"] != DBNull.Value)
currentFileInfo.task_type_id = (int?) reader["task_type_id"]; 
if (reader["cash_order_id"] != DBNull.Value)
currentFileInfo.cash_order_id = (int?) reader["cash_order_id"]; 
} 

currentFileInfo.isNewEntity = false;
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

public FileInfo CurrentFileInfo
{
get{ return currentFileInfo; }
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


#region FileInfo functions

public static FileInfoReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.file_info_id == (Columns.file_info_id & columns))
qry.Append("file_info_id,");
if (Columns.parsed == (Columns.parsed & columns))
qry.Append("parsed,");
if (Columns.bytes_transferred == (Columns.bytes_transferred & columns))
qry.Append("bytes_transferred,");
if (Columns.file_path_at_ATM == (Columns.file_path_at_ATM & columns))
qry.Append("file_path_at_ATM,");
if (Columns.ATM_id == (Columns.ATM_id & columns))
qry.Append("ATM_id,");
if (Columns.file_type_id == (Columns.file_type_id & columns))
qry.Append("file_type_id,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.download_time == (Columns.download_time & columns))
qry.Append("download_time,");
if (Columns.end_time == (Columns.end_time & columns))
qry.Append("end_time,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.zipped_file_size == (Columns.zipped_file_size & columns))
qry.Append("zipped_file_size,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.unZipped_file_size == (Columns.unZipped_file_size & columns))
qry.Append("unZipped_file_size,");
if (Columns.last_invoked == (Columns.last_invoked & columns))
qry.Append("last_invoked,");
if (Columns.retry_Remaining == (Columns.retry_Remaining & columns))
qry.Append("retry_Remaining,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
if (Columns.server_filepath == (Columns.server_filepath & columns))
qry.Append("server_filepath,");
if (Columns.task_type_id == (Columns.task_type_id & columns))
qry.Append("task_type_id,");
if (Columns.cash_order_id == (Columns.cash_order_id & columns))
qry.Append("cash_order_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from File_info ");

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
return new FileInfoReader(cmd.ExecuteReader(), conn, columns);
}

static public FileInfoReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static FileInfoReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select file_info_id,parsed,bytes_transferred,file_path_at_ATM,ATM_id,file_type_id,creation_time,download_time,end_time,status,zipped_file_size,created_by,unZipped_file_size,last_invoked,retry_Remaining,failure_reason,server_filepath,task_type_id,cash_order_id from File_info ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new FileInfoReader(cmd.ExecuteReader(), conn);
}

static public FileInfoReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static FileInfo LoadFileInfo(string where)
{
FileInfoReader reader = FileInfo.ExecuteReader(where);
FileInfo _fileinfo = null;
if (reader.Read())
_fileinfo = reader.CurrentFileInfo;
reader.Close();
return _fileinfo;
}

public static FileInfo LoadFileInfo(string where, IDbConnection conn)
{
FileInfoReader reader = FileInfo.ExecuteReader(where, conn);
FileInfo _fileinfo = null;
if (reader.Read())
_fileinfo = reader.CurrentFileInfo;
reader.Close(false);
return _fileinfo;
}

public static FileInfo LoadFileInfoByPk( int file_info_id )
{
return LoadFileInfo( " file_info_id="+file_info_id );
}

public static FileInfo LoadFileInfoByPk( int file_info_id , IDbConnection conn)
{
return LoadFileInfo(" file_info_id="+file_info_id , conn);
}

public void Save()
{
if (file_info_idChanged || parsedChanged || bytes_transferredChanged || file_path_at_ATMChanged || aTM_idChanged || file_type_idChanged || creation_timeChanged || download_timeChanged || end_timeChanged || statusChanged || zipped_file_sizeChanged || created_byChanged || unZipped_file_sizeChanged || last_invokedChanged || retry_RemainingChanged || failure_reasonChanged || server_filepathChanged || task_type_idChanged || cash_order_idChanged )
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
if (file_info_idChanged || parsedChanged || bytes_transferredChanged || file_path_at_ATMChanged || aTM_idChanged || file_type_idChanged || creation_timeChanged || download_timeChanged || end_timeChanged || statusChanged || zipped_file_sizeChanged || created_byChanged || unZipped_file_sizeChanged || last_invokedChanged || retry_RemainingChanged || failure_reasonChanged || server_filepathChanged || task_type_idChanged || cash_order_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into File_info( file_info_id,parsed,bytes_transferred,file_path_at_ATM,ATM_id,file_type_id,creation_time,download_time,end_time,status,zipped_file_size,created_by,unZipped_file_size,last_invoked,retry_Remaining,failure_reason,server_filepath,task_type_id,cash_order_id ) values(");
lock (ConnectionFactory.connectionString) { this.file_info_id = ConnectionFactory.GetNextId();
qry.Append(this.file_info_id);
} qry.Append(",");
qry.Append(parsedDbString+",");
qry.Append(bytes_transferredDbString+",");
qry.Append(file_path_at_ATMDbString+",");
qry.Append(aTM_idDbString+",");
qry.Append(file_type_idDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(download_timeDbString+",");
qry.Append(end_timeDbString+",");
qry.Append(statusDbString+",");
qry.Append(zipped_file_sizeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(unZipped_file_sizeDbString+",");
qry.Append(last_invokedDbString+",");
qry.Append(retry_RemainingDbString+",");
qry.Append(failure_reasonDbString+",");
qry.Append(server_filepathDbString+",");
qry.Append(task_type_idDbString+",");
qry.Append(cash_order_idDbString);
qry.Append(");");

}
else
{
if (!(file_info_idChanged || parsedChanged || bytes_transferredChanged || file_path_at_ATMChanged || aTM_idChanged || file_type_idChanged || creation_timeChanged || download_timeChanged || end_timeChanged || statusChanged || zipped_file_sizeChanged || created_byChanged || unZipped_file_sizeChanged || last_invokedChanged || retry_RemainingChanged || failure_reasonChanged || server_filepathChanged || task_type_idChanged || cash_order_idChanged ))
return;
qry.Append("UPDATE File_info set "); if ( parsedChanged )
{
qry.Append("parsed ="+parsedDbString);
qry.Append(",");
}

if ( bytes_transferredChanged )
{
qry.Append("bytes_transferred ="+bytes_transferredDbString);
qry.Append(",");
}

if ( file_path_at_ATMChanged )
{
qry.Append("file_path_at_ATM ="+file_path_at_ATMDbString);
qry.Append(",");
}

if ( aTM_idChanged )
{
qry.Append("ATM_id ="+aTM_idDbString);
qry.Append(",");
}

if ( file_type_idChanged )
{
qry.Append("file_type_id ="+file_type_idDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( download_timeChanged )
{
qry.Append("download_time ="+download_timeDbString);
qry.Append(",");
}

if ( end_timeChanged )
{
qry.Append("end_time ="+end_timeDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( zipped_file_sizeChanged )
{
qry.Append("zipped_file_size ="+zipped_file_sizeDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( unZipped_file_sizeChanged )
{
qry.Append("unZipped_file_size ="+unZipped_file_sizeDbString);
qry.Append(",");
}

if ( last_invokedChanged )
{
qry.Append("last_invoked ="+last_invokedDbString);
qry.Append(",");
}

if ( retry_RemainingChanged )
{
qry.Append("retry_Remaining ="+retry_RemainingDbString);
qry.Append(",");
}

if ( failure_reasonChanged )
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}

if ( server_filepathChanged )
{
qry.Append("server_filepath ="+server_filepathDbString);
qry.Append(",");
}

if ( task_type_idChanged )
{
qry.Append("task_type_id ="+task_type_idDbString);
qry.Append(",");
}

if ( cash_order_idChanged )
{
qry.Append("cash_order_id ="+cash_order_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("file_info_id = "+file_info_idDbString);
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
cmd.CommandText = "DELETE File_info where file_info_id = "+ file_info_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteFileInfos(string where)
{
ConnectionFactory.ExecuteQuery("delete File_info where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
file_info_id= 1,
parsed= 2,
bytes_transferred= 4,
file_path_at_ATM= 8,
ATM_id= 16,
file_type_id= 32,
creation_time= 64,
download_time= 128,
end_time= 256,
status= 512,
zipped_file_size= 1024,
created_by= 2048,
unZipped_file_size= 4096,
last_invoked= 8192,
retry_Remaining= 16384,
failure_reason= 32768,
server_filepath= 65536,
task_type_id= 131072,
cash_order_id= 262144
}
#endregion
}
}
