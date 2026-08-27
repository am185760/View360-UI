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
public class CcmsOrganizationUser
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsOrganizationUser() { }
public CcmsOrganizationUser( int id ) 
{
}
public CcmsOrganizationUser( long? organization_id,int? user_id )
{
this.organization_id = organization_id;
this.organization_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
}
private CcmsOrganizationUser( int id,long? organization_id,int? user_id )
{
this.id = id;
this.idChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
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
private long? organization_id;
public long? OrganizationId
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
#region UserId
private bool user_idChanged = false;
private int? user_id;
public int? UserId
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
if (this.user_id.HasValue)
return user_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsOrganizationUserReader
public class CcmsOrganizationUserReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsOrganizationUser currentCcmsOrganizationUser;
Columns columns;
bool partialRead = false;
private CcmsOrganizationUserReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsOrganizationUserReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsOrganizationUserReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsOrganizationUser; }

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
currentCcmsOrganizationUser = new CcmsOrganizationUser();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsOrganizationUser.id =(int) reader["id"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsOrganizationUser.organization_id =(long?) reader["organization_id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentCcmsOrganizationUser.user_id =(int?) reader["user_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsOrganizationUser.id = (int) reader["id"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsOrganizationUser.organization_id = (long?) reader["organization_id"]; 
if (reader["user_id"] != DBNull.Value)
currentCcmsOrganizationUser.user_id = (int?) reader["user_id"]; 
} 

currentCcmsOrganizationUser.isNewEntity = false;
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

public CcmsOrganizationUser CurrentCcmsOrganizationUser
{
get{ return currentCcmsOrganizationUser; }
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


#region CcmsOrganizationUser functions

public static CcmsOrganizationUserReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_organization_user ");

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
return new CcmsOrganizationUserReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsOrganizationUserReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsOrganizationUserReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,organization_id,user_id from Ccms_organization_user ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsOrganizationUserReader(cmd.ExecuteReader(), conn);
}

static public CcmsOrganizationUserReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsOrganizationUser LoadCcmsOrganizationUser(string where)
{
CcmsOrganizationUserReader reader = CcmsOrganizationUser.ExecuteReader(where);
CcmsOrganizationUser _ccmsorganizationuser = null;
if (reader.Read())
_ccmsorganizationuser = reader.CurrentCcmsOrganizationUser;
reader.Close();
return _ccmsorganizationuser;
}

public static CcmsOrganizationUser LoadCcmsOrganizationUser(string where, IDbConnection conn)
{
CcmsOrganizationUserReader reader = CcmsOrganizationUser.ExecuteReader(where, conn);
CcmsOrganizationUser _ccmsorganizationuser = null;
if (reader.Read())
_ccmsorganizationuser = reader.CurrentCcmsOrganizationUser;
reader.Close(false);
return _ccmsorganizationuser;
}

public static CcmsOrganizationUser LoadCcmsOrganizationUserByPk( int id )
{
return LoadCcmsOrganizationUser( " id="+id );
}

public static CcmsOrganizationUser LoadCcmsOrganizationUserByPk( int id , IDbConnection conn)
{
return LoadCcmsOrganizationUser(" id="+id , conn);
}

public void Save()
{
if (idChanged || organization_idChanged || user_idChanged )
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
if (idChanged || organization_idChanged || user_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_organization_user( organization_id,user_id ) values(");
qry.Append(organization_idDbString+",");
qry.Append(user_idDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || organization_idChanged || user_idChanged ))
return;
qry.Append("UPDATE Ccms_organization_user set "); if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
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
    object res = cmd.ExecuteScalar();
    if (res == DBNull.Value)
        id = 1;
    else
        id = int.Parse(res.ToString());
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
cmd.CommandText = "DELETE Ccms_organization_user where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsOrganizationUsers(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_organization_user where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
organization_id= 2,
user_id= 4
}
#endregion
public void BulkSave(List<CcmsOrganizationUser> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_organization_user";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsOrganizationUser.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsOrganizationUser> transList,ref DataTable dt)
{
foreach (CcmsOrganizationUser tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["organization_id"] = tran.OrganizationId;
Row["user_id"] = tran.UserId;
dt.Rows.Add(Row);
} }
}
}
