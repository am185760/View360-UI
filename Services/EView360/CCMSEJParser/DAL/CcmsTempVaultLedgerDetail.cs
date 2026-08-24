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
public class CcmsTempVaultLedgerDetail
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsTempVaultLedgerDetail() { }
public CcmsTempVaultLedgerDetail( int id,int ledger_id,int quantity,int vault_note_type_id ) 
{
this.id = id;
this.idChanged = true;
this.ledger_id = ledger_id;
this.ledger_idChanged = true;
this.quantity = quantity;
this.quantityChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
}
public CcmsTempVaultLedgerDetail( int id,int ledger_id,int quantity,int vault_note_type_id,int? balance )
{
this.id = id;
this.idChanged = true;
this.ledger_id = ledger_id;
this.ledger_idChanged = true;
this.quantity = quantity;
this.quantityChanged = true;
this.vault_note_type_id = vault_note_type_id;
this.vault_note_type_idChanged = true;
this.balance = balance;
this.balanceChanged = true;
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
#region LedgerId
private bool ledger_idChanged = false;
private int ledger_id;
public int LedgerId
{
get { return ledger_id; }
set { 
ledger_id = value;
ledger_idChanged = true;
}
}
private string ledger_idDbString
{
get
{
return ledger_id.ToString();
}
}
#endregion
#region Quantity
private bool quantityChanged = false;
private int quantity;
public int Quantity
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
return quantity.ToString();
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
#region Balance
private bool balanceChanged = false;
private int? balance;
public int? Balance
{
get { return balance; }
set { 
balance = value;
balanceChanged = true;
}
}
private string balanceDbString
{
get
{
if (this.balance.HasValue)
return balance.ToString();
else
return "null";
}
}
#endregion
#endregion

#region CcmsTempVaultLedgerDetailReader
public class CcmsTempVaultLedgerDetailReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsTempVaultLedgerDetail currentCcmsTempVaultLedgerDetail;
Columns columns;
bool partialRead = false;
private CcmsTempVaultLedgerDetailReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsTempVaultLedgerDetailReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsTempVaultLedgerDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsTempVaultLedgerDetail; }

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
currentCcmsTempVaultLedgerDetail = new CcmsTempVaultLedgerDetail();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsTempVaultLedgerDetail.id =(int) reader["id"]; 
if ((columns & Columns.ledger_id) == Columns.ledger_id && reader["ledger_id"]!=DBNull.Value)
currentCcmsTempVaultLedgerDetail.ledger_id =(int) reader["ledger_id"]; 
if ((columns & Columns.quantity) == Columns.quantity && reader["quantity"]!=DBNull.Value)
currentCcmsTempVaultLedgerDetail.quantity =(int) reader["quantity"]; 
if ((columns & Columns.vault_note_type_id) == Columns.vault_note_type_id && reader["vault_note_type_id"]!=DBNull.Value)
currentCcmsTempVaultLedgerDetail.vault_note_type_id =(int) reader["vault_note_type_id"]; 
if ((columns & Columns.balance) == Columns.balance && reader["balance"]!=DBNull.Value)
currentCcmsTempVaultLedgerDetail.balance =(int?) reader["balance"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsTempVaultLedgerDetail.id = (int) reader["id"]; 
if (reader["ledger_id"] != DBNull.Value)
currentCcmsTempVaultLedgerDetail.ledger_id = (int) reader["ledger_id"]; 
if (reader["quantity"] != DBNull.Value)
currentCcmsTempVaultLedgerDetail.quantity = (int) reader["quantity"]; 
if (reader["vault_note_type_id"] != DBNull.Value)
currentCcmsTempVaultLedgerDetail.vault_note_type_id = (int) reader["vault_note_type_id"]; 
if (reader["balance"] != DBNull.Value)
currentCcmsTempVaultLedgerDetail.balance = (int?) reader["balance"]; 
} 

currentCcmsTempVaultLedgerDetail.isNewEntity = false;
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

