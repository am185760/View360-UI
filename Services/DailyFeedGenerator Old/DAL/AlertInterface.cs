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
public class AlertInterface
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AlertInterface() { }
public AlertInterface( int alert_interface_id,bool is_active,bool smtp_server_requires_login ) 
{
this.is_active = is_active;
this.is_activeChanged = true;
this.smtp_server_requires_login = smtp_server_requires_login;
this.smtp_server_requires_loginChanged = true;
}
public AlertInterface( string alert_interface_name,bool is_active,string smtp_server_ip,int? smtp_server_port,string smtp_user_id,string smtp_password,string smtp_sender_address,int? sms_max_retries,int? fax_max_retries,bool smtp_server_requires_login )
{
this.alert_interface_name = alert_interface_name;
this.alert_interface_nameChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.smtp_server_ip = smtp_server_ip;
this.smtp_server_ipChanged = true;
this.smtp_server_port = smtp_server_port;
this.smtp_server_portChanged = true;
this.smtp_user_id = smtp_user_id;
this.smtp_user_idChanged = true;
this.smtp_password = smtp_password;
this.smtp_passwordChanged = true;
this.smtp_sender_address = smtp_sender_address;
this.smtp_sender_addressChanged = true;
this.sms_max_retries = sms_max_retries;
this.sms_max_retriesChanged = true;
this.fax_max_retries = fax_max_retries;
this.fax_max_retriesChanged = true;
this.smtp_server_requires_login = smtp_server_requires_login;
this.smtp_server_requires_loginChanged = true;
}
private AlertInterface( int alert_interface_id,string alert_interface_name,bool is_active,string smtp_server_ip,int? smtp_server_port,string smtp_user_id,string smtp_password,string smtp_sender_address,int? sms_max_retries,int? fax_max_retries,bool smtp_server_requires_login )
{
this.alert_interface_id = alert_interface_id;
this.alert_interface_idChanged = true;
this.alert_interface_name = alert_interface_name;
this.alert_interface_nameChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.smtp_server_ip = smtp_server_ip;
this.smtp_server_ipChanged = true;
this.smtp_server_port = smtp_server_port;
this.smtp_server_portChanged = true;
this.smtp_user_id = smtp_user_id;
this.smtp_user_idChanged = true;
this.smtp_password = smtp_password;
this.smtp_passwordChanged = true;
this.smtp_sender_address = smtp_sender_address;
this.smtp_sender_addressChanged = true;
this.sms_max_retries = sms_max_retries;
this.sms_max_retriesChanged = true;
this.fax_max_retries = fax_max_retries;
this.fax_max_retriesChanged = true;
this.smtp_server_requires_login = smtp_server_requires_login;
this.smtp_server_requires_loginChanged = true;
}

#region members and properties for columns

