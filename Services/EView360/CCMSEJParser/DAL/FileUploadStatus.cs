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
public class FileUploadStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public FileUploadStatus() { }
public FileUploadStatus( int file_upload_status_id,int atm_id,int upload_id,int file_seq_no,string status ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.upload_id = upload_id;
this.upload_idChanged = true;
this.file_seq_no = file_seq_no;
this.file_seq_noChanged = true;
this.status = status;
this.statusChanged = true;
}
public FileUploadStatus( int atm_id,int upload_id,int file_seq_no,string status,int? uploaded_bytes,DateTime? start_time,DateTime? end_time,int? connection_breaks,DateTime? active_time )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.upload_id = upload_id;
this.upload_idChanged = true;
this.file_seq_no = file_seq_no;
this.file_seq_noChanged = true;
this.status = status;
this.statusChanged = true;
this.uploaded_bytes = uploaded_bytes;
this.uploaded_bytesChanged = true;
this.start_time = start_time;
this.start_timeChanged = true;
this.end_time = end_time;
this.end_timeChanged = true;
this.connection_breaks = connection_breaks;
this.connection_breaksChanged = true;
this.active_time = active_time;
this.active_timeChanged = true;
}
private FileUploadStatus( int file_upload_status_id,int atm_id,int upload_id,int file_seq_no,string status,int? uploaded_bytes,DateTime? start_time,DateTime? end_time,int? connection_breaks,DateTime? active_time )
{
this.file_upload_status_id = file_upload_status_id;
this.file_upload_status_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.upload_id = upload_id;
this.upload_idChanged = true;
this.file_seq_no = file_seq_no;
this.file_seq_noChanged = true;
this.status = status;
this.statusChanged = true;
this.uploaded_bytes = uploaded_bytes;
this.uploaded_bytesChanged = true;
this.start_time = start_time;
this.start_timeChanged = true;
this.end_time = end_time;
this.end_timeChanged = true;
this.connection_breaks = connection_breaks;
this.connection_breaksChanged = true;
this.active_time = active_time;
this.active_timeChanged = true;
}

#region members and properties for columns

