
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
 public class ExplodedReplenishment
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ExplodedReplenishment() { }
 public ExplodedReplenishment( int atm_id,int cash_added1,int cash_added2,int cash_added3,int cash_added4,int cash_added5,int cash_added6,int cash_added7,DateTime rep_datetime,string rep_status,int replenishment_id,int task_id,int cash_order_id,bool is_swap,DateTime processing_datetime )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.cash_added1 = cash_added1;
 this.cash_added1Changed = true;
 this.cash_added2 = cash_added2;
 this.cash_added2Changed = true;
 this.cash_added3 = cash_added3;
 this.cash_added3Changed = true;
 this.cash_added4 = cash_added4;
 this.cash_added4Changed = true;
 this.cash_added5 = cash_added5;
 this.cash_added5Changed = true;
 this.cash_added6 = cash_added6;
 this.cash_added6Changed = true;
 this.cash_added7 = cash_added7;
 this.cash_added7Changed = true;
 this.rep_datetime = rep_datetime;
 this.rep_datetimeChanged = true;
 this.rep_status = rep_status;
 this.rep_statusChanged = true;
 this.replenishment_id = replenishment_id;
 this.replenishment_idChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.cash_order_id = cash_order_id;
 this.cash_order_idChanged = true;
 this.is_swap = is_swap;
 this.is_swapChanged = true;
 this.processing_datetime = processing_datetime;
 this.processing_datetimeChanged = true;
 }
 private ExplodedReplenishment( int exploded_replenishment_id,int atm_id,int cash_added1,int cash_added2,int cash_added3,int cash_added4,int cash_added5,int cash_added6,int cash_added7,DateTime rep_datetime,string rep_status,int replenishment_id,int task_id,int cash_order_id,bool is_swap,DateTime processing_datetime )
 {
 this.exploded_replenishment_id = exploded_replenishment_id;
 this.exploded_replenishment_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.cash_added1 = cash_added1;
 this.cash_added1Changed = true;
 this.cash_added2 = cash_added2;
 this.cash_added2Changed = true;
 this.cash_added3 = cash_added3;
 this.cash_added3Changed = true;
 this.cash_added4 = cash_added4;
 this.cash_added4Changed = true;
 this.cash_added5 = cash_added5;
 this.cash_added5Changed = true;
 this.cash_added6 = cash_added6;
 this.cash_added6Changed = true;
 this.cash_added7 = cash_added7;
 this.cash_added7Changed = true;
 this.rep_datetime = rep_datetime;
 this.rep_datetimeChanged = true;
 this.rep_status = rep_status;
 this.rep_statusChanged = true;
 this.replenishment_id = replenishment_id;
 this.replenishment_idChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.cash_order_id = cash_order_id;
 this.cash_order_idChanged = true;
 this.is_swap = is_swap;
 this.is_swapChanged = true;
 this.processing_datetime = processing_datetime;
 this.processing_datetimeChanged = true;
 }

 #region members and properties for columns

 #region ExplodedReplenishmentId
 private bool exploded_replenishment_idChanged = false;
 private int exploded_replenishment_id;
 public int ExplodedReplenishmentId
 {
 get { return exploded_replenishment_id; }
 set { 
exploded_replenishment_id = value;
exploded_replenishment_idChanged = true;
 }
 }
 private string exploded_replenishment_idDbString
 {
 get
 {
 return exploded_replenishment_id.ToString();
 }
 }
 #endregion
 #region AtmId
 private bool atm_idChanged = false;
 private int atm_id;
 public int AtmId
 {
 get { return atm_id; }
 set { 
atm_id = value;
atm_idChanged = true;
 }
 }
 private string atm_idDbString
 {
 get
 {
 return atm_id.ToString();
 }
 }
 #endregion
 #region CashAdded1
 private bool cash_added1Changed = false;
 private int cash_added1;
 public int CashAdded1
 {
 get { return cash_added1; }
 set { 
cash_added1 = value;
cash_added1Changed = true;
 }
 }
 private string cash_added1DbString
 {
 get
 {
 return cash_added1.ToString();
 }
 }
 #endregion
 #region CashAdded2
 private bool cash_added2Changed = false;
 private int cash_added2;
 public int CashAdded2
 {
 get { return cash_added2; }
 set { 
cash_added2 = value;
cash_added2Changed = true;
 }
 }
 private string cash_added2DbString
 {
 get
 {
 return cash_added2.ToString();
 }
 }
 #endregion
 #region CashAdded3
 private bool cash_added3Changed = false;
 private int cash_added3;
 public int CashAdded3
 {
 get { return cash_added3; }
 set { 
cash_added3 = value;
cash_added3Changed = true;
 }
 }
 private string cash_added3DbString
 {
 get
 {
 return cash_added3.ToString();
 }
 }
 #endregion
 #region CashAdded4
 private bool cash_added4Changed = false;
 private int cash_added4;
 public int CashAdded4
 {
 get { return cash_added4; }
 set { 
cash_added4 = value;
cash_added4Changed = true;
 }
 }
 private string cash_added4DbString
 {
 get
 {
 return cash_added4.ToString();
 }
 }
 #endregion
 #region CashAdded5
 private bool cash_added5Changed = false;
 private int cash_added5;
 public int CashAdded5
 {
 get { return cash_added5; }
 set { 
cash_added5 = value;
cash_added5Changed = true;
 }
 }
 private string cash_added5DbString
 {
 get
 {
 return cash_added5.ToString();
 }
 }
 #endregion
 #region CashAdded6
 private bool cash_added6Changed = false;
 private int cash_added6;
 public int CashAdded6
 {
 get { return cash_added6; }
 set { 
cash_added6 = value;
cash_added6Changed = true;
 }
 }
 private string cash_added6DbString
 {
 get
 {
 return cash_added6.ToString();
 }
 }
 #endregion
 #region CashAdded7
 private bool cash_added7Changed = false;
 private int cash_added7;
 public int CashAdded7
 {
 get { return cash_added7; }
 set { 
cash_added7 = value;
cash_added7Changed = true;
 }
 }
 private string cash_added7DbString
 {
 get
 {
 return cash_added7.ToString();
 }
 }
 #endregion
 #region RepDatetime
 private bool rep_datetimeChanged = false;
 private DateTime rep_datetime;
 public DateTime RepDatetime
 {
 get { return rep_datetime; }
 set { 
rep_datetime = value;
rep_datetimeChanged = true;
 }
 }
 private string rep_datetimeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",rep_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region RepStatus
 private bool rep_statusChanged = false;
 private string rep_status;
 public string RepStatus
 {
 get { return rep_status; }
 set { 
rep_status = value;
rep_statusChanged = true;
 }
 }
 private string rep_statusDbString
 {
 get
 {
 if (this.rep_status!=null)
 return string.Format("'{0}'",rep_status); else
 return "null";
 }
 }
 #endregion
 #region ReplenishmentId
 private bool replenishment_idChanged = false;
 private int replenishment_id;
 public int ReplenishmentId
 {
 get { return replenishment_id; }
 set { 
replenishment_id = value;
replenishment_idChanged = true;
 }
 }
 private string replenishment_idDbString
 {
 get
 {
 return replenishment_id.ToString();
 }
 }
 #endregion
 #region TaskId
 private bool task_idChanged = false;
 private int task_id;
 public int TaskId
 {
 get { return task_id; }
 set { 
task_id = value;
task_idChanged = true;
 }
 }
 private string task_idDbString
 {
 get
 {
 return task_id.ToString();
 }
 }
 #endregion
 #region CashOrderId
 private bool cash_order_idChanged = false;
 private int cash_order_id;
 public int CashOrderId
 {
 get { return cash_order_id; }
 set { 
cash_order_id = value;
cash_order_idChanged = true;
 }
 }
 private string cash_order_idDbString
 {
 get
 {
 return cash_order_id.ToString();
 }
 }
 #endregion
 #region IsSwap
 private bool is_swapChanged = false;
 private bool is_swap;
 public bool IsSwap
 {
 get { return is_swap; }
 set { 
is_swap = value;
is_swapChanged = true;
 }
 }
 private string is_swapDbString
 {
 get
 {
 return is_swap?"1":"0";
 }
 }
 #endregion
 #region ProcessingDatetime
 private bool processing_datetimeChanged = false;
 private DateTime processing_datetime;
 public DateTime ProcessingDatetime
 {
 get { return processing_datetime; }
 set { 
processing_datetime = value;
processing_datetimeChanged = true;
 }
 }
 private string processing_datetimeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",processing_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #endregion

 #region ExplodedReplenishmentReader
 public class ExplodedReplenishmentReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ExplodedReplenishment currentExplodedReplenishment;
 Columns columns;
 bool partialRead = false;
 private ExplodedReplenishmentReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ExplodedReplenishmentReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ExplodedReplenishmentReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentExplodedReplenishment; }

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
 currentExplodedReplenishment = new ExplodedReplenishment();
 if (partialRead)
 { if ((columns & Columns.exploded_replenishment_id) == Columns.exploded_replenishment_id && reader["exploded_replenishment_id"]!=DBNull.Value)
 currentExplodedReplenishment.exploded_replenishment_id =(int) reader["exploded_replenishment_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentExplodedReplenishment.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.cash_added1) == Columns.cash_added1 && reader["cash_added1"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added1 =(int) reader["cash_added1"]; 
 if ((columns & Columns.cash_added2) == Columns.cash_added2 && reader["cash_added2"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added2 =(int) reader["cash_added2"]; 
 if ((columns & Columns.cash_added3) == Columns.cash_added3 && reader["cash_added3"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added3 =(int) reader["cash_added3"]; 
 if ((columns & Columns.cash_added4) == Columns.cash_added4 && reader["cash_added4"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added4 =(int) reader["cash_added4"]; 
 if ((columns & Columns.cash_added5) == Columns.cash_added5 && reader["cash_added5"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added5 =(int) reader["cash_added5"]; 
 if ((columns & Columns.cash_added6) == Columns.cash_added6 && reader["cash_added6"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added6 =(int) reader["cash_added6"]; 
 if ((columns & Columns.cash_added7) == Columns.cash_added7 && reader["cash_added7"]!=DBNull.Value)
 currentExplodedReplenishment.cash_added7 =(int) reader["cash_added7"]; 
 if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"]!=DBNull.Value)
 currentExplodedReplenishment.rep_datetime =(DateTime) reader["rep_datetime"]; 
 if ((columns & Columns.rep_status) == Columns.rep_status && reader["rep_status"]!=DBNull.Value)
 currentExplodedReplenishment.rep_status =(string) reader["rep_status"]; 
 if ((columns & Columns.replenishment_id) == Columns.replenishment_id && reader["replenishment_id"]!=DBNull.Value)
 currentExplodedReplenishment.replenishment_id =(int) reader["replenishment_id"]; 
 if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
 currentExplodedReplenishment.task_id =(int) reader["task_id"]; 
 if ((columns & Columns.cash_order_id) == Columns.cash_order_id && reader["cash_order_id"]!=DBNull.Value)
 currentExplodedReplenishment.cash_order_id =(int) reader["cash_order_id"]; 
 if ((columns & Columns.is_swap) == Columns.is_swap && reader["is_swap"]!=DBNull.Value)
 currentExplodedReplenishment.is_swap =(bool) reader["is_swap"]; 
 if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
 currentExplodedReplenishment.processing_datetime =(DateTime) reader["processing_datetime"]; 

 } else
 {
 if (reader["exploded_replenishment_id"] != DBNull.Value)
 currentExplodedReplenishment.exploded_replenishment_id = (int) reader["exploded_replenishment_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentExplodedReplenishment.atm_id = (int) reader["atm_id"]; 
 if (reader["cash_added1"] != DBNull.Value)
 currentExplodedReplenishment.cash_added1 = (int) reader["cash_added1"]; 
 if (reader["cash_added2"] != DBNull.Value)
 currentExplodedReplenishment.cash_added2 = (int) reader["cash_added2"]; 
 if (reader["cash_added3"] != DBNull.Value)
 currentExplodedReplenishment.cash_added3 = (int) reader["cash_added3"]; 
 if (reader["cash_added4"] != DBNull.Value)
 currentExplodedReplenishment.cash_added4 = (int) reader["cash_added4"]; 
 if (reader["cash_added5"] != DBNull.Value)
 currentExplodedReplenishment.cash_added5 = (int) reader["cash_added5"]; 
 if (reader["cash_added6"] != DBNull.Value)
 currentExplodedReplenishment.cash_added6 = (int) reader["cash_added6"]; 
 if (reader["cash_added7"] != DBNull.Value)
 currentExplodedReplenishment.cash_added7 = (int) reader["cash_added7"]; 
 if (reader["rep_datetime"] != DBNull.Value)
 currentExplodedReplenishment.rep_datetime = (DateTime) reader["rep_datetime"]; 
 if (reader["rep_status"] != DBNull.Value)
 currentExplodedReplenishment.rep_status = (string) reader["rep_status"]; 
 if (reader["replenishment_id"] != DBNull.Value)
 currentExplodedReplenishment.replenishment_id = (int) reader["replenishment_id"]; 
 if (reader["task_id"] != DBNull.Value)
 currentExplodedReplenishment.task_id = (int) reader["task_id"]; 
 if (reader["cash_order_id"] != DBNull.Value)
 currentExplodedReplenishment.cash_order_id = (int) reader["cash_order_id"]; 
 if (reader["is_swap"] != DBNull.Value)
 currentExplodedReplenishment.is_swap = (bool) reader["is_swap"]; 
 if (reader["processing_datetime"] != DBNull.Value)
 currentExplodedReplenishment.processing_datetime = (DateTime) reader["processing_datetime"]; 
 } 

 currentExplodedReplenishment.isNewEntity = false;
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

 public ExplodedReplenishment CurrentExplodedReplenishment
 {
 get{ return currentExplodedReplenishment; }
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


 #region ExplodedReplenishment functions

 public static ExplodedReplenishmentReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.exploded_replenishment_id == (Columns.exploded_replenishment_id & columns))
 qry.Append("exploded_replenishment_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.cash_added1 == (Columns.cash_added1 & columns))
 qry.Append("cash_added1,");
 if (Columns.cash_added2 == (Columns.cash_added2 & columns))
 qry.Append("cash_added2,");
 if (Columns.cash_added3 == (Columns.cash_added3 & columns))
 qry.Append("cash_added3,");
 if (Columns.cash_added4 == (Columns.cash_added4 & columns))
 qry.Append("cash_added4,");
 if (Columns.cash_added5 == (Columns.cash_added5 & columns))
 qry.Append("cash_added5,");
 if (Columns.cash_added6 == (Columns.cash_added6 & columns))
 qry.Append("cash_added6,");
 if (Columns.cash_added7 == (Columns.cash_added7 & columns))
 qry.Append("cash_added7,");
 if (Columns.rep_datetime == (Columns.rep_datetime & columns))
 qry.Append("rep_datetime,");
 if (Columns.rep_status == (Columns.rep_status & columns))
 qry.Append("rep_status,");
 if (Columns.replenishment_id == (Columns.replenishment_id & columns))
 qry.Append("replenishment_id,");
 if (Columns.task_id == (Columns.task_id & columns))
 qry.Append("task_id,");
 if (Columns.cash_order_id == (Columns.cash_order_id & columns))
 qry.Append("cash_order_id,");
 if (Columns.is_swap == (Columns.is_swap & columns))
 qry.Append("is_swap,");
 if (Columns.processing_datetime == (Columns.processing_datetime & columns))
 qry.Append("processing_datetime,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Exploded_replenishment ");

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
 return new ExplodedReplenishmentReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ExplodedReplenishmentReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ExplodedReplenishmentReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select exploded_replenishment_id,atm_id,cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,rep_datetime,rep_status,replenishment_id,task_id,cash_order_id,is_swap,processing_datetime from Exploded_replenishment ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ExplodedReplenishmentReader(cmd.ExecuteReader(), conn);
 }

 static public ExplodedReplenishmentReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static ExplodedReplenishment LoadExplodedReplenishment(string where)
 {
ExplodedReplenishmentReader reader = ExplodedReplenishment.ExecuteReader(where);
ExplodedReplenishment _explodedreplenishment = null;
 if (reader.Read())
 _explodedreplenishment = reader.CurrentExplodedReplenishment;
 reader.Close();
 return _explodedreplenishment;
 }

 public static ExplodedReplenishment LoadExplodedReplenishment(string where, IDbConnection conn)
 {
ExplodedReplenishmentReader reader = ExplodedReplenishment.ExecuteReader(where, conn);
ExplodedReplenishment _explodedreplenishment = null;
 if (reader.Read())
 _explodedreplenishment = reader.CurrentExplodedReplenishment;
 reader.Close(false);
 return _explodedreplenishment;
 }

 public static ExplodedReplenishment LoadExplodedReplenishmentByPk( int exploded_replenishment_id )
 {
 return LoadExplodedReplenishment( " exploded_replenishment_id="+exploded_replenishment_id );
 }

 public static ExplodedReplenishment LoadExplodedReplenishmentByPk( int exploded_replenishment_id , IDbConnection conn)
 {
 return LoadExplodedReplenishment(" exploded_replenishment_id="+exploded_replenishment_id , conn);
 }

 public void Save()
 {
 if (exploded_replenishment_idChanged || atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || rep_datetimeChanged || rep_statusChanged || replenishment_idChanged || task_idChanged || cash_order_idChanged || is_swapChanged || processing_datetimeChanged )
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
 if (exploded_replenishment_idChanged || atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || rep_datetimeChanged || rep_statusChanged || replenishment_idChanged || task_idChanged || cash_order_idChanged || is_swapChanged || processing_datetimeChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Exploded_replenishment( exploded_replenishment_id,atm_id,cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,rep_datetime,rep_status,replenishment_id,task_id,cash_order_id,is_swap,processing_datetime ) values(");
 lock (ConnectionFactory.connectionString) { this.exploded_replenishment_id = ConnectionFactory.GetNextId();
 qry.Append(this.exploded_replenishment_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(cash_added1DbString+",");
 qry.Append(cash_added2DbString+",");
 qry.Append(cash_added3DbString+",");
 qry.Append(cash_added4DbString+",");
 qry.Append(cash_added5DbString+",");
 qry.Append(cash_added6DbString+",");
 qry.Append(cash_added7DbString+",");
 qry.Append(rep_datetimeDbString+",");
 qry.Append(rep_statusDbString+",");
 qry.Append(replenishment_idDbString+",");
 qry.Append(task_idDbString+",");
 qry.Append(cash_order_idDbString+",");
 qry.Append(is_swapDbString+",");
 qry.Append(processing_datetimeDbString);
 qry.Append(");");

 }
 else
 {
 if (!(exploded_replenishment_idChanged || atm_idChanged || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || rep_datetimeChanged || rep_statusChanged || replenishment_idChanged || task_idChanged || cash_order_idChanged || is_swapChanged || processing_datetimeChanged ))
 return;
 qry.Append("UPDATE Exploded_replenishment set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( cash_added1Changed )
 {
 qry.Append("cash_added1 ="+cash_added1DbString);
 qry.Append(",");
 }

 if ( cash_added2Changed )
 {
 qry.Append("cash_added2 ="+cash_added2DbString);
 qry.Append(",");
 }

 if ( cash_added3Changed )
 {
 qry.Append("cash_added3 ="+cash_added3DbString);
 qry.Append(",");
 }

 if ( cash_added4Changed )
 {
 qry.Append("cash_added4 ="+cash_added4DbString);
 qry.Append(",");
 }

 if ( cash_added5Changed )
 {
 qry.Append("cash_added5 ="+cash_added5DbString);
 qry.Append(",");
 }

 if ( cash_added6Changed )
 {
 qry.Append("cash_added6 ="+cash_added6DbString);
 qry.Append(",");
 }

 if ( cash_added7Changed )
 {
 qry.Append("cash_added7 ="+cash_added7DbString);
 qry.Append(",");
 }

 if ( rep_datetimeChanged )
 {
 qry.Append("rep_datetime ="+rep_datetimeDbString);
 qry.Append(",");
 }

 if ( rep_statusChanged )
 {
 qry.Append("rep_status ="+rep_statusDbString);
 qry.Append(",");
 }

 if ( replenishment_idChanged )
 {
 qry.Append("replenishment_id ="+replenishment_idDbString);
 qry.Append(",");
 }

 if ( task_idChanged )
 {
 qry.Append("task_id ="+task_idDbString);
 qry.Append(",");
 }

 if ( cash_order_idChanged )
 {
 qry.Append("cash_order_id ="+cash_order_idDbString);
 qry.Append(",");
 }

 if ( is_swapChanged )
 {
 qry.Append("is_swap ="+is_swapDbString);
 qry.Append(",");
 }

 if ( processing_datetimeChanged )
 {
 qry.Append("processing_datetime ="+processing_datetimeDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("exploded_replenishment_id = "+exploded_replenishment_idDbString);
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
 cmd.CommandText = "DELETE Exploded_replenishment where exploded_replenishment_id = "+ exploded_replenishment_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteExplodedReplenishments(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Exploded_replenishment where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
exploded_replenishment_id= 1,
atm_id= 2,
cash_added1= 4,
cash_added2= 8,
cash_added3= 16,
cash_added4= 32,
cash_added5= 64,
cash_added6= 128,
cash_added7= 256,
rep_datetime= 512,
rep_status= 1024,
replenishment_id= 2048,
task_id= 4096,
cash_order_id= 8192,
is_swap= 16384,
processing_datetime= 32768
 }
 #endregion
 public void BulkSave(List<ExplodedReplenishment> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Exploded_replenishment";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ExplodedReplenishment.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ExplodedReplenishment> transList,ref DataTable dt)
 {
 foreach (ExplodedReplenishment tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["exploded_replenishment_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["cash_added1"] = tran.CashAdded1;
 Row["cash_added2"] = tran.CashAdded2;
 Row["cash_added3"] = tran.CashAdded3;
 Row["cash_added4"] = tran.CashAdded4;
 Row["cash_added5"] = tran.CashAdded5;
 Row["cash_added6"] = tran.CashAdded6;
 Row["cash_added7"] = tran.CashAdded7;
 Row["rep_datetime"] = tran.RepDatetime;
 Row["rep_status"] = tran.RepStatus;
 Row["replenishment_id"] = tran.ReplenishmentId;
 Row["task_id"] = tran.TaskId;
 Row["cash_order_id"] = tran.CashOrderId;
 Row["is_swap"] = tran.IsSwap;
 Row["processing_datetime"] = tran.ProcessingDatetime;
 dt.Rows.Add(Row);
 } }
 }
 }

 
