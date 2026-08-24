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
public class AtmSettlementHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmSettlementHistory() { }
public AtmSettlementHistory( int atm_settlement_history_id,int atm_settlement_id ) 
{
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
}
public AtmSettlementHistory( int atm_settlement_id,string gl_no,DateTime? rep_datetime,string seal_number,int? cash_rep_denomination_type1,int? cash_rep_counters_type1,int? cash_rep_denomination_type2,int? cash_rep_counters_type2,int? cash_rep_denomination_type3,int? cash_rep_counters_type3,int? cash_rep_denomination_type4,int? cash_rep_counters_type4,int? cash_return_denomination_type1,int? cash_return_counters_type1,int? cash_return_denomination_type2,int? cash_return_counters_type2,int? cash_return_denomination_type3,int? cash_return_counters_type3,int? cash_return_denomination_type4,int? cash_return_counters_type4,int? cash_dispensed_denomination_type1,int? cash_dispensed_counters_type1,int? cash_dispensed_denomination_type2,int? cash_dispensed_counters_type2,int? cash_dispensed_denomination_type3,int? cash_dispensed_counters_type3,int? cash_dispensed_denomination_type4,int? cash_dispensed_counters_type4,int? cash_rejected_denomination_type1,int? cash_rejected_counters_type1,int? cash_rejected_denomination_type2,int? cash_rejected_counters_type2,int? cash_rejected_denomination_type3,int? cash_rejected_counters_type3,int? cash_rejected_denomination_type4,int? cash_rejected_counters_type4,int? uploaded_by,DateTime? upload_datetime,string atm_site_and_number,decimal? total_replenished,DateTime? date_of_old_replenised,string location,int? atm_no,decimal? total_returned,int? cash_rep_denomination_type5,int? cash_rep_counters_type5,int? cash_rep_denomination_type6,int? cash_rep_counters_type6,int? cash_rep_denomination_type7,int? cash_rep_counters_type7,int? cash_return_denomination_type5,int? cash_return_counters_type5,int? cash_return_denomination_type6,int? cash_return_counters_type6,int? cash_return_denomination_type7,int? cash_return_counters_type7,int? cash_dispensed_denomination_type5,int? cash_dispensed_counters_type5,int? cash_dispensed_denomination_type6,int? cash_dispensed_counters_type6,int? cash_dispensed_denomination_type7,int? cash_dispensed_counters_type7,int? cash_rejected_denomination_type5,int? cash_rejected_counters_type5,int? cash_rejected_denomination_type6,int? cash_rejected_counters_type6,int? cash_rejected_denomination_type7,int? cash_rejected_counters_type7,int? cash_rem_denomination_type5,int? cash_rem_counters_type5,int? cash_rem_denomination_type6,int? cash_rem_counters_type6,int? cash_rem_denomination_type7,int? cash_rem_counters_type7 )
{
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
this.gl_no = gl_no;
this.gl_noChanged = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.seal_number = seal_number;
this.seal_numberChanged = true;
this.cash_rep_denomination_type1 = cash_rep_denomination_type1;
this.cash_rep_denomination_type1Changed = true;
this.cash_rep_counters_type1 = cash_rep_counters_type1;
this.cash_rep_counters_type1Changed = true;
this.cash_rep_denomination_type2 = cash_rep_denomination_type2;
this.cash_rep_denomination_type2Changed = true;
this.cash_rep_counters_type2 = cash_rep_counters_type2;
this.cash_rep_counters_type2Changed = true;
this.cash_rep_denomination_type3 = cash_rep_denomination_type3;
this.cash_rep_denomination_type3Changed = true;
this.cash_rep_counters_type3 = cash_rep_counters_type3;
this.cash_rep_counters_type3Changed = true;
this.cash_rep_denomination_type4 = cash_rep_denomination_type4;
this.cash_rep_denomination_type4Changed = true;
this.cash_rep_counters_type4 = cash_rep_counters_type4;
this.cash_rep_counters_type4Changed = true;
this.cash_return_denomination_type1 = cash_return_denomination_type1;
this.cash_return_denomination_type1Changed = true;
this.cash_return_counters_type1 = cash_return_counters_type1;
this.cash_return_counters_type1Changed = true;
this.cash_return_denomination_type2 = cash_return_denomination_type2;
this.cash_return_denomination_type2Changed = true;
this.cash_return_counters_type2 = cash_return_counters_type2;
this.cash_return_counters_type2Changed = true;
this.cash_return_denomination_type3 = cash_return_denomination_type3;
this.cash_return_denomination_type3Changed = true;
this.cash_return_counters_type3 = cash_return_counters_type3;
this.cash_return_counters_type3Changed = true;
this.cash_return_denomination_type4 = cash_return_denomination_type4;
this.cash_return_denomination_type4Changed = true;
this.cash_return_counters_type4 = cash_return_counters_type4;
this.cash_return_counters_type4Changed = true;
this.cash_dispensed_denomination_type1 = cash_dispensed_denomination_type1;
this.cash_dispensed_denomination_type1Changed = true;
this.cash_dispensed_counters_type1 = cash_dispensed_counters_type1;
this.cash_dispensed_counters_type1Changed = true;
this.cash_dispensed_denomination_type2 = cash_dispensed_denomination_type2;
this.cash_dispensed_denomination_type2Changed = true;
this.cash_dispensed_counters_type2 = cash_dispensed_counters_type2;
this.cash_dispensed_counters_type2Changed = true;
this.cash_dispensed_denomination_type3 = cash_dispensed_denomination_type3;
this.cash_dispensed_denomination_type3Changed = true;
this.cash_dispensed_counters_type3 = cash_dispensed_counters_type3;
this.cash_dispensed_counters_type3Changed = true;
this.cash_dispensed_denomination_type4 = cash_dispensed_denomination_type4;
this.cash_dispensed_denomination_type4Changed = true;
this.cash_dispensed_counters_type4 = cash_dispensed_counters_type4;
this.cash_dispensed_counters_type4Changed = true;
this.cash_rejected_denomination_type1 = cash_rejected_denomination_type1;
this.cash_rejected_denomination_type1Changed = true;
this.cash_rejected_counters_type1 = cash_rejected_counters_type1;
this.cash_rejected_counters_type1Changed = true;
this.cash_rejected_denomination_type2 = cash_rejected_denomination_type2;
this.cash_rejected_denomination_type2Changed = true;
this.cash_rejected_counters_type2 = cash_rejected_counters_type2;
this.cash_rejected_counters_type2Changed = true;
this.cash_rejected_denomination_type3 = cash_rejected_denomination_type3;
this.cash_rejected_denomination_type3Changed = true;
this.cash_rejected_counters_type3 = cash_rejected_counters_type3;
this.cash_rejected_counters_type3Changed = true;
this.cash_rejected_denomination_type4 = cash_rejected_denomination_type4;
this.cash_rejected_denomination_type4Changed = true;
this.cash_rejected_counters_type4 = cash_rejected_counters_type4;
this.cash_rejected_counters_type4Changed = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.upload_datetime = upload_datetime;
this.upload_datetimeChanged = true;
this.atm_site_and_number = atm_site_and_number;
this.atm_site_and_numberChanged = true;
this.total_replenished = total_replenished;
this.total_replenishedChanged = true;
this.date_of_old_replenised = date_of_old_replenised;
this.date_of_old_replenisedChanged = true;
this.location = location;
this.locationChanged = true;
this.atm_no = atm_no;
this.atm_noChanged = true;
this.total_returned = total_returned;
this.total_returnedChanged = true;
this.cash_rep_denomination_type5 = cash_rep_denomination_type5;
this.cash_rep_denomination_type5Changed = true;
this.cash_rep_counters_type5 = cash_rep_counters_type5;
this.cash_rep_counters_type5Changed = true;
this.cash_rep_denomination_type6 = cash_rep_denomination_type6;
this.cash_rep_denomination_type6Changed = true;
this.cash_rep_counters_type6 = cash_rep_counters_type6;
this.cash_rep_counters_type6Changed = true;
this.cash_rep_denomination_type7 = cash_rep_denomination_type7;
this.cash_rep_denomination_type7Changed = true;
this.cash_rep_counters_type7 = cash_rep_counters_type7;
this.cash_rep_counters_type7Changed = true;
this.cash_return_denomination_type5 = cash_return_denomination_type5;
this.cash_return_denomination_type5Changed = true;
this.cash_return_counters_type5 = cash_return_counters_type5;
this.cash_return_counters_type5Changed = true;
this.cash_return_denomination_type6 = cash_return_denomination_type6;
this.cash_return_denomination_type6Changed = true;
this.cash_return_counters_type6 = cash_return_counters_type6;
this.cash_return_counters_type6Changed = true;
this.cash_return_denomination_type7 = cash_return_denomination_type7;
this.cash_return_denomination_type7Changed = true;
this.cash_return_counters_type7 = cash_return_counters_type7;
this.cash_return_counters_type7Changed = true;
this.cash_dispensed_denomination_type5 = cash_dispensed_denomination_type5;
this.cash_dispensed_denomination_type5Changed = true;
this.cash_dispensed_counters_type5 = cash_dispensed_counters_type5;
this.cash_dispensed_counters_type5Changed = true;
this.cash_dispensed_denomination_type6 = cash_dispensed_denomination_type6;
this.cash_dispensed_denomination_type6Changed = true;
this.cash_dispensed_counters_type6 = cash_dispensed_counters_type6;
this.cash_dispensed_counters_type6Changed = true;
this.cash_dispensed_denomination_type7 = cash_dispensed_denomination_type7;
this.cash_dispensed_denomination_type7Changed = true;
this.cash_dispensed_counters_type7 = cash_dispensed_counters_type7;
this.cash_dispensed_counters_type7Changed = true;
this.cash_rejected_denomination_type5 = cash_rejected_denomination_type5;
this.cash_rejected_denomination_type5Changed = true;
this.cash_rejected_counters_type5 = cash_rejected_counters_type5;
this.cash_rejected_counters_type5Changed = true;
this.cash_rejected_denomination_type6 = cash_rejected_denomination_type6;
this.cash_rejected_denomination_type6Changed = true;
this.cash_rejected_counters_type6 = cash_rejected_counters_type6;
this.cash_rejected_counters_type6Changed = true;
this.cash_rejected_denomination_type7 = cash_rejected_denomination_type7;
this.cash_rejected_denomination_type7Changed = true;
this.cash_rejected_counters_type7 = cash_rejected_counters_type7;
this.cash_rejected_counters_type7Changed = true;
this.cash_rem_denomination_type5 = cash_rem_denomination_type5;
this.cash_rem_denomination_type5Changed = true;
this.cash_rem_counters_type5 = cash_rem_counters_type5;
this.cash_rem_counters_type5Changed = true;
this.cash_rem_denomination_type6 = cash_rem_denomination_type6;
this.cash_rem_denomination_type6Changed = true;
this.cash_rem_counters_type6 = cash_rem_counters_type6;
this.cash_rem_counters_type6Changed = true;
this.cash_rem_denomination_type7 = cash_rem_denomination_type7;
this.cash_rem_denomination_type7Changed = true;
this.cash_rem_counters_type7 = cash_rem_counters_type7;
this.cash_rem_counters_type7Changed = true;
}
private AtmSettlementHistory( int atm_settlement_history_id,int atm_settlement_id,string gl_no,DateTime? rep_datetime,string seal_number,int? cash_rep_denomination_type1,int? cash_rep_counters_type1,int? cash_rep_denomination_type2,int? cash_rep_counters_type2,int? cash_rep_denomination_type3,int? cash_rep_counters_type3,int? cash_rep_denomination_type4,int? cash_rep_counters_type4,int? cash_return_denomination_type1,int? cash_return_counters_type1,int? cash_return_denomination_type2,int? cash_return_counters_type2,int? cash_return_denomination_type3,int? cash_return_counters_type3,int? cash_return_denomination_type4,int? cash_return_counters_type4,int? cash_dispensed_denomination_type1,int? cash_dispensed_counters_type1,int? cash_dispensed_denomination_type2,int? cash_dispensed_counters_type2,int? cash_dispensed_denomination_type3,int? cash_dispensed_counters_type3,int? cash_dispensed_denomination_type4,int? cash_dispensed_counters_type4,int? cash_rejected_denomination_type1,int? cash_rejected_counters_type1,int? cash_rejected_denomination_type2,int? cash_rejected_counters_type2,int? cash_rejected_denomination_type3,int? cash_rejected_counters_type3,int? cash_rejected_denomination_type4,int? cash_rejected_counters_type4,int? uploaded_by,DateTime? upload_datetime,string atm_site_and_number,decimal? total_replenished,DateTime? date_of_old_replenised,string location,int? atm_no,decimal? total_returned,int? cash_rep_denomination_type5,int? cash_rep_counters_type5,int? cash_rep_denomination_type6,int? cash_rep_counters_type6,int? cash_rep_denomination_type7,int? cash_rep_counters_type7,int? cash_return_denomination_type5,int? cash_return_counters_type5,int? cash_return_denomination_type6,int? cash_return_counters_type6,int? cash_return_denomination_type7,int? cash_return_counters_type7,int? cash_dispensed_denomination_type5,int? cash_dispensed_counters_type5,int? cash_dispensed_denomination_type6,int? cash_dispensed_counters_type6,int? cash_dispensed_denomination_type7,int? cash_dispensed_counters_type7,int? cash_rejected_denomination_type5,int? cash_rejected_counters_type5,int? cash_rejected_denomination_type6,int? cash_rejected_counters_type6,int? cash_rejected_denomination_type7,int? cash_rejected_counters_type7,int? cash_rem_denomination_type5,int? cash_rem_counters_type5,int? cash_rem_denomination_type6,int? cash_rem_counters_type6,int? cash_rem_denomination_type7,int? cash_rem_counters_type7 )
{
this.atm_settlement_history_id = atm_settlement_history_id;
this.atm_settlement_history_idChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
this.gl_no = gl_no;
this.gl_noChanged = true;
this.rep_datetime = rep_datetime;
this.rep_datetimeChanged = true;
this.seal_number = seal_number;
this.seal_numberChanged = true;
this.cash_rep_denomination_type1 = cash_rep_denomination_type1;
this.cash_rep_denomination_type1Changed = true;
this.cash_rep_counters_type1 = cash_rep_counters_type1;
this.cash_rep_counters_type1Changed = true;
this.cash_rep_denomination_type2 = cash_rep_denomination_type2;
this.cash_rep_denomination_type2Changed = true;
this.cash_rep_counters_type2 = cash_rep_counters_type2;
this.cash_rep_counters_type2Changed = true;
this.cash_rep_denomination_type3 = cash_rep_denomination_type3;
this.cash_rep_denomination_type3Changed = true;
this.cash_rep_counters_type3 = cash_rep_counters_type3;
this.cash_rep_counters_type3Changed = true;
this.cash_rep_denomination_type4 = cash_rep_denomination_type4;
this.cash_rep_denomination_type4Changed = true;
this.cash_rep_counters_type4 = cash_rep_counters_type4;
this.cash_rep_counters_type4Changed = true;
this.cash_return_denomination_type1 = cash_return_denomination_type1;
this.cash_return_denomination_type1Changed = true;
this.cash_return_counters_type1 = cash_return_counters_type1;
this.cash_return_counters_type1Changed = true;
this.cash_return_denomination_type2 = cash_return_denomination_type2;
this.cash_return_denomination_type2Changed = true;
this.cash_return_counters_type2 = cash_return_counters_type2;
this.cash_return_counters_type2Changed = true;
this.cash_return_denomination_type3 = cash_return_denomination_type3;
this.cash_return_denomination_type3Changed = true;
this.cash_return_counters_type3 = cash_return_counters_type3;
this.cash_return_counters_type3Changed = true;
this.cash_return_denomination_type4 = cash_return_denomination_type4;
this.cash_return_denomination_type4Changed = true;
this.cash_return_counters_type4 = cash_return_counters_type4;
this.cash_return_counters_type4Changed = true;
this.cash_dispensed_denomination_type1 = cash_dispensed_denomination_type1;
this.cash_dispensed_denomination_type1Changed = true;
this.cash_dispensed_counters_type1 = cash_dispensed_counters_type1;
this.cash_dispensed_counters_type1Changed = true;
this.cash_dispensed_denomination_type2 = cash_dispensed_denomination_type2;
this.cash_dispensed_denomination_type2Changed = true;
this.cash_dispensed_counters_type2 = cash_dispensed_counters_type2;
this.cash_dispensed_counters_type2Changed = true;
this.cash_dispensed_denomination_type3 = cash_dispensed_denomination_type3;
this.cash_dispensed_denomination_type3Changed = true;
this.cash_dispensed_counters_type3 = cash_dispensed_counters_type3;
this.cash_dispensed_counters_type3Changed = true;
this.cash_dispensed_denomination_type4 = cash_dispensed_denomination_type4;
this.cash_dispensed_denomination_type4Changed = true;
this.cash_dispensed_counters_type4 = cash_dispensed_counters_type4;
this.cash_dispensed_counters_type4Changed = true;
this.cash_rejected_denomination_type1 = cash_rejected_denomination_type1;
this.cash_rejected_denomination_type1Changed = true;
this.cash_rejected_counters_type1 = cash_rejected_counters_type1;
this.cash_rejected_counters_type1Changed = true;
this.cash_rejected_denomination_type2 = cash_rejected_denomination_type2;
this.cash_rejected_denomination_type2Changed = true;
this.cash_rejected_counters_type2 = cash_rejected_counters_type2;
this.cash_rejected_counters_type2Changed = true;
this.cash_rejected_denomination_type3 = cash_rejected_denomination_type3;
this.cash_rejected_denomination_type3Changed = true;
this.cash_rejected_counters_type3 = cash_rejected_counters_type3;
this.cash_rejected_counters_type3Changed = true;
this.cash_rejected_denomination_type4 = cash_rejected_denomination_type4;
this.cash_rejected_denomination_type4Changed = true;
this.cash_rejected_counters_type4 = cash_rejected_counters_type4;
this.cash_rejected_counters_type4Changed = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.upload_datetime = upload_datetime;
this.upload_datetimeChanged = true;
this.atm_site_and_number = atm_site_and_number;
this.atm_site_and_numberChanged = true;
this.total_replenished = total_replenished;
this.total_replenishedChanged = true;
this.date_of_old_replenised = date_of_old_replenised;
this.date_of_old_replenisedChanged = true;
this.location = location;
this.locationChanged = true;
this.atm_no = atm_no;
this.atm_noChanged = true;
this.total_returned = total_returned;
this.total_returnedChanged = true;
this.cash_rep_denomination_type5 = cash_rep_denomination_type5;
this.cash_rep_denomination_type5Changed = true;
this.cash_rep_counters_type5 = cash_rep_counters_type5;
this.cash_rep_counters_type5Changed = true;
this.cash_rep_denomination_type6 = cash_rep_denomination_type6;
this.cash_rep_denomination_type6Changed = true;
this.cash_rep_counters_type6 = cash_rep_counters_type6;
this.cash_rep_counters_type6Changed = true;
this.cash_rep_denomination_type7 = cash_rep_denomination_type7;
this.cash_rep_denomination_type7Changed = true;
this.cash_rep_counters_type7 = cash_rep_counters_type7;
this.cash_rep_counters_type7Changed = true;
this.cash_return_denomination_type5 = cash_return_denomination_type5;
this.cash_return_denomination_type5Changed = true;
this.cash_return_counters_type5 = cash_return_counters_type5;
this.cash_return_counters_type5Changed = true;
this.cash_return_denomination_type6 = cash_return_denomination_type6;
this.cash_return_denomination_type6Changed = true;
this.cash_return_counters_type6 = cash_return_counters_type6;
this.cash_return_counters_type6Changed = true;
this.cash_return_denomination_type7 = cash_return_denomination_type7;
this.cash_return_denomination_type7Changed = true;
this.cash_return_counters_type7 = cash_return_counters_type7;
this.cash_return_counters_type7Changed = true;
this.cash_dispensed_denomination_type5 = cash_dispensed_denomination_type5;
this.cash_dispensed_denomination_type5Changed = true;
this.cash_dispensed_counters_type5 = cash_dispensed_counters_type5;
this.cash_dispensed_counters_type5Changed = true;
this.cash_dispensed_denomination_type6 = cash_dispensed_denomination_type6;
this.cash_dispensed_denomination_type6Changed = true;
this.cash_dispensed_counters_type6 = cash_dispensed_counters_type6;
this.cash_dispensed_counters_type6Changed = true;
this.cash_dispensed_denomination_type7 = cash_dispensed_denomination_type7;
this.cash_dispensed_denomination_type7Changed = true;
this.cash_dispensed_counters_type7 = cash_dispensed_counters_type7;
this.cash_dispensed_counters_type7Changed = true;
this.cash_rejected_denomination_type5 = cash_rejected_denomination_type5;
this.cash_rejected_denomination_type5Changed = true;
this.cash_rejected_counters_type5 = cash_rejected_counters_type5;
this.cash_rejected_counters_type5Changed = true;
this.cash_rejected_denomination_type6 = cash_rejected_denomination_type6;
this.cash_rejected_denomination_type6Changed = true;
this.cash_rejected_counters_type6 = cash_rejected_counters_type6;
this.cash_rejected_counters_type6Changed = true;
this.cash_rejected_denomination_type7 = cash_rejected_denomination_type7;
this.cash_rejected_denomination_type7Changed = true;
this.cash_rejected_counters_type7 = cash_rejected_counters_type7;
this.cash_rejected_counters_type7Changed = true;
this.cash_rem_denomination_type5 = cash_rem_denomination_type5;
this.cash_rem_denomination_type5Changed = true;
this.cash_rem_counters_type5 = cash_rem_counters_type5;
this.cash_rem_counters_type5Changed = true;
this.cash_rem_denomination_type6 = cash_rem_denomination_type6;
this.cash_rem_denomination_type6Changed = true;
this.cash_rem_counters_type6 = cash_rem_counters_type6;
this.cash_rem_counters_type6Changed = true;
this.cash_rem_denomination_type7 = cash_rem_denomination_type7;
this.cash_rem_denomination_type7Changed = true;
this.cash_rem_counters_type7 = cash_rem_counters_type7;
this.cash_rem_counters_type7Changed = true;
}

