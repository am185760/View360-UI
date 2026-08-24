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
public class Token
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Token() { }
public Token( int nextid )
{
this.nextid = nextid;
this.nextidChanged = true;
}

#region members and properties for columns

#region Nextid
private bool nextidChanged = false;
private int nextid;
public int Nextid
{
get { return nextid; }
set { 
nextid = value;
nextidChanged = true;
}
}
private string nextidDbString
{
get
{
return nextid.ToString();
}
}
#endregion
#endregion

#region TokenReader
public class TokenReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Token currentToken;
Columns columns;
bool partialRead = false;
private TokenReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public TokenReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public TokenReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentToken; }

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
currentToken = new Token();
if (partialRead)
{ if ((columns & Columns.nextid) == Columns.nextid && reader["nextid"]!=DBNull.Value)
currentToken.nextid =(int) reader["nextid"]; 

} else
{
if (reader["nextid"] != DBNull.Value)
currentToken.nextid = (int) reader["nextid"]; 
} 

currentToken.isNewEntity = false;
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

public Token CurrentToken
{
get{ return currentToken; }
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


#region Token functions

public static TokenReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.nextid == (Columns.nextid & columns))
qry.Append("nextid,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Token ");

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
return new TokenReader(cmd.ExecuteReader(), conn, columns);
}

static public TokenReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static TokenReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select nextid from Token ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new TokenReader(cmd.ExecuteReader(), conn);
}

static public TokenReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Token LoadToken(string where)
{
TokenReader reader = Token.ExecuteReader(where);
Token _token = null;
if (reader.Read())
_token = reader.CurrentToken;
reader.Close();
return _token;
}

public static Token LoadToken(string where, IDbConnection conn)
{
TokenReader reader = Token.ExecuteReader(where, conn);
Token _token = null;
if (reader.Read())
_token = reader.CurrentToken;
reader.Close(false);
return _token;
}


public void Save()
{
if (nextidChanged )
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
if (nextidChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Token( nextid ) values(");
qry.Append(nextidDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Token!");
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

public static void DeleteTokens(string where)
{
ConnectionFactory.ExecuteQuery("delete Token where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
nextid= 1
}
#endregion
public void BulkSave(List<Token> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Token";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Token.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Token> transList,ref DataTable dt)
{
foreach (Token tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["nextid"] = tran.Nextid;
dt.Rows.Add(Row);
} }
}
}
