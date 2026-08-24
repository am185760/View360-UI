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
public class SensorOidMapping
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SensorOidMapping() { }
public SensorOidMapping( int sensor_oid_mapping_id ) 
{
}
public SensorOidMapping( string oid,string name )
{
this.oid = oid;
this.oidChanged = true;
this.name = name;
this.nameChanged = true;
}
private SensorOidMapping( int sensor_oid_mapping_id,string oid,string name )
{
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
this.oid = oid;
this.oidChanged = true;
this.name = name;
this.nameChanged = true;
}

#region members and properties for columns

#region SensorOidMappingId
private bool sensor_oid_mapping_idChanged = false;
private int sensor_oid_mapping_id;
public int SensorOidMappingId
{
get { return sensor_oid_mapping_id; }
set { 
sensor_oid_mapping_id = value;
sensor_oid_mapping_idChanged = true;
}
}
private string sensor_oid_mapping_idDbString
{
get
{
return sensor_oid_mapping_id.ToString();
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
#region Name
private bool nameChanged = false;
private string name;
public string Name
{
get { return name; }
set { 
name = value;
nameChanged = true;
}
}
private string nameDbString
{
get
{
if (this.name!=null)
return string.Format("'{0}'",name); else
return "null";
}
}
#endregion
#endregion

#region SensorOidMappingReader
public class SensorOidMappingReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SensorOidMapping currentSensorOidMapping;
Columns columns;
bool partialRead = false;
private SensorOidMappingReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SensorOidMappingReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SensorOidMappingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSensorOidMapping; }

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
currentSensorOidMapping = new SensorOidMapping();
if (partialRead)
{ if ((columns & Columns.sensor_oid_mapping_id) == Columns.sensor_oid_mapping_id && reader["sensor_oid_mapping_id"]!=DBNull.Value)
currentSensorOidMapping.sensor_oid_mapping_id =(int) reader["sensor_oid_mapping_id"]; 
if ((columns & Columns.oid) == Columns.oid && reader["oid"]!=DBNull.Value)
currentSensorOidMapping.oid =(string) reader["oid"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentSensorOidMapping.name =(string) reader["name"]; 

} else
{
if (reader["sensor_oid_mapping_id"] != DBNull.Value)
currentSensorOidMapping.sensor_oid_mapping_id = (int) reader["sensor_oid_mapping_id"]; 
if (reader["oid"] != DBNull.Value)
currentSensorOidMapping.oid = (string) reader["oid"]; 
if (reader["name"] != DBNull.Value)
currentSensorOidMapping.name = (string) reader["name"]; 
} 

currentSensorOidMapping.isNewEntity = false;
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

public SensorOidMapping CurrentSensorOidMapping
{
get{ return currentSensorOidMapping; }
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


#region SensorOidMapping functions

public static SensorOidMappingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.sensor_oid_mapping_id == (Columns.sensor_oid_mapping_id & columns))
qry.Append("sensor_oid_mapping_id,");
if (Columns.oid == (Columns.oid & columns))
qry.Append("oid,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Sensor_oid_mapping ");

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
return new SensorOidMappingReader(cmd.ExecuteReader(), conn, columns);
}

static public SensorOidMappingReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SensorOidMappingReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select sensor_oid_mapping_id,oid,name from Sensor_oid_mapping ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SensorOidMappingReader(cmd.ExecuteReader(), conn);
}

static public SensorOidMappingReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SensorOidMapping LoadSensorOidMapping(string where)
{
SensorOidMappingReader reader = SensorOidMapping.ExecuteReader(where);
SensorOidMapping _sensoroidmapping = null;
if (reader.Read())
_sensoroidmapping = reader.CurrentSensorOidMapping;
reader.Close();
return _sensoroidmapping;
}

public static SensorOidMapping LoadSensorOidMapping(string where, IDbConnection conn)
{
SensorOidMappingReader reader = SensorOidMapping.ExecuteReader(where, conn);
SensorOidMapping _sensoroidmapping = null;
if (reader.Read())
_sensoroidmapping = reader.CurrentSensorOidMapping;
reader.Close(false);
return _sensoroidmapping;
}

public static SensorOidMapping LoadSensorOidMappingByPk( int sensor_oid_mapping_id )
{
return LoadSensorOidMapping( " sensor_oid_mapping_id="+sensor_oid_mapping_id );
}

public static SensorOidMapping LoadSensorOidMappingByPk( int sensor_oid_mapping_id , IDbConnection conn)
{
return LoadSensorOidMapping(" sensor_oid_mapping_id="+sensor_oid_mapping_id , conn);
}

public void Save()
{
if (sensor_oid_mapping_idChanged || oidChanged || nameChanged )
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
if (sensor_oid_mapping_idChanged || oidChanged || nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Sensor_oid_mapping( sensor_oid_mapping_id,oid,name ) values(");
lock (ConnectionFactory.connectionString) { this.sensor_oid_mapping_id = ConnectionFactory.GetNextId();
qry.Append(this.sensor_oid_mapping_id);
} qry.Append(",");
qry.Append(oidDbString+",");
qry.Append(nameDbString);
qry.Append(");");

}
else
{
if (!(sensor_oid_mapping_idChanged || oidChanged || nameChanged ))
return;
qry.Append("UPDATE Sensor_oid_mapping set "); if ( oidChanged )
{
qry.Append("oid ="+oidDbString);
qry.Append(",");
}

if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("sensor_oid_mapping_id = "+sensor_oid_mapping_idDbString);
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
cmd.CommandText = "DELETE Sensor_oid_mapping where sensor_oid_mapping_id = "+ sensor_oid_mapping_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteSensorOidMappings(string where)
{
ConnectionFactory.ExecuteQuery("delete Sensor_oid_mapping where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
sensor_oid_mapping_id= 1,
oid= 2,
name= 4
}
#endregion
public void BulkSave(List<SensorOidMapping> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Sensor_oid_mapping";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SensorOidMapping.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SensorOidMapping> transList,ref DataTable dt)
{
foreach (SensorOidMapping tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["sensor_oid_mapping_id"] =ConnectionFactory.GetNextId();
Row["oid"] = tran.Oid;
Row["name"] = tran.Name;
dt.Rows.Add(Row);
} }
}
}
