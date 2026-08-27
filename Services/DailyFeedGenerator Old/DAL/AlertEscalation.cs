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
public class AlertEscalation
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AlertEscalation() { }
public AlertEscalation( int alert_escalation_id,int alert_template_id,int severity_id ) 
{
this.alert_template_id = alert_template_id;
this.alert_template_idChanged = true;
this.severity_id = severity_id;
this.severity_idChanged = true;
}
public AlertEscalation( int alert_template_id,int severity_id,int? level0_duration,int? level1_duration,int? level2_duration,int? level3_duration,int? level4_duration,byte? level1_notification_count,byte? level2_notification_count,byte? level3_notification_count,byte? level4_notification_count,byte? level5_notification_count,int? level1_reminder_interval,int? level2_reminder_interval,int? level3_reminder_interval,int? level4_reminder_interval,int? level5_reminder_interval,bool? level1_email_enabled,bool? level1_sms_enabled,bool? level1_fax_enabled,bool? level2_email_enabled,bool? level2_sms_enabled,bool? level2_fax_enabled,bool? level3_email_enabled,bool? level3_sms_enabled,bool? level3_fax_enabled,bool? level4_email_enabled,bool? level4_sms_enabled,bool? level4_fax_enabled,bool? level5_email_enabled,bool? level5_sms_enabled,bool? level5_fax_enabled )
{
this.alert_template_id = alert_template_id;
this.alert_template_idChanged = true;
this.severity_id = severity_id;
this.severity_idChanged = true;
this.level0_duration = level0_duration;
this.level0_durationChanged = true;
this.level1_duration = level1_duration;
this.level1_durationChanged = true;
this.level2_duration = level2_duration;
this.level2_durationChanged = true;
this.level3_duration = level3_duration;
this.level3_durationChanged = true;
this.level4_duration = level4_duration;
this.level4_durationChanged = true;
this.level1_notification_count = level1_notification_count;
this.level1_notification_countChanged = true;
this.level2_notification_count = level2_notification_count;
this.level2_notification_countChanged = true;
this.level3_notification_count = level3_notification_count;
this.level3_notification_countChanged = true;
this.level4_notification_count = level4_notification_count;
this.level4_notification_countChanged = true;
this.level5_notification_count = level5_notification_count;
this.level5_notification_countChanged = true;
this.level1_reminder_interval = level1_reminder_interval;
this.level1_reminder_intervalChanged = true;
this.level2_reminder_interval = level2_reminder_interval;
this.level2_reminder_intervalChanged = true;
this.level3_reminder_interval = level3_reminder_interval;
this.level3_reminder_intervalChanged = true;
this.level4_reminder_interval = level4_reminder_interval;
this.level4_reminder_intervalChanged = true;
this.level5_reminder_interval = level5_reminder_interval;
this.level5_reminder_intervalChanged = true;
this.level1_email_enabled = level1_email_enabled;
this.level1_email_enabledChanged = true;
this.level1_sms_enabled = level1_sms_enabled;
this.level1_sms_enabledChanged = true;
this.level1_fax_enabled = level1_fax_enabled;
this.level1_fax_enabledChanged = true;
this.level2_email_enabled = level2_email_enabled;
this.level2_email_enabledChanged = true;
this.level2_sms_enabled = level2_sms_enabled;
this.level2_sms_enabledChanged = true;
this.level2_fax_enabled = level2_fax_enabled;
this.level2_fax_enabledChanged = true;
this.level3_email_enabled = level3_email_enabled;
this.level3_email_enabledChanged = true;
this.level3_sms_enabled = level3_sms_enabled;
this.level3_sms_enabledChanged = true;
this.level3_fax_enabled = level3_fax_enabled;
this.level3_fax_enabledChanged = true;
this.level4_email_enabled = level4_email_enabled;
this.level4_email_enabledChanged = true;
this.level4_sms_enabled = level4_sms_enabled;
this.level4_sms_enabledChanged = true;
this.level4_fax_enabled = level4_fax_enabled;
this.level4_fax_enabledChanged = true;
this.level5_email_enabled = level5_email_enabled;
this.level5_email_enabledChanged = true;
this.level5_sms_enabled = level5_sms_enabled;
this.level5_sms_enabledChanged = true;
this.level5_fax_enabled = level5_fax_enabled;
this.level5_fax_enabledChanged = true;
}
private AlertEscalation( int alert_escalation_id,int alert_template_id,int severity_id,int? level0_duration,int? level1_duration,int? level2_duration,int? level3_duration,int? level4_duration,byte? level1_notification_count,byte? level2_notification_count,byte? level3_notification_count,byte? level4_notification_count,byte? level5_notification_count,int? level1_reminder_interval,int? level2_reminder_interval,int? level3_reminder_interval,int? level4_reminder_interval,int? level5_reminder_interval,bool? level1_email_enabled,bool? level1_sms_enabled,bool? level1_fax_enabled,bool? level2_email_enabled,bool? level2_sms_enabled,bool? level2_fax_enabled,bool? level3_email_enabled,bool? level3_sms_enabled,bool? level3_fax_enabled,bool? level4_email_enabled,bool? level4_sms_enabled,bool? level4_fax_enabled,bool? level5_email_enabled,bool? level5_sms_enabled,bool? level5_fax_enabled )
{
this.alert_escalation_id = alert_escalation_id;
this.alert_escalation_idChanged = true;
this.alert_template_id = alert_template_id;
this.alert_template_idChanged = true;
this.severity_id = severity_id;
this.severity_idChanged = true;
this.level0_duration = level0_duration;
this.level0_durationChanged = true;
this.level1_duration = level1_duration;
this.level1_durationChanged = true;
this.level2_duration = level2_duration;
this.level2_durationChanged = true;
this.level3_duration = level3_duration;
this.level3_durationChanged = true;
this.level4_duration = level4_duration;
this.level4_durationChanged = true;
this.level1_notification_count = level1_notification_count;
this.level1_notification_countChanged = true;
this.level2_notification_count = level2_notification_count;
this.level2_notification_countChanged = true;
this.level3_notification_count = level3_notification_count;
this.level3_notification_countChanged = true;
this.level4_notification_count = level4_notification_count;
this.level4_notification_countChanged = true;
this.level5_notification_count = level5_notification_count;
this.level5_notification_countChanged = true;
this.level1_reminder_interval = level1_reminder_interval;
this.level1_reminder_intervalChanged = true;
this.level2_reminder_interval = level2_reminder_interval;
this.level2_reminder_intervalChanged = true;
this.level3_reminder_interval = level3_reminder_interval;
this.level3_reminder_intervalChanged = true;
this.level4_reminder_interval = level4_reminder_interval;
this.level4_reminder_intervalChanged = true;
this.level5_reminder_interval = level5_reminder_interval;
this.level5_reminder_intervalChanged = true;
this.level1_email_enabled = level1_email_enabled;
this.level1_email_enabledChanged = true;
this.level1_sms_enabled = level1_sms_enabled;
this.level1_sms_enabledChanged = true;
this.level1_fax_enabled = level1_fax_enabled;
this.level1_fax_enabledChanged = true;
this.level2_email_enabled = level2_email_enabled;
this.level2_email_enabledChanged = true;
this.level2_sms_enabled = level2_sms_enabled;
this.level2_sms_enabledChanged = true;
this.level2_fax_enabled = level2_fax_enabled;
this.level2_fax_enabledChanged = true;
this.level3_email_enabled = level3_email_enabled;
this.level3_email_enabledChanged = true;
this.level3_sms_enabled = level3_sms_enabled;
this.level3_sms_enabledChanged = true;
this.level3_fax_enabled = level3_fax_enabled;
this.level3_fax_enabledChanged = true;
this.level4_email_enabled = level4_email_enabled;
this.level4_email_enabledChanged = true;
this.level4_sms_enabled = level4_sms_enabled;
this.level4_sms_enabledChanged = true;
this.level4_fax_enabled = level4_fax_enabled;
this.level4_fax_enabledChanged = true;
this.level5_email_enabled = level5_email_enabled;
this.level5_email_enabledChanged = true;
this.level5_sms_enabled = level5_sms_enabled;
this.level5_sms_enabledChanged = true;
this.level5_fax_enabled = level5_fax_enabled;
this.level5_fax_enabledChanged = true;
}

