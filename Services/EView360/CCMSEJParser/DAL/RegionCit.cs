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
public class RegionCit
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public RegionCit() { }
public RegionCit( int cit_id,int region_id )
{
this.cit_id = cit_id;
this.cit_idChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}
private RegionCit( int region_cit_id,int cit_id,int region_id )
{
this.region_cit_id = region_cit_id;
this.region_cit_idChanged = true;
this.cit_id = cit_id;
this.cit_idChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}

#region members and properties for columns

#region RegionCitId
private bool region_cit_idChanged = false;
private int region_cit_id;
public int RegionCitId
{
get { return region_cit_id; }
set { 
region_cit_id = value;
region_cit_idChanged = true;
}
}
private string region_cit_idDbString
{
get
{
return region_cit_id.ToString();
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

#region RegionCitReader
public class RegionCitReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
RegionCit currentRegionCit;
Columns columns;
bool partialRead = false;
private RegionCitReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public RegionCitReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public RegionCitReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentRegionCit; }

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
currentRegionCit = new RegionCit();
if (partialRead)
{ if ((columns & Columns.region_cit_id) == Columns.region_cit_id && reader["region_cit_id"]!=DBNull.Value)
currentRegionCit.region_cit_id =(int) reader["region_cit_id"]; 
if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
currentRegionCit.cit_id =(int) reader["cit_id"]; 
if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentRegionCit.region_id =(int) reader["region_id"]; 

} else
{
if (reader["region_cit_id"] != DBNull.Value)
currentRegionCit.region_cit_id = (int) reader["region_cit_id"]; 
if (reader["cit_id"] != DBNull.Value)
currentRegionCit.cit_id = (int) reader["cit_id"]; 
if (reader["region_id"] != DBNull.Value)
currentRegionCit.region_id = (int) reader["region_id"]; 
} 

currentRegionCit.isNewEntity = false;
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

public RegionCit CurrentRegionCit
{
get{ return currentRegionCit; }
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


#region RegionCit functions

public static RegionCitReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.region_cit_id == (Columns.region_cit_id & columns))
qry.Append("region_cit_id,");
if (Columns.cit_id == (Columns.cit_id & columns))
qry.Append("cit_id,");
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Region_cit ");

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
return new RegionCitReader(cmd.ExecuteReader(), conn, columns);
}

static public RegionCitReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static RegionCitReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select region_cit_id,cit_id,region_id from Region_cit ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new RegionCitReader(cmd.ExecuteReader(), conn);
}

static public RegionCitReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static RegionCit LoadRegionCit(string where)
{
RegionCitReader reader = RegionCit.ExecuteReader(where);
RegionCit _regioncit = null;
if (reader.Read())
_regioncit = reader.CurrentRegionCit;
reader.Close();
return _regioncit;
}

public static RegionCit LoadRegionCit(string where, IDbConnection conn)
{
RegionCitReader reader = RegionCit.ExecuteReader(where, conn);
RegionCit _regioncit = null;
if (reader.Read())
_regioncit = reader.CurrentRegionCit;
reader.Close(false);
return _regioncit;
}

public static RegionCit LoadRegionCitByPk( int region_cit_id )
{
return LoadRegionCit( " region_cit_id="+region_cit_id );
}

public static RegionCit LoadRegionCitByPk( int region_cit_id , IDbConnection conn)
{
return LoadRegionCit(" region_cit_id="+region_cit_id , conn);
}

public void Save()
{
if (region_cit_idChanged || cit_idChanged || region_idChanged )
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
if (region_cit_idChanged || cit_idChanged || region_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Region_cit( region_cit_id,cit_id,region_id ) values(");
lock (ConnectionFactory.connectionString) { this.region_cit_id = ConnectionFactory.GetNextId();
qry.Append(this.region_cit_id);
} qry.Append(",");
qry.Append(cit_idDbString+",");
qry.Append(region_idDbString);
qry.Append(");");

}
else
{
if (!(region_cit_idChanged || cit_idChanged || region_idChanged ))
return;
qry.Append("UPDATE Region_cit set "); if ( cit_idChanged )
{
qry.Append("cit_id ="+cit_idDbString);
qry.Append(",");
}

if ( region_idChanged )
{
qry.Append("region_id ="+region_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("region_cit_id = "+region_cit_idDbString);
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
cmd.CommandText = "DELETE Region_cit where region_cit_id = "+ region_cit_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteRegionCits(string where)
{
ConnectionFactory.ExecuteQuery("delete Region_cit where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
region_cit_id= 1,
cit_id= 2,
region_id= 4
}
#endregion
public void BulkSave(List<RegionCit> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Region_cit";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(RegionCit.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <RegionCit> transList,ref DataTable dt)
{
foreach (RegionCit tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["region_cit_id"] =ConnectionFactory.GetNextId();
Row["cit_id"] = tran.CitId;
Row["region_id"] = tran.RegionId;
dt.Rows.Add(Row);
} }
}
}
