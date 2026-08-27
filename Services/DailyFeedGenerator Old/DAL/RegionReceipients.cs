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
public class RegionReceipients
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public RegionReceipients() { }
public RegionReceipients( int receipients_id,int region_id )
{
this.receipients_id = receipients_id;
this.receipients_idChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}
private RegionReceipients( int region_receipients_id,int receipients_id,int region_id )
{
this.region_receipients_id = region_receipients_id;
this.region_receipients_idChanged = true;
this.receipients_id = receipients_id;
this.receipients_idChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}

#region members and properties for columns

#region RegionReceipientsId
private bool region_receipients_idChanged = false;
private int region_receipients_id;
public int RegionReceipientsId
{
get { return region_receipients_id; }
set { 
region_receipients_id = value;
region_receipients_idChanged = true;
}
}
private string region_receipients_idDbString
{
get
{
return region_receipients_id.ToString();
}
}
#endregion
#region ReceipientsId
private bool receipients_idChanged = false;
private int receipients_id;
public int ReceipientsId
{
get { return receipients_id; }
set { 
receipients_id = value;
receipients_idChanged = true;
}
}
private string receipients_idDbString
{
get
{
return receipients_id.ToString();
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

#region RegionReceipientsReader
public class RegionReceipientsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
RegionReceipients currentRegionReceipients;
Columns columns;
bool partialRead = false;
private RegionReceipientsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public RegionReceipientsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public RegionReceipientsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentRegionReceipients; }

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
currentRegionReceipients = new RegionReceipients();
if (partialRead)
{ if ((columns & Columns.region_receipients_id) == Columns.region_receipients_id && reader["region_receipients_id"]!=DBNull.Value)
currentRegionReceipients.region_receipients_id =(int) reader["region_receipients_id"]; 
if ((columns & Columns.receipients_id) == Columns.receipients_id && reader["receipients_id"]!=DBNull.Value)
currentRegionReceipients.receipients_id =(int) reader["receipients_id"]; 
if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentRegionReceipients.region_id =(int) reader["region_id"]; 

} else
{
if (reader["region_receipients_id"] != DBNull.Value)
currentRegionReceipients.region_receipients_id = (int) reader["region_receipients_id"]; 
if (reader["receipients_id"] != DBNull.Value)
currentRegionReceipients.receipients_id = (int) reader["receipients_id"]; 
if (reader["region_id"] != DBNull.Value)
currentRegionReceipients.region_id = (int) reader["region_id"]; 
} 

currentRegionReceipients.isNewEntity = false;
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

public RegionReceipients CurrentRegionReceipients
{
get{ return currentRegionReceipients; }
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


#region RegionReceipients functions

public static RegionReceipientsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.region_receipients_id == (Columns.region_receipients_id & columns))
qry.Append("region_receipients_id,");
if (Columns.receipients_id == (Columns.receipients_id & columns))
qry.Append("receipients_id,");
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Region_receipients ");

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
return new RegionReceipientsReader(cmd.ExecuteReader(), conn, columns);
}

static public RegionReceipientsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static RegionReceipientsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select region_receipients_id,receipients_id,region_id from Region_receipients ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new RegionReceipientsReader(cmd.ExecuteReader(), conn);
}

static public RegionReceipientsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static RegionReceipients LoadRegionReceipients(string where)
{
RegionReceipientsReader reader = RegionReceipients.ExecuteReader(where);
RegionReceipients _regionreceipients = null;
if (reader.Read())
_regionreceipients = reader.CurrentRegionReceipients;
reader.Close();
return _regionreceipients;
}

public static RegionReceipients LoadRegionReceipients(string where, IDbConnection conn)
{
RegionReceipientsReader reader = RegionReceipients.ExecuteReader(where, conn);
RegionReceipients _regionreceipients = null;
if (reader.Read())
_regionreceipients = reader.CurrentRegionReceipients;
reader.Close(false);
return _regionreceipients;
}

public static RegionReceipients LoadRegionReceipientsByPk( int region_receipients_id )
{
return LoadRegionReceipients( " region_receipients_id="+region_receipients_id );
}

public static RegionReceipients LoadRegionReceipientsByPk( int region_receipients_id , IDbConnection conn)
{
return LoadRegionReceipients(" region_receipients_id="+region_receipients_id , conn);
}

public void Save()
{
if (region_receipients_idChanged || receipients_idChanged || region_idChanged )
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
if (region_receipients_idChanged || receipients_idChanged || region_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Region_receipients( region_receipients_id,receipients_id,region_id ) values(");
lock (ConnectionFactory.connectionString) { this.region_receipients_id = ConnectionFactory.GetNextId();
qry.Append(this.region_receipients_id);
} qry.Append(",");
qry.Append(receipients_idDbString+",");
qry.Append(region_idDbString);
qry.Append(");");

}
else
{
if (!(region_receipients_idChanged || receipients_idChanged || region_idChanged ))
return;
qry.Append("UPDATE Region_receipients set "); if ( receipients_idChanged )
{
qry.Append("receipients_id ="+receipients_idDbString);
qry.Append(",");
}

if ( region_idChanged )
{
qry.Append("region_id ="+region_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("region_receipients_id = "+region_receipients_idDbString);
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
cmd.CommandText = "DELETE Region_receipients where region_receipients_id = "+ region_receipients_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteRegionReceipientss(string where)
{
ConnectionFactory.ExecuteQuery("delete Region_receipients where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
region_receipients_id= 1,
receipients_id= 2,
region_id= 4
}
#endregion
public void BulkSave(List<RegionReceipients> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Region_receipients";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(RegionReceipients.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <RegionReceipients> transList,ref DataTable dt)
{
foreach (RegionReceipients tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["region_receipients_id"] =ConnectionFactory.GetNextId();
Row["receipients_id"] = tran.ReceipientsId;
Row["region_id"] = tran.RegionId;
dt.Rows.Add(Row);
} }
}
}
