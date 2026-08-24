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
public class TransactionRule
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public TransactionRule() { }
public TransactionRule( int transaction_rule_id,string transaction_rule_name,DateTime creation_time,int created_by,bool is_active ) 
{
this.transaction_rule_name = transaction_rule_name;
this.transaction_rule_nameChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}
public TransactionRule( string transaction_rule_name,string transaction_rule_friendly_name,string transaction_rule_filtering_criteria,DateTime creation_time,int created_by,DateTime? modification_time,int? modified_by,string color,bool is_active )
{
this.transaction_rule_name = transaction_rule_name;
this.transaction_rule_nameChanged = true;
this.transaction_rule_friendly_name = transaction_rule_friendly_name;
this.transaction_rule_friendly_nameChanged = true;
this.transaction_rule_filtering_criteria = transaction_rule_filtering_criteria;
this.transaction_rule_filtering_criteriaChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.color = color;
this.colorChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}
private TransactionRule( int transaction_rule_id,string transaction_rule_name,string transaction_rule_friendly_name,string transaction_rule_filtering_criteria,DateTime creation_time,int created_by,DateTime? modification_time,int? modified_by,string color,bool is_active )
{
this.transaction_rule_id = transaction_rule_id;
this.transaction_rule_idChanged = true;
this.transaction_rule_name = transaction_rule_name;
this.transaction_rule_nameChanged = true;
this.transaction_rule_friendly_name = transaction_rule_friendly_name;
this.transaction_rule_friendly_nameChanged = true;
this.transaction_rule_filtering_criteria = transaction_rule_filtering_criteria;
this.transaction_rule_filtering_criteriaChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.color = color;
this.colorChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}

#region members and properties for columns

