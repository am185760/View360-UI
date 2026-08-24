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
public class Comment
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Comment() { }
public Comment( int comment_id ) 
{
}
public Comment( string comment_text )
{
this.comment_text = comment_text;
this.comment_textChanged = true;
}
private Comment( int comment_id,string comment_text )
{
this.comment_id = comment_id;
this.comment_idChanged = true;
this.comment_text = comment_text;
this.comment_textChanged = true;
}

#region members and properties for columns

#region CommentId
private bool comment_idChanged = false;
private int comment_id;
public int CommentId
{
get { return comment_id; }
set { 
comment_id = value;
comment_idChanged = true;
}
}
private string comment_idDbString
{
get
{
return comment_id.ToString();
}
}
#endregion
#region CommentText
private bool comment_textChanged = false;
private string comment_text;
public string CommentText
{
get { return comment_text; }
set { 
comment_text = value;
comment_textChanged = true;
}
}
private string comment_textDbString
{
get
{
if (this.comment_text!=null)
return string.Format("'{0}'",comment_text); else
return "null";
}
}
#endregion
#endregion

#region CommentReader
public class CommentReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Comment currentComment;
Columns columns;
bool partialRead = false;
private CommentReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CommentReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CommentReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentComment; }

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
currentComment = new Comment();
if (partialRead)
{ if ((columns & Columns.comment_id) == Columns.comment_id && reader["comment_id"]!=DBNull.Value)
currentComment.comment_id =(int) reader["comment_id"]; 
if ((columns & Columns.comment_text) == Columns.comment_text && reader["comment_text"]!=DBNull.Value)
currentComment.comment_text =(string) reader["comment_text"]; 

} else
{
if (reader["comment_id"] != DBNull.Value)
currentComment.comment_id = (int) reader["comment_id"]; 
if (reader["comment_text"] != DBNull.Value)
currentComment.comment_text = (string) reader["comment_text"]; 
} 

currentComment.isNewEntity = false;
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

public Comment CurrentComment
{
get{ return currentComment; }
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


#region Comment functions

public static CommentReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.comment_id == (Columns.comment_id & columns))
qry.Append("comment_id,");
if (Columns.comment_text == (Columns.comment_text & columns))
qry.Append("comment_text,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Comment ");

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
return new CommentReader(cmd.ExecuteReader(), conn, columns);
}

static public CommentReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CommentReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select comment_id,comment_text from Comment ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CommentReader(cmd.ExecuteReader(), conn);
}

static public CommentReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Comment LoadComment(string where)
{
CommentReader reader = Comment.ExecuteReader(where);
Comment _comment = null;
if (reader.Read())
_comment = reader.CurrentComment;
reader.Close();
return _comment;
}

public static Comment LoadComment(string where, IDbConnection conn)
{
CommentReader reader = Comment.ExecuteReader(where, conn);
Comment _comment = null;
if (reader.Read())
_comment = reader.CurrentComment;
reader.Close(false);
return _comment;
}

public static Comment LoadCommentByPk( int comment_id )
{
return LoadComment( " comment_id="+comment_id );
}

public static Comment LoadCommentByPk( int comment_id , IDbConnection conn)
{
return LoadComment(" comment_id="+comment_id , conn);
}

public void Save()
{
if (comment_idChanged || comment_textChanged )
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
if (comment_idChanged || comment_textChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Comment( comment_id,comment_text ) values(");
lock (ConnectionFactory.connectionString) { this.comment_id = ConnectionFactory.GetNextId();
qry.Append(this.comment_id);
} qry.Append(",");
qry.Append(comment_textDbString);
qry.Append(");");

}
else
{
if (!(comment_idChanged || comment_textChanged ))
return;
qry.Append("UPDATE Comment set "); if ( comment_textChanged )
{
qry.Append("comment_text ="+comment_textDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("comment_id = "+comment_idDbString);
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
cmd.CommandText = "DELETE Comment where comment_id = "+ comment_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteComments(string where)
{
ConnectionFactory.ExecuteQuery("delete Comment where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
comment_id= 1,
comment_text= 2
}
#endregion
public void BulkSave(List<Comment> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Comment";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Comment.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Comment> transList,ref DataTable dt)
{
foreach (Comment tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["comment_id"] =ConnectionFactory.GetNextId();
Row["comment_text"] = tran.CommentText;
dt.Rows.Add(Row);
} }
}
}
