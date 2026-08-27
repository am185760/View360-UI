

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
        public Atm(int aTM_id, int region_id, string title, string iP, int port, int created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, DateTime last_wincor_sent, bool is_healthy, bool suspend_cash_order, int note_set_type_id, int retry_count_cash_order_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int retry_count_alert, int countsClearRetries, int tCPTimeout, int sleepInterval, int cPMCommandWait, int cPMCommandSleep, string aANDCApplications1, string aANDCApplications2, string aANDCApplications3, string aANDCApplications4, string aANDCApplications5, int monitoring_Retries, int windowSwitch_Sleep, int appSwitch_Sleep, int monitoringCycle_Sleep, int cPMLogLevel, bool isDispenserRealTimeNotificationEnabled, bool isBNARealTimeNotificationEnabled, bool isCPMRealTimeNotificationEnabled, bool isReplenishmentRealTimeNotificationEnabled, bool isOutOfCashRealTimeNotificationEnabled, bool isDispenserMismatchRealTimeNotificationEnabled, bool isBNAMismatchRealTimeNotificationEnabled, bool isCPMMismatchRealTimeNotificationEnabled, bool isCounterExplodedRealTimeNotificationEnabled, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, int out_of_cash_threshold, bool is_ej_enabled, bool is_counter_enabled, int priority, int protocol_type_id, byte current_mode, byte aggregate_state, byte communication_status, bool is_critical)
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
        }
        public Atm(string last_status_reply, int region_id, string title, string iP, int port, int? modified_by, int created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, DateTime last_wincor_sent, bool is_healthy, string location, string address1, string address2, string city, string country, string zip_code, string location_type, string service_status, string holiday_status, string business_days, int? time_zone, int? max_notes_per_cassette, int? cassette1_split_percentage, int? cassette2_split_percentage, int? cassette3_split_percentage, int? cassette4_split_percentage, int? cassette5_split_percentage, int? cassette6_split_percentage, int? cassette7_split_percentage, decimal? interest_rate, decimal? insurance_rate, decimal? max_holding_amount, decimal? min_operating_balance, decimal? min_amount_for_normal_delivery, string bank_cash_center_id, string cIT_cash_center_servicer, string depot_id, string secondary_depot_vault_id, string new_atm_scenario, string cash_swap_days, string mandatory_cash_swap_days, int? cash_swap_cycle, int? cash_swap_lead_time, DateTime? cash_swap_start_date, decimal? cash_swap_handling_cost, decimal? cash_swap_costs, string emergency_days, int? emergency_lead_time, decimal? emergency_cost, string contact1_email, string contact2_email, string contact3_email, string contact1_phone, string contact2_phone, string contact3_phone, DateTime? effective_date, bool suspend_cash_order, bool? is_atm, bool? is_cdm, bool? is_ccdm, int? cdm_cassette1_capacity, int? cdm_cassette2_capacity, int? cdm_cassette3_capacity, int? cdm_cassette4_capacity, int? ccdm_cassette1_capacity, int? ccdm_cassette2_capacity, int? ccdm_cassette3_capacity, int? ccdm_cassette4_capacity, int? cdm_cassette1_threshold, int? cdm_cassette2_threshold, int? cdm_cassette3_threshold, int? cdm_cassette4_threshold, int? ccdm_cassette1_threshold, int? ccdm_cassette2_threshold, int? ccdm_cassette3_threshold, int? ccdm_cassette4_threshold, int note_set_type_id, int? ccdm_cassette5_capacity, int? ccdm_cassette5_threshold, int? startup_sleep_interval, byte? debug_level, bool? exclude_dff, int? purge1_threshold, bool? is_purge1_threshold_selected, int? purge2_threshold, bool? is_purge2_threshold_selected, int? purge3_threshold, bool? is_purge3_threshold_selected, int? purge4_threshold, bool? is_purge4_threshold_selected, int? purge5_threshold, bool? is_purge5_threshold_selected, int? purge6_threshold, bool? is_purge6_threshold_selected, int? purge7_threshold, bool? is_purge7_threshold_selected, int retry_count_cash_order_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int retry_count_alert, int countsClearRetries, int tCPTimeout, int sleepInterval, int cPMCommandWait, int cPMCommandSleep, string aANDCApplications1, string aANDCApplications2, string aANDCApplications3, string aANDCApplications4, string aANDCApplications5, int monitoring_Retries, int windowSwitch_Sleep, int appSwitch_Sleep, int monitoringCycle_Sleep, int cPMLogLevel, bool isDispenserRealTimeNotificationEnabled, bool isBNARealTimeNotificationEnabled, bool isCPMRealTimeNotificationEnabled, bool isReplenishmentRealTimeNotificationEnabled, bool isOutOfCashRealTimeNotificationEnabled, bool isDispenserMismatchRealTimeNotificationEnabled, bool isBNAMismatchRealTimeNotificationEnabled, bool isCPMMismatchRealTimeNotificationEnabled, bool isCounterExplodedRealTimeNotificationEnabled, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, string cpm_command, int? allowed_inactivity_period, string gl_number, decimal? card_captured_cost, decimal? escotting_cost, decimal? replenishment_cost, decimal? maintenance_cost, decimal? flm_call_out_cost, string description, bool? is_dff_generation_halt, string cit_atm_title, int? cheque_allowed_inactivity_period, int? bna_allowed_inactivity_period, int out_of_cash_threshold, int? no_of_dispensed_transactions_to_monitor, bool is_ej_enabled, bool is_counter_enabled, int priority, string longitude, string latitude, decimal? on_us_amount, decimal? not_on_us_amount, int? standard_order_type1, int? standard_order_type2, int? standard_order_type3, int? standard_order_type4, int? standard_order_type5, int? standard_order_type6, int? standard_order_type7, int protocol_type_id, byte current_mode, byte aggregate_state, DateTime? last_boot_time, DateTime? discovery_time, DateTime? last_scan_time, byte communication_status, bool is_critical, DateTime? current_mode_modified_on, DateTime? last_Notification_Received_On, DateTime? last_Notification_Time, decimal? normal_order_cost, decimal? emergency_order_cost, int? receipt_transaction_cutoff, bool? is_swap_default_replenishment, int? message_processor_id)
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
        }
        private Atm(int aTM_id, string last_status_reply, int region_id, string title, string iP, int port, int? modified_by, int created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, DateTime last_wincor_sent, bool is_healthy, string location, string address1, string address2, string city, string country, string zip_code, string location_type, string service_status, string holiday_status, string business_days, int? time_zone, int? max_notes_per_cassette, int? cassette1_split_percentage, int? cassette2_split_percentage, int? cassette3_split_percentage, int? cassette4_split_percentage, int? cassette5_split_percentage, int? cassette6_split_percentage, int? cassette7_split_percentage, decimal? interest_rate, decimal? insurance_rate, decimal? max_holding_amount, decimal? min_operating_balance, decimal? min_amount_for_normal_delivery, string bank_cash_center_id, string cIT_cash_center_servicer, string depot_id, string secondary_depot_vault_id, string new_atm_scenario, string cash_swap_days, string mandatory_cash_swap_days, int? cash_swap_cycle, int? cash_swap_lead_time, DateTime? cash_swap_start_date, decimal? cash_swap_handling_cost, decimal? cash_swap_costs, string emergency_days, int? emergency_lead_time, decimal? emergency_cost, string contact1_email, string contact2_email, string contact3_email, string contact1_phone, string contact2_phone, string contact3_phone, DateTime? effective_date, bool suspend_cash_order, bool? is_atm, bool? is_cdm, bool? is_ccdm, int? cdm_cassette1_capacity, int? cdm_cassette2_capacity, int? cdm_cassette3_capacity, int? cdm_cassette4_capacity, int? ccdm_cassette1_capacity, int? ccdm_cassette2_capacity, int? ccdm_cassette3_capacity, int? ccdm_cassette4_capacity, int? cdm_cassette1_threshold, int? cdm_cassette2_threshold, int? cdm_cassette3_threshold, int? cdm_cassette4_threshold, int? ccdm_cassette1_threshold, int? ccdm_cassette2_threshold, int? ccdm_cassette3_threshold, int? ccdm_cassette4_threshold, int note_set_type_id, int? ccdm_cassette5_capacity, int? ccdm_cassette5_threshold, int? startup_sleep_interval, byte? debug_level, bool? exclude_dff, int? purge1_threshold, bool? is_purge1_threshold_selected, int? purge2_threshold, bool? is_purge2_threshold_selected, int? purge3_threshold, bool? is_purge3_threshold_selected, int? purge4_threshold, bool? is_purge4_threshold_selected, int? purge5_threshold, bool? is_purge5_threshold_selected, int? purge6_threshold, bool? is_purge6_threshold_selected, int? purge7_threshold, bool? is_purge7_threshold_selected, int retry_count_cash_order_upload, int retry_count_conf_upload, int retry_count_counter_file, int retry_count_restart_schedule, int retry_count_datetime_schedule, int retry_count_alert, int countsClearRetries, int tCPTimeout, int sleepInterval, int cPMCommandWait, int cPMCommandSleep, string aANDCApplications1, string aANDCApplications2, string aANDCApplications3, string aANDCApplications4, string aANDCApplications5, int monitoring_Retries, int windowSwitch_Sleep, int appSwitch_Sleep, int monitoringCycle_Sleep, int cPMLogLevel, bool isDispenserRealTimeNotificationEnabled, bool isBNARealTimeNotificationEnabled, bool isCPMRealTimeNotificationEnabled, bool isReplenishmentRealTimeNotificationEnabled, bool isOutOfCashRealTimeNotificationEnabled, bool isDispenserMismatchRealTimeNotificationEnabled, bool isBNAMismatchRealTimeNotificationEnabled, bool isCPMMismatchRealTimeNotificationEnabled, bool isCounterExplodedRealTimeNotificationEnabled, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, string cpm_command, int? allowed_inactivity_period, string gl_number, decimal? card_captured_cost, decimal? escotting_cost, decimal? replenishment_cost, decimal? maintenance_cost, decimal? flm_call_out_cost, string description, bool? is_dff_generation_halt, string cit_atm_title, int? cheque_allowed_inactivity_period, int? bna_allowed_inactivity_period, int out_of_cash_threshold, int? no_of_dispensed_transactions_to_monitor, bool is_ej_enabled, bool is_counter_enabled, int priority, string longitude, string latitude, decimal? on_us_amount, decimal? not_on_us_amount, int? standard_order_type1, int? standard_order_type2, int? standard_order_type3, int? standard_order_type4, int? standard_order_type5, int? standard_order_type6, int? standard_order_type7, int protocol_type_id, byte current_mode, byte aggregate_state, DateTime? last_boot_time, DateTime? discovery_time, DateTime? last_scan_time, byte communication_status, bool is_critical, DateTime? current_mode_modified_on, DateTime? last_Notification_Received_On, DateTime? last_Notification_Time, decimal? normal_order_cost, decimal? emergency_order_cost, int? receipt_transaction_cutoff, bool? is_swap_default_replenishment, int? message_processor_id)
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
        #endregion

        #region AtmReader
        public class AtmReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Atm currentAtm;
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
            cmd.CommandText = "Select ATM_id,last_status_reply,region_id,title,IP,port,modified_by,created_by,is_active,creation_time,atm_type,cassette1_capacity,cassette1_denomination,cassette2_capacity,cassette2_denomination,cassette3_denomination,cassette3_capacity,cassette4_denomination,cassette4_capacity,cassette5_denomination,cassette5_capacity,cassette6_denomination,cassette6_capacity,cassette7_denomination,cassette7_capacity,last_wincor_sent,is_healthy,location,address1,address2,city,country,zip_code,location_type,service_status,holiday_status,business_days,time_zone,max_notes_per_cassette,cassette1_split_percentage,cassette2_split_percentage,cassette3_split_percentage,cassette4_split_percentage,cassette5_split_percentage,cassette6_split_percentage,cassette7_split_percentage,interest_rate,insurance_rate,max_holding_amount,min_operating_balance,min_amount_for_normal_delivery,bank_cash_center_id,CIT_cash_center_servicer,depot_id,secondary_depot_vault_id,new_atm_scenario,cash_swap_days,mandatory_cash_swap_days,cash_swap_cycle,cash_swap_lead_time,cash_swap_start_date,cash_swap_handling_cost,cash_swap_costs,emergency_days,emergency_lead_time,emergency_cost,contact1_email,contact2_email,contact3_email,contact1_phone,contact2_phone,contact3_phone,effective_date,suspend_cash_order,is_atm,is_cdm,is_ccdm,cdm_cassette1_capacity,cdm_cassette2_capacity,cdm_cassette3_capacity,cdm_cassette4_capacity,ccdm_cassette1_capacity,ccdm_cassette2_capacity,ccdm_cassette3_capacity,ccdm_cassette4_capacity,cdm_cassette1_threshold,cdm_cassette2_threshold,cdm_cassette3_threshold,cdm_cassette4_threshold,ccdm_cassette1_threshold,ccdm_cassette2_threshold,ccdm_cassette3_threshold,ccdm_cassette4_threshold,note_set_type_id,ccdm_cassette5_capacity,ccdm_cassette5_threshold,startup_sleep_interval,debug_level,exclude_dff,purge1_threshold,is_purge1_threshold_selected,purge2_threshold,is_purge2_threshold_selected,purge3_threshold,is_purge3_threshold_selected,purge4_threshold,is_purge4_threshold_selected,purge5_threshold,is_purge5_threshold_selected,purge6_threshold,is_purge6_threshold_selected,purge7_threshold,is_purge7_threshold_selected,retry_count_cash_order_upload,retry_count_conf_upload,retry_count_counter_file,retry_count_restart_schedule,retry_count_datetime_schedule,retry_count_alert,CountsClearRetries,TCPTimeout,SleepInterval,CPMCommandWait,CPMCommandSleep,AANDCApplications1,AANDCApplications2,AANDCApplications3,AANDCApplications4,AANDCApplications5,Monitoring_Retries,WindowSwitch_Sleep,AppSwitch_Sleep,MonitoringCycle_Sleep,CPMLogLevel,IsDispenserRealTimeNotificationEnabled,IsBNARealTimeNotificationEnabled,IsCPMRealTimeNotificationEnabled,IsReplenishmentRealTimeNotificationEnabled,IsOutOfCashRealTimeNotificationEnabled,IsDispenserMismatchRealTimeNotificationEnabled,IsBNAMismatchRealTimeNotificationEnabled,IsCPMMismatchRealTimeNotificationEnabled,IsCounterExplodedRealTimeNotificationEnabled,Type1MinimumNotes,Type2MinimumNotes,Type3MinimumNotes,Type4MinimumNotes,Type5MinimumNotes,Type6MinimumNotes,Type7MinimumNotes,cpm_command,allowed_inactivity_period,gl_number,card_captured_cost,escotting_cost,replenishment_cost,maintenance_cost,flm_call_out_cost,description,is_dff_generation_halt,cit_atm_title,cheque_allowed_inactivity_period,bna_allowed_inactivity_period,out_of_cash_threshold,no_of_dispensed_transactions_to_monitor,is_ej_enabled,is_counter_enabled,priority,longitude,latitude,on_us_amount,not_on_us_amount,standard_order_type1,standard_order_type2,standard_order_type3,standard_order_type4,standard_order_type5,standard_order_type6,standard_order_type7,protocol_type_id,current_mode,aggregate_state,last_boot_time,discovery_time,last_scan_time,communication_status,is_critical,current_mode_modified_on,Last_Notification_Received_On,Last_Notification_Time,normal_order_cost,emergency_order_cost,receipt_transaction_cutoff,is_swap_default_replenishment,message_processor_id from Atm ";
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
            return LoadAtm(" ATM_id=" + aTM_id);
        }

        public static Atm LoadAtmByPk(int aTM_id, IDbConnection conn)
        {
            return LoadAtm(" ATM_id=" + aTM_id, conn);
        }

        public void Save()
        {
            if (aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || last_wincor_sentChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || zip_codeChanged || location_typeChanged || service_statusChanged || holiday_statusChanged || business_daysChanged || time_zoneChanged || max_notes_per_cassetteChanged || cassette1_split_percentageChanged || cassette2_split_percentageChanged || cassette3_split_percentageChanged || cassette4_split_percentageChanged || cassette5_split_percentageChanged || cassette6_split_percentageChanged || cassette7_split_percentageChanged || interest_rateChanged || insurance_rateChanged || max_holding_amountChanged || min_operating_balanceChanged || min_amount_for_normal_deliveryChanged || bank_cash_center_idChanged || cIT_cash_center_servicerChanged || depot_idChanged || secondary_depot_vault_idChanged || new_atm_scenarioChanged || cash_swap_daysChanged || mandatory_cash_swap_daysChanged || cash_swap_cycleChanged || cash_swap_lead_timeChanged || cash_swap_start_dateChanged || cash_swap_handling_costChanged || cash_swap_costsChanged || emergency_daysChanged || emergency_lead_timeChanged || emergency_costChanged || contact1_emailChanged || contact2_emailChanged || contact3_emailChanged || contact1_phoneChanged || contact2_phoneChanged || contact3_phoneChanged || effective_dateChanged || suspend_cash_orderChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || exclude_dffChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_cash_order_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || retry_count_alertChanged || countsClearRetriesChanged || tCPTimeoutChanged || sleepIntervalChanged || cPMCommandWaitChanged || cPMCommandSleepChanged || aANDCApplications1Changed || aANDCApplications2Changed || aANDCApplications3Changed || aANDCApplications4Changed || aANDCApplications5Changed || monitoring_RetriesChanged || windowSwitch_SleepChanged || appSwitch_SleepChanged || monitoringCycle_SleepChanged || cPMLogLevelChanged || isDispenserRealTimeNotificationEnabledChanged || isBNARealTimeNotificationEnabledChanged || isCPMRealTimeNotificationEnabledChanged || isReplenishmentRealTimeNotificationEnabledChanged || isOutOfCashRealTimeNotificationEnabledChanged || isDispenserMismatchRealTimeNotificationEnabledChanged || isBNAMismatchRealTimeNotificationEnabledChanged || isCPMMismatchRealTimeNotificationEnabledChanged || isCounterExplodedRealTimeNotificationEnabledChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || cpm_commandChanged || allowed_inactivity_periodChanged || gl_numberChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || descriptionChanged || is_dff_generation_haltChanged || cit_atm_titleChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || no_of_dispensed_transactions_to_monitorChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || longitudeChanged || latitudeChanged || on_us_amountChanged || not_on_us_amountChanged || standard_order_type1Changed || standard_order_type2Changed || standard_order_type3Changed || standard_order_type4Changed || standard_order_type5Changed || standard_order_type6Changed || standard_order_type7Changed || protocol_type_idChanged || current_modeChanged || aggregate_stateChanged || last_boot_timeChanged || discovery_timeChanged || last_scan_timeChanged || communication_statusChanged || is_criticalChanged || current_mode_modified_onChanged || last_Notification_Received_OnChanged || last_Notification_TimeChanged || normal_order_costChanged || emergency_order_costChanged || receipt_transaction_cutoffChanged || is_swap_default_replenishmentChanged || message_processor_idChanged)
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
            if (aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || last_wincor_sentChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || zip_codeChanged || location_typeChanged || service_statusChanged || holiday_statusChanged || business_daysChanged || time_zoneChanged || max_notes_per_cassetteChanged || cassette1_split_percentageChanged || cassette2_split_percentageChanged || cassette3_split_percentageChanged || cassette4_split_percentageChanged || cassette5_split_percentageChanged || cassette6_split_percentageChanged || cassette7_split_percentageChanged || interest_rateChanged || insurance_rateChanged || max_holding_amountChanged || min_operating_balanceChanged || min_amount_for_normal_deliveryChanged || bank_cash_center_idChanged || cIT_cash_center_servicerChanged || depot_idChanged || secondary_depot_vault_idChanged || new_atm_scenarioChanged || cash_swap_daysChanged || mandatory_cash_swap_daysChanged || cash_swap_cycleChanged || cash_swap_lead_timeChanged || cash_swap_start_dateChanged || cash_swap_handling_costChanged || cash_swap_costsChanged || emergency_daysChanged || emergency_lead_timeChanged || emergency_costChanged || contact1_emailChanged || contact2_emailChanged || contact3_emailChanged || contact1_phoneChanged || contact2_phoneChanged || contact3_phoneChanged || effective_dateChanged || suspend_cash_orderChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || exclude_dffChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_cash_order_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || retry_count_alertChanged || countsClearRetriesChanged || tCPTimeoutChanged || sleepIntervalChanged || cPMCommandWaitChanged || cPMCommandSleepChanged || aANDCApplications1Changed || aANDCApplications2Changed || aANDCApplications3Changed || aANDCApplications4Changed || aANDCApplications5Changed || monitoring_RetriesChanged || windowSwitch_SleepChanged || appSwitch_SleepChanged || monitoringCycle_SleepChanged || cPMLogLevelChanged || isDispenserRealTimeNotificationEnabledChanged || isBNARealTimeNotificationEnabledChanged || isCPMRealTimeNotificationEnabledChanged || isReplenishmentRealTimeNotificationEnabledChanged || isOutOfCashRealTimeNotificationEnabledChanged || isDispenserMismatchRealTimeNotificationEnabledChanged || isBNAMismatchRealTimeNotificationEnabledChanged || isCPMMismatchRealTimeNotificationEnabledChanged || isCounterExplodedRealTimeNotificationEnabledChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || cpm_commandChanged || allowed_inactivity_periodChanged || gl_numberChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || descriptionChanged || is_dff_generation_haltChanged || cit_atm_titleChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || no_of_dispensed_transactions_to_monitorChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || longitudeChanged || latitudeChanged || on_us_amountChanged || not_on_us_amountChanged || standard_order_type1Changed || standard_order_type2Changed || standard_order_type3Changed || standard_order_type4Changed || standard_order_type5Changed || standard_order_type6Changed || standard_order_type7Changed || protocol_type_idChanged || current_modeChanged || aggregate_stateChanged || last_boot_timeChanged || discovery_timeChanged || last_scan_timeChanged || communication_statusChanged || is_criticalChanged || current_mode_modified_onChanged || last_Notification_Received_OnChanged || last_Notification_TimeChanged || normal_order_costChanged || emergency_order_costChanged || receipt_transaction_cutoffChanged || is_swap_default_replenishmentChanged || message_processor_idChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm( ATM_id,last_status_reply,region_id,title,IP,port,modified_by,created_by,is_active,creation_time,atm_type,cassette1_capacity,cassette1_denomination,cassette2_capacity,cassette2_denomination,cassette3_denomination,cassette3_capacity,cassette4_denomination,cassette4_capacity,cassette5_denomination,cassette5_capacity,cassette6_denomination,cassette6_capacity,cassette7_denomination,cassette7_capacity,last_wincor_sent,is_healthy,location,address1,address2,city,country,zip_code,location_type,service_status,holiday_status,business_days,time_zone,max_notes_per_cassette,cassette1_split_percentage,cassette2_split_percentage,cassette3_split_percentage,cassette4_split_percentage,cassette5_split_percentage,cassette6_split_percentage,cassette7_split_percentage,interest_rate,insurance_rate,max_holding_amount,min_operating_balance,min_amount_for_normal_delivery,bank_cash_center_id,CIT_cash_center_servicer,depot_id,secondary_depot_vault_id,new_atm_scenario,cash_swap_days,mandatory_cash_swap_days,cash_swap_cycle,cash_swap_lead_time,cash_swap_start_date,cash_swap_handling_cost,cash_swap_costs,emergency_days,emergency_lead_time,emergency_cost,contact1_email,contact2_email,contact3_email,contact1_phone,contact2_phone,contact3_phone,effective_date,suspend_cash_order,is_atm,is_cdm,is_ccdm,cdm_cassette1_capacity,cdm_cassette2_capacity,cdm_cassette3_capacity,cdm_cassette4_capacity,ccdm_cassette1_capacity,ccdm_cassette2_capacity,ccdm_cassette3_capacity,ccdm_cassette4_capacity,cdm_cassette1_threshold,cdm_cassette2_threshold,cdm_cassette3_threshold,cdm_cassette4_threshold,ccdm_cassette1_threshold,ccdm_cassette2_threshold,ccdm_cassette3_threshold,ccdm_cassette4_threshold,note_set_type_id,ccdm_cassette5_capacity,ccdm_cassette5_threshold,startup_sleep_interval,debug_level,exclude_dff,purge1_threshold,is_purge1_threshold_selected,purge2_threshold,is_purge2_threshold_selected,purge3_threshold,is_purge3_threshold_selected,purge4_threshold,is_purge4_threshold_selected,purge5_threshold,is_purge5_threshold_selected,purge6_threshold,is_purge6_threshold_selected,purge7_threshold,is_purge7_threshold_selected,retry_count_cash_order_upload,retry_count_conf_upload,retry_count_counter_file,retry_count_restart_schedule,retry_count_datetime_schedule,retry_count_alert,CountsClearRetries,TCPTimeout,SleepInterval,CPMCommandWait,CPMCommandSleep,AANDCApplications1,AANDCApplications2,AANDCApplications3,AANDCApplications4,AANDCApplications5,Monitoring_Retries,WindowSwitch_Sleep,AppSwitch_Sleep,MonitoringCycle_Sleep,CPMLogLevel,IsDispenserRealTimeNotificationEnabled,IsBNARealTimeNotificationEnabled,IsCPMRealTimeNotificationEnabled,IsReplenishmentRealTimeNotificationEnabled,IsOutOfCashRealTimeNotificationEnabled,IsDispenserMismatchRealTimeNotificationEnabled,IsBNAMismatchRealTimeNotificationEnabled,IsCPMMismatchRealTimeNotificationEnabled,IsCounterExplodedRealTimeNotificationEnabled,Type1MinimumNotes,Type2MinimumNotes,Type3MinimumNotes,Type4MinimumNotes,Type5MinimumNotes,Type6MinimumNotes,Type7MinimumNotes,cpm_command,allowed_inactivity_period,gl_number,card_captured_cost,escotting_cost,replenishment_cost,maintenance_cost,flm_call_out_cost,description,is_dff_generation_halt,cit_atm_title,cheque_allowed_inactivity_period,bna_allowed_inactivity_period,out_of_cash_threshold,no_of_dispensed_transactions_to_monitor,is_ej_enabled,is_counter_enabled,priority,longitude,latitude,on_us_amount,not_on_us_amount,standard_order_type1,standard_order_type2,standard_order_type3,standard_order_type4,standard_order_type5,standard_order_type6,standard_order_type7,protocol_type_id,current_mode,aggregate_state,last_boot_time,discovery_time,last_scan_time,communication_status,is_critical,current_mode_modified_on,Last_Notification_Received_On,Last_Notification_Time,normal_order_cost,emergency_order_cost,receipt_transaction_cutoff,is_swap_default_replenishment,message_processor_id ) values(");
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
                    qry.Append(message_processor_idDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || last_wincor_sentChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || zip_codeChanged || location_typeChanged || service_statusChanged || holiday_statusChanged || business_daysChanged || time_zoneChanged || max_notes_per_cassetteChanged || cassette1_split_percentageChanged || cassette2_split_percentageChanged || cassette3_split_percentageChanged || cassette4_split_percentageChanged || cassette5_split_percentageChanged || cassette6_split_percentageChanged || cassette7_split_percentageChanged || interest_rateChanged || insurance_rateChanged || max_holding_amountChanged || min_operating_balanceChanged || min_amount_for_normal_deliveryChanged || bank_cash_center_idChanged || cIT_cash_center_servicerChanged || depot_idChanged || secondary_depot_vault_idChanged || new_atm_scenarioChanged || cash_swap_daysChanged || mandatory_cash_swap_daysChanged || cash_swap_cycleChanged || cash_swap_lead_timeChanged || cash_swap_start_dateChanged || cash_swap_handling_costChanged || cash_swap_costsChanged || emergency_daysChanged || emergency_lead_timeChanged || emergency_costChanged || contact1_emailChanged || contact2_emailChanged || contact3_emailChanged || contact1_phoneChanged || contact2_phoneChanged || contact3_phoneChanged || effective_dateChanged || suspend_cash_orderChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || exclude_dffChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_cash_order_uploadChanged || retry_count_conf_uploadChanged || retry_count_counter_fileChanged || retry_count_restart_scheduleChanged || retry_count_datetime_scheduleChanged || retry_count_alertChanged || countsClearRetriesChanged || tCPTimeoutChanged || sleepIntervalChanged || cPMCommandWaitChanged || cPMCommandSleepChanged || aANDCApplications1Changed || aANDCApplications2Changed || aANDCApplications3Changed || aANDCApplications4Changed || aANDCApplications5Changed || monitoring_RetriesChanged || windowSwitch_SleepChanged || appSwitch_SleepChanged || monitoringCycle_SleepChanged || cPMLogLevelChanged || isDispenserRealTimeNotificationEnabledChanged || isBNARealTimeNotificationEnabledChanged || isCPMRealTimeNotificationEnabledChanged || isReplenishmentRealTimeNotificationEnabledChanged || isOutOfCashRealTimeNotificationEnabledChanged || isDispenserMismatchRealTimeNotificationEnabledChanged || isBNAMismatchRealTimeNotificationEnabledChanged || isCPMMismatchRealTimeNotificationEnabledChanged || isCounterExplodedRealTimeNotificationEnabledChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || cpm_commandChanged || allowed_inactivity_periodChanged || gl_numberChanged || card_captured_costChanged || escotting_costChanged || replenishment_costChanged || maintenance_costChanged || flm_call_out_costChanged || descriptionChanged || is_dff_generation_haltChanged || cit_atm_titleChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || no_of_dispensed_transactions_to_monitorChanged || is_ej_enabledChanged || is_counter_enabledChanged || priorityChanged || longitudeChanged || latitudeChanged || on_us_amountChanged || not_on_us_amountChanged || standard_order_type1Changed || standard_order_type2Changed || standard_order_type3Changed || standard_order_type4Changed || standard_order_type5Changed || standard_order_type6Changed || standard_order_type7Changed || protocol_type_idChanged || current_modeChanged || aggregate_stateChanged || last_boot_timeChanged || discovery_timeChanged || last_scan_timeChanged || communication_statusChanged || is_criticalChanged || current_mode_modified_onChanged || last_Notification_Received_OnChanged || last_Notification_TimeChanged || normal_order_costChanged || emergency_order_costChanged || receipt_transaction_cutoffChanged || is_swap_default_replenishmentChanged || message_processor_idChanged))
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
            cmd.CommandText = "DELETE Atm where ATM_id = " + aTM_id;
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
    }
}
