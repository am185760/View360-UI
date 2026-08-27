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
public class FilesToUpload
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public FilesToUpload() { }
public FilesToUpload( int files_to_upload_id,int upload_id ) 
{
this.upload_id = upload_id;
this.upload_idChanged = true;
}
public FilesToUpload( int? file_seq_no,string source_path,string path_at_atm,string overwrite_option,int? file_size,bool? execute_File,int upload_id )
{
this.file_seq_no = file_seq_no;
this.file_seq_noChanged = true;
this.source_path = source_path;
this.source_pathChanged = true;
this.path_at_atm = path_at_atm;
this.path_at_atmChanged = true;
this.overwrite_option = overwrite_option;
this.overwrite_optionChanged = true;
this.file_size = file_size;
this.file_sizeChanged = true;
this.execute_File = execute_File;
this.execute_FileChanged = true;
this.upload_id = upload_id;
this.upload_idChanged = true;
}
private FilesToUpload( int files_to_upload_id,int? file_seq_no,string source_path,string path_at_atm,string overwrite_option,int? file_size,bool? execute_File,int upload_id )
{
this.files_to_upload_id = files_to_upload_id;
this.files_to_upload_idChanged = true;
this.file_seq_no = file_seq_no;
this.file_seq_noChanged = true;
this.source_path = source_path;
this.source_pathChanged = true;
this.path_at_atm = path_at_atm;
this.path_at_atmChanged = true;
this.overwrite_option = overwrite_option;
this.overwrite_optionChanged = true;
this.file_size = file_size;
this.file_sizeChanged = true;
this.execute_File = execute_File;
this.execute_FileChanged = true;
this.upload_id = upload_id;
this.upload_idChanged = true;
}

#region members and properties for columns

