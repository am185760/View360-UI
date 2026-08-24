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
public class VaultSummaryByCit
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public VaultSummaryByCit() { }
public VaultSummaryByCit( int vault_summary_by_cit_id,int vault_id,DateTime generated_at,DateTime vault_summary_date,int uploaded_by ) 
{
this.vault_id = vault_id;
this.vault_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.vault_summary_date = vault_summary_date;
this.vault_summary_dateChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
}
public VaultSummaryByCit( string denomination_name,int? opening_balance,int? bad_notes_sent_to_bank,int? substitution_recieved_from_bank,int? new_opening_balance,int? cash_recieved_from_bank,int? cash_delivered_to_atm,int? cash_returned_from_atm,int? unfit_notes,int? closing_balance,decimal? cash_value,int vault_id,DateTime generated_at,DateTime vault_summary_date,int uploaded_by )
{
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.bad_notes_sent_to_bank = bad_notes_sent_to_bank;
this.bad_notes_sent_to_bankChanged = true;
this.substitution_recieved_from_bank = substitution_recieved_from_bank;
this.substitution_recieved_from_bankChanged = true;
this.new_opening_balance = new_opening_balance;
this.new_opening_balanceChanged = true;
this.cash_recieved_from_bank = cash_recieved_from_bank;
this.cash_recieved_from_bankChanged = true;
this.cash_delivered_to_atm = cash_delivered_to_atm;
this.cash_delivered_to_atmChanged = true;
this.cash_returned_from_atm = cash_returned_from_atm;
this.cash_returned_from_atmChanged = true;
this.unfit_notes = unfit_notes;
this.unfit_notesChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.cash_value = cash_value;
this.cash_valueChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.vault_summary_date = vault_summary_date;
this.vault_summary_dateChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
}
private VaultSummaryByCit( int vault_summary_by_cit_id,string denomination_name,int? opening_balance,int? bad_notes_sent_to_bank,int? substitution_recieved_from_bank,int? new_opening_balance,int? cash_recieved_from_bank,int? cash_delivered_to_atm,int? cash_returned_from_atm,int? unfit_notes,int? closing_balance,decimal? cash_value,int vault_id,DateTime generated_at,DateTime vault_summary_date,int uploaded_by )
{
this.vault_summary_by_cit_id = vault_summary_by_cit_id;
this.vault_summary_by_cit_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.opening_balance = opening_balance;
this.opening_balanceChanged = true;
this.bad_notes_sent_to_bank = bad_notes_sent_to_bank;
this.bad_notes_sent_to_bankChanged = true;
this.substitution_recieved_from_bank = substitution_recieved_from_bank;
this.substitution_recieved_from_bankChanged = true;
this.new_opening_balance = new_opening_balance;
this.new_opening_balanceChanged = true;
this.cash_recieved_from_bank = cash_recieved_from_bank;
this.cash_recieved_from_bankChanged = true;
this.cash_delivered_to_atm = cash_delivered_to_atm;
this.cash_delivered_to_atmChanged = true;
this.cash_returned_from_atm = cash_returned_from_atm;
this.cash_returned_from_atmChanged = true;
this.unfit_notes = unfit_notes;
this.unfit_notesChanged = true;
this.closing_balance = closing_balance;
this.closing_balanceChanged = true;
this.cash_value = cash_value;
this.cash_valueChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.vault_summary_date = vault_summary_date;
this.vault_summary_dateChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
}

#region members and properties for columns