#region members and properties for columns

#region AlertEscalationId
private bool alert_escalation_idChanged = false;
private int alert_escalation_id;
public int AlertEscalationId
{
get { return alert_escalation_id; }
set { 
alert_escalation_id = value;
alert_escalation_idChanged = true;
}
}
private string alert_escalation_idDbString
{
get
{
return alert_escalation_id.ToString();
}
}
#endregion
#region AlertTemplateId
private bool alert_template_idChanged = false;
private int alert_template_id;
public int AlertTemplateId
{
get { return alert_template_id; }
set { 
alert_template_id = value;
alert_template_idChanged = true;
}
}
private string alert_template_idDbString
{
get
{
return alert_template_id.ToString();
}
}
#endregion
#region SeverityId
private bool severity_idChanged = false;
private int severity_id;
public int SeverityId
{
get { return severity_id; }
set { 
severity_id = value;
severity_idChanged = true;
}
}
private string severity_idDbString
{
get
{
return severity_id.ToString();
}
}
#endregion
#region Level0Duration
private bool level0_durationChanged = false;
private int? level0_duration;
public int? Level0Duration
{
get { return level0_duration; }
set { 
level0_duration = value;
level0_durationChanged = true;
}
}
private string level0_durationDbString
{
get
{
if (this.level0_duration.HasValue)
return level0_duration.ToString();
else
return "null";
}
}
#endregion
#region Level1Duration
private bool level1_durationChanged = false;
private int? level1_duration;
public int? Level1Duration
{
get { return level1_duration; }
set { 
level1_duration = value;
level1_durationChanged = true;
}
}
private string level1_durationDbString
{
get
{
if (this.level1_duration.HasValue)
return level1_duration.ToString();
else
return "null";
}
}
#endregion
#region Level2Duration
private bool level2_durationChanged = false;
private int? level2_duration;
public int? Level2Duration
{
get { return level2_duration; }
set { 
level2_duration = value;
level2_durationChanged = true;
}
}
private string level2_durationDbString
{
get
{
if (this.level2_duration.HasValue)
return level2_duration.ToString();
else
return "null";
}
}
#endregion
#region Level3Duration
private bool level3_durationChanged = false;
private int? level3_duration;
public int? Level3Duration
{
get { return level3_duration; }
set { 
level3_duration = value;
level3_durationChanged = true;
}
}
private string level3_durationDbString
{
get
{
if (this.level3_duration.HasValue)
return level3_duration.ToString();
else
return "null";
}
}
#endregion
#region Level4Duration
private bool level4_durationChanged = false;
private int? level4_duration;
public int? Level4Duration
{
get { return level4_duration; }
set { 
level4_duration = value;
level4_durationChanged = true;
}
}
private string level4_durationDbString
{
get
{
if (this.level4_duration.HasValue)
return level4_duration.ToString();
else
return "null";
}
}
#endregion
#region Level1NotificationCount
private bool level1_notification_countChanged = false;
private byte? level1_notification_count;
public byte? Level1NotificationCount
{
get { return level1_notification_count; }
set { 
level1_notification_count = value;
level1_notification_countChanged = true;
}
}
private string level1_notification_countDbString
{
get
{
if (this.level1_notification_count.HasValue)
return level1_notification_count.ToString();
else
return "null";
}
}
#endregion
#region Level2NotificationCount
private bool level2_notification_countChanged = false;
private byte? level2_notification_count;
public byte? Level2NotificationCount
{
get { return level2_notification_count; }
set { 
level2_notification_count = value;
level2_notification_countChanged = true;
}
}
private string level2_notification_countDbString
{
get
{
if (this.level2_notification_count.HasValue)
return level2_notification_count.ToString();
else
return "null";
}
}
#endregion
#region Level3NotificationCount
private bool level3_notification_countChanged = false;
private byte? level3_notification_count;
public byte? Level3NotificationCount
{
get { return level3_notification_count; }
set { 
level3_notification_count = value;
level3_notification_countChanged = true;
}
}
private string level3_notification_countDbString
{
get
{
if (this.level3_notification_count.HasValue)
return level3_notification_count.ToString();
else
return "null";
}
}
#endregion
#region Level4NotificationCount
private bool level4_notification_countChanged = false;
private byte? level4_notification_count;
public byte? Level4NotificationCount
{
get { return level4_notification_count; }
set { 
level4_notification_count = value;
level4_notification_countChanged = true;
}
}
private string level4_notification_countDbString
{
get
{
if (this.level4_notification_count.HasValue)
return level4_notification_count.ToString();
else
return "null";
}
}
#endregion
#region Level5NotificationCount
private bool level5_notification_countChanged = false;
private byte? level5_notification_count;
public byte? Level5NotificationCount
{
get { return level5_notification_count; }
set { 
level5_notification_count = value;
level5_notification_countChanged = true;
}
}
private string level5_notification_countDbString
{
get
{
if (this.level5_notification_count.HasValue)
return level5_notification_count.ToString();
else
return "null";
}
}
#endregion
#region Level1ReminderInterval
private bool level1_reminder_intervalChanged = false;
private int? level1_reminder_interval;
public int? Level1ReminderInterval
{
get { return level1_reminder_interval; }
set { 
level1_reminder_interval = value;
level1_reminder_intervalChanged = true;
}
}
private string level1_reminder_intervalDbString
{
get
{
if (this.level1_reminder_interval.HasValue)
return level1_reminder_interval.ToString();
else
return "null";
}
}
#endregion
#region Level2ReminderInterval
private bool level2_reminder_intervalChanged = false;
private int? level2_reminder_interval;
public int? Level2ReminderInterval
{
get { return level2_reminder_interval; }
set { 
level2_reminder_interval = value;
level2_reminder_intervalChanged = true;
}
}
private string level2_reminder_intervalDbString
{
get
{
if (this.level2_reminder_interval.HasValue)
return level2_reminder_interval.ToString();
else
return "null";
}
}
#endregion
#region Level3ReminderInterval
private bool level3_reminder_intervalChanged = false;
private int? level3_reminder_interval;
public int? Level3ReminderInterval
{
get { return level3_reminder_interval; }
set { 
level3_reminder_interval = value;
level3_reminder_intervalChanged = true;
}
}
private string level3_reminder_intervalDbString
{
get
{
if (this.level3_reminder_interval.HasValue)
return level3_reminder_interval.ToString();
else
return "null";
}
}
#endregion
#region Level4ReminderInterval
private bool level4_reminder_intervalChanged = false;
private int? level4_reminder_interval;
public int? Level4ReminderInterval
{
get { return level4_reminder_interval; }
set { 
level4_reminder_interval = value;
level4_reminder_intervalChanged = true;
}
}
private string level4_reminder_intervalDbString
{
get
{
if (this.level4_reminder_interval.HasValue)
return level4_reminder_interval.ToString();
else
return "null";
}
}
#endregion
#region Level5ReminderInterval
private bool level5_reminder_intervalChanged = false;
private int? level5_reminder_interval;
public int? Level5ReminderInterval
{
get { return level5_reminder_interval; }
set { 
level5_reminder_interval = value;
level5_reminder_intervalChanged = true;
}
}
private string level5_reminder_intervalDbString
{
get
{
if (this.level5_reminder_interval.HasValue)
return level5_reminder_interval.ToString();
else
return "null";
}
}
#endregion
#region Level1EmailEnabled
private bool level1_email_enabledChanged = false;
private bool? level1_email_enabled;
public bool? Level1EmailEnabled
{
get { return level1_email_enabled; }
set { 
level1_email_enabled = value;
level1_email_enabledChanged = true;
}
}
private string level1_email_enabledDbString
{
get
{
if (this.level1_email_enabled.HasValue)
return level1_email_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level1SmsEnabled
private bool level1_sms_enabledChanged = false;
private bool? level1_sms_enabled;
public bool? Level1SmsEnabled
{
get { return level1_sms_enabled; }
set { 
level1_sms_enabled = value;
level1_sms_enabledChanged = true;
}
}
private string level1_sms_enabledDbString
{
get
{
if (this.level1_sms_enabled.HasValue)
return level1_sms_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level1FaxEnabled
private bool level1_fax_enabledChanged = false;
private bool? level1_fax_enabled;
public bool? Level1FaxEnabled
{
get { return level1_fax_enabled; }
set { 
level1_fax_enabled = value;
level1_fax_enabledChanged = true;
}
}
private string level1_fax_enabledDbString
{
get
{
if (this.level1_fax_enabled.HasValue)
return level1_fax_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level2EmailEnabled
private bool level2_email_enabledChanged = false;
private bool? level2_email_enabled;
public bool? Level2EmailEnabled
{
get { return level2_email_enabled; }
set { 
level2_email_enabled = value;
level2_email_enabledChanged = true;
}
}
private string level2_email_enabledDbString
{
get
{
if (this.level2_email_enabled.HasValue)
return level2_email_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level2SmsEnabled
private bool level2_sms_enabledChanged = false;
private bool? level2_sms_enabled;
public bool? Level2SmsEnabled
{
get { return level2_sms_enabled; }
set { 
level2_sms_enabled = value;
level2_sms_enabledChanged = true;
}
}
private string level2_sms_enabledDbString
{
get
{
if (this.level2_sms_enabled.HasValue)
return level2_sms_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level2FaxEnabled
private bool level2_fax_enabledChanged = false;
private bool? level2_fax_enabled;
public bool? Level2FaxEnabled
{
get { return level2_fax_enabled; }
set { 
level2_fax_enabled = value;
level2_fax_enabledChanged = true;
}
}
private string level2_fax_enabledDbString
{
get
{
if (this.level2_fax_enabled.HasValue)
return level2_fax_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level3EmailEnabled
private bool level3_email_enabledChanged = false;
private bool? level3_email_enabled;
public bool? Level3EmailEnabled
{
get { return level3_email_enabled; }
set { 
level3_email_enabled = value;
level3_email_enabledChanged = true;
}
}
private string level3_email_enabledDbString
{
get
{
if (this.level3_email_enabled.HasValue)
return level3_email_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level3SmsEnabled
private bool level3_sms_enabledChanged = false;
private bool? level3_sms_enabled;
public bool? Level3SmsEnabled
{
get { return level3_sms_enabled; }
set { 
level3_sms_enabled = value;
level3_sms_enabledChanged = true;
}
}
private string level3_sms_enabledDbString
{
get
{
if (this.level3_sms_enabled.HasValue)
return level3_sms_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level3FaxEnabled
private bool level3_fax_enabledChanged = false;
private bool? level3_fax_enabled;
public bool? Level3FaxEnabled
{
get { return level3_fax_enabled; }
set { 
level3_fax_enabled = value;
level3_fax_enabledChanged = true;
}
}
private string level3_fax_enabledDbString
{
get
{
if (this.level3_fax_enabled.HasValue)
return level3_fax_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level4EmailEnabled
private bool level4_email_enabledChanged = false;
private bool? level4_email_enabled;
public bool? Level4EmailEnabled
{
get { return level4_email_enabled; }
set { 
level4_email_enabled = value;
level4_email_enabledChanged = true;
}
}
private string level4_email_enabledDbString
{
get
{
if (this.level4_email_enabled.HasValue)
return level4_email_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level4SmsEnabled
private bool level4_sms_enabledChanged = false;
private bool? level4_sms_enabled;
public bool? Level4SmsEnabled
{
get { return level4_sms_enabled; }
set { 
level4_sms_enabled = value;
level4_sms_enabledChanged = true;
}
}
private string level4_sms_enabledDbString
{
get
{
if (this.level4_sms_enabled.HasValue)
return level4_sms_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level4FaxEnabled
private bool level4_fax_enabledChanged = false;
private bool? level4_fax_enabled;
public bool? Level4FaxEnabled
{
get { return level4_fax_enabled; }
set { 
level4_fax_enabled = value;
level4_fax_enabledChanged = true;
}
}
private string level4_fax_enabledDbString
{
get
{
if (this.level4_fax_enabled.HasValue)
return level4_fax_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level5EmailEnabled
private bool level5_email_enabledChanged = false;
private bool? level5_email_enabled;
public bool? Level5EmailEnabled
{
get { return level5_email_enabled; }
set { 
level5_email_enabled = value;
level5_email_enabledChanged = true;
}
}
private string level5_email_enabledDbString
{
get
{
if (this.level5_email_enabled.HasValue)
return level5_email_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level5SmsEnabled
private bool level5_sms_enabledChanged = false;
private bool? level5_sms_enabled;
public bool? Level5SmsEnabled
{
get { return level5_sms_enabled; }
set { 
level5_sms_enabled = value;
level5_sms_enabledChanged = true;
}
}
private string level5_sms_enabledDbString
{
get
{
if (this.level5_sms_enabled.HasValue)
return level5_sms_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Level5FaxEnabled
private bool level5_fax_enabledChanged = false;
private bool? level5_fax_enabled;
public bool? Level5FaxEnabled
{
get { return level5_fax_enabled; }
set { 
level5_fax_enabled = value;
level5_fax_enabledChanged = true;
}
}
private string level5_fax_enabledDbString
{
get
{
if (this.level5_fax_enabled.HasValue)
return level5_fax_enabled.Value?"1":"0";
else
return "null";
}
}
#endregion
#endregion

#region AlertEscalationReader
public class AlertEscalationReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AlertEscalation currentAlertEscalation;
Columns columns;
bool partialRead = false;
private AlertEscalationReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AlertEscalationReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AlertEscalationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAlertEscalation; }

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
currentAlertEscalation = new AlertEscalation();
if (partialRead)
{ if ((columns & Columns.alert_escalation_id) == Columns.alert_escalation_id && reader["alert_escalation_id"]!=DBNull.Value)
currentAlertEscalation.alert_escalation_id =(int) reader["alert_escalation_id"]; 
if ((columns & Columns.alert_template_id) == Columns.alert_template_id && reader["alert_template_id"]!=DBNull.Value)
currentAlertEscalation.alert_template_id =(int) reader["alert_template_id"]; 
if ((columns & Columns.severity_id) == Columns.severity_id && reader["severity_id"]!=DBNull.Value)
currentAlertEscalation.severity_id =(int) reader["severity_id"]; 
if ((columns & Columns.level0_duration) == Columns.level0_duration && reader["level0_duration"]!=DBNull.Value)
currentAlertEscalation.level0_duration =(int?) reader["level0_duration"]; 
if ((columns & Columns.level1_duration) == Columns.level1_duration && reader["level1_duration"]!=DBNull.Value)
currentAlertEscalation.level1_duration =(int?) reader["level1_duration"]; 
if ((columns & Columns.level2_duration) == Columns.level2_duration && reader["level2_duration"]!=DBNull.Value)
currentAlertEscalation.level2_duration =(int?) reader["level2_duration"]; 
if ((columns & Columns.level3_duration) == Columns.level3_duration && reader["level3_duration"]!=DBNull.Value)
currentAlertEscalation.level3_duration =(int?) reader["level3_duration"]; 
if ((columns & Columns.level4_duration) == Columns.level4_duration && reader["level4_duration"]!=DBNull.Value)
currentAlertEscalation.level4_duration =(int?) reader["level4_duration"]; 
if ((columns & Columns.level1_notification_count) == Columns.level1_notification_count && reader["level1_notification_count"]!=DBNull.Value)
currentAlertEscalation.level1_notification_count =(byte?) reader["level1_notification_count"]; 
if ((columns & Columns.level2_notification_count) == Columns.level2_notification_count && reader["level2_notification_count"]!=DBNull.Value)
currentAlertEscalation.level2_notification_count =(byte?) reader["level2_notification_count"]; 
if ((columns & Columns.level3_notification_count) == Columns.level3_notification_count && reader["level3_notification_count"]!=DBNull.Value)
currentAlertEscalation.level3_notification_count =(byte?) reader["level3_notification_count"]; 
if ((columns & Columns.level4_notification_count) == Columns.level4_notification_count && reader["level4_notification_count"]!=DBNull.Value)
currentAlertEscalation.level4_notification_count =(byte?) reader["level4_notification_count"]; 
if ((columns & Columns.level5_notification_count) == Columns.level5_notification_count && reader["level5_notification_count"]!=DBNull.Value)
currentAlertEscalation.level5_notification_count =(byte?) reader["level5_notification_count"]; 
if ((columns & Columns.level1_reminder_interval) == Columns.level1_reminder_interval && reader["level1_reminder_interval"]!=DBNull.Value)
currentAlertEscalation.level1_reminder_interval =(int?) reader["level1_reminder_interval"]; 
if ((columns & Columns.level2_reminder_interval) == Columns.level2_reminder_interval && reader["level2_reminder_interval"]!=DBNull.Value)
currentAlertEscalation.level2_reminder_interval =(int?) reader["level2_reminder_interval"]; 
if ((columns & Columns.level3_reminder_interval) == Columns.level3_reminder_interval && reader["level3_reminder_interval"]!=DBNull.Value)
currentAlertEscalation.level3_reminder_interval =(int?) reader["level3_reminder_interval"]; 
if ((columns & Columns.level4_reminder_interval) == Columns.level4_reminder_interval && reader["level4_reminder_interval"]!=DBNull.Value)
currentAlertEscalation.level4_reminder_interval =(int?) reader["level4_reminder_interval"]; 
if ((columns & Columns.level5_reminder_interval) == Columns.level5_reminder_interval && reader["level5_reminder_interval"]!=DBNull.Value)
currentAlertEscalation.level5_reminder_interval =(int?) reader["level5_reminder_interval"]; 
if ((columns & Columns.level1_email_enabled) == Columns.level1_email_enabled && reader["level1_email_enabled"]!=DBNull.Value)
currentAlertEscalation.level1_email_enabled =(bool?) reader["level1_email_enabled"]; 
if ((columns & Columns.level1_sms_enabled) == Columns.level1_sms_enabled && reader["level1_sms_enabled"]!=DBNull.Value)
currentAlertEscalation.level1_sms_enabled =(bool?) reader["level1_sms_enabled"]; 
if ((columns & Columns.level1_fax_enabled) == Columns.level1_fax_enabled && reader["level1_fax_enabled"]!=DBNull.Value)
currentAlertEscalation.level1_fax_enabled =(bool?) reader["level1_fax_enabled"]; 
if ((columns & Columns.level2_email_enabled) == Columns.level2_email_enabled && reader["level2_email_enabled"]!=DBNull.Value)
currentAlertEscalation.level2_email_enabled =(bool?) reader["level2_email_enabled"]; 
if ((columns & Columns.level2_sms_enabled) == Columns.level2_sms_enabled && reader["level2_sms_enabled"]!=DBNull.Value)
currentAlertEscalation.level2_sms_enabled =(bool?) reader["level2_sms_enabled"]; 
if ((columns & Columns.level2_fax_enabled) == Columns.level2_fax_enabled && reader["level2_fax_enabled"]!=DBNull.Value)
currentAlertEscalation.level2_fax_enabled =(bool?) reader["level2_fax_enabled"]; 
if ((columns & Columns.level3_email_enabled) == Columns.level3_email_enabled && reader["level3_email_enabled"]!=DBNull.Value)
currentAlertEscalation.level3_email_enabled =(bool?) reader["level3_email_enabled"]; 
if ((columns & Columns.level3_sms_enabled) == Columns.level3_sms_enabled && reader["level3_sms_enabled"]!=DBNull.Value)
currentAlertEscalation.level3_sms_enabled =(bool?) reader["level3_sms_enabled"]; 
if ((columns & Columns.level3_fax_enabled) == Columns.level3_fax_enabled && reader["level3_fax_enabled"]!=DBNull.Value)
currentAlertEscalation.level3_fax_enabled =(bool?) reader["level3_fax_enabled"]; 
if ((columns & Columns.level4_email_enabled) == Columns.level4_email_enabled && reader["level4_email_enabled"]!=DBNull.Value)
currentAlertEscalation.level4_email_enabled =(bool?) reader["level4_email_enabled"]; 
if ((columns & Columns.level4_sms_enabled) == Columns.level4_sms_enabled && reader["level4_sms_enabled"]!=DBNull.Value)
currentAlertEscalation.level4_sms_enabled =(bool?) reader["level4_sms_enabled"]; 
if ((columns & Columns.level4_fax_enabled) == Columns.level4_fax_enabled && reader["level4_fax_enabled"]!=DBNull.Value)
currentAlertEscalation.level4_fax_enabled =(bool?) reader["level4_fax_enabled"]; 
if ((columns & Columns.level5_email_enabled) == Columns.level5_email_enabled && reader["level5_email_enabled"]!=DBNull.Value)
currentAlertEscalation.level5_email_enabled =(bool?) reader["level5_email_enabled"]; 
if ((columns & Columns.level5_sms_enabled) == Columns.level5_sms_enabled && reader["level5_sms_enabled"]!=DBNull.Value)
currentAlertEscalation.level5_sms_enabled =(bool?) reader["level5_sms_enabled"]; 
if ((columns & Columns.level5_fax_enabled) == Columns.level5_fax_enabled && reader["level5_fax_enabled"]!=DBNull.Value)
currentAlertEscalation.level5_fax_enabled =(bool?) reader["level5_fax_enabled"]; 

} else
{
if (reader["alert_escalation_id"] != DBNull.Value)
currentAlertEscalation.alert_escalation_id = (int) reader["alert_escalation_id"]; 
if (reader["alert_template_id"] != DBNull.Value)
currentAlertEscalation.alert_template_id = (int) reader["alert_template_id"]; 
if (reader["severity_id"] != DBNull.Value)
currentAlertEscalation.severity_id = (int) reader["severity_id"]; 
if (reader["level0_duration"] != DBNull.Value)
currentAlertEscalation.level0_duration = (int?) reader["level0_duration"]; 
if (reader["level1_duration"] != DBNull.Value)
currentAlertEscalation.level1_duration = (int?) reader["level1_duration"]; 
if (reader["level2_duration"] != DBNull.Value)
currentAlertEscalation.level2_duration = (int?) reader["level2_duration"]; 
if (reader["level3_duration"] != DBNull.Value)
currentAlertEscalation.level3_duration = (int?) reader["level3_duration"]; 
if (reader["level4_duration"] != DBNull.Value)
currentAlertEscalation.level4_duration = (int?) reader["level4_duration"]; 
if (reader["level1_notification_count"] != DBNull.Value)
currentAlertEscalation.level1_notification_count = (byte?) reader["level1_notification_count"]; 
if (reader["level2_notification_count"] != DBNull.Value)
currentAlertEscalation.level2_notification_count = (byte?) reader["level2_notification_count"]; 
if (reader["level3_notification_count"] != DBNull.Value)
currentAlertEscalation.level3_notification_count = (byte?) reader["level3_notification_count"]; 
if (reader["level4_notification_count"] != DBNull.Value)
currentAlertEscalation.level4_notification_count = (byte?) reader["level4_notification_count"]; 
if (reader["level5_notification_count"] != DBNull.Value)
currentAlertEscalation.level5_notification_count = (byte?) reader["level5_notification_count"]; 
if (reader["level1_reminder_interval"] != DBNull.Value)
currentAlertEscalation.level1_reminder_interval = (int?) reader["level1_reminder_interval"]; 
if (reader["level2_reminder_interval"] != DBNull.Value)
currentAlertEscalation.level2_reminder_interval = (int?) reader["level2_reminder_interval"]; 
if (reader["level3_reminder_interval"] != DBNull.Value)
currentAlertEscalation.level3_reminder_interval = (int?) reader["level3_reminder_interval"]; 
if (reader["level4_reminder_interval"] != DBNull.Value)
currentAlertEscalation.level4_reminder_interval = (int?) reader["level4_reminder_interval"]; 
if (reader["level5_reminder_interval"] != DBNull.Value)
currentAlertEscalation.level5_reminder_interval = (int?) reader["level5_reminder_interval"]; 
if (reader["level1_email_enabled"] != DBNull.Value)
currentAlertEscalation.level1_email_enabled = (bool?) reader["level1_email_enabled"]; 
if (reader["level1_sms_enabled"] != DBNull.Value)
currentAlertEscalation.level1_sms_enabled = (bool?) reader["level1_sms_enabled"]; 
if (reader["level1_fax_enabled"] != DBNull.Value)
currentAlertEscalation.level1_fax_enabled = (bool?) reader["level1_fax_enabled"]; 
if (reader["level2_email_enabled"] != DBNull.Value)
currentAlertEscalation.level2_email_enabled = (bool?) reader["level2_email_enabled"]; 
if (reader["level2_sms_enabled"] != DBNull.Value)
currentAlertEscalation.level2_sms_enabled = (bool?) reader["level2_sms_enabled"]; 
if (reader["level2_fax_enabled"] != DBNull.Value)
currentAlertEscalation.level2_fax_enabled = (bool?) reader["level2_fax_enabled"]; 
if (reader["level3_email_enabled"] != DBNull.Value)
currentAlertEscalation.level3_email_enabled = (bool?) reader["level3_email_enabled"]; 
if (reader["level3_sms_enabled"] != DBNull.Value)
currentAlertEscalation.level3_sms_enabled = (bool?) reader["level3_sms_enabled"]; 
if (reader["level3_fax_enabled"] != DBNull.Value)
currentAlertEscalation.level3_fax_enabled = (bool?) reader["level3_fax_enabled"]; 
if (reader["level4_email_enabled"] != DBNull.Value)
currentAlertEscalation.level4_email_enabled = (bool?) reader["level4_email_enabled"]; 
if (reader["level4_sms_enabled"] != DBNull.Value)
currentAlertEscalation.level4_sms_enabled = (bool?) reader["level4_sms_enabled"]; 
if (reader["level4_fax_enabled"] != DBNull.Value)
currentAlertEscalation.level4_fax_enabled = (bool?) reader["level4_fax_enabled"]; 
if (reader["level5_email_enabled"] != DBNull.Value)
currentAlertEscalation.level5_email_enabled = (bool?) reader["level5_email_enabled"]; 
if (reader["level5_sms_enabled"] != DBNull.Value)
currentAlertEscalation.level5_sms_enabled = (bool?) reader["level5_sms_enabled"]; 
if (reader["level5_fax_enabled"] != DBNull.Value)
currentAlertEscalation.level5_fax_enabled = (bool?) reader["level5_fax_enabled"]; 
} 

currentAlertEscalation.isNewEntity = false;
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

public AlertEscalation CurrentAlertEscalation
{
get{ return currentAlertEscalation; }
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


#region AlertEscalation functions

public static AlertEscalationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.alert_escalation_id == (Columns.alert_escalation_id & columns))
qry.Append("alert_escalation_id,");
if (Columns.alert_template_id == (Columns.alert_template_id & columns))
qry.Append("alert_template_id,");
if (Columns.severity_id == (Columns.severity_id & columns))
qry.Append("severity_id,");
if (Columns.level0_duration == (Columns.level0_duration & columns))
qry.Append("level0_duration,");
if (Columns.level1_duration == (Columns.level1_duration & columns))
qry.Append("level1_duration,");
if (Columns.level2_duration == (Columns.level2_duration & columns))
qry.Append("level2_duration,");
if (Columns.level3_duration == (Columns.level3_duration & columns))
qry.Append("level3_duration,");
if (Columns.level4_duration == (Columns.level4_duration & columns))
qry.Append("level4_duration,");
if (Columns.level1_notification_count == (Columns.level1_notification_count & columns))
qry.Append("level1_notification_count,");
if (Columns.level2_notification_count == (Columns.level2_notification_count & columns))
qry.Append("level2_notification_count,");
if (Columns.level3_notification_count == (Columns.level3_notification_count & columns))
qry.Append("level3_notification_count,");
if (Columns.level4_notification_count == (Columns.level4_notification_count & columns))
qry.Append("level4_notification_count,");
if (Columns.level5_notification_count == (Columns.level5_notification_count & columns))
qry.Append("level5_notification_count,");
if (Columns.level1_reminder_interval == (Columns.level1_reminder_interval & columns))
qry.Append("level1_reminder_interval,");
if (Columns.level2_reminder_interval == (Columns.level2_reminder_interval & columns))
qry.Append("level2_reminder_interval,");
if (Columns.level3_reminder_interval == (Columns.level3_reminder_interval & columns))
qry.Append("level3_reminder_interval,");
if (Columns.level4_reminder_interval == (Columns.level4_reminder_interval & columns))
qry.Append("level4_reminder_interval,");
if (Columns.level5_reminder_interval == (Columns.level5_reminder_interval & columns))
qry.Append("level5_reminder_interval,");
if (Columns.level1_email_enabled == (Columns.level1_email_enabled & columns))
qry.Append("level1_email_enabled,");
if (Columns.level1_sms_enabled == (Columns.level1_sms_enabled & columns))
qry.Append("level1_sms_enabled,");
if (Columns.level1_fax_enabled == (Columns.level1_fax_enabled & columns))
qry.Append("level1_fax_enabled,");
if (Columns.level2_email_enabled == (Columns.level2_email_enabled & columns))
qry.Append("level2_email_enabled,");
if (Columns.level2_sms_enabled == (Columns.level2_sms_enabled & columns))
qry.Append("level2_sms_enabled,");
if (Columns.level2_fax_enabled == (Columns.level2_fax_enabled & columns))
qry.Append("level2_fax_enabled,");
if (Columns.level3_email_enabled == (Columns.level3_email_enabled & columns))
qry.Append("level3_email_enabled,");
if (Columns.level3_sms_enabled == (Columns.level3_sms_enabled & columns))
qry.Append("level3_sms_enabled,");
if (Columns.level3_fax_enabled == (Columns.level3_fax_enabled & columns))
qry.Append("level3_fax_enabled,");
if (Columns.level4_email_enabled == (Columns.level4_email_enabled & columns))
qry.Append("level4_email_enabled,");
if (Columns.level4_sms_enabled == (Columns.level4_sms_enabled & columns))
qry.Append("level4_sms_enabled,");
if (Columns.level4_fax_enabled == (Columns.level4_fax_enabled & columns))
qry.Append("level4_fax_enabled,");
if (Columns.level5_email_enabled == (Columns.level5_email_enabled & columns))
qry.Append("level5_email_enabled,");
if (Columns.level5_sms_enabled == (Columns.level5_sms_enabled & columns))
qry.Append("level5_sms_enabled,");
if (Columns.level5_fax_enabled == (Columns.level5_fax_enabled & columns))
qry.Append("level5_fax_enabled,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Alert_escalation ");

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
return new AlertEscalationReader(cmd.ExecuteReader(), conn, columns);
}

static public AlertEscalationReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AlertEscalationReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select alert_escalation_id,alert_template_id,severity_id,level0_duration,level1_duration,level2_duration,level3_duration,level4_duration,level1_notification_count,level2_notification_count,level3_notification_count,level4_notification_count,level5_notification_count,level1_reminder_interval,level2_reminder_interval,level3_reminder_interval,level4_reminder_interval,level5_reminder_interval,level1_email_enabled,level1_sms_enabled,level1_fax_enabled,level2_email_enabled,level2_sms_enabled,level2_fax_enabled,level3_email_enabled,level3_sms_enabled,level3_fax_enabled,level4_email_enabled,level4_sms_enabled,level4_fax_enabled,level5_email_enabled,level5_sms_enabled,level5_fax_enabled from Alert_escalation ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AlertEscalationReader(cmd.ExecuteReader(), conn);
}

static public AlertEscalationReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AlertEscalation LoadAlertEscalation(string where)
{
AlertEscalationReader reader = AlertEscalation.ExecuteReader(where);
AlertEscalation _alertescalation = null;
if (reader.Read())
_alertescalation = reader.CurrentAlertEscalation;
reader.Close();
return _alertescalation;
}

public static AlertEscalation LoadAlertEscalation(string where, IDbConnection conn)
{
AlertEscalationReader reader = AlertEscalation.ExecuteReader(where, conn);
AlertEscalation _alertescalation = null;
if (reader.Read())
_alertescalation = reader.CurrentAlertEscalation;
reader.Close(false);
return _alertescalation;
}

public static AlertEscalation LoadAlertEscalationByPk( int alert_escalation_id )
{
return LoadAlertEscalation( " alert_escalation_id="+alert_escalation_id );
}

public static AlertEscalation LoadAlertEscalationByPk( int alert_escalation_id , IDbConnection conn)
{
return LoadAlertEscalation(" alert_escalation_id="+alert_escalation_id , conn);
}

public void Save()
{
if (alert_escalation_idChanged || alert_template_idChanged || severity_idChanged || level0_durationChanged || level1_durationChanged || level2_durationChanged || level3_durationChanged || level4_durationChanged || level1_notification_countChanged || level2_notification_countChanged || level3_notification_countChanged || level4_notification_countChanged || level5_notification_countChanged || level1_reminder_intervalChanged || level2_reminder_intervalChanged || level3_reminder_intervalChanged || level4_reminder_intervalChanged || level5_reminder_intervalChanged || level1_email_enabledChanged || level1_sms_enabledChanged || level1_fax_enabledChanged || level2_email_enabledChanged || level2_sms_enabledChanged || level2_fax_enabledChanged || level3_email_enabledChanged || level3_sms_enabledChanged || level3_fax_enabledChanged || level4_email_enabledChanged || level4_sms_enabledChanged || level4_fax_enabledChanged || level5_email_enabledChanged || level5_sms_enabledChanged || level5_fax_enabledChanged )
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
if (alert_escalation_idChanged || alert_template_idChanged || severity_idChanged || level0_durationChanged || level1_durationChanged || level2_durationChanged || level3_durationChanged || level4_durationChanged || level1_notification_countChanged || level2_notification_countChanged || level3_notification_countChanged || level4_notification_countChanged || level5_notification_countChanged || level1_reminder_intervalChanged || level2_reminder_intervalChanged || level3_reminder_intervalChanged || level4_reminder_intervalChanged || level5_reminder_intervalChanged || level1_email_enabledChanged || level1_sms_enabledChanged || level1_fax_enabledChanged || level2_email_enabledChanged || level2_sms_enabledChanged || level2_fax_enabledChanged || level3_email_enabledChanged || level3_sms_enabledChanged || level3_fax_enabledChanged || level4_email_enabledChanged || level4_sms_enabledChanged || level4_fax_enabledChanged || level5_email_enabledChanged || level5_sms_enabledChanged || level5_fax_enabledChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Alert_escalation( alert_escalation_id,alert_template_id,severity_id,level0_duration,level1_duration,level2_duration,level3_duration,level4_duration,level1_notification_count,level2_notification_count,level3_notification_count,level4_notification_count,level5_notification_count,level1_reminder_interval,level2_reminder_interval,level3_reminder_interval,level4_reminder_interval,level5_reminder_interval,level1_email_enabled,level1_sms_enabled,level1_fax_enabled,level2_email_enabled,level2_sms_enabled,level2_fax_enabled,level3_email_enabled,level3_sms_enabled,level3_fax_enabled,level4_email_enabled,level4_sms_enabled,level4_fax_enabled,level5_email_enabled,level5_sms_enabled,level5_fax_enabled ) values(");
lock (ConnectionFactory.connectionString) { this.alert_escalation_id = ConnectionFactory.GetNextId();
qry.Append(this.alert_escalation_id);
} qry.Append(",");
qry.Append(alert_template_idDbString+",");
qry.Append(severity_idDbString+",");
qry.Append(level0_durationDbString+",");
qry.Append(level1_durationDbString+",");
qry.Append(level2_durationDbString+",");
qry.Append(level3_durationDbString+",");
qry.Append(level4_durationDbString+",");
qry.Append(level1_notification_countDbString+",");
qry.Append(level2_notification_countDbString+",");
qry.Append(level3_notification_countDbString+",");
qry.Append(level4_notification_countDbString+",");
qry.Append(level5_notification_countDbString+",");
qry.Append(level1_reminder_intervalDbString+",");
qry.Append(level2_reminder_intervalDbString+",");
qry.Append(level3_reminder_intervalDbString+",");
qry.Append(level4_reminder_intervalDbString+",");
qry.Append(level5_reminder_intervalDbString+",");
qry.Append(level1_email_enabledDbString+",");
qry.Append(level1_sms_enabledDbString+",");
qry.Append(level1_fax_enabledDbString+",");
qry.Append(level2_email_enabledDbString+",");
qry.Append(level2_sms_enabledDbString+",");
qry.Append(level2_fax_enabledDbString+",");
qry.Append(level3_email_enabledDbString+",");
qry.Append(level3_sms_enabledDbString+",");
qry.Append(level3_fax_enabledDbString+",");
qry.Append(level4_email_enabledDbString+",");
qry.Append(level4_sms_enabledDbString+",");
qry.Append(level4_fax_enabledDbString+",");
qry.Append(level5_email_enabledDbString+",");
qry.Append(level5_sms_enabledDbString+",");
qry.Append(level5_fax_enabledDbString);
qry.Append(");");

}
else
{
if (!(alert_escalation_idChanged || alert_template_idChanged || severity_idChanged || level0_durationChanged || level1_durationChanged || level2_durationChanged || level3_durationChanged || level4_durationChanged || level1_notification_countChanged || level2_notification_countChanged || level3_notification_countChanged || level4_notification_countChanged || level5_notification_countChanged || level1_reminder_intervalChanged || level2_reminder_intervalChanged || level3_reminder_intervalChanged || level4_reminder_intervalChanged || level5_reminder_intervalChanged || level1_email_enabledChanged || level1_sms_enabledChanged || level1_fax_enabledChanged || level2_email_enabledChanged || level2_sms_enabledChanged || level2_fax_enabledChanged || level3_email_enabledChanged || level3_sms_enabledChanged || level3_fax_enabledChanged || level4_email_enabledChanged || level4_sms_enabledChanged || level4_fax_enabledChanged || level5_email_enabledChanged || level5_sms_enabledChanged || level5_fax_enabledChanged ))
return;
qry.Append("UPDATE Alert_escalation set "); if ( alert_template_idChanged )
{
qry.Append("alert_template_id ="+alert_template_idDbString);
qry.Append(",");
}

if ( severity_idChanged )
{
qry.Append("severity_id ="+severity_idDbString);
qry.Append(",");
}

if ( level0_durationChanged )
{
qry.Append("level0_duration ="+level0_durationDbString);
qry.Append(",");
}

if ( level1_durationChanged )
{
qry.Append("level1_duration ="+level1_durationDbString);
qry.Append(",");
}

if ( level2_durationChanged )
{
qry.Append("level2_duration ="+level2_durationDbString);
qry.Append(",");
}

if ( level3_durationChanged )
{
qry.Append("level3_duration ="+level3_durationDbString);
qry.Append(",");
}

if ( level4_durationChanged )
{
qry.Append("level4_duration ="+level4_durationDbString);
qry.Append(",");
}

if ( level1_notification_countChanged )
{
qry.Append("level1_notification_count ="+level1_notification_countDbString);
qry.Append(",");
}

if ( level2_notification_countChanged )
{
qry.Append("level2_notification_count ="+level2_notification_countDbString);
qry.Append(",");
}

if ( level3_notification_countChanged )
{
qry.Append("level3_notification_count ="+level3_notification_countDbString);
qry.Append(",");
}

if ( level4_notification_countChanged )
{
qry.Append("level4_notification_count ="+level4_notification_countDbString);
qry.Append(",");
}

if ( level5_notification_countChanged )
{
qry.Append("level5_notification_count ="+level5_notification_countDbString);
qry.Append(",");
}

if ( level1_reminder_intervalChanged )
{
qry.Append("level1_reminder_interval ="+level1_reminder_intervalDbString);
qry.Append(",");
}

if ( level2_reminder_intervalChanged )
{
qry.Append("level2_reminder_interval ="+level2_reminder_intervalDbString);
qry.Append(",");
}

if ( level3_reminder_intervalChanged )
{
qry.Append("level3_reminder_interval ="+level3_reminder_intervalDbString);
qry.Append(",");
}

if ( level4_reminder_intervalChanged )
{
qry.Append("level4_reminder_interval ="+level4_reminder_intervalDbString);
qry.Append(",");
}

if ( level5_reminder_intervalChanged )
{
qry.Append("level5_reminder_interval ="+level5_reminder_intervalDbString);
qry.Append(",");
}

if ( level1_email_enabledChanged )
{
qry.Append("level1_email_enabled ="+level1_email_enabledDbString);
qry.Append(",");
}

if ( level1_sms_enabledChanged )
{
qry.Append("level1_sms_enabled ="+level1_sms_enabledDbString);
qry.Append(",");
}

if ( level1_fax_enabledChanged )
{
qry.Append("level1_fax_enabled ="+level1_fax_enabledDbString);
qry.Append(",");
}

if ( level2_email_enabledChanged )
{
qry.Append("level2_email_enabled ="+level2_email_enabledDbString);
qry.Append(",");
}

if ( level2_sms_enabledChanged )
{
qry.Append("level2_sms_enabled ="+level2_sms_enabledDbString);
qry.Append(",");
}

if ( level2_fax_enabledChanged )
{
qry.Append("level2_fax_enabled ="+level2_fax_enabledDbString);
qry.Append(",");
}

if ( level3_email_enabledChanged )
{
qry.Append("level3_email_enabled ="+level3_email_enabledDbString);
qry.Append(",");
}

if ( level3_sms_enabledChanged )
{
qry.Append("level3_sms_enabled ="+level3_sms_enabledDbString);
qry.Append(",");
}

if ( level3_fax_enabledChanged )
{
qry.Append("level3_fax_enabled ="+level3_fax_enabledDbString);
qry.Append(",");
}

if ( level4_email_enabledChanged )
{
qry.Append("level4_email_enabled ="+level4_email_enabledDbString);
qry.Append(",");
}

if ( level4_sms_enabledChanged )
{
qry.Append("level4_sms_enabled ="+level4_sms_enabledDbString);
qry.Append(",");
}

if ( level4_fax_enabledChanged )
{
qry.Append("level4_fax_enabled ="+level4_fax_enabledDbString);
qry.Append(",");
}

if ( level5_email_enabledChanged )
{
qry.Append("level5_email_enabled ="+level5_email_enabledDbString);
qry.Append(",");
}

if ( level5_sms_enabledChanged )
{
qry.Append("level5_sms_enabled ="+level5_sms_enabledDbString);
qry.Append(",");
}

if ( level5_fax_enabledChanged )
{
qry.Append("level5_fax_enabled ="+level5_fax_enabledDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("alert_escalation_id = "+alert_escalation_idDbString);
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
cmd.CommandText = "DELETE Alert_escalation where alert_escalation_id = "+ alert_escalation_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAlertEscalations(string where)
{
ConnectionFactory.ExecuteQuery("delete Alert_escalation where " + where);
}

#endregion
#region Columns enum
public enum Columns:ulong
{
alert_escalation_id= 1,
alert_template_id= 2,
severity_id= 4,
level0_duration= 8,
level1_duration= 16,
level2_duration= 32,
level3_duration= 64,
level4_duration= 128,
level1_notification_count= 256,
level2_notification_count= 512,
level3_notification_count= 1024,
level4_notification_count= 2048,
level5_notification_count= 4096,
level1_reminder_interval= 8192,
level2_reminder_interval= 16384,
level3_reminder_interval= 32768,
level4_reminder_interval= 65536,
level5_reminder_interval= 131072,
level1_email_enabled= 262144,
level1_sms_enabled= 524288,
level1_fax_enabled= 1048576,
level2_email_enabled= 2097152,
level2_sms_enabled= 4194304,
level2_fax_enabled= 8388608,
level3_email_enabled= 16777216,
level3_sms_enabled= 33554432,
level3_fax_enabled= 67108864,
level4_email_enabled= 134217728,
level4_sms_enabled= 268435456,
level4_fax_enabled= 536870912,
level5_email_enabled= 1073741824,
level5_sms_enabled= 2147483648,
level5_fax_enabled= 4294967296
}
#endregion
public void BulkSave(List<AlertEscalation> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Alert_escalation";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AlertEscalation.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AlertEscalation> transList,ref DataTable dt)
{
foreach (AlertEscalation tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["alert_escalation_id"] =ConnectionFactory.GetNextId();
Row["alert_template_id"] = tran.AlertTemplateId;
Row["severity_id"] = tran.SeverityId;
Row["level0_duration"] = tran.Level0Duration;
Row["level1_duration"] = tran.Level1Duration;
Row["level2_duration"] = tran.Level2Duration;
Row["level3_duration"] = tran.Level3Duration;
Row["level4_duration"] = tran.Level4Duration;
Row["level1_notification_count"] = tran.Level1NotificationCount;
Row["level2_notification_count"] = tran.Level2NotificationCount;
Row["level3_notification_count"] = tran.Level3NotificationCount;
Row["level4_notification_count"] = tran.Level4NotificationCount;
Row["level5_notification_count"] = tran.Level5NotificationCount;
Row["level1_reminder_interval"] = tran.Level1ReminderInterval;
Row["level2_reminder_interval"] = tran.Level2ReminderInterval;
Row["level3_reminder_interval"] = tran.Level3ReminderInterval;
Row["level4_reminder_interval"] = tran.Level4ReminderInterval;
Row["level5_reminder_interval"] = tran.Level5ReminderInterval;
Row["level1_email_enabled"] = tran.Level1EmailEnabled;
Row["level1_sms_enabled"] = tran.Level1SmsEnabled;
Row["level1_fax_enabled"] = tran.Level1FaxEnabled;
Row["level2_email_enabled"] = tran.Level2EmailEnabled;
Row["level2_sms_enabled"] = tran.Level2SmsEnabled;
Row["level2_fax_enabled"] = tran.Level2FaxEnabled;
Row["level3_email_enabled"] = tran.Level3EmailEnabled;
Row["level3_sms_enabled"] = tran.Level3SmsEnabled;
Row["level3_fax_enabled"] = tran.Level3FaxEnabled;
Row["level4_email_enabled"] = tran.Level4EmailEnabled;
Row["level4_sms_enabled"] = tran.Level4SmsEnabled;
Row["level4_fax_enabled"] = tran.Level4FaxEnabled;
Row["level5_email_enabled"] = tran.Level5EmailEnabled;
Row["level5_sms_enabled"] = tran.Level5SmsEnabled;
Row["level5_fax_enabled"] = tran.Level5FaxEnabled;
dt.Rows.Add(Row);
} }
}
}
