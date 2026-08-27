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
public class AtmCashPosition
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmCashPosition() { }
public AtmCashPosition( int cash_position_id,int atm_id,int cassette_id,int currency_id,bool is_active ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette_id = cassette_id;
this.cassette_idChanged = true;
this.currency_id = currency_id;
this.currency_idChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}
public AtmCashPosition( int atm_id,int cassette_id,int currency_id,int? currency_denomination,int? notes_remaining,int? notes_rejected,int? notes_dispensed,int? notes_jammed,bool is_active,int? min_threshold )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette_id = cassette_id;
this.cassette_idChanged = true;
this.currency_id = currency_id;
this.currency_idChanged = true;
this.currency_denomination = currency_denomination;
this.currency_denominationChanged = true;
this.notes_remaining = notes_remaining;
this.notes_remainingChanged = true;
this.notes_rejected = notes_rejected;
this.notes_rejectedChanged = true;
this.notes_dispensed = notes_dispensed;
this.notes_dispensedChanged = true;
this.notes_jammed = notes_jammed;
this.notes_jammedChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.min_threshold = min_threshold;
this.min_thresholdChanged = true;
}
private AtmCashPosition( int cash_position_id,int atm_id,int cassette_id,int currency_id,int? currency_denomination,int? notes_remaining,int? notes_rejected,int? notes_dispensed,int? notes_jammed,bool is_active,int? min_threshold )
{
this.cash_position_id = cash_position_id;
this.cash_position_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.cassette_id = cassette_id;
this.cassette_idChanged = true;
this.currency_id = currency_id;
this.currency_idChanged = true;
this.currency_denomination = currency_denomination;
this.currency_denominationChanged = true;
this.notes_remaining = notes_remaining;
this.notes_remainingChanged = true;
this.notes_rejected = notes_rejected;
this.notes_rejectedChanged = true;
this.notes_dispensed = notes_dispensed;
this.notes_dispensedChanged = true;
this.notes_jammed = notes_jammed;
this.notes_jammedChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.min_threshold = min_threshold;
this.min_thresholdChanged = true;
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
#region MinThreshold
private bool min_thresholdChanged = false;
private int? min_threshold;
public int? MinThreshold
{
get { return min_threshold; }
set { 
min_threshold = value;
min_thresholdChanged = true;
}
}
private string min_thresholdDbString
{
get
{
if (this.min_threshold.HasValue)
return min_threshold.ToString();
else
return "null";
}
}
#endregion
#endregion

#region AtmCashPositionReader
public class AtmCashPositionReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmCashPosition currentAtmCashPosition;
Columns columns;
bool partialRead = false;
private AtmCashPositionReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmCashPositionReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmCashPositionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmCashPosition; }

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
currentAtmCashPosition = new AtmCashPosition();
if (partialRead)
{ if ((columns & Columns.cash_position_id) == Columns.cash_position_id && reader["cash_position_id"]!=DBNull.Value)
currentAtmCashPosition.cash_position_id =(int) reader["cash_position_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmCashPosition.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.cassette_id) == Columns.cassette_id && reader["cassette_id"]!=DBNull.Value)
currentAtmCashPosition.cassette_id =(int) reader["cassette_id"]; 
if ((columns & Columns.currency_id) == Columns.currency_id && reader["currency_id"]!=DBNull.Value)
currentAtmCashPosition.currency_id =(int) reader["currency_id"]; 
if ((columns & Columns.currency_denomination) == Columns.currency_denomination && reader["currency_denomination"]!=DBNull.Value)
currentAtmCashPosition.currency_denomination =(int?) reader["currency_denomination"]; 
if ((columns & Columns.notes_remaining) == Columns.notes_remaining && reader["notes_remaining"]!=DBNull.Value)
currentAtmCashPosition.notes_remaining =(int?) reader["notes_remaining"]; 
if ((columns & Columns.notes_rejected) == Columns.notes_rejected && reader["notes_rejected"]!=DBNull.Value)
currentAtmCashPosition.notes_rejected =(int?) reader["notes_rejected"]; 
if ((columns & Columns.notes_dispensed) == Columns.notes_dispensed && reader["notes_dispensed"]!=DBNull.Value)
currentAtmCashPosition.notes_dispensed =(int?) reader["notes_dispensed"]; 
if ((columns & Columns.notes_jammed) == Columns.notes_jammed && reader["notes_jammed"]!=DBNull.Value)
currentAtmCashPosition.notes_jammed =(int?) reader["notes_jammed"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentAtmCashPosition.is_active =(bool) reader["is_active"]; 
if ((columns & Columns.min_threshold) == Columns.min_threshold && reader["min_threshold"]!=DBNull.Value)
currentAtmCashPosition.min_threshold =(int?) reader["min_threshold"]; 

} else
{
if (reader["cash_position_id"] != DBNull.Value)
currentAtmCashPosition.cash_position_id = (int) reader["cash_position_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmCashPosition.atm_id = (int) reader["atm_id"]; 
if (reader["cassette_id"] != DBNull.Value)
currentAtmCashPosition.cassette_id = (int) reader["cassette_id"]; 
if (reader["currency_id"] != DBNull.Value)
currentAtmCashPosition.currency_id = (int) reader["currency_id"]; 
if (reader["currency_denomination"] != DBNull.Value)
currentAtmCashPosition.currency_denomination = (int?) reader["currency_denomination"]; 
if (reader["notes_remaining"] != DBNull.Value)
currentAtmCashPosition.notes_remaining = (int?) reader["notes_remaining"]; 
if (reader["notes_rejected"] != DBNull.Value)
currentAtmCashPosition.notes_rejected = (int?) reader["notes_rejected"]; 
if (reader["notes_dispensed"] != DBNull.Value)
currentAtmCashPosition.notes_dispensed = (int?) reader["notes_dispensed"]; 
if (reader["notes_jammed"] != DBNull.Value)
currentAtmCashPosition.notes_jammed = (int?) reader["notes_jammed"]; 
if (reader["is_active"] != DBNull.Value)
currentAtmCashPosition.is_active = (bool) reader["is_active"]; 
if (reader["min_threshold"] != DBNull.Value)
currentAtmCashPosition.min_threshold = (int?) reader["min_threshold"]; 
} 

currentAtmCashPosition.isNewEntity = false;
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

public AtmCashPosition CurrentAtmCashPosition
{
get{ return currentAtmCashPosition; }
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


#region AtmCashPosition functions

public static AtmCashPositionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.cash_position_id == (Columns.cash_position_id & columns))
qry.Append("cash_position_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.cassette_id == (Columns.cassette_id & columns))
qry.Append("cassette_id,");
if (Columns.currency_id == (Columns.currency_id & columns))
qry.Append("currency_id,");
if (Columns.currency_denomination == (Columns.currency_denomination & columns))
qry.Append("currency_denomination,");
if (Columns.notes_remaining == (Columns.notes_remaining & columns))
qry.Append("notes_remaining,");
if (Columns.notes_rejected == (Columns.notes_rejected & columns))
qry.Append("notes_rejected,");
if (Columns.notes_dispensed == (Columns.notes_dispensed & columns))
qry.Append("notes_dispensed,");
if (Columns.notes_jammed == (Columns.notes_jammed & columns))
qry.Append("notes_jammed,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
if (Columns.min_threshold == (Columns.min_threshold & columns))
qry.Append("min_threshold,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_cash_position ");

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
return new AtmCashPositionReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmCashPositionReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmCashPositionReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select cash_position_id,atm_id,cassette_id,currency_id,currency_denomination,notes_remaining,notes_rejected,notes_dispensed,notes_jammed,is_active,min_threshold from Atm_cash_position ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmCashPositionReader(cmd.ExecuteReader(), conn);
}

static public AtmCashPositionReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmCashPosition LoadAtmCashPosition(string where)
{
AtmCashPositionReader reader = AtmCashPosition.ExecuteReader(where);
AtmCashPosition _atmcashposition = null;
if (reader.Read())
_atmcashposition = reader.CurrentAtmCashPosition;
reader.Close();
return _atmcashposition;
}

public static AtmCashPosition LoadAtmCashPosition(string where, IDbConnection conn)
{
AtmCashPositionReader reader = AtmCashPosition.ExecuteReader(where, conn);
AtmCashPosition _atmcashposition = null;
if (reader.Read())
_atmcashposition = reader.CurrentAtmCashPosition;
reader.Close(false);
return _atmcashposition;
}

public static AtmCashPosition LoadAtmCashPositionByPk( int cash_position_id )
{
return LoadAtmCashPosition( " cash_position_id="+cash_position_id );
}

public static AtmCashPosition LoadAtmCashPositionByPk( int cash_position_id , IDbConnection conn)
{
return LoadAtmCashPosition(" cash_position_id="+cash_position_id , conn);
}

public void Save()
{
if (cash_position_idChanged || atm_idChanged || cassette_idChanged || currency_idChanged || currency_denominationChanged || notes_remainingChanged || notes_rejectedChanged || notes_dispensedChanged || notes_jammedChanged || is_activeChanged || min_thresholdChanged )
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
if (cash_position_idChanged || atm_idChanged || cassette_idChanged || currency_idChanged || currency_denominationChanged || notes_remainingChanged || notes_rejectedChanged || notes_dispensedChanged || notes_jammedChanged || is_activeChanged || min_thresholdChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_cash_position( cash_position_id,atm_id,cassette_id,currency_id,currency_denomination,notes_remaining,notes_rejected,notes_dispensed,notes_jammed,is_active,min_threshold ) values(");
lock (ConnectionFactory.connectionString) { this.cash_position_id = ConnectionFactory.GetNextId();
qry.Append(this.cash_position_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(cassette_idDbString+",");
qry.Append(currency_idDbString+",");
qry.Append(currency_denominationDbString+",");
qry.Append(notes_remainingDbString+",");
qry.Append(notes_rejectedDbString+",");
qry.Append(notes_dispensedDbString+",");
qry.Append(notes_jammedDbString+",");
qry.Append(is_activeDbString+",");
qry.Append(min_thresholdDbString);
qry.Append(");");

}
else
{
if (!(cash_position_idChanged || atm_idChanged || cassette_idChanged || currency_idChanged || currency_denominationChanged || notes_remainingChanged || notes_rejectedChanged || notes_dispensedChanged || notes_jammedChanged || is_activeChanged || min_thresholdChanged ))
return;
qry.Append("UPDATE Atm_cash_position set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( cassette_idChanged )
{
qry.Append("cassette_id ="+cassette_idDbString);
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

if ( notes_dispensedChanged )
{
qry.Append("notes_dispensed ="+notes_dispensedDbString);
qry.Append(",");
}

if ( notes_jammedChanged )
{
qry.Append("notes_jammed ="+notes_jammedDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}

if ( min_thresholdChanged )
{
qry.Append("min_threshold ="+min_thresholdDbString);
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
cmd.CommandText = "DELETE Atm_cash_position where cash_position_id = "+ cash_position_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmCashPositions(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_cash_position where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
cash_position_id= 1,
atm_id= 2,
cassette_id= 4,
currency_id= 8,
currency_denomination= 16,
notes_remaining= 32,
notes_rejected= 64,
notes_dispensed= 128,
notes_jammed= 256,
is_active= 512,
min_threshold= 1024
}
#endregion
public void BulkSave(List<AtmCashPosition> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_cash_position";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmCashPosition.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmCashPosition> transList,ref DataTable dt)
{
foreach (AtmCashPosition tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["cash_position_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["cassette_id"] = tran.CassetteId;
Row["currency_id"] = tran.CurrencyId;
Row["currency_denomination"] = tran.CurrencyDenomination;
Row["notes_remaining"] = tran.NotesRemaining;
Row["notes_rejected"] = tran.NotesRejected;
Row["notes_dispensed"] = tran.NotesDispensed;
Row["notes_jammed"] = tran.NotesJammed;
Row["is_active"] = tran.IsActive;
Row["min_threshold"] = tran.MinThreshold;
dt.Rows.Add(Row);
} }
}
}
