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
public class CcmslongegratedAlert
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmslongegratedAlert() { }
public CcmslongegratedAlert( long id,bool generate_notification_sent,bool resolve_notification_sent ) 
{
this.generate_notification_sent = generate_notification_sent;
this.generate_notification_sentChanged = true;
this.resolve_notification_sent = resolve_notification_sent;
this.resolve_notification_sentChanged = true;
}
public CcmslongegratedAlert( long? alert_type_id,string alert_type,long? entity_id,string entity_type,string alert_level,string alert_status,DateTime? generated_at,string alert_text,DateTime? expiration_time,long? generate_retry_remaining,long? resolve_retry_remaining,DateTime? last_invoked_at,string module_type,long? ftp_file_info_id,string failure_reason,string alert_resolution_text,long? organization_id,DateTime? resolved_at,bool generate_notification_sent,bool resolve_notification_sent,long? atm_id,long? atm_alert_id,long? event_count )
{
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.alert_type = alert_type;
this.alert_typeChanged = true;
this.entity_id = entity_id;
this.entity_idChanged = true;
this.entity_type = entity_type;
this.entity_typeChanged = true;
this.alert_level = alert_level;
this.alert_levelChanged = true;
this.alert_status = alert_status;
this.alert_statusChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.alert_text = alert_text;
this.alert_textChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
this.generate_retry_remaining = generate_retry_remaining;
this.generate_retry_remainingChanged = true;
this.resolve_retry_remaining = resolve_retry_remaining;
this.resolve_retry_remainingChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.module_type = module_type;
this.module_typeChanged = true;
this.ftp_file_info_id = ftp_file_info_id;
this.ftp_file_info_idChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.alert_resolution_text = alert_resolution_text;
this.alert_resolution_textChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.resolved_at = resolved_at;
this.resolved_atChanged = true;
this.generate_notification_sent = generate_notification_sent;
this.generate_notification_sentChanged = true;
this.resolve_notification_sent = resolve_notification_sent;
this.resolve_notification_sentChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.atm_alert_id = atm_alert_id;
this.atm_alert_idChanged = true;
this.event_count = event_count;
this.event_countChanged = true;
}
private CcmslongegratedAlert( long id,long? alert_type_id,string alert_type,long? entity_id,string entity_type,string alert_level,string alert_status,DateTime? generated_at,string alert_text,DateTime? expiration_time,long? generate_retry_remaining,long? resolve_retry_remaining,DateTime? last_invoked_at,string module_type,long? ftp_file_info_id,string failure_reason,string alert_resolution_text,long? organization_id,DateTime? resolved_at,bool generate_notification_sent,bool resolve_notification_sent,long? atm_id,long? atm_alert_id,long? event_count )
{
this.id = id;
this.idChanged = true;
this.alert_type_id = alert_type_id;
this.alert_type_idChanged = true;
this.alert_type = alert_type;
this.alert_typeChanged = true;
this.entity_id = entity_id;
this.entity_idChanged = true;
this.entity_type = entity_type;
this.entity_typeChanged = true;
this.alert_level = alert_level;
this.alert_levelChanged = true;
this.alert_status = alert_status;
this.alert_statusChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.alert_text = alert_text;
this.alert_textChanged = true;
this.expiration_time = expiration_time;
this.expiration_timeChanged = true;
this.generate_retry_remaining = generate_retry_remaining;
this.generate_retry_remainingChanged = true;
this.resolve_retry_remaining = resolve_retry_remaining;
this.resolve_retry_remainingChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.module_type = module_type;
this.module_typeChanged = true;
this.ftp_file_info_id = ftp_file_info_id;
this.ftp_file_info_idChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.alert_resolution_text = alert_resolution_text;
this.alert_resolution_textChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.resolved_at = resolved_at;
this.resolved_atChanged = true;
this.generate_notification_sent = generate_notification_sent;
this.generate_notification_sentChanged = true;
this.resolve_notification_sent = resolve_notification_sent;
this.resolve_notification_sentChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.atm_alert_id = atm_alert_id;
this.atm_alert_idChanged = true;
this.event_count = event_count;
this.event_countChanged = true;
}

