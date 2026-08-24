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
public class MState
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public MState() { }
public MState( int mstate_id ) 
{
}
public MState( string mstate_desc,string device_id,string mState_code,byte? mstate_status )
{
this.mstate_desc = mstate_desc;
this.mstate_descChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.mState_code = mState_code;
this.mState_codeChanged = true;
this.mstate_status = mstate_status;
this.mstate_statusChanged = true;
}
private MState( int mstate_id,string mstate_desc,string device_id,string mState_code,byte? mstate_status )
{
this.mstate_id = mstate_id;
this.mstate_idChanged = true;
this.mstate_desc = mstate_desc;
this.mstate_descChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.mState_code = mState_code;
this.mState_codeChanged = true;
this.mstate_status = mstate_status;
this.mstate_statusChanged = true;
}

#region members and properties for columns

#region MstateId
private bool mstate_idChanged = false;
private int mstate_id;
public int MstateId
{
get { return mstate_id; }
set { 
mstate_id = value;
mstate_idChanged = true;
}
}
private string mstate_idDbString
{
get
{
return mstate_id.ToString();
}
}
#endregion
#region MstateDesc
private bool mstate_descChanged = false;
private string mstate_desc;
public string MstateDesc
{
get { return mstate_desc; }
set { 
mstate_desc = value;
mstate_descChanged = true;
}
}
private string mstate_descDbString
{
get
{
if (this.mstate_desc!=null)
return string.Format("'{0}'",mstate_desc); else
return "null";
}
}
#endregion
#region DeviceId
private bool device_idChanged = false;
private string device_id;
public string DeviceId
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
if (this.device_id!=null)
return string.Format("'{0}'",device_id); else
return "null";
}
}
#endregion
#region MStateCode
private bool mState_codeChanged = false;
private string mState_code;
public string MStateCode
{
get { return mState_code; }
set { 
mState_code = value;
mState_codeChanged = true;
}
}
private string mState_codeDbString
{
get
{
if (this.mState_code!=null)
return string.Format("'{0}'",mState_code); else
return "null";
}
}
#endregion
#region MstateStatus
private bool mstate_statusChanged = false;
private byte? mstate_status;
public byte? MstateStatus
{
get { return mstate_status; }
set { 
mstate_status = value;
mstate_statusChanged = true;
}
}
private string mstate_statusDbString
{
get
{
if (this.mstate_status.HasValue)
return mstate_status.ToString();
else
return "null";
}
}
#endregion
#endregion

#region MStateReader
public class MStateReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
MState currentMState;
Columns columns;
bool partialRead = false;
private MStateReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public MStateReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public MStateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentMState; }

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
currentMState = new MState();
if (partialRead)
{ if ((columns & Columns.mstate_id) == Columns.mstate_id && reader["mstate_id"]!=DBNull.Value)
currentMState.mstate_id =(int) reader["mstate_id"]; 
if ((columns & Columns.mstate_desc) == Columns.mstate_desc && reader["mstate_desc"]!=DBNull.Value)
currentMState.mstate_desc =(string) reader["mstate_desc"]; 
if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentMState.device_id =(string) reader["device_id"]; 
if ((columns & Columns.mState_code) == Columns.mState_code && reader["mState_code"]!=DBNull.Value)
currentMState.mState_code =(string) reader["mState_code"]; 
if ((columns & Columns.mstate_status) == Columns.mstate_status && reader["mstate_status"]!=DBNull.Value)
currentMState.mstate_status =(byte?) reader["mstate_status"]; 

} else
{
if (reader["mstate_id"] != DBNull.Value)
currentMState.mstate_id = (int) reader["mstate_id"]; 
if (reader["mstate_desc"] != DBNull.Value)
currentMState.mstate_desc = (string) reader["mstate_desc"]; 
if (reader["device_id"] != DBNull.Value)
currentMState.device_id = (string) reader["device_id"]; 
if (reader["mState_code"] != DBNull.Value)
currentMState.mState_code = (string) reader["mState_code"]; 
if (reader["mstate_status"] != DBNull.Value)
currentMState.mstate_status = (byte?) reader["mstate_status"]; 
} 