#region FilesToUploadId
private bool files_to_upload_idChanged = false;
private int files_to_upload_id;
public int FilesToUploadId
{
get { return files_to_upload_id; }
set { 
files_to_upload_id = value;
files_to_upload_idChanged = true;
}
}
private string files_to_upload_idDbString
{
get
{
return files_to_upload_id.ToString();
}
}
#endregion
#region FileSeqNo
private bool file_seq_noChanged = false;
private int? file_seq_no;
public int? FileSeqNo
{
get { return file_seq_no; }
set { 
file_seq_no = value;
file_seq_noChanged = true;
}
}
private string file_seq_noDbString
{
get
{
if (this.file_seq_no.HasValue)
return file_seq_no.ToString();
else
return "null";
}
}
#endregion
#region SourcePath
private bool source_pathChanged = false;
private string source_path;
public string SourcePath
{
get { return source_path; }
set { 
source_path = value;
source_pathChanged = true;
}
}
private string source_pathDbString
{
get
{
if (this.source_path!=null)
return string.Format("'{0}'",source_path); else
return "null";
}
}
#endregion
#region PathAtAtm
private bool path_at_atmChanged = false;
private string path_at_atm;
public string PathAtAtm
{
get { return path_at_atm; }
set { 
path_at_atm = value;
path_at_atmChanged = true;
}
}
private string path_at_atmDbString
{
get
{
if (this.path_at_atm!=null)
return string.Format("'{0}'",path_at_atm); else
return "null";
}
}
#endregion
#region OverwriteOption
private bool overwrite_optionChanged = false;
private string overwrite_option;
public string OverwriteOption
{
get { return overwrite_option; }
set { 
overwrite_option = value;
overwrite_optionChanged = true;
}
}
private string overwrite_optionDbString
{
get
{
if (this.overwrite_option!=null)
return string.Format("'{0}'",overwrite_option); else
return "null";
}
}
#endregion
#region FileSize
private bool file_sizeChanged = false;
private int? file_size;
public int? FileSize
{
get { return file_size; }
set { 
file_size = value;
file_sizeChanged = true;
}
}
private string file_sizeDbString
{
get
{
if (this.file_size.HasValue)
return file_size.ToString();
else
return "null";
}
}
#endregion
#region ExecuteFile
private bool execute_FileChanged = false;
private bool? execute_File;
public bool? ExecuteFile
{
get { return execute_File; }
set { 
execute_File = value;
execute_FileChanged = true;
}
}
private string execute_FileDbString
{
get
{
if (this.execute_File.HasValue)
return execute_File.Value?"1":"0";
else
return "null";
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
#endregion

#region FilesToUploadReader
public class FilesToUploadReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
FilesToUpload currentFilesToUpload;
Columns columns;
bool partialRead = false;
private FilesToUploadReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public FilesToUploadReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public FilesToUploadReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentFilesToUpload; }

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
currentFilesToUpload = new FilesToUpload();
if (partialRead)
{ if ((columns & Columns.files_to_upload_id) == Columns.files_to_upload_id && reader["files_to_upload_id"]!=DBNull.Value)
currentFilesToUpload.files_to_upload_id =(int) reader["files_to_upload_id"]; 
if ((columns & Columns.file_seq_no) == Columns.file_seq_no && reader["file_seq_no"]!=DBNull.Value)
currentFilesToUpload.file_seq_no =(int?) reader["file_seq_no"]; 
if ((columns & Columns.source_path) == Columns.source_path && reader["source_path"]!=DBNull.Value)
currentFilesToUpload.source_path =(string) reader["source_path"]; 
if ((columns & Columns.path_at_atm) == Columns.path_at_atm && reader["path_at_atm"]!=DBNull.Value)
currentFilesToUpload.path_at_atm =(string) reader["path_at_atm"]; 
if ((columns & Columns.overwrite_option) == Columns.overwrite_option && reader["overwrite_option"]!=DBNull.Value)
currentFilesToUpload.overwrite_option =(string) reader["overwrite_option"]; 
if ((columns & Columns.file_size) == Columns.file_size && reader["file_size"]!=DBNull.Value)
currentFilesToUpload.file_size =(int?) reader["file_size"]; 
if ((columns & Columns.execute_File) == Columns.execute_File && reader["execute_File"]!=DBNull.Value)
currentFilesToUpload.execute_File =(bool?) reader["execute_File"]; 
if ((columns & Columns.upload_id) == Columns.upload_id && reader["upload_id"]!=DBNull.Value)
currentFilesToUpload.upload_id =(int) reader["upload_id"]; 

} else
{
if (reader["files_to_upload_id"] != DBNull.Value)
currentFilesToUpload.files_to_upload_id = (int) reader["files_to_upload_id"]; 
if (reader["file_seq_no"] != DBNull.Value)
currentFilesToUpload.file_seq_no = (int?) reader["file_seq_no"]; 
if (reader["source_path"] != DBNull.Value)
currentFilesToUpload.source_path = (string) reader["source_path"]; 
if (reader["path_at_atm"] != DBNull.Value)
currentFilesToUpload.path_at_atm = (string) reader["path_at_atm"]; 
if (reader["overwrite_option"] != DBNull.Value)
currentFilesToUpload.overwrite_option = (string) reader["overwrite_option"]; 
if (reader["file_size"] != DBNull.Value)
currentFilesToUpload.file_size = (int?) reader["file_size"]; 
if (reader["execute_File"] != DBNull.Value)
currentFilesToUpload.execute_File = (bool?) reader["execute_File"]; 
if (reader["upload_id"] != DBNull.Value)
currentFilesToUpload.upload_id = (int) reader["upload_id"]; 
} 

currentFilesToUpload.isNewEntity = false;
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

public FilesToUpload CurrentFilesToUpload
{
get{ return currentFilesToUpload; }
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


#region FilesToUpload functions

public static FilesToUploadReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.files_to_upload_id == (Columns.files_to_upload_id & columns))
qry.Append("files_to_upload_id,");
if (Columns.file_seq_no == (Columns.file_seq_no & columns))
qry.Append("file_seq_no,");
if (Columns.source_path == (Columns.source_path & columns))
qry.Append("source_path,");
if (Columns.path_at_atm == (Columns.path_at_atm & columns))
qry.Append("path_at_atm,");
if (Columns.overwrite_option == (Columns.overwrite_option & columns))
qry.Append("overwrite_option,");
if (Columns.file_size == (Columns.file_size & columns))
qry.Append("file_size,");
if (Columns.execute_File == (Columns.execute_File & columns))
qry.Append("execute_File,");
if (Columns.upload_id == (Columns.upload_id & columns))
qry.Append("upload_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Files_to_upload ");

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
return new FilesToUploadReader(cmd.ExecuteReader(), conn, columns);
}

static public FilesToUploadReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static FilesToUploadReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select files_to_upload_id,file_seq_no,source_path,path_at_atm,overwrite_option,file_size,execute_File,upload_id from Files_to_upload ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new FilesToUploadReader(cmd.ExecuteReader(), conn);
}

