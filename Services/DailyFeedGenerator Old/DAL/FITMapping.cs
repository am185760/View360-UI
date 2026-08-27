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
public class FITMapping
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public FITMapping() { }
public FITMapping( string pAN_prefix ) 
{
this.pAN_prefix = pAN_prefix;
this.pAN_prefixChanged = true;
}
public FITMapping( string pAN_prefix,string bank_name,bool? on_us )
{
this.pAN_prefix = pAN_prefix;
this.pAN_prefixChanged = true;
this.bank_name = bank_name;
this.bank_nameChanged = true;
this.on_us = on_us;
this.on_usChanged = true;
}

#region members and properties for columns

#region PANPrefix
private bool pAN_prefixChanged = false;
private string pAN_prefix;
public string PANPrefix
{
get { return pAN_prefix; }
set { 
pAN_prefix = value;
pAN_prefixChanged = true;
}
}
private string pAN_prefixDbString
{
get
{
if (this.pAN_prefix!=null)
return string.Format("'{0}'",pAN_prefix); else
return "null";
}
}
#endregion
#region BankName
private bool bank_nameChanged = false;
private string bank_name;
public string BankName
{
get { return bank_name; }
set { 
bank_name = value;
bank_nameChanged = true;
}
}
private string bank_nameDbString
{
get
{
if (this.bank_name!=null)
return string.Format("'{0}'",bank_name); else
return "null";
}
}
#endregion
#region OnUs
private bool on_usChanged = false;
private bool? on_us;
public bool? OnUs
{
get { return on_us; }
set { 
on_us = value;
on_usChanged = true;
}
}
private string on_usDbString
{
get
{
if (this.on_us.HasValue)
return on_us.Value?"1":"0";
else
return "null";
}
}
#endregion
#endregion

#region FITMappingReader
public class FITMappingReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
FITMapping currentFITMapping;
Columns columns;
bool partialRead = false;
private FITMappingReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public FITMappingReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public FITMappingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentFITMapping; }

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
currentFITMapping = new FITMapping();
if (partialRead)
{ if ((columns & Columns.PAN_prefix) == Columns.PAN_prefix && reader["PAN_prefix"]!=DBNull.Value)
currentFITMapping.pAN_prefix =(string) reader["PAN_prefix"]; 
if ((columns & Columns.bank_name) == Columns.bank_name && reader["bank_name"]!=DBNull.Value)
currentFITMapping.bank_name =(string) reader["bank_name"]; 
if ((columns & Columns.on_us) == Columns.on_us && reader["on_us"]!=DBNull.Value)
currentFITMapping.on_us =(bool?) reader["on_us"]; 

} else
{
if (reader["PAN_prefix"] != DBNull.Value)
currentFITMapping.pAN_prefix = (string) reader["PAN_prefix"]; 
if (reader["bank_name"] != DBNull.Value)
currentFITMapping.bank_name = (string) reader["bank_name"]; 
if (reader["on_us"] != DBNull.Value)
currentFITMapping.on_us = (bool?) reader["on_us"]; 
} 

currentFITMapping.isNewEntity = false;
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

public FITMapping CurrentFITMapping
{
get{ return currentFITMapping; }
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


#region FITMapping functions

public static FITMappingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.PAN_prefix == (Columns.PAN_prefix & columns))
qry.Append("PAN_prefix,");
if (Columns.bank_name == (Columns.bank_name & columns))
qry.Append("bank_name,");
if (Columns.on_us == (Columns.on_us & columns))
qry.Append("on_us,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from FITMapping ");

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
return new FITMappingReader(cmd.ExecuteReader(), conn, columns);
}

static public FITMappingReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static FITMappingReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select PAN_prefix,bank_name,on_us from FITMapping ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new FITMappingReader(cmd.ExecuteReader(), conn);
}

static public FITMappingReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static FITMapping LoadFITMapping(string where)
{
FITMappingReader reader = FITMapping.ExecuteReader(where);
FITMapping _fitmapping = null;
if (reader.Read())
_fitmapping = reader.CurrentFITMapping;
reader.Close();
return _fitmapping;
}

public static FITMapping LoadFITMapping(string where, IDbConnection conn)
{
FITMappingReader reader = FITMapping.ExecuteReader(where, conn);
FITMapping _fitmapping = null;
if (reader.Read())
_fitmapping = reader.CurrentFITMapping;
reader.Close(false);
return _fitmapping;
}


public void Save()
{
if (pAN_prefixChanged || bank_nameChanged || on_usChanged )
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
if (pAN_prefixChanged || bank_nameChanged || on_usChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into FITMapping( PAN_prefix,bank_name,on_us ) values(");
qry.Append(pAN_prefixDbString+",");
qry.Append(bank_nameDbString+",");
qry.Append(on_usDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update FITMapping!");
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

public static void DeleteFITMappings(string where)
{
ConnectionFactory.ExecuteQuery("delete FITMapping where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
PAN_prefix= 1,
bank_name= 2,
on_us= 4
}
#endregion
public void BulkSave(List<FITMapping> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "FITMapping";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(FITMapping.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <FITMapping> transList,ref DataTable dt)
{
foreach (FITMapping tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["pAN_prefix"] = tran.PANPrefix;
Row["bank_name"] = tran.BankName;
Row["on_us"] = tran.OnUs;
dt.Rows.Add(Row);
} }
}
}
