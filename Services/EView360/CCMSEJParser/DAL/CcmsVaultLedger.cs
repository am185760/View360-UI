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
public class CcmsVaultLedger
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsVaultLedger() { }
public CcmsVaultLedger( int id,DateTime transaction_date,string transaction_type,decimal ledger_amount,int posted_by,int vault_id,string vault_transaction_type,int atm_settlement_id ) 
{
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.ledger_amount = ledger_amount;
this.ledger_amountChanged = true;
this.posted_by = posted_by;
this.posted_byChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.vault_transaction_type = vault_transaction_type;
this.vault_transaction_typeChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
}
public CcmsVaultLedger( DateTime transaction_date,string description,string transaction_type,decimal ledger_amount,decimal? balance,int posted_by,int vault_id,string vault_transaction_type,int? cheque_id,int? atm_id,int? vault_adjustment_id,int atm_settlement_id )
{
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.description = description;
this.descriptionChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.ledger_amount = ledger_amount;
this.ledger_amountChanged = true;
this.balance = balance;
this.balanceChanged = true;
this.posted_by = posted_by;
this.posted_byChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.vault_transaction_type = vault_transaction_type;
this.vault_transaction_typeChanged = true;
this.cheque_id = cheque_id;
this.cheque_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.vault_adjustment_id = vault_adjustment_id;
this.vault_adjustment_idChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
}
private CcmsVaultLedger( int id,DateTime transaction_date,string description,string transaction_type,decimal ledger_amount,decimal? balance,int posted_by,int vault_id,string vault_transaction_type,int? cheque_id,int? atm_id,int? vault_adjustment_id,int atm_settlement_id )
{
this.id = id;
this.idChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.description = description;
this.descriptionChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.ledger_amount = ledger_amount;
this.ledger_amountChanged = true;
this.balance = balance;
this.balanceChanged = true;
this.posted_by = posted_by;
this.posted_byChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.vault_transaction_type = vault_transaction_type;
this.vault_transaction_typeChanged = true;
this.cheque_id = cheque_id;
this.cheque_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.vault_adjustment_id = vault_adjustment_id;
this.vault_adjustment_idChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
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
#region TransactionDate
private bool transaction_dateChanged = false;
private DateTime transaction_date;
public DateTime TransactionDate
{
get { return transaction_date; }
set { 
transaction_date = value;
transaction_dateChanged = true;
}
}
private string transaction_dateDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",transaction_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region Description
private bool descriptionChanged = false;
private string description;
public string Description
{
get { return description; }
set { 
description = value;
descriptionChanged = true;
}
}
private string descriptionDbString
{
get
{
if (this.description!=null)
return string.Format("'{0}'",description); else
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
#region LedgerAmount
private bool ledger_amountChanged = false;
private decimal ledger_amount;
public decimal LedgerAmount
{
get { return ledger_amount; }
set { 
ledger_amount = value;
ledger_amountChanged = true;
}
}
private string ledger_amountDbString
{
get
{
return ledger_amount.ToString();
}
}
#endregion
#region Balance
private bool balanceChanged = false;
private decimal? balance;
public decimal? Balance
{
get { return balance; }
set { 
balance = value;
balanceChanged = true;
}
}
private string balanceDbString
{
get
{
if (this.balance.HasValue)
return balance.ToString();
else
return "null";
}
}
#endregion
#region PostedBy
private bool posted_byChanged = false;
private int posted_by;
public int PostedBy
{
get { return posted_by; }
set { 
posted_by = value;
posted_byChanged = true;
}
}
private string posted_byDbString
{
get
{
return posted_by.ToString();
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
#region ChequeId
private bool cheque_idChanged = false;
private int? cheque_id;
public int? ChequeId
{
get { return cheque_id; }
set { 
cheque_id = value;
cheque_idChanged = true;
}
}
private string cheque_idDbString
{
get
{
if (this.cheque_id.HasValue)
return cheque_id.ToString();
else
return "null";
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int? atm_id;
public int? AtmId
{
get { return atm_id; }
set { 
atm_id = value;
atm_idChanged = true;
}
}
private string atm_idDbString
{
get
{
if (this.atm_id.HasValue)
return atm_id.ToString();
else
return "null";
}
}
#endregion
#region VaultAdjustmentId
private bool vault_adjustment_idChanged = false;
private int? vault_adjustment_id;
public int? VaultAdjustmentId
{
get { return vault_adjustment_id; }
set { 
vault_adjustment_id = value;
vault_adjustment_idChanged = true;
}
}
private string vault_adjustment_idDbString
{
get
{
if (this.vault_adjustment_id.HasValue)
return vault_adjustment_id.ToString();
else
return "null";
}
}
#endregion
#region AtmSettlementId
private bool atm_settlement_idChanged = false;
private int atm_settlement_id;
public int AtmSettlementId
{
get { return atm_settlement_id; }
set { 
atm_settlement_id = value;
atm_settlement_idChanged = true;
}
}
private string atm_settlement_idDbString
{
get
{
return atm_settlement_id.ToString();
}
}
#endregion
#endregion

#region CcmsVaultLedgerReader
public class CcmsVaultLedgerReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsVaultLedger currentCcmsVaultLedger;
Columns columns;
bool partialRead = false;
private CcmsVaultLedgerReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsVaultLedgerReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsVaultLedgerReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsVaultLedger; }

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
currentCcmsVaultLedger = new CcmsVaultLedger();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsVaultLedger.id =(int) reader["id"]; 
if ((columns & Columns.transaction_date) == Columns.transaction_date && reader["transaction_date"]!=DBNull.Value)
currentCcmsVaultLedger.transaction_date =(DateTime) reader["transaction_date"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsVaultLedger.description =(string) reader["description"]; 
if ((columns & Columns.transaction_type) == Columns.transaction_type && reader["transaction_type"]!=DBNull.Value)
currentCcmsVaultLedger.transaction_type =(string) reader["transaction_type"]; 
if ((columns & Columns.ledger_amount) == Columns.ledger_amount && reader["ledger_amount"]!=DBNull.Value)
currentCcmsVaultLedger.ledger_amount =(decimal) reader["ledger_amount"]; 
if ((columns & Columns.balance) == Columns.balance && reader["balance"]!=DBNull.Value)
currentCcmsVaultLedger.balance =(decimal?) reader["balance"]; 
if ((columns & Columns.posted_by) == Columns.posted_by && reader["posted_by"]!=DBNull.Value)
currentCcmsVaultLedger.posted_by =(int) reader["posted_by"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsVaultLedger.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.vault_transaction_type) == Columns.vault_transaction_type && reader["vault_transaction_type"]!=DBNull.Value)
currentCcmsVaultLedger.vault_transaction_type =(string) reader["vault_transaction_type"]; 
if ((columns & Columns.cheque_id) == Columns.cheque_id && reader["cheque_id"]!=DBNull.Value)
currentCcmsVaultLedger.cheque_id =(int?) reader["cheque_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCcmsVaultLedger.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.vault_adjustment_id) == Columns.vault_adjustment_id && reader["vault_adjustment_id"]!=DBNull.Value)
currentCcmsVaultLedger.vault_adjustment_id =(int?) reader["vault_adjustment_id"]; 
if ((columns & Columns.atm_settlement_id) == Columns.atm_settlement_id && reader["atm_settlement_id"]!=DBNull.Value)
currentCcmsVaultLedger.atm_settlement_id =(int) reader["atm_settlement_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsVaultLedger.id = (int) reader["id"]; 
if (reader["transaction_date"] != DBNull.Value)
currentCcmsVaultLedger.transaction_date = (DateTime) reader["transaction_date"]; 
if (reader["description"] != DBNull.Value)
currentCcmsVaultLedger.description = (string) reader["description"]; 
if (reader["transaction_type"] != DBNull.Value)
currentCcmsVaultLedger.transaction_type = (string) reader["transaction_type"]; 
if (reader["ledger_amount"] != DBNull.Value)
currentCcmsVaultLedger.ledger_amount = (decimal) reader["ledger_amount"]; 
if (reader["balance"] != DBNull.Value)
currentCcmsVaultLedger.balance = (decimal?) reader["balance"]; 
if (reader["posted_by"] != DBNull.Value)
currentCcmsVaultLedger.posted_by = (int) reader["posted_by"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsVaultLedger.vault_id = (int) reader["vault_id"]; 
if (reader["vault_transaction_type"] != DBNull.Value)
currentCcmsVaultLedger.vault_transaction_type = (string) reader["vault_transaction_type"]; 
if (reader["cheque_id"] != DBNull.Value)
currentCcmsVaultLedger.cheque_id = (int?) reader["cheque_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentCcmsVaultLedger.atm_id = (int?) reader["atm_id"]; 
if (reader["vault_adjustment_id"] != DBNull.Value)
currentCcmsVaultLedger.vault_adjustment_id = (int?) reader["vault_adjustment_id"]; 
if (reader["atm_settlement_id"] != DBNull.Value)
currentCcmsVaultLedger.atm_settlement_id = (int) reader["atm_settlement_id"]; 
} 

currentCcmsVaultLedger.isNewEntity = false;
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

public CcmsVaultLedger CurrentCcmsVaultLedger
{
get{ return currentCcmsVaultLedger; }
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


#region CcmsVaultLedger functions

public static CcmsVaultLedgerReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.transaction_date == (Columns.transaction_date & columns))
qry.Append("transaction_date,");
if (Columns.description == (Columns.description & columns))
qry.Append("description,");
if (Columns.transaction_type == (Columns.transaction_type & columns))
qry.Append("transaction_type,");
if (Columns.ledger_amount == (Columns.ledger_amount & columns))
qry.Append("ledger_amount,");
if (Columns.balance == (Columns.balance & columns))
qry.Append("balance,");
if (Columns.posted_by == (Columns.posted_by & columns))
qry.Append("posted_by,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.vault_transaction_type == (Columns.vault_transaction_type & columns))
qry.Append("vault_transaction_type,");
if (Columns.cheque_id == (Columns.cheque_id & columns))
qry.Append("cheque_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.vault_adjustment_id == (Columns.vault_adjustment_id & columns))
qry.Append("vault_adjustment_id,");
if (Columns.atm_settlement_id == (Columns.atm_settlement_id & columns))
qry.Append("atm_settlement_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_vault_ledger ");

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
return new CcmsVaultLedgerReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsVaultLedgerReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsVaultLedgerReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,transaction_date,description,transaction_type,ledger_amount,balance,posted_by,vault_id,vault_transaction_type,cheque_id,atm_id,vault_adjustment_id,atm_settlement_id from Ccms_vault_ledger ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsVaultLedgerReader(cmd.ExecuteReader(), conn);
}

static public CcmsVaultLedgerReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsVaultLedger LoadCcmsVaultLedger(string where)
{
CcmsVaultLedgerReader reader = CcmsVaultLedger.ExecuteReader(where);
CcmsVaultLedger _ccmsvaultledger = null;
if (reader.Read())
_ccmsvaultledger = reader.CurrentCcmsVaultLedger;
reader.Close();
return _ccmsvaultledger;
}

public static CcmsVaultLedger LoadCcmsVaultLedger(string where, IDbConnection conn)
{
CcmsVaultLedgerReader reader = CcmsVaultLedger.ExecuteReader(where, conn);
CcmsVaultLedger _ccmsvaultledger = null;
if (reader.Read())
_ccmsvaultledger = reader.CurrentCcmsVaultLedger;
reader.Close(false);
return _ccmsvaultledger;
}

public static CcmsVaultLedger LoadCcmsVaultLedgerByPk( int id )
{
return LoadCcmsVaultLedger( " id="+id );
}

public static CcmsVaultLedger LoadCcmsVaultLedgerByPk( int id , IDbConnection conn)
{
return LoadCcmsVaultLedger(" id="+id , conn);
}

public void Save()
{
if (idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || ledger_amountChanged || balanceChanged || posted_byChanged || vault_idChanged || vault_transaction_typeChanged || cheque_idChanged || atm_idChanged || vault_adjustment_idChanged || atm_settlement_idChanged )
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
if (idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || ledger_amountChanged || balanceChanged || posted_byChanged || vault_idChanged || vault_transaction_typeChanged || cheque_idChanged || atm_idChanged || vault_adjustment_idChanged || atm_settlement_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_vault_ledger( id,transaction_date,description,transaction_type,ledger_amount,balance,posted_by,vault_id,vault_transaction_type,cheque_id,atm_id,vault_adjustment_id,atm_settlement_id ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(transaction_dateDbString+",");
qry.Append(descriptionDbString+",");
qry.Append(transaction_typeDbString+",");
qry.Append(ledger_amountDbString+",");
qry.Append(balanceDbString+",");
qry.Append(posted_byDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(vault_transaction_typeDbString+",");
qry.Append(cheque_idDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(vault_adjustment_idDbString+",");
qry.Append(atm_settlement_idDbString);
qry.Append(");");

}
else
{
if (!(idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || ledger_amountChanged || balanceChanged || posted_byChanged || vault_idChanged || vault_transaction_typeChanged || cheque_idChanged || atm_idChanged || vault_adjustment_idChanged || atm_settlement_idChanged ))
return;
qry.Append("UPDATE Ccms_vault_ledger set "); if ( transaction_dateChanged )
{
qry.Append("transaction_date ="+transaction_dateDbString);
qry.Append(",");
}

if ( descriptionChanged )
{
qry.Append("description ="+descriptionDbString);
qry.Append(",");
}

if ( transaction_typeChanged )
{
qry.Append("transaction_type ="+transaction_typeDbString);
qry.Append(",");
}

if ( ledger_amountChanged )
{
qry.Append("ledger_amount ="+ledger_amountDbString);
qry.Append(",");
}

if ( balanceChanged )
{
qry.Append("balance ="+balanceDbString);
qry.Append(",");
}

if ( posted_byChanged )
{
qry.Append("posted_by ="+posted_byDbString);
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

if ( cheque_idChanged )
{
qry.Append("cheque_id ="+cheque_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( vault_adjustment_idChanged )
{
qry.Append("vault_adjustment_id ="+vault_adjustment_idDbString);
qry.Append(",");
}

if ( atm_settlement_idChanged )
{
qry.Append("atm_settlement_id ="+atm_settlement_idDbString);
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
cmd.CommandText = "DELETE Ccms_vault_ledger where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsVaultLedgers(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_vault_ledger where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
transaction_date= 2,
description= 4,
transaction_type= 8,
ledger_amount= 16,
balance= 32,
posted_by= 64,
vault_id= 128,
vault_transaction_type= 256,
cheque_id= 512,
atm_id= 1024,
vault_adjustment_id= 2048,
atm_settlement_id= 4096
}
#endregion
public void BulkSave(List<CcmsVaultLedger> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_vault_ledger";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsVaultLedger.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsVaultLedger> transList,ref DataTable dt)
{
foreach (CcmsVaultLedger tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["transaction_date"] = tran.TransactionDate;
Row["description"] = tran.Description;
Row["transaction_type"] = tran.TransactionType;
Row["ledger_amount"] = tran.LedgerAmount;
Row["balance"] = tran.Balance;
Row["posted_by"] = tran.PostedBy;
Row["vault_id"] = tran.VaultId;
Row["vault_transaction_type"] = tran.VaultTransactionType;
Row["cheque_id"] = tran.ChequeId;
Row["atm_id"] = tran.AtmId;
Row["vault_adjustment_id"] = tran.VaultAdjustmentId;
Row["atm_settlement_id"] = tran.AtmSettlementId;
dt.Rows.Add(Row);
} }
}
}