#region TransactionRuleId
private bool transaction_rule_idChanged = false;
private int transaction_rule_id;
public int TransactionRuleId
{
get { return transaction_rule_id; }
set { 
transaction_rule_id = value;
transaction_rule_idChanged = true;
}
}
private string transaction_rule_idDbString
{
get
{
return transaction_rule_id.ToString();
}
}
#endregion
#region TransactionRuleName
private bool transaction_rule_nameChanged = false;
private string transaction_rule_name;
public string TransactionRuleName
{
get { return transaction_rule_name; }
set { 
transaction_rule_name = value;
transaction_rule_nameChanged = true;
}
}
private string transaction_rule_nameDbString
{
get
{
if (this.transaction_rule_name!=null)
return string.Format("'{0}'",transaction_rule_name); else
return "null";
}
}
#endregion
#region TransactionRuleFriendlyName
private bool transaction_rule_friendly_nameChanged = false;
private string transaction_rule_friendly_name;
public string TransactionRuleFriendlyName
{
get { return transaction_rule_friendly_name; }
set { 
transaction_rule_friendly_name = value;
transaction_rule_friendly_nameChanged = true;
}
}
private string transaction_rule_friendly_nameDbString
{
get
{
if (this.transaction_rule_friendly_name!=null)
return string.Format("'{0}'",transaction_rule_friendly_name); else
return "null";
}
}
#endregion
#region TransactionRuleFilteringCriteria
private bool transaction_rule_filtering_criteriaChanged = false;
private string transaction_rule_filtering_criteria;
public string TransactionRuleFilteringCriteria
{
get { return transaction_rule_filtering_criteria; }
set { 
transaction_rule_filtering_criteria = value;
transaction_rule_filtering_criteriaChanged = true;
}
}
private string transaction_rule_filtering_criteriaDbString
{
get
{
if (this.transaction_rule_filtering_criteria!=null)
return string.Format("'{0}'",transaction_rule_filtering_criteria); else
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
#region ModificationTime
private bool modification_timeChanged = false;
private DateTime? modification_time;
public DateTime? ModificationTime
{
get { return modification_time; }
set { 
modification_time = value;
modification_timeChanged = true;
}
}
private string modification_timeDbString
{
get
{
if (this.modification_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region Color
private bool colorChanged = false;
private string color;
public string Color
{
get { return color; }
set { 
color = value;
colorChanged = true;
}
}
private string colorDbString
{
get
{
if (this.color!=null)
return string.Format("'{0}'",color); else
return "null";
}
}
#endregion
#region IsActive
private bool is_activeChanged = false;
private bool is_active;
public bool IsActive
{
get { return is_active; }
set { 
is_active = value;
is_activeChanged = true;
}
}
private string is_activeDbString
{
get
{
return is_active?"1":"0";
}
}
#endregion
#endregion

#region TransactionRuleReader
public class TransactionRuleReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
TransactionRule currentTransactionRule;
Columns columns;
bool partialRead = false;
private TransactionRuleReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public TransactionRuleReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public TransactionRuleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentTransactionRule; }

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
currentTransactionRule = new TransactionRule();
if (partialRead)
{ if ((columns & Columns.transaction_rule_id) == Columns.transaction_rule_id && reader["transaction_rule_id"]!=DBNull.Value)
currentTransactionRule.transaction_rule_id =(int) reader["transaction_rule_id"]; 
if ((columns & Columns.transaction_rule_name) == Columns.transaction_rule_name && reader["transaction_rule_name"]!=DBNull.Value)
currentTransactionRule.transaction_rule_name =(string) reader["transaction_rule_name"]; 
if ((columns & Columns.transaction_rule_friendly_name) == Columns.transaction_rule_friendly_name && reader["transaction_rule_friendly_name"]!=DBNull.Value)
currentTransactionRule.transaction_rule_friendly_name =(string) reader["transaction_rule_friendly_name"]; 
if ((columns & Columns.transaction_rule_filtering_criteria) == Columns.transaction_rule_filtering_criteria && reader["transaction_rule_filtering_criteria"]!=DBNull.Value)
currentTransactionRule.transaction_rule_filtering_criteria =(string) reader["transaction_rule_filtering_criteria"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentTransactionRule.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentTransactionRule.created_by =(int) reader["created_by"]; 
if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
currentTransactionRule.modification_time =(DateTime?) reader["modification_time"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentTransactionRule.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.color) == Columns.color && reader["color"]!=DBNull.Value)
currentTransactionRule.color =(string) reader["color"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentTransactionRule.is_active =(bool) reader["is_active"]; 

} else
{
if (reader["transaction_rule_id"] != DBNull.Value)
currentTransactionRule.transaction_rule_id = (int) reader["transaction_rule_id"]; 
if (reader["transaction_rule_name"] != DBNull.Value)
currentTransactionRule.transaction_rule_name = (string) reader["transaction_rule_name"]; 
if (reader["transaction_rule_friendly_name"] != DBNull.Value)
currentTransactionRule.transaction_rule_friendly_name = (string) reader["transaction_rule_friendly_name"]; 
if (reader["transaction_rule_filtering_criteria"] != DBNull.Value)
currentTransactionRule.transaction_rule_filtering_criteria = (string) reader["transaction_rule_filtering_criteria"]; 
if (reader["creation_time"] != DBNull.Value)
currentTransactionRule.creation_time = (DateTime) reader["creation_time"]; 
if (reader["created_by"] != DBNull.Value)
currentTransactionRule.created_by = (int) reader["created_by"]; 
if (reader["modification_time"] != DBNull.Value)
currentTransactionRule.modification_time = (DateTime?) reader["modification_time"]; 
if (reader["modified_by"] != DBNull.Value)
currentTransactionRule.modified_by = (int?) reader["modified_by"]; 
if (reader["color"] != DBNull.Value)
currentTransactionRule.color = (string) reader["color"]; 
if (reader["is_active"] != DBNull.Value)
currentTransactionRule.is_active = (bool) reader["is_active"]; 
} 

currentTransactionRule.isNewEntity = false;
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

public TransactionRule CurrentTransactionRule
{
get{ return currentTransactionRule; }
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


#region TransactionRule functions

public static TransactionRuleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.transaction_rule_id == (Columns.transaction_rule_id & columns))
qry.Append("transaction_rule_id,");
if (Columns.transaction_rule_name == (Columns.transaction_rule_name & columns))
qry.Append("transaction_rule_name,");
if (Columns.transaction_rule_friendly_name == (Columns.transaction_rule_friendly_name & columns))
qry.Append("transaction_rule_friendly_name,");
if (Columns.transaction_rule_filtering_criteria == (Columns.transaction_rule_filtering_criteria & columns))
qry.Append("transaction_rule_filtering_criteria,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modification_time == (Columns.modification_time & columns))
qry.Append("modification_time,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.color == (Columns.color & columns))
qry.Append("color,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Transaction_rule ");

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
return new TransactionRuleReader(cmd.ExecuteReader(), conn, columns);
}

static public TransactionRuleReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static TransactionRuleReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select transaction_rule_id,transaction_rule_name,transaction_rule_friendly_name,transaction_rule_filtering_criteria,creation_time,created_by,modification_time,modified_by,color,is_active from Transaction_rule ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new TransactionRuleReader(cmd.ExecuteReader(), conn);
}

static public TransactionRuleReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static TransactionRule LoadTransactionRule(string where)
{
TransactionRuleReader reader = TransactionRule.ExecuteReader(where);
TransactionRule _transactionrule = null;
if (reader.Read())
_transactionrule = reader.CurrentTransactionRule;
reader.Close();
return _transactionrule;
}

public static TransactionRule LoadTransactionRule(string where, IDbConnection conn)
{
TransactionRuleReader reader = TransactionRule.ExecuteReader(where, conn);
TransactionRule _transactionrule = null;
if (reader.Read())
_transactionrule = reader.CurrentTransactionRule;
reader.Close(false);
return _transactionrule;
}

public static TransactionRule LoadTransactionRuleByPk( int transaction_rule_id )
{
return LoadTransactionRule( " transaction_rule_id="+transaction_rule_id );
}

public static TransactionRule LoadTransactionRuleByPk( int transaction_rule_id , IDbConnection conn)
{
return LoadTransactionRule(" transaction_rule_id="+transaction_rule_id , conn);
}

public void Save()
{
if (transaction_rule_idChanged || transaction_rule_nameChanged || transaction_rule_friendly_nameChanged || transaction_rule_filtering_criteriaChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged || colorChanged || is_activeChanged )
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
if (transaction_rule_idChanged || transaction_rule_nameChanged || transaction_rule_friendly_nameChanged || transaction_rule_filtering_criteriaChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged || colorChanged || is_activeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Transaction_rule( transaction_rule_id,transaction_rule_name,transaction_rule_friendly_name,transaction_rule_filtering_criteria,creation_time,created_by,modification_time,modified_by,color,is_active ) values(");
lock (ConnectionFactory.connectionString) { this.transaction_rule_id = ConnectionFactory.GetNextId();
qry.Append(this.transaction_rule_id);
} qry.Append(",");
qry.Append(transaction_rule_nameDbString+",");
qry.Append(transaction_rule_friendly_nameDbString+",");
qry.Append(transaction_rule_filtering_criteriaDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modification_timeDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(colorDbString+",");
qry.Append(is_activeDbString);
qry.Append(");");

}
else
{
if (!(transaction_rule_idChanged || transaction_rule_nameChanged || transaction_rule_friendly_nameChanged || transaction_rule_filtering_criteriaChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged || colorChanged || is_activeChanged ))
return;
qry.Append("UPDATE Transaction_rule set "); if ( transaction_rule_nameChanged )
{
qry.Append("transaction_rule_name ="+transaction_rule_nameDbString);
qry.Append(",");
}

if ( transaction_rule_friendly_nameChanged )
{
qry.Append("transaction_rule_friendly_name ="+transaction_rule_friendly_nameDbString);
qry.Append(",");
}

if ( transaction_rule_filtering_criteriaChanged )
{
qry.Append("transaction_rule_filtering_criteria ="+transaction_rule_filtering_criteriaDbString);
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

if ( modification_timeChanged )
{
qry.Append("modification_time ="+modification_timeDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( colorChanged )
{
qry.Append("color ="+colorDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("transaction_rule_id = "+transaction_rule_idDbString);
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
cmd.CommandText = "DELETE Transaction_rule where transaction_rule_id = "+ transaction_rule_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteTransactionRules(string where)
{
ConnectionFactory.ExecuteQuery("delete Transaction_rule where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
transaction_rule_id= 1,
transaction_rule_name= 2,
transaction_rule_friendly_name= 4,
transaction_rule_filtering_criteria= 8,
creation_time= 16,
created_by= 32,
modification_time= 64,
modified_by= 128,
color= 256,
is_active= 512
}
#endregion
public void BulkSave(List<TransactionRule> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Transaction_rule";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(TransactionRule.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <TransactionRule> transList,ref DataTable dt)
{
foreach (TransactionRule tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["transaction_rule_id"] =ConnectionFactory.GetNextId();
Row["transaction_rule_name"] = tran.TransactionRuleName;
Row["transaction_rule_friendly_name"] = tran.TransactionRuleFriendlyName;
Row["transaction_rule_filtering_criteria"] = tran.TransactionRuleFilteringCriteria;
Row["creation_time"] = tran.CreationTime;
Row["created_by"] = tran.CreatedBy;
Row["modification_time"] = tran.ModificationTime;
Row["modified_by"] = tran.ModifiedBy;
Row["color"] = tran.Color;
Row["is_active"] = tran.IsActive;
dt.Rows.Add(Row);
} }
}
}
