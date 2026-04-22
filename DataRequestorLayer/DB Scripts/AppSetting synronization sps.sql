
CREATE TYPE [dbo].[AppSetting_table_type] AS TABLE(
	[app_setting_id] [bigint] NOT NULL,
	[cash_data_stores_location] [varchar](512) NOT NULL,
	[defalt_atm_port] [int] NOT NULL,
	[refresh_interval] [int] NOT NULL,
	[temporary_folder] [varchar](512) NOT NULL,
	[logFile_path] [varchar](512) NOT NULL,
	[parsing_enabled] [bit] NOT NULL,
	[LicenseKey] [varchar](6000) NULL,
	[apply_password_policy] [bit] NOT NULL,
	[UI_log_level] [varchar](7) NOT NULL,
	[service_log_level] [varchar](7) NOT NULL,
	[heart_beat_refresh_interval] [int] NOT NULL,
	[smtp_username] [varchar](50) NULL,
	[smtp_password] [varchar](50) NULL,
	[smtp_server] [varchar](100) NULL,
	[smtp_port] [smallint] NULL,
	[smtp_requires_authentication] [bit] NULL,
	[downloaded_file_path] [varchar](255) NOT NULL,
	[server_ip] [varchar](50) NOT NULL,
	[server_port] [int] NOT NULL,
	[archival_days] [int] NULL,
	[archival_server] [varchar](50) NULL,
	[archival_database] [varchar](50) NULL,
	[archival_username] [varchar](50) NULL,
	[archival_password] [varchar](255) NULL,
	[dashboard_refresh_interval] [int] NOT NULL,
	[cash_order_execution_time] [datetime] NOT NULL,
	[threshold_for_alert] [int] NULL,
	[threshold_for_ftp] [int] NULL,
	[threshold_for_task] [int] NULL,
	[threshold_for_cashorder] [int] NULL,
	[hold_other_df_tasks] [bit] NOT NULL,
	[alert_expiration_time] [int] NULL,
	[is_ciphered_comm] [bit] NULL,
	[vault_day_balance_execution_time] [datetime] NULL,
	[retry_count_cash_order_upload] [int] NOT NULL,
	[retry_count_cash_order_download] [int] NOT NULL,
	[retry_count_dff_upload] [int] NOT NULL,
	[retry_count_conf_upload] [int] NOT NULL,
	[retry_count_counter_file] [int] NOT NULL,
	[retry_count_restart_schedule] [int] NOT NULL,
	[retry_count_datetime_schedule] [int] NOT NULL,
	[cut_over_log_file_interval] [int] NOT NULL,
	[retry_count_alert] [int] NOT NULL,
	[last_ej_summary_generated_at] [datetime] NULL,
	[failed_to_parse_threshold] [int] NULL,
	[active_directory_domain] [varchar](200) NULL,
	[is_suspected_rep_task_disabled] [bit] NULL,
	[rep_time_diff] [varchar](4) NULL,
	[rep_start_time] [varchar](5) NULL,
	[rep_end_time] [varchar](5) NULL,
	[notes_difference] [int] NULL,
	[is_duplicate_checking_enabled] [bit] NULL,
	[allowed_no_of_days_for_mismatched_trxn_processing] [int] NOT NULL,
	[is_dff_halted] [bit] NULL,
	[is_ledger_auto_created] [bit] NOT NULL,
	[initEjExecTime] [char](14) NULL,
	[server_port2] [int] NULL,
	[is_google_map_enabled] [bit] NULL,
	[ccms_parser_refresh_interval] [int] NULL,
	[cash_order_generation_time] [datetime] NULL,
	[currency_server_refresh_interval] [int] NULL,
	[currency_mng_password] [varchar](200) NULL,
	[exchange_password] [varchar](200) NULL,
	[exchange_pop_password] [varchar](200) NULL,
	[ej_parser_zip_password] [varchar](200) NULL,
	[ej_parser_ftp_Password] [varchar](200) NULL,
	[bank_name] [varchar](20) NULL,
	[sms_token] [varchar](2000) NULL,
	[sms_token_generated_at] [datetime] NULL,
	[customer_transaction_amount_threshold_low] [int] NULL,
	[customer_transaction_amount_threshold_medium] [int] NULL,
	[ServersInfo] [varbinary](max) NULL,
	[is_secured_access] [bit] NULL,
	[daily_feed_ftp_uri] [varchar](150) NULL,
	[daily_feed_ftp_username] [varchar](150) NULL,
	[daily_feed_ftp_password] [varchar](150) NULL,
	[daily_feed_generation_time] [datetime] NULL,
	[daily_feed_output_file_path] [varchar](150) NULL,
	[daily_feed_generation_delay] [int] NULL,
	is_edited bit 
)
GO





create PROCEDURE [dbo].[SaveAppSettingInfo] 
 @AppSetttingInfo AppSetting_table_type readonly
AS
BEGIN

	
	INSERT INTO app_setting
SELECT *  FROM @AppSetttingInfo n
WHERE NOT EXISTS (SELECT * FROM app_setting WHERE app_setting.app_setting_id = n.app_setting_id)

	select @@ROWCOUNT;
END




GO
create PROCEDURE [dbo].[GetEditedAppSetting] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from app_setting where is_edited = 1 ;
END


GO
create PROCEDURE [dbo].[GetAllAppSetting] 
AS
BEGIN

select * from app_setting
END

go





