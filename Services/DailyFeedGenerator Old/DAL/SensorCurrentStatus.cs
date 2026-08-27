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
public class SensorCurrentStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SensorCurrentStatus() { }
public SensorCurrentStatus( int sensor_current_status_id,int sensor_oid_mapping_id ) 
{
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
}
public SensorCurrentStatus( int sensor_oid_mapping_id,int? val,int? atm_id )
{
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
this.val = val;
this.valChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private SensorCurrentStatus( int sensor_current_status_id,int sensor_oid_mapping_id,int? val,int? atm_id )
{
this.sensor_current_status_id = sensor_current_status_id;
this.sensor_current_status_idChanged = true;
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
this.val = val;
this.valChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region SensorCurrentStatusId
private bool sensor_current_status_idChanged = false;
private int sensor_current_status_id;
public int SensorCurrentStatusId
{
get { return sensor_current_status_id; }
set { 
sensor_current_status_id = value;
sensor_current_status_idChanged = true;
}
}
private string sensor_current_status_idDbString
{
get
{
return sensor_current_status_id.ToString();
}
}
#endregion
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
#region Val
private bool valChanged = false;
private int? val;
public int? Val
{
get { return val; }
set { 
val = value;
valChanged = true;
}
}
private string valDbString
{
get
{
if (this.val.HasValue)
return val.ToString();
else
return "null";
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int? atm_id;
public int? AtmId
{
get { return atm_id; }
set { 
atm_id = value;
atm_idChanged = true;
}
}
private string atm_idDbString
{
get
{
if (this.atm_id.HasValue)
return atm_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region SensorCurrentStatusReader
public class SensorCurrentStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SensorCurrentStatus currentSensorCurrentStatus;
Columns columns;
bool partialRead = false;
private SensorCurrentStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SensorCurrentStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SensorCurrentStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSensorCurrentStatus; }

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
currentSensorCurrentStatus = new SensorCurrentStatus();
if (partialRead)
{ if ((columns & Columns.sensor_current_status_id) == Columns.sensor_current_status_id && reader["sensor_current_status_id"]!=DBNull.Value)
currentSensorCurrentStatus.sensor_current_status_id =(int) reader["sensor_current_status_id"]; 
if ((columns & Columns.sensor_oid_mapping_id) == Columns.sensor_oid_mapping_id && reader["sensor_oid_mapping_id"]!=DBNull.Value)
currentSensorCurrentStatus.sensor_oid_mapping_id =(int) reader["sensor_oid_mapping_id"]; 
if ((columns & Columns.val) == Columns.val && reader["val"]!=DBNull.Value)
currentSensorCurrentStatus.val =(int?) reader["val"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentSensorCurrentStatus.atm_id =(int?) reader["atm_id"]; 

} else
{
if (reader["sensor_current_status_id"] != DBNull.Value)
currentSensorCurrentStatus.sensor_current_status_id = (int) reader["sensor_current_status_id"]; 
if (reader["sensor_oid_mapping_id"] != DBNull.Value)
currentSensorCurrentStatus.sensor_oid_mapping_id = (int) reader["sensor_oid_mapping_id"]; 
if (reader["val"] != DBNull.Value)
currentSensorCurrentStatus.val = (int?) reader["val"]; 
if (reader["atm_id"] != DBNull.Value)
currentSensorCurrentStatus.atm_id = (int?) reader["atm_id"]; 
} 

currentSensorCurrentStatus.isNewEntity = false;
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

public SensorCurrentStatus CurrentSensorCurrentStatus
{
get{ return currentSensorCurrentStatus; }
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


#region SensorCurrentStatus functions

public static SensorCurrentStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.sensor_current_status_id == (Columns.sensor_current_status_id & columns))
qry.Append("sensor_current_status_id,");
if (Columns.sensor_oid_mapping_id == (Columns.sensor_oid_mapping_id & columns))
qry.Append("sensor_oid_mapping_id,");
if (Columns.val == (Columns.val & columns))
qry.Append("val,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Sensor_current_status ");

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
return new SensorCurrentStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public SensorCurrentStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SensorCurrentStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select sensor_current_status_id,sensor_oid_mapping_id,val,atm_id from Sensor_current_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SensorCurrentStatusReader(cmd.ExecuteReader(), conn);
}

static public SensorCurrentStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SensorCurrentStatus LoadSensorCurrentStatus(string where)
{
SensorCurrentStatusReader reader = SensorCurrentStatus.ExecuteReader(where);
SensorCurrentStatus _sensorcurrentstatus = null;
if (reader.Read())
_sensorcurrentstatus = reader.CurrentSensorCurrentStatus;
reader.Close();
return _sensorcurrentstatus;
}

public static SensorCurrentStatus LoadSensorCurrentStatus(string where, IDbConnection conn)
{
SensorCurrentStatusReader reader = SensorCurrentStatus.ExecuteReader(where, conn);
SensorCurrentStatus _sensorcurrentstatus = null;
if (reader.Read())
_sensorcurrentstatus = reader.CurrentSensorCurrentStatus;
reader.Close(false);
return _sensorcurrentstatus;
}

public static SensorCurrentStatus LoadSensorCurrentStatusByPk( int sensor_current_status_id )
{
return LoadSensorCurrentStatus( " sensor_current_status_id="+sensor_current_status_id );
}

public static SensorCurrentStatus LoadSensorCurrentStatusByPk( int sensor_current_status_id , IDbConnection conn)
{
return LoadSensorCurrentStatus(" sensor_current_status_id="+sensor_current_status_id , conn);
}

public void Save()
{
if (sensor_current_status_idChanged || sensor_oid_mapping_idChanged || valChanged || atm_idChanged )
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
if (sensor_current_status_idChanged || sensor_oid_mapping_idChanged || valChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Sensor_current_status( sensor_current_status_id,sensor_oid_mapping_id,val,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.sensor_current_status_id = ConnectionFactory.GetNextId();
qry.Append(this.sensor_current_status_id);
} qry.Append(",");
qry.Append(sensor_oid_mapping_idDbString+",");
qry.Append(valDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(sensor_current_status_idChanged || sensor_oid_mapping_idChanged || valChanged || atm_idChanged ))
return;
qry.Append("UPDATE Sensor_current_status set "); if ( sensor_oid_mapping_idChanged )
{
qry.Append("sensor_oid_mapping_id ="+sensor_oid_mapping_idDbString);
qry.Append(",");
}

if ( valChanged )
{
qry.Append("val ="+valDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("sensor_current_status_id = "+sensor_current_status_idDbString);
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
cmd.CommandText = "DELETE Sensor_current_status where sensor_current_status_id = "+ sensor_current_status_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteSensorCurrentStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete Sensor_current_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
sensor_current_status_id= 1,
sensor_oid_mapping_id= 2,
val= 4,
atm_id= 8
}
#endregion
public void BulkSave(List<SensorCurrentStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Sensor_current_status";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SensorCurrentStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SensorCurrentStatus> transList,ref DataTable dt)
{
foreach (SensorCurrentStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["sensor_current_status_id"] =ConnectionFactory.GetNextId();
Row["sensor_oid_mapping_id"] = tran.SensorOidMappingId;
Row["val"] = tran.Val;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
