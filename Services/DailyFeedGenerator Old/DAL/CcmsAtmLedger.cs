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
public class CcmsAtmLedger
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsAtmLedger() { }
public CcmsAtmLedger( int id,string type,int task_id,DateTime processing_datetime ) 
{
this.type = type;
this.typeChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
}
public CcmsAtmLedger( DateTime? transaction_date,string description,string transaction_type,decimal? balance,int? atm_id,int? atm_log_id,string order_number,string type,string mode,bool? is_deleted,int task_id,DateTime processing_datetime )
{
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.description = description;
this.descriptionChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.balance = balance;
this.balanceChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.atm_log_id = atm_log_id;
this.atm_log_idChanged = true;
this.order_number = order_number;
this.order_numberChanged = true;
this.type = type;
this.typeChanged = true;
this.mode = mode;
this.modeChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
}
private CcmsAtmLedger( int id,DateTime? transaction_date,string description,string transaction_type,decimal? balance,int? atm_id,int? atm_log_id,string order_number,string type,string mode,bool? is_deleted,int task_id,DateTime processing_datetime )
{
this.id = id;
this.idChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.description = description;
this.descriptionChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.balance = balance;
this.balanceChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.atm_log_id = atm_log_id;
this.atm_log_idChanged = true;
this.order_number = order_number;
this.order_numberChanged = true;
this.type = type;
this.typeChanged = true;
this.mode = mode;
this.modeChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
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
private DateTime? transaction_date;
public DateTime? TransactionDate
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
if (this.transaction_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",transaction_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
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
#region AtmLogId
private bool atm_log_idChanged = false;
private int? atm_log_id;
public int? AtmLogId
{
get { return atm_log_id; }
set { 
atm_log_id = value;
atm_log_idChanged = true;
}
}
private string atm_log_idDbString
{
get
{
if (this.atm_log_id.HasValue)
return atm_log_id.ToString();
else
return "null";
}
}
#endregion
#region OrderNumber
private bool order_numberChanged = false;
private string order_number;
public string OrderNumber
{
get { return order_number; }
set { 
order_number = value;
order_numberChanged = true;
}
}
private string order_numberDbString
{
get
{
if (this.order_number!=null)
return string.Format("'{0}'",order_number); else
return "null";
}
}
#endregion
#region Type
private bool typeChanged = false;
private string type;
public string Type
{
get { return type; }
set { 
type = value;
typeChanged = true;
}
}
private string typeDbString
{
get
{
if (this.type!=null)
return string.Format("'{0}'",type); else
return "null";
}
}
#endregion
#region Mode
private bool modeChanged = false;
private string mode;
public string Mode
{
get { return mode; }
set { 
mode = value;
modeChanged = true;
}
}
private string modeDbString
{
get
{
if (this.mode!=null)
return string.Format("'{0}'",mode); else
return "null";
}
}
#endregion
#region IsDeleted
private bool is_deletedChanged = false;
private bool? is_deleted;
public bool? IsDeleted
{
get { return is_deleted; }
set { 
is_deleted = value;
is_deletedChanged = true;
}
}
private string is_deletedDbString
{
get
{
if (this.is_deleted.HasValue)
return is_deleted.Value?"1":"0";
else
return "null";
}
}
#endregion
#region TaskId
private bool task_idChanged = false;
private int task_id;
public int TaskId
{
get { return task_id; }
set { 
task_id = value;
task_idChanged = true;
}
}
private string task_idDbString
{
get
{
return task_id.ToString();
}
}
#endregion
#region ProcessingDatetime
private bool processing_datetimeChanged = false;
private DateTime processing_datetime;
public DateTime ProcessingDatetime
{
get { return processing_datetime; }
set { 
processing_datetime = value;
processing_datetimeChanged = true;
}
}
private string processing_datetimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",processing_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region CcmsAtmLedgerReader
public class CcmsAtmLedgerReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsAtmLedger currentCcmsAtmLedger;
Columns columns;
bool partialRead = false;
private CcmsAtmLedgerReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsAtmLedgerReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsAtmLedgerReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsAtmLedger; }

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
currentCcmsAtmLedger = new CcmsAtmLedger();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsAtmLedger.id =(int) reader["id"]; 
if ((columns & Columns.transaction_date) == Columns.transaction_date && reader["transaction_date"]!=DBNull.Value)
currentCcmsAtmLedger.transaction_date =(DateTime?) reader["transaction_date"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsAtmLedger.description =(string) reader["description"]; 
if ((columns & Columns.transaction_type) == Columns.transaction_type && reader["transaction_type"]!=DBNull.Value)
currentCcmsAtmLedger.transaction_type =(string) reader["transaction_type"]; 
if ((columns & Columns.balance) == Columns.balance && reader["balance"]!=DBNull.Value)
currentCcmsAtmLedger.balance =(decimal?) reader["balance"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCcmsAtmLedger.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.atm_log_id) == Columns.atm_log_id && reader["atm_log_id"]!=DBNull.Value)
currentCcmsAtmLedger.atm_log_id =(int?) reader["atm_log_id"]; 
if ((columns & Columns.order_number) == Columns.order_number && reader["order_number"]!=DBNull.Value)
currentCcmsAtmLedger.order_number =(string) reader["order_number"]; 
if ((columns & Columns.type) == Columns.type && reader["type"]!=DBNull.Value)
currentCcmsAtmLedger.type =(string) reader["type"]; 
if ((columns & Columns.mode) == Columns.mode && reader["mode"]!=DBNull.Value)
currentCcmsAtmLedger.mode =(string) reader["mode"]; 
if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
currentCcmsAtmLedger.is_deleted =(bool?) reader["is_deleted"]; 
if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
currentCcmsAtmLedger.task_id =(int) reader["task_id"]; 
if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
currentCcmsAtmLedger.processing_datetime =(DateTime) reader["processing_datetime"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsAtmLedger.id = (int) reader["id"]; 
if (reader["transaction_date"] != DBNull.Value)
currentCcmsAtmLedger.transaction_date = (DateTime?) reader["transaction_date"]; 
if (reader["description"] != DBNull.Value)
currentCcmsAtmLedger.description = (string) reader["description"]; 
if (reader["transaction_type"] != DBNull.Value)
currentCcmsAtmLedger.transaction_type = (string) reader["transaction_type"]; 
if (reader["balance"] != DBNull.Value)
currentCcmsAtmLedger.balance = (decimal?) reader["balance"]; 
if (reader["atm_id"] != DBNull.Value)
currentCcmsAtmLedger.atm_id = (int?) reader["atm_id"]; 
if (reader["atm_log_id"] != DBNull.Value)
currentCcmsAtmLedger.atm_log_id = (int?) reader["atm_log_id"]; 
if (reader["order_number"] != DBNull.Value)
currentCcmsAtmLedger.order_number = (string) reader["order_number"]; 
if (reader["type"] != DBNull.Value)
currentCcmsAtmLedger.type = (string) reader["type"]; 
if (reader["mode"] != DBNull.Value)
currentCcmsAtmLedger.mode = (string) reader["mode"]; 
if (reader["is_deleted"] != DBNull.Value)
currentCcmsAtmLedger.is_deleted = (bool?) reader["is_deleted"]; 
if (reader["task_id"] != DBNull.Value)
currentCcmsAtmLedger.task_id = (int) reader["task_id"]; 
if (reader["processing_datetime"] != DBNull.Value)
currentCcmsAtmLedger.processing_datetime = (DateTime) reader["processing_datetime"]; 
} 

currentCcmsAtmLedger.isNewEntity = false;
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

public CcmsAtmLedger CurrentCcmsAtmLedger
{
get{ return currentCcmsAtmLedger; }
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


#region CcmsAtmLedger functions

public static CcmsAtmLedgerReader ExecuteReader(string where, IDbConnection conn, Columns columns)
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
if (Columns.balance == (Columns.balance & columns))
qry.Append("balance,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.atm_log_id == (Columns.atm_log_id & columns))
qry.Append("atm_log_id,");
if (Columns.order_number == (Columns.order_number & columns))
qry.Append("order_number,");
if (Columns.type == (Columns.type & columns))
qry.Append("type,");
if (Columns.mode == (Columns.mode & columns))
qry.Append("mode,");
if (Columns.is_deleted == (Columns.is_deleted & columns))
qry.Append("is_deleted,");
if (Columns.task_id == (Columns.task_id & columns))
qry.Append("task_id,");
if (Columns.processing_datetime == (Columns.processing_datetime & columns))
qry.Append("processing_datetime,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_atm_ledger ");

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
return new CcmsAtmLedgerReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsAtmLedgerReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsAtmLedgerReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,transaction_date,description,transaction_type,balance,atm_id,atm_log_id,order_number,type,mode,is_deleted,task_id,processing_datetime from Ccms_atm_ledger ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsAtmLedgerReader(cmd.ExecuteReader(), conn);
}

static public CcmsAtmLedgerReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsAtmLedger LoadCcmsAtmLedger(string where)
{
CcmsAtmLedgerReader reader = CcmsAtmLedger.ExecuteReader(where);
CcmsAtmLedger _ccmsatmledger = null;
if (reader.Read())
_ccmsatmledger = reader.CurrentCcmsAtmLedger;
reader.Close();
return _ccmsatmledger;
}

public static CcmsAtmLedger LoadCcmsAtmLedger(string where, IDbConnection conn)
{
CcmsAtmLedgerReader reader = CcmsAtmLedger.ExecuteReader(where, conn);
CcmsAtmLedger _ccmsatmledger = null;
if (reader.Read())
_ccmsatmledger = reader.CurrentCcmsAtmLedger;
reader.Close(false);
return _ccmsatmledger;
}

public static CcmsAtmLedger LoadCcmsAtmLedgerByPk( int id )
{
return LoadCcmsAtmLedger( " id="+id );
}

public static CcmsAtmLedger LoadCcmsAtmLedgerByPk( int id , IDbConnection conn)
{
return LoadCcmsAtmLedger(" id="+id , conn);
}

public void Save()
{
if (idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || balanceChanged || atm_idChanged || atm_log_idChanged || order_numberChanged || typeChanged || modeChanged || is_deletedChanged || task_idChanged || processing_datetimeChanged )
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
if (idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || balanceChanged || atm_idChanged || atm_log_idChanged || order_numberChanged || typeChanged || modeChanged || is_deletedChanged || task_idChanged || processing_datetimeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_atm_ledger( transaction_date,description,transaction_type,balance,atm_id,atm_log_id,order_number,type,mode,is_deleted,task_id,processing_datetime ) values(");

qry.Append(transaction_dateDbString+",");
qry.Append(descriptionDbString+",");
qry.Append(transaction_typeDbString+",");
qry.Append(balanceDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(atm_log_idDbString+",");
qry.Append(order_numberDbString+",");
qry.Append(typeDbString+",");
qry.Append(modeDbString+",");
qry.Append(is_deletedDbString+",");
qry.Append(task_idDbString+",");
qry.Append(processing_datetimeDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || transaction_dateChanged || descriptionChanged || transaction_typeChanged || balanceChanged || atm_idChanged || atm_log_idChanged || order_numberChanged || typeChanged || modeChanged || is_deletedChanged || task_idChanged || processing_datetimeChanged ))
return;
qry.Append("UPDATE Ccms_atm_ledger set "); if ( transaction_dateChanged )
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

if ( balanceChanged )
{
qry.Append("balance ="+balanceDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( atm_log_idChanged )
{
qry.Append("atm_log_id ="+atm_log_idDbString);
qry.Append(",");
}

if ( order_numberChanged )
{
qry.Append("order_number ="+order_numberDbString);
qry.Append(",");
}

if ( typeChanged )
{
qry.Append("type ="+typeDbString);
qry.Append(",");
}

if ( modeChanged )
{
qry.Append("mode ="+modeDbString);
qry.Append(",");
}

if ( is_deletedChanged )
{
qry.Append("is_deleted ="+is_deletedDbString);
qry.Append(",");
}

if ( task_idChanged )
{
qry.Append("task_id ="+task_idDbString);
qry.Append(",");
}

if ( processing_datetimeChanged )
{
qry.Append("processing_datetime ="+processing_datetimeDbString);
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
cmd.CommandText = "DELETE Ccms_atm_ledger where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsAtmLedgers(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_atm_ledger where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
transaction_date= 2,
description= 4,
transaction_type= 8,
balance= 16,
atm_id= 32,
atm_log_id= 64,
order_number= 128,
type= 256,
mode= 512,
is_deleted= 1024,
task_id= 2048,
processing_datetime= 4096
}
#endregion
public void BulkSave(List<CcmsAtmLedger> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_atm_ledger";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsAtmLedger.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsAtmLedger> transList,ref DataTable dt)
{
foreach (CcmsAtmLedger tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["transaction_date"] = tran.TransactionDate;
Row["description"] = tran.Description;
Row["transaction_type"] = tran.TransactionType;
Row["balance"] = tran.Balance;
Row["atm_id"] = tran.AtmId;
Row["atm_log_id"] = tran.AtmLogId;
Row["order_number"] = tran.OrderNumber;
Row["type"] = tran.Type;
Row["mode"] = tran.Mode;
Row["is_deleted"] = tran.IsDeleted;
Row["task_id"] = tran.TaskId;
Row["processing_datetime"] = tran.ProcessingDatetime;
dt.Rows.Add(Row);
} }
}
}
