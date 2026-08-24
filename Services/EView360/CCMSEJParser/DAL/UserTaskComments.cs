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
public class UserTaskComments
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public UserTaskComments() { }
public UserTaskComments( int user_task_comments_id,int user_id,DateTime creation_time,int user_task_id ) 
{
this.user_id = user_id;
this.user_idChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.user_task_id = user_task_id;
this.user_task_idChanged = true;
}
public UserTaskComments( int user_id,string comments,DateTime creation_time,int user_task_id )
{
this.user_id = user_id;
this.user_idChanged = true;
this.comments = comments;
this.commentsChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.user_task_id = user_task_id;
this.user_task_idChanged = true;
}
private UserTaskComments( int user_task_comments_id,int user_id,string comments,DateTime creation_time,int user_task_id )
{
this.user_task_comments_id = user_task_comments_id;
this.user_task_comments_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.comments = comments;
this.commentsChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.user_task_id = user_task_id;
this.user_task_idChanged = true;
}

#region members and properties for columns

#region UserTaskCommentsId
private bool user_task_comments_idChanged = false;
private int user_task_comments_id;
public int UserTaskCommentsId
{
get { return user_task_comments_id; }
set { 
user_task_comments_id = value;
user_task_comments_idChanged = true;
}
}
private string user_task_comments_idDbString
{
get
{
return user_task_comments_id.ToString();
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
#region Comments
private bool commentsChanged = false;
private string comments;
public string Comments
{
get { return comments; }
set { 
comments = value;
commentsChanged = true;
}
}
private string commentsDbString
{
get
{
if (this.comments!=null)
return string.Format("'{0}'",comments); else
return "null";
}
}
#endregion
#region CreationTime
private bool creation_timeChanged = false;
private DateTime creation_time;
public DateTime CreationTime
{
get { return creation_time; }
set { 
creation_time = value;
creation_timeChanged = true;
}
}
private string creation_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#endregion

#region UserTaskCommentsReader
public class UserTaskCommentsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
UserTaskComments currentUserTaskComments;
Columns columns;
bool partialRead = false;
private UserTaskCommentsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public UserTaskCommentsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public UserTaskCommentsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentUserTaskComments; }

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
currentUserTaskComments = new UserTaskComments();
if (partialRead)
{ if ((columns & Columns.user_task_comments_id) == Columns.user_task_comments_id && reader["user_task_comments_id"]!=DBNull.Value)
currentUserTaskComments.user_task_comments_id =(int) reader["user_task_comments_id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentUserTaskComments.user_id =(int) reader["user_id"]; 
if ((columns & Columns.comments) == Columns.comments && reader["comments"]!=DBNull.Value)
currentUserTaskComments.comments =(string) reader["comments"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentUserTaskComments.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.user_task_id) == Columns.user_task_id && reader["user_task_id"]!=DBNull.Value)
currentUserTaskComments.user_task_id =(int) reader["user_task_id"]; 

} else
{
if (reader["user_task_comments_id"] != DBNull.Value)
currentUserTaskComments.user_task_comments_id = (int) reader["user_task_comments_id"]; 
if (reader["user_id"] != DBNull.Value)
currentUserTaskComments.user_id = (int) reader["user_id"]; 
if (reader["comments"] != DBNull.Value)
currentUserTaskComments.comments = (string) reader["comments"]; 
if (reader["creation_time"] != DBNull.Value)
currentUserTaskComments.creation_time = (DateTime) reader["creation_time"]; 
if (reader["user_task_id"] != DBNull.Value)
currentUserTaskComments.user_task_id = (int) reader["user_task_id"]; 
} 

currentUserTaskComments.isNewEntity = false;
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

public UserTaskComments CurrentUserTaskComments
{
get{ return currentUserTaskComments; }
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


#region UserTaskComments functions

public static UserTaskCommentsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.user_task_comments_id == (Columns.user_task_comments_id & columns))
qry.Append("user_task_comments_id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.comments == (Columns.comments & columns))
qry.Append("comments,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.user_task_id == (Columns.user_task_id & columns))
qry.Append("user_task_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from User_task_comments ");

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
return new UserTaskCommentsReader(cmd.ExecuteReader(), conn, columns);
}

static public UserTaskCommentsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static UserTaskCommentsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select user_task_comments_id,user_id,comments,creation_time,user_task_id from User_task_comments ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new UserTaskCommentsReader(cmd.ExecuteReader(), conn);
}

static public UserTaskCommentsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static UserTaskComments LoadUserTaskComments(string where)
{
UserTaskCommentsReader reader = UserTaskComments.ExecuteReader(where);
UserTaskComments _usertaskcomments = null;
if (reader.Read())
_usertaskcomments = reader.CurrentUserTaskComments;
reader.Close();
return _usertaskcomments;
}

public static UserTaskComments LoadUserTaskComments(string where, IDbConnection conn)
{
UserTaskCommentsReader reader = UserTaskComments.ExecuteReader(where, conn);
UserTaskComments _usertaskcomments = null;
if (reader.Read())
_usertaskcomments = reader.CurrentUserTaskComments;
reader.Close(false);
return _usertaskcomments;
}

public static UserTaskComments LoadUserTaskCommentsByPk( int user_task_comments_id )
{
return LoadUserTaskComments( " user_task_comments_id="+user_task_comments_id );
}

public static UserTaskComments LoadUserTaskCommentsByPk( int user_task_comments_id , IDbConnection conn)
{
return LoadUserTaskComments(" user_task_comments_id="+user_task_comments_id , conn);
}

public void Save()
{
if (user_task_comments_idChanged || user_idChanged || commentsChanged || creation_timeChanged || user_task_idChanged )
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
if (user_task_comments_idChanged || user_idChanged || commentsChanged || creation_timeChanged || user_task_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into User_task_comments( user_task_comments_id,user_id,comments,creation_time,user_task_id ) values(");
lock (ConnectionFactory.connectionString) { this.user_task_comments_id = ConnectionFactory.GetNextId();
qry.Append(this.user_task_comments_id);
} qry.Append(",");
qry.Append(user_idDbString+",");
qry.Append(commentsDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(user_task_idDbString);
qry.Append(");");

}
else
{
if (!(user_task_comments_idChanged || user_idChanged || commentsChanged || creation_timeChanged || user_task_idChanged ))
return;
qry.Append("UPDATE User_task_comments set "); if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( commentsChanged )
{
qry.Append("comments ="+commentsDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( user_task_idChanged )
{
qry.Append("user_task_id ="+user_task_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("user_task_comments_id = "+user_task_comments_idDbString);
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
cmd.CommandText = "DELETE User_task_comments where user_task_comments_id = "+ user_task_comments_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteUserTaskCommentss(string where)
{
ConnectionFactory.ExecuteQuery("delete User_task_comments where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
user_task_comments_id= 1,
user_id= 2,
comments= 4,
creation_time= 8,
user_task_id= 16
}
#endregion
public void BulkSave(List<UserTaskComments> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "User_task_comments";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(UserTaskComments.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <UserTaskComments> transList,ref DataTable dt)
{
foreach (UserTaskComments tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["user_task_comments_id"] =ConnectionFactory.GetNextId();
Row["user_id"] = tran.UserId;
Row["comments"] = tran.Comments;
Row["creation_time"] = tran.CreationTime;
Row["user_task_id"] = tran.UserTaskId;
dt.Rows.Add(Row);
} }
}
}
