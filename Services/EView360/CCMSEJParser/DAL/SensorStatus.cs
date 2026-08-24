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
public class SensorStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SensorStatus() { }
public SensorStatus( int sensor_status_id,int sensor_oid_mapping_id ) 
{
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
}
public SensorStatus( int sensor_oid_mapping_id,DateTime? from_time,DateTime? to_time,int? val,int? atm_id )
{
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
this.from_time = from_time;
this.from_timeChanged = true;
this.to_time = to_time;
this.to_timeChanged = true;
this.val = val;
this.valChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private SensorStatus( int sensor_status_id,int sensor_oid_mapping_id,DateTime? from_time,DateTime? to_time,int? val,int? atm_id )
{
this.sensor_status_id = sensor_status_id;
this.sensor_status_idChanged = true;
this.sensor_oid_mapping_id = sensor_oid_mapping_id;
this.sensor_oid_mapping_idChanged = true;
this.from_time = from_time;
this.from_timeChanged = true;
this.to_time = to_time;
this.to_timeChanged = true;
this.val = val;
this.valChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region SensorStatusId
private bool sensor_status_idChanged = false;
private int sensor_status_id;
public int SensorStatusId
{
get { return sensor_status_id; }
set { 
sensor_status_id = value;
sensor_status_idChanged = true;
}
}
private string sensor_status_idDbString
{
get
{
return sensor_status_id.ToString();
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
#region FromTime
private bool from_timeChanged = false;
private DateTime? from_time;
public DateTime? FromTime
{
get { return from_time; }
set { 
from_time = value;
from_timeChanged = true;
}
}
private string from_timeDbString
{
get
{
if (this.from_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",from_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ToTime
private bool to_timeChanged = false;
private DateTime? to_time;
public DateTime? ToTime
{
get { return to_time; }
set { 
to_time = value;
to_timeChanged = true;
}
}
private string to_timeDbString
{
get
{
if (this.to_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",to_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
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

#region SensorStatusReader
public class SensorStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SensorStatus currentSensorStatus;
Columns columns;
bool partialRead = false;
private SensorStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SensorStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SensorStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSensorStatus; }

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
currentSensorStatus = new SensorStatus();
if (partialRead)
{ if ((columns & Columns.sensor_status_id) == Columns.sensor_status_id && reader["sensor_status_id"]!=DBNull.Value)
currentSensorStatus.sensor_status_id =(int) reader["sensor_status_id"]; 
if ((columns & Columns.sensor_oid_mapping_id) == Columns.sensor_oid_mapping_id && reader["sensor_oid_mapping_id"]!=DBNull.Value)
currentSensorStatus.sensor_oid_mapping_id =(int) reader["sensor_oid_mapping_id"]; 
if ((columns & Columns.from_time) == Columns.from_time && reader["from_time"]!=DBNull.Value)
currentSensorStatus.from_time =(DateTime?) reader["from_time"]; 
if ((columns & Columns.to_time) == Columns.to_time && reader["to_time"]!=DBNull.Value)
currentSensorStatus.to_time =(DateTime?) reader["to_time"]; 
if ((columns & Columns.val) == Columns.val && reader["val"]!=DBNull.Value)
currentSensorStatus.val =(int?) reader["val"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentSensorStatus.atm_id =(int?) reader["atm_id"]; 

} else
{
if (reader["sensor_status_id"] != DBNull.Value)
currentSensorStatus.sensor_status_id = (int) reader["sensor_status_id"]; 
if (reader["sensor_oid_mapping_id"] != DBNull.Value)
currentSensorStatus.sensor_oid_mapping_id = (int) reader["sensor_oid_mapping_id"]; 
if (reader["from_time"] != DBNull.Value)
currentSensorStatus.from_time = (DateTime?) reader["from_time"]; 
if (reader["to_time"] != DBNull.Value)
currentSensorStatus.to_time = (DateTime?) reader["to_time"]; 
if (reader["val"] != DBNull.Value)
currentSensorStatus.val = (int?) reader["val"]; 
if (reader["atm_id"] != DBNull.Value)
currentSensorStatus.atm_id = (int?) reader["atm_id"]; 
} 

currentSensorStatus.isNewEntity = false;
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

public SensorStatus CurrentSensorStatus
{
get{ return currentSensorStatus; }
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


#region SensorStatus functions

public static SensorStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.sensor_status_id == (Columns.sensor_status_id & columns))
qry.Append("sensor_status_id,");
if (Columns.sensor_oid_mapping_id == (Columns.sensor_oid_mapping_id & columns))
qry.Append("sensor_oid_mapping_id,");
if (Columns.from_time == (Columns.from_time & columns))
qry.Append("from_time,");
if (Columns.to_time == (Columns.to_time & columns))
qry.Append("to_time,");
if (Columns.val == (Columns.val & columns))
qry.Append("val,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Sensor_status ");

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
return new SensorStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public SensorStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SensorStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select sensor_status_id,sensor_oid_mapping_id,from_time,to_time,val,atm_id from Sensor_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SensorStatusReader(cmd.ExecuteReader(), conn);
}

static public SensorStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SensorStatus LoadSensorStatus(string where)
{
SensorStatusReader reader = SensorStatus.ExecuteReader(where);
SensorStatus _sensorstatus = null;
if (reader.Read())
_sensorstatus = reader.CurrentSensorStatus;
reader.Close();
return _sensorstatus;
}

public static SensorStatus LoadSensorStatus(string where, IDbConnection conn)
{
SensorStatusReader reader = SensorStatus.ExecuteReader(where, conn);
SensorStatus _sensorstatus = null;
if (reader.Read())
_sensorstatus = reader.CurrentSensorStatus;
reader.Close(false);
return _sensorstatus;
}

public static SensorStatus LoadSensorStatusByPk( int sensor_status_id )
{
return LoadSensorStatus( " sensor_status_id="+sensor_status_id );
}

public static SensorStatus LoadSensorStatusByPk( int sensor_status_id , IDbConnection conn)
{
return LoadSensorStatus(" sensor_status_id="+sensor_status_id , conn);
}

public void Save()
{
if (sensor_status_idChanged || sensor_oid_mapping_idChanged || from_timeChanged || to_timeChanged || valChanged || atm_idChanged )
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
if (sensor_status_idChanged || sensor_oid_mapping_idChanged || from_timeChanged || to_timeChanged || valChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Sensor_status( sensor_status_id,sensor_oid_mapping_id,from_time,to_time,val,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.sensor_status_id = ConnectionFactory.GetNextId();
qry.Append(this.sensor_status_id);
} qry.Append(",");
qry.Append(sensor_oid_mapping_idDbString+",");
qry.Append(from_timeDbString+",");
qry.Append(to_timeDbString+",");
qry.Append(valDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(sensor_status_idChanged || sensor_oid_mapping_idChanged || from_timeChanged || to_timeChanged || valChanged || atm_idChanged ))
return;
qry.Append("UPDATE Sensor_status set "); if ( sensor_oid_mapping_idChanged )
{
qry.Append("sensor_oid_mapping_id ="+sensor_oid_mapping_idDbString);
qry.Append(",");
}

if ( from_timeChanged )
{
qry.Append("from_time ="+from_timeDbString);
qry.Append(",");
}

if ( to_timeChanged )
{
qry.Append("to_time ="+to_timeDbString);
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
qry.Append("sensor_status_id = "+sensor_status_idDbString);
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
cmd.CommandText = "DELETE Sensor_status where sensor_status_id = "+ sensor_status_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteSensorStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete Sensor_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
sensor_status_id= 1,
sensor_oid_mapping_id= 2,
from_time= 4,
to_time= 8,
val= 16,
atm_id= 32
}
#endregion
public void BulkSave(List<SensorStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Sensor_status";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SensorStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SensorStatus> transList,ref DataTable dt)
{
foreach (SensorStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["sensor_status_id"] =ConnectionFactory.GetNextId();
Row["sensor_oid_mapping_id"] = tran.SensorOidMappingId;
Row["from_time"] = tran.FromTime;
Row["to_time"] = tran.ToTime;
Row["val"] = tran.Val;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
