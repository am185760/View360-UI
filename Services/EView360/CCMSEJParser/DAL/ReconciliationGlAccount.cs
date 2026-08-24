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
public class ReconciliationGlAccount
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReconciliationGlAccount() { }
public ReconciliationGlAccount( int reconciliation_gl_account_id,string reconciliation_gl_account_name,DateTime creation_time,int created_by ) 
{
this.reconciliation_gl_account_name = reconciliation_gl_account_name;
this.reconciliation_gl_account_nameChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
}
public ReconciliationGlAccount( string reconciliation_gl_account_name,decimal? opening_balance,int? modified_by,DateTime? modification_datetime,DateTime creation_time,int created_by,string user_comments )
{
this.reconciliation_gl_account_name = reconciliation_gl_account_name;
this.reconciliation_gl_account_nameChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modification_datetime = modification_datetime;
this.modification_datetimeChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.user_comments = user_comments;
this.user_commentsChanged = true;
}
private ReconciliationGlAccount( int reconciliation_gl_account_id,string reconciliation_gl_account_name,decimal? opening_balance,int? modified_by,DateTime? modification_datetime,DateTime creation_time,int created_by,string user_comments )
{
this.reconciliation_gl_account_id = reconciliation_gl_account_id;
this.reconciliation_gl_account_idChanged = true;
this.reconciliation_gl_account_name = reconciliation_gl_account_name;
this.reconciliation_gl_account_nameChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modification_datetime = modification_datetime;
this.modification_datetimeChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.user_comments = user_comments;
this.user_commentsChanged = true;
}

