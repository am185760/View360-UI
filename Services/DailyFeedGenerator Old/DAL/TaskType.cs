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
public class TaskType
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public TaskType() { }
public TaskType( string task_type_name )
{
this.task_type_name = task_type_name;
this.task_type_nameChanged = true;
}
private TaskType( int task_type_id,string task_type_name )
{
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
this.task_type_name = task_type_name;
this.task_type_nameChanged = true;
}

#region members and properties for columns

#region TaskTypeId
private bool task_type_idChanged = false;
private int task_type_id;
public int TaskTypeId
{
get { return task_type_id; }
set { 
task_type_id = value;
task_type_idChanged = true;
}
}
private string task_type_idDbString
{
get
{
return task_type_id.ToString();
}
}
#endregion
#region TaskTypeName
private bool task_type_nameChanged = false;
private string task_type_name;
public string TaskTypeName
{
get { return task_type_name; }
set { 
task_type_name = value;
task_type_nameChanged = true;
}
}
private string task_type_nameDbString
{
get
{
if (this.task_type_name!=null)
return string.Format("'{0}'",task_type_name); else
return "null";
}
}
#endregion
#endregion

#region TaskTypeReader
public class TaskTypeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
TaskType currentTaskType;
Columns columns;
bool partialRead = false;
private TaskTypeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public TaskTypeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public TaskTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentTaskType; }

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
currentTaskType = new TaskType();
if (partialRead)
{ if ((columns & Columns.task_type_id) == Columns.task_type_id && reader["task_type_id"]!=DBNull.Value)
currentTaskType.task_type_id =(int) reader["task_type_id"]; 
if ((columns & Columns.task_type_name) == Columns.task_type_name && reader["task_type_name"]!=DBNull.Value)
currentTaskType.task_type_name =(string) reader["task_type_name"]; 

} else
{
if (reader["task_type_id"] != DBNull.Value)
currentTaskType.task_type_id = (int) reader["task_type_id"]; 
if (reader["task_type_name"] != DBNull.Value)
currentTaskType.task_type_name = (string) reader["task_type_name"]; 
} 

currentTaskType.isNewEntity = false;
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

public TaskType CurrentTaskType
{
get{ return currentTaskType; }
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


#region TaskType functions

public static TaskTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.task_type_id == (Columns.task_type_id & columns))
qry.Append("task_type_id,");
if (Columns.task_type_name == (Columns.task_type_name & columns))
qry.Append("task_type_name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Task_type ");

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
return new TaskTypeReader(cmd.ExecuteReader(), conn, columns);
}

static public TaskTypeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static TaskTypeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select task_type_id,task_type_name from Task_type ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new TaskTypeReader(cmd.ExecuteReader(), conn);
}

static public TaskTypeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static TaskType LoadTaskType(string where)
{
TaskTypeReader reader = TaskType.ExecuteReader(where);
TaskType _tasktype = null;
if (reader.Read())
_tasktype = reader.CurrentTaskType;
reader.Close();
return _tasktype;
}

public static TaskType LoadTaskType(string where, IDbConnection conn)
{
TaskTypeReader reader = TaskType.ExecuteReader(where, conn);
TaskType _tasktype = null;
if (reader.Read())
_tasktype = reader.CurrentTaskType;
reader.Close(false);
return _tasktype;
}

public static TaskType LoadTaskTypeByPk( int task_type_id )
{
return LoadTaskType( " task_type_id="+task_type_id );
}

public static TaskType LoadTaskTypeByPk( int task_type_id , IDbConnection conn)
{
return LoadTaskType(" task_type_id="+task_type_id , conn);
}

public void Save()
{
if (task_type_idChanged || task_type_nameChanged )
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
if (task_type_idChanged || task_type_nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Task_type( task_type_id,task_type_name ) values(");
lock (ConnectionFactory.connectionString) { this.task_type_id = ConnectionFactory.GetNextId();
qry.Append(this.task_type_id);
} qry.Append(",");
qry.Append(task_type_nameDbString);
qry.Append(");");

}
else
{
if (!(task_type_idChanged || task_type_nameChanged ))
return;
qry.Append("UPDATE Task_type set "); if ( task_type_nameChanged )
{
qry.Append("task_type_name ="+task_type_nameDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("task_type_id = "+task_type_idDbString);
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
cmd.CommandText = "DELETE Task_type where task_type_id = "+ task_type_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteTaskTypes(string where)
{
ConnectionFactory.ExecuteQuery("delete Task_type where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
task_type_id= 1,
task_type_name= 2
}
#endregion
public void BulkSave(List<TaskType> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Task_type";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(TaskType.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <TaskType> transList,ref DataTable dt)
{
foreach (TaskType tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["task_type_id"] =ConnectionFactory.GetNextId();
Row["task_type_name"] = tran.TaskTypeName;
dt.Rows.Add(Row);
} }
}
}
