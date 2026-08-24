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
public class ReconciledTransactions
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReconciledTransactions() { }
public ReconciledTransactions( int reconciled_transactions_id,int batch_id,DateTime generated_at,string title,DateTime trxn_datetime,string tsn,decimal amount ) 
{
this.batch_id = batch_id;
this.batch_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.title = title;
this.titleChanged = true;
this.trxn_datetime = trxn_datetime;
this.trxn_datetimeChanged = true;
this.tsn = tsn;
this.tsnChanged = true;
this.amount = amount;
this.amountChanged = true;
}
public ReconciledTransactions( int batch_id,DateTime generated_at,string title,DateTime trxn_datetime,string tsn,decimal amount,string pan,string source )
{
this.batch_id = batch_id;
this.batch_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.title = title;
this.titleChanged = true;
this.trxn_datetime = trxn_datetime;
this.trxn_datetimeChanged = true;
this.tsn = tsn;
this.tsnChanged = true;
this.amount = amount;
this.amountChanged = true;
this.pan = pan;
this.panChanged = true;
this.source = source;
this.sourceChanged = true;
}
private ReconciledTransactions( int reconciled_transactions_id,int batch_id,DateTime generated_at,string title,DateTime trxn_datetime,string tsn,decimal amount,string pan,string source )
{
this.reconciled_transactions_id = reconciled_transactions_id;
this.reconciled_transactions_idChanged = true;
this.batch_id = batch_id;
this.batch_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.title = title;
this.titleChanged = true;
this.trxn_datetime = trxn_datetime;
this.trxn_datetimeChanged = true;
this.tsn = tsn;
this.tsnChanged = true;
this.amount = amount;
this.amountChanged = true;
this.pan = pan;
this.panChanged = true;
this.source = source;
this.sourceChanged = true;
}

#region members and properties for columns

