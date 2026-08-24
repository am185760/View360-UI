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
public class CcmsOrgNoteSet
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsOrgNoteSet() { }
public CcmsOrgNoteSet( int id ) 
{
}
public CcmsOrgNoteSet( int? organization_id,string name,bool? is_default )
{
this.organization_id = organization_id;
this.organization_idChanged = true;
this.name = name;
this.nameChanged = true;
this.is_default = is_default;
this.is_defaultChanged = true;
}
private CcmsOrgNoteSet( int id,int? organization_id,string name,bool? is_default )
{
this.id = id;
this.idChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.name = name;
this.nameChanged = true;
this.is_default = is_default;
this.is_defaultChanged = true;
}

#region members and properties for columns

#region Id
private bool idChanged = false;
private int id;
public int Id
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
return id.ToString();
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
#region IsDefault
private bool is_defaultChanged = false;
private bool? is_default;
public bool? IsDefault
{
get { return is_default; }
set { 
is_default = value;
is_defaultChanged = true;
}
}
private string is_defaultDbString
{
get
{
if (this.is_default.HasValue)
return is_default.Value?"1":"0";
else
return "null";
}
}
#endregion
#endregion

#region CcmsOrgNoteSetReader
public class CcmsOrgNoteSetReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsOrgNoteSet currentCcmsOrgNoteSet;
Columns columns;
bool partialRead = false;
private CcmsOrgNoteSetReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsOrgNoteSetReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsOrgNoteSetReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsOrgNoteSet; }

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
currentCcmsOrgNoteSet = new CcmsOrgNoteSet();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsOrgNoteSet.id =(int) reader["id"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsOrgNoteSet.organization_id =(int?) reader["organization_id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCcmsOrgNoteSet.name =(string) reader["name"]; 
if ((columns & Columns.is_default) == Columns.is_default && reader["is_default"]!=DBNull.Value)
currentCcmsOrgNoteSet.is_default =(bool?) reader["is_default"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsOrgNoteSet.id = (int) reader["id"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsOrgNoteSet.organization_id = (int?) reader["organization_id"]; 
if (reader["name"] != DBNull.Value)
currentCcmsOrgNoteSet.name = (string) reader["name"]; 
if (reader["is_default"] != DBNull.Value)
currentCcmsOrgNoteSet.is_default = (bool?) reader["is_default"]; 
} 

currentCcmsOrgNoteSet.isNewEntity = false;
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

public CcmsOrgNoteSet CurrentCcmsOrgNoteSet
{
get{ return currentCcmsOrgNoteSet; }
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


#region CcmsOrgNoteSet functions

public static CcmsOrgNoteSetReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.is_default == (Columns.is_default & columns))
qry.Append("is_default,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_org_note_set ");

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
return new CcmsOrgNoteSetReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsOrgNoteSetReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsOrgNoteSetReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,organization_id,name,is_default from Ccms_org_note_set ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsOrgNoteSetReader(cmd.ExecuteReader(), conn);
}

static public CcmsOrgNoteSetReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsOrgNoteSet LoadCcmsOrgNoteSet(string where)
{
CcmsOrgNoteSetReader reader = CcmsOrgNoteSet.ExecuteReader(where);
CcmsOrgNoteSet _ccmsorgnoteset = null;
if (reader.Read())
_ccmsorgnoteset = reader.CurrentCcmsOrgNoteSet;
reader.Close();
return _ccmsorgnoteset;
}

public static CcmsOrgNoteSet LoadCcmsOrgNoteSet(string where, IDbConnection conn)
{
CcmsOrgNoteSetReader reader = CcmsOrgNoteSet.ExecuteReader(where, conn);
CcmsOrgNoteSet _ccmsorgnoteset = null;
if (reader.Read())
_ccmsorgnoteset = reader.CurrentCcmsOrgNoteSet;
reader.Close(false);
return _ccmsorgnoteset;
}

public static CcmsOrgNoteSet LoadCcmsOrgNoteSetByPk( int id )
{
return LoadCcmsOrgNoteSet( " id="+id );
}

public static CcmsOrgNoteSet LoadCcmsOrgNoteSetByPk( int id , IDbConnection conn)
{
return LoadCcmsOrgNoteSet(" id="+id , conn);
}

public void Save()
{
if (idChanged || organization_idChanged || nameChanged || is_defaultChanged )
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
if (idChanged || organization_idChanged || nameChanged || is_defaultChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_org_note_set( id,organization_id,name,is_default ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(organization_idDbString+",");
qry.Append(nameDbString+",");
qry.Append(is_defaultDbString);
qry.Append(");");

}
else
{
if (!(idChanged || organization_idChanged || nameChanged || is_defaultChanged ))
return;
qry.Append("UPDATE Ccms_org_note_set set "); if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( is_defaultChanged )
{
qry.Append("is_default ="+is_defaultDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("id = "+idDbString);
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
cmd.CommandText = "DELETE Ccms_org_note_set where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsOrgNoteSets(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_org_note_set where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
organization_id= 2,
name= 4,
is_default= 8
}
#endregion
public void BulkSave(List<CcmsOrgNoteSet> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_org_note_set";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsOrgNoteSet.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsOrgNoteSet> transList,ref DataTable dt)
{
foreach (CcmsOrgNoteSet tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["organization_id"] = tran.OrganizationId;
Row["name"] = tran.Name;
Row["is_default"] = tran.IsDefault;
dt.Rows.Add(Row);
} }
}
}
