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
public class Investigation
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Investigation() { }
public Investigation( int investigation_id,int investigation_reason_id,int forward_to,DateTime creation_time,int atm_id,int investigation_status,int user_id ) 
{
this.investigation_reason_id = investigation_reason_id;
this.investigation_reason_idChanged = true;
this.forward_to = forward_to;
this.forward_toChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.investigation_status = investigation_status;
this.investigation_statusChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
}
public Investigation( int investigation_reason_id,int forward_to,string investigation_summary,DateTime creation_time,string order_number,int atm_id,int investigation_status,int user_id,DateTime? modification_time,int? modified_by,DateTime? resolution_time,int? resolved_by )
{
this.investigation_reason_id = investigation_reason_id;
this.investigation_reason_idChanged = true;
this.forward_to = forward_to;
this.forward_toChanged = true;
this.investigation_summary = investigation_summary;
this.investigation_summaryChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.order_number = order_number;
this.order_numberChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.investigation_status = investigation_status;
this.investigation_statusChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.resolution_time = resolution_time;
this.resolution_timeChanged = true;
this.resolved_by = resolved_by;
this.resolved_byChanged = true;
}
private Investigation( int investigation_id,int investigation_reason_id,int forward_to,string investigation_summary,DateTime creation_time,string order_number,int atm_id,int investigation_status,int user_id,DateTime? modification_time,int? modified_by,DateTime? resolution_time,int? resolved_by )
{
this.investigation_id = investigation_id;
this.investigation_idChanged = true;
this.investigation_reason_id = investigation_reason_id;
this.investigation_reason_idChanged = true;
this.forward_to = forward_to;
this.forward_toChanged = true;
this.investigation_summary = investigation_summary;
this.investigation_summaryChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.order_number = order_number;
this.order_numberChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.investigation_status = investigation_status;
this.investigation_statusChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.resolution_time = resolution_time;
this.resolution_timeChanged = true;
this.resolved_by = resolved_by;
this.resolved_byChanged = true;
}

#region members and properties for columns

