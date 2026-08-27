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
public class AtmSettlementInfo
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmSettlementInfo() { }
public AtmSettlementInfo( int atm_settlement_info_id ) 
{
}
public AtmSettlementInfo( DateTime? report_date,string report_path,int? uploaded_by,DateTime? upload_datetime )
{
this.report_date = report_date;
this.report_dateChanged = true;
this.report_path = report_path;
this.report_pathChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.upload_datetime = upload_datetime;
this.upload_datetimeChanged = true;
}
private AtmSettlementInfo( int atm_settlement_info_id,DateTime? report_date,string report_path,int? uploaded_by,DateTime? upload_datetime )
{
this.atm_settlement_info_id = atm_settlement_info_id;
this.atm_settlement_info_idChanged = true;
this.report_date = report_date;
this.report_dateChanged = true;
this.report_path = report_path;
this.report_pathChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.upload_datetime = upload_datetime;
this.upload_datetimeChanged = true;
}

#region members and properties for columns

#region AtmSettlementInfoId
private bool atm_settlement_info_idChanged = false;
private int atm_settlement_info_id;
public int AtmSettlementInfoId
{
get { return atm_settlement_info_id; }
set { 
atm_settlement_info_id = value;
atm_settlement_info_idChanged = true;
}
}
private string atm_settlement_info_idDbString
{
get
{
return atm_settlement_info_id.ToString();
}
}
#endregion
#region ReportDate
private bool report_dateChanged = false;
private DateTime? report_date;
public DateTime? ReportDate
{
get { return report_date; }
set { 
report_date = value;
report_dateChanged = true;
}
}
private string report_dateDbString
{
get
{
if (this.report_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",report_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ReportPath
private bool report_pathChanged = false;
private string report_path;
public string ReportPath
{
get { return report_path; }
set { 
report_path = value;
report_pathChanged = true;
}
}
private string report_pathDbString
{
get
{
if (this.report_path!=null)
return string.Format("'{0}'",report_path); else
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
#endregion

#region AtmSettlementInfoReader
public class AtmSettlementInfoReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmSettlementInfo currentAtmSettlementInfo;
Columns columns;
bool partialRead = false;
private AtmSettlementInfoReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmSettlementInfoReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmSettlementInfoReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmSettlementInfo; }

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
currentAtmSettlementInfo = new AtmSettlementInfo();
if (partialRead)
{ if ((columns & Columns.atm_settlement_info_id) == Columns.atm_settlement_info_id && reader["atm_settlement_info_id"]!=DBNull.Value)
currentAtmSettlementInfo.atm_settlement_info_id =(int) reader["atm_settlement_info_id"]; 
if ((columns & Columns.report_date) == Columns.report_date && reader["report_date"]!=DBNull.Value)
currentAtmSettlementInfo.report_date =(DateTime?) reader["report_date"]; 
if ((columns & Columns.report_path) == Columns.report_path && reader["report_path"]!=DBNull.Value)
currentAtmSettlementInfo.report_path =(string) reader["report_path"]; 
if ((columns & Columns.uploaded_by) == Columns.uploaded_by && reader["uploaded_by"]!=DBNull.Value)
currentAtmSettlementInfo.uploaded_by =(int?) reader["uploaded_by"]; 
if ((columns & Columns.upload_datetime) == Columns.upload_datetime && reader["upload_datetime"]!=DBNull.Value)
currentAtmSettlementInfo.upload_datetime =(DateTime?) reader["upload_datetime"]; 

} else
{
if (reader["atm_settlement_info_id"] != DBNull.Value)
currentAtmSettlementInfo.atm_settlement_info_id = (int) reader["atm_settlement_info_id"]; 
if (reader["report_date"] != DBNull.Value)
currentAtmSettlementInfo.report_date = (DateTime?) reader["report_date"]; 
if (reader["report_path"] != DBNull.Value)
currentAtmSettlementInfo.report_path = (string) reader["report_path"]; 
if (reader["uploaded_by"] != DBNull.Value)
currentAtmSettlementInfo.uploaded_by = (int?) reader["uploaded_by"]; 
if (reader["upload_datetime"] != DBNull.Value)
currentAtmSettlementInfo.upload_datetime = (DateTime?) reader["upload_datetime"]; 
} 

currentAtmSettlementInfo.isNewEntity = false;
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

public AtmSettlementInfo CurrentAtmSettlementInfo
{
get{ return currentAtmSettlementInfo; }
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


#region AtmSettlementInfo functions

public static AtmSettlementInfoReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_settlement_info_id == (Columns.atm_settlement_info_id & columns))
qry.Append("atm_settlement_info_id,");
if (Columns.report_date == (Columns.report_date & columns))
qry.Append("report_date,");
if (Columns.report_path == (Columns.report_path & columns))
qry.Append("report_path,");
if (Columns.uploaded_by == (Columns.uploaded_by & columns))
qry.Append("uploaded_by,");
if (Columns.upload_datetime == (Columns.upload_datetime & columns))
qry.Append("upload_datetime,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_settlement_info ");

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
return new AtmSettlementInfoReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmSettlementInfoReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmSettlementInfoReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_settlement_info_id,report_date,report_path,uploaded_by,upload_datetime from Atm_settlement_info ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmSettlementInfoReader(cmd.ExecuteReader(), conn);
}

static public AtmSettlementInfoReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmSettlementInfo LoadAtmSettlementInfo(string where)
{
AtmSettlementInfoReader reader = AtmSettlementInfo.ExecuteReader(where);
AtmSettlementInfo _atmsettlementinfo = null;
if (reader.Read())
_atmsettlementinfo = reader.CurrentAtmSettlementInfo;
reader.Close();
return _atmsettlementinfo;
}

public static AtmSettlementInfo LoadAtmSettlementInfo(string where, IDbConnection conn)
{
AtmSettlementInfoReader reader = AtmSettlementInfo.ExecuteReader(where, conn);
AtmSettlementInfo _atmsettlementinfo = null;
if (reader.Read())
_atmsettlementinfo = reader.CurrentAtmSettlementInfo;
reader.Close(false);
return _atmsettlementinfo;
}

public static AtmSettlementInfo LoadAtmSettlementInfoByPk( int atm_settlement_info_id )
{
return LoadAtmSettlementInfo( " atm_settlement_info_id="+atm_settlement_info_id );
}

public static AtmSettlementInfo LoadAtmSettlementInfoByPk( int atm_settlement_info_id , IDbConnection conn)
{
return LoadAtmSettlementInfo(" atm_settlement_info_id="+atm_settlement_info_id , conn);
}

public void Save()
{
if (atm_settlement_info_idChanged || report_dateChanged || report_pathChanged || uploaded_byChanged || upload_datetimeChanged )
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
if (atm_settlement_info_idChanged || report_dateChanged || report_pathChanged || uploaded_byChanged || upload_datetimeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_settlement_info( atm_settlement_info_id,report_date,report_path,uploaded_by,upload_datetime ) values(");
lock (ConnectionFactory.connectionString) { this.atm_settlement_info_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_settlement_info_id);
} qry.Append(",");
qry.Append(report_dateDbString+",");
qry.Append(report_pathDbString+",");
qry.Append(uploaded_byDbString+",");
qry.Append(upload_datetimeDbString);
qry.Append(");");

}
else
{
if (!(atm_settlement_info_idChanged || report_dateChanged || report_pathChanged || uploaded_byChanged || upload_datetimeChanged ))
return;
qry.Append("UPDATE Atm_settlement_info set "); if ( report_dateChanged )
{
qry.Append("report_date ="+report_dateDbString);
qry.Append(",");
}

if ( report_pathChanged )
{
qry.Append("report_path ="+report_pathDbString);
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


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_settlement_info_id = "+atm_settlement_info_idDbString);
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
cmd.CommandText = "DELETE Atm_settlement_info where atm_settlement_info_id = "+ atm_settlement_info_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmSettlementInfos(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_settlement_info where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_settlement_info_id= 1,
report_date= 2,
report_path= 4,
uploaded_by= 8,
upload_datetime= 16
}
#endregion
public void BulkSave(List<AtmSettlementInfo> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_settlement_info";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmSettlementInfo.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmSettlementInfo> transList,ref DataTable dt)
{
foreach (AtmSettlementInfo tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_settlement_info_id"] =ConnectionFactory.GetNextId();
Row["report_date"] = tran.ReportDate;
Row["report_path"] = tran.ReportPath;
Row["uploaded_by"] = tran.UploadedBy;
Row["upload_datetime"] = tran.UploadDatetime;
dt.Rows.Add(Row);
} }
}
}