currentMState.isNewEntity = false;
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

public MState CurrentMState
{
get{ return currentMState; }
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


#region MState functions

public static MStateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.mstate_id == (Columns.mstate_id & columns))
qry.Append("mstate_id,");
if (Columns.mstate_desc == (Columns.mstate_desc & columns))
qry.Append("mstate_desc,");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.mState_code == (Columns.mState_code & columns))
qry.Append("mState_code,");
if (Columns.mstate_status == (Columns.mstate_status & columns))
qry.Append("mstate_status,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from MState ");

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
return new MStateReader(cmd.ExecuteReader(), conn, columns);
}

static public MStateReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static MStateReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select mstate_id,mstate_desc,device_id,mState_code,mstate_status from MState ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new MStateReader(cmd.ExecuteReader(), conn);
}

static public MStateReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static MState LoadMState(string where)
{
MStateReader reader = MState.ExecuteReader(where);
MState _mstate = null;
if (reader.Read())
_mstate = reader.CurrentMState;
reader.Close();
return _mstate;
}

public static MState LoadMState(string where, IDbConnection conn)
{
MStateReader reader = MState.ExecuteReader(where, conn);
MState _mstate = null;
if (reader.Read())
_mstate = reader.CurrentMState;
reader.Close(false);
return _mstate;
}

public static MState LoadMStateByPk( int mstate_id )
{
return LoadMState( " mstate_id="+mstate_id );
}

public static MState LoadMStateByPk( int mstate_id , IDbConnection conn)
{
return LoadMState(" mstate_id="+mstate_id , conn);
}

public void Save()
{
if (mstate_idChanged || mstate_descChanged || device_idChanged || mState_codeChanged || mstate_statusChanged )
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
if (mstate_idChanged || mstate_descChanged || device_idChanged || mState_codeChanged || mstate_statusChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into MState( mstate_id,mstate_desc,device_id,mState_code,mstate_status ) values(");
lock (ConnectionFactory.connectionString) { this.mstate_id = ConnectionFactory.GetNextId();
qry.Append(this.mstate_id);
} qry.Append(",");
qry.Append(mstate_descDbString+",");
qry.Append(device_idDbString+",");
qry.Append(mState_codeDbString+",");
qry.Append(mstate_statusDbString);
qry.Append(");");

}
else
{
if (!(mstate_idChanged || mstate_descChanged || device_idChanged || mState_codeChanged || mstate_statusChanged ))
return;
qry.Append("UPDATE MState set "); if ( mstate_descChanged )
{
qry.Append("mstate_desc ="+mstate_descDbString);
qry.Append(",");
}

if ( device_idChanged )
{
qry.Append("device_id ="+device_idDbString);
qry.Append(",");
}

if ( mState_codeChanged )
{
qry.Append("mState_code ="+mState_codeDbString);
qry.Append(",");
}

if ( mstate_statusChanged )
{
qry.Append("mstate_status ="+mstate_statusDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("mstate_id = "+mstate_idDbString);
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
cmd.CommandText = "DELETE MState where mstate_id = "+ mstate_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteMStates(string where)
{
ConnectionFactory.ExecuteQuery("delete MState where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
mstate_id= 1,
mstate_desc= 2,
device_id= 4,
mState_code= 8,
mstate_status= 16
}
#endregion
public void BulkSave(List<MState> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "MState";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(MState.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <MState> transList,ref DataTable dt)
{
foreach (MState tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["mstate_id"] =ConnectionFactory.GetNextId();
Row["mstate_desc"] = tran.MstateDesc;
Row["device_id"] = tran.DeviceId;
Row["mState_code"] = tran.MStateCode;
Row["mstate_status"] = tran.MstateStatus;
dt.Rows.Add(Row);
} }
}
}
