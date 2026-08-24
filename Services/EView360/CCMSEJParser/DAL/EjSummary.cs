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
public class EjSummary
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public EjSummary() { }
public EjSummary( int ej_summary_id ) 
{
}
public EjSummary( int? atm_id,decimal? closing_balance,decimal? withdrawals,decimal? pre_withdrawals,decimal? return_amount,decimal? replenishment_amount,DateTime? rep_datetime,DateTime? trxn_datetime,DateTime? processing_datetime,int? notes_remaining_type1,int? notes_remaining_type2,int? notes_remaining_type3,int? notes_remaining_type4,int? cash_added1,int? cash_added2,int? cash_added3,int? cash_added4,int? return_type1,int? return_type2,int? return_type3,int? return_type4 )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.withdrawals = withdrawals;
this.withdrawalsChanged = true;
this.pre_withdrawals = pre_withdrawals;
this.pre_withdrawalsChanged = true;
this.return_amount = return_amount;
this.return_amountChanged = true;
this.replenishment_amount = replenishment_amount;
this.replenishment_amountChanged = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.trxn_datetime = trxn_datetime;
this.trxn_datetimeChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
this.notes_remaining_type1 = notes_remaining_type1;
this.notes_remaining_type1Changed = true;
this.notes_remaining_type2 = notes_remaining_type2;
this.notes_remaining_type2Changed = true;
this.notes_remaining_type3 = notes_remaining_type3;
this.notes_remaining_type3Changed = true;
this.notes_remaining_type4 = notes_remaining_type4;
this.notes_remaining_type4Changed = true;
this.cash_added1 = cash_added1;
this.cash_added1Changed = true;
this.cash_added2 = cash_added2;
this.cash_added2Changed = true;
this.cash_added3 = cash_added3;
this.cash_added3Changed = true;
this.cash_added4 = cash_added4;
this.cash_added4Changed = true;
this.return_type1 = return_type1;
this.return_type1Changed = true;
this.return_type2 = return_type2;
this.return_type2Changed = true;
this.return_type3 = return_type3;
this.return_type3Changed = true;
this.return_type4 = return_type4;
this.return_type4Changed = true;
}
private EjSummary( int ej_summary_id,int? atm_id,decimal? closing_balance,decimal? withdrawals,decimal? pre_withdrawals,decimal? return_amount,decimal? replenishment_amount,DateTime? rep_datetime,DateTime? trxn_datetime,DateTime? processing_datetime,int? notes_remaining_type1,int? notes_remaining_type2,int? notes_remaining_type3,int? notes_remaining_type4,int? cash_added1,int? cash_added2,int? cash_added3,int? cash_added4,int? return_type1,int? return_type2,int? return_type3,int? return_type4 )
{
this.ej_summary_id = ej_summary_id;
this.ej_summary_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.withdrawals = withdrawals;
this.withdrawalsChanged = true;
this.pre_withdrawals = pre_withdrawals;
this.pre_withdrawalsChanged = true;
this.return_amount = return_amount;
this.return_amountChanged = true;
this.replenishment_amount = replenishment_amount;
this.replenishment_amountChanged = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.trxn_datetime = trxn_datetime;
this.trxn_datetimeChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
this.notes_remaining_type1 = notes_remaining_type1;
this.notes_remaining_type1Changed = true;
this.notes_remaining_type2 = notes_remaining_type2;
this.notes_remaining_type2Changed = true;
this.notes_remaining_type3 = notes_remaining_type3;
this.notes_remaining_type3Changed = true;
this.notes_remaining_type4 = notes_remaining_type4;
this.notes_remaining_type4Changed = true;
this.cash_added1 = cash_added1;
this.cash_added1Changed = true;
this.cash_added2 = cash_added2;
this.cash_added2Changed = true;
this.cash_added3 = cash_added3;
this.cash_added3Changed = true;
this.cash_added4 = cash_added4;
this.cash_added4Changed = true;
this.return_type1 = return_type1;
this.return_type1Changed = true;
this.return_type2 = return_type2;
this.return_type2Changed = true;
this.return_type3 = return_type3;
this.return_type3Changed = true;
this.return_type4 = return_type4;
this.return_type4Changed = true;
}

