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
public class DispensedLogic
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public DispensedLogic() { }
public DispensedLogic( int dispensed_logic_id,int atm_id,int amount,int operator_id ) 
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.operator_id = operator_id;
this.operator_idChanged = true;
}
public DispensedLogic( int atm_id,int amount,bool? type1,bool? type2,bool? type3,bool? type4,int operator_id )
{
this.atm_id = atm_id;
this.atm_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.type1 = type1;
this.type1Changed = true;
this.type2 = type2;
this.type2Changed = true;
this.type3 = type3;
this.type3Changed = true;
this.type4 = type4;
this.type4Changed = true;
this.operator_id = operator_id;
this.operator_idChanged = true;
}
private DispensedLogic( int dispensed_logic_id,int atm_id,int amount,bool? type1,bool? type2,bool? type3,bool? type4,int operator_id )
{
this.dispensed_logic_id = dispensed_logic_id;
this.dispensed_logic_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
this.amount = amount;
this.amountChanged = true;
this.type1 = type1;
this.type1Changed = true;
this.type2 = type2;
this.type2Changed = true;
this.type3 = type3;
this.type3Changed = true;
this.type4 = type4;
this.type4Changed = true;
this.operator_id = operator_id;
this.operator_idChanged = true;
}

#region members and properties for columns

