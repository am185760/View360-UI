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
public class CcmsOrderDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsOrderDetail() { }
public CcmsOrderDetail( long id ) 
{
}
public CcmsOrderDetail( long? order_id,string denomination_name,decimal? quantity,long? note_set_item_id )
{
this.order_id = order_id;
this.order_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.quantity = quantity;
this.quantityChanged = true;
this.note_set_item_id = note_set_item_id;
this.note_set_item_idChanged = true;
}
private CcmsOrderDetail( long id,long? order_id,string denomination_name,decimal? quantity,long? note_set_item_id )
{
this.id = id;
this.idChanged = true;
this.order_id = order_id;
this.order_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.quantity = quantity;
this.quantityChanged = true;
this.note_set_item_id = note_set_item_id;
this.note_set_item_idChanged = true;
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
#region OrderId
private bool order_idChanged = false;
private long? order_id;
public long? OrderId
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
if (this.order_id.HasValue)
return order_id.ToString();
else
return "null";
}
}
#endregion
#region DenominationName
private bool denomination_nameChanged = false;
private string denomination_name;
public string DenominationName
{
get { return denomination_name; }
set { 
denomination_name = value;
denomination_nameChanged = true;
}
}
private string denomination_nameDbString
{
get
{
if (this.denomination_name!=null)
return string.Format("'{0}'",denomination_name); else
return "null";
}
}
#endregion
#region Quantity
private bool quantityChanged = false;
private decimal? quantity;
public decimal? Quantity
{
get { return quantity; }
set { 
quantity = value;
quantityChanged = true;
}
}
private string quantityDbString
{
get
{
if (this.quantity.HasValue)
return quantity.ToString();
else
return "null";
}
}
#endregion
#region NoteSetItemId
private bool note_set_item_idChanged = false;
private long? note_set_item_id;
public long? NoteSetItemId
{
get { return note_set_item_id; }
set { 
note_set_item_id = value;
note_set_item_idChanged = true;
}
}
private string note_set_item_idDbString
{
get
{
if (this.note_set_item_id.HasValue)
return note_set_item_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsOrderDetailReader
public class CcmsOrderDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsOrderDetail currentCcmsOrderDetail;
Columns columns;
bool partialRead = false;
private CcmsOrderDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsOrderDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsOrderDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsOrderDetail; }

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
currentCcmsOrderDetail = new CcmsOrderDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsOrderDetail.id =(long) reader["id"]; 
if ((columns & Columns.order_id) == Columns.order_id && reader["order_id"]!=DBNull.Value)
currentCcmsOrderDetail.order_id =(long?) reader["order_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsOrderDetail.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.quantity) == Columns.quantity && reader["quantity"]!=DBNull.Value)
currentCcmsOrderDetail.quantity =(decimal?) reader["quantity"]; 
if ((columns & Columns.note_set_item_id) == Columns.note_set_item_id && reader["note_set_item_id"]!=DBNull.Value)
currentCcmsOrderDetail.note_set_item_id =(long?) reader["note_set_item_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsOrderDetail.id = (long) reader["id"]; 
if (reader["order_id"] != DBNull.Value)
currentCcmsOrderDetail.order_id = (long?) reader["order_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsOrderDetail.denomination_name = (string) reader["denomination_name"]; 
if (reader["quantity"] != DBNull.Value)
currentCcmsOrderDetail.quantity = (decimal?) reader["quantity"]; 
if (reader["note_set_item_id"] != DBNull.Value)
currentCcmsOrderDetail.note_set_item_id = (long?) reader["note_set_item_id"]; 
} 

currentCcmsOrderDetail.isNewEntity = false;
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

public CcmsOrderDetail CurrentCcmsOrderDetail
{
get{ return currentCcmsOrderDetail; }
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


#region CcmsOrderDetail functions

public static CcmsOrderDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.order_id == (Columns.order_id & columns))
qry.Append("order_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.quantity == (Columns.quantity & columns))
qry.Append("quantity,");
if (Columns.note_set_item_id == (Columns.note_set_item_id & columns))
qry.Append("note_set_item_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_order_detail ");

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
return new CcmsOrderDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsOrderDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsOrderDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,order_id,denomination_name,quantity,note_set_item_id from Ccms_order_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsOrderDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsOrderDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsOrderDetail LoadCcmsOrderDetail(string where)
{
CcmsOrderDetailReader reader = CcmsOrderDetail.ExecuteReader(where);
CcmsOrderDetail _ccmsorderdetail = null;
if (reader.Read())
_ccmsorderdetail = reader.CurrentCcmsOrderDetail;
reader.Close();
return _ccmsorderdetail;
}

public static CcmsOrderDetail LoadCcmsOrderDetail(string where, IDbConnection conn)
{
CcmsOrderDetailReader reader = CcmsOrderDetail.ExecuteReader(where, conn);
CcmsOrderDetail _ccmsorderdetail = null;
if (reader.Read())
_ccmsorderdetail = reader.CurrentCcmsOrderDetail;
reader.Close(false);
return _ccmsorderdetail;
}

public static CcmsOrderDetail LoadCcmsOrderDetailByPk( long id )
{
return LoadCcmsOrderDetail( " id="+id );
}

public static CcmsOrderDetail LoadCcmsOrderDetailByPk( long id , IDbConnection conn)
{
return LoadCcmsOrderDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || order_idChanged || denomination_nameChanged || quantityChanged || note_set_item_idChanged )
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
if (idChanged || order_idChanged || denomination_nameChanged || quantityChanged || note_set_item_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_order_detail( order_id,denomination_name,quantity,note_set_item_id ) values(");
qry.Append(order_idDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(quantityDbString+",");
qry.Append(note_set_item_idDbString);
qry.Append(");");

}
else
{
if (!(idChanged || order_idChanged || denomination_nameChanged || quantityChanged || note_set_item_idChanged ))
return;
qry.Append("UPDATE Ccms_order_detail set "); if ( order_idChanged )
{
qry.Append("order_id ="+order_idDbString);
qry.Append(",");
}

if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( quantityChanged )
{
qry.Append("quantity ="+quantityDbString);
qry.Append(",");
}

if ( note_set_item_idChanged )
{
qry.Append("note_set_item_id ="+note_set_item_idDbString);
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
cmd.CommandText = "DELETE Ccms_order_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsOrderDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_order_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
order_id= 2,
denomination_name= 4,
quantity= 8,
note_set_item_id= 16
}
#endregion
public void BulkSave(List<CcmsOrderDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_order_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsOrderDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsOrderDetail> transList,ref DataTable dt)
{
foreach (CcmsOrderDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["order_id"] = tran.OrderId;
Row["denomination_name"] = tran.DenominationName;
Row["quantity"] = tran.Quantity;
Row["note_set_item_id"] = tran.NoteSetItemId;
dt.Rows.Add(Row);
} }
}
}
