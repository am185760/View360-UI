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
public class AtmDevices
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmDevices() { }
public AtmDevices( bool is_active,bool is_critical,bool is_present )
{
this.is_active = is_active;
this.is_activeChanged = true;
this.is_critical = is_critical;
this.is_criticalChanged = true;
this.is_present = is_present;
this.is_presentChanged = true;
}
private AtmDevices( int atm_id,int device_template_id,int device_id,bool is_active,bool is_critical,bool is_present )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.device_template_id = device_template_id;
this.device_template_idChanged = true;
this.device_id = device_id;
this.device_idChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.is_critical = is_critical;
this.is_criticalChanged = true;
this.is_present = is_present;
this.is_presentChanged = true;
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
#region DeviceTemplateId
private bool device_template_idChanged = false;
private int device_template_id;
public int DeviceTemplateId
{
get { return device_template_id; }
set { 
device_template_id = value;
device_template_idChanged = true;
}
}
private string device_template_idDbString
{
get
{
return device_template_id.ToString();
}
}
#endregion
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
#region IsActive
private bool is_activeChanged = false;
private bool is_active;
public bool IsActive
{
get { return is_active; }
set { 
is_active = value;
is_activeChanged = true;
}
}
private string is_activeDbString
{
get
{
return is_active?"1":"0";
}
}
#endregion
#region IsCritical
private bool is_criticalChanged = false;
private bool is_critical;
public bool IsCritical
{
get { return is_critical; }
set { 
is_critical = value;
is_criticalChanged = true;
}
}
private string is_criticalDbString
{
get
{
return is_critical?"1":"0";
}
}
#endregion
#region IsPresent
private bool is_presentChanged = false;
private bool is_present;
public bool IsPresent
{
get { return is_present; }
set { 
is_present = value;
is_presentChanged = true;
}
}
private string is_presentDbString
{
get
{
return is_present?"1":"0";
}
}
#endregion
#endregion

