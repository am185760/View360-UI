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
public class UserSetting
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public UserSetting() { }
public UserSetting( int user_id,int tree_panel_width )
{
this.user_id = user_id;
this.user_idChanged = true;
this.tree_panel_width = tree_panel_width;
this.tree_panel_widthChanged = true;
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
#region TreePanelWidth
private bool tree_panel_widthChanged = false;
private int tree_panel_width;
public int TreePanelWidth
{
get { return tree_panel_width; }
set { 
tree_panel_width = value;
tree_panel_widthChanged = true;
}
}
private string tree_panel_widthDbString
{
get
{
return tree_panel_width.ToString();
}
}
#endregion
#endregion

#region UserSettingReader
public class UserSettingReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
UserSetting currentUserSetting;
Columns columns;
bool partialRead = false;
private UserSettingReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public UserSettingReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public UserSettingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentUserSetting; }

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
currentUserSetting = new UserSetting();
if (partialRead)
{ if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentUserSetting.user_id =(int) reader["user_id"]; 
if ((columns & Columns.tree_panel_width) == Columns.tree_panel_width && reader["tree_panel_width"]!=DBNull.Value)
currentUserSetting.tree_panel_width =(int) reader["tree_panel_width"]; 

} else
{
if (reader["user_id"] != DBNull.Value)
currentUserSetting.user_id = (int) reader["user_id"]; 
if (reader["tree_panel_width"] != DBNull.Value)
currentUserSetting.tree_panel_width = (int) reader["tree_panel_width"]; 
} 

currentUserSetting.isNewEntity = false;
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

public UserSetting CurrentUserSetting
{
get{ return currentUserSetting; }
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


#region UserSetting functions

public static UserSettingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.tree_panel_width == (Columns.tree_panel_width & columns))
qry.Append("tree_panel_width,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from User_setting ");

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
return new UserSettingReader(cmd.ExecuteReader(), conn, columns);
}

static public UserSettingReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static UserSettingReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select user_id,tree_panel_width from User_setting ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new UserSettingReader(cmd.ExecuteReader(), conn);
}

static public UserSettingReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static UserSetting LoadUserSetting(string where)
{
UserSettingReader reader = UserSetting.ExecuteReader(where);
UserSetting _usersetting = null;
if (reader.Read())
_usersetting = reader.CurrentUserSetting;
reader.Close();
return _usersetting;
}

public static UserSetting LoadUserSetting(string where, IDbConnection conn)
{
UserSettingReader reader = UserSetting.ExecuteReader(where, conn);
UserSetting _usersetting = null;
if (reader.Read())
_usersetting = reader.CurrentUserSetting;
reader.Close(false);
return _usersetting;
}

public static UserSetting LoadUserSettingByPk( int user_id )
{
return LoadUserSetting( " user_id="+user_id );
}

public static UserSetting LoadUserSettingByPk( int user_id , IDbConnection conn)
{
return LoadUserSetting(" user_id="+user_id , conn);
}

public void Save()
{
if (user_idChanged || tree_panel_widthChanged )
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
if (user_idChanged || tree_panel_widthChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into User_setting( user_id,tree_panel_width ) values(");
qry.Append(user_idDbString+",");
qry.Append(tree_panel_widthDbString);
qry.Append(");");

}
else
{
if (!(user_idChanged || tree_panel_widthChanged ))
return;
qry.Append("UPDATE User_setting set "); if ( tree_panel_widthChanged )
{
qry.Append("tree_panel_width ="+tree_panel_widthDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("user_id = "+user_idDbString);
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
cmd.CommandText = "DELETE User_setting where user_id = "+ user_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteUserSettings(string where)
{
ConnectionFactory.ExecuteQuery("delete User_setting where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
user_id= 1,
tree_panel_width= 2
}
#endregion
public void BulkSave(List<UserSetting> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "User_setting";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(UserSetting.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <UserSetting> transList,ref DataTable dt)
{
foreach (UserSetting tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["user_id"] = tran.UserId;
Row["tree_panel_width"] = tran.TreePanelWidth;
dt.Rows.Add(Row);
} }
}
}
