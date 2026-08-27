
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
 public class SmsCustomerDetail
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public SmsCustomerDetail() { }
 public SmsCustomerDetail( int sms_customer_detail_id,int sms_task_id,int ej_transaction_id ) 
 {
 this.sms_task_id = sms_task_id;
 this.sms_task_idChanged = true;
 this.ej_transaction_id = ej_transaction_id;
 this.ej_transaction_idChanged = true;
 }
 public SmsCustomerDetail( int sms_task_id,string customer_id,string customer_name,string customer_telephone,string customer_mobile_no,string customer_email,string customer_category,decimal? available_balance,string rm_name,string rm_contact,string rm_email,int ej_transaction_id )
 {
 this.sms_task_id = sms_task_id;
 this.sms_task_idChanged = true;
 this.customer_id = customer_id;
 this.customer_idChanged = true;
 this.customer_name = customer_name;
 this.customer_nameChanged = true;
 this.customer_telephone = customer_telephone;
 this.customer_telephoneChanged = true;
 this.customer_mobile_no = customer_mobile_no;
 this.customer_mobile_noChanged = true;
 this.customer_email = customer_email;
 this.customer_emailChanged = true;
 this.customer_category = customer_category;
 this.customer_categoryChanged = true;
 this.available_balance = available_balance;
 this.available_balanceChanged = true;
 this.rm_name = rm_name;
 this.rm_nameChanged = true;
 this.rm_contact = rm_contact;
 this.rm_contactChanged = true;
 this.rm_email = rm_email;
 this.rm_emailChanged = true;
 this.ej_transaction_id = ej_transaction_id;
 this.ej_transaction_idChanged = true;
 }
 private SmsCustomerDetail( int sms_customer_detail_id,int sms_task_id,string customer_id,string customer_name,string customer_telephone,string customer_mobile_no,string customer_email,string customer_category,decimal? available_balance,string rm_name,string rm_contact,string rm_email,int ej_transaction_id )
 {
 this.sms_customer_detail_id = sms_customer_detail_id;
 this.sms_customer_detail_idChanged = true;
 this.sms_task_id = sms_task_id;
 this.sms_task_idChanged = true;
 this.customer_id = customer_id;
 this.customer_idChanged = true;
 this.customer_name = customer_name;
 this.customer_nameChanged = true;
 this.customer_telephone = customer_telephone;
 this.customer_telephoneChanged = true;
 this.customer_mobile_no = customer_mobile_no;
 this.customer_mobile_noChanged = true;
 this.customer_email = customer_email;
 this.customer_emailChanged = true;
 this.customer_category = customer_category;
 this.customer_categoryChanged = true;
 this.available_balance = available_balance;
 this.available_balanceChanged = true;
 this.rm_name = rm_name;
 this.rm_nameChanged = true;
 this.rm_contact = rm_contact;
 this.rm_contactChanged = true;
 this.rm_email = rm_email;
 this.rm_emailChanged = true;
 this.ej_transaction_id = ej_transaction_id;
 this.ej_transaction_idChanged = true;
 }

 #region members and properties for columns

 #region SmsCustomerDetailId
 private bool sms_customer_detail_idChanged = false;
 private int sms_customer_detail_id;
 public int SmsCustomerDetailId
 {
 get { return sms_customer_detail_id; }
 set { 
sms_customer_detail_id = value;
sms_customer_detail_idChanged = true;
 }
 }
 private string sms_customer_detail_idDbString
 {
 get
 {
 return sms_customer_detail_id.ToString();
 }
 }
 #endregion
 #region SmsTaskId
 private bool sms_task_idChanged = false;
 private int sms_task_id;
 public int SmsTaskId
 {
 get { return sms_task_id; }
 set { 
sms_task_id = value;
sms_task_idChanged = true;
 }
 }
 private string sms_task_idDbString
 {
 get
 {
 return sms_task_id.ToString();
 }
 }
 #endregion
 #region CustomerId
 private bool customer_idChanged = false;
 private string customer_id;
 public string CustomerId
 {
 get { return customer_id; }
 set { 
customer_id = value;
customer_idChanged = true;
 }
 }
 private string customer_idDbString
 {
 get
 {
 if (this.customer_id!=null)
 return string.Format("'{0}'",customer_id); else
 return "null";
 }
 }
 #endregion
 #region CustomerName
 private bool customer_nameChanged = false;
 private string customer_name;
 public string CustomerName
 {
 get { return customer_name; }
 set { 
customer_name = value;
customer_nameChanged = true;
 }
 }
 private string customer_nameDbString
 {
 get
 {
 if (this.customer_name!=null)
 return string.Format("'{0}'",customer_name); else
 return "null";
 }
 }
 #endregion
 #region CustomerTelephone
 private bool customer_telephoneChanged = false;
 private string customer_telephone;
 public string CustomerTelephone
 {
 get { return customer_telephone; }
 set { 
customer_telephone = value;
customer_telephoneChanged = true;
 }
 }
 private string customer_telephoneDbString
 {
 get
 {
 if (this.customer_telephone!=null)
 return string.Format("'{0}'",customer_telephone); else
 return "null";
 }
 }
 #endregion
 #region CustomerMobileNo
 private bool customer_mobile_noChanged = false;
 private string customer_mobile_no;
 public string CustomerMobileNo
 {
 get { return customer_mobile_no; }
 set { 
customer_mobile_no = value;
customer_mobile_noChanged = true;
 }
 }
 private string customer_mobile_noDbString
 {
 get
 {
 if (this.customer_mobile_no!=null)
 return string.Format("'{0}'",customer_mobile_no); else
 return "null";
 }
 }
 #endregion
 #region CustomerEmail
 private bool customer_emailChanged = false;
 private string customer_email;
 public string CustomerEmail
 {
 get { return customer_email; }
 set { 
customer_email = value;
customer_emailChanged = true;
 }
 }
 private string customer_emailDbString
 {
 get
 {
 if (this.customer_email!=null)
 return string.Format("'{0}'",customer_email); else
 return "null";
 }
 }
 #endregion
 #region CustomerCategory
 private bool customer_categoryChanged = false;
 private string customer_category;
 public string CustomerCategory
 {
 get { return customer_category; }
 set { 
customer_category = value;
customer_categoryChanged = true;
 }
 }
 private string customer_categoryDbString
 {
 get
 {
 if (this.customer_category!=null)
 return string.Format("'{0}'",customer_category); else
 return "null";
 }
 }
 #endregion
 #region AvailableBalance
 private bool available_balanceChanged = false;
 private decimal? available_balance;
 public decimal? AvailableBalance
 {
 get { return available_balance; }
 set { 
available_balance = value;
available_balanceChanged = true;
 }
 }
 private string available_balanceDbString
 {
 get
 {
 if (this.available_balance.HasValue)
 return available_balance.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region RmName
 private bool rm_nameChanged = false;
 private string rm_name;
 public string RmName
 {
 get { return rm_name; }
 set { 
rm_name = value;
rm_nameChanged = true;
 }
 }
 private string rm_nameDbString
 {
 get
 {
 if (this.rm_name!=null)
 return string.Format("'{0}'",rm_name); else
 return "null";
 }
 }
 #endregion
 #region RmContact
 private bool rm_contactChanged = false;
 private string rm_contact;
 public string RmContact
 {
 get { return rm_contact; }
 set { 
rm_contact = value;
rm_contactChanged = true;
 }
 }
 private string rm_contactDbString
 {
 get
 {
 if (this.rm_contact!=null)
 return string.Format("'{0}'",rm_contact); else
 return "null";
 }
 }
 #endregion
 #region RmEmail
 private bool rm_emailChanged = false;
 private string rm_email;
 public string RmEmail
 {
 get { return rm_email; }
 set { 
rm_email = value;
rm_emailChanged = true;
 }
 }
 private string rm_emailDbString
 {
 get
 {
 if (this.rm_email!=null)
 return string.Format("'{0}'",rm_email); else
 return "null";
 }
 }
 #endregion
 #region EjTransactionId
 private bool ej_transaction_idChanged = false;
 private int ej_transaction_id;
 public int EjTransactionId
 {
 get { return ej_transaction_id; }
 set { 
ej_transaction_id = value;
ej_transaction_idChanged = true;
 }
 }
 private string ej_transaction_idDbString
 {
 get
 {
 return ej_transaction_id.ToString();
 }
 }
 #endregion
 #endregion

 #region SmsCustomerDetailReader
 public class SmsCustomerDetailReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
SmsCustomerDetail currentSmsCustomerDetail;
 Columns columns;
 bool partialRead = false;
 private SmsCustomerDetailReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public SmsCustomerDetailReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public SmsCustomerDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentSmsCustomerDetail; }

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
 currentSmsCustomerDetail = new SmsCustomerDetail();
 if (partialRead)
 { if ((columns & Columns.sms_customer_detail_id) == Columns.sms_customer_detail_id && reader["sms_customer_detail_id"]!=DBNull.Value)
 currentSmsCustomerDetail.sms_customer_detail_id =(int) reader["sms_customer_detail_id"]; 
 if ((columns & Columns.sms_task_id) == Columns.sms_task_id && reader["sms_task_id"]!=DBNull.Value)
 currentSmsCustomerDetail.sms_task_id =(int) reader["sms_task_id"]; 
 if ((columns & Columns.customer_id) == Columns.customer_id && reader["customer_id"]!=DBNull.Value)
 currentSmsCustomerDetail.customer_id =(string) reader["customer_id"]; 
 if ((columns & Columns.customer_name) == Columns.customer_name && reader["customer_name"]!=DBNull.Value)
 currentSmsCustomerDetail.customer_name =(string) reader["customer_name"]; 
 if ((columns & Columns.customer_telephone) == Columns.customer_telephone && reader["customer_telephone"]!=DBNull.Value)
 currentSmsCustomerDetail.customer_telephone =(string) reader["customer_telephone"]; 
 if ((columns & Columns.customer_mobile_no) == Columns.customer_mobile_no && reader["customer_mobile_no"]!=DBNull.Value)
 currentSmsCustomerDetail.customer_mobile_no =(string) reader["customer_mobile_no"]; 
 if ((columns & Columns.customer_email) == Columns.customer_email && reader["customer_email"]!=DBNull.Value)
 currentSmsCustomerDetail.customer_email =(string) reader["customer_email"]; 
 if ((columns & Columns.customer_category) == Columns.customer_category && reader["customer_category"]!=DBNull.Value)
 currentSmsCustomerDetail.customer_category =(string) reader["customer_category"]; 
 if ((columns & Columns.available_balance) == Columns.available_balance && reader["available_balance"]!=DBNull.Value)
 currentSmsCustomerDetail.available_balance =(decimal?) reader["available_balance"]; 
 if ((columns & Columns.rm_name) == Columns.rm_name && reader["rm_name"]!=DBNull.Value)
 currentSmsCustomerDetail.rm_name =(string) reader["rm_name"]; 
 if ((columns & Columns.rm_contact) == Columns.rm_contact && reader["rm_contact"]!=DBNull.Value)
 currentSmsCustomerDetail.rm_contact =(string) reader["rm_contact"]; 
 if ((columns & Columns.rm_email) == Columns.rm_email && reader["rm_email"]!=DBNull.Value)
 currentSmsCustomerDetail.rm_email =(string) reader["rm_email"]; 
 if ((columns & Columns.ej_transaction_id) == Columns.ej_transaction_id && reader["ej_transaction_id"]!=DBNull.Value)
 currentSmsCustomerDetail.ej_transaction_id =(int) reader["ej_transaction_id"]; 

 } else
 {
 if (reader["sms_customer_detail_id"] != DBNull.Value)
 currentSmsCustomerDetail.sms_customer_detail_id = (int) reader["sms_customer_detail_id"]; 
 if (reader["sms_task_id"] != DBNull.Value)
 currentSmsCustomerDetail.sms_task_id = (int) reader["sms_task_id"]; 
 if (reader["customer_id"] != DBNull.Value)
 currentSmsCustomerDetail.customer_id = (string) reader["customer_id"]; 
 if (reader["customer_name"] != DBNull.Value)
 currentSmsCustomerDetail.customer_name = (string) reader["customer_name"]; 
 if (reader["customer_telephone"] != DBNull.Value)
 currentSmsCustomerDetail.customer_telephone = (string) reader["customer_telephone"]; 
 if (reader["customer_mobile_no"] != DBNull.Value)
 currentSmsCustomerDetail.customer_mobile_no = (string) reader["customer_mobile_no"]; 
 if (reader["customer_email"] != DBNull.Value)
 currentSmsCustomerDetail.customer_email = (string) reader["customer_email"]; 
 if (reader["customer_category"] != DBNull.Value)
 currentSmsCustomerDetail.customer_category = (string) reader["customer_category"]; 
 if (reader["available_balance"] != DBNull.Value)
 currentSmsCustomerDetail.available_balance = (decimal?) reader["available_balance"]; 
 if (reader["rm_name"] != DBNull.Value)
 currentSmsCustomerDetail.rm_name = (string) reader["rm_name"]; 
 if (reader["rm_contact"] != DBNull.Value)
 currentSmsCustomerDetail.rm_contact = (string) reader["rm_contact"]; 
 if (reader["rm_email"] != DBNull.Value)
 currentSmsCustomerDetail.rm_email = (string) reader["rm_email"]; 
 if (reader["ej_transaction_id"] != DBNull.Value)
 currentSmsCustomerDetail.ej_transaction_id = (int) reader["ej_transaction_id"]; 
 } 

 currentSmsCustomerDetail.isNewEntity = false;
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

 public SmsCustomerDetail CurrentSmsCustomerDetail
 {
 get{ return currentSmsCustomerDetail; }
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


 #region SmsCustomerDetail functions

 public static SmsCustomerDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.sms_customer_detail_id == (Columns.sms_customer_detail_id & columns))
 qry.Append("sms_customer_detail_id,");
 if (Columns.sms_task_id == (Columns.sms_task_id & columns))
 qry.Append("sms_task_id,");
 if (Columns.customer_id == (Columns.customer_id & columns))
 qry.Append("customer_id,");
 if (Columns.customer_name == (Columns.customer_name & columns))
 qry.Append("customer_name,");
 if (Columns.customer_telephone == (Columns.customer_telephone & columns))
 qry.Append("customer_telephone,");
 if (Columns.customer_mobile_no == (Columns.customer_mobile_no & columns))
 qry.Append("customer_mobile_no,");
 if (Columns.customer_email == (Columns.customer_email & columns))
 qry.Append("customer_email,");
 if (Columns.customer_category == (Columns.customer_category & columns))
 qry.Append("customer_category,");
 if (Columns.available_balance == (Columns.available_balance & columns))
 qry.Append("available_balance,");
 if (Columns.rm_name == (Columns.rm_name & columns))
 qry.Append("rm_name,");
 if (Columns.rm_contact == (Columns.rm_contact & columns))
 qry.Append("rm_contact,");
 if (Columns.rm_email == (Columns.rm_email & columns))
 qry.Append("rm_email,");
 if (Columns.ej_transaction_id == (Columns.ej_transaction_id & columns))
 qry.Append("ej_transaction_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Sms_customer_detail ");

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
 return new SmsCustomerDetailReader(cmd.ExecuteReader(), conn, columns);
 }

 static public SmsCustomerDetailReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static SmsCustomerDetailReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select sms_customer_detail_id,sms_task_id,customer_id,customer_name,customer_telephone,customer_mobile_no,customer_email,customer_category,available_balance,rm_name,rm_contact,rm_email,ej_transaction_id from Sms_customer_detail ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new SmsCustomerDetailReader(cmd.ExecuteReader(), conn);
 }

 static public SmsCustomerDetailReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static SmsCustomerDetail LoadSmsCustomerDetail(string where)
 {
SmsCustomerDetailReader reader = SmsCustomerDetail.ExecuteReader(where);
SmsCustomerDetail _smscustomerdetail = null;
 if (reader.Read())
 _smscustomerdetail = reader.CurrentSmsCustomerDetail;
 reader.Close();
 return _smscustomerdetail;
 }

 public static SmsCustomerDetail LoadSmsCustomerDetail(string where, IDbConnection conn)
 {
SmsCustomerDetailReader reader = SmsCustomerDetail.ExecuteReader(where, conn);
SmsCustomerDetail _smscustomerdetail = null;
 if (reader.Read())
 _smscustomerdetail = reader.CurrentSmsCustomerDetail;
 reader.Close(false);
 return _smscustomerdetail;
 }

 public static SmsCustomerDetail LoadSmsCustomerDetailByPk( int sms_customer_detail_id )
 {
 return LoadSmsCustomerDetail( " sms_customer_detail_id="+sms_customer_detail_id );
 }

 public static SmsCustomerDetail LoadSmsCustomerDetailByPk( int sms_customer_detail_id , IDbConnection conn)
 {
 return LoadSmsCustomerDetail(" sms_customer_detail_id="+sms_customer_detail_id , conn);
 }

 public void Save()
 {
 if (sms_customer_detail_idChanged || sms_task_idChanged || customer_idChanged || customer_nameChanged || customer_telephoneChanged || customer_mobile_noChanged || customer_emailChanged || customer_categoryChanged || available_balanceChanged || rm_nameChanged || rm_contactChanged || rm_emailChanged || ej_transaction_idChanged )
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
 if (sms_customer_detail_idChanged || sms_task_idChanged || customer_idChanged || customer_nameChanged || customer_telephoneChanged || customer_mobile_noChanged || customer_emailChanged || customer_categoryChanged || available_balanceChanged || rm_nameChanged || rm_contactChanged || rm_emailChanged || ej_transaction_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Sms_customer_detail( sms_customer_detail_id,sms_task_id,customer_id,customer_name,customer_telephone,customer_mobile_no,customer_email,customer_category,available_balance,rm_name,rm_contact,rm_email,ej_transaction_id ) values(");
 lock (ConnectionFactory.connectionString) { this.sms_customer_detail_id = ConnectionFactory.GetNextId();
 qry.Append(this.sms_customer_detail_id);
 } qry.Append(",");
 qry.Append(sms_task_idDbString+",");
 qry.Append(customer_idDbString+",");
 qry.Append(customer_nameDbString+",");
 qry.Append(customer_telephoneDbString+",");
 qry.Append(customer_mobile_noDbString+",");
 qry.Append(customer_emailDbString+",");
 qry.Append(customer_categoryDbString+",");
 qry.Append(available_balanceDbString+",");
 qry.Append(rm_nameDbString+",");
 qry.Append(rm_contactDbString+",");
 qry.Append(rm_emailDbString+",");
 qry.Append(ej_transaction_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(sms_customer_detail_idChanged || sms_task_idChanged || customer_idChanged || customer_nameChanged || customer_telephoneChanged || customer_mobile_noChanged || customer_emailChanged || customer_categoryChanged || available_balanceChanged || rm_nameChanged || rm_contactChanged || rm_emailChanged || ej_transaction_idChanged ))
 return;
 qry.Append("UPDATE Sms_customer_detail set "); if ( sms_task_idChanged )
 {
 qry.Append("sms_task_id ="+sms_task_idDbString);
 qry.Append(",");
 }

 if ( customer_idChanged )
 {
 qry.Append("customer_id ="+customer_idDbString);
 qry.Append(",");
 }

 if ( customer_nameChanged )
 {
 qry.Append("customer_name ="+customer_nameDbString);
 qry.Append(",");
 }

 if ( customer_telephoneChanged )
 {
 qry.Append("customer_telephone ="+customer_telephoneDbString);
 qry.Append(",");
 }

 if ( customer_mobile_noChanged )
 {
 qry.Append("customer_mobile_no ="+customer_mobile_noDbString);
 qry.Append(",");
 }

 if ( customer_emailChanged )
 {
 qry.Append("customer_email ="+customer_emailDbString);
 qry.Append(",");
 }

 if ( customer_categoryChanged )
 {
 qry.Append("customer_category ="+customer_categoryDbString);
 qry.Append(",");
 }

 if ( available_balanceChanged )
 {
 qry.Append("available_balance ="+available_balanceDbString);
 qry.Append(",");
 }

 if ( rm_nameChanged )
 {
 qry.Append("rm_name ="+rm_nameDbString);
 qry.Append(",");
 }

 if ( rm_contactChanged )
 {
 qry.Append("rm_contact ="+rm_contactDbString);
 qry.Append(",");
 }

 if ( rm_emailChanged )
 {
 qry.Append("rm_email ="+rm_emailDbString);
 qry.Append(",");
 }

 if ( ej_transaction_idChanged )
 {
 qry.Append("ej_transaction_id ="+ej_transaction_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("sms_customer_detail_id = "+sms_customer_detail_idDbString);
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
 cmd.CommandText = "DELETE Sms_customer_detail where sms_customer_detail_id = "+ sms_customer_detail_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteSmsCustomerDetails(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Sms_customer_detail where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
sms_customer_detail_id= 1,
sms_task_id= 2,
customer_id= 4,
customer_name= 8,
customer_telephone= 16,
customer_mobile_no= 32,
customer_email= 64,
customer_category= 128,
available_balance= 256,
rm_name= 512,
rm_contact= 1024,
rm_email= 2048,
ej_transaction_id= 4096
 }
 #endregion
 public void BulkSave(List<SmsCustomerDetail> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Sms_customer_detail";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(SmsCustomerDetail.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <SmsCustomerDetail> transList,ref DataTable dt)
 {
 foreach (SmsCustomerDetail tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["sms_customer_detail_id"] =ConnectionFactory.GetNextId();
 Row["sms_task_id"] = tran.SmsTaskId;
 Row["customer_id"] = tran.CustomerId;
 Row["customer_name"] = tran.CustomerName;
 Row["customer_telephone"] = tran.CustomerTelephone;
 Row["customer_mobile_no"] = tran.CustomerMobileNo;
 Row["customer_email"] = tran.CustomerEmail;
 Row["customer_category"] = tran.CustomerCategory;
 Row["available_balance"] = tran.AvailableBalance;
 Row["rm_name"] = tran.RmName;
 Row["rm_contact"] = tran.RmContact;
 Row["rm_email"] = tran.RmEmail;
 Row["ej_transaction_id"] = tran.EjTransactionId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
