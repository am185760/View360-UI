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
public class ReconciliationTransactions
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReconciliationTransactions() { }
public ReconciliationTransactions( int reconciliation_transactions_id,int reconciliation_switch_data_id,int reconciliation_host_data_id,int ej_parsed_transactions_id,int parsed_transactions_id,int comparison_type,int user_id,DateTime generated_at,int reconciliation_batch_id,string status ) 
{
this.reconciliation_switch_data_id = reconciliation_switch_data_id;
this.reconciliation_switch_data_idChanged = true;
this.reconciliation_host_data_id = reconciliation_host_data_id;
this.reconciliation_host_data_idChanged = true;
this.ej_parsed_transactions_id = ej_parsed_transactions_id;
this.ej_parsed_transactions_idChanged = true;
this.parsed_transactions_id = parsed_transactions_id;
this.parsed_transactions_idChanged = true;
this.comparison_type = comparison_type;
this.comparison_typeChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.status = status;
this.statusChanged = true;
}
public ReconciliationTransactions( int reconciliation_switch_data_id,int reconciliation_host_data_id,int ej_parsed_transactions_id,int parsed_transactions_id,int comparison_type,bool? is_reconciled,bool? is_reconciled_manually,int user_id,DateTime generated_at,DateTime? updated_at,string reason,int reconciliation_batch_id,string status,string user_comments )
{
this.reconciliation_switch_data_id = reconciliation_switch_data_id;
this.reconciliation_switch_data_idChanged = true;
this.reconciliation_host_data_id = reconciliation_host_data_id;
this.reconciliation_host_data_idChanged = true;
this.ej_parsed_transactions_id = ej_parsed_transactions_id;
this.ej_parsed_transactions_idChanged = true;
this.parsed_transactions_id = parsed_transactions_id;
this.parsed_transactions_idChanged = true;
this.comparison_type = comparison_type;
this.comparison_typeChanged = true;
this.is_reconciled = is_reconciled;
this.is_reconciledChanged = true;
this.is_reconciled_manually = is_reconciled_manually;
this.is_reconciled_manuallyChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.updated_at = updated_at;
this.updated_atChanged = true;
this.reason = reason;
this.reasonChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.status = status;
this.statusChanged = true;
this.user_comments = user_comments;
this.user_commentsChanged = true;
}
private ReconciliationTransactions( int reconciliation_transactions_id,int reconciliation_switch_data_id,int reconciliation_host_data_id,int ej_parsed_transactions_id,int parsed_transactions_id,int comparison_type,bool? is_reconciled,bool? is_reconciled_manually,int user_id,DateTime generated_at,DateTime? updated_at,string reason,int reconciliation_batch_id,string status,string user_comments )
{
this.reconciliation_transactions_id = reconciliation_transactions_id;
this.reconciliation_transactions_idChanged = true;
this.reconciliation_switch_data_id = reconciliation_switch_data_id;
this.reconciliation_switch_data_idChanged = true;
this.reconciliation_host_data_id = reconciliation_host_data_id;
this.reconciliation_host_data_idChanged = true;
this.ej_parsed_transactions_id = ej_parsed_transactions_id;
this.ej_parsed_transactions_idChanged = true;
this.parsed_transactions_id = parsed_transactions_id;
this.parsed_transactions_idChanged = true;
this.comparison_type = comparison_type;
this.comparison_typeChanged = true;
this.is_reconciled = is_reconciled;
this.is_reconciledChanged = true;
this.is_reconciled_manually = is_reconciled_manually;
this.is_reconciled_manuallyChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.updated_at = updated_at;
this.updated_atChanged = true;
this.reason = reason;
this.reasonChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.status = status;
this.statusChanged = true;
this.user_comments = user_comments;
this.user_commentsChanged = true;
}

#region members and properties for columns

