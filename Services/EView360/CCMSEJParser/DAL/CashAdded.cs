using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;

namespace Avanza.CCMS.DAL
{
[Serializable()]
public class CashAdded
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CashAdded() { }
public CashAdded( int? atm_id,int? cash_added1,int? cash_added2,int? cash_added3,int? cash_added4,DateTime? rep_datetime,bool? status ) 
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
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.status = status;
this.statusChanged = true;
}
public CashAdded( int? atm_id,int? cash_added1,int? cash_added2,int? cash_added3,int? cash_added4,DateTime? rep_datetime,bool? status,string reason )
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
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.status = status;
this.statusChanged = true;
this.reason = reason;
this.reasonChanged = true;
}

#region members and properties for columns

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
#region CashAdded1
private bool cash_added1Changed = false;
private int? cash_added1;
public int? CashAdded1
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
if (this.cash_added1.HasValue)
return cash_added1.ToString();
else
return "null";
}
}
#endregion
#region CashAdded2
private bool cash_added2Changed = false;
private int? cash_added2;
public int? CashAdded2
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
if (this.cash_added2.HasValue)
return cash_added2.ToString();
else
return "null";
}
}
#endregion
#region CashAdded3
private bool cash_added3Changed = false;
private int? cash_added3;
public int? CashAdded3
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
if (this.cash_added3.HasValue)
return cash_added3.ToString();
else
return "null";
}
}
#endregion
#region CashAdded4
private bool cash_added4Changed = false;
private int? cash_added4;
public int? CashAdded4
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
if (this.cash_added4.HasValue)
return cash_added4.ToString();
else
return "null";
}
}
#endregion
#region RepDatetime
private bool rep_datetimeChanged = false;
private DateTime? rep_datetime;
public DateTime? RepDatetime
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
if (this.rep_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",rep_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region Status
private bool statusChanged = false;
private bool? status;
public bool? Status
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
if (this.status.HasValue)
return status.Value?"1":"0";
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

#region CashAddedReader
public class CashAddedReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CashAdded currentCashAdded;
Columns columns;
bool partialRead = false;
private CashAddedReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CashAddedReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CashAddedReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCashAdded; }

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
currentCashAdded = new CashAdded();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCashAdded.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.cash_added1) == Columns.cash_added1 && reader["cash_added1"]!=DBNull.Value)
currentCashAdded.cash_added1 =(int?) reader["cash_added1"]; 
if ((columns & Columns.cash_added2) == Columns.cash_added2 && reader["cash_added2"]!=DBNull.Value)
currentCashAdded.cash_added2 =(int?) reader["cash_added2"]; 
if ((columns & Columns.cash_added3) == Columns.cash_added3 && reader["cash_added3"]!=DBNull.Value)
currentCashAdded.cash_added3 =(int?) reader["cash_added3"]; 
if ((columns & Columns.cash_added4) == Columns.cash_added4 && reader["cash_added4"]!=DBNull.Value)
currentCashAdded.cash_added4 =(int?) reader["cash_added4"]; 
if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"]!=DBNull.Value)
currentCashAdded.rep_datetime =(DateTime?) reader["rep_datetime"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentCashAdded.status =(bool?) reader["status"]; 
if ((columns & Columns.reason) == Columns.reason && reader["reason"]!=DBNull.Value)
currentCashAdded.reason =(string) reader["reason"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentCashAdded.atm_id = (int?) reader["atm_id"]; 
if (reader["cash_added1"] != DBNull.Value)
currentCashAdded.cash_added1 = (int?) reader["cash_added1"]; 
if (reader["cash_added2"] != DBNull.Value)
currentCashAdded.cash_added2 = (int?) reader["cash_added2"]; 
if (reader["cash_added3"] != DBNull.Value)
currentCashAdded.cash_added3 = (int?) reader["cash_added3"]; 
if (reader["cash_added4"] != DBNull.Value)
currentCashAdded.cash_added4 = (int?) reader["cash_added4"]; 
if (reader["rep_datetime"] != DBNull.Value)
currentCashAdded.rep_datetime = (DateTime?) reader["rep_datetime"]; 
if (reader["status"] != DBNull.Value)
currentCashAdded.status = (bool?) reader["status"]; 
if (reader["reason"] != DBNull.Value)
currentCashAdded.reason = (string) reader["reason"]; 
} 

currentCashAdded.isNewEntity = false;
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

public CashAdded CurrentCashAdded
{
get{ return currentCashAdded; }
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


#region CashAdded functions

public static CashAddedReader ExecuteReader(string where, IDbConnection conn, Columns columns)
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
if (Columns.rep_datetime == (Columns.rep_datetime & columns))
qry.Append("rep_datetime,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.reason == (Columns.reason & columns))
qry.Append("reason,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Cash_added ");

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
return new CashAddedReader(cmd.ExecuteReader(), conn, columns);
}

static public CashAddedReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CashAddedReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,status,reason from Cash_added ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CashAddedReader(cmd.ExecuteReader(), conn);
}

static public CashAddedReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CashAdded LoadCashAdded(string where)
{
CashAddedReader reader = CashAdded.ExecuteReader(where);
CashAdded _cashadded = null;
if (reader.Read())
_cashadded = reader.CurrentCashAdded;
reader.Close();
return _cashadded;
}

public static CashAdded LoadCashAdded(string where, IDbConnection conn)
{
CashAddedReader reader = CashAdded.ExecuteReader(where, conn);
CashAdded _cashadded = null;
if (reader.Read())
_cashadded = reader.CurrentCashAdded;
reader.Close(false);
return _cashadded;
}


public void Save()
{
if (atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || rep_datetimeChanged || statusChanged || reasonChanged )
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
if (atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || rep_datetimeChanged || statusChanged || reasonChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Cash_added( atm_id,cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,status,reason ) values(");
qry.Append(atm_idDbString+",");
qry.Append(cash_added1DbString+",");
qry.Append(cash_added2DbString+",");
qry.Append(cash_added3DbString+",");
qry.Append(cash_added4DbString+",");
qry.Append(rep_datetimeDbString+",");
qry.Append(statusDbString+",");
qry.Append(reasonDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Cash_added!");
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
throw new Exception("Could not delete because no primary key is defined");
}

public static void DeleteCashAddeds(string where)
{
ConnectionFactory.ExecuteQuery("delete Cash_added where " + where);
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
rep_datetime= 32,
status= 64,
reason= 128
}
#endregion
}
}
