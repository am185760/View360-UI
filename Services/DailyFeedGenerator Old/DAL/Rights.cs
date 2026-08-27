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
public class Rights
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Rights() { }
public Rights( int right_id ) 
{
}
public Rights( string name )
{
this.name = name;
this.nameChanged = true;
}
private Rights( int right_id,string name )
{
this.right_id = right_id;
this.right_idChanged = true;
this.name = name;
this.nameChanged = true;
}

#region members and properties for columns

#region RightId
private bool right_idChanged = false;
private int right_id;
public int RightId
{
get { return right_id; }
set { 
right_id = value;
right_idChanged = true;
}
}
private string right_idDbString
{
get
{
return right_id.ToString();
}
}
#endregion
#region Name
private bool nameChanged = false;
private string name;
public string Name
{
get { return name; }
set { 
name = value;
nameChanged = true;
}
}
private string nameDbString
{
get
{
if (this.name!=null)
return string.Format("'{0}'",name); else
return "null";
}
}
#endregion
#endregion

#region RightsReader
public class RightsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Rights currentRights;
Columns columns;
bool partialRead = false;
private RightsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public RightsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public RightsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentRights; }

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
currentRights = new Rights();
if (partialRead)
{ if ((columns & Columns.right_id) == Columns.right_id && reader["right_id"]!=DBNull.Value)
currentRights.right_id =(int) reader["right_id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentRights.name =(string) reader["name"]; 

} else
{
if (reader["right_id"] != DBNull.Value)
currentRights.right_id = (int) reader["right_id"]; 
if (reader["name"] != DBNull.Value)
currentRights.name = (string) reader["name"]; 
} 

currentRights.isNewEntity = false;
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

public Rights CurrentRights
{
get{ return currentRights; }
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


#region Rights functions

public static RightsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.right_id == (Columns.right_id & columns))
qry.Append("right_id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Rights ");

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
return new RightsReader(cmd.ExecuteReader(), conn, columns);
}

static public RightsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static RightsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select right_id,name from Rights ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new RightsReader(cmd.ExecuteReader(), conn);
}

static public RightsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Rights LoadRights(string where)
{
RightsReader reader = Rights.ExecuteReader(where);
Rights _rights = null;
if (reader.Read())
_rights = reader.CurrentRights;
reader.Close();
return _rights;
}

public static Rights LoadRights(string where, IDbConnection conn)
{
RightsReader reader = Rights.ExecuteReader(where, conn);
Rights _rights = null;
if (reader.Read())
_rights = reader.CurrentRights;
reader.Close(false);
return _rights;
}

public static Rights LoadRightsByPk( int right_id )
{
return LoadRights( " right_id="+right_id );
}

public static Rights LoadRightsByPk( int right_id , IDbConnection conn)
{
return LoadRights(" right_id="+right_id , conn);
}

public void Save()
{
if (right_idChanged || nameChanged )
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
if (right_idChanged || nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Rights( right_id,name ) values(");
lock (ConnectionFactory.connectionString) { this.right_id = ConnectionFactory.GetNextId();
qry.Append(this.right_id);
} qry.Append(",");
qry.Append(nameDbString);
qry.Append(");");

}
else
{
if (!(right_idChanged || nameChanged ))
return;
qry.Append("UPDATE Rights set "); if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("right_id = "+right_idDbString);
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
cmd.CommandText = "DELETE Rights where right_id = "+ right_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteRightss(string where)
{
ConnectionFactory.ExecuteQuery("delete Rights where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
right_id= 1,
name= 2
}
#endregion
public void BulkSave(List<Rights> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Rights";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Rights.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Rights> transList,ref DataTable dt)
{
foreach (Rights tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["right_id"] =ConnectionFactory.GetNextId();
Row["name"] = tran.Name;
dt.Rows.Add(Row);
} }
}
}