#region ReconciledTransactionsId
private bool reconciled_transactions_idChanged = false;
private int reconciled_transactions_id;
public int ReconciledTransactionsId
{
get { return reconciled_transactions_id; }
set { 
reconciled_transactions_id = value;
reconciled_transactions_idChanged = true;
}
}
private string reconciled_transactions_idDbString
{
get
{
return reconciled_transactions_id.ToString();
}
}
#endregion
#region BatchId
private bool batch_idChanged = false;
private int batch_id;
public int BatchId
{
get { return batch_id; }
set { 
batch_id = value;
batch_idChanged = true;
}
}
private string batch_idDbString
{
get
{
return batch_id.ToString();
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
#region Title
private bool titleChanged = false;
private string title;
public string Title
{
get { return title; }
set { 
title = value;
titleChanged = true;
}
}
private string titleDbString
{
get
{
if (this.title!=null)
return string.Format("'{0}'",title); else
return "null";
}
}
#endregion
#region TrxnDatetime
private bool trxn_datetimeChanged = false;
private DateTime trxn_datetime;
public DateTime TrxnDatetime
{
get { return trxn_datetime; }
set { 
trxn_datetime = value;
trxn_datetimeChanged = true;
}
}
private string trxn_datetimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",trxn_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region Tsn
private bool tsnChanged = false;
private string tsn;
public string Tsn
{
get { return tsn; }
set { 
tsn = value;
tsnChanged = true;
}
}
private string tsnDbString
{
get
{
if (this.tsn!=null)
return string.Format("'{0}'",tsn); else
return "null";
}
}
#endregion
#region Amount
private bool amountChanged = false;
private decimal amount;
public decimal Amount
{
get { return amount; }
set { 
amount = value;
amountChanged = true;
}
}
private string amountDbString
{
get
{
return amount.ToString();
}
}
#endregion
#region Pan
private bool panChanged = false;
private string pan;
public string Pan
{
get { return pan; }
set { 
pan = value;
panChanged = true;
}
}
private string panDbString
{
get
{
if (this.pan!=null)
return string.Format("'{0}'",pan); else
return "null";
}
}
#endregion
#region Source
private bool sourceChanged = false;
private string source;
public string Source
{
get { return source; }
set { 
source = value;
sourceChanged = true;
}
}
private string sourceDbString
{
get
{
if (this.source!=null)
return string.Format("'{0}'",source); else
return "null";
}
}
#endregion
#endregion

#region ReconciledTransactionsReader
public class ReconciledTransactionsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReconciledTransactions currentReconciledTransactions;
Columns columns;
bool partialRead = false;
private ReconciledTransactionsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReconciledTransactionsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReconciledTransactionsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReconciledTransactions; }

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
currentReconciledTransactions = new ReconciledTransactions();
if (partialRead)
{ if ((columns & Columns.reconciled_transactions_id) == Columns.reconciled_transactions_id && reader["reconciled_transactions_id"]!=DBNull.Value)
currentReconciledTransactions.reconciled_transactions_id =(int) reader["reconciled_transactions_id"]; 
if ((columns & Columns.batch_id) == Columns.batch_id && reader["batch_id"]!=DBNull.Value)
currentReconciledTransactions.batch_id =(int) reader["batch_id"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentReconciledTransactions.generated_at =(DateTime) reader["generated_at"]; 
if ((columns & Columns.title) == Columns.title && reader["title"]!=DBNull.Value)
currentReconciledTransactions.title =(string) reader["title"]; 
if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"]!=DBNull.Value)
currentReconciledTransactions.trxn_datetime =(DateTime) reader["trxn_datetime"]; 
if ((columns & Columns.tsn) == Columns.tsn && reader["tsn"]!=DBNull.Value)
currentReconciledTransactions.tsn =(string) reader["tsn"]; 
if ((columns & Columns.amount) == Columns.amount && reader["amount"]!=DBNull.Value)
currentReconciledTransactions.amount =(decimal) reader["amount"]; 
if ((columns & Columns.pan) == Columns.pan && reader["pan"]!=DBNull.Value)
currentReconciledTransactions.pan =(string) reader["pan"]; 
if ((columns & Columns.source) == Columns.source && reader["source"]!=DBNull.Value)
currentReconciledTransactions.source =(string) reader["source"]; 

} else
{
if (reader["reconciled_transactions_id"] != DBNull.Value)
currentReconciledTransactions.reconciled_transactions_id = (int) reader["reconciled_transactions_id"]; 
if (reader["batch_id"] != DBNull.Value)
currentReconciledTransactions.batch_id = (int) reader["batch_id"]; 
if (reader["generated_at"] != DBNull.Value)
currentReconciledTransactions.generated_at = (DateTime) reader["generated_at"]; 
if (reader["title"] != DBNull.Value)
currentReconciledTransactions.title = (string) reader["title"]; 
if (reader["trxn_datetime"] != DBNull.Value)
currentReconciledTransactions.trxn_datetime = (DateTime) reader["trxn_datetime"]; 
if (reader["tsn"] != DBNull.Value)
currentReconciledTransactions.tsn = (string) reader["tsn"]; 
if (reader["amount"] != DBNull.Value)
currentReconciledTransactions.amount = (decimal) reader["amount"]; 
if (reader["pan"] != DBNull.Value)
currentReconciledTransactions.pan = (string) reader["pan"]; 
if (reader["source"] != DBNull.Value)
currentReconciledTransactions.source = (string) reader["source"]; 
} 

currentReconciledTransactions.isNewEntity = false;
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

public ReconciledTransactions CurrentReconciledTransactions
{
get{ return currentReconciledTransactions; }
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


#region ReconciledTransactions functions

public static ReconciledTransactionsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.reconciled_transactions_id == (Columns.reconciled_transactions_id & columns))
qry.Append("reconciled_transactions_id,");
if (Columns.batch_id == (Columns.batch_id & columns))
qry.Append("batch_id,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.title == (Columns.title & columns))
qry.Append("title,");
if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
qry.Append("trxn_datetime,");
if (Columns.tsn == (Columns.tsn & columns))
qry.Append("tsn,");
if (Columns.amount == (Columns.amount & columns))
qry.Append("amount,");
if (Columns.pan == (Columns.pan & columns))
qry.Append("pan,");
if (Columns.source == (Columns.source & columns))
qry.Append("source,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Reconciled_transactions ");

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
return new ReconciledTransactionsReader(cmd.ExecuteReader(), conn, columns);
}

static public ReconciledTransactionsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReconciledTransactionsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select reconciled_transactions_id,batch_id,generated_at,title,trxn_datetime,tsn,amount,pan,source from Reconciled_transactions ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReconciledTransactionsReader(cmd.ExecuteReader(), conn);
}

static public ReconciledTransactionsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReconciledTransactions LoadReconciledTransactions(string where)
{
ReconciledTransactionsReader reader = ReconciledTransactions.ExecuteReader(where);
ReconciledTransactions _reconciledtransactions = null;
if (reader.Read())
_reconciledtransactions = reader.CurrentReconciledTransactions;
reader.Close();
return _reconciledtransactions;
}

public static ReconciledTransactions LoadReconciledTransactions(string where, IDbConnection conn)
{
ReconciledTransactionsReader reader = ReconciledTransactions.ExecuteReader(where, conn);
ReconciledTransactions _reconciledtransactions = null;
if (reader.Read())
_reconciledtransactions = reader.CurrentReconciledTransactions;
reader.Close(false);
return _reconciledtransactions;
}

public static ReconciledTransactions LoadReconciledTransactionsByPk( int reconciled_transactions_id )
{
return LoadReconciledTransactions( " reconciled_transactions_id="+reconciled_transactions_id );
}

public static ReconciledTransactions LoadReconciledTransactionsByPk( int reconciled_transactions_id , IDbConnection conn)
{
return LoadReconciledTransactions(" reconciled_transactions_id="+reconciled_transactions_id , conn);
}

public void Save()
{
if (reconciled_transactions_idChanged || batch_idChanged || generated_atChanged || titleChanged || trxn_datetimeChanged || tsnChanged || amountChanged || panChanged || sourceChanged )
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
if (reconciled_transactions_idChanged || batch_idChanged || generated_atChanged || titleChanged || trxn_datetimeChanged || tsnChanged || amountChanged || panChanged || sourceChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Reconciled_transactions( reconciled_transactions_id,batch_id,generated_at,title,trxn_datetime,tsn,amount,pan,source ) values(");
lock (ConnectionFactory.connectionString) { this.reconciled_transactions_id = ConnectionFactory.GetNextId();
qry.Append(this.reconciled_transactions_id);
} qry.Append(",");
qry.Append(batch_idDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(titleDbString+",");
qry.Append(trxn_datetimeDbString+",");
qry.Append(tsnDbString+",");
qry.Append(amountDbString+",");
qry.Append(panDbString+",");
qry.Append(sourceDbString);
qry.Append(");");

}
else
{
if (!(reconciled_transactions_idChanged || batch_idChanged || generated_atChanged || titleChanged || trxn_datetimeChanged || tsnChanged || amountChanged || panChanged || sourceChanged ))
return;
qry.Append("UPDATE Reconciled_transactions set "); if ( batch_idChanged )
{
qry.Append("batch_id ="+batch_idDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( titleChanged )
{
qry.Append("title ="+titleDbString);
qry.Append(",");
}

if ( trxn_datetimeChanged )
{
qry.Append("trxn_datetime ="+trxn_datetimeDbString);
qry.Append(",");
}

if ( tsnChanged )
{
qry.Append("tsn ="+tsnDbString);
qry.Append(",");
}

if ( amountChanged )
{
qry.Append("amount ="+amountDbString);
qry.Append(",");
}

if ( panChanged )
{
qry.Append("pan ="+panDbString);
qry.Append(",");
}

if ( sourceChanged )
{
qry.Append("source ="+sourceDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("reconciled_transactions_id = "+reconciled_transactions_idDbString);
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
cmd.CommandText = "DELETE Reconciled_transactions where reconciled_transactions_id = "+ reconciled_transactions_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReconciledTransactionss(string where)
{
ConnectionFactory.ExecuteQuery("delete Reconciled_transactions where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
reconciled_transactions_id= 1,
batch_id= 2,
generated_at= 4,
title= 8,
trxn_datetime= 16,
tsn= 32,
amount= 64,
pan= 128,
source= 256
}
#endregion
public void BulkSave(List<ReconciledTransactions> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Reconciled_transactions";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReconciledTransactions.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReconciledTransactions> transList,ref DataTable dt)
{
foreach (ReconciledTransactions tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["reconciled_transactions_id"] =ConnectionFactory.GetNextId();
Row["batch_id"] = tran.BatchId;
Row["generated_at"] = tran.GeneratedAt;
Row["title"] = tran.Title;
Row["trxn_datetime"] = tran.TrxnDatetime;
Row["tsn"] = tran.Tsn;
Row["amount"] = tran.Amount;
Row["pan"] = tran.Pan;
Row["source"] = tran.Source;
dt.Rows.Add(Row);
} }
}
}
