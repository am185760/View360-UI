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
public class Notification
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Notification() { }
public Notification( int notification_id,int retry_remaining,bool notification_sent,int alert_id ) 
{
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.notification_sent = notification_sent;
this.notification_sentChanged = true;
this.alert_id = alert_id;
this.alert_idChanged = true;
}
public Notification( int retry_remaining,DateTime? last_invoked_at,bool notification_sent,int alert_id,string failure_reason )
{
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.notification_sent = notification_sent;
this.notification_sentChanged = true;
this.alert_id = alert_id;
this.alert_idChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
}
private Notification( int notification_id,int retry_remaining,DateTime? last_invoked_at,bool notification_sent,int alert_id,string failure_reason )
{
this.notification_id = notification_id;
this.notification_idChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.notification_sent = notification_sent;
this.notification_sentChanged = true;
this.alert_id = alert_id;
this.alert_idChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
}

#region members and properties for columns

#region NotificationId
private bool notification_idChanged = false;
private int notification_id;
public int NotificationId
{
get { return notification_id; }
set { 
notification_id = value;
notification_idChanged = true;
}
}
private string notification_idDbString
{
get
{
return notification_id.ToString();
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
#region NotificationSent
private bool notification_sentChanged = false;
private bool notification_sent;
public bool NotificationSent
{
get { return notification_sent; }
set { 
notification_sent = value;
notification_sentChanged = true;
}
}
private string notification_sentDbString
{
get
{
return notification_sent?"1":"0";
}
}
#endregion
#region AlertId
private bool alert_idChanged = false;
private int alert_id;
public int AlertId
{
get { return alert_id; }
set { 
alert_id = value;
alert_idChanged = true;
}
}
private string alert_idDbString
{
get
{
return alert_id.ToString();
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

#region NotificationReader
public class NotificationReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Notification currentNotification;
Columns columns;
bool partialRead = false;
private NotificationReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public NotificationReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public NotificationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentNotification; }

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
currentNotification = new Notification();
if (partialRead)
{ if ((columns & Columns.notification_id) == Columns.notification_id && reader["notification_id"]!=DBNull.Value)
currentNotification.notification_id =(int) reader["notification_id"]; 
if ((columns & Columns.retry_remaining) == Columns.retry_remaining && reader["retry_remaining"]!=DBNull.Value)
currentNotification.retry_remaining =(int) reader["retry_remaining"]; 
if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"]!=DBNull.Value)
currentNotification.last_invoked_at =(DateTime?) reader["last_invoked_at"]; 
if ((columns & Columns.notification_sent) == Columns.notification_sent && reader["notification_sent"]!=DBNull.Value)
currentNotification.notification_sent =(bool) reader["notification_sent"]; 
if ((columns & Columns.alert_id) == Columns.alert_id && reader["alert_id"]!=DBNull.Value)
currentNotification.alert_id =(int) reader["alert_id"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentNotification.failure_reason =(string) reader["failure_reason"]; 

} else
{
if (reader["notification_id"] != DBNull.Value)
currentNotification.notification_id = (int) reader["notification_id"]; 
if (reader["retry_remaining"] != DBNull.Value)
currentNotification.retry_remaining = (int) reader["retry_remaining"]; 
if (reader["last_invoked_at"] != DBNull.Value)
currentNotification.last_invoked_at = (DateTime?) reader["last_invoked_at"]; 
if (reader["notification_sent"] != DBNull.Value)
currentNotification.notification_sent = (bool) reader["notification_sent"]; 
if (reader["alert_id"] != DBNull.Value)
currentNotification.alert_id = (int) reader["alert_id"]; 
if (reader["failure_reason"] != DBNull.Value)
currentNotification.failure_reason = (string) reader["failure_reason"]; 
} 

currentNotification.isNewEntity = false;
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

public Notification CurrentNotification
{
get{ return currentNotification; }
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


#region Notification functions

public static NotificationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.notification_id == (Columns.notification_id & columns))
qry.Append("notification_id,");
if (Columns.retry_remaining == (Columns.retry_remaining & columns))
qry.Append("retry_remaining,");
if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
qry.Append("last_invoked_at,");
if (Columns.notification_sent == (Columns.notification_sent & columns))
qry.Append("notification_sent,");
if (Columns.alert_id == (Columns.alert_id & columns))
qry.Append("alert_id,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Notification ");

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
return new NotificationReader(cmd.ExecuteReader(), conn, columns);
}

static public NotificationReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static NotificationReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select notification_id,retry_remaining,last_invoked_at,notification_sent,alert_id,failure_reason from Notification ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new NotificationReader(cmd.ExecuteReader(), conn);
}

static public NotificationReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Notification LoadNotification(string where)
{
NotificationReader reader = Notification.ExecuteReader(where);
Notification _notification = null;
if (reader.Read())
_notification = reader.CurrentNotification;
reader.Close();
return _notification;
}

public static Notification LoadNotification(string where, IDbConnection conn)
{
NotificationReader reader = Notification.ExecuteReader(where, conn);
Notification _notification = null;
if (reader.Read())
_notification = reader.CurrentNotification;
reader.Close(false);
return _notification;
}

public static Notification LoadNotificationByPk( int notification_id )
{
return LoadNotification( " notification_id="+notification_id );
}

public static Notification LoadNotificationByPk( int notification_id , IDbConnection conn)
{
return LoadNotification(" notification_id="+notification_id , conn);
}

public void Save()
{
if (notification_idChanged || retry_remainingChanged || last_invoked_atChanged || notification_sentChanged || alert_idChanged || failure_reasonChanged )
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
if (notification_idChanged || retry_remainingChanged || last_invoked_atChanged || notification_sentChanged || alert_idChanged || failure_reasonChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Notification( notification_id,retry_remaining,last_invoked_at,notification_sent,alert_id,failure_reason ) values(");
lock (ConnectionFactory.connectionString) { this.notification_id = ConnectionFactory.GetNextId();
qry.Append(this.notification_id);
} qry.Append(",");
qry.Append(retry_remainingDbString+",");
qry.Append(last_invoked_atDbString+",");
qry.Append(notification_sentDbString+",");
qry.Append(alert_idDbString+",");
qry.Append(failure_reasonDbString);
qry.Append(");");

}
else
{
if (!(notification_idChanged || retry_remainingChanged || last_invoked_atChanged || notification_sentChanged || alert_idChanged || failure_reasonChanged ))
return;
qry.Append("UPDATE Notification set "); if ( retry_remainingChanged )
{
qry.Append("retry_remaining ="+retry_remainingDbString);
qry.Append(",");
}

if ( last_invoked_atChanged )
{
qry.Append("last_invoked_at ="+last_invoked_atDbString);
qry.Append(",");
}

if ( notification_sentChanged )
{
qry.Append("notification_sent ="+notification_sentDbString);
qry.Append(",");
}

if ( alert_idChanged )
{
qry.Append("alert_id ="+alert_idDbString);
qry.Append(",");
}

if ( failure_reasonChanged )
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("notification_id = "+notification_idDbString);
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
cmd.CommandText = "DELETE Notification where notification_id = "+ notification_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteNotifications(string where)
{
ConnectionFactory.ExecuteQuery("delete Notification where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
notification_id= 1,
retry_remaining= 2,
last_invoked_at= 4,
notification_sent= 8,
alert_id= 16,
failure_reason= 32
}
#endregion
public void BulkSave(List<Notification> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Notification";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Notification.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Notification> transList,ref DataTable dt)
{
foreach (Notification tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["notification_id"] =ConnectionFactory.GetNextId();
Row["retry_remaining"] = tran.RetryRemaining;
Row["last_invoked_at"] = tran.LastInvokedAt;
Row["notification_sent"] = tran.NotificationSent;
Row["alert_id"] = tran.AlertId;
Row["failure_reason"] = tran.FailureReason;
dt.Rows.Add(Row);
} }
}
}
