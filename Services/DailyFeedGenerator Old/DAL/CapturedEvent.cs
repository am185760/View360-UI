

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
 public class CapturedEvent
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public CapturedEvent() { }
 public CapturedEvent( int captured_keylookup_id,DateTime captured_at,int atm_id,int task_id,long captured_event_index )
 {
 this.captured_keylookup_id = captured_keylookup_id;
 this.captured_keylookup_idChanged = true;
 this.captured_at = captured_at;
 this.captured_atChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.captured_event_index = captured_event_index;
 this.captured_event_indexChanged = true;
 }
 private CapturedEvent( int captured_event_id,int captured_keylookup_id,DateTime captured_at,int atm_id,int task_id,long captured_event_index )
 {
 this.captured_event_id = captured_event_id;
 this.captured_event_idChanged = true;
 this.captured_keylookup_id = captured_keylookup_id;
 this.captured_keylookup_idChanged = true;
 this.captured_at = captured_at;
 this.captured_atChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.captured_event_index = captured_event_index;
 this.captured_event_indexChanged = true;
 }

 #region members and properties for columns

 #region CapturedEventId
 private bool captured_event_idChanged = false;
 private long captured_event_id;
 public long CapturedEventId
 {
 get { return captured_event_id; }
 set { 
captured_event_id = value;
captured_event_idChanged = true;
 }
 }
 private string captured_event_idDbString
 {
 get
 {
 return captured_event_id.ToString();
 }
 }
 #endregion
 #region CapturedKeylookupId
 private bool captured_keylookup_idChanged = false;
 private int captured_keylookup_id;
 public int CapturedKeylookupId
 {
 get { return captured_keylookup_id; }
 set { 
captured_keylookup_id = value;
captured_keylookup_idChanged = true;
 }
 }
 private string captured_keylookup_idDbString
 {
 get
 {
 return captured_keylookup_id.ToString();
 }
 }
 #endregion
 #region CapturedAt
 private bool captured_atChanged = false;
 private DateTime captured_at;
 public DateTime CapturedAt
 {
 get { return captured_at; }
 set { 
captured_at = value;
captured_atChanged = true;
 }
 }
 private string captured_atDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",captured_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
 #region CapturedEventIndex
 private bool captured_event_indexChanged = false;
 private long captured_event_index;
 public long CapturedEventIndex
 {
 get { return captured_event_index; }
 set { 
captured_event_index = value;
captured_event_indexChanged = true;
 }
 }
 private string captured_event_indexDbString
 {
 get
 {
 return captured_event_index.ToString();
 }
 }
 #endregion
 #endregion

 #region CapturedEventReader
 public class CapturedEventReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
