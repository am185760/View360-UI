

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
 public class AlertType
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public AlertType() { }
 public AlertType( int alert_type_id,string alert_type_name,string alert_default_text ) 
 {
 this.alert_type_name = alert_type_name;
 this.alert_type_nameChanged = true;
 this.alert_default_text = alert_default_text;
 this.alert_default_textChanged = true;
 }
 public AlertType( string alert_type_name,string alert_additional_text,string alert_default_text,bool? send_email_notification,bool? open_ticket_in_gasper,string tpa_code,string tpa_value )
 {
 this.alert_type_name = alert_type_name;
 this.alert_type_nameChanged = true;
 this.alert_additional_text = alert_additional_text;
 this.alert_additional_textChanged = true;
 this.alert_default_text = alert_default_text;
 this.alert_default_textChanged = true;
 this.send_email_notification = send_email_notification;
 this.send_email_notificationChanged = true;
 this.open_ticket_in_gasper = open_ticket_in_gasper;
 this.open_ticket_in_gasperChanged = true;
 this.tpa_code = tpa_code;
 this.tpa_codeChanged = true;
 this.tpa_value = tpa_value;
 this.tpa_valueChanged = true;
 }
 private AlertType( int alert_type_id,string alert_type_name,string alert_additional_text,string alert_default_text,bool? send_email_notification,bool? open_ticket_in_gasper,string tpa_code,string tpa_value )
 {
 this.alert_type_id = alert_type_id;
 this.alert_type_idChanged = true;
 this.alert_type_name = alert_type_name;
 this.alert_type_nameChanged = true;
 this.alert_additional_text = alert_additional_text;
 this.alert_additional_textChanged = true;
 this.alert_default_text = alert_default_text;
 this.alert_default_textChanged = true;
 this.send_email_notification = send_email_notification;
 this.send_email_notificationChanged = true;
 this.open_ticket_in_gasper = open_ticket_in_gasper;
 this.open_ticket_in_gasperChanged = true;
 this.tpa_code = tpa_code;
 this.tpa_codeChanged = true;
 this.tpa_value = tpa_value;
 this.tpa_valueChanged = true;
 }

 #region members and properties for columns

 #region AlertTypeId
 private bool alert_type_idChanged = false;
 private int alert_type_id;
 public int AlertTypeId
 {
 get { return alert_type_id; }
 set { 
alert_type_id = value;
alert_type_idChanged = true;
 }
 }
 private string alert_type_idDbString
 {
 get
 {
 return alert_type_id.ToString();
 }
 }
 #endregion
 #region AlertTypeName
 private bool alert_type_nameChanged = false;
 private string alert_type_name;
 public string AlertTypeName
 {
 get { return alert_type_name; }
 set { 
alert_type_name = value;
alert_type_nameChanged = true;
 }
 }
 private string alert_type_nameDbString
 {
 get
 {
 if (this.alert_type_name!=null)
 return string.Format("'{0}'",alert_type_name); else
 return "null";
 }
 }
 #endregion
 #region AlertAdditionalText
 private bool alert_additional_textChanged = false;
 private string alert_additional_text;
 public string AlertAdditionalText
 {
 get { return alert_additional_text; }
 set { 
alert_additional_text = value;
alert_additional_textChanged = true;
 }
 }
 private string alert_additional_textDbString
 {
 get
 {
 if (this.alert_additional_text!=null)
 return string.Format("'{0}'",alert_additional_text); else
 return "null";
 }
 }
 #endregion
 #region AlertDefaultText
 private bool alert_default_textChanged = false;
 private string alert_default_text;
 public string AlertDefaultText
 {
 get { return alert_default_text; }
 set { 
alert_default_text = value;
alert_default_textChanged = true;
 }
 }
 private string alert_default_textDbString
 {
 get
 {
 if (this.alert_default_text!=null)
 return string.Format("'{0}'",alert_default_text); else
 return "null";
 }
 }
 #endregion
 #region SendEmailNotification
 private bool send_email_notificationChanged = false;
 private bool? send_email_notification;
 public bool? SendEmailNotification
 {
 get { return send_email_notification; }
 set { 
send_email_notification = value;
send_email_notificationChanged = true;
 }
 }
 private string send_email_notificationDbString
 {
 get
 {
 if (this.send_email_notification.HasValue)
 return send_email_notification.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #region OpenTicketInGasper
 private bool open_ticket_in_gasperChanged = false;
 private bool? open_ticket_in_gasper;
 public bool? OpenTicketInGasper
 {
 get { return open_ticket_in_gasper; }
 set { 
open_ticket_in_gasper = value;
open_ticket_in_gasperChanged = true;
 }
 }
 private string open_ticket_in_gasperDbString
 {
 get
 {
 if (this.open_ticket_in_gasper.HasValue)
 return open_ticket_in_gasper.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #region TpaCode
 private bool tpa_codeChanged = false;
 private string tpa_code;
 public string TpaCode
 {
 get { return tpa_code; }
 set { 
tpa_code = value;
tpa_codeChanged = true;
 }
 }
 private string tpa_codeDbString
 {
 get
 {
 if (this.tpa_code!=null)
 return string.Format("'{0}'",tpa_code); else
 return "null";
 }
 }
 #endregion
 #region TpaValue
 private bool tpa_valueChanged = false;
 private string tpa_value;
 public string TpaValue
 {
 get { return tpa_value; }
 set { 
tpa_value = value;
tpa_valueChanged = true;
 }
 }
 private string tpa_valueDbString
 {
 get
 {
 if (this.tpa_value!=null)
 return string.Format("'{0}'",tpa_value); else
 return "null";
 }
 }
 #endregion
 #endregion

 #region AlertTypeReader
 public class AlertTypeReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
AlertType currentAlertType;
 Columns columns;
 bool partialRead = false;
 private AlertTypeReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public AlertTypeReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public AlertTypeReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentAlertType; }

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
 currentAlertType = new AlertType();
 if (partialRead)
 { if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"]!=DBNull.Value)
 currentAlertType.alert_type_id =(int) reader["alert_type_id"]; 
 if ((columns & Columns.alert_type_name) == Columns.alert_type_name && reader["alert_type_name"]!=DBNull.Value)
 currentAlertType.alert_type_name =(string) reader["alert_type_name"]; 
 if ((columns & Columns.alert_additional_text) == Columns.alert_additional_text && reader["alert_additional_text"]!=DBNull.Value)
 currentAlertType.alert_additional_text =(string) reader["alert_additional_text"]; 
 if ((columns & Columns.alert_default_text) == Columns.alert_default_text && reader["alert_default_text"]!=DBNull.Value)
 currentAlertType.alert_default_text =(string) reader["alert_default_text"]; 
 if ((columns & Columns.send_email_notification) == Columns.send_email_notification && reader["send_email_notification"]!=DBNull.Value)
 currentAlertType.send_email_notification =(bool?) reader["send_email_notification"]; 
 if ((columns & Columns.open_ticket_in_gasper) == Columns.open_ticket_in_gasper && reader["open_ticket_in_gasper"]!=DBNull.Value)
 currentAlertType.open_ticket_in_gasper =(bool?) reader["open_ticket_in_gasper"]; 
 if ((columns & Columns.tpa_code) == Columns.tpa_code && reader["tpa_code"]!=DBNull.Value)
 currentAlertType.tpa_code =(string) reader["tpa_code"]; 
 if ((columns & Columns.tpa_value) == Columns.tpa_value && reader["tpa_value"]!=DBNull.Value)
 currentAlertType.tpa_value =(string) reader["tpa_value"]; 

 } else
 {
 if (reader["alert_type_id"] != DBNull.Value)
 currentAlertType.alert_type_id = (int) reader["alert_type_id"]; 
 if (reader["alert_type_name"] != DBNull.Value)
 currentAlertType.alert_type_name = (string) reader["alert_type_name"]; 
 if (reader["alert_additional_text"] != DBNull.Value)
 currentAlertType.alert_additional_text = (string) reader["alert_additional_text"]; 
 if (reader["alert_default_text"] != DBNull.Value)
 currentAlertType.alert_default_text = (string) reader["alert_default_text"]; 
 if (reader["send_email_notification"] != DBNull.Value)
 currentAlertType.send_email_notification = (bool?) reader["send_email_notification"]; 
 if (reader["open_ticket_in_gasper"] != DBNull.Value)
 currentAlertType.open_ticket_in_gasper = (bool?) reader["open_ticket_in_gasper"]; 
 if (reader["tpa_code"] != DBNull.Value)
 currentAlertType.tpa_code = (string) reader["tpa_code"]; 
 if (reader["tpa_value"] != DBNull.Value)
 currentAlertType.tpa_value = (string) reader["tpa_value"]; 
 } 

 currentAlertType.isNewEntity = false;
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

 public AlertType CurrentAlertType
 {
 get{ return currentAlertType; }
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


 #region AlertType functions

 public static AlertTypeReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.alert_type_id == (Columns.alert_type_id & columns))
 qry.Append("alert_type_id,");
 if (Columns.alert_type_name == (Columns.alert_type_name & columns))
 qry.Append("alert_type_name,");
 if (Columns.alert_additional_text == (Columns.alert_additional_text & columns))
 qry.Append("alert_additional_text,");
 if (Columns.alert_default_text == (Columns.alert_default_text & columns))
 qry.Append("alert_default_text,");
 if (Columns.send_email_notification == (Columns.send_email_notification & columns))
 qry.Append("send_email_notification,");
 if (Columns.open_ticket_in_gasper == (Columns.open_ticket_in_gasper & columns))
 qry.Append("open_ticket_in_gasper,");
 if (Columns.tpa_code == (Columns.tpa_code & columns))
 qry.Append("tpa_code,");
 if (Columns.tpa_value == (Columns.tpa_value & columns))
 qry.Append("tpa_value,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Alert_type ");

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
 return new AlertTypeReader(cmd.ExecuteReader(), conn, columns);
 }

 static public AlertTypeReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static AlertTypeReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select alert_type_id,alert_type_name,alert_additional_text,alert_default_text,send_email_notification,open_ticket_in_gasper,tpa_code,tpa_value from Alert_type ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new AlertTypeReader(cmd.ExecuteReader(), conn);
 }

 static public AlertTypeReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static AlertType LoadAlertType(string where)
 {
AlertTypeReader reader = AlertType.ExecuteReader(where);
AlertType _alerttype = null;
 if (reader.Read())
 _alerttype = reader.CurrentAlertType;
 reader.Close();
 return _alerttype;
 }

 public static AlertType LoadAlertType(string where, IDbConnection conn)
 {
AlertTypeReader reader = AlertType.ExecuteReader(where, conn);
AlertType _alerttype = null;
 if (reader.Read())
 _alerttype = reader.CurrentAlertType;
 reader.Close(false);
 return _alerttype;
 }

 public static AlertType LoadAlertTypeByPk( int alert_type_id )
 {
 return LoadAlertType( " alert_type_id="+alert_type_id );
 }

 public static AlertType LoadAlertTypeByPk( int alert_type_id , IDbConnection conn)
 {
 return LoadAlertType(" alert_type_id="+alert_type_id , conn);
 }

 public void Save()
 {
 if (alert_type_idChanged || alert_type_nameChanged || alert_additional_textChanged || alert_default_textChanged || send_email_notificationChanged || open_ticket_in_gasperChanged || tpa_codeChanged || tpa_valueChanged )
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
 if (alert_type_idChanged || alert_type_nameChanged || alert_additional_textChanged || alert_default_textChanged || send_email_notificationChanged || open_ticket_in_gasperChanged || tpa_codeChanged || tpa_valueChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Alert_type( alert_type_id,alert_type_name,alert_additional_text,alert_default_text,send_email_notification,open_ticket_in_gasper,tpa_code,tpa_value ) values(");
 lock (ConnectionFactory.connectionString) { this.alert_type_id = ConnectionFactory.GetNextId();
 qry.Append(this.alert_type_id);
 } qry.Append(",");
 qry.Append(alert_type_nameDbString+",");
 qry.Append(alert_additional_textDbString+",");
 qry.Append(alert_default_textDbString+",");
 qry.Append(send_email_notificationDbString+",");
 qry.Append(open_ticket_in_gasperDbString+",");
 qry.Append(tpa_codeDbString+",");
 qry.Append(tpa_valueDbString);
 qry.Append(");");

 }
 else
 {
 if (!(alert_type_idChanged || alert_type_nameChanged || alert_additional_textChanged || alert_default_textChanged || send_email_notificationChanged || open_ticket_in_gasperChanged || tpa_codeChanged || tpa_valueChanged ))
 return;
 qry.Append("UPDATE Alert_type set "); if ( alert_type_nameChanged )
 {
 qry.Append("alert_type_name ="+alert_type_nameDbString);
 qry.Append(",");
 }

 if ( alert_additional_textChanged )
 {
 qry.Append("alert_additional_text ="+alert_additional_textDbString);
 qry.Append(",");
 }

 if ( alert_default_textChanged )
 {
 qry.Append("alert_default_text ="+alert_default_textDbString);
 qry.Append(",");
 }

 if ( send_email_notificationChanged )
 {
 qry.Append("send_email_notification ="+send_email_notificationDbString);
 qry.Append(",");
 }

 if ( open_ticket_in_gasperChanged )
 {
 qry.Append("open_ticket_in_gasper ="+open_ticket_in_gasperDbString);
 qry.Append(",");
 }

 if ( tpa_codeChanged )
 {
 qry.Append("tpa_code ="+tpa_codeDbString);
 qry.Append(",");
 }

 if ( tpa_valueChanged )
 {
 qry.Append("tpa_value ="+tpa_valueDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("alert_type_id = "+alert_type_idDbString);
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
 cmd.CommandText = "DELETE Alert_type where alert_type_id = "+ alert_type_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteAlertTypes(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Alert_type where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
alert_type_id= 1,
alert_type_name= 2,
alert_additional_text= 4,
alert_default_text= 8,
send_email_notification= 16,
open_ticket_in_gasper= 32,
tpa_code= 64,
tpa_value= 128
 }
 #endregion
 public void BulkSave(List<AlertType> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Alert_type";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(AlertType.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <AlertType> transList,ref DataTable dt)
 {
 foreach (AlertType tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["alert_type_id"] =ConnectionFactory.GetNextId();
 Row["alert_type_name"] = tran.AlertTypeName;
 Row["alert_additional_text"] = tran.AlertAdditionalText;
 Row["alert_default_text"] = tran.AlertDefaultText;
 Row["send_email_notification"] = tran.SendEmailNotification;
 Row["open_ticket_in_gasper"] = tran.OpenTicketInGasper;
 Row["tpa_code"] = tran.TpaCode;
 Row["tpa_value"] = tran.TpaValue;
 dt.Rows.Add(Row);
 } }
 }
 }

 
