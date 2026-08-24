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
public class DailyFeedConfig
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DailyFeedConfig() { }
public DailyFeedConfig( int daily_feed_scheme_id,string daily_feed_file_prefix,int region_id )
{
this.daily_feed_scheme_id = daily_feed_scheme_id;
this.daily_feed_scheme_idChanged = true;
this.daily_feed_file_prefix = daily_feed_file_prefix;
this.daily_feed_file_prefixChanged = true;
this.region_id = region_id;
this.region_idChanged = true;
}

#region members and properties for columns

#region DailyFeedSchemeId
private bool daily_feed_scheme_idChanged = false;
private int daily_feed_scheme_id;
public int DailyFeedSchemeId
{
get { return daily_feed_scheme_id; }
set { 
daily_feed_scheme_id = value;
daily_feed_scheme_idChanged = true;
}
}
private string daily_feed_scheme_idDbString
{
get
{
return daily_feed_scheme_id.ToString();
}
}
#endregion
#region DailyFeedFilePrefix
private bool daily_feed_file_prefixChanged = false;
private string daily_feed_file_prefix;
public string DailyFeedFilePrefix
{
get { return daily_feed_file_prefix; }
set { 
daily_feed_file_prefix = value;
daily_feed_file_prefixChanged = true;
}
}
private string daily_feed_file_prefixDbString
{
get
{
if (this.daily_feed_file_prefix!=null)
return string.Format("'{0}'",daily_feed_file_prefix); else
return "null";
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

#region DailyFeedConfigReader
public class DailyFeedConfigReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DailyFeedConfig currentDailyFeedConfig;
Columns columns;
bool partialRead = false;
private DailyFeedConfigReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DailyFeedConfigReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DailyFeedConfigReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDailyFeedConfig; }

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
currentDailyFeedConfig = new DailyFeedConfig();
if (partialRead)
{ if ((columns & Columns.daily_feed_scheme_id) == Columns.daily_feed_scheme_id && reader["daily_feed_scheme_id"]!=DBNull.Value)
currentDailyFeedConfig.daily_feed_scheme_id =(int) reader["daily_feed_scheme_id"]; 
if ((columns & Columns.daily_feed_file_prefix) == Columns.daily_feed_file_prefix && reader["daily_feed_file_prefix"]!=DBNull.Value)
currentDailyFeedConfig.daily_feed_file_prefix =(string) reader["daily_feed_file_prefix"]; 
if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentDailyFeedConfig.region_id =(int) reader["region_id"]; 

} else
{
if (reader["daily_feed_scheme_id"] != DBNull.Value)
currentDailyFeedConfig.daily_feed_scheme_id = (int) reader["daily_feed_scheme_id"]; 
if (reader["daily_feed_file_prefix"] != DBNull.Value)
currentDailyFeedConfig.daily_feed_file_prefix = (string) reader["daily_feed_file_prefix"]; 
if (reader["region_id"] != DBNull.Value)
currentDailyFeedConfig.region_id = (int) reader["region_id"]; 
} 

currentDailyFeedConfig.isNewEntity = false;
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

public DailyFeedConfig CurrentDailyFeedConfig
{
get{ return currentDailyFeedConfig; }
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


#region DailyFeedConfig functions

public static DailyFeedConfigReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.daily_feed_scheme_id == (Columns.daily_feed_scheme_id & columns))
qry.Append("daily_feed_scheme_id,");
if (Columns.daily_feed_file_prefix == (Columns.daily_feed_file_prefix & columns))
qry.Append("daily_feed_file_prefix,");
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Daily_feed_config ");

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
return new DailyFeedConfigReader(cmd.ExecuteReader(), conn, columns);
}

static public DailyFeedConfigReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DailyFeedConfigReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select daily_feed_scheme_id,daily_feed_file_prefix,region_id from Daily_feed_config ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DailyFeedConfigReader(cmd.ExecuteReader(), conn);
}

static public DailyFeedConfigReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DailyFeedConfig LoadDailyFeedConfig(string where)
{
DailyFeedConfigReader reader = DailyFeedConfig.ExecuteReader(where);
DailyFeedConfig _dailyfeedconfig = null;
if (reader.Read())
_dailyfeedconfig = reader.CurrentDailyFeedConfig;
reader.Close();
return _dailyfeedconfig;
}

public static DailyFeedConfig LoadDailyFeedConfig(string where, IDbConnection conn)
{
DailyFeedConfigReader reader = DailyFeedConfig.ExecuteReader(where, conn);
DailyFeedConfig _dailyfeedconfig = null;
if (reader.Read())
_dailyfeedconfig = reader.CurrentDailyFeedConfig;
reader.Close(false);
return _dailyfeedconfig;
}


public void Save()
{
if (daily_feed_scheme_idChanged || daily_feed_file_prefixChanged || region_idChanged )
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
if (daily_feed_scheme_idChanged || daily_feed_file_prefixChanged || region_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Daily_feed_config( daily_feed_scheme_id,daily_feed_file_prefix,region_id ) values(");
qry.Append(daily_feed_scheme_idDbString+",");
qry.Append(daily_feed_file_prefixDbString+",");
qry.Append(region_idDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Daily_feed_config!");
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
throw new Exception("Could not delete because no primary key is defined");
}

public static void DeleteDailyFeedConfigs(string where)
{
ConnectionFactory.ExecuteQuery("delete Daily_feed_config where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
daily_feed_scheme_id= 1,
daily_feed_file_prefix= 2,
region_id= 4
}
#endregion
public void BulkSave(List<DailyFeedConfig> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Daily_feed_config";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DailyFeedConfig.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DailyFeedConfig> transList,ref DataTable dt)
{
foreach (DailyFeedConfig tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["daily_feed_scheme_id"] = tran.DailyFeedSchemeId;
Row["daily_feed_file_prefix"] = tran.DailyFeedFilePrefix;
Row["region_id"] = tran.RegionId;
dt.Rows.Add(Row);
} }
}
}
