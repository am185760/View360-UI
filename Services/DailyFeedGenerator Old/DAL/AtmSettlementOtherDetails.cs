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
public class AtmSettlementOtherDetails
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmSettlementOtherDetails() { }
public AtmSettlementOtherDetails( int atm_settlement_other_details_id,int atm_settlement_id ) 
{
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
}
public AtmSettlementOtherDetails( int atm_settlement_id,int? no_of_replenishment,string inventory,string comments )
{
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
this.no_of_replenishment = no_of_replenishment;
this.no_of_replenishmentChanged = true;
this.inventory = inventory;
this.inventoryChanged = true;
this.comments = comments;
this.commentsChanged = true;
}
private AtmSettlementOtherDetails( int atm_settlement_other_details_id,int atm_settlement_id,int? no_of_replenishment,string inventory,string comments )
{
this.atm_settlement_other_details_id = atm_settlement_other_details_id;
this.atm_settlement_other_details_idChanged = true;
this.atm_settlement_id = atm_settlement_id;
this.atm_settlement_idChanged = true;
this.no_of_replenishment = no_of_replenishment;
this.no_of_replenishmentChanged = true;
this.inventory = inventory;
this.inventoryChanged = true;
this.comments = comments;
this.commentsChanged = true;
}

#region members and properties for columns

#region AtmSettlementOtherDetailsId
private bool atm_settlement_other_details_idChanged = false;
private int atm_settlement_other_details_id;
public int AtmSettlementOtherDetailsId
{
get { return atm_settlement_other_details_id; }
set { 
atm_settlement_other_details_id = value;
atm_settlement_other_details_idChanged = true;
}
}
private string atm_settlement_other_details_idDbString
{
get
{
return atm_settlement_other_details_id.ToString();
}
}
#endregion
#region AtmSettlementId
private bool atm_settlement_idChanged = false;
private int atm_settlement_id;
public int AtmSettlementId
{
get { return atm_settlement_id; }
set { 
atm_settlement_id = value;
atm_settlement_idChanged = true;
}
}
private string atm_settlement_idDbString
{
get
{
return atm_settlement_id.ToString();
}
}
#endregion
#region NoOfReplenishment
private bool no_of_replenishmentChanged = false;
private int? no_of_replenishment;
public int? NoOfReplenishment
{
get { return no_of_replenishment; }
set { 
no_of_replenishment = value;
no_of_replenishmentChanged = true;
}
}
private string no_of_replenishmentDbString
{
get
{
if (this.no_of_replenishment.HasValue)
return no_of_replenishment.ToString();
else
return "null";
}
}
#endregion
#region Inventory
private bool inventoryChanged = false;
private string inventory;
public string Inventory
{
get { return inventory; }
set { 
inventory = value;
inventoryChanged = true;
}
}
private string inventoryDbString
{
get
{
if (this.inventory!=null)
return string.Format("'{0}'",inventory); else
return "null";
}
}
#endregion
#region Comments
private bool commentsChanged = false;
private string comments;
public string Comments
{
get { return comments; }
set { 
comments = value;
commentsChanged = true;
}
}
private string commentsDbString
{
get
{
if (this.comments!=null)
return string.Format("'{0}'",comments); else
return "null";
}
}
#endregion
#endregion

#region AtmSettlementOtherDetailsReader
public class AtmSettlementOtherDetailsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmSettlementOtherDetails currentAtmSettlementOtherDetails;
Columns columns;
bool partialRead = false;
private AtmSettlementOtherDetailsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmSettlementOtherDetailsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmSettlementOtherDetailsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmSettlementOtherDetails; }

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
currentAtmSettlementOtherDetails = new AtmSettlementOtherDetails();
if (partialRead)
{ if ((columns & Columns.atm_settlement_other_details_id) == Columns.atm_settlement_other_details_id && reader["atm_settlement_other_details_id"]!=DBNull.Value)
currentAtmSettlementOtherDetails.atm_settlement_other_details_id =(int) reader["atm_settlement_other_details_id"]; 
if ((columns & Columns.atm_settlement_id) == Columns.atm_settlement_id && reader["atm_settlement_id"]!=DBNull.Value)
currentAtmSettlementOtherDetails.atm_settlement_id =(int) reader["atm_settlement_id"]; 
if ((columns & Columns.no_of_replenishment) == Columns.no_of_replenishment && reader["no_of_replenishment"]!=DBNull.Value)
currentAtmSettlementOtherDetails.no_of_replenishment =(int?) reader["no_of_replenishment"]; 
if ((columns & Columns.inventory) == Columns.inventory && reader["inventory"]!=DBNull.Value)
currentAtmSettlementOtherDetails.inventory =(string) reader["inventory"]; 
if ((columns & Columns.comments) == Columns.comments && reader["comments"]!=DBNull.Value)
currentAtmSettlementOtherDetails.comments =(string) reader["comments"]; 

} else
{
if (reader["atm_settlement_other_details_id"] != DBNull.Value)
currentAtmSettlementOtherDetails.atm_settlement_other_details_id = (int) reader["atm_settlement_other_details_id"]; 
if (reader["atm_settlement_id"] != DBNull.Value)
currentAtmSettlementOtherDetails.atm_settlement_id = (int) reader["atm_settlement_id"]; 
if (reader["no_of_replenishment"] != DBNull.Value)
currentAtmSettlementOtherDetails.no_of_replenishment = (int?) reader["no_of_replenishment"]; 
if (reader["inventory"] != DBNull.Value)
currentAtmSettlementOtherDetails.inventory = (string) reader["inventory"]; 
if (reader["comments"] != DBNull.Value)
currentAtmSettlementOtherDetails.comments = (string) reader["comments"]; 
} 