#region DispensedLogicId
private bool dispensed_logic_idChanged = false;
private int dispensed_logic_id;
public int DispensedLogicId
{
get { return dispensed_logic_id; }
set { 
dispensed_logic_id = value;
dispensed_logic_idChanged = true;
}
}
private string dispensed_logic_idDbString
{
get
{
return dispensed_logic_id.ToString();
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
#region Amount
private bool amountChanged = false;
private int amount;
public int Amount
{
get { return amount; }
set { 
amount = value;
amountChanged = true;
}
}
private string amountDbString
{
get
{
return amount.ToString();
}
}
#endregion
#region Type1
private bool type1Changed = false;
private bool? type1;
public bool? Type1
{
get { return type1; }
set { 
type1 = value;
type1Changed = true;
}
}
private string type1DbString
{
get
{
if (this.type1.HasValue)
return type1.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Type2
private bool type2Changed = false;
private bool? type2;
public bool? Type2
{
get { return type2; }
set { 
type2 = value;
type2Changed = true;
}
}
private string type2DbString
{
get
{
if (this.type2.HasValue)
return type2.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Type3
private bool type3Changed = false;
private bool? type3;
public bool? Type3
{
get { return type3; }
set { 
type3 = value;
type3Changed = true;
}
}
private string type3DbString
{
get
{
if (this.type3.HasValue)
return type3.Value?"1":"0";
else
return "null";
}
}
#endregion
#region Type4
private bool type4Changed = false;
private bool? type4;
public bool? Type4
{
get { return type4; }
set { 
type4 = value;
type4Changed = true;
}
}
private string type4DbString
{
get
{
if (this.type4.HasValue)
return type4.Value?"1":"0";
else
return "null";
}
}
#endregion
#region OperatorId
private bool operator_idChanged = false;
private int operator_id;
public int OperatorId
{
get { return operator_id; }
set { 
operator_id = value;
operator_idChanged = true;
}
}
private string operator_idDbString
{
get
{
return operator_id.ToString();
}
}
#endregion
#endregion

#region DispensedLogicReader
public class DispensedLogicReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
DispensedLogic currentDispensedLogic;
Columns columns;
bool partialRead = false;
private DispensedLogicReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public DispensedLogicReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public DispensedLogicReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentDispensedLogic; }

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
currentDispensedLogic = new DispensedLogic();
if (partialRead)
{ if ((columns & Columns.dispensed_logic_id) == Columns.dispensed_logic_id && reader["dispensed_logic_id"]!=DBNull.Value)
currentDispensedLogic.dispensed_logic_id =(int) reader["dispensed_logic_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentDispensedLogic.atm_id =(int) reader["atm_id"]; 
if ((columns & Columns.amount) == Columns.amount && reader["amount"]!=DBNull.Value)
currentDispensedLogic.amount =(int) reader["amount"]; 
if ((columns & Columns.type1) == Columns.type1 && reader["type1"]!=DBNull.Value)
currentDispensedLogic.type1 =(bool?) reader["type1"]; 
if ((columns & Columns.type2) == Columns.type2 && reader["type2"]!=DBNull.Value)
currentDispensedLogic.type2 =(bool?) reader["type2"]; 
if ((columns & Columns.type3) == Columns.type3 && reader["type3"]!=DBNull.Value)
currentDispensedLogic.type3 =(bool?) reader["type3"]; 
if ((columns & Columns.type4) == Columns.type4 && reader["type4"]!=DBNull.Value)
currentDispensedLogic.type4 =(bool?) reader["type4"]; 
if ((columns & Columns.operator_id) == Columns.operator_id && reader["operator_id"]!=DBNull.Value)
currentDispensedLogic.operator_id =(int) reader["operator_id"]; 

} else
{
if (reader["dispensed_logic_id"] != DBNull.Value)
currentDispensedLogic.dispensed_logic_id = (int) reader["dispensed_logic_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentDispensedLogic.atm_id = (int) reader["atm_id"]; 
if (reader["amount"] != DBNull.Value)
currentDispensedLogic.amount = (int) reader["amount"]; 
if (reader["type1"] != DBNull.Value)
currentDispensedLogic.type1 = (bool?) reader["type1"]; 
if (reader["type2"] != DBNull.Value)
currentDispensedLogic.type2 = (bool?) reader["type2"]; 
if (reader["type3"] != DBNull.Value)
currentDispensedLogic.type3 = (bool?) reader["type3"]; 
if (reader["type4"] != DBNull.Value)
currentDispensedLogic.type4 = (bool?) reader["type4"]; 
if (reader["operator_id"] != DBNull.Value)
currentDispensedLogic.operator_id = (int) reader["operator_id"]; 
} 

currentDispensedLogic.isNewEntity = false;
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

public DispensedLogic CurrentDispensedLogic
{
get{ return currentDispensedLogic; }
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


#region DispensedLogic functions

public static DispensedLogicReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.dispensed_logic_id == (Columns.dispensed_logic_id & columns))
qry.Append("dispensed_logic_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
if (Columns.amount == (Columns.amount & columns))
qry.Append("amount,");
if (Columns.type1 == (Columns.type1 & columns))
qry.Append("type1,");
if (Columns.type2 == (Columns.type2 & columns))
qry.Append("type2,");
if (Columns.type3 == (Columns.type3 & columns))
qry.Append("type3,");
if (Columns.type4 == (Columns.type4 & columns))
qry.Append("type4,");
if (Columns.operator_id == (Columns.operator_id & columns))
qry.Append("operator_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Dispensed_logic ");

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
return new DispensedLogicReader(cmd.ExecuteReader(), conn, columns);
}

static public DispensedLogicReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static DispensedLogicReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select dispensed_logic_id,atm_id,amount,type1,type2,type3,type4,operator_id from Dispensed_logic ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new DispensedLogicReader(cmd.ExecuteReader(), conn);
}

static public DispensedLogicReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static DispensedLogic LoadDispensedLogic(string where)
{
DispensedLogicReader reader = DispensedLogic.ExecuteReader(where);
DispensedLogic _dispensedlogic = null;
if (reader.Read())
_dispensedlogic = reader.CurrentDispensedLogic;
reader.Close();
return _dispensedlogic;
}

public static DispensedLogic LoadDispensedLogic(string where, IDbConnection conn)
{
DispensedLogicReader reader = DispensedLogic.ExecuteReader(where, conn);
DispensedLogic _dispensedlogic = null;
if (reader.Read())
_dispensedlogic = reader.CurrentDispensedLogic;
reader.Close(false);
return _dispensedlogic;
}

public static DispensedLogic LoadDispensedLogicByPk( int dispensed_logic_id )
{
return LoadDispensedLogic( " dispensed_logic_id="+dispensed_logic_id );
}

public static DispensedLogic LoadDispensedLogicByPk( int dispensed_logic_id , IDbConnection conn)
{
return LoadDispensedLogic(" dispensed_logic_id="+dispensed_logic_id , conn);
}

public void Save()
{
if (dispensed_logic_idChanged || atm_idChanged || amountChanged || type1Changed || type2Changed || type3Changed || type4Changed || operator_idChanged )
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
if (dispensed_logic_idChanged || atm_idChanged || amountChanged || type1Changed || type2Changed || type3Changed || type4Changed || operator_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Dispensed_logic( dispensed_logic_id,atm_id,amount,type1,type2,type3,type4,operator_id ) values(");
lock (ConnectionFactory.connectionString) { this.dispensed_logic_id = ConnectionFactory.GetNextId();
qry.Append(this.dispensed_logic_id);
} qry.Append(",");
qry.Append(atm_idDbString+",");
qry.Append(amountDbString+",");
qry.Append(type1DbString+",");
qry.Append(type2DbString+",");
qry.Append(type3DbString+",");
qry.Append(type4DbString+",");
qry.Append(operator_idDbString);
qry.Append(");");

}
else
{
if (!(dispensed_logic_idChanged || atm_idChanged || amountChanged || type1Changed || type2Changed || type3Changed || type4Changed || operator_idChanged ))
return;
qry.Append("UPDATE Dispensed_logic set "); if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}

if ( amountChanged )
{
qry.Append("amount ="+amountDbString);
qry.Append(",");
}

if ( type1Changed )
{
qry.Append("type1 ="+type1DbString);
qry.Append(",");
}

if ( type2Changed )
{
qry.Append("type2 ="+type2DbString);
qry.Append(",");
}

if ( type3Changed )
{
qry.Append("type3 ="+type3DbString);
qry.Append(",");
}

if ( type4Changed )
{
qry.Append("type4 ="+type4DbString);
qry.Append(",");
}

if ( operator_idChanged )
{
qry.Append("operator_id ="+operator_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("dispensed_logic_id = "+dispensed_logic_idDbString);
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
cmd.CommandText = "DELETE Dispensed_logic where dispensed_logic_id = "+ dispensed_logic_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteDispensedLogics(string where)
{
ConnectionFactory.ExecuteQuery("delete Dispensed_logic where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
dispensed_logic_id= 1,
atm_id= 2,
amount= 4,
type1= 8,
type2= 16,
type3= 32,
type4= 64,
operator_id= 128
}
#endregion
public void BulkSave(List<DispensedLogic> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Dispensed_logic";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(DispensedLogic.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <DispensedLogic> transList,ref DataTable dt)
{
foreach (DispensedLogic tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["dispensed_logic_id"] =ConnectionFactory.GetNextId();
Row["atm_id"] = tran.AtmId;
Row["amount"] = tran.Amount;
Row["type1"] = tran.Type1;
Row["type2"] = tran.Type2;
Row["type3"] = tran.Type3;
Row["type4"] = tran.Type4;
Row["operator_id"] = tran.OperatorId;
dt.Rows.Add(Row);
} }
}
}