#region members and properties for columns

#region EjSummaryId
private bool ej_summary_idChanged = false;
private int ej_summary_id;
public int EjSummaryId
{
get { return ej_summary_id; }
set { 
ej_summary_id = value;
ej_summary_idChanged = true;
}
}
private string ej_summary_idDbString
{
get
{
return ej_summary_id.ToString();
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
#region ClosingBalance
private bool closing_balanceChanged = false;
private decimal? closing_balance;
public decimal? ClosingBalance
{
get { return closing_balance; }
set { 
closing_balance = value;
closing_balanceChanged = true;
}
}
private string closing_balanceDbString
{
get
{
if (this.closing_balance.HasValue)
return closing_balance.ToString();
else
return "null";
}
}
#endregion
#region Withdrawals
private bool withdrawalsChanged = false;
private decimal? withdrawals;
public decimal? Withdrawals
{
get { return withdrawals; }
set { 
withdrawals = value;
withdrawalsChanged = true;
}
}
private string withdrawalsDbString
{
get
{
if (this.withdrawals.HasValue)
return withdrawals.ToString();
else
return "null";
}
}
#endregion
#region PreWithdrawals
private bool pre_withdrawalsChanged = false;
private decimal? pre_withdrawals;
public decimal? PreWithdrawals
{
get { return pre_withdrawals; }
set { 
pre_withdrawals = value;
pre_withdrawalsChanged = true;
}
}
private string pre_withdrawalsDbString
{
get
{
if (this.pre_withdrawals.HasValue)
return pre_withdrawals.ToString();
else
return "null";
}
}
#endregion
#region ReturnAmount
private bool return_amountChanged = false;
private decimal? return_amount;
public decimal? ReturnAmount
{
get { return return_amount; }
set { 
return_amount = value;
return_amountChanged = true;
}
}
private string return_amountDbString
{
get
{
if (this.return_amount.HasValue)
return return_amount.ToString();
else
return "null";
}
}
#endregion
#region ReplenishmentAmount
private bool replenishment_amountChanged = false;
private decimal? replenishment_amount;
public decimal? ReplenishmentAmount
{
get { return replenishment_amount; }
set { 
replenishment_amount = value;
replenishment_amountChanged = true;
}
}
private string replenishment_amountDbString
{
get
{
if (this.replenishment_amount.HasValue)
return replenishment_amount.ToString();
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
#region TrxnDatetime
private bool trxn_datetimeChanged = false;
private DateTime? trxn_datetime;
public DateTime? TrxnDatetime
{
get { return trxn_datetime; }
set { 
trxn_datetime = value;
trxn_datetimeChanged = true;
}
}
private string trxn_datetimeDbString
{
get
{
if (this.trxn_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",trxn_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ProcessingDatetime
private bool processing_datetimeChanged = false;
private DateTime? processing_datetime;
public DateTime? ProcessingDatetime
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
if (this.processing_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",processing_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region NotesRemainingType1
private bool notes_remaining_type1Changed = false;
private int? notes_remaining_type1;
public int? NotesRemainingType1
{
get { return notes_remaining_type1; }
set { 
notes_remaining_type1 = value;
notes_remaining_type1Changed = true;
}
}
private string notes_remaining_type1DbString
{
get
{
if (this.notes_remaining_type1.HasValue)
return notes_remaining_type1.ToString();
else
return "null";
}
}
#endregion
#region NotesRemainingType2
private bool notes_remaining_type2Changed = false;
private int? notes_remaining_type2;
public int? NotesRemainingType2
{
get { return notes_remaining_type2; }
set { 
notes_remaining_type2 = value;
notes_remaining_type2Changed = true;
}
}
private string notes_remaining_type2DbString
{
get
{
if (this.notes_remaining_type2.HasValue)
return notes_remaining_type2.ToString();
else
return "null";
}
}
#endregion
#region NotesRemainingType3
private bool notes_remaining_type3Changed = false;
private int? notes_remaining_type3;
public int? NotesRemainingType3
{
get { return notes_remaining_type3; }
set { 
notes_remaining_type3 = value;
notes_remaining_type3Changed = true;
}
}
private string notes_remaining_type3DbString
{
get
{
if (this.notes_remaining_type3.HasValue)
return notes_remaining_type3.ToString();
else
return "null";
}
}
#endregion
#region NotesRemainingType4
private bool notes_remaining_type4Changed = false;
private int? notes_remaining_type4;
public int? NotesRemainingType4
{
get { return notes_remaining_type4; }
set { 
notes_remaining_type4 = value;
notes_remaining_type4Changed = true;
}
}
private string notes_remaining_type4DbString
{
get
{
if (this.notes_remaining_type4.HasValue)
return notes_remaining_type4.ToString();
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
#region ReturnType1
private bool return_type1Changed = false;
private int? return_type1;
public int? ReturnType1
{
get { return return_type1; }
set { 
return_type1 = value;
return_type1Changed = true;
}
}
private string return_type1DbString
{
get
{
if (this.return_type1.HasValue)
return return_type1.ToString();
else
return "null";
}
}
#endregion
#region ReturnType2
private bool return_type2Changed = false;
private int? return_type2;
public int? ReturnType2
{
get { return return_type2; }
set { 
return_type2 = value;
return_type2Changed = true;
}
}
private string return_type2DbString
{
get
{
if (this.return_type2.HasValue)
return return_type2.ToString();
else
return "null";
}
}
#endregion
#region ReturnType3
private bool return_type3Changed = false;
private int? return_type3;
public int? ReturnType3
{
get { return return_type3; }
set { 
return_type3 = value;
return_type3Changed = true;
}
}
private string return_type3DbString
{
get
{
if (this.return_type3.HasValue)
return return_type3.ToString();
else
return "null";
}
}
#endregion
#region ReturnType4
private bool return_type4Changed = false;
private int? return_type4;
public int? ReturnType4
{
get { return return_type4; }
set { 
return_type4 = value;
return_type4Changed = true;
}
}
private string return_type4DbString
{
get
{
if (this.return_type4.HasValue)
return return_type4.ToString();
else
return "null";
}
}
#endregion
#endregion

#region EjSummaryReader
public class EjSummaryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
EjSummary currentEjSummary;
Columns columns;
bool partialRead = false;
private EjSummaryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public EjSummaryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public EjSummaryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentEjSummary; }

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
currentEjSummary = new EjSummary();
if (partialRead)
{ if ((columns & Columns.ej_summary_id) == Columns.ej_summary_id && reader["ej_summary_id"]!=DBNull.Value)
currentEjSummary.ej_summary_id =(int) reader["ej_summary_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentEjSummary.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.closing_balance) == Columns.closing_balance && reader["closing_balance"]!=DBNull.Value)
currentEjSummary.closing_balance =(decimal?) reader["closing_balance"]; 
if ((columns & Columns.withdrawals) == Columns.withdrawals && reader["withdrawals"]!=DBNull.Value)
currentEjSummary.withdrawals =(decimal?) reader["withdrawals"]; 
if ((columns & Columns.pre_withdrawals) == Columns.pre_withdrawals && reader["pre_withdrawals"]!=DBNull.Value)
currentEjSummary.pre_withdrawals =(decimal?) reader["pre_withdrawals"]; 
if ((columns & Columns.return_amount) == Columns.return_amount && reader["return_amount"]!=DBNull.Value)
currentEjSummary.return_amount =(decimal?) reader["return_amount"]; 
if ((columns & Columns.replenishment_amount) == Columns.replenishment_amount && reader["replenishment_amount"]!=DBNull.Value)
currentEjSummary.replenishment_amount =(decimal?) reader["replenishment_amount"]; 
if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"]!=DBNull.Value)
currentEjSummary.rep_datetime =(DateTime?) reader["rep_datetime"]; 
if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"]!=DBNull.Value)
currentEjSummary.trxn_datetime =(DateTime?) reader["trxn_datetime"]; 
if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
currentEjSummary.processing_datetime =(DateTime?) reader["processing_datetime"]; 
if ((columns & Columns.notes_remaining_type1) == Columns.notes_remaining_type1 && reader["notes_remaining_type1"]!=DBNull.Value)
currentEjSummary.notes_remaining_type1 =(int?) reader["notes_remaining_type1"]; 
if ((columns & Columns.notes_remaining_type2) == Columns.notes_remaining_type2 && reader["notes_remaining_type2"]!=DBNull.Value)
currentEjSummary.notes_remaining_type2 =(int?) reader["notes_remaining_type2"]; 
if ((columns & Columns.notes_remaining_type3) == Columns.notes_remaining_type3 && reader["notes_remaining_type3"]!=DBNull.Value)
currentEjSummary.notes_remaining_type3 =(int?) reader["notes_remaining_type3"]; 
if ((columns & Columns.notes_remaining_type4) == Columns.notes_remaining_type4 && reader["notes_remaining_type4"]!=DBNull.Value)
currentEjSummary.notes_remaining_type4 =(int?) reader["notes_remaining_type4"]; 
if ((columns & Columns.cash_added1) == Columns.cash_added1 && reader["cash_added1"]!=DBNull.Value)
currentEjSummary.cash_added1 =(int?) reader["cash_added1"]; 
if ((columns & Columns.cash_added2) == Columns.cash_added2 && reader["cash_added2"]!=DBNull.Value)
currentEjSummary.cash_added2 =(int?) reader["cash_added2"]; 
if ((columns & Columns.cash_added3) == Columns.cash_added3 && reader["cash_added3"]!=DBNull.Value)
currentEjSummary.cash_added3 =(int?) reader["cash_added3"]; 
if ((columns & Columns.cash_added4) == Columns.cash_added4 && reader["cash_added4"]!=DBNull.Value)
currentEjSummary.cash_added4 =(int?) reader["cash_added4"]; 
if ((columns & Columns.return_type1) == Columns.return_type1 && reader["return_type1"]!=DBNull.Value)
currentEjSummary.return_type1 =(int?) reader["return_type1"]; 
if ((columns & Columns.return_type2) == Columns.return_type2 && reader["return_type2"]!=DBNull.Value)
currentEjSummary.return_type2 =(int?) reader["return_type2"]; 
if ((columns & Columns.return_type3) == Columns.return_type3 && reader["return_type3"]!=DBNull.Value)
currentEjSummary.return_type3 =(int?) reader["return_type3"]; 
if ((columns & Columns.return_type4) == Columns.return_type4 && reader["return_type4"]!=DBNull.Value)
currentEjSummary.return_type4 =(int?) reader["return_type4"]; 

} else
{
if (reader["ej_summary_id"] != DBNull.Value)
currentEjSummary.ej_summary_id = (int) reader["ej_summary_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentEjSummary.atm_id = (int?) reader["atm_id"]; 
if (reader["closing_balance"] != DBNull.Value)
currentEjSummary.closing_balance = (decimal?) reader["closing_balance"]; 
if (reader["withdrawals"] != DBNull.Value)
currentEjSummary.withdrawals = (decimal?) reader["withdrawals"]; 
if (reader["pre_withdrawals"] != DBNull.Value)
currentEjSummary.pre_withdrawals = (decimal?) reader["pre_withdrawals"]; 
if (reader["return_amount"] != DBNull.Value)
currentEjSummary.return_amount = (decimal?) reader["return_amount"]; 
if (reader["replenishment_amount"] != DBNull.Value)
currentEjSummary.replenishment_amount = (decimal?) reader["replenishment_amount"]; 
if (reader["rep_datetime"] != DBNull.Value)
currentEjSummary.rep_datetime = (DateTime?) reader["rep_datetime"]; 
if (reader["trxn_datetime"] != DBNull.Value)
currentEjSummary.trxn_datetime = (DateTime?) reader["trxn_datetime"]; 
if (reader["processing_datetime"] != DBNull.Value)
currentEjSummary.processing_datetime = (DateTime?) reader["processing_datetime"]; 
if (reader["notes_remaining_type1"] != DBNull.Value)
currentEjSummary.notes_remaining_type1 = (int?) reader["notes_remaining_type1"]; 
if (reader["notes_remaining_type2"] != DBNull.Value)
currentEjSummary.notes_remaining_type2 = (int?) reader["notes_remaining_type2"]; 
if (reader["notes_remaining_type3"] != DBNull.Value)
currentEjSummary.notes_remaining_type3 = (int?) reader["notes_remaining_type3"]; 
if (reader["notes_remaining_type4"] != DBNull.Value)
currentEjSummary.notes_remaining_type4 = (int?) reader["notes_remaining_type4"]; 
if (reader["cash_added1"] != DBNull.Value)
currentEjSummary.cash_added1 = (int?) reader["cash_added1"]; 
if (reader["cash_added2"] != DBNull.Value)
currentEjSummary.cash_added2 = (int?) reader["cash_added2"]; 
if (reader["cash_added3"] != DBNull.Value)
currentEjSummary.cash_added3 = (int?) reader["cash_added3"]; 
if (reader["cash_added4"] != DBNull.Value)
currentEjSummary.cash_added4 = (int?) reader["cash_added4"]; 
if (reader["return_type1"] != DBNull.Value)
currentEjSummary.return_type1 = (int?) reader["return_type1"]; 
if (reader["return_type2"] != DBNull.Value)
currentEjSummary.return_type2 = (int?) reader["return_type2"]; 
if (reader["return_type3"] != DBNull.Value)
currentEjSummary.return_type3 = (int?) reader["return_type3"]; 
if (reader["return_type4"] != DBNull.Value)
currentEjSummary.return_type4 = (int?) reader["return_type4"]; 
} 

currentEjSummary.isNewEntity = false;
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

public EjSummary CurrentEjSummary
{
get{ return currentEjSummary; }
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


#region EjSummary functions

public static EjSummaryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.ej_summary_id == (Columns.ej_summary_id & columns))
qry.Append("ej_summary_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.closing_balance == (Columns.closing_balance & columns))
qry.Append("closing_balance,");
if (Columns.withdrawals == (Columns.withdrawals & columns))
qry.Append("withdrawals,");
if (Columns.pre_withdrawals == (Columns.pre_withdrawals & columns))
qry.Append("pre_withdrawals,");
if (Columns.return_amount == (Columns.return_amount & columns))
qry.Append("return_amount,");
if (Columns.replenishment_amount == (Columns.replenishment_amount & columns))
qry.Append("replenishment_amount,");
if (Columns.rep_datetime == (Columns.rep_datetime & columns))
qry.Append("rep_datetime,");
if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
qry.Append("trxn_datetime,");
if (Columns.processing_datetime == (Columns.processing_datetime & columns))
qry.Append("processing_datetime,");
if (Columns.notes_remaining_type1 == (Columns.notes_remaining_type1 & columns))
qry.Append("notes_remaining_type1,");
if (Columns.notes_remaining_type2 == (Columns.notes_remaining_type2 & columns))
qry.Append("notes_remaining_type2,");
if (Columns.notes_remaining_type3 == (Columns.notes_remaining_type3 & columns))
qry.Append("notes_remaining_type3,");
if (Columns.notes_remaining_type4 == (Columns.notes_remaining_type4 & columns))
qry.Append("notes_remaining_type4,");
if (Columns.cash_added1 == (Columns.cash_added1 & columns))
qry.Append("cash_added1,");
if (Columns.cash_added2 == (Columns.cash_added2 & columns))
qry.Append("cash_added2,");
if (Columns.cash_added3 == (Columns.cash_added3 & columns))
qry.Append("cash_added3,");
if (Columns.cash_added4 == (Columns.cash_added4 & columns))
qry.Append("cash_added4,");
if (Columns.return_type1 == (Columns.return_type1 & columns))
qry.Append("return_type1,");
if (Columns.return_type2 == (Columns.return_type2 & columns))
qry.Append("return_type2,");
if (Columns.return_type3 == (Columns.return_type3 & columns))
qry.Append("return_type3,");
if (Columns.return_type4 == (Columns.return_type4 & columns))
qry.Append("return_type4,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ej_summary ");

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
return new EjSummaryReader(cmd.ExecuteReader(), conn, columns);
}

static public EjSummaryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static EjSummaryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select ej_summary_id,atm_id,closing_balance,withdrawals,pre_withdrawals,return_amount,replenishment_amount,rep_datetime,trxn_datetime,processing_datetime,notes_remaining_type1,notes_remaining_type2,notes_remaining_type3,notes_remaining_type4,cash_added1,cash_added2,cash_added3,cash_added4,return_type1,return_type2,return_type3,return_type4 from Ej_summary ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new EjSummaryReader(cmd.ExecuteReader(), conn);
}

static public EjSummaryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static EjSummary LoadEjSummary(string where)
{
EjSummaryReader reader = EjSummary.ExecuteReader(where);
EjSummary _ejsummary = null;
if (reader.Read())
_ejsummary = reader.CurrentEjSummary;
reader.Close();
return _ejsummary;
}

public static EjSummary LoadEjSummary(string where, IDbConnection conn)
{
EjSummaryReader reader = EjSummary.ExecuteReader(where, conn);
EjSummary _ejsummary = null;
if (reader.Read())
_ejsummary = reader.CurrentEjSummary;
reader.Close(false);
return _ejsummary;
}

public static EjSummary LoadEjSummaryByPk( int ej_summary_id )
{
return LoadEjSummary( " ej_summary_id="+ej_summary_id );
}

public static EjSummary LoadEjSummaryByPk( int ej_summary_id , IDbConnection conn)
{
return LoadEjSummary(" ej_summary_id="+ej_summary_id , conn);
}

public void Save()
{
if (ej_summary_idChanged || atm_idChanged || closing_balanceChanged || withdrawalsChanged || pre_withdrawalsChanged || return_amountChanged || replenishment_amountChanged || rep_datetimeChanged || trxn_datetimeChanged || processing_datetimeChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || return_type1Changed || return_type2Changed || return_type3Changed || return_type4Changed )
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
if (ej_summary_idChanged || atm_idChanged || closing_balanceChanged || withdrawalsChanged || pre_withdrawalsChanged || return_amountChanged || replenishment_amountChanged || rep_datetimeChanged || trxn_datetimeChanged || processing_datetimeChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || return_type1Changed || return_type2Changed || return_type3Changed || return_type4Changed )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ej_summary( ej_summary_id,atm_id,closing_balance,withdrawals,pre_withdrawals,return_amount,replenishment_amount,rep_datetime,trxn_datetime,processing_datetime,notes_remaining_type1,notes_remaining_type2,notes_remaining_type3,notes_remaining_type4,cash_added1,cash_added2,cash_added3,cash_added4,return_type1,return_type2,return_type3,return_type4 ) values(");
lock (ConnectionFactory.connectionString) { this.ej_summary_id = ConnectionFactory.GetNextId();
qry.Append(this.ej_summary_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(closing_balanceDbString+",");
qry.Append(withdrawalsDbString+",");
qry.Append(pre_withdrawalsDbString+",");
qry.Append(return_amountDbString+",");
qry.Append(replenishment_amountDbString+",");
qry.Append(rep_datetimeDbString+",");
qry.Append(trxn_datetimeDbString+",");
qry.Append(processing_datetimeDbString+",");
qry.Append(notes_remaining_type1DbString+",");
qry.Append(notes_remaining_type2DbString+",");
qry.Append(notes_remaining_type3DbString+",");
qry.Append(notes_remaining_type4DbString+",");
qry.Append(cash_added1DbString+",");
qry.Append(cash_added2DbString+",");
qry.Append(cash_added3DbString+",");
qry.Append(cash_added4DbString+",");
qry.Append(return_type1DbString+",");
qry.Append(return_type2DbString+",");
qry.Append(return_type3DbString+",");
qry.Append(return_type4DbString);
qry.Append(");");

}
else
{
if (!(ej_summary_idChanged || atm_idChanged || closing_balanceChanged || withdrawalsChanged || pre_withdrawalsChanged || return_amountChanged || replenishment_amountChanged || rep_datetimeChanged || trxn_datetimeChanged || processing_datetimeChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || return_type1Changed || return_type2Changed || return_type3Changed || return_type4Changed ))
return;
qry.Append("UPDATE Ej_summary set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( closing_balanceChanged )
{
qry.Append("closing_balance ="+closing_balanceDbString);
qry.Append(",");
}

if ( withdrawalsChanged )
{
qry.Append("withdrawals ="+withdrawalsDbString);
qry.Append(",");
}

if ( pre_withdrawalsChanged )
{
qry.Append("pre_withdrawals ="+pre_withdrawalsDbString);
qry.Append(",");
}

if ( return_amountChanged )
{
qry.Append("return_amount ="+return_amountDbString);
qry.Append(",");
}

if ( replenishment_amountChanged )
{
qry.Append("replenishment_amount ="+replenishment_amountDbString);
qry.Append(",");
}

if ( rep_datetimeChanged )
{
qry.Append("rep_datetime ="+rep_datetimeDbString);
qry.Append(",");
}

if ( trxn_datetimeChanged )
{
qry.Append("trxn_datetime ="+trxn_datetimeDbString);
qry.Append(",");
}

if ( processing_datetimeChanged )
{
qry.Append("processing_datetime ="+processing_datetimeDbString);
qry.Append(",");
}

if ( notes_remaining_type1Changed )
{
qry.Append("notes_remaining_type1 ="+notes_remaining_type1DbString);
qry.Append(",");
}

if ( notes_remaining_type2Changed )
{
qry.Append("notes_remaining_type2 ="+notes_remaining_type2DbString);
qry.Append(",");
}

if ( notes_remaining_type3Changed )
{
qry.Append("notes_remaining_type3 ="+notes_remaining_type3DbString);
qry.Append(",");
}

if ( notes_remaining_type4Changed )
{
qry.Append("notes_remaining_type4 ="+notes_remaining_type4DbString);
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

if ( return_type1Changed )
{
qry.Append("return_type1 ="+return_type1DbString);
qry.Append(",");
}

if ( return_type2Changed )
{
qry.Append("return_type2 ="+return_type2DbString);
qry.Append(",");
}

if ( return_type3Changed )
{
qry.Append("return_type3 ="+return_type3DbString);
qry.Append(",");
}

if ( return_type4Changed )
{
qry.Append("return_type4 ="+return_type4DbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("ej_summary_id = "+ej_summary_idDbString);
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
cmd.CommandText = "DELETE Ej_summary where ej_summary_id = "+ ej_summary_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteEjSummarys(string where)
{
ConnectionFactory.ExecuteQuery("delete Ej_summary where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
ej_summary_id= 1,
atm_id= 2,
closing_balance= 4,
withdrawals= 8,
pre_withdrawals= 16,
return_amount= 32,
replenishment_amount= 64,
rep_datetime= 128,
trxn_datetime= 256,
processing_datetime= 512,
notes_remaining_type1= 1024,
notes_remaining_type2= 2048,
notes_remaining_type3= 4096,
notes_remaining_type4= 8192,
cash_added1= 16384,
cash_added2= 32768,
cash_added3= 65536,
cash_added4= 131072,
return_type1= 262144,
return_type2= 524288,
return_type3= 1048576,
return_type4= 2097152
}
#endregion
public void BulkSave(List<EjSummary> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ej_summary";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(EjSummary.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <EjSummary> transList,ref DataTable dt)
{
foreach (EjSummary tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["ej_summary_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["closing_balance"] = tran.ClosingBalance;
Row["withdrawals"] = tran.Withdrawals;
Row["pre_withdrawals"] = tran.PreWithdrawals;
Row["return_amount"] = tran.ReturnAmount;
Row["replenishment_amount"] = tran.ReplenishmentAmount;
Row["rep_datetime"] = tran.RepDatetime;
Row["trxn_datetime"] = tran.TrxnDatetime;
Row["processing_datetime"] = tran.ProcessingDatetime;
Row["notes_remaining_type1"] = tran.NotesRemainingType1;
Row["notes_remaining_type2"] = tran.NotesRemainingType2;
Row["notes_remaining_type3"] = tran.NotesRemainingType3;
Row["notes_remaining_type4"] = tran.NotesRemainingType4;
Row["cash_added1"] = tran.CashAdded1;
Row["cash_added2"] = tran.CashAdded2;
Row["cash_added3"] = tran.CashAdded3;
Row["cash_added4"] = tran.CashAdded4;
Row["return_type1"] = tran.ReturnType1;
Row["return_type2"] = tran.ReturnType2;
Row["return_type3"] = tran.ReturnType3;
Row["return_type4"] = tran.ReturnType4;
dt.Rows.Add(Row);
} }
}
}
