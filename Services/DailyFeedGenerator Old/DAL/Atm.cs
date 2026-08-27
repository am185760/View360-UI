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
    public class Atm
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Atm() { }
        public Atm(int aTM_id, int region_id, string title, string iP, int port, int created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, DateTime last_wincor_sent, bool is_healthy, bool suspend_cash_order, int note_set_type_id, int retry_count_cash_order_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int retry_count_alert, int countsClearRetries, int tCPTimeout, int sleepInterval, int cPMCommandWait, int cPMCommandSleep, string aANDCApplications1, string aANDCApplications2, string aANDCApplications3, string aANDCApplications4, string aANDCApplications5, int monitoring_Retries, int windowSwitch_Sleep, int appSwitch_Sleep, int monitoringCycle_Sleep, int cPMLogLevel, bool isDispenserRealTimeNotificationEnabled, bool isBNARealTimeNotificationEnabled, bool isCPMRealTimeNotificationEnabled, bool isReplenishmentRealTimeNotificationEnabled, bool isOutOfCashRealTimeNotificationEnabled, bool isDispenserMismatchRealTimeNotificationEnabled, bool isBNAMismatchRealTimeNotificationEnabled, bool isCPMMismatchRealTimeNotificationEnabled, bool isCounterExplodedRealTimeNotificationEnabled, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, int out_of_cash_threshold, bool is_ej_enabled, bool is_counter_enabled, int priority, int protocol_type_id, byte current_mode, byte aggregate_state, byte communication_status, bool is_critical, bool is_sdm)
        {
            this.region_id = region_id;
            this.region_idChanged = true;
            this.title = title;
            this.titleChanged = true;
            this.iP = iP;
            this.iPChanged = true;
            this.port = port;
            this.portChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.atm_type = atm_type;
            this.atm_typeChanged = true;
            this.cassette1_capacity = cassette1_capacity;
            this.cassette1_capacityChanged = true;
            this.cassette1_denomination = cassette1_denomination;
            this.cassette1_denominationChanged = true;
            this.cassette2_capacity = cassette2_capacity;
            this.cassette2_capacityChanged = true;
            this.cassette2_denomination = cassette2_denomination;
            this.cassette2_denominationChanged = true;
            this.cassette3_denomination = cassette3_denomination;
            this.cassette3_denominationChanged = true;
            this.cassette3_capacity = cassette3_capacity;
            this.cassette3_capacityChanged = true;
            this.cassette4_denomination = cassette4_denomination;
            this.cassette4_denominationChanged = true;
            this.cassette4_capacity = cassette4_capacity;
            this.cassette4_capacityChanged = true;
            this.cassette5_denomination = cassette5_denomination;
            this.cassette5_denominationChanged = true;
            this.cassette5_capacity = cassette5_capacity;
            this.cassette5_capacityChanged = true;
            this.cassette6_denomination = cassette6_denomination;
            this.cassette6_denominationChanged = true;
            this.cassette6_capacity = cassette6_capacity;
            this.cassette6_capacityChanged = true;
            this.cassette7_denomination = cassette7_denomination;
            this.cassette7_denominationChanged = true;
            this.cassette7_capacity = cassette7_capacity;
            this.cassette7_capacityChanged = true;
            this.last_wincor_sent = last_wincor_sent;
            this.last_wincor_sentChanged = true;
            this.is_healthy = is_healthy;
            this.is_healthyChanged = true;
            this.suspend_cash_order = suspend_cash_order;
            this.suspend_cash_orderChanged = true;
            this.note_set_type_id = note_set_type_id;
            this.note_set_type_idChanged = true;
            this.retry_count_cash_order_upload = retry_count_cash_order_upload;
            this.retry_count_cash_order_uploadChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.retry_count_counter_file = retry_count_counter_file;
            this.retry_count_counter_fileChanged = true;
            this.retry_count_restart_schedule = retry_count_restart_schedule;
            this.retry_count_restart_scheduleChanged = true;
            this.retry_count_datetime_schedule = retry_count_datetime_schedule;
            this.retry_count_datetime_scheduleChanged = true;
            this.retry_count_alert = retry_count_alert;
            this.retry_count_alertChanged = true;
            this.countsClearRetries = countsClearRetries;
            this.countsClearRetriesChanged = true;
            this.tCPTimeout = tCPTimeout;
            this.tCPTimeoutChanged = true;
            this.sleepInterval = sleepInterval;
            this.sleepIntervalChanged = true;
            this.cPMCommandWait = cPMCommandWait;
            this.cPMCommandWaitChanged = true;
            this.cPMCommandSleep = cPMCommandSleep;
            this.cPMCommandSleepChanged = true;
            this.aANDCApplications1 = aANDCApplications1;
            this.aANDCApplications1Changed = true;
            this.aANDCApplications2 = aANDCApplications2;
            this.aANDCApplications2Changed = true;
            this.aANDCApplications3 = aANDCApplications3;
            this.aANDCApplications3Changed = true;
            this.aANDCApplications4 = aANDCApplications4;
            this.aANDCApplications4Changed = true;
            this.aANDCApplications5 = aANDCApplications5;
            this.aANDCApplications5Changed = true;
            this.monitoring_Retries = monitoring_Retries;
            this.monitoring_RetriesChanged = true;
            this.windowSwitch_Sleep = windowSwitch_Sleep;
            this.windowSwitch_SleepChanged = true;
            this.appSwitch_Sleep = appSwitch_Sleep;
            this.appSwitch_SleepChanged = true;
            this.monitoringCycle_Sleep = monitoringCycle_Sleep;
            this.monitoringCycle_SleepChanged = true;
            this.cPMLogLevel = cPMLogLevel;
            this.cPMLogLevelChanged = true;
            this.isDispenserRealTimeNotificationEnabled = isDispenserRealTimeNotificationEnabled;
            this.isDispenserRealTimeNotificationEnabledChanged = true;
            this.isBNARealTimeNotificationEnabled = isBNARealTimeNotificationEnabled;
            this.isBNARealTimeNotificationEnabledChanged = true;
            this.isCPMRealTimeNotificationEnabled = isCPMRealTimeNotificationEnabled;
            this.isCPMRealTimeNotificationEnabledChanged = true;
            this.isReplenishmentRealTimeNotificationEnabled = isReplenishmentRealTimeNotificationEnabled;
            this.isReplenishmentRealTimeNotificationEnabledChanged = true;
            this.isOutOfCashRealTimeNotificationEnabled = isOutOfCashRealTimeNotificationEnabled;
            this.isOutOfCashRealTimeNotificationEnabledChanged = true;
            this.isDispenserMismatchRealTimeNotificationEnabled = isDispenserMismatchRealTimeNotificationEnabled;
            this.isDispenserMismatchRealTimeNotificationEnabledChanged = true;
            this.isBNAMismatchRealTimeNotificationEnabled = isBNAMismatchRealTimeNotificationEnabled;
            this.isBNAMismatchRealTimeNotificationEnabledChanged = true;
            this.isCPMMismatchRealTimeNotificationEnabled = isCPMMismatchRealTimeNotificationEnabled;
            this.isCPMMismatchRealTimeNotificationEnabledChanged = true;
            this.isCounterExplodedRealTimeNotificationEnabled = isCounterExplodedRealTimeNotificationEnabled;
            this.isCounterExplodedRealTimeNotificationEnabledChanged = true;
            this.type1MinimumNotes = type1MinimumNotes;
            this.type1MinimumNotesChanged = true;
            this.type2MinimumNotes = type2MinimumNotes;
            this.type2MinimumNotesChanged = true;
            this.type3MinimumNotes = type3MinimumNotes;
            this.type3MinimumNotesChanged = true;
            this.type4MinimumNotes = type4MinimumNotes;
            this.type4MinimumNotesChanged = true;
            this.type5MinimumNotes = type5MinimumNotes;
            this.type5MinimumNotesChanged = true;
            this.type6MinimumNotes = type6MinimumNotes;
            this.type6MinimumNotesChanged = true;
            this.type7MinimumNotes = type7MinimumNotes;
            this.type7MinimumNotesChanged = true;
            this.out_of_cash_threshold = out_of_cash_threshold;
            this.out_of_cash_thresholdChanged = true;
            this.is_ej_enabled = is_ej_enabled;
            this.is_ej_enabledChanged = true;
            this.is_counter_enabled = is_counter_enabled;
            this.is_counter_enabledChanged = true;
            this.priority = priority;
            this.priorityChanged = true;
            this.protocol_type_id = protocol_type_id;
            this.protocol_type_idChanged = true;
            this.current_mode = current_mode;
            this.current_modeChanged = true;
            this.aggregate_state = aggregate_state;
            this.aggregate_stateChanged = true;
            this.communication_status = communication_status;
            this.communication_statusChanged = true;
            this.is_critical = is_critical;
            this.is_criticalChanged = true;
            this.is_sdm = is_sdm;
            this.is_sdmChanged = true;
        }
        public Atm(string last_status_reply, int region_id, string title, string iP, int port, int? modified_by, int created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, DateTime last_wincor_sent, bool is_healthy, string location, string address1, string address2, string city, string country, string zip_code, string location_type, string service_status, string holiday_status, string business_days, int? time_zone, int? max_notes_per_cassette, int? cassette1_split_percentage, int? cassette2_split_percentage, int? cassette3_split_percentage, int? cassette4_split_percentage, int? cassette5_split_percentage, int? cassette6_split_percentage, int? cassette7_split_percentage, decimal? interest_rate, decimal? insurance_rate, decimal? max_holding_amount, decimal? min_operating_balance, decimal? min_amount_for_normal_delivery, string bank_cash_center_id, string cIT_cash_center_servicer, string depot_id, string secondary_depot_vault_id, string new_atm_scenario, string cash_swap_days, string mandatory_cash_swap_days, int? cash_swap_cycle, int? cash_swap_lead_time, DateTime? cash_swap_start_date, decimal? cash_swap_handling_cost, decimal? cash_swap_costs, string emergency_days, int? emergency_lead_time, decimal? emergency_cost, string contact1_email, string contact2_email, string contact3_email, string contact1_phone, string contact2_phone, string contact3_phone, DateTime? effective_date, bool suspend_cash_order, bool? is_atm, bool? is_cdm, bool? is_ccdm, int? cdm_cassette1_capacity, int? cdm_cassette2_capacity, int? cdm_cassette3_capacity, int? cdm_cassette4_capacity, int? ccdm_cassette1_capacity, int? ccdm_cassette2_capacity, int? ccdm_cassette3_capacity, int? ccdm_cassette4_capacity, int? cdm_cassette1_threshold, int? cdm_cassette2_threshold, int? cdm_cassette3_threshold, int? cdm_cassette4_threshold, int? ccdm_cassette1_threshold, int? ccdm_cassette2_threshold, int? ccdm_cassette3_threshold, int? ccdm_cassette4_threshold, int note_set_type_id, int? ccdm_cassette5_capacity, int? ccdm_cassette5_threshold, int? startup_sleep_interval, byte? debug_level, bool? exclude_dff, int? purge1_threshold, bool? is_purge1_threshold_selected, int? purge2_threshold, bool? is_purge2_threshold_selected, int? purge3_threshold, bool? is_purge3_threshold_selected, int? purge4_threshold, bool? is_purge4_threshold_selected, int? purge5_threshold, bool? is_purge5_threshold_selected, int? purge6_threshold, bool? is_purge6_threshold_selected, int? purge7_threshold, bool? is_purge7_threshold_selected, int retry_count_cash_order_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int retry_count_alert, int countsClearRetries, int tCPTimeout, int sleepInterval, int cPMCommandWait, int cPMCommandSleep, string aANDCApplications1, string aANDCApplications2, string aANDCApplications3, string aANDCApplications4, string aANDCApplications5, int monitoring_Retries, int windowSwitch_Sleep, int appSwitch_Sleep, int monitoringCycle_Sleep, int cPMLogLevel, bool isDispenserRealTimeNotificationEnabled, bool isBNARealTimeNotificationEnabled, bool isCPMRealTimeNotificationEnabled, bool isReplenishmentRealTimeNotificationEnabled, bool isOutOfCashRealTimeNotificationEnabled, bool isDispenserMismatchRealTimeNotificationEnabled, bool isBNAMismatchRealTimeNotificationEnabled, bool isCPMMismatchRealTimeNotificationEnabled, bool isCounterExplodedRealTimeNotificationEnabled, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, string cpm_command, int? allowed_inactivity_period, string gl_number, decimal? card_captured_cost, decimal? escotting_cost, decimal? replenishment_cost, decimal? maintenance_cost, decimal? flm_call_out_cost, string description, bool? is_dff_generation_halt, string cit_atm_title, int? cheque_allowed_inactivity_period, int? bna_allowed_inactivity_period, int out_of_cash_threshold, int? no_of_dispensed_transactions_to_monitor, bool is_ej_enabled, bool is_counter_enabled, int priority, string longitude, string latitude, decimal? on_us_amount, decimal? not_on_us_amount, int? standard_order_type1, int? standard_order_type2, int? standard_order_type3, int? standard_order_type4, int? standard_order_type5, int? standard_order_type6, int? standard_order_type7, int protocol_type_id, byte current_mode, byte aggregate_state, DateTime? last_boot_time, DateTime? discovery_time, DateTime? last_scan_time, byte communication_status, bool is_critical, DateTime? current_mode_modified_on, DateTime? last_Notification_Received_On, DateTime? last_Notification_Time, decimal? normal_order_cost, decimal? emergency_order_cost, int? receipt_transaction_cutoff, bool? is_swap_default_replenishment, int? message_processor_id, string last_ping_status, DateTime? last_ping_executed_at, string last_telnet_status, DateTime? last_telnet_executed_at, DateTime? last_archive_file_received_at, bool is_sdm, string initEjExecTime, DateTime? ccmsagent_last_reported_heartbeat, DateTime? ccmsservicemanager_last_reported_heartbeat, int? distribution_port, string parser_rep_date_format, int? type1_min_notes_threshold, int? type2_min_notes_threshold, int? type3_min_notes_threshold, int? type4_min_notes_threshold, int? type1_suggested_notes_normal_days, int? type2_suggested_notes_normal_days, int? type3_suggested_notes_normal_days, int? type4_suggested_notes_normal_days, int? type5_suggested_notes_normal_days, int? type6_suggested_notes_normal_days, int? type7_suggested_notes_normal_days, int? type1_suggested_notes_salary_days, int? type2_suggested_notes_salary_days, int? type3_suggested_notes_salary_days, int? type4_suggested_notes_salary_days, int? type5_suggested_notes_salary_days, int? type6_suggested_notes_salary_days, int? type7_suggested_notes_salary_days, decimal? avg_dispensed, decimal? spare_cash, int? dispensing_behavior, decimal? avg_dispensed_salary_days, int? inactivity_period_salary_days, int? inactivity_period_normal_days, int? type1_min_notes_threshold_value, int? type2_min_notes_threshold_value, int? type3_min_notes_threshold_value, int? type4_min_notes_threshold_value, int? bna_allowed_inactivity_period_normal_days, int? bna_allowed_inactivity_period_salary_days, int? cheque_allowed_inactivity_period_normal_days, int? cheque_allowed_inactivity_period_salary_days, decimal? min_operating_balance_normal_days, decimal? min_operating_balance_salary_days, bool? is_order_auto_generated, bool? is_win7_machine, bool? is_branch_atm, bool? is_emirate_islamic, bool? is_itm, bool? is_bulk_cash_deposit, bool? is_combo, decimal? atm_cost, decimal? software_cost, decimal? network_cost, decimal? site_preparation_cost, decimal? security_infrastructure_cost, string im_branch_code, string im_en_id, string im_location, string im_business_area, string im_circle, int? cit_id, int? atm_bandwidth_id, int? atm_model_id, bool? is_recycler)
        {
            this.last_status_reply = last_status_reply;
            this.last_status_replyChanged = true;
            this.region_id = region_id;
            this.region_idChanged = true;
            this.title = title;
            this.titleChanged = true;
            this.iP = iP;
            this.iPChanged = true;
            this.port = port;
            this.portChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.atm_type = atm_type;
            this.atm_typeChanged = true;
            this.cassette1_capacity = cassette1_capacity;
            this.cassette1_capacityChanged = true;
            this.cassette1_denomination = cassette1_denomination;
            this.cassette1_denominationChanged = true;
            this.cassette2_capacity = cassette2_capacity;
            this.cassette2_capacityChanged = true;
            this.cassette2_denomination = cassette2_denomination;
            this.cassette2_denominationChanged = true;
            this.cassette3_denomination = cassette3_denomination;
            this.cassette3_denominationChanged = true;
            this.cassette3_capacity = cassette3_capacity;
            this.cassette3_capacityChanged = true;
            this.cassette4_denomination = cassette4_denomination;
            this.cassette4_denominationChanged = true;
            this.cassette4_capacity = cassette4_capacity;
            this.cassette4_capacityChanged = true;
            this.cassette5_denomination = cassette5_denomination;
            this.cassette5_denominationChanged = true;
            this.cassette5_capacity = cassette5_capacity;
            this.cassette5_capacityChanged = true;
            this.cassette6_denomination = cassette6_denomination;
            this.cassette6_denominationChanged = true;
            this.cassette6_capacity = cassette6_capacity;
            this.cassette6_capacityChanged = true;
            this.cassette7_denomination = cassette7_denomination;
            this.cassette7_denominationChanged = true;
            this.cassette7_capacity = cassette7_capacity;
            this.cassette7_capacityChanged = true;
            this.last_wincor_sent = last_wincor_sent;
            this.last_wincor_sentChanged = true;
            this.is_healthy = is_healthy;
            this.is_healthyChanged = true;
            this.location = location;
            this.locationChanged = true;
            this.address1 = address1;
            this.address1Changed = true;
            this.address2 = address2;
            this.address2Changed = true;
            this.city = city;
            this.cityChanged = true;
            this.country = country;
            this.countryChanged = true;
            this.zip_code = zip_code;
            this.zip_codeChanged = true;
            this.location_type = location_type;
            this.location_typeChanged = true;
            this.service_status = service_status;
            this.service_statusChanged = true;
            this.holiday_status = holiday_status;
            this.holiday_statusChanged = true;
            this.business_days = business_days;
            this.business_daysChanged = true;
            this.time_zone = time_zone;
            this.time_zoneChanged = true;
            this.max_notes_per_cassette = max_notes_per_cassette;
            this.max_notes_per_cassetteChanged = true;
            this.cassette1_split_percentage = cassette1_split_percentage;
            this.cassette1_split_percentageChanged = true;
            this.cassette2_split_percentage = cassette2_split_percentage;
            this.cassette2_split_percentageChanged = true;
            this.cassette3_split_percentage = cassette3_split_percentage;
            this.cassette3_split_percentageChanged = true;
            this.cassette4_split_percentage = cassette4_split_percentage;
            this.cassette4_split_percentageChanged = true;
            this.cassette5_split_percentage = cassette5_split_percentage;
            this.cassette5_split_percentageChanged = true;
            this.cassette6_split_percentage = cassette6_split_percentage;
            this.cassette6_split_percentageChanged = true;
            this.cassette7_split_percentage = cassette7_split_percentage;
            this.cassette7_split_percentageChanged = true;
            this.interest_rate = interest_rate;
            this.interest_rateChanged = true;
            this.insurance_rate = insurance_rate;
            this.insurance_rateChanged = true;
            this.max_holding_amount = max_holding_amount;
            this.max_holding_amountChanged = true;
            this.min_operating_balance = min_operating_balance;
            this.min_operating_balanceChanged = true;
            this.min_amount_for_normal_delivery = min_amount_for_normal_delivery;
            this.min_amount_for_normal_deliveryChanged = true;
            this.bank_cash_center_id = bank_cash_center_id;
            this.bank_cash_center_idChanged = true;
            this.cIT_cash_center_servicer = cIT_cash_center_servicer;
            this.cIT_cash_center_servicerChanged = true;
            this.depot_id = depot_id;
            this.depot_idChanged = true;
            this.secondary_depot_vault_id = secondary_depot_vault_id;
            this.secondary_depot_vault_idChanged = true;
            this.new_atm_scenario = new_atm_scenario;
            this.new_atm_scenarioChanged = true;
            this.cash_swap_days = cash_swap_days;
            this.cash_swap_daysChanged = true;
            this.mandatory_cash_swap_days = mandatory_cash_swap_days;
            this.mandatory_cash_swap_daysChanged = true;
            this.cash_swap_cycle = cash_swap_cycle;
            this.cash_swap_cycleChanged = true;
            this.cash_swap_lead_time = cash_swap_lead_time;
            this.cash_swap_lead_timeChanged = true;
            this.cash_swap_start_date = cash_swap_start_date;
            this.cash_swap_start_dateChanged = true;
            this.cash_swap_handling_cost = cash_swap_handling_cost;
            this.cash_swap_handling_costChanged = true;
            this.cash_swap_costs = cash_swap_costs;
            this.cash_swap_costsChanged = true;
            this.emergency_days = emergency_days;
            this.emergency_daysChanged = true;
            this.emergency_lead_time = emergency_lead_time;
            this.emergency_lead_timeChanged = true;
            this.emergency_cost = emergency_cost;
            this.emergency_costChanged = true;
            this.contact1_email = contact1_email;
            this.contact1_emailChanged = true;
            this.contact2_email = contact2_email;
            this.contact2_emailChanged = true;
            this.contact3_email = contact3_email;
            this.contact3_emailChanged = true;
            this.contact1_phone = contact1_phone;
            this.contact1_phoneChanged = true;
            this.contact2_phone = contact2_phone;
            this.contact2_phoneChanged = true;
            this.contact3_phone = contact3_phone;
            this.contact3_phoneChanged = true;
            this.effective_date = effective_date;
            this.effective_dateChanged = true;
            this.suspend_cash_order = suspend_cash_order;
            this.suspend_cash_orderChanged = true;
            this.is_atm = is_atm;
            this.is_atmChanged = true;
            this.is_cdm = is_cdm;
            this.is_cdmChanged = true;
            this.is_ccdm = is_ccdm;
            this.is_ccdmChanged = true;
            this.cdm_cassette1_capacity = cdm_cassette1_capacity;
            this.cdm_cassette1_capacityChanged = true;
            this.cdm_cassette2_capacity = cdm_cassette2_capacity;
            this.cdm_cassette2_capacityChanged = true;
            this.cdm_cassette3_capacity = cdm_cassette3_capacity;
            this.cdm_cassette3_capacityChanged = true;
            this.cdm_cassette4_capacity = cdm_cassette4_capacity;
            this.cdm_cassette4_capacityChanged = true;
            this.ccdm_cassette1_capacity = ccdm_cassette1_capacity;
            this.ccdm_cassette1_capacityChanged = true;
            this.ccdm_cassette2_capacity = ccdm_cassette2_capacity;
            this.ccdm_cassette2_capacityChanged = true;
            this.ccdm_cassette3_capacity = ccdm_cassette3_capacity;
            this.ccdm_cassette3_capacityChanged = true;
            this.ccdm_cassette4_capacity = ccdm_cassette4_capacity;
            this.ccdm_cassette4_capacityChanged = true;
            this.cdm_cassette1_threshold = cdm_cassette1_threshold;
            this.cdm_cassette1_thresholdChanged = true;
            this.cdm_cassette2_threshold = cdm_cassette2_threshold;
            this.cdm_cassette2_thresholdChanged = true;
            this.cdm_cassette3_threshold = cdm_cassette3_threshold;
            this.cdm_cassette3_thresholdChanged = true;
            this.cdm_cassette4_threshold = cdm_cassette4_threshold;
            this.cdm_cassette4_thresholdChanged = true;
            this.ccdm_cassette1_threshold = ccdm_cassette1_threshold;
            this.ccdm_cassette1_thresholdChanged = true;
            this.ccdm_cassette2_threshold = ccdm_cassette2_threshold;
            this.ccdm_cassette2_thresholdChanged = true;
            this.ccdm_cassette3_threshold = ccdm_cassette3_threshold;
            this.ccdm_cassette3_thresholdChanged = true;
            this.ccdm_cassette4_threshold = ccdm_cassette4_threshold;
            this.ccdm_cassette4_thresholdChanged = true;
            this.note_set_type_id = note_set_type_id;
            this.note_set_type_idChanged = true;
            this.ccdm_cassette5_capacity = ccdm_cassette5_capacity;
            this.ccdm_cassette5_capacityChanged = true;
            this.ccdm_cassette5_threshold = ccdm_cassette5_threshold;
            this.ccdm_cassette5_thresholdChanged = true;
            this.startup_sleep_interval = startup_sleep_interval;
            this.startup_sleep_intervalChanged = true;
            this.debug_level = debug_level;
            this.debug_levelChanged = true;
            this.exclude_dff = exclude_dff;
            this.exclude_dffChanged = true;
            this.purge1_threshold = purge1_threshold;
            this.purge1_thresholdChanged = true;
            this.is_purge1_threshold_selected = is_purge1_threshold_selected;
            this.is_purge1_threshold_selectedChanged = true;
            this.purge2_threshold = purge2_threshold;
            this.purge2_thresholdChanged = true;
            this.is_purge2_threshold_selected = is_purge2_threshold_selected;
            this.is_purge2_threshold_selectedChanged = true;
            this.purge3_threshold = purge3_threshold;
            this.purge3_thresholdChanged = true;
            this.is_purge3_threshold_selected = is_purge3_threshold_selected;
            this.is_purge3_threshold_selectedChanged = true;
            this.purge4_threshold = purge4_threshold;
            this.purge4_thresholdChanged = true;
            this.is_purge4_threshold_selected = is_purge4_threshold_selected;
            this.is_purge4_threshold_selectedChanged = true;
            this.purge5_threshold = purge5_threshold;
            this.purge5_thresholdChanged = true;
            this.is_purge5_threshold_selected = is_purge5_threshold_selected;
            this.is_purge5_threshold_selectedChanged = true;
            this.purge6_threshold = purge6_threshold;
            this.purge6_thresholdChanged = true;
            this.is_purge6_threshold_selected = is_purge6_threshold_selected;
            this.is_purge6_threshold_selectedChanged = true;
            this.purge7_threshold = purge7_threshold;
            this.purge7_thresholdChanged = true;
            this.is_purge7_threshold_selected = is_purge7_threshold_selected;
            this.is_purge7_threshold_selectedChanged = true;
            this.retry_count_cash_order_upload = retry_count_cash_order_upload;
            this.retry_count_cash_order_uploadChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.retry_count_counter_file = retry_count_counter_file;
            this.retry_count_counter_fileChanged = true;
            this.retry_count_restart_schedule = retry_count_restart_schedule;
            this.retry_count_restart_scheduleChanged = true;
            this.retry_count_datetime_schedule = retry_count_datetime_schedule;
            this.retry_count_datetime_scheduleChanged = true;
            this.retry_count_alert = retry_count_alert;
            this.retry_count_alertChanged = true;
            this.countsClearRetries = countsClearRetries;
            this.countsClearRetriesChanged = true;
            this.tCPTimeout = tCPTimeout;
            this.tCPTimeoutChanged = true;
            this.sleepInterval = sleepInterval;
            this.sleepIntervalChanged = true;
            this.cPMCommandWait = cPMCommandWait;
            this.cPMCommandWaitChanged = true;
            this.cPMCommandSleep = cPMCommandSleep;
            this.cPMCommandSleepChanged = true;
            this.aANDCApplications1 = aANDCApplications1;
            this.aANDCApplications1Changed = true;
            this.aANDCApplications2 = aANDCApplications2;
            this.aANDCApplications2Changed = true;
            this.aANDCApplications3 = aANDCApplications3;
            this.aANDCApplications3Changed = true;
            this.aANDCApplications4 = aANDCApplications4;
            this.aANDCApplications4Changed = true;
            this.aANDCApplications5 = aANDCApplications5;
            this.aANDCApplications5Changed = true;
            this.monitoring_Retries = monitoring_Retries;
            this.monitoring_RetriesChanged = true;
            this.windowSwitch_Sleep = windowSwitch_Sleep;
            this.windowSwitch_SleepChanged = true;
            this.appSwitch_Sleep = appSwitch_Sleep;
            this.appSwitch_SleepChanged = true;
            this.monitoringCycle_Sleep = monitoringCycle_Sleep;
            this.monitoringCycle_SleepChanged = true;
            this.cPMLogLevel = cPMLogLevel;
            this.cPMLogLevelChanged = true;
            this.isDispenserRealTimeNotificationEnabled = isDispenserRealTimeNotificationEnabled;
            this.isDispenserRealTimeNotificationEnabledChanged = true;
            this.isBNARealTimeNotificationEnabled = isBNARealTimeNotificationEnabled;
            this.isBNARealTimeNotificationEnabledChanged = true;
            this.isCPMRealTimeNotificationEnabled = isCPMRealTimeNotificationEnabled;
            this.isCPMRealTimeNotificationEnabledChanged = true;
            this.isReplenishmentRealTimeNotificationEnabled = isReplenishmentRealTimeNotificationEnabled;
            this.isReplenishmentRealTimeNotificationEnabledChanged = true;
            this.isOutOfCashRealTimeNotificationEnabled = isOutOfCashRealTimeNotificationEnabled;
            this.isOutOfCashRealTimeNotificationEnabledChanged = true;
            this.isDispenserMismatchRealTimeNotificationEnabled = isDispenserMismatchRealTimeNotificationEnabled;
            this.isDispenserMismatchRealTimeNotificationEnabledChanged = true;
            this.isBNAMismatchRealTimeNotificationEnabled = isBNAMismatchRealTimeNotificationEnabled;
            this.isBNAMismatchRealTimeNotificationEnabledChanged = true;
            this.isCPMMismatchRealTimeNotificationEnabled = isCPMMismatchRealTimeNotificationEnabled;
            this.isCPMMismatchRealTimeNotificationEnabledChanged = true;
            this.isCounterExplodedRealTimeNotificationEnabled = isCounterExplodedRealTimeNotificationEnabled;
            this.isCounterExplodedRealTimeNotificationEnabledChanged = true;
            this.type1MinimumNotes = type1MinimumNotes;
            this.type1MinimumNotesChanged = true;
            this.type2MinimumNotes = type2MinimumNotes;
            this.type2MinimumNotesChanged = true;
            this.type3MinimumNotes = type3MinimumNotes;
            this.type3MinimumNotesChanged = true;
            this.type4MinimumNotes = type4MinimumNotes;
            this.type4MinimumNotesChanged = true;
            this.type5MinimumNotes = type5MinimumNotes;
            this.type5MinimumNotesChanged = true;
            this.type6MinimumNotes = type6MinimumNotes;
            this.type6MinimumNotesChanged = true;
            this.type7MinimumNotes = type7MinimumNotes;
            this.type7MinimumNotesChanged = true;
            this.cpm_command = cpm_command;
            this.cpm_commandChanged = true;
            this.allowed_inactivity_period = allowed_inactivity_period;
            this.allowed_inactivity_periodChanged = true;
            this.gl_number = gl_number;
            this.gl_numberChanged = true;
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
            this.description = description;
            this.descriptionChanged = true;
            this.is_dff_generation_halt = is_dff_generation_halt;
            this.is_dff_generation_haltChanged = true;
            this.cit_atm_title = cit_atm_title;
            this.cit_atm_titleChanged = true;
            this.cheque_allowed_inactivity_period = cheque_allowed_inactivity_period;
            this.cheque_allowed_inactivity_periodChanged = true;
            this.bna_allowed_inactivity_period = bna_allowed_inactivity_period;
            this.bna_allowed_inactivity_periodChanged = true;
            this.out_of_cash_threshold = out_of_cash_threshold;
            this.out_of_cash_thresholdChanged = true;
            this.no_of_dispensed_transactions_to_monitor = no_of_dispensed_transactions_to_monitor;
            this.no_of_dispensed_transactions_to_monitorChanged = true;
            this.is_ej_enabled = is_ej_enabled;
            this.is_ej_enabledChanged = true;
            this.is_counter_enabled = is_counter_enabled;
            this.is_counter_enabledChanged = true;
            this.priority = priority;
            this.priorityChanged = true;
            this.longitude = longitude;
            this.longitudeChanged = true;
            this.latitude = latitude;
            this.latitudeChanged = true;
            this.on_us_amount = on_us_amount;
            this.on_us_amountChanged = true;
            this.not_on_us_amount = not_on_us_amount;
            this.not_on_us_amountChanged = true;
            this.standard_order_type1 = standard_order_type1;
            this.standard_order_type1Changed = true;
            this.standard_order_type2 = standard_order_type2;
            this.standard_order_type2Changed = true;
            this.standard_order_type3 = standard_order_type3;
            this.standard_order_type3Changed = true;
            this.standard_order_type4 = standard_order_type4;
            this.standard_order_type4Changed = true;
            this.standard_order_type5 = standard_order_type5;
            this.standard_order_type5Changed = true;
            this.standard_order_type6 = standard_order_type6;
            this.standard_order_type6Changed = true;
            this.standard_order_type7 = standard_order_type7;
            this.standard_order_type7Changed = true;
            this.protocol_type_id = protocol_type_id;
            this.protocol_type_idChanged = true;
            this.current_mode = current_mode;
            this.current_modeChanged = true;
            this.aggregate_state = aggregate_state;
            this.aggregate_stateChanged = true;
            this.last_boot_time = last_boot_time;
            this.last_boot_timeChanged = true;
            this.discovery_time = discovery_time;
            this.discovery_timeChanged = true;
            this.last_scan_time = last_scan_time;
            this.last_scan_timeChanged = true;
            this.communication_status = communication_status;
            this.communication_statusChanged = true;
            this.is_critical = is_critical;
            this.is_criticalChanged = true;
            this.current_mode_modified_on = current_mode_modified_on;
            this.current_mode_modified_onChanged = true;
            this.last_Notification_Received_On = last_Notification_Received_On;
            this.last_Notification_Received_OnChanged = true;
            this.last_Notification_Time = last_Notification_Time;
            this.last_Notification_TimeChanged = true;
            this.normal_order_cost = normal_order_cost;
            this.normal_order_costChanged = true;
            this.emergency_order_cost = emergency_order_cost;
            this.emergency_order_costChanged = true;
            this.receipt_transaction_cutoff = receipt_transaction_cutoff;
            this.receipt_transaction_cutoffChanged = true;
            this.is_swap_default_replenishment = is_swap_default_replenishment;
            this.is_swap_default_replenishmentChanged = true;
            this.message_processor_id = message_processor_id;
            this.message_processor_idChanged = true;
            this.last_ping_status = last_ping_status;
            this.last_ping_statusChanged = true;
            this.last_ping_executed_at = last_ping_executed_at;
            this.last_ping_executed_atChanged = true;
            this.last_telnet_status = last_telnet_status;
            this.last_telnet_statusChanged = true;
            this.last_telnet_executed_at = last_telnet_executed_at;
            this.last_telnet_executed_atChanged = true;
            this.last_archive_file_received_at = last_archive_file_received_at;
            this.last_archive_file_received_atChanged = true;
            this.is_sdm = is_sdm;
            this.is_sdmChanged = true;
            this.initEjExecTime = initEjExecTime;
            this.initEjExecTimeChanged = true;
            this.ccmsagent_last_reported_heartbeat = ccmsagent_last_reported_heartbeat;
            this.ccmsagent_last_reported_heartbeatChanged = true;
            this.ccmsservicemanager_last_reported_heartbeat = ccmsservicemanager_last_reported_heartbeat;
            this.ccmsservicemanager_last_reported_heartbeatChanged = true;
            this.distribution_port = distribution_port;
            this.distribution_portChanged = true;
            this.parser_rep_date_format = parser_rep_date_format;
            this.parser_rep_date_formatChanged = true;
            this.type1_min_notes_threshold = type1_min_notes_threshold;
            this.type1_min_notes_thresholdChanged = true;
            this.type2_min_notes_threshold = type2_min_notes_threshold;
            this.type2_min_notes_thresholdChanged = true;
            this.type3_min_notes_threshold = type3_min_notes_threshold;
            this.type3_min_notes_thresholdChanged = true;
            this.type4_min_notes_threshold = type4_min_notes_threshold;
            this.type4_min_notes_thresholdChanged = true;
            this.type1_suggested_notes_normal_days = type1_suggested_notes_normal_days;
            this.type1_suggested_notes_normal_daysChanged = true;
            this.type2_suggested_notes_normal_days = type2_suggested_notes_normal_days;
            this.type2_suggested_notes_normal_daysChanged = true;
            this.type3_suggested_notes_normal_days = type3_suggested_notes_normal_days;
            this.type3_suggested_notes_normal_daysChanged = true;
            this.type4_suggested_notes_normal_days = type4_suggested_notes_normal_days;
            this.type4_suggested_notes_normal_daysChanged = true;
            this.type5_suggested_notes_normal_days = type5_suggested_notes_normal_days;
            this.type5_suggested_notes_normal_daysChanged = true;
            this.type6_suggested_notes_normal_days = type6_suggested_notes_normal_days;
            this.type6_suggested_notes_normal_daysChanged = true;
            this.type7_suggested_notes_normal_days = type7_suggested_notes_normal_days;
            this.type7_suggested_notes_normal_daysChanged = true;
            this.type1_suggested_notes_salary_days = type1_suggested_notes_salary_days;
            this.type1_suggested_notes_salary_daysChanged = true;
            this.type2_suggested_notes_salary_days = type2_suggested_notes_salary_days;
            this.type2_suggested_notes_salary_daysChanged = true;
            this.type3_suggested_notes_salary_days = type3_suggested_notes_salary_days;
            this.type3_suggested_notes_salary_daysChanged = true;
            this.type4_suggested_notes_salary_days = type4_suggested_notes_salary_days;
            this.type4_suggested_notes_salary_daysChanged = true;
            this.type5_suggested_notes_salary_days = type5_suggested_notes_salary_days;
            this.type5_suggested_notes_salary_daysChanged = true;
            this.type6_suggested_notes_salary_days = type6_suggested_notes_salary_days;
            this.type6_suggested_notes_salary_daysChanged = true;
            this.type7_suggested_notes_salary_days = type7_suggested_notes_salary_days;
            this.type7_suggested_notes_salary_daysChanged = true;
            this.avg_dispensed = avg_dispensed;
            this.avg_dispensedChanged = true;
            this.spare_cash = spare_cash;
            this.spare_cashChanged = true;
            this.dispensing_behavior = dispensing_behavior;
            this.dispensing_behaviorChanged = true;
            this.avg_dispensed_salary_days = avg_dispensed_salary_days;
            this.avg_dispensed_salary_daysChanged = true;
            this.inactivity_period_salary_days = inactivity_period_salary_days;
            this.inactivity_period_salary_daysChanged = true;
            this.inactivity_period_normal_days = inactivity_period_normal_days;
            this.inactivity_period_normal_daysChanged = true;
            this.type1_min_notes_threshold_value = type1_min_notes_threshold_value;
            this.type1_min_notes_threshold_valueChanged = true;
            this.type2_min_notes_threshold_value = type2_min_notes_threshold_value;
            this.type2_min_notes_threshold_valueChanged = true;
            this.type3_min_notes_threshold_value = type3_min_notes_threshold_value;
            this.type3_min_notes_threshold_valueChanged = true;
            this.type4_min_notes_threshold_value = type4_min_notes_threshold_value;
            this.type4_min_notes_threshold_valueChanged = true;
            this.bna_allowed_inactivity_period_normal_days = bna_allowed_inactivity_period_normal_days;
            this.bna_allowed_inactivity_period_normal_daysChanged = true;
            this.bna_allowed_inactivity_period_salary_days = bna_allowed_inactivity_period_salary_days;
            this.bna_allowed_inactivity_period_salary_daysChanged = true;
            this.cheque_allowed_inactivity_period_normal_days = cheque_allowed_inactivity_period_normal_days;
            this.cheque_allowed_inactivity_period_normal_daysChanged = true;
            this.cheque_allowed_inactivity_period_salary_days = cheque_allowed_inactivity_period_salary_days;
            this.cheque_allowed_inactivity_period_salary_daysChanged = true;
            this.min_operating_balance_normal_days = min_operating_balance_normal_days;
            this.min_operating_balance_normal_daysChanged = true;
            this.min_operating_balance_salary_days = min_operating_balance_salary_days;
            this.min_operating_balance_salary_daysChanged = true;
            this.is_order_auto_generated = is_order_auto_generated;
            this.is_order_auto_generatedChanged = true;
            this.is_win7_machine = is_win7_machine;
            this.is_win7_machineChanged = true;
            this.is_branch_atm = is_branch_atm;
            this.is_branch_atmChanged = true;
            this.is_emirate_islamic = is_emirate_islamic;
            this.is_emirate_islamicChanged = true;
            this.is_itm = is_itm;
            this.is_itmChanged = true;
            this.is_bulk_cash_deposit = is_bulk_cash_deposit;
            this.is_bulk_cash_depositChanged = true;
            this.is_combo = is_combo;
            this.is_comboChanged = true;
            this.atm_cost = atm_cost;
            this.atm_costChanged = true;
            this.software_cost = software_cost;
            this.software_costChanged = true;
            this.network_cost = network_cost;
            this.network_costChanged = true;
            this.site_preparation_cost = site_preparation_cost;
            this.site_preparation_costChanged = true;
            this.security_infrastructure_cost = security_infrastructure_cost;
            this.security_infrastructure_costChanged = true;
            this.im_branch_code = im_branch_code;
            this.im_branch_codeChanged = true;
            this.im_en_id = im_en_id;
            this.im_en_idChanged = true;
            this.im_location = im_location;
            this.im_locationChanged = true;
            this.im_business_area = im_business_area;
            this.im_business_areaChanged = true;
            this.im_circle = im_circle;
            this.im_circleChanged = true;
            this.cit_id = cit_id;
            this.cit_idChanged = true;
            this.atm_bandwidth_id = atm_bandwidth_id;
            this.atm_bandwidth_idChanged = true;
            this.atm_model_id = atm_model_id;
            this.atm_model_idChanged = true;
            this.is_recycler = is_recycler;
            this.is_recyclerChanged = true;
        }
        private Atm(int aTM_id, string last_status_reply, int region_id, string title, string iP, int port, int? modified_by, int created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, DateTime last_wincor_sent, bool is_healthy, string location, string address1, string address2, string city, string country, string zip_code, string location_type, string service_status, string holiday_status, string business_days, int? time_zone, int? max_notes_per_cassette, int? cassette1_split_percentage, int? cassette2_split_percentage, int? cassette3_split_percentage, int? cassette4_split_percentage, int? cassette5_split_percentage, int? cassette6_split_percentage, int? cassette7_split_percentage, decimal? interest_rate, decimal? insurance_rate, decimal? max_holding_amount, decimal? min_operating_balance, decimal? min_amount_for_normal_delivery, string bank_cash_center_id, string cIT_cash_center_servicer, string depot_id, string secondary_depot_vault_id, string new_atm_scenario, string cash_swap_days, string mandatory_cash_swap_days, int? cash_swap_cycle, int? cash_swap_lead_time, DateTime? cash_swap_start_date, decimal? cash_swap_handling_cost, decimal? cash_swap_costs, string emergency_days, int? emergency_lead_time, decimal? emergency_cost, string contact1_email, string contact2_email, string contact3_email, string contact1_phone, string contact2_phone, string contact3_phone, DateTime? effective_date, bool suspend_cash_order, bool? is_atm, bool? is_cdm, bool? is_ccdm, int? cdm_cassette1_capacity, int? cdm_cassette2_capacity, int? cdm_cassette3_capacity, int? cdm_cassette4_capacity, int? ccdm_cassette1_capacity, int? ccdm_cassette2_capacity, int? ccdm_cassette3_capacity, int? ccdm_cassette4_capacity, int? cdm_cassette1_threshold, int? cdm_cassette2_threshold, int? cdm_cassette3_threshold, int? cdm_cassette4_threshold, int? ccdm_cassette1_threshold, int? ccdm_cassette2_threshold, int? ccdm_cassette3_threshold, int? ccdm_cassette4_threshold, int note_set_type_id, int? ccdm_cassette5_capacity, int? ccdm_cassette5_threshold, int? startup_sleep_interval, byte? debug_level, bool? exclude_dff, int? purge1_threshold, bool? is_purge1_threshold_selected, int? purge2_threshold, bool? is_purge2_threshold_selected, int? purge3_threshold, bool? is_purge3_threshold_selected, int? purge4_threshold, bool? is_purge4_threshold_selected, int? purge5_threshold, bool? is_purge5_threshold_selected, int? purge6_threshold, bool? is_purge6_threshold_selected, int? purge7_threshold, bool? is_purge7_threshold_selected, int retry_count_cash_order_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int retry_count_alert, int countsClearRetries, int tCPTimeout, int sleepInterval, int cPMCommandWait, int cPMCommandSleep, string aANDCApplications1, string aANDCApplications2, string aANDCApplications3, string aANDCApplications4, string aANDCApplications5, int monitoring_Retries, int windowSwitch_Sleep, int appSwitch_Sleep, int monitoringCycle_Sleep, int cPMLogLevel, bool isDispenserRealTimeNotificationEnabled, bool isBNARealTimeNotificationEnabled, bool isCPMRealTimeNotificationEnabled, bool isReplenishmentRealTimeNotificationEnabled, bool isOutOfCashRealTimeNotificationEnabled, bool isDispenserMismatchRealTimeNotificationEnabled, bool isBNAMismatchRealTimeNotificationEnabled, bool isCPMMismatchRealTimeNotificationEnabled, bool isCounterExplodedRealTimeNotificationEnabled, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, string cpm_command, int? allowed_inactivity_period, string gl_number, decimal? card_captured_cost, decimal? escotting_cost, decimal? replenishment_cost, decimal? maintenance_cost, decimal? flm_call_out_cost, string description, bool? is_dff_generation_halt, string cit_atm_title, int? cheque_allowed_inactivity_period, int? bna_allowed_inactivity_period, int out_of_cash_threshold, int? no_of_dispensed_transactions_to_monitor, bool is_ej_enabled, bool is_counter_enabled, int priority, string longitude, string latitude, decimal? on_us_amount, decimal? not_on_us_amount, int? standard_order_type1, int? standard_order_type2, int? standard_order_type3, int? standard_order_type4, int? standard_order_type5, int? standard_order_type6, int? standard_order_type7, int protocol_type_id, byte current_mode, byte aggregate_state, DateTime? last_boot_time, DateTime? discovery_time, DateTime? last_scan_time, byte communication_status, bool is_critical, DateTime? current_mode_modified_on, DateTime? last_Notification_Received_On, DateTime? last_Notification_Time, decimal? normal_order_cost, decimal? emergency_order_cost, int? receipt_transaction_cutoff, bool? is_swap_default_replenishment, int? message_processor_id, string last_ping_status, DateTime? last_ping_executed_at, string last_telnet_status, DateTime? last_telnet_executed_at, DateTime? last_archive_file_received_at, bool is_sdm, string initEjExecTime, DateTime? ccmsagent_last_reported_heartbeat, DateTime? ccmsservicemanager_last_reported_heartbeat, int? distribution_port, string parser_rep_date_format, int? type1_min_notes_threshold, int? type2_min_notes_threshold, int? type3_min_notes_threshold, int? type4_min_notes_threshold, int? type1_suggested_notes_normal_days, int? type2_suggested_notes_normal_days, int? type3_suggested_notes_normal_days, int? type4_suggested_notes_normal_days, int? type5_suggested_notes_normal_days, int? type6_suggested_notes_normal_days, int? type7_suggested_notes_normal_days, int? type1_suggested_notes_salary_days, int? type2_suggested_notes_salary_days, int? type3_suggested_notes_salary_days, int? type4_suggested_notes_salary_days, int? type5_suggested_notes_salary_days, int? type6_suggested_notes_salary_days, int? type7_suggested_notes_salary_days, decimal? avg_dispensed, decimal? spare_cash, int? dispensing_behavior, decimal? avg_dispensed_salary_days, int? inactivity_period_salary_days, int? inactivity_period_normal_days, int? type1_min_notes_threshold_value, int? type2_min_notes_threshold_value, int? type3_min_notes_threshold_value, int? type4_min_notes_threshold_value, int? bna_allowed_inactivity_period_normal_days, int? bna_allowed_inactivity_period_salary_days, int? cheque_allowed_inactivity_period_normal_days, int? cheque_allowed_inactivity_period_salary_days, decimal? min_operating_balance_normal_days, decimal? min_operating_balance_salary_days, bool? is_order_auto_generated, bool? is_win7_machine, bool? is_branch_atm, bool? is_emirate_islamic, bool? is_itm, bool? is_bulk_cash_deposit, bool? is_combo, decimal? atm_cost, decimal? software_cost, decimal? network_cost, decimal? site_preparation_cost, decimal? security_infrastructure_cost, string im_branch_code, string im_en_id, string im_location, string im_business_area, string im_circle, int? cit_id, int? atm_bandwidth_id, int? atm_model_id, bool? is_recycler)
        {
            this.aTM_id = aTM_id;
            this.aTM_idChanged = true;
            this.last_status_reply = last_status_reply;
            this.last_status_replyChanged = true;
            this.region_id = region_id;
            this.region_idChanged = true;
            this.title = title;
            this.titleChanged = true;
            this.iP = iP;
            this.iPChanged = true;
            this.port = port;
            this.portChanged = true;
            this.modified_by = modified_by;
            this.modified_byChanged = true;
            this.created_by = created_by;
            this.created_byChanged = true;
            this.is_active = is_active;
            this.is_activeChanged = true;
            this.creation_time = creation_time;
            this.creation_timeChanged = true;
            this.atm_type = atm_type;
            this.atm_typeChanged = true;
            this.cassette1_capacity = cassette1_capacity;
            this.cassette1_capacityChanged = true;
            this.cassette1_denomination = cassette1_denomination;
            this.cassette1_denominationChanged = true;
            this.cassette2_capacity = cassette2_capacity;
            this.cassette2_capacityChanged = true;
            this.cassette2_denomination = cassette2_denomination;
            this.cassette2_denominationChanged = true;
            this.cassette3_denomination = cassette3_denomination;
            this.cassette3_denominationChanged = true;
            this.cassette3_capacity = cassette3_capacity;
            this.cassette3_capacityChanged = true;
            this.cassette4_denomination = cassette4_denomination;
            this.cassette4_denominationChanged = true;
            this.cassette4_capacity = cassette4_capacity;
            this.cassette4_capacityChanged = true;
            this.cassette5_denomination = cassette5_denomination;
            this.cassette5_denominationChanged = true;
            this.cassette5_capacity = cassette5_capacity;
            this.cassette5_capacityChanged = true;
            this.cassette6_denomination = cassette6_denomination;
            this.cassette6_denominationChanged = true;
            this.cassette6_capacity = cassette6_capacity;
            this.cassette6_capacityChanged = true;
            this.cassette7_denomination = cassette7_denomination;
            this.cassette7_denominationChanged = true;
            this.cassette7_capacity = cassette7_capacity;
            this.cassette7_capacityChanged = true;
            this.last_wincor_sent = last_wincor_sent;
            this.last_wincor_sentChanged = true;
            this.is_healthy = is_healthy;
            this.is_healthyChanged = true;
            this.location = location;
            this.locationChanged = true;
            this.address1 = address1;
            this.address1Changed = true;
            this.address2 = address2;
            this.address2Changed = true;
            this.city = city;
            this.cityChanged = true;
            this.country = country;
            this.countryChanged = true;
            this.zip_code = zip_code;
            this.zip_codeChanged = true;
            this.location_type = location_type;
            this.location_typeChanged = true;
            this.service_status = service_status;
            this.service_statusChanged = true;
            this.holiday_status = holiday_status;
            this.holiday_statusChanged = true;
            this.business_days = business_days;
            this.business_daysChanged = true;
            this.time_zone = time_zone;
            this.time_zoneChanged = true;
            this.max_notes_per_cassette = max_notes_per_cassette;
            this.max_notes_per_cassetteChanged = true;
            this.cassette1_split_percentage = cassette1_split_percentage;
            this.cassette1_split_percentageChanged = true;
            this.cassette2_split_percentage = cassette2_split_percentage;
            this.cassette2_split_percentageChanged = true;
            this.cassette3_split_percentage = cassette3_split_percentage;
            this.cassette3_split_percentageChanged = true;
            this.cassette4_split_percentage = cassette4_split_percentage;
            this.cassette4_split_percentageChanged = true;
            this.cassette5_split_percentage = cassette5_split_percentage;
            this.cassette5_split_percentageChanged = true;
            this.cassette6_split_percentage = cassette6_split_percentage;
            this.cassette6_split_percentageChanged = true;
            this.cassette7_split_percentage = cassette7_split_percentage;
            this.cassette7_split_percentageChanged = true;
            this.interest_rate = interest_rate;
            this.interest_rateChanged = true;
            this.insurance_rate = insurance_rate;
            this.insurance_rateChanged = true;
            this.max_holding_amount = max_holding_amount;
            this.max_holding_amountChanged = true;
            this.min_operating_balance = min_operating_balance;
            this.min_operating_balanceChanged = true;
            this.min_amount_for_normal_delivery = min_amount_for_normal_delivery;
            this.min_amount_for_normal_deliveryChanged = true;
            this.bank_cash_center_id = bank_cash_center_id;
            this.bank_cash_center_idChanged = true;
            this.cIT_cash_center_servicer = cIT_cash_center_servicer;
            this.cIT_cash_center_servicerChanged = true;
            this.depot_id = depot_id;
            this.depot_idChanged = true;
            this.secondary_depot_vault_id = secondary_depot_vault_id;
            this.secondary_depot_vault_idChanged = true;
            this.new_atm_scenario = new_atm_scenario;
            this.new_atm_scenarioChanged = true;
            this.cash_swap_days = cash_swap_days;
            this.cash_swap_daysChanged = true;
            this.mandatory_cash_swap_days = mandatory_cash_swap_days;
            this.mandatory_cash_swap_daysChanged = true;
            this.cash_swap_cycle = cash_swap_cycle;
            this.cash_swap_cycleChanged = true;
            this.cash_swap_lead_time = cash_swap_lead_time;
            this.cash_swap_lead_timeChanged = true;
            this.cash_swap_start_date = cash_swap_start_date;
            this.cash_swap_start_dateChanged = true;
            this.cash_swap_handling_cost = cash_swap_handling_cost;
            this.cash_swap_handling_costChanged = true;
            this.cash_swap_costs = cash_swap_costs;
            this.cash_swap_costsChanged = true;
            this.emergency_days = emergency_days;
            this.emergency_daysChanged = true;
            this.emergency_lead_time = emergency_lead_time;
            this.emergency_lead_timeChanged = true;
            this.emergency_cost = emergency_cost;
            this.emergency_costChanged = true;
            this.contact1_email = contact1_email;
            this.contact1_emailChanged = true;
            this.contact2_email = contact2_email;
            this.contact2_emailChanged = true;
            this.contact3_email = contact3_email;
            this.contact3_emailChanged = true;
            this.contact1_phone = contact1_phone;
            this.contact1_phoneChanged = true;
            this.contact2_phone = contact2_phone;
            this.contact2_phoneChanged = true;
            this.contact3_phone = contact3_phone;
            this.contact3_phoneChanged = true;
            this.effective_date = effective_date;
            this.effective_dateChanged = true;
            this.suspend_cash_order = suspend_cash_order;
            this.suspend_cash_orderChanged = true;
            this.is_atm = is_atm;
            this.is_atmChanged = true;
            this.is_cdm = is_cdm;
            this.is_cdmChanged = true;
            this.is_ccdm = is_ccdm;
            this.is_ccdmChanged = true;
            this.cdm_cassette1_capacity = cdm_cassette1_capacity;
            this.cdm_cassette1_capacityChanged = true;
            this.cdm_cassette2_capacity = cdm_cassette2_capacity;
            this.cdm_cassette2_capacityChanged = true;
            this.cdm_cassette3_capacity = cdm_cassette3_capacity;
            this.cdm_cassette3_capacityChanged = true;
            this.cdm_cassette4_capacity = cdm_cassette4_capacity;
            this.cdm_cassette4_capacityChanged = true;
            this.ccdm_cassette1_capacity = ccdm_cassette1_capacity;
            this.ccdm_cassette1_capacityChanged = true;
            this.ccdm_cassette2_capacity = ccdm_cassette2_capacity;
            this.ccdm_cassette2_capacityChanged = true;
            this.ccdm_cassette3_capacity = ccdm_cassette3_capacity;
            this.ccdm_cassette3_capacityChanged = true;
            this.ccdm_cassette4_capacity = ccdm_cassette4_capacity;
            this.ccdm_cassette4_capacityChanged = true;
            this.cdm_cassette1_threshold = cdm_cassette1_threshold;
            this.cdm_cassette1_thresholdChanged = true;
            this.cdm_cassette2_threshold = cdm_cassette2_threshold;
            this.cdm_cassette2_thresholdChanged = true;
            this.cdm_cassette3_threshold = cdm_cassette3_threshold;
            this.cdm_cassette3_thresholdChanged = true;
            this.cdm_cassette4_threshold = cdm_cassette4_threshold;
            this.cdm_cassette4_thresholdChanged = true;
            this.ccdm_cassette1_threshold = ccdm_cassette1_threshold;
            this.ccdm_cassette1_thresholdChanged = true;
            this.ccdm_cassette2_threshold = ccdm_cassette2_threshold;
            this.ccdm_cassette2_thresholdChanged = true;
            this.ccdm_cassette3_threshold = ccdm_cassette3_threshold;
            this.ccdm_cassette3_thresholdChanged = true;
            this.ccdm_cassette4_threshold = ccdm_cassette4_threshold;
            this.ccdm_cassette4_thresholdChanged = true;
            this.note_set_type_id = note_set_type_id;
            this.note_set_type_idChanged = true;
            this.ccdm_cassette5_capacity = ccdm_cassette5_capacity;
            this.ccdm_cassette5_capacityChanged = true;
            this.ccdm_cassette5_threshold = ccdm_cassette5_threshold;
            this.ccdm_cassette5_thresholdChanged = true;
            this.startup_sleep_interval = startup_sleep_interval;
            this.startup_sleep_intervalChanged = true;
            this.debug_level = debug_level;
            this.debug_levelChanged = true;
            this.exclude_dff = exclude_dff;
            this.exclude_dffChanged = true;
            this.purge1_threshold = purge1_threshold;
            this.purge1_thresholdChanged = true;
            this.is_purge1_threshold_selected = is_purge1_threshold_selected;
            this.is_purge1_threshold_selectedChanged = true;
            this.purge2_threshold = purge2_threshold;
            this.purge2_thresholdChanged = true;
            this.is_purge2_threshold_selected = is_purge2_threshold_selected;
            this.is_purge2_threshold_selectedChanged = true;
            this.purge3_threshold = purge3_threshold;
            this.purge3_thresholdChanged = true;
            this.is_purge3_threshold_selected = is_purge3_threshold_selected;
            this.is_purge3_threshold_selectedChanged = true;
            this.purge4_threshold = purge4_threshold;
            this.purge4_thresholdChanged = true;
            this.is_purge4_threshold_selected = is_purge4_threshold_selected;
            this.is_purge4_threshold_selectedChanged = true;
            this.purge5_threshold = purge5_threshold;
            this.purge5_thresholdChanged = true;
            this.is_purge5_threshold_selected = is_purge5_threshold_selected;
            this.is_purge5_threshold_selectedChanged = true;
            this.purge6_threshold = purge6_threshold;
            this.purge6_thresholdChanged = true;
            this.is_purge6_threshold_selected = is_purge6_threshold_selected;
            this.is_purge6_threshold_selectedChanged = true;
            this.purge7_threshold = purge7_threshold;
            this.purge7_thresholdChanged = true;
            this.is_purge7_threshold_selected = is_purge7_threshold_selected;
            this.is_purge7_threshold_selectedChanged = true;
            this.retry_count_cash_order_upload = retry_count_cash_order_upload;
            this.retry_count_cash_order_uploadChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.retry_count_counter_file = retry_count_counter_file;
            this.retry_count_counter_fileChanged = true;
            this.retry_count_restart_schedule = retry_count_restart_schedule;
            this.retry_count_restart_scheduleChanged = true;
            this.retry_count_datetime_schedule = retry_count_datetime_schedule;
            this.retry_count_datetime_scheduleChanged = true;
            this.retry_count_alert = retry_count_alert;
            this.retry_count_alertChanged = true;
            this.countsClearRetries = countsClearRetries;
            this.countsClearRetriesChanged = true;
            this.tCPTimeout = tCPTimeout;
            this.tCPTimeoutChanged = true;
            this.sleepInterval = sleepInterval;
            this.sleepIntervalChanged = true;
            this.cPMCommandWait = cPMCommandWait;
            this.cPMCommandWaitChanged = true;
            this.cPMCommandSleep = cPMCommandSleep;
            this.cPMCommandSleepChanged = true;
            this.aANDCApplications1 = aANDCApplications1;
            this.aANDCApplications1Changed = true;
            this.aANDCApplications2 = aANDCApplications2;
            this.aANDCApplications2Changed = true;
            this.aANDCApplications3 = aANDCApplications3;
            this.aANDCApplications3Changed = true;
            this.aANDCApplications4 = aANDCApplications4;
            this.aANDCApplications4Changed = true;
            this.aANDCApplications5 = aANDCApplications5;
            this.aANDCApplications5Changed = true;
            this.monitoring_Retries = monitoring_Retries;
            this.monitoring_RetriesChanged = true;
            this.windowSwitch_Sleep = windowSwitch_Sleep;
            this.windowSwitch_SleepChanged = true;
            this.appSwitch_Sleep = appSwitch_Sleep;
            this.appSwitch_SleepChanged = true;
            this.monitoringCycle_Sleep = monitoringCycle_Sleep;
            this.monitoringCycle_SleepChanged = true;
            this.cPMLogLevel = cPMLogLevel;
            this.cPMLogLevelChanged = true;
            this.isDispenserRealTimeNotificationEnabled = isDispenserRealTimeNotificationEnabled;
            this.isDispenserRealTimeNotificationEnabledChanged = true;
            this.isBNARealTimeNotificationEnabled = isBNARealTimeNotificationEnabled;
            this.isBNARealTimeNotificationEnabledChanged = true;
            this.isCPMRealTimeNotificationEnabled = isCPMRealTimeNotificationEnabled;
            this.isCPMRealTimeNotificationEnabledChanged = true;
            this.isReplenishmentRealTimeNotificationEnabled = isReplenishmentRealTimeNotificationEnabled;
            this.isReplenishmentRealTimeNotificationEnabledChanged = true;
            this.isOutOfCashRealTimeNotificationEnabled = isOutOfCashRealTimeNotificationEnabled;
            this.isOutOfCashRealTimeNotificationEnabledChanged = true;
            this.isDispenserMismatchRealTimeNotificationEnabled = isDispenserMismatchRealTimeNotificationEnabled;
            this.isDispenserMismatchRealTimeNotificationEnabledChanged = true;
            this.isBNAMismatchRealTimeNotificationEnabled = isBNAMismatchRealTimeNotificationEnabled;
            this.isBNAMismatchRealTimeNotificationEnabledChanged = true;
            this.isCPMMismatchRealTimeNotificationEnabled = isCPMMismatchRealTimeNotificationEnabled;
            this.isCPMMismatchRealTimeNotificationEnabledChanged = true;
            this.isCounterExplodedRealTimeNotificationEnabled = isCounterExplodedRealTimeNotificationEnabled;
            this.isCounterExplodedRealTimeNotificationEnabledChanged = true;
            this.type1MinimumNotes = type1MinimumNotes;
            this.type1MinimumNotesChanged = true;
            this.type2MinimumNotes = type2MinimumNotes;
            this.type2MinimumNotesChanged = true;
            this.type3MinimumNotes = type3MinimumNotes;
            this.type3MinimumNotesChanged = true;
            this.type4MinimumNotes = type4MinimumNotes;
            this.type4MinimumNotesChanged = true;
            this.type5MinimumNotes = type5MinimumNotes;
            this.type5MinimumNotesChanged = true;
            this.type6MinimumNotes = type6MinimumNotes;
            this.type6MinimumNotesChanged = true;
            this.type7MinimumNotes = type7MinimumNotes;
            this.type7MinimumNotesChanged = true;
            this.cpm_command = cpm_command;
            this.cpm_commandChanged = true;
            this.allowed_inactivity_period = allowed_inactivity_period;
            this.allowed_inactivity_periodChanged = true;
            this.gl_number = gl_number;
            this.gl_numberChanged = true;
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
            this.description = description;
            this.descriptionChanged = true;
            this.is_dff_generation_halt = is_dff_generation_halt;
            this.is_dff_generation_haltChanged = true;
            this.cit_atm_title = cit_atm_title;
            this.cit_atm_titleChanged = true;
            this.cheque_allowed_inactivity_period = cheque_allowed_inactivity_period;
            this.cheque_allowed_inactivity_periodChanged = true;
            this.bna_allowed_inactivity_period = bna_allowed_inactivity_period;
            this.bna_allowed_inactivity_periodChanged = true;
            this.out_of_cash_threshold = out_of_cash_threshold;
            this.out_of_cash_thresholdChanged = true;
            this.no_of_dispensed_transactions_to_monitor = no_of_dispensed_transactions_to_monitor;
            this.no_of_dispensed_transactions_to_monitorChanged = true;
            this.is_ej_enabled = is_ej_enabled;
            this.is_ej_enabledChanged = true;
            this.is_counter_enabled = is_counter_enabled;
            this.is_counter_enabledChanged = true;
            this.priority = priority;
            this.priorityChanged = true;
            this.longitude = longitude;
            this.longitudeChanged = true;
            this.latitude = latitude;
            this.latitudeChanged = true;
            this.on_us_amount = on_us_amount;
            this.on_us_amountChanged = true;
            this.not_on_us_amount = not_on_us_amount;
            this.not_on_us_amountChanged = true;
            this.standard_order_type1 = standard_order_type1;
            this.standard_order_type1Changed = true;
            this.standard_order_type2 = standard_order_type2;
            this.standard_order_type2Changed = true;
            this.standard_order_type3 = standard_order_type3;
            this.standard_order_type3Changed = true;
            this.standard_order_type4 = standard_order_type4;
            this.standard_order_type4Changed = true;
            this.standard_order_type5 = standard_order_type5;
            this.standard_order_type5Changed = true;
            this.standard_order_type6 = standard_order_type6;
            this.standard_order_type6Changed = true;
            this.standard_order_type7 = standard_order_type7;
            this.standard_order_type7Changed = true;
            this.protocol_type_id = protocol_type_id;
            this.protocol_type_idChanged = true;
            this.current_mode = current_mode;
            this.current_modeChanged = true;
            this.aggregate_state = aggregate_state;
            this.aggregate_stateChanged = true;
            this.last_boot_time = last_boot_time;
            this.last_boot_timeChanged = true;
            this.discovery_time = discovery_time;
            this.discovery_timeChanged = true;
            this.last_scan_time = last_scan_time;
            this.last_scan_timeChanged = true;
            this.communication_status = communication_status;
            this.communication_statusChanged = true;
            this.is_critical = is_critical;
            this.is_criticalChanged = true;
            this.current_mode_modified_on = current_mode_modified_on;
            this.current_mode_modified_onChanged = true;
            this.last_Notification_Received_On = last_Notification_Received_On;
            this.last_Notification_Received_OnChanged = true;
            this.last_Notification_Time = last_Notification_Time;
            this.last_Notification_TimeChanged = true;
            this.normal_order_cost = normal_order_cost;
            this.normal_order_costChanged = true;
            this.emergency_order_cost = emergency_order_cost;
            this.emergency_order_costChanged = true;
            this.receipt_transaction_cutoff = receipt_transaction_cutoff;
            this.receipt_transaction_cutoffChanged = true;
            this.is_swap_default_replenishment = is_swap_default_replenishment;
            this.is_swap_default_replenishmentChanged = true;
            this.message_processor_id = message_processor_id;
            this.message_processor_idChanged = true;
            this.last_ping_status = last_ping_status;
            this.last_ping_statusChanged = true;
            this.last_ping_executed_at = last_ping_executed_at;
            this.last_ping_executed_atChanged = true;
            this.last_telnet_status = last_telnet_status;
            this.last_telnet_statusChanged = true;
            this.last_telnet_executed_at = last_telnet_executed_at;
            this.last_telnet_executed_atChanged = true;
            this.last_archive_file_received_at = last_archive_file_received_at;
            this.last_archive_file_received_atChanged = true;
            this.is_sdm = is_sdm;
            this.is_sdmChanged = true;
            this.initEjExecTime = initEjExecTime;
            this.initEjExecTimeChanged = true;
            this.ccmsagent_last_reported_heartbeat = ccmsagent_last_reported_heartbeat;
            this.ccmsagent_last_reported_heartbeatChanged = true;
            this.ccmsservicemanager_last_reported_heartbeat = ccmsservicemanager_last_reported_heartbeat;
            this.ccmsservicemanager_last_reported_heartbeatChanged = true;
            this.distribution_port = distribution_port;
            this.distribution_portChanged = true;
            this.parser_rep_date_format = parser_rep_date_format;
            this.parser_rep_date_formatChanged = true;
            this.type1_min_notes_threshold = type1_min_notes_threshold;
            this.type1_min_notes_thresholdChanged = true;
            this.type2_min_notes_threshold = type2_min_notes_threshold;
            this.type2_min_notes_thresholdChanged = true;
            this.type3_min_notes_threshold = type3_min_notes_threshold;
            this.type3_min_notes_thresholdChanged = true;
            this.type4_min_notes_threshold = type4_min_notes_threshold;
            this.type4_min_notes_thresholdChanged = true;
            this.type1_suggested_notes_normal_days = type1_suggested_notes_normal_days;
            this.type1_suggested_notes_normal_daysChanged = true;
            this.type2_suggested_notes_normal_days = type2_suggested_notes_normal_days;
            this.type2_suggested_notes_normal_daysChanged = true;
            this.type3_suggested_notes_normal_days = type3_suggested_notes_normal_days;
            this.type3_suggested_notes_normal_daysChanged = true;
            this.type4_suggested_notes_normal_days = type4_suggested_notes_normal_days;
            this.type4_suggested_notes_normal_daysChanged = true;
            this.type5_suggested_notes_normal_days = type5_suggested_notes_normal_days;
            this.type5_suggested_notes_normal_daysChanged = true;
            this.type6_suggested_notes_normal_days = type6_suggested_notes_normal_days;
            this.type6_suggested_notes_normal_daysChanged = true;
            this.type7_suggested_notes_normal_days = type7_suggested_notes_normal_days;
            this.type7_suggested_notes_normal_daysChanged = true;
            this.type1_suggested_notes_salary_days = type1_suggested_notes_salary_days;
            this.type1_suggested_notes_salary_daysChanged = true;
            this.type2_suggested_notes_salary_days = type2_suggested_notes_salary_days;
            this.type2_suggested_notes_salary_daysChanged = true;
            this.type3_suggested_notes_salary_days = type3_suggested_notes_salary_days;
            this.type3_suggested_notes_salary_daysChanged = true;
            this.type4_suggested_notes_salary_days = type4_suggested_notes_salary_days;
            this.type4_suggested_notes_salary_daysChanged = true;
            this.type5_suggested_notes_salary_days = type5_suggested_notes_salary_days;
            this.type5_suggested_notes_salary_daysChanged = true;
            this.type6_suggested_notes_salary_days = type6_suggested_notes_salary_days;
            this.type6_suggested_notes_salary_daysChanged = true;
            this.type7_suggested_notes_salary_days = type7_suggested_notes_salary_days;
            this.type7_suggested_notes_salary_daysChanged = true;
            this.avg_dispensed = avg_dispensed;
            this.avg_dispensedChanged = true;
            this.spare_cash = spare_cash;
            this.spare_cashChanged = true;
            this.dispensing_behavior = dispensing_behavior;
            this.dispensing_behaviorChanged = true;
            this.avg_dispensed_salary_days = avg_dispensed_salary_days;
            this.avg_dispensed_salary_daysChanged = true;
            this.inactivity_period_salary_days = inactivity_period_salary_days;
            this.inactivity_period_salary_daysChanged = true;
            this.inactivity_period_normal_days = inactivity_period_normal_days;
            this.inactivity_period_normal_daysChanged = true;
            this.type1_min_notes_threshold_value = type1_min_notes_threshold_value;
            this.type1_min_notes_threshold_valueChanged = true;
            this.type2_min_notes_threshold_value = type2_min_notes_threshold_value;
            this.type2_min_notes_threshold_valueChanged = true;
            this.type3_min_notes_threshold_value = type3_min_notes_threshold_value;
            this.type3_min_notes_threshold_valueChanged = true;
            this.type4_min_notes_threshold_value = type4_min_notes_threshold_value;
            this.type4_min_notes_threshold_valueChanged = true;
            this.bna_allowed_inactivity_period_normal_days = bna_allowed_inactivity_period_normal_days;
            this.bna_allowed_inactivity_period_normal_daysChanged = true;
            this.bna_allowed_inactivity_period_salary_days = bna_allowed_inactivity_period_salary_days;
            this.bna_allowed_inactivity_period_salary_daysChanged = true;
            this.cheque_allowed_inactivity_period_normal_days = cheque_allowed_inactivity_period_normal_days;
            this.cheque_allowed_inactivity_period_normal_daysChanged = true;
            this.cheque_allowed_inactivity_period_salary_days = cheque_allowed_inactivity_period_salary_days;
            this.cheque_allowed_inactivity_period_salary_daysChanged = true;
            this.min_operating_balance_normal_days = min_operating_balance_normal_days;
            this.min_operating_balance_normal_daysChanged = true;
            this.min_operating_balance_salary_days = min_operating_balance_salary_days;
            this.min_operating_balance_salary_daysChanged = true;
            this.is_order_auto_generated = is_order_auto_generated;
            this.is_order_auto_generatedChanged = true;
            this.is_win7_machine = is_win7_machine;
            this.is_win7_machineChanged = true;
            this.is_branch_atm = is_branch_atm;
            this.is_branch_atmChanged = true;
            this.is_emirate_islamic = is_emirate_islamic;
            this.is_emirate_islamicChanged = true;
            this.is_itm = is_itm;
            this.is_itmChanged = true;
            this.is_bulk_cash_deposit = is_bulk_cash_deposit;
            this.is_bulk_cash_depositChanged = true;
            this.is_combo = is_combo;
            this.is_comboChanged = true;
            this.atm_cost = atm_cost;
            this.atm_costChanged = true;
            this.software_cost = software_cost;
            this.software_costChanged = true;
            this.network_cost = network_cost;
            this.network_costChanged = true;
            this.site_preparation_cost = site_preparation_cost;
            this.site_preparation_costChanged = true;
            this.security_infrastructure_cost = security_infrastructure_cost;
            this.security_infrastructure_costChanged = true;
            this.im_branch_code = im_branch_code;
            this.im_branch_codeChanged = true;
            this.im_en_id = im_en_id;
            this.im_en_idChanged = true;
            this.im_location = im_location;
            this.im_locationChanged = true;
            this.im_business_area = im_business_area;
            this.im_business_areaChanged = true;
            this.im_circle = im_circle;
            this.im_circleChanged = true;
            this.cit_id = cit_id;
            this.cit_idChanged = true;
            this.atm_bandwidth_id = atm_bandwidth_id;
            this.atm_bandwidth_idChanged = true;
            this.atm_model_id = atm_model_id;
            this.atm_model_idChanged = true;
            this.is_recycler = is_recycler;
            this.is_recyclerChanged = true;
        }

        #region members and properties for columns

        #region ATMId
        private bool aTM_idChanged = false;
        private int aTM_id;
        public int ATMId
        {
            get { return aTM_id; }
            set
            {
                aTM_id = value;
                aTM_idChanged = true;
            }
        }
        private string aTM_idDbString
        {
            get
            {
                return aTM_id.ToString();
            }
        }
        #endregion
        #region LastStatusReply
        private bool last_status_replyChanged = false;
        private string last_status_reply;
        public string LastStatusReply
        {
            get { return last_status_reply; }
            set
            {
                last_status_reply = value;
                last_status_replyChanged = true;
            }
        }
        private string last_status_replyDbString
        {
            get
            {
                if (this.last_status_reply != null)
                    return string.Format("'{0}'", last_status_reply);
                else
                    return "null";
            }
        }
        #endregion
        #region RegionId
        private bool region_idChanged = false;
        private int region_id;
        public int RegionId
        {
            get { return region_id; }
            set
            {
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
        #region Title
        private bool titleChanged = false;
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                titleChanged = true;
            }
        }
        private string titleDbString
        {
            get
            {
                if (this.title != null)
                    return string.Format("'{0}'", title);
                else
                    return "null";
            }
        }
        #endregion
        #region IP
        private bool iPChanged = false;
        private string iP;
        public string IP
        {
            get { return iP; }
            set
            {
                iP = value;
                iPChanged = true;
            }
        }
        private string iPDbString
        {
            get
            {
                if (this.iP != null)
                    return string.Format("'{0}'", iP);
                else
                    return "null";
            }
        }
        #endregion
        #region Port
        private bool portChanged = false;
        private int port;
        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                portChanged = true;
            }
        }
        private string portDbString
        {
            get
            {
                return port.ToString();
            }
        }
        #endregion
        #region ModifiedBy
        private bool modified_byChanged = false;
        private int? modified_by;
        public int? ModifiedBy
        {
            get { return modified_by; }
            set
            {
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
        #region CreatedBy
        private bool created_byChanged = false;
        private int created_by;
        public int CreatedBy
        {
            get { return created_by; }
            set
            {
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
        #region IsActive
        private bool is_activeChanged = false;
        private bool is_active;
        public bool IsActive
        {
            get { return is_active; }
            set
            {
                is_active = value;
                is_activeChanged = true;
            }
        }
        private string is_activeDbString
        {
            get
            {
                return is_active ? "1" : "0";
            }
        }
        #endregion
        #region CreationTime
        private bool creation_timeChanged = false;
        private DateTime creation_time;
        public DateTime CreationTime
        {
            get { return creation_time; }
            set
            {
                creation_time = value;
                creation_timeChanged = true;
            }
        }
        private string creation_timeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", creation_time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region AtmType
        private bool atm_typeChanged = false;
        private string atm_type;
        public string AtmType
        {
            get { return atm_type; }
            set
            {
                atm_type = value;
                atm_typeChanged = true;
            }
        }
        private string atm_typeDbString
        {
            get
            {
                if (this.atm_type != null)
                    return string.Format("'{0}'", atm_type);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Capacity
        private bool cassette1_capacityChanged = false;
        private int cassette1_capacity;
        public int Cassette1Capacity
        {
            get { return cassette1_capacity; }
            set
            {
                cassette1_capacity = value;
                cassette1_capacityChanged = true;
            }
        }
        private string cassette1_capacityDbString
        {
            get
            {
                return cassette1_capacity.ToString();
            }
        }
        #endregion
        #region Cassette1Denomination
        private bool cassette1_denominationChanged = false;
        private int cassette1_denomination;
        public int Cassette1Denomination
        {
            get { return cassette1_denomination; }
            set
            {
                cassette1_denomination = value;
                cassette1_denominationChanged = true;
            }
        }
        private string cassette1_denominationDbString
        {
            get
            {
                return cassette1_denomination.ToString();
            }
        }
        #endregion
        #region Cassette2Capacity
        private bool cassette2_capacityChanged = false;
        private int cassette2_capacity;
        public int Cassette2Capacity
        {
            get { return cassette2_capacity; }
            set
            {
                cassette2_capacity = value;
                cassette2_capacityChanged = true;
            }
        }
        private string cassette2_capacityDbString
        {
            get
            {
                return cassette2_capacity.ToString();
            }
        }
        #endregion
        #region Cassette2Denomination
        private bool cassette2_denominationChanged = false;
        private int cassette2_denomination;
        public int Cassette2Denomination
        {
            get { return cassette2_denomination; }
            set
            {
                cassette2_denomination = value;
                cassette2_denominationChanged = true;
            }
        }
        private string cassette2_denominationDbString
        {
            get
            {
                return cassette2_denomination.ToString();
            }
        }
        #endregion
        #region Cassette3Denomination
        private bool cassette3_denominationChanged = false;
        private int cassette3_denomination;
        public int Cassette3Denomination
        {
            get { return cassette3_denomination; }
            set
            {
                cassette3_denomination = value;
                cassette3_denominationChanged = true;
            }
        }
        private string cassette3_denominationDbString
        {
            get
            {
                return cassette3_denomination.ToString();
            }
        }
        #endregion
        #region Cassette3Capacity
        private bool cassette3_capacityChanged = false;
        private int cassette3_capacity;
        public int Cassette3Capacity
        {
            get { return cassette3_capacity; }
            set
            {
                cassette3_capacity = value;
                cassette3_capacityChanged = true;
            }
        }
        private string cassette3_capacityDbString
        {
            get
            {
                return cassette3_capacity.ToString();
            }
        }
        #endregion
        #region Cassette4Denomination
        private bool cassette4_denominationChanged = false;
        private int cassette4_denomination;
        public int Cassette4Denomination
        {
            get { return cassette4_denomination; }
            set
            {
                cassette4_denomination = value;
                cassette4_denominationChanged = true;
            }
        }
        private string cassette4_denominationDbString
        {
            get
            {
                return cassette4_denomination.ToString();
            }
        }
        #endregion
        #region Cassette4Capacity
        private bool cassette4_capacityChanged = false;
        private int cassette4_capacity;
        public int Cassette4Capacity
        {
            get { return cassette4_capacity; }
            set
            {
                cassette4_capacity = value;
                cassette4_capacityChanged = true;
            }
        }
        private string cassette4_capacityDbString
        {
            get
            {
                return cassette4_capacity.ToString();
            }
        }
        #endregion
        #region Cassette5Denomination
        private bool cassette5_denominationChanged = false;
        private int cassette5_denomination;
        public int Cassette5Denomination
        {
            get { return cassette5_denomination; }
            set
            {
                cassette5_denomination = value;
                cassette5_denominationChanged = true;
            }
        }
        private string cassette5_denominationDbString
        {
            get
            {
                return cassette5_denomination.ToString();
            }
        }
        #endregion
        #region Cassette5Capacity
        private bool cassette5_capacityChanged = false;
        private int cassette5_capacity;
        public int Cassette5Capacity
        {
            get { return cassette5_capacity; }
            set
            {
                cassette5_capacity = value;
                cassette5_capacityChanged = true;
            }
        }
        private string cassette5_capacityDbString
        {
            get
            {
                return cassette5_capacity.ToString();
            }
        }
        #endregion
        #region Cassette6Denomination
        private bool cassette6_denominationChanged = false;
        private int cassette6_denomination;
        public int Cassette6Denomination
        {
            get { return cassette6_denomination; }
            set
            {
                cassette6_denomination = value;
                cassette6_denominationChanged = true;
            }
        }
        private string cassette6_denominationDbString
        {
            get
            {
                return cassette6_denomination.ToString();
            }
        }
        #endregion
        #region Cassette6Capacity
        private bool cassette6_capacityChanged = false;
        private int cassette6_capacity;
        public int Cassette6Capacity
        {
            get { return cassette6_capacity; }
            set
            {
                cassette6_capacity = value;
                cassette6_capacityChanged = true;
            }
        }
        private string cassette6_capacityDbString
        {
            get
            {
                return cassette6_capacity.ToString();
            }
        }
        #endregion
        #region Cassette7Denomination
        private bool cassette7_denominationChanged = false;
        private int cassette7_denomination;
        public int Cassette7Denomination
        {
            get { return cassette7_denomination; }
            set
            {
                cassette7_denomination = value;
                cassette7_denominationChanged = true;
            }
        }
        private string cassette7_denominationDbString
        {
            get
            {
                return cassette7_denomination.ToString();
            }
        }
        #endregion
        #region Cassette7Capacity
        private bool cassette7_capacityChanged = false;
        private int cassette7_capacity;
        public int Cassette7Capacity
        {
            get { return cassette7_capacity; }
            set
            {
                cassette7_capacity = value;
                cassette7_capacityChanged = true;
            }
        }
        private string cassette7_capacityDbString
        {
            get
            {
                return cassette7_capacity.ToString();
            }
        }
        #endregion
        #region LastWincorSent
        private bool last_wincor_sentChanged = false;
        private DateTime last_wincor_sent;
        public DateTime LastWincorSent
        {
            get { return last_wincor_sent; }
            set
            {
                last_wincor_sent = value;
                last_wincor_sentChanged = true;
            }
        }
        private string last_wincor_sentDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", last_wincor_sent.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region IsHealthy
        private bool is_healthyChanged = false;
        private bool is_healthy;
        public bool IsHealthy
        {
            get { return is_healthy; }
            set
            {
                is_healthy = value;
                is_healthyChanged = true;
            }
        }
        private string is_healthyDbString
        {
            get
            {
                return is_healthy ? "1" : "0";
            }
        }
        #endregion
        #region Location
        private bool locationChanged = false;
        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                locationChanged = true;
            }
        }
        private string locationDbString
        {
            get
            {
                if (this.location != null)
                    return string.Format("'{0}'", location);
                else
                    return "null";
            }
        }
        #endregion
        #region Address1
        private bool address1Changed = false;
        private string address1;
        public string Address1
        {
            get { return address1; }
            set
            {
                address1 = value;
                address1Changed = true;
            }
        }
        private string address1DbString
        {
            get
            {
                if (this.address1 != null)
                    return string.Format("'{0}'", address1);
                else
                    return "null";
            }
        }
        #endregion
        #region Address2
        private bool address2Changed = false;
        private string address2;
        public string Address2
        {
            get { return address2; }
            set
            {
                address2 = value;
                address2Changed = true;
            }
        }
        private string address2DbString
        {
            get
            {
                if (this.address2 != null)
                    return string.Format("'{0}'", address2);
                else
                    return "null";
            }
        }
        #endregion
        #region City
        private bool cityChanged = false;
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                cityChanged = true;
            }
        }
        private string cityDbString
        {
            get
            {
                if (this.city != null)
                    return string.Format("'{0}'", city);
                else
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
            set
            {
                country = value;
                countryChanged = true;
            }
        }
        private string countryDbString
        {
            get
            {
                if (this.country != null)
                    return string.Format("'{0}'", country);
                else
                    return "null";
            }
        }
        #endregion
        #region ZipCode
        private bool zip_codeChanged = false;
        private string zip_code;
        public string ZipCode
        {
            get { return zip_code; }
            set
            {
                zip_code = value;
                zip_codeChanged = true;
            }
        }
        private string zip_codeDbString
        {
            get
            {
                if (this.zip_code != null)
                    return string.Format("'{0}'", zip_code);
                else
                    return "null";
            }
        }
        #endregion
        #region LocationType
        private bool location_typeChanged = false;
        private string location_type;
        public string LocationType
        {
            get { return location_type; }
            set
            {
                location_type = value;
                location_typeChanged = true;
            }
        }
        private string location_typeDbString
        {
            get
            {
                if (this.location_type != null)
                    return string.Format("'{0}'", location_type);
                else
                    return "null";
            }
        }
        #endregion
        #region ServiceStatus
        private bool service_statusChanged = false;
        private string service_status;
        public string ServiceStatus
        {
            get { return service_status; }
            set
            {
                service_status = value;
                service_statusChanged = true;
            }
        }
        private string service_statusDbString
        {
            get
            {
                if (this.service_status != null)
                    return string.Format("'{0}'", service_status);
                else
                    return "null";
            }
        }
        #endregion
        #region HolidayStatus
        private bool holiday_statusChanged = false;
        private string holiday_status;
        public string HolidayStatus
        {
            get { return holiday_status; }
            set
            {
                holiday_status = value;
                holiday_statusChanged = true;
            }
        }
        private string holiday_statusDbString
        {
            get
            {
                if (this.holiday_status != null)
                    return string.Format("'{0}'", holiday_status);
                else
                    return "null";
            }
        }
        #endregion
        #region BusinessDays
        private bool business_daysChanged = false;
        private string business_days;
        public string BusinessDays
        {
            get { return business_days; }
            set
            {
                business_days = value;
                business_daysChanged = true;
            }
        }
        private string business_daysDbString
        {
            get
            {
                if (this.business_days != null)
                    return string.Format("'{0}'", business_days);
                else
                    return "null";
            }
        }
        #endregion
        #region TimeZone
        private bool time_zoneChanged = false;
        private int? time_zone;
        public int? TimeZone
        {
            get { return time_zone; }
            set
            {
                time_zone = value;
                time_zoneChanged = true;
            }
        }
        private string time_zoneDbString
        {
            get
            {
                if (this.time_zone.HasValue)
                    return time_zone.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MaxNotesPerCassette
        private bool max_notes_per_cassetteChanged = false;
        private int? max_notes_per_cassette;
        public int? MaxNotesPerCassette
        {
            get { return max_notes_per_cassette; }
            set
            {
                max_notes_per_cassette = value;
                max_notes_per_cassetteChanged = true;
            }
        }
        private string max_notes_per_cassetteDbString
        {
            get
            {
                if (this.max_notes_per_cassette.HasValue)
                    return max_notes_per_cassette.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1SplitPercentage
        private bool cassette1_split_percentageChanged = false;
        private int? cassette1_split_percentage;
        public int? Cassette1SplitPercentage
        {
            get { return cassette1_split_percentage; }
            set
            {
                cassette1_split_percentage = value;
                cassette1_split_percentageChanged = true;
            }
        }
        private string cassette1_split_percentageDbString
        {
            get
            {
                if (this.cassette1_split_percentage.HasValue)
                    return cassette1_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2SplitPercentage
        private bool cassette2_split_percentageChanged = false;
        private int? cassette2_split_percentage;
        public int? Cassette2SplitPercentage
        {
            get { return cassette2_split_percentage; }
            set
            {
                cassette2_split_percentage = value;
                cassette2_split_percentageChanged = true;
            }
        }
        private string cassette2_split_percentageDbString
        {
            get
            {
                if (this.cassette2_split_percentage.HasValue)
                    return cassette2_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3SplitPercentage
        private bool cassette3_split_percentageChanged = false;
        private int? cassette3_split_percentage;
        public int? Cassette3SplitPercentage
        {
            get { return cassette3_split_percentage; }
            set
            {
                cassette3_split_percentage = value;
                cassette3_split_percentageChanged = true;
            }
        }
        private string cassette3_split_percentageDbString
        {
            get
            {
                if (this.cassette3_split_percentage.HasValue)
                    return cassette3_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4SplitPercentage
        private bool cassette4_split_percentageChanged = false;
        private int? cassette4_split_percentage;
        public int? Cassette4SplitPercentage
        {
            get { return cassette4_split_percentage; }
            set
            {
                cassette4_split_percentage = value;
                cassette4_split_percentageChanged = true;
            }
        }
        private string cassette4_split_percentageDbString
        {
            get
            {
                if (this.cassette4_split_percentage.HasValue)
                    return cassette4_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette5SplitPercentage
        private bool cassette5_split_percentageChanged = false;
        private int? cassette5_split_percentage;
        public int? Cassette5SplitPercentage
        {
            get { return cassette5_split_percentage; }
            set
            {
                cassette5_split_percentage = value;
                cassette5_split_percentageChanged = true;
            }
        }
        private string cassette5_split_percentageDbString
        {
            get
            {
                if (this.cassette5_split_percentage.HasValue)
                    return cassette5_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette6SplitPercentage
        private bool cassette6_split_percentageChanged = false;
        private int? cassette6_split_percentage;
        public int? Cassette6SplitPercentage
        {
            get { return cassette6_split_percentage; }
            set
            {
                cassette6_split_percentage = value;
                cassette6_split_percentageChanged = true;
            }
        }
        private string cassette6_split_percentageDbString
        {
            get
            {
                if (this.cassette6_split_percentage.HasValue)
                    return cassette6_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette7SplitPercentage
        private bool cassette7_split_percentageChanged = false;
        private int? cassette7_split_percentage;
        public int? Cassette7SplitPercentage
        {
            get { return cassette7_split_percentage; }
            set
            {
                cassette7_split_percentage = value;
                cassette7_split_percentageChanged = true;
            }
        }
        private string cassette7_split_percentageDbString
        {
            get
            {
                if (this.cassette7_split_percentage.HasValue)
                    return cassette7_split_percentage.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region InterestRate
        private bool interest_rateChanged = false;
        private decimal? interest_rate;
        public decimal? InterestRate
        {
            get { return interest_rate; }
            set
            {
                interest_rate = value;
                interest_rateChanged = true;
            }
        }
        private string interest_rateDbString
        {
            get
            {
                if (this.interest_rate.HasValue)
                    return interest_rate.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region InsuranceRate
        private bool insurance_rateChanged = false;
        private decimal? insurance_rate;
        public decimal? InsuranceRate
        {
            get { return insurance_rate; }
            set
            {
                insurance_rate = value;
                insurance_rateChanged = true;
            }
        }
        private string insurance_rateDbString
        {
            get
            {
                if (this.insurance_rate.HasValue)
                    return insurance_rate.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MaxHoldingAmount
        private bool max_holding_amountChanged = false;
        private decimal? max_holding_amount;
        public decimal? MaxHoldingAmount
        {
            get { return max_holding_amount; }
            set
            {
                max_holding_amount = value;
                max_holding_amountChanged = true;
            }
        }
        private string max_holding_amountDbString
        {
            get
            {
                if (this.max_holding_amount.HasValue)
                    return max_holding_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MinOperatingBalance
        private bool min_operating_balanceChanged = false;
        private decimal? min_operating_balance;
        public decimal? MinOperatingBalance
        {
            get { return min_operating_balance; }
            set
            {
                min_operating_balance = value;
                min_operating_balanceChanged = true;
            }
        }
        private string min_operating_balanceDbString
        {
            get
            {
                if (this.min_operating_balance.HasValue)
                    return min_operating_balance.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MinAmountForNormalDelivery
        private bool min_amount_for_normal_deliveryChanged = false;
        private decimal? min_amount_for_normal_delivery;
        public decimal? MinAmountForNormalDelivery
        {
            get { return min_amount_for_normal_delivery; }
            set
            {
                min_amount_for_normal_delivery = value;
                min_amount_for_normal_deliveryChanged = true;
            }
        }
        private string min_amount_for_normal_deliveryDbString
        {
            get
            {
                if (this.min_amount_for_normal_delivery.HasValue)
                    return min_amount_for_normal_delivery.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region BankCashCenterId
        private bool bank_cash_center_idChanged = false;
        private string bank_cash_center_id;
        public string BankCashCenterId
        {
            get { return bank_cash_center_id; }
            set
            {
                bank_cash_center_id = value;
                bank_cash_center_idChanged = true;
            }
        }
        private string bank_cash_center_idDbString
        {
            get
            {
                if (this.bank_cash_center_id != null)
                    return string.Format("'{0}'", bank_cash_center_id);
                else
                    return "null";
            }
        }
        #endregion
        #region CITCashCenterServicer
        private bool cIT_cash_center_servicerChanged = false;
        private string cIT_cash_center_servicer;
        public string CITCashCenterServicer
        {
            get { return cIT_cash_center_servicer; }
            set
            {
                cIT_cash_center_servicer = value;
                cIT_cash_center_servicerChanged = true;
            }
        }
        private string cIT_cash_center_servicerDbString
        {
            get
            {
                if (this.cIT_cash_center_servicer != null)
                    return string.Format("'{0}'", cIT_cash_center_servicer);
                else
                    return "null";
            }
        }
        #endregion
        #region DepotId
        private bool depot_idChanged = false;
        private string depot_id;
        public string DepotId
        {
            get { return depot_id; }
            set
            {
                depot_id = value;
                depot_idChanged = true;
            }
        }
        private string depot_idDbString
        {
            get
            {
                if (this.depot_id != null)
                    return string.Format("'{0}'", depot_id);
                else
                    return "null";
            }
        }
        #endregion
        #region SecondaryDepotVaultId
        private bool secondary_depot_vault_idChanged = false;
        private string secondary_depot_vault_id;
        public string SecondaryDepotVaultId
        {
            get { return secondary_depot_vault_id; }
            set
            {
                secondary_depot_vault_id = value;
                secondary_depot_vault_idChanged = true;
            }
        }
        private string secondary_depot_vault_idDbString
        {
            get
            {
                if (this.secondary_depot_vault_id != null)
                    return string.Format("'{0}'", secondary_depot_vault_id);
                else
                    return "null";
            }
        }
        #endregion
        #region NewAtmScenario
        private bool new_atm_scenarioChanged = false;
        private string new_atm_scenario;
        public string NewAtmScenario
        {
            get { return new_atm_scenario; }
            set
            {
                new_atm_scenario = value;
                new_atm_scenarioChanged = true;
            }
        }
        private string new_atm_scenarioDbString
        {
            get
            {
                if (this.new_atm_scenario != null)
                    return string.Format("'{0}'", new_atm_scenario);
                else
                    return "null";
            }
        }
        #endregion
        #region CashSwapDays
        private bool cash_swap_daysChanged = false;
        private string cash_swap_days;
        public string CashSwapDays
        {
            get { return cash_swap_days; }
            set
            {
                cash_swap_days = value;
                cash_swap_daysChanged = true;
            }
        }
        private string cash_swap_daysDbString
        {
            get
            {
                if (this.cash_swap_days != null)
                    return string.Format("'{0}'", cash_swap_days);
                else
                    return "null";
            }
        }
        #endregion
        #region MandatoryCashSwapDays
        private bool mandatory_cash_swap_daysChanged = false;
        private string mandatory_cash_swap_days;
        public string MandatoryCashSwapDays
        {
            get { return mandatory_cash_swap_days; }
            set
            {
                mandatory_cash_swap_days = value;
                mandatory_cash_swap_daysChanged = true;
            }
        }
        private string mandatory_cash_swap_daysDbString
        {
            get
            {
                if (this.mandatory_cash_swap_days != null)
                    return string.Format("'{0}'", mandatory_cash_swap_days);
                else
                    return "null";
            }
        }
        #endregion
        #region CashSwapCycle
        private bool cash_swap_cycleChanged = false;
        private int? cash_swap_cycle;
        public int? CashSwapCycle
        {
            get { return cash_swap_cycle; }
            set
            {
                cash_swap_cycle = value;
                cash_swap_cycleChanged = true;
            }
        }
        private string cash_swap_cycleDbString
        {
            get
            {
                if (this.cash_swap_cycle.HasValue)
                    return cash_swap_cycle.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashSwapLeadTime
        private bool cash_swap_lead_timeChanged = false;
        private int? cash_swap_lead_time;
        public int? CashSwapLeadTime
        {
            get { return cash_swap_lead_time; }
            set
            {
                cash_swap_lead_time = value;
                cash_swap_lead_timeChanged = true;
            }
        }
        private string cash_swap_lead_timeDbString
        {
            get
            {
                if (this.cash_swap_lead_time.HasValue)
                    return cash_swap_lead_time.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashSwapStartDate
        private bool cash_swap_start_dateChanged = false;
        private DateTime? cash_swap_start_date;
        public DateTime? CashSwapStartDate
        {
            get { return cash_swap_start_date; }
            set
            {
                cash_swap_start_date = value;
                cash_swap_start_dateChanged = true;
            }
        }
        private string cash_swap_start_dateDbString
        {
            get
            {
                if (this.cash_swap_start_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", cash_swap_start_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CashSwapHandlingCost
        private bool cash_swap_handling_costChanged = false;
        private decimal? cash_swap_handling_cost;
        public decimal? CashSwapHandlingCost
        {
            get { return cash_swap_handling_cost; }
            set
            {
                cash_swap_handling_cost = value;
                cash_swap_handling_costChanged = true;
            }
        }
        private string cash_swap_handling_costDbString
        {
            get
            {
                if (this.cash_swap_handling_cost.HasValue)
                    return cash_swap_handling_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashSwapCosts
        private bool cash_swap_costsChanged = false;
        private decimal? cash_swap_costs;
        public decimal? CashSwapCosts
        {
            get { return cash_swap_costs; }
            set
            {
                cash_swap_costs = value;
                cash_swap_costsChanged = true;
            }
        }
        private string cash_swap_costsDbString
        {
            get
            {
                if (this.cash_swap_costs.HasValue)
                    return cash_swap_costs.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EmergencyDays
        private bool emergency_daysChanged = false;
        private string emergency_days;
        public string EmergencyDays
        {
            get { return emergency_days; }
            set
            {
                emergency_days = value;
                emergency_daysChanged = true;
            }
        }
        private string emergency_daysDbString
        {
            get
            {
                if (this.emergency_days != null)
                    return string.Format("'{0}'", emergency_days);
                else
                    return "null";
            }
        }
        #endregion
        #region EmergencyLeadTime
        private bool emergency_lead_timeChanged = false;
        private int? emergency_lead_time;
        public int? EmergencyLeadTime
        {
            get { return emergency_lead_time; }
            set
            {
                emergency_lead_time = value;
                emergency_lead_timeChanged = true;
            }
        }
        private string emergency_lead_timeDbString
        {
            get
            {
                if (this.emergency_lead_time.HasValue)
                    return emergency_lead_time.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EmergencyCost
        private bool emergency_costChanged = false;
        private decimal? emergency_cost;
        public decimal? EmergencyCost
        {
            get { return emergency_cost; }
            set
            {
                emergency_cost = value;
                emergency_costChanged = true;
            }
        }
        private string emergency_costDbString
        {
            get
            {
                if (this.emergency_cost.HasValue)
                    return emergency_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Contact1Email
        private bool contact1_emailChanged = false;
        private string contact1_email;
        public string Contact1Email
        {
            get { return contact1_email; }
            set
            {
                contact1_email = value;
                contact1_emailChanged = true;
            }
        }
        private string contact1_emailDbString
        {
            get
            {
                if (this.contact1_email != null)
                    return string.Format("'{0}'", contact1_email);
                else
                    return "null";
            }
        }
        #endregion
        #region Contact2Email
        private bool contact2_emailChanged = false;
        private string contact2_email;
        public string Contact2Email
        {
            get { return contact2_email; }
            set
            {
                contact2_email = value;
                contact2_emailChanged = true;
            }
        }
        private string contact2_emailDbString
        {
            get
            {
                if (this.contact2_email != null)
                    return string.Format("'{0}'", contact2_email);
                else
                    return "null";
            }
        }
        #endregion
        #region Contact3Email
        private bool contact3_emailChanged = false;
        private string contact3_email;
        public string Contact3Email
        {
            get { return contact3_email; }
            set
            {
                contact3_email = value;
                contact3_emailChanged = true;
            }
        }
        private string contact3_emailDbString
        {
            get
            {
                if (this.contact3_email != null)
                    return string.Format("'{0}'", contact3_email);
                else
                    return "null";
            }
        }
        #endregion
        #region Contact1Phone
        private bool contact1_phoneChanged = false;
        private string contact1_phone;
        public string Contact1Phone
        {
            get { return contact1_phone; }
            set
            {
                contact1_phone = value;
                contact1_phoneChanged = true;
            }
        }
        private string contact1_phoneDbString
        {
            get
            {
                if (this.contact1_phone != null)
                    return string.Format("'{0}'", contact1_phone);
                else
                    return "null";
            }
        }
        #endregion
        #region Contact2Phone
        private bool contact2_phoneChanged = false;
        private string contact2_phone;
        public string Contact2Phone
        {
            get { return contact2_phone; }
            set
            {
                contact2_phone = value;
                contact2_phoneChanged = true;
            }
        }
        private string contact2_phoneDbString
        {
            get
            {
                if (this.contact2_phone != null)
                    return string.Format("'{0}'", contact2_phone);
                else
                    return "null";
            }
        }
        #endregion
        #region Contact3Phone
        private bool contact3_phoneChanged = false;
        private string contact3_phone;
        public string Contact3Phone
        {
            get { return contact3_phone; }
            set
            {
                contact3_phone = value;
                contact3_phoneChanged = true;
            }
        }
        private string contact3_phoneDbString
        {
            get
            {
                if (this.contact3_phone != null)
                    return string.Format("'{0}'", contact3_phone);
                else
                    return "null";
            }
        }
        #endregion
        #region EffectiveDate
        private bool effective_dateChanged = false;
        private DateTime? effective_date;
        public DateTime? EffectiveDate
        {
            get { return effective_date; }
            set
            {
                effective_date = value;
                effective_dateChanged = true;
            }
        }
        private string effective_dateDbString
        {
            get
            {
                if (this.effective_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", effective_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region SuspendCashOrder
        private bool suspend_cash_orderChanged = false;
        private bool suspend_cash_order;
        public bool SuspendCashOrder
        {
            get { return suspend_cash_order; }
            set
            {
                suspend_cash_order = value;
                suspend_cash_orderChanged = true;
            }
        }
        private string suspend_cash_orderDbString
        {
            get
            {
                return suspend_cash_order ? "1" : "0";
            }
        }
        #endregion
        #region IsAtm
        private bool is_atmChanged = false;
        private bool? is_atm;
        public bool? IsAtm
        {
            get { return is_atm; }
            set
            {
                is_atm = value;
                is_atmChanged = true;
            }
        }
        private string is_atmDbString
        {
            get
            {
                if (this.is_atm.HasValue)
                    return is_atm.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsCdm
        private bool is_cdmChanged = false;
        private bool? is_cdm;
        public bool? IsCdm
        {
            get { return is_cdm; }
            set
            {
                is_cdm = value;
                is_cdmChanged = true;
            }
        }
        private string is_cdmDbString
        {
            get
            {
                if (this.is_cdm.HasValue)
                    return is_cdm.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsCcdm
        private bool is_ccdmChanged = false;
        private bool? is_ccdm;
        public bool? IsCcdm
        {
            get { return is_ccdm; }
            set
            {
                is_ccdm = value;
                is_ccdmChanged = true;
            }
        }
        private string is_ccdmDbString
        {
            get
            {
                if (this.is_ccdm.HasValue)
                    return is_ccdm.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette1Capacity
        private bool cdm_cassette1_capacityChanged = false;
        private int? cdm_cassette1_capacity;
        public int? CdmCassette1Capacity
        {
            get { return cdm_cassette1_capacity; }
            set
            {
                cdm_cassette1_capacity = value;
                cdm_cassette1_capacityChanged = true;
            }
        }
        private string cdm_cassette1_capacityDbString
        {
            get
            {
                if (this.cdm_cassette1_capacity.HasValue)
                    return cdm_cassette1_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette2Capacity
        private bool cdm_cassette2_capacityChanged = false;
        private int? cdm_cassette2_capacity;
        public int? CdmCassette2Capacity
        {
            get { return cdm_cassette2_capacity; }
            set
            {
                cdm_cassette2_capacity = value;
                cdm_cassette2_capacityChanged = true;
            }
        }
        private string cdm_cassette2_capacityDbString
        {
            get
            {
                if (this.cdm_cassette2_capacity.HasValue)
                    return cdm_cassette2_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette3Capacity
        private bool cdm_cassette3_capacityChanged = false;
        private int? cdm_cassette3_capacity;
        public int? CdmCassette3Capacity
        {
            get { return cdm_cassette3_capacity; }
            set
            {
                cdm_cassette3_capacity = value;
                cdm_cassette3_capacityChanged = true;
            }
        }
        private string cdm_cassette3_capacityDbString
        {
            get
            {
                if (this.cdm_cassette3_capacity.HasValue)
                    return cdm_cassette3_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette4Capacity
        private bool cdm_cassette4_capacityChanged = false;
        private int? cdm_cassette4_capacity;
        public int? CdmCassette4Capacity
        {
            get { return cdm_cassette4_capacity; }
            set
            {
                cdm_cassette4_capacity = value;
                cdm_cassette4_capacityChanged = true;
            }
        }
        private string cdm_cassette4_capacityDbString
        {
            get
            {
                if (this.cdm_cassette4_capacity.HasValue)
                    return cdm_cassette4_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette1Capacity
        private bool ccdm_cassette1_capacityChanged = false;
        private int? ccdm_cassette1_capacity;
        public int? CcdmCassette1Capacity
        {
            get { return ccdm_cassette1_capacity; }
            set
            {
                ccdm_cassette1_capacity = value;
                ccdm_cassette1_capacityChanged = true;
            }
        }
        private string ccdm_cassette1_capacityDbString
        {
            get
            {
                if (this.ccdm_cassette1_capacity.HasValue)
                    return ccdm_cassette1_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette2Capacity
        private bool ccdm_cassette2_capacityChanged = false;
        private int? ccdm_cassette2_capacity;
        public int? CcdmCassette2Capacity
        {
            get { return ccdm_cassette2_capacity; }
            set
            {
                ccdm_cassette2_capacity = value;
                ccdm_cassette2_capacityChanged = true;
            }
        }
        private string ccdm_cassette2_capacityDbString
        {
            get
            {
                if (this.ccdm_cassette2_capacity.HasValue)
                    return ccdm_cassette2_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette3Capacity
        private bool ccdm_cassette3_capacityChanged = false;
        private int? ccdm_cassette3_capacity;
        public int? CcdmCassette3Capacity
        {
            get { return ccdm_cassette3_capacity; }
            set
            {
                ccdm_cassette3_capacity = value;
                ccdm_cassette3_capacityChanged = true;
            }
        }
        private string ccdm_cassette3_capacityDbString
        {
            get
            {
                if (this.ccdm_cassette3_capacity.HasValue)
                    return ccdm_cassette3_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette4Capacity
        private bool ccdm_cassette4_capacityChanged = false;
        private int? ccdm_cassette4_capacity;
        public int? CcdmCassette4Capacity
        {
            get { return ccdm_cassette4_capacity; }
            set
            {
                ccdm_cassette4_capacity = value;
                ccdm_cassette4_capacityChanged = true;
            }
        }
        private string ccdm_cassette4_capacityDbString
        {
            get
            {
                if (this.ccdm_cassette4_capacity.HasValue)
                    return ccdm_cassette4_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette1Threshold
        private bool cdm_cassette1_thresholdChanged = false;
        private int? cdm_cassette1_threshold;
        public int? CdmCassette1Threshold
        {
            get { return cdm_cassette1_threshold; }
            set
            {
                cdm_cassette1_threshold = value;
                cdm_cassette1_thresholdChanged = true;
            }
        }
        private string cdm_cassette1_thresholdDbString
        {
            get
            {
                if (this.cdm_cassette1_threshold.HasValue)
                    return cdm_cassette1_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette2Threshold
        private bool cdm_cassette2_thresholdChanged = false;
        private int? cdm_cassette2_threshold;
        public int? CdmCassette2Threshold
        {
            get { return cdm_cassette2_threshold; }
            set
            {
                cdm_cassette2_threshold = value;
                cdm_cassette2_thresholdChanged = true;
            }
        }
        private string cdm_cassette2_thresholdDbString
        {
            get
            {
                if (this.cdm_cassette2_threshold.HasValue)
                    return cdm_cassette2_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette3Threshold
        private bool cdm_cassette3_thresholdChanged = false;
        private int? cdm_cassette3_threshold;
        public int? CdmCassette3Threshold
        {
            get { return cdm_cassette3_threshold; }
            set
            {
                cdm_cassette3_threshold = value;
                cdm_cassette3_thresholdChanged = true;
            }
        }
        private string cdm_cassette3_thresholdDbString
        {
            get
            {
                if (this.cdm_cassette3_threshold.HasValue)
                    return cdm_cassette3_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CdmCassette4Threshold
        private bool cdm_cassette4_thresholdChanged = false;
        private int? cdm_cassette4_threshold;
        public int? CdmCassette4Threshold
        {
            get { return cdm_cassette4_threshold; }
            set
            {
                cdm_cassette4_threshold = value;
                cdm_cassette4_thresholdChanged = true;
            }
        }
        private string cdm_cassette4_thresholdDbString
        {
            get
            {
                if (this.cdm_cassette4_threshold.HasValue)
                    return cdm_cassette4_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette1Threshold
        private bool ccdm_cassette1_thresholdChanged = false;
        private int? ccdm_cassette1_threshold;
        public int? CcdmCassette1Threshold
        {
            get { return ccdm_cassette1_threshold; }
            set
            {
                ccdm_cassette1_threshold = value;
                ccdm_cassette1_thresholdChanged = true;
            }
        }
        private string ccdm_cassette1_thresholdDbString
        {
            get
            {
                if (this.ccdm_cassette1_threshold.HasValue)
                    return ccdm_cassette1_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette2Threshold
        private bool ccdm_cassette2_thresholdChanged = false;
        private int? ccdm_cassette2_threshold;
        public int? CcdmCassette2Threshold
        {
            get { return ccdm_cassette2_threshold; }
            set
            {
                ccdm_cassette2_threshold = value;
                ccdm_cassette2_thresholdChanged = true;
            }
        }
        private string ccdm_cassette2_thresholdDbString
        {
            get
            {
                if (this.ccdm_cassette2_threshold.HasValue)
                    return ccdm_cassette2_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette3Threshold
        private bool ccdm_cassette3_thresholdChanged = false;
        private int? ccdm_cassette3_threshold;
        public int? CcdmCassette3Threshold
        {
            get { return ccdm_cassette3_threshold; }
            set
            {
                ccdm_cassette3_threshold = value;
                ccdm_cassette3_thresholdChanged = true;
            }
        }
        private string ccdm_cassette3_thresholdDbString
        {
            get
            {
                if (this.ccdm_cassette3_threshold.HasValue)
                    return ccdm_cassette3_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette4Threshold
        private bool ccdm_cassette4_thresholdChanged = false;
        private int? ccdm_cassette4_threshold;
        public int? CcdmCassette4Threshold
        {
            get { return ccdm_cassette4_threshold; }
            set
            {
                ccdm_cassette4_threshold = value;
                ccdm_cassette4_thresholdChanged = true;
            }
        }
        private string ccdm_cassette4_thresholdDbString
        {
            get
            {
                if (this.ccdm_cassette4_threshold.HasValue)
                    return ccdm_cassette4_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NoteSetTypeId
        private bool note_set_type_idChanged = false;
        private int note_set_type_id;
        public int NoteSetTypeId
        {
            get { return note_set_type_id; }
            set
            {
                note_set_type_id = value;
                note_set_type_idChanged = true;
            }
        }
        private string note_set_type_idDbString
        {
            get
            {
                return note_set_type_id.ToString();
            }
        }
        #endregion
        #region CcdmCassette5Capacity
        private bool ccdm_cassette5_capacityChanged = false;
        private int? ccdm_cassette5_capacity;
        public int? CcdmCassette5Capacity
        {
            get { return ccdm_cassette5_capacity; }
            set
            {
                ccdm_cassette5_capacity = value;
                ccdm_cassette5_capacityChanged = true;
            }
        }
        private string ccdm_cassette5_capacityDbString
        {
            get
            {
                if (this.ccdm_cassette5_capacity.HasValue)
                    return ccdm_cassette5_capacity.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CcdmCassette5Threshold
        private bool ccdm_cassette5_thresholdChanged = false;
        private int? ccdm_cassette5_threshold;
        public int? CcdmCassette5Threshold
        {
            get { return ccdm_cassette5_threshold; }
            set
            {
                ccdm_cassette5_threshold = value;
                ccdm_cassette5_thresholdChanged = true;
            }
        }
        private string ccdm_cassette5_thresholdDbString
        {
            get
            {
                if (this.ccdm_cassette5_threshold.HasValue)
                    return ccdm_cassette5_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StartupSleepInterval
        private bool startup_sleep_intervalChanged = false;
        private int? startup_sleep_interval;
        public int? StartupSleepInterval
        {
            get { return startup_sleep_interval; }
            set
            {
                startup_sleep_interval = value;
                startup_sleep_intervalChanged = true;
            }
        }
        private string startup_sleep_intervalDbString
        {
            get
            {
                if (this.startup_sleep_interval.HasValue)
                    return startup_sleep_interval.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DebugLevel
        private bool debug_levelChanged = false;
        private byte? debug_level;
        public byte? DebugLevel
        {
            get { return debug_level; }
            set
            {
                debug_level = value;
                debug_levelChanged = true;
            }
        }
        private string debug_levelDbString
        {
            get
            {
                if (this.debug_level.HasValue)
                    return debug_level.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ExcludeDff
        private bool exclude_dffChanged = false;
        private bool? exclude_dff;
        public bool? ExcludeDff
        {
            get { return exclude_dff; }
            set
            {
                exclude_dff = value;
                exclude_dffChanged = true;
            }
        }
        private string exclude_dffDbString
        {
            get
            {
                if (this.exclude_dff.HasValue)
                    return exclude_dff.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge1Threshold
        private bool purge1_thresholdChanged = false;
        private int? purge1_threshold;
        public int? Purge1Threshold
        {
            get { return purge1_threshold; }
            set
            {
                purge1_threshold = value;
                purge1_thresholdChanged = true;
            }
        }
        private string purge1_thresholdDbString
        {
            get
            {
                if (this.purge1_threshold.HasValue)
                    return purge1_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge1ThresholdSelected
        private bool is_purge1_threshold_selectedChanged = false;
        private bool? is_purge1_threshold_selected;
        public bool? IsPurge1ThresholdSelected
        {
            get { return is_purge1_threshold_selected; }
            set
            {
                is_purge1_threshold_selected = value;
                is_purge1_threshold_selectedChanged = true;
            }
        }
        private string is_purge1_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge1_threshold_selected.HasValue)
                    return is_purge1_threshold_selected.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge2Threshold
        private bool purge2_thresholdChanged = false;
        private int? purge2_threshold;
        public int? Purge2Threshold
        {
            get { return purge2_threshold; }
            set
            {
                purge2_threshold = value;
                purge2_thresholdChanged = true;
            }
        }
        private string purge2_thresholdDbString
        {
            get
            {
                if (this.purge2_threshold.HasValue)
                    return purge2_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge2ThresholdSelected
        private bool is_purge2_threshold_selectedChanged = false;
        private bool? is_purge2_threshold_selected;
        public bool? IsPurge2ThresholdSelected
        {
            get { return is_purge2_threshold_selected; }
            set
            {
                is_purge2_threshold_selected = value;
                is_purge2_threshold_selectedChanged = true;
            }
        }
        private string is_purge2_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge2_threshold_selected.HasValue)
                    return is_purge2_threshold_selected.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge3Threshold
        private bool purge3_thresholdChanged = false;
        private int? purge3_threshold;
        public int? Purge3Threshold
        {
            get { return purge3_threshold; }
            set
            {
                purge3_threshold = value;
                purge3_thresholdChanged = true;
            }
        }
        private string purge3_thresholdDbString
        {
            get
            {
                if (this.purge3_threshold.HasValue)
                    return purge3_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge3ThresholdSelected
        private bool is_purge3_threshold_selectedChanged = false;
        private bool? is_purge3_threshold_selected;
        public bool? IsPurge3ThresholdSelected
        {
            get { return is_purge3_threshold_selected; }
            set
            {
                is_purge3_threshold_selected = value;
                is_purge3_threshold_selectedChanged = true;
            }
        }
        private string is_purge3_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge3_threshold_selected.HasValue)
                    return is_purge3_threshold_selected.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge4Threshold
        private bool purge4_thresholdChanged = false;
        private int? purge4_threshold;
        public int? Purge4Threshold
        {
            get { return purge4_threshold; }
            set
            {
                purge4_threshold = value;
                purge4_thresholdChanged = true;
            }
        }
        private string purge4_thresholdDbString
        {
            get
            {
                if (this.purge4_threshold.HasValue)
                    return purge4_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge4ThresholdSelected
        private bool is_purge4_threshold_selectedChanged = false;
        private bool? is_purge4_threshold_selected;
        public bool? IsPurge4ThresholdSelected
        {
            get { return is_purge4_threshold_selected; }
            set
            {
                is_purge4_threshold_selected = value;
                is_purge4_threshold_selectedChanged = true;
            }
        }
        private string is_purge4_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge4_threshold_selected.HasValue)
                    return is_purge4_threshold_selected.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge5Threshold
        private bool purge5_thresholdChanged = false;
        private int? purge5_threshold;
        public int? Purge5Threshold
        {
            get { return purge5_threshold; }
            set
            {
                purge5_threshold = value;
                purge5_thresholdChanged = true;
            }
        }
        private string purge5_thresholdDbString
        {
            get
            {
                if (this.purge5_threshold.HasValue)
                    return purge5_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge5ThresholdSelected
        private bool is_purge5_threshold_selectedChanged = false;
        private bool? is_purge5_threshold_selected;
        public bool? IsPurge5ThresholdSelected
        {
            get { return is_purge5_threshold_selected; }
            set
            {
                is_purge5_threshold_selected = value;
                is_purge5_threshold_selectedChanged = true;
            }
        }
        private string is_purge5_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge5_threshold_selected.HasValue)
                    return is_purge5_threshold_selected.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge6Threshold
        private bool purge6_thresholdChanged = false;
        private int? purge6_threshold;
        public int? Purge6Threshold
        {
            get { return purge6_threshold; }
            set
            {
                purge6_threshold = value;
                purge6_thresholdChanged = true;
            }
        }
        private string purge6_thresholdDbString
        {
            get
            {
                if (this.purge6_threshold.HasValue)
                    return purge6_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge6ThresholdSelected
        private bool is_purge6_threshold_selectedChanged = false;
        private bool? is_purge6_threshold_selected;
        public bool? IsPurge6ThresholdSelected
        {
            get { return is_purge6_threshold_selected; }
            set
            {
                is_purge6_threshold_selected = value;
                is_purge6_threshold_selectedChanged = true;
            }
        }
        private string is_purge6_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge6_threshold_selected.HasValue)
                    return is_purge6_threshold_selected.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Purge7Threshold
        private bool purge7_thresholdChanged = false;
        private int? purge7_threshold;
        public int? Purge7Threshold
        {
            get { return purge7_threshold; }
            set
            {
                purge7_threshold = value;
                purge7_thresholdChanged = true;
            }
        }
        private string purge7_thresholdDbString
        {
            get
            {
                if (this.purge7_threshold.HasValue)
                    return purge7_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsPurge7ThresholdSelected
        private bool is_purge7_threshold_selectedChanged = false;
        private bool? is_purge7_threshold_selected;
        public bool? IsPurge7ThresholdSelected
        {
            get { return is_purge7_threshold_selected; }
            set
            {
                is_purge7_threshold_selected = value;
                is_purge7_threshold_selectedChanged = true;
            }
        }
        private string is_purge7_threshold_selectedDbString
        {
            get
            {
                if (this.is_purge7_threshold_selected.HasValue)
                    return is_purge7_threshold_selected.Value ? "1" : "0";
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
        #region CountsClearRetries
        private bool countsClearRetriesChanged = false;
        private int countsClearRetries;
        public int CountsClearRetries
        {
            get { return countsClearRetries; }
            set
            {
                countsClearRetries = value;
                countsClearRetriesChanged = true;
            }
        }
        private string countsClearRetriesDbString
        {
            get
            {
                return countsClearRetries.ToString();
            }
        }
        #endregion
        #region TCPTimeout
        private bool tCPTimeoutChanged = false;
        private int tCPTimeout;
        public int TCPTimeout
        {
            get { return tCPTimeout; }
            set
            {
                tCPTimeout = value;
                tCPTimeoutChanged = true;
            }
        }
        private string tCPTimeoutDbString
        {
            get
            {
                return tCPTimeout.ToString();
            }
        }
        #endregion
        #region SleepInterval
        private bool sleepIntervalChanged = false;
        private int sleepInterval;
        public int SleepInterval
        {
            get { return sleepInterval; }
            set
            {
                sleepInterval = value;
                sleepIntervalChanged = true;
            }
        }
        private string sleepIntervalDbString
        {
            get
            {
                return sleepInterval.ToString();
            }
        }
        #endregion
        #region CPMCommandWait
        private bool cPMCommandWaitChanged = false;
        private int cPMCommandWait;
        public int CPMCommandWait
        {
            get { return cPMCommandWait; }
            set
            {
                cPMCommandWait = value;
                cPMCommandWaitChanged = true;
            }
        }
        private string cPMCommandWaitDbString
        {
            get
            {
                return cPMCommandWait.ToString();
            }
        }
        #endregion
        #region CPMCommandSleep
        private bool cPMCommandSleepChanged = false;
        private int cPMCommandSleep;
        public int CPMCommandSleep
        {
            get { return cPMCommandSleep; }
            set
            {
                cPMCommandSleep = value;
                cPMCommandSleepChanged = true;
            }
        }
        private string cPMCommandSleepDbString
        {
            get
            {
                return cPMCommandSleep.ToString();
            }
        }
        #endregion
        #region AANDCApplications1
        private bool aANDCApplications1Changed = false;
        private string aANDCApplications1;
        public string AANDCApplications1
        {
            get { return aANDCApplications1; }
            set
            {
                aANDCApplications1 = value;
                aANDCApplications1Changed = true;
            }
        }
        private string aANDCApplications1DbString
        {
            get
            {
                if (this.aANDCApplications1 != null)
                    return string.Format("'{0}'", aANDCApplications1);
                else
                    return "null";
            }
        }
        #endregion
        #region AANDCApplications2
        private bool aANDCApplications2Changed = false;
        private string aANDCApplications2;
        public string AANDCApplications2
        {
            get { return aANDCApplications2; }
            set
            {
                aANDCApplications2 = value;
                aANDCApplications2Changed = true;
            }
        }
        private string aANDCApplications2DbString
        {
            get
            {
                if (this.aANDCApplications2 != null)
                    return string.Format("'{0}'", aANDCApplications2);
                else
                    return "null";
            }
        }
        #endregion
        #region AANDCApplications3
        private bool aANDCApplications3Changed = false;
        private string aANDCApplications3;
        public string AANDCApplications3
        {
            get { return aANDCApplications3; }
            set
            {
                aANDCApplications3 = value;
                aANDCApplications3Changed = true;
            }
        }
        private string aANDCApplications3DbString
        {
            get
            {
                if (this.aANDCApplications3 != null)
                    return string.Format("'{0}'", aANDCApplications3);
                else
                    return "null";
            }
        }
        #endregion
        #region AANDCApplications4
        private bool aANDCApplications4Changed = false;
        private string aANDCApplications4;
        public string AANDCApplications4
        {
            get { return aANDCApplications4; }
            set
            {
                aANDCApplications4 = value;
                aANDCApplications4Changed = true;
            }
        }
        private string aANDCApplications4DbString
        {
            get
            {
                if (this.aANDCApplications4 != null)
                    return string.Format("'{0}'", aANDCApplications4);
                else
                    return "null";
            }
        }
        #endregion
        #region AANDCApplications5
        private bool aANDCApplications5Changed = false;
        private string aANDCApplications5;
        public string AANDCApplications5
        {
            get { return aANDCApplications5; }
            set
            {
                aANDCApplications5 = value;
                aANDCApplications5Changed = true;
            }
        }
        private string aANDCApplications5DbString
        {
            get
            {
                if (this.aANDCApplications5 != null)
                    return string.Format("'{0}'", aANDCApplications5);
                else
                    return "null";
            }
        }
        #endregion
        #region MonitoringRetries
        private bool monitoring_RetriesChanged = false;
        private int monitoring_Retries;
        public int MonitoringRetries
        {
            get { return monitoring_Retries; }
            set
            {
                monitoring_Retries = value;
                monitoring_RetriesChanged = true;
            }
        }
        private string monitoring_RetriesDbString
        {
            get
            {
                return monitoring_Retries.ToString();
            }
        }
        #endregion
        #region WindowSwitchSleep
        private bool windowSwitch_SleepChanged = false;
        private int windowSwitch_Sleep;
        public int WindowSwitchSleep
        {
            get { return windowSwitch_Sleep; }
            set
            {
                windowSwitch_Sleep = value;
                windowSwitch_SleepChanged = true;
            }
        }
        private string windowSwitch_SleepDbString
        {
            get
            {
                return windowSwitch_Sleep.ToString();
            }
        }
        #endregion
        #region AppSwitchSleep
        private bool appSwitch_SleepChanged = false;
        private int appSwitch_Sleep;
        public int AppSwitchSleep
        {
            get { return appSwitch_Sleep; }
            set
            {
                appSwitch_Sleep = value;
                appSwitch_SleepChanged = true;
            }
        }
        private string appSwitch_SleepDbString
        {
            get
            {
                return appSwitch_Sleep.ToString();
            }
        }
        #endregion
        #region MonitoringCycleSleep
        private bool monitoringCycle_SleepChanged = false;
        private int monitoringCycle_Sleep;
        public int MonitoringCycleSleep
        {
            get { return monitoringCycle_Sleep; }
            set
            {
                monitoringCycle_Sleep = value;
                monitoringCycle_SleepChanged = true;
            }
        }
        private string monitoringCycle_SleepDbString
        {
            get
            {
                return monitoringCycle_Sleep.ToString();
            }
        }
        #endregion
        #region CPMLogLevel
        private bool cPMLogLevelChanged = false;
        private int cPMLogLevel;
        public int CPMLogLevel
        {
            get { return cPMLogLevel; }
            set
            {
                cPMLogLevel = value;
                cPMLogLevelChanged = true;
            }
        }
        private string cPMLogLevelDbString
        {
            get
            {
                return cPMLogLevel.ToString();
            }
        }
        #endregion
        #region IsDispenserRealTimeNotificationEnabled
        private bool isDispenserRealTimeNotificationEnabledChanged = false;
        private bool isDispenserRealTimeNotificationEnabled;
        public bool IsDispenserRealTimeNotificationEnabled
        {
            get { return isDispenserRealTimeNotificationEnabled; }
            set
            {
                isDispenserRealTimeNotificationEnabled = value;
                isDispenserRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isDispenserRealTimeNotificationEnabledDbString
        {
            get
            {
                return isDispenserRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsBNARealTimeNotificationEnabled
        private bool isBNARealTimeNotificationEnabledChanged = false;
        private bool isBNARealTimeNotificationEnabled;
        public bool IsBNARealTimeNotificationEnabled
        {
            get { return isBNARealTimeNotificationEnabled; }
            set
            {
                isBNARealTimeNotificationEnabled = value;
                isBNARealTimeNotificationEnabledChanged = true;
            }
        }
        private string isBNARealTimeNotificationEnabledDbString
        {
            get
            {
                return isBNARealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsCPMRealTimeNotificationEnabled
        private bool isCPMRealTimeNotificationEnabledChanged = false;
        private bool isCPMRealTimeNotificationEnabled;
        public bool IsCPMRealTimeNotificationEnabled
        {
            get { return isCPMRealTimeNotificationEnabled; }
            set
            {
                isCPMRealTimeNotificationEnabled = value;
                isCPMRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isCPMRealTimeNotificationEnabledDbString
        {
            get
            {
                return isCPMRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsReplenishmentRealTimeNotificationEnabled
        private bool isReplenishmentRealTimeNotificationEnabledChanged = false;
        private bool isReplenishmentRealTimeNotificationEnabled;
        public bool IsReplenishmentRealTimeNotificationEnabled
        {
            get { return isReplenishmentRealTimeNotificationEnabled; }
            set
            {
                isReplenishmentRealTimeNotificationEnabled = value;
                isReplenishmentRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isReplenishmentRealTimeNotificationEnabledDbString
        {
            get
            {
                return isReplenishmentRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsOutOfCashRealTimeNotificationEnabled
        private bool isOutOfCashRealTimeNotificationEnabledChanged = false;
        private bool isOutOfCashRealTimeNotificationEnabled;
        public bool IsOutOfCashRealTimeNotificationEnabled
        {
            get { return isOutOfCashRealTimeNotificationEnabled; }
            set
            {
                isOutOfCashRealTimeNotificationEnabled = value;
                isOutOfCashRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isOutOfCashRealTimeNotificationEnabledDbString
        {
            get
            {
                return isOutOfCashRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsDispenserMismatchRealTimeNotificationEnabled
        private bool isDispenserMismatchRealTimeNotificationEnabledChanged = false;
        private bool isDispenserMismatchRealTimeNotificationEnabled;
        public bool IsDispenserMismatchRealTimeNotificationEnabled
        {
            get { return isDispenserMismatchRealTimeNotificationEnabled; }
            set
            {
                isDispenserMismatchRealTimeNotificationEnabled = value;
                isDispenserMismatchRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isDispenserMismatchRealTimeNotificationEnabledDbString
        {
            get
            {
                return isDispenserMismatchRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsBNAMismatchRealTimeNotificationEnabled
        private bool isBNAMismatchRealTimeNotificationEnabledChanged = false;
        private bool isBNAMismatchRealTimeNotificationEnabled;
        public bool IsBNAMismatchRealTimeNotificationEnabled
        {
            get { return isBNAMismatchRealTimeNotificationEnabled; }
            set
            {
                isBNAMismatchRealTimeNotificationEnabled = value;
                isBNAMismatchRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isBNAMismatchRealTimeNotificationEnabledDbString
        {
            get
            {
                return isBNAMismatchRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsCPMMismatchRealTimeNotificationEnabled
        private bool isCPMMismatchRealTimeNotificationEnabledChanged = false;
        private bool isCPMMismatchRealTimeNotificationEnabled;
        public bool IsCPMMismatchRealTimeNotificationEnabled
        {
            get { return isCPMMismatchRealTimeNotificationEnabled; }
            set
            {
                isCPMMismatchRealTimeNotificationEnabled = value;
                isCPMMismatchRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isCPMMismatchRealTimeNotificationEnabledDbString
        {
            get
            {
                return isCPMMismatchRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region IsCounterExplodedRealTimeNotificationEnabled
        private bool isCounterExplodedRealTimeNotificationEnabledChanged = false;
        private bool isCounterExplodedRealTimeNotificationEnabled;
        public bool IsCounterExplodedRealTimeNotificationEnabled
        {
            get { return isCounterExplodedRealTimeNotificationEnabled; }
            set
            {
                isCounterExplodedRealTimeNotificationEnabled = value;
                isCounterExplodedRealTimeNotificationEnabledChanged = true;
            }
        }
        private string isCounterExplodedRealTimeNotificationEnabledDbString
        {
            get
            {
                return isCounterExplodedRealTimeNotificationEnabled ? "1" : "0";
            }
        }
        #endregion
        #region Type1MinimumNotes
        private bool type1MinimumNotesChanged = false;
        private int type1MinimumNotes;
        public int Type1MinimumNotes
        {
            get { return type1MinimumNotes; }
            set
            {
                type1MinimumNotes = value;
                type1MinimumNotesChanged = true;
            }
        }
        private string type1MinimumNotesDbString
        {
            get
            {
                return type1MinimumNotes.ToString();
            }
        }
        #endregion
        #region Type2MinimumNotes
        private bool type2MinimumNotesChanged = false;
        private int type2MinimumNotes;
        public int Type2MinimumNotes
        {
            get { return type2MinimumNotes; }
            set
            {
                type2MinimumNotes = value;
                type2MinimumNotesChanged = true;
            }
        }
        private string type2MinimumNotesDbString
        {
            get
            {
                return type2MinimumNotes.ToString();
            }
        }
        #endregion
        #region Type3MinimumNotes
        private bool type3MinimumNotesChanged = false;
        private int type3MinimumNotes;
        public int Type3MinimumNotes
        {
            get { return type3MinimumNotes; }
            set
            {
                type3MinimumNotes = value;
                type3MinimumNotesChanged = true;
            }
        }
        private string type3MinimumNotesDbString
        {
            get
            {
                return type3MinimumNotes.ToString();
            }
        }
        #endregion
        #region Type4MinimumNotes
        private bool type4MinimumNotesChanged = false;
        private int type4MinimumNotes;
        public int Type4MinimumNotes
        {
            get { return type4MinimumNotes; }
            set
            {
                type4MinimumNotes = value;
                type4MinimumNotesChanged = true;
            }
        }
        private string type4MinimumNotesDbString
        {
            get
            {
                return type4MinimumNotes.ToString();
            }
        }
        #endregion
        #region Type5MinimumNotes
        private bool type5MinimumNotesChanged = false;
        private int type5MinimumNotes;
        public int Type5MinimumNotes
        {
            get { return type5MinimumNotes; }
            set
            {
                type5MinimumNotes = value;
                type5MinimumNotesChanged = true;
            }
        }
        private string type5MinimumNotesDbString
        {
            get
            {
                return type5MinimumNotes.ToString();
            }
        }
        #endregion
        #region Type6MinimumNotes
        private bool type6MinimumNotesChanged = false;
        private int type6MinimumNotes;
        public int Type6MinimumNotes
        {
            get { return type6MinimumNotes; }
            set
            {
                type6MinimumNotes = value;
                type6MinimumNotesChanged = true;
            }
        }
        private string type6MinimumNotesDbString
        {
            get
            {
                return type6MinimumNotes.ToString();
            }
        }
        #endregion
        #region Type7MinimumNotes
        private bool type7MinimumNotesChanged = false;
        private int type7MinimumNotes;
        public int Type7MinimumNotes
        {
            get { return type7MinimumNotes; }
            set
            {
                type7MinimumNotes = value;
                type7MinimumNotesChanged = true;
            }
        }
        private string type7MinimumNotesDbString
        {
            get
            {
                return type7MinimumNotes.ToString();
            }
        }
        #endregion
        #region CpmCommand
        private bool cpm_commandChanged = false;
        private string cpm_command;
        public string CpmCommand
        {
            get { return cpm_command; }
            set
            {
                cpm_command = value;
                cpm_commandChanged = true;
            }
        }
        private string cpm_commandDbString
        {
            get
            {
                if (this.cpm_command != null)
                    return string.Format("'{0}'", cpm_command);
                else
                    return "null";
            }
        }
        #endregion
        #region AllowedInactivityPeriod
        private bool allowed_inactivity_periodChanged = false;
        private int? allowed_inactivity_period;
        public int? AllowedInactivityPeriod
        {
            get { return allowed_inactivity_period; }
            set
            {
                allowed_inactivity_period = value;
                allowed_inactivity_periodChanged = true;
            }
        }
        private string allowed_inactivity_periodDbString
        {
            get
            {
                if (this.allowed_inactivity_period.HasValue)
                    return allowed_inactivity_period.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region GlNumber
        private bool gl_numberChanged = false;
        private string gl_number;
        public string GlNumber
        {
            get { return gl_number; }
            set
            {
                gl_number = value;
                gl_numberChanged = true;
            }
        }
        private string gl_numberDbString
        {
            get
            {
                if (this.gl_number != null)
                    return string.Format("'{0}'", gl_number);
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
            set
            {
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
            set
            {
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
            set
            {
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
            set
            {
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
            set
            {
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
        #region Description
        private bool descriptionChanged = false;
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                descriptionChanged = true;
            }
        }
        private string descriptionDbString
        {
            get
            {
                if (this.description != null)
                    return string.Format("'{0}'", description);
                else
                    return "null";
            }
        }
        #endregion
        #region IsDffGenerationHalt
        private bool is_dff_generation_haltChanged = false;
        private bool? is_dff_generation_halt;
        public bool? IsDffGenerationHalt
        {
            get { return is_dff_generation_halt; }
            set
            {
                is_dff_generation_halt = value;
                is_dff_generation_haltChanged = true;
            }
        }
        private string is_dff_generation_haltDbString
        {
            get
            {
                if (this.is_dff_generation_halt.HasValue)
                    return is_dff_generation_halt.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region CitAtmTitle
        private bool cit_atm_titleChanged = false;
        private string cit_atm_title;
        public string CitAtmTitle
        {
            get { return cit_atm_title; }
            set
            {
                cit_atm_title = value;
                cit_atm_titleChanged = true;
            }
        }
        private string cit_atm_titleDbString
        {
            get
            {
                if (this.cit_atm_title != null)
                    return string.Format("'{0}'", cit_atm_title);
                else
                    return "null";
            }
        }
        #endregion
        #region ChequeAllowedInactivityPeriod
        private bool cheque_allowed_inactivity_periodChanged = false;
        private int? cheque_allowed_inactivity_period;
        public int? ChequeAllowedInactivityPeriod
        {
            get { return cheque_allowed_inactivity_period; }
            set
            {
                cheque_allowed_inactivity_period = value;
                cheque_allowed_inactivity_periodChanged = true;
            }
        }
        private string cheque_allowed_inactivity_periodDbString
        {
            get
            {
                if (this.cheque_allowed_inactivity_period.HasValue)
                    return cheque_allowed_inactivity_period.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region BnaAllowedInactivityPeriod
        private bool bna_allowed_inactivity_periodChanged = false;
        private int? bna_allowed_inactivity_period;
        public int? BnaAllowedInactivityPeriod
        {
            get { return bna_allowed_inactivity_period; }
            set
            {
                bna_allowed_inactivity_period = value;
                bna_allowed_inactivity_periodChanged = true;
            }
        }
        private string bna_allowed_inactivity_periodDbString
        {
            get
            {
                if (this.bna_allowed_inactivity_period.HasValue)
                    return bna_allowed_inactivity_period.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region OutOfCashThreshold
        private bool out_of_cash_thresholdChanged = false;
        private int out_of_cash_threshold;
        public int OutOfCashThreshold
        {
            get { return out_of_cash_threshold; }
            set
            {
                out_of_cash_threshold = value;
                out_of_cash_thresholdChanged = true;
            }
        }
        private string out_of_cash_thresholdDbString
        {
            get
            {
                return out_of_cash_threshold.ToString();
            }
        }
        #endregion
        #region NoOfDispensedTransactionsToMonitor
        private bool no_of_dispensed_transactions_to_monitorChanged = false;
        private int? no_of_dispensed_transactions_to_monitor;
        public int? NoOfDispensedTransactionsToMonitor
        {
            get { return no_of_dispensed_transactions_to_monitor; }
            set
            {
                no_of_dispensed_transactions_to_monitor = value;
                no_of_dispensed_transactions_to_monitorChanged = true;
            }
        }
        private string no_of_dispensed_transactions_to_monitorDbString
        {
            get
            {
                if (this.no_of_dispensed_transactions_to_monitor.HasValue)
                    return no_of_dispensed_transactions_to_monitor.ToString();
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
            set
            {
                is_ej_enabled = value;
                is_ej_enabledChanged = true;
            }
        }
        private string is_ej_enabledDbString
        {
            get
            {
                return is_ej_enabled ? "1" : "0";
            }
        }
        #endregion
        #region IsCounterEnabled
        private bool is_counter_enabledChanged = false;
        private bool is_counter_enabled;
        public bool IsCounterEnabled
        {
            get { return is_counter_enabled; }
            set
            {
                is_counter_enabled = value;
                is_counter_enabledChanged = true;
            }
        }
        private string is_counter_enabledDbString
        {
            get
            {
                return is_counter_enabled ? "1" : "0";
            }
        }
        #endregion
        #region Priority
        private bool priorityChanged = false;
        private int priority;
        public int Priority
        {
            get { return priority; }
            set
            {
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
        #region Longitude
        private bool longitudeChanged = false;
        private string longitude;
        public string Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                longitudeChanged = true;
            }
        }
        private string longitudeDbString
        {
            get
            {
                if (this.longitude != null)
                    return string.Format("'{0}'", longitude);
                else
                    return "null";
            }
        }
        #endregion
        #region Latitude
        private bool latitudeChanged = false;
        private string latitude;
        public string Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                latitudeChanged = true;
            }
        }
        private string latitudeDbString
        {
            get
            {
                if (this.latitude != null)
                    return string.Format("'{0}'", latitude);
                else
                    return "null";
            }
        }
        #endregion
        #region OnUsAmount
        private bool on_us_amountChanged = false;
        private decimal? on_us_amount;
        public decimal? OnUsAmount
        {
            get { return on_us_amount; }
            set
            {
                on_us_amount = value;
                on_us_amountChanged = true;
            }
        }
        private string on_us_amountDbString
        {
            get
            {
                if (this.on_us_amount.HasValue)
                    return on_us_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotOnUsAmount
        private bool not_on_us_amountChanged = false;
        private decimal? not_on_us_amount;
        public decimal? NotOnUsAmount
        {
            get { return not_on_us_amount; }
            set
            {
                not_on_us_amount = value;
                not_on_us_amountChanged = true;
            }
        }
        private string not_on_us_amountDbString
        {
            get
            {
                if (this.not_on_us_amount.HasValue)
                    return not_on_us_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType1
        private bool standard_order_type1Changed = false;
        private int? standard_order_type1;
        public int? StandardOrderType1
        {
            get { return standard_order_type1; }
            set
            {
                standard_order_type1 = value;
                standard_order_type1Changed = true;
            }
        }
        private string standard_order_type1DbString
        {
            get
            {
                if (this.standard_order_type1.HasValue)
                    return standard_order_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType2
        private bool standard_order_type2Changed = false;
        private int? standard_order_type2;
        public int? StandardOrderType2
        {
            get { return standard_order_type2; }
            set
            {
                standard_order_type2 = value;
                standard_order_type2Changed = true;
            }
        }
        private string standard_order_type2DbString
        {
            get
            {
                if (this.standard_order_type2.HasValue)
                    return standard_order_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType3
        private bool standard_order_type3Changed = false;
        private int? standard_order_type3;
        public int? StandardOrderType3
        {
            get { return standard_order_type3; }
            set
            {
                standard_order_type3 = value;
                standard_order_type3Changed = true;
            }
        }
        private string standard_order_type3DbString
        {
            get
            {
                if (this.standard_order_type3.HasValue)
                    return standard_order_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType4
        private bool standard_order_type4Changed = false;
        private int? standard_order_type4;
        public int? StandardOrderType4
        {
            get { return standard_order_type4; }
            set
            {
                standard_order_type4 = value;
                standard_order_type4Changed = true;
            }
        }
        private string standard_order_type4DbString
        {
            get
            {
                if (this.standard_order_type4.HasValue)
                    return standard_order_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType5
        private bool standard_order_type5Changed = false;
        private int? standard_order_type5;
        public int? StandardOrderType5
        {
            get { return standard_order_type5; }
            set
            {
                standard_order_type5 = value;
                standard_order_type5Changed = true;
            }
        }
        private string standard_order_type5DbString
        {
            get
            {
                if (this.standard_order_type5.HasValue)
                    return standard_order_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType6
        private bool standard_order_type6Changed = false;
        private int? standard_order_type6;
        public int? StandardOrderType6
        {
            get { return standard_order_type6; }
            set
            {
                standard_order_type6 = value;
                standard_order_type6Changed = true;
            }
        }
        private string standard_order_type6DbString
        {
            get
            {
                if (this.standard_order_type6.HasValue)
                    return standard_order_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region StandardOrderType7
        private bool standard_order_type7Changed = false;
        private int? standard_order_type7;
        public int? StandardOrderType7
        {
            get { return standard_order_type7; }
            set
            {
                standard_order_type7 = value;
                standard_order_type7Changed = true;
            }
        }
        private string standard_order_type7DbString
        {
            get
            {
                if (this.standard_order_type7.HasValue)
                    return standard_order_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ProtocolTypeId
        private bool protocol_type_idChanged = false;
        private int protocol_type_id;
        public int ProtocolTypeId
        {
            get { return protocol_type_id; }
            set
            {
                protocol_type_id = value;
                protocol_type_idChanged = true;
            }
        }
        private string protocol_type_idDbString
        {
            get
            {
                return protocol_type_id.ToString();
            }
        }
        #endregion
        #region CurrentMode
        private bool current_modeChanged = false;
        private byte current_mode;
        public byte CurrentMode
        {
            get { return current_mode; }
            set
            {
                current_mode = value;
                current_modeChanged = true;
            }
        }
        private string current_modeDbString
        {
            get
            {
                return current_mode.ToString();
            }
        }
        #endregion
        #region AggregateState
        private bool aggregate_stateChanged = false;
        private byte aggregate_state;
        public byte AggregateState
        {
            get { return aggregate_state; }
            set
            {
                aggregate_state = value;
                aggregate_stateChanged = true;
            }
        }
        private string aggregate_stateDbString
        {
            get
            {
                return aggregate_state.ToString();
            }
        }
        #endregion
        #region LastBootTime
        private bool last_boot_timeChanged = false;
        private DateTime? last_boot_time;
        public DateTime? LastBootTime
        {
            get { return last_boot_time; }
            set
            {
                last_boot_time = value;
                last_boot_timeChanged = true;
            }
        }
        private string last_boot_timeDbString
        {
            get
            {
                if (this.last_boot_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_boot_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region DiscoveryTime
        private bool discovery_timeChanged = false;
        private DateTime? discovery_time;
        public DateTime? DiscoveryTime
        {
            get { return discovery_time; }
            set
            {
                discovery_time = value;
                discovery_timeChanged = true;
            }
        }
        private string discovery_timeDbString
        {
            get
            {
                if (this.discovery_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", discovery_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region LastScanTime
        private bool last_scan_timeChanged = false;
        private DateTime? last_scan_time;
        public DateTime? LastScanTime
        {
            get { return last_scan_time; }
            set
            {
                last_scan_time = value;
                last_scan_timeChanged = true;
            }
        }
        private string last_scan_timeDbString
        {
            get
            {
                if (this.last_scan_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_scan_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CommunicationStatus
        private bool communication_statusChanged = false;
        private byte communication_status;
        public byte CommunicationStatus
        {
            get { return communication_status; }
            set
            {
                communication_status = value;
                communication_statusChanged = true;
            }
        }
        private string communication_statusDbString
        {
            get
            {
                return communication_status.ToString();
            }
        }
        #endregion
        #region IsCritical
        private bool is_criticalChanged = false;
        private bool is_critical;
        public bool IsCritical
        {
            get { return is_critical; }
            set
            {
                is_critical = value;
                is_criticalChanged = true;
            }
        }
        private string is_criticalDbString
        {
            get
            {
                return is_critical ? "1" : "0";
            }
        }
        #endregion
        #region CurrentModeModifiedOn
        private bool current_mode_modified_onChanged = false;
        private DateTime? current_mode_modified_on;
        public DateTime? CurrentModeModifiedOn
        {
            get { return current_mode_modified_on; }
            set
            {
                current_mode_modified_on = value;
                current_mode_modified_onChanged = true;
            }
        }
        private string current_mode_modified_onDbString
        {
            get
            {
                if (this.current_mode_modified_on.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", current_mode_modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region LastNotificationReceivedOn
        private bool last_Notification_Received_OnChanged = false;
        private DateTime? last_Notification_Received_On;
        public DateTime? LastNotificationReceivedOn
        {
            get { return last_Notification_Received_On; }
            set
            {
                last_Notification_Received_On = value;
                last_Notification_Received_OnChanged = true;
            }
        }
        private string last_Notification_Received_OnDbString
        {
            get
            {
                if (this.last_Notification_Received_On.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_Notification_Received_On.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region LastNotificationTime
        private bool last_Notification_TimeChanged = false;
        private DateTime? last_Notification_Time;
        public DateTime? LastNotificationTime
        {
            get { return last_Notification_Time; }
            set
            {
                last_Notification_Time = value;
                last_Notification_TimeChanged = true;
            }
        }
        private string last_Notification_TimeDbString
        {
            get
            {
                if (this.last_Notification_Time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_Notification_Time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region NormalOrderCost
        private bool normal_order_costChanged = false;
        private decimal? normal_order_cost;
        public decimal? NormalOrderCost
        {
            get { return normal_order_cost; }
            set
            {
                normal_order_cost = value;
                normal_order_costChanged = true;
            }
        }
        private string normal_order_costDbString
        {
            get
            {
                if (this.normal_order_cost.HasValue)
                    return normal_order_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EmergencyOrderCost
        private bool emergency_order_costChanged = false;
        private decimal? emergency_order_cost;
        public decimal? EmergencyOrderCost
        {
            get { return emergency_order_cost; }
            set
            {
                emergency_order_cost = value;
                emergency_order_costChanged = true;
            }
        }
        private string emergency_order_costDbString
        {
            get
            {
                if (this.emergency_order_cost.HasValue)
                    return emergency_order_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReceiptTransactionCutoff
        private bool receipt_transaction_cutoffChanged = false;
        private int? receipt_transaction_cutoff;
        public int? ReceiptTransactionCutoff
        {
            get { return receipt_transaction_cutoff; }
            set
            {
                receipt_transaction_cutoff = value;
                receipt_transaction_cutoffChanged = true;
            }
        }
        private string receipt_transaction_cutoffDbString
        {
            get
            {
                if (this.receipt_transaction_cutoff.HasValue)
                    return receipt_transaction_cutoff.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsSwapDefaultReplenishment
        private bool is_swap_default_replenishmentChanged = false;
        private bool? is_swap_default_replenishment;
        public bool? IsSwapDefaultReplenishment
        {
            get { return is_swap_default_replenishment; }
            set
            {
                is_swap_default_replenishment = value;
                is_swap_default_replenishmentChanged = true;
            }
        }
        private string is_swap_default_replenishmentDbString
        {
            get
            {
                if (this.is_swap_default_replenishment.HasValue)
                    return is_swap_default_replenishment.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region MessageProcessorId
        private bool message_processor_idChanged = false;
        private int? message_processor_id;
        public int? MessageProcessorId
        {
            get { return message_processor_id; }
            set
            {
                message_processor_id = value;
                message_processor_idChanged = true;
            }
        }
        private string message_processor_idDbString
        {
            get
            {
                if (this.message_processor_id.HasValue)
                    return message_processor_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region LastPingStatus
        private bool last_ping_statusChanged = false;
        private string last_ping_status;
        public string LastPingStatus
        {
            get { return last_ping_status; }
            set
            {
                last_ping_status = value;
                last_ping_statusChanged = true;
            }
        }
        private string last_ping_statusDbString
        {
            get
            {
                if (this.last_ping_status != null)
                    return string.Format("'{0}'", last_ping_status);
                else
                    return "null";
            }
        }
        #endregion
        #region LastPingExecutedAt
        private bool last_ping_executed_atChanged = false;
        private DateTime? last_ping_executed_at;
        public DateTime? LastPingExecutedAt
        {
            get { return last_ping_executed_at; }
            set
            {
                last_ping_executed_at = value;
                last_ping_executed_atChanged = true;
            }
        }
        private string last_ping_executed_atDbString
        {
            get
            {
                if (this.last_ping_executed_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_ping_executed_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region LastTelnetStatus
        private bool last_telnet_statusChanged = false;
        private string last_telnet_status;
        public string LastTelnetStatus
        {
            get { return last_telnet_status; }
            set
            {
                last_telnet_status = value;
                last_telnet_statusChanged = true;
            }
        }
        private string last_telnet_statusDbString
        {
            get
            {
                if (this.last_telnet_status != null)
                    return string.Format("'{0}'", last_telnet_status);
                else
                    return "null";
            }
        }
        #endregion
        #region LastTelnetExecutedAt
        private bool last_telnet_executed_atChanged = false;
        private DateTime? last_telnet_executed_at;
        public DateTime? LastTelnetExecutedAt
        {
            get { return last_telnet_executed_at; }
            set
            {
                last_telnet_executed_at = value;
                last_telnet_executed_atChanged = true;
            }
        }
        private string last_telnet_executed_atDbString
        {
            get
            {
                if (this.last_telnet_executed_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_telnet_executed_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region LastArchiveFileReceivedAt
        private bool last_archive_file_received_atChanged = false;
        private DateTime? last_archive_file_received_at;
        public DateTime? LastArchiveFileReceivedAt
        {
            get { return last_archive_file_received_at; }
            set
            {
                last_archive_file_received_at = value;
                last_archive_file_received_atChanged = true;
            }
        }
        private string last_archive_file_received_atDbString
        {
            get
            {
                if (this.last_archive_file_received_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", last_archive_file_received_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region IsSdm
        private bool is_sdmChanged = false;
        private bool is_sdm;
        public bool IsSdm
        {
            get { return is_sdm; }
            set
            {
                is_sdm = value;
                is_sdmChanged = true;
            }
        }
        private string is_sdmDbString
        {
            get
            {
                return is_sdm ? "1" : "0";
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
        #region CcmsagentLastReportedHeartbeat
        private bool ccmsagent_last_reported_heartbeatChanged = false;
        private DateTime? ccmsagent_last_reported_heartbeat;
        public DateTime? CcmsagentLastReportedHeartbeat
        {
            get { return ccmsagent_last_reported_heartbeat; }
            set
            {
                ccmsagent_last_reported_heartbeat = value;
                ccmsagent_last_reported_heartbeatChanged = true;
            }
        }
        private string ccmsagent_last_reported_heartbeatDbString
        {
            get
            {
                if (this.ccmsagent_last_reported_heartbeat.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", ccmsagent_last_reported_heartbeat.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region CcmsservicemanagerLastReportedHeartbeat
        private bool ccmsservicemanager_last_reported_heartbeatChanged = false;
        private DateTime? ccmsservicemanager_last_reported_heartbeat;
        public DateTime? CcmsservicemanagerLastReportedHeartbeat
        {
            get { return ccmsservicemanager_last_reported_heartbeat; }
            set
            {
                ccmsservicemanager_last_reported_heartbeat = value;
                ccmsservicemanager_last_reported_heartbeatChanged = true;
            }
        }
        private string ccmsservicemanager_last_reported_heartbeatDbString
        {
            get
            {
                if (this.ccmsservicemanager_last_reported_heartbeat.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", ccmsservicemanager_last_reported_heartbeat.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region DistributionPort
        private bool distribution_portChanged = false;
        private int? distribution_port;
        public int? DistributionPort
        {
            get { return distribution_port; }
            set
            {
                distribution_port = value;
                distribution_portChanged = true;
            }
        }
        private string distribution_portDbString
        {
            get
            {
                if (this.distribution_port.HasValue)
                    return distribution_port.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ParserRepDateFormat
        private bool parser_rep_date_formatChanged = false;
        private string parser_rep_date_format;
        public string ParserRepDateFormat
        {
            get { return parser_rep_date_format; }
            set
            {
                parser_rep_date_format = value;
                parser_rep_date_formatChanged = true;
            }
        }
        private string parser_rep_date_formatDbString
        {
            get
            {
                if (this.parser_rep_date_format != null)
                    return string.Format("'{0}'", parser_rep_date_format);
                else
                    return "null";
            }
        }
        #endregion
        #region Type1MinNotesThreshold
        private bool type1_min_notes_thresholdChanged = false;
        private int? type1_min_notes_threshold;
        public int? Type1MinNotesThreshold
        {
            get { return type1_min_notes_threshold; }
            set
            {
                type1_min_notes_threshold = value;
                type1_min_notes_thresholdChanged = true;
            }
        }
        private string type1_min_notes_thresholdDbString
        {
            get
            {
                if (this.type1_min_notes_threshold.HasValue)
                    return type1_min_notes_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type2MinNotesThreshold
        private bool type2_min_notes_thresholdChanged = false;
        private int? type2_min_notes_threshold;
        public int? Type2MinNotesThreshold
        {
            get { return type2_min_notes_threshold; }
            set
            {
                type2_min_notes_threshold = value;
                type2_min_notes_thresholdChanged = true;
            }
        }
        private string type2_min_notes_thresholdDbString
        {
            get
            {
                if (this.type2_min_notes_threshold.HasValue)
                    return type2_min_notes_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type3MinNotesThreshold
        private bool type3_min_notes_thresholdChanged = false;
        private int? type3_min_notes_threshold;
        public int? Type3MinNotesThreshold
        {
            get { return type3_min_notes_threshold; }
            set
            {
                type3_min_notes_threshold = value;
                type3_min_notes_thresholdChanged = true;
            }
        }
        private string type3_min_notes_thresholdDbString
        {
            get
            {
                if (this.type3_min_notes_threshold.HasValue)
                    return type3_min_notes_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type4MinNotesThreshold
        private bool type4_min_notes_thresholdChanged = false;
        private int? type4_min_notes_threshold;
        public int? Type4MinNotesThreshold
        {
            get { return type4_min_notes_threshold; }
            set
            {
                type4_min_notes_threshold = value;
                type4_min_notes_thresholdChanged = true;
            }
        }
        private string type4_min_notes_thresholdDbString
        {
            get
            {
                if (this.type4_min_notes_threshold.HasValue)
                    return type4_min_notes_threshold.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type1SuggestedNotesNormalDays
        private bool type1_suggested_notes_normal_daysChanged = false;
        private int? type1_suggested_notes_normal_days;
        public int? Type1SuggestedNotesNormalDays
        {
            get { return type1_suggested_notes_normal_days; }
            set
            {
                type1_suggested_notes_normal_days = value;
                type1_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type1_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type1_suggested_notes_normal_days.HasValue)
                    return type1_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type2SuggestedNotesNormalDays
        private bool type2_suggested_notes_normal_daysChanged = false;
        private int? type2_suggested_notes_normal_days;
        public int? Type2SuggestedNotesNormalDays
        {
            get { return type2_suggested_notes_normal_days; }
            set
            {
                type2_suggested_notes_normal_days = value;
                type2_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type2_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type2_suggested_notes_normal_days.HasValue)
                    return type2_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type3SuggestedNotesNormalDays
        private bool type3_suggested_notes_normal_daysChanged = false;
        private int? type3_suggested_notes_normal_days;
        public int? Type3SuggestedNotesNormalDays
        {
            get { return type3_suggested_notes_normal_days; }
            set
            {
                type3_suggested_notes_normal_days = value;
                type3_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type3_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type3_suggested_notes_normal_days.HasValue)
                    return type3_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type4SuggestedNotesNormalDays
        private bool type4_suggested_notes_normal_daysChanged = false;
        private int? type4_suggested_notes_normal_days;
        public int? Type4SuggestedNotesNormalDays
        {
            get { return type4_suggested_notes_normal_days; }
            set
            {
                type4_suggested_notes_normal_days = value;
                type4_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type4_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type4_suggested_notes_normal_days.HasValue)
                    return type4_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type5SuggestedNotesNormalDays
        private bool type5_suggested_notes_normal_daysChanged = false;
        private int? type5_suggested_notes_normal_days;
        public int? Type5SuggestedNotesNormalDays
        {
            get { return type5_suggested_notes_normal_days; }
            set
            {
                type5_suggested_notes_normal_days = value;
                type5_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type5_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type5_suggested_notes_normal_days.HasValue)
                    return type5_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type6SuggestedNotesNormalDays
        private bool type6_suggested_notes_normal_daysChanged = false;
        private int? type6_suggested_notes_normal_days;
        public int? Type6SuggestedNotesNormalDays
        {
            get { return type6_suggested_notes_normal_days; }
            set
            {
                type6_suggested_notes_normal_days = value;
                type6_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type6_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type6_suggested_notes_normal_days.HasValue)
                    return type6_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type7SuggestedNotesNormalDays
        private bool type7_suggested_notes_normal_daysChanged = false;
        private int? type7_suggested_notes_normal_days;
        public int? Type7SuggestedNotesNormalDays
        {
            get { return type7_suggested_notes_normal_days; }
            set
            {
                type7_suggested_notes_normal_days = value;
                type7_suggested_notes_normal_daysChanged = true;
            }
        }
        private string type7_suggested_notes_normal_daysDbString
        {
            get
            {
                if (this.type7_suggested_notes_normal_days.HasValue)
                    return type7_suggested_notes_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type1SuggestedNotesSalaryDays
        private bool type1_suggested_notes_salary_daysChanged = false;
        private int? type1_suggested_notes_salary_days;
        public int? Type1SuggestedNotesSalaryDays
        {
            get { return type1_suggested_notes_salary_days; }
            set
            {
                type1_suggested_notes_salary_days = value;
                type1_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type1_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type1_suggested_notes_salary_days.HasValue)
                    return type1_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type2SuggestedNotesSalaryDays
        private bool type2_suggested_notes_salary_daysChanged = false;
        private int? type2_suggested_notes_salary_days;
        public int? Type2SuggestedNotesSalaryDays
        {
            get { return type2_suggested_notes_salary_days; }
            set
            {
                type2_suggested_notes_salary_days = value;
                type2_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type2_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type2_suggested_notes_salary_days.HasValue)
                    return type2_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type3SuggestedNotesSalaryDays
        private bool type3_suggested_notes_salary_daysChanged = false;
        private int? type3_suggested_notes_salary_days;
        public int? Type3SuggestedNotesSalaryDays
        {
            get { return type3_suggested_notes_salary_days; }
            set
            {
                type3_suggested_notes_salary_days = value;
                type3_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type3_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type3_suggested_notes_salary_days.HasValue)
                    return type3_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type4SuggestedNotesSalaryDays
        private bool type4_suggested_notes_salary_daysChanged = false;
        private int? type4_suggested_notes_salary_days;
        public int? Type4SuggestedNotesSalaryDays
        {
            get { return type4_suggested_notes_salary_days; }
            set
            {
                type4_suggested_notes_salary_days = value;
                type4_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type4_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type4_suggested_notes_salary_days.HasValue)
                    return type4_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type5SuggestedNotesSalaryDays
        private bool type5_suggested_notes_salary_daysChanged = false;
        private int? type5_suggested_notes_salary_days;
        public int? Type5SuggestedNotesSalaryDays
        {
            get { return type5_suggested_notes_salary_days; }
            set
            {
                type5_suggested_notes_salary_days = value;
                type5_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type5_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type5_suggested_notes_salary_days.HasValue)
                    return type5_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type6SuggestedNotesSalaryDays
        private bool type6_suggested_notes_salary_daysChanged = false;
        private int? type6_suggested_notes_salary_days;
        public int? Type6SuggestedNotesSalaryDays
        {
            get { return type6_suggested_notes_salary_days; }
            set
            {
                type6_suggested_notes_salary_days = value;
                type6_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type6_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type6_suggested_notes_salary_days.HasValue)
                    return type6_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type7SuggestedNotesSalaryDays
        private bool type7_suggested_notes_salary_daysChanged = false;
        private int? type7_suggested_notes_salary_days;
        public int? Type7SuggestedNotesSalaryDays
        {
            get { return type7_suggested_notes_salary_days; }
            set
            {
                type7_suggested_notes_salary_days = value;
                type7_suggested_notes_salary_daysChanged = true;
            }
        }
        private string type7_suggested_notes_salary_daysDbString
        {
            get
            {
                if (this.type7_suggested_notes_salary_days.HasValue)
                    return type7_suggested_notes_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AvgDispensed
        private bool avg_dispensedChanged = false;
        private decimal? avg_dispensed;
        public decimal? AvgDispensed
        {
            get { return avg_dispensed; }
            set
            {
                avg_dispensed = value;
                avg_dispensedChanged = true;
            }
        }
        private string avg_dispensedDbString
        {
            get
            {
                if (this.avg_dispensed.HasValue)
                    return avg_dispensed.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region SpareCash
        private bool spare_cashChanged = false;
        private decimal? spare_cash;
        public decimal? SpareCash
        {
            get { return spare_cash; }
            set
            {
                spare_cash = value;
                spare_cashChanged = true;
            }
        }
        private string spare_cashDbString
        {
            get
            {
                if (this.spare_cash.HasValue)
                    return spare_cash.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DispensingBehavior
        private bool dispensing_behaviorChanged = false;
        private int? dispensing_behavior;
        public int? DispensingBehavior
        {
            get { return dispensing_behavior; }
            set
            {
                dispensing_behavior = value;
                dispensing_behaviorChanged = true;
            }
        }
        private string dispensing_behaviorDbString
        {
            get
            {
                if (this.dispensing_behavior.HasValue)
                    return dispensing_behavior.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AvgDispensedSalaryDays
        private bool avg_dispensed_salary_daysChanged = false;
        private decimal? avg_dispensed_salary_days;
        public decimal? AvgDispensedSalaryDays
        {
            get { return avg_dispensed_salary_days; }
            set
            {
                avg_dispensed_salary_days = value;
                avg_dispensed_salary_daysChanged = true;
            }
        }
        private string avg_dispensed_salary_daysDbString
        {
            get
            {
                if (this.avg_dispensed_salary_days.HasValue)
                    return avg_dispensed_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region InactivityPeriodSalaryDays
        private bool inactivity_period_salary_daysChanged = false;
        private int? inactivity_period_salary_days;
        public int? InactivityPeriodSalaryDays
        {
            get { return inactivity_period_salary_days; }
            set
            {
                inactivity_period_salary_days = value;
                inactivity_period_salary_daysChanged = true;
            }
        }
        private string inactivity_period_salary_daysDbString
        {
            get
            {
                if (this.inactivity_period_salary_days.HasValue)
                    return inactivity_period_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region InactivityPeriodNormalDays
        private bool inactivity_period_normal_daysChanged = false;
        private int? inactivity_period_normal_days;
        public int? InactivityPeriodNormalDays
        {
            get { return inactivity_period_normal_days; }
            set
            {
                inactivity_period_normal_days = value;
                inactivity_period_normal_daysChanged = true;
            }
        }
        private string inactivity_period_normal_daysDbString
        {
            get
            {
                if (this.inactivity_period_normal_days.HasValue)
                    return inactivity_period_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type1MinNotesThresholdValue
        private bool type1_min_notes_threshold_valueChanged = false;
        private int? type1_min_notes_threshold_value;
        public int? Type1MinNotesThresholdValue
        {
            get { return type1_min_notes_threshold_value; }
            set
            {
                type1_min_notes_threshold_value = value;
                type1_min_notes_threshold_valueChanged = true;
            }
        }
        private string type1_min_notes_threshold_valueDbString
        {
            get
            {
                if (this.type1_min_notes_threshold_value.HasValue)
                    return type1_min_notes_threshold_value.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type2MinNotesThresholdValue
        private bool type2_min_notes_threshold_valueChanged = false;
        private int? type2_min_notes_threshold_value;
        public int? Type2MinNotesThresholdValue
        {
            get { return type2_min_notes_threshold_value; }
            set
            {
                type2_min_notes_threshold_value = value;
                type2_min_notes_threshold_valueChanged = true;
            }
        }
        private string type2_min_notes_threshold_valueDbString
        {
            get
            {
                if (this.type2_min_notes_threshold_value.HasValue)
                    return type2_min_notes_threshold_value.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type3MinNotesThresholdValue
        private bool type3_min_notes_threshold_valueChanged = false;
        private int? type3_min_notes_threshold_value;
        public int? Type3MinNotesThresholdValue
        {
            get { return type3_min_notes_threshold_value; }
            set
            {
                type3_min_notes_threshold_value = value;
                type3_min_notes_threshold_valueChanged = true;
            }
        }
        private string type3_min_notes_threshold_valueDbString
        {
            get
            {
                if (this.type3_min_notes_threshold_value.HasValue)
                    return type3_min_notes_threshold_value.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Type4MinNotesThresholdValue
        private bool type4_min_notes_threshold_valueChanged = false;
        private int? type4_min_notes_threshold_value;
        public int? Type4MinNotesThresholdValue
        {
            get { return type4_min_notes_threshold_value; }
            set
            {
                type4_min_notes_threshold_value = value;
                type4_min_notes_threshold_valueChanged = true;
            }
        }
        private string type4_min_notes_threshold_valueDbString
        {
            get
            {
                if (this.type4_min_notes_threshold_value.HasValue)
                    return type4_min_notes_threshold_value.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region BnaAllowedInactivityPeriodNormalDays
        private bool bna_allowed_inactivity_period_normal_daysChanged = false;
        private int? bna_allowed_inactivity_period_normal_days;
        public int? BnaAllowedInactivityPeriodNormalDays
        {
            get { return bna_allowed_inactivity_period_normal_days; }
            set
            {
                bna_allowed_inactivity_period_normal_days = value;
                bna_allowed_inactivity_period_normal_daysChanged = true;
            }
        }
        private string bna_allowed_inactivity_period_normal_daysDbString
        {
            get
            {
                if (this.bna_allowed_inactivity_period_normal_days.HasValue)
                    return bna_allowed_inactivity_period_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region BnaAllowedInactivityPeriodSalaryDays
        private bool bna_allowed_inactivity_period_salary_daysChanged = false;
        private int? bna_allowed_inactivity_period_salary_days;
        public int? BnaAllowedInactivityPeriodSalaryDays
        {
            get { return bna_allowed_inactivity_period_salary_days; }
            set
            {
                bna_allowed_inactivity_period_salary_days = value;
                bna_allowed_inactivity_period_salary_daysChanged = true;
            }
        }
        private string bna_allowed_inactivity_period_salary_daysDbString
        {
            get
            {
                if (this.bna_allowed_inactivity_period_salary_days.HasValue)
                    return bna_allowed_inactivity_period_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ChequeAllowedInactivityPeriodNormalDays
        private bool cheque_allowed_inactivity_period_normal_daysChanged = false;
        private int? cheque_allowed_inactivity_period_normal_days;
        public int? ChequeAllowedInactivityPeriodNormalDays
        {
            get { return cheque_allowed_inactivity_period_normal_days; }
            set
            {
                cheque_allowed_inactivity_period_normal_days = value;
                cheque_allowed_inactivity_period_normal_daysChanged = true;
            }
        }
        private string cheque_allowed_inactivity_period_normal_daysDbString
        {
            get
            {
                if (this.cheque_allowed_inactivity_period_normal_days.HasValue)
                    return cheque_allowed_inactivity_period_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ChequeAllowedInactivityPeriodSalaryDays
        private bool cheque_allowed_inactivity_period_salary_daysChanged = false;
        private int? cheque_allowed_inactivity_period_salary_days;
        public int? ChequeAllowedInactivityPeriodSalaryDays
        {
            get { return cheque_allowed_inactivity_period_salary_days; }
            set
            {
                cheque_allowed_inactivity_period_salary_days = value;
                cheque_allowed_inactivity_period_salary_daysChanged = true;
            }
        }
        private string cheque_allowed_inactivity_period_salary_daysDbString
        {
            get
            {
                if (this.cheque_allowed_inactivity_period_salary_days.HasValue)
                    return cheque_allowed_inactivity_period_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MinOperatingBalanceNormalDays
        private bool min_operating_balance_normal_daysChanged = false;
        private decimal? min_operating_balance_normal_days;
        public decimal? MinOperatingBalanceNormalDays
        {
            get { return min_operating_balance_normal_days; }
            set
            {
                min_operating_balance_normal_days = value;
                min_operating_balance_normal_daysChanged = true;
            }
        }
        private string min_operating_balance_normal_daysDbString
        {
            get
            {
                if (this.min_operating_balance_normal_days.HasValue)
                    return min_operating_balance_normal_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MinOperatingBalanceSalaryDays
        private bool min_operating_balance_salary_daysChanged = false;
        private decimal? min_operating_balance_salary_days;
        public decimal? MinOperatingBalanceSalaryDays
        {
            get { return min_operating_balance_salary_days; }
            set
            {
                min_operating_balance_salary_days = value;
                min_operating_balance_salary_daysChanged = true;
            }
        }
        private string min_operating_balance_salary_daysDbString
        {
            get
            {
                if (this.min_operating_balance_salary_days.HasValue)
                    return min_operating_balance_salary_days.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsOrderAutoGenerated
        private bool is_order_auto_generatedChanged = false;
        private bool? is_order_auto_generated;
        public bool? IsOrderAutoGenerated
        {
            get { return is_order_auto_generated; }
            set
            {
                is_order_auto_generated = value;
                is_order_auto_generatedChanged = true;
            }
        }
        private string is_order_auto_generatedDbString
        {
            get
            {
                if (this.is_order_auto_generated.HasValue)
                    return is_order_auto_generated.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsWin7Machine
        private bool is_win7_machineChanged = false;
        private bool? is_win7_machine;
        public bool? IsWin7Machine
        {
            get { return is_win7_machine; }
            set
            {
                is_win7_machine = value;
                is_win7_machineChanged = true;
            }
        }
        private string is_win7_machineDbString
        {
            get
            {
                if (this.is_win7_machine.HasValue)
                    return is_win7_machine.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsBranchAtm
        private bool is_branch_atmChanged = false;
        private bool? is_branch_atm;
        public bool? IsBranchAtm
        {
            get { return is_branch_atm; }
            set
            {
                is_branch_atm = value;
                is_branch_atmChanged = true;
            }
        }
        private string is_branch_atmDbString
        {
            get
            {
                if (this.is_branch_atm.HasValue)
                    return is_branch_atm.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsEmirateIslamic
        private bool is_emirate_islamicChanged = false;
        private bool? is_emirate_islamic;
        public bool? IsEmirateIslamic
        {
            get { return is_emirate_islamic; }
            set
            {
                is_emirate_islamic = value;
                is_emirate_islamicChanged = true;
            }
        }
        private string is_emirate_islamicDbString
        {
            get
            {
                if (this.is_emirate_islamic.HasValue)
                    return is_emirate_islamic.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsItm
        private bool is_itmChanged = false;
        private bool? is_itm;
        public bool? IsItm
        {
            get { return is_itm; }
            set
            {
                is_itm = value;
                is_itmChanged = true;
            }
        }
        private string is_itmDbString
        {
            get
            {
                if (this.is_itm.HasValue)
                    return is_itm.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsBulkCashDeposit
        private bool is_bulk_cash_depositChanged = false;
        private bool? is_bulk_cash_deposit;
        public bool? IsBulkCashDeposit
        {
            get { return is_bulk_cash_deposit; }
            set
            {
                is_bulk_cash_deposit = value;
                is_bulk_cash_depositChanged = true;
            }
        }
        private string is_bulk_cash_depositDbString
        {
            get
            {
                if (this.is_bulk_cash_deposit.HasValue)
                    return is_bulk_cash_deposit.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region IsCombo
        private bool is_comboChanged = false;
        private bool? is_combo;
        public bool? IsCombo
        {
            get { return is_combo; }
            set
            {
                is_combo = value;
                is_comboChanged = true;
            }
        }
        private string is_comboDbString
        {
            get
            {
                if (this.is_combo.HasValue)
                    return is_combo.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region AtmCost
        private bool atm_costChanged = false;
        private decimal? atm_cost;
        public decimal? AtmCost
        {
            get { return atm_cost; }
            set
            {
                atm_cost = value;
                atm_costChanged = true;
            }
        }
        private string atm_costDbString
        {
            get
            {
                if (this.atm_cost.HasValue)
                    return atm_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region SoftwareCost
        private bool software_costChanged = false;
        private decimal? software_cost;
        public decimal? SoftwareCost
        {
            get { return software_cost; }
            set
            {
                software_cost = value;
                software_costChanged = true;
            }
        }
        private string software_costDbString
        {
            get
            {
                if (this.software_cost.HasValue)
                    return software_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NetworkCost
        private bool network_costChanged = false;
        private decimal? network_cost;
        public decimal? NetworkCost
        {
            get { return network_cost; }
            set
            {
                network_cost = value;
                network_costChanged = true;
            }
        }
        private string network_costDbString
        {
            get
            {
                if (this.network_cost.HasValue)
                    return network_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region SitePreparationCost
        private bool site_preparation_costChanged = false;
        private decimal? site_preparation_cost;
        public decimal? SitePreparationCost
        {
            get { return site_preparation_cost; }
            set
            {
                site_preparation_cost = value;
                site_preparation_costChanged = true;
            }
        }
        private string site_preparation_costDbString
        {
            get
            {
                if (this.site_preparation_cost.HasValue)
                    return site_preparation_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region SecurityInfrastructureCost
        private bool security_infrastructure_costChanged = false;
        private decimal? security_infrastructure_cost;
        public decimal? SecurityInfrastructureCost
        {
            get { return security_infrastructure_cost; }
            set
            {
                security_infrastructure_cost = value;
                security_infrastructure_costChanged = true;
            }
        }
        private string security_infrastructure_costDbString
        {
            get
            {
                if (this.security_infrastructure_cost.HasValue)
                    return security_infrastructure_cost.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ImBranchCode
        private bool im_branch_codeChanged = false;
        private string im_branch_code;
        public string ImBranchCode
        {
            get { return im_branch_code; }
            set
            {
                im_branch_code = value;
                im_branch_codeChanged = true;
            }
        }
        private string im_branch_codeDbString
        {
            get
            {
                if (this.im_branch_code != null)
                    return string.Format("'{0}'", im_branch_code);
                else
                    return "null";
            }
        }
        #endregion
        #region ImEnId
        private bool im_en_idChanged = false;
        private string im_en_id;
        public string ImEnId
        {
            get { return im_en_id; }
            set
            {
                im_en_id = value;
                im_en_idChanged = true;
            }
        }
        private string im_en_idDbString
        {
            get
            {
                if (this.im_en_id != null)
                    return string.Format("'{0}'", im_en_id);
                else
                    return "null";
            }
        }
        #endregion
        #region ImLocation
        private bool im_locationChanged = false;
        private string im_location;
        public string ImLocation
        {
            get { return im_location; }
            set
            {
                im_location = value;
                im_locationChanged = true;
            }
        }
        private string im_locationDbString
        {
            get
            {
                if (this.im_location != null)
                    return string.Format("'{0}'", im_location);
                else
                    return "null";
            }
        }
        #endregion
        #region ImBusinessArea
        private bool im_business_areaChanged = false;
        private string im_business_area;
        public string ImBusinessArea
        {
            get { return im_business_area; }
            set
            {
                im_business_area = value;
                im_business_areaChanged = true;
            }
        }
        private string im_business_areaDbString
        {
            get
            {
                if (this.im_business_area != null)
                    return string.Format("'{0}'", im_business_area);
                else
                    return "null";
            }
        }
        #endregion
        #region ImCircle
        private bool im_circleChanged = false;
        private string im_circle;
        public string ImCircle
        {
            get { return im_circle; }
            set
            {
                im_circle = value;
                im_circleChanged = true;
            }
        }
        private string im_circleDbString
        {
            get
            {
                if (this.im_circle != null)
                    return string.Format("'{0}'", im_circle);
                else
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
            set
            {
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
        #region AtmBandwidthId
        private bool atm_bandwidth_idChanged = false;
        private int? atm_bandwidth_id;
        public int? AtmBandwidthId
        {
            get { return atm_bandwidth_id; }
            set
            {
                atm_bandwidth_id = value;
                atm_bandwidth_idChanged = true;
            }
        }
        private string atm_bandwidth_idDbString
        {
            get
            {
                if (this.atm_bandwidth_id.HasValue)
                    return atm_bandwidth_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AtmModelId
        private bool atm_model_idChanged = false;
        private int? atm_model_id;
        public int? AtmModelId
        {
            get { return atm_model_id; }
            set
            {
                atm_model_id = value;
                atm_model_idChanged = true;
            }
        }
        private string atm_model_idDbString
        {
            get
            {
                if (this.atm_model_id.HasValue)
                    return atm_model_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region IsRecycler
        private bool is_recyclerChanged = false;
        private bool? is_recycler;
        public bool? IsRecycler
        {
            get { return is_recycler; }
            set
            {
                is_recycler = value;
                is_recyclerChanged = true;
            }
        }
        private string is_recyclerDbString
        {
            get
            {
                if (this.is_recycler.HasValue)
                    return is_recycler.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region AtmReader
        public class AtmReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Atm currentAtm;
            Columns columns;
            bool partialRead = false;
            private AtmReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public AtmReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public AtmReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentAtm; }

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
                    currentAtm = new Atm();
                    {
                        if (reader["ATM_id"] != DBNull.Value)
                            currentAtm.aTM_id = (int)reader["ATM_id"];
                        if (reader["last_status_reply"] != DBNull.Value)
                            currentAtm.last_status_reply = (string)reader["last_status_reply"];
                        if (reader["region_id"] != DBNull.Value)
                            currentAtm.region_id = (int)reader["region_id"];
                        if (reader["title"] != DBNull.Value)
                            currentAtm.title = (string)reader["title"];
                        if (reader["IP"] != DBNull.Value)
                            currentAtm.iP = (string)reader["IP"];
                        if (reader["port"] != DBNull.Value)
                            currentAtm.port = (int)reader["port"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentAtm.modified_by = (int?)reader["modified_by"];
                        if (reader["created_by"] != DBNull.Value)
                            currentAtm.created_by = (int)reader["created_by"];
                        if (reader["is_active"] != DBNull.Value)
                            currentAtm.is_active = (bool)reader["is_active"];
                        if (reader["creation_time"] != DBNull.Value)
                            currentAtm.creation_time = (DateTime)reader["creation_time"];
                        if (reader["atm_type"] != DBNull.Value)
                            currentAtm.atm_type = (string)reader["atm_type"];
                        if (reader["cassette1_capacity"] != DBNull.Value)
                            currentAtm.cassette1_capacity = (int)reader["cassette1_capacity"];
                        if (reader["cassette1_denomination"] != DBNull.Value)
                            currentAtm.cassette1_denomination = (int)reader["cassette1_denomination"];
                        if (reader["cassette2_capacity"] != DBNull.Value)
                            currentAtm.cassette2_capacity = (int)reader["cassette2_capacity"];
                        if (reader["cassette2_denomination"] != DBNull.Value)
                            currentAtm.cassette2_denomination = (int)reader["cassette2_denomination"];
                        if (reader["cassette3_denomination"] != DBNull.Value)
                            currentAtm.cassette3_denomination = (int)reader["cassette3_denomination"];
                        if (reader["cassette3_capacity"] != DBNull.Value)
                            currentAtm.cassette3_capacity = (int)reader["cassette3_capacity"];
                        if (reader["cassette4_denomination"] != DBNull.Value)
                            currentAtm.cassette4_denomination = (int)reader["cassette4_denomination"];
                        if (reader["cassette4_capacity"] != DBNull.Value)
                            currentAtm.cassette4_capacity = (int)reader["cassette4_capacity"];
                        if (reader["cassette5_denomination"] != DBNull.Value)
                            currentAtm.cassette5_denomination = (int)reader["cassette5_denomination"];
                        if (reader["cassette5_capacity"] != DBNull.Value)
                            currentAtm.cassette5_capacity = (int)reader["cassette5_capacity"];
                        if (reader["cassette6_denomination"] != DBNull.Value)
                            currentAtm.cassette6_denomination = (int)reader["cassette6_denomination"];
                        if (reader["cassette6_capacity"] != DBNull.Value)
                            currentAtm.cassette6_capacity = (int)reader["cassette6_capacity"];
                        if (reader["cassette7_denomination"] != DBNull.Value)
                            currentAtm.cassette7_denomination = (int)reader["cassette7_denomination"];
                        if (reader["cassette7_capacity"] != DBNull.Value)
                            currentAtm.cassette7_capacity = (int)reader["cassette7_capacity"];
                        if (reader["last_wincor_sent"] != DBNull.Value)
                            currentAtm.last_wincor_sent = (DateTime)reader["last_wincor_sent"];
                        if (reader["is_healthy"] != DBNull.Value)
                            currentAtm.is_healthy = (bool)reader["is_healthy"];
                        if (reader["location"] != DBNull.Value)
                            currentAtm.location = (string)reader["location"];
                        if (reader["address1"] != DBNull.Value)
                            currentAtm.address1 = (string)reader["address1"];
                        if (reader["address2"] != DBNull.Value)
                            currentAtm.address2 = (string)reader["address2"];
                        if (reader["city"] != DBNull.Value)
                            currentAtm.city = (string)reader["city"];
                        if (reader["country"] != DBNull.Value)
                            currentAtm.country = (string)reader["country"];
                        if (reader["zip_code"] != DBNull.Value)
                            currentAtm.zip_code = (string)reader["zip_code"];
                        if (reader["location_type"] != DBNull.Value)
                            currentAtm.location_type = (string)reader["location_type"];
                        if (reader["service_status"] != DBNull.Value)
                            currentAtm.service_status = (string)reader["service_status"];
                        if (reader["holiday_status"] != DBNull.Value)
                            currentAtm.holiday_status = (string)reader["holiday_status"];
                        if (reader["business_days"] != DBNull.Value)
                            currentAtm.business_days = (string)reader["business_days"];
                        if (reader["time_zone"] != DBNull.Value)
                            currentAtm.time_zone = (int?)reader["time_zone"];
                        if (reader["max_notes_per_cassette"] != DBNull.Value)
                            currentAtm.max_notes_per_cassette = (int?)reader["max_notes_per_cassette"];
                        if (reader["cassette1_split_percentage"] != DBNull.Value)
                            currentAtm.cassette1_split_percentage = (int?)reader["cassette1_split_percentage"];
                        if (reader["cassette2_split_percentage"] != DBNull.Value)
                            currentAtm.cassette2_split_percentage = (int?)reader["cassette2_split_percentage"];
                        if (reader["cassette3_split_percentage"] != DBNull.Value)
                            currentAtm.cassette3_split_percentage = (int?)reader["cassette3_split_percentage"];
                        if (reader["cassette4_split_percentage"] != DBNull.Value)
                            currentAtm.cassette4_split_percentage = (int?)reader["cassette4_split_percentage"];
                        if (reader["cassette5_split_percentage"] != DBNull.Value)
                            currentAtm.cassette5_split_percentage = (int?)reader["cassette5_split_percentage"];
                        if (reader["cassette6_split_percentage"] != DBNull.Value)
                            currentAtm.cassette6_split_percentage = (int?)reader["cassette6_split_percentage"];
                        if (reader["cassette7_split_percentage"] != DBNull.Value)
                            currentAtm.cassette7_split_percentage = (int?)reader["cassette7_split_percentage"];
                        if (reader["interest_rate"] != DBNull.Value)
                            currentAtm.interest_rate = (decimal?)reader["interest_rate"];
                        if (reader["insurance_rate"] != DBNull.Value)
                            currentAtm.insurance_rate = (decimal?)reader["insurance_rate"];
                        if (reader["max_holding_amount"] != DBNull.Value)
                            currentAtm.max_holding_amount = (decimal?)reader["max_holding_amount"];
                        if (reader["min_operating_balance"] != DBNull.Value)
                            currentAtm.min_operating_balance = (decimal?)reader["min_operating_balance"];
                        if (reader["min_amount_for_normal_delivery"] != DBNull.Value)
                            currentAtm.min_amount_for_normal_delivery = (decimal?)reader["min_amount_for_normal_delivery"];
                        if (reader["bank_cash_center_id"] != DBNull.Value)
                            currentAtm.bank_cash_center_id = (string)reader["bank_cash_center_id"];
                        if (reader["CIT_cash_center_servicer"] != DBNull.Value)
                            currentAtm.cIT_cash_center_servicer = (string)reader["CIT_cash_center_servicer"];
                        if (reader["depot_id"] != DBNull.Value)
                            currentAtm.depot_id = (string)reader["depot_id"];
                        if (reader["secondary_depot_vault_id"] != DBNull.Value)
                            currentAtm.secondary_depot_vault_id = (string)reader["secondary_depot_vault_id"];
                        if (reader["new_atm_scenario"] != DBNull.Value)
                            currentAtm.new_atm_scenario = (string)reader["new_atm_scenario"];
                        if (reader["cash_swap_days"] != DBNull.Value)
                            currentAtm.cash_swap_days = (string)reader["cash_swap_days"];
                        if (reader["mandatory_cash_swap_days"] != DBNull.Value)
                            currentAtm.mandatory_cash_swap_days = (string)reader["mandatory_cash_swap_days"];
                        if (reader["cash_swap_cycle"] != DBNull.Value)
                            currentAtm.cash_swap_cycle = (int?)reader["cash_swap_cycle"];
                        if (reader["cash_swap_lead_time"] != DBNull.Value)
                            currentAtm.cash_swap_lead_time = (int?)reader["cash_swap_lead_time"];
                        if (reader["cash_swap_start_date"] != DBNull.Value)
                            currentAtm.cash_swap_start_date = (DateTime?)reader["cash_swap_start_date"];
                        if (reader["cash_swap_handling_cost"] != DBNull.Value)
                            currentAtm.cash_swap_handling_cost = (decimal?)reader["cash_swap_handling_cost"];
                        if (reader["cash_swap_costs"] != DBNull.Value)
                            currentAtm.cash_swap_costs = (decimal?)reader["cash_swap_costs"];
                        if (reader["emergency_days"] != DBNull.Value)
                            currentAtm.emergency_days = (string)reader["emergency_days"];
                        if (reader["emergency_lead_time"] != DBNull.Value)
                            currentAtm.emergency_lead_time = (int?)reader["emergency_lead_time"];
                        if (reader["emergency_cost"] != DBNull.Value)
                            currentAtm.emergency_cost = (decimal?)reader["emergency_cost"];
                        if (reader["contact1_email"] != DBNull.Value)
                            currentAtm.contact1_email = (string)reader["contact1_email"];
                        if (reader["contact2_email"] != DBNull.Value)
                            currentAtm.contact2_email = (string)reader["contact2_email"];
                        if (reader["contact3_email"] != DBNull.Value)
                            currentAtm.contact3_email = (string)reader["contact3_email"];
                        if (reader["contact1_phone"] != DBNull.Value)
                            currentAtm.contact1_phone = (string)reader["contact1_phone"];
                        if (reader["contact2_phone"] != DBNull.Value)
                            currentAtm.contact2_phone = (string)reader["contact2_phone"];
                        if (reader["contact3_phone"] != DBNull.Value)
                            currentAtm.contact3_phone = (string)reader["contact3_phone"];
                        if (reader["effective_date"] != DBNull.Value)
                            currentAtm.effective_date = (DateTime?)reader["effective_date"];
                        if (reader["suspend_cash_order"] != DBNull.Value)
                            currentAtm.suspend_cash_order = (bool)reader["suspend_cash_order"];
                        if (reader["is_atm"] != DBNull.Value)
                            currentAtm.is_atm = (bool?)reader["is_atm"];
                        if (reader["is_cdm"] != DBNull.Value)
                            currentAtm.is_cdm = (bool?)reader["is_cdm"];
                        if (reader["is_ccdm"] != DBNull.Value)
                            currentAtm.is_ccdm = (bool?)reader["is_ccdm"];
                        if (reader["cdm_cassette1_capacity"] != DBNull.Value)
                            currentAtm.cdm_cassette1_capacity = (int?)reader["cdm_cassette1_capacity"];
                        if (reader["cdm_cassette2_capacity"] != DBNull.Value)
                            currentAtm.cdm_cassette2_capacity = (int?)reader["cdm_cassette2_capacity"];
                        if (reader["cdm_cassette3_capacity"] != DBNull.Value)
                            currentAtm.cdm_cassette3_capacity = (int?)reader["cdm_cassette3_capacity"];
                        if (reader["cdm_cassette4_capacity"] != DBNull.Value)
                            currentAtm.cdm_cassette4_capacity = (int?)reader["cdm_cassette4_capacity"];
                        if (reader["ccdm_cassette1_capacity"] != DBNull.Value)
                            currentAtm.ccdm_cassette1_capacity = (int?)reader["ccdm_cassette1_capacity"];
                        if (reader["ccdm_cassette2_capacity"] != DBNull.Value)
                            currentAtm.ccdm_cassette2_capacity = (int?)reader["ccdm_cassette2_capacity"];
                        if (reader["ccdm_cassette3_capacity"] != DBNull.Value)
                            currentAtm.ccdm_cassette3_capacity = (int?)reader["ccdm_cassette3_capacity"];
                        if (reader["ccdm_cassette4_capacity"] != DBNull.Value)
                            currentAtm.ccdm_cassette4_capacity = (int?)reader["ccdm_cassette4_capacity"];
                        if (reader["cdm_cassette1_threshold"] != DBNull.Value)
                            currentAtm.cdm_cassette1_threshold = (int?)reader["cdm_cassette1_threshold"];
                        if (reader["cdm_cassette2_threshold"] != DBNull.Value)
                            currentAtm.cdm_cassette2_threshold = (int?)reader["cdm_cassette2_threshold"];
                        if (reader["cdm_cassette3_threshold"] != DBNull.Value)
                            currentAtm.cdm_cassette3_threshold = (int?)reader["cdm_cassette3_threshold"];
                        if (reader["cdm_cassette4_threshold"] != DBNull.Value)
                            currentAtm.cdm_cassette4_threshold = (int?)reader["cdm_cassette4_threshold"];
                        if (reader["ccdm_cassette1_threshold"] != DBNull.Value)
                            currentAtm.ccdm_cassette1_threshold = (int?)reader["ccdm_cassette1_threshold"];
                        if (reader["ccdm_cassette2_threshold"] != DBNull.Value)
                            currentAtm.ccdm_cassette2_threshold = (int?)reader["ccdm_cassette2_threshold"];
                        if (reader["ccdm_cassette3_threshold"] != DBNull.Value)
                            currentAtm.ccdm_cassette3_threshold = (int?)reader["ccdm_cassette3_threshold"];
                        if (reader["ccdm_cassette4_threshold"] != DBNull.Value)
                            currentAtm.ccdm_cassette4_threshold = (int?)reader["ccdm_cassette4_threshold"];
                        if (reader["note_set_type_id"] != DBNull.Value)
                            currentAtm.note_set_type_id = (int)reader["note_set_type_id"];
                        if (reader["ccdm_cassette5_capacity"] != DBNull.Value)
                            currentAtm.ccdm_cassette5_capacity = (int?)reader["ccdm_cassette5_capacity"];
                        if (reader["ccdm_cassette5_threshold"] != DBNull.Value)
                            currentAtm.ccdm_cassette5_threshold = (int?)reader["ccdm_cassette5_threshold"];
                        if (reader["startup_sleep_interval"] != DBNull.Value)
                            currentAtm.startup_sleep_interval = (int?)reader["startup_sleep_interval"];
                        if (reader["debug_level"] != DBNull.Value)
                            currentAtm.debug_level = (byte?)reader["debug_level"];
                        if (reader["exclude_dff"] != DBNull.Value)
                            currentAtm.exclude_dff = (bool?)reader["exclude_dff"];
                        if (reader["purge1_threshold"] != DBNull.Value)
                            currentAtm.purge1_threshold = (int?)reader["purge1_threshold"];
                        if (reader["is_purge1_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge1_threshold_selected = (bool?)reader["is_purge1_threshold_selected"];
                        if (reader["purge2_threshold"] != DBNull.Value)
                            currentAtm.purge2_threshold = (int?)reader["purge2_threshold"];
                        if (reader["is_purge2_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge2_threshold_selected = (bool?)reader["is_purge2_threshold_selected"];
                        if (reader["purge3_threshold"] != DBNull.Value)
                            currentAtm.purge3_threshold = (int?)reader["purge3_threshold"];
                        if (reader["is_purge3_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge3_threshold_selected = (bool?)reader["is_purge3_threshold_selected"];
                        if (reader["purge4_threshold"] != DBNull.Value)
                            currentAtm.purge4_threshold = (int?)reader["purge4_threshold"];
                        if (reader["is_purge4_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge4_threshold_selected = (bool?)reader["is_purge4_threshold_selected"];
                        if (reader["purge5_threshold"] != DBNull.Value)
                            currentAtm.purge5_threshold = (int?)reader["purge5_threshold"];
                        if (reader["is_purge5_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge5_threshold_selected = (bool?)reader["is_purge5_threshold_selected"];
                        if (reader["purge6_threshold"] != DBNull.Value)
                            currentAtm.purge6_threshold = (int?)reader["purge6_threshold"];
                        if (reader["is_purge6_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge6_threshold_selected = (bool?)reader["is_purge6_threshold_selected"];
                        if (reader["purge7_threshold"] != DBNull.Value)
                            currentAtm.purge7_threshold = (int?)reader["purge7_threshold"];
                        if (reader["is_purge7_threshold_selected"] != DBNull.Value)
                            currentAtm.is_purge7_threshold_selected = (bool?)reader["is_purge7_threshold_selected"];
                        if (reader["retry_count_cash_order_upload"] != DBNull.Value)
                            currentAtm.retry_count_cash_order_upload = (int)reader["retry_count_cash_order_upload"];
                        if (reader["retry_count_conf_upload"] != DBNull.Value)
                            currentAtm.retry_count_conf_upload = (int)reader["retry_count_conf_upload"];
                        if (reader["retry_count_counter_file"] != DBNull.Value)
                            currentAtm.retry_count_counter_file = (int)reader["retry_count_counter_file"];
                        if (reader["retry_count_restart_schedule"] != DBNull.Value)
                            currentAtm.retry_count_restart_schedule = (int)reader["retry_count_restart_schedule"];
                        if (reader["retry_count_datetime_schedule"] != DBNull.Value)
                            currentAtm.retry_count_datetime_schedule = (int)reader["retry_count_datetime_schedule"];
                        if (reader["retry_count_alert"] != DBNull.Value)
                            currentAtm.retry_count_alert = (int)reader["retry_count_alert"];
                        if (reader["CountsClearRetries"] != DBNull.Value)
                            currentAtm.countsClearRetries = (int)reader["CountsClearRetries"];
                        if (reader["TCPTimeout"] != DBNull.Value)
                            currentAtm.tCPTimeout = (int)reader["TCPTimeout"];
                        if (reader["SleepInterval"] != DBNull.Value)
                            currentAtm.sleepInterval = (int)reader["SleepInterval"];
                        if (reader["CPMCommandWait"] != DBNull.Value)
                            currentAtm.cPMCommandWait = (int)reader["CPMCommandWait"];
                        if (reader["CPMCommandSleep"] != DBNull.Value)
                            currentAtm.cPMCommandSleep = (int)reader["CPMCommandSleep"];
                        if (reader["AANDCApplications1"] != DBNull.Value)
                            currentAtm.aANDCApplications1 = (string)reader["AANDCApplications1"];
                        if (reader["AANDCApplications2"] != DBNull.Value)
                            currentAtm.aANDCApplications2 = (string)reader["AANDCApplications2"];
                        if (reader["AANDCApplications3"] != DBNull.Value)
                            currentAtm.aANDCApplications3 = (string)reader["AANDCApplications3"];
                        if (reader["AANDCApplications4"] != DBNull.Value)
                            currentAtm.aANDCApplications4 = (string)reader["AANDCApplications4"];
                        if (reader["AANDCApplications5"] != DBNull.Value)
                            currentAtm.aANDCApplications5 = (string)reader["AANDCApplications5"];
                        if (reader["Monitoring_Retries"] != DBNull.Value)
                            currentAtm.monitoring_Retries = (int)reader["Monitoring_Retries"];
                        if (reader["WindowSwitch_Sleep"] != DBNull.Value)
                            currentAtm.windowSwitch_Sleep = (int)reader["WindowSwitch_Sleep"];
                        if (reader["AppSwitch_Sleep"] != DBNull.Value)
                            currentAtm.appSwitch_Sleep = (int)reader["AppSwitch_Sleep"];
                        if (reader["MonitoringCycle_Sleep"] != DBNull.Value)
                            currentAtm.monitoringCycle_Sleep = (int)reader["MonitoringCycle_Sleep"];
                        if (reader["CPMLogLevel"] != DBNull.Value)
                            currentAtm.cPMLogLevel = (int)reader["CPMLogLevel"];
                        if (reader["IsDispenserRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isDispenserRealTimeNotificationEnabled = (bool)reader["IsDispenserRealTimeNotificationEnabled"];
                        if (reader["IsBNARealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isBNARealTimeNotificationEnabled = (bool)reader["IsBNARealTimeNotificationEnabled"];
                        if (reader["IsCPMRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isCPMRealTimeNotificationEnabled = (bool)reader["IsCPMRealTimeNotificationEnabled"];
                        if (reader["IsReplenishmentRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isReplenishmentRealTimeNotificationEnabled = (bool)reader["IsReplenishmentRealTimeNotificationEnabled"];
                        if (reader["IsOutOfCashRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isOutOfCashRealTimeNotificationEnabled = (bool)reader["IsOutOfCashRealTimeNotificationEnabled"];
                        if (reader["IsDispenserMismatchRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isDispenserMismatchRealTimeNotificationEnabled = (bool)reader["IsDispenserMismatchRealTimeNotificationEnabled"];
                        if (reader["IsBNAMismatchRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isBNAMismatchRealTimeNotificationEnabled = (bool)reader["IsBNAMismatchRealTimeNotificationEnabled"];
                        if (reader["IsCPMMismatchRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isCPMMismatchRealTimeNotificationEnabled = (bool)reader["IsCPMMismatchRealTimeNotificationEnabled"];
                        if (reader["IsCounterExplodedRealTimeNotificationEnabled"] != DBNull.Value)
                            currentAtm.isCounterExplodedRealTimeNotificationEnabled = (bool)reader["IsCounterExplodedRealTimeNotificationEnabled"];
                        if (reader["Type1MinimumNotes"] != DBNull.Value)
                            currentAtm.type1MinimumNotes = (int)reader["Type1MinimumNotes"];
                        if (reader["Type2MinimumNotes"] != DBNull.Value)
                            currentAtm.type2MinimumNotes = (int)reader["Type2MinimumNotes"];
                        if (reader["Type3MinimumNotes"] != DBNull.Value)
                            currentAtm.type3MinimumNotes = (int)reader["Type3MinimumNotes"];
                        if (reader["Type4MinimumNotes"] != DBNull.Value)
                            currentAtm.type4MinimumNotes = (int)reader["Type4MinimumNotes"];
                        if (reader["Type5MinimumNotes"] != DBNull.Value)
                            currentAtm.type5MinimumNotes = (int)reader["Type5MinimumNotes"];
                        if (reader["Type6MinimumNotes"] != DBNull.Value)
                            currentAtm.type6MinimumNotes = (int)reader["Type6MinimumNotes"];
                        if (reader["Type7MinimumNotes"] != DBNull.Value)
                            currentAtm.type7MinimumNotes = (int)reader["Type7MinimumNotes"];
                        if (reader["cpm_command"] != DBNull.Value)
                            currentAtm.cpm_command = (string)reader["cpm_command"];
                        if (reader["allowed_inactivity_period"] != DBNull.Value)
                            currentAtm.allowed_inactivity_period = (int?)reader["allowed_inactivity_period"];
                        if (reader["gl_number"] != DBNull.Value)
                            currentAtm.gl_number = (string)reader["gl_number"];
                        if (reader["card_captured_cost"] != DBNull.Value)
                            currentAtm.card_captured_cost = (decimal?)reader["card_captured_cost"];
                        if (reader["escotting_cost"] != DBNull.Value)
                            currentAtm.escotting_cost = (decimal?)reader["escotting_cost"];
                        if (reader["replenishment_cost"] != DBNull.Value)
                            currentAtm.replenishment_cost = (decimal?)reader["replenishment_cost"];
                        if (reader["maintenance_cost"] != DBNull.Value)
                            currentAtm.maintenance_cost = (decimal?)reader["maintenance_cost"];
                        if (reader["flm_call_out_cost"] != DBNull.Value)
                            currentAtm.flm_call_out_cost = (decimal?)reader["flm_call_out_cost"];
                        if (reader["description"] != DBNull.Value)
                            currentAtm.description = (string)reader["description"];
                        if (reader["is_dff_generation_halt"] != DBNull.Value)
                            currentAtm.is_dff_generation_halt = (bool?)reader["is_dff_generation_halt"];
                        if (reader["cit_atm_title"] != DBNull.Value)
                            currentAtm.cit_atm_title = (string)reader["cit_atm_title"];
                        if (reader["cheque_allowed_inactivity_period"] != DBNull.Value)
                            currentAtm.cheque_allowed_inactivity_period = (int?)reader["cheque_allowed_inactivity_period"];
                        if (reader["bna_allowed_inactivity_period"] != DBNull.Value)
                            currentAtm.bna_allowed_inactivity_period = (int?)reader["bna_allowed_inactivity_period"];
                        if (reader["out_of_cash_threshold"] != DBNull.Value)
                            currentAtm.out_of_cash_threshold = (int)reader["out_of_cash_threshold"];
                        if (reader["no_of_dispensed_transactions_to_monitor"] != DBNull.Value)
                            currentAtm.no_of_dispensed_transactions_to_monitor = (int?)reader["no_of_dispensed_transactions_to_monitor"];
                        if (reader["is_ej_enabled"] != DBNull.Value)
                            currentAtm.is_ej_enabled = (bool)reader["is_ej_enabled"];
                        if (reader["is_counter_enabled"] != DBNull.Value)
                            currentAtm.is_counter_enabled = (bool)reader["is_counter_enabled"];
                        if (reader["priority"] != DBNull.Value)
                            currentAtm.priority = (int)reader["priority"];
                        if (reader["longitude"] != DBNull.Value)
                            currentAtm.longitude = (string)reader["longitude"];
                        if (reader["latitude"] != DBNull.Value)
                            currentAtm.latitude = (string)reader["latitude"];
                        if (reader["on_us_amount"] != DBNull.Value)
                            currentAtm.on_us_amount = (decimal?)reader["on_us_amount"];
                        if (reader["not_on_us_amount"] != DBNull.Value)
                            currentAtm.not_on_us_amount = (decimal?)reader["not_on_us_amount"];
                        if (reader["standard_order_type1"] != DBNull.Value)
                            currentAtm.standard_order_type1 = (int?)reader["standard_order_type1"];
                        if (reader["standard_order_type2"] != DBNull.Value)
                            currentAtm.standard_order_type2 = (int?)reader["standard_order_type2"];
                        if (reader["standard_order_type3"] != DBNull.Value)
                            currentAtm.standard_order_type3 = (int?)reader["standard_order_type3"];
                        if (reader["standard_order_type4"] != DBNull.Value)
                            currentAtm.standard_order_type4 = (int?)reader["standard_order_type4"];
                        if (reader["standard_order_type5"] != DBNull.Value)
                            currentAtm.standard_order_type5 = (int?)reader["standard_order_type5"];
                        if (reader["standard_order_type6"] != DBNull.Value)
                            currentAtm.standard_order_type6 = (int?)reader["standard_order_type6"];
                        if (reader["standard_order_type7"] != DBNull.Value)
                            currentAtm.standard_order_type7 = (int?)reader["standard_order_type7"];
                        if (reader["protocol_type_id"] != DBNull.Value)
                            currentAtm.protocol_type_id = (int)reader["protocol_type_id"];
                        if (reader["current_mode"] != DBNull.Value)
                            currentAtm.current_mode = (byte)reader["current_mode"];
                        if (reader["aggregate_state"] != DBNull.Value)
                            currentAtm.aggregate_state = (byte)reader["aggregate_state"];
                        if (reader["last_boot_time"] != DBNull.Value)
                            currentAtm.last_boot_time = (DateTime?)reader["last_boot_time"];
                        if (reader["discovery_time"] != DBNull.Value)
                            currentAtm.discovery_time = (DateTime?)reader["discovery_time"];
                        if (reader["last_scan_time"] != DBNull.Value)
                            currentAtm.last_scan_time = (DateTime?)reader["last_scan_time"];
                        if (reader["communication_status"] != DBNull.Value)
                            currentAtm.communication_status = (byte)reader["communication_status"];
                        if (reader["is_critical"] != DBNull.Value)
                            currentAtm.is_critical = (bool)reader["is_critical"];
                        if (reader["current_mode_modified_on"] != DBNull.Value)
                            currentAtm.current_mode_modified_on = (DateTime?)reader["current_mode_modified_on"];
                        if (reader["Last_Notification_Received_On"] != DBNull.Value)
                            currentAtm.last_Notification_Received_On = (DateTime?)reader["Last_Notification_Received_On"];
                        if (reader["Last_Notification_Time"] != DBNull.Value)
                            currentAtm.last_Notification_Time = (DateTime?)reader["Last_Notification_Time"];
                        if (reader["normal_order_cost"] != DBNull.Value)
                            currentAtm.normal_order_cost = (decimal?)reader["normal_order_cost"];
                        if (reader["emergency_order_cost"] != DBNull.Value)
                            currentAtm.emergency_order_cost = (decimal?)reader["emergency_order_cost"];
                        if (reader["receipt_transaction_cutoff"] != DBNull.Value)
                            currentAtm.receipt_transaction_cutoff = (int?)reader["receipt_transaction_cutoff"];
                        if (reader["is_swap_default_replenishment"] != DBNull.Value)
                            currentAtm.is_swap_default_replenishment = (bool?)reader["is_swap_default_replenishment"];
                        if (reader["message_processor_id"] != DBNull.Value)
                            currentAtm.message_processor_id = (int?)reader["message_processor_id"];
                        if (reader["last_ping_status"] != DBNull.Value)
                            currentAtm.last_ping_status = (string)reader["last_ping_status"];
                        if (reader["last_ping_executed_at"] != DBNull.Value)
                            currentAtm.last_ping_executed_at = (DateTime?)reader["last_ping_executed_at"];
                        if (reader["last_telnet_status"] != DBNull.Value)
                            currentAtm.last_telnet_status = (string)reader["last_telnet_status"];
                        if (reader["last_telnet_executed_at"] != DBNull.Value)
                            currentAtm.last_telnet_executed_at = (DateTime?)reader["last_telnet_executed_at"];
                        if (reader["last_archive_file_received_at"] != DBNull.Value)
                            currentAtm.last_archive_file_received_at = (DateTime?)reader["last_archive_file_received_at"];
                        if (reader["is_sdm"] != DBNull.Value)
                            currentAtm.is_sdm = (bool)reader["is_sdm"];
                        if (reader["initEjExecTime"] != DBNull.Value)
                            currentAtm.initEjExecTime = (string)reader["initEjExecTime"];
                        if (reader["ccmsagent_last_reported_heartbeat"] != DBNull.Value)
                            currentAtm.ccmsagent_last_reported_heartbeat = (DateTime?)reader["ccmsagent_last_reported_heartbeat"];
                        if (reader["ccmsservicemanager_last_reported_heartbeat"] != DBNull.Value)
                            currentAtm.ccmsservicemanager_last_reported_heartbeat = (DateTime?)reader["ccmsservicemanager_last_reported_heartbeat"];
                        if (reader["distribution_port"] != DBNull.Value)
                            currentAtm.distribution_port = (int?)reader["distribution_port"];
                        if (reader["parser_rep_date_format"] != DBNull.Value)
                            currentAtm.parser_rep_date_format = (string)reader["parser_rep_date_format"];
                        if (reader["type1_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type1_min_notes_threshold = (int?)reader["type1_min_notes_threshold"];
                        if (reader["type2_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type2_min_notes_threshold = (int?)reader["type2_min_notes_threshold"];
                        if (reader["type3_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type3_min_notes_threshold = (int?)reader["type3_min_notes_threshold"];
                        if (reader["type4_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type4_min_notes_threshold = (int?)reader["type4_min_notes_threshold"];
                        if (reader["type1_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type1_suggested_notes_normal_days = (int?)reader["type1_suggested_notes_normal_days"];
                        if (reader["type2_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type2_suggested_notes_normal_days = (int?)reader["type2_suggested_notes_normal_days"];
                        if (reader["type3_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type3_suggested_notes_normal_days = (int?)reader["type3_suggested_notes_normal_days"];
                        if (reader["type4_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type4_suggested_notes_normal_days = (int?)reader["type4_suggested_notes_normal_days"];
                        if (reader["type5_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type5_suggested_notes_normal_days = (int?)reader["type5_suggested_notes_normal_days"];
                        if (reader["type6_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type6_suggested_notes_normal_days = (int?)reader["type6_suggested_notes_normal_days"];
                        if (reader["type7_suggested_notes_normal_days"] != DBNull.Value)
                            currentAtm.type7_suggested_notes_normal_days = (int?)reader["type7_suggested_notes_normal_days"];
                        if (reader["type1_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type1_suggested_notes_salary_days = (int?)reader["type1_suggested_notes_salary_days"];
                        if (reader["type2_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type2_suggested_notes_salary_days = (int?)reader["type2_suggested_notes_salary_days"];
                        if (reader["type3_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type3_suggested_notes_salary_days = (int?)reader["type3_suggested_notes_salary_days"];
                        if (reader["type4_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type4_suggested_notes_salary_days = (int?)reader["type4_suggested_notes_salary_days"];
                        if (reader["type5_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type5_suggested_notes_salary_days = (int?)reader["type5_suggested_notes_salary_days"];
                        if (reader["type6_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type6_suggested_notes_salary_days = (int?)reader["type6_suggested_notes_salary_days"];
                        if (reader["type7_suggested_notes_salary_days"] != DBNull.Value)
                            currentAtm.type7_suggested_notes_salary_days = (int?)reader["type7_suggested_notes_salary_days"];
                        if (reader["avg_dispensed"] != DBNull.Value)
                            currentAtm.avg_dispensed = (decimal?)reader["avg_dispensed"];
                        if (reader["spare_cash"] != DBNull.Value)
                            currentAtm.spare_cash = (decimal?)reader["spare_cash"];
                        if (reader["dispensing_behavior"] != DBNull.Value)
                            currentAtm.dispensing_behavior = (int?)reader["dispensing_behavior"];
                        if (reader["avg_dispensed_salary_days"] != DBNull.Value)
                            currentAtm.avg_dispensed_salary_days = (decimal?)reader["avg_dispensed_salary_days"];
                        if (reader["inactivity_period_salary_days"] != DBNull.Value)
                            currentAtm.inactivity_period_salary_days = (int?)reader["inactivity_period_salary_days"];
                        if (reader["inactivity_period_normal_days"] != DBNull.Value)
                            currentAtm.inactivity_period_normal_days = (int?)reader["inactivity_period_normal_days"];
                        if (reader["type1_min_notes_threshold_value"] != DBNull.Value)
                            currentAtm.type1_min_notes_threshold_value = (int?)reader["type1_min_notes_threshold_value"];
                        if (reader["type2_min_notes_threshold_value"] != DBNull.Value)
                            currentAtm.type2_min_notes_threshold_value = (int?)reader["type2_min_notes_threshold_value"];
                        if (reader["type3_min_notes_threshold_value"] != DBNull.Value)
                            currentAtm.type3_min_notes_threshold_value = (int?)reader["type3_min_notes_threshold_value"];
                        if (reader["type4_min_notes_threshold_value"] != DBNull.Value)
                            currentAtm.type4_min_notes_threshold_value = (int?)reader["type4_min_notes_threshold_value"];
                        if (reader["bna_allowed_inactivity_period_normal_days"] != DBNull.Value)
                            currentAtm.bna_allowed_inactivity_period_normal_days = (int?)reader["bna_allowed_inactivity_period_normal_days"];
                        if (reader["bna_allowed_inactivity_period_salary_days"] != DBNull.Value)
                            currentAtm.bna_allowed_inactivity_period_salary_days = (int?)reader["bna_allowed_inactivity_period_salary_days"];
                        if (reader["cheque_allowed_inactivity_period_normal_days"] != DBNull.Value)
                            currentAtm.cheque_allowed_inactivity_period_normal_days = (int?)reader["cheque_allowed_inactivity_period_normal_days"];
                        if (reader["cheque_allowed_inactivity_period_salary_days"] != DBNull.Value)
                            currentAtm.cheque_allowed_inactivity_period_salary_days = (int?)reader["cheque_allowed_inactivity_period_salary_days"];
                        if (reader["min_operating_balance_normal_days"] != DBNull.Value)
                            currentAtm.min_operating_balance_normal_days = (decimal?)reader["min_operating_balance_normal_days"];
                        if (reader["min_operating_balance_salary_days"] != DBNull.Value)
                            currentAtm.min_operating_balance_salary_days = (decimal?)reader["min_operating_balance_salary_days"];
                        if (reader["is_order_auto_generated"] != DBNull.Value)
                            currentAtm.is_order_auto_generated = (bool?)reader["is_order_auto_generated"];
                        if (reader["is_win7_machine"] != DBNull.Value)
                            currentAtm.is_win7_machine = (bool?)reader["is_win7_machine"];
                        if (reader["is_branch_atm"] != DBNull.Value)
                            currentAtm.is_branch_atm = (bool?)reader["is_branch_atm"];
                        if (reader["is_emirate_islamic"] != DBNull.Value)
                            currentAtm.is_emirate_islamic = (bool?)reader["is_emirate_islamic"];
                        if (reader["is_itm"] != DBNull.Value)
                            currentAtm.is_itm = (bool?)reader["is_itm"];
                        if (reader["is_bulk_cash_deposit"] != DBNull.Value)
                            currentAtm.is_bulk_cash_deposit = (bool?)reader["is_bulk_cash_deposit"];
                        if (reader["is_combo"] != DBNull.Value)
                            currentAtm.is_combo = (bool?)reader["is_combo"];
                        if (reader["atm_cost"] != DBNull.Value)
                            currentAtm.atm_cost = (decimal?)reader["atm_cost"];
                        if (reader["software_cost"] != DBNull.Value)
                            currentAtm.software_cost = (decimal?)reader["software_cost"];
                        if (reader["network_cost"] != DBNull.Value)
                            currentAtm.network_cost = (decimal?)reader["network_cost"];
                        if (reader["site_preparation_cost"] != DBNull.Value)
                            currentAtm.site_preparation_cost = (decimal?)reader["site_preparation_cost"];
                        if (reader["security_infrastructure_cost"] != DBNull.Value)
                            currentAtm.security_infrastructure_cost = (decimal?)reader["security_infrastructure_cost"];
                        if (reader["im_branch_code"] != DBNull.Value)
                            currentAtm.im_branch_code = (string)reader["im_branch_code"];
                        if (reader["im_en_id"] != DBNull.Value)
                            currentAtm.im_en_id = (string)reader["im_en_id"];
                        if (reader["im_location"] != DBNull.Value)
                            currentAtm.im_location = (string)reader["im_location"];
                        if (reader["im_business_area"] != DBNull.Value)
                            currentAtm.im_business_area = (string)reader["im_business_area"];
                        if (reader["im_circle"] != DBNull.Value)
                            currentAtm.im_circle = (string)reader["im_circle"];
                        if (reader["cit_id"] != DBNull.Value)
                            currentAtm.cit_id = (int?)reader["cit_id"];
                        if (reader["atm_bandwidth_id"] != DBNull.Value)
                            currentAtm.atm_bandwidth_id = (int?)reader["atm_bandwidth_id"];
                        if (reader["atm_model_id"] != DBNull.Value)
                            currentAtm.atm_model_id = (int?)reader["atm_model_id"];
                        if (reader["is_recycler"] != DBNull.Value)
                            currentAtm.is_recycler = (bool?)reader["is_recycler"];
                    }

                    currentAtm.isNewEntity = false;
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

            public Atm CurrentAtm
            {
                get { return currentAtm; }
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


        #region Atm functions

        public static AtmReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ATM_id == (Columns.ATM_id & columns))
                qry.Append("ATM_id,");
            if (Columns.last_status_reply == (Columns.last_status_reply & columns))
                qry.Append("last_status_reply,");
            if (Columns.region_id == (Columns.region_id & columns))
                qry.Append("region_id,");
            if (Columns.title == (Columns.title & columns))
                qry.Append("title,");
            if (Columns.IP == (Columns.IP & columns))
                qry.Append("IP,");
            if (Columns.port == (Columns.port & columns))
                qry.Append("port,");
            if (Columns.modified_by == (Columns.modified_by & columns))
                qry.Append("modified_by,");
            if (Columns.created_by == (Columns.created_by & columns))
                qry.Append("created_by,");
            if (Columns.is_active == (Columns.is_active & columns))
                qry.Append("is_active,");
            if (Columns.creation_time == (Columns.creation_time & columns))
                qry.Append("creation_time,");
            if (Columns.atm_type == (Columns.atm_type & columns))
                qry.Append("atm_type,");
            if (Columns.cassette1_capacity == (Columns.cassette1_capacity & columns))
                qry.Append("cassette1_capacity,");
            if (Columns.cassette1_denomination == (Columns.cassette1_denomination & columns))
                qry.Append("cassette1_denomination,");
            if (Columns.cassette2_capacity == (Columns.cassette2_capacity & columns))
                qry.Append("cassette2_capacity,");
            if (Columns.cassette2_denomination == (Columns.cassette2_denomination & columns))
                qry.Append("cassette2_denomination,");
            if (Columns.cassette3_denomination == (Columns.cassette3_denomination & columns))
                qry.Append("cassette3_denomination,");
            if (Columns.cassette3_capacity == (Columns.cassette3_capacity & columns))
                qry.Append("cassette3_capacity,");
            if (Columns.cassette4_denomination == (Columns.cassette4_denomination & columns))
                qry.Append("cassette4_denomination,");
            if (Columns.cassette4_capacity == (Columns.cassette4_capacity & columns))
                qry.Append("cassette4_capacity,");
            if (Columns.cassette5_denomination == (Columns.cassette5_denomination & columns))
                qry.Append("cassette5_denomination,");
            if (Columns.cassette5_capacity == (Columns.cassette5_capacity & columns))
                qry.Append("cassette5_capacity,");
            if (Columns.cassette6_denomination == (Columns.cassette6_denomination & columns))
                qry.Append("cassette6_denomination,");
            if (Columns.cassette6_capacity == (Columns.cassette6_capacity & columns))
                qry.Append("cassette6_capacity,");
            if (Columns.cassette7_denomination == (Columns.cassette7_denomination & columns))
                qry.Append("cassette7_denomination,");
            if (Columns.cassette7_capacity == (Columns.cassette7_capacity & columns))
                qry.Append("cassette7_capacity,");
            if (Columns.last_wincor_sent == (Columns.last_wincor_sent & columns))
                qry.Append("last_wincor_sent,");
            if (Columns.is_healthy == (Columns.is_healthy & columns))
                qry.Append("is_healthy,");
            if (Columns.location == (Columns.location & columns))
                qry.Append("location,");
            if (Columns.address1 == (Columns.address1 & columns))
                qry.Append("address1,");
            if (Columns.address2 == (Columns.address2 & columns))
                qry.Append("address2,");
            if (Columns.city == (Columns.city & columns))
                qry.Append("city,");
            if (Columns.country == (Columns.country & columns))
                qry.Append("country,");
            if (Columns.zip_code == (Columns.zip_code & columns))
                qry.Append("zip_code,");
            if (Columns.location_type == (Columns.location_type & columns))
                qry.Append("location_type,");
            if (Columns.service_status == (Columns.service_status & columns))
                qry.Append("service_status,");
            if (Columns.holiday_status == (Columns.holiday_status & columns))
                qry.Append("holiday_status,");
            if (Columns.business_days == (Columns.business_days & columns))
                qry.Append("business_days,");
            if (Columns.time_zone == (Columns.time_zone & columns))
                qry.Append("time_zone,");
            if (Columns.max_notes_per_cassette == (Columns.max_notes_per_cassette & columns))
                qry.Append("max_notes_per_cassette,");
            if (Columns.cassette1_split_percentage == (Columns.cassette1_split_percentage & columns))
                qry.Append("cassette1_split_percentage,");
            if (Columns.cassette2_split_percentage == (Columns.cassette2_split_percentage & columns))
                qry.Append("cassette2_split_percentage,");
            if (Columns.cassette3_split_percentage == (Columns.cassette3_split_percentage & columns))
                qry.Append("cassette3_split_percentage,");
            if (Columns.cassette4_split_percentage == (Columns.cassette4_split_percentage & columns))
                qry.Append("cassette4_split_percentage,");
            if (Columns.cassette5_split_percentage == (Columns.cassette5_split_percentage & columns))
                qry.Append("cassette5_split_percentage,");
            if (Columns.cassette6_split_percentage == (Columns.cassette6_split_percentage & columns))
                qry.Append("cassette6_split_percentage,");
            if (Columns.cassette7_split_percentage == (Columns.cassette7_split_percentage & columns))
                qry.Append("cassette7_split_percentage,");
            if (Columns.interest_rate == (Columns.interest_rate & columns))
                qry.Append("interest_rate,");
            if (Columns.insurance_rate == (Columns.insurance_rate & columns))
                qry.Append("insurance_rate,");
            if (Columns.max_holding_amount == (Columns.max_holding_amount & columns))
                qry.Append("max_holding_amount,");
            if (Columns.min_operating_balance == (Columns.min_operating_balance & columns))
                qry.Append("min_operating_balance,");
            if (Columns.min_amount_for_normal_delivery == (Columns.min_amount_for_normal_delivery & columns))
                qry.Append("min_amount_for_normal_delivery,");
            if (Columns.bank_cash_center_id == (Columns.bank_cash_center_id & columns))
                qry.Append("bank_cash_center_id,");
            if (Columns.CIT_cash_center_servicer == (Columns.CIT_cash_center_servicer & columns))
                qry.Append("CIT_cash_center_servicer,");
            if (Columns.depot_id == (Columns.depot_id & columns))
                qry.Append("depot_id,");
            if (Columns.secondary_depot_vault_id == (Columns.secondary_depot_vault_id & columns))
                qry.Append("secondary_depot_vault_id,");
            if (Columns.new_atm_scenario == (Columns.new_atm_scenario & columns))
                qry.Append("new_atm_scenario,");
            if (Columns.cash_swap_days == (Columns.cash_swap_days & columns))
                qry.Append("cash_swap_days,");
            if (Columns.mandatory_cash_swap_days == (Columns.mandatory_cash_swap_days & columns))
                qry.Append("mandatory_cash_swap_days,");
            if (Columns.cash_swap_cycle == (Columns.cash_swap_cycle & columns))
                qry.Append("cash_swap_cycle,");
            if (Columns.cash_swap_lead_time == (Columns.cash_swap_lead_time & columns))
                qry.Append("cash_swap_lead_time,");
            if (Columns.cash_swap_start_date == (Columns.cash_swap_start_date & columns))
                qry.Append("cash_swap_start_date,");
            if (Columns.cash_swap_handling_cost == (Columns.cash_swap_handling_cost & columns))
                qry.Append("cash_swap_handling_cost,");
            if (Columns.cash_swap_costs == (Columns.cash_swap_costs & columns))
                qry.Append("cash_swap_costs,");
            if (Columns.emergency_days == (Columns.emergency_days & columns))
                qry.Append("emergency_days,");
            if (Columns.emergency_lead_time == (Columns.emergency_lead_time & columns))
                qry.Append("emergency_lead_time,");
            if (Columns.emergency_cost == (Columns.emergency_cost & columns))
                qry.Append("emergency_cost,");
            if (Columns.contact1_email == (Columns.contact1_email & columns))
                qry.Append("contact1_email,");
            if (Columns.contact2_email == (Columns.contact2_email & columns))
                qry.Append("contact2_email,");
            if (Columns.contact3_email == (Columns.contact3_email & columns))
                qry.Append("contact3_email,");
            if (Columns.contact1_phone == (Columns.contact1_phone & columns))
                qry.Append("contact1_phone,");
            if (Columns.contact2_phone == (Columns.contact2_phone & columns))
                qry.Append("contact2_phone,");
            if (Columns.contact3_phone == (Columns.contact3_phone & columns))
                qry.Append("contact3_phone,");
            if (Columns.effective_date == (Columns.effective_date & columns))
                qry.Append("effective_date,");
            if (Columns.suspend_cash_order == (Columns.suspend_cash_order & columns))
                qry.Append("suspend_cash_order,");
            if (Columns.is_atm == (Columns.is_atm & columns))
                qry.Append("is_atm,");
            if (Columns.is_cdm == (Columns.is_cdm & columns))
                qry.Append("is_cdm,");
            if (Columns.is_ccdm == (Columns.is_ccdm & columns))
                qry.Append("is_ccdm,");
            if (Columns.cdm_cassette1_capacity == (Columns.cdm_cassette1_capacity & columns))
                qry.Append("cdm_cassette1_capacity,");
            if (Columns.cdm_cassette2_capacity == (Columns.cdm_cassette2_capacity & columns))
                qry.Append("cdm_cassette2_capacity,");
            if (Columns.cdm_cassette3_capacity == (Columns.cdm_cassette3_capacity & columns))
                qry.Append("cdm_cassette3_capacity,");
            if (Columns.cdm_cassette4_capacity == (Columns.cdm_cassette4_capacity & columns))
                qry.Append("cdm_cassette4_capacity,");
            if (Columns.ccdm_cassette1_capacity == (Columns.ccdm_cassette1_capacity & columns))
                qry.Append("ccdm_cassette1_capacity,");
            if (Columns.ccdm_cassette2_capacity == (Columns.ccdm_cassette2_capacity & columns))
                qry.Append("ccdm_cassette2_capacity,");
            if (Columns.ccdm_cassette3_capacity == (Columns.ccdm_cassette3_capacity & columns))
                qry.Append("ccdm_cassette3_capacity,");
            if (Columns.ccdm_cassette4_capacity == (Columns.ccdm_cassette4_capacity & columns))
                qry.Append("ccdm_cassette4_capacity,");
            if (Columns.cdm_cassette1_threshold == (Columns.cdm_cassette1_threshold & columns))
                qry.Append("cdm_cassette1_threshold,");
            if (Columns.cdm_cassette2_threshold == (Columns.cdm_cassette2_threshold & columns))
                qry.Append("cdm_cassette2_threshold,");
            if (Columns.cdm_cassette3_threshold == (Columns.cdm_cassette3_threshold & columns))
                qry.Append("cdm_cassette3_threshold,");
            if (Columns.cdm_cassette4_threshold == (Columns.cdm_cassette4_threshold & columns))
                qry.Append("cdm_cassette4_threshold,");
            if (Columns.ccdm_cassette1_threshold == (Columns.ccdm_cassette1_threshold & columns))
                qry.Append("ccdm_cassette1_threshold,");
            if (Columns.ccdm_cassette2_threshold == (Columns.ccdm_cassette2_threshold & columns))
                qry.Append("ccdm_cassette2_threshold,");
            if (Columns.ccdm_cassette3_threshold == (Columns.ccdm_cassette3_threshold & columns))
                qry.Append("ccdm_cassette3_threshold,");
            if (Columns.ccdm_cassette4_threshold == (Columns.ccdm_cassette4_threshold & columns))
                qry.Append("ccdm_cassette4_threshold,");
            if (Columns.note_set_type_id == (Columns.note_set_type_id & columns))
                qry.Append("note_set_type_id,");
            if (Columns.ccdm_cassette5_capacity == (Columns.ccdm_cassette5_capacity & columns))
                qry.Append("ccdm_cassette5_capacity,");
            if (Columns.ccdm_cassette5_threshold == (Columns.ccdm_cassette5_threshold & columns))
                qry.Append("ccdm_cassette5_threshold,");
            if (Columns.startup_sleep_interval == (Columns.startup_sleep_interval & columns))
                qry.Append("startup_sleep_interval,");
            if (Columns.debug_level == (Columns.debug_level & columns))
                qry.Append("debug_level,");
            if (Columns.exclude_dff == (Columns.exclude_dff & columns))
                qry.Append("exclude_dff,");
            if (Columns.purge1_threshold == (Columns.purge1_threshold & columns))
                qry.Append("purge1_threshold,");
            if (Columns.is_purge1_threshold_selected == (Columns.is_purge1_threshold_selected & columns))
                qry.Append("is_purge1_threshold_selected,");
            if (Columns.purge2_threshold == (Columns.purge2_threshold & columns))
                qry.Append("purge2_threshold,");
            if (Columns.is_purge2_threshold_selected == (Columns.is_purge2_threshold_selected & columns))
                qry.Append("is_purge2_threshold_selected,");
            if (Columns.purge3_threshold == (Columns.purge3_threshold & columns))
                qry.Append("purge3_threshold,");
            if (Columns.is_purge3_threshold_selected == (Columns.is_purge3_threshold_selected & columns))
                qry.Append("is_purge3_threshold_selected,");
            if (Columns.purge4_threshold == (Columns.purge4_threshold & columns))
                qry.Append("purge4_threshold,");
            if (Columns.is_purge4_threshold_selected == (Columns.is_purge4_threshold_selected & columns))
                qry.Append("is_purge4_threshold_selected,");
            if (Columns.purge5_threshold == (Columns.purge5_threshold & columns))
                qry.Append("purge5_threshold,");
            if (Columns.is_purge5_threshold_selected == (Columns.is_purge5_threshold_selected & columns))
                qry.Append("is_purge5_threshold_selected,");
            if (Columns.purge6_threshold == (Columns.purge6_threshold & columns))
                qry.Append("purge6_threshold,");
            if (Columns.is_purge6_threshold_selected == (Columns.is_purge6_threshold_selected & columns))
                qry.Append("is_purge6_threshold_selected,");
            if (Columns.purge7_threshold == (Columns.purge7_threshold & columns))
                qry.Append("purge7_threshold,");
            if (Columns.is_purge7_threshold_selected == (Columns.is_purge7_threshold_selected & columns))
                qry.Append("is_purge7_threshold_selected,");
            if (Columns.retry_count_cash_order_upload == (Columns.retry_count_cash_order_upload & columns))
                qry.Append("retry_count_cash_order_upload,");
            if (Columns.retry_count_conf_upload == (Columns.retry_count_conf_upload & columns))
                qry.Append("retry_count_conf_upload,");
            if (Columns.retry_count_counter_file == (Columns.retry_count_counter_file & columns))
                qry.Append("retry_count_counter_file,");
            if (Columns.retry_count_restart_schedule == (Columns.retry_count_restart_schedule & columns))
                qry.Append("retry_count_restart_schedule,");
            if (Columns.retry_count_datetime_schedule == (Columns.retry_count_datetime_schedule & columns))
                qry.Append("retry_count_datetime_schedule,");
            if (Columns.retry_count_alert == (Columns.retry_count_alert & columns))
                qry.Append("retry_count_alert,");
            if (Columns.CountsClearRetries == (Columns.CountsClearRetries & columns))
                qry.Append("CountsClearRetries,");
            if (Columns.TCPTimeout == (Columns.TCPTimeout & columns))
                qry.Append("TCPTimeout,");
            if (Columns.SleepInterval == (Columns.SleepInterval & columns))
                qry.Append("SleepInterval,");
            if (Columns.CPMCommandWait == (Columns.CPMCommandWait & columns))
                qry.Append("CPMCommandWait,");
            if (Columns.CPMCommandSleep == (Columns.CPMCommandSleep & columns))
                qry.Append("CPMCommandSleep,");
            if (Columns.AANDCApplications1 == (Columns.AANDCApplications1 & columns))
                qry.Append("AANDCApplications1,");
            if (Columns.AANDCApplications2 == (Columns.AANDCApplications2 & columns))
                qry.Append("AANDCApplications2,");
            if (Columns.AANDCApplications3 == (Columns.AANDCApplications3 & columns))
                qry.Append("AANDCApplications3,");
            if (Columns.AANDCApplications4 == (Columns.AANDCApplications4 & columns))
                qry.Append("AANDCApplications4,");
            if (Columns.AANDCApplications5 == (Columns.AANDCApplications5 & columns))
                qry.Append("AANDCApplications5,");
            if (Columns.Monitoring_Retries == (Columns.Monitoring_Retries & columns))
                qry.Append("Monitoring_Retries,");
            if (Columns.WindowSwitch_Sleep == (Columns.WindowSwitch_Sleep & columns))
                qry.Append("WindowSwitch_Sleep,");
            if (Columns.AppSwitch_Sleep == (Columns.AppSwitch_Sleep & columns))
                qry.Append("AppSwitch_Sleep,");
            if (Columns.MonitoringCycle_Sleep == (Columns.MonitoringCycle_Sleep & columns))
                qry.Append("MonitoringCycle_Sleep,");
            if (Columns.CPMLogLevel == (Columns.CPMLogLevel & columns))
                qry.Append("CPMLogLevel,");
            if (Columns.IsDispenserRealTimeNotificationEnabled == (Columns.IsDispenserRealTimeNotificationEnabled & columns))
                qry.Append("IsDispenserRealTimeNotificationEnabled,");
            if (Columns.IsBNARealTimeNotificationEnabled == (Columns.IsBNARealTimeNotificationEnabled & columns))
                qry.Append("IsBNARealTimeNotificationEnabled,");
            if (Columns.IsCPMRealTimeNotificationEnabled == (Columns.IsCPMRealTimeNotificationEnabled & columns))
                qry.Append("IsCPMRealTimeNotificationEnabled,");
            if (Columns.IsReplenishmentRealTimeNotificationEnabled == (Columns.IsReplenishmentRealTimeNotificationEnabled & columns))
                qry.Append("IsReplenishmentRealTimeNotificationEnabled,");
            if (Columns.IsOutOfCashRealTimeNotificationEnabled == (Columns.IsOutOfCashRealTimeNotificationEnabled & columns))
                qry.Append("IsOutOfCashRealTimeNotificationEnabled,");
            if (Columns.IsDispenserMismatchRealTimeNotificationEnabled == (Columns.IsDispenserMismatchRealTimeNotificationEnabled & columns))
                qry.Append("IsDispenserMismatchRealTimeNotificationEnabled,");
            if (Columns.IsBNAMismatchRealTimeNotificationEnabled == (Columns.IsBNAMismatchRealTimeNotificationEnabled & columns))
                qry.Append("IsBNAMismatchRealTimeNotificationEnabled,");
            if (Columns.IsCPMMismatchRealTimeNotificationEnabled == (Columns.IsCPMMismatchRealTimeNotificationEnabled & columns))
                qry.Append("IsCPMMismatchRealTimeNotificationEnabled,");
            if (Columns.IsCounterExplodedRealTimeNotificationEnabled == (Columns.IsCounterExplodedRealTimeNotificationEnabled & columns))
                qry.Append("IsCounterExplodedRealTimeNotificationEnabled,");
            if (Columns.Type1MinimumNotes == (Columns.Type1MinimumNotes & columns))
                qry.Append("Type1MinimumNotes,");
            if (Columns.Type2MinimumNotes == (Columns.Type2MinimumNotes & columns))
                qry.Append("Type2MinimumNotes,");
            if (Columns.Type3MinimumNotes == (Columns.Type3MinimumNotes & columns))
                qry.Append("Type3MinimumNotes,");
            if (Columns.Type4MinimumNotes == (Columns.Type4MinimumNotes & columns))
                qry.Append("Type4MinimumNotes,");
            if (Columns.Type5MinimumNotes == (Columns.Type5MinimumNotes & columns))
                qry.Append("Type5MinimumNotes,");
            if (Columns.Type6MinimumNotes == (Columns.Type6MinimumNotes & columns))
                qry.Append("Type6MinimumNotes,");
            if (Columns.Type7MinimumNotes == (Columns.Type7MinimumNotes & columns))
                qry.Append("Type7MinimumNotes,");
            if (Columns.cpm_command == (Columns.cpm_command & columns))
                qry.Append("cpm_command,");
            if (Columns.allowed_inactivity_period == (Columns.allowed_inactivity_period & columns))
                qry.Append("allowed_inactivity_period,");
            if (Columns.gl_number == (Columns.gl_number & columns))
                qry.Append("gl_number,");
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
            if (Columns.description == (Columns.description & columns))
                qry.Append("description,");
            if (Columns.is_dff_generation_halt == (Columns.is_dff_generation_halt & columns))
                qry.Append("is_dff_generation_halt,");
            if (Columns.cit_atm_title == (Columns.cit_atm_title & columns))
                qry.Append("cit_atm_title,");
            if (Columns.cheque_allowed_inactivity_period == (Columns.cheque_allowed_inactivity_period & columns))
                qry.Append("cheque_allowed_inactivity_period,");
            if (Columns.bna_allowed_inactivity_period == (Columns.bna_allowed_inactivity_period & columns))
                qry.Append("bna_allowed_inactivity_period,");
            if (Columns.out_of_cash_threshold == (Columns.out_of_cash_threshold & columns))
                qry.Append("out_of_cash_threshold,");
            if (Columns.no_of_dispensed_transactions_to_monitor == (Columns.no_of_dispensed_transactions_to_monitor & columns))
                qry.Append("no_of_dispensed_transactions_to_monitor,");
            if (Columns.is_ej_enabled == (Columns.is_ej_enabled & columns))
                qry.Append("is_ej_enabled,");
            if (Columns.is_counter_enabled == (Columns.is_counter_enabled & columns))
                qry.Append("is_counter_enabled,");
            if (Columns.priority == (Columns.priority & columns))
                qry.Append("priority,");
            if (Columns.longitude == (Columns.longitude & columns))
                qry.Append("longitude,");
            if (Columns.latitude == (Columns.latitude & columns))
                qry.Append("latitude,");
            if (Columns.on_us_amount == (Columns.on_us_amount & columns))
                qry.Append("on_us_amount,");
            if (Columns.not_on_us_amount == (Columns.not_on_us_amount & columns))
                qry.Append("not_on_us_amount,");
            if (Columns.standard_order_type1 == (Columns.standard_order_type1 & columns))
                qry.Append("standard_order_type1,");
            if (Columns.standard_order_type2 == (Columns.standard_order_type2 & columns))
                qry.Append("standard_order_type2,");
            if (Columns.standard_order_type3 == (Columns.standard_order_type3 & columns))
                qry.Append("standard_order_type3,");
            if (Columns.standard_order_type4 == (Columns.standard_order_type4 & columns))
                qry.Append("standard_order_type4,");
            if (Columns.standard_order_type5 == (Columns.standard_order_type5 & columns))
                qry.Append("standard_order_type5,");
            if (Columns.standard_order_type6 == (Columns.standard_order_type6 & columns))
                qry.Append("standard_order_type6,");
            if (Columns.standard_order_type7 == (Columns.standard_order_type7 & columns))
                qry.Append("standard_order_type7,");
            if (Columns.protocol_type_id == (Columns.protocol_type_id & columns))
                qry.Append("protocol_type_id,");
            if (Columns.current_mode == (Columns.current_mode & columns))
                qry.Append("current_mode,");
            if (Columns.aggregate_state == (Columns.aggregate_state & columns))
                qry.Append("aggregate_state,");
            if (Columns.last_boot_time == (Columns.last_boot_time & columns))
                qry.Append("last_boot_time,");
            if (Columns.discovery_time == (Columns.discovery_time & columns))
                qry.Append("discovery_time,");
            if (Columns.last_scan_time == (Columns.last_scan_time & columns))
                qry.Append("last_scan_time,");
            if (Columns.communication_status == (Columns.communication_status & columns))
                qry.Append("communication_status,");
            if (Columns.is_critical == (Columns.is_critical & columns))
                qry.Append("is_critical,");
            if (Columns.current_mode_modified_on == (Columns.current_mode_modified_on & columns))
                qry.Append("current_mode_modified_on,");
            if (Columns.Last_Notification_Received_On == (Columns.Last_Notification_Received_On & columns))
                qry.Append("Last_Notification_Received_On,");
            if (Columns.Last_Notification_Time == (Columns.Last_Notification_Time & columns))
                qry.Append("Last_Notification_Time,");
            if (Columns.normal_order_cost == (Columns.normal_order_cost & columns))
                qry.Append("normal_order_cost,");
            if (Columns.emergency_order_cost == (Columns.emergency_order_cost & columns))
                qry.Append("emergency_order_cost,");
            if (Columns.receipt_transaction_cutoff == (Columns.receipt_transaction_cutoff & columns))
                qry.Append("receipt_transaction_cutoff,");
            if (Columns.is_swap_default_replenishment == (Columns.is_swap_default_replenishment & columns))
                qry.Append("is_swap_default_replenishment,");
            if (Columns.message_processor_id == (Columns.message_processor_id & columns))
                qry.Append("message_processor_id,");
            if (Columns.last_ping_status == (Columns.last_ping_status & columns))
                qry.Append("last_ping_status,");
            if (Columns.last_ping_executed_at == (Columns.last_ping_executed_at & columns))
                qry.Append("last_ping_executed_at,");
            if (Columns.last_telnet_status == (Columns.last_telnet_status & columns))
                qry.Append("last_telnet_status,");
            if (Columns.last_telnet_executed_at == (Columns.last_telnet_executed_at & columns))
                qry.Append("last_telnet_executed_at,");
            if (Columns.last_archive_file_received_at == (Columns.last_archive_file_received_at & columns))
                qry.Append("last_archive_file_received_at,");
            if (Columns.is_sdm == (Columns.is_sdm & columns))
                qry.Append("is_sdm,");
            if (Columns.initEjExecTime == (Columns.initEjExecTime & columns))
                qry.Append("initEjExecTime,");
            if (Columns.ccmsagent_last_reported_heartbeat == (Columns.ccmsagent_last_reported_heartbeat & columns))
                qry.Append("ccmsagent_last_reported_heartbeat,");
            if (Columns.ccmsservicemanager_last_reported_heartbeat == (Columns.ccmsservicemanager_last_reported_heartbeat & columns))
                qry.Append("ccmsservicemanager_last_reported_heartbeat,");
            if (Columns.distribution_port == (Columns.distribution_port & columns))
                qry.Append("distribution_port,");
            if (Columns.parser_rep_date_format == (Columns.parser_rep_date_format & columns))
                qry.Append("parser_rep_date_format,");
            if (Columns.type1_min_notes_threshold == (Columns.type1_min_notes_threshold & columns))
                qry.Append("type1_min_notes_threshold,");
            if (Columns.type2_min_notes_threshold == (Columns.type2_min_notes_threshold & columns))
                qry.Append("type2_min_notes_threshold,");
            if (Columns.type3_min_notes_threshold == (Columns.type3_min_notes_threshold & columns))
                qry.Append("type3_min_notes_threshold,");
            if (Columns.type4_min_notes_threshold == (Columns.type4_min_notes_threshold & columns))
                qry.Append("type4_min_notes_threshold,");
            if (Columns.type1_suggested_notes_normal_days == (Columns.type1_suggested_notes_normal_days & columns))
                qry.Append("type1_suggested_notes_normal_days,");
            if (Columns.type2_suggested_notes_normal_days == (Columns.type2_suggested_notes_normal_days & columns))
                qry.Append("type2_suggested_notes_normal_days,");
            if (Columns.type3_suggested_notes_normal_days == (Columns.type3_suggested_notes_normal_days & columns))
                qry.Append("type3_suggested_notes_normal_days,");
            if (Columns.type4_suggested_notes_normal_days == (Columns.type4_suggested_notes_normal_days & columns))
                qry.Append("type4_suggested_notes_normal_days,");
            if (Columns.type5_suggested_notes_normal_days == (Columns.type5_suggested_notes_normal_days & columns))
                qry.Append("type5_suggested_notes_normal_days,");
            if (Columns.type6_suggested_notes_normal_days == (Columns.type6_suggested_notes_normal_days & columns))
                qry.Append("type6_suggested_notes_normal_days,");
            if (Columns.type7_suggested_notes_normal_days == (Columns.type7_suggested_notes_normal_days & columns))
                qry.Append("type7_suggested_notes_normal_days,");
            if (Columns.type1_suggested_notes_salary_days == (Columns.type1_suggested_notes_salary_days & columns))
                qry.Append("type1_suggested_notes_salary_days,");
            if (Columns.type2_suggested_notes_salary_days == (Columns.type2_suggested_notes_salary_days & columns))
                qry.Append("type2_suggested_notes_salary_days,");
            if (Columns.type3_suggested_notes_salary_days == (Columns.type3_suggested_notes_salary_days & columns))
                qry.Append("type3_suggested_notes_salary_days,");
            if (Columns.type4_suggested_notes_salary_days == (Columns.type4_suggested_notes_salary_days & columns))
                qry.Append("type4_suggested_notes_salary_days,");
            if (Columns.type5_suggested_notes_salary_days == (Columns.type5_suggested_notes_salary_days & columns))
                qry.Append("type5_suggested_notes_salary_days,");
            if (Columns.type6_suggested_notes_salary_days == (Columns.type6_suggested_notes_salary_days & columns))
                qry.Append("type6_suggested_notes_salary_days,");
            if (Columns.type7_suggested_notes_salary_days == (Columns.type7_suggested_notes_salary_days & columns))
                qry.Append("type7_suggested_notes_salary_days,");
            if (Columns.avg_dispensed == (Columns.avg_dispensed & columns))
                qry.Append("avg_dispensed,");
            if (Columns.spare_cash == (Columns.spare_cash & columns))
                qry.Append("spare_cash,");
            if (Columns.dispensing_behavior == (Columns.dispensing_behavior & columns))
                qry.Append("dispensing_behavior,");
            if (Columns.avg_dispensed_salary_days == (Columns.avg_dispensed_salary_days & columns))
                qry.Append("avg_dispensed_salary_days,");
            if (Columns.inactivity_period_salary_days == (Columns.inactivity_period_salary_days & columns))
                qry.Append("inactivity_period_salary_days,");
            if (Columns.inactivity_period_normal_days == (Columns.inactivity_period_normal_days & columns))
                qry.Append("inactivity_period_normal_days,");
            if (Columns.type1_min_notes_threshold_value == (Columns.type1_min_notes_threshold_value & columns))
                qry.Append("type1_min_notes_threshold_value,");
            if (Columns.type2_min_notes_threshold_value == (Columns.type2_min_notes_threshold_value & columns))
                qry.Append("type2_min_notes_threshold_value,");
            if (Columns.type3_min_notes_threshold_value == (Columns.type3_min_notes_threshold_value & columns))
                qry.Append("type3_min_notes_threshold_value,");
            if (Columns.type4_min_notes_threshold_value == (Columns.type4_min_notes_threshold_value & columns))
                qry.Append("type4_min_notes_threshold_value,");
            if (Columns.bna_allowed_inactivity_period_normal_days == (Columns.bna_allowed_inactivity_period_normal_days & columns))
                qry.Append("bna_allowed_inactivity_period_normal_days,");
            if (Columns.bna_allowed_inactivity_period_salary_days == (Columns.bna_allowed_inactivity_period_salary_days & columns))
                qry.Append("bna_allowed_inactivity_period_salary_days,");
            if (Columns.cheque_allowed_inactivity_period_normal_days == (Columns.cheque_allowed_inactivity_period_normal_days & columns))
                qry.Append("cheque_allowed_inactivity_period_normal_days,");
            if (Columns.cheque_allowed_inactivity_period_salary_days == (Columns.cheque_allowed_inactivity_period_salary_days & columns))
                qry.Append("cheque_allowed_inactivity_period_salary_days,");
            if (Columns.min_operating_balance_normal_days == (Columns.min_operating_balance_normal_days & columns))
                qry.Append("min_operating_balance_normal_days,");
            if (Columns.min_operating_balance_salary_days == (Columns.min_operating_balance_salary_days & columns))
                qry.Append("min_operating_balance_salary_days,");
            if (Columns.is_order_auto_generated == (Columns.is_order_auto_generated & columns))
                qry.Append("is_order_auto_generated,");
            if (Columns.is_win7_machine == (Columns.is_win7_machine & columns))
                qry.Append("is_win7_machine,");
            if (Columns.is_branch_atm == (Columns.is_branch_atm & columns))
                qry.Append("is_branch_atm,");
            if (Columns.is_emirate_islamic == (Columns.is_emirate_islamic & columns))
                qry.Append("is_emirate_islamic,");
            if (Columns.is_itm == (Columns.is_itm & columns))
                qry.Append("is_itm,");
            if (Columns.is_bulk_cash_deposit == (Columns.is_bulk_cash_deposit & columns))
                qry.Append("is_bulk_cash_deposit,");
            if (Columns.is_combo == (Columns.is_combo & columns))
                qry.Append("is_combo,");
            if (Columns.atm_cost == (Columns.atm_cost & columns))
                qry.Append("atm_cost,");
            if (Columns.software_cost == (Columns.software_cost & columns))
                qry.Append("software_cost,");
            if (Columns.network_cost == (Columns.network_cost & columns))
                qry.Append("network_cost,");
            if (Columns.site_preparation_cost == (Columns.site_preparation_cost & columns))
                qry.Append("site_preparation_cost,");
            if (Columns.security_infrastructure_cost == (Columns.security_infrastructure_cost & columns))
                qry.Append("security_infrastructure_cost,");
            if (Columns.im_branch_code == (Columns.im_branch_code & columns))
                qry.Append("im_branch_code,");
            if (Columns.im_en_id == (Columns.im_en_id & columns))
                qry.Append("im_en_id,");
            if (Columns.im_location == (Columns.im_location & columns))
                qry.Append("im_location,");
            if (Columns.im_business_area == (Columns.im_business_area & columns))
                qry.Append("im_business_area,");
            if (Columns.im_circle == (Columns.im_circle & columns))
                qry.Append("im_circle,");
            if (Columns.cit_id == (Columns.cit_id & columns))
                qry.Append("cit_id,");
            if (Columns.atm_bandwidth_id == (Columns.atm_bandwidth_id & columns))
                qry.Append("atm_bandwidth_id,");
            if (Columns.atm_model_id == (Columns.atm_model_id & columns))
                qry.Append("atm_model_id,");
            if (Columns.is_recycler == (Columns.is_recycler & columns))
                qry.Append("is_recycler,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Atm ");

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
            return new AtmReader(cmd.ExecuteReader(), conn, columns);
        }

        static public AtmReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static AtmReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select ATM_id,last_status_reply,region_id,title,IP,port,modified_by,created_by,is_active,creation_time,atm_type,cassette1_capacity,cassette1_denomination,cassette2_capacity,cassette2_denomination,cassette3_denomination,cassette3_capacity,cassette4_denomination,cassette4_capacity,cassette5_denomination,cassette5_capacity,cassette6_denomination,cassette6_capacity,cassette7_denomination,cassette7_capacity,last_wincor_sent,is_healthy,location,address1,address2,city,country,zip_code,location_type,service_status,holiday_status,business_days,time_zone,max_notes_per_cassette,cassette1_split_percentage,cassette2_split_percentage,cassette3_split_percentage,cassette4_split_percentage,cassette5_split_percentage,cassette6_split_percentage,cassette7_split_percentage,interest_rate,insurance_rate,max_holding_amount,min_operating_balance,min_amount_for_normal_delivery,bank_cash_center_id,CIT_cash_center_servicer,depot_id,secondary_depot_vault_id,new_atm_scenario,cash_swap_days,mandatory_cash_swap_days,cash_swap_cycle,cash_swap_lead_time,cash_swap_start_date,cash_swap_handling_cost,cash_swap_costs,emergency_days,emergency_lead_time,emergency_cost,contact1_email,contact2_email,contact3_email,contact1_phone,contact2_phone,contact3_phone,effective_date,suspend_cash_order,is_atm,is_cdm,is_ccdm,cdm_cassette1_capacity,cdm_cassette2_capacity,cdm_cassette3_capacity,cdm_cassette4_capacity,ccdm_cassette1_capacity,ccdm_cassette2_capacity,ccdm_cassette3_capacity,ccdm_cassette4_capacity,cdm_cassette1_threshold,cdm_cassette2_threshold,cdm_cassette3_threshold,cdm_cassette4_threshold,ccdm_cassette1_threshold,ccdm_cassette2_threshold,ccdm_cassette3_threshold,ccdm_cassette4_threshold,note_set_type_id,ccdm_cassette5_capacity,ccdm_cassette5_threshold,startup_sleep_interval,debug_level,exclude_dff,purge1_threshold,is_purge1_threshold_selected,purge2_threshold,is_purge2_threshold_selected,purge3_threshold,is_purge3_threshold_selected,purge4_threshold,is_purge4_threshold_selected,purge5_threshold,is_purge5_threshold_selected,purge6_threshold,is_purge6_threshold_selected,purge7_threshold,is_purge7_threshold_selected,retry_count_cash_order_upload,retry_count_conf_upload,retry_count_counter_file,retry_count_restart_schedule,retry_count_datetime_schedule,retry_count_alert,CountsClearRetries,TCPTimeout,SleepInterval,CPMCommandWait,CPMCommandSleep,AANDCApplications1,AANDCApplications2,AANDCApplications3,AANDCApplications4,AANDCApplications5,Monitoring_Retries,WindowSwitch_Sleep,AppSwitch_Sleep,MonitoringCycle_Sleep,CPMLogLevel,IsDispenserRealTimeNotificationEnabled,IsBNARealTimeNotificationEnabled,IsCPMRealTimeNotificationEnabled,IsReplenishmentRealTimeNotificationEnabled,IsOutOfCashRealTimeNotificationEnabled,IsDispenserMismatchRealTimeNotificationEnabled,IsBNAMismatchRealTimeNotificationEnabled,IsCPMMismatchRealTimeNotificationEnabled,IsCounterExplodedRealTimeNotificationEnabled,Type1MinimumNotes,Type2MinimumNotes,Type3MinimumNotes,Type4MinimumNotes,Type5MinimumNotes,Type6MinimumNotes,Type7MinimumNotes,cpm_command,allowed_inactivity_period,gl_number,card_captured_cost,escotting_cost,replenishment_cost,maintenance_cost,flm_call_out_cost,description,is_dff_generation_halt,cit_atm_title,cheque_allowed_inactivity_period,bna_allowed_inactivity_period,out_of_cash_threshold,no_of_dispensed_transactions_to_monitor,is_ej_enabled,is_counter_enabled,priority,longitude,latitude,on_us_amount,not_on_us_amount,standard_order_type1,standard_order_type2,standard_order_type3,standard_order_type4,standard_order_type5,standard_order_type6,standard_order_type7,protocol_type_id,current_mode,aggregate_state,last_boot_time,discovery_time,last_scan_time,communication_status,is_critical,current_mode_modified_on,Last_Notification_Received_On,Last_Notification_Time,normal_order_cost,emergency_order_cost,receipt_transaction_cutoff,is_swap_default_replenishment,message_processor_id,last_ping_status,last_ping_executed_at,last_telnet_status,last_telnet_executed_at,last_archive_file_received_at,is_sdm,initEjExecTime,ccmsagent_last_reported_heartbeat,ccmsservicemanager_last_reported_heartbeat,distribution_port,parser_rep_date_format,type1_min_notes_threshold,type2_min_notes_threshold,type3_min_notes_threshold,type4_min_notes_threshold,type1_suggested_notes_normal_days,type2_suggested_notes_normal_days,type3_suggested_notes_normal_days,type4_suggested_notes_normal_days,type5_suggested_notes_normal_days,type6_suggested_notes_normal_days,type7_suggested_notes_normal_days,type1_suggested_notes_salary_days,type2_suggested_notes_salary_days,type3_suggested_notes_salary_days,type4_suggested_notes_salary_days,type5_suggested_notes_salary_days,type6_suggested_notes_salary_days,type7_suggested_notes_salary_days,avg_dispensed,spare_cash,dispensing_behavior,avg_dispensed_salary_days,inactivity_period_salary_days,inactivity_period_normal_days,type1_min_notes_threshold_value,type2_min_notes_threshold_value,type3_min_notes_threshold_value,type4_min_notes_threshold_value,bna_allowed_inactivity_period_normal_days,bna_allowed_inactivity_period_salary_days,cheque_allowed_inactivity_period_normal_days,cheque_allowed_inactivity_period_salary_days,min_operating_balance_normal_days,min_operating_balance_salary_days,is_order_auto_generated,is_win7_machine,is_branch_atm,is_emirate_islamic,is_itm,is_bulk_cash_deposit,is_combo,atm_cost,software_cost,network_cost,site_preparation_cost,security_infrastructure_cost,im_branch_code,im_en_id,im_location,im_business_area,im_circle,cit_id,atm_bandwidth_id,atm_model_id,is_recycler from Atm ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmReader(cmd.ExecuteReader(), conn);
        }

        static public AtmReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static Atm LoadAtm(string where)
        {
            AtmReader reader = Atm.ExecuteReader(where);
            Atm _atm = null;
            if (reader.Read())
                _atm = reader.CurrentAtm;
            reader.Close();
            return _atm;
        }

        public static Atm LoadAtm(string where, IDbConnection conn)
        {
            AtmReader reader = Atm.ExecuteReader(where, conn);
            Atm _atm = null;
            if (reader.Read())
                _atm = reader.CurrentAtm;
            reader.Close(false);
            return _atm;
        }

        public static Atm LoadAtmByPk(int aTM_id)
        {
            return LoadAtm("ATM_id=" + aTM_id);
        }

        public static Atm LoadAtmByPk(int aTM_id, IDbConnection conn)
        {
            return LoadAtm(" ATM_id=" + aTM_id, conn);
        }

        public void Save()
        {
            if (aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || last_wincor_sentChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || zip_codeChanged || location_typeChanged || service_statusChanged || holiday_statusChanged || business_daysChanged || time_zoneChanged || max_notes_per_cassetteChanged || cassette1_split_percentageChanged || cassette2_split_percentageChanged || cassette3_split_percentageChanged || cassette4_split_percentageChanged || cassette5_split_percentageChanged || cassette6_split_percentageChanged || cassette7_split_percentageChanged || interest_rateChanged || insurance_rateChanged || max_holding_amountChanged || min_operating_balanceChanged || min_amount_for_normal_deliveryChanged || bank_cash_center_idChanged || cIT_cash_center_servicerChanged || depot_idChanged || secondary_depot_vault_idChanged || new_atm_scenarioChanged || cash_swap_daysChanged || mandatory_cash_swap_daysChanged || cash_swap_cycleChanged || cash_swap_lead_timeChanged || cash_swap_start_dateChanged || cash_swap_handling_costChanged || cash_swap_costsChanged || emergency_daysChanged || emergency_lead_timeChanged || emergency_costChanged || contact1_emailChanged || contact2_emailChanged || contact3_emailChanged || contact1_phoneChanged || contact2_phoneChanged || contact3_phoneChanged || effective_dateChanged || suspend_cash_orderChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || exclude_dffChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_cash_order_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || retry_count_alertChanged || countsClearRetriesChanged || tCPTimeoutChanged || sleepIntervalChanged || cPMCommandWaitChanged || cPMCommandSleepChanged || aANDCApplications1Changed || aANDCApplications2Changed || aANDCApplications3Changed || aANDCApplications4Changed || aANDCApplications5Changed || monitoring_RetriesChanged || windowSwitch_SleepChanged || appSwitch_SleepChanged || monitoringCycle_SleepChanged || cPMLogLevelChanged || isDispenserRealTimeNotificationEnabledChanged || isBNARealTimeNotificationEnabledChanged || isCPMRealTimeNotificationEnabledChanged || isReplenishmentRealTimeNotificationEnabledChanged || isOutOfCashRealTimeNotificationEnabledChanged || isDispenserMismatchRealTimeNotificationEnabledChanged || isBNAMismatchRealTimeNotificationEnabledChanged || isCPMMismatchRealTimeNotificationEnabledChanged || isCounterExplodedRealTimeNotificationEnabledChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || cpm_commandChanged || allowed_inactivity_periodChanged || gl_numberChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || descriptionChanged || is_dff_generation_haltChanged || cit_atm_titleChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || no_of_dispensed_transactions_to_monitorChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || longitudeChanged || latitudeChanged || on_us_amountChanged || not_on_us_amountChanged || standard_order_type1Changed || standard_order_type2Changed || standard_order_type3Changed || standard_order_type4Changed || standard_order_type5Changed || standard_order_type6Changed || standard_order_type7Changed || protocol_type_idChanged || current_modeChanged || aggregate_stateChanged || last_boot_timeChanged || discovery_timeChanged || last_scan_timeChanged || communication_statusChanged || is_criticalChanged || current_mode_modified_onChanged || last_Notification_Received_OnChanged || last_Notification_TimeChanged || normal_order_costChanged || emergency_order_costChanged || receipt_transaction_cutoffChanged || is_swap_default_replenishmentChanged || message_processor_idChanged || last_ping_statusChanged || last_ping_executed_atChanged || last_telnet_statusChanged || last_telnet_executed_atChanged || last_archive_file_received_atChanged || is_sdmChanged || initEjExecTimeChanged || ccmsagent_last_reported_heartbeatChanged || ccmsservicemanager_last_reported_heartbeatChanged || distribution_portChanged || parser_rep_date_formatChanged || type1_min_notes_thresholdChanged || type2_min_notes_thresholdChanged || type3_min_notes_thresholdChanged || type4_min_notes_thresholdChanged || type1_suggested_notes_normal_daysChanged || type2_suggested_notes_normal_daysChanged || type3_suggested_notes_normal_daysChanged || type4_suggested_notes_normal_daysChanged || type5_suggested_notes_normal_daysChanged || type6_suggested_notes_normal_daysChanged || type7_suggested_notes_normal_daysChanged || type1_suggested_notes_salary_daysChanged || type2_suggested_notes_salary_daysChanged || type3_suggested_notes_salary_daysChanged || type4_suggested_notes_salary_daysChanged || type5_suggested_notes_salary_daysChanged || type6_suggested_notes_salary_daysChanged || type7_suggested_notes_salary_daysChanged || avg_dispensedChanged || spare_cashChanged || dispensing_behaviorChanged || avg_dispensed_salary_daysChanged || inactivity_period_salary_daysChanged || inactivity_period_normal_daysChanged || type1_min_notes_threshold_valueChanged || type2_min_notes_threshold_valueChanged || type3_min_notes_threshold_valueChanged || type4_min_notes_threshold_valueChanged || bna_allowed_inactivity_period_normal_daysChanged || bna_allowed_inactivity_period_salary_daysChanged || cheque_allowed_inactivity_period_normal_daysChanged || cheque_allowed_inactivity_period_salary_daysChanged || min_operating_balance_normal_daysChanged || min_operating_balance_salary_daysChanged || is_order_auto_generatedChanged || is_win7_machineChanged || is_branch_atmChanged || is_emirate_islamicChanged || is_itmChanged || is_bulk_cash_depositChanged || is_comboChanged || atm_costChanged || software_costChanged || network_costChanged || site_preparation_costChanged || security_infrastructure_costChanged || im_branch_codeChanged || im_en_idChanged || im_locationChanged || im_business_areaChanged || im_circleChanged || cit_idChanged || atm_bandwidth_idChanged || atm_model_idChanged || is_recyclerChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());
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
            if (aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || last_wincor_sentChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || zip_codeChanged || location_typeChanged || service_statusChanged || holiday_statusChanged || business_daysChanged || time_zoneChanged || max_notes_per_cassetteChanged || cassette1_split_percentageChanged || cassette2_split_percentageChanged || cassette3_split_percentageChanged || cassette4_split_percentageChanged || cassette5_split_percentageChanged || cassette6_split_percentageChanged || cassette7_split_percentageChanged || interest_rateChanged || insurance_rateChanged || max_holding_amountChanged || min_operating_balanceChanged || min_amount_for_normal_deliveryChanged || bank_cash_center_idChanged || cIT_cash_center_servicerChanged || depot_idChanged || secondary_depot_vault_idChanged || new_atm_scenarioChanged || cash_swap_daysChanged || mandatory_cash_swap_daysChanged || cash_swap_cycleChanged || cash_swap_lead_timeChanged || cash_swap_start_dateChanged || cash_swap_handling_costChanged || cash_swap_costsChanged || emergency_daysChanged || emergency_lead_timeChanged || emergency_costChanged || contact1_emailChanged || contact2_emailChanged || contact3_emailChanged || contact1_phoneChanged || contact2_phoneChanged || contact3_phoneChanged || effective_dateChanged || suspend_cash_orderChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || exclude_dffChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_cash_order_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || retry_count_alertChanged || countsClearRetriesChanged || tCPTimeoutChanged || sleepIntervalChanged || cPMCommandWaitChanged || cPMCommandSleepChanged || aANDCApplications1Changed || aANDCApplications2Changed || aANDCApplications3Changed || aANDCApplications4Changed || aANDCApplications5Changed || monitoring_RetriesChanged || windowSwitch_SleepChanged || appSwitch_SleepChanged || monitoringCycle_SleepChanged || cPMLogLevelChanged || isDispenserRealTimeNotificationEnabledChanged || isBNARealTimeNotificationEnabledChanged || isCPMRealTimeNotificationEnabledChanged || isReplenishmentRealTimeNotificationEnabledChanged || isOutOfCashRealTimeNotificationEnabledChanged || isDispenserMismatchRealTimeNotificationEnabledChanged || isBNAMismatchRealTimeNotificationEnabledChanged || isCPMMismatchRealTimeNotificationEnabledChanged || isCounterExplodedRealTimeNotificationEnabledChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || cpm_commandChanged || allowed_inactivity_periodChanged || gl_numberChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || descriptionChanged || is_dff_generation_haltChanged || cit_atm_titleChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || no_of_dispensed_transactions_to_monitorChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || longitudeChanged || latitudeChanged || on_us_amountChanged || not_on_us_amountChanged || standard_order_type1Changed || standard_order_type2Changed || standard_order_type3Changed || standard_order_type4Changed || standard_order_type5Changed || standard_order_type6Changed || standard_order_type7Changed || protocol_type_idChanged || current_modeChanged || aggregate_stateChanged || last_boot_timeChanged || discovery_timeChanged || last_scan_timeChanged || communication_statusChanged || is_criticalChanged || current_mode_modified_onChanged || last_Notification_Received_OnChanged || last_Notification_TimeChanged || normal_order_costChanged || emergency_order_costChanged || receipt_transaction_cutoffChanged || is_swap_default_replenishmentChanged || message_processor_idChanged || last_ping_statusChanged || last_ping_executed_atChanged || last_telnet_statusChanged || last_telnet_executed_atChanged || last_archive_file_received_atChanged || is_sdmChanged || initEjExecTimeChanged || ccmsagent_last_reported_heartbeatChanged || ccmsservicemanager_last_reported_heartbeatChanged || distribution_portChanged || parser_rep_date_formatChanged || type1_min_notes_thresholdChanged || type2_min_notes_thresholdChanged || type3_min_notes_thresholdChanged || type4_min_notes_thresholdChanged || type1_suggested_notes_normal_daysChanged || type2_suggested_notes_normal_daysChanged || type3_suggested_notes_normal_daysChanged || type4_suggested_notes_normal_daysChanged || type5_suggested_notes_normal_daysChanged || type6_suggested_notes_normal_daysChanged || type7_suggested_notes_normal_daysChanged || type1_suggested_notes_salary_daysChanged || type2_suggested_notes_salary_daysChanged || type3_suggested_notes_salary_daysChanged || type4_suggested_notes_salary_daysChanged || type5_suggested_notes_salary_daysChanged || type6_suggested_notes_salary_daysChanged || type7_suggested_notes_salary_daysChanged || avg_dispensedChanged || spare_cashChanged || dispensing_behaviorChanged || avg_dispensed_salary_daysChanged || inactivity_period_salary_daysChanged || inactivity_period_normal_daysChanged || type1_min_notes_threshold_valueChanged || type2_min_notes_threshold_valueChanged || type3_min_notes_threshold_valueChanged || type4_min_notes_threshold_valueChanged || bna_allowed_inactivity_period_normal_daysChanged || bna_allowed_inactivity_period_salary_daysChanged || cheque_allowed_inactivity_period_normal_daysChanged || cheque_allowed_inactivity_period_salary_daysChanged || min_operating_balance_normal_daysChanged || min_operating_balance_salary_daysChanged || is_order_auto_generatedChanged || is_win7_machineChanged || is_branch_atmChanged || is_emirate_islamicChanged || is_itmChanged || is_bulk_cash_depositChanged || is_comboChanged || atm_costChanged || software_costChanged || network_costChanged || site_preparation_costChanged || security_infrastructure_costChanged || im_branch_codeChanged || im_en_idChanged || im_locationChanged || im_business_areaChanged || im_circleChanged || cit_idChanged || atm_bandwidth_idChanged || atm_model_idChanged || is_recyclerChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm(ATM_id,last_status_reply,region_id,title,IP,port,modified_by,created_by,is_active,creation_time,atm_type,cassette1_capacity,cassette1_denomination,cassette2_capacity,cassette2_denomination,cassette3_denomination,cassette3_capacity,cassette4_denomination,cassette4_capacity,cassette5_denomination,cassette5_capacity,cassette6_denomination,cassette6_capacity,cassette7_denomination,cassette7_capacity,last_wincor_sent,is_healthy,location,address1,address2,city,country,zip_code,location_type,service_status,holiday_status,business_days,time_zone,max_notes_per_cassette,cassette1_split_percentage,cassette2_split_percentage,cassette3_split_percentage,cassette4_split_percentage,cassette5_split_percentage,cassette6_split_percentage,cassette7_split_percentage,interest_rate,insurance_rate,max_holding_amount,min_operating_balance,min_amount_for_normal_delivery,bank_cash_center_id,CIT_cash_center_servicer,depot_id,secondary_depot_vault_id,new_atm_scenario,cash_swap_days,mandatory_cash_swap_days,cash_swap_cycle,cash_swap_lead_time,cash_swap_start_date,cash_swap_handling_cost,cash_swap_costs,emergency_days,emergency_lead_time,emergency_cost,contact1_email,contact2_email,contact3_email,contact1_phone,contact2_phone,contact3_phone,effective_date,suspend_cash_order,is_atm,is_cdm,is_ccdm,cdm_cassette1_capacity,cdm_cassette2_capacity,cdm_cassette3_capacity,cdm_cassette4_capacity,ccdm_cassette1_capacity,ccdm_cassette2_capacity,ccdm_cassette3_capacity,ccdm_cassette4_capacity,cdm_cassette1_threshold,cdm_cassette2_threshold,cdm_cassette3_threshold,cdm_cassette4_threshold,ccdm_cassette1_threshold,ccdm_cassette2_threshold,ccdm_cassette3_threshold,ccdm_cassette4_threshold,note_set_type_id,ccdm_cassette5_capacity,ccdm_cassette5_threshold,startup_sleep_interval,debug_level,exclude_dff,purge1_threshold,is_purge1_threshold_selected,purge2_threshold,is_purge2_threshold_selected,purge3_threshold,is_purge3_threshold_selected,purge4_threshold,is_purge4_threshold_selected,purge5_threshold,is_purge5_threshold_selected,purge6_threshold,is_purge6_threshold_selected,purge7_threshold,is_purge7_threshold_selected,retry_count_cash_order_upload,retry_count_conf_upload,retry_count_counter_file,retry_count_restart_schedule,retry_count_datetime_schedule,retry_count_alert,CountsClearRetries,TCPTimeout,SleepInterval,CPMCommandWait,CPMCommandSleep,AANDCApplications1,AANDCApplications2,AANDCApplications3,AANDCApplications4,AANDCApplications5,Monitoring_Retries,WindowSwitch_Sleep,AppSwitch_Sleep,MonitoringCycle_Sleep,CPMLogLevel,IsDispenserRealTimeNotificationEnabled,IsBNARealTimeNotificationEnabled,IsCPMRealTimeNotificationEnabled,IsReplenishmentRealTimeNotificationEnabled,IsOutOfCashRealTimeNotificationEnabled,IsDispenserMismatchRealTimeNotificationEnabled,IsBNAMismatchRealTimeNotificationEnabled,IsCPMMismatchRealTimeNotificationEnabled,IsCounterExplodedRealTimeNotificationEnabled,Type1MinimumNotes,Type2MinimumNotes,Type3MinimumNotes,Type4MinimumNotes,Type5MinimumNotes,Type6MinimumNotes,Type7MinimumNotes,cpm_command,allowed_inactivity_period,gl_number,card_captured_cost,escotting_cost,replenishment_cost,maintenance_cost,flm_call_out_cost,description,is_dff_generation_halt,cit_atm_title,cheque_allowed_inactivity_period,bna_allowed_inactivity_period,out_of_cash_threshold,no_of_dispensed_transactions_to_monitor,is_ej_enabled,is_counter_enabled,priority,longitude,latitude,on_us_amount,not_on_us_amount,standard_order_type1,standard_order_type2,standard_order_type3,standard_order_type4,standard_order_type5,standard_order_type6,standard_order_type7,protocol_type_id,current_mode,aggregate_state,last_boot_time,discovery_time,last_scan_time,communication_status,is_critical,current_mode_modified_on,Last_Notification_Received_On,Last_Notification_Time,normal_order_cost,emergency_order_cost,receipt_transaction_cutoff,is_swap_default_replenishment,message_processor_id,last_ping_status,last_ping_executed_at,last_telnet_status,last_telnet_executed_at,last_archive_file_received_at,is_sdm,initEjExecTime,ccmsagent_last_reported_heartbeat,ccmsservicemanager_last_reported_heartbeat,distribution_port,parser_rep_date_format,type1_min_notes_threshold,type2_min_notes_threshold,type3_min_notes_threshold,type4_min_notes_threshold,type1_suggested_notes_normal_days,type2_suggested_notes_normal_days,type3_suggested_notes_normal_days,type4_suggested_notes_normal_days,type5_suggested_notes_normal_days,type6_suggested_notes_normal_days,type7_suggested_notes_normal_days,type1_suggested_notes_salary_days,type2_suggested_notes_salary_days,type3_suggested_notes_salary_days,type4_suggested_notes_salary_days,type5_suggested_notes_salary_days,type6_suggested_notes_salary_days,type7_suggested_notes_salary_days,avg_dispensed,spare_cash,dispensing_behavior,avg_dispensed_salary_days,inactivity_period_salary_days,inactivity_period_normal_days,type1_min_notes_threshold_value,type2_min_notes_threshold_value,type3_min_notes_threshold_value,type4_min_notes_threshold_value,bna_allowed_inactivity_period_normal_days,bna_allowed_inactivity_period_salary_days,cheque_allowed_inactivity_period_normal_days,cheque_allowed_inactivity_period_salary_days,min_operating_balance_normal_days,min_operating_balance_salary_days,is_order_auto_generated,is_win7_machine,is_branch_atm,is_emirate_islamic,is_itm,is_bulk_cash_deposit,is_combo,atm_cost,software_cost,network_cost,site_preparation_cost,security_infrastructure_cost,im_branch_code,im_en_id,im_location,im_business_area,im_circle,cit_id,atm_bandwidth_id,atm_model_id,is_recycler) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.aTM_id = ConnectionFactory.GetNextId();
                        qry.Append(this.aTM_id);
                    } qry.Append(",");
                    qry.Append(last_status_replyDbString + ",");
                    qry.Append(region_idDbString + ",");
                    qry.Append(titleDbString + ",");
                    qry.Append(iPDbString + ",");
                    qry.Append(portDbString + ",");
                    qry.Append(modified_byDbString + ",");
                    qry.Append(created_byDbString + ",");
                    qry.Append(is_activeDbString + ",");
                    qry.Append(creation_timeDbString + ",");
                    qry.Append(atm_typeDbString + ",");
                    qry.Append(cassette1_capacityDbString + ",");
                    qry.Append(cassette1_denominationDbString + ",");
                    qry.Append(cassette2_capacityDbString + ",");
                    qry.Append(cassette2_denominationDbString + ",");
                    qry.Append(cassette3_denominationDbString + ",");
                    qry.Append(cassette3_capacityDbString + ",");
                    qry.Append(cassette4_denominationDbString + ",");
                    qry.Append(cassette4_capacityDbString + ",");
                    qry.Append(cassette5_denominationDbString + ",");
                    qry.Append(cassette5_capacityDbString + ",");
                    qry.Append(cassette6_denominationDbString + ",");
                    qry.Append(cassette6_capacityDbString + ",");
                    qry.Append(cassette7_denominationDbString + ",");
                    qry.Append(cassette7_capacityDbString + ",");
                    qry.Append(last_wincor_sentDbString + ",");
                    qry.Append(is_healthyDbString + ",");
                    qry.Append(locationDbString + ",");
                    qry.Append(address1DbString + ",");
                    qry.Append(address2DbString + ",");
                    qry.Append(cityDbString + ",");
                    qry.Append(countryDbString + ",");
                    qry.Append(zip_codeDbString + ",");
                    qry.Append(location_typeDbString + ",");
                    qry.Append(service_statusDbString + ",");
                    qry.Append(holiday_statusDbString + ",");
                    qry.Append(business_daysDbString + ",");
                    qry.Append(time_zoneDbString + ",");
                    qry.Append(max_notes_per_cassetteDbString + ",");
                    qry.Append(cassette1_split_percentageDbString + ",");
                    qry.Append(cassette2_split_percentageDbString + ",");
                    qry.Append(cassette3_split_percentageDbString + ",");
                    qry.Append(cassette4_split_percentageDbString + ",");
                    qry.Append(cassette5_split_percentageDbString + ",");
                    qry.Append(cassette6_split_percentageDbString + ",");
                    qry.Append(cassette7_split_percentageDbString + ",");
                    qry.Append(interest_rateDbString + ",");
                    qry.Append(insurance_rateDbString + ",");
                    qry.Append(max_holding_amountDbString + ",");
                    qry.Append(min_operating_balanceDbString + ",");
                    qry.Append(min_amount_for_normal_deliveryDbString + ",");
                    qry.Append(bank_cash_center_idDbString + ",");
                    qry.Append(cIT_cash_center_servicerDbString + ",");
                    qry.Append(depot_idDbString + ",");
                    qry.Append(secondary_depot_vault_idDbString + ",");
                    qry.Append(new_atm_scenarioDbString + ",");
                    qry.Append(cash_swap_daysDbString + ",");
                    qry.Append(mandatory_cash_swap_daysDbString + ",");
                    qry.Append(cash_swap_cycleDbString + ",");
                    qry.Append(cash_swap_lead_timeDbString + ",");
                    qry.Append(cash_swap_start_dateDbString + ",");
                    qry.Append(cash_swap_handling_costDbString + ",");
                    qry.Append(cash_swap_costsDbString + ",");
                    qry.Append(emergency_daysDbString + ",");
                    qry.Append(emergency_lead_timeDbString + ",");
                    qry.Append(emergency_costDbString + ",");
                    qry.Append(contact1_emailDbString + ",");
                    qry.Append(contact2_emailDbString + ",");
                    qry.Append(contact3_emailDbString + ",");
                    qry.Append(contact1_phoneDbString + ",");
                    qry.Append(contact2_phoneDbString + ",");
                    qry.Append(contact3_phoneDbString + ",");
                    qry.Append(effective_dateDbString + ",");
                    qry.Append(suspend_cash_orderDbString + ",");
                    qry.Append(is_atmDbString + ",");
                    qry.Append(is_cdmDbString + ",");
                    qry.Append(is_ccdmDbString + ",");
                    qry.Append(cdm_cassette1_capacityDbString + ",");
                    qry.Append(cdm_cassette2_capacityDbString + ",");
                    qry.Append(cdm_cassette3_capacityDbString + ",");
                    qry.Append(cdm_cassette4_capacityDbString + ",");
                    qry.Append(ccdm_cassette1_capacityDbString + ",");
                    qry.Append(ccdm_cassette2_capacityDbString + ",");
                    qry.Append(ccdm_cassette3_capacityDbString + ",");
                    qry.Append(ccdm_cassette4_capacityDbString + ",");
                    qry.Append(cdm_cassette1_thresholdDbString + ",");
                    qry.Append(cdm_cassette2_thresholdDbString + ",");
                    qry.Append(cdm_cassette3_thresholdDbString + ",");
                    qry.Append(cdm_cassette4_thresholdDbString + ",");
                    qry.Append(ccdm_cassette1_thresholdDbString + ",");
                    qry.Append(ccdm_cassette2_thresholdDbString + ",");
                    qry.Append(ccdm_cassette3_thresholdDbString + ",");
                    qry.Append(ccdm_cassette4_thresholdDbString + ",");
                    qry.Append(note_set_type_idDbString + ",");
                    qry.Append(ccdm_cassette5_capacityDbString + ",");
                    qry.Append(ccdm_cassette5_thresholdDbString + ",");
                    qry.Append(startup_sleep_intervalDbString + ",");
                    qry.Append(debug_levelDbString + ",");
                    qry.Append(exclude_dffDbString + ",");
                    qry.Append(purge1_thresholdDbString + ",");
                    qry.Append(is_purge1_threshold_selectedDbString + ",");
                    qry.Append(purge2_thresholdDbString + ",");
                    qry.Append(is_purge2_threshold_selectedDbString + ",");
                    qry.Append(purge3_thresholdDbString + ",");
                    qry.Append(is_purge3_threshold_selectedDbString + ",");
                    qry.Append(purge4_thresholdDbString + ",");
                    qry.Append(is_purge4_threshold_selectedDbString + ",");
                    qry.Append(purge5_thresholdDbString + ",");
                    qry.Append(is_purge5_threshold_selectedDbString + ",");
                    qry.Append(purge6_thresholdDbString + ",");
                    qry.Append(is_purge6_threshold_selectedDbString + ",");
                    qry.Append(purge7_thresholdDbString + ",");
                    qry.Append(is_purge7_threshold_selectedDbString + ",");
                    qry.Append(retry_count_cash_order_uploadDbString + ",");
                    qry.Append(retry_count_conf_uploadDbString + ",");
                    qry.Append(retry_count_counter_fileDbString + ",");
                    qry.Append(retry_count_restart_scheduleDbString + ",");
                    qry.Append(retry_count_datetime_scheduleDbString + ",");
                    qry.Append(retry_count_alertDbString + ",");
                    qry.Append(countsClearRetriesDbString + ",");
                    qry.Append(tCPTimeoutDbString + ",");
                    qry.Append(sleepIntervalDbString + ",");
                    qry.Append(cPMCommandWaitDbString + ",");
                    qry.Append(cPMCommandSleepDbString + ",");
                    qry.Append(aANDCApplications1DbString + ",");
                    qry.Append(aANDCApplications2DbString + ",");
                    qry.Append(aANDCApplications3DbString + ",");
                    qry.Append(aANDCApplications4DbString + ",");
                    qry.Append(aANDCApplications5DbString + ",");
                    qry.Append(monitoring_RetriesDbString + ",");
                    qry.Append(windowSwitch_SleepDbString + ",");
                    qry.Append(appSwitch_SleepDbString + ",");
                    qry.Append(monitoringCycle_SleepDbString + ",");
                    qry.Append(cPMLogLevelDbString + ",");
                    qry.Append(isDispenserRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isBNARealTimeNotificationEnabledDbString + ",");
                    qry.Append(isCPMRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isReplenishmentRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isOutOfCashRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isDispenserMismatchRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isBNAMismatchRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isCPMMismatchRealTimeNotificationEnabledDbString + ",");
                    qry.Append(isCounterExplodedRealTimeNotificationEnabledDbString + ",");
                    qry.Append(type1MinimumNotesDbString + ",");
                    qry.Append(type2MinimumNotesDbString + ",");
                    qry.Append(type3MinimumNotesDbString + ",");
                    qry.Append(type4MinimumNotesDbString + ",");
                    qry.Append(type5MinimumNotesDbString + ",");
                    qry.Append(type6MinimumNotesDbString + ",");
                    qry.Append(type7MinimumNotesDbString + ",");
                    qry.Append(cpm_commandDbString + ",");
                    qry.Append(allowed_inactivity_periodDbString + ",");
                    qry.Append(gl_numberDbString + ",");
                    qry.Append(card_captured_costDbString + ",");
                    qry.Append(escotting_costDbString + ",");
                    qry.Append(replenishment_costDbString + ",");
                    qry.Append(maintenance_costDbString + ",");
                    qry.Append(flm_call_out_costDbString + ",");
                    qry.Append(descriptionDbString + ",");
                    qry.Append(is_dff_generation_haltDbString + ",");
                    qry.Append(cit_atm_titleDbString + ",");
                    qry.Append(cheque_allowed_inactivity_periodDbString + ",");
                    qry.Append(bna_allowed_inactivity_periodDbString + ",");
                    qry.Append(out_of_cash_thresholdDbString + ",");
                    qry.Append(no_of_dispensed_transactions_to_monitorDbString + ",");
                    qry.Append(is_ej_enabledDbString + ",");
                    qry.Append(is_counter_enabledDbString + ",");
                    qry.Append(priorityDbString + ",");
                    qry.Append(longitudeDbString + ",");
                    qry.Append(latitudeDbString + ",");
                    qry.Append(on_us_amountDbString + ",");
                    qry.Append(not_on_us_amountDbString + ",");
                    qry.Append(standard_order_type1DbString + ",");
                    qry.Append(standard_order_type2DbString + ",");
                    qry.Append(standard_order_type3DbString + ",");
                    qry.Append(standard_order_type4DbString + ",");
                    qry.Append(standard_order_type5DbString + ",");
                    qry.Append(standard_order_type6DbString + ",");
                    qry.Append(standard_order_type7DbString + ",");
                    qry.Append(protocol_type_idDbString + ",");
                    qry.Append(current_modeDbString + ",");
                    qry.Append(aggregate_stateDbString + ",");
                    qry.Append(last_boot_timeDbString + ",");
                    qry.Append(discovery_timeDbString + ",");
                    qry.Append(last_scan_timeDbString + ",");
                    qry.Append(communication_statusDbString + ",");
                    qry.Append(is_criticalDbString + ",");
                    qry.Append(current_mode_modified_onDbString + ",");
                    qry.Append(last_Notification_Received_OnDbString + ",");
                    qry.Append(last_Notification_TimeDbString + ",");
                    qry.Append(normal_order_costDbString + ",");
                    qry.Append(emergency_order_costDbString + ",");
                    qry.Append(receipt_transaction_cutoffDbString + ",");
                    qry.Append(is_swap_default_replenishmentDbString + ",");
                    qry.Append(message_processor_idDbString + ",");
                    qry.Append(last_ping_statusDbString + ",");
                    qry.Append(last_ping_executed_atDbString + ",");
                    qry.Append(last_telnet_statusDbString + ",");
                    qry.Append(last_telnet_executed_atDbString + ",");
                    qry.Append(last_archive_file_received_atDbString + ",");
                    qry.Append(is_sdmDbString + ",");
                    qry.Append(initEjExecTimeDbString + ",");
                    qry.Append(ccmsagent_last_reported_heartbeatDbString + ",");
                    qry.Append(ccmsservicemanager_last_reported_heartbeatDbString + ",");
                    qry.Append(distribution_portDbString + ",");
                    qry.Append(parser_rep_date_formatDbString + ",");
                    qry.Append(type1_min_notes_thresholdDbString + ",");
                    qry.Append(type2_min_notes_thresholdDbString + ",");
                    qry.Append(type3_min_notes_thresholdDbString + ",");
                    qry.Append(type4_min_notes_thresholdDbString + ",");
                    qry.Append(type1_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type2_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type3_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type4_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type5_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type6_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type7_suggested_notes_normal_daysDbString + ",");
                    qry.Append(type1_suggested_notes_salary_daysDbString + ",");
                    qry.Append(type2_suggested_notes_salary_daysDbString + ",");
                    qry.Append(type3_suggested_notes_salary_daysDbString + ",");
                    qry.Append(type4_suggested_notes_salary_daysDbString + ",");
                    qry.Append(type5_suggested_notes_salary_daysDbString + ",");
                    qry.Append(type6_suggested_notes_salary_daysDbString + ",");
                    qry.Append(type7_suggested_notes_salary_daysDbString + ",");
                    qry.Append(avg_dispensedDbString + ",");
                    qry.Append(spare_cashDbString + ",");
                    qry.Append(dispensing_behaviorDbString + ",");
                    qry.Append(avg_dispensed_salary_daysDbString + ",");
                    qry.Append(inactivity_period_salary_daysDbString + ",");
                    qry.Append(inactivity_period_normal_daysDbString + ",");
                    qry.Append(type1_min_notes_threshold_valueDbString + ",");
                    qry.Append(type2_min_notes_threshold_valueDbString + ",");
                    qry.Append(type3_min_notes_threshold_valueDbString + ",");
                    qry.Append(type4_min_notes_threshold_valueDbString + ",");
                    qry.Append(bna_allowed_inactivity_period_normal_daysDbString + ",");
                    qry.Append(bna_allowed_inactivity_period_salary_daysDbString + ",");
                    qry.Append(cheque_allowed_inactivity_period_normal_daysDbString + ",");
                    qry.Append(cheque_allowed_inactivity_period_salary_daysDbString + ",");
                    qry.Append(min_operating_balance_normal_daysDbString + ",");
                    qry.Append(min_operating_balance_salary_daysDbString + ",");
                    qry.Append(is_order_auto_generatedDbString + ",");
                    qry.Append(is_win7_machineDbString + ",");
                    qry.Append(is_branch_atmDbString + ",");
                    qry.Append(is_emirate_islamicDbString + ",");
                    qry.Append(is_itmDbString + ",");
                    qry.Append(is_bulk_cash_depositDbString + ",");
                    qry.Append(is_comboDbString + ",");
                    qry.Append(atm_costDbString + ",");
                    qry.Append(software_costDbString + ",");
                    qry.Append(network_costDbString + ",");
                    qry.Append(site_preparation_costDbString + ",");
                    qry.Append(security_infrastructure_costDbString + ",");
                    qry.Append(im_branch_codeDbString + ",");
                    qry.Append(im_en_idDbString + ",");
                    qry.Append(im_locationDbString + ",");
                    qry.Append(im_business_areaDbString + ",");
                    qry.Append(im_circleDbString + ",");
                    qry.Append(cit_idDbString + ",");
                    qry.Append(atm_bandwidth_idDbString + ",");
                    qry.Append(atm_model_idDbString + ",");
                    qry.Append(is_recyclerDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || last_wincor_sentChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || zip_codeChanged || location_typeChanged || service_statusChanged || holiday_statusChanged || business_daysChanged || time_zoneChanged || max_notes_per_cassetteChanged || cassette1_split_percentageChanged || cassette2_split_percentageChanged || cassette3_split_percentageChanged || cassette4_split_percentageChanged || cassette5_split_percentageChanged || cassette6_split_percentageChanged || cassette7_split_percentageChanged || interest_rateChanged || insurance_rateChanged || max_holding_amountChanged || min_operating_balanceChanged || min_amount_for_normal_deliveryChanged || bank_cash_center_idChanged || cIT_cash_center_servicerChanged || depot_idChanged || secondary_depot_vault_idChanged || new_atm_scenarioChanged || cash_swap_daysChanged || mandatory_cash_swap_daysChanged || cash_swap_cycleChanged || cash_swap_lead_timeChanged || cash_swap_start_dateChanged || cash_swap_handling_costChanged || cash_swap_costsChanged || emergency_daysChanged || emergency_lead_timeChanged || emergency_costChanged || contact1_emailChanged || contact2_emailChanged || contact3_emailChanged || contact1_phoneChanged || contact2_phoneChanged || contact3_phoneChanged || effective_dateChanged || suspend_cash_orderChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || exclude_dffChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_cash_order_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || retry_count_alertChanged || countsClearRetriesChanged || tCPTimeoutChanged || sleepIntervalChanged || cPMCommandWaitChanged || cPMCommandSleepChanged || aANDCApplications1Changed || aANDCApplications2Changed || aANDCApplications3Changed || aANDCApplications4Changed || aANDCApplications5Changed || monitoring_RetriesChanged || windowSwitch_SleepChanged || appSwitch_SleepChanged || monitoringCycle_SleepChanged || cPMLogLevelChanged || isDispenserRealTimeNotificationEnabledChanged || isBNARealTimeNotificationEnabledChanged || isCPMRealTimeNotificationEnabledChanged || isReplenishmentRealTimeNotificationEnabledChanged || isOutOfCashRealTimeNotificationEnabledChanged || isDispenserMismatchRealTimeNotificationEnabledChanged || isBNAMismatchRealTimeNotificationEnabledChanged || isCPMMismatchRealTimeNotificationEnabledChanged || isCounterExplodedRealTimeNotificationEnabledChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || cpm_commandChanged || allowed_inactivity_periodChanged || gl_numberChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || descriptionChanged || is_dff_generation_haltChanged || cit_atm_titleChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || no_of_dispensed_transactions_to_monitorChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || longitudeChanged || latitudeChanged || on_us_amountChanged || not_on_us_amountChanged || standard_order_type1Changed || standard_order_type2Changed || standard_order_type3Changed || standard_order_type4Changed || standard_order_type5Changed || standard_order_type6Changed || standard_order_type7Changed || protocol_type_idChanged || current_modeChanged || aggregate_stateChanged || last_boot_timeChanged || discovery_timeChanged || last_scan_timeChanged || communication_statusChanged || is_criticalChanged || current_mode_modified_onChanged || last_Notification_Received_OnChanged || last_Notification_TimeChanged || normal_order_costChanged || emergency_order_costChanged || receipt_transaction_cutoffChanged || is_swap_default_replenishmentChanged || message_processor_idChanged || last_ping_statusChanged || last_ping_executed_atChanged || last_telnet_statusChanged || last_telnet_executed_atChanged || last_archive_file_received_atChanged || is_sdmChanged || initEjExecTimeChanged || ccmsagent_last_reported_heartbeatChanged || ccmsservicemanager_last_reported_heartbeatChanged || distribution_portChanged || parser_rep_date_formatChanged || type1_min_notes_thresholdChanged || type2_min_notes_thresholdChanged || type3_min_notes_thresholdChanged || type4_min_notes_thresholdChanged || type1_suggested_notes_normal_daysChanged || type2_suggested_notes_normal_daysChanged || type3_suggested_notes_normal_daysChanged || type4_suggested_notes_normal_daysChanged || type5_suggested_notes_normal_daysChanged || type6_suggested_notes_normal_daysChanged || type7_suggested_notes_normal_daysChanged || type1_suggested_notes_salary_daysChanged || type2_suggested_notes_salary_daysChanged || type3_suggested_notes_salary_daysChanged || type4_suggested_notes_salary_daysChanged || type5_suggested_notes_salary_daysChanged || type6_suggested_notes_salary_daysChanged || type7_suggested_notes_salary_daysChanged || avg_dispensedChanged || spare_cashChanged || dispensing_behaviorChanged || avg_dispensed_salary_daysChanged || inactivity_period_salary_daysChanged || inactivity_period_normal_daysChanged || type1_min_notes_threshold_valueChanged || type2_min_notes_threshold_valueChanged || type3_min_notes_threshold_valueChanged || type4_min_notes_threshold_valueChanged || bna_allowed_inactivity_period_normal_daysChanged || bna_allowed_inactivity_period_salary_daysChanged || cheque_allowed_inactivity_period_normal_daysChanged || cheque_allowed_inactivity_period_salary_daysChanged || min_operating_balance_normal_daysChanged || min_operating_balance_salary_daysChanged || is_order_auto_generatedChanged || is_win7_machineChanged || is_branch_atmChanged || is_emirate_islamicChanged || is_itmChanged || is_bulk_cash_depositChanged || is_comboChanged || atm_costChanged || software_costChanged || network_costChanged || site_preparation_costChanged || security_infrastructure_costChanged || im_branch_codeChanged || im_en_idChanged || im_locationChanged || im_business_areaChanged || im_circleChanged || cit_idChanged || atm_bandwidth_idChanged || atm_model_idChanged || is_recyclerChanged))
                        return;
                    qry.Append("UPDATE Atm set "); if (last_status_replyChanged)
                    {
                        qry.Append("last_status_reply =" + last_status_replyDbString);
                        qry.Append(",");
                    }

                    if (region_idChanged)
                    {
                        qry.Append("region_id =" + region_idDbString);
                        qry.Append(",");
                    }

                    if (titleChanged)
                    {
                        qry.Append("title =" + titleDbString);
                        qry.Append(",");
                    }

                    if (iPChanged)
                    {
                        qry.Append("IP =" + iPDbString);
                        qry.Append(",");
                    }

                    if (portChanged)
                    {
                        qry.Append("port =" + portDbString);
                        qry.Append(",");
                    }

                    if (modified_byChanged)
                    {
                        qry.Append("modified_by =" + modified_byDbString);
                        qry.Append(",");
                    }

                    if (created_byChanged)
                    {
                        qry.Append("created_by =" + created_byDbString);
                        qry.Append(",");
                    }

                    if (is_activeChanged)
                    {
                        qry.Append("is_active =" + is_activeDbString);
                        qry.Append(",");
                    }

                    if (creation_timeChanged)
                    {
                        qry.Append("creation_time =" + creation_timeDbString);
                        qry.Append(",");
                    }

                    if (atm_typeChanged)
                    {
                        qry.Append("atm_type =" + atm_typeDbString);
                        qry.Append(",");
                    }

                    if (cassette1_capacityChanged)
                    {
                        qry.Append("cassette1_capacity =" + cassette1_capacityDbString);
                        qry.Append(",");
                    }

                    if (cassette1_denominationChanged)
                    {
                        qry.Append("cassette1_denomination =" + cassette1_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette2_capacityChanged)
                    {
                        qry.Append("cassette2_capacity =" + cassette2_capacityDbString);
                        qry.Append(",");
                    }

                    if (cassette2_denominationChanged)
                    {
                        qry.Append("cassette2_denomination =" + cassette2_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette3_denominationChanged)
                    {
                        qry.Append("cassette3_denomination =" + cassette3_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette3_capacityChanged)
                    {
                        qry.Append("cassette3_capacity =" + cassette3_capacityDbString);
                        qry.Append(",");
                    }

                    if (cassette4_denominationChanged)
                    {
                        qry.Append("cassette4_denomination =" + cassette4_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette4_capacityChanged)
                    {
                        qry.Append("cassette4_capacity =" + cassette4_capacityDbString);
                        qry.Append(",");
                    }

                    if (cassette5_denominationChanged)
                    {
                        qry.Append("cassette5_denomination =" + cassette5_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette5_capacityChanged)
                    {
                        qry.Append("cassette5_capacity =" + cassette5_capacityDbString);
                        qry.Append(",");
                    }

                    if (cassette6_denominationChanged)
                    {
                        qry.Append("cassette6_denomination =" + cassette6_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette6_capacityChanged)
                    {
                        qry.Append("cassette6_capacity =" + cassette6_capacityDbString);
                        qry.Append(",");
                    }

                    if (cassette7_denominationChanged)
                    {
                        qry.Append("cassette7_denomination =" + cassette7_denominationDbString);
                        qry.Append(",");
                    }

                    if (cassette7_capacityChanged)
                    {
                        qry.Append("cassette7_capacity =" + cassette7_capacityDbString);
                        qry.Append(",");
                    }

                    if (last_wincor_sentChanged)
                    {
                        qry.Append("last_wincor_sent =" + last_wincor_sentDbString);
                        qry.Append(",");
                    }

                    if (is_healthyChanged)
                    {
                        qry.Append("is_healthy =" + is_healthyDbString);
                        qry.Append(",");
                    }

                    if (locationChanged)
                    {
                        qry.Append("location =" + locationDbString);
                        qry.Append(",");
                    }

                    if (address1Changed)
                    {
                        qry.Append("address1 =" + address1DbString);
                        qry.Append(",");
                    }

                    if (address2Changed)
                    {
                        qry.Append("address2 =" + address2DbString);
                        qry.Append(",");
                    }

                    if (cityChanged)
                    {
                        qry.Append("city =" + cityDbString);
                        qry.Append(",");
                    }

                    if (countryChanged)
                    {
                        qry.Append("country =" + countryDbString);
                        qry.Append(",");
                    }

                    if (zip_codeChanged)
                    {
                        qry.Append("zip_code =" + zip_codeDbString);
                        qry.Append(",");
                    }

                    if (location_typeChanged)
                    {
                        qry.Append("location_type =" + location_typeDbString);
                        qry.Append(",");
                    }

                    if (service_statusChanged)
                    {
                        qry.Append("service_status =" + service_statusDbString);
                        qry.Append(",");
                    }

                    if (holiday_statusChanged)
                    {
                        qry.Append("holiday_status =" + holiday_statusDbString);
                        qry.Append(",");
                    }

                    if (business_daysChanged)
                    {
                        qry.Append("business_days =" + business_daysDbString);
                        qry.Append(",");
                    }

                    if (time_zoneChanged)
                    {
                        qry.Append("time_zone =" + time_zoneDbString);
                        qry.Append(",");
                    }

                    if (max_notes_per_cassetteChanged)
                    {
                        qry.Append("max_notes_per_cassette =" + max_notes_per_cassetteDbString);
                        qry.Append(",");
                    }

                    if (cassette1_split_percentageChanged)
                    {
                        qry.Append("cassette1_split_percentage =" + cassette1_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (cassette2_split_percentageChanged)
                    {
                        qry.Append("cassette2_split_percentage =" + cassette2_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (cassette3_split_percentageChanged)
                    {
                        qry.Append("cassette3_split_percentage =" + cassette3_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (cassette4_split_percentageChanged)
                    {
                        qry.Append("cassette4_split_percentage =" + cassette4_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (cassette5_split_percentageChanged)
                    {
                        qry.Append("cassette5_split_percentage =" + cassette5_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (cassette6_split_percentageChanged)
                    {
                        qry.Append("cassette6_split_percentage =" + cassette6_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (cassette7_split_percentageChanged)
                    {
                        qry.Append("cassette7_split_percentage =" + cassette7_split_percentageDbString);
                        qry.Append(",");
                    }

                    if (interest_rateChanged)
                    {
                        qry.Append("interest_rate =" + interest_rateDbString);
                        qry.Append(",");
                    }

                    if (insurance_rateChanged)
                    {
                        qry.Append("insurance_rate =" + insurance_rateDbString);
                        qry.Append(",");
                    }

                    if (max_holding_amountChanged)
                    {
                        qry.Append("max_holding_amount =" + max_holding_amountDbString);
                        qry.Append(",");
                    }

                    if (min_operating_balanceChanged)
                    {
                        qry.Append("min_operating_balance =" + min_operating_balanceDbString);
                        qry.Append(",");
                    }

                    if (min_amount_for_normal_deliveryChanged)
                    {
                        qry.Append("min_amount_for_normal_delivery =" + min_amount_for_normal_deliveryDbString);
                        qry.Append(",");
                    }

                    if (bank_cash_center_idChanged)
                    {
                        qry.Append("bank_cash_center_id =" + bank_cash_center_idDbString);
                        qry.Append(",");
                    }

                    if (cIT_cash_center_servicerChanged)
                    {
                        qry.Append("CIT_cash_center_servicer =" + cIT_cash_center_servicerDbString);
                        qry.Append(",");
                    }

                    if (depot_idChanged)
                    {
                        qry.Append("depot_id =" + depot_idDbString);
                        qry.Append(",");
                    }

                    if (secondary_depot_vault_idChanged)
                    {
                        qry.Append("secondary_depot_vault_id =" + secondary_depot_vault_idDbString);
                        qry.Append(",");
                    }

                    if (new_atm_scenarioChanged)
                    {
                        qry.Append("new_atm_scenario =" + new_atm_scenarioDbString);
                        qry.Append(",");
                    }

                    if (cash_swap_daysChanged)
                    {
                        qry.Append("cash_swap_days =" + cash_swap_daysDbString);
                        qry.Append(",");
                    }

                    if (mandatory_cash_swap_daysChanged)
                    {
                        qry.Append("mandatory_cash_swap_days =" + mandatory_cash_swap_daysDbString);
                        qry.Append(",");
                    }

                    if (cash_swap_cycleChanged)
                    {
                        qry.Append("cash_swap_cycle =" + cash_swap_cycleDbString);
                        qry.Append(",");
                    }

                    if (cash_swap_lead_timeChanged)
                    {
                        qry.Append("cash_swap_lead_time =" + cash_swap_lead_timeDbString);
                        qry.Append(",");
                    }

                    if (cash_swap_start_dateChanged)
                    {
                        qry.Append("cash_swap_start_date =" + cash_swap_start_dateDbString);
                        qry.Append(",");
                    }

                    if (cash_swap_handling_costChanged)
                    {
                        qry.Append("cash_swap_handling_cost =" + cash_swap_handling_costDbString);
                        qry.Append(",");
                    }

                    if (cash_swap_costsChanged)
                    {
                        qry.Append("cash_swap_costs =" + cash_swap_costsDbString);
                        qry.Append(",");
                    }

                    if (emergency_daysChanged)
                    {
                        qry.Append("emergency_days =" + emergency_daysDbString);
                        qry.Append(",");
                    }

                    if (emergency_lead_timeChanged)
                    {
                        qry.Append("emergency_lead_time =" + emergency_lead_timeDbString);
                        qry.Append(",");
                    }

                    if (emergency_costChanged)
                    {
                        qry.Append("emergency_cost =" + emergency_costDbString);
                        qry.Append(",");
                    }

                    if (contact1_emailChanged)
                    {
                        qry.Append("contact1_email =" + contact1_emailDbString);
                        qry.Append(",");
                    }

                    if (contact2_emailChanged)
                    {
                        qry.Append("contact2_email =" + contact2_emailDbString);
                        qry.Append(",");
                    }

                    if (contact3_emailChanged)
                    {
                        qry.Append("contact3_email =" + contact3_emailDbString);
                        qry.Append(",");
                    }

                    if (contact1_phoneChanged)
                    {
                        qry.Append("contact1_phone =" + contact1_phoneDbString);
                        qry.Append(",");
                    }

                    if (contact2_phoneChanged)
                    {
                        qry.Append("contact2_phone =" + contact2_phoneDbString);
                        qry.Append(",");
                    }

                    if (contact3_phoneChanged)
                    {
                        qry.Append("contact3_phone =" + contact3_phoneDbString);
                        qry.Append(",");
                    }

                    if (effective_dateChanged)
                    {
                        qry.Append("effective_date =" + effective_dateDbString);
                        qry.Append(",");
                    }

                    if (suspend_cash_orderChanged)
                    {
                        qry.Append("suspend_cash_order =" + suspend_cash_orderDbString);
                        qry.Append(",");
                    }

                    if (is_atmChanged)
                    {
                        qry.Append("is_atm =" + is_atmDbString);
                        qry.Append(",");
                    }

                    if (is_cdmChanged)
                    {
                        qry.Append("is_cdm =" + is_cdmDbString);
                        qry.Append(",");
                    }

                    if (is_ccdmChanged)
                    {
                        qry.Append("is_ccdm =" + is_ccdmDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette1_capacityChanged)
                    {
                        qry.Append("cdm_cassette1_capacity =" + cdm_cassette1_capacityDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette2_capacityChanged)
                    {
                        qry.Append("cdm_cassette2_capacity =" + cdm_cassette2_capacityDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette3_capacityChanged)
                    {
                        qry.Append("cdm_cassette3_capacity =" + cdm_cassette3_capacityDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette4_capacityChanged)
                    {
                        qry.Append("cdm_cassette4_capacity =" + cdm_cassette4_capacityDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette1_capacityChanged)
                    {
                        qry.Append("ccdm_cassette1_capacity =" + ccdm_cassette1_capacityDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette2_capacityChanged)
                    {
                        qry.Append("ccdm_cassette2_capacity =" + ccdm_cassette2_capacityDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette3_capacityChanged)
                    {
                        qry.Append("ccdm_cassette3_capacity =" + ccdm_cassette3_capacityDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette4_capacityChanged)
                    {
                        qry.Append("ccdm_cassette4_capacity =" + ccdm_cassette4_capacityDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette1_thresholdChanged)
                    {
                        qry.Append("cdm_cassette1_threshold =" + cdm_cassette1_thresholdDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette2_thresholdChanged)
                    {
                        qry.Append("cdm_cassette2_threshold =" + cdm_cassette2_thresholdDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette3_thresholdChanged)
                    {
                        qry.Append("cdm_cassette3_threshold =" + cdm_cassette3_thresholdDbString);
                        qry.Append(",");
                    }

                    if (cdm_cassette4_thresholdChanged)
                    {
                        qry.Append("cdm_cassette4_threshold =" + cdm_cassette4_thresholdDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette1_thresholdChanged)
                    {
                        qry.Append("ccdm_cassette1_threshold =" + ccdm_cassette1_thresholdDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette2_thresholdChanged)
                    {
                        qry.Append("ccdm_cassette2_threshold =" + ccdm_cassette2_thresholdDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette3_thresholdChanged)
                    {
                        qry.Append("ccdm_cassette3_threshold =" + ccdm_cassette3_thresholdDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette4_thresholdChanged)
                    {
                        qry.Append("ccdm_cassette4_threshold =" + ccdm_cassette4_thresholdDbString);
                        qry.Append(",");
                    }

                    if (note_set_type_idChanged)
                    {
                        qry.Append("note_set_type_id =" + note_set_type_idDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette5_capacityChanged)
                    {
                        qry.Append("ccdm_cassette5_capacity =" + ccdm_cassette5_capacityDbString);
                        qry.Append(",");
                    }

                    if (ccdm_cassette5_thresholdChanged)
                    {
                        qry.Append("ccdm_cassette5_threshold =" + ccdm_cassette5_thresholdDbString);
                        qry.Append(",");
                    }

                    if (startup_sleep_intervalChanged)
                    {
                        qry.Append("startup_sleep_interval =" + startup_sleep_intervalDbString);
                        qry.Append(",");
                    }

                    if (debug_levelChanged)
                    {
                        qry.Append("debug_level =" + debug_levelDbString);
                        qry.Append(",");
                    }

                    if (exclude_dffChanged)
                    {
                        qry.Append("exclude_dff =" + exclude_dffDbString);
                        qry.Append(",");
                    }

                    if (purge1_thresholdChanged)
                    {
                        qry.Append("purge1_threshold =" + purge1_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge1_threshold_selectedChanged)
                    {
                        qry.Append("is_purge1_threshold_selected =" + is_purge1_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (purge2_thresholdChanged)
                    {
                        qry.Append("purge2_threshold =" + purge2_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge2_threshold_selectedChanged)
                    {
                        qry.Append("is_purge2_threshold_selected =" + is_purge2_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (purge3_thresholdChanged)
                    {
                        qry.Append("purge3_threshold =" + purge3_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge3_threshold_selectedChanged)
                    {
                        qry.Append("is_purge3_threshold_selected =" + is_purge3_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (purge4_thresholdChanged)
                    {
                        qry.Append("purge4_threshold =" + purge4_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge4_threshold_selectedChanged)
                    {
                        qry.Append("is_purge4_threshold_selected =" + is_purge4_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (purge5_thresholdChanged)
                    {
                        qry.Append("purge5_threshold =" + purge5_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge5_threshold_selectedChanged)
                    {
                        qry.Append("is_purge5_threshold_selected =" + is_purge5_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (purge6_thresholdChanged)
                    {
                        qry.Append("purge6_threshold =" + purge6_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge6_threshold_selectedChanged)
                    {
                        qry.Append("is_purge6_threshold_selected =" + is_purge6_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (purge7_thresholdChanged)
                    {
                        qry.Append("purge7_threshold =" + purge7_thresholdDbString);
                        qry.Append(",");
                    }

                    if (is_purge7_threshold_selectedChanged)
                    {
                        qry.Append("is_purge7_threshold_selected =" + is_purge7_threshold_selectedDbString);
                        qry.Append(",");
                    }

                    if (retry_count_cash_order_uploadChanged)
                    {
                        qry.Append("retry_count_cash_order_upload =" + retry_count_cash_order_uploadDbString);
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

                    if (retry_count_alertChanged)
                    {
                        qry.Append("retry_count_alert =" + retry_count_alertDbString);
                        qry.Append(",");
                    }

                    if (countsClearRetriesChanged)
                    {
                        qry.Append("CountsClearRetries =" + countsClearRetriesDbString);
                        qry.Append(",");
                    }

                    if (tCPTimeoutChanged)
                    {
                        qry.Append("TCPTimeout =" + tCPTimeoutDbString);
                        qry.Append(",");
                    }

                    if (sleepIntervalChanged)
                    {
                        qry.Append("SleepInterval =" + sleepIntervalDbString);
                        qry.Append(",");
                    }

                    if (cPMCommandWaitChanged)
                    {
                        qry.Append("CPMCommandWait =" + cPMCommandWaitDbString);
                        qry.Append(",");
                    }

                    if (cPMCommandSleepChanged)
                    {
                        qry.Append("CPMCommandSleep =" + cPMCommandSleepDbString);
                        qry.Append(",");
                    }

                    if (aANDCApplications1Changed)
                    {
                        qry.Append("AANDCApplications1 =" + aANDCApplications1DbString);
                        qry.Append(",");
                    }

                    if (aANDCApplications2Changed)
                    {
                        qry.Append("AANDCApplications2 =" + aANDCApplications2DbString);
                        qry.Append(",");
                    }

                    if (aANDCApplications3Changed)
                    {
                        qry.Append("AANDCApplications3 =" + aANDCApplications3DbString);
                        qry.Append(",");
                    }

                    if (aANDCApplications4Changed)
                    {
                        qry.Append("AANDCApplications4 =" + aANDCApplications4DbString);
                        qry.Append(",");
                    }

                    if (aANDCApplications5Changed)
                    {
                        qry.Append("AANDCApplications5 =" + aANDCApplications5DbString);
                        qry.Append(",");
                    }

                    if (monitoring_RetriesChanged)
                    {
                        qry.Append("Monitoring_Retries =" + monitoring_RetriesDbString);
                        qry.Append(",");
                    }

                    if (windowSwitch_SleepChanged)
                    {
                        qry.Append("WindowSwitch_Sleep =" + windowSwitch_SleepDbString);
                        qry.Append(",");
                    }

                    if (appSwitch_SleepChanged)
                    {
                        qry.Append("AppSwitch_Sleep =" + appSwitch_SleepDbString);
                        qry.Append(",");
                    }

                    if (monitoringCycle_SleepChanged)
                    {
                        qry.Append("MonitoringCycle_Sleep =" + monitoringCycle_SleepDbString);
                        qry.Append(",");
                    }

                    if (cPMLogLevelChanged)
                    {
                        qry.Append("CPMLogLevel =" + cPMLogLevelDbString);
                        qry.Append(",");
                    }

                    if (isDispenserRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsDispenserRealTimeNotificationEnabled =" + isDispenserRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isBNARealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsBNARealTimeNotificationEnabled =" + isBNARealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isCPMRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsCPMRealTimeNotificationEnabled =" + isCPMRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isReplenishmentRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsReplenishmentRealTimeNotificationEnabled =" + isReplenishmentRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isOutOfCashRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsOutOfCashRealTimeNotificationEnabled =" + isOutOfCashRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isDispenserMismatchRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsDispenserMismatchRealTimeNotificationEnabled =" + isDispenserMismatchRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isBNAMismatchRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsBNAMismatchRealTimeNotificationEnabled =" + isBNAMismatchRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isCPMMismatchRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsCPMMismatchRealTimeNotificationEnabled =" + isCPMMismatchRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (isCounterExplodedRealTimeNotificationEnabledChanged)
                    {
                        qry.Append("IsCounterExplodedRealTimeNotificationEnabled =" + isCounterExplodedRealTimeNotificationEnabledDbString);
                        qry.Append(",");
                    }

                    if (type1MinimumNotesChanged)
                    {
                        qry.Append("Type1MinimumNotes =" + type1MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (type2MinimumNotesChanged)
                    {
                        qry.Append("Type2MinimumNotes =" + type2MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (type3MinimumNotesChanged)
                    {
                        qry.Append("Type3MinimumNotes =" + type3MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (type4MinimumNotesChanged)
                    {
                        qry.Append("Type4MinimumNotes =" + type4MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (type5MinimumNotesChanged)
                    {
                        qry.Append("Type5MinimumNotes =" + type5MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (type6MinimumNotesChanged)
                    {
                        qry.Append("Type6MinimumNotes =" + type6MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (type7MinimumNotesChanged)
                    {
                        qry.Append("Type7MinimumNotes =" + type7MinimumNotesDbString);
                        qry.Append(",");
                    }

                    if (cpm_commandChanged)
                    {
                        qry.Append("cpm_command =" + cpm_commandDbString);
                        qry.Append(",");
                    }

                    if (allowed_inactivity_periodChanged)
                    {
                        qry.Append("allowed_inactivity_period =" + allowed_inactivity_periodDbString);
                        qry.Append(",");
                    }

                    if (gl_numberChanged)
                    {
                        qry.Append("gl_number =" + gl_numberDbString);
                        qry.Append(",");
                    }

                    if (card_captured_costChanged)
                    {
                        qry.Append("card_captured_cost =" + card_captured_costDbString);
                        qry.Append(",");
                    }

                    if (escotting_costChanged)
                    {
                        qry.Append("escotting_cost =" + escotting_costDbString);
                        qry.Append(",");
                    }

                    if (replenishment_costChanged)
                    {
                        qry.Append("replenishment_cost =" + replenishment_costDbString);
                        qry.Append(",");
                    }

                    if (maintenance_costChanged)
                    {
                        qry.Append("maintenance_cost =" + maintenance_costDbString);
                        qry.Append(",");
                    }

                    if (flm_call_out_costChanged)
                    {
                        qry.Append("flm_call_out_cost =" + flm_call_out_costDbString);
                        qry.Append(",");
                    }

                    if (descriptionChanged)
                    {
                        qry.Append("description =" + descriptionDbString);
                        qry.Append(",");
                    }

                    if (is_dff_generation_haltChanged)
                    {
                        qry.Append("is_dff_generation_halt =" + is_dff_generation_haltDbString);
                        qry.Append(",");
                    }

                    if (cit_atm_titleChanged)
                    {
                        qry.Append("cit_atm_title =" + cit_atm_titleDbString);
                        qry.Append(",");
                    }

                    if (cheque_allowed_inactivity_periodChanged)
                    {
                        qry.Append("cheque_allowed_inactivity_period =" + cheque_allowed_inactivity_periodDbString);
                        qry.Append(",");
                    }

                    if (bna_allowed_inactivity_periodChanged)
                    {
                        qry.Append("bna_allowed_inactivity_period =" + bna_allowed_inactivity_periodDbString);
                        qry.Append(",");
                    }

                    if (out_of_cash_thresholdChanged)
                    {
                        qry.Append("out_of_cash_threshold =" + out_of_cash_thresholdDbString);
                        qry.Append(",");
                    }

                    if (no_of_dispensed_transactions_to_monitorChanged)
                    {
                        qry.Append("no_of_dispensed_transactions_to_monitor =" + no_of_dispensed_transactions_to_monitorDbString);
                        qry.Append(",");
                    }

                    if (is_ej_enabledChanged)
                    {
                        qry.Append("is_ej_enabled =" + is_ej_enabledDbString);
                        qry.Append(",");
                    }

                    if (is_counter_enabledChanged)
                    {
                        qry.Append("is_counter_enabled =" + is_counter_enabledDbString);
                        qry.Append(",");
                    }

                    if (priorityChanged)
                    {
                        qry.Append("priority =" + priorityDbString);
                        qry.Append(",");
                    }

                    if (longitudeChanged)
                    {
                        qry.Append("longitude =" + longitudeDbString);
                        qry.Append(",");
                    }

                    if (latitudeChanged)
                    {
                        qry.Append("latitude =" + latitudeDbString);
                        qry.Append(",");
                    }

                    if (on_us_amountChanged)
                    {
                        qry.Append("on_us_amount =" + on_us_amountDbString);
                        qry.Append(",");
                    }

                    if (not_on_us_amountChanged)
                    {
                        qry.Append("not_on_us_amount =" + not_on_us_amountDbString);
                        qry.Append(",");
                    }

                    if (standard_order_type1Changed)
                    {
                        qry.Append("standard_order_type1 =" + standard_order_type1DbString);
                        qry.Append(",");
                    }

                    if (standard_order_type2Changed)
                    {
                        qry.Append("standard_order_type2 =" + standard_order_type2DbString);
                        qry.Append(",");
                    }

                    if (standard_order_type3Changed)
                    {
                        qry.Append("standard_order_type3 =" + standard_order_type3DbString);
                        qry.Append(",");
                    }

                    if (standard_order_type4Changed)
                    {
                        qry.Append("standard_order_type4 =" + standard_order_type4DbString);
                        qry.Append(",");
                    }

                    if (standard_order_type5Changed)
                    {
                        qry.Append("standard_order_type5 =" + standard_order_type5DbString);
                        qry.Append(",");
                    }

                    if (standard_order_type6Changed)
                    {
                        qry.Append("standard_order_type6 =" + standard_order_type6DbString);
                        qry.Append(",");
                    }

                    if (standard_order_type7Changed)
                    {
                        qry.Append("standard_order_type7 =" + standard_order_type7DbString);
                        qry.Append(",");
                    }

                    if (protocol_type_idChanged)
                    {
                        qry.Append("protocol_type_id =" + protocol_type_idDbString);
                        qry.Append(",");
                    }

                    if (current_modeChanged)
                    {
                        qry.Append("current_mode =" + current_modeDbString);
                        qry.Append(",");
                    }

                    if (aggregate_stateChanged)
                    {
                        qry.Append("aggregate_state =" + aggregate_stateDbString);
                        qry.Append(",");
                    }

                    if (last_boot_timeChanged)
                    {
                        qry.Append("last_boot_time =" + last_boot_timeDbString);
                        qry.Append(",");
                    }

                    if (discovery_timeChanged)
                    {
                        qry.Append("discovery_time =" + discovery_timeDbString);
                        qry.Append(",");
                    }

                    if (last_scan_timeChanged)
                    {
                        qry.Append("last_scan_time =" + last_scan_timeDbString);
                        qry.Append(",");
                    }

                    if (communication_statusChanged)
                    {
                        qry.Append("communication_status =" + communication_statusDbString);
                        qry.Append(",");
                    }

                    if (is_criticalChanged)
                    {
                        qry.Append("is_critical =" + is_criticalDbString);
                        qry.Append(",");
                    }

                    if (current_mode_modified_onChanged)
                    {
                        qry.Append("current_mode_modified_on =" + current_mode_modified_onDbString);
                        qry.Append(",");
                    }

                    if (last_Notification_Received_OnChanged)
                    {
                        qry.Append("Last_Notification_Received_On =" + last_Notification_Received_OnDbString);
                        qry.Append(",");
                    }

                    if (last_Notification_TimeChanged)
                    {
                        qry.Append("Last_Notification_Time =" + last_Notification_TimeDbString);
                        qry.Append(",");
                    }

                    if (normal_order_costChanged)
                    {
                        qry.Append("normal_order_cost =" + normal_order_costDbString);
                        qry.Append(",");
                    }

                    if (emergency_order_costChanged)
                    {
                        qry.Append("emergency_order_cost =" + emergency_order_costDbString);
                        qry.Append(",");
                    }

                    if (receipt_transaction_cutoffChanged)
                    {
                        qry.Append("receipt_transaction_cutoff =" + receipt_transaction_cutoffDbString);
                        qry.Append(",");
                    }

                    if (is_swap_default_replenishmentChanged)
                    {
                        qry.Append("is_swap_default_replenishment =" + is_swap_default_replenishmentDbString);
                        qry.Append(",");
                    }

                    if (message_processor_idChanged)
                    {
                        qry.Append("message_processor_id =" + message_processor_idDbString);
                        qry.Append(",");
                    }

                    if (last_ping_statusChanged)
                    {
                        qry.Append("last_ping_status =" + last_ping_statusDbString);
                        qry.Append(",");
                    }

                    if (last_ping_executed_atChanged)
                    {
                        qry.Append("last_ping_executed_at =" + last_ping_executed_atDbString);
                        qry.Append(",");
                    }

                    if (last_telnet_statusChanged)
                    {
                        qry.Append("last_telnet_status =" + last_telnet_statusDbString);
                        qry.Append(",");
                    }

                    if (last_telnet_executed_atChanged)
                    {
                        qry.Append("last_telnet_executed_at =" + last_telnet_executed_atDbString);
                        qry.Append(",");
                    }

                    if (last_archive_file_received_atChanged)
                    {
                        qry.Append("last_archive_file_received_at =" + last_archive_file_received_atDbString);
                        qry.Append(",");
                    }

                    if (is_sdmChanged)
                    {
                        qry.Append("is_sdm =" + is_sdmDbString);
                        qry.Append(",");
                    }

                    if (initEjExecTimeChanged)
                    {
                        qry.Append("initEjExecTime =" + initEjExecTimeDbString);
                        qry.Append(",");
                    }

                    if (ccmsagent_last_reported_heartbeatChanged)
                    {
                        qry.Append("ccmsagent_last_reported_heartbeat =" + ccmsagent_last_reported_heartbeatDbString);
                        qry.Append(",");
                    }

                    if (ccmsservicemanager_last_reported_heartbeatChanged)
                    {
                        qry.Append("ccmsservicemanager_last_reported_heartbeat =" + ccmsservicemanager_last_reported_heartbeatDbString);
                        qry.Append(",");
                    }

                    if (distribution_portChanged)
                    {
                        qry.Append("distribution_port =" + distribution_portDbString);
                        qry.Append(",");
                    }

                    if (parser_rep_date_formatChanged)
                    {
                        qry.Append("parser_rep_date_format =" + parser_rep_date_formatDbString);
                        qry.Append(",");
                    }

                    if (type1_min_notes_thresholdChanged)
                    {
                        qry.Append("type1_min_notes_threshold =" + type1_min_notes_thresholdDbString);
                        qry.Append(",");
                    }

                    if (type2_min_notes_thresholdChanged)
                    {
                        qry.Append("type2_min_notes_threshold =" + type2_min_notes_thresholdDbString);
                        qry.Append(",");
                    }

                    if (type3_min_notes_thresholdChanged)
                    {
                        qry.Append("type3_min_notes_threshold =" + type3_min_notes_thresholdDbString);
                        qry.Append(",");
                    }

                    if (type4_min_notes_thresholdChanged)
                    {
                        qry.Append("type4_min_notes_threshold =" + type4_min_notes_thresholdDbString);
                        qry.Append(",");
                    }

                    if (type1_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type1_suggested_notes_normal_days =" + type1_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type2_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type2_suggested_notes_normal_days =" + type2_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type3_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type3_suggested_notes_normal_days =" + type3_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type4_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type4_suggested_notes_normal_days =" + type4_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type5_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type5_suggested_notes_normal_days =" + type5_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type6_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type6_suggested_notes_normal_days =" + type6_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type7_suggested_notes_normal_daysChanged)
                    {
                        qry.Append("type7_suggested_notes_normal_days =" + type7_suggested_notes_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type1_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type1_suggested_notes_salary_days =" + type1_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (type2_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type2_suggested_notes_salary_days =" + type2_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (type3_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type3_suggested_notes_salary_days =" + type3_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (type4_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type4_suggested_notes_salary_days =" + type4_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (type5_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type5_suggested_notes_salary_days =" + type5_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (type6_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type6_suggested_notes_salary_days =" + type6_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (type7_suggested_notes_salary_daysChanged)
                    {
                        qry.Append("type7_suggested_notes_salary_days =" + type7_suggested_notes_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (avg_dispensedChanged)
                    {
                        qry.Append("avg_dispensed =" + avg_dispensedDbString);
                        qry.Append(",");
                    }

                    if (spare_cashChanged)
                    {
                        qry.Append("spare_cash =" + spare_cashDbString);
                        qry.Append(",");
                    }

                    if (dispensing_behaviorChanged)
                    {
                        qry.Append("dispensing_behavior =" + dispensing_behaviorDbString);
                        qry.Append(",");
                    }

                    if (avg_dispensed_salary_daysChanged)
                    {
                        qry.Append("avg_dispensed_salary_days =" + avg_dispensed_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (inactivity_period_salary_daysChanged)
                    {
                        qry.Append("inactivity_period_salary_days =" + inactivity_period_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (inactivity_period_normal_daysChanged)
                    {
                        qry.Append("inactivity_period_normal_days =" + inactivity_period_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (type1_min_notes_threshold_valueChanged)
                    {
                        qry.Append("type1_min_notes_threshold_value =" + type1_min_notes_threshold_valueDbString);
                        qry.Append(",");
                    }

                    if (type2_min_notes_threshold_valueChanged)
                    {
                        qry.Append("type2_min_notes_threshold_value =" + type2_min_notes_threshold_valueDbString);
                        qry.Append(",");
                    }

                    if (type3_min_notes_threshold_valueChanged)
                    {
                        qry.Append("type3_min_notes_threshold_value =" + type3_min_notes_threshold_valueDbString);
                        qry.Append(",");
                    }

                    if (type4_min_notes_threshold_valueChanged)
                    {
                        qry.Append("type4_min_notes_threshold_value =" + type4_min_notes_threshold_valueDbString);
                        qry.Append(",");
                    }

                    if (bna_allowed_inactivity_period_normal_daysChanged)
                    {
                        qry.Append("bna_allowed_inactivity_period_normal_days =" + bna_allowed_inactivity_period_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (bna_allowed_inactivity_period_salary_daysChanged)
                    {
                        qry.Append("bna_allowed_inactivity_period_salary_days =" + bna_allowed_inactivity_period_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (cheque_allowed_inactivity_period_normal_daysChanged)
                    {
                        qry.Append("cheque_allowed_inactivity_period_normal_days =" + cheque_allowed_inactivity_period_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (cheque_allowed_inactivity_period_salary_daysChanged)
                    {
                        qry.Append("cheque_allowed_inactivity_period_salary_days =" + cheque_allowed_inactivity_period_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (min_operating_balance_normal_daysChanged)
                    {
                        qry.Append("min_operating_balance_normal_days =" + min_operating_balance_normal_daysDbString);
                        qry.Append(",");
                    }

                    if (min_operating_balance_salary_daysChanged)
                    {
                        qry.Append("min_operating_balance_salary_days =" + min_operating_balance_salary_daysDbString);
                        qry.Append(",");
                    }

                    if (is_order_auto_generatedChanged)
                    {
                        qry.Append("is_order_auto_generated =" + is_order_auto_generatedDbString);
                        qry.Append(",");
                    }

                    if (is_win7_machineChanged)
                    {
                        qry.Append("is_win7_machine =" + is_win7_machineDbString);
                        qry.Append(",");
                    }

                    if (is_branch_atmChanged)
                    {
                        qry.Append("is_branch_atm =" + is_branch_atmDbString);
                        qry.Append(",");
                    }

                    if (is_emirate_islamicChanged)
                    {
                        qry.Append("is_emirate_islamic =" + is_emirate_islamicDbString);
                        qry.Append(",");
                    }

                    if (is_itmChanged)
                    {
                        qry.Append("is_itm =" + is_itmDbString);
                        qry.Append(",");
                    }

                    if (is_bulk_cash_depositChanged)
                    {
                        qry.Append("is_bulk_cash_deposit =" + is_bulk_cash_depositDbString);
                        qry.Append(",");
                    }

                    if (is_comboChanged)
                    {
                        qry.Append("is_combo =" + is_comboDbString);
                        qry.Append(",");
                    }

                    if (atm_costChanged)
                    {
                        qry.Append("atm_cost =" + atm_costDbString);
                        qry.Append(",");
                    }

                    if (software_costChanged)
                    {
                        qry.Append("software_cost =" + software_costDbString);
                        qry.Append(",");
                    }

                    if (network_costChanged)
                    {
                        qry.Append("network_cost =" + network_costDbString);
                        qry.Append(",");
                    }

                    if (site_preparation_costChanged)
                    {
                        qry.Append("site_preparation_cost =" + site_preparation_costDbString);
                        qry.Append(",");
                    }

                    if (security_infrastructure_costChanged)
                    {
                        qry.Append("security_infrastructure_cost =" + security_infrastructure_costDbString);
                        qry.Append(",");
                    }

                    if (im_branch_codeChanged)
                    {
                        qry.Append("im_branch_code =" + im_branch_codeDbString);
                        qry.Append(",");
                    }

                    if (im_en_idChanged)
                    {
                        qry.Append("im_en_id =" + im_en_idDbString);
                        qry.Append(",");
                    }

                    if (im_locationChanged)
                    {
                        qry.Append("im_location =" + im_locationDbString);
                        qry.Append(",");
                    }

                    if (im_business_areaChanged)
                    {
                        qry.Append("im_business_area =" + im_business_areaDbString);
                        qry.Append(",");
                    }

                    if (im_circleChanged)
                    {
                        qry.Append("im_circle =" + im_circleDbString);
                        qry.Append(",");
                    }

                    if (cit_idChanged)
                    {
                        qry.Append("cit_id =" + cit_idDbString);
                        qry.Append(",");
                    }

                    if (atm_bandwidth_idChanged)
                    {
                        qry.Append("atm_bandwidth_id =" + atm_bandwidth_idDbString);
                        qry.Append(",");
                    }

                    if (atm_model_idChanged)
                    {
                        qry.Append("atm_model_id =" + atm_model_idDbString);
                        qry.Append(",");
                    }

                    if (is_recyclerChanged)
                    {
                        qry.Append("is_recycler =" + is_recyclerDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ATM_id = " + aTM_idDbString);
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
            cmd.CommandText = "DELETE Atm where ATM_id= " + aTM_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteAtms(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Atm where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            ATM_id = 1,
            last_status_reply = 2,
            region_id = 3,
            title = 4,
            IP = 5,
            port = 6,
            modified_by = 7,
            created_by = 8,
            is_active = 9,
            creation_time = 10,
            atm_type = 11,
            cassette1_capacity = 12,
            cassette1_denomination = 13,
            cassette2_capacity = 14,
            cassette2_denomination = 15,
            cassette3_denomination = 16,
            cassette3_capacity = 17,
            cassette4_denomination = 18,
            cassette4_capacity = 19,
            cassette5_denomination = 20,
            cassette5_capacity = 21,
            cassette6_denomination = 22,
            cassette6_capacity = 23,
            cassette7_denomination = 24,
            cassette7_capacity = 25,
            last_wincor_sent = 26,
            is_healthy = 27,
            location = 28,
            address1 = 29,
            address2 = 30,
            city = 31,
            country = 32,
            zip_code = 33,
            location_type = 34,
            service_status = 35,
            holiday_status = 35,
            business_days = 37,
            time_zone = 38,
            max_notes_per_cassette = 39,
            cassette1_split_percentage = 40,
            cassette2_split_percentage = 41,
            cassette3_split_percentage = 42,
            cassette4_split_percentage = 43,
            cassette5_split_percentage = 44,
            cassette6_split_percentage = 45,
            cassette7_split_percentage = 46,
            interest_rate = 47,
            insurance_rate = 48,
            max_holding_amount = 49,
            min_operating_balance = 50,
            min_amount_for_normal_delivery = 51,
            bank_cash_center_id = 52,
            CIT_cash_center_servicer = 53,
            depot_id = 54,
            secondary_depot_vault_id = 55,
            new_atm_scenario = 56,
            cash_swap_days = 57,
            mandatory_cash_swap_days = 58,
            cash_swap_cycle = 59,
            cash_swap_lead_time = 60,
            cash_swap_start_date = 61,
            cash_swap_handling_cost = 62,
            cash_swap_costs = 63,
            emergency_days = 64,
            emergency_lead_time = 65,
            emergency_cost = 66,
            contact1_email = 67,
            contact2_email = 68,
            contact3_email = 69,
            contact1_phone = 70,
            contact2_phone = 71,
            contact3_phone = 72,
            effective_date = 73,
            suspend_cash_order = 74,
            is_atm = 75,
            is_cdm = 76,
            is_ccdm = 77,
            cdm_cassette1_capacity = 78,
            cdm_cassette2_capacity = 79,
            cdm_cassette3_capacity = 80,
            cdm_cassette4_capacity = 81,
            ccdm_cassette1_capacity = 82,
            ccdm_cassette2_capacity = 83,
            ccdm_cassette3_capacity = 84,
            ccdm_cassette4_capacity = 85,
            cdm_cassette1_threshold = 86,
            cdm_cassette2_threshold = 87,
            cdm_cassette3_threshold = 88,
            cdm_cassette4_threshold = 89,
            ccdm_cassette1_threshold = 90,
            ccdm_cassette2_threshold = 91,
            ccdm_cassette3_threshold = 92,
            ccdm_cassette4_threshold = 93,
            note_set_type_id = 94,
            ccdm_cassette5_capacity = 95,
            ccdm_cassette5_threshold = 96,
            startup_sleep_interval = 97,
            debug_level = 98,
            exclude_dff = 99,
            purge1_threshold = 100,
            is_purge1_threshold_selected = 101,
            purge2_threshold = 102,
            is_purge2_threshold_selected = 103,
            purge3_threshold = 104,
            is_purge3_threshold_selected = 105,
            purge4_threshold = 106,
            is_purge4_threshold_selected = 107,
            purge5_threshold = 108,
            is_purge5_threshold_selected = 109,
            purge6_threshold = 110,
            is_purge6_threshold_selected = 111,
            purge7_threshold = 112,
            is_purge7_threshold_selected = 113,
            retry_count_cash_order_upload = 114,
            retry_count_conf_upload = 115,
            retry_count_counter_file = 116,
            retry_count_restart_schedule = 117,
            retry_count_datetime_schedule = 118,
            retry_count_alert = 119,
            CountsClearRetries = 120,
            TCPTimeout = 121,
            SleepInterval = 122,
            CPMCommandWait = 123,
            CPMCommandSleep = 124,
            AANDCApplications1 = 125,
            AANDCApplications2 = 126,
            AANDCApplications3 = 127,
            AANDCApplications4 = 128,
            AANDCApplications5 = 129,
            Monitoring_Retries = 130,
            WindowSwitch_Sleep = 131,
            AppSwitch_Sleep = 132,
            MonitoringCycle_Sleep = 133,
            CPMLogLevel = 134,
            IsDispenserRealTimeNotificationEnabled = 135,
            IsBNARealTimeNotificationEnabled = 136,
            IsCPMRealTimeNotificationEnabled = 137,
            IsReplenishmentRealTimeNotificationEnabled = 138,
            IsOutOfCashRealTimeNotificationEnabled = 139,
            IsDispenserMismatchRealTimeNotificationEnabled = 140,
            IsBNAMismatchRealTimeNotificationEnabled = 141,
            IsCPMMismatchRealTimeNotificationEnabled = 142,
            IsCounterExplodedRealTimeNotificationEnabled = 143,
            Type1MinimumNotes = 144,
            Type2MinimumNotes = 145,
            Type3MinimumNotes = 146,
            Type4MinimumNotes = 147,
            Type5MinimumNotes = 148,
            Type6MinimumNotes = 149,
            Type7MinimumNotes = 150,
            cpm_command = 151,
            allowed_inactivity_period = 152,
            gl_number = 153,
            card_captured_cost = 154,
            escotting_cost = 155,
            replenishment_cost = 156,
            maintenance_cost = 157,
            flm_call_out_cost = 158,
            description = 159,
            is_dff_generation_halt = 160,
            cit_atm_title = 161,
            cheque_allowed_inactivity_period = 162,
            bna_allowed_inactivity_period = 163,
            out_of_cash_threshold = 164,
            no_of_dispensed_transactions_to_monitor = 165,
            is_ej_enabled = 166,
            is_counter_enabled = 167,
            priority = 168,
            longitude = 169,
            latitude = 170,
            on_us_amount = 171,
            not_on_us_amount = 172,
            standard_order_type1 = 173,
            standard_order_type2 = 174,
            standard_order_type3 = 175,
            standard_order_type4 = 176,
            standard_order_type5 = 177,
            standard_order_type6 = 178,
            standard_order_type7 = 179,
            protocol_type_id = 180,
            current_mode = 181,
            aggregate_state = 182,
            last_boot_time = 183,
            discovery_time = 184,
            last_scan_time = 185,
            communication_status = 186,
            is_critical = 187,
            current_mode_modified_on = 188,
            Last_Notification_Received_On = 189,
            Last_Notification_Time = 190,
            normal_order_cost = 191,
            emergency_order_cost = 192,
            receipt_transaction_cutoff = 193,
            is_swap_default_replenishment = 194,
            message_processor_id = 195,
            last_ping_status = 196,
            last_ping_executed_at = 197,
            last_telnet_status = 198,
            last_telnet_executed_at = 199,
            last_archive_file_received_at = 20,
            is_sdm = 201,
            initEjExecTime = 202,
            ccmsagent_last_reported_heartbeat = 203,
            ccmsservicemanager_last_reported_heartbeat = 204,
            distribution_port = 205,
            parser_rep_date_format = 206,
            type1_min_notes_threshold = 207,
            type2_min_notes_threshold = 208,
            type3_min_notes_threshold = 209,
            type4_min_notes_threshold = 210,
            type1_suggested_notes_normal_days = 211,
            type2_suggested_notes_normal_days = 212,
            type3_suggested_notes_normal_days = 213,
            type4_suggested_notes_normal_days = 214,
            type5_suggested_notes_normal_days = 215,
            type6_suggested_notes_normal_days = 216,
            type7_suggested_notes_normal_days = 217,
            type1_suggested_notes_salary_days = 218,
            type2_suggested_notes_salary_days = 219,
            type3_suggested_notes_salary_days = 220,
            type4_suggested_notes_salary_days = 221,
            type5_suggested_notes_salary_days = 222,
            type6_suggested_notes_salary_days = 223,
            type7_suggested_notes_salary_days = 224,
            avg_dispensed = 225,
            spare_cash = 226,
            dispensing_behavior = 227,
            avg_dispensed_salary_days = 228,
            inactivity_period_salary_days = 229,
            inactivity_period_normal_days = 230,
            type1_min_notes_threshold_value = 231,
            type2_min_notes_threshold_value = 232,
            type3_min_notes_threshold_value = 233,
            type4_min_notes_threshold_value = 234,
            bna_allowed_inactivity_period_normal_days = 235,
            bna_allowed_inactivity_period_salary_days = 236,
            cheque_allowed_inactivity_period_normal_days = 237,
            cheque_allowed_inactivity_period_salary_days = 238,
            min_operating_balance_normal_days = 239,
            min_operating_balance_salary_days = 240,
            is_order_auto_generated = 241,
            is_win7_machine = 242,
            is_branch_atm = 243,
            is_emirate_islamic = 244,
            is_itm = 245,
            is_bulk_cash_deposit = 246,
            is_combo = 247,
            atm_cost = 248,
            software_cost = 249,
            network_cost = 250,
            site_preparation_cost = 251,
            security_infrastructure_cost = 252,
            im_branch_code = 253,
            im_en_id = 254,
            im_location = 255,
            im_business_area = 256,
            im_circle = 257,
            cit_id = 258,
            atm_bandwidth_id = 259,
            atm_model_id = 260,
            is_recycler = 261
        }
        #endregion
        public DataTable BulkSave(List<Atm> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Atm";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Atm.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Atm> transList, ref DataTable dt)
        {
            foreach (Atm tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["aTM_id"] = ConnectionFactory.GetNextId();
                Row["last_status_reply"] = tran.LastStatusReply;
                Row["region_id"] = tran.RegionId;
                Row["title"] = tran.Title;
                Row["iP"] = tran.IP;
                Row["port"] = tran.Port;
                Row["modified_by"] = tran.ModifiedBy;
                Row["created_by"] = tran.CreatedBy;
                Row["is_active"] = tran.IsActive;
                Row["creation_time"] = tran.CreationTime;
                Row["atm_type"] = tran.AtmType;
                Row["cassette1_capacity"] = tran.Cassette1Capacity;
                Row["cassette1_denomination"] = tran.Cassette1Denomination;
                Row["cassette2_capacity"] = tran.Cassette2Capacity;
                Row["cassette2_denomination"] = tran.Cassette2Denomination;
                Row["cassette3_denomination"] = tran.Cassette3Denomination;
                Row["cassette3_capacity"] = tran.Cassette3Capacity;
                Row["cassette4_denomination"] = tran.Cassette4Denomination;
                Row["cassette4_capacity"] = tran.Cassette4Capacity;
                Row["cassette5_denomination"] = tran.Cassette5Denomination;
                Row["cassette5_capacity"] = tran.Cassette5Capacity;
                Row["cassette6_denomination"] = tran.Cassette6Denomination;
                Row["cassette6_capacity"] = tran.Cassette6Capacity;
                Row["cassette7_denomination"] = tran.Cassette7Denomination;
                Row["cassette7_capacity"] = tran.Cassette7Capacity;
                Row["last_wincor_sent"] = tran.LastWincorSent;
                Row["is_healthy"] = tran.IsHealthy;
                Row["location"] = tran.Location;
                Row["address1"] = tran.Address1;
                Row["address2"] = tran.Address2;
                Row["city"] = tran.City;
                Row["country"] = tran.Country;
                Row["zip_code"] = tran.ZipCode;
                Row["location_type"] = tran.LocationType;
                Row["service_status"] = tran.ServiceStatus;
                Row["holiday_status"] = tran.HolidayStatus;
                Row["business_days"] = tran.BusinessDays;
                Row["time_zone"] = tran.TimeZone;
                Row["max_notes_per_cassette"] = tran.MaxNotesPerCassette;
                Row["cassette1_split_percentage"] = tran.Cassette1SplitPercentage;
                Row["cassette2_split_percentage"] = tran.Cassette2SplitPercentage;
                Row["cassette3_split_percentage"] = tran.Cassette3SplitPercentage;
                Row["cassette4_split_percentage"] = tran.Cassette4SplitPercentage;
                Row["cassette5_split_percentage"] = tran.Cassette5SplitPercentage;
                Row["cassette6_split_percentage"] = tran.Cassette6SplitPercentage;
                Row["cassette7_split_percentage"] = tran.Cassette7SplitPercentage;
                Row["interest_rate"] = tran.InterestRate;
                Row["insurance_rate"] = tran.InsuranceRate;
                Row["max_holding_amount"] = tran.MaxHoldingAmount;
                Row["min_operating_balance"] = tran.MinOperatingBalance;
                Row["min_amount_for_normal_delivery"] = tran.MinAmountForNormalDelivery;
                Row["bank_cash_center_id"] = tran.BankCashCenterId;
                Row["cIT_cash_center_servicer"] = tran.CITCashCenterServicer;
                Row["depot_id"] = tran.DepotId;
                Row["secondary_depot_vault_id"] = tran.SecondaryDepotVaultId;
                Row["new_atm_scenario"] = tran.NewAtmScenario;
                Row["cash_swap_days"] = tran.CashSwapDays;
                Row["mandatory_cash_swap_days"] = tran.MandatoryCashSwapDays;
                Row["cash_swap_cycle"] = tran.CashSwapCycle;
                Row["cash_swap_lead_time"] = tran.CashSwapLeadTime;
                Row["cash_swap_start_date"] = tran.CashSwapStartDate;
                Row["cash_swap_handling_cost"] = tran.CashSwapHandlingCost;
                Row["cash_swap_costs"] = tran.CashSwapCosts;
                Row["emergency_days"] = tran.EmergencyDays;
                Row["emergency_lead_time"] = tran.EmergencyLeadTime;
                Row["emergency_cost"] = tran.EmergencyCost;
                Row["contact1_email"] = tran.Contact1Email;
                Row["contact2_email"] = tran.Contact2Email;
                Row["contact3_email"] = tran.Contact3Email;
                Row["contact1_phone"] = tran.Contact1Phone;
                Row["contact2_phone"] = tran.Contact2Phone;
                Row["contact3_phone"] = tran.Contact3Phone;
                Row["effective_date"] = tran.EffectiveDate;
                Row["suspend_cash_order"] = tran.SuspendCashOrder;
                Row["is_atm"] = tran.IsAtm;
                Row["is_cdm"] = tran.IsCdm;
                Row["is_ccdm"] = tran.IsCcdm;
                Row["cdm_cassette1_capacity"] = tran.CdmCassette1Capacity;
                Row["cdm_cassette2_capacity"] = tran.CdmCassette2Capacity;
                Row["cdm_cassette3_capacity"] = tran.CdmCassette3Capacity;
                Row["cdm_cassette4_capacity"] = tran.CdmCassette4Capacity;
                Row["ccdm_cassette1_capacity"] = tran.CcdmCassette1Capacity;
                Row["ccdm_cassette2_capacity"] = tran.CcdmCassette2Capacity;
                Row["ccdm_cassette3_capacity"] = tran.CcdmCassette3Capacity;
                Row["ccdm_cassette4_capacity"] = tran.CcdmCassette4Capacity;
                Row["cdm_cassette1_threshold"] = tran.CdmCassette1Threshold;
                Row["cdm_cassette2_threshold"] = tran.CdmCassette2Threshold;
                Row["cdm_cassette3_threshold"] = tran.CdmCassette3Threshold;
                Row["cdm_cassette4_threshold"] = tran.CdmCassette4Threshold;
                Row["ccdm_cassette1_threshold"] = tran.CcdmCassette1Threshold;
                Row["ccdm_cassette2_threshold"] = tran.CcdmCassette2Threshold;
                Row["ccdm_cassette3_threshold"] = tran.CcdmCassette3Threshold;
                Row["ccdm_cassette4_threshold"] = tran.CcdmCassette4Threshold;
                Row["note_set_type_id"] = tran.NoteSetTypeId;
                Row["ccdm_cassette5_capacity"] = tran.CcdmCassette5Capacity;
                Row["ccdm_cassette5_threshold"] = tran.CcdmCassette5Threshold;
                Row["startup_sleep_interval"] = tran.StartupSleepInterval;
                Row["debug_level"] = tran.DebugLevel;
                Row["exclude_dff"] = tran.ExcludeDff;
                Row["purge1_threshold"] = tran.Purge1Threshold;
                Row["is_purge1_threshold_selected"] = tran.IsPurge1ThresholdSelected;
                Row["purge2_threshold"] = tran.Purge2Threshold;
                Row["is_purge2_threshold_selected"] = tran.IsPurge2ThresholdSelected;
                Row["purge3_threshold"] = tran.Purge3Threshold;
                Row["is_purge3_threshold_selected"] = tran.IsPurge3ThresholdSelected;
                Row["purge4_threshold"] = tran.Purge4Threshold;
                Row["is_purge4_threshold_selected"] = tran.IsPurge4ThresholdSelected;
                Row["purge5_threshold"] = tran.Purge5Threshold;
                Row["is_purge5_threshold_selected"] = tran.IsPurge5ThresholdSelected;
                Row["purge6_threshold"] = tran.Purge6Threshold;
                Row["is_purge6_threshold_selected"] = tran.IsPurge6ThresholdSelected;
                Row["purge7_threshold"] = tran.Purge7Threshold;
                Row["is_purge7_threshold_selected"] = tran.IsPurge7ThresholdSelected;
                Row["retry_count_cash_order_upload"] = tran.RetryCountCashOrderUpload;
                Row["retry_count_conf_upload"] = tran.RetryCountConfUpload;
                Row["retry_count_counter_file"] = tran.RetryCountCounterFile;
                Row["retry_count_restart_schedule"] = tran.RetryCountRestartSchedule;
                Row["retry_count_datetime_schedule"] = tran.RetryCountDatetimeSchedule;
                Row["retry_count_alert"] = tran.RetryCountAlert;
                Row["countsClearRetries"] = tran.CountsClearRetries;
                Row["tCPTimeout"] = tran.TCPTimeout;
                Row["sleepInterval"] = tran.SleepInterval;
                Row["cPMCommandWait"] = tran.CPMCommandWait;
                Row["cPMCommandSleep"] = tran.CPMCommandSleep;
                Row["aANDCApplications1"] = tran.AANDCApplications1;
                Row["aANDCApplications2"] = tran.AANDCApplications2;
                Row["aANDCApplications3"] = tran.AANDCApplications3;
                Row["aANDCApplications4"] = tran.AANDCApplications4;
                Row["aANDCApplications5"] = tran.AANDCApplications5;
                Row["monitoring_Retries"] = tran.MonitoringRetries;
                Row["windowSwitch_Sleep"] = tran.WindowSwitchSleep;
                Row["appSwitch_Sleep"] = tran.AppSwitchSleep;
                Row["monitoringCycle_Sleep"] = tran.MonitoringCycleSleep;
                Row["cPMLogLevel"] = tran.CPMLogLevel;
                Row["isDispenserRealTimeNotificationEnabled"] = tran.IsDispenserRealTimeNotificationEnabled;
                Row["isBNARealTimeNotificationEnabled"] = tran.IsBNARealTimeNotificationEnabled;
                Row["isCPMRealTimeNotificationEnabled"] = tran.IsCPMRealTimeNotificationEnabled;
                Row["isReplenishmentRealTimeNotificationEnabled"] = tran.IsReplenishmentRealTimeNotificationEnabled;
                Row["isOutOfCashRealTimeNotificationEnabled"] = tran.IsOutOfCashRealTimeNotificationEnabled;
                Row["isDispenserMismatchRealTimeNotificationEnabled"] = tran.IsDispenserMismatchRealTimeNotificationEnabled;
                Row["isBNAMismatchRealTimeNotificationEnabled"] = tran.IsBNAMismatchRealTimeNotificationEnabled;
                Row["isCPMMismatchRealTimeNotificationEnabled"] = tran.IsCPMMismatchRealTimeNotificationEnabled;
                Row["isCounterExplodedRealTimeNotificationEnabled"] = tran.IsCounterExplodedRealTimeNotificationEnabled;
                Row["type1MinimumNotes"] = tran.Type1MinimumNotes;
                Row["type2MinimumNotes"] = tran.Type2MinimumNotes;
                Row["type3MinimumNotes"] = tran.Type3MinimumNotes;
                Row["type4MinimumNotes"] = tran.Type4MinimumNotes;
                Row["type5MinimumNotes"] = tran.Type5MinimumNotes;
                Row["type6MinimumNotes"] = tran.Type6MinimumNotes;
                Row["type7MinimumNotes"] = tran.Type7MinimumNotes;
                Row["cpm_command"] = tran.CpmCommand;
                Row["allowed_inactivity_period"] = tran.AllowedInactivityPeriod;
                Row["gl_number"] = tran.GlNumber;
                Row["card_captured_cost"] = tran.CardCapturedCost;
                Row["escotting_cost"] = tran.EscottingCost;
                Row["replenishment_cost"] = tran.ReplenishmentCost;
                Row["maintenance_cost"] = tran.MaintenanceCost;
                Row["flm_call_out_cost"] = tran.FlmCallOutCost;
                Row["description"] = tran.Description;
                Row["is_dff_generation_halt"] = tran.IsDffGenerationHalt;
                Row["cit_atm_title"] = tran.CitAtmTitle;
                Row["cheque_allowed_inactivity_period"] = tran.ChequeAllowedInactivityPeriod;
                Row["bna_allowed_inactivity_period"] = tran.BnaAllowedInactivityPeriod;
                Row["out_of_cash_threshold"] = tran.OutOfCashThreshold;
                Row["no_of_dispensed_transactions_to_monitor"] = tran.NoOfDispensedTransactionsToMonitor;
                Row["is_ej_enabled"] = tran.IsEjEnabled;
                Row["is_counter_enabled"] = tran.IsCounterEnabled;
                Row["priority"] = tran.Priority;
                Row["longitude"] = tran.Longitude;
                Row["latitude"] = tran.Latitude;
                Row["on_us_amount"] = tran.OnUsAmount;
                Row["not_on_us_amount"] = tran.NotOnUsAmount;
                Row["standard_order_type1"] = tran.StandardOrderType1;
                Row["standard_order_type2"] = tran.StandardOrderType2;
                Row["standard_order_type3"] = tran.StandardOrderType3;
                Row["standard_order_type4"] = tran.StandardOrderType4;
                Row["standard_order_type5"] = tran.StandardOrderType5;
                Row["standard_order_type6"] = tran.StandardOrderType6;
                Row["standard_order_type7"] = tran.StandardOrderType7;
                Row["protocol_type_id"] = tran.ProtocolTypeId;
                Row["current_mode"] = tran.CurrentMode;
                Row["aggregate_state"] = tran.AggregateState;
                Row["last_boot_time"] = tran.LastBootTime;
                Row["discovery_time"] = tran.DiscoveryTime;
                Row["last_scan_time"] = tran.LastScanTime;
                Row["communication_status"] = tran.CommunicationStatus;
                Row["is_critical"] = tran.IsCritical;
                Row["current_mode_modified_on"] = tran.CurrentModeModifiedOn;
                Row["last_Notification_Received_On"] = tran.LastNotificationReceivedOn;
                Row["last_Notification_Time"] = tran.LastNotificationTime;
                Row["normal_order_cost"] = tran.NormalOrderCost;
                Row["emergency_order_cost"] = tran.EmergencyOrderCost;
                Row["receipt_transaction_cutoff"] = tran.ReceiptTransactionCutoff;
                Row["is_swap_default_replenishment"] = tran.IsSwapDefaultReplenishment;
                Row["message_processor_id"] = tran.MessageProcessorId;
                Row["last_ping_status"] = tran.LastPingStatus;
                Row["last_ping_executed_at"] = tran.LastPingExecutedAt;
                Row["last_telnet_status"] = tran.LastTelnetStatus;
                Row["last_telnet_executed_at"] = tran.LastTelnetExecutedAt;
                Row["last_archive_file_received_at"] = tran.LastArchiveFileReceivedAt;
                Row["is_sdm"] = tran.IsSdm;
                Row["initEjExecTime"] = tran.InitEjExecTime;
                Row["ccmsagent_last_reported_heartbeat"] = tran.CcmsagentLastReportedHeartbeat;
                Row["ccmsservicemanager_last_reported_heartbeat"] = tran.CcmsservicemanagerLastReportedHeartbeat;
                Row["distribution_port"] = tran.DistributionPort;
                Row["parser_rep_date_format"] = tran.ParserRepDateFormat;
                Row["type1_min_notes_threshold"] = tran.Type1MinNotesThreshold;
                Row["type2_min_notes_threshold"] = tran.Type2MinNotesThreshold;
                Row["type3_min_notes_threshold"] = tran.Type3MinNotesThreshold;
                Row["type4_min_notes_threshold"] = tran.Type4MinNotesThreshold;
                Row["type1_suggested_notes_normal_days"] = tran.Type1SuggestedNotesNormalDays;
                Row["type2_suggested_notes_normal_days"] = tran.Type2SuggestedNotesNormalDays;
                Row["type3_suggested_notes_normal_days"] = tran.Type3SuggestedNotesNormalDays;
                Row["type4_suggested_notes_normal_days"] = tran.Type4SuggestedNotesNormalDays;
                Row["type5_suggested_notes_normal_days"] = tran.Type5SuggestedNotesNormalDays;
                Row["type6_suggested_notes_normal_days"] = tran.Type6SuggestedNotesNormalDays;
                Row["type7_suggested_notes_normal_days"] = tran.Type7SuggestedNotesNormalDays;
                Row["type1_suggested_notes_salary_days"] = tran.Type1SuggestedNotesSalaryDays;
                Row["type2_suggested_notes_salary_days"] = tran.Type2SuggestedNotesSalaryDays;
                Row["type3_suggested_notes_salary_days"] = tran.Type3SuggestedNotesSalaryDays;
                Row["type4_suggested_notes_salary_days"] = tran.Type4SuggestedNotesSalaryDays;
                Row["type5_suggested_notes_salary_days"] = tran.Type5SuggestedNotesSalaryDays;
                Row["type6_suggested_notes_salary_days"] = tran.Type6SuggestedNotesSalaryDays;
                Row["type7_suggested_notes_salary_days"] = tran.Type7SuggestedNotesSalaryDays;
                Row["avg_dispensed"] = tran.AvgDispensed;
                Row["spare_cash"] = tran.SpareCash;
                Row["dispensing_behavior"] = tran.DispensingBehavior;
                Row["avg_dispensed_salary_days"] = tran.AvgDispensedSalaryDays;
                Row["inactivity_period_salary_days"] = tran.InactivityPeriodSalaryDays;
                Row["inactivity_period_normal_days"] = tran.InactivityPeriodNormalDays;
                Row["type1_min_notes_threshold_value"] = tran.Type1MinNotesThresholdValue;
                Row["type2_min_notes_threshold_value"] = tran.Type2MinNotesThresholdValue;
                Row["type3_min_notes_threshold_value"] = tran.Type3MinNotesThresholdValue;
                Row["type4_min_notes_threshold_value"] = tran.Type4MinNotesThresholdValue;
                Row["bna_allowed_inactivity_period_normal_days"] = tran.BnaAllowedInactivityPeriodNormalDays;
                Row["bna_allowed_inactivity_period_salary_days"] = tran.BnaAllowedInactivityPeriodSalaryDays;
                Row["cheque_allowed_inactivity_period_normal_days"] = tran.ChequeAllowedInactivityPeriodNormalDays;
                Row["cheque_allowed_inactivity_period_salary_days"] = tran.ChequeAllowedInactivityPeriodSalaryDays;
                Row["min_operating_balance_normal_days"] = tran.MinOperatingBalanceNormalDays;
                Row["min_operating_balance_salary_days"] = tran.MinOperatingBalanceSalaryDays;
                Row["is_order_auto_generated"] = tran.IsOrderAutoGenerated;
                Row["is_win7_machine"] = tran.IsWin7Machine;
                Row["is_branch_atm"] = tran.IsBranchAtm;
                Row["is_emirate_islamic"] = tran.IsEmirateIslamic;
                Row["is_itm"] = tran.IsItm;
                Row["is_bulk_cash_deposit"] = tran.IsBulkCashDeposit;
                Row["is_combo"] = tran.IsCombo;
                Row["atm_cost"] = tran.AtmCost;
                Row["software_cost"] = tran.SoftwareCost;
                Row["network_cost"] = tran.NetworkCost;
                Row["site_preparation_cost"] = tran.SitePreparationCost;
                Row["security_infrastructure_cost"] = tran.SecurityInfrastructureCost;
                Row["im_branch_code"] = tran.ImBranchCode;
                Row["im_en_id"] = tran.ImEnId;
                Row["im_location"] = tran.ImLocation;
                Row["im_business_area"] = tran.ImBusinessArea;
                Row["im_circle"] = tran.ImCircle;
                Row["cit_id"] = tran.CitId;
                Row["atm_bandwidth_id"] = tran.AtmBandwidthId;
                Row["atm_model_id"] = tran.AtmModelId;
                Row["is_recycler"] = tran.IsRecycler;
                dt.Rows.Add(Row);
            }
        }
    }
}