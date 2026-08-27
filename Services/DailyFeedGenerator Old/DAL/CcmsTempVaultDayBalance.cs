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
public class CcmsTempVaultDayBalance
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsTempVaultDayBalance() { }
public CcmsTempVaultDayBalance( DateTime ledger_date,int vault_id,string vault_transaction_type,string transaction_type,string denomination_name,int total_quantity,int total_value,int vault_note_type_id,int denomination_id,DateTime generated_at )
{
this.ledger_date = ledger_date;
this.ledger_dateChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.vault_transaction_type = vault_transaction_type;
this.vault_transaction_typeChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.total_quantity = total_quantity;
this.total_quantityChanged = true;
this.total_value = total_value;
this.total_valueChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}
private CcmsTempVaultDayBalance( int id,DateTime ledger_date,int vault_id,string vault_transaction_type,string transaction_type,string denomination_name,int total_quantity,int total_value,int vault_note_type_id,int denomination_id,DateTime generated_at )
{
this.id = id;
this.idChanged = true;
this.ledger_date = ledger_date;
this.ledger_dateChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.vault_transaction_type = vault_transaction_type;
this.vault_transaction_typeChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.total_quantity = total_quantity;
this.total_quantityChanged = true;
this.total_value = total_value;
this.total_valueChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}

#region members and properties for columns

#region Id
private bool idChanged = false;
private int id;
public int Id
{
get { return id; }
set { 
id = value;
idChanged = true;
}
}
private string idDbString
{
get
{
return id.ToString();
}
}
#endregion
#region LedgerDate
private bool ledger_dateChanged = false;
private DateTime ledger_date;
public DateTime LedgerDate
{
get { return ledger_date; }
set { 
ledger_date = value;
ledger_dateChanged = true;
}
}
private string ledger_dateDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",ledger_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region VaultId
private bool vault_idChanged = false;
private int vault_id;
public int VaultId
{
get { return vault_id; }
set { 
vault_id = value;
vault_idChanged = true;
}
}
private string vault_idDbString
{
get
{
return vault_id.ToString();
}
}
#endregion
#region VaultTransactionType
private bool vault_transaction_typeChanged = false;
private string vault_transaction_type;
public string VaultTransactionType
{
get { return vault_transaction_type; }
set { 
vault_transaction_type = value;
vault_transaction_typeChanged = true;
}
}
private string vault_transaction_typeDbString
{
get
{
if (this.vault_transaction_type!=null)
return string.Format("'{0}'",vault_transaction_type); else
return "null";
}
}
#endregion
#region TransactionType
private bool transaction_typeChanged = false;
private string transaction_type;
public string TransactionType
{
get { return transaction_type; }
set { 
transaction_type = value;
transaction_typeChanged = true;
}
}
private string transaction_typeDbString
{
get
{
if (this.transaction_type!=null)
return string.Format("'{0}'",transaction_type); else
return "null";
}
}
#endregion
#region DenominationName
private bool denomination_nameChanged = false;
private string denomination_name;
public string DenominationName
{
get { return denomination_name; }
set { 
denomination_name = value;
denomination_nameChanged = true;
}
}
private string denomination_nameDbString
{
get
{
if (this.denomination_name!=null)
return string.Format("'{0}'",denomination_name); else
return "null";
}
}
#endregion
#region TotalQuantity
private bool total_quantityChanged = false;
private int total_quantity;
public int TotalQuantity
{
get { return total_quantity; }
set { 
total_quantity = value;
total_quantityChanged = true;
}
}
private string total_quantityDbString
{
get
{
return total_quantity.ToString();
}
}
#endregion
#region TotalValue
private bool total_valueChanged = false;
private int total_value;
public int TotalValue
{
get { return total_value; }
set { 
total_value = value;
total_valueChanged = true;
}
}
private string total_valueDbString
{
get
{
return total_value.ToString();
}
}
#endregion
#region VaultNoteTypeId
private bool vault_note_type_idChanged = false;
private int vault_note_type_id;
public int VaultNoteTypeId
{
get { return vault_note_type_id; }
set { 
vault_note_type_id = value;
vault_note_type_idChanged = true;
}
}
private string vault_note_type_idDbString
{
get
{
return vault_note_type_id.ToString();
}
}
#endregion
#region DenominationId
private bool denomination_idChanged = false;
private int denomination_id;
public int DenominationId
{
get { return denomination_id; }
set { 
denomination_id = value;
denomination_idChanged = true;
}
}
private string denomination_idDbString
{
get
{
return denomination_id.ToString();
}
}
#endregion
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime generated_at;
public DateTime GeneratedAt
{
get { return generated_at; }
set { 
generated_at = value;
generated_atChanged = true;
}
}
private string generated_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region CcmsTempVaultDayBalanceReader
public class CcmsTempVaultDayBalanceReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsTempVaultDayBalance currentCcmsTempVaultDayBalance;
Columns columns;
bool partialRead = false;
private CcmsTempVaultDayBalanceReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsTempVaultDayBalanceReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsTempVaultDayBalanceReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsTempVaultDayBalance; }

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
currentCcmsTempVaultDayBalance = new CcmsTempVaultDayBalance();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.id =(int) reader["id"]; 
if ((columns & Columns.ledger_date) == Columns.ledger_date && reader["ledger_date"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.ledger_date =(DateTime) reader["ledger_date"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.vault_transaction_type) == Columns.vault_transaction_type && reader["vault_transaction_type"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.vault_transaction_type =(string) reader["vault_transaction_type"]; 
if ((columns & Columns.transaction_type) == Columns.transaction_type && reader["transaction_type"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.transaction_type =(string) reader["transaction_type"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.total_quantity) == Columns.total_quantity && reader["total_quantity"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.total_quantity =(int) reader["total_quantity"]; 
if ((columns & Columns.total_value) == Columns.total_value && reader["total_value"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.total_value =(int) reader["total_value"]; 
if ((columns & Columns.vault_note_type_id) == Columns.vault_note_type_id && reader["vault_note_type_id"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.vault_note_type_id =(int) reader["vault_note_type_id"]; 
if ((columns & Columns.denomination_id) == Columns.denomination_id && reader["denomination_id"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.denomination_id =(int) reader["denomination_id"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentCcmsTempVaultDayBalance.generated_at =(DateTime) reader["generated_at"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsTempVaultDayBalance.id = (int) reader["id"]; 
if (reader["ledger_date"] != DBNull.Value)
currentCcmsTempVaultDayBalance.ledger_date = (DateTime) reader["ledger_date"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsTempVaultDayBalance.vault_id = (int) reader["vault_id"]; 
if (reader["vault_transaction_type"] != DBNull.Value)
currentCcmsTempVaultDayBalance.vault_transaction_type = (string) reader["vault_transaction_type"]; 
if (reader["transaction_type"] != DBNull.Value)
currentCcmsTempVaultDayBalance.transaction_type = (string) reader["transaction_type"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsTempVaultDayBalance.denomination_name = (string) reader["denomination_name"]; 
if (reader["total_quantity"] != DBNull.Value)
currentCcmsTempVaultDayBalance.total_quantity = (int) reader["total_quantity"]; 
if (reader["total_value"] != DBNull.Value)
currentCcmsTempVaultDayBalance.total_value = (int) reader["total_value"]; 
if (reader["vault_note_type_id"] != DBNull.Value)
currentCcmsTempVaultDayBalance.vault_note_type_id = (int) reader["vault_note_type_id"]; 
if (reader["denomination_id"] != DBNull.Value)
currentCcmsTempVaultDayBalance.denomination_id = (int) reader["denomination_id"]; 
if (reader["generated_at"] != DBNull.Value)
currentCcmsTempVaultDayBalance.generated_at = (DateTime) reader["generated_at"]; 
} 

currentCcmsTempVaultDayBalance.isNewEntity = false;
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

public CcmsTempVaultDayBalance CurrentCcmsTempVaultDayBalance
{
get{ return currentCcmsTempVaultDayBalance; }
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


#region CcmsTempVaultDayBalance functions

public static CcmsTempVaultDayBalanceReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.ledger_date == (Columns.ledger_date & columns))
qry.Append("ledger_date,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.vault_transaction_type == (Columns.vault_transaction_type & columns))
qry.Append("vault_transaction_type,");
if (Columns.transaction_type == (Columns.transaction_type & columns))
qry.Append("transaction_type,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.total_quantity == (Columns.total_quantity & columns))
qry.Append("total_quantity,");
if (Columns.total_value == (Columns.total_value & columns))
qry.Append("total_value,");
if (Columns.vault_note_type_id == (Columns.vault_note_type_id & columns))
qry.Append("vault_note_type_id,");
if (Columns.denomination_id == (Columns.denomination_id & columns))
qry.Append("denomination_id,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_temp_vault_day_balance ");

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
return new CcmsTempVaultDayBalanceReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsTempVaultDayBalanceReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsTempVaultDayBalanceReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,ledger_date,vault_id,vault_transaction_type,transaction_type,denomination_name,total_quantity,total_value,vault_note_type_id,denomination_id,generated_at from Ccms_temp_vault_day_balance ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsTempVaultDayBalanceReader(cmd.ExecuteReader(), conn);
}

static public CcmsTempVaultDayBalanceReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsTempVaultDayBalance LoadCcmsTempVaultDayBalance(string where)
{
CcmsTempVaultDayBalanceReader reader = CcmsTempVaultDayBalance.ExecuteReader(where);
CcmsTempVaultDayBalance _ccmstempvaultdaybalance = null;
if (reader.Read())
_ccmstempvaultdaybalance = reader.CurrentCcmsTempVaultDayBalance;
reader.Close();
return _ccmstempvaultdaybalance;
}

public static CcmsTempVaultDayBalance LoadCcmsTempVaultDayBalance(string where, IDbConnection conn)
{
CcmsTempVaultDayBalanceReader reader = CcmsTempVaultDayBalance.ExecuteReader(where, conn);
CcmsTempVaultDayBalance _ccmstempvaultdaybalance = null;
if (reader.Read())
_ccmstempvaultdaybalance = reader.CurrentCcmsTempVaultDayBalance;
reader.Close(false);
return _ccmstempvaultdaybalance;
}

public static CcmsTempVaultDayBalance LoadCcmsTempVaultDayBalanceByPk( int id )
{
return LoadCcmsTempVaultDayBalance( " id="+id );
}

public static CcmsTempVaultDayBalance LoadCcmsTempVaultDayBalanceByPk( int id , IDbConnection conn)
{
return LoadCcmsTempVaultDayBalance(" id="+id , conn);
}

public void Save()
{
if (idChanged || ledger_dateChanged || vault_idChanged || vault_transaction_typeChanged || transaction_typeChanged || denomination_nameChanged || total_quantityChanged || total_valueChanged || vault_note_type_idChanged || denomination_idChanged || generated_atChanged )
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
if (idChanged || ledger_dateChanged || vault_idChanged || vault_transaction_typeChanged || transaction_typeChanged || denomination_nameChanged || total_quantityChanged || total_valueChanged || vault_note_type_idChanged || denomination_idChanged || generated_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_temp_vault_day_balance( id,ledger_date,vault_id,vault_transaction_type,transaction_type,denomination_name,total_quantity,total_value,vault_note_type_id,denomination_id,generated_at ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(ledger_dateDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(vault_transaction_typeDbString+",");
qry.Append(transaction_typeDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(total_quantityDbString+",");
qry.Append(total_valueDbString+",");
qry.Append(vault_note_type_idDbString+",");
qry.Append(denomination_idDbString+",");
qry.Append(generated_atDbString);
qry.Append(");");

}
else
{
if (!(idChanged || ledger_dateChanged || vault_idChanged || vault_transaction_typeChanged || transaction_typeChanged || denomination_nameChanged || total_quantityChanged || total_valueChanged || vault_note_type_idChanged || denomination_idChanged || generated_atChanged ))
return;
qry.Append("UPDATE Ccms_temp_vault_day_balance set "); if ( ledger_dateChanged )
{
qry.Append("ledger_date ="+ledger_dateDbString);
qry.Append(",");
}

if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( vault_transaction_typeChanged )
{
qry.Append("vault_transaction_type ="+vault_transaction_typeDbString);
qry.Append(",");
}

if ( transaction_typeChanged )
{
qry.Append("transaction_type ="+transaction_typeDbString);
qry.Append(",");
}

if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( total_quantityChanged )
{
qry.Append("total_quantity ="+total_quantityDbString);
qry.Append(",");
}

if ( total_valueChanged )
{
qry.Append("total_value ="+total_valueDbString);
qry.Append(",");
}

if ( vault_note_type_idChanged )
{
qry.Append("vault_note_type_id ="+vault_note_type_idDbString);
qry.Append(",");
}

if ( denomination_idChanged )
{
qry.Append("denomination_id ="+denomination_idDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("id = "+idDbString);
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
cmd.CommandText = "DELETE Ccms_temp_vault_day_balance where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsTempVaultDayBalances(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_temp_vault_day_balance where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
ledger_date= 2,
vault_id= 4,
vault_transaction_type= 8,
transaction_type= 16,
denomination_name= 32,
total_quantity= 64,
total_value= 128,
vault_note_type_id= 256,
denomination_id= 512,
generated_at= 1024
}
#endregion
public void BulkSave(List<CcmsTempVaultDayBalance> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_temp_vault_day_balance";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsTempVaultDayBalance.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsTempVaultDayBalance> transList,ref DataTable dt)
{
foreach (CcmsTempVaultDayBalance tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["ledger_date"] = tran.LedgerDate;
Row["vault_id"] = tran.VaultId;
Row["vault_transaction_type"] = tran.VaultTransactionType;
Row["transaction_type"] = tran.TransactionType;
Row["denomination_name"] = tran.DenominationName;
Row["total_quantity"] = tran.TotalQuantity;
Row["total_value"] = tran.TotalValue;
Row["vault_note_type_id"] = tran.VaultNoteTypeId;
Row["denomination_id"] = tran.DenominationId;
Row["generated_at"] = tran.GeneratedAt;
dt.Rows.Add(Row);
} }
}
}
