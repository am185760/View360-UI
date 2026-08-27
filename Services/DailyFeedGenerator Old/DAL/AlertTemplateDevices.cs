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
public class AlertTemplateDevices
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AlertTemplateDevices() { }
public AlertTemplateDevices( int device_id,int alert_template_id )
{
this.device_id = device_id;
this.device_idChanged = true;
this.alert_template_id = alert_template_id;
this.alert_template_idChanged = true;
}
private AlertTemplateDevices( int device_id,int alert_template_id,int alert_template_devices_id )
{
this.device_id = device_id;
this.device_idChanged = true;
this.alert_template_id = alert_template_id;
this.alert_template_idChanged = true;
this.alert_template_devices_id = alert_template_devices_id;
this.alert_template_devices_idChanged = true;
}

#region members and properties for columns

#region DeviceId
private bool device_idChanged = false;
private int device_id;
public int DeviceId
{
get { return device_id; }
set { 
device_id = value;
device_idChanged = true;
}
}
private string device_idDbString
{
get
{
return device_id.ToString();
}
}
#endregion
#region AlertTemplateId
private bool alert_template_idChanged = false;
private int alert_template_id;
public int AlertTemplateId
{
get { return alert_template_id; }
set { 
alert_template_id = value;
alert_template_idChanged = true;
}
}
private string alert_template_idDbString
{
get
{
return alert_template_id.ToString();
}
}
#endregion
#region AlertTemplateDevicesId
private bool alert_template_devices_idChanged = false;
private int alert_template_devices_id;
public int AlertTemplateDevicesId
{
get { return alert_template_devices_id; }
set { 
alert_template_devices_id = value;
alert_template_devices_idChanged = true;
}
}
private string alert_template_devices_idDbString
{
get
{
return alert_template_devices_id.ToString();
}
}
#endregion
#endregion

#region AlertTemplateDevicesReader
public class AlertTemplateDevicesReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AlertTemplateDevices currentAlertTemplateDevices;
Columns columns;
bool partialRead = false;
private AlertTemplateDevicesReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AlertTemplateDevicesReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AlertTemplateDevicesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAlertTemplateDevices; }

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
currentAlertTemplateDevices = new AlertTemplateDevices();
if (partialRead)
{ if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentAlertTemplateDevices.device_id =(int) reader["device_id"]; 
if ((columns & Columns.alert_template_id) == Columns.alert_template_id && reader["alert_template_id"]!=DBNull.Value)
currentAlertTemplateDevices.alert_template_id =(int) reader["alert_template_id"]; 
if ((columns & Columns.alert_template_devices_id) == Columns.alert_template_devices_id && reader["alert_template_devices_id"]!=DBNull.Value)
currentAlertTemplateDevices.alert_template_devices_id =(int) reader["alert_template_devices_id"]; 

} else
{
if (reader["device_id"] != DBNull.Value)
currentAlertTemplateDevices.device_id = (int) reader["device_id"]; 
if (reader["alert_template_id"] != DBNull.Value)
currentAlertTemplateDevices.alert_template_id = (int) reader["alert_template_id"]; 
if (reader["alert_template_devices_id"] != DBNull.Value)
currentAlertTemplateDevices.alert_template_devices_id = (int) reader["alert_template_devices_id"]; 
} 

currentAlertTemplateDevices.isNewEntity = false;
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

public AlertTemplateDevices CurrentAlertTemplateDevices
{
get{ return currentAlertTemplateDevices; }
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


#region AlertTemplateDevices functions

public static AlertTemplateDevicesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.alert_template_id == (Columns.alert_template_id & columns))
qry.Append("alert_template_id,");
if (Columns.alert_template_devices_id == (Columns.alert_template_devices_id & columns))
qry.Append("alert_template_devices_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Alert_template_devices ");

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
return new AlertTemplateDevicesReader(cmd.ExecuteReader(), conn, columns);
}

static public AlertTemplateDevicesReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AlertTemplateDevicesReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_id,alert_template_id,alert_template_devices_id from Alert_template_devices ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AlertTemplateDevicesReader(cmd.ExecuteReader(), conn);
}

static public AlertTemplateDevicesReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AlertTemplateDevices LoadAlertTemplateDevices(string where)
{
AlertTemplateDevicesReader reader = AlertTemplateDevices.ExecuteReader(where);
AlertTemplateDevices _alerttemplatedevices = null;
if (reader.Read())
_alerttemplatedevices = reader.CurrentAlertTemplateDevices;
reader.Close();
return _alerttemplatedevices;
}

public static AlertTemplateDevices LoadAlertTemplateDevices(string where, IDbConnection conn)
{
AlertTemplateDevicesReader reader = AlertTemplateDevices.ExecuteReader(where, conn);
AlertTemplateDevices _alerttemplatedevices = null;
if (reader.Read())
_alerttemplatedevices = reader.CurrentAlertTemplateDevices;
reader.Close(false);
return _alerttemplatedevices;
}

public static AlertTemplateDevices LoadAlertTemplateDevicesByPk( int alert_template_devices_id )
{
return LoadAlertTemplateDevices( " alert_template_devices_id="+alert_template_devices_id );
}

public static AlertTemplateDevices LoadAlertTemplateDevicesByPk( int alert_template_devices_id , IDbConnection conn)
{
return LoadAlertTemplateDevices(" alert_template_devices_id="+alert_template_devices_id , conn);
}

public void Save()
{
if (device_idChanged || alert_template_idChanged || alert_template_devices_idChanged )
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
if (device_idChanged || alert_template_idChanged || alert_template_devices_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Alert_template_devices( device_id,alert_template_id,alert_template_devices_id ) values(");
qry.Append(device_idDbString+",");
qry.Append(alert_template_idDbString+",");
lock (ConnectionFactory.connectionString) { this.alert_template_devices_id = ConnectionFactory.GetNextId();
qry.Append(this.alert_template_devices_id);
} qry.Append(");");

}
else
{
if (!(device_idChanged || alert_template_idChanged || alert_template_devices_idChanged ))
return;
qry.Append("UPDATE Alert_template_devices set "); if ( device_idChanged )
{
qry.Append("device_id ="+device_idDbString);
qry.Append(",");
}

if ( alert_template_idChanged )
{
qry.Append("alert_template_id ="+alert_template_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("alert_template_devices_id = "+alert_template_devices_idDbString);
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
cmd.CommandText = "DELETE Alert_template_devices where alert_template_devices_id = "+ alert_template_devices_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAlertTemplateDevicess(string where)
{
ConnectionFactory.ExecuteQuery("delete Alert_template_devices where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_id= 1,
alert_template_id= 2,
alert_template_devices_id= 4
}
#endregion
public void BulkSave(List<AlertTemplateDevices> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Alert_template_devices";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AlertTemplateDevices.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AlertTemplateDevices> transList,ref DataTable dt)
{
foreach (AlertTemplateDevices tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_id"] = tran.DeviceId;
Row["alert_template_id"] = tran.AlertTemplateId;
Row["alert_template_devices_id"] =ConnectionFactory.GetNextId();
dt.Rows.Add(Row);
} }
}
}
