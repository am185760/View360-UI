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
public class CcmsChequeDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsChequeDetail() { }
public CcmsChequeDetail( int cheque_id,int vault_note_type_id,int denomination_id,string denomination_name,int denomination_qty )
{
this.cheque_id = cheque_id;
this.cheque_idChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.denomination_qty = denomination_qty;
this.denomination_qtyChanged = true;
}
private CcmsChequeDetail( int id,int cheque_id,int vault_note_type_id,int denomination_id,string denomination_name,int denomination_qty )
{
this.id = id;
this.idChanged = true;
this.cheque_id = cheque_id;
this.cheque_idChanged = true;
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
#region ChequeId
private bool cheque_idChanged = false;
private int cheque_id;
public int ChequeId
{
get { return cheque_id; }
set { 
cheque_id = value;
cheque_idChanged = true;
}
}
private string cheque_idDbString
{
get
{
return cheque_id.ToString();
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

#region CcmsChequeDetailReader
public class CcmsChequeDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsChequeDetail currentCcmsChequeDetail;
Columns columns;
bool partialRead = false;
private CcmsChequeDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsChequeDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsChequeDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsChequeDetail; }

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
currentCcmsChequeDetail = new CcmsChequeDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsChequeDetail.id =(int) reader["id"]; 
if ((columns & Columns.cheque_id) == Columns.cheque_id && reader["cheque_id"]!=DBNull.Value)
currentCcmsChequeDetail.cheque_id =(int) reader["cheque_id"]; 
if ((columns & Columns.vault_note_type_id) == Columns.vault_note_type_id && reader["vault_note_type_id"]!=DBNull.Value)
currentCcmsChequeDetail.vault_note_type_id =(int) reader["vault_note_type_id"]; 
if ((columns & Columns.denomination_id) == Columns.denomination_id && reader["denomination_id"]!=DBNull.Value)
currentCcmsChequeDetail.denomination_id =(int) reader["denomination_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsChequeDetail.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.denomination_qty) == Columns.denomination_qty && reader["denomination_qty"]!=DBNull.Value)
currentCcmsChequeDetail.denomination_qty =(int) reader["denomination_qty"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsChequeDetail.id = (int) reader["id"]; 
if (reader["cheque_id"] != DBNull.Value)
currentCcmsChequeDetail.cheque_id = (int) reader["cheque_id"]; 
if (reader["vault_note_type_id"] != DBNull.Value)
currentCcmsChequeDetail.vault_note_type_id = (int) reader["vault_note_type_id"]; 
if (reader["denomination_id"] != DBNull.Value)
currentCcmsChequeDetail.denomination_id = (int) reader["denomination_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsChequeDetail.denomination_name = (string) reader["denomination_name"]; 
if (reader["denomination_qty"] != DBNull.Value)
currentCcmsChequeDetail.denomination_qty = (int) reader["denomination_qty"]; 
} 

currentCcmsChequeDetail.isNewEntity = false;
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

public CcmsChequeDetail CurrentCcmsChequeDetail
{
get{ return currentCcmsChequeDetail; }
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


#region CcmsChequeDetail functions

public static CcmsChequeDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.cheque_id == (Columns.cheque_id & columns))
qry.Append("cheque_id,");
if (Columns.vault_note_type_id == (Columns.vault_note_type_id & columns))
qry.Append("vault_note_type_id,");
if (Columns.denomination_id == (Columns.denomination_id & columns))
qry.Append("denomination_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.denomination_qty == (Columns.denomination_qty & columns))
qry.Append("denomination_qty,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_cheque_detail ");

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
return new CcmsChequeDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsChequeDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsChequeDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,cheque_id,vault_note_type_id,denomination_id,denomination_name,denomination_qty from Ccms_cheque_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsChequeDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsChequeDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsChequeDetail LoadCcmsChequeDetail(string where)
{
CcmsChequeDetailReader reader = CcmsChequeDetail.ExecuteReader(where);
CcmsChequeDetail _ccmschequedetail = null;
if (reader.Read())
_ccmschequedetail = reader.CurrentCcmsChequeDetail;
reader.Close();
return _ccmschequedetail;
}

public static CcmsChequeDetail LoadCcmsChequeDetail(string where, IDbConnection conn)
{
CcmsChequeDetailReader reader = CcmsChequeDetail.ExecuteReader(where, conn);
CcmsChequeDetail _ccmschequedetail = null;
if (reader.Read())
_ccmschequedetail = reader.CurrentCcmsChequeDetail;
reader.Close(false);
return _ccmschequedetail;
}

public static CcmsChequeDetail LoadCcmsChequeDetailByPk( int id )
{
return LoadCcmsChequeDetail( " id="+id );
}

public static CcmsChequeDetail LoadCcmsChequeDetailByPk( int id , IDbConnection conn)
{
return LoadCcmsChequeDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || cheque_idChanged || vault_note_type_idChanged || denomination_idChanged || denomination_nameChanged || denomination_qtyChanged )
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
if (idChanged || cheque_idChanged || vault_note_type_idChanged || denomination_idChanged || denomination_nameChanged || denomination_qtyChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_cheque_detail( id,cheque_id,vault_note_type_id,denomination_id,denomination_name,denomination_qty ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(cheque_idDbString+",");
qry.Append(vault_note_type_idDbString+",");
qry.Append(denomination_idDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(denomination_qtyDbString);
qry.Append(");");

}
else
{
if (!(idChanged || cheque_idChanged || vault_note_type_idChanged || denomination_idChanged || denomination_nameChanged || denomination_qtyChanged ))
return;
qry.Append("UPDATE Ccms_cheque_detail set "); if ( cheque_idChanged )
{
qry.Append("cheque_id ="+cheque_idDbString);
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
cmd.CommandText = "DELETE Ccms_cheque_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsChequeDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_cheque_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
cheque_id= 2,
vault_note_type_id= 4,
denomination_id= 8,
denomination_name= 16,
denomination_qty= 32
}
#endregion
public void BulkSave(List<CcmsChequeDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_cheque_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsChequeDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsChequeDetail> transList,ref DataTable dt)
{
foreach (CcmsChequeDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["cheque_id"] = tran.ChequeId;
Row["vault_note_type_id"] = tran.VaultNoteTypeId;
Row["denomination_id"] = tran.DenominationId;
Row["denomination_name"] = tran.DenominationName;
Row["denomination_qty"] = tran.DenominationQty;
dt.Rows.Add(Row);
} }
}
}
