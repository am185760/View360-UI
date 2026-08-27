

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
 public class VaultSettlementDetail
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public VaultSettlementDetail() { }
 public VaultSettlementDetail( int vault_settlement_detail_id,int vault_settlement_id,string denomination_name,int opening_balance,int bad_notes_sent_to_bank,int substitution_recieved_from_bank,int new_opening_balance,int cash_recieved_from_bank,int cash_delivered_to_atm,int cash_returned_from_atm,int unfit_notes,int closing_balance,decimal cash_value ) 
 {
 this.vault_settlement_id = vault_settlement_id;
 this.vault_settlement_idChanged = true;
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
 }
 public VaultSettlementDetail( int vault_settlement_id,string denomination_name,int opening_balance,int bad_notes_sent_to_bank,int substitution_recieved_from_bank,int new_opening_balance,int cash_recieved_from_bank,int cash_delivered_to_atm,int cash_returned_from_atm,int unfit_notes,int closing_balance,decimal cash_value,int? unfit_notes_delivered_to_bank )
 {
 this.vault_settlement_id = vault_settlement_id;
 this.vault_settlement_idChanged = true;
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
 this.unfit_notes_delivered_to_bank = unfit_notes_delivered_to_bank;
 this.unfit_notes_delivered_to_bankChanged = true;
 }
 private VaultSettlementDetail( int vault_settlement_detail_id,int vault_settlement_id,string denomination_name,int opening_balance,int bad_notes_sent_to_bank,int substitution_recieved_from_bank,int new_opening_balance,int cash_recieved_from_bank,int cash_delivered_to_atm,int cash_returned_from_atm,int unfit_notes,int closing_balance,decimal cash_value,int? unfit_notes_delivered_to_bank )
 {
 this.vault_settlement_detail_id = vault_settlement_detail_id;
 this.vault_settlement_detail_idChanged = true;
 this.vault_settlement_id = vault_settlement_id;
 this.vault_settlement_idChanged = true;
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
 this.unfit_notes_delivered_to_bank = unfit_notes_delivered_to_bank;
 this.unfit_notes_delivered_to_bankChanged = true;
 }

 #region members and properties for columns

 #region VaultSettlementDetailId
 private bool vault_settlement_detail_idChanged = false;
 private int vault_settlement_detail_id;
 public int VaultSettlementDetailId
 {
 get { return vault_settlement_detail_id; }
 set { 
vault_settlement_detail_id = value;
vault_settlement_detail_idChanged = true;
 }
 }
 private string vault_settlement_detail_idDbString
 {
 get
 {
 return vault_settlement_detail_id.ToString();
 }
 }
 #endregion
 #region VaultSettlementId
 private bool vault_settlement_idChanged = false;
 private int vault_settlement_id;
 public int VaultSettlementId
 {
 get { return vault_settlement_id; }
 set { 
vault_settlement_id = value;
vault_settlement_idChanged = true;
 }
 }
 private string vault_settlement_idDbString
 {
 get
 {
 return vault_settlement_id.ToString();
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
 private int opening_balance;
 public int OpeningBalance
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
 return opening_balance.ToString();
 }
 }
 #endregion
 #region BadNotesSentToBank
 private bool bad_notes_sent_to_bankChanged = false;
 private int bad_notes_sent_to_bank;
 public int BadNotesSentToBank
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
 return bad_notes_sent_to_bank.ToString();
 }
 }
 #endregion
 #region SubstitutionRecievedFromBank
 private bool substitution_recieved_from_bankChanged = false;
 private int substitution_recieved_from_bank;
 public int SubstitutionRecievedFromBank
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
 return substitution_recieved_from_bank.ToString();
 }
 }
 #endregion
 #region NewOpeningBalance
 private bool new_opening_balanceChanged = false;
 private int new_opening_balance;
 public int NewOpeningBalance
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
 return new_opening_balance.ToString();
 }
 }
 #endregion
 #region CashRecievedFromBank
 private bool cash_recieved_from_bankChanged = false;
 private int cash_recieved_from_bank;
 public int CashRecievedFromBank
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
 return cash_recieved_from_bank.ToString();
 }
 }
 #endregion
 #region CashDeliveredToAtm
 private bool cash_delivered_to_atmChanged = false;
 private int cash_delivered_to_atm;
 public int CashDeliveredToAtm
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
 return cash_delivered_to_atm.ToString();
 }
 }
 #endregion
 #region CashReturnedFromAtm
 private bool cash_returned_from_atmChanged = false;
 private int cash_returned_from_atm;
 public int CashReturnedFromAtm
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
 return cash_returned_from_atm.ToString();
 }
 }
 #endregion
 #region UnfitNotes
 private bool unfit_notesChanged = false;
 private int unfit_notes;
 public int UnfitNotes
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
 return unfit_notes.ToString();
 }
 }
 #endregion
 #region ClosingBalance
 private bool closing_balanceChanged = false;
 private int closing_balance;
 public int ClosingBalance
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
 return closing_balance.ToString();
 }
 }
 #endregion
 #region CashValue
 private bool cash_valueChanged = false;
 private decimal cash_value;
 public decimal CashValue
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
 return cash_value.ToString();
 }
 }
 #endregion
 #region UnfitNotesDeliveredToBank
 private bool unfit_notes_delivered_to_bankChanged = false;
 private int? unfit_notes_delivered_to_bank;
 public int? UnfitNotesDeliveredToBank
 {
 get { return unfit_notes_delivered_to_bank; }
 set { 
unfit_notes_delivered_to_bank = value;
unfit_notes_delivered_to_bankChanged = true;
 }
 }
 private string unfit_notes_delivered_to_bankDbString
 {
 get
 {
 if (this.unfit_notes_delivered_to_bank.HasValue)
 return unfit_notes_delivered_to_bank.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region VaultSettlementDetailReader
 public class VaultSettlementDetailReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
VaultSettlementDetail currentVaultSettlementDetail;
 Columns columns;
 bool partialRead = false;
 private VaultSettlementDetailReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public VaultSettlementDetailReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public VaultSettlementDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentVaultSettlementDetail; }

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
 currentVaultSettlementDetail = new VaultSettlementDetail();
 if (partialRead)
 { if ((columns & Columns.vault_settlement_detail_id) == Columns.vault_settlement_detail_id && reader["vault_settlement_detail_id"]!=DBNull.Value)
 currentVaultSettlementDetail.vault_settlement_detail_id =(int) reader["vault_settlement_detail_id"]; 
 if ((columns & Columns.vault_settlement_id) == Columns.vault_settlement_id && reader["vault_settlement_id"]!=DBNull.Value)
 currentVaultSettlementDetail.vault_settlement_id =(int) reader["vault_settlement_id"]; 
 if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
 currentVaultSettlementDetail.denomination_name =(string) reader["denomination_name"]; 
 if ((columns & Columns.opening_balance) == Columns.opening_balance && reader["opening_balance"]!=DBNull.Value)
 currentVaultSettlementDetail.opening_balance =(int) reader["opening_balance"]; 
 if ((columns & Columns.bad_notes_sent_to_bank) == Columns.bad_notes_sent_to_bank && reader["bad_notes_sent_to_bank"]!=DBNull.Value)
 currentVaultSettlementDetail.bad_notes_sent_to_bank =(int) reader["bad_notes_sent_to_bank"]; 
 if ((columns & Columns.substitution_recieved_from_bank) == Columns.substitution_recieved_from_bank && reader["substitution_recieved_from_bank"]!=DBNull.Value)
 currentVaultSettlementDetail.substitution_recieved_from_bank =(int) reader["substitution_recieved_from_bank"]; 
 if ((columns & Columns.new_opening_balance) == Columns.new_opening_balance && reader["new_opening_balance"]!=DBNull.Value)
 currentVaultSettlementDetail.new_opening_balance =(int) reader["new_opening_balance"]; 
 if ((columns & Columns.cash_recieved_from_bank) == Columns.cash_recieved_from_bank && reader["cash_recieved_from_bank"]!=DBNull.Value)
 currentVaultSettlementDetail.cash_recieved_from_bank =(int) reader["cash_recieved_from_bank"]; 
 if ((columns & Columns.cash_delivered_to_atm) == Columns.cash_delivered_to_atm && reader["cash_delivered_to_atm"]!=DBNull.Value)
 currentVaultSettlementDetail.cash_delivered_to_atm =(int) reader["cash_delivered_to_atm"]; 
 if ((columns & Columns.cash_returned_from_atm) == Columns.cash_returned_from_atm && reader["cash_returned_from_atm"]!=DBNull.Value)
 currentVaultSettlementDetail.cash_returned_from_atm =(int) reader["cash_returned_from_atm"]; 
 if ((columns & Columns.unfit_notes) == Columns.unfit_notes && reader["unfit_notes"]!=DBNull.Value)
 currentVaultSettlementDetail.unfit_notes =(int) reader["unfit_notes"]; 
 if ((columns & Columns.closing_balance) == Columns.closing_balance && reader["closing_balance"]!=DBNull.Value)
 currentVaultSettlementDetail.closing_balance =(int) reader["closing_balance"]; 
 if ((columns & Columns.cash_value) == Columns.cash_value && reader["cash_value"]!=DBNull.Value)
 currentVaultSettlementDetail.cash_value =(decimal) reader["cash_value"]; 
 if ((columns & Columns.unfit_notes_delivered_to_bank) == Columns.unfit_notes_delivered_to_bank && reader["unfit_notes_delivered_to_bank"]!=DBNull.Value)
 currentVaultSettlementDetail.unfit_notes_delivered_to_bank =(int?) reader["unfit_notes_delivered_to_bank"]; 

 } else
 {
 if (reader["vault_settlement_detail_id"] != DBNull.Value)
 currentVaultSettlementDetail.vault_settlement_detail_id = (int) reader["vault_settlement_detail_id"]; 
 if (reader["vault_settlement_id"] != DBNull.Value)
 currentVaultSettlementDetail.vault_settlement_id = (int) reader["vault_settlement_id"]; 
 if (reader["denomination_name"] != DBNull.Value)
 currentVaultSettlementDetail.denomination_name = (string) reader["denomination_name"]; 
 if (reader["opening_balance"] != DBNull.Value)
 currentVaultSettlementDetail.opening_balance = (int) reader["opening_balance"]; 
 if (reader["bad_notes_sent_to_bank"] != DBNull.Value)
 currentVaultSettlementDetail.bad_notes_sent_to_bank = (int) reader["bad_notes_sent_to_bank"]; 
 if (reader["substitution_recieved_from_bank"] != DBNull.Value)
 currentVaultSettlementDetail.substitution_recieved_from_bank = (int) reader["substitution_recieved_from_bank"]; 
 if (reader["new_opening_balance"] != DBNull.Value)
 currentVaultSettlementDetail.new_opening_balance = (int) reader["new_opening_balance"]; 
 if (reader["cash_recieved_from_bank"] != DBNull.Value)
 currentVaultSettlementDetail.cash_recieved_from_bank = (int) reader["cash_recieved_from_bank"]; 
 if (reader["cash_delivered_to_atm"] != DBNull.Value)
 currentVaultSettlementDetail.cash_delivered_to_atm = (int) reader["cash_delivered_to_atm"]; 
 if (reader["cash_returned_from_atm"] != DBNull.Value)
 currentVaultSettlementDetail.cash_returned_from_atm = (int) reader["cash_returned_from_atm"]; 
 if (reader["unfit_notes"] != DBNull.Value)
 currentVaultSettlementDetail.unfit_notes = (int) reader["unfit_notes"]; 
 if (reader["closing_balance"] != DBNull.Value)
 currentVaultSettlementDetail.closing_balance = (int) reader["closing_balance"]; 
 if (reader["cash_value"] != DBNull.Value)
 currentVaultSettlementDetail.cash_value = (decimal) reader["cash_value"]; 
 if (reader["unfit_notes_delivered_to_bank"] != DBNull.Value)
 currentVaultSettlementDetail.unfit_notes_delivered_to_bank = (int?) reader["unfit_notes_delivered_to_bank"]; 
 } 

 currentVaultSettlementDetail.isNewEntity = false;
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

 public VaultSettlementDetail CurrentVaultSettlementDetail
 {
 get{ return currentVaultSettlementDetail; }
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


 #region VaultSettlementDetail functions

 public static VaultSettlementDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.vault_settlement_detail_id == (Columns.vault_settlement_detail_id & columns))
 qry.Append("vault_settlement_detail_id,");
 if (Columns.vault_settlement_id == (Columns.vault_settlement_id & columns))
 qry.Append("vault_settlement_id,");
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
 if (Columns.unfit_notes_delivered_to_bank == (Columns.unfit_notes_delivered_to_bank & columns))
 qry.Append("unfit_notes_delivered_to_bank,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Vault_settlement_detail ");

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
 return new VaultSettlementDetailReader(cmd.ExecuteReader(), conn, columns);
 }

 static public VaultSettlementDetailReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static VaultSettlementDetailReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select vault_settlement_detail_id,vault_settlement_id,denomination_name,opening_balance,bad_notes_sent_to_bank,substitution_recieved_from_bank,new_opening_balance,cash_recieved_from_bank,cash_delivered_to_atm,cash_returned_from_atm,unfit_notes,closing_balance,cash_value,unfit_notes_delivered_to_bank from Vault_settlement_detail ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new VaultSettlementDetailReader(cmd.ExecuteReader(), conn);
 }

 static public VaultSettlementDetailReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static VaultSettlementDetail LoadVaultSettlementDetail(string where)
 {
VaultSettlementDetailReader reader = VaultSettlementDetail.ExecuteReader(where);
VaultSettlementDetail _vaultsettlementdetail = null;
 if (reader.Read())
 _vaultsettlementdetail = reader.CurrentVaultSettlementDetail;
 reader.Close();
 return _vaultsettlementdetail;
 }

 public static VaultSettlementDetail LoadVaultSettlementDetail(string where, IDbConnection conn)
 {
VaultSettlementDetailReader reader = VaultSettlementDetail.ExecuteReader(where, conn);
VaultSettlementDetail _vaultsettlementdetail = null;
 if (reader.Read())
 _vaultsettlementdetail = reader.CurrentVaultSettlementDetail;
 reader.Close(false);
 return _vaultsettlementdetail;
 }

 public static VaultSettlementDetail LoadVaultSettlementDetailByPk( int vault_settlement_detail_id )
 {
 return LoadVaultSettlementDetail( " vault_settlement_detail_id="+vault_settlement_detail_id );
 }

 public static VaultSettlementDetail LoadVaultSettlementDetailByPk( int vault_settlement_detail_id , IDbConnection conn)
 {
 return LoadVaultSettlementDetail(" vault_settlement_detail_id="+vault_settlement_detail_id , conn);
 }

 public void Save()
 {
 if (vault_settlement_detail_idChanged || vault_settlement_idChanged || denomination_nameChanged || opening_balanceChanged || bad_notes_sent_to_bankChanged || substitution_recieved_from_bankChanged || new_opening_balanceChanged || cash_recieved_from_bankChanged || cash_delivered_to_atmChanged || cash_returned_from_atmChanged || unfit_notesChanged || closing_balanceChanged || cash_valueChanged || unfit_notes_delivered_to_bankChanged )
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
 if (vault_settlement_detail_idChanged || vault_settlement_idChanged || denomination_nameChanged || opening_balanceChanged || bad_notes_sent_to_bankChanged || substitution_recieved_from_bankChanged || new_opening_balanceChanged || cash_recieved_from_bankChanged || cash_delivered_to_atmChanged || cash_returned_from_atmChanged || unfit_notesChanged || closing_balanceChanged || cash_valueChanged || unfit_notes_delivered_to_bankChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Vault_settlement_detail( vault_settlement_detail_id,vault_settlement_id,denomination_name,opening_balance,bad_notes_sent_to_bank,substitution_recieved_from_bank,new_opening_balance,cash_recieved_from_bank,cash_delivered_to_atm,cash_returned_from_atm,unfit_notes,closing_balance,cash_value,unfit_notes_delivered_to_bank ) values(");
 lock (ConnectionFactory.connectionString) { this.vault_settlement_detail_id = ConnectionFactory.GetNextId();
 qry.Append(this.vault_settlement_detail_id);
 } qry.Append(",");
 qry.Append(vault_settlement_idDbString+",");
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
 qry.Append(unfit_notes_delivered_to_bankDbString);
 qry.Append(");");

 }
 else
 {
 if (!(vault_settlement_detail_idChanged || vault_settlement_idChanged || denomination_nameChanged || opening_balanceChanged || bad_notes_sent_to_bankChanged || substitution_recieved_from_bankChanged || new_opening_balanceChanged || cash_recieved_from_bankChanged || cash_delivered_to_atmChanged || cash_returned_from_atmChanged || unfit_notesChanged || closing_balanceChanged || cash_valueChanged || unfit_notes_delivered_to_bankChanged ))
 return;
 qry.Append("UPDATE Vault_settlement_detail set "); if ( vault_settlement_idChanged )
 {
 qry.Append("vault_settlement_id ="+vault_settlement_idDbString);
 qry.Append(",");
 }

 if ( denomination_nameChanged )
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

 if ( unfit_notes_delivered_to_bankChanged )
 {
 qry.Append("unfit_notes_delivered_to_bank ="+unfit_notes_delivered_to_bankDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("vault_settlement_detail_id = "+vault_settlement_detail_idDbString);
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
 cmd.CommandText = "DELETE Vault_settlement_detail where vault_settlement_detail_id = "+ vault_settlement_detail_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteVaultSettlementDetails(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Vault_settlement_detail where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
vault_settlement_detail_id= 1,
vault_settlement_id= 2,
denomination_name= 4,
opening_balance= 8,
bad_notes_sent_to_bank= 16,
substitution_recieved_from_bank= 32,
new_opening_balance= 64,
cash_recieved_from_bank= 128,
cash_delivered_to_atm= 256,
cash_returned_from_atm= 512,
unfit_notes= 1024,
closing_balance= 2048,
cash_value= 4096,
unfit_notes_delivered_to_bank= 8192
 }
 #endregion
 public void BulkSave(List<VaultSettlementDetail> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Vault_settlement_detail";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(VaultSettlementDetail.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <VaultSettlementDetail> transList,ref DataTable dt)
 {
 foreach (VaultSettlementDetail tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["vault_settlement_detail_id"] =ConnectionFactory.GetNextId();
 Row["vault_settlement_id"] = tran.VaultSettlementId;
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
 Row["unfit_notes_delivered_to_bank"] = tran.UnfitNotesDeliveredToBank;
 dt.Rows.Add(Row);
 } }
 }
 }

 
