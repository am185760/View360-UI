
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
 public class MissingNotes
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public MissingNotes() { }
 public MissingNotes( DateTime processing_datetime,int type1,int type2,int type3,int type4,int type5,int type6,int type7,int task_id,int atm_id )
 {
 this.processing_datetime = processing_datetime;
 this.processing_datetimeChanged = true;
 this.type1 = type1;
 this.type1Changed = true;
 this.type2 = type2;
 this.type2Changed = true;
 this.type3 = type3;
 this.type3Changed = true;
 this.type4 = type4;
 this.type4Changed = true;
 this.type5 = type5;
 this.type5Changed = true;
 this.type6 = type6;
 this.type6Changed = true;
 this.type7 = type7;
 this.type7Changed = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }
 private MissingNotes( int missing_notes_id,DateTime processing_datetime,int type1,int type2,int type3,int type4,int type5,int type6,int type7,int task_id,int atm_id )
 {
 this.missing_notes_id = missing_notes_id;
 this.missing_notes_idChanged = true;
 this.processing_datetime = processing_datetime;
 this.processing_datetimeChanged = true;
 this.type1 = type1;
 this.type1Changed = true;
 this.type2 = type2;
 this.type2Changed = true;
 this.type3 = type3;
 this.type3Changed = true;
 this.type4 = type4;
 this.type4Changed = true;
 this.type5 = type5;
 this.type5Changed = true;
 this.type6 = type6;
 this.type6Changed = true;
 this.type7 = type7;
 this.type7Changed = true;
 this.task_id = task_id;
 this.task_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }

 #region members and properties for columns

 #region MissingNotesId
 private bool missing_notes_idChanged = false;
 private int missing_notes_id;
 public int MissingNotesId
 {
 get { return missing_notes_id; }
 set { 
missing_notes_id = value;
missing_notes_idChanged = true;
 }
 }
 private string missing_notes_idDbString
 {
 get
 {
 return missing_notes_id.ToString();
 }
 }
 #endregion
 #region ProcessingDatetime
 private bool processing_datetimeChanged = false;
 private DateTime processing_datetime;
 public DateTime ProcessingDatetime
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
 return string.Format("Convert(datetime,'{0}',121)",processing_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region Type1
 private bool type1Changed = false;
 private int type1;
 public int Type1
 {
 get { return type1; }
 set { 
type1 = value;
type1Changed = true;
 }
 }
 private string type1DbString
 {
 get
 {
 return type1.ToString();
 }
 }
 #endregion
 #region Type2
 private bool type2Changed = false;
 private int type2;
 public int Type2
 {
 get { return type2; }
 set { 
type2 = value;
type2Changed = true;
 }
 }
 private string type2DbString
 {
 get
 {
 return type2.ToString();
 }
 }
 #endregion
 #region Type3
 private bool type3Changed = false;
 private int type3;
 public int Type3
 {
 get { return type3; }
 set { 
type3 = value;
type3Changed = true;
 }
 }
 private string type3DbString
 {
 get
 {
 return type3.ToString();
 }
 }
 #endregion
 #region Type4
 private bool type4Changed = false;
 private int type4;
 public int Type4
 {
 get { return type4; }
 set { 
type4 = value;
type4Changed = true;
 }
 }
 private string type4DbString
 {
 get
 {
 return type4.ToString();
 }
 }
 #endregion
 #region Type5
 private bool type5Changed = false;
 private int type5;
 public int Type5
 {
 get { return type5; }
 set { 
type5 = value;
type5Changed = true;
 }
 }
 private string type5DbString
 {
 get
 {
 return type5.ToString();
 }
 }
 #endregion
 #region Type6
 private bool type6Changed = false;
 private int type6;
 public int Type6
 {
 get { return type6; }
 set { 
type6 = value;
type6Changed = true;
 }
 }
 private string type6DbString
 {
 get
 {
 return type6.ToString();
 }
 }
 #endregion
 #region Type7
 private bool type7Changed = false;
 private int type7;
 public int Type7
 {
 get { return type7; }
 set { 
type7 = value;
type7Changed = true;
 }
 }
 private string type7DbString
 {
 get
 {
 return type7.ToString();
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
 #endregion

 #region MissingNotesReader
 public class MissingNotesReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
MissingNotes currentMissingNotes;
 Columns columns;
 bool partialRead = false;
 private MissingNotesReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public MissingNotesReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public MissingNotesReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentMissingNotes; }

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
 currentMissingNotes = new MissingNotes();
 if (partialRead)
 { if ((columns & Columns.missing_notes_id) == Columns.missing_notes_id && reader["missing_notes_id"]!=DBNull.Value)
 currentMissingNotes.missing_notes_id =(int) reader["missing_notes_id"]; 
 if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"]!=DBNull.Value)
 currentMissingNotes.processing_datetime =(DateTime) reader["processing_datetime"]; 
 if ((columns & Columns.type1) == Columns.type1 && reader["type1"]!=DBNull.Value)
 currentMissingNotes.type1 =(int) reader["type1"]; 
 if ((columns & Columns.type2) == Columns.type2 && reader["type2"]!=DBNull.Value)
 currentMissingNotes.type2 =(int) reader["type2"]; 
 if ((columns & Columns.type3) == Columns.type3 && reader["type3"]!=DBNull.Value)
 currentMissingNotes.type3 =(int) reader["type3"]; 
 if ((columns & Columns.type4) == Columns.type4 && reader["type4"]!=DBNull.Value)
 currentMissingNotes.type4 =(int) reader["type4"]; 
 if ((columns & Columns.type5) == Columns.type5 && reader["type5"]!=DBNull.Value)
 currentMissingNotes.type5 =(int) reader["type5"]; 
 if ((columns & Columns.type6) == Columns.type6 && reader["type6"]!=DBNull.Value)
 currentMissingNotes.type6 =(int) reader["type6"]; 
 if ((columns & Columns.type7) == Columns.type7 && reader["type7"]!=DBNull.Value)
 currentMissingNotes.type7 =(int) reader["type7"]; 
 if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"]!=DBNull.Value)
 currentMissingNotes.task_id =(int) reader["task_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentMissingNotes.atm_id =(int) reader["atm_id"]; 

 } else
 {
 if (reader["missing_notes_id"] != DBNull.Value)
 currentMissingNotes.missing_notes_id = (int) reader["missing_notes_id"]; 
 if (reader["processing_datetime"] != DBNull.Value)
 currentMissingNotes.processing_datetime = (DateTime) reader["processing_datetime"]; 
 if (reader["type1"] != DBNull.Value)
 currentMissingNotes.type1 = (int) reader["type1"]; 
 if (reader["type2"] != DBNull.Value)
 currentMissingNotes.type2 = (int) reader["type2"]; 
 if (reader["type3"] != DBNull.Value)
 currentMissingNotes.type3 = (int) reader["type3"]; 
 if (reader["type4"] != DBNull.Value)
 currentMissingNotes.type4 = (int) reader["type4"]; 
 if (reader["type5"] != DBNull.Value)
 currentMissingNotes.type5 = (int) reader["type5"]; 
 if (reader["type6"] != DBNull.Value)
 currentMissingNotes.type6 = (int) reader["type6"]; 
 if (reader["type7"] != DBNull.Value)
 currentMissingNotes.type7 = (int) reader["type7"]; 
 if (reader["task_id"] != DBNull.Value)
 currentMissingNotes.task_id = (int) reader["task_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentMissingNotes.atm_id = (int) reader["atm_id"]; 
 } 

 currentMissingNotes.isNewEntity = false;
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

 public MissingNotes CurrentMissingNotes
 {
 get{ return currentMissingNotes; }
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


 #region MissingNotes functions

 public static MissingNotesReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.missing_notes_id == (Columns.missing_notes_id & columns))
 qry.Append("missing_notes_id,");
 if (Columns.processing_datetime == (Columns.processing_datetime & columns))
 qry.Append("processing_datetime,");
 if (Columns.type1 == (Columns.type1 & columns))
 qry.Append("type1,");
 if (Columns.type2 == (Columns.type2 & columns))
 qry.Append("type2,");
 if (Columns.type3 == (Columns.type3 & columns))
 qry.Append("type3,");
 if (Columns.type4 == (Columns.type4 & columns))
 qry.Append("type4,");
 if (Columns.type5 == (Columns.type5 & columns))
 qry.Append("type5,");
 if (Columns.type6 == (Columns.type6 & columns))
 qry.Append("type6,");
 if (Columns.type7 == (Columns.type7 & columns))
 qry.Append("type7,");
 if (Columns.task_id == (Columns.task_id & columns))
 qry.Append("task_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Missing_notes ");

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
 return new MissingNotesReader(cmd.ExecuteReader(), conn, columns);
 }

 static public MissingNotesReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static MissingNotesReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select missing_notes_id,processing_datetime,type1,type2,type3,type4,type5,type6,type7,task_id,atm_id from Missing_notes ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new MissingNotesReader(cmd.ExecuteReader(), conn);
 }

 static public MissingNotesReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static MissingNotes LoadMissingNotes(string where)
 {
MissingNotesReader reader = MissingNotes.ExecuteReader(where);
MissingNotes _missingnotes = null;
 if (reader.Read())
 _missingnotes = reader.CurrentMissingNotes;
 reader.Close();
 return _missingnotes;
 }

 public static MissingNotes LoadMissingNotes(string where, IDbConnection conn)
 {
MissingNotesReader reader = MissingNotes.ExecuteReader(where, conn);
MissingNotes _missingnotes = null;
 if (reader.Read())
 _missingnotes = reader.CurrentMissingNotes;
 reader.Close(false);
 return _missingnotes;
 }

 public static MissingNotes LoadMissingNotesByPk( int missing_notes_id )
 {
 return LoadMissingNotes( " missing_notes_id="+missing_notes_id );
 }

 public static MissingNotes LoadMissingNotesByPk( int missing_notes_id , IDbConnection conn)
 {
 return LoadMissingNotes(" missing_notes_id="+missing_notes_id , conn);
 }

 public void Save()
 {
 if (missing_notes_idChanged || processing_datetimeChanged || type1Changed || type2Changed || type3Changed || type4Changed || type5Changed || type6Changed || type7Changed || task_idChanged || atm_idChanged )
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
 if (missing_notes_idChanged || processing_datetimeChanged || type1Changed || type2Changed || type3Changed || type4Changed || type5Changed || type6Changed || type7Changed || task_idChanged || atm_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Missing_notes( missing_notes_id,processing_datetime,type1,type2,type3,type4,type5,type6,type7,task_id,atm_id ) values(");
 lock (ConnectionFactory.connectionString) { this.missing_notes_id = ConnectionFactory.GetNextId();
 qry.Append(this.missing_notes_id);
 } qry.Append(",");
 qry.Append(processing_datetimeDbString+",");
 qry.Append(type1DbString+",");
 qry.Append(type2DbString+",");
 qry.Append(type3DbString+",");
 qry.Append(type4DbString+",");
 qry.Append(type5DbString+",");
 qry.Append(type6DbString+",");
 qry.Append(type7DbString+",");
 qry.Append(task_idDbString+",");
 qry.Append(atm_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(missing_notes_idChanged || processing_datetimeChanged || type1Changed || type2Changed || type3Changed || type4Changed || type5Changed || type6Changed || type7Changed || task_idChanged || atm_idChanged ))
 return;
 qry.Append("UPDATE Missing_notes set "); if ( processing_datetimeChanged )
 {
 qry.Append("processing_datetime ="+processing_datetimeDbString);
 qry.Append(",");
 }

 if ( type1Changed )
 {
 qry.Append("type1 ="+type1DbString);
 qry.Append(",");
 }

 if ( type2Changed )
 {
 qry.Append("type2 ="+type2DbString);
 qry.Append(",");
 }

 if ( type3Changed )
 {
 qry.Append("type3 ="+type3DbString);
 qry.Append(",");
 }

 if ( type4Changed )
 {
 qry.Append("type4 ="+type4DbString);
 qry.Append(",");
 }

 if ( type5Changed )
 {
 qry.Append("type5 ="+type5DbString);
 qry.Append(",");
 }

 if ( type6Changed )
 {
 qry.Append("type6 ="+type6DbString);
 qry.Append(",");
 }

 if ( type7Changed )
 {
 qry.Append("type7 ="+type7DbString);
 qry.Append(",");
 }

 if ( task_idChanged )
 {
 qry.Append("task_id ="+task_idDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("missing_notes_id = "+missing_notes_idDbString);
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
 cmd.CommandText = "DELETE Missing_notes where missing_notes_id = "+ missing_notes_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteMissingNotess(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Missing_notes where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
missing_notes_id= 1,
processing_datetime= 2,
type1= 4,
type2= 8,
type3= 16,
type4= 32,
type5= 64,
type6= 128,
type7= 256,
task_id= 512,
atm_id= 1024
 }
 #endregion
 public void BulkSave(List<MissingNotes> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Missing_notes";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(MissingNotes.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <MissingNotes> transList,ref DataTable dt)
 {
 foreach (MissingNotes tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["missing_notes_id"] =ConnectionFactory.GetNextId();
 Row["processing_datetime"] = tran.ProcessingDatetime;
 Row["type1"] = tran.Type1;
 Row["type2"] = tran.Type2;
 Row["type3"] = tran.Type3;
 Row["type4"] = tran.Type4;
 Row["type5"] = tran.Type5;
 Row["type6"] = tran.Type6;
 Row["type7"] = tran.Type7;
 Row["task_id"] = tran.TaskId;
 Row["atm_id"] = tran.AtmId;
 dt.Rows.Add(Row);
 } }
 }
 }

 