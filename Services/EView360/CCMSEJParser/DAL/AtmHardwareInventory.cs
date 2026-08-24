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
public class AtmHardwareInventory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmHardwareInventory() { }
public AtmHardwareInventory( int atm_id,string installed_hardware,DateTime generated_at )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.installed_hardware = installed_hardware;
this.installed_hardwareChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}
private AtmHardwareInventory( int atm_hardware_inventory_id,int atm_id,string installed_hardware,DateTime generated_at )
{
this.atm_hardware_inventory_id = atm_hardware_inventory_id;
this.atm_hardware_inventory_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.installed_hardware = installed_hardware;
this.installed_hardwareChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}

#region members and properties for columns

#region AtmHardwareInventoryId
private bool atm_hardware_inventory_idChanged = false;
private int atm_hardware_inventory_id;
public int AtmHardwareInventoryId
{
get { return atm_hardware_inventory_id; }
set { 
atm_hardware_inventory_id = value;
atm_hardware_inventory_idChanged = true;
}
}
private string atm_hardware_inventory_idDbString
{
get
{
return atm_hardware_inventory_id.ToString();
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
#region InstalledHardware
private bool installed_hardwareChanged = false;
private string installed_hardware;
public string InstalledHardware
{
get { return installed_hardware; }
set { 
installed_hardware = value;
installed_hardwareChanged = true;
}
}
private string installed_hardwareDbString
{
get
{
if (this.installed_hardware!=null)
return string.Format("'{0}'",installed_hardware); else
return "null";
}
}
#endregion
#region GeneratedAt
private bool generated_atChanged = false;
private DateTime generated_at;
public DateTime GeneratedAt
{
get { return generated_at; }
set { 
generated_at = value;
generated_atChanged = true;
}
}
private string generated_atDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region AtmHardwareInventoryReader
public class AtmHardwareInventoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmHardwareInventory currentAtmHardwareInventory;
Columns columns;
bool partialRead = false;
private AtmHardwareInventoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmHardwareInventoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmHardwareInventoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmHardwareInventory; }

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
currentAtmHardwareInventory = new AtmHardwareInventory();
if (partialRead)
{ if ((columns & Columns.atm_hardware_inventory_id) == Columns.atm_hardware_inventory_id && reader["atm_hardware_inventory_id"]!=DBNull.Value)
currentAtmHardwareInventory.atm_hardware_inventory_id =(int) reader["atm_hardware_inventory_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmHardwareInventory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.installed_hardware) == Columns.installed_hardware && reader["installed_hardware"]!=DBNull.Value)
currentAtmHardwareInventory.installed_hardware =(string) reader["installed_hardware"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentAtmHardwareInventory.generated_at =(DateTime) reader["generated_at"]; 

} else
{
if (reader["atm_hardware_inventory_id"] != DBNull.Value)
currentAtmHardwareInventory.atm_hardware_inventory_id = (int) reader["atm_hardware_inventory_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmHardwareInventory.atm_id = (int) reader["atm_id"]; 
if (reader["installed_hardware"] != DBNull.Value)
currentAtmHardwareInventory.installed_hardware = (string) reader["installed_hardware"]; 
if (reader["generated_at"] != DBNull.Value)
currentAtmHardwareInventory.generated_at = (DateTime) reader["generated_at"]; 
} 

currentAtmHardwareInventory.isNewEntity = false;
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

public AtmHardwareInventory CurrentAtmHardwareInventory
{
get{ return currentAtmHardwareInventory; }
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


#region AtmHardwareInventory functions

public static AtmHardwareInventoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_hardware_inventory_id == (Columns.atm_hardware_inventory_id & columns))
qry.Append("atm_hardware_inventory_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.installed_hardware == (Columns.installed_hardware & columns))
qry.Append("installed_hardware,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_hardware_inventory ");

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
return new AtmHardwareInventoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmHardwareInventoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmHardwareInventoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_hardware_inventory_id,atm_id,installed_hardware,generated_at from Atm_hardware_inventory ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmHardwareInventoryReader(cmd.ExecuteReader(), conn);
}

static public AtmHardwareInventoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmHardwareInventory LoadAtmHardwareInventory(string where)
{
AtmHardwareInventoryReader reader = AtmHardwareInventory.ExecuteReader(where);
AtmHardwareInventory _atmhardwareinventory = null;
if (reader.Read())
_atmhardwareinventory = reader.CurrentAtmHardwareInventory;
reader.Close();
return _atmhardwareinventory;
}

public static AtmHardwareInventory LoadAtmHardwareInventory(string where, IDbConnection conn)
{
AtmHardwareInventoryReader reader = AtmHardwareInventory.ExecuteReader(where, conn);
AtmHardwareInventory _atmhardwareinventory = null;
if (reader.Read())
_atmhardwareinventory = reader.CurrentAtmHardwareInventory;
reader.Close(false);
return _atmhardwareinventory;
}

public static AtmHardwareInventory LoadAtmHardwareInventoryByPk( int atm_hardware_inventory_id )
{
return LoadAtmHardwareInventory( " atm_hardware_inventory_id="+atm_hardware_inventory_id );
}

public static AtmHardwareInventory LoadAtmHardwareInventoryByPk( int atm_hardware_inventory_id , IDbConnection conn)
{
return LoadAtmHardwareInventory(" atm_hardware_inventory_id="+atm_hardware_inventory_id , conn);
}

public void Save()
{
if (atm_hardware_inventory_idChanged || atm_idChanged || installed_hardwareChanged || generated_atChanged )
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
if (atm_hardware_inventory_idChanged || atm_idChanged || installed_hardwareChanged || generated_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_hardware_inventory( atm_hardware_inventory_id,atm_id,installed_hardware,generated_at ) values(");
lock (ConnectionFactory.connectionString) { this.atm_hardware_inventory_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_hardware_inventory_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(installed_hardwareDbString+",");
qry.Append(generated_atDbString);
qry.Append(");");

}
else
{
if (!(atm_hardware_inventory_idChanged || atm_idChanged || installed_hardwareChanged || generated_atChanged ))
return;
qry.Append("UPDATE Atm_hardware_inventory set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( installed_hardwareChanged )
{
qry.Append("installed_hardware ="+installed_hardwareDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_hardware_inventory_id = "+atm_hardware_inventory_idDbString);
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
cmd.CommandText = "DELETE Atm_hardware_inventory where atm_hardware_inventory_id = "+ atm_hardware_inventory_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmHardwareInventorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_hardware_inventory where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_hardware_inventory_id= 1,
atm_id= 2,
installed_hardware= 4,
generated_at= 8
}
#endregion
public void BulkSave(List<AtmHardwareInventory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_hardware_inventory";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmHardwareInventory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmHardwareInventory> transList,ref DataTable dt)
{
foreach (AtmHardwareInventory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_hardware_inventory_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["installed_hardware"] = tran.InstalledHardware;
Row["generated_at"] = tran.GeneratedAt;
dt.Rows.Add(Row);
} }
}
}
