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
public class CcmsReplenishmentDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsReplenishmentDetail() { }
public CcmsReplenishmentDetail( long id ) 
{
}
public CcmsReplenishmentDetail( long? order_detail_id,decimal? residual_qty,long? replenishment_id,decimal? replenished_qty )
{
this.order_detail_id = order_detail_id;
this.order_detail_idChanged = true;
this.residual_qty = residual_qty;
this.residual_qtyChanged = true;
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
this.replenished_qty = replenished_qty;
this.replenished_qtyChanged = true;
}
private CcmsReplenishmentDetail( long id,long? order_detail_id,decimal? residual_qty,long? replenishment_id,decimal? replenished_qty )
{
this.id = id;
this.idChanged = true;
this.order_detail_id = order_detail_id;
this.order_detail_idChanged = true;
this.residual_qty = residual_qty;
this.residual_qtyChanged = true;
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
this.replenished_qty = replenished_qty;
this.replenished_qtyChanged = true;
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
#region OrderDetailId
private bool order_detail_idChanged = false;
private long? order_detail_id;
public long? OrderDetailId
{
get { return order_detail_id; }
set { 
order_detail_id = value;
order_detail_idChanged = true;
}
}
private string order_detail_idDbString
{
get
{
if (this.order_detail_id.HasValue)
return order_detail_id.ToString();
else
return "null";
}
}
#endregion
#region ResidualQty
private bool residual_qtyChanged = false;
private decimal? residual_qty;
public decimal? ResidualQty
{
get { return residual_qty; }
set { 
residual_qty = value;
residual_qtyChanged = true;
}
}
private string residual_qtyDbString
{
get
{
if (this.residual_qty.HasValue)
return residual_qty.ToString();
else
return "null";
}
}
#endregion
#region ReplenishmentId
private bool replenishment_idChanged = false;
private long? replenishment_id;
public long? ReplenishmentId
{
get { return replenishment_id; }
set { 
replenishment_id = value;
replenishment_idChanged = true;
}
}
private string replenishment_idDbString
{
get
{
if (this.replenishment_id.HasValue)
return replenishment_id.ToString();
else
return "null";
}
}
#endregion
#region ReplenishedQty
private bool replenished_qtyChanged = false;
private decimal? replenished_qty;
public decimal? ReplenishedQty
{
get { return replenished_qty; }
set { 
replenished_qty = value;
replenished_qtyChanged = true;
}
}
private string replenished_qtyDbString
{
get
{
if (this.replenished_qty.HasValue)
return replenished_qty.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsReplenishmentDetailReader
public class CcmsReplenishmentDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsReplenishmentDetail currentCcmsReplenishmentDetail;
Columns columns;
bool partialRead = false;
private CcmsReplenishmentDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsReplenishmentDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsReplenishmentDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsReplenishmentDetail; }

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
currentCcmsReplenishmentDetail = new CcmsReplenishmentDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsReplenishmentDetail.id =(long) reader["id"]; 
if ((columns & Columns.order_detail_id) == Columns.order_detail_id && reader["order_detail_id"]!=DBNull.Value)
currentCcmsReplenishmentDetail.order_detail_id =(long?) reader["order_detail_id"]; 
if ((columns & Columns.residual_qty) == Columns.residual_qty && reader["residual_qty"]!=DBNull.Value)
currentCcmsReplenishmentDetail.residual_qty =(decimal?) reader["residual_qty"]; 
if ((columns & Columns.replenishment_id) == Columns.replenishment_id && reader["replenishment_id"]!=DBNull.Value)
currentCcmsReplenishmentDetail.replenishment_id =(long?) reader["replenishment_id"]; 
if ((columns & Columns.replenished_qty) == Columns.replenished_qty && reader["replenished_qty"]!=DBNull.Value)
currentCcmsReplenishmentDetail.replenished_qty =(decimal?) reader["replenished_qty"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsReplenishmentDetail.id = (long) reader["id"]; 
if (reader["order_detail_id"] != DBNull.Value)
currentCcmsReplenishmentDetail.order_detail_id = (long?) reader["order_detail_id"]; 
if (reader["residual_qty"] != DBNull.Value)
currentCcmsReplenishmentDetail.residual_qty = (decimal?) reader["residual_qty"]; 
if (reader["replenishment_id"] != DBNull.Value)
currentCcmsReplenishmentDetail.replenishment_id = (long?) reader["replenishment_id"]; 
if (reader["replenished_qty"] != DBNull.Value)
currentCcmsReplenishmentDetail.replenished_qty = (decimal?) reader["replenished_qty"]; 
} 

currentCcmsReplenishmentDetail.isNewEntity = false;
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

public CcmsReplenishmentDetail CurrentCcmsReplenishmentDetail
{
get{ return currentCcmsReplenishmentDetail; }
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


#region CcmsReplenishmentDetail functions

public static CcmsReplenishmentDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.order_detail_id == (Columns.order_detail_id & columns))
qry.Append("order_detail_id,");
if (Columns.residual_qty == (Columns.residual_qty & columns))
qry.Append("residual_qty,");
if (Columns.replenishment_id == (Columns.replenishment_id & columns))
qry.Append("replenishment_id,");
if (Columns.replenished_qty == (Columns.replenished_qty & columns))
qry.Append("replenished_qty,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_replenishment_detail ");

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
return new CcmsReplenishmentDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsReplenishmentDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsReplenishmentDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,order_detail_id,residual_qty,replenishment_id,replenished_qty from Ccms_replenishment_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsReplenishmentDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsReplenishmentDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsReplenishmentDetail LoadCcmsReplenishmentDetail(string where)
{
CcmsReplenishmentDetailReader reader = CcmsReplenishmentDetail.ExecuteReader(where);
CcmsReplenishmentDetail _ccmsreplenishmentdetail = null;
if (reader.Read())
_ccmsreplenishmentdetail = reader.CurrentCcmsReplenishmentDetail;
reader.Close();
return _ccmsreplenishmentdetail;
}

public static CcmsReplenishmentDetail LoadCcmsReplenishmentDetail(string where, IDbConnection conn)
{
CcmsReplenishmentDetailReader reader = CcmsReplenishmentDetail.ExecuteReader(where, conn);
CcmsReplenishmentDetail _ccmsreplenishmentdetail = null;
if (reader.Read())
_ccmsreplenishmentdetail = reader.CurrentCcmsReplenishmentDetail;
reader.Close(false);
return _ccmsreplenishmentdetail;
}

public static CcmsReplenishmentDetail LoadCcmsReplenishmentDetailByPk( long id )
{
return LoadCcmsReplenishmentDetail( " id="+id );
}

public static CcmsReplenishmentDetail LoadCcmsReplenishmentDetailByPk( long id , IDbConnection conn)
{
return LoadCcmsReplenishmentDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || order_detail_idChanged || residual_qtyChanged || replenishment_idChanged || replenished_qtyChanged )
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
if (idChanged || order_detail_idChanged || residual_qtyChanged || replenishment_idChanged || replenished_qtyChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_replenishment_detail( order_detail_id,residual_qty,replenishment_id,replenished_qty ) values(");
qry.Append(order_detail_idDbString+",");
qry.Append(residual_qtyDbString+",");
qry.Append(replenishment_idDbString+",");
qry.Append(replenished_qtyDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || order_detail_idChanged || residual_qtyChanged || replenishment_idChanged || replenished_qtyChanged ))
return;
qry.Append("UPDATE Ccms_replenishment_detail set "); if ( order_detail_idChanged )
{
qry.Append("order_detail_id ="+order_detail_idDbString);
qry.Append(",");
}

if ( residual_qtyChanged )
{
qry.Append("residual_qty ="+residual_qtyDbString);
qry.Append(",");
}

if ( replenishment_idChanged )
{
qry.Append("replenishment_id ="+replenishment_idDbString);
qry.Append(",");
}

if ( replenished_qtyChanged )
{
qry.Append("replenished_qty ="+replenished_qtyDbString);
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
    //cmd.ExecuteNonQuery();
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
cmd.CommandText = "DELETE Ccms_replenishment_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsReplenishmentDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_replenishment_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
order_detail_id= 2,
residual_qty= 4,
replenishment_id= 8,
replenished_qty= 16
}
#endregion
public void BulkSave(List<CcmsReplenishmentDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_replenishment_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsReplenishmentDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsReplenishmentDetail> transList,ref DataTable dt)
{
foreach (CcmsReplenishmentDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["order_detail_id"] = tran.OrderDetailId;
Row["residual_qty"] = tran.ResidualQty;
Row["replenishment_id"] = tran.ReplenishmentId;
Row["replenished_qty"] = tran.ReplenishedQty;
dt.Rows.Add(Row);
} }
}
}
