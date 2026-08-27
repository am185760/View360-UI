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
public class CcmsUserNcr
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsUserNcr() { }
public CcmsUserNcr( int id ) 
{
}
public CcmsUserNcr( int? user_id,int? organization_id )
{
this.user_id = user_id;
this.user_idChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
}
private CcmsUserNcr( int id,int? user_id,int? organization_id )
{
this.id = id;
this.idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
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
#endregion

#region CcmsUserNcrReader
public class CcmsUserNcrReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsUserNcr currentCcmsUserNcr;
Columns columns;
bool partialRead = false;
private CcmsUserNcrReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsUserNcrReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsUserNcrReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsUserNcr; }

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
currentCcmsUserNcr = new CcmsUserNcr();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsUserNcr.id =(int) reader["id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentCcmsUserNcr.user_id =(int?) reader["user_id"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsUserNcr.organization_id =(int?) reader["organization_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsUserNcr.id = (int) reader["id"]; 
if (reader["user_id"] != DBNull.Value)
currentCcmsUserNcr.user_id = (int?) reader["user_id"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsUserNcr.organization_id = (int?) reader["organization_id"]; 
} 

currentCcmsUserNcr.isNewEntity = false;
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

public CcmsUserNcr CurrentCcmsUserNcr
{
get{ return currentCcmsUserNcr; }
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


#region CcmsUserNcr functions

public static CcmsUserNcrReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_user_ncr ");

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
return new CcmsUserNcrReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsUserNcrReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsUserNcrReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,user_id,organization_id from Ccms_user_ncr ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsUserNcrReader(cmd.ExecuteReader(), conn);
}

static public CcmsUserNcrReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsUserNcr LoadCcmsUserNcr(string where)
{
CcmsUserNcrReader reader = CcmsUserNcr.ExecuteReader(where);
CcmsUserNcr _ccmsuserncr = null;
if (reader.Read())
_ccmsuserncr = reader.CurrentCcmsUserNcr;
reader.Close();
return _ccmsuserncr;
}

public static CcmsUserNcr LoadCcmsUserNcr(string where, IDbConnection conn)
{
CcmsUserNcrReader reader = CcmsUserNcr.ExecuteReader(where, conn);
CcmsUserNcr _ccmsuserncr = null;
if (reader.Read())
_ccmsuserncr = reader.CurrentCcmsUserNcr;
reader.Close(false);
return _ccmsuserncr;
}

public static CcmsUserNcr LoadCcmsUserNcrByPk( int id )
{
return LoadCcmsUserNcr( " id="+id );
}

public static CcmsUserNcr LoadCcmsUserNcrByPk( int id , IDbConnection conn)
{
return LoadCcmsUserNcr(" id="+id , conn);
}

public void Save()
{
if (idChanged || user_idChanged || organization_idChanged )
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
if (idChanged || user_idChanged || organization_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_user_ncr(user_id,organization_id ) values(");
qry.Append(user_idDbString+",");
qry.Append(organization_idDbString);
qry.Append(");SELECT scope_identity();");

}
else
{
if (!(idChanged || user_idChanged || organization_idChanged ))
return;
qry.Append("UPDATE Ccms_user_ncr set "); if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
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
cmd.CommandText = "DELETE Ccms_user_ncr where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsUserNcrs(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_user_ncr where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
user_id= 2,
organization_id= 4
}
#endregion
public void BulkSave(List<CcmsUserNcr> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_user_ncr";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsUserNcr.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsUserNcr> transList,ref DataTable dt)
{
foreach (CcmsUserNcr tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["user_id"] = tran.UserId;
Row["organization_id"] = tran.OrganizationId;
dt.Rows.Add(Row);
} }
}
}
