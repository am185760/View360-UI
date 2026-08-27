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
public class CashDataStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CashDataStatus() { }
public CashDataStatus( int? atm_id,DateTime? cash_data_download_time,DateTime? recorded_at )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cash_data_download_time = cash_data_download_time;
this.cash_data_download_timeChanged = true;
this.recorded_at = recorded_at;
this.recorded_atChanged = true;
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
#region CashDataDownloadTime
private bool cash_data_download_timeChanged = false;
private DateTime? cash_data_download_time;
public DateTime? CashDataDownloadTime
{
get { return cash_data_download_time; }
set { 
cash_data_download_time = value;
cash_data_download_timeChanged = true;
}
}
private string cash_data_download_timeDbString
{
get
{
if (this.cash_data_download_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",cash_data_download_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region RecordedAt
private bool recorded_atChanged = false;
private DateTime? recorded_at;
public DateTime? RecordedAt
{
get { return recorded_at; }
set { 
recorded_at = value;
recorded_atChanged = true;
}
}
private string recorded_atDbString
{
get
{
if (this.recorded_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",recorded_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#endregion

#region CashDataStatusReader
public class CashDataStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CashDataStatus currentCashDataStatus;
Columns columns;
bool partialRead = false;
private CashDataStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CashDataStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CashDataStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCashDataStatus; }

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
currentCashDataStatus = new CashDataStatus();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCashDataStatus.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.cash_data_download_time) == Columns.cash_data_download_time && reader["cash_data_download_time"]!=DBNull.Value)
currentCashDataStatus.cash_data_download_time =(DateTime?) reader["cash_data_download_time"]; 
if ((columns & Columns.recorded_at) == Columns.recorded_at && reader["recorded_at"]!=DBNull.Value)
currentCashDataStatus.recorded_at =(DateTime?) reader["recorded_at"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentCashDataStatus.atm_id = (int?) reader["atm_id"]; 
if (reader["cash_data_download_time"] != DBNull.Value)
currentCashDataStatus.cash_data_download_time = (DateTime?) reader["cash_data_download_time"]; 
if (reader["recorded_at"] != DBNull.Value)
currentCashDataStatus.recorded_at = (DateTime?) reader["recorded_at"]; 
} 

currentCashDataStatus.isNewEntity = false;
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

public CashDataStatus CurrentCashDataStatus
{
get{ return currentCashDataStatus; }
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


#region CashDataStatus functions

public static CashDataStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.cash_data_download_time == (Columns.cash_data_download_time & columns))
qry.Append("cash_data_download_time,");
if (Columns.recorded_at == (Columns.recorded_at & columns))
qry.Append("recorded_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Cash_data_status ");

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
return new CashDataStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public CashDataStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CashDataStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,cash_data_download_time,recorded_at from Cash_data_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CashDataStatusReader(cmd.ExecuteReader(), conn);
}

static public CashDataStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CashDataStatus LoadCashDataStatus(string where)
{
CashDataStatusReader reader = CashDataStatus.ExecuteReader(where);
CashDataStatus _cashdatastatus = null;
if (reader.Read())
_cashdatastatus = reader.CurrentCashDataStatus;
reader.Close();
return _cashdatastatus;
}

public static CashDataStatus LoadCashDataStatus(string where, IDbConnection conn)
{
CashDataStatusReader reader = CashDataStatus.ExecuteReader(where, conn);
CashDataStatus _cashdatastatus = null;
if (reader.Read())
_cashdatastatus = reader.CurrentCashDataStatus;
reader.Close(false);
return _cashdatastatus;
}


public void Save()
{
if (atm_idChanged || cash_data_download_timeChanged || recorded_atChanged )
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
if (atm_idChanged || cash_data_download_timeChanged || recorded_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Cash_data_status( atm_id,cash_data_download_time,recorded_at ) values(");
qry.Append(atm_idDbString+",");
qry.Append(cash_data_download_timeDbString+",");
qry.Append(recorded_atDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Cash_data_status!");
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

public static void DeleteCashDataStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete Cash_data_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
cash_data_download_time= 2,
recorded_at= 4
}
#endregion
}
}
