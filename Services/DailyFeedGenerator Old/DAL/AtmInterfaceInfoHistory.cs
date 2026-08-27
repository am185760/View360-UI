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
public class AtmInterfaceInfoHistory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmInterfaceInfoHistory() { }
public AtmInterfaceInfoHistory( int atm_interface_info_history_id,int atm_interface_info_id ) 
{
this.atm_interface_info_id = atm_interface_info_id;
this.atm_interface_info_idChanged = true;
}
public AtmInterfaceInfoHistory( int atm_interface_info_id,DateTime? from_date,DateTime? to_date,int? interface_status )
{
this.atm_interface_info_id = atm_interface_info_id;
this.atm_interface_info_idChanged = true;
this.from_date = from_date;
this.from_dateChanged = true;
this.to_date = to_date;
this.to_dateChanged = true;
this.interface_status = interface_status;
this.interface_statusChanged = true;
}
private AtmInterfaceInfoHistory( int atm_interface_info_history_id,int atm_interface_info_id,DateTime? from_date,DateTime? to_date,int? interface_status )
{
this.atm_interface_info_history_id = atm_interface_info_history_id;
this.atm_interface_info_history_idChanged = true;
this.atm_interface_info_id = atm_interface_info_id;
this.atm_interface_info_idChanged = true;
this.from_date = from_date;
this.from_dateChanged = true;
this.to_date = to_date;
this.to_dateChanged = true;
this.interface_status = interface_status;
this.interface_statusChanged = true;
}

#region members and properties for columns

