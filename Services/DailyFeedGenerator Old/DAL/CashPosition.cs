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
public class CashPosition
{
public bool isNewEntity = true;
public bool IsNewEntity
{
get { return isNewEntity; }
}

public CashPosition() { }
public CashPosition( int cash_position_id,int atm_id,int task_id,DateTime last_trxn_at ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.last_trxn_at = last_trxn_at;
this.last_trxn_atChanged = true;
}
public CashPosition( int atm_id,int? cassette1_notes,int? cassette2_notes,int? cassette3_notes,int? cassette4_notes,int? cassette5_notes,int? cassette6_notes,int? cassette7_notes,int task_id,DateTime last_trxn_at,int? purge_cassette1_notes,int? purge_cassette2_notes,int? purge_cassette3_notes,int? purge_cassette4_notes,int? purge_cassette5_notes,int? purge_cassette6_notes,int? purge_cassette7_notes )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette1_notes = cassette1_notes;
this.cassette1_notesChanged = true;
this.cassette2_notes = cassette2_notes;
this.cassette2_notesChanged = true;
this.cassette3_notes = cassette3_notes;
this.cassette3_notesChanged = true;
this.cassette4_notes = cassette4_notes;
this.cassette4_notesChanged = true;
this.cassette5_notes = cassette5_notes;
this.cassette5_notesChanged = true;
this.cassette6_notes = cassette6_notes;
this.cassette6_notesChanged = true;
this.cassette7_notes = cassette7_notes;
this.cassette7_notesChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.last_trxn_at = last_trxn_at;
this.last_trxn_atChanged = true;
this.purge_cassette1_notes = purge_cassette1_notes;
this.purge_cassette1_notesChanged = true;
this.purge_cassette2_notes = purge_cassette2_notes;
this.purge_cassette2_notesChanged = true;
this.purge_cassette3_notes = purge_cassette3_notes;
this.purge_cassette3_notesChanged = true;
this.purge_cassette4_notes = purge_cassette4_notes;
this.purge_cassette4_notesChanged = true;
this.purge_cassette5_notes = purge_cassette5_notes;
this.purge_cassette5_notesChanged = true;
this.purge_cassette6_notes = purge_cassette6_notes;
this.purge_cassette6_notesChanged = true;
this.purge_cassette7_notes = purge_cassette7_notes;
this.purge_cassette7_notesChanged = true;
}
private CashPosition( int cash_position_id,int atm_id,int? cassette1_notes,int? cassette2_notes,int? cassette3_notes,int? cassette4_notes,int? cassette5_notes,int? cassette6_notes,int? cassette7_notes,int task_id,DateTime last_trxn_at,int? purge_cassette1_notes,int? purge_cassette2_notes,int? purge_cassette3_notes,int? purge_cassette4_notes,int? purge_cassette5_notes,int? purge_cassette6_notes,int? purge_cassette7_notes )
{
this.cash_position_id = cash_position_id;
this.cash_position_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette1_notes = cassette1_notes;
this.cassette1_notesChanged = true;
this.cassette2_notes = cassette2_notes;
this.cassette2_notesChanged = true;
this.cassette3_notes = cassette3_notes;
this.cassette3_notesChanged = true;
this.cassette4_notes = cassette4_notes;
this.cassette4_notesChanged = true;
this.cassette5_notes = cassette5_notes;
this.cassette5_notesChanged = true;
this.cassette6_notes = cassette6_notes;
this.cassette6_notesChanged = true;
this.cassette7_notes = cassette7_notes;
this.cassette7_notesChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.last_trxn_at = last_trxn_at;
this.last_trxn_atChanged = true;
this.purge_cassette1_notes = purge_cassette1_notes;
this.purge_cassette1_notesChanged = true;
this.purge_cassette2_notes = purge_cassette2_notes;
this.purge_cassette2_notesChanged = true;
this.purge_cassette3_notes = purge_cassette3_notes;
this.purge_cassette3_notesChanged = true;
this.purge_cassette4_notes = purge_cassette4_notes;
this.purge_cassette4_notesChanged = true;
this.purge_cassette5_notes = purge_cassette5_notes;
this.purge_cassette5_notesChanged = true;
this.purge_cassette6_notes = purge_cassette6_notes;
this.purge_cassette6_notesChanged = true;
this.purge_cassette7_notes = purge_cassette7_notes;
this.purge_cassette7_notesChanged = true;
}

