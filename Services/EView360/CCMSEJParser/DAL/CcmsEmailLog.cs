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
public class CcmsEmailLog
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsEmailLog() { }
public CcmsEmailLog( int id ) 
{
}
public CcmsEmailLog( int? alert_id,string user_name,string email_id,DateTime? sent_at )
{
this.alert_id = alert_id;
this.alert_idChanged = true;
this.user_name = user_name;
this.user_nameChanged = true;
this.email_id = email_id;
this.email_idChanged = true;
this.sent_at = sent_at;
this.sent_atChanged = true;
}
private CcmsEmailLog( int id,int? alert_id,string user_name,string email_id,DateTime? sent_at )
{
this.id = id;
this.idChanged = true;
this.alert_id = alert_id;
this.alert_idChanged = true;
this.user_name = user_name;
this.user_nameChanged = true;
this.email_id = email_id;
this.email_idChanged = true;
this.sent_at = sent_at;
this.sent_atChanged = true;
}

#region members and properties for columns

#region Id
private bool idChanged = false;
private int id;
public int Id
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
#region AlertId
private bool alert_idChanged = false;
private int? alert_id;
public int? AlertId
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
if (this.alert_id.HasValue)
return alert_id.ToString();
else
return "null";
}
}
#endregion
#region UserName
private bool user_nameChanged = false;
private string user_name;
public string UserName
{
get { return user_name; }
set { 
user_name = value;
user_nameChanged = true;
}
}
private string user_nameDbString
{
get
{
if (this.user_name!=null)
return string.Format("'{0}'",user_name); else
return "null";
}
}
#endregion
#region EmailId
private bool email_idChanged = false;
private string email_id;
public string EmailId
{
get { return email_id; }
set { 
email_id = value;
email_idChanged = true;
}
}
private string email_idDbString
{
get
{
if (this.email_id!=null)
return string.Format("'{0}'",email_id); else
return "null";
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
#endregion

#region CcmsEmailLogReader
public class CcmsEmailLogReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsEmailLog currentCcmsEmailLog;
Columns columns;
bool partialRead = false;
private CcmsEmailLogReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsEmailLogReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsEmailLogReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsEmailLog; }

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
currentCcmsEmailLog = new CcmsEmailLog();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsEmailLog.id =(int) reader["id"]; 
if ((columns & Columns.alert_id) == Columns.alert_id && reader["alert_id"]!=DBNull.Value)
currentCcmsEmailLog.alert_id =(int?) reader["alert_id"]; 
if ((columns & Columns.user_name) == Columns.user_name && reader["user_name"]!=DBNull.Value)
currentCcmsEmailLog.user_name =(string) reader["user_name"]; 
if ((columns & Columns.email_id) == Columns.email_id && reader["email_id"]!=DBNull.Value)
currentCcmsEmailLog.email_id =(string) reader["email_id"]; 
if ((columns & Columns.sent_at) == Columns.sent_at && reader["sent_at"]!=DBNull.Value)
currentCcmsEmailLog.sent_at =(DateTime?) reader["sent_at"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsEmailLog.id = (int) reader["id"]; 
if (reader["alert_id"] != DBNull.Value)
currentCcmsEmailLog.alert_id = (int?) reader["alert_id"]; 
if (reader["user_name"] != DBNull.Value)
currentCcmsEmailLog.user_name = (string) reader["user_name"]; 
if (reader["email_id"] != DBNull.Value)
currentCcmsEmailLog.email_id = (string) reader["email_id"]; 
if (reader["sent_at"] != DBNull.Value)
currentCcmsEmailLog.sent_at = (DateTime?) reader["sent_at"]; 
} 

currentCcmsEmailLog.isNewEntity = false;
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

public CcmsEmailLog CurrentCcmsEmailLog
{
get{ return currentCcmsEmailLog; }
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


#region CcmsEmailLog functions

public static CcmsEmailLogReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.alert_id == (Columns.alert_id & columns))
qry.Append("alert_id,");
if (Columns.user_name == (Columns.user_name & columns))
qry.Append("user_name,");
if (Columns.email_id == (Columns.email_id & columns))
qry.Append("email_id,");
if (Columns.sent_at == (Columns.sent_at & columns))
qry.Append("sent_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_email_log ");

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
return new CcmsEmailLogReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsEmailLogReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsEmailLogReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,alert_id,user_name,email_id,sent_at from Ccms_email_log ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsEmailLogReader(cmd.ExecuteReader(), conn);
}

static public CcmsEmailLogReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsEmailLog LoadCcmsEmailLog(string where)
{
CcmsEmailLogReader reader = CcmsEmailLog.ExecuteReader(where);
CcmsEmailLog _ccmsemaillog = null;
if (reader.Read())
_ccmsemaillog = reader.CurrentCcmsEmailLog;
reader.Close();
return _ccmsemaillog;
}

public static CcmsEmailLog LoadCcmsEmailLog(string where, IDbConnection conn)
{
CcmsEmailLogReader reader = CcmsEmailLog.ExecuteReader(where, conn);
CcmsEmailLog _ccmsemaillog = null;
if (reader.Read())
_ccmsemaillog = reader.CurrentCcmsEmailLog;
reader.Close(false);
return _ccmsemaillog;
}

public static CcmsEmailLog LoadCcmsEmailLogByPk( int id )
{
return LoadCcmsEmailLog( " id="+id );
}

public static CcmsEmailLog LoadCcmsEmailLogByPk( int id , IDbConnection conn)
{
return LoadCcmsEmailLog(" id="+id , conn);
}

public void Save()
{
if (idChanged || alert_idChanged || user_nameChanged || email_idChanged || sent_atChanged )
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
if (idChanged || alert_idChanged || user_nameChanged || email_idChanged || sent_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_email_log( alert_id,user_name,email_id,sent_at ) values(");

qry.Append(alert_idDbString+",");
qry.Append(user_nameDbString+",");
qry.Append(email_idDbString+",");
qry.Append(sent_atDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || alert_idChanged || user_nameChanged || email_idChanged || sent_atChanged ))
return;
qry.Append("UPDATE Ccms_email_log set "); if ( alert_idChanged )
{
qry.Append("alert_id ="+alert_idDbString);
qry.Append(",");
}

if ( user_nameChanged )
{
qry.Append("user_name ="+user_nameDbString);
qry.Append(",");
}

if ( email_idChanged )
{
qry.Append("email_id ="+email_idDbString);
qry.Append(",");
}

if ( sent_atChanged )
{
qry.Append("sent_at ="+sent_atDbString);
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
    object res = cmd.ExecuteScalar();
    if (res == DBNull.Value)
        id = 1;
    else
        id = int.Parse(res.ToString());
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
cmd.CommandText = "DELETE Ccms_email_log where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsEmailLogs(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_email_log where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
alert_id= 2,
user_name= 4,
email_id= 8,
sent_at= 16
}
#endregion
public void BulkSave(List<CcmsEmailLog> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_email_log";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsEmailLog.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsEmailLog> transList,ref DataTable dt)
{
foreach (CcmsEmailLog tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["alert_id"] = tran.AlertId;
Row["user_name"] = tran.UserName;
Row["email_id"] = tran.EmailId;
Row["sent_at"] = tran.SentAt;
dt.Rows.Add(Row);
} }
}
}
