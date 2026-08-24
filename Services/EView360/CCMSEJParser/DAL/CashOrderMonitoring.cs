
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
 public class CashOrderMonitoring
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public CashOrderMonitoring() { }
 public CashOrderMonitoring( int cash_order_monitoring_id,int atm_id,int current_order_id,DateTime current_order_received_at,decimal current_order_remaining_amount,DateTime cash_order_datetime,decimal current_order_suggested_amount ) 
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.current_order_id = current_order_id;
 this.current_order_idChanged = true;
 this.current_order_received_at = current_order_received_at;
 this.current_order_received_atChanged = true;
 this.current_order_remaining_amount = current_order_remaining_amount;
 this.current_order_remaining_amountChanged = true;
 this.cash_order_datetime = cash_order_datetime;
 this.cash_order_datetimeChanged = true;
 this.current_order_suggested_amount = current_order_suggested_amount;
 this.current_order_suggested_amountChanged = true;
 }
 public CashOrderMonitoring( int atm_id,int current_order_id,DateTime current_order_received_at,DateTime? current_order_delivered_at,DateTime? current_order_executed_at,decimal current_order_remaining_amount,DateTime cash_order_datetime,decimal current_order_suggested_amount,DateTime? replenishment_datetime )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.current_order_id = current_order_id;
 this.current_order_idChanged = true;
 this.current_order_received_at = current_order_received_at;
 this.current_order_received_atChanged = true;
 this.current_order_delivered_at = current_order_delivered_at;
 this.current_order_delivered_atChanged = true;
 this.current_order_executed_at = current_order_executed_at;
 this.current_order_executed_atChanged = true;
 this.current_order_remaining_amount = current_order_remaining_amount;
 this.current_order_remaining_amountChanged = true;
 this.cash_order_datetime = cash_order_datetime;
 this.cash_order_datetimeChanged = true;
 this.current_order_suggested_amount = current_order_suggested_amount;
 this.current_order_suggested_amountChanged = true;
 this.replenishment_datetime = replenishment_datetime;
 this.replenishment_datetimeChanged = true;
 }
 private CashOrderMonitoring( int cash_order_monitoring_id,int atm_id,int current_order_id,DateTime current_order_received_at,DateTime? current_order_delivered_at,DateTime? current_order_executed_at,decimal current_order_remaining_amount,DateTime cash_order_datetime,decimal current_order_suggested_amount,DateTime? replenishment_datetime )
 {
 this.cash_order_monitoring_id = cash_order_monitoring_id;
 this.cash_order_monitoring_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.current_order_id = current_order_id;
 this.current_order_idChanged = true;
 this.current_order_received_at = current_order_received_at;
 this.current_order_received_atChanged = true;
 this.current_order_delivered_at = current_order_delivered_at;
 this.current_order_delivered_atChanged = true;
 this.current_order_executed_at = current_order_executed_at;
 this.current_order_executed_atChanged = true;
 this.current_order_remaining_amount = current_order_remaining_amount;
 this.current_order_remaining_amountChanged = true;
 this.cash_order_datetime = cash_order_datetime;
 this.cash_order_datetimeChanged = true;
 this.current_order_suggested_amount = current_order_suggested_amount;
 this.current_order_suggested_amountChanged = true;
 this.replenishment_datetime = replenishment_datetime;
 this.replenishment_datetimeChanged = true;
 }

 #region members and properties for columns

 #region CashOrderMonitoringId
 private bool cash_order_monitoring_idChanged = false;
 private int cash_order_monitoring_id;
 public int CashOrderMonitoringId
 {
 get { return cash_order_monitoring_id; }
 set { 
cash_order_monitoring_id = value;
cash_order_monitoring_idChanged = true;
 }
 }
 private string cash_order_monitoring_idDbString
 {
 get
 {
 return cash_order_monitoring_id.ToString();
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
 #region CurrentOrderId
 private bool current_order_idChanged = false;
 private int current_order_id;
 public int CurrentOrderId
 {
 get { return current_order_id; }
 set { 
current_order_id = value;
current_order_idChanged = true;
 }
 }
 private string current_order_idDbString
 {
 get
 {
 return current_order_id.ToString();
 }
 }
 #endregion
 #region CurrentOrderReceivedAt
 private bool current_order_received_atChanged = false;
 private DateTime current_order_received_at;
 public DateTime CurrentOrderReceivedAt
 {
 get { return current_order_received_at; }
 set { 
current_order_received_at = value;
current_order_received_atChanged = true;
 }
 }
 private string current_order_received_atDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",current_order_received_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region CurrentOrderDeliveredAt
 private bool current_order_delivered_atChanged = false;
 private DateTime? current_order_delivered_at;
 public DateTime? CurrentOrderDeliveredAt
 {
 get { return current_order_delivered_at; }
 set { 
current_order_delivered_at = value;
current_order_delivered_atChanged = true;
 }
 }
 private string current_order_delivered_atDbString
 {
 get
 {
 if (this.current_order_delivered_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",current_order_delivered_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region CurrentOrderExecutedAt
 private bool current_order_executed_atChanged = false;
 private DateTime? current_order_executed_at;
 public DateTime? CurrentOrderExecutedAt
 {
 get { return current_order_executed_at; }
 set { 
current_order_executed_at = value;
current_order_executed_atChanged = true;
 }
 }
 private string current_order_executed_atDbString
 {
 get
 {
 if (this.current_order_executed_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",current_order_executed_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region CurrentOrderRemainingAmount
 private bool current_order_remaining_amountChanged = false;
 private decimal current_order_remaining_amount;
 public decimal CurrentOrderRemainingAmount
 {
 get { return current_order_remaining_amount; }
 set { 
current_order_remaining_amount = value;
current_order_remaining_amountChanged = true;
 }
 }
 private string current_order_remaining_amountDbString
 {
 get
 {
 return current_order_remaining_amount.ToString();
 }
 }
 #endregion
 #region CashOrderDatetime
 private bool cash_order_datetimeChanged = false;
 private DateTime cash_order_datetime;
 public DateTime CashOrderDatetime
 {
 get { return cash_order_datetime; }
 set { 
cash_order_datetime = value;
cash_order_datetimeChanged = true;
 }
 }
 private string cash_order_datetimeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",cash_order_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region CurrentOrderSuggestedAmount
 private bool current_order_suggested_amountChanged = false;
 private decimal current_order_suggested_amount;
 public decimal CurrentOrderSuggestedAmount
 {
 get { return current_order_suggested_amount; }
 set { 
current_order_suggested_amount = value;
current_order_suggested_amountChanged = true;
 }
 }
 private string current_order_suggested_amountDbString
 {
 get
 {
 return current_order_suggested_amount.ToString();
 }
 }
 #endregion
 #region ReplenishmentDatetime
 private bool replenishment_datetimeChanged = false;
 private DateTime? replenishment_datetime;
 public DateTime? ReplenishmentDatetime
 {
 get { return replenishment_datetime; }
 set { 
replenishment_datetime = value;
replenishment_datetimeChanged = true;
 }
 }
 private string replenishment_datetimeDbString
 {
 get
 {
 if (this.replenishment_datetime.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",replenishment_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region CashOrderMonitoringReader
 public class CashOrderMonitoringReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
CashOrderMonitoring currentCashOrderMonitoring;
 Columns columns;
 bool partialRead = false;
 private CashOrderMonitoringReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public CashOrderMonitoringReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public CashOrderMonitoringReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentCashOrderMonitoring; }

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
 currentCashOrderMonitoring = new CashOrderMonitoring();
 if (partialRead)
 { if ((columns & Columns.cash_order_monitoring_id) == Columns.cash_order_monitoring_id && reader["cash_order_monitoring_id"]!=DBNull.Value)
 currentCashOrderMonitoring.cash_order_monitoring_id =(int) reader["cash_order_monitoring_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentCashOrderMonitoring.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.current_order_id) == Columns.current_order_id && reader["current_order_id"]!=DBNull.Value)
 currentCashOrderMonitoring.current_order_id =(int) reader["current_order_id"]; 
 if ((columns & Columns.current_order_received_at) == Columns.current_order_received_at && reader["current_order_received_at"]!=DBNull.Value)
 currentCashOrderMonitoring.current_order_received_at =(DateTime) reader["current_order_received_at"]; 
 if ((columns & Columns.current_order_delivered_at) == Columns.current_order_delivered_at && reader["current_order_delivered_at"]!=DBNull.Value)
 currentCashOrderMonitoring.current_order_delivered_at =(DateTime?) reader["current_order_delivered_at"]; 
 if ((columns & Columns.current_order_executed_at) == Columns.current_order_executed_at && reader["current_order_executed_at"]!=DBNull.Value)
 currentCashOrderMonitoring.current_order_executed_at =(DateTime?) reader["current_order_executed_at"]; 
 if ((columns & Columns.current_order_remaining_amount) == Columns.current_order_remaining_amount && reader["current_order_remaining_amount"]!=DBNull.Value)
 currentCashOrderMonitoring.current_order_remaining_amount =(decimal) reader["current_order_remaining_amount"]; 
 if ((columns & Columns.cash_order_datetime) == Columns.cash_order_datetime && reader["cash_order_datetime"]!=DBNull.Value)
 currentCashOrderMonitoring.cash_order_datetime =(DateTime) reader["cash_order_datetime"]; 
 if ((columns & Columns.current_order_suggested_amount) == Columns.current_order_suggested_amount && reader["current_order_suggested_amount"]!=DBNull.Value)
 currentCashOrderMonitoring.current_order_suggested_amount =(decimal) reader["current_order_suggested_amount"]; 
 if ((columns & Columns.replenishment_datetime) == Columns.replenishment_datetime && reader["replenishment_datetime"]!=DBNull.Value)
 currentCashOrderMonitoring.replenishment_datetime =(DateTime?) reader["replenishment_datetime"]; 

 } else
 {
 if (reader["cash_order_monitoring_id"] != DBNull.Value)
 currentCashOrderMonitoring.cash_order_monitoring_id = (int) reader["cash_order_monitoring_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentCashOrderMonitoring.atm_id = (int) reader["atm_id"]; 
 if (reader["current_order_id"] != DBNull.Value)
 currentCashOrderMonitoring.current_order_id = (int) reader["current_order_id"]; 
 if (reader["current_order_received_at"] != DBNull.Value)
 currentCashOrderMonitoring.current_order_received_at = (DateTime) reader["current_order_received_at"]; 
 if (reader["current_order_delivered_at"] != DBNull.Value)
 currentCashOrderMonitoring.current_order_delivered_at = (DateTime?) reader["current_order_delivered_at"]; 
 if (reader["current_order_executed_at"] != DBNull.Value)
 currentCashOrderMonitoring.current_order_executed_at = (DateTime?) reader["current_order_executed_at"]; 
 if (reader["current_order_remaining_amount"] != DBNull.Value)
 currentCashOrderMonitoring.current_order_remaining_amount = (decimal) reader["current_order_remaining_amount"]; 
 if (reader["cash_order_datetime"] != DBNull.Value)
 currentCashOrderMonitoring.cash_order_datetime = (DateTime) reader["cash_order_datetime"]; 
 if (reader["current_order_suggested_amount"] != DBNull.Value)
 currentCashOrderMonitoring.current_order_suggested_amount = (decimal) reader["current_order_suggested_amount"]; 
 if (reader["replenishment_datetime"] != DBNull.Value)
 currentCashOrderMonitoring.replenishment_datetime = (DateTime?) reader["replenishment_datetime"]; 
 } 

 currentCashOrderMonitoring.isNewEntity = false;
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

 public CashOrderMonitoring CurrentCashOrderMonitoring
 {
 get{ return currentCashOrderMonitoring; }
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


 #region CashOrderMonitoring functions

 public static CashOrderMonitoringReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.cash_order_monitoring_id == (Columns.cash_order_monitoring_id & columns))
 qry.Append("cash_order_monitoring_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.current_order_id == (Columns.current_order_id & columns))
 qry.Append("current_order_id,");
 if (Columns.current_order_received_at == (Columns.current_order_received_at & columns))
 qry.Append("current_order_received_at,");
 if (Columns.current_order_delivered_at == (Columns.current_order_delivered_at & columns))
 qry.Append("current_order_delivered_at,");
 if (Columns.current_order_executed_at == (Columns.current_order_executed_at & columns))
 qry.Append("current_order_executed_at,");
 if (Columns.current_order_remaining_amount == (Columns.current_order_remaining_amount & columns))
 qry.Append("current_order_remaining_amount,");
 if (Columns.cash_order_datetime == (Columns.cash_order_datetime & columns))
 qry.Append("cash_order_datetime,");
 if (Columns.current_order_suggested_amount == (Columns.current_order_suggested_amount & columns))
 qry.Append("current_order_suggested_amount,");
 if (Columns.replenishment_datetime == (Columns.replenishment_datetime & columns))
 qry.Append("replenishment_datetime,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Cash_order_monitoring ");

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
 return new CashOrderMonitoringReader(cmd.ExecuteReader(), conn, columns);
 }

 static public CashOrderMonitoringReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static CashOrderMonitoringReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select cash_order_monitoring_id,atm_id,current_order_id,current_order_received_at,current_order_delivered_at,current_order_executed_at,current_order_remaining_amount,cash_order_datetime,current_order_suggested_amount,replenishment_datetime from Cash_order_monitoring ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new CashOrderMonitoringReader(cmd.ExecuteReader(), conn);
 }

 static public CashOrderMonitoringReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static CashOrderMonitoring LoadCashOrderMonitoring(string where)
 {
CashOrderMonitoringReader reader = CashOrderMonitoring.ExecuteReader(where);
CashOrderMonitoring _cashordermonitoring = null;
 if (reader.Read())
 _cashordermonitoring = reader.CurrentCashOrderMonitoring;
 reader.Close();
 return _cashordermonitoring;
 }

 public static CashOrderMonitoring LoadCashOrderMonitoring(string where, IDbConnection conn)
 {
CashOrderMonitoringReader reader = CashOrderMonitoring.ExecuteReader(where, conn);
CashOrderMonitoring _cashordermonitoring = null;
 if (reader.Read())
 _cashordermonitoring = reader.CurrentCashOrderMonitoring;
 reader.Close(false);
 return _cashordermonitoring;
 }

 public static CashOrderMonitoring LoadCashOrderMonitoringByPk( int cash_order_monitoring_id )
 {
 return LoadCashOrderMonitoring( " cash_order_monitoring_id="+cash_order_monitoring_id );
 }

 public static CashOrderMonitoring LoadCashOrderMonitoringByPk( int cash_order_monitoring_id , IDbConnection conn)
 {
 return LoadCashOrderMonitoring(" cash_order_monitoring_id="+cash_order_monitoring_id , conn);
 }

 public void Save()
 {
 if (cash_order_monitoring_idChanged || atm_idChanged || current_order_idChanged || current_order_received_atChanged || current_order_delivered_atChanged || current_order_executed_atChanged || current_order_remaining_amountChanged || cash_order_datetimeChanged || current_order_suggested_amountChanged || replenishment_datetimeChanged )
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
 if (cash_order_monitoring_idChanged || atm_idChanged || current_order_idChanged || current_order_received_atChanged || current_order_delivered_atChanged || current_order_executed_atChanged || current_order_remaining_amountChanged || cash_order_datetimeChanged || current_order_suggested_amountChanged || replenishment_datetimeChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Cash_order_monitoring( cash_order_monitoring_id,atm_id,current_order_id,current_order_received_at,current_order_delivered_at,current_order_executed_at,current_order_remaining_amount,cash_order_datetime,current_order_suggested_amount,replenishment_datetime ) values(");
 lock (ConnectionFactory.connectionString) { this.cash_order_monitoring_id = ConnectionFactory.GetNextId();
 qry.Append(this.cash_order_monitoring_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(current_order_idDbString+",");
 qry.Append(current_order_received_atDbString+",");
 qry.Append(current_order_delivered_atDbString+",");
 qry.Append(current_order_executed_atDbString+",");
 qry.Append(current_order_remaining_amountDbString+",");
 qry.Append(cash_order_datetimeDbString+",");
 qry.Append(current_order_suggested_amountDbString+",");
 qry.Append(replenishment_datetimeDbString);
 qry.Append(");");

 }
 else
 {
 if (!(cash_order_monitoring_idChanged || atm_idChanged || current_order_idChanged || current_order_received_atChanged || current_order_delivered_atChanged || current_order_executed_atChanged || current_order_remaining_amountChanged || cash_order_datetimeChanged || current_order_suggested_amountChanged || replenishment_datetimeChanged ))
 return;
 qry.Append("UPDATE Cash_order_monitoring set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( current_order_idChanged )
 {
 qry.Append("current_order_id ="+current_order_idDbString);
 qry.Append(",");
 }

 if ( current_order_received_atChanged )
 {
 qry.Append("current_order_received_at ="+current_order_received_atDbString);
 qry.Append(",");
 }

 if ( current_order_delivered_atChanged )
 {
 qry.Append("current_order_delivered_at ="+current_order_delivered_atDbString);
 qry.Append(",");
 }

 if ( current_order_executed_atChanged )
 {
 qry.Append("current_order_executed_at ="+current_order_executed_atDbString);
 qry.Append(",");
 }

 if ( current_order_remaining_amountChanged )
 {
 qry.Append("current_order_remaining_amount ="+current_order_remaining_amountDbString);
 qry.Append(",");
 }

 if ( cash_order_datetimeChanged )
 {
 qry.Append("cash_order_datetime ="+cash_order_datetimeDbString);
 qry.Append(",");
 }

 if ( current_order_suggested_amountChanged )
 {
 qry.Append("current_order_suggested_amount ="+current_order_suggested_amountDbString);
 qry.Append(",");
 }

 if ( replenishment_datetimeChanged )
 {
 qry.Append("replenishment_datetime ="+replenishment_datetimeDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("cash_order_monitoring_id = "+cash_order_monitoring_idDbString);
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
 cmd.CommandText = "DELETE Cash_order_monitoring where cash_order_monitoring_id = "+ cash_order_monitoring_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteCashOrderMonitorings(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Cash_order_monitoring where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
cash_order_monitoring_id= 1,
atm_id= 2,
current_order_id= 4,
current_order_received_at= 8,
current_order_delivered_at= 16,
current_order_executed_at= 32,
current_order_remaining_amount= 64,
cash_order_datetime= 128,
current_order_suggested_amount= 256,
replenishment_datetime= 512
 }
 #endregion
 public void BulkSave(List<CashOrderMonitoring> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Cash_order_monitoring";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(CashOrderMonitoring.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <CashOrderMonitoring> transList,ref DataTable dt)
 {
 foreach (CashOrderMonitoring tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["cash_order_monitoring_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["current_order_id"] = tran.CurrentOrderId;
 Row["current_order_received_at"] = tran.CurrentOrderReceivedAt;
 Row["current_order_delivered_at"] = tran.CurrentOrderDeliveredAt;
 Row["current_order_executed_at"] = tran.CurrentOrderExecutedAt;
 Row["current_order_remaining_amount"] = tran.CurrentOrderRemainingAmount;
 Row["cash_order_datetime"] = tran.CashOrderDatetime;
 Row["current_order_suggested_amount"] = tran.CurrentOrderSuggestedAmount;
 Row["replenishment_datetime"] = tran.ReplenishmentDatetime;
 dt.Rows.Add(Row);
 } }
 }
 }

 
