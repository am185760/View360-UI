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
public class DownloadingSchedule
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DownloadingSchedule() { }
public DownloadingSchedule( DateTime next_download_at,int downloading_schedule_id ) 
{
this.next_download_at = next_download_at;
this.next_download_atChanged = true;
}
public DownloadingSchedule( DateTime next_download_at,int? organization_id )
{
this.next_download_at = next_download_at;
this.next_download_atChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
}
private DownloadingSchedule( DateTime next_download_at,int downloading_schedule_id,int? organization_id )
{
this.next_download_at = next_download_at;
this.next_download_atChanged = true;
this.downloading_schedule_id = downloading_schedule_id;
this.downloading_schedule_idChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
}

#region members and properties for columns

#region NextDownloadAt
private bool next_download_atChanged = false;
private DateTime next_download_at;
public DateTime NextDownloadAt
{
get { return next_download_at; }
set { 
next_download_at = value;
next_download_atChanged = true;
}
}
private string next_download_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",next_download_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region DownloadingScheduleId
private bool downloading_schedule_idChanged = false;
private int downloading_schedule_id;
public int DownloadingScheduleId
{
get { return downloading_schedule_id; }
set { 
downloading_schedule_id = value;
downloading_schedule_idChanged = true;
}
}
private string downloading_schedule_idDbString
{
get
{
return downloading_schedule_id.ToString();
}
}
#endregion
#region OrganizationId
private bool organization_idChanged = false;
private int? organization_id;
public int? OrganizationId
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
#endregion

#region DownloadingScheduleReader
public class DownloadingScheduleReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DownloadingSchedule currentDownloadingSchedule;
Columns columns;
bool partialRead = false;
private DownloadingScheduleReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DownloadingScheduleReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DownloadingScheduleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDownloadingSchedule; }

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
currentDownloadingSchedule = new DownloadingSchedule();
if (partialRead)
{ if ((columns & Columns.next_download_at) == Columns.next_download_at && reader["next_download_at"]!=DBNull.Value)
currentDownloadingSchedule.next_download_at =(DateTime) reader["next_download_at"]; 
if ((columns & Columns.downloading_schedule_id) == Columns.downloading_schedule_id && reader["downloading_schedule_id"]!=DBNull.Value)
currentDownloadingSchedule.downloading_schedule_id =(int) reader["downloading_schedule_id"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentDownloadingSchedule.organization_id =(int?) reader["organization_id"]; 

} else
{
if (reader["next_download_at"] != DBNull.Value)
currentDownloadingSchedule.next_download_at = (DateTime) reader["next_download_at"]; 
if (reader["downloading_schedule_id"] != DBNull.Value)
currentDownloadingSchedule.downloading_schedule_id = (int) reader["downloading_schedule_id"]; 
if (reader["organization_id"] != DBNull.Value)
currentDownloadingSchedule.organization_id = (int?) reader["organization_id"]; 
} 

currentDownloadingSchedule.isNewEntity = false;
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

public DownloadingSchedule CurrentDownloadingSchedule
{
get{ return currentDownloadingSchedule; }
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


#region DownloadingSchedule functions

public static DownloadingScheduleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.next_download_at == (Columns.next_download_at & columns))
qry.Append("next_download_at,");
if (Columns.downloading_schedule_id == (Columns.downloading_schedule_id & columns))
qry.Append("downloading_schedule_id,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Downloading_schedule ");

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
return new DownloadingScheduleReader(cmd.ExecuteReader(), conn, columns);
}

static public DownloadingScheduleReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DownloadingScheduleReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select next_download_at,downloading_schedule_id,organization_id from Downloading_schedule ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DownloadingScheduleReader(cmd.ExecuteReader(), conn);
}

static public DownloadingScheduleReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DownloadingSchedule LoadDownloadingSchedule(string where)
{
DownloadingScheduleReader reader = DownloadingSchedule.ExecuteReader(where);
DownloadingSchedule _downloadingschedule = null;
if (reader.Read())
_downloadingschedule = reader.CurrentDownloadingSchedule;
reader.Close();
return _downloadingschedule;
}

public static DownloadingSchedule LoadDownloadingSchedule(string where, IDbConnection conn)
{
DownloadingScheduleReader reader = DownloadingSchedule.ExecuteReader(where, conn);
DownloadingSchedule _downloadingschedule = null;
if (reader.Read())
_downloadingschedule = reader.CurrentDownloadingSchedule;
reader.Close(false);
return _downloadingschedule;
}

public static DownloadingSchedule LoadDownloadingScheduleByPk( int downloading_schedule_id )
{
return LoadDownloadingSchedule( " downloading_schedule_id="+downloading_schedule_id );
}

public static DownloadingSchedule LoadDownloadingScheduleByPk( int downloading_schedule_id , IDbConnection conn)
{
return LoadDownloadingSchedule(" downloading_schedule_id="+downloading_schedule_id , conn);
}

public void Save()
{
if (next_download_atChanged || downloading_schedule_idChanged || organization_idChanged )
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
if (next_download_atChanged || downloading_schedule_idChanged || organization_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Downloading_schedule( next_download_at,downloading_schedule_id,organization_id ) values(");
qry.Append(next_download_atDbString+",");
lock (ConnectionFactory.connectionString) { this.downloading_schedule_id = ConnectionFactory.GetNextId();
qry.Append(this.downloading_schedule_id);
} qry.Append(",");
qry.Append(organization_idDbString);
qry.Append(");");

}
else
{
if (!(next_download_atChanged || downloading_schedule_idChanged || organization_idChanged ))
return;
qry.Append("UPDATE Downloading_schedule set "); if ( next_download_atChanged )
{
qry.Append("next_download_at ="+next_download_atDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("downloading_schedule_id = "+downloading_schedule_idDbString);
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
cmd.CommandText = "DELETE Downloading_schedule where downloading_schedule_id = "+ downloading_schedule_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDownloadingSchedules(string where)
{
ConnectionFactory.ExecuteQuery("delete Downloading_schedule where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
next_download_at= 1,
downloading_schedule_id= 2,
organization_id= 4
}
#endregion
public void BulkSave(List<DownloadingSchedule> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Downloading_schedule";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DownloadingSchedule.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DownloadingSchedule> transList,ref DataTable dt)
{
foreach (DownloadingSchedule tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["next_download_at"] = tran.NextDownloadAt;
Row["downloading_schedule_id"] =ConnectionFactory.GetNextId();
Row["organization_id"] = tran.OrganizationId;
dt.Rows.Add(Row);
} }
}
}
