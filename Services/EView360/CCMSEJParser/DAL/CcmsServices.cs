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
public class CcmsServices
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsServices() { }
public CcmsServices( int ccms_services_id,string name,string service_status ) 
{
this.name = name;
this.nameChanged = true;
this.service_status = service_status;
this.service_statusChanged = true;
}
public CcmsServices( string name,string service_status,DateTime? last_invoked_at,bool? is_start_scheduled,bool? is_stop_scheduled )
{
this.name = name;
this.nameChanged = true;
this.service_status = service_status;
this.service_statusChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.is_start_scheduled = is_start_scheduled;
this.is_start_scheduledChanged = true;
this.is_stop_scheduled = is_stop_scheduled;
this.is_stop_scheduledChanged = true;
}
private CcmsServices( int ccms_services_id,string name,string service_status,DateTime? last_invoked_at,bool? is_start_scheduled,bool? is_stop_scheduled )
{
this.ccms_services_id = ccms_services_id;
this.ccms_services_idChanged = true;
this.name = name;
this.nameChanged = true;
this.service_status = service_status;
this.service_statusChanged = true;
this.last_invoked_at = last_invoked_at;
this.last_invoked_atChanged = true;
this.is_start_scheduled = is_start_scheduled;
this.is_start_scheduledChanged = true;
this.is_stop_scheduled = is_stop_scheduled;
this.is_stop_scheduledChanged = true;
}

#region members and properties for columns

