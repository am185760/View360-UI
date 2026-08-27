
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
 public class ExceptionHandlingCriteria
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ExceptionHandlingCriteria() { }
 public ExceptionHandlingCriteria( int exception_handling_criteria_id,string message ) 
 {
 this.message = message;
 this.messageChanged = true;
 }
 public ExceptionHandlingCriteria( string message,bool? is_precondition,bool? is_disputed,bool? is_sms_task_required,int? transaction_type_id )
 {
 this.message = message;
 this.messageChanged = true;
 this.is_precondition = is_precondition;
 this.is_preconditionChanged = true;
 this.is_disputed = is_disputed;
 this.is_disputedChanged = true;
 this.is_sms_task_required = is_sms_task_required;
 this.is_sms_task_requiredChanged = true;
 this.transaction_type_id = transaction_type_id;
 this.transaction_type_idChanged = true;
 }
 private ExceptionHandlingCriteria( int exception_handling_criteria_id,string message,bool? is_precondition,bool? is_disputed,bool? is_sms_task_required,int? transaction_type_id )
 {
 this.exception_handling_criteria_id = exception_handling_criteria_id;
 this.exception_handling_criteria_idChanged = true;
 this.message = message;
 this.messageChanged = true;
 this.is_precondition = is_precondition;
 this.is_preconditionChanged = true;
 this.is_disputed = is_disputed;
 this.is_disputedChanged = true;
 this.is_sms_task_required = is_sms_task_required;
 this.is_sms_task_requiredChanged = true;
 this.transaction_type_id = transaction_type_id;
 this.transaction_type_idChanged = true;
 }

 #region members and properties for columns

 #region ExceptionHandlingCriteriaId
 private bool exception_handling_criteria_idChanged = false;
 private int exception_handling_criteria_id;
 public int ExceptionHandlingCriteriaId
 {
 get { return exception_handling_criteria_id; }
 set { 
exception_handling_criteria_id = value;
exception_handling_criteria_idChanged = true;
 }
 }
 private string exception_handling_criteria_idDbString
 {
 get
 {
 return exception_handling_criteria_id.ToString();
 }
 }
 #endregion
 #region Message
 private bool messageChanged = false;
 private string message;
 public string Message
 {
 get { return message; }
 set { 
message = value;
messageChanged = true;
 }
 }
 private string messageDbString
 {
 get
 {
 if (this.message!=null)
 return string.Format("'{0}'",message); else
 return "null";
 }
 }
 #endregion
 #region IsPrecondition
 private bool is_preconditionChanged = false;
 private bool? is_precondition;
 public bool? IsPrecondition
 {
 get { return is_precondition; }
 set { 
is_precondition = value;
is_preconditionChanged = true;
 }
 }
 private string is_preconditionDbString
 {
 get
 {
 if (this.is_precondition.HasValue)
 return is_precondition.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #region IsDisputed
 private bool is_disputedChanged = false;
 private bool? is_disputed;
 public bool? IsDisputed
 {
 get { return is_disputed; }
 set { 
is_disputed = value;
is_disputedChanged = true;
 }
 }
 private string is_disputedDbString
 {
 get
 {
 if (this.is_disputed.HasValue)
 return is_disputed.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #region IsSmsTaskRequired
 private bool is_sms_task_requiredChanged = false;
 private bool? is_sms_task_required;
 public bool? IsSmsTaskRequired
 {
 get { return is_sms_task_required; }
 set { 
is_sms_task_required = value;
is_sms_task_requiredChanged = true;
 }
 }
 private string is_sms_task_requiredDbString
 {
 get
 {
 if (this.is_sms_task_required.HasValue)
 return is_sms_task_required.Value?"1":"0";
 else
 return "null";
 }
 }
 #endregion
 #region TransactionTypeId
 private bool transaction_type_idChanged = false;
 private int? transaction_type_id;
 public int? TransactionTypeId
 {
 get { return transaction_type_id; }
 set { 
transaction_type_id = value;
transaction_type_idChanged = true;
 }
 }
 private string transaction_type_idDbString
 {
 get
 {
 if (this.transaction_type_id.HasValue)
 return transaction_type_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region ExceptionHandlingCriteriaReader
 public class ExceptionHandlingCriteriaReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ExceptionHandlingCriteria currentExceptionHandlingCriteria;
 Columns columns;
 bool partialRead = false;
 private ExceptionHandlingCriteriaReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ExceptionHandlingCriteriaReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ExceptionHandlingCriteriaReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentExceptionHandlingCriteria; }

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
 currentExceptionHandlingCriteria = new ExceptionHandlingCriteria();
 if (partialRead)
 { if ((columns & Columns.exception_handling_criteria_id) == Columns.exception_handling_criteria_id && reader["exception_handling_criteria_id"]!=DBNull.Value)
 currentExceptionHandlingCriteria.exception_handling_criteria_id =(int) reader["exception_handling_criteria_id"]; 
 if ((columns & Columns.message) == Columns.message && reader["message"]!=DBNull.Value)
 currentExceptionHandlingCriteria.message =(string) reader["message"]; 
 if ((columns & Columns.is_precondition) == Columns.is_precondition && reader["is_precondition"]!=DBNull.Value)
 currentExceptionHandlingCriteria.is_precondition =(bool?) reader["is_precondition"]; 
 if ((columns & Columns.is_disputed) == Columns.is_disputed && reader["is_disputed"]!=DBNull.Value)
 currentExceptionHandlingCriteria.is_disputed =(bool?) reader["is_disputed"]; 
 if ((columns & Columns.is_sms_task_required) == Columns.is_sms_task_required && reader["is_sms_task_required"]!=DBNull.Value)
 currentExceptionHandlingCriteria.is_sms_task_required =(bool?) reader["is_sms_task_required"]; 
 if ((columns & Columns.transaction_type_id) == Columns.transaction_type_id && reader["transaction_type_id"]!=DBNull.Value)
 currentExceptionHandlingCriteria.transaction_type_id =(int?) reader["transaction_type_id"]; 

 } else
 {
 if (reader["exception_handling_criteria_id"] != DBNull.Value)
 currentExceptionHandlingCriteria.exception_handling_criteria_id = (int) reader["exception_handling_criteria_id"]; 
 if (reader["message"] != DBNull.Value)
 currentExceptionHandlingCriteria.message = (string) reader["message"]; 
 if (reader["is_precondition"] != DBNull.Value)
 currentExceptionHandlingCriteria.is_precondition = (bool?) reader["is_precondition"]; 
 if (reader["is_disputed"] != DBNull.Value)
 currentExceptionHandlingCriteria.is_disputed = (bool?) reader["is_disputed"]; 
 if (reader["is_sms_task_required"] != DBNull.Value)
 currentExceptionHandlingCriteria.is_sms_task_required = (bool?) reader["is_sms_task_required"]; 
 if (reader["transaction_type_id"] != DBNull.Value)
 currentExceptionHandlingCriteria.transaction_type_id = (int?) reader["transaction_type_id"]; 
 } 

 currentExceptionHandlingCriteria.isNewEntity = false;
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

 public ExceptionHandlingCriteria CurrentExceptionHandlingCriteria
 {
 get{ return currentExceptionHandlingCriteria; }
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


 #region ExceptionHandlingCriteria functions

 public static ExceptionHandlingCriteriaReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.exception_handling_criteria_id == (Columns.exception_handling_criteria_id & columns))
 qry.Append("exception_handling_criteria_id,");
 if (Columns.message == (Columns.message & columns))
 qry.Append("message,");
 if (Columns.is_precondition == (Columns.is_precondition & columns))
 qry.Append("is_precondition,");
 if (Columns.is_disputed == (Columns.is_disputed & columns))
 qry.Append("is_disputed,");
 if (Columns.is_sms_task_required == (Columns.is_sms_task_required & columns))
 qry.Append("is_sms_task_required,");
 if (Columns.transaction_type_id == (Columns.transaction_type_id & columns))
 qry.Append("transaction_type_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Exception_handling_criteria ");

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
 return new ExceptionHandlingCriteriaReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ExceptionHandlingCriteriaReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ExceptionHandlingCriteriaReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select exception_handling_criteria_id,message,is_precondition,is_disputed,is_sms_task_required,transaction_type_id from Exception_handling_criteria ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ExceptionHandlingCriteriaReader(cmd.ExecuteReader(), conn);
 }

 static public ExceptionHandlingCriteriaReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static ExceptionHandlingCriteria LoadExceptionHandlingCriteria(string where)
 {
ExceptionHandlingCriteriaReader reader = ExceptionHandlingCriteria.ExecuteReader(where);
ExceptionHandlingCriteria _exceptionhandlingcriteria = null;
 if (reader.Read())
 _exceptionhandlingcriteria = reader.CurrentExceptionHandlingCriteria;
 reader.Close();
 return _exceptionhandlingcriteria;
 }

 public static ExceptionHandlingCriteria LoadExceptionHandlingCriteria(string where, IDbConnection conn)
 {
ExceptionHandlingCriteriaReader reader = ExceptionHandlingCriteria.ExecuteReader(where, conn);
ExceptionHandlingCriteria _exceptionhandlingcriteria = null;
 if (reader.Read())
 _exceptionhandlingcriteria = reader.CurrentExceptionHandlingCriteria;
 reader.Close(false);
 return _exceptionhandlingcriteria;
 }

 public static ExceptionHandlingCriteria LoadExceptionHandlingCriteriaByPk( int exception_handling_criteria_id )
 {
 return LoadExceptionHandlingCriteria( " exception_handling_criteria_id="+exception_handling_criteria_id );
 }

 public static ExceptionHandlingCriteria LoadExceptionHandlingCriteriaByPk( int exception_handling_criteria_id , IDbConnection conn)
 {
 return LoadExceptionHandlingCriteria(" exception_handling_criteria_id="+exception_handling_criteria_id , conn);
 }

 public void Save()
 {
 if (exception_handling_criteria_idChanged || messageChanged || is_preconditionChanged || is_disputedChanged || is_sms_task_requiredChanged || transaction_type_idChanged )
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
 if (exception_handling_criteria_idChanged || messageChanged || is_preconditionChanged || is_disputedChanged || is_sms_task_requiredChanged || transaction_type_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Exception_handling_criteria( exception_handling_criteria_id,message,is_precondition,is_disputed,is_sms_task_required,transaction_type_id ) values(");
 lock (ConnectionFactory.connectionString) { this.exception_handling_criteria_id = ConnectionFactory.GetNextId();
 qry.Append(this.exception_handling_criteria_id);
 } qry.Append(",");
 qry.Append(messageDbString+",");
 qry.Append(is_preconditionDbString+",");
 qry.Append(is_disputedDbString+",");
 qry.Append(is_sms_task_requiredDbString+",");
 qry.Append(transaction_type_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(exception_handling_criteria_idChanged || messageChanged || is_preconditionChanged || is_disputedChanged || is_sms_task_requiredChanged || transaction_type_idChanged ))
 return;
 qry.Append("UPDATE Exception_handling_criteria set "); if ( messageChanged )
 {
 qry.Append("message ="+messageDbString);
 qry.Append(",");
 }

 if ( is_preconditionChanged )
 {
 qry.Append("is_precondition ="+is_preconditionDbString);
 qry.Append(",");
 }

 if ( is_disputedChanged )
 {
 qry.Append("is_disputed ="+is_disputedDbString);
 qry.Append(",");
 }

 if ( is_sms_task_requiredChanged )
 {
 qry.Append("is_sms_task_required ="+is_sms_task_requiredDbString);
 qry.Append(",");
 }

 if ( transaction_type_idChanged )
 {
 qry.Append("transaction_type_id ="+transaction_type_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("exception_handling_criteria_id = "+exception_handling_criteria_idDbString);
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
 cmd.CommandText = "DELETE Exception_handling_criteria where exception_handling_criteria_id = "+ exception_handling_criteria_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteExceptionHandlingCriterias(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Exception_handling_criteria where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
exception_handling_criteria_id= 1,
message= 2,
is_precondition= 4,
is_disputed= 8,
is_sms_task_required= 16,
transaction_type_id= 32
 }
 #endregion
 public void BulkSave(List<ExceptionHandlingCriteria> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Exception_handling_criteria";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ExceptionHandlingCriteria.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ExceptionHandlingCriteria> transList,ref DataTable dt)
 {
 foreach (ExceptionHandlingCriteria tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["exception_handling_criteria_id"] =ConnectionFactory.GetNextId();
 Row["message"] = tran.Message;
 Row["is_precondition"] = tran.IsPrecondition;
 Row["is_disputed"] = tran.IsDisputed;
 Row["is_sms_task_required"] = tran.IsSmsTaskRequired;
 Row["transaction_type_id"] = tran.TransactionTypeId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
