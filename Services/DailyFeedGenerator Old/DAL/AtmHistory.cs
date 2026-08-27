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
public class AtmHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmHistory() { }
public AtmHistory( int atm_id,DateTime from_time ) 
{
this.from_time = from_time;
this.from_timeChanged = true;
}
public AtmHistory( DateTime from_time,DateTime? to_time,int? service_state )
{
this.from_time = from_time;
this.from_timeChanged = true;
this.to_time = to_time;
this.to_timeChanged = true;
this.service_state = service_state;
this.service_stateChanged = true;
}
private AtmHistory( int atm_id,DateTime from_time,DateTime? to_time,int? service_state )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.from_time = from_time;
this.from_timeChanged = true;
this.to_time = to_time;
this.to_timeChanged = true;
this.service_state = service_state;
this.service_stateChanged = true;
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
#region ServiceState
private bool service_stateChanged = false;
private int? service_state;
public int? ServiceState
{
get { return service_state; }
set { 
service_state = value;
service_stateChanged = true;
}
}
private string service_stateDbString
{
get
{
if (this.service_state.HasValue)
return service_state.ToString();
else
return "null";
}
}
#endregion
#endregion

#region AtmHistoryReader
public class AtmHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmHistory currentAtmHistory;
Columns columns;
bool partialRead = false;
private AtmHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmHistory; }

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
currentAtmHistory = new AtmHistory();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmHistory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.from_time) == Columns.from_time && reader["from_time"]!=DBNull.Value)
currentAtmHistory.from_time =(DateTime) reader["from_time"]; 
if ((columns & Columns.to_time) == Columns.to_time && reader["to_time"]!=DBNull.Value)
currentAtmHistory.to_time =(DateTime?) reader["to_time"]; 
if ((columns & Columns.service_state) == Columns.service_state && reader["service_state"]!=DBNull.Value)
currentAtmHistory.service_state =(int?) reader["service_state"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentAtmHistory.atm_id = (int) reader["atm_id"]; 
if (reader["from_time"] != DBNull.Value)
currentAtmHistory.from_time = (DateTime) reader["from_time"]; 
if (reader["to_time"] != DBNull.Value)
currentAtmHistory.to_time = (DateTime?) reader["to_time"]; 
if (reader["service_state"] != DBNull.Value)
currentAtmHistory.service_state = (int?) reader["service_state"]; 
} 

currentAtmHistory.isNewEntity = false;
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

public AtmHistory CurrentAtmHistory
{
get{ return currentAtmHistory; }
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


#region AtmHistory functions

public static AtmHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.from_time == (Columns.from_time & columns))
qry.Append("from_time,");
if (Columns.to_time == (Columns.to_time & columns))
qry.Append("to_time,");
if (Columns.service_state == (Columns.service_state & columns))
qry.Append("service_state,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_history ");

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
return new AtmHistoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmHistoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,from_time,to_time,service_state from Atm_history ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmHistoryReader(cmd.ExecuteReader(), conn);
}

static public AtmHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmHistory LoadAtmHistory(string where)
{
AtmHistoryReader reader = AtmHistory.ExecuteReader(where);
AtmHistory _atmhistory = null;
if (reader.Read())
_atmhistory = reader.CurrentAtmHistory;
reader.Close();
return _atmhistory;
}

public static AtmHistory LoadAtmHistory(string where, IDbConnection conn)
{
AtmHistoryReader reader = AtmHistory.ExecuteReader(where, conn);
AtmHistory _atmhistory = null;
if (reader.Read())
_atmhistory = reader.CurrentAtmHistory;
reader.Close(false);
return _atmhistory;
}

public static AtmHistory LoadAtmHistoryByPk( int atm_id,DateTime from_time )
{
return LoadAtmHistory( " atm_id="+atm_id+" and from_time=Convert(datetime,'"+from_time.ToString("yyyy-MM-dd HH:mm:ss.fff")+"',121)" );
}

public static AtmHistory LoadAtmHistoryByPk( int atm_id,DateTime from_time , IDbConnection conn)
{
return LoadAtmHistory(" atm_id="+atm_id+" and from_time=Convert(datetime,'"+from_time.ToString("yyyy-MM-dd HH:mm:ss.fff")+"',121)" , conn);
}

public void Save()
{
if (atm_idChanged || from_timeChanged || to_timeChanged || service_stateChanged )
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
if (atm_idChanged || from_timeChanged || to_timeChanged || service_stateChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_history( atm_id,from_time,to_time,service_state ) values(");
lock (ConnectionFactory.connectionString) { this.atm_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_id);
} qry.Append(",");
qry.Append(from_timeDbString+",");
qry.Append(to_timeDbString+",");
qry.Append(service_stateDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || from_timeChanged || to_timeChanged || service_stateChanged ))
return;
qry.Append("UPDATE Atm_history set "); if ( to_timeChanged )
{
qry.Append("to_time ="+to_timeDbString);
qry.Append(",");
}

if ( service_stateChanged )
{
qry.Append("service_state ="+service_stateDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_id = "+atm_idDbString);
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
cmd.CommandText = "DELETE Atm_history where atm_id = "+ atm_id +" and from_time = "+ from_time;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_history where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
from_time= 2,
to_time= 4,
service_state= 8
}
#endregion
public void BulkSave(List<AtmHistory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_history";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmHistory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmHistory> transList,ref DataTable dt)
{
foreach (AtmHistory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] =ConnectionFactory.GetNextId();
Row["from_time"] = tran.FromTime;
Row["to_time"] = tran.ToTime;
Row["service_state"] = tran.ServiceState;
dt.Rows.Add(Row);
} }
}
}
