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
public class VaultSettlement
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public VaultSettlement() { }
public VaultSettlement( int vault_id,DateTime generated_at,DateTime vault_summary_date,int uploaded_by,int atm_settlement_info_id )
{
this.vault_id = vault_id;
this.vault_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.vault_summary_date = vault_summary_date;
this.vault_summary_dateChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.atm_settlement_info_id = atm_settlement_info_id;
this.atm_settlement_info_idChanged = true;
}
private VaultSettlement( int vault_settlement_id,int vault_id,DateTime generated_at,DateTime vault_summary_date,int uploaded_by,int atm_settlement_info_id )
{
this.vault_settlement_id = vault_settlement_id;
this.vault_settlement_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
this.vault_summary_date = vault_summary_date;
this.vault_summary_dateChanged = true;
this.uploaded_by = uploaded_by;
this.uploaded_byChanged = true;
this.atm_settlement_info_id = atm_settlement_info_id;
this.atm_settlement_info_idChanged = true;
}

#region members and properties for columns

#region VaultSettlementId
private bool vault_settlement_idChanged = false;
private int vault_settlement_id;
public int VaultSettlementId
{
get { return vault_settlement_id; }
set { 
vault_settlement_id = value;
vault_settlement_idChanged = true;
}
}
private string vault_settlement_idDbString
{
get
{
return vault_settlement_id.ToString();
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
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime generated_at;
public DateTime GeneratedAt
{
get { return generated_at; }
set { 
generated_at = value;
generated_atChanged = true;
}
}
private string generated_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region VaultSummaryDate
private bool vault_summary_dateChanged = false;
private DateTime vault_summary_date;
public DateTime VaultSummaryDate
{
get { return vault_summary_date; }
set { 
vault_summary_date = value;
vault_summary_dateChanged = true;
}
}
private string vault_summary_dateDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",vault_summary_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region UploadedBy
private bool uploaded_byChanged = false;
private int uploaded_by;
public int UploadedBy
{
get { return uploaded_by; }
set { 
uploaded_by = value;
uploaded_byChanged = true;
}
}
private string uploaded_byDbString
{
get
{
return uploaded_by.ToString();
}
}
#endregion
#region AtmSettlementInfoId
private bool atm_settlement_info_idChanged = false;
private int atm_settlement_info_id;
public int AtmSettlementInfoId
{
get { return atm_settlement_info_id; }
set { 
atm_settlement_info_id = value;
atm_settlement_info_idChanged = true;
}
}
private string atm_settlement_info_idDbString
{
get
{
return atm_settlement_info_id.ToString();
}
}
#endregion
#endregion

#region VaultSettlementReader
public class VaultSettlementReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
VaultSettlement currentVaultSettlement;
Columns columns;
bool partialRead = false;
private VaultSettlementReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public VaultSettlementReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public VaultSettlementReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentVaultSettlement; }

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
currentVaultSettlement = new VaultSettlement();
if (partialRead)
{ if ((columns & Columns.vault_settlement_id) == Columns.vault_settlement_id && reader["vault_settlement_id"]!=DBNull.Value)
currentVaultSettlement.vault_settlement_id =(int) reader["vault_settlement_id"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentVaultSettlement.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentVaultSettlement.generated_at =(DateTime) reader["generated_at"]; 
if ((columns & Columns.vault_summary_date) == Columns.vault_summary_date && reader["vault_summary_date"]!=DBNull.Value)
currentVaultSettlement.vault_summary_date =(DateTime) reader["vault_summary_date"]; 
if ((columns & Columns.uploaded_by) == Columns.uploaded_by && reader["uploaded_by"]!=DBNull.Value)
currentVaultSettlement.uploaded_by =(int) reader["uploaded_by"]; 
if ((columns & Columns.atm_settlement_info_id) == Columns.atm_settlement_info_id && reader["atm_settlement_info_id"]!=DBNull.Value)
currentVaultSettlement.atm_settlement_info_id =(int) reader["atm_settlement_info_id"]; 

} else
{
if (reader["vault_settlement_id"] != DBNull.Value)
currentVaultSettlement.vault_settlement_id = (int) reader["vault_settlement_id"]; 
if (reader["vault_id"] != DBNull.Value)
currentVaultSettlement.vault_id = (int) reader["vault_id"]; 
if (reader["generated_at"] != DBNull.Value)
currentVaultSettlement.generated_at = (DateTime) reader["generated_at"]; 
if (reader["vault_summary_date"] != DBNull.Value)
currentVaultSettlement.vault_summary_date = (DateTime) reader["vault_summary_date"]; 
if (reader["uploaded_by"] != DBNull.Value)
currentVaultSettlement.uploaded_by = (int) reader["uploaded_by"]; 
if (reader["atm_settlement_info_id"] != DBNull.Value)
currentVaultSettlement.atm_settlement_info_id = (int) reader["atm_settlement_info_id"]; 
} 

currentVaultSettlement.isNewEntity = false;
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

public VaultSettlement CurrentVaultSettlement
{
get{ return currentVaultSettlement; }
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


#region VaultSettlement functions

public static VaultSettlementReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.vault_settlement_id == (Columns.vault_settlement_id & columns))
qry.Append("vault_settlement_id,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
if (Columns.vault_summary_date == (Columns.vault_summary_date & columns))
qry.Append("vault_summary_date,");
if (Columns.uploaded_by == (Columns.uploaded_by & columns))
qry.Append("uploaded_by,");
if (Columns.atm_settlement_info_id == (Columns.atm_settlement_info_id & columns))
qry.Append("atm_settlement_info_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Vault_settlement ");

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
return new VaultSettlementReader(cmd.ExecuteReader(), conn, columns);
}

static public VaultSettlementReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static VaultSettlementReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select vault_settlement_id,vault_id,generated_at,vault_summary_date,uploaded_by,atm_settlement_info_id from Vault_settlement ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new VaultSettlementReader(cmd.ExecuteReader(), conn);
}

static public VaultSettlementReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static VaultSettlement LoadVaultSettlement(string where)
{
VaultSettlementReader reader = VaultSettlement.ExecuteReader(where);
VaultSettlement _vaultsettlement = null;
if (reader.Read())
_vaultsettlement = reader.CurrentVaultSettlement;
reader.Close();
return _vaultsettlement;
}

public static VaultSettlement LoadVaultSettlement(string where, IDbConnection conn)
{
VaultSettlementReader reader = VaultSettlement.ExecuteReader(where, conn);
VaultSettlement _vaultsettlement = null;
if (reader.Read())
_vaultsettlement = reader.CurrentVaultSettlement;
reader.Close(false);
return _vaultsettlement;
}

public static VaultSettlement LoadVaultSettlementByPk( int vault_settlement_id )
{
return LoadVaultSettlement( " vault_settlement_id="+vault_settlement_id );
}

public static VaultSettlement LoadVaultSettlementByPk( int vault_settlement_id , IDbConnection conn)
{
return LoadVaultSettlement(" vault_settlement_id="+vault_settlement_id , conn);
}

public void Save()
{
if (vault_settlement_idChanged || vault_idChanged || generated_atChanged || vault_summary_dateChanged || uploaded_byChanged || atm_settlement_info_idChanged )
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
if (vault_settlement_idChanged || vault_idChanged || generated_atChanged || vault_summary_dateChanged || uploaded_byChanged || atm_settlement_info_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Vault_settlement( vault_settlement_id,vault_id,generated_at,vault_summary_date,uploaded_by,atm_settlement_info_id ) values(");
lock (ConnectionFactory.connectionString) { this.vault_settlement_id = ConnectionFactory.GetNextId();
qry.Append(this.vault_settlement_id);
} qry.Append(",");
qry.Append(vault_idDbString+",");
qry.Append(generated_atDbString+",");
qry.Append(vault_summary_dateDbString+",");
qry.Append(uploaded_byDbString+",");
qry.Append(atm_settlement_info_idDbString);
qry.Append(");");

}
else
{
if (!(vault_settlement_idChanged || vault_idChanged || generated_atChanged || vault_summary_dateChanged || uploaded_byChanged || atm_settlement_info_idChanged ))
return;
qry.Append("UPDATE Vault_settlement set "); if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}

if ( vault_summary_dateChanged )
{
qry.Append("vault_summary_date ="+vault_summary_dateDbString);
qry.Append(",");
}

if ( uploaded_byChanged )
{
qry.Append("uploaded_by ="+uploaded_byDbString);
qry.Append(",");
}

if ( atm_settlement_info_idChanged )
{
qry.Append("atm_settlement_info_id ="+atm_settlement_info_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("vault_settlement_id = "+vault_settlement_idDbString);
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
cmd.CommandText = "DELETE Vault_settlement where vault_settlement_id = "+ vault_settlement_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteVaultSettlements(string where)
{
ConnectionFactory.ExecuteQuery("delete Vault_settlement where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
vault_settlement_id= 1,
vault_id= 2,
generated_at= 4,
vault_summary_date= 8,
uploaded_by= 16,
atm_settlement_info_id= 32
}
#endregion
public void BulkSave(List<VaultSettlement> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Vault_settlement";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(VaultSettlement.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <VaultSettlement> transList,ref DataTable dt)
{
foreach (VaultSettlement tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["vault_settlement_id"] =ConnectionFactory.GetNextId();
Row["vault_id"] = tran.VaultId;
Row["generated_at"] = tran.GeneratedAt;
Row["vault_summary_date"] = tran.VaultSummaryDate;
Row["uploaded_by"] = tran.UploadedBy;
Row["atm_settlement_info_id"] = tran.AtmSettlementInfoId;
dt.Rows.Add(Row);
} }
}
}
