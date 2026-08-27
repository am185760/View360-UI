using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;

namespace Avanza.CCMS.DAL
{
[Serializable()]
public class Server
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Server() { }
public Server( int? server_id ) 
{
}
public Server( string server_name,string ftp_username,string ftp_password,string ftp_url,string ftp_archive_url )
{
this.server_name = server_name;
this.server_nameChanged = true;
this.ftp_username = ftp_username;
this.ftp_usernameChanged = true;
this.ftp_password = ftp_password;
this.ftp_passwordChanged = true;
this.ftp_url = ftp_url;
this.ftp_urlChanged = true;
this.ftp_archive_url = ftp_archive_url;
this.ftp_archive_urlChanged = true;
}
private Server( int? server_id,string server_name,string ftp_username,string ftp_password,string ftp_url,string ftp_archive_url )
{
this.server_id = server_id;
this.server_idChanged = true;
this.server_name = server_name;
this.server_nameChanged = true;
this.ftp_username = ftp_username;
this.ftp_usernameChanged = true;
this.ftp_password = ftp_password;
this.ftp_passwordChanged = true;
this.ftp_url = ftp_url;
this.ftp_urlChanged = true;
this.ftp_archive_url = ftp_archive_url;
this.ftp_archive_urlChanged = true;
}

#region members and properties for columns

#region ServerId
private bool server_idChanged = false;
private int? server_id;
public int? ServerId
{
get { return server_id; }
set { 
server_id = value;
server_idChanged = true;
}
}
private string server_idDbString
{
get
{
if (this.server_id.HasValue)
return server_id.ToString();
else
return "null";
}
}
#endregion
#region ServerName
private bool server_nameChanged = false;
private string server_name;
public string ServerName
{
get { return server_name; }
set { 
server_name = value;
server_nameChanged = true;
}
}
private string server_nameDbString
{
get
{
if (this.server_name!=null)
return string.Format("'{0}'",server_name); else
return "null";
}
}
#endregion
#region FtpUsername
private bool ftp_usernameChanged = false;
private string ftp_username;
public string FtpUsername
{
get { return ftp_username; }
set { 
ftp_username = value;
ftp_usernameChanged = true;
}
}
private string ftp_usernameDbString
{
get
{
if (this.ftp_username!=null)
return string.Format("'{0}'",ftp_username); else
return "null";
}
}
#endregion
#region FtpPassword
private bool ftp_passwordChanged = false;
private string ftp_password;
public string FtpPassword
{
get { return ftp_password; }
set { 
ftp_password = value;
ftp_passwordChanged = true;
}
}
private string ftp_passwordDbString
{
get
{
if (this.ftp_password!=null)
return string.Format("'{0}'",ftp_password); else
return "null";
}
}
#endregion
#region FtpUrl
private bool ftp_urlChanged = false;
private string ftp_url;
public string FtpUrl
{
get { return ftp_url; }
set { 
ftp_url = value;
ftp_urlChanged = true;
}
}
private string ftp_urlDbString
{
get
{
if (this.ftp_url!=null)
return string.Format("'{0}'",ftp_url); else
return "null";
}
}
#endregion
#region FtpArchiveUrl
private bool ftp_archive_urlChanged = false;
private string ftp_archive_url;
public string FtpArchiveUrl
{
get { return ftp_archive_url; }
set { 
ftp_archive_url = value;
ftp_archive_urlChanged = true;
}
}
private string ftp_archive_urlDbString
{
get
{
if (this.ftp_archive_url!=null)
return string.Format("'{0}'",ftp_archive_url); else
return "null";
}
}
#endregion
#endregion

#region ServerReader
public class ServerReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Server currentServer;
Columns columns;
bool partialRead = false;
private ServerReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ServerReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ServerReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentServer; }

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
currentServer = new Server();
if (partialRead)
{ if ((columns & Columns.server_id) == Columns.server_id && reader["server_id"]!=DBNull.Value)
currentServer.server_id =(int?) reader["server_id"]; 
if ((columns & Columns.server_name) == Columns.server_name && reader["server_name"]!=DBNull.Value)
currentServer.server_name =(string) reader["server_name"]; 
if ((columns & Columns.ftp_username) == Columns.ftp_username && reader["ftp_username"]!=DBNull.Value)
currentServer.ftp_username =(string) reader["ftp_username"]; 
if ((columns & Columns.ftp_password) == Columns.ftp_password && reader["ftp_password"]!=DBNull.Value)
currentServer.ftp_password =(string) reader["ftp_password"]; 
if ((columns & Columns.ftp_url) == Columns.ftp_url && reader["ftp_url"]!=DBNull.Value)
currentServer.ftp_url =(string) reader["ftp_url"]; 
if ((columns & Columns.ftp_archive_url) == Columns.ftp_archive_url && reader["ftp_archive_url"]!=DBNull.Value)
currentServer.ftp_archive_url =(string) reader["ftp_archive_url"]; 

} else
{
if (reader["server_id"] != DBNull.Value)
currentServer.server_id = (int?) reader["server_id"]; 
if (reader["server_name"] != DBNull.Value)
currentServer.server_name = (string) reader["server_name"]; 
if (reader["ftp_username"] != DBNull.Value)
currentServer.ftp_username = (string) reader["ftp_username"]; 
if (reader["ftp_password"] != DBNull.Value)
currentServer.ftp_password = (string) reader["ftp_password"]; 
if (reader["ftp_url"] != DBNull.Value)
currentServer.ftp_url = (string) reader["ftp_url"]; 
if (reader["ftp_archive_url"] != DBNull.Value)
currentServer.ftp_archive_url = (string) reader["ftp_archive_url"]; 
} 