#region members and properties for columns

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
#region ReconciliationGlAccountName
private bool reconciliation_gl_account_nameChanged = false;
private string reconciliation_gl_account_name;
public string ReconciliationGlAccountName
{
get { return reconciliation_gl_account_name; }
set { 
reconciliation_gl_account_name = value;
reconciliation_gl_account_nameChanged = true;
}
}
private string reconciliation_gl_account_nameDbString
{
get
{
if (this.reconciliation_gl_account_name!=null)
return string.Format("'{0}'",reconciliation_gl_account_name); else
return "null";
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
#region ModifiedBy
private bool modified_byChanged = false;
private int? modified_by;
public int? ModifiedBy
{
get { return modified_by; }
set { 
modified_by = value;
modified_byChanged = true;
}
}
private string modified_byDbString
{
get
{
if (this.modified_by.HasValue)
return modified_by.ToString();
else
return "null";
}
}
#endregion
#region ModificationDatetime
private bool modification_datetimeChanged = false;
private DateTime? modification_datetime;
public DateTime? ModificationDatetime
{
get { return modification_datetime; }
set { 
modification_datetime = value;
modification_datetimeChanged = true;
}
}
private string modification_datetimeDbString
{
get
{
if (this.modification_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modification_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region CreationTime
private bool creation_timeChanged = false;
private DateTime creation_time;
public DateTime CreationTime
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
return string.Format("Convert(datetime,'{0}',121)",creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region CreatedBy
private bool created_byChanged = false;
private int created_by;
public int CreatedBy
{
get { return created_by; }
set { 
created_by = value;
created_byChanged = true;
}
}
private string created_byDbString
{
get
{
return created_by.ToString();
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

#region ReconciliationGlAccountReader
public class ReconciliationGlAccountReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReconciliationGlAccount currentReconciliationGlAccount;
Columns columns;
bool partialRead = false;
private ReconciliationGlAccountReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReconciliationGlAccountReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReconciliationGlAccountReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReconciliationGlAccount; }

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
currentReconciliationGlAccount = new ReconciliationGlAccount();
if (partialRead)
{ if ((columns & Columns.reconciliation_gl_account_id) == Columns.reconciliation_gl_account_id && reader["reconciliation_gl_account_id"]!=DBNull.Value)
currentReconciliationGlAccount.reconciliation_gl_account_id =(int) reader["reconciliation_gl_account_id"]; 
if ((columns & Columns.reconciliation_gl_account_name) == Columns.reconciliation_gl_account_name && reader["reconciliation_gl_account_name"]!=DBNull.Value)
currentReconciliationGlAccount.reconciliation_gl_account_name =(string) reader["reconciliation_gl_account_name"]; 
if ((columns & Columns.opening_balance) == Columns.opening_balance && reader["opening_balance"]!=DBNull.Value)
currentReconciliationGlAccount.opening_balance =(decimal?) reader["opening_balance"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentReconciliationGlAccount.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.modification_datetime) == Columns.modification_datetime && reader["modification_datetime"]!=DBNull.Value)
currentReconciliationGlAccount.modification_datetime =(DateTime?) reader["modification_datetime"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentReconciliationGlAccount.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentReconciliationGlAccount.created_by =(int) reader["created_by"]; 
if ((columns & Columns.user_comments) == Columns.user_comments && reader["user_comments"]!=DBNull.Value)
currentReconciliationGlAccount.user_comments =(string) reader["user_comments"]; 

} else
{
if (reader["reconciliation_gl_account_id"] != DBNull.Value)
currentReconciliationGlAccount.reconciliation_gl_account_id = (int) reader["reconciliation_gl_account_id"]; 
if (reader["reconciliation_gl_account_name"] != DBNull.Value)
currentReconciliationGlAccount.reconciliation_gl_account_name = (string) reader["reconciliation_gl_account_name"]; 
if (reader["opening_balance"] != DBNull.Value)
currentReconciliationGlAccount.opening_balance = (decimal?) reader["opening_balance"]; 
if (reader["modified_by"] != DBNull.Value)
currentReconciliationGlAccount.modified_by = (int?) reader["modified_by"]; 
if (reader["modification_datetime"] != DBNull.Value)
currentReconciliationGlAccount.modification_datetime = (DateTime?) reader["modification_datetime"]; 
if (reader["creation_time"] != DBNull.Value)
currentReconciliationGlAccount.creation_time = (DateTime) reader["creation_time"]; 
if (reader["created_by"] != DBNull.Value)
currentReconciliationGlAccount.created_by = (int) reader["created_by"]; 
if (reader["user_comments"] != DBNull.Value)
currentReconciliationGlAccount.user_comments = (string) reader["user_comments"]; 
} 

currentReconciliationGlAccount.isNewEntity = false;
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

public ReconciliationGlAccount CurrentReconciliationGlAccount
{
get{ return currentReconciliationGlAccount; }
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


#region ReconciliationGlAccount functions

public static ReconciliationGlAccountReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.reconciliation_gl_account_id == (Columns.reconciliation_gl_account_id & columns))
qry.Append("reconciliation_gl_account_id,");
if (Columns.reconciliation_gl_account_name == (Columns.reconciliation_gl_account_name & columns))
qry.Append("reconciliation_gl_account_name,");
if (Columns.opening_balance == (Columns.opening_balance & columns))
qry.Append("opening_balance,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.modification_datetime == (Columns.modification_datetime & columns))
qry.Append("modification_datetime,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.user_comments == (Columns.user_comments & columns))
qry.Append("user_comments,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Reconciliation_gl_account ");

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
return new ReconciliationGlAccountReader(cmd.ExecuteReader(), conn, columns);
}

static public ReconciliationGlAccountReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReconciliationGlAccountReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select reconciliation_gl_account_id,reconciliation_gl_account_name,opening_balance,modified_by,modification_datetime,creation_time,created_by,user_comments from Reconciliation_gl_account ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReconciliationGlAccountReader(cmd.ExecuteReader(), conn);
}

static public ReconciliationGlAccountReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReconciliationGlAccount LoadReconciliationGlAccount(string where)
{
ReconciliationGlAccountReader reader = ReconciliationGlAccount.ExecuteReader(where);
ReconciliationGlAccount _reconciliationglaccount = null;
if (reader.Read())
_reconciliationglaccount = reader.CurrentReconciliationGlAccount;
reader.Close();
return _reconciliationglaccount;
}

public static ReconciliationGlAccount LoadReconciliationGlAccount(string where, IDbConnection conn)
{
ReconciliationGlAccountReader reader = ReconciliationGlAccount.ExecuteReader(where, conn);
ReconciliationGlAccount _reconciliationglaccount = null;
if (reader.Read())
_reconciliationglaccount = reader.CurrentReconciliationGlAccount;
reader.Close(false);
return _reconciliationglaccount;
}

public static ReconciliationGlAccount LoadReconciliationGlAccountByPk( int reconciliation_gl_account_id )
{
return LoadReconciliationGlAccount( " reconciliation_gl_account_id="+reconciliation_gl_account_id );
}

public static ReconciliationGlAccount LoadReconciliationGlAccountByPk( int reconciliation_gl_account_id , IDbConnection conn)
{
return LoadReconciliationGlAccount(" reconciliation_gl_account_id="+reconciliation_gl_account_id , conn);
}

public void Save()
{
if (reconciliation_gl_account_idChanged || reconciliation_gl_account_nameChanged || opening_balanceChanged || modified_byChanged || modification_datetimeChanged || creation_timeChanged || created_byChanged || user_commentsChanged )
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
if (reconciliation_gl_account_idChanged || reconciliation_gl_account_nameChanged || opening_balanceChanged || modified_byChanged || modification_datetimeChanged || creation_timeChanged || created_byChanged || user_commentsChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Reconciliation_gl_account( reconciliation_gl_account_id,reconciliation_gl_account_name,opening_balance,modified_by,modification_datetime,creation_time,created_by,user_comments ) values(");
lock (ConnectionFactory.connectionString) { this.reconciliation_gl_account_id = ConnectionFactory.GetNextId();
qry.Append(this.reconciliation_gl_account_id);
} qry.Append(",");
qry.Append(reconciliation_gl_account_nameDbString+",");
qry.Append(opening_balanceDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(modification_datetimeDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(user_commentsDbString);
qry.Append(");");

}
else
{
if (!(reconciliation_gl_account_idChanged || reconciliation_gl_account_nameChanged || opening_balanceChanged || modified_byChanged || modification_datetimeChanged || creation_timeChanged || created_byChanged || user_commentsChanged ))
return;
qry.Append("UPDATE Reconciliation_gl_account set "); if ( reconciliation_gl_account_nameChanged )
{
qry.Append("reconciliation_gl_account_name ="+reconciliation_gl_account_nameDbString);
qry.Append(",");
}

if ( opening_balanceChanged )
{
qry.Append("opening_balance ="+opening_balanceDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( modification_datetimeChanged )
{
qry.Append("modification_datetime ="+modification_datetimeDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( user_commentsChanged )
{
qry.Append("user_comments ="+user_commentsDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("reconciliation_gl_account_id = "+reconciliation_gl_account_idDbString);
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
cmd.CommandText = "DELETE Reconciliation_gl_account where reconciliation_gl_account_id = "+ reconciliation_gl_account_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReconciliationGlAccounts(string where)
{
ConnectionFactory.ExecuteQuery("delete Reconciliation_gl_account where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
reconciliation_gl_account_id= 1,
reconciliation_gl_account_name= 2,
opening_balance= 4,
modified_by= 8,
modification_datetime= 16,
creation_time= 32,
created_by= 64,
user_comments= 128
}
#endregion
public void BulkSave(List<ReconciliationGlAccount> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Reconciliation_gl_account";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReconciliationGlAccount.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReconciliationGlAccount> transList,ref DataTable dt)
{
foreach (ReconciliationGlAccount tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["reconciliation_gl_account_id"] =ConnectionFactory.GetNextId();
Row["reconciliation_gl_account_name"] = tran.ReconciliationGlAccountName;
Row["opening_balance"] = tran.OpeningBalance;
Row["modified_by"] = tran.ModifiedBy;
Row["modification_datetime"] = tran.ModificationDatetime;
Row["creation_time"] = tran.CreationTime;
Row["created_by"] = tran.CreatedBy;
Row["user_comments"] = tran.UserComments;
dt.Rows.Add(Row);
} }
}
}
