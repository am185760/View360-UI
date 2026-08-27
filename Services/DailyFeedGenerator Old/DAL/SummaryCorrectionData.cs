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
public class SummaryCorrectionData
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SummaryCorrectionData() { }
public SummaryCorrectionData( int atm_id,int notes_remaining1,int notes_remaining2,int notes_remaining3,int notes_remaining4,int notes_dispensed1,int notes_dispensed2,int notes_dispensed3,int notes_dispensed4,int notes_rejected1,int notes_rejected2,int notes_rejected3,int notes_rejected4,int modified_by,DateTime modified_datetime,DateTime rep_datetime,int atm_settlement_id )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.notes_remaining1 = notes_remaining1;
this.notes_remaining1Changed = true;
this.notes_remaining2 = notes_remaining2;
this.notes_remaining2Changed = true;
this.notes_remaining3 = notes_remaining3;
this.notes_remaining3Changed = true;
this.notes_remaining4 = notes_remaining4;
this.notes_remaining4Changed = true;
this.notes_dispensed1 = notes_dispensed1;
this.notes_dispensed1Changed = true;
this.notes_dispensed2 = notes_dispensed2;
this.notes_dispensed2Changed = true;
this.notes_dispensed3 = notes_dispensed3;
this.notes_dispensed3Changed = true;
this.notes_dispensed4 = notes_dispensed4;
this.notes_dispensed4Changed = true;
this.notes_rejected1 = notes_rejected1;
this.notes_rejected1Changed = true;
this.notes_rejected2 = notes_rejected2;
this.notes_rejected2Changed = true;
this.notes_rejected3 = notes_rejected3;
this.notes_rejected3Changed = true;
this.notes_rejected4 = notes_rejected4;
this.notes_rejected4Changed = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_datetime = modified_datetime;
this.modified_datetimeChanged = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
}
private SummaryCorrectionData( int summary_correction_data_id,int atm_id,int notes_remaining1,int notes_remaining2,int notes_remaining3,int notes_remaining4,int notes_dispensed1,int notes_dispensed2,int notes_dispensed3,int notes_dispensed4,int notes_rejected1,int notes_rejected2,int notes_rejected3,int notes_rejected4,int modified_by,DateTime modified_datetime,DateTime rep_datetime,int atm_settlement_id )
{
this.summary_correction_data_id = summary_correction_data_id;
this.summary_correction_data_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.notes_remaining1 = notes_remaining1;
this.notes_remaining1Changed = true;
this.notes_remaining2 = notes_remaining2;
this.notes_remaining2Changed = true;
this.notes_remaining3 = notes_remaining3;
this.notes_remaining3Changed = true;
this.notes_remaining4 = notes_remaining4;
this.notes_remaining4Changed = true;
this.notes_dispensed1 = notes_dispensed1;
this.notes_dispensed1Changed = true;
this.notes_dispensed2 = notes_dispensed2;
this.notes_dispensed2Changed = true;
this.notes_dispensed3 = notes_dispensed3;
this.notes_dispensed3Changed = true;
this.notes_dispensed4 = notes_dispensed4;
this.notes_dispensed4Changed = true;
this.notes_rejected1 = notes_rejected1;
this.notes_rejected1Changed = true;
this.notes_rejected2 = notes_rejected2;
this.notes_rejected2Changed = true;
this.notes_rejected3 = notes_rejected3;
this.notes_rejected3Changed = true;
this.notes_rejected4 = notes_rejected4;
this.notes_rejected4Changed = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_datetime = modified_datetime;
this.modified_datetimeChanged = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
}

#region members and properties for columns

