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
public class ReportTaskDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ReportTaskDetail() { }
public ReportTaskDetail( int report_task_id,int atm_id )
{
this.report_task_id = report_task_id;
this.report_task_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private ReportTaskDetail( int report_task_detail_id,int report_task_id,int atm_id )
{
this.report_task_detail_id = report_task_detail_id;
this.report_task_detail_idChanged = true;
this.report_task_id = report_task_id;
this.report_task_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region ReportTaskDetailId
private bool report_task_detail_idChanged = false;
private int report_task_detail_id;
public int ReportTaskDetailId
{
get { return report_task_detail_id; }
set { 
report_task_detail_id = value;
report_task_detail_idChanged = true;
}
}
private string report_task_detail_idDbString
{
get
{
return report_task_detail_id.ToString();
}
}
#endregion
#region ReportTaskId
private bool report_task_idChanged = false;
private int report_task_id;
public int ReportTaskId
{
get { return report_task_id; }
set { 
report_task_id = value;
report_task_idChanged = true;
}
}
private string report_task_idDbString
{
get
{
return report_task_id.ToString();
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
#endregion

#region ReportTaskDetailReader
public class ReportTaskDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ReportTaskDetail currentReportTaskDetail;
Columns columns;
bool partialRead = false;
private ReportTaskDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ReportTaskDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ReportTaskDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentReportTaskDetail; }

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
currentReportTaskDetail = new ReportTaskDetail();
if (partialRead)
{ if ((columns & Columns.report_task_detail_id) == Columns.report_task_detail_id && reader["report_task_detail_id"]!=DBNull.Value)
currentReportTaskDetail.report_task_detail_id =(int) reader["report_task_detail_id"]; 
if ((columns & Columns.report_task_id) == Columns.report_task_id && reader["report_task_id"]!=DBNull.Value)
currentReportTaskDetail.report_task_id =(int) reader["report_task_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentReportTaskDetail.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["report_task_detail_id"] != DBNull.Value)
currentReportTaskDetail.report_task_detail_id = (int) reader["report_task_detail_id"]; 
if (reader["report_task_id"] != DBNull.Value)
currentReportTaskDetail.report_task_id = (int) reader["report_task_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentReportTaskDetail.atm_id = (int) reader["atm_id"]; 
} 

currentReportTaskDetail.isNewEntity = false;
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

public ReportTaskDetail CurrentReportTaskDetail
{
get{ return currentReportTaskDetail; }
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


#region ReportTaskDetail functions

public static ReportTaskDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.report_task_detail_id == (Columns.report_task_detail_id & columns))
qry.Append("report_task_detail_id,");
if (Columns.report_task_id == (Columns.report_task_id & columns))
qry.Append("report_task_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Report_task_detail ");

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
return new ReportTaskDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public ReportTaskDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ReportTaskDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select report_task_detail_id,report_task_id,atm_id from Report_task_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ReportTaskDetailReader(cmd.ExecuteReader(), conn);
}

static public ReportTaskDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ReportTaskDetail LoadReportTaskDetail(string where)
{
ReportTaskDetailReader reader = ReportTaskDetail.ExecuteReader(where);
ReportTaskDetail _reporttaskdetail = null;
if (reader.Read())
_reporttaskdetail = reader.CurrentReportTaskDetail;
reader.Close();
return _reporttaskdetail;
}

public static ReportTaskDetail LoadReportTaskDetail(string where, IDbConnection conn)
{
ReportTaskDetailReader reader = ReportTaskDetail.ExecuteReader(where, conn);
ReportTaskDetail _reporttaskdetail = null;
if (reader.Read())
_reporttaskdetail = reader.CurrentReportTaskDetail;
reader.Close(false);
return _reporttaskdetail;
}

public static ReportTaskDetail LoadReportTaskDetailByPk( int report_task_detail_id )
{
return LoadReportTaskDetail( " report_task_detail_id="+report_task_detail_id );
}

public static ReportTaskDetail LoadReportTaskDetailByPk( int report_task_detail_id , IDbConnection conn)
{
return LoadReportTaskDetail(" report_task_detail_id="+report_task_detail_id , conn);
}

public void Save()
{
if (report_task_detail_idChanged || report_task_idChanged || atm_idChanged )
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
if (report_task_detail_idChanged || report_task_idChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Report_task_detail( report_task_detail_id,report_task_id,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.report_task_detail_id = ConnectionFactory.GetNextId();
qry.Append(this.report_task_detail_id);
} qry.Append(",");
qry.Append(report_task_idDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(report_task_detail_idChanged || report_task_idChanged || atm_idChanged ))
return;
qry.Append("UPDATE Report_task_detail set "); if ( report_task_idChanged )
{
qry.Append("report_task_id ="+report_task_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("report_task_detail_id = "+report_task_detail_idDbString);
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
cmd.CommandText = "DELETE Report_task_detail where report_task_detail_id = "+ report_task_detail_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteReportTaskDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Report_task_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
report_task_detail_id= 1,
report_task_id= 2,
atm_id= 4
}
#endregion
public void BulkSave(List<ReportTaskDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Report_task_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ReportTaskDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ReportTaskDetail> transList,ref DataTable dt)
{
foreach (ReportTaskDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["report_task_detail_id"] =ConnectionFactory.GetNextId();
Row["report_task_id"] = tran.ReportTaskId;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
