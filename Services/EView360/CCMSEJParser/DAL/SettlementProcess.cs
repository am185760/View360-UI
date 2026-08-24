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
public class SettlementProcess
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SettlementProcess() { }
public SettlementProcess( int settlement_process_id ) 
{
}
public SettlementProcess( string settlement_process_name,string replenish_sheet_name,string vault_sheet_name )
{
this.settlement_process_name = settlement_process_name;
this.settlement_process_nameChanged = true;
this.replenish_sheet_name = replenish_sheet_name;
this.replenish_sheet_nameChanged = true;
this.vault_sheet_name = vault_sheet_name;
this.vault_sheet_nameChanged = true;
}
private SettlementProcess( int settlement_process_id,string settlement_process_name,string replenish_sheet_name,string vault_sheet_name )
{
this.settlement_process_id = settlement_process_id;
this.settlement_process_idChanged = true;
this.settlement_process_name = settlement_process_name;
this.settlement_process_nameChanged = true;
this.replenish_sheet_name = replenish_sheet_name;
this.replenish_sheet_nameChanged = true;
this.vault_sheet_name = vault_sheet_name;
this.vault_sheet_nameChanged = true;
}

#region members and properties for columns

#region SettlementProcessId
private bool settlement_process_idChanged = false;
private int settlement_process_id;
public int SettlementProcessId
{
get { return settlement_process_id; }
set { 
settlement_process_id = value;
settlement_process_idChanged = true;
}
}
private string settlement_process_idDbString
{
get
{
return settlement_process_id.ToString();
}
}
#endregion
#region SettlementProcessName
private bool settlement_process_nameChanged = false;
private string settlement_process_name;
public string SettlementProcessName
{
get { return settlement_process_name; }
set { 
settlement_process_name = value;
settlement_process_nameChanged = true;
}
}
private string settlement_process_nameDbString
{
get
{
if (this.settlement_process_name!=null)
return string.Format("'{0}'",settlement_process_name); else
return "null";
}
}
#endregion
#region ReplenishSheetName
private bool replenish_sheet_nameChanged = false;
private string replenish_sheet_name;
public string ReplenishSheetName
{
get { return replenish_sheet_name; }
set { 
replenish_sheet_name = value;
replenish_sheet_nameChanged = true;
}
}
private string replenish_sheet_nameDbString
{
get
{
if (this.replenish_sheet_name!=null)
return string.Format("'{0}'",replenish_sheet_name); else
return "null";
}
}
#endregion
#region VaultSheetName
private bool vault_sheet_nameChanged = false;
private string vault_sheet_name;
public string VaultSheetName
{
get { return vault_sheet_name; }
set { 
vault_sheet_name = value;
vault_sheet_nameChanged = true;
}
}
private string vault_sheet_nameDbString
{
get
{
if (this.vault_sheet_name!=null)
return string.Format("'{0}'",vault_sheet_name); else
return "null";
}
}
#endregion
#endregion

#region SettlementProcessReader
public class SettlementProcessReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SettlementProcess currentSettlementProcess;
Columns columns;
bool partialRead = false;
private SettlementProcessReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SettlementProcessReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SettlementProcessReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSettlementProcess; }

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
currentSettlementProcess = new SettlementProcess();
if (partialRead)
{ if ((columns & Columns.settlement_process_id) == Columns.settlement_process_id && reader["settlement_process_id"]!=DBNull.Value)
currentSettlementProcess.settlement_process_id =(int) reader["settlement_process_id"]; 
if ((columns & Columns.settlement_process_name) == Columns.settlement_process_name && reader["settlement_process_name"]!=DBNull.Value)
currentSettlementProcess.settlement_process_name =(string) reader["settlement_process_name"]; 
if ((columns & Columns.replenish_sheet_name) == Columns.replenish_sheet_name && reader["replenish_sheet_name"]!=DBNull.Value)
currentSettlementProcess.replenish_sheet_name =(string) reader["replenish_sheet_name"]; 
if ((columns & Columns.vault_sheet_name) == Columns.vault_sheet_name && reader["vault_sheet_name"]!=DBNull.Value)
currentSettlementProcess.vault_sheet_name =(string) reader["vault_sheet_name"]; 

} else
{
if (reader["settlement_process_id"] != DBNull.Value)
currentSettlementProcess.settlement_process_id = (int) reader["settlement_process_id"]; 
if (reader["settlement_process_name"] != DBNull.Value)
currentSettlementProcess.settlement_process_name = (string) reader["settlement_process_name"]; 
if (reader["replenish_sheet_name"] != DBNull.Value)
currentSettlementProcess.replenish_sheet_name = (string) reader["replenish_sheet_name"]; 
if (reader["vault_sheet_name"] != DBNull.Value)
currentSettlementProcess.vault_sheet_name = (string) reader["vault_sheet_name"]; 
} 

