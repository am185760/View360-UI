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
public class OrganizationSettlementsProcess
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public OrganizationSettlementsProcess() { }
public OrganizationSettlementsProcess( int organization_settlements_process_id ) 
{
}
public OrganizationSettlementsProcess( int? organization_id,int? settlement_process_id )
{
this.organization_id = organization_id;
this.organization_idChanged = true;
this.settlement_process_id = settlement_process_id;
this.settlement_process_idChanged = true;
}
private OrganizationSettlementsProcess( int organization_settlements_process_id,int? organization_id,int? settlement_process_id )
{
this.organization_settlements_process_id = organization_settlements_process_id;
this.organization_settlements_process_idChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
this.settlement_process_id = settlement_process_id;
this.settlement_process_idChanged = true;
}

#region members and properties for columns

#region OrganizationSettlementsProcessId
private bool organization_settlements_process_idChanged = false;
private int organization_settlements_process_id;
public int OrganizationSettlementsProcessId
{
get { return organization_settlements_process_id; }
set { 
organization_settlements_process_id = value;
organization_settlements_process_idChanged = true;
}
}
private string organization_settlements_process_idDbString
{
get
{
return organization_settlements_process_id.ToString();
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
#region SettlementProcessId
private bool settlement_process_idChanged = false;
private int? settlement_process_id;
public int? SettlementProcessId
{
get { return settlement_process_id; }
set { 
settlement_process_id = value;
settlement_process_idChanged = true;
}
}
private string settlement_process_idDbString
{
get
{
if (this.settlement_process_id.HasValue)
return settlement_process_id.ToString();
else
return "null";
}
}
#endregion
#endregion

#region OrganizationSettlementsProcessReader
public class OrganizationSettlementsProcessReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
OrganizationSettlementsProcess currentOrganizationSettlementsProcess;
Columns columns;
bool partialRead = false;
private OrganizationSettlementsProcessReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public OrganizationSettlementsProcessReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public OrganizationSettlementsProcessReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentOrganizationSettlementsProcess; }

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
currentOrganizationSettlementsProcess = new OrganizationSettlementsProcess();
if (partialRead)
{ if ((columns & Columns.organization_settlements_process_id) == Columns.organization_settlements_process_id && reader["organization_settlements_process_id"]!=DBNull.Value)
currentOrganizationSettlementsProcess.organization_settlements_process_id =(int) reader["organization_settlements_process_id"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentOrganizationSettlementsProcess.organization_id =(int?) reader["organization_id"]; 
if ((columns & Columns.settlement_process_id) == Columns.settlement_process_id && reader["settlement_process_id"]!=DBNull.Value)
currentOrganizationSettlementsProcess.settlement_process_id =(int?) reader["settlement_process_id"]; 

} else
{
if (reader["organization_settlements_process_id"] != DBNull.Value)
currentOrganizationSettlementsProcess.organization_settlements_process_id = (int) reader["organization_settlements_process_id"]; 
if (reader["organization_id"] != DBNull.Value)
currentOrganizationSettlementsProcess.organization_id = (int?) reader["organization_id"]; 
if (reader["settlement_process_id"] != DBNull.Value)
currentOrganizationSettlementsProcess.settlement_process_id = (int?) reader["settlement_process_id"]; 
} 

currentOrganizationSettlementsProcess.isNewEntity = false;
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

public OrganizationSettlementsProcess CurrentOrganizationSettlementsProcess
{
get{ return currentOrganizationSettlementsProcess; }
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


#region OrganizationSettlementsProcess functions

public static OrganizationSettlementsProcessReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.organization_settlements_process_id == (Columns.organization_settlements_process_id & columns))
qry.Append("organization_settlements_process_id,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
if (Columns.settlement_process_id == (Columns.settlement_process_id & columns))
qry.Append("settlement_process_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Organization_settlements_process ");

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
return new OrganizationSettlementsProcessReader(cmd.ExecuteReader(), conn, columns);
}

static public OrganizationSettlementsProcessReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static OrganizationSettlementsProcessReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select organization_settlements_process_id,organization_id,settlement_process_id from Organization_settlements_process ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new OrganizationSettlementsProcessReader(cmd.ExecuteReader(), conn);
}

static public OrganizationSettlementsProcessReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static OrganizationSettlementsProcess LoadOrganizationSettlementsProcess(string where)
{
OrganizationSettlementsProcessReader reader = OrganizationSettlementsProcess.ExecuteReader(where);
OrganizationSettlementsProcess _organizationsettlementsprocess = null;
if (reader.Read())
_organizationsettlementsprocess = reader.CurrentOrganizationSettlementsProcess;
reader.Close();
return _organizationsettlementsprocess;
}

public static OrganizationSettlementsProcess LoadOrganizationSettlementsProcess(string where, IDbConnection conn)
{
OrganizationSettlementsProcessReader reader = OrganizationSettlementsProcess.ExecuteReader(where, conn);
OrganizationSettlementsProcess _organizationsettlementsprocess = null;
if (reader.Read())
_organizationsettlementsprocess = reader.CurrentOrganizationSettlementsProcess;
reader.Close(false);
return _organizationsettlementsprocess;
}

public static OrganizationSettlementsProcess LoadOrganizationSettlementsProcessByPk( int organization_settlements_process_id )
{
return LoadOrganizationSettlementsProcess( " organization_settlements_process_id="+organization_settlements_process_id );
}

public static OrganizationSettlementsProcess LoadOrganizationSettlementsProcessByPk( int organization_settlements_process_id , IDbConnection conn)
{
return LoadOrganizationSettlementsProcess(" organization_settlements_process_id="+organization_settlements_process_id , conn);
}

public void Save()
{
if (organization_settlements_process_idChanged || organization_idChanged || settlement_process_idChanged )
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
if (organization_settlements_process_idChanged || organization_idChanged || settlement_process_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Organization_settlements_process( organization_settlements_process_id,organization_id,settlement_process_id ) values(");
lock (ConnectionFactory.connectionString) { this.organization_settlements_process_id = ConnectionFactory.GetNextId();
qry.Append(this.organization_settlements_process_id);
} qry.Append(",");
qry.Append(organization_idDbString+",");
qry.Append(settlement_process_idDbString);
qry.Append(");");

}
else
{
if (!(organization_settlements_process_idChanged || organization_idChanged || settlement_process_idChanged ))
return;
qry.Append("UPDATE Organization_settlements_process set "); if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}

if ( settlement_process_idChanged )
{
qry.Append("settlement_process_id ="+settlement_process_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("organization_settlements_process_id = "+organization_settlements_process_idDbString);
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
cmd.CommandText = "DELETE Organization_settlements_process where organization_settlements_process_id = "+ organization_settlements_process_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteOrganizationSettlementsProcesss(string where)
{
ConnectionFactory.ExecuteQuery("delete Organization_settlements_process where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
organization_settlements_process_id= 1,
organization_id= 2,
settlement_process_id= 4
}
#endregion
public void BulkSave(List<OrganizationSettlementsProcess> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Organization_settlements_process";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(OrganizationSettlementsProcess.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <OrganizationSettlementsProcess> transList,ref DataTable dt)
{
foreach (OrganizationSettlementsProcess tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["organization_settlements_process_id"] =ConnectionFactory.GetNextId();
Row["organization_id"] = tran.OrganizationId;
Row["settlement_process_id"] = tran.SettlementProcessId;
dt.Rows.Add(Row);
} }
}
}
