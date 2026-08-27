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
public class CcmsAtmReplenishmentPurgeDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsAtmReplenishmentPurgeDetail() { }
public CcmsAtmReplenishmentPurgeDetail( long id ) 
{
}
public CcmsAtmReplenishmentPurgeDetail( long? quantity,long? note_set_item_id,string denomination_name,long? atm_ledger_id )
{
this.quantity = quantity;
this.quantityChanged = true;
this.note_set_item_id = note_set_item_id;
this.note_set_item_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.atm_ledger_id = atm_ledger_id;
this.atm_ledger_idChanged = true;
}
private CcmsAtmReplenishmentPurgeDetail( long id,long? quantity,long? note_set_item_id,string denomination_name,long? atm_ledger_id )
{
this.id = id;
this.idChanged = true;
this.quantity = quantity;
this.quantityChanged = true;
this.note_set_item_id = note_set_item_id;
this.note_set_item_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.atm_ledger_id = atm_ledger_id;
this.atm_ledger_idChanged = true;
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
#region Quantity
private bool quantityChanged = false;
private long? quantity;
public long? Quantity
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
#region AtmLedgerId
private bool atm_ledger_idChanged = false;
private long? atm_ledger_id;
public long? AtmLedgerId
{
get { return atm_ledger_id; }
set { 
atm_ledger_id = value;
atm_ledger_idChanged = true;
}
}
private string atm_ledger_idDbString
{
get
{
if (this.atm_ledger_id.HasValue)
return atm_ledger_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsAtmReplenishmentPurgeDetailReader
public class CcmsAtmReplenishmentPurgeDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsAtmReplenishmentPurgeDetail currentCcmsAtmReplenishmentPurgeDetail;
Columns columns;
bool partialRead = false;
private CcmsAtmReplenishmentPurgeDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsAtmReplenishmentPurgeDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsAtmReplenishmentPurgeDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsAtmReplenishmentPurgeDetail; }

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
currentCcmsAtmReplenishmentPurgeDetail = new CcmsAtmReplenishmentPurgeDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.id =(long) reader["id"]; 
if ((columns & Columns.quantity) == Columns.quantity && reader["quantity"]!=DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.quantity =(long?) reader["quantity"]; 
if ((columns & Columns.note_set_item_id) == Columns.note_set_item_id && reader["note_set_item_id"]!=DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.note_set_item_id =(long?) reader["note_set_item_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.atm_ledger_id) == Columns.atm_ledger_id && reader["atm_ledger_id"]!=DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.atm_ledger_id =(long?) reader["atm_ledger_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.id = (long) reader["id"]; 
if (reader["quantity"] != DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.quantity = (long?) reader["quantity"]; 
if (reader["note_set_item_id"] != DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.note_set_item_id = (long?) reader["note_set_item_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.denomination_name = (string) reader["denomination_name"]; 
if (reader["atm_ledger_id"] != DBNull.Value)
currentCcmsAtmReplenishmentPurgeDetail.atm_ledger_id = (long?) reader["atm_ledger_id"]; 
} 

currentCcmsAtmReplenishmentPurgeDetail.isNewEntity = false;
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

public CcmsAtmReplenishmentPurgeDetail CurrentCcmsAtmReplenishmentPurgeDetail
{
get{ return currentCcmsAtmReplenishmentPurgeDetail; }
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


#region CcmsAtmReplenishmentPurgeDetail functions

public static CcmsAtmReplenishmentPurgeDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.quantity == (Columns.quantity & columns))
qry.Append("quantity,");
if (Columns.note_set_item_id == (Columns.note_set_item_id & columns))
qry.Append("note_set_item_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.atm_ledger_id == (Columns.atm_ledger_id & columns))
qry.Append("atm_ledger_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_atm_replenishment_purge_detail ");

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
return new CcmsAtmReplenishmentPurgeDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsAtmReplenishmentPurgeDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsAtmReplenishmentPurgeDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,quantity,note_set_item_id,denomination_name,atm_ledger_id from Ccms_atm_replenishment_purge_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsAtmReplenishmentPurgeDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsAtmReplenishmentPurgeDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsAtmReplenishmentPurgeDetail LoadCcmsAtmReplenishmentPurgeDetail(string where)
{
CcmsAtmReplenishmentPurgeDetailReader reader = CcmsAtmReplenishmentPurgeDetail.ExecuteReader(where);
CcmsAtmReplenishmentPurgeDetail _ccmsatmreplenishmentpurgedetail = null;
if (reader.Read())
_ccmsatmreplenishmentpurgedetail = reader.CurrentCcmsAtmReplenishmentPurgeDetail;
reader.Close();
return _ccmsatmreplenishmentpurgedetail;
}

public static CcmsAtmReplenishmentPurgeDetail LoadCcmsAtmReplenishmentPurgeDetail(string where, IDbConnection conn)
{
CcmsAtmReplenishmentPurgeDetailReader reader = CcmsAtmReplenishmentPurgeDetail.ExecuteReader(where, conn);
CcmsAtmReplenishmentPurgeDetail _ccmsatmreplenishmentpurgedetail = null;
if (reader.Read())
_ccmsatmreplenishmentpurgedetail = reader.CurrentCcmsAtmReplenishmentPurgeDetail;
reader.Close(false);
return _ccmsatmreplenishmentpurgedetail;
}

public static CcmsAtmReplenishmentPurgeDetail LoadCcmsAtmReplenishmentPurgeDetailByPk( long id )
{
return LoadCcmsAtmReplenishmentPurgeDetail( " id="+id );
}

public static CcmsAtmReplenishmentPurgeDetail LoadCcmsAtmReplenishmentPurgeDetailByPk( long id , IDbConnection conn)
{
return LoadCcmsAtmReplenishmentPurgeDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || quantityChanged || note_set_item_idChanged || denomination_nameChanged || atm_ledger_idChanged )
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
if (idChanged || quantityChanged || note_set_item_idChanged || denomination_nameChanged || atm_ledger_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_atm_replenishment_purge_detail( quantity,note_set_item_id,denomination_name,atm_ledger_id ) values(");
qry.Append(quantityDbString+",");
qry.Append(note_set_item_idDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(atm_ledger_idDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || quantityChanged || note_set_item_idChanged || denomination_nameChanged || atm_ledger_idChanged ))
return;
qry.Append("UPDATE Ccms_atm_replenishment_purge_detail set "); if ( quantityChanged )
{
qry.Append("quantity ="+quantityDbString);
qry.Append(",");
}

if ( note_set_item_idChanged )
{
qry.Append("note_set_item_id ="+note_set_item_idDbString);
qry.Append(",");
}

if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( atm_ledger_idChanged )
{
qry.Append("atm_ledger_id ="+atm_ledger_idDbString);
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
cmd.CommandText = "DELETE Ccms_atm_replenishment_purge_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsAtmReplenishmentPurgeDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_atm_replenishment_purge_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
quantity= 2,
note_set_item_id= 4,
denomination_name= 8,
atm_ledger_id= 16
}
#endregion
public void BulkSave(List<CcmsAtmReplenishmentPurgeDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_atm_replenishment_purge_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsAtmReplenishmentPurgeDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsAtmReplenishmentPurgeDetail> transList,ref DataTable dt)
{
foreach (CcmsAtmReplenishmentPurgeDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["quantity"] = tran.Quantity;
Row["note_set_item_id"] = tran.NoteSetItemId;
Row["denomination_name"] = tran.DenominationName;
Row["atm_ledger_id"] = tran.AtmLedgerId;
dt.Rows.Add(Row);
} }
}
}
