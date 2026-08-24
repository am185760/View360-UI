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
public class GeneralAlert
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public GeneralAlert() { }
public GeneralAlert( int general_alert_id,DateTime generated_at,int alert_type_id,DateTime expiration_time,string alert_msg,int retry_remaining,bool generate_notification_sent ) 
{
this.generated_at = generated_at;
this.generated_atChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
this.alert_msg = alert_msg;
this.alert_msgChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.generate_notification_sent = generate_notification_sent;
this.generate_notification_sentChanged = true;
}
public GeneralAlert( DateTime generated_at,int alert_type_id,DateTime expiration_time,string alert_msg,int retry_remaining,DateTime? last_invoked_at,bool generate_notification_sent,string failure_reason,int? entity_id,string entity_type )
{
this.generated_at = generated_at;
this.generated_atChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
this.alert_msg = alert_msg;
this.alert_msgChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.generate_notification_sent = generate_notification_sent;
this.generate_notification_sentChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.entity_id = entity_id;
this.entity_idChanged = true;
this.entity_type = entity_type;
this.entity_typeChanged = true;
}
private GeneralAlert( int general_alert_id,DateTime generated_at,int alert_type_id,DateTime expiration_time,string alert_msg,int retry_remaining,DateTime? last_invoked_at,bool generate_notification_sent,string failure_reason,int? entity_id,string entity_type )
{
this.general_alert_id = general_alert_id;
this.general_alert_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
this.alert_msg = alert_msg;
this.alert_msgChanged = true;
this.retry_remaining = retry_remaining;
this.retry_remainingChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.generate_notification_sent = generate_notification_sent;
this.generate_notification_sentChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.entity_id = entity_id;
this.entity_idChanged = true;
this.entity_type = entity_type;
this.entity_typeChanged = true;
}

#region members and properties for columns

