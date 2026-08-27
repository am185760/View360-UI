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
public class AtmInterfaceInfo
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmInterfaceInfo() { }
public AtmInterfaceInfo( int atm_interface_info_id,int atm_id,string interface_friendly_name,DateTime creation_time,int created_by ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.interface_friendly_name = interface_friendly_name;
this.interface_friendly_nameChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
}
public AtmInterfaceInfo( int atm_id,string interface_friendly_name,string ip,DateTime creation_time,int created_by,DateTime? modification_time,int? modified_by )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.interface_friendly_name = interface_friendly_name;
this.interface_friendly_nameChanged = true;
this.ip = ip;
this.ipChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
}
private AtmInterfaceInfo( int atm_interface_info_id,int atm_id,string interface_friendly_name,string ip,DateTime creation_time,int created_by,DateTime? modification_time,int? modified_by )
{
this.atm_interface_info_id = atm_interface_info_id;
this.atm_interface_info_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.interface_friendly_name = interface_friendly_name;
this.interface_friendly_nameChanged = true;
this.ip = ip;
this.ipChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
}

#region members and properties for columns

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
#region InterfaceFriendlyName
private bool interface_friendly_nameChanged = false;
private string interface_friendly_name;
public string InterfaceFriendlyName
{
get { return interface_friendly_name; }
set { 
interface_friendly_name = value;
interface_friendly_nameChanged = true;
}
}
private string interface_friendly_nameDbString
{
get
{
if (this.interface_friendly_name!=null)
return string.Format("'{0}'",interface_friendly_name); else
return "null";
}
}
#endregion
#region Ip
private bool ipChanged = false;
private string ip;
public string Ip
{
get { return ip; }
set { 
ip = value;
ipChanged = true;
}
}
private string ipDbString
{
get
{
if (this.ip!=null)
return string.Format("'{0}'",ip); else
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
#region CreatedBy
private bool created_byChanged = false;
private int created_by;
public int CreatedBy
{
get { return created_by; }
set { 
created_by = value;
created_byChanged = true;
}
}
private string created_byDbString
{
get
{
return created_by.ToString();
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
#endregion

#region AtmInterfaceInfoReader
public class AtmInterfaceInfoReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmInterfaceInfo currentAtmInterfaceInfo;
Columns columns;
bool partialRead = false;
private AtmInterfaceInfoReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmInterfaceInfoReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmInterfaceInfoReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmInterfaceInfo; }

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
currentAtmInterfaceInfo = new AtmInterfaceInfo();
if (partialRead)
{ if ((columns & Columns.atm_interface_info_id) == Columns.atm_interface_info_id && reader["atm_interface_info_id"]!=DBNull.Value)
currentAtmInterfaceInfo.atm_interface_info_id =(int) reader["atm_interface_info_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmInterfaceInfo.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.interface_friendly_name) == Columns.interface_friendly_name && reader["interface_friendly_name"]!=DBNull.Value)
currentAtmInterfaceInfo.interface_friendly_name =(string) reader["interface_friendly_name"]; 
if ((columns & Columns.ip) == Columns.ip && reader["ip"]!=DBNull.Value)
currentAtmInterfaceInfo.ip =(string) reader["ip"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentAtmInterfaceInfo.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentAtmInterfaceInfo.created_by =(int) reader["created_by"]; 
if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
currentAtmInterfaceInfo.modification_time =(DateTime?) reader["modification_time"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentAtmInterfaceInfo.modified_by =(int?) reader["modified_by"]; 

} else
{
if (reader["atm_interface_info_id"] != DBNull.Value)
currentAtmInterfaceInfo.atm_interface_info_id = (int) reader["atm_interface_info_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmInterfaceInfo.atm_id = (int) reader["atm_id"]; 
if (reader["interface_friendly_name"] != DBNull.Value)
currentAtmInterfaceInfo.interface_friendly_name = (string) reader["interface_friendly_name"]; 
if (reader["ip"] != DBNull.Value)
currentAtmInterfaceInfo.ip = (string) reader["ip"]; 
if (reader["creation_time"] != DBNull.Value)
currentAtmInterfaceInfo.creation_time = (DateTime) reader["creation_time"]; 
if (reader["created_by"] != DBNull.Value)
currentAtmInterfaceInfo.created_by = (int) reader["created_by"]; 
if (reader["modification_time"] != DBNull.Value)
currentAtmInterfaceInfo.modification_time = (DateTime?) reader["modification_time"]; 
if (reader["modified_by"] != DBNull.Value)
currentAtmInterfaceInfo.modified_by = (int?) reader["modified_by"]; 
} 

currentAtmInterfaceInfo.isNewEntity = false;
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

public AtmInterfaceInfo CurrentAtmInterfaceInfo
{
get{ return currentAtmInterfaceInfo; }
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


#region AtmInterfaceInfo functions

public static AtmInterfaceInfoReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_interface_info_id == (Columns.atm_interface_info_id & columns))
qry.Append("atm_interface_info_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.interface_friendly_name == (Columns.interface_friendly_name & columns))
qry.Append("interface_friendly_name,");
if (Columns.ip == (Columns.ip & columns))
qry.Append("ip,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modification_time == (Columns.modification_time & columns))
qry.Append("modification_time,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_interface_info ");

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
return new AtmInterfaceInfoReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmInterfaceInfoReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmInterfaceInfoReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_interface_info_id,atm_id,interface_friendly_name,ip,creation_time,created_by,modification_time,modified_by from Atm_interface_info ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmInterfaceInfoReader(cmd.ExecuteReader(), conn);
}

static public AtmInterfaceInfoReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmInterfaceInfo LoadAtmInterfaceInfo(string where)
{
AtmInterfaceInfoReader reader = AtmInterfaceInfo.ExecuteReader(where);
AtmInterfaceInfo _atminterfaceinfo = null;
if (reader.Read())
_atminterfaceinfo = reader.CurrentAtmInterfaceInfo;
reader.Close();
return _atminterfaceinfo;
}

public static AtmInterfaceInfo LoadAtmInterfaceInfo(string where, IDbConnection conn)
{
AtmInterfaceInfoReader reader = AtmInterfaceInfo.ExecuteReader(where, conn);
AtmInterfaceInfo _atminterfaceinfo = null;
if (reader.Read())
_atminterfaceinfo = reader.CurrentAtmInterfaceInfo;
reader.Close(false);
return _atminterfaceinfo;
}

public static AtmInterfaceInfo LoadAtmInterfaceInfoByPk( int atm_interface_info_id )
{
return LoadAtmInterfaceInfo( " atm_interface_info_id="+atm_interface_info_id );
}

public static AtmInterfaceInfo LoadAtmInterfaceInfoByPk( int atm_interface_info_id , IDbConnection conn)
{
return LoadAtmInterfaceInfo(" atm_interface_info_id="+atm_interface_info_id , conn);
}

public void Save()
{
if (atm_interface_info_idChanged || atm_idChanged || interface_friendly_nameChanged || ipChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged )
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
if (atm_interface_info_idChanged || atm_idChanged || interface_friendly_nameChanged || ipChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_interface_info( atm_interface_info_id,atm_id,interface_friendly_name,ip,creation_time,created_by,modification_time,modified_by ) values(");
lock (ConnectionFactory.connectionString) { this.atm_interface_info_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_interface_info_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(interface_friendly_nameDbString+",");
qry.Append(ipDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modification_timeDbString+",");
qry.Append(modified_byDbString);
qry.Append(");");

}
else
{
if (!(atm_interface_info_idChanged || atm_idChanged || interface_friendly_nameChanged || ipChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged ))
return;
qry.Append("UPDATE Atm_interface_info set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( interface_friendly_nameChanged )
{
qry.Append("interface_friendly_name ="+interface_friendly_nameDbString);
qry.Append(",");
}

if ( ipChanged )
{
qry.Append("ip ="+ipDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
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


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_interface_info_id = "+atm_interface_info_idDbString);
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
cmd.CommandText = "DELETE Atm_interface_info where atm_interface_info_id = "+ atm_interface_info_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmInterfaceInfos(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_interface_info where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_interface_info_id= 1,
atm_id= 2,
interface_friendly_name= 4,
ip= 8,
creation_time= 16,
created_by= 32,
modification_time= 64,
modified_by= 128
}
#endregion
public void BulkSave(List<AtmInterfaceInfo> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_interface_info";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmInterfaceInfo.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmInterfaceInfo> transList,ref DataTable dt)
{
foreach (AtmInterfaceInfo tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_interface_info_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["interface_friendly_name"] = tran.InterfaceFriendlyName;
Row["ip"] = tran.Ip;
Row["creation_time"] = tran.CreationTime;
Row["created_by"] = tran.CreatedBy;
Row["modification_time"] = tran.ModificationTime;
Row["modified_by"] = tran.ModifiedBy;
dt.Rows.Add(Row);
} }
}
}
