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
public class AlertHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AlertHistory() { }
public AlertHistory( int alert_id,int log_id,int escalation_level,int reminder_no,int retries_left,bool is_sent,int user_id,int alert_interface ) 
{
this.log_id = log_id;
this.log_idChanged = true;
this.escalation_level = escalation_level;
this.escalation_levelChanged = true;
this.reminder_no = reminder_no;
this.reminder_noChanged = true;
this.retries_left = retries_left;
this.retries_leftChanged = true;
this.is_sent = is_sent;
this.is_sentChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.alert_interface = alert_interface;
this.alert_interfaceChanged = true;
}
public AlertHistory( int log_id,int escalation_level,int reminder_no,DateTime? sent_at,int retries_left,bool is_sent,int user_id,int alert_interface )
{
this.log_id = log_id;
this.log_idChanged = true;
this.escalation_level = escalation_level;
this.escalation_levelChanged = true;
this.reminder_no = reminder_no;
this.reminder_noChanged = true;
this.sent_at = sent_at;
this.sent_atChanged = true;
this.retries_left = retries_left;
this.retries_leftChanged = true;
this.is_sent = is_sent;
this.is_sentChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.alert_interface = alert_interface;
this.alert_interfaceChanged = true;
}
private AlertHistory( int alert_id,int log_id,int escalation_level,int reminder_no,DateTime? sent_at,int retries_left,bool is_sent,int user_id,int alert_interface )
{
this.alert_id = alert_id;
this.alert_idChanged = true;
this.log_id = log_id;
this.log_idChanged = true;
this.escalation_level = escalation_level;
this.escalation_levelChanged = true;
this.reminder_no = reminder_no;
this.reminder_noChanged = true;
this.sent_at = sent_at;
this.sent_atChanged = true;
this.retries_left = retries_left;
this.retries_leftChanged = true;
this.is_sent = is_sent;
this.is_sentChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.alert_interface = alert_interface;
this.alert_interfaceChanged = true;
}

#region members and properties for columns

