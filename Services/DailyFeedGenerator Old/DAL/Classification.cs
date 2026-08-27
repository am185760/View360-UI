
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
 public class Classification
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public Classification() { }
 public Classification( int classification_id,DateTime creation_time,int created_by ) 
 {
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 }
 public Classification( string classification_name,DateTime creation_time,int created_by,DateTime? modification_time,int? modified_by )
 {
 this.classification_name = classification_name;
 this.classification_nameChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.modification_time = modification_time;
 this.modification_timeChanged = true;
 this.modified_by = modified_by;
 this.modified_byChanged = true;
 }
 private Classification( int classification_id,string classification_name,DateTime creation_time,int created_by,DateTime? modification_time,int? modified_by )
 {
 this.classification_id = classification_id;
 this.classification_idChanged = true;
 this.classification_name = classification_name;
 this.classification_nameChanged = true;
 this.creation_time = creation_time;
 this.creation_timeChanged = true;
 this.created_by = created_by;
 this.created_byChanged = true;
 this.modification_time = modification_time;
 this.modification_timeChanged = true;
 this.modified_by = modified_by;
 this.modified_byChanged = true;
 }

 #region members and properties for columns

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
 #region ClassificationName
 private bool classification_nameChanged = false;
 private string classification_name;
 public string ClassificationName
 {
 get { return classification_name; }
 set { 
classification_name = value;
classification_nameChanged = true;
 }
 }
 private string classification_nameDbString
 {
 get
 {
 if (this.classification_name!=null)
 return string.Format("'{0}'",classification_name); else
 return "null";
 }
 }
 #endregion
 #region CreationTime
 private bool creation_timeChanged = false;
 private DateTime creation_time;
 public DateTime CreationTime
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
 return string.Format("Convert(datetime,'{0}',121)",creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region CreatedBy
 private bool created_byChanged = false;
 private int created_by;
 public int CreatedBy
 {
 get { return created_by; }
 set { 
created_by = value;
created_byChanged = true;
 }
 }
 private string created_byDbString
 {
 get
 {
 return created_by.ToString();
 }
 }
 #endregion
 #region ModificationTime
 private bool modification_timeChanged = false;
 private DateTime? modification_time;
 public DateTime? ModificationTime
 {
 get { return modification_time; }
 set { 
modification_time = value;
modification_timeChanged = true;
 }
 }
 private string modification_timeDbString
 {
 get
 {
 if (this.modification_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region ModifiedBy
 private bool modified_byChanged = false;
 private int? modified_by;
 public int? ModifiedBy
 {
 get { return modified_by; }
 set { 
modified_by = value;
modified_byChanged = true;
 }
 }
 private string modified_byDbString
 {
 get
 {
 if (this.modified_by.HasValue)
 return modified_by.ToString();
 else
 return "null";
 }
 }
 #endregion
 #endregion

 #region ClassificationReader
 public class ClassificationReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
Classification currentClassification;
 Columns columns;
 bool partialRead = false;
 private ClassificationReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ClassificationReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ClassificationReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentClassification; }

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
 currentClassification = new Classification();
 if (partialRead)
 { if ((columns & Columns.classification_id) == Columns.classification_id && reader["classification_id"]!=DBNull.Value)
 currentClassification.classification_id =(int) reader["classification_id"]; 
 if ((columns & Columns.classification_name) == Columns.classification_name && reader["classification_name"]!=DBNull.Value)
 currentClassification.classification_name =(string) reader["classification_name"]; 
 if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
 currentClassification.creation_time =(DateTime) reader["creation_time"]; 
 if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
 currentClassification.created_by =(int) reader["created_by"]; 
 if ((columns & Columns.modification_time) == Columns.modification_time && reader["modification_time"]!=DBNull.Value)
 currentClassification.modification_time =(DateTime?) reader["modification_time"]; 
 if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
 currentClassification.modified_by =(int?) reader["modified_by"]; 

 } else
 {
 if (reader["classification_id"] != DBNull.Value)
 currentClassification.classification_id = (int) reader["classification_id"]; 
 if (reader["classification_name"] != DBNull.Value)
 currentClassification.classification_name = (string) reader["classification_name"]; 
 if (reader["creation_time"] != DBNull.Value)
 currentClassification.creation_time = (DateTime) reader["creation_time"]; 
 if (reader["created_by"] != DBNull.Value)
 currentClassification.created_by = (int) reader["created_by"]; 
 if (reader["modification_time"] != DBNull.Value)
 currentClassification.modification_time = (DateTime?) reader["modification_time"]; 
 if (reader["modified_by"] != DBNull.Value)
 currentClassification.modified_by = (int?) reader["modified_by"]; 
 } 

 currentClassification.isNewEntity = false;
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

 public Classification CurrentClassification
 {
 get{ return currentClassification; }
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


 #region Classification functions

 public static ClassificationReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.classification_id == (Columns.classification_id & columns))
 qry.Append("classification_id,");
 if (Columns.classification_name == (Columns.classification_name & columns))
 qry.Append("classification_name,");
 if (Columns.creation_time == (Columns.creation_time & columns))
 qry.Append("creation_time,");
 if (Columns.created_by == (Columns.created_by & columns))
 qry.Append("created_by,");
 if (Columns.modification_time == (Columns.modification_time & columns))
 qry.Append("modification_time,");
 if (Columns.modified_by == (Columns.modified_by & columns))
 qry.Append("modified_by,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Classification ");

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
 return new ClassificationReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ClassificationReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ClassificationReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select classification_id,classification_name,creation_time,created_by,modification_time,modified_by from Classification ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ClassificationReader(cmd.ExecuteReader(), conn);
 }

 static public ClassificationReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static Classification LoadClassification(string where)
 {
ClassificationReader reader = Classification.ExecuteReader(where);
Classification _classification = null;
 if (reader.Read())
 _classification = reader.CurrentClassification;
 reader.Close();
 return _classification;
 }

 public static Classification LoadClassification(string where, IDbConnection conn)
 {
ClassificationReader reader = Classification.ExecuteReader(where, conn);
Classification _classification = null;
 if (reader.Read())
 _classification = reader.CurrentClassification;
 reader.Close(false);
 return _classification;
 }

 public static Classification LoadClassificationByPk( int classification_id )
 {
 return LoadClassification( " classification_id="+classification_id );
 }

 public static Classification LoadClassificationByPk( int classification_id , IDbConnection conn)
 {
 return LoadClassification(" classification_id="+classification_id , conn);
 }

 public void Save()
 {
 if (classification_idChanged || classification_nameChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged )
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
 if (classification_idChanged || classification_nameChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Classification( classification_id,classification_name,creation_time,created_by,modification_time,modified_by ) values(");
 lock (ConnectionFactory.connectionString) { this.classification_id = ConnectionFactory.GetNextId();
 qry.Append(this.classification_id);
 } qry.Append(",");
 qry.Append(classification_nameDbString+",");
 qry.Append(creation_timeDbString+",");
 qry.Append(created_byDbString+",");
 qry.Append(modification_timeDbString+",");
 qry.Append(modified_byDbString);
 qry.Append(");");

 }
 else
 {
 if (!(classification_idChanged || classification_nameChanged || creation_timeChanged || created_byChanged || modification_timeChanged || modified_byChanged ))
 return;
 qry.Append("UPDATE Classification set "); if ( classification_nameChanged )
 {
 qry.Append("classification_name ="+classification_nameDbString);
 qry.Append(",");
 }

 if ( creation_timeChanged )
 {
 qry.Append("creation_time ="+creation_timeDbString);
 qry.Append(",");
 }

 if ( created_byChanged )
 {
 qry.Append("created_by ="+created_byDbString);
 qry.Append(",");
 }

 if ( modification_timeChanged )
 {
 qry.Append("modification_time ="+modification_timeDbString);
 qry.Append(",");
 }

 if ( modified_byChanged )
 {
 qry.Append("modified_by ="+modified_byDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("classification_id = "+classification_idDbString);
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
 cmd.CommandText = "DELETE Classification where classification_id = "+ classification_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteClassifications(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Classification where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
classification_id= 1,
classification_name= 2,
creation_time= 4,
created_by= 8,
modification_time= 16,
modified_by= 32
 }
 #endregion
 public void BulkSave(List<Classification> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Classification";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(Classification.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <Classification> transList,ref DataTable dt)
 {
 foreach (Classification tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["classification_id"] =ConnectionFactory.GetNextId();
 Row["classification_name"] = tran.ClassificationName;
 Row["creation_time"] = tran.CreationTime;
 Row["created_by"] = tran.CreatedBy;
 Row["modification_time"] = tran.ModificationTime;
 Row["modified_by"] = tran.ModifiedBy;
 dt.Rows.Add(Row);
 } }
 }
 }

 
