
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
 public class GasperTicket
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public GasperTicket() { }
 public GasperTicket( int gasper_ticket_id,int atm_id ) 
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }
 public GasperTicket( string title,DateTime? start_date,DateTime? end_date,int atm_id,int? ticket_id,string reason,string branch_name,string address_1,string city,string object_type_description,string location_type,int? status_code_key,string status_description,string shared_comment,string service_team,decimal? total_ticket_duration,string id2 )
 {
 this.title = title;
 this.titleChanged = true;
 this.start_date = start_date;
 this.start_dateChanged = true;
 this.end_date = end_date;
 this.end_dateChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.ticket_id = ticket_id;
 this.ticket_idChanged = true;
 this.reason = reason;
 this.reasonChanged = true;
 this.branch_name = branch_name;
 this.branch_nameChanged = true;
 this.address_1 = address_1;
 this.address_1Changed = true;
 this.city = city;
 this.cityChanged = true;
 this.object_type_description = object_type_description;
 this.object_type_descriptionChanged = true;
 this.location_type = location_type;
 this.location_typeChanged = true;
 this.status_code_key = status_code_key;
 this.status_code_keyChanged = true;
 this.status_description = status_description;
 this.status_descriptionChanged = true;
 this.shared_comment = shared_comment;
 this.shared_commentChanged = true;
 this.service_team = service_team;
 this.service_teamChanged = true;
 this.total_ticket_duration = total_ticket_duration;
 this.total_ticket_durationChanged = true;
 this.id2 = id2;
 this.id2Changed = true;
 }
 private GasperTicket( int gasper_ticket_id,string title,DateTime? start_date,DateTime? end_date,int atm_id,int? ticket_id,string reason,string branch_name,string address_1,string city,string object_type_description,string location_type,int? status_code_key,string status_description,string shared_comment,string service_team,decimal? total_ticket_duration,string id2 )
 {
 this.gasper_ticket_id = gasper_ticket_id;
 this.gasper_ticket_idChanged = true;
 this.title = title;
 this.titleChanged = true;
 this.start_date = start_date;
 this.start_dateChanged = true;
 this.end_date = end_date;
 this.end_dateChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.ticket_id = ticket_id;
 this.ticket_idChanged = true;
 this.reason = reason;
 this.reasonChanged = true;
 this.branch_name = branch_name;
 this.branch_nameChanged = true;
 this.address_1 = address_1;
 this.address_1Changed = true;
 this.city = city;
 this.cityChanged = true;
 this.object_type_description = object_type_description;
 this.object_type_descriptionChanged = true;
 this.location_type = location_type;
 this.location_typeChanged = true;
 this.status_code_key = status_code_key;
 this.status_code_keyChanged = true;
 this.status_description = status_description;
 this.status_descriptionChanged = true;
 this.shared_comment = shared_comment;
 this.shared_commentChanged = true;
 this.service_team = service_team;
 this.service_teamChanged = true;
 this.total_ticket_duration = total_ticket_duration;
 this.total_ticket_durationChanged = true;
 this.id2 = id2;
 this.id2Changed = true;
 }

 #region members and properties for columns

 #region GasperTicketId
 private bool gasper_ticket_idChanged = false;
 private int gasper_ticket_id;
 public int GasperTicketId
 {
 get { return gasper_ticket_id; }
 set { 
gasper_ticket_id = value;
gasper_ticket_idChanged = true;
 }
 }
 private string gasper_ticket_idDbString
 {
 get
 {
 return gasper_ticket_id.ToString();
 }
 }
 #endregion
 #region Title
 private bool titleChanged = false;
 private string title;
 public string Title
 {
 get { return title; }
 set { 
title = value;
titleChanged = true;
 }
 }
 private string titleDbString
 {
 get
 {
 if (this.title!=null)
 return string.Format("'{0}'",title); else
 return "null";
 }
 }
 #endregion
 #region StartDate
 private bool start_dateChanged = false;
 private DateTime? start_date;
 public DateTime? StartDate
 {
 get { return start_date; }
 set { 
start_date = value;
start_dateChanged = true;
 }
 }
 private string start_dateDbString
 {
 get
 {
 if (this.start_date.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",start_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region EndDate
 private bool end_dateChanged = false;
 private DateTime? end_date;
 public DateTime? EndDate
 {
 get { return end_date; }
 set { 
end_date = value;
end_dateChanged = true;
 }
 }
 private string end_dateDbString
 {
 get
 {
 if (this.end_date.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",end_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
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
 #region TicketId
 private bool ticket_idChanged = false;
 private int? ticket_id;
 public int? TicketId
 {
 get { return ticket_id; }
 set { 
ticket_id = value;
ticket_idChanged = true;
 }
 }
 private string ticket_idDbString
 {
 get
 {
 if (this.ticket_id.HasValue)
 return ticket_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Reason
 private bool reasonChanged = false;
 private string reason;
 public string Reason
 {
 get { return reason; }
 set { 
reason = value;
reasonChanged = true;
 }
 }
 private string reasonDbString
 {
 get
 {
 if (this.reason!=null)
 return string.Format("'{0}'",reason); else
 return "null";
 }
 }
 #endregion
 #region BranchName
 private bool branch_nameChanged = false;
 private string branch_name;
 public string BranchName
 {
 get { return branch_name; }
 set { 
branch_name = value;
branch_nameChanged = true;
 }
 }
 private string branch_nameDbString
 {
 get
 {
 if (this.branch_name!=null)
 return string.Format("'{0}'",branch_name); else
 return "null";
 }
 }
 #endregion
 #region Address1
 private bool address_1Changed = false;
 private string address_1;
 public string Address1
 {
 get { return address_1; }
 set { 
address_1 = value;
address_1Changed = true;
 }
 }
 private string address_1DbString
 {
 get
 {
 if (this.address_1!=null)
 return string.Format("'{0}'",address_1); else
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
 #region ObjectTypeDescription
 private bool object_type_descriptionChanged = false;
 private string object_type_description;
 public string ObjectTypeDescription
 {
 get { return object_type_description; }
 set { 
object_type_description = value;
object_type_descriptionChanged = true;
 }
 }
 private string object_type_descriptionDbString
 {
 get
 {
 if (this.object_type_description!=null)
 return string.Format("'{0}'",object_type_description); else
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
 #region StatusCodeKey
 private bool status_code_keyChanged = false;
 private int? status_code_key;
 public int? StatusCodeKey
 {
 get { return status_code_key; }
 set { 
status_code_key = value;
status_code_keyChanged = true;
 }
 }
 private string status_code_keyDbString
 {
 get
 {
 if (this.status_code_key.HasValue)
 return status_code_key.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region StatusDescription
 private bool status_descriptionChanged = false;
 private string status_description;
 public string StatusDescription
 {
 get { return status_description; }
 set { 
status_description = value;
status_descriptionChanged = true;
 }
 }
 private string status_descriptionDbString
 {
 get
 {
 if (this.status_description!=null)
 return string.Format("'{0}'",status_description); else
 return "null";
 }
 }
 #endregion
 #region SharedComment
 private bool shared_commentChanged = false;
 private string shared_comment;
 public string SharedComment
 {
 get { return shared_comment; }
 set { 
shared_comment = value;
shared_commentChanged = true;
 }
 }
 private string shared_commentDbString
 {
 get
 {
 if (this.shared_comment!=null)
 return string.Format("'{0}'",shared_comment); else
 return "null";
 }
 }
 #endregion
 #region ServiceTeam
 private bool service_teamChanged = false;
 private string service_team;
 public string ServiceTeam
 {
 get { return service_team; }
 set { 
service_team = value;
service_teamChanged = true;
 }
 }
 private string service_teamDbString
 {
 get
 {
 if (this.service_team!=null)
 return string.Format("'{0}'",service_team); else
 return "null";
 }
 }
 #endregion
 #region TotalTicketDuration
 private bool total_ticket_durationChanged = false;
 private decimal? total_ticket_duration;
 public decimal? TotalTicketDuration
 {
 get { return total_ticket_duration; }
 set { 
total_ticket_duration = value;
total_ticket_durationChanged = true;
 }
 }
 private string total_ticket_durationDbString
 {
 get
 {
 if (this.total_ticket_duration.HasValue)
 return total_ticket_duration.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region Id2
 private bool id2Changed = false;
 private string id2;
 public string Id2
 {
 get { return id2; }
 set { 
id2 = value;
id2Changed = true;
 }
 }
 private string id2DbString
 {
 get
 {
 if (this.id2!=null)
 return string.Format("'{0}'",id2); else
 return "null";
 }
 }
 #endregion
 #endregion

 #region GasperTicketReader
 public class GasperTicketReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
GasperTicket currentGasperTicket;
 Columns columns;
 bool partialRead = false;
 private GasperTicketReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public GasperTicketReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public GasperTicketReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentGasperTicket; }

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
 currentGasperTicket = new GasperTicket();
 if (partialRead)
 { if ((columns & Columns.gasper_ticket_id) == Columns.gasper_ticket_id && reader["gasper_ticket_id"]!=DBNull.Value)
 currentGasperTicket.gasper_ticket_id =(int) reader["gasper_ticket_id"]; 
 if ((columns & Columns.title) == Columns.title && reader["title"]!=DBNull.Value)
 currentGasperTicket.title =(string) reader["title"]; 
 if ((columns & Columns.start_date) == Columns.start_date && reader["start_date"]!=DBNull.Value)
 currentGasperTicket.start_date =(DateTime?) reader["start_date"]; 
 if ((columns & Columns.end_date) == Columns.end_date && reader["end_date"]!=DBNull.Value)
 currentGasperTicket.end_date =(DateTime?) reader["end_date"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentGasperTicket.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.ticket_id) == Columns.ticket_id && reader["ticket_id"]!=DBNull.Value)
 currentGasperTicket.ticket_id =(int?) reader["ticket_id"]; 
 if ((columns & Columns.Reason) == Columns.Reason && reader["Reason"]!=DBNull.Value)
 currentGasperTicket.reason =(string) reader["Reason"]; 
 if ((columns & Columns.branch_name) == Columns.branch_name && reader["branch_name"]!=DBNull.Value)
 currentGasperTicket.branch_name =(string) reader["branch_name"]; 
 if ((columns & Columns.address_1) == Columns.address_1 && reader["address_1"]!=DBNull.Value)
 currentGasperTicket.address_1 =(string) reader["address_1"]; 
 if ((columns & Columns.city) == Columns.city && reader["city"]!=DBNull.Value)
 currentGasperTicket.city =(string) reader["city"]; 
 if ((columns & Columns.object_type_description) == Columns.object_type_description && reader["object_type_description"]!=DBNull.Value)
 currentGasperTicket.object_type_description =(string) reader["object_type_description"]; 
 if ((columns & Columns.location_type) == Columns.location_type && reader["location_type"]!=DBNull.Value)
 currentGasperTicket.location_type =(string) reader["location_type"]; 
 if ((columns & Columns.status_code_key) == Columns.status_code_key && reader["status_code_key"]!=DBNull.Value)
 currentGasperTicket.status_code_key =(int?) reader["status_code_key"]; 
 if ((columns & Columns.status_description) == Columns.status_description && reader["status_description"]!=DBNull.Value)
 currentGasperTicket.status_description =(string) reader["status_description"]; 
 if ((columns & Columns.shared_comment) == Columns.shared_comment && reader["shared_comment"]!=DBNull.Value)
 currentGasperTicket.shared_comment =(string) reader["shared_comment"]; 
 if ((columns & Columns.service_team) == Columns.service_team && reader["service_team"]!=DBNull.Value)
 currentGasperTicket.service_team =(string) reader["service_team"]; 
 if ((columns & Columns.total_ticket_duration) == Columns.total_ticket_duration && reader["total_ticket_duration"]!=DBNull.Value)
 currentGasperTicket.total_ticket_duration =(decimal?) reader["total_ticket_duration"]; 
 if ((columns & Columns.id2) == Columns.id2 && reader["id2"]!=DBNull.Value)
 currentGasperTicket.id2 =(string) reader["id2"]; 

 } else
 {
 if (reader["gasper_ticket_id"] != DBNull.Value)
 currentGasperTicket.gasper_ticket_id = (int) reader["gasper_ticket_id"]; 
 if (reader["title"] != DBNull.Value)
 currentGasperTicket.title = (string) reader["title"]; 
 if (reader["start_date"] != DBNull.Value)
 currentGasperTicket.start_date = (DateTime?) reader["start_date"]; 
 if (reader["end_date"] != DBNull.Value)
 currentGasperTicket.end_date = (DateTime?) reader["end_date"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentGasperTicket.atm_id = (int) reader["atm_id"]; 
 if (reader["ticket_id"] != DBNull.Value)
 currentGasperTicket.ticket_id = (int?) reader["ticket_id"]; 
 if (reader["Reason"] != DBNull.Value)
 currentGasperTicket.reason = (string) reader["Reason"]; 
 if (reader["branch_name"] != DBNull.Value)
 currentGasperTicket.branch_name = (string) reader["branch_name"]; 
 if (reader["address_1"] != DBNull.Value)
 currentGasperTicket.address_1 = (string) reader["address_1"]; 
 if (reader["city"] != DBNull.Value)
 currentGasperTicket.city = (string) reader["city"]; 
 if (reader["object_type_description"] != DBNull.Value)
 currentGasperTicket.object_type_description = (string) reader["object_type_description"]; 
 if (reader["location_type"] != DBNull.Value)
 currentGasperTicket.location_type = (string) reader["location_type"]; 
 if (reader["status_code_key"] != DBNull.Value)
 currentGasperTicket.status_code_key = (int?) reader["status_code_key"]; 
 if (reader["status_description"] != DBNull.Value)
 currentGasperTicket.status_description = (string) reader["status_description"]; 
 if (reader["shared_comment"] != DBNull.Value)
 currentGasperTicket.shared_comment = (string) reader["shared_comment"]; 
 if (reader["service_team"] != DBNull.Value)
 currentGasperTicket.service_team = (string) reader["service_team"]; 
 if (reader["total_ticket_duration"] != DBNull.Value)
 currentGasperTicket.total_ticket_duration = (decimal?) reader["total_ticket_duration"]; 
 if (reader["id2"] != DBNull.Value)
 currentGasperTicket.id2 = (string) reader["id2"]; 
 } 

 currentGasperTicket.isNewEntity = false;
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

 public GasperTicket CurrentGasperTicket
 {
 get{ return currentGasperTicket; }
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


 #region GasperTicket functions

 public static GasperTicketReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.gasper_ticket_id == (Columns.gasper_ticket_id & columns))
 qry.Append("gasper_ticket_id,");
 if (Columns.title == (Columns.title & columns))
 qry.Append("title,");
 if (Columns.start_date == (Columns.start_date & columns))
 qry.Append("start_date,");
 if (Columns.end_date == (Columns.end_date & columns))
 qry.Append("end_date,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.ticket_id == (Columns.ticket_id & columns))
 qry.Append("ticket_id,");
 if (Columns.Reason == (Columns.Reason & columns))
 qry.Append("Reason,");
 if (Columns.branch_name == (Columns.branch_name & columns))
 qry.Append("branch_name,");
 if (Columns.address_1 == (Columns.address_1 & columns))
 qry.Append("address_1,");
 if (Columns.city == (Columns.city & columns))
 qry.Append("city,");
 if (Columns.object_type_description == (Columns.object_type_description & columns))
 qry.Append("object_type_description,");
 if (Columns.location_type == (Columns.location_type & columns))
 qry.Append("location_type,");
 if (Columns.status_code_key == (Columns.status_code_key & columns))
 qry.Append("status_code_key,");
 if (Columns.status_description == (Columns.status_description & columns))
 qry.Append("status_description,");
 if (Columns.shared_comment == (Columns.shared_comment & columns))
 qry.Append("shared_comment,");
 if (Columns.service_team == (Columns.service_team & columns))
 qry.Append("service_team,");
 if (Columns.total_ticket_duration == (Columns.total_ticket_duration & columns))
 qry.Append("total_ticket_duration,");
 if (Columns.id2 == (Columns.id2 & columns))
 qry.Append("id2,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Gasper_ticket ");

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
 return new GasperTicketReader(cmd.ExecuteReader(), conn, columns);
 }

 static public GasperTicketReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static GasperTicketReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select gasper_ticket_id,title,start_date,end_date,atm_id,ticket_id,Reason,branch_name,address_1,city,object_type_description,location_type,status_code_key,status_description,shared_comment,service_team,total_ticket_duration,id2 from Gasper_ticket ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new GasperTicketReader(cmd.ExecuteReader(), conn);
 }

 static public GasperTicketReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static GasperTicket LoadGasperTicket(string where)
 {
GasperTicketReader reader = GasperTicket.ExecuteReader(where);
GasperTicket _gasperticket = null;
 if (reader.Read())
 _gasperticket = reader.CurrentGasperTicket;
 reader.Close();
 return _gasperticket;
 }

 public static GasperTicket LoadGasperTicket(string where, IDbConnection conn)
 {
GasperTicketReader reader = GasperTicket.ExecuteReader(where, conn);
GasperTicket _gasperticket = null;
 if (reader.Read())
 _gasperticket = reader.CurrentGasperTicket;
 reader.Close(false);
 return _gasperticket;
 }

 public static GasperTicket LoadGasperTicketByPk( int gasper_ticket_id )
 {
 return LoadGasperTicket( " gasper_ticket_id="+gasper_ticket_id );
 }

 public static GasperTicket LoadGasperTicketByPk( int gasper_ticket_id , IDbConnection conn)
 {
 return LoadGasperTicket(" gasper_ticket_id="+gasper_ticket_id , conn);
 }

 public void Save()
 {
 if (gasper_ticket_idChanged || titleChanged || start_dateChanged || end_dateChanged || atm_idChanged || ticket_idChanged || reasonChanged || branch_nameChanged || address_1Changed || cityChanged || object_type_descriptionChanged || location_typeChanged || status_code_keyChanged || status_descriptionChanged || shared_commentChanged || service_teamChanged || total_ticket_durationChanged || id2Changed )
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
 if (gasper_ticket_idChanged || titleChanged || start_dateChanged || end_dateChanged || atm_idChanged || ticket_idChanged || reasonChanged || branch_nameChanged || address_1Changed || cityChanged || object_type_descriptionChanged || location_typeChanged || status_code_keyChanged || status_descriptionChanged || shared_commentChanged || service_teamChanged || total_ticket_durationChanged || id2Changed )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Gasper_ticket( gasper_ticket_id,title,start_date,end_date,atm_id,ticket_id,Reason,branch_name,address_1,city,object_type_description,location_type,status_code_key,status_description,shared_comment,service_team,total_ticket_duration,id2 ) values(");
 lock (ConnectionFactory.connectionString) { this.gasper_ticket_id = ConnectionFactory.GetNextId();
 qry.Append(this.gasper_ticket_id);
 } qry.Append(",");
 qry.Append(titleDbString+",");
 qry.Append(start_dateDbString+",");
 qry.Append(end_dateDbString+",");
 qry.Append(atm_idDbString+",");
 qry.Append(ticket_idDbString+",");
 qry.Append(reasonDbString+",");
 qry.Append(branch_nameDbString+",");
 qry.Append(address_1DbString+",");
 qry.Append(cityDbString+",");
 qry.Append(object_type_descriptionDbString+",");
 qry.Append(location_typeDbString+",");
 qry.Append(status_code_keyDbString+",");
 qry.Append(status_descriptionDbString+",");
 qry.Append(shared_commentDbString+",");
 qry.Append(service_teamDbString+",");
 qry.Append(total_ticket_durationDbString+",");
 qry.Append(id2DbString);
 qry.Append(");");

 }
 else
 {
 if (!(gasper_ticket_idChanged || titleChanged || start_dateChanged || end_dateChanged || atm_idChanged || ticket_idChanged || reasonChanged || branch_nameChanged || address_1Changed || cityChanged || object_type_descriptionChanged || location_typeChanged || status_code_keyChanged || status_descriptionChanged || shared_commentChanged || service_teamChanged || total_ticket_durationChanged || id2Changed ))
 return;
 qry.Append("UPDATE Gasper_ticket set "); if ( titleChanged )
 {
 qry.Append("title ="+titleDbString);
 qry.Append(",");
 }

 if ( start_dateChanged )
 {
 qry.Append("start_date ="+start_dateDbString);
 qry.Append(",");
 }

 if ( end_dateChanged )
 {
 qry.Append("end_date ="+end_dateDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( ticket_idChanged )
 {
 qry.Append("ticket_id ="+ticket_idDbString);
 qry.Append(",");
 }

 if ( reasonChanged )
 {
 qry.Append("Reason ="+reasonDbString);
 qry.Append(",");
 }

 if ( branch_nameChanged )
 {
 qry.Append("branch_name ="+branch_nameDbString);
 qry.Append(",");
 }

 if ( address_1Changed )
 {
 qry.Append("address_1 ="+address_1DbString);
 qry.Append(",");
 }

 if ( cityChanged )
 {
 qry.Append("city ="+cityDbString);
 qry.Append(",");
 }

 if ( object_type_descriptionChanged )
 {
 qry.Append("object_type_description ="+object_type_descriptionDbString);
 qry.Append(",");
 }

 if ( location_typeChanged )
 {
 qry.Append("location_type ="+location_typeDbString);
 qry.Append(",");
 }

 if ( status_code_keyChanged )
 {
 qry.Append("status_code_key ="+status_code_keyDbString);
 qry.Append(",");
 }

 if ( status_descriptionChanged )
 {
 qry.Append("status_description ="+status_descriptionDbString);
 qry.Append(",");
 }

 if ( shared_commentChanged )
 {
 qry.Append("shared_comment ="+shared_commentDbString);
 qry.Append(",");
 }

 if ( service_teamChanged )
 {
 qry.Append("service_team ="+service_teamDbString);
 qry.Append(",");
 }

 if ( total_ticket_durationChanged )
 {
 qry.Append("total_ticket_duration ="+total_ticket_durationDbString);
 qry.Append(",");
 }

 if ( id2Changed )
 {
 qry.Append("id2 ="+id2DbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("gasper_ticket_id = "+gasper_ticket_idDbString);
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
 cmd.CommandText = "DELETE Gasper_ticket where gasper_ticket_id = "+ gasper_ticket_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteGasperTickets(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Gasper_ticket where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
gasper_ticket_id= 1,
title= 2,
start_date= 4,
end_date= 8,
atm_id= 16,
ticket_id= 32,
Reason= 64,
branch_name= 128,
address_1= 256,
city= 512,
object_type_description= 1024,
location_type= 2048,
status_code_key= 4096,
status_description= 8192,
shared_comment= 16384,
service_team= 32768,
total_ticket_duration= 65536,
id2= 131072
 }
 #endregion
 public void BulkSave(List<GasperTicket> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Gasper_ticket";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(GasperTicket.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <GasperTicket> transList,ref DataTable dt)
 {
 foreach (GasperTicket tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["gasper_ticket_id"] =ConnectionFactory.GetNextId();
 Row["title"] = tran.Title;
 Row["start_date"] = tran.StartDate;
 Row["end_date"] = tran.EndDate;
 Row["atm_id"] = tran.AtmId;
 Row["ticket_id"] = tran.TicketId;
 Row["reason"] = tran.Reason;
 Row["branch_name"] = tran.BranchName;
 Row["address_1"] = tran.Address1;
 Row["city"] = tran.City;
 Row["object_type_description"] = tran.ObjectTypeDescription;
 Row["location_type"] = tran.LocationType;
 Row["status_code_key"] = tran.StatusCodeKey;
 Row["status_description"] = tran.StatusDescription;
 Row["shared_comment"] = tran.SharedComment;
 Row["service_team"] = tran.ServiceTeam;
 Row["total_ticket_duration"] = tran.TotalTicketDuration;
 Row["id2"] = tran.Id2;
 dt.Rows.Add(Row);
 } }
 }
 }

 
