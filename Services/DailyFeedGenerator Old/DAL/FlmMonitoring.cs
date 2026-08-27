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
public class FlmMonitoring
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public FlmMonitoring() { }
public FlmMonitoring( int flm_monitoring_id ) 
{
}
public FlmMonitoring( DateTime? activity_datetime,string ticket_number,string log,string call_reported_by,string atm_id_no,string atm_location,string type_of_problem,string code,string info_passed_to,DateTime? time_of_info,DateTime? time_of_reaching_site,DateTime? time_of_solving,string attended_by,int? reject_receipt_counter_type1,int? reject_receipt_counter_type2,int? reject_receipt_counter_type3,int? reject_receipt_counter_type4,int? physical_reject_counter_type1,int? physical_reject_counter_type2,int? physical_reject_counter_type3,int? physical_reject_counter_type4,string actual_problem_found,string action_taken,string bna_jammed_counter,string te_bag_no_and_count,DateTime? time_of_call_to_bank,int? sno,int? uploaded_by,DateTime? upload_datetime,string type_of_call )
{
this.activity_datetime = activity_datetime;
this.activity_datetimeChanged = true;
this.ticket_number = ticket_number;
this.ticket_numberChanged = true;
this.log = log;
this.logChanged = true;
this.call_reported_by = call_reported_by;
this.call_reported_byChanged = true;
this.atm_id_no = atm_id_no;
this.atm_id_noChanged = true;
this.atm_location = atm_location;
this.atm_locationChanged = true;
this.type_of_problem = type_of_problem;
this.type_of_problemChanged = true;
this.code = code;
this.codeChanged = true;
this.info_passed_to = info_passed_to;
this.info_passed_toChanged = true;
this.time_of_info = time_of_info;
this.time_of_infoChanged = true;
this.time_of_reaching_site = time_of_reaching_site;
this.time_of_reaching_siteChanged = true;
this.time_of_solving = time_of_solving;
this.time_of_solvingChanged = true;
this.attended_by = attended_by;
this.attended_byChanged = true;
this.reject_receipt_counter_type1 = reject_receipt_counter_type1;
this.reject_receipt_counter_type1Changed = true;
this.reject_receipt_counter_type2 = reject_receipt_counter_type2;
this.reject_receipt_counter_type2Changed = true;
this.reject_receipt_counter_type3 = reject_receipt_counter_type3;
this.reject_receipt_counter_type3Changed = true;
this.reject_receipt_counter_type4 = reject_receipt_counter_type4;
this.reject_receipt_counter_type4Changed = true;
this.physical_reject_counter_type1 = physical_reject_counter_type1;
this.physical_reject_counter_type1Changed = true;
this.physical_reject_counter_type2 = physical_reject_counter_type2;
this.physical_reject_counter_type2Changed = true;
this.physical_reject_counter_type3 = physical_reject_counter_type3;
this.physical_reject_counter_type3Changed = true;
this.physical_reject_counter_type4 = physical_reject_counter_type4;
this.physical_reject_counter_type4Changed = true;
this.actual_problem_found = actual_problem_found;
this.actual_problem_foundChanged = true;
this.action_taken = action_taken;
this.action_takenChanged = true;
this.bna_jammed_counter = bna_jammed_counter;
this.bna_jammed_counterChanged = true;
this.te_bag_no_and_count = te_bag_no_and_count;
this.te_bag_no_and_countChanged = true;
this.time_of_call_to_bank = time_of_call_to_bank;
this.time_of_call_to_bankChanged = true;
this.sno = sno;
this.snoChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.upload_datetime = upload_datetime;
this.upload_datetimeChanged = true;
this.type_of_call = type_of_call;
this.type_of_callChanged = true;
}
private FlmMonitoring( int flm_monitoring_id,DateTime? activity_datetime,string ticket_number,string log,string call_reported_by,string atm_id_no,string atm_location,string type_of_problem,string code,string info_passed_to,DateTime? time_of_info,DateTime? time_of_reaching_site,DateTime? time_of_solving,string attended_by,int? reject_receipt_counter_type1,int? reject_receipt_counter_type2,int? reject_receipt_counter_type3,int? reject_receipt_counter_type4,int? physical_reject_counter_type1,int? physical_reject_counter_type2,int? physical_reject_counter_type3,int? physical_reject_counter_type4,string actual_problem_found,string action_taken,string bna_jammed_counter,string te_bag_no_and_count,DateTime? time_of_call_to_bank,int? sno,int? uploaded_by,DateTime? upload_datetime,string type_of_call )
{
this.flm_monitoring_id = flm_monitoring_id;
this.flm_monitoring_idChanged = true;
this.activity_datetime = activity_datetime;
this.activity_datetimeChanged = true;
this.ticket_number = ticket_number;
this.ticket_numberChanged = true;
this.log = log;
this.logChanged = true;
this.call_reported_by = call_reported_by;
this.call_reported_byChanged = true;
this.atm_id_no = atm_id_no;
this.atm_id_noChanged = true;
this.atm_location = atm_location;
this.atm_locationChanged = true;
this.type_of_problem = type_of_problem;
this.type_of_problemChanged = true;
this.code = code;
this.codeChanged = true;
this.info_passed_to = info_passed_to;
this.info_passed_toChanged = true;
this.time_of_info = time_of_info;
this.time_of_infoChanged = true;
this.time_of_reaching_site = time_of_reaching_site;
this.time_of_reaching_siteChanged = true;
this.time_of_solving = time_of_solving;
this.time_of_solvingChanged = true;
this.attended_by = attended_by;
this.attended_byChanged = true;
this.reject_receipt_counter_type1 = reject_receipt_counter_type1;
this.reject_receipt_counter_type1Changed = true;
this.reject_receipt_counter_type2 = reject_receipt_counter_type2;
this.reject_receipt_counter_type2Changed = true;
this.reject_receipt_counter_type3 = reject_receipt_counter_type3;
this.reject_receipt_counter_type3Changed = true;
this.reject_receipt_counter_type4 = reject_receipt_counter_type4;
this.reject_receipt_counter_type4Changed = true;
this.physical_reject_counter_type1 = physical_reject_counter_type1;
this.physical_reject_counter_type1Changed = true;
this.physical_reject_counter_type2 = physical_reject_counter_type2;
this.physical_reject_counter_type2Changed = true;
this.physical_reject_counter_type3 = physical_reject_counter_type3;
this.physical_reject_counter_type3Changed = true;
this.physical_reject_counter_type4 = physical_reject_counter_type4;
this.physical_reject_counter_type4Changed = true;
this.actual_problem_found = actual_problem_found;
this.actual_problem_foundChanged = true;
this.action_taken = action_taken;
this.action_takenChanged = true;
this.bna_jammed_counter = bna_jammed_counter;
this.bna_jammed_counterChanged = true;
this.te_bag_no_and_count = te_bag_no_and_count;
this.te_bag_no_and_countChanged = true;
this.time_of_call_to_bank = time_of_call_to_bank;
this.time_of_call_to_bankChanged = true;
this.sno = sno;
this.snoChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.upload_datetime = upload_datetime;
this.upload_datetimeChanged = true;
this.type_of_call = type_of_call;
this.type_of_callChanged = true;
}