#region SummaryCorrectionDataId
private bool summary_correction_data_idChanged = false;
private int summary_correction_data_id;
public int SummaryCorrectionDataId
{
get { return summary_correction_data_id; }
set { 
summary_correction_data_id = value;
summary_correction_data_idChanged = true;
}
}
private string summary_correction_data_idDbString
{
get
{
return summary_correction_data_id.ToString();
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
#region NotesRemaining1
private bool notes_remaining1Changed = false;
private int notes_remaining1;
public int NotesRemaining1
{
get { return notes_remaining1; }
set { 
notes_remaining1 = value;
notes_remaining1Changed = true;
}
}
private string notes_remaining1DbString
{
get
{
return notes_remaining1.ToString();
}
}
#endregion
#region NotesRemaining2
private bool notes_remaining2Changed = false;
private int notes_remaining2;
public int NotesRemaining2
{
get { return notes_remaining2; }
set { 
notes_remaining2 = value;
notes_remaining2Changed = true;
}
}
private string notes_remaining2DbString
{
get
{
return notes_remaining2.ToString();
}
}
#endregion
#region NotesRemaining3
private bool notes_remaining3Changed = false;
private int notes_remaining3;
public int NotesRemaining3
{
get { return notes_remaining3; }
set { 
notes_remaining3 = value;
notes_remaining3Changed = true;
}
}
private string notes_remaining3DbString
{
get
{
return notes_remaining3.ToString();
}
}
#endregion
#region NotesRemaining4
private bool notes_remaining4Changed = false;
private int notes_remaining4;
public int NotesRemaining4
{
get { return notes_remaining4; }
set { 
notes_remaining4 = value;
notes_remaining4Changed = true;
}
}
private string notes_remaining4DbString
{
get
{
return notes_remaining4.ToString();
}
}
#endregion
#region NotesDispensed1
private bool notes_dispensed1Changed = false;
private int notes_dispensed1;
public int NotesDispensed1
{
get { return notes_dispensed1; }
set { 
notes_dispensed1 = value;
notes_dispensed1Changed = true;
}
}
private string notes_dispensed1DbString
{
get
{
return notes_dispensed1.ToString();
}
}
#endregion
#region NotesDispensed2
private bool notes_dispensed2Changed = false;
private int notes_dispensed2;
public int NotesDispensed2
{
get { return notes_dispensed2; }
set { 
notes_dispensed2 = value;
notes_dispensed2Changed = true;
}
}
private string notes_dispensed2DbString
{
get
{
return notes_dispensed2.ToString();
}
}
#endregion
#region NotesDispensed3
private bool notes_dispensed3Changed = false;
private int notes_dispensed3;
public int NotesDispensed3
{
get { return notes_dispensed3; }
set { 
notes_dispensed3 = value;
notes_dispensed3Changed = true;
}
}
private string notes_dispensed3DbString
{
get
{
return notes_dispensed3.ToString();
}
}
#endregion
#region NotesDispensed4
private bool notes_dispensed4Changed = false;
private int notes_dispensed4;
public int NotesDispensed4
{
get { return notes_dispensed4; }
set { 
notes_dispensed4 = value;
notes_dispensed4Changed = true;
}
}
private string notes_dispensed4DbString
{
get
{
return notes_dispensed4.ToString();
}
}
#endregion
#region NotesRejected1
private bool notes_rejected1Changed = false;
private int notes_rejected1;
public int NotesRejected1
{
get { return notes_rejected1; }
set { 
notes_rejected1 = value;
notes_rejected1Changed = true;
}
}
private string notes_rejected1DbString
{
get
{
return notes_rejected1.ToString();
}
}
#endregion
#region NotesRejected2
private bool notes_rejected2Changed = false;
private int notes_rejected2;
public int NotesRejected2
{
get { return notes_rejected2; }
set { 
notes_rejected2 = value;
notes_rejected2Changed = true;
}
}
private string notes_rejected2DbString
{
get
{
return notes_rejected2.ToString();
}
}
#endregion
#region NotesRejected3
private bool notes_rejected3Changed = false;
private int notes_rejected3;
public int NotesRejected3
{
get { return notes_rejected3; }
set { 
notes_rejected3 = value;
notes_rejected3Changed = true;
}
}
private string notes_rejected3DbString
{
get
{
return notes_rejected3.ToString();
}
}
#endregion
#region NotesRejected4
private bool notes_rejected4Changed = false;
private int notes_rejected4;
public int NotesRejected4
{
get { return notes_rejected4; }
set { 
notes_rejected4 = value;
notes_rejected4Changed = true;
}
}
private string notes_rejected4DbString
{
get
{
return notes_rejected4.ToString();
}
}
#endregion
#region ModifiedBy
private bool modified_byChanged = false;
private int modified_by;
public int ModifiedBy
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
return modified_by.ToString();
}
}
#endregion
#region ModifiedDatetime
private bool modified_datetimeChanged = false;
private DateTime modified_datetime;
public DateTime ModifiedDatetime
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
return string.Format("Convert(datetime,'{0}',121)",modified_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region AtmSettlementId
private bool atm_settlement_idChanged = false;
private int atm_settlement_id;
public int AtmSettlementId
{
get { return atm_settlement_id; }
set { 
atm_settlement_id = value;
atm_settlement_idChanged = true;
}
}
private string atm_settlement_idDbString
{
get
{
return atm_settlement_id.ToString();
}
}
#endregion
#endregion

#region SummaryCorrectionDataReader
public class SummaryCorrectionDataReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SummaryCorrectionData currentSummaryCorrectionData;
Columns columns;
bool partialRead = false;
private SummaryCorrectionDataReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SummaryCorrectionDataReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SummaryCorrectionDataReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSummaryCorrectionData; }

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
currentSummaryCorrectionData = new SummaryCorrectionData();
if (partialRead)
{ if ((columns & Columns.summary_correction_data_id) == Columns.summary_correction_data_id && reader["summary_correction_data_id"]!=DBNull.Value)
currentSummaryCorrectionData.summary_correction_data_id =(int) reader["summary_correction_data_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentSummaryCorrectionData.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.notes_remaining1) == Columns.notes_remaining1 && reader["notes_remaining1"]!=DBNull.Value)
currentSummaryCorrectionData.notes_remaining1 =(int) reader["notes_remaining1"]; 
if ((columns & Columns.notes_remaining2) == Columns.notes_remaining2 && reader["notes_remaining2"]!=DBNull.Value)
currentSummaryCorrectionData.notes_remaining2 =(int) reader["notes_remaining2"]; 
if ((columns & Columns.notes_remaining3) == Columns.notes_remaining3 && reader["notes_remaining3"]!=DBNull.Value)
currentSummaryCorrectionData.notes_remaining3 =(int) reader["notes_remaining3"]; 
if ((columns & Columns.notes_remaining4) == Columns.notes_remaining4 && reader["notes_remaining4"]!=DBNull.Value)
currentSummaryCorrectionData.notes_remaining4 =(int) reader["notes_remaining4"]; 
if ((columns & Columns.notes_dispensed1) == Columns.notes_dispensed1 && reader["notes_dispensed1"]!=DBNull.Value)
currentSummaryCorrectionData.notes_dispensed1 =(int) reader["notes_dispensed1"]; 
if ((columns & Columns.notes_dispensed2) == Columns.notes_dispensed2 && reader["notes_dispensed2"]!=DBNull.Value)
currentSummaryCorrectionData.notes_dispensed2 =(int) reader["notes_dispensed2"]; 
if ((columns & Columns.notes_dispensed3) == Columns.notes_dispensed3 && reader["notes_dispensed3"]!=DBNull.Value)
currentSummaryCorrectionData.notes_dispensed3 =(int) reader["notes_dispensed3"]; 
if ((columns & Columns.notes_dispensed4) == Columns.notes_dispensed4 && reader["notes_dispensed4"]!=DBNull.Value)
currentSummaryCorrectionData.notes_dispensed4 =(int) reader["notes_dispensed4"]; 
if ((columns & Columns.notes_rejected1) == Columns.notes_rejected1 && reader["notes_rejected1"]!=DBNull.Value)
currentSummaryCorrectionData.notes_rejected1 =(int) reader["notes_rejected1"]; 
if ((columns & Columns.notes_rejected2) == Columns.notes_rejected2 && reader["notes_rejected2"]!=DBNull.Value)
currentSummaryCorrectionData.notes_rejected2 =(int) reader["notes_rejected2"]; 
if ((columns & Columns.notes_rejected3) == Columns.notes_rejected3 && reader["notes_rejected3"]!=DBNull.Value)
currentSummaryCorrectionData.notes_rejected3 =(int) reader["notes_rejected3"]; 
if ((columns & Columns.notes_rejected4) == Columns.notes_rejected4 && reader["notes_rejected4"]!=DBNull.Value)
currentSummaryCorrectionData.notes_rejected4 =(int) reader["notes_rejected4"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentSummaryCorrectionData.modified_by =(int) reader["modified_by"]; 
if ((columns & Columns.modified_datetime) == Columns.modified_datetime && reader["modified_datetime"]!=DBNull.Value)
currentSummaryCorrectionData.modified_datetime =(DateTime) reader["modified_datetime"]; 
if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"]!=DBNull.Value)
currentSummaryCorrectionData.rep_datetime =(DateTime) reader["rep_datetime"]; 
if ((columns & Columns.atm_settlement_id) == Columns.atm_settlement_id && reader["atm_settlement_id"]!=DBNull.Value)
currentSummaryCorrectionData.atm_settlement_id =(int) reader["atm_settlement_id"]; 

} else
{
if (reader["summary_correction_data_id"] != DBNull.Value)
currentSummaryCorrectionData.summary_correction_data_id = (int) reader["summary_correction_data_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentSummaryCorrectionData.atm_id = (int) reader["atm_id"]; 
if (reader["notes_remaining1"] != DBNull.Value)
currentSummaryCorrectionData.notes_remaining1 = (int) reader["notes_remaining1"]; 
if (reader["notes_remaining2"] != DBNull.Value)
currentSummaryCorrectionData.notes_remaining2 = (int) reader["notes_remaining2"]; 
if (reader["notes_remaining3"] != DBNull.Value)
currentSummaryCorrectionData.notes_remaining3 = (int) reader["notes_remaining3"]; 
if (reader["notes_remaining4"] != DBNull.Value)
currentSummaryCorrectionData.notes_remaining4 = (int) reader["notes_remaining4"]; 
if (reader["notes_dispensed1"] != DBNull.Value)
currentSummaryCorrectionData.notes_dispensed1 = (int) reader["notes_dispensed1"]; 
if (reader["notes_dispensed2"] != DBNull.Value)
currentSummaryCorrectionData.notes_dispensed2 = (int) reader["notes_dispensed2"]; 
if (reader["notes_dispensed3"] != DBNull.Value)
currentSummaryCorrectionData.notes_dispensed3 = (int) reader["notes_dispensed3"]; 
if (reader["notes_dispensed4"] != DBNull.Value)
currentSummaryCorrectionData.notes_dispensed4 = (int) reader["notes_dispensed4"]; 
if (reader["notes_rejected1"] != DBNull.Value)
currentSummaryCorrectionData.notes_rejected1 = (int) reader["notes_rejected1"]; 
if (reader["notes_rejected2"] != DBNull.Value)
currentSummaryCorrectionData.notes_rejected2 = (int) reader["notes_rejected2"]; 
if (reader["notes_rejected3"] != DBNull.Value)
currentSummaryCorrectionData.notes_rejected3 = (int) reader["notes_rejected3"]; 
if (reader["notes_rejected4"] != DBNull.Value)
currentSummaryCorrectionData.notes_rejected4 = (int) reader["notes_rejected4"]; 
if (reader["modified_by"] != DBNull.Value)
currentSummaryCorrectionData.modified_by = (int) reader["modified_by"]; 
if (reader["modified_datetime"] != DBNull.Value)
currentSummaryCorrectionData.modified_datetime = (DateTime) reader["modified_datetime"]; 
if (reader["rep_datetime"] != DBNull.Value)
currentSummaryCorrectionData.rep_datetime = (DateTime) reader["rep_datetime"]; 
if (reader["atm_settlement_id"] != DBNull.Value)
currentSummaryCorrectionData.atm_settlement_id = (int) reader["atm_settlement_id"]; 
} 

currentSummaryCorrectionData.isNewEntity = false;
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

public SummaryCorrectionData CurrentSummaryCorrectionData
{
get{ return currentSummaryCorrectionData; }
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


#region SummaryCorrectionData functions

public static SummaryCorrectionDataReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.summary_correction_data_id == (Columns.summary_correction_data_id & columns))
qry.Append("summary_correction_data_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.notes_remaining1 == (Columns.notes_remaining1 & columns))
qry.Append("notes_remaining1,");
if (Columns.notes_remaining2 == (Columns.notes_remaining2 & columns))
qry.Append("notes_remaining2,");
if (Columns.notes_remaining3 == (Columns.notes_remaining3 & columns))
qry.Append("notes_remaining3,");
if (Columns.notes_remaining4 == (Columns.notes_remaining4 & columns))
qry.Append("notes_remaining4,");
if (Columns.notes_dispensed1 == (Columns.notes_dispensed1 & columns))
qry.Append("notes_dispensed1,");
if (Columns.notes_dispensed2 == (Columns.notes_dispensed2 & columns))
qry.Append("notes_dispensed2,");
if (Columns.notes_dispensed3 == (Columns.notes_dispensed3 & columns))
qry.Append("notes_dispensed3,");
if (Columns.notes_dispensed4 == (Columns.notes_dispensed4 & columns))
qry.Append("notes_dispensed4,");
if (Columns.notes_rejected1 == (Columns.notes_rejected1 & columns))
qry.Append("notes_rejected1,");
if (Columns.notes_rejected2 == (Columns.notes_rejected2 & columns))
qry.Append("notes_rejected2,");
if (Columns.notes_rejected3 == (Columns.notes_rejected3 & columns))
qry.Append("notes_rejected3,");
if (Columns.notes_rejected4 == (Columns.notes_rejected4 & columns))
qry.Append("notes_rejected4,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.modified_datetime == (Columns.modified_datetime & columns))
qry.Append("modified_datetime,");
if (Columns.rep_datetime == (Columns.rep_datetime & columns))
qry.Append("rep_datetime,");
if (Columns.atm_settlement_id == (Columns.atm_settlement_id & columns))
qry.Append("atm_settlement_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Summary_correction_data ");

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
return new SummaryCorrectionDataReader(cmd.ExecuteReader(), conn, columns);
}

static public SummaryCorrectionDataReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SummaryCorrectionDataReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select summary_correction_data_id,atm_id,notes_remaining1,notes_remaining2,notes_remaining3,notes_remaining4,notes_dispensed1,notes_dispensed2,notes_dispensed3,notes_dispensed4,notes_rejected1,notes_rejected2,notes_rejected3,notes_rejected4,modified_by,modified_datetime,rep_datetime,atm_settlement_id from Summary_correction_data ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SummaryCorrectionDataReader(cmd.ExecuteReader(), conn);
}

static public SummaryCorrectionDataReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SummaryCorrectionData LoadSummaryCorrectionData(string where)
{
SummaryCorrectionDataReader reader = SummaryCorrectionData.ExecuteReader(where);
SummaryCorrectionData _summarycorrectiondata = null;
if (reader.Read())
_summarycorrectiondata = reader.CurrentSummaryCorrectionData;
reader.Close();
return _summarycorrectiondata;
}

public static SummaryCorrectionData LoadSummaryCorrectionData(string where, IDbConnection conn)
{
SummaryCorrectionDataReader reader = SummaryCorrectionData.ExecuteReader(where, conn);
SummaryCorrectionData _summarycorrectiondata = null;
if (reader.Read())
_summarycorrectiondata = reader.CurrentSummaryCorrectionData;
reader.Close(false);
return _summarycorrectiondata;
}

public static SummaryCorrectionData LoadSummaryCorrectionDataByPk( int summary_correction_data_id )
{
return LoadSummaryCorrectionData( " summary_correction_data_id="+summary_correction_data_id );
}

public static SummaryCorrectionData LoadSummaryCorrectionDataByPk( int summary_correction_data_id , IDbConnection conn)
{
return LoadSummaryCorrectionData(" summary_correction_data_id="+summary_correction_data_id , conn);
}

public void Save()
{
if (summary_correction_data_idChanged || atm_idChanged || notes_remaining1Changed || notes_remaining2Changed || notes_remaining3Changed || notes_remaining4Changed || notes_dispensed1Changed || notes_dispensed2Changed || notes_dispensed3Changed || notes_dispensed4Changed || notes_rejected1Changed || notes_rejected2Changed || notes_rejected3Changed || notes_rejected4Changed || modified_byChanged || modified_datetimeChanged || rep_datetimeChanged || atm_settlement_idChanged )
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
if (summary_correction_data_idChanged || atm_idChanged || notes_remaining1Changed || notes_remaining2Changed || notes_remaining3Changed || notes_remaining4Changed || notes_dispensed1Changed || notes_dispensed2Changed || notes_dispensed3Changed || notes_dispensed4Changed || notes_rejected1Changed || notes_rejected2Changed || notes_rejected3Changed || notes_rejected4Changed || modified_byChanged || modified_datetimeChanged || rep_datetimeChanged || atm_settlement_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Summary_correction_data( summary_correction_data_id,atm_id,notes_remaining1,notes_remaining2,notes_remaining3,notes_remaining4,notes_dispensed1,notes_dispensed2,notes_dispensed3,notes_dispensed4,notes_rejected1,notes_rejected2,notes_rejected3,notes_rejected4,modified_by,modified_datetime,rep_datetime,atm_settlement_id ) values(");
lock (ConnectionFactory.connectionString) { this.summary_correction_data_id = ConnectionFactory.GetNextId();
qry.Append(this.summary_correction_data_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(notes_remaining1DbString+",");
qry.Append(notes_remaining2DbString+",");
qry.Append(notes_remaining3DbString+",");
qry.Append(notes_remaining4DbString+",");
qry.Append(notes_dispensed1DbString+",");
qry.Append(notes_dispensed2DbString+",");
qry.Append(notes_dispensed3DbString+",");
qry.Append(notes_dispensed4DbString+",");
qry.Append(notes_rejected1DbString+",");
qry.Append(notes_rejected2DbString+",");
qry.Append(notes_rejected3DbString+",");
qry.Append(notes_rejected4DbString+",");
qry.Append(modified_byDbString+",");
qry.Append(modified_datetimeDbString+",");
qry.Append(rep_datetimeDbString+",");
qry.Append(atm_settlement_idDbString);
qry.Append(");");

}
else
{
if (!(summary_correction_data_idChanged || atm_idChanged || notes_remaining1Changed || notes_remaining2Changed || notes_remaining3Changed || notes_remaining4Changed || notes_dispensed1Changed || notes_dispensed2Changed || notes_dispensed3Changed || notes_dispensed4Changed || notes_rejected1Changed || notes_rejected2Changed || notes_rejected3Changed || notes_rejected4Changed || modified_byChanged || modified_datetimeChanged || rep_datetimeChanged || atm_settlement_idChanged ))
return;
qry.Append("UPDATE Summary_correction_data set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( notes_remaining1Changed )
{
qry.Append("notes_remaining1 ="+notes_remaining1DbString);
qry.Append(",");
}

if ( notes_remaining2Changed )
{
qry.Append("notes_remaining2 ="+notes_remaining2DbString);
qry.Append(",");
}

if ( notes_remaining3Changed )
{
qry.Append("notes_remaining3 ="+notes_remaining3DbString);
qry.Append(",");
}

if ( notes_remaining4Changed )
{
qry.Append("notes_remaining4 ="+notes_remaining4DbString);
qry.Append(",");
}

if ( notes_dispensed1Changed )
{
qry.Append("notes_dispensed1 ="+notes_dispensed1DbString);
qry.Append(",");
}

if ( notes_dispensed2Changed )
{
qry.Append("notes_dispensed2 ="+notes_dispensed2DbString);
qry.Append(",");
}

if ( notes_dispensed3Changed )
{
qry.Append("notes_dispensed3 ="+notes_dispensed3DbString);
qry.Append(",");
}

if ( notes_dispensed4Changed )
{
qry.Append("notes_dispensed4 ="+notes_dispensed4DbString);
qry.Append(",");
}

if ( notes_rejected1Changed )
{
qry.Append("notes_rejected1 ="+notes_rejected1DbString);
qry.Append(",");
}

if ( notes_rejected2Changed )
{
qry.Append("notes_rejected2 ="+notes_rejected2DbString);
qry.Append(",");
}

if ( notes_rejected3Changed )
{
qry.Append("notes_rejected3 ="+notes_rejected3DbString);
qry.Append(",");
}

if ( notes_rejected4Changed )
{
qry.Append("notes_rejected4 ="+notes_rejected4DbString);
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

if ( rep_datetimeChanged )
{
qry.Append("rep_datetime ="+rep_datetimeDbString);
qry.Append(",");
}

if ( atm_settlement_idChanged )
{
qry.Append("atm_settlement_id ="+atm_settlement_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("summary_correction_data_id = "+summary_correction_data_idDbString);
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
cmd.CommandText = "DELETE Summary_correction_data where summary_correction_data_id = "+ summary_correction_data_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteSummaryCorrectionDatas(string where)
{
ConnectionFactory.ExecuteQuery("delete Summary_correction_data where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
summary_correction_data_id= 1,
atm_id= 2,
notes_remaining1= 4,
notes_remaining2= 8,
notes_remaining3= 16,
notes_remaining4= 32,
notes_dispensed1= 64,
notes_dispensed2= 128,
notes_dispensed3= 256,
notes_dispensed4= 512,
notes_rejected1= 1024,
notes_rejected2= 2048,
notes_rejected3= 4096,
notes_rejected4= 8192,
modified_by= 16384,
modified_datetime= 32768,
rep_datetime= 65536,
atm_settlement_id= 131072
}
#endregion
public void BulkSave(List<SummaryCorrectionData> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Summary_correction_data";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SummaryCorrectionData.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SummaryCorrectionData> transList,ref DataTable dt)
{
foreach (SummaryCorrectionData tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["summary_correction_data_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["notes_remaining1"] = tran.NotesRemaining1;
Row["notes_remaining2"] = tran.NotesRemaining2;
Row["notes_remaining3"] = tran.NotesRemaining3;
Row["notes_remaining4"] = tran.NotesRemaining4;
Row["notes_dispensed1"] = tran.NotesDispensed1;
Row["notes_dispensed2"] = tran.NotesDispensed2;
Row["notes_dispensed3"] = tran.NotesDispensed3;
Row["notes_dispensed4"] = tran.NotesDispensed4;
Row["notes_rejected1"] = tran.NotesRejected1;
Row["notes_rejected2"] = tran.NotesRejected2;
Row["notes_rejected3"] = tran.NotesRejected3;
Row["notes_rejected4"] = tran.NotesRejected4;
Row["modified_by"] = tran.ModifiedBy;
Row["modified_datetime"] = tran.ModifiedDatetime;
Row["rep_datetime"] = tran.RepDatetime;
Row["atm_settlement_id"] = tran.AtmSettlementId;
dt.Rows.Add(Row);
} }
}
}
