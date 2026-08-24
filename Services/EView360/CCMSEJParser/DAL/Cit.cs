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
public class Cit
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Cit() { }
public Cit( int cit_internal_id,int created_by,DateTime creation_time ) 
{
this.created_by = created_by;
this.created_byChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
}
public Cit( string name,string location,string id,string team_id,string cc_id,int created_by,int? modified_by,DateTime creation_time,bool? is_active )
{
this.name = name;
this.nameChanged = true;
this.location = location;
this.locationChanged = true;
this.id = id;
this.idChanged = true;
this.team_id = team_id;
this.team_idChanged = true;
this.cc_id = cc_id;
this.cc_idChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}
private Cit( int cit_internal_id,string name,string location,string id,string team_id,string cc_id,int created_by,int? modified_by,DateTime creation_time,bool? is_active )
{
this.cit_internal_id = cit_internal_id;
this.cit_internal_idChanged = true;
this.name = name;
this.nameChanged = true;
this.location = location;
this.locationChanged = true;
this.id = id;
this.idChanged = true;
this.team_id = team_id;
this.team_idChanged = true;
this.cc_id = cc_id;
this.cc_idChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
}

#region members and properties for columns

#region CitInternalId
private bool cit_internal_idChanged = false;
private int cit_internal_id;
public int CitInternalId
{
get { return cit_internal_id; }
set { 
cit_internal_id = value;
cit_internal_idChanged = true;
}
}
private string cit_internal_idDbString
{
get
{
return cit_internal_id.ToString();
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
#region Location
private bool locationChanged = false;
private string location;
public string Location
{
get { return location; }
set { 
location = value;
locationChanged = true;
}
}
private string locationDbString
{
get
{
if (this.location!=null)
return string.Format("'{0}'",location); else
return "null";
}
}
#endregion
#region Id
private bool idChanged = false;
private string id;
public string Id
{
get { return id; }
set { 
id = value;
idChanged = true;
}
}
private string idDbString
{
get
{
if (this.id!=null)
return string.Format("'{0}'",id); else
return "null";
}
}
#endregion
#region TeamId
private bool team_idChanged = false;
private string team_id;
public string TeamId
{
get { return team_id; }
set { 
team_id = value;
team_idChanged = true;
}
}
private string team_idDbString
{
get
{
if (this.team_id!=null)
return string.Format("'{0}'",team_id); else
return "null";
}
}
#endregion
#region CcId
private bool cc_idChanged = false;
private string cc_id;
public string CcId
{
get { return cc_id; }
set { 
cc_id = value;
cc_idChanged = true;
}
}
private string cc_idDbString
{
get
{
if (this.cc_id!=null)
return string.Format("'{0}'",cc_id); else
return "null";
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
#region IsActive
private bool is_activeChanged = false;
private bool? is_active;
public bool? IsActive
{
get { return is_active; }
set { 
is_active = value;
is_activeChanged = true;
}
}
private string is_activeDbString
{
get
{
if (this.is_active.HasValue)
return is_active.Value?"1":"0";
else
return "null";
}
}
#endregion
#endregion

#region CitReader
public class CitReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Cit currentCit;
Columns columns;
bool partialRead = false;
private CitReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CitReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CitReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCit; }

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
currentCit = new Cit();
if (partialRead)
{ if ((columns & Columns.cit_internal_id) == Columns.cit_internal_id && reader["cit_internal_id"]!=DBNull.Value)
currentCit.cit_internal_id =(int) reader["cit_internal_id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCit.name =(string) reader["name"]; 
if ((columns & Columns.location) == Columns.location && reader["location"]!=DBNull.Value)
currentCit.location =(string) reader["location"]; 
if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCit.id =(string) reader["id"]; 
if ((columns & Columns.team_id) == Columns.team_id && reader["team_id"]!=DBNull.Value)
currentCit.team_id =(string) reader["team_id"]; 
if ((columns & Columns.cc_id) == Columns.cc_id && reader["cc_id"]!=DBNull.Value)
currentCit.cc_id =(string) reader["cc_id"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCit.created_by =(int) reader["created_by"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCit.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentCit.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentCit.is_active =(bool?) reader["is_active"]; 

} else
{
if (reader["cit_internal_id"] != DBNull.Value)
currentCit.cit_internal_id = (int) reader["cit_internal_id"]; 
if (reader["name"] != DBNull.Value)
currentCit.name = (string) reader["name"]; 
if (reader["location"] != DBNull.Value)
currentCit.location = (string) reader["location"]; 
if (reader["id"] != DBNull.Value)
currentCit.id = (string) reader["id"]; 
if (reader["team_id"] != DBNull.Value)
currentCit.team_id = (string) reader["team_id"]; 
if (reader["cc_id"] != DBNull.Value)
currentCit.cc_id = (string) reader["cc_id"]; 
if (reader["created_by"] != DBNull.Value)
currentCit.created_by = (int) reader["created_by"]; 
if (reader["modified_by"] != DBNull.Value)
currentCit.modified_by = (int?) reader["modified_by"]; 
if (reader["creation_time"] != DBNull.Value)
currentCit.creation_time = (DateTime) reader["creation_time"]; 
if (reader["is_active"] != DBNull.Value)
currentCit.is_active = (bool?) reader["is_active"]; 
} 

currentCit.isNewEntity = false;
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

public Cit CurrentCit
{
get{ return currentCit; }
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


#region Cit functions

public static CitReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.cit_internal_id == (Columns.cit_internal_id & columns))
qry.Append("cit_internal_id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.location == (Columns.location & columns))
qry.Append("location,");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.team_id == (Columns.team_id & columns))
qry.Append("team_id,");
if (Columns.cc_id == (Columns.cc_id & columns))
qry.Append("cc_id,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Cit ");

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
return new CitReader(cmd.ExecuteReader(), conn, columns);
}

static public CitReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CitReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select cit_internal_id,name,location,id,team_id,cc_id,created_by,modified_by,creation_time,is_active from Cit ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CitReader(cmd.ExecuteReader(), conn);
}

static public CitReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Cit LoadCit(string where)
{
CitReader reader = Cit.ExecuteReader(where);
Cit _cit = null;
if (reader.Read())
_cit = reader.CurrentCit;
reader.Close();
return _cit;
}

public static Cit LoadCit(string where, IDbConnection conn)
{
CitReader reader = Cit.ExecuteReader(where, conn);
Cit _cit = null;
if (reader.Read())
_cit = reader.CurrentCit;
reader.Close(false);
return _cit;
}

public static Cit LoadCitByPk( int cit_internal_id )
{
return LoadCit( " cit_internal_id="+cit_internal_id );
}

public static Cit LoadCitByPk( int cit_internal_id , IDbConnection conn)
{
return LoadCit(" cit_internal_id="+cit_internal_id , conn);
}

public void Save()
{
if (cit_internal_idChanged || nameChanged || locationChanged || idChanged || team_idChanged || cc_idChanged || created_byChanged || modified_byChanged || creation_timeChanged || is_activeChanged )
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
if (cit_internal_idChanged || nameChanged || locationChanged || idChanged || team_idChanged || cc_idChanged || created_byChanged || modified_byChanged || creation_timeChanged || is_activeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Cit( cit_internal_id,name,location,id,team_id,cc_id,created_by,modified_by,creation_time,is_active ) values(");
lock (ConnectionFactory.connectionString) { this.cit_internal_id = ConnectionFactory.GetNextId();
qry.Append(this.cit_internal_id);
} qry.Append(",");
qry.Append(nameDbString+",");
qry.Append(locationDbString+",");
qry.Append(idDbString+",");
qry.Append(team_idDbString+",");
qry.Append(cc_idDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(is_activeDbString);
qry.Append(");");

}
else
{
if (!(cit_internal_idChanged || nameChanged || locationChanged || idChanged || team_idChanged || cc_idChanged || created_byChanged || modified_byChanged || creation_timeChanged || is_activeChanged ))
return;
qry.Append("UPDATE Cit set "); if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( locationChanged )
{
qry.Append("location ="+locationDbString);
qry.Append(",");
}

if ( idChanged )
{
qry.Append("id ="+idDbString);
qry.Append(",");
}

if ( team_idChanged )
{
qry.Append("team_id ="+team_idDbString);
qry.Append(",");
}

if ( cc_idChanged )
{
qry.Append("cc_id ="+cc_idDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("cit_internal_id = "+cit_internal_idDbString);
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
cmd.CommandText = "DELETE Cit where cit_internal_id = "+ cit_internal_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCits(string where)
{
ConnectionFactory.ExecuteQuery("delete Cit where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
cit_internal_id= 1,
name= 2,
location= 4,
id= 8,
team_id= 16,
cc_id= 32,
created_by= 64,
modified_by= 128,
creation_time= 256,
is_active= 512
}
#endregion
public void BulkSave(List<Cit> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Cit";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Cit.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Cit> transList,ref DataTable dt)
{
foreach (Cit tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["cit_internal_id"] =ConnectionFactory.GetNextId();
Row["name"] = tran.Name;
Row["location"] = tran.Location;
Row["id"] = tran.Id;
Row["team_id"] = tran.TeamId;
Row["cc_id"] = tran.CcId;
Row["created_by"] = tran.CreatedBy;
Row["modified_by"] = tran.ModifiedBy;
Row["creation_time"] = tran.CreationTime;
Row["is_active"] = tran.IsActive;
dt.Rows.Add(Row);
} }
}
}
