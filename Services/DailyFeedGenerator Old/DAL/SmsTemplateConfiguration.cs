

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
 public class SmsTemplateConfiguration
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public SmsTemplateConfiguration() { }
 public SmsTemplateConfiguration( int sms_template_configuration_id,string status,int sms_transaction_type_detail_id,int template_id,int channel_id ) 
 {
 this.status = status;
 this.statusChanged = true;
 this.sms_transaction_type_detail_id = sms_transaction_type_detail_id;
 this.sms_transaction_type_detail_idChanged = true;
 this.template_id = template_id;
 this.template_idChanged = true;
 this.channel_id = channel_id;
 this.channel_idChanged = true;
 }
 public SmsTemplateConfiguration( string status,int sms_transaction_type_detail_id,int template_id,int channel_id,int? alert_type_id )
 {
 this.status = status;
 this.statusChanged = true;
 this.sms_transaction_type_detail_id = sms_transaction_type_detail_id;
 this.sms_transaction_type_detail_idChanged = true;
 this.template_id = template_id;
 this.template_idChanged = true;
 this.channel_id = channel_id;
 this.channel_idChanged = true;
 this.alert_type_id = alert_type_id;
 this.alert_type_idChanged = true;
 }
 private SmsTemplateConfiguration( int sms_template_configuration_id,string status,int sms_transaction_type_detail_id,int template_id,int channel_id,int? alert_type_id )
 {
 this.sms_template_configuration_id = sms_template_configuration_id;
 this.sms_template_configuration_idChanged = true;
 this.status = status;
 this.statusChanged = true;
 this.sms_transaction_type_detail_id = sms_transaction_type_detail_id;
 this.sms_transaction_type_detail_idChanged = true;
 this.template_id = template_id;
 this.template_idChanged = true;
 this.channel_id = channel_id;
 this.channel_idChanged = true;
 this.alert_type_id = alert_type_id;
 this.alert_type_idChanged = true;
 }

 #region members and properties for columns

 #region SmsTemplateConfigurationId
 private bool sms_template_configuration_idChanged = false;
 private int sms_template_configuration_id;
 public int SmsTemplateConfigurationId
 {
 get { return sms_template_configuration_id; }
 set { 
sms_template_configuration_id = value;
sms_template_configuration_idChanged = true;
 }
 }
 private string sms_template_configuration_idDbString
 {
 get
 {
 return sms_template_configuration_id.ToString();
 }
 }
 #endregion
 #region Status
 private bool statusChanged = false;
 private string status;
 public string Status
 {
 get { return status; }
 set { 
status = value;
statusChanged = true;
 }
 }
 private string statusDbString
 {
 get
 {
 if (this.status!=null)
 return string.Format("'{0}'",status); else
 return "null";
 }
 }
 #endregion
 #region SmsTransactionTypeDetailId
 private bool sms_transaction_type_detail_idChanged = false;
 private int sms_transaction_type_detail_id;
 public int SmsTransactionTypeDetailId
 {
 get { return sms_transaction_type_detail_id; }
 set { 
sms_transaction_type_detail_id = value;
sms_transaction_type_detail_idChanged = true;
 }
 }
 private string sms_transaction_type_detail_idDbString
 {
 get
 {
 return sms_transaction_type_detail_id.ToString();
 }
 }
 #endregion
 #region TemplateId
 private bool template_idChanged = false;
 private int template_id;
 public int TemplateId
 {
 get { return template_id; }
 set { 
template_id = value;
template_idChanged = true;
 }
 }
 private string template_idDbString
 {
 get
 {
 return template_id.ToString();
 }
 }
 #endregion
 #region ChannelId
 private bool channel_idChanged = false;
 private int channel_id;
 public int ChannelId
 {
 get { return channel_id; }
 set { 
channel_id = value;
channel_idChanged = true;
 }
 }
 private string channel_idDbString
 {
 get
 {
 return channel_id.ToString();
 }
 }
 #endregion
 #region AlertTypeId
 private bool alert_type_idChanged = false;
 private int? alert_type_id;
 public int? AlertTypeId
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
 if (this.alert_type_id.HasValue)
 return alert_type_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region SmsTemplateConfigurationReader
 public class SmsTemplateConfigurationReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
