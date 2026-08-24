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
public class CcmsAtmEvent
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsAtmEvent() { }
public CcmsAtmEvent( long id ) 
{
}
public CcmsAtmEvent( string name )
{
this.name = name;
this.nameChanged = true;
}
private CcmsAtmEvent( long id,string name )
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

#region CcmsAtmEventReader
public class CcmsAtmEventReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsAtmEvent currentCcmsAtmEvent;
Columns columns;
bool partialRead = false;
private CcmsAtmEventReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsAtmEventReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsAtmEventReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsAtmEvent; }

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
currentCcmsAtmEvent = new CcmsAtmEvent();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsAtmEvent.id =(long) reader["id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentCcmsAtmEvent.name =(string) reader["name"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsAtmEvent.id = (long) reader["id"]; 
if (reader["name"] != DBNull.Value)
currentCcmsAtmEvent.name = (string) reader["name"]; 
} 

currentCcmsAtmEvent.isNewEntity = false;
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

public CcmsAtmEvent CurrentCcmsAtmEvent
{
get{ return currentCcmsAtmEvent; }
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


#region CcmsAtmEvent functions

public static CcmsAtmEventReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_atm_event ");

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
return new CcmsAtmEventReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsAtmEventReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsAtmEventReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,name from Ccms_atm_event ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsAtmEventReader(cmd.ExecuteReader(), conn);
}

static public CcmsAtmEventReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsAtmEvent LoadCcmsAtmEvent(string where)
{
CcmsAtmEventReader reader = CcmsAtmEvent.ExecuteReader(where);
CcmsAtmEvent _ccmsatmevent = null;
if (reader.Read())
_ccmsatmevent = reader.CurrentCcmsAtmEvent;
reader.Close();
return _ccmsatmevent;
}

public static CcmsAtmEvent LoadCcmsAtmEvent(string where, IDbConnection conn)
{
CcmsAtmEventReader reader = CcmsAtmEvent.ExecuteReader(where, conn);
CcmsAtmEvent _ccmsatmevent = null;
if (reader.Read())
_ccmsatmevent = reader.CurrentCcmsAtmEvent;
reader.Close(false);
return _ccmsatmevent;
}

public static CcmsAtmEvent LoadCcmsAtmEventByPk( long id )
{
return LoadCcmsAtmEvent( " id="+id );
}

public static CcmsAtmEvent LoadCcmsAtmEventByPk( long id , IDbConnection conn)
{
return LoadCcmsAtmEvent(" id="+id , conn);
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
qry.Append(@"insert into Ccms_atm_event( id,name ) values(");
qry.Append(nameDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || nameChanged ))
return;
qry.Append("UPDATE Ccms_atm_event set "); if ( nameChanged )
{
qry.Append("name ="+nameDbString);
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
cmd.CommandText = "DELETE Ccms_atm_event where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsAtmEvents(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_atm_event where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
name= 2
}
#endregion
public void BulkSave(List<CcmsAtmEvent> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_atm_event";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsAtmEvent.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsAtmEvent> transList,ref DataTable dt)
{
foreach (CcmsAtmEvent tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["name"] = tran.Name;
dt.Rows.Add(Row);
} }
}
}
