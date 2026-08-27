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
public class ReconciliationGlAccountSummary
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReconciliationGlAccountSummary() { }
public ReconciliationGlAccountSummary( int reconciliation_gl_account_summary_id,int reconciliation_gl_account_id,int reconciliation_batch_id,int atm_id ) 
{
this.reconciliation_gl_account_id = reconciliation_gl_account_id;
this.reconciliation_gl_account_idChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
public ReconciliationGlAccountSummary( int reconciliation_gl_account_id,decimal? opening_balance,decimal? closing_balance,DateTime? creation_time,int reconciliation_batch_id,int atm_id )
{
this.reconciliation_gl_account_id = reconciliation_gl_account_id;
this.reconciliation_gl_account_idChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private ReconciliationGlAccountSummary( int reconciliation_gl_account_summary_id,int reconciliation_gl_account_id,decimal? opening_balance,decimal? closing_balance,DateTime? creation_time,int reconciliation_batch_id,int atm_id )
{
this.reconciliation_gl_account_summary_id = reconciliation_gl_account_summary_id;
this.reconciliation_gl_account_summary_idChanged = true;
this.reconciliation_gl_account_id = reconciliation_gl_account_id;
this.reconciliation_gl_account_idChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region ReconciliationGlAccountSummaryId
private bool reconciliation_gl_account_summary_idChanged = false;
private int reconciliation_gl_account_summary_id;
public int ReconciliationGlAccountSummaryId
{
get { return reconciliation_gl_account_summary_id; }
set { 
reconciliation_gl_account_summary_id = value;
reconciliation_gl_account_summary_idChanged = true;
}
}
private string reconciliation_gl_account_summary_idDbString
{
get
{
return reconciliation_gl_account_summary_id.ToString();
}
}
#endregion
#region ReconciliationGlAccountId
private bool reconciliation_gl_account_idChanged = false;
private int reconciliation_gl_account_id;
public int ReconciliationGlAccountId
{
get { return reconciliation_gl_account_id; }
set { 
reconciliation_gl_account_id = value;
reconciliation_gl_account_idChanged = true;
}
}
private string reconciliation_gl_account_idDbString
{
get
{
return reconciliation_gl_account_id.ToString();
}
}
#endregion
#region OpeningBalance
private bool opening_balanceChanged = false;
private decimal? opening_balance;
public decimal? OpeningBalance
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
if (this.opening_balance.HasValue)
return opening_balance.ToString();
else
return "null";
}
}
#endregion
#region ClosingBalance
private bool closing_balanceChanged = false;
private decimal? closing_balance;
public decimal? ClosingBalance
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
if (this.closing_balance.HasValue)
return closing_balance.ToString();
else
return "null";
}
}
#endregion
#region CreationTime
private bool creation_timeChanged = false;
private DateTime? creation_time;
public DateTime? CreationTime
{
get { return creation_time; }
set { 
creation_time = value;
creation_timeChanged = true;
}
}
private string creation_timeDbString
{
get
{
if (this.creation_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",creation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ReconciliationBatchId
private bool reconciliation_batch_idChanged = false;
private int reconciliation_batch_id;
public int ReconciliationBatchId
{
get { return reconciliation_batch_id; }
set { 
reconciliation_batch_id = value;
reconciliation_batch_idChanged = true;
}
}
private string reconciliation_batch_idDbString
{
get
{
return reconciliation_batch_id.ToString();
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int atm_id;
public int AtmId
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
return atm_id.ToString();
}
}
#endregion
#endregion

#region ReconciliationGlAccountSummaryReader
public class ReconciliationGlAccountSummaryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReconciliationGlAccountSummary currentReconciliationGlAccountSummary;
Columns columns;
bool partialRead = false;
private ReconciliationGlAccountSummaryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReconciliationGlAccountSummaryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReconciliationGlAccountSummaryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReconciliationGlAccountSummary; }

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
currentReconciliationGlAccountSummary = new ReconciliationGlAccountSummary();
if (partialRead)
{ if ((columns & Columns.reconciliation_gl_account_summary_id) == Columns.reconciliation_gl_account_summary_id && reader["reconciliation_gl_account_summary_id"]!=DBNull.Value)
currentReconciliationGlAccountSummary.reconciliation_gl_account_summary_id =(int) reader["reconciliation_gl_account_summary_id"]; 
if ((columns & Columns.reconciliation_gl_account_id) == Columns.reconciliation_gl_account_id && reader["reconciliation_gl_account_id"]!=DBNull.Value)
currentReconciliationGlAccountSummary.reconciliation_gl_account_id =(int) reader["reconciliation_gl_account_id"]; 
if ((columns & Columns.opening_balance) == Columns.opening_balance && reader["opening_balance"]!=DBNull.Value)
currentReconciliationGlAccountSummary.opening_balance =(decimal?) reader["opening_balance"]; 
if ((columns & Columns.closing_balance) == Columns.closing_balance && reader["closing_balance"]!=DBNull.Value)
currentReconciliationGlAccountSummary.closing_balance =(decimal?) reader["closing_balance"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentReconciliationGlAccountSummary.creation_time =(DateTime?) reader["creation_time"]; 
if ((columns & Columns.reconciliation_batch_id) == Columns.reconciliation_batch_id && reader["reconciliation_batch_id"]!=DBNull.Value)
currentReconciliationGlAccountSummary.reconciliation_batch_id =(int) reader["reconciliation_batch_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentReconciliationGlAccountSummary.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["reconciliation_gl_account_summary_id"] != DBNull.Value)
currentReconciliationGlAccountSummary.reconciliation_gl_account_summary_id = (int) reader["reconciliation_gl_account_summary_id"]; 
if (reader["reconciliation_gl_account_id"] != DBNull.Value)
currentReconciliationGlAccountSummary.reconciliation_gl_account_id = (int) reader["reconciliation_gl_account_id"]; 
if (reader["opening_balance"] != DBNull.Value)
currentReconciliationGlAccountSummary.opening_balance = (decimal?) reader["opening_balance"]; 
if (reader["closing_balance"] != DBNull.Value)
currentReconciliationGlAccountSummary.closing_balance = (decimal?) reader["closing_balance"]; 
if (reader["creation_time"] != DBNull.Value)
currentReconciliationGlAccountSummary.creation_time = (DateTime?) reader["creation_time"]; 
if (reader["reconciliation_batch_id"] != DBNull.Value)
currentReconciliationGlAccountSummary.reconciliation_batch_id = (int) reader["reconciliation_batch_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentReconciliationGlAccountSummary.atm_id = (int) reader["atm_id"]; 
} 

currentReconciliationGlAccountSummary.isNewEntity = false;
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

public ReconciliationGlAccountSummary CurrentReconciliationGlAccountSummary
{
get{ return currentReconciliationGlAccountSummary; }
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


#region ReconciliationGlAccountSummary functions

public static ReconciliationGlAccountSummaryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.reconciliation_gl_account_summary_id == (Columns.reconciliation_gl_account_summary_id & columns))
qry.Append("reconciliation_gl_account_summary_id,");
if (Columns.reconciliation_gl_account_id == (Columns.reconciliation_gl_account_id & columns))
qry.Append("reconciliation_gl_account_id,");
if (Columns.opening_balance == (Columns.opening_balance & columns))
qry.Append("opening_balance,");
if (Columns.closing_balance == (Columns.closing_balance & columns))
qry.Append("closing_balance,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.reconciliation_batch_id == (Columns.reconciliation_batch_id & columns))
qry.Append("reconciliation_batch_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Reconciliation_gl_account_summary ");

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
return new ReconciliationGlAccountSummaryReader(cmd.ExecuteReader(), conn, columns);
}

static public ReconciliationGlAccountSummaryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReconciliationGlAccountSummaryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select reconciliation_gl_account_summary_id,reconciliation_gl_account_id,opening_balance,closing_balance,creation_time,reconciliation_batch_id,atm_id from Reconciliation_gl_account_summary ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReconciliationGlAccountSummaryReader(cmd.ExecuteReader(), conn);
}

static public ReconciliationGlAccountSummaryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReconciliationGlAccountSummary LoadReconciliationGlAccountSummary(string where)
{
ReconciliationGlAccountSummaryReader reader = ReconciliationGlAccountSummary.ExecuteReader(where);
ReconciliationGlAccountSummary _reconciliationglaccountsummary = null;
if (reader.Read())
_reconciliationglaccountsummary = reader.CurrentReconciliationGlAccountSummary;
reader.Close();
return _reconciliationglaccountsummary;
}

public static ReconciliationGlAccountSummary LoadReconciliationGlAccountSummary(string where, IDbConnection conn)
{
ReconciliationGlAccountSummaryReader reader = ReconciliationGlAccountSummary.ExecuteReader(where, conn);
ReconciliationGlAccountSummary _reconciliationglaccountsummary = null;
if (reader.Read())
_reconciliationglaccountsummary = reader.CurrentReconciliationGlAccountSummary;
reader.Close(false);
return _reconciliationglaccountsummary;
}

public static ReconciliationGlAccountSummary LoadReconciliationGlAccountSummaryByPk( int reconciliation_gl_account_summary_id )
{
return LoadReconciliationGlAccountSummary( " reconciliation_gl_account_summary_id="+reconciliation_gl_account_summary_id );
}

public static ReconciliationGlAccountSummary LoadReconciliationGlAccountSummaryByPk( int reconciliation_gl_account_summary_id , IDbConnection conn)
{
return LoadReconciliationGlAccountSummary(" reconciliation_gl_account_summary_id="+reconciliation_gl_account_summary_id , conn);
}

public void Save()
{
if (reconciliation_gl_account_summary_idChanged || reconciliation_gl_account_idChanged || opening_balanceChanged || closing_balanceChanged || creation_timeChanged || reconciliation_batch_idChanged || atm_idChanged )
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
if (reconciliation_gl_account_summary_idChanged || reconciliation_gl_account_idChanged || opening_balanceChanged || closing_balanceChanged || creation_timeChanged || reconciliation_batch_idChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Reconciliation_gl_account_summary( reconciliation_gl_account_summary_id,reconciliation_gl_account_id,opening_balance,closing_balance,creation_time,reconciliation_batch_id,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.reconciliation_gl_account_summary_id = ConnectionFactory.GetNextId();
qry.Append(this.reconciliation_gl_account_summary_id);
} qry.Append(",");
qry.Append(reconciliation_gl_account_idDbString+",");
qry.Append(opening_balanceDbString+",");
qry.Append(closing_balanceDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(reconciliation_batch_idDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(reconciliation_gl_account_summary_idChanged || reconciliation_gl_account_idChanged || opening_balanceChanged || closing_balanceChanged || creation_timeChanged || reconciliation_batch_idChanged || atm_idChanged ))
return;
qry.Append("UPDATE Reconciliation_gl_account_summary set "); if ( reconciliation_gl_account_idChanged )
{
qry.Append("reconciliation_gl_account_id ="+reconciliation_gl_account_idDbString);
qry.Append(",");
}

if ( opening_balanceChanged )
{
qry.Append("opening_balance ="+opening_balanceDbString);
qry.Append(",");
}

if ( closing_balanceChanged )
{
qry.Append("closing_balance ="+closing_balanceDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( reconciliation_batch_idChanged )
{
qry.Append("reconciliation_batch_id ="+reconciliation_batch_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("reconciliation_gl_account_summary_id = "+reconciliation_gl_account_summary_idDbString);
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
cmd.CommandText = "DELETE Reconciliation_gl_account_summary where reconciliation_gl_account_summary_id = "+ reconciliation_gl_account_summary_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReconciliationGlAccountSummarys(string where)
{
ConnectionFactory.ExecuteQuery("delete Reconciliation_gl_account_summary where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
reconciliation_gl_account_summary_id= 1,
reconciliation_gl_account_id= 2,
opening_balance= 4,
closing_balance= 8,
creation_time= 16,
reconciliation_batch_id= 32,
atm_id= 64
}
#endregion
public void BulkSave(List<ReconciliationGlAccountSummary> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Reconciliation_gl_account_summary";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReconciliationGlAccountSummary.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReconciliationGlAccountSummary> transList,ref DataTable dt)
{
foreach (ReconciliationGlAccountSummary tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["reconciliation_gl_account_summary_id"] =ConnectionFactory.GetNextId();
Row["reconciliation_gl_account_id"] = tran.ReconciliationGlAccountId;
Row["opening_balance"] = tran.OpeningBalance;
Row["closing_balance"] = tran.ClosingBalance;
Row["creation_time"] = tran.CreationTime;
Row["reconciliation_batch_id"] = tran.ReconciliationBatchId;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
