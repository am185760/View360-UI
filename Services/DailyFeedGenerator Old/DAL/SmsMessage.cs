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
public class SmsMessage
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public SmsMessage() { }
public SmsMessage( int sMS_Message_Id ) 
{
this.sMS_Message_Id = sMS_Message_Id;
this.sMS_Message_IdChanged = true;
}
public SmsMessage( int sMS_Message_Id,string sMS_Module_Source,string sMS_Module_Id,string sMS_Mobile_Number,string sMS_Message,DateTime? sMS_Generated_Date,DateTime? sMS_Sent_Date,int? sMS_Status,int? sMS_Retries )
{
this.sMS_Message_Id = sMS_Message_Id;
this.sMS_Message_IdChanged = true;
this.sMS_Module_Source = sMS_Module_Source;
this.sMS_Module_SourceChanged = true;
this.sMS_Module_Id = sMS_Module_Id;
this.sMS_Module_IdChanged = true;
this.sMS_Mobile_Number = sMS_Mobile_Number;
this.sMS_Mobile_NumberChanged = true;
this.sMS_Message = sMS_Message;
this.sMS_MessageChanged = true;
this.sMS_Generated_Date = sMS_Generated_Date;
this.sMS_Generated_DateChanged = true;
this.sMS_Sent_Date = sMS_Sent_Date;
this.sMS_Sent_DateChanged = true;
this.sMS_Status = sMS_Status;
this.sMS_StatusChanged = true;
this.sMS_Retries = sMS_Retries;
this.sMS_RetriesChanged = true;
}

#region members and properties for columns

