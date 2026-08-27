using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;

namespace Avanza.CCMS.DAL
{
[Serializable()]
public class ConfigurationInfo
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ConfigurationInfo() { }
public ConfigurationInfo( int? configuration_info_id,int? task_type_id,int? retry_count ) 
{
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
this.retry_count = retry_count;
this.retry_countChanged = true;
}
public ConfigurationInfo( int? task_type_id,int? retry_count,DateTime? last_invoked_at,string failure_reason,bool? status,int? atm_id )
{
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
this.retry_count = retry_count;
this.retry_countChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.status = status;
this.statusChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private ConfigurationInfo( int? configuration_info_id,int? task_type_id,int? retry_count,DateTime? last_invoked_at,string failure_reason,bool? status,int? atm_id )
{
this.configuration_info_id = configuration_info_id;
this.configuration_info_idChanged = true;
this.task_type_id = task_type_id;
this.task_type_idChanged = true;
this.retry_count = retry_count;
this.retry_countChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.failure_reason = failure_reason;
this.failure_reasonChanged = true;
this.status = status;
this.statusChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region ConfigurationInfoId
private bool configuration_info_idChanged = false;
private int? configuration_info_id;
public int? ConfigurationInfoId
{
get { return configuration_info_id; }
set { 
configuration_info_id = value;
configuration_info_idChanged = true;
}
}
private string configuration_info_idDbString
{
get
{
if (this.configuration_info_id.HasValue)
return configuration_info_id.ToString();
else
return "null";
}
}
#endregion
#region TaskTypeId
private bool task_type_idChanged = false;
private int? task_type_id;
public int? TaskTypeId
{
get { return task_type_id; }
set { 
task_type_id = value;
task_type_idChanged = true;
}
}
private string task_type_idDbString
{
get
{
if (this.task_type_id.HasValue)
return task_type_id.ToString();
else
return "null";
}
}
#endregion
#region RetryCount
private bool retry_countChanged = false;
private int? retry_count;
public int? RetryCount
{
get { return retry_count; }
set { 
retry_count = value;
retry_countChanged = true;
}
}
private string retry_countDbString
{
get
{
if (this.retry_count.HasValue)
return retry_count.ToString();
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
#region Status
private bool statusChanged = false;
private bool? status;
public bool? Status
{
get { return status; }
set { 
status = value;
statusChanged = true;
}
}
private string statusDbString
{
get
{
if (this.status.HasValue)
return status.Value?"1":"0";
else
return "null";
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int? atm_id;
public int? AtmId
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
#endregion

#region ConfigurationInfoReader
public class ConfigurationInfoReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ConfigurationInfo currentConfigurationInfo;
Columns columns;
bool partialRead = false;
private ConfigurationInfoReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ConfigurationInfoReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ConfigurationInfoReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentConfigurationInfo; }

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
currentConfigurationInfo = new ConfigurationInfo();
if (partialRead)
{ if ((columns & Columns.configuration_info_id) == Columns.configuration_info_id && reader["configuration_info_id"]!=DBNull.Value)
currentConfigurationInfo.configuration_info_id =(int?) reader["configuration_info_id"]; 
if ((columns & Columns.task_type_id) == Columns.task_type_id && reader["task_type_id"]!=DBNull.Value)
currentConfigurationInfo.task_type_id =(int?) reader["task_type_id"]; 
if ((columns & Columns.retry_count) == Columns.retry_count && reader["retry_count"]!=DBNull.Value)
currentConfigurationInfo.retry_count =(int?) reader["retry_count"]; 
if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"]!=DBNull.Value)
currentConfigurationInfo.last_invoked_at =(DateTime?) reader["last_invoked_at"]; 
if ((columns & Columns.failure_reason) == Columns.failure_reason && reader["failure_reason"]!=DBNull.Value)
currentConfigurationInfo.failure_reason =(string) reader["failure_reason"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentConfigurationInfo.status =(bool?) reader["status"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentConfigurationInfo.atm_id =(int?) reader["atm_id"]; 

} else
{
if (reader["configuration_info_id"] != DBNull.Value)
currentConfigurationInfo.configuration_info_id = (int?) reader["configuration_info_id"]; 
if (reader["task_type_id"] != DBNull.Value)
currentConfigurationInfo.task_type_id = (int?) reader["task_type_id"]; 
if (reader["retry_count"] != DBNull.Value)
currentConfigurationInfo.retry_count = (int?) reader["retry_count"]; 
if (reader["last_invoked_at"] != DBNull.Value)
currentConfigurationInfo.last_invoked_at = (DateTime?) reader["last_invoked_at"]; 
if (reader["failure_reason"] != DBNull.Value)
currentConfigurationInfo.failure_reason = (string) reader["failure_reason"]; 
if (reader["status"] != DBNull.Value)
currentConfigurationInfo.status = (bool?) reader["status"]; 
if (reader["atm_id"] != DBNull.Value)
currentConfigurationInfo.atm_id = (int?) reader["atm_id"]; 
} 

currentConfigurationInfo.isNewEntity = false;
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

public ConfigurationInfo CurrentConfigurationInfo
{
get{ return currentConfigurationInfo; }
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


#region ConfigurationInfo functions

public static ConfigurationInfoReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.configuration_info_id == (Columns.configuration_info_id & columns))
qry.Append("configuration_info_id,");
if (Columns.task_type_id == (Columns.task_type_id & columns))
qry.Append("task_type_id,");
if (Columns.retry_count == (Columns.retry_count & columns))
qry.Append("retry_count,");
if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
qry.Append("last_invoked_at,");
if (Columns.failure_reason == (Columns.failure_reason & columns))
qry.Append("failure_reason,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Configuration_info ");

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
return new ConfigurationInfoReader(cmd.ExecuteReader(), conn, columns);
}

static public ConfigurationInfoReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ConfigurationInfoReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select configuration_info_id,task_type_id,retry_count,last_invoked_at,failure_reason,status,atm_id from Configuration_info ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ConfigurationInfoReader(cmd.ExecuteReader(), conn);
}

static public ConfigurationInfoReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ConfigurationInfo LoadConfigurationInfo(string where)
{
ConfigurationInfoReader reader = ConfigurationInfo.ExecuteReader(where);
ConfigurationInfo _configurationinfo = null;
if (reader.Read())
_configurationinfo = reader.CurrentConfigurationInfo;
reader.Close();
return _configurationinfo;
}

public static ConfigurationInfo LoadConfigurationInfo(string where, IDbConnection conn)
{
ConfigurationInfoReader reader = ConfigurationInfo.ExecuteReader(where, conn);
ConfigurationInfo _configurationinfo = null;
if (reader.Read())
_configurationinfo = reader.CurrentConfigurationInfo;
reader.Close(false);
return _configurationinfo;
}

public static ConfigurationInfo LoadConfigurationInfoByPk( int configuration_info_id )
{
return LoadConfigurationInfo( " configuration_info_id="+configuration_info_id );
}

public static ConfigurationInfo LoadConfigurationInfoByPk( int configuration_info_id , IDbConnection conn)
{
return LoadConfigurationInfo(" configuration_info_id="+configuration_info_id , conn);
}

public void Save()
{
if (configuration_info_idChanged || task_type_idChanged || retry_countChanged || last_invoked_atChanged || failure_reasonChanged || statusChanged || atm_idChanged )
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
if (configuration_info_idChanged || task_type_idChanged || retry_countChanged || last_invoked_atChanged || failure_reasonChanged || statusChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Configuration_info( configuration_info_id,task_type_id,retry_count,last_invoked_at,failure_reason,status,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.configuration_info_id = ConnectionFactory.GetNextId();
qry.Append(this.configuration_info_id);
} qry.Append(",");
qry.Append(task_type_idDbString+",");
qry.Append(retry_countDbString+",");
qry.Append(last_invoked_atDbString+",");
qry.Append(failure_reasonDbString+",");
qry.Append(statusDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(configuration_info_idChanged || task_type_idChanged || retry_countChanged || last_invoked_atChanged || failure_reasonChanged || statusChanged || atm_idChanged ))
return;
qry.Append("UPDATE Configuration_info set "); if ( task_type_idChanged )
{
qry.Append("task_type_id ="+task_type_idDbString);
qry.Append(",");
}

if ( retry_countChanged )
{
qry.Append("retry_count ="+retry_countDbString);
qry.Append(",");
}

if ( last_invoked_atChanged )
{
qry.Append("last_invoked_at ="+last_invoked_atDbString);
qry.Append(",");
}

if ( failure_reasonChanged )
{
qry.Append("failure_reason ="+failure_reasonDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("configuration_info_id = "+configuration_info_idDbString);
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
cmd.CommandText = "DELETE Configuration_info where configuration_info_id = "+ configuration_info_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteConfigurationInfos(string where)
{
ConnectionFactory.ExecuteQuery("delete Configuration_info where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
configuration_info_id= 1,
task_type_id= 2,
retry_count= 4,
last_invoked_at= 8,
failure_reason= 16,
status= 32,
atm_id= 64
}
#endregion
}
}