#region GeneralAlertId
private bool general_alert_idChanged = false;
private int general_alert_id;
public int GeneralAlertId
{
get { return general_alert_id; }
set { 
general_alert_id = value;
general_alert_idChanged = true;
}
}
private string general_alert_idDbString
{
get
{
return general_alert_id.ToString();
}
}
#endregion
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime generated_at;
public DateTime GeneratedAt
{
get { return generated_at; }
set { 
generated_at = value;
generated_atChanged = true;
}
}
private string generated_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region AlertTypeId
private bool alert_type_idChanged = false;
private int alert_type_id;
public int AlertTypeId
{
get { return alert_type_id; }
set { 
alert_type_id = value;
alert_type_idChanged = true;
}
}
private string alert_type_idDbString
{
get
{
return alert_type_id.ToString();
}
}
#endregion
#region ExpirationTime
private bool expiration_timeChanged = false;
private DateTime expiration_time;
public DateTime ExpirationTime
{
get { return expiration_time; }
set { 
expiration_time = value;
expiration_timeChanged = true;
}
}
private string expiration_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",expiration_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region AlertMsg
private bool alert_msgChanged = false;
private string alert_msg;
public string AlertMsg
{
get { return alert_msg; }
set { 
alert_msg = value;
alert_msgChanged = true;
}
}
private string alert_msgDbString
{
get
{
if (this.alert_msg!=null)
return string.Format("'{0}'",alert_msg); else
return "null";
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
#region GenerateNotificationSent
private bool generate_notification_sentChanged = false;
private bool generate_notification_sent;
public bool GenerateNotificationSent
{
get { return generate_notification_sent; }
set { 
generate_notification_sent = value;
generate_notification_sentChanged = true;
}
}
private string generate_notification_sentDbString
{
get
{
return generate_notification_sent?"1":"0";
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
#endregion

#region GeneralAlertReader
public class GeneralAlertReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
GeneralAlert currentGeneralAlert;
Columns columns;
bool partialRead = false;
private GeneralAlertReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public GeneralAlertReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public GeneralAlertReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentGeneralAlert; }

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
currentGeneralAlert = new GeneralAlert();
if (partialRead)
{ if ((columns & Columns.general_alert_id) == Columns.general_alert_id && reader["general_alert_id"]!=DBNull.Value)
currentGeneralAlert.general_alert_id =(int) reader["general_alert_id"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentGeneralAlert.generated_at =(DateTime) reader["generated_at"]; 
if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"]!=DBNull.Value)
currentGeneralAlert.alert_type_id =(int) reader["alert_type_id"]; 
if ((columns & Columns.expiration_time) == Columns.expiration_time && reader["expiration_time"]!=DBNull.Value)
currentGeneralAlert.expiration_time =(DateTime) reader["expiration_time"]; 
if ((columns & Columns.alert_msg) == Columns.alert_msg && reader["alert_msg"]!=DBNull.Value)
currentGeneralAlert.alert_msg =(string) reader["alert_msg"]; 
if ((columns & Columns.retry_remaining) == Columns.retry_remaining && reader["retry_remaining"]!=DBNull.Value)
currentGeneralAlert.retry_remaining =(int) reader["retry_remaining"]; 
if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"]!=DBNull.Value)
currentGeneralAlert.last_invoked_at =(DateTime?) reader["last_invoked_at"]; 
if ((columns & Columns.generate_notification_sent) == Columns.generate_notification_sent && reader["generate_notification_sent"]!=DBNull.Value)
currentGeneralAlert.generate_notification_sent =(bool) reader["generate_notification_sent"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentGeneralAlert.failure_reason =(string) reader["failure_reason"]; 
if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"]!=DBNull.Value)
currentGeneralAlert.entity_id =(int?) reader["entity_id"]; 
if ((columns & Columns.entity_type) == Columns.entity_type && reader["entity_type"]!=DBNull.Value)
currentGeneralAlert.entity_type =(string) reader["entity_type"]; 

} else
{
if (reader["general_alert_id"] != DBNull.Value)
currentGeneralAlert.general_alert_id = (int) reader["general_alert_id"]; 
if (reader["generated_at"] != DBNull.Value)
currentGeneralAlert.generated_at = (DateTime) reader["generated_at"]; 
if (reader["alert_type_id"] != DBNull.Value)
currentGeneralAlert.alert_type_id = (int) reader["alert_type_id"]; 
if (reader["expiration_time"] != DBNull.Value)
currentGeneralAlert.expiration_time = (DateTime) reader["expiration_time"]; 
if (reader["alert_msg"] != DBNull.Value)
currentGeneralAlert.alert_msg = (string) reader["alert_msg"]; 
if (reader["retry_remaining"] != DBNull.Value)
currentGeneralAlert.retry_remaining = (int) reader["retry_remaining"]; 
if (reader["last_invoked_at"] != DBNull.Value)
currentGeneralAlert.last_invoked_at = (DateTime?) reader["last_invoked_at"]; 
if (reader["generate_notification_sent"] != DBNull.Value)
currentGeneralAlert.generate_notification_sent = (bool) reader["generate_notification_sent"]; 
if (reader["failure_reason"] != DBNull.Value)
currentGeneralAlert.failure_reason = (string) reader["failure_reason"]; 
if (reader["entity_id"] != DBNull.Value)
currentGeneralAlert.entity_id = (int?) reader["entity_id"]; 
if (reader["entity_type"] != DBNull.Value)
currentGeneralAlert.entity_type = (string) reader["entity_type"]; 
} 

currentGeneralAlert.isNewEntity = false;
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

public GeneralAlert CurrentGeneralAlert
{
get{ return currentGeneralAlert; }
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


#region GeneralAlert functions

public static GeneralAlertReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.general_alert_id == (Columns.general_alert_id & columns))
qry.Append("general_alert_id,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.alert_type_id == (Columns.alert_type_id & columns))
qry.Append("alert_type_id,");
if (Columns.expiration_time == (Columns.expiration_time & columns))
qry.Append("expiration_time,");
if (Columns.alert_msg == (Columns.alert_msg & columns))
qry.Append("alert_msg,");
if (Columns.retry_remaining == (Columns.retry_remaining & columns))
qry.Append("retry_remaining,");
if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
qry.Append("last_invoked_at,");
if (Columns.generate_notification_sent == (Columns.generate_notification_sent & columns))
qry.Append("generate_notification_sent,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
if (Columns.entity_id == (Columns.entity_id & columns))
qry.Append("entity_id,");
if (Columns.entity_type == (Columns.entity_type & columns))
qry.Append("entity_type,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from General_alert ");

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
return new GeneralAlertReader(cmd.ExecuteReader(), conn, columns);
}

static public GeneralAlertReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static GeneralAlertReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select general_alert_id,generated_at,alert_type_id,expiration_time,alert_msg,retry_remaining,last_invoked_at,generate_notification_sent,failure_reason,entity_id,entity_type from General_alert ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new GeneralAlertReader(cmd.ExecuteReader(), conn);
}

static public GeneralAlertReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static GeneralAlert LoadGeneralAlert(string where)
{
GeneralAlertReader reader = GeneralAlert.ExecuteReader(where);
GeneralAlert _generalalert = null;
if (reader.Read())
_generalalert = reader.CurrentGeneralAlert;
reader.Close();
return _generalalert;
}

public static GeneralAlert LoadGeneralAlert(string where, IDbConnection conn)
{
GeneralAlertReader reader = GeneralAlert.ExecuteReader(where, conn);
GeneralAlert _generalalert = null;
if (reader.Read())
_generalalert = reader.CurrentGeneralAlert;
reader.Close(false);
return _generalalert;
}

public static GeneralAlert LoadGeneralAlertByPk( int general_alert_id )
{
return LoadGeneralAlert( " general_alert_id="+general_alert_id );
}

public static GeneralAlert LoadGeneralAlertByPk( int general_alert_id , IDbConnection conn)
{
return LoadGeneralAlert(" general_alert_id="+general_alert_id , conn);
}

public void Save()
{
if (general_alert_idChanged || generated_atChanged || alert_type_idChanged || expiration_timeChanged || alert_msgChanged || retry_remainingChanged || last_invoked_atChanged || generate_notification_sentChanged || failure_reasonChanged || entity_idChanged || entity_typeChanged )
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
if (general_alert_idChanged || generated_atChanged || alert_type_idChanged || expiration_timeChanged || alert_msgChanged || retry_remainingChanged || last_invoked_atChanged || generate_notification_sentChanged || failure_reasonChanged || entity_idChanged || entity_typeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into General_alert( general_alert_id,generated_at,alert_type_id,expiration_time,alert_msg,retry_remaining,last_invoked_at,generate_notification_sent,failure_reason,entity_id,entity_type ) values(");
lock (ConnectionFactory.connectionString) { this.general_alert_id = ConnectionFactory.GetNextId();
qry.Append(this.general_alert_id);
} qry.Append(",");
qry.Append(generated_atDbString+",");
qry.Append(alert_type_idDbString+",");
qry.Append(expiration_timeDbString+",");
qry.Append(alert_msgDbString+",");
qry.Append(retry_remainingDbString+",");
qry.Append(last_invoked_atDbString+",");
qry.Append(generate_notification_sentDbString+",");
qry.Append(failure_reasonDbString+",");
qry.Append(entity_idDbString+",");
qry.Append(entity_typeDbString);
qry.Append(");");

}
else
{
if (!(general_alert_idChanged || generated_atChanged || alert_type_idChanged || expiration_timeChanged || alert_msgChanged || retry_remainingChanged || last_invoked_atChanged || generate_notification_sentChanged || failure_reasonChanged || entity_idChanged || entity_typeChanged ))
return;
qry.Append("UPDATE General_alert set "); if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( alert_type_idChanged )
{
qry.Append("alert_type_id ="+alert_type_idDbString);
qry.Append(",");
}

if ( expiration_timeChanged )
{
qry.Append("expiration_time ="+expiration_timeDbString);
qry.Append(",");
}

if ( alert_msgChanged )
{
qry.Append("alert_msg ="+alert_msgDbString);
qry.Append(",");
}

if ( retry_remainingChanged )
{
qry.Append("retry_remaining ="+retry_remainingDbString);
qry.Append(",");
}

if ( last_invoked_atChanged )
{
qry.Append("last_invoked_at ="+last_invoked_atDbString);
qry.Append(",");
}

if ( generate_notification_sentChanged )
{
qry.Append("generate_notification_sent ="+generate_notification_sentDbString);
qry.Append(",");
}

if ( failure_reasonChanged )
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}

if ( entity_idChanged )
{
qry.Append("entity_id ="+entity_idDbString);
qry.Append(",");
}

if ( entity_typeChanged )
{
qry.Append("entity_type ="+entity_typeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("general_alert_id = "+general_alert_idDbString);
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
cmd.CommandText = "DELETE General_alert where general_alert_id = "+ general_alert_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteGeneralAlerts(string where)
{
ConnectionFactory.ExecuteQuery("delete General_alert where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
general_alert_id= 1,
generated_at= 2,
alert_type_id= 4,
expiration_time= 8,
alert_msg= 16,
retry_remaining= 32,
last_invoked_at= 64,
generate_notification_sent= 128,
failure_reason= 256,
entity_id= 512,
entity_type= 1024
}
#endregion
public void BulkSave(List<GeneralAlert> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "General_alert";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(GeneralAlert.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <GeneralAlert> transList,ref DataTable dt)
{
foreach (GeneralAlert tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["general_alert_id"] =ConnectionFactory.GetNextId();
Row["generated_at"] = tran.GeneratedAt;
Row["alert_type_id"] = tran.AlertTypeId;
Row["expiration_time"] = tran.ExpirationTime;
Row["alert_msg"] = tran.AlertMsg;
Row["retry_remaining"] = tran.RetryRemaining;
Row["last_invoked_at"] = tran.LastInvokedAt;
Row["generate_notification_sent"] = tran.GenerateNotificationSent;
Row["failure_reason"] = tran.FailureReason;
Row["entity_id"] = tran.EntityId;
Row["entity_type"] = tran.EntityType;
dt.Rows.Add(Row);
} }
}
}
