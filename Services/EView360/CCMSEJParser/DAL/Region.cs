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
public class Region
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public Region() { }
public Region( int region_id,string region_name,bool is_active,int created_by,DateTime creation_time,bool is_organization,bool is_dff_version_2_configured,int retry_count_cash_order_download,int retry_count_dff_upload,int retry_count_alert,bool is_dff_suspeded,bool is_ej_enabled,bool is_counter_enabled,int priority ) 
{
this.region_name = region_name;
this.region_nameChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.is_organization = is_organization;
this.is_organizationChanged = true;
this.is_dff_version_2_configured = is_dff_version_2_configured;
this.is_dff_version_2_configuredChanged = true;
this.retry_count_cash_order_download = retry_count_cash_order_download;
this.retry_count_cash_order_downloadChanged = true;
this.retry_count_dff_upload = retry_count_dff_upload;
this.retry_count_dff_uploadChanged = true;
this.retry_count_alert = retry_count_alert;
this.retry_count_alertChanged = true;
this.is_dff_suspeded = is_dff_suspeded;
this.is_dff_suspededChanged = true;
this.is_ej_enabled = is_ej_enabled;
this.is_ej_enabledChanged = true;
this.is_counter_enabled = is_counter_enabled;
this.is_counter_enabledChanged = true;
this.priority = priority;
this.priorityChanged = true;
}
public Region( string region_name,int? parent_region_id,string location,string country,string mCN,int? region_cit_id,byte[] bank_logo,bool is_active,int created_by,int? modified_by,DateTime creation_time,bool is_organization,bool? suspend_cash_order,DateTime? daily_feed_generation_time,string daily_feed_output_file_path,int? daily_feed_generation_delay,string cash_order_downloaded_file_path,string daily_feed_ftp_uri,string daily_feed_ftp_username,string daily_feed_ftp_password,string cash_order_ftp_uri,string cash_order_ftp_username,string cash_order_ftp_password,string cash_order_archive_url,int? number_of_types,bool is_dff_version_2_configured,int retry_count_cash_order_download,int retry_count_dff_upload,int retry_count_alert,bool? is_secured_access,decimal? card_captured_cost,decimal? escotting_cost,decimal? replenishment_cost,decimal? maintenance_cost,decimal? flm_call_out_cost,string dff_naming_convention,string configured_cassettes,string configured_cassettes_denomination,int? seconds_between_trxn_in_ej_and_ccms,string smtp_server,int? smtp_port,string smtp_username,string smtp_password,bool is_dff_suspeded,bool is_ej_enabled,bool is_counter_enabled,int priority,string offline_atm_settlements_file_path,string offline_atm_settlements_multicurrency_file_path,DateTime? vault_summary_generation_time )
{
this.region_name = region_name;
this.region_nameChanged = true;
this.parent_region_id = parent_region_id;
this.parent_region_idChanged = true;
this.location = location;
this.locationChanged = true;
this.country = country;
this.countryChanged = true;
this.mCN = mCN;
this.mCNChanged = true;
this.region_cit_id = region_cit_id;
this.region_cit_idChanged = true;
this.bank_logo = bank_logo;
this.bank_logoChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.is_organization = is_organization;
this.is_organizationChanged = true;
this.suspend_cash_order = suspend_cash_order;
this.suspend_cash_orderChanged = true;
this.daily_feed_generation_time = daily_feed_generation_time;
this.daily_feed_generation_timeChanged = true;
this.daily_feed_output_file_path = daily_feed_output_file_path;
this.daily_feed_output_file_pathChanged = true;
this.daily_feed_generation_delay = daily_feed_generation_delay;
this.daily_feed_generation_delayChanged = true;
this.cash_order_downloaded_file_path = cash_order_downloaded_file_path;
this.cash_order_downloaded_file_pathChanged = true;
this.daily_feed_ftp_uri = daily_feed_ftp_uri;
this.daily_feed_ftp_uriChanged = true;
this.daily_feed_ftp_username = daily_feed_ftp_username;
this.daily_feed_ftp_usernameChanged = true;
this.daily_feed_ftp_password = daily_feed_ftp_password;
this.daily_feed_ftp_passwordChanged = true;
this.cash_order_ftp_uri = cash_order_ftp_uri;
this.cash_order_ftp_uriChanged = true;
this.cash_order_ftp_username = cash_order_ftp_username;
this.cash_order_ftp_usernameChanged = true;
this.cash_order_ftp_password = cash_order_ftp_password;
this.cash_order_ftp_passwordChanged = true;
this.cash_order_archive_url = cash_order_archive_url;
this.cash_order_archive_urlChanged = true;
this.number_of_types = number_of_types;
this.number_of_typesChanged = true;
this.is_dff_version_2_configured = is_dff_version_2_configured;
this.is_dff_version_2_configuredChanged = true;
this.retry_count_cash_order_download = retry_count_cash_order_download;
this.retry_count_cash_order_downloadChanged = true;
this.retry_count_dff_upload = retry_count_dff_upload;
this.retry_count_dff_uploadChanged = true;
this.retry_count_alert = retry_count_alert;
this.retry_count_alertChanged = true;
this.is_secured_access = is_secured_access;
this.is_secured_accessChanged = true;
this.card_captured_cost = card_captured_cost;
this.card_captured_costChanged = true;
this.escotting_cost = escotting_cost;
this.escotting_costChanged = true;
this.replenishment_cost = replenishment_cost;
this.replenishment_costChanged = true;
this.maintenance_cost = maintenance_cost;
this.maintenance_costChanged = true;
this.flm_call_out_cost = flm_call_out_cost;
this.flm_call_out_costChanged = true;
this.dff_naming_convention = dff_naming_convention;
this.dff_naming_conventionChanged = true;
this.configured_cassettes = configured_cassettes;
this.configured_cassettesChanged = true;
this.configured_cassettes_denomination = configured_cassettes_denomination;
this.configured_cassettes_denominationChanged = true;
this.seconds_between_trxn_in_ej_and_ccms = seconds_between_trxn_in_ej_and_ccms;
this.seconds_between_trxn_in_ej_and_ccmsChanged = true;
this.smtp_server = smtp_server;
this.smtp_serverChanged = true;
this.smtp_port = smtp_port;
this.smtp_portChanged = true;
this.smtp_username = smtp_username;
this.smtp_usernameChanged = true;
this.smtp_password = smtp_password;
this.smtp_passwordChanged = true;
this.is_dff_suspeded = is_dff_suspeded;
this.is_dff_suspededChanged = true;
this.is_ej_enabled = is_ej_enabled;
this.is_ej_enabledChanged = true;
this.is_counter_enabled = is_counter_enabled;
this.is_counter_enabledChanged = true;
this.priority = priority;
this.priorityChanged = true;
this.offline_atm_settlements_file_path = offline_atm_settlements_file_path;
this.offline_atm_settlements_file_pathChanged = true;
this.offline_atm_settlements_multicurrency_file_path = offline_atm_settlements_multicurrency_file_path;
this.offline_atm_settlements_multicurrency_file_pathChanged = true;
this.vault_summary_generation_time = vault_summary_generation_time;
this.vault_summary_generation_timeChanged = true;
}
private Region( int region_id,string region_name,int? parent_region_id,string location,string country,string mCN,int? region_cit_id,byte[] bank_logo,bool is_active,int created_by,int? modified_by,DateTime creation_time,bool is_organization,bool? suspend_cash_order,DateTime? daily_feed_generation_time,string daily_feed_output_file_path,int? daily_feed_generation_delay,string cash_order_downloaded_file_path,string daily_feed_ftp_uri,string daily_feed_ftp_username,string daily_feed_ftp_password,string cash_order_ftp_uri,string cash_order_ftp_username,string cash_order_ftp_password,string cash_order_archive_url,int? number_of_types,bool is_dff_version_2_configured,int retry_count_cash_order_download,int retry_count_dff_upload,int retry_count_alert,bool? is_secured_access,decimal? card_captured_cost,decimal? escotting_cost,decimal? replenishment_cost,decimal? maintenance_cost,decimal? flm_call_out_cost,string dff_naming_convention,string configured_cassettes,string configured_cassettes_denomination,int? seconds_between_trxn_in_ej_and_ccms,string smtp_server,int? smtp_port,string smtp_username,string smtp_password,bool is_dff_suspeded,bool is_ej_enabled,bool is_counter_enabled,int priority,string offline_atm_settlements_file_path,string offline_atm_settlements_multicurrency_file_path,DateTime? vault_summary_generation_time )
{
this.region_id = region_id;
this.region_idChanged = true;
this.region_name = region_name;
this.region_nameChanged = true;
this.parent_region_id = parent_region_id;
this.parent_region_idChanged = true;
this.location = location;
this.locationChanged = true;
this.country = country;
this.countryChanged = true;
this.mCN = mCN;
this.mCNChanged = true;
this.region_cit_id = region_cit_id;
this.region_cit_idChanged = true;
this.bank_logo = bank_logo;
this.bank_logoChanged = true;
this.is_active = is_active;
this.is_activeChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.creation_time = creation_time;
this.creation_timeChanged = true;
this.is_organization = is_organization;
this.is_organizationChanged = true;
this.suspend_cash_order = suspend_cash_order;
this.suspend_cash_orderChanged = true;
this.daily_feed_generation_time = daily_feed_generation_time;
this.daily_feed_generation_timeChanged = true;
this.daily_feed_output_file_path = daily_feed_output_file_path;
this.daily_feed_output_file_pathChanged = true;
this.daily_feed_generation_delay = daily_feed_generation_delay;
this.daily_feed_generation_delayChanged = true;
this.cash_order_downloaded_file_path = cash_order_downloaded_file_path;
this.cash_order_downloaded_file_pathChanged = true;
this.daily_feed_ftp_uri = daily_feed_ftp_uri;
this.daily_feed_ftp_uriChanged = true;
this.daily_feed_ftp_username = daily_feed_ftp_username;
this.daily_feed_ftp_usernameChanged = true;
this.daily_feed_ftp_password = daily_feed_ftp_password;
this.daily_feed_ftp_passwordChanged = true;
this.cash_order_ftp_uri = cash_order_ftp_uri;
this.cash_order_ftp_uriChanged = true;
this.cash_order_ftp_username = cash_order_ftp_username;
this.cash_order_ftp_usernameChanged = true;
this.cash_order_ftp_password = cash_order_ftp_password;
this.cash_order_ftp_passwordChanged = true;
this.cash_order_archive_url = cash_order_archive_url;
this.cash_order_archive_urlChanged = true;
this.number_of_types = number_of_types;
this.number_of_typesChanged = true;
this.is_dff_version_2_configured = is_dff_version_2_configured;
this.is_dff_version_2_configuredChanged = true;
this.retry_count_cash_order_download = retry_count_cash_order_download;
this.retry_count_cash_order_downloadChanged = true;
this.retry_count_dff_upload = retry_count_dff_upload;
this.retry_count_dff_uploadChanged = true;
this.retry_count_alert = retry_count_alert;
this.retry_count_alertChanged = true;
this.is_secured_access = is_secured_access;
this.is_secured_accessChanged = true;
this.card_captured_cost = card_captured_cost;
this.card_captured_costChanged = true;
this.escotting_cost = escotting_cost;
this.escotting_costChanged = true;
this.replenishment_cost = replenishment_cost;
this.replenishment_costChanged = true;
this.maintenance_cost = maintenance_cost;
this.maintenance_costChanged = true;
this.flm_call_out_cost = flm_call_out_cost;
this.flm_call_out_costChanged = true;
this.dff_naming_convention = dff_naming_convention;
this.dff_naming_conventionChanged = true;
this.configured_cassettes = configured_cassettes;
this.configured_cassettesChanged = true;
this.configured_cassettes_denomination = configured_cassettes_denomination;
this.configured_cassettes_denominationChanged = true;
this.seconds_between_trxn_in_ej_and_ccms = seconds_between_trxn_in_ej_and_ccms;
this.seconds_between_trxn_in_ej_and_ccmsChanged = true;
this.smtp_server = smtp_server;
this.smtp_serverChanged = true;
this.smtp_port = smtp_port;
this.smtp_portChanged = true;
this.smtp_username = smtp_username;
this.smtp_usernameChanged = true;
this.smtp_password = smtp_password;
this.smtp_passwordChanged = true;
this.is_dff_suspeded = is_dff_suspeded;
this.is_dff_suspededChanged = true;
this.is_ej_enabled = is_ej_enabled;
this.is_ej_enabledChanged = true;
this.is_counter_enabled = is_counter_enabled;
this.is_counter_enabledChanged = true;
this.priority = priority;
this.priorityChanged = true;
this.offline_atm_settlements_file_path = offline_atm_settlements_file_path;
this.offline_atm_settlements_file_pathChanged = true;
this.offline_atm_settlements_multicurrency_file_path = offline_atm_settlements_multicurrency_file_path;
this.offline_atm_settlements_multicurrency_file_pathChanged = true;
this.vault_summary_generation_time = vault_summary_generation_time;
this.vault_summary_generation_timeChanged = true;
}