#region members and properties for columns

#region Id
private bool idChanged = false;
private long id;
public long Id
{
get { return id; }
set { 
id = value;
idChanged = true;
}
}
private string idDbString
{
get
{
return id.ToString();
}
}
#endregion
#region AlertTypeId
private bool alert_type_idChanged = false;
private long? alert_type_id;
public long? AlertTypeId
{
get { return alert_type_id; }
set { 
alert_type_id = value;
alert_type_idChanged = true;
}
}
private string alert_type_idDbString
{
get
{
if (this.alert_type_id.HasValue)
return alert_type_id.ToString();
else
return "null";
}
}
#endregion
#region AlertType
private bool alert_typeChanged = false;
private string alert_type;
public string AlertType
{
get { return alert_type; }
set { 
alert_type = value;
alert_typeChanged = true;
}
}
private string alert_typeDbString
{
get
{
if (this.alert_type!=null)
return string.Format("'{0}'",alert_type); else
return "null";
}
}
#endregion
#region EntityId
private bool entity_idChanged = false;
private long? entity_id;
public long? EntityId
{
get { return entity_id; }
set { 
entity_id = value;
entity_idChanged = true;
}
}
private string entity_idDbString
{
get
{
if (this.entity_id.HasValue)
return entity_id.ToString();
else
return "null";
}
}
#endregion
#region EntityType
private bool entity_typeChanged = false;
private string entity_type;
public string EntityType
{
get { return entity_type; }
set { 
entity_type = value;
entity_typeChanged = true;
}
}
private string entity_typeDbString
{
get
{
if (this.entity_type!=null)
return string.Format("'{0}'",entity_type); else
return "null";
}
}
#endregion
#region AlertLevel
private bool alert_levelChanged = false;
private string alert_level;
public string AlertLevel
{
get { return alert_level; }
set { 
alert_level = value;
alert_levelChanged = true;
}
}
private string alert_levelDbString
{
get
{
if (this.alert_level!=null)
return string.Format("'{0}'",alert_level); else
return "null";
}
}
#endregion
#region AlertStatus
private bool alert_statusChanged = false;
private string alert_status;
public string AlertStatus
{
get { return alert_status; }
set { 
alert_status = value;
alert_statusChanged = true;
}
}
private string alert_statusDbString
{
get
{
if (this.alert_status!=null)
return string.Format("'{0}'",alert_status); else
return "null";
}
}
#endregion
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime? generated_at;
public DateTime? GeneratedAt
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
if (this.generated_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",generated_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region AlertText
private bool alert_textChanged = false;
private string alert_text;
public string AlertText
{
get { return alert_text; }
set { 
alert_text = value;
alert_textChanged = true;
}
}
private string alert_textDbString
{
get
{
if (this.alert_text!=null)
return string.Format("'{0}'",alert_text); else
return "null";
}
}
#endregion
#region ExpirationTime
private bool expiration_timeChanged = false;
private DateTime? expiration_time;
public DateTime? ExpirationTime
{
get { return expiration_time; }
set { 
expiration_time = value;
expiration_timeChanged = true;
}
}
private string expiration_timeDbString
{
get
{
if (this.expiration_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",expiration_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region GenerateRetryRemaining
private bool generate_retry_remainingChanged = false;
private long? generate_retry_remaining;
public long? GenerateRetryRemaining
{
get { return generate_retry_remaining; }
set { 
generate_retry_remaining = value;
generate_retry_remainingChanged = true;
}
}
private string generate_retry_remainingDbString
{
get
{
if (this.generate_retry_remaining.HasValue)
return generate_retry_remaining.ToString();
else
return "null";
}
}
#endregion
#region ResolveRetryRemaining
private bool resolve_retry_remainingChanged = false;
private long? resolve_retry_remaining;
public long? ResolveRetryRemaining
{
get { return resolve_retry_remaining; }
set { 
resolve_retry_remaining = value;
resolve_retry_remainingChanged = true;
}
}
private string resolve_retry_remainingDbString
{
get
{
if (this.resolve_retry_remaining.HasValue)
return resolve_retry_remaining.ToString();
else
return "null";
}
}
#endregion
#region LastInvokedAt
private bool last_invoked_atChanged = false;
private DateTime? last_invoked_at;
public DateTime? LastInvokedAt
{
get { return last_invoked_at; }
set { 
last_invoked_at = value;
last_invoked_atChanged = true;
}
}
private string last_invoked_atDbString
{
get
{
if (this.last_invoked_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",last_invoked_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ModuleType
private bool module_typeChanged = false;
private string module_type;
public string ModuleType
{
get { return module_type; }
set { 
module_type = value;
module_typeChanged = true;
}
}
private string module_typeDbString
{
get
{
if (this.module_type!=null)
return string.Format("'{0}'",module_type); else
return "null";
}
}
#endregion
#region FtpFileInfoId
private bool ftp_file_info_idChanged = false;
private long? ftp_file_info_id;
public long? FtpFileInfoId
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
#region FailureReason
private bool failure_reasonChanged = false;
private string failure_reason;
public string FailureReason
{
get { return failure_reason; }
set { 
failure_reason = value;
failure_reasonChanged = true;
}
}
private string failure_reasonDbString
{
get
{
if (this.failure_reason!=null)
return string.Format("'{0}'",failure_reason); else
return "null";
}
}
#endregion
#region AlertResolutionText
private bool alert_resolution_textChanged = false;
private string alert_resolution_text;
public string AlertResolutionText
{
get { return alert_resolution_text; }
set { 
alert_resolution_text = value;
alert_resolution_textChanged = true;
}
}
private string alert_resolution_textDbString
{
get
{
if (this.alert_resolution_text!=null)
return string.Format("'{0}'",alert_resolution_text); else
return "null";
}
}
#endregion
#region OrganizationId
private bool organization_idChanged = false;
private long? organization_id;
public long? OrganizationId
{
get { return organization_id; }
set { 
organization_id = value;
organization_idChanged = true;
}
}
private string organization_idDbString
{
get
{
if (this.organization_id.HasValue)
return organization_id.ToString();
else
return "null";
}
}
#endregion
#region ResolvedAt
private bool resolved_atChanged = false;
private DateTime? resolved_at;
public DateTime? ResolvedAt
{
get { return resolved_at; }
set { 
resolved_at = value;
resolved_atChanged = true;
}
}
private string resolved_atDbString
{
get
{
if (this.resolved_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",resolved_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region GenerateNotificationSent
private bool generate_notification_sentChanged = false;
private bool generate_notification_sent;
public bool GenerateNotificationSent
{
get { return generate_notification_sent; }
set { 
generate_notification_sent = value;
generate_notification_sentChanged = true;
}
}
private string generate_notification_sentDbString
{
get
{
return generate_notification_sent?"1":"0";
}
}
#endregion
#region ResolveNotificationSent
private bool resolve_notification_sentChanged = false;
private bool resolve_notification_sent;
public bool ResolveNotificationSent
{
get { return resolve_notification_sent; }
set { 
resolve_notification_sent = value;
resolve_notification_sentChanged = true;
}
}
private string resolve_notification_sentDbString
{
get
{
return resolve_notification_sent?"1":"0";
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private long? atm_id;
public long? AtmId
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
#region AtmAlertId
private bool atm_alert_idChanged = false;
private long? atm_alert_id;
public long? AtmAlertId
{
get { return atm_alert_id; }
set { 
atm_alert_id = value;
atm_alert_idChanged = true;
}
}
private string atm_alert_idDbString
{
get
{
if (this.atm_alert_id.HasValue)
return atm_alert_id.ToString();
else
return "null";
}
}
#endregion
#region EventCount
private bool event_countChanged = false;
private long? event_count;
public long? EventCount
{
get { return event_count; }
set { 
event_count = value;
event_countChanged = true;
}
}
private string event_countDbString
{
get
{
if (this.event_count.HasValue)
return event_count.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmslongegratedAlertReader
public class CcmslongegratedAlertReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmslongegratedAlert currentCcmslongegratedAlert;
Columns columns;
bool partialRead = false;
private CcmslongegratedAlertReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmslongegratedAlertReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmslongegratedAlertReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmslongegratedAlert; }

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
currentCcmslongegratedAlert = new CcmslongegratedAlert();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmslongegratedAlert.id =(long) reader["id"]; 
if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"]!=DBNull.Value)
currentCcmslongegratedAlert.alert_type_id =(long?) reader["alert_type_id"]; 
if ((columns & Columns.alert_type) == Columns.alert_type && reader["alert_type"]!=DBNull.Value)
currentCcmslongegratedAlert.alert_type =(string) reader["alert_type"]; 
if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"]!=DBNull.Value)
currentCcmslongegratedAlert.entity_id =(long?) reader["entity_id"]; 
if ((columns & Columns.entity_type) == Columns.entity_type && reader["entity_type"]!=DBNull.Value)
currentCcmslongegratedAlert.entity_type =(string) reader["entity_type"]; 
if ((columns & Columns.alert_level) == Columns.alert_level && reader["alert_level"]!=DBNull.Value)
currentCcmslongegratedAlert.alert_level =(string) reader["alert_level"]; 
if ((columns & Columns.alert_status) == Columns.alert_status && reader["alert_status"]!=DBNull.Value)
currentCcmslongegratedAlert.alert_status =(string) reader["alert_status"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentCcmslongegratedAlert.generated_at =(DateTime?) reader["generated_at"]; 
if ((columns & Columns.alert_text) == Columns.alert_text && reader["alert_text"]!=DBNull.Value)
currentCcmslongegratedAlert.alert_text =(string) reader["alert_text"]; 
if ((columns & Columns.expiration_time) == Columns.expiration_time && reader["expiration_time"]!=DBNull.Value)
currentCcmslongegratedAlert.expiration_time =(DateTime?) reader["expiration_time"]; 
if ((columns & Columns.generate_retry_remaining) == Columns.generate_retry_remaining && reader["generate_retry_remaining"]!=DBNull.Value)
currentCcmslongegratedAlert.generate_retry_remaining =(long?) reader["generate_retry_remaining"]; 
if ((columns & Columns.resolve_retry_remaining) == Columns.resolve_retry_remaining && reader["resolve_retry_remaining"]!=DBNull.Value)
currentCcmslongegratedAlert.resolve_retry_remaining =(long?) reader["resolve_retry_remaining"]; 
if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"]!=DBNull.Value)
currentCcmslongegratedAlert.last_invoked_at =(DateTime?) reader["last_invoked_at"]; 
if ((columns & Columns.module_type) == Columns.module_type && reader["module_type"]!=DBNull.Value)
currentCcmslongegratedAlert.module_type =(string) reader["module_type"]; 
if ((columns & Columns.ftp_file_info_id) == Columns.ftp_file_info_id && reader["ftp_file_info_id"]!=DBNull.Value)
currentCcmslongegratedAlert.ftp_file_info_id =(long?) reader["ftp_file_info_id"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentCcmslongegratedAlert.failure_reason =(string) reader["failure_reason"]; 
if ((columns & Columns.alert_resolution_text) == Columns.alert_resolution_text && reader["alert_resolution_text"]!=DBNull.Value)
currentCcmslongegratedAlert.alert_resolution_text =(string) reader["alert_resolution_text"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmslongegratedAlert.organization_id =(long?) reader["organization_id"]; 
if ((columns & Columns.resolved_at) == Columns.resolved_at && reader["resolved_at"]!=DBNull.Value)
currentCcmslongegratedAlert.resolved_at =(DateTime?) reader["resolved_at"]; 
if ((columns & Columns.generate_notification_sent) == Columns.generate_notification_sent && reader["generate_notification_sent"]!=DBNull.Value)
currentCcmslongegratedAlert.generate_notification_sent =(bool) reader["generate_notification_sent"]; 
if ((columns & Columns.resolve_notification_sent) == Columns.resolve_notification_sent && reader["resolve_notification_sent"]!=DBNull.Value)
currentCcmslongegratedAlert.resolve_notification_sent =(bool) reader["resolve_notification_sent"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCcmslongegratedAlert.atm_id =(long?) reader["atm_id"]; 
if ((columns & Columns.atm_alert_id) == Columns.atm_alert_id && reader["atm_alert_id"]!=DBNull.Value)
currentCcmslongegratedAlert.atm_alert_id =(long?) reader["atm_alert_id"]; 
if ((columns & Columns.event_count) == Columns.event_count && reader["event_count"]!=DBNull.Value)
currentCcmslongegratedAlert.event_count =(long?) reader["event_count"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmslongegratedAlert.id = (long) reader["id"]; 
if (reader["alert_type_id"] != DBNull.Value)
currentCcmslongegratedAlert.alert_type_id = (long?) reader["alert_type_id"]; 
if (reader["alert_type"] != DBNull.Value)
currentCcmslongegratedAlert.alert_type = (string) reader["alert_type"]; 
if (reader["entity_id"] != DBNull.Value)
currentCcmslongegratedAlert.entity_id = (long?) reader["entity_id"]; 
if (reader["entity_type"] != DBNull.Value)
currentCcmslongegratedAlert.entity_type = (string) reader["entity_type"]; 
if (reader["alert_level"] != DBNull.Value)
currentCcmslongegratedAlert.alert_level = (string) reader["alert_level"]; 
if (reader["alert_status"] != DBNull.Value)
currentCcmslongegratedAlert.alert_status = (string) reader["alert_status"]; 
if (reader["generated_at"] != DBNull.Value)
currentCcmslongegratedAlert.generated_at = (DateTime?) reader["generated_at"]; 
if (reader["alert_text"] != DBNull.Value)
currentCcmslongegratedAlert.alert_text = (string) reader["alert_text"]; 
if (reader["expiration_time"] != DBNull.Value)
currentCcmslongegratedAlert.expiration_time = (DateTime?) reader["expiration_time"]; 
if (reader["generate_retry_remaining"] != DBNull.Value)
currentCcmslongegratedAlert.generate_retry_remaining = (long?) reader["generate_retry_remaining"]; 
if (reader["resolve_retry_remaining"] != DBNull.Value)
currentCcmslongegratedAlert.resolve_retry_remaining = (long?) reader["resolve_retry_remaining"]; 
if (reader["last_invoked_at"] != DBNull.Value)
currentCcmslongegratedAlert.last_invoked_at = (DateTime?) reader["last_invoked_at"]; 
if (reader["module_type"] != DBNull.Value)
currentCcmslongegratedAlert.module_type = (string) reader["module_type"]; 
if (reader["ftp_file_info_id"] != DBNull.Value)
currentCcmslongegratedAlert.ftp_file_info_id = (long?) reader["ftp_file_info_id"]; 
if (reader["failure_reason"] != DBNull.Value)
currentCcmslongegratedAlert.failure_reason = (string) reader["failure_reason"]; 
if (reader["alert_resolution_text"] != DBNull.Value)
currentCcmslongegratedAlert.alert_resolution_text = (string) reader["alert_resolution_text"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmslongegratedAlert.organization_id = (long?) reader["organization_id"]; 
if (reader["resolved_at"] != DBNull.Value)
currentCcmslongegratedAlert.resolved_at = (DateTime?) reader["resolved_at"]; 
if (reader["generate_notification_sent"] != DBNull.Value)
currentCcmslongegratedAlert.generate_notification_sent = (bool) reader["generate_notification_sent"]; 
if (reader["resolve_notification_sent"] != DBNull.Value)
currentCcmslongegratedAlert.resolve_notification_sent = (bool) reader["resolve_notification_sent"]; 
if (reader["atm_id"] != DBNull.Value)
currentCcmslongegratedAlert.atm_id = (long?) reader["atm_id"]; 
if (reader["atm_alert_id"] != DBNull.Value)
currentCcmslongegratedAlert.atm_alert_id = (long?) reader["atm_alert_id"]; 
if (reader["event_count"] != DBNull.Value)
currentCcmslongegratedAlert.event_count = (long?) reader["event_count"]; 
} 

currentCcmslongegratedAlert.isNewEntity = false;
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

public CcmslongegratedAlert CurrentCcmslongegratedAlert
{
get{ return currentCcmslongegratedAlert; }
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


#region CcmslongegratedAlert functions

public static CcmslongegratedAlertReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.alert_type_id == (Columns.alert_type_id & columns))
qry.Append("alert_type_id,");
if (Columns.alert_type == (Columns.alert_type & columns))
qry.Append("alert_type,");
if (Columns.entity_id == (Columns.entity_id & columns))
qry.Append("entity_id,");
if (Columns.entity_type == (Columns.entity_type & columns))
qry.Append("entity_type,");
if (Columns.alert_level == (Columns.alert_level & columns))
qry.Append("alert_level,");
if (Columns.alert_status == (Columns.alert_status & columns))
qry.Append("alert_status,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.alert_text == (Columns.alert_text & columns))
qry.Append("alert_text,");
if (Columns.expiration_time == (Columns.expiration_time & columns))
qry.Append("expiration_time,");
if (Columns.generate_retry_remaining == (Columns.generate_retry_remaining & columns))
qry.Append("generate_retry_remaining,");
if (Columns.resolve_retry_remaining == (Columns.resolve_retry_remaining & columns))
qry.Append("resolve_retry_remaining,");
if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
qry.Append("last_invoked_at,");
if (Columns.module_type == (Columns.module_type & columns))
qry.Append("module_type,");
if (Columns.ftp_file_info_id == (Columns.ftp_file_info_id & columns))
qry.Append("ftp_file_info_id,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
if (Columns.alert_resolution_text == (Columns.alert_resolution_text & columns))
qry.Append("alert_resolution_text,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.resolved_at == (Columns.resolved_at & columns))
qry.Append("resolved_at,");
if (Columns.generate_notification_sent == (Columns.generate_notification_sent & columns))
qry.Append("generate_notification_sent,");
if (Columns.resolve_notification_sent == (Columns.resolve_notification_sent & columns))
qry.Append("resolve_notification_sent,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.atm_alert_id == (Columns.atm_alert_id & columns))
qry.Append("atm_alert_id,");
if (Columns.event_count == (Columns.event_count & columns))
qry.Append("event_count,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_longegrated_alert ");

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
return new CcmslongegratedAlertReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmslongegratedAlertReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmslongegratedAlertReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,alert_type_id,alert_type,entity_id,entity_type,alert_level,alert_status,generated_at,alert_text,expiration_time,generate_retry_remaining,resolve_retry_remaining,last_invoked_at,module_type,ftp_file_info_id,failure_reason,alert_resolution_text,organization_id,resolved_at,generate_notification_sent,resolve_notification_sent,atm_id,atm_alert_id,event_count from Ccms_longegrated_alert ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmslongegratedAlertReader(cmd.ExecuteReader(), conn);
}

static public CcmslongegratedAlertReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmslongegratedAlert LoadCcmslongegratedAlert(string where)
{
CcmslongegratedAlertReader reader = CcmslongegratedAlert.ExecuteReader(where);
CcmslongegratedAlert _ccmslongegratedalert = null;
if (reader.Read())
_ccmslongegratedalert = reader.CurrentCcmslongegratedAlert;
reader.Close();
return _ccmslongegratedalert;
}

public static CcmslongegratedAlert LoadCcmslongegratedAlert(string where, IDbConnection conn)
{
CcmslongegratedAlertReader reader = CcmslongegratedAlert.ExecuteReader(where, conn);
CcmslongegratedAlert _ccmslongegratedalert = null;
if (reader.Read())
_ccmslongegratedalert = reader.CurrentCcmslongegratedAlert;
reader.Close(false);
return _ccmslongegratedalert;
}

public static CcmslongegratedAlert LoadCcmslongegratedAlertByPk( long id )
{
return LoadCcmslongegratedAlert( " id="+id );
}

public static CcmslongegratedAlert LoadCcmslongegratedAlertByPk( long id , IDbConnection conn)
{
return LoadCcmslongegratedAlert(" id="+id , conn);
}

public void Save()
{
if (idChanged || alert_type_idChanged || alert_typeChanged || entity_idChanged || entity_typeChanged || alert_levelChanged || alert_statusChanged || generated_atChanged || alert_textChanged || expiration_timeChanged || generate_retry_remainingChanged || resolve_retry_remainingChanged || last_invoked_atChanged || module_typeChanged || ftp_file_info_idChanged || failure_reasonChanged || alert_resolution_textChanged || organization_idChanged || resolved_atChanged || generate_notification_sentChanged || resolve_notification_sentChanged || atm_idChanged || atm_alert_idChanged || event_countChanged )
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
if (idChanged || alert_type_idChanged || alert_typeChanged || entity_idChanged || entity_typeChanged || alert_levelChanged || alert_statusChanged || generated_atChanged || alert_textChanged || expiration_timeChanged || generate_retry_remainingChanged || resolve_retry_remainingChanged || last_invoked_atChanged || module_typeChanged || ftp_file_info_idChanged || failure_reasonChanged || alert_resolution_textChanged || organization_idChanged || resolved_atChanged || generate_notification_sentChanged || resolve_notification_sentChanged || atm_idChanged || atm_alert_idChanged || event_countChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_longegrated_alert( id,alert_type_id,alert_type,entity_id,entity_type,alert_level,alert_status,generated_at,alert_text,expiration_time,generate_retry_remaining,resolve_retry_remaining,last_invoked_at,module_type,ftp_file_info_id,failure_reason,alert_resolution_text,organization_id,resolved_at,generate_notification_sent,resolve_notification_sent,atm_id,atm_alert_id,event_count ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(alert_type_idDbString+",");
qry.Append(alert_typeDbString+",");
qry.Append(entity_idDbString+",");
qry.Append(entity_typeDbString+",");
qry.Append(alert_levelDbString+",");
qry.Append(alert_statusDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(alert_textDbString+",");
qry.Append(expiration_timeDbString+",");
qry.Append(generate_retry_remainingDbString+",");
qry.Append(resolve_retry_remainingDbString+",");
qry.Append(last_invoked_atDbString+",");
qry.Append(module_typeDbString+",");
qry.Append(ftp_file_info_idDbString+",");
qry.Append(failure_reasonDbString+",");
qry.Append(alert_resolution_textDbString+",");
qry.Append(organization_idDbString+",");
qry.Append(resolved_atDbString+",");
qry.Append(generate_notification_sentDbString+",");
qry.Append(resolve_notification_sentDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(atm_alert_idDbString+",");
qry.Append(event_countDbString);
qry.Append(");");

}
else
{
if (!(idChanged || alert_type_idChanged || alert_typeChanged || entity_idChanged || entity_typeChanged || alert_levelChanged || alert_statusChanged || generated_atChanged || alert_textChanged || expiration_timeChanged || generate_retry_remainingChanged || resolve_retry_remainingChanged || last_invoked_atChanged || module_typeChanged || ftp_file_info_idChanged || failure_reasonChanged || alert_resolution_textChanged || organization_idChanged || resolved_atChanged || generate_notification_sentChanged || resolve_notification_sentChanged || atm_idChanged || atm_alert_idChanged || event_countChanged ))
return;
qry.Append("UPDATE Ccms_longegrated_alert set "); if ( alert_type_idChanged )
{
qry.Append("alert_type_id ="+alert_type_idDbString);
qry.Append(",");
}

if ( alert_typeChanged )
{
qry.Append("alert_type ="+alert_typeDbString);
qry.Append(",");
}

if ( entity_idChanged )
{
qry.Append("entity_id ="+entity_idDbString);
qry.Append(",");
}

if ( entity_typeChanged )
{
qry.Append("entity_type ="+entity_typeDbString);
qry.Append(",");
}

if ( alert_levelChanged )
{
qry.Append("alert_level ="+alert_levelDbString);
qry.Append(",");
}

if ( alert_statusChanged )
{
qry.Append("alert_status ="+alert_statusDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( alert_textChanged )
{
qry.Append("alert_text ="+alert_textDbString);
qry.Append(",");
}

if ( expiration_timeChanged )
{
qry.Append("expiration_time ="+expiration_timeDbString);
qry.Append(",");
}

if ( generate_retry_remainingChanged )
{
qry.Append("generate_retry_remaining ="+generate_retry_remainingDbString);
qry.Append(",");
}

if ( resolve_retry_remainingChanged )
{
qry.Append("resolve_retry_remaining ="+resolve_retry_remainingDbString);
qry.Append(",");
}

if ( last_invoked_atChanged )
{
qry.Append("last_invoked_at ="+last_invoked_atDbString);
qry.Append(",");
}

if ( module_typeChanged )
{
qry.Append("module_type ="+module_typeDbString);
qry.Append(",");
}

if ( ftp_file_info_idChanged )
{
qry.Append("ftp_file_info_id ="+ftp_file_info_idDbString);
qry.Append(",");
}

if ( failure_reasonChanged )
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}

if ( alert_resolution_textChanged )
{
qry.Append("alert_resolution_text ="+alert_resolution_textDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( resolved_atChanged )
{
qry.Append("resolved_at ="+resolved_atDbString);
qry.Append(",");
}

if ( generate_notification_sentChanged )
{
qry.Append("generate_notification_sent ="+generate_notification_sentDbString);
qry.Append(",");
}

if ( resolve_notification_sentChanged )
{
qry.Append("resolve_notification_sent ="+resolve_notification_sentDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( atm_alert_idChanged )
{
qry.Append("atm_alert_id ="+atm_alert_idDbString);
qry.Append(",");
}

if ( event_countChanged )
{
qry.Append("event_count ="+event_countDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("id = "+idDbString);
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
cmd.CommandText = "DELETE Ccms_longegrated_alert where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmslongegratedAlerts(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_longegrated_alert where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
alert_type_id= 2,
alert_type= 4,
entity_id= 8,
entity_type= 16,
alert_level= 32,
alert_status= 64,
generated_at= 128,
alert_text= 256,
expiration_time= 512,
generate_retry_remaining= 1024,
resolve_retry_remaining= 2048,
last_invoked_at= 4096,
module_type= 8192,
ftp_file_info_id= 16384,
failure_reason= 32768,
alert_resolution_text= 65536,
organization_id= 131072,
resolved_at= 262144,
generate_notification_sent= 524288,
resolve_notification_sent= 1048576,
atm_id= 2097152,
atm_alert_id= 4194304,
event_count= 8388608
}
#endregion
public void BulkSave(List<CcmslongegratedAlert> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_longegrated_alert";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmslongegratedAlert.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmslongegratedAlert> transList,ref DataTable dt)
{
foreach (CcmslongegratedAlert tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["alert_type_id"] = tran.AlertTypeId;
Row["alert_type"] = tran.AlertType;
Row["entity_id"] = tran.EntityId;
Row["entity_type"] = tran.EntityType;
Row["alert_level"] = tran.AlertLevel;
Row["alert_status"] = tran.AlertStatus;
Row["generated_at"] = tran.GeneratedAt;
Row["alert_text"] = tran.AlertText;
Row["expiration_time"] = tran.ExpirationTime;
Row["generate_retry_remaining"] = tran.GenerateRetryRemaining;
Row["resolve_retry_remaining"] = tran.ResolveRetryRemaining;
Row["last_invoked_at"] = tran.LastInvokedAt;
Row["module_type"] = tran.ModuleType;
Row["ftp_file_info_id"] = tran.FtpFileInfoId;
Row["failure_reason"] = tran.FailureReason;
Row["alert_resolution_text"] = tran.AlertResolutionText;
Row["organization_id"] = tran.OrganizationId;
Row["resolved_at"] = tran.ResolvedAt;
Row["generate_notification_sent"] = tran.GenerateNotificationSent;
Row["resolve_notification_sent"] = tran.ResolveNotificationSent;
Row["atm_id"] = tran.AtmId;
Row["atm_alert_id"] = tran.AtmAlertId;
Row["event_count"] = tran.EventCount;
dt.Rows.Add(Row);
} }
}
}
