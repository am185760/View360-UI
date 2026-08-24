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
public class DeviceTemplateDevices
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DeviceTemplateDevices() { }
public DeviceTemplateDevices( int is_present )
{
this.is_present = is_present;
this.is_presentChanged = true;
}
private DeviceTemplateDevices( int device_template_id,int device_id,int is_present )
{
this.device_template_id = device_template_id;
this.device_template_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.is_present = is_present;
this.is_presentChanged = true;
}

#region members and properties for columns

#region DeviceTemplateId
private bool device_template_idChanged = false;
private int device_template_id;
public int DeviceTemplateId
{
get { return device_template_id; }
set { 
device_template_id = value;
device_template_idChanged = true;
}
}
private string device_template_idDbString
{
get
{
return device_template_id.ToString();
}
}
#endregion
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
#region IsPresent
private bool is_presentChanged = false;
private int is_present;
public int IsPresent
{
get { return is_present; }
set { 
is_present = value;
is_presentChanged = true;
}
}
private string is_presentDbString
{
get
{
return is_present.ToString();
}
}
#endregion
#endregion

#region DeviceTemplateDevicesReader
public class DeviceTemplateDevicesReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DeviceTemplateDevices currentDeviceTemplateDevices;
Columns columns;
bool partialRead = false;
private DeviceTemplateDevicesReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DeviceTemplateDevicesReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DeviceTemplateDevicesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDeviceTemplateDevices; }

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
currentDeviceTemplateDevices = new DeviceTemplateDevices();
if (partialRead)
{ if ((columns & Columns.device_template_id) == Columns.device_template_id && reader["device_template_id"]!=DBNull.Value)
currentDeviceTemplateDevices.device_template_id =(int) reader["device_template_id"]; 
if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentDeviceTemplateDevices.device_id =(int) reader["device_id"]; 
if ((columns & Columns.is_present) == Columns.is_present && reader["is_present"]!=DBNull.Value)
currentDeviceTemplateDevices.is_present =(int) reader["is_present"]; 

} else
{
if (reader["device_template_id"] != DBNull.Value)
currentDeviceTemplateDevices.device_template_id = (int) reader["device_template_id"]; 
if (reader["device_id"] != DBNull.Value)
currentDeviceTemplateDevices.device_id = (int) reader["device_id"]; 
if (reader["is_present"] != DBNull.Value)
currentDeviceTemplateDevices.is_present = (int) reader["is_present"]; 
} 

currentDeviceTemplateDevices.isNewEntity = false;
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

public DeviceTemplateDevices CurrentDeviceTemplateDevices
{
get{ return currentDeviceTemplateDevices; }
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


#region DeviceTemplateDevices functions

public static DeviceTemplateDevicesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_template_id == (Columns.device_template_id & columns))
qry.Append("device_template_id,");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.is_present == (Columns.is_present & columns))
qry.Append("is_present,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Device_template_devices ");

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
return new DeviceTemplateDevicesReader(cmd.ExecuteReader(), conn, columns);
}

static public DeviceTemplateDevicesReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DeviceTemplateDevicesReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_template_id,device_id,is_present from Device_template_devices ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DeviceTemplateDevicesReader(cmd.ExecuteReader(), conn);
}

static public DeviceTemplateDevicesReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DeviceTemplateDevices LoadDeviceTemplateDevices(string where)
{
DeviceTemplateDevicesReader reader = DeviceTemplateDevices.ExecuteReader(where);
DeviceTemplateDevices _devicetemplatedevices = null;
if (reader.Read())
_devicetemplatedevices = reader.CurrentDeviceTemplateDevices;
reader.Close();
return _devicetemplatedevices;
}

public static DeviceTemplateDevices LoadDeviceTemplateDevices(string where, IDbConnection conn)
{
DeviceTemplateDevicesReader reader = DeviceTemplateDevices.ExecuteReader(where, conn);
DeviceTemplateDevices _devicetemplatedevices = null;
if (reader.Read())
_devicetemplatedevices = reader.CurrentDeviceTemplateDevices;
reader.Close(false);
return _devicetemplatedevices;
}

public static DeviceTemplateDevices LoadDeviceTemplateDevicesByPk( int device_template_id,int device_id )
{
return LoadDeviceTemplateDevices( " device_template_id="+device_template_id+" and device_id="+device_id );
}

public static DeviceTemplateDevices LoadDeviceTemplateDevicesByPk( int device_template_id,int device_id , IDbConnection conn)
{
return LoadDeviceTemplateDevices(" device_template_id="+device_template_id+" and device_id="+device_id , conn);
}

public void Save()
{
if (device_template_idChanged || device_idChanged || is_presentChanged )
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
if (device_template_idChanged || device_idChanged || is_presentChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Device_template_devices( device_template_id,device_id,is_present ) values(");
lock (ConnectionFactory.connectionString) { this.device_template_id = ConnectionFactory.GetNextId();
qry.Append(this.device_template_id);
} qry.Append(",");
lock (ConnectionFactory.connectionString) { this.device_id = ConnectionFactory.GetNextId();
qry.Append(this.device_id);
} qry.Append(",");
qry.Append(is_presentDbString);
qry.Append(");");

}
else
{
if (!(device_template_idChanged || device_idChanged || is_presentChanged ))
return;
qry.Append("UPDATE Device_template_devices set "); if ( is_presentChanged )
{
qry.Append("is_present ="+is_presentDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("device_template_id = "+device_template_idDbString);
qry.Append(" and device_id = "+device_idDbString);
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
cmd.CommandText = "DELETE Device_template_devices where device_template_id = "+ device_template_id +" and device_id = "+ device_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDeviceTemplateDevicess(string where)
{
ConnectionFactory.ExecuteQuery("delete Device_template_devices where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_template_id= 1,
device_id= 2,
is_present= 4
}
#endregion
public void BulkSave(List<DeviceTemplateDevices> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Device_template_devices";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DeviceTemplateDevices.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DeviceTemplateDevices> transList,ref DataTable dt)
{
foreach (DeviceTemplateDevices tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_template_id"] =ConnectionFactory.GetNextId();
Row["device_id"] =ConnectionFactory.GetNextId();
Row["is_present"] = tran.IsPresent;
dt.Rows.Add(Row);
} }
}
}
