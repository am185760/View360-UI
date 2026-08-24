
 

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
 public class EjParsedDeviceStatus
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public EjParsedDeviceStatus() { }
 public EjParsedDeviceStatus( int ej_parsed_device_status_id ) 
 {
 }
 public EjParsedDeviceStatus( int? ej_parsed_cpm_transaction_id,int? ej_parsed_bna_transaction_id,DateTime? device_status_datetime,string device,string t_code,int? fitness,string m_status,string supplies )
 {
 this.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_id;
 this.ej_parsed_cpm_transaction_idChanged = true;
 this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
 this.ej_parsed_bna_transaction_idChanged = true;
 this.device_status_datetime = device_status_datetime;
 this.device_status_datetimeChanged = true;
 this.device = device;
 this.deviceChanged = true;
 this.t_code = t_code;
 this.t_codeChanged = true;
 this.fitness = fitness;
 this.fitnessChanged = true;
 this.m_status = m_status;
 this.m_statusChanged = true;
 this.supplies = supplies;
 this.suppliesChanged = true;
 }
 private EjParsedDeviceStatus( int ej_parsed_device_status_id,int? ej_parsed_cpm_transaction_id,int? ej_parsed_bna_transaction_id,DateTime? device_status_datetime,string device,string t_code,int? fitness,string m_status,string supplies )
 {
 this.ej_parsed_device_status_id = ej_parsed_device_status_id;
 this.ej_parsed_device_status_idChanged = true;
 this.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_id;
 this.ej_parsed_cpm_transaction_idChanged = true;
 this.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_id;
 this.ej_parsed_bna_transaction_idChanged = true;
 this.device_status_datetime = device_status_datetime;
 this.device_status_datetimeChanged = true;
 this.device = device;
 this.deviceChanged = true;
 this.t_code = t_code;
 this.t_codeChanged = true;
 this.fitness = fitness;
 this.fitnessChanged = true;
 this.m_status = m_status;
 this.m_statusChanged = true;
 this.supplies = supplies;
 this.suppliesChanged = true;
 }

 #region members and properties for columns

 #region EjParsedDeviceStatusId
 private bool ej_parsed_device_status_idChanged = false;
 private int ej_parsed_device_status_id;
 public int EjParsedDeviceStatusId
 {
 get { return ej_parsed_device_status_id; }
 set { 
ej_parsed_device_status_id = value;
ej_parsed_device_status_idChanged = true;
 }
 }
 private string ej_parsed_device_status_idDbString
 {
 get
 {
 return ej_parsed_device_status_id.ToString();
 }
 }
 #endregion
 #region EjParsedCpmTransactionId
 private bool ej_parsed_cpm_transaction_idChanged = false;
 private int? ej_parsed_cpm_transaction_id;
 public int? EjParsedCpmTransactionId
 {
 get { return ej_parsed_cpm_transaction_id; }
 set { 
ej_parsed_cpm_transaction_id = value;
ej_parsed_cpm_transaction_idChanged = true;
 }
 }
 private string ej_parsed_cpm_transaction_idDbString
 {
 get
 {
 if (this.ej_parsed_cpm_transaction_id.HasValue)
 return ej_parsed_cpm_transaction_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region EjParsedBnaTransactionId
 private bool ej_parsed_bna_transaction_idChanged = false;
 private int? ej_parsed_bna_transaction_id;
 public int? EjParsedBnaTransactionId
 {
 get { return ej_parsed_bna_transaction_id; }
 set { 
ej_parsed_bna_transaction_id = value;
ej_parsed_bna_transaction_idChanged = true;
 }
 }
 private string ej_parsed_bna_transaction_idDbString
 {
 get
 {
 if (this.ej_parsed_bna_transaction_id.HasValue)
 return ej_parsed_bna_transaction_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region DeviceStatusDatetime
 private bool device_status_datetimeChanged = false;
 private DateTime? device_status_datetime;
 public DateTime? DeviceStatusDatetime
 {
 get { return device_status_datetime; }
 set { 
device_status_datetime = value;
device_status_datetimeChanged = true;
 }
 }
 private string device_status_datetimeDbString
 {
 get
 {
 if (this.device_status_datetime.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",device_status_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region Device
 private bool deviceChanged = false;
 private string device;
 public string Device
 {
 get { return device; }
 set { 
device = value;
deviceChanged = true;
 }
 }
 private string deviceDbString
 {
 get
 {
 if (this.device!=null)
 return string.Format("'{0}'",device); else
 return "null";
 }
 }
 #endregion
 #region TCode
 private bool t_codeChanged = false;
 private string t_code;
 public string TCode
 {
 get { return t_code; }
 set { 
t_code = value;
t_codeChanged = true;
 }
 }
 private string t_codeDbString
 {
 get
 {
 if (this.t_code!=null)
 return string.Format("'{0}'",t_code); else
 return "null";
 }
 }
 #endregion
 #region Fitness
 private bool fitnessChanged = false;
 private int? fitness;
 public int? Fitness
 {
 get { return fitness; }
 set { 
fitness = value;
fitnessChanged = true;
 }
 }
 private string fitnessDbString
 {
 get
 {
 if (this.fitness.HasValue)
 return fitness.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region MStatus
 private bool m_statusChanged = false;
 private string m_status;
 public string MStatus
 {
 get { return m_status; }
 set { 
m_status = value;
m_statusChanged = true;
 }
 }
 private string m_statusDbString
 {
 get
 {
 if (this.m_status!=null)
 return string.Format("'{0}'",m_status); else
 return "null";
 }
 }
 #endregion
 #region Supplies
 private bool suppliesChanged = false;
 private string supplies;
 public string Supplies
 {
 get { return supplies; }
 set { 
supplies = value;
suppliesChanged = true;
 }
 }
 private string suppliesDbString
 {
 get
 {
 if (this.supplies!=null)
 return string.Format("'{0}'",supplies); else
 return "null";
 }
 }
 #endregion
 #endregion

 #region EjParsedDeviceStatusReader
 public class EjParsedDeviceStatusReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
EjParsedDeviceStatus currentEjParsedDeviceStatus;
 Columns columns;
 bool partialRead = false;
 private EjParsedDeviceStatusReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public EjParsedDeviceStatusReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public EjParsedDeviceStatusReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentEjParsedDeviceStatus; }

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
 currentEjParsedDeviceStatus = new EjParsedDeviceStatus();
 if (partialRead)
 { if ((columns & Columns.ej_parsed_device_status_id) == Columns.ej_parsed_device_status_id && reader["ej_parsed_device_status_id"]!=DBNull.Value)
 currentEjParsedDeviceStatus.ej_parsed_device_status_id =(int) reader["ej_parsed_device_status_id"]; 
 if ((columns & Columns.ej_parsed_cpm_transaction_id) == Columns.ej_parsed_cpm_transaction_id && reader["ej_parsed_cpm_transaction_id"]!=DBNull.Value)
 currentEjParsedDeviceStatus.ej_parsed_cpm_transaction_id =(int?) reader["ej_parsed_cpm_transaction_id"]; 
 if ((columns & Columns.ej_parsed_bna_transaction_id) == Columns.ej_parsed_bna_transaction_id && reader["ej_parsed_bna_transaction_id"]!=DBNull.Value)
 currentEjParsedDeviceStatus.ej_parsed_bna_transaction_id =(int?) reader["ej_parsed_bna_transaction_id"]; 
 if ((columns & Columns.device_status_datetime) == Columns.device_status_datetime && reader["device_status_datetime"]!=DBNull.Value)
 currentEjParsedDeviceStatus.device_status_datetime =(DateTime?) reader["device_status_datetime"]; 
 if ((columns & Columns.device) == Columns.device && reader["device"]!=DBNull.Value)
 currentEjParsedDeviceStatus.device =(string) reader["device"]; 
 if ((columns & Columns.t_code) == Columns.t_code && reader["t_code"]!=DBNull.Value)
 currentEjParsedDeviceStatus.t_code =(string) reader["t_code"]; 
 if ((columns & Columns.fitness) == Columns.fitness && reader["fitness"]!=DBNull.Value)
 currentEjParsedDeviceStatus.fitness =(int?) reader["fitness"]; 
 if ((columns & Columns.m_status) == Columns.m_status && reader["m_status"]!=DBNull.Value)
 currentEjParsedDeviceStatus.m_status =(string) reader["m_status"]; 
 if ((columns & Columns.supplies) == Columns.supplies && reader["supplies"]!=DBNull.Value)
 currentEjParsedDeviceStatus.supplies =(string) reader["supplies"]; 

 } else
 {
 if (reader["ej_parsed_device_status_id"] != DBNull.Value)
 currentEjParsedDeviceStatus.ej_parsed_device_status_id = (int) reader["ej_parsed_device_status_id"]; 
 if (reader["ej_parsed_cpm_transaction_id"] != DBNull.Value)
 currentEjParsedDeviceStatus.ej_parsed_cpm_transaction_id = (int?) reader["ej_parsed_cpm_transaction_id"]; 
 if (reader["ej_parsed_bna_transaction_id"] != DBNull.Value)
 currentEjParsedDeviceStatus.ej_parsed_bna_transaction_id = (int?) reader["ej_parsed_bna_transaction_id"]; 
 if (reader["device_status_datetime"] != DBNull.Value)
 currentEjParsedDeviceStatus.device_status_datetime = (DateTime?) reader["device_status_datetime"]; 
 if (reader["device"] != DBNull.Value)
 currentEjParsedDeviceStatus.device = (string) reader["device"]; 
 if (reader["t_code"] != DBNull.Value)
 currentEjParsedDeviceStatus.t_code = (string) reader["t_code"]; 
 if (reader["fitness"] != DBNull.Value)
 currentEjParsedDeviceStatus.fitness = (int?) reader["fitness"]; 
 if (reader["m_status"] != DBNull.Value)
 currentEjParsedDeviceStatus.m_status = (string) reader["m_status"]; 
 if (reader["supplies"] != DBNull.Value)
 currentEjParsedDeviceStatus.supplies = (string) reader["supplies"]; 
 } 

 currentEjParsedDeviceStatus.isNewEntity = false;
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

 public EjParsedDeviceStatus CurrentEjParsedDeviceStatus
 {
 get{ return currentEjParsedDeviceStatus; }
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


 #region EjParsedDeviceStatus functions

 public static EjParsedDeviceStatusReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.ej_parsed_device_status_id == (Columns.ej_parsed_device_status_id & columns))
 qry.Append("ej_parsed_device_status_id,");
 if (Columns.ej_parsed_cpm_transaction_id == (Columns.ej_parsed_cpm_transaction_id & columns))
 qry.Append("ej_parsed_cpm_transaction_id,");
 if (Columns.ej_parsed_bna_transaction_id == (Columns.ej_parsed_bna_transaction_id & columns))
 qry.Append("ej_parsed_bna_transaction_id,");
 if (Columns.device_status_datetime == (Columns.device_status_datetime & columns))
 qry.Append("device_status_datetime,");
 if (Columns.device == (Columns.device & columns))
 qry.Append("device,");
 if (Columns.t_code == (Columns.t_code & columns))
 qry.Append("t_code,");
 if (Columns.fitness == (Columns.fitness & columns))
 qry.Append("fitness,");
 if (Columns.m_status == (Columns.m_status & columns))
 qry.Append("m_status,");
 if (Columns.supplies == (Columns.supplies & columns))
 qry.Append("supplies,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Ej_parsed_device_status ");

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
 return new EjParsedDeviceStatusReader(cmd.ExecuteReader(), conn, columns);
 }

 static public EjParsedDeviceStatusReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static EjParsedDeviceStatusReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select ej_parsed_device_status_id,ej_parsed_cpm_transaction_id,ej_parsed_bna_transaction_id,device_status_datetime,device,t_code,fitness,m_status,supplies from Ej_parsed_device_status ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new EjParsedDeviceStatusReader(cmd.ExecuteReader(), conn);
 }

 static public EjParsedDeviceStatusReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static EjParsedDeviceStatus LoadEjParsedDeviceStatus(string where)
 {
EjParsedDeviceStatusReader reader = EjParsedDeviceStatus.ExecuteReader(where);
EjParsedDeviceStatus _ejparseddevicestatus = null;
 if (reader.Read())
 _ejparseddevicestatus = reader.CurrentEjParsedDeviceStatus;
 reader.Close();
 return _ejparseddevicestatus;
 }

 public static EjParsedDeviceStatus LoadEjParsedDeviceStatus(string where, IDbConnection conn)
 {
EjParsedDeviceStatusReader reader = EjParsedDeviceStatus.ExecuteReader(where, conn);
EjParsedDeviceStatus _ejparseddevicestatus = null;
 if (reader.Read())
 _ejparseddevicestatus = reader.CurrentEjParsedDeviceStatus;
 reader.Close(false);
 return _ejparseddevicestatus;
 }

 public static EjParsedDeviceStatus LoadEjParsedDeviceStatusByPk( int ej_parsed_device_status_id )
 {
 return LoadEjParsedDeviceStatus( " ej_parsed_device_status_id="+ej_parsed_device_status_id );
 }

 public static EjParsedDeviceStatus LoadEjParsedDeviceStatusByPk( int ej_parsed_device_status_id , IDbConnection conn)
 {
 return LoadEjParsedDeviceStatus(" ej_parsed_device_status_id="+ej_parsed_device_status_id , conn);
 }

 public void Save()
 {
 if (ej_parsed_device_status_idChanged || ej_parsed_cpm_transaction_idChanged || ej_parsed_bna_transaction_idChanged || device_status_datetimeChanged || deviceChanged || t_codeChanged || fitnessChanged || m_statusChanged || suppliesChanged )
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
 if (ej_parsed_device_status_idChanged || ej_parsed_cpm_transaction_idChanged || ej_parsed_bna_transaction_idChanged || device_status_datetimeChanged || deviceChanged || t_codeChanged || fitnessChanged || m_statusChanged || suppliesChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Ej_parsed_device_status( ej_parsed_device_status_id,ej_parsed_cpm_transaction_id,ej_parsed_bna_transaction_id,device_status_datetime,device,t_code,fitness,m_status,supplies ) values(");
 lock (ConnectionFactory.connectionString) { this.ej_parsed_device_status_id = ConnectionFactory.GetNextId();
 qry.Append(this.ej_parsed_device_status_id);
 } qry.Append(",");
 qry.Append(ej_parsed_cpm_transaction_idDbString+",");
 qry.Append(ej_parsed_bna_transaction_idDbString+",");
 qry.Append(device_status_datetimeDbString+",");
 qry.Append(deviceDbString+",");
 qry.Append(t_codeDbString+",");
 qry.Append(fitnessDbString+",");
 qry.Append(m_statusDbString+",");
 qry.Append(suppliesDbString);
 qry.Append(");");

 }
 else
 {
 if (!(ej_parsed_device_status_idChanged || ej_parsed_cpm_transaction_idChanged || ej_parsed_bna_transaction_idChanged || device_status_datetimeChanged || deviceChanged || t_codeChanged || fitnessChanged || m_statusChanged || suppliesChanged ))
 return;
 qry.Append("UPDATE Ej_parsed_device_status set "); if ( ej_parsed_cpm_transaction_idChanged )
 {
 qry.Append("ej_parsed_cpm_transaction_id ="+ej_parsed_cpm_transaction_idDbString);
 qry.Append(",");
 }

 if ( ej_parsed_bna_transaction_idChanged )
 {
 qry.Append("ej_parsed_bna_transaction_id ="+ej_parsed_bna_transaction_idDbString);
 qry.Append(",");
 }

 if ( device_status_datetimeChanged )
 {
 qry.Append("device_status_datetime ="+device_status_datetimeDbString);
 qry.Append(",");
 }

 if ( deviceChanged )
 {
 qry.Append("device ="+deviceDbString);
 qry.Append(",");
 }

 if ( t_codeChanged )
 {
 qry.Append("t_code ="+t_codeDbString);
 qry.Append(",");
 }

 if ( fitnessChanged )
 {
 qry.Append("fitness ="+fitnessDbString);
 qry.Append(",");
 }

 if ( m_statusChanged )
 {
 qry.Append("m_status ="+m_statusDbString);
 qry.Append(",");
 }

 if ( suppliesChanged )
 {
 qry.Append("supplies ="+suppliesDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("ej_parsed_device_status_id = "+ej_parsed_device_status_idDbString);
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
 cmd.CommandText = "DELETE Ej_parsed_device_status where ej_parsed_device_status_id = "+ ej_parsed_device_status_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteEjParsedDeviceStatuss(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Ej_parsed_device_status where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
ej_parsed_device_status_id= 1,
ej_parsed_cpm_transaction_id= 2,
ej_parsed_bna_transaction_id= 4,
device_status_datetime= 8,
device= 16,
t_code= 32,
fitness= 64,
m_status= 128,
supplies= 256
 }
 #endregion
 public void BulkSave(List<EjParsedDeviceStatus> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Ej_parsed_device_status";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(EjParsedDeviceStatus.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <EjParsedDeviceStatus> transList,ref DataTable dt)
 {
 foreach (EjParsedDeviceStatus tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["ej_parsed_device_status_id"] =ConnectionFactory.GetNextId();
 Row["ej_parsed_cpm_transaction_id"] = tran.EjParsedCpmTransactionId;
 Row["ej_parsed_bna_transaction_id"] = tran.EjParsedBnaTransactionId;
 Row["device_status_datetime"] = tran.DeviceStatusDatetime;
 Row["device"] = tran.Device;
 Row["t_code"] = tran.TCode;
 Row["fitness"] = tran.Fitness;
 Row["m_status"] = tran.MStatus;
 Row["supplies"] = tran.Supplies;
 dt.Rows.Add(Row);
 } }
 }
 }

 


