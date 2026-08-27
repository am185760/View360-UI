
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
 public class ObjectPerformanceReportDetail
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ObjectPerformanceReportDetail() { }
 public ObjectPerformanceReportDetail( int object_performance_report_detail_id,int atm_id,int object_performance_report_id ) 
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.object_performance_report_id = object_performance_report_id;
 this.object_performance_report_idChanged = true;
 }
 public ObjectPerformanceReportDetail( int atm_id,string object_type,string city,string address,string branch,string location_type,decimal? in_service,decimal? out_of_service,int? total_downtime,decimal? comms_failure,decimal? flm_p1,decimal? host_down,decimal? slm_p1,decimal? cash_out,decimal? in_supervisor,int object_performance_report_id )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.object_type = object_type;
 this.object_typeChanged = true;
 this.city = city;
 this.cityChanged = true;
 this.address = address;
 this.addressChanged = true;
 this.branch = branch;
 this.branchChanged = true;
 this.location_type = location_type;
 this.location_typeChanged = true;
 this.in_service = in_service;
 this.in_serviceChanged = true;
 this.out_of_service = out_of_service;
 this.out_of_serviceChanged = true;
 this.total_downtime = total_downtime;
 this.total_downtimeChanged = true;
 this.comms_failure = comms_failure;
 this.comms_failureChanged = true;
 this.flm_p1 = flm_p1;
 this.flm_p1Changed = true;
 this.host_down = host_down;
 this.host_downChanged = true;
 this.slm_p1 = slm_p1;
 this.slm_p1Changed = true;
 this.cash_out = cash_out;
 this.cash_outChanged = true;
 this.in_supervisor = in_supervisor;
 this.in_supervisorChanged = true;
 this.object_performance_report_id = object_performance_report_id;
 this.object_performance_report_idChanged = true;
 }
 private ObjectPerformanceReportDetail( int object_performance_report_detail_id,int atm_id,string object_type,string city,string address,string branch,string location_type,decimal? in_service,decimal? out_of_service,int? total_downtime,decimal? comms_failure,decimal? flm_p1,decimal? host_down,decimal? slm_p1,decimal? cash_out,decimal? in_supervisor,int object_performance_report_id )
 {
 this.object_performance_report_detail_id = object_performance_report_detail_id;
 this.object_performance_report_detail_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.object_type = object_type;
 this.object_typeChanged = true;
 this.city = city;
 this.cityChanged = true;
 this.address = address;
 this.addressChanged = true;
 this.branch = branch;
 this.branchChanged = true;
 this.location_type = location_type;
 this.location_typeChanged = true;
 this.in_service = in_service;
 this.in_serviceChanged = true;
 this.out_of_service = out_of_service;
 this.out_of_serviceChanged = true;
 this.total_downtime = total_downtime;
 this.total_downtimeChanged = true;
 this.comms_failure = comms_failure;
 this.comms_failureChanged = true;
 this.flm_p1 = flm_p1;
 this.flm_p1Changed = true;
 this.host_down = host_down;
 this.host_downChanged = true;
 this.slm_p1 = slm_p1;
 this.slm_p1Changed = true;
 this.cash_out = cash_out;
 this.cash_outChanged = true;
 this.in_supervisor = in_supervisor;
 this.in_supervisorChanged = true;
 this.object_performance_report_id = object_performance_report_id;
 this.object_performance_report_idChanged = true;
 }

 #region members and properties for columns

 #region ObjectPerformanceReportDetailId
 private bool object_performance_report_detail_idChanged = false;
 private int object_performance_report_detail_id;
 public int ObjectPerformanceReportDetailId
 {
 get { return object_performance_report_detail_id; }
 set { 
object_performance_report_detail_id = value;
object_performance_report_detail_idChanged = true;
 }
 }
 private string object_performance_report_detail_idDbString
 {
 get
 {
 return object_performance_report_detail_id.ToString();
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
 #region ObjectType
 private bool object_typeChanged = false;
 private string object_type;
 public string ObjectType
 {
 get { return object_type; }
 set { 
object_type = value;
object_typeChanged = true;
 }
 }
 private string object_typeDbString
 {
 get
 {
 if (this.object_type!=null)
 return string.Format("'{0}'",object_type); else
 return "null";
 }
 }
 #endregion
 #region City
 private bool cityChanged = false;
 private string city;
 public string City
 {
 get { return city; }
 set { 
city = value;
cityChanged = true;
 }
 }
 private string cityDbString
 {
 get
 {
 if (this.city!=null)
 return string.Format("'{0}'",city); else
 return "null";
 }
 }
 #endregion
 #region Address
 private bool addressChanged = false;
 private string address;
 public string Address
 {
 get { return address; }
 set { 
address = value;
addressChanged = true;
 }
 }
 private string addressDbString
 {
 get
 {
 if (this.address!=null)
 return string.Format("'{0}'",address); else
 return "null";
 }
 }
 #endregion
 #region Branch
 private bool branchChanged = false;
 private string branch;
 public string Branch
 {
 get { return branch; }
 set { 
branch = value;
branchChanged = true;
 }
 }
 private string branchDbString
 {
 get
 {
 if (this.branch!=null)
 return string.Format("'{0}'",branch); else
 return "null";
 }
 }
 #endregion
 #region LocationType
 private bool location_typeChanged = false;
 private string location_type;
 public string LocationType
 {
 get { return location_type; }
 set { 
location_type = value;
location_typeChanged = true;
 }
 }
 private string location_typeDbString
 {
 get
 {
 if (this.location_type!=null)
 return string.Format("'{0}'",location_type); else
 return "null";
 }
 }
 #endregion
 #region InService
 private bool in_serviceChanged = false;
 private decimal? in_service;
 public decimal? InService
 {
 get { return in_service; }
 set { 
in_service = value;
in_serviceChanged = true;
 }
 }
 private string in_serviceDbString
 {
 get
 {
 if (this.in_service.HasValue)
 return in_service.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region OutOfService
 private bool out_of_serviceChanged = false;
 private decimal? out_of_service;
 public decimal? OutOfService
 {
 get { return out_of_service; }
 set { 
out_of_service = value;
out_of_serviceChanged = true;
 }
 }
 private string out_of_serviceDbString
 {
 get
 {
 if (this.out_of_service.HasValue)
 return out_of_service.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region TotalDowntime
 private bool total_downtimeChanged = false;
 private int? total_downtime;
 public int? TotalDowntime
 {
 get { return total_downtime; }
 set { 
total_downtime = value;
total_downtimeChanged = true;
 }
 }
 private string total_downtimeDbString
 {
 get
 {
 if (this.total_downtime.HasValue)
 return total_downtime.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region CommsFailure
 private bool comms_failureChanged = false;
 private decimal? comms_failure;
 public decimal? CommsFailure
 {
 get { return comms_failure; }
 set { 
comms_failure = value;
comms_failureChanged = true;
 }
 }
 private string comms_failureDbString
 {
 get
 {
 if (this.comms_failure.HasValue)
 return comms_failure.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region FlmP1
 private bool flm_p1Changed = false;
 private decimal? flm_p1;
 public decimal? FlmP1
 {
 get { return flm_p1; }
 set { 
flm_p1 = value;
flm_p1Changed = true;
 }
 }
 private string flm_p1DbString
 {
 get
 {
 if (this.flm_p1.HasValue)
 return flm_p1.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region HostDown
 private bool host_downChanged = false;
 private decimal? host_down;
 public decimal? HostDown
 {
 get { return host_down; }
 set { 
host_down = value;
host_downChanged = true;
 }
 }
 private string host_downDbString
 {
 get
 {
 if (this.host_down.HasValue)
 return host_down.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region SlmP1
 private bool slm_p1Changed = false;
 private decimal? slm_p1;
 public decimal? SlmP1
 {
 get { return slm_p1; }
 set { 
slm_p1 = value;
slm_p1Changed = true;
 }
 }
 private string slm_p1DbString
 {
 get
 {
 if (this.slm_p1.HasValue)
 return slm_p1.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region CashOut
 private bool cash_outChanged = false;
 private decimal? cash_out;
 public decimal? CashOut
 {
 get { return cash_out; }
 set { 
cash_out = value;
cash_outChanged = true;
 }
 }
 private string cash_outDbString
 {
 get
 {
 if (this.cash_out.HasValue)
 return cash_out.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region InSupervisor
 private bool in_supervisorChanged = false;
 private decimal? in_supervisor;
 public decimal? InSupervisor
 {
 get { return in_supervisor; }
 set { 
in_supervisor = value;
in_supervisorChanged = true;
 }
 }
 private string in_supervisorDbString
 {
 get
 {
 if (this.in_supervisor.HasValue)
 return in_supervisor.ToString();
 else
 return "null";
 }
 }
 #endregion
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
 #endregion

 #region ObjectPerformanceReportDetailReader
 public class ObjectPerformanceReportDetailReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ObjectPerformanceReportDetail currentObjectPerformanceReportDetail;
 Columns columns;
 bool partialRead = false;
 private ObjectPerformanceReportDetailReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ObjectPerformanceReportDetailReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ObjectPerformanceReportDetailReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentObjectPerformanceReportDetail; }

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
 currentObjectPerformanceReportDetail = new ObjectPerformanceReportDetail();
 if (partialRead)
 { if ((columns & Columns.object_performance_report_detail_id) == Columns.object_performance_report_detail_id && reader["object_performance_report_detail_id"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.object_performance_report_detail_id =(int) reader["object_performance_report_detail_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.object_type) == Columns.object_type && reader["object_type"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.object_type =(string) reader["object_type"]; 
 if ((columns & Columns.city) == Columns.city && reader["city"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.city =(string) reader["city"]; 
 if ((columns & Columns.address) == Columns.address && reader["address"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.address =(string) reader["address"]; 
 if ((columns & Columns.branch) == Columns.branch && reader["branch"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.branch =(string) reader["branch"]; 
 if ((columns & Columns.location_type) == Columns.location_type && reader["location_type"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.location_type =(string) reader["location_type"]; 
 if ((columns & Columns.in_service) == Columns.in_service && reader["in_service"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.in_service =(decimal?) reader["in_service"]; 
 if ((columns & Columns.out_of_service) == Columns.out_of_service && reader["out_of_service"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.out_of_service =(decimal?) reader["out_of_service"]; 
 if ((columns & Columns.total_downtime) == Columns.total_downtime && reader["total_downtime"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.total_downtime =(int?) reader["total_downtime"]; 
 if ((columns & Columns.comms_failure) == Columns.comms_failure && reader["comms_failure"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.comms_failure =(decimal?) reader["comms_failure"]; 
 if ((columns & Columns.flm_p1) == Columns.flm_p1 && reader["flm_p1"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.flm_p1 =(decimal?) reader["flm_p1"]; 
 if ((columns & Columns.host_down) == Columns.host_down && reader["host_down"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.host_down =(decimal?) reader["host_down"]; 
 if ((columns & Columns.slm_p1) == Columns.slm_p1 && reader["slm_p1"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.slm_p1 =(decimal?) reader["slm_p1"]; 
 if ((columns & Columns.cash_out) == Columns.cash_out && reader["cash_out"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.cash_out =(decimal?) reader["cash_out"]; 
 if ((columns & Columns.in_supervisor) == Columns.in_supervisor && reader["in_supervisor"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.in_supervisor =(decimal?) reader["in_supervisor"]; 
 if ((columns & Columns.object_performance_report_id) == Columns.object_performance_report_id && reader["object_performance_report_id"]!=DBNull.Value)
 currentObjectPerformanceReportDetail.object_performance_report_id =(int) reader["object_performance_report_id"]; 

 } else
 {
 if (reader["object_performance_report_detail_id"] != DBNull.Value)
 currentObjectPerformanceReportDetail.object_performance_report_detail_id = (int) reader["object_performance_report_detail_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentObjectPerformanceReportDetail.atm_id = (int) reader["atm_id"]; 
 if (reader["object_type"] != DBNull.Value)
 currentObjectPerformanceReportDetail.object_type = (string) reader["object_type"]; 
 if (reader["city"] != DBNull.Value)
 currentObjectPerformanceReportDetail.city = (string) reader["city"]; 
 if (reader["address"] != DBNull.Value)
 currentObjectPerformanceReportDetail.address = (string) reader["address"]; 
 if (reader["branch"] != DBNull.Value)
 currentObjectPerformanceReportDetail.branch = (string) reader["branch"]; 
 if (reader["location_type"] != DBNull.Value)
 currentObjectPerformanceReportDetail.location_type = (string) reader["location_type"]; 
 if (reader["in_service"] != DBNull.Value)
 currentObjectPerformanceReportDetail.in_service = (decimal?) reader["in_service"]; 
 if (reader["out_of_service"] != DBNull.Value)
 currentObjectPerformanceReportDetail.out_of_service = (decimal?) reader["out_of_service"]; 
 if (reader["total_downtime"] != DBNull.Value)
 currentObjectPerformanceReportDetail.total_downtime = (int?) reader["total_downtime"]; 
 if (reader["comms_failure"] != DBNull.Value)
 currentObjectPerformanceReportDetail.comms_failure = (decimal?) reader["comms_failure"]; 
 if (reader["flm_p1"] != DBNull.Value)
 currentObjectPerformanceReportDetail.flm_p1 = (decimal?) reader["flm_p1"]; 
 if (reader["host_down"] != DBNull.Value)
 currentObjectPerformanceReportDetail.host_down = (decimal?) reader["host_down"]; 
 if (reader["slm_p1"] != DBNull.Value)
 currentObjectPerformanceReportDetail.slm_p1 = (decimal?) reader["slm_p1"]; 
 if (reader["cash_out"] != DBNull.Value)
 currentObjectPerformanceReportDetail.cash_out = (decimal?) reader["cash_out"]; 
 if (reader["in_supervisor"] != DBNull.Value)
 currentObjectPerformanceReportDetail.in_supervisor = (decimal?) reader["in_supervisor"]; 
 if (reader["object_performance_report_id"] != DBNull.Value)
 currentObjectPerformanceReportDetail.object_performance_report_id = (int) reader["object_performance_report_id"]; 
 } 

 currentObjectPerformanceReportDetail.isNewEntity = false;
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

 public ObjectPerformanceReportDetail CurrentObjectPerformanceReportDetail
 {
 get{ return currentObjectPerformanceReportDetail; }
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


 #region ObjectPerformanceReportDetail functions

 public static ObjectPerformanceReportDetailReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.object_performance_report_detail_id == (Columns.object_performance_report_detail_id & columns))
 qry.Append("object_performance_report_detail_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.object_type == (Columns.object_type & columns))
 qry.Append("object_type,");
 if (Columns.city == (Columns.city & columns))
 qry.Append("city,");
 if (Columns.address == (Columns.address & columns))
 qry.Append("address,");
 if (Columns.branch == (Columns.branch & columns))
 qry.Append("branch,");
 if (Columns.location_type == (Columns.location_type & columns))
 qry.Append("location_type,");
 if (Columns.in_service == (Columns.in_service & columns))
 qry.Append("in_service,");
 if (Columns.out_of_service == (Columns.out_of_service & columns))
 qry.Append("out_of_service,");
 if (Columns.total_downtime == (Columns.total_downtime & columns))
 qry.Append("total_downtime,");
 if (Columns.comms_failure == (Columns.comms_failure & columns))
 qry.Append("comms_failure,");
 if (Columns.flm_p1 == (Columns.flm_p1 & columns))
 qry.Append("flm_p1,");
 if (Columns.host_down == (Columns.host_down & columns))
 qry.Append("host_down,");
 if (Columns.slm_p1 == (Columns.slm_p1 & columns))
 qry.Append("slm_p1,");
 if (Columns.cash_out == (Columns.cash_out & columns))
 qry.Append("cash_out,");
 if (Columns.in_supervisor == (Columns.in_supervisor & columns))
 qry.Append("in_supervisor,");
 if (Columns.object_performance_report_id == (Columns.object_performance_report_id & columns))
 qry.Append("object_performance_report_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Object_performance_report_detail ");

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
 return new ObjectPerformanceReportDetailReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ObjectPerformanceReportDetailReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ObjectPerformanceReportDetailReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select object_performance_report_detail_id,atm_id,object_type,city,address,branch,location_type,in_service,out_of_service,total_downtime,comms_failure,flm_p1,host_down,slm_p1,cash_out,in_supervisor,object_performance_report_id from Object_performance_report_detail ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ObjectPerformanceReportDetailReader(cmd.ExecuteReader(), conn);
 }

 static public ObjectPerformanceReportDetailReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static ObjectPerformanceReportDetail LoadObjectPerformanceReportDetail(string where)
 {
ObjectPerformanceReportDetailReader reader = ObjectPerformanceReportDetail.ExecuteReader(where);
ObjectPerformanceReportDetail _objectperformancereportdetail = null;
 if (reader.Read())
 _objectperformancereportdetail = reader.CurrentObjectPerformanceReportDetail;
 reader.Close();
 return _objectperformancereportdetail;
 }

 public static ObjectPerformanceReportDetail LoadObjectPerformanceReportDetail(string where, IDbConnection conn)
 {
ObjectPerformanceReportDetailReader reader = ObjectPerformanceReportDetail.ExecuteReader(where, conn);
ObjectPerformanceReportDetail _objectperformancereportdetail = null;
 if (reader.Read())
 _objectperformancereportdetail = reader.CurrentObjectPerformanceReportDetail;
 reader.Close(false);
 return _objectperformancereportdetail;
 }

 public static ObjectPerformanceReportDetail LoadObjectPerformanceReportDetailByPk( int object_performance_report_detail_id )
 {
 return LoadObjectPerformanceReportDetail( " object_performance_report_detail_id="+object_performance_report_detail_id );
 }

 public static ObjectPerformanceReportDetail LoadObjectPerformanceReportDetailByPk( int object_performance_report_detail_id , IDbConnection conn)
 {
 return LoadObjectPerformanceReportDetail(" object_performance_report_detail_id="+object_performance_report_detail_id , conn);
 }

 public void Save()
 {
 if (object_performance_report_detail_idChanged || atm_idChanged || object_typeChanged || cityChanged || addressChanged || branchChanged || location_typeChanged || in_serviceChanged || out_of_serviceChanged || total_downtimeChanged || comms_failureChanged || flm_p1Changed || host_downChanged || slm_p1Changed || cash_outChanged || in_supervisorChanged || object_performance_report_idChanged )
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
 if (object_performance_report_detail_idChanged || atm_idChanged || object_typeChanged || cityChanged || addressChanged || branchChanged || location_typeChanged || in_serviceChanged || out_of_serviceChanged || total_downtimeChanged || comms_failureChanged || flm_p1Changed || host_downChanged || slm_p1Changed || cash_outChanged || in_supervisorChanged || object_performance_report_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Object_performance_report_detail( object_performance_report_detail_id,atm_id,object_type,city,address,branch,location_type,in_service,out_of_service,total_downtime,comms_failure,flm_p1,host_down,slm_p1,cash_out,in_supervisor,object_performance_report_id ) values(");
 lock (ConnectionFactory.connectionString) { this.object_performance_report_detail_id = ConnectionFactory.GetNextId();
 qry.Append(this.object_performance_report_detail_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(object_typeDbString+",");
 qry.Append(cityDbString+",");
 qry.Append(addressDbString+",");
 qry.Append(branchDbString+",");
 qry.Append(location_typeDbString+",");
 qry.Append(in_serviceDbString+",");
 qry.Append(out_of_serviceDbString+",");
 qry.Append(total_downtimeDbString+",");
 qry.Append(comms_failureDbString+",");
 qry.Append(flm_p1DbString+",");
 qry.Append(host_downDbString+",");
 qry.Append(slm_p1DbString+",");
 qry.Append(cash_outDbString+",");
 qry.Append(in_supervisorDbString+",");
 qry.Append(object_performance_report_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(object_performance_report_detail_idChanged || atm_idChanged || object_typeChanged || cityChanged || addressChanged || branchChanged || location_typeChanged || in_serviceChanged || out_of_serviceChanged || total_downtimeChanged || comms_failureChanged || flm_p1Changed || host_downChanged || slm_p1Changed || cash_outChanged || in_supervisorChanged || object_performance_report_idChanged ))
 return;
 qry.Append("UPDATE Object_performance_report_detail set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( object_typeChanged )
 {
 qry.Append("object_type ="+object_typeDbString);
 qry.Append(",");
 }

 if ( cityChanged )
 {
 qry.Append("city ="+cityDbString);
 qry.Append(",");
 }

 if ( addressChanged )
 {
 qry.Append("address ="+addressDbString);
 qry.Append(",");
 }

 if ( branchChanged )
 {
 qry.Append("branch ="+branchDbString);
 qry.Append(",");
 }

 if ( location_typeChanged )
 {
 qry.Append("location_type ="+location_typeDbString);
 qry.Append(",");
 }

 if ( in_serviceChanged )
 {
 qry.Append("in_service ="+in_serviceDbString);
 qry.Append(",");
 }

 if ( out_of_serviceChanged )
 {
 qry.Append("out_of_service ="+out_of_serviceDbString);
 qry.Append(",");
 }

 if ( total_downtimeChanged )
 {
 qry.Append("total_downtime ="+total_downtimeDbString);
 qry.Append(",");
 }

 if ( comms_failureChanged )
 {
 qry.Append("comms_failure ="+comms_failureDbString);
 qry.Append(",");
 }

 if ( flm_p1Changed )
 {
 qry.Append("flm_p1 ="+flm_p1DbString);
 qry.Append(",");
 }

 if ( host_downChanged )
 {
 qry.Append("host_down ="+host_downDbString);
 qry.Append(",");
 }

 if ( slm_p1Changed )
 {
 qry.Append("slm_p1 ="+slm_p1DbString);
 qry.Append(",");
 }

 if ( cash_outChanged )
 {
 qry.Append("cash_out ="+cash_outDbString);
 qry.Append(",");
 }

 if ( in_supervisorChanged )
 {
 qry.Append("in_supervisor ="+in_supervisorDbString);
 qry.Append(",");
 }

 if ( object_performance_report_idChanged )
 {
 qry.Append("object_performance_report_id ="+object_performance_report_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("object_performance_report_detail_id = "+object_performance_report_detail_idDbString);
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
 cmd.CommandText = "DELETE Object_performance_report_detail where object_performance_report_detail_id = "+ object_performance_report_detail_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteObjectPerformanceReportDetails(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Object_performance_report_detail where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
object_performance_report_detail_id= 1,
atm_id= 2,
object_type= 4,
city= 8,
address= 16,
branch= 32,
location_type= 64,
in_service= 128,
out_of_service= 256,
total_downtime= 512,
comms_failure= 1024,
flm_p1= 2048,
host_down= 4096,
slm_p1= 8192,
cash_out= 16384,
in_supervisor= 32768,
object_performance_report_id= 65536
 }
 #endregion
 public void BulkSave(List<ObjectPerformanceReportDetail> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Object_performance_report_detail";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ObjectPerformanceReportDetail.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ObjectPerformanceReportDetail> transList,ref DataTable dt)
 {
 foreach (ObjectPerformanceReportDetail tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["object_performance_report_detail_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["object_type"] = tran.ObjectType;
 Row["city"] = tran.City;
 Row["address"] = tran.Address;
 Row["branch"] = tran.Branch;
 Row["location_type"] = tran.LocationType;
 Row["in_service"] = tran.InService;
 Row["out_of_service"] = tran.OutOfService;
 Row["total_downtime"] = tran.TotalDowntime;
 Row["comms_failure"] = tran.CommsFailure;
 Row["flm_p1"] = tran.FlmP1;
 Row["host_down"] = tran.HostDown;
 Row["slm_p1"] = tran.SlmP1;
 Row["cash_out"] = tran.CashOut;
 Row["in_supervisor"] = tran.InSupervisor;
 Row["object_performance_report_id"] = tran.ObjectPerformanceReportId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