create procedure [dbo].[UpdateAppSettingInfo]
@AppSettingInfo AppSetting_table_type  READONLY
 as
 update e set 
 e.cash_data_stores_location=d.cash_data_stores_location,
 e.defalt_atm_port =d.defalt_atm_port,
 e.refresh_interval=d.refresh_interval,
 e.temporary_folder=d.temporary_folder,
 e.logFile_path=d.logFile_path,
 e.parsing_enabled=d.parsing_enabled,
 e.LicenseKey= d.LicenseKey,
 e.apply_password_policy=d.apply_password_policy,
 e.UI_log_level=d.UI_log_level,
 e.service_log_level=d.service_log_level,
 e.heart_beat_refresh_interval =d.heart_beat_refresh_interval,
 e.smtp_username=d.smtp_username,
 e.smtp_password=d.smtp_password,
 e.smtp_server=d.smtp_server,
 e.smtp_port=d.smtp_port,
 e.smtp_requires_authentication=d.smtp_requires_authentication,
 e.downloaded_file_path=d.downloaded_file_path,
 e.server_ip=d.server_ip,
 e.server_port=d.server_port,
 e.archival_days=d.archival_days,
 e.archival_server =d.archival_server,
 e.archival_database=d.archival_database,
 e.archival_username=d.archival_username,
 e.archival_password=d.archival_password,
 e.dashboard_refresh_interval=d.dashboard_refresh_interval,
 e.cash_order_execution_time=d.cash_order_execution_time,
 e.threshold_for_alert = d.threshold_for_alert,
 e.threshold_for_ftp = d.threshold_for_ftp,
e.threshold_for_task = d.threshold_for_task,
e.threshold_for_cashorder = d.threshold_for_cashorder,
e.hold_other_df_tasks = d.hold_other_df_tasks,
e.is_edited = 0,
 e.alert_expiration_time=d.alert_expiration_time,
 e.is_ciphered_comm=d.is_ciphered_comm,
 e.vault_day_balance_execution_time =d.vault_day_balance_execution_time,
 e.retry_count_cash_order_upload=d.retry_count_cash_order_upload,
 e.retry_count_cash_order_download=d.retry_count_cash_order_download,
 e.retry_count_dff_upload=d.retry_count_dff_upload,
 e.retry_count_conf_upload=d.retry_count_conf_upload,
 e.retry_count_counter_file=d.retry_count_counter_file,
 e.retry_count_restart_schedule = d.retry_count_restart_schedule,
 e.retry_count_datetime_schedule = d.retry_count_datetime_schedule,
e.cut_over_log_file_interval = d.cut_over_log_file_interval,
e.retry_count_alert = d.retry_count_alert,
e.last_ej_summary_generated_at = d.last_ej_summary_generated_at,
 e.active_directory_domain=d.active_directory_domain ,
  e.is_suspected_rep_task_disabled=d.is_suspected_rep_task_disabled ,
   e.rep_time_diff=d.rep_time_diff ,
e.rep_start_time=d.rep_start_time ,
 e.rep_end_time=d.rep_end_time ,
  e.notes_difference=d.notes_difference ,
e.is_duplicate_checking_enabled=d.is_duplicate_checking_enabled ,
e.allowed_no_of_days_for_mismatched_trxn_processing=d.allowed_no_of_days_for_mismatched_trxn_processing ,
e.is_dff_halted=d.is_dff_halted ,
 e.is_ledger_auto_created=d.is_ledger_auto_created ,
  e.initEjExecTime=d.initEjExecTime ,
  e.server_port2=d.server_port2,
  e.is_google_map_enabled=d.is_google_map_enabled,
  e.ccms_parser_refresh_interval=d.ccms_parser_refresh_interval,
  e.cash_order_generation_time=d.cash_order_generation_time,
  e.currency_server_refresh_interval=d.currency_server_refresh_interval,
  e.currency_mng_password=d.currency_mng_password,
  e.exchange_password=d.exchange_password,
  e.exchange_pop_password=d.exchange_pop_password,
  e.ej_parser_zip_password=d.ej_parser_zip_password,
  e.ej_parser_ftp_Password=d.ej_parser_ftp_Password,
  e.bank_name=d.bank_name,
  e.sms_token=d.sms_token,
  e.sms_token_generated_at=d.sms_token_generated_at,
  e.customer_transaction_amount_threshold_low=d.customer_transaction_amount_threshold_low,
  e.customer_transaction_amount_threshold_medium=d.customer_transaction_amount_threshold_medium,
  e.ServersInfo=d.ServersInfo,
  e.is_secured_access=d.is_secured_access,
  e.daily_feed_ftp_uri=d.daily_feed_ftp_uri,
  e.daily_feed_ftp_username=d.daily_feed_ftp_username,
  e.daily_feed_ftp_password=d.daily_feed_ftp_password,
  e.daily_feed_generation_time=d.daily_feed_generation_time ,
  e.daily_feed_output_file_path=d.daily_feed_output_file_path ,
  e.daily_feed_generation_delay=d.daily_feed_generation_delay 
 from app_setting e,@AppSettingInfo d
 where e.app_setting_id=d.app_setting_id 

go

alter PROCEDURE [dbo].[UpdateEditedAppSettingInfoInCore] 
@AppSettingsIds varchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	declare @sql varchar(max);
	set @sql = N'update app_setting set is_edited = 0 where app_setting_id in ('+ @AppSettingsIds +')';
	Exec(@sql);
	select @@ROWCOUNT;
END