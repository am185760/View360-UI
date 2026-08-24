
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
 public class AppUser
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public AppUser() { }
 public AppUser( int user_id,string user_login,string user_full_name,int user_created_by,DateTime user_creation_time,bool user_is_active,bool is_active_directory_user,bool is_deleted,bool is_editied,bool is_added ) 
 {
 this.user_login = user_login;
 this.user_loginChanged = true;
 this.user_full_name = user_full_name;
 this.user_full_nameChanged = true;
 this.user_created_by = user_created_by;
 this.user_created_byChanged = true;
 this.user_creation_time = user_creation_time;
 this.user_creation_timeChanged = true;
 this.user_is_active = user_is_active;
 this.user_is_activeChanged = true;
 this.is_active_directory_user = is_active_directory_user;
 this.is_active_directory_userChanged = true;
 this.is_deleted = is_deleted;
 this.is_deletedChanged = true;
 this.is_editied = is_editied;
 this.is_editiedChanged = true;
 this.is_added = is_added;
 this.is_addedChanged = true;
 }
 public AppUser( string user_login,string user_password,string user_full_name,DateTime? user_last_login_time,int user_created_by,DateTime user_creation_time,int? user_modified_by,DateTime? user_modification_time,bool user_is_active,string user_email,int? cit_id,string user_type,int? manager_id,bool is_active_directory_user,int? employee_manager_id,string mobile_number,int? retry_attempt,string approval_status,bool is_deleted,bool is_editied,bool is_added )
 {
 this.user_login = user_login;
 this.user_loginChanged = true;
 this.user_password = user_password;
 this.user_passwordChanged = true;
 this.user_full_name = user_full_name;
 this.user_full_nameChanged = true;
 this.user_last_login_time = user_last_login_time;
 this.user_last_login_timeChanged = true;
 this.user_created_by = user_created_by;
 this.user_created_byChanged = true;
 this.user_creation_time = user_creation_time;
 this.user_creation_timeChanged = true;
 this.user_modified_by = user_modified_by;
 this.user_modified_byChanged = true;
 this.user_modification_time = user_modification_time;
 this.user_modification_timeChanged = true;
 this.user_is_active = user_is_active;
 this.user_is_activeChanged = true;
 this.user_email = user_email;
 this.user_emailChanged = true;
 this.cit_id = cit_id;
 this.cit_idChanged = true;
 this.user_type = user_type;
 this.user_typeChanged = true;
 this.manager_id = manager_id;
 this.manager_idChanged = true;
 this.is_active_directory_user = is_active_directory_user;
 this.is_active_directory_userChanged = true;
 this.employee_manager_id = employee_manager_id;
 this.employee_manager_idChanged = true;
 this.mobile_number = mobile_number;
 this.mobile_numberChanged = true;
 this.retry_attempt = retry_attempt;
 this.retry_attemptChanged = true;
 this.approval_status = approval_status;
 this.approval_statusChanged = true;
 this.is_deleted = is_deleted;
 this.is_deletedChanged = true;
 this.is_editied = is_editied;
 this.is_editiedChanged = true;
 this.is_added = is_added;
 this.is_addedChanged = true;
 }
 private AppUser( int user_id,string user_login,string user_password,string user_full_name,DateTime? user_last_login_time,int user_created_by,DateTime user_creation_time,int? user_modified_by,DateTime? user_modification_time,bool user_is_active,string user_email,int? cit_id,string user_type,int? manager_id,bool is_active_directory_user,int? employee_manager_id,string mobile_number,int? retry_attempt,string approval_status,bool is_deleted,bool is_editied,bool is_added )
 {
 this.user_id = user_id;
 this.user_idChanged = true;
 this.user_login = user_login;
 this.user_loginChanged = true;
 this.user_password = user_password;
 this.user_passwordChanged = true;
 this.user_full_name = user_full_name;
 this.user_full_nameChanged = true;
 this.user_last_login_time = user_last_login_time;
 this.user_last_login_timeChanged = true;
 this.user_created_by = user_created_by;
 this.user_created_byChanged = true;
 this.user_creation_time = user_creation_time;
 this.user_creation_timeChanged = true;
 this.user_modified_by = user_modified_by;
 this.user_modified_byChanged = true;
 this.user_modification_time = user_modification_time;
 this.user_modification_timeChanged = true;
 this.user_is_active = user_is_active;
 this.user_is_activeChanged = true;
 this.user_email = user_email;
 this.user_emailChanged = true;
 this.cit_id = cit_id;
 this.cit_idChanged = true;
 this.user_type = user_type;
 this.user_typeChanged = true;
 this.manager_id = manager_id;
 this.manager_idChanged = true;
 this.is_active_directory_user = is_active_directory_user;
 this.is_active_directory_userChanged = true;
 this.employee_manager_id = employee_manager_id;
 this.employee_manager_idChanged = true;
 this.mobile_number = mobile_number;
 this.mobile_numberChanged = true;
 this.retry_attempt = retry_attempt;
 this.retry_attemptChanged = true;
 this.approval_status = approval_status;
 this.approval_statusChanged = true;
 this.is_deleted = is_deleted;
 this.is_deletedChanged = true;
 this.is_editied = is_editied;
 this.is_editiedChanged = true;
 this.is_added = is_added;
 this.is_addedChanged = true;
 }

 #region members and properties for columns

 #region UserId
 private bool user_idChanged = false;
 private int user_id;
 public int UserId
 {
 get { return user_id; }
 set { 
user_id = value;
user_idChanged = true;
 }
 }
 private string user_idDbString
 {
 get
 {
 return user_id.ToString();
 }
 }
 #endregion
 #region UserLogin
 private bool user_loginChanged = false;
 private string user_login;
 public string UserLogin
 {
 get { return user_login; }
 set { 
user_login = value;
user_loginChanged = true;
 }
 }
 private string user_loginDbString
 {
 get
 {
 if (this.user_login!=null)
 return string.Format("'{0}'",user_login); else
 return "null";
 }
 }
 #endregion
 #region UserPassword
 private bool user_passwordChanged = false;
 private string user_password;
 public string UserPassword
 {
 get { return user_password; }
 set { 
user_password = value;
user_passwordChanged = true;
 }
 }
 private string user_passwordDbString
 {
 get
 {
 if (this.user_password!=null)
 return string.Format("'{0}'",user_password); else
 return "null";
 }
 }
 #endregion
 #region UserFullName
 private bool user_full_nameChanged = false;
 private string user_full_name;
 public string UserFullName
 {
 get { return user_full_name; }
 set { 
user_full_name = value;
user_full_nameChanged = true;
 }
 }
 private string user_full_nameDbString
 {
 get
 {
 if (this.user_full_name!=null)
 return string.Format("'{0}'",user_full_name); else
 return "null";
 }
 }
 #endregion
 #region UserLastLoginTime
 private bool user_last_login_timeChanged = false;
 private DateTime? user_last_login_time;
 public DateTime? UserLastLoginTime
 {
 get { return user_last_login_time; }
 set { 
user_last_login_time = value;
user_last_login_timeChanged = true;
 }
 }
 private string user_last_login_timeDbString
 {
 get
 {
 if (this.user_last_login_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",user_last_login_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region UserCreatedBy
 private bool user_created_byChanged = false;
 private int user_created_by;
 public int UserCreatedBy
 {
 get { return user_created_by; }
 set { 
user_created_by = value;
user_created_byChanged = true;
 }
 }
 private string user_created_byDbString
 {
 get
 {
 return user_created_by.ToString();
 }
 }
 #endregion
 #region UserCreationTime
 private bool user_creation_timeChanged = false;
 private DateTime user_creation_time;
 public DateTime UserCreationTime
 {
 get { return user_creation_time; }
 set { 
user_creation_time = value;
user_creation_timeChanged = true;
 }
 }
 private string user_creation_timeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",user_creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region UserModifiedBy
 private bool user_modified_byChanged = false;
 private int? user_modified_by;
 public int? UserModifiedBy
 {
 get { return user_modified_by; }
 set { 
user_modified_by = value;
user_modified_byChanged = true;
 }
 }
 private string user_modified_byDbString
 {
 get
 {
 if (this.user_modified_by.HasValue)
 return user_modified_by.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region UserModificationTime
 private bool user_modification_timeChanged = false;
 private DateTime? user_modification_time;
 public DateTime? UserModificationTime
 {
 get { return user_modification_time; }
 set { 
user_modification_time = value;
user_modification_timeChanged = true;
 }
 }
 private string user_modification_timeDbString
 {
 get
 {
 if (this.user_modification_time.HasValue)
 return string.Format("Convert(datetime,'{0}',121)",user_modification_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 else
 return "null";
 }
 }
 #endregion
 #region UserIsActive
 private bool user_is_activeChanged = false;
 private bool user_is_active;
 public bool UserIsActive
 {
 get { return user_is_active; }
 set { 
user_is_active = value;
user_is_activeChanged = true;
 }
 }
 private string user_is_activeDbString
 {
 get
 {
 return user_is_active?"1":"0";
 }
 }
 #endregion
 #region UserEmail
 private bool user_emailChanged = false;
 private string user_email;
 public string UserEmail
 {
 get { return user_email; }
 set { 
user_email = value;
user_emailChanged = true;
 }
 }
 private string user_emailDbString
 {
 get
 {
 if (this.user_email!=null)
 return string.Format("'{0}'",user_email); else
 return "null";
 }
 }
 #endregion
 #region CitId
 private bool cit_idChanged = false;
 private int? cit_id;
 public int? CitId
 {
 get { return cit_id; }
 set { 
cit_id = value;
cit_idChanged = true;
 }
 }
 private string cit_idDbString
 {
 get
 {
 if (this.cit_id.HasValue)
 return cit_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region UserType
 private bool user_typeChanged = false;
 private string user_type;
 public string UserType
 {
 get { return user_type; }
 set { 
user_type = value;
user_typeChanged = true;
 }
 }
 private string user_typeDbString
 {
 get
 {
 if (this.user_type!=null)
 return string.Format("'{0}'",user_type); else
 return "null";
 }
 }
 #endregion
 #region ManagerId
 private bool manager_idChanged = false;
 private int? manager_id;
 public int? ManagerId
 {
 get { return manager_id; }
 set { 
manager_id = value;
manager_idChanged = true;
 }
 }
 private string manager_idDbString
 {
 get
 {
 if (this.manager_id.HasValue)
 return manager_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region IsActiveDirectoryUser
 private bool is_active_directory_userChanged = false;
 private bool is_active_directory_user;
 public bool IsActiveDirectoryUser
 {
 get { return is_active_directory_user; }
 set { 
is_active_directory_user = value;
is_active_directory_userChanged = true;
 }
 }
 private string is_active_directory_userDbString
 {
 get
 {
 return is_active_directory_user?"1":"0";
 }
 }
 #endregion
 #region EmployeeManagerId
 private bool employee_manager_idChanged = false;
 private int? employee_manager_id;
 public int? EmployeeManagerId
 {
 get { return employee_manager_id; }
 set { 
employee_manager_id = value;
employee_manager_idChanged = true;
 }
 }
 private string employee_manager_idDbString
 {
 get
 {
 if (this.employee_manager_id.HasValue)
 return employee_manager_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region MobileNumber
 private bool mobile_numberChanged = false;
 private string mobile_number;
 public string MobileNumber
 {
 get { return mobile_number; }
 set { 
mobile_number = value;
mobile_numberChanged = true;
 }
 }
 private string mobile_numberDbString
 {
 get
 {
 if (this.mobile_number!=null)
 return string.Format("'{0}'",mobile_number); else
 return "null";
 }
 }
 #endregion
 #region RetryAttempt
 private bool retry_attemptChanged = false;
 private int? retry_attempt;
 public int? RetryAttempt
 {
 get { return retry_attempt; }
 set { 
retry_attempt = value;
retry_attemptChanged = true;
 }
 }
 private string retry_attemptDbString
 {
 get
 {
 if (this.retry_attempt.HasValue)
 return retry_attempt.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region ApprovalStatus
 private bool approval_statusChanged = false;
 private string approval_status;
 public string ApprovalStatus
 {
 get { return approval_status; }
 set { 
approval_status = value;
approval_statusChanged = true;
 }
 }
 private string approval_statusDbString
 {
 get
 {
 if (this.approval_status!=null)
 return string.Format("'{0}'",approval_status); else
 return "null";
 }
 }
 #endregion
 #region IsDeleted
 private bool is_deletedChanged = false;
 private bool is_deleted;
 public bool IsDeleted
 {
 get { return is_deleted; }
 set { 
is_deleted = value;
is_deletedChanged = true;
 }
 }
 private string is_deletedDbString
 {
 get
 {
 return is_deleted?"1":"0";
 }
 }
 #endregion
 #region IsEditied
 private bool is_editiedChanged = false;
 private bool is_editied;
 public bool IsEditied
 {
 get { return is_editied; }
 set { 
is_editied = value;
is_editiedChanged = true;
 }
 }
 private string is_editiedDbString
 {
 get
 {
 return is_editied?"1":"0";
 }
 }
 #endregion
 #region IsAdded
 private bool is_addedChanged = false;
 private bool is_added;
 public bool IsAdded
 {
 get { return is_added; }
 set { 
is_added = value;
is_addedChanged = true;
 }
 }
 private string is_addedDbString
 {
 get
 {
 return is_added?"1":"0";
 }
 }
 #endregion
 #endregion

 #region AppUserReader
 public class AppUserReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
AppUser currentAppUser;
 Columns columns;
 bool partialRead = false;
 private AppUserReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public AppUserReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public AppUserReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentAppUser; }

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
 currentAppUser = new AppUser();
 if (partialRead)
 { if ((columns & Columns.user_id) == Columns.user_id && reader["user_id"]!=DBNull.Value)
 currentAppUser.user_id =(int) reader["user_id"]; 
 if ((columns & Columns.user_login) == Columns.user_login && reader["user_login"]!=DBNull.Value)
 currentAppUser.user_login =(string) reader["user_login"]; 
 if ((columns & Columns.user_password) == Columns.user_password && reader["user_password"]!=DBNull.Value)
 currentAppUser.user_password =(string) reader["user_password"]; 
 if ((columns & Columns.user_full_name) == Columns.user_full_name && reader["user_full_name"]!=DBNull.Value)
 currentAppUser.user_full_name =(string) reader["user_full_name"]; 
 if ((columns & Columns.user_last_login_time) == Columns.user_last_login_time && reader["user_last_login_time"]!=DBNull.Value)
 currentAppUser.user_last_login_time =(DateTime?) reader["user_last_login_time"]; 
 if ((columns & Columns.user_created_by) == Columns.user_created_by && reader["user_created_by"]!=DBNull.Value)
 currentAppUser.user_created_by =(int) reader["user_created_by"]; 
 if ((columns & Columns.user_creation_time) == Columns.user_creation_time && reader["user_creation_time"]!=DBNull.Value)
 currentAppUser.user_creation_time =(DateTime) reader["user_creation_time"]; 
 if ((columns & Columns.user_modified_by) == Columns.user_modified_by && reader["user_modified_by"]!=DBNull.Value)
 currentAppUser.user_modified_by =(int?) reader["user_modified_by"]; 
 if ((columns & Columns.user_modification_time) == Columns.user_modification_time && reader["user_modification_time"]!=DBNull.Value)
 currentAppUser.user_modification_time =(DateTime?) reader["user_modification_time"]; 
 if ((columns & Columns.user_is_active) == Columns.user_is_active && reader["user_is_active"]!=DBNull.Value)
 currentAppUser.user_is_active =(bool) reader["user_is_active"]; 
 if ((columns & Columns.user_email) == Columns.user_email && reader["user_email"]!=DBNull.Value)
 currentAppUser.user_email =(string) reader["user_email"]; 
 if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
 currentAppUser.cit_id =(int?) reader["cit_id"]; 
 if ((columns & Columns.user_type) == Columns.user_type && reader["user_type"]!=DBNull.Value)
 currentAppUser.user_type =(string) reader["user_type"]; 
 if ((columns & Columns.manager_id) == Columns.manager_id && reader["manager_id"]!=DBNull.Value)
 currentAppUser.manager_id =(int?) reader["manager_id"]; 
 if ((columns & Columns.is_active_directory_user) == Columns.is_active_directory_user && reader["is_active_directory_user"]!=DBNull.Value)
 currentAppUser.is_active_directory_user =(bool) reader["is_active_directory_user"]; 
 if ((columns & Columns.employee_manager_id) == Columns.employee_manager_id && reader["employee_manager_id"]!=DBNull.Value)
 currentAppUser.employee_manager_id =(int?) reader["employee_manager_id"]; 
 if ((columns & Columns.mobile_number) == Columns.mobile_number && reader["mobile_number"]!=DBNull.Value)
 currentAppUser.mobile_number =(string) reader["mobile_number"]; 
 if ((columns & Columns.retry_attempt) == Columns.retry_attempt && reader["retry_attempt"]!=DBNull.Value)
 currentAppUser.retry_attempt =(int?) reader["retry_attempt"]; 
 if ((columns & Columns.approval_status) == Columns.approval_status && reader["approval_status"]!=DBNull.Value)
 currentAppUser.approval_status =(string) reader["approval_status"]; 
 if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
 currentAppUser.is_deleted =(bool) reader["is_deleted"]; 
 if ((columns & Columns.is_editied) == Columns.is_editied && reader["is_editied"]!=DBNull.Value)
 currentAppUser.is_editied =(bool) reader["is_editied"]; 
 if ((columns & Columns.is_added) == Columns.is_added && reader["is_added"]!=DBNull.Value)
 currentAppUser.is_added =(bool) reader["is_added"]; 

 } else
 {
 if (reader["user_id"] != DBNull.Value)
 currentAppUser.user_id = (int) reader["user_id"]; 
 if (reader["user_login"] != DBNull.Value)
 currentAppUser.user_login = (string) reader["user_login"]; 
 if (reader["user_password"] != DBNull.Value)
 currentAppUser.user_password = (string) reader["user_password"]; 
 if (reader["user_full_name"] != DBNull.Value)
 currentAppUser.user_full_name = (string) reader["user_full_name"]; 
 if (reader["user_last_login_time"] != DBNull.Value)
 currentAppUser.user_last_login_time = (DateTime?) reader["user_last_login_time"]; 
 if (reader["user_created_by"] != DBNull.Value)
 currentAppUser.user_created_by = (int) reader["user_created_by"]; 
 if (reader["user_creation_time"] != DBNull.Value)
 currentAppUser.user_creation_time = (DateTime) reader["user_creation_time"]; 
 if (reader["user_modified_by"] != DBNull.Value)
 currentAppUser.user_modified_by = (int?) reader["user_modified_by"]; 
 if (reader["user_modification_time"] != DBNull.Value)
 currentAppUser.user_modification_time = (DateTime?) reader["user_modification_time"]; 
 if (reader["user_is_active"] != DBNull.Value)
 currentAppUser.user_is_active = (bool) reader["user_is_active"]; 
 if (reader["user_email"] != DBNull.Value)
 currentAppUser.user_email = (string) reader["user_email"]; 
 if (reader["cit_id"] != DBNull.Value)
 currentAppUser.cit_id = (int?) reader["cit_id"]; 
 if (reader["user_type"] != DBNull.Value)
 currentAppUser.user_type = (string) reader["user_type"]; 
 if (reader["manager_id"] != DBNull.Value)
 currentAppUser.manager_id = (int?) reader["manager_id"]; 
 if (reader["is_active_directory_user"] != DBNull.Value)
 currentAppUser.is_active_directory_user = (bool) reader["is_active_directory_user"]; 
 if (reader["employee_manager_id"] != DBNull.Value)
 currentAppUser.employee_manager_id = (int?) reader["employee_manager_id"]; 
 if (reader["mobile_number"] != DBNull.Value)
 currentAppUser.mobile_number = (string) reader["mobile_number"]; 
 if (reader["retry_attempt"] != DBNull.Value)
 currentAppUser.retry_attempt = (int?) reader["retry_attempt"]; 
 if (reader["approval_status"] != DBNull.Value)
 currentAppUser.approval_status = (string) reader["approval_status"]; 
 if (reader["is_deleted"] != DBNull.Value)
 currentAppUser.is_deleted = (bool) reader["is_deleted"]; 
 if (reader["is_editied"] != DBNull.Value)
 currentAppUser.is_editied = (bool) reader["is_editied"]; 
 if (reader["is_added"] != DBNull.Value)
 currentAppUser.is_added = (bool) reader["is_added"]; 
 } 

 currentAppUser.isNewEntity = false;
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

 public AppUser CurrentAppUser
 {
 get{ return currentAppUser; }
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


 #region AppUser functions

 public static AppUserReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.user_id == (Columns.user_id & columns))
 qry.Append("user_id,");
 if (Columns.user_login == (Columns.user_login & columns))
 qry.Append("user_login,");
 if (Columns.user_password == (Columns.user_password & columns))
 qry.Append("user_password,");
 if (Columns.user_full_name == (Columns.user_full_name & columns))
 qry.Append("user_full_name,");
 if (Columns.user_last_login_time == (Columns.user_last_login_time & columns))
 qry.Append("user_last_login_time,");
 if (Columns.user_created_by == (Columns.user_created_by & columns))
 qry.Append("user_created_by,");
 if (Columns.user_creation_time == (Columns.user_creation_time & columns))
 qry.Append("user_creation_time,");
 if (Columns.user_modified_by == (Columns.user_modified_by & columns))
 qry.Append("user_modified_by,");
 if (Columns.user_modification_time == (Columns.user_modification_time & columns))
 qry.Append("user_modification_time,");
 if (Columns.user_is_active == (Columns.user_is_active & columns))
 qry.Append("user_is_active,");
 if (Columns.user_email == (Columns.user_email & columns))
 qry.Append("user_email,");
 if (Columns.cit_id == (Columns.cit_id & columns))
 qry.Append("cit_id,");
 if (Columns.user_type == (Columns.user_type & columns))
 qry.Append("user_type,");
 if (Columns.manager_id == (Columns.manager_id & columns))
 qry.Append("manager_id,");
 if (Columns.is_active_directory_user == (Columns.is_active_directory_user & columns))
 qry.Append("is_active_directory_user,");
 if (Columns.employee_manager_id == (Columns.employee_manager_id & columns))
 qry.Append("employee_manager_id,");
 if (Columns.mobile_number == (Columns.mobile_number & columns))
 qry.Append("mobile_number,");
 if (Columns.retry_attempt == (Columns.retry_attempt & columns))
 qry.Append("retry_attempt,");
 if (Columns.approval_status == (Columns.approval_status & columns))
 qry.Append("approval_status,");
 if (Columns.is_deleted == (Columns.is_deleted & columns))
 qry.Append("is_deleted,");
 if (Columns.is_editied == (Columns.is_editied & columns))
 qry.Append("is_editied,");
 if (Columns.is_added == (Columns.is_added & columns))
 qry.Append("is_added,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from App_user ");

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
 return new AppUserReader(cmd.ExecuteReader(), conn, columns);
 }

 static public AppUserReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static AppUserReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select user_id,user_login,user_password,user_full_name,user_last_login_time,user_created_by,user_creation_time,user_modified_by,user_modification_time,user_is_active,user_email,cit_id,user_type,manager_id,is_active_directory_user,employee_manager_id,mobile_number,retry_attempt,approval_status,is_deleted,is_editied,is_added from App_user ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new AppUserReader(cmd.ExecuteReader(), conn);
 }

 static public AppUserReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static AppUser LoadAppUser(string where)
 {
AppUserReader reader = AppUser.ExecuteReader(where);
AppUser _appuser = null;
 if (reader.Read())
 _appuser = reader.CurrentAppUser;
 reader.Close();
 return _appuser;
 }

 public static AppUser LoadAppUser(string where, IDbConnection conn)
 {
AppUserReader reader = AppUser.ExecuteReader(where, conn);
AppUser _appuser = null;
 if (reader.Read())
 _appuser = reader.CurrentAppUser;
 reader.Close(false);
 return _appuser;
 }

 public static AppUser LoadAppUserByPk( int user_id )
 {
 return LoadAppUser( " user_id="+user_id );
 }

 public static AppUser LoadAppUserByUserLogin(string user_login)
 {
     return LoadAppUser(" user_login='" + user_login + "'");
 }

 public static AppUser LoadAppUserByPk( int user_id , IDbConnection conn)
 {
 return LoadAppUser(" user_id="+user_id , conn);
 }

 public void Save()
 {
 if (user_idChanged || user_loginChanged || user_passwordChanged || user_full_nameChanged || user_last_login_timeChanged || user_created_byChanged || user_creation_timeChanged || user_modified_byChanged || user_modification_timeChanged || user_is_activeChanged || user_emailChanged || cit_idChanged || user_typeChanged || manager_idChanged || is_active_directory_userChanged || employee_manager_idChanged || mobile_numberChanged || retry_attemptChanged || approval_statusChanged || is_deletedChanged || is_editiedChanged || is_addedChanged )
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
 if (user_idChanged || user_loginChanged || user_passwordChanged || user_full_nameChanged || user_last_login_timeChanged || user_created_byChanged || user_creation_timeChanged || user_modified_byChanged || user_modification_timeChanged || user_is_activeChanged || user_emailChanged || cit_idChanged || user_typeChanged || manager_idChanged || is_active_directory_userChanged || employee_manager_idChanged || mobile_numberChanged || retry_attemptChanged || approval_statusChanged || is_deletedChanged || is_editiedChanged || is_addedChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into App_user( user_id,user_login,user_password,user_full_name,user_last_login_time,user_created_by,user_creation_time,user_modified_by,user_modification_time,user_is_active,user_email,cit_id,user_type,manager_id,is_active_directory_user,employee_manager_id,mobile_number,retry_attempt,approval_status,is_deleted,is_editied,is_added ) values(");
 lock (ConnectionFactory.connectionString) { this.user_id = ConnectionFactory.GetNextId();
 qry.Append(this.user_id);
 } qry.Append(",");
 qry.Append(user_loginDbString+",");
 qry.Append(user_passwordDbString+",");
 qry.Append(user_full_nameDbString+",");
 qry.Append(user_last_login_timeDbString+",");
 qry.Append(user_created_byDbString+",");
 qry.Append(user_creation_timeDbString+",");
 qry.Append(user_modified_byDbString+",");
 qry.Append(user_modification_timeDbString+",");
 qry.Append(user_is_activeDbString+",");
 qry.Append(user_emailDbString+",");
 qry.Append(cit_idDbString+",");
 qry.Append(user_typeDbString+",");
 qry.Append(manager_idDbString+",");
 qry.Append(is_active_directory_userDbString+",");
 qry.Append(employee_manager_idDbString+",");
 qry.Append(mobile_numberDbString+",");
 qry.Append(retry_attemptDbString+",");
 qry.Append(approval_statusDbString+",");
 qry.Append(is_deletedDbString+",");
 qry.Append(is_editiedDbString+",");
 qry.Append(is_addedDbString);
 qry.Append(");");

 }
 else
 {
 if (!(user_idChanged || user_loginChanged || user_passwordChanged || user_full_nameChanged || user_last_login_timeChanged || user_created_byChanged || user_creation_timeChanged || user_modified_byChanged || user_modification_timeChanged || user_is_activeChanged || user_emailChanged || cit_idChanged || user_typeChanged || manager_idChanged || is_active_directory_userChanged || employee_manager_idChanged || mobile_numberChanged || retry_attemptChanged || approval_statusChanged || is_deletedChanged || is_editiedChanged || is_addedChanged ))
 return;
 qry.Append("UPDATE App_user set "); if ( user_loginChanged )
 {
 qry.Append("user_login ="+user_loginDbString);
 qry.Append(",");
 }

 if ( user_passwordChanged )
 {
 qry.Append("user_password ="+user_passwordDbString);
 qry.Append(",");
 }

 if ( user_full_nameChanged )
 {
 qry.Append("user_full_name ="+user_full_nameDbString);
 qry.Append(",");
 }

 if ( user_last_login_timeChanged )
 {
 qry.Append("user_last_login_time ="+user_last_login_timeDbString);
 qry.Append(",");
 }

 if ( user_created_byChanged )
 {
 qry.Append("user_created_by ="+user_created_byDbString);
 qry.Append(",");
 }

 if ( user_creation_timeChanged )
 {
 qry.Append("user_creation_time ="+user_creation_timeDbString);
 qry.Append(",");
 }

 if ( user_modified_byChanged )
 {
 qry.Append("user_modified_by ="+user_modified_byDbString);
 qry.Append(",");
 }

 if ( user_modification_timeChanged )
 {
 qry.Append("user_modification_time ="+user_modification_timeDbString);
 qry.Append(",");
 }

 if ( user_is_activeChanged )
 {
 qry.Append("user_is_active ="+user_is_activeDbString);
 qry.Append(",");
 }

 if ( user_emailChanged )
 {
 qry.Append("user_email ="+user_emailDbString);
 qry.Append(",");
 }

 if ( cit_idChanged )
 {
 qry.Append("cit_id ="+cit_idDbString);
 qry.Append(",");
 }

 if ( user_typeChanged )
 {
 qry.Append("user_type ="+user_typeDbString);
 qry.Append(",");
 }

 if ( manager_idChanged )
 {
 qry.Append("manager_id ="+manager_idDbString);
 qry.Append(",");
 }

 if ( is_active_directory_userChanged )
 {
 qry.Append("is_active_directory_user ="+is_active_directory_userDbString);
 qry.Append(",");
 }

 if ( employee_manager_idChanged )
 {
 qry.Append("employee_manager_id ="+employee_manager_idDbString);
 qry.Append(",");
 }

 if ( mobile_numberChanged )
 {
 qry.Append("mobile_number ="+mobile_numberDbString);
 qry.Append(",");
 }

 if ( retry_attemptChanged )
 {
 qry.Append("retry_attempt ="+retry_attemptDbString);
 qry.Append(",");
 }

 if ( approval_statusChanged )
 {
 qry.Append("approval_status ="+approval_statusDbString);
 qry.Append(",");
 }

 if ( is_deletedChanged )
 {
 qry.Append("is_deleted ="+is_deletedDbString);
 qry.Append(",");
 }

 if ( is_editiedChanged )
 {
 qry.Append("is_editied ="+is_editiedDbString);
 qry.Append(",");
 }

 if ( is_addedChanged )
 {
 qry.Append("is_added ="+is_addedDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("user_id = "+user_idDbString);
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
 cmd.CommandText = "DELETE App_user where user_id = "+ user_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteAppUsers(string where)
 {
 ConnectionFactory.ExecuteQuery("delete App_user where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
user_id= 1,
user_login= 2,
user_password= 4,
user_full_name= 8,
user_last_login_time= 16,
user_created_by= 32,
user_creation_time= 64,
user_modified_by= 128,
user_modification_time= 256,
user_is_active= 512,
user_email= 1024,
cit_id= 2048,
user_type= 4096,
manager_id= 8192,
is_active_directory_user= 16384,
employee_manager_id= 32768,
mobile_number= 65536,
retry_attempt= 131072,
approval_status= 262144,
is_deleted= 524288,
is_editied= 1048576,
is_added= 2097152
 }
 #endregion
 public void BulkSave(List<AppUser> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "App_user";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(AppUser.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <AppUser> transList,ref DataTable dt)
 {
 foreach (AppUser tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["user_id"] =ConnectionFactory.GetNextId();
 Row["user_login"] = tran.UserLogin;
 Row["user_password"] = tran.UserPassword;
 Row["user_full_name"] = tran.UserFullName;
 Row["user_last_login_time"] = tran.UserLastLoginTime;
 Row["user_created_by"] = tran.UserCreatedBy;
 Row["user_creation_time"] = tran.UserCreationTime;
 Row["user_modified_by"] = tran.UserModifiedBy;
 Row["user_modification_time"] = tran.UserModificationTime;
 Row["user_is_active"] = tran.UserIsActive;
 Row["user_email"] = tran.UserEmail;
 Row["cit_id"] = tran.CitId;
 Row["user_type"] = tran.UserType;
 Row["manager_id"] = tran.ManagerId;
 Row["is_active_directory_user"] = tran.IsActiveDirectoryUser;
 Row["employee_manager_id"] = tran.EmployeeManagerId;
 Row["mobile_number"] = tran.MobileNumber;
 Row["retry_attempt"] = tran.RetryAttempt;
 Row["approval_status"] = tran.ApprovalStatus;
 Row["is_deleted"] = tran.IsDeleted;
 Row["is_editied"] = tran.IsEditied;
 Row["is_added"] = tran.IsAdded;
 dt.Rows.Add(Row);
 } }
 }
}


