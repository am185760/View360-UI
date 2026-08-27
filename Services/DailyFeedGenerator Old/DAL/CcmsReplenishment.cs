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
public class CcmsReplenishment
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsReplenishment() { }
public CcmsReplenishment( long id ) 
{
}
public CcmsReplenishment( long? order_id,long? vault_id,string supervisor_name,DateTime? replenishment_date,string status,decimal? no_of_cheque,bool? is_deleted,DateTime? created_on,long? created_by,DateTime? modified_on,long? modified_by,string replenishment_type )
{
this.order_id = order_id;
this.order_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.supervisor_name = supervisor_name;
this.supervisor_nameChanged = true;
this.replenishment_date = replenishment_date;
this.replenishment_dateChanged = true;
this.status = status;
this.statusChanged = true;
this.no_of_cheque = no_of_cheque;
this.no_of_chequeChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.replenishment_type = replenishment_type;
this.replenishment_typeChanged = true;
}
private CcmsReplenishment( long id,long? order_id,long? vault_id,string supervisor_name,DateTime? replenishment_date,string status,decimal? no_of_cheque,bool? is_deleted,DateTime? created_on,long? created_by,DateTime? modified_on,long? modified_by,string replenishment_type )
{
this.id = id;
this.idChanged = true;
this.order_id = order_id;
this.order_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.supervisor_name = supervisor_name;
this.supervisor_nameChanged = true;
this.replenishment_date = replenishment_date;
this.replenishment_dateChanged = true;
this.status = status;
this.statusChanged = true;
this.no_of_cheque = no_of_cheque;
this.no_of_chequeChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.replenishment_type = replenishment_type;
this.replenishment_typeChanged = true;
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
#region VaultId
private bool vault_idChanged = false;
private long? vault_id;
public long? VaultId
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
if (this.vault_id.HasValue)
return vault_id.ToString();
else
return "null";
}
}
#endregion
#region SupervisorName
private bool supervisor_nameChanged = false;
private string supervisor_name;
public string SupervisorName
{
get { return supervisor_name; }
set { 
supervisor_name = value;
supervisor_nameChanged = true;
}
}
private string supervisor_nameDbString
{
get
{
if (this.supervisor_name!=null)
return string.Format("'{0}'",supervisor_name); else
return "null";
}
}
#endregion
#region ReplenishmentDate
private bool replenishment_dateChanged = false;
private DateTime? replenishment_date;
public DateTime? ReplenishmentDate
{
get { return replenishment_date; }
set { 
replenishment_date = value;
replenishment_dateChanged = true;
}
}
private string replenishment_dateDbString
{
get
{
if (this.replenishment_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",replenishment_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region Status
private bool statusChanged = false;
private string status;
public string Status
{
get { return status; }
set { 
status = value;
statusChanged = true;
}
}
private string statusDbString
{
get
{
if (this.status!=null)
return string.Format("'{0}'",status); else
return "null";
}
}
#endregion
#region NoOfCheque
private bool no_of_chequeChanged = false;
private decimal? no_of_cheque;
public decimal? NoOfCheque
{
get { return no_of_cheque; }
set { 
no_of_cheque = value;
no_of_chequeChanged = true;
}
}
private string no_of_chequeDbString
{
get
{
if (this.no_of_cheque.HasValue)
return no_of_cheque.ToString();
else
return "null";
}
}
#endregion
#region IsDeleted
private bool is_deletedChanged = false;
private bool? is_deleted;
public bool? IsDeleted
{
get { return is_deleted; }
set { 
is_deleted = value;
is_deletedChanged = true;
}
}
private string is_deletedDbString
{
get
{
if (this.is_deleted.HasValue)
return is_deleted.Value?"1":"0";
else
return "null";
}
}
#endregion
#region CreatedOn
private bool created_onChanged = false;
private DateTime? created_on;
public DateTime? CreatedOn
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
if (this.created_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",created_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region CreatedBy
private bool created_byChanged = false;
private long? created_by;
public long? CreatedBy
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
if (this.created_by.HasValue)
return created_by.ToString();
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
#region ModifiedBy
private bool modified_byChanged = false;
private long? modified_by;
public long? ModifiedBy
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
#region ReplenishmentType
private bool replenishment_typeChanged = false;
private string replenishment_type;
public string ReplenishmentType
{
get { return replenishment_type; }
set { 
replenishment_type = value;
replenishment_typeChanged = true;
}
}
private string replenishment_typeDbString
{
get
{
if (this.replenishment_type!=null)
return string.Format("'{0}'",replenishment_type); else
return "null";
}
}
#endregion
#endregion

#region CcmsReplenishmentReader
public class CcmsReplenishmentReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsReplenishment currentCcmsReplenishment;
Columns columns;
bool partialRead = false;
private CcmsReplenishmentReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsReplenishmentReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsReplenishmentReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsReplenishment; }

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
currentCcmsReplenishment = new CcmsReplenishment();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsReplenishment.id =(long) reader["id"]; 
if ((columns & Columns.order_id) == Columns.order_id && reader["order_id"]!=DBNull.Value)
currentCcmsReplenishment.order_id =(long?) reader["order_id"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsReplenishment.vault_id =(long?) reader["vault_id"]; 
if ((columns & Columns.supervisor_name) == Columns.supervisor_name && reader["supervisor_name"]!=DBNull.Value)
currentCcmsReplenishment.supervisor_name =(string) reader["supervisor_name"]; 
if ((columns & Columns.replenishment_date) == Columns.replenishment_date && reader["replenishment_date"]!=DBNull.Value)
currentCcmsReplenishment.replenishment_date =(DateTime?) reader["replenishment_date"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentCcmsReplenishment.status =(string) reader["status"]; 
if ((columns & Columns.no_of_cheque) == Columns.no_of_cheque && reader["no_of_cheque"]!=DBNull.Value)
currentCcmsReplenishment.no_of_cheque =(decimal?) reader["no_of_cheque"]; 
if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
currentCcmsReplenishment.is_deleted =(bool?) reader["is_deleted"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsReplenishment.created_on =(DateTime?) reader["created_on"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsReplenishment.created_by =(long?) reader["created_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsReplenishment.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsReplenishment.modified_by =(long?) reader["modified_by"]; 
if ((columns & Columns.replenishment_type) == Columns.replenishment_type && reader["replenishment_type"]!=DBNull.Value)
currentCcmsReplenishment.replenishment_type =(string) reader["replenishment_type"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsReplenishment.id = (long) reader["id"]; 
if (reader["order_id"] != DBNull.Value)
currentCcmsReplenishment.order_id = (long?) reader["order_id"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsReplenishment.vault_id = (long?) reader["vault_id"]; 
if (reader["supervisor_name"] != DBNull.Value)
currentCcmsReplenishment.supervisor_name = (string) reader["supervisor_name"]; 
if (reader["replenishment_date"] != DBNull.Value)
currentCcmsReplenishment.replenishment_date = (DateTime?) reader["replenishment_date"]; 
if (reader["status"] != DBNull.Value)
currentCcmsReplenishment.status = (string) reader["status"]; 
if (reader["no_of_cheque"] != DBNull.Value)
currentCcmsReplenishment.no_of_cheque = (decimal?) reader["no_of_cheque"]; 
if (reader["is_deleted"] != DBNull.Value)
currentCcmsReplenishment.is_deleted = (bool?) reader["is_deleted"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsReplenishment.created_on = (DateTime?) reader["created_on"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsReplenishment.created_by = (long?) reader["created_by"]; 
if (reader["modified_on"] != DBNull.Value)
currentCcmsReplenishment.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsReplenishment.modified_by = (long?) reader["modified_by"]; 
if (reader["replenishment_type"] != DBNull.Value)
currentCcmsReplenishment.replenishment_type = (string) reader["replenishment_type"]; 
} 

currentCcmsReplenishment.isNewEntity = false;
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

public CcmsReplenishment CurrentCcmsReplenishment
{
get{ return currentCcmsReplenishment; }
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


#region CcmsReplenishment functions

public static CcmsReplenishmentReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.order_id == (Columns.order_id & columns))
qry.Append("order_id,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.supervisor_name == (Columns.supervisor_name & columns))
qry.Append("supervisor_name,");
if (Columns.replenishment_date == (Columns.replenishment_date & columns))
qry.Append("replenishment_date,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.no_of_cheque == (Columns.no_of_cheque & columns))
qry.Append("no_of_cheque,");
if (Columns.is_deleted == (Columns.is_deleted & columns))
qry.Append("is_deleted,");
if (Columns.created_on == (Columns.created_on & columns))
qry.Append("created_on,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modified_on == (Columns.modified_on & columns))
qry.Append("modified_on,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.replenishment_type == (Columns.replenishment_type & columns))
qry.Append("replenishment_type,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_replenishment ");

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
return new CcmsReplenishmentReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsReplenishmentReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsReplenishmentReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,order_id,vault_id,supervisor_name,replenishment_date,status,no_of_cheque,is_deleted,created_on,created_by,modified_on,modified_by,replenishment_type from Ccms_replenishment ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsReplenishmentReader(cmd.ExecuteReader(), conn);
}

static public CcmsReplenishmentReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsReplenishment LoadCcmsReplenishment(string where)
{
CcmsReplenishmentReader reader = CcmsReplenishment.ExecuteReader(where);
CcmsReplenishment _ccmsreplenishment = null;
if (reader.Read())
_ccmsreplenishment = reader.CurrentCcmsReplenishment;
reader.Close();
return _ccmsreplenishment;
}

public static CcmsReplenishment LoadCcmsReplenishment(string where, IDbConnection conn)
{
CcmsReplenishmentReader reader = CcmsReplenishment.ExecuteReader(where, conn);
CcmsReplenishment _ccmsreplenishment = null;
if (reader.Read())
_ccmsreplenishment = reader.CurrentCcmsReplenishment;
reader.Close(false);
return _ccmsreplenishment;
}

public static CcmsReplenishment LoadCcmsReplenishmentByPk( long id )
{
return LoadCcmsReplenishment( " id="+id );
}

public static CcmsReplenishment LoadCcmsReplenishmentByPk( long id , IDbConnection conn)
{
return LoadCcmsReplenishment(" id="+id , conn);
}

public void Save()
{
if (idChanged || order_idChanged || vault_idChanged || supervisor_nameChanged || replenishment_dateChanged || statusChanged || no_of_chequeChanged || is_deletedChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || replenishment_typeChanged )
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
if (idChanged || order_idChanged || vault_idChanged || supervisor_nameChanged || replenishment_dateChanged || statusChanged || no_of_chequeChanged || is_deletedChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || replenishment_typeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_replenishment( order_id,vault_id,supervisor_name,replenishment_date,status,no_of_cheque,is_deleted,created_on,created_by,modified_on,modified_by,replenishment_type ) values(");
qry.Append(order_idDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(supervisor_nameDbString+",");
qry.Append(replenishment_dateDbString+",");
qry.Append(statusDbString+",");
qry.Append(no_of_chequeDbString+",");
qry.Append(is_deletedDbString+",");
qry.Append(created_onDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(replenishment_typeDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || order_idChanged || vault_idChanged || supervisor_nameChanged || replenishment_dateChanged || statusChanged || no_of_chequeChanged || is_deletedChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || replenishment_typeChanged ))
return;
qry.Append("UPDATE Ccms_replenishment set "); if ( order_idChanged )
{
qry.Append("order_id ="+order_idDbString);
qry.Append(",");
}

if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( supervisor_nameChanged )
{
qry.Append("supervisor_name ="+supervisor_nameDbString);
qry.Append(",");
}

if ( replenishment_dateChanged )
{
qry.Append("replenishment_date ="+replenishment_dateDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( no_of_chequeChanged )
{
qry.Append("no_of_cheque ="+no_of_chequeDbString);
qry.Append(",");
}

if ( is_deletedChanged )
{
qry.Append("is_deleted ="+is_deletedDbString);
qry.Append(",");
}

if ( created_onChanged )
{
qry.Append("created_on ="+created_onDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( modified_onChanged )
{
qry.Append("modified_on ="+modified_onDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( replenishment_typeChanged )
{
qry.Append("replenishment_type ="+replenishment_typeDbString);
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
cmd.CommandText = "DELETE Ccms_replenishment where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsReplenishments(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_replenishment where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
order_id= 2,
vault_id= 4,
supervisor_name= 8,
replenishment_date= 16,
status= 32,
no_of_cheque= 64,
is_deleted= 128,
created_on= 256,
created_by= 512,
modified_on= 1024,
modified_by= 2048,
replenishment_type= 4096
}
#endregion
public void BulkSave(List<CcmsReplenishment> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_replenishment";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsReplenishment.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsReplenishment> transList,ref DataTable dt)
{
foreach (CcmsReplenishment tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["order_id"] = tran.OrderId;
Row["vault_id"] = tran.VaultId;
Row["supervisor_name"] = tran.SupervisorName;
Row["replenishment_date"] = tran.ReplenishmentDate;
Row["status"] = tran.Status;
Row["no_of_cheque"] = tran.NoOfCheque;
Row["is_deleted"] = tran.IsDeleted;
Row["created_on"] = tran.CreatedOn;
Row["created_by"] = tran.CreatedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["replenishment_type"] = tran.ReplenishmentType;
dt.Rows.Add(Row);
} }
}
}
