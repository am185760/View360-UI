
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
 public class Incident
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public Incident() { }
 public Incident( int incident_id,int atm_alert_id ) 
 {
 this.atm_alert_id = atm_alert_id;
 this.atm_alert_idChanged = true;
 }
 public Incident( DateTime? creation_time,string mail_subject,string mail_from,string mail_to,DateTime? sent_at,int atm_alert_id )
 {
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.mail_subject = mail_subject;
 this.mail_subjectChanged = true;
 this.mail_from = mail_from;
 this.mail_fromChanged = true;
 this.mail_to = mail_to;
 this.mail_toChanged = true;
 this.sent_at = sent_at;
 this.sent_atChanged = true;
 this.atm_alert_id = atm_alert_id;
 this.atm_alert_idChanged = true;
 }
 private Incident( int incident_id,DateTime? creation_time,string mail_subject,string mail_from,string mail_to,DateTime? sent_at,int atm_alert_id )
 {
 this.incident_id = incident_id;
 this.incident_idChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.mail_subject = mail_subject;
 this.mail_subjectChanged = true;
 this.mail_from = mail_from;
 this.mail_fromChanged = true;
 this.mail_to = mail_to;
 this.mail_toChanged = true;
 this.sent_at = sent_at;
 this.sent_atChanged = true;
 this.atm_alert_id = atm_alert_id;
 this.atm_alert_idChanged = true;
 }

 #region members and properties for columns

 #region IncidentId
 private bool incident_idChanged = false;
 private int incident_id;
 public int IncidentId
 {
 get { return incident_id; }
 set { 
incident_id = value;
incident_idChanged = true;
 }
 }
 private string incident_idDbString
 {
 get
 {
 return incident_id.ToString();
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
 #region MailSubject
 private bool mail_subjectChanged = false;
 private string mail_subject;
 public string MailSubject
 {
 get { return mail_subject; }
 set { 
mail_subject = value;
mail_subjectChanged = true;
 }
 }
 private string mail_subjectDbString
 {
 get
 {
 if (this.mail_subject!=null)
 return string.Format("'{0}'",mail_subject); else
 return "null";
 }
 }
 #endregion
 #region MailFrom
 private bool mail_fromChanged = false;
 private string mail_from;
 public string MailFrom
 {
 get { return mail_from; }
 set { 
mail_from = value;
mail_fromChanged = true;
 }
 }
 private string mail_fromDbString
 {
 get
 {
 if (this.mail_from!=null)
 return string.Format("'{0}'",mail_from); else
 return "null";
 }
 }
 #endregion
 #region MailTo
 private bool mail_toChanged = false;
 private string mail_to;
 public string MailTo
 {
 get { return mail_to; }
 set { 
mail_to = value;
mail_toChanged = true;
 }
 }
 private string mail_toDbString
 {
 get
 {
 if (this.mail_to!=null)
 return string.Format("'{0}'",mail_to); else
 return "null";
 }
 }
 #endregion
 #region SentAt
 private bool sent_atChanged = false;
 private DateTime? sent_at;
 public DateTime? SentAt
 {
 get { return sent_at; }
 set { 
sent_at = value;
sent_atChanged = true;
 }
 }
 private string sent_atDbString
 {
 get
 {
 if (this.sent_at.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",sent_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region AtmAlertId
 private bool atm_alert_idChanged = false;
 private int atm_alert_id;
 public int AtmAlertId
 {
 get { return atm_alert_id; }
 set { 
atm_alert_id = value;
atm_alert_idChanged = true;
 }
 }
 private string atm_alert_idDbString
 {
 get
 {
 return atm_alert_id.ToString();
 }
 }
 #endregion
 #endregion

 #region IncidentReader
 public class IncidentReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
Incident currentIncident;
 Columns columns;
 bool partialRead = false;
 private IncidentReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public IncidentReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public IncidentReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentIncident; }

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
 currentIncident = new Incident();
 if (partialRead)
 { if ((columns & Columns.incident_id) == Columns.incident_id && reader["incident_id"]!=DBNull.Value)
 currentIncident.incident_id =(int) reader["incident_id"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentIncident.creation_time =(DateTime?) reader["creation_time"]; 
 if ((columns & Columns.mail_subject) == Columns.mail_subject && reader["mail_subject"]!=DBNull.Value)
 currentIncident.mail_subject =(string) reader["mail_subject"]; 
 if ((columns & Columns.mail_from) == Columns.mail_from && reader["mail_from"]!=DBNull.Value)
 currentIncident.mail_from =(string) reader["mail_from"]; 
 if ((columns & Columns.mail_to) == Columns.mail_to && reader["mail_to"]!=DBNull.Value)
 currentIncident.mail_to =(string) reader["mail_to"]; 
 if ((columns & Columns.sent_at) == Columns.sent_at && reader["sent_at"]!=DBNull.Value)
 currentIncident.sent_at =(DateTime?) reader["sent_at"]; 
 if ((columns & Columns.atm_alert_id) == Columns.atm_alert_id && reader["atm_alert_id"]!=DBNull.Value)
 currentIncident.atm_alert_id =(int) reader["atm_alert_id"]; 

 } else
 {
 if (reader["incident_id"] != DBNull.Value)
 currentIncident.incident_id = (int) reader["incident_id"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentIncident.creation_time = (DateTime?) reader["creation_time"]; 
 if (reader["mail_subject"] != DBNull.Value)
 currentIncident.mail_subject = (string) reader["mail_subject"]; 
 if (reader["mail_from"] != DBNull.Value)
 currentIncident.mail_from = (string) reader["mail_from"]; 
 if (reader["mail_to"] != DBNull.Value)
 currentIncident.mail_to = (string) reader["mail_to"]; 
 if (reader["sent_at"] != DBNull.Value)
 currentIncident.sent_at = (DateTime?) reader["sent_at"]; 
 if (reader["atm_alert_id"] != DBNull.Value)
 currentIncident.atm_alert_id = (int) reader["atm_alert_id"]; 
 } 

 currentIncident.isNewEntity = false;
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

 public Incident CurrentIncident
 {
 get{ return currentIncident; }
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


 #region Incident functions

 public static IncidentReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.incident_id == (Columns.incident_id & columns))
 qry.Append("incident_id,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.mail_subject == (Columns.mail_subject & columns))
 qry.Append("mail_subject,");
 if (Columns.mail_from == (Columns.mail_from & columns))
 qry.Append("mail_from,");
 if (Columns.mail_to == (Columns.mail_to & columns))
 qry.Append("mail_to,");
 if (Columns.sent_at == (Columns.sent_at & columns))
 qry.Append("sent_at,");
 if (Columns.atm_alert_id == (Columns.atm_alert_id & columns))
 qry.Append("atm_alert_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Incident ");

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
 return new IncidentReader(cmd.ExecuteReader(), conn, columns);
 }

 static public IncidentReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static IncidentReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select incident_id,creation_time,mail_subject,mail_from,mail_to,sent_at,atm_alert_id from Incident ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new IncidentReader(cmd.ExecuteReader(), conn);
 }

 static public IncidentReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static Incident LoadIncident(string where)
 {
IncidentReader reader = Incident.ExecuteReader(where);
Incident _incident = null;
 if (reader.Read())
 _incident = reader.CurrentIncident;
 reader.Close();
 return _incident;
 }

 public static Incident LoadIncident(string where, IDbConnection conn)
 {
IncidentReader reader = Incident.ExecuteReader(where, conn);
Incident _incident = null;
 if (reader.Read())
 _incident = reader.CurrentIncident;
 reader.Close(false);
 return _incident;
 }

 public static Incident LoadIncidentByPk( int incident_id )
 {
 return LoadIncident( " incident_id="+incident_id );
 }

 public static Incident LoadIncidentByPk( int incident_id , IDbConnection conn)
 {
 return LoadIncident(" incident_id="+incident_id , conn);
 }

 public void Save()
 {
 if (incident_idChanged || creation_timeChanged || mail_subjectChanged || mail_fromChanged || mail_toChanged || sent_atChanged || atm_alert_idChanged )
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
 if (incident_idChanged || creation_timeChanged || mail_subjectChanged || mail_fromChanged || mail_toChanged || sent_atChanged || atm_alert_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Incident( incident_id,creation_time,mail_subject,mail_from,mail_to,sent_at,atm_alert_id ) values(");
 lock (ConnectionFactory.connectionString) { this.incident_id = ConnectionFactory.GetNextId();
 qry.Append(this.incident_id);
 } qry.Append(",");
 qry.Append(creation_timeDbString+",");
 qry.Append(mail_subjectDbString+",");
 qry.Append(mail_fromDbString+",");
 qry.Append(mail_toDbString+",");
 qry.Append(sent_atDbString+",");
 qry.Append(atm_alert_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(incident_idChanged || creation_timeChanged || mail_subjectChanged || mail_fromChanged || mail_toChanged || sent_atChanged || atm_alert_idChanged ))
 return;
 qry.Append("UPDATE Incident set "); if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( mail_subjectChanged )
 {
 qry.Append("mail_subject ="+mail_subjectDbString);
 qry.Append(",");
 }

 if ( mail_fromChanged )
 {
 qry.Append("mail_from ="+mail_fromDbString);
 qry.Append(",");
 }

 if ( mail_toChanged )
 {
 qry.Append("mail_to ="+mail_toDbString);
 qry.Append(",");
 }

 if ( sent_atChanged )
 {
 qry.Append("sent_at ="+sent_atDbString);
 qry.Append(",");
 }

 if ( atm_alert_idChanged )
 {
 qry.Append("atm_alert_id ="+atm_alert_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("incident_id = "+incident_idDbString);
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
 cmd.CommandText = "DELETE Incident where incident_id = "+ incident_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteIncidents(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Incident where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
incident_id= 1,
creation_time= 2,
mail_subject= 4,
mail_from= 8,
mail_to= 16,
sent_at= 32,
atm_alert_id= 64
 }
 #endregion
 public void BulkSave(List<Incident> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Incident";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(Incident.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <Incident> transList,ref DataTable dt)
 {
 foreach (Incident tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["incident_id"] =ConnectionFactory.GetNextId();
 Row["creation_time"] = tran.CreationTime;
 Row["mail_subject"] = tran.MailSubject;
 Row["mail_from"] = tran.MailFrom;
 Row["mail_to"] = tran.MailTo;
 Row["sent_at"] = tran.SentAt;
 Row["atm_alert_id"] = tran.AtmAlertId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
