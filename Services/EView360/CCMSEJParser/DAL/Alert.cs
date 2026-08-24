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
public class Alert
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Alert() { }
public Alert( int alert_id,DateTime generated_at,int alert_type_id ) 
{
this.generated_at = generated_at;
this.generated_atChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
}
public Alert( int? atm_id,bool? status,DateTime generated_at,DateTime? resolve_at,int alert_type_id,string source,int? ftp_file_info_id,string alert_data,DateTime? expiration_time )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.status = status;
this.statusChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.resolve_at = resolve_at;
this.resolve_atChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.source = source;
this.sourceChanged = true;
this.ftp_file_info_id = ftp_file_info_id;
this.ftp_file_info_idChanged = true;
this.alert_data = alert_data;
this.alert_dataChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
}
private Alert( int? atm_id,int alert_id,bool? status,DateTime generated_at,DateTime? resolve_at,int alert_type_id,string source,int? ftp_file_info_id,string alert_data,DateTime? expiration_time )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.alert_id = alert_id;
this.alert_idChanged = true;
this.status = status;
this.statusChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.resolve_at = resolve_at;
this.resolve_atChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.source = source;
this.sourceChanged = true;
this.ftp_file_info_id = ftp_file_info_id;
this.ftp_file_info_idChanged = true;
this.alert_data = alert_data;
this.alert_dataChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
}