#region AtmDevicesReader
public class AtmDevicesReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmDevices currentAtmDevices;
Columns columns;
bool partialRead = false;
private AtmDevicesReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmDevicesReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmDevicesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmDevices; }

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
currentAtmDevices = new AtmDevices();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmDevices.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.device_template_id) == Columns.device_template_id && reader["device_template_id"]!=DBNull.Value)
currentAtmDevices.device_template_id =(int) reader["device_template_id"]; 
if ((columns & Columns.device_id) == Columns.device_id && reader["device_id"]!=DBNull.Value)
currentAtmDevices.device_id =(int) reader["device_id"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentAtmDevices.is_active =(bool) reader["is_active"]; 
if ((columns & Columns.is_critical) == Columns.is_critical && reader["is_critical"]!=DBNull.Value)
currentAtmDevices.is_critical =(bool) reader["is_critical"]; 
if ((columns & Columns.is_present) == Columns.is_present && reader["is_present"]!=DBNull.Value)
currentAtmDevices.is_present =(bool) reader["is_present"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentAtmDevices.atm_id = (int) reader["atm_id"]; 
if (reader["device_template_id"] != DBNull.Value)
currentAtmDevices.device_template_id = (int) reader["device_template_id"]; 
if (reader["device_id"] != DBNull.Value)
currentAtmDevices.device_id = (int) reader["device_id"]; 
if (reader["is_active"] != DBNull.Value)
currentAtmDevices.is_active = (bool) reader["is_active"]; 
if (reader["is_critical"] != DBNull.Value)
currentAtmDevices.is_critical = (bool) reader["is_critical"]; 
if (reader["is_present"] != DBNull.Value)
currentAtmDevices.is_present = (bool) reader["is_present"]; 
} 

currentAtmDevices.isNewEntity = false;
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

public AtmDevices CurrentAtmDevices
{
get{ return currentAtmDevices; }
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


#region AtmDevices functions

public static AtmDevicesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.device_template_id == (Columns.device_template_id & columns))
qry.Append("device_template_id,");
if (Columns.device_id == (Columns.device_id & columns))
qry.Append("device_id,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
if (Columns.is_critical == (Columns.is_critical & columns))
qry.Append("is_critical,");
if (Columns.is_present == (Columns.is_present & columns))
qry.Append("is_present,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_devices ");

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
return new AtmDevicesReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmDevicesReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmDevicesReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,device_template_id,device_id,is_active,is_critical,is_present from Atm_devices ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmDevicesReader(cmd.ExecuteReader(), conn);
}

static public AtmDevicesReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmDevices LoadAtmDevices(string where)
{
AtmDevicesReader reader = AtmDevices.ExecuteReader(where);
AtmDevices _atmdevices = null;
if (reader.Read())
_atmdevices = reader.CurrentAtmDevices;
reader.Close();
return _atmdevices;
}

public static AtmDevices LoadAtmDevices(string where, IDbConnection conn)
{
AtmDevicesReader reader = AtmDevices.ExecuteReader(where, conn);
AtmDevices _atmdevices = null;
if (reader.Read())
_atmdevices = reader.CurrentAtmDevices;
reader.Close(false);
return _atmdevices;
}

public static AtmDevices LoadAtmDevicesByPk( int atm_id,int device_template_id,int device_id )
{
return LoadAtmDevices( " atm_id="+atm_id+" and device_template_id="+device_template_id+" and device_id="+device_id );
}

public static AtmDevices LoadAtmDevicesByPk( int atm_id,int device_template_id,int device_id , IDbConnection conn)
{
return LoadAtmDevices(" atm_id="+atm_id+" and device_template_id="+device_template_id+" and device_id="+device_id , conn);
}

public void Save()
{
if (atm_idChanged || device_template_idChanged || device_idChanged || is_activeChanged || is_criticalChanged || is_presentChanged )
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
if (atm_idChanged || device_template_idChanged || device_idChanged || is_activeChanged || is_criticalChanged || is_presentChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_devices( atm_id,device_template_id,device_id,is_active,is_critical,is_present ) values(");
lock (ConnectionFactory.connectionString) { this.atm_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_id);
} qry.Append(",");
lock (ConnectionFactory.connectionString) { this.device_template_id = ConnectionFactory.GetNextId();
qry.Append(this.device_template_id);
} qry.Append(",");
lock (ConnectionFactory.connectionString) { this.device_id = ConnectionFactory.GetNextId();
qry.Append(this.device_id);
} qry.Append(",");
qry.Append(is_activeDbString+",");
qry.Append(is_criticalDbString+",");
qry.Append(is_presentDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || device_template_idChanged || device_idChanged || is_activeChanged || is_criticalChanged || is_presentChanged ))
return;
qry.Append("UPDATE Atm_devices set "); if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}

if ( is_criticalChanged )
{
qry.Append("is_critical ="+is_criticalDbString);
qry.Append(",");
}

if ( is_presentChanged )
{
qry.Append("is_present ="+is_presentDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_id = "+atm_idDbString);
qry.Append(" and device_template_id = "+device_template_idDbString);
qry.Append(" and device_id = "+device_idDbString);
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
cmd.CommandText = "DELETE Atm_devices where atm_id = "+ atm_id +" and device_template_id = "+ device_template_id +" and device_id = "+ device_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmDevicess(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_devices where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
device_template_id= 2,
device_id= 4,
is_active= 8,
is_critical= 16,
is_present= 32
}
#endregion
public void BulkSave(List<AtmDevices> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_devices";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmDevices.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmDevices> transList,ref DataTable dt)
{
foreach (AtmDevices tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] =ConnectionFactory.GetNextId();
Row["device_template_id"] =ConnectionFactory.GetNextId();
Row["device_id"] =ConnectionFactory.GetNextId();
Row["is_active"] = tran.IsActive;
Row["is_critical"] = tran.IsCritical;
Row["is_present"] = tran.IsPresent;
dt.Rows.Add(Row);
} }
}
}
