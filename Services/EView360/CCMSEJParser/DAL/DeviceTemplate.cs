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
public class DeviceTemplate
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DeviceTemplate() { }
public DeviceTemplate( int device_template_id ) 
{
}
public DeviceTemplate( string device_template_name,string device_template_desc,bool? is_active )
{
this.device_template_name = device_template_name;
this.device_template_nameChanged = true;
this.device_template_desc = device_template_desc;
this.device_template_descChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}
private DeviceTemplate( int device_template_id,string device_template_name,string device_template_desc,bool? is_active )
{
this.device_template_id = device_template_id;
this.device_template_idChanged = true;
this.device_template_name = device_template_name;
this.device_template_nameChanged = true;
this.device_template_desc = device_template_desc;
this.device_template_descChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
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
#region DeviceTemplateName
private bool device_template_nameChanged = false;
private string device_template_name;
public string DeviceTemplateName
{
get { return device_template_name; }
set { 
device_template_name = value;
device_template_nameChanged = true;
}
}
private string device_template_nameDbString
{
get
{
if (this.device_template_name!=null)
return string.Format("'{0}'",device_template_name); else
return "null";
}
}
#endregion
#region DeviceTemplateDesc
private bool device_template_descChanged = false;
private string device_template_desc;
public string DeviceTemplateDesc
{
get { return device_template_desc; }
set { 
device_template_desc = value;
device_template_descChanged = true;
}
}
private string device_template_descDbString
{
get
{
if (this.device_template_desc!=null)
return string.Format("'{0}'",device_template_desc); else
return "null";
}
}
#endregion
#region IsActive
private bool is_activeChanged = false;
private bool? is_active;
public bool? IsActive
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
if (this.is_active.HasValue)
return is_active.Value?"1":"0";
else
return "null";
}
}
#endregion
#endregion

#region DeviceTemplateReader
public class DeviceTemplateReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DeviceTemplate currentDeviceTemplate;
Columns columns;
bool partialRead = false;
private DeviceTemplateReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DeviceTemplateReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DeviceTemplateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDeviceTemplate; }

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
currentDeviceTemplate = new DeviceTemplate();
if (partialRead)
{ if ((columns & Columns.device_template_id) == Columns.device_template_id && reader["device_template_id"]!=DBNull.Value)
currentDeviceTemplate.device_template_id =(int) reader["device_template_id"]; 
if ((columns & Columns.device_template_name) == Columns.device_template_name && reader["device_template_name"]!=DBNull.Value)
currentDeviceTemplate.device_template_name =(string) reader["device_template_name"]; 
if ((columns & Columns.device_template_desc) == Columns.device_template_desc && reader["device_template_desc"]!=DBNull.Value)
currentDeviceTemplate.device_template_desc =(string) reader["device_template_desc"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentDeviceTemplate.is_active =(bool?) reader["is_active"]; 

} else
{
if (reader["device_template_id"] != DBNull.Value)
currentDeviceTemplate.device_template_id = (int) reader["device_template_id"]; 
if (reader["device_template_name"] != DBNull.Value)
currentDeviceTemplate.device_template_name = (string) reader["device_template_name"]; 
if (reader["device_template_desc"] != DBNull.Value)
currentDeviceTemplate.device_template_desc = (string) reader["device_template_desc"]; 
if (reader["is_active"] != DBNull.Value)
currentDeviceTemplate.is_active = (bool?) reader["is_active"]; 
} 

currentDeviceTemplate.isNewEntity = false;
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

public DeviceTemplate CurrentDeviceTemplate
{
get{ return currentDeviceTemplate; }
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


#region DeviceTemplate functions

public static DeviceTemplateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_template_id == (Columns.device_template_id & columns))
qry.Append("device_template_id,");
if (Columns.device_template_name == (Columns.device_template_name & columns))
qry.Append("device_template_name,");
if (Columns.device_template_desc == (Columns.device_template_desc & columns))
qry.Append("device_template_desc,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Device_template ");

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
return new DeviceTemplateReader(cmd.ExecuteReader(), conn, columns);
}

static public DeviceTemplateReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DeviceTemplateReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_template_id,device_template_name,device_template_desc,is_active from Device_template ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DeviceTemplateReader(cmd.ExecuteReader(), conn);
}

static public DeviceTemplateReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DeviceTemplate LoadDeviceTemplate(string where)
{
DeviceTemplateReader reader = DeviceTemplate.ExecuteReader(where);
DeviceTemplate _devicetemplate = null;
if (reader.Read())
_devicetemplate = reader.CurrentDeviceTemplate;
reader.Close();
return _devicetemplate;
}

public static DeviceTemplate LoadDeviceTemplate(string where, IDbConnection conn)
{
DeviceTemplateReader reader = DeviceTemplate.ExecuteReader(where, conn);
DeviceTemplate _devicetemplate = null;
if (reader.Read())
_devicetemplate = reader.CurrentDeviceTemplate;
reader.Close(false);
return _devicetemplate;
}

public static DeviceTemplate LoadDeviceTemplateByPk( int device_template_id )
{
return LoadDeviceTemplate( " device_template_id="+device_template_id );
}

public static DeviceTemplate LoadDeviceTemplateByPk( int device_template_id , IDbConnection conn)
{
return LoadDeviceTemplate(" device_template_id="+device_template_id , conn);
}

public void Save()
{
if (device_template_idChanged || device_template_nameChanged || device_template_descChanged || is_activeChanged )
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
if (device_template_idChanged || device_template_nameChanged || device_template_descChanged || is_activeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Device_template( device_template_id,device_template_name,device_template_desc,is_active ) values(");
lock (ConnectionFactory.connectionString) { this.device_template_id = ConnectionFactory.GetNextId();
qry.Append(this.device_template_id);
} qry.Append(",");
qry.Append(device_template_nameDbString+",");
qry.Append(device_template_descDbString+",");
qry.Append(is_activeDbString);
qry.Append(");");

}
else
{
if (!(device_template_idChanged || device_template_nameChanged || device_template_descChanged || is_activeChanged ))
return;
qry.Append("UPDATE Device_template set "); if ( device_template_nameChanged )
{
qry.Append("device_template_name ="+device_template_nameDbString);
qry.Append(",");
}

if ( device_template_descChanged )
{
qry.Append("device_template_desc ="+device_template_descDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("device_template_id = "+device_template_idDbString);
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
cmd.CommandText = "DELETE Device_template where device_template_id = "+ device_template_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDeviceTemplates(string where)
{
ConnectionFactory.ExecuteQuery("delete Device_template where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_template_id= 1,
device_template_name= 2,
device_template_desc= 4,
is_active= 8
}
#endregion
public void BulkSave(List<DeviceTemplate> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Device_template";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DeviceTemplate.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DeviceTemplate> transList,ref DataTable dt)
{
foreach (DeviceTemplate tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_template_id"] =ConnectionFactory.GetNextId();
Row["device_template_name"] = tran.DeviceTemplateName;
Row["device_template_desc"] = tran.DeviceTemplateDesc;
Row["is_active"] = tran.IsActive;
dt.Rows.Add(Row);
} }
}
}
