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
public class DispenserEndOfDayBalance
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DispenserEndOfDayBalance() { }
public DispenserEndOfDayBalance( int atm_id,DateTime counter_file_datetime,int cassette1_remaining_notes,int cassette2_remaining_notes,int cassette3_remaining_notes,int cassette4_remaining_notes,int cassette5_remaining_notes,int cassette6_remaining_notes,int cassette7_remaining_notes,int cassette1_dispensed_notes,int cassette2_dispensed_notes,int cassette3_dispensed_notes,int cassette4_dispensed_notes,int cassette5_dispensed_notes,int cassette6_dispensed_notes,int cassette7_dispensed_notes,int cassette1_purged_notes,int cassette2_purged_notes,int cassette3_purged_notes,int cassette4_purged_notes,int cassette5_purged_notes,int cassette6_purged_notes,int cassette7_purged_notes,DateTime processed_at_datetime )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.counter_file_datetime = counter_file_datetime;
this.counter_file_datetimeChanged = true;
this.cassette1_remaining_notes = cassette1_remaining_notes;
this.cassette1_remaining_notesChanged = true;
this.cassette2_remaining_notes = cassette2_remaining_notes;
this.cassette2_remaining_notesChanged = true;
this.cassette3_remaining_notes = cassette3_remaining_notes;
this.cassette3_remaining_notesChanged = true;
this.cassette4_remaining_notes = cassette4_remaining_notes;
this.cassette4_remaining_notesChanged = true;
this.cassette5_remaining_notes = cassette5_remaining_notes;
this.cassette5_remaining_notesChanged = true;
this.cassette6_remaining_notes = cassette6_remaining_notes;
this.cassette6_remaining_notesChanged = true;
this.cassette7_remaining_notes = cassette7_remaining_notes;
this.cassette7_remaining_notesChanged = true;
this.cassette1_dispensed_notes = cassette1_dispensed_notes;
this.cassette1_dispensed_notesChanged = true;
this.cassette2_dispensed_notes = cassette2_dispensed_notes;
this.cassette2_dispensed_notesChanged = true;
this.cassette3_dispensed_notes = cassette3_dispensed_notes;
this.cassette3_dispensed_notesChanged = true;
this.cassette4_dispensed_notes = cassette4_dispensed_notes;
this.cassette4_dispensed_notesChanged = true;
this.cassette5_dispensed_notes = cassette5_dispensed_notes;
this.cassette5_dispensed_notesChanged = true;
this.cassette6_dispensed_notes = cassette6_dispensed_notes;
this.cassette6_dispensed_notesChanged = true;
this.cassette7_dispensed_notes = cassette7_dispensed_notes;
this.cassette7_dispensed_notesChanged = true;
this.cassette1_purged_notes = cassette1_purged_notes;
this.cassette1_purged_notesChanged = true;
this.cassette2_purged_notes = cassette2_purged_notes;
this.cassette2_purged_notesChanged = true;
this.cassette3_purged_notes = cassette3_purged_notes;
this.cassette3_purged_notesChanged = true;
this.cassette4_purged_notes = cassette4_purged_notes;
this.cassette4_purged_notesChanged = true;
this.cassette5_purged_notes = cassette5_purged_notes;
this.cassette5_purged_notesChanged = true;
this.cassette6_purged_notes = cassette6_purged_notes;
this.cassette6_purged_notesChanged = true;
this.cassette7_purged_notes = cassette7_purged_notes;
this.cassette7_purged_notesChanged = true;
this.processed_at_datetime = processed_at_datetime;
this.processed_at_datetimeChanged = true;
}
private DispenserEndOfDayBalance( int dispenser_end_of_day_balance_id,int atm_id,DateTime counter_file_datetime,int cassette1_remaining_notes,int cassette2_remaining_notes,int cassette3_remaining_notes,int cassette4_remaining_notes,int cassette5_remaining_notes,int cassette6_remaining_notes,int cassette7_remaining_notes,int cassette1_dispensed_notes,int cassette2_dispensed_notes,int cassette3_dispensed_notes,int cassette4_dispensed_notes,int cassette5_dispensed_notes,int cassette6_dispensed_notes,int cassette7_dispensed_notes,int cassette1_purged_notes,int cassette2_purged_notes,int cassette3_purged_notes,int cassette4_purged_notes,int cassette5_purged_notes,int cassette6_purged_notes,int cassette7_purged_notes,DateTime processed_at_datetime )
{
this.dispenser_end_of_day_balance_id = dispenser_end_of_day_balance_id;
this.dispenser_end_of_day_balance_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.counter_file_datetime = counter_file_datetime;
this.counter_file_datetimeChanged = true;
this.cassette1_remaining_notes = cassette1_remaining_notes;
this.cassette1_remaining_notesChanged = true;
this.cassette2_remaining_notes = cassette2_remaining_notes;
this.cassette2_remaining_notesChanged = true;
this.cassette3_remaining_notes = cassette3_remaining_notes;
this.cassette3_remaining_notesChanged = true;
this.cassette4_remaining_notes = cassette4_remaining_notes;
this.cassette4_remaining_notesChanged = true;
this.cassette5_remaining_notes = cassette5_remaining_notes;
this.cassette5_remaining_notesChanged = true;
this.cassette6_remaining_notes = cassette6_remaining_notes;
this.cassette6_remaining_notesChanged = true;
this.cassette7_remaining_notes = cassette7_remaining_notes;
this.cassette7_remaining_notesChanged = true;
this.cassette1_dispensed_notes = cassette1_dispensed_notes;
this.cassette1_dispensed_notesChanged = true;
this.cassette2_dispensed_notes = cassette2_dispensed_notes;
this.cassette2_dispensed_notesChanged = true;
this.cassette3_dispensed_notes = cassette3_dispensed_notes;
this.cassette3_dispensed_notesChanged = true;
this.cassette4_dispensed_notes = cassette4_dispensed_notes;
this.cassette4_dispensed_notesChanged = true;
this.cassette5_dispensed_notes = cassette5_dispensed_notes;
this.cassette5_dispensed_notesChanged = true;
this.cassette6_dispensed_notes = cassette6_dispensed_notes;
this.cassette6_dispensed_notesChanged = true;
this.cassette7_dispensed_notes = cassette7_dispensed_notes;
this.cassette7_dispensed_notesChanged = true;
this.cassette1_purged_notes = cassette1_purged_notes;
this.cassette1_purged_notesChanged = true;
this.cassette2_purged_notes = cassette2_purged_notes;
this.cassette2_purged_notesChanged = true;
this.cassette3_purged_notes = cassette3_purged_notes;
this.cassette3_purged_notesChanged = true;
this.cassette4_purged_notes = cassette4_purged_notes;
this.cassette4_purged_notesChanged = true;
this.cassette5_purged_notes = cassette5_purged_notes;
this.cassette5_purged_notesChanged = true;
this.cassette6_purged_notes = cassette6_purged_notes;
this.cassette6_purged_notesChanged = true;
this.cassette7_purged_notes = cassette7_purged_notes;
this.cassette7_purged_notesChanged = true;
this.processed_at_datetime = processed_at_datetime;
this.processed_at_datetimeChanged = true;
}

