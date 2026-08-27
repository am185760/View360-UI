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
public class BatchSchedule
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public BatchSchedule() { }
public BatchSchedule( int batch_schedule_id,int interval,int atm_id ) 
{
this.interval = interval;
this.intervalChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
public BatchSchedule( string event_name,int interval,int atm_id )
{
this.event_name = event_name;
this.event_nameChanged = true;
this.interval = interval;
this.intervalChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private BatchSchedule( int batch_schedule_id,string event_name,int interval,int atm_id )
{
this.batch_schedule_id = batch_schedule_id;
this.batch_schedule_idChanged = true;
this.event_name = event_name;
this.event_nameChanged = true;
this.interval = interval;
this.intervalChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region BatchScheduleId
private bool batch_schedule_idChanged = false;
private int batch_schedule_id;
public int BatchScheduleId
{
get { return batch_schedule_id; }
set { 
batch_schedule_id = value;
batch_schedule_idChanged = true;
}
}
private string batch_schedule_idDbString
{
get
{
return batch_schedule_id.ToString();
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

#region BatchScheduleReader
public class BatchScheduleReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
BatchSchedule currentBatchSchedule;
Columns columns;
bool partialRead = false;
private BatchScheduleReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public BatchScheduleReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public BatchScheduleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentBatchSchedule; }

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
currentBatchSchedule = new BatchSchedule();
if (partialRead)
{ if ((columns & Columns.batch_schedule_id) == Columns.batch_schedule_id && reader["batch_schedule_id"]!=DBNull.Value)
currentBatchSchedule.batch_schedule_id =(int) reader["batch_schedule_id"]; 
if ((columns & Columns.event_name) == Columns.event_name && reader["event_name"]!=DBNull.Value)
currentBatchSchedule.event_name =(string) reader["event_name"]; 
if ((columns & Columns.interval) == Columns.interval && reader["interval"]!=DBNull.Value)
currentBatchSchedule.interval =(int) reader["interval"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentBatchSchedule.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["batch_schedule_id"] != DBNull.Value)
currentBatchSchedule.batch_schedule_id = (int) reader["batch_schedule_id"]; 
if (reader["event_name"] != DBNull.Value)
currentBatchSchedule.event_name = (string) reader["event_name"]; 
if (reader["interval"] != DBNull.Value)
currentBatchSchedule.interval = (int) reader["interval"]; 
if (reader["atm_id"] != DBNull.Value)
currentBatchSchedule.atm_id = (int) reader["atm_id"]; 
} 

currentBatchSchedule.isNewEntity = false;
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

public BatchSchedule CurrentBatchSchedule
{
get{ return currentBatchSchedule; }
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


#region BatchSchedule functions

public static BatchScheduleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.batch_schedule_id == (Columns.batch_schedule_id & columns))
qry.Append("batch_schedule_id,");
if (Columns.event_name == (Columns.event_name & columns))
qry.Append("event_name,");
if (Columns.interval == (Columns.interval & columns))
qry.Append("interval,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Batch_schedule ");

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
return new BatchScheduleReader(cmd.ExecuteReader(), conn, columns);
}

static public BatchScheduleReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static BatchScheduleReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select batch_schedule_id,event_name,interval,atm_id from Batch_schedule ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new BatchScheduleReader(cmd.ExecuteReader(), conn);
}

static public BatchScheduleReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static BatchSchedule LoadBatchSchedule(string where)
{
BatchScheduleReader reader = BatchSchedule.ExecuteReader(where);
BatchSchedule _batchschedule = null;
if (reader.Read())
_batchschedule = reader.CurrentBatchSchedule;
reader.Close();
return _batchschedule;
}

public static BatchSchedule LoadBatchSchedule(string where, IDbConnection conn)
{
BatchScheduleReader reader = BatchSchedule.ExecuteReader(where, conn);
BatchSchedule _batchschedule = null;
if (reader.Read())
_batchschedule = reader.CurrentBatchSchedule;
reader.Close(false);
return _batchschedule;
}

public static BatchSchedule LoadBatchScheduleByPk( int batch_schedule_id )
{
return LoadBatchSchedule( " batch_schedule_id="+batch_schedule_id );
}

public static BatchSchedule LoadBatchScheduleByPk( int batch_schedule_id , IDbConnection conn)
{
return LoadBatchSchedule(" batch_schedule_id="+batch_schedule_id , conn);
}

public void Save()
{
if (batch_schedule_idChanged || event_nameChanged || intervalChanged || atm_idChanged )
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
if (batch_schedule_idChanged || event_nameChanged || intervalChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Batch_schedule( batch_schedule_id,event_name,interval,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.batch_schedule_id = ConnectionFactory.GetNextId();
qry.Append(this.batch_schedule_id);
} qry.Append(",");
qry.Append(event_nameDbString+",");
qry.Append(intervalDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(batch_schedule_idChanged || event_nameChanged || intervalChanged || atm_idChanged ))
return;
qry.Append("UPDATE Batch_schedule set "); if ( event_nameChanged )
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
qry.Append("batch_schedule_id = "+batch_schedule_idDbString);
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
cmd.CommandText = "DELETE Batch_schedule where batch_schedule_id = "+ batch_schedule_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteBatchSchedules(string where)
{
ConnectionFactory.ExecuteQuery("delete Batch_schedule where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
batch_schedule_id= 1,
event_name= 2,
interval= 4,
atm_id= 8
}
#endregion
public void BulkSave(List<BatchSchedule> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Batch_schedule";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(BatchSchedule.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <BatchSchedule> transList,ref DataTable dt)
{
foreach (BatchSchedule tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["batch_schedule_id"] =ConnectionFactory.GetNextId();
Row["event_name"] = tran.EventName;
Row["interval"] = tran.Interval;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
