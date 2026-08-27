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
public class PowerDown
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public PowerDown() { }
public PowerDown( int iD,DateTime starrttime,DateTime endTime,string aTMID )
{
this.iD = iD;
this.iDChanged = true;
this.starrttime = starrttime;
this.starrttimeChanged = true;
this.endTime = endTime;
this.endTimeChanged = true;
this.aTMID = aTMID;
this.aTMIDChanged = true;
}

#region members and properties for columns

#region ID
private bool iDChanged = false;
private int iD;
public int ID
{
get { return iD; }
set { 
iD = value;
iDChanged = true;
}
}
private string iDDbString
{
get
{
return iD.ToString();
}
}
#endregion
#region Starrttime
private bool starrttimeChanged = false;
private DateTime starrttime;
public DateTime Starrttime
{
get { return starrttime; }
set { 
starrttime = value;
starrttimeChanged = true;
}
}
private string starrttimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",starrttime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region EndTime
private bool endTimeChanged = false;
private DateTime endTime;
public DateTime EndTime
{
get { return endTime; }
set { 
endTime = value;
endTimeChanged = true;
}
}
private string endTimeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",endTime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#region ATMID
private bool aTMIDChanged = false;
private string aTMID;
public string ATMID
{
get { return aTMID; }
set { 
aTMID = value;
aTMIDChanged = true;
}
}
private string aTMIDDbString
{
get
{
if (this.aTMID!=null)
return string.Format("'{0}'",aTMID); else
return "null";
}
}
#endregion
#endregion

#region PowerDownReader
public class PowerDownReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
PowerDown currentPowerDown;
Columns columns;
bool partialRead = false;
private PowerDownReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public PowerDownReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public PowerDownReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentPowerDown; }

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
currentPowerDown = new PowerDown();
if (partialRead)
{ if ((columns & Columns.ID) == Columns.ID && reader["ID"]!=DBNull.Value)
currentPowerDown.iD =(int) reader["ID"]; 
if ((columns & Columns.Starrttime) == Columns.Starrttime && reader["Starrttime"]!=DBNull.Value)
currentPowerDown.starrttime =(DateTime) reader["Starrttime"]; 
if ((columns & Columns.EndTime) == Columns.EndTime && reader["EndTime"]!=DBNull.Value)
currentPowerDown.endTime =(DateTime) reader["EndTime"]; 
if ((columns & Columns.ATMID) == Columns.ATMID && reader["ATMID"]!=DBNull.Value)
currentPowerDown.aTMID =(string) reader["ATMID"]; 

} else
{
if (reader["ID"] != DBNull.Value)
currentPowerDown.iD = (int) reader["ID"]; 
if (reader["Starrttime"] != DBNull.Value)
currentPowerDown.starrttime = (DateTime) reader["Starrttime"]; 
if (reader["EndTime"] != DBNull.Value)
currentPowerDown.endTime = (DateTime) reader["EndTime"]; 
if (reader["ATMID"] != DBNull.Value)
currentPowerDown.aTMID = (string) reader["ATMID"]; 
} 

currentPowerDown.isNewEntity = false;
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

public PowerDown CurrentPowerDown
{
get{ return currentPowerDown; }
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


#region PowerDown functions

public static PowerDownReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.ID == (Columns.ID & columns))
qry.Append("ID,");
if (Columns.Starrttime == (Columns.Starrttime & columns))
qry.Append("Starrttime,");
if (Columns.EndTime == (Columns.EndTime & columns))
qry.Append("EndTime,");
if (Columns.ATMID == (Columns.ATMID & columns))
qry.Append("ATMID,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from PowerDown ");

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
return new PowerDownReader(cmd.ExecuteReader(), conn, columns);
}

static public PowerDownReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static PowerDownReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select ID,Starrttime,EndTime,ATMID from PowerDown ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new PowerDownReader(cmd.ExecuteReader(), conn);
}

static public PowerDownReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static PowerDown LoadPowerDown(string where)
{
PowerDownReader reader = PowerDown.ExecuteReader(where);
PowerDown _powerdown = null;
if (reader.Read())
_powerdown = reader.CurrentPowerDown;
reader.Close();
return _powerdown;
}

public static PowerDown LoadPowerDown(string where, IDbConnection conn)
{
PowerDownReader reader = PowerDown.ExecuteReader(where, conn);
PowerDown _powerdown = null;
if (reader.Read())
_powerdown = reader.CurrentPowerDown;
reader.Close(false);
return _powerdown;
}


public void Save()
{
if (iDChanged || starrttimeChanged || endTimeChanged || aTMIDChanged )
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
if (iDChanged || starrttimeChanged || endTimeChanged || aTMIDChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into PowerDown( ID,Starrttime,EndTime,ATMID ) values(");
qry.Append(iDDbString+",");
qry.Append(starrttimeDbString+",");
qry.Append(endTimeDbString+",");
qry.Append(aTMIDDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update PowerDown!");
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

public static void DeletePowerDowns(string where)
{
ConnectionFactory.ExecuteQuery("delete PowerDown where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
ID= 1,
Starrttime= 2,
EndTime= 4,
ATMID= 8
}
#endregion
public void BulkSave(List<PowerDown> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "PowerDown";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(PowerDown.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <PowerDown> transList,ref DataTable dt)
{
foreach (PowerDown tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["iD"] = tran.ID;
Row["starrttime"] = tran.Starrttime;
Row["endTime"] = tran.EndTime;
Row["aTMID"] = tran.ATMID;
dt.Rows.Add(Row);
} }
}
}
