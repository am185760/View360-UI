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
public class ParsedCpmCounter
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public ParsedCpmCounter() { }
public ParsedCpmCounter( int parsed_cpm_counter_id,int atm_id,int task_id,DateTime deposit_at ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.deposit_at = deposit_at;
this.deposit_atChanged = true;
}
public ParsedCpmCounter( int? bin1,int? bin2,int? bin3,int? bin4,int atm_id,int task_id,DateTime deposit_at )
{
this.bin1 = bin1;
this.bin1Changed = true;
this.bin2 = bin2;
this.bin2Changed = true;
this.bin3 = bin3;
this.bin3Changed = true;
this.bin4 = bin4;
this.bin4Changed = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.deposit_at = deposit_at;
this.deposit_atChanged = true;
}
private ParsedCpmCounter( int parsed_cpm_counter_id,int? bin1,int? bin2,int? bin3,int? bin4,int atm_id,int task_id,DateTime deposit_at )
{
this.parsed_cpm_counter_id = parsed_cpm_counter_id;
this.parsed_cpm_counter_idChanged = true;
this.bin1 = bin1;
this.bin1Changed = true;
this.bin2 = bin2;
this.bin2Changed = true;
this.bin3 = bin3;
this.bin3Changed = true;
this.bin4 = bin4;
this.bin4Changed = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.task_id = task_id;
this.task_idChanged = true;
this.deposit_at = deposit_at;
this.deposit_atChanged = true;
}

#region members and properties for columns

