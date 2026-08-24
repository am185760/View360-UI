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
public class FileType
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public FileType() { }
public FileType( string path_at_ATM,string file_type_title,string copy_type,bool is_EJLog )
{
this.path_at_ATM = path_at_ATM;
this.path_at_ATMChanged = true;
this.file_type_title = file_type_title;
this.file_type_titleChanged = true;
this.copy_type = copy_type;
this.copy_typeChanged = true;
this.is_EJLog = is_EJLog;
this.is_EJLogChanged = true;
}
private FileType( int file_type_id,string path_at_ATM,string file_type_title,string copy_type,bool is_EJLog )
{
this.file_type_id = file_type_id;
this.file_type_idChanged = true;
this.path_at_ATM = path_at_ATM;
this.path_at_ATMChanged = true;
this.file_type_title = file_type_title;
this.file_type_titleChanged = true;
this.copy_type = copy_type;
this.copy_typeChanged = true;
this.is_EJLog = is_EJLog;
this.is_EJLogChanged = true;
}

#region members and properties for columns

#region FileTypeId
private bool file_type_idChanged = false;
private int file_type_id;
public int FileTypeId
{
get { return file_type_id; }
set { 
file_type_id = value;
file_type_idChanged = true;
}
}
private string file_type_idDbString
{
get
{
return file_type_id.ToString();
}
}
#endregion
#region PathAtATM
private bool path_at_ATMChanged = false;
private string path_at_ATM;
public string PathAtATM
{
get { return path_at_ATM; }
set { 
path_at_ATM = value;
path_at_ATMChanged = true;
}
}
private string path_at_ATMDbString
{
get
{
if (this.path_at_ATM!=null)
return string.Format("'{0}'",path_at_ATM); else
return "null";
}
}
#endregion
#region FileTypeTitle
private bool file_type_titleChanged = false;
private string file_type_title;
public string FileTypeTitle
{
get { return file_type_title; }
set { 
file_type_title = value;
file_type_titleChanged = true;
}
}
private string file_type_titleDbString
{
get
{
if (this.file_type_title!=null)
return string.Format("'{0}'",file_type_title); else
return "null";
}
}
#endregion
#region CopyType
private bool copy_typeChanged = false;
private string copy_type;
public string CopyType
{
get { return copy_type; }
set { 
copy_type = value;
copy_typeChanged = true;
}
}
private string copy_typeDbString
{
get
{
if (this.copy_type!=null)
return string.Format("'{0}'",copy_type); else
return "null";
}
}
#endregion
#region IsEJLog
private bool is_EJLogChanged = false;
private bool is_EJLog;
public bool IsEJLog
{
get { return is_EJLog; }
set { 
is_EJLog = value;
is_EJLogChanged = true;
}
}
private string is_EJLogDbString
{
get
{
return is_EJLog?"1":"0";
}
}
#endregion
#endregion

#region FileTypeReader
public class FileTypeReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
FileType currentFileType;
Columns columns;
bool partialRead = false;
private FileTypeReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public FileTypeReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public FileTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentFileType; }

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
currentFileType = new FileType();
if (partialRead)
{ if ((columns & Columns.file_type_id) == Columns.file_type_id && reader["file_type_id"]!=DBNull.Value)
currentFileType.file_type_id =(int) reader["file_type_id"]; 
if ((columns & Columns.path_at_ATM) == Columns.path_at_ATM && reader["path_at_ATM"]!=DBNull.Value)
currentFileType.path_at_ATM =(string) reader["path_at_ATM"]; 
if ((columns & Columns.file_type_title) == Columns.file_type_title && reader["file_type_title"]!=DBNull.Value)
currentFileType.file_type_title =(string) reader["file_type_title"]; 
if ((columns & Columns.copy_type) == Columns.copy_type && reader["copy_type"]!=DBNull.Value)
currentFileType.copy_type =(string) reader["copy_type"]; 
if ((columns & Columns.is_EJLog) == Columns.is_EJLog && reader["is_EJLog"]!=DBNull.Value)
currentFileType.is_EJLog =(bool) reader["is_EJLog"]; 

} else
{
if (reader["file_type_id"] != DBNull.Value)
currentFileType.file_type_id = (int) reader["file_type_id"]; 
if (reader["path_at_ATM"] != DBNull.Value)
currentFileType.path_at_ATM = (string) reader["path_at_ATM"]; 
if (reader["file_type_title"] != DBNull.Value)
currentFileType.file_type_title = (string) reader["file_type_title"]; 
if (reader["copy_type"] != DBNull.Value)
currentFileType.copy_type = (string) reader["copy_type"]; 
if (reader["is_EJLog"] != DBNull.Value)
currentFileType.is_EJLog = (bool) reader["is_EJLog"]; 
} 

