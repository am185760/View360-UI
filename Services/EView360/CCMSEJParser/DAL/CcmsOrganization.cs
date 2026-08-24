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
public class CcmsOrganization
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsOrganization() { }
public CcmsOrganization( int id ) 
{
}
public CcmsOrganization( string name,string mcn,string location,string country,bool? is_deleted,int? created_by,DateTime? created_on,int? modified_by,DateTime? modified_on,int? region_id,string code,byte[] logo )
{
this.name = name;
this.nameChanged = true;
this.mcn = mcn;
this.mcnChanged = true;
this.location = location;
this.locationChanged = true;
this.country = country;
this.countryChanged = true;
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
this.region_id = region_id;
this.region_idChanged = true;
this.code = code;
this.codeChanged = true;
this.logo = logo;
this.logoChanged = true;
}
private CcmsOrganization( int id,string name,string mcn,string location,string country,bool? is_deleted,int? created_by,DateTime? created_on,int? modified_by,DateTime? modified_on,int? region_id,string code,byte[] logo )
{
this.id = id;
this.idChanged = true;
this.name = name;
this.nameChanged = true;
this.mcn = mcn;
this.mcnChanged = true;
this.location = location;
this.locationChanged = true;
this.country = country;
this.countryChanged = true;
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
this.region_id = region_id;
this.region_idChanged = true;
this.code = code;
this.codeChanged = true;
this.logo = logo;
this.logoChanged = true;
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
#region Mcn
private bool mcnChanged = false;
private string mcn;
public string Mcn
{
get { return mcn; }
set { 
mcn = value;
mcnChanged = true;
}
}
private string mcnDbString
{
get
{
if (this.mcn!=null)
return string.Format("'{0}'",mcn); else
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
#region Country
private bool countryChanged = false;
private string country;
public string Country
{
get { return country; }
set { 
country = value;
countryChanged = true;
}
}
private string countryDbString
{
get
{
if (this.country!=null)
return string.Format("'{0}'",country); else
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
#region CreatedOn
private bool created_onChanged = false;
private DateTime? created_on;
public DateTime? CreatedOn
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
if (this.created_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",created_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region RegionId
private bool region_idChanged = false;
private int? region_id;
public int? RegionId
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
if (this.region_id.HasValue)
return region_id.ToString();
else
return "null";
}
}
#endregion
#region Code
private bool codeChanged = false;
private string code;
public string Code
{
get { return code; }
set { 
code = value;
codeChanged = true;
}
}
private string codeDbString
{
get
{
if (this.code!=null)
return string.Format("'{0}'",code); else
return "null";
}
}
#endregion
#region Logo
private bool logoChanged = false;
private byte[] logo;
public byte[] Logo
{
get { return logo; }
set { 
logo = value;
logoChanged = true;
}
}
private string logoDbString
{
get
{
if (this.logo!=null)
return "@logo";
else
return "null";
}
}
#endregion
#endregion

#region CcmsOrganizationReader
public class CcmsOrganizationReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsOrganization currentCcmsOrganization;
Columns columns;
bool partialRead = false;
private CcmsOrganizationReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsOrganizationReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsOrganizationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsOrganization; }

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
currentCcmsOrganization = new CcmsOrganization();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsOrganization.id =(int) reader["id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCcmsOrganization.name =(string) reader["name"]; 
if ((columns & Columns.mcn) == Columns.mcn && reader["mcn"]!=DBNull.Value)
currentCcmsOrganization.mcn =(string) reader["mcn"]; 
if ((columns & Columns.location) == Columns.location && reader["location"]!=DBNull.Value)
currentCcmsOrganization.location =(string) reader["location"]; 
if ((columns & Columns.country) == Columns.country && reader["country"]!=DBNull.Value)
currentCcmsOrganization.country =(string) reader["country"]; 
if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
currentCcmsOrganization.is_deleted =(bool?) reader["is_deleted"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsOrganization.created_by =(int?) reader["created_by"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsOrganization.created_on =(DateTime?) reader["created_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsOrganization.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsOrganization.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentCcmsOrganization.region_id =(int?) reader["region_id"]; 
if ((columns & Columns.code) == Columns.code && reader["code"]!=DBNull.Value)
currentCcmsOrganization.code =(string) reader["code"]; 
if ((columns & Columns.logo) == Columns.logo && reader["logo"]!=DBNull.Value)
currentCcmsOrganization.logo =(byte[]) reader["logo"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsOrganization.id = (int) reader["id"]; 
if (reader["name"] != DBNull.Value)
currentCcmsOrganization.name = (string) reader["name"]; 
if (reader["mcn"] != DBNull.Value)
currentCcmsOrganization.mcn = (string) reader["mcn"]; 
if (reader["location"] != DBNull.Value)
currentCcmsOrganization.location = (string) reader["location"]; 
if (reader["country"] != DBNull.Value)
currentCcmsOrganization.country = (string) reader["country"]; 
if (reader["is_deleted"] != DBNull.Value)
currentCcmsOrganization.is_deleted = (bool?) reader["is_deleted"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsOrganization.created_by = (int?) reader["created_by"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsOrganization.created_on = (DateTime?) reader["created_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsOrganization.modified_by = (int?) reader["modified_by"]; 
if (reader["modified_on"] != DBNull.Value)
currentCcmsOrganization.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["region_id"] != DBNull.Value)
currentCcmsOrganization.region_id = (int?) reader["region_id"]; 
if (reader["code"] != DBNull.Value)
currentCcmsOrganization.code = (string) reader["code"]; 
if (reader["logo"] != DBNull.Value)
currentCcmsOrganization.logo = (byte[]) reader["logo"]; 
} 

currentCcmsOrganization.isNewEntity = false;
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

public CcmsOrganization CurrentCcmsOrganization
{
get{ return currentCcmsOrganization; }
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


#region CcmsOrganization functions

public static CcmsOrganizationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.mcn == (Columns.mcn & columns))
qry.Append("mcn,");
if (Columns.location == (Columns.location & columns))
qry.Append("location,");
if (Columns.country == (Columns.country & columns))
qry.Append("country,");
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
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
if (Columns.code == (Columns.code & columns))
qry.Append("code,");
if (Columns.logo == (Columns.logo & columns))
qry.Append("logo,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_organization ");

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
return new CcmsOrganizationReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsOrganizationReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsOrganizationReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,name,mcn,location,country,is_deleted,created_by,created_on,modified_by,modified_on,region_id,code,logo from Ccms_organization ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsOrganizationReader(cmd.ExecuteReader(), conn);
}

static public CcmsOrganizationReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsOrganization LoadCcmsOrganization(string where)
{
CcmsOrganizationReader reader = CcmsOrganization.ExecuteReader(where);
CcmsOrganization _ccmsorganization = null;
if (reader.Read())
_ccmsorganization = reader.CurrentCcmsOrganization;
reader.Close();
return _ccmsorganization;
}

public static CcmsOrganization LoadCcmsOrganization(string where, IDbConnection conn)
{
CcmsOrganizationReader reader = CcmsOrganization.ExecuteReader(where, conn);
CcmsOrganization _ccmsorganization = null;
if (reader.Read())
_ccmsorganization = reader.CurrentCcmsOrganization;
reader.Close(false);
return _ccmsorganization;
}

public static CcmsOrganization LoadCcmsOrganizationByPk( int id )
{
return LoadCcmsOrganization( " id="+id );
}

public static CcmsOrganization LoadCcmsOrganizationByPk( int id , IDbConnection conn)
{
return LoadCcmsOrganization(" id="+id , conn);
}

public void Save()
{
if (idChanged || nameChanged || mcnChanged || locationChanged || countryChanged || is_deletedChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || region_idChanged || codeChanged || logoChanged )
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
if (idChanged || nameChanged || mcnChanged || locationChanged || countryChanged || is_deletedChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || region_idChanged || codeChanged || logoChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_organization( id,name,mcn,location,country,is_deleted,created_by,created_on,modified_by,modified_on,region_id,code,logo ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(nameDbString+",");
qry.Append(mcnDbString+",");
qry.Append(locationDbString+",");
qry.Append(countryDbString+",");
qry.Append(is_deletedDbString+",");
qry.Append(created_byDbString+",");
qry.Append(created_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(region_idDbString+",");
qry.Append(codeDbString+",");
qry.Append(logoDbString);
qry.Append(");");

}
else
{
if (!(idChanged || nameChanged || mcnChanged || locationChanged || countryChanged || is_deletedChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || region_idChanged || codeChanged || logoChanged ))
return;
qry.Append("UPDATE Ccms_organization set "); if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( mcnChanged )
{
qry.Append("mcn ="+mcnDbString);
qry.Append(",");
}

if ( locationChanged )
{
qry.Append("location ="+locationDbString);
qry.Append(",");
}

if ( countryChanged )
{
qry.Append("country ="+countryDbString);
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

if ( region_idChanged )
{
qry.Append("region_id ="+region_idDbString);
qry.Append(",");
}

if ( codeChanged )
{
qry.Append("code ="+codeDbString);
qry.Append(",");
}

if ( logoChanged )
{
qry.Append("logo ="+logoDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("id = "+idDbString);
}
if ( logoChanged )
{
IDbDataParameter dbParam_logo = cmd.CreateParameter();
cmd.Parameters.Add(dbParam_logo);
dbParam_logo.ParameterName = "@logo";
dbParam_logo.Value = this.logo;
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
cmd.CommandText = "DELETE Ccms_organization where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsOrganizations(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_organization where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
name= 2,
mcn= 4,
location= 8,
country= 16,
is_deleted= 32,
created_by= 64,
created_on= 128,
modified_by= 256,
modified_on= 512,
region_id= 1024,
code= 2048,
logo= 4096
}
#endregion
public void BulkSave(List<CcmsOrganization> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_organization";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsOrganization.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsOrganization> transList,ref DataTable dt)
{
foreach (CcmsOrganization tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["name"] = tran.Name;
Row["mcn"] = tran.Mcn;
Row["location"] = tran.Location;
Row["country"] = tran.Country;
Row["is_deleted"] = tran.IsDeleted;
Row["created_by"] = tran.CreatedBy;
Row["created_on"] = tran.CreatedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["region_id"] = tran.RegionId;
Row["code"] = tran.Code;
Row["logo"] = tran.Logo;
dt.Rows.Add(Row);
} }
}
}