#region members and properties for columns

#region DispenserEndOfDayBalanceId
private bool dispenser_end_of_day_balance_idChanged = false;
private int dispenser_end_of_day_balance_id;
public int DispenserEndOfDayBalanceId
{
get { return dispenser_end_of_day_balance_id; }
set { 
dispenser_end_of_day_balance_id = value;
dispenser_end_of_day_balance_idChanged = true;
}
}
private string dispenser_end_of_day_balance_idDbString
{
get
{
return dispenser_end_of_day_balance_id.ToString();
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
#region CounterFileDatetime
private bool counter_file_datetimeChanged = false;
private DateTime counter_file_datetime;
public DateTime CounterFileDatetime
{
get { return counter_file_datetime; }
set { 
counter_file_datetime = value;
counter_file_datetimeChanged = true;
}
}
private string counter_file_datetimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",counter_file_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region Cassette1RemainingNotes
private bool cassette1_remaining_notesChanged = false;
private int cassette1_remaining_notes;
public int Cassette1RemainingNotes
{
get { return cassette1_remaining_notes; }
set { 
cassette1_remaining_notes = value;
cassette1_remaining_notesChanged = true;
}
}
private string cassette1_remaining_notesDbString
{
get
{
return cassette1_remaining_notes.ToString();
}
}
#endregion
#region Cassette2RemainingNotes
private bool cassette2_remaining_notesChanged = false;
private int cassette2_remaining_notes;
public int Cassette2RemainingNotes
{
get { return cassette2_remaining_notes; }
set { 
cassette2_remaining_notes = value;
cassette2_remaining_notesChanged = true;
}
}
private string cassette2_remaining_notesDbString
{
get
{
return cassette2_remaining_notes.ToString();
}
}
#endregion
#region Cassette3RemainingNotes
private bool cassette3_remaining_notesChanged = false;
private int cassette3_remaining_notes;
public int Cassette3RemainingNotes
{
get { return cassette3_remaining_notes; }
set { 
cassette3_remaining_notes = value;
cassette3_remaining_notesChanged = true;
}
}
private string cassette3_remaining_notesDbString
{
get
{
return cassette3_remaining_notes.ToString();
}
}
#endregion
#region Cassette4RemainingNotes
private bool cassette4_remaining_notesChanged = false;
private int cassette4_remaining_notes;
public int Cassette4RemainingNotes
{
get { return cassette4_remaining_notes; }
set { 
cassette4_remaining_notes = value;
cassette4_remaining_notesChanged = true;
}
}
private string cassette4_remaining_notesDbString
{
get
{
return cassette4_remaining_notes.ToString();
}
}
#endregion
#region Cassette5RemainingNotes
private bool cassette5_remaining_notesChanged = false;
private int cassette5_remaining_notes;
public int Cassette5RemainingNotes
{
get { return cassette5_remaining_notes; }
set { 
cassette5_remaining_notes = value;
cassette5_remaining_notesChanged = true;
}
}
private string cassette5_remaining_notesDbString
{
get
{
return cassette5_remaining_notes.ToString();
}
}
#endregion
#region Cassette6RemainingNotes
private bool cassette6_remaining_notesChanged = false;
private int cassette6_remaining_notes;
public int Cassette6RemainingNotes
{
get { return cassette6_remaining_notes; }
set { 
cassette6_remaining_notes = value;
cassette6_remaining_notesChanged = true;
}
}
private string cassette6_remaining_notesDbString
{
get
{
return cassette6_remaining_notes.ToString();
}
}
#endregion
#region Cassette7RemainingNotes
private bool cassette7_remaining_notesChanged = false;
private int cassette7_remaining_notes;
public int Cassette7RemainingNotes
{
get { return cassette7_remaining_notes; }
set { 
cassette7_remaining_notes = value;
cassette7_remaining_notesChanged = true;
}
}
private string cassette7_remaining_notesDbString
{
get
{
return cassette7_remaining_notes.ToString();
}
}
#endregion
#region Cassette1DispensedNotes
private bool cassette1_dispensed_notesChanged = false;
private int cassette1_dispensed_notes;
public int Cassette1DispensedNotes
{
get { return cassette1_dispensed_notes; }
set { 
cassette1_dispensed_notes = value;
cassette1_dispensed_notesChanged = true;
}
}
private string cassette1_dispensed_notesDbString
{
get
{
return cassette1_dispensed_notes.ToString();
}
}
#endregion
#region Cassette2DispensedNotes
private bool cassette2_dispensed_notesChanged = false;
private int cassette2_dispensed_notes;
public int Cassette2DispensedNotes
{
get { return cassette2_dispensed_notes; }
set { 
cassette2_dispensed_notes = value;
cassette2_dispensed_notesChanged = true;
}
}
private string cassette2_dispensed_notesDbString
{
get
{
return cassette2_dispensed_notes.ToString();
}
}
#endregion
#region Cassette3DispensedNotes
private bool cassette3_dispensed_notesChanged = false;
private int cassette3_dispensed_notes;
public int Cassette3DispensedNotes
{
get { return cassette3_dispensed_notes; }
set { 
cassette3_dispensed_notes = value;
cassette3_dispensed_notesChanged = true;
}
}
private string cassette3_dispensed_notesDbString
{
get
{
return cassette3_dispensed_notes.ToString();
}
}
#endregion
#region Cassette4DispensedNotes
private bool cassette4_dispensed_notesChanged = false;
private int cassette4_dispensed_notes;
public int Cassette4DispensedNotes
{
get { return cassette4_dispensed_notes; }
set { 
cassette4_dispensed_notes = value;
cassette4_dispensed_notesChanged = true;
}
}
private string cassette4_dispensed_notesDbString
{
get
{
return cassette4_dispensed_notes.ToString();
}
}
#endregion
#region Cassette5DispensedNotes
private bool cassette5_dispensed_notesChanged = false;
private int cassette5_dispensed_notes;
public int Cassette5DispensedNotes
{
get { return cassette5_dispensed_notes; }
set { 
cassette5_dispensed_notes = value;
cassette5_dispensed_notesChanged = true;
}
}
private string cassette5_dispensed_notesDbString
{
get
{
return cassette5_dispensed_notes.ToString();
}
}
#endregion
#region Cassette6DispensedNotes
private bool cassette6_dispensed_notesChanged = false;
private int cassette6_dispensed_notes;
public int Cassette6DispensedNotes
{
get { return cassette6_dispensed_notes; }
set { 
cassette6_dispensed_notes = value;
cassette6_dispensed_notesChanged = true;
}
}
private string cassette6_dispensed_notesDbString
{
get
{
return cassette6_dispensed_notes.ToString();
}
}
#endregion
#region Cassette7DispensedNotes
private bool cassette7_dispensed_notesChanged = false;
private int cassette7_dispensed_notes;
public int Cassette7DispensedNotes
{
get { return cassette7_dispensed_notes; }
set { 
cassette7_dispensed_notes = value;
cassette7_dispensed_notesChanged = true;
}
}
private string cassette7_dispensed_notesDbString
{
get
{
return cassette7_dispensed_notes.ToString();
}
}
#endregion
#region Cassette1PurgedNotes
private bool cassette1_purged_notesChanged = false;
private int cassette1_purged_notes;
public int Cassette1PurgedNotes
{
get { return cassette1_purged_notes; }
set { 
cassette1_purged_notes = value;
cassette1_purged_notesChanged = true;
}
}
private string cassette1_purged_notesDbString
{
get
{
return cassette1_purged_notes.ToString();
}
}
#endregion
#region Cassette2PurgedNotes
private bool cassette2_purged_notesChanged = false;
private int cassette2_purged_notes;
public int Cassette2PurgedNotes
{
get { return cassette2_purged_notes; }
set { 
cassette2_purged_notes = value;
cassette2_purged_notesChanged = true;
}
}
private string cassette2_purged_notesDbString
{
get
{
return cassette2_purged_notes.ToString();
}
}
#endregion
#region Cassette3PurgedNotes
private bool cassette3_purged_notesChanged = false;
private int cassette3_purged_notes;
public int Cassette3PurgedNotes
{
get { return cassette3_purged_notes; }
set { 
cassette3_purged_notes = value;
cassette3_purged_notesChanged = true;
}
}
private string cassette3_purged_notesDbString
{
get
{
return cassette3_purged_notes.ToString();
}
}
#endregion
#region Cassette4PurgedNotes
private bool cassette4_purged_notesChanged = false;
private int cassette4_purged_notes;
public int Cassette4PurgedNotes
{
get { return cassette4_purged_notes; }
set { 
cassette4_purged_notes = value;
cassette4_purged_notesChanged = true;
}
}
private string cassette4_purged_notesDbString
{
get
{
return cassette4_purged_notes.ToString();
}
}
#endregion
#region Cassette5PurgedNotes
private bool cassette5_purged_notesChanged = false;
private int cassette5_purged_notes;
public int Cassette5PurgedNotes
{
get { return cassette5_purged_notes; }
set { 
cassette5_purged_notes = value;
cassette5_purged_notesChanged = true;
}
}
private string cassette5_purged_notesDbString
{
get
{
return cassette5_purged_notes.ToString();
}
}
#endregion
#region Cassette6PurgedNotes
private bool cassette6_purged_notesChanged = false;
private int cassette6_purged_notes;
public int Cassette6PurgedNotes
{
get { return cassette6_purged_notes; }
set { 
cassette6_purged_notes = value;
cassette6_purged_notesChanged = true;
}
}
private string cassette6_purged_notesDbString
{
get
{
return cassette6_purged_notes.ToString();
}
}
#endregion
#region Cassette7PurgedNotes
private bool cassette7_purged_notesChanged = false;
private int cassette7_purged_notes;
public int Cassette7PurgedNotes
{
get { return cassette7_purged_notes; }
set { 
cassette7_purged_notes = value;
cassette7_purged_notesChanged = true;
}
}
private string cassette7_purged_notesDbString
{
get
{
return cassette7_purged_notes.ToString();
}
}
#endregion
#region ProcessedAtDatetime
private bool processed_at_datetimeChanged = false;
private DateTime processed_at_datetime;
public DateTime ProcessedAtDatetime
{
get { return processed_at_datetime; }
set { 
processed_at_datetime = value;
processed_at_datetimeChanged = true;
}
}
private string processed_at_datetimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",processed_at_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region DispenserEndOfDayBalanceReader
public class DispenserEndOfDayBalanceReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DispenserEndOfDayBalance currentDispenserEndOfDayBalance;
Columns columns;
bool partialRead = false;
private DispenserEndOfDayBalanceReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DispenserEndOfDayBalanceReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DispenserEndOfDayBalanceReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDispenserEndOfDayBalance; }

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
currentDispenserEndOfDayBalance = new DispenserEndOfDayBalance();
if (partialRead)
{ if ((columns & Columns.dispenser_end_of_day_balance_id) == Columns.dispenser_end_of_day_balance_id && reader["dispenser_end_of_day_balance_id"]!=DBNull.Value)
currentDispenserEndOfDayBalance.dispenser_end_of_day_balance_id =(int) reader["dispenser_end_of_day_balance_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentDispenserEndOfDayBalance.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.counter_file_datetime) == Columns.counter_file_datetime && reader["counter_file_datetime"]!=DBNull.Value)
currentDispenserEndOfDayBalance.counter_file_datetime =(DateTime) reader["counter_file_datetime"]; 
if ((columns & Columns.cassette1_remaining_notes) == Columns.cassette1_remaining_notes && reader["cassette1_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette1_remaining_notes =(int) reader["cassette1_remaining_notes"]; 
if ((columns & Columns.cassette2_remaining_notes) == Columns.cassette2_remaining_notes && reader["cassette2_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette2_remaining_notes =(int) reader["cassette2_remaining_notes"]; 
if ((columns & Columns.cassette3_remaining_notes) == Columns.cassette3_remaining_notes && reader["cassette3_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette3_remaining_notes =(int) reader["cassette3_remaining_notes"]; 
if ((columns & Columns.cassette4_remaining_notes) == Columns.cassette4_remaining_notes && reader["cassette4_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette4_remaining_notes =(int) reader["cassette4_remaining_notes"]; 
if ((columns & Columns.cassette5_remaining_notes) == Columns.cassette5_remaining_notes && reader["cassette5_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette5_remaining_notes =(int) reader["cassette5_remaining_notes"]; 
if ((columns & Columns.cassette6_remaining_notes) == Columns.cassette6_remaining_notes && reader["cassette6_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette6_remaining_notes =(int) reader["cassette6_remaining_notes"]; 
if ((columns & Columns.cassette7_remaining_notes) == Columns.cassette7_remaining_notes && reader["cassette7_remaining_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette7_remaining_notes =(int) reader["cassette7_remaining_notes"]; 
if ((columns & Columns.cassette1_dispensed_notes) == Columns.cassette1_dispensed_notes && reader["cassette1_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette1_dispensed_notes =(int) reader["cassette1_dispensed_notes"]; 
if ((columns & Columns.cassette2_dispensed_notes) == Columns.cassette2_dispensed_notes && reader["cassette2_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette2_dispensed_notes =(int) reader["cassette2_dispensed_notes"]; 
if ((columns & Columns.cassette3_dispensed_notes) == Columns.cassette3_dispensed_notes && reader["cassette3_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette3_dispensed_notes =(int) reader["cassette3_dispensed_notes"]; 
if ((columns & Columns.cassette4_dispensed_notes) == Columns.cassette4_dispensed_notes && reader["cassette4_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette4_dispensed_notes =(int) reader["cassette4_dispensed_notes"]; 
if ((columns & Columns.cassette5_dispensed_notes) == Columns.cassette5_dispensed_notes && reader["cassette5_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette5_dispensed_notes =(int) reader["cassette5_dispensed_notes"]; 
if ((columns & Columns.cassette6_dispensed_notes) == Columns.cassette6_dispensed_notes && reader["cassette6_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette6_dispensed_notes =(int) reader["cassette6_dispensed_notes"]; 
if ((columns & Columns.cassette7_dispensed_notes) == Columns.cassette7_dispensed_notes && reader["cassette7_dispensed_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette7_dispensed_notes =(int) reader["cassette7_dispensed_notes"]; 
if ((columns & Columns.cassette1_purged_notes) == Columns.cassette1_purged_notes && reader["cassette1_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette1_purged_notes =(int) reader["cassette1_purged_notes"]; 
if ((columns & Columns.cassette2_purged_notes) == Columns.cassette2_purged_notes && reader["cassette2_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette2_purged_notes =(int) reader["cassette2_purged_notes"]; 
if ((columns & Columns.cassette3_purged_notes) == Columns.cassette3_purged_notes && reader["cassette3_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette3_purged_notes =(int) reader["cassette3_purged_notes"]; 
if ((columns & Columns.cassette4_purged_notes) == Columns.cassette4_purged_notes && reader["cassette4_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette4_purged_notes =(int) reader["cassette4_purged_notes"]; 
if ((columns & Columns.cassette5_purged_notes) == Columns.cassette5_purged_notes && reader["cassette5_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette5_purged_notes =(int) reader["cassette5_purged_notes"]; 
if ((columns & Columns.cassette6_purged_notes) == Columns.cassette6_purged_notes && reader["cassette6_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette6_purged_notes =(int) reader["cassette6_purged_notes"]; 
if ((columns & Columns.cassette7_purged_notes) == Columns.cassette7_purged_notes && reader["cassette7_purged_notes"]!=DBNull.Value)
currentDispenserEndOfDayBalance.cassette7_purged_notes =(int) reader["cassette7_purged_notes"]; 
if ((columns & Columns.processed_at_datetime) == Columns.processed_at_datetime && reader["processed_at_datetime"]!=DBNull.Value)
currentDispenserEndOfDayBalance.processed_at_datetime =(DateTime) reader["processed_at_datetime"]; 

} else
{
if (reader["dispenser_end_of_day_balance_id"] != DBNull.Value)
currentDispenserEndOfDayBalance.dispenser_end_of_day_balance_id = (int) reader["dispenser_end_of_day_balance_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentDispenserEndOfDayBalance.atm_id = (int) reader["atm_id"]; 
if (reader["counter_file_datetime"] != DBNull.Value)
currentDispenserEndOfDayBalance.counter_file_datetime = (DateTime) reader["counter_file_datetime"]; 
if (reader["cassette1_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette1_remaining_notes = (int) reader["cassette1_remaining_notes"]; 
if (reader["cassette2_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette2_remaining_notes = (int) reader["cassette2_remaining_notes"]; 
if (reader["cassette3_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette3_remaining_notes = (int) reader["cassette3_remaining_notes"]; 
if (reader["cassette4_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette4_remaining_notes = (int) reader["cassette4_remaining_notes"]; 
if (reader["cassette5_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette5_remaining_notes = (int) reader["cassette5_remaining_notes"]; 
if (reader["cassette6_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette6_remaining_notes = (int) reader["cassette6_remaining_notes"]; 
if (reader["cassette7_remaining_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette7_remaining_notes = (int) reader["cassette7_remaining_notes"]; 
if (reader["cassette1_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette1_dispensed_notes = (int) reader["cassette1_dispensed_notes"]; 
if (reader["cassette2_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette2_dispensed_notes = (int) reader["cassette2_dispensed_notes"]; 
if (reader["cassette3_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette3_dispensed_notes = (int) reader["cassette3_dispensed_notes"]; 
if (reader["cassette4_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette4_dispensed_notes = (int) reader["cassette4_dispensed_notes"]; 
if (reader["cassette5_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette5_dispensed_notes = (int) reader["cassette5_dispensed_notes"]; 
if (reader["cassette6_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette6_dispensed_notes = (int) reader["cassette6_dispensed_notes"]; 
if (reader["cassette7_dispensed_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette7_dispensed_notes = (int) reader["cassette7_dispensed_notes"]; 
if (reader["cassette1_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette1_purged_notes = (int) reader["cassette1_purged_notes"]; 
if (reader["cassette2_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette2_purged_notes = (int) reader["cassette2_purged_notes"]; 
if (reader["cassette3_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette3_purged_notes = (int) reader["cassette3_purged_notes"]; 
if (reader["cassette4_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette4_purged_notes = (int) reader["cassette4_purged_notes"]; 
if (reader["cassette5_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette5_purged_notes = (int) reader["cassette5_purged_notes"]; 
if (reader["cassette6_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette6_purged_notes = (int) reader["cassette6_purged_notes"]; 
if (reader["cassette7_purged_notes"] != DBNull.Value)
currentDispenserEndOfDayBalance.cassette7_purged_notes = (int) reader["cassette7_purged_notes"]; 
if (reader["processed_at_datetime"] != DBNull.Value)
currentDispenserEndOfDayBalance.processed_at_datetime = (DateTime) reader["processed_at_datetime"]; 
} 

currentDispenserEndOfDayBalance.isNewEntity = false;
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

public DispenserEndOfDayBalance CurrentDispenserEndOfDayBalance
{
get{ return currentDispenserEndOfDayBalance; }
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


#region DispenserEndOfDayBalance functions

public static DispenserEndOfDayBalanceReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.dispenser_end_of_day_balance_id == (Columns.dispenser_end_of_day_balance_id & columns))
qry.Append("dispenser_end_of_day_balance_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.counter_file_datetime == (Columns.counter_file_datetime & columns))
qry.Append("counter_file_datetime,");
if (Columns.cassette1_remaining_notes == (Columns.cassette1_remaining_notes & columns))
qry.Append("cassette1_remaining_notes,");
if (Columns.cassette2_remaining_notes == (Columns.cassette2_remaining_notes & columns))
qry.Append("cassette2_remaining_notes,");
if (Columns.cassette3_remaining_notes == (Columns.cassette3_remaining_notes & columns))
qry.Append("cassette3_remaining_notes,");
if (Columns.cassette4_remaining_notes == (Columns.cassette4_remaining_notes & columns))
qry.Append("cassette4_remaining_notes,");
if (Columns.cassette5_remaining_notes == (Columns.cassette5_remaining_notes & columns))
qry.Append("cassette5_remaining_notes,");
if (Columns.cassette6_remaining_notes == (Columns.cassette6_remaining_notes & columns))
qry.Append("cassette6_remaining_notes,");
if (Columns.cassette7_remaining_notes == (Columns.cassette7_remaining_notes & columns))
qry.Append("cassette7_remaining_notes,");
if (Columns.cassette1_dispensed_notes == (Columns.cassette1_dispensed_notes & columns))
qry.Append("cassette1_dispensed_notes,");
if (Columns.cassette2_dispensed_notes == (Columns.cassette2_dispensed_notes & columns))
qry.Append("cassette2_dispensed_notes,");
if (Columns.cassette3_dispensed_notes == (Columns.cassette3_dispensed_notes & columns))
qry.Append("cassette3_dispensed_notes,");
if (Columns.cassette4_dispensed_notes == (Columns.cassette4_dispensed_notes & columns))
qry.Append("cassette4_dispensed_notes,");
if (Columns.cassette5_dispensed_notes == (Columns.cassette5_dispensed_notes & columns))
qry.Append("cassette5_dispensed_notes,");
if (Columns.cassette6_dispensed_notes == (Columns.cassette6_dispensed_notes & columns))
qry.Append("cassette6_dispensed_notes,");
if (Columns.cassette7_dispensed_notes == (Columns.cassette7_dispensed_notes & columns))
qry.Append("cassette7_dispensed_notes,");
if (Columns.cassette1_purged_notes == (Columns.cassette1_purged_notes & columns))
qry.Append("cassette1_purged_notes,");
if (Columns.cassette2_purged_notes == (Columns.cassette2_purged_notes & columns))
qry.Append("cassette2_purged_notes,");
if (Columns.cassette3_purged_notes == (Columns.cassette3_purged_notes & columns))
qry.Append("cassette3_purged_notes,");
if (Columns.cassette4_purged_notes == (Columns.cassette4_purged_notes & columns))
qry.Append("cassette4_purged_notes,");
if (Columns.cassette5_purged_notes == (Columns.cassette5_purged_notes & columns))
qry.Append("cassette5_purged_notes,");
if (Columns.cassette6_purged_notes == (Columns.cassette6_purged_notes & columns))
qry.Append("cassette6_purged_notes,");
if (Columns.cassette7_purged_notes == (Columns.cassette7_purged_notes & columns))
qry.Append("cassette7_purged_notes,");
if (Columns.processed_at_datetime == (Columns.processed_at_datetime & columns))
qry.Append("processed_at_datetime,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Dispenser_end_of_day_balance ");

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
return new DispenserEndOfDayBalanceReader(cmd.ExecuteReader(), conn, columns);
}

static public DispenserEndOfDayBalanceReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DispenserEndOfDayBalanceReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select dispenser_end_of_day_balance_id,atm_id,counter_file_datetime,cassette1_remaining_notes,cassette2_remaining_notes,cassette3_remaining_notes,cassette4_remaining_notes,cassette5_remaining_notes,cassette6_remaining_notes,cassette7_remaining_notes,cassette1_dispensed_notes,cassette2_dispensed_notes,cassette3_dispensed_notes,cassette4_dispensed_notes,cassette5_dispensed_notes,cassette6_dispensed_notes,cassette7_dispensed_notes,cassette1_purged_notes,cassette2_purged_notes,cassette3_purged_notes,cassette4_purged_notes,cassette5_purged_notes,cassette6_purged_notes,cassette7_purged_notes,processed_at_datetime from Dispenser_end_of_day_balance ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DispenserEndOfDayBalanceReader(cmd.ExecuteReader(), conn);
}

static public DispenserEndOfDayBalanceReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DispenserEndOfDayBalance LoadDispenserEndOfDayBalance(string where)
{
DispenserEndOfDayBalanceReader reader = DispenserEndOfDayBalance.ExecuteReader(where);
DispenserEndOfDayBalance _dispenserendofdaybalance = null;
if (reader.Read())
_dispenserendofdaybalance = reader.CurrentDispenserEndOfDayBalance;
reader.Close();
return _dispenserendofdaybalance;
}

public static DispenserEndOfDayBalance LoadDispenserEndOfDayBalance(string where, IDbConnection conn)
{
DispenserEndOfDayBalanceReader reader = DispenserEndOfDayBalance.ExecuteReader(where, conn);
DispenserEndOfDayBalance _dispenserendofdaybalance = null;
if (reader.Read())
_dispenserendofdaybalance = reader.CurrentDispenserEndOfDayBalance;
reader.Close(false);
return _dispenserendofdaybalance;
}

public static DispenserEndOfDayBalance LoadDispenserEndOfDayBalanceByPk( int dispenser_end_of_day_balance_id )
{
return LoadDispenserEndOfDayBalance( " dispenser_end_of_day_balance_id="+dispenser_end_of_day_balance_id );
}

public static DispenserEndOfDayBalance LoadDispenserEndOfDayBalanceByPk( int dispenser_end_of_day_balance_id , IDbConnection conn)
{
return LoadDispenserEndOfDayBalance(" dispenser_end_of_day_balance_id="+dispenser_end_of_day_balance_id , conn);
}

public void Save()
{
if (dispenser_end_of_day_balance_idChanged || atm_idChanged || counter_file_datetimeChanged || cassette1_remaining_notesChanged || cassette2_remaining_notesChanged || cassette3_remaining_notesChanged || cassette4_remaining_notesChanged || cassette5_remaining_notesChanged || cassette6_remaining_notesChanged || cassette7_remaining_notesChanged || cassette1_dispensed_notesChanged || cassette2_dispensed_notesChanged || cassette3_dispensed_notesChanged || cassette4_dispensed_notesChanged || cassette5_dispensed_notesChanged || cassette6_dispensed_notesChanged || cassette7_dispensed_notesChanged || cassette1_purged_notesChanged || cassette2_purged_notesChanged || cassette3_purged_notesChanged || cassette4_purged_notesChanged || cassette5_purged_notesChanged || cassette6_purged_notesChanged || cassette7_purged_notesChanged || processed_at_datetimeChanged )
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
if (dispenser_end_of_day_balance_idChanged || atm_idChanged || counter_file_datetimeChanged || cassette1_remaining_notesChanged || cassette2_remaining_notesChanged || cassette3_remaining_notesChanged || cassette4_remaining_notesChanged || cassette5_remaining_notesChanged || cassette6_remaining_notesChanged || cassette7_remaining_notesChanged || cassette1_dispensed_notesChanged || cassette2_dispensed_notesChanged || cassette3_dispensed_notesChanged || cassette4_dispensed_notesChanged || cassette5_dispensed_notesChanged || cassette6_dispensed_notesChanged || cassette7_dispensed_notesChanged || cassette1_purged_notesChanged || cassette2_purged_notesChanged || cassette3_purged_notesChanged || cassette4_purged_notesChanged || cassette5_purged_notesChanged || cassette6_purged_notesChanged || cassette7_purged_notesChanged || processed_at_datetimeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Dispenser_end_of_day_balance( dispenser_end_of_day_balance_id,atm_id,counter_file_datetime,cassette1_remaining_notes,cassette2_remaining_notes,cassette3_remaining_notes,cassette4_remaining_notes,cassette5_remaining_notes,cassette6_remaining_notes,cassette7_remaining_notes,cassette1_dispensed_notes,cassette2_dispensed_notes,cassette3_dispensed_notes,cassette4_dispensed_notes,cassette5_dispensed_notes,cassette6_dispensed_notes,cassette7_dispensed_notes,cassette1_purged_notes,cassette2_purged_notes,cassette3_purged_notes,cassette4_purged_notes,cassette5_purged_notes,cassette6_purged_notes,cassette7_purged_notes,processed_at_datetime ) values(");
lock (ConnectionFactory.connectionString) { this.dispenser_end_of_day_balance_id = ConnectionFactory.GetNextId();
qry.Append(this.dispenser_end_of_day_balance_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(counter_file_datetimeDbString+",");
qry.Append(cassette1_remaining_notesDbString+",");
qry.Append(cassette2_remaining_notesDbString+",");
qry.Append(cassette3_remaining_notesDbString+",");
qry.Append(cassette4_remaining_notesDbString+",");
qry.Append(cassette5_remaining_notesDbString+",");
qry.Append(cassette6_remaining_notesDbString+",");
qry.Append(cassette7_remaining_notesDbString+",");
qry.Append(cassette1_dispensed_notesDbString+",");
qry.Append(cassette2_dispensed_notesDbString+",");
qry.Append(cassette3_dispensed_notesDbString+",");
qry.Append(cassette4_dispensed_notesDbString+",");
qry.Append(cassette5_dispensed_notesDbString+",");
qry.Append(cassette6_dispensed_notesDbString+",");
qry.Append(cassette7_dispensed_notesDbString+",");
qry.Append(cassette1_purged_notesDbString+",");
qry.Append(cassette2_purged_notesDbString+",");
qry.Append(cassette3_purged_notesDbString+",");
qry.Append(cassette4_purged_notesDbString+",");
qry.Append(cassette5_purged_notesDbString+",");
qry.Append(cassette6_purged_notesDbString+",");
qry.Append(cassette7_purged_notesDbString+",");
qry.Append(processed_at_datetimeDbString);
qry.Append(");");

}
else
{
if (!(dispenser_end_of_day_balance_idChanged || atm_idChanged || counter_file_datetimeChanged || cassette1_remaining_notesChanged || cassette2_remaining_notesChanged || cassette3_remaining_notesChanged || cassette4_remaining_notesChanged || cassette5_remaining_notesChanged || cassette6_remaining_notesChanged || cassette7_remaining_notesChanged || cassette1_dispensed_notesChanged || cassette2_dispensed_notesChanged || cassette3_dispensed_notesChanged || cassette4_dispensed_notesChanged || cassette5_dispensed_notesChanged || cassette6_dispensed_notesChanged || cassette7_dispensed_notesChanged || cassette1_purged_notesChanged || cassette2_purged_notesChanged || cassette3_purged_notesChanged || cassette4_purged_notesChanged || cassette5_purged_notesChanged || cassette6_purged_notesChanged || cassette7_purged_notesChanged || processed_at_datetimeChanged ))
return;
qry.Append("UPDATE Dispenser_end_of_day_balance set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( counter_file_datetimeChanged )
{
qry.Append("counter_file_datetime ="+counter_file_datetimeDbString);
qry.Append(",");
}

if ( cassette1_remaining_notesChanged )
{
qry.Append("cassette1_remaining_notes ="+cassette1_remaining_notesDbString);
qry.Append(",");
}

if ( cassette2_remaining_notesChanged )
{
qry.Append("cassette2_remaining_notes ="+cassette2_remaining_notesDbString);
qry.Append(",");
}

if ( cassette3_remaining_notesChanged )
{
qry.Append("cassette3_remaining_notes ="+cassette3_remaining_notesDbString);
qry.Append(",");
}

if ( cassette4_remaining_notesChanged )
{
qry.Append("cassette4_remaining_notes ="+cassette4_remaining_notesDbString);
qry.Append(",");
}

if ( cassette5_remaining_notesChanged )
{
qry.Append("cassette5_remaining_notes ="+cassette5_remaining_notesDbString);
qry.Append(",");
}

if ( cassette6_remaining_notesChanged )
{
qry.Append("cassette6_remaining_notes ="+cassette6_remaining_notesDbString);
qry.Append(",");
}

if ( cassette7_remaining_notesChanged )
{
qry.Append("cassette7_remaining_notes ="+cassette7_remaining_notesDbString);
qry.Append(",");
}

if ( cassette1_dispensed_notesChanged )
{
qry.Append("cassette1_dispensed_notes ="+cassette1_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette2_dispensed_notesChanged )
{
qry.Append("cassette2_dispensed_notes ="+cassette2_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette3_dispensed_notesChanged )
{
qry.Append("cassette3_dispensed_notes ="+cassette3_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette4_dispensed_notesChanged )
{
qry.Append("cassette4_dispensed_notes ="+cassette4_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette5_dispensed_notesChanged )
{
qry.Append("cassette5_dispensed_notes ="+cassette5_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette6_dispensed_notesChanged )
{
qry.Append("cassette6_dispensed_notes ="+cassette6_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette7_dispensed_notesChanged )
{
qry.Append("cassette7_dispensed_notes ="+cassette7_dispensed_notesDbString);
qry.Append(",");
}

if ( cassette1_purged_notesChanged )
{
qry.Append("cassette1_purged_notes ="+cassette1_purged_notesDbString);
qry.Append(",");
}

if ( cassette2_purged_notesChanged )
{
qry.Append("cassette2_purged_notes ="+cassette2_purged_notesDbString);
qry.Append(",");
}

if ( cassette3_purged_notesChanged )
{
qry.Append("cassette3_purged_notes ="+cassette3_purged_notesDbString);
qry.Append(",");
}

if ( cassette4_purged_notesChanged )
{
qry.Append("cassette4_purged_notes ="+cassette4_purged_notesDbString);
qry.Append(",");
}

if ( cassette5_purged_notesChanged )
{
qry.Append("cassette5_purged_notes ="+cassette5_purged_notesDbString);
qry.Append(",");
}

if ( cassette6_purged_notesChanged )
{
qry.Append("cassette6_purged_notes ="+cassette6_purged_notesDbString);
qry.Append(",");
}

if ( cassette7_purged_notesChanged )
{
qry.Append("cassette7_purged_notes ="+cassette7_purged_notesDbString);
qry.Append(",");
}

if ( processed_at_datetimeChanged )
{
qry.Append("processed_at_datetime ="+processed_at_datetimeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("dispenser_end_of_day_balance_id = "+dispenser_end_of_day_balance_idDbString);
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
cmd.CommandText = "DELETE Dispenser_end_of_day_balance where dispenser_end_of_day_balance_id = "+ dispenser_end_of_day_balance_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDispenserEndOfDayBalances(string where)
{
ConnectionFactory.ExecuteQuery("delete Dispenser_end_of_day_balance where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
dispenser_end_of_day_balance_id= 1,
atm_id= 2,
counter_file_datetime= 4,
cassette1_remaining_notes= 8,
cassette2_remaining_notes= 16,
cassette3_remaining_notes= 32,
cassette4_remaining_notes= 64,
cassette5_remaining_notes= 128,
cassette6_remaining_notes= 256,
cassette7_remaining_notes= 512,
cassette1_dispensed_notes= 1024,
cassette2_dispensed_notes= 2048,
cassette3_dispensed_notes= 4096,
cassette4_dispensed_notes= 8192,
cassette5_dispensed_notes= 16384,
cassette6_dispensed_notes= 32768,
cassette7_dispensed_notes= 65536,
cassette1_purged_notes= 131072,
cassette2_purged_notes= 262144,
cassette3_purged_notes= 524288,
cassette4_purged_notes= 1048576,
cassette5_purged_notes= 2097152,
cassette6_purged_notes= 4194304,
cassette7_purged_notes= 8388608,
processed_at_datetime= 16777216
}
#endregion
public void BulkSave(List<DispenserEndOfDayBalance> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Dispenser_end_of_day_balance";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DispenserEndOfDayBalance.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DispenserEndOfDayBalance> transList,ref DataTable dt)
{
foreach (DispenserEndOfDayBalance tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["dispenser_end_of_day_balance_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["counter_file_datetime"] = tran.CounterFileDatetime;
Row["cassette1_remaining_notes"] = tran.Cassette1RemainingNotes;
Row["cassette2_remaining_notes"] = tran.Cassette2RemainingNotes;
Row["cassette3_remaining_notes"] = tran.Cassette3RemainingNotes;
Row["cassette4_remaining_notes"] = tran.Cassette4RemainingNotes;
Row["cassette5_remaining_notes"] = tran.Cassette5RemainingNotes;
Row["cassette6_remaining_notes"] = tran.Cassette6RemainingNotes;
Row["cassette7_remaining_notes"] = tran.Cassette7RemainingNotes;
Row["cassette1_dispensed_notes"] = tran.Cassette1DispensedNotes;
Row["cassette2_dispensed_notes"] = tran.Cassette2DispensedNotes;
Row["cassette3_dispensed_notes"] = tran.Cassette3DispensedNotes;
Row["cassette4_dispensed_notes"] = tran.Cassette4DispensedNotes;
Row["cassette5_dispensed_notes"] = tran.Cassette5DispensedNotes;
Row["cassette6_dispensed_notes"] = tran.Cassette6DispensedNotes;
Row["cassette7_dispensed_notes"] = tran.Cassette7DispensedNotes;
Row["cassette1_purged_notes"] = tran.Cassette1PurgedNotes;
Row["cassette2_purged_notes"] = tran.Cassette2PurgedNotes;
Row["cassette3_purged_notes"] = tran.Cassette3PurgedNotes;
Row["cassette4_purged_notes"] = tran.Cassette4PurgedNotes;
Row["cassette5_purged_notes"] = tran.Cassette5PurgedNotes;
Row["cassette6_purged_notes"] = tran.Cassette6PurgedNotes;
Row["cassette7_purged_notes"] = tran.Cassette7PurgedNotes;
Row["processed_at_datetime"] = tran.ProcessedAtDatetime;
dt.Rows.Add(Row);
} }
}
}
