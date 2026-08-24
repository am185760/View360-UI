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
public class GroupDevices
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public GroupDevices() { }
public GroupDevices( int group_id,int device_id )
{
this.group_id = group_id;
this.group_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
}
private GroupDevices( int group_id,int device_id,int group_devices_id )
{
this.group_id = group_id;
this.group_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.group_devices_id = group_devices_id;
this.group_devices_idChanged = true;
}

#region members and properties for columns

#region GroupId
private bool group_idChanged = false;
private int group_id;
public int GroupId
{
get { return group_id; }
set { 
group_id = value;
group_idChanged = true;
}
}
private string group_idDbString
{
get
{
return group_id.ToString();
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
#region GroupDevicesId
private bool group_devices_idChanged = false;
private int group_devices_id;
public int GroupDevicesId
{
get { return group_devices_id; }
set { 
group_devices_id = value;
group_devices_idChanged = true;
}
}
private string group_devices_idDbString
{
get
{
return group_devices_id.ToString();
}
}
#endregion
#endregion

#region GroupDevicesReader
public class GroupDevicesReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
GroupDevices currentGroupDevices;
Columns columns;
bool partialRead = false;
private GroupDevicesReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public GroupDevicesReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public GroupDevicesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentGroupDevices; }

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
currentGroupDevices = new GroupDevices();
if (partialRead)
{ if ((columns & Columns.group_id) == Columns.group_id && reader["group_id"]!=DBNull.Value)
currentGroupDevices.group_id =(int) reader["group_id"]; 
if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentGroupDevices.device_id =(int) reader["device_id"]; 
if ((columns & Columns.group_devices_id) == Columns.group_devices_id && reader["group_devices_id"]!=DBNull.Value)
currentGroupDevices.group_devices_id =(int) reader["group_devices_id"]; 

} else
{
if (reader["group_id"] != DBNull.Value)
currentGroupDevices.group_id = (int) reader["group_id"]; 
if (reader["device_id"] != DBNull.Value)
currentGroupDevices.device_id = (int) reader["device_id"]; 
if (reader["group_devices_id"] != DBNull.Value)
currentGroupDevices.group_devices_id = (int) reader["group_devices_id"]; 
} 

currentGroupDevices.isNewEntity = false;
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

public GroupDevices CurrentGroupDevices
{
get{ return currentGroupDevices; }
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


#region GroupDevices functions

public static GroupDevicesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.group_id == (Columns.group_id & columns))
qry.Append("group_id,");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.group_devices_id == (Columns.group_devices_id & columns))
qry.Append("group_devices_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Group_devices ");

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
return new GroupDevicesReader(cmd.ExecuteReader(), conn, columns);
}

static public GroupDevicesReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static GroupDevicesReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select group_id,device_id,group_devices_id from Group_devices ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new GroupDevicesReader(cmd.ExecuteReader(), conn);
}

static public GroupDevicesReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static GroupDevices LoadGroupDevices(string where)
{
GroupDevicesReader reader = GroupDevices.ExecuteReader(where);
GroupDevices _groupdevices = null;
if (reader.Read())
_groupdevices = reader.CurrentGroupDevices;
reader.Close();
return _groupdevices;
}

public static GroupDevices LoadGroupDevices(string where, IDbConnection conn)
{
GroupDevicesReader reader = GroupDevices.ExecuteReader(where, conn);
GroupDevices _groupdevices = null;
if (reader.Read())
_groupdevices = reader.CurrentGroupDevices;
reader.Close(false);
return _groupdevices;
}

public static GroupDevices LoadGroupDevicesByPk( int group_devices_id )
{
return LoadGroupDevices( " group_devices_id="+group_devices_id );
}

public static GroupDevices LoadGroupDevicesByPk( int group_devices_id , IDbConnection conn)
{
return LoadGroupDevices(" group_devices_id="+group_devices_id , conn);
}

public void Save()
{
if (group_idChanged || device_idChanged || group_devices_idChanged )
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
if (group_idChanged || device_idChanged || group_devices_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Group_devices( group_id,device_id,group_devices_id ) values(");
qry.Append(group_idDbString+",");
qry.Append(device_idDbString+",");
lock (ConnectionFactory.connectionString) { this.group_devices_id = ConnectionFactory.GetNextId();
qry.Append(this.group_devices_id);
} qry.Append(");");

}
else
{
if (!(group_idChanged || device_idChanged || group_devices_idChanged ))
return;
qry.Append("UPDATE Group_devices set "); if ( group_idChanged )
{
qry.Append("group_id ="+group_idDbString);
qry.Append(",");
}

if ( device_idChanged )
{
qry.Append("device_id ="+device_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("group_devices_id = "+group_devices_idDbString);
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
cmd.CommandText = "DELETE Group_devices where group_devices_id = "+ group_devices_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteGroupDevicess(string where)
{
ConnectionFactory.ExecuteQuery("delete Group_devices where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
group_id= 1,
device_id= 2,
group_devices_id= 4
}
#endregion
public void BulkSave(List<GroupDevices> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Group_devices";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(GroupDevices.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <GroupDevices> transList,ref DataTable dt)
{
foreach (GroupDevices tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["group_id"] = tran.GroupId;
Row["device_id"] = tran.DeviceId;
Row["group_devices_id"] =ConnectionFactory.GetNextId();
dt.Rows.Add(Row);
} }
}
}
