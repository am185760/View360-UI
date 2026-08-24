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
public class TransactionType
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public TransactionType() { }
public TransactionType( int transaction_type_id ) 
{
}
public TransactionType( string transaction_type_name )
{
this.transaction_type_name = transaction_type_name;
this.transaction_type_nameChanged = true;
}
private TransactionType( int transaction_type_id,string transaction_type_name )
{
this.transaction_type_id = transaction_type_id;
this.transaction_type_idChanged = true;
this.transaction_type_name = transaction_type_name;
this.transaction_type_nameChanged = true;
}

#region members and properties for columns

#region TransactionTypeId
private bool transaction_type_idChanged = false;
private int transaction_type_id;
public int TransactionTypeId
{
get { return transaction_type_id; }
set { 
transaction_type_id = value;
transaction_type_idChanged = true;
}
}
private string transaction_type_idDbString
{
get
{
return transaction_type_id.ToString();
}
}
#endregion
#region TransactionTypeName
private bool transaction_type_nameChanged = false;
private string transaction_type_name;
public string TransactionTypeName
{
get { return transaction_type_name; }
set { 
transaction_type_name = value;
transaction_type_nameChanged = true;
}
}
private string transaction_type_nameDbString
{
get
{
if (this.transaction_type_name!=null)
return string.Format("'{0}'",transaction_type_name); else
return "null";
}
}
#endregion
#endregion

#region TransactionTypeReader
public class TransactionTypeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
TransactionType currentTransactionType;
Columns columns;
bool partialRead = false;
private TransactionTypeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public TransactionTypeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public TransactionTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentTransactionType; }

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
currentTransactionType = new TransactionType();
if (partialRead)
{ if ((columns & Columns.transaction_type_id) == Columns.transaction_type_id && reader["transaction_type_id"]!=DBNull.Value)
currentTransactionType.transaction_type_id =(int) reader["transaction_type_id"]; 
if ((columns & Columns.transaction_type_name) == Columns.transaction_type_name && reader["transaction_type_name"]!=DBNull.Value)
currentTransactionType.transaction_type_name =(string) reader["transaction_type_name"]; 

} else
{
if (reader["transaction_type_id"] != DBNull.Value)
currentTransactionType.transaction_type_id = (int) reader["transaction_type_id"]; 
if (reader["transaction_type_name"] != DBNull.Value)
currentTransactionType.transaction_type_name = (string) reader["transaction_type_name"]; 
} 

currentTransactionType.isNewEntity = false;
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

public TransactionType CurrentTransactionType
{
get{ return currentTransactionType; }
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


#region TransactionType functions

public static TransactionTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.transaction_type_id == (Columns.transaction_type_id & columns))
qry.Append("transaction_type_id,");
if (Columns.transaction_type_name == (Columns.transaction_type_name & columns))
qry.Append("transaction_type_name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Transaction_type ");

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
return new TransactionTypeReader(cmd.ExecuteReader(), conn, columns);
}

static public TransactionTypeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static TransactionTypeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select transaction_type_id,transaction_type_name from Transaction_type ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new TransactionTypeReader(cmd.ExecuteReader(), conn);
}

static public TransactionTypeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static TransactionType LoadTransactionType(string where)
{
TransactionTypeReader reader = TransactionType.ExecuteReader(where);
TransactionType _transactiontype = null;
if (reader.Read())
_transactiontype = reader.CurrentTransactionType;
reader.Close();
return _transactiontype;
}

public static TransactionType LoadTransactionType(string where, IDbConnection conn)
{
TransactionTypeReader reader = TransactionType.ExecuteReader(where, conn);
TransactionType _transactiontype = null;
if (reader.Read())
_transactiontype = reader.CurrentTransactionType;
reader.Close(false);
return _transactiontype;
}

public static TransactionType LoadTransactionTypeByPk( int transaction_type_id )
{
return LoadTransactionType( " transaction_type_id="+transaction_type_id );
}

public static TransactionType LoadTransactionTypeByPk( int transaction_type_id , IDbConnection conn)
{
return LoadTransactionType(" transaction_type_id="+transaction_type_id , conn);
}

public void Save()
{
if (transaction_type_idChanged || transaction_type_nameChanged )
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
if (transaction_type_idChanged || transaction_type_nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Transaction_type( transaction_type_id,transaction_type_name ) values(");
lock (ConnectionFactory.connectionString) { this.transaction_type_id = ConnectionFactory.GetNextId();
qry.Append(this.transaction_type_id);
} qry.Append(",");
qry.Append(transaction_type_nameDbString);
qry.Append(");");

}
else
{
if (!(transaction_type_idChanged || transaction_type_nameChanged ))
return;
qry.Append("UPDATE Transaction_type set "); if ( transaction_type_nameChanged )
{
qry.Append("transaction_type_name ="+transaction_type_nameDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("transaction_type_id = "+transaction_type_idDbString);
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
cmd.CommandText = "DELETE Transaction_type where transaction_type_id = "+ transaction_type_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteTransactionTypes(string where)
{
ConnectionFactory.ExecuteQuery("delete Transaction_type where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
transaction_type_id= 1,
transaction_type_name= 2
}
#endregion
public void BulkSave(List<TransactionType> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Transaction_type";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(TransactionType.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <TransactionType> transList,ref DataTable dt)
{
foreach (TransactionType tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["transaction_type_id"] =ConnectionFactory.GetNextId();
Row["transaction_type_name"] = tran.TransactionTypeName;
dt.Rows.Add(Row);
} }
}
}
