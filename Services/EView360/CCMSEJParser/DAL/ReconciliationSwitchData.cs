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
public class ReconciliationSwitchData
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReconciliationSwitchData() { }
public ReconciliationSwitchData( int reconciliation_switch_data_id,int reconciliation_batch_id,string atm_id,string card_number,string transaction_date,string transaction_time ) 
{
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.card_number = card_number;
this.card_numberChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.transaction_time = transaction_time;
this.transaction_timeChanged = true;
}
public ReconciliationSwitchData( int reconciliation_batch_id,string atm_id,string card_number,string customer_account_no,string transaction_date,string transaction_time,decimal? transaction_amount,string transaction_currency,string transaction_sequence,string transaction_type,string transaction_response,DateTime? transaction_settlement_date,string card_network,string card_issuer )
{
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.card_number = card_number;
this.card_numberChanged = true;
this.customer_account_no = customer_account_no;
this.customer_account_noChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.transaction_time = transaction_time;
this.transaction_timeChanged = true;
this.transaction_amount = transaction_amount;
this.transaction_amountChanged = true;
this.transaction_currency = transaction_currency;
this.transaction_currencyChanged = true;
this.transaction_sequence = transaction_sequence;
this.transaction_sequenceChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.transaction_response = transaction_response;
this.transaction_responseChanged = true;
this.transaction_settlement_date = transaction_settlement_date;
this.transaction_settlement_dateChanged = true;
this.card_network = card_network;
this.card_networkChanged = true;
this.card_issuer = card_issuer;
this.card_issuerChanged = true;
}
private ReconciliationSwitchData( int reconciliation_switch_data_id,int reconciliation_batch_id,string atm_id,string card_number,string customer_account_no,string transaction_date,string transaction_time,decimal? transaction_amount,string transaction_currency,string transaction_sequence,string transaction_type,string transaction_response,DateTime? transaction_settlement_date,string card_network,string card_issuer )
{
this.reconciliation_switch_data_id = reconciliation_switch_data_id;
this.reconciliation_switch_data_idChanged = true;
this.reconciliation_batch_id = reconciliation_batch_id;
this.reconciliation_batch_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.card_number = card_number;
this.card_numberChanged = true;
this.customer_account_no = customer_account_no;
this.customer_account_noChanged = true;
this.transaction_date = transaction_date;
this.transaction_dateChanged = true;
this.transaction_time = transaction_time;
this.transaction_timeChanged = true;
this.transaction_amount = transaction_amount;
this.transaction_amountChanged = true;
this.transaction_currency = transaction_currency;
this.transaction_currencyChanged = true;
this.transaction_sequence = transaction_sequence;
this.transaction_sequenceChanged = true;
this.transaction_type = transaction_type;
this.transaction_typeChanged = true;
this.transaction_response = transaction_response;
this.transaction_responseChanged = true;
this.transaction_settlement_date = transaction_settlement_date;
this.transaction_settlement_dateChanged = true;
this.card_network = card_network;
this.card_networkChanged = true;
this.card_issuer = card_issuer;
this.card_issuerChanged = true;
}

#region members and properties for columns