#region SMSMessageId
private bool sMS_Message_IdChanged = false;
private int sMS_Message_Id;
public int SMSMessageId
{
get { return sMS_Message_Id; }
set { 
sMS_Message_Id = value;
sMS_Message_IdChanged = true;
}
}
private string sMS_Message_IdDbString
{
get
{
return sMS_Message_Id.ToString();
}
}
#endregion
#region SMSModuleSource
private bool sMS_Module_SourceChanged = false;
private string sMS_Module_Source;
public string SMSModuleSource
{
get { return sMS_Module_Source; }
set { 
sMS_Module_Source = value;
sMS_Module_SourceChanged = true;
}
}
private string sMS_Module_SourceDbString
{
get
{
if (this.sMS_Module_Source!=null)
return string.Format("'{0}'",sMS_Module_Source); else
return "null";
}
}
#endregion
#region SMSModuleId
private bool sMS_Module_IdChanged = false;
private string sMS_Module_Id;
public string SMSModuleId
{
get { return sMS_Module_Id; }
set { 
sMS_Module_Id = value;
sMS_Module_IdChanged = true;
}
}
private string sMS_Module_IdDbString
{
get
{
if (this.sMS_Module_Id!=null)
return string.Format("'{0}'",sMS_Module_Id); else
return "null";
}
}
#endregion
#region SMSMobileNumber
private bool sMS_Mobile_NumberChanged = false;
private string sMS_Mobile_Number;
public string SMSMobileNumber
{
get { return sMS_Mobile_Number; }
set { 
sMS_Mobile_Number = value;
sMS_Mobile_NumberChanged = true;
}
}
private string sMS_Mobile_NumberDbString
{
get
{
if (this.sMS_Mobile_Number!=null)
return string.Format("'{0}'",sMS_Mobile_Number); else
return "null";
}
}
#endregion
#region SMSMessage
private bool sMS_MessageChanged = false;
private string sMS_Message;
public string SMSMessage
{
get { return sMS_Message; }
set { 
sMS_Message = value;
sMS_MessageChanged = true;
}
}
private string sMS_MessageDbString
{
get
{
if (this.sMS_Message!=null)
return string.Format("'{0}'",sMS_Message); else
return "null";
}
}
#endregion
#region SMSGeneratedDate
private bool sMS_Generated_DateChanged = false;
private DateTime? sMS_Generated_Date;
public DateTime? SMSGeneratedDate
{
get { return sMS_Generated_Date; }
set { 
sMS_Generated_Date = value;
sMS_Generated_DateChanged = true;
}
}
private string sMS_Generated_DateDbString
{
get
{
if (this.sMS_Generated_Date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",sMS_Generated_Date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region SMSSentDate
private bool sMS_Sent_DateChanged = false;
private DateTime? sMS_Sent_Date;
public DateTime? SMSSentDate
{
get { return sMS_Sent_Date; }
set { 
sMS_Sent_Date = value;
sMS_Sent_DateChanged = true;
}
}
private string sMS_Sent_DateDbString
{
get
{
if (this.sMS_Sent_Date.HasValue)
return string.Format("Convert(datetime,'{0}',121)",sMS_Sent_Date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region SMSStatus
private bool sMS_StatusChanged = false;
private int? sMS_Status;
public int? SMSStatus
{
get { return sMS_Status; }
set { 
sMS_Status = value;
sMS_StatusChanged = true;
}
}
private string sMS_StatusDbString
{
get
{
if (this.sMS_Status.HasValue)
return sMS_Status.ToString();
else
return "null";
}
}
#endregion
#region SMSRetries
private bool sMS_RetriesChanged = false;
private int? sMS_Retries;
public int? SMSRetries
{
get { return sMS_Retries; }
set { 
sMS_Retries = value;
sMS_RetriesChanged = true;
}
}
private string sMS_RetriesDbString
{
get
{
if (this.sMS_Retries.HasValue)
return sMS_Retries.ToString();
else
return "null";
}
}
#endregion
#endregion

#region SmsMessageReader
public class SmsMessageReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
SmsMessage currentSmsMessage;
Columns columns;
bool partialRead = false;
private SmsMessageReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public SmsMessageReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public SmsMessageReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentSmsMessage; }

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
currentSmsMessage = new SmsMessage();
if (partialRead)
{ if ((columns & Columns.SMS_Message_Id) == Columns.SMS_Message_Id && reader["SMS_Message_Id"]!=DBNull.Value)
currentSmsMessage.sMS_Message_Id =(int) reader["SMS_Message_Id"]; 
if ((columns & Columns.SMS_Module_Source) == Columns.SMS_Module_Source && reader["SMS_Module_Source"]!=DBNull.Value)
currentSmsMessage.sMS_Module_Source =(string) reader["SMS_Module_Source"]; 
if ((columns & Columns.SMS_Module_Id) == Columns.SMS_Module_Id && reader["SMS_Module_Id"]!=DBNull.Value)
currentSmsMessage.sMS_Module_Id =(string) reader["SMS_Module_Id"]; 
if ((columns & Columns.SMS_Mobile_Number) == Columns.SMS_Mobile_Number && reader["SMS_Mobile_Number"]!=DBNull.Value)
currentSmsMessage.sMS_Mobile_Number =(string) reader["SMS_Mobile_Number"]; 
if ((columns & Columns.SMS_Message) == Columns.SMS_Message && reader["SMS_Message"]!=DBNull.Value)
currentSmsMessage.sMS_Message =(string) reader["SMS_Message"]; 
if ((columns & Columns.SMS_Generated_Date) == Columns.SMS_Generated_Date && reader["SMS_Generated_Date"]!=DBNull.Value)
currentSmsMessage.sMS_Generated_Date =(DateTime?) reader["SMS_Generated_Date"]; 
if ((columns & Columns.SMS_Sent_Date) == Columns.SMS_Sent_Date && reader["SMS_Sent_Date"]!=DBNull.Value)
currentSmsMessage.sMS_Sent_Date =(DateTime?) reader["SMS_Sent_Date"]; 
if ((columns & Columns.SMS_Status) == Columns.SMS_Status && reader["SMS_Status"]!=DBNull.Value)
currentSmsMessage.sMS_Status =(int?) reader["SMS_Status"]; 
if ((columns & Columns.SMS_Retries) == Columns.SMS_Retries && reader["SMS_Retries"]!=DBNull.Value)
currentSmsMessage.sMS_Retries =(int?) reader["SMS_Retries"]; 

} else
{
if (reader["SMS_Message_Id"] != DBNull.Value)
currentSmsMessage.sMS_Message_Id = (int) reader["SMS_Message_Id"]; 
if (reader["SMS_Module_Source"] != DBNull.Value)
currentSmsMessage.sMS_Module_Source = (string) reader["SMS_Module_Source"]; 
if (reader["SMS_Module_Id"] != DBNull.Value)
currentSmsMessage.sMS_Module_Id = (string) reader["SMS_Module_Id"]; 
if (reader["SMS_Mobile_Number"] != DBNull.Value)
currentSmsMessage.sMS_Mobile_Number = (string) reader["SMS_Mobile_Number"]; 
if (reader["SMS_Message"] != DBNull.Value)
currentSmsMessage.sMS_Message = (string) reader["SMS_Message"]; 
if (reader["SMS_Generated_Date"] != DBNull.Value)
currentSmsMessage.sMS_Generated_Date = (DateTime?) reader["SMS_Generated_Date"]; 
if (reader["SMS_Sent_Date"] != DBNull.Value)
currentSmsMessage.sMS_Sent_Date = (DateTime?) reader["SMS_Sent_Date"]; 
if (reader["SMS_Status"] != DBNull.Value)
currentSmsMessage.sMS_Status = (int?) reader["SMS_Status"]; 
if (reader["SMS_Retries"] != DBNull.Value)
currentSmsMessage.sMS_Retries = (int?) reader["SMS_Retries"]; 
} 

currentSmsMessage.isNewEntity = false;
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

public SmsMessage CurrentSmsMessage
{
get{ return currentSmsMessage; }
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


#region SmsMessage functions

public static SmsMessageReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.SMS_Message_Id == (Columns.SMS_Message_Id & columns))
qry.Append("SMS_Message_Id,");
if (Columns.SMS_Module_Source == (Columns.SMS_Module_Source & columns))
qry.Append("SMS_Module_Source,");
if (Columns.SMS_Module_Id == (Columns.SMS_Module_Id & columns))
qry.Append("SMS_Module_Id,");
if (Columns.SMS_Mobile_Number == (Columns.SMS_Mobile_Number & columns))
qry.Append("SMS_Mobile_Number,");
if (Columns.SMS_Message == (Columns.SMS_Message & columns))
qry.Append("SMS_Message,");
if (Columns.SMS_Generated_Date == (Columns.SMS_Generated_Date & columns))
qry.Append("SMS_Generated_Date,");
if (Columns.SMS_Sent_Date == (Columns.SMS_Sent_Date & columns))
qry.Append("SMS_Sent_Date,");
if (Columns.SMS_Status == (Columns.SMS_Status & columns))
qry.Append("SMS_Status,");
if (Columns.SMS_Retries == (Columns.SMS_Retries & columns))
qry.Append("SMS_Retries,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Sms_message ");

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
return new SmsMessageReader(cmd.ExecuteReader(), conn, columns);
}

static public SmsMessageReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static SmsMessageReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select SMS_Message_Id,SMS_Module_Source,SMS_Module_Id,SMS_Mobile_Number,SMS_Message,SMS_Generated_Date,SMS_Sent_Date,SMS_Status,SMS_Retries from Sms_message ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new SmsMessageReader(cmd.ExecuteReader(), conn);
}

static public SmsMessageReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static SmsMessage LoadSmsMessage(string where)
{
SmsMessageReader reader = SmsMessage.ExecuteReader(where);
SmsMessage _smsmessage = null;
if (reader.Read())
_smsmessage = reader.CurrentSmsMessage;
reader.Close();
return _smsmessage;
}

public static SmsMessage LoadSmsMessage(string where, IDbConnection conn)
{
SmsMessageReader reader = SmsMessage.ExecuteReader(where, conn);
SmsMessage _smsmessage = null;
if (reader.Read())
_smsmessage = reader.CurrentSmsMessage;
reader.Close(false);
return _smsmessage;
}


public void Save()
{
if (sMS_Message_IdChanged || sMS_Module_SourceChanged || sMS_Module_IdChanged || sMS_Mobile_NumberChanged || sMS_MessageChanged || sMS_Generated_DateChanged || sMS_Sent_DateChanged || sMS_StatusChanged || sMS_RetriesChanged )
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
if (sMS_Message_IdChanged || sMS_Module_SourceChanged || sMS_Module_IdChanged || sMS_Mobile_NumberChanged || sMS_MessageChanged || sMS_Generated_DateChanged || sMS_Sent_DateChanged || sMS_StatusChanged || sMS_RetriesChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Sms_message( SMS_Message_Id,SMS_Module_Source,SMS_Module_Id,SMS_Mobile_Number,SMS_Message,SMS_Generated_Date,SMS_Sent_Date,SMS_Status,SMS_Retries ) values(");
qry.Append(sMS_Message_IdDbString+",");
qry.Append(sMS_Module_SourceDbString+",");
qry.Append(sMS_Module_IdDbString+",");
qry.Append(sMS_Mobile_NumberDbString+",");
qry.Append(sMS_MessageDbString+",");
qry.Append(sMS_Generated_DateDbString+",");
qry.Append(sMS_Sent_DateDbString+",");
qry.Append(sMS_StatusDbString+",");
qry.Append(sMS_RetriesDbString);
qry.Append(");");

}
else
{
throw new Exception("No primary key is defined, can not update Sms_message!");
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
throw new Exception("Could not delete because no primary key is defined");
}

public static void DeleteSmsMessages(string where)
{
ConnectionFactory.ExecuteQuery("delete Sms_message where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
SMS_Message_Id= 1,
SMS_Module_Source= 2,
SMS_Module_Id= 4,
SMS_Mobile_Number= 8,
SMS_Message= 16,
SMS_Generated_Date= 32,
SMS_Sent_Date= 64,
SMS_Status= 128,
SMS_Retries= 256
}
#endregion
public void BulkSave(List<SmsMessage> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Sms_message";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(SmsMessage.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <SmsMessage> transList,ref DataTable dt)
{
foreach (SmsMessage tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["sMS_Message_Id"] = tran.SMSMessageId;
Row["sMS_Module_Source"] = tran.SMSModuleSource;
Row["sMS_Module_Id"] = tran.SMSModuleId;
Row["sMS_Mobile_Number"] = tran.SMSMobileNumber;
Row["sMS_Message"] = tran.SMSMessage;
Row["sMS_Generated_Date"] = tran.SMSGeneratedDate;
Row["sMS_Sent_Date"] = tran.SMSSentDate;
Row["sMS_Status"] = tran.SMSStatus;
Row["sMS_Retries"] = tran.SMSRetries;
dt.Rows.Add(Row);
} }
}
}
