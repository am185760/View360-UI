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
public class ReplenishmentHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReplenishmentHistory() { }
public ReplenishmentHistory( int atm_id,int cash_added1,int cash_added2,int cash_added3,int cash_added4,int cash_added5,int cash_added6,int cash_added7,DateTime rep_datetime,string rep_status,int replenishment_id,int task_id,bool is_swap,int replenishment_history_id ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cash_added1 = cash_added1;
this.cash_added1Changed = true;
this.cash_added2 = cash_added2;
this.cash_added2Changed = true;
this.cash_added3 = cash_added3;
this.cash_added3Changed = true;
this.cash_added4 = cash_added4;
this.cash_added4Changed = true;
this.cash_added5 = cash_added5;
this.cash_added5Changed = true;
this.cash_added6 = cash_added6;
this.cash_added6Changed = true;
this.cash_added7 = cash_added7;
this.cash_added7Changed = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.rep_status = rep_status;
this.rep_statusChanged = true;
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.is_swap = is_swap;
this.is_swapChanged = true;
}
public ReplenishmentHistory( int atm_id,int cash_added1,int cash_added2,int cash_added3,int cash_added4,int cash_added5,int cash_added6,int cash_added7,DateTime rep_datetime,string rep_status,int replenishment_id,int task_id,int? cash_order_id,bool is_swap,DateTime? generated_at,bool? is_updated,int? modified_by,DateTime? modified_datetime,int? generated_by,string reason )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cash_added1 = cash_added1;
this.cash_added1Changed = true;
this.cash_added2 = cash_added2;
this.cash_added2Changed = true;
this.cash_added3 = cash_added3;
this.cash_added3Changed = true;
this.cash_added4 = cash_added4;
this.cash_added4Changed = true;
this.cash_added5 = cash_added5;
this.cash_added5Changed = true;
this.cash_added6 = cash_added6;
this.cash_added6Changed = true;
this.cash_added7 = cash_added7;
this.cash_added7Changed = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.rep_status = rep_status;
this.rep_statusChanged = true;
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.cash_order_id = cash_order_id;
this.cash_order_idChanged = true;
this.is_swap = is_swap;
this.is_swapChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.is_updated = is_updated;
this.is_updatedChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_datetime = modified_datetime;
this.modified_datetimeChanged = true;
this.generated_by = generated_by;
this.generated_byChanged = true;
this.reason = reason;
this.reasonChanged = true;
}
private ReplenishmentHistory( int atm_id,int cash_added1,int cash_added2,int cash_added3,int cash_added4,int cash_added5,int cash_added6,int cash_added7,DateTime rep_datetime,string rep_status,int replenishment_id,int task_id,int? cash_order_id,bool is_swap,DateTime? generated_at,bool? is_updated,int replenishment_history_id,int? modified_by,DateTime? modified_datetime,int? generated_by,string reason )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cash_added1 = cash_added1;
this.cash_added1Changed = true;
this.cash_added2 = cash_added2;
this.cash_added2Changed = true;
this.cash_added3 = cash_added3;
this.cash_added3Changed = true;
this.cash_added4 = cash_added4;
this.cash_added4Changed = true;
this.cash_added5 = cash_added5;
this.cash_added5Changed = true;
this.cash_added6 = cash_added6;
this.cash_added6Changed = true;
this.cash_added7 = cash_added7;
this.cash_added7Changed = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.rep_status = rep_status;
this.rep_statusChanged = true;
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.cash_order_id = cash_order_id;
this.cash_order_idChanged = true;
this.is_swap = is_swap;
this.is_swapChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.is_updated = is_updated;
this.is_updatedChanged = true;
this.replenishment_history_id = replenishment_history_id;
this.replenishment_history_idChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_datetime = modified_datetime;
this.modified_datetimeChanged = true;
this.generated_by = generated_by;
this.generated_byChanged = true;
this.reason = reason;
this.reasonChanged = true;
}

