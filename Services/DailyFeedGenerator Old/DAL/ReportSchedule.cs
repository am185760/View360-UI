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
 public class ReportSchedule
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public ReportSchedule() { }
 public ReportSchedule( int report_schedule_id,string report_name,string report_receipients,string report_temp_path,int retry_count,DateTime report_next_generated_at,string report_friendly_name,bool schedule_type,bool is_ej_enabled,bool is_graphical_report,bool is_weekly,bool is_monthly ) 
 {
 this.report_name = report_name;
 this.report_nameChanged = true;
 this.report_receipients = report_receipients;
 this.report_receipientsChanged = true;
 this.report_temp_path = report_temp_path;
 this.report_temp_pathChanged = true;
 this.retry_count = retry_count;
 this.retry_countChanged = true;
 this.report_next_generated_at = report_next_generated_at;
 this.report_next_generated_atChanged = true;
 this.report_friendly_name = report_friendly_name;
 this.report_friendly_nameChanged = true;
 this.schedule_type = schedule_type;
 this.schedule_typeChanged = true;
 this.is_ej_enabled = is_ej_enabled;
 this.is_ej_enabledChanged = true;
 this.is_graphical_report = is_graphical_report;
 this.is_graphical_reportChanged = true;
 this.is_weekly = is_weekly;
 this.is_weeklyChanged = true;
 this.is_monthly = is_monthly;
 this.is_monthlyChanged = true;
 }
 public ReportSchedule( string report_name,string report_physical_path,string report_receipients,string report_temp_path,int retry_count,DateTime report_next_generated_at,string report_friendly_name,int? minutes_to_schedule_again,short? report_export_type,int? report_data_age,bool schedule_type,int? organization_id,bool is_ej_enabled,string report_virtual_dir_path,bool is_graphical_report,int? criteria_id,bool is_weekly,bool is_monthly,string applicable_note_set_type, int? cit_id )
 {
 this.report_name = report_name;
 this.report_nameChanged = true;
 this.report_physical_path = report_physical_path;
 this.report_physical_pathChanged = true;
 this.report_receipients = report_receipients;
 this.report_receipientsChanged = true;
 this.report_temp_path = report_temp_path;
 this.report_temp_pathChanged = true;
 this.retry_count = retry_count;
 this.retry_countChanged = true;
 this.report_next_generated_at = report_next_generated_at;
 this.report_next_generated_atChanged = true;
 this.report_friendly_name = report_friendly_name;
 this.report_friendly_nameChanged = true;
 this.minutes_to_schedule_again = minutes_to_schedule_again;
 this.minutes_to_schedule_againChanged = true;
 this.report_export_type = report_export_type;
 this.report_export_typeChanged = true;
 this.report_data_age = report_data_age;
 this.report_data_ageChanged = true;
 this.schedule_type = schedule_type;
 this.schedule_typeChanged = true;
 this.organization_id = organization_id;
 this.organization_idChanged = true;
 this.is_ej_enabled = is_ej_enabled;
 this.is_ej_enabledChanged = true;
 this.report_virtual_dir_path = report_virtual_dir_path;
 this.report_virtual_dir_pathChanged = true;
 this.is_graphical_report = is_graphical_report;
 this.is_graphical_reportChanged = true;
 this.criteria_id = criteria_id;
 this.criteria_idChanged = true;
 this.is_weekly = is_weekly;
 this.is_weeklyChanged = true;
 this.is_monthly = is_monthly;
 this.is_monthlyChanged = true;
 this.applicable_note_set_type = applicable_note_set_type;
 this.applicable_note_set_typeChanged = true;
     this.cit_id = cit_id;
     this.cit_idChanged = true;
 }
 private ReportSchedule( int report_schedule_id,string report_name,string report_physical_path,string report_receipients,string report_temp_path,int retry_count,DateTime report_next_generated_at,string report_friendly_name,int? minutes_to_schedule_again,short? report_export_type,int? report_data_age,bool schedule_type,int? organization_id,bool is_ej_enabled,string report_virtual_dir_path,bool is_graphical_report,int? criteria_id,bool is_weekly,bool is_monthly,string applicable_note_set_type,int? cit_id )
 {
 this.report_schedule_id = report_schedule_id;
 this.report_schedule_idChanged = true;
 this.report_name = report_name;
 this.report_nameChanged = true;
 this.report_physical_path = report_physical_path;
 this.report_physical_pathChanged = true;
 this.report_receipients = report_receipients;
 this.report_receipientsChanged = true;
 this.report_temp_path = report_temp_path;
 this.report_temp_pathChanged = true;
 this.retry_count = retry_count;
 this.retry_countChanged = true;
 this.report_next_generated_at = report_next_generated_at;
 this.report_next_generated_atChanged = true;
 this.report_friendly_name = report_friendly_name;
 this.report_friendly_nameChanged = true;
 this.minutes_to_schedule_again = minutes_to_schedule_again;
 this.minutes_to_schedule_againChanged = true;
 this.report_export_type = report_export_type;
 this.report_export_typeChanged = true;
 this.report_data_age = report_data_age;
 this.report_data_ageChanged = true;
 this.schedule_type = schedule_type;
 this.schedule_typeChanged = true;
 this.organization_id = organization_id;
 this.organization_idChanged = true;
 this.is_ej_enabled = is_ej_enabled;
 this.is_ej_enabledChanged = true;
 this.report_virtual_dir_path = report_virtual_dir_path;
 this.report_virtual_dir_pathChanged = true;
 this.is_graphical_report = is_graphical_report;
 this.is_graphical_reportChanged = true;
 this.criteria_id = criteria_id;
 this.criteria_idChanged = true;
 this.is_weekly = is_weekly;
 this.is_weeklyChanged = true;
 this.is_monthly = is_monthly;
 this.is_monthlyChanged = true;
 this.applicable_note_set_type = applicable_note_set_type;
 this.applicable_note_set_typeChanged = true;
     this.cit_id = cit_id;
     this.cit_idChanged = true;
 }

 #region members and properties for columns

 #region ReportScheduleId
 private bool report_schedule_idChanged = false;
 private int report_schedule_id;
 public int ReportScheduleId
 {
 get { return report_schedule_id; }
 set { 
report_schedule_id = value;
report_schedule_idChanged = true;
 }
 }
 private string report_schedule_idDbString
 {
 get
 {
 return report_schedule_id.ToString();
 }
 }
 #endregion
 #region ReportName
 private bool report_nameChanged = false;
 private string report_name;
 public string ReportName
 {
 get { return report_name; }
 set { 
report_name = value;
report_nameChanged = true;
 }
 }
 private string report_nameDbString
 {
 get
 {
 if (this.report_name!=null)
 return string.Format("'{0}'",report_name); else
 return "null";
 }
 }
 #endregion
 #region ReportPhysicalPath
 private bool report_physical_pathChanged = false;
 private string report_physical_path;
 public string ReportPhysicalPath
 {
 get { return report_physical_path; }
 set { 
report_physical_path = value;
report_physical_pathChanged = true;
 }
 }
 private string report_physical_pathDbString
 {
 get
 {
 if (this.report_physical_path!=null)
 return string.Format("'{0}'",report_physical_path); else
 return "null";
 }
 }
 #endregion
 #region ReportReceipients
 private bool report_receipientsChanged = false;
 private string report_receipients;
 public string ReportReceipients
 {
 get { return report_receipients; }
 set { 
report_receipients = value;
report_receipientsChanged = true;
 }
 }
 private string report_receipientsDbString
 {
 get
 {
 if (this.report_receipients!=null)
 return string.Format("'{0}'",report_receipients); else
 return "null";
 }
 }
 #endregion
 #region ReportTempPath
 private bool report_temp_pathChanged = false;
 private string report_temp_path;
 public string ReportTempPath
 {
 get { return report_temp_path; }
 set { 
report_temp_path = value;
report_temp_pathChanged = true;
 }
 }
 private string report_temp_pathDbString
 {
 get
 {
 if (this.report_temp_path!=null)
 return string.Format("'{0}'",report_temp_path); else
 return "null";
 }
 }
 #endregion
 #region RetryCount
 private bool retry_countChanged = false;
 private int retry_count;
 public int RetryCount
 {
 get { return retry_count; }
 set { 
retry_count = value;
retry_countChanged = true;
 }
 }
 private string retry_countDbString
 {
 get
 {
 return retry_count.ToString();
 }
 }
 #endregion
 #region ReportNextGeneratedAt
 private bool report_next_generated_atChanged = false;
 private DateTime report_next_generated_at;
 public DateTime ReportNextGeneratedAt
 {
 get { return report_next_generated_at; }
 set { 
report_next_generated_at = value;
report_next_generated_atChanged = true;
 }
 }
 private string report_next_generated_atDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",report_next_generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region ReportFriendlyName
 private bool report_friendly_nameChanged = false;
 private string report_friendly_name;
 public string ReportFriendlyName
 {
 get { return report_friendly_name; }
 set { 
report_friendly_name = value;
report_friendly_nameChanged = true;
 }
 }
 private string report_friendly_nameDbString
 {
 get
 {
 if (this.report_friendly_name!=null)
 return string.Format("'{0}'",report_friendly_name); else
 return "null";
 }
 }
 #endregion
 #region MinutesToScheduleAgain
 private bool minutes_to_schedule_againChanged = false;
 private int? minutes_to_schedule_again;
 public int? MinutesToScheduleAgain
 {
 get { return minutes_to_schedule_again; }
 set { 
minutes_to_schedule_again = value;
minutes_to_schedule_againChanged = true;
 }
 }
 private string minutes_to_schedule_againDbString
 {
 get
 {
 if (this.minutes_to_schedule_again.HasValue)
 return minutes_to_schedule_again.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region ReportExportType
 private bool report_export_typeChanged = false;
 private short? report_export_type;
 public short? ReportExportType
 {
 get { return report_export_type; }
 set { 
report_export_type = value;
report_export_typeChanged = true;
 }
 }
 private string report_export_typeDbString
 {
 get
 {
 if (this.report_export_type.HasValue)
 return report_export_type.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region ReportDataAge
 private bool report_data_ageChanged = false;
 private int? report_data_age;
 public int? ReportDataAge
 {
 get { return report_data_age; }
 set { 
report_data_age = value;
report_data_ageChanged = true;
 }
 }
 private string report_data_ageDbString
 {
 get
 {
 if (this.report_data_age.HasValue)
 return report_data_age.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region ScheduleType
 private bool schedule_typeChanged = false;
 private bool schedule_type;
 public bool ScheduleType
 {
 get { return schedule_type; }
 set { 
schedule_type = value;
schedule_typeChanged = true;
 }
 }
 private string schedule_typeDbString
 {
 get
 {
 return schedule_type?"1":"0";
 }
 }
 #endregion
 #region OrganizationId
 private bool organization_idChanged = false;
 private int? organization_id;
 public int? OrganizationId
 {
 get { return organization_id; }
 set { 
organization_id = value;
organization_idChanged = true;
 }
 }
 private string organization_idDbString
 {
 get
 {
 if (this.organization_id.HasValue)
 return organization_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region IsEjEnabled
 private bool is_ej_enabledChanged = false;
 private bool is_ej_enabled;
 public bool IsEjEnabled
 {
 get { return is_ej_enabled; }
 set { 
is_ej_enabled = value;
is_ej_enabledChanged = true;
 }
 }
 private string is_ej_enabledDbString
 {
 get
 {
 return is_ej_enabled?"1":"0";
 }
 }
 #endregion
 #region ReportVirtualDirPath
 private bool report_virtual_dir_pathChanged = false;
 private string report_virtual_dir_path;
 public string ReportVirtualDirPath
 {
 get { return report_virtual_dir_path; }
 set { 
report_virtual_dir_path = value;
report_virtual_dir_pathChanged = true;
 }
 }
 private string report_virtual_dir_pathDbString
 {
 get
 {
 if (this.report_virtual_dir_path!=null)
 return string.Format("'{0}'",report_virtual_dir_path); else
 return "null";
 }
 }
 #endregion
 #region IsGraphicalReport
 private bool is_graphical_reportChanged = false;
 private bool is_graphical_report;
 public bool IsGraphicalReport
 {
 get { return is_graphical_report; }
 set { 
is_graphical_report = value;
is_graphical_reportChanged = true;
 }
 }
 private string is_graphical_reportDbString
 {
 get
 {
 return is_graphical_report?"1":"0";
 }
 }
 #endregion
 #region CriteriaId
 private bool criteria_idChanged = false;
 private int? criteria_id;
 public int? CriteriaId
 {
 get { return criteria_id; }
 set { 
criteria_id = value;
criteria_idChanged = true;
 }
 }
 private string criteria_idDbString
 {
 get
 {
 if (this.criteria_id.HasValue)
 return criteria_id.ToString();
 else
 return "null";
 }
 }
 #endregion
 #region IsWeekly
 private bool is_weeklyChanged = false;
 private bool is_weekly;
 public bool IsWeekly
 {
 get { return is_weekly; }
 set { 
is_weekly = value;
is_weeklyChanged = true;
 }
 }
 private string is_weeklyDbString
 {
 get
 {
 return is_weekly?"1":"0";
 }
 }
 #endregion
 #region IsMonthly
 private bool is_monthlyChanged = false;
 private bool is_monthly;
 public bool IsMonthly
 {
 get { return is_monthly; }
 set { 
is_monthly = value;
is_monthlyChanged = true;
 }
 }
 private string is_monthlyDbString
 {
 get
 {
 return is_monthly?"1":"0";
 }
 }
 #endregion
 #region ApplicableNoteSetType
 private bool applicable_note_set_typeChanged = false;
 private string applicable_note_set_type;
 public string ApplicableNoteSetType
 {
 get { return applicable_note_set_type; }
 set { 
applicable_note_set_type = value;
applicable_note_set_typeChanged = true;
 }
 }
 private string applicable_note_set_typeDbString
 {
 get
 {
 if (this.applicable_note_set_type!=null)
 return string.Format("'{0}'",applicable_note_set_type); else
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
 #endregion

 #region ReportScheduleReader
 public class ReportScheduleReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
ReportSchedule currentReportSchedule;
 Columns columns;
 bool partialRead = false;
 private ReportScheduleReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public ReportScheduleReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public ReportScheduleReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentReportSchedule; }

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
 currentReportSchedule = new ReportSchedule();
 if (partialRead)
 { if ((columns & Columns.report_schedule_id) == Columns.report_schedule_id && reader["report_schedule_id"]!=DBNull.Value)
 currentReportSchedule.report_schedule_id =(int) reader["report_schedule_id"]; 
 if ((columns & Columns.report_name) == Columns.report_name && reader["report_name"]!=DBNull.Value)
 currentReportSchedule.report_name =(string) reader["report_name"]; 
 if ((columns & Columns.report_physical_path) == Columns.report_physical_path && reader["report_physical_path"]!=DBNull.Value)
 currentReportSchedule.report_physical_path =(string) reader["report_physical_path"]; 
 if ((columns & Columns.report_receipients) == Columns.report_receipients && reader["report_receipients"]!=DBNull.Value)
 currentReportSchedule.report_receipients =(string) reader["report_receipients"]; 
 if ((columns & Columns.report_temp_path) == Columns.report_temp_path && reader["report_temp_path"]!=DBNull.Value)
 currentReportSchedule.report_temp_path =(string) reader["report_temp_path"]; 
 if ((columns & Columns.retry_count) == Columns.retry_count && reader["retry_count"]!=DBNull.Value)
 currentReportSchedule.retry_count =(int) reader["retry_count"]; 
 if ((columns & Columns.report_next_generated_at) == Columns.report_next_generated_at && reader["report_next_generated_at"]!=DBNull.Value)
 currentReportSchedule.report_next_generated_at =(DateTime) reader["report_next_generated_at"]; 
 if ((columns & Columns.report_friendly_name) == Columns.report_friendly_name && reader["report_friendly_name"]!=DBNull.Value)
 currentReportSchedule.report_friendly_name =(string) reader["report_friendly_name"]; 
 if ((columns & Columns.minutes_to_schedule_again) == Columns.minutes_to_schedule_again && reader["minutes_to_schedule_again"]!=DBNull.Value)
 currentReportSchedule.minutes_to_schedule_again =(int?) reader["minutes_to_schedule_again"]; 
 if ((columns & Columns.report_export_type) == Columns.report_export_type && reader["report_export_type"]!=DBNull.Value)
 currentReportSchedule.report_export_type =(short?) reader["report_export_type"]; 
 if ((columns & Columns.report_data_age) == Columns.report_data_age && reader["report_data_age"]!=DBNull.Value)
 currentReportSchedule.report_data_age =(int?) reader["report_data_age"]; 
 if ((columns & Columns.schedule_type) == Columns.schedule_type && reader["schedule_type"]!=DBNull.Value)
 currentReportSchedule.schedule_type =(bool) reader["schedule_type"]; 
 if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
 currentReportSchedule.organization_id =(int?) reader["organization_id"]; 
 if ((columns & Columns.is_ej_enabled) == Columns.is_ej_enabled && reader["is_ej_enabled"]!=DBNull.Value)
 currentReportSchedule.is_ej_enabled =(bool) reader["is_ej_enabled"]; 
 if ((columns & Columns.report_virtual_dir_path) == Columns.report_virtual_dir_path && reader["report_virtual_dir_path"]!=DBNull.Value)
 currentReportSchedule.report_virtual_dir_path =(string) reader["report_virtual_dir_path"]; 
 if ((columns & Columns.is_graphical_report) == Columns.is_graphical_report && reader["is_graphical_report"]!=DBNull.Value)
 currentReportSchedule.is_graphical_report =(bool) reader["is_graphical_report"]; 
 if ((columns & Columns.criteria_id) == Columns.criteria_id && reader["criteria_id"]!=DBNull.Value)
 currentReportSchedule.criteria_id =(int?) reader["criteria_id"]; 
 if ((columns & Columns.is_weekly) == Columns.is_weekly && reader["is_weekly"]!=DBNull.Value)
 currentReportSchedule.is_weekly =(bool) reader["is_weekly"]; 
 if ((columns & Columns.is_monthly) == Columns.is_monthly && reader["is_monthly"]!=DBNull.Value)
 currentReportSchedule.is_monthly =(bool) reader["is_monthly"]; 
 if ((columns & Columns.applicable_note_set_type) == Columns.applicable_note_set_type && reader["applicable_note_set_type"]!=DBNull.Value)
 currentReportSchedule.applicable_note_set_type =(string) reader["applicable_note_set_type"]; 
 if ((columns & Columns.cit_id) == Columns.cit_id && reader["cit_id"]!=DBNull.Value)
     currentReportSchedule.cit_id = (int?)reader["cit_id"];
 } else
 {
 if (reader["report_schedule_id"] != DBNull.Value)
 currentReportSchedule.report_schedule_id = (int) reader["report_schedule_id"]; 
 if (reader["report_name"] != DBNull.Value)
 currentReportSchedule.report_name = (string) reader["report_name"]; 
 if (reader["report_physical_path"] != DBNull.Value)
 currentReportSchedule.report_physical_path = (string) reader["report_physical_path"]; 
 if (reader["report_receipients"] != DBNull.Value)
 currentReportSchedule.report_receipients = (string) reader["report_receipients"]; 
 if (reader["report_temp_path"] != DBNull.Value)
 currentReportSchedule.report_temp_path = (string) reader["report_temp_path"]; 
 if (reader["retry_count"] != DBNull.Value)
 currentReportSchedule.retry_count = (int) reader["retry_count"]; 
 if (reader["report_next_generated_at"] != DBNull.Value)
 currentReportSchedule.report_next_generated_at = (DateTime) reader["report_next_generated_at"]; 
 if (reader["report_friendly_name"] != DBNull.Value)
 currentReportSchedule.report_friendly_name = (string) reader["report_friendly_name"]; 
 if (reader["minutes_to_schedule_again"] != DBNull.Value)
 currentReportSchedule.minutes_to_schedule_again = (int?) reader["minutes_to_schedule_again"]; 
 if (reader["report_export_type"] != DBNull.Value)
 currentReportSchedule.report_export_type = (short?) reader["report_export_type"]; 
 if (reader["report_data_age"] != DBNull.Value)
 currentReportSchedule.report_data_age = (int?) reader["report_data_age"]; 
 if (reader["schedule_type"] != DBNull.Value)
 currentReportSchedule.schedule_type = (bool) reader["schedule_type"]; 
 if (reader["organization_id"] != DBNull.Value)
 currentReportSchedule.organization_id = (int?) reader["organization_id"]; 
 if (reader["is_ej_enabled"] != DBNull.Value)
 currentReportSchedule.is_ej_enabled = (bool) reader["is_ej_enabled"]; 
 if (reader["report_virtual_dir_path"] != DBNull.Value)
 currentReportSchedule.report_virtual_dir_path = (string) reader["report_virtual_dir_path"]; 
 if (reader["is_graphical_report"] != DBNull.Value)
 currentReportSchedule.is_graphical_report = (bool) reader["is_graphical_report"]; 
 if (reader["criteria_id"] != DBNull.Value)
 currentReportSchedule.criteria_id = (int?) reader["criteria_id"]; 
 if (reader["is_weekly"] != DBNull.Value)
 currentReportSchedule.is_weekly = (bool) reader["is_weekly"]; 
 if (reader["is_monthly"] != DBNull.Value)
 currentReportSchedule.is_monthly = (bool) reader["is_monthly"]; 
 if (reader["applicable_note_set_type"] != DBNull.Value)
 currentReportSchedule.applicable_note_set_type = (string) reader["applicable_note_set_type"]; 
     if (reader["cit_id"] != DBNull.Value)
         currentReportSchedule.cit_id = (int?)reader["cit_id"]; 
 } 

 currentReportSchedule.isNewEntity = false;
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

 public ReportSchedule CurrentReportSchedule
 {
 get{ return currentReportSchedule; }
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


 #region ReportSchedule functions

 public static ReportScheduleReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.report_schedule_id == (Columns.report_schedule_id & columns))
 qry.Append("report_schedule_id,");
 if (Columns.report_name == (Columns.report_name & columns))
 qry.Append("report_name,");
 if (Columns.report_physical_path == (Columns.report_physical_path & columns))
 qry.Append("report_physical_path,");
 if (Columns.report_receipients == (Columns.report_receipients & columns))
 qry.Append("report_receipients,");
 if (Columns.report_temp_path == (Columns.report_temp_path & columns))
 qry.Append("report_temp_path,");
 if (Columns.retry_count == (Columns.retry_count & columns))
 qry.Append("retry_count,");
 if (Columns.report_next_generated_at == (Columns.report_next_generated_at & columns))
 qry.Append("report_next_generated_at,");
 if (Columns.report_friendly_name == (Columns.report_friendly_name & columns))
 qry.Append("report_friendly_name,");
 if (Columns.minutes_to_schedule_again == (Columns.minutes_to_schedule_again & columns))
 qry.Append("minutes_to_schedule_again,");
 if (Columns.report_export_type == (Columns.report_export_type & columns))
 qry.Append("report_export_type,");
 if (Columns.report_data_age == (Columns.report_data_age & columns))
 qry.Append("report_data_age,");
 if (Columns.schedule_type == (Columns.schedule_type & columns))
 qry.Append("schedule_type,");
 if (Columns.organization_id == (Columns.organization_id & columns))
 qry.Append("organization_id,");
 if (Columns.is_ej_enabled == (Columns.is_ej_enabled & columns))
 qry.Append("is_ej_enabled,");
 if (Columns.report_virtual_dir_path == (Columns.report_virtual_dir_path & columns))
 qry.Append("report_virtual_dir_path,");
 if (Columns.is_graphical_report == (Columns.is_graphical_report & columns))
 qry.Append("is_graphical_report,");
 if (Columns.criteria_id == (Columns.criteria_id & columns))
 qry.Append("criteria_id,");
 if (Columns.is_weekly == (Columns.is_weekly & columns))
 qry.Append("is_weekly,");
 if (Columns.is_monthly == (Columns.is_monthly & columns))
 qry.Append("is_monthly,");
 if (Columns.applicable_note_set_type == (Columns.applicable_note_set_type & columns))
 qry.Append("applicable_note_set_type,");
 if (Columns.cit_id == (Columns.cit_id & columns))
     qry.Append("cit_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Report_schedule ");

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
 return new ReportScheduleReader(cmd.ExecuteReader(), conn, columns);
 }

 static public ReportScheduleReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static ReportScheduleReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select report_schedule_id,report_name,report_physical_path,report_receipients,report_temp_path,retry_count,report_next_generated_at,report_friendly_name,minutes_to_schedule_again,report_export_type,report_data_age,schedule_type,organization_id,is_ej_enabled,report_virtual_dir_path,is_graphical_report,criteria_id,is_weekly,is_monthly,applicable_note_set_type,cit_id from Report_schedule ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new ReportScheduleReader(cmd.ExecuteReader(), conn);
 }

 static public ReportScheduleReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static ReportSchedule LoadReportSchedule(string where)
 {
ReportScheduleReader reader = ReportSchedule.ExecuteReader(where);
ReportSchedule _reportschedule = null;
 if (reader.Read())
 _reportschedule = reader.CurrentReportSchedule;
 reader.Close();
 return _reportschedule;
 }

 public static ReportSchedule LoadReportSchedule(string where, IDbConnection conn)
 {
ReportScheduleReader reader = ReportSchedule.ExecuteReader(where, conn);
ReportSchedule _reportschedule = null;
 if (reader.Read())
 _reportschedule = reader.CurrentReportSchedule;
 reader.Close(false);
 return _reportschedule;
 }

 public static ReportSchedule LoadReportScheduleByPk( int report_schedule_id )
 {
 return LoadReportSchedule( " report_schedule_id="+report_schedule_id );
 }

 public static ReportSchedule LoadReportScheduleByPk( int report_schedule_id , IDbConnection conn)
 {
 return LoadReportSchedule(" report_schedule_id="+report_schedule_id , conn);
 }

 public void Save()
 {
 if (report_schedule_idChanged || report_nameChanged || report_physical_pathChanged || report_receipientsChanged || report_temp_pathChanged || retry_countChanged || report_next_generated_atChanged || report_friendly_nameChanged || minutes_to_schedule_againChanged || report_export_typeChanged || report_data_ageChanged || schedule_typeChanged || organization_idChanged || is_ej_enabledChanged || report_virtual_dir_pathChanged || is_graphical_reportChanged || criteria_idChanged || is_weeklyChanged || is_monthlyChanged || applicable_note_set_typeChanged || cit_idChanged )
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
     if (report_schedule_idChanged || report_nameChanged || report_physical_pathChanged || report_receipientsChanged || report_temp_pathChanged || retry_countChanged || report_next_generated_atChanged || report_friendly_nameChanged || minutes_to_schedule_againChanged || report_export_typeChanged || report_data_ageChanged || schedule_typeChanged || organization_idChanged || is_ej_enabledChanged || report_virtual_dir_pathChanged || is_graphical_reportChanged || criteria_idChanged || is_weeklyChanged || is_monthlyChanged || applicable_note_set_typeChanged || cit_idChanged)
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
     qry.Append(@"insert into Report_schedule( report_schedule_id,report_name,report_physical_path,report_receipients,report_temp_path,retry_count,report_next_generated_at,report_friendly_name,minutes_to_schedule_again,report_export_type,report_data_age,schedule_type,organization_id,is_ej_enabled,report_virtual_dir_path,is_graphical_report,criteria_id,is_weekly,is_monthly,applicable_note_set_type,cit_id ) values(");
 lock (ConnectionFactory.connectionString) { this.report_schedule_id = ConnectionFactory.GetNextId();
 qry.Append(this.report_schedule_id);
 } qry.Append(",");
 qry.Append(report_nameDbString+",");
 qry.Append(report_physical_pathDbString+",");
 qry.Append(report_receipientsDbString+",");
 qry.Append(report_temp_pathDbString+",");
 qry.Append(retry_countDbString+",");
 qry.Append(report_next_generated_atDbString+",");
 qry.Append(report_friendly_nameDbString+",");
 qry.Append(minutes_to_schedule_againDbString+",");
 qry.Append(report_export_typeDbString+",");
 qry.Append(report_data_ageDbString+",");
 qry.Append(schedule_typeDbString+",");
 qry.Append(organization_idDbString+",");
 qry.Append(is_ej_enabledDbString+",");
 qry.Append(report_virtual_dir_pathDbString+",");
 qry.Append(is_graphical_reportDbString+",");
 qry.Append(criteria_idDbString+",");
 qry.Append(is_weeklyDbString+",");
 qry.Append(is_monthlyDbString+",");
 qry.Append(applicable_note_set_typeDbString + ",");
 qry.Append(cit_idDbString);
 qry.Append(");");

 }
 else
 {
     if (!(report_schedule_idChanged || report_nameChanged || report_physical_pathChanged || report_receipientsChanged || report_temp_pathChanged || retry_countChanged || report_next_generated_atChanged || report_friendly_nameChanged || minutes_to_schedule_againChanged || report_export_typeChanged || report_data_ageChanged || schedule_typeChanged || organization_idChanged || is_ej_enabledChanged || report_virtual_dir_pathChanged || is_graphical_reportChanged || criteria_idChanged || is_weeklyChanged || is_monthlyChanged || applicable_note_set_typeChanged || cit_idChanged))
 return;
 qry.Append("UPDATE Report_schedule set "); if ( report_nameChanged )
 {
 qry.Append("report_name ="+report_nameDbString);
 qry.Append(",");
 }

 if ( report_physical_pathChanged )
 {
 qry.Append("report_physical_path ="+report_physical_pathDbString);
 qry.Append(",");
 }

 if ( report_receipientsChanged )
 {
 qry.Append("report_receipients ="+report_receipientsDbString);
 qry.Append(",");
 }

 if ( report_temp_pathChanged )
 {
 qry.Append("report_temp_path ="+report_temp_pathDbString);
 qry.Append(",");
 }

 if ( retry_countChanged )
 {
 qry.Append("retry_count ="+retry_countDbString);
 qry.Append(",");
 }

 if ( report_next_generated_atChanged )
 {
 qry.Append("report_next_generated_at ="+report_next_generated_atDbString);
 qry.Append(",");
 }

 if ( report_friendly_nameChanged )
 {
 qry.Append("report_friendly_name ="+report_friendly_nameDbString);
 qry.Append(",");
 }

 if ( minutes_to_schedule_againChanged )
 {
 qry.Append("minutes_to_schedule_again ="+minutes_to_schedule_againDbString);
 qry.Append(",");
 }

 if ( report_export_typeChanged )
 {
 qry.Append("report_export_type ="+report_export_typeDbString);
 qry.Append(",");
 }

 if ( report_data_ageChanged )
 {
 qry.Append("report_data_age ="+report_data_ageDbString);
 qry.Append(",");
 }

 if ( schedule_typeChanged )
 {
 qry.Append("schedule_type ="+schedule_typeDbString);
 qry.Append(",");
 }

 if ( organization_idChanged )
 {
 qry.Append("organization_id ="+organization_idDbString);
 qry.Append(",");
 }

 if ( is_ej_enabledChanged )
 {
 qry.Append("is_ej_enabled ="+is_ej_enabledDbString);
 qry.Append(",");
 }

 if ( report_virtual_dir_pathChanged )
 {
 qry.Append("report_virtual_dir_path ="+report_virtual_dir_pathDbString);
 qry.Append(",");
 }

 if ( is_graphical_reportChanged )
 {
 qry.Append("is_graphical_report ="+is_graphical_reportDbString);
 qry.Append(",");
 }

 if ( criteria_idChanged )
 {
 qry.Append("criteria_id ="+criteria_idDbString);
 qry.Append(",");
 }

 if ( is_weeklyChanged )
 {
 qry.Append("is_weekly ="+is_weeklyDbString);
 qry.Append(",");
 }

 if ( is_monthlyChanged )
 {
 qry.Append("is_monthly ="+is_monthlyDbString);
 qry.Append(",");
 }

 if ( applicable_note_set_typeChanged )
 {
 qry.Append("applicable_note_set_type ="+applicable_note_set_typeDbString);
 qry.Append(",");
 }

 if (cit_idChanged)
 {
     qry.Append("cit_id =" + cit_idDbString);
     qry.Append(",");
 }

 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("report_schedule_id = "+report_schedule_idDbString);
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
 cmd.CommandText = "DELETE Report_schedule where report_schedule_id = "+ report_schedule_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteReportSchedules(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Report_schedule where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:uint
 {
report_schedule_id= 1,
report_name= 2,
report_physical_path= 4,
report_receipients= 8,
report_temp_path= 16,
retry_count= 32,
report_next_generated_at= 64,
report_friendly_name= 128,
minutes_to_schedule_again= 256,
report_export_type= 512,
report_data_age= 1024,
schedule_type= 2048,
organization_id= 4096,
is_ej_enabled= 8192,
report_virtual_dir_path= 16384,
is_graphical_report= 32768,
criteria_id= 65536,
is_weekly= 131072,
is_monthly= 262144,
applicable_note_set_type= 524288,
cit_id= 1048576	
 }
 #endregion
 public void BulkSave(List<ReportSchedule> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Report_schedule";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(ReportSchedule.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <ReportSchedule> transList,ref DataTable dt)
 {
 foreach (ReportSchedule tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["report_schedule_id"] =ConnectionFactory.GetNextId();
 Row["report_name"] = tran.ReportName;
 Row["report_physical_path"] = tran.ReportPhysicalPath;
 Row["report_receipients"] = tran.ReportReceipients;
 Row["report_temp_path"] = tran.ReportTempPath;
 Row["retry_count"] = tran.RetryCount;
 Row["report_next_generated_at"] = tran.ReportNextGeneratedAt;
 Row["report_friendly_name"] = tran.ReportFriendlyName;
 Row["minutes_to_schedule_again"] = tran.MinutesToScheduleAgain;
 Row["report_export_type"] = tran.ReportExportType;
 Row["report_data_age"] = tran.ReportDataAge;
 Row["schedule_type"] = tran.ScheduleType;
 Row["organization_id"] = tran.OrganizationId;
 Row["is_ej_enabled"] = tran.IsEjEnabled;
 Row["report_virtual_dir_path"] = tran.ReportVirtualDirPath;
 Row["is_graphical_report"] = tran.IsGraphicalReport;
 Row["criteria_id"] = tran.CriteriaId;
 Row["is_weekly"] = tran.IsWeekly;
 Row["is_monthly"] = tran.IsMonthly;
 Row["applicable_note_set_type"] = tran.ApplicableNoteSetType;
 Row["cit_id"] = tran.CitId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
