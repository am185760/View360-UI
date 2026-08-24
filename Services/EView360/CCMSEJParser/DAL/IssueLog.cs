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
public class IssueLog
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public IssueLog() { }
public IssueLog( int log_id,string ticket_id,int atm_id,string issue_desc,DateTime reported_at,bool is_resolved,int escalation_level,DateTime next_escalated_at,byte reminders_left_level1,byte reminders_left_level2,byte reminders_left_level3,byte reminders_left_level4,byte reminders_left_level5 ) 
{
this.ticket_id = ticket_id;
this.ticket_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.issue_desc = issue_desc;
this.issue_descChanged = true;
this.reported_at = reported_at;
this.reported_atChanged = true;
this.is_resolved = is_resolved;
this.is_resolvedChanged = true;
this.escalation_level = escalation_level;
this.escalation_levelChanged = true;
this.next_escalated_at = next_escalated_at;
this.next_escalated_atChanged = true;
this.reminders_left_level1 = reminders_left_level1;
this.reminders_left_level1Changed = true;
this.reminders_left_level2 = reminders_left_level2;
this.reminders_left_level2Changed = true;
this.reminders_left_level3 = reminders_left_level3;
this.reminders_left_level3Changed = true;
this.reminders_left_level4 = reminders_left_level4;
this.reminders_left_level4Changed = true;
this.reminders_left_level5 = reminders_left_level5;
this.reminders_left_level5Changed = true;
}
public IssueLog( string ticket_id,int atm_id,int? device_id,string issue_desc,DateTime reported_at,bool is_resolved,DateTime? resolution_time,int? resolved_by,int escalation_level,DateTime next_escalated_at,byte reminders_left_level1,byte reminders_left_level2,byte reminders_left_level3,byte reminders_left_level4,byte reminders_left_level5 )
{
this.ticket_id = ticket_id;
this.ticket_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.issue_desc = issue_desc;
this.issue_descChanged = true;
this.reported_at = reported_at;
this.reported_atChanged = true;
this.is_resolved = is_resolved;
this.is_resolvedChanged = true;
this.resolution_time = resolution_time;
this.resolution_timeChanged = true;
this.resolved_by = resolved_by;
this.resolved_byChanged = true;
this.escalation_level = escalation_level;
this.escalation_levelChanged = true;
this.next_escalated_at = next_escalated_at;
this.next_escalated_atChanged = true;
this.reminders_left_level1 = reminders_left_level1;
this.reminders_left_level1Changed = true;
this.reminders_left_level2 = reminders_left_level2;
this.reminders_left_level2Changed = true;
this.reminders_left_level3 = reminders_left_level3;
this.reminders_left_level3Changed = true;
this.reminders_left_level4 = reminders_left_level4;
this.reminders_left_level4Changed = true;
this.reminders_left_level5 = reminders_left_level5;
this.reminders_left_level5Changed = true;
}
private IssueLog( int log_id,string ticket_id,int atm_id,int? device_id,string issue_desc,DateTime reported_at,bool is_resolved,DateTime? resolution_time,int? resolved_by,int escalation_level,DateTime next_escalated_at,byte reminders_left_level1,byte reminders_left_level2,byte reminders_left_level3,byte reminders_left_level4,byte reminders_left_level5 )
{
this.log_id = log_id;
this.log_idChanged = true;
this.ticket_id = ticket_id;
this.ticket_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.issue_desc = issue_desc;
this.issue_descChanged = true;
this.reported_at = reported_at;
this.reported_atChanged = true;
this.is_resolved = is_resolved;
this.is_resolvedChanged = true;
this.resolution_time = resolution_time;
this.resolution_timeChanged = true;
this.resolved_by = resolved_by;
this.resolved_byChanged = true;
this.escalation_level = escalation_level;
this.escalation_levelChanged = true;
this.next_escalated_at = next_escalated_at;
this.next_escalated_atChanged = true;
this.reminders_left_level1 = reminders_left_level1;
this.reminders_left_level1Changed = true;
this.reminders_left_level2 = reminders_left_level2;
this.reminders_left_level2Changed = true;
this.reminders_left_level3 = reminders_left_level3;
this.reminders_left_level3Changed = true;
this.reminders_left_level4 = reminders_left_level4;
this.reminders_left_level4Changed = true;
this.reminders_left_level5 = reminders_left_level5;
this.reminders_left_level5Changed = true;
}

