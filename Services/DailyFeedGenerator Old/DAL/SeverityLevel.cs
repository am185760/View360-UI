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
public class SeverityLevel
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SeverityLevel() { }
public SeverityLevel( int severity_id ) 
{
}
public SeverityLevel( string level_name )
{
this.level_name = level_name;
this.level_nameChanged = true;
}
private SeverityLevel( int severity_id,string level_name )
{
this.severity_id = severity_id;
this.severity_idChanged = true;
this.level_name = level_name;
this.level_nameChanged = true;
}

#region members and properties for columns

#region SeverityId
private bool severity_idChanged = false;
private int severity_id;
public int SeverityId
{
get { return severity_id; }
set { 
severity_id = value;
severity_idChanged = true;
}
}
private string severity_idDbString
{
get
{
return severity_id.ToString();
}
}
#endregion
#region LevelName
private bool level_nameChanged = false;
private string level_name;
public string LevelName
{
get { return level_name; }
set { 
level_name = value;
level_nameChanged = true;
}
}
private string level_nameDbString
{
get
{
if (this.level_name!=null)
return string.Format("'{0}'",level_name); else
return "null";
}
}
#endregion
#endregion

#region SeverityLevelReader
public class SeverityLevelReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SeverityLevel currentSeverityLevel;
Columns columns;
bool partialRead = false;
private SeverityLevelReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SeverityLevelReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SeverityLevelReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSeverityLevel; }

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
currentSeverityLevel = new SeverityLevel();
if (partialRead)
{ if ((columns & Columns.severity_id) == Columns.severity_id && reader["severity_id"]!=DBNull.Value)
currentSeverityLevel.severity_id =(int) reader["severity_id"]; 
if ((columns & Columns.level_name) == Columns.level_name && reader["level_name"]!=DBNull.Value)
currentSeverityLevel.level_name =(string) reader["level_name"]; 

} else
{
if (reader["severity_id"] != DBNull.Value)
currentSeverityLevel.severity_id = (int) reader["severity_id"]; 
if (reader["level_name"] != DBNull.Value)
currentSeverityLevel.level_name = (string) reader["level_name"]; 
} 

currentSeverityLevel.isNewEntity = false;
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

public SeverityLevel CurrentSeverityLevel
{
get{ return currentSeverityLevel; }
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


#region SeverityLevel functions

public static SeverityLevelReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.severity_id == (Columns.severity_id & columns))
qry.Append("severity_id,");
if (Columns.level_name == (Columns.level_name & columns))
qry.Append("level_name,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Severity_level ");

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
return new SeverityLevelReader(cmd.ExecuteReader(), conn, columns);
}

static public SeverityLevelReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SeverityLevelReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select severity_id,level_name from Severity_level ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SeverityLevelReader(cmd.ExecuteReader(), conn);
}

static public SeverityLevelReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SeverityLevel LoadSeverityLevel(string where)
{
SeverityLevelReader reader = SeverityLevel.ExecuteReader(where);
SeverityLevel _severitylevel = null;
if (reader.Read())
_severitylevel = reader.CurrentSeverityLevel;
reader.Close();
return _severitylevel;
}

public static SeverityLevel LoadSeverityLevel(string where, IDbConnection conn)
{
SeverityLevelReader reader = SeverityLevel.ExecuteReader(where, conn);
SeverityLevel _severitylevel = null;
if (reader.Read())
_severitylevel = reader.CurrentSeverityLevel;
reader.Close(false);
return _severitylevel;
}

public static SeverityLevel LoadSeverityLevelByPk( int severity_id )
{
return LoadSeverityLevel( " severity_id="+severity_id );
}

public static SeverityLevel LoadSeverityLevelByPk( int severity_id , IDbConnection conn)
{
return LoadSeverityLevel(" severity_id="+severity_id , conn);
}

public void Save()
{
if (severity_idChanged || level_nameChanged )
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
if (severity_idChanged || level_nameChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Severity_level( severity_id,level_name ) values(");
lock (ConnectionFactory.connectionString) { this.severity_id = ConnectionFactory.GetNextId();
qry.Append(this.severity_id);
} qry.Append(",");
qry.Append(level_nameDbString);
qry.Append(");");

}
else
{
if (!(severity_idChanged || level_nameChanged ))
return;
qry.Append("UPDATE Severity_level set "); if ( level_nameChanged )
{
qry.Append("level_name ="+level_nameDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("severity_id = "+severity_idDbString);
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
cmd.CommandText = "DELETE Severity_level where severity_id = "+ severity_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteSeverityLevels(string where)
{
ConnectionFactory.ExecuteQuery("delete Severity_level where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
severity_id= 1,
level_name= 2
}
#endregion
public void BulkSave(List<SeverityLevel> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Severity_level";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SeverityLevel.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SeverityLevel> transList,ref DataTable dt)
{
foreach (SeverityLevel tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["severity_id"] =ConnectionFactory.GetNextId();
Row["level_name"] = tran.LevelName;
dt.Rows.Add(Row);
} }
}
}