#region ReconciliationTransactionsId
private bool reconciliation_transactions_idChanged = false;
private int reconciliation_transactions_id;
public int ReconciliationTransactionsId
{
get { return reconciliation_transactions_id; }
set { 
reconciliation_transactions_id = value;
reconciliation_transactions_idChanged = true;
}
}
private string reconciliation_transactions_idDbString
{
get
{
return reconciliation_transactions_id.ToString();
}
}
#endregion
#region ReconciliationSwitchDataId
private bool reconciliation_switch_data_idChanged = false;
private int reconciliation_switch_data_id;
public int ReconciliationSwitchDataId
{
get { return reconciliation_switch_data_id; }
set { 
reconciliation_switch_data_id = value;
reconciliation_switch_data_idChanged = true;
}
}
private string reconciliation_switch_data_idDbString
{
get
{
return reconciliation_switch_data_id.ToString();
}
}
#endregion
#region ReconciliationHostDataId
private bool reconciliation_host_data_idChanged = false;
private int reconciliation_host_data_id;
public int ReconciliationHostDataId
{
get { return reconciliation_host_data_id; }
set { 
reconciliation_host_data_id = value;
reconciliation_host_data_idChanged = true;
}
}
private string reconciliation_host_data_idDbString
{
get
{
return reconciliation_host_data_id.ToString();
}
}
#endregion
#region EjParsedTransactionsId
private bool ej_parsed_transactions_idChanged = false;
private int ej_parsed_transactions_id;
public int EjParsedTransactionsId
{
get { return ej_parsed_transactions_id; }
set { 
ej_parsed_transactions_id = value;
ej_parsed_transactions_idChanged = true;
}
}
private string ej_parsed_transactions_idDbString
{
get
{
return ej_parsed_transactions_id.ToString();
}
}
#endregion
#region ParsedTransactionsId
private bool parsed_transactions_idChanged = false;
private int parsed_transactions_id;
public int ParsedTransactionsId
{
get { return parsed_transactions_id; }
set { 
parsed_transactions_id = value;
parsed_transactions_idChanged = true;
}
}
private string parsed_transactions_idDbString
{
get
{
return parsed_transactions_id.ToString();
}
}
#endregion
#region ComparisonType
private bool comparison_typeChanged = false;
private int comparison_type;
public int ComparisonType
{
get { return comparison_type; }
set { 
comparison_type = value;
comparison_typeChanged = true;
}
}
private string comparison_typeDbString
{
get
{
return comparison_type.ToString();
}
}
#endregion
#region IsReconciled
private bool is_reconciledChanged = false;
private bool? is_reconciled;
public bool? IsReconciled
{
get { return is_reconciled; }
set { 
is_reconciled = value;
is_reconciledChanged = true;
}
}
private string is_reconciledDbString
{
get
{
if (this.is_reconciled.HasValue)
return is_reconciled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region IsReconciledManually
private bool is_reconciled_manuallyChanged = false;
private bool? is_reconciled_manually;
public bool? IsReconciledManually
{
get { return is_reconciled_manually; }
set { 
is_reconciled_manually = value;
is_reconciled_manuallyChanged = true;
}
}
private string is_reconciled_manuallyDbString
{
get
{
if (this.is_reconciled_manually.HasValue)
return is_reconciled_manually.Value?"1":"0";
else
return "null";
}
}
#endregion
#region UserId
private bool user_idChanged = false;
private int user_id;
public int UserId
{
get { return user_id; }
set { 
user_id = value;
user_idChanged = true;
}
}
private string user_idDbString
{
get
{
return user_id.ToString();
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
#region UpdatedAt
private bool updated_atChanged = false;
private DateTime? updated_at;
public DateTime? UpdatedAt
{
get { return updated_at; }
set { 
updated_at = value;
updated_atChanged = true;
}
}
private string updated_atDbString
{
get
{
if (this.updated_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",updated_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region Reason
private bool reasonChanged = false;
private string reason;
public string Reason
{
get { return reason; }
set { 
reason = value;
reasonChanged = true;
}
}
private string reasonDbString
{
get
{
if (this.reason!=null)
return string.Format("'{0}'",reason); else
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
#region Status
private bool statusChanged = false;
private string status;
public string Status
{
get { return status; }
set { 
status = value;
statusChanged = true;
}
}
private string statusDbString
{
get
{
if (this.status!=null)
return string.Format("'{0}'",status); else
return "null";
}
}
#endregion
#region UserComments
private bool user_commentsChanged = false;
private string user_comments;
public string UserComments
{
get { return user_comments; }
set { 
user_comments = value;
user_commentsChanged = true;
}
}
private string user_commentsDbString
{
get
{
if (this.user_comments!=null)
return string.Format("'{0}'",user_comments); else
return "null";
}
}
#endregion
#endregion

#region ReconciliationTransactionsReader
public class ReconciliationTransactionsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReconciliationTransactions currentReconciliationTransactions;
Columns columns;
bool partialRead = false;
private ReconciliationTransactionsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReconciliationTransactionsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReconciliationTransactionsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReconciliationTransactions; }

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
currentReconciliationTransactions = new ReconciliationTransactions();
if (partialRead)
{ if ((columns & Columns.reconciliation_transactions_id) == Columns.reconciliation_transactions_id && reader["reconciliation_transactions_id"]!=DBNull.Value)
currentReconciliationTransactions.reconciliation_transactions_id =(int) reader["reconciliation_transactions_id"]; 
if ((columns & Columns.reconciliation_switch_data_id) == Columns.reconciliation_switch_data_id && reader["reconciliation_switch_data_id"]!=DBNull.Value)
currentReconciliationTransactions.reconciliation_switch_data_id =(int) reader["reconciliation_switch_data_id"]; 
if ((columns & Columns.reconciliation_host_data_id) == Columns.reconciliation_host_data_id && reader["reconciliation_host_data_id"]!=DBNull.Value)
currentReconciliationTransactions.reconciliation_host_data_id =(int) reader["reconciliation_host_data_id"]; 
if ((columns & Columns.ej_parsed_transactions_id) == Columns.ej_parsed_transactions_id && reader["ej_parsed_transactions_id"]!=DBNull.Value)
currentReconciliationTransactions.ej_parsed_transactions_id =(int) reader["ej_parsed_transactions_id"]; 
if ((columns & Columns.parsed_transactions_id) == Columns.parsed_transactions_id && reader["parsed_transactions_id"]!=DBNull.Value)
currentReconciliationTransactions.parsed_transactions_id =(int) reader["parsed_transactions_id"]; 
if ((columns & Columns.comparison_type) == Columns.comparison_type && reader["comparison_type"]!=DBNull.Value)
currentReconciliationTransactions.comparison_type =(int) reader["comparison_type"]; 
if ((columns & Columns.is_reconciled) == Columns.is_reconciled && reader["is_reconciled"]!=DBNull.Value)
currentReconciliationTransactions.is_reconciled =(bool?) reader["is_reconciled"]; 
if ((columns & Columns.is_reconciled_manually) == Columns.is_reconciled_manually && reader["is_reconciled_manually"]!=DBNull.Value)
currentReconciliationTransactions.is_reconciled_manually =(bool?) reader["is_reconciled_manually"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentReconciliationTransactions.user_id =(int) reader["user_id"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentReconciliationTransactions.generated_at =(DateTime) reader["generated_at"]; 
if ((columns & Columns.updated_at) == Columns.updated_at && reader["updated_at"]!=DBNull.Value)
currentReconciliationTransactions.updated_at =(DateTime?) reader["updated_at"]; 
if ((columns & Columns.reason) == Columns.reason && reader["reason"]!=DBNull.Value)
currentReconciliationTransactions.reason =(string) reader["reason"]; 
if ((columns & Columns.reconciliation_batch_id) == Columns.reconciliation_batch_id && reader["reconciliation_batch_id"]!=DBNull.Value)
currentReconciliationTransactions.reconciliation_batch_id =(int) reader["reconciliation_batch_id"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentReconciliationTransactions.status =(string) reader["status"]; 
if ((columns & Columns.user_comments) == Columns.user_comments && reader["user_comments"]!=DBNull.Value)
currentReconciliationTransactions.user_comments =(string) reader["user_comments"]; 

} else
{
if (reader["reconciliation_transactions_id"] != DBNull.Value)
currentReconciliationTransactions.reconciliation_transactions_id = (int) reader["reconciliation_transactions_id"]; 
if (reader["reconciliation_switch_data_id"] != DBNull.Value)
currentReconciliationTransactions.reconciliation_switch_data_id = (int) reader["reconciliation_switch_data_id"]; 
if (reader["reconciliation_host_data_id"] != DBNull.Value)
currentReconciliationTransactions.reconciliation_host_data_id = (int) reader["reconciliation_host_data_id"]; 
if (reader["ej_parsed_transactions_id"] != DBNull.Value)
currentReconciliationTransactions.ej_parsed_transactions_id = (int) reader["ej_parsed_transactions_id"]; 
if (reader["parsed_transactions_id"] != DBNull.Value)
currentReconciliationTransactions.parsed_transactions_id = (int) reader["parsed_transactions_id"]; 
if (reader["comparison_type"] != DBNull.Value)
currentReconciliationTransactions.comparison_type = (int) reader["comparison_type"]; 
if (reader["is_reconciled"] != DBNull.Value)
currentReconciliationTransactions.is_reconciled = (bool?) reader["is_reconciled"]; 
if (reader["is_reconciled_manually"] != DBNull.Value)
currentReconciliationTransactions.is_reconciled_manually = (bool?) reader["is_reconciled_manually"]; 
if (reader["user_id"] != DBNull.Value)
currentReconciliationTransactions.user_id = (int) reader["user_id"]; 
if (reader["generated_at"] != DBNull.Value)
currentReconciliationTransactions.generated_at = (DateTime) reader["generated_at"]; 
if (reader["updated_at"] != DBNull.Value)
currentReconciliationTransactions.updated_at = (DateTime?) reader["updated_at"]; 
if (reader["reason"] != DBNull.Value)
currentReconciliationTransactions.reason = (string) reader["reason"]; 
if (reader["reconciliation_batch_id"] != DBNull.Value)
currentReconciliationTransactions.reconciliation_batch_id = (int) reader["reconciliation_batch_id"]; 
if (reader["status"] != DBNull.Value)
currentReconciliationTransactions.status = (string) reader["status"]; 
if (reader["user_comments"] != DBNull.Value)
currentReconciliationTransactions.user_comments = (string) reader["user_comments"]; 
} 

currentReconciliationTransactions.isNewEntity = false;
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

public ReconciliationTransactions CurrentReconciliationTransactions
{
get{ return currentReconciliationTransactions; }
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


#region ReconciliationTransactions functions

public static ReconciliationTransactionsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.reconciliation_transactions_id == (Columns.reconciliation_transactions_id & columns))
qry.Append("reconciliation_transactions_id,");
if (Columns.reconciliation_switch_data_id == (Columns.reconciliation_switch_data_id & columns))
qry.Append("reconciliation_switch_data_id,");
if (Columns.reconciliation_host_data_id == (Columns.reconciliation_host_data_id & columns))
qry.Append("reconciliation_host_data_id,");
if (Columns.ej_parsed_transactions_id == (Columns.ej_parsed_transactions_id & columns))
qry.Append("ej_parsed_transactions_id,");
if (Columns.parsed_transactions_id == (Columns.parsed_transactions_id & columns))
qry.Append("parsed_transactions_id,");
if (Columns.comparison_type == (Columns.comparison_type & columns))
qry.Append("comparison_type,");
if (Columns.is_reconciled == (Columns.is_reconciled & columns))
qry.Append("is_reconciled,");
if (Columns.is_reconciled_manually == (Columns.is_reconciled_manually & columns))
qry.Append("is_reconciled_manually,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.updated_at == (Columns.updated_at & columns))
qry.Append("updated_at,");
if (Columns.reason == (Columns.reason & columns))
qry.Append("reason,");
if (Columns.reconciliation_batch_id == (Columns.reconciliation_batch_id & columns))
qry.Append("reconciliation_batch_id,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.user_comments == (Columns.user_comments & columns))
qry.Append("user_comments,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Reconciliation_transactions ");

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
return new ReconciliationTransactionsReader(cmd.ExecuteReader(), conn, columns);
}

static public ReconciliationTransactionsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReconciliationTransactionsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select reconciliation_transactions_id,reconciliation_switch_data_id,reconciliation_host_data_id,ej_parsed_transactions_id,parsed_transactions_id,comparison_type,is_reconciled,is_reconciled_manually,user_id,generated_at,updated_at,reason,reconciliation_batch_id,status,user_comments from Reconciliation_transactions ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReconciliationTransactionsReader(cmd.ExecuteReader(), conn);
}

static public ReconciliationTransactionsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReconciliationTransactions LoadReconciliationTransactions(string where)
{
ReconciliationTransactionsReader reader = ReconciliationTransactions.ExecuteReader(where);
ReconciliationTransactions _reconciliationtransactions = null;
if (reader.Read())
_reconciliationtransactions = reader.CurrentReconciliationTransactions;
reader.Close();
return _reconciliationtransactions;
}

public static ReconciliationTransactions LoadReconciliationTransactions(string where, IDbConnection conn)
{
ReconciliationTransactionsReader reader = ReconciliationTransactions.ExecuteReader(where, conn);
ReconciliationTransactions _reconciliationtransactions = null;
if (reader.Read())
_reconciliationtransactions = reader.CurrentReconciliationTransactions;
reader.Close(false);
return _reconciliationtransactions;
}

public static ReconciliationTransactions LoadReconciliationTransactionsByPk( int reconciliation_transactions_id )
{
return LoadReconciliationTransactions( " reconciliation_transactions_id="+reconciliation_transactions_id );
}

public static ReconciliationTransactions LoadReconciliationTransactionsByPk( int reconciliation_transactions_id , IDbConnection conn)
{
return LoadReconciliationTransactions(" reconciliation_transactions_id="+reconciliation_transactions_id , conn);
}

public void Save()
{
if (reconciliation_transactions_idChanged || reconciliation_switch_data_idChanged || reconciliation_host_data_idChanged || ej_parsed_transactions_idChanged || parsed_transactions_idChanged || comparison_typeChanged || is_reconciledChanged || is_reconciled_manuallyChanged || user_idChanged || generated_atChanged || updated_atChanged || reasonChanged || reconciliation_batch_idChanged || statusChanged || user_commentsChanged )
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
if (reconciliation_transactions_idChanged || reconciliation_switch_data_idChanged || reconciliation_host_data_idChanged || ej_parsed_transactions_idChanged || parsed_transactions_idChanged || comparison_typeChanged || is_reconciledChanged || is_reconciled_manuallyChanged || user_idChanged || generated_atChanged || updated_atChanged || reasonChanged || reconciliation_batch_idChanged || statusChanged || user_commentsChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Reconciliation_transactions( reconciliation_transactions_id,reconciliation_switch_data_id,reconciliation_host_data_id,ej_parsed_transactions_id,parsed_transactions_id,comparison_type,is_reconciled,is_reconciled_manually,user_id,generated_at,updated_at,reason,reconciliation_batch_id,status,user_comments ) values(");
lock (ConnectionFactory.connectionString) { this.reconciliation_transactions_id = ConnectionFactory.GetNextId();
qry.Append(this.reconciliation_transactions_id);
} qry.Append(",");
qry.Append(reconciliation_switch_data_idDbString+",");
qry.Append(reconciliation_host_data_idDbString+",");
qry.Append(ej_parsed_transactions_idDbString+",");
qry.Append(parsed_transactions_idDbString+",");
qry.Append(comparison_typeDbString+",");
qry.Append(is_reconciledDbString+",");
qry.Append(is_reconciled_manuallyDbString+",");
qry.Append(user_idDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(updated_atDbString+",");
qry.Append(reasonDbString+",");
qry.Append(reconciliation_batch_idDbString+",");
qry.Append(statusDbString+",");
qry.Append(user_commentsDbString);
qry.Append(");");

}
else
{
if (!(reconciliation_transactions_idChanged || reconciliation_switch_data_idChanged || reconciliation_host_data_idChanged || ej_parsed_transactions_idChanged || parsed_transactions_idChanged || comparison_typeChanged || is_reconciledChanged || is_reconciled_manuallyChanged || user_idChanged || generated_atChanged || updated_atChanged || reasonChanged || reconciliation_batch_idChanged || statusChanged || user_commentsChanged ))
return;
qry.Append("UPDATE Reconciliation_transactions set "); if ( reconciliation_switch_data_idChanged )
{
qry.Append("reconciliation_switch_data_id ="+reconciliation_switch_data_idDbString);
qry.Append(",");
}

if ( reconciliation_host_data_idChanged )
{
qry.Append("reconciliation_host_data_id ="+reconciliation_host_data_idDbString);
qry.Append(",");
}

if ( ej_parsed_transactions_idChanged )
{
qry.Append("ej_parsed_transactions_id ="+ej_parsed_transactions_idDbString);
qry.Append(",");
}

if ( parsed_transactions_idChanged )
{
qry.Append("parsed_transactions_id ="+parsed_transactions_idDbString);
qry.Append(",");
}

if ( comparison_typeChanged )
{
qry.Append("comparison_type ="+comparison_typeDbString);
qry.Append(",");
}

if ( is_reconciledChanged )
{
qry.Append("is_reconciled ="+is_reconciledDbString);
qry.Append(",");
}

if ( is_reconciled_manuallyChanged )
{
qry.Append("is_reconciled_manually ="+is_reconciled_manuallyDbString);
qry.Append(",");
}

if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( updated_atChanged )
{
qry.Append("updated_at ="+updated_atDbString);
qry.Append(",");
}

if ( reasonChanged )
{
qry.Append("reason ="+reasonDbString);
qry.Append(",");
}

if ( reconciliation_batch_idChanged )
{
qry.Append("reconciliation_batch_id ="+reconciliation_batch_idDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( user_commentsChanged )
{
qry.Append("user_comments ="+user_commentsDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("reconciliation_transactions_id = "+reconciliation_transactions_idDbString);
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
cmd.CommandText = "DELETE Reconciliation_transactions where reconciliation_transactions_id = "+ reconciliation_transactions_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReconciliationTransactionss(string where)
{
ConnectionFactory.ExecuteQuery("delete Reconciliation_transactions where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
reconciliation_transactions_id= 1,
reconciliation_switch_data_id= 2,
reconciliation_host_data_id= 4,
ej_parsed_transactions_id= 8,
parsed_transactions_id= 16,
comparison_type= 32,
is_reconciled= 64,
is_reconciled_manually= 128,
user_id= 256,
generated_at= 512,
updated_at= 1024,
reason= 2048,
reconciliation_batch_id= 4096,
status= 8192,
user_comments= 16384
}
#endregion
public void BulkSave(List<ReconciliationTransactions> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Reconciliation_transactions";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReconciliationTransactions.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReconciliationTransactions> transList,ref DataTable dt)
{
foreach (ReconciliationTransactions tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["reconciliation_transactions_id"] =ConnectionFactory.GetNextId();
Row["reconciliation_switch_data_id"] = tran.ReconciliationSwitchDataId;
Row["reconciliation_host_data_id"] = tran.ReconciliationHostDataId;
Row["ej_parsed_transactions_id"] = tran.EjParsedTransactionsId;
Row["parsed_transactions_id"] = tran.ParsedTransactionsId;
Row["comparison_type"] = tran.ComparisonType;
Row["is_reconciled"] = tran.IsReconciled;
Row["is_reconciled_manually"] = tran.IsReconciledManually;
Row["user_id"] = tran.UserId;
Row["generated_at"] = tran.GeneratedAt;
Row["updated_at"] = tran.UpdatedAt;
Row["reason"] = tran.Reason;
Row["reconciliation_batch_id"] = tran.ReconciliationBatchId;
Row["status"] = tran.Status;
Row["user_comments"] = tran.UserComments;
dt.Rows.Add(Row);
} }
}
}
