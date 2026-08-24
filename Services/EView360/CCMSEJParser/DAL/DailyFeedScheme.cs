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
public class DailyFeedScheme
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DailyFeedScheme() { }
public DailyFeedScheme( string mcn,bool is_split_by_country )
{
this.mcn = mcn;
this.mcnChanged = true;
this.is_split_by_country = is_split_by_country;
this.is_split_by_countryChanged = true;
}
private DailyFeedScheme( string mcn,bool is_split_by_country,int daily_feed_scheme_id )
{
this.mcn = mcn;
this.mcnChanged = true;
this.is_split_by_country = is_split_by_country;
this.is_split_by_countryChanged = true;
this.daily_feed_scheme_id = daily_feed_scheme_id;
this.daily_feed_scheme_idChanged = true;
}

#region members and properties for columns

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
#region IsSplitByCountry
private bool is_split_by_countryChanged = false;
private bool is_split_by_country;
public bool IsSplitByCountry
{
get { return is_split_by_country; }
set { 
is_split_by_country = value;
is_split_by_countryChanged = true;
}
}
private string is_split_by_countryDbString
{
get
{
return is_split_by_country?"1":"0";
}
}
#endregion
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
#endregion

#region DailyFeedSchemeReader
public class DailyFeedSchemeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DailyFeedScheme currentDailyFeedScheme;
Columns columns;
bool partialRead = false;
private DailyFeedSchemeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DailyFeedSchemeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DailyFeedSchemeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDailyFeedScheme; }

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
currentDailyFeedScheme = new DailyFeedScheme();
if (partialRead)
{ if ((columns & Columns.mcn) == Columns.mcn && reader["mcn"]!=DBNull.Value)
currentDailyFeedScheme.mcn =(string) reader["mcn"]; 
if ((columns & Columns.is_split_by_country) == Columns.is_split_by_country && reader["is_split_by_country"]!=DBNull.Value)
currentDailyFeedScheme.is_split_by_country =(bool) reader["is_split_by_country"]; 
if ((columns & Columns.daily_feed_scheme_id) == Columns.daily_feed_scheme_id && reader["daily_feed_scheme_id"]!=DBNull.Value)
currentDailyFeedScheme.daily_feed_scheme_id =(int) reader["daily_feed_scheme_id"]; 

} else
{
if (reader["mcn"] != DBNull.Value)
currentDailyFeedScheme.mcn = (string) reader["mcn"]; 
if (reader["is_split_by_country"] != DBNull.Value)
currentDailyFeedScheme.is_split_by_country = (bool) reader["is_split_by_country"]; 
if (reader["daily_feed_scheme_id"] != DBNull.Value)
currentDailyFeedScheme.daily_feed_scheme_id = (int) reader["daily_feed_scheme_id"]; 
} 

currentDailyFeedScheme.isNewEntity = false;
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

public DailyFeedScheme CurrentDailyFeedScheme
{
get{ return currentDailyFeedScheme; }
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


#region DailyFeedScheme functions

public static DailyFeedSchemeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.mcn == (Columns.mcn & columns))
qry.Append("mcn,");
if (Columns.is_split_by_country == (Columns.is_split_by_country & columns))
qry.Append("is_split_by_country,");
if (Columns.daily_feed_scheme_id == (Columns.daily_feed_scheme_id & columns))
qry.Append("daily_feed_scheme_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Daily_feed_scheme ");

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
return new DailyFeedSchemeReader(cmd.ExecuteReader(), conn, columns);
}

static public DailyFeedSchemeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DailyFeedSchemeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select mcn,is_split_by_country,daily_feed_scheme_id from Daily_feed_scheme ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DailyFeedSchemeReader(cmd.ExecuteReader(), conn);
}

static public DailyFeedSchemeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DailyFeedScheme LoadDailyFeedScheme(string where)
{
DailyFeedSchemeReader reader = DailyFeedScheme.ExecuteReader(where);
DailyFeedScheme _dailyfeedscheme = null;
if (reader.Read())
_dailyfeedscheme = reader.CurrentDailyFeedScheme;
reader.Close();
return _dailyfeedscheme;
}

public static DailyFeedScheme LoadDailyFeedScheme(string where, IDbConnection conn)
{
DailyFeedSchemeReader reader = DailyFeedScheme.ExecuteReader(where, conn);
DailyFeedScheme _dailyfeedscheme = null;
if (reader.Read())
_dailyfeedscheme = reader.CurrentDailyFeedScheme;
reader.Close(false);
return _dailyfeedscheme;
}

public static DailyFeedScheme LoadDailyFeedSchemeByPk( int daily_feed_scheme_id )
{
return LoadDailyFeedScheme( " daily_feed_scheme_id="+daily_feed_scheme_id );
}

public static DailyFeedScheme LoadDailyFeedSchemeByPk( int daily_feed_scheme_id , IDbConnection conn)
{
return LoadDailyFeedScheme(" daily_feed_scheme_id="+daily_feed_scheme_id , conn);
}

public void Save()
{
if (mcnChanged || is_split_by_countryChanged || daily_feed_scheme_idChanged )
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
if (mcnChanged || is_split_by_countryChanged || daily_feed_scheme_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Daily_feed_scheme( mcn,is_split_by_country,daily_feed_scheme_id ) values(");
qry.Append(mcnDbString+",");
qry.Append(is_split_by_countryDbString+",");
lock (ConnectionFactory.connectionString) { this.daily_feed_scheme_id = ConnectionFactory.GetNextId();
qry.Append(this.daily_feed_scheme_id);
} qry.Append(");");

}
else
{
if (!(mcnChanged || is_split_by_countryChanged || daily_feed_scheme_idChanged ))
return;
qry.Append("UPDATE Daily_feed_scheme set "); if ( mcnChanged )
{
qry.Append("mcn ="+mcnDbString);
qry.Append(",");
}

if ( is_split_by_countryChanged )
{
qry.Append("is_split_by_country ="+is_split_by_countryDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("daily_feed_scheme_id = "+daily_feed_scheme_idDbString);
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
cmd.CommandText = "DELETE Daily_feed_scheme where daily_feed_scheme_id = "+ daily_feed_scheme_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDailyFeedSchemes(string where)
{
ConnectionFactory.ExecuteQuery("delete Daily_feed_scheme where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
mcn= 1,
is_split_by_country= 2,
daily_feed_scheme_id= 4
}
#endregion
public void BulkSave(List<DailyFeedScheme> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Daily_feed_scheme";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DailyFeedScheme.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DailyFeedScheme> transList,ref DataTable dt)
{
foreach (DailyFeedScheme tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["mcn"] = tran.Mcn;
Row["is_split_by_country"] = tran.IsSplitByCountry;
Row["daily_feed_scheme_id"] =ConnectionFactory.GetNextId();
dt.Rows.Add(Row);
} }
}
}
