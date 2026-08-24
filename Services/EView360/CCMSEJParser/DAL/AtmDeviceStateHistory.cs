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
public class AtmDeviceStateHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmDeviceStateHistory() { }
public AtmDeviceStateHistory( int atm_id,int device_id,DateTime from_time ) 
{
this.from_time = from_time;
this.from_timeChanged = true;
}
public AtmDeviceStateHistory( DateTime from_time,DateTime? to_time,int? device_service_state )
{
this.from_time = from_time;
this.from_timeChanged = true;
this.to_time = to_time;
this.to_timeChanged = true;
this.device_service_state = device_service_state;
this.device_service_stateChanged = true;
}
private AtmDeviceStateHistory( int atm_id,int device_id,DateTime from_time,DateTime? to_time,int? device_service_state )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.from_time = from_time;
this.from_timeChanged = true;
this.to_time = to_time;
this.to_timeChanged = true;
this.device_service_state = device_service_state;
this.device_service_stateChanged = true;
}

#region members and properties for columns

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
#region FromTime
private bool from_timeChanged = false;
private DateTime from_time;
public DateTime FromTime
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
return string.Format("Convert(datetime,'{0}',121)",from_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region DeviceServiceState
private bool device_service_stateChanged = false;
private int? device_service_state;
public int? DeviceServiceState
{
get { return device_service_state; }
set { 
device_service_state = value;
device_service_stateChanged = true;
}
}
private string device_service_stateDbString
{
get
{
if (this.device_service_state.HasValue)
return device_service_state.ToString();
else
return "null";
}
}
#endregion
#endregion

#region AtmDeviceStateHistoryReader
public class AtmDeviceStateHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmDeviceStateHistory currentAtmDeviceStateHistory;
Columns columns;
bool partialRead = false;
private AtmDeviceStateHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmDeviceStateHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmDeviceStateHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmDeviceStateHistory; }

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
currentAtmDeviceStateHistory = new AtmDeviceStateHistory();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmDeviceStateHistory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentAtmDeviceStateHistory.device_id =(int) reader["device_id"]; 
if ((columns & Columns.from_time) == Columns.from_time && reader["from_time"]!=DBNull.Value)
currentAtmDeviceStateHistory.from_time =(DateTime) reader["from_time"]; 
if ((columns & Columns.to_time) == Columns.to_time && reader["to_time"]!=DBNull.Value)
currentAtmDeviceStateHistory.to_time =(DateTime?) reader["to_time"]; 
if ((columns & Columns.device_service_state) == Columns.device_service_state && reader["device_service_state"]!=DBNull.Value)
currentAtmDeviceStateHistory.device_service_state =(int?) reader["device_service_state"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentAtmDeviceStateHistory.atm_id = (int) reader["atm_id"]; 
if (reader["device_id"] != DBNull.Value)
currentAtmDeviceStateHistory.device_id = (int) reader["device_id"]; 
if (reader["from_time"] != DBNull.Value)
currentAtmDeviceStateHistory.from_time = (DateTime) reader["from_time"]; 
if (reader["to_time"] != DBNull.Value)
currentAtmDeviceStateHistory.to_time = (DateTime?) reader["to_time"]; 
if (reader["device_service_state"] != DBNull.Value)
currentAtmDeviceStateHistory.device_service_state = (int?) reader["device_service_state"]; 
} 

currentAtmDeviceStateHistory.isNewEntity = false;
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

public AtmDeviceStateHistory CurrentAtmDeviceStateHistory
{
get{ return currentAtmDeviceStateHistory; }
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


#region AtmDeviceStateHistory functions

public static AtmDeviceStateHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.from_time == (Columns.from_time & columns))
qry.Append("from_time,");
if (Columns.to_time == (Columns.to_time & columns))
qry.Append("to_time,");
if (Columns.device_service_state == (Columns.device_service_state & columns))
qry.Append("device_service_state,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_device_state_history ");

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
return new AtmDeviceStateHistoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmDeviceStateHistoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmDeviceStateHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,device_id,from_time,to_time,device_service_state from Atm_device_state_history ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmDeviceStateHistoryReader(cmd.ExecuteReader(), conn);
}

