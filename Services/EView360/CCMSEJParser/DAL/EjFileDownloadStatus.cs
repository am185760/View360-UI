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
public class EjFileDownloadStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public EjFileDownloadStatus() { }
public EjFileDownloadStatus( int ej_file_download_status_id ) 
{
}
public EjFileDownloadStatus( int? atm_id,DateTime? ej_file_download_time,DateTime? processing_datetime )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.ej_file_download_time = ej_file_download_time;
this.ej_file_download_timeChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
}
private EjFileDownloadStatus( int ej_file_download_status_id,int? atm_id,DateTime? ej_file_download_time,DateTime? processing_datetime )
{
this.ej_file_download_status_id = ej_file_download_status_id;
this.ej_file_download_status_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.ej_file_download_time = ej_file_download_time;
this.ej_file_download_timeChanged = true;
this.processing_datetime = processing_datetime;
this.processing_datetimeChanged = true;
}

#region members and properties for columns

#region EjFileDownloadStatusId
private bool ej_file_download_status_idChanged = false;
private int ej_file_download_status_id;
public int EjFileDownloadStatusId
{
get { return ej_file_download_status_id; }
set { 
ej_file_download_status_id = value;
ej_file_download_status_idChanged = true;
}
}
private string ej_file_download_status_idDbString
{
get
{
return ej_file_download_status_id.ToString();
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
#region EjFileDownloadTime
private bool ej_file_download_timeChanged = false;
private DateTime? ej_file_download_time;
public DateTime? EjFileDownloadTime
{
get { return ej_file_download_time; }
set { 
ej_file_download_time = value;
ej_file_download_timeChanged = true;
}
}
private string ej_file_download_timeDbString
{
get
{
if (this.ej_file_download_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",ej_file_download_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ProcessingDatetime
private bool processing_datetimeChanged = false;
private DateTime? processing_datetime;
public DateTime? ProcessingDatetime
{
get { return processing_datetime; }
set { 
processing_datetime = value;
processing_datetimeChanged = true;
}
}
private string processing_datetimeDbString
{
get
{
if (this.processing_datetime.HasValue)
return string.Format("Convert(datetime,'{0}',121)",processing_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#endregion

#region EjFileDownloadStatusReader
public class EjFileDownloadStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
EjFileDownloadStatus currentEjFileDownloadStatus;
Columns columns;
bool partialRead = false;
private EjFileDownloadStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public EjFileDownloadStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public EjFileDownloadStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentEjFileDownloadStatus; }

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
currentEjFileDownloadStatus = new EjFileDownloadStatus();
if (partialRead)
{ if ((columns & Columns.ej_file_download_status_id) == Columns.ej_file_download_status_id && reader["ej_file_download_status_id"]!=DBNull.Value)
currentEjFileDownloadStatus.ej_file_download_status_id =(int) reader["ej_file_download_status_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentEjFileDownloadStatus.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.ej_file_download_time) == Columns.ej_file_download_time && reader["ej_file_download_time"]!=DBNull.Value)
currentEjFileDownloadStatus.ej_file_download_time =(DateTime?) reader["ej_file_download_time"]; 
if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
currentEjFileDownloadStatus.processing_datetime =(DateTime?) reader["processing_datetime"]; 

} else
{
if (reader["ej_file_download_status_id"] != DBNull.Value)
currentEjFileDownloadStatus.ej_file_download_status_id = (int) reader["ej_file_download_status_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentEjFileDownloadStatus.atm_id = (int?) reader["atm_id"]; 
if (reader["ej_file_download_time"] != DBNull.Value)
currentEjFileDownloadStatus.ej_file_download_time = (DateTime?) reader["ej_file_download_time"]; 
if (reader["processing_datetime"] != DBNull.Value)
currentEjFileDownloadStatus.processing_datetime = (DateTime?) reader["processing_datetime"]; 
} 

currentEjFileDownloadStatus.isNewEntity = false;
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

public EjFileDownloadStatus CurrentEjFileDownloadStatus
{
get{ return currentEjFileDownloadStatus; }
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


#region EjFileDownloadStatus functions

public static EjFileDownloadStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.ej_file_download_status_id == (Columns.ej_file_download_status_id & columns))
qry.Append("ej_file_download_status_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.ej_file_download_time == (Columns.ej_file_download_time & columns))
qry.Append("ej_file_download_time,");
if (Columns.processing_datetime == (Columns.processing_datetime & columns))
qry.Append("processing_datetime,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ej_file_download_status ");

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
return new EjFileDownloadStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public EjFileDownloadStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static EjFileDownloadStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select ej_file_download_status_id,atm_id,ej_file_download_time,processing_datetime from Ej_file_download_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new EjFileDownloadStatusReader(cmd.ExecuteReader(), conn);
}

static public EjFileDownloadStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static EjFileDownloadStatus LoadEjFileDownloadStatus(string where)
{
EjFileDownloadStatusReader reader = EjFileDownloadStatus.ExecuteReader(where);
EjFileDownloadStatus _ejfiledownloadstatus = null;
if (reader.Read())
_ejfiledownloadstatus = reader.CurrentEjFileDownloadStatus;
reader.Close();
return _ejfiledownloadstatus;
}

public static EjFileDownloadStatus LoadEjFileDownloadStatus(string where, IDbConnection conn)
{
EjFileDownloadStatusReader reader = EjFileDownloadStatus.ExecuteReader(where, conn);
EjFileDownloadStatus _ejfiledownloadstatus = null;
if (reader.Read())
_ejfiledownloadstatus = reader.CurrentEjFileDownloadStatus;
reader.Close(false);
return _ejfiledownloadstatus;
}

public static EjFileDownloadStatus LoadEjFileDownloadStatusByPk( int ej_file_download_status_id )
{
return LoadEjFileDownloadStatus( " ej_file_download_status_id="+ej_file_download_status_id );
}

public static EjFileDownloadStatus LoadEjFileDownloadStatusByPk( int ej_file_download_status_id , IDbConnection conn)
{
return LoadEjFileDownloadStatus(" ej_file_download_status_id="+ej_file_download_status_id , conn);
}

public void Save()
{
if (ej_file_download_status_idChanged || atm_idChanged || ej_file_download_timeChanged || processing_datetimeChanged )
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
if (ej_file_download_status_idChanged || atm_idChanged || ej_file_download_timeChanged || processing_datetimeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ej_file_download_status( ej_file_download_status_id,atm_id,ej_file_download_time,processing_datetime ) values(");
lock (ConnectionFactory.connectionString) { this.ej_file_download_status_id = ConnectionFactory.GetNextId();
qry.Append(this.ej_file_download_status_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(ej_file_download_timeDbString+",");
qry.Append(processing_datetimeDbString);
qry.Append(");");

}
else
{
if (!(ej_file_download_status_idChanged || atm_idChanged || ej_file_download_timeChanged || processing_datetimeChanged ))
return;
qry.Append("UPDATE Ej_file_download_status set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( ej_file_download_timeChanged )
{
qry.Append("ej_file_download_time ="+ej_file_download_timeDbString);
qry.Append(",");
}

if ( processing_datetimeChanged )
{
qry.Append("processing_datetime ="+processing_datetimeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("ej_file_download_status_id = "+ej_file_download_status_idDbString);
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
cmd.CommandText = "DELETE Ej_file_download_status where ej_file_download_status_id = "+ ej_file_download_status_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteEjFileDownloadStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete Ej_file_download_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
ej_file_download_status_id= 1,
atm_id= 2,
ej_file_download_time= 4,
processing_datetime= 8
}
#endregion
public void BulkSave(List<EjFileDownloadStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ej_file_download_status";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(EjFileDownloadStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <EjFileDownloadStatus> transList,ref DataTable dt)
{
foreach (EjFileDownloadStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["ej_file_download_status_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["ej_file_download_time"] = tran.EjFileDownloadTime;
Row["processing_datetime"] = tran.ProcessingDatetime;
dt.Rows.Add(Row);
} }
}
}
