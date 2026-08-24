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
public class AuditLog
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AuditLog() { }
public AuditLog( DateTime activity_time,string message,int right_id,int user_id )
{
this.activity_time = activity_time;
this.activity_timeChanged = true;
this.message = message;
this.messageChanged = true;
this.right_id = right_id;
this.right_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
}

#region members and properties for columns

#region ActivityTime
private bool activity_timeChanged = false;
private DateTime activity_time;
public DateTime ActivityTime
{
get { return activity_time; }
set { 
activity_time = value;
activity_timeChanged = true;
}
}
private string activity_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",activity_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region Message
private bool messageChanged = false;
private string message;
public string Message
{
get { return message; }
set { 
message = value;
messageChanged = true;
}
}
private string messageDbString
{
get
{
if (this.message!=null)
return string.Format("'{0}'",message); else
return "null";
}
}
#endregion
#region RightId
private bool right_idChanged = false;
private int right_id;
public int RightId
{
get { return right_id; }
set { 
right_id = value;
right_idChanged = true;
}
}
private string right_idDbString
{
get
{
return right_id.ToString();
}
}
#endregion
#region UserId
private bool user_idChanged = false;
private int user_id;
public int UserId
{
get { return user_id; }
set { 
user_id = value;
user_idChanged = true;
}
}
private string user_idDbString
{
get
{
return user_id.ToString();
}
}
#endregion
#endregion

#region AuditLogReader
public class AuditLogReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AuditLog currentAuditLog;
Columns columns;
bool partialRead = false;
private AuditLogReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AuditLogReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AuditLogReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAuditLog; }

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
currentAuditLog = new AuditLog();
if (partialRead)
{ if ((columns & Columns.activity_time) == Columns.activity_time && reader["activity_time"]!=DBNull.Value)
currentAuditLog.activity_time =(DateTime) reader["activity_time"]; 
if ((columns & Columns.message) == Columns.message && reader["message"]!=DBNull.Value)
currentAuditLog.message =(string) reader["message"]; 
if ((columns & Columns.right_id) == Columns.right_id && reader["right_id"]!=DBNull.Value)
currentAuditLog.right_id =(int) reader["right_id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentAuditLog.user_id =(int) reader["user_id"]; 

} else
{
if (reader["activity_time"] != DBNull.Value)
currentAuditLog.activity_time = (DateTime) reader["activity_time"]; 
if (reader["message"] != DBNull.Value)
currentAuditLog.message = (string) reader["message"]; 
if (reader["right_id"] != DBNull.Value)
currentAuditLog.right_id = (int) reader["right_id"]; 
if (reader["user_id"] != DBNull.Value)
currentAuditLog.user_id = (int) reader["user_id"]; 
} 

currentAuditLog.isNewEntity = false;
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

public AuditLog CurrentAuditLog
{
get{ return currentAuditLog; }
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


#region AuditLog functions

public static AuditLogReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.activity_time == (Columns.activity_time & columns))
qry.Append("activity_time,");
if (Columns.message == (Columns.message & columns))
qry.Append("message,");
if (Columns.right_id == (Columns.right_id & columns))
qry.Append("right_id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Audit_log ");

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
return new AuditLogReader(cmd.ExecuteReader(), conn, columns);
}

static public AuditLogReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AuditLogReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select activity_time,message,right_id,user_id from Audit_log ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AuditLogReader(cmd.ExecuteReader(), conn);
}

static public AuditLogReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AuditLog LoadAuditLog(string where)
{
AuditLogReader reader = AuditLog.ExecuteReader(where);
AuditLog _auditlog = null;
if (reader.Read())
_auditlog = reader.CurrentAuditLog;
reader.Close();
return _auditlog;
}

public static AuditLog LoadAuditLog(string where, IDbConnection conn)
{
AuditLogReader reader = AuditLog.ExecuteReader(where, conn);
AuditLog _auditlog = null;
if (reader.Read())
_auditlog = reader.CurrentAuditLog;
reader.Close(false);
return _auditlog;
}


public void Save()
{
if (activity_timeChanged || messageChanged || right_idChanged || user_idChanged )
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
if (activity_timeChanged || messageChanged || right_idChanged || user_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Audit_log( activity_time,message,right_id,user_id ) values(");
qry.Append(activity_timeDbString+",");
qry.Append(messageDbString+",");
qry.Append(right_idDbString+",");
qry.Append(user_idDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Audit_log!");
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

public static void DeleteAuditLogs(string where)
{
ConnectionFactory.ExecuteQuery("delete Audit_log where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
activity_time= 1,
message= 2,
right_id= 4,
user_id= 8
}
#endregion
public void BulkSave(List<AuditLog> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Audit_log";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AuditLog.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AuditLog> transList,ref DataTable dt)
{
foreach (AuditLog tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["activity_time"] = tran.ActivityTime;
Row["message"] = tran.Message;
Row["right_id"] = tran.RightId;
Row["user_id"] = tran.UserId;
dt.Rows.Add(Row);
} }
}
}
