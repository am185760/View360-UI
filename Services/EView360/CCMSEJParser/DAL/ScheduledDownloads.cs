
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
 public class ScheduledDownloads
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ScheduledDownloads() { }
 public ScheduledDownloads( int aTM_id,int file_type_id )
 {
 this.aTM_id = aTM_id;
 this.aTM_idChanged = true;
 this.file_type_id = file_type_id;
 this.file_type_idChanged = true;
 }
 private ScheduledDownloads( int aTM_id,int file_type_id,int scheduled_downloads_id )
 {
 this.aTM_id = aTM_id;
 this.aTM_idChanged = true;
 this.file_type_id = file_type_id;
 this.file_type_idChanged = true;
 this.scheduled_downloads_id = scheduled_downloads_id;
 this.scheduled_downloads_idChanged = true;
 }

 #region members and properties for columns

 #region ATMId
 private bool aTM_idChanged = false;
 private int aTM_id;
 public int ATMId
 {
 get { return aTM_id; }
 set { 
aTM_id = value;
aTM_idChanged = true;
 }
 }
 private string aTM_idDbString
 {
 get
 {
 return aTM_id.ToString();
 }
 }
 #endregion
 #region FileTypeId
 private bool file_type_idChanged = false;
 private int file_type_id;
 public int FileTypeId
 {
 get { return file_type_id; }
 set { 
file_type_id = value;
file_type_idChanged = true;
 }
 }
 private string file_type_idDbString
 {
 get
 {
 return file_type_id.ToString();
 }
 }
 #endregion
 #region ScheduledDownloadsId
 private bool scheduled_downloads_idChanged = false;
 private int scheduled_downloads_id;
 public int ScheduledDownloadsId
 {
 get { return scheduled_downloads_id; }
 set { 
scheduled_downloads_id = value;
scheduled_downloads_idChanged = true;
 }
 }
 private string scheduled_downloads_idDbString
 {
 get
 {
 return scheduled_downloads_id.ToString();
 }
 }
 #endregion
 #endregion

 #region ScheduledDownloadsReader
 public class ScheduledDownloadsReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ScheduledDownloads currentScheduledDownloads;
 Columns columns;
 bool partialRead = false;
 private ScheduledDownloadsReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ScheduledDownloadsReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ScheduledDownloadsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentScheduledDownloads; }

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
 currentScheduledDownloads = new ScheduledDownloads();
 if (partialRead)
 { if ((columns & Columns.ATM_id) == Columns.ATM_id && reader["ATM_id"]!=DBNull.Value)
 currentScheduledDownloads.aTM_id =(int) reader["ATM_id"]; 
 if ((columns & Columns.file_type_id) == Columns.file_type_id && reader["file_type_id"]!=DBNull.Value)
 currentScheduledDownloads.file_type_id =(int) reader["file_type_id"]; 
 if ((columns & Columns.scheduled_downloads_id) == Columns.scheduled_downloads_id && reader["scheduled_downloads_id"]!=DBNull.Value)
 currentScheduledDownloads.scheduled_downloads_id =(int) reader["scheduled_downloads_id"]; 

 } else
 {
 if (reader["ATM_id"] != DBNull.Value)
 currentScheduledDownloads.aTM_id = (int) reader["ATM_id"]; 
 if (reader["file_type_id"] != DBNull.Value)
 currentScheduledDownloads.file_type_id = (int) reader["file_type_id"]; 
 if (reader["scheduled_downloads_id"] != DBNull.Value)
 currentScheduledDownloads.scheduled_downloads_id = (int) reader["scheduled_downloads_id"]; 
 } 

 currentScheduledDownloads.isNewEntity = false;
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

 public ScheduledDownloads CurrentScheduledDownloads
 {
 get{ return currentScheduledDownloads; }
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


 #region ScheduledDownloads functions

 public static ScheduledDownloadsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.ATM_id == (Columns.ATM_id & columns))
 qry.Append("ATM_id,");
 if (Columns.file_type_id == (Columns.file_type_id & columns))
 qry.Append("file_type_id,");
 if (Columns.scheduled_downloads_id == (Columns.scheduled_downloads_id & columns))
 qry.Append("scheduled_downloads_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Scheduled_downloads ");

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
 return new ScheduledDownloadsReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ScheduledDownloadsReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ScheduledDownloadsReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select ATM_id,file_type_id,scheduled_downloads_id from Scheduled_downloads ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ScheduledDownloadsReader(cmd.ExecuteReader(), conn);
 }

 static public ScheduledDownloadsReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static ScheduledDownloads LoadScheduledDownloads(string where)
 {
ScheduledDownloadsReader reader = ScheduledDownloads.ExecuteReader(where);
ScheduledDownloads _scheduleddownloads = null;
 if (reader.Read())
 _scheduleddownloads = reader.CurrentScheduledDownloads;
 reader.Close();
 return _scheduleddownloads;
 }

 public static ScheduledDownloads LoadScheduledDownloads(string where, IDbConnection conn)
 {
ScheduledDownloadsReader reader = ScheduledDownloads.ExecuteReader(where, conn);
ScheduledDownloads _scheduleddownloads = null;
 if (reader.Read())
 _scheduleddownloads = reader.CurrentScheduledDownloads;
 reader.Close(false);
 return _scheduleddownloads;
 }

 public static ScheduledDownloads LoadScheduledDownloadsByPk( int scheduled_downloads_id )
 {
 return LoadScheduledDownloads( " scheduled_downloads_id="+scheduled_downloads_id );
 }

 public static ScheduledDownloads LoadScheduledDownloadsByPk( int scheduled_downloads_id , IDbConnection conn)
 {
 return LoadScheduledDownloads(" scheduled_downloads_id="+scheduled_downloads_id , conn);
 }

 public void Save()
 {
 if (aTM_idChanged || file_type_idChanged || scheduled_downloads_idChanged )
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
 if (aTM_idChanged || file_type_idChanged || scheduled_downloads_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Scheduled_downloads( ATM_id,file_type_id,scheduled_downloads_id ) values(");
 qry.Append(aTM_idDbString+",");
 qry.Append(file_type_idDbString+",");
 lock (ConnectionFactory.connectionString) { this.scheduled_downloads_id = ConnectionFactory.GetNextId();
 qry.Append(this.scheduled_downloads_id);
 } qry.Append(");");

 }
 else
 {
 if (!(aTM_idChanged || file_type_idChanged || scheduled_downloads_idChanged ))
 return;
 qry.Append("UPDATE Scheduled_downloads set "); if ( aTM_idChanged )
 {
 qry.Append("ATM_id ="+aTM_idDbString);
 qry.Append(",");
 }

 if ( file_type_idChanged )
 {
 qry.Append("file_type_id ="+file_type_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("scheduled_downloads_id = "+scheduled_downloads_idDbString);
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
 cmd.CommandText = "DELETE Scheduled_downloads where scheduled_downloads_id = "+ scheduled_downloads_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteScheduledDownloadss(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Scheduled_downloads where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
ATM_id= 1,
file_type_id= 2,
scheduled_downloads_id= 4
 }
 #endregion
 public void BulkSave(List<ScheduledDownloads> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Scheduled_downloads";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ScheduledDownloads.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ScheduledDownloads> transList,ref DataTable dt)
 {
 foreach (ScheduledDownloads tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["aTM_id"] = tran.ATMId;
 Row["file_type_id"] = tran.FileTypeId;
 Row["scheduled_downloads_id"] =ConnectionFactory.GetNextId();
 dt.Rows.Add(Row);
 } }
 }
 }

 