
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
 public class ObjectPerformanceReport
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ObjectPerformanceReport() { }
 public ObjectPerformanceReport( int object_performance_report_id,int atm_type
 )  {
 this.atm_type = atm_type;
 this.atm_typeChanged = true;
 }
 public ObjectPerformanceReport( string excel_file_name,DateTime? creation_time,DateTime? report_date,int atm_type )
 {
 this.excel_file_name = excel_file_name;
 this.excel_file_nameChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.report_date = report_date;
 this.report_dateChanged = true;
 this.atm_type = atm_type;
 this.atm_typeChanged = true;
 }
 private ObjectPerformanceReport( int object_performance_report_id,string excel_file_name,DateTime? creation_time,DateTime? report_date,int atm_type )
 {
 this.object_performance_report_id = object_performance_report_id;
 this.object_performance_report_idChanged = true;
 this.excel_file_name = excel_file_name;
 this.excel_file_nameChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.report_date = report_date;
 this.report_dateChanged = true;
 this.atm_type = atm_type;
 this.atm_typeChanged = true;
 }

 #region members and properties for columns

 #region ObjectPerformanceReportId
 private bool object_performance_report_idChanged = false;
 private int object_performance_report_id;
 public int ObjectPerformanceReportId
 {
 get { return object_performance_report_id; }
 set { 
object_performance_report_id = value;
object_performance_report_idChanged = true;
 }
 }
 private string object_performance_report_idDbString
 {
 get
 {
 return object_performance_report_id.ToString();
 }
 }
 #endregion
 #region ExcelFileName
 private bool excel_file_nameChanged = false;
 private string excel_file_name;
 public string ExcelFileName
 {
 get { return excel_file_name; }
 set { 
excel_file_name = value;
excel_file_nameChanged = true;
 }
 }
 private string excel_file_nameDbString
 {
 get
 {
 if (this.excel_file_name!=null)
 return string.Format("'{0}'",excel_file_name); else
 return "null";
 }
 }
 #endregion
 #region CreationTime
 private bool creation_timeChanged = false;
 private DateTime? creation_time;
 public DateTime? CreationTime
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
 if (this.creation_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",creation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region ReportDate
 private bool report_dateChanged = false;
 private DateTime? report_date;
 public DateTime? ReportDate
 {
 get { return report_date; }
 set { 
report_date = value;
report_dateChanged = true;
 }
 }
 private string report_dateDbString
 {
 get
 {
 if (this.report_date.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",report_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region AtmType
 private bool atm_typeChanged = false;
 private int atm_type;
 public int AtmType
 {
 get { return atm_type; }
 set { 
atm_type = value;
atm_typeChanged = true;
 }
 }
 private string atm_typeDbString
 {
 get
 {
 return atm_type.ToString();
 }
 }
 #endregion
 #endregion

 #region ObjectPerformanceReportReader
 public class ObjectPerformanceReportReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ObjectPerformanceReport currentObjectPerformanceReport;
 Columns columns;
 bool partialRead = false;
 private ObjectPerformanceReportReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ObjectPerformanceReportReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ObjectPerformanceReportReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentObjectPerformanceReport; }

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
 currentObjectPerformanceReport = new ObjectPerformanceReport();
 if (partialRead)
 { if ((columns & Columns.object_performance_report_id) == Columns.object_performance_report_id && reader["object_performance_report_id"]!=DBNull.Value)
 currentObjectPerformanceReport.object_performance_report_id =(int) reader["object_performance_report_id"]; 
 if ((columns & Columns.excel_file_name) == Columns.excel_file_name && reader["excel_file_name"]!=DBNull.Value)
 currentObjectPerformanceReport.excel_file_name =(string) reader["excel_file_name"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentObjectPerformanceReport.creation_time =(DateTime?) reader["creation_time"]; 
 if ((columns & Columns.report_date) == Columns.report_date && reader["report_date"]!=DBNull.Value)
 currentObjectPerformanceReport.report_date =(DateTime?) reader["report_date"]; 
 if ((columns & Columns.atm_type) == Columns.atm_type && reader["atm_type"]!=DBNull.Value)
 currentObjectPerformanceReport.atm_type =(int) reader["atm_type"]; 

 } else
 {
 if (reader["object_performance_report_id"] != DBNull.Value)
 currentObjectPerformanceReport.object_performance_report_id = (int) reader["object_performance_report_id"]; 
 if (reader["excel_file_name"] != DBNull.Value)
 currentObjectPerformanceReport.excel_file_name = (string) reader["excel_file_name"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentObjectPerformanceReport.creation_time = (DateTime?) reader["creation_time"]; 
 if (reader["report_date"] != DBNull.Value)
 currentObjectPerformanceReport.report_date = (DateTime?) reader["report_date"]; 
 if (reader["atm_type"] != DBNull.Value)
 currentObjectPerformanceReport.atm_type = (int) reader["atm_type"]; 
 } 

 currentObjectPerformanceReport.isNewEntity = false;
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

 public ObjectPerformanceReport CurrentObjectPerformanceReport
 {
 get{ return currentObjectPerformanceReport; }
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


 #region ObjectPerformanceReport functions

 public static ObjectPerformanceReportReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.object_performance_report_id == (Columns.object_performance_report_id & columns))
 qry.Append("object_performance_report_id,");
 if (Columns.excel_file_name == (Columns.excel_file_name & columns))
 qry.Append("excel_file_name,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.report_date == (Columns.report_date & columns))
 qry.Append("report_date,");
 if (Columns.atm_type == (Columns.atm_type & columns))
 qry.Append("atm_type,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Object_performance_report ");

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
 return new ObjectPerformanceReportReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ObjectPerformanceReportReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ObjectPerformanceReportReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select object_performance_report_id,excel_file_name,creation_time,report_date,atm_type from Object_performance_report ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ObjectPerformanceReportReader(cmd.ExecuteReader(), conn);
 }

 static public ObjectPerformanceReportReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static ObjectPerformanceReport LoadObjectPerformanceReport(string where)
 {
ObjectPerformanceReportReader reader = ObjectPerformanceReport.ExecuteReader(where);
ObjectPerformanceReport _objectperformancereport = null;
 if (reader.Read())
 _objectperformancereport = reader.CurrentObjectPerformanceReport;
 reader.Close();
 return _objectperformancereport;
 }

 public static ObjectPerformanceReport LoadObjectPerformanceReport(string where, IDbConnection conn)
 {
ObjectPerformanceReportReader reader = ObjectPerformanceReport.ExecuteReader(where, conn);
ObjectPerformanceReport _objectperformancereport = null;
 if (reader.Read())
 _objectperformancereport = reader.CurrentObjectPerformanceReport;
 reader.Close(false);
 return _objectperformancereport;
 }

 public static ObjectPerformanceReport LoadObjectPerformanceReportByPk( int object_performance_report_id )
 {
 return LoadObjectPerformanceReport( " object_performance_report_id="+object_performance_report_id );
 }

 public static ObjectPerformanceReport LoadObjectPerformanceReportByPk( int object_performance_report_id , IDbConnection conn)
 {
 return LoadObjectPerformanceReport(" object_performance_report_id="+object_performance_report_id , conn);
 }

 public void Save()
 {
 if (object_performance_report_idChanged || excel_file_nameChanged || creation_timeChanged || report_dateChanged || atm_typeChanged )
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
 if (object_performance_report_idChanged || excel_file_nameChanged || creation_timeChanged || report_dateChanged || atm_typeChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Object_performance_report( object_performance_report_id,excel_file_name,creation_time,report_date,atm_type ) values(");
 lock (ConnectionFactory.connectionString) { this.object_performance_report_id = ConnectionFactory.GetNextId();
 qry.Append(this.object_performance_report_id);
 } qry.Append(",");
 qry.Append(excel_file_nameDbString+",");
 qry.Append(creation_timeDbString+",");
 qry.Append(report_dateDbString+",");
 qry.Append(atm_typeDbString);
 qry.Append(");");

 }
 else
 {
 if (!(object_performance_report_idChanged || excel_file_nameChanged || creation_timeChanged || report_dateChanged || atm_typeChanged ))
 return;
 qry.Append("UPDATE Object_performance_report set "); if ( excel_file_nameChanged )
 {
 qry.Append("excel_file_name ="+excel_file_nameDbString);
 qry.Append(",");
 }

 if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( report_dateChanged )
 {
 qry.Append("report_date ="+report_dateDbString);
 qry.Append(",");
 }

 if ( atm_typeChanged )
 {
 qry.Append("atm_type ="+atm_typeDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("object_performance_report_id = "+object_performance_report_idDbString);
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
 cmd.CommandText = "DELETE Object_performance_report where object_performance_report_id = "+ object_performance_report_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteObjectPerformanceReports(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Object_performance_report where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
object_performance_report_id= 1,
excel_file_name= 2,
creation_time= 4,
report_date= 8,
atm_type= 16
 }
 #endregion
 public void BulkSave(List<ObjectPerformanceReport> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Object_performance_report";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ObjectPerformanceReport.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ObjectPerformanceReport> transList,ref DataTable dt)
 {
 foreach (ObjectPerformanceReport tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["object_performance_report_id"] =ConnectionFactory.GetNextId();
 Row["excel_file_name"] = tran.ExcelFileName;
 Row["creation_time"] = tran.CreationTime;
 Row["report_date"] = tran.ReportDate;
 Row["atm_type"] = tran.AtmType;
 dt.Rows.Add(Row);
 } }
 }
 }