#region ReconciliationSwitchDataId
private bool reconciliation_switch_data_idChanged = false;
private int reconciliation_switch_data_id;
public int ReconciliationSwitchDataId
{
get { return reconciliation_switch_data_id; }
set { 
reconciliation_switch_data_id = value;
reconciliation_switch_data_idChanged = true;
}
}
private string reconciliation_switch_data_idDbString
{
get
{
return reconciliation_switch_data_id.ToString();
}
}
#endregion
#region ReconciliationBatchId
private bool reconciliation_batch_idChanged = false;
private int reconciliation_batch_id;
public int ReconciliationBatchId
{
get { return reconciliation_batch_id; }
set { 
reconciliation_batch_id = value;
reconciliation_batch_idChanged = true;
}
}
private string reconciliation_batch_idDbString
{
get
{
return reconciliation_batch_id.ToString();
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private string atm_id;
public string AtmId
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
if (this.atm_id!=null)
return string.Format("'{0}'",atm_id); else
return "null";
}
}
#endregion
#region CardNumber
private bool card_numberChanged = false;
private string card_number;
public string CardNumber
{
get { return card_number; }
set { 
card_number = value;
card_numberChanged = true;
}
}
private string card_numberDbString
{
get
{
if (this.card_number!=null)
return string.Format("'{0}'",card_number); else
return "null";
}
}
#endregion
#region CustomerAccountNo
private bool customer_account_noChanged = false;
private string customer_account_no;
public string CustomerAccountNo
{
get { return customer_account_no; }
set { 
customer_account_no = value;
customer_account_noChanged = true;
}
}
private string customer_account_noDbString
{
get
{
if (this.customer_account_no!=null)
return string.Format("'{0}'",customer_account_no); else
return "null";
}
}
#endregion
#region TransactionDate
private bool transaction_dateChanged = false;
private string transaction_date;
public string TransactionDate
{
get { return transaction_date; }
set { 
transaction_date = value;
transaction_dateChanged = true;
}
}
private string transaction_dateDbString
{
get
{
if (this.transaction_date!=null)
return string.Format("'{0}'",transaction_date); else
return "null";
}
}
#endregion
#region TransactionTime
private bool transaction_timeChanged = false;
private string transaction_time;
public string TransactionTime
{
get { return transaction_time; }
set { 
transaction_time = value;
transaction_timeChanged = true;
}
}
private string transaction_timeDbString
{
get
{
if (this.transaction_time!=null)
return string.Format("'{0}'",transaction_time); else
return "null";
}
}
#endregion
#region TransactionAmount
private bool transaction_amountChanged = false;
private decimal? transaction_amount;
public decimal? TransactionAmount
{
get { return transaction_amount; }
set { 
transaction_amount = value;
transaction_amountChanged = true;
}
}
private string transaction_amountDbString
{
get
{
if (this.transaction_amount.HasValue)
return transaction_amount.ToString();
else
return "null";
}
}
#endregion
#region TransactionCurrency
private bool transaction_currencyChanged = false;
private string transaction_currency;
public string TransactionCurrency
{
get { return transaction_currency; }
set { 
transaction_currency = value;
transaction_currencyChanged = true;
}
}
private string transaction_currencyDbString
{
get
{
if (this.transaction_currency!=null)
return string.Format("'{0}'",transaction_currency); else
return "null";
}
}
#endregion
#region TransactionSequence
private bool transaction_sequenceChanged = false;
private string transaction_sequence;
public string TransactionSequence
{
get { return transaction_sequence; }
set { 
transaction_sequence = value;
transaction_sequenceChanged = true;
}
}
private string transaction_sequenceDbString
{
get
{
if (this.transaction_sequence!=null)
return string.Format("'{0}'",transaction_sequence); else
return "null";
}
}
#endregion
#region TransactionType
private bool transaction_typeChanged = false;
private string transaction_type;
public string TransactionType
{
get { return transaction_type; }
set { 
transaction_type = value;
transaction_typeChanged = true;
}
}
private string transaction_typeDbString
{
get
{
if (this.transaction_type!=null)
return string.Format("'{0}'",transaction_type); else
return "null";
}
}
#endregion
#region TransactionResponse
private bool transaction_responseChanged = false;
private string transaction_response;
public string TransactionResponse
{
get { return transaction_response; }
set { 
transaction_response = value;
transaction_responseChanged = true;
}
}
private string transaction_responseDbString
{
get
{
if (this.transaction_response!=null)
return string.Format("'{0}'",transaction_response); else
return "null";
}
}
#endregion
#region TransactionSettlementDate
private bool transaction_settlement_dateChanged = false;
private DateTime? transaction_settlement_date;
public DateTime? TransactionSettlementDate
{
get { return transaction_settlement_date; }
set { 
transaction_settlement_date = value;
transaction_settlement_dateChanged = true;
}
}
private string transaction_settlement_dateDbString
{
get
{
if (this.transaction_settlement_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",transaction_settlement_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region CardNetwork
private bool card_networkChanged = false;
private string card_network;
public string CardNetwork
{
get { return card_network; }
set { 
card_network = value;
card_networkChanged = true;
}
}
private string card_networkDbString
{
get
{
if (this.card_network!=null)
return string.Format("'{0}'",card_network); else
return "null";
}
}
#endregion
#region CardIssuer
private bool card_issuerChanged = false;
private string card_issuer;
public string CardIssuer
{
get { return card_issuer; }
set { 
card_issuer = value;
card_issuerChanged = true;
}
}
private string card_issuerDbString
{
get
{
if (this.card_issuer!=null)
return string.Format("'{0}'",card_issuer); else
return "null";
}
}
#endregion
#endregion

#region ReconciliationSwitchDataReader
public class ReconciliationSwitchDataReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReconciliationSwitchData currentReconciliationSwitchData;
Columns columns;
bool partialRead = false;
private ReconciliationSwitchDataReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReconciliationSwitchDataReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReconciliationSwitchDataReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReconciliationSwitchData; }

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
currentReconciliationSwitchData = new ReconciliationSwitchData();
if (partialRead)
{ if ((columns & Columns.reconciliation_switch_data_id) == Columns.reconciliation_switch_data_id && reader["reconciliation_switch_data_id"]!=DBNull.Value)
currentReconciliationSwitchData.reconciliation_switch_data_id =(int) reader["reconciliation_switch_data_id"]; 
if ((columns & Columns.reconciliation_batch_id) == Columns.reconciliation_batch_id && reader["reconciliation_batch_id"]!=DBNull.Value)
currentReconciliationSwitchData.reconciliation_batch_id =(int) reader["reconciliation_batch_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentReconciliationSwitchData.atm_id =(string) reader["atm_id"]; 
if ((columns & Columns.card_number) == Columns.card_number && reader["card_number"]!=DBNull.Value)
currentReconciliationSwitchData.card_number =(string) reader["card_number"]; 
if ((columns & Columns.customer_account_no) == Columns.customer_account_no && reader["customer_account_no"]!=DBNull.Value)
currentReconciliationSwitchData.customer_account_no =(string) reader["customer_account_no"]; 
if ((columns & Columns.transaction_date) == Columns.transaction_date && reader["transaction_date"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_date =(string) reader["transaction_date"]; 
if ((columns & Columns.transaction_time) == Columns.transaction_time && reader["transaction_time"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_time =(string) reader["transaction_time"]; 
if ((columns & Columns.transaction_amount) == Columns.transaction_amount && reader["transaction_amount"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_amount =(decimal?) reader["transaction_amount"]; 
if ((columns & Columns.transaction_currency) == Columns.transaction_currency && reader["transaction_currency"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_currency =(string) reader["transaction_currency"]; 
if ((columns & Columns.transaction_sequence) == Columns.transaction_sequence && reader["transaction_sequence"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_sequence =(string) reader["transaction_sequence"]; 
if ((columns & Columns.transaction_type) == Columns.transaction_type && reader["transaction_type"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_type =(string) reader["transaction_type"]; 
if ((columns & Columns.transaction_response) == Columns.transaction_response && reader["transaction_response"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_response =(string) reader["transaction_response"]; 
if ((columns & Columns.transaction_settlement_date) == Columns.transaction_settlement_date && reader["transaction_settlement_date"]!=DBNull.Value)
currentReconciliationSwitchData.transaction_settlement_date =(DateTime?) reader["transaction_settlement_date"]; 
if ((columns & Columns.card_network) == Columns.card_network && reader["card_network"]!=DBNull.Value)
currentReconciliationSwitchData.card_network =(string) reader["card_network"]; 
if ((columns & Columns.card_issuer) == Columns.card_issuer && reader["card_issuer"]!=DBNull.Value)
currentReconciliationSwitchData.card_issuer =(string) reader["card_issuer"]; 

} else
{
if (reader["reconciliation_switch_data_id"] != DBNull.Value)
currentReconciliationSwitchData.reconciliation_switch_data_id = (int) reader["reconciliation_switch_data_id"]; 
if (reader["reconciliation_batch_id"] != DBNull.Value)
currentReconciliationSwitchData.reconciliation_batch_id = (int) reader["reconciliation_batch_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentReconciliationSwitchData.atm_id = (string) reader["atm_id"]; 
if (reader["card_number"] != DBNull.Value)
currentReconciliationSwitchData.card_number = (string) reader["card_number"]; 
if (reader["customer_account_no"] != DBNull.Value)
currentReconciliationSwitchData.customer_account_no = (string) reader["customer_account_no"]; 
if (reader["transaction_date"] != DBNull.Value)
currentReconciliationSwitchData.transaction_date = (string) reader["transaction_date"]; 
if (reader["transaction_time"] != DBNull.Value)
currentReconciliationSwitchData.transaction_time = (string) reader["transaction_time"]; 
if (reader["transaction_amount"] != DBNull.Value)
currentReconciliationSwitchData.transaction_amount = (decimal?) reader["transaction_amount"]; 
if (reader["transaction_currency"] != DBNull.Value)
currentReconciliationSwitchData.transaction_currency = (string) reader["transaction_currency"]; 
if (reader["transaction_sequence"] != DBNull.Value)
currentReconciliationSwitchData.transaction_sequence = (string) reader["transaction_sequence"]; 
if (reader["transaction_type"] != DBNull.Value)
currentReconciliationSwitchData.transaction_type = (string) reader["transaction_type"]; 
if (reader["transaction_response"] != DBNull.Value)
currentReconciliationSwitchData.transaction_response = (string) reader["transaction_response"]; 
if (reader["transaction_settlement_date"] != DBNull.Value)
currentReconciliationSwitchData.transaction_settlement_date = (DateTime?) reader["transaction_settlement_date"]; 
if (reader["card_network"] != DBNull.Value)
currentReconciliationSwitchData.card_network = (string) reader["card_network"]; 
if (reader["card_issuer"] != DBNull.Value)
currentReconciliationSwitchData.card_issuer = (string) reader["card_issuer"]; 
} 

currentReconciliationSwitchData.isNewEntity = false;
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

public ReconciliationSwitchData CurrentReconciliationSwitchData
{
get{ return currentReconciliationSwitchData; }
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


#region ReconciliationSwitchData functions

public static ReconciliationSwitchDataReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.reconciliation_switch_data_id == (Columns.reconciliation_switch_data_id & columns))
qry.Append("reconciliation_switch_data_id,");
if (Columns.reconciliation_batch_id == (Columns.reconciliation_batch_id & columns))
qry.Append("reconciliation_batch_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.card_number == (Columns.card_number & columns))
qry.Append("card_number,");
if (Columns.customer_account_no == (Columns.customer_account_no & columns))
qry.Append("customer_account_no,");
if (Columns.transaction_date == (Columns.transaction_date & columns))
qry.Append("transaction_date,");
if (Columns.transaction_time == (Columns.transaction_time & columns))
qry.Append("transaction_time,");
if (Columns.transaction_amount == (Columns.transaction_amount & columns))
qry.Append("transaction_amount,");
if (Columns.transaction_currency == (Columns.transaction_currency & columns))
qry.Append("transaction_currency,");
if (Columns.transaction_sequence == (Columns.transaction_sequence & columns))
qry.Append("transaction_sequence,");
if (Columns.transaction_type == (Columns.transaction_type & columns))
qry.Append("transaction_type,");
if (Columns.transaction_response == (Columns.transaction_response & columns))
qry.Append("transaction_response,");
if (Columns.transaction_settlement_date == (Columns.transaction_settlement_date & columns))
qry.Append("transaction_settlement_date,");
if (Columns.card_network == (Columns.card_network & columns))
qry.Append("card_network,");
if (Columns.card_issuer == (Columns.card_issuer & columns))
qry.Append("card_issuer,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Reconciliation_switch_data ");

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
return new ReconciliationSwitchDataReader(cmd.ExecuteReader(), conn, columns);
}

static public ReconciliationSwitchDataReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReconciliationSwitchDataReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select reconciliation_switch_data_id,reconciliation_batch_id,atm_id,card_number,customer_account_no,transaction_date,transaction_time,transaction_amount,transaction_currency,transaction_sequence,transaction_type,transaction_response,transaction_settlement_date,card_network,card_issuer from Reconciliation_switch_data ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReconciliationSwitchDataReader(cmd.ExecuteReader(), conn);
}

static public ReconciliationSwitchDataReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReconciliationSwitchData LoadReconciliationSwitchData(string where)
{
ReconciliationSwitchDataReader reader = ReconciliationSwitchData.ExecuteReader(where);
ReconciliationSwitchData _reconciliationswitchdata = null;
if (reader.Read())
_reconciliationswitchdata = reader.CurrentReconciliationSwitchData;
reader.Close();
return _reconciliationswitchdata;
}

public static ReconciliationSwitchData LoadReconciliationSwitchData(string where, IDbConnection conn)
{
ReconciliationSwitchDataReader reader = ReconciliationSwitchData.ExecuteReader(where, conn);
ReconciliationSwitchData _reconciliationswitchdata = null;
if (reader.Read())
_reconciliationswitchdata = reader.CurrentReconciliationSwitchData;
reader.Close(false);
return _reconciliationswitchdata;
}

public static ReconciliationSwitchData LoadReconciliationSwitchDataByPk( int reconciliation_switch_data_id )
{
return LoadReconciliationSwitchData( " reconciliation_switch_data_id="+reconciliation_switch_data_id );
}

public static ReconciliationSwitchData LoadReconciliationSwitchDataByPk( int reconciliation_switch_data_id , IDbConnection conn)
{
return LoadReconciliationSwitchData(" reconciliation_switch_data_id="+reconciliation_switch_data_id , conn);
}

public void Save()
{
if (reconciliation_switch_data_idChanged || reconciliation_batch_idChanged || atm_idChanged || card_numberChanged || customer_account_noChanged || transaction_dateChanged || transaction_timeChanged || transaction_amountChanged || transaction_currencyChanged || transaction_sequenceChanged || transaction_typeChanged || transaction_responseChanged || transaction_settlement_dateChanged || card_networkChanged || card_issuerChanged )
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
if (reconciliation_switch_data_idChanged || reconciliation_batch_idChanged || atm_idChanged || card_numberChanged || customer_account_noChanged || transaction_dateChanged || transaction_timeChanged || transaction_amountChanged || transaction_currencyChanged || transaction_sequenceChanged || transaction_typeChanged || transaction_responseChanged || transaction_settlement_dateChanged || card_networkChanged || card_issuerChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Reconciliation_switch_data( reconciliation_switch_data_id,reconciliation_batch_id,atm_id,card_number,customer_account_no,transaction_date,transaction_time,transaction_amount,transaction_currency,transaction_sequence,transaction_type,transaction_response,transaction_settlement_date,card_network,card_issuer ) values(");
lock (ConnectionFactory.connectionString) { this.reconciliation_switch_data_id = ConnectionFactory.GetNextId();
qry.Append(this.reconciliation_switch_data_id);
} qry.Append(",");
qry.Append(reconciliation_batch_idDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(card_numberDbString+",");
qry.Append(customer_account_noDbString+",");
qry.Append(transaction_dateDbString+",");
qry.Append(transaction_timeDbString+",");
qry.Append(transaction_amountDbString+",");
qry.Append(transaction_currencyDbString+",");
qry.Append(transaction_sequenceDbString+",");
qry.Append(transaction_typeDbString+",");
qry.Append(transaction_responseDbString+",");
qry.Append(transaction_settlement_dateDbString+",");
qry.Append(card_networkDbString+",");
qry.Append(card_issuerDbString);
qry.Append(");");

}
else
{
if (!(reconciliation_switch_data_idChanged || reconciliation_batch_idChanged || atm_idChanged || card_numberChanged || customer_account_noChanged || transaction_dateChanged || transaction_timeChanged || transaction_amountChanged || transaction_currencyChanged || transaction_sequenceChanged || transaction_typeChanged || transaction_responseChanged || transaction_settlement_dateChanged || card_networkChanged || card_issuerChanged ))
return;
qry.Append("UPDATE Reconciliation_switch_data set "); if ( reconciliation_batch_idChanged )
{
qry.Append("reconciliation_batch_id ="+reconciliation_batch_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( card_numberChanged )
{
qry.Append("card_number ="+card_numberDbString);
qry.Append(",");
}

if ( customer_account_noChanged )
{
qry.Append("customer_account_no ="+customer_account_noDbString);
qry.Append(",");
}

if ( transaction_dateChanged )
{
qry.Append("transaction_date ="+transaction_dateDbString);
qry.Append(",");
}

if ( transaction_timeChanged )
{
qry.Append("transaction_time ="+transaction_timeDbString);
qry.Append(",");
}

if ( transaction_amountChanged )
{
qry.Append("transaction_amount ="+transaction_amountDbString);
qry.Append(",");
}

if ( transaction_currencyChanged )
{
qry.Append("transaction_currency ="+transaction_currencyDbString);
qry.Append(",");
}

if ( transaction_sequenceChanged )
{
qry.Append("transaction_sequence ="+transaction_sequenceDbString);
qry.Append(",");
}

if ( transaction_typeChanged )
{
qry.Append("transaction_type ="+transaction_typeDbString);
qry.Append(",");
}

if ( transaction_responseChanged )
{
qry.Append("transaction_response ="+transaction_responseDbString);
qry.Append(",");
}

if ( transaction_settlement_dateChanged )
{
qry.Append("transaction_settlement_date ="+transaction_settlement_dateDbString);
qry.Append(",");
}

if ( card_networkChanged )
{
qry.Append("card_network ="+card_networkDbString);
qry.Append(",");
}

if ( card_issuerChanged )
{
qry.Append("card_issuer ="+card_issuerDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("reconciliation_switch_data_id = "+reconciliation_switch_data_idDbString);
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
cmd.CommandText = "DELETE Reconciliation_switch_data where reconciliation_switch_data_id = "+ reconciliation_switch_data_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReconciliationSwitchDatas(string where)
{
ConnectionFactory.ExecuteQuery("delete Reconciliation_switch_data where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
reconciliation_switch_data_id= 1,
reconciliation_batch_id= 2,
atm_id= 4,
card_number= 8,
customer_account_no= 16,
transaction_date= 32,
transaction_time= 64,
transaction_amount= 128,
transaction_currency= 256,
transaction_sequence= 512,
transaction_type= 1024,
transaction_response= 2048,
transaction_settlement_date= 4096,
card_network= 8192,
card_issuer= 16384
}
#endregion
public void BulkSave(List<ReconciliationSwitchData> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Reconciliation_switch_data";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReconciliationSwitchData.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReconciliationSwitchData> transList,ref DataTable dt)
{
foreach (ReconciliationSwitchData tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["reconciliation_switch_data_id"] =ConnectionFactory.GetNextId();
Row["reconciliation_batch_id"] = tran.ReconciliationBatchId;
Row["atm_id"] = tran.AtmId;
Row["card_number"] = tran.CardNumber;
Row["customer_account_no"] = tran.CustomerAccountNo;
Row["transaction_date"] = tran.TransactionDate;
Row["transaction_time"] = tran.TransactionTime;
Row["transaction_amount"] = tran.TransactionAmount;
Row["transaction_currency"] = tran.TransactionCurrency;
Row["transaction_sequence"] = tran.TransactionSequence;
Row["transaction_type"] = tran.TransactionType;
Row["transaction_response"] = tran.TransactionResponse;
Row["transaction_settlement_date"] = tran.TransactionSettlementDate;
Row["card_network"] = tran.CardNetwork;
Row["card_issuer"] = tran.CardIssuer;
dt.Rows.Add(Row);
} }
}
}
