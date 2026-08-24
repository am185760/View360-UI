
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
public class AtmBandwidth
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmBandwidth() { }
public AtmBandwidth(int atm_bandwidth_id) 
{
}
public AtmBandwidth(string atm_bandwidth_name,int? link_speed_kbps,DateTime? creation_time,int? created_by,DateTime? modification_time,int? modified_by)
{
this.atm_bandwidth_name = atm_bandwidth_name;
this.atm_bandwidth_nameChanged = true;
this.link_speed_kbps = link_speed_kbps;
this.link_speed_kbpsChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modification_time = modification_time;
this.modification_timeChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
}
private AtmBandwidth(int atm_bandwidth_id,string atm_bandwidth_name,int? link_speed_kbps,DateTime? creation_time,int? created_by,DateTime? modification_time,int? modified_by)
{
this.atm_bandwidth_id = atm_bandwidth_id;
this.atm_bandwidth_idChanged = true;
this.atm_bandwidth_name = atm_bandwidth_name;
this.atm_bandwidth_nameChanged = true;
this.link_speed_kbps = link_speed_kbps;
this.link_speed_kbpsChanged = true;
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

#region AtmBandwidthId
private bool atm_bandwidth_idChanged = false;
private int atm_bandwidth_id;
public int AtmBandwidthId
{
get { return atm_bandwidth_id; }
set { 
atm_bandwidth_id = value;
atm_bandwidth_idChanged = true;
}
}
private string atm_bandwidth_idDbString
{
get
{
return atm_bandwidth_id.ToString();
}
}
#endregion
#region AtmBandwidthName
private bool atm_bandwidth_nameChanged = false;
private string atm_bandwidth_name;
public string AtmBandwidthName
{
get { return atm_bandwidth_name; }
set { 
atm_bandwidth_name = value;
atm_bandwidth_nameChanged = true;
}
}
private string atm_bandwidth_nameDbString
{
get
{
if (this.atm_bandwidth_name!=null)
return string.Format("'{0}'",atm_bandwidth_name);else
return "null";
}
}
#endregion
#region LinkSpeedKbps
private bool link_speed_kbpsChanged = false;
private int? link_speed_kbps;
public int? LinkSpeedKbps
{
get { return link_speed_kbps; }
set { 
link_speed_kbps = value;
link_speed_kbpsChanged = true;
}
}
private string link_speed_kbpsDbString
{
get
{
if (this.link_speed_kbps.HasValue)
return link_speed_kbps.ToString();
else
return "null";
}
}
#endregion
#region CreationTime
private bool creation_timeChanged = false;
private DateTime? creation_time;
public DateTime? CreationTime
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
if (this.creation_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",creation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region CreatedBy
private bool created_byChanged = false;
private int? created_by;
public int? CreatedBy
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
if (this.created_by.HasValue)
return created_by.ToString();
else
return "null";
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

#region AtmBandwidthReader
public class AtmBandwidthReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmBandwidth currentAtmBandwidth;
Columns columns;
bool partialRead = false;
private AtmBandwidthReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmBandwidthReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmBandwidthReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get{ return currentAtmBandwidth; }

}public void Close()
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
currentAtmBandwidth = new AtmBandwidth();
if (partialRead)
{if ((columns & Columns.atm_bandwidth_id) == Columns.atm_bandwidth_id && reader["atm_bandwidth_id"]!=DBNull.Value)
currentAtmBandwidth.atm_bandwidth_id =(int) reader["atm_bandwidth_id"]; 
if ((columns & Columns.atm_bandwidth_name) == Columns.atm_bandwidth_name && reader["atm_bandwidth_name"]!=DBNull.Value)
currentAtmBandwidth.atm_bandwidth_name =(string) reader["atm_bandwidth_name"]; 
if ((columns & Columns.link_speed_kbps) == Columns.link_speed_kbps && reader["link_speed_kbps"]!=DBNull.Value)
currentAtmBandwidth.link_speed_kbps =(int?) reader["link_speed_kbps"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentAtmBandwidth.creation_time =(DateTime?) reader["creation_time"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentAtmBandwidth.created_by =(int?) reader["created_by"]; 
if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
currentAtmBandwidth.modification_time =(DateTime?) reader["modification_time"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentAtmBandwidth.modified_by =(int?) reader["modified_by"]; 

}else
{
if (reader["atm_bandwidth_id"] != DBNull.Value)
currentAtmBandwidth.atm_bandwidth_id = (int) reader["atm_bandwidth_id"]; 
if (reader["atm_bandwidth_name"] != DBNull.Value)
currentAtmBandwidth.atm_bandwidth_name = (string) reader["atm_bandwidth_name"]; 
if (reader["link_speed_kbps"] != DBNull.Value)
currentAtmBandwidth.link_speed_kbps = (int?) reader["link_speed_kbps"]; 
if (reader["creation_time"] != DBNull.Value)
currentAtmBandwidth.creation_time = (DateTime?) reader["creation_time"]; 
if (reader["created_by"] != DBNull.Value)
currentAtmBandwidth.created_by = (int?) reader["created_by"]; 
if (reader["modification_time"] != DBNull.Value)
currentAtmBandwidth.modification_time = (DateTime?) reader["modification_time"]; 
if (reader["modified_by"] != DBNull.Value)
currentAtmBandwidth.modified_by = (int?) reader["modified_by"]; 
} 

currentAtmBandwidth.isNewEntity = false;
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

public AtmBandwidth CurrentAtmBandwidth
{
get{ return currentAtmBandwidth; }
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


#region AtmBandwidth functions

public static AtmBandwidthReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_bandwidth_id == (Columns.atm_bandwidth_id & columns))
qry.Append("atm_bandwidth_id,");
if (Columns.atm_bandwidth_name == (Columns.atm_bandwidth_name & columns))
qry.Append("atm_bandwidth_name,");
if (Columns.link_speed_kbps == (Columns.link_speed_kbps & columns))
qry.Append("link_speed_kbps,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modification_time == (Columns.modification_time & columns))
qry.Append("modification_time,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_bandwidth ");

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
return new AtmBandwidthReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmBandwidthReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmBandwidthReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_bandwidth_id,atm_bandwidth_name,link_speed_kbps,creation_time,created_by,modification_time,modified_by from Atm_bandwidth ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmBandwidthReader(cmd.ExecuteReader(), conn);
}

static public AtmBandwidthReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmBandwidth LoadAtmBandwidth(string where)
{
AtmBandwidthReader reader = AtmBandwidth.ExecuteReader(where);
AtmBandwidth _atmbandwidth = null;
if (reader.Read())
_atmbandwidth = reader.CurrentAtmBandwidth;
reader.Close();
return _atmbandwidth;
}

public static AtmBandwidth LoadAtmBandwidth(string where, IDbConnection conn)
{
AtmBandwidthReader reader = AtmBandwidth.ExecuteReader(where, conn);
AtmBandwidth _atmbandwidth = null;
if (reader.Read())
_atmbandwidth = reader.CurrentAtmBandwidth;
reader.Close(false);
return _atmbandwidth;
}

public static AtmBandwidth LoadAtmBandwidthByPk(int atm_bandwidth_id)
{
return LoadAtmBandwidth("atm_bandwidth_id="+atm_bandwidth_id);
}

public static AtmBandwidth LoadAtmBandwidthByPk(int atm_bandwidth_id, IDbConnection conn)
{
return LoadAtmBandwidth(" atm_bandwidth_id="+atm_bandwidth_id, conn);
}

public void Save()
{
if (atm_bandwidth_idChanged|| atm_bandwidth_nameChanged|| link_speed_kbpsChanged|| creation_timeChanged|| created_byChanged|| modification_timeChanged|| modified_byChanged)
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
private void ExcuteSave(IDbCommand cmd){
if (atm_bandwidth_idChanged|| atm_bandwidth_nameChanged|| link_speed_kbpsChanged|| creation_timeChanged|| created_byChanged|| modification_timeChanged|| modified_byChanged)
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_bandwidth(atm_bandwidth_id,atm_bandwidth_name,link_speed_kbps,creation_time,created_by,modification_time,modified_by) values(");
lock (ConnectionFactory.connectionString){this.atm_bandwidth_id =ConnectionFactory.GetNextId();
qry.Append(this.atm_bandwidth_id);
}qry.Append(",");
qry.Append(atm_bandwidth_nameDbString+",");
qry.Append(link_speed_kbpsDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modification_timeDbString+",");
qry.Append(modified_byDbString);
qry.Append(");");

}
else
{
if (!(atm_bandwidth_idChanged|| atm_bandwidth_nameChanged|| link_speed_kbpsChanged|| creation_timeChanged|| created_byChanged|| modification_timeChanged|| modified_byChanged))
return;
qry.Append("UPDATE Atm_bandwidth set ");if (atm_bandwidth_nameChanged)
{
qry.Append("atm_bandwidth_name ="+atm_bandwidth_nameDbString);
qry.Append(",");
}

if (link_speed_kbpsChanged)
{
qry.Append("link_speed_kbps ="+link_speed_kbpsDbString);
qry.Append(",");
}

if (creation_timeChanged)
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if (created_byChanged)
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if (modification_timeChanged)
{
qry.Append("modification_time ="+modification_timeDbString);
qry.Append(",");
}

if (modified_byChanged)
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_bandwidth_id = "+atm_bandwidth_idDbString);
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
cmd.CommandText = "DELETE Atm_bandwidth where atm_bandwidth_id= "+ atm_bandwidth_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmBandwidths(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_bandwidth where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_bandwidth_id= 1,
atm_bandwidth_name= 2,
link_speed_kbps= 4,
creation_time= 8,
created_by= 16,
modification_time= 32,
modified_by= 64
}
#endregion
public void BulkSave(List<AtmBandwidth>dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_bandwidth";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmBandwidth.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmBandwidth>transList,ref DataTable dt)
{
foreach (AtmBandwidth tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_bandwidth_id"] =ConnectionFactory.GetNextId();
Row["atm_bandwidth_name"] = tran.AtmBandwidthName;
Row["link_speed_kbps"] = tran.LinkSpeedKbps;
Row["creation_time"] = tran.CreationTime;
Row["created_by"] = tran.CreatedBy;
Row["modification_time"] = tran.ModificationTime;
Row["modified_by"] = tran.ModifiedBy;
dt.Rows.Add(Row);
}}
}
}

 
