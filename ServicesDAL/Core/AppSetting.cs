 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class AppSetting
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public AppSetting() { }
        public AppSetting(long app_setting_id, string cash_data_stores_location, int defalt_atm_port, int refresh_interval, string temporary_folder, string logFile_path, bool parsing_enabled, bool apply_password_policy, string uI_log_level, string service_log_level, int heart_beat_refresh_interval, string downloaded_file_path, string server_ip, int server_port, int dashboard_refresh_interval, DateTime cash_order_execution_time, bool hold_other_df_tasks, int retry_count_cash_order_upload, int retry_count_cash_order_download, int retry_count_dff_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int cut_over_log_file_interval, int retry_count_alert, int allowed_no_of_days_for_mismatched_trxn_processing, bool is_ledger_auto_created)
        {
            this.cash_data_stores_location = cash_data_stores_location;
            this.cash_data_stores_locationChanged = true;
            this.defalt_atm_port = defalt_atm_port;
            this.defalt_atm_portChanged = true;
            this.refresh_interval = refresh_interval;
            this.refresh_intervalChanged = true;
            this.temporary_folder = temporary_folder;
            this.temporary_folderChanged = true;
            this.logFile_path = logFile_path;
            this.logFile_pathChanged = true;
            this.parsing_enabled = parsing_enabled;
            this.parsing_enabledChanged = true;
            this.apply_password_policy = apply_password_policy;
            this.apply_password_policyChanged = true;
            this.uI_log_level = uI_log_level;
            this.uI_log_levelChanged = true;
            this.service_log_level = service_log_level;
            this.service_log_levelChanged = true;
            this.heart_beat_refresh_interval = heart_beat_refresh_interval;
            this.heart_beat_refresh_intervalChanged = true;
            this.downloaded_file_path = downloaded_file_path;
            this.downloaded_file_pathChanged = true;
            this.server_ip = server_ip;
            this.server_ipChanged = true;
            this.server_port = server_port;
            this.server_portChanged = true;
            this.dashboard_refresh_interval = dashboard_refresh_interval;
            this.dashboard_refresh_intervalChanged = true;
            this.cash_order_execution_time = cash_order_execution_time;
            this.cash_order_execution_timeChanged = true;
            this.hold_other_df_tasks = hold_other_df_tasks;
            this.hold_other_df_tasksChanged = true;
            this.retry_count_cash_order_upload = retry_count_cash_order_upload;
            this.retry_count_cash_order_uploadChanged = true;
            this.retry_count_cash_order_download = retry_count_cash_order_download;
            this.retry_count_cash_order_downloadChanged = true;
            this.retry_count_dff_upload = retry_count_dff_upload;
            this.retry_count_dff_uploadChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.retry_count_counter_file = retry_count_counter_file;
            this.retry_count_counter_fileChanged = true;
            this.retry_count_restart_schedule = retry_count_restart_schedule;
            this.retry_count_restart_scheduleChanged = true;
            this.retry_count_datetime_schedule = retry_count_datetime_schedule;
            this.retry_count_datetime_scheduleChanged = true;
            this.cut_over_log_file_interval = cut_over_log_file_interval;
            this.cut_over_log_file_intervalChanged = true;
            this.retry_count_alert = retry_count_alert;
            this.retry_count_alertChanged = true;
            this.allowed_no_of_days_for_mismatched_trxn_processing = allowed_no_of_days_for_mismatched_trxn_processing;
            this.allowed_no_of_days_for_mismatched_trxn_processingChanged = true;
            this.is_ledger_auto_created = is_ledger_auto_created;
            this.is_ledger_auto_createdChanged = true;
        }
        public AppSetting(string cash_data_stores_location, int defalt_atm_port, int refresh_interval, string temporary_folder, string logFile_path, bool parsing_enabled, string licenseKey, bool apply_password_policy, string uI_log_level, string service_log_level, int heart_beat_refresh_interval, string smtp_username, string smtp_password, string smtp_server, short? smtp_port, bool? smtp_requires_authentication, string downloaded_file_path, string server_ip, int server_port, int? archival_days, string archival_server, string archival_database, string archival_username, string archival_password, int dashboard_refresh_interval, DateTime cash_order_execution_time, int? threshold_for_alert, int? threshold_for_ftp, int? threshold_for_task, int? threshold_for_cashorder, bool hold_other_df_tasks, int? alert_expiration_time, bool? is_ciphered_comm, DateTime? vault_day_balance_execution_time, int retry_count_cash_order_upload, int retry_count_cash_order_download, int retry_count_dff_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int cut_over_log_file_interval, int retry_count_alert, DateTime? last_ej_summary_generated_at, int? failed_to_parse_threshold, string active_directory_domain, bool? is_suspected_rep_task_disabled, string rep_time_diff, string rep_start_time, string rep_end_time, int? notes_difference, bool? is_duplicate_checking_enabled, int allowed_no_of_days_for_mismatched_trxn_processing, bool? is_dff_halted, bool is_ledger_auto_created, string initEjExecTime, int? server_port2, bool? is_google_map_enabled, int? ccms_parser_refresh_interval, DateTime? cash_order_generation_time, int? currency_server_refresh_interval, string currency_mng_password, string exchange_password, string exchange_pop_password, string ej_parser_zip_password, string ej_parser_ftp_Password, string bank_name, string sms_token, DateTime? sms_token_generated_at, int? customer_transaction_amount_threshold_low, int? customer_transaction_amount_threshold_medium, byte[] serversInfo, bool? is_secured_access, string daily_feed_ftp_uri, string daily_feed_ftp_username, string daily_feed_ftp_password, DateTime? daily_feed_generation_time, string daily_feed_output_file_path, int? daily_feed_generation_delay, string coreDbName, string cashDbName, string txDbName, bool? is_edited, int? atm_data_streaming_heartbeat_port, int? atm_data_streaming_port, int? atm_on_demand_request_port, int? atm_on_demand_request_hearbeat_port)
        {
            this.cash_data_stores_location = cash_data_stores_location;
            this.cash_data_stores_locationChanged = true;
            this.defalt_atm_port = defalt_atm_port;
            this.defalt_atm_portChanged = true;
            this.refresh_interval = refresh_interval;
            this.refresh_intervalChanged = true;
            this.temporary_folder = temporary_folder;
            this.temporary_folderChanged = true;
            this.logFile_path = logFile_path;
            this.logFile_pathChanged = true;
            this.parsing_enabled = parsing_enabled;
            this.parsing_enabledChanged = true;
            this.licenseKey = licenseKey;
            this.licenseKeyChanged = true;
            this.apply_password_policy = apply_password_policy;
            this.apply_password_policyChanged = true;
            this.uI_log_level = uI_log_level;
            this.uI_log_levelChanged = true;
            this.service_log_level = service_log_level;
            this.service_log_levelChanged = true;
            this.heart_beat_refresh_interval = heart_beat_refresh_interval;
            this.heart_beat_refresh_intervalChanged = true;
            this.smtp_username = smtp_username;
            this.smtp_usernameChanged = true;
            this.smtp_password = smtp_password;
            this.smtp_passwordChanged = true;
            this.smtp_server = smtp_server;
            this.smtp_serverChanged = true;
            this.smtp_port = smtp_port;
            this.smtp_portChanged = true;
            this.smtp_requires_authentication = smtp_requires_authentication;
            this.smtp_requires_authenticationChanged = true;
            this.downloaded_file_path = downloaded_file_path;
            this.downloaded_file_pathChanged = true;
            this.server_ip = server_ip;
            this.server_ipChanged = true;
            this.server_port = server_port;
            this.server_portChanged = true;
            this.archival_days = archival_days;
            this.archival_daysChanged = true;
            this.archival_server = archival_server;
            this.archival_serverChanged = true;
            this.archival_database = archival_database;
            this.archival_databaseChanged = true;
            this.archival_username = archival_username;
            this.archival_usernameChanged = true;
            this.archival_password = archival_password;
            this.archival_passwordChanged = true;
            this.dashboard_refresh_interval = dashboard_refresh_interval;
            this.dashboard_refresh_intervalChanged = true;
            this.cash_order_execution_time = cash_order_execution_time;
            this.cash_order_execution_timeChanged = true;
            this.threshold_for_alert = threshold_for_alert;
            this.threshold_for_alertChanged = true;
            this.threshold_for_ftp = threshold_for_ftp;
            this.threshold_for_ftpChanged = true;
            this.threshold_for_task = threshold_for_task;
            this.threshold_for_taskChanged = true;
            this.threshold_for_cashorder = threshold_for_cashorder;
            this.threshold_for_cashorderChanged = true;
            this.hold_other_df_tasks = hold_other_df_tasks;
            this.hold_other_df_tasksChanged = true;
            this.alert_expiration_time = alert_expiration_time;
            this.alert_expiration_timeChanged = true;
            this.is_ciphered_comm = is_ciphered_comm;
            this.is_ciphered_commChanged = true;
            this.vault_day_balance_execution_time = vault_day_balance_execution_time;
            this.vault_day_balance_execution_timeChanged = true;
            this.retry_count_cash_order_upload = retry_count_cash_order_upload;
            this.retry_count_cash_order_uploadChanged = true;
            this.retry_count_cash_order_download = retry_count_cash_order_download;
            this.retry_count_cash_order_downloadChanged = true;
            this.retry_count_dff_upload = retry_count_dff_upload;
            this.retry_count_dff_uploadChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.retry_count_counter_file = retry_count_counter_file;
            this.retry_count_counter_fileChanged = true;
            this.retry_count_restart_schedule = retry_count_restart_schedule;
            this.retry_count_restart_scheduleChanged = true;
            this.retry_count_datetime_schedule = retry_count_datetime_schedule;
            this.retry_count_datetime_scheduleChanged = true;
            this.cut_over_log_file_interval = cut_over_log_file_interval;
            this.cut_over_log_file_intervalChanged = true;
            this.retry_count_alert = retry_count_alert;
            this.retry_count_alertChanged = true;
            this.last_ej_summary_generated_at = last_ej_summary_generated_at;
            this.last_ej_summary_generated_atChanged = true;
            this.failed_to_parse_threshold = failed_to_parse_threshold;
            this.failed_to_parse_thresholdChanged = true;
            this.active_directory_domain = active_directory_domain;
            this.active_directory_domainChanged = true;
            this.is_suspected_rep_task_disabled = is_suspected_rep_task_disabled;
            this.is_suspected_rep_task_disabledChanged = true;
            this.rep_time_diff = rep_time_diff;
            this.rep_time_diffChanged = true;
            this.rep_start_time = rep_start_time;
            this.rep_start_timeChanged = true;
            this.rep_end_time = rep_end_time;
            this.rep_end_timeChanged = true;
            this.notes_difference = notes_difference;
            this.notes_differenceChanged = true;
            this.is_duplicate_checking_enabled = is_duplicate_checking_enabled;
            this.is_duplicate_checking_enabledChanged = true;
            this.allowed_no_of_days_for_mismatched_trxn_processing = allowed_no_of_days_for_mismatched_trxn_processing;
            this.allowed_no_of_days_for_mismatched_trxn_processingChanged = true;
            this.is_dff_halted = is_dff_halted;
            this.is_dff_haltedChanged = true;
            this.is_ledger_auto_created = is_ledger_auto_created;
            this.is_ledger_auto_createdChanged = true;
            this.initEjExecTime = initEjExecTime;
            this.initEjExecTimeChanged = true;
            this.server_port2 = server_port2;
            this.server_port2Changed = true;
            this.is_google_map_enabled = is_google_map_enabled;
            this.is_google_map_enabledChanged = true;
            this.ccms_parser_refresh_interval = ccms_parser_refresh_interval;
            this.ccms_parser_refresh_intervalChanged = true;
            this.cash_order_generation_time = cash_order_generation_time;
            this.cash_order_generation_timeChanged = true;
            this.currency_server_refresh_interval = currency_server_refresh_interval;
            this.currency_server_refresh_intervalChanged = true;
            this.currency_mng_password = currency_mng_password;
            this.currency_mng_passwordChanged = true;
            this.exchange_password = exchange_password;
            this.exchange_passwordChanged = true;
            this.exchange_pop_password = exchange_pop_password;
            this.exchange_pop_passwordChanged = true;
            this.ej_parser_zip_password = ej_parser_zip_password;
            this.ej_parser_zip_passwordChanged = true;
            this.ej_parser_ftp_Password = ej_parser_ftp_Password;
            this.ej_parser_ftp_PasswordChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
            this.sms_token = sms_token;
            this.sms_tokenChanged = true;
            this.sms_token_generated_at = sms_token_generated_at;
            this.sms_token_generated_atChanged = true;
            this.customer_transaction_amount_threshold_low = customer_transaction_amount_threshold_low;
            this.customer_transaction_amount_threshold_lowChanged = true;
            this.customer_transaction_amount_threshold_medium = customer_transaction_amount_threshold_medium;
            this.customer_transaction_amount_threshold_mediumChanged = true;
            this.serversInfo = serversInfo;
            this.serversInfoChanged = true;
            this.is_secured_access = is_secured_access;
            this.is_secured_accessChanged = true;
            this.daily_feed_ftp_uri = daily_feed_ftp_uri;
            this.daily_feed_ftp_uriChanged = true;
            this.daily_feed_ftp_username = daily_feed_ftp_username;
            this.daily_feed_ftp_usernameChanged = true;
            this.daily_feed_ftp_password = daily_feed_ftp_password;
            this.daily_feed_ftp_passwordChanged = true;
            this.daily_feed_generation_time = daily_feed_generation_time;
            this.daily_feed_generation_timeChanged = true;
            this.daily_feed_output_file_path = daily_feed_output_file_path;
            this.daily_feed_output_file_pathChanged = true;
            this.daily_feed_generation_delay = daily_feed_generation_delay;
            this.daily_feed_generation_delayChanged = true;
            this.coreDbName = coreDbName;
            this.coreDbNameChanged = true;
            this.cashDbName = cashDbName;
            this.cashDbNameChanged = true;
            this.txDbName = txDbName;
            this.txDbNameChanged = true;
            this.is_edited = is_edited;
            this.is_editedChanged = true;
            this.atm_data_streaming_heartbeat_port = atm_data_streaming_heartbeat_port;
            this.atm_data_streaming_heartbeat_portChanged = true;
            this.atm_data_streaming_port = atm_data_streaming_port;
            this.atm_data_streaming_portChanged = true;
            this.atm_on_demand_request_port = atm_on_demand_request_port;
            this.atm_on_demand_request_portChanged = true;
            this.atm_on_demand_request_hearbeat_port = atm_on_demand_request_hearbeat_port;
            this.atm_on_demand_request_hearbeat_portChanged = true;
        }
        private AppSetting(long app_setting_id, string cash_data_stores_location, int defalt_atm_port, int refresh_interval, string temporary_folder, string logFile_path, bool parsing_enabled, string licenseKey, bool apply_password_policy, string uI_log_level, string service_log_level, int heart_beat_refresh_interval, string smtp_username, string smtp_password, string smtp_server, short? smtp_port, bool? smtp_requires_authentication, string downloaded_file_path, string server_ip, int server_port, int? archival_days, string archival_server, string archival_database, string archival_username, string archival_password, int dashboard_refresh_interval, DateTime cash_order_execution_time, int? threshold_for_alert, int? threshold_for_ftp, int? threshold_for_task, int? threshold_for_cashorder, bool hold_other_df_tasks, int? alert_expiration_time, bool? is_ciphered_comm, DateTime? vault_day_balance_execution_time, int retry_count_cash_order_upload, int retry_count_cash_order_download, int retry_count_dff_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int cut_over_log_file_interval, int retry_count_alert, DateTime? last_ej_summary_generated_at, int? failed_to_parse_threshold, string active_directory_domain, bool? is_suspected_rep_task_disabled, string rep_time_diff, string rep_start_time, string rep_end_time, int? notes_difference, bool? is_duplicate_checking_enabled, int allowed_no_of_days_for_mismatched_trxn_processing, bool? is_dff_halted, bool is_ledger_auto_created, string initEjExecTime, int? server_port2, bool? is_google_map_enabled, int? ccms_parser_refresh_interval, DateTime? cash_order_generation_time, int? currency_server_refresh_interval, string currency_mng_password, string exchange_password, string exchange_pop_password, string ej_parser_zip_password, string ej_parser_ftp_Password, string bank_name, string sms_token, DateTime? sms_token_generated_at, int? customer_transaction_amount_threshold_low, int? customer_transaction_amount_threshold_medium, byte[] serversInfo, bool? is_secured_access, string daily_feed_ftp_uri, string daily_feed_ftp_username, string daily_feed_ftp_password, DateTime? daily_feed_generation_time, string daily_feed_output_file_path, int? daily_feed_generation_delay, string coreDbName, string cashDbName, string txDbName, bool? is_edited, int? atm_data_streaming_heartbeat_port, int? atm_data_streaming_port, int? atm_on_demand_request_port, int? atm_on_demand_request_hearbeat_port)
        {
            this.app_setting_id = app_setting_id;
            this.app_setting_idChanged = true;
            this.cash_data_stores_location = cash_data_stores_location;
            this.cash_data_stores_locationChanged = true;
            this.defalt_atm_port = defalt_atm_port;
            this.defalt_atm_portChanged = true;
            this.refresh_interval = refresh_interval;
            this.refresh_intervalChanged = true;
            this.temporary_folder = temporary_folder;
            this.temporary_folderChanged = true;
            this.logFile_path = logFile_path;
            this.logFile_pathChanged = true;
            this.parsing_enabled = parsing_enabled;
            this.parsing_enabledChanged = true;
            this.licenseKey = licenseKey;
            this.licenseKeyChanged = true;
            this.apply_password_policy = apply_password_policy;
            this.apply_password_policyChanged = true;
            this.uI_log_level = uI_log_level;
            this.uI_log_levelChanged = true;
            this.service_log_level = service_log_level;
            this.service_log_levelChanged = true;
            this.heart_beat_refresh_interval = heart_beat_refresh_interval;
            this.heart_beat_refresh_intervalChanged = true;
            this.smtp_username = smtp_username;
            this.smtp_usernameChanged = true;
            this.smtp_password = smtp_password;
            this.smtp_passwordChanged = true;
            this.smtp_server = smtp_server;
            this.smtp_serverChanged = true;
            this.smtp_port = smtp_port;
            this.smtp_portChanged = true;
            this.smtp_requires_authentication = smtp_requires_authentication;
            this.smtp_requires_authenticationChanged = true;
            this.downloaded_file_path = downloaded_file_path;
            this.downloaded_file_pathChanged = true;
            this.server_ip = server_ip;
            this.server_ipChanged = true;
            this.server_port = server_port;
            this.server_portChanged = true;
            this.archival_days = archival_days;
            this.archival_daysChanged = true;
            this.archival_server = archival_server;
            this.archival_serverChanged = true;
            this.archival_database = archival_database;
            this.archival_databaseChanged = true;
            this.archival_username = archival_username;
            this.archival_usernameChanged = true;
            this.archival_password = archival_password;
            this.archival_passwordChanged = true;
            this.dashboard_refresh_interval = dashboard_refresh_interval;
            this.dashboard_refresh_intervalChanged = true;
            this.cash_order_execution_time = cash_order_execution_time;
            this.cash_order_execution_timeChanged = true;
            this.threshold_for_alert = threshold_for_alert;
            this.threshold_for_alertChanged = true;
            this.threshold_for_ftp = threshold_for_ftp;
            this.threshold_for_ftpChanged = true;
            this.threshold_for_task = threshold_for_task;
            this.threshold_for_taskChanged = true;
            this.threshold_for_cashorder = threshold_for_cashorder;
            this.threshold_for_cashorderChanged = true;
            this.hold_other_df_tasks = hold_other_df_tasks;
            this.hold_other_df_tasksChanged = true;
            this.alert_expiration_time = alert_expiration_time;
            this.alert_expiration_timeChanged = true;
            this.is_ciphered_comm = is_ciphered_comm;
            this.is_ciphered_commChanged = true;
            this.vault_day_balance_execution_time = vault_day_balance_execution_time;
            this.vault_day_balance_execution_timeChanged = true;
            this.retry_count_cash_order_upload = retry_count_cash_order_upload;
            this.retry_count_cash_order_uploadChanged = true;
            this.retry_count_cash_order_download = retry_count_cash_order_download;
            this.retry_count_cash_order_downloadChanged = true;
            this.retry_count_dff_upload = retry_count_dff_upload;
            this.retry_count_dff_uploadChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.retry_count_counter_file = retry_count_counter_file;
            this.retry_count_counter_fileChanged = true;
            this.retry_count_restart_schedule = retry_count_restart_schedule;
            this.retry_count_restart_scheduleChanged = true;
            this.retry_count_datetime_schedule = retry_count_datetime_schedule;
            this.retry_count_datetime_scheduleChanged = true;
            this.cut_over_log_file_interval = cut_over_log_file_interval;
            this.cut_over_log_file_intervalChanged = true;
            this.retry_count_alert = retry_count_alert;
            this.retry_count_alertChanged = true;
            this.last_ej_summary_generated_at = last_ej_summary_generated_at;
            this.last_ej_summary_generated_atChanged = true;
            this.failed_to_parse_threshold = failed_to_parse_threshold;
            this.failed_to_parse_thresholdChanged = true;
            this.active_directory_domain = active_directory_domain;
            this.active_directory_domainChanged = true;
            this.is_suspected_rep_task_disabled = is_suspected_rep_task_disabled;
            this.is_suspected_rep_task_disabledChanged = true;
            this.rep_time_diff = rep_time_diff;
            this.rep_time_diffChanged = true;
            this.rep_start_time = rep_start_time;
            this.rep_start_timeChanged = true;
            this.rep_end_time = rep_end_time;
            this.rep_end_timeChanged = true;
            this.notes_difference = notes_difference;
            this.notes_differenceChanged = true;
            this.is_duplicate_checking_enabled = is_duplicate_checking_enabled;
            this.is_duplicate_checking_enabledChanged = true;
            this.allowed_no_of_days_for_mismatched_trxn_processing = allowed_no_of_days_for_mismatched_trxn_processing;
            this.allowed_no_of_days_for_mismatched_trxn_processingChanged = true;
            this.is_dff_halted = is_dff_halted;
            this.is_dff_haltedChanged = true;
            this.is_ledger_auto_created = is_ledger_auto_created;
            this.is_ledger_auto_createdChanged = true;
            this.initEjExecTime = initEjExecTime;
            this.initEjExecTimeChanged = true;
            this.server_port2 = server_port2;
            this.server_port2Changed = true;
            this.is_google_map_enabled = is_google_map_enabled;
            this.is_google_map_enabledChanged = true;
            this.ccms_parser_refresh_interval = ccms_parser_refresh_interval;
            this.ccms_parser_refresh_intervalChanged = true;
            this.cash_order_generation_time = cash_order_generation_time;
            this.cash_order_generation_timeChanged = true;
            this.currency_server_refresh_interval = currency_server_refresh_interval;
            this.currency_server_refresh_intervalChanged = true;
            this.currency_mng_password = currency_mng_password;
            this.currency_mng_passwordChanged = true;
            this.exchange_password = exchange_password;
            this.exchange_passwordChanged = true;
            this.exchange_pop_password = exchange_pop_password;
            this.exchange_pop_passwordChanged = true;
            this.ej_parser_zip_password = ej_parser_zip_password;
            this.ej_parser_zip_passwordChanged = true;
            this.ej_parser_ftp_Password = ej_parser_ftp_Password;
            this.ej_parser_ftp_PasswordChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
            this.sms_token = sms_token;
            this.sms_tokenChanged = true;
            this.sms_token_generated_at = sms_token_generated_at;
            this.sms_token_generated_atChanged = true;
            this.customer_transaction_amount_threshold_low = customer_transaction_amount_threshold_low;
            this.customer_transaction_amount_threshold_lowChanged = true;
            this.customer_transaction_amount_threshold_medium = customer_transaction_amount_threshold_medium;
            this.customer_transaction_amount_threshold_mediumChanged = true;
            this.serversInfo = serversInfo;
            this.serversInfoChanged = true;
            this.is_secured_access = is_secured_access;
            this.is_secured_accessChanged = true;
            this.daily_feed_ftp_uri = daily_feed_ftp_uri;
            this.daily_feed_ftp_uriChanged = true;
            this.daily_feed_ftp_username = daily_feed_ftp_username;
            this.daily_feed_ftp_usernameChanged = true;
            this.daily_feed_ftp_password = daily_feed_ftp_password;
            this.daily_feed_ftp_passwordChanged = true;
            this.daily_feed_generation_time = daily_feed_generation_time;
            this.daily_feed_generation_timeChanged = true;
            this.daily_feed_output_file_path = daily_feed_output_file_path;
            this.daily_feed_output_file_pathChanged = true;
            this.daily_feed_generation_delay = daily_feed_generation_delay;
            this.daily_feed_generation_delayChanged = true;
            this.coreDbName = coreDbName;
            this.coreDbNameChanged = true;
            this.cashDbName = cashDbName;
            this.cashDbNameChanged = true;
            this.txDbName = txDbName;
            this.txDbNameChanged = true;
            this.is_edited = is_edited;
            this.is_editedChanged = true;
            this.atm_data_streaming_heartbeat_port = atm_data_streaming_heartbeat_port;
            this.atm_data_streaming_heartbeat_portChanged = true;
            this.atm_data_streaming_port = atm_data_streaming_port;
            this.atm_data_streaming_portChanged = true;
            this.atm_on_demand_request_port = atm_on_demand_request_port;
            this.atm_on_demand_request_portChanged = true;
            this.atm_on_demand_request_hearbeat_port = atm_on_demand_request_hearbeat_port;
            this.atm_on_demand_request_hearbeat_portChanged = true;
        }

        #region members and properties for columns

        #region AppSettingId
        private bool app_setting_idChanged = false;
        private long app_setting_id;
        public long AppSettingId
        {
            get { return app_setting_id; }
            set
            {
                app_setting_id = value;
                app_setting_idChanged = true;
            }
        }
        private string app_setting_idDbString
        {
            get
            {
                return app_setting_id.ToString();
            }
        }
        #endregion
        #region CashDataStoresLocation
        private bool cash_data_stores_locationChanged = false;
        private string cash_data_stores_location;
        public string CashDataStoresLocation
        {
            get { return cash_data_stores_location; }
            set
            {
                cash_data_stores_location = value;
                cash_data_stores_locationChanged = true;
            }
        }
        private string cash_data_stores_locationDbString
        {
            get
            {
                if (this.cash_data_stores_location != null)
                    return string.Format("'{0}'", cash_data_stores_location);
                else
                    return "null";
            }
        }
        #endregion
        #region DefaltAtmPort
        private bool defalt_atm_portChanged = false;
        private int defalt_atm_port;
        public int DefaltAtmPort
        {
            get { return defalt_atm_port; }
            set
            {
                defalt_atm_port = value;
                defalt_atm_portChanged = true;
            }
        }
        private string defalt_atm_portDbString
        {
            get
            {
                return defalt_atm_port.ToString();
            }
        }
        #endregion
        #region RefreshInterval
        private bool refresh_intervalChanged = false;
        private int refresh_interval;
        public int RefreshInterval
        {
            get { return refresh_interval; }
            set
            {
                refresh_interval = value;
                refresh_intervalChanged = true;
            }
        }
        private string refresh_intervalDbString
        {
            get
            {
                return refresh_interval.ToString();
            }
        }
        #endregion
        #region TemporaryFolder
        private bool temporary_folderChanged = false;
        private string temporary_folder;
        public string TemporaryFolder
        {
            get { return temporary_folder; }
            set
            {
                temporary_folder = value;
                temporary_folderChanged = true;
            }
        }
        private string temporary_folderDbString
        {
            get
            {
                if (this.temporary_folder != null)
                    return string.Format("'{0}'", temporary_folder);
                else
                    return "null";
            }
        }
        #endregion
        #region LogFilePath
        private bool logFile_pathChanged = false;
        private string logFile_path;
        public string LogFilePath
        {
            get { return logFile_path; }
            set
            {
                logFile_path = value;
                logFile_pathChanged = true;
            }
        }
        private string logFile_pathDbString
        {
            get
            {
                if (this.logFile_path != null)
                    return string.Format("'{0}'", logFile_path);
                else
                    return "null";
            }
        }
        #endregion
        #region ParsingEnabled
        private bool parsing_enabledChanged = false;
        private bool parsing_enabled;
        public bool ParsingEnabled
        {
            get { return parsing_enabled; }
            set
            {
                parsing_enabled = value;
                parsing_enabledChanged = true;
            }
        }
        private string parsing_enabledDbString
        {
            get
            {
                return parsing_enabled ? "1" : "0";
            }
        }
        #endregion
        #region LicenseKey
        private bool licenseKeyChanged = false;
        private string licenseKey;
        public string LicenseKey
        {
            get { return licenseKey; }
            set
            {
                licenseKey = value;
                licenseKeyChanged = true;
            }
        }
        private string licenseKeyDbString
        {
            get
            {
                if (this.licenseKey != null)
                    return string.Format("'{0}'", licenseKey);
                else
                    return "null";
            }
        }
        #endregion
        #region ApplyPasswordPolicy
        private bool apply_password_policyChanged = false;
        private bool apply_password_policy;
        public bool ApplyPasswordPolicy
        {
            get { return apply_password_policy; }
            set
            {
                apply_password_policy = value;
                apply_password_policyChanged = true;
            }
        }
        private string apply_password_policyDbString
        {
            get
            {
                return apply_password_policy ? "1" : "0";
            }
        }
        #endregion
        #region UILogLevel
        private bool uI_log_levelChanged = false;
        private string uI_log_level;
        public string UILogLevel
        {
            get { return uI_log_level; }
            set
            {
                uI_log_level = value;
                uI_log_levelChanged = true;
            }
        }
        private string uI_log_levelDbString
        {
            get
            {
                if (this.uI_log_level != null)
                    return string.Format("'{0}'", uI_log_level);
                else
                    return "null";
            }
        }
        #endregion
        #region ServiceLogLevel
        private bool service_log_levelChanged = false;
        private string service_log_level;
        public string ServiceLogLevel
        {
            get { return service_log_level; }
            set
            {
                service_log_level = value;
                service_log_levelChanged = true;
            }
        }
        private string service_log_levelDbString
        {
            get
            {
                if (this.service_log_level != null)
                    return string.Format("'{0}'", service_log_level);
                else
                    return "null";
            }
        }
        #endregion
        #region HeartBeatRefreshInterval
        private bool heart_beat_refresh_intervalChanged = false;
        private int heart_beat_refresh_interval;
        public int HeartBeatRefreshInterval
        {
            get { return heart_beat_refresh_interval; }
            set
            {
                heart_beat_refresh_interval = value;
                heart_beat_refresh_intervalChanged = true;
            }
        }
        private string heart_beat_refresh_intervalDbString
        {
            get
            {
                return heart_beat_refresh_interval.ToString();
            }
        }
        #endregion
        #region SmtpUsername
        private bool smtp_usernameChanged = false;
        private string smtp_username;
        public string SmtpUsername
        {
            get { return smtp_username; }
            set
            {
                smtp_username = value;
                smtp_usernameChanged = true;
            }
        }
        private string smtp_usernameDbString
        {
            get
            {
                if (this.smtp_username != null)
                    return string.Format("'{0}'", smtp_username);
                else
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
            set
            {
                smtp_password = value;
                smtp_passwordChanged = true;
            }
        }
        private string smtp_passwordDbString
        {
            get
            {
                if (this.smtp_password != null)
                    return string.Format("'{0}'", smtp_password);
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
            set
            {
                smtp_server = value;
                smtp_serverChanged = true;
            }
        }
        private string smtp_serverDbString
        {
            get
            {
                if (this.smtp_server != null)
                    return string.Format("'{0}'", smtp_server);
                else
                    return "null";
            }
        }
        #endregion
        #region SmtpPort
        private bool smtp_portChanged = false;
        private short? smtp_port;
        public short? SmtpPort
        {
            get { return smtp_port; }
            set
            {
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
        #region SmtpRequiresAuthentication
        private bool smtp_requires_authenticationChanged = false;
        private bool? smtp_requires_authentication;
        public bool? SmtpRequiresAuthentication
        {
            get { return smtp_requires_authentication; }
            set
            {
                smtp_requires_authentication = value;
                smtp_requires_authenticationChanged = true;
            }
        }
        private string smtp_requires_authenticationDbString
        {
            get
            {
                if (this.smtp_requires_authentication.HasValue)
                    return smtp_requires_authentication.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region DownloadedFilePath
        private bool downloaded_file_pathChanged = false;
        private string downloaded_file_path;
        public string DownloadedFilePath
        {
            get { return downloaded_file_path; }
            set
            {
                downloaded_file_path = value;
                downloaded_file_pathChanged = true;
            }
        }
        private string downloaded_file_pathDbString
        {
            get
            {
                if (this.downloaded_file_path != null)
                    return string.Format("'{0}'", downloaded_file_path);
                else
                    return "null";
            }
        }
        #endregion
        #region ServerIp
        private bool server_ipChanged = false;
        private string server_ip;
        public string ServerIp
        {
            get { return server_ip; }
            set
            {
                server_ip = value;
                server_ipChanged = true;
            }
        }
        private string server_ipDbString
        {
            get
            {
                if (this.server_ip != null)
                    return string.Format("'{0}'", server_ip);
                else
                    return "null";
            }
        }
        #endregion
        #region ServerPort
        private bool server_portChanged = false;
        private int server_port;
        public int ServerPort
        {
            get { return server_port; }
            set
            {
                server_port = value;
                server_portChanged = true;
            }
        }
        private string server_portDbString
        {
            get
            {
                return server_port.ToString();
            }
        }
        #endregion
        #region ArchivalDays
        private bool archival_daysChanged = false;
        private int? archival_days;
        public int? ArchivalDays
        {
            get { return archival_days; }
            set
            {
                archival_days = value;
                archival_daysChanged = true;
            }
        }
        private string archival_daysDbString
        {
            get
            {
                if (this.archival_days.HasValue)
                    return archival_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ArchivalServer
        private bool archival_serverChanged = false;
        private string archival_server;
        public string ArchivalServer
        {
            get { return archival_server; }
            set
            {
                archival_server = value;
                archival_serverChanged = true;
            }
        }
        private string archival_serverDbString
        {
            get
            {
                if (this.archival_server != null)
                    return string.Format("'{0}'", archival_server);
                else
                    return "null";
            }
        }
        #endregion
        #region ArchivalDatabase
        private bool archival_databaseChanged = false;
        private string archival_database;
        public string ArchivalDatabase
        {
            get { return archival_database; }
            set
            {
                archival_database = value;
                archival_databaseChanged = true;
            }
        }
        private string archival_databaseDbString
        {
            get
            {
                if (this.archival_database != null)
                    return string.Format("'{0}'", archival_database);
                else
                    return "null";
            }
        }
        #endregion
        #region ArchivalUsername
        private bool archival_usernameChanged = false;
        private string archival_username;
        public string ArchivalUsername
        {
            get { return archival_username; }
            set
            {
                archival_username = value;
                archival_usernameChanged = true;
            }
        }
        private string archival_usernameDbString
        {
            get
            {
                if (this.archival_username != null)
                    return string.Format("'{0}'", archival_username);
                else
                    return "null";
            }
        }
        #endregion
        #region ArchivalPassword
        private bool archival_passwordChanged = false;
        private string archival_password;
        public string ArchivalPassword
        {
            get { return archival_password; }
            set
            {
                archival_password = value;
                archival_passwordChanged = true;
            }
        }
        private string archival_passwordDbString
        {
            get
            {
                if (this.archival_password != null)
                    return string.Format("'{0}'", archival_password);
                else
                    return "null";
            }
        }
        #endregion
        #region DashboardRefreshInterval
        private bool dashboard_refresh_intervalChanged = false;
        private int dashboard_refresh_interval;
        public int DashboardRefreshInterval
        {
            get { return dashboard_refresh_interval; }
            set
            {
                dashboard_refresh_interval = value;
                dashboard_refresh_intervalChanged = true;
            }
        }
        private string dashboard_refresh_intervalDbString
        {
            get
            {
                return dashboard_refresh_interval.ToString();
            }
        }
        #endregion
        #region CashOrderExecutionTime
        private bool cash_order_execution_timeChanged = false;
        private DateTime cash_order_execution_time;
        public DateTime CashOrderExecutionTime
        {
            get { return cash_order_execution_time; }
            set
            {
                cash_order_execution_time = value;
                cash_order_execution_timeChanged = true;
            }
        }
        private string cash_order_execution_timeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", cash_order_execution_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region ThresholdForAlert
        private bool threshold_for_alertChanged = false;
        private int? threshold_for_alert;
        public int? ThresholdForAlert
        {
            get { return threshold_for_alert; }
            set
            {
                threshold_for_alert = value;
                threshold_for_alertChanged = true;
            }
        }
        private string threshold_for_alertDbString
        {
            get
            {
                if (this.threshold_for_alert.HasValue)
                    return threshold_for_alert.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ThresholdForFtp
        private bool threshold_for_ftpChanged = false;
        private int? threshold_for_ftp;
        public int? ThresholdForFtp
        {
            get { return threshold_for_ftp; }
            set
            {
                threshold_for_ftp = value;
                threshold_for_ftpChanged = true;
            }
        }
        private string threshold_for_ftpDbString
        {
            get
            {
                if (this.threshold_for_ftp.HasValue)
                    return threshold_for_ftp.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ThresholdForTask
        private bool threshold_for_taskChanged = false;
        private int? threshold_for_task;
        public int? ThresholdForTask
        {
            get { return threshold_for_task; }
            set
            {
                threshold_for_task = value;
                threshold_for_taskChanged = true;
            }
        }
        private string threshold_for_taskDbString
        {
            get
            {
                if (this.threshold_for_task.HasValue)
                    return threshold_for_task.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ThresholdForCashorder
        private bool threshold_for_cashorderChanged = false;
        private int? threshold_for_cashorder;
        public int? ThresholdForCashorder
        {
            get { return threshold_for_cashorder; }
            set
            {
                threshold_for_cashorder = value;
                threshold_for_cashorderChanged = true;
            }
        }
        private string threshold_for_cashorderDbString
        {
            get
            {
                if (this.threshold_for_cashorder.HasValue)
                    return threshold_for_cashorder.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region HoldOtherDfTasks
        private bool hold_other_df_tasksChanged = false;
        private bool hold_other_df_tasks;
        public bool HoldOtherDfTasks
        {
            get { return hold_other_df_tasks; }
            set
            {
                hold_other_df_tasks = value;
                hold_other_df_tasksChanged = true;
            }
        }
        private string hold_other_df_tasksDbString
        {
            get
            {
                return hold_other_df_tasks ? "1" : "0";
            }
        }
        #endregion
        #region AlertExpirationTime
        private bool alert_expiration_timeChanged = false;
        private int? alert_expiration_time;
        public int? AlertExpirationTime
        {
            get { return alert_expiration_time; }
            set
            {
                alert_expiration_time = value;
                alert_expiration_timeChanged = true;
            }
        }
        private string alert_expiration_timeDbString
        {
            get
            {
                if (this.alert_expiration_time.HasValue)
                    return alert_expiration_time.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsCipheredComm
        private bool is_ciphered_commChanged = false;
        private bool? is_ciphered_comm;
        public bool? IsCipheredComm
        {
            get { return is_ciphered_comm; }
            set
            {
                is_ciphered_comm = value;
                is_ciphered_commChanged = true;
            }
        }
        private string is_ciphered_commDbString
        {
            get
            {
                if (this.is_ciphered_comm.HasValue)
                    return is_ciphered_comm.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region VaultDayBalanceExecutionTime
        private bool vault_day_balance_execution_timeChanged = false;
        private DateTime? vault_day_balance_execution_time;
        public DateTime? VaultDayBalanceExecutionTime
        {
            get { return vault_day_balance_execution_time; }
            set
            {
                vault_day_balance_execution_time = value;
                vault_day_balance_execution_timeChanged = true;
            }
        }
        private string vault_day_balance_execution_timeDbString
        {
            get
            {
                if (this.vault_day_balance_execution_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", vault_day_balance_execution_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region RetryCountCashOrderUpload
        private bool retry_count_cash_order_uploadChanged = false;
        private int retry_count_cash_order_upload;
        public int RetryCountCashOrderUpload
        {
            get { return retry_count_cash_order_upload; }
            set
            {
                retry_count_cash_order_upload = value;
                retry_count_cash_order_uploadChanged = true;
            }
        }
        private string retry_count_cash_order_uploadDbString
        {
            get
            {
                return retry_count_cash_order_upload.ToString();
            }
        }
        #endregion
        #region RetryCountCashOrderDownload
        private bool retry_count_cash_order_downloadChanged = false;
        private int retry_count_cash_order_download;
        public int RetryCountCashOrderDownload
        {
            get { return retry_count_cash_order_download; }
            set
            {
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
            set
            {
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
        #region RetryCountConfUpload
        private bool retry_count_conf_uploadChanged = false;
        private int retry_count_conf_upload;
        public int RetryCountConfUpload
        {
            get { return retry_count_conf_upload; }
            set
            {
                retry_count_conf_upload = value;
                retry_count_conf_uploadChanged = true;
            }
        }
        private string retry_count_conf_uploadDbString
        {
            get
            {
                return retry_count_conf_upload.ToString();
            }
        }
        #endregion
        #region RetryCountCounterFile
        private bool retry_count_counter_fileChanged = false;
        private int retry_count_counter_file;
        public int RetryCountCounterFile
        {
            get { return retry_count_counter_file; }
            set
            {
                retry_count_counter_file = value;
                retry_count_counter_fileChanged = true;
            }
        }
        private string retry_count_counter_fileDbString
        {
            get
            {
                return retry_count_counter_file.ToString();
            }
        }
        #endregion
        #region RetryCountRestartSchedule
        private bool retry_count_restart_scheduleChanged = false;
        private int retry_count_restart_schedule;
        public int RetryCountRestartSchedule
        {
            get { return retry_count_restart_schedule; }
            set
            {
                retry_count_restart_schedule = value;
                retry_count_restart_scheduleChanged = true;
            }
        }
        private string retry_count_restart_scheduleDbString
        {
            get
            {
                return retry_count_restart_schedule.ToString();
            }
        }
        #endregion
        #region RetryCountDatetimeSchedule
        private bool retry_count_datetime_scheduleChanged = false;
        private int retry_count_datetime_schedule;
        public int RetryCountDatetimeSchedule
        {
            get { return retry_count_datetime_schedule; }
            set
            {
                retry_count_datetime_schedule = value;
                retry_count_datetime_scheduleChanged = true;
            }
        }
        private string retry_count_datetime_scheduleDbString
        {
            get
            {
                return retry_count_datetime_schedule.ToString();
            }
        }
        #endregion
        #region CutOverLogFileInterval
        private bool cut_over_log_file_intervalChanged = false;
        private int cut_over_log_file_interval;
        public int CutOverLogFileInterval
        {
            get { return cut_over_log_file_interval; }
            set
            {
                cut_over_log_file_interval = value;
                cut_over_log_file_intervalChanged = true;
            }
        }
        private string cut_over_log_file_intervalDbString
        {
            get
            {
                return cut_over_log_file_interval.ToString();
            }
        }
        #endregion
        #region RetryCountAlert
        private bool retry_count_alertChanged = false;
        private int retry_count_alert;
        public int RetryCountAlert
        {
            get { return retry_count_alert; }
            set
            {
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
        #region LastEjSummaryGeneratedAt
        private bool last_ej_summary_generated_atChanged = false;
        private DateTime? last_ej_summary_generated_at;
        public DateTime? LastEjSummaryGeneratedAt
        {
            get { return last_ej_summary_generated_at; }
            set
            {
                last_ej_summary_generated_at = value;
                last_ej_summary_generated_atChanged = true;
            }
        }
        private string last_ej_summary_generated_atDbString
        {
            get
            {
                if (this.last_ej_summary_generated_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_ej_summary_generated_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region FailedToParseThreshold
        private bool failed_to_parse_thresholdChanged = false;
        private int? failed_to_parse_threshold;
        public int? FailedToParseThreshold
        {
            get { return failed_to_parse_threshold; }
            set
            {
                failed_to_parse_threshold = value;
                failed_to_parse_thresholdChanged = true;
            }
        }
        private string failed_to_parse_thresholdDbString
        {
            get
            {
                if (this.failed_to_parse_threshold.HasValue)
                    return failed_to_parse_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ActiveDirectoryDomain
        private bool active_directory_domainChanged = false;
        private string active_directory_domain;
        public string ActiveDirectoryDomain
        {
            get { return active_directory_domain; }
            set
            {
                active_directory_domain = value;
                active_directory_domainChanged = true;
            }
        }
        private string active_directory_domainDbString
        {
            get
            {
                if (this.active_directory_domain != null)
                    return string.Format("'{0}'", active_directory_domain);
                else
                    return "null";
            }
        }
        #endregion
        #region IsSuspectedRepTaskDisabled
        private bool is_suspected_rep_task_disabledChanged = false;
        private bool? is_suspected_rep_task_disabled;
        public bool? IsSuspectedRepTaskDisabled
        {
            get { return is_suspected_rep_task_disabled; }
            set
            {
                is_suspected_rep_task_disabled = value;
                is_suspected_rep_task_disabledChanged = true;
            }
        }
        private string is_suspected_rep_task_disabledDbString
        {
            get
            {
                if (this.is_suspected_rep_task_disabled.HasValue)
                    return is_suspected_rep_task_disabled.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region RepTimeDiff
        private bool rep_time_diffChanged = false;
        private string rep_time_diff;
        public string RepTimeDiff
        {
            get { return rep_time_diff; }
            set
            {
                rep_time_diff = value;
                rep_time_diffChanged = true;
            }
        }
        private string rep_time_diffDbString
        {
            get
            {
                if (this.rep_time_diff != null)
                    return string.Format("'{0}'", rep_time_diff);
                else
                    return "null";
            }
        }
        #endregion
        #region RepStartTime
        private bool rep_start_timeChanged = false;
        private string rep_start_time;
        public string RepStartTime
        {
            get { return rep_start_time; }
            set
            {
                rep_start_time = value;
                rep_start_timeChanged = true;
            }
        }
        private string rep_start_timeDbString
        {
            get
            {
                if (this.rep_start_time != null)
                    return string.Format("'{0}'", rep_start_time);
                else
                    return "null";
            }
        }
        #endregion
        #region RepEndTime
        private bool rep_end_timeChanged = false;
        private string rep_end_time;
        public string RepEndTime
        {
            get { return rep_end_time; }
            set
            {
                rep_end_time = value;
                rep_end_timeChanged = true;
            }
        }
        private string rep_end_timeDbString
        {
            get
            {
                if (this.rep_end_time != null)
                    return string.Format("'{0}'", rep_end_time);
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDifference
        private bool notes_differenceChanged = false;
        private int? notes_difference;
        public int? NotesDifference
        {
            get { return notes_difference; }
            set
            {
                notes_difference = value;
                notes_differenceChanged = true;
            }
        }
        private string notes_differenceDbString
        {
            get
            {
                if (this.notes_difference.HasValue)
                    return notes_difference.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsDuplicateCheckingEnabled
        private bool is_duplicate_checking_enabledChanged = false;
        private bool? is_duplicate_checking_enabled;
        public bool? IsDuplicateCheckingEnabled
        {
            get { return is_duplicate_checking_enabled; }
            set
            {
                is_duplicate_checking_enabled = value;
                is_duplicate_checking_enabledChanged = true;
            }
        }
        private string is_duplicate_checking_enabledDbString
        {
            get
            {
                if (this.is_duplicate_checking_enabled.HasValue)
                    return is_duplicate_checking_enabled.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region AllowedNoOfDaysForMismatchedTrxnProcessing
        private bool allowed_no_of_days_for_mismatched_trxn_processingChanged = false;
        private int allowed_no_of_days_for_mismatched_trxn_processing;
        public int AllowedNoOfDaysForMismatchedTrxnProcessing
        {
            get { return allowed_no_of_days_for_mismatched_trxn_processing; }
            set
            {
                allowed_no_of_days_for_mismatched_trxn_processing = value;
                allowed_no_of_days_for_mismatched_trxn_processingChanged = true;
            }
        }
        private string allowed_no_of_days_for_mismatched_trxn_processingDbString
        {
            get
            {
                return allowed_no_of_days_for_mismatched_trxn_processing.ToString();
            }
        }
        #endregion
        #region IsDffHalted
        private bool is_dff_haltedChanged = false;
        private bool? is_dff_halted;
        public bool? IsDffHalted
        {
            get { return is_dff_halted; }
            set
            {
                is_dff_halted = value;
                is_dff_haltedChanged = true;
            }
        }
        private string is_dff_haltedDbString
        {
            get
            {
                if (this.is_dff_halted.HasValue)
                    return is_dff_halted.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsLedgerAutoCreated
        private bool is_ledger_auto_createdChanged = false;
        private bool is_ledger_auto_created;
        public bool IsLedgerAutoCreated
        {
            get { return is_ledger_auto_created; }
            set
            {
                is_ledger_auto_created = value;
                is_ledger_auto_createdChanged = true;
            }
        }
        private string is_ledger_auto_createdDbString
        {
            get
            {
                return is_ledger_auto_created ? "1" : "0";
            }
        }
        #endregion
        #region InitEjExecTime
        private bool initEjExecTimeChanged = false;
        private string initEjExecTime;
        public string InitEjExecTime
        {
            get { return initEjExecTime; }
            set
            {
                initEjExecTime = value;
                initEjExecTimeChanged = true;
            }
        }
        private string initEjExecTimeDbString
        {
            get
            {
                if (this.initEjExecTime != null)
                    return string.Format("'{0}'", initEjExecTime);
                else
                    return "null";
            }
        }
        #endregion
        #region ServerPort2
        private bool server_port2Changed = false;
        private int? server_port2;
        public int? ServerPort2
        {
            get { return server_port2; }
            set
            {
                server_port2 = value;
                server_port2Changed = true;
            }
        }
        private string server_port2DbString
        {
            get
            {
                if (this.server_port2.HasValue)
                    return server_port2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsGoogleMapEnabled
        private bool is_google_map_enabledChanged = false;
        private bool? is_google_map_enabled;
        public bool? IsGoogleMapEnabled
        {
            get { return is_google_map_enabled; }
            set
            {
                is_google_map_enabled = value;
                is_google_map_enabledChanged = true;
            }
        }
        private string is_google_map_enabledDbString
        {
            get
            {
                if (this.is_google_map_enabled.HasValue)
                    return is_google_map_enabled.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region CcmsParserRefreshInterval
        private bool ccms_parser_refresh_intervalChanged = false;
        private int? ccms_parser_refresh_interval;
        public int? CcmsParserRefreshInterval
        {
            get { return ccms_parser_refresh_interval; }
            set
            {
                ccms_parser_refresh_interval = value;
                ccms_parser_refresh_intervalChanged = true;
            }
        }
        private string ccms_parser_refresh_intervalDbString
        {
            get
            {
                if (this.ccms_parser_refresh_interval.HasValue)
                    return ccms_parser_refresh_interval.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashOrderGenerationTime
        private bool cash_order_generation_timeChanged = false;
        private DateTime? cash_order_generation_time;
        public DateTime? CashOrderGenerationTime
        {
            get { return cash_order_generation_time; }
            set
            {
                cash_order_generation_time = value;
                cash_order_generation_timeChanged = true;
            }
        }
        private string cash_order_generation_timeDbString
        {
            get
            {
                if (this.cash_order_generation_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", cash_order_generation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CurrencyServerRefreshInterval
        private bool currency_server_refresh_intervalChanged = false;
        private int? currency_server_refresh_interval;
        public int? CurrencyServerRefreshInterval
        {
            get { return currency_server_refresh_interval; }
            set
            {
                currency_server_refresh_interval = value;
                currency_server_refresh_intervalChanged = true;
            }
        }
        private string currency_server_refresh_intervalDbString
        {
            get
            {
                if (this.currency_server_refresh_interval.HasValue)
                    return currency_server_refresh_interval.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CurrencyMngPassword
        private bool currency_mng_passwordChanged = false;
        private string currency_mng_password;
        public string CurrencyMngPassword
        {
            get { return currency_mng_password; }
            set
            {
                currency_mng_password = value;
                currency_mng_passwordChanged = true;
            }
        }
        private string currency_mng_passwordDbString
        {
            get
            {
                if (this.currency_mng_password != null)
                    return string.Format("'{0}'", currency_mng_password);
                else
                    return "null";
            }
        }
        #endregion
        #region ExchangePassword
        private bool exchange_passwordChanged = false;
        private string exchange_password;
        public string ExchangePassword
        {
            get { return exchange_password; }
            set
            {
                exchange_password = value;
                exchange_passwordChanged = true;
            }
        }
        private string exchange_passwordDbString
        {
            get
            {
                if (this.exchange_password != null)
                    return string.Format("'{0}'", exchange_password);
                else
                    return "null";
            }
        }
        #endregion
        #region ExchangePopPassword
        private bool exchange_pop_passwordChanged = false;
        private string exchange_pop_password;
        public string ExchangePopPassword
        {
            get { return exchange_pop_password; }
            set
            {
                exchange_pop_password = value;
                exchange_pop_passwordChanged = true;
            }
        }
        private string exchange_pop_passwordDbString
        {
            get
            {
                if (this.exchange_pop_password != null)
                    return string.Format("'{0}'", exchange_pop_password);
                else
                    return "null";
            }
        }
        #endregion
        #region EjParserZipPassword
        private bool ej_parser_zip_passwordChanged = false;
        private string ej_parser_zip_password;
        public string EjParserZipPassword
        {
            get { return ej_parser_zip_password; }
            set
            {
                ej_parser_zip_password = value;
                ej_parser_zip_passwordChanged = true;
            }
        }
        private string ej_parser_zip_passwordDbString
        {
            get
            {
                if (this.ej_parser_zip_password != null)
                    return string.Format("'{0}'", ej_parser_zip_password);
                else
                    return "null";
            }
        }
        #endregion
        #region EjParserFtpPassword
        private bool ej_parser_ftp_PasswordChanged = false;
        private string ej_parser_ftp_Password;
        public string EjParserFtpPassword
        {
            get { return ej_parser_ftp_Password; }
            set
            {
                ej_parser_ftp_Password = value;
                ej_parser_ftp_PasswordChanged = true;
            }
        }
        private string ej_parser_ftp_PasswordDbString
        {
            get
            {
                if (this.ej_parser_ftp_Password != null)
                    return string.Format("'{0}'", ej_parser_ftp_Password);
                else
                    return "null";
            }
        }
        #endregion
        #region BankName
        private bool bank_nameChanged = false;
        private string bank_name;
        public string BankName
        {
            get { return bank_name; }
            set
            {
                bank_name = value;
                bank_nameChanged = true;
            }
        }
        private string bank_nameDbString
        {
            get
            {
                if (this.bank_name != null)
                    return string.Format("'{0}'", bank_name);
                else
                    return "null";
            }
        }
        #endregion
        #region SmsToken
        private bool sms_tokenChanged = false;
        private string sms_token;
        public string SmsToken
        {
            get { return sms_token; }
            set
            {
                sms_token = value;
                sms_tokenChanged = true;
            }
        }
        private string sms_tokenDbString
        {
            get
            {
                if (this.sms_token != null)
                    return string.Format("'{0}'", sms_token);
                else
                    return "null";
            }
        }
        #endregion
        #region SmsTokenGeneratedAt
        private bool sms_token_generated_atChanged = false;
        private DateTime? sms_token_generated_at;
        public DateTime? SmsTokenGeneratedAt
        {
            get { return sms_token_generated_at; }
            set
            {
                sms_token_generated_at = value;
                sms_token_generated_atChanged = true;
            }
        }
        private string sms_token_generated_atDbString
        {
            get
            {
                if (this.sms_token_generated_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", sms_token_generated_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CustomerTransactionAmountThresholdLow
        private bool customer_transaction_amount_threshold_lowChanged = false;
        private int? customer_transaction_amount_threshold_low;
        public int? CustomerTransactionAmountThresholdLow
        {
            get { return customer_transaction_amount_threshold_low; }
            set
            {
                customer_transaction_amount_threshold_low = value;
                customer_transaction_amount_threshold_lowChanged = true;
            }
        }
        private string customer_transaction_amount_threshold_lowDbString
        {
            get
            {
                if (this.customer_transaction_amount_threshold_low.HasValue)
                    return customer_transaction_amount_threshold_low.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CustomerTransactionAmountThresholdMedium
        private bool customer_transaction_amount_threshold_mediumChanged = false;
        private int? customer_transaction_amount_threshold_medium;
        public int? CustomerTransactionAmountThresholdMedium
        {
            get { return customer_transaction_amount_threshold_medium; }
            set
            {
                customer_transaction_amount_threshold_medium = value;
                customer_transaction_amount_threshold_mediumChanged = true;
            }
        }
        private string customer_transaction_amount_threshold_mediumDbString
        {
            get
            {
                if (this.customer_transaction_amount_threshold_medium.HasValue)
                    return customer_transaction_amount_threshold_medium.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ServersInfo
        private bool serversInfoChanged = false;
        private byte[] serversInfo;
        public byte[] ServersInfo
        {
            get { return serversInfo; }
            set
            {
                serversInfo = value;
                serversInfoChanged = true;
            }
        }
        private string serversInfoDbString
        {
            get
            {
                if (this.serversInfo != null)
                    return "@serversInfo";
                else
                    return "null";
            }
        }
        #endregion
        #region IsSecuredAccess
        private bool is_secured_accessChanged = false;
        private bool? is_secured_access;
        public bool? IsSecuredAccess
        {
            get { return is_secured_access; }
            set
            {
                is_secured_access = value;
                is_secured_accessChanged = true;
            }
        }
        private string is_secured_accessDbString
        {
            get
            {
                if (this.is_secured_access.HasValue)
                    return is_secured_access.Value ? "1" : "0";
                else
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
            set
            {
                daily_feed_ftp_uri = value;
                daily_feed_ftp_uriChanged = true;
            }
        }
        private string daily_feed_ftp_uriDbString
        {
            get
            {
                if (this.daily_feed_ftp_uri != null)
                    return string.Format("'{0}'", daily_feed_ftp_uri);
                else
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
            set
            {
                daily_feed_ftp_username = value;
                daily_feed_ftp_usernameChanged = true;
            }
        }
        private string daily_feed_ftp_usernameDbString
        {
            get
            {
                if (this.daily_feed_ftp_username != null)
                    return string.Format("'{0}'", daily_feed_ftp_username);
                else
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
            set
            {
                daily_feed_ftp_password = value;
                daily_feed_ftp_passwordChanged = true;
            }
        }
        private string daily_feed_ftp_passwordDbString
        {
            get
            {
                if (this.daily_feed_ftp_password != null)
                    return string.Format("'{0}'", daily_feed_ftp_password);
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
            set
            {
                daily_feed_generation_time = value;
                daily_feed_generation_timeChanged = true;
            }
        }
        private string daily_feed_generation_timeDbString
        {
            get
            {
                if (this.daily_feed_generation_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", daily_feed_generation_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
            set
            {
                daily_feed_output_file_path = value;
                daily_feed_output_file_pathChanged = true;
            }
        }
        private string daily_feed_output_file_pathDbString
        {
            get
            {
                if (this.daily_feed_output_file_path != null)
                    return string.Format("'{0}'", daily_feed_output_file_path);
                else
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
            set
            {
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
        #region CoreDbName
        private bool coreDbNameChanged = false;
        private string coreDbName;
        public string CoreDbName
        {
            get { return coreDbName; }
            set
            {
                coreDbName = value;
                coreDbNameChanged = true;
            }
        }
        private string coreDbNameDbString
        {
            get
            {
                if (this.coreDbName != null)
                    return string.Format("'{0}'", coreDbName);
                else
                    return "null";
            }
        }
        #endregion
        #region CashDbName
        private bool cashDbNameChanged = false;
        private string cashDbName;
        public string CashDbName
        {
            get { return cashDbName; }
            set
            {
                cashDbName = value;
                cashDbNameChanged = true;
            }
        }
        private string cashDbNameDbString
        {
            get
            {
                if (this.cashDbName != null)
                    return string.Format("'{0}'", cashDbName);
                else
                    return "null";
            }
        }
        #endregion
        #region TxDbName
        private bool txDbNameChanged = false;
        private string txDbName;
        public string TxDbName
        {
            get { return txDbName; }
            set
            {
                txDbName = value;
                txDbNameChanged = true;
            }
        }
        private string txDbNameDbString
        {
            get
            {
                if (this.txDbName != null)
                    return string.Format("'{0}'", txDbName);
                else
                    return "null";
            }
        }
        #endregion
        #region IsEdited
        private bool is_editedChanged = false;
        private bool? is_edited;
        public bool? IsEdited
        {
            get { return is_edited; }
            set
            {
                is_edited = value;
                is_editedChanged = true;
            }
        }
        private string is_editedDbString
        {
            get
            {
                if (this.is_edited.HasValue)
                    return is_edited.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region AtmDataStreamingHeartbeatPort
        private bool atm_data_streaming_heartbeat_portChanged = false;
        private int? atm_data_streaming_heartbeat_port;
        public int? AtmDataStreamingHeartbeatPort
        {
            get { return atm_data_streaming_heartbeat_port; }
            set
            {
                atm_data_streaming_heartbeat_port = value;
                atm_data_streaming_heartbeat_portChanged = true;
            }
        }
        private string atm_data_streaming_heartbeat_portDbString
        {
            get
            {
                if (this.atm_data_streaming_heartbeat_port.HasValue)
                    return atm_data_streaming_heartbeat_port.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AtmDataStreamingPort
        private bool atm_data_streaming_portChanged = false;
        private int? atm_data_streaming_port;
        public int? AtmDataStreamingPort
        {
            get { return atm_data_streaming_port; }
            set
            {
                atm_data_streaming_port = value;
                atm_data_streaming_portChanged = true;
            }
        }
        private string atm_data_streaming_portDbString
        {
            get
            {
                if (this.atm_data_streaming_port.HasValue)
                    return atm_data_streaming_port.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AtmOnDemandRequestPort
        private bool atm_on_demand_request_portChanged = false;
        private int? atm_on_demand_request_port;
        public int? AtmOnDemandRequestPort
        {
            get { return atm_on_demand_request_port; }
            set
            {
                atm_on_demand_request_port = value;
                atm_on_demand_request_portChanged = true;
            }
        }
        private string atm_on_demand_request_portDbString
        {
            get
            {
                if (this.atm_on_demand_request_port.HasValue)
                    return atm_on_demand_request_port.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AtmOnDemandRequestHearbeatPort
        private bool atm_on_demand_request_hearbeat_portChanged = false;
        private int? atm_on_demand_request_hearbeat_port;
        public int? AtmOnDemandRequestHearbeatPort
        {
            get { return atm_on_demand_request_hearbeat_port; }
            set
            {
                atm_on_demand_request_hearbeat_port = value;
                atm_on_demand_request_hearbeat_portChanged = true;
            }
        }
        private string atm_on_demand_request_hearbeat_portDbString
        {
            get
            {
                if (this.atm_on_demand_request_hearbeat_port.HasValue)
                    return atm_on_demand_request_hearbeat_port.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region AppSettingReader
        public class AppSettingReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            AppSetting currentAppSetting;
            Columns columns;
            bool partialRead = false;
            private AppSettingReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AppSettingReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AppSettingReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAppSetting; }

            }
            public void Close()
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
                    currentAppSetting = new AppSetting();
                    {
                        if (reader["app_setting_id"] != DBNull.Value)
                            currentAppSetting.app_setting_id = (long)reader["app_setting_id"];
                        if (reader["cash_data_stores_location"] != DBNull.Value)
                            currentAppSetting.cash_data_stores_location = (string)reader["cash_data_stores_location"];
                        if (reader["defalt_atm_port"] != DBNull.Value)
                            currentAppSetting.defalt_atm_port = (int)reader["defalt_atm_port"];
                        if (reader["refresh_interval"] != DBNull.Value)
                            currentAppSetting.refresh_interval = (int)reader["refresh_interval"];
                        if (reader["temporary_folder"] != DBNull.Value)
                            currentAppSetting.temporary_folder = (string)reader["temporary_folder"];
                        if (reader["logFile_path"] != DBNull.Value)
                            currentAppSetting.logFile_path = (string)reader["logFile_path"];
                        if (reader["parsing_enabled"] != DBNull.Value)
                            currentAppSetting.parsing_enabled = (bool)reader["parsing_enabled"];
                        if (reader["LicenseKey"] != DBNull.Value)
                            currentAppSetting.licenseKey = (string)reader["LicenseKey"];
                        if (reader["apply_password_policy"] != DBNull.Value)
                            currentAppSetting.apply_password_policy = (bool)reader["apply_password_policy"];
                        if (reader["UI_log_level"] != DBNull.Value)
                            currentAppSetting.uI_log_level = (string)reader["UI_log_level"];
                        if (reader["service_log_level"] != DBNull.Value)
                            currentAppSetting.service_log_level = (string)reader["service_log_level"];
                        if (reader["heart_beat_refresh_interval"] != DBNull.Value)
                            currentAppSetting.heart_beat_refresh_interval = (int)reader["heart_beat_refresh_interval"];
                        if (reader["smtp_username"] != DBNull.Value)
                            currentAppSetting.smtp_username = (string)reader["smtp_username"];
                        if (reader["smtp_password"] != DBNull.Value)
                            currentAppSetting.smtp_password = (string)reader["smtp_password"];
                        if (reader["smtp_server"] != DBNull.Value)
                            currentAppSetting.smtp_server = (string)reader["smtp_server"];
                        if (reader["smtp_port"] != DBNull.Value)
                            currentAppSetting.smtp_port = (short?)reader["smtp_port"];
                        if (reader["smtp_requires_authentication"] != DBNull.Value)
                            currentAppSetting.smtp_requires_authentication = (bool?)reader["smtp_requires_authentication"];
                        if (reader["downloaded_file_path"] != DBNull.Value)
                            currentAppSetting.downloaded_file_path = (string)reader["downloaded_file_path"];
                        if (reader["server_ip"] != DBNull.Value)
                            currentAppSetting.server_ip = (string)reader["server_ip"];
                        if (reader["server_port"] != DBNull.Value)
                            currentAppSetting.server_port = (int)reader["server_port"];
                        if (reader["archival_days"] != DBNull.Value)
                            currentAppSetting.archival_days = (int?)reader["archival_days"];
                        if (reader["archival_server"] != DBNull.Value)
                            currentAppSetting.archival_server = (string)reader["archival_server"];
                        if (reader["archival_database"] != DBNull.Value)
                            currentAppSetting.archival_database = (string)reader["archival_database"];
                        if (reader["archival_username"] != DBNull.Value)
                            currentAppSetting.archival_username = (string)reader["archival_username"];
                        if (reader["archival_password"] != DBNull.Value)
                            currentAppSetting.archival_password = (string)reader["archival_password"];
                        if (reader["dashboard_refresh_interval"] != DBNull.Value)
                            currentAppSetting.dashboard_refresh_interval = (int)reader["dashboard_refresh_interval"];
                        if (reader["cash_order_execution_time"] != DBNull.Value)
                            currentAppSetting.cash_order_execution_time = (DateTime)reader["cash_order_execution_time"];
                        if (reader["threshold_for_alert"] != DBNull.Value)
                            currentAppSetting.threshold_for_alert = (int?)reader["threshold_for_alert"];
                        if (reader["threshold_for_ftp"] != DBNull.Value)
                            currentAppSetting.threshold_for_ftp = (int?)reader["threshold_for_ftp"];
                        if (reader["threshold_for_task"] != DBNull.Value)
                            currentAppSetting.threshold_for_task = (int?)reader["threshold_for_task"];
                        if (reader["threshold_for_cashorder"] != DBNull.Value)
                            currentAppSetting.threshold_for_cashorder = (int?)reader["threshold_for_cashorder"];
                        if (reader["hold_other_df_tasks"] != DBNull.Value)
                            currentAppSetting.hold_other_df_tasks = (bool)reader["hold_other_df_tasks"];
                        if (reader["alert_expiration_time"] != DBNull.Value)
                            currentAppSetting.alert_expiration_time = (int?)reader["alert_expiration_time"];
                        if (reader["is_ciphered_comm"] != DBNull.Value)
                            currentAppSetting.is_ciphered_comm = (bool?)reader["is_ciphered_comm"];
                        if (reader["vault_day_balance_execution_time"] != DBNull.Value)
                            currentAppSetting.vault_day_balance_execution_time = (DateTime?)reader["vault_day_balance_execution_time"];
                        if (reader["retry_count_cash_order_upload"] != DBNull.Value)
                            currentAppSetting.retry_count_cash_order_upload = (int)reader["retry_count_cash_order_upload"];
                        if (reader["retry_count_cash_order_download"] != DBNull.Value)
                            currentAppSetting.retry_count_cash_order_download = (int)reader["retry_count_cash_order_download"];
                        if (reader["retry_count_dff_upload"] != DBNull.Value)
                            currentAppSetting.retry_count_dff_upload = (int)reader["retry_count_dff_upload"];
                        if (reader["retry_count_conf_upload"] != DBNull.Value)
                            currentAppSetting.retry_count_conf_upload = (int)reader["retry_count_conf_upload"];
                        if (reader["retry_count_counter_file"] != DBNull.Value)
                            currentAppSetting.retry_count_counter_file = (int)reader["retry_count_counter_file"];
                        if (reader["retry_count_restart_schedule"] != DBNull.Value)
                            currentAppSetting.retry_count_restart_schedule = (int)reader["retry_count_restart_schedule"];
                        if (reader["retry_count_datetime_schedule"] != DBNull.Value)
                            currentAppSetting.retry_count_datetime_schedule = (int)reader["retry_count_datetime_schedule"];
                        if (reader["cut_over_log_file_interval"] != DBNull.Value)
                            currentAppSetting.cut_over_log_file_interval = (int)reader["cut_over_log_file_interval"];
                        if (reader["retry_count_alert"] != DBNull.Value)
                            currentAppSetting.retry_count_alert = (int)reader["retry_count_alert"];
                        if (reader["last_ej_summary_generated_at"] != DBNull.Value)
                            currentAppSetting.last_ej_summary_generated_at = (DateTime?)reader["last_ej_summary_generated_at"];
                        if (reader["failed_to_parse_threshold"] != DBNull.Value)
                            currentAppSetting.failed_to_parse_threshold = (int?)reader["failed_to_parse_threshold"];
                        if (reader["active_directory_domain"] != DBNull.Value)
                            currentAppSetting.active_directory_domain = (string)reader["active_directory_domain"];
                        if (reader["is_suspected_rep_task_disabled"] != DBNull.Value)
                            currentAppSetting.is_suspected_rep_task_disabled = (bool?)reader["is_suspected_rep_task_disabled"];
                        if (reader["rep_time_diff"] != DBNull.Value)
                            currentAppSetting.rep_time_diff = (string)reader["rep_time_diff"];
                        if (reader["rep_start_time"] != DBNull.Value)
                            currentAppSetting.rep_start_time = (string)reader["rep_start_time"];
                        if (reader["rep_end_time"] != DBNull.Value)
                            currentAppSetting.rep_end_time = (string)reader["rep_end_time"];
                        if (reader["notes_difference"] != DBNull.Value)
                            currentAppSetting.notes_difference = (int?)reader["notes_difference"];
                        if (reader["is_duplicate_checking_enabled"] != DBNull.Value)
                            currentAppSetting.is_duplicate_checking_enabled = (bool?)reader["is_duplicate_checking_enabled"];
                        if (reader["allowed_no_of_days_for_mismatched_trxn_processing"] != DBNull.Value)
                            currentAppSetting.allowed_no_of_days_for_mismatched_trxn_processing = (int)reader["allowed_no_of_days_for_mismatched_trxn_processing"];
                        if (reader["is_dff_halted"] != DBNull.Value)
                            currentAppSetting.is_dff_halted = (bool?)reader["is_dff_halted"];
                        if (reader["is_ledger_auto_created"] != DBNull.Value)
                            currentAppSetting.is_ledger_auto_created = (bool)reader["is_ledger_auto_created"];
                        if (reader["initEjExecTime"] != DBNull.Value)
                            currentAppSetting.initEjExecTime = (string)reader["initEjExecTime"];
                        if (reader["server_port2"] != DBNull.Value)
                            currentAppSetting.server_port2 = (int?)reader["server_port2"];
                        if (reader["is_google_map_enabled"] != DBNull.Value)
                            currentAppSetting.is_google_map_enabled = (bool?)reader["is_google_map_enabled"];
                        if (reader["ccms_parser_refresh_interval"] != DBNull.Value)
                            currentAppSetting.ccms_parser_refresh_interval = (int?)reader["ccms_parser_refresh_interval"];
                        if (reader["cash_order_generation_time"] != DBNull.Value)
                            currentAppSetting.cash_order_generation_time = (DateTime?)reader["cash_order_generation_time"];
                        if (reader["currency_server_refresh_interval"] != DBNull.Value)
                            currentAppSetting.currency_server_refresh_interval = (int?)reader["currency_server_refresh_interval"];
                        if (reader["currency_mng_password"] != DBNull.Value)
                            currentAppSetting.currency_mng_password = (string)reader["currency_mng_password"];
                        if (reader["exchange_password"] != DBNull.Value)
                            currentAppSetting.exchange_password = (string)reader["exchange_password"];
                        if (reader["exchange_pop_password"] != DBNull.Value)
                            currentAppSetting.exchange_pop_password = (string)reader["exchange_pop_password"];
                        if (reader["ej_parser_zip_password"] != DBNull.Value)
                            currentAppSetting.ej_parser_zip_password = (string)reader["ej_parser_zip_password"];
                        if (reader["ej_parser_ftp_Password"] != DBNull.Value)
                            currentAppSetting.ej_parser_ftp_Password = (string)reader["ej_parser_ftp_Password"];
                        if (reader["bank_name"] != DBNull.Value)
                            currentAppSetting.bank_name = (string)reader["bank_name"];
                        if (reader["sms_token"] != DBNull.Value)
                            currentAppSetting.sms_token = (string)reader["sms_token"];
                        if (reader["sms_token_generated_at"] != DBNull.Value)
                            currentAppSetting.sms_token_generated_at = (DateTime?)reader["sms_token_generated_at"];
                        if (reader["customer_transaction_amount_threshold_low"] != DBNull.Value)
                            currentAppSetting.customer_transaction_amount_threshold_low = (int?)reader["customer_transaction_amount_threshold_low"];
                        if (reader["customer_transaction_amount_threshold_medium"] != DBNull.Value)
                            currentAppSetting.customer_transaction_amount_threshold_medium = (int?)reader["customer_transaction_amount_threshold_medium"];
                        if (reader["ServersInfo"] != DBNull.Value)
                            currentAppSetting.serversInfo = (byte[])reader["ServersInfo"];
                        if (reader["is_secured_access"] != DBNull.Value)
                            currentAppSetting.is_secured_access = (bool?)reader["is_secured_access"];
                        if (reader["daily_feed_ftp_uri"] != DBNull.Value)
                            currentAppSetting.daily_feed_ftp_uri = (string)reader["daily_feed_ftp_uri"];
                        if (reader["daily_feed_ftp_username"] != DBNull.Value)
                            currentAppSetting.daily_feed_ftp_username = (string)reader["daily_feed_ftp_username"];
                        if (reader["daily_feed_ftp_password"] != DBNull.Value)
                            currentAppSetting.daily_feed_ftp_password = (string)reader["daily_feed_ftp_password"];
                        if (reader["daily_feed_generation_time"] != DBNull.Value)
                            currentAppSetting.daily_feed_generation_time = (DateTime?)reader["daily_feed_generation_time"];
                        if (reader["daily_feed_output_file_path"] != DBNull.Value)
                            currentAppSetting.daily_feed_output_file_path = (string)reader["daily_feed_output_file_path"];
                        if (reader["daily_feed_generation_delay"] != DBNull.Value)
                            currentAppSetting.daily_feed_generation_delay = (int?)reader["daily_feed_generation_delay"];
                        if (reader["CoreDbName"] != DBNull.Value)
                            currentAppSetting.coreDbName = (string)reader["CoreDbName"];
                        if (reader["CashDbName"] != DBNull.Value)
                            currentAppSetting.cashDbName = (string)reader["CashDbName"];
                        if (reader["TxDbName"] != DBNull.Value)
                            currentAppSetting.txDbName = (string)reader["TxDbName"];
                        if (reader["is_edited"] != DBNull.Value)
                            currentAppSetting.is_edited = (bool?)reader["is_edited"];
                        if (reader["atm_data_streaming_heartbeat_port"] != DBNull.Value)
                            currentAppSetting.atm_data_streaming_heartbeat_port = (int?)reader["atm_data_streaming_heartbeat_port"];
                        if (reader["atm_data_streaming_port"] != DBNull.Value)
                            currentAppSetting.atm_data_streaming_port = (int?)reader["atm_data_streaming_port"];
                        if (reader["atm_on_demand_request_port"] != DBNull.Value)
                            currentAppSetting.atm_on_demand_request_port = (int?)reader["atm_on_demand_request_port"];
                        if (reader["atm_on_demand_request_hearbeat_port"] != DBNull.Value)
                            currentAppSetting.atm_on_demand_request_hearbeat_port = (int?)reader["atm_on_demand_request_hearbeat_port"];
                    }

                    currentAppSetting.isNewEntity = false;
                    return true;
                }
                else
                    return false;
            }
            #region IEnumerable Members

            public IEnumerator GetEnumerator()
            {
                return this;
            }
            #endregion


            #region IEnumerator Members

            public AppSetting CurrentAppSetting
            {
                get { return currentAppSetting; }
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


        #region AppSetting functions

        public static AppSettingReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.app_setting_id == (Columns.app_setting_id & columns))
                qry.Append("app_setting_id,");
            if (Columns.cash_data_stores_location == (Columns.cash_data_stores_location & columns))
                qry.Append("cash_data_stores_location,");
            if (Columns.defalt_atm_port == (Columns.defalt_atm_port & columns))
                qry.Append("defalt_atm_port,");
            if (Columns.refresh_interval == (Columns.refresh_interval & columns))
                qry.Append("refresh_interval,");
            if (Columns.temporary_folder == (Columns.temporary_folder & columns))
                qry.Append("temporary_folder,");
            if (Columns.logFile_path == (Columns.logFile_path & columns))
                qry.Append("logFile_path,");
            if (Columns.parsing_enabled == (Columns.parsing_enabled & columns))
                qry.Append("parsing_enabled,");
            if (Columns.LicenseKey == (Columns.LicenseKey & columns))
                qry.Append("LicenseKey,");
            if (Columns.apply_password_policy == (Columns.apply_password_policy & columns))
                qry.Append("apply_password_policy,");
            if (Columns.UI_log_level == (Columns.UI_log_level & columns))
                qry.Append("UI_log_level,");
            if (Columns.service_log_level == (Columns.service_log_level & columns))
                qry.Append("service_log_level,");
            if (Columns.heart_beat_refresh_interval == (Columns.heart_beat_refresh_interval & columns))
                qry.Append("heart_beat_refresh_interval,");
            if (Columns.smtp_username == (Columns.smtp_username & columns))
                qry.Append("smtp_username,");
            if (Columns.smtp_password == (Columns.smtp_password & columns))
                qry.Append("smtp_password,");
            if (Columns.smtp_server == (Columns.smtp_server & columns))
                qry.Append("smtp_server,");
            if (Columns.smtp_port == (Columns.smtp_port & columns))
                qry.Append("smtp_port,");
            if (Columns.smtp_requires_authentication == (Columns.smtp_requires_authentication & columns))
                qry.Append("smtp_requires_authentication,");
            if (Columns.downloaded_file_path == (Columns.downloaded_file_path & columns))
                qry.Append("downloaded_file_path,");
            if (Columns.server_ip == (Columns.server_ip & columns))
                qry.Append("server_ip,");
            if (Columns.server_port == (Columns.server_port & columns))
                qry.Append("server_port,");
            if (Columns.archival_days == (Columns.archival_days & columns))
                qry.Append("archival_days,");
            if (Columns.archival_server == (Columns.archival_server & columns))
                qry.Append("archival_server,");
            if (Columns.archival_database == (Columns.archival_database & columns))
                qry.Append("archival_database,");
            if (Columns.archival_username == (Columns.archival_username & columns))
                qry.Append("archival_username,");
            if (Columns.archival_password == (Columns.archival_password & columns))
                qry.Append("archival_password,");
            if (Columns.dashboard_refresh_interval == (Columns.dashboard_refresh_interval & columns))
                qry.Append("dashboard_refresh_interval,");
            if (Columns.cash_order_execution_time == (Columns.cash_order_execution_time & columns))
                qry.Append("cash_order_execution_time,");
            if (Columns.threshold_for_alert == (Columns.threshold_for_alert & columns))
                qry.Append("threshold_for_alert,");
            if (Columns.threshold_for_ftp == (Columns.threshold_for_ftp & columns))
                qry.Append("threshold_for_ftp,");
            if (Columns.threshold_for_task == (Columns.threshold_for_task & columns))
                qry.Append("threshold_for_task,");
            if (Columns.threshold_for_cashorder == (Columns.threshold_for_cashorder & columns))
                qry.Append("threshold_for_cashorder,");
            if (Columns.hold_other_df_tasks == (Columns.hold_other_df_tasks & columns))
                qry.Append("hold_other_df_tasks,");
            if (Columns.alert_expiration_time == (Columns.alert_expiration_time & columns))
                qry.Append("alert_expiration_time,");
            if (Columns.is_ciphered_comm == (Columns.is_ciphered_comm & columns))
                qry.Append("is_ciphered_comm,");
            if (Columns.vault_day_balance_execution_time == (Columns.vault_day_balance_execution_time & columns))
                qry.Append("vault_day_balance_execution_time,");
            if (Columns.retry_count_cash_order_upload == (Columns.retry_count_cash_order_upload & columns))
                qry.Append("retry_count_cash_order_upload,");
            if (Columns.retry_count_cash_order_download == (Columns.retry_count_cash_order_download & columns))
                qry.Append("retry_count_cash_order_download,");
            if (Columns.retry_count_dff_upload == (Columns.retry_count_dff_upload & columns))
                qry.Append("retry_count_dff_upload,");
            if (Columns.retry_count_conf_upload == (Columns.retry_count_conf_upload & columns))
                qry.Append("retry_count_conf_upload,");
            if (Columns.retry_count_counter_file == (Columns.retry_count_counter_file & columns))
                qry.Append("retry_count_counter_file,");
            if (Columns.retry_count_restart_schedule == (Columns.retry_count_restart_schedule & columns))
                qry.Append("retry_count_restart_schedule,");
            if (Columns.retry_count_datetime_schedule == (Columns.retry_count_datetime_schedule & columns))
                qry.Append("retry_count_datetime_schedule,");
            if (Columns.cut_over_log_file_interval == (Columns.cut_over_log_file_interval & columns))
                qry.Append("cut_over_log_file_interval,");
            if (Columns.retry_count_alert == (Columns.retry_count_alert & columns))
                qry.Append("retry_count_alert,");
            if (Columns.last_ej_summary_generated_at == (Columns.last_ej_summary_generated_at & columns))
                qry.Append("last_ej_summary_generated_at,");
            if (Columns.failed_to_parse_threshold == (Columns.failed_to_parse_threshold & columns))
                qry.Append("failed_to_parse_threshold,");
            if (Columns.active_directory_domain == (Columns.active_directory_domain & columns))
                qry.Append("active_directory_domain,");
            if (Columns.is_suspected_rep_task_disabled == (Columns.is_suspected_rep_task_disabled & columns))
                qry.Append("is_suspected_rep_task_disabled,");
            if (Columns.rep_time_diff == (Columns.rep_time_diff & columns))
                qry.Append("rep_time_diff,");
            if (Columns.rep_start_time == (Columns.rep_start_time & columns))
                qry.Append("rep_start_time,");
            if (Columns.rep_end_time == (Columns.rep_end_time & columns))
                qry.Append("rep_end_time,");
            if (Columns.notes_difference == (Columns.notes_difference & columns))
                qry.Append("notes_difference,");
            if (Columns.is_duplicate_checking_enabled == (Columns.is_duplicate_checking_enabled & columns))
                qry.Append("is_duplicate_checking_enabled,");
            if (Columns.allowed_no_of_days_for_mismatched_trxn_processing == (Columns.allowed_no_of_days_for_mismatched_trxn_processing & columns))
                qry.Append("allowed_no_of_days_for_mismatched_trxn_processing,");
            if (Columns.is_dff_halted == (Columns.is_dff_halted & columns))
                qry.Append("is_dff_halted,");
            if (Columns.is_ledger_auto_created == (Columns.is_ledger_auto_created & columns))
                qry.Append("is_ledger_auto_created,");
            if (Columns.initEjExecTime == (Columns.initEjExecTime & columns))
                qry.Append("initEjExecTime,");
            if (Columns.server_port2 == (Columns.server_port2 & columns))
                qry.Append("server_port2,");
            if (Columns.is_google_map_enabled == (Columns.is_google_map_enabled & columns))
                qry.Append("is_google_map_enabled,");
            if (Columns.ccms_parser_refresh_interval == (Columns.ccms_parser_refresh_interval & columns))
                qry.Append("ccms_parser_refresh_interval,");
            if (Columns.cash_order_generation_time == (Columns.cash_order_generation_time & columns))
                qry.Append("cash_order_generation_time,");
            if (Columns.currency_server_refresh_interval == (Columns.currency_server_refresh_interval & columns))
                qry.Append("currency_server_refresh_interval,");
            if (Columns.currency_mng_password == (Columns.currency_mng_password & columns))
                qry.Append("currency_mng_password,");
            if (Columns.exchange_password == (Columns.exchange_password & columns))
                qry.Append("exchange_password,");
            if (Columns.exchange_pop_password == (Columns.exchange_pop_password & columns))
                qry.Append("exchange_pop_password,");
            if (Columns.ej_parser_zip_password == (Columns.ej_parser_zip_password & columns))
                qry.Append("ej_parser_zip_password,");
            if (Columns.ej_parser_ftp_Password == (Columns.ej_parser_ftp_Password & columns))
                qry.Append("ej_parser_ftp_Password,");
            if (Columns.bank_name == (Columns.bank_name & columns))
                qry.Append("bank_name,");
            if (Columns.sms_token == (Columns.sms_token & columns))
                qry.Append("sms_token,");
            if (Columns.sms_token_generated_at == (Columns.sms_token_generated_at & columns))
                qry.Append("sms_token_generated_at,");
            if (Columns.customer_transaction_amount_threshold_low == (Columns.customer_transaction_amount_threshold_low & columns))
                qry.Append("customer_transaction_amount_threshold_low,");
            if (Columns.customer_transaction_amount_threshold_medium == (Columns.customer_transaction_amount_threshold_medium & columns))
                qry.Append("customer_transaction_amount_threshold_medium,");
            if (Columns.ServersInfo == (Columns.ServersInfo & columns))
                qry.Append("ServersInfo,");
            if (Columns.is_secured_access == (Columns.is_secured_access & columns))
                qry.Append("is_secured_access,");
            if (Columns.daily_feed_ftp_uri == (Columns.daily_feed_ftp_uri & columns))
                qry.Append("daily_feed_ftp_uri,");
            if (Columns.daily_feed_ftp_username == (Columns.daily_feed_ftp_username & columns))
                qry.Append("daily_feed_ftp_username,");
            if (Columns.daily_feed_ftp_password == (Columns.daily_feed_ftp_password & columns))
                qry.Append("daily_feed_ftp_password,");
            if (Columns.daily_feed_generation_time == (Columns.daily_feed_generation_time & columns))
                qry.Append("daily_feed_generation_time,");
            if (Columns.daily_feed_output_file_path == (Columns.daily_feed_output_file_path & columns))
                qry.Append("daily_feed_output_file_path,");
            if (Columns.daily_feed_generation_delay == (Columns.daily_feed_generation_delay & columns))
                qry.Append("daily_feed_generation_delay,");
            if (Columns.CoreDbName == (Columns.CoreDbName & columns))
                qry.Append("CoreDbName,");
            if (Columns.CashDbName == (Columns.CashDbName & columns))
                qry.Append("CashDbName,");
            if (Columns.TxDbName == (Columns.TxDbName & columns))
                qry.Append("TxDbName,");
            if (Columns.is_edited == (Columns.is_edited & columns))
                qry.Append("is_edited,");
            if (Columns.atm_data_streaming_heartbeat_port == (Columns.atm_data_streaming_heartbeat_port & columns))
                qry.Append("atm_data_streaming_heartbeat_port,");
            if (Columns.atm_data_streaming_port == (Columns.atm_data_streaming_port & columns))
                qry.Append("atm_data_streaming_port,");
            if (Columns.atm_on_demand_request_port == (Columns.atm_on_demand_request_port & columns))
                qry.Append("atm_on_demand_request_port,");
            if (Columns.atm_on_demand_request_hearbeat_port == (Columns.atm_on_demand_request_hearbeat_port & columns))
                qry.Append("atm_on_demand_request_hearbeat_port,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from App_setting ");

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
            return new AppSettingReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AppSettingReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AppSettingReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select app_setting_id,cash_data_stores_location,defalt_atm_port,refresh_interval,temporary_folder,logFile_path,parsing_enabled,LicenseKey,apply_password_policy,UI_log_level,service_log_level,heart_beat_refresh_interval,smtp_username,smtp_password,smtp_server,smtp_port,smtp_requires_authentication,downloaded_file_path,server_ip,server_port,archival_days,archival_server,archival_database,archival_username,archival_password,dashboard_refresh_interval,cash_order_execution_time,threshold_for_alert,threshold_for_ftp,threshold_for_task,threshold_for_cashorder,hold_other_df_tasks,alert_expiration_time,is_ciphered_comm,vault_day_balance_execution_time,retry_count_cash_order_upload,retry_count_cash_order_download,retry_count_dff_upload,retry_count_conf_upload,retry_count_counter_file,retry_count_restart_schedule,retry_count_datetime_schedule,cut_over_log_file_interval,retry_count_alert,last_ej_summary_generated_at,failed_to_parse_threshold,active_directory_domain,is_suspected_rep_task_disabled,rep_time_diff,rep_start_time,rep_end_time,notes_difference,is_duplicate_checking_enabled,allowed_no_of_days_for_mismatched_trxn_processing,is_dff_halted,is_ledger_auto_created,initEjExecTime,server_port2,is_google_map_enabled,ccms_parser_refresh_interval,cash_order_generation_time,currency_server_refresh_interval,currency_mng_password,exchange_password,exchange_pop_password,ej_parser_zip_password,ej_parser_ftp_Password,bank_name,sms_token,sms_token_generated_at,customer_transaction_amount_threshold_low,customer_transaction_amount_threshold_medium,ServersInfo,is_secured_access,daily_feed_ftp_uri,daily_feed_ftp_username,daily_feed_ftp_password,daily_feed_generation_time,daily_feed_output_file_path,daily_feed_generation_delay,CoreDbName,CashDbName,TxDbName,is_edited,atm_data_streaming_heartbeat_port,atm_data_streaming_port,atm_on_demand_request_port,atm_on_demand_request_hearbeat_port from App_setting ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AppSettingReader(cmd.ExecuteReader(), conn);
        }

        static public AppSettingReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public static AppSetting LoadAppSetting(string where)
        {
            AppSettingReader reader = AppSetting.ExecuteReader(where);
            AppSetting _appsetting = null;
            if (reader.Read())
                _appsetting = reader.CurrentAppSetting;
            reader.Close();
            return _appsetting;
        }

        public static AppSetting LoadAppSetting(string where, IDbConnection conn)
        {
            AppSettingReader reader = AppSetting.ExecuteReader(where, conn);
            AppSetting _appsetting = null;
            if (reader.Read())
                _appsetting = reader.CurrentAppSetting;
            reader.Close(false);
            return _appsetting;
        }

        public static AppSetting LoadAppSettingByPk(long app_setting_id)
        {
            return LoadAppSetting("app_setting_id=" + app_setting_id);
        }

        public static AppSetting LoadAppSettingByPk(long app_setting_id, IDbConnection conn)
        {
            return LoadAppSetting(" app_setting_id=" + app_setting_id, conn);
        }

        public void Save()
        {
            if (app_setting_idChanged || cash_data_stores_locationChanged || defalt_atm_portChanged || refresh_intervalChanged || temporary_folderChanged || logFile_pathChanged || parsing_enabledChanged || licenseKeyChanged || apply_password_policyChanged || uI_log_levelChanged || service_log_levelChanged || heart_beat_refresh_intervalChanged || smtp_usernameChanged || smtp_passwordChanged || smtp_serverChanged || smtp_portChanged || smtp_requires_authenticationChanged || downloaded_file_pathChanged || server_ipChanged || server_portChanged || archival_daysChanged || archival_serverChanged || archival_databaseChanged || archival_usernameChanged || archival_passwordChanged || dashboard_refresh_intervalChanged || cash_order_execution_timeChanged || threshold_for_alertChanged || threshold_for_ftpChanged || threshold_for_taskChanged || threshold_for_cashorderChanged || hold_other_df_tasksChanged || alert_expiration_timeChanged || is_ciphered_commChanged || vault_day_balance_execution_timeChanged || retry_count_cash_order_uploadChanged || retry_count_cash_order_downloadChanged || retry_count_dff_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || cut_over_log_file_intervalChanged || retry_count_alertChanged || last_ej_summary_generated_atChanged || failed_to_parse_thresholdChanged || active_directory_domainChanged || is_suspected_rep_task_disabledChanged || rep_time_diffChanged || rep_start_timeChanged || rep_end_timeChanged || notes_differenceChanged || is_duplicate_checking_enabledChanged || allowed_no_of_days_for_mismatched_trxn_processingChanged || is_dff_haltedChanged || is_ledger_auto_createdChanged || initEjExecTimeChanged || server_port2Changed || is_google_map_enabledChanged || ccms_parser_refresh_intervalChanged || cash_order_generation_timeChanged || currency_server_refresh_intervalChanged || currency_mng_passwordChanged || exchange_passwordChanged || exchange_pop_passwordChanged || ej_parser_zip_passwordChanged || ej_parser_ftp_PasswordChanged || bank_nameChanged || sms_tokenChanged || sms_token_generated_atChanged || customer_transaction_amount_threshold_lowChanged || customer_transaction_amount_threshold_mediumChanged || serversInfoChanged || is_secured_accessChanged || daily_feed_ftp_uriChanged || daily_feed_ftp_usernameChanged || daily_feed_ftp_passwordChanged || daily_feed_generation_timeChanged || daily_feed_output_file_pathChanged || daily_feed_generation_delayChanged || coreDbNameChanged || cashDbNameChanged || txDbNameChanged || is_editedChanged || atm_data_streaming_heartbeat_portChanged || atm_data_streaming_portChanged || atm_on_demand_request_portChanged || atm_on_demand_request_hearbeat_portChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Core).CreateCommand());
        }

        public void Save(IDbConnection conn, IDbTransaction trx)
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
        private void ExcuteSave(IDbCommand cmd)
        {
            if (app_setting_idChanged || cash_data_stores_locationChanged || defalt_atm_portChanged || refresh_intervalChanged || temporary_folderChanged || logFile_pathChanged || parsing_enabledChanged || licenseKeyChanged || apply_password_policyChanged || uI_log_levelChanged || service_log_levelChanged || heart_beat_refresh_intervalChanged || smtp_usernameChanged || smtp_passwordChanged || smtp_serverChanged || smtp_portChanged || smtp_requires_authenticationChanged || downloaded_file_pathChanged || server_ipChanged || server_portChanged || archival_daysChanged || archival_serverChanged || archival_databaseChanged || archival_usernameChanged || archival_passwordChanged || dashboard_refresh_intervalChanged || cash_order_execution_timeChanged || threshold_for_alertChanged || threshold_for_ftpChanged || threshold_for_taskChanged || threshold_for_cashorderChanged || hold_other_df_tasksChanged || alert_expiration_timeChanged || is_ciphered_commChanged || vault_day_balance_execution_timeChanged || retry_count_cash_order_uploadChanged || retry_count_cash_order_downloadChanged || retry_count_dff_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || cut_over_log_file_intervalChanged || retry_count_alertChanged || last_ej_summary_generated_atChanged || failed_to_parse_thresholdChanged || active_directory_domainChanged || is_suspected_rep_task_disabledChanged || rep_time_diffChanged || rep_start_timeChanged || rep_end_timeChanged || notes_differenceChanged || is_duplicate_checking_enabledChanged || allowed_no_of_days_for_mismatched_trxn_processingChanged || is_dff_haltedChanged || is_ledger_auto_createdChanged || initEjExecTimeChanged || server_port2Changed || is_google_map_enabledChanged || ccms_parser_refresh_intervalChanged || cash_order_generation_timeChanged || currency_server_refresh_intervalChanged || currency_mng_passwordChanged || exchange_passwordChanged || exchange_pop_passwordChanged || ej_parser_zip_passwordChanged || ej_parser_ftp_PasswordChanged || bank_nameChanged || sms_tokenChanged || sms_token_generated_atChanged || customer_transaction_amount_threshold_lowChanged || customer_transaction_amount_threshold_mediumChanged || serversInfoChanged || is_secured_accessChanged || daily_feed_ftp_uriChanged || daily_feed_ftp_usernameChanged || daily_feed_ftp_passwordChanged || daily_feed_generation_timeChanged || daily_feed_output_file_pathChanged || daily_feed_generation_delayChanged || coreDbNameChanged || cashDbNameChanged || txDbNameChanged || is_editedChanged || atm_data_streaming_heartbeat_portChanged || atm_data_streaming_portChanged || atm_on_demand_request_portChanged || atm_on_demand_request_hearbeat_portChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into App_setting(app_setting_id,cash_data_stores_location,defalt_atm_port,refresh_interval,temporary_folder,logFile_path,parsing_enabled,LicenseKey,apply_password_policy,UI_log_level,service_log_level,heart_beat_refresh_interval,smtp_username,smtp_password,smtp_server,smtp_port,smtp_requires_authentication,downloaded_file_path,server_ip,server_port,archival_days,archival_server,archival_database,archival_username,archival_password,dashboard_refresh_interval,cash_order_execution_time,threshold_for_alert,threshold_for_ftp,threshold_for_task,threshold_for_cashorder,hold_other_df_tasks,alert_expiration_time,is_ciphered_comm,vault_day_balance_execution_time,retry_count_cash_order_upload,retry_count_cash_order_download,retry_count_dff_upload,retry_count_conf_upload,retry_count_counter_file,retry_count_restart_schedule,retry_count_datetime_schedule,cut_over_log_file_interval,retry_count_alert,last_ej_summary_generated_at,failed_to_parse_threshold,active_directory_domain,is_suspected_rep_task_disabled,rep_time_diff,rep_start_time,rep_end_time,notes_difference,is_duplicate_checking_enabled,allowed_no_of_days_for_mismatched_trxn_processing,is_dff_halted,is_ledger_auto_created,initEjExecTime,server_port2,is_google_map_enabled,ccms_parser_refresh_interval,cash_order_generation_time,currency_server_refresh_interval,currency_mng_password,exchange_password,exchange_pop_password,ej_parser_zip_password,ej_parser_ftp_Password,bank_name,sms_token,sms_token_generated_at,customer_transaction_amount_threshold_low,customer_transaction_amount_threshold_medium,ServersInfo,is_secured_access,daily_feed_ftp_uri,daily_feed_ftp_username,daily_feed_ftp_password,daily_feed_generation_time,daily_feed_output_file_path,daily_feed_generation_delay,CoreDbName,CashDbName,TxDbName,is_edited,atm_data_streaming_heartbeat_port,atm_data_streaming_port,atm_on_demand_request_port,atm_on_demand_request_hearbeat_port) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.app_setting_id = ConnectionFactory.GetNextId( DatabaseName.Core);
                        qry.Append(this.app_setting_id);
                    }
                    qry.Append(",");
                    qry.Append(cash_data_stores_locationDbString + ",");
                    qry.Append(defalt_atm_portDbString + ",");
                    qry.Append(refresh_intervalDbString + ",");
                    qry.Append(temporary_folderDbString + ",");
                    qry.Append(logFile_pathDbString + ",");
                    qry.Append(parsing_enabledDbString + ",");
                    qry.Append(licenseKeyDbString + ",");
                    qry.Append(apply_password_policyDbString + ",");
                    qry.Append(uI_log_levelDbString + ",");
                    qry.Append(service_log_levelDbString + ",");
                    qry.Append(heart_beat_refresh_intervalDbString + ",");
                    qry.Append(smtp_usernameDbString + ",");
                    qry.Append(smtp_passwordDbString + ",");
                    qry.Append(smtp_serverDbString + ",");
                    qry.Append(smtp_portDbString + ",");
                    qry.Append(smtp_requires_authenticationDbString + ",");
                    qry.Append(downloaded_file_pathDbString + ",");
                    qry.Append(server_ipDbString + ",");
                    qry.Append(server_portDbString + ",");
                    qry.Append(archival_daysDbString + ",");
                    qry.Append(archival_serverDbString + ",");
                    qry.Append(archival_databaseDbString + ",");
                    qry.Append(archival_usernameDbString + ",");
                    qry.Append(archival_passwordDbString + ",");
                    qry.Append(dashboard_refresh_intervalDbString + ",");
                    qry.Append(cash_order_execution_timeDbString + ",");
                    qry.Append(threshold_for_alertDbString + ",");
                    qry.Append(threshold_for_ftpDbString + ",");
                    qry.Append(threshold_for_taskDbString + ",");
                    qry.Append(threshold_for_cashorderDbString + ",");
                    qry.Append(hold_other_df_tasksDbString + ",");
                    qry.Append(alert_expiration_timeDbString + ",");
                    qry.Append(is_ciphered_commDbString + ",");
                    qry.Append(vault_day_balance_execution_timeDbString + ",");
                    qry.Append(retry_count_cash_order_uploadDbString + ",");
                    qry.Append(retry_count_cash_order_downloadDbString + ",");
                    qry.Append(retry_count_dff_uploadDbString + ",");
                    qry.Append(retry_count_conf_uploadDbString + ",");
                    qry.Append(retry_count_counter_fileDbString + ",");
                    qry.Append(retry_count_restart_scheduleDbString + ",");
                    qry.Append(retry_count_datetime_scheduleDbString + ",");
                    qry.Append(cut_over_log_file_intervalDbString + ",");
                    qry.Append(retry_count_alertDbString + ",");
                    qry.Append(last_ej_summary_generated_atDbString + ",");
                    qry.Append(failed_to_parse_thresholdDbString + ",");
                    qry.Append(active_directory_domainDbString + ",");
                    qry.Append(is_suspected_rep_task_disabledDbString + ",");
                    qry.Append(rep_time_diffDbString + ",");
                    qry.Append(rep_start_timeDbString + ",");
                    qry.Append(rep_end_timeDbString + ",");
                    qry.Append(notes_differenceDbString + ",");
                    qry.Append(is_duplicate_checking_enabledDbString + ",");
                    qry.Append(allowed_no_of_days_for_mismatched_trxn_processingDbString + ",");
                    qry.Append(is_dff_haltedDbString + ",");
                    qry.Append(is_ledger_auto_createdDbString + ",");
                    qry.Append(initEjExecTimeDbString + ",");
                    qry.Append(server_port2DbString + ",");
                    qry.Append(is_google_map_enabledDbString + ",");
                    qry.Append(ccms_parser_refresh_intervalDbString + ",");
                    qry.Append(cash_order_generation_timeDbString + ",");
                    qry.Append(currency_server_refresh_intervalDbString + ",");
                    qry.Append(currency_mng_passwordDbString + ",");
                    qry.Append(exchange_passwordDbString + ",");
                    qry.Append(exchange_pop_passwordDbString + ",");
                    qry.Append(ej_parser_zip_passwordDbString + ",");
                    qry.Append(ej_parser_ftp_PasswordDbString + ",");
                    qry.Append(bank_nameDbString + ",");
                    qry.Append(sms_tokenDbString + ",");
                    qry.Append(sms_token_generated_atDbString + ",");
                    qry.Append(customer_transaction_amount_threshold_lowDbString + ",");
                    qry.Append(customer_transaction_amount_threshold_mediumDbString + ",");
                    qry.Append(serversInfoDbString + ",");
                    qry.Append(is_secured_accessDbString + ",");
                    qry.Append(daily_feed_ftp_uriDbString + ",");
                    qry.Append(daily_feed_ftp_usernameDbString + ",");
                    qry.Append(daily_feed_ftp_passwordDbString + ",");
                    qry.Append(daily_feed_generation_timeDbString + ",");
                    qry.Append(daily_feed_output_file_pathDbString + ",");
                    qry.Append(daily_feed_generation_delayDbString + ",");
                    qry.Append(coreDbNameDbString + ",");
                    qry.Append(cashDbNameDbString + ",");
                    qry.Append(txDbNameDbString + ",");
                    qry.Append(is_editedDbString + ",");
                    qry.Append(atm_data_streaming_heartbeat_portDbString + ",");
                    qry.Append(atm_data_streaming_portDbString + ",");
                    qry.Append(atm_on_demand_request_portDbString + ",");
                    qry.Append(atm_on_demand_request_hearbeat_portDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(app_setting_idChanged || cash_data_stores_locationChanged || defalt_atm_portChanged || refresh_intervalChanged || temporary_folderChanged || logFile_pathChanged || parsing_enabledChanged || licenseKeyChanged || apply_password_policyChanged || uI_log_levelChanged || service_log_levelChanged || heart_beat_refresh_intervalChanged || smtp_usernameChanged || smtp_passwordChanged || smtp_serverChanged || smtp_portChanged || smtp_requires_authenticationChanged || downloaded_file_pathChanged || server_ipChanged || server_portChanged || archival_daysChanged || archival_serverChanged || archival_databaseChanged || archival_usernameChanged || archival_passwordChanged || dashboard_refresh_intervalChanged || cash_order_execution_timeChanged || threshold_for_alertChanged || threshold_for_ftpChanged || threshold_for_taskChanged || threshold_for_cashorderChanged || hold_other_df_tasksChanged || alert_expiration_timeChanged || is_ciphered_commChanged || vault_day_balance_execution_timeChanged || retry_count_cash_order_uploadChanged || retry_count_cash_order_downloadChanged || retry_count_dff_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || cut_over_log_file_intervalChanged || retry_count_alertChanged || last_ej_summary_generated_atChanged || failed_to_parse_thresholdChanged || active_directory_domainChanged || is_suspected_rep_task_disabledChanged || rep_time_diffChanged || rep_start_timeChanged || rep_end_timeChanged || notes_differenceChanged || is_duplicate_checking_enabledChanged || allowed_no_of_days_for_mismatched_trxn_processingChanged || is_dff_haltedChanged || is_ledger_auto_createdChanged || initEjExecTimeChanged || server_port2Changed || is_google_map_enabledChanged || ccms_parser_refresh_intervalChanged || cash_order_generation_timeChanged || currency_server_refresh_intervalChanged || currency_mng_passwordChanged || exchange_passwordChanged || exchange_pop_passwordChanged || ej_parser_zip_passwordChanged || ej_parser_ftp_PasswordChanged || bank_nameChanged || sms_tokenChanged || sms_token_generated_atChanged || customer_transaction_amount_threshold_lowChanged || customer_transaction_amount_threshold_mediumChanged || serversInfoChanged || is_secured_accessChanged || daily_feed_ftp_uriChanged || daily_feed_ftp_usernameChanged || daily_feed_ftp_passwordChanged || daily_feed_generation_timeChanged || daily_feed_output_file_pathChanged || daily_feed_generation_delayChanged || coreDbNameChanged || cashDbNameChanged || txDbNameChanged || is_editedChanged || atm_data_streaming_heartbeat_portChanged || atm_data_streaming_portChanged || atm_on_demand_request_portChanged || atm_on_demand_request_hearbeat_portChanged))
                        return;
                    qry.Append("UPDATE App_setting set "); if (cash_data_stores_locationChanged)
                    {
                        qry.Append("cash_data_stores_location =" + cash_data_stores_locationDbString);
                        qry.Append(",");
                    }

                    if (defalt_atm_portChanged)
                    {
                        qry.Append("defalt_atm_port =" + defalt_atm_portDbString);
                        qry.Append(",");
                    }

                    if (refresh_intervalChanged)
                    {
                        qry.Append("refresh_interval =" + refresh_intervalDbString);
                        qry.Append(",");
                    }

                    if (temporary_folderChanged)
                    {
                        qry.Append("temporary_folder =" + temporary_folderDbString);
                        qry.Append(",");
                    }

                    if (logFile_pathChanged)
                    {
                        qry.Append("logFile_path =" + logFile_pathDbString);
                        qry.Append(",");
                    }

                    if (parsing_enabledChanged)
                    {
                        qry.Append("parsing_enabled =" + parsing_enabledDbString);
                        qry.Append(",");
                    }

                    if (licenseKeyChanged)
                    {
                        qry.Append("LicenseKey =" + licenseKeyDbString);
                        qry.Append(",");
                    }

                    if (apply_password_policyChanged)
                    {
                        qry.Append("apply_password_policy =" + apply_password_policyDbString);
                        qry.Append(",");
                    }

                    if (uI_log_levelChanged)
                    {
                        qry.Append("UI_log_level =" + uI_log_levelDbString);
                        qry.Append(",");
                    }

                    if (service_log_levelChanged)
                    {
                        qry.Append("service_log_level =" + service_log_levelDbString);
                        qry.Append(",");
                    }

                    if (heart_beat_refresh_intervalChanged)
                    {
                        qry.Append("heart_beat_refresh_interval =" + heart_beat_refresh_intervalDbString);
                        qry.Append(",");
                    }

                    if (smtp_usernameChanged)
                    {
                        qry.Append("smtp_username =" + smtp_usernameDbString);
                        qry.Append(",");
                    }

                    if (smtp_passwordChanged)
                    {
                        qry.Append("smtp_password =" + smtp_passwordDbString);
                        qry.Append(",");
                    }

                    if (smtp_serverChanged)
                    {
                        qry.Append("smtp_server =" + smtp_serverDbString);
                        qry.Append(",");
                    }

                    if (smtp_portChanged)
                    {
                        qry.Append("smtp_port =" + smtp_portDbString);
                        qry.Append(",");
                    }

                    if (smtp_requires_authenticationChanged)
                    {
                        qry.Append("smtp_requires_authentication =" + smtp_requires_authenticationDbString);
                        qry.Append(",");
                    }

                    if (downloaded_file_pathChanged)
                    {
                        qry.Append("downloaded_file_path =" + downloaded_file_pathDbString);
                        qry.Append(",");
                    }

                    if (server_ipChanged)
                    {
                        qry.Append("server_ip =" + server_ipDbString);
                        qry.Append(",");
                    }

                    if (server_portChanged)
                    {
                        qry.Append("server_port =" + server_portDbString);
                        qry.Append(",");
                    }

                    if (archival_daysChanged)
                    {
                        qry.Append("archival_days =" + archival_daysDbString);
                        qry.Append(",");
                    }

                    if (archival_serverChanged)
                    {
                        qry.Append("archival_server =" + archival_serverDbString);
                        qry.Append(",");
                    }

                    if (archival_databaseChanged)
                    {
                        qry.Append("archival_database =" + archival_databaseDbString);
                        qry.Append(",");
                    }

                    if (archival_usernameChanged)
                    {
                        qry.Append("archival_username =" + archival_usernameDbString);
                        qry.Append(",");
                    }

                    if (archival_passwordChanged)
                    {
                        qry.Append("archival_password =" + archival_passwordDbString);
                        qry.Append(",");
                    }

                    if (dashboard_refresh_intervalChanged)
                    {
                        qry.Append("dashboard_refresh_interval =" + dashboard_refresh_intervalDbString);
                        qry.Append(",");
                    }

                    if (cash_order_execution_timeChanged)
                    {
                        qry.Append("cash_order_execution_time =" + cash_order_execution_timeDbString);
                        qry.Append(",");
                    }

                    if (threshold_for_alertChanged)
                    {
                        qry.Append("threshold_for_alert =" + threshold_for_alertDbString);
                        qry.Append(",");
                    }

                    if (threshold_for_ftpChanged)
                    {
                        qry.Append("threshold_for_ftp =" + threshold_for_ftpDbString);
                        qry.Append(",");
                    }

                    if (threshold_for_taskChanged)
                    {
                        qry.Append("threshold_for_task =" + threshold_for_taskDbString);
                        qry.Append(",");
                    }

                    if (threshold_for_cashorderChanged)
                    {
                        qry.Append("threshold_for_cashorder =" + threshold_for_cashorderDbString);
                        qry.Append(",");
                    }

                    if (hold_other_df_tasksChanged)
                    {
                        qry.Append("hold_other_df_tasks =" + hold_other_df_tasksDbString);
                        qry.Append(",");
                    }

                    if (alert_expiration_timeChanged)
                    {
                        qry.Append("alert_expiration_time =" + alert_expiration_timeDbString);
                        qry.Append(",");
                    }

                    if (is_ciphered_commChanged)
                    {
                        qry.Append("is_ciphered_comm =" + is_ciphered_commDbString);
                        qry.Append(",");
                    }

                    if (vault_day_balance_execution_timeChanged)
                    {
                        qry.Append("vault_day_balance_execution_time =" + vault_day_balance_execution_timeDbString);
                        qry.Append(",");
                    }

                    if (retry_count_cash_order_uploadChanged)
                    {
                        qry.Append("retry_count_cash_order_upload =" + retry_count_cash_order_uploadDbString);
                        qry.Append(",");
                    }

                    if (retry_count_cash_order_downloadChanged)
                    {
                        qry.Append("retry_count_cash_order_download =" + retry_count_cash_order_downloadDbString);
                        qry.Append(",");
                    }

                    if (retry_count_dff_uploadChanged)
                    {
                        qry.Append("retry_count_dff_upload =" + retry_count_dff_uploadDbString);
                        qry.Append(",");
                    }

                    if (retry_count_conf_uploadChanged)
                    {
                        qry.Append("retry_count_conf_upload =" + retry_count_conf_uploadDbString);
                        qry.Append(",");
                    }

                    if (retry_count_counter_fileChanged)
                    {
                        qry.Append("retry_count_counter_file =" + retry_count_counter_fileDbString);
                        qry.Append(",");
                    }

                    if (retry_count_restart_scheduleChanged)
                    {
                        qry.Append("retry_count_restart_schedule =" + retry_count_restart_scheduleDbString);
                        qry.Append(",");
                    }

                    if (retry_count_datetime_scheduleChanged)
                    {
                        qry.Append("retry_count_datetime_schedule =" + retry_count_datetime_scheduleDbString);
                        qry.Append(",");
                    }

                    if (cut_over_log_file_intervalChanged)
                    {
                        qry.Append("cut_over_log_file_interval =" + cut_over_log_file_intervalDbString);
                        qry.Append(",");
                    }

                    if (retry_count_alertChanged)
                    {
                        qry.Append("retry_count_alert =" + retry_count_alertDbString);
                        qry.Append(",");
                    }

                    if (last_ej_summary_generated_atChanged)
                    {
                        qry.Append("last_ej_summary_generated_at =" + last_ej_summary_generated_atDbString);
                        qry.Append(",");
                    }

                    if (failed_to_parse_thresholdChanged)
                    {
                        qry.Append("failed_to_parse_threshold =" + failed_to_parse_thresholdDbString);
                        qry.Append(",");
                    }

                    if (active_directory_domainChanged)
                    {
                        qry.Append("active_directory_domain =" + active_directory_domainDbString);
                        qry.Append(",");
                    }

                    if (is_suspected_rep_task_disabledChanged)
                    {
                        qry.Append("is_suspected_rep_task_disabled =" + is_suspected_rep_task_disabledDbString);
                        qry.Append(",");
                    }

                    if (rep_time_diffChanged)
                    {
                        qry.Append("rep_time_diff =" + rep_time_diffDbString);
                        qry.Append(",");
                    }

                    if (rep_start_timeChanged)
                    {
                        qry.Append("rep_start_time =" + rep_start_timeDbString);
                        qry.Append(",");
                    }

                    if (rep_end_timeChanged)
                    {
                        qry.Append("rep_end_time =" + rep_end_timeDbString);
                        qry.Append(",");
                    }

                    if (notes_differenceChanged)
                    {
                        qry.Append("notes_difference =" + notes_differenceDbString);
                        qry.Append(",");
                    }

                    if (is_duplicate_checking_enabledChanged)
                    {
                        qry.Append("is_duplicate_checking_enabled =" + is_duplicate_checking_enabledDbString);
                        qry.Append(",");
                    }

                    if (allowed_no_of_days_for_mismatched_trxn_processingChanged)
                    {
                        qry.Append("allowed_no_of_days_for_mismatched_trxn_processing =" + allowed_no_of_days_for_mismatched_trxn_processingDbString);
                        qry.Append(",");
                    }

                    if (is_dff_haltedChanged)
                    {
                        qry.Append("is_dff_halted =" + is_dff_haltedDbString);
                        qry.Append(",");
                    }

                    if (is_ledger_auto_createdChanged)
                    {
                        qry.Append("is_ledger_auto_created =" + is_ledger_auto_createdDbString);
                        qry.Append(",");
                    }

                    if (initEjExecTimeChanged)
                    {
                        qry.Append("initEjExecTime =" + initEjExecTimeDbString);
                        qry.Append(",");
                    }

                    if (server_port2Changed)
                    {
                        qry.Append("server_port2 =" + server_port2DbString);
                        qry.Append(",");
                    }

                    if (is_google_map_enabledChanged)
                    {
                        qry.Append("is_google_map_enabled =" + is_google_map_enabledDbString);
                        qry.Append(",");
                    }

                    if (ccms_parser_refresh_intervalChanged)
                    {
                        qry.Append("ccms_parser_refresh_interval =" + ccms_parser_refresh_intervalDbString);
                        qry.Append(",");
                    }

                    if (cash_order_generation_timeChanged)
                    {
                        qry.Append("cash_order_generation_time =" + cash_order_generation_timeDbString);
                        qry.Append(",");
                    }

                    if (currency_server_refresh_intervalChanged)
                    {
                        qry.Append("currency_server_refresh_interval =" + currency_server_refresh_intervalDbString);
                        qry.Append(",");
                    }

                    if (currency_mng_passwordChanged)
                    {
                        qry.Append("currency_mng_password =" + currency_mng_passwordDbString);
                        qry.Append(",");
                    }

                    if (exchange_passwordChanged)
                    {
                        qry.Append("exchange_password =" + exchange_passwordDbString);
                        qry.Append(",");
                    }

                    if (exchange_pop_passwordChanged)
                    {
                        qry.Append("exchange_pop_password =" + exchange_pop_passwordDbString);
                        qry.Append(",");
                    }

                    if (ej_parser_zip_passwordChanged)
                    {
                        qry.Append("ej_parser_zip_password =" + ej_parser_zip_passwordDbString);
                        qry.Append(",");
                    }

                    if (ej_parser_ftp_PasswordChanged)
                    {
                        qry.Append("ej_parser_ftp_Password =" + ej_parser_ftp_PasswordDbString);
                        qry.Append(",");
                    }

                    if (bank_nameChanged)
                    {
                        qry.Append("bank_name =" + bank_nameDbString);
                        qry.Append(",");
                    }

                    if (sms_tokenChanged)
                    {
                        qry.Append("sms_token =" + sms_tokenDbString);
                        qry.Append(",");
                    }

                    if (sms_token_generated_atChanged)
                    {
                        qry.Append("sms_token_generated_at =" + sms_token_generated_atDbString);
                        qry.Append(",");
                    }

                    if (customer_transaction_amount_threshold_lowChanged)
                    {
                        qry.Append("customer_transaction_amount_threshold_low =" + customer_transaction_amount_threshold_lowDbString);
                        qry.Append(",");
                    }

                    if (customer_transaction_amount_threshold_mediumChanged)
                    {
                        qry.Append("customer_transaction_amount_threshold_medium =" + customer_transaction_amount_threshold_mediumDbString);
                        qry.Append(",");
                    }

                    if (serversInfoChanged)
                    {
                        qry.Append("ServersInfo =" + serversInfoDbString);
                        qry.Append(",");
                    }

                    if (is_secured_accessChanged)
                    {
                        qry.Append("is_secured_access =" + is_secured_accessDbString);
                        qry.Append(",");
                    }

                    if (daily_feed_ftp_uriChanged)
                    {
                        qry.Append("daily_feed_ftp_uri =" + daily_feed_ftp_uriDbString);
                        qry.Append(",");
                    }

                    if (daily_feed_ftp_usernameChanged)
                    {
                        qry.Append("daily_feed_ftp_username =" + daily_feed_ftp_usernameDbString);
                        qry.Append(",");
                    }

                    if (daily_feed_ftp_passwordChanged)
                    {
                        qry.Append("daily_feed_ftp_password =" + daily_feed_ftp_passwordDbString);
                        qry.Append(",");
                    }

                    if (daily_feed_generation_timeChanged)
                    {
                        qry.Append("daily_feed_generation_time =" + daily_feed_generation_timeDbString);
                        qry.Append(",");
                    }

                    if (daily_feed_output_file_pathChanged)
                    {
                        qry.Append("daily_feed_output_file_path =" + daily_feed_output_file_pathDbString);
                        qry.Append(",");
                    }

                    if (daily_feed_generation_delayChanged)
                    {
                        qry.Append("daily_feed_generation_delay =" + daily_feed_generation_delayDbString);
                        qry.Append(",");
                    }

                    if (coreDbNameChanged)
                    {
                        qry.Append("CoreDbName =" + coreDbNameDbString);
                        qry.Append(",");
                    }

                    if (cashDbNameChanged)
                    {
                        qry.Append("CashDbName =" + cashDbNameDbString);
                        qry.Append(",");
                    }

                    if (txDbNameChanged)
                    {
                        qry.Append("TxDbName =" + txDbNameDbString);
                        qry.Append(",");
                    }

                    if (is_editedChanged)
                    {
                        qry.Append("is_edited =" + is_editedDbString);
                        qry.Append(",");
                    }

                    if (atm_data_streaming_heartbeat_portChanged)
                    {
                        qry.Append("atm_data_streaming_heartbeat_port =" + atm_data_streaming_heartbeat_portDbString);
                        qry.Append(",");
                    }

                    if (atm_data_streaming_portChanged)
                    {
                        qry.Append("atm_data_streaming_port =" + atm_data_streaming_portDbString);
                        qry.Append(",");
                    }

                    if (atm_on_demand_request_portChanged)
                    {
                        qry.Append("atm_on_demand_request_port =" + atm_on_demand_request_portDbString);
                        qry.Append(",");
                    }

                    if (atm_on_demand_request_hearbeat_portChanged)
                    {
                        qry.Append("atm_on_demand_request_hearbeat_port =" + atm_on_demand_request_hearbeat_portDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("app_setting_id = " + app_setting_idDbString);
                }
                if (serversInfoChanged)
                {
                    IDbDataParameter dbParam_serversInfo = cmd.CreateParameter();
                    cmd.Parameters.Add(dbParam_serversInfo);
                    dbParam_serversInfo.ParameterName = "@serversInfo";
                    dbParam_serversInfo.Value = this.serversInfo;
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE App_setting whereapp_setting_id= " + app_setting_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAppSettings(string where)
        {
            ConnectionFactory.ExecuteQuery("delete App_setting where " + where,DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            app_setting_id = 0,
            cash_data_stores_location = 1,
            defalt_atm_port = 2,
            refresh_interval = 3,
            temporary_folder = 4,
            logFile_path = 5,
            parsing_enabled = 6,
            LicenseKey = 7,
            apply_password_policy = 8,
            UI_log_level = 9,
            service_log_level = 10,
            heart_beat_refresh_interval = 11,
            smtp_username = 12,
            smtp_password = 13,
            smtp_server = 14,
            smtp_port = 15,
            smtp_requires_authentication = 16,
            downloaded_file_path = 17,
            server_ip = 18,
            server_port = 19,
            archival_days = 20,
            archival_server = 21,
            archival_database = 22,
            archival_username = 23,
            archival_password = 24,
            dashboard_refresh_interval = 25,
            cash_order_execution_time = 26,
            threshold_for_alert = 27,
            threshold_for_ftp = 28,
            threshold_for_task = 29,
            threshold_for_cashorder = 30,
            hold_other_df_tasks = 31,
            alert_expiration_time = 32,
            is_ciphered_comm = 33,
            vault_day_balance_execution_time = 34,
            retry_count_cash_order_upload = 35,
            retry_count_cash_order_download = 36,
            retry_count_dff_upload = 37,
            retry_count_conf_upload = 38,
            retry_count_counter_file = 39,
            retry_count_restart_schedule = 40,
            retry_count_datetime_schedule = 41,
            cut_over_log_file_interval = 42,
            retry_count_alert = 43,
            last_ej_summary_generated_at = 44,
            failed_to_parse_threshold = 45,
            active_directory_domain = 46,
            is_suspected_rep_task_disabled = 47,
            rep_time_diff = 48,
            rep_start_time = 49,
            rep_end_time = 50,
            notes_difference = 51,
            is_duplicate_checking_enabled = 52,
            allowed_no_of_days_for_mismatched_trxn_processing = 53,
            is_dff_halted = 54,
            is_ledger_auto_created = 55,
            initEjExecTime = 56,
            server_port2 = 57,
            is_google_map_enabled = 58,
            ccms_parser_refresh_interval = 59,
            cash_order_generation_time = 60,
            currency_server_refresh_interval = 61,
            currency_mng_password = 62,
            exchange_password = 63,
            exchange_pop_password = 64,
            ej_parser_zip_password = 65,
            ej_parser_ftp_Password = 66,
            bank_name = 67,
            sms_token = 68,
            sms_token_generated_at = 69,
            customer_transaction_amount_threshold_low = 70,
            customer_transaction_amount_threshold_medium = 71,
            ServersInfo = 72,
            is_secured_access = 73,
            daily_feed_ftp_uri = 74,
            daily_feed_ftp_username = 75,
            daily_feed_ftp_password = 76,
            daily_feed_generation_time = 77,
            daily_feed_output_file_path = 78,
            daily_feed_generation_delay = 79,
            CoreDbName = 80,
            CashDbName = 81,
            TxDbName = 82,
            is_edited = 83,
            atm_data_streaming_heartbeat_port = 84,
            atm_data_streaming_port = 85,
            atm_on_demand_request_port = 86,
            atm_on_demand_request_hearbeat_port = 87
        }
        #endregion
        public DataTable BulkSave(List<AppSetting> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "App_setting";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(AppSetting.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<AppSetting> transList, ref DataTable dt)
        {
            foreach (AppSetting tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["app_setting_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
                Row["cash_data_stores_location"] = tran.CashDataStoresLocation;
                Row["defalt_atm_port"] = tran.DefaltAtmPort;
                Row["refresh_interval"] = tran.RefreshInterval;
                Row["temporary_folder"] = tran.TemporaryFolder;
                Row["logFile_path"] = tran.LogFilePath;
                Row["parsing_enabled"] = tran.ParsingEnabled;
                Row["licenseKey"] = tran.LicenseKey;
                Row["apply_password_policy"] = tran.ApplyPasswordPolicy;
                Row["uI_log_level"] = tran.UILogLevel;
                Row["service_log_level"] = tran.ServiceLogLevel;
                Row["heart_beat_refresh_interval"] = tran.HeartBeatRefreshInterval;
                Row["smtp_username"] = tran.SmtpUsername;
                Row["smtp_password"] = tran.SmtpPassword;
                Row["smtp_server"] = tran.SmtpServer;
                Row["smtp_port"] = tran.SmtpPort;
                Row["smtp_requires_authentication"] = tran.SmtpRequiresAuthentication;
                Row["downloaded_file_path"] = tran.DownloadedFilePath;
                Row["server_ip"] = tran.ServerIp;
                Row["server_port"] = tran.ServerPort;
                Row["archival_days"] = tran.ArchivalDays;
                Row["archival_server"] = tran.ArchivalServer;
                Row["archival_database"] = tran.ArchivalDatabase;
                Row["archival_username"] = tran.ArchivalUsername;
                Row["archival_password"] = tran.ArchivalPassword;
                Row["dashboard_refresh_interval"] = tran.DashboardRefreshInterval;
                Row["cash_order_execution_time"] = tran.CashOrderExecutionTime;
                Row["threshold_for_alert"] = tran.ThresholdForAlert;
                Row["threshold_for_ftp"] = tran.ThresholdForFtp;
                Row["threshold_for_task"] = tran.ThresholdForTask;
                Row["threshold_for_cashorder"] = tran.ThresholdForCashorder;
                Row["hold_other_df_tasks"] = tran.HoldOtherDfTasks;
                Row["alert_expiration_time"] = tran.AlertExpirationTime;
                Row["is_ciphered_comm"] = tran.IsCipheredComm;
                Row["vault_day_balance_execution_time"] = tran.VaultDayBalanceExecutionTime;
                Row["retry_count_cash_order_upload"] = tran.RetryCountCashOrderUpload;
                Row["retry_count_cash_order_download"] = tran.RetryCountCashOrderDownload;
                Row["retry_count_dff_upload"] = tran.RetryCountDffUpload;
                Row["retry_count_conf_upload"] = tran.RetryCountConfUpload;
                Row["retry_count_counter_file"] = tran.RetryCountCounterFile;
                Row["retry_count_restart_schedule"] = tran.RetryCountRestartSchedule;
                Row["retry_count_datetime_schedule"] = tran.RetryCountDatetimeSchedule;
                Row["cut_over_log_file_interval"] = tran.CutOverLogFileInterval;
                Row["retry_count_alert"] = tran.RetryCountAlert;
                Row["last_ej_summary_generated_at"] = tran.LastEjSummaryGeneratedAt;
                Row["failed_to_parse_threshold"] = tran.FailedToParseThreshold;
                Row["active_directory_domain"] = tran.ActiveDirectoryDomain;
                Row["is_suspected_rep_task_disabled"] = tran.IsSuspectedRepTaskDisabled;
                Row["rep_time_diff"] = tran.RepTimeDiff;
                Row["rep_start_time"] = tran.RepStartTime;
                Row["rep_end_time"] = tran.RepEndTime;
                Row["notes_difference"] = tran.NotesDifference;
                Row["is_duplicate_checking_enabled"] = tran.IsDuplicateCheckingEnabled;
                Row["allowed_no_of_days_for_mismatched_trxn_processing"] = tran.AllowedNoOfDaysForMismatchedTrxnProcessing;
                Row["is_dff_halted"] = tran.IsDffHalted;
                Row["is_ledger_auto_created"] = tran.IsLedgerAutoCreated;
                Row["initEjExecTime"] = tran.InitEjExecTime;
                Row["server_port2"] = tran.ServerPort2;
                Row["is_google_map_enabled"] = tran.IsGoogleMapEnabled;
                Row["ccms_parser_refresh_interval"] = tran.CcmsParserRefreshInterval;
                Row["cash_order_generation_time"] = tran.CashOrderGenerationTime;
                Row["currency_server_refresh_interval"] = tran.CurrencyServerRefreshInterval;
                Row["currency_mng_password"] = tran.CurrencyMngPassword;
                Row["exchange_password"] = tran.ExchangePassword;
                Row["exchange_pop_password"] = tran.ExchangePopPassword;
                Row["ej_parser_zip_password"] = tran.EjParserZipPassword;
                Row["ej_parser_ftp_Password"] = tran.EjParserFtpPassword;
                Row["bank_name"] = tran.BankName;
                Row["sms_token"] = tran.SmsToken;
                Row["sms_token_generated_at"] = tran.SmsTokenGeneratedAt;
                Row["customer_transaction_amount_threshold_low"] = tran.CustomerTransactionAmountThresholdLow;
                Row["customer_transaction_amount_threshold_medium"] = tran.CustomerTransactionAmountThresholdMedium;
                Row["serversInfo"] = tran.ServersInfo;
                Row["is_secured_access"] = tran.IsSecuredAccess;
                Row["daily_feed_ftp_uri"] = tran.DailyFeedFtpUri;
                Row["daily_feed_ftp_username"] = tran.DailyFeedFtpUsername;
                Row["daily_feed_ftp_password"] = tran.DailyFeedFtpPassword;
                Row["daily_feed_generation_time"] = tran.DailyFeedGenerationTime;
                Row["daily_feed_output_file_path"] = tran.DailyFeedOutputFilePath;
                Row["daily_feed_generation_delay"] = tran.DailyFeedGenerationDelay;
                Row["coreDbName"] = tran.CoreDbName;
                Row["cashDbName"] = tran.CashDbName;
                Row["txDbName"] = tran.TxDbName;
                Row["is_edited"] = tran.IsEdited;
                Row["atm_data_streaming_heartbeat_port"] = tran.AtmDataStreamingHeartbeatPort;
                Row["atm_data_streaming_port"] = tran.AtmDataStreamingPort;
                Row["atm_on_demand_request_port"] = tran.AtmOnDemandRequestPort;
                Row["atm_on_demand_request_hearbeat_port"] = tran.AtmOnDemandRequestHearbeatPort;
                dt.Rows.Add(Row);
            }
        }
    }
}


