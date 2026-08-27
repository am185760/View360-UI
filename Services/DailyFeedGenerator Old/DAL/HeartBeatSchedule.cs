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
public class HeartBeatSchedule
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public HeartBeatSchedule() { }
public HeartBeatSchedule( int heart_beat_schedule_id,int interval,int atm_id ) 
{
this.interval = interval;
this.intervalChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
public HeartBeatSchedule( string event_name,int interval,int atm_id )
{
this.event_name = event_name;
this.event_nameChanged = true;
this.interval = interval;
this.intervalChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private HeartBeatSchedule( int heart_beat_schedule_id,string event_name,int interval,int atm_id )
{
this.heart_beat_schedule_id = heart_beat_schedule_id;
this.heart_beat_schedule_idChanged = true;
this.event_name = event_name;
this.event_nameChanged = true;
this.interval = interval;
this.intervalChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region HeartBeatScheduleId
private bool heart_beat_schedule_idChanged = false;
private int heart_beat_schedule_id;
public int HeartBeatScheduleId
{
get { return heart_beat_schedule_id; }
set { 
heart_beat_schedule_id = value;
heart_beat_schedule_idChanged = true;
}
}
private string heart_beat_schedule_idDbString
{
get
{
return heart_beat_schedule_id.ToString();
}
}
#endregion
#region EventName
private bool event_nameChanged = false;
private string event_name;
public string EventName
{
get { return event_name; }
set { 
event_name = value;
event_nameChanged = true;
}
}
private string event_nameDbString
{
get
{
if (this.event_name!=null)
return string.Format("'{0}'",event_name); else
return "null";
}
}
#endregion
#region Interval
private bool intervalChanged = false;
private int interval;
public int Interval
{
get { return interval; }
set { 
interval = value;
intervalChanged = true;
}
}
private string intervalDbString
{
get
{
return interval.ToString();
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int atm_id;
public int AtmId
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
return atm_id.ToString();
}
}
#endregion
#endregion

#region HeartBeatScheduleReader
public class HeartBeatScheduleReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
HeartBeatSchedule currentHeartBeatSchedule;
Columns columns;
bool partialRead = false;
private HeartBeatScheduleReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public HeartBeatScheduleReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public HeartBeatScheduleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentHeartBeatSchedule; }

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
currentHeartBeatSchedule = new HeartBeatSchedule();
if (partialRead)
{ if ((columns & Columns.heart_beat_schedule_id) == Columns.heart_beat_schedule_id && reader["heart_beat_schedule_id"]!=DBNull.Value)
currentHeartBeatSchedule.heart_beat_schedule_id =(int) reader["heart_beat_schedule_id"]; 
if ((columns & Columns.event_name) == Columns.event_name && reader["event_name"]!=DBNull.Value)
currentHeartBeatSchedule.event_name =(string) reader["event_name"]; 
if ((columns & Columns.interval) == Columns.interval && reader["interval"]!=DBNull.Value)
currentHeartBeatSchedule.interval =(int) reader["interval"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentHeartBeatSchedule.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["heart_beat_schedule_id"] != DBNull.Value)
currentHeartBeatSchedule.heart_beat_schedule_id = (int) reader["heart_beat_schedule_id"]; 
if (reader["event_name"] != DBNull.Value)
currentHeartBeatSchedule.event_name = (string) reader["event_name"]; 
if (reader["interval"] != DBNull.Value)
currentHeartBeatSchedule.interval = (int) reader["interval"]; 
if (reader["atm_id"] != DBNull.Value)
currentHeartBeatSchedule.atm_id = (int) reader["atm_id"]; 
} 

currentHeartBeatSchedule.isNewEntity = false;
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

public HeartBeatSchedule CurrentHeartBeatSchedule
{
get{ return currentHeartBeatSchedule; }
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


#region HeartBeatSchedule functions

public static HeartBeatScheduleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.heart_beat_schedule_id == (Columns.heart_beat_schedule_id & columns))
qry.Append("heart_beat_schedule_id,");
if (Columns.event_name == (Columns.event_name & columns))
qry.Append("event_name,");
if (Columns.interval == (Columns.interval & columns))
qry.Append("interval,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Heart_beat_schedule ");

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
return new HeartBeatScheduleReader(cmd.ExecuteReader(), conn, columns);
}

static public HeartBeatScheduleReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static HeartBeatScheduleReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select heart_beat_schedule_id,event_name,interval,atm_id from Heart_beat_schedule ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new HeartBeatScheduleReader(cmd.ExecuteReader(), conn);
}

static public HeartBeatScheduleReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static HeartBeatSchedule LoadHeartBeatSchedule(string where)
{
HeartBeatScheduleReader reader = HeartBeatSchedule.ExecuteReader(where);
HeartBeatSchedule _heartbeatschedule = null;
if (reader.Read())
_heartbeatschedule = reader.CurrentHeartBeatSchedule;
reader.Close();
return _heartbeatschedule;
}

public static HeartBeatSchedule LoadHeartBeatSchedule(string where, IDbConnection conn)
{
HeartBeatScheduleReader reader = HeartBeatSchedule.ExecuteReader(where, conn);
HeartBeatSchedule _heartbeatschedule = null;
if (reader.Read())
_heartbeatschedule = reader.CurrentHeartBeatSchedule;
reader.Close(false);
return _heartbeatschedule;
}

public static HeartBeatSchedule LoadHeartBeatScheduleByPk( int heart_beat_schedule_id )
{
return LoadHeartBeatSchedule( " heart_beat_schedule_id="+heart_beat_schedule_id );
}

public static HeartBeatSchedule LoadHeartBeatScheduleByPk( int heart_beat_schedule_id , IDbConnection conn)
{
return LoadHeartBeatSchedule(" heart_beat_schedule_id="+heart_beat_schedule_id , conn);
}

public void Save()
{
if (heart_beat_schedule_idChanged || event_nameChanged || intervalChanged || atm_idChanged )
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
if (heart_beat_schedule_idChanged || event_nameChanged || intervalChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Heart_beat_schedule( heart_beat_schedule_id,event_name,interval,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.heart_beat_schedule_id = ConnectionFactory.GetNextId();
qry.Append(this.heart_beat_schedule_id);
} qry.Append(",");
qry.Append(event_nameDbString+",");
qry.Append(intervalDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(heart_beat_schedule_idChanged || event_nameChanged || intervalChanged || atm_idChanged ))
return;
qry.Append("UPDATE Heart_beat_schedule set "); if ( event_nameChanged )
{
qry.Append("event_name ="+event_nameDbString);
qry.Append(",");
}

if ( intervalChanged )
{
qry.Append("interval ="+intervalDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("heart_beat_schedule_id = "+heart_beat_schedule_idDbString);
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
cmd.CommandText = "DELETE Heart_beat_schedule where heart_beat_schedule_id = "+ heart_beat_schedule_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteHeartBeatSchedules(string where)
{
ConnectionFactory.ExecuteQuery("delete Heart_beat_schedule where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
heart_beat_schedule_id= 1,
event_name= 2,
interval= 4,
atm_id= 8
}
#endregion
public void BulkSave(List<HeartBeatSchedule> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Heart_beat_schedule";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(HeartBeatSchedule.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <HeartBeatSchedule> transList,ref DataTable dt)
{
foreach (HeartBeatSchedule tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["heart_beat_schedule_id"] =ConnectionFactory.GetNextId();
Row["event_name"] = tran.EventName;
Row["interval"] = tran.Interval;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
