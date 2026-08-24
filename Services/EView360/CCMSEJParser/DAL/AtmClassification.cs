
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
 public class AtmClassification
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public AtmClassification() { }
 public AtmClassification( int atm_id,int classification_id )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.classification_id = classification_id;
 this.classification_idChanged = true;
 }
 private AtmClassification( int atm_classification_id,int atm_id,int classification_id )
 {
 this.atm_classification_id = atm_classification_id;
 this.atm_classification_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.classification_id = classification_id;
 this.classification_idChanged = true;
 }

 #region members and properties for columns

 #region AtmClassificationId
 private bool atm_classification_idChanged = false;
 private int atm_classification_id;
 public int AtmClassificationId
 {
 get { return atm_classification_id; }
 set { 
atm_classification_id = value;
atm_classification_idChanged = true;
 }
 }
 private string atm_classification_idDbString
 {
 get
 {
 return atm_classification_id.ToString();
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
 #region ClassificationId
 private bool classification_idChanged = false;
 private int classification_id;
 public int ClassificationId
 {
 get { return classification_id; }
 set { 
classification_id = value;
classification_idChanged = true;
 }
 }
 private string classification_idDbString
 {
 get
 {
 return classification_id.ToString();
 }
 }
 #endregion
 #endregion

 #region AtmClassificationReader
 public class AtmClassificationReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
AtmClassification currentAtmClassification;
 Columns columns;
 bool partialRead = false;
 private AtmClassificationReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public AtmClassificationReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public AtmClassificationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentAtmClassification; }

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
 currentAtmClassification = new AtmClassification();
 if (partialRead)
 { if ((columns & Columns.atm_classification_id) == Columns.atm_classification_id && reader["atm_classification_id"]!=DBNull.Value)
 currentAtmClassification.atm_classification_id =(int) reader["atm_classification_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentAtmClassification.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.classification_id) == Columns.classification_id && reader["classification_id"]!=DBNull.Value)
 currentAtmClassification.classification_id =(int) reader["classification_id"]; 

 } else
 {
 if (reader["atm_classification_id"] != DBNull.Value)
 currentAtmClassification.atm_classification_id = (int) reader["atm_classification_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentAtmClassification.atm_id = (int) reader["atm_id"]; 
 if (reader["classification_id"] != DBNull.Value)
 currentAtmClassification.classification_id = (int) reader["classification_id"]; 
 } 

 currentAtmClassification.isNewEntity = false;
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

 public AtmClassification CurrentAtmClassification
 {
 get{ return currentAtmClassification; }
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


 #region AtmClassification functions

 public static AtmClassificationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.atm_classification_id == (Columns.atm_classification_id & columns))
 qry.Append("atm_classification_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.classification_id == (Columns.classification_id & columns))
 qry.Append("classification_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Atm_classification ");

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
 return new AtmClassificationReader(cmd.ExecuteReader(), conn, columns);
 }

 static public AtmClassificationReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static AtmClassificationReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select atm_classification_id,atm_id,classification_id from Atm_classification ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new AtmClassificationReader(cmd.ExecuteReader(), conn);
 }

 static public AtmClassificationReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static AtmClassification LoadAtmClassification(string where)
 {
AtmClassificationReader reader = AtmClassification.ExecuteReader(where);
AtmClassification _atmclassification = null;
 if (reader.Read())
 _atmclassification = reader.CurrentAtmClassification;
 reader.Close();
 return _atmclassification;
 }

 public static AtmClassification LoadAtmClassification(string where, IDbConnection conn)
 {
AtmClassificationReader reader = AtmClassification.ExecuteReader(where, conn);
AtmClassification _atmclassification = null;
 if (reader.Read())
 _atmclassification = reader.CurrentAtmClassification;
 reader.Close(false);
 return _atmclassification;
 }

 public static AtmClassification LoadAtmClassificationByPk( int atm_classification_id )
 {
 return LoadAtmClassification( " atm_classification_id="+atm_classification_id );
 }

 public static AtmClassification LoadAtmClassificationByPk( int atm_classification_id , IDbConnection conn)
 {
 return LoadAtmClassification(" atm_classification_id="+atm_classification_id , conn);
 }

 public void Save()
 {
 if (atm_classification_idChanged || atm_idChanged || classification_idChanged )
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
 if (atm_classification_idChanged || atm_idChanged || classification_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Atm_classification( atm_classification_id,atm_id,classification_id ) values(");
 lock (ConnectionFactory.connectionString) { this.atm_classification_id = ConnectionFactory.GetNextId();
 qry.Append(this.atm_classification_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(classification_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(atm_classification_idChanged || atm_idChanged || classification_idChanged ))
 return;
 qry.Append("UPDATE Atm_classification set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( classification_idChanged )
 {
 qry.Append("classification_id ="+classification_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("atm_classification_id = "+atm_classification_idDbString);
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
 cmd.CommandText = "DELETE Atm_classification where atm_classification_id = "+ atm_classification_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteAtmClassifications(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Atm_classification where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
atm_classification_id= 1,
atm_id= 2,
classification_id= 4
 }
 #endregion
 public void BulkSave(List<AtmClassification> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Atm_classification";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(AtmClassification.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <AtmClassification> transList,ref DataTable dt)
 {
 foreach (AtmClassification tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["atm_classification_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["classification_id"] = tran.ClassificationId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
