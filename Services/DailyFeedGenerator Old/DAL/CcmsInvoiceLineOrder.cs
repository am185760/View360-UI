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
public class CcmsInvoiceLineOrder
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsInvoiceLineOrder() { }
public CcmsInvoiceLineOrder( int id,int invoice_id,int order_id ) 
{
this.invoice_id = invoice_id;
this.invoice_idChanged = true;
this.order_id = order_id;
this.order_idChanged = true;
}
public CcmsInvoiceLineOrder( int invoice_id,int order_id,decimal? amount,string description,string order_number )
{
this.invoice_id = invoice_id;
this.invoice_idChanged = true;
this.order_id = order_id;
this.order_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.description = description;
this.descriptionChanged = true;
this.order_number = order_number;
this.order_numberChanged = true;
}
private CcmsInvoiceLineOrder( int id,int invoice_id,int order_id,decimal? amount,string description,string order_number )
{
this.id = id;
this.idChanged = true;
this.invoice_id = invoice_id;
this.invoice_idChanged = true;
this.order_id = order_id;
this.order_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.description = description;
this.descriptionChanged = true;
this.order_number = order_number;
this.order_numberChanged = true;
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
#region OrderId
private bool order_idChanged = false;
private int order_id;
public int OrderId
{
get { return order_id; }
set { 
order_id = value;
order_idChanged = true;
}
}
private string order_idDbString
{
get
{
return order_id.ToString();
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
#region OrderNumber
private bool order_numberChanged = false;
private string order_number;
public string OrderNumber
{
get { return order_number; }
set { 
order_number = value;
order_numberChanged = true;
}
}
private string order_numberDbString
{
get
{
if (this.order_number!=null)
return string.Format("'{0}'",order_number); else
return "null";
}
}
#endregion
#endregion

#region CcmsInvoiceLineOrderReader
public class CcmsInvoiceLineOrderReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsInvoiceLineOrder currentCcmsInvoiceLineOrder;
Columns columns;
bool partialRead = false;
private CcmsInvoiceLineOrderReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsInvoiceLineOrderReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsInvoiceLineOrderReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsInvoiceLineOrder; }

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
currentCcmsInvoiceLineOrder = new CcmsInvoiceLineOrder();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsInvoiceLineOrder.id =(int) reader["id"]; 
if ((columns & Columns.invoice_id) == Columns.invoice_id && reader["invoice_id"]!=DBNull.Value)
currentCcmsInvoiceLineOrder.invoice_id =(int) reader["invoice_id"]; 
if ((columns & Columns.order_id) == Columns.order_id && reader["order_id"]!=DBNull.Value)
currentCcmsInvoiceLineOrder.order_id =(int) reader["order_id"]; 
if ((columns & Columns.amount) == Columns.amount && reader["amount"]!=DBNull.Value)
currentCcmsInvoiceLineOrder.amount =(decimal?) reader["amount"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsInvoiceLineOrder.description =(string) reader["description"]; 
if ((columns & Columns.order_number) == Columns.order_number && reader["order_number"]!=DBNull.Value)
currentCcmsInvoiceLineOrder.order_number =(string) reader["order_number"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsInvoiceLineOrder.id = (int) reader["id"]; 
if (reader["invoice_id"] != DBNull.Value)
currentCcmsInvoiceLineOrder.invoice_id = (int) reader["invoice_id"]; 
if (reader["order_id"] != DBNull.Value)
currentCcmsInvoiceLineOrder.order_id = (int) reader["order_id"]; 
if (reader["amount"] != DBNull.Value)
currentCcmsInvoiceLineOrder.amount = (decimal?) reader["amount"]; 
if (reader["description"] != DBNull.Value)
currentCcmsInvoiceLineOrder.description = (string) reader["description"]; 
if (reader["order_number"] != DBNull.Value)
currentCcmsInvoiceLineOrder.order_number = (string) reader["order_number"]; 
} 

currentCcmsInvoiceLineOrder.isNewEntity = false;
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

public CcmsInvoiceLineOrder CurrentCcmsInvoiceLineOrder
{
get{ return currentCcmsInvoiceLineOrder; }
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


#region CcmsInvoiceLineOrder functions

public static CcmsInvoiceLineOrderReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.invoice_id == (Columns.invoice_id & columns))
qry.Append("invoice_id,");
if (Columns.order_id == (Columns.order_id & columns))
qry.Append("order_id,");
if (Columns.amount == (Columns.amount & columns))
qry.Append("amount,");
if (Columns.description == (Columns.description & columns))
qry.Append("description,");
if (Columns.order_number == (Columns.order_number & columns))
qry.Append("order_number,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_invoice_line_order ");

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
return new CcmsInvoiceLineOrderReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsInvoiceLineOrderReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsInvoiceLineOrderReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,invoice_id,order_id,amount,description,order_number from Ccms_invoice_line_order ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsInvoiceLineOrderReader(cmd.ExecuteReader(), conn);
}

static public CcmsInvoiceLineOrderReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsInvoiceLineOrder LoadCcmsInvoiceLineOrder(string where)
{
CcmsInvoiceLineOrderReader reader = CcmsInvoiceLineOrder.ExecuteReader(where);
CcmsInvoiceLineOrder _ccmsinvoicelineorder = null;
if (reader.Read())
_ccmsinvoicelineorder = reader.CurrentCcmsInvoiceLineOrder;
reader.Close();
return _ccmsinvoicelineorder;
}

public static CcmsInvoiceLineOrder LoadCcmsInvoiceLineOrder(string where, IDbConnection conn)
{
CcmsInvoiceLineOrderReader reader = CcmsInvoiceLineOrder.ExecuteReader(where, conn);
CcmsInvoiceLineOrder _ccmsinvoicelineorder = null;
if (reader.Read())
_ccmsinvoicelineorder = reader.CurrentCcmsInvoiceLineOrder;
reader.Close(false);
return _ccmsinvoicelineorder;
}

public static CcmsInvoiceLineOrder LoadCcmsInvoiceLineOrderByPk( int id )
{
return LoadCcmsInvoiceLineOrder( " id="+id );
}

public static CcmsInvoiceLineOrder LoadCcmsInvoiceLineOrderByPk( int id , IDbConnection conn)
{
return LoadCcmsInvoiceLineOrder(" id="+id , conn);
}

public void Save()
{
if (idChanged || invoice_idChanged || order_idChanged || amountChanged || descriptionChanged || order_numberChanged )
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
if (idChanged || invoice_idChanged || order_idChanged || amountChanged || descriptionChanged || order_numberChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_invoice_line_order( id,invoice_id,order_id,amount,description,order_number ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(invoice_idDbString+",");
qry.Append(order_idDbString+",");
qry.Append(amountDbString+",");
qry.Append(descriptionDbString+",");
qry.Append(order_numberDbString);
qry.Append(");");

}
else
{
if (!(idChanged || invoice_idChanged || order_idChanged || amountChanged || descriptionChanged || order_numberChanged ))
return;
qry.Append("UPDATE Ccms_invoice_line_order set "); if ( invoice_idChanged )
{
qry.Append("invoice_id ="+invoice_idDbString);
qry.Append(",");
}

if ( order_idChanged )
{
qry.Append("order_id ="+order_idDbString);
qry.Append(",");
}

if ( amountChanged )
{
qry.Append("amount ="+amountDbString);
qry.Append(",");
}

if ( descriptionChanged )
{
qry.Append("description ="+descriptionDbString);
qry.Append(",");
}

if ( order_numberChanged )
{
qry.Append("order_number ="+order_numberDbString);
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
cmd.CommandText = "DELETE Ccms_invoice_line_order where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsInvoiceLineOrders(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_invoice_line_order where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
invoice_id= 2,
order_id= 4,
amount= 8,
description= 16,
order_number= 32
}
#endregion
public void BulkSave(List<CcmsInvoiceLineOrder> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_invoice_line_order";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsInvoiceLineOrder.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsInvoiceLineOrder> transList,ref DataTable dt)
{
foreach (CcmsInvoiceLineOrder tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["invoice_id"] = tran.InvoiceId;
Row["order_id"] = tran.OrderId;
Row["amount"] = tran.Amount;
Row["description"] = tran.Description;
Row["order_number"] = tran.OrderNumber;
dt.Rows.Add(Row);
} }
}
}
