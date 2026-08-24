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
public class EjStatus
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public EjStatus() { }
public EjStatus( int atm_id,DateTime ejDateTime,DateTime recorded_at )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.ejDateTime = ejDateTime;
this.ejDateTimeChanged = true;
this.recorded_at = recorded_at;
this.recorded_atChanged = true;
}
private EjStatus( int atm_id,DateTime ejDateTime,DateTime recorded_at,int ej_status_id )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.ejDateTime = ejDateTime;
this.ejDateTimeChanged = true;
this.recorded_at = recorded_at;
this.recorded_atChanged = true;
this.ej_status_id = ej_status_id;
this.ej_status_idChanged = true;
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
#region EjDateTime
private bool ejDateTimeChanged = false;
private DateTime ejDateTime;
public DateTime EjDateTime
{
get { return ejDateTime; }
set { 
ejDateTime = value;
ejDateTimeChanged = true;
}
}
private string ejDateTimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",ejDateTime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
#region EjStatusId
private bool ej_status_idChanged = false;
private int ej_status_id;
public int EjStatusId
{
get { return ej_status_id; }
set { 
ej_status_id = value;
ej_status_idChanged = true;
}
}
private string ej_status_idDbString
{
get
{
return ej_status_id.ToString();
}
}
#endregion
#endregion

#region EjStatusReader
public class EjStatusReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
EjStatus currentEjStatus;
Columns columns;
bool partialRead = false;
private EjStatusReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public EjStatusReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public EjStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentEjStatus; }

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
currentEjStatus = new EjStatus();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentEjStatus.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.ejDateTime) == Columns.ejDateTime && reader["ejDateTime"]!=DBNull.Value)
currentEjStatus.ejDateTime =(DateTime) reader["ejDateTime"]; 
if ((columns & Columns.recorded_at) == Columns.recorded_at && reader["recorded_at"]!=DBNull.Value)
currentEjStatus.recorded_at =(DateTime) reader["recorded_at"]; 
if ((columns & Columns.ej_status_id) == Columns.ej_status_id && reader["ej_status_id"]!=DBNull.Value)
currentEjStatus.ej_status_id =(int) reader["ej_status_id"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentEjStatus.atm_id = (int) reader["atm_id"]; 
if (reader["ejDateTime"] != DBNull.Value)
currentEjStatus.ejDateTime = (DateTime) reader["ejDateTime"]; 
if (reader["recorded_at"] != DBNull.Value)
currentEjStatus.recorded_at = (DateTime) reader["recorded_at"]; 
if (reader["ej_status_id"] != DBNull.Value)
currentEjStatus.ej_status_id = (int) reader["ej_status_id"]; 
} 

currentEjStatus.isNewEntity = false;
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

public EjStatus CurrentEjStatus
{
get{ return currentEjStatus; }
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


#region EjStatus functions

public static EjStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.ejDateTime == (Columns.ejDateTime & columns))
qry.Append("ejDateTime,");
if (Columns.recorded_at == (Columns.recorded_at & columns))
qry.Append("recorded_at,");
if (Columns.ej_status_id == (Columns.ej_status_id & columns))
qry.Append("ej_status_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from EjStatus ");

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
return new EjStatusReader(cmd.ExecuteReader(), conn, columns);
}

static public EjStatusReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static EjStatusReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,ejDateTime,recorded_at,ej_status_id from EjStatus ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new EjStatusReader(cmd.ExecuteReader(), conn);
}

static public EjStatusReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static EjStatus LoadEjStatus(string where)
{
EjStatusReader reader = EjStatus.ExecuteReader(where);
EjStatus _ejstatus = null;
if (reader.Read())
_ejstatus = reader.CurrentEjStatus;
reader.Close();
return _ejstatus;
}

public static EjStatus LoadEjStatus(string where, IDbConnection conn)
{
EjStatusReader reader = EjStatus.ExecuteReader(where, conn);
EjStatus _ejstatus = null;
if (reader.Read())
_ejstatus = reader.CurrentEjStatus;
reader.Close(false);
return _ejstatus;
}

public static EjStatus LoadEjStatusByPk( int ej_status_id )
{
return LoadEjStatus( " ej_status_id="+ej_status_id );
}

public static EjStatus LoadEjStatusByPk( int ej_status_id , IDbConnection conn)
{
return LoadEjStatus(" ej_status_id="+ej_status_id , conn);
}

public void Save()
{
if (atm_idChanged || ejDateTimeChanged || recorded_atChanged || ej_status_idChanged )
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
if (atm_idChanged || ejDateTimeChanged || recorded_atChanged || ej_status_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into EjStatus( atm_id,ejDateTime,recorded_at,ej_status_id ) values(");
qry.Append(atm_idDbString+",");
qry.Append(ejDateTimeDbString+",");
qry.Append(recorded_atDbString+",");
lock (ConnectionFactory.connectionString) { this.ej_status_id = ConnectionFactory.GetNextId();
qry.Append(this.ej_status_id);
} qry.Append(");");

}
else
{
if (!(atm_idChanged || ejDateTimeChanged || recorded_atChanged || ej_status_idChanged ))
return;
qry.Append("UPDATE EjStatus set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( ejDateTimeChanged )
{
qry.Append("ejDateTime ="+ejDateTimeDbString);
qry.Append(",");
}

if ( recorded_atChanged )
{
qry.Append("recorded_at ="+recorded_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("ej_status_id = "+ej_status_idDbString);
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
cmd.CommandText = "DELETE EjStatus where ej_status_id = "+ ej_status_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteEjStatuss(string where)
{
ConnectionFactory.ExecuteQuery("delete EjStatus where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
ejDateTime= 2,
recorded_at= 4,
ej_status_id= 8
}
#endregion
public void BulkSave(List<EjStatus> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "EjStatus";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(EjStatus.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <EjStatus> transList,ref DataTable dt)
{
foreach (EjStatus tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] = tran.AtmId;
Row["ejDateTime"] = tran.EjDateTime;
Row["recorded_at"] = tran.RecordedAt;
Row["ej_status_id"] =ConnectionFactory.GetNextId();
dt.Rows.Add(Row);
} }
}
}
