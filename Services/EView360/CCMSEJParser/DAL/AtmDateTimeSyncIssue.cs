

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
 public class AtmDateTimeSyncIssue
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public AtmDateTimeSyncIssue() { }
 public AtmDateTimeSyncIssue( int atm_id,DateTime generated_at,int task_id,DateTime last_date,DateTime new_date )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.generated_at = generated_at;
 this.generated_atChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.last_date = last_date;
 this.last_dateChanged = true;
 this.new_date = new_date;
 this.new_dateChanged = true;
 }
 private AtmDateTimeSyncIssue( int atm_date_time_sync_issue_id,int atm_id,DateTime generated_at,int task_id,DateTime last_date,DateTime new_date )
 {
 this.atm_date_time_sync_issue_id = atm_date_time_sync_issue_id;
 this.atm_date_time_sync_issue_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.generated_at = generated_at;
 this.generated_atChanged = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.last_date = last_date;
 this.last_dateChanged = true;
 this.new_date = new_date;
 this.new_dateChanged = true;
 }

 #region members and properties for columns

 #region AtmDateTimeSyncIssueId
 private bool atm_date_time_sync_issue_idChanged = false;
 private int atm_date_time_sync_issue_id;
 public int AtmDateTimeSyncIssueId
 {
 get { return atm_date_time_sync_issue_id; }
 set { 
atm_date_time_sync_issue_id = value;
atm_date_time_sync_issue_idChanged = true;
 }
 }
 private string atm_date_time_sync_issue_idDbString
 {
 get
 {
 return atm_date_time_sync_issue_id.ToString();
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
 #region GeneratedAt
 private bool generated_atChanged = false;
 private DateTime generated_at;
 public DateTime GeneratedAt
 {
 get { return generated_at; }
 set { 
generated_at = value;
generated_atChanged = true;
 }
 }
 private string generated_atDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
 #region LastDate
 private bool last_dateChanged = false;
 private DateTime last_date;
 public DateTime LastDate
 {
 get { return last_date; }
 set { 
last_date = value;
last_dateChanged = true;
 }
 }
 private string last_dateDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",last_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region NewDate
 private bool new_dateChanged = false;
 private DateTime new_date;
 public DateTime NewDate
 {
 get { return new_date; }
 set { 
new_date = value;
new_dateChanged = true;
 }
 }
 private string new_dateDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",new_date.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #endregion

 #region AtmDateTimeSyncIssueReader
 public class AtmDateTimeSyncIssueReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
AtmDateTimeSyncIssue currentAtmDateTimeSyncIssue;
 Columns columns;
 bool partialRead = false;
 private AtmDateTimeSyncIssueReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public AtmDateTimeSyncIssueReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public AtmDateTimeSyncIssueReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentAtmDateTimeSyncIssue; }

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
 currentAtmDateTimeSyncIssue = new AtmDateTimeSyncIssue();
 if (partialRead)
 { if ((columns & Columns.atm_date_time_sync_issue_id) == Columns.atm_date_time_sync_issue_id && reader["atm_date_time_sync_issue_id"]!=DBNull.Value)
 currentAtmDateTimeSyncIssue.atm_date_time_sync_issue_id =(int) reader["atm_date_time_sync_issue_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentAtmDateTimeSyncIssue.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
 currentAtmDateTimeSyncIssue.generated_at =(DateTime) reader["generated_at"]; 
 if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
 currentAtmDateTimeSyncIssue.task_id =(int) reader["task_id"]; 
 if ((columns & Columns.last_date) == Columns.last_date && reader["last_date"]!=DBNull.Value)
 currentAtmDateTimeSyncIssue.last_date =(DateTime) reader["last_date"]; 
 if ((columns & Columns.new_date) == Columns.new_date && reader["new_date"]!=DBNull.Value)
 currentAtmDateTimeSyncIssue.new_date =(DateTime) reader["new_date"]; 

 } else
 {
 if (reader["atm_date_time_sync_issue_id"] != DBNull.Value)
 currentAtmDateTimeSyncIssue.atm_date_time_sync_issue_id = (int) reader["atm_date_time_sync_issue_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentAtmDateTimeSyncIssue.atm_id = (int) reader["atm_id"]; 
 if (reader["generated_at"] != DBNull.Value)
 currentAtmDateTimeSyncIssue.generated_at = (DateTime) reader["generated_at"]; 
 if (reader["task_id"] != DBNull.Value)
 currentAtmDateTimeSyncIssue.task_id = (int) reader["task_id"]; 
 if (reader["last_date"] != DBNull.Value)
 currentAtmDateTimeSyncIssue.last_date = (DateTime) reader["last_date"]; 
 if (reader["new_date"] != DBNull.Value)
 currentAtmDateTimeSyncIssue.new_date = (DateTime) reader["new_date"]; 
 } 

 currentAtmDateTimeSyncIssue.isNewEntity = false;
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

 public AtmDateTimeSyncIssue CurrentAtmDateTimeSyncIssue
 {
 get{ return currentAtmDateTimeSyncIssue; }
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


 #region AtmDateTimeSyncIssue functions

 public static AtmDateTimeSyncIssueReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.atm_date_time_sync_issue_id == (Columns.atm_date_time_sync_issue_id & columns))
 qry.Append("atm_date_time_sync_issue_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.generated_at == (Columns.generated_at & columns))
 qry.Append("generated_at,");
 if (Columns.task_id == (Columns.task_id & columns))
 qry.Append("task_id,");
 if (Columns.last_date == (Columns.last_date & columns))
 qry.Append("last_date,");
 if (Columns.new_date == (Columns.new_date & columns))
 qry.Append("new_date,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Atm_date_time_sync_issue ");

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
 return new AtmDateTimeSyncIssueReader(cmd.ExecuteReader(), conn, columns);
 }

 static public AtmDateTimeSyncIssueReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static AtmDateTimeSyncIssueReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select atm_date_time_sync_issue_id,atm_id,generated_at,task_id,last_date,new_date from Atm_date_time_sync_issue ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new AtmDateTimeSyncIssueReader(cmd.ExecuteReader(), conn);
 }

 static public AtmDateTimeSyncIssueReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static AtmDateTimeSyncIssue LoadAtmDateTimeSyncIssue(string where)
 {
AtmDateTimeSyncIssueReader reader = AtmDateTimeSyncIssue.ExecuteReader(where);
AtmDateTimeSyncIssue _atmdatetimesyncissue = null;
 if (reader.Read())
 _atmdatetimesyncissue = reader.CurrentAtmDateTimeSyncIssue;
 reader.Close();
 return _atmdatetimesyncissue;
 }

 public static AtmDateTimeSyncIssue LoadAtmDateTimeSyncIssue(string where, IDbConnection conn)
 {
AtmDateTimeSyncIssueReader reader = AtmDateTimeSyncIssue.ExecuteReader(where, conn);
AtmDateTimeSyncIssue _atmdatetimesyncissue = null;
 if (reader.Read())
 _atmdatetimesyncissue = reader.CurrentAtmDateTimeSyncIssue;
 reader.Close(false);
 return _atmdatetimesyncissue;
 }

 public static AtmDateTimeSyncIssue LoadAtmDateTimeSyncIssueByPk( int atm_date_time_sync_issue_id )
 {
 return LoadAtmDateTimeSyncIssue( " atm_date_time_sync_issue_id="+atm_date_time_sync_issue_id );
 }

 public static AtmDateTimeSyncIssue LoadAtmDateTimeSyncIssueByPk( int atm_date_time_sync_issue_id , IDbConnection conn)
 {
 return LoadAtmDateTimeSyncIssue(" atm_date_time_sync_issue_id="+atm_date_time_sync_issue_id , conn);
 }

 public void Save()
 {
 if (atm_date_time_sync_issue_idChanged || atm_idChanged || generated_atChanged || task_idChanged || last_dateChanged || new_dateChanged )
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
 if (atm_date_time_sync_issue_idChanged || atm_idChanged || generated_atChanged || task_idChanged || last_dateChanged || new_dateChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Atm_date_time_sync_issue( atm_date_time_sync_issue_id,atm_id,generated_at,task_id,last_date,new_date ) values(");
 lock (ConnectionFactory.connectionString) { this.atm_date_time_sync_issue_id = ConnectionFactory.GetNextId();
 qry.Append(this.atm_date_time_sync_issue_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(generated_atDbString+",");
 qry.Append(task_idDbString+",");
 qry.Append(last_dateDbString+",");
 qry.Append(new_dateDbString);
 qry.Append(");");

 }
 else
 {
 if (!(atm_date_time_sync_issue_idChanged || atm_idChanged || generated_atChanged || task_idChanged || last_dateChanged || new_dateChanged ))
 return;
 qry.Append("UPDATE Atm_date_time_sync_issue set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( generated_atChanged )
 {
 qry.Append("generated_at ="+generated_atDbString);
 qry.Append(",");
 }

 if ( task_idChanged )
 {
 qry.Append("task_id ="+task_idDbString);
 qry.Append(",");
 }

 if ( last_dateChanged )
 {
 qry.Append("last_date ="+last_dateDbString);
 qry.Append(",");
 }

 if ( new_dateChanged )
 {
 qry.Append("new_date ="+new_dateDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("atm_date_time_sync_issue_id = "+atm_date_time_sync_issue_idDbString);
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
 cmd.CommandText = "DELETE Atm_date_time_sync_issue where atm_date_time_sync_issue_id = "+ atm_date_time_sync_issue_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteAtmDateTimeSyncIssues(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Atm_date_time_sync_issue where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
atm_date_time_sync_issue_id= 1,
atm_id= 2,
generated_at= 4,
task_id= 8,
last_date= 16,
new_date= 32
 }
 #endregion
 public void BulkSave(List<AtmDateTimeSyncIssue> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Atm_date_time_sync_issue";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(AtmDateTimeSyncIssue.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <AtmDateTimeSyncIssue> transList,ref DataTable dt)
 {
 foreach (AtmDateTimeSyncIssue tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["atm_date_time_sync_issue_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["generated_at"] = tran.GeneratedAt;
 Row["task_id"] = tran.TaskId;
 Row["last_date"] = tran.LastDate;
 Row["new_date"] = tran.NewDate;
 dt.Rows.Add(Row);
 } }
 }
 }

 