#region AlertId
private bool alert_idChanged = false;
private int alert_id;
public int AlertId
{
get { return alert_id; }
set { 
alert_id = value;
alert_idChanged = true;
}
}
private string alert_idDbString
{
get
{
return alert_id.ToString();
}
}
#endregion
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
#region ReminderNo
private bool reminder_noChanged = false;
private int reminder_no;
public int ReminderNo
{
get { return reminder_no; }
set { 
reminder_no = value;
reminder_noChanged = true;
}
}
private string reminder_noDbString
{
get
{
return reminder_no.ToString();
}
}
#endregion
#region SentAt
private bool sent_atChanged = false;
private DateTime? sent_at;
public DateTime? SentAt
{
get { return sent_at; }
set { 
sent_at = value;
sent_atChanged = true;
}
}
private string sent_atDbString
{
get
{
if (this.sent_at.HasValue)
return string.Format("Convert(datetime,'{0}',121)",sent_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region RetriesLeft
private bool retries_leftChanged = false;
private int retries_left;
public int RetriesLeft
{
get { return retries_left; }
set { 
retries_left = value;
retries_leftChanged = true;
}
}
private string retries_leftDbString
{
get
{
return retries_left.ToString();
}
}
#endregion
#region IsSent
private bool is_sentChanged = false;
private bool is_sent;
public bool IsSent
{
get { return is_sent; }
set { 
is_sent = value;
is_sentChanged = true;
}
}
private string is_sentDbString
{
get
{
return is_sent?"1":"0";
}
}
#endregion
#region UserId
private bool user_idChanged = false;
private int user_id;
public int UserId
{
get { return user_id; }
set { 
user_id = value;
user_idChanged = true;
}
}
private string user_idDbString
{
get
{
return user_id.ToString();
}
}
#endregion
#region AlertInterface
private bool alert_interfaceChanged = false;
private int alert_interface;
public int AlertInterface
{
get { return alert_interface; }
set { 
alert_interface = value;
alert_interfaceChanged = true;
}
}
private string alert_interfaceDbString
{
get
{
return alert_interface.ToString();
}
}
#endregion
#endregion

#region AlertHistoryReader
public class AlertHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AlertHistory currentAlertHistory;
Columns columns;
bool partialRead = false;
private AlertHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AlertHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AlertHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAlertHistory; }

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
currentAlertHistory = new AlertHistory();
if (partialRead)
{ if ((columns & Columns.alert_id) == Columns.alert_id && reader["alert_id"]!=DBNull.Value)
currentAlertHistory.alert_id =(int) reader["alert_id"]; 
if ((columns & Columns.log_id) == Columns.log_id && reader["log_id"]!=DBNull.Value)
currentAlertHistory.log_id =(int) reader["log_id"]; 
if ((columns & Columns.escalation_level) == Columns.escalation_level && reader["escalation_level"]!=DBNull.Value)
currentAlertHistory.escalation_level =(int) reader["escalation_level"]; 
if ((columns & Columns.reminder_no) == Columns.reminder_no && reader["reminder_no"]!=DBNull.Value)
currentAlertHistory.reminder_no =(int) reader["reminder_no"]; 
if ((columns & Columns.sent_at) == Columns.sent_at && reader["sent_at"]!=DBNull.Value)
currentAlertHistory.sent_at =(DateTime?) reader["sent_at"]; 
if ((columns & Columns.retries_left) == Columns.retries_left && reader["retries_left"]!=DBNull.Value)
currentAlertHistory.retries_left =(int) reader["retries_left"]; 
if ((columns & Columns.is_sent) == Columns.is_sent && reader["is_sent"]!=DBNull.Value)
currentAlertHistory.is_sent =(bool) reader["is_sent"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentAlertHistory.user_id =(int) reader["user_id"]; 
if ((columns & Columns.alert_interface) == Columns.alert_interface && reader["alert_interface"]!=DBNull.Value)
currentAlertHistory.alert_interface =(int) reader["alert_interface"]; 

} else
{
if (reader["alert_id"] != DBNull.Value)
currentAlertHistory.alert_id = (int) reader["alert_id"]; 
if (reader["log_id"] != DBNull.Value)
currentAlertHistory.log_id = (int) reader["log_id"]; 
if (reader["escalation_level"] != DBNull.Value)
currentAlertHistory.escalation_level = (int) reader["escalation_level"]; 
if (reader["reminder_no"] != DBNull.Value)
currentAlertHistory.reminder_no = (int) reader["reminder_no"]; 
if (reader["sent_at"] != DBNull.Value)
currentAlertHistory.sent_at = (DateTime?) reader["sent_at"]; 
if (reader["retries_left"] != DBNull.Value)
currentAlertHistory.retries_left = (int) reader["retries_left"]; 
if (reader["is_sent"] != DBNull.Value)
currentAlertHistory.is_sent = (bool) reader["is_sent"]; 
if (reader["user_id"] != DBNull.Value)
currentAlertHistory.user_id = (int) reader["user_id"]; 
if (reader["alert_interface"] != DBNull.Value)
currentAlertHistory.alert_interface = (int) reader["alert_interface"]; 
} 

currentAlertHistory.isNewEntity = false;
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

public AlertHistory CurrentAlertHistory
{
get{ return currentAlertHistory; }
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


#region AlertHistory functions

public static AlertHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.alert_id == (Columns.alert_id & columns))
qry.Append("alert_id,");
if (Columns.log_id == (Columns.log_id & columns))
qry.Append("log_id,");
if (Columns.escalation_level == (Columns.escalation_level & columns))
qry.Append("escalation_level,");
if (Columns.reminder_no == (Columns.reminder_no & columns))
qry.Append("reminder_no,");
if (Columns.sent_at == (Columns.sent_at & columns))
qry.Append("sent_at,");
if (Columns.retries_left == (Columns.retries_left & columns))
qry.Append("retries_left,");
if (Columns.is_sent == (Columns.is_sent & columns))
qry.Append("is_sent,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.alert_interface == (Columns.alert_interface & columns))
qry.Append("alert_interface,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Alert_history ");

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
return new AlertHistoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AlertHistoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AlertHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select alert_id,log_id,escalation_level,reminder_no,sent_at,retries_left,is_sent,user_id,alert_interface from Alert_history ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AlertHistoryReader(cmd.ExecuteReader(), conn);
}

static public AlertHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AlertHistory LoadAlertHistory(string where)
{
AlertHistoryReader reader = AlertHistory.ExecuteReader(where);
AlertHistory _alerthistory = null;
if (reader.Read())
_alerthistory = reader.CurrentAlertHistory;
reader.Close();
return _alerthistory;
}

public static AlertHistory LoadAlertHistory(string where, IDbConnection conn)
{
AlertHistoryReader reader = AlertHistory.ExecuteReader(where, conn);
AlertHistory _alerthistory = null;
if (reader.Read())
_alerthistory = reader.CurrentAlertHistory;
reader.Close(false);
return _alerthistory;
}

public static AlertHistory LoadAlertHistoryByPk( int alert_id )
{
return LoadAlertHistory( " alert_id="+alert_id );
}

public static AlertHistory LoadAlertHistoryByPk( int alert_id , IDbConnection conn)
{
return LoadAlertHistory(" alert_id="+alert_id , conn);
}

public void Save()
{
if (alert_idChanged || log_idChanged || escalation_levelChanged || reminder_noChanged || sent_atChanged || retries_leftChanged || is_sentChanged || user_idChanged || alert_interfaceChanged )
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
if (alert_idChanged || log_idChanged || escalation_levelChanged || reminder_noChanged || sent_atChanged || retries_leftChanged || is_sentChanged || user_idChanged || alert_interfaceChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Alert_history( alert_id,log_id,escalation_level,reminder_no,sent_at,retries_left,is_sent,user_id,alert_interface ) values(");
lock (ConnectionFactory.connectionString) { this.alert_id = ConnectionFactory.GetNextId();
qry.Append(this.alert_id);
} qry.Append(",");
qry.Append(log_idDbString+",");
qry.Append(escalation_levelDbString+",");
qry.Append(reminder_noDbString+",");
qry.Append(sent_atDbString+",");
qry.Append(retries_leftDbString+",");
qry.Append(is_sentDbString+",");
qry.Append(user_idDbString+",");
qry.Append(alert_interfaceDbString);
qry.Append(");");

}
else
{
if (!(alert_idChanged || log_idChanged || escalation_levelChanged || reminder_noChanged || sent_atChanged || retries_leftChanged || is_sentChanged || user_idChanged || alert_interfaceChanged ))
return;
qry.Append("UPDATE Alert_history set "); if ( log_idChanged )
{
qry.Append("log_id ="+log_idDbString);
qry.Append(",");
}

if ( escalation_levelChanged )
{
qry.Append("escalation_level ="+escalation_levelDbString);
qry.Append(",");
}

if ( reminder_noChanged )
{
qry.Append("reminder_no ="+reminder_noDbString);
qry.Append(",");
}

if ( sent_atChanged )
{
qry.Append("sent_at ="+sent_atDbString);
qry.Append(",");
}

if ( retries_leftChanged )
{
qry.Append("retries_left ="+retries_leftDbString);
qry.Append(",");
}

if ( is_sentChanged )
{
qry.Append("is_sent ="+is_sentDbString);
qry.Append(",");
}

if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( alert_interfaceChanged )
{
qry.Append("alert_interface ="+alert_interfaceDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("alert_id = "+alert_idDbString);
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
cmd.CommandText = "DELETE Alert_history where alert_id = "+ alert_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAlertHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Alert_history where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
alert_id= 1,
log_id= 2,
escalation_level= 4,
reminder_no= 8,
sent_at= 16,
retries_left= 32,
is_sent= 64,
user_id= 128,
alert_interface= 256
}
#endregion
public void BulkSave(List<AlertHistory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Alert_history";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AlertHistory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AlertHistory> transList,ref DataTable dt)
{
foreach (AlertHistory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["alert_id"] =ConnectionFactory.GetNextId();
Row["log_id"] = tran.LogId;
Row["escalation_level"] = tran.EscalationLevel;
Row["reminder_no"] = tran.ReminderNo;
Row["sent_at"] = tran.SentAt;
Row["retries_left"] = tran.RetriesLeft;
Row["is_sent"] = tran.IsSent;
Row["user_id"] = tran.UserId;
Row["alert_interface"] = tran.AlertInterface;
dt.Rows.Add(Row);
} }
}
}
