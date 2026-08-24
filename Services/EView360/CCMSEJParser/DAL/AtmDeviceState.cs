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
public class AtmDeviceState
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmDeviceState() { }
public AtmDeviceState( int device_id,int atm_id,int device_state ) 
{
this.device_state = device_state;
this.device_stateChanged = true;
}
public AtmDeviceState( int device_state,DateTime? last_updated_on,string device_state_desc )
{
this.device_state = device_state;
this.device_stateChanged = true;
this.last_updated_on = last_updated_on;
this.last_updated_onChanged = true;
this.device_state_desc = device_state_desc;
this.device_state_descChanged = true;
}
private AtmDeviceState( int device_id,int atm_id,int device_state,DateTime? last_updated_on,string device_state_desc )
{
this.device_id = device_id;
this.device_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.device_state = device_state;
this.device_stateChanged = true;
this.last_updated_on = last_updated_on;
this.last_updated_onChanged = true;
this.device_state_desc = device_state_desc;
this.device_state_descChanged = true;
}

#region members and properties for columns

#region DeviceId
private bool device_idChanged = false;
private int device_id;
public int DeviceId
{
get { return device_id; }
set { 
device_id = value;
device_idChanged = true;
}
}
private string device_idDbString
{
get
{
return device_id.ToString();
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
#region DeviceState
private bool device_stateChanged = false;
private int device_state;
public int DeviceState
{
get { return device_state; }
set { 
device_state = value;
device_stateChanged = true;
}
}
private string device_stateDbString
{
get
{
return device_state.ToString();
}
}
#endregion
#region LastUpdatedOn
private bool last_updated_onChanged = false;
private DateTime? last_updated_on;
public DateTime? LastUpdatedOn
{
get { return last_updated_on; }
set { 
last_updated_on = value;
last_updated_onChanged = true;
}
}
private string last_updated_onDbString
{
get
{
if (this.last_updated_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",last_updated_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region DeviceStateDesc
private bool device_state_descChanged = false;
private string device_state_desc;
public string DeviceStateDesc
{
get { return device_state_desc; }
set { 
device_state_desc = value;
device_state_descChanged = true;
}
}
private string device_state_descDbString
{
get
{
if (this.device_state_desc!=null)
return string.Format("'{0}'",device_state_desc); else
return "null";
}
}
#endregion
#endregion

#region AtmDeviceStateReader
public class AtmDeviceStateReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmDeviceState currentAtmDeviceState;
Columns columns;
bool partialRead = false;
private AtmDeviceStateReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmDeviceStateReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmDeviceStateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmDeviceState; }

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
currentAtmDeviceState = new AtmDeviceState();
if (partialRead)
{ if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentAtmDeviceState.device_id =(int) reader["device_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmDeviceState.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.device_state) == Columns.device_state && reader["device_state"]!=DBNull.Value)
currentAtmDeviceState.device_state =(int) reader["device_state"]; 
if ((columns & Columns.last_updated_on) == Columns.last_updated_on && reader["last_updated_on"]!=DBNull.Value)
currentAtmDeviceState.last_updated_on =(DateTime?) reader["last_updated_on"]; 
if ((columns & Columns.device_state_desc) == Columns.device_state_desc && reader["device_state_desc"]!=DBNull.Value)
currentAtmDeviceState.device_state_desc =(string) reader["device_state_desc"]; 

} else
{
if (reader["device_id"] != DBNull.Value)
currentAtmDeviceState.device_id = (int) reader["device_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmDeviceState.atm_id = (int) reader["atm_id"]; 
if (reader["device_state"] != DBNull.Value)
currentAtmDeviceState.device_state = (int) reader["device_state"]; 
if (reader["last_updated_on"] != DBNull.Value)
currentAtmDeviceState.last_updated_on = (DateTime?) reader["last_updated_on"]; 
if (reader["device_state_desc"] != DBNull.Value)
currentAtmDeviceState.device_state_desc = (string) reader["device_state_desc"]; 
} 

currentAtmDeviceState.isNewEntity = false;
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

public AtmDeviceState CurrentAtmDeviceState
{
get{ return currentAtmDeviceState; }
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


#region AtmDeviceState functions

public static AtmDeviceStateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.device_state == (Columns.device_state & columns))
qry.Append("device_state,");
if (Columns.last_updated_on == (Columns.last_updated_on & columns))
qry.Append("last_updated_on,");
if (Columns.device_state_desc == (Columns.device_state_desc & columns))
qry.Append("device_state_desc,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_device_state ");

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
return new AtmDeviceStateReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmDeviceStateReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmDeviceStateReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select device_id,atm_id,device_state,last_updated_on,device_state_desc from Atm_device_state ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmDeviceStateReader(cmd.ExecuteReader(), conn);
}

static public AtmDeviceStateReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmDeviceState LoadAtmDeviceState(string where)
{
AtmDeviceStateReader reader = AtmDeviceState.ExecuteReader(where);
AtmDeviceState _atmdevicestate = null;
if (reader.Read())
_atmdevicestate = reader.CurrentAtmDeviceState;
reader.Close();
return _atmdevicestate;
}

public static AtmDeviceState LoadAtmDeviceState(string where, IDbConnection conn)
{
AtmDeviceStateReader reader = AtmDeviceState.ExecuteReader(where, conn);
AtmDeviceState _atmdevicestate = null;
if (reader.Read())
_atmdevicestate = reader.CurrentAtmDeviceState;
reader.Close(false);
return _atmdevicestate;
}

public static AtmDeviceState LoadAtmDeviceStateByPk( int device_id,int atm_id )
{
return LoadAtmDeviceState( " device_id="+device_id+" and atm_id="+atm_id );
}

public static AtmDeviceState LoadAtmDeviceStateByPk( int device_id,int atm_id , IDbConnection conn)
{
return LoadAtmDeviceState(" device_id="+device_id+" and atm_id="+atm_id , conn);
}

public void Save()
{
if (device_idChanged || atm_idChanged || device_stateChanged || last_updated_onChanged || device_state_descChanged )
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
if (device_idChanged || atm_idChanged || device_stateChanged || last_updated_onChanged || device_state_descChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_device_state( device_id,atm_id,device_state,last_updated_on,device_state_desc ) values(");
lock (ConnectionFactory.connectionString) { this.device_id = ConnectionFactory.GetNextId();
qry.Append(this.device_id);
} qry.Append(",");
lock (ConnectionFactory.connectionString) { this.atm_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_id);
} qry.Append(",");
qry.Append(device_stateDbString+",");
qry.Append(last_updated_onDbString+",");
qry.Append(device_state_descDbString);
qry.Append(");");

}
else
{
if (!(device_idChanged || atm_idChanged || device_stateChanged || last_updated_onChanged || device_state_descChanged ))
return;
qry.Append("UPDATE Atm_device_state set "); if ( device_stateChanged )
{
qry.Append("device_state ="+device_stateDbString);
qry.Append(",");
}

if ( last_updated_onChanged )
{
qry.Append("last_updated_on ="+last_updated_onDbString);
qry.Append(",");
}

if ( device_state_descChanged )
{
qry.Append("device_state_desc ="+device_state_descDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("device_id = "+device_idDbString);
qry.Append(" and atm_id = "+atm_idDbString);
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
cmd.CommandText = "DELETE Atm_device_state where device_id = "+ device_id +" and atm_id = "+ atm_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmDeviceStates(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_device_state where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
device_id= 1,
atm_id= 2,
device_state= 4,
last_updated_on= 8,
device_state_desc= 16
}
#endregion
public void BulkSave(List<AtmDeviceState> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_device_state";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmDeviceState.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmDeviceState> transList,ref DataTable dt)
{
foreach (AtmDeviceState tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["device_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] =ConnectionFactory.GetNextId();
Row["device_state"] = tran.DeviceState;
Row["last_updated_on"] = tran.LastUpdatedOn;
Row["device_state_desc"] = tran.DeviceStateDesc;
dt.Rows.Add(Row);
} }
}
}