#region AlertInterfaceId
private bool alert_interface_idChanged = false;
private int alert_interface_id;
public int AlertInterfaceId
{
get { return alert_interface_id; }
set { 
alert_interface_id = value;
alert_interface_idChanged = true;
}
}
private string alert_interface_idDbString
{
get
{
return alert_interface_id.ToString();
}
}
#endregion
#region AlertInterfaceName
private bool alert_interface_nameChanged = false;
private string alert_interface_name;
public string AlertInterfaceName
{
get { return alert_interface_name; }
set { 
alert_interface_name = value;
alert_interface_nameChanged = true;
}
}
private string alert_interface_nameDbString
{
get
{
if (this.alert_interface_name!=null)
return string.Format("'{0}'",alert_interface_name); else
return "null";
}
}
#endregion
#region IsActive
private bool is_activeChanged = false;
private bool is_active;
public bool IsActive
{
get { return is_active; }
set { 
is_active = value;
is_activeChanged = true;
}
}
private string is_activeDbString
{
get
{
return is_active?"1":"0";
}
}
#endregion
#region SmtpServerIp
private bool smtp_server_ipChanged = false;
private string smtp_server_ip;
public string SmtpServerIp
{
get { return smtp_server_ip; }
set { 
smtp_server_ip = value;
smtp_server_ipChanged = true;
}
}
private string smtp_server_ipDbString
{
get
{
if (this.smtp_server_ip!=null)
return string.Format("'{0}'",smtp_server_ip); else
return "null";
}
}
#endregion
#region SmtpServerPort
private bool smtp_server_portChanged = false;
private int? smtp_server_port;
public int? SmtpServerPort
{
get { return smtp_server_port; }
set { 
smtp_server_port = value;
smtp_server_portChanged = true;
}
}
private string smtp_server_portDbString
{
get
{
if (this.smtp_server_port.HasValue)
return smtp_server_port.ToString();
else
return "null";
}
}
#endregion
#region SmtpUserId
private bool smtp_user_idChanged = false;
private string smtp_user_id;
public string SmtpUserId
{
get { return smtp_user_id; }
set { 
smtp_user_id = value;
smtp_user_idChanged = true;
}
}
private string smtp_user_idDbString
{
get
{
if (this.smtp_user_id!=null)
return string.Format("'{0}'",smtp_user_id); else
return "null";
}
}
#endregion
#region SmtpPassword
private bool smtp_passwordChanged = false;
private string smtp_password;
public string SmtpPassword
{
get { return smtp_password; }
set { 
smtp_password = value;
smtp_passwordChanged = true;
}
}
private string smtp_passwordDbString
{
get
{
if (this.smtp_password!=null)
return string.Format("'{0}'",smtp_password); else
return "null";
}
}
#endregion
#region SmtpSenderAddress
private bool smtp_sender_addressChanged = false;
private string smtp_sender_address;
public string SmtpSenderAddress
{
get { return smtp_sender_address; }
set { 
smtp_sender_address = value;
smtp_sender_addressChanged = true;
}
}
private string smtp_sender_addressDbString
{
get
{
if (this.smtp_sender_address!=null)
return string.Format("'{0}'",smtp_sender_address); else
return "null";
}
}
#endregion
#region SmsMaxRetries
private bool sms_max_retriesChanged = false;
private int? sms_max_retries;
public int? SmsMaxRetries
{
get { return sms_max_retries; }
set { 
sms_max_retries = value;
sms_max_retriesChanged = true;
}
}
private string sms_max_retriesDbString
{
get
{
if (this.sms_max_retries.HasValue)
return sms_max_retries.ToString();
else
return "null";
}
}
#endregion
#region FaxMaxRetries
private bool fax_max_retriesChanged = false;
private int? fax_max_retries;
public int? FaxMaxRetries
{
get { return fax_max_retries; }
set { 
fax_max_retries = value;
fax_max_retriesChanged = true;
}
}
private string fax_max_retriesDbString
{
get
{
if (this.fax_max_retries.HasValue)
return fax_max_retries.ToString();
else
return "null";
}
}
#endregion
#region SmtpServerRequiresLogin
private bool smtp_server_requires_loginChanged = false;
private bool smtp_server_requires_login;
public bool SmtpServerRequiresLogin
{
get { return smtp_server_requires_login; }
set { 
smtp_server_requires_login = value;
smtp_server_requires_loginChanged = true;
}
}
private string smtp_server_requires_loginDbString
{
get
{
return smtp_server_requires_login?"1":"0";
}
}
#endregion
#endregion

