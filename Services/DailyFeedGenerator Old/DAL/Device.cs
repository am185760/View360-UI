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
public class Device
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Device() { }
public Device( int device_id,string device_name,int device_number,int error_severity,bool is_active,bool is_abstract ) 
{
this.device_name = device_name;
this.device_nameChanged = true;
this.device_number = device_number;
this.device_numberChanged = true;
this.error_severity = error_severity;
this.error_severityChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.is_abstract = is_abstract;
this.is_abstractChanged = true;
}
public Device( string device_name,string oid,string device_internal_name,string device_friendly_name,int device_number,string vendor_name,int? module_number,string device_service_1,string device_service_2,string device_service_3,int error_severity,bool? is_replenishable,bool is_active,bool is_abstract )
{
this.device_name = device_name;
this.device_nameChanged = true;
this.oid = oid;
this.oidChanged = true;
this.device_internal_name = device_internal_name;
this.device_internal_nameChanged = true;
this.device_friendly_name = device_friendly_name;
this.device_friendly_nameChanged = true;
this.device_number = device_number;
this.device_numberChanged = true;
this.vendor_name = vendor_name;
this.vendor_nameChanged = true;
this.module_number = module_number;
this.module_numberChanged = true;
this.device_service_1 = device_service_1;
this.device_service_1Changed = true;
this.device_service_2 = device_service_2;
this.device_service_2Changed = true;
this.device_service_3 = device_service_3;
this.device_service_3Changed = true;
this.error_severity = error_severity;
this.error_severityChanged = true;
this.is_replenishable = is_replenishable;
this.is_replenishableChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.is_abstract = is_abstract;
this.is_abstractChanged = true;
}
private Device( int device_id,string device_name,string oid,string device_internal_name,string device_friendly_name,int device_number,string vendor_name,int? module_number,string device_service_1,string device_service_2,string device_service_3,int error_severity,bool? is_replenishable,bool is_active,bool is_abstract )
{
this.device_id = device_id;
this.device_idChanged = true;
this.device_name = device_name;
this.device_nameChanged = true;
this.oid = oid;
this.oidChanged = true;
this.device_internal_name = device_internal_name;
this.device_internal_nameChanged = true;
this.device_friendly_name = device_friendly_name;
this.device_friendly_nameChanged = true;
this.device_number = device_number;
this.device_numberChanged = true;
this.vendor_name = vendor_name;
this.vendor_nameChanged = true;
this.module_number = module_number;
this.module_numberChanged = true;
this.device_service_1 = device_service_1;
this.device_service_1Changed = true;
this.device_service_2 = device_service_2;
this.device_service_2Changed = true;
this.device_service_3 = device_service_3;
this.device_service_3Changed = true;
this.error_severity = error_severity;
this.error_severityChanged = true;
this.is_replenishable = is_replenishable;
this.is_replenishableChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.is_abstract = is_abstract;
this.is_abstractChanged = true;
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
#region DeviceName
private bool device_nameChanged = false;
private string device_name;
public string DeviceName
{
get { return device_name; }
set { 
device_name = value;
device_nameChanged = true;
}
}
private string device_nameDbString
{
get
{
if (this.device_name!=null)
return string.Format("'{0}'",device_name); else
return "null";
}
}
#endregion
#region Oid
private bool oidChanged = false;
private string oid;
public string Oid
{
get { return oid; }
set { 
oid = value;
oidChanged = true;
}
}
private string oidDbString
{
get
{
if (this.oid!=null)
return string.Format("'{0}'",oid); else
return "null";
}
}
#endregion
#region DeviceInternalName
private bool device_internal_nameChanged = false;
private string device_internal_name;
public string DeviceInternalName
{
get { return device_internal_name; }
set { 
device_internal_name = value;
device_internal_nameChanged = true;
}
}
private string device_internal_nameDbString
{
get
{
if (this.device_internal_name!=null)
return string.Format("'{0}'",device_internal_name); else
return "null";
}
}
#endregion
#region DeviceFriendlyName
private bool device_friendly_nameChanged = false;
private string device_friendly_name;
public string DeviceFriendlyName
{
get { return device_friendly_name; }
set { 
device_friendly_name = value;
device_friendly_nameChanged = true;
}
}
private string device_friendly_nameDbString
{
get
{
if (this.device_friendly_name!=null)
return string.Format("'{0}'",device_friendly_name); else
return "null";
}
}
#endregion
#region DeviceNumber
private bool device_numberChanged = false;
private int device_number;
public int DeviceNumber
{
get { return device_number; }
set { 
device_number = value;
device_numberChanged = true;
}
}
private string device_numberDbString
{
get
{
return device_number.ToString();
}
}
#endregion
#region VendorName
private bool vendor_nameChanged = false;
private string vendor_name;
public string VendorName
{
get { return vendor_name; }
set { 
vendor_name = value;
vendor_nameChanged = true;
}
}
private string vendor_nameDbString
{
get
{
if (this.vendor_name!=null)
return string.Format("'{0}'",vendor_name); else
return "null";
}
}
#endregion
#region ModuleNumber
private bool module_numberChanged = false;
private int? module_number;
public int? ModuleNumber
{
get { return module_number; }
set { 
module_number = value;
module_numberChanged = true;
}
}
private string module_numberDbString
{
get
{
if (this.module_number.HasValue)
return module_number.ToString();
else
return "null";
}
}
#endregion
#region DeviceService1
private bool device_service_1Changed = false;
private string device_service_1;
public string DeviceService1
{
get { return device_service_1; }
set { 
device_service_1 = value;
device_service_1Changed = true;
}
}
private string device_service_1DbString
{
get
{
if (this.device_service_1!=null)
return string.Format("'{0}'",device_service_1); else
return "null";
}
}
#endregion
#region DeviceService2
private bool device_service_2Changed = false;
private string device_service_2;
public string DeviceService2
{
get { return device_service_2; }
set { 
device_service_2 = value;
device_service_2Changed = true;
}
}
private string device_service_2DbString
{
get
{
if (this.device_service_2!=null)
return string.Format("'{0}'",device_service_2); else
return "null";
}
}
#endregion
#region DeviceService3
private bool device_service_3Changed = false;
private string device_service_3;
public string DeviceService3
{
get { return device_service_3; }
set { 
device_service_3 = value;
device_service_3Changed = true;
}
}
private string device_service_3DbString
{
get
{
if (this.device_service_3!=null)
return string.Format("'{0}'",device_service_3); else
return "null";
}
}
#endregion
#region ErrorSeverity
private bool error_severityChanged = false;
private int error_severity;
public int ErrorSeverity
{
get { return error_severity; }
set { 
error_severity = value;
error_severityChanged = true;
}
}
private string error_severityDbString
{
get
{
return error_severity.ToString();
}
}
#endregion
#region IsReplenishable
private bool is_replenishableChanged = false;
private bool? is_replenishable;
public bool? IsReplenishable
{
get { return is_replenishable; }
set { 
is_replenishable = value;
is_replenishableChanged = true;
}
}
private string is_replenishableDbString
{
get
{
if (this.is_replenishable.HasValue)
return is_replenishable.Value?"1":"0";
else
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
#region IsAbstract
private bool is_abstractChanged = false;
private bool is_abstract;
public bool IsAbstract
{
get { return is_abstract; }
set { 
is_abstract = value;
is_abstractChanged = true;
}
}
private string is_abstractDbString
{
get
{
return is_abstract?"1":"0";
}
}
#endregion
#endregion

#region DeviceReader
public class DeviceReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Device currentDevice;
Columns columns;
bool partialRead = false;
private DeviceReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DeviceReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DeviceReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDevice; }

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
currentDevice = new Device();
if (partialRead)
{ if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentDevice.device_id =(int) reader["device_id"]; 
if ((columns & Columns.device_name) == Columns.device_name && reader["device_name"]!=DBNull.Value)
currentDevice.device_name =(string) reader["device_name"]; 
if ((columns & Columns.oid) == Columns.oid && reader["oid"]!=DBNull.Value)
currentDevice.oid =(string) reader["oid"]; 
if ((columns & Columns.device_internal_name) == Columns.device_internal_name && reader["device_internal_name"]!=DBNull.Value)
currentDevice.device_internal_name =(string) reader["device_internal_name"]; 
if ((columns & Columns.device_friendly_name) == Columns.device_friendly_name && reader["device_friendly_name"]!=DBNull.Value)
currentDevice.device_friendly_name =(string) reader["device_friendly_name"]; 
if ((columns & Columns.device_number) == Columns.device_number && reader["device_number"]!=DBNull.Value)
currentDevice.device_number =(int) reader["device_number"]; 
if ((columns & Columns.vendor_name) == Columns.vendor_name && reader["vendor_name"]!=DBNull.Value)
currentDevice.vendor_name =(string) reader["vendor_name"]; 
if ((columns & Columns.module_number) == Columns.module_number && reader["module_number"]!=DBNull.Value)
currentDevice.module_number =(int?) reader["module_number"]; 
if ((columns & Columns.device_service_1) == Columns.device_service_1 && reader["device_service_1"]!=DBNull.Value)
currentDevice.device_service_1 =(string) reader["device_service_1"]; 
if ((columns & Columns.device_service_2) == Columns.device_service_2 && reader["device_service_2"]!=DBNull.Value)
currentDevice.device_service_2 =(string) reader["device_service_2"]; 
if ((columns & Columns.device_service_3) == Columns.device_service_3 && reader["device_service_3"]!=DBNull.Value)
currentDevice.device_service_3 =(string) reader["device_service_3"]; 
if ((columns & Columns.error_severity) == Columns.error_severity && reader["error_severity"]!=DBNull.Value)
currentDevice.error_severity =(int) reader["error_severity"]; 
if ((columns & Columns.is_replenishable) == Columns.is_replenishable && reader["is_replenishable"]!=DBNull.Value)
currentDevice.is_replenishable =(bool?) reader["is_replenishable"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentDevice.is_active =(bool) reader["is_active"]; 
if ((columns & Columns.is_abstract) == Columns.is_abstract && reader["is_abstract"]!=DBNull.Value)
currentDevice.is_abstract =(bool) reader["is_abstract"]; 

} else
{
if (reader["device_id"] != DBNull.Value)
currentDevice.device_id = (int) reader["device_id"]; 
if (reader["device_name"] != DBNull.Value)
currentDevice.device_name = (string) reader["device_name"]; 
if (reader["oid"] != DBNull.Value)
currentDevice.oid = (string) reader["oid"]; 
if (reader["device_internal_name"] != DBNull.Value)
currentDevice.device_internal_name = (string) reader["device_internal_name"]; 
if (reader["device_friendly_name"] != DBNull.Value)
currentDevice.device_friendly_name = (string) reader["device_friendly_name"]; 
if (reader["device_number"] != DBNull.Value)
currentDevice.device_number = (int) reader["device_number"]; 
if (reader["vendor_name"] != DBNull.Value)
currentDevice.vendor_name = (string) reader["vendor_name"]; 
if (reader["module_number"] != DBNull.Value)
currentDevice.module_number = (int?) reader["module_number"]; 
if (reader["device_service_1"] != DBNull.Value)
currentDevice.device_service_1 = (string) reader["device_service_1"]; 
if (reader["device_service_2"] != DBNull.Value)
currentDevice.device_service_2 = (string) reader["device_service_2"]; 
if (reader["device_service_3"] != DBNull.Value)
currentDevice.device_service_3 = (string) reader["device_service_3"]; 
if (reader["error_severity"] != DBNull.Value)
currentDevice.error_severity = (int) reader["error_severity"]; 
if (reader["is_replenishable"] != DBNull.Value)
currentDevice.is_replenishable = (bool?) reader["is_replenishable"]; 
if (reader["is_active"] != DBNull.Value)
currentDevice.is_active = (bool) reader["is_active"]; 
if (reader["is_abstract"] != DBNull.Value)
currentDevice.is_abstract = (bool) reader["is_abstract"]; 
} 

currentDevice.isNewEntity = false;
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

public Device CurrentDevice
{
get{ return currentDevice; }
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


#region Device functions

public static DeviceReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.device_name == (Columns.device_name & columns))
qry.Append("device_name,");
if (Columns.oid == (Columns.oid & columns))
qry.Append("oid,");
if (Columns.device_internal_name == (Columns.device_internal_name & columns))
qry.Append("device_internal_name,");
if (Columns.device_friendly_name == (Columns.device_friendly_name & columns))
qry.Append("device_friendly_name,");
if (Columns.device_number == (Columns.device_number & columns))
qry.Append("device_number,");
if (Columns.vendor_name == (Columns.vendor_name & columns))
qry.Append("vendor_name,");
if (Columns.module_number == (Columns.module_number & columns))
qry.Append("module_number,");
if (Columns.device_service_1 == (Columns.device_service_1 & columns))
qry.Append("device_service_1,");
if (Columns.device_service_2 == (Columns.device_service_2 & columns))
qry.Append("device_service_2,");
if (Columns.device_service_3 == (Columns.device_service_3 & columns))
qry.Append("device_service_3,");
if (Columns.error_severity == (Columns.error_severity & columns))
qry.Append("error_severity,");
if (Columns.is_replenishable == (Columns.is_replenishable & columns))
qry.Append("is_replenishable,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
if (Columns.is_abstract == (Columns.is_abstract & columns))
qry.Append("is_abstract,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Device ");

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
return new DeviceReader(cmd.ExecuteReader(), conn, columns);
}

static public DeviceReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DeviceReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_id,device_name,oid,device_internal_name,device_friendly_name,device_number,vendor_name,module_number,device_service_1,device_service_2,device_service_3,error_severity,is_replenishable,is_active,is_abstract from Device ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DeviceReader(cmd.ExecuteReader(), conn);
}

static public DeviceReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Device LoadDevice(string where)
{
DeviceReader reader = Device.ExecuteReader(where);
Device _device = null;
if (reader.Read())
_device = reader.CurrentDevice;
reader.Close();
return _device;
}

public static Device LoadDevice(string where, IDbConnection conn)
{
DeviceReader reader = Device.ExecuteReader(where, conn);
Device _device = null;
if (reader.Read())
_device = reader.CurrentDevice;
reader.Close(false);
return _device;
}

public static Device LoadDeviceByPk( int device_id )
{
return LoadDevice( " device_id="+device_id );
}

public static Device LoadDeviceByPk( int device_id , IDbConnection conn)
{
return LoadDevice(" device_id="+device_id , conn);
}

public void Save()
{
if (device_idChanged || device_nameChanged || oidChanged || device_internal_nameChanged || device_friendly_nameChanged || device_numberChanged || vendor_nameChanged || module_numberChanged || device_service_1Changed || device_service_2Changed || device_service_3Changed || error_severityChanged || is_replenishableChanged || is_activeChanged || is_abstractChanged )
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
if (device_idChanged || device_nameChanged || oidChanged || device_internal_nameChanged || device_friendly_nameChanged || device_numberChanged || vendor_nameChanged || module_numberChanged || device_service_1Changed || device_service_2Changed || device_service_3Changed || error_severityChanged || is_replenishableChanged || is_activeChanged || is_abstractChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Device( device_id,device_name,oid,device_internal_name,device_friendly_name,device_number,vendor_name,module_number,device_service_1,device_service_2,device_service_3,error_severity,is_replenishable,is_active,is_abstract ) values(");
lock (ConnectionFactory.connectionString) { this.device_id = ConnectionFactory.GetNextId();
qry.Append(this.device_id);
} qry.Append(",");
qry.Append(device_nameDbString+",");
qry.Append(oidDbString+",");
qry.Append(device_internal_nameDbString+",");
qry.Append(device_friendly_nameDbString+",");
qry.Append(device_numberDbString+",");
qry.Append(vendor_nameDbString+",");
qry.Append(module_numberDbString+",");
qry.Append(device_service_1DbString+",");
qry.Append(device_service_2DbString+",");
qry.Append(device_service_3DbString+",");
qry.Append(error_severityDbString+",");
qry.Append(is_replenishableDbString+",");
qry.Append(is_activeDbString+",");
qry.Append(is_abstractDbString);
qry.Append(");");

}
else
{
if (!(device_idChanged || device_nameChanged || oidChanged || device_internal_nameChanged || device_friendly_nameChanged || device_numberChanged || vendor_nameChanged || module_numberChanged || device_service_1Changed || device_service_2Changed || device_service_3Changed || error_severityChanged || is_replenishableChanged || is_activeChanged || is_abstractChanged ))
return;
qry.Append("UPDATE Device set "); if ( device_nameChanged )
{
qry.Append("device_name ="+device_nameDbString);
qry.Append(",");
}

if ( oidChanged )
{
qry.Append("oid ="+oidDbString);
qry.Append(",");
}

if ( device_internal_nameChanged )
{
qry.Append("device_internal_name ="+device_internal_nameDbString);
qry.Append(",");
}

if ( device_friendly_nameChanged )
{
qry.Append("device_friendly_name ="+device_friendly_nameDbString);
qry.Append(",");
}

if ( device_numberChanged )
{
qry.Append("device_number ="+device_numberDbString);
qry.Append(",");
}

if ( vendor_nameChanged )
{
qry.Append("vendor_name ="+vendor_nameDbString);
qry.Append(",");
}

if ( module_numberChanged )
{
qry.Append("module_number ="+module_numberDbString);
qry.Append(",");
}

if ( device_service_1Changed )
{
qry.Append("device_service_1 ="+device_service_1DbString);
qry.Append(",");
}

if ( device_service_2Changed )
{
qry.Append("device_service_2 ="+device_service_2DbString);
qry.Append(",");
}

if ( device_service_3Changed )
{
qry.Append("device_service_3 ="+device_service_3DbString);
qry.Append(",");
}

if ( error_severityChanged )
{
qry.Append("error_severity ="+error_severityDbString);
qry.Append(",");
}

if ( is_replenishableChanged )
{
qry.Append("is_replenishable ="+is_replenishableDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}

if ( is_abstractChanged )
{
qry.Append("is_abstract ="+is_abstractDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("device_id = "+device_idDbString);
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
cmd.CommandText = "DELETE Device where device_id = "+ device_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDevices(string where)
{
ConnectionFactory.ExecuteQuery("delete Device where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_id= 1,
device_name= 2,
oid= 4,
device_internal_name= 8,
device_friendly_name= 16,
device_number= 32,
vendor_name= 64,
module_number= 128,
device_service_1= 256,
device_service_2= 512,
device_service_3= 1024,
error_severity= 2048,
is_replenishable= 4096,
is_active= 8192,
is_abstract= 16384
}
#endregion
public void BulkSave(List<Device> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Device";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Device.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Device> transList,ref DataTable dt)
{
foreach (Device tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_id"] =ConnectionFactory.GetNextId();
Row["device_name"] = tran.DeviceName;
Row["oid"] = tran.Oid;
Row["device_internal_name"] = tran.DeviceInternalName;
Row["device_friendly_name"] = tran.DeviceFriendlyName;
Row["device_number"] = tran.DeviceNumber;
Row["vendor_name"] = tran.VendorName;
Row["module_number"] = tran.ModuleNumber;
Row["device_service_1"] = tran.DeviceService1;
Row["device_service_2"] = tran.DeviceService2;
Row["device_service_3"] = tran.DeviceService3;
Row["error_severity"] = tran.ErrorSeverity;
Row["is_replenishable"] = tran.IsReplenishable;
Row["is_active"] = tran.IsActive;
Row["is_abstract"] = tran.IsAbstract;
dt.Rows.Add(Row);
} }
}
}