SmsTemplateConfiguration currentSmsTemplateConfiguration;
 Columns columns;
 bool partialRead = false;
 private SmsTemplateConfigurationReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public SmsTemplateConfigurationReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public SmsTemplateConfigurationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentSmsTemplateConfiguration; }

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
 currentSmsTemplateConfiguration = new SmsTemplateConfiguration();
 if (partialRead)
 { if ((columns & Columns.sms_template_configuration_id) == Columns.sms_template_configuration_id && reader["sms_template_configuration_id"]!=DBNull.Value)
 currentSmsTemplateConfiguration.sms_template_configuration_id =(int) reader["sms_template_configuration_id"]; 
 if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
 currentSmsTemplateConfiguration.status =(string) reader["status"]; 
 if ((columns & Columns.sms_transaction_type_detail_id) == Columns.sms_transaction_type_detail_id && reader["sms_transaction_type_detail_id"]!=DBNull.Value)
 currentSmsTemplateConfiguration.sms_transaction_type_detail_id =(int) reader["sms_transaction_type_detail_id"]; 
 if ((columns & Columns.template_id) == Columns.template_id && reader["template_id"]!=DBNull.Value)
 currentSmsTemplateConfiguration.template_id =(int) reader["template_id"]; 
 if ((columns & Columns.channel_id) == Columns.channel_id && reader["channel_id"]!=DBNull.Value)
 currentSmsTemplateConfiguration.channel_id =(int) reader["channel_id"]; 
 if ((columns & Columns.alert_type_id) == Columns.alert_type_id && reader["alert_type_id"]!=DBNull.Value)
 currentSmsTemplateConfiguration.alert_type_id =(int?) reader["alert_type_id"]; 

 } else
 {
 if (reader["sms_template_configuration_id"] != DBNull.Value)
 currentSmsTemplateConfiguration.sms_template_configuration_id = (int) reader["sms_template_configuration_id"]; 
 if (reader["status"] != DBNull.Value)
 currentSmsTemplateConfiguration.status = (string) reader["status"]; 
 if (reader["sms_transaction_type_detail_id"] != DBNull.Value)
 currentSmsTemplateConfiguration.sms_transaction_type_detail_id = (int) reader["sms_transaction_type_detail_id"]; 
 if (reader["template_id"] != DBNull.Value)
 currentSmsTemplateConfiguration.template_id = (int) reader["template_id"]; 
 if (reader["channel_id"] != DBNull.Value)
 currentSmsTemplateConfiguration.channel_id = (int) reader["channel_id"]; 
 if (reader["alert_type_id"] != DBNull.Value)
 currentSmsTemplateConfiguration.alert_type_id = (int?) reader["alert_type_id"]; 
 } 

 currentSmsTemplateConfiguration.isNewEntity = false;
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

 public SmsTemplateConfiguration CurrentSmsTemplateConfiguration
 {
 get{ return currentSmsTemplateConfiguration; }
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


 #region SmsTemplateConfiguration functions

 public static SmsTemplateConfigurationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.sms_template_configuration_id == (Columns.sms_template_configuration_id & columns))
 qry.Append("sms_template_configuration_id,");
 if (Columns.status == (Columns.status & columns))
 qry.Append("status,");
 if (Columns.sms_transaction_type_detail_id == (Columns.sms_transaction_type_detail_id & columns))
 qry.Append("sms_transaction_type_detail_id,");
 if (Columns.template_id == (Columns.template_id & columns))
 qry.Append("template_id,");
 if (Columns.channel_id == (Columns.channel_id & columns))
 qry.Append("channel_id,");
 if (Columns.alert_type_id == (Columns.alert_type_id & columns))
 qry.Append("alert_type_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Sms_template_configuration ");

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
 return new SmsTemplateConfigurationReader(cmd.ExecuteReader(), conn, columns);
 }

 static public SmsTemplateConfigurationReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static SmsTemplateConfigurationReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select sms_template_configuration_id,status,sms_transaction_type_detail_id,template_id,channel_id,alert_type_id from Sms_template_configuration ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new SmsTemplateConfigurationReader(cmd.ExecuteReader(), conn);
 }

 static public SmsTemplateConfigurationReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static SmsTemplateConfiguration LoadSmsTemplateConfiguration(string where)
 {
SmsTemplateConfigurationReader reader = SmsTemplateConfiguration.ExecuteReader(where);
SmsTemplateConfiguration _smstemplateconfiguration = null;
 if (reader.Read())
 _smstemplateconfiguration = reader.CurrentSmsTemplateConfiguration;
 reader.Close();
 return _smstemplateconfiguration;
 }

 public static SmsTemplateConfiguration LoadSmsTemplateConfiguration(string where, IDbConnection conn)
 {
SmsTemplateConfigurationReader reader = SmsTemplateConfiguration.ExecuteReader(where, conn);
SmsTemplateConfiguration _smstemplateconfiguration = null;
 if (reader.Read())
 _smstemplateconfiguration = reader.CurrentSmsTemplateConfiguration;
 reader.Close(false);
 return _smstemplateconfiguration;
 }

 public static SmsTemplateConfiguration LoadSmsTemplateConfigurationByPk( int sms_template_configuration_id )
 {
 return LoadSmsTemplateConfiguration( " sms_template_configuration_id="+sms_template_configuration_id );
 }

 public static SmsTemplateConfiguration LoadSmsTemplateConfigurationByPk( int sms_template_configuration_id , IDbConnection conn)
 {
 return LoadSmsTemplateConfiguration(" sms_template_configuration_id="+sms_template_configuration_id , conn);
 }

 public void Save()
 {
 if (sms_template_configuration_idChanged || statusChanged || sms_transaction_type_detail_idChanged || template_idChanged || channel_idChanged || alert_type_idChanged )
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
 if (sms_template_configuration_idChanged || statusChanged || sms_transaction_type_detail_idChanged || template_idChanged || channel_idChanged || alert_type_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Sms_template_configuration( sms_template_configuration_id,status,sms_transaction_type_detail_id,template_id,channel_id,alert_type_id ) values(");
 lock (ConnectionFactory.connectionString) { this.sms_template_configuration_id = ConnectionFactory.GetNextId();
 qry.Append(this.sms_template_configuration_id);
 } qry.Append(",");
 qry.Append(statusDbString+",");
 qry.Append(sms_transaction_type_detail_idDbString+",");
 qry.Append(template_idDbString+",");
 qry.Append(channel_idDbString+",");
 qry.Append(alert_type_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(sms_template_configuration_idChanged || statusChanged || sms_transaction_type_detail_idChanged || template_idChanged || channel_idChanged || alert_type_idChanged ))
 return;
 qry.Append("UPDATE Sms_template_configuration set "); if ( statusChanged )
 {
 qry.Append("status ="+statusDbString);
 qry.Append(",");
 }

 if ( sms_transaction_type_detail_idChanged )
 {
 qry.Append("sms_transaction_type_detail_id ="+sms_transaction_type_detail_idDbString);
 qry.Append(",");
 }

 if ( template_idChanged )
 {
 qry.Append("template_id ="+template_idDbString);
 qry.Append(",");
 }

 if ( channel_idChanged )
 {
 qry.Append("channel_id ="+channel_idDbString);
 qry.Append(",");
 }

 if ( alert_type_idChanged )
 {
 qry.Append("alert_type_id ="+alert_type_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("sms_template_configuration_id = "+sms_template_configuration_idDbString);
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
 cmd.CommandText = "DELETE Sms_template_configuration where sms_template_configuration_id = "+ sms_template_configuration_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteSmsTemplateConfigurations(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Sms_template_configuration where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
sms_template_configuration_id= 1,
status= 2,
sms_transaction_type_detail_id= 4,
template_id= 8,
channel_id= 16,
alert_type_id= 32
 }
 #endregion
 public void BulkSave(List<SmsTemplateConfiguration> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Sms_template_configuration";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(SmsTemplateConfiguration.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <SmsTemplateConfiguration> transList,ref DataTable dt)
 {
 foreach (SmsTemplateConfiguration tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["sms_template_configuration_id"] =ConnectionFactory.GetNextId();
 Row["status"] = tran.Status;
 Row["sms_transaction_type_detail_id"] = tran.SmsTransactionTypeDetailId;
 Row["template_id"] = tran.TemplateId;
 Row["channel_id"] = tran.ChannelId;
 Row["alert_type_id"] = tran.AlertTypeId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
