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
public class CcmsInvoiceLineItem
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsInvoiceLineItem() { }
public CcmsInvoiceLineItem( int id,int invoice_id,string name ) 
{
this.invoice_id = invoice_id;
this.invoice_idChanged = true;
this.name = name;
this.nameChanged = true;
}
public CcmsInvoiceLineItem( int invoice_id,string name,string description,decimal? amount )
{
this.invoice_id = invoice_id;
this.invoice_idChanged = true;
this.name = name;
this.nameChanged = true;
this.description = description;
this.descriptionChanged = true;
this.amount = amount;
this.amountChanged = true;
}
private CcmsInvoiceLineItem( int id,int invoice_id,string name,string description,decimal? amount )
{
this.id = id;
this.idChanged = true;
this.invoice_id = invoice_id;
this.invoice_idChanged = true;
this.name = name;
this.nameChanged = true;
this.description = description;
this.descriptionChanged = true;
this.amount = amount;
this.amountChanged = true;
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
#region InvoiceId
private bool invoice_idChanged = false;
private int invoice_id;
public int InvoiceId
{
get { return invoice_id; }
set { 
invoice_id = value;
invoice_idChanged = true;
}
}
private string invoice_idDbString
{
get
{
return invoice_id.ToString();
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
#region Amount
private bool amountChanged = false;
private decimal? amount;
public decimal? Amount
{
get { return amount; }
set { 
amount = value;
amountChanged = true;
}
}
private string amountDbString
{
get
{
if (this.amount.HasValue)
return amount.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsInvoiceLineItemReader
public class CcmsInvoiceLineItemReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsInvoiceLineItem currentCcmsInvoiceLineItem;
Columns columns;
bool partialRead = false;
private CcmsInvoiceLineItemReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsInvoiceLineItemReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsInvoiceLineItemReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsInvoiceLineItem; }

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
currentCcmsInvoiceLineItem = new CcmsInvoiceLineItem();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsInvoiceLineItem.id =(int) reader["id"]; 
if ((columns & Columns.invoice_id) == Columns.invoice_id && reader["invoice_id"]!=DBNull.Value)
currentCcmsInvoiceLineItem.invoice_id =(int) reader["invoice_id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCcmsInvoiceLineItem.name =(string) reader["name"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsInvoiceLineItem.description =(string) reader["description"]; 
if ((columns & Columns.amount) == Columns.amount && reader["amount"]!=DBNull.Value)
currentCcmsInvoiceLineItem.amount =(decimal?) reader["amount"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsInvoiceLineItem.id = (int) reader["id"]; 
if (reader["invoice_id"] != DBNull.Value)
currentCcmsInvoiceLineItem.invoice_id = (int) reader["invoice_id"]; 
if (reader["name"] != DBNull.Value)
currentCcmsInvoiceLineItem.name = (string) reader["name"]; 
if (reader["description"] != DBNull.Value)
currentCcmsInvoiceLineItem.description = (string) reader["description"]; 
if (reader["amount"] != DBNull.Value)
currentCcmsInvoiceLineItem.amount = (decimal?) reader["amount"]; 
} 

currentCcmsInvoiceLineItem.isNewEntity = false;
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

public CcmsInvoiceLineItem CurrentCcmsInvoiceLineItem
{
get{ return currentCcmsInvoiceLineItem; }
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


#region CcmsInvoiceLineItem functions

public static CcmsInvoiceLineItemReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.invoice_id == (Columns.invoice_id & columns))
qry.Append("invoice_id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.description == (Columns.description & columns))
qry.Append("description,");
if (Columns.amount == (Columns.amount & columns))
qry.Append("amount,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_invoice_line_item ");

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
return new CcmsInvoiceLineItemReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsInvoiceLineItemReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsInvoiceLineItemReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,invoice_id,name,description,amount from Ccms_invoice_line_item ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsInvoiceLineItemReader(cmd.ExecuteReader(), conn);
}

static public CcmsInvoiceLineItemReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsInvoiceLineItem LoadCcmsInvoiceLineItem(string where)
{
CcmsInvoiceLineItemReader reader = CcmsInvoiceLineItem.ExecuteReader(where);
CcmsInvoiceLineItem _ccmsinvoicelineitem = null;
if (reader.Read())
_ccmsinvoicelineitem = reader.CurrentCcmsInvoiceLineItem;
reader.Close();
return _ccmsinvoicelineitem;
}

public static CcmsInvoiceLineItem LoadCcmsInvoiceLineItem(string where, IDbConnection conn)
{
CcmsInvoiceLineItemReader reader = CcmsInvoiceLineItem.ExecuteReader(where, conn);
CcmsInvoiceLineItem _ccmsinvoicelineitem = null;
if (reader.Read())
_ccmsinvoicelineitem = reader.CurrentCcmsInvoiceLineItem;
reader.Close(false);
return _ccmsinvoicelineitem;
}

public static CcmsInvoiceLineItem LoadCcmsInvoiceLineItemByPk( int id )
{
return LoadCcmsInvoiceLineItem( " id="+id );
}

public static CcmsInvoiceLineItem LoadCcmsInvoiceLineItemByPk( int id , IDbConnection conn)
{
return LoadCcmsInvoiceLineItem(" id="+id , conn);
}

public void Save()
{
if (idChanged || invoice_idChanged || nameChanged || descriptionChanged || amountChanged )
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
if (idChanged || invoice_idChanged || nameChanged || descriptionChanged || amountChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_invoice_line_item( id,invoice_id,name,description,amount ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(invoice_idDbString+",");
qry.Append(nameDbString+",");
qry.Append(descriptionDbString+",");
qry.Append(amountDbString);
qry.Append(");");

}
else
{
if (!(idChanged || invoice_idChanged || nameChanged || descriptionChanged || amountChanged ))
return;
qry.Append("UPDATE Ccms_invoice_line_item set "); if ( invoice_idChanged )
{
qry.Append("invoice_id ="+invoice_idDbString);
qry.Append(",");
}

if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( descriptionChanged )
{
qry.Append("description ="+descriptionDbString);
qry.Append(",");
}

if ( amountChanged )
{
qry.Append("amount ="+amountDbString);
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
cmd.CommandText = "DELETE Ccms_invoice_line_item where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsInvoiceLineItems(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_invoice_line_item where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
invoice_id= 2,
name= 4,
description= 8,
amount= 16
}
#endregion
public void BulkSave(List<CcmsInvoiceLineItem> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_invoice_line_item";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsInvoiceLineItem.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsInvoiceLineItem> transList,ref DataTable dt)
{
foreach (CcmsInvoiceLineItem tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["invoice_id"] = tran.InvoiceId;
Row["name"] = tran.Name;
Row["description"] = tran.Description;
Row["amount"] = tran.Amount;
dt.Rows.Add(Row);
} }
}
}