static public FilesToUploadReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static FilesToUpload LoadFilesToUpload(string where)
{
FilesToUploadReader reader = FilesToUpload.ExecuteReader(where);
FilesToUpload _filestoupload = null;
if (reader.Read())
_filestoupload = reader.CurrentFilesToUpload;
reader.Close();
return _filestoupload;
}

public static FilesToUpload LoadFilesToUpload(string where, IDbConnection conn)
{
FilesToUploadReader reader = FilesToUpload.ExecuteReader(where, conn);
FilesToUpload _filestoupload = null;
if (reader.Read())
_filestoupload = reader.CurrentFilesToUpload;
reader.Close(false);
return _filestoupload;
}

public static FilesToUpload LoadFilesToUploadByPk( int files_to_upload_id )
{
return LoadFilesToUpload( " files_to_upload_id="+files_to_upload_id );
}

public static FilesToUpload LoadFilesToUploadByPk( int files_to_upload_id , IDbConnection conn)
{
return LoadFilesToUpload(" files_to_upload_id="+files_to_upload_id , conn);
}

public void Save()
{
if (files_to_upload_idChanged || file_seq_noChanged || source_pathChanged || path_at_atmChanged || overwrite_optionChanged || file_sizeChanged || execute_FileChanged || upload_idChanged )
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
if (files_to_upload_idChanged || file_seq_noChanged || source_pathChanged || path_at_atmChanged || overwrite_optionChanged || file_sizeChanged || execute_FileChanged || upload_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Files_to_upload( files_to_upload_id,file_seq_no,source_path,path_at_atm,overwrite_option,file_size,execute_File,upload_id ) values(");
lock (ConnectionFactory.connectionString) { this.files_to_upload_id = ConnectionFactory.GetNextId();
qry.Append(this.files_to_upload_id);
} qry.Append(",");
qry.Append(file_seq_noDbString+",");
qry.Append(source_pathDbString+",");
qry.Append(path_at_atmDbString+",");
qry.Append(overwrite_optionDbString+",");
qry.Append(file_sizeDbString+",");
qry.Append(execute_FileDbString+",");
qry.Append(upload_idDbString);
qry.Append(");");

}
else
{
if (!(files_to_upload_idChanged || file_seq_noChanged || source_pathChanged || path_at_atmChanged || overwrite_optionChanged || file_sizeChanged || execute_FileChanged || upload_idChanged ))
return;
qry.Append("UPDATE Files_to_upload set "); if ( file_seq_noChanged )
{
qry.Append("file_seq_no ="+file_seq_noDbString);
qry.Append(",");
}

if ( source_pathChanged )
{
qry.Append("source_path ="+source_pathDbString);
qry.Append(",");
}

if ( path_at_atmChanged )
{
qry.Append("path_at_atm ="+path_at_atmDbString);
qry.Append(",");
}

if ( overwrite_optionChanged )
{
qry.Append("overwrite_option ="+overwrite_optionDbString);
qry.Append(",");
}

if ( file_sizeChanged )
{
qry.Append("file_size ="+file_sizeDbString);
qry.Append(",");
}

if ( execute_FileChanged )
{
qry.Append("execute_File ="+execute_FileDbString);
qry.Append(",");
}

if ( upload_idChanged )
{
qry.Append("upload_id ="+upload_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("files_to_upload_id = "+files_to_upload_idDbString);
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
cmd.CommandText = "DELETE Files_to_upload where files_to_upload_id = "+ files_to_upload_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteFilesToUploads(string where)
{
ConnectionFactory.ExecuteQuery("delete Files_to_upload where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
files_to_upload_id= 1,
file_seq_no= 2,
source_path= 4,
path_at_atm= 8,
overwrite_option= 16,
file_size= 32,
execute_File= 64,
upload_id= 128
}
#endregion
public void BulkSave(List<FilesToUpload> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Files_to_upload";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(FilesToUpload.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <FilesToUpload> transList,ref DataTable dt)
{
foreach (FilesToUpload tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["files_to_upload_id"] =ConnectionFactory.GetNextId();
Row["file_seq_no"] = tran.FileSeqNo;
Row["source_path"] = tran.SourcePath;
Row["path_at_atm"] = tran.PathAtAtm;
Row["overwrite_option"] = tran.OverwriteOption;
Row["file_size"] = tran.FileSize;
Row["execute_File"] = tran.ExecuteFile;
Row["upload_id"] = tran.UploadId;
dt.Rows.Add(Row);
} }
}
}
