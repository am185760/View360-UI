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
public class CcmsOrgNoteSetItem
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsOrgNoteSetItem() { }
public CcmsOrgNoteSetItem( int id ) 
{
}
public CcmsOrgNoteSetItem( int? org_note_set_id,int? denomination_id,string denomination_name )
{
this.org_note_set_id = org_note_set_id;
this.org_note_set_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
}
private CcmsOrgNoteSetItem( int id,int? org_note_set_id,int? denomination_id,string denomination_name )
{
this.id = id;
this.idChanged = true;
this.org_note_set_id = org_note_set_id;
this.org_note_set_idChanged = true;
this.denomination_id = denomination_id;
this.denomination_idChanged = true;
this.denomination_name = denomination_name;
this.denomination_nameChanged = true;
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
#region OrgNoteSetId
private bool org_note_set_idChanged = false;
private int? org_note_set_id;
public int? OrgNoteSetId
{
get { return org_note_set_id; }
set { 
org_note_set_id = value;
org_note_set_idChanged = true;
}
}
private string org_note_set_idDbString
{
get
{
if (this.org_note_set_id.HasValue)
return org_note_set_id.ToString();
else
return "null";
}
}
#endregion
#region DenominationId
private bool denomination_idChanged = false;
private int? denomination_id;
public int? DenominationId
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
if (this.denomination_id.HasValue)
return denomination_id.ToString();
else
return "null";
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
#endregion

#region CcmsOrgNoteSetItemReader
public class CcmsOrgNoteSetItemReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsOrgNoteSetItem currentCcmsOrgNoteSetItem;
Columns columns;
bool partialRead = false;
private CcmsOrgNoteSetItemReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsOrgNoteSetItemReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsOrgNoteSetItemReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsOrgNoteSetItem; }

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
currentCcmsOrgNoteSetItem = new CcmsOrgNoteSetItem();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsOrgNoteSetItem.id =(int) reader["id"]; 
if ((columns & Columns.org_note_set_id) == Columns.org_note_set_id && reader["org_note_set_id"]!=DBNull.Value)
currentCcmsOrgNoteSetItem.org_note_set_id =(int?) reader["org_note_set_id"]; 
if ((columns & Columns.denomination_id) == Columns.denomination_id && reader["denomination_id"]!=DBNull.Value)
currentCcmsOrgNoteSetItem.denomination_id =(int?) reader["denomination_id"]; 
if ((columns & Columns.denomination_name) == Columns.denomination_name && reader["denomination_name"]!=DBNull.Value)
currentCcmsOrgNoteSetItem.denomination_name =(string) reader["denomination_name"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsOrgNoteSetItem.id = (int) reader["id"]; 
if (reader["org_note_set_id"] != DBNull.Value)
currentCcmsOrgNoteSetItem.org_note_set_id = (int?) reader["org_note_set_id"]; 
if (reader["denomination_id"] != DBNull.Value)
currentCcmsOrgNoteSetItem.denomination_id = (int?) reader["denomination_id"]; 
if (reader["denomination_name"] != DBNull.Value)
currentCcmsOrgNoteSetItem.denomination_name = (string) reader["denomination_name"]; 
} 

currentCcmsOrgNoteSetItem.isNewEntity = false;
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

public CcmsOrgNoteSetItem CurrentCcmsOrgNoteSetItem
{
get{ return currentCcmsOrgNoteSetItem; }
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


#region CcmsOrgNoteSetItem functions

public static CcmsOrgNoteSetItemReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.org_note_set_id == (Columns.org_note_set_id & columns))
qry.Append("org_note_set_id,");
if (Columns.denomination_id == (Columns.denomination_id & columns))
qry.Append("denomination_id,");
if (Columns.denomination_name == (Columns.denomination_name & columns))
qry.Append("denomination_name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_org_note_set_item ");

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
return new CcmsOrgNoteSetItemReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsOrgNoteSetItemReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsOrgNoteSetItemReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,org_note_set_id,denomination_id,denomination_name from Ccms_org_note_set_item ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsOrgNoteSetItemReader(cmd.ExecuteReader(), conn);
}

static public CcmsOrgNoteSetItemReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsOrgNoteSetItem LoadCcmsOrgNoteSetItem(string where)
{
CcmsOrgNoteSetItemReader reader = CcmsOrgNoteSetItem.ExecuteReader(where);
CcmsOrgNoteSetItem _ccmsorgnotesetitem = null;
if (reader.Read())
_ccmsorgnotesetitem = reader.CurrentCcmsOrgNoteSetItem;
reader.Close();
return _ccmsorgnotesetitem;
}

public static CcmsOrgNoteSetItem LoadCcmsOrgNoteSetItem(string where, IDbConnection conn)
{
CcmsOrgNoteSetItemReader reader = CcmsOrgNoteSetItem.ExecuteReader(where, conn);
CcmsOrgNoteSetItem _ccmsorgnotesetitem = null;
if (reader.Read())
_ccmsorgnotesetitem = reader.CurrentCcmsOrgNoteSetItem;
reader.Close(false);
return _ccmsorgnotesetitem;
}

public static CcmsOrgNoteSetItem LoadCcmsOrgNoteSetItemByPk( int id )
{
return LoadCcmsOrgNoteSetItem( " id="+id );
}

public static CcmsOrgNoteSetItem LoadCcmsOrgNoteSetItemByPk( int id , IDbConnection conn)
{
return LoadCcmsOrgNoteSetItem(" id="+id , conn);
}

public void Save()
{
if (idChanged || org_note_set_idChanged || denomination_idChanged || denomination_nameChanged )
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
if (idChanged || org_note_set_idChanged || denomination_idChanged || denomination_nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_org_note_set_item( id,org_note_set_id,denomination_id,denomination_name ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(org_note_set_idDbString+",");
qry.Append(denomination_idDbString+",");
qry.Append(denomination_nameDbString);
qry.Append(");");

}
else
{
if (!(idChanged || org_note_set_idChanged || denomination_idChanged || denomination_nameChanged ))
return;
qry.Append("UPDATE Ccms_org_note_set_item set "); if ( org_note_set_idChanged )
{
qry.Append("org_note_set_id ="+org_note_set_idDbString);
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
cmd.CommandText = "DELETE Ccms_org_note_set_item where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsOrgNoteSetItems(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_org_note_set_item where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
org_note_set_id= 2,
denomination_id= 4,
denomination_name= 8
}
#endregion
public void BulkSave(List<CcmsOrgNoteSetItem> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_org_note_set_item";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsOrgNoteSetItem.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsOrgNoteSetItem> transList,ref DataTable dt)
{
foreach (CcmsOrgNoteSetItem tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["org_note_set_id"] = tran.OrgNoteSetId;
Row["denomination_id"] = tran.DenominationId;
Row["denomination_name"] = tran.DenominationName;
dt.Rows.Add(Row);
} }
}
}