#region AlertInterfaceReader
public class AlertInterfaceReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AlertInterface currentAlertInterface;
Columns columns;
bool partialRead = false;
private AlertInterfaceReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AlertInterfaceReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AlertInterfaceReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAlertInterface; }

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
currentAlertInterface = new AlertInterface();
if (partialRead)
{ if ((columns & Columns.alert_interface_id) == Columns.alert_interface_id && reader["alert_interface_id"]!=DBNull.Value)
currentAlertInterface.alert_interface_id =(int) reader["alert_interface_id"]; 
if ((columns & Columns.alert_interface_name) == Columns.alert_interface_name && reader["alert_interface_name"]!=DBNull.Value)
currentAlertInterface.alert_interface_name =(string) reader["alert_interface_name"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentAlertInterface.is_active =(bool) reader["is_active"]; 
if ((columns & Columns.smtp_server_ip) == Columns.smtp_server_ip && reader["smtp_server_ip"]!=DBNull.Value)
currentAlertInterface.smtp_server_ip =(string) reader["smtp_server_ip"]; 
if ((columns & Columns.smtp_server_port) == Columns.smtp_server_port && reader["smtp_server_port"]!=DBNull.Value)
currentAlertInterface.smtp_server_port =(int?) reader["smtp_server_port"]; 
if ((columns & Columns.smtp_user_id) == Columns.smtp_user_id && reader["smtp_user_id"]!=DBNull.Value)
currentAlertInterface.smtp_user_id =(string) reader["smtp_user_id"]; 
if ((columns & Columns.smtp_password) == Columns.smtp_password && reader["smtp_password"]!=DBNull.Value)
currentAlertInterface.smtp_password =(string) reader["smtp_password"]; 
if ((columns & Columns.smtp_sender_address) == Columns.smtp_sender_address && reader["smtp_sender_address"]!=DBNull.Value)
currentAlertInterface.smtp_sender_address =(string) reader["smtp_sender_address"]; 
if ((columns & Columns.sms_max_retries) == Columns.sms_max_retries && reader["sms_max_retries"]!=DBNull.Value)
currentAlertInterface.sms_max_retries =(int?) reader["sms_max_retries"]; 
if ((columns & Columns.fax_max_retries) == Columns.fax_max_retries && reader["fax_max_retries"]!=DBNull.Value)
currentAlertInterface.fax_max_retries =(int?) reader["fax_max_retries"]; 
if ((columns & Columns.smtp_server_requires_login) == Columns.smtp_server_requires_login && reader["smtp_server_requires_login"]!=DBNull.Value)
currentAlertInterface.smtp_server_requires_login =(bool) reader["smtp_server_requires_login"]; 

} else
{
if (reader["alert_interface_id"] != DBNull.Value)
currentAlertInterface.alert_interface_id = (int) reader["alert_interface_id"]; 
if (reader["alert_interface_name"] != DBNull.Value)
currentAlertInterface.alert_interface_name = (string) reader["alert_interface_name"]; 
if (reader["is_active"] != DBNull.Value)
currentAlertInterface.is_active = (bool) reader["is_active"]; 
if (reader["smtp_server_ip"] != DBNull.Value)
currentAlertInterface.smtp_server_ip = (string) reader["smtp_server_ip"]; 
if (reader["smtp_server_port"] != DBNull.Value)
currentAlertInterface.smtp_server_port = (int?) reader["smtp_server_port"]; 
if (reader["smtp_user_id"] != DBNull.Value)
currentAlertInterface.smtp_user_id = (string) reader["smtp_user_id"]; 
if (reader["smtp_password"] != DBNull.Value)
currentAlertInterface.smtp_password = (string) reader["smtp_password"]; 
if (reader["smtp_sender_address"] != DBNull.Value)
currentAlertInterface.smtp_sender_address = (string) reader["smtp_sender_address"]; 
if (reader["sms_max_retries"] != DBNull.Value)
currentAlertInterface.sms_max_retries = (int?) reader["sms_max_retries"]; 
if (reader["fax_max_retries"] != DBNull.Value)
currentAlertInterface.fax_max_retries = (int?) reader["fax_max_retries"]; 
if (reader["smtp_server_requires_login"] != DBNull.Value)
currentAlertInterface.smtp_server_requires_login = (bool) reader["smtp_server_requires_login"]; 
} 

currentAlertInterface.isNewEntity = false;
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

public AlertInterface CurrentAlertInterface
{
get{ return currentAlertInterface; }
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


#region AlertInterface functions

public static AlertInterfaceReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.alert_interface_id == (Columns.alert_interface_id & columns))
qry.Append("alert_interface_id,");
if (Columns.alert_interface_name == (Columns.alert_interface_name & columns))
qry.Append("alert_interface_name,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
if (Columns.smtp_server_ip == (Columns.smtp_server_ip & columns))
qry.Append("smtp_server_ip,");
if (Columns.smtp_server_port == (Columns.smtp_server_port & columns))
qry.Append("smtp_server_port,");
if (Columns.smtp_user_id == (Columns.smtp_user_id & columns))
qry.Append("smtp_user_id,");
if (Columns.smtp_password == (Columns.smtp_password & columns))
qry.Append("smtp_password,");
if (Columns.smtp_sender_address == (Columns.smtp_sender_address & columns))
qry.Append("smtp_sender_address,");
if (Columns.sms_max_retries == (Columns.sms_max_retries & columns))
qry.Append("sms_max_retries,");
if (Columns.fax_max_retries == (Columns.fax_max_retries & columns))
qry.Append("fax_max_retries,");
if (Columns.smtp_server_requires_login == (Columns.smtp_server_requires_login & columns))
qry.Append("smtp_server_requires_login,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Alert_interface ");

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
return new AlertInterfaceReader(cmd.ExecuteReader(), conn, columns);
}

static public AlertInterfaceReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AlertInterfaceReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select alert_interface_id,alert_interface_name,is_active,smtp_server_ip,smtp_server_port,smtp_user_id,smtp_password,smtp_sender_address,sms_max_retries,fax_max_retries,smtp_server_requires_login from Alert_interface ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AlertInterfaceReader(cmd.ExecuteReader(), conn);
}