currentAtmSettlementOtherDetails.isNewEntity = false;
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

public AtmSettlementOtherDetails CurrentAtmSettlementOtherDetails
{
get{ return currentAtmSettlementOtherDetails; }
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


#region AtmSettlementOtherDetails functions

public static AtmSettlementOtherDetailsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atm_settlement_other_details_id == (Columns.atm_settlement_other_details_id & columns))
qry.Append("atm_settlement_other_details_id,");
if (Columns.atm_settlement_id == (Columns.atm_settlement_id & columns))
qry.Append("atm_settlement_id,");
if (Columns.no_of_replenishment == (Columns.no_of_replenishment & columns))
qry.Append("no_of_replenishment,");
if (Columns.inventory == (Columns.inventory & columns))
qry.Append("inventory,");
if (Columns.comments == (Columns.comments & columns))
qry.Append("comments,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atm_settlement_other_details ");

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
return new AtmSettlementOtherDetailsReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmSettlementOtherDetailsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmSettlementOtherDetailsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atm_settlement_other_details_id,atm_settlement_id,no_of_replenishment,inventory,comments from Atm_settlement_other_details ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmSettlementOtherDetailsReader(cmd.ExecuteReader(), conn);
}

static public AtmSettlementOtherDetailsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmSettlementOtherDetails LoadAtmSettlementOtherDetails(string where)
{
AtmSettlementOtherDetailsReader reader = AtmSettlementOtherDetails.ExecuteReader(where);
AtmSettlementOtherDetails _atmsettlementotherdetails = null;
if (reader.Read())
_atmsettlementotherdetails = reader.CurrentAtmSettlementOtherDetails;
reader.Close();
return _atmsettlementotherdetails;
}

public static AtmSettlementOtherDetails LoadAtmSettlementOtherDetails(string where, IDbConnection conn)
{
AtmSettlementOtherDetailsReader reader = AtmSettlementOtherDetails.ExecuteReader(where, conn);
AtmSettlementOtherDetails _atmsettlementotherdetails = null;
if (reader.Read())
_atmsettlementotherdetails = reader.CurrentAtmSettlementOtherDetails;
reader.Close(false);
return _atmsettlementotherdetails;
}

public static AtmSettlementOtherDetails LoadAtmSettlementOtherDetailsByPk( int atm_settlement_other_details_id )
{
return LoadAtmSettlementOtherDetails( " atm_settlement_other_details_id="+atm_settlement_other_details_id );
}

public static AtmSettlementOtherDetails LoadAtmSettlementOtherDetailsByPk( int atm_settlement_other_details_id , IDbConnection conn)
{
return LoadAtmSettlementOtherDetails(" atm_settlement_other_details_id="+atm_settlement_other_details_id , conn);
}

public void Save()
{
if (atm_settlement_other_details_idChanged || atm_settlement_idChanged || no_of_replenishmentChanged || inventoryChanged || commentsChanged )
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
if (atm_settlement_other_details_idChanged || atm_settlement_idChanged || no_of_replenishmentChanged || inventoryChanged || commentsChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atm_settlement_other_details( atm_settlement_other_details_id,atm_settlement_id,no_of_replenishment,inventory,comments ) values(");
lock (ConnectionFactory.connectionString) { this.atm_settlement_other_details_id = ConnectionFactory.GetNextId();
qry.Append(this.atm_settlement_other_details_id);
} qry.Append(",");
qry.Append(atm_settlement_idDbString+",");
qry.Append(no_of_replenishmentDbString+",");
qry.Append(inventoryDbString+",");
qry.Append(commentsDbString);
qry.Append(");");

}
else
{
if (!(atm_settlement_other_details_idChanged || atm_settlement_idChanged || no_of_replenishmentChanged || inventoryChanged || commentsChanged ))
return;
qry.Append("UPDATE Atm_settlement_other_details set "); if ( atm_settlement_idChanged )
{
qry.Append("atm_settlement_id ="+atm_settlement_idDbString);
qry.Append(",");
}

if ( no_of_replenishmentChanged )
{
qry.Append("no_of_replenishment ="+no_of_replenishmentDbString);
qry.Append(",");
}

if ( inventoryChanged )
{
qry.Append("inventory ="+inventoryDbString);
qry.Append(",");
}

if ( commentsChanged )
{
qry.Append("comments ="+commentsDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atm_settlement_other_details_id = "+atm_settlement_other_details_idDbString);
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
cmd.CommandText = "DELETE Atm_settlement_other_details where atm_settlement_other_details_id = "+ atm_settlement_other_details_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmSettlementOtherDetailss(string where)
{
ConnectionFactory.ExecuteQuery("delete Atm_settlement_other_details where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atm_settlement_other_details_id= 1,
atm_settlement_id= 2,
no_of_replenishment= 4,
inventory= 8,
comments= 16
}
#endregion
public void BulkSave(List<AtmSettlementOtherDetails> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atm_settlement_other_details";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmSettlementOtherDetails.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmSettlementOtherDetails> transList,ref DataTable dt)
{
foreach (AtmSettlementOtherDetails tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atm_settlement_other_details_id"] =ConnectionFactory.GetNextId();
Row["atm_settlement_id"] = tran.AtmSettlementId;
Row["no_of_replenishment"] = tran.NoOfReplenishment;
Row["inventory"] = tran.Inventory;
Row["comments"] = tran.Comments;
dt.Rows.Add(Row);
} }
}
}
