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
public class CcmsInvoiceStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsInvoiceStatus() { }
public CcmsInvoiceStatus( long id,string name )
{
this.id = id;
this.idChanged = true;
this.name = name;
this.nameChanged = true;
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
#region Name
private bool nameChanged = false;
private string name;
public string Name
{
get { return name; }
set { 
name = value;
nameChanged = true;
}
}
private string nameDbString
{
get
{
if (this.name!=null)
return string.Format("'{0}'",name); else
return "null";
}
}
#endregion
#endregion

#region CcmsInvoiceStatusReader
public class CcmsInvoiceStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsInvoiceStatus currentCcmsInvoiceStatus;
Columns columns;
bool partialRead = false;
private CcmsInvoiceStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsInvoiceStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsInvoiceStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsInvoiceStatus; }

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
currentCcmsInvoiceStatus = new CcmsInvoiceStatus();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsInvoiceStatus.id =long.Parse(reader["id"].ToString()); 
if ((columns & Columns.Name) == Columns.Name && reader["Name"]!=DBNull.Value)
currentCcmsInvoiceStatus.name =(string) reader["Name"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsInvoiceStatus.id = (long) reader["id"]; 
if (reader["Name"] != DBNull.Value)
currentCcmsInvoiceStatus.name = (string) reader["Name"]; 
} 

currentCcmsInvoiceStatus.isNewEntity = false;
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

public CcmsInvoiceStatus CurrentCcmsInvoiceStatus
{
get{ return currentCcmsInvoiceStatus; }
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


#region CcmsInvoiceStatus functions

public static CcmsInvoiceStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.Name == (Columns.Name & columns))
qry.Append("Name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_invoice_status ");

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
return new CcmsInvoiceStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsInvoiceStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsInvoiceStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,Name from Ccms_invoice_status ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsInvoiceStatusReader(cmd.ExecuteReader(), conn);
}

static public CcmsInvoiceStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsInvoiceStatus LoadCcmsInvoiceStatus(string where)
{
CcmsInvoiceStatusReader reader = CcmsInvoiceStatus.ExecuteReader(where);
CcmsInvoiceStatus _ccmsinvoicestatus = null;
if (reader.Read())
_ccmsinvoicestatus = reader.CurrentCcmsInvoiceStatus;
reader.Close();
return _ccmsinvoicestatus;
}

public static CcmsInvoiceStatus LoadCcmsInvoiceStatus(string where, IDbConnection conn)
{
CcmsInvoiceStatusReader reader = CcmsInvoiceStatus.ExecuteReader(where, conn);
CcmsInvoiceStatus _ccmsinvoicestatus = null;
if (reader.Read())
_ccmsinvoicestatus = reader.CurrentCcmsInvoiceStatus;
reader.Close(false);
return _ccmsinvoicestatus;
}

public static CcmsInvoiceStatus LoadCcmsInvoiceStatusByPk( long id )
{
return LoadCcmsInvoiceStatus( " id="+id );
}

public static CcmsInvoiceStatus LoadCcmsInvoiceStatusByPk( long id , IDbConnection conn)
{
return LoadCcmsInvoiceStatus(" id="+id , conn);
}

public void Save()
{
if (idChanged || nameChanged )
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
if (idChanged || nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_invoice_status( id,Name ) values(");
qry.Append(idDbString+",");
qry.Append(nameDbString);
qry.Append(");");

}
else
{
if (!(idChanged || nameChanged ))
return;
qry.Append("UPDATE Ccms_invoice_status set "); if ( nameChanged )
{
qry.Append("Name ="+nameDbString);
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
cmd.CommandText = "DELETE Ccms_invoice_status where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsInvoiceStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_invoice_status where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
Name= 2
}
#endregion
public void BulkSave(List<CcmsInvoiceStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_invoice_status";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsInvoiceStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsInvoiceStatus> transList,ref DataTable dt)
{
foreach (CcmsInvoiceStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] = tran.Id;
Row["name"] = tran.Name;
dt.Rows.Add(Row);
} }
}
}
