
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
 public class EjCapturedCard
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public EjCapturedCard() { }
 public EjCapturedCard( int ej_captured_card_id,int task_id,DateTime capture_time,int atm_id ) 
 {
 this.task_id = task_id;
 this.task_idChanged = true;
 this.capture_time = capture_time;
 this.capture_timeChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }
 public EjCapturedCard( int task_id,string pAN,DateTime capture_time,int? tSN,int atm_id,string capture_reason,DateTime? processing_datetime,string reason,int? start_index,int? end_index )
 {
 this.task_id = task_id;
 this.task_idChanged = true;
 this.pAN = pAN;
 this.pANChanged = true;
 this.capture_time = capture_time;
 this.capture_timeChanged = true;
 this.tSN = tSN;
 this.tSNChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.capture_reason = capture_reason;
 this.capture_reasonChanged = true;
 this.processing_datetime = processing_datetime;
 this.processing_datetimeChanged = true;
 this.reason = reason;
 this.reasonChanged = true;
 this.start_index = start_index;
 this.start_indexChanged = true;
 this.end_index = end_index;
 this.end_indexChanged = true;
 }
 private EjCapturedCard( int ej_captured_card_id,int task_id,string pAN,DateTime capture_time,int? tSN,int atm_id,string capture_reason,DateTime? processing_datetime,string reason,int? start_index,int? end_index )
 {
 this.ej_captured_card_id = ej_captured_card_id;
 this.ej_captured_card_idChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.pAN = pAN;
 this.pANChanged = true;
 this.capture_time = capture_time;
 this.capture_timeChanged = true;
 this.tSN = tSN;
 this.tSNChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.capture_reason = capture_reason;
 this.capture_reasonChanged = true;
 this.processing_datetime = processing_datetime;
 this.processing_datetimeChanged = true;
 this.reason = reason;
 this.reasonChanged = true;
 this.start_index = start_index;
 this.start_indexChanged = true;
 this.end_index = end_index;
 this.end_indexChanged = true;
 }

 #region members and properties for columns

 #region EjCapturedCardId
 private bool ej_captured_card_idChanged = false;
 private int ej_captured_card_id;
 public int EjCapturedCardId
 {
 get { return ej_captured_card_id; }
 set { 
ej_captured_card_id = value;
ej_captured_card_idChanged = true;
 }
 }
 private string ej_captured_card_idDbString
 {
 get
 {
 return ej_captured_card_id.ToString();
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
 #region PAN
 private bool pANChanged = false;
 private string pAN;
 public string PAN
 {
 get { return pAN; }
 set { 
pAN = value;
pANChanged = true;
 }
 }
 private string pANDbString
 {
 get
 {
 if (this.pAN!=null)
 return string.Format("'{0}'",pAN); else
 return "null";
 }
 }
 #endregion
 #region CaptureTime
 private bool capture_timeChanged = false;
 private DateTime capture_time;
 public DateTime CaptureTime
 {
 get { return capture_time; }
 set { 
capture_time = value;
capture_timeChanged = true;
 }
 }
 private string capture_timeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",capture_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region TSN
 private bool tSNChanged = false;
 private int? tSN;
 public int? TSN
 {
 get { return tSN; }
 set { 
tSN = value;
tSNChanged = true;
 }
 }
 private string tSNDbString
 {
 get
 {
 if (this.tSN.HasValue)
 return tSN.ToString();
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
 #region CaptureReason
 private bool capture_reasonChanged = false;
 private string capture_reason;
 public string CaptureReason
 {
 get { return capture_reason; }
 set { 
capture_reason = value;
capture_reasonChanged = true;
 }
 }
 private string capture_reasonDbString
 {
 get
 {
 if (this.capture_reason!=null)
 return string.Format("'{0}'",capture_reason); else
 return "null";
 }
 }
 #endregion
 #region ProcessingDatetime
 private bool processing_datetimeChanged = false;
 private DateTime? processing_datetime;
 public DateTime? ProcessingDatetime
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
 if (this.processing_datetime.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",processing_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
 #region StartIndex
 private bool start_indexChanged = false;
 private int? start_index;
 public int? StartIndex
 {
 get { return start_index; }
 set { 
start_index = value;
start_indexChanged = true;
 }
 }
 private string start_indexDbString
 {
 get
 {
 if (this.start_index.HasValue)
 return start_index.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region EndIndex
 private bool end_indexChanged = false;
 private int? end_index;
 public int? EndIndex
 {
 get { return end_index; }
 set { 
end_index = value;
end_indexChanged = true;
 }
 }
 private string end_indexDbString
 {
 get
 {
 if (this.end_index.HasValue)
 return end_index.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region EjCapturedCardReader
 public class EjCapturedCardReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
EjCapturedCard currentEjCapturedCard;
 Columns columns;
 bool partialRead = false;
 private EjCapturedCardReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public EjCapturedCardReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public EjCapturedCardReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentEjCapturedCard; }

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
 currentEjCapturedCard = new EjCapturedCard();
 if (partialRead)
 { if ((columns & Columns.ej_captured_card_id) == Columns.ej_captured_card_id && reader["ej_captured_card_id"]!=DBNull.Value)
 currentEjCapturedCard.ej_captured_card_id =(int) reader["ej_captured_card_id"]; 
 if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
 currentEjCapturedCard.task_id =(int) reader["task_id"]; 
 if ((columns & Columns.PAN) == Columns.PAN && reader["PAN"]!=DBNull.Value)
 currentEjCapturedCard.pAN =(string) reader["PAN"]; 
 if ((columns & Columns.capture_time) == Columns.capture_time && reader["capture_time"]!=DBNull.Value)
 currentEjCapturedCard.capture_time =(DateTime) reader["capture_time"]; 
 if ((columns & Columns.TSN) == Columns.TSN && reader["TSN"]!=DBNull.Value)
 currentEjCapturedCard.tSN =(int?) reader["TSN"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentEjCapturedCard.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.capture_reason) == Columns.capture_reason && reader["capture_reason"]!=DBNull.Value)
 currentEjCapturedCard.capture_reason =(string) reader["capture_reason"]; 
 if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
 currentEjCapturedCard.processing_datetime =(DateTime?) reader["processing_datetime"]; 
 if ((columns & Columns.reason) == Columns.reason && reader["reason"]!=DBNull.Value)
 currentEjCapturedCard.reason =(string) reader["reason"]; 
 if ((columns & Columns.start_index) == Columns.start_index && reader["start_index"]!=DBNull.Value)
 currentEjCapturedCard.start_index =(int?) reader["start_index"]; 
 if ((columns & Columns.end_index) == Columns.end_index && reader["end_index"]!=DBNull.Value)
 currentEjCapturedCard.end_index =(int?) reader["end_index"]; 

 } else
 {
 if (reader["ej_captured_card_id"] != DBNull.Value)
 currentEjCapturedCard.ej_captured_card_id = (int) reader["ej_captured_card_id"]; 
 if (reader["task_id"] != DBNull.Value)
 currentEjCapturedCard.task_id = (int) reader["task_id"]; 
 if (reader["PAN"] != DBNull.Value)
 currentEjCapturedCard.pAN = (string) reader["PAN"]; 
 if (reader["capture_time"] != DBNull.Value)
 currentEjCapturedCard.capture_time = (DateTime) reader["capture_time"]; 
 if (reader["TSN"] != DBNull.Value)
 currentEjCapturedCard.tSN = (int?) reader["TSN"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentEjCapturedCard.atm_id = (int) reader["atm_id"]; 
 if (reader["capture_reason"] != DBNull.Value)
 currentEjCapturedCard.capture_reason = (string) reader["capture_reason"]; 
 if (reader["processing_datetime"] != DBNull.Value)
 currentEjCapturedCard.processing_datetime = (DateTime?) reader["processing_datetime"]; 
 if (reader["reason"] != DBNull.Value)
 currentEjCapturedCard.reason = (string) reader["reason"]; 
 if (reader["start_index"] != DBNull.Value)
 currentEjCapturedCard.start_index = (int?) reader["start_index"]; 
 if (reader["end_index"] != DBNull.Value)
 currentEjCapturedCard.end_index = (int?) reader["end_index"]; 
 } 

 currentEjCapturedCard.isNewEntity = false;
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

 public EjCapturedCard CurrentEjCapturedCard
 {
 get{ return currentEjCapturedCard; }
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


 #region EjCapturedCard functions

 public static EjCapturedCardReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.ej_captured_card_id == (Columns.ej_captured_card_id & columns))
 qry.Append("ej_captured_card_id,");
 if (Columns.task_id == (Columns.task_id & columns))
 qry.Append("task_id,");
 if (Columns.PAN == (Columns.PAN & columns))
 qry.Append("PAN,");
 if (Columns.capture_time == (Columns.capture_time & columns))
 qry.Append("capture_time,");
 if (Columns.TSN == (Columns.TSN & columns))
 qry.Append("TSN,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.capture_reason == (Columns.capture_reason & columns))
 qry.Append("capture_reason,");
 if (Columns.processing_datetime == (Columns.processing_datetime & columns))
 qry.Append("processing_datetime,");
 if (Columns.reason == (Columns.reason & columns))
 qry.Append("reason,");
 if (Columns.start_index == (Columns.start_index & columns))
 qry.Append("start_index,");
 if (Columns.end_index == (Columns.end_index & columns))
 qry.Append("end_index,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Ej_captured_card ");

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
 return new EjCapturedCardReader(cmd.ExecuteReader(), conn, columns);
 }

 static public EjCapturedCardReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static EjCapturedCardReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select ej_captured_card_id,task_id,PAN,capture_time,TSN,atm_id,capture_reason,processing_datetime,reason,start_index,end_index from Ej_captured_card ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new EjCapturedCardReader(cmd.ExecuteReader(), conn);
 }

 static public EjCapturedCardReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static EjCapturedCard LoadEjCapturedCard(string where)
 {
EjCapturedCardReader reader = EjCapturedCard.ExecuteReader(where);
EjCapturedCard _ejcapturedcard = null;
 if (reader.Read())
 _ejcapturedcard = reader.CurrentEjCapturedCard;
 reader.Close();
 return _ejcapturedcard;
 }

 public static EjCapturedCard LoadEjCapturedCard(string where, IDbConnection conn)
 {
EjCapturedCardReader reader = EjCapturedCard.ExecuteReader(where, conn);
EjCapturedCard _ejcapturedcard = null;
 if (reader.Read())
 _ejcapturedcard = reader.CurrentEjCapturedCard;
 reader.Close(false);
 return _ejcapturedcard;
 }

 public static EjCapturedCard LoadEjCapturedCardByPk( int ej_captured_card_id )
 {
 return LoadEjCapturedCard( " ej_captured_card_id="+ej_captured_card_id );
 }

 public static EjCapturedCard LoadEjCapturedCardByPk( int ej_captured_card_id , IDbConnection conn)
 {
 return LoadEjCapturedCard(" ej_captured_card_id="+ej_captured_card_id , conn);
 }

 public void Save()
 {
 if (ej_captured_card_idChanged || task_idChanged || pANChanged || capture_timeChanged || tSNChanged || atm_idChanged || capture_reasonChanged || processing_datetimeChanged || reasonChanged || start_indexChanged || end_indexChanged )
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
 if (ej_captured_card_idChanged || task_idChanged || pANChanged || capture_timeChanged || tSNChanged || atm_idChanged || capture_reasonChanged || processing_datetimeChanged || reasonChanged || start_indexChanged || end_indexChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Ej_captured_card( ej_captured_card_id,task_id,PAN,capture_time,TSN,atm_id,capture_reason,processing_datetime,reason,start_index,end_index ) values(");
 lock (ConnectionFactory.connectionString) { this.ej_captured_card_id = ConnectionFactory.GetNextId();
 qry.Append(this.ej_captured_card_id);
 } qry.Append(",");
 qry.Append(task_idDbString+",");
 qry.Append(pANDbString+",");
 qry.Append(capture_timeDbString+",");
 qry.Append(tSNDbString+",");
 qry.Append(atm_idDbString+",");
 qry.Append(capture_reasonDbString+",");
 qry.Append(processing_datetimeDbString+",");
 qry.Append(reasonDbString+",");
 qry.Append(start_indexDbString+",");
 qry.Append(end_indexDbString);
 qry.Append(");");

 }
 else
 {
 if (!(ej_captured_card_idChanged || task_idChanged || pANChanged || capture_timeChanged || tSNChanged || atm_idChanged || capture_reasonChanged || processing_datetimeChanged || reasonChanged || start_indexChanged || end_indexChanged ))
 return;
 qry.Append("UPDATE Ej_captured_card set "); if ( task_idChanged )
 {
 qry.Append("task_id ="+task_idDbString);
 qry.Append(",");
 }

 if ( pANChanged )
 {
 qry.Append("PAN ="+pANDbString);
 qry.Append(",");
 }

 if ( capture_timeChanged )
 {
 qry.Append("capture_time ="+capture_timeDbString);
 qry.Append(",");
 }

 if ( tSNChanged )
 {
 qry.Append("TSN ="+tSNDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( capture_reasonChanged )
 {
 qry.Append("capture_reason ="+capture_reasonDbString);
 qry.Append(",");
 }

 if ( processing_datetimeChanged )
 {
 qry.Append("processing_datetime ="+processing_datetimeDbString);
 qry.Append(",");
 }

 if ( reasonChanged )
 {
 qry.Append("reason ="+reasonDbString);
 qry.Append(",");
 }

 if ( start_indexChanged )
 {
 qry.Append("start_index ="+start_indexDbString);
 qry.Append(",");
 }

 if ( end_indexChanged )
 {
 qry.Append("end_index ="+end_indexDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("ej_captured_card_id = "+ej_captured_card_idDbString);
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
 cmd.CommandText = "DELETE Ej_captured_card where ej_captured_card_id = "+ ej_captured_card_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteEjCapturedCards(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Ej_captured_card where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
ej_captured_card_id= 1,
task_id= 2,
PAN= 4,
capture_time= 8,
TSN= 16,
atm_id= 32,
capture_reason= 64,
processing_datetime= 128,
reason= 256,
start_index= 512,
end_index= 1024
 }
 #endregion
 public void BulkSave(List<EjCapturedCard> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Ej_captured_card";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(EjCapturedCard.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <EjCapturedCard> transList,ref DataTable dt)
 {
 foreach (EjCapturedCard tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["ej_captured_card_id"] =ConnectionFactory.GetNextId();
 Row["task_id"] = tran.TaskId;
 Row["pAN"] = tran.PAN;
 Row["capture_time"] = tran.CaptureTime;
 Row["tSN"] = tran.TSN;
 Row["atm_id"] = tran.AtmId;
 Row["capture_reason"] = tran.CaptureReason;
 Row["processing_datetime"] = tran.ProcessingDatetime;
 Row["reason"] = tran.Reason;
 Row["start_index"] = tran.StartIndex;
 Row["end_index"] = tran.EndIndex;
 dt.Rows.Add(Row);
 } }
 }
 }

 
