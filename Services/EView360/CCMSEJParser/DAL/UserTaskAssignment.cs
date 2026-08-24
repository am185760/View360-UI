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
public class UserTaskAssignment
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public UserTaskAssignment() { }
public UserTaskAssignment( int user_task_id,int user_id )
{
this.user_task_id = user_task_id;
this.user_task_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
}
private UserTaskAssignment( int user_task_assignment_id,int user_task_id,int user_id )
{
this.user_task_assignment_id = user_task_assignment_id;
this.user_task_assignment_idChanged = true;
this.user_task_id = user_task_id;
this.user_task_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
}

#region members and properties for columns

#region UserTaskAssignmentId
private bool user_task_assignment_idChanged = false;
private int user_task_assignment_id;
public int UserTaskAssignmentId
{
get { return user_task_assignment_id; }
set { 
user_task_assignment_id = value;
user_task_assignment_idChanged = true;
}
}
private string user_task_assignment_idDbString
{
get
{
return user_task_assignment_id.ToString();
}
}
#endregion
#region UserTaskId
private bool user_task_idChanged = false;
private int user_task_id;
public int UserTaskId
{
get { return user_task_id; }
set { 
user_task_id = value;
user_task_idChanged = true;
}
}
private string user_task_idDbString
{
get
{
return user_task_id.ToString();
}
}
#endregion
#region UserId
private bool user_idChanged = false;
private int user_id;
public int UserId
{
get { return user_id; }
set { 
user_id = value;
user_idChanged = true;
}
}
private string user_idDbString
{
get
{
return user_id.ToString();
}
}
#endregion
#endregion

#region UserTaskAssignmentReader
public class UserTaskAssignmentReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
UserTaskAssignment currentUserTaskAssignment;
Columns columns;
bool partialRead = false;
private UserTaskAssignmentReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public UserTaskAssignmentReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public UserTaskAssignmentReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentUserTaskAssignment; }

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
currentUserTaskAssignment = new UserTaskAssignment();
if (partialRead)
{ if ((columns & Columns.user_task_assignment_id) == Columns.user_task_assignment_id && reader["user_task_assignment_id"]!=DBNull.Value)
currentUserTaskAssignment.user_task_assignment_id =(int) reader["user_task_assignment_id"]; 
if ((columns & Columns.user_task_id) == Columns.user_task_id && reader["user_task_id"]!=DBNull.Value)
currentUserTaskAssignment.user_task_id =(int) reader["user_task_id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentUserTaskAssignment.user_id =(int) reader["user_id"]; 

} else
{
if (reader["user_task_assignment_id"] != DBNull.Value)
currentUserTaskAssignment.user_task_assignment_id = (int) reader["user_task_assignment_id"]; 
if (reader["user_task_id"] != DBNull.Value)
currentUserTaskAssignment.user_task_id = (int) reader["user_task_id"]; 
if (reader["user_id"] != DBNull.Value)
currentUserTaskAssignment.user_id = (int) reader["user_id"]; 
} 

currentUserTaskAssignment.isNewEntity = false;
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

public UserTaskAssignment CurrentUserTaskAssignment
{
get{ return currentUserTaskAssignment; }
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


#region UserTaskAssignment functions

public static UserTaskAssignmentReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.user_task_assignment_id == (Columns.user_task_assignment_id & columns))
qry.Append("user_task_assignment_id,");
if (Columns.user_task_id == (Columns.user_task_id & columns))
qry.Append("user_task_id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from User_task_assignment ");

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
return new UserTaskAssignmentReader(cmd.ExecuteReader(), conn, columns);
}

static public UserTaskAssignmentReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static UserTaskAssignmentReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select user_task_assignment_id,user_task_id,user_id from User_task_assignment ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new UserTaskAssignmentReader(cmd.ExecuteReader(), conn);
}

static public UserTaskAssignmentReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static UserTaskAssignment LoadUserTaskAssignment(string where)
{
UserTaskAssignmentReader reader = UserTaskAssignment.ExecuteReader(where);
UserTaskAssignment _usertaskassignment = null;
if (reader.Read())
_usertaskassignment = reader.CurrentUserTaskAssignment;
reader.Close();
return _usertaskassignment;
}

public static UserTaskAssignment LoadUserTaskAssignment(string where, IDbConnection conn)
{
UserTaskAssignmentReader reader = UserTaskAssignment.ExecuteReader(where, conn);
UserTaskAssignment _usertaskassignment = null;
if (reader.Read())
_usertaskassignment = reader.CurrentUserTaskAssignment;
reader.Close(false);
return _usertaskassignment;
}

public static UserTaskAssignment LoadUserTaskAssignmentByPk( int user_task_assignment_id )
{
return LoadUserTaskAssignment( " user_task_assignment_id="+user_task_assignment_id );
}

public static UserTaskAssignment LoadUserTaskAssignmentByPk( int user_task_assignment_id , IDbConnection conn)
{
return LoadUserTaskAssignment(" user_task_assignment_id="+user_task_assignment_id , conn);
}

public void Save()
{
if (user_task_assignment_idChanged || user_task_idChanged || user_idChanged )
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
if (user_task_assignment_idChanged || user_task_idChanged || user_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into User_task_assignment( user_task_assignment_id,user_task_id,user_id ) values(");
lock (ConnectionFactory.connectionString) { this.user_task_assignment_id = ConnectionFactory.GetNextId();
qry.Append(this.user_task_assignment_id);
} qry.Append(",");
qry.Append(user_task_idDbString+",");
qry.Append(user_idDbString);
qry.Append(");");

}
else
{
if (!(user_task_assignment_idChanged || user_task_idChanged || user_idChanged ))
return;
qry.Append("UPDATE User_task_assignment set "); if ( user_task_idChanged )
{
qry.Append("user_task_id ="+user_task_idDbString);
qry.Append(",");
}

if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("user_task_assignment_id = "+user_task_assignment_idDbString);
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
cmd.CommandText = "DELETE User_task_assignment where user_task_assignment_id = "+ user_task_assignment_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteUserTaskAssignments(string where)
{
ConnectionFactory.ExecuteQuery("delete User_task_assignment where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
user_task_assignment_id= 1,
user_task_id= 2,
user_id= 4
}
#endregion
public void BulkSave(List<UserTaskAssignment> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "User_task_assignment";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(UserTaskAssignment.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <UserTaskAssignment> transList,ref DataTable dt)
{
foreach (UserTaskAssignment tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["user_task_assignment_id"] =ConnectionFactory.GetNextId();
Row["user_task_id"] = tran.UserTaskId;
Row["user_id"] = tran.UserId;
dt.Rows.Add(Row);
} }
}
}
