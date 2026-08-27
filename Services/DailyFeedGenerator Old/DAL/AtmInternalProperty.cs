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
public class AtmInternalProperty
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmInternalProperty() { }
public AtmInternalProperty( string device_name,string property_name,string property_value )
{
this.device_name = device_name;
this.device_nameChanged = true;
this.property_name = property_name;
this.property_nameChanged = true;
this.property_value = property_value;
this.property_valueChanged = true;
}
private AtmInternalProperty( int atm_id,string device_name,string property_name,string property_value )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.device_name = device_name;
this.device_nameChanged = true;
this.property_name = property_name;
this.property_nameChanged = true;
this.property_value = property_value;
this.property_valueChanged = true;
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
#region DeviceName
private bool device_nameChanged = false;
private string device_name;
public string DeviceName
{
get { return device_name; }
set { 
device_name = value;
device_nameChanged = true;
}
}
private string device_nameDbString
{
get
{
if (this.device_name!=null)
return string.Format("'{0}'",device_name); else
return "null";
}
}
#endregion
#region PropertyName
private bool property_nameChanged = false;
private string property_name;
public string PropertyName
{
get { return property_name; }
set { 
property_name = value;
property_nameChanged = true;
}
}
private string property_nameDbString
{
get
{
if (this.property_name!=null)
return string.Format("'{0}'",property_name); else
return "null";
}
}
#endregion
#region PropertyValue
private bool property_valueChanged = false;
private string property_value;
public string PropertyValue
{
get { return property_value; }
set { 
property_value = value;
property_valueChanged = true;
}
}
private string property_valueDbString
{
get
{
if (this.property_value!=null)
return string.Format("'{0}'",property_value); else
return "null";
}
}
#endregion
#endregion

#region AtmInternalPropertyReader
public class AtmInternalPropertyReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmInternalProperty currentAtmInternalProperty;
Columns columns;
bool partialRead = false;
private AtmInternalPropertyReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmInternalPropertyReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmInternalPropertyReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmInternalProperty; }

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
currentAtmInternalProperty = new AtmInternalProperty();
if (partialRead)
{ if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmInternalProperty.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.device_name) == Columns.device_name && reader["device_name"]!=DBNull.Value)
currentAtmInternalProperty.device_name =(string) reader["device_name"]; 
if ((columns & Columns.property_name) == Columns.property_name && reader["property_name"]!=DBNull.Value)
currentAtmInternalProperty.property_name =(string) reader["property_name"]; 
if ((columns & Columns.property_value) == Columns.property_value && reader["property_value"]!=DBNull.Value)
currentAtmInternalProperty.property_value =(string) reader["property_value"]; 

} else
{
if (reader["atm_id"] != DBNull.Value)
currentAtmInternalProperty.atm_id = (int) reader["atm_id"]; 
if (reader["device_name"] != DBNull.Value)
currentAtmInternalProperty.device_name = (string) reader["device_name"]; 
if (reader["property_name"] != DBNull.Value)
currentAtmInternalProperty.property_name = (string) reader["property_name"]; 
if (reader["property_value"] != DBNull.Value)
currentAtmInternalProperty.property_value = (string) reader["property_value"]; 
} 

currentAtmInternalProperty.isNewEntity = false;
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

public AtmInternalProperty CurrentAtmInternalProperty
{
get{ return currentAtmInternalProperty; }
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


#region AtmInternalProperty functions

public static AtmInternalPropertyReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.device_name == (Columns.device_name & columns))
qry.Append("device_name,");
if (Columns.property_name == (Columns.property_name & columns))
qry.Append("property_name,");
if (Columns.property_value == (Columns.property_value & columns))
qry.Append("property_value,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_internal_property ");

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
return new AtmInternalPropertyReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmInternalPropertyReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmInternalPropertyReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_id,device_name,property_name,property_value from Atm_internal_property ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmInternalPropertyReader(cmd.ExecuteReader(), conn);
}

static public AtmInternalPropertyReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmInternalProperty LoadAtmInternalProperty(string where)
{
AtmInternalPropertyReader reader = AtmInternalProperty.ExecuteReader(where);
AtmInternalProperty _atminternalproperty = null;
if (reader.Read())
_atminternalproperty = reader.CurrentAtmInternalProperty;
reader.Close();
return _atminternalproperty;
}

public static AtmInternalProperty LoadAtmInternalProperty(string where, IDbConnection conn)
{
AtmInternalPropertyReader reader = AtmInternalProperty.ExecuteReader(where, conn);
AtmInternalProperty _atminternalproperty = null;
if (reader.Read())
_atminternalproperty = reader.CurrentAtmInternalProperty;
reader.Close(false);
return _atminternalproperty;
}

public static AtmInternalProperty LoadAtmInternalPropertyByPk( int atm_id,string device_name,string property_name )
{
return LoadAtmInternalProperty( " atm_id="+atm_id+" and device_name="+device_name+" and property_name="+property_name );
}

public static AtmInternalProperty LoadAtmInternalPropertyByPk( int atm_id,string device_name,string property_name , IDbConnection conn)
{
return LoadAtmInternalProperty(" atm_id="+atm_id+" and device_name="+device_name+" and property_name="+property_name , conn);
}

public void Save()
{
if (atm_idChanged || device_nameChanged || property_nameChanged || property_valueChanged )
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
if (atm_idChanged || device_nameChanged || property_nameChanged || property_valueChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_internal_property( atm_id,device_name,property_name,property_value ) values(");
lock (ConnectionFactory.connectionString) { this.atm_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_id);
} qry.Append(",");
qry.Append(device_nameDbString+",");
qry.Append(property_nameDbString+",");
qry.Append(property_valueDbString);
qry.Append(");");

}
else
{
if (!(atm_idChanged || device_nameChanged || property_nameChanged || property_valueChanged ))
return;
qry.Append("UPDATE Atm_internal_property set "); if ( property_valueChanged )
{
qry.Append("property_value ="+property_valueDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_id = "+atm_idDbString);
qry.Append(" and device_name = "+device_nameDbString);
qry.Append(" and property_name = "+property_nameDbString);
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
cmd.CommandText = "DELETE Atm_internal_property where atm_id = "+ atm_id +" and device_name = "+ device_name +" and property_name = "+ property_name;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmInternalPropertys(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_internal_property where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_id= 1,
device_name= 2,
property_name= 4,
property_value= 8
}
#endregion
public void BulkSave(List<AtmInternalProperty> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_internal_property";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmInternalProperty.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmInternalProperty> transList,ref DataTable dt)
{
foreach (AtmInternalProperty tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_id"] =ConnectionFactory.GetNextId();
Row["device_name"] = tran.DeviceName;
Row["property_name"] = tran.PropertyName;
Row["property_value"] = tran.PropertyValue;
dt.Rows.Add(Row);
} }
}
}
