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
public class EjEvents
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public EjEvents() { }
public EjEvents( int ej_events_id ) 
{
}
public EjEvents( string ej_text,DateTime? ej_datetime,int? atm_id,int? task_id,DateTime? processing_datetime )
{
this.ej_text = ej_text;
this.ej_textChanged = true;
this.ej_datetime = ej_datetime;
this.ej_datetimeChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
}
private EjEvents( int ej_events_id,string ej_text,DateTime? ej_datetime,int? atm_id,int? task_id,DateTime? processing_datetime )
{
this.ej_events_id = ej_events_id;
this.ej_events_idChanged = true;
this.ej_text = ej_text;
this.ej_textChanged = true;
this.ej_datetime = ej_datetime;
this.ej_datetimeChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
}

#region members and properties for columns

#region EjEventsId
private bool ej_events_idChanged = false;
private int ej_events_id;
public int EjEventsId
{
get { return ej_events_id; }
set { 
ej_events_id = value;
ej_events_idChanged = true;
}
}
private string ej_events_idDbString
{
get
{
return ej_events_id.ToString();
}
}
#endregion
#region EjText
private bool ej_textChanged = false;
private string ej_text;
public string EjText
{
get { return ej_text; }
set { 
ej_text = value;
ej_textChanged = true;
}
}
private string ej_textDbString
{
get
{
if (this.ej_text!=null)
return string.Format("'{0}'",ej_text); else
return "null";
}
}
#endregion
#region EjDatetime
private bool ej_datetimeChanged = false;
private DateTime? ej_datetime;
public DateTime? EjDatetime
{
get { return ej_datetime; }
set { 
ej_datetime = value;
ej_datetimeChanged = true;
}
}
private string ej_datetimeDbString
{
get
{
if (this.ej_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",ej_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region TaskId
private bool task_idChanged = false;
private int? task_id;
public int? TaskId
{
get { return task_id; }
set { 
task_id = value;
task_idChanged = true;
}
}
private string task_idDbString
{
get
{
if (this.task_id.HasValue)
return task_id.ToString();
else
return "null";
}
}
#endregion
#region ProcessingDatetime
private bool processing_datetimeChanged = false;
private DateTime? processing_datetime;
public DateTime? ProcessingDatetime
{
get { return processing_datetime; }
set { 
processing_datetime = value;
processing_datetimeChanged = true;
}
}
private string processing_datetimeDbString
{
get
{
if (this.processing_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",processing_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#endregion

#region EjEventsReader
public class EjEventsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
EjEvents currentEjEvents;
Columns columns;
bool partialRead = false;
private EjEventsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public EjEventsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public EjEventsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentEjEvents; }

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
currentEjEvents = new EjEvents();
if (partialRead)
{ if ((columns & Columns.ej_events_id) == Columns.ej_events_id && reader["ej_events_id"]!=DBNull.Value)
currentEjEvents.ej_events_id =(int) reader["ej_events_id"]; 
if ((columns & Columns.ej_text) == Columns.ej_text && reader["ej_text"]!=DBNull.Value)
currentEjEvents.ej_text =(string) reader["ej_text"]; 
if ((columns & Columns.ej_datetime) == Columns.ej_datetime && reader["ej_datetime"]!=DBNull.Value)
currentEjEvents.ej_datetime =(DateTime?) reader["ej_datetime"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentEjEvents.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
currentEjEvents.task_id =(int?) reader["task_id"]; 
if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
currentEjEvents.processing_datetime =(DateTime?) reader["processing_datetime"]; 

} else
{
if (reader["ej_events_id"] != DBNull.Value)
currentEjEvents.ej_events_id = (int) reader["ej_events_id"]; 
if (reader["ej_text"] != DBNull.Value)
currentEjEvents.ej_text = (string) reader["ej_text"]; 
if (reader["ej_datetime"] != DBNull.Value)
currentEjEvents.ej_datetime = (DateTime?) reader["ej_datetime"]; 
if (reader["atm_id"] != DBNull.Value)
currentEjEvents.atm_id = (int?) reader["atm_id"]; 
if (reader["task_id"] != DBNull.Value)
currentEjEvents.task_id = (int?) reader["task_id"]; 
if (reader["processing_datetime"] != DBNull.Value)
currentEjEvents.processing_datetime = (DateTime?) reader["processing_datetime"]; 
} 

currentEjEvents.isNewEntity = false;
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

public EjEvents CurrentEjEvents
{
get{ return currentEjEvents; }
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


#region EjEvents functions

public static EjEventsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.ej_events_id == (Columns.ej_events_id & columns))
qry.Append("ej_events_id,");
if (Columns.ej_text == (Columns.ej_text & columns))
qry.Append("ej_text,");
if (Columns.ej_datetime == (Columns.ej_datetime & columns))
qry.Append("ej_datetime,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.task_id == (Columns.task_id & columns))
qry.Append("task_id,");
if (Columns.processing_datetime == (Columns.processing_datetime & columns))
qry.Append("processing_datetime,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ej_events ");

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
return new EjEventsReader(cmd.ExecuteReader(), conn, columns);
}

static public EjEventsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static EjEventsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select ej_events_id,ej_text,ej_datetime,atm_id,task_id,processing_datetime from Ej_events ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new EjEventsReader(cmd.ExecuteReader(), conn);
}

static public EjEventsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static EjEvents LoadEjEvents(string where)
{
EjEventsReader reader = EjEvents.ExecuteReader(where);
EjEvents _ejevents = null;
if (reader.Read())
_ejevents = reader.CurrentEjEvents;
reader.Close();
return _ejevents;
}

public static EjEvents LoadEjEvents(string where, IDbConnection conn)
{
EjEventsReader reader = EjEvents.ExecuteReader(where, conn);
EjEvents _ejevents = null;
if (reader.Read())
_ejevents = reader.CurrentEjEvents;
reader.Close(false);
return _ejevents;
}

public static EjEvents LoadEjEventsByPk( int ej_events_id )
{
return LoadEjEvents( " ej_events_id="+ej_events_id );
}

public static EjEvents LoadEjEventsByPk( int ej_events_id , IDbConnection conn)
{
return LoadEjEvents(" ej_events_id="+ej_events_id , conn);
}

public void Save()
{
if (ej_events_idChanged || ej_textChanged || ej_datetimeChanged || atm_idChanged || task_idChanged || processing_datetimeChanged )
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
if (ej_events_idChanged || ej_textChanged || ej_datetimeChanged || atm_idChanged || task_idChanged || processing_datetimeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ej_events( ej_events_id,ej_text,ej_datetime,atm_id,task_id,processing_datetime ) values(");
lock (ConnectionFactory.connectionString) { this.ej_events_id = ConnectionFactory.GetNextId();
qry.Append(this.ej_events_id);
} qry.Append(",");
qry.Append(ej_textDbString+",");
qry.Append(ej_datetimeDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(task_idDbString+",");
qry.Append(processing_datetimeDbString);
qry.Append(");");

}
else
{
if (!(ej_events_idChanged || ej_textChanged || ej_datetimeChanged || atm_idChanged || task_idChanged || processing_datetimeChanged ))
return;
qry.Append("UPDATE Ej_events set "); if ( ej_textChanged )
{
qry.Append("ej_text ="+ej_textDbString);
qry.Append(",");
}

if ( ej_datetimeChanged )
{
qry.Append("ej_datetime ="+ej_datetimeDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( task_idChanged )
{
qry.Append("task_id ="+task_idDbString);
qry.Append(",");
}

if ( processing_datetimeChanged )
{
qry.Append("processing_datetime ="+processing_datetimeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("ej_events_id = "+ej_events_idDbString);
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
cmd.CommandText = "DELETE Ej_events where ej_events_id = "+ ej_events_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteEjEventss(string where)
{
ConnectionFactory.ExecuteQuery("delete Ej_events where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
ej_events_id= 1,
ej_text= 2,
ej_datetime= 4,
atm_id= 8,
task_id= 16,
processing_datetime= 32
}
#endregion
public void BulkSave(List<EjEvents> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ej_events";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(EjEvents.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <EjEvents> transList,ref DataTable dt)
{
foreach (EjEvents tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["ej_events_id"] =ConnectionFactory.GetNextId();
Row["ej_text"] = tran.EjText;
Row["ej_datetime"] = tran.EjDatetime;
Row["atm_id"] = tran.AtmId;
Row["task_id"] = tran.TaskId;
Row["processing_datetime"] = tran.ProcessingDatetime;
dt.Rows.Add(Row);
} }
}
}
