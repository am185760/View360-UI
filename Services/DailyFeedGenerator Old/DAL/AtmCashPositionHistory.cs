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
public class AtmCashPositionHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmCashPositionHistory() { }
public AtmCashPositionHistory( int cash_position_id,int atm_id,int cassette_id,DateTime position_timestamp,int currency_id ) 
{
this.cash_position_id = cash_position_id;
this.cash_position_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette_id = cassette_id;
this.cassette_idChanged = true;
this.position_timestamp = position_timestamp;
this.position_timestampChanged = true;
this.currency_id = currency_id;
this.currency_idChanged = true;
}
public AtmCashPositionHistory( int cash_position_id,int atm_id,int cassette_id,DateTime position_timestamp,int currency_id,int? currency_denomination,int? notes_remaining,int? notes_rejected,int? notes_jammed,int? notes_dispensed )
{
this.cash_position_id = cash_position_id;
this.cash_position_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette_id = cassette_id;
this.cassette_idChanged = true;
this.position_timestamp = position_timestamp;
this.position_timestampChanged = true;
this.currency_id = currency_id;
this.currency_idChanged = true;
this.currency_denomination = currency_denomination;
this.currency_denominationChanged = true;
this.notes_remaining = notes_remaining;
this.notes_remainingChanged = true;
this.notes_rejected = notes_rejected;
this.notes_rejectedChanged = true;
this.notes_jammed = notes_jammed;
this.notes_jammedChanged = true;
this.notes_dispensed = notes_dispensed;
this.notes_dispensedChanged = true;
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
#region CassetteId
private bool cassette_idChanged = false;
private int cassette_id;
public int CassetteId
{
get { return cassette_id; }
set { 
cassette_id = value;
cassette_idChanged = true;
}
}
private string cassette_idDbString
{
get
{
return cassette_id.ToString();
}
}
#endregion
#region PositionTimestamp
private bool position_timestampChanged = false;
private DateTime position_timestamp;
public DateTime PositionTimestamp
{
get { return position_timestamp; }
set { 
position_timestamp = value;
position_timestampChanged = true;
}
}
private string position_timestampDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",position_timestamp.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region CurrencyId
private bool currency_idChanged = false;
private int currency_id;
public int CurrencyId
{
get { return currency_id; }
set { 
currency_id = value;
currency_idChanged = true;
}
}
private string currency_idDbString
{
get
{
return currency_id.ToString();
}
}
#endregion
#region CurrencyDenomination
private bool currency_denominationChanged = false;
private int? currency_denomination;
public int? CurrencyDenomination
{
get { return currency_denomination; }
set { 
currency_denomination = value;
currency_denominationChanged = true;
}
}
private string currency_denominationDbString
{
get
{
if (this.currency_denomination.HasValue)
return currency_denomination.ToString();
else
return "null";
}
}
#endregion
#region NotesRemaining
private bool notes_remainingChanged = false;
private int? notes_remaining;
public int? NotesRemaining
{
get { return notes_remaining; }
set { 
notes_remaining = value;
notes_remainingChanged = true;
}
}
private string notes_remainingDbString
{
get
{
if (this.notes_remaining.HasValue)
return notes_remaining.ToString();
else
return "null";
}
}
#endregion
#region NotesRejected
private bool notes_rejectedChanged = false;
private int? notes_rejected;
public int? NotesRejected
{
get { return notes_rejected; }
set { 
notes_rejected = value;
notes_rejectedChanged = true;
}
}
private string notes_rejectedDbString
{
get
{
if (this.notes_rejected.HasValue)
return notes_rejected.ToString();
else
return "null";
}
}
#endregion
#region NotesJammed
private bool notes_jammedChanged = false;
private int? notes_jammed;
public int? NotesJammed
{
get { return notes_jammed; }
set { 
notes_jammed = value;
notes_jammedChanged = true;
}
}
private string notes_jammedDbString
{
get
{
if (this.notes_jammed.HasValue)
return notes_jammed.ToString();
else
return "null";
}
}
#endregion
#region NotesDispensed
private bool notes_dispensedChanged = false;
private int? notes_dispensed;
public int? NotesDispensed
{
get { return notes_dispensed; }
set { 
notes_dispensed = value;
notes_dispensedChanged = true;
}
}
private string notes_dispensedDbString
{
get
{
if (this.notes_dispensed.HasValue)
return notes_dispensed.ToString();
else
return "null";
}
}
#endregion
#endregion

#region AtmCashPositionHistoryReader
public class AtmCashPositionHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmCashPositionHistory currentAtmCashPositionHistory;
Columns columns;
bool partialRead = false;
private AtmCashPositionHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmCashPositionHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmCashPositionHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmCashPositionHistory; }

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
currentAtmCashPositionHistory = new AtmCashPositionHistory();
if (partialRead)
{ if ((columns & Columns.cash_position_id) == Columns.cash_position_id && reader["cash_position_id"]!=DBNull.Value)
currentAtmCashPositionHistory.cash_position_id =(int) reader["cash_position_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmCashPositionHistory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.cassette_id) == Columns.cassette_id && reader["cassette_id"]!=DBNull.Value)
currentAtmCashPositionHistory.cassette_id =(int) reader["cassette_id"]; 
if ((columns & Columns.position_timestamp) == Columns.position_timestamp && reader["position_timestamp"]!=DBNull.Value)
currentAtmCashPositionHistory.position_timestamp =(DateTime) reader["position_timestamp"]; 
if ((columns & Columns.currency_id) == Columns.currency_id && reader["currency_id"]!=DBNull.Value)
currentAtmCashPositionHistory.currency_id =(int) reader["currency_id"]; 
if ((columns & Columns.currency_denomination) == Columns.currency_denomination && reader["currency_denomination"]!=DBNull.Value)
currentAtmCashPositionHistory.currency_denomination =(int?) reader["currency_denomination"]; 
if ((columns & Columns.notes_remaining) == Columns.notes_remaining && reader["notes_remaining"]!=DBNull.Value)
currentAtmCashPositionHistory.notes_remaining =(int?) reader["notes_remaining"]; 
if ((columns & Columns.notes_rejected) == Columns.notes_rejected && reader["notes_rejected"]!=DBNull.Value)
currentAtmCashPositionHistory.notes_rejected =(int?) reader["notes_rejected"]; 
if ((columns & Columns.notes_jammed) == Columns.notes_jammed && reader["notes_jammed"]!=DBNull.Value)
currentAtmCashPositionHistory.notes_jammed =(int?) reader["notes_jammed"]; 
if ((columns & Columns.notes_dispensed) == Columns.notes_dispensed && reader["notes_dispensed"]!=DBNull.Value)
currentAtmCashPositionHistory.notes_dispensed =(int?) reader["notes_dispensed"]; 

} else
{
if (reader["cash_position_id"] != DBNull.Value)
currentAtmCashPositionHistory.cash_position_id = (int) reader["cash_position_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmCashPositionHistory.atm_id = (int) reader["atm_id"]; 
if (reader["cassette_id"] != DBNull.Value)
currentAtmCashPositionHistory.cassette_id = (int) reader["cassette_id"]; 
if (reader["position_timestamp"] != DBNull.Value)
currentAtmCashPositionHistory.position_timestamp = (DateTime) reader["position_timestamp"]; 
if (reader["currency_id"] != DBNull.Value)
currentAtmCashPositionHistory.currency_id = (int) reader["currency_id"]; 
if (reader["currency_denomination"] != DBNull.Value)
currentAtmCashPositionHistory.currency_denomination = (int?) reader["currency_denomination"]; 
if (reader["notes_remaining"] != DBNull.Value)
currentAtmCashPositionHistory.notes_remaining = (int?) reader["notes_remaining"]; 
if (reader["notes_rejected"] != DBNull.Value)
currentAtmCashPositionHistory.notes_rejected = (int?) reader["notes_rejected"]; 
if (reader["notes_jammed"] != DBNull.Value)
currentAtmCashPositionHistory.notes_jammed = (int?) reader["notes_jammed"]; 
if (reader["notes_dispensed"] != DBNull.Value)
currentAtmCashPositionHistory.notes_dispensed = (int?) reader["notes_dispensed"]; 
} 

currentAtmCashPositionHistory.isNewEntity = false;
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

public AtmCashPositionHistory CurrentAtmCashPositionHistory
{
get{ return currentAtmCashPositionHistory; }
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


#region AtmCashPositionHistory functions

public static AtmCashPositionHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.cash_position_id == (Columns.cash_position_id & columns))
qry.Append("cash_position_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.cassette_id == (Columns.cassette_id & columns))
qry.Append("cassette_id,");
if (Columns.position_timestamp == (Columns.position_timestamp & columns))
qry.Append("position_timestamp,");
if (Columns.currency_id == (Columns.currency_id & columns))
qry.Append("currency_id,");
if (Columns.currency_denomination == (Columns.currency_denomination & columns))
qry.Append("currency_denomination,");
if (Columns.notes_remaining == (Columns.notes_remaining & columns))
qry.Append("notes_remaining,");
if (Columns.notes_rejected == (Columns.notes_rejected & columns))
qry.Append("notes_rejected,");
if (Columns.notes_jammed == (Columns.notes_jammed & columns))
qry.Append("notes_jammed,");
if (Columns.notes_dispensed == (Columns.notes_dispensed & columns))
qry.Append("notes_dispensed,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_cash_position_history ");

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
return new AtmCashPositionHistoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmCashPositionHistoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmCashPositionHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select cash_position_id,atm_id,cassette_id,position_timestamp,currency_id,currency_denomination,notes_remaining,notes_rejected,notes_jammed,notes_dispensed from Atm_cash_position_history ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmCashPositionHistoryReader(cmd.ExecuteReader(), conn);
}

static public AtmCashPositionHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmCashPositionHistory LoadAtmCashPositionHistory(string where)
{
AtmCashPositionHistoryReader reader = AtmCashPositionHistory.ExecuteReader(where);
AtmCashPositionHistory _atmcashpositionhistory = null;
if (reader.Read())
_atmcashpositionhistory = reader.CurrentAtmCashPositionHistory;
reader.Close();
return _atmcashpositionhistory;
}

public static AtmCashPositionHistory LoadAtmCashPositionHistory(string where, IDbConnection conn)
{
AtmCashPositionHistoryReader reader = AtmCashPositionHistory.ExecuteReader(where, conn);
AtmCashPositionHistory _atmcashpositionhistory = null;
if (reader.Read())
_atmcashpositionhistory = reader.CurrentAtmCashPositionHistory;
reader.Close(false);
return _atmcashpositionhistory;
}

public static AtmCashPositionHistory LoadAtmCashPositionHistoryByPk( int cash_position_id )
{
return LoadAtmCashPositionHistory( " cash_position_id="+cash_position_id );
}

public static AtmCashPositionHistory LoadAtmCashPositionHistoryByPk( int cash_position_id , IDbConnection conn)
{
return LoadAtmCashPositionHistory(" cash_position_id="+cash_position_id , conn);
}

public void Save()
{
if (cash_position_idChanged || atm_idChanged || cassette_idChanged || position_timestampChanged || currency_idChanged || currency_denominationChanged || notes_remainingChanged || notes_rejectedChanged || notes_jammedChanged || notes_dispensedChanged )
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
if (cash_position_idChanged || atm_idChanged || cassette_idChanged || position_timestampChanged || currency_idChanged || currency_denominationChanged || notes_remainingChanged || notes_rejectedChanged || notes_jammedChanged || notes_dispensedChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_cash_position_history( cash_position_id,atm_id,cassette_id,position_timestamp,currency_id,currency_denomination,notes_remaining,notes_rejected,notes_jammed,notes_dispensed ) values(");
qry.Append(cash_position_idDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(cassette_idDbString+",");
qry.Append(position_timestampDbString+",");
qry.Append(currency_idDbString+",");
qry.Append(currency_denominationDbString+",");
qry.Append(notes_remainingDbString+",");
qry.Append(notes_rejectedDbString+",");
qry.Append(notes_jammedDbString+",");
qry.Append(notes_dispensedDbString);
qry.Append(");");

}
else
{
if (!(cash_position_idChanged || atm_idChanged || cassette_idChanged || position_timestampChanged || currency_idChanged || currency_denominationChanged || notes_remainingChanged || notes_rejectedChanged || notes_jammedChanged || notes_dispensedChanged ))
return;
qry.Append("UPDATE Atm_cash_position_history set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( cassette_idChanged )
{
qry.Append("cassette_id ="+cassette_idDbString);
qry.Append(",");
}

if ( position_timestampChanged )
{
qry.Append("position_timestamp ="+position_timestampDbString);
qry.Append(",");
}

if ( currency_idChanged )
{
qry.Append("currency_id ="+currency_idDbString);
qry.Append(",");
}

if ( currency_denominationChanged )
{
qry.Append("currency_denomination ="+currency_denominationDbString);
qry.Append(",");
}

if ( notes_remainingChanged )
{
qry.Append("notes_remaining ="+notes_remainingDbString);
qry.Append(",");
}

if ( notes_rejectedChanged )
{
qry.Append("notes_rejected ="+notes_rejectedDbString);
qry.Append(",");
}

if ( notes_jammedChanged )
{
qry.Append("notes_jammed ="+notes_jammedDbString);
qry.Append(",");
}

if ( notes_dispensedChanged )
{
qry.Append("notes_dispensed ="+notes_dispensedDbString);
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
cmd.CommandText = "DELETE Atm_cash_position_history where cash_position_id = "+ cash_position_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmCashPositionHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_cash_position_history where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
cash_position_id= 1,
atm_id= 2,
cassette_id= 4,
position_timestamp= 8,
currency_id= 16,
currency_denomination= 32,
notes_remaining= 64,
notes_rejected= 128,
notes_jammed= 256,
notes_dispensed= 512
}
#endregion
public void BulkSave(List<AtmCashPositionHistory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_cash_position_history";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmCashPositionHistory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmCashPositionHistory> transList,ref DataTable dt)
{
foreach (AtmCashPositionHistory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["cash_position_id"] = tran.CashPositionId;
Row["atm_id"] = tran.AtmId;
Row["cassette_id"] = tran.CassetteId;
Row["position_timestamp"] = tran.PositionTimestamp;
Row["currency_id"] = tran.CurrencyId;
Row["currency_denomination"] = tran.CurrencyDenomination;
Row["notes_remaining"] = tran.NotesRemaining;
Row["notes_rejected"] = tran.NotesRejected;
Row["notes_jammed"] = tran.NotesJammed;
Row["notes_dispensed"] = tran.NotesDispensed;
dt.Rows.Add(Row);
} }
}
}
