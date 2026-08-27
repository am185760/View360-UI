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
public class InvestigationComments
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public InvestigationComments() { }
public InvestigationComments( int investigation_comments_id,int investigation_id,int user_id,DateTime creation_time ) 
{
this.investigation_id = investigation_id;
this.investigation_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
}
public InvestigationComments( int investigation_id,int user_id,string comments,DateTime creation_time )
{
this.investigation_id = investigation_id;
this.investigation_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.comments = comments;
this.commentsChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
}
private InvestigationComments( int investigation_comments_id,int investigation_id,int user_id,string comments,DateTime creation_time )
{
this.investigation_comments_id = investigation_comments_id;
this.investigation_comments_idChanged = true;
this.investigation_id = investigation_id;
this.investigation_idChanged = true;
this.user_id = user_id;
this.user_idChanged = true;
this.comments = comments;
this.commentsChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
}

#region members and properties for columns

#region InvestigationCommentsId
private bool investigation_comments_idChanged = false;
private int investigation_comments_id;
public int InvestigationCommentsId
{
get { return investigation_comments_id; }
set { 
investigation_comments_id = value;
investigation_comments_idChanged = true;
}
}
private string investigation_comments_idDbString
{
get
{
return investigation_comments_id.ToString();
}
}
#endregion
#region InvestigationId
private bool investigation_idChanged = false;
private int investigation_id;
public int InvestigationId
{
get { return investigation_id; }
set { 
investigation_id = value;
investigation_idChanged = true;
}
}
private string investigation_idDbString
{
get
{
return investigation_id.ToString();
}
}
#endregion
#region UserId
private bool user_idChanged = false;
private int user_id;
public int UserId
{
get { return user_id; }
set { 
user_id = value;
user_idChanged = true;
}
}
private string user_idDbString
{
get
{
return user_id.ToString();
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
#region CreationTime
private bool creation_timeChanged = false;
private DateTime creation_time;
public DateTime CreationTime
{
get { return creation_time; }
set { 
creation_time = value;
creation_timeChanged = true;
}
}
private string creation_timeDbString
{
get
{
return string.Format("Convert(datetime,'{0}',121)",creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
}
}
#endregion
#endregion

#region InvestigationCommentsReader
public class InvestigationCommentsReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
InvestigationComments currentInvestigationComments;
Columns columns;
bool partialRead = false;
private InvestigationCommentsReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public InvestigationCommentsReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public InvestigationCommentsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentInvestigationComments; }

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
currentInvestigationComments = new InvestigationComments();
if (partialRead)
{ if ((columns & Columns.investigation_comments_id) == Columns.investigation_comments_id && reader["investigation_comments_id"]!=DBNull.Value)
currentInvestigationComments.investigation_comments_id =(int) reader["investigation_comments_id"]; 
if ((columns & Columns.investigation_id) == Columns.investigation_id && reader["investigation_id"]!=DBNull.Value)
currentInvestigationComments.investigation_id =(int) reader["investigation_id"]; 
if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
currentInvestigationComments.user_id =(int) reader["user_id"]; 
if ((columns & Columns.comments) == Columns.comments && reader["comments"]!=DBNull.Value)
currentInvestigationComments.comments =(string) reader["comments"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentInvestigationComments.creation_time =(DateTime) reader["creation_time"]; 

} else
{
if (reader["investigation_comments_id"] != DBNull.Value)
currentInvestigationComments.investigation_comments_id = (int) reader["investigation_comments_id"]; 
if (reader["investigation_id"] != DBNull.Value)
currentInvestigationComments.investigation_id = (int) reader["investigation_id"]; 
if (reader["user_id"] != DBNull.Value)
currentInvestigationComments.user_id = (int) reader["user_id"]; 
if (reader["comments"] != DBNull.Value)
currentInvestigationComments.comments = (string) reader["comments"]; 
if (reader["creation_time"] != DBNull.Value)
currentInvestigationComments.creation_time = (DateTime) reader["creation_time"]; 
} 

currentInvestigationComments.isNewEntity = false;
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

public InvestigationComments CurrentInvestigationComments
{
get{ return currentInvestigationComments; }
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


#region InvestigationComments functions

public static InvestigationCommentsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.investigation_comments_id == (Columns.investigation_comments_id & columns))
qry.Append("investigation_comments_id,");
if (Columns.investigation_id == (Columns.investigation_id & columns))
qry.Append("investigation_id,");
if (Columns.user_id == (Columns.user_id & columns))
qry.Append("user_id,");
if (Columns.comments == (Columns.comments & columns))
qry.Append("comments,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Investigation_comments ");

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
return new InvestigationCommentsReader(cmd.ExecuteReader(), conn, columns);
}

static public InvestigationCommentsReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static InvestigationCommentsReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select investigation_comments_id,investigation_id,user_id,comments,creation_time from Investigation_comments ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new InvestigationCommentsReader(cmd.ExecuteReader(), conn);
}

static public InvestigationCommentsReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static InvestigationComments LoadInvestigationComments(string where)
{
InvestigationCommentsReader reader = InvestigationComments.ExecuteReader(where);
InvestigationComments _investigationcomments = null;
if (reader.Read())
_investigationcomments = reader.CurrentInvestigationComments;
reader.Close();
return _investigationcomments;
}

public static InvestigationComments LoadInvestigationComments(string where, IDbConnection conn)
{
InvestigationCommentsReader reader = InvestigationComments.ExecuteReader(where, conn);
InvestigationComments _investigationcomments = null;
if (reader.Read())
_investigationcomments = reader.CurrentInvestigationComments;
reader.Close(false);
return _investigationcomments;
}

public static InvestigationComments LoadInvestigationCommentsByPk( int investigation_comments_id )
{
return LoadInvestigationComments( " investigation_comments_id="+investigation_comments_id );
}

public static InvestigationComments LoadInvestigationCommentsByPk( int investigation_comments_id , IDbConnection conn)
{
return LoadInvestigationComments(" investigation_comments_id="+investigation_comments_id , conn);
}

public void Save()
{
if (investigation_comments_idChanged || investigation_idChanged || user_idChanged || commentsChanged || creation_timeChanged )
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
if (investigation_comments_idChanged || investigation_idChanged || user_idChanged || commentsChanged || creation_timeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Investigation_comments( investigation_comments_id,investigation_id,user_id,comments,creation_time ) values(");
lock (ConnectionFactory.connectionString) { this.investigation_comments_id = ConnectionFactory.GetNextId();
qry.Append(this.investigation_comments_id);
} qry.Append(",");
qry.Append(investigation_idDbString+",");
qry.Append(user_idDbString+",");
qry.Append(commentsDbString+",");
qry.Append(creation_timeDbString);
qry.Append(");");

}
else
{
if (!(investigation_comments_idChanged || investigation_idChanged || user_idChanged || commentsChanged || creation_timeChanged ))
return;
qry.Append("UPDATE Investigation_comments set "); if ( investigation_idChanged )
{
qry.Append("investigation_id ="+investigation_idDbString);
qry.Append(",");
}

if ( user_idChanged )
{
qry.Append("user_id ="+user_idDbString);
qry.Append(",");
}

if ( commentsChanged )
{
qry.Append("comments ="+commentsDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("investigation_comments_id = "+investigation_comments_idDbString);
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
cmd.CommandText = "DELETE Investigation_comments where investigation_comments_id = "+ investigation_comments_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteInvestigationCommentss(string where)
{
ConnectionFactory.ExecuteQuery("delete Investigation_comments where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
investigation_comments_id= 1,
investigation_id= 2,
user_id= 4,
comments= 8,
creation_time= 16
}
#endregion
public void BulkSave(List<InvestigationComments> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Investigation_comments";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(InvestigationComments.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <InvestigationComments> transList,ref DataTable dt)
{
foreach (InvestigationComments tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["investigation_comments_id"] =ConnectionFactory.GetNextId();
Row["investigation_id"] = tran.InvestigationId;
Row["user_id"] = tran.UserId;
Row["comments"] = tran.Comments;
Row["creation_time"] = tran.CreationTime;
dt.Rows.Add(Row);
} }
}
}