#region FileUploadStatusId
private bool file_upload_status_idChanged = false;
private int file_upload_status_id;
public int FileUploadStatusId
{
get { return file_upload_status_id; }
set { 
file_upload_status_id = value;
file_upload_status_idChanged = true;
}
}
private string file_upload_status_idDbString
{
get
{
return file_upload_status_id.ToString();
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
#region FileSeqNo
private bool file_seq_noChanged = false;
private int file_seq_no;
public int FileSeqNo
{
get { return file_seq_no; }
set { 
file_seq_no = value;
file_seq_noChanged = true;
}
}
private string file_seq_noDbString
{
get
{
return file_seq_no.ToString();
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
#region UploadedBytes
private bool uploaded_bytesChanged = false;
private int? uploaded_bytes;
public int? UploadedBytes
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
if (this.uploaded_bytes.HasValue)
return uploaded_bytes.ToString();
else
return "null";
}
}
#endregion
#region StartTime
private bool start_timeChanged = false;
private DateTime? start_time;
public DateTime? StartTime
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
if (this.start_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",start_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region ConnectionBreaks
private bool connection_breaksChanged = false;
private int? connection_breaks;
public int? ConnectionBreaks
{
get { return connection_breaks; }
set { 
connection_breaks = value;
connection_breaksChanged = true;
}
}
private string connection_breaksDbString
{
get
{
if (this.connection_breaks.HasValue)
return connection_breaks.ToString();
else
return "null";
}
}
#endregion
#region ActiveTime
private bool active_timeChanged = false;
private DateTime? active_time;
public DateTime? ActiveTime
{
get { return active_time; }
set { 
active_time = value;
active_timeChanged = true;
}
}
private string active_timeDbString
{
get
{
if (this.active_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",active_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#endregion

#region FileUploadStatusReader
public class FileUploadStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
FileUploadStatus currentFileUploadStatus;
Columns columns;
bool partialRead = false;
private FileUploadStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public FileUploadStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public FileUploadStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentFileUploadStatus; }

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
currentFileUploadStatus = new FileUploadStatus();
if (partialRead)
{ if ((columns & Columns.file_upload_status_id) == Columns.file_upload_status_id && reader["file_upload_status_id"]!=DBNull.Value)
currentFileUploadStatus.file_upload_status_id =(int) reader["file_upload_status_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentFileUploadStatus.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.upload_id) == Columns.upload_id && reader["upload_id"]!=DBNull.Value)
currentFileUploadStatus.upload_id =(int) reader["upload_id"]; 
if ((columns & Columns.file_seq_no) == Columns.file_seq_no && reader["file_seq_no"]!=DBNull.Value)
currentFileUploadStatus.file_seq_no =(int) reader["file_seq_no"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentFileUploadStatus.status =(string) reader["status"]; 
if ((columns & Columns.uploaded_bytes) == Columns.uploaded_bytes && reader["uploaded_bytes"]!=DBNull.Value)
currentFileUploadStatus.uploaded_bytes =(int?) reader["uploaded_bytes"]; 
if ((columns & Columns.start_time) == Columns.start_time && reader["start_time"]!=DBNull.Value)
currentFileUploadStatus.start_time =(DateTime?) reader["start_time"]; 
if ((columns & Columns.end_time) == Columns.end_time && reader["end_time"]!=DBNull.Value)
currentFileUploadStatus.end_time =(DateTime?) reader["end_time"]; 
if ((columns & Columns.connection_breaks) == Columns.connection_breaks && reader["connection_breaks"]!=DBNull.Value)
currentFileUploadStatus.connection_breaks =(int?) reader["connection_breaks"]; 
if ((columns & Columns.active_time) == Columns.active_time && reader["active_time"]!=DBNull.Value)
currentFileUploadStatus.active_time =(DateTime?) reader["active_time"]; 

} else
{
if (reader["file_upload_status_id"] != DBNull.Value)
currentFileUploadStatus.file_upload_status_id = (int) reader["file_upload_status_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentFileUploadStatus.atm_id = (int) reader["atm_id"]; 
if (reader["upload_id"] != DBNull.Value)
currentFileUploadStatus.upload_id = (int) reader["upload_id"]; 
if (reader["file_seq_no"] != DBNull.Value)
currentFileUploadStatus.file_seq_no = (int) reader["file_seq_no"]; 
if (reader["status"] != DBNull.Value)
currentFileUploadStatus.status = (string) reader["status"]; 
if (reader["uploaded_bytes"] != DBNull.Value)
currentFileUploadStatus.uploaded_bytes = (int?) reader["uploaded_bytes"]; 
if (reader["start_time"] != DBNull.Value)
currentFileUploadStatus.start_time = (DateTime?) reader["start_time"]; 
if (reader["end_time"] != DBNull.Value)
currentFileUploadStatus.end_time = (DateTime?) reader["end_time"]; 
if (reader["connection_breaks"] != DBNull.Value)
currentFileUploadStatus.connection_breaks = (int?) reader["connection_breaks"]; 
if (reader["active_time"] != DBNull.Value)
currentFileUploadStatus.active_time = (DateTime?) reader["active_time"]; 
} 

currentFileUploadStatus.isNewEntity = false;
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

public FileUploadStatus CurrentFileUploadStatus
{
get{ return currentFileUploadStatus; }
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


#region FileUploadStatus functions

public static FileUploadStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.file_upload_status_id == (Columns.file_upload_status_id & columns))
qry.Append("file_upload_status_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.upload_id == (Columns.upload_id & columns))
qry.Append("upload_id,");
if (Columns.file_seq_no == (Columns.file_seq_no & columns))
qry.Append("file_seq_no,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.uploaded_bytes == (Columns.uploaded_bytes & columns))
qry.Append("uploaded_bytes,");
if (Columns.start_time == (Columns.start_time & columns))
qry.Append("start_time,");
if (Columns.end_time == (Columns.end_time & columns))
qry.Append("end_time,");
if (Columns.connection_breaks == (Columns.connection_breaks & columns))
qry.Append("connection_breaks,");
if (Columns.active_time == (Columns.active_time & columns))
qry.Append("active_time,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from File_upload_status ");

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
return new FileUploadStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public FileUploadStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static FileUploadStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select file_upload_status_id,atm_id,upload_id,file_seq_no,status,uploaded_bytes,start_time,end_time,connection_breaks,active_time from File_upload_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new FileUploadStatusReader(cmd.ExecuteReader(), conn);
}

static public FileUploadStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static FileUploadStatus LoadFileUploadStatus(string where)
{
FileUploadStatusReader reader = FileUploadStatus.ExecuteReader(where);
FileUploadStatus _fileuploadstatus = null;
if (reader.Read())
_fileuploadstatus = reader.CurrentFileUploadStatus;
reader.Close();
return _fileuploadstatus;
}

public static FileUploadStatus LoadFileUploadStatus(string where, IDbConnection conn)
{
FileUploadStatusReader reader = FileUploadStatus.ExecuteReader(where, conn);
FileUploadStatus _fileuploadstatus = null;
if (reader.Read())
_fileuploadstatus = reader.CurrentFileUploadStatus;
reader.Close(false);
return _fileuploadstatus;
}

public static FileUploadStatus LoadFileUploadStatusByPk( int file_upload_status_id )
{
return LoadFileUploadStatus( " file_upload_status_id="+file_upload_status_id );
}

public static FileUploadStatus LoadFileUploadStatusByPk( int file_upload_status_id , IDbConnection conn)
{
return LoadFileUploadStatus(" file_upload_status_id="+file_upload_status_id , conn);
}

public void Save()
{
if (file_upload_status_idChanged || atm_idChanged || upload_idChanged || file_seq_noChanged || statusChanged || uploaded_bytesChanged || start_timeChanged || end_timeChanged || connection_breaksChanged || active_timeChanged )
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
if (file_upload_status_idChanged || atm_idChanged || upload_idChanged || file_seq_noChanged || statusChanged || uploaded_bytesChanged || start_timeChanged || end_timeChanged || connection_breaksChanged || active_timeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into File_upload_status( file_upload_status_id,atm_id,upload_id,file_seq_no,status,uploaded_bytes,start_time,end_time,connection_breaks,active_time ) values(");
lock (ConnectionFactory.connectionString) { this.file_upload_status_id = ConnectionFactory.GetNextId();
qry.Append(this.file_upload_status_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(upload_idDbString+",");
qry.Append(file_seq_noDbString+",");
qry.Append(statusDbString+",");
qry.Append(uploaded_bytesDbString+",");
qry.Append(start_timeDbString+",");
qry.Append(end_timeDbString+",");
qry.Append(connection_breaksDbString+",");
qry.Append(active_timeDbString);
qry.Append(");");

}
else
{
if (!(file_upload_status_idChanged || atm_idChanged || upload_idChanged || file_seq_noChanged || statusChanged || uploaded_bytesChanged || start_timeChanged || end_timeChanged || connection_breaksChanged || active_timeChanged ))
return;
qry.Append("UPDATE File_upload_status set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( upload_idChanged )
{
qry.Append("upload_id ="+upload_idDbString);
qry.Append(",");
}

if ( file_seq_noChanged )
{
qry.Append("file_seq_no ="+file_seq_noDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( uploaded_bytesChanged )
{
qry.Append("uploaded_bytes ="+uploaded_bytesDbString);
qry.Append(",");
}

if ( start_timeChanged )
{
qry.Append("start_time ="+start_timeDbString);
qry.Append(",");
}

if ( end_timeChanged )
{
qry.Append("end_time ="+end_timeDbString);
qry.Append(",");
}

if ( connection_breaksChanged )
{
qry.Append("connection_breaks ="+connection_breaksDbString);
qry.Append(",");
}

if ( active_timeChanged )
{
qry.Append("active_time ="+active_timeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("file_upload_status_id = "+file_upload_status_idDbString);
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
cmd.CommandText = "DELETE File_upload_status where file_upload_status_id = "+ file_upload_status_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteFileUploadStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete File_upload_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
file_upload_status_id= 1,
atm_id= 2,
upload_id= 4,
file_seq_no= 8,
status= 16,
uploaded_bytes= 32,
start_time= 64,
end_time= 128,
connection_breaks= 256,
active_time= 512
}
#endregion
public void BulkSave(List<FileUploadStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "File_upload_status";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(FileUploadStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <FileUploadStatus> transList,ref DataTable dt)
{
foreach (FileUploadStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["file_upload_status_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["upload_id"] = tran.UploadId;
Row["file_seq_no"] = tran.FileSeqNo;
Row["status"] = tran.Status;
Row["uploaded_bytes"] = tran.UploadedBytes;
Row["start_time"] = tran.StartTime;
Row["end_time"] = tran.EndTime;
Row["connection_breaks"] = tran.ConnectionBreaks;
Row["active_time"] = tran.ActiveTime;
dt.Rows.Add(Row);
} }
}
}