static public AtmDeviceStateHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmDeviceStateHistory LoadAtmDeviceStateHistory(string where)
{
AtmDeviceStateHistoryReader reader = AtmDeviceStateHistory.ExecuteReader(where);
AtmDeviceStateHistory _atmdevicestatehistory = null;
if (reader.Read())
_atmdevicestatehistory = reader.CurrentAtmDeviceStateHistory;
reader.Close();
return _atmdevicestatehistory;
}

public static AtmDeviceStateHistory LoadAtmDeviceStateHistory(string where, IDbConnection conn)
{
AtmDeviceStateHistoryReader reader = AtmDeviceStateHistory.ExecuteReader(where, conn);
AtmDeviceStateHistory _atmdevicestatehistory = null;
if (reader.Read())
_atmdevicestatehistory = reader.CurrentAtmDeviceStateHistory;
reader.Close(false);
return _atmdevicestatehistory;
}

public static AtmDeviceStateHistory LoadAtmDeviceStateHistoryByPk( int atm_id,int device_id,DateTime from_time )
{
return LoadAtmDeviceStateHistory( " atm_id="+atm_id+" and device_id="+device_id+" and from_time=Convert(datetime,'"+from_time.ToString("yyyy-MM-dd HH:mm:ss.fff")+"',121)" );
}

public static AtmDeviceStateHistory LoadAtmDeviceStateHistoryByPk( int atm_id,int device_id,DateTime from_time , IDbConnection conn)
{
return LoadAtmDeviceStateHistory(" atm_id="+atm_id+" and device_id="+device_id+" and from_time=Convert(datetime,'"+from_time.ToString("yyyy-MM-dd HH:mm:ss.fff")+"',121)" , conn);
}

public void Save()
{
if (atm_idChanged || device_idChanged || from_timeChanged || to_timeChanged || device_service_stateChanged )
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
if (atm_idChanged || device_idChanged || from_timeChanged || to_timeChanged || device_service_stateChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_device_state_history( atm_id,device_id,from_time,to_time,device_service_state ) values(");
lock (ConnectionFactory.connectionString) { this.atm_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_id);
} qry.Append(",");
lock (ConnectionFactory.connectionString) { this.device_id = ConnectionFactory.GetNextId();
qry.Append(this.device_id);
} qry.Append(",");
qry.Append(from_timeDbString+",");
qry.Append(to_timeDbString+",");
qry.Append(device_service_stateDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || device_idChanged || from_timeChanged || to_timeChanged || device_service_stateChanged ))
return;
qry.Append("UPDATE Atm_device_state_history set "); if ( to_timeChanged )
{
qry.Append("to_time ="+to_timeDbString);
qry.Append(",");
}

if ( device_service_stateChanged )
{
qry.Append("device_service_state ="+device_service_stateDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_id = "+atm_idDbString);
qry.Append(" and device_id = "+device_idDbString);
qry.Append(" and from_time = "+from_timeDbString);
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
cmd.CommandText = "DELETE Atm_device_state_history where atm_id = "+ atm_id +" and device_id = "+ device_id +" and from_time = "+ from_time;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmDeviceStateHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_device_state_history where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
device_id= 2,
from_time= 4,
to_time= 8,
device_service_state= 16
}
#endregion
public void BulkSave(List<AtmDeviceStateHistory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_device_state_history";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmDeviceStateHistory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmDeviceStateHistory> transList,ref DataTable dt)
{
foreach (AtmDeviceStateHistory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] =ConnectionFactory.GetNextId();
Row["device_id"] =ConnectionFactory.GetNextId();
Row["from_time"] = tran.FromTime;
Row["to_time"] = tran.ToTime;
Row["device_service_state"] = tran.DeviceServiceState;
dt.Rows.Add(Row);
} }
}
}
