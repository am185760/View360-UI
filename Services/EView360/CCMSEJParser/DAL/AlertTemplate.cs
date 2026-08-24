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
public class AlertTemplate
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public AlertTemplate() { }
public AlertTemplate( int alert_template_id ) 
{
}
public AlertTemplate( string alert_template_name,string alert_template_desc )
{
this.alert_template_name = alert_template_name;
this.alert_template_nameChanged = true;
this.alert_template_desc = alert_template_desc;
this.alert_template_descChanged = true;
}
private AlertTemplate( int alert_template_id,string alert_template_name,string alert_template_desc )
{
this.alert_template_id = alert_template_id;
this.alert_template_idChanged = true;
this.alert_template_name = alert_template_name;
this.alert_template_nameChanged = true;
this.alert_template_desc = alert_template_desc;
this.alert_template_descChanged = true;
}

#region members and properties for columns

#region AlertTemplateId
private bool alert_template_idChanged = false;
private int alert_template_id;
public int AlertTemplateId
{
get { return alert_template_id; }
set { 
alert_template_id = value;
alert_template_idChanged = true;
}
}
private string alert_template_idDbString
{
get
{
return alert_template_id.ToString();
}
}
#endregion
#region AlertTemplateName
private bool alert_template_nameChanged = false;
private string alert_template_name;
public string AlertTemplateName
{
get { return alert_template_name; }
set { 
alert_template_name = value;
alert_template_nameChanged = true;
}
}
private string alert_template_nameDbString
{
get
{
if (this.alert_template_name!=null)
return string.Format("'{0}'",alert_template_name); else
return "null";
}
}
#endregion
#region AlertTemplateDesc
private bool alert_template_descChanged = false;
private string alert_template_desc;
public string AlertTemplateDesc
{
get { return alert_template_desc; }
set { 
alert_template_desc = value;
alert_template_descChanged = true;
}
}
private string alert_template_descDbString
{
get
{
if (this.alert_template_desc!=null)
return string.Format("'{0}'",alert_template_desc); else
return "null";
}
}
#endregion
#endregion

#region AlertTemplateReader
public class AlertTemplateReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
AlertTemplate currentAlertTemplate;
Columns columns;
bool partialRead = false;
private AlertTemplateReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public AlertTemplateReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public AlertTemplateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentAlertTemplate; }

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
currentAlertTemplate = new AlertTemplate();
if (partialRead)
{ if ((columns & Columns.alert_template_id) == Columns.alert_template_id && reader["alert_template_id"]!=DBNull.Value)
currentAlertTemplate.alert_template_id =(int) reader["alert_template_id"]; 
if ((columns & Columns.alert_template_name) == Columns.alert_template_name && reader["alert_template_name"]!=DBNull.Value)
currentAlertTemplate.alert_template_name =(string) reader["alert_template_name"]; 
if ((columns & Columns.alert_template_desc) == Columns.alert_template_desc && reader["alert_template_desc"]!=DBNull.Value)
currentAlertTemplate.alert_template_desc =(string) reader["alert_template_desc"]; 

} else
{
if (reader["alert_template_id"] != DBNull.Value)
currentAlertTemplate.alert_template_id = (int) reader["alert_template_id"]; 
if (reader["alert_template_name"] != DBNull.Value)
currentAlertTemplate.alert_template_name = (string) reader["alert_template_name"]; 
if (reader["alert_template_desc"] != DBNull.Value)
currentAlertTemplate.alert_template_desc = (string) reader["alert_template_desc"]; 
} 

currentAlertTemplate.isNewEntity = false;
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

public AlertTemplate CurrentAlertTemplate
{
get{ return currentAlertTemplate; }
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


#region AlertTemplate functions

public static AlertTemplateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.alert_template_id == (Columns.alert_template_id & columns))
qry.Append("alert_template_id,");
if (Columns.alert_template_name == (Columns.alert_template_name & columns))
qry.Append("alert_template_name,");
if (Columns.alert_template_desc == (Columns.alert_template_desc & columns))
qry.Append("alert_template_desc,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Alert_template ");

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
return new AlertTemplateReader(cmd.ExecuteReader(), conn, columns);
}

static public AlertTemplateReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static AlertTemplateReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select alert_template_id,alert_template_name,alert_template_desc from Alert_template ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new AlertTemplateReader(cmd.ExecuteReader(), conn);
}

static public AlertTemplateReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static AlertTemplate LoadAlertTemplate(string where)
{
AlertTemplateReader reader = AlertTemplate.ExecuteReader(where);
AlertTemplate _alerttemplate = null;
if (reader.Read())
_alerttemplate = reader.CurrentAlertTemplate;
reader.Close();
return _alerttemplate;
}

public static AlertTemplate LoadAlertTemplate(string where, IDbConnection conn)
{
AlertTemplateReader reader = AlertTemplate.ExecuteReader(where, conn);
AlertTemplate _alerttemplate = null;
if (reader.Read())
_alerttemplate = reader.CurrentAlertTemplate;
reader.Close(false);
return _alerttemplate;
}

public static AlertTemplate LoadAlertTemplateByPk( int alert_template_id )
{
return LoadAlertTemplate( " alert_template_id="+alert_template_id );
}

public static AlertTemplate LoadAlertTemplateByPk( int alert_template_id , IDbConnection conn)
{
return LoadAlertTemplate(" alert_template_id="+alert_template_id , conn);
}

public void Save()
{
if (alert_template_idChanged || alert_template_nameChanged || alert_template_descChanged )
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
if (alert_template_idChanged || alert_template_nameChanged || alert_template_descChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Alert_template( alert_template_id,alert_template_name,alert_template_desc ) values(");
lock (ConnectionFactory.connectionString) { this.alert_template_id = ConnectionFactory.GetNextId();
qry.Append(this.alert_template_id);
} qry.Append(",");
qry.Append(alert_template_nameDbString+",");
qry.Append(alert_template_descDbString);
qry.Append(");");

}
else
{
if (!(alert_template_idChanged || alert_template_nameChanged || alert_template_descChanged ))
return;
qry.Append("UPDATE Alert_template set "); if ( alert_template_nameChanged )
{
qry.Append("alert_template_name ="+alert_template_nameDbString);
qry.Append(",");
}

if ( alert_template_descChanged )
{
qry.Append("alert_template_desc ="+alert_template_descDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("alert_template_id = "+alert_template_idDbString);
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
cmd.CommandText = "DELETE Alert_template where alert_template_id = "+ alert_template_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteAlertTemplates(string where)
{
ConnectionFactory.ExecuteQuery("delete Alert_template where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
alert_template_id= 1,
alert_template_name= 2,
alert_template_desc= 4
}
#endregion
public void BulkSave(List<AlertTemplate> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Alert_template";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(AlertTemplate.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <AlertTemplate> transList,ref DataTable dt)
{
foreach (AlertTemplate tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["alert_template_id"] =ConnectionFactory.GetNextId();
Row["alert_template_name"] = tran.AlertTemplateName;
Row["alert_template_desc"] = tran.AlertTemplateDesc;
dt.Rows.Add(Row);
} }
}
}
