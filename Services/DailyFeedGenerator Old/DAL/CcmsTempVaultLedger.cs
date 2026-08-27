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
public class CcmsTempVaultLedger
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsTempVaultLedger() { }
public CcmsTempVaultLedger( int id,DateTime transaction_date,string transaction_type,decimal ledger_amount,int posted_by,int vault_id,string vault_transaction_type ) 
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
}
public CcmsTempVaultLedger( DateTime transaction_date,string description,string transaction_type,decimal ledger_amount,decimal? balance,int posted_by,int vault_id,string vault_transaction_type,int? cheque_id,int? atm_id,int? order_id )
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
this.order_id = order_id;
this.order_idChanged = true;
}
private CcmsTempVaultLedger( int id,DateTime transaction_date,string description,string transaction_type,decimal ledger_amount,decimal? balance,int posted_by,int vault_id,string vault_transaction_type,int? cheque_id,int? atm_id,int? order_id )
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
this.order_id = order_id;
this.order_idChanged = true;
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
#region OrderId
private bool order_idChanged = false;
private int? order_id;
public int? OrderId
{
get { return order_id; }
set { 
order_id = value;
order_idChanged = true;
}
}
private string order_idDbString
{
get
{
if (this.order_id.HasValue)
return order_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsTempVaultLedgerReader
public class CcmsTempVaultLedgerReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsTempVaultLedger currentCcmsTempVaultLedger;
Columns columns;
bool partialRead = false;
private CcmsTempVaultLedgerReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsTempVaultLedgerReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsTempVaultLedgerReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsTempVaultLedger; }

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
currentCcmsTempVaultLedger = new CcmsTempVaultLedger();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsTempVaultLedger.id =(int) reader["id"]; 
if ((columns & Columns.transaction_date) == Columns.transaction_date && reader["transaction_date"]!=DBNull.Value)
currentCcmsTempVaultLedger.transaction_date =(DateTime) reader["transaction_date"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsTempVaultLedger.description =(string) reader["description"]; 
if ((columns & Columns.transaction_type) == Columns.transaction_type && reader["transaction_type"]!=DBNull.Value)
currentCcmsTempVaultLedger.transaction_type =(string) reader["transaction_type"]; 
if ((columns & Columns.ledger_amount) == Columns.ledger_amount && reader["ledger_amount"]!=DBNull.Value)
currentCcmsTempVaultLedger.ledger_amount =(decimal) reader["ledger_amount"]; 
if ((columns & Columns.balance) == Columns.balance && reader["balance"]!=DBNull.Value)
currentCcmsTempVaultLedger.balance =(decimal?) reader["balance"]; 
if ((columns & Columns.posted_by) == Columns.posted_by && reader["posted_by"]!=DBNull.Value)
currentCcmsTempVaultLedger.posted_by =(int) reader["posted_by"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsTempVaultLedger.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.vault_transaction_type) == Columns.vault_transaction_type && reader["vault_transaction_type"]!=DBNull.Value)
currentCcmsTempVaultLedger.vault_transaction_type =(string) reader["vault_transaction_type"]; 
if ((columns & Columns.cheque_id) == Columns.cheque_id && reader["cheque_id"]!=DBNull.Value)
currentCcmsTempVaultLedger.cheque_id =(int?) reader["cheque_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCcmsTempVaultLedger.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.order_id) == Columns.order_id && reader["order_id"]!=DBNull.Value)
currentCcmsTempVaultLedger.order_id =(int?) reader["order_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsTempVaultLedger.id = (int) reader["id"]; 
if (reader["transaction_date"] != DBNull.Value)
currentCcmsTempVaultLedger.transaction_date = (DateTime) reader["transaction_date"]; 
if (reader["description"] != DBNull.Value)
currentCcmsTempVaultLedger.description = (string) reader["description"]; 
if (reader["transaction_type"] != DBNull.Value)
currentCcmsTempVaultLedger.transaction_type = (string) reader["transaction_type"]; 
if (reader["ledger_amount"] != DBNull.Value)
currentCcmsTempVaultLedger.ledger_amount = (decimal) reader["ledger_amount"]; 
if (reader["balance"] != DBNull.Value)
currentCcmsTempVaultLedger.balance = (decimal?) reader["balance"]; 
if (reader["posted_by"] != DBNull.Value)
currentCcmsTempVaultLedger.posted_by = (int) reader["posted_by"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsTempVaultLedger.vault_id = (int) reader["vault_id"]; 
if (reader["vault_transaction_type"] != DBNull.Value)
currentCcmsTempVaultLedger.vault_transaction_type = (string) reader["vault_transaction_type"]; 
if (reader["cheque_id"] != DBNull.Value)
currentCcmsTempVaultLedger.cheque_id = (int?) reader["cheque_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentCcmsTempVaultLedger.atm_id = (int?) reader["atm_id"]; 
if (reader["order_id"] != DBNull.Value)
currentCcmsTempVaultLedger.order_id = (int?) reader["order_id"]; 
} 

currentCcmsTempVaultLedger.isNewEntity = false;
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

public CcmsTempVaultLedger CurrentCcmsTempVaultLedger
{
get{ return currentCcmsTempVaultLedger; }
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


#region CcmsTempVaultLedger functions

public static CcmsTempVaultLedgerReader ExecuteReader(string where, IDbConnection conn, Columns columns)
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
if (Columns.order_id == (Columns.order_id & columns))
qry.Append("order_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_temp_vault_ledger ");

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
return new CcmsTempVaultLedgerReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsTempVaultLedgerReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsTempVaultLedgerReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,transaction_date,description,transaction_type,ledger_amount,balance,posted_by,vault_id,vault_transaction_type,cheque_id,atm_id,order_id from Ccms_temp_vault_ledger ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsTempVaultLedgerReader(cmd.ExecuteReader(), conn);
}

static public CcmsTempVaultLedgerReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsTempVaultLedger LoadCcmsTempVaultLedger(string where)
{
CcmsTempVaultLedgerReader reader = CcmsTempVaultLedger.ExecuteReader(where);
CcmsTempVaultLedger _ccmstempvaultledger = null;
if (reader.Read())
_ccmstempvaultledger = reader.CurrentCcmsTempVaultLedger;
reader.Close();
return _ccmstempvaultledger;
}

public static CcmsTempVaultLedger LoadCcmsTempVaultLedger(string where, IDbConnection conn)
{
CcmsTempVaultLedgerReader reader = CcmsTempVaultLedger.ExecuteReader(where, conn);
CcmsTempVaultLedger _ccmstempvaultledger = null;
if (reader.Read())
_ccmstempvaultledger = reader.CurrentCcmsTempVaultLedger;
reader.Close(false);
return _ccmstempvaultledger;
}

public static CcmsTempVaultLedger LoadCcmsTempVaultLedgerByPk( int id )
{
return LoadCcmsTempVaultLedger( " id="+id );
}

public static CcmsTempVaultLedger LoadCcmsTempVaultLedgerByPk( int id , IDbConnection conn)
{
return LoadCcmsTempVaultLedger(" id="+id , conn);
}

public void Save()
{
if (idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || ledger_amountChanged || balanceChanged || posted_byChanged || vault_idChanged || vault_transaction_typeChanged || cheque_idChanged || atm_idChanged || order_idChanged )
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
if (idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || ledger_amountChanged || balanceChanged || posted_byChanged || vault_idChanged || vault_transaction_typeChanged || cheque_idChanged || atm_idChanged || order_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_temp_vault_ledger( transaction_date,description,transaction_type,ledger_amount,balance,posted_by,vault_id,vault_transaction_type,cheque_id,atm_id,order_id ) values(");

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
qry.Append(order_idDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || ledger_amountChanged || balanceChanged || posted_byChanged || vault_idChanged || vault_transaction_typeChanged || cheque_idChanged || atm_idChanged || order_idChanged ))
return;
qry.Append("UPDATE Ccms_temp_vault_ledger set "); if ( transaction_dateChanged )
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

if ( order_idChanged )
{
qry.Append("order_id ="+order_idDbString);
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
    //cmd.ExecuteNonQuery();
    object res = cmd.ExecuteScalar();
    if (res == DBNull.Value)
        id = 1;
    else
        id = int.Parse(res.ToString());
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
cmd.CommandText = "DELETE Ccms_temp_vault_ledger where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsTempVaultLedgers(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_temp_vault_ledger where " + where);
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
order_id= 2048
}
#endregion
public void BulkSave(List<CcmsTempVaultLedger> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_temp_vault_ledger";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsTempVaultLedger.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsTempVaultLedger> transList,ref DataTable dt)
{
foreach (CcmsTempVaultLedger tran in transList)
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
Row["order_id"] = tran.OrderId;
dt.Rows.Add(Row);
} }
}
}