currentFileType.isNewEntity = false;
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

public FileType CurrentFileType
{
get{ return currentFileType; }
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


#region FileType functions

public static FileTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.file_type_id == (Columns.file_type_id & columns))
qry.Append("file_type_id,");
if (Columns.path_at_ATM == (Columns.path_at_ATM & columns))
qry.Append("path_at_ATM,");
if (Columns.file_type_title == (Columns.file_type_title & columns))
qry.Append("file_type_title,");
if (Columns.copy_type == (Columns.copy_type & columns))
qry.Append("copy_type,");
if (Columns.is_EJLog == (Columns.is_EJLog & columns))
qry.Append("is_EJLog,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from File_type ");

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
return new FileTypeReader(cmd.ExecuteReader(), conn, columns);
}

static public FileTypeReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static FileTypeReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select file_type_id,path_at_ATM,file_type_title,copy_type,is_EJLog from File_type ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new FileTypeReader(cmd.ExecuteReader(), conn);
}

static public FileTypeReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static FileType LoadFileType(string where)
{
FileTypeReader reader = FileType.ExecuteReader(where);
FileType _filetype = null;
if (reader.Read())
_filetype = reader.CurrentFileType;
reader.Close();
return _filetype;
}

public static FileType LoadFileType(string where, IDbConnection conn)
{
FileTypeReader reader = FileType.ExecuteReader(where, conn);
FileType _filetype = null;
if (reader.Read())
_filetype = reader.CurrentFileType;
reader.Close(false);
return _filetype;
}

public static FileType LoadFileTypeByPk( int file_type_id )
{
return LoadFileType( " file_type_id="+file_type_id );
}

public static FileType LoadFileTypeByPk( int file_type_id , IDbConnection conn)
{
return LoadFileType(" file_type_id="+file_type_id , conn);
}

public void Save()
{
if (file_type_idChanged || path_at_ATMChanged || file_type_titleChanged || copy_typeChanged || is_EJLogChanged )
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
if (file_type_idChanged || path_at_ATMChanged || file_type_titleChanged || copy_typeChanged || is_EJLogChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into File_type( file_type_id,path_at_ATM,file_type_title,copy_type,is_EJLog ) values(");
lock (ConnectionFactory.connectionString) { this.file_type_id = ConnectionFactory.GetNextId();
qry.Append(this.file_type_id);
} qry.Append(",");
qry.Append(path_at_ATMDbString+",");
qry.Append(file_type_titleDbString+",");
qry.Append(copy_typeDbString+",");
qry.Append(is_EJLogDbString);
qry.Append(");");

}
else
{
if (!(file_type_idChanged || path_at_ATMChanged || file_type_titleChanged || copy_typeChanged || is_EJLogChanged ))
return;
qry.Append("UPDATE File_type set "); if ( path_at_ATMChanged )
{
qry.Append("path_at_ATM ="+path_at_ATMDbString);
qry.Append(",");
}

if ( file_type_titleChanged )
{
qry.Append("file_type_title ="+file_type_titleDbString);
qry.Append(",");
}

if ( copy_typeChanged )
{
qry.Append("copy_type ="+copy_typeDbString);
qry.Append(",");
}

if ( is_EJLogChanged )
{
qry.Append("is_EJLog ="+is_EJLogDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("file_type_id = "+file_type_idDbString);
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
cmd.CommandText = "DELETE File_type where file_type_id = "+ file_type_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteFileTypes(string where)
{
ConnectionFactory.ExecuteQuery("delete File_type where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
file_type_id= 1,
path_at_ATM= 2,
file_type_title= 4,
copy_type= 8,
is_EJLog= 16
}
#endregion
public void BulkSave(List<FileType> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "File_type";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(FileType.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <FileType> transList,ref DataTable dt)
{
foreach (FileType tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["file_type_id"] =ConnectionFactory.GetNextId();
Row["path_at_ATM"] = tran.PathAtATM;
Row["file_type_title"] = tran.FileTypeTitle;
Row["copy_type"] = tran.CopyType;
Row["is_EJLog"] = tran.IsEJLog;
dt.Rows.Add(Row);
} }
}
}