#region members and properties for columns

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
#region CashAdded1
private bool cash_added1Changed = false;
private int cash_added1;
public int CashAdded1
{
get { return cash_added1; }
set { 
cash_added1 = value;
cash_added1Changed = true;
}
}
private string cash_added1DbString
{
get
{
return cash_added1.ToString();
}
}
#endregion
#region CashAdded2
private bool cash_added2Changed = false;
private int cash_added2;
public int CashAdded2
{
get { return cash_added2; }
set { 
cash_added2 = value;
cash_added2Changed = true;
}
}
private string cash_added2DbString
{
get
{
return cash_added2.ToString();
}
}
#endregion
#region CashAdded3
private bool cash_added3Changed = false;
private int cash_added3;
public int CashAdded3
{
get { return cash_added3; }
set { 
cash_added3 = value;
cash_added3Changed = true;
}
}
private string cash_added3DbString
{
get
{
return cash_added3.ToString();
}
}
#endregion
#region CashAdded4
private bool cash_added4Changed = false;
private int cash_added4;
public int CashAdded4
{
get { return cash_added4; }
set { 
cash_added4 = value;
cash_added4Changed = true;
}
}
private string cash_added4DbString
{
get
{
return cash_added4.ToString();
}
}
#endregion
#region CashAdded5
private bool cash_added5Changed = false;
private int cash_added5;
public int CashAdded5
{
get { return cash_added5; }
set { 
cash_added5 = value;
cash_added5Changed = true;
}
}
private string cash_added5DbString
{
get
{
return cash_added5.ToString();
}
}
#endregion
#region CashAdded6
private bool cash_added6Changed = false;
private int cash_added6;
public int CashAdded6
{
get { return cash_added6; }
set { 
cash_added6 = value;
cash_added6Changed = true;
}
}
private string cash_added6DbString
{
get
{
return cash_added6.ToString();
}
}
#endregion
#region CashAdded7
private bool cash_added7Changed = false;
private int cash_added7;
public int CashAdded7
{
get { return cash_added7; }
set { 
cash_added7 = value;
cash_added7Changed = true;
}
}
private string cash_added7DbString
{
get
{
return cash_added7.ToString();
}
}
#endregion
#region RepDatetime
private bool rep_datetimeChanged = false;
private DateTime rep_datetime;
public DateTime RepDatetime
{
get { return rep_datetime; }
set { 
rep_datetime = value;
rep_datetimeChanged = true;
}
}
private string rep_datetimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",rep_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region RepStatus
private bool rep_statusChanged = false;
private string rep_status;
public string RepStatus
{
get { return rep_status; }
set { 
rep_status = value;
rep_statusChanged = true;
}
}
private string rep_statusDbString
{
get
{
if (this.rep_status!=null)
return string.Format("'{0}'",rep_status); else
return "null";
}
}
#endregion
#region ReplenishmentId
private bool replenishment_idChanged = false;
private int replenishment_id;
public int ReplenishmentId
{
get { return replenishment_id; }
set { 
replenishment_id = value;
replenishment_idChanged = true;
}
}
private string replenishment_idDbString
{
get
{
return replenishment_id.ToString();
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
#region CashOrderId
private bool cash_order_idChanged = false;
private int? cash_order_id;
public int? CashOrderId
{
get { return cash_order_id; }
set { 
cash_order_id = value;
cash_order_idChanged = true;
}
}
private string cash_order_idDbString
{
get
{
if (this.cash_order_id.HasValue)
return cash_order_id.ToString();
else
return "null";
}
}
#endregion
#region IsSwap
private bool is_swapChanged = false;
private bool is_swap;
public bool IsSwap
{
get { return is_swap; }
set { 
is_swap = value;
is_swapChanged = true;
}
}
private string is_swapDbString
{
get
{
return is_swap?"1":"0";
}
}
#endregion
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime? generated_at;
public DateTime? GeneratedAt
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
if (this.generated_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",generated_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region IsUpdated
private bool is_updatedChanged = false;
private bool? is_updated;
public bool? IsUpdated
{
get { return is_updated; }
set { 
is_updated = value;
is_updatedChanged = true;
}
}
private string is_updatedDbString
{
get
{
if (this.is_updated.HasValue)
return is_updated.Value?"1":"0";
else
return "null";
}
}
#endregion
#region ReplenishmentHistoryId
private bool replenishment_history_idChanged = false;
private int replenishment_history_id;
public int ReplenishmentHistoryId
{
get { return replenishment_history_id; }
set { 
replenishment_history_id = value;
replenishment_history_idChanged = true;
}
}
private string replenishment_history_idDbString
{
get
{
return replenishment_history_id.ToString();
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
#region ModifiedDatetime
private bool modified_datetimeChanged = false;
private DateTime? modified_datetime;
public DateTime? ModifiedDatetime
{
get { return modified_datetime; }
set { 
modified_datetime = value;
modified_datetimeChanged = true;
}
}
private string modified_datetimeDbString
{
get
{
if (this.modified_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modified_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region GeneratedBy
private bool generated_byChanged = false;
private int? generated_by;
public int? GeneratedBy
{
get { return generated_by; }
set { 
generated_by = value;
generated_byChanged = true;
}
}
private string generated_byDbString
{
get
{
if (this.generated_by.HasValue)
return generated_by.ToString();
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
#endregion

#region ReplenishmentHistoryReader
public class ReplenishmentHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReplenishmentHistory currentReplenishmentHistory;
Columns columns;
bool partialRead = false;
private ReplenishmentHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReplenishmentHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReplenishmentHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReplenishmentHistory; }

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
currentReplenishmentHistory = new ReplenishmentHistory();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentReplenishmentHistory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.cash_added1) == Columns.cash_added1 && reader["cash_added1"]!=DBNull.Value)
currentReplenishmentHistory.cash_added1 =(int) reader["cash_added1"]; 
if ((columns & Columns.cash_added2) == Columns.cash_added2 && reader["cash_added2"]!=DBNull.Value)
currentReplenishmentHistory.cash_added2 =(int) reader["cash_added2"]; 
if ((columns & Columns.cash_added3) == Columns.cash_added3 && reader["cash_added3"]!=DBNull.Value)
currentReplenishmentHistory.cash_added3 =(int) reader["cash_added3"]; 
if ((columns & Columns.cash_added4) == Columns.cash_added4 && reader["cash_added4"]!=DBNull.Value)
currentReplenishmentHistory.cash_added4 =(int) reader["cash_added4"]; 
if ((columns & Columns.cash_added5) == Columns.cash_added5 && reader["cash_added5"]!=DBNull.Value)
currentReplenishmentHistory.cash_added5 =(int) reader["cash_added5"]; 
if ((columns & Columns.cash_added6) == Columns.cash_added6 && reader["cash_added6"]!=DBNull.Value)
currentReplenishmentHistory.cash_added6 =(int) reader["cash_added6"]; 
if ((columns & Columns.cash_added7) == Columns.cash_added7 && reader["cash_added7"]!=DBNull.Value)
currentReplenishmentHistory.cash_added7 =(int) reader["cash_added7"]; 
if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"]!=DBNull.Value)
currentReplenishmentHistory.rep_datetime =(DateTime) reader["rep_datetime"]; 
if ((columns & Columns.rep_status) == Columns.rep_status && reader["rep_status"]!=DBNull.Value)
currentReplenishmentHistory.rep_status =(string) reader["rep_status"]; 
if ((columns & Columns.replenishment_id) == Columns.replenishment_id && reader["replenishment_id"]!=DBNull.Value)
currentReplenishmentHistory.replenishment_id =(int) reader["replenishment_id"]; 
if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
currentReplenishmentHistory.task_id =(int) reader["task_id"]; 
if ((columns & Columns.cash_order_id) == Columns.cash_order_id && reader["cash_order_id"]!=DBNull.Value)
currentReplenishmentHistory.cash_order_id =(int?) reader["cash_order_id"]; 
if ((columns & Columns.is_swap) == Columns.is_swap && reader["is_swap"]!=DBNull.Value)
currentReplenishmentHistory.is_swap =(bool) reader["is_swap"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentReplenishmentHistory.generated_at =(DateTime?) reader["generated_at"]; 
if ((columns & Columns.is_updated) == Columns.is_updated && reader["is_updated"]!=DBNull.Value)
currentReplenishmentHistory.is_updated =(bool?) reader["is_updated"]; 
if ((columns & Columns.replenishment_history_id) == Columns.replenishment_history_id && reader["replenishment_history_id"]!=DBNull.Value)
currentReplenishmentHistory.replenishment_history_id =(int) reader["replenishment_history_id"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentReplenishmentHistory.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.modified_datetime) == Columns.modified_datetime && reader["modified_datetime"]!=DBNull.Value)
currentReplenishmentHistory.modified_datetime =(DateTime?) reader["modified_datetime"]; 
if ((columns & Columns.generated_by) == Columns.generated_by && reader["generated_by"]!=DBNull.Value)
currentReplenishmentHistory.generated_by =(int?) reader["generated_by"]; 
if ((columns & Columns.reason) == Columns.reason && reader["reason"]!=DBNull.Value)
currentReplenishmentHistory.reason =(string) reader["reason"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentReplenishmentHistory.atm_id = (int) reader["atm_id"]; 
if (reader["cash_added1"] != DBNull.Value)
currentReplenishmentHistory.cash_added1 = (int) reader["cash_added1"]; 
if (reader["cash_added2"] != DBNull.Value)
currentReplenishmentHistory.cash_added2 = (int) reader["cash_added2"]; 
if (reader["cash_added3"] != DBNull.Value)
currentReplenishmentHistory.cash_added3 = (int) reader["cash_added3"]; 
if (reader["cash_added4"] != DBNull.Value)
currentReplenishmentHistory.cash_added4 = (int) reader["cash_added4"]; 
if (reader["cash_added5"] != DBNull.Value)
currentReplenishmentHistory.cash_added5 = (int) reader["cash_added5"]; 
if (reader["cash_added6"] != DBNull.Value)
currentReplenishmentHistory.cash_added6 = (int) reader["cash_added6"]; 
if (reader["cash_added7"] != DBNull.Value)
currentReplenishmentHistory.cash_added7 = (int) reader["cash_added7"]; 
if (reader["rep_datetime"] != DBNull.Value)
currentReplenishmentHistory.rep_datetime = (DateTime) reader["rep_datetime"]; 
if (reader["rep_status"] != DBNull.Value)
currentReplenishmentHistory.rep_status = (string) reader["rep_status"]; 
if (reader["replenishment_id"] != DBNull.Value)
currentReplenishmentHistory.replenishment_id = (int) reader["replenishment_id"]; 
if (reader["task_id"] != DBNull.Value)
currentReplenishmentHistory.task_id = (int) reader["task_id"]; 
if (reader["cash_order_id"] != DBNull.Value)
currentReplenishmentHistory.cash_order_id = (int?) reader["cash_order_id"]; 
if (reader["is_swap"] != DBNull.Value)
currentReplenishmentHistory.is_swap = (bool) reader["is_swap"]; 
if (reader["generated_at"] != DBNull.Value)
currentReplenishmentHistory.generated_at = (DateTime?) reader["generated_at"]; 
if (reader["is_updated"] != DBNull.Value)
currentReplenishmentHistory.is_updated = (bool?) reader["is_updated"]; 
if (reader["replenishment_history_id"] != DBNull.Value)
currentReplenishmentHistory.replenishment_history_id = (int) reader["replenishment_history_id"]; 
if (reader["modified_by"] != DBNull.Value)
currentReplenishmentHistory.modified_by = (int?) reader["modified_by"]; 
if (reader["modified_datetime"] != DBNull.Value)
currentReplenishmentHistory.modified_datetime = (DateTime?) reader["modified_datetime"]; 
if (reader["generated_by"] != DBNull.Value)
currentReplenishmentHistory.generated_by = (int?) reader["generated_by"]; 
if (reader["reason"] != DBNull.Value)
currentReplenishmentHistory.reason = (string) reader["reason"]; 
} 

currentReplenishmentHistory.isNewEntity = false;
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

public ReplenishmentHistory CurrentReplenishmentHistory
{
get{ return currentReplenishmentHistory; }
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


#region ReplenishmentHistory functions

public static ReplenishmentHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.cash_added1 == (Columns.cash_added1 & columns))
qry.Append("cash_added1,");
if (Columns.cash_added2 == (Columns.cash_added2 & columns))
qry.Append("cash_added2,");
if (Columns.cash_added3 == (Columns.cash_added3 & columns))
qry.Append("cash_added3,");
if (Columns.cash_added4 == (Columns.cash_added4 & columns))
qry.Append("cash_added4,");
if (Columns.cash_added5 == (Columns.cash_added5 & columns))
qry.Append("cash_added5,");
if (Columns.cash_added6 == (Columns.cash_added6 & columns))
qry.Append("cash_added6,");
if (Columns.cash_added7 == (Columns.cash_added7 & columns))
qry.Append("cash_added7,");
if (Columns.rep_datetime == (Columns.rep_datetime & columns))
qry.Append("rep_datetime,");
if (Columns.rep_status == (Columns.rep_status & columns))
qry.Append("rep_status,");
if (Columns.replenishment_id == (Columns.replenishment_id & columns))
qry.Append("replenishment_id,");
if (Columns.task_id == (Columns.task_id & columns))
qry.Append("task_id,");
if (Columns.cash_order_id == (Columns.cash_order_id & columns))
qry.Append("cash_order_id,");
if (Columns.is_swap == (Columns.is_swap & columns))
qry.Append("is_swap,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.is_updated == (Columns.is_updated & columns))
qry.Append("is_updated,");
if (Columns.replenishment_history_id == (Columns.replenishment_history_id & columns))
qry.Append("replenishment_history_id,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.modified_datetime == (Columns.modified_datetime & columns))
qry.Append("modified_datetime,");
if (Columns.generated_by == (Columns.generated_by & columns))
qry.Append("generated_by,");
if (Columns.reason == (Columns.reason & columns))
qry.Append("reason,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from ReplenishmentHistory ");

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
return new ReplenishmentHistoryReader(cmd.ExecuteReader(), conn, columns);
}

static public ReplenishmentHistoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReplenishmentHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,rep_datetime,rep_status,replenishment_id,task_id,cash_order_id,is_swap,generated_at,is_updated,replenishment_history_id,modified_by,modified_datetime,generated_by,reason from ReplenishmentHistory ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReplenishmentHistoryReader(cmd.ExecuteReader(), conn);
}

static public ReplenishmentHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReplenishmentHistory LoadReplenishmentHistory(string where)
{
ReplenishmentHistoryReader reader = ReplenishmentHistory.ExecuteReader(where);
ReplenishmentHistory _replenishmenthistory = null;
if (reader.Read())
_replenishmenthistory = reader.CurrentReplenishmentHistory;
reader.Close();
return _replenishmenthistory;
}

public static ReplenishmentHistory LoadReplenishmentHistory(string where, IDbConnection conn)
{
ReplenishmentHistoryReader reader = ReplenishmentHistory.ExecuteReader(where, conn);
ReplenishmentHistory _replenishmenthistory = null;
if (reader.Read())
_replenishmenthistory = reader.CurrentReplenishmentHistory;
reader.Close(false);
return _replenishmenthistory;
}

public static ReplenishmentHistory LoadReplenishmentHistoryByPk( int replenishment_history_id )
{
return LoadReplenishmentHistory( " replenishment_history_id="+replenishment_history_id );
}

public static ReplenishmentHistory LoadReplenishmentHistoryByPk( int replenishment_history_id , IDbConnection conn)
{
return LoadReplenishmentHistory(" replenishment_history_id="+replenishment_history_id , conn);
}

public void Save()
{
if (atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || rep_datetimeChanged || rep_statusChanged || replenishment_idChanged || task_idChanged || cash_order_idChanged || is_swapChanged || generated_atChanged || is_updatedChanged || replenishment_history_idChanged || modified_byChanged || modified_datetimeChanged || generated_byChanged || reasonChanged )
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
if (atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || rep_datetimeChanged || rep_statusChanged || replenishment_idChanged || task_idChanged || cash_order_idChanged || is_swapChanged || generated_atChanged || is_updatedChanged || replenishment_history_idChanged || modified_byChanged || modified_datetimeChanged || generated_byChanged || reasonChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into ReplenishmentHistory( atm_id,cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,rep_datetime,rep_status,replenishment_id,task_id,cash_order_id,is_swap,generated_at,is_updated,replenishment_history_id,modified_by,modified_datetime,generated_by,reason ) values(");
qry.Append(atm_idDbString+",");
qry.Append(cash_added1DbString+",");
qry.Append(cash_added2DbString+",");
qry.Append(cash_added3DbString+",");
qry.Append(cash_added4DbString+",");
qry.Append(cash_added5DbString+",");
qry.Append(cash_added6DbString+",");
qry.Append(cash_added7DbString+",");
qry.Append(rep_datetimeDbString+",");
qry.Append(rep_statusDbString+",");
qry.Append(replenishment_idDbString+",");
qry.Append(task_idDbString+",");
qry.Append(cash_order_idDbString+",");
qry.Append(is_swapDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(is_updatedDbString+",");
lock (ConnectionFactory.connectionString) { this.replenishment_history_id = ConnectionFactory.GetNextId();
qry.Append(this.replenishment_history_id);
} qry.Append(",");
qry.Append(modified_byDbString+",");
qry.Append(modified_datetimeDbString+",");
qry.Append(generated_byDbString+",");
qry.Append(reasonDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || rep_datetimeChanged || rep_statusChanged || replenishment_idChanged || task_idChanged || cash_order_idChanged || is_swapChanged || generated_atChanged || is_updatedChanged || replenishment_history_idChanged || modified_byChanged || modified_datetimeChanged || generated_byChanged || reasonChanged ))
return;
qry.Append("UPDATE ReplenishmentHistory set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( cash_added1Changed )
{
qry.Append("cash_added1 ="+cash_added1DbString);
qry.Append(",");
}

if ( cash_added2Changed )
{
qry.Append("cash_added2 ="+cash_added2DbString);
qry.Append(",");
}

if ( cash_added3Changed )
{
qry.Append("cash_added3 ="+cash_added3DbString);
qry.Append(",");
}

if ( cash_added4Changed )
{
qry.Append("cash_added4 ="+cash_added4DbString);
qry.Append(",");
}

if ( cash_added5Changed )
{
qry.Append("cash_added5 ="+cash_added5DbString);
qry.Append(",");
}

if ( cash_added6Changed )
{
qry.Append("cash_added6 ="+cash_added6DbString);
qry.Append(",");
}

if ( cash_added7Changed )
{
qry.Append("cash_added7 ="+cash_added7DbString);
qry.Append(",");
}

if ( rep_datetimeChanged )
{
qry.Append("rep_datetime ="+rep_datetimeDbString);
qry.Append(",");
}

if ( rep_statusChanged )
{
qry.Append("rep_status ="+rep_statusDbString);
qry.Append(",");
}

if ( replenishment_idChanged )
{
qry.Append("replenishment_id ="+replenishment_idDbString);
qry.Append(",");
}

if ( task_idChanged )
{
qry.Append("task_id ="+task_idDbString);
qry.Append(",");
}

if ( cash_order_idChanged )
{
qry.Append("cash_order_id ="+cash_order_idDbString);
qry.Append(",");
}

if ( is_swapChanged )
{
qry.Append("is_swap ="+is_swapDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( is_updatedChanged )
{
qry.Append("is_updated ="+is_updatedDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( modified_datetimeChanged )
{
qry.Append("modified_datetime ="+modified_datetimeDbString);
qry.Append(",");
}

if ( generated_byChanged )
{
qry.Append("generated_by ="+generated_byDbString);
qry.Append(",");
}

if ( reasonChanged )
{
qry.Append("reason ="+reasonDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("replenishment_history_id = "+replenishment_history_idDbString);
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
cmd.CommandText = "DELETE ReplenishmentHistory where replenishment_history_id = "+ replenishment_history_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReplenishmentHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete ReplenishmentHistory where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
cash_added1= 2,
cash_added2= 4,
cash_added3= 8,
cash_added4= 16,
cash_added5= 32,
cash_added6= 64,
cash_added7= 128,
rep_datetime= 256,
rep_status= 512,
replenishment_id= 1024,
task_id= 2048,
cash_order_id= 4096,
is_swap= 8192,
generated_at= 16384,
is_updated= 32768,
replenishment_history_id= 65536,
modified_by= 131072,
modified_datetime= 262144,
generated_by= 524288,
reason= 1048576
}
#endregion
public void BulkSave(List<ReplenishmentHistory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "ReplenishmentHistory";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReplenishmentHistory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReplenishmentHistory> transList,ref DataTable dt)
{
foreach (ReplenishmentHistory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] = tran.AtmId;
Row["cash_added1"] = tran.CashAdded1;
Row["cash_added2"] = tran.CashAdded2;
Row["cash_added3"] = tran.CashAdded3;
Row["cash_added4"] = tran.CashAdded4;
Row["cash_added5"] = tran.CashAdded5;
Row["cash_added6"] = tran.CashAdded6;
Row["cash_added7"] = tran.CashAdded7;
Row["rep_datetime"] = tran.RepDatetime;
Row["rep_status"] = tran.RepStatus;
Row["replenishment_id"] = tran.ReplenishmentId;
Row["task_id"] = tran.TaskId;
Row["cash_order_id"] = tran.CashOrderId;
Row["is_swap"] = tran.IsSwap;
Row["generated_at"] = tran.GeneratedAt;
Row["is_updated"] = tran.IsUpdated;
Row["replenishment_history_id"] =ConnectionFactory.GetNextId();
Row["modified_by"] = tran.ModifiedBy;
Row["modified_datetime"] = tran.ModifiedDatetime;
Row["generated_by"] = tran.GeneratedBy;
Row["reason"] = tran.Reason;
dt.Rows.Add(Row);
} }
}
}