#region members and properties for columns

#region LogId
private bool log_idChanged = false;
private int log_id;
public int LogId
{
get { return log_id; }
set { 
log_id = value;
log_idChanged = true;
}
}
private string log_idDbString
{
get
{
return log_id.ToString();
}
}
#endregion
#region TicketId
private bool ticket_idChanged = false;
private string ticket_id;
public string TicketId
{
get { return ticket_id; }
set { 
ticket_id = value;
ticket_idChanged = true;
}
}
private string ticket_idDbString
{
get
{
if (this.ticket_id!=null)
return string.Format("'{0}'",ticket_id); else
return "null";
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
#region DeviceId
private bool device_idChanged = false;
private int? device_id;
public int? DeviceId
{
get { return device_id; }
set { 
device_id = value;
device_idChanged = true;
}
}
private string device_idDbString
{
get
{
if (this.device_id.HasValue)
return device_id.ToString();
else
return "null";
}
}
#endregion
#region IssueDesc
private bool issue_descChanged = false;
private string issue_desc;
public string IssueDesc
{
get { return issue_desc; }
set { 
issue_desc = value;
issue_descChanged = true;
}
}
private string issue_descDbString
{
get
{
if (this.issue_desc!=null)
return string.Format("'{0}'",issue_desc); else
return "null";
}
}
#endregion
#region ReportedAt
private bool reported_atChanged = false;
private DateTime reported_at;
public DateTime ReportedAt
{
get { return reported_at; }
set { 
reported_at = value;
reported_atChanged = true;
}
}
private string reported_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",reported_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region IsResolved
private bool is_resolvedChanged = false;
private bool is_resolved;
public bool IsResolved
{
get { return is_resolved; }
set { 
is_resolved = value;
is_resolvedChanged = true;
}
}
private string is_resolvedDbString
{
get
{
return is_resolved?"1":"0";
}
}
#endregion
#region ResolutionTime
private bool resolution_timeChanged = false;
private DateTime? resolution_time;
public DateTime? ResolutionTime
{
get { return resolution_time; }
set { 
resolution_time = value;
resolution_timeChanged = true;
}
}
private string resolution_timeDbString
{
get
{
if (this.resolution_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",resolution_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ResolvedBy
private bool resolved_byChanged = false;
private int? resolved_by;
public int? ResolvedBy
{
get { return resolved_by; }
set { 
resolved_by = value;
resolved_byChanged = true;
}
}
private string resolved_byDbString
{
get
{
if (this.resolved_by.HasValue)
return resolved_by.ToString();
else
return "null";
}
}
#endregion
#region EscalationLevel
private bool escalation_levelChanged = false;
private int escalation_level;
public int EscalationLevel
{
get { return escalation_level; }
set { 
escalation_level = value;
escalation_levelChanged = true;
}
}
private string escalation_levelDbString
{
get
{
return escalation_level.ToString();
}
}
#endregion
#region NextEscalatedAt
private bool next_escalated_atChanged = false;
private DateTime next_escalated_at;
public DateTime NextEscalatedAt
{
get { return next_escalated_at; }
set { 
next_escalated_at = value;
next_escalated_atChanged = true;
}
}
private string next_escalated_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",next_escalated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region RemindersLeftLevel1
private bool reminders_left_level1Changed = false;
private byte reminders_left_level1;
public byte RemindersLeftLevel1
{
get { return reminders_left_level1; }
set { 
reminders_left_level1 = value;
reminders_left_level1Changed = true;
}
}
private string reminders_left_level1DbString
{
get
{
return reminders_left_level1.ToString();
}
}
#endregion
#region RemindersLeftLevel2
private bool reminders_left_level2Changed = false;
private byte reminders_left_level2;
public byte RemindersLeftLevel2
{
get { return reminders_left_level2; }
set { 
reminders_left_level2 = value;
reminders_left_level2Changed = true;
}
}
private string reminders_left_level2DbString
{
get
{
return reminders_left_level2.ToString();
}
}
#endregion
#region RemindersLeftLevel3
private bool reminders_left_level3Changed = false;
private byte reminders_left_level3;
public byte RemindersLeftLevel3
{
get { return reminders_left_level3; }
set { 
reminders_left_level3 = value;
reminders_left_level3Changed = true;
}
}
private string reminders_left_level3DbString
{
get
{
return reminders_left_level3.ToString();
}
}
#endregion
#region RemindersLeftLevel4
private bool reminders_left_level4Changed = false;
private byte reminders_left_level4;
public byte RemindersLeftLevel4
{
get { return reminders_left_level4; }
set { 
reminders_left_level4 = value;
reminders_left_level4Changed = true;
}
}
private string reminders_left_level4DbString
{
get
{
return reminders_left_level4.ToString();
}
}
#endregion
#region RemindersLeftLevel5
private bool reminders_left_level5Changed = false;
private byte reminders_left_level5;
public byte RemindersLeftLevel5
{
get { return reminders_left_level5; }
set { 
reminders_left_level5 = value;
reminders_left_level5Changed = true;
}
}
private string reminders_left_level5DbString
{
get
{
return reminders_left_level5.ToString();
}
}
#endregion
#endregion

#region IssueLogReader
public class IssueLogReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
IssueLog currentIssueLog;
Columns columns;
bool partialRead = false;
private IssueLogReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public IssueLogReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public IssueLogReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentIssueLog; }

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
currentIssueLog = new IssueLog();
if (partialRead)
{ if ((columns & Columns.log_id) == Columns.log_id && reader["log_id"]!=DBNull.Value)
currentIssueLog.log_id =(int) reader["log_id"]; 
if ((columns & Columns.ticket_id) == Columns.ticket_id && reader["ticket_id"]!=DBNull.Value)
currentIssueLog.ticket_id =(string) reader["ticket_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentIssueLog.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentIssueLog.device_id =(int?) reader["device_id"]; 
if ((columns & Columns.issue_desc) == Columns.issue_desc && reader["issue_desc"]!=DBNull.Value)
currentIssueLog.issue_desc =(string) reader["issue_desc"]; 
if ((columns & Columns.reported_at) == Columns.reported_at && reader["reported_at"]!=DBNull.Value)
currentIssueLog.reported_at =(DateTime) reader["reported_at"]; 
if ((columns & Columns.is_resolved) == Columns.is_resolved && reader["is_resolved"]!=DBNull.Value)
currentIssueLog.is_resolved =(bool) reader["is_resolved"]; 
if ((columns & Columns.resolution_time) == Columns.resolution_time && reader["resolution_time"]!=DBNull.Value)
currentIssueLog.resolution_time =(DateTime?) reader["resolution_time"]; 
if ((columns & Columns.resolved_by) == Columns.resolved_by && reader["resolved_by"]!=DBNull.Value)
currentIssueLog.resolved_by =(int?) reader["resolved_by"]; 
if ((columns & Columns.escalation_level) == Columns.escalation_level && reader["escalation_level"]!=DBNull.Value)
currentIssueLog.escalation_level =(int) reader["escalation_level"]; 
if ((columns & Columns.next_escalated_at) == Columns.next_escalated_at && reader["next_escalated_at"]!=DBNull.Value)
currentIssueLog.next_escalated_at =(DateTime) reader["next_escalated_at"]; 
if ((columns & Columns.reminders_left_level1) == Columns.reminders_left_level1 && reader["reminders_left_level1"]!=DBNull.Value)
currentIssueLog.reminders_left_level1 =(byte) reader["reminders_left_level1"]; 
if ((columns & Columns.reminders_left_level2) == Columns.reminders_left_level2 && reader["reminders_left_level2"]!=DBNull.Value)
currentIssueLog.reminders_left_level2 =(byte) reader["reminders_left_level2"]; 
if ((columns & Columns.reminders_left_level3) == Columns.reminders_left_level3 && reader["reminders_left_level3"]!=DBNull.Value)
currentIssueLog.reminders_left_level3 =(byte) reader["reminders_left_level3"]; 
if ((columns & Columns.reminders_left_level4) == Columns.reminders_left_level4 && reader["reminders_left_level4"]!=DBNull.Value)
currentIssueLog.reminders_left_level4 =(byte) reader["reminders_left_level4"]; 
if ((columns & Columns.reminders_left_level5) == Columns.reminders_left_level5 && reader["reminders_left_level5"]!=DBNull.Value)
currentIssueLog.reminders_left_level5 =(byte) reader["reminders_left_level5"]; 

} else
{
if (reader["log_id"] != DBNull.Value)
currentIssueLog.log_id = (int) reader["log_id"]; 
if (reader["ticket_id"] != DBNull.Value)
currentIssueLog.ticket_id = (string) reader["ticket_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentIssueLog.atm_id = (int) reader["atm_id"]; 
if (reader["device_id"] != DBNull.Value)
currentIssueLog.device_id = (int?) reader["device_id"]; 
if (reader["issue_desc"] != DBNull.Value)
currentIssueLog.issue_desc = (string) reader["issue_desc"]; 
if (reader["reported_at"] != DBNull.Value)
currentIssueLog.reported_at = (DateTime) reader["reported_at"]; 
if (reader["is_resolved"] != DBNull.Value)
currentIssueLog.is_resolved = (bool) reader["is_resolved"]; 
if (reader["resolution_time"] != DBNull.Value)
currentIssueLog.resolution_time = (DateTime?) reader["resolution_time"]; 
if (reader["resolved_by"] != DBNull.Value)
currentIssueLog.resolved_by = (int?) reader["resolved_by"]; 
if (reader["escalation_level"] != DBNull.Value)
currentIssueLog.escalation_level = (int) reader["escalation_level"]; 
if (reader["next_escalated_at"] != DBNull.Value)
currentIssueLog.next_escalated_at = (DateTime) reader["next_escalated_at"]; 
if (reader["reminders_left_level1"] != DBNull.Value)
currentIssueLog.reminders_left_level1 = (byte) reader["reminders_left_level1"]; 
if (reader["reminders_left_level2"] != DBNull.Value)
currentIssueLog.reminders_left_level2 = (byte) reader["reminders_left_level2"]; 
if (reader["reminders_left_level3"] != DBNull.Value)
currentIssueLog.reminders_left_level3 = (byte) reader["reminders_left_level3"]; 
if (reader["reminders_left_level4"] != DBNull.Value)
currentIssueLog.reminders_left_level4 = (byte) reader["reminders_left_level4"]; 
if (reader["reminders_left_level5"] != DBNull.Value)
currentIssueLog.reminders_left_level5 = (byte) reader["reminders_left_level5"]; 
} 

currentIssueLog.isNewEntity = false;
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

public IssueLog CurrentIssueLog
{
get{ return currentIssueLog; }
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


#region IssueLog functions

public static IssueLogReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.log_id == (Columns.log_id & columns))
qry.Append("log_id,");
if (Columns.ticket_id == (Columns.ticket_id & columns))
qry.Append("ticket_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.issue_desc == (Columns.issue_desc & columns))
qry.Append("issue_desc,");
if (Columns.reported_at == (Columns.reported_at & columns))
qry.Append("reported_at,");
if (Columns.is_resolved == (Columns.is_resolved & columns))
qry.Append("is_resolved,");
if (Columns.resolution_time == (Columns.resolution_time & columns))
qry.Append("resolution_time,");
if (Columns.resolved_by == (Columns.resolved_by & columns))
qry.Append("resolved_by,");
if (Columns.escalation_level == (Columns.escalation_level & columns))
qry.Append("escalation_level,");
if (Columns.next_escalated_at == (Columns.next_escalated_at & columns))
qry.Append("next_escalated_at,");
if (Columns.reminders_left_level1 == (Columns.reminders_left_level1 & columns))
qry.Append("reminders_left_level1,");
if (Columns.reminders_left_level2 == (Columns.reminders_left_level2 & columns))
qry.Append("reminders_left_level2,");
if (Columns.reminders_left_level3 == (Columns.reminders_left_level3 & columns))
qry.Append("reminders_left_level3,");
if (Columns.reminders_left_level4 == (Columns.reminders_left_level4 & columns))
qry.Append("reminders_left_level4,");
if (Columns.reminders_left_level5 == (Columns.reminders_left_level5 & columns))
qry.Append("reminders_left_level5,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Issue_log ");

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
return new IssueLogReader(cmd.ExecuteReader(), conn, columns);
}

static public IssueLogReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static IssueLogReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select log_id,ticket_id,atm_id,device_id,issue_desc,reported_at,is_resolved,resolution_time,resolved_by,escalation_level,next_escalated_at,reminders_left_level1,reminders_left_level2,reminders_left_level3,reminders_left_level4,reminders_left_level5 from Issue_log ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new IssueLogReader(cmd.ExecuteReader(), conn);
}

static public IssueLogReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static IssueLog LoadIssueLog(string where)
{
IssueLogReader reader = IssueLog.ExecuteReader(where);
IssueLog _issuelog = null;
if (reader.Read())
_issuelog = reader.CurrentIssueLog;
reader.Close();
return _issuelog;
}

public static IssueLog LoadIssueLog(string where, IDbConnection conn)
{
IssueLogReader reader = IssueLog.ExecuteReader(where, conn);
IssueLog _issuelog = null;
if (reader.Read())
_issuelog = reader.CurrentIssueLog;
reader.Close(false);
return _issuelog;
}

public static IssueLog LoadIssueLogByPk( int log_id )
{
return LoadIssueLog( " log_id="+log_id );
}

public static IssueLog LoadIssueLogByPk( int log_id , IDbConnection conn)
{
return LoadIssueLog(" log_id="+log_id , conn);
}

public void Save()
{
if (log_idChanged || ticket_idChanged || atm_idChanged || device_idChanged || issue_descChanged || reported_atChanged || is_resolvedChanged || resolution_timeChanged || resolved_byChanged || escalation_levelChanged || next_escalated_atChanged || reminders_left_level1Changed || reminders_left_level2Changed || reminders_left_level3Changed || reminders_left_level4Changed || reminders_left_level5Changed )
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
if (log_idChanged || ticket_idChanged || atm_idChanged || device_idChanged || issue_descChanged || reported_atChanged || is_resolvedChanged || resolution_timeChanged || resolved_byChanged || escalation_levelChanged || next_escalated_atChanged || reminders_left_level1Changed || reminders_left_level2Changed || reminders_left_level3Changed || reminders_left_level4Changed || reminders_left_level5Changed )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Issue_log( log_id,ticket_id,atm_id,device_id,issue_desc,reported_at,is_resolved,resolution_time,resolved_by,escalation_level,next_escalated_at,reminders_left_level1,reminders_left_level2,reminders_left_level3,reminders_left_level4,reminders_left_level5 ) values(");
lock (ConnectionFactory.connectionString) { this.log_id = ConnectionFactory.GetNextId();
qry.Append(this.log_id);
} qry.Append(",");
qry.Append(ticket_idDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(device_idDbString+",");
qry.Append(issue_descDbString+",");
qry.Append(reported_atDbString+",");
qry.Append(is_resolvedDbString+",");
qry.Append(resolution_timeDbString+",");
qry.Append(resolved_byDbString+",");
qry.Append(escalation_levelDbString+",");
qry.Append(next_escalated_atDbString+",");
qry.Append(reminders_left_level1DbString+",");
qry.Append(reminders_left_level2DbString+",");
qry.Append(reminders_left_level3DbString+",");
qry.Append(reminders_left_level4DbString+",");
qry.Append(reminders_left_level5DbString);
qry.Append(");");

}
else
{
if (!(log_idChanged || ticket_idChanged || atm_idChanged || device_idChanged || issue_descChanged || reported_atChanged || is_resolvedChanged || resolution_timeChanged || resolved_byChanged || escalation_levelChanged || next_escalated_atChanged || reminders_left_level1Changed || reminders_left_level2Changed || reminders_left_level3Changed || reminders_left_level4Changed || reminders_left_level5Changed ))
return;
qry.Append("UPDATE Issue_log set "); if ( ticket_idChanged )
{
qry.Append("ticket_id ="+ticket_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( device_idChanged )
{
qry.Append("device_id ="+device_idDbString);
qry.Append(",");
}

if ( issue_descChanged )
{
qry.Append("issue_desc ="+issue_descDbString);
qry.Append(",");
}

if ( reported_atChanged )
{
qry.Append("reported_at ="+reported_atDbString);
qry.Append(",");
}

if ( is_resolvedChanged )
{
qry.Append("is_resolved ="+is_resolvedDbString);
qry.Append(",");
}

if ( resolution_timeChanged )
{
qry.Append("resolution_time ="+resolution_timeDbString);
qry.Append(",");
}

if ( resolved_byChanged )
{
qry.Append("resolved_by ="+resolved_byDbString);
qry.Append(",");
}

if ( escalation_levelChanged )
{
qry.Append("escalation_level ="+escalation_levelDbString);
qry.Append(",");
}

if ( next_escalated_atChanged )
{
qry.Append("next_escalated_at ="+next_escalated_atDbString);
qry.Append(",");
}

if ( reminders_left_level1Changed )
{
qry.Append("reminders_left_level1 ="+reminders_left_level1DbString);
qry.Append(",");
}

if ( reminders_left_level2Changed )
{
qry.Append("reminders_left_level2 ="+reminders_left_level2DbString);
qry.Append(",");
}

if ( reminders_left_level3Changed )
{
qry.Append("reminders_left_level3 ="+reminders_left_level3DbString);
qry.Append(",");
}

if ( reminders_left_level4Changed )
{
qry.Append("reminders_left_level4 ="+reminders_left_level4DbString);
qry.Append(",");
}

if ( reminders_left_level5Changed )
{
qry.Append("reminders_left_level5 ="+reminders_left_level5DbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("log_id = "+log_idDbString);
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
cmd.CommandText = "DELETE Issue_log where log_id = "+ log_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteIssueLogs(string where)
{
ConnectionFactory.ExecuteQuery("delete Issue_log where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
log_id= 1,
ticket_id= 2,
atm_id= 4,
device_id= 8,
issue_desc= 16,
reported_at= 32,
is_resolved= 64,
resolution_time= 128,
resolved_by= 256,
escalation_level= 512,
next_escalated_at= 1024,
reminders_left_level1= 2048,
reminders_left_level2= 4096,
reminders_left_level3= 8192,
reminders_left_level4= 16384,
reminders_left_level5= 32768
}
#endregion
public void BulkSave(List<IssueLog> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Issue_log";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(IssueLog.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <IssueLog> transList,ref DataTable dt)
{
foreach (IssueLog tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["log_id"] =ConnectionFactory.GetNextId();
Row["ticket_id"] = tran.TicketId;
Row["atm_id"] = tran.AtmId;
Row["device_id"] = tran.DeviceId;
Row["issue_desc"] = tran.IssueDesc;
Row["reported_at"] = tran.ReportedAt;
Row["is_resolved"] = tran.IsResolved;
Row["resolution_time"] = tran.ResolutionTime;
Row["resolved_by"] = tran.ResolvedBy;
Row["escalation_level"] = tran.EscalationLevel;
Row["next_escalated_at"] = tran.NextEscalatedAt;
Row["reminders_left_level1"] = tran.RemindersLeftLevel1;
Row["reminders_left_level2"] = tran.RemindersLeftLevel2;
Row["reminders_left_level3"] = tran.RemindersLeftLevel3;
Row["reminders_left_level4"] = tran.RemindersLeftLevel4;
Row["reminders_left_level5"] = tran.RemindersLeftLevel5;
dt.Rows.Add(Row);
} }
}
}
