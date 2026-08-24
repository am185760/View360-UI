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
public class TerminalType
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public TerminalType() { }
public TerminalType( string atm_type )
{
this.atm_type = atm_type;
this.atm_typeChanged = true;
}

#region members and properties for columns

#region AtmType
private bool atm_typeChanged = false;
private string atm_type;
public string AtmType
{
get { return atm_type; }
set { 
atm_type = value;
atm_typeChanged = true;
}
}
private string atm_typeDbString
{
get
{
if (this.atm_type!=null)
return string.Format("'{0}'",atm_type); else
return "null";
}
}
#endregion
#endregion

#region TerminalTypeReader
public class TerminalTypeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
TerminalType currentTerminalType;
Columns columns;
bool partialRead = false;
private TerminalTypeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public TerminalTypeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public TerminalTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentTerminalType; }

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
currentTerminalType = new TerminalType();
if (partialRead)
{ if ((columns & Columns.atm_type) == Columns.atm_type && reader["atm_type"]!=DBNull.Value)
currentTerminalType.atm_type =(string) reader["atm_type"]; 

} else
{
if (reader["atm_type"] != DBNull.Value)
currentTerminalType.atm_type = (string) reader["atm_type"]; 
} 

currentTerminalType.isNewEntity = false;
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

public TerminalType CurrentTerminalType
{
get{ return currentTerminalType; }
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


#region TerminalType functions

public static TerminalTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_type == (Columns.atm_type & columns))
qry.Append("atm_type,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Terminal_type ");

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
return new TerminalTypeReader(cmd.ExecuteReader(), conn, columns);
}

static public TerminalTypeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static TerminalTypeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_type from Terminal_type ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new TerminalTypeReader(cmd.ExecuteReader(), conn);
}

static public TerminalTypeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static TerminalType LoadTerminalType(string where)
{
TerminalTypeReader reader = TerminalType.ExecuteReader(where);
TerminalType _terminaltype = null;
if (reader.Read())
_terminaltype = reader.CurrentTerminalType;
reader.Close();
return _terminaltype;
}

public static TerminalType LoadTerminalType(string where, IDbConnection conn)
{
TerminalTypeReader reader = TerminalType.ExecuteReader(where, conn);
TerminalType _terminaltype = null;
if (reader.Read())
_terminaltype = reader.CurrentTerminalType;
reader.Close(false);
return _terminaltype;
}


public void Save()
{
if (atm_typeChanged )
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
if (atm_typeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Terminal_type( atm_type ) values(");
qry.Append(atm_typeDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Terminal_type!");
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

public static void DeleteTerminalTypes(string where)
{
ConnectionFactory.ExecuteQuery("delete Terminal_type where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_type= 1
}
#endregion
public void BulkSave(List<TerminalType> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Terminal_type";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(TerminalType.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <TerminalType> transList,ref DataTable dt)
{
foreach (TerminalType tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_type"] = tran.AtmType;
dt.Rows.Add(Row);
} }
}
}
