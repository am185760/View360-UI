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
public class CcmsVaultAdjustmentsDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsVaultAdjustmentsDetail() { }
public CcmsVaultAdjustmentsDetail( int ccms_vault_adjustments_id,int vault_note_type_id,int denomination_id,string denomination_name,int denomination_qty )
{
this.ccms_vault_adjustments_id = ccms_vault_adjustments_id;
this.ccms_vault_adjustments_idChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.denomination_qty = denomination_qty;
this.denomination_qtyChanged = true;
}
private CcmsVaultAdjustmentsDetail( int id,int ccms_vault_adjustments_id,int vault_note_type_id,int denomination_id,string denomination_name,int denomination_qty )
{
this.id = id;
this.idChanged = true;
this.ccms_vault_adjustments_id = ccms_vault_adjustments_id;
this.ccms_vault_adjustments_idChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.denomination_qty = denomination_qty;
this.denomination_qtyChanged = true;
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
#region CcmsVaultAdjustmentsId
private bool ccms_vault_adjustments_idChanged = false;
private int ccms_vault_adjustments_id;
public int CcmsVaultAdjustmentsId
{
get { return ccms_vault_adjustments_id; }
set { 
ccms_vault_adjustments_id = value;
ccms_vault_adjustments_idChanged = true;
}
}
private string ccms_vault_adjustments_idDbString
{
get
{
return ccms_vault_adjustments_id.ToString();
}
}
#endregion
#region VaultNoteTypeId
private bool vault_note_type_idChanged = false;
private int vault_note_type_id;
public int VaultNoteTypeId
{
get { return vault_note_type_id; }
set { 
vault_note_type_id = value;
vault_note_type_idChanged = true;
}
}
private string vault_note_type_idDbString
{
get
{
return vault_note_type_id.ToString();
}
}
#endregion
#region DenominationId
private bool denomination_idChanged = false;
private int denomination_id;
public int DenominationId
{
get { return denomination_id; }
set { 
denomination_id = value;
denomination_idChanged = true;
}
}
private string denomination_idDbString
{
get
{
return denomination_id.ToString();
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
#region DenominationQty
private bool denomination_qtyChanged = false;
private int denomination_qty;
public int DenominationQty
{
get { return denomination_qty; }
set { 
denomination_qty = value;
denomination_qtyChanged = true;
}
}
private string denomination_qtyDbString
{
get
{
return denomination_qty.ToString();
}
}
#endregion
#endregion

#region CcmsVaultAdjustmentsDetailReader
public class CcmsVaultAdjustmentsDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsVaultAdjustmentsDetail currentCcmsVaultAdjustmentsDetail;
Columns columns;
bool partialRead = false;
private CcmsVaultAdjustmentsDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsVaultAdjustmentsDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsVaultAdjustmentsDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsVaultAdjustmentsDetail; }

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
currentCcmsVaultAdjustmentsDetail = new CcmsVaultAdjustmentsDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsVaultAdjustmentsDetail.id =(int) reader["id"]; 
if ((columns & Columns.ccms_vault_adjustments_id) == Columns.ccms_vault_adjustments_id && reader["ccms_vault_adjustments_id"]!=DBNull.Value)
currentCcmsVaultAdjustmentsDetail.ccms_vault_adjustments_id =(int) reader["ccms_vault_adjustments_id"]; 
if ((columns & Columns.vault_note_type_id) == Columns.vault_note_type_id && reader["vault_note_type_id"]!=DBNull.Value)
currentCcmsVaultAdjustmentsDetail.vault_note_type_id =(int) reader["vault_note_type_id"]; 
if ((columns & Columns.denomination_id) == Columns.denomination_id && reader["denomination_id"]!=DBNull.Value)
currentCcmsVaultAdjustmentsDetail.denomination_id =(int) reader["denomination_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsVaultAdjustmentsDetail.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.denomination_qty) == Columns.denomination_qty && reader["denomination_qty"]!=DBNull.Value)
currentCcmsVaultAdjustmentsDetail.denomination_qty =(int) reader["denomination_qty"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsVaultAdjustmentsDetail.id = (int) reader["id"]; 
if (reader["ccms_vault_adjustments_id"] != DBNull.Value)
currentCcmsVaultAdjustmentsDetail.ccms_vault_adjustments_id = (int) reader["ccms_vault_adjustments_id"]; 
if (reader["vault_note_type_id"] != DBNull.Value)
currentCcmsVaultAdjustmentsDetail.vault_note_type_id = (int) reader["vault_note_type_id"]; 
if (reader["denomination_id"] != DBNull.Value)
currentCcmsVaultAdjustmentsDetail.denomination_id = (int) reader["denomination_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsVaultAdjustmentsDetail.denomination_name = (string) reader["denomination_name"]; 
if (reader["denomination_qty"] != DBNull.Value)
currentCcmsVaultAdjustmentsDetail.denomination_qty = (int) reader["denomination_qty"]; 
} 

currentCcmsVaultAdjustmentsDetail.isNewEntity = false;
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

public CcmsVaultAdjustmentsDetail CurrentCcmsVaultAdjustmentsDetail
{
get{ return currentCcmsVaultAdjustmentsDetail; }
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


#region CcmsVaultAdjustmentsDetail functions

public static CcmsVaultAdjustmentsDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.ccms_vault_adjustments_id == (Columns.ccms_vault_adjustments_id & columns))
qry.Append("ccms_vault_adjustments_id,");
if (Columns.vault_note_type_id == (Columns.vault_note_type_id & columns))
qry.Append("vault_note_type_id,");
if (Columns.denomination_id == (Columns.denomination_id & columns))
qry.Append("denomination_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.denomination_qty == (Columns.denomination_qty & columns))
qry.Append("denomination_qty,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_vault_adjustments_detail ");

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
return new CcmsVaultAdjustmentsDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsVaultAdjustmentsDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsVaultAdjustmentsDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,ccms_vault_adjustments_id,vault_note_type_id,denomination_id,denomination_name,denomination_qty from Ccms_vault_adjustments_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsVaultAdjustmentsDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsVaultAdjustmentsDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsVaultAdjustmentsDetail LoadCcmsVaultAdjustmentsDetail(string where)
{
CcmsVaultAdjustmentsDetailReader reader = CcmsVaultAdjustmentsDetail.ExecuteReader(where);
CcmsVaultAdjustmentsDetail _ccmsvaultadjustmentsdetail = null;
if (reader.Read())
_ccmsvaultadjustmentsdetail = reader.CurrentCcmsVaultAdjustmentsDetail;
reader.Close();
return _ccmsvaultadjustmentsdetail;
}

public static CcmsVaultAdjustmentsDetail LoadCcmsVaultAdjustmentsDetail(string where, IDbConnection conn)
{
CcmsVaultAdjustmentsDetailReader reader = CcmsVaultAdjustmentsDetail.ExecuteReader(where, conn);
CcmsVaultAdjustmentsDetail _ccmsvaultadjustmentsdetail = null;
if (reader.Read())
_ccmsvaultadjustmentsdetail = reader.CurrentCcmsVaultAdjustmentsDetail;
reader.Close(false);
return _ccmsvaultadjustmentsdetail;
}

public static CcmsVaultAdjustmentsDetail LoadCcmsVaultAdjustmentsDetailByPk( int id )
{
return LoadCcmsVaultAdjustmentsDetail( " id="+id );
}

public static CcmsVaultAdjustmentsDetail LoadCcmsVaultAdjustmentsDetailByPk( int id , IDbConnection conn)
{
return LoadCcmsVaultAdjustmentsDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || ccms_vault_adjustments_idChanged || vault_note_type_idChanged || denomination_idChanged || denomination_nameChanged || denomination_qtyChanged )
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
if (idChanged || ccms_vault_adjustments_idChanged || vault_note_type_idChanged || denomination_idChanged || denomination_nameChanged || denomination_qtyChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_vault_adjustments_detail( id,ccms_vault_adjustments_id,vault_note_type_id,denomination_id,denomination_name,denomination_qty ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(ccms_vault_adjustments_idDbString+",");
qry.Append(vault_note_type_idDbString+",");
qry.Append(denomination_idDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(denomination_qtyDbString);
qry.Append(");");

}
else
{
if (!(idChanged || ccms_vault_adjustments_idChanged || vault_note_type_idChanged || denomination_idChanged || denomination_nameChanged || denomination_qtyChanged ))
return;
qry.Append("UPDATE Ccms_vault_adjustments_detail set "); if ( ccms_vault_adjustments_idChanged )
{
qry.Append("ccms_vault_adjustments_id ="+ccms_vault_adjustments_idDbString);
qry.Append(",");
}

if ( vault_note_type_idChanged )
{
qry.Append("vault_note_type_id ="+vault_note_type_idDbString);
qry.Append(",");
}

if ( denomination_idChanged )
{
qry.Append("denomination_id ="+denomination_idDbString);
qry.Append(",");
}

if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( denomination_qtyChanged )
{
qry.Append("denomination_qty ="+denomination_qtyDbString);
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
cmd.CommandText = "DELETE Ccms_vault_adjustments_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsVaultAdjustmentsDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_vault_adjustments_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
ccms_vault_adjustments_id= 2,
vault_note_type_id= 4,
denomination_id= 8,
denomination_name= 16,
denomination_qty= 32
}
#endregion
public void BulkSave(List<CcmsVaultAdjustmentsDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_vault_adjustments_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsVaultAdjustmentsDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsVaultAdjustmentsDetail> transList,ref DataTable dt)
{
foreach (CcmsVaultAdjustmentsDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["ccms_vault_adjustments_id"] = tran.CcmsVaultAdjustmentsId;
Row["vault_note_type_id"] = tran.VaultNoteTypeId;
Row["denomination_id"] = tran.DenominationId;
Row["denomination_name"] = tran.DenominationName;
Row["denomination_qty"] = tran.DenominationQty;
dt.Rows.Add(Row);
} }
}
}
