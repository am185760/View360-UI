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
public class CcmsReplenishmentPurgeDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsReplenishmentPurgeDetail() { }
public CcmsReplenishmentPurgeDetail( long id ) 
{
}
public CcmsReplenishmentPurgeDetail( long? replenishment_id,string denomination_name,decimal? quantity,long? note_set_item_id )
{
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.quantity = quantity;
this.quantityChanged = true;
this.note_set_item_id = note_set_item_id;
this.note_set_item_idChanged = true;
}
private CcmsReplenishmentPurgeDetail( long id,long? replenishment_id,string denomination_name,decimal? quantity,long? note_set_item_id )
{
this.id = id;
this.idChanged = true;
this.replenishment_id = replenishment_id;
this.replenishment_idChanged = true;
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

#region CcmsReplenishmentPurgeDetailReader
public class CcmsReplenishmentPurgeDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsReplenishmentPurgeDetail currentCcmsReplenishmentPurgeDetail;
Columns columns;
bool partialRead = false;
private CcmsReplenishmentPurgeDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsReplenishmentPurgeDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsReplenishmentPurgeDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsReplenishmentPurgeDetail; }

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
currentCcmsReplenishmentPurgeDetail = new CcmsReplenishmentPurgeDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsReplenishmentPurgeDetail.id =(long) reader["id"]; 
if ((columns & Columns.replenishment_id) == Columns.replenishment_id && reader["replenishment_id"]!=DBNull.Value)
currentCcmsReplenishmentPurgeDetail.replenishment_id =(long?) reader["replenishment_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsReplenishmentPurgeDetail.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.quantity) == Columns.quantity && reader["quantity"]!=DBNull.Value)
currentCcmsReplenishmentPurgeDetail.quantity =(decimal?) reader["quantity"]; 
if ((columns & Columns.note_set_item_id) == Columns.note_set_item_id && reader["note_set_item_id"]!=DBNull.Value)
currentCcmsReplenishmentPurgeDetail.note_set_item_id =(long?) reader["note_set_item_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsReplenishmentPurgeDetail.id = (long) reader["id"]; 
if (reader["replenishment_id"] != DBNull.Value)
currentCcmsReplenishmentPurgeDetail.replenishment_id = (long?) reader["replenishment_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsReplenishmentPurgeDetail.denomination_name = (string) reader["denomination_name"]; 
if (reader["quantity"] != DBNull.Value)
currentCcmsReplenishmentPurgeDetail.quantity = (decimal?) reader["quantity"]; 
if (reader["note_set_item_id"] != DBNull.Value)
currentCcmsReplenishmentPurgeDetail.note_set_item_id = (long?) reader["note_set_item_id"]; 
} 

currentCcmsReplenishmentPurgeDetail.isNewEntity = false;
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

public CcmsReplenishmentPurgeDetail CurrentCcmsReplenishmentPurgeDetail
{
get{ return currentCcmsReplenishmentPurgeDetail; }
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


#region CcmsReplenishmentPurgeDetail functions

public static CcmsReplenishmentPurgeDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.replenishment_id == (Columns.replenishment_id & columns))
qry.Append("replenishment_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.quantity == (Columns.quantity & columns))
qry.Append("quantity,");
if (Columns.note_set_item_id == (Columns.note_set_item_id & columns))
qry.Append("note_set_item_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_replenishment_purge_detail ");

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
return new CcmsReplenishmentPurgeDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsReplenishmentPurgeDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsReplenishmentPurgeDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,replenishment_id,denomination_name,quantity,note_set_item_id from Ccms_replenishment_purge_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsReplenishmentPurgeDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsReplenishmentPurgeDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsReplenishmentPurgeDetail LoadCcmsReplenishmentPurgeDetail(string where)
{
CcmsReplenishmentPurgeDetailReader reader = CcmsReplenishmentPurgeDetail.ExecuteReader(where);
CcmsReplenishmentPurgeDetail _ccmsreplenishmentpurgedetail = null;
if (reader.Read())
_ccmsreplenishmentpurgedetail = reader.CurrentCcmsReplenishmentPurgeDetail;
reader.Close();
return _ccmsreplenishmentpurgedetail;
}

public static CcmsReplenishmentPurgeDetail LoadCcmsReplenishmentPurgeDetail(string where, IDbConnection conn)
{
CcmsReplenishmentPurgeDetailReader reader = CcmsReplenishmentPurgeDetail.ExecuteReader(where, conn);
CcmsReplenishmentPurgeDetail _ccmsreplenishmentpurgedetail = null;
if (reader.Read())
_ccmsreplenishmentpurgedetail = reader.CurrentCcmsReplenishmentPurgeDetail;
reader.Close(false);
return _ccmsreplenishmentpurgedetail;
}

public static CcmsReplenishmentPurgeDetail LoadCcmsReplenishmentPurgeDetailByPk( long id )
{
return LoadCcmsReplenishmentPurgeDetail( " id="+id );
}

public static CcmsReplenishmentPurgeDetail LoadCcmsReplenishmentPurgeDetailByPk( long id , IDbConnection conn)
{
return LoadCcmsReplenishmentPurgeDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || replenishment_idChanged || denomination_nameChanged || quantityChanged || note_set_item_idChanged )
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
if (idChanged || replenishment_idChanged || denomination_nameChanged || quantityChanged || note_set_item_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_replenishment_purge_detail( id,replenishment_id,denomination_name,quantity,note_set_item_id ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(replenishment_idDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(quantityDbString+",");
qry.Append(note_set_item_idDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || replenishment_idChanged || denomination_nameChanged || quantityChanged || note_set_item_idChanged ))
return;
qry.Append("UPDATE Ccms_replenishment_purge_detail set "); if ( replenishment_idChanged )
{
qry.Append("replenishment_id ="+replenishment_idDbString);
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
cmd.CommandText = "DELETE Ccms_replenishment_purge_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsReplenishmentPurgeDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_replenishment_purge_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
replenishment_id= 2,
denomination_name= 4,
quantity= 8,
note_set_item_id= 16
}
#endregion
public void BulkSave(List<CcmsReplenishmentPurgeDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_replenishment_purge_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsReplenishmentPurgeDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsReplenishmentPurgeDetail> transList,ref DataTable dt)
{
foreach (CcmsReplenishmentPurgeDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["replenishment_id"] = tran.ReplenishmentId;
Row["denomination_name"] = tran.DenominationName;
Row["quantity"] = tran.Quantity;
Row["note_set_item_id"] = tran.NoteSetItemId;
dt.Rows.Add(Row);
} }
}
}
