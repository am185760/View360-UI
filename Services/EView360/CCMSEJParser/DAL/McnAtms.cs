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
public class McnAtms
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public McnAtms() { }
public McnAtms( int atm_id,string mcn,int region_id )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.mcn = mcn;
this.mcnChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}
private McnAtms( int atm_id,string mcn,int mcn_atm_id,int region_id )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.mcn = mcn;
this.mcnChanged = true;
this.mcn_atm_id = mcn_atm_id;
this.mcn_atm_idChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}

#region members and properties for columns

#region AtmId
private bool atm_idChanged = false;
private int atm_id;
public int AtmId
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
return atm_id.ToString();
}
}
#endregion
#region Mcn
private bool mcnChanged = false;
private string mcn;
public string Mcn
{
get { return mcn; }
set { 
mcn = value;
mcnChanged = true;
}
}
private string mcnDbString
{
get
{
if (this.mcn!=null)
return string.Format("'{0}'",mcn); else
return "null";
}
}
#endregion
#region McnAtmId
private bool mcn_atm_idChanged = false;
private int mcn_atm_id;
public int McnAtmId
{
get { return mcn_atm_id; }
set { 
mcn_atm_id = value;
mcn_atm_idChanged = true;
}
}
private string mcn_atm_idDbString
{
get
{
return mcn_atm_id.ToString();
}
}
#endregion
#region RegionId
private bool region_idChanged = false;
private int region_id;
public int RegionId
{
get { return region_id; }
set { 
region_id = value;
region_idChanged = true;
}
}
private string region_idDbString
{
get
{
return region_id.ToString();
}
}
#endregion
#endregion

#region McnAtmsReader
public class McnAtmsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
McnAtms currentMcnAtms;
Columns columns;
bool partialRead = false;
private McnAtmsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public McnAtmsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public McnAtmsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentMcnAtms; }

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
currentMcnAtms = new McnAtms();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentMcnAtms.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.mcn) == Columns.mcn && reader["mcn"]!=DBNull.Value)
currentMcnAtms.mcn =(string) reader["mcn"]; 
if ((columns & Columns.mcn_atm_id) == Columns.mcn_atm_id && reader["mcn_atm_id"]!=DBNull.Value)
currentMcnAtms.mcn_atm_id =(int) reader["mcn_atm_id"]; 
if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentMcnAtms.region_id =(int) reader["region_id"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentMcnAtms.atm_id = (int) reader["atm_id"]; 
if (reader["mcn"] != DBNull.Value)
currentMcnAtms.mcn = (string) reader["mcn"]; 
if (reader["mcn_atm_id"] != DBNull.Value)
currentMcnAtms.mcn_atm_id = (int) reader["mcn_atm_id"]; 
if (reader["region_id"] != DBNull.Value)
currentMcnAtms.region_id = (int) reader["region_id"]; 
} 

currentMcnAtms.isNewEntity = false;
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

public McnAtms CurrentMcnAtms
{
get{ return currentMcnAtms; }
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


#region McnAtms functions

public static McnAtmsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.mcn == (Columns.mcn & columns))
qry.Append("mcn,");
if (Columns.mcn_atm_id == (Columns.mcn_atm_id & columns))
qry.Append("mcn_atm_id,");
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Mcn_atms ");

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
return new McnAtmsReader(cmd.ExecuteReader(), conn, columns);
}

static public McnAtmsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static McnAtmsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,mcn,mcn_atm_id,region_id from Mcn_atms ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new McnAtmsReader(cmd.ExecuteReader(), conn);
}

static public McnAtmsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static McnAtms LoadMcnAtms(string where)
{
McnAtmsReader reader = McnAtms.ExecuteReader(where);
McnAtms _mcnatms = null;
if (reader.Read())
_mcnatms = reader.CurrentMcnAtms;
reader.Close();
return _mcnatms;
}

public static McnAtms LoadMcnAtms(string where, IDbConnection conn)
{
McnAtmsReader reader = McnAtms.ExecuteReader(where, conn);
McnAtms _mcnatms = null;
if (reader.Read())
_mcnatms = reader.CurrentMcnAtms;
reader.Close(false);
return _mcnatms;
}

public static McnAtms LoadMcnAtmsByPk( int mcn_atm_id )
{
return LoadMcnAtms( " mcn_atm_id="+mcn_atm_id );
}

public static McnAtms LoadMcnAtmsByPk( int mcn_atm_id , IDbConnection conn)
{
return LoadMcnAtms(" mcn_atm_id="+mcn_atm_id , conn);
}

public void Save()
{
if (atm_idChanged || mcnChanged || mcn_atm_idChanged || region_idChanged )
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
if (atm_idChanged || mcnChanged || mcn_atm_idChanged || region_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Mcn_atms( atm_id,mcn,mcn_atm_id,region_id ) values(");
qry.Append(atm_idDbString+",");
qry.Append(mcnDbString+",");
lock (ConnectionFactory.connectionString) { this.mcn_atm_id = ConnectionFactory.GetNextId();
qry.Append(this.mcn_atm_id);
} qry.Append(",");
qry.Append(region_idDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || mcnChanged || mcn_atm_idChanged || region_idChanged ))
return;
qry.Append("UPDATE Mcn_atms set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( mcnChanged )
{
qry.Append("mcn ="+mcnDbString);
qry.Append(",");
}

if ( region_idChanged )
{
qry.Append("region_id ="+region_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("mcn_atm_id = "+mcn_atm_idDbString);
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
cmd.CommandText = "DELETE Mcn_atms where mcn_atm_id = "+ mcn_atm_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteMcnAtmss(string where)
{
ConnectionFactory.ExecuteQuery("delete Mcn_atms where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
mcn= 2,
mcn_atm_id= 4,
region_id= 8
}
#endregion
public void BulkSave(List<McnAtms> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Mcn_atms";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(McnAtms.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <McnAtms> transList,ref DataTable dt)
{
foreach (McnAtms tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] = tran.AtmId;
Row["mcn"] = tran.Mcn;
Row["mcn_atm_id"] =ConnectionFactory.GetNextId();
Row["region_id"] = tran.RegionId;
dt.Rows.Add(Row);
} }
}
}
