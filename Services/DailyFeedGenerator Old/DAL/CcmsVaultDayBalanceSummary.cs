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
public class CcmsVaultDayBalanceSummary
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsVaultDayBalanceSummary() { }
public CcmsVaultDayBalanceSummary( int ccms_vault_day_balance_summary_id,int opening_balance,int closing_balance,string denomination_name,int vault_id,DateTime transaction_date,DateTime generated_at ) 
{
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}
public CcmsVaultDayBalanceSummary( int opening_balance,int closing_balance,int? bulk_cash,int? cash_delivered_to_atm,int? cash_returned_to_atm,string denomination_name,int vault_id,DateTime transaction_date,DateTime generated_at )
{
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.bulk_cash = bulk_cash;
this.bulk_cashChanged = true;
this.cash_delivered_to_atm = cash_delivered_to_atm;
this.cash_delivered_to_atmChanged = true;
this.cash_returned_to_atm = cash_returned_to_atm;
this.cash_returned_to_atmChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}
private CcmsVaultDayBalanceSummary( int ccms_vault_day_balance_summary_id,int opening_balance,int closing_balance,int? bulk_cash,int? cash_delivered_to_atm,int? cash_returned_to_atm,string denomination_name,int vault_id,DateTime transaction_date,DateTime generated_at )
{
this.ccms_vault_day_balance_summary_id = ccms_vault_day_balance_summary_id;
this.ccms_vault_day_balance_summary_idChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.bulk_cash = bulk_cash;
this.bulk_cashChanged = true;
this.cash_delivered_to_atm = cash_delivered_to_atm;
this.cash_delivered_to_atmChanged = true;
this.cash_returned_to_atm = cash_returned_to_atm;
this.cash_returned_to_atmChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}

#region members and properties for columns

