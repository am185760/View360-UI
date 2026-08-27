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
public class DeviceCurrentmodeMapping
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DeviceCurrentmodeMapping() { }
public DeviceCurrentmodeMapping( string device_name,string property_name,string property_value,string current_mode,byte priority,byte issue_action,int severity_level_id )
{
this.device_name = device_name;
this.device_nameChanged = true;
this.property_name = property_name;
this.property_nameChanged = true;
this.property_value = property_value;
this.property_valueChanged = true;
this.current_mode = current_mode;
this.current_modeChanged = true;
this.priority = priority;
this.priorityChanged = true;
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
#region CurrentMode
private bool current_modeChanged = false;
private string current_mode;
public string CurrentMode
{
get { return current_mode; }
set { 
current_mode = value;
current_modeChanged = true;
}
}
private string current_modeDbString
{
get
{
if (this.current_mode!=null)
return string.Format("'{0}'",current_mode); else
return "null";
}
}
#endregion
#region Priority
private bool priorityChanged = false;
private byte priority;
public byte Priority
{
get { return priority; }
set { 
priority = value;
priorityChanged = true;
}
}
private string priorityDbString
{
get
{
return priority.ToString();
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

#region DeviceCurrentmodeMappingReader
public class DeviceCurrentmodeMappingReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DeviceCurrentmodeMapping currentDeviceCurrentmodeMapping;
Columns columns;
bool partialRead = false;
private DeviceCurrentmodeMappingReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DeviceCurrentmodeMappingReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DeviceCurrentmodeMappingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDeviceCurrentmodeMapping; }

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
currentDeviceCurrentmodeMapping = new DeviceCurrentmodeMapping();
if (partialRead)
{ if ((columns & Columns.device_name) == Columns.device_name && reader["device_name"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.device_name =(string) reader["device_name"]; 
if ((columns & Columns.property_name) == Columns.property_name && reader["property_name"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.property_name =(string) reader["property_name"]; 
if ((columns & Columns.property_value) == Columns.property_value && reader["property_value"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.property_value =(string) reader["property_value"]; 
if ((columns & Columns.current_mode) == Columns.current_mode && reader["current_mode"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.current_mode =(string) reader["current_mode"]; 
if ((columns & Columns.priority) == Columns.priority && reader["priority"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.priority =(byte) reader["priority"]; 
if ((columns & Columns.issue_action) == Columns.issue_action && reader["issue_action"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.issue_action =(byte) reader["issue_action"]; 
if ((columns & Columns.severity_level_id) == Columns.severity_level_id && reader["severity_level_id"]!=DBNull.Value)
currentDeviceCurrentmodeMapping.severity_level_id =(int) reader["severity_level_id"]; 

} else
{
if (reader["device_name"] != DBNull.Value)
currentDeviceCurrentmodeMapping.device_name = (string) reader["device_name"]; 
if (reader["property_name"] != DBNull.Value)
currentDeviceCurrentmodeMapping.property_name = (string) reader["property_name"]; 
if (reader["property_value"] != DBNull.Value)
currentDeviceCurrentmodeMapping.property_value = (string) reader["property_value"]; 
if (reader["current_mode"] != DBNull.Value)
currentDeviceCurrentmodeMapping.current_mode = (string) reader["current_mode"]; 
if (reader["priority"] != DBNull.Value)
currentDeviceCurrentmodeMapping.priority = (byte) reader["priority"]; 
if (reader["issue_action"] != DBNull.Value)
currentDeviceCurrentmodeMapping.issue_action = (byte) reader["issue_action"]; 
if (reader["severity_level_id"] != DBNull.Value)
currentDeviceCurrentmodeMapping.severity_level_id = (int) reader["severity_level_id"]; 
} 

currentDeviceCurrentmodeMapping.isNewEntity = false;
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

public DeviceCurrentmodeMapping CurrentDeviceCurrentmodeMapping
{
get{ return currentDeviceCurrentmodeMapping; }
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


#region DeviceCurrentmodeMapping functions

public static DeviceCurrentmodeMappingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_name == (Columns.device_name & columns))
qry.Append("device_name,");
if (Columns.property_name == (Columns.property_name & columns))
qry.Append("property_name,");
if (Columns.property_value == (Columns.property_value & columns))
qry.Append("property_value,");
if (Columns.current_mode == (Columns.current_mode & columns))
qry.Append("current_mode,");
if (Columns.priority == (Columns.priority & columns))
qry.Append("priority,");
if (Columns.issue_action == (Columns.issue_action & columns))
qry.Append("issue_action,");
if (Columns.severity_level_id == (Columns.severity_level_id & columns))
qry.Append("severity_level_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Device_currentmode_mapping ");

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
return new DeviceCurrentmodeMappingReader(cmd.ExecuteReader(), conn, columns);
}

static public DeviceCurrentmodeMappingReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DeviceCurrentmodeMappingReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_name,property_name,property_value,current_mode,priority,issue_action,severity_level_id from Device_currentmode_mapping ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DeviceCurrentmodeMappingReader(cmd.ExecuteReader(), conn);
}

static public DeviceCurrentmodeMappingReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DeviceCurrentmodeMapping LoadDeviceCurrentmodeMapping(string where)
{
DeviceCurrentmodeMappingReader reader = DeviceCurrentmodeMapping.ExecuteReader(where);
DeviceCurrentmodeMapping _devicecurrentmodemapping = null;
if (reader.Read())
_devicecurrentmodemapping = reader.CurrentDeviceCurrentmodeMapping;
reader.Close();
return _devicecurrentmodemapping;
}

public static DeviceCurrentmodeMapping LoadDeviceCurrentmodeMapping(string where, IDbConnection conn)
{
DeviceCurrentmodeMappingReader reader = DeviceCurrentmodeMapping.ExecuteReader(where, conn);
DeviceCurrentmodeMapping _devicecurrentmodemapping = null;
if (reader.Read())
_devicecurrentmodemapping = reader.CurrentDeviceCurrentmodeMapping;
reader.Close(false);
return _devicecurrentmodemapping;
}


public void Save()
{
if (device_nameChanged || property_nameChanged || property_valueChanged || current_modeChanged || priorityChanged || issue_actionChanged || severity_level_idChanged )
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
if (device_nameChanged || property_nameChanged || property_valueChanged || current_modeChanged || priorityChanged || issue_actionChanged || severity_level_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Device_currentmode_mapping( device_name,property_name,property_value,current_mode,priority,issue_action,severity_level_id ) values(");
qry.Append(device_nameDbString+",");
qry.Append(property_nameDbString+",");
qry.Append(property_valueDbString+",");
qry.Append(current_modeDbString+",");
qry.Append(priorityDbString+",");
qry.Append(issue_actionDbString+",");
qry.Append(severity_level_idDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Device_currentmode_mapping!");
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

public static void DeleteDeviceCurrentmodeMappings(string where)
{
ConnectionFactory.ExecuteQuery("delete Device_currentmode_mapping where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_name= 1,
property_name= 2,
property_value= 4,
current_mode= 8,
priority= 16,
issue_action= 32,
severity_level_id= 64
}
#endregion
public void BulkSave(List<DeviceCurrentmodeMapping> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Device_currentmode_mapping";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DeviceCurrentmodeMapping.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DeviceCurrentmodeMapping> transList,ref DataTable dt)
{
foreach (DeviceCurrentmodeMapping tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_name"] = tran.DeviceName;
Row["property_name"] = tran.PropertyName;
Row["property_value"] = tran.PropertyValue;
Row["current_mode"] = tran.CurrentMode;
Row["priority"] = tran.Priority;
Row["issue_action"] = tran.IssueAction;
Row["severity_level_id"] = tran.SeverityLevelId;
dt.Rows.Add(Row);
} }
}
}