currentSettlementProcess.isNewEntity = false;
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

public SettlementProcess CurrentSettlementProcess
{
get{ return currentSettlementProcess; }
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


#region SettlementProcess functions

public static SettlementProcessReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.settlement_process_id == (Columns.settlement_process_id & columns))
qry.Append("settlement_process_id,");
if (Columns.settlement_process_name == (Columns.settlement_process_name & columns))
qry.Append("settlement_process_name,");
if (Columns.replenish_sheet_name == (Columns.replenish_sheet_name & columns))
qry.Append("replenish_sheet_name,");
if (Columns.vault_sheet_name == (Columns.vault_sheet_name & columns))
qry.Append("vault_sheet_name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Settlement_process ");

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
return new SettlementProcessReader(cmd.ExecuteReader(), conn, columns);
}

static public SettlementProcessReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SettlementProcessReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select settlement_process_id,settlement_process_name,replenish_sheet_name,vault_sheet_name from Settlement_process ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SettlementProcessReader(cmd.ExecuteReader(), conn);
}

static public SettlementProcessReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SettlementProcess LoadSettlementProcess(string where)
{
SettlementProcessReader reader = SettlementProcess.ExecuteReader(where);
SettlementProcess _settlementprocess = null;
if (reader.Read())
_settlementprocess = reader.CurrentSettlementProcess;
reader.Close();
return _settlementprocess;
}

public static SettlementProcess LoadSettlementProcess(string where, IDbConnection conn)
{
SettlementProcessReader reader = SettlementProcess.ExecuteReader(where, conn);
SettlementProcess _settlementprocess = null;
if (reader.Read())
_settlementprocess = reader.CurrentSettlementProcess;
reader.Close(false);
return _settlementprocess;
}

public static SettlementProcess LoadSettlementProcessByPk( int settlement_process_id )
{
return LoadSettlementProcess( " settlement_process_id="+settlement_process_id );
}

public static SettlementProcess LoadSettlementProcessByPk( int settlement_process_id , IDbConnection conn)
{
return LoadSettlementProcess(" settlement_process_id="+settlement_process_id , conn);
}

public void Save()
{
if (settlement_process_idChanged || settlement_process_nameChanged || replenish_sheet_nameChanged || vault_sheet_nameChanged )
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
if (settlement_process_idChanged || settlement_process_nameChanged || replenish_sheet_nameChanged || vault_sheet_nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Settlement_process( settlement_process_id,settlement_process_name,replenish_sheet_name,vault_sheet_name ) values(");
lock (ConnectionFactory.connectionString) { this.settlement_process_id = ConnectionFactory.GetNextId();
qry.Append(this.settlement_process_id);
} qry.Append(",");
qry.Append(settlement_process_nameDbString+",");
qry.Append(replenish_sheet_nameDbString+",");
qry.Append(vault_sheet_nameDbString);
qry.Append(");");

}
else
{
if (!(settlement_process_idChanged || settlement_process_nameChanged || replenish_sheet_nameChanged || vault_sheet_nameChanged ))
return;
qry.Append("UPDATE Settlement_process set "); if ( settlement_process_nameChanged )
{
qry.Append("settlement_process_name ="+settlement_process_nameDbString);
qry.Append(",");
}

if ( replenish_sheet_nameChanged )
{
qry.Append("replenish_sheet_name ="+replenish_sheet_nameDbString);
qry.Append(",");
}

if ( vault_sheet_nameChanged )
{
qry.Append("vault_sheet_name ="+vault_sheet_nameDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("settlement_process_id = "+settlement_process_idDbString);
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
cmd.CommandText = "DELETE Settlement_process where settlement_process_id = "+ settlement_process_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteSettlementProcesss(string where)
{
ConnectionFactory.ExecuteQuery("delete Settlement_process where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
settlement_process_id= 1,
settlement_process_name= 2,
replenish_sheet_name= 4,
vault_sheet_name= 8
}
#endregion
public void BulkSave(List<SettlementProcess> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Settlement_process";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SettlementProcess.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SettlementProcess> transList,ref DataTable dt)
{
foreach (SettlementProcess tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["settlement_process_id"] =ConnectionFactory.GetNextId();
Row["settlement_process_name"] = tran.SettlementProcessName;
Row["replenish_sheet_name"] = tran.ReplenishSheetName;
Row["vault_sheet_name"] = tran.VaultSheetName;
dt.Rows.Add(Row);
} }
}
}