static public AlertInterfaceReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AlertInterface LoadAlertInterface(string where)
{
AlertInterfaceReader reader = AlertInterface.ExecuteReader(where);
AlertInterface _alertinterface = null;
if (reader.Read())
_alertinterface = reader.CurrentAlertInterface;
reader.Close();
return _alertinterface;
}

public static AlertInterface LoadAlertInterface(string where, IDbConnection conn)
{
AlertInterfaceReader reader = AlertInterface.ExecuteReader(where, conn);
AlertInterface _alertinterface = null;
if (reader.Read())
_alertinterface = reader.CurrentAlertInterface;
reader.Close(false);
return _alertinterface;
}

public static AlertInterface LoadAlertInterfaceByPk( int alert_interface_id )
{
return LoadAlertInterface( " alert_interface_id="+alert_interface_id );
}

public static AlertInterface LoadAlertInterfaceByPk( int alert_interface_id , IDbConnection conn)
{
return LoadAlertInterface(" alert_interface_id="+alert_interface_id , conn);
}

public void Save()
{
if (alert_interface_idChanged || alert_interface_nameChanged || is_activeChanged || smtp_server_ipChanged || smtp_server_portChanged || smtp_user_idChanged || smtp_passwordChanged || smtp_sender_addressChanged || sms_max_retriesChanged || fax_max_retriesChanged || smtp_server_requires_loginChanged )
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
if (alert_interface_idChanged || alert_interface_nameChanged || is_activeChanged || smtp_server_ipChanged || smtp_server_portChanged || smtp_user_idChanged || smtp_passwordChanged || smtp_sender_addressChanged || sms_max_retriesChanged || fax_max_retriesChanged || smtp_server_requires_loginChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Alert_interface( alert_interface_id,alert_interface_name,is_active,smtp_server_ip,smtp_server_port,smtp_user_id,smtp_password,smtp_sender_address,sms_max_retries,fax_max_retries,smtp_server_requires_login ) values(");
lock (ConnectionFactory.connectionString) { this.alert_interface_id = ConnectionFactory.GetNextId();
qry.Append(this.alert_interface_id);
} qry.Append(",");
qry.Append(alert_interface_nameDbString+",");
qry.Append(is_activeDbString+",");
qry.Append(smtp_server_ipDbString+",");
qry.Append(smtp_server_portDbString+",");
qry.Append(smtp_user_idDbString+",");
qry.Append(smtp_passwordDbString+",");
qry.Append(smtp_sender_addressDbString+",");
qry.Append(sms_max_retriesDbString+",");
qry.Append(fax_max_retriesDbString+",");
qry.Append(smtp_server_requires_loginDbString);
qry.Append(");");

}
else
{
if (!(alert_interface_idChanged || alert_interface_nameChanged || is_activeChanged || smtp_server_ipChanged || smtp_server_portChanged || smtp_user_idChanged || smtp_passwordChanged || smtp_sender_addressChanged || sms_max_retriesChanged || fax_max_retriesChanged || smtp_server_requires_loginChanged ))
return;
qry.Append("UPDATE Alert_interface set "); if ( alert_interface_nameChanged )
{
qry.Append("alert_interface_name ="+alert_interface_nameDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}

if ( smtp_server_ipChanged )
{
qry.Append("smtp_server_ip ="+smtp_server_ipDbString);
qry.Append(",");
}

if ( smtp_server_portChanged )
{
qry.Append("smtp_server_port ="+smtp_server_portDbString);
qry.Append(",");
}

if ( smtp_user_idChanged )
{
qry.Append("smtp_user_id ="+smtp_user_idDbString);
qry.Append(",");
}

if ( smtp_passwordChanged )
{
qry.Append("smtp_password ="+smtp_passwordDbString);
qry.Append(",");
}

if ( smtp_sender_addressChanged )
{
qry.Append("smtp_sender_address ="+smtp_sender_addressDbString);
qry.Append(",");
}

if ( sms_max_retriesChanged )
{
qry.Append("sms_max_retries ="+sms_max_retriesDbString);
qry.Append(",");
}

if ( fax_max_retriesChanged )
{
qry.Append("fax_max_retries ="+fax_max_retriesDbString);
qry.Append(",");
}

if ( smtp_server_requires_loginChanged )
{
qry.Append("smtp_server_requires_login ="+smtp_server_requires_loginDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("alert_interface_id = "+alert_interface_idDbString);
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
cmd.CommandText = "DELETE Alert_interface where alert_interface_id = "+ alert_interface_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAlertInterfaces(string where)
{
ConnectionFactory.ExecuteQuery("delete Alert_interface where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
alert_interface_id= 1,
alert_interface_name= 2,
is_active= 4,
smtp_server_ip= 8,
smtp_server_port= 16,
smtp_user_id= 32,
smtp_password= 64,
smtp_sender_address= 128,
sms_max_retries= 256,
fax_max_retries= 512,
smtp_server_requires_login= 1024
}
#endregion
public void BulkSave(List<AlertInterface> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Alert_interface";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AlertInterface.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AlertInterface> transList,ref DataTable dt)
{
foreach (AlertInterface tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["alert_interface_id"] =ConnectionFactory.GetNextId();
Row["alert_interface_name"] = tran.AlertInterfaceName;
Row["is_active"] = tran.IsActive;
Row["smtp_server_ip"] = tran.SmtpServerIp;
Row["smtp_server_port"] = tran.SmtpServerPort;
Row["smtp_user_id"] = tran.SmtpUserId;
Row["smtp_password"] = tran.SmtpPassword;
Row["smtp_sender_address"] = tran.SmtpSenderAddress;
Row["sms_max_retries"] = tran.SmsMaxRetries;
Row["fax_max_retries"] = tran.FaxMaxRetries;
Row["smtp_server_requires_login"] = tran.SmtpServerRequiresLogin;
dt.Rows.Add(Row);
} }
}
}