#region members and properties for columns

#region AtmSettlementHistoryId
private bool atm_settlement_history_idChanged = false;
private int atm_settlement_history_id;
public int AtmSettlementHistoryId
{
get { return atm_settlement_history_id; }
set { 
atm_settlement_history_id = value;
atm_settlement_history_idChanged = true;
}
}
private string atm_settlement_history_idDbString
{
get
{
return atm_settlement_history_id.ToString();
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
#region GlNo
private bool gl_noChanged = false;
private string gl_no;
public string GlNo
{
get { return gl_no; }
set { 
gl_no = value;
gl_noChanged = true;
}
}
private string gl_noDbString
{
get
{
if (this.gl_no!=null)
return string.Format("'{0}'",gl_no); else
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
#region SealNumber
private bool seal_numberChanged = false;
private string seal_number;
public string SealNumber
{
get { return seal_number; }
set { 
seal_number = value;
seal_numberChanged = true;
}
}
private string seal_numberDbString
{
get
{
if (this.seal_number!=null)
return string.Format("'{0}'",seal_number); else
return "null";
}
}
#endregion
#region CashRepDenominationType1
private bool cash_rep_denomination_type1Changed = false;
private int? cash_rep_denomination_type1;
public int? CashRepDenominationType1
{
get { return cash_rep_denomination_type1; }
set { 
cash_rep_denomination_type1 = value;
cash_rep_denomination_type1Changed = true;
}
}
private string cash_rep_denomination_type1DbString
{
get
{
if (this.cash_rep_denomination_type1.HasValue)
return cash_rep_denomination_type1.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType1
private bool cash_rep_counters_type1Changed = false;
private int? cash_rep_counters_type1;
public int? CashRepCountersType1
{
get { return cash_rep_counters_type1; }
set { 
cash_rep_counters_type1 = value;
cash_rep_counters_type1Changed = true;
}
}
private string cash_rep_counters_type1DbString
{
get
{
if (this.cash_rep_counters_type1.HasValue)
return cash_rep_counters_type1.ToString();
else
return "null";
}
}
#endregion
#region CashRepDenominationType2
private bool cash_rep_denomination_type2Changed = false;
private int? cash_rep_denomination_type2;
public int? CashRepDenominationType2
{
get { return cash_rep_denomination_type2; }
set { 
cash_rep_denomination_type2 = value;
cash_rep_denomination_type2Changed = true;
}
}
private string cash_rep_denomination_type2DbString
{
get
{
if (this.cash_rep_denomination_type2.HasValue)
return cash_rep_denomination_type2.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType2
private bool cash_rep_counters_type2Changed = false;
private int? cash_rep_counters_type2;
public int? CashRepCountersType2
{
get { return cash_rep_counters_type2; }
set { 
cash_rep_counters_type2 = value;
cash_rep_counters_type2Changed = true;
}
}
private string cash_rep_counters_type2DbString
{
get
{
if (this.cash_rep_counters_type2.HasValue)
return cash_rep_counters_type2.ToString();
else
return "null";
}
}
#endregion
#region CashRepDenominationType3
private bool cash_rep_denomination_type3Changed = false;
private int? cash_rep_denomination_type3;
public int? CashRepDenominationType3
{
get { return cash_rep_denomination_type3; }
set { 
cash_rep_denomination_type3 = value;
cash_rep_denomination_type3Changed = true;
}
}
private string cash_rep_denomination_type3DbString
{
get
{
if (this.cash_rep_denomination_type3.HasValue)
return cash_rep_denomination_type3.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType3
private bool cash_rep_counters_type3Changed = false;
private int? cash_rep_counters_type3;
public int? CashRepCountersType3
{
get { return cash_rep_counters_type3; }
set { 
cash_rep_counters_type3 = value;
cash_rep_counters_type3Changed = true;
}
}
private string cash_rep_counters_type3DbString
{
get
{
if (this.cash_rep_counters_type3.HasValue)
return cash_rep_counters_type3.ToString();
else
return "null";
}
}
#endregion
#region CashRepDenominationType4
private bool cash_rep_denomination_type4Changed = false;
private int? cash_rep_denomination_type4;
public int? CashRepDenominationType4
{
get { return cash_rep_denomination_type4; }
set { 
cash_rep_denomination_type4 = value;
cash_rep_denomination_type4Changed = true;
}
}
private string cash_rep_denomination_type4DbString
{
get
{
if (this.cash_rep_denomination_type4.HasValue)
return cash_rep_denomination_type4.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType4
private bool cash_rep_counters_type4Changed = false;
private int? cash_rep_counters_type4;
public int? CashRepCountersType4
{
get { return cash_rep_counters_type4; }
set { 
cash_rep_counters_type4 = value;
cash_rep_counters_type4Changed = true;
}
}
private string cash_rep_counters_type4DbString
{
get
{
if (this.cash_rep_counters_type4.HasValue)
return cash_rep_counters_type4.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType1
private bool cash_return_denomination_type1Changed = false;
private int? cash_return_denomination_type1;
public int? CashReturnDenominationType1
{
get { return cash_return_denomination_type1; }
set { 
cash_return_denomination_type1 = value;
cash_return_denomination_type1Changed = true;
}
}
private string cash_return_denomination_type1DbString
{
get
{
if (this.cash_return_denomination_type1.HasValue)
return cash_return_denomination_type1.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType1
private bool cash_return_counters_type1Changed = false;
private int? cash_return_counters_type1;
public int? CashReturnCountersType1
{
get { return cash_return_counters_type1; }
set { 
cash_return_counters_type1 = value;
cash_return_counters_type1Changed = true;
}
}
private string cash_return_counters_type1DbString
{
get
{
if (this.cash_return_counters_type1.HasValue)
return cash_return_counters_type1.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType2
private bool cash_return_denomination_type2Changed = false;
private int? cash_return_denomination_type2;
public int? CashReturnDenominationType2
{
get { return cash_return_denomination_type2; }
set { 
cash_return_denomination_type2 = value;
cash_return_denomination_type2Changed = true;
}
}
private string cash_return_denomination_type2DbString
{
get
{
if (this.cash_return_denomination_type2.HasValue)
return cash_return_denomination_type2.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType2
private bool cash_return_counters_type2Changed = false;
private int? cash_return_counters_type2;
public int? CashReturnCountersType2
{
get { return cash_return_counters_type2; }
set { 
cash_return_counters_type2 = value;
cash_return_counters_type2Changed = true;
}
}
private string cash_return_counters_type2DbString
{
get
{
if (this.cash_return_counters_type2.HasValue)
return cash_return_counters_type2.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType3
private bool cash_return_denomination_type3Changed = false;
private int? cash_return_denomination_type3;
public int? CashReturnDenominationType3
{
get { return cash_return_denomination_type3; }
set { 
cash_return_denomination_type3 = value;
cash_return_denomination_type3Changed = true;
}
}
private string cash_return_denomination_type3DbString
{
get
{
if (this.cash_return_denomination_type3.HasValue)
return cash_return_denomination_type3.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType3
private bool cash_return_counters_type3Changed = false;
private int? cash_return_counters_type3;
public int? CashReturnCountersType3
{
get { return cash_return_counters_type3; }
set { 
cash_return_counters_type3 = value;
cash_return_counters_type3Changed = true;
}
}
private string cash_return_counters_type3DbString
{
get
{
if (this.cash_return_counters_type3.HasValue)
return cash_return_counters_type3.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType4
private bool cash_return_denomination_type4Changed = false;
private int? cash_return_denomination_type4;
public int? CashReturnDenominationType4
{
get { return cash_return_denomination_type4; }
set { 
cash_return_denomination_type4 = value;
cash_return_denomination_type4Changed = true;
}
}
private string cash_return_denomination_type4DbString
{
get
{
if (this.cash_return_denomination_type4.HasValue)
return cash_return_denomination_type4.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType4
private bool cash_return_counters_type4Changed = false;
private int? cash_return_counters_type4;
public int? CashReturnCountersType4
{
get { return cash_return_counters_type4; }
set { 
cash_return_counters_type4 = value;
cash_return_counters_type4Changed = true;
}
}
private string cash_return_counters_type4DbString
{
get
{
if (this.cash_return_counters_type4.HasValue)
return cash_return_counters_type4.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType1
private bool cash_dispensed_denomination_type1Changed = false;
private int? cash_dispensed_denomination_type1;
public int? CashDispensedDenominationType1
{
get { return cash_dispensed_denomination_type1; }
set { 
cash_dispensed_denomination_type1 = value;
cash_dispensed_denomination_type1Changed = true;
}
}
private string cash_dispensed_denomination_type1DbString
{
get
{
if (this.cash_dispensed_denomination_type1.HasValue)
return cash_dispensed_denomination_type1.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType1
private bool cash_dispensed_counters_type1Changed = false;
private int? cash_dispensed_counters_type1;
public int? CashDispensedCountersType1
{
get { return cash_dispensed_counters_type1; }
set { 
cash_dispensed_counters_type1 = value;
cash_dispensed_counters_type1Changed = true;
}
}
private string cash_dispensed_counters_type1DbString
{
get
{
if (this.cash_dispensed_counters_type1.HasValue)
return cash_dispensed_counters_type1.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType2
private bool cash_dispensed_denomination_type2Changed = false;
private int? cash_dispensed_denomination_type2;
public int? CashDispensedDenominationType2
{
get { return cash_dispensed_denomination_type2; }
set { 
cash_dispensed_denomination_type2 = value;
cash_dispensed_denomination_type2Changed = true;
}
}
private string cash_dispensed_denomination_type2DbString
{
get
{
if (this.cash_dispensed_denomination_type2.HasValue)
return cash_dispensed_denomination_type2.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType2
private bool cash_dispensed_counters_type2Changed = false;
private int? cash_dispensed_counters_type2;
public int? CashDispensedCountersType2
{
get { return cash_dispensed_counters_type2; }
set { 
cash_dispensed_counters_type2 = value;
cash_dispensed_counters_type2Changed = true;
}
}
private string cash_dispensed_counters_type2DbString
{
get
{
if (this.cash_dispensed_counters_type2.HasValue)
return cash_dispensed_counters_type2.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType3
private bool cash_dispensed_denomination_type3Changed = false;
private int? cash_dispensed_denomination_type3;
public int? CashDispensedDenominationType3
{
get { return cash_dispensed_denomination_type3; }
set { 
cash_dispensed_denomination_type3 = value;
cash_dispensed_denomination_type3Changed = true;
}
}
private string cash_dispensed_denomination_type3DbString
{
get
{
if (this.cash_dispensed_denomination_type3.HasValue)
return cash_dispensed_denomination_type3.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType3
private bool cash_dispensed_counters_type3Changed = false;
private int? cash_dispensed_counters_type3;
public int? CashDispensedCountersType3
{
get { return cash_dispensed_counters_type3; }
set { 
cash_dispensed_counters_type3 = value;
cash_dispensed_counters_type3Changed = true;
}
}
private string cash_dispensed_counters_type3DbString
{
get
{
if (this.cash_dispensed_counters_type3.HasValue)
return cash_dispensed_counters_type3.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType4
private bool cash_dispensed_denomination_type4Changed = false;
private int? cash_dispensed_denomination_type4;
public int? CashDispensedDenominationType4
{
get { return cash_dispensed_denomination_type4; }
set { 
cash_dispensed_denomination_type4 = value;
cash_dispensed_denomination_type4Changed = true;
}
}
private string cash_dispensed_denomination_type4DbString
{
get
{
if (this.cash_dispensed_denomination_type4.HasValue)
return cash_dispensed_denomination_type4.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType4
private bool cash_dispensed_counters_type4Changed = false;
private int? cash_dispensed_counters_type4;
public int? CashDispensedCountersType4
{
get { return cash_dispensed_counters_type4; }
set { 
cash_dispensed_counters_type4 = value;
cash_dispensed_counters_type4Changed = true;
}
}
private string cash_dispensed_counters_type4DbString
{
get
{
if (this.cash_dispensed_counters_type4.HasValue)
return cash_dispensed_counters_type4.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType1
private bool cash_rejected_denomination_type1Changed = false;
private int? cash_rejected_denomination_type1;
public int? CashRejectedDenominationType1
{
get { return cash_rejected_denomination_type1; }
set { 
cash_rejected_denomination_type1 = value;
cash_rejected_denomination_type1Changed = true;
}
}
private string cash_rejected_denomination_type1DbString
{
get
{
if (this.cash_rejected_denomination_type1.HasValue)
return cash_rejected_denomination_type1.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType1
private bool cash_rejected_counters_type1Changed = false;
private int? cash_rejected_counters_type1;
public int? CashRejectedCountersType1
{
get { return cash_rejected_counters_type1; }
set { 
cash_rejected_counters_type1 = value;
cash_rejected_counters_type1Changed = true;
}
}
private string cash_rejected_counters_type1DbString
{
get
{
if (this.cash_rejected_counters_type1.HasValue)
return cash_rejected_counters_type1.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType2
private bool cash_rejected_denomination_type2Changed = false;
private int? cash_rejected_denomination_type2;
public int? CashRejectedDenominationType2
{
get { return cash_rejected_denomination_type2; }
set { 
cash_rejected_denomination_type2 = value;
cash_rejected_denomination_type2Changed = true;
}
}
private string cash_rejected_denomination_type2DbString
{
get
{
if (this.cash_rejected_denomination_type2.HasValue)
return cash_rejected_denomination_type2.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType2
private bool cash_rejected_counters_type2Changed = false;
private int? cash_rejected_counters_type2;
public int? CashRejectedCountersType2
{
get { return cash_rejected_counters_type2; }
set { 
cash_rejected_counters_type2 = value;
cash_rejected_counters_type2Changed = true;
}
}
private string cash_rejected_counters_type2DbString
{
get
{
if (this.cash_rejected_counters_type2.HasValue)
return cash_rejected_counters_type2.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType3
private bool cash_rejected_denomination_type3Changed = false;
private int? cash_rejected_denomination_type3;
public int? CashRejectedDenominationType3
{
get { return cash_rejected_denomination_type3; }
set { 
cash_rejected_denomination_type3 = value;
cash_rejected_denomination_type3Changed = true;
}
}
private string cash_rejected_denomination_type3DbString
{
get
{
if (this.cash_rejected_denomination_type3.HasValue)
return cash_rejected_denomination_type3.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType3
private bool cash_rejected_counters_type3Changed = false;
private int? cash_rejected_counters_type3;
public int? CashRejectedCountersType3
{
get { return cash_rejected_counters_type3; }
set { 
cash_rejected_counters_type3 = value;
cash_rejected_counters_type3Changed = true;
}
}
private string cash_rejected_counters_type3DbString
{
get
{
if (this.cash_rejected_counters_type3.HasValue)
return cash_rejected_counters_type3.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType4
private bool cash_rejected_denomination_type4Changed = false;
private int? cash_rejected_denomination_type4;
public int? CashRejectedDenominationType4
{
get { return cash_rejected_denomination_type4; }
set { 
cash_rejected_denomination_type4 = value;
cash_rejected_denomination_type4Changed = true;
}
}
private string cash_rejected_denomination_type4DbString
{
get
{
if (this.cash_rejected_denomination_type4.HasValue)
return cash_rejected_denomination_type4.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType4
private bool cash_rejected_counters_type4Changed = false;
private int? cash_rejected_counters_type4;
public int? CashRejectedCountersType4
{
get { return cash_rejected_counters_type4; }
set { 
cash_rejected_counters_type4 = value;
cash_rejected_counters_type4Changed = true;
}
}
private string cash_rejected_counters_type4DbString
{
get
{
if (this.cash_rejected_counters_type4.HasValue)
return cash_rejected_counters_type4.ToString();
else
return "null";
}
}
#endregion
#region UploadedBy
private bool uploaded_byChanged = false;
private int? uploaded_by;
public int? UploadedBy
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
if (this.uploaded_by.HasValue)
return uploaded_by.ToString();
else
return "null";
}
}
#endregion
#region UploadDatetime
private bool upload_datetimeChanged = false;
private DateTime? upload_datetime;
public DateTime? UploadDatetime
{
get { return upload_datetime; }
set { 
upload_datetime = value;
upload_datetimeChanged = true;
}
}
private string upload_datetimeDbString
{
get
{
if (this.upload_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",upload_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region AtmSiteAndNumber
private bool atm_site_and_numberChanged = false;
private string atm_site_and_number;
public string AtmSiteAndNumber
{
get { return atm_site_and_number; }
set { 
atm_site_and_number = value;
atm_site_and_numberChanged = true;
}
}
private string atm_site_and_numberDbString
{
get
{
if (this.atm_site_and_number!=null)
return string.Format("'{0}'",atm_site_and_number); else
return "null";
}
}
#endregion
#region TotalReplenished
private bool total_replenishedChanged = false;
private decimal? total_replenished;
public decimal? TotalReplenished
{
get { return total_replenished; }
set { 
total_replenished = value;
total_replenishedChanged = true;
}
}
private string total_replenishedDbString
{
get
{
if (this.total_replenished.HasValue)
return total_replenished.ToString();
else
return "null";
}
}
#endregion
#region DateOfOldReplenised
private bool date_of_old_replenisedChanged = false;
private DateTime? date_of_old_replenised;
public DateTime? DateOfOldReplenised
{
get { return date_of_old_replenised; }
set { 
date_of_old_replenised = value;
date_of_old_replenisedChanged = true;
}
}
private string date_of_old_replenisedDbString
{
get
{
if (this.date_of_old_replenised.HasValue)
return string.Format("Convert(datetime,'{0}',121)",date_of_old_replenised.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region Location
private bool locationChanged = false;
private string location;
public string Location
{
get { return location; }
set { 
location = value;
locationChanged = true;
}
}
private string locationDbString
{
get
{
if (this.location!=null)
return string.Format("'{0}'",location); else
return "null";
}
}
#endregion
#region AtmNo
private bool atm_noChanged = false;
private int? atm_no;
public int? AtmNo
{
get { return atm_no; }
set { 
atm_no = value;
atm_noChanged = true;
}
}
private string atm_noDbString
{
get
{
if (this.atm_no.HasValue)
return atm_no.ToString();
else
return "null";
}
}
#endregion
#region TotalReturned
private bool total_returnedChanged = false;
private decimal? total_returned;
public decimal? TotalReturned
{
get { return total_returned; }
set { 
total_returned = value;
total_returnedChanged = true;
}
}
private string total_returnedDbString
{
get
{
if (this.total_returned.HasValue)
return total_returned.ToString();
else
return "null";
}
}
#endregion
#region CashRepDenominationType5
private bool cash_rep_denomination_type5Changed = false;
private int? cash_rep_denomination_type5;
public int? CashRepDenominationType5
{
get { return cash_rep_denomination_type5; }
set { 
cash_rep_denomination_type5 = value;
cash_rep_denomination_type5Changed = true;
}
}
private string cash_rep_denomination_type5DbString
{
get
{
if (this.cash_rep_denomination_type5.HasValue)
return cash_rep_denomination_type5.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType5
private bool cash_rep_counters_type5Changed = false;
private int? cash_rep_counters_type5;
public int? CashRepCountersType5
{
get { return cash_rep_counters_type5; }
set { 
cash_rep_counters_type5 = value;
cash_rep_counters_type5Changed = true;
}
}
private string cash_rep_counters_type5DbString
{
get
{
if (this.cash_rep_counters_type5.HasValue)
return cash_rep_counters_type5.ToString();
else
return "null";
}
}
#endregion
#region CashRepDenominationType6
private bool cash_rep_denomination_type6Changed = false;
private int? cash_rep_denomination_type6;
public int? CashRepDenominationType6
{
get { return cash_rep_denomination_type6; }
set { 
cash_rep_denomination_type6 = value;
cash_rep_denomination_type6Changed = true;
}
}
private string cash_rep_denomination_type6DbString
{
get
{
if (this.cash_rep_denomination_type6.HasValue)
return cash_rep_denomination_type6.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType6
private bool cash_rep_counters_type6Changed = false;
private int? cash_rep_counters_type6;
public int? CashRepCountersType6
{
get { return cash_rep_counters_type6; }
set { 
cash_rep_counters_type6 = value;
cash_rep_counters_type6Changed = true;
}
}
private string cash_rep_counters_type6DbString
{
get
{
if (this.cash_rep_counters_type6.HasValue)
return cash_rep_counters_type6.ToString();
else
return "null";
}
}
#endregion
#region CashRepDenominationType7
private bool cash_rep_denomination_type7Changed = false;
private int? cash_rep_denomination_type7;
public int? CashRepDenominationType7
{
get { return cash_rep_denomination_type7; }
set { 
cash_rep_denomination_type7 = value;
cash_rep_denomination_type7Changed = true;
}
}
private string cash_rep_denomination_type7DbString
{
get
{
if (this.cash_rep_denomination_type7.HasValue)
return cash_rep_denomination_type7.ToString();
else
return "null";
}
}
#endregion
#region CashRepCountersType7
private bool cash_rep_counters_type7Changed = false;
private int? cash_rep_counters_type7;
public int? CashRepCountersType7
{
get { return cash_rep_counters_type7; }
set { 
cash_rep_counters_type7 = value;
cash_rep_counters_type7Changed = true;
}
}
private string cash_rep_counters_type7DbString
{
get
{
if (this.cash_rep_counters_type7.HasValue)
return cash_rep_counters_type7.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType5
private bool cash_return_denomination_type5Changed = false;
private int? cash_return_denomination_type5;
public int? CashReturnDenominationType5
{
get { return cash_return_denomination_type5; }
set { 
cash_return_denomination_type5 = value;
cash_return_denomination_type5Changed = true;
}
}
private string cash_return_denomination_type5DbString
{
get
{
if (this.cash_return_denomination_type5.HasValue)
return cash_return_denomination_type5.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType5
private bool cash_return_counters_type5Changed = false;
private int? cash_return_counters_type5;
public int? CashReturnCountersType5
{
get { return cash_return_counters_type5; }
set { 
cash_return_counters_type5 = value;
cash_return_counters_type5Changed = true;
}
}
private string cash_return_counters_type5DbString
{
get
{
if (this.cash_return_counters_type5.HasValue)
return cash_return_counters_type5.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType6
private bool cash_return_denomination_type6Changed = false;
private int? cash_return_denomination_type6;
public int? CashReturnDenominationType6
{
get { return cash_return_denomination_type6; }
set { 
cash_return_denomination_type6 = value;
cash_return_denomination_type6Changed = true;
}
}
private string cash_return_denomination_type6DbString
{
get
{
if (this.cash_return_denomination_type6.HasValue)
return cash_return_denomination_type6.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType6
private bool cash_return_counters_type6Changed = false;
private int? cash_return_counters_type6;
public int? CashReturnCountersType6
{
get { return cash_return_counters_type6; }
set { 
cash_return_counters_type6 = value;
cash_return_counters_type6Changed = true;
}
}
private string cash_return_counters_type6DbString
{
get
{
if (this.cash_return_counters_type6.HasValue)
return cash_return_counters_type6.ToString();
else
return "null";
}
}
#endregion
#region CashReturnDenominationType7
private bool cash_return_denomination_type7Changed = false;
private int? cash_return_denomination_type7;
public int? CashReturnDenominationType7
{
get { return cash_return_denomination_type7; }
set { 
cash_return_denomination_type7 = value;
cash_return_denomination_type7Changed = true;
}
}
private string cash_return_denomination_type7DbString
{
get
{
if (this.cash_return_denomination_type7.HasValue)
return cash_return_denomination_type7.ToString();
else
return "null";
}
}
#endregion
#region CashReturnCountersType7
private bool cash_return_counters_type7Changed = false;
private int? cash_return_counters_type7;
public int? CashReturnCountersType7
{
get { return cash_return_counters_type7; }
set { 
cash_return_counters_type7 = value;
cash_return_counters_type7Changed = true;
}
}
private string cash_return_counters_type7DbString
{
get
{
if (this.cash_return_counters_type7.HasValue)
return cash_return_counters_type7.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType5
private bool cash_dispensed_denomination_type5Changed = false;
private int? cash_dispensed_denomination_type5;
public int? CashDispensedDenominationType5
{
get { return cash_dispensed_denomination_type5; }
set { 
cash_dispensed_denomination_type5 = value;
cash_dispensed_denomination_type5Changed = true;
}
}
private string cash_dispensed_denomination_type5DbString
{
get
{
if (this.cash_dispensed_denomination_type5.HasValue)
return cash_dispensed_denomination_type5.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType5
private bool cash_dispensed_counters_type5Changed = false;
private int? cash_dispensed_counters_type5;
public int? CashDispensedCountersType5
{
get { return cash_dispensed_counters_type5; }
set { 
cash_dispensed_counters_type5 = value;
cash_dispensed_counters_type5Changed = true;
}
}
private string cash_dispensed_counters_type5DbString
{
get
{
if (this.cash_dispensed_counters_type5.HasValue)
return cash_dispensed_counters_type5.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType6
private bool cash_dispensed_denomination_type6Changed = false;
private int? cash_dispensed_denomination_type6;
public int? CashDispensedDenominationType6
{
get { return cash_dispensed_denomination_type6; }
set { 
cash_dispensed_denomination_type6 = value;
cash_dispensed_denomination_type6Changed = true;
}
}
private string cash_dispensed_denomination_type6DbString
{
get
{
if (this.cash_dispensed_denomination_type6.HasValue)
return cash_dispensed_denomination_type6.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType6
private bool cash_dispensed_counters_type6Changed = false;
private int? cash_dispensed_counters_type6;
public int? CashDispensedCountersType6
{
get { return cash_dispensed_counters_type6; }
set { 
cash_dispensed_counters_type6 = value;
cash_dispensed_counters_type6Changed = true;
}
}
private string cash_dispensed_counters_type6DbString
{
get
{
if (this.cash_dispensed_counters_type6.HasValue)
return cash_dispensed_counters_type6.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedDenominationType7
private bool cash_dispensed_denomination_type7Changed = false;
private int? cash_dispensed_denomination_type7;
public int? CashDispensedDenominationType7
{
get { return cash_dispensed_denomination_type7; }
set { 
cash_dispensed_denomination_type7 = value;
cash_dispensed_denomination_type7Changed = true;
}
}
private string cash_dispensed_denomination_type7DbString
{
get
{
if (this.cash_dispensed_denomination_type7.HasValue)
return cash_dispensed_denomination_type7.ToString();
else
return "null";
}
}
#endregion
#region CashDispensedCountersType7
private bool cash_dispensed_counters_type7Changed = false;
private int? cash_dispensed_counters_type7;
public int? CashDispensedCountersType7
{
get { return cash_dispensed_counters_type7; }
set { 
cash_dispensed_counters_type7 = value;
cash_dispensed_counters_type7Changed = true;
}
}
private string cash_dispensed_counters_type7DbString
{
get
{
if (this.cash_dispensed_counters_type7.HasValue)
return cash_dispensed_counters_type7.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType5
private bool cash_rejected_denomination_type5Changed = false;
private int? cash_rejected_denomination_type5;
public int? CashRejectedDenominationType5
{
get { return cash_rejected_denomination_type5; }
set { 
cash_rejected_denomination_type5 = value;
cash_rejected_denomination_type5Changed = true;
}
}
private string cash_rejected_denomination_type5DbString
{
get
{
if (this.cash_rejected_denomination_type5.HasValue)
return cash_rejected_denomination_type5.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType5
private bool cash_rejected_counters_type5Changed = false;
private int? cash_rejected_counters_type5;
public int? CashRejectedCountersType5
{
get { return cash_rejected_counters_type5; }
set { 
cash_rejected_counters_type5 = value;
cash_rejected_counters_type5Changed = true;
}
}
private string cash_rejected_counters_type5DbString
{
get
{
if (this.cash_rejected_counters_type5.HasValue)
return cash_rejected_counters_type5.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType6
private bool cash_rejected_denomination_type6Changed = false;
private int? cash_rejected_denomination_type6;
public int? CashRejectedDenominationType6
{
get { return cash_rejected_denomination_type6; }
set { 
cash_rejected_denomination_type6 = value;
cash_rejected_denomination_type6Changed = true;
}
}
private string cash_rejected_denomination_type6DbString
{
get
{
if (this.cash_rejected_denomination_type6.HasValue)
return cash_rejected_denomination_type6.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType6
private bool cash_rejected_counters_type6Changed = false;
private int? cash_rejected_counters_type6;
public int? CashRejectedCountersType6
{
get { return cash_rejected_counters_type6; }
set { 
cash_rejected_counters_type6 = value;
cash_rejected_counters_type6Changed = true;
}
}
private string cash_rejected_counters_type6DbString
{
get
{
if (this.cash_rejected_counters_type6.HasValue)
return cash_rejected_counters_type6.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedDenominationType7
private bool cash_rejected_denomination_type7Changed = false;
private int? cash_rejected_denomination_type7;
public int? CashRejectedDenominationType7
{
get { return cash_rejected_denomination_type7; }
set { 
cash_rejected_denomination_type7 = value;
cash_rejected_denomination_type7Changed = true;
}
}
private string cash_rejected_denomination_type7DbString
{
get
{
if (this.cash_rejected_denomination_type7.HasValue)
return cash_rejected_denomination_type7.ToString();
else
return "null";
}
}
#endregion
#region CashRejectedCountersType7
private bool cash_rejected_counters_type7Changed = false;
private int? cash_rejected_counters_type7;
public int? CashRejectedCountersType7
{
get { return cash_rejected_counters_type7; }
set { 
cash_rejected_counters_type7 = value;
cash_rejected_counters_type7Changed = true;
}
}
private string cash_rejected_counters_type7DbString
{
get
{
if (this.cash_rejected_counters_type7.HasValue)
return cash_rejected_counters_type7.ToString();
else
return "null";
}
}
#endregion
#region CashRemDenominationType5
private bool cash_rem_denomination_type5Changed = false;
private int? cash_rem_denomination_type5;
public int? CashRemDenominationType5
{
get { return cash_rem_denomination_type5; }
set { 
cash_rem_denomination_type5 = value;
cash_rem_denomination_type5Changed = true;
}
}
private string cash_rem_denomination_type5DbString
{
get
{
if (this.cash_rem_denomination_type5.HasValue)
return cash_rem_denomination_type5.ToString();
else
return "null";
}
}
#endregion
#region CashRemCountersType5
private bool cash_rem_counters_type5Changed = false;
private int? cash_rem_counters_type5;
public int? CashRemCountersType5
{
get { return cash_rem_counters_type5; }
set { 
cash_rem_counters_type5 = value;
cash_rem_counters_type5Changed = true;
}
}
private string cash_rem_counters_type5DbString
{
get
{
if (this.cash_rem_counters_type5.HasValue)
return cash_rem_counters_type5.ToString();
else
return "null";
}
}
#endregion
#region CashRemDenominationType6
private bool cash_rem_denomination_type6Changed = false;
private int? cash_rem_denomination_type6;
public int? CashRemDenominationType6
{
get { return cash_rem_denomination_type6; }
set { 
cash_rem_denomination_type6 = value;
cash_rem_denomination_type6Changed = true;
}
}
private string cash_rem_denomination_type6DbString
{
get
{
if (this.cash_rem_denomination_type6.HasValue)
return cash_rem_denomination_type6.ToString();
else
return "null";
}
}
#endregion
#region CashRemCountersType6
private bool cash_rem_counters_type6Changed = false;
private int? cash_rem_counters_type6;
public int? CashRemCountersType6
{
get { return cash_rem_counters_type6; }
set { 
cash_rem_counters_type6 = value;
cash_rem_counters_type6Changed = true;
}
}
private string cash_rem_counters_type6DbString
{
get
{
if (this.cash_rem_counters_type6.HasValue)
return cash_rem_counters_type6.ToString();
else
return "null";
}
}
#endregion
#region CashRemDenominationType7
private bool cash_rem_denomination_type7Changed = false;
private int? cash_rem_denomination_type7;
public int? CashRemDenominationType7
{
get { return cash_rem_denomination_type7; }
set { 
cash_rem_denomination_type7 = value;
cash_rem_denomination_type7Changed = true;
}
}
private string cash_rem_denomination_type7DbString
{
get
{
if (this.cash_rem_denomination_type7.HasValue)
return cash_rem_denomination_type7.ToString();
else
return "null";
}
}
#endregion
#region CashRemCountersType7
private bool cash_rem_counters_type7Changed = false;
private int? cash_rem_counters_type7;
public int? CashRemCountersType7
{
get { return cash_rem_counters_type7; }
set { 
cash_rem_counters_type7 = value;
cash_rem_counters_type7Changed = true;
}
}
private string cash_rem_counters_type7DbString
{
get
{
if (this.cash_rem_counters_type7.HasValue)
return cash_rem_counters_type7.ToString();
else
return "null";
}
}
#endregion
#endregion

#region AtmSettlementHistoryReader
public class AtmSettlementHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmSettlementHistory currentAtmSettlementHistory;
bool partialRead = false;
private AtmSettlementHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmSettlementHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
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
get { return currentAtmSettlementHistory; }

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
currentAtmSettlementHistory = new AtmSettlementHistory();
{
if (reader["atm_settlement_history_id"] != DBNull.Value)
currentAtmSettlementHistory.atm_settlement_history_id = (int) reader["atm_settlement_history_id"]; 
if (reader["atm_settlement_id"] != DBNull.Value)
currentAtmSettlementHistory.atm_settlement_id = (int) reader["atm_settlement_id"]; 
if (reader["gl_no"] != DBNull.Value)
currentAtmSettlementHistory.gl_no = (string) reader["gl_no"]; 
if (reader["rep_datetime"] != DBNull.Value)
currentAtmSettlementHistory.rep_datetime = (DateTime?) reader["rep_datetime"]; 
if (reader["seal_number"] != DBNull.Value)
currentAtmSettlementHistory.seal_number = (string) reader["seal_number"]; 
if (reader["cash_rep_denomination_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type1 = (int?) reader["cash_rep_denomination_type1"]; 
if (reader["cash_rep_counters_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type1 = (int?) reader["cash_rep_counters_type1"]; 
if (reader["cash_rep_denomination_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type2 = (int?) reader["cash_rep_denomination_type2"]; 
if (reader["cash_rep_counters_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type2 = (int?) reader["cash_rep_counters_type2"]; 
if (reader["cash_rep_denomination_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type3 = (int?) reader["cash_rep_denomination_type3"]; 
if (reader["cash_rep_counters_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type3 = (int?) reader["cash_rep_counters_type3"]; 
if (reader["cash_rep_denomination_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type4 = (int?) reader["cash_rep_denomination_type4"]; 
if (reader["cash_rep_counters_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type4 = (int?) reader["cash_rep_counters_type4"]; 
if (reader["cash_return_denomination_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type1 = (int?) reader["cash_return_denomination_type1"]; 
if (reader["cash_return_counters_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type1 = (int?) reader["cash_return_counters_type1"]; 
if (reader["cash_return_denomination_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type2 = (int?) reader["cash_return_denomination_type2"]; 
if (reader["cash_return_counters_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type2 = (int?) reader["cash_return_counters_type2"]; 
if (reader["cash_return_denomination_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type3 = (int?) reader["cash_return_denomination_type3"]; 
if (reader["cash_return_counters_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type3 = (int?) reader["cash_return_counters_type3"]; 
if (reader["cash_return_denomination_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type4 = (int?) reader["cash_return_denomination_type4"]; 
if (reader["cash_return_counters_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type4 = (int?) reader["cash_return_counters_type4"]; 
if (reader["cash_dispensed_denomination_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type1 = (int?) reader["cash_dispensed_denomination_type1"]; 
if (reader["cash_dispensed_counters_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type1 = (int?) reader["cash_dispensed_counters_type1"]; 
if (reader["cash_dispensed_denomination_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type2 = (int?) reader["cash_dispensed_denomination_type2"]; 
if (reader["cash_dispensed_counters_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type2 = (int?) reader["cash_dispensed_counters_type2"]; 
if (reader["cash_dispensed_denomination_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type3 = (int?) reader["cash_dispensed_denomination_type3"]; 
if (reader["cash_dispensed_counters_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type3 = (int?) reader["cash_dispensed_counters_type3"]; 
if (reader["cash_dispensed_denomination_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type4 = (int?) reader["cash_dispensed_denomination_type4"]; 
if (reader["cash_dispensed_counters_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type4 = (int?) reader["cash_dispensed_counters_type4"]; 
if (reader["cash_rejected_denomination_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type1 = (int?) reader["cash_rejected_denomination_type1"]; 
if (reader["cash_rejected_counters_type1"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type1 = (int?) reader["cash_rejected_counters_type1"]; 
if (reader["cash_rejected_denomination_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type2 = (int?) reader["cash_rejected_denomination_type2"]; 
if (reader["cash_rejected_counters_type2"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type2 = (int?) reader["cash_rejected_counters_type2"]; 
if (reader["cash_rejected_denomination_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type3 = (int?) reader["cash_rejected_denomination_type3"]; 
if (reader["cash_rejected_counters_type3"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type3 = (int?) reader["cash_rejected_counters_type3"]; 
if (reader["cash_rejected_denomination_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type4 = (int?) reader["cash_rejected_denomination_type4"]; 
if (reader["cash_rejected_counters_type4"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type4 = (int?) reader["cash_rejected_counters_type4"]; 
if (reader["uploaded_by"] != DBNull.Value)
currentAtmSettlementHistory.uploaded_by = (int?) reader["uploaded_by"]; 
if (reader["upload_datetime"] != DBNull.Value)
currentAtmSettlementHistory.upload_datetime = (DateTime?) reader["upload_datetime"]; 
if (reader["atm_site_and_number"] != DBNull.Value)
currentAtmSettlementHistory.atm_site_and_number = (string) reader["atm_site_and_number"]; 
if (reader["total_replenished"] != DBNull.Value)
currentAtmSettlementHistory.total_replenished = (decimal?) reader["total_replenished"]; 
if (reader["date_of_old_replenised"] != DBNull.Value)
currentAtmSettlementHistory.date_of_old_replenised = (DateTime?) reader["date_of_old_replenised"]; 
if (reader["location"] != DBNull.Value)
currentAtmSettlementHistory.location = (string) reader["location"]; 
if (reader["atm_no"] != DBNull.Value)
currentAtmSettlementHistory.atm_no = (int?) reader["atm_no"]; 
if (reader["total_returned"] != DBNull.Value)
currentAtmSettlementHistory.total_returned = (decimal?) reader["total_returned"]; 
if (reader["cash_rep_denomination_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type5 = (int?) reader["cash_rep_denomination_type5"]; 
if (reader["cash_rep_counters_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type5 = (int?) reader["cash_rep_counters_type5"]; 
if (reader["cash_rep_denomination_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type6 = (int?) reader["cash_rep_denomination_type6"]; 
if (reader["cash_rep_counters_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type6 = (int?) reader["cash_rep_counters_type6"]; 
if (reader["cash_rep_denomination_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_denomination_type7 = (int?) reader["cash_rep_denomination_type7"]; 
if (reader["cash_rep_counters_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_rep_counters_type7 = (int?) reader["cash_rep_counters_type7"]; 
if (reader["cash_return_denomination_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type5 = (int?) reader["cash_return_denomination_type5"]; 
if (reader["cash_return_counters_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type5 = (int?) reader["cash_return_counters_type5"]; 
if (reader["cash_return_denomination_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type6 = (int?) reader["cash_return_denomination_type6"]; 
if (reader["cash_return_counters_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type6 = (int?) reader["cash_return_counters_type6"]; 
if (reader["cash_return_denomination_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_denomination_type7 = (int?) reader["cash_return_denomination_type7"]; 
if (reader["cash_return_counters_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_return_counters_type7 = (int?) reader["cash_return_counters_type7"]; 
if (reader["cash_dispensed_denomination_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type5 = (int?) reader["cash_dispensed_denomination_type5"]; 
if (reader["cash_dispensed_counters_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type5 = (int?) reader["cash_dispensed_counters_type5"]; 
if (reader["cash_dispensed_denomination_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type6 = (int?) reader["cash_dispensed_denomination_type6"]; 
if (reader["cash_dispensed_counters_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type6 = (int?) reader["cash_dispensed_counters_type6"]; 
if (reader["cash_dispensed_denomination_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_denomination_type7 = (int?) reader["cash_dispensed_denomination_type7"]; 
if (reader["cash_dispensed_counters_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_dispensed_counters_type7 = (int?) reader["cash_dispensed_counters_type7"]; 
if (reader["cash_rejected_denomination_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type5 = (int?) reader["cash_rejected_denomination_type5"]; 
if (reader["cash_rejected_counters_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type5 = (int?) reader["cash_rejected_counters_type5"]; 
if (reader["cash_rejected_denomination_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type6 = (int?) reader["cash_rejected_denomination_type6"]; 
if (reader["cash_rejected_counters_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type6 = (int?) reader["cash_rejected_counters_type6"]; 
if (reader["cash_rejected_denomination_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_denomination_type7 = (int?) reader["cash_rejected_denomination_type7"]; 
if (reader["cash_rejected_counters_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_rejected_counters_type7 = (int?) reader["cash_rejected_counters_type7"]; 
if (reader["cash_rem_denomination_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_rem_denomination_type5 = (int?) reader["cash_rem_denomination_type5"]; 
if (reader["cash_rem_counters_type5"] != DBNull.Value)
currentAtmSettlementHistory.cash_rem_counters_type5 = (int?) reader["cash_rem_counters_type5"]; 
if (reader["cash_rem_denomination_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_rem_denomination_type6 = (int?) reader["cash_rem_denomination_type6"]; 
if (reader["cash_rem_counters_type6"] != DBNull.Value)
currentAtmSettlementHistory.cash_rem_counters_type6 = (int?) reader["cash_rem_counters_type6"]; 
if (reader["cash_rem_denomination_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_rem_denomination_type7 = (int?) reader["cash_rem_denomination_type7"]; 
if (reader["cash_rem_counters_type7"] != DBNull.Value)
currentAtmSettlementHistory.cash_rem_counters_type7 = (int?) reader["cash_rem_counters_type7"]; 
} 

currentAtmSettlementHistory.isNewEntity = false;
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

public AtmSettlementHistory CurrentAtmSettlementHistory
{
get{ return currentAtmSettlementHistory; }
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


#region AtmSettlementHistory functions

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmSettlementHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_settlement_history_id,atm_settlement_id,gl_no,rep_datetime,seal_number,cash_rep_denomination_type1,cash_rep_counters_type1,cash_rep_denomination_type2,cash_rep_counters_type2,cash_rep_denomination_type3,cash_rep_counters_type3,cash_rep_denomination_type4,cash_rep_counters_type4,cash_return_denomination_type1,cash_return_counters_type1,cash_return_denomination_type2,cash_return_counters_type2,cash_return_denomination_type3,cash_return_counters_type3,cash_return_denomination_type4,cash_return_counters_type4,cash_dispensed_denomination_type1,cash_dispensed_counters_type1,cash_dispensed_denomination_type2,cash_dispensed_counters_type2,cash_dispensed_denomination_type3,cash_dispensed_counters_type3,cash_dispensed_denomination_type4,cash_dispensed_counters_type4,cash_rejected_denomination_type1,cash_rejected_counters_type1,cash_rejected_denomination_type2,cash_rejected_counters_type2,cash_rejected_denomination_type3,cash_rejected_counters_type3,cash_rejected_denomination_type4,cash_rejected_counters_type4,uploaded_by,upload_datetime,atm_site_and_number,total_replenished,date_of_old_replenised,location,atm_no,total_returned,cash_rep_denomination_type5,cash_rep_counters_type5,cash_rep_denomination_type6,cash_rep_counters_type6,cash_rep_denomination_type7,cash_rep_counters_type7,cash_return_denomination_type5,cash_return_counters_type5,cash_return_denomination_type6,cash_return_counters_type6,cash_return_denomination_type7,cash_return_counters_type7,cash_dispensed_denomination_type5,cash_dispensed_counters_type5,cash_dispensed_denomination_type6,cash_dispensed_counters_type6,cash_dispensed_denomination_type7,cash_dispensed_counters_type7,cash_rejected_denomination_type5,cash_rejected_counters_type5,cash_rejected_denomination_type6,cash_rejected_counters_type6,cash_rejected_denomination_type7,cash_rejected_counters_type7,cash_rem_denomination_type5,cash_rem_counters_type5,cash_rem_denomination_type6,cash_rem_counters_type6,cash_rem_denomination_type7,cash_rem_counters_type7 from Atm_settlement_history ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmSettlementHistoryReader(cmd.ExecuteReader(), conn);
}

static public AtmSettlementHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmSettlementHistory LoadAtmSettlementHistory(string where)
{
AtmSettlementHistoryReader reader = AtmSettlementHistory.ExecuteReader(where);
AtmSettlementHistory _atmsettlementhistory = null;
if (reader.Read())
_atmsettlementhistory = reader.CurrentAtmSettlementHistory;
reader.Close();
return _atmsettlementhistory;
}

public static AtmSettlementHistory LoadAtmSettlementHistory(string where, IDbConnection conn)
{
AtmSettlementHistoryReader reader = AtmSettlementHistory.ExecuteReader(where, conn);
AtmSettlementHistory _atmsettlementhistory = null;
if (reader.Read())
_atmsettlementhistory = reader.CurrentAtmSettlementHistory;
reader.Close(false);
return _atmsettlementhistory;
}

public static AtmSettlementHistory LoadAtmSettlementHistoryByPk( int atm_settlement_history_id )
{
return LoadAtmSettlementHistory( " atm_settlement_history_id="+atm_settlement_history_id );
}

public static AtmSettlementHistory LoadAtmSettlementHistoryByPk( int atm_settlement_history_id , IDbConnection conn)
{
return LoadAtmSettlementHistory(" atm_settlement_history_id="+atm_settlement_history_id , conn);
}

public void Save()
{
if (atm_settlement_history_idChanged || atm_settlement_idChanged || gl_noChanged || rep_datetimeChanged || seal_numberChanged || cash_rep_denomination_type1Changed || cash_rep_counters_type1Changed || cash_rep_denomination_type2Changed || cash_rep_counters_type2Changed || cash_rep_denomination_type3Changed || cash_rep_counters_type3Changed || cash_rep_denomination_type4Changed || cash_rep_counters_type4Changed || cash_return_denomination_type1Changed || cash_return_counters_type1Changed || cash_return_denomination_type2Changed || cash_return_counters_type2Changed || cash_return_denomination_type3Changed || cash_return_counters_type3Changed || cash_return_denomination_type4Changed || cash_return_counters_type4Changed || cash_dispensed_denomination_type1Changed || cash_dispensed_counters_type1Changed || cash_dispensed_denomination_type2Changed || cash_dispensed_counters_type2Changed || cash_dispensed_denomination_type3Changed || cash_dispensed_counters_type3Changed || cash_dispensed_denomination_type4Changed || cash_dispensed_counters_type4Changed || cash_rejected_denomination_type1Changed || cash_rejected_counters_type1Changed || cash_rejected_denomination_type2Changed || cash_rejected_counters_type2Changed || cash_rejected_denomination_type3Changed || cash_rejected_counters_type3Changed || cash_rejected_denomination_type4Changed || cash_rejected_counters_type4Changed || uploaded_byChanged || upload_datetimeChanged || atm_site_and_numberChanged || total_replenishedChanged || date_of_old_replenisedChanged || locationChanged || atm_noChanged || total_returnedChanged || cash_rep_denomination_type5Changed || cash_rep_counters_type5Changed || cash_rep_denomination_type6Changed || cash_rep_counters_type6Changed || cash_rep_denomination_type7Changed || cash_rep_counters_type7Changed || cash_return_denomination_type5Changed || cash_return_counters_type5Changed || cash_return_denomination_type6Changed || cash_return_counters_type6Changed || cash_return_denomination_type7Changed || cash_return_counters_type7Changed || cash_dispensed_denomination_type5Changed || cash_dispensed_counters_type5Changed || cash_dispensed_denomination_type6Changed || cash_dispensed_counters_type6Changed || cash_dispensed_denomination_type7Changed || cash_dispensed_counters_type7Changed || cash_rejected_denomination_type5Changed || cash_rejected_counters_type5Changed || cash_rejected_denomination_type6Changed || cash_rejected_counters_type6Changed || cash_rejected_denomination_type7Changed || cash_rejected_counters_type7Changed || cash_rem_denomination_type5Changed || cash_rem_counters_type5Changed || cash_rem_denomination_type6Changed || cash_rem_counters_type6Changed || cash_rem_denomination_type7Changed || cash_rem_counters_type7Changed )
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
if (atm_settlement_history_idChanged || atm_settlement_idChanged || gl_noChanged || rep_datetimeChanged || seal_numberChanged || cash_rep_denomination_type1Changed || cash_rep_counters_type1Changed || cash_rep_denomination_type2Changed || cash_rep_counters_type2Changed || cash_rep_denomination_type3Changed || cash_rep_counters_type3Changed || cash_rep_denomination_type4Changed || cash_rep_counters_type4Changed || cash_return_denomination_type1Changed || cash_return_counters_type1Changed || cash_return_denomination_type2Changed || cash_return_counters_type2Changed || cash_return_denomination_type3Changed || cash_return_counters_type3Changed || cash_return_denomination_type4Changed || cash_return_counters_type4Changed || cash_dispensed_denomination_type1Changed || cash_dispensed_counters_type1Changed || cash_dispensed_denomination_type2Changed || cash_dispensed_counters_type2Changed || cash_dispensed_denomination_type3Changed || cash_dispensed_counters_type3Changed || cash_dispensed_denomination_type4Changed || cash_dispensed_counters_type4Changed || cash_rejected_denomination_type1Changed || cash_rejected_counters_type1Changed || cash_rejected_denomination_type2Changed || cash_rejected_counters_type2Changed || cash_rejected_denomination_type3Changed || cash_rejected_counters_type3Changed || cash_rejected_denomination_type4Changed || cash_rejected_counters_type4Changed || uploaded_byChanged || upload_datetimeChanged || atm_site_and_numberChanged || total_replenishedChanged || date_of_old_replenisedChanged || locationChanged || atm_noChanged || total_returnedChanged || cash_rep_denomination_type5Changed || cash_rep_counters_type5Changed || cash_rep_denomination_type6Changed || cash_rep_counters_type6Changed || cash_rep_denomination_type7Changed || cash_rep_counters_type7Changed || cash_return_denomination_type5Changed || cash_return_counters_type5Changed || cash_return_denomination_type6Changed || cash_return_counters_type6Changed || cash_return_denomination_type7Changed || cash_return_counters_type7Changed || cash_dispensed_denomination_type5Changed || cash_dispensed_counters_type5Changed || cash_dispensed_denomination_type6Changed || cash_dispensed_counters_type6Changed || cash_dispensed_denomination_type7Changed || cash_dispensed_counters_type7Changed || cash_rejected_denomination_type5Changed || cash_rejected_counters_type5Changed || cash_rejected_denomination_type6Changed || cash_rejected_counters_type6Changed || cash_rejected_denomination_type7Changed || cash_rejected_counters_type7Changed || cash_rem_denomination_type5Changed || cash_rem_counters_type5Changed || cash_rem_denomination_type6Changed || cash_rem_counters_type6Changed || cash_rem_denomination_type7Changed || cash_rem_counters_type7Changed )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_settlement_history( atm_settlement_history_id,atm_settlement_id,gl_no,rep_datetime,seal_number,cash_rep_denomination_type1,cash_rep_counters_type1,cash_rep_denomination_type2,cash_rep_counters_type2,cash_rep_denomination_type3,cash_rep_counters_type3,cash_rep_denomination_type4,cash_rep_counters_type4,cash_return_denomination_type1,cash_return_counters_type1,cash_return_denomination_type2,cash_return_counters_type2,cash_return_denomination_type3,cash_return_counters_type3,cash_return_denomination_type4,cash_return_counters_type4,cash_dispensed_denomination_type1,cash_dispensed_counters_type1,cash_dispensed_denomination_type2,cash_dispensed_counters_type2,cash_dispensed_denomination_type3,cash_dispensed_counters_type3,cash_dispensed_denomination_type4,cash_dispensed_counters_type4,cash_rejected_denomination_type1,cash_rejected_counters_type1,cash_rejected_denomination_type2,cash_rejected_counters_type2,cash_rejected_denomination_type3,cash_rejected_counters_type3,cash_rejected_denomination_type4,cash_rejected_counters_type4,uploaded_by,upload_datetime,atm_site_and_number,total_replenished,date_of_old_replenised,location,atm_no,total_returned,cash_rep_denomination_type5,cash_rep_counters_type5,cash_rep_denomination_type6,cash_rep_counters_type6,cash_rep_denomination_type7,cash_rep_counters_type7,cash_return_denomination_type5,cash_return_counters_type5,cash_return_denomination_type6,cash_return_counters_type6,cash_return_denomination_type7,cash_return_counters_type7,cash_dispensed_denomination_type5,cash_dispensed_counters_type5,cash_dispensed_denomination_type6,cash_dispensed_counters_type6,cash_dispensed_denomination_type7,cash_dispensed_counters_type7,cash_rejected_denomination_type5,cash_rejected_counters_type5,cash_rejected_denomination_type6,cash_rejected_counters_type6,cash_rejected_denomination_type7,cash_rejected_counters_type7,cash_rem_denomination_type5,cash_rem_counters_type5,cash_rem_denomination_type6,cash_rem_counters_type6,cash_rem_denomination_type7,cash_rem_counters_type7 ) values(");
lock (ConnectionFactory.connectionString) { this.atm_settlement_history_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_settlement_history_id);
} qry.Append(",");
qry.Append(atm_settlement_idDbString+",");
qry.Append(gl_noDbString+",");
qry.Append(rep_datetimeDbString+",");
qry.Append(seal_numberDbString+",");
qry.Append(cash_rep_denomination_type1DbString+",");
qry.Append(cash_rep_counters_type1DbString+",");
qry.Append(cash_rep_denomination_type2DbString+",");
qry.Append(cash_rep_counters_type2DbString+",");
qry.Append(cash_rep_denomination_type3DbString+",");
qry.Append(cash_rep_counters_type3DbString+",");
qry.Append(cash_rep_denomination_type4DbString+",");
qry.Append(cash_rep_counters_type4DbString+",");
qry.Append(cash_return_denomination_type1DbString+",");
qry.Append(cash_return_counters_type1DbString+",");
qry.Append(cash_return_denomination_type2DbString+",");
qry.Append(cash_return_counters_type2DbString+",");
qry.Append(cash_return_denomination_type3DbString+",");
qry.Append(cash_return_counters_type3DbString+",");
qry.Append(cash_return_denomination_type4DbString+",");
qry.Append(cash_return_counters_type4DbString+",");
qry.Append(cash_dispensed_denomination_type1DbString+",");
qry.Append(cash_dispensed_counters_type1DbString+",");
qry.Append(cash_dispensed_denomination_type2DbString+",");
qry.Append(cash_dispensed_counters_type2DbString+",");
qry.Append(cash_dispensed_denomination_type3DbString+",");
qry.Append(cash_dispensed_counters_type3DbString+",");
qry.Append(cash_dispensed_denomination_type4DbString+",");
qry.Append(cash_dispensed_counters_type4DbString+",");
qry.Append(cash_rejected_denomination_type1DbString+",");
qry.Append(cash_rejected_counters_type1DbString+",");
qry.Append(cash_rejected_denomination_type2DbString+",");
qry.Append(cash_rejected_counters_type2DbString+",");
qry.Append(cash_rejected_denomination_type3DbString+",");
qry.Append(cash_rejected_counters_type3DbString+",");
qry.Append(cash_rejected_denomination_type4DbString+",");
qry.Append(cash_rejected_counters_type4DbString+",");
qry.Append(uploaded_byDbString+",");
qry.Append(upload_datetimeDbString+",");
qry.Append(atm_site_and_numberDbString+",");
qry.Append(total_replenishedDbString+",");
qry.Append(date_of_old_replenisedDbString+",");
qry.Append(locationDbString+",");
qry.Append(atm_noDbString+",");
qry.Append(total_returnedDbString+",");
qry.Append(cash_rep_denomination_type5DbString+",");
qry.Append(cash_rep_counters_type5DbString+",");
qry.Append(cash_rep_denomination_type6DbString+",");
qry.Append(cash_rep_counters_type6DbString+",");
qry.Append(cash_rep_denomination_type7DbString+",");
qry.Append(cash_rep_counters_type7DbString+",");
qry.Append(cash_return_denomination_type5DbString+",");
qry.Append(cash_return_counters_type5DbString+",");
qry.Append(cash_return_denomination_type6DbString+",");
qry.Append(cash_return_counters_type6DbString+",");
qry.Append(cash_return_denomination_type7DbString+",");
qry.Append(cash_return_counters_type7DbString+",");
qry.Append(cash_dispensed_denomination_type5DbString+",");
qry.Append(cash_dispensed_counters_type5DbString+",");
qry.Append(cash_dispensed_denomination_type6DbString+",");
qry.Append(cash_dispensed_counters_type6DbString+",");
qry.Append(cash_dispensed_denomination_type7DbString+",");
qry.Append(cash_dispensed_counters_type7DbString+",");
qry.Append(cash_rejected_denomination_type5DbString+",");
qry.Append(cash_rejected_counters_type5DbString+",");
qry.Append(cash_rejected_denomination_type6DbString+",");
qry.Append(cash_rejected_counters_type6DbString+",");
qry.Append(cash_rejected_denomination_type7DbString+",");
qry.Append(cash_rejected_counters_type7DbString+",");
qry.Append(cash_rem_denomination_type5DbString+",");
qry.Append(cash_rem_counters_type5DbString+",");
qry.Append(cash_rem_denomination_type6DbString+",");
qry.Append(cash_rem_counters_type6DbString+",");
qry.Append(cash_rem_denomination_type7DbString+",");
qry.Append(cash_rem_counters_type7DbString);
qry.Append(");");

}
else
{
if (!(atm_settlement_history_idChanged || atm_settlement_idChanged || gl_noChanged || rep_datetimeChanged || seal_numberChanged || cash_rep_denomination_type1Changed || cash_rep_counters_type1Changed || cash_rep_denomination_type2Changed || cash_rep_counters_type2Changed || cash_rep_denomination_type3Changed || cash_rep_counters_type3Changed || cash_rep_denomination_type4Changed || cash_rep_counters_type4Changed || cash_return_denomination_type1Changed || cash_return_counters_type1Changed || cash_return_denomination_type2Changed || cash_return_counters_type2Changed || cash_return_denomination_type3Changed || cash_return_counters_type3Changed || cash_return_denomination_type4Changed || cash_return_counters_type4Changed || cash_dispensed_denomination_type1Changed || cash_dispensed_counters_type1Changed || cash_dispensed_denomination_type2Changed || cash_dispensed_counters_type2Changed || cash_dispensed_denomination_type3Changed || cash_dispensed_counters_type3Changed || cash_dispensed_denomination_type4Changed || cash_dispensed_counters_type4Changed || cash_rejected_denomination_type1Changed || cash_rejected_counters_type1Changed || cash_rejected_denomination_type2Changed || cash_rejected_counters_type2Changed || cash_rejected_denomination_type3Changed || cash_rejected_counters_type3Changed || cash_rejected_denomination_type4Changed || cash_rejected_counters_type4Changed || uploaded_byChanged || upload_datetimeChanged || atm_site_and_numberChanged || total_replenishedChanged || date_of_old_replenisedChanged || locationChanged || atm_noChanged || total_returnedChanged || cash_rep_denomination_type5Changed || cash_rep_counters_type5Changed || cash_rep_denomination_type6Changed || cash_rep_counters_type6Changed || cash_rep_denomination_type7Changed || cash_rep_counters_type7Changed || cash_return_denomination_type5Changed || cash_return_counters_type5Changed || cash_return_denomination_type6Changed || cash_return_counters_type6Changed || cash_return_denomination_type7Changed || cash_return_counters_type7Changed || cash_dispensed_denomination_type5Changed || cash_dispensed_counters_type5Changed || cash_dispensed_denomination_type6Changed || cash_dispensed_counters_type6Changed || cash_dispensed_denomination_type7Changed || cash_dispensed_counters_type7Changed || cash_rejected_denomination_type5Changed || cash_rejected_counters_type5Changed || cash_rejected_denomination_type6Changed || cash_rejected_counters_type6Changed || cash_rejected_denomination_type7Changed || cash_rejected_counters_type7Changed || cash_rem_denomination_type5Changed || cash_rem_counters_type5Changed || cash_rem_denomination_type6Changed || cash_rem_counters_type6Changed || cash_rem_denomination_type7Changed || cash_rem_counters_type7Changed ))
return;
qry.Append("UPDATE Atm_settlement_history set "); if ( atm_settlement_idChanged )
{
qry.Append("atm_settlement_id ="+atm_settlement_idDbString);
qry.Append(",");
}

if ( gl_noChanged )
{
qry.Append("gl_no ="+gl_noDbString);
qry.Append(",");
}

if ( rep_datetimeChanged )
{
qry.Append("rep_datetime ="+rep_datetimeDbString);
qry.Append(",");
}

if ( seal_numberChanged )
{
qry.Append("seal_number ="+seal_numberDbString);
qry.Append(",");
}

if ( cash_rep_denomination_type1Changed )
{
qry.Append("cash_rep_denomination_type1 ="+cash_rep_denomination_type1DbString);
qry.Append(",");
}

if ( cash_rep_counters_type1Changed )
{
qry.Append("cash_rep_counters_type1 ="+cash_rep_counters_type1DbString);
qry.Append(",");
}

if ( cash_rep_denomination_type2Changed )
{
qry.Append("cash_rep_denomination_type2 ="+cash_rep_denomination_type2DbString);
qry.Append(",");
}

if ( cash_rep_counters_type2Changed )
{
qry.Append("cash_rep_counters_type2 ="+cash_rep_counters_type2DbString);
qry.Append(",");
}

if ( cash_rep_denomination_type3Changed )
{
qry.Append("cash_rep_denomination_type3 ="+cash_rep_denomination_type3DbString);
qry.Append(",");
}

if ( cash_rep_counters_type3Changed )
{
qry.Append("cash_rep_counters_type3 ="+cash_rep_counters_type3DbString);
qry.Append(",");
}

if ( cash_rep_denomination_type4Changed )
{
qry.Append("cash_rep_denomination_type4 ="+cash_rep_denomination_type4DbString);
qry.Append(",");
}

if ( cash_rep_counters_type4Changed )
{
qry.Append("cash_rep_counters_type4 ="+cash_rep_counters_type4DbString);
qry.Append(",");
}

if ( cash_return_denomination_type1Changed )
{
qry.Append("cash_return_denomination_type1 ="+cash_return_denomination_type1DbString);
qry.Append(",");
}

if ( cash_return_counters_type1Changed )
{
qry.Append("cash_return_counters_type1 ="+cash_return_counters_type1DbString);
qry.Append(",");
}

if ( cash_return_denomination_type2Changed )
{
qry.Append("cash_return_denomination_type2 ="+cash_return_denomination_type2DbString);
qry.Append(",");
}

if ( cash_return_counters_type2Changed )
{
qry.Append("cash_return_counters_type2 ="+cash_return_counters_type2DbString);
qry.Append(",");
}

if ( cash_return_denomination_type3Changed )
{
qry.Append("cash_return_denomination_type3 ="+cash_return_denomination_type3DbString);
qry.Append(",");
}

if ( cash_return_counters_type3Changed )
{
qry.Append("cash_return_counters_type3 ="+cash_return_counters_type3DbString);
qry.Append(",");
}

if ( cash_return_denomination_type4Changed )
{
qry.Append("cash_return_denomination_type4 ="+cash_return_denomination_type4DbString);
qry.Append(",");
}

if ( cash_return_counters_type4Changed )
{
qry.Append("cash_return_counters_type4 ="+cash_return_counters_type4DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type1Changed )
{
qry.Append("cash_dispensed_denomination_type1 ="+cash_dispensed_denomination_type1DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type1Changed )
{
qry.Append("cash_dispensed_counters_type1 ="+cash_dispensed_counters_type1DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type2Changed )
{
qry.Append("cash_dispensed_denomination_type2 ="+cash_dispensed_denomination_type2DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type2Changed )
{
qry.Append("cash_dispensed_counters_type2 ="+cash_dispensed_counters_type2DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type3Changed )
{
qry.Append("cash_dispensed_denomination_type3 ="+cash_dispensed_denomination_type3DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type3Changed )
{
qry.Append("cash_dispensed_counters_type3 ="+cash_dispensed_counters_type3DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type4Changed )
{
qry.Append("cash_dispensed_denomination_type4 ="+cash_dispensed_denomination_type4DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type4Changed )
{
qry.Append("cash_dispensed_counters_type4 ="+cash_dispensed_counters_type4DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type1Changed )
{
qry.Append("cash_rejected_denomination_type1 ="+cash_rejected_denomination_type1DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type1Changed )
{
qry.Append("cash_rejected_counters_type1 ="+cash_rejected_counters_type1DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type2Changed )
{
qry.Append("cash_rejected_denomination_type2 ="+cash_rejected_denomination_type2DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type2Changed )
{
qry.Append("cash_rejected_counters_type2 ="+cash_rejected_counters_type2DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type3Changed )
{
qry.Append("cash_rejected_denomination_type3 ="+cash_rejected_denomination_type3DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type3Changed )
{
qry.Append("cash_rejected_counters_type3 ="+cash_rejected_counters_type3DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type4Changed )
{
qry.Append("cash_rejected_denomination_type4 ="+cash_rejected_denomination_type4DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type4Changed )
{
qry.Append("cash_rejected_counters_type4 ="+cash_rejected_counters_type4DbString);
qry.Append(",");
}

if ( uploaded_byChanged )
{
qry.Append("uploaded_by ="+uploaded_byDbString);
qry.Append(",");
}

if ( upload_datetimeChanged )
{
qry.Append("upload_datetime ="+upload_datetimeDbString);
qry.Append(",");
}

if ( atm_site_and_numberChanged )
{
qry.Append("atm_site_and_number ="+atm_site_and_numberDbString);
qry.Append(",");
}

if ( total_replenishedChanged )
{
qry.Append("total_replenished ="+total_replenishedDbString);
qry.Append(",");
}

if ( date_of_old_replenisedChanged )
{
qry.Append("date_of_old_replenised ="+date_of_old_replenisedDbString);
qry.Append(",");
}

if ( locationChanged )
{
qry.Append("location ="+locationDbString);
qry.Append(",");
}

if ( atm_noChanged )
{
qry.Append("atm_no ="+atm_noDbString);
qry.Append(",");
}

if ( total_returnedChanged )
{
qry.Append("total_returned ="+total_returnedDbString);
qry.Append(",");
}

if ( cash_rep_denomination_type5Changed )
{
qry.Append("cash_rep_denomination_type5 ="+cash_rep_denomination_type5DbString);
qry.Append(",");
}

if ( cash_rep_counters_type5Changed )
{
qry.Append("cash_rep_counters_type5 ="+cash_rep_counters_type5DbString);
qry.Append(",");
}

if ( cash_rep_denomination_type6Changed )
{
qry.Append("cash_rep_denomination_type6 ="+cash_rep_denomination_type6DbString);
qry.Append(",");
}

if ( cash_rep_counters_type6Changed )
{
qry.Append("cash_rep_counters_type6 ="+cash_rep_counters_type6DbString);
qry.Append(",");
}

if ( cash_rep_denomination_type7Changed )
{
qry.Append("cash_rep_denomination_type7 ="+cash_rep_denomination_type7DbString);
qry.Append(",");
}

if ( cash_rep_counters_type7Changed )
{
qry.Append("cash_rep_counters_type7 ="+cash_rep_counters_type7DbString);
qry.Append(",");
}

if ( cash_return_denomination_type5Changed )
{
qry.Append("cash_return_denomination_type5 ="+cash_return_denomination_type5DbString);
qry.Append(",");
}

if ( cash_return_counters_type5Changed )
{
qry.Append("cash_return_counters_type5 ="+cash_return_counters_type5DbString);
qry.Append(",");
}

if ( cash_return_denomination_type6Changed )
{
qry.Append("cash_return_denomination_type6 ="+cash_return_denomination_type6DbString);
qry.Append(",");
}

if ( cash_return_counters_type6Changed )
{
qry.Append("cash_return_counters_type6 ="+cash_return_counters_type6DbString);
qry.Append(",");
}

if ( cash_return_denomination_type7Changed )
{
qry.Append("cash_return_denomination_type7 ="+cash_return_denomination_type7DbString);
qry.Append(",");
}

if ( cash_return_counters_type7Changed )
{
qry.Append("cash_return_counters_type7 ="+cash_return_counters_type7DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type5Changed )
{
qry.Append("cash_dispensed_denomination_type5 ="+cash_dispensed_denomination_type5DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type5Changed )
{
qry.Append("cash_dispensed_counters_type5 ="+cash_dispensed_counters_type5DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type6Changed )
{
qry.Append("cash_dispensed_denomination_type6 ="+cash_dispensed_denomination_type6DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type6Changed )
{
qry.Append("cash_dispensed_counters_type6 ="+cash_dispensed_counters_type6DbString);
qry.Append(",");
}

if ( cash_dispensed_denomination_type7Changed )
{
qry.Append("cash_dispensed_denomination_type7 ="+cash_dispensed_denomination_type7DbString);
qry.Append(",");
}

if ( cash_dispensed_counters_type7Changed )
{
qry.Append("cash_dispensed_counters_type7 ="+cash_dispensed_counters_type7DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type5Changed )
{
qry.Append("cash_rejected_denomination_type5 ="+cash_rejected_denomination_type5DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type5Changed )
{
qry.Append("cash_rejected_counters_type5 ="+cash_rejected_counters_type5DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type6Changed )
{
qry.Append("cash_rejected_denomination_type6 ="+cash_rejected_denomination_type6DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type6Changed )
{
qry.Append("cash_rejected_counters_type6 ="+cash_rejected_counters_type6DbString);
qry.Append(",");
}

if ( cash_rejected_denomination_type7Changed )
{
qry.Append("cash_rejected_denomination_type7 ="+cash_rejected_denomination_type7DbString);
qry.Append(",");
}

if ( cash_rejected_counters_type7Changed )
{
qry.Append("cash_rejected_counters_type7 ="+cash_rejected_counters_type7DbString);
qry.Append(",");
}

if ( cash_rem_denomination_type5Changed )
{
qry.Append("cash_rem_denomination_type5 ="+cash_rem_denomination_type5DbString);
qry.Append(",");
}

if ( cash_rem_counters_type5Changed )
{
qry.Append("cash_rem_counters_type5 ="+cash_rem_counters_type5DbString);
qry.Append(",");
}

if ( cash_rem_denomination_type6Changed )
{
qry.Append("cash_rem_denomination_type6 ="+cash_rem_denomination_type6DbString);
qry.Append(",");
}

if ( cash_rem_counters_type6Changed )
{
qry.Append("cash_rem_counters_type6 ="+cash_rem_counters_type6DbString);
qry.Append(",");
}

if ( cash_rem_denomination_type7Changed )
{
qry.Append("cash_rem_denomination_type7 ="+cash_rem_denomination_type7DbString);
qry.Append(",");
}

if ( cash_rem_counters_type7Changed )
{
qry.Append("cash_rem_counters_type7 ="+cash_rem_counters_type7DbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_settlement_history_id = "+atm_settlement_history_idDbString);
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
cmd.CommandText = "DELETE Atm_settlement_history where atm_settlement_history_id = "+ atm_settlement_history_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmSettlementHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_settlement_history where " + where);
}

#endregion
}
}
