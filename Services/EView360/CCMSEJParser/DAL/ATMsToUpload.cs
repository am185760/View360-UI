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
public class AtmsToUpload
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AtmsToUpload() { }
public AtmsToUpload( int upload_id,int atm_id )
{
this.upload_id = upload_id;
this.upload_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private AtmsToUpload( int atms_to_upload_id,int upload_id,int atm_id )
{
this.atms_to_upload_id = atms_to_upload_id;
this.atms_to_upload_idChanged = true;
this.upload_id = upload_id;
this.upload_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region AtmsToUploadId
private bool atms_to_upload_idChanged = false;
private int atms_to_upload_id;
public int AtmsToUploadId
{
get { return atms_to_upload_id; }
set { 
atms_to_upload_id = value;
atms_to_upload_idChanged = true;
}
}
private string atms_to_upload_idDbString
{
get
{
return atms_to_upload_id.ToString();
}
}
#endregion
#region UploadId
private bool upload_idChanged = false;
private int upload_id;
public int UploadId
{
get { return upload_id; }
set { 
upload_id = value;
upload_idChanged = true;
}
}
private string upload_idDbString
{
get
{
return upload_id.ToString();
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
#endregion

#region AtmsToUploadReader
public class AtmsToUploadReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AtmsToUpload currentAtmsToUpload;
Columns columns;
bool partialRead = false;
private AtmsToUploadReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AtmsToUploadReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AtmsToUploadReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAtmsToUpload; }

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
currentAtmsToUpload = new AtmsToUpload();
if (partialRead)
{ if ((columns & Columns.atms_to_upload_id) == Columns.atms_to_upload_id && reader["atms_to_upload_id"]!=DBNull.Value)
currentAtmsToUpload.atms_to_upload_id =(int) reader["atms_to_upload_id"]; 
if ((columns & Columns.upload_id) == Columns.upload_id && reader["upload_id"]!=DBNull.Value)
currentAtmsToUpload.upload_id =(int) reader["upload_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentAtmsToUpload.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["atms_to_upload_id"] != DBNull.Value)
currentAtmsToUpload.atms_to_upload_id = (int) reader["atms_to_upload_id"]; 
if (reader["upload_id"] != DBNull.Value)
currentAtmsToUpload.upload_id = (int) reader["upload_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentAtmsToUpload.atm_id = (int) reader["atm_id"]; 
} 

currentAtmsToUpload.isNewEntity = false;
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

public AtmsToUpload CurrentAtmsToUpload
{
get{ return currentAtmsToUpload; }
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


#region AtmsToUpload functions

public static AtmsToUploadReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.atms_to_upload_id == (Columns.atms_to_upload_id & columns))
qry.Append("atms_to_upload_id,");
if (Columns.upload_id == (Columns.upload_id & columns))
qry.Append("upload_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Atms_to_upload ");

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
return new AtmsToUploadReader(cmd.ExecuteReader(), conn, columns);
}

static public AtmsToUploadReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AtmsToUploadReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select atms_to_upload_id,upload_id,atm_id from Atms_to_upload ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AtmsToUploadReader(cmd.ExecuteReader(), conn);
}

static public AtmsToUploadReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AtmsToUpload LoadAtmsToUpload(string where)
{
AtmsToUploadReader reader = AtmsToUpload.ExecuteReader(where);
AtmsToUpload _atmstoupload = null;
if (reader.Read())
_atmstoupload = reader.CurrentAtmsToUpload;
reader.Close();
return _atmstoupload;
}

public static AtmsToUpload LoadAtmsToUpload(string where, IDbConnection conn)
{
AtmsToUploadReader reader = AtmsToUpload.ExecuteReader(where, conn);
AtmsToUpload _atmstoupload = null;
if (reader.Read())
_atmstoupload = reader.CurrentAtmsToUpload;
reader.Close(false);
return _atmstoupload;
}

public static AtmsToUpload LoadAtmsToUploadByPk( int atms_to_upload_id )
{
return LoadAtmsToUpload( " atms_to_upload_id="+atms_to_upload_id );
}

public static AtmsToUpload LoadAtmsToUploadByPk( int atms_to_upload_id , IDbConnection conn)
{
return LoadAtmsToUpload(" atms_to_upload_id="+atms_to_upload_id , conn);
}

public void Save()
{
if (atms_to_upload_idChanged || upload_idChanged || atm_idChanged )
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
if (atms_to_upload_idChanged || upload_idChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Atms_to_upload( atms_to_upload_id,upload_id,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.atms_to_upload_id = ConnectionFactory.GetNextId();
qry.Append(this.atms_to_upload_id);
} qry.Append(",");
qry.Append(upload_idDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(atms_to_upload_idChanged || upload_idChanged || atm_idChanged ))
return;
qry.Append("UPDATE Atms_to_upload set "); if ( upload_idChanged )
{
qry.Append("upload_id ="+upload_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("atms_to_upload_id = "+atms_to_upload_idDbString);
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
cmd.CommandText = "DELETE Atms_to_upload where atms_to_upload_id = "+ atms_to_upload_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAtmsToUploads(string where)
{
ConnectionFactory.ExecuteQuery("delete Atms_to_upload where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
atms_to_upload_id= 1,
upload_id= 2,
atm_id= 4
}
#endregion
public void BulkSave(List<AtmsToUpload> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Atms_to_upload";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AtmsToUpload.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AtmsToUpload> transList,ref DataTable dt)
{
foreach (AtmsToUpload tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["atms_to_upload_id"] =ConnectionFactory.GetNextId();
Row["upload_id"] = tran.UploadId;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
