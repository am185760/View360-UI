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
public class ErrorLog
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ErrorLog() { }
public ErrorLog( int error_log_id,int task_id ) 
{
this.task_id = task_id;
this.task_idChanged = true;
}
public ErrorLog( int task_id,string transaction_chunk,string failure_reason )
{
this.task_id = task_id;
this.task_idChanged = true;
this.transaction_chunk = transaction_chunk;
this.transaction_chunkChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
}
private ErrorLog( int error_log_id,int task_id,string transaction_chunk,string failure_reason )
{
this.error_log_id = error_log_id;
this.error_log_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.transaction_chunk = transaction_chunk;
this.transaction_chunkChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
}

#region members and properties for columns

#region ErrorLogId
private bool error_log_idChanged = false;
private int error_log_id;
public int ErrorLogId
{
get { return error_log_id; }
set { 
error_log_id = value;
error_log_idChanged = true;
}
}
private string error_log_idDbString
{
get
{
return error_log_id.ToString();
}
}
#endregion
#region TaskId
private bool task_idChanged = false;
private int task_id;
public int TaskId
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
return task_id.ToString();
}
}
#endregion
#region TransactionChunk
private bool transaction_chunkChanged = false;
private string transaction_chunk;
public string TransactionChunk
{
get { return transaction_chunk; }
set { 
transaction_chunk = value;
transaction_chunkChanged = true;
}
}
private string transaction_chunkDbString
{
get
{
if (this.transaction_chunk!=null)
return string.Format("'{0}'",transaction_chunk); else
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
#endregion

#region ErrorLogReader
public class ErrorLogReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ErrorLog currentErrorLog;
Columns columns;
bool partialRead = false;
private ErrorLogReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ErrorLogReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ErrorLogReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentErrorLog; }

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
currentErrorLog = new ErrorLog();
if (partialRead)
{ if ((columns & Columns.error_log_id) == Columns.error_log_id && reader["error_log_id"]!=DBNull.Value)
currentErrorLog.error_log_id =(int) reader["error_log_id"]; 
if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
currentErrorLog.task_id =(int) reader["task_id"]; 
if ((columns & Columns.transaction_chunk) == Columns.transaction_chunk && reader["transaction_chunk"]!=DBNull.Value)
currentErrorLog.transaction_chunk =(string) reader["transaction_chunk"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentErrorLog.failure_reason =(string) reader["failure_reason"]; 

} else
{
if (reader["error_log_id"] != DBNull.Value)
currentErrorLog.error_log_id = (int) reader["error_log_id"]; 
if (reader["task_id"] != DBNull.Value)
currentErrorLog.task_id = (int) reader["task_id"]; 
if (reader["transaction_chunk"] != DBNull.Value)
currentErrorLog.transaction_chunk = (string) reader["transaction_chunk"]; 
if (reader["failure_reason"] != DBNull.Value)
currentErrorLog.failure_reason = (string) reader["failure_reason"]; 
} 

currentErrorLog.isNewEntity = false;
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

public ErrorLog CurrentErrorLog
{
get{ return currentErrorLog; }
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


#region ErrorLog functions

public static ErrorLogReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.error_log_id == (Columns.error_log_id & columns))
qry.Append("error_log_id,");
if (Columns.task_id == (Columns.task_id & columns))
qry.Append("task_id,");
if (Columns.transaction_chunk == (Columns.transaction_chunk & columns))
qry.Append("transaction_chunk,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Error_log ");

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
return new ErrorLogReader(cmd.ExecuteReader(), conn, columns);
}

static public ErrorLogReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ErrorLogReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select error_log_id,task_id,transaction_chunk,failure_reason from Error_log ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ErrorLogReader(cmd.ExecuteReader(), conn);
}

static public ErrorLogReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ErrorLog LoadErrorLog(string where)
{
ErrorLogReader reader = ErrorLog.ExecuteReader(where);
ErrorLog _errorlog = null;
if (reader.Read())
_errorlog = reader.CurrentErrorLog;
reader.Close();
return _errorlog;
}

public static ErrorLog LoadErrorLog(string where, IDbConnection conn)
{
ErrorLogReader reader = ErrorLog.ExecuteReader(where, conn);
ErrorLog _errorlog = null;
if (reader.Read())
_errorlog = reader.CurrentErrorLog;
reader.Close(false);
return _errorlog;
}

public static ErrorLog LoadErrorLogByPk( int error_log_id )
{
return LoadErrorLog( " error_log_id="+error_log_id );
}

public static ErrorLog LoadErrorLogByPk( int error_log_id , IDbConnection conn)
{
return LoadErrorLog(" error_log_id="+error_log_id , conn);
}

public void Save()
{
if (error_log_idChanged || task_idChanged || transaction_chunkChanged || failure_reasonChanged )
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
if (error_log_idChanged || task_idChanged || transaction_chunkChanged || failure_reasonChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Error_log( error_log_id,task_id,transaction_chunk,failure_reason ) values(");
lock (ConnectionFactory.connectionString) { this.error_log_id = ConnectionFactory.GetNextId();
qry.Append(this.error_log_id);
} qry.Append(",");
qry.Append(task_idDbString+",");
qry.Append(transaction_chunkDbString+",");
qry.Append(failure_reasonDbString);
qry.Append(");");

}
else
{
if (!(error_log_idChanged || task_idChanged || transaction_chunkChanged || failure_reasonChanged ))
return;
qry.Append("UPDATE Error_log set "); if ( task_idChanged )
{
qry.Append("task_id ="+task_idDbString);
qry.Append(",");
}

if ( transaction_chunkChanged )
{
qry.Append("transaction_chunk ="+transaction_chunkDbString);
qry.Append(",");
}

if ( failure_reasonChanged )
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("error_log_id = "+error_log_idDbString);
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
cmd.CommandText = "DELETE Error_log where error_log_id = "+ error_log_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteErrorLogs(string where)
{
ConnectionFactory.ExecuteQuery("delete Error_log where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
error_log_id= 1,
task_id= 2,
transaction_chunk= 4,
failure_reason= 8
}
#endregion
public void BulkSave(List<ErrorLog> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Error_log";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ErrorLog.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ErrorLog> transList,ref DataTable dt)
{
foreach (ErrorLog tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["error_log_id"] =ConnectionFactory.GetNextId();
Row["task_id"] = tran.TaskId;
Row["transaction_chunk"] = tran.TransactionChunk;
Row["failure_reason"] = tran.FailureReason;
dt.Rows.Add(Row);
} }
}
}