#region members and properties for columns

#region FlmMonitoringId
private bool flm_monitoring_idChanged = false;
private int flm_monitoring_id;
public int FlmMonitoringId
{
get { return flm_monitoring_id; }
set { 
flm_monitoring_id = value;
flm_monitoring_idChanged = true;
}
}
private string flm_monitoring_idDbString
{
get
{
return flm_monitoring_id.ToString();
}
}
#endregion
#region ActivityDatetime
private bool activity_datetimeChanged = false;
private DateTime? activity_datetime;
public DateTime? ActivityDatetime
{
get { return activity_datetime; }
set { 
activity_datetime = value;
activity_datetimeChanged = true;
}
}
private string activity_datetimeDbString
{
get
{
if (this.activity_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",activity_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region TicketNumber
private bool ticket_numberChanged = false;
private string ticket_number;
public string TicketNumber
{
get { return ticket_number; }
set { 
ticket_number = value;
ticket_numberChanged = true;
}
}
private string ticket_numberDbString
{
get
{
if (this.ticket_number!=null)
return string.Format("'{0}'",ticket_number); else
return "null";
}
}
#endregion
#region Log
private bool logChanged = false;
private string log;
public string Log
{
get { return log; }
set { 
log = value;
logChanged = true;
}
}
private string logDbString
{
get
{
if (this.log!=null)
return string.Format("'{0}'",log); else
return "null";
}
}
#endregion
#region CallReportedBy
private bool call_reported_byChanged = false;
private string call_reported_by;
public string CallReportedBy
{
get { return call_reported_by; }
set { 
call_reported_by = value;
call_reported_byChanged = true;
}
}
private string call_reported_byDbString
{
get
{
if (this.call_reported_by!=null)
return string.Format("'{0}'",call_reported_by); else
return "null";
}
}
#endregion
#region AtmIdNo
private bool atm_id_noChanged = false;
private string atm_id_no;
public string AtmIdNo
{
get { return atm_id_no; }
set { 
atm_id_no = value;
atm_id_noChanged = true;
}
}
private string atm_id_noDbString
{
get
{
if (this.atm_id_no!=null)
return string.Format("'{0}'",atm_id_no); else
return "null";
}
}
#endregion
#region AtmLocation
private bool atm_locationChanged = false;
private string atm_location;
public string AtmLocation
{
get { return atm_location; }
set { 
atm_location = value;
atm_locationChanged = true;
}
}
private string atm_locationDbString
{
get
{
if (this.atm_location!=null)
return string.Format("'{0}'",atm_location); else
return "null";
}
}
#endregion
#region TypeOfProblem
private bool type_of_problemChanged = false;
private string type_of_problem;
public string TypeOfProblem
{
get { return type_of_problem; }
set { 
type_of_problem = value;
type_of_problemChanged = true;
}
}
private string type_of_problemDbString
{
get
{
if (this.type_of_problem!=null)
return string.Format("'{0}'",type_of_problem); else
return "null";
}
}
#endregion
#region Code
private bool codeChanged = false;
private string code;
public string Code
{
get { return code; }
set { 
code = value;
codeChanged = true;
}
}
private string codeDbString
{
get
{
if (this.code!=null)
return string.Format("'{0}'",code); else
return "null";
}
}
#endregion
#region InfoPassedTo
private bool info_passed_toChanged = false;
private string info_passed_to;
public string InfoPassedTo
{
get { return info_passed_to; }
set { 
info_passed_to = value;
info_passed_toChanged = true;
}
}
private string info_passed_toDbString
{
get
{
if (this.info_passed_to!=null)
return string.Format("'{0}'",info_passed_to); else
return "null";
}
}
#endregion
#region TimeOfInfo
private bool time_of_infoChanged = false;
private DateTime? time_of_info;
public DateTime? TimeOfInfo
{
get { return time_of_info; }
set { 
time_of_info = value;
time_of_infoChanged = true;
}
}
private string time_of_infoDbString
{
get
{
if (this.time_of_info.HasValue)
return string.Format("Convert(datetime,'{0}',121)",time_of_info.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region TimeOfReachingSite
private bool time_of_reaching_siteChanged = false;
private DateTime? time_of_reaching_site;
public DateTime? TimeOfReachingSite
{
get { return time_of_reaching_site; }
set { 
time_of_reaching_site = value;
time_of_reaching_siteChanged = true;
}
}
private string time_of_reaching_siteDbString
{
get
{
if (this.time_of_reaching_site.HasValue)
return string.Format("Convert(datetime,'{0}',121)",time_of_reaching_site.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region TimeOfSolving
private bool time_of_solvingChanged = false;
private DateTime? time_of_solving;
public DateTime? TimeOfSolving
{
get { return time_of_solving; }
set { 
time_of_solving = value;
time_of_solvingChanged = true;
}
}
private string time_of_solvingDbString
{
get
{
if (this.time_of_solving.HasValue)
return string.Format("Convert(datetime,'{0}',121)",time_of_solving.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region AttendedBy
private bool attended_byChanged = false;
private string attended_by;
public string AttendedBy
{
get { return attended_by; }
set { 
attended_by = value;
attended_byChanged = true;
}
}
private string attended_byDbString
{
get
{
if (this.attended_by!=null)
return string.Format("'{0}'",attended_by); else
return "null";
}
}
#endregion
#region RejectReceiptCounterType1
private bool reject_receipt_counter_type1Changed = false;
private int? reject_receipt_counter_type1;
public int? RejectReceiptCounterType1
{
get { return reject_receipt_counter_type1; }
set { 
reject_receipt_counter_type1 = value;
reject_receipt_counter_type1Changed = true;
}
}
private string reject_receipt_counter_type1DbString
{
get
{
if (this.reject_receipt_counter_type1.HasValue)
return reject_receipt_counter_type1.ToString();
else
return "null";
}
}
#endregion
#region RejectReceiptCounterType2
private bool reject_receipt_counter_type2Changed = false;
private int? reject_receipt_counter_type2;
public int? RejectReceiptCounterType2
{
get { return reject_receipt_counter_type2; }
set { 
reject_receipt_counter_type2 = value;
reject_receipt_counter_type2Changed = true;
}
}
private string reject_receipt_counter_type2DbString
{
get
{
if (this.reject_receipt_counter_type2.HasValue)
return reject_receipt_counter_type2.ToString();
else
return "null";
}
}
#endregion
#region RejectReceiptCounterType3
private bool reject_receipt_counter_type3Changed = false;
private int? reject_receipt_counter_type3;
public int? RejectReceiptCounterType3
{
get { return reject_receipt_counter_type3; }
set { 
reject_receipt_counter_type3 = value;
reject_receipt_counter_type3Changed = true;
}
}
private string reject_receipt_counter_type3DbString
{
get
{
if (this.reject_receipt_counter_type3.HasValue)
return reject_receipt_counter_type3.ToString();
else
return "null";
}
}
#endregion
#region RejectReceiptCounterType4
private bool reject_receipt_counter_type4Changed = false;
private int? reject_receipt_counter_type4;
public int? RejectReceiptCounterType4
{
get { return reject_receipt_counter_type4; }
set { 
reject_receipt_counter_type4 = value;
reject_receipt_counter_type4Changed = true;
}
}
private string reject_receipt_counter_type4DbString
{
get
{
if (this.reject_receipt_counter_type4.HasValue)
return reject_receipt_counter_type4.ToString();
else
return "null";
}
}
#endregion
#region PhysicalRejectCounterType1
private bool physical_reject_counter_type1Changed = false;
private int? physical_reject_counter_type1;
public int? PhysicalRejectCounterType1
{
get { return physical_reject_counter_type1; }
set { 
physical_reject_counter_type1 = value;
physical_reject_counter_type1Changed = true;
}
}
private string physical_reject_counter_type1DbString
{
get
{
if (this.physical_reject_counter_type1.HasValue)
return physical_reject_counter_type1.ToString();
else
return "null";
}
}
#endregion
#region PhysicalRejectCounterType2
private bool physical_reject_counter_type2Changed = false;
private int? physical_reject_counter_type2;
public int? PhysicalRejectCounterType2
{
get { return physical_reject_counter_type2; }
set { 
physical_reject_counter_type2 = value;
physical_reject_counter_type2Changed = true;
}
}
private string physical_reject_counter_type2DbString
{
get
{
if (this.physical_reject_counter_type2.HasValue)
return physical_reject_counter_type2.ToString();
else
return "null";
}
}
#endregion
#region PhysicalRejectCounterType3
private bool physical_reject_counter_type3Changed = false;
private int? physical_reject_counter_type3;
public int? PhysicalRejectCounterType3
{
get { return physical_reject_counter_type3; }
set { 
physical_reject_counter_type3 = value;
physical_reject_counter_type3Changed = true;
}
}
private string physical_reject_counter_type3DbString
{
get
{
if (this.physical_reject_counter_type3.HasValue)
return physical_reject_counter_type3.ToString();
else
return "null";
}
}
#endregion
#region PhysicalRejectCounterType4
private bool physical_reject_counter_type4Changed = false;
private int? physical_reject_counter_type4;
public int? PhysicalRejectCounterType4
{
get { return physical_reject_counter_type4; }
set { 
physical_reject_counter_type4 = value;
physical_reject_counter_type4Changed = true;
}
}
private string physical_reject_counter_type4DbString
{
get
{
if (this.physical_reject_counter_type4.HasValue)
return physical_reject_counter_type4.ToString();
else
return "null";
}
}
#endregion
#region ActualProblemFound
private bool actual_problem_foundChanged = false;
private string actual_problem_found;
public string ActualProblemFound
{
get { return actual_problem_found; }
set { 
actual_problem_found = value;
actual_problem_foundChanged = true;
}
}
private string actual_problem_foundDbString
{
get
{
if (this.actual_problem_found!=null)
return string.Format("'{0}'",actual_problem_found); else
return "null";
}
}
#endregion
#region ActionTaken
private bool action_takenChanged = false;
private string action_taken;
public string ActionTaken
{
get { return action_taken; }
set { 
action_taken = value;
action_takenChanged = true;
}
}
private string action_takenDbString
{
get
{
if (this.action_taken!=null)
return string.Format("'{0}'",action_taken); else
return "null";
}
}
#endregion
#region BnaJammedCounter
private bool bna_jammed_counterChanged = false;
private string bna_jammed_counter;
public string BnaJammedCounter
{
get { return bna_jammed_counter; }
set { 
bna_jammed_counter = value;
bna_jammed_counterChanged = true;
}
}
private string bna_jammed_counterDbString
{
get
{
if (this.bna_jammed_counter!=null)
return string.Format("'{0}'",bna_jammed_counter); else
return "null";
}
}
#endregion
#region TeBagNoAndCount
private bool te_bag_no_and_countChanged = false;
private string te_bag_no_and_count;
public string TeBagNoAndCount
{
get { return te_bag_no_and_count; }
set { 
te_bag_no_and_count = value;
te_bag_no_and_countChanged = true;
}
}
private string te_bag_no_and_countDbString
{
get
{
if (this.te_bag_no_and_count!=null)
return string.Format("'{0}'",te_bag_no_and_count); else
return "null";
}
}
#endregion
#region TimeOfCallToBank
private bool time_of_call_to_bankChanged = false;
private DateTime? time_of_call_to_bank;
public DateTime? TimeOfCallToBank
{
get { return time_of_call_to_bank; }
set { 
time_of_call_to_bank = value;
time_of_call_to_bankChanged = true;
}
}
private string time_of_call_to_bankDbString
{
get
{
if (this.time_of_call_to_bank.HasValue)
return string.Format("Convert(datetime,'{0}',121)",time_of_call_to_bank.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region Sno
private bool snoChanged = false;
private int? sno;
public int? Sno
{
get { return sno; }
set { 
sno = value;
snoChanged = true;
}
}
private string snoDbString
{
get
{
if (this.sno.HasValue)
return sno.ToString();
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
#region TypeOfCall
private bool type_of_callChanged = false;
private string type_of_call;
public string TypeOfCall
{
get { return type_of_call; }
set { 
type_of_call = value;
type_of_callChanged = true;
}
}
private string type_of_callDbString
{
get
{
if (this.type_of_call!=null)
return string.Format("'{0}'",type_of_call); else
return "null";
}
}
#endregion
#endregion

#region FlmMonitoringReader
public class FlmMonitoringReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
FlmMonitoring currentFlmMonitoring;
Columns columns;
bool partialRead = false;
private FlmMonitoringReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public FlmMonitoringReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public FlmMonitoringReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentFlmMonitoring; }

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
currentFlmMonitoring = new FlmMonitoring();
if (partialRead)
{ if ((columns & Columns.flm_monitoring_id) == Columns.flm_monitoring_id && reader["flm_monitoring_id"]!=DBNull.Value)
currentFlmMonitoring.flm_monitoring_id =(int) reader["flm_monitoring_id"]; 
if ((columns & Columns.activity_datetime) == Columns.activity_datetime && reader["activity_datetime"]!=DBNull.Value)
currentFlmMonitoring.activity_datetime =(DateTime?) reader["activity_datetime"]; 
if ((columns & Columns.ticket_number) == Columns.ticket_number && reader["ticket_number"]!=DBNull.Value)
currentFlmMonitoring.ticket_number =(string) reader["ticket_number"]; 
if ((columns & Columns.log) == Columns.log && reader["log"]!=DBNull.Value)
currentFlmMonitoring.log =(string) reader["log"]; 
if ((columns & Columns.call_reported_by) == Columns.call_reported_by && reader["call_reported_by"]!=DBNull.Value)
currentFlmMonitoring.call_reported_by =(string) reader["call_reported_by"]; 
if ((columns & Columns.atm_id_no) == Columns.atm_id_no && reader["atm_id_no"]!=DBNull.Value)
currentFlmMonitoring.atm_id_no =(string) reader["atm_id_no"]; 
if ((columns & Columns.atm_location) == Columns.atm_location && reader["atm_location"]!=DBNull.Value)
currentFlmMonitoring.atm_location =(string) reader["atm_location"]; 
if ((columns & Columns.type_of_problem) == Columns.type_of_problem && reader["type_of_problem"]!=DBNull.Value)
currentFlmMonitoring.type_of_problem =(string) reader["type_of_problem"]; 
if ((columns & Columns.code) == Columns.code && reader["code"]!=DBNull.Value)
currentFlmMonitoring.code =(string) reader["code"]; 
if ((columns & Columns.info_passed_to) == Columns.info_passed_to && reader["info_passed_to"]!=DBNull.Value)
currentFlmMonitoring.info_passed_to =(string) reader["info_passed_to"]; 
if ((columns & Columns.time_of_info) == Columns.time_of_info && reader["time_of_info"]!=DBNull.Value)
currentFlmMonitoring.time_of_info =(DateTime?) reader["time_of_info"]; 
if ((columns & Columns.time_of_reaching_site) == Columns.time_of_reaching_site && reader["time_of_reaching_site"]!=DBNull.Value)
currentFlmMonitoring.time_of_reaching_site =(DateTime?) reader["time_of_reaching_site"]; 
if ((columns & Columns.time_of_solving) == Columns.time_of_solving && reader["time_of_solving"]!=DBNull.Value)
currentFlmMonitoring.time_of_solving =(DateTime?) reader["time_of_solving"]; 
if ((columns & Columns.attended_by) == Columns.attended_by && reader["attended_by"]!=DBNull.Value)
currentFlmMonitoring.attended_by =(string) reader["attended_by"]; 
if ((columns & Columns.reject_receipt_counter_type1) == Columns.reject_receipt_counter_type1 && reader["reject_receipt_counter_type1"]!=DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type1 =(int?) reader["reject_receipt_counter_type1"]; 
if ((columns & Columns.reject_receipt_counter_type2) == Columns.reject_receipt_counter_type2 && reader["reject_receipt_counter_type2"]!=DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type2 =(int?) reader["reject_receipt_counter_type2"]; 
if ((columns & Columns.reject_receipt_counter_type3) == Columns.reject_receipt_counter_type3 && reader["reject_receipt_counter_type3"]!=DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type3 =(int?) reader["reject_receipt_counter_type3"]; 
if ((columns & Columns.reject_receipt_counter_type4) == Columns.reject_receipt_counter_type4 && reader["reject_receipt_counter_type4"]!=DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type4 =(int?) reader["reject_receipt_counter_type4"]; 
if ((columns & Columns.physical_reject_counter_type1) == Columns.physical_reject_counter_type1 && reader["physical_reject_counter_type1"]!=DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type1 =(int?) reader["physical_reject_counter_type1"]; 
if ((columns & Columns.physical_reject_counter_type2) == Columns.physical_reject_counter_type2 && reader["physical_reject_counter_type2"]!=DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type2 =(int?) reader["physical_reject_counter_type2"]; 
if ((columns & Columns.physical_reject_counter_type3) == Columns.physical_reject_counter_type3 && reader["physical_reject_counter_type3"]!=DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type3 =(int?) reader["physical_reject_counter_type3"]; 
if ((columns & Columns.physical_reject_counter_type4) == Columns.physical_reject_counter_type4 && reader["physical_reject_counter_type4"]!=DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type4 =(int?) reader["physical_reject_counter_type4"]; 
if ((columns & Columns.actual_problem_found) == Columns.actual_problem_found && reader["actual_problem_found"]!=DBNull.Value)
currentFlmMonitoring.actual_problem_found =(string) reader["actual_problem_found"]; 
if ((columns & Columns.action_taken) == Columns.action_taken && reader["action_taken"]!=DBNull.Value)
currentFlmMonitoring.action_taken =(string) reader["action_taken"]; 
if ((columns & Columns.bna_jammed_counter) == Columns.bna_jammed_counter && reader["bna_jammed_counter"]!=DBNull.Value)
currentFlmMonitoring.bna_jammed_counter =(string) reader["bna_jammed_counter"]; 
if ((columns & Columns.te_bag_no_and_count) == Columns.te_bag_no_and_count && reader["te_bag_no_and_count"]!=DBNull.Value)
currentFlmMonitoring.te_bag_no_and_count =(string) reader["te_bag_no_and_count"]; 
if ((columns & Columns.time_of_call_to_bank) == Columns.time_of_call_to_bank && reader["time_of_call_to_bank"]!=DBNull.Value)
currentFlmMonitoring.time_of_call_to_bank =(DateTime?) reader["time_of_call_to_bank"]; 
if ((columns & Columns.sno) == Columns.sno && reader["sno"]!=DBNull.Value)
currentFlmMonitoring.sno =(int?) reader["sno"]; 
if ((columns & Columns.uploaded_by) == Columns.uploaded_by && reader["uploaded_by"]!=DBNull.Value)
currentFlmMonitoring.uploaded_by =(int?) reader["uploaded_by"]; 
if ((columns & Columns.upload_datetime) == Columns.upload_datetime && reader["upload_datetime"]!=DBNull.Value)
currentFlmMonitoring.upload_datetime =(DateTime?) reader["upload_datetime"]; 
if ((columns & Columns.type_of_call) == Columns.type_of_call && reader["type_of_call"]!=DBNull.Value)
currentFlmMonitoring.type_of_call =(string) reader["type_of_call"]; 

} else
{
if (reader["flm_monitoring_id"] != DBNull.Value)
currentFlmMonitoring.flm_monitoring_id = (int) reader["flm_monitoring_id"]; 
if (reader["activity_datetime"] != DBNull.Value)
currentFlmMonitoring.activity_datetime = (DateTime?) reader["activity_datetime"]; 
if (reader["ticket_number"] != DBNull.Value)
currentFlmMonitoring.ticket_number = (string) reader["ticket_number"]; 
if (reader["log"] != DBNull.Value)
currentFlmMonitoring.log = (string) reader["log"]; 
if (reader["call_reported_by"] != DBNull.Value)
currentFlmMonitoring.call_reported_by = (string) reader["call_reported_by"]; 
if (reader["atm_id_no"] != DBNull.Value)
currentFlmMonitoring.atm_id_no = (string) reader["atm_id_no"]; 
if (reader["atm_location"] != DBNull.Value)
currentFlmMonitoring.atm_location = (string) reader["atm_location"]; 
if (reader["type_of_problem"] != DBNull.Value)
currentFlmMonitoring.type_of_problem = (string) reader["type_of_problem"]; 
if (reader["code"] != DBNull.Value)
currentFlmMonitoring.code = (string) reader["code"]; 
if (reader["info_passed_to"] != DBNull.Value)
currentFlmMonitoring.info_passed_to = (string) reader["info_passed_to"]; 
if (reader["time_of_info"] != DBNull.Value)
currentFlmMonitoring.time_of_info = (DateTime?) reader["time_of_info"]; 
if (reader["time_of_reaching_site"] != DBNull.Value)
currentFlmMonitoring.time_of_reaching_site = (DateTime?) reader["time_of_reaching_site"]; 
if (reader["time_of_solving"] != DBNull.Value)
currentFlmMonitoring.time_of_solving = (DateTime?) reader["time_of_solving"]; 
if (reader["attended_by"] != DBNull.Value)
currentFlmMonitoring.attended_by = (string) reader["attended_by"]; 
if (reader["reject_receipt_counter_type1"] != DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type1 = (int?) reader["reject_receipt_counter_type1"]; 
if (reader["reject_receipt_counter_type2"] != DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type2 = (int?) reader["reject_receipt_counter_type2"]; 
if (reader["reject_receipt_counter_type3"] != DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type3 = (int?) reader["reject_receipt_counter_type3"]; 
if (reader["reject_receipt_counter_type4"] != DBNull.Value)
currentFlmMonitoring.reject_receipt_counter_type4 = (int?) reader["reject_receipt_counter_type4"]; 
if (reader["physical_reject_counter_type1"] != DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type1 = (int?) reader["physical_reject_counter_type1"]; 
if (reader["physical_reject_counter_type2"] != DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type2 = (int?) reader["physical_reject_counter_type2"]; 
if (reader["physical_reject_counter_type3"] != DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type3 = (int?) reader["physical_reject_counter_type3"]; 
if (reader["physical_reject_counter_type4"] != DBNull.Value)
currentFlmMonitoring.physical_reject_counter_type4 = (int?) reader["physical_reject_counter_type4"]; 
if (reader["actual_problem_found"] != DBNull.Value)
currentFlmMonitoring.actual_problem_found = (string) reader["actual_problem_found"]; 
if (reader["action_taken"] != DBNull.Value)
currentFlmMonitoring.action_taken = (string) reader["action_taken"]; 
if (reader["bna_jammed_counter"] != DBNull.Value)
currentFlmMonitoring.bna_jammed_counter = (string) reader["bna_jammed_counter"]; 
if (reader["te_bag_no_and_count"] != DBNull.Value)
currentFlmMonitoring.te_bag_no_and_count = (string) reader["te_bag_no_and_count"]; 
if (reader["time_of_call_to_bank"] != DBNull.Value)
currentFlmMonitoring.time_of_call_to_bank = (DateTime?) reader["time_of_call_to_bank"]; 
if (reader["sno"] != DBNull.Value)
currentFlmMonitoring.sno = (int?) reader["sno"]; 
if (reader["uploaded_by"] != DBNull.Value)
currentFlmMonitoring.uploaded_by = (int?) reader["uploaded_by"]; 
if (reader["upload_datetime"] != DBNull.Value)
currentFlmMonitoring.upload_datetime = (DateTime?) reader["upload_datetime"]; 
if (reader["type_of_call"] != DBNull.Value)
currentFlmMonitoring.type_of_call = (string) reader["type_of_call"]; 
} 

currentFlmMonitoring.isNewEntity = false;
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

public FlmMonitoring CurrentFlmMonitoring
{
get{ return currentFlmMonitoring; }
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


#region FlmMonitoring functions

public static FlmMonitoringReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.flm_monitoring_id == (Columns.flm_monitoring_id & columns))
qry.Append("flm_monitoring_id,");
if (Columns.activity_datetime == (Columns.activity_datetime & columns))
qry.Append("activity_datetime,");
if (Columns.ticket_number == (Columns.ticket_number & columns))
qry.Append("ticket_number,");
if (Columns.log == (Columns.log & columns))
qry.Append("log,");
if (Columns.call_reported_by == (Columns.call_reported_by & columns))
qry.Append("call_reported_by,");
if (Columns.atm_id_no == (Columns.atm_id_no & columns))
qry.Append("atm_id_no,");
if (Columns.atm_location == (Columns.atm_location & columns))
qry.Append("atm_location,");
if (Columns.type_of_problem == (Columns.type_of_problem & columns))
qry.Append("type_of_problem,");
if (Columns.code == (Columns.code & columns))
qry.Append("code,");
if (Columns.info_passed_to == (Columns.info_passed_to & columns))
qry.Append("info_passed_to,");
if (Columns.time_of_info == (Columns.time_of_info & columns))
qry.Append("time_of_info,");
if (Columns.time_of_reaching_site == (Columns.time_of_reaching_site & columns))
qry.Append("time_of_reaching_site,");
if (Columns.time_of_solving == (Columns.time_of_solving & columns))
qry.Append("time_of_solving,");
if (Columns.attended_by == (Columns.attended_by & columns))
qry.Append("attended_by,");
if (Columns.reject_receipt_counter_type1 == (Columns.reject_receipt_counter_type1 & columns))
qry.Append("reject_receipt_counter_type1,");
if (Columns.reject_receipt_counter_type2 == (Columns.reject_receipt_counter_type2 & columns))
qry.Append("reject_receipt_counter_type2,");
if (Columns.reject_receipt_counter_type3 == (Columns.reject_receipt_counter_type3 & columns))
qry.Append("reject_receipt_counter_type3,");
if (Columns.reject_receipt_counter_type4 == (Columns.reject_receipt_counter_type4 & columns))
qry.Append("reject_receipt_counter_type4,");
if (Columns.physical_reject_counter_type1 == (Columns.physical_reject_counter_type1 & columns))
qry.Append("physical_reject_counter_type1,");
if (Columns.physical_reject_counter_type2 == (Columns.physical_reject_counter_type2 & columns))
qry.Append("physical_reject_counter_type2,");
if (Columns.physical_reject_counter_type3 == (Columns.physical_reject_counter_type3 & columns))
qry.Append("physical_reject_counter_type3,");
if (Columns.physical_reject_counter_type4 == (Columns.physical_reject_counter_type4 & columns))
qry.Append("physical_reject_counter_type4,");
if (Columns.actual_problem_found == (Columns.actual_problem_found & columns))
qry.Append("actual_problem_found,");
if (Columns.action_taken == (Columns.action_taken & columns))
qry.Append("action_taken,");
if (Columns.bna_jammed_counter == (Columns.bna_jammed_counter & columns))
qry.Append("bna_jammed_counter,");
if (Columns.te_bag_no_and_count == (Columns.te_bag_no_and_count & columns))
qry.Append("te_bag_no_and_count,");
if (Columns.time_of_call_to_bank == (Columns.time_of_call_to_bank & columns))
qry.Append("time_of_call_to_bank,");
if (Columns.sno == (Columns.sno & columns))
qry.Append("sno,");
if (Columns.uploaded_by == (Columns.uploaded_by & columns))
qry.Append("uploaded_by,");
if (Columns.upload_datetime == (Columns.upload_datetime & columns))
qry.Append("upload_datetime,");
if (Columns.type_of_call == (Columns.type_of_call & columns))
qry.Append("type_of_call,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Flm_monitoring ");

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
return new FlmMonitoringReader(cmd.ExecuteReader(), conn, columns);
}

static public FlmMonitoringReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static FlmMonitoringReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select flm_monitoring_id,activity_datetime,ticket_number,log,call_reported_by,atm_id_no,atm_location,type_of_problem,code,info_passed_to,time_of_info,time_of_reaching_site,time_of_solving,attended_by,reject_receipt_counter_type1,reject_receipt_counter_type2,reject_receipt_counter_type3,reject_receipt_counter_type4,physical_reject_counter_type1,physical_reject_counter_type2,physical_reject_counter_type3,physical_reject_counter_type4,actual_problem_found,action_taken,bna_jammed_counter,te_bag_no_and_count,time_of_call_to_bank,sno,uploaded_by,upload_datetime,type_of_call from Flm_monitoring ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new FlmMonitoringReader(cmd.ExecuteReader(), conn);
}

static public FlmMonitoringReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static FlmMonitoring LoadFlmMonitoring(string where)
{
FlmMonitoringReader reader = FlmMonitoring.ExecuteReader(where);
FlmMonitoring _flmmonitoring = null;
if (reader.Read())
_flmmonitoring = reader.CurrentFlmMonitoring;
reader.Close();
return _flmmonitoring;
}

public static FlmMonitoring LoadFlmMonitoring(string where, IDbConnection conn)
{
FlmMonitoringReader reader = FlmMonitoring.ExecuteReader(where, conn);
FlmMonitoring _flmmonitoring = null;
if (reader.Read())
_flmmonitoring = reader.CurrentFlmMonitoring;
reader.Close(false);
return _flmmonitoring;
}

public static FlmMonitoring LoadFlmMonitoringByPk( int flm_monitoring_id )
{
return LoadFlmMonitoring( " flm_monitoring_id="+flm_monitoring_id );
}

public static FlmMonitoring LoadFlmMonitoringByPk( int flm_monitoring_id , IDbConnection conn)
{
return LoadFlmMonitoring(" flm_monitoring_id="+flm_monitoring_id , conn);
}

public void Save()
{
if (flm_monitoring_idChanged || activity_datetimeChanged || ticket_numberChanged || logChanged || call_reported_byChanged || atm_id_noChanged || atm_locationChanged || type_of_problemChanged || codeChanged || info_passed_toChanged || time_of_infoChanged || time_of_reaching_siteChanged || time_of_solvingChanged || attended_byChanged || reject_receipt_counter_type1Changed || reject_receipt_counter_type2Changed || reject_receipt_counter_type3Changed || reject_receipt_counter_type4Changed || physical_reject_counter_type1Changed || physical_reject_counter_type2Changed || physical_reject_counter_type3Changed || physical_reject_counter_type4Changed || actual_problem_foundChanged || action_takenChanged || bna_jammed_counterChanged || te_bag_no_and_countChanged || time_of_call_to_bankChanged || snoChanged || uploaded_byChanged || upload_datetimeChanged || type_of_callChanged )
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
if (flm_monitoring_idChanged || activity_datetimeChanged || ticket_numberChanged || logChanged || call_reported_byChanged || atm_id_noChanged || atm_locationChanged || type_of_problemChanged || codeChanged || info_passed_toChanged || time_of_infoChanged || time_of_reaching_siteChanged || time_of_solvingChanged || attended_byChanged || reject_receipt_counter_type1Changed || reject_receipt_counter_type2Changed || reject_receipt_counter_type3Changed || reject_receipt_counter_type4Changed || physical_reject_counter_type1Changed || physical_reject_counter_type2Changed || physical_reject_counter_type3Changed || physical_reject_counter_type4Changed || actual_problem_foundChanged || action_takenChanged || bna_jammed_counterChanged || te_bag_no_and_countChanged || time_of_call_to_bankChanged || snoChanged || uploaded_byChanged || upload_datetimeChanged || type_of_callChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Flm_monitoring( flm_monitoring_id,activity_datetime,ticket_number,log,call_reported_by,atm_id_no,atm_location,type_of_problem,code,info_passed_to,time_of_info,time_of_reaching_site,time_of_solving,attended_by,reject_receipt_counter_type1,reject_receipt_counter_type2,reject_receipt_counter_type3,reject_receipt_counter_type4,physical_reject_counter_type1,physical_reject_counter_type2,physical_reject_counter_type3,physical_reject_counter_type4,actual_problem_found,action_taken,bna_jammed_counter,te_bag_no_and_count,time_of_call_to_bank,sno,uploaded_by,upload_datetime,type_of_call ) values(");
lock (ConnectionFactory.connectionString) { this.flm_monitoring_id = ConnectionFactory.GetNextId();
qry.Append(this.flm_monitoring_id);
} qry.Append(",");
qry.Append(activity_datetimeDbString+",");
qry.Append(ticket_numberDbString+",");
qry.Append(logDbString+",");
qry.Append(call_reported_byDbString+",");
qry.Append(atm_id_noDbString+",");
qry.Append(atm_locationDbString+",");
qry.Append(type_of_problemDbString+",");
qry.Append(codeDbString+",");
qry.Append(info_passed_toDbString+",");
qry.Append(time_of_infoDbString+",");
qry.Append(time_of_reaching_siteDbString+",");
qry.Append(time_of_solvingDbString+",");
qry.Append(attended_byDbString+",");
qry.Append(reject_receipt_counter_type1DbString+",");
qry.Append(reject_receipt_counter_type2DbString+",");
qry.Append(reject_receipt_counter_type3DbString+",");
qry.Append(reject_receipt_counter_type4DbString+",");
qry.Append(physical_reject_counter_type1DbString+",");
qry.Append(physical_reject_counter_type2DbString+",");
qry.Append(physical_reject_counter_type3DbString+",");
qry.Append(physical_reject_counter_type4DbString+",");
qry.Append(actual_problem_foundDbString+",");
qry.Append(action_takenDbString+",");
qry.Append(bna_jammed_counterDbString+",");
qry.Append(te_bag_no_and_countDbString+",");
qry.Append(time_of_call_to_bankDbString+",");
qry.Append(snoDbString+",");
qry.Append(uploaded_byDbString+",");
qry.Append(upload_datetimeDbString+",");
qry.Append(type_of_callDbString);
qry.Append(");");

}
else
{
if (!(flm_monitoring_idChanged || activity_datetimeChanged || ticket_numberChanged || logChanged || call_reported_byChanged || atm_id_noChanged || atm_locationChanged || type_of_problemChanged || codeChanged || info_passed_toChanged || time_of_infoChanged || time_of_reaching_siteChanged || time_of_solvingChanged || attended_byChanged || reject_receipt_counter_type1Changed || reject_receipt_counter_type2Changed || reject_receipt_counter_type3Changed || reject_receipt_counter_type4Changed || physical_reject_counter_type1Changed || physical_reject_counter_type2Changed || physical_reject_counter_type3Changed || physical_reject_counter_type4Changed || actual_problem_foundChanged || action_takenChanged || bna_jammed_counterChanged || te_bag_no_and_countChanged || time_of_call_to_bankChanged || snoChanged || uploaded_byChanged || upload_datetimeChanged || type_of_callChanged ))
return;
qry.Append("UPDATE Flm_monitoring set "); if ( activity_datetimeChanged )
{
qry.Append("activity_datetime ="+activity_datetimeDbString);
qry.Append(",");
}

if ( ticket_numberChanged )
{
qry.Append("ticket_number ="+ticket_numberDbString);
qry.Append(",");
}

if ( logChanged )
{
qry.Append("log ="+logDbString);
qry.Append(",");
}

if ( call_reported_byChanged )
{
qry.Append("call_reported_by ="+call_reported_byDbString);
qry.Append(",");
}

if ( atm_id_noChanged )
{
qry.Append("atm_id_no ="+atm_id_noDbString);
qry.Append(",");
}

if ( atm_locationChanged )
{
qry.Append("atm_location ="+atm_locationDbString);
qry.Append(",");
}

if ( type_of_problemChanged )
{
qry.Append("type_of_problem ="+type_of_problemDbString);
qry.Append(",");
}

if ( codeChanged )
{
qry.Append("code ="+codeDbString);
qry.Append(",");
}

if ( info_passed_toChanged )
{
qry.Append("info_passed_to ="+info_passed_toDbString);
qry.Append(",");
}

if ( time_of_infoChanged )
{
qry.Append("time_of_info ="+time_of_infoDbString);
qry.Append(",");
}

if ( time_of_reaching_siteChanged )
{
qry.Append("time_of_reaching_site ="+time_of_reaching_siteDbString);
qry.Append(",");
}

if ( time_of_solvingChanged )
{
qry.Append("time_of_solving ="+time_of_solvingDbString);
qry.Append(",");
}

if ( attended_byChanged )
{
qry.Append("attended_by ="+attended_byDbString);
qry.Append(",");
}

if ( reject_receipt_counter_type1Changed )
{
qry.Append("reject_receipt_counter_type1 ="+reject_receipt_counter_type1DbString);
qry.Append(",");
}

if ( reject_receipt_counter_type2Changed )
{
qry.Append("reject_receipt_counter_type2 ="+reject_receipt_counter_type2DbString);
qry.Append(",");
}

if ( reject_receipt_counter_type3Changed )
{
qry.Append("reject_receipt_counter_type3 ="+reject_receipt_counter_type3DbString);
qry.Append(",");
}

if ( reject_receipt_counter_type4Changed )
{
qry.Append("reject_receipt_counter_type4 ="+reject_receipt_counter_type4DbString);
qry.Append(",");
}

if ( physical_reject_counter_type1Changed )
{
qry.Append("physical_reject_counter_type1 ="+physical_reject_counter_type1DbString);
qry.Append(",");
}

if ( physical_reject_counter_type2Changed )
{
qry.Append("physical_reject_counter_type2 ="+physical_reject_counter_type2DbString);
qry.Append(",");
}

if ( physical_reject_counter_type3Changed )
{
qry.Append("physical_reject_counter_type3 ="+physical_reject_counter_type3DbString);
qry.Append(",");
}

if ( physical_reject_counter_type4Changed )
{
qry.Append("physical_reject_counter_type4 ="+physical_reject_counter_type4DbString);
qry.Append(",");
}

if ( actual_problem_foundChanged )
{
qry.Append("actual_problem_found ="+actual_problem_foundDbString);
qry.Append(",");
}

if ( action_takenChanged )
{
qry.Append("action_taken ="+action_takenDbString);
qry.Append(",");
}

if ( bna_jammed_counterChanged )
{
qry.Append("bna_jammed_counter ="+bna_jammed_counterDbString);
qry.Append(",");
}

if ( te_bag_no_and_countChanged )
{
qry.Append("te_bag_no_and_count ="+te_bag_no_and_countDbString);
qry.Append(",");
}

if ( time_of_call_to_bankChanged )
{
qry.Append("time_of_call_to_bank ="+time_of_call_to_bankDbString);
qry.Append(",");
}

if ( snoChanged )
{
qry.Append("sno ="+snoDbString);
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

if ( type_of_callChanged )
{
qry.Append("type_of_call ="+type_of_callDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("flm_monitoring_id = "+flm_monitoring_idDbString);
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
cmd.CommandText = "DELETE Flm_monitoring where flm_monitoring_id = "+ flm_monitoring_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteFlmMonitorings(string where)
{
ConnectionFactory.ExecuteQuery("delete Flm_monitoring where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
flm_monitoring_id= 1,
activity_datetime= 2,
ticket_number= 4,
log= 8,
call_reported_by= 16,
atm_id_no= 32,
atm_location= 64,
type_of_problem= 128,
code= 256,
info_passed_to= 512,
time_of_info= 1024,
time_of_reaching_site= 2048,
time_of_solving= 4096,
attended_by= 8192,
reject_receipt_counter_type1= 16384,
reject_receipt_counter_type2= 32768,
reject_receipt_counter_type3= 65536,
reject_receipt_counter_type4= 131072,
physical_reject_counter_type1= 262144,
physical_reject_counter_type2= 524288,
physical_reject_counter_type3= 1048576,
physical_reject_counter_type4= 2097152,
actual_problem_found= 4194304,
action_taken= 8388608,
bna_jammed_counter= 16777216,
te_bag_no_and_count= 33554432,
time_of_call_to_bank= 67108864,
sno= 134217728,
uploaded_by= 268435456,
upload_datetime= 536870912,
type_of_call= 1073741824
}
#endregion
public void BulkSave(List<FlmMonitoring> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Flm_monitoring";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(FlmMonitoring.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <FlmMonitoring> transList,ref DataTable dt)
{
foreach (FlmMonitoring tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["flm_monitoring_id"] =ConnectionFactory.GetNextId();
Row["activity_datetime"] = tran.ActivityDatetime;
Row["ticket_number"] = tran.TicketNumber;
Row["log"] = tran.Log;
Row["call_reported_by"] = tran.CallReportedBy;
Row["atm_id_no"] = tran.AtmIdNo;
Row["atm_location"] = tran.AtmLocation;
Row["type_of_problem"] = tran.TypeOfProblem;
Row["code"] = tran.Code;
Row["info_passed_to"] = tran.InfoPassedTo;
Row["time_of_info"] = tran.TimeOfInfo;
Row["time_of_reaching_site"] = tran.TimeOfReachingSite;
Row["time_of_solving"] = tran.TimeOfSolving;
Row["attended_by"] = tran.AttendedBy;
Row["reject_receipt_counter_type1"] = tran.RejectReceiptCounterType1;
Row["reject_receipt_counter_type2"] = tran.RejectReceiptCounterType2;
Row["reject_receipt_counter_type3"] = tran.RejectReceiptCounterType3;
Row["reject_receipt_counter_type4"] = tran.RejectReceiptCounterType4;
Row["physical_reject_counter_type1"] = tran.PhysicalRejectCounterType1;
Row["physical_reject_counter_type2"] = tran.PhysicalRejectCounterType2;
Row["physical_reject_counter_type3"] = tran.PhysicalRejectCounterType3;
Row["physical_reject_counter_type4"] = tran.PhysicalRejectCounterType4;
Row["actual_problem_found"] = tran.ActualProblemFound;
Row["action_taken"] = tran.ActionTaken;
Row["bna_jammed_counter"] = tran.BnaJammedCounter;
Row["te_bag_no_and_count"] = tran.TeBagNoAndCount;
Row["time_of_call_to_bank"] = tran.TimeOfCallToBank;
Row["sno"] = tran.Sno;
Row["uploaded_by"] = tran.UploadedBy;
Row["upload_datetime"] = tran.UploadDatetime;
Row["type_of_call"] = tran.TypeOfCall;
dt.Rows.Add(Row);
} }
}
}