#region ParsedCpmCounterId
private bool parsed_cpm_counter_idChanged = false;
private int parsed_cpm_counter_id;
public int ParsedCpmCounterId
{
get { return parsed_cpm_counter_id; }
set { 
parsed_cpm_counter_id = value;
parsed_cpm_counter_idChanged = true;
}
}
private string parsed_cpm_counter_idDbString
{
get
{
return parsed_cpm_counter_id.ToString();
}
}
#endregion
#region Bin1
private bool bin1Changed = false;
private int? bin1;
public int? Bin1
{
get { return bin1; }
set { 
bin1 = value;
bin1Changed = true;
}
}
private string bin1DbString
{
get
{
if (this.bin1.HasValue)
return bin1.ToString();
else
return "null";
}
}
#endregion
#region Bin2
private bool bin2Changed = false;
private int? bin2;
public int? Bin2
{
get { return bin2; }
set { 
bin2 = value;
bin2Changed = true;
}
}
private string bin2DbString
{
get
{
if (this.bin2.HasValue)
return bin2.ToString();
else
return "null";
}
}
#endregion
#region Bin3
private bool bin3Changed = false;
private int? bin3;
public int? Bin3
{
get { return bin3; }
set { 
bin3 = value;
bin3Changed = true;
}
}
private string bin3DbString
{
get
{
if (this.bin3.HasValue)
return bin3.ToString();
else
return "null";
}
}
#endregion
#region Bin4
private bool bin4Changed = false;
private int? bin4;
public int? Bin4
{
get { return bin4; }
set { 
bin4 = value;
bin4Changed = true;
}
}
private string bin4DbString
{
get
{
if (this.bin4.HasValue)
return bin4.ToString();
else
return "null";
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
#region TaskId
private bool task_idChanged = false;
private int task_id;
public int TaskId
{
get { return task_id; }
set { 
task_id = value;
task_idChanged = true;
}
}
private string task_idDbString
{
get
{
return task_id.ToString();
}
}
#endregion
#region DepositAt
private bool deposit_atChanged = false;
private DateTime deposit_at;
public DateTime DepositAt
{
get { return deposit_at; }
set { 
deposit_at = value;
deposit_atChanged = true;
}
}
private string deposit_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",deposit_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region ParsedCpmCounterReader
public class ParsedCpmCounterReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
ParsedCpmCounter currentParsedCpmCounter;
Columns columns;
bool partialRead = false;
private ParsedCpmCounterReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public ParsedCpmCounterReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public ParsedCpmCounterReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentParsedCpmCounter; }

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
currentParsedCpmCounter = new ParsedCpmCounter();
if (partialRead)
{ if ((columns & Columns.parsed_cpm_counter_id) == Columns.parsed_cpm_counter_id && reader["parsed_cpm_counter_id"]!=DBNull.Value)
currentParsedCpmCounter.parsed_cpm_counter_id =(int) reader["parsed_cpm_counter_id"]; 
if ((columns & Columns.bin1) == Columns.bin1 && reader["bin1"]!=DBNull.Value)
currentParsedCpmCounter.bin1 =(int?) reader["bin1"]; 
if ((columns & Columns.bin2) == Columns.bin2 && reader["bin2"]!=DBNull.Value)
currentParsedCpmCounter.bin2 =(int?) reader["bin2"]; 
if ((columns & Columns.bin3) == Columns.bin3 && reader["bin3"]!=DBNull.Value)
currentParsedCpmCounter.bin3 =(int?) reader["bin3"]; 
if ((columns & Columns.bin4) == Columns.bin4 && reader["bin4"]!=DBNull.Value)
currentParsedCpmCounter.bin4 =(int?) reader["bin4"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentParsedCpmCounter.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
currentParsedCpmCounter.task_id =(int) reader["task_id"]; 
if ((columns & Columns.deposit_at) == Columns.deposit_at && reader["deposit_at"]!=DBNull.Value)
currentParsedCpmCounter.deposit_at =(DateTime) reader["deposit_at"]; 

} else
{
if (reader["parsed_cpm_counter_id"] != DBNull.Value)
currentParsedCpmCounter.parsed_cpm_counter_id = (int) reader["parsed_cpm_counter_id"]; 
if (reader["bin1"] != DBNull.Value)
currentParsedCpmCounter.bin1 = (int?) reader["bin1"]; 
if (reader["bin2"] != DBNull.Value)
currentParsedCpmCounter.bin2 = (int?) reader["bin2"]; 
if (reader["bin3"] != DBNull.Value)
currentParsedCpmCounter.bin3 = (int?) reader["bin3"]; 
if (reader["bin4"] != DBNull.Value)
currentParsedCpmCounter.bin4 = (int?) reader["bin4"]; 
if (reader["atm_id"] != DBNull.Value)
currentParsedCpmCounter.atm_id = (int) reader["atm_id"]; 
if (reader["task_id"] != DBNull.Value)
currentParsedCpmCounter.task_id = (int) reader["task_id"]; 
if (reader["deposit_at"] != DBNull.Value)
currentParsedCpmCounter.deposit_at = (DateTime) reader["deposit_at"]; 
} 

currentParsedCpmCounter.isNewEntity = false;
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

public ParsedCpmCounter CurrentParsedCpmCounter
{
get{ return currentParsedCpmCounter; }
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


#region ParsedCpmCounter functions

public static ParsedCpmCounterReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.parsed_cpm_counter_id == (Columns.parsed_cpm_counter_id & columns))
qry.Append("parsed_cpm_counter_id,");
if (Columns.bin1 == (Columns.bin1 & columns))
qry.Append("bin1,");
if (Columns.bin2 == (Columns.bin2 & columns))
qry.Append("bin2,");
if (Columns.bin3 == (Columns.bin3 & columns))
qry.Append("bin3,");
if (Columns.bin4 == (Columns.bin4 & columns))
qry.Append("bin4,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.task_id == (Columns.task_id & columns))
qry.Append("task_id,");
if (Columns.deposit_at == (Columns.deposit_at & columns))
qry.Append("deposit_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Parsed_cpm_counter ");

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
return new ParsedCpmCounterReader(cmd.ExecuteReader(), conn, columns);
}

static public ParsedCpmCounterReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static ParsedCpmCounterReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select parsed_cpm_counter_id,bin1,bin2,bin3,bin4,atm_id,task_id,deposit_at from Parsed_cpm_counter ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new ParsedCpmCounterReader(cmd.ExecuteReader(), conn);
}

static public ParsedCpmCounterReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static ParsedCpmCounter LoadParsedCpmCounter(string where)
{
ParsedCpmCounterReader reader = ParsedCpmCounter.ExecuteReader(where);
ParsedCpmCounter _parsedcpmcounter = null;
if (reader.Read())
_parsedcpmcounter = reader.CurrentParsedCpmCounter;
reader.Close();
return _parsedcpmcounter;
}

public static ParsedCpmCounter LoadParsedCpmCounter(string where, IDbConnection conn)
{
ParsedCpmCounterReader reader = ParsedCpmCounter.ExecuteReader(where, conn);
ParsedCpmCounter _parsedcpmcounter = null;
if (reader.Read())
_parsedcpmcounter = reader.CurrentParsedCpmCounter;
reader.Close(false);
return _parsedcpmcounter;
}

public static ParsedCpmCounter LoadParsedCpmCounterByPk( int parsed_cpm_counter_id )
{
return LoadParsedCpmCounter( " parsed_cpm_counter_id="+parsed_cpm_counter_id );
}

public static ParsedCpmCounter LoadParsedCpmCounterByPk( int parsed_cpm_counter_id , IDbConnection conn)
{
return LoadParsedCpmCounter(" parsed_cpm_counter_id="+parsed_cpm_counter_id , conn);
}

public void Save()
{
if (parsed_cpm_counter_idChanged || bin1Changed || bin2Changed || bin3Changed || bin4Changed || atm_idChanged || task_idChanged || deposit_atChanged )
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
if (parsed_cpm_counter_idChanged || bin1Changed || bin2Changed || bin3Changed || bin4Changed || atm_idChanged || task_idChanged || deposit_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Parsed_cpm_counter( parsed_cpm_counter_id,bin1,bin2,bin3,bin4,atm_id,task_id,deposit_at ) values(");
lock (ConnectionFactory.connectionString) { this.parsed_cpm_counter_id = ConnectionFactory.GetNextId();
qry.Append(this.parsed_cpm_counter_id);
} qry.Append(",");
qry.Append(bin1DbString+",");
qry.Append(bin2DbString+",");
qry.Append(bin3DbString+",");
qry.Append(bin4DbString+",");
qry.Append(atm_idDbString+",");
qry.Append(task_idDbString+",");
qry.Append(deposit_atDbString);
qry.Append(");");

}
else
{
if (!(parsed_cpm_counter_idChanged || bin1Changed || bin2Changed || bin3Changed || bin4Changed || atm_idChanged || task_idChanged || deposit_atChanged ))
return;
qry.Append("UPDATE Parsed_cpm_counter set "); if ( bin1Changed )
{
qry.Append("bin1 ="+bin1DbString);
qry.Append(",");
}

if ( bin2Changed )
{
qry.Append("bin2 ="+bin2DbString);
qry.Append(",");
}

if ( bin3Changed )
{
qry.Append("bin3 ="+bin3DbString);
qry.Append(",");
}

if ( bin4Changed )
{
qry.Append("bin4 ="+bin4DbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( task_idChanged )
{
qry.Append("task_id ="+task_idDbString);
qry.Append(",");
}

if ( deposit_atChanged )
{
qry.Append("deposit_at ="+deposit_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("parsed_cpm_counter_id = "+parsed_cpm_counter_idDbString);
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
cmd.CommandText = "DELETE Parsed_cpm_counter where parsed_cpm_counter_id = "+ parsed_cpm_counter_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteParsedCpmCounters(string where)
{
ConnectionFactory.ExecuteQuery("delete Parsed_cpm_counter where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
parsed_cpm_counter_id= 1,
bin1= 2,
bin2= 4,
bin3= 8,
bin4= 16,
atm_id= 32,
task_id= 64,
deposit_at= 128
}
#endregion
public void BulkSave(List<ParsedCpmCounter> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Parsed_cpm_counter";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(ParsedCpmCounter.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <ParsedCpmCounter> transList,ref DataTable dt)
{
foreach (ParsedCpmCounter tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["parsed_cpm_counter_id"] =ConnectionFactory.GetNextId();
Row["bin1"] = tran.Bin1;
Row["bin2"] = tran.Bin2;
Row["bin3"] = tran.Bin3;
Row["bin4"] = tran.Bin4;
Row["atm_id"] = tran.AtmId;
Row["task_id"] = tran.TaskId;
Row["deposit_at"] = tran.DepositAt;
dt.Rows.Add(Row);
} }
}
}
