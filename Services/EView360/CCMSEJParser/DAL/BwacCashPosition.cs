
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
 public class BwacCashPosition
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public BwacCashPosition() { }
 public BwacCashPosition( int atm_id,DateTime rep_datetime,decimal loaded,decimal dispensed,decimal remaining,int bwac_upload_process_id )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.rep_datetime = rep_datetime;
 this.rep_datetimeChanged = true;
 this.loaded = loaded;
 this.loadedChanged = true;
 this.dispensed = dispensed;
 this.dispensedChanged = true;
 this.remaining = remaining;
 this.remainingChanged = true;
 this.bwac_upload_process_id = bwac_upload_process_id;
 this.bwac_upload_process_idChanged = true;
 }
 private BwacCashPosition( int bwac_cash_position_id,int atm_id,DateTime rep_datetime,decimal loaded,decimal dispensed,decimal remaining,int bwac_upload_process_id )
 {
 this.bwac_cash_position_id = bwac_cash_position_id;
 this.bwac_cash_position_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.rep_datetime = rep_datetime;
 this.rep_datetimeChanged = true;
 this.loaded = loaded;
 this.loadedChanged = true;
 this.dispensed = dispensed;
 this.dispensedChanged = true;
 this.remaining = remaining;
 this.remainingChanged = true;
 this.bwac_upload_process_id = bwac_upload_process_id;
 this.bwac_upload_process_idChanged = true;
 }

 #region members and properties for columns

 #region BwacCashPositionId
 private bool bwac_cash_position_idChanged = false;
 private int bwac_cash_position_id;
 public int BwacCashPositionId
 {
 get { return bwac_cash_position_id; }
 set { 
bwac_cash_position_id = value;
bwac_cash_position_idChanged = true;
 }
 }
 private string bwac_cash_position_idDbString
 {
 get
 {
 return bwac_cash_position_id.ToString();
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
 #region RepDatetime
 private bool rep_datetimeChanged = false;
 private DateTime rep_datetime;
 public DateTime RepDatetime
 {
 get { return rep_datetime; }
 set { 
rep_datetime = value;
rep_datetimeChanged = true;
 }
 }
 private string rep_datetimeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",rep_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region Loaded
 private bool loadedChanged = false;
 private decimal loaded;
 public decimal Loaded
 {
 get { return loaded; }
 set { 
loaded = value;
loadedChanged = true;
 }
 }
 private string loadedDbString
 {
 get
 {
 return loaded.ToString();
 }
 }
 #endregion
 #region Dispensed
 private bool dispensedChanged = false;
 private decimal dispensed;
 public decimal Dispensed
 {
 get { return dispensed; }
 set { 
dispensed = value;
dispensedChanged = true;
 }
 }
 private string dispensedDbString
 {
 get
 {
 return dispensed.ToString();
 }
 }
 #endregion
 #region Remaining
 private bool remainingChanged = false;
 private decimal remaining;
 public decimal Remaining
 {
 get { return remaining; }
 set { 
remaining = value;
remainingChanged = true;
 }
 }
 private string remainingDbString
 {
 get
 {
 return remaining.ToString();
 }
 }
 #endregion
 #region BwacUploadProcessId
 private bool bwac_upload_process_idChanged = false;
 private int bwac_upload_process_id;
 public int BwacUploadProcessId
 {
 get { return bwac_upload_process_id; }
 set { 
bwac_upload_process_id = value;
bwac_upload_process_idChanged = true;
 }
 }
 private string bwac_upload_process_idDbString
 {
 get
 {
 return bwac_upload_process_id.ToString();
 }
 }
 #endregion
 #endregion

 #region BwacCashPositionReader
 public class BwacCashPositionReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
BwacCashPosition currentBwacCashPosition;
 Columns columns;
 bool partialRead = false;
 private BwacCashPositionReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public BwacCashPositionReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public BwacCashPositionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentBwacCashPosition; }

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
 currentBwacCashPosition = new BwacCashPosition();
 if (partialRead)
 { if ((columns & Columns.bwac_cash_position_id) == Columns.bwac_cash_position_id && reader["bwac_cash_position_id"]!=DBNull.Value)
 currentBwacCashPosition.bwac_cash_position_id =(int) reader["bwac_cash_position_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentBwacCashPosition.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.rep_datetime) == Columns.rep_datetime && reader["rep_datetime"]!=DBNull.Value)
 currentBwacCashPosition.rep_datetime =(DateTime) reader["rep_datetime"]; 
 if ((columns & Columns.loaded) == Columns.loaded && reader["loaded"]!=DBNull.Value)
 currentBwacCashPosition.loaded =(decimal) reader["loaded"]; 
 if ((columns & Columns.dispensed) == Columns.dispensed && reader["dispensed"]!=DBNull.Value)
 currentBwacCashPosition.dispensed =(decimal) reader["dispensed"]; 
 if ((columns & Columns.remaining) == Columns.remaining && reader["remaining"]!=DBNull.Value)
 currentBwacCashPosition.remaining =(decimal) reader["remaining"]; 
 if ((columns & Columns.bwac_upload_process_id) == Columns.bwac_upload_process_id && reader["bwac_upload_process_id"]!=DBNull.Value)
 currentBwacCashPosition.bwac_upload_process_id =(int) reader["bwac_upload_process_id"]; 

 } else
 {
 if (reader["bwac_cash_position_id"] != DBNull.Value)
 currentBwacCashPosition.bwac_cash_position_id = (int) reader["bwac_cash_position_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentBwacCashPosition.atm_id = (int) reader["atm_id"]; 
 if (reader["rep_datetime"] != DBNull.Value)
 currentBwacCashPosition.rep_datetime = (DateTime) reader["rep_datetime"]; 
 if (reader["loaded"] != DBNull.Value)
 currentBwacCashPosition.loaded = (decimal) reader["loaded"]; 
 if (reader["dispensed"] != DBNull.Value)
 currentBwacCashPosition.dispensed = (decimal) reader["dispensed"]; 
 if (reader["remaining"] != DBNull.Value)
 currentBwacCashPosition.remaining = (decimal) reader["remaining"]; 
 if (reader["bwac_upload_process_id"] != DBNull.Value)
 currentBwacCashPosition.bwac_upload_process_id = (int) reader["bwac_upload_process_id"]; 
 } 

 currentBwacCashPosition.isNewEntity = false;
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

 public BwacCashPosition CurrentBwacCashPosition
 {
 get{ return currentBwacCashPosition; }
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


 #region BwacCashPosition functions

 public static BwacCashPositionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.bwac_cash_position_id == (Columns.bwac_cash_position_id & columns))
 qry.Append("bwac_cash_position_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.rep_datetime == (Columns.rep_datetime & columns))
 qry.Append("rep_datetime,");
 if (Columns.loaded == (Columns.loaded & columns))
 qry.Append("loaded,");
 if (Columns.dispensed == (Columns.dispensed & columns))
 qry.Append("dispensed,");
 if (Columns.remaining == (Columns.remaining & columns))
 qry.Append("remaining,");
 if (Columns.bwac_upload_process_id == (Columns.bwac_upload_process_id & columns))
 qry.Append("bwac_upload_process_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Bwac_cash_position ");

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
 return new BwacCashPositionReader(cmd.ExecuteReader(), conn, columns);
 }

 static public BwacCashPositionReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static BwacCashPositionReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select bwac_cash_position_id,atm_id,rep_datetime,loaded,dispensed,remaining,bwac_upload_process_id from Bwac_cash_position ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new BwacCashPositionReader(cmd.ExecuteReader(), conn);
 }

 static public BwacCashPositionReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static BwacCashPosition LoadBwacCashPosition(string where)
 {
BwacCashPositionReader reader = BwacCashPosition.ExecuteReader(where);
BwacCashPosition _bwaccashposition = null;
 if (reader.Read())
 _bwaccashposition = reader.CurrentBwacCashPosition;
 reader.Close();
 return _bwaccashposition;
 }

 public static BwacCashPosition LoadBwacCashPosition(string where, IDbConnection conn)
 {
BwacCashPositionReader reader = BwacCashPosition.ExecuteReader(where, conn);
BwacCashPosition _bwaccashposition = null;
 if (reader.Read())
 _bwaccashposition = reader.CurrentBwacCashPosition;
 reader.Close(false);
 return _bwaccashposition;
 }

 public static BwacCashPosition LoadBwacCashPositionByPk( int bwac_cash_position_id )
 {
 return LoadBwacCashPosition( " bwac_cash_position_id="+bwac_cash_position_id );
 }

 public static BwacCashPosition LoadBwacCashPositionByPk( int bwac_cash_position_id , IDbConnection conn)
 {
 return LoadBwacCashPosition(" bwac_cash_position_id="+bwac_cash_position_id , conn);
 }

 public void Save()
 {
 if (bwac_cash_position_idChanged || atm_idChanged || rep_datetimeChanged || loadedChanged || dispensedChanged || remainingChanged || bwac_upload_process_idChanged )
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
 if (bwac_cash_position_idChanged || atm_idChanged || rep_datetimeChanged || loadedChanged || dispensedChanged || remainingChanged || bwac_upload_process_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Bwac_cash_position( bwac_cash_position_id,atm_id,rep_datetime,loaded,dispensed,remaining,bwac_upload_process_id ) values(");
 lock (ConnectionFactory.connectionString) { this.bwac_cash_position_id = ConnectionFactory.GetNextId();
 qry.Append(this.bwac_cash_position_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(rep_datetimeDbString+",");
 qry.Append(loadedDbString+",");
 qry.Append(dispensedDbString+",");
 qry.Append(remainingDbString+",");
 qry.Append(bwac_upload_process_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(bwac_cash_position_idChanged || atm_idChanged || rep_datetimeChanged || loadedChanged || dispensedChanged || remainingChanged || bwac_upload_process_idChanged ))
 return;
 qry.Append("UPDATE Bwac_cash_position set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( rep_datetimeChanged )
 {
 qry.Append("rep_datetime ="+rep_datetimeDbString);
 qry.Append(",");
 }

 if ( loadedChanged )
 {
 qry.Append("loaded ="+loadedDbString);
 qry.Append(",");
 }

 if ( dispensedChanged )
 {
 qry.Append("dispensed ="+dispensedDbString);
 qry.Append(",");
 }

 if ( remainingChanged )
 {
 qry.Append("remaining ="+remainingDbString);
 qry.Append(",");
 }

 if ( bwac_upload_process_idChanged )
 {
 qry.Append("bwac_upload_process_id ="+bwac_upload_process_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("bwac_cash_position_id = "+bwac_cash_position_idDbString);
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
 cmd.CommandText = "DELETE Bwac_cash_position where bwac_cash_position_id = "+ bwac_cash_position_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteBwacCashPositions(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Bwac_cash_position where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
bwac_cash_position_id= 1,
atm_id= 2,
rep_datetime= 4,
loaded= 8,
dispensed= 16,
remaining= 32,
bwac_upload_process_id= 64
 }
 #endregion
 public void BulkSave(List<BwacCashPosition> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Bwac_cash_position";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(BwacCashPosition.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <BwacCashPosition> transList,ref DataTable dt)
 {
 foreach (BwacCashPosition tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["bwac_cash_position_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["rep_datetime"] = tran.RepDatetime;
 Row["loaded"] = tran.Loaded;
 Row["dispensed"] = tran.Dispensed;
 Row["remaining"] = tran.Remaining;
 Row["bwac_upload_process_id"] = tran.BwacUploadProcessId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
