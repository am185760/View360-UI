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
public class CcmsDenomination
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsDenomination() { }
public CcmsDenomination( int id,string name ) 
{
this.name = name;
this.nameChanged = true;
}
public CcmsDenomination( string name,string currency_code,int? organization_id,int? value )
{
this.name = name;
this.nameChanged = true;
this.currency_code = currency_code;
this.currency_codeChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.value = value;
this.valueChanged = true;
}
private CcmsDenomination( int id,string name,string currency_code,int? organization_id,int? value )
{
this.id = id;
this.idChanged = true;
this.name = name;
this.nameChanged = true;
this.currency_code = currency_code;
this.currency_codeChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.value = value;
this.valueChanged = true;
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
#region CurrencyCode
private bool currency_codeChanged = false;
private string currency_code;
public string CurrencyCode
{
get { return currency_code; }
set { 
currency_code = value;
currency_codeChanged = true;
}
}
private string currency_codeDbString
{
get
{
if (this.currency_code!=null)
return string.Format("'{0}'",currency_code); else
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
#region Value
private bool valueChanged = false;
private int? value;
public int? Value
{
get { return value; }
set { 
value = value;
valueChanged = true;
}
}
private string valueDbString
{
get
{
if (this.value.HasValue)
return value.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsDenominationReader
public class CcmsDenominationReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsDenomination currentCcmsDenomination;
Columns columns;
bool partialRead = false;
private CcmsDenominationReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsDenominationReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsDenominationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsDenomination; }

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
currentCcmsDenomination = new CcmsDenomination();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsDenomination.id =(int) reader["id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCcmsDenomination.name =(string) reader["name"]; 
if ((columns & Columns.currency_code) == Columns.currency_code && reader["currency_code"]!=DBNull.Value)
currentCcmsDenomination.currency_code =(string) reader["currency_code"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsDenomination.organization_id =(int?) reader["organization_id"]; 
if ((columns & Columns.value) == Columns.value && reader["value"]!=DBNull.Value)
currentCcmsDenomination.value =(int?) reader["value"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsDenomination.id = (int) reader["id"]; 
if (reader["name"] != DBNull.Value)
currentCcmsDenomination.name = (string) reader["name"]; 
if (reader["currency_code"] != DBNull.Value)
currentCcmsDenomination.currency_code = (string) reader["currency_code"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsDenomination.organization_id = (int?) reader["organization_id"]; 
if (reader["value"] != DBNull.Value)
currentCcmsDenomination.value = (int?) reader["value"]; 
} 

currentCcmsDenomination.isNewEntity = false;
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

public CcmsDenomination CurrentCcmsDenomination
{
get{ return currentCcmsDenomination; }
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


#region CcmsDenomination functions

public static CcmsDenominationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.currency_code == (Columns.currency_code & columns))
qry.Append("currency_code,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.value == (Columns.value & columns))
qry.Append("value,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_denomination ");

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
return new CcmsDenominationReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsDenominationReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsDenominationReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,name,currency_code,organization_id,value from Ccms_denomination ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsDenominationReader(cmd.ExecuteReader(), conn);
}

static public CcmsDenominationReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsDenomination LoadCcmsDenomination(string where)
{
CcmsDenominationReader reader = CcmsDenomination.ExecuteReader(where);
CcmsDenomination _ccmsdenomination = null;
if (reader.Read())
_ccmsdenomination = reader.CurrentCcmsDenomination;
reader.Close();
return _ccmsdenomination;
}

public static CcmsDenomination LoadCcmsDenomination(string where, IDbConnection conn)
{
CcmsDenominationReader reader = CcmsDenomination.ExecuteReader(where, conn);
CcmsDenomination _ccmsdenomination = null;
if (reader.Read())
_ccmsdenomination = reader.CurrentCcmsDenomination;
reader.Close(false);
return _ccmsdenomination;
}

public static CcmsDenomination LoadCcmsDenominationByPk( int id )
{
return LoadCcmsDenomination( " id="+id );
}

public static CcmsDenomination LoadCcmsDenominationByPk( int id , IDbConnection conn)
{
return LoadCcmsDenomination(" id="+id , conn);
}

public void Save()
{
if (idChanged || nameChanged || currency_codeChanged || organization_idChanged || valueChanged )
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
if (idChanged || nameChanged || currency_codeChanged || organization_idChanged || valueChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_denomination( id,name,currency_code,organization_id,value ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(nameDbString+",");
qry.Append(currency_codeDbString+",");
qry.Append(organization_idDbString+",");
qry.Append(valueDbString);
qry.Append(");");

}
else
{
if (!(idChanged || nameChanged || currency_codeChanged || organization_idChanged || valueChanged ))
return;
qry.Append("UPDATE Ccms_denomination set "); if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( currency_codeChanged )
{
qry.Append("currency_code ="+currency_codeDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( valueChanged )
{
qry.Append("value ="+valueDbString);
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
cmd.CommandText = "DELETE Ccms_denomination where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsDenominations(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_denomination where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
name= 2,
currency_code= 4,
organization_id= 8,
value= 16
}
#endregion
public void BulkSave(List<CcmsDenomination> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_denomination";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsDenomination.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsDenomination> transList,ref DataTable dt)
{
foreach (CcmsDenomination tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["name"] = tran.Name;
Row["currency_code"] = tran.CurrencyCode;
Row["organization_id"] = tran.OrganizationId;
Row["value"] = tran.Value;
dt.Rows.Add(Row);
} }
}
}
