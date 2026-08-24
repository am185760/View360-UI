
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
 public class OperationalHour
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public OperationalHour() { }
 public OperationalHour( int operational_hour_id,int atm_id,string operational_hour_from,string operational_hour_to,bool is_operational_day ) 
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.operational_hour_from = operational_hour_from;
 this.operational_hour_fromChanged = true;
 this.operational_hour_to = operational_hour_to;
 this.operational_hour_toChanged = true;
 this.is_operational_day = is_operational_day;
 this.is_operational_dayChanged = true;
 }
 public OperationalHour( int atm_id,int? operational_day_id,string operational_hour_from,string operational_hour_to,bool is_operational_day )
 {
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.operational_day_id = operational_day_id;
 this.operational_day_idChanged = true;
 this.operational_hour_from = operational_hour_from;
 this.operational_hour_fromChanged = true;
 this.operational_hour_to = operational_hour_to;
 this.operational_hour_toChanged = true;
 this.is_operational_day = is_operational_day;
 this.is_operational_dayChanged = true;
 }
 private OperationalHour( int operational_hour_id,int atm_id,int? operational_day_id,string operational_hour_from,string operational_hour_to,bool is_operational_day )
 {
 this.operational_hour_id = operational_hour_id;
 this.operational_hour_idChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 this.operational_day_id = operational_day_id;
 this.operational_day_idChanged = true;
 this.operational_hour_from = operational_hour_from;
 this.operational_hour_fromChanged = true;
 this.operational_hour_to = operational_hour_to;
 this.operational_hour_toChanged = true;
 this.is_operational_day = is_operational_day;
 this.is_operational_dayChanged = true;
 }

 #region members and properties for columns

 #region OperationalHourId
 private bool operational_hour_idChanged = false;
 private int operational_hour_id;
 public int OperationalHourId
 {
 get { return operational_hour_id; }
 set { 
operational_hour_id = value;
operational_hour_idChanged = true;
 }
 }
 private string operational_hour_idDbString
 {
 get
 {
 return operational_hour_id.ToString();
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
 #region OperationalDayId
 private bool operational_day_idChanged = false;
 private int? operational_day_id;
 public int? OperationalDayId
 {
 get { return operational_day_id; }
 set { 
operational_day_id = value;
operational_day_idChanged = true;
 }
 }
 private string operational_day_idDbString
 {
 get
 {
 if (this.operational_day_id.HasValue)
 return operational_day_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region OperationalHourFrom
 private bool operational_hour_fromChanged = false;
 private string operational_hour_from;
 public string OperationalHourFrom
 {
 get { return operational_hour_from; }
 set { 
operational_hour_from = value;
operational_hour_fromChanged = true;
 }
 }
 private string operational_hour_fromDbString
 {
 get
 {
 if (this.operational_hour_from!=null)
 return string.Format("'{0}'",operational_hour_from); else
 return "null";
 }
 }
 #endregion
 #region OperationalHourTo
 private bool operational_hour_toChanged = false;
 private string operational_hour_to;
 public string OperationalHourTo
 {
 get { return operational_hour_to; }
 set { 
operational_hour_to = value;
operational_hour_toChanged = true;
 }
 }
 private string operational_hour_toDbString
 {
 get
 {
 if (this.operational_hour_to!=null)
 return string.Format("'{0}'",operational_hour_to); else
 return "null";
 }
 }
 #endregion
 #region IsOperationalDay
 private bool is_operational_dayChanged = false;
 private bool is_operational_day;
 public bool IsOperationalDay
 {
 get { return is_operational_day; }
 set { 
is_operational_day = value;
is_operational_dayChanged = true;
 }
 }
 private string is_operational_dayDbString
 {
 get
 {
 return is_operational_day?"1":"0";
 }
 }
 #endregion
 #endregion

 #region OperationalHourReader
 public class OperationalHourReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
OperationalHour currentOperationalHour;
 Columns columns;
 bool partialRead = false;
 private OperationalHourReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public OperationalHourReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public OperationalHourReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentOperationalHour; }

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
 currentOperationalHour = new OperationalHour();
 if (partialRead)
 { if ((columns & Columns.operational_hour_id) == Columns.operational_hour_id && reader["operational_hour_id"]!=DBNull.Value)
 currentOperationalHour.operational_hour_id =(int) reader["operational_hour_id"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentOperationalHour.atm_id =(int) reader["atm_id"]; 
 if ((columns & Columns.operational_day_id) == Columns.operational_day_id && reader["operational_day_id"]!=DBNull.Value)
 currentOperationalHour.operational_day_id =(int?) reader["operational_day_id"]; 
 if ((columns & Columns.operational_hour_from) == Columns.operational_hour_from && reader["operational_hour_from"]!=DBNull.Value)
 currentOperationalHour.operational_hour_from =(string) reader["operational_hour_from"]; 
 if ((columns & Columns.operational_hour_to) == Columns.operational_hour_to && reader["operational_hour_to"]!=DBNull.Value)
 currentOperationalHour.operational_hour_to =(string) reader["operational_hour_to"]; 
 if ((columns & Columns.is_operational_day) == Columns.is_operational_day && reader["is_operational_day"]!=DBNull.Value)
 currentOperationalHour.is_operational_day =(bool) reader["is_operational_day"]; 

 } else
 {
 if (reader["operational_hour_id"] != DBNull.Value)
 currentOperationalHour.operational_hour_id = (int) reader["operational_hour_id"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentOperationalHour.atm_id = (int) reader["atm_id"]; 
 if (reader["operational_day_id"] != DBNull.Value)
 currentOperationalHour.operational_day_id = (int?) reader["operational_day_id"]; 
 if (reader["operational_hour_from"] != DBNull.Value)
 currentOperationalHour.operational_hour_from = (string) reader["operational_hour_from"]; 
 if (reader["operational_hour_to"] != DBNull.Value)
 currentOperationalHour.operational_hour_to = (string) reader["operational_hour_to"]; 
 if (reader["is_operational_day"] != DBNull.Value)
 currentOperationalHour.is_operational_day = (bool) reader["is_operational_day"]; 
 } 

 currentOperationalHour.isNewEntity = false;
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

 public OperationalHour CurrentOperationalHour
 {
 get{ return currentOperationalHour; }
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


 #region OperationalHour functions

 public static OperationalHourReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.operational_hour_id == (Columns.operational_hour_id & columns))
 qry.Append("operational_hour_id,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 if (Columns.operational_day_id == (Columns.operational_day_id & columns))
 qry.Append("operational_day_id,");
 if (Columns.operational_hour_from == (Columns.operational_hour_from & columns))
 qry.Append("operational_hour_from,");
 if (Columns.operational_hour_to == (Columns.operational_hour_to & columns))
 qry.Append("operational_hour_to,");
 if (Columns.is_operational_day == (Columns.is_operational_day & columns))
 qry.Append("is_operational_day,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Operational_hour ");

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
 return new OperationalHourReader(cmd.ExecuteReader(), conn, columns);
 }

 static public OperationalHourReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static OperationalHourReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select operational_hour_id,atm_id,operational_day_id,operational_hour_from,operational_hour_to,is_operational_day from Operational_hour ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new OperationalHourReader(cmd.ExecuteReader(), conn);
 }

 static public OperationalHourReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static OperationalHour LoadOperationalHour(string where)
 {
OperationalHourReader reader = OperationalHour.ExecuteReader(where);
OperationalHour _operationalhour = null;
 if (reader.Read())
 _operationalhour = reader.CurrentOperationalHour;
 reader.Close();
 return _operationalhour;
 }

 public static OperationalHour LoadOperationalHour(string where, IDbConnection conn)
 {
OperationalHourReader reader = OperationalHour.ExecuteReader(where, conn);
OperationalHour _operationalhour = null;
 if (reader.Read())
 _operationalhour = reader.CurrentOperationalHour;
 reader.Close(false);
 return _operationalhour;
 }

 public static OperationalHour LoadOperationalHourByPk( int operational_hour_id )
 {
 return LoadOperationalHour( " operational_hour_id="+operational_hour_id );
 }

 public static OperationalHour LoadOperationalHourByPk( int operational_hour_id , IDbConnection conn)
 {
 return LoadOperationalHour(" operational_hour_id="+operational_hour_id , conn);
 }

 public void Save()
 {
 if (operational_hour_idChanged || atm_idChanged || operational_day_idChanged || operational_hour_fromChanged || operational_hour_toChanged || is_operational_dayChanged )
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
 if (operational_hour_idChanged || atm_idChanged || operational_day_idChanged || operational_hour_fromChanged || operational_hour_toChanged || is_operational_dayChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Operational_hour( operational_hour_id,atm_id,operational_day_id,operational_hour_from,operational_hour_to,is_operational_day ) values(");
 lock (ConnectionFactory.connectionString) { this.operational_hour_id = ConnectionFactory.GetNextId();
 qry.Append(this.operational_hour_id);
 } qry.Append(",");
 qry.Append(atm_idDbString+",");
 qry.Append(operational_day_idDbString+",");
 qry.Append(operational_hour_fromDbString+",");
 qry.Append(operational_hour_toDbString+",");
 qry.Append(is_operational_dayDbString);
 qry.Append(");");

 }
 else
 {
 if (!(operational_hour_idChanged || atm_idChanged || operational_day_idChanged || operational_hour_fromChanged || operational_hour_toChanged || is_operational_dayChanged ))
 return;
 qry.Append("UPDATE Operational_hour set "); if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }

 if ( operational_day_idChanged )
 {
 qry.Append("operational_day_id ="+operational_day_idDbString);
 qry.Append(",");
 }

 if ( operational_hour_fromChanged )
 {
 qry.Append("operational_hour_from ="+operational_hour_fromDbString);
 qry.Append(",");
 }

 if ( operational_hour_toChanged )
 {
 qry.Append("operational_hour_to ="+operational_hour_toDbString);
 qry.Append(",");
 }

 if ( is_operational_dayChanged )
 {
 qry.Append("is_operational_day ="+is_operational_dayDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("operational_hour_id = "+operational_hour_idDbString);
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
 cmd.CommandText = "DELETE Operational_hour where operational_hour_id = "+ operational_hour_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteOperationalHours(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Operational_hour where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
operational_hour_id= 1,
atm_id= 2,
operational_day_id= 4,
operational_hour_from= 8,
operational_hour_to= 16,
is_operational_day= 32
 }
 #endregion
 public void BulkSave(List<OperationalHour> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Operational_hour";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(OperationalHour.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <OperationalHour> transList,ref DataTable dt)
 {
 foreach (OperationalHour tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["operational_hour_id"] =ConnectionFactory.GetNextId();
 Row["atm_id"] = tran.AtmId;
 Row["operational_day_id"] = tran.OperationalDayId;
 Row["operational_hour_from"] = tran.OperationalHourFrom;
 Row["operational_hour_to"] = tran.OperationalHourTo;
 Row["is_operational_day"] = tran.IsOperationalDay;
 dt.Rows.Add(Row);
 } }
 }
 }

 
