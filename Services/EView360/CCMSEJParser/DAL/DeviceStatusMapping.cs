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
public class DeviceStatusMapping
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DeviceStatusMapping() { }
public DeviceStatusMapping( string device_name,string property_name,string property_value,int target_device_id,string target_status,byte issue_action,int severity_level_id ) 
{
this.device_name = device_name;
this.device_nameChanged = true;
this.property_name = property_name;
this.property_nameChanged = true;
this.property_value = property_value;
this.property_valueChanged = true;
this.target_device_id = target_device_id;
this.target_device_idChanged = true;
this.target_status = target_status;
this.target_statusChanged = true;
this.issue_action = issue_action;
this.issue_actionChanged = true;
this.severity_level_id = severity_level_id;
this.severity_level_idChanged = true;
}
public DeviceStatusMapping( string device_name,string property_name,string property_value,int target_device_id,string target_status,string target_status_desc,byte issue_action,int severity_level_id )
{
this.device_name = device_name;
this.device_nameChanged = true;
this.property_name = property_name;
this.property_nameChanged = true;
this.property_value = property_value;
this.property_valueChanged = true;
this.target_device_id = target_device_id;
this.target_device_idChanged = true;
this.target_status = target_status;
this.target_statusChanged = true;
this.target_status_desc = target_status_desc;
this.target_status_descChanged = true;
this.issue_action = issue_action;
this.issue_actionChanged = true;
this.severity_level_id = severity_level_id;
this.severity_level_idChanged = true;
}

#region members and properties for columns

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
#region PropertyName
private bool property_nameChanged = false;
private string property_name;
public string PropertyName
{
get { return property_name; }
set { 
property_name = value;
property_nameChanged = true;
}
}
private string property_nameDbString
{
get
{
if (this.property_name!=null)
return string.Format("'{0}'",property_name); else
return "null";
}
}
#endregion
#region PropertyValue
private bool property_valueChanged = false;
private string property_value;
public string PropertyValue
{
get { return property_value; }
set { 
property_value = value;
property_valueChanged = true;
}
}
private string property_valueDbString
{
get
{
if (this.property_value!=null)
return string.Format("'{0}'",property_value); else
return "null";
}
}
#endregion
#region TargetDeviceId
private bool target_device_idChanged = false;
private int target_device_id;
public int TargetDeviceId
{
get { return target_device_id; }
set { 
target_device_id = value;
target_device_idChanged = true;
}
}
private string target_device_idDbString
{
get
{
return target_device_id.ToString();
}
}
#endregion
#region TargetStatus
private bool target_statusChanged = false;
private string target_status;
public string TargetStatus
{
get { return target_status; }
set { 
target_status = value;
target_statusChanged = true;
}
}
private string target_statusDbString
{
get
{
if (this.target_status!=null)
return string.Format("'{0}'",target_status); else
return "null";
}
}
#endregion
#region TargetStatusDesc
private bool target_status_descChanged = false;
private string target_status_desc;
public string TargetStatusDesc
{
get { return target_status_desc; }
set { 
target_status_desc = value;
target_status_descChanged = true;
}
}
private string target_status_descDbString
{
get
{
if (this.target_status_desc!=null)
return string.Format("'{0}'",target_status_desc); else
return "null";
}
}
#endregion
#region IssueAction
private bool issue_actionChanged = false;
private byte issue_action;
public byte IssueAction
{
get { return issue_action; }
set { 
issue_action = value;
issue_actionChanged = true;
}
}
private string issue_actionDbString
{
get
{
return issue_action.ToString();
}
}
#endregion
#region SeverityLevelId
private bool severity_level_idChanged = false;
private int severity_level_id;
public int SeverityLevelId
{
get { return severity_level_id; }
set { 
severity_level_id = value;
severity_level_idChanged = true;
}
}
private string severity_level_idDbString
{
get
{
return severity_level_id.ToString();
}
}
#endregion
#endregion

#region DeviceStatusMappingReader
public class DeviceStatusMappingReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DeviceStatusMapping currentDeviceStatusMapping;
Columns columns;
bool partialRead = false;
private DeviceStatusMappingReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DeviceStatusMappingReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DeviceStatusMappingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDeviceStatusMapping; }

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
currentDeviceStatusMapping = new DeviceStatusMapping();
if (partialRead)
{ if ((columns & Columns.device_name) == Columns.device_name && reader["device_name"]!=DBNull.Value)
currentDeviceStatusMapping.device_name =(string) reader["device_name"]; 
if ((columns & Columns.property_name) == Columns.property_name && reader["property_name"]!=DBNull.Value)
currentDeviceStatusMapping.property_name =(string) reader["property_name"]; 
if ((columns & Columns.property_value) == Columns.property_value && reader["property_value"]!=DBNull.Value)
currentDeviceStatusMapping.property_value =(string) reader["property_value"]; 
if ((columns & Columns.target_device_id) == Columns.target_device_id && reader["target_device_id"]!=DBNull.Value)
currentDeviceStatusMapping.target_device_id =(int) reader["target_device_id"]; 
if ((columns & Columns.target_status) == Columns.target_status && reader["target_status"]!=DBNull.Value)
currentDeviceStatusMapping.target_status =(string) reader["target_status"]; 
if ((columns & Columns.target_status_desc) == Columns.target_status_desc && reader["target_status_desc"]!=DBNull.Value)
currentDeviceStatusMapping.target_status_desc =(string) reader["target_status_desc"]; 
if ((columns & Columns.issue_action) == Columns.issue_action && reader["issue_action"]!=DBNull.Value)
currentDeviceStatusMapping.issue_action =(byte) reader["issue_action"]; 
if ((columns & Columns.severity_level_id) == Columns.severity_level_id && reader["severity_level_id"]!=DBNull.Value)
currentDeviceStatusMapping.severity_level_id =(int) reader["severity_level_id"]; 

} else
{
if (reader["device_name"] != DBNull.Value)
currentDeviceStatusMapping.device_name = (string) reader["device_name"]; 
if (reader["property_name"] != DBNull.Value)
currentDeviceStatusMapping.property_name = (string) reader["property_name"]; 
if (reader["property_value"] != DBNull.Value)
currentDeviceStatusMapping.property_value = (string) reader["property_value"]; 
if (reader["target_device_id"] != DBNull.Value)
currentDeviceStatusMapping.target_device_id = (int) reader["target_device_id"]; 
if (reader["target_status"] != DBNull.Value)
currentDeviceStatusMapping.target_status = (string) reader["target_status"]; 
if (reader["target_status_desc"] != DBNull.Value)
currentDeviceStatusMapping.target_status_desc = (string) reader["target_status_desc"]; 
if (reader["issue_action"] != DBNull.Value)
currentDeviceStatusMapping.issue_action = (byte) reader["issue_action"]; 
if (reader["severity_level_id"] != DBNull.Value)
currentDeviceStatusMapping.severity_level_id = (int) reader["severity_level_id"]; 
} 

