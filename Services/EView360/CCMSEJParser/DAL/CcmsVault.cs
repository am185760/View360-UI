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
public class CcmsVault
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsVault() { }
public CcmsVault( int id,int region_id,int cit_id,string title,int created_by,DateTime created_on,int organization_id,bool is_branch,int note_set_type_id ) 
{
this.region_id = region_id;
this.region_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.title = title;
this.titleChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.is_branch = is_branch;
this.is_branchChanged = true;
this.note_set_type_id = note_set_type_id;
this.note_set_type_idChanged = true;
}
public CcmsVault( int region_id,int cit_id,string title,string description,bool? is_deleted,int created_by,DateTime created_on,int? modified_by,DateTime? modified_on,int organization_id,bool is_branch,int note_set_type_id )
{
this.region_id = region_id;
this.region_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.title = title;
this.titleChanged = true;
this.description = description;
this.descriptionChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.is_branch = is_branch;
this.is_branchChanged = true;
this.note_set_type_id = note_set_type_id;
this.note_set_type_idChanged = true;
}
private CcmsVault( int id,int region_id,int cit_id,string title,string description,bool? is_deleted,int created_by,DateTime created_on,int? modified_by,DateTime? modified_on,int organization_id,bool is_branch,int note_set_type_id )
{
this.id = id;
this.idChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.title = title;
this.titleChanged = true;
this.description = description;
this.descriptionChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.is_branch = is_branch;
this.is_branchChanged = true;
this.note_set_type_id = note_set_type_id;
this.note_set_type_idChanged = true;
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
#region RegionId
private bool region_idChanged = false;
private int region_id;
public int RegionId
{
get { return region_id; }
set { 
region_id = value;
region_idChanged = true;
}
}
private string region_idDbString
{
get
{
return region_id.ToString();
}
}
#endregion
#region CitId
private bool cit_idChanged = false;
private int cit_id;
public int CitId
{
get { return cit_id; }
set { 
cit_id = value;
cit_idChanged = true;
}
}
private string cit_idDbString
{
get
{
return cit_id.ToString();
}
}
#endregion
#region Title
private bool titleChanged = false;
private string title;
public string Title
{
get { return title; }
set { 
title = value;
titleChanged = true;
}
}
private string titleDbString
{
get
{
if (this.title!=null)
return string.Format("'{0}'",title); else
return "null";
}
}
#endregion
#region Description
private bool descriptionChanged = false;
private string description;
public string Description
{
get { return description; }
set { 
description = value;
descriptionChanged = true;
}
}
private string descriptionDbString
{
get
{
if (this.description!=null)
return string.Format("'{0}'",description); else
return "null";
}
}
#endregion
#region IsDeleted
private bool is_deletedChanged = false;
private bool? is_deleted;
public bool? IsDeleted
{
get { return is_deleted; }
set { 
is_deleted = value;
is_deletedChanged = true;
}
}
private string is_deletedDbString
{
get
{
if (this.is_deleted.HasValue)
return is_deleted.Value?"1":"0";
else
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
#region CreatedOn
private bool created_onChanged = false;
private DateTime created_on;
public DateTime CreatedOn
{
get { return created_on; }
set { 
created_on = value;
created_onChanged = true;
}
}
private string created_onDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",created_on.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region ModifiedOn
private bool modified_onChanged = false;
private DateTime? modified_on;
public DateTime? ModifiedOn
{
get { return modified_on; }
set { 
modified_on = value;
modified_onChanged = true;
}
}
private string modified_onDbString
{
get
{
if (this.modified_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region OrganizationId
private bool organization_idChanged = false;
private int organization_id;
public int OrganizationId
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
return organization_id.ToString();
}
}
#endregion
#region IsBranch
private bool is_branchChanged = false;
private bool is_branch;
public bool IsBranch
{
get { return is_branch; }
set { 
is_branch = value;
is_branchChanged = true;
}
}
private string is_branchDbString
{
get
{
return is_branch?"1":"0";
}
}
#endregion
#region NoteSetTypeId
private bool note_set_type_idChanged = false;
private int note_set_type_id;
public int NoteSetTypeId
{
get { return note_set_type_id; }
set { 
note_set_type_id = value;
note_set_type_idChanged = true;
}
}
private string note_set_type_idDbString
{
get
{
return note_set_type_id.ToString();
}
}
#endregion
#endregion

#region CcmsVaultReader
public class CcmsVaultReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsVault currentCcmsVault;
Columns columns;
bool partialRead = false;
private CcmsVaultReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsVaultReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsVaultReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsVault; }

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
currentCcmsVault = new CcmsVault();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsVault.id =(int) reader["id"]; 
if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentCcmsVault.region_id =(int) reader["region_id"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentCcmsVault.cit_id =(int) reader["cit_id"]; 
if ((columns & Columns.title) == Columns.title && reader["title"]!=DBNull.Value)
currentCcmsVault.title =(string) reader["title"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsVault.description =(string) reader["description"]; 
if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
currentCcmsVault.is_deleted =(bool?) reader["is_deleted"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsVault.created_by =(int) reader["created_by"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsVault.created_on =(DateTime) reader["created_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsVault.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsVault.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsVault.organization_id =(int) reader["organization_id"]; 
if ((columns & Columns.is_branch) == Columns.is_branch && reader["is_branch"]!=DBNull.Value)
currentCcmsVault.is_branch =(bool) reader["is_branch"]; 
if ((columns & Columns.note_set_type_id) == Columns.note_set_type_id && reader["note_set_type_id"]!=DBNull.Value)
currentCcmsVault.note_set_type_id =(int) reader["note_set_type_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsVault.id = (int) reader["id"]; 
if (reader["region_id"] != DBNull.Value)
currentCcmsVault.region_id = (int) reader["region_id"]; 
if (reader["cit_id"] != DBNull.Value)
currentCcmsVault.cit_id = (int) reader["cit_id"]; 
if (reader["title"] != DBNull.Value)
currentCcmsVault.title = (string) reader["title"]; 
if (reader["description"] != DBNull.Value)
currentCcmsVault.description = (string) reader["description"]; 
if (reader["is_deleted"] != DBNull.Value)
currentCcmsVault.is_deleted = (bool?) reader["is_deleted"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsVault.created_by = (int) reader["created_by"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsVault.created_on = (DateTime) reader["created_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsVault.modified_by = (int?) reader["modified_by"]; 
if (reader["modified_on"] != DBNull.Value)
currentCcmsVault.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsVault.organization_id = (int) reader["organization_id"]; 
if (reader["is_branch"] != DBNull.Value)
currentCcmsVault.is_branch = (bool) reader["is_branch"]; 
if (reader["note_set_type_id"] != DBNull.Value)
currentCcmsVault.note_set_type_id = (int) reader["note_set_type_id"]; 
} 

currentCcmsVault.isNewEntity = false;
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

public CcmsVault CurrentCcmsVault
{
get{ return currentCcmsVault; }
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


#region CcmsVault functions

public static CcmsVaultReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
if (Columns.title == (Columns.title & columns))
qry.Append("title,");
if (Columns.description == (Columns.description & columns))
qry.Append("description,");
if (Columns.is_deleted == (Columns.is_deleted & columns))
qry.Append("is_deleted,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.created_on == (Columns.created_on & columns))
qry.Append("created_on,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.modified_on == (Columns.modified_on & columns))
qry.Append("modified_on,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.is_branch == (Columns.is_branch & columns))
qry.Append("is_branch,");
if (Columns.note_set_type_id == (Columns.note_set_type_id & columns))
qry.Append("note_set_type_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_vault ");

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
return new CcmsVaultReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsVaultReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsVaultReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,region_id,cit_id,title,description,is_deleted,created_by,created_on,modified_by,modified_on,organization_id,is_branch,note_set_type_id from Ccms_vault ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsVaultReader(cmd.ExecuteReader(), conn);
}

static public CcmsVaultReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsVault LoadCcmsVault(string where)
{
CcmsVaultReader reader = CcmsVault.ExecuteReader(where);
CcmsVault _ccmsvault = null;
if (reader.Read())
_ccmsvault = reader.CurrentCcmsVault;
reader.Close();
return _ccmsvault;
}

public static CcmsVault LoadCcmsVault(string where, IDbConnection conn)
{
CcmsVaultReader reader = CcmsVault.ExecuteReader(where, conn);
CcmsVault _ccmsvault = null;
if (reader.Read())
_ccmsvault = reader.CurrentCcmsVault;
reader.Close(false);
return _ccmsvault;
}

public static CcmsVault LoadCcmsVaultByPk( int id )
{
return LoadCcmsVault( " id="+id );
}

public static CcmsVault LoadCcmsVaultByPk( int id , IDbConnection conn)
{
return LoadCcmsVault(" id="+id , conn);
}

public void Save()
{
if (idChanged || region_idChanged || cit_idChanged || titleChanged || descriptionChanged || is_deletedChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged || is_branchChanged || note_set_type_idChanged )
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
if (idChanged || region_idChanged || cit_idChanged || titleChanged || descriptionChanged || is_deletedChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged || is_branchChanged || note_set_type_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_vault( id,region_id,cit_id,title,description,is_deleted,created_by,created_on,modified_by,modified_on,organization_id,is_branch,note_set_type_id ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(region_idDbString+",");
qry.Append(cit_idDbString+",");
qry.Append(titleDbString+",");
qry.Append(descriptionDbString+",");
qry.Append(is_deletedDbString+",");
qry.Append(created_byDbString+",");
qry.Append(created_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(organization_idDbString+",");
qry.Append(is_branchDbString+",");
qry.Append(note_set_type_idDbString);
qry.Append(");");

}
else
{
if (!(idChanged || region_idChanged || cit_idChanged || titleChanged || descriptionChanged || is_deletedChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged || is_branchChanged || note_set_type_idChanged ))
return;
qry.Append("UPDATE Ccms_vault set "); if ( region_idChanged )
{
qry.Append("region_id ="+region_idDbString);
qry.Append(",");
}

if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
qry.Append(",");
}

if ( titleChanged )
{
qry.Append("title ="+titleDbString);
qry.Append(",");
}

if ( descriptionChanged )
{
qry.Append("description ="+descriptionDbString);
qry.Append(",");
}

if ( is_deletedChanged )
{
qry.Append("is_deleted ="+is_deletedDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( created_onChanged )
{
qry.Append("created_on ="+created_onDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( modified_onChanged )
{
qry.Append("modified_on ="+modified_onDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( is_branchChanged )
{
qry.Append("is_branch ="+is_branchDbString);
qry.Append(",");
}

if ( note_set_type_idChanged )
{
qry.Append("note_set_type_id ="+note_set_type_idDbString);
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
cmd.CommandText = "DELETE Ccms_vault where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsVaults(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_vault where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
region_id= 2,
cit_id= 4,
title= 8,
description= 16,
is_deleted= 32,
created_by= 64,
created_on= 128,
modified_by= 256,
modified_on= 512,
organization_id= 1024,
is_branch= 2048,
note_set_type_id= 4096
}
#endregion
public void BulkSave(List<CcmsVault> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_vault";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsVault.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsVault> transList,ref DataTable dt)
{
foreach (CcmsVault tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["region_id"] = tran.RegionId;
Row["cit_id"] = tran.CitId;
Row["title"] = tran.Title;
Row["description"] = tran.Description;
Row["is_deleted"] = tran.IsDeleted;
Row["created_by"] = tran.CreatedBy;
Row["created_on"] = tran.CreatedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["organization_id"] = tran.OrganizationId;
Row["is_branch"] = tran.IsBranch;
Row["note_set_type_id"] = tran.NoteSetTypeId;
dt.Rows.Add(Row);
} }
}
}
