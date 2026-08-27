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
public class AtmSoftwareInventory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmSoftwareInventory() { }
public AtmSoftwareInventory( int atm_id,string installed_program,DateTime generated_at )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.installed_program = installed_program;
this.installed_programChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}
private AtmSoftwareInventory( int atm_software_inventory_id,int atm_id,string installed_program,DateTime generated_at )
{
this.atm_software_inventory_id = atm_software_inventory_id;
this.atm_software_inventory_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.installed_program = installed_program;
this.installed_programChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}

#region members and properties for columns

#region AtmSoftwareInventoryId
private bool atm_software_inventory_idChanged = false;
private int atm_software_inventory_id;
public int AtmSoftwareInventoryId
{
get { return atm_software_inventory_id; }
set { 
atm_software_inventory_id = value;
atm_software_inventory_idChanged = true;
}
}
private string atm_software_inventory_idDbString
{
get
{
return atm_software_inventory_id.ToString();
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
#region InstalledProgram
private bool installed_programChanged = false;
private string installed_program;
public string InstalledProgram
{
get { return installed_program; }
set { 
installed_program = value;
installed_programChanged = true;
}
}
private string installed_programDbString
{
get
{
if (this.installed_program!=null)
return string.Format("'{0}'",installed_program); else
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

#region AtmSoftwareInventoryReader
public class AtmSoftwareInventoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmSoftwareInventory currentAtmSoftwareInventory;
Columns columns;
bool partialRead = false;
private AtmSoftwareInventoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmSoftwareInventoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmSoftwareInventoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmSoftwareInventory; }

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
currentAtmSoftwareInventory = new AtmSoftwareInventory();
if (partialRead)
{ if ((columns & Columns.atm_software_inventory_id) == Columns.atm_software_inventory_id && reader["atm_software_inventory_id"]!=DBNull.Value)
currentAtmSoftwareInventory.atm_software_inventory_id =(int) reader["atm_software_inventory_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmSoftwareInventory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.installed_program) == Columns.installed_program && reader["installed_program"]!=DBNull.Value)
currentAtmSoftwareInventory.installed_program =(string) reader["installed_program"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentAtmSoftwareInventory.generated_at =(DateTime) reader["generated_at"]; 

} else
{
if (reader["atm_software_inventory_id"] != DBNull.Value)
currentAtmSoftwareInventory.atm_software_inventory_id = (int) reader["atm_software_inventory_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmSoftwareInventory.atm_id = (int) reader["atm_id"]; 
if (reader["installed_program"] != DBNull.Value)
currentAtmSoftwareInventory.installed_program = (string) reader["installed_program"]; 
if (reader["generated_at"] != DBNull.Value)
currentAtmSoftwareInventory.generated_at = (DateTime) reader["generated_at"]; 
} 

currentAtmSoftwareInventory.isNewEntity = false;
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

public AtmSoftwareInventory CurrentAtmSoftwareInventory
{
get{ return currentAtmSoftwareInventory; }
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


#region AtmSoftwareInventory functions

public static AtmSoftwareInventoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_software_inventory_id == (Columns.atm_software_inventory_id & columns))
qry.Append("atm_software_inventory_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.installed_program == (Columns.installed_program & columns))
qry.Append("installed_program,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_software_inventory ");

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
return new AtmSoftwareInventoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmSoftwareInventoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmSoftwareInventoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_software_inventory_id,atm_id,installed_program,generated_at from Atm_software_inventory ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmSoftwareInventoryReader(cmd.ExecuteReader(), conn);
}

static public AtmSoftwareInventoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmSoftwareInventory LoadAtmSoftwareInventory(string where)
{
AtmSoftwareInventoryReader reader = AtmSoftwareInventory.ExecuteReader(where);
AtmSoftwareInventory _atmsoftwareinventory = null;
if (reader.Read())
_atmsoftwareinventory = reader.CurrentAtmSoftwareInventory;
reader.Close();
return _atmsoftwareinventory;
}

public static AtmSoftwareInventory LoadAtmSoftwareInventory(string where, IDbConnection conn)
{
AtmSoftwareInventoryReader reader = AtmSoftwareInventory.ExecuteReader(where, conn);
AtmSoftwareInventory _atmsoftwareinventory = null;
if (reader.Read())
_atmsoftwareinventory = reader.CurrentAtmSoftwareInventory;
reader.Close(false);
return _atmsoftwareinventory;
}

public static AtmSoftwareInventory LoadAtmSoftwareInventoryByPk( int atm_software_inventory_id )
{
return LoadAtmSoftwareInventory( " atm_software_inventory_id="+atm_software_inventory_id );
}

public static AtmSoftwareInventory LoadAtmSoftwareInventoryByPk( int atm_software_inventory_id , IDbConnection conn)
{
return LoadAtmSoftwareInventory(" atm_software_inventory_id="+atm_software_inventory_id , conn);
}

public void Save()
{
if (atm_software_inventory_idChanged || atm_idChanged || installed_programChanged || generated_atChanged )
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
if (atm_software_inventory_idChanged || atm_idChanged || installed_programChanged || generated_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_software_inventory( atm_software_inventory_id,atm_id,installed_program,generated_at ) values(");
lock (ConnectionFactory.connectionString) { this.atm_software_inventory_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_software_inventory_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(installed_programDbString+",");
qry.Append(generated_atDbString);
qry.Append(");");

}
else
{
if (!(atm_software_inventory_idChanged || atm_idChanged || installed_programChanged || generated_atChanged ))
return;
qry.Append("UPDATE Atm_software_inventory set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( installed_programChanged )
{
qry.Append("installed_program ="+installed_programDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_software_inventory_id = "+atm_software_inventory_idDbString);
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
cmd.CommandText = "DELETE Atm_software_inventory where atm_software_inventory_id = "+ atm_software_inventory_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmSoftwareInventorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_software_inventory where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_software_inventory_id= 1,
atm_id= 2,
installed_program= 4,
generated_at= 8
}
#endregion
public void BulkSave(List<AtmSoftwareInventory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_software_inventory";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmSoftwareInventory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmSoftwareInventory> transList,ref DataTable dt)
{
foreach (AtmSoftwareInventory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_software_inventory_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["installed_program"] = tran.InstalledProgram;
Row["generated_at"] = tran.GeneratedAt;
dt.Rows.Add(Row);
} }
}
}