currentServer.isNewEntity = false;
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

public Server CurrentServer
{
get{ return currentServer; }
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


#region Server functions

public static ServerReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.server_id == (Columns.server_id & columns))
qry.Append("server_id,");
if (Columns.server_name == (Columns.server_name & columns))
qry.Append("server_name,");
if (Columns.ftp_username == (Columns.ftp_username & columns))
qry.Append("ftp_username,");
if (Columns.ftp_password == (Columns.ftp_password & columns))
qry.Append("ftp_password,");
if (Columns.ftp_url == (Columns.ftp_url & columns))
qry.Append("ftp_url,");
if (Columns.ftp_archive_url == (Columns.ftp_archive_url & columns))
qry.Append("ftp_archive_url,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Server ");

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
return new ServerReader(cmd.ExecuteReader(), conn, columns);
}

static public ServerReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ServerReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select server_id,server_name,ftp_username,ftp_password,ftp_url,ftp_archive_url from Server ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ServerReader(cmd.ExecuteReader(), conn);
}

static public ServerReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Server LoadServer(string where)
{
ServerReader reader = Server.ExecuteReader(where);
Server _server = null;
if (reader.Read())
_server = reader.CurrentServer;
reader.Close();
return _server;
}

public static Server LoadServer(string where, IDbConnection conn)
{
ServerReader reader = Server.ExecuteReader(where, conn);
Server _server = null;
if (reader.Read())
_server = reader.CurrentServer;
reader.Close(false);
return _server;
}

public static Server LoadServerByPk( int server_id )
{
return LoadServer( " server_id="+server_id );
}

public static Server LoadServerByPk( int server_id , IDbConnection conn)
{
return LoadServer(" server_id="+server_id , conn);
}

public void Save()
{
if (server_idChanged || server_nameChanged || ftp_usernameChanged || ftp_passwordChanged || ftp_urlChanged || ftp_archive_urlChanged )
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
if (server_idChanged || server_nameChanged || ftp_usernameChanged || ftp_passwordChanged || ftp_urlChanged || ftp_archive_urlChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Server( server_id,server_name,ftp_username,ftp_password,ftp_url,ftp_archive_url ) values(");
lock (ConnectionFactory.connectionString) { this.server_id = ConnectionFactory.GetNextId();
qry.Append(this.server_id);
} qry.Append(",");
qry.Append(server_nameDbString+",");
qry.Append(ftp_usernameDbString+",");
qry.Append(ftp_passwordDbString+",");
qry.Append(ftp_urlDbString+",");
qry.Append(ftp_archive_urlDbString);
qry.Append(");");

}
else
{
if (!(server_idChanged || server_nameChanged || ftp_usernameChanged || ftp_passwordChanged || ftp_urlChanged || ftp_archive_urlChanged ))
return;
qry.Append("UPDATE Server set "); if ( server_nameChanged )
{
qry.Append("server_name ="+server_nameDbString);
qry.Append(",");
}

if ( ftp_usernameChanged )
{
qry.Append("ftp_username ="+ftp_usernameDbString);
qry.Append(",");
}

if ( ftp_passwordChanged )
{
qry.Append("ftp_password ="+ftp_passwordDbString);
qry.Append(",");
}

if ( ftp_urlChanged )
{
qry.Append("ftp_url ="+ftp_urlDbString);
qry.Append(",");
}

if ( ftp_archive_urlChanged )
{
qry.Append("ftp_archive_url ="+ftp_archive_urlDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("server_id = "+server_idDbString);
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
cmd.CommandText = "DELETE Server where server_id = "+ server_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteServers(string where)
{
ConnectionFactory.ExecuteQuery("delete Server where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
server_id= 1,
server_name= 2,
ftp_username= 4,
ftp_password= 8,
ftp_url= 16,
ftp_archive_url= 32
}
#endregion
}
}