currentDeviceStatusMapping.isNewEntity = false;
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

public DeviceStatusMapping CurrentDeviceStatusMapping
{
get{ return currentDeviceStatusMapping; }
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


#region DeviceStatusMapping functions

public static DeviceStatusMappingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_name == (Columns.device_name & columns))
qry.Append("device_name,");
if (Columns.property_name == (Columns.property_name & columns))
qry.Append("property_name,");
if (Columns.property_value == (Columns.property_value & columns))
qry.Append("property_value,");
if (Columns.target_device_id == (Columns.target_device_id & columns))
qry.Append("target_device_id,");
if (Columns.target_status == (Columns.target_status & columns))
qry.Append("target_status,");
if (Columns.target_status_desc == (Columns.target_status_desc & columns))
qry.Append("target_status_desc,");
if (Columns.issue_action == (Columns.issue_action & columns))
qry.Append("issue_action,");
if (Columns.severity_level_id == (Columns.severity_level_id & columns))
qry.Append("severity_level_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Device_status_mapping ");

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
return new DeviceStatusMappingReader(cmd.ExecuteReader(), conn, columns);
}

static public DeviceStatusMappingReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DeviceStatusMappingReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_name,property_name,property_value,target_device_id,target_status,target_status_desc,issue_action,severity_level_id from Device_status_mapping ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DeviceStatusMappingReader(cmd.ExecuteReader(), conn);
}

static public DeviceStatusMappingReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DeviceStatusMapping LoadDeviceStatusMapping(string where)
{
DeviceStatusMappingReader reader = DeviceStatusMapping.ExecuteReader(where);
DeviceStatusMapping _devicestatusmapping = null;
if (reader.Read())
_devicestatusmapping = reader.CurrentDeviceStatusMapping;
reader.Close();
return _devicestatusmapping;
}

public static DeviceStatusMapping LoadDeviceStatusMapping(string where, IDbConnection conn)
{
DeviceStatusMappingReader reader = DeviceStatusMapping.ExecuteReader(where, conn);
DeviceStatusMapping _devicestatusmapping = null;
if (reader.Read())
_devicestatusmapping = reader.CurrentDeviceStatusMapping;
reader.Close(false);
return _devicestatusmapping;
}


public void Save()
{
if (device_nameChanged || property_nameChanged || property_valueChanged || target_device_idChanged || target_statusChanged || target_status_descChanged || issue_actionChanged || severity_level_idChanged )
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
if (device_nameChanged || property_nameChanged || property_valueChanged || target_device_idChanged || target_statusChanged || target_status_descChanged || issue_actionChanged || severity_level_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Device_status_mapping( device_name,property_name,property_value,target_device_id,target_status,target_status_desc,issue_action,severity_level_id ) values(");
qry.Append(device_nameDbString+",");
qry.Append(property_nameDbString+",");
qry.Append(property_valueDbString+",");
qry.Append(target_device_idDbString+",");
qry.Append(target_statusDbString+",");
qry.Append(target_status_descDbString+",");
qry.Append(issue_actionDbString+",");
qry.Append(severity_level_idDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Device_status_mapping!");
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

public static void DeleteDeviceStatusMappings(string where)
{
ConnectionFactory.ExecuteQuery("delete Device_status_mapping where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_name= 1,
property_name= 2,
property_value= 4,
target_device_id= 8,
target_status= 16,
target_status_desc= 32,
issue_action= 64,
severity_level_id= 128
}
#endregion
public void BulkSave(List<DeviceStatusMapping> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Device_status_mapping";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DeviceStatusMapping.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DeviceStatusMapping> transList,ref DataTable dt)
{
foreach (DeviceStatusMapping tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_name"] = tran.DeviceName;
Row["property_name"] = tran.PropertyName;
Row["property_value"] = tran.PropertyValue;
Row["target_device_id"] = tran.TargetDeviceId;
Row["target_status"] = tran.TargetStatus;
Row["target_status_desc"] = tran.TargetStatusDesc;
Row["issue_action"] = tran.IssueAction;
Row["severity_level_id"] = tran.SeverityLevelId;
dt.Rows.Add(Row);
} }
}
}
