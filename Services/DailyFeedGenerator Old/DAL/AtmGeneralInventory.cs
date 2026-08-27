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
public class AtmGeneralInventory
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmGeneralInventory() { }
public AtmGeneralInventory( int atm_id,string name,string field_value,DateTime generated_at )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.name = name;
this.nameChanged = true;
this.field_value = field_value;
this.field_valueChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}
private AtmGeneralInventory( int atm_general_inventory_id,int atm_id,string name,string field_value,DateTime generated_at )
{
this.atm_general_inventory_id = atm_general_inventory_id;
this.atm_general_inventory_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.name = name;
this.nameChanged = true;
this.field_value = field_value;
this.field_valueChanged = true;
this.generated_at = generated_at;
this.generated_atChanged = true;
}

#region members and properties for columns

#region AtmGeneralInventoryId
private bool atm_general_inventory_idChanged = false;
private int atm_general_inventory_id;
public int AtmGeneralInventoryId
{
get { return atm_general_inventory_id; }
set { 
atm_general_inventory_id = value;
atm_general_inventory_idChanged = true;
}
}
private string atm_general_inventory_idDbString
{
get
{
return atm_general_inventory_id.ToString();
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
#region Name
private bool nameChanged = false;
private string name;
public string Name
{
get { return name; }
set { 
name = value;
nameChanged = true;
}
}
private string nameDbString
{
get
{
if (this.name!=null)
return string.Format("'{0}'",name); else
return "null";
}
}
#endregion
#region FieldValue
private bool field_valueChanged = false;
private string field_value;
public string FieldValue
{
get { return field_value; }
set { 
field_value = value;
field_valueChanged = true;
}
}
private string field_valueDbString
{
get
{
if (this.field_value!=null)
return string.Format("'{0}'",field_value); else
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

#region AtmGeneralInventoryReader
public class AtmGeneralInventoryReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmGeneralInventory currentAtmGeneralInventory;
Columns columns;
bool partialRead = false;
private AtmGeneralInventoryReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmGeneralInventoryReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmGeneralInventoryReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmGeneralInventory; }

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
currentAtmGeneralInventory = new AtmGeneralInventory();
if (partialRead)
{ if ((columns & Columns.atm_general_inventory_id) == Columns.atm_general_inventory_id && reader["atm_general_inventory_id"]!=DBNull.Value)
currentAtmGeneralInventory.atm_general_inventory_id =(int) reader["atm_general_inventory_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmGeneralInventory.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.name) == Columns.name && reader["name"]!=DBNull.Value)
currentAtmGeneralInventory.name =(string) reader["name"]; 
if ((columns & Columns.field_value) == Columns.field_value && reader["field_value"]!=DBNull.Value)
currentAtmGeneralInventory.field_value =(string) reader["field_value"]; 
if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
currentAtmGeneralInventory.generated_at =(DateTime) reader["generated_at"]; 

} else
{
if (reader["atm_general_inventory_id"] != DBNull.Value)
currentAtmGeneralInventory.atm_general_inventory_id = (int) reader["atm_general_inventory_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmGeneralInventory.atm_id = (int) reader["atm_id"]; 
if (reader["name"] != DBNull.Value)
currentAtmGeneralInventory.name = (string) reader["name"]; 
if (reader["field_value"] != DBNull.Value)
currentAtmGeneralInventory.field_value = (string) reader["field_value"]; 
if (reader["generated_at"] != DBNull.Value)
currentAtmGeneralInventory.generated_at = (DateTime) reader["generated_at"]; 
} 

currentAtmGeneralInventory.isNewEntity = false;
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

public AtmGeneralInventory CurrentAtmGeneralInventory
{
get{ return currentAtmGeneralInventory; }
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


#region AtmGeneralInventory functions

public static AtmGeneralInventoryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_general_inventory_id == (Columns.atm_general_inventory_id & columns))
qry.Append("atm_general_inventory_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.name == (Columns.name & columns))
qry.Append("name,");
if (Columns.field_value == (Columns.field_value & columns))
qry.Append("field_value,");
if (Columns.generated_at == (Columns.generated_at & columns))
qry.Append("generated_at,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_general_inventory ");

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
return new AtmGeneralInventoryReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmGeneralInventoryReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmGeneralInventoryReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_general_inventory_id,atm_id,name,field_value,generated_at from Atm_general_inventory ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmGeneralInventoryReader(cmd.ExecuteReader(), conn);
}

static public AtmGeneralInventoryReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmGeneralInventory LoadAtmGeneralInventory(string where)
{
AtmGeneralInventoryReader reader = AtmGeneralInventory.ExecuteReader(where);
AtmGeneralInventory _atmgeneralinventory = null;
if (reader.Read())
_atmgeneralinventory = reader.CurrentAtmGeneralInventory;
reader.Close();
return _atmgeneralinventory;
}

public static AtmGeneralInventory LoadAtmGeneralInventory(string where, IDbConnection conn)
{
AtmGeneralInventoryReader reader = AtmGeneralInventory.ExecuteReader(where, conn);
AtmGeneralInventory _atmgeneralinventory = null;
if (reader.Read())
_atmgeneralinventory = reader.CurrentAtmGeneralInventory;
reader.Close(false);
return _atmgeneralinventory;
}

public static AtmGeneralInventory LoadAtmGeneralInventoryByPk( int atm_general_inventory_id )
{
return LoadAtmGeneralInventory( " atm_general_inventory_id="+atm_general_inventory_id );
}

public static AtmGeneralInventory LoadAtmGeneralInventoryByPk( int atm_general_inventory_id , IDbConnection conn)
{
return LoadAtmGeneralInventory(" atm_general_inventory_id="+atm_general_inventory_id , conn);
}

public void Save()
{
if (atm_general_inventory_idChanged || atm_idChanged || nameChanged || field_valueChanged || generated_atChanged )
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
if (atm_general_inventory_idChanged || atm_idChanged || nameChanged || field_valueChanged || generated_atChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_general_inventory( atm_general_inventory_id,atm_id,name,field_value,generated_at ) values(");
lock (ConnectionFactory.connectionString) { this.atm_general_inventory_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_general_inventory_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(nameDbString+",");
qry.Append(field_valueDbString+",");
qry.Append(generated_atDbString);
qry.Append(");");

}
else
{
if (!(atm_general_inventory_idChanged || atm_idChanged || nameChanged || field_valueChanged || generated_atChanged ))
return;
qry.Append("UPDATE Atm_general_inventory set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( nameChanged )
{
qry.Append("name ="+nameDbString);
qry.Append(",");
}

if ( field_valueChanged )
{
qry.Append("field_value ="+field_valueDbString);
qry.Append(",");
}

if ( generated_atChanged )
{
qry.Append("generated_at ="+generated_atDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_general_inventory_id = "+atm_general_inventory_idDbString);
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
cmd.CommandText = "DELETE Atm_general_inventory where atm_general_inventory_id = "+ atm_general_inventory_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmGeneralInventorys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_general_inventory where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_general_inventory_id= 1,
atm_id= 2,
name= 4,
field_value= 8,
generated_at= 16
}
#endregion
public void BulkSave(List<AtmGeneralInventory> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_general_inventory";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmGeneralInventory.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmGeneralInventory> transList,ref DataTable dt)
{
foreach (AtmGeneralInventory tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_general_inventory_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["name"] = tran.Name;
Row["field_value"] = tran.FieldValue;
Row["generated_at"] = tran.GeneratedAt;
dt.Rows.Add(Row);
} }
}
}
