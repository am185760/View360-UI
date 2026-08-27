
 

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
 public class CcmsSmsTemplate
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public CcmsSmsTemplate() { }
 public CcmsSmsTemplate( int ccms_sms_template_id,DateTime creation_time,int created_by ) 
 {
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 }
 public CcmsSmsTemplate( string ccms_sms_template_name,string ccms_sms_template_message,DateTime creation_time,DateTime? modification_time,int created_by,int? modified_by,string tibco_template_id )
 {
 this.ccms_sms_template_name = ccms_sms_template_name;
 this.ccms_sms_template_nameChanged = true;
 this.ccms_sms_template_message = ccms_sms_template_message;
 this.ccms_sms_template_messageChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.modification_time = modification_time;
 this.modification_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.modified_by = modified_by;
 this.modified_byChanged = true;
 this.tibco_template_id = tibco_template_id;
 this.tibco_template_idChanged = true;
 }
 private CcmsSmsTemplate( int ccms_sms_template_id,string ccms_sms_template_name,string ccms_sms_template_message,DateTime creation_time,DateTime? modification_time,int created_by,int? modified_by,string tibco_template_id )
 {
 this.ccms_sms_template_id = ccms_sms_template_id;
 this.ccms_sms_template_idChanged = true;
 this.ccms_sms_template_name = ccms_sms_template_name;
 this.ccms_sms_template_nameChanged = true;
 this.ccms_sms_template_message = ccms_sms_template_message;
 this.ccms_sms_template_messageChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.modification_time = modification_time;
 this.modification_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.modified_by = modified_by;
 this.modified_byChanged = true;
 this.tibco_template_id = tibco_template_id;
 this.tibco_template_idChanged = true;
 }

 #region members and properties for columns

 #region CcmsSmsTemplateId
 private bool ccms_sms_template_idChanged = false;
 private int ccms_sms_template_id;
 public int CcmsSmsTemplateId
 {
 get { return ccms_sms_template_id; }
 set { 
ccms_sms_template_id = value;
ccms_sms_template_idChanged = true;
 }
 }
 private string ccms_sms_template_idDbString
 {
 get
 {
 return ccms_sms_template_id.ToString();
 }
 }
 #endregion
 #region CcmsSmsTemplateName
 private bool ccms_sms_template_nameChanged = false;
 private string ccms_sms_template_name;
 public string CcmsSmsTemplateName
 {
 get { return ccms_sms_template_name; }
 set { 
ccms_sms_template_name = value;
ccms_sms_template_nameChanged = true;
 }
 }
 private string ccms_sms_template_nameDbString
 {
 get
 {
 if (this.ccms_sms_template_name!=null)
 return string.Format("'{0}'",ccms_sms_template_name); else
 return "null";
 }
 }
 #endregion
 #region CcmsSmsTemplateMessage
 private bool ccms_sms_template_messageChanged = false;
 private string ccms_sms_template_message;
 public string CcmsSmsTemplateMessage
 {
 get { return ccms_sms_template_message; }
 set { 
ccms_sms_template_message = value;
ccms_sms_template_messageChanged = true;
 }
 }
 private string ccms_sms_template_messageDbString
 {
 get
 {
 if (this.ccms_sms_template_message!=null)
 return string.Format("'{0}'",ccms_sms_template_message); else
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
 #region ModificationTime
 private bool modification_timeChanged = false;
 private DateTime? modification_time;
 public DateTime? ModificationTime
 {
 get { return modification_time; }
 set { 
modification_time = value;
modification_timeChanged = true;
 }
 }
 private string modification_timeDbString
 {
 get
 {
 if (this.modification_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region CreatedBy
 private bool created_byChanged = false;
 private int created_by;
 public int CreatedBy
 {
 get { return created_by; }
 set { 
created_by = value;
created_byChanged = true;
 }
 }
 private string created_byDbString
 {
 get
 {
 return created_by.ToString();
 }
 }
 #endregion
 #region ModifiedBy
 private bool modified_byChanged = false;
 private int? modified_by;
 public int? ModifiedBy
 {
 get { return modified_by; }
 set { 
modified_by = value;
modified_byChanged = true;
 }
 }
 private string modified_byDbString
 {
 get
 {
 if (this.modified_by.HasValue)
 return modified_by.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region TibcoTemplateId
 private bool tibco_template_idChanged = false;
 private string tibco_template_id;
 public string TibcoTemplateId
 {
 get { return tibco_template_id; }
 set { 
tibco_template_id = value;
tibco_template_idChanged = true;
 }
 }
 private string tibco_template_idDbString
 {
 get
 {
 if (this.tibco_template_id!=null)
 return string.Format("'{0}'",tibco_template_id); else
 return "null";
 }
 }
 #endregion
 #endregion

 #region CcmsSmsTemplateReader
 public class CcmsSmsTemplateReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
CcmsSmsTemplate currentCcmsSmsTemplate;
 Columns columns;
 bool partialRead = false;
 private CcmsSmsTemplateReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public CcmsSmsTemplateReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public CcmsSmsTemplateReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentCcmsSmsTemplate; }

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
 currentCcmsSmsTemplate = new CcmsSmsTemplate();
 if (partialRead)
 { if ((columns & Columns.ccms_sms_template_id) == Columns.ccms_sms_template_id && reader["ccms_sms_template_id"]!=DBNull.Value)
 currentCcmsSmsTemplate.ccms_sms_template_id =(int) reader["ccms_sms_template_id"]; 
 if ((columns & Columns.ccms_sms_template_name) == Columns.ccms_sms_template_name && reader["ccms_sms_template_name"]!=DBNull.Value)
 currentCcmsSmsTemplate.ccms_sms_template_name =(string) reader["ccms_sms_template_name"]; 
 if ((columns & Columns.ccms_sms_template_message) == Columns.ccms_sms_template_message && reader["ccms_sms_template_message"]!=DBNull.Value)
 currentCcmsSmsTemplate.ccms_sms_template_message =(string) reader["ccms_sms_template_message"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentCcmsSmsTemplate.creation_time =(DateTime) reader["creation_time"]; 
 if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
 currentCcmsSmsTemplate.modification_time =(DateTime?) reader["modification_time"]; 
 if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
 currentCcmsSmsTemplate.created_by =(int) reader["created_by"]; 
 if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
 currentCcmsSmsTemplate.modified_by =(int?) reader["modified_by"]; 
 if ((columns & Columns.tibco_template_id) == Columns.tibco_template_id && reader["tibco_template_id"]!=DBNull.Value)
 currentCcmsSmsTemplate.tibco_template_id =(string) reader["tibco_template_id"]; 

 } else
 {
 if (reader["ccms_sms_template_id"] != DBNull.Value)
 currentCcmsSmsTemplate.ccms_sms_template_id = (int) reader["ccms_sms_template_id"]; 
 if (reader["ccms_sms_template_name"] != DBNull.Value)
 currentCcmsSmsTemplate.ccms_sms_template_name = (string) reader["ccms_sms_template_name"]; 
 if (reader["ccms_sms_template_message"] != DBNull.Value)
 currentCcmsSmsTemplate.ccms_sms_template_message = (string) reader["ccms_sms_template_message"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentCcmsSmsTemplate.creation_time = (DateTime) reader["creation_time"]; 
 if (reader["modification_time"] != DBNull.Value)
 currentCcmsSmsTemplate.modification_time = (DateTime?) reader["modification_time"]; 
 if (reader["created_by"] != DBNull.Value)
 currentCcmsSmsTemplate.created_by = (int) reader["created_by"]; 
 if (reader["modified_by"] != DBNull.Value)
 currentCcmsSmsTemplate.modified_by = (int?) reader["modified_by"]; 
 if (reader["tibco_template_id"] != DBNull.Value)
 currentCcmsSmsTemplate.tibco_template_id = (string) reader["tibco_template_id"]; 
 } 

 currentCcmsSmsTemplate.isNewEntity = false;
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

 public CcmsSmsTemplate CurrentCcmsSmsTemplate
 {
 get{ return currentCcmsSmsTemplate; }
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


 #region CcmsSmsTemplate functions

 public static CcmsSmsTemplateReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.ccms_sms_template_id == (Columns.ccms_sms_template_id & columns))
 qry.Append("ccms_sms_template_id,");
 if (Columns.ccms_sms_template_name == (Columns.ccms_sms_template_name & columns))
 qry.Append("ccms_sms_template_name,");
 if (Columns.ccms_sms_template_message == (Columns.ccms_sms_template_message & columns))
 qry.Append("ccms_sms_template_message,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.modification_time == (Columns.modification_time & columns))
 qry.Append("modification_time,");
 if (Columns.created_by == (Columns.created_by & columns))
 qry.Append("created_by,");
 if (Columns.modified_by == (Columns.modified_by & columns))
 qry.Append("modified_by,");
 if (Columns.tibco_template_id == (Columns.tibco_template_id & columns))
 qry.Append("tibco_template_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Ccms_sms_template ");

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
 return new CcmsSmsTemplateReader(cmd.ExecuteReader(), conn, columns);
 }

 static public CcmsSmsTemplateReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static CcmsSmsTemplateReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select ccms_sms_template_id,ccms_sms_template_name,ccms_sms_template_message,creation_time,modification_time,created_by,modified_by,tibco_template_id from Ccms_sms_template ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new CcmsSmsTemplateReader(cmd.ExecuteReader(), conn);
 }

 static public CcmsSmsTemplateReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static CcmsSmsTemplate LoadCcmsSmsTemplate(string where)
 {
CcmsSmsTemplateReader reader = CcmsSmsTemplate.ExecuteReader(where);
CcmsSmsTemplate _ccmssmstemplate = null;
 if (reader.Read())
 _ccmssmstemplate = reader.CurrentCcmsSmsTemplate;
 reader.Close();
 return _ccmssmstemplate;
 }

 public static CcmsSmsTemplate LoadCcmsSmsTemplate(string where, IDbConnection conn)
 {
CcmsSmsTemplateReader reader = CcmsSmsTemplate.ExecuteReader(where, conn);
CcmsSmsTemplate _ccmssmstemplate = null;
 if (reader.Read())
 _ccmssmstemplate = reader.CurrentCcmsSmsTemplate;
 reader.Close(false);
 return _ccmssmstemplate;
 }

 public static CcmsSmsTemplate LoadCcmsSmsTemplateByPk( int ccms_sms_template_id )
 {
 return LoadCcmsSmsTemplate( " ccms_sms_template_id="+ccms_sms_template_id );
 }

 public static CcmsSmsTemplate LoadCcmsSmsTemplateByPk( int ccms_sms_template_id , IDbConnection conn)
 {
 return LoadCcmsSmsTemplate(" ccms_sms_template_id="+ccms_sms_template_id , conn);
 }

 public void Save()
 {
 if (ccms_sms_template_idChanged || ccms_sms_template_nameChanged || ccms_sms_template_messageChanged || creation_timeChanged || modification_timeChanged || created_byChanged || modified_byChanged || tibco_template_idChanged )
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
 if (ccms_sms_template_idChanged || ccms_sms_template_nameChanged || ccms_sms_template_messageChanged || creation_timeChanged || modification_timeChanged || created_byChanged || modified_byChanged || tibco_template_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Ccms_sms_template( ccms_sms_template_id,ccms_sms_template_name,ccms_sms_template_message,creation_time,modification_time,created_by,modified_by,tibco_template_id ) values(");
 lock (ConnectionFactory.connectionString) { this.ccms_sms_template_id = ConnectionFactory.GetNextId();
 qry.Append(this.ccms_sms_template_id);
 } qry.Append(",");
 qry.Append(ccms_sms_template_nameDbString+",");
 qry.Append(ccms_sms_template_messageDbString+",");
 qry.Append(creation_timeDbString+",");
 qry.Append(modification_timeDbString+",");
 qry.Append(created_byDbString+",");
 qry.Append(modified_byDbString+",");
 qry.Append(tibco_template_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(ccms_sms_template_idChanged || ccms_sms_template_nameChanged || ccms_sms_template_messageChanged || creation_timeChanged || modification_timeChanged || created_byChanged || modified_byChanged || tibco_template_idChanged ))
 return;
 qry.Append("UPDATE Ccms_sms_template set "); if ( ccms_sms_template_nameChanged )
 {
 qry.Append("ccms_sms_template_name ="+ccms_sms_template_nameDbString);
 qry.Append(",");
 }

 if ( ccms_sms_template_messageChanged )
 {
 qry.Append("ccms_sms_template_message ="+ccms_sms_template_messageDbString);
 qry.Append(",");
 }

 if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( modification_timeChanged )
 {
 qry.Append("modification_time ="+modification_timeDbString);
 qry.Append(",");
 }

 if ( created_byChanged )
 {
 qry.Append("created_by ="+created_byDbString);
 qry.Append(",");
 }

 if ( modified_byChanged )
 {
 qry.Append("modified_by ="+modified_byDbString);
 qry.Append(",");
 }

 if ( tibco_template_idChanged )
 {
 qry.Append("tibco_template_id ="+tibco_template_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("ccms_sms_template_id = "+ccms_sms_template_idDbString);
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
 cmd.CommandText = "DELETE Ccms_sms_template where ccms_sms_template_id = "+ ccms_sms_template_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteCcmsSmsTemplates(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Ccms_sms_template where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
ccms_sms_template_id= 1,
ccms_sms_template_name= 2,
ccms_sms_template_message= 4,
creation_time= 8,
modification_time= 16,
created_by= 32,
modified_by= 64,
tibco_template_id= 128
 }
 #endregion
 public void BulkSave(List<CcmsSmsTemplate> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Ccms_sms_template";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(CcmsSmsTemplate.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <CcmsSmsTemplate> transList,ref DataTable dt)
 {
 foreach (CcmsSmsTemplate tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["ccms_sms_template_id"] =ConnectionFactory.GetNextId();
 Row["ccms_sms_template_name"] = tran.CcmsSmsTemplateName;
 Row["ccms_sms_template_message"] = tran.CcmsSmsTemplateMessage;
 Row["creation_time"] = tran.CreationTime;
 Row["modification_time"] = tran.ModificationTime;
 Row["created_by"] = tran.CreatedBy;
 Row["modified_by"] = tran.ModifiedBy;
 Row["tibco_template_id"] = tran.TibcoTemplateId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