CapturedEvent currentCapturedEvent;
 Columns columns;
 bool partialRead = false;
 private CapturedEventReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public CapturedEventReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public CapturedEventReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentCapturedEvent; }

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
 currentCapturedEvent = new CapturedEvent();
 if (partialRead)
 { if ((columns & Columns.captured_event_id) == Columns.captured_event_id && reader["captured_event_id"]!=DBNull.Value)
 currentCapturedEvent.captured_event_id =(int) reader["captured_event_id"]; 
 if ((columns & Columns.captured_keylookup_id) == Columns.captured_keylookup_id && reader["captured_keylookup_id"]!=DBNull.Value)
 currentCapturedEvent.captured_keylookup_id =(int) reader["captured_keylookup_id"]; 
 if ((columns & Columns.captured_at) == Columns.captured_at && reader["captured_at"]!=DBNull.Value)
 currentCapturedEvent.captured_at =(DateTime) reader["captured_at"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentCapturedEvent.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
 currentCapturedEvent.task_id =(int) reader["task_id"]; 
 if ((columns & Columns.captured_event_index) == Columns.captured_event_index && reader["captured_event_index"]!=DBNull.Value)
 currentCapturedEvent.captured_event_index =(int) reader["captured_event_index"]; 

 } else
 {
 if (reader["captured_event_id"] != DBNull.Value)
 currentCapturedEvent.captured_event_id = (int) reader["captured_event_id"]; 
 if (reader["captured_keylookup_id"] != DBNull.Value)
 currentCapturedEvent.captured_keylookup_id = (int) reader["captured_keylookup_id"]; 
 if (reader["captured_at"] != DBNull.Value)
 currentCapturedEvent.captured_at = (DateTime) reader["captured_at"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentCapturedEvent.atm_id = (int) reader["atm_id"]; 
 if (reader["task_id"] != DBNull.Value)
 currentCapturedEvent.task_id = (int) reader["task_id"]; 
 if (reader["captured_event_index"] != DBNull.Value)
 currentCapturedEvent.captured_event_index = (int) reader["captured_event_index"]; 
 } 

 currentCapturedEvent.isNewEntity = false;
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

 public CapturedEvent CurrentCapturedEvent
 {
 get{ return currentCapturedEvent; }
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


 #region CapturedEvent functions

 public static CapturedEventReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.captured_event_id == (Columns.captured_event_id & columns))
 qry.Append("captured_event_id,");
 if (Columns.captured_keylookup_id == (Columns.captured_keylookup_id & columns))
 qry.Append("captured_keylookup_id,");
 if (Columns.captured_at == (Columns.captured_at & columns))
 qry.Append("captured_at,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.task_id == (Columns.task_id & columns))
 qry.Append("task_id,");
 if (Columns.captured_event_index == (Columns.captured_event_index & columns))
 qry.Append("captured_event_index,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Captured_event ");

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
 return new CapturedEventReader(cmd.ExecuteReader(), conn, columns);
 }

 static public CapturedEventReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static CapturedEventReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select captured_event_id,captured_keylookup_id,captured_at,atm_id,task_id,captured_event_index from Captured_event ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new CapturedEventReader(cmd.ExecuteReader(), conn);
 }

 static public CapturedEventReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static CapturedEvent LoadCapturedEvent(string where)
 {
CapturedEventReader reader = CapturedEvent.ExecuteReader(where);
CapturedEvent _capturedevent = null;
 if (reader.Read())
 _capturedevent = reader.CurrentCapturedEvent;
 reader.Close();
 return _capturedevent;
 }

 public static CapturedEvent LoadCapturedEvent(string where, IDbConnection conn)
 {
CapturedEventReader reader = CapturedEvent.ExecuteReader(where, conn);
CapturedEvent _capturedevent = null;
 if (reader.Read())
 _capturedevent = reader.CurrentCapturedEvent;
 reader.Close(false);
 return _capturedevent;
 }

 public static CapturedEvent LoadCapturedEventByPk( int captured_event_id )
 {
 return LoadCapturedEvent( " captured_event_id="+captured_event_id );
 }

 public static CapturedEvent LoadCapturedEventByPk( int captured_event_id , IDbConnection conn)
 {
 return LoadCapturedEvent(" captured_event_id="+captured_event_id , conn);
 }

 public void Save()
 {
 if (captured_event_idChanged || captured_keylookup_idChanged || captured_atChanged || atm_idChanged || task_idChanged || captured_event_indexChanged )
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
 if (captured_event_idChanged || captured_keylookup_idChanged || captured_atChanged || atm_idChanged || task_idChanged || captured_event_indexChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Captured_event( captured_event_id,captured_keylookup_id,captured_at,atm_id,task_id,captured_event_index ) values(");
 lock (ConnectionFactory.connectionString) { this.captured_event_id = ConnectionFactory.GetNextId();
 qry.Append(this.captured_event_id);
 } qry.Append(",");
 qry.Append(captured_keylookup_idDbString+",");
 qry.Append(captured_atDbString+",");
 qry.Append(atm_idDbString+",");
 qry.Append(task_idDbString+",");
 qry.Append(captured_event_indexDbString);
 qry.Append(");");

 }
 else
 {
 if (!(captured_event_idChanged || captured_keylookup_idChanged || captured_atChanged || atm_idChanged || task_idChanged || captured_event_indexChanged ))
 return;
 qry.Append("UPDATE Captured_event set "); if ( captured_keylookup_idChanged )
 {
 qry.Append("captured_keylookup_id ="+captured_keylookup_idDbString);
 qry.Append(",");
 }

 if ( captured_atChanged )
 {
 qry.Append("captured_at ="+captured_atDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( task_idChanged )
 {
 qry.Append("task_id ="+task_idDbString);
 qry.Append(",");
 }

 if ( captured_event_indexChanged )
 {
 qry.Append("captured_event_index ="+captured_event_indexDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("captured_event_id = "+captured_event_idDbString);
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
 cmd.CommandText = "DELETE Captured_event where captured_event_id = "+ captured_event_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteCapturedEvents(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Captured_event where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
captured_event_id= 1,
captured_keylookup_id= 2,
captured_at= 4,
atm_id= 8,
task_id= 16,
captured_event_index= 32
 }
 #endregion
 public void BulkSave(List<CapturedEvent> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Captured_event";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(CapturedEvent.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <CapturedEvent> transList,ref DataTable dt)
 {
 foreach (CapturedEvent tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["captured_event_id"] =ConnectionFactory.GetNextId();
 Row["captured_keylookup_id"] = tran.CapturedKeylookupId;
 Row["captured_at"] = tran.CapturedAt;
 Row["atm_id"] = tran.AtmId;
 Row["task_id"] = tran.TaskId;
 Row["captured_event_index"] = tran.CapturedEventIndex;
 dt.Rows.Add(Row);
 } }
 }
 }

 