public CcmsTempVaultLedgerDetail CurrentCcmsTempVaultLedgerDetail
{
get{ return currentCcmsTempVaultLedgerDetail; }
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


#region CcmsTempVaultLedgerDetail functions

public static CcmsTempVaultLedgerDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.ledger_id == (Columns.ledger_id & columns))
qry.Append("ledger_id,");
if (Columns.quantity == (Columns.quantity & columns))
qry.Append("quantity,");
if (Columns.vault_note_type_id == (Columns.vault_note_type_id & columns))
qry.Append("vault_note_type_id,");
if (Columns.balance == (Columns.balance & columns))
qry.Append("balance,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_temp_vault_ledger_detail ");

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
return new CcmsTempVaultLedgerDetailReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsTempVaultLedgerDetailReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsTempVaultLedgerDetailReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,ledger_id,quantity,vault_note_type_id,balance from Ccms_temp_vault_ledger_detail ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsTempVaultLedgerDetailReader(cmd.ExecuteReader(), conn);
}

static public CcmsTempVaultLedgerDetailReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsTempVaultLedgerDetail LoadCcmsTempVaultLedgerDetail(string where)
{
CcmsTempVaultLedgerDetailReader reader = CcmsTempVaultLedgerDetail.ExecuteReader(where);
CcmsTempVaultLedgerDetail _ccmstempvaultledgerdetail = null;
if (reader.Read())
_ccmstempvaultledgerdetail = reader.CurrentCcmsTempVaultLedgerDetail;
reader.Close();
return _ccmstempvaultledgerdetail;
}

public static CcmsTempVaultLedgerDetail LoadCcmsTempVaultLedgerDetail(string where, IDbConnection conn)
{
CcmsTempVaultLedgerDetailReader reader = CcmsTempVaultLedgerDetail.ExecuteReader(where, conn);
CcmsTempVaultLedgerDetail _ccmstempvaultledgerdetail = null;
if (reader.Read())
_ccmstempvaultledgerdetail = reader.CurrentCcmsTempVaultLedgerDetail;
reader.Close(false);
return _ccmstempvaultledgerdetail;
}

public static CcmsTempVaultLedgerDetail LoadCcmsTempVaultLedgerDetailByPk( int id )
{
return LoadCcmsTempVaultLedgerDetail( " id="+id );
}

public static CcmsTempVaultLedgerDetail LoadCcmsTempVaultLedgerDetailByPk( int id , IDbConnection conn)
{
return LoadCcmsTempVaultLedgerDetail(" id="+id , conn);
}

public void Save()
{
if (idChanged || ledger_idChanged || quantityChanged || vault_note_type_idChanged || balanceChanged )
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
if (idChanged || ledger_idChanged || quantityChanged || vault_note_type_idChanged || balanceChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_temp_vault_ledger_detail( ledger_id,quantity,vault_note_type_id,balance ) values(");
qry.Append(ledger_idDbString+",");
qry.Append(quantityDbString+",");
qry.Append(vault_note_type_idDbString+",");
qry.Append(balanceDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || ledger_idChanged || quantityChanged || vault_note_type_idChanged || balanceChanged ))
return;
qry.Append("UPDATE Ccms_temp_vault_ledger_detail set "); if ( ledger_idChanged )
{
qry.Append("ledger_id ="+ledger_idDbString);
qry.Append(",");
}

if ( quantityChanged )
{
qry.Append("quantity ="+quantityDbString);
qry.Append(",");
}

if ( vault_note_type_idChanged )
{
qry.Append("vault_note_type_id ="+vault_note_type_idDbString);
qry.Append(",");
}

if ( balanceChanged )
{
qry.Append("balance ="+balanceDbString);
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
cmd.CommandText = "DELETE Ccms_temp_vault_ledger_detail where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsTempVaultLedgerDetails(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_temp_vault_ledger_detail where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
ledger_id= 2,
quantity= 4,
vault_note_type_id= 8,
balance= 16
}
#endregion
public void BulkSave(List<CcmsTempVaultLedgerDetail> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_temp_vault_ledger_detail";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsTempVaultLedgerDetail.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsTempVaultLedgerDetail> transList,ref DataTable dt)
{
foreach (CcmsTempVaultLedgerDetail tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] = tran.Id;
Row["ledger_id"] = tran.LedgerId;
Row["quantity"] = tran.Quantity;
Row["vault_note_type_id"] = tran.VaultNoteTypeId;
Row["balance"] = tran.Balance;
dt.Rows.Add(Row);
} }
}
}
