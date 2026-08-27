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
public class CcmsVaultNoteType
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsVaultNoteType() { }
public CcmsVaultNoteType( int vault_id,int denomination_id,int thrashold_qty,string denomination_name,int emergency_cash )
{
this.vault_id = vault_id;
this.vault_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.thrashold_qty = thrashold_qty;
this.thrashold_qtyChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.emergency_cash = emergency_cash;
this.emergency_cashChanged = true;
}
private CcmsVaultNoteType( int id,int vault_id,int denomination_id,int thrashold_qty,string denomination_name,int emergency_cash )
{
this.id = id;
this.idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.thrashold_qty = thrashold_qty;
this.thrashold_qtyChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
this.emergency_cash = emergency_cash;
this.emergency_cashChanged = true;
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
#region VaultId
private bool vault_idChanged = false;
private int vault_id;
public int VaultId
{
get { return vault_id; }
set { 
vault_id = value;
vault_idChanged = true;
}
}
private string vault_idDbString
{
get
{
return vault_id.ToString();
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
#region ThrasholdQty
private bool thrashold_qtyChanged = false;
private int thrashold_qty;
public int ThrasholdQty
{
get { return thrashold_qty; }
set { 
thrashold_qty = value;
thrashold_qtyChanged = true;
}
}
private string thrashold_qtyDbString
{
get
{
return thrashold_qty.ToString();
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
#region EmergencyCash
private bool emergency_cashChanged = false;
private int emergency_cash;
public int EmergencyCash
{
get { return emergency_cash; }
set { 
emergency_cash = value;
emergency_cashChanged = true;
}
}
private string emergency_cashDbString
{
get
{
return emergency_cash.ToString();
}
}
#endregion
#endregion

#region CcmsVaultNoteTypeReader
public class CcmsVaultNoteTypeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsVaultNoteType currentCcmsVaultNoteType;
Columns columns;
bool partialRead = false;
private CcmsVaultNoteTypeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsVaultNoteTypeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsVaultNoteTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsVaultNoteType; }

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
currentCcmsVaultNoteType = new CcmsVaultNoteType();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsVaultNoteType.id =(int) reader["id"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsVaultNoteType.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.denomination_id) == Columns.denomination_id && reader["denomination_id"]!=DBNull.Value)
currentCcmsVaultNoteType.denomination_id =(int) reader["denomination_id"]; 
if ((columns & Columns.thrashold_qty) == Columns.thrashold_qty && reader["thrashold_qty"]!=DBNull.Value)
currentCcmsVaultNoteType.thrashold_qty =(int) reader["thrashold_qty"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsVaultNoteType.denomination_name =(string) reader["denomination_name"]; 
if ((columns & Columns.emergency_cash) == Columns.emergency_cash && reader["emergency_cash"]!=DBNull.Value)
currentCcmsVaultNoteType.emergency_cash =(int) reader["emergency_cash"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsVaultNoteType.id = (int) reader["id"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsVaultNoteType.vault_id = (int) reader["vault_id"]; 
if (reader["denomination_id"] != DBNull.Value)
currentCcmsVaultNoteType.denomination_id = (int) reader["denomination_id"]; 
if (reader["thrashold_qty"] != DBNull.Value)
currentCcmsVaultNoteType.thrashold_qty = (int) reader["thrashold_qty"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsVaultNoteType.denomination_name = (string) reader["denomination_name"]; 
if (reader["emergency_cash"] != DBNull.Value)
currentCcmsVaultNoteType.emergency_cash = (int) reader["emergency_cash"]; 
} 

currentCcmsVaultNoteType.isNewEntity = false;
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

public CcmsVaultNoteType CurrentCcmsVaultNoteType
{
get{ return currentCcmsVaultNoteType; }
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


#region CcmsVaultNoteType functions

public static CcmsVaultNoteTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.denomination_id == (Columns.denomination_id & columns))
qry.Append("denomination_id,");
if (Columns.thrashold_qty == (Columns.thrashold_qty & columns))
qry.Append("thrashold_qty,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
if (Columns.emergency_cash == (Columns.emergency_cash & columns))
qry.Append("emergency_cash,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_vault_note_type ");

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
return new CcmsVaultNoteTypeReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsVaultNoteTypeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsVaultNoteTypeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,vault_id,denomination_id,thrashold_qty,denomination_name,emergency_cash from Ccms_vault_note_type ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsVaultNoteTypeReader(cmd.ExecuteReader(), conn);
}

static public CcmsVaultNoteTypeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsVaultNoteType LoadCcmsVaultNoteType(string where)
{
CcmsVaultNoteTypeReader reader = CcmsVaultNoteType.ExecuteReader(where);
CcmsVaultNoteType _ccmsvaultnotetype = null;
if (reader.Read())
_ccmsvaultnotetype = reader.CurrentCcmsVaultNoteType;
reader.Close();
return _ccmsvaultnotetype;
}

public static CcmsVaultNoteType LoadCcmsVaultNoteType(string where, IDbConnection conn)
{
CcmsVaultNoteTypeReader reader = CcmsVaultNoteType.ExecuteReader(where, conn);
CcmsVaultNoteType _ccmsvaultnotetype = null;
if (reader.Read())
_ccmsvaultnotetype = reader.CurrentCcmsVaultNoteType;
reader.Close(false);
return _ccmsvaultnotetype;
}

public static CcmsVaultNoteType LoadCcmsVaultNoteTypeByPk( int id )
{
return LoadCcmsVaultNoteType( " id="+id );
}

public static CcmsVaultNoteType LoadCcmsVaultNoteTypeByPk( int id , IDbConnection conn)
{
return LoadCcmsVaultNoteType(" id="+id , conn);
}

public void Save()
{
if (idChanged || vault_idChanged || denomination_idChanged || thrashold_qtyChanged || denomination_nameChanged || emergency_cashChanged )
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
if (idChanged || vault_idChanged || denomination_idChanged || thrashold_qtyChanged || denomination_nameChanged || emergency_cashChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_vault_note_type( id,vault_id,denomination_id,thrashold_qty,denomination_name,emergency_cash ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(vault_idDbString+",");
qry.Append(denomination_idDbString+",");
qry.Append(thrashold_qtyDbString+",");
qry.Append(denomination_nameDbString+",");
qry.Append(emergency_cashDbString);
qry.Append(");");

}
else
{
if (!(idChanged || vault_idChanged || denomination_idChanged || thrashold_qtyChanged || denomination_nameChanged || emergency_cashChanged ))
return;
qry.Append("UPDATE Ccms_vault_note_type set "); if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( denomination_idChanged )
{
qry.Append("denomination_id ="+denomination_idDbString);
qry.Append(",");
}

if ( thrashold_qtyChanged )
{
qry.Append("thrashold_qty ="+thrashold_qtyDbString);
qry.Append(",");
}

if ( denomination_nameChanged )
{
qry.Append("denomination_name ="+denomination_nameDbString);
qry.Append(",");
}

if ( emergency_cashChanged )
{
qry.Append("emergency_cash ="+emergency_cashDbString);
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
cmd.CommandText = "DELETE Ccms_vault_note_type where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsVaultNoteTypes(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_vault_note_type where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
vault_id= 2,
denomination_id= 4,
thrashold_qty= 8,
denomination_name= 16,
emergency_cash= 32
}
#endregion
public void BulkSave(List<CcmsVaultNoteType> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_vault_note_type";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsVaultNoteType.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsVaultNoteType> transList,ref DataTable dt)
{
foreach (CcmsVaultNoteType tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["vault_id"] = tran.VaultId;
Row["denomination_id"] = tran.DenominationId;
Row["thrashold_qty"] = tran.ThrasholdQty;
Row["denomination_name"] = tran.DenominationName;
Row["emergency_cash"] = tran.EmergencyCash;
dt.Rows.Add(Row);
} }
}
}
