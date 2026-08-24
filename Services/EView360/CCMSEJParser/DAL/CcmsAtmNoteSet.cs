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
public class CcmsAtmNoteSet
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsAtmNoteSet() { }
public CcmsAtmNoteSet( int id ) 
{
}
public CcmsAtmNoteSet( int? atm_id,int? org_note_set_id )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.org_note_set_id = org_note_set_id;
this.org_note_set_idChanged = true;
}
private CcmsAtmNoteSet( int id,int? atm_id,int? org_note_set_id )
{
this.id = id;
this.idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.org_note_set_id = org_note_set_id;
this.org_note_set_idChanged = true;
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
#region AtmId
private bool atm_idChanged = false;
private int? atm_id;
public int? AtmId
{
get { return atm_id; }
set { 
atm_id = value;
atm_idChanged = true;
}
}
private string atm_idDbString
{
get
{
if (this.atm_id.HasValue)
return atm_id.ToString();
else
return "null";
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
#endregion

#region CcmsAtmNoteSetReader
public class CcmsAtmNoteSetReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsAtmNoteSet currentCcmsAtmNoteSet;
Columns columns;
bool partialRead = false;
private CcmsAtmNoteSetReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsAtmNoteSetReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsAtmNoteSetReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsAtmNoteSet; }

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
currentCcmsAtmNoteSet = new CcmsAtmNoteSet();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsAtmNoteSet.id =(int) reader["id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCcmsAtmNoteSet.atm_id =(int?) reader["atm_id"]; 
if ((columns & Columns.org_note_set_id) == Columns.org_note_set_id && reader["org_note_set_id"]!=DBNull.Value)
currentCcmsAtmNoteSet.org_note_set_id =(int?) reader["org_note_set_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsAtmNoteSet.id = (int) reader["id"]; 
if (reader["atm_id"] != DBNull.Value)
currentCcmsAtmNoteSet.atm_id = (int?) reader["atm_id"]; 
if (reader["org_note_set_id"] != DBNull.Value)
currentCcmsAtmNoteSet.org_note_set_id = (int?) reader["org_note_set_id"]; 
} 

currentCcmsAtmNoteSet.isNewEntity = false;
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

public CcmsAtmNoteSet CurrentCcmsAtmNoteSet
{
get{ return currentCcmsAtmNoteSet; }
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


#region CcmsAtmNoteSet functions

public static CcmsAtmNoteSetReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.org_note_set_id == (Columns.org_note_set_id & columns))
qry.Append("org_note_set_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_atm_note_set ");

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
return new CcmsAtmNoteSetReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsAtmNoteSetReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsAtmNoteSetReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,atm_id,org_note_set_id from Ccms_atm_note_set ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsAtmNoteSetReader(cmd.ExecuteReader(), conn);
}

static public CcmsAtmNoteSetReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsAtmNoteSet LoadCcmsAtmNoteSet(string where)
{
CcmsAtmNoteSetReader reader = CcmsAtmNoteSet.ExecuteReader(where);
CcmsAtmNoteSet _ccmsatmnoteset = null;
if (reader.Read())
_ccmsatmnoteset = reader.CurrentCcmsAtmNoteSet;
reader.Close();
return _ccmsatmnoteset;
}

public static CcmsAtmNoteSet LoadCcmsAtmNoteSet(string where, IDbConnection conn)
{
CcmsAtmNoteSetReader reader = CcmsAtmNoteSet.ExecuteReader(where, conn);
CcmsAtmNoteSet _ccmsatmnoteset = null;
if (reader.Read())
_ccmsatmnoteset = reader.CurrentCcmsAtmNoteSet;
reader.Close(false);
return _ccmsatmnoteset;
}

public static CcmsAtmNoteSet LoadCcmsAtmNoteSetByPk( int id )
{
return LoadCcmsAtmNoteSet( " id="+id );
}

public static CcmsAtmNoteSet LoadCcmsAtmNoteSetByPk( int id , IDbConnection conn)
{
return LoadCcmsAtmNoteSet(" id="+id , conn);
}

public void Save()
{
if (idChanged || atm_idChanged || org_note_set_idChanged )
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
if (idChanged || atm_idChanged || org_note_set_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_atm_note_set( id,atm_id,org_note_set_id ) values(");
lock (ConnectionFactory.connectionString) { this.id = ConnectionFactory.GetNextId();
qry.Append(this.id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(org_note_set_idDbString);
qry.Append(");");

}
else
{
if (!(idChanged || atm_idChanged || org_note_set_idChanged ))
return;
qry.Append("UPDATE Ccms_atm_note_set set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( org_note_set_idChanged )
{
qry.Append("org_note_set_id ="+org_note_set_idDbString);
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
cmd.CommandText = "DELETE Ccms_atm_note_set where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsAtmNoteSets(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_atm_note_set where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
atm_id= 2,
org_note_set_id= 4
}
#endregion
public void BulkSave(List<CcmsAtmNoteSet> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_atm_note_set";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsAtmNoteSet.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsAtmNoteSet> transList,ref DataTable dt)
{
foreach (CcmsAtmNoteSet tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["org_note_set_id"] = tran.OrgNoteSetId;
dt.Rows.Add(Row);
} }
}
}