#region CcmsServicesId
private bool ccms_services_idChanged = false;
private int ccms_services_id;
public int CcmsServicesId
{
get { return ccms_services_id; }
set { 
ccms_services_id = value;
ccms_services_idChanged = true;
}
}
private string ccms_services_idDbString
{
get
{
return ccms_services_id.ToString();
}
}
#endregion
#region Name
private bool nameChanged = false;
private string name;
public string Name
{
get { return name; }
set { 
name = value;
nameChanged = true;
}
}
private string nameDbString
{
get
{
if (this.name!=null)
return string.Format("'{0}'",name); else
return "null";
}
}
#endregion
#region ServiceStatus
private bool service_statusChanged = false;
private string service_status;
public string ServiceStatus
{
get { return service_status; }
set { 
service_status = value;
service_statusChanged = true;
}
}
private string service_statusDbString
{
get
{
if (this.service_status!=null)
return string.Format("'{0}'",service_status); else
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
#region IsStartScheduled
private bool is_start_scheduledChanged = false;
private bool? is_start_scheduled;
public bool? IsStartScheduled
{
get { return is_start_scheduled; }
set { 
is_start_scheduled = value;
is_start_scheduledChanged = true;
}
}
private string is_start_scheduledDbString
{
get
{
if (this.is_start_scheduled.HasValue)
return is_start_scheduled.Value?"1":"0";
else
return "null";
}
}
#endregion
#region IsStopScheduled
private bool is_stop_scheduledChanged = false;
private bool? is_stop_scheduled;
public bool? IsStopScheduled
{
get { return is_stop_scheduled; }
set { 
is_stop_scheduled = value;
is_stop_scheduledChanged = true;
}
}
private string is_stop_scheduledDbString
{
get
{
if (this.is_stop_scheduled.HasValue)
return is_stop_scheduled.Value?"1":"0";
else
return "null";
}
}
#endregion
#endregion

#region CcmsServicesReader
public class CcmsServicesReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsServices currentCcmsServices;
Columns columns;
bool partialRead = false;
private CcmsServicesReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsServicesReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsServicesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsServices; }

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
currentCcmsServices = new CcmsServices();
if (partialRead)
{ if ((columns & Columns.ccms_services_id) == Columns.ccms_services_id && reader["ccms_services_id"]!=DBNull.Value)
currentCcmsServices.ccms_services_id =(int) reader["ccms_services_id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCcmsServices.name =(string) reader["name"]; 
if ((columns & Columns.service_status) == Columns.service_status && reader["service_status"]!=DBNull.Value)
currentCcmsServices.service_status =(string) reader["service_status"]; 
if ((columns & Columns.last_invoked_at) == Columns.last_invoked_at && reader["last_invoked_at"]!=DBNull.Value)
currentCcmsServices.last_invoked_at =(DateTime?) reader["last_invoked_at"]; 
if ((columns & Columns.is_start_scheduled) == Columns.is_start_scheduled && reader["is_start_scheduled"]!=DBNull.Value)
currentCcmsServices.is_start_scheduled =(bool?) reader["is_start_scheduled"]; 
if ((columns & Columns.is_stop_scheduled) == Columns.is_stop_scheduled && reader["is_stop_scheduled"]!=DBNull.Value)
currentCcmsServices.is_stop_scheduled =(bool?) reader["is_stop_scheduled"]; 

} else
{
if (reader["ccms_services_id"] != DBNull.Value)
currentCcmsServices.ccms_services_id = (int) reader["ccms_services_id"]; 
if (reader["name"] != DBNull.Value)
currentCcmsServices.name = (string) reader["name"]; 
if (reader["service_status"] != DBNull.Value)
currentCcmsServices.service_status = (string) reader["service_status"]; 
if (reader["last_invoked_at"] != DBNull.Value)
currentCcmsServices.last_invoked_at = (DateTime?) reader["last_invoked_at"]; 
if (reader["is_start_scheduled"] != DBNull.Value)
currentCcmsServices.is_start_scheduled = (bool?) reader["is_start_scheduled"]; 
if (reader["is_stop_scheduled"] != DBNull.Value)
currentCcmsServices.is_stop_scheduled = (bool?) reader["is_stop_scheduled"]; 
} 

currentCcmsServices.isNewEntity = false;
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

public CcmsServices CurrentCcmsServices
{
get{ return currentCcmsServices; }
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


#region CcmsServices functions

public static CcmsServicesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.ccms_services_id == (Columns.ccms_services_id & columns))
qry.Append("ccms_services_id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.service_status == (Columns.service_status & columns))
qry.Append("service_status,");
if (Columns.last_invoked_at == (Columns.last_invoked_at & columns))
qry.Append("last_invoked_at,");
if (Columns.is_start_scheduled == (Columns.is_start_scheduled & columns))
qry.Append("is_start_scheduled,");
if (Columns.is_stop_scheduled == (Columns.is_stop_scheduled & columns))
qry.Append("is_stop_scheduled,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_services ");

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
return new CcmsServicesReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsServicesReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsServicesReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select ccms_services_id,name,service_status,last_invoked_at,is_start_scheduled,is_stop_scheduled from Ccms_services ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsServicesReader(cmd.ExecuteReader(), conn);
}

static public CcmsServicesReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsServices LoadCcmsServices(string where)
{
CcmsServicesReader reader = CcmsServices.ExecuteReader(where);
CcmsServices _ccmsservices = null;
if (reader.Read())
_ccmsservices = reader.CurrentCcmsServices;
reader.Close();
return _ccmsservices;
}

public static CcmsServices LoadCcmsServices(string where, IDbConnection conn)
{
CcmsServicesReader reader = CcmsServices.ExecuteReader(where, conn);
CcmsServices _ccmsservices = null;
if (reader.Read())
_ccmsservices = reader.CurrentCcmsServices;
reader.Close(false);
return _ccmsservices;
}

public static CcmsServices LoadCcmsServicesByPk( int ccms_services_id )
{
return LoadCcmsServices( " ccms_services_id="+ccms_services_id );
}

public static CcmsServices LoadCcmsServicesByPk( int ccms_services_id , IDbConnection conn)
{
return LoadCcmsServices(" ccms_services_id="+ccms_services_id , conn);
}

public void Save()
{
if (ccms_services_idChanged || nameChanged || service_statusChanged || last_invoked_atChanged || is_start_scheduledChanged || is_stop_scheduledChanged )
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
if (ccms_services_idChanged || nameChanged || service_statusChanged || last_invoked_atChanged || is_start_scheduledChanged || is_stop_scheduledChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_services( ccms_services_id,name,service_status,last_invoked_at,is_start_scheduled,is_stop_scheduled ) values(");
lock (ConnectionFactory.connectionString) { this.ccms_services_id = ConnectionFactory.GetNextId();
qry.Append(this.ccms_services_id);
} qry.Append(",");
qry.Append(nameDbString+",");
qry.Append(service_statusDbString+",");
qry.Append(last_invoked_atDbString+",");
qry.Append(is_start_scheduledDbString+",");
qry.Append(is_stop_scheduledDbString);
qry.Append(");");

}
else
{
if (!(ccms_services_idChanged || nameChanged || service_statusChanged || last_invoked_atChanged || is_start_scheduledChanged || is_stop_scheduledChanged ))
return;
qry.Append("UPDATE Ccms_services set "); if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( service_statusChanged )
{
qry.Append("service_status ="+service_statusDbString);
qry.Append(",");
}

if ( last_invoked_atChanged )
{
qry.Append("last_invoked_at ="+last_invoked_atDbString);
qry.Append(",");
}

if ( is_start_scheduledChanged )
{
qry.Append("is_start_scheduled ="+is_start_scheduledDbString);
qry.Append(",");
}

if ( is_stop_scheduledChanged )
{
qry.Append("is_stop_scheduled ="+is_stop_scheduledDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("ccms_services_id = "+ccms_services_idDbString);
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
cmd.CommandText = "DELETE Ccms_services where ccms_services_id = "+ ccms_services_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsServicess(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_services where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
ccms_services_id= 1,
name= 2,
service_status= 4,
last_invoked_at= 8,
is_start_scheduled= 16,
is_stop_scheduled= 32
}
#endregion
public void BulkSave(List<CcmsServices> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_services";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsServices.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsServices> transList,ref DataTable dt)
{
foreach (CcmsServices tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["ccms_services_id"] =ConnectionFactory.GetNextId();
Row["name"] = tran.Name;
Row["service_status"] = tran.ServiceStatus;
Row["last_invoked_at"] = tran.LastInvokedAt;
Row["is_start_scheduled"] = tran.IsStartScheduled;
Row["is_stop_scheduled"] = tran.IsStopScheduled;
dt.Rows.Add(Row);
} }
}
}
