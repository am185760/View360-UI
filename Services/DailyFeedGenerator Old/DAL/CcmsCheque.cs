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
public class CcmsCheque
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsCheque() { }
public CcmsCheque( int id,string cheque_number,DateTime cheque_date,int cit_id,int vault_id,decimal cheque_amount,int created_by,DateTime created_on,int organization_id ) 
{
this.cheque_number = cheque_number;
this.cheque_numberChanged = true;
this.cheque_date = cheque_date;
this.cheque_dateChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.cheque_amount = cheque_amount;
this.cheque_amountChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
}
public CcmsCheque( string cheque_number,DateTime cheque_date,int cit_id,int vault_id,decimal cheque_amount,int created_by,DateTime created_on,int? modified_by,DateTime? modified_on,int organization_id )
{
this.cheque_number = cheque_number;
this.cheque_numberChanged = true;
this.cheque_date = cheque_date;
this.cheque_dateChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.cheque_amount = cheque_amount;
this.cheque_amountChanged = true;
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
}
private CcmsCheque( int id,string cheque_number,DateTime cheque_date,int cit_id,int vault_id,decimal cheque_amount,int created_by,DateTime created_on,int? modified_by,DateTime? modified_on,int organization_id )
{
this.id = id;
this.idChanged = true;
this.cheque_number = cheque_number;
this.cheque_numberChanged = true;
this.cheque_date = cheque_date;
this.cheque_dateChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.cheque_amount = cheque_amount;
this.cheque_amountChanged = true;
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
private DateTime cheque_date;
public DateTime ChequeDate
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
return string.Format("Convert(datetime,'{0}',121)",cheque_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region ChequeAmount
private bool cheque_amountChanged = false;
private decimal cheque_amount;
public decimal ChequeAmount
{
get { return cheque_amount; }
set { 
cheque_amount = value;
cheque_amountChanged = true;
}
}
private string cheque_amountDbString
{
get
{
return cheque_amount.ToString();
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
#endregion

#region CcmsChequeReader
public class CcmsChequeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsCheque currentCcmsCheque;
Columns columns;
bool partialRead = false;
private CcmsChequeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsChequeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsChequeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsCheque; }

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
currentCcmsCheque = new CcmsCheque();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsCheque.id =(int) reader["id"]; 
if ((columns & Columns.cheque_number) == Columns.cheque_number && reader["cheque_number"]!=DBNull.Value)
currentCcmsCheque.cheque_number =(string) reader["cheque_number"]; 
if ((columns & Columns.cheque_date) == Columns.cheque_date && reader["cheque_date"]!=DBNull.Value)
currentCcmsCheque.cheque_date =(DateTime) reader["cheque_date"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentCcmsCheque.cit_id =(int) reader["cit_id"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentCcmsCheque.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.cheque_amount) == Columns.cheque_amount && reader["cheque_amount"]!=DBNull.Value)
currentCcmsCheque.cheque_amount =(decimal) reader["cheque_amount"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsCheque.created_by =(int) reader["created_by"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsCheque.created_on =(DateTime) reader["created_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsCheque.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsCheque.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsCheque.organization_id =(int) reader["organization_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsCheque.id = (int) reader["id"]; 
if (reader["cheque_number"] != DBNull.Value)
currentCcmsCheque.cheque_number = (string) reader["cheque_number"]; 
if (reader["cheque_date"] != DBNull.Value)
currentCcmsCheque.cheque_date = (DateTime) reader["cheque_date"]; 
if (reader["cit_id"] != DBNull.Value)
currentCcmsCheque.cit_id = (int) reader["cit_id"]; 
if (reader["vault_id"] != DBNull.Value)
currentCcmsCheque.vault_id = (int) reader["vault_id"]; 
if (reader["cheque_amount"] != DBNull.Value)
currentCcmsCheque.cheque_amount = (decimal) reader["cheque_amount"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsCheque.created_by = (int) reader["created_by"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsCheque.created_on = (DateTime) reader["created_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsCheque.modified_by = (int?) reader["modified_by"]; 
if (reader["modified_on"] != DBNull.Value)
currentCcmsCheque.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsCheque.organization_id = (int) reader["organization_id"]; 
} 

currentCcmsCheque.isNewEntity = false;
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

public CcmsCheque CurrentCcmsCheque
{
get{ return currentCcmsCheque; }
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


#region CcmsCheque functions

public static CcmsChequeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.cheque_number == (Columns.cheque_number & columns))
qry.Append("cheque_number,");
if (Columns.cheque_date == (Columns.cheque_date & columns))
qry.Append("cheque_date,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.cheque_amount == (Columns.cheque_amount & columns))
qry.Append("cheque_amount,");
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
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_cheque ");

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
return new CcmsChequeReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsChequeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsChequeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,cheque_number,cheque_date,cit_id,vault_id,cheque_amount,created_by,created_on,modified_by,modified_on,organization_id from Ccms_cheque ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsChequeReader(cmd.ExecuteReader(), conn);
}

static public CcmsChequeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsCheque LoadCcmsCheque(string where)
{
CcmsChequeReader reader = CcmsCheque.ExecuteReader(where);
CcmsCheque _ccmscheque = null;
if (reader.Read())
_ccmscheque = reader.CurrentCcmsCheque;
reader.Close();
return _ccmscheque;
}

public static CcmsCheque LoadCcmsCheque(string where, IDbConnection conn)
{
CcmsChequeReader reader = CcmsCheque.ExecuteReader(where, conn);
CcmsCheque _ccmscheque = null;
if (reader.Read())
_ccmscheque = reader.CurrentCcmsCheque;
reader.Close(false);
return _ccmscheque;
}

public static CcmsCheque LoadCcmsChequeByPk( int id )
{
return LoadCcmsCheque( " id="+id );
}

public static CcmsCheque LoadCcmsChequeByPk( int id , IDbConnection conn)
{
return LoadCcmsCheque(" id="+id , conn);
}

public void Save()
{
if (idChanged || cheque_numberChanged || cheque_dateChanged || cit_idChanged || vault_idChanged || cheque_amountChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged )
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
if (idChanged || cheque_numberChanged || cheque_dateChanged || cit_idChanged || vault_idChanged || cheque_amountChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_cheque( id,cheque_number,cheque_date,cit_id,vault_id,cheque_amount,created_by,created_on,modified_by,modified_on,organization_id ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(cheque_numberDbString+",");
qry.Append(cheque_dateDbString+",");
qry.Append(cit_idDbString+",");
qry.Append(vault_idDbString+",");
qry.Append(cheque_amountDbString+",");
qry.Append(created_byDbString+",");
qry.Append(created_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(organization_idDbString);
qry.Append(");");

}
else
{
if (!(idChanged || cheque_numberChanged || cheque_dateChanged || cit_idChanged || vault_idChanged || cheque_amountChanged || created_byChanged || created_onChanged || modified_byChanged || modified_onChanged || organization_idChanged ))
return;
qry.Append("UPDATE Ccms_cheque set "); if ( cheque_numberChanged )
{
qry.Append("cheque_number ="+cheque_numberDbString);
qry.Append(",");
}

if ( cheque_dateChanged )
{
qry.Append("cheque_date ="+cheque_dateDbString);
qry.Append(",");
}

if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
qry.Append(",");
}

if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( cheque_amountChanged )
{
qry.Append("cheque_amount ="+cheque_amountDbString);
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
cmd.CommandText = "DELETE Ccms_cheque where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsCheques(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_cheque where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
cheque_number= 2,
cheque_date= 4,
cit_id= 8,
vault_id= 16,
cheque_amount= 32,
created_by= 64,
created_on= 128,
modified_by= 256,
modified_on= 512,
organization_id= 1024
}
#endregion
public void BulkSave(List<CcmsCheque> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_cheque";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsCheque.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsCheque> transList,ref DataTable dt)
{
foreach (CcmsCheque tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["cheque_number"] = tran.ChequeNumber;
Row["cheque_date"] = tran.ChequeDate;
Row["cit_id"] = tran.CitId;
Row["vault_id"] = tran.VaultId;
Row["cheque_amount"] = tran.ChequeAmount;
Row["created_by"] = tran.CreatedBy;
Row["created_on"] = tran.CreatedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["organization_id"] = tran.OrganizationId;
dt.Rows.Add(Row);
} }
}
}
