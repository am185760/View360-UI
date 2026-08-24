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
public class AtmInterfaceCurrentStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmInterfaceCurrentStatus() { }
public AtmInterfaceCurrentStatus( int atm_interface_info_id,int interface_status,int atm_id )
{
this.atm_interface_info_id = atm_interface_info_id;
this.atm_interface_info_idChanged = true;
this.interface_status = interface_status;
this.interface_statusChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private AtmInterfaceCurrentStatus( int atm_interface_current_status_id,int atm_interface_info_id,int interface_status,int atm_id )
{
this.atm_interface_current_status_id = atm_interface_current_status_id;
this.atm_interface_current_status_idChanged = true;
this.atm_interface_info_id = atm_interface_info_id;
this.atm_interface_info_idChanged = true;
this.interface_status = interface_status;
this.interface_statusChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region AtmInterfaceCurrentStatusId
private bool atm_interface_current_status_idChanged = false;
private int atm_interface_current_status_id;
public int AtmInterfaceCurrentStatusId
{
get { return atm_interface_current_status_id; }
set { 
atm_interface_current_status_id = value;
atm_interface_current_status_idChanged = true;
}
}
private string atm_interface_current_status_idDbString
{
get
{
return atm_interface_current_status_id.ToString();
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
#region InterfaceStatus
private bool interface_statusChanged = false;
private int interface_status;
public int InterfaceStatus
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
return interface_status.ToString();
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

#region AtmInterfaceCurrentStatusReader
public class AtmInterfaceCurrentStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmInterfaceCurrentStatus currentAtmInterfaceCurrentStatus;
Columns columns;
bool partialRead = false;
private AtmInterfaceCurrentStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmInterfaceCurrentStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmInterfaceCurrentStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmInterfaceCurrentStatus; }

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
currentAtmInterfaceCurrentStatus = new AtmInterfaceCurrentStatus();
if (partialRead)
{ if ((columns & Columns.atm_interface_current_status_id) == Columns.atm_interface_current_status_id && reader["atm_interface_current_status_id"]!=DBNull.Value)
currentAtmInterfaceCurrentStatus.atm_interface_current_status_id =(int) reader["atm_interface_current_status_id"]; 
if ((columns & Columns.atm_interface_info_id) == Columns.atm_interface_info_id && reader["atm_interface_info_id"]!=DBNull.Value)
currentAtmInterfaceCurrentStatus.atm_interface_info_id =(int) reader["atm_interface_info_id"]; 
if ((columns & Columns.interface_status) == Columns.interface_status && reader["interface_status"]!=DBNull.Value)
currentAtmInterfaceCurrentStatus.interface_status =(int) reader["interface_status"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmInterfaceCurrentStatus.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["atm_interface_current_status_id"] != DBNull.Value)
currentAtmInterfaceCurrentStatus.atm_interface_current_status_id = (int) reader["atm_interface_current_status_id"]; 
if (reader["atm_interface_info_id"] != DBNull.Value)
currentAtmInterfaceCurrentStatus.atm_interface_info_id = (int) reader["atm_interface_info_id"]; 
if (reader["interface_status"] != DBNull.Value)
currentAtmInterfaceCurrentStatus.interface_status = (int) reader["interface_status"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmInterfaceCurrentStatus.atm_id = (int) reader["atm_id"]; 
} 

currentAtmInterfaceCurrentStatus.isNewEntity = false;
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

public AtmInterfaceCurrentStatus CurrentAtmInterfaceCurrentStatus
{
get{ return currentAtmInterfaceCurrentStatus; }
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


#region AtmInterfaceCurrentStatus functions

public static AtmInterfaceCurrentStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_interface_current_status_id == (Columns.atm_interface_current_status_id & columns))
qry.Append("atm_interface_current_status_id,");
if (Columns.atm_interface_info_id == (Columns.atm_interface_info_id & columns))
qry.Append("atm_interface_info_id,");
if (Columns.interface_status == (Columns.interface_status & columns))
qry.Append("interface_status,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_interface_current_status ");

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
return new AtmInterfaceCurrentStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmInterfaceCurrentStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmInterfaceCurrentStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_interface_current_status_id,atm_interface_info_id,interface_status,atm_id from Atm_interface_current_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmInterfaceCurrentStatusReader(cmd.ExecuteReader(), conn);
}

static public AtmInterfaceCurrentStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmInterfaceCurrentStatus LoadAtmInterfaceCurrentStatus(string where)
{
AtmInterfaceCurrentStatusReader reader = AtmInterfaceCurrentStatus.ExecuteReader(where);
AtmInterfaceCurrentStatus _atminterfacecurrentstatus = null;
if (reader.Read())
_atminterfacecurrentstatus = reader.CurrentAtmInterfaceCurrentStatus;
reader.Close();
return _atminterfacecurrentstatus;
}

public static AtmInterfaceCurrentStatus LoadAtmInterfaceCurrentStatus(string where, IDbConnection conn)
{
AtmInterfaceCurrentStatusReader reader = AtmInterfaceCurrentStatus.ExecuteReader(where, conn);
AtmInterfaceCurrentStatus _atminterfacecurrentstatus = null;
if (reader.Read())
_atminterfacecurrentstatus = reader.CurrentAtmInterfaceCurrentStatus;
reader.Close(false);
return _atminterfacecurrentstatus;
}

public static AtmInterfaceCurrentStatus LoadAtmInterfaceCurrentStatusByPk( int atm_interface_current_status_id )
{
return LoadAtmInterfaceCurrentStatus( " atm_interface_current_status_id="+atm_interface_current_status_id );
}

public static AtmInterfaceCurrentStatus LoadAtmInterfaceCurrentStatusByPk( int atm_interface_current_status_id , IDbConnection conn)
{
return LoadAtmInterfaceCurrentStatus(" atm_interface_current_status_id="+atm_interface_current_status_id , conn);
}

public void Save()
{
if (atm_interface_current_status_idChanged || atm_interface_info_idChanged || interface_statusChanged || atm_idChanged )
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
if (atm_interface_current_status_idChanged || atm_interface_info_idChanged || interface_statusChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_interface_current_status( atm_interface_current_status_id,atm_interface_info_id,interface_status,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.atm_interface_current_status_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_interface_current_status_id);
} qry.Append(",");
qry.Append(atm_interface_info_idDbString+",");
qry.Append(interface_statusDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(atm_interface_current_status_idChanged || atm_interface_info_idChanged || interface_statusChanged || atm_idChanged ))
return;
qry.Append("UPDATE Atm_interface_current_status set "); if ( atm_interface_info_idChanged )
{
qry.Append("atm_interface_info_id ="+atm_interface_info_idDbString);
qry.Append(",");
}

if ( interface_statusChanged )
{
qry.Append("interface_status ="+interface_statusDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_interface_current_status_id = "+atm_interface_current_status_idDbString);
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
cmd.CommandText = "DELETE Atm_interface_current_status where atm_interface_current_status_id = "+ atm_interface_current_status_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmInterfaceCurrentStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_interface_current_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_interface_current_status_id= 1,
atm_interface_info_id= 2,
interface_status= 4,
atm_id= 8
}
#endregion
public void BulkSave(List<AtmInterfaceCurrentStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_interface_current_status";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmInterfaceCurrentStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmInterfaceCurrentStatus> transList,ref DataTable dt)
{
foreach (AtmInterfaceCurrentStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_interface_current_status_id"] =ConnectionFactory.GetNextId();
Row["atm_interface_info_id"] = tran.AtmInterfaceInfoId;
Row["interface_status"] = tran.InterfaceStatus;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