#region VaultSummaryByCitId
private bool vault_summary_by_cit_idChanged = false;
private int vault_summary_by_cit_id;
public int VaultSummaryByCitId
{
get { return vault_summary_by_cit_id; }
set { 
vault_summary_by_cit_id = value;
vault_summary_by_cit_idChanged = true;
}
}
private string vault_summary_by_cit_idDbString
{
get
{
return vault_summary_by_cit_id.ToString();
}
}
#endregion
#region DenominationName
private bool denomination_nameChanged = false;
private string denomination_name;
public string DenominationName
{
get { return denomination_name; }
set { 
denomination_name = value;
denomination_nameChanged = true;
}
}
private string denomination_nameDbString
{
get
{
if (this.denomination_name!=null)
return string.Format("'{0}'",denomination_name); else
return "null";
}
}
#endregion
#region OpeningBalance
private bool opening_balanceChanged = false;
private int? opening_balance;
public int? OpeningBalance
{
get { return opening_balance; }
set { 
opening_balance = value;
opening_balanceChanged = true;
}
}
private string opening_balanceDbString
{
get
{
if (this.opening_balance.HasValue)
return opening_balance.ToString();
else
return "null";
}
}
#endregion
#region BadNotesSentToBank
private bool bad_notes_sent_to_bankChanged = false;
private int? bad_notes_sent_to_bank;
public int? BadNotesSentToBank
{
get { return bad_notes_sent_to_bank; }
set { 
bad_notes_sent_to_bank = value;
bad_notes_sent_to_bankChanged = true;
}
}
private string bad_notes_sent_to_bankDbString
{
get
{
if (this.bad_notes_sent_to_bank.HasValue)
return bad_notes_sent_to_bank.ToString();
else
return "null";
}
}
#endregion
#region SubstitutionRecievedFromBank
private bool substitution_recieved_from_bankChanged = false;
private int? substitution_recieved_from_bank;
public int? SubstitutionRecievedFromBank
{
get { return substitution_recieved_from_bank; }
set { 
substitution_recieved_from_bank = value;
substitution_recieved_from_bankChanged = true;
}
}
private string substitution_recieved_from_bankDbString
{
get
{
if (this.substitution_recieved_from_bank.HasValue)
return substitution_recieved_from_bank.ToString();
else
return "null";
}
}
#endregion
#region NewOpeningBalance
private bool new_opening_balanceChanged = false;
private int? new_opening_balance;
public int? NewOpeningBalance
{
get { return new_opening_balance; }
set { 
new_opening_balance = value;
new_opening_balanceChanged = true;
}
}
private string new_opening_balanceDbString
{
get
{
if (this.new_opening_balance.HasValue)
return new_opening_balance.ToString();
else
return "null";
}
}
#endregion
#region CashRecievedFromBank
private bool cash_recieved_from_bankChanged = false;
private int? cash_recieved_from_bank;
public int? CashRecievedFromBank
{
get { return cash_recieved_from_bank; }
set { 
cash_recieved_from_bank = value;
cash_recieved_from_bankChanged = true;
}
}
private string cash_recieved_from_bankDbString
{
get
{
if (this.cash_recieved_from_bank.HasValue)
return cash_recieved_from_bank.ToString();
else
return "null";
}
}
#endregion
#region CashDeliveredToAtm
private bool cash_delivered_to_atmChanged = false;
private int? cash_delivered_to_atm;
public int? CashDeliveredToAtm
{
get { return cash_delivered_to_atm; }
set { 
cash_delivered_to_atm = value;
cash_delivered_to_atmChanged = true;
}
}
private string cash_delivered_to_atmDbString
{
get
{
if (this.cash_delivered_to_atm.HasValue)
return cash_delivered_to_atm.ToString();
else
return "null";
}
}
#endregion
#region CashReturnedFromAtm
private bool cash_returned_from_atmChanged = false;
private int? cash_returned_from_atm;
public int? CashReturnedFromAtm
{
get { return cash_returned_from_atm; }
set { 
cash_returned_from_atm = value;
cash_returned_from_atmChanged = true;
}
}
private string cash_returned_from_atmDbString
{
get
{
if (this.cash_returned_from_atm.HasValue)
return cash_returned_from_atm.ToString();
else
return "null";
}
}
#endregion
#region UnfitNotes
private bool unfit_notesChanged = false;
private int? unfit_notes;
public int? UnfitNotes
{
get { return unfit_notes; }
set { 
unfit_notes = value;
unfit_notesChanged = true;
}
}
private string unfit_notesDbString
{
get
{
if (this.unfit_notes.HasValue)
return unfit_notes.ToString();
else
return "null";
}
}
#endregion
#region ClosingBalance
private bool closing_balanceChanged = false;
private int? closing_balance;
public int? ClosingBalance
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
#region CashValue
private bool cash_valueChanged = false;
private decimal? cash_value;
public decimal? CashValue
{
get { return cash_value; }
set { 
cash_value = value;
cash_valueChanged = true;
}
}
private string cash_valueDbString
{
get
{
if (this.cash_value.HasValue)
return cash_value.ToString();
else
return "null";
}
}
#endregion
#region VaultId
private bool vault_idChanged = false;
private int vault_id;
public int VaultId
{
get { return vault_id; }
set { 
vault_id = value;
vault_idChanged = true;
}
}
private string vault_idDbString
{
get
{
return vault_id.ToString();
}
}
#endregion
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime generated_at;
public DateTime GeneratedAt
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
return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region VaultSummaryDate
private bool vault_summary_dateChanged = false;
private DateTime vault_summary_date;
public DateTime VaultSummaryDate
{
get { return vault_summary_date; }
set { 
vault_summary_date = value;
vault_summary_dateChanged = true;
}
}
private string vault_summary_dateDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",vault_summary_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region UploadedBy
private bool uploaded_byChanged = false;
private int uploaded_by;
public int UploadedBy
{
get { return uploaded_by; }
set { 
uploaded_by = value;
uploaded_byChanged = true;
}
}
private string uploaded_byDbString
{
get
{
return uploaded_by.ToString();
}
}
#endregion
#endregion