#region members and properties for columns

#region CashPositionId
private bool cash_position_idChanged = false;
private int cash_position_id;
public int CashPositionId
{
get { return cash_position_id; }
set { 
cash_position_id = value;
cash_position_idChanged = true;
}
}
private string cash_position_idDbString
{
get
{
return cash_position_id.ToString();
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
#region Cassette1Notes
private bool cassette1_notesChanged = false;
private int? cassette1_notes;
public int? Cassette1Notes
{
get { return cassette1_notes; }
set { 
cassette1_notes = value;
cassette1_notesChanged = true;
}
}
private string cassette1_notesDbString
{
get
{
if (this.cassette1_notes.HasValue)
return cassette1_notes.ToString();
else
return "null";
}
}
#endregion
#region Cassette2Notes
private bool cassette2_notesChanged = false;
private int? cassette2_notes;
public int? Cassette2Notes
{
get { return cassette2_notes; }
set { 
cassette2_notes = value;
cassette2_notesChanged = true;
}
}
private string cassette2_notesDbString
{
get
{
if (this.cassette2_notes.HasValue)
return cassette2_notes.ToString();
else
return "null";
}
}
#endregion
#region Cassette3Notes
private bool cassette3_notesChanged = false;
private int? cassette3_notes;
public int? Cassette3Notes
{
get { return cassette3_notes; }
set { 
cassette3_notes = value;
cassette3_notesChanged = true;
}
}
private string cassette3_notesDbString
{
get
{
if (this.cassette3_notes.HasValue)
return cassette3_notes.ToString();
else
return "null";
}
}
#endregion
#region Cassette4Notes
private bool cassette4_notesChanged = false;
private int? cassette4_notes;
public int? Cassette4Notes
{
get { return cassette4_notes; }
set { 
cassette4_notes = value;
cassette4_notesChanged = true;
}
}
private string cassette4_notesDbString
{
get
{
if (this.cassette4_notes.HasValue)
return cassette4_notes.ToString();
else
return "null";
}
}
#endregion
#region Cassette5Notes
private bool cassette5_notesChanged = false;
private int? cassette5_notes;
public int? Cassette5Notes
{
get { return cassette5_notes; }
set { 
cassette5_notes = value;
cassette5_notesChanged = true;
}
}
private string cassette5_notesDbString
{
get
{
if (this.cassette5_notes.HasValue)
return cassette5_notes.ToString();
else
return "null";
}
}
#endregion
#region Cassette6Notes
private bool cassette6_notesChanged = false;
private int? cassette6_notes;
public int? Cassette6Notes
{
get { return cassette6_notes; }
set { 
cassette6_notes = value;
cassette6_notesChanged = true;
}
}
private string cassette6_notesDbString
{
get
{
if (this.cassette6_notes.HasValue)
return cassette6_notes.ToString();
else
return "null";
}
}
#endregion
#region Cassette7Notes
private bool cassette7_notesChanged = false;
private int? cassette7_notes;
public int? Cassette7Notes
{
get { return cassette7_notes; }
set { 
cassette7_notes = value;
cassette7_notesChanged = true;
}
}
private string cassette7_notesDbString
{
get
{
if (this.cassette7_notes.HasValue)
return cassette7_notes.ToString();
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
#region LastTrxnAt
private bool last_trxn_atChanged = false;
private DateTime last_trxn_at;
public DateTime LastTrxnAt
{
get { return last_trxn_at; }
set { 
last_trxn_at = value;
last_trxn_atChanged = true;
}
}
private string last_trxn_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",last_trxn_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region PurgeCassette1Notes
private bool purge_cassette1_notesChanged = false;
private int? purge_cassette1_notes;
public int? PurgeCassette1Notes
{
get { return purge_cassette1_notes; }
set { 
purge_cassette1_notes = value;
purge_cassette1_notesChanged = true;
}
}
private string purge_cassette1_notesDbString
{
get
{
if (this.purge_cassette1_notes.HasValue)
return purge_cassette1_notes.ToString();
else
return "null";
}
}
#endregion
#region PurgeCassette2Notes
private bool purge_cassette2_notesChanged = false;
private int? purge_cassette2_notes;
public int? PurgeCassette2Notes
{
get { return purge_cassette2_notes; }
set { 
purge_cassette2_notes = value;
purge_cassette2_notesChanged = true;
}
}
private string purge_cassette2_notesDbString
{
get
{
if (this.purge_cassette2_notes.HasValue)
return purge_cassette2_notes.ToString();
else
return "null";
}
}
#endregion
#region PurgeCassette3Notes
private bool purge_cassette3_notesChanged = false;
private int? purge_cassette3_notes;
public int? PurgeCassette3Notes
{
get { return purge_cassette3_notes; }
set { 
purge_cassette3_notes = value;
purge_cassette3_notesChanged = true;
}
}
private string purge_cassette3_notesDbString
{
get
{
if (this.purge_cassette3_notes.HasValue)
return purge_cassette3_notes.ToString();
else
return "null";
}
}
#endregion
#region PurgeCassette4Notes
private bool purge_cassette4_notesChanged = false;
private int? purge_cassette4_notes;
public int? PurgeCassette4Notes
{
get { return purge_cassette4_notes; }
set { 
purge_cassette4_notes = value;
purge_cassette4_notesChanged = true;
}
}
private string purge_cassette4_notesDbString
{
get
{
if (this.purge_cassette4_notes.HasValue)
return purge_cassette4_notes.ToString();
else
return "null";
}
}
#endregion
#region PurgeCassette5Notes
private bool purge_cassette5_notesChanged = false;
private int? purge_cassette5_notes;
public int? PurgeCassette5Notes
{
get { return purge_cassette5_notes; }
set { 
purge_cassette5_notes = value;
purge_cassette5_notesChanged = true;
}
}
private string purge_cassette5_notesDbString
{
get
{
if (this.purge_cassette5_notes.HasValue)
return purge_cassette5_notes.ToString();
else
return "null";
}
}
#endregion
#region PurgeCassette6Notes
private bool purge_cassette6_notesChanged = false;
private int? purge_cassette6_notes;
public int? PurgeCassette6Notes
{
get { return purge_cassette6_notes; }
set { 
purge_cassette6_notes = value;
purge_cassette6_notesChanged = true;
}
}
private string purge_cassette6_notesDbString
{
get
{
if (this.purge_cassette6_notes.HasValue)
return purge_cassette6_notes.ToString();
else
return "null";
}
}
#endregion
#region PurgeCassette7Notes
private bool purge_cassette7_notesChanged = false;
private int? purge_cassette7_notes;
public int? PurgeCassette7Notes
{
get { return purge_cassette7_notes; }
set { 
purge_cassette7_notes = value;
purge_cassette7_notesChanged = true;
}
}
private string purge_cassette7_notesDbString
{
get
{
if (this.purge_cassette7_notes.HasValue)
return purge_cassette7_notes.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CashPositionReader
public class CashPositionReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CashPosition currentCashPosition;
Columns columns;
bool partialRead = false;
private CashPositionReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CashPositionReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CashPositionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCashPosition; }

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
currentCashPosition = new CashPosition();
if (partialRead)
{ if ((columns & Columns.cash_position_id) == Columns.cash_position_id && reader["cash_position_id"]!=DBNull.Value)
currentCashPosition.cash_position_id =(int) reader["cash_position_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCashPosition.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.cassette1_notes) == Columns.cassette1_notes && reader["cassette1_notes"]!=DBNull.Value)
currentCashPosition.cassette1_notes =(int?) reader["cassette1_notes"]; 
if ((columns & Columns.cassette2_notes) == Columns.cassette2_notes && reader["cassette2_notes"]!=DBNull.Value)
currentCashPosition.cassette2_notes =(int?) reader["cassette2_notes"]; 
if ((columns & Columns.cassette3_notes) == Columns.cassette3_notes && reader["cassette3_notes"]!=DBNull.Value)
currentCashPosition.cassette3_notes =(int?) reader["cassette3_notes"]; 
if ((columns & Columns.cassette4_notes) == Columns.cassette4_notes && reader["cassette4_notes"]!=DBNull.Value)
currentCashPosition.cassette4_notes =(int?) reader["cassette4_notes"]; 
if ((columns & Columns.cassette5_notes) == Columns.cassette5_notes && reader["cassette5_notes"]!=DBNull.Value)
currentCashPosition.cassette5_notes =(int?) reader["cassette5_notes"]; 
if ((columns & Columns.cassette6_notes) == Columns.cassette6_notes && reader["cassette6_notes"]!=DBNull.Value)
currentCashPosition.cassette6_notes =(int?) reader["cassette6_notes"]; 
if ((columns & Columns.cassette7_notes) == Columns.cassette7_notes && reader["cassette7_notes"]!=DBNull.Value)
currentCashPosition.cassette7_notes =(int?) reader["cassette7_notes"]; 
if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
currentCashPosition.task_id =(int) reader["task_id"]; 
if ((columns & Columns.last_trxn_at) == Columns.last_trxn_at && reader["last_trxn_at"]!=DBNull.Value)
currentCashPosition.last_trxn_at =(DateTime) reader["last_trxn_at"]; 
if ((columns & Columns.purge_cassette1_notes) == Columns.purge_cassette1_notes && reader["purge_cassette1_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette1_notes =(int?) reader["purge_cassette1_notes"]; 
if ((columns & Columns.purge_cassette2_notes) == Columns.purge_cassette2_notes && reader["purge_cassette2_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette2_notes =(int?) reader["purge_cassette2_notes"]; 
if ((columns & Columns.purge_cassette3_notes) == Columns.purge_cassette3_notes && reader["purge_cassette3_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette3_notes =(int?) reader["purge_cassette3_notes"]; 
if ((columns & Columns.purge_cassette4_notes) == Columns.purge_cassette4_notes && reader["purge_cassette4_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette4_notes =(int?) reader["purge_cassette4_notes"]; 
if ((columns & Columns.purge_cassette5_notes) == Columns.purge_cassette5_notes && reader["purge_cassette5_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette5_notes =(int?) reader["purge_cassette5_notes"]; 
if ((columns & Columns.purge_cassette6_notes) == Columns.purge_cassette6_notes && reader["purge_cassette6_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette6_notes =(int?) reader["purge_cassette6_notes"]; 
if ((columns & Columns.purge_cassette7_notes) == Columns.purge_cassette7_notes && reader["purge_cassette7_notes"]!=DBNull.Value)
currentCashPosition.purge_cassette7_notes =(int?) reader["purge_cassette7_notes"]; 

} else
{
if (reader["cash_position_id"] != DBNull.Value)
currentCashPosition.cash_position_id = (int) reader["cash_position_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentCashPosition.atm_id = (int) reader["atm_id"]; 
if (reader["cassette1_notes"] != DBNull.Value)
currentCashPosition.cassette1_notes = (int?) reader["cassette1_notes"]; 
if (reader["cassette2_notes"] != DBNull.Value)
currentCashPosition.cassette2_notes = (int?) reader["cassette2_notes"]; 
if (reader["cassette3_notes"] != DBNull.Value)
currentCashPosition.cassette3_notes = (int?) reader["cassette3_notes"]; 
if (reader["cassette4_notes"] != DBNull.Value)
currentCashPosition.cassette4_notes = (int?) reader["cassette4_notes"]; 
if (reader["cassette5_notes"] != DBNull.Value)
currentCashPosition.cassette5_notes = (int?) reader["cassette5_notes"]; 
if (reader["cassette6_notes"] != DBNull.Value)
currentCashPosition.cassette6_notes = (int?) reader["cassette6_notes"]; 
if (reader["cassette7_notes"] != DBNull.Value)
currentCashPosition.cassette7_notes = (int?) reader["cassette7_notes"]; 
if (reader["task_id"] != DBNull.Value)
currentCashPosition.task_id = (int) reader["task_id"]; 
if (reader["last_trxn_at"] != DBNull.Value)
currentCashPosition.last_trxn_at = (DateTime) reader["last_trxn_at"]; 
if (reader["purge_cassette1_notes"] != DBNull.Value)
currentCashPosition.purge_cassette1_notes = (int?) reader["purge_cassette1_notes"]; 
if (reader["purge_cassette2_notes"] != DBNull.Value)
currentCashPosition.purge_cassette2_notes = (int?) reader["purge_cassette2_notes"]; 
if (reader["purge_cassette3_notes"] != DBNull.Value)
currentCashPosition.purge_cassette3_notes = (int?) reader["purge_cassette3_notes"]; 
if (reader["purge_cassette4_notes"] != DBNull.Value)
currentCashPosition.purge_cassette4_notes = (int?) reader["purge_cassette4_notes"]; 
if (reader["purge_cassette5_notes"] != DBNull.Value)
currentCashPosition.purge_cassette5_notes = (int?) reader["purge_cassette5_notes"]; 
if (reader["purge_cassette6_notes"] != DBNull.Value)
currentCashPosition.purge_cassette6_notes = (int?) reader["purge_cassette6_notes"]; 
if (reader["purge_cassette7_notes"] != DBNull.Value)
currentCashPosition.purge_cassette7_notes = (int?) reader["purge_cassette7_notes"]; 
} 

currentCashPosition.isNewEntity = false;
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

public CashPosition CurrentCashPosition
{
get{ return currentCashPosition; }
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


#region CashPosition functions

public static CashPositionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.cash_position_id == (Columns.cash_position_id & columns))
qry.Append("cash_position_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.cassette1_notes == (Columns.cassette1_notes & columns))
qry.Append("cassette1_notes,");
if (Columns.cassette2_notes == (Columns.cassette2_notes & columns))
qry.Append("cassette2_notes,");
if (Columns.cassette3_notes == (Columns.cassette3_notes & columns))
qry.Append("cassette3_notes,");
if (Columns.cassette4_notes == (Columns.cassette4_notes & columns))
qry.Append("cassette4_notes,");
if (Columns.cassette5_notes == (Columns.cassette5_notes & columns))
qry.Append("cassette5_notes,");
if (Columns.cassette6_notes == (Columns.cassette6_notes & columns))
qry.Append("cassette6_notes,");
if (Columns.cassette7_notes == (Columns.cassette7_notes & columns))
qry.Append("cassette7_notes,");
if (Columns.task_id == (Columns.task_id & columns))
qry.Append("task_id,");
if (Columns.last_trxn_at == (Columns.last_trxn_at & columns))
qry.Append("last_trxn_at,");
if (Columns.purge_cassette1_notes == (Columns.purge_cassette1_notes & columns))
qry.Append("purge_cassette1_notes,");
if (Columns.purge_cassette2_notes == (Columns.purge_cassette2_notes & columns))
qry.Append("purge_cassette2_notes,");
if (Columns.purge_cassette3_notes == (Columns.purge_cassette3_notes & columns))
qry.Append("purge_cassette3_notes,");
if (Columns.purge_cassette4_notes == (Columns.purge_cassette4_notes & columns))
qry.Append("purge_cassette4_notes,");
if (Columns.purge_cassette5_notes == (Columns.purge_cassette5_notes & columns))
qry.Append("purge_cassette5_notes,");
if (Columns.purge_cassette6_notes == (Columns.purge_cassette6_notes & columns))
qry.Append("purge_cassette6_notes,");
if (Columns.purge_cassette7_notes == (Columns.purge_cassette7_notes & columns))
qry.Append("purge_cassette7_notes,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Cash_position ");

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
return new CashPositionReader(cmd.ExecuteReader(), conn, columns);
}

static public CashPositionReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CashPositionReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select cash_position_id,atm_id,cassette1_notes,cassette2_notes,cassette3_notes,cassette4_notes,cassette5_notes,cassette6_notes,cassette7_notes,task_id,last_trxn_at,purge_cassette1_notes,purge_cassette2_notes,purge_cassette3_notes,purge_cassette4_notes,purge_cassette5_notes,purge_cassette6_notes,purge_cassette7_notes from Cash_position ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CashPositionReader(cmd.ExecuteReader(), conn);
}

static public CashPositionReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CashPosition LoadCashPosition(string where)
{
CashPositionReader reader = CashPosition.ExecuteReader(where);
CashPosition _cashposition = null;
if (reader.Read())
_cashposition = reader.CurrentCashPosition;
reader.Close();
return _cashposition;
}

public static CashPosition LoadCashPosition(string where, IDbConnection conn)
{
CashPositionReader reader = CashPosition.ExecuteReader(where, conn);
CashPosition _cashposition = null;
if (reader.Read())
_cashposition = reader.CurrentCashPosition;
reader.Close(false);
return _cashposition;
}

public static CashPosition LoadCashPositionByPk( int cash_position_id )
{
return LoadCashPosition( " cash_position_id="+cash_position_id );
}

public static CashPosition LoadCashPositionByPk( int cash_position_id , IDbConnection conn)
{
return LoadCashPosition(" cash_position_id="+cash_position_id , conn);
}

public void Save()
{
if (cash_position_idChanged || atm_idChanged || cassette1_notesChanged || cassette2_notesChanged || cassette3_notesChanged || cassette4_notesChanged || cassette5_notesChanged || cassette6_notesChanged || cassette7_notesChanged || task_idChanged || last_trxn_atChanged || purge_cassette1_notesChanged || purge_cassette2_notesChanged || purge_cassette3_notesChanged || purge_cassette4_notesChanged || purge_cassette5_notesChanged || purge_cassette6_notesChanged || purge_cassette7_notesChanged )
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
if (cash_position_idChanged || atm_idChanged || cassette1_notesChanged || cassette2_notesChanged || cassette3_notesChanged || cassette4_notesChanged || cassette5_notesChanged || cassette6_notesChanged || cassette7_notesChanged || task_idChanged || last_trxn_atChanged || purge_cassette1_notesChanged || purge_cassette2_notesChanged || purge_cassette3_notesChanged || purge_cassette4_notesChanged || purge_cassette5_notesChanged || purge_cassette6_notesChanged || purge_cassette7_notesChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Cash_position( cash_position_id,atm_id,cassette1_notes,cassette2_notes,cassette3_notes,cassette4_notes,cassette5_notes,cassette6_notes,cassette7_notes,task_id,last_trxn_at,purge_cassette1_notes,purge_cassette2_notes,purge_cassette3_notes,purge_cassette4_notes,purge_cassette5_notes,purge_cassette6_notes,purge_cassette7_notes ) values(");
lock (ConnectionFactory.connectionString) { this.cash_position_id = ConnectionFactory.GetNextId();
qry.Append(this.cash_position_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(cassette1_notesDbString+",");
qry.Append(cassette2_notesDbString+",");
qry.Append(cassette3_notesDbString+",");
qry.Append(cassette4_notesDbString+",");
qry.Append(cassette5_notesDbString+",");
qry.Append(cassette6_notesDbString+",");
qry.Append(cassette7_notesDbString+",");
qry.Append(task_idDbString+",");
qry.Append(last_trxn_atDbString+",");
qry.Append(purge_cassette1_notesDbString+",");
qry.Append(purge_cassette2_notesDbString+",");
qry.Append(purge_cassette3_notesDbString+",");
qry.Append(purge_cassette4_notesDbString+",");
qry.Append(purge_cassette5_notesDbString+",");
qry.Append(purge_cassette6_notesDbString+",");
qry.Append(purge_cassette7_notesDbString);
qry.Append(");");

}
else
{
if (!(cash_position_idChanged || atm_idChanged || cassette1_notesChanged || cassette2_notesChanged || cassette3_notesChanged || cassette4_notesChanged || cassette5_notesChanged || cassette6_notesChanged || cassette7_notesChanged || task_idChanged || last_trxn_atChanged || purge_cassette1_notesChanged || purge_cassette2_notesChanged || purge_cassette3_notesChanged || purge_cassette4_notesChanged || purge_cassette5_notesChanged || purge_cassette6_notesChanged || purge_cassette7_notesChanged ))
return;
qry.Append("UPDATE Cash_position set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( cassette1_notesChanged )
{
qry.Append("cassette1_notes ="+cassette1_notesDbString);
qry.Append(",");
}

if ( cassette2_notesChanged )
{
qry.Append("cassette2_notes ="+cassette2_notesDbString);
qry.Append(",");
}

if ( cassette3_notesChanged )
{
qry.Append("cassette3_notes ="+cassette3_notesDbString);
qry.Append(",");
}

if ( cassette4_notesChanged )
{
qry.Append("cassette4_notes ="+cassette4_notesDbString);
qry.Append(",");
}

if ( cassette5_notesChanged )
{
qry.Append("cassette5_notes ="+cassette5_notesDbString);
qry.Append(",");
}

if ( cassette6_notesChanged )
{
qry.Append("cassette6_notes ="+cassette6_notesDbString);
qry.Append(",");
}

if ( cassette7_notesChanged )
{
qry.Append("cassette7_notes ="+cassette7_notesDbString);
qry.Append(",");
}

if ( task_idChanged )
{
qry.Append("task_id ="+task_idDbString);
qry.Append(",");
}

if ( last_trxn_atChanged )
{
qry.Append("last_trxn_at ="+last_trxn_atDbString);
qry.Append(",");
}

if ( purge_cassette1_notesChanged )
{
qry.Append("purge_cassette1_notes ="+purge_cassette1_notesDbString);
qry.Append(",");
}

if ( purge_cassette2_notesChanged )
{
qry.Append("purge_cassette2_notes ="+purge_cassette2_notesDbString);
qry.Append(",");
}

if ( purge_cassette3_notesChanged )
{
qry.Append("purge_cassette3_notes ="+purge_cassette3_notesDbString);
qry.Append(",");
}

if ( purge_cassette4_notesChanged )
{
qry.Append("purge_cassette4_notes ="+purge_cassette4_notesDbString);
qry.Append(",");
}

if ( purge_cassette5_notesChanged )
{
qry.Append("purge_cassette5_notes ="+purge_cassette5_notesDbString);
qry.Append(",");
}

if ( purge_cassette6_notesChanged )
{
qry.Append("purge_cassette6_notes ="+purge_cassette6_notesDbString);
qry.Append(",");
}

if ( purge_cassette7_notesChanged )
{
qry.Append("purge_cassette7_notes ="+purge_cassette7_notesDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("cash_position_id = "+cash_position_idDbString);
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
cmd.CommandText = "DELETE Cash_position where cash_position_id = "+ cash_position_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCashPositions(string where)
{
ConnectionFactory.ExecuteQuery("delete Cash_position where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
cash_position_id= 1,
atm_id= 2,
cassette1_notes= 4,
cassette2_notes= 8,
cassette3_notes= 16,
cassette4_notes= 32,
cassette5_notes= 64,
cassette6_notes= 128,
cassette7_notes= 256,
task_id= 512,
last_trxn_at= 1024,
purge_cassette1_notes= 2048,
purge_cassette2_notes= 4096,
purge_cassette3_notes= 8192,
purge_cassette4_notes= 16384,
purge_cassette5_notes= 32768,
purge_cassette6_notes= 65536,
purge_cassette7_notes= 131072
}
#endregion
public void BulkSave(List<CashPosition> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Cash_position";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CashPosition.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CashPosition> transList,ref DataTable dt)
{
foreach (CashPosition tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["cash_position_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["cassette1_notes"] = tran.Cassette1Notes;
Row["cassette2_notes"] = tran.Cassette2Notes;
Row["cassette3_notes"] = tran.Cassette3Notes;
Row["cassette4_notes"] = tran.Cassette4Notes;
Row["cassette5_notes"] = tran.Cassette5Notes;
Row["cassette6_notes"] = tran.Cassette6Notes;
Row["cassette7_notes"] = tran.Cassette7Notes;
Row["task_id"] = tran.TaskId;
Row["last_trxn_at"] = tran.LastTrxnAt;
Row["purge_cassette1_notes"] = tran.PurgeCassette1Notes;
Row["purge_cassette2_notes"] = tran.PurgeCassette2Notes;
Row["purge_cassette3_notes"] = tran.PurgeCassette3Notes;
Row["purge_cassette4_notes"] = tran.PurgeCassette4Notes;
Row["purge_cassette5_notes"] = tran.PurgeCassette5Notes;
Row["purge_cassette6_notes"] = tran.PurgeCassette6Notes;
Row["purge_cassette7_notes"] = tran.PurgeCassette7Notes;
dt.Rows.Add(Row);
} }
}
}