#region AtmInterfaceInfoHistoryId
private bool atm_interface_info_history_idChanged = false;
private int atm_interface_info_history_id;
public int AtmInterfaceInfoHistoryId
{
get { return atm_interface_info_history_id; }
set { 
atm_interface_info_history_id = value;
atm_interface_info_history_idChanged = true;
}
}
private string atm_interface_info_history_idDbString
{
get
{
return atm_interface_info_history_id.ToString();
}
}
#endregion
#region AtmInterfaceInfoId
private bool atm_interface_info_idChanged = false;
private int atm_interface_info_id;
public int AtmInterfaceInfoId
{
get { return atm_interface_info_id; }
set { 
atm_interface_info_id = value;
atm_interface_info_idChanged = true;
}
}
private string atm_interface_info_idDbString
{
get
{
return atm_interface_info_id.ToString();
}
}
#endregion
#region FromDate
private bool from_dateChanged = false;
private DateTime? from_date;
public DateTime? FromDate
{
get { return from_date; }
set { 
from_date = value;
from_dateChanged = true;
}
}
private string from_dateDbString
{
get
{
if (this.from_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",from_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ToDate
private bool to_dateChanged = false;
private DateTime? to_date;
public DateTime? ToDate
{
get { return to_date; }
set { 
to_date = value;
to_dateChanged = true;
}
}
private string to_dateDbString
{
get
{
if (this.to_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",to_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region InterfaceStatus
private bool interface_statusChanged = false;
private int? interface_status;
public int? InterfaceStatus
{
get { return interface_status; }
set { 
interface_status = value;
interface_statusChanged = true;
}
}
private string interface_statusDbString
{
get
{
if (this.interface_status.HasValue)
return interface_status.ToString();
else
return "null";
}
}
#endregion
#endregion

#region AtmInterfaceInfoHistoryReader
public class AtmInterfaceInfoHistoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmInterfaceInfoHistory currentAtmInterfaceInfoHistory;
Columns columns;
bool partialRead = false;
private AtmInterfaceInfoHistoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmInterfaceInfoHistoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmInterfaceInfoHistoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmInterfaceInfoHistory; }

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
currentAtmInterfaceInfoHistory = new AtmInterfaceInfoHistory();
if (partialRead)
{ if ((columns & Columns.atm_interface_info_history_id) == Columns.atm_interface_info_history_id && reader["atm_interface_info_history_id"]!=DBNull.Value)
currentAtmInterfaceInfoHistory.atm_interface_info_history_id =(int) reader["atm_interface_info_history_id"]; 
if ((columns & Columns.atm_interface_info_id) == Columns.atm_interface_info_id && reader["atm_interface_info_id"]!=DBNull.Value)
currentAtmInterfaceInfoHistory.atm_interface_info_id =(int) reader["atm_interface_info_id"]; 
if ((columns & Columns.from_date) == Columns.from_date && reader["from_date"]!=DBNull.Value)
currentAtmInterfaceInfoHistory.from_date =(DateTime?) reader["from_date"]; 
if ((columns & Columns.to_date) == Columns.to_date && reader["to_date"]!=DBNull.Value)
currentAtmInterfaceInfoHistory.to_date =(DateTime?) reader["to_date"]; 
if ((columns & Columns.interface_status) == Columns.interface_status && reader["interface_status"]!=DBNull.Value)
currentAtmInterfaceInfoHistory.interface_status =(int?) reader["interface_status"]; 

} else
{
if (reader["atm_interface_info_history_id"] != DBNull.Value)
currentAtmInterfaceInfoHistory.atm_interface_info_history_id = (int) reader["atm_interface_info_history_id"]; 
if (reader["atm_interface_info_id"] != DBNull.Value)
currentAtmInterfaceInfoHistory.atm_interface_info_id = (int) reader["atm_interface_info_id"]; 
if (reader["from_date"] != DBNull.Value)
currentAtmInterfaceInfoHistory.from_date = (DateTime?) reader["from_date"]; 
if (reader["to_date"] != DBNull.Value)
currentAtmInterfaceInfoHistory.to_date = (DateTime?) reader["to_date"]; 
if (reader["interface_status"] != DBNull.Value)
currentAtmInterfaceInfoHistory.interface_status = (int?) reader["interface_status"]; 
} 

currentAtmInterfaceInfoHistory.isNewEntity = false;
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

public AtmInterfaceInfoHistory CurrentAtmInterfaceInfoHistory
{
get{ return currentAtmInterfaceInfoHistory; }
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


#region AtmInterfaceInfoHistory functions

public static AtmInterfaceInfoHistoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_interface_info_history_id == (Columns.atm_interface_info_history_id & columns))
qry.Append("atm_interface_info_history_id,");
if (Columns.atm_interface_info_id == (Columns.atm_interface_info_id & columns))
qry.Append("atm_interface_info_id,");
if (Columns.from_date == (Columns.from_date & columns))
qry.Append("from_date,");
if (Columns.to_date == (Columns.to_date & columns))
qry.Append("to_date,");
if (Columns.interface_status == (Columns.interface_status & columns))
qry.Append("interface_status,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_interface_info_history ");

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
return new AtmInterfaceInfoHistoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmInterfaceInfoHistoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmInterfaceInfoHistoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_interface_info_history_id,atm_interface_info_id,from_date,to_date,interface_status from Atm_interface_info_history ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmInterfaceInfoHistoryReader(cmd.ExecuteReader(), conn);
}

static public AtmInterfaceInfoHistoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmInterfaceInfoHistory LoadAtmInterfaceInfoHistory(string where)
{
AtmInterfaceInfoHistoryReader reader = AtmInterfaceInfoHistory.ExecuteReader(where);
AtmInterfaceInfoHistory _atminterfaceinfohistory = null;
if (reader.Read())
_atminterfaceinfohistory = reader.CurrentAtmInterfaceInfoHistory;
reader.Close();
return _atminterfaceinfohistory;
}

public static AtmInterfaceInfoHistory LoadAtmInterfaceInfoHistory(string where, IDbConnection conn)
{
AtmInterfaceInfoHistoryReader reader = AtmInterfaceInfoHistory.ExecuteReader(where, conn);
AtmInterfaceInfoHistory _atminterfaceinfohistory = null;
if (reader.Read())
_atminterfaceinfohistory = reader.CurrentAtmInterfaceInfoHistory;
reader.Close(false);
return _atminterfaceinfohistory;
}

public static AtmInterfaceInfoHistory LoadAtmInterfaceInfoHistoryByPk( int atm_interface_info_history_id )
{
return LoadAtmInterfaceInfoHistory( " atm_interface_info_history_id="+atm_interface_info_history_id );
}

public static AtmInterfaceInfoHistory LoadAtmInterfaceInfoHistoryByPk( int atm_interface_info_history_id , IDbConnection conn)
{
return LoadAtmInterfaceInfoHistory(" atm_interface_info_history_id="+atm_interface_info_history_id , conn);
}

public void Save()
{
if (atm_interface_info_history_idChanged || atm_interface_info_idChanged || from_dateChanged || to_dateChanged || interface_statusChanged )
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
if (atm_interface_info_history_idChanged || atm_interface_info_idChanged || from_dateChanged || to_dateChanged || interface_statusChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_interface_info_history( atm_interface_info_history_id,atm_interface_info_id,from_date,to_date,interface_status ) values(");
lock (ConnectionFactory.connectionString) { this.atm_interface_info_history_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_interface_info_history_id);
} qry.Append(",");
qry.Append(atm_interface_info_idDbString+",");
qry.Append(from_dateDbString+",");
qry.Append(to_dateDbString+",");
qry.Append(interface_statusDbString);
qry.Append(");");

}
else
{
if (!(atm_interface_info_history_idChanged || atm_interface_info_idChanged || from_dateChanged || to_dateChanged || interface_statusChanged ))
return;
qry.Append("UPDATE Atm_interface_info_history set "); if ( atm_interface_info_idChanged )
{
qry.Append("atm_interface_info_id ="+atm_interface_info_idDbString);
qry.Append(",");
}

if ( from_dateChanged )
{
qry.Append("from_date ="+from_dateDbString);
qry.Append(",");
}

if ( to_dateChanged )
{
qry.Append("to_date ="+to_dateDbString);
qry.Append(",");
}

if ( interface_statusChanged )
{
qry.Append("interface_status ="+interface_statusDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_interface_info_history_id = "+atm_interface_info_history_idDbString);
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
cmd.CommandText = "DELETE Atm_interface_info_history where atm_interface_info_history_id = "+ atm_interface_info_history_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmInterfaceInfoHistorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_interface_info_history where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_interface_info_history_id= 1,
atm_interface_info_id= 2,
from_date= 4,
to_date= 8,
interface_status= 16
}
#endregion
public void BulkSave(List<AtmInterfaceInfoHistory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_interface_info_history";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmInterfaceInfoHistory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmInterfaceInfoHistory> transList,ref DataTable dt)
{
foreach (AtmInterfaceInfoHistory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_interface_info_history_id"] =ConnectionFactory.GetNextId();
Row["atm_interface_info_id"] = tran.AtmInterfaceInfoId;
Row["from_date"] = tran.FromDate;
Row["to_date"] = tran.ToDate;
Row["interface_status"] = tran.InterfaceStatus;
dt.Rows.Add(Row);
} }
}
}
