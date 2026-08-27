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
public class CpmCountsCleared
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CpmCountsCleared() { }
public CpmCountsCleared( int atm_id,DateTime counts_cleared_at,DateTime recorded_at )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.counts_cleared_at = counts_cleared_at;
this.counts_cleared_atChanged = true;
this.recorded_at = recorded_at;
this.recorded_atChanged = true;
}
private CpmCountsCleared( int cpm_counts_cleared_id,int atm_id,DateTime counts_cleared_at,DateTime recorded_at )
{
this.cpm_counts_cleared_id = cpm_counts_cleared_id;
this.cpm_counts_cleared_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.counts_cleared_at = counts_cleared_at;
this.counts_cleared_atChanged = true;
this.recorded_at = recorded_at;
this.recorded_atChanged = true;
}

#region members and properties for columns

#region CpmCountsClearedId
private bool cpm_counts_cleared_idChanged = false;
private int cpm_counts_cleared_id;
public int CpmCountsClearedId
{
get { return cpm_counts_cleared_id; }
set { 
cpm_counts_cleared_id = value;
cpm_counts_cleared_idChanged = true;
}
}
private string cpm_counts_cleared_idDbString
{
get
{
return cpm_counts_cleared_id.ToString();
}
}
#endregion
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
#region CountsClearedAt
private bool counts_cleared_atChanged = false;
private DateTime counts_cleared_at;
public DateTime CountsClearedAt
{
get { return counts_cleared_at; }
set { 
counts_cleared_at = value;
counts_cleared_atChanged = true;
}
}
private string counts_cleared_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",counts_cleared_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region RecordedAt
private bool recorded_atChanged = false;
private DateTime recorded_at;
public DateTime RecordedAt
{
get { return recorded_at; }
set { 
recorded_at = value;
recorded_atChanged = true;
}
}
private string recorded_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",recorded_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region CpmCountsClearedReader
public class CpmCountsClearedReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CpmCountsCleared currentCpmCountsCleared;
Columns columns;
bool partialRead = false;
private CpmCountsClearedReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CpmCountsClearedReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CpmCountsClearedReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCpmCountsCleared; }

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
currentCpmCountsCleared = new CpmCountsCleared();
if (partialRead)
{ if ((columns & Columns.cpm_counts_cleared_id) == Columns.cpm_counts_cleared_id && reader["cpm_counts_cleared_id"]!=DBNull.Value)
currentCpmCountsCleared.cpm_counts_cleared_id =(int) reader["cpm_counts_cleared_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentCpmCountsCleared.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.counts_cleared_at) == Columns.counts_cleared_at && reader["counts_cleared_at"]!=DBNull.Value)
currentCpmCountsCleared.counts_cleared_at =(DateTime) reader["counts_cleared_at"]; 
if ((columns & Columns.recorded_at) == Columns.recorded_at && reader["recorded_at"]!=DBNull.Value)
currentCpmCountsCleared.recorded_at =(DateTime) reader["recorded_at"]; 

} else
{
if (reader["cpm_counts_cleared_id"] != DBNull.Value)
currentCpmCountsCleared.cpm_counts_cleared_id = (int) reader["cpm_counts_cleared_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentCpmCountsCleared.atm_id = (int) reader["atm_id"]; 
if (reader["counts_cleared_at"] != DBNull.Value)
currentCpmCountsCleared.counts_cleared_at = (DateTime) reader["counts_cleared_at"]; 
if (reader["recorded_at"] != DBNull.Value)
currentCpmCountsCleared.recorded_at = (DateTime) reader["recorded_at"]; 
} 

currentCpmCountsCleared.isNewEntity = false;
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

public CpmCountsCleared CurrentCpmCountsCleared
{
get{ return currentCpmCountsCleared; }
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


#region CpmCountsCleared functions

public static CpmCountsClearedReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.cpm_counts_cleared_id == (Columns.cpm_counts_cleared_id & columns))
qry.Append("cpm_counts_cleared_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.counts_cleared_at == (Columns.counts_cleared_at & columns))
qry.Append("counts_cleared_at,");
if (Columns.recorded_at == (Columns.recorded_at & columns))
qry.Append("recorded_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Cpm_counts_cleared ");

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
return new CpmCountsClearedReader(cmd.ExecuteReader(), conn, columns);
}

static public CpmCountsClearedReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CpmCountsClearedReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select cpm_counts_cleared_id,atm_id,counts_cleared_at,recorded_at from Cpm_counts_cleared ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CpmCountsClearedReader(cmd.ExecuteReader(), conn);
}

static public CpmCountsClearedReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CpmCountsCleared LoadCpmCountsCleared(string where)
{
CpmCountsClearedReader reader = CpmCountsCleared.ExecuteReader(where);
CpmCountsCleared _cpmcountscleared = null;
if (reader.Read())
_cpmcountscleared = reader.CurrentCpmCountsCleared;
reader.Close();
return _cpmcountscleared;
}

public static CpmCountsCleared LoadCpmCountsCleared(string where, IDbConnection conn)
{
CpmCountsClearedReader reader = CpmCountsCleared.ExecuteReader(where, conn);
CpmCountsCleared _cpmcountscleared = null;
if (reader.Read())
_cpmcountscleared = reader.CurrentCpmCountsCleared;
reader.Close(false);
return _cpmcountscleared;
}

public static CpmCountsCleared LoadCpmCountsClearedByPk( int cpm_counts_cleared_id )
{
return LoadCpmCountsCleared( " cpm_counts_cleared_id="+cpm_counts_cleared_id );
}

public static CpmCountsCleared LoadCpmCountsClearedByPk( int cpm_counts_cleared_id , IDbConnection conn)
{
return LoadCpmCountsCleared(" cpm_counts_cleared_id="+cpm_counts_cleared_id , conn);
}

public void Save()
{
if (cpm_counts_cleared_idChanged || atm_idChanged || counts_cleared_atChanged || recorded_atChanged )
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
if (cpm_counts_cleared_idChanged || atm_idChanged || counts_cleared_atChanged || recorded_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Cpm_counts_cleared( cpm_counts_cleared_id,atm_id,counts_cleared_at,recorded_at ) values(");
lock (ConnectionFactory.connectionString) { this.cpm_counts_cleared_id = ConnectionFactory.GetNextId();
qry.Append(this.cpm_counts_cleared_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(counts_cleared_atDbString+",");
qry.Append(recorded_atDbString);
qry.Append(");");

}
else
{
if (!(cpm_counts_cleared_idChanged || atm_idChanged || counts_cleared_atChanged || recorded_atChanged ))
return;
qry.Append("UPDATE Cpm_counts_cleared set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( counts_cleared_atChanged )
{
qry.Append("counts_cleared_at ="+counts_cleared_atDbString);
qry.Append(",");
}

if ( recorded_atChanged )
{
qry.Append("recorded_at ="+recorded_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("cpm_counts_cleared_id = "+cpm_counts_cleared_idDbString);
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
cmd.CommandText = "DELETE Cpm_counts_cleared where cpm_counts_cleared_id = "+ cpm_counts_cleared_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCpmCountsCleareds(string where)
{
ConnectionFactory.ExecuteQuery("delete Cpm_counts_cleared where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
cpm_counts_cleared_id= 1,
atm_id= 2,
counts_cleared_at= 4,
recorded_at= 8
}
#endregion
public DataTable BulkSave(List<CpmCountsCleared> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Cpm_counts_cleared";
bulk.WriteToServer(dt); return dt;
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CpmCountsCleared.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CpmCountsCleared> transList,ref DataTable dt)
{
foreach (CpmCountsCleared tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["cpm_counts_cleared_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["counts_cleared_at"] = tran.CountsClearedAt;
Row["recorded_at"] = tran.RecordedAt;
dt.Rows.Add(Row);
} }
}
}
