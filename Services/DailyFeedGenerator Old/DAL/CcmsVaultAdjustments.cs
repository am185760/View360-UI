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
public class CcmsVaultAdjustments
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsVaultAdjustments() { }
public CcmsVaultAdjustments( int id,int cit_id,int vault_id,decimal amount,int created_by,DateTime created_on,int organization_id,string trxn_type ) 
{
this.cit_id = cit_id;
this.cit_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.trxn_type = trxn_type;
this.trxn_typeChanged = true;
}
public CcmsVaultAdjustments( int cit_id,int vault_id,decimal amount,int created_by,DateTime created_on,int? modified_by,DateTime? modified_on,int organization_id,string trxn_type )
{
this.cit_id = cit_id;
this.cit_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.trxn_type = trxn_type;
this.trxn_typeChanged = true;
}
private CcmsVaultAdjustments( int id,int cit_id,int vault_id,decimal amount,int created_by,DateTime created_on,int? modified_by,DateTime? modified_on,int organization_id,string trxn_type )
{
this.id = id;
this.idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.trxn_type = trxn_type;
this.trxn_typeChanged = true;
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
#region CitId
private bool cit_idChanged = false;
private int cit_id;
public int CitId
{
get { return cit_id; }
set { 
cit_id = value;
cit_idChanged = true;
}
}
private string cit_idDbString
{
get
{
return cit_id.ToString();
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
#region Amount
private bool amountChanged = false;
private decimal amount;
public decimal Amount
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
return amount.ToString();
}
}
#endregion
#region CreatedBy
private bool created_byChanged = false;
private int created_by;
public int CreatedBy
{
get { return created_by; }
set { 
created_by = value;
created_byChanged = true;
}
}
private string created_byDbString
{
get
{
return created_by.ToString();
}
}
#endregion
#region CreatedOn
private bool created_onChanged = false;
private DateTime created_on;
public DateTime CreatedOn
{
get { return created_on; }
set { 
created_on = value;
created_onChanged = true;
}
}
private string created_onDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",created_on.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region ModifiedBy
private bool modified_byChanged = false;
private int? modified_by;
public int? ModifiedBy
{
get { return modified_by; }
set { 
modified_by = value;
modified_byChanged = true;
}
}
private string modified_byDbString
{
get
{
if (this.modified_by.HasValue)
return modified_by.ToString();
else
return "null";
}
}
#endregion
#region ModifiedOn
private bool modified_onChanged = false;
private DateTime? modified_on;
public DateTime? ModifiedOn
{
get { return modified_on; }
set { 
modified_on = value;
modified_onChanged = true;
}
}
private string modified_onDbString
{
get
{
if (this.modified_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region OrganizationId
private bool organization_idChanged = false;
private int organization_id;
public int OrganizationId
{
get { return organization_id; }
set { 
organization_id = value;
organization_idChanged = true;
}
}
private string organization_idDbString
{
get
{
return organization_id.ToString();
}
}
#endregion
#region TrxnType
private bool trxn_typeChanged = false;
private string trxn_type;
public string TrxnType
{
get { return trxn_type; }
set { 
trxn_type = value;
trxn_typeChanged = true;
}
}
private string trxn_typeDbString
{
get
{
if (this.trxn_type!=null)
return string.Format("'{0}'",trxn_type); else
return "null";
}
}
#endregion
#endregion

#region CcmsVaultAdjustmentsReader
public class CcmsVaultAdjustmentsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsVaultAdjustments currentCcmsVaultAdjustments;
Columns columns;
bool partialRead = false;
private CcmsVaultAdjustmentsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsVaultAdjustmentsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsVaultAdjustmentsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsVaultAdjustments; }

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
currentCcmsVaultAdjustments = new CcmsVaultAdjustments();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsVaultAdjustments.id =(int) reader["id"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentCcmsVaultAdjustments.cit_id =(int) reader["cit_id"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsVaultAdjustments.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.amount) == Columns.amount && reader["amount"]!=DBNull.Value)
currentCcmsVaultAdjustments.amount =(decimal) reader["amount"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsVaultAdjustments.created_by =(int) reader["created_by"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsVaultAdjustments.created_on =(DateTime) reader["created_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsVaultAdjustments.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsVaultAdjustments.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsVaultAdjustments.organization_id =(int) reader["organization_id"]; 
if ((columns & Columns.trxn_type) == Columns.trxn_type && reader["trxn_type"]!=DBNull.Value)
currentCcmsVaultAdjustments.trxn_type =(string) reader["trxn_type"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsVaultAdjustments.id = (int) reader["id"]; 
if (reader["cit_id"] != DBNull.Value)
currentCcmsVaultAdjustments.cit_id = (int) reader["cit_id"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsVaultAdjustments.vault_id = (int) reader["vault_id"]; 
if (reader["amount"] != DBNull.Value)
currentCcmsVaultAdjustments.amount = (decimal) reader["amount"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsVaultAdjustments.created_by = (int) reader["created_by"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsVaultAdjustments.created_on = (DateTime) reader["created_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsVaultAdjustments.modified_by = (int?) reader["modified_by"]; 
if (reader["modified_on"] != DBNull.Value)
currentCcmsVaultAdjustments.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsVaultAdjustments.organization_id = (int) reader["organization_id"]; 
if (reader["trxn_type"] != DBNull.Value)
currentCcmsVaultAdjustments.trxn_type = (string) reader["trxn_type"]; 
} 

currentCcmsVaultAdjustments.isNewEntity = false;
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

public CcmsVaultAdjustments CurrentCcmsVaultAdjustments
{
get{ return currentCcmsVaultAdjustments; }
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


#region CcmsVaultAdjustments functions

public static CcmsVaultAdjustmentsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.amount == (Columns.amount & columns))
qry.Append("amount,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.created_on == (Columns.created_on & columns))
qry.Append("created_on,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.modified_on == (Columns.modified_on & columns))
qry.Append("modified_on,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.trxn_type == (Columns.trxn_type & columns))
qry.Append("trxn_type,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_vault_adjustments ");

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
return new CcmsVaultAdjustmentsReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsVaultAdjustmentsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsVaultAdjustmentsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,cit_id,vault_id,amount,created_by,created_on,modified_by,modified_on,organization_id,trxn_type from Ccms_vault_adjustments ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsVaultAdjustmentsReader(cmd.ExecuteReader(), conn);
}

static public CcmsVaultAdjustmentsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsVaultAdjustments LoadCcmsVaultAdjustments(string where)
{
CcmsVaultAdjustmentsReader reader = CcmsVaultAdjustments.ExecuteReader(where);
CcmsVaultAdjustments _ccmsvaultadjustments = null;
if (reader.Read())
_ccmsvaultadjustments = reader.CurrentCcmsVaultAdjustments;
reader.Close();
return _ccmsvaultadjustments;
}

public static CcmsVaultAdjustments LoadCcmsVaultAdjustments(string where, IDbConnection conn)
{
CcmsVaultAdjustmentsReader reader = CcmsVaultAdjustments.ExecuteReader(where, conn);
CcmsVaultAdjustments _ccmsvaultadjustments = null;
if (reader.Read())
_ccmsvaultadjustments = reader.CurrentCcmsVaultAdjustments;
reader.Close(false);
return _ccmsvaultadjustments;
}

public static CcmsVaultAdjustments LoadCcmsVaultAdjustmentsByPk( int id )
{
return LoadCcmsVaultAdjustments( " id="+id );
}

public static CcmsVaultAdjustments LoadCcmsVaultAdjustmentsByPk( int id , IDbConnection conn)
{
return LoadCcmsVaultAdjustments(" id="+id , conn);
}

public void Save()
{
if (idChanged || cit_idChanged || vault_idChanged || amountChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged || trxn_typeChanged )
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
if (idChanged || cit_idChanged || vault_idChanged || amountChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged || trxn_typeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_vault_adjustments( id,cit_id,vault_id,amount,created_by,created_on,modified_by,modified_on,organization_id,trxn_type ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(cit_idDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(amountDbString+",");
qry.Append(created_byDbString+",");
qry.Append(created_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(organization_idDbString+",");
qry.Append(trxn_typeDbString);
qry.Append(");");

}
else
{
if (!(idChanged || cit_idChanged || vault_idChanged || amountChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged || trxn_typeChanged ))
return;
qry.Append("UPDATE Ccms_vault_adjustments set "); if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
qry.Append(",");
}

if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( amountChanged )
{
qry.Append("amount ="+amountDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( created_onChanged )
{
qry.Append("created_on ="+created_onDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( modified_onChanged )
{
qry.Append("modified_on ="+modified_onDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( trxn_typeChanged )
{
qry.Append("trxn_type ="+trxn_typeDbString);
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
cmd.CommandText = "DELETE Ccms_vault_adjustments where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsVaultAdjustmentss(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_vault_adjustments where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
cit_id= 2,
vault_id= 4,
amount= 8,
created_by= 16,
created_on= 32,
modified_by= 64,
modified_on= 128,
organization_id= 256,
trxn_type= 512
}
#endregion
public void BulkSave(List<CcmsVaultAdjustments> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_vault_adjustments";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsVaultAdjustments.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsVaultAdjustments> transList,ref DataTable dt)
{
foreach (CcmsVaultAdjustments tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["cit_id"] = tran.CitId;
Row["vault_id"] = tran.VaultId;
Row["amount"] = tran.Amount;
Row["created_by"] = tran.CreatedBy;
Row["created_on"] = tran.CreatedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["organization_id"] = tran.OrganizationId;
Row["trxn_type"] = tran.TrxnType;
dt.Rows.Add(Row);
} }
}
}