#region members and properties for columns

#region RegionId
private bool region_idChanged = false;
private int region_id;
public int RegionId
{
get { return region_id; }
set { 
region_id = value;
region_idChanged = true;
}
}
private string region_idDbString
{
get
{
return region_id.ToString();
}
}
#endregion
#region RegionName
private bool region_nameChanged = false;
private string region_name;
public string RegionName
{
get { return region_name; }
set { 
region_name = value;
region_nameChanged = true;
}
}
private string region_nameDbString
{
get
{
if (this.region_name!=null)
return string.Format("'{0}'",region_name); else
return "null";
}
}
#endregion
#region ParentRegionId
private bool parent_region_idChanged = false;
private int? parent_region_id;
public int? ParentRegionId
{
get { return parent_region_id; }
set { 
parent_region_id = value;
parent_region_idChanged = true;
}
}
private string parent_region_idDbString
{
get
{
if (this.parent_region_id.HasValue)
return parent_region_id.ToString();
else
return "null";
}
}
#endregion
#region Location
private bool locationChanged = false;
private string location;
public string Location
{
get { return location; }
set { 
location = value;
locationChanged = true;
}
}
private string locationDbString
{
get
{
if (this.location!=null)
return string.Format("'{0}'",location); else
return "null";
}
}
#endregion
#region Country
private bool countryChanged = false;
private string country;
public string Country
{
get { return country; }
set { 
country = value;
countryChanged = true;
}
}
private string countryDbString
{
get
{
if (this.country!=null)
return string.Format("'{0}'",country); else
return "null";
}
}
#endregion
#region MCN
private bool mCNChanged = false;
private string mCN;
public string MCN
{
get { return mCN; }
set { 
mCN = value;
mCNChanged = true;
}
}
private string mCNDbString
{
get
{
if (this.mCN!=null)
return string.Format("'{0}'",mCN); else
return "null";
}
}
#endregion
#region RegionCitId
private bool region_cit_idChanged = false;
private int? region_cit_id;
public int? RegionCitId
{
get { return region_cit_id; }
set { 
region_cit_id = value;
region_cit_idChanged = true;
}
}
private string region_cit_idDbString
{
get
{
if (this.region_cit_id.HasValue)
return region_cit_id.ToString();
else
return "null";
}
}
#endregion
#region BankLogo
private bool bank_logoChanged = false;
private byte[] bank_logo;
public byte[] BankLogo
{
get { return bank_logo; }
set { 
bank_logo = value;
bank_logoChanged = true;
}
}
private string bank_logoDbString
{
get
{
if (this.bank_logo!=null)
return "@bank_logo";
else
return "null";
}
}
#endregion
#region IsActive
private bool is_activeChanged = false;
private bool is_active;
public bool IsActive
{
get { return is_active; }
set { 
is_active = value;
is_activeChanged = true;
}
}
private string is_activeDbString
{
get
{
return is_active?"1":"0";
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
#region IsOrganization
private bool is_organizationChanged = false;
private bool is_organization;
public bool IsOrganization
{
get { return is_organization; }
set { 
is_organization = value;
is_organizationChanged = true;
}
}
private string is_organizationDbString
{
get
{
return is_organization?"1":"0";
}
}
#endregion
#region SuspendCashOrder
private bool suspend_cash_orderChanged = false;
private bool? suspend_cash_order;
public bool? SuspendCashOrder
{
get { return suspend_cash_order; }
set { 
suspend_cash_order = value;
suspend_cash_orderChanged = true;
}
}
private string suspend_cash_orderDbString
{
get
{
if (this.suspend_cash_order.HasValue)
return suspend_cash_order.Value?"1":"0";
else
return "null";
}
}
#endregion
#region DailyFeedGenerationTime
private bool daily_feed_generation_timeChanged = false;
private DateTime? daily_feed_generation_time;
public DateTime? DailyFeedGenerationTime
{
get { return daily_feed_generation_time; }
set { 
daily_feed_generation_time = value;
daily_feed_generation_timeChanged = true;
}
}
private string daily_feed_generation_timeDbString
{
get
{
if (this.daily_feed_generation_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",daily_feed_generation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region DailyFeedOutputFilePath
private bool daily_feed_output_file_pathChanged = false;
private string daily_feed_output_file_path;
public string DailyFeedOutputFilePath
{
get { return daily_feed_output_file_path; }
set { 
daily_feed_output_file_path = value;
daily_feed_output_file_pathChanged = true;
}
}
private string daily_feed_output_file_pathDbString
{
get
{
if (this.daily_feed_output_file_path!=null)
return string.Format("'{0}'",daily_feed_output_file_path); else
return "null";
}
}
#endregion
#region DailyFeedGenerationDelay
private bool daily_feed_generation_delayChanged = false;
private int? daily_feed_generation_delay;
public int? DailyFeedGenerationDelay
{
get { return daily_feed_generation_delay; }
set { 
daily_feed_generation_delay = value;
daily_feed_generation_delayChanged = true;
}
}
private string daily_feed_generation_delayDbString
{
get
{
if (this.daily_feed_generation_delay.HasValue)
return daily_feed_generation_delay.ToString();
else
return "null";
}
}
#endregion
#region CashOrderDownloadedFilePath
private bool cash_order_downloaded_file_pathChanged = false;
private string cash_order_downloaded_file_path;
public string CashOrderDownloadedFilePath
{
get { return cash_order_downloaded_file_path; }
set { 
cash_order_downloaded_file_path = value;
cash_order_downloaded_file_pathChanged = true;
}
}
private string cash_order_downloaded_file_pathDbString
{
get
{
if (this.cash_order_downloaded_file_path!=null)
return string.Format("'{0}'",cash_order_downloaded_file_path); else
return "null";
}
}
#endregion
#region DailyFeedFtpUri
private bool daily_feed_ftp_uriChanged = false;
private string daily_feed_ftp_uri;
public string DailyFeedFtpUri
{
get { return daily_feed_ftp_uri; }
set { 
daily_feed_ftp_uri = value;
daily_feed_ftp_uriChanged = true;
}
}
private string daily_feed_ftp_uriDbString
{
get
{
if (this.daily_feed_ftp_uri!=null)
return string.Format("'{0}'",daily_feed_ftp_uri); else
return "null";
}
}
#endregion
#region DailyFeedFtpUsername
private bool daily_feed_ftp_usernameChanged = false;
private string daily_feed_ftp_username;
public string DailyFeedFtpUsername
{
get { return daily_feed_ftp_username; }
set { 
daily_feed_ftp_username = value;
daily_feed_ftp_usernameChanged = true;
}
}
private string daily_feed_ftp_usernameDbString
{
get
{
if (this.daily_feed_ftp_username!=null)
return string.Format("'{0}'",daily_feed_ftp_username); else
return "null";
}
}
#endregion
#region DailyFeedFtpPassword
private bool daily_feed_ftp_passwordChanged = false;
private string daily_feed_ftp_password;
public string DailyFeedFtpPassword
{
get { return daily_feed_ftp_password; }
set { 
daily_feed_ftp_password = value;
daily_feed_ftp_passwordChanged = true;
}
}
private string daily_feed_ftp_passwordDbString
{
get
{
if (this.daily_feed_ftp_password!=null)
return string.Format("'{0}'",daily_feed_ftp_password); else
return "null";
}
}
#endregion
#region CashOrderFtpUri
private bool cash_order_ftp_uriChanged = false;
private string cash_order_ftp_uri;
public string CashOrderFtpUri
{
get { return cash_order_ftp_uri; }
set { 
cash_order_ftp_uri = value;
cash_order_ftp_uriChanged = true;
}
}
private string cash_order_ftp_uriDbString
{
get
{
if (this.cash_order_ftp_uri!=null)
return string.Format("'{0}'",cash_order_ftp_uri); else
return "null";
}
}
#endregion
#region CashOrderFtpUsername
private bool cash_order_ftp_usernameChanged = false;
private string cash_order_ftp_username;
public string CashOrderFtpUsername
{
get { return cash_order_ftp_username; }
set { 
cash_order_ftp_username = value;
cash_order_ftp_usernameChanged = true;
}
}
private string cash_order_ftp_usernameDbString
{
get
{
if (this.cash_order_ftp_username!=null)
return string.Format("'{0}'",cash_order_ftp_username); else
return "null";
}
}
#endregion
#region CashOrderFtpPassword
private bool cash_order_ftp_passwordChanged = false;
private string cash_order_ftp_password;
public string CashOrderFtpPassword
{
get { return cash_order_ftp_password; }
set { 
cash_order_ftp_password = value;
cash_order_ftp_passwordChanged = true;
}
}
private string cash_order_ftp_passwordDbString
{
get
{
if (this.cash_order_ftp_password!=null)
return string.Format("'{0}'",cash_order_ftp_password); else
return "null";
}
}
#endregion
#region CashOrderArchiveUrl
private bool cash_order_archive_urlChanged = false;
private string cash_order_archive_url;
public string CashOrderArchiveUrl
{
get { return cash_order_archive_url; }
set { 
cash_order_archive_url = value;
cash_order_archive_urlChanged = true;
}
}
private string cash_order_archive_urlDbString
{
get
{
if (this.cash_order_archive_url!=null)
return string.Format("'{0}'",cash_order_archive_url); else
return "null";
}
}
#endregion
#region NumberOfTypes
private bool number_of_typesChanged = false;
private int? number_of_types;
public int? NumberOfTypes
{
get { return number_of_types; }
set { 
number_of_types = value;
number_of_typesChanged = true;
}
}
private string number_of_typesDbString
{
get
{
if (this.number_of_types.HasValue)
return number_of_types.ToString();
else
return "null";
}
}
#endregion
#region IsDffVersion2Configured
private bool is_dff_version_2_configuredChanged = false;
private bool is_dff_version_2_configured;
public bool IsDffVersion2Configured
{
get { return is_dff_version_2_configured; }
set { 
is_dff_version_2_configured = value;
is_dff_version_2_configuredChanged = true;
}
}
private string is_dff_version_2_configuredDbString
{
get
{
return is_dff_version_2_configured?"1":"0";
}
}
#endregion
#region RetryCountCashOrderDownload
private bool retry_count_cash_order_downloadChanged = false;
private int retry_count_cash_order_download;
public int RetryCountCashOrderDownload
{
get { return retry_count_cash_order_download; }
set { 
retry_count_cash_order_download = value;
retry_count_cash_order_downloadChanged = true;
}
}
private string retry_count_cash_order_downloadDbString
{
get
{
return retry_count_cash_order_download.ToString();
}
}
#endregion
#region RetryCountDffUpload
private bool retry_count_dff_uploadChanged = false;
private int retry_count_dff_upload;
public int RetryCountDffUpload
{
get { return retry_count_dff_upload; }
set { 
retry_count_dff_upload = value;
retry_count_dff_uploadChanged = true;
}
}
private string retry_count_dff_uploadDbString
{
get
{
return retry_count_dff_upload.ToString();
}
}
#endregion
#region RetryCountAlert
private bool retry_count_alertChanged = false;
private int retry_count_alert;
public int RetryCountAlert
{
get { return retry_count_alert; }
set { 
retry_count_alert = value;
retry_count_alertChanged = true;
}
}
private string retry_count_alertDbString
{
get
{
return retry_count_alert.ToString();
}
}
#endregion
#region IsSecuredAccess
private bool is_secured_accessChanged = false;
private bool? is_secured_access;
public bool? IsSecuredAccess
{
get { return is_secured_access; }
set { 
is_secured_access = value;
is_secured_accessChanged = true;
}
}
private string is_secured_accessDbString
{
get
{
if (this.is_secured_access.HasValue)
return is_secured_access.Value?"1":"0";
else
return "null";
}
}
#endregion
#region CardCapturedCost
private bool card_captured_costChanged = false;
private decimal? card_captured_cost;
public decimal? CardCapturedCost
{
get { return card_captured_cost; }
set { 
card_captured_cost = value;
card_captured_costChanged = true;
}
}
private string card_captured_costDbString
{
get
{
if (this.card_captured_cost.HasValue)
return card_captured_cost.ToString();
else
return "null";
}
}
#endregion
#region EscottingCost
private bool escotting_costChanged = false;
private decimal? escotting_cost;
public decimal? EscottingCost
{
get { return escotting_cost; }
set { 
escotting_cost = value;
escotting_costChanged = true;
}
}
private string escotting_costDbString
{
get
{
if (this.escotting_cost.HasValue)
return escotting_cost.ToString();
else
return "null";
}
}
#endregion
#region ReplenishmentCost
private bool replenishment_costChanged = false;
private decimal? replenishment_cost;
public decimal? ReplenishmentCost
{
get { return replenishment_cost; }
set { 
replenishment_cost = value;
replenishment_costChanged = true;
}
}
private string replenishment_costDbString
{
get
{
if (this.replenishment_cost.HasValue)
return replenishment_cost.ToString();
else
return "null";
}
}
#endregion
#region MaintenanceCost
private bool maintenance_costChanged = false;
private decimal? maintenance_cost;
public decimal? MaintenanceCost
{
get { return maintenance_cost; }
set { 
maintenance_cost = value;
maintenance_costChanged = true;
}
}
private string maintenance_costDbString
{
get
{
if (this.maintenance_cost.HasValue)
return maintenance_cost.ToString();
else
return "null";
}
}
#endregion
#region FlmCallOutCost
private bool flm_call_out_costChanged = false;
private decimal? flm_call_out_cost;
public decimal? FlmCallOutCost
{
get { return flm_call_out_cost; }
set { 
flm_call_out_cost = value;
flm_call_out_costChanged = true;
}
}
private string flm_call_out_costDbString
{
get
{
if (this.flm_call_out_cost.HasValue)
return flm_call_out_cost.ToString();
else
return "null";
}
}
#endregion
#region DffNamingConvention
private bool dff_naming_conventionChanged = false;
private string dff_naming_convention;
public string DffNamingConvention
{
get { return dff_naming_convention; }
set { 
dff_naming_convention = value;
dff_naming_conventionChanged = true;
}
}
private string dff_naming_conventionDbString
{
get
{
if (this.dff_naming_convention!=null)
return string.Format("'{0}'",dff_naming_convention); else
return "null";
}
}
#endregion
#region ConfiguredCassettes
private bool configured_cassettesChanged = false;
private string configured_cassettes;
public string ConfiguredCassettes
{
get { return configured_cassettes; }
set { 
configured_cassettes = value;
configured_cassettesChanged = true;
}
}
private string configured_cassettesDbString
{
get
{
if (this.configured_cassettes!=null)
return string.Format("'{0}'",configured_cassettes); else
return "null";
}
}
#endregion
#region ConfiguredCassettesDenomination
private bool configured_cassettes_denominationChanged = false;
private string configured_cassettes_denomination;
public string ConfiguredCassettesDenomination
{
get { return configured_cassettes_denomination; }
set { 
configured_cassettes_denomination = value;
configured_cassettes_denominationChanged = true;
}
}
private string configured_cassettes_denominationDbString
{
get
{
if (this.configured_cassettes_denomination!=null)
return string.Format("'{0}'",configured_cassettes_denomination); else
return "null";
}
}
#endregion
#region SecondsBetweenTrxnInEjAndCcms
private bool seconds_between_trxn_in_ej_and_ccmsChanged = false;
private int? seconds_between_trxn_in_ej_and_ccms;
public int? SecondsBetweenTrxnInEjAndCcms
{
get { return seconds_between_trxn_in_ej_and_ccms; }
set { 
seconds_between_trxn_in_ej_and_ccms = value;
seconds_between_trxn_in_ej_and_ccmsChanged = true;
}
}
private string seconds_between_trxn_in_ej_and_ccmsDbString
{
get
{
if (this.seconds_between_trxn_in_ej_and_ccms.HasValue)
return seconds_between_trxn_in_ej_and_ccms.ToString();
else
return "null";
}
}
#endregion
#region SmtpServer
private bool smtp_serverChanged = false;
private string smtp_server;
public string SmtpServer
{
get { return smtp_server; }
set { 
smtp_server = value;
smtp_serverChanged = true;
}
}
private string smtp_serverDbString
{
get
{
if (this.smtp_server!=null)
return string.Format("'{0}'",smtp_server); else
return "null";
}
}
#endregion
#region SmtpPort
private bool smtp_portChanged = false;
private int? smtp_port;
public int? SmtpPort
{
get { return smtp_port; }
set { 
smtp_port = value;
smtp_portChanged = true;
}
}
private string smtp_portDbString
{
get
{
if (this.smtp_port.HasValue)
return smtp_port.ToString();
else
return "null";
}
}
#endregion
#region SmtpUsername
private bool smtp_usernameChanged = false;
private string smtp_username;
public string SmtpUsername
{
get { return smtp_username; }
set { 
smtp_username = value;
smtp_usernameChanged = true;
}
}
private string smtp_usernameDbString
{
get
{
if (this.smtp_username!=null)
return string.Format("'{0}'",smtp_username); else
return "null";
}
}
#endregion
#region SmtpPassword
private bool smtp_passwordChanged = false;
private string smtp_password;
public string SmtpPassword
{
get { return smtp_password; }
set { 
smtp_password = value;
smtp_passwordChanged = true;
}
}
private string smtp_passwordDbString
{
get
{
if (this.smtp_password!=null)
return string.Format("'{0}'",smtp_password); else
return "null";
}
}
#endregion
#region IsDffSuspeded
private bool is_dff_suspededChanged = false;
private bool is_dff_suspeded;
public bool IsDffSuspeded
{
get { return is_dff_suspeded; }
set { 
is_dff_suspeded = value;
is_dff_suspededChanged = true;
}
}
private string is_dff_suspededDbString
{
get
{
return is_dff_suspeded?"1":"0";
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
#region IsCounterEnabled
private bool is_counter_enabledChanged = false;
private bool is_counter_enabled;
public bool IsCounterEnabled
{
get { return is_counter_enabled; }
set { 
is_counter_enabled = value;
is_counter_enabledChanged = true;
}
}
private string is_counter_enabledDbString
{
get
{
return is_counter_enabled?"1":"0";
}
}
#endregion
#region Priority
private bool priorityChanged = false;
private int priority;
public int Priority
{
get { return priority; }
set { 
priority = value;
priorityChanged = true;
}
}
private string priorityDbString
{
get
{
return priority.ToString();
}
}
#endregion
#region OfflineAtmSettlementsFilePath
private bool offline_atm_settlements_file_pathChanged = false;
private string offline_atm_settlements_file_path;
public string OfflineAtmSettlementsFilePath
{
get { return offline_atm_settlements_file_path; }
set { 
offline_atm_settlements_file_path = value;
offline_atm_settlements_file_pathChanged = true;
}
}
private string offline_atm_settlements_file_pathDbString
{
get
{
if (this.offline_atm_settlements_file_path!=null)
return string.Format("'{0}'",offline_atm_settlements_file_path); else
return "null";
}
}
#endregion
#region OfflineAtmSettlementsMulticurrencyFilePath
private bool offline_atm_settlements_multicurrency_file_pathChanged = false;
private string offline_atm_settlements_multicurrency_file_path;
public string OfflineAtmSettlementsMulticurrencyFilePath
{
get { return offline_atm_settlements_multicurrency_file_path; }
set { 
offline_atm_settlements_multicurrency_file_path = value;
offline_atm_settlements_multicurrency_file_pathChanged = true;
}
}
private string offline_atm_settlements_multicurrency_file_pathDbString
{
get
{
if (this.offline_atm_settlements_multicurrency_file_path!=null)
return string.Format("'{0}'",offline_atm_settlements_multicurrency_file_path); else
return "null";
}
}
#endregion
#region VaultSummaryGenerationTime
private bool vault_summary_generation_timeChanged = false;
private DateTime? vault_summary_generation_time;
public DateTime? VaultSummaryGenerationTime
{
get { return vault_summary_generation_time; }
set { 
vault_summary_generation_time = value;
vault_summary_generation_timeChanged = true;
}
}
private string vault_summary_generation_timeDbString
{
get
{
if (this.vault_summary_generation_time.HasValue)
return string.Format("Convert(datetime,'{0}',121)",vault_summary_generation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#endregion

#region RegionReader
public class RegionReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
Region currentRegion;
Columns columns;
bool partialRead = false;
private RegionReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public RegionReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public RegionReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentRegion; }

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
currentRegion = new Region();
if (partialRead)
{ if ((columns & Columns.region_id) == Columns.region_id && reader["region_id"]!=DBNull.Value)
currentRegion.region_id =(int) reader["region_id"]; 
if ((columns & Columns.region_name) == Columns.region_name && reader["region_name"]!=DBNull.Value)
currentRegion.region_name =(string) reader["region_name"]; 
if ((columns & Columns.parent_region_id) == Columns.parent_region_id && reader["parent_region_id"]!=DBNull.Value)
currentRegion.parent_region_id =(int?) reader["parent_region_id"]; 
if ((columns & Columns.location) == Columns.location && reader["location"]!=DBNull.Value)
currentRegion.location =(string) reader["location"]; 
if ((columns & Columns.country) == Columns.country && reader["country"]!=DBNull.Value)
currentRegion.country =(string) reader["country"]; 
if ((columns & Columns.MCN) == Columns.MCN && reader["MCN"]!=DBNull.Value)
currentRegion.mCN =(string) reader["MCN"]; 
if ((columns & Columns.region_cit_id) == Columns.region_cit_id && reader["region_cit_id"]!=DBNull.Value)
currentRegion.region_cit_id =(int?) reader["region_cit_id"]; 
if ((columns & Columns.bank_logo) == Columns.bank_logo && reader["bank_logo"]!=DBNull.Value)
currentRegion.bank_logo =(byte[]) reader["bank_logo"]; 
if ((columns & Columns.is_active) == Columns.is_active && reader["is_active"]!=DBNull.Value)
currentRegion.is_active =(bool) reader["is_active"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentRegion.created_by =(int) reader["created_by"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentRegion.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.creation_time) == Columns.creation_time && reader["creation_time"]!=DBNull.Value)
currentRegion.creation_time =(DateTime) reader["creation_time"]; 
if ((columns & Columns.is_organization) == Columns.is_organization && reader["is_organization"]!=DBNull.Value)
currentRegion.is_organization =(bool) reader["is_organization"]; 
if ((columns & Columns.suspend_cash_order) == Columns.suspend_cash_order && reader["suspend_cash_order"]!=DBNull.Value)
currentRegion.suspend_cash_order =(bool?) reader["suspend_cash_order"]; 
if ((columns & Columns.daily_feed_generation_time) == Columns.daily_feed_generation_time && reader["daily_feed_generation_time"]!=DBNull.Value)
currentRegion.daily_feed_generation_time =(DateTime?) reader["daily_feed_generation_time"]; 
if ((columns & Columns.daily_feed_output_file_path) == Columns.daily_feed_output_file_path && reader["daily_feed_output_file_path"]!=DBNull.Value)
currentRegion.daily_feed_output_file_path =(string) reader["daily_feed_output_file_path"]; 
if ((columns & Columns.daily_feed_generation_delay) == Columns.daily_feed_generation_delay && reader["daily_feed_generation_delay"]!=DBNull.Value)
currentRegion.daily_feed_generation_delay =(int?) reader["daily_feed_generation_delay"]; 
if ((columns & Columns.cash_order_downloaded_file_path) == Columns.cash_order_downloaded_file_path && reader["cash_order_downloaded_file_path"]!=DBNull.Value)
currentRegion.cash_order_downloaded_file_path =(string) reader["cash_order_downloaded_file_path"]; 
if ((columns & Columns.daily_feed_ftp_uri) == Columns.daily_feed_ftp_uri && reader["daily_feed_ftp_uri"]!=DBNull.Value)
currentRegion.daily_feed_ftp_uri =(string) reader["daily_feed_ftp_uri"]; 
if ((columns & Columns.daily_feed_ftp_username) == Columns.daily_feed_ftp_username && reader["daily_feed_ftp_username"]!=DBNull.Value)
currentRegion.daily_feed_ftp_username =(string) reader["daily_feed_ftp_username"]; 
if ((columns & Columns.daily_feed_ftp_password) == Columns.daily_feed_ftp_password && reader["daily_feed_ftp_password"]!=DBNull.Value)
currentRegion.daily_feed_ftp_password =(string) reader["daily_feed_ftp_password"]; 
if ((columns & Columns.cash_order_ftp_uri) == Columns.cash_order_ftp_uri && reader["cash_order_ftp_uri"]!=DBNull.Value)
currentRegion.cash_order_ftp_uri =(string) reader["cash_order_ftp_uri"]; 
if ((columns & Columns.cash_order_ftp_username) == Columns.cash_order_ftp_username && reader["cash_order_ftp_username"]!=DBNull.Value)
currentRegion.cash_order_ftp_username =(string) reader["cash_order_ftp_username"]; 
if ((columns & Columns.cash_order_ftp_password) == Columns.cash_order_ftp_password && reader["cash_order_ftp_password"]!=DBNull.Value)
currentRegion.cash_order_ftp_password =(string) reader["cash_order_ftp_password"]; 
if ((columns & Columns.cash_order_archive_url) == Columns.cash_order_archive_url && reader["cash_order_archive_url"]!=DBNull.Value)
currentRegion.cash_order_archive_url =(string) reader["cash_order_archive_url"]; 
if ((columns & Columns.number_of_types) == Columns.number_of_types && reader["number_of_types"]!=DBNull.Value)
currentRegion.number_of_types =(int?) reader["number_of_types"]; 
if ((columns & Columns.is_dff_version_2_configured) == Columns.is_dff_version_2_configured && reader["is_dff_version_2_configured"]!=DBNull.Value)
currentRegion.is_dff_version_2_configured =(bool) reader["is_dff_version_2_configured"]; 
if ((columns & Columns.retry_count_cash_order_download) == Columns.retry_count_cash_order_download && reader["retry_count_cash_order_download"]!=DBNull.Value)
currentRegion.retry_count_cash_order_download =(int) reader["retry_count_cash_order_download"]; 
if ((columns & Columns.retry_count_dff_upload) == Columns.retry_count_dff_upload && reader["retry_count_dff_upload"]!=DBNull.Value)
currentRegion.retry_count_dff_upload =(int) reader["retry_count_dff_upload"]; 
if ((columns & Columns.retry_count_alert) == Columns.retry_count_alert && reader["retry_count_alert"]!=DBNull.Value)
currentRegion.retry_count_alert =(int) reader["retry_count_alert"]; 
if ((columns & Columns.is_secured_access) == Columns.is_secured_access && reader["is_secured_access"]!=DBNull.Value)
currentRegion.is_secured_access =(bool?) reader["is_secured_access"]; 
if ((columns & Columns.card_captured_cost) == Columns.card_captured_cost && reader["card_captured_cost"]!=DBNull.Value)
currentRegion.card_captured_cost =(decimal?) reader["card_captured_cost"]; 
if ((columns & Columns.escotting_cost) == Columns.escotting_cost && reader["escotting_cost"]!=DBNull.Value)
currentRegion.escotting_cost =(decimal?) reader["escotting_cost"]; 
if ((columns & Columns.replenishment_cost) == Columns.replenishment_cost && reader["replenishment_cost"]!=DBNull.Value)
currentRegion.replenishment_cost =(decimal?) reader["replenishment_cost"]; 
if ((columns & Columns.maintenance_cost) == Columns.maintenance_cost && reader["maintenance_cost"]!=DBNull.Value)
currentRegion.maintenance_cost =(decimal?) reader["maintenance_cost"]; 
if ((columns & Columns.flm_call_out_cost) == Columns.flm_call_out_cost && reader["flm_call_out_cost"]!=DBNull.Value)
currentRegion.flm_call_out_cost =(decimal?) reader["flm_call_out_cost"]; 
if ((columns & Columns.dff_naming_convention) == Columns.dff_naming_convention && reader["dff_naming_convention"]!=DBNull.Value)
currentRegion.dff_naming_convention =(string) reader["dff_naming_convention"]; 
if ((columns & Columns.configured_cassettes) == Columns.configured_cassettes && reader["configured_cassettes"]!=DBNull.Value)
currentRegion.configured_cassettes =(string) reader["configured_cassettes"]; 
if ((columns & Columns.configured_cassettes_denomination) == Columns.configured_cassettes_denomination && reader["configured_cassettes_denomination"]!=DBNull.Value)
currentRegion.configured_cassettes_denomination =(string) reader["configured_cassettes_denomination"]; 
if ((columns & Columns.seconds_between_trxn_in_ej_and_ccms) == Columns.seconds_between_trxn_in_ej_and_ccms && reader["seconds_between_trxn_in_ej_and_ccms"]!=DBNull.Value)
currentRegion.seconds_between_trxn_in_ej_and_ccms =(int?) reader["seconds_between_trxn_in_ej_and_ccms"]; 
if ((columns & Columns.smtp_server) == Columns.smtp_server && reader["smtp_server"]!=DBNull.Value)
currentRegion.smtp_server =(string) reader["smtp_server"]; 
if ((columns & Columns.smtp_port) == Columns.smtp_port && reader["smtp_port"]!=DBNull.Value)
currentRegion.smtp_port =(int?) reader["smtp_port"]; 
if ((columns & Columns.smtp_username) == Columns.smtp_username && reader["smtp_username"]!=DBNull.Value)
currentRegion.smtp_username =(string) reader["smtp_username"]; 
if ((columns & Columns.smtp_password) == Columns.smtp_password && reader["smtp_password"]!=DBNull.Value)
currentRegion.smtp_password =(string) reader["smtp_password"]; 
if ((columns & Columns.is_dff_suspeded) == Columns.is_dff_suspeded && reader["is_dff_suspeded"]!=DBNull.Value)
currentRegion.is_dff_suspeded =(bool) reader["is_dff_suspeded"]; 
if ((columns & Columns.is_ej_enabled) == Columns.is_ej_enabled && reader["is_ej_enabled"]!=DBNull.Value)
currentRegion.is_ej_enabled =(bool) reader["is_ej_enabled"]; 
if ((columns & Columns.is_counter_enabled) == Columns.is_counter_enabled && reader["is_counter_enabled"]!=DBNull.Value)
currentRegion.is_counter_enabled =(bool) reader["is_counter_enabled"]; 
if ((columns & Columns.priority) == Columns.priority && reader["priority"]!=DBNull.Value)
currentRegion.priority =(int) reader["priority"]; 
if ((columns & Columns.offline_atm_settlements_file_path) == Columns.offline_atm_settlements_file_path && reader["offline_atm_settlements_file_path"]!=DBNull.Value)
currentRegion.offline_atm_settlements_file_path =(string) reader["offline_atm_settlements_file_path"]; 
if ((columns & Columns.offline_atm_settlements_multicurrency_file_path) == Columns.offline_atm_settlements_multicurrency_file_path && reader["offline_atm_settlements_multicurrency_file_path"]!=DBNull.Value)
currentRegion.offline_atm_settlements_multicurrency_file_path =(string) reader["offline_atm_settlements_multicurrency_file_path"]; 
if ((columns & Columns.vault_summary_generation_time) == Columns.vault_summary_generation_time && reader["vault_summary_generation_time"]!=DBNull.Value)
currentRegion.vault_summary_generation_time =(DateTime?) reader["vault_summary_generation_time"]; 

} else
{
if (reader["region_id"] != DBNull.Value)
currentRegion.region_id = (int) reader["region_id"]; 
if (reader["region_name"] != DBNull.Value)
currentRegion.region_name = (string) reader["region_name"]; 
if (reader["parent_region_id"] != DBNull.Value)
currentRegion.parent_region_id = (int?) reader["parent_region_id"]; 
if (reader["location"] != DBNull.Value)
currentRegion.location = (string) reader["location"]; 
if (reader["country"] != DBNull.Value)
currentRegion.country = (string) reader["country"]; 
if (reader["MCN"] != DBNull.Value)
currentRegion.mCN = (string) reader["MCN"]; 
if (reader["region_cit_id"] != DBNull.Value)
currentRegion.region_cit_id = (int?) reader["region_cit_id"]; 
if (reader["bank_logo"] != DBNull.Value)
currentRegion.bank_logo = (byte[]) reader["bank_logo"]; 
if (reader["is_active"] != DBNull.Value)
currentRegion.is_active = (bool) reader["is_active"]; 
if (reader["created_by"] != DBNull.Value)
currentRegion.created_by = (int) reader["created_by"]; 
if (reader["modified_by"] != DBNull.Value)
currentRegion.modified_by = (int?) reader["modified_by"]; 
if (reader["creation_time"] != DBNull.Value)
currentRegion.creation_time = (DateTime) reader["creation_time"]; 
if (reader["is_organization"] != DBNull.Value)
currentRegion.is_organization = (bool) reader["is_organization"]; 
if (reader["suspend_cash_order"] != DBNull.Value)
currentRegion.suspend_cash_order = (bool?) reader["suspend_cash_order"]; 
if (reader["daily_feed_generation_time"] != DBNull.Value)
currentRegion.daily_feed_generation_time = (DateTime?) reader["daily_feed_generation_time"]; 
if (reader["daily_feed_output_file_path"] != DBNull.Value)
currentRegion.daily_feed_output_file_path = (string) reader["daily_feed_output_file_path"]; 
if (reader["daily_feed_generation_delay"] != DBNull.Value)
currentRegion.daily_feed_generation_delay = (int?) reader["daily_feed_generation_delay"]; 
if (reader["cash_order_downloaded_file_path"] != DBNull.Value)
currentRegion.cash_order_downloaded_file_path = (string) reader["cash_order_downloaded_file_path"]; 
if (reader["daily_feed_ftp_uri"] != DBNull.Value)
currentRegion.daily_feed_ftp_uri = (string) reader["daily_feed_ftp_uri"]; 
if (reader["daily_feed_ftp_username"] != DBNull.Value)
currentRegion.daily_feed_ftp_username = (string) reader["daily_feed_ftp_username"]; 
if (reader["daily_feed_ftp_password"] != DBNull.Value)
currentRegion.daily_feed_ftp_password = (string) reader["daily_feed_ftp_password"]; 
if (reader["cash_order_ftp_uri"] != DBNull.Value)
currentRegion.cash_order_ftp_uri = (string) reader["cash_order_ftp_uri"]; 
if (reader["cash_order_ftp_username"] != DBNull.Value)
currentRegion.cash_order_ftp_username = (string) reader["cash_order_ftp_username"]; 
if (reader["cash_order_ftp_password"] != DBNull.Value)
currentRegion.cash_order_ftp_password = (string) reader["cash_order_ftp_password"]; 
if (reader["cash_order_archive_url"] != DBNull.Value)
currentRegion.cash_order_archive_url = (string) reader["cash_order_archive_url"]; 
if (reader["number_of_types"] != DBNull.Value)
currentRegion.number_of_types = (int?) reader["number_of_types"]; 
if (reader["is_dff_version_2_configured"] != DBNull.Value)
currentRegion.is_dff_version_2_configured = (bool) reader["is_dff_version_2_configured"]; 
if (reader["retry_count_cash_order_download"] != DBNull.Value)
currentRegion.retry_count_cash_order_download = (int) reader["retry_count_cash_order_download"]; 
if (reader["retry_count_dff_upload"] != DBNull.Value)
currentRegion.retry_count_dff_upload = (int) reader["retry_count_dff_upload"]; 
if (reader["retry_count_alert"] != DBNull.Value)
currentRegion.retry_count_alert = (int) reader["retry_count_alert"]; 
if (reader["is_secured_access"] != DBNull.Value)
currentRegion.is_secured_access = (bool?) reader["is_secured_access"]; 
if (reader["card_captured_cost"] != DBNull.Value)
currentRegion.card_captured_cost = (decimal?) reader["card_captured_cost"]; 
if (reader["escotting_cost"] != DBNull.Value)
currentRegion.escotting_cost = (decimal?) reader["escotting_cost"]; 
if (reader["replenishment_cost"] != DBNull.Value)
currentRegion.replenishment_cost = (decimal?) reader["replenishment_cost"]; 
if (reader["maintenance_cost"] != DBNull.Value)
currentRegion.maintenance_cost = (decimal?) reader["maintenance_cost"]; 
if (reader["flm_call_out_cost"] != DBNull.Value)
currentRegion.flm_call_out_cost = (decimal?) reader["flm_call_out_cost"]; 
if (reader["dff_naming_convention"] != DBNull.Value)
currentRegion.dff_naming_convention = (string) reader["dff_naming_convention"]; 
if (reader["configured_cassettes"] != DBNull.Value)
currentRegion.configured_cassettes = (string) reader["configured_cassettes"]; 
if (reader["configured_cassettes_denomination"] != DBNull.Value)
currentRegion.configured_cassettes_denomination = (string) reader["configured_cassettes_denomination"]; 
if (reader["seconds_between_trxn_in_ej_and_ccms"] != DBNull.Value)
currentRegion.seconds_between_trxn_in_ej_and_ccms = (int?) reader["seconds_between_trxn_in_ej_and_ccms"]; 
if (reader["smtp_server"] != DBNull.Value)
currentRegion.smtp_server = (string) reader["smtp_server"]; 
if (reader["smtp_port"] != DBNull.Value)
currentRegion.smtp_port = (int?) reader["smtp_port"]; 
if (reader["smtp_username"] != DBNull.Value)
currentRegion.smtp_username = (string) reader["smtp_username"]; 
if (reader["smtp_password"] != DBNull.Value)
currentRegion.smtp_password = (string) reader["smtp_password"]; 
if (reader["is_dff_suspeded"] != DBNull.Value)
currentRegion.is_dff_suspeded = (bool) reader["is_dff_suspeded"]; 
if (reader["is_ej_enabled"] != DBNull.Value)
currentRegion.is_ej_enabled = (bool) reader["is_ej_enabled"]; 
if (reader["is_counter_enabled"] != DBNull.Value)
currentRegion.is_counter_enabled = (bool) reader["is_counter_enabled"]; 
if (reader["priority"] != DBNull.Value)
currentRegion.priority = (int) reader["priority"]; 
if (reader["offline_atm_settlements_file_path"] != DBNull.Value)
currentRegion.offline_atm_settlements_file_path = (string) reader["offline_atm_settlements_file_path"]; 
if (reader["offline_atm_settlements_multicurrency_file_path"] != DBNull.Value)
currentRegion.offline_atm_settlements_multicurrency_file_path = (string) reader["offline_atm_settlements_multicurrency_file_path"]; 
if (reader["vault_summary_generation_time"] != DBNull.Value)
currentRegion.vault_summary_generation_time = (DateTime?) reader["vault_summary_generation_time"]; 
} 

currentRegion.isNewEntity = false;
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

public Region CurrentRegion
{
get{ return currentRegion; }
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


#region Region functions

public static RegionReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.region_id == (Columns.region_id & columns))
qry.Append("region_id,");
if (Columns.region_name == (Columns.region_name & columns))
qry.Append("region_name,");
if (Columns.parent_region_id == (Columns.parent_region_id & columns))
qry.Append("parent_region_id,");
if (Columns.location == (Columns.location & columns))
qry.Append("location,");
if (Columns.country == (Columns.country & columns))
qry.Append("country,");
if (Columns.MCN == (Columns.MCN & columns))
qry.Append("MCN,");
if (Columns.region_cit_id == (Columns.region_cit_id & columns))
qry.Append("region_cit_id,");
if (Columns.bank_logo == (Columns.bank_logo & columns))
qry.Append("bank_logo,");
if (Columns.is_active == (Columns.is_active & columns))
qry.Append("is_active,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.creation_time == (Columns.creation_time & columns))
qry.Append("creation_time,");
if (Columns.is_organization == (Columns.is_organization & columns))
qry.Append("is_organization,");
if (Columns.suspend_cash_order == (Columns.suspend_cash_order & columns))
qry.Append("suspend_cash_order,");
if (Columns.daily_feed_generation_time == (Columns.daily_feed_generation_time & columns))
qry.Append("daily_feed_generation_time,");
if (Columns.daily_feed_output_file_path == (Columns.daily_feed_output_file_path & columns))
qry.Append("daily_feed_output_file_path,");
if (Columns.daily_feed_generation_delay == (Columns.daily_feed_generation_delay & columns))
qry.Append("daily_feed_generation_delay,");
if (Columns.cash_order_downloaded_file_path == (Columns.cash_order_downloaded_file_path & columns))
qry.Append("cash_order_downloaded_file_path,");
if (Columns.daily_feed_ftp_uri == (Columns.daily_feed_ftp_uri & columns))
qry.Append("daily_feed_ftp_uri,");
if (Columns.daily_feed_ftp_username == (Columns.daily_feed_ftp_username & columns))
qry.Append("daily_feed_ftp_username,");
if (Columns.daily_feed_ftp_password == (Columns.daily_feed_ftp_password & columns))
qry.Append("daily_feed_ftp_password,");
if (Columns.cash_order_ftp_uri == (Columns.cash_order_ftp_uri & columns))
qry.Append("cash_order_ftp_uri,");
if (Columns.cash_order_ftp_username == (Columns.cash_order_ftp_username & columns))
qry.Append("cash_order_ftp_username,");
if (Columns.cash_order_ftp_password == (Columns.cash_order_ftp_password & columns))
qry.Append("cash_order_ftp_password,");
if (Columns.cash_order_archive_url == (Columns.cash_order_archive_url & columns))
qry.Append("cash_order_archive_url,");
if (Columns.number_of_types == (Columns.number_of_types & columns))
qry.Append("number_of_types,");
if (Columns.is_dff_version_2_configured == (Columns.is_dff_version_2_configured & columns))
qry.Append("is_dff_version_2_configured,");
if (Columns.retry_count_cash_order_download == (Columns.retry_count_cash_order_download & columns))
qry.Append("retry_count_cash_order_download,");
if (Columns.retry_count_dff_upload == (Columns.retry_count_dff_upload & columns))
qry.Append("retry_count_dff_upload,");
if (Columns.retry_count_alert == (Columns.retry_count_alert & columns))
qry.Append("retry_count_alert,");
if (Columns.is_secured_access == (Columns.is_secured_access & columns))
qry.Append("is_secured_access,");
if (Columns.card_captured_cost == (Columns.card_captured_cost & columns))
qry.Append("card_captured_cost,");
if (Columns.escotting_cost == (Columns.escotting_cost & columns))
qry.Append("escotting_cost,");
if (Columns.replenishment_cost == (Columns.replenishment_cost & columns))
qry.Append("replenishment_cost,");
if (Columns.maintenance_cost == (Columns.maintenance_cost & columns))
qry.Append("maintenance_cost,");
if (Columns.flm_call_out_cost == (Columns.flm_call_out_cost & columns))
qry.Append("flm_call_out_cost,");
if (Columns.dff_naming_convention == (Columns.dff_naming_convention & columns))
qry.Append("dff_naming_convention,");
if (Columns.configured_cassettes == (Columns.configured_cassettes & columns))
qry.Append("configured_cassettes,");
if (Columns.configured_cassettes_denomination == (Columns.configured_cassettes_denomination & columns))
qry.Append("configured_cassettes_denomination,");
if (Columns.seconds_between_trxn_in_ej_and_ccms == (Columns.seconds_between_trxn_in_ej_and_ccms & columns))
qry.Append("seconds_between_trxn_in_ej_and_ccms,");
if (Columns.smtp_server == (Columns.smtp_server & columns))
qry.Append("smtp_server,");
if (Columns.smtp_port == (Columns.smtp_port & columns))
qry.Append("smtp_port,");
if (Columns.smtp_username == (Columns.smtp_username & columns))
qry.Append("smtp_username,");
if (Columns.smtp_password == (Columns.smtp_password & columns))
qry.Append("smtp_password,");
if (Columns.is_dff_suspeded == (Columns.is_dff_suspeded & columns))
qry.Append("is_dff_suspeded,");
if (Columns.is_ej_enabled == (Columns.is_ej_enabled & columns))
qry.Append("is_ej_enabled,");
if (Columns.is_counter_enabled == (Columns.is_counter_enabled & columns))
qry.Append("is_counter_enabled,");
if (Columns.priority == (Columns.priority & columns))
qry.Append("priority,");
if (Columns.offline_atm_settlements_file_path == (Columns.offline_atm_settlements_file_path & columns))
qry.Append("offline_atm_settlements_file_path,");
if (Columns.offline_atm_settlements_multicurrency_file_path == (Columns.offline_atm_settlements_multicurrency_file_path & columns))
qry.Append("offline_atm_settlements_multicurrency_file_path,");
if (Columns.vault_summary_generation_time == (Columns.vault_summary_generation_time & columns))
qry.Append("vault_summary_generation_time,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Region ");

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
return new RegionReader(cmd.ExecuteReader(), conn, columns);
}

static public RegionReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static RegionReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select region_id,region_name,parent_region_id,location,country,MCN,region_cit_id,bank_logo,is_active,created_by,modified_by,creation_time,is_organization,suspend_cash_order,daily_feed_generation_time,daily_feed_output_file_path,daily_feed_generation_delay,cash_order_downloaded_file_path,daily_feed_ftp_uri,daily_feed_ftp_username,daily_feed_ftp_password,cash_order_ftp_uri,cash_order_ftp_username,cash_order_ftp_password,cash_order_archive_url,number_of_types,is_dff_version_2_configured,retry_count_cash_order_download,retry_count_dff_upload,retry_count_alert,is_secured_access,card_captured_cost,escotting_cost,replenishment_cost,maintenance_cost,flm_call_out_cost,dff_naming_convention,configured_cassettes,configured_cassettes_denomination,seconds_between_trxn_in_ej_and_ccms,smtp_server,smtp_port,smtp_username,smtp_password,is_dff_suspeded,is_ej_enabled,is_counter_enabled,priority,offline_atm_settlements_file_path,offline_atm_settlements_multicurrency_file_path,vault_summary_generation_time from Region ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new RegionReader(cmd.ExecuteReader(), conn);
}

static public RegionReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static Region LoadRegion(string where)
{
RegionReader reader = Region.ExecuteReader(where);
Region _region = null;
if (reader.Read())
_region = reader.CurrentRegion;
reader.Close();
return _region;
}

public static Region LoadRegion(string where, IDbConnection conn)
{
RegionReader reader = Region.ExecuteReader(where, conn);
Region _region = null;
if (reader.Read())
_region = reader.CurrentRegion;
reader.Close(false);
return _region;
}

public static Region LoadRegionByPk( int region_id )
{
return LoadRegion( " region_id="+region_id );
}

public static Region LoadRegionByPk( int region_id , IDbConnection conn)
{
return LoadRegion(" region_id="+region_id , conn);
}

public void Save()
{
if (region_idChanged || region_nameChanged || parent_region_idChanged || locationChanged || countryChanged || mCNChanged || region_cit_idChanged || bank_logoChanged || is_activeChanged || created_byChanged || modified_byChanged || creation_timeChanged || is_organizationChanged || suspend_cash_orderChanged || daily_feed_generation_timeChanged || daily_feed_output_file_pathChanged || daily_feed_generation_delayChanged || cash_order_downloaded_file_pathChanged || daily_feed_ftp_uriChanged || daily_feed_ftp_usernameChanged || daily_feed_ftp_passwordChanged || cash_order_ftp_uriChanged || cash_order_ftp_usernameChanged || cash_order_ftp_passwordChanged || cash_order_archive_urlChanged || number_of_typesChanged || is_dff_version_2_configuredChanged || retry_count_cash_order_downloadChanged || retry_count_dff_uploadChanged || retry_count_alertChanged || is_secured_accessChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || dff_naming_conventionChanged || configured_cassettesChanged || configured_cassettes_denominationChanged || seconds_between_trxn_in_ej_and_ccmsChanged || smtp_serverChanged || smtp_portChanged || smtp_usernameChanged || smtp_passwordChanged || is_dff_suspededChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || offline_atm_settlements_file_pathChanged || offline_atm_settlements_multicurrency_file_pathChanged || vault_summary_generation_timeChanged )
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
if (region_idChanged || region_nameChanged || parent_region_idChanged || locationChanged || countryChanged || mCNChanged || region_cit_idChanged || bank_logoChanged || is_activeChanged || created_byChanged || modified_byChanged || creation_timeChanged || is_organizationChanged || suspend_cash_orderChanged || daily_feed_generation_timeChanged || daily_feed_output_file_pathChanged || daily_feed_generation_delayChanged || cash_order_downloaded_file_pathChanged || daily_feed_ftp_uriChanged || daily_feed_ftp_usernameChanged || daily_feed_ftp_passwordChanged || cash_order_ftp_uriChanged || cash_order_ftp_usernameChanged || cash_order_ftp_passwordChanged || cash_order_archive_urlChanged || number_of_typesChanged || is_dff_version_2_configuredChanged || retry_count_cash_order_downloadChanged || retry_count_dff_uploadChanged || retry_count_alertChanged || is_secured_accessChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || dff_naming_conventionChanged || configured_cassettesChanged || configured_cassettes_denominationChanged || seconds_between_trxn_in_ej_and_ccmsChanged || smtp_serverChanged || smtp_portChanged || smtp_usernameChanged || smtp_passwordChanged || is_dff_suspededChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || offline_atm_settlements_file_pathChanged || offline_atm_settlements_multicurrency_file_pathChanged || vault_summary_generation_timeChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Region( region_id,region_name,parent_region_id,location,country,MCN,region_cit_id,bank_logo,is_active,created_by,modified_by,creation_time,is_organization,suspend_cash_order,daily_feed_generation_time,daily_feed_output_file_path,daily_feed_generation_delay,cash_order_downloaded_file_path,daily_feed_ftp_uri,daily_feed_ftp_username,daily_feed_ftp_password,cash_order_ftp_uri,cash_order_ftp_username,cash_order_ftp_password,cash_order_archive_url,number_of_types,is_dff_version_2_configured,retry_count_cash_order_download,retry_count_dff_upload,retry_count_alert,is_secured_access,card_captured_cost,escotting_cost,replenishment_cost,maintenance_cost,flm_call_out_cost,dff_naming_convention,configured_cassettes,configured_cassettes_denomination,seconds_between_trxn_in_ej_and_ccms,smtp_server,smtp_port,smtp_username,smtp_password,is_dff_suspeded,is_ej_enabled,is_counter_enabled,priority,offline_atm_settlements_file_path,offline_atm_settlements_multicurrency_file_path,vault_summary_generation_time ) values(");
lock (ConnectionFactory.connectionString) { this.region_id = ConnectionFactory.GetNextId();
qry.Append(this.region_id);
} qry.Append(",");
qry.Append(region_nameDbString+",");
qry.Append(parent_region_idDbString+",");
qry.Append(locationDbString+",");
qry.Append(countryDbString+",");
qry.Append(mCNDbString+",");
qry.Append(region_cit_idDbString+",");
qry.Append(bank_logoDbString+",");
qry.Append(is_activeDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(creation_timeDbString+",");
qry.Append(is_organizationDbString+",");
qry.Append(suspend_cash_orderDbString+",");
qry.Append(daily_feed_generation_timeDbString+",");
qry.Append(daily_feed_output_file_pathDbString+",");
qry.Append(daily_feed_generation_delayDbString+",");
qry.Append(cash_order_downloaded_file_pathDbString+",");
qry.Append(daily_feed_ftp_uriDbString+",");
qry.Append(daily_feed_ftp_usernameDbString+",");
qry.Append(daily_feed_ftp_passwordDbString+",");
qry.Append(cash_order_ftp_uriDbString+",");
qry.Append(cash_order_ftp_usernameDbString+",");
qry.Append(cash_order_ftp_passwordDbString+",");
qry.Append(cash_order_archive_urlDbString+",");
qry.Append(number_of_typesDbString+",");
qry.Append(is_dff_version_2_configuredDbString+",");
qry.Append(retry_count_cash_order_downloadDbString+",");
qry.Append(retry_count_dff_uploadDbString+",");
qry.Append(retry_count_alertDbString+",");
qry.Append(is_secured_accessDbString+",");
qry.Append(card_captured_costDbString+",");
qry.Append(escotting_costDbString+",");
qry.Append(replenishment_costDbString+",");
qry.Append(maintenance_costDbString+",");
qry.Append(flm_call_out_costDbString+",");
qry.Append(dff_naming_conventionDbString+",");
qry.Append(configured_cassettesDbString+",");
qry.Append(configured_cassettes_denominationDbString+",");
qry.Append(seconds_between_trxn_in_ej_and_ccmsDbString+",");
qry.Append(smtp_serverDbString+",");
qry.Append(smtp_portDbString+",");
qry.Append(smtp_usernameDbString+",");
qry.Append(smtp_passwordDbString+",");
qry.Append(is_dff_suspededDbString+",");
qry.Append(is_ej_enabledDbString+",");
qry.Append(is_counter_enabledDbString+",");
qry.Append(priorityDbString+",");
qry.Append(offline_atm_settlements_file_pathDbString+",");
qry.Append(offline_atm_settlements_multicurrency_file_pathDbString+",");
qry.Append(vault_summary_generation_timeDbString);
qry.Append(");");

}
else
{
if (!(region_idChanged || region_nameChanged || parent_region_idChanged || locationChanged || countryChanged || mCNChanged || region_cit_idChanged || bank_logoChanged || is_activeChanged || created_byChanged || modified_byChanged || creation_timeChanged || is_organizationChanged || suspend_cash_orderChanged || daily_feed_generation_timeChanged || daily_feed_output_file_pathChanged || daily_feed_generation_delayChanged || cash_order_downloaded_file_pathChanged || daily_feed_ftp_uriChanged || daily_feed_ftp_usernameChanged || daily_feed_ftp_passwordChanged || cash_order_ftp_uriChanged || cash_order_ftp_usernameChanged || cash_order_ftp_passwordChanged || cash_order_archive_urlChanged || number_of_typesChanged || is_dff_version_2_configuredChanged || retry_count_cash_order_downloadChanged || retry_count_dff_uploadChanged || retry_count_alertChanged || is_secured_accessChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || dff_naming_conventionChanged || configured_cassettesChanged || configured_cassettes_denominationChanged || seconds_between_trxn_in_ej_and_ccmsChanged || smtp_serverChanged || smtp_portChanged || smtp_usernameChanged || smtp_passwordChanged || is_dff_suspededChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || offline_atm_settlements_file_pathChanged || offline_atm_settlements_multicurrency_file_pathChanged || vault_summary_generation_timeChanged ))
return;
qry.Append("UPDATE Region set "); if ( region_nameChanged )
{
qry.Append("region_name ="+region_nameDbString);
qry.Append(",");
}

if ( parent_region_idChanged )
{
qry.Append("parent_region_id ="+parent_region_idDbString);
qry.Append(",");
}

if ( locationChanged )
{
qry.Append("location ="+locationDbString);
qry.Append(",");
}

if ( countryChanged )
{
qry.Append("country ="+countryDbString);
qry.Append(",");
}

if ( mCNChanged )
{
qry.Append("MCN ="+mCNDbString);
qry.Append(",");
}

if ( region_cit_idChanged )
{
qry.Append("region_cit_id ="+region_cit_idDbString);
qry.Append(",");
}

if ( bank_logoChanged )
{
qry.Append("bank_logo ="+bank_logoDbString);
qry.Append(",");
}

if ( is_activeChanged )
{
qry.Append("is_active ="+is_activeDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( creation_timeChanged )
{
qry.Append("creation_time ="+creation_timeDbString);
qry.Append(",");
}

if ( is_organizationChanged )
{
qry.Append("is_organization ="+is_organizationDbString);
qry.Append(",");
}

if ( suspend_cash_orderChanged )
{
qry.Append("suspend_cash_order ="+suspend_cash_orderDbString);
qry.Append(",");
}

if ( daily_feed_generation_timeChanged )
{
qry.Append("daily_feed_generation_time ="+daily_feed_generation_timeDbString);
qry.Append(",");
}

if ( daily_feed_output_file_pathChanged )
{
qry.Append("daily_feed_output_file_path ="+daily_feed_output_file_pathDbString);
qry.Append(",");
}

if ( daily_feed_generation_delayChanged )
{
qry.Append("daily_feed_generation_delay ="+daily_feed_generation_delayDbString);
qry.Append(",");
}

if ( cash_order_downloaded_file_pathChanged )
{
qry.Append("cash_order_downloaded_file_path ="+cash_order_downloaded_file_pathDbString);
qry.Append(",");
}

if ( daily_feed_ftp_uriChanged )
{
qry.Append("daily_feed_ftp_uri ="+daily_feed_ftp_uriDbString);
qry.Append(",");
}

if ( daily_feed_ftp_usernameChanged )
{
qry.Append("daily_feed_ftp_username ="+daily_feed_ftp_usernameDbString);
qry.Append(",");
}

if ( daily_feed_ftp_passwordChanged )
{
qry.Append("daily_feed_ftp_password ="+daily_feed_ftp_passwordDbString);
qry.Append(",");
}

if ( cash_order_ftp_uriChanged )
{
qry.Append("cash_order_ftp_uri ="+cash_order_ftp_uriDbString);
qry.Append(",");
}

if ( cash_order_ftp_usernameChanged )
{
qry.Append("cash_order_ftp_username ="+cash_order_ftp_usernameDbString);
qry.Append(",");
}

if ( cash_order_ftp_passwordChanged )
{
qry.Append("cash_order_ftp_password ="+cash_order_ftp_passwordDbString);
qry.Append(",");
}

if ( cash_order_archive_urlChanged )
{
qry.Append("cash_order_archive_url ="+cash_order_archive_urlDbString);
qry.Append(",");
}

if ( number_of_typesChanged )
{
qry.Append("number_of_types ="+number_of_typesDbString);
qry.Append(",");
}

if ( is_dff_version_2_configuredChanged )
{
qry.Append("is_dff_version_2_configured ="+is_dff_version_2_configuredDbString);
qry.Append(",");
}

if ( retry_count_cash_order_downloadChanged )
{
qry.Append("retry_count_cash_order_download ="+retry_count_cash_order_downloadDbString);
qry.Append(",");
}

if ( retry_count_dff_uploadChanged )
{
qry.Append("retry_count_dff_upload ="+retry_count_dff_uploadDbString);
qry.Append(",");
}

if ( retry_count_alertChanged )
{
qry.Append("retry_count_alert ="+retry_count_alertDbString);
qry.Append(",");
}

if ( is_secured_accessChanged )
{
qry.Append("is_secured_access ="+is_secured_accessDbString);
qry.Append(",");
}

if ( card_captured_costChanged )
{
qry.Append("card_captured_cost ="+card_captured_costDbString);
qry.Append(",");
}

if ( escotting_costChanged )
{
qry.Append("escotting_cost ="+escotting_costDbString);
qry.Append(",");
}

if ( replenishment_costChanged )
{
qry.Append("replenishment_cost ="+replenishment_costDbString);
qry.Append(",");
}

if ( maintenance_costChanged )
{
qry.Append("maintenance_cost ="+maintenance_costDbString);
qry.Append(",");
}

if ( flm_call_out_costChanged )
{
qry.Append("flm_call_out_cost ="+flm_call_out_costDbString);
qry.Append(",");
}

if ( dff_naming_conventionChanged )
{
qry.Append("dff_naming_convention ="+dff_naming_conventionDbString);
qry.Append(",");
}

if ( configured_cassettesChanged )
{
qry.Append("configured_cassettes ="+configured_cassettesDbString);
qry.Append(",");
}

if ( configured_cassettes_denominationChanged )
{
qry.Append("configured_cassettes_denomination ="+configured_cassettes_denominationDbString);
qry.Append(",");
}

if ( seconds_between_trxn_in_ej_and_ccmsChanged )
{
qry.Append("seconds_between_trxn_in_ej_and_ccms ="+seconds_between_trxn_in_ej_and_ccmsDbString);
qry.Append(",");
}

if ( smtp_serverChanged )
{
qry.Append("smtp_server ="+smtp_serverDbString);
qry.Append(",");
}

if ( smtp_portChanged )
{
qry.Append("smtp_port ="+smtp_portDbString);
qry.Append(",");
}

if ( smtp_usernameChanged )
{
qry.Append("smtp_username ="+smtp_usernameDbString);
qry.Append(",");
}

if ( smtp_passwordChanged )
{
qry.Append("smtp_password ="+smtp_passwordDbString);
qry.Append(",");
}

if ( is_dff_suspededChanged )
{
qry.Append("is_dff_suspeded ="+is_dff_suspededDbString);
qry.Append(",");
}

if ( is_ej_enabledChanged )
{
qry.Append("is_ej_enabled ="+is_ej_enabledDbString);
qry.Append(",");
}

if ( is_counter_enabledChanged )
{
qry.Append("is_counter_enabled ="+is_counter_enabledDbString);
qry.Append(",");
}

if ( priorityChanged )
{
qry.Append("priority ="+priorityDbString);
qry.Append(",");
}

if ( offline_atm_settlements_file_pathChanged )
{
qry.Append("offline_atm_settlements_file_path ="+offline_atm_settlements_file_pathDbString);
qry.Append(",");
}

if ( offline_atm_settlements_multicurrency_file_pathChanged )
{
qry.Append("offline_atm_settlements_multicurrency_file_path ="+offline_atm_settlements_multicurrency_file_pathDbString);
qry.Append(",");
}

if ( vault_summary_generation_timeChanged )
{
qry.Append("vault_summary_generation_time ="+vault_summary_generation_timeDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("region_id = "+region_idDbString);
}
if ( bank_logoChanged )
{
IDbDataParameter dbParam_bank_logo = cmd.CreateParameter();
cmd.Parameters.Add(dbParam_bank_logo);
dbParam_bank_logo.ParameterName = "@bank_logo";
dbParam_bank_logo.Value = this.bank_logo;
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
cmd.CommandText = "DELETE Region where region_id = "+ region_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteRegions(string where)
{
ConnectionFactory.ExecuteQuery("delete Region where " + where);
}

#endregion
#region Columns enum
public enum Columns:ulong
{
region_id= 1,
region_name= 2,
parent_region_id= 4,
location= 8,
country= 16,
MCN= 32,
region_cit_id= 64,
bank_logo= 128,
is_active= 256,
created_by= 512,
modified_by= 1024,
creation_time= 2048,
is_organization= 4096,
suspend_cash_order= 8192,
daily_feed_generation_time= 16384,
daily_feed_output_file_path= 32768,
daily_feed_generation_delay= 65536,
cash_order_downloaded_file_path= 131072,
daily_feed_ftp_uri= 262144,
daily_feed_ftp_username= 524288,
daily_feed_ftp_password= 1048576,
cash_order_ftp_uri= 2097152,
cash_order_ftp_username= 4194304,
cash_order_ftp_password= 8388608,
cash_order_archive_url= 16777216,
number_of_types= 33554432,
is_dff_version_2_configured= 67108864,
retry_count_cash_order_download= 134217728,
retry_count_dff_upload= 268435456,
retry_count_alert= 536870912,
is_secured_access= 1073741824,
card_captured_cost= 2147483648,
escotting_cost= 4294967296,
replenishment_cost= 8589934592,
maintenance_cost= 17179869184,
flm_call_out_cost= 34359738368,
dff_naming_convention= 68719476736,
configured_cassettes= 137438953472,
configured_cassettes_denomination= 274877906944,
seconds_between_trxn_in_ej_and_ccms= 549755813888,
smtp_server= 1099511627776,
smtp_port= 2199023255552,
smtp_username= 4398046511104,
smtp_password= 8796093022208,
is_dff_suspeded= 17592186044416,
is_ej_enabled= 35184372088832,
is_counter_enabled= 70368744177664,
priority= 140737488355328,
offline_atm_settlements_file_path= 281474976710656,
offline_atm_settlements_multicurrency_file_path= 562949953421312,
vault_summary_generation_time= 1125899906842624
}
#endregion
public void BulkSave(List<Region> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Region";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(Region.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <Region> transList,ref DataTable dt)
{
foreach (Region tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["region_id"] =ConnectionFactory.GetNextId();
Row["region_name"] = tran.RegionName;
Row["parent_region_id"] = tran.ParentRegionId;
Row["location"] = tran.Location;
Row["country"] = tran.Country;
Row["mCN"] = tran.MCN;
Row["region_cit_id"] = tran.RegionCitId;
Row["bank_logo"] = tran.BankLogo;
Row["is_active"] = tran.IsActive;
Row["created_by"] = tran.CreatedBy;
Row["modified_by"] = tran.ModifiedBy;
Row["creation_time"] = tran.CreationTime;
Row["is_organization"] = tran.IsOrganization;
Row["suspend_cash_order"] = tran.SuspendCashOrder;
Row["daily_feed_generation_time"] = tran.DailyFeedGenerationTime;
Row["daily_feed_output_file_path"] = tran.DailyFeedOutputFilePath;
Row["daily_feed_generation_delay"] = tran.DailyFeedGenerationDelay;
Row["cash_order_downloaded_file_path"] = tran.CashOrderDownloadedFilePath;
Row["daily_feed_ftp_uri"] = tran.DailyFeedFtpUri;
Row["daily_feed_ftp_username"] = tran.DailyFeedFtpUsername;
Row["daily_feed_ftp_password"] = tran.DailyFeedFtpPassword;
Row["cash_order_ftp_uri"] = tran.CashOrderFtpUri;
Row["cash_order_ftp_username"] = tran.CashOrderFtpUsername;
Row["cash_order_ftp_password"] = tran.CashOrderFtpPassword;
Row["cash_order_archive_url"] = tran.CashOrderArchiveUrl;
Row["number_of_types"] = tran.NumberOfTypes;
Row["is_dff_version_2_configured"] = tran.IsDffVersion2Configured;
Row["retry_count_cash_order_download"] = tran.RetryCountCashOrderDownload;
Row["retry_count_dff_upload"] = tran.RetryCountDffUpload;
Row["retry_count_alert"] = tran.RetryCountAlert;
Row["is_secured_access"] = tran.IsSecuredAccess;
Row["card_captured_cost"] = tran.CardCapturedCost;
Row["escotting_cost"] = tran.EscottingCost;
Row["replenishment_cost"] = tran.ReplenishmentCost;
Row["maintenance_cost"] = tran.MaintenanceCost;
Row["flm_call_out_cost"] = tran.FlmCallOutCost;
Row["dff_naming_convention"] = tran.DffNamingConvention;
Row["configured_cassettes"] = tran.ConfiguredCassettes;
Row["configured_cassettes_denomination"] = tran.ConfiguredCassettesDenomination;
Row["seconds_between_trxn_in_ej_and_ccms"] = tran.SecondsBetweenTrxnInEjAndCcms;
Row["smtp_server"] = tran.SmtpServer;
Row["smtp_port"] = tran.SmtpPort;
Row["smtp_username"] = tran.SmtpUsername;
Row["smtp_password"] = tran.SmtpPassword;
Row["is_dff_suspeded"] = tran.IsDffSuspeded;
Row["is_ej_enabled"] = tran.IsEjEnabled;
Row["is_counter_enabled"] = tran.IsCounterEnabled;
Row["priority"] = tran.Priority;
Row["offline_atm_settlements_file_path"] = tran.OfflineAtmSettlementsFilePath;
Row["offline_atm_settlements_multicurrency_file_path"] = tran.OfflineAtmSettlementsMulticurrencyFilePath;
Row["vault_summary_generation_time"] = tran.VaultSummaryGenerationTime;
dt.Rows.Add(Row);
} }
}
}