#region VaultSummaryByCitReader
public class VaultSummaryByCitReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
VaultSummaryByCit currentVaultSummaryByCit;
Columns columns;
bool partialRead = false;
private VaultSummaryByCitReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public VaultSummaryByCitReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public VaultSummaryByCitReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentVaultSummaryByCit; }

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
currentVaultSummaryByCit = new VaultSummaryByCit();
if (partialRead)
{ if ((columns & Columns.vault_summary_by_cit_id) == Columns.vault_summary_by_cit_id && reader["vault_summary_by_cit_id"]!=DBNull.Value)
currentVaultSummaryByCit.vault_summary_by_cit_id =(int) reader["vault_summary_by_cit_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentVaultSummaryByCit.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.opening_balance) == Columns.opening_balance && reader["opening_balance"]!=DBNull.Value)
currentVaultSummaryByCit.opening_balance =(int?) reader["opening_balance"]; 
if ((columns & Columns.bad_notes_sent_to_bank) == Columns.bad_notes_sent_to_bank && reader["bad_notes_sent_to_bank"]!=DBNull.Value)
currentVaultSummaryByCit.bad_notes_sent_to_bank =(int?) reader["bad_notes_sent_to_bank"]; 
if ((columns & Columns.substitution_recieved_from_bank) == Columns.substitution_recieved_from_bank && reader["substitution_recieved_from_bank"]!=DBNull.Value)
currentVaultSummaryByCit.substitution_recieved_from_bank =(int?) reader["substitution_recieved_from_bank"]; 
if ((columns & Columns.new_opening_balance) == Columns.new_opening_balance && reader["new_opening_balance"]!=DBNull.Value)
currentVaultSummaryByCit.new_opening_balance =(int?) reader["new_opening_balance"]; 
if ((columns & Columns.cash_recieved_from_bank) == Columns.cash_recieved_from_bank && reader["cash_recieved_from_bank"]!=DBNull.Value)
currentVaultSummaryByCit.cash_recieved_from_bank =(int?) reader["cash_recieved_from_bank"]; 
if ((columns & Columns.cash_delivered_to_atm) == Columns.cash_delivered_to_atm && reader["cash_delivered_to_atm"]!=DBNull.Value)
currentVaultSummaryByCit.cash_delivered_to_atm =(int?) reader["cash_delivered_to_atm"]; 
if ((columns & Columns.cash_returned_from_atm) == Columns.cash_returned_from_atm && reader["cash_returned_from_atm"]!=DBNull.Value)
currentVaultSummaryByCit.cash_returned_from_atm =(int?) reader["cash_returned_from_atm"]; 
if ((columns & Columns.unfit_notes) == Columns.unfit_notes && reader["unfit_notes"]!=DBNull.Value)
currentVaultSummaryByCit.unfit_notes =(int?) reader["unfit_notes"]; 
if ((columns & Columns.closing_balance) == Columns.closing_balance && reader["closing_balance"]!=DBNull.Value)
currentVaultSummaryByCit.closing_balance =(int?) reader["closing_balance"]; 
if ((columns & Columns.cash_value) == Columns.cash_value && reader["cash_value"]!=DBNull.Value)
currentVaultSummaryByCit.cash_value =(decimal?) reader["cash_value"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentVaultSummaryByCit.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentVaultSummaryByCit.generated_at =(DateTime) reader["generated_at"]; 
if ((columns & Columns.vault_summary_date) == Columns.vault_summary_date && reader["vault_summary_date"]!=DBNull.Value)
currentVaultSummaryByCit.vault_summary_date =(DateTime) reader["vault_summary_date"]; 
if ((columns & Columns.uploaded_by) == Columns.uploaded_by && reader["uploaded_by"]!=DBNull.Value)
currentVaultSummaryByCit.uploaded_by =(int) reader["uploaded_by"]; 

} else
{
if (reader["vault_summary_by_cit_id"] != DBNull.Value)
currentVaultSummaryByCit.vault_summary_by_cit_id = (int) reader["vault_summary_by_cit_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentVaultSummaryByCit.denomination_name = (string) reader["denomination_name"]; 
if (reader["opening_balance"] != DBNull.Value)
currentVaultSummaryByCit.opening_balance = (int?) reader["opening_balance"]; 
if (reader["bad_notes_sent_to_bank"] != DBNull.Value)
currentVaultSummaryByCit.bad_notes_sent_to_bank = (int?) reader["bad_notes_sent_to_bank"]; 
if (reader["substitution_recieved_from_bank"] != DBNull.Value)
currentVaultSummaryByCit.substitution_recieved_from_bank = (int?) reader["substitution_recieved_from_bank"]; 
if (reader["new_opening_balance"] != DBNull.Value)
currentVaultSummaryByCit.new_opening_balance = (int?) reader["new_opening_balance"]; 
if (reader["cash_recieved_from_bank"] != DBNull.Value)
currentVaultSummaryByCit.cash_recieved_from_bank = (int?) reader["cash_recieved_from_bank"]; 
if (reader["cash_delivered_to_atm"] != DBNull.Value)
currentVaultSummaryByCit.cash_delivered_to_atm = (int?) reader["cash_delivered_to_atm"]; 
if (reader["cash_returned_from_atm"] != DBNull.Value)
currentVaultSummaryByCit.cash_returned_from_atm = (int?) reader["cash_returned_from_atm"]; 
if (reader["unfit_notes"] != DBNull.Value)
currentVaultSummaryByCit.unfit_notes = (int?) reader["unfit_notes"]; 
if (reader["closing_balance"] != DBNull.Value)
currentVaultSummaryByCit.closing_balance = (int?) reader["closing_balance"]; 
if (reader["cash_value"] != DBNull.Value)
currentVaultSummaryByCit.cash_value = (decimal?) reader["cash_value"]; 
if (reader["vault_id"] != DBNull.Value)
currentVaultSummaryByCit.vault_id = (int) reader["vault_id"]; 
if (reader["generated_at"] != DBNull.Value)
currentVaultSummaryByCit.generated_at = (DateTime) reader["generated_at"]; 
if (reader["vault_summary_date"] != DBNull.Value)
currentVaultSummaryByCit.vault_summary_date = (DateTime) reader["vault_summary_date"]; 
if (reader["uploaded_by"] != DBNull.Value)
currentVaultSummaryByCit.uploaded_by = (int) reader["uploaded_by"]; 
} 

currentVaultSummaryByCit.isNewEntity = false;
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

public VaultSummaryByCit CurrentVaultSummaryByCit
{
get{ return currentVaultSummaryByCit; }
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


#region VaultSummaryByCit functions

public static VaultSummaryByCitReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.vault_summary_by_cit_id == (Columns.vault_summary_by_cit_id & columns))
qry.Append("vault_summary_by_cit_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.opening_balance == (Columns.opening_balance & columns))
qry.Append("opening_balance,");
if (Columns.bad_notes_sent_to_bank == (Columns.bad_notes_sent_to_bank & columns))
qry.Append("bad_notes_sent_to_bank,");
if (Columns.substitution_recieved_from_bank == (Columns.substitution_recieved_from_bank & columns))
qry.Append("substitution_recieved_from_bank,");
if (Columns.new_opening_balance == (Columns.new_opening_balance & columns))
qry.Append("new_opening_balance,");
if (Columns.cash_recieved_from_bank == (Columns.cash_recieved_from_bank & columns))
qry.Append("cash_recieved_from_bank,");
if (Columns.cash_delivered_to_atm == (Columns.cash_delivered_to_atm & columns))
qry.Append("cash_delivered_to_atm,");
if (Columns.cash_returned_from_atm == (Columns.cash_returned_from_atm & columns))
qry.Append("cash_returned_from_atm,");
if (Columns.unfit_notes == (Columns.unfit_notes & columns))
qry.Append("unfit_notes,");
if (Columns.closing_balance == (Columns.closing_balance & columns))
qry.Append("closing_balance,");
if (Columns.cash_value == (Columns.cash_value & columns))
qry.Append("cash_value,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.vault_summary_date == (Columns.vault_summary_date & columns))
qry.Append("vault_summary_date,");
if (Columns.uploaded_by == (Columns.uploaded_by & columns))
qry.Append("uploaded_by,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Vault_summary_by_cit ");

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
return new VaultSummaryByCitReader(cmd.ExecuteReader(), conn, columns);
}

static public VaultSummaryByCitReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static VaultSummaryByCitReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select vault_summary_by_cit_id,denomination_name,opening_balance,bad_notes_sent_to_bank,substitution_recieved_from_bank,new_opening_balance,cash_recieved_from_bank,cash_delivered_to_atm,cash_returned_from_atm,unfit_notes,closing_balance,cash_value,vault_id,generated_at,vault_summary_date,uploaded_by from Vault_summary_by_cit ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new VaultSummaryByCitReader(cmd.ExecuteReader(), conn);
}

static public VaultSummaryByCitReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static VaultSummaryByCit LoadVaultSummaryByCit(string where)
{
VaultSummaryByCitReader reader = VaultSummaryByCit.ExecuteReader(where);
VaultSummaryByCit _vaultsummarybycit = null;
if (reader.Read())
_vaultsummarybycit = reader.CurrentVaultSummaryByCit;
reader.Close();
return _vaultsummarybycit;
}

public static VaultSummaryByCit LoadVaultSummaryByCit(string where, IDbConnection conn)
{
VaultSummaryByCitReader reader = VaultSummaryByCit.ExecuteReader(where, conn);
VaultSummaryByCit _vaultsummarybycit = null;
if (reader.Read())
_vaultsummarybycit = reader.CurrentVaultSummaryByCit;
reader.Close(false);
return _vaultsummarybycit;
}

public static VaultSummaryByCit LoadVaultSummaryByCitByPk( int vault_summary_by_cit_id )
{
return LoadVaultSummaryByCit( " vault_summary_by_cit_id="+vault_summary_by_cit_id );
}

public static VaultSummaryByCit LoadVaultSummaryByCitByPk( int vault_summary_by_cit_id , IDbConnection conn)
{
return LoadVaultSummaryByCit(" vault_summary_by_cit_id="+vault_summary_by_cit_id , conn);
}

public void Save()
{
if (vault_summary_by_cit_idChanged || denomination_nameChanged || opening_balanceChanged || bad_notes_sent_to_bankChanged || substitution_recieved_from_bankChanged || new_opening_balanceChanged || cash_recieved_from_bankChanged || cash_delivered_to_atmChanged || cash_returned_from_atmChanged || unfit_notesChanged || closing_balanceChanged || cash_valueChanged || vault_idChanged || generated_atChanged || vault_summary_dateChanged || uploaded_byChanged )
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
if (vault_summary_by_cit_idChanged || denomination_nameChanged || opening_balanceChanged || bad_notes_sent_to_bankChanged || substitution_recieved_from_bankChanged || new_opening_balanceChanged || cash_recieved_from_bankChanged || cash_delivered_to_atmChanged || cash_returned_from_atmChanged || unfit_notesChanged || closing_balanceChanged || cash_valueChanged || vault_idChanged || generated_atChanged || vault_summary_dateChanged || uploaded_byChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Vault_summary_by_cit( vault_summary_by_cit_id,denomination_name,opening_balance,bad_notes_sent_to_bank,substitution_recieved_from_bank,new_opening_balance,cash_recieved_from_bank,cash_delivered_to_atm,cash_returned_from_atm,unfit_notes,closing_balance,cash_value,vault_id,generated_at,vault_summary_date,uploaded_by ) values(");
lock (ConnectionFactory.connectionString) { this.vault_summary_by_cit_id = ConnectionFactory.GetNextId();
qry.Append(this.vault_summary_by_cit_id);
} qry.Append(",");
qry.Append(denomination_nameDbString+",");
qry.Append(opening_balanceDbString+",");
qry.Append(bad_notes_sent_to_bankDbString+",");
qry.Append(substitution_recieved_from_bankDbString+",");
qry.Append(new_opening_balanceDbString+",");
qry.Append(cash_recieved_from_bankDbString+",");
qry.Append(cash_delivered_to_atmDbString+",");
qry.Append(cash_returned_from_atmDbString+",");
qry.Append(unfit_notesDbString+",");
qry.Append(closing_balanceDbString+",");
qry.Append(cash_valueDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(vault_summary_dateDbString+",");
qry.Append(uploaded_byDbString);
qry.Append(");");

}
else
{
if (!(vault_summary_by_cit_idChanged || denomination_nameChanged || opening_balanceChanged || bad_notes_sent_to_bankChanged || substitution_recieved_from_bankChanged || new_opening_balanceChanged || cash_recieved_from_bankChanged || cash_delivered_to_atmChanged || cash_returned_from_atmChanged || unfit_notesChanged || closing_balanceChanged || cash_valueChanged || vault_idChanged || generated_atChanged || vault_summary_dateChanged || uploaded_byChanged ))
return;
qry.Append("UPDATE Vault_summary_by_cit set "); if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( opening_balanceChanged )
{
qry.Append("opening_balance ="+opening_balanceDbString);
qry.Append(",");
}

if ( bad_notes_sent_to_bankChanged )
{
qry.Append("bad_notes_sent_to_bank ="+bad_notes_sent_to_bankDbString);
qry.Append(",");
}

if ( substitution_recieved_from_bankChanged )
{
qry.Append("substitution_recieved_from_bank ="+substitution_recieved_from_bankDbString);
qry.Append(",");
}

if ( new_opening_balanceChanged )
{
qry.Append("new_opening_balance ="+new_opening_balanceDbString);
qry.Append(",");
}

if ( cash_recieved_from_bankChanged )
{
qry.Append("cash_recieved_from_bank ="+cash_recieved_from_bankDbString);
qry.Append(",");
}

if ( cash_delivered_to_atmChanged )
{
qry.Append("cash_delivered_to_atm ="+cash_delivered_to_atmDbString);
qry.Append(",");
}

if ( cash_returned_from_atmChanged )
{
qry.Append("cash_returned_from_atm ="+cash_returned_from_atmDbString);
qry.Append(",");
}

if ( unfit_notesChanged )
{
qry.Append("unfit_notes ="+unfit_notesDbString);
qry.Append(",");
}

if ( closing_balanceChanged )
{
qry.Append("closing_balance ="+closing_balanceDbString);
qry.Append(",");
}

if ( cash_valueChanged )
{
qry.Append("cash_value ="+cash_valueDbString);
qry.Append(",");
}

if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( vault_summary_dateChanged )
{
qry.Append("vault_summary_date ="+vault_summary_dateDbString);
qry.Append(",");
}

if ( uploaded_byChanged )
{
qry.Append("uploaded_by ="+uploaded_byDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("vault_summary_by_cit_id = "+vault_summary_by_cit_idDbString);
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
cmd.CommandText = "DELETE Vault_summary_by_cit where vault_summary_by_cit_id = "+ vault_summary_by_cit_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteVaultSummaryByCits(string where)
{
ConnectionFactory.ExecuteQuery("delete Vault_summary_by_cit where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
vault_summary_by_cit_id= 1,
denomination_name= 2,
opening_balance= 4,
bad_notes_sent_to_bank= 8,
substitution_recieved_from_bank= 16,
new_opening_balance= 32,
cash_recieved_from_bank= 64,
cash_delivered_to_atm= 128,
cash_returned_from_atm= 256,
unfit_notes= 512,
closing_balance= 1024,
cash_value= 2048,
vault_id= 4096,
generated_at= 8192,
vault_summary_date= 16384,
uploaded_by= 32768
}
#endregion
public void BulkSave(List<VaultSummaryByCit> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Vault_summary_by_cit";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(VaultSummaryByCit.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <VaultSummaryByCit> transList,ref DataTable dt)
{
foreach (VaultSummaryByCit tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["vault_summary_by_cit_id"] =ConnectionFactory.GetNextId();
Row["denomination_name"] = tran.DenominationName;
Row["opening_balance"] = tran.OpeningBalance;
Row["bad_notes_sent_to_bank"] = tran.BadNotesSentToBank;
Row["substitution_recieved_from_bank"] = tran.SubstitutionRecievedFromBank;
Row["new_opening_balance"] = tran.NewOpeningBalance;
Row["cash_recieved_from_bank"] = tran.CashRecievedFromBank;
Row["cash_delivered_to_atm"] = tran.CashDeliveredToAtm;
Row["cash_returned_from_atm"] = tran.CashReturnedFromAtm;
Row["unfit_notes"] = tran.UnfitNotes;
Row["closing_balance"] = tran.ClosingBalance;
Row["cash_value"] = tran.CashValue;
Row["vault_id"] = tran.VaultId;
Row["generated_at"] = tran.GeneratedAt;
Row["vault_summary_date"] = tran.VaultSummaryDate;
Row["uploaded_by"] = tran.UploadedBy;
dt.Rows.Add(Row);
} }
}
}
