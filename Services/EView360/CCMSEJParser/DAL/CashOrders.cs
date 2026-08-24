
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
 public class CashOrders
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public CashOrders() { }
 public CashOrders( int cash_order_id,int atm_id,string cash_order_type,DateTime cash_order_datetime,bool is_uploaded,int created_by,DateTime dispatch_time,bool is_vault_deducted,bool is_cancelled ) 
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.cash_order_type = cash_order_type;
 this.cash_order_typeChanged = true;
 this.cash_order_datetime = cash_order_datetime;
 this.cash_order_datetimeChanged = true;
 this.is_uploaded = is_uploaded;
 this.is_uploadedChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.dispatch_time = dispatch_time;
 this.dispatch_timeChanged = true;
 this.is_vault_deducted = is_vault_deducted;
 this.is_vault_deductedChanged = true;
 this.is_cancelled = is_cancelled;
 this.is_cancelledChanged = true;
 }
 public CashOrders( int atm_id,string cash_order_type,DateTime cash_order_datetime,int? cassette1_suggested_notes,int? cassette2_suggested_notes,int? cassette3_suggested_notes,int? cassette4_suggested_notes,int? cassette5_suggested_notes,int? cassette6_suggested_notes,int? cassette7_suggested_notes,int? cassette1_remaining_notes,int? cassette2_remaining_notes,int? cassette3_remaining_notes,int? cassette4_remaining_notes,int? cassette5_remaining_notes,int? cassette6_remaining_notes,int? cassette7_remaining_notes,bool is_uploaded,DateTime? last_replenishment_at,int? ftp_file_info_id,int? cassette1_denomination,int? cassette2_denomination,int? cassette3_denomination,int? cassette4_denomination,int? cassette5_denomination,int? cassette6_denomination,int? cassette7_denomination,int created_by,DateTime dispatch_time,string order_number,bool is_vault_deducted,bool is_cancelled,bool? is_hold,DateTime? replenishment_datetime,int? modified_by,DateTime? modification_time,DateTime? creation_time,bool? is_reminder_sent_to_cit )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.cash_order_type = cash_order_type;
 this.cash_order_typeChanged = true;
 this.cash_order_datetime = cash_order_datetime;
 this.cash_order_datetimeChanged = true;
 this.cassette1_suggested_notes = cassette1_suggested_notes;
 this.cassette1_suggested_notesChanged = true;
 this.cassette2_suggested_notes = cassette2_suggested_notes;
 this.cassette2_suggested_notesChanged = true;
 this.cassette3_suggested_notes = cassette3_suggested_notes;
 this.cassette3_suggested_notesChanged = true;
 this.cassette4_suggested_notes = cassette4_suggested_notes;
 this.cassette4_suggested_notesChanged = true;
 this.cassette5_suggested_notes = cassette5_suggested_notes;
 this.cassette5_suggested_notesChanged = true;
 this.cassette6_suggested_notes = cassette6_suggested_notes;
 this.cassette6_suggested_notesChanged = true;
 this.cassette7_suggested_notes = cassette7_suggested_notes;
 this.cassette7_suggested_notesChanged = true;
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
 this.is_uploaded = is_uploaded;
 this.is_uploadedChanged = true;
 this.last_replenishment_at = last_replenishment_at;
 this.last_replenishment_atChanged = true;
 this.ftp_file_info_id = ftp_file_info_id;
 this.ftp_file_info_idChanged = true;
 this.cassette1_denomination = cassette1_denomination;
 this.cassette1_denominationChanged = true;
 this.cassette2_denomination = cassette2_denomination;
 this.cassette2_denominationChanged = true;
 this.cassette3_denomination = cassette3_denomination;
 this.cassette3_denominationChanged = true;
 this.cassette4_denomination = cassette4_denomination;
 this.cassette4_denominationChanged = true;
 this.cassette5_denomination = cassette5_denomination;
 this.cassette5_denominationChanged = true;
 this.cassette6_denomination = cassette6_denomination;
 this.cassette6_denominationChanged = true;
 this.cassette7_denomination = cassette7_denomination;
 this.cassette7_denominationChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.dispatch_time = dispatch_time;
 this.dispatch_timeChanged = true;
 this.order_number = order_number;
 this.order_numberChanged = true;
 this.is_vault_deducted = is_vault_deducted;
 this.is_vault_deductedChanged = true;
 this.is_cancelled = is_cancelled;
 this.is_cancelledChanged = true;
 this.is_hold = is_hold;
 this.is_holdChanged = true;
 this.replenishment_datetime = replenishment_datetime;
 this.replenishment_datetimeChanged = true;
 this.modified_by = modified_by;
 this.modified_byChanged = true;
 this.modification_time = modification_time;
 this.modification_timeChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.is_reminder_sent_to_cit = is_reminder_sent_to_cit;
 this.is_reminder_sent_to_citChanged = true;
 }
 private CashOrders( int cash_order_id,int atm_id,string cash_order_type,DateTime cash_order_datetime,int? cassette1_suggested_notes,int? cassette2_suggested_notes,int? cassette3_suggested_notes,int? cassette4_suggested_notes,int? cassette5_suggested_notes,int? cassette6_suggested_notes,int? cassette7_suggested_notes,int? cassette1_remaining_notes,int? cassette2_remaining_notes,int? cassette3_remaining_notes,int? cassette4_remaining_notes,int? cassette5_remaining_notes,int? cassette6_remaining_notes,int? cassette7_remaining_notes,bool is_uploaded,DateTime? last_replenishment_at,int? ftp_file_info_id,int? cassette1_denomination,int? cassette2_denomination,int? cassette3_denomination,int? cassette4_denomination,int? cassette5_denomination,int? cassette6_denomination,int? cassette7_denomination,int created_by,DateTime dispatch_time,string order_number,bool is_vault_deducted,bool is_cancelled,bool? is_hold,DateTime? replenishment_datetime,int? modified_by,DateTime? modification_time,DateTime? creation_time,bool? is_reminder_sent_to_cit )
 {
 this.cash_order_id = cash_order_id;
 this.cash_order_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.cash_order_type = cash_order_type;
 this.cash_order_typeChanged = true;
 this.cash_order_datetime = cash_order_datetime;
 this.cash_order_datetimeChanged = true;
 this.cassette1_suggested_notes = cassette1_suggested_notes;
 this.cassette1_suggested_notesChanged = true;
 this.cassette2_suggested_notes = cassette2_suggested_notes;
 this.cassette2_suggested_notesChanged = true;
 this.cassette3_suggested_notes = cassette3_suggested_notes;
 this.cassette3_suggested_notesChanged = true;
 this.cassette4_suggested_notes = cassette4_suggested_notes;
 this.cassette4_suggested_notesChanged = true;
 this.cassette5_suggested_notes = cassette5_suggested_notes;
 this.cassette5_suggested_notesChanged = true;
 this.cassette6_suggested_notes = cassette6_suggested_notes;
 this.cassette6_suggested_notesChanged = true;
 this.cassette7_suggested_notes = cassette7_suggested_notes;
 this.cassette7_suggested_notesChanged = true;
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
 this.is_uploaded = is_uploaded;
 this.is_uploadedChanged = true;
 this.last_replenishment_at = last_replenishment_at;
 this.last_replenishment_atChanged = true;
 this.ftp_file_info_id = ftp_file_info_id;
 this.ftp_file_info_idChanged = true;
 this.cassette1_denomination = cassette1_denomination;
 this.cassette1_denominationChanged = true;
 this.cassette2_denomination = cassette2_denomination;
 this.cassette2_denominationChanged = true;
 this.cassette3_denomination = cassette3_denomination;
 this.cassette3_denominationChanged = true;
 this.cassette4_denomination = cassette4_denomination;
 this.cassette4_denominationChanged = true;
 this.cassette5_denomination = cassette5_denomination;
 this.cassette5_denominationChanged = true;
 this.cassette6_denomination = cassette6_denomination;
 this.cassette6_denominationChanged = true;
 this.cassette7_denomination = cassette7_denomination;
 this.cassette7_denominationChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.dispatch_time = dispatch_time;
 this.dispatch_timeChanged = true;
 this.order_number = order_number;
 this.order_numberChanged = true;
 this.is_vault_deducted = is_vault_deducted;
 this.is_vault_deductedChanged = true;
 this.is_cancelled = is_cancelled;
 this.is_cancelledChanged = true;
 this.is_hold = is_hold;
 this.is_holdChanged = true;
 this.replenishment_datetime = replenishment_datetime;
 this.replenishment_datetimeChanged = true;
 this.modified_by = modified_by;
 this.modified_byChanged = true;
 this.modification_time = modification_time;
 this.modification_timeChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.is_reminder_sent_to_cit = is_reminder_sent_to_cit;
 this.is_reminder_sent_to_citChanged = true;
 }

 #region members and properties for columns

 #region CashOrderId
 private bool cash_order_idChanged = false;
 private int cash_order_id;
 public int CashOrderId
 {
 get { return cash_order_id; }
 set { 
cash_order_id = value;
cash_order_idChanged = true;
 }
 }
 private string cash_order_idDbString
 {
 get
 {
 return cash_order_id.ToString();
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
 #region CashOrderType
 private bool cash_order_typeChanged = false;
 private string cash_order_type;
 public string CashOrderType
 {
 get { return cash_order_type; }
 set { 
cash_order_type = value;
cash_order_typeChanged = true;
 }
 }
 private string cash_order_typeDbString
 {
 get
 {
 if (this.cash_order_type!=null)
 return string.Format("'{0}'",cash_order_type); else
 return "null";
 }
 }
 #endregion
 #region CashOrderDatetime
 private bool cash_order_datetimeChanged = false;
 private DateTime cash_order_datetime;
 public DateTime CashOrderDatetime
 {
 get { return cash_order_datetime; }
 set { 
cash_order_datetime = value;
cash_order_datetimeChanged = true;
 }
 }
 private string cash_order_datetimeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",cash_order_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region Cassette1SuggestedNotes
 private bool cassette1_suggested_notesChanged = false;
 private int? cassette1_suggested_notes;
 public int? Cassette1SuggestedNotes
 {
 get { return cassette1_suggested_notes; }
 set { 
cassette1_suggested_notes = value;
cassette1_suggested_notesChanged = true;
 }
 }
 private string cassette1_suggested_notesDbString
 {
 get
 {
 if (this.cassette1_suggested_notes.HasValue)
 return cassette1_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette2SuggestedNotes
 private bool cassette2_suggested_notesChanged = false;
 private int? cassette2_suggested_notes;
 public int? Cassette2SuggestedNotes
 {
 get { return cassette2_suggested_notes; }
 set { 
cassette2_suggested_notes = value;
cassette2_suggested_notesChanged = true;
 }
 }
 private string cassette2_suggested_notesDbString
 {
 get
 {
 if (this.cassette2_suggested_notes.HasValue)
 return cassette2_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette3SuggestedNotes
 private bool cassette3_suggested_notesChanged = false;
 private int? cassette3_suggested_notes;
 public int? Cassette3SuggestedNotes
 {
 get { return cassette3_suggested_notes; }
 set { 
cassette3_suggested_notes = value;
cassette3_suggested_notesChanged = true;
 }
 }
 private string cassette3_suggested_notesDbString
 {
 get
 {
 if (this.cassette3_suggested_notes.HasValue)
 return cassette3_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette4SuggestedNotes
 private bool cassette4_suggested_notesChanged = false;
 private int? cassette4_suggested_notes;
 public int? Cassette4SuggestedNotes
 {
 get { return cassette4_suggested_notes; }
 set { 
cassette4_suggested_notes = value;
cassette4_suggested_notesChanged = true;
 }
 }
 private string cassette4_suggested_notesDbString
 {
 get
 {
 if (this.cassette4_suggested_notes.HasValue)
 return cassette4_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette5SuggestedNotes
 private bool cassette5_suggested_notesChanged = false;
 private int? cassette5_suggested_notes;
 public int? Cassette5SuggestedNotes
 {
 get { return cassette5_suggested_notes; }
 set { 
cassette5_suggested_notes = value;
cassette5_suggested_notesChanged = true;
 }
 }
 private string cassette5_suggested_notesDbString
 {
 get
 {
 if (this.cassette5_suggested_notes.HasValue)
 return cassette5_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette6SuggestedNotes
 private bool cassette6_suggested_notesChanged = false;
 private int? cassette6_suggested_notes;
 public int? Cassette6SuggestedNotes
 {
 get { return cassette6_suggested_notes; }
 set { 
cassette6_suggested_notes = value;
cassette6_suggested_notesChanged = true;
 }
 }
 private string cassette6_suggested_notesDbString
 {
 get
 {
 if (this.cassette6_suggested_notes.HasValue)
 return cassette6_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette7SuggestedNotes
 private bool cassette7_suggested_notesChanged = false;
 private int? cassette7_suggested_notes;
 public int? Cassette7SuggestedNotes
 {
 get { return cassette7_suggested_notes; }
 set { 
cassette7_suggested_notes = value;
cassette7_suggested_notesChanged = true;
 }
 }
 private string cassette7_suggested_notesDbString
 {
 get
 {
 if (this.cassette7_suggested_notes.HasValue)
 return cassette7_suggested_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette1RemainingNotes
 private bool cassette1_remaining_notesChanged = false;
 private int? cassette1_remaining_notes;
 public int? Cassette1RemainingNotes
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
 if (this.cassette1_remaining_notes.HasValue)
 return cassette1_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette2RemainingNotes
 private bool cassette2_remaining_notesChanged = false;
 private int? cassette2_remaining_notes;
 public int? Cassette2RemainingNotes
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
 if (this.cassette2_remaining_notes.HasValue)
 return cassette2_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette3RemainingNotes
 private bool cassette3_remaining_notesChanged = false;
 private int? cassette3_remaining_notes;
 public int? Cassette3RemainingNotes
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
 if (this.cassette3_remaining_notes.HasValue)
 return cassette3_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette4RemainingNotes
 private bool cassette4_remaining_notesChanged = false;
 private int? cassette4_remaining_notes;
 public int? Cassette4RemainingNotes
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
 if (this.cassette4_remaining_notes.HasValue)
 return cassette4_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette5RemainingNotes
 private bool cassette5_remaining_notesChanged = false;
 private int? cassette5_remaining_notes;
 public int? Cassette5RemainingNotes
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
 if (this.cassette5_remaining_notes.HasValue)
 return cassette5_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette6RemainingNotes
 private bool cassette6_remaining_notesChanged = false;
 private int? cassette6_remaining_notes;
 public int? Cassette6RemainingNotes
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
 if (this.cassette6_remaining_notes.HasValue)
 return cassette6_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette7RemainingNotes
 private bool cassette7_remaining_notesChanged = false;
 private int? cassette7_remaining_notes;
 public int? Cassette7RemainingNotes
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
 if (this.cassette7_remaining_notes.HasValue)
 return cassette7_remaining_notes.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region IsUploaded
 private bool is_uploadedChanged = false;
 private bool is_uploaded;
 public bool IsUploaded
 {
 get { return is_uploaded; }
 set { 
is_uploaded = value;
is_uploadedChanged = true;
 }
 }
 private string is_uploadedDbString
 {
 get
 {
 return is_uploaded?"1":"0";
 }
 }
 #endregion
 #region LastReplenishmentAt
 private bool last_replenishment_atChanged = false;
 private DateTime? last_replenishment_at;
 public DateTime? LastReplenishmentAt
 {
 get { return last_replenishment_at; }
 set { 
last_replenishment_at = value;
last_replenishment_atChanged = true;
 }
 }
 private string last_replenishment_atDbString
 {
 get
 {
 if (this.last_replenishment_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",last_replenishment_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region FtpFileInfoId
 private bool ftp_file_info_idChanged = false;
 private int? ftp_file_info_id;
 public int? FtpFileInfoId
 {
 get { return ftp_file_info_id; }
 set { 
ftp_file_info_id = value;
ftp_file_info_idChanged = true;
 }
 }
 private string ftp_file_info_idDbString
 {
 get
 {
 if (this.ftp_file_info_id.HasValue)
 return ftp_file_info_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette1Denomination
 private bool cassette1_denominationChanged = false;
 private int? cassette1_denomination;
 public int? Cassette1Denomination
 {
 get { return cassette1_denomination; }
 set { 
cassette1_denomination = value;
cassette1_denominationChanged = true;
 }
 }
 private string cassette1_denominationDbString
 {
 get
 {
 if (this.cassette1_denomination.HasValue)
 return cassette1_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette2Denomination
 private bool cassette2_denominationChanged = false;
 private int? cassette2_denomination;
 public int? Cassette2Denomination
 {
 get { return cassette2_denomination; }
 set { 
cassette2_denomination = value;
cassette2_denominationChanged = true;
 }
 }
 private string cassette2_denominationDbString
 {
 get
 {
 if (this.cassette2_denomination.HasValue)
 return cassette2_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette3Denomination
 private bool cassette3_denominationChanged = false;
 private int? cassette3_denomination;
 public int? Cassette3Denomination
 {
 get { return cassette3_denomination; }
 set { 
cassette3_denomination = value;
cassette3_denominationChanged = true;
 }
 }
 private string cassette3_denominationDbString
 {
 get
 {
 if (this.cassette3_denomination.HasValue)
 return cassette3_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette4Denomination
 private bool cassette4_denominationChanged = false;
 private int? cassette4_denomination;
 public int? Cassette4Denomination
 {
 get { return cassette4_denomination; }
 set { 
cassette4_denomination = value;
cassette4_denominationChanged = true;
 }
 }
 private string cassette4_denominationDbString
 {
 get
 {
 if (this.cassette4_denomination.HasValue)
 return cassette4_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette5Denomination
 private bool cassette5_denominationChanged = false;
 private int? cassette5_denomination;
 public int? Cassette5Denomination
 {
 get { return cassette5_denomination; }
 set { 
cassette5_denomination = value;
cassette5_denominationChanged = true;
 }
 }
 private string cassette5_denominationDbString
 {
 get
 {
 if (this.cassette5_denomination.HasValue)
 return cassette5_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette6Denomination
 private bool cassette6_denominationChanged = false;
 private int? cassette6_denomination;
 public int? Cassette6Denomination
 {
 get { return cassette6_denomination; }
 set { 
cassette6_denomination = value;
cassette6_denominationChanged = true;
 }
 }
 private string cassette6_denominationDbString
 {
 get
 {
 if (this.cassette6_denomination.HasValue)
 return cassette6_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Cassette7Denomination
 private bool cassette7_denominationChanged = false;
 private int? cassette7_denomination;
 public int? Cassette7Denomination
 {
 get { return cassette7_denomination; }
 set { 
cassette7_denomination = value;
cassette7_denominationChanged = true;
 }
 }
 private string cassette7_denominationDbString
 {
 get
 {
 if (this.cassette7_denomination.HasValue)
 return cassette7_denomination.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region CreatedBy
 private bool created_byChanged = false;
 private int created_by;
 public int CreatedBy
 {
 get { return created_by; }
 set { 
created_by = value;
created_byChanged = true;
 }
 }
 private string created_byDbString
 {
 get
 {
 return created_by.ToString();
 }
 }
 #endregion
 #region DispatchTime
 private bool dispatch_timeChanged = false;
 private DateTime dispatch_time;
 public DateTime DispatchTime
 {
 get { return dispatch_time; }
 set { 
dispatch_time = value;
dispatch_timeChanged = true;
 }
 }
 private string dispatch_timeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",dispatch_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region OrderNumber
 private bool order_numberChanged = false;
 private string order_number;
 public string OrderNumber
 {
 get { return order_number; }
 set { 
order_number = value;
order_numberChanged = true;
 }
 }
 private string order_numberDbString
 {
 get
 {
 if (this.order_number!=null)
 return string.Format("'{0}'",order_number); else
 return "null";
 }
 }
 #endregion
 #region IsVaultDeducted
 private bool is_vault_deductedChanged = false;
 private bool is_vault_deducted;
 public bool IsVaultDeducted
 {
 get { return is_vault_deducted; }
 set { 
is_vault_deducted = value;
is_vault_deductedChanged = true;
 }
 }
 private string is_vault_deductedDbString
 {
 get
 {
 return is_vault_deducted?"1":"0";
 }
 }
 #endregion
 #region IsCancelled
 private bool is_cancelledChanged = false;
 private bool is_cancelled;
 public bool IsCancelled
 {
 get { return is_cancelled; }
 set { 
is_cancelled = value;
is_cancelledChanged = true;
 }
 }
 private string is_cancelledDbString
 {
 get
 {
 return is_cancelled?"1":"0";
 }
 }
 #endregion
 #region IsHold
 private bool is_holdChanged = false;
 private bool? is_hold;
 public bool? IsHold
 {
 get { return is_hold; }
 set { 
is_hold = value;
is_holdChanged = true;
 }
 }
 private string is_holdDbString
 {
 get
 {
 if (this.is_hold.HasValue)
 return is_hold.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #region ReplenishmentDatetime
 private bool replenishment_datetimeChanged = false;
 private DateTime? replenishment_datetime;
 public DateTime? ReplenishmentDatetime
 {
 get { return replenishment_datetime; }
 set { 
replenishment_datetime = value;
replenishment_datetimeChanged = true;
 }
 }
 private string replenishment_datetimeDbString
 {
 get
 {
 if (this.replenishment_datetime.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",replenishment_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region ModifiedBy
 private bool modified_byChanged = false;
 private int? modified_by;
 public int? ModifiedBy
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
 if (this.modified_by.HasValue)
 return modified_by.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region ModificationTime
 private bool modification_timeChanged = false;
 private DateTime? modification_time;
 public DateTime? ModificationTime
 {
 get { return modification_time; }
 set { 
modification_time = value;
modification_timeChanged = true;
 }
 }
 private string modification_timeDbString
 {
 get
 {
 if (this.modification_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region CreationTime
 private bool creation_timeChanged = false;
 private DateTime? creation_time;
 public DateTime? CreationTime
 {
 get { return creation_time; }
 set { 
creation_time = value;
creation_timeChanged = true;
 }
 }
 private string creation_timeDbString
 {
 get
 {
 if (this.creation_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",creation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region IsReminderSentToCit
 private bool is_reminder_sent_to_citChanged = false;
 private bool? is_reminder_sent_to_cit;
 public bool? IsReminderSentToCit
 {
 get { return is_reminder_sent_to_cit; }
 set { 
is_reminder_sent_to_cit = value;
is_reminder_sent_to_citChanged = true;
 }
 }
 private string is_reminder_sent_to_citDbString
 {
 get
 {
 if (this.is_reminder_sent_to_cit.HasValue)
 return is_reminder_sent_to_cit.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region CashOrdersReader
 public class CashOrdersReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
CashOrders currentCashOrders;
 Columns columns;
 bool partialRead = false;
 private CashOrdersReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public CashOrdersReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public CashOrdersReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentCashOrders; }

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
 currentCashOrders = new CashOrders();
 if (partialRead)
 { if ((columns & Columns.cash_order_id) == Columns.cash_order_id && reader["cash_order_id"]!=DBNull.Value)
 currentCashOrders.cash_order_id =(int) reader["cash_order_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentCashOrders.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.cash_order_type) == Columns.cash_order_type && reader["cash_order_type"]!=DBNull.Value)
 currentCashOrders.cash_order_type =(string) reader["cash_order_type"]; 
 if ((columns & Columns.cash_order_datetime) == Columns.cash_order_datetime && reader["cash_order_datetime"]!=DBNull.Value)
 currentCashOrders.cash_order_datetime =(DateTime) reader["cash_order_datetime"]; 
 if ((columns & Columns.cassette1_suggested_notes) == Columns.cassette1_suggested_notes && reader["cassette1_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette1_suggested_notes =(int?) reader["cassette1_suggested_notes"]; 
 if ((columns & Columns.cassette2_suggested_notes) == Columns.cassette2_suggested_notes && reader["cassette2_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette2_suggested_notes =(int?) reader["cassette2_suggested_notes"]; 
 if ((columns & Columns.cassette3_suggested_notes) == Columns.cassette3_suggested_notes && reader["cassette3_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette3_suggested_notes =(int?) reader["cassette3_suggested_notes"]; 
 if ((columns & Columns.cassette4_suggested_notes) == Columns.cassette4_suggested_notes && reader["cassette4_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette4_suggested_notes =(int?) reader["cassette4_suggested_notes"]; 
 if ((columns & Columns.cassette5_suggested_notes) == Columns.cassette5_suggested_notes && reader["cassette5_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette5_suggested_notes =(int?) reader["cassette5_suggested_notes"]; 
 if ((columns & Columns.cassette6_suggested_notes) == Columns.cassette6_suggested_notes && reader["cassette6_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette6_suggested_notes =(int?) reader["cassette6_suggested_notes"]; 
 if ((columns & Columns.cassette7_suggested_notes) == Columns.cassette7_suggested_notes && reader["cassette7_suggested_notes"]!=DBNull.Value)
 currentCashOrders.cassette7_suggested_notes =(int?) reader["cassette7_suggested_notes"]; 
 if ((columns & Columns.cassette1_remaining_notes) == Columns.cassette1_remaining_notes && reader["cassette1_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette1_remaining_notes =(int?) reader["cassette1_remaining_notes"]; 
 if ((columns & Columns.cassette2_remaining_notes) == Columns.cassette2_remaining_notes && reader["cassette2_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette2_remaining_notes =(int?) reader["cassette2_remaining_notes"]; 
 if ((columns & Columns.cassette3_remaining_notes) == Columns.cassette3_remaining_notes && reader["cassette3_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette3_remaining_notes =(int?) reader["cassette3_remaining_notes"]; 
 if ((columns & Columns.cassette4_remaining_notes) == Columns.cassette4_remaining_notes && reader["cassette4_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette4_remaining_notes =(int?) reader["cassette4_remaining_notes"]; 
 if ((columns & Columns.cassette5_remaining_notes) == Columns.cassette5_remaining_notes && reader["cassette5_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette5_remaining_notes =(int?) reader["cassette5_remaining_notes"]; 
 if ((columns & Columns.cassette6_remaining_notes) == Columns.cassette6_remaining_notes && reader["cassette6_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette6_remaining_notes =(int?) reader["cassette6_remaining_notes"]; 
 if ((columns & Columns.cassette7_remaining_notes) == Columns.cassette7_remaining_notes && reader["cassette7_remaining_notes"]!=DBNull.Value)
 currentCashOrders.cassette7_remaining_notes =(int?) reader["cassette7_remaining_notes"]; 
 if ((columns & Columns.is_uploaded) == Columns.is_uploaded && reader["is_uploaded"]!=DBNull.Value)
 currentCashOrders.is_uploaded =(bool) reader["is_uploaded"]; 
 if ((columns & Columns.last_replenishment_at) == Columns.last_replenishment_at && reader["last_replenishment_at"]!=DBNull.Value)
 currentCashOrders.last_replenishment_at =(DateTime?) reader["last_replenishment_at"]; 
 if ((columns & Columns.ftp_file_info_id) == Columns.ftp_file_info_id && reader["ftp_file_info_id"]!=DBNull.Value)
 currentCashOrders.ftp_file_info_id =(int?) reader["ftp_file_info_id"]; 
 if ((columns & Columns.cassette1_denomination) == Columns.cassette1_denomination && reader["cassette1_denomination"]!=DBNull.Value)
 currentCashOrders.cassette1_denomination =(int?) reader["cassette1_denomination"]; 
 if ((columns & Columns.cassette2_denomination) == Columns.cassette2_denomination && reader["cassette2_denomination"]!=DBNull.Value)
 currentCashOrders.cassette2_denomination =(int?) reader["cassette2_denomination"]; 
 if ((columns & Columns.cassette3_denomination) == Columns.cassette3_denomination && reader["cassette3_denomination"]!=DBNull.Value)
 currentCashOrders.cassette3_denomination =(int?) reader["cassette3_denomination"]; 
 if ((columns & Columns.cassette4_denomination) == Columns.cassette4_denomination && reader["cassette4_denomination"]!=DBNull.Value)
 currentCashOrders.cassette4_denomination =(int?) reader["cassette4_denomination"]; 
 if ((columns & Columns.cassette5_denomination) == Columns.cassette5_denomination && reader["cassette5_denomination"]!=DBNull.Value)
 currentCashOrders.cassette5_denomination =(int?) reader["cassette5_denomination"]; 
 if ((columns & Columns.cassette6_denomination) == Columns.cassette6_denomination && reader["cassette6_denomination"]!=DBNull.Value)
 currentCashOrders.cassette6_denomination =(int?) reader["cassette6_denomination"]; 
 if ((columns & Columns.cassette7_denomination) == Columns.cassette7_denomination && reader["cassette7_denomination"]!=DBNull.Value)
 currentCashOrders.cassette7_denomination =(int?) reader["cassette7_denomination"]; 
 if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
 currentCashOrders.created_by =(int) reader["created_by"]; 
 if ((columns & Columns.dispatch_time) == Columns.dispatch_time && reader["dispatch_time"]!=DBNull.Value)
 currentCashOrders.dispatch_time =(DateTime) reader["dispatch_time"]; 
 if ((columns & Columns.order_number) == Columns.order_number && reader["order_number"]!=DBNull.Value)
 currentCashOrders.order_number =(string) reader["order_number"]; 
 if ((columns & Columns.is_vault_deducted) == Columns.is_vault_deducted && reader["is_vault_deducted"]!=DBNull.Value)
 currentCashOrders.is_vault_deducted =(bool) reader["is_vault_deducted"]; 
 if ((columns & Columns.is_cancelled) == Columns.is_cancelled && reader["is_cancelled"]!=DBNull.Value)
 currentCashOrders.is_cancelled =(bool) reader["is_cancelled"]; 
 if ((columns & Columns.is_hold) == Columns.is_hold && reader["is_hold"]!=DBNull.Value)
 currentCashOrders.is_hold =(bool?) reader["is_hold"]; 
 if ((columns & Columns.replenishment_datetime) == Columns.replenishment_datetime && reader["replenishment_datetime"]!=DBNull.Value)
 currentCashOrders.replenishment_datetime =(DateTime?) reader["replenishment_datetime"]; 
 if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
 currentCashOrders.modified_by =(int?) reader["modified_by"]; 
 if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
 currentCashOrders.modification_time =(DateTime?) reader["modification_time"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentCashOrders.creation_time =(DateTime?) reader["creation_time"]; 
 if ((columns & Columns.is_reminder_sent_to_cit) == Columns.is_reminder_sent_to_cit && reader["is_reminder_sent_to_cit"]!=DBNull.Value)
 currentCashOrders.is_reminder_sent_to_cit =(bool?) reader["is_reminder_sent_to_cit"]; 

 } else
 {
 if (reader["cash_order_id"] != DBNull.Value)
 currentCashOrders.cash_order_id = (int) reader["cash_order_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentCashOrders.atm_id = (int) reader["atm_id"]; 
 if (reader["cash_order_type"] != DBNull.Value)
 currentCashOrders.cash_order_type = (string) reader["cash_order_type"]; 
 if (reader["cash_order_datetime"] != DBNull.Value)
 currentCashOrders.cash_order_datetime = (DateTime) reader["cash_order_datetime"]; 
 if (reader["cassette1_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette1_suggested_notes = (int?) reader["cassette1_suggested_notes"]; 
 if (reader["cassette2_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette2_suggested_notes = (int?) reader["cassette2_suggested_notes"]; 
 if (reader["cassette3_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette3_suggested_notes = (int?) reader["cassette3_suggested_notes"]; 
 if (reader["cassette4_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette4_suggested_notes = (int?) reader["cassette4_suggested_notes"]; 
 if (reader["cassette5_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette5_suggested_notes = (int?) reader["cassette5_suggested_notes"]; 
 if (reader["cassette6_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette6_suggested_notes = (int?) reader["cassette6_suggested_notes"]; 
 if (reader["cassette7_suggested_notes"] != DBNull.Value)
 currentCashOrders.cassette7_suggested_notes = (int?) reader["cassette7_suggested_notes"]; 
 if (reader["cassette1_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette1_remaining_notes = (int?) reader["cassette1_remaining_notes"]; 
 if (reader["cassette2_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette2_remaining_notes = (int?) reader["cassette2_remaining_notes"]; 
 if (reader["cassette3_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette3_remaining_notes = (int?) reader["cassette3_remaining_notes"]; 
 if (reader["cassette4_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette4_remaining_notes = (int?) reader["cassette4_remaining_notes"]; 
 if (reader["cassette5_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette5_remaining_notes = (int?) reader["cassette5_remaining_notes"]; 
 if (reader["cassette6_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette6_remaining_notes = (int?) reader["cassette6_remaining_notes"]; 
 if (reader["cassette7_remaining_notes"] != DBNull.Value)
 currentCashOrders.cassette7_remaining_notes = (int?) reader["cassette7_remaining_notes"]; 
 if (reader["is_uploaded"] != DBNull.Value)
 currentCashOrders.is_uploaded = (bool) reader["is_uploaded"]; 
 if (reader["last_replenishment_at"] != DBNull.Value)
 currentCashOrders.last_replenishment_at = (DateTime?) reader["last_replenishment_at"]; 
 if (reader["ftp_file_info_id"] != DBNull.Value)
 currentCashOrders.ftp_file_info_id = (int?) reader["ftp_file_info_id"]; 
 if (reader["cassette1_denomination"] != DBNull.Value)
 currentCashOrders.cassette1_denomination = (int?) reader["cassette1_denomination"]; 
 if (reader["cassette2_denomination"] != DBNull.Value)
 currentCashOrders.cassette2_denomination = (int?) reader["cassette2_denomination"]; 
 if (reader["cassette3_denomination"] != DBNull.Value)
 currentCashOrders.cassette3_denomination = (int?) reader["cassette3_denomination"]; 
 if (reader["cassette4_denomination"] != DBNull.Value)
 currentCashOrders.cassette4_denomination = (int?) reader["cassette4_denomination"]; 
 if (reader["cassette5_denomination"] != DBNull.Value)
 currentCashOrders.cassette5_denomination = (int?) reader["cassette5_denomination"]; 
 if (reader["cassette6_denomination"] != DBNull.Value)
 currentCashOrders.cassette6_denomination = (int?) reader["cassette6_denomination"]; 
 if (reader["cassette7_denomination"] != DBNull.Value)
 currentCashOrders.cassette7_denomination = (int?) reader["cassette7_denomination"]; 
 if (reader["created_by"] != DBNull.Value)
 currentCashOrders.created_by = (int) reader["created_by"]; 
 if (reader["dispatch_time"] != DBNull.Value)
 currentCashOrders.dispatch_time = (DateTime) reader["dispatch_time"]; 
 if (reader["order_number"] != DBNull.Value)
 currentCashOrders.order_number = (string) reader["order_number"]; 
 if (reader["is_vault_deducted"] != DBNull.Value)
 currentCashOrders.is_vault_deducted = (bool) reader["is_vault_deducted"]; 
 if (reader["is_cancelled"] != DBNull.Value)
 currentCashOrders.is_cancelled = (bool) reader["is_cancelled"]; 
 if (reader["is_hold"] != DBNull.Value)
 currentCashOrders.is_hold = (bool?) reader["is_hold"]; 
 if (reader["replenishment_datetime"] != DBNull.Value)
 currentCashOrders.replenishment_datetime = (DateTime?) reader["replenishment_datetime"]; 
 if (reader["modified_by"] != DBNull.Value)
 currentCashOrders.modified_by = (int?) reader["modified_by"]; 
 if (reader["modification_time"] != DBNull.Value)
 currentCashOrders.modification_time = (DateTime?) reader["modification_time"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentCashOrders.creation_time = (DateTime?) reader["creation_time"]; 
 if (reader["is_reminder_sent_to_cit"] != DBNull.Value)
 currentCashOrders.is_reminder_sent_to_cit = (bool?) reader["is_reminder_sent_to_cit"]; 
 } 

 currentCashOrders.isNewEntity = false;
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

 public CashOrders CurrentCashOrders
 {
 get{ return currentCashOrders; }
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


 #region CashOrders functions

 public static CashOrdersReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.cash_order_id == (Columns.cash_order_id & columns))
 qry.Append("cash_order_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.cash_order_type == (Columns.cash_order_type & columns))
 qry.Append("cash_order_type,");
 if (Columns.cash_order_datetime == (Columns.cash_order_datetime & columns))
 qry.Append("cash_order_datetime,");
 if (Columns.cassette1_suggested_notes == (Columns.cassette1_suggested_notes & columns))
 qry.Append("cassette1_suggested_notes,");
 if (Columns.cassette2_suggested_notes == (Columns.cassette2_suggested_notes & columns))
 qry.Append("cassette2_suggested_notes,");
 if (Columns.cassette3_suggested_notes == (Columns.cassette3_suggested_notes & columns))
 qry.Append("cassette3_suggested_notes,");
 if (Columns.cassette4_suggested_notes == (Columns.cassette4_suggested_notes & columns))
 qry.Append("cassette4_suggested_notes,");
 if (Columns.cassette5_suggested_notes == (Columns.cassette5_suggested_notes & columns))
 qry.Append("cassette5_suggested_notes,");
 if (Columns.cassette6_suggested_notes == (Columns.cassette6_suggested_notes & columns))
 qry.Append("cassette6_suggested_notes,");
 if (Columns.cassette7_suggested_notes == (Columns.cassette7_suggested_notes & columns))
 qry.Append("cassette7_suggested_notes,");
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
 if (Columns.is_uploaded == (Columns.is_uploaded & columns))
 qry.Append("is_uploaded,");
 if (Columns.last_replenishment_at == (Columns.last_replenishment_at & columns))
 qry.Append("last_replenishment_at,");
 if (Columns.ftp_file_info_id == (Columns.ftp_file_info_id & columns))
 qry.Append("ftp_file_info_id,");
 if (Columns.cassette1_denomination == (Columns.cassette1_denomination & columns))
 qry.Append("cassette1_denomination,");
 if (Columns.cassette2_denomination == (Columns.cassette2_denomination & columns))
 qry.Append("cassette2_denomination,");
 if (Columns.cassette3_denomination == (Columns.cassette3_denomination & columns))
 qry.Append("cassette3_denomination,");
 if (Columns.cassette4_denomination == (Columns.cassette4_denomination & columns))
 qry.Append("cassette4_denomination,");
 if (Columns.cassette5_denomination == (Columns.cassette5_denomination & columns))
 qry.Append("cassette5_denomination,");
 if (Columns.cassette6_denomination == (Columns.cassette6_denomination & columns))
 qry.Append("cassette6_denomination,");
 if (Columns.cassette7_denomination == (Columns.cassette7_denomination & columns))
 qry.Append("cassette7_denomination,");
 if (Columns.created_by == (Columns.created_by & columns))
 qry.Append("created_by,");
 if (Columns.dispatch_time == (Columns.dispatch_time & columns))
 qry.Append("dispatch_time,");
 if (Columns.order_number == (Columns.order_number & columns))
 qry.Append("order_number,");
 if (Columns.is_vault_deducted == (Columns.is_vault_deducted & columns))
 qry.Append("is_vault_deducted,");
 if (Columns.is_cancelled == (Columns.is_cancelled & columns))
 qry.Append("is_cancelled,");
 if (Columns.is_hold == (Columns.is_hold & columns))
 qry.Append("is_hold,");
 if (Columns.replenishment_datetime == (Columns.replenishment_datetime & columns))
 qry.Append("replenishment_datetime,");
 if (Columns.modified_by == (Columns.modified_by & columns))
 qry.Append("modified_by,");
 if (Columns.modification_time == (Columns.modification_time & columns))
 qry.Append("modification_time,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.is_reminder_sent_to_cit == (Columns.is_reminder_sent_to_cit & columns))
 qry.Append("is_reminder_sent_to_cit,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Cash_orders ");

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
 return new CashOrdersReader(cmd.ExecuteReader(), conn, columns);
 }

 static public CashOrdersReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static CashOrdersReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select cash_order_id,atm_id,cash_order_type,cash_order_datetime,cassette1_suggested_notes,cassette2_suggested_notes,cassette3_suggested_notes,cassette4_suggested_notes,cassette5_suggested_notes,cassette6_suggested_notes,cassette7_suggested_notes,cassette1_remaining_notes,cassette2_remaining_notes,cassette3_remaining_notes,cassette4_remaining_notes,cassette5_remaining_notes,cassette6_remaining_notes,cassette7_remaining_notes,is_uploaded,last_replenishment_at,ftp_file_info_id,cassette1_denomination,cassette2_denomination,cassette3_denomination,cassette4_denomination,cassette5_denomination,cassette6_denomination,cassette7_denomination,created_by,dispatch_time,order_number,is_vault_deducted,is_cancelled,is_hold,replenishment_datetime,modified_by,modification_time,creation_time,is_reminder_sent_to_cit from Cash_orders ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new CashOrdersReader(cmd.ExecuteReader(), conn);
 }

 static public CashOrdersReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static CashOrders LoadCashOrders(string where)
 {
CashOrdersReader reader = CashOrders.ExecuteReader(where);
CashOrders _cashorders = null;
 if (reader.Read())
 _cashorders = reader.CurrentCashOrders;
 reader.Close();
 return _cashorders;
 }

 public static CashOrders LoadCashOrders(string where, IDbConnection conn)
 {
CashOrdersReader reader = CashOrders.ExecuteReader(where, conn);
CashOrders _cashorders = null;
 if (reader.Read())
 _cashorders = reader.CurrentCashOrders;
 reader.Close(false);
 return _cashorders;
 }

 public static CashOrders LoadCashOrdersByPk( int cash_order_id )
 {
 return LoadCashOrders( " cash_order_id="+cash_order_id );
 }

 public static CashOrders LoadCashOrdersByPk( int cash_order_id , IDbConnection conn)
 {
 return LoadCashOrders(" cash_order_id="+cash_order_id , conn);
 }

 public void Save()
 {
 if (cash_order_idChanged || atm_idChanged || cash_order_typeChanged || cash_order_datetimeChanged || cassette1_suggested_notesChanged || cassette2_suggested_notesChanged || cassette3_suggested_notesChanged || cassette4_suggested_notesChanged || cassette5_suggested_notesChanged || cassette6_suggested_notesChanged || cassette7_suggested_notesChanged || cassette1_remaining_notesChanged || cassette2_remaining_notesChanged || cassette3_remaining_notesChanged || cassette4_remaining_notesChanged || cassette5_remaining_notesChanged || cassette6_remaining_notesChanged || cassette7_remaining_notesChanged || is_uploadedChanged || last_replenishment_atChanged || ftp_file_info_idChanged || cassette1_denominationChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette4_denominationChanged || cassette5_denominationChanged || cassette6_denominationChanged || cassette7_denominationChanged || created_byChanged || dispatch_timeChanged || order_numberChanged || is_vault_deductedChanged || is_cancelledChanged || is_holdChanged || replenishment_datetimeChanged || modified_byChanged || modification_timeChanged || creation_timeChanged || is_reminder_sent_to_citChanged )
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
 if (cash_order_idChanged || atm_idChanged || cash_order_typeChanged || cash_order_datetimeChanged || cassette1_suggested_notesChanged || cassette2_suggested_notesChanged || cassette3_suggested_notesChanged || cassette4_suggested_notesChanged || cassette5_suggested_notesChanged || cassette6_suggested_notesChanged || cassette7_suggested_notesChanged || cassette1_remaining_notesChanged || cassette2_remaining_notesChanged || cassette3_remaining_notesChanged || cassette4_remaining_notesChanged || cassette5_remaining_notesChanged || cassette6_remaining_notesChanged || cassette7_remaining_notesChanged || is_uploadedChanged || last_replenishment_atChanged || ftp_file_info_idChanged || cassette1_denominationChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette4_denominationChanged || cassette5_denominationChanged || cassette6_denominationChanged || cassette7_denominationChanged || created_byChanged || dispatch_timeChanged || order_numberChanged || is_vault_deductedChanged || is_cancelledChanged || is_holdChanged || replenishment_datetimeChanged || modified_byChanged || modification_timeChanged || creation_timeChanged || is_reminder_sent_to_citChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Cash_orders( cash_order_id,atm_id,cash_order_type,cash_order_datetime,cassette1_suggested_notes,cassette2_suggested_notes,cassette3_suggested_notes,cassette4_suggested_notes,cassette5_suggested_notes,cassette6_suggested_notes,cassette7_suggested_notes,cassette1_remaining_notes,cassette2_remaining_notes,cassette3_remaining_notes,cassette4_remaining_notes,cassette5_remaining_notes,cassette6_remaining_notes,cassette7_remaining_notes,is_uploaded,last_replenishment_at,ftp_file_info_id,cassette1_denomination,cassette2_denomination,cassette3_denomination,cassette4_denomination,cassette5_denomination,cassette6_denomination,cassette7_denomination,created_by,dispatch_time,order_number,is_vault_deducted,is_cancelled,is_hold,replenishment_datetime,modified_by,modification_time,creation_time,is_reminder_sent_to_cit ) values(");
 lock (ConnectionFactory.connectionString) { this.cash_order_id = ConnectionFactory.GetNextId();
 qry.Append(this.cash_order_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(cash_order_typeDbString+",");
 qry.Append(cash_order_datetimeDbString+",");
 qry.Append(cassette1_suggested_notesDbString+",");
 qry.Append(cassette2_suggested_notesDbString+",");
 qry.Append(cassette3_suggested_notesDbString+",");
 qry.Append(cassette4_suggested_notesDbString+",");
 qry.Append(cassette5_suggested_notesDbString+",");
 qry.Append(cassette6_suggested_notesDbString+",");
 qry.Append(cassette7_suggested_notesDbString+",");
 qry.Append(cassette1_remaining_notesDbString+",");
 qry.Append(cassette2_remaining_notesDbString+",");
 qry.Append(cassette3_remaining_notesDbString+",");
 qry.Append(cassette4_remaining_notesDbString+",");
 qry.Append(cassette5_remaining_notesDbString+",");
 qry.Append(cassette6_remaining_notesDbString+",");
 qry.Append(cassette7_remaining_notesDbString+",");
 qry.Append(is_uploadedDbString+",");
 qry.Append(last_replenishment_atDbString+",");
 qry.Append(ftp_file_info_idDbString+",");
 qry.Append(cassette1_denominationDbString+",");
 qry.Append(cassette2_denominationDbString+",");
 qry.Append(cassette3_denominationDbString+",");
 qry.Append(cassette4_denominationDbString+",");
 qry.Append(cassette5_denominationDbString+",");
 qry.Append(cassette6_denominationDbString+",");
 qry.Append(cassette7_denominationDbString+",");
 qry.Append(created_byDbString+",");
 qry.Append(dispatch_timeDbString+",");
 qry.Append(order_numberDbString+",");
 qry.Append(is_vault_deductedDbString+",");
 qry.Append(is_cancelledDbString+",");
 qry.Append(is_holdDbString+",");
 qry.Append(replenishment_datetimeDbString+",");
 qry.Append(modified_byDbString+",");
 qry.Append(modification_timeDbString+",");
 qry.Append(creation_timeDbString+",");
 qry.Append(is_reminder_sent_to_citDbString);
 qry.Append(");");

 }
 else
 {
 if (!(cash_order_idChanged || atm_idChanged || cash_order_typeChanged || cash_order_datetimeChanged || cassette1_suggested_notesChanged || cassette2_suggested_notesChanged || cassette3_suggested_notesChanged || cassette4_suggested_notesChanged || cassette5_suggested_notesChanged || cassette6_suggested_notesChanged || cassette7_suggested_notesChanged || cassette1_remaining_notesChanged || cassette2_remaining_notesChanged || cassette3_remaining_notesChanged || cassette4_remaining_notesChanged || cassette5_remaining_notesChanged || cassette6_remaining_notesChanged || cassette7_remaining_notesChanged || is_uploadedChanged || last_replenishment_atChanged || ftp_file_info_idChanged || cassette1_denominationChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette4_denominationChanged || cassette5_denominationChanged || cassette6_denominationChanged || cassette7_denominationChanged || created_byChanged || dispatch_timeChanged || order_numberChanged || is_vault_deductedChanged || is_cancelledChanged || is_holdChanged || replenishment_datetimeChanged || modified_byChanged || modification_timeChanged || creation_timeChanged || is_reminder_sent_to_citChanged ))
 return;
 qry.Append("UPDATE Cash_orders set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( cash_order_typeChanged )
 {
 qry.Append("cash_order_type ="+cash_order_typeDbString);
 qry.Append(",");
 }

 if ( cash_order_datetimeChanged )
 {
 qry.Append("cash_order_datetime ="+cash_order_datetimeDbString);
 qry.Append(",");
 }

 if ( cassette1_suggested_notesChanged )
 {
 qry.Append("cassette1_suggested_notes ="+cassette1_suggested_notesDbString);
 qry.Append(",");
 }

 if ( cassette2_suggested_notesChanged )
 {
 qry.Append("cassette2_suggested_notes ="+cassette2_suggested_notesDbString);
 qry.Append(",");
 }

 if ( cassette3_suggested_notesChanged )
 {
 qry.Append("cassette3_suggested_notes ="+cassette3_suggested_notesDbString);
 qry.Append(",");
 }

 if ( cassette4_suggested_notesChanged )
 {
 qry.Append("cassette4_suggested_notes ="+cassette4_suggested_notesDbString);
 qry.Append(",");
 }

 if ( cassette5_suggested_notesChanged )
 {
 qry.Append("cassette5_suggested_notes ="+cassette5_suggested_notesDbString);
 qry.Append(",");
 }

 if ( cassette6_suggested_notesChanged )
 {
 qry.Append("cassette6_suggested_notes ="+cassette6_suggested_notesDbString);
 qry.Append(",");
 }

 if ( cassette7_suggested_notesChanged )
 {
 qry.Append("cassette7_suggested_notes ="+cassette7_suggested_notesDbString);
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

 if ( is_uploadedChanged )
 {
 qry.Append("is_uploaded ="+is_uploadedDbString);
 qry.Append(",");
 }

 if ( last_replenishment_atChanged )
 {
 qry.Append("last_replenishment_at ="+last_replenishment_atDbString);
 qry.Append(",");
 }

 if ( ftp_file_info_idChanged )
 {
 qry.Append("ftp_file_info_id ="+ftp_file_info_idDbString);
 qry.Append(",");
 }

 if ( cassette1_denominationChanged )
 {
 qry.Append("cassette1_denomination ="+cassette1_denominationDbString);
 qry.Append(",");
 }

 if ( cassette2_denominationChanged )
 {
 qry.Append("cassette2_denomination ="+cassette2_denominationDbString);
 qry.Append(",");
 }

 if ( cassette3_denominationChanged )
 {
 qry.Append("cassette3_denomination ="+cassette3_denominationDbString);
 qry.Append(",");
 }

 if ( cassette4_denominationChanged )
 {
 qry.Append("cassette4_denomination ="+cassette4_denominationDbString);
 qry.Append(",");
 }

 if ( cassette5_denominationChanged )
 {
 qry.Append("cassette5_denomination ="+cassette5_denominationDbString);
 qry.Append(",");
 }

 if ( cassette6_denominationChanged )
 {
 qry.Append("cassette6_denomination ="+cassette6_denominationDbString);
 qry.Append(",");
 }

 if ( cassette7_denominationChanged )
 {
 qry.Append("cassette7_denomination ="+cassette7_denominationDbString);
 qry.Append(",");
 }

 if ( created_byChanged )
 {
 qry.Append("created_by ="+created_byDbString);
 qry.Append(",");
 }

 if ( dispatch_timeChanged )
 {
 qry.Append("dispatch_time ="+dispatch_timeDbString);
 qry.Append(",");
 }

 if ( order_numberChanged )
 {
 qry.Append("order_number ="+order_numberDbString);
 qry.Append(",");
 }

 if ( is_vault_deductedChanged )
 {
 qry.Append("is_vault_deducted ="+is_vault_deductedDbString);
 qry.Append(",");
 }

 if ( is_cancelledChanged )
 {
 qry.Append("is_cancelled ="+is_cancelledDbString);
 qry.Append(",");
 }

 if ( is_holdChanged )
 {
 qry.Append("is_hold ="+is_holdDbString);
 qry.Append(",");
 }

 if ( replenishment_datetimeChanged )
 {
 qry.Append("replenishment_datetime ="+replenishment_datetimeDbString);
 qry.Append(",");
 }

 if ( modified_byChanged )
 {
 qry.Append("modified_by ="+modified_byDbString);
 qry.Append(",");
 }

 if ( modification_timeChanged )
 {
 qry.Append("modification_time ="+modification_timeDbString);
 qry.Append(",");
 }

 if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( is_reminder_sent_to_citChanged )
 {
 qry.Append("is_reminder_sent_to_cit ="+is_reminder_sent_to_citDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("cash_order_id = "+cash_order_idDbString);
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
 cmd.CommandText = "DELETE Cash_orders where cash_order_id = "+ cash_order_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteCashOrderss(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Cash_orders where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:ulong
 {
cash_order_id= 1,
atm_id= 2,
cash_order_type= 4,
cash_order_datetime= 8,
cassette1_suggested_notes= 16,
cassette2_suggested_notes= 32,
cassette3_suggested_notes= 64,
cassette4_suggested_notes= 128,
cassette5_suggested_notes= 256,
cassette6_suggested_notes= 512,
cassette7_suggested_notes= 1024,
cassette1_remaining_notes= 2048,
cassette2_remaining_notes= 4096,
cassette3_remaining_notes= 8192,
cassette4_remaining_notes= 16384,
cassette5_remaining_notes= 32768,
cassette6_remaining_notes= 65536,
cassette7_remaining_notes= 131072,
is_uploaded= 262144,
last_replenishment_at= 524288,
ftp_file_info_id= 1048576,
cassette1_denomination= 2097152,
cassette2_denomination= 4194304,
cassette3_denomination= 8388608,
cassette4_denomination= 16777216,
cassette5_denomination= 33554432,
cassette6_denomination= 67108864,
cassette7_denomination= 134217728,
created_by= 268435456,
dispatch_time= 536870912,
order_number= 1073741824,
is_vault_deducted= 2147483648,
is_cancelled= 4294967296,
is_hold= 8589934592,
replenishment_datetime= 17179869184,
modified_by= 34359738368,
modification_time= 68719476736,
creation_time= 137438953472,
is_reminder_sent_to_cit= 274877906944
 }
 #endregion
 public void BulkSave(List<CashOrders> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Cash_orders";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(CashOrders.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <CashOrders> transList,ref DataTable dt)
 {
 foreach (CashOrders tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["cash_order_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["cash_order_type"] = tran.CashOrderType;
 Row["cash_order_datetime"] = tran.CashOrderDatetime;
 Row["cassette1_suggested_notes"] = tran.Cassette1SuggestedNotes;
 Row["cassette2_suggested_notes"] = tran.Cassette2SuggestedNotes;
 Row["cassette3_suggested_notes"] = tran.Cassette3SuggestedNotes;
 Row["cassette4_suggested_notes"] = tran.Cassette4SuggestedNotes;
 Row["cassette5_suggested_notes"] = tran.Cassette5SuggestedNotes;
 Row["cassette6_suggested_notes"] = tran.Cassette6SuggestedNotes;
 Row["cassette7_suggested_notes"] = tran.Cassette7SuggestedNotes;
 Row["cassette1_remaining_notes"] = tran.Cassette1RemainingNotes;
 Row["cassette2_remaining_notes"] = tran.Cassette2RemainingNotes;
 Row["cassette3_remaining_notes"] = tran.Cassette3RemainingNotes;
 Row["cassette4_remaining_notes"] = tran.Cassette4RemainingNotes;
 Row["cassette5_remaining_notes"] = tran.Cassette5RemainingNotes;
 Row["cassette6_remaining_notes"] = tran.Cassette6RemainingNotes;
 Row["cassette7_remaining_notes"] = tran.Cassette7RemainingNotes;
 Row["is_uploaded"] = tran.IsUploaded;
 Row["last_replenishment_at"] = tran.LastReplenishmentAt;
 Row["ftp_file_info_id"] = tran.FtpFileInfoId;
 Row["cassette1_denomination"] = tran.Cassette1Denomination;
 Row["cassette2_denomination"] = tran.Cassette2Denomination;
 Row["cassette3_denomination"] = tran.Cassette3Denomination;
 Row["cassette4_denomination"] = tran.Cassette4Denomination;
 Row["cassette5_denomination"] = tran.Cassette5Denomination;
 Row["cassette6_denomination"] = tran.Cassette6Denomination;
 Row["cassette7_denomination"] = tran.Cassette7Denomination;
 Row["created_by"] = tran.CreatedBy;
 Row["dispatch_time"] = tran.DispatchTime;
 Row["order_number"] = tran.OrderNumber;
 Row["is_vault_deducted"] = tran.IsVaultDeducted;
 Row["is_cancelled"] = tran.IsCancelled;
 Row["is_hold"] = tran.IsHold;
 Row["replenishment_datetime"] = tran.ReplenishmentDatetime;
 Row["modified_by"] = tran.ModifiedBy;
 Row["modification_time"] = tran.ModificationTime;
 Row["creation_time"] = tran.CreationTime;
 Row["is_reminder_sent_to_cit"] = tran.IsReminderSentToCit;
 dt.Rows.Add(Row);
 } }
 }
 }

 
