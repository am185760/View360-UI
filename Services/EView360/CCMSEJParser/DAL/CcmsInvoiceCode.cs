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
public class CcmsInvoiceCode
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsInvoiceCode() { }
public CcmsInvoiceCode( int id,string prefix,string postfix,int current_counter,int organization_id,int cit_id ) 
{
this.prefix = prefix;
this.prefixChanged = true;
this.postfix = postfix;
this.postfixChanged = true;
this.current_counter = current_counter;
this.current_counterChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
}
public CcmsInvoiceCode( string prefix,string postfix,int current_counter,int organization_id,int cit_id,string description )
{
this.prefix = prefix;
this.prefixChanged = true;
this.postfix = postfix;
this.postfixChanged = true;
this.current_counter = current_counter;
this.current_counterChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.description = description;
this.descriptionChanged = true;
}
private CcmsInvoiceCode( int id,string prefix,string postfix,int current_counter,int organization_id,int cit_id,string description )
{
this.id = id;
this.idChanged = true;
this.prefix = prefix;
this.prefixChanged = true;
this.postfix = postfix;
this.postfixChanged = true;
this.current_counter = current_counter;
this.current_counterChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.description = description;
this.descriptionChanged = true;
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
#region Prefix
private bool prefixChanged = false;
private string prefix;
public string Prefix
{
get { return prefix; }
set { 
prefix = value;
prefixChanged = true;
}
}
private string prefixDbString
{
get
{
if (this.prefix!=null)
return string.Format("'{0}'",prefix); else
return "null";
}
}
#endregion
#region Postfix
private bool postfixChanged = false;
private string postfix;
public string Postfix
{
get { return postfix; }
set { 
postfix = value;
postfixChanged = true;
}
}
private string postfixDbString
{
get
{
if (this.postfix!=null)
return string.Format("'{0}'",postfix); else
return "null";
}
}
#endregion
#region CurrentCounter
private bool current_counterChanged = false;
private int current_counter;
public int CurrentCounter
{
get { return current_counter; }
set { 
current_counter = value;
current_counterChanged = true;
}
}
private string current_counterDbString
{
get
{
return current_counter.ToString();
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
#endregion

#region CcmsInvoiceCodeReader
public class CcmsInvoiceCodeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsInvoiceCode currentCcmsInvoiceCode;
Columns columns;
bool partialRead = false;
private CcmsInvoiceCodeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsInvoiceCodeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsInvoiceCodeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsInvoiceCode; }

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
currentCcmsInvoiceCode = new CcmsInvoiceCode();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsInvoiceCode.id =(int) reader["id"]; 
if ((columns & Columns.prefix) == Columns.prefix && reader["prefix"]!=DBNull.Value)
currentCcmsInvoiceCode.prefix =(string) reader["prefix"]; 
if ((columns & Columns.postfix) == Columns.postfix && reader["postfix"]!=DBNull.Value)
currentCcmsInvoiceCode.postfix =(string) reader["postfix"]; 
if ((columns & Columns.current_counter) == Columns.current_counter && reader["current_counter"]!=DBNull.Value)
currentCcmsInvoiceCode.current_counter =(int) reader["current_counter"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsInvoiceCode.organization_id =(int) reader["organization_id"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentCcmsInvoiceCode.cit_id =(int) reader["cit_id"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsInvoiceCode.description =(string) reader["description"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsInvoiceCode.id = (int) reader["id"]; 
if (reader["prefix"] != DBNull.Value)
currentCcmsInvoiceCode.prefix = (string) reader["prefix"]; 
if (reader["postfix"] != DBNull.Value)
currentCcmsInvoiceCode.postfix = (string) reader["postfix"]; 
if (reader["current_counter"] != DBNull.Value)
currentCcmsInvoiceCode.current_counter = (int) reader["current_counter"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsInvoiceCode.organization_id = (int) reader["organization_id"]; 
if (reader["cit_id"] != DBNull.Value)
currentCcmsInvoiceCode.cit_id = (int) reader["cit_id"]; 
if (reader["description"] != DBNull.Value)
currentCcmsInvoiceCode.description = (string) reader["description"]; 
} 

currentCcmsInvoiceCode.isNewEntity = false;
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

public CcmsInvoiceCode CurrentCcmsInvoiceCode
{
get{ return currentCcmsInvoiceCode; }
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


#region CcmsInvoiceCode functions

public static CcmsInvoiceCodeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.prefix == (Columns.prefix & columns))
qry.Append("prefix,");
if (Columns.postfix == (Columns.postfix & columns))
qry.Append("postfix,");
if (Columns.current_counter == (Columns.current_counter & columns))
qry.Append("current_counter,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
if (Columns.description == (Columns.description & columns))
qry.Append("description,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_invoice_code ");

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
return new CcmsInvoiceCodeReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsInvoiceCodeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsInvoiceCodeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,prefix,postfix,current_counter,organization_id,cit_id,description from Ccms_invoice_code ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsInvoiceCodeReader(cmd.ExecuteReader(), conn);
}

static public CcmsInvoiceCodeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsInvoiceCode LoadCcmsInvoiceCode(string where)
{
CcmsInvoiceCodeReader reader = CcmsInvoiceCode.ExecuteReader(where);
CcmsInvoiceCode _ccmsinvoicecode = null;
if (reader.Read())
_ccmsinvoicecode = reader.CurrentCcmsInvoiceCode;
reader.Close();
return _ccmsinvoicecode;
}

public static CcmsInvoiceCode LoadCcmsInvoiceCode(string where, IDbConnection conn)
{
CcmsInvoiceCodeReader reader = CcmsInvoiceCode.ExecuteReader(where, conn);
CcmsInvoiceCode _ccmsinvoicecode = null;
if (reader.Read())
_ccmsinvoicecode = reader.CurrentCcmsInvoiceCode;
reader.Close(false);
return _ccmsinvoicecode;
}

public static CcmsInvoiceCode LoadCcmsInvoiceCodeByPk( int id )
{
return LoadCcmsInvoiceCode( " id="+id );
}

public static CcmsInvoiceCode LoadCcmsInvoiceCodeByPk( int id , IDbConnection conn)
{
return LoadCcmsInvoiceCode(" id="+id , conn);
}

public void Save()
{
if (idChanged || prefixChanged || postfixChanged || current_counterChanged || organization_idChanged || cit_idChanged || descriptionChanged )
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
if (idChanged || prefixChanged || postfixChanged || current_counterChanged || organization_idChanged || cit_idChanged || descriptionChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_invoice_code( id,prefix,postfix,current_counter,organization_id,cit_id,description ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(prefixDbString+",");
qry.Append(postfixDbString+",");
qry.Append(current_counterDbString+",");
qry.Append(organization_idDbString+",");
qry.Append(cit_idDbString+",");
qry.Append(descriptionDbString);
qry.Append(");");

}
else
{
if (!(idChanged || prefixChanged || postfixChanged || current_counterChanged || organization_idChanged || cit_idChanged || descriptionChanged ))
return;
qry.Append("UPDATE Ccms_invoice_code set "); if ( prefixChanged )
{
qry.Append("prefix ="+prefixDbString);
qry.Append(",");
}

if ( postfixChanged )
{
qry.Append("postfix ="+postfixDbString);
qry.Append(",");
}

if ( current_counterChanged )
{
qry.Append("current_counter ="+current_counterDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
qry.Append(",");
}

if ( descriptionChanged )
{
qry.Append("description ="+descriptionDbString);
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
cmd.CommandText = "DELETE Ccms_invoice_code where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsInvoiceCodes(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_invoice_code where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
prefix= 2,
postfix= 4,
current_counter= 8,
organization_id= 16,
cit_id= 32,
description= 64
}
#endregion
public void BulkSave(List<CcmsInvoiceCode> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_invoice_code";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsInvoiceCode.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsInvoiceCode> transList,ref DataTable dt)
{
foreach (CcmsInvoiceCode tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["prefix"] = tran.Prefix;
Row["postfix"] = tran.Postfix;
Row["current_counter"] = tran.CurrentCounter;
Row["organization_id"] = tran.OrganizationId;
Row["cit_id"] = tran.CitId;
Row["description"] = tran.Description;
dt.Rows.Add(Row);
} }
}
}
