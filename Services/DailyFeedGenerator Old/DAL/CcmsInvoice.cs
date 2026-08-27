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
public class CcmsInvoice
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsInvoice() { }
public CcmsInvoice( int id,DateTime invoice_date ) 
{
this.invoice_date = invoice_date;
this.invoice_dateChanged = true;
}
public CcmsInvoice( string code,int? cit_id,decimal? amount,string status,string cheque_number,DateTime? cheque_date,bool? is_deleted,DateTime? created_on,int? created_by,DateTime? modified_on,int? modified_by,int? organization_id,string remarks,DateTime invoice_date )
{
this.code = code;
this.codeChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.status = status;
this.statusChanged = true;
this.cheque_number = cheque_number;
this.cheque_numberChanged = true;
this.cheque_date = cheque_date;
this.cheque_dateChanged = true;
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
this.organization_id = organization_id;
this.organization_idChanged = true;
this.remarks = remarks;
this.remarksChanged = true;
this.invoice_date = invoice_date;
this.invoice_dateChanged = true;
}
private CcmsInvoice( int id,string code,int? cit_id,decimal? amount,string status,string cheque_number,DateTime? cheque_date,bool? is_deleted,DateTime? created_on,int? created_by,DateTime? modified_on,int? modified_by,int? organization_id,string remarks,DateTime invoice_date )
{
this.id = id;
this.idChanged = true;
this.code = code;
this.codeChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.status = status;
this.statusChanged = true;
this.cheque_number = cheque_number;
this.cheque_numberChanged = true;
this.cheque_date = cheque_date;
this.cheque_dateChanged = true;
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
this.organization_id = organization_id;
this.organization_idChanged = true;
this.remarks = remarks;
this.remarksChanged = true;
this.invoice_date = invoice_date;
this.invoice_dateChanged = true;
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
#region Code
private bool codeChanged = false;
private string code;
public string Code
{
get { return code; }
set { 
code = value;
codeChanged = true;
}
}
private string codeDbString
{
get
{
if (this.code!=null)
return string.Format("'{0}'",code); else
return "null";
}
}
#endregion
#region CitId
private bool cit_idChanged = false;
private int? cit_id;
public int? CitId
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
if (this.cit_id.HasValue)
return cit_id.ToString();
else
return "null";
}
}
#endregion
#region Amount
private bool amountChanged = false;
private decimal? amount;
public decimal? Amount
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
if (this.amount.HasValue)
return amount.ToString();
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
#region ChequeNumber
private bool cheque_numberChanged = false;
private string cheque_number;
public string ChequeNumber
{
get { return cheque_number; }
set { 
cheque_number = value;
cheque_numberChanged = true;
}
}
private string cheque_numberDbString
{
get
{
if (this.cheque_number!=null)
return string.Format("'{0}'",cheque_number); else
return "null";
}
}
#endregion
#region ChequeDate
private bool cheque_dateChanged = false;
private DateTime? cheque_date;
public DateTime? ChequeDate
{
get { return cheque_date; }
set { 
cheque_date = value;
cheque_dateChanged = true;
}
}
private string cheque_dateDbString
{
get
{
if (this.cheque_date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",cheque_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
private int? created_by;
public int? CreatedBy
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
#region OrganizationId
private bool organization_idChanged = false;
private int? organization_id;
public int? OrganizationId
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
if (this.organization_id.HasValue)
return organization_id.ToString();
else
return "null";
}
}
#endregion
#region Remarks
private bool remarksChanged = false;
private string remarks;
public string Remarks
{
get { return remarks; }
set { 
remarks = value;
remarksChanged = true;
}
}
private string remarksDbString
{
get
{
if (this.remarks!=null)
return string.Format("'{0}'",remarks); else
return "null";
}
}
#endregion
#region InvoiceDate
private bool invoice_dateChanged = false;
private DateTime invoice_date;
public DateTime InvoiceDate
{
get { return invoice_date; }
set { 
invoice_date = value;
invoice_dateChanged = true;
}
}
private string invoice_dateDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",invoice_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region CcmsInvoiceReader
public class CcmsInvoiceReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsInvoice currentCcmsInvoice;
Columns columns;
bool partialRead = false;
private CcmsInvoiceReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsInvoiceReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsInvoiceReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsInvoice; }

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
currentCcmsInvoice = new CcmsInvoice();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsInvoice.id =(int) reader["id"]; 
if ((columns & Columns.code) == Columns.code && reader["code"]!=DBNull.Value)
currentCcmsInvoice.code =(string) reader["code"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentCcmsInvoice.cit_id =(int?) reader["cit_id"]; 
if ((columns & Columns.amount) == Columns.amount && reader["amount"]!=DBNull.Value)
currentCcmsInvoice.amount =(decimal?) reader["amount"]; 
if ((columns & Columns.Status) == Columns.Status && reader["Status"]!=DBNull.Value)
currentCcmsInvoice.status =(string) reader["Status"]; 
if ((columns & Columns.cheque_number) == Columns.cheque_number && reader["cheque_number"]!=DBNull.Value)
currentCcmsInvoice.cheque_number =(string) reader["cheque_number"]; 
if ((columns & Columns.cheque_date) == Columns.cheque_date && reader["cheque_date"]!=DBNull.Value)
currentCcmsInvoice.cheque_date =(DateTime?) reader["cheque_date"]; 
if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
currentCcmsInvoice.is_deleted =(bool?) reader["is_deleted"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsInvoice.created_on =(DateTime?) reader["created_on"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsInvoice.created_by =(int?) reader["created_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsInvoice.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsInvoice.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.Organization_id) == Columns.Organization_id && reader["Organization_id"]!=DBNull.Value)
currentCcmsInvoice.organization_id =(int?) reader["Organization_id"]; 
if ((columns & Columns.Remarks) == Columns.Remarks && reader["Remarks"]!=DBNull.Value)
currentCcmsInvoice.remarks =(string) reader["Remarks"]; 
if ((columns & Columns.invoice_date) == Columns.invoice_date && reader["invoice_date"]!=DBNull.Value)
currentCcmsInvoice.invoice_date =(DateTime) reader["invoice_date"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsInvoice.id = (int) reader["id"]; 
if (reader["code"] != DBNull.Value)
currentCcmsInvoice.code = (string) reader["code"]; 
if (reader["cit_id"] != DBNull.Value)
currentCcmsInvoice.cit_id = (int?) reader["cit_id"]; 
if (reader["amount"] != DBNull.Value)
currentCcmsInvoice.amount = (decimal?) reader["amount"]; 
if (reader["Status"] != DBNull.Value)
currentCcmsInvoice.status = (string) reader["Status"]; 
if (reader["cheque_number"] != DBNull.Value)
currentCcmsInvoice.cheque_number = (string) reader["cheque_number"]; 
if (reader["cheque_date"] != DBNull.Value)
currentCcmsInvoice.cheque_date = (DateTime?) reader["cheque_date"]; 
if (reader["is_deleted"] != DBNull.Value)
currentCcmsInvoice.is_deleted = (bool?) reader["is_deleted"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsInvoice.created_on = (DateTime?) reader["created_on"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsInvoice.created_by = (int?) reader["created_by"]; 
if (reader["modified_on"] != DBNull.Value)
currentCcmsInvoice.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsInvoice.modified_by = (int?) reader["modified_by"]; 
if (reader["Organization_id"] != DBNull.Value)
currentCcmsInvoice.organization_id = (int?) reader["Organization_id"]; 
if (reader["Remarks"] != DBNull.Value)
currentCcmsInvoice.remarks = (string) reader["Remarks"]; 
if (reader["invoice_date"] != DBNull.Value)
currentCcmsInvoice.invoice_date = (DateTime) reader["invoice_date"]; 
} 

currentCcmsInvoice.isNewEntity = false;
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

public CcmsInvoice CurrentCcmsInvoice
{
get{ return currentCcmsInvoice; }
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


#region CcmsInvoice functions

public static CcmsInvoiceReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.code == (Columns.code & columns))
qry.Append("code,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
if (Columns.amount == (Columns.amount & columns))
qry.Append("amount,");
if (Columns.Status == (Columns.Status & columns))
qry.Append("Status,");
if (Columns.cheque_number == (Columns.cheque_number & columns))
qry.Append("cheque_number,");
if (Columns.cheque_date == (Columns.cheque_date & columns))
qry.Append("cheque_date,");
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
if (Columns.Organization_id == (Columns.Organization_id & columns))
qry.Append("Organization_id,");
if (Columns.Remarks == (Columns.Remarks & columns))
qry.Append("Remarks,");
if (Columns.invoice_date == (Columns.invoice_date & columns))
qry.Append("invoice_date,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_invoice ");

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
return new CcmsInvoiceReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsInvoiceReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsInvoiceReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,code,cit_id,amount,Status,cheque_number,cheque_date,is_deleted,created_on,created_by,modified_on,modified_by,Organization_id,Remarks,invoice_date from Ccms_invoice ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsInvoiceReader(cmd.ExecuteReader(), conn);
}

static public CcmsInvoiceReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsInvoice LoadCcmsInvoice(string where)
{
CcmsInvoiceReader reader = CcmsInvoice.ExecuteReader(where);
CcmsInvoice _ccmsinvoice = null;
if (reader.Read())
_ccmsinvoice = reader.CurrentCcmsInvoice;
reader.Close();
return _ccmsinvoice;
}

public static CcmsInvoice LoadCcmsInvoice(string where, IDbConnection conn)
{
CcmsInvoiceReader reader = CcmsInvoice.ExecuteReader(where, conn);
CcmsInvoice _ccmsinvoice = null;
if (reader.Read())
_ccmsinvoice = reader.CurrentCcmsInvoice;
reader.Close(false);
return _ccmsinvoice;
}

public static CcmsInvoice LoadCcmsInvoiceByPk( int id )
{
return LoadCcmsInvoice( " id="+id );
}

public static CcmsInvoice LoadCcmsInvoiceByPk( int id , IDbConnection conn)
{
return LoadCcmsInvoice(" id="+id , conn);
}

public void Save()
{
if (idChanged || codeChanged || cit_idChanged || amountChanged || statusChanged || cheque_numberChanged || cheque_dateChanged || is_deletedChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || organization_idChanged || remarksChanged || invoice_dateChanged )
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
if (idChanged || codeChanged || cit_idChanged || amountChanged || statusChanged || cheque_numberChanged || cheque_dateChanged || is_deletedChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || organization_idChanged || remarksChanged || invoice_dateChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_invoice( id,code,cit_id,amount,Status,cheque_number,cheque_date,is_deleted,created_on,created_by,modified_on,modified_by,Organization_id,Remarks,invoice_date ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(codeDbString+",");
qry.Append(cit_idDbString+",");
qry.Append(amountDbString+",");
qry.Append(statusDbString+",");
qry.Append(cheque_numberDbString+",");
qry.Append(cheque_dateDbString+",");
qry.Append(is_deletedDbString+",");
qry.Append(created_onDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(organization_idDbString+",");
qry.Append(remarksDbString+",");
qry.Append(invoice_dateDbString);
qry.Append(");");

}
else
{
if (!(idChanged || codeChanged || cit_idChanged || amountChanged || statusChanged || cheque_numberChanged || cheque_dateChanged || is_deletedChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || organization_idChanged || remarksChanged || invoice_dateChanged ))
return;
qry.Append("UPDATE Ccms_invoice set "); if ( codeChanged )
{
qry.Append("code ="+codeDbString);
qry.Append(",");
}

if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
qry.Append(",");
}

if ( amountChanged )
{
qry.Append("amount ="+amountDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("Status ="+statusDbString);
qry.Append(",");
}

if ( cheque_numberChanged )
{
qry.Append("cheque_number ="+cheque_numberDbString);
qry.Append(",");
}

if ( cheque_dateChanged )
{
qry.Append("cheque_date ="+cheque_dateDbString);
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

if ( organization_idChanged )
{
qry.Append("Organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( remarksChanged )
{
qry.Append("Remarks ="+remarksDbString);
qry.Append(",");
}

if ( invoice_dateChanged )
{
qry.Append("invoice_date ="+invoice_dateDbString);
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
cmd.CommandText = "DELETE Ccms_invoice where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsInvoices(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_invoice where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
code= 2,
cit_id= 4,
amount= 8,
Status= 16,
cheque_number= 32,
cheque_date= 64,
is_deleted= 128,
created_on= 256,
created_by= 512,
modified_on= 1024,
modified_by= 2048,
Organization_id= 4096,
Remarks= 8192,
invoice_date= 16384
}
#endregion
public void BulkSave(List<CcmsInvoice> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_invoice";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsInvoice.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsInvoice> transList,ref DataTable dt)
{
foreach (CcmsInvoice tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["code"] = tran.Code;
Row["cit_id"] = tran.CitId;
Row["amount"] = tran.Amount;
Row["status"] = tran.Status;
Row["cheque_number"] = tran.ChequeNumber;
Row["cheque_date"] = tran.ChequeDate;
Row["is_deleted"] = tran.IsDeleted;
Row["created_on"] = tran.CreatedOn;
Row["created_by"] = tran.CreatedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["organization_id"] = tran.OrganizationId;
Row["remarks"] = tran.Remarks;
Row["invoice_date"] = tran.InvoiceDate;
dt.Rows.Add(Row);
} }
}
}
