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
public class DeviceTallyMapping
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DeviceTallyMapping() { }
public DeviceTallyMapping( string device_name,string property_name,int target_tally_id,byte tally_type )
{
this.device_name = device_name;
this.device_nameChanged = true;
this.property_name = property_name;
this.property_nameChanged = true;
this.target_tally_id = target_tally_id;
this.target_tally_idChanged = true;
this.tally_type = tally_type;
this.tally_typeChanged = true;
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
#region TargetTallyId
private bool target_tally_idChanged = false;
private int target_tally_id;
public int TargetTallyId
{
get { return target_tally_id; }
set { 
target_tally_id = value;
target_tally_idChanged = true;
}
}
private string target_tally_idDbString
{
get
{
return target_tally_id.ToString();
}
}
#endregion
#region TallyType
private bool tally_typeChanged = false;
private byte tally_type;
public byte TallyType
{
get { return tally_type; }
set { 
tally_type = value;
tally_typeChanged = true;
}
}
private string tally_typeDbString
{
get
{
return tally_type.ToString();
}
}
#endregion
#endregion

#region DeviceTallyMappingReader
public class DeviceTallyMappingReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DeviceTallyMapping currentDeviceTallyMapping;
Columns columns;
bool partialRead = false;
private DeviceTallyMappingReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DeviceTallyMappingReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DeviceTallyMappingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDeviceTallyMapping; }

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
currentDeviceTallyMapping = new DeviceTallyMapping();
if (partialRead)
{ if ((columns & Columns.device_name) == Columns.device_name && reader["device_name"]!=DBNull.Value)
currentDeviceTallyMapping.device_name =(string) reader["device_name"]; 
if ((columns & Columns.property_name) == Columns.property_name && reader["property_name"]!=DBNull.Value)
currentDeviceTallyMapping.property_name =(string) reader["property_name"]; 
if ((columns & Columns.target_tally_id) == Columns.target_tally_id && reader["target_tally_id"]!=DBNull.Value)
currentDeviceTallyMapping.target_tally_id =(int) reader["target_tally_id"]; 
if ((columns & Columns.tally_type) == Columns.tally_type && reader["tally_type"]!=DBNull.Value)
currentDeviceTallyMapping.tally_type =(byte) reader["tally_type"]; 

} else
{
if (reader["device_name"] != DBNull.Value)
currentDeviceTallyMapping.device_name = (string) reader["device_name"]; 
if (reader["property_name"] != DBNull.Value)
currentDeviceTallyMapping.property_name = (string) reader["property_name"]; 
if (reader["target_tally_id"] != DBNull.Value)
currentDeviceTallyMapping.target_tally_id = (int) reader["target_tally_id"]; 
if (reader["tally_type"] != DBNull.Value)
currentDeviceTallyMapping.tally_type = (byte) reader["tally_type"]; 
} 

currentDeviceTallyMapping.isNewEntity = false;
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

public DeviceTallyMapping CurrentDeviceTallyMapping
{
get{ return currentDeviceTallyMapping; }
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


#region DeviceTallyMapping functions

public static DeviceTallyMappingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_name == (Columns.device_name & columns))
qry.Append("device_name,");
if (Columns.property_name == (Columns.property_name & columns))
qry.Append("property_name,");
if (Columns.target_tally_id == (Columns.target_tally_id & columns))
qry.Append("target_tally_id,");
if (Columns.tally_type == (Columns.tally_type & columns))
qry.Append("tally_type,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Device_tally_mapping ");

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
return new DeviceTallyMappingReader(cmd.ExecuteReader(), conn, columns);
}

static public DeviceTallyMappingReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DeviceTallyMappingReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_name,property_name,target_tally_id,tally_type from Device_tally_mapping ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DeviceTallyMappingReader(cmd.ExecuteReader(), conn);
}

static public DeviceTallyMappingReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DeviceTallyMapping LoadDeviceTallyMapping(string where)
{
DeviceTallyMappingReader reader = DeviceTallyMapping.ExecuteReader(where);
DeviceTallyMapping _devicetallymapping = null;
if (reader.Read())
_devicetallymapping = reader.CurrentDeviceTallyMapping;
reader.Close();
return _devicetallymapping;
}

public static DeviceTallyMapping LoadDeviceTallyMapping(string where, IDbConnection conn)
{
DeviceTallyMappingReader reader = DeviceTallyMapping.ExecuteReader(where, conn);
DeviceTallyMapping _devicetallymapping = null;
if (reader.Read())
_devicetallymapping = reader.CurrentDeviceTallyMapping;
reader.Close(false);
return _devicetallymapping;
}


public void Save()
{
if (device_nameChanged || property_nameChanged || target_tally_idChanged || tally_typeChanged )
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
if (device_nameChanged || property_nameChanged || target_tally_idChanged || tally_typeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Device_tally_mapping( device_name,property_name,target_tally_id,tally_type ) values(");
qry.Append(device_nameDbString+",");
qry.Append(property_nameDbString+",");
qry.Append(target_tally_idDbString+",");
qry.Append(tally_typeDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Device_tally_mapping!");
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

public static void DeleteDeviceTallyMappings(string where)
{
ConnectionFactory.ExecuteQuery("delete Device_tally_mapping where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_name= 1,
property_name= 2,
target_tally_id= 4,
tally_type= 8
}
#endregion
public void BulkSave(List<DeviceTallyMapping> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Device_tally_mapping";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DeviceTallyMapping.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DeviceTallyMapping> transList,ref DataTable dt)
{
foreach (DeviceTallyMapping tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_name"] = tran.DeviceName;
Row["property_name"] = tran.PropertyName;
Row["target_tally_id"] = tran.TargetTallyId;
Row["tally_type"] = tran.TallyType;
dt.Rows.Add(Row);
} }
}
}
