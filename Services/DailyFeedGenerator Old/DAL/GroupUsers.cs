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
public class GroupUsers
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public GroupUsers() { }
public GroupUsers( int user_id,int group_id )
{
this.user_id = user_id;
this.user_idChanged = true;
this.group_id = group_id;
this.group_idChanged = true;
}

#region members and properties for columns

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
#region GroupId
private bool group_idChanged = false;
private int group_id;
public int GroupId
{
get { return group_id; }
set { 
group_id = value;
group_idChanged = true;
}
}
private string group_idDbString
{
get
{
return group_id.ToString();
}
}
#endregion
#endregion

#region GroupUsersReader
public class GroupUsersReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
GroupUsers currentGroupUsers;
Columns columns;
bool partialRead = false;
private GroupUsersReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public GroupUsersReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public GroupUsersReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentGroupUsers; }

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
currentGroupUsers = new GroupUsers();
if (partialRead)
{ if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentGroupUsers.user_id =(int) reader["user_id"]; 
if ((columns & Columns.group_id) == Columns.group_id && reader["group_id"]!=DBNull.Value)
currentGroupUsers.group_id =(int) reader["group_id"]; 

} else
{
if (reader["user_id"] != DBNull.Value)
currentGroupUsers.user_id = (int) reader["user_id"]; 
if (reader["group_id"] != DBNull.Value)
currentGroupUsers.group_id = (int) reader["group_id"]; 
} 

currentGroupUsers.isNewEntity = false;
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

public GroupUsers CurrentGroupUsers
{
get{ return currentGroupUsers; }
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


#region GroupUsers functions

public static GroupUsersReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.group_id == (Columns.group_id & columns))
qry.Append("group_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Group_users ");

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
return new GroupUsersReader(cmd.ExecuteReader(), conn, columns);
}

static public GroupUsersReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static GroupUsersReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select user_id,group_id from Group_users ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new GroupUsersReader(cmd.ExecuteReader(), conn);
}

static public GroupUsersReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static GroupUsers LoadGroupUsers(string where)
{
GroupUsersReader reader = GroupUsers.ExecuteReader(where);
GroupUsers _groupusers = null;
if (reader.Read())
_groupusers = reader.CurrentGroupUsers;
reader.Close();
return _groupusers;
}

public static GroupUsers LoadGroupUsers(string where, IDbConnection conn)
{
GroupUsersReader reader = GroupUsers.ExecuteReader(where, conn);
GroupUsers _groupusers = null;
if (reader.Read())
_groupusers = reader.CurrentGroupUsers;
reader.Close(false);
return _groupusers;
}


public void Save()
{
if (user_idChanged || group_idChanged )
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
if (user_idChanged || group_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Group_users( user_id,group_id ) values(");
qry.Append(user_idDbString+",");
qry.Append(group_idDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Group_users!");
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
throw new Exception("Could not delete because no primary key is defined");
}

public static void DeleteGroupUserss(string where)
{
ConnectionFactory.ExecuteQuery("delete Group_users where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
user_id= 1,
group_id= 2
}
#endregion
public void BulkSave(List<GroupUsers> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Group_users";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(GroupUsers.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <GroupUsers> transList,ref DataTable dt)
{
foreach (GroupUsers tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["user_id"] = tran.UserId;
Row["group_id"] = tran.GroupId;
dt.Rows.Add(Row);
} }
}
}