#region CcmsVaultDayBalanceSummaryId
private bool ccms_vault_day_balance_summary_idChanged = false;
private int ccms_vault_day_balance_summary_id;
public int CcmsVaultDayBalanceSummaryId
{
get { return ccms_vault_day_balance_summary_id; }
set { 
ccms_vault_day_balance_summary_id = value;
ccms_vault_day_balance_summary_idChanged = true;
}
}
private string ccms_vault_day_balance_summary_idDbString
{
get
{
return ccms_vault_day_balance_summary_id.ToString();
}
}
#endregion
#region OpeningBalance
private bool opening_balanceChanged = false;
private int opening_balance;
public int OpeningBalance
{
get { return opening_balance; }
set { 
opening_balance = value;
opening_balanceChanged = true;
}
}
private string opening_balanceDbString
{
get
{
return opening_balance.ToString();
}
}
#endregion
#region ClosingBalance
private bool closing_balanceChanged = false;
private int closing_balance;
public int ClosingBalance
{
get { return closing_balance; }
set { 
closing_balance = value;
closing_balanceChanged = true;
}
}
private string closing_balanceDbString
{
get
{
return closing_balance.ToString();
}
}
#endregion
#region BulkCash
private bool bulk_cashChanged = false;
private int? bulk_cash;
public int? BulkCash
{
get { return bulk_cash; }
set { 
bulk_cash = value;
bulk_cashChanged = true;
}
}
private string bulk_cashDbString
{
get
{
if (this.bulk_cash.HasValue)
return bulk_cash.ToString();
else
return "null";
}
}
#endregion
#region CashDeliveredToAtm
private bool cash_delivered_to_atmChanged = false;
private int? cash_delivered_to_atm;
public int? CashDeliveredToAtm
{
get { return cash_delivered_to_atm; }
set { 
cash_delivered_to_atm = value;
cash_delivered_to_atmChanged = true;
}
}
private string cash_delivered_to_atmDbString
{
get
{
if (this.cash_delivered_to_atm.HasValue)
return cash_delivered_to_atm.ToString();
else
return "null";
}
}
#endregion
#region CashReturnedToAtm
private bool cash_returned_to_atmChanged = false;
private int? cash_returned_to_atm;
public int? CashReturnedToAtm
{
get { return cash_returned_to_atm; }
set { 
cash_returned_to_atm = value;
cash_returned_to_atmChanged = true;
}
}
private string cash_returned_to_atmDbString
{
get
{
if (this.cash_returned_to_atm.HasValue)
return cash_returned_to_atm.ToString();
else
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

#region CcmsVaultDayBalanceSummaryReader
public class CcmsVaultDayBalanceSummaryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsVaultDayBalanceSummary currentCcmsVaultDayBalanceSummary;
Columns columns;
bool partialRead = false;
private CcmsVaultDayBalanceSummaryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsVaultDayBalanceSummaryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsVaultDayBalanceSummaryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsVaultDayBalanceSummary; }

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
currentCcmsVaultDayBalanceSummary = new CcmsVaultDayBalanceSummary();
if (partialRead)
{ if ((columns & Columns.ccms_vault_day_balance_summary_id) == Columns.ccms_vault_day_balance_summary_id && reader["ccms_vault_day_balance_summary_id"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.ccms_vault_day_balance_summary_id =(int) reader["ccms_vault_day_balance_summary_id"]; 
if ((columns & Columns.opening_balance) == Columns.opening_balance && reader["opening_balance"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.opening_balance =(int) reader["opening_balance"]; 
if ((columns & Columns.closing_balance) == Columns.closing_balance && reader["closing_balance"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.closing_balance =(int) reader["closing_balance"]; 
if ((columns & Columns.bulk_cash) == Columns.bulk_cash && reader["bulk_cash"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.bulk_cash =(int?) reader["bulk_cash"]; 
if ((columns & Columns.cash_delivered_to_atm) == Columns.cash_delivered_to_atm && reader["cash_delivered_to_atm"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.cash_delivered_to_atm =(int?) reader["cash_delivered_to_atm"]; 
if ((columns & Columns.cash_returned_to_atm) == Columns.cash_returned_to_atm && reader["cash_returned_to_atm"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.cash_returned_to_atm =(int?) reader["cash_returned_to_atm"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.transaction_date) == Columns.transaction_date && reader["transaction_date"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.transaction_date =(DateTime) reader["transaction_date"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentCcmsVaultDayBalanceSummary.generated_at =(DateTime) reader["generated_at"]; 

} else
{
if (reader["ccms_vault_day_balance_summary_id"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.ccms_vault_day_balance_summary_id = (int) reader["ccms_vault_day_balance_summary_id"]; 
if (reader["opening_balance"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.opening_balance = (int) reader["opening_balance"]; 
if (reader["closing_balance"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.closing_balance = (int) reader["closing_balance"]; 
if (reader["bulk_cash"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.bulk_cash = (int?) reader["bulk_cash"]; 
if (reader["cash_delivered_to_atm"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.cash_delivered_to_atm = (int?) reader["cash_delivered_to_atm"]; 
if (reader["cash_returned_to_atm"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.cash_returned_to_atm = (int?) reader["cash_returned_to_atm"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.denomination_name = (string) reader["denomination_name"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.vault_id = (int) reader["vault_id"]; 
if (reader["transaction_date"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.transaction_date = (DateTime) reader["transaction_date"]; 
if (reader["generated_at"] != DBNull.Value)
currentCcmsVaultDayBalanceSummary.generated_at = (DateTime) reader["generated_at"]; 
} 

currentCcmsVaultDayBalanceSummary.isNewEntity = false;
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

public CcmsVaultDayBalanceSummary CurrentCcmsVaultDayBalanceSummary
{
get{ return currentCcmsVaultDayBalanceSummary; }
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


#region CcmsVaultDayBalanceSummary functions

public static CcmsVaultDayBalanceSummaryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.ccms_vault_day_balance_summary_id == (Columns.ccms_vault_day_balance_summary_id & columns))
qry.Append("ccms_vault_day_balance_summary_id,");
if (Columns.opening_balance == (Columns.opening_balance & columns))
qry.Append("opening_balance,");
if (Columns.closing_balance == (Columns.closing_balance & columns))
qry.Append("closing_balance,");
if (Columns.bulk_cash == (Columns.bulk_cash & columns))
qry.Append("bulk_cash,");
if (Columns.cash_delivered_to_atm == (Columns.cash_delivered_to_atm & columns))
qry.Append("cash_delivered_to_atm,");
if (Columns.cash_returned_to_atm == (Columns.cash_returned_to_atm & columns))
qry.Append("cash_returned_to_atm,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.transaction_date == (Columns.transaction_date & columns))
qry.Append("transaction_date,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_vault_day_balance_summary ");

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
return new CcmsVaultDayBalanceSummaryReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsVaultDayBalanceSummaryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsVaultDayBalanceSummaryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select ccms_vault_day_balance_summary_id,opening_balance,closing_balance,bulk_cash,cash_delivered_to_atm,cash_returned_to_atm,denomination_name,vault_id,transaction_date,generated_at from Ccms_vault_day_balance_summary ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsVaultDayBalanceSummaryReader(cmd.ExecuteReader(), conn);
}

static public CcmsVaultDayBalanceSummaryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsVaultDayBalanceSummary LoadCcmsVaultDayBalanceSummary(string where)
{
CcmsVaultDayBalanceSummaryReader reader = CcmsVaultDayBalanceSummary.ExecuteReader(where);
CcmsVaultDayBalanceSummary _ccmsvaultdaybalancesummary = null;
if (reader.Read())
_ccmsvaultdaybalancesummary = reader.CurrentCcmsVaultDayBalanceSummary;
reader.Close();
return _ccmsvaultdaybalancesummary;
}

public static CcmsVaultDayBalanceSummary LoadCcmsVaultDayBalanceSummary(string where, IDbConnection conn)
{
CcmsVaultDayBalanceSummaryReader reader = CcmsVaultDayBalanceSummary.ExecuteReader(where, conn);
CcmsVaultDayBalanceSummary _ccmsvaultdaybalancesummary = null;
if (reader.Read())
_ccmsvaultdaybalancesummary = reader.CurrentCcmsVaultDayBalanceSummary;
reader.Close(false);
return _ccmsvaultdaybalancesummary;
}

public static CcmsVaultDayBalanceSummary LoadCcmsVaultDayBalanceSummaryByPk( int ccms_vault_day_balance_summary_id )
{
return LoadCcmsVaultDayBalanceSummary( " ccms_vault_day_balance_summary_id="+ccms_vault_day_balance_summary_id );
}

public static CcmsVaultDayBalanceSummary LoadCcmsVaultDayBalanceSummaryByPk( int ccms_vault_day_balance_summary_id , IDbConnection conn)
{
return LoadCcmsVaultDayBalanceSummary(" ccms_vault_day_balance_summary_id="+ccms_vault_day_balance_summary_id , conn);
}

public void Save()
{
if (ccms_vault_day_balance_summary_idChanged || opening_balanceChanged || closing_balanceChanged || bulk_cashChanged || cash_delivered_to_atmChanged || cash_returned_to_atmChanged || denomination_nameChanged || vault_idChanged || transaction_dateChanged || generated_atChanged )
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
if (ccms_vault_day_balance_summary_idChanged || opening_balanceChanged || closing_balanceChanged || bulk_cashChanged || cash_delivered_to_atmChanged || cash_returned_to_atmChanged || denomination_nameChanged || vault_idChanged || transaction_dateChanged || generated_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_vault_day_balance_summary( ccms_vault_day_balance_summary_id,opening_balance,closing_balance,bulk_cash,cash_delivered_to_atm,cash_returned_to_atm,denomination_name,vault_id,transaction_date,generated_at ) values(");
lock (ConnectionFactory.connectionString) { this.ccms_vault_day_balance_summary_id = ConnectionFactory.GetNextId();
qry.Append(this.ccms_vault_day_balance_summary_id);
} qry.Append(",");
qry.Append(opening_balanceDbString+",");
qry.Append(closing_balanceDbString+",");
qry.Append(bulk_cashDbString+",");
qry.Append(cash_delivered_to_atmDbString+",");
qry.Append(cash_returned_to_atmDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(transaction_dateDbString+",");
qry.Append(generated_atDbString);
qry.Append(");");

}
else
{
if (!(ccms_vault_day_balance_summary_idChanged || opening_balanceChanged || closing_balanceChanged || bulk_cashChanged || cash_delivered_to_atmChanged || cash_returned_to_atmChanged || denomination_nameChanged || vault_idChanged || transaction_dateChanged || generated_atChanged ))
return;
qry.Append("UPDATE Ccms_vault_day_balance_summary set "); if ( opening_balanceChanged )
{
qry.Append("opening_balance ="+opening_balanceDbString);
qry.Append(",");
}

if ( closing_balanceChanged )
{
qry.Append("closing_balance ="+closing_balanceDbString);
qry.Append(",");
}

if ( bulk_cashChanged )
{
qry.Append("bulk_cash ="+bulk_cashDbString);
qry.Append(",");
}

if ( cash_delivered_to_atmChanged )
{
qry.Append("cash_delivered_to_atm ="+cash_delivered_to_atmDbString);
qry.Append(",");
}

if ( cash_returned_to_atmChanged )
{
qry.Append("cash_returned_to_atm ="+cash_returned_to_atmDbString);
qry.Append(",");
}

if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( transaction_dateChanged )
{
qry.Append("transaction_date ="+transaction_dateDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("ccms_vault_day_balance_summary_id = "+ccms_vault_day_balance_summary_idDbString);
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
cmd.CommandText = "DELETE Ccms_vault_day_balance_summary where ccms_vault_day_balance_summary_id = "+ ccms_vault_day_balance_summary_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsVaultDayBalanceSummarys(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_vault_day_balance_summary where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
ccms_vault_day_balance_summary_id= 1,
opening_balance= 2,
closing_balance= 4,
bulk_cash= 8,
cash_delivered_to_atm= 16,
cash_returned_to_atm= 32,
denomination_name= 64,
vault_id= 128,
transaction_date= 256,
generated_at= 512
}
#endregion
public void BulkSave(List<CcmsVaultDayBalanceSummary> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_vault_day_balance_summary";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsVaultDayBalanceSummary.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsVaultDayBalanceSummary> transList,ref DataTable dt)
{
foreach (CcmsVaultDayBalanceSummary tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["ccms_vault_day_balance_summary_id"] =ConnectionFactory.GetNextId();
Row["opening_balance"] = tran.OpeningBalance;
Row["closing_balance"] = tran.ClosingBalance;
Row["bulk_cash"] = tran.BulkCash;
Row["cash_delivered_to_atm"] = tran.CashDeliveredToAtm;
Row["cash_returned_to_atm"] = tran.CashReturnedToAtm;
Row["denomination_name"] = tran.DenominationName;
Row["vault_id"] = tran.VaultId;
Row["transaction_date"] = tran.TransactionDate;
Row["generated_at"] = tran.GeneratedAt;
dt.Rows.Add(Row);
} }
}
}
