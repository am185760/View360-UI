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
public class CcmsUserCit
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsUserCit() { }
public CcmsUserCit(long id) 
{
}
public CcmsUserCit( long user_id,long cit_id )
{
this.user_id = user_id;
this.user_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
}
private CcmsUserCit( long id,long user_id,long cit_id )
{
this.id = id;
this.idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
}

#region members and properties for columns

#region Id
private bool idChanged = false;
private long id;
public long Id
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
private long user_id;
public long UserId
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
return user_id.ToString();
}
}
#endregion
#region CitId
private bool cit_idChanged = false;
private long cit_id;
public long CitId
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
#endregion

#region CcmsUserCitReader
public class CcmsUserCitReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsUserCit currentCcmsUserCit;
Columns columns;
bool partialRead = false;
private CcmsUserCitReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsUserCitReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsUserCitReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsUserCit; }

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
currentCcmsUserCit = new CcmsUserCit();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsUserCit.id =(long) reader["id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentCcmsUserCit.user_id =(long) reader["user_id"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentCcmsUserCit.cit_id =(long) reader["cit_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsUserCit.id = (int) reader["id"]; 
if (reader["user_id"] != DBNull.Value)
currentCcmsUserCit.user_id = (long) reader["user_id"]; 
if (reader["cit_id"] != DBNull.Value)
currentCcmsUserCit.cit_id = (long) reader["cit_id"]; 
} 

currentCcmsUserCit.isNewEntity = false;
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

public CcmsUserCit CurrentCcmsUserCit
{
get{ return currentCcmsUserCit; }
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


#region CcmsUserCit functions

public static CcmsUserCitReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_user_cit ");

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
return new CcmsUserCitReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsUserCitReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsUserCitReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,user_id,cit_id from Ccms_user_cit ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsUserCitReader(cmd.ExecuteReader(), conn);
}

static public CcmsUserCitReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsUserCit LoadCcmsUserCit(string where)
{
CcmsUserCitReader reader = CcmsUserCit.ExecuteReader(where);
CcmsUserCit _ccmsusercit = null;
if (reader.Read())
_ccmsusercit = reader.CurrentCcmsUserCit;
reader.Close();
return _ccmsusercit;
}

public static CcmsUserCit LoadCcmsUserCit(string where, IDbConnection conn)
{
CcmsUserCitReader reader = CcmsUserCit.ExecuteReader(where, conn);
CcmsUserCit _ccmsusercit = null;
if (reader.Read())
_ccmsusercit = reader.CurrentCcmsUserCit;
reader.Close(false);
return _ccmsusercit;
}

public static CcmsUserCit LoadCcmsUserCitByPk( int id )
{
return LoadCcmsUserCit( " id="+id );
}

public static CcmsUserCit LoadCcmsUserCitByPk( int id , IDbConnection conn)
{
return LoadCcmsUserCit(" id="+id , conn);
}

public void Save()
{
if (idChanged || user_idChanged || cit_idChanged )
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
if (idChanged || user_idChanged || cit_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_user_cit( user_id,cit_id ) values(");
qry.Append(user_idDbString+",");
qry.Append(cit_idDbString);
qry.Append(");SELECT scope_identity();");

}
else
{
if (!(idChanged || user_idChanged || cit_idChanged ))
return;
qry.Append("UPDATE Ccms_user_cit set "); if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
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
cmd.CommandText = "DELETE Ccms_user_cit where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsUserCits(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_user_cit where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
user_id= 2,
cit_id= 4
}
#endregion
public void BulkSave(List<CcmsUserCit> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_user_cit";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsUserCit.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsUserCit> transList,ref DataTable dt)
{
foreach (CcmsUserCit tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["user_id"] = tran.UserId;
Row["cit_id"] = tran.CitId;
dt.Rows.Add(Row);
} }
}
}
