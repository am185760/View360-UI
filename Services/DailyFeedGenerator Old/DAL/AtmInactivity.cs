
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
 public class AtmInactivity
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public AtmInactivity() { }
 public AtmInactivity( int atm_inactivity_id,int atm_id ) 
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }
 public AtmInactivity( int atm_id,DateTime? last_transaction_at,DateTime? last_cdm_transaction_at,DateTime? last_ccdm_transaction_at,int? inactivity_counter,int? inactivity_counter_for_cdm,int? inactivity_counter_for_ccdm,int? inactivity_counter_normal_day,int? inactivity_counter_for_cdm_normal_day,int? inactivity_counter_for_ccdm_normal_day,int? inactivity_counter_salary_day,int? inactivity_counter_for_cdm_salary_day,int? inactivity_counter_for_ccdm_salary_day )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.last_transaction_at = last_transaction_at;
 this.last_transaction_atChanged = true;
 this.last_cdm_transaction_at = last_cdm_transaction_at;
 this.last_cdm_transaction_atChanged = true;
 this.last_ccdm_transaction_at = last_ccdm_transaction_at;
 this.last_ccdm_transaction_atChanged = true;
 this.inactivity_counter = inactivity_counter;
 this.inactivity_counterChanged = true;
 this.inactivity_counter_for_cdm = inactivity_counter_for_cdm;
 this.inactivity_counter_for_cdmChanged = true;
 this.inactivity_counter_for_ccdm = inactivity_counter_for_ccdm;
 this.inactivity_counter_for_ccdmChanged = true;
 this.inactivity_counter_normal_day = inactivity_counter_normal_day;
 this.inactivity_counter_normal_dayChanged = true;
 this.inactivity_counter_for_cdm_normal_day = inactivity_counter_for_cdm_normal_day;
 this.inactivity_counter_for_cdm_normal_dayChanged = true;
 this.inactivity_counter_for_ccdm_normal_day = inactivity_counter_for_ccdm_normal_day;
 this.inactivity_counter_for_ccdm_normal_dayChanged = true;
 this.inactivity_counter_salary_day = inactivity_counter_salary_day;
 this.inactivity_counter_salary_dayChanged = true;
 this.inactivity_counter_for_cdm_salary_day = inactivity_counter_for_cdm_salary_day;
 this.inactivity_counter_for_cdm_salary_dayChanged = true;
 this.inactivity_counter_for_ccdm_salary_day = inactivity_counter_for_ccdm_salary_day;
 this.inactivity_counter_for_ccdm_salary_dayChanged = true;
 }
 private AtmInactivity( int atm_inactivity_id,int atm_id,DateTime? last_transaction_at,DateTime? last_cdm_transaction_at,DateTime? last_ccdm_transaction_at,int? inactivity_counter,int? inactivity_counter_for_cdm,int? inactivity_counter_for_ccdm,int? inactivity_counter_normal_day,int? inactivity_counter_for_cdm_normal_day,int? inactivity_counter_for_ccdm_normal_day,int? inactivity_counter_salary_day,int? inactivity_counter_for_cdm_salary_day,int? inactivity_counter_for_ccdm_salary_day )
 {
 this.atm_inactivity_id = atm_inactivity_id;
 this.atm_inactivity_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.last_transaction_at = last_transaction_at;
 this.last_transaction_atChanged = true;
 this.last_cdm_transaction_at = last_cdm_transaction_at;
 this.last_cdm_transaction_atChanged = true;
 this.last_ccdm_transaction_at = last_ccdm_transaction_at;
 this.last_ccdm_transaction_atChanged = true;
 this.inactivity_counter = inactivity_counter;
 this.inactivity_counterChanged = true;
 this.inactivity_counter_for_cdm = inactivity_counter_for_cdm;
 this.inactivity_counter_for_cdmChanged = true;
 this.inactivity_counter_for_ccdm = inactivity_counter_for_ccdm;
 this.inactivity_counter_for_ccdmChanged = true;
 this.inactivity_counter_normal_day = inactivity_counter_normal_day;
 this.inactivity_counter_normal_dayChanged = true;
 this.inactivity_counter_for_cdm_normal_day = inactivity_counter_for_cdm_normal_day;
 this.inactivity_counter_for_cdm_normal_dayChanged = true;
 this.inactivity_counter_for_ccdm_normal_day = inactivity_counter_for_ccdm_normal_day;
 this.inactivity_counter_for_ccdm_normal_dayChanged = true;
 this.inactivity_counter_salary_day = inactivity_counter_salary_day;
 this.inactivity_counter_salary_dayChanged = true;
 this.inactivity_counter_for_cdm_salary_day = inactivity_counter_for_cdm_salary_day;
 this.inactivity_counter_for_cdm_salary_dayChanged = true;
 this.inactivity_counter_for_ccdm_salary_day = inactivity_counter_for_ccdm_salary_day;
 this.inactivity_counter_for_ccdm_salary_dayChanged = true;
 }

 #region members and properties for columns

 #region AtmInactivityId
 private bool atm_inactivity_idChanged = false;
 private int atm_inactivity_id;
 public int AtmInactivityId
 {
 get { return atm_inactivity_id; }
 set { 
atm_inactivity_id = value;
atm_inactivity_idChanged = true;
 }
 }
 private string atm_inactivity_idDbString
 {
 get
 {
 return atm_inactivity_id.ToString();
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
 #region LastTransactionAt
 private bool last_transaction_atChanged = false;
 private DateTime? last_transaction_at;
 public DateTime? LastTransactionAt
 {
 get { return last_transaction_at; }
 set { 
last_transaction_at = value;
last_transaction_atChanged = true;
 }
 }
 private string last_transaction_atDbString
 {
 get
 {
 if (this.last_transaction_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",last_transaction_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region LastCdmTransactionAt
 private bool last_cdm_transaction_atChanged = false;
 private DateTime? last_cdm_transaction_at;
 public DateTime? LastCdmTransactionAt
 {
 get { return last_cdm_transaction_at; }
 set { 
last_cdm_transaction_at = value;
last_cdm_transaction_atChanged = true;
 }
 }
 private string last_cdm_transaction_atDbString
 {
 get
 {
 if (this.last_cdm_transaction_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",last_cdm_transaction_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region LastCcdmTransactionAt
 private bool last_ccdm_transaction_atChanged = false;
 private DateTime? last_ccdm_transaction_at;
 public DateTime? LastCcdmTransactionAt
 {
 get { return last_ccdm_transaction_at; }
 set { 
last_ccdm_transaction_at = value;
last_ccdm_transaction_atChanged = true;
 }
 }
 private string last_ccdm_transaction_atDbString
 {
 get
 {
 if (this.last_ccdm_transaction_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",last_ccdm_transaction_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounter
 private bool inactivity_counterChanged = false;
 private int? inactivity_counter;
 public int? InactivityCounter
 {
 get { return inactivity_counter; }
 set { 
inactivity_counter = value;
inactivity_counterChanged = true;
 }
 }
 private string inactivity_counterDbString
 {
 get
 {
 if (this.inactivity_counter.HasValue)
 return inactivity_counter.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterForCdm
 private bool inactivity_counter_for_cdmChanged = false;
 private int? inactivity_counter_for_cdm;
 public int? InactivityCounterForCdm
 {
 get { return inactivity_counter_for_cdm; }
 set { 
inactivity_counter_for_cdm = value;
inactivity_counter_for_cdmChanged = true;
 }
 }
 private string inactivity_counter_for_cdmDbString
 {
 get
 {
 if (this.inactivity_counter_for_cdm.HasValue)
 return inactivity_counter_for_cdm.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterForCcdm
 private bool inactivity_counter_for_ccdmChanged = false;
 private int? inactivity_counter_for_ccdm;
 public int? InactivityCounterForCcdm
 {
 get { return inactivity_counter_for_ccdm; }
 set { 
inactivity_counter_for_ccdm = value;
inactivity_counter_for_ccdmChanged = true;
 }
 }
 private string inactivity_counter_for_ccdmDbString
 {
 get
 {
 if (this.inactivity_counter_for_ccdm.HasValue)
 return inactivity_counter_for_ccdm.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterNormalDay
 private bool inactivity_counter_normal_dayChanged = false;
 private int? inactivity_counter_normal_day;
 public int? InactivityCounterNormalDay
 {
 get { return inactivity_counter_normal_day; }
 set { 
inactivity_counter_normal_day = value;
inactivity_counter_normal_dayChanged = true;
 }
 }
 private string inactivity_counter_normal_dayDbString
 {
 get
 {
 if (this.inactivity_counter_normal_day.HasValue)
 return inactivity_counter_normal_day.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterForCdmNormalDay
 private bool inactivity_counter_for_cdm_normal_dayChanged = false;
 private int? inactivity_counter_for_cdm_normal_day;
 public int? InactivityCounterForCdmNormalDay
 {
 get { return inactivity_counter_for_cdm_normal_day; }
 set { 
inactivity_counter_for_cdm_normal_day = value;
inactivity_counter_for_cdm_normal_dayChanged = true;
 }
 }
 private string inactivity_counter_for_cdm_normal_dayDbString
 {
 get
 {
 if (this.inactivity_counter_for_cdm_normal_day.HasValue)
 return inactivity_counter_for_cdm_normal_day.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterForCcdmNormalDay
 private bool inactivity_counter_for_ccdm_normal_dayChanged = false;
 private int? inactivity_counter_for_ccdm_normal_day;
 public int? InactivityCounterForCcdmNormalDay
 {
 get { return inactivity_counter_for_ccdm_normal_day; }
 set { 
inactivity_counter_for_ccdm_normal_day = value;
inactivity_counter_for_ccdm_normal_dayChanged = true;
 }
 }
 private string inactivity_counter_for_ccdm_normal_dayDbString
 {
 get
 {
 if (this.inactivity_counter_for_ccdm_normal_day.HasValue)
 return inactivity_counter_for_ccdm_normal_day.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterSalaryDay
 private bool inactivity_counter_salary_dayChanged = false;
 private int? inactivity_counter_salary_day;
 public int? InactivityCounterSalaryDay
 {
 get { return inactivity_counter_salary_day; }
 set { 
inactivity_counter_salary_day = value;
inactivity_counter_salary_dayChanged = true;
 }
 }
 private string inactivity_counter_salary_dayDbString
 {
 get
 {
 if (this.inactivity_counter_salary_day.HasValue)
 return inactivity_counter_salary_day.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterForCdmSalaryDay
 private bool inactivity_counter_for_cdm_salary_dayChanged = false;
 private int? inactivity_counter_for_cdm_salary_day;
 public int? InactivityCounterForCdmSalaryDay
 {
 get { return inactivity_counter_for_cdm_salary_day; }
 set { 
inactivity_counter_for_cdm_salary_day = value;
inactivity_counter_for_cdm_salary_dayChanged = true;
 }
 }
 private string inactivity_counter_for_cdm_salary_dayDbString
 {
 get
 {
 if (this.inactivity_counter_for_cdm_salary_day.HasValue)
 return inactivity_counter_for_cdm_salary_day.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InactivityCounterForCcdmSalaryDay
 private bool inactivity_counter_for_ccdm_salary_dayChanged = false;
 private int? inactivity_counter_for_ccdm_salary_day;
 public int? InactivityCounterForCcdmSalaryDay
 {
 get { return inactivity_counter_for_ccdm_salary_day; }
 set { 
inactivity_counter_for_ccdm_salary_day = value;
inactivity_counter_for_ccdm_salary_dayChanged = true;
 }
 }
 private string inactivity_counter_for_ccdm_salary_dayDbString
 {
 get
 {
 if (this.inactivity_counter_for_ccdm_salary_day.HasValue)
 return inactivity_counter_for_ccdm_salary_day.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region AtmInactivityReader
 public class AtmInactivityReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
AtmInactivity currentAtmInactivity;
 Columns columns;
 bool partialRead = false;
 private AtmInactivityReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public AtmInactivityReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public AtmInactivityReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentAtmInactivity; }

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
 currentAtmInactivity = new AtmInactivity();
 if (partialRead)
 { if ((columns & Columns.atm_inactivity_id) == Columns.atm_inactivity_id && reader["atm_inactivity_id"]!=DBNull.Value)
 currentAtmInactivity.atm_inactivity_id =(int) reader["atm_inactivity_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentAtmInactivity.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.last_transaction_at) == Columns.last_transaction_at && reader["last_transaction_at"]!=DBNull.Value)
 currentAtmInactivity.last_transaction_at =(DateTime?) reader["last_transaction_at"]; 
 if ((columns & Columns.last_cdm_transaction_at) == Columns.last_cdm_transaction_at && reader["last_cdm_transaction_at"]!=DBNull.Value)
 currentAtmInactivity.last_cdm_transaction_at =(DateTime?) reader["last_cdm_transaction_at"]; 
 if ((columns & Columns.last_ccdm_transaction_at) == Columns.last_ccdm_transaction_at && reader["last_ccdm_transaction_at"]!=DBNull.Value)
 currentAtmInactivity.last_ccdm_transaction_at =(DateTime?) reader["last_ccdm_transaction_at"]; 
 if ((columns & Columns.inactivity_counter) == Columns.inactivity_counter && reader["inactivity_counter"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter =(int?) reader["inactivity_counter"]; 
 if ((columns & Columns.inactivity_counter_for_cdm) == Columns.inactivity_counter_for_cdm && reader["inactivity_counter_for_cdm"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_cdm =(int?) reader["inactivity_counter_for_cdm"]; 
 if ((columns & Columns.inactivity_counter_for_ccdm) == Columns.inactivity_counter_for_ccdm && reader["inactivity_counter_for_ccdm"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_ccdm =(int?) reader["inactivity_counter_for_ccdm"]; 
 if ((columns & Columns.inactivity_counter_normal_day) == Columns.inactivity_counter_normal_day && reader["inactivity_counter_normal_day"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_normal_day =(int?) reader["inactivity_counter_normal_day"]; 
 if ((columns & Columns.inactivity_counter_for_cdm_normal_day) == Columns.inactivity_counter_for_cdm_normal_day && reader["inactivity_counter_for_cdm_normal_day"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_cdm_normal_day =(int?) reader["inactivity_counter_for_cdm_normal_day"]; 
 if ((columns & Columns.inactivity_counter_for_ccdm_normal_day) == Columns.inactivity_counter_for_ccdm_normal_day && reader["inactivity_counter_for_ccdm_normal_day"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_ccdm_normal_day =(int?) reader["inactivity_counter_for_ccdm_normal_day"]; 
 if ((columns & Columns.inactivity_counter_salary_day) == Columns.inactivity_counter_salary_day && reader["inactivity_counter_salary_day"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_salary_day =(int?) reader["inactivity_counter_salary_day"]; 
 if ((columns & Columns.inactivity_counter_for_cdm_salary_day) == Columns.inactivity_counter_for_cdm_salary_day && reader["inactivity_counter_for_cdm_salary_day"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_cdm_salary_day =(int?) reader["inactivity_counter_for_cdm_salary_day"]; 
 if ((columns & Columns.inactivity_counter_for_ccdm_salary_day) == Columns.inactivity_counter_for_ccdm_salary_day && reader["inactivity_counter_for_ccdm_salary_day"]!=DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_ccdm_salary_day =(int?) reader["inactivity_counter_for_ccdm_salary_day"]; 

 } else
 {
 if (reader["atm_inactivity_id"] != DBNull.Value)
 currentAtmInactivity.atm_inactivity_id = (int) reader["atm_inactivity_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentAtmInactivity.atm_id = (int) reader["atm_id"]; 
 if (reader["last_transaction_at"] != DBNull.Value)
 currentAtmInactivity.last_transaction_at = (DateTime?) reader["last_transaction_at"]; 
 if (reader["last_cdm_transaction_at"] != DBNull.Value)
 currentAtmInactivity.last_cdm_transaction_at = (DateTime?) reader["last_cdm_transaction_at"]; 
 if (reader["last_ccdm_transaction_at"] != DBNull.Value)
 currentAtmInactivity.last_ccdm_transaction_at = (DateTime?) reader["last_ccdm_transaction_at"]; 
 if (reader["inactivity_counter"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter = (int?) reader["inactivity_counter"]; 
 if (reader["inactivity_counter_for_cdm"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_cdm = (int?) reader["inactivity_counter_for_cdm"]; 
 if (reader["inactivity_counter_for_ccdm"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_ccdm = (int?) reader["inactivity_counter_for_ccdm"]; 
 if (reader["inactivity_counter_normal_day"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_normal_day = (int?) reader["inactivity_counter_normal_day"]; 
 if (reader["inactivity_counter_for_cdm_normal_day"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_cdm_normal_day = (int?) reader["inactivity_counter_for_cdm_normal_day"]; 
 if (reader["inactivity_counter_for_ccdm_normal_day"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_ccdm_normal_day = (int?) reader["inactivity_counter_for_ccdm_normal_day"]; 
 if (reader["inactivity_counter_salary_day"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_salary_day = (int?) reader["inactivity_counter_salary_day"]; 
 if (reader["inactivity_counter_for_cdm_salary_day"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_cdm_salary_day = (int?) reader["inactivity_counter_for_cdm_salary_day"]; 
 if (reader["inactivity_counter_for_ccdm_salary_day"] != DBNull.Value)
 currentAtmInactivity.inactivity_counter_for_ccdm_salary_day = (int?) reader["inactivity_counter_for_ccdm_salary_day"]; 
 } 

 currentAtmInactivity.isNewEntity = false;
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

 public AtmInactivity CurrentAtmInactivity
 {
 get{ return currentAtmInactivity; }
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


 #region AtmInactivity functions

 public static AtmInactivityReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.atm_inactivity_id == (Columns.atm_inactivity_id & columns))
 qry.Append("atm_inactivity_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.last_transaction_at == (Columns.last_transaction_at & columns))
 qry.Append("last_transaction_at,");
 if (Columns.last_cdm_transaction_at == (Columns.last_cdm_transaction_at & columns))
 qry.Append("last_cdm_transaction_at,");
 if (Columns.last_ccdm_transaction_at == (Columns.last_ccdm_transaction_at & columns))
 qry.Append("last_ccdm_transaction_at,");
 if (Columns.inactivity_counter == (Columns.inactivity_counter & columns))
 qry.Append("inactivity_counter,");
 if (Columns.inactivity_counter_for_cdm == (Columns.inactivity_counter_for_cdm & columns))
 qry.Append("inactivity_counter_for_cdm,");
 if (Columns.inactivity_counter_for_ccdm == (Columns.inactivity_counter_for_ccdm & columns))
 qry.Append("inactivity_counter_for_ccdm,");
 if (Columns.inactivity_counter_normal_day == (Columns.inactivity_counter_normal_day & columns))
 qry.Append("inactivity_counter_normal_day,");
 if (Columns.inactivity_counter_for_cdm_normal_day == (Columns.inactivity_counter_for_cdm_normal_day & columns))
 qry.Append("inactivity_counter_for_cdm_normal_day,");
 if (Columns.inactivity_counter_for_ccdm_normal_day == (Columns.inactivity_counter_for_ccdm_normal_day & columns))
 qry.Append("inactivity_counter_for_ccdm_normal_day,");
 if (Columns.inactivity_counter_salary_day == (Columns.inactivity_counter_salary_day & columns))
 qry.Append("inactivity_counter_salary_day,");
 if (Columns.inactivity_counter_for_cdm_salary_day == (Columns.inactivity_counter_for_cdm_salary_day & columns))
 qry.Append("inactivity_counter_for_cdm_salary_day,");
 if (Columns.inactivity_counter_for_ccdm_salary_day == (Columns.inactivity_counter_for_ccdm_salary_day & columns))
 qry.Append("inactivity_counter_for_ccdm_salary_day,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Atm_inactivity ");

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
 return new AtmInactivityReader(cmd.ExecuteReader(), conn, columns);
 }

 static public AtmInactivityReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static AtmInactivityReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select atm_inactivity_id,atm_id,last_transaction_at,last_cdm_transaction_at,last_ccdm_transaction_at,inactivity_counter,inactivity_counter_for_cdm,inactivity_counter_for_ccdm,inactivity_counter_normal_day,inactivity_counter_for_cdm_normal_day,inactivity_counter_for_ccdm_normal_day,inactivity_counter_salary_day,inactivity_counter_for_cdm_salary_day,inactivity_counter_for_ccdm_salary_day from Atm_inactivity ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new AtmInactivityReader(cmd.ExecuteReader(), conn);
 }

 static public AtmInactivityReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static AtmInactivity LoadAtmInactivity(string where)
 {
AtmInactivityReader reader = AtmInactivity.ExecuteReader(where);
AtmInactivity _atminactivity = null;
 if (reader.Read())
 _atminactivity = reader.CurrentAtmInactivity;
 reader.Close();
 return _atminactivity;
 }

 public static AtmInactivity LoadAtmInactivity(string where, IDbConnection conn)
 {
AtmInactivityReader reader = AtmInactivity.ExecuteReader(where, conn);
AtmInactivity _atminactivity = null;
 if (reader.Read())
 _atminactivity = reader.CurrentAtmInactivity;
 reader.Close(false);
 return _atminactivity;
 }

 public static AtmInactivity LoadAtmInactivityByPk( int atm_inactivity_id )
 {
 return LoadAtmInactivity( " atm_inactivity_id="+atm_inactivity_id );
 }

 public static AtmInactivity LoadAtmInactivityByPk( int atm_inactivity_id , IDbConnection conn)
 {
 return LoadAtmInactivity(" atm_inactivity_id="+atm_inactivity_id , conn);
 }

 public void Save()
 {
 if (atm_inactivity_idChanged || atm_idChanged || last_transaction_atChanged || last_cdm_transaction_atChanged || last_ccdm_transaction_atChanged || inactivity_counterChanged || inactivity_counter_for_cdmChanged || inactivity_counter_for_ccdmChanged || inactivity_counter_normal_dayChanged || inactivity_counter_for_cdm_normal_dayChanged || inactivity_counter_for_ccdm_normal_dayChanged || inactivity_counter_salary_dayChanged || inactivity_counter_for_cdm_salary_dayChanged || inactivity_counter_for_ccdm_salary_dayChanged )
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
 if (atm_inactivity_idChanged || atm_idChanged || last_transaction_atChanged || last_cdm_transaction_atChanged || last_ccdm_transaction_atChanged || inactivity_counterChanged || inactivity_counter_for_cdmChanged || inactivity_counter_for_ccdmChanged || inactivity_counter_normal_dayChanged || inactivity_counter_for_cdm_normal_dayChanged || inactivity_counter_for_ccdm_normal_dayChanged || inactivity_counter_salary_dayChanged || inactivity_counter_for_cdm_salary_dayChanged || inactivity_counter_for_ccdm_salary_dayChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Atm_inactivity( atm_inactivity_id,atm_id,last_transaction_at,last_cdm_transaction_at,last_ccdm_transaction_at,inactivity_counter,inactivity_counter_for_cdm,inactivity_counter_for_ccdm,inactivity_counter_normal_day,inactivity_counter_for_cdm_normal_day,inactivity_counter_for_ccdm_normal_day,inactivity_counter_salary_day,inactivity_counter_for_cdm_salary_day,inactivity_counter_for_ccdm_salary_day ) values(");
 lock (ConnectionFactory.connectionString) { this.atm_inactivity_id = ConnectionFactory.GetNextId();
 qry.Append(this.atm_inactivity_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(last_transaction_atDbString+",");
 qry.Append(last_cdm_transaction_atDbString+",");
 qry.Append(last_ccdm_transaction_atDbString+",");
 qry.Append(inactivity_counterDbString+",");
 qry.Append(inactivity_counter_for_cdmDbString+",");
 qry.Append(inactivity_counter_for_ccdmDbString+",");
 qry.Append(inactivity_counter_normal_dayDbString+",");
 qry.Append(inactivity_counter_for_cdm_normal_dayDbString+",");
 qry.Append(inactivity_counter_for_ccdm_normal_dayDbString+",");
 qry.Append(inactivity_counter_salary_dayDbString+",");
 qry.Append(inactivity_counter_for_cdm_salary_dayDbString+",");
 qry.Append(inactivity_counter_for_ccdm_salary_dayDbString);
 qry.Append(");");

 }
 else
 {
 if (!(atm_inactivity_idChanged || atm_idChanged || last_transaction_atChanged || last_cdm_transaction_atChanged || last_ccdm_transaction_atChanged || inactivity_counterChanged || inactivity_counter_for_cdmChanged || inactivity_counter_for_ccdmChanged || inactivity_counter_normal_dayChanged || inactivity_counter_for_cdm_normal_dayChanged || inactivity_counter_for_ccdm_normal_dayChanged || inactivity_counter_salary_dayChanged || inactivity_counter_for_cdm_salary_dayChanged || inactivity_counter_for_ccdm_salary_dayChanged ))
 return;
 qry.Append("UPDATE Atm_inactivity set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( last_transaction_atChanged )
 {
 qry.Append("last_transaction_at ="+last_transaction_atDbString);
 qry.Append(",");
 }

 if ( last_cdm_transaction_atChanged )
 {
 qry.Append("last_cdm_transaction_at ="+last_cdm_transaction_atDbString);
 qry.Append(",");
 }

 if ( last_ccdm_transaction_atChanged )
 {
 qry.Append("last_ccdm_transaction_at ="+last_ccdm_transaction_atDbString);
 qry.Append(",");
 }

 if ( inactivity_counterChanged )
 {
 qry.Append("inactivity_counter ="+inactivity_counterDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_for_cdmChanged )
 {
 qry.Append("inactivity_counter_for_cdm ="+inactivity_counter_for_cdmDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_for_ccdmChanged )
 {
 qry.Append("inactivity_counter_for_ccdm ="+inactivity_counter_for_ccdmDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_normal_dayChanged )
 {
 qry.Append("inactivity_counter_normal_day ="+inactivity_counter_normal_dayDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_for_cdm_normal_dayChanged )
 {
 qry.Append("inactivity_counter_for_cdm_normal_day ="+inactivity_counter_for_cdm_normal_dayDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_for_ccdm_normal_dayChanged )
 {
 qry.Append("inactivity_counter_for_ccdm_normal_day ="+inactivity_counter_for_ccdm_normal_dayDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_salary_dayChanged )
 {
 qry.Append("inactivity_counter_salary_day ="+inactivity_counter_salary_dayDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_for_cdm_salary_dayChanged )
 {
 qry.Append("inactivity_counter_for_cdm_salary_day ="+inactivity_counter_for_cdm_salary_dayDbString);
 qry.Append(",");
 }

 if ( inactivity_counter_for_ccdm_salary_dayChanged )
 {
 qry.Append("inactivity_counter_for_ccdm_salary_day ="+inactivity_counter_for_ccdm_salary_dayDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("atm_inactivity_id = "+atm_inactivity_idDbString);
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
 cmd.CommandText = "DELETE Atm_inactivity where atm_inactivity_id = "+ atm_inactivity_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteAtmInactivitys(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Atm_inactivity where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
atm_inactivity_id= 1,
atm_id= 2,
last_transaction_at= 4,
last_cdm_transaction_at= 8,
last_ccdm_transaction_at= 16,
inactivity_counter= 32,
inactivity_counter_for_cdm= 64,
inactivity_counter_for_ccdm= 128,
inactivity_counter_normal_day= 256,
inactivity_counter_for_cdm_normal_day= 512,
inactivity_counter_for_ccdm_normal_day= 1024,
inactivity_counter_salary_day= 2048,
inactivity_counter_for_cdm_salary_day= 4096,
inactivity_counter_for_ccdm_salary_day= 8192
 }
 #endregion
 public void BulkSave(List<AtmInactivity> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Atm_inactivity";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(AtmInactivity.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <AtmInactivity> transList,ref DataTable dt)
 {
 foreach (AtmInactivity tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["atm_inactivity_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["last_transaction_at"] = tran.LastTransactionAt;
 Row["last_cdm_transaction_at"] = tran.LastCdmTransactionAt;
 Row["last_ccdm_transaction_at"] = tran.LastCcdmTransactionAt;
 Row["inactivity_counter"] = tran.InactivityCounter;
 Row["inactivity_counter_for_cdm"] = tran.InactivityCounterForCdm;
 Row["inactivity_counter_for_ccdm"] = tran.InactivityCounterForCcdm;
 Row["inactivity_counter_normal_day"] = tran.InactivityCounterNormalDay;
 Row["inactivity_counter_for_cdm_normal_day"] = tran.InactivityCounterForCdmNormalDay;
 Row["inactivity_counter_for_ccdm_normal_day"] = tran.InactivityCounterForCcdmNormalDay;
 Row["inactivity_counter_salary_day"] = tran.InactivityCounterSalaryDay;
 Row["inactivity_counter_for_cdm_salary_day"] = tran.InactivityCounterForCdmSalaryDay;
 Row["inactivity_counter_for_ccdm_salary_day"] = tran.InactivityCounterForCcdmSalaryDay;
 dt.Rows.Add(Row);
 } }
 }
 }

 