#region InvestigationId
private bool investigation_idChanged = false;
private int investigation_id;
public int InvestigationId
{
get { return investigation_id; }
set { 
investigation_id = value;
investigation_idChanged = true;
}
}
private string investigation_idDbString
{
get
{
return investigation_id.ToString();
}
}
#endregion
#region InvestigationReasonId
private bool investigation_reason_idChanged = false;
private int investigation_reason_id;
public int InvestigationReasonId
{
get { return investigation_reason_id; }
set { 
investigation_reason_id = value;
investigation_reason_idChanged = true;
}
}
private string investigation_reason_idDbString
{
get
{
return investigation_reason_id.ToString();
}
}
#endregion
#region ForwardTo
private bool forward_toChanged = false;
private int forward_to;
public int ForwardTo
{
get { return forward_to; }
set { 
forward_to = value;
forward_toChanged = true;
}
}
private string forward_toDbString
{
get
{
return forward_to.ToString();
}
}
#endregion
#region InvestigationSummary
private bool investigation_summaryChanged = false;
private string investigation_summary;
public string InvestigationSummary
{
get { return investigation_summary; }
set { 
investigation_summary = value;
investigation_summaryChanged = true;
}
}
private string investigation_summaryDbString
{
get
{
if (this.investigation_summary!=null)
return string.Format("'{0}'",investigation_summary); else
return "null";
}
}
#endregion
#region CreationTime
private bool creation_timeChanged = false;
private DateTime creation_time;
public DateTime CreationTime
{
get { return creation_time; }
set { 
creation_time = value;
creation_timeChanged = true;
}
}
private string creation_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region OrderNumber
private bool order_numberChanged = false;
private string order_number;
public string OrderNumber
{
get { return order_number; }
set { 
order_number = value;
order_numberChanged = true;
}
}
private string order_numberDbString
{
get
{
if (this.order_number!=null)
return string.Format("'{0}'",order_number); else
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
#region InvestigationStatus
private bool investigation_statusChanged = false;
private int investigation_status;
public int InvestigationStatus
{
get { return investigation_status; }
set { 
investigation_status = value;
investigation_statusChanged = true;
}
}
private string investigation_statusDbString
{
get
{
return investigation_status.ToString();
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
#region ModificationTime
private bool modification_timeChanged = false;
private DateTime? modification_time;
public DateTime? ModificationTime
{
get { return modification_time; }
set { 
modification_time = value;
modification_timeChanged = true;
}
}
private string modification_timeDbString
{
get
{
if (this.modification_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ModifiedBy
private bool modified_byChanged = false;
private int? modified_by;
public int? ModifiedBy
{
get { return modified_by; }
set { 
modified_by = value;
modified_byChanged = true;
}
}
private string modified_byDbString
{
get
{
if (this.modified_by.HasValue)
return modified_by.ToString();
else
return "null";
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
#endregion

#region InvestigationReader
public class InvestigationReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Investigation currentInvestigation;
Columns columns;
bool partialRead = false;
private InvestigationReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public InvestigationReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public InvestigationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentInvestigation; }

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
currentInvestigation = new Investigation();
if (partialRead)
{ if ((columns & Columns.investigation_id) == Columns.investigation_id && reader["investigation_id"]!=DBNull.Value)
currentInvestigation.investigation_id =(int) reader["investigation_id"]; 
if ((columns & Columns.investigation_reason_id) == Columns.investigation_reason_id && reader["investigation_reason_id"]!=DBNull.Value)
currentInvestigation.investigation_reason_id =(int) reader["investigation_reason_id"]; 
if ((columns & Columns.forward_to) == Columns.forward_to && reader["forward_to"]!=DBNull.Value)
currentInvestigation.forward_to =(int) reader["forward_to"]; 
if ((columns & Columns.investigation_summary) == Columns.investigation_summary && reader["investigation_summary"]!=DBNull.Value)
currentInvestigation.investigation_summary =(string) reader["investigation_summary"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentInvestigation.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.order_number) == Columns.order_number && reader["order_number"]!=DBNull.Value)
currentInvestigation.order_number =(string) reader["order_number"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentInvestigation.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.investigation_status) == Columns.investigation_status && reader["investigation_status"]!=DBNull.Value)
currentInvestigation.investigation_status =(int) reader["investigation_status"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentInvestigation.user_id =(int) reader["user_id"]; 
if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
currentInvestigation.modification_time =(DateTime?) reader["modification_time"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentInvestigation.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.resolution_time) == Columns.resolution_time && reader["resolution_time"]!=DBNull.Value)
currentInvestigation.resolution_time =(DateTime?) reader["resolution_time"]; 
if ((columns & Columns.resolved_by) == Columns.resolved_by && reader["resolved_by"]!=DBNull.Value)
currentInvestigation.resolved_by =(int?) reader["resolved_by"]; 

} else
{
if (reader["investigation_id"] != DBNull.Value)
currentInvestigation.investigation_id = (int) reader["investigation_id"]; 
if (reader["investigation_reason_id"] != DBNull.Value)
currentInvestigation.investigation_reason_id = (int) reader["investigation_reason_id"]; 
if (reader["forward_to"] != DBNull.Value)
currentInvestigation.forward_to = (int) reader["forward_to"]; 
if (reader["investigation_summary"] != DBNull.Value)
currentInvestigation.investigation_summary = (string) reader["investigation_summary"]; 
if (reader["creation_time"] != DBNull.Value)
currentInvestigation.creation_time = (DateTime) reader["creation_time"]; 
if (reader["order_number"] != DBNull.Value)
currentInvestigation.order_number = (string) reader["order_number"]; 
if (reader["atm_id"] != DBNull.Value)
currentInvestigation.atm_id = (int) reader["atm_id"]; 
if (reader["investigation_status"] != DBNull.Value)
currentInvestigation.investigation_status = (int) reader["investigation_status"]; 
if (reader["user_id"] != DBNull.Value)
currentInvestigation.user_id = (int) reader["user_id"]; 
if (reader["modification_time"] != DBNull.Value)
currentInvestigation.modification_time = (DateTime?) reader["modification_time"]; 
if (reader["modified_by"] != DBNull.Value)
currentInvestigation.modified_by = (int?) reader["modified_by"]; 
if (reader["resolution_time"] != DBNull.Value)
currentInvestigation.resolution_time = (DateTime?) reader["resolution_time"]; 
if (reader["resolved_by"] != DBNull.Value)
currentInvestigation.resolved_by = (int?) reader["resolved_by"]; 
} 

currentInvestigation.isNewEntity = false;
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

public Investigation CurrentInvestigation
{
get{ return currentInvestigation; }
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


#region Investigation functions

public static InvestigationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.investigation_id == (Columns.investigation_id & columns))
qry.Append("investigation_id,");
if (Columns.investigation_reason_id == (Columns.investigation_reason_id & columns))
qry.Append("investigation_reason_id,");
if (Columns.forward_to == (Columns.forward_to & columns))
qry.Append("forward_to,");
if (Columns.investigation_summary == (Columns.investigation_summary & columns))
qry.Append("investigation_summary,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.order_number == (Columns.order_number & columns))
qry.Append("order_number,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.investigation_status == (Columns.investigation_status & columns))
qry.Append("investigation_status,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.modification_time == (Columns.modification_time & columns))
qry.Append("modification_time,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.resolution_time == (Columns.resolution_time & columns))
qry.Append("resolution_time,");
if (Columns.resolved_by == (Columns.resolved_by & columns))
qry.Append("resolved_by,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Investigation ");

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
return new InvestigationReader(cmd.ExecuteReader(), conn, columns);
}

static public InvestigationReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static InvestigationReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select investigation_id,investigation_reason_id,forward_to,investigation_summary,creation_time,order_number,atm_id,investigation_status,user_id,modification_time,modified_by,resolution_time,resolved_by from Investigation ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new InvestigationReader(cmd.ExecuteReader(), conn);
}

static public InvestigationReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Investigation LoadInvestigation(string where)
{
InvestigationReader reader = Investigation.ExecuteReader(where);
Investigation _investigation = null;
if (reader.Read())
_investigation = reader.CurrentInvestigation;
reader.Close();
return _investigation;
}

public static Investigation LoadInvestigation(string where, IDbConnection conn)
{
InvestigationReader reader = Investigation.ExecuteReader(where, conn);
Investigation _investigation = null;
if (reader.Read())
_investigation = reader.CurrentInvestigation;
reader.Close(false);
return _investigation;
}

public static Investigation LoadInvestigationByPk( int investigation_id )
{
return LoadInvestigation( " investigation_id="+investigation_id );
}

public static Investigation LoadInvestigationByPk( int investigation_id , IDbConnection conn)
{
return LoadInvestigation(" investigation_id="+investigation_id , conn);
}

public void Save()
{
if (investigation_idChanged || investigation_reason_idChanged || forward_toChanged || investigation_summaryChanged || creation_timeChanged || order_numberChanged || atm_idChanged || investigation_statusChanged || user_idChanged || modification_timeChanged || modified_byChanged || resolution_timeChanged || resolved_byChanged )
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
if (investigation_idChanged || investigation_reason_idChanged || forward_toChanged || investigation_summaryChanged || creation_timeChanged || order_numberChanged || atm_idChanged || investigation_statusChanged || user_idChanged || modification_timeChanged || modified_byChanged || resolution_timeChanged || resolved_byChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Investigation( investigation_id,investigation_reason_id,forward_to,investigation_summary,creation_time,order_number,atm_id,investigation_status,user_id,modification_time,modified_by,resolution_time,resolved_by ) values(");
lock (ConnectionFactory.connectionString) { this.investigation_id = ConnectionFactory.GetNextId();
qry.Append(this.investigation_id);
} qry.Append(",");
qry.Append(investigation_reason_idDbString+",");
qry.Append(forward_toDbString+",");
qry.Append(investigation_summaryDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(order_numberDbString+",");
qry.Append(atm_idDbString+",");
qry.Append(investigation_statusDbString+",");
qry.Append(user_idDbString+",");
qry.Append(modification_timeDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(resolution_timeDbString+",");
qry.Append(resolved_byDbString);
qry.Append(");");

}
else
{
if (!(investigation_idChanged || investigation_reason_idChanged || forward_toChanged || investigation_summaryChanged || creation_timeChanged || order_numberChanged || atm_idChanged || investigation_statusChanged || user_idChanged || modification_timeChanged || modified_byChanged || resolution_timeChanged || resolved_byChanged ))
return;
qry.Append("UPDATE Investigation set "); if ( investigation_reason_idChanged )
{
qry.Append("investigation_reason_id ="+investigation_reason_idDbString);
qry.Append(",");
}

if ( forward_toChanged )
{
qry.Append("forward_to ="+forward_toDbString);
qry.Append(",");
}

if ( investigation_summaryChanged )
{
qry.Append("investigation_summary ="+investigation_summaryDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( order_numberChanged )
{
qry.Append("order_number ="+order_numberDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( investigation_statusChanged )
{
qry.Append("investigation_status ="+investigation_statusDbString);
qry.Append(",");
}

if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( modification_timeChanged )
{
qry.Append("modification_time ="+modification_timeDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
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


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("investigation_id = "+investigation_idDbString);
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
cmd.CommandText = "DELETE Investigation where investigation_id = "+ investigation_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteInvestigations(string where)
{
ConnectionFactory.ExecuteQuery("delete Investigation where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
investigation_id= 1,
investigation_reason_id= 2,
forward_to= 4,
investigation_summary= 8,
creation_time= 16,
order_number= 32,
atm_id= 64,
investigation_status= 128,
user_id= 256,
modification_time= 512,
modified_by= 1024,
resolution_time= 2048,
resolved_by= 4096
}
#endregion
public void BulkSave(List<Investigation> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Investigation";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Investigation.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Investigation> transList,ref DataTable dt)
{
foreach (Investigation tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["investigation_id"] =ConnectionFactory.GetNextId();
Row["investigation_reason_id"] = tran.InvestigationReasonId;
Row["forward_to"] = tran.ForwardTo;
Row["investigation_summary"] = tran.InvestigationSummary;
Row["creation_time"] = tran.CreationTime;
Row["order_number"] = tran.OrderNumber;
Row["atm_id"] = tran.AtmId;
Row["investigation_status"] = tran.InvestigationStatus;
Row["user_id"] = tran.UserId;
Row["modification_time"] = tran.ModificationTime;
Row["modified_by"] = tran.ModifiedBy;
Row["resolution_time"] = tran.ResolutionTime;
Row["resolved_by"] = tran.ResolvedBy;
dt.Rows.Add(Row);
} }
}
}
