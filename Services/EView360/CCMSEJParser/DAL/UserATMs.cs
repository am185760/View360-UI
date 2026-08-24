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
public class UserATMs
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public UserATMs() { }
public UserATMs( int user_id,int aTM_id )
{
this.user_id = user_id;
this.user_idChanged = true;
this.aTM_id = aTM_id;
this.aTM_idChanged = true;
}
private UserATMs( int user_ATM_id,int user_id,int aTM_id )
{
this.user_ATM_id = user_ATM_id;
this.user_ATM_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.aTM_id = aTM_id;
this.aTM_idChanged = true;
}

#region members and properties for columns

#region UserATMId
private bool user_ATM_idChanged = false;
private int user_ATM_id;
public int UserATMId
{
get { return user_ATM_id; }
set { 
user_ATM_id = value;
user_ATM_idChanged = true;
}
}
private string user_ATM_idDbString
{
get
{
return user_ATM_id.ToString();
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
#region ATMId
private bool aTM_idChanged = false;
private int aTM_id;
public int ATMId
{
get { return aTM_id; }
set { 
aTM_id = value;
aTM_idChanged = true;
}
}
private string aTM_idDbString
{
get
{
return aTM_id.ToString();
}
}
#endregion
#endregion

#region UserATMsReader
public class UserATMsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
UserATMs currentUserATMs;
Columns columns;
bool partialRead = false;
private UserATMsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public UserATMsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public UserATMsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentUserATMs; }

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
currentUserATMs = new UserATMs();
if (partialRead)
{ if ((columns & Columns.user_ATM_id) == Columns.user_ATM_id && reader["user_ATM_id"]!=DBNull.Value)
currentUserATMs.user_ATM_id =(int) reader["user_ATM_id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentUserATMs.user_id =(int) reader["user_id"]; 
if ((columns & Columns.ATM_id) == Columns.ATM_id && reader["ATM_id"]!=DBNull.Value)
currentUserATMs.aTM_id =(int) reader["ATM_id"]; 

} else
{
if (reader["user_ATM_id"] != DBNull.Value)
currentUserATMs.user_ATM_id = (int) reader["user_ATM_id"]; 
if (reader["user_id"] != DBNull.Value)
currentUserATMs.user_id = (int) reader["user_id"]; 
if (reader["ATM_id"] != DBNull.Value)
currentUserATMs.aTM_id = (int) reader["ATM_id"]; 
} 

currentUserATMs.isNewEntity = false;
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

public UserATMs CurrentUserATMs
{
get{ return currentUserATMs; }
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


#region UserATMs functions

public static UserATMsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.user_ATM_id == (Columns.user_ATM_id & columns))
qry.Append("user_ATM_id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.ATM_id == (Columns.ATM_id & columns))
qry.Append("ATM_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from User_ATMs ");

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
return new UserATMsReader(cmd.ExecuteReader(), conn, columns);
}

static public UserATMsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static UserATMsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select user_ATM_id,user_id,ATM_id from User_ATMs ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new UserATMsReader(cmd.ExecuteReader(), conn);
}

static public UserATMsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static UserATMs LoadUserATMs(string where)
{
UserATMsReader reader = UserATMs.ExecuteReader(where);
UserATMs _useratms = null;
if (reader.Read())
_useratms = reader.CurrentUserATMs;
reader.Close();
return _useratms;
}

public static UserATMs LoadUserATMs(string where, IDbConnection conn)
{
UserATMsReader reader = UserATMs.ExecuteReader(where, conn);
UserATMs _useratms = null;
if (reader.Read())
_useratms = reader.CurrentUserATMs;
reader.Close(false);
return _useratms;
}

public static UserATMs LoadUserATMsByPk( int user_ATM_id )
{
return LoadUserATMs( " user_ATM_id="+user_ATM_id );
}

public static UserATMs LoadUserATMsByPk( int user_ATM_id , IDbConnection conn)
{
return LoadUserATMs(" user_ATM_id="+user_ATM_id , conn);
}

public void Save()
{
if (user_ATM_idChanged || user_idChanged || aTM_idChanged )
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
if (user_ATM_idChanged || user_idChanged || aTM_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into User_ATMs( user_ATM_id,user_id,ATM_id ) values(");
lock (ConnectionFactory.connectionString) { this.user_ATM_id = ConnectionFactory.GetNextId();
qry.Append(this.user_ATM_id);
} qry.Append(",");
qry.Append(user_idDbString+",");
qry.Append(aTM_idDbString);
qry.Append(");");

}
else
{
if (!(user_ATM_idChanged || user_idChanged || aTM_idChanged ))
return;
qry.Append("UPDATE User_ATMs set "); if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( aTM_idChanged )
{
qry.Append("ATM_id ="+aTM_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("user_ATM_id = "+user_ATM_idDbString);
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
cmd.CommandText = "DELETE User_ATMs where user_ATM_id = "+ user_ATM_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteUserATMss(string where)
{
ConnectionFactory.ExecuteQuery("delete User_ATMs where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
user_ATM_id= 1,
user_id= 2,
ATM_id= 4
}
#endregion
public void BulkSave(List<UserATMs> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "User_ATMs";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(UserATMs.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <UserATMs> transList,ref DataTable dt)
{
foreach (UserATMs tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["user_ATM_id"] =ConnectionFactory.GetNextId();
Row["user_id"] = tran.UserId;
Row["aTM_id"] = tran.ATMId;
dt.Rows.Add(Row);
} }
}
}