#region members and properties for columns

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
#region Status
private bool statusChanged = false;
private bool? status;
public bool? Status
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
if (this.status.HasValue)
return status.Value?"1":"0";
else
return "null";
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
#region ResolveAt
private bool resolve_atChanged = false;
private DateTime? resolve_at;
public DateTime? ResolveAt
{
get { return resolve_at; }
set { 
resolve_at = value;
resolve_atChanged = true;
}
}
private string resolve_atDbString
{
get
{
if (this.resolve_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",resolve_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
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
#region Source
private bool sourceChanged = false;
private string source;
public string Source
{
get { return source; }
set { 
source = value;
sourceChanged = true;
}
}
private string sourceDbString
{
get
{
if (this.source!=null)
return string.Format("'{0}'",source); else
return "null";
}
}
#endregion
#region FtpFileInfoId
private bool ftp_file_info_idChanged = false;
private int? ftp_file_info_id;
public int? FtpFileInfoId
{
get { return ftp_file_info_id; }
set { 
ftp_file_info_id = value;
ftp_file_info_idChanged = true;
}
}
private string ftp_file_info_idDbString
{
get
{
if (this.ftp_file_info_id.HasValue)
return ftp_file_info_id.ToString();
else
return "null";
}
}
#endregion
#region AlertData
private bool alert_dataChanged = false;
private string alert_data;
public string AlertData
{
get { return alert_data; }
set { 
alert_data = value;
alert_dataChanged = true;
}
}
private string alert_dataDbString
{
get
{
if (this.alert_data!=null)
return string.Format("'{0}'",alert_data); else
return "null";
}
}
#endregion
#region ExpirationTime
private bool expiration_timeChanged = false;
private DateTime? expiration_time;
public DateTime? ExpirationTime
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
if (this.expiration_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",expiration_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#endregion

#region AlertReader
public class AlertReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Alert currentAlert;
Columns columns;
bool partialRead = false;
private AlertReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AlertReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AlertReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAlert; }

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
currentAlert = new Alert();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAlert.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.alert_id) == Columns.alert_id && reader["alert_id"]!=DBNull.Value)
currentAlert.alert_id =(int) reader["alert_id"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentAlert.status =(bool?) reader["status"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentAlert.generated_at =(DateTime) reader["generated_at"]; 
if ((columns & Columns.resolve_at) == Columns.resolve_at && reader["resolve_at"]!=DBNull.Value)
currentAlert.resolve_at =(DateTime?) reader["resolve_at"]; 
if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"]!=DBNull.Value)
currentAlert.alert_type_id =(int) reader["alert_type_id"]; 
if ((columns & Columns.source) == Columns.source && reader["source"]!=DBNull.Value)
currentAlert.source =(string) reader["source"]; 
if ((columns & Columns.ftp_file_info_id) == Columns.ftp_file_info_id && reader["ftp_file_info_id"]!=DBNull.Value)
currentAlert.ftp_file_info_id =(int?) reader["ftp_file_info_id"]; 
if ((columns & Columns.alert_data) == Columns.alert_data && reader["alert_data"]!=DBNull.Value)
currentAlert.alert_data =(string) reader["alert_data"]; 
if ((columns & Columns.expiration_time) == Columns.expiration_time && reader["expiration_time"]!=DBNull.Value)
currentAlert.expiration_time =(DateTime?) reader["expiration_time"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentAlert.atm_id = (int?) reader["atm_id"]; 
if (reader["alert_id"] != DBNull.Value)
currentAlert.alert_id = (int) reader["alert_id"]; 
if (reader["status"] != DBNull.Value)
currentAlert.status = (bool?) reader["status"]; 
if (reader["generated_at"] != DBNull.Value)
currentAlert.generated_at = (DateTime) reader["generated_at"]; 
if (reader["resolve_at"] != DBNull.Value)
currentAlert.resolve_at = (DateTime?) reader["resolve_at"]; 
if (reader["alert_type_id"] != DBNull.Value)
currentAlert.alert_type_id = (int) reader["alert_type_id"]; 
if (reader["source"] != DBNull.Value)
currentAlert.source = (string) reader["source"]; 
if (reader["ftp_file_info_id"] != DBNull.Value)
currentAlert.ftp_file_info_id = (int?) reader["ftp_file_info_id"]; 
if (reader["alert_data"] != DBNull.Value)
currentAlert.alert_data = (string) reader["alert_data"]; 
if (reader["expiration_time"] != DBNull.Value)
currentAlert.expiration_time = (DateTime?) reader["expiration_time"]; 
} 

currentAlert.isNewEntity = false;
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

public Alert CurrentAlert
{
get{ return currentAlert; }
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


#region Alert functions

public static AlertReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.alert_id == (Columns.alert_id & columns))
qry.Append("alert_id,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.resolve_at == (Columns.resolve_at & columns))
qry.Append("resolve_at,");
if (Columns.alert_type_id == (Columns.alert_type_id & columns))
qry.Append("alert_type_id,");
if (Columns.source == (Columns.source & columns))
qry.Append("source,");
if (Columns.ftp_file_info_id == (Columns.ftp_file_info_id & columns))
qry.Append("ftp_file_info_id,");
if (Columns.alert_data == (Columns.alert_data & columns))
qry.Append("alert_data,");
if (Columns.expiration_time == (Columns.expiration_time & columns))
qry.Append("expiration_time,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Alert ");

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
return new AlertReader(cmd.ExecuteReader(), conn, columns);
}

static public AlertReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AlertReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,alert_id,status,generated_at,resolve_at,alert_type_id,source,ftp_file_info_id,alert_data,expiration_time from Alert ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AlertReader(cmd.ExecuteReader(), conn);
}

static public AlertReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Alert LoadAlert(string where)
{
AlertReader reader = Alert.ExecuteReader(where);
Alert _alert = null;
if (reader.Read())
_alert = reader.CurrentAlert;
reader.Close();
return _alert;
}

public static Alert LoadAlert(string where, IDbConnection conn)
{
AlertReader reader = Alert.ExecuteReader(where, conn);
Alert _alert = null;
if (reader.Read())
_alert = reader.CurrentAlert;
reader.Close(false);
return _alert;
}

public static Alert LoadAlertByPk( int alert_id )
{
return LoadAlert( " alert_id="+alert_id );
}

public static Alert LoadAlertByPk( int alert_id , IDbConnection conn)
{
return LoadAlert(" alert_id="+alert_id , conn);
}

public void Save()
{
if (atm_idChanged || alert_idChanged || statusChanged || generated_atChanged || resolve_atChanged || alert_type_idChanged || sourceChanged || ftp_file_info_idChanged || alert_dataChanged || expiration_timeChanged )
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
if (atm_idChanged || alert_idChanged || statusChanged || generated_atChanged || resolve_atChanged || alert_type_idChanged || sourceChanged || ftp_file_info_idChanged || alert_dataChanged || expiration_timeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Alert( atm_id,alert_id,status,generated_at,resolve_at,alert_type_id,source,ftp_file_info_id,alert_data,expiration_time ) values(");
qry.Append(atm_idDbString+",");
lock (ConnectionFactory.connectionString) { this.alert_id = ConnectionFactory.GetNextId();
qry.Append(this.alert_id);
} qry.Append(",");
qry.Append(statusDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(resolve_atDbString+",");
qry.Append(alert_type_idDbString+",");
qry.Append(sourceDbString+",");
qry.Append(ftp_file_info_idDbString+",");
qry.Append(alert_dataDbString+",");
qry.Append(expiration_timeDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || alert_idChanged || statusChanged || generated_atChanged || resolve_atChanged || alert_type_idChanged || sourceChanged || ftp_file_info_idChanged || alert_dataChanged || expiration_timeChanged ))
return;
qry.Append("UPDATE Alert set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( resolve_atChanged )
{
qry.Append("resolve_at ="+resolve_atDbString);
qry.Append(",");
}

if ( alert_type_idChanged )
{
qry.Append("alert_type_id ="+alert_type_idDbString);
qry.Append(",");
}

if ( sourceChanged )
{
qry.Append("source ="+sourceDbString);
qry.Append(",");
}

if ( ftp_file_info_idChanged )
{
qry.Append("ftp_file_info_id ="+ftp_file_info_idDbString);
qry.Append(",");
}

if ( alert_dataChanged )
{
qry.Append("alert_data ="+alert_dataDbString);
qry.Append(",");
}

if ( expiration_timeChanged )
{
qry.Append("expiration_time ="+expiration_timeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("alert_id = "+alert_idDbString);
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
cmd.CommandText = "DELETE Alert where alert_id = "+ alert_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAlerts(string where)
{
ConnectionFactory.ExecuteQuery("delete Alert where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
alert_id= 2,
status= 4,
generated_at= 8,
resolve_at= 16,
alert_type_id= 32,
source= 64,
ftp_file_info_id= 128,
alert_data= 256,
expiration_time= 512
}
#endregion
public void BulkSave(List<Alert> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Alert";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Alert.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Alert> transList,ref DataTable dt)
{
foreach (Alert tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] = tran.AtmId;
Row["alert_id"] =ConnectionFactory.GetNextId();
Row["status"] = tran.Status;
Row["generated_at"] = tran.GeneratedAt;
Row["resolve_at"] = tran.ResolveAt;
Row["alert_type_id"] = tran.AlertTypeId;
Row["source"] = tran.Source;
Row["ftp_file_info_id"] = tran.FtpFileInfoId;
Row["alert_data"] = tran.AlertData;
Row["expiration_time"] = tran.ExpirationTime;
dt.Rows.Add(Row);
} }
}
}
