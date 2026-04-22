using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServicesDAL
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
        public Atm(long aTM_id, long region_id, string title, string iP, int port, long created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, bool is_healthy, long note_set_type_id, int retry_count_conf_upload, int tCPTimeout, int sleepInterval, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, int out_of_cash_threshold)
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
            this.is_healthy = is_healthy;
            this.is_healthyChanged = true;
            this.note_set_type_id = note_set_type_id;
            this.note_set_type_idChanged = true;
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.tCPTimeout = tCPTimeout;
            this.tCPTimeoutChanged = true;
            this.sleepInterval = sleepInterval;
            this.sleepIntervalChanged = true;
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
        }
        public Atm(string last_status_reply, long region_id, string title, string iP, int port, long? modified_by, long created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, bool is_healthy, string location, string address1, string address2, string city, string country, int? max_notes_per_cassette, decimal? min_operating_balance, bool? is_atm, bool? is_cdm, bool? is_ccdm, int? cdm_cassette1_capacity, int? cdm_cassette2_capacity, int? cdm_cassette3_capacity, int? cdm_cassette4_capacity, int? ccdm_cassette1_capacity, int? ccdm_cassette2_capacity, int? ccdm_cassette3_capacity, int? ccdm_cassette4_capacity, int? cdm_cassette1_threshold, int? cdm_cassette2_threshold, int? cdm_cassette3_threshold, int? cdm_cassette4_threshold, int? ccdm_cassette1_threshold, int? ccdm_cassette2_threshold, int? ccdm_cassette3_threshold, int? ccdm_cassette4_threshold, long note_set_type_id, int? ccdm_cassette5_capacity, int? ccdm_cassette5_threshold, int? startup_sleep_interval, byte? debug_level, int? purge1_threshold, bool? is_purge1_threshold_selected, int? purge2_threshold, bool? is_purge2_threshold_selected, int? purge3_threshold, bool? is_purge3_threshold_selected, int? purge4_threshold, bool? is_purge4_threshold_selected, int? purge5_threshold, bool? is_purge5_threshold_selected, int? purge6_threshold, bool? is_purge6_threshold_selected, int? purge7_threshold, bool? is_purge7_threshold_selected, int retry_count_conf_upload, int tCPTimeout, int sleepInterval, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, int? allowed_inactivity_period, string description, int? cheque_allowed_inactivity_period, int? bna_allowed_inactivity_period, int out_of_cash_threshold, string longitude, string latitude, bool? is_swap_default_replenishment, long? message_processor_id, int? type1_min_notes_threshold, int? type2_min_notes_threshold, int? type3_min_notes_threshold, int? type4_min_notes_threshold, int? type1_min_notes_threshold_value, int? type2_min_notes_threshold_value, int? type3_min_notes_threshold_value, int? type4_min_notes_threshold_value, int? bna_allowed_inactivity_period_normal_days, int? bna_allowed_inactivity_period_salary_days, int? cheque_allowed_inactivity_period_normal_days, int? cheque_allowed_inactivity_period_salary_days, long? cit_id, bool? is_recycler, string last_ping_status, DateTime? last_ping_executed_at, string last_telnet_status, DateTime? last_telnet_executed_at, int? assigned_server, bool? is_edited, DateTime? atm_streaming_heartbeat_received_at, DateTime? atm_on_demand_heartbeat_received_at)
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
            this.max_notes_per_cassette = max_notes_per_cassette;
            this.max_notes_per_cassetteChanged = true;
            this.min_operating_balance = min_operating_balance;
            this.min_operating_balanceChanged = true;
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
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.tCPTimeout = tCPTimeout;
            this.tCPTimeoutChanged = true;
            this.sleepInterval = sleepInterval;
            this.sleepIntervalChanged = true;
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
            this.allowed_inactivity_period = allowed_inactivity_period;
            this.allowed_inactivity_periodChanged = true;
            this.description = description;
            this.descriptionChanged = true;
            this.cheque_allowed_inactivity_period = cheque_allowed_inactivity_period;
            this.cheque_allowed_inactivity_periodChanged = true;
            this.bna_allowed_inactivity_period = bna_allowed_inactivity_period;
            this.bna_allowed_inactivity_periodChanged = true;
            this.out_of_cash_threshold = out_of_cash_threshold;
            this.out_of_cash_thresholdChanged = true;
            this.longitude = longitude;
            this.longitudeChanged = true;
            this.latitude = latitude;
            this.latitudeChanged = true;
            this.is_swap_default_replenishment = is_swap_default_replenishment;
            this.is_swap_default_replenishmentChanged = true;
            this.message_processor_id = message_processor_id;
            this.message_processor_idChanged = true;
            this.type1_min_notes_threshold = type1_min_notes_threshold;
            this.type1_min_notes_thresholdChanged = true;
            this.type2_min_notes_threshold = type2_min_notes_threshold;
            this.type2_min_notes_thresholdChanged = true;
            this.type3_min_notes_threshold = type3_min_notes_threshold;
            this.type3_min_notes_thresholdChanged = true;
            this.type4_min_notes_threshold = type4_min_notes_threshold;
            this.type4_min_notes_thresholdChanged = true;
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
            this.cit_id = cit_id;
            this.cit_idChanged = true;
            this.is_recycler = is_recycler;
            this.is_recyclerChanged = true;
            this.last_ping_status = last_ping_status;
            this.last_ping_statusChanged = true;
            this.last_ping_executed_at = last_ping_executed_at;
            this.last_ping_executed_atChanged = true;
            this.last_telnet_status = last_telnet_status;
            this.last_telnet_statusChanged = true;
            this.last_telnet_executed_at = last_telnet_executed_at;
            this.last_telnet_executed_atChanged = true;
            this.assigned_server = assigned_server;
            this.assigned_serverChanged = true;
            this.is_edited = is_edited;
            this.is_editedChanged = true;
            this.atm_streaming_heartbeat_received_at = atm_streaming_heartbeat_received_at;
            this.atm_streaming_heartbeat_received_atChanged = true;
            this.atm_on_demand_heartbeat_received_at = atm_on_demand_heartbeat_received_at;
            this.atm_on_demand_heartbeat_received_atChanged = true;
        }
        private Atm(long aTM_id, string last_status_reply, long region_id, string title, string iP, int port, long? modified_by, long created_by, bool is_active, DateTime creation_time, string atm_type, int cassette1_capacity, int cassette1_denomination, int cassette2_capacity, int cassette2_denomination, int cassette3_denomination, int cassette3_capacity, int cassette4_denomination, int cassette4_capacity, int cassette5_denomination, int cassette5_capacity, int cassette6_denomination, int cassette6_capacity, int cassette7_denomination, int cassette7_capacity, bool is_healthy, string location, string address1, string address2, string city, string country, int? max_notes_per_cassette, decimal? min_operating_balance, bool? is_atm, bool? is_cdm, bool? is_ccdm, int? cdm_cassette1_capacity, int? cdm_cassette2_capacity, int? cdm_cassette3_capacity, int? cdm_cassette4_capacity, int? ccdm_cassette1_capacity, int? ccdm_cassette2_capacity, int? ccdm_cassette3_capacity, int? ccdm_cassette4_capacity, int? cdm_cassette1_threshold, int? cdm_cassette2_threshold, int? cdm_cassette3_threshold, int? cdm_cassette4_threshold, int? ccdm_cassette1_threshold, int? ccdm_cassette2_threshold, int? ccdm_cassette3_threshold, int? ccdm_cassette4_threshold, long note_set_type_id, int? ccdm_cassette5_capacity, int? ccdm_cassette5_threshold, int? startup_sleep_interval, byte? debug_level, int? purge1_threshold, bool? is_purge1_threshold_selected, int? purge2_threshold, bool? is_purge2_threshold_selected, int? purge3_threshold, bool? is_purge3_threshold_selected, int? purge4_threshold, bool? is_purge4_threshold_selected, int? purge5_threshold, bool? is_purge5_threshold_selected, int? purge6_threshold, bool? is_purge6_threshold_selected, int? purge7_threshold, bool? is_purge7_threshold_selected, int retry_count_conf_upload, int tCPTimeout, int sleepInterval, int type1MinimumNotes, int type2MinimumNotes, int type3MinimumNotes, int type4MinimumNotes, int type5MinimumNotes, int type6MinimumNotes, int type7MinimumNotes, int? allowed_inactivity_period, string description, int? cheque_allowed_inactivity_period, int? bna_allowed_inactivity_period, int out_of_cash_threshold, string longitude, string latitude, bool? is_swap_default_replenishment, long? message_processor_id, int? type1_min_notes_threshold, int? type2_min_notes_threshold, int? type3_min_notes_threshold, int? type4_min_notes_threshold, int? type1_min_notes_threshold_value, int? type2_min_notes_threshold_value, int? type3_min_notes_threshold_value, int? type4_min_notes_threshold_value, int? bna_allowed_inactivity_period_normal_days, int? bna_allowed_inactivity_period_salary_days, int? cheque_allowed_inactivity_period_normal_days, int? cheque_allowed_inactivity_period_salary_days, long? cit_id, bool? is_recycler, string last_ping_status, DateTime? last_ping_executed_at, string last_telnet_status, DateTime? last_telnet_executed_at, int? assigned_server, bool? is_edited, DateTime? atm_streaming_heartbeat_received_at, DateTime? atm_on_demand_heartbeat_received_at)
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
            this.max_notes_per_cassette = max_notes_per_cassette;
            this.max_notes_per_cassetteChanged = true;
            this.min_operating_balance = min_operating_balance;
            this.min_operating_balanceChanged = true;
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
            this.retry_count_conf_upload = retry_count_conf_upload;
            this.retry_count_conf_uploadChanged = true;
            this.tCPTimeout = tCPTimeout;
            this.tCPTimeoutChanged = true;
            this.sleepInterval = sleepInterval;
            this.sleepIntervalChanged = true;
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
            this.allowed_inactivity_period = allowed_inactivity_period;
            this.allowed_inactivity_periodChanged = true;
            this.description = description;
            this.descriptionChanged = true;
            this.cheque_allowed_inactivity_period = cheque_allowed_inactivity_period;
            this.cheque_allowed_inactivity_periodChanged = true;
            this.bna_allowed_inactivity_period = bna_allowed_inactivity_period;
            this.bna_allowed_inactivity_periodChanged = true;
            this.out_of_cash_threshold = out_of_cash_threshold;
            this.out_of_cash_thresholdChanged = true;
            this.longitude = longitude;
            this.longitudeChanged = true;
            this.latitude = latitude;
            this.latitudeChanged = true;
            this.is_swap_default_replenishment = is_swap_default_replenishment;
            this.is_swap_default_replenishmentChanged = true;
            this.message_processor_id = message_processor_id;
            this.message_processor_idChanged = true;
            this.type1_min_notes_threshold = type1_min_notes_threshold;
            this.type1_min_notes_thresholdChanged = true;
            this.type2_min_notes_threshold = type2_min_notes_threshold;
            this.type2_min_notes_thresholdChanged = true;
            this.type3_min_notes_threshold = type3_min_notes_threshold;
            this.type3_min_notes_thresholdChanged = true;
            this.type4_min_notes_threshold = type4_min_notes_threshold;
            this.type4_min_notes_thresholdChanged = true;
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
            this.cit_id = cit_id;
            this.cit_idChanged = true;
            this.is_recycler = is_recycler;
            this.is_recyclerChanged = true;
            this.last_ping_status = last_ping_status;
            this.last_ping_statusChanged = true;
            this.last_ping_executed_at = last_ping_executed_at;
            this.last_ping_executed_atChanged = true;
            this.last_telnet_status = last_telnet_status;
            this.last_telnet_statusChanged = true;
            this.last_telnet_executed_at = last_telnet_executed_at;
            this.last_telnet_executed_atChanged = true;
            this.assigned_server = assigned_server;
            this.assigned_serverChanged = true;
            this.is_edited = is_edited;
            this.is_editedChanged = true;
            this.atm_streaming_heartbeat_received_at = atm_streaming_heartbeat_received_at;
            this.atm_streaming_heartbeat_received_atChanged = true;
            this.atm_on_demand_heartbeat_received_at = atm_on_demand_heartbeat_received_at;
            this.atm_on_demand_heartbeat_received_atChanged = true;
        }

        #region members and properties for columns

        #region ATMId
        private bool aTM_idChanged = false;
        private long aTM_id;
        public long ATMId
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
        private long region_id;
        public long RegionId
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
        private long? modified_by;
        public long? ModifiedBy
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
        private long created_by;
        public long CreatedBy
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
        private long note_set_type_id;
        public long NoteSetTypeId
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
        private long? message_processor_id;
        public long? MessageProcessorId
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
        #region CitId
        private bool cit_idChanged = false;
        private long? cit_id;
        public long? CitId
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
        #region AssignedServer
        private bool assigned_serverChanged = false;
        private int? assigned_server;
        public int? AssignedServer
        {
            get { return assigned_server; }
            set
            {
                assigned_server = value;
                assigned_serverChanged = true;
            }
        }
        private string assigned_serverDbString
        {
            get
            {
                if (this.assigned_server.HasValue)
                    return assigned_server.ToString();
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
        #region AtmStreamingHeartbeatReceivedAt
        private bool atm_streaming_heartbeat_received_atChanged = false;
        private DateTime? atm_streaming_heartbeat_received_at;
        public DateTime? AtmStreamingHeartbeatReceivedAt
        {
            get { return atm_streaming_heartbeat_received_at; }
            set
            {
                atm_streaming_heartbeat_received_at = value;
                atm_streaming_heartbeat_received_atChanged = true;
            }
        }
        private string atm_streaming_heartbeat_received_atDbString
        {
            get
            {
                if (this.atm_streaming_heartbeat_received_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", atm_streaming_heartbeat_received_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region AtmOnDemandHeartbeatReceivedAt
        private bool atm_on_demand_heartbeat_received_atChanged = false;
        private DateTime? atm_on_demand_heartbeat_received_at;
        public DateTime? AtmOnDemandHeartbeatReceivedAt
        {
            get { return atm_on_demand_heartbeat_received_at; }
            set
            {
                atm_on_demand_heartbeat_received_at = value;
                atm_on_demand_heartbeat_received_atChanged = true;
            }
        }
        private string atm_on_demand_heartbeat_received_atDbString
        {
            get
            {
                if (this.atm_on_demand_heartbeat_received_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", atm_on_demand_heartbeat_received_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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
                            currentAtm.aTM_id = (long)reader["ATM_id"];
                        if (reader["last_status_reply"] != DBNull.Value)
                            currentAtm.last_status_reply = (string)reader["last_status_reply"];
                        if (reader["region_id"] != DBNull.Value)
                            currentAtm.region_id = (long)reader["region_id"];
                        if (reader["title"] != DBNull.Value)
                            currentAtm.title = (string)reader["title"];
                        if (reader["IP"] != DBNull.Value)
                            currentAtm.iP = (string)reader["IP"];
                        if (reader["port"] != DBNull.Value)
                            currentAtm.port = (int)reader["port"];
                        if (reader["modified_by"] != DBNull.Value)
                            currentAtm.modified_by = (long?)reader["modified_by"];
                        if (reader["created_by"] != DBNull.Value)
                            currentAtm.created_by = (long)reader["created_by"];
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
                        if (reader["max_notes_per_cassette"] != DBNull.Value)
                            currentAtm.max_notes_per_cassette = (int?)reader["max_notes_per_cassette"];
                        if (reader["min_operating_balance"] != DBNull.Value)
                            currentAtm.min_operating_balance = (decimal?)reader["min_operating_balance"];
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
                            currentAtm.note_set_type_id = (long)reader["note_set_type_id"];
                        if (reader["ccdm_cassette5_capacity"] != DBNull.Value)
                            currentAtm.ccdm_cassette5_capacity = (int?)reader["ccdm_cassette5_capacity"];
                        if (reader["ccdm_cassette5_threshold"] != DBNull.Value)
                            currentAtm.ccdm_cassette5_threshold = (int?)reader["ccdm_cassette5_threshold"];
                        if (reader["startup_sleep_interval"] != DBNull.Value)
                            currentAtm.startup_sleep_interval = (int?)reader["startup_sleep_interval"];
                        if (reader["debug_level"] != DBNull.Value)
                            currentAtm.debug_level = (byte?)reader["debug_level"];
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
                        if (reader["retry_count_conf_upload"] != DBNull.Value)
                            currentAtm.retry_count_conf_upload = (int)reader["retry_count_conf_upload"];
                        if (reader["TCPTimeout"] != DBNull.Value)
                            currentAtm.tCPTimeout = (int)reader["TCPTimeout"];
                        if (reader["SleepInterval"] != DBNull.Value)
                            currentAtm.sleepInterval = (int)reader["SleepInterval"];
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
                        if (reader["allowed_inactivity_period"] != DBNull.Value)
                            currentAtm.allowed_inactivity_period = (int?)reader["allowed_inactivity_period"];
                        if (reader["description"] != DBNull.Value)
                            currentAtm.description = (string)reader["description"];
                        if (reader["cheque_allowed_inactivity_period"] != DBNull.Value)
                            currentAtm.cheque_allowed_inactivity_period = (int?)reader["cheque_allowed_inactivity_period"];
                        if (reader["bna_allowed_inactivity_period"] != DBNull.Value)
                            currentAtm.bna_allowed_inactivity_period = (int?)reader["bna_allowed_inactivity_period"];
                        if (reader["out_of_cash_threshold"] != DBNull.Value)
                            currentAtm.out_of_cash_threshold = (int)reader["out_of_cash_threshold"];
                        if (reader["longitude"] != DBNull.Value)
                            currentAtm.longitude = (string)reader["longitude"];
                        if (reader["latitude"] != DBNull.Value)
                            currentAtm.latitude = (string)reader["latitude"];
                        if (reader["is_swap_default_replenishment"] != DBNull.Value)
                            currentAtm.is_swap_default_replenishment = (bool?)reader["is_swap_default_replenishment"];
                        if (reader["message_processor_id"] != DBNull.Value)
                            currentAtm.message_processor_id = (long?)reader["message_processor_id"];
                        if (reader["type1_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type1_min_notes_threshold = (int?)reader["type1_min_notes_threshold"];
                        if (reader["type2_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type2_min_notes_threshold = (int?)reader["type2_min_notes_threshold"];
                        if (reader["type3_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type3_min_notes_threshold = (int?)reader["type3_min_notes_threshold"];
                        if (reader["type4_min_notes_threshold"] != DBNull.Value)
                            currentAtm.type4_min_notes_threshold = (int?)reader["type4_min_notes_threshold"];
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
                        if (reader["cit_id"] != DBNull.Value)
                            currentAtm.cit_id = (long?)reader["cit_id"];
                        if (reader["is_recycler"] != DBNull.Value)
                            currentAtm.is_recycler = (bool?)reader["is_recycler"];
                        if (reader["last_ping_status"] != DBNull.Value)
                            currentAtm.last_ping_status = (string)reader["last_ping_status"];
                        if (reader["last_ping_executed_at"] != DBNull.Value)
                            currentAtm.last_ping_executed_at = (DateTime?)reader["last_ping_executed_at"];
                        if (reader["last_telnet_status"] != DBNull.Value)
                            currentAtm.last_telnet_status = (string)reader["last_telnet_status"];
                        if (reader["last_telnet_executed_at"] != DBNull.Value)
                            currentAtm.last_telnet_executed_at = (DateTime?)reader["last_telnet_executed_at"];
                        if (reader["assigned_server"] != DBNull.Value)
                            currentAtm.assigned_server = (int?)reader["assigned_server"];
                        if (reader["is_edited"] != DBNull.Value)
                            currentAtm.is_edited = (bool?)reader["is_edited"];
                        if (reader["atm_streaming_heartbeat_received_at"] != DBNull.Value)
                            currentAtm.atm_streaming_heartbeat_received_at = (DateTime?)reader["atm_streaming_heartbeat_received_at"];
                        if (reader["atm_on_demand_heartbeat_received_at"] != DBNull.Value)
                            currentAtm.atm_on_demand_heartbeat_received_at = (DateTime?)reader["atm_on_demand_heartbeat_received_at"];
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
            if (Columns.max_notes_per_cassette == (Columns.max_notes_per_cassette & columns))
                qry.Append("max_notes_per_cassette,");
            if (Columns.min_operating_balance == (Columns.min_operating_balance & columns))
                qry.Append("min_operating_balance,");
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
            if (Columns.retry_count_conf_upload == (Columns.retry_count_conf_upload & columns))
                qry.Append("retry_count_conf_upload,");
            if (Columns.TCPTimeout == (Columns.TCPTimeout & columns))
                qry.Append("TCPTimeout,");
            if (Columns.SleepInterval == (Columns.SleepInterval & columns))
                qry.Append("SleepInterval,");
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
            if (Columns.allowed_inactivity_period == (Columns.allowed_inactivity_period & columns))
                qry.Append("allowed_inactivity_period,");
            if (Columns.description == (Columns.description & columns))
                qry.Append("description,");
            if (Columns.cheque_allowed_inactivity_period == (Columns.cheque_allowed_inactivity_period & columns))
                qry.Append("cheque_allowed_inactivity_period,");
            if (Columns.bna_allowed_inactivity_period == (Columns.bna_allowed_inactivity_period & columns))
                qry.Append("bna_allowed_inactivity_period,");
            if (Columns.out_of_cash_threshold == (Columns.out_of_cash_threshold & columns))
                qry.Append("out_of_cash_threshold,");
            if (Columns.longitude == (Columns.longitude & columns))
                qry.Append("longitude,");
            if (Columns.latitude == (Columns.latitude & columns))
                qry.Append("latitude,");
            if (Columns.is_swap_default_replenishment == (Columns.is_swap_default_replenishment & columns))
                qry.Append("is_swap_default_replenishment,");
            if (Columns.message_processor_id == (Columns.message_processor_id & columns))
                qry.Append("message_processor_id,");
            if (Columns.type1_min_notes_threshold == (Columns.type1_min_notes_threshold & columns))
                qry.Append("type1_min_notes_threshold,");
            if (Columns.type2_min_notes_threshold == (Columns.type2_min_notes_threshold & columns))
                qry.Append("type2_min_notes_threshold,");
            if (Columns.type3_min_notes_threshold == (Columns.type3_min_notes_threshold & columns))
                qry.Append("type3_min_notes_threshold,");
            if (Columns.type4_min_notes_threshold == (Columns.type4_min_notes_threshold & columns))
                qry.Append("type4_min_notes_threshold,");
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
            if (Columns.cit_id == (Columns.cit_id & columns))
                qry.Append("cit_id,");
            if (Columns.is_recycler == (Columns.is_recycler & columns))
                qry.Append("is_recycler,");
            if (Columns.last_ping_status == (Columns.last_ping_status & columns))
                qry.Append("last_ping_status,");
            if (Columns.last_ping_executed_at == (Columns.last_ping_executed_at & columns))
                qry.Append("last_ping_executed_at,");
            if (Columns.last_telnet_status == (Columns.last_telnet_status & columns))
                qry.Append("last_telnet_status,");
            if (Columns.last_telnet_executed_at == (Columns.last_telnet_executed_at & columns))
                qry.Append("last_telnet_executed_at,");
            if (Columns.assigned_server == (Columns.assigned_server & columns))
                qry.Append("assigned_server,");
            if (Columns.is_edited == (Columns.is_edited & columns))
                qry.Append("is_edited,");
            if (Columns.atm_streaming_heartbeat_received_at == (Columns.atm_streaming_heartbeat_received_at & columns))
                qry.Append("atm_streaming_heartbeat_received_at,");
            if (Columns.atm_on_demand_heartbeat_received_at == (Columns.atm_on_demand_heartbeat_received_at & columns))
                qry.Append("atm_on_demand_heartbeat_received_at,");
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
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core), columns);
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
            cmd.CommandText = "Select ATM_id,last_status_reply,region_id,title,IP,port,modified_by,created_by,is_active,creation_time,atm_type,cassette1_capacity,cassette1_denomination,cassette2_capacity,cassette2_denomination,cassette3_denomination,cassette3_capacity,cassette4_denomination,cassette4_capacity,cassette5_denomination,cassette5_capacity,cassette6_denomination,cassette6_capacity,cassette7_denomination,cassette7_capacity,is_healthy,location,address1,address2,city,country,max_notes_per_cassette,min_operating_balance,is_atm,is_cdm,is_ccdm,cdm_cassette1_capacity,cdm_cassette2_capacity,cdm_cassette3_capacity,cdm_cassette4_capacity,ccdm_cassette1_capacity,ccdm_cassette2_capacity,ccdm_cassette3_capacity,ccdm_cassette4_capacity,cdm_cassette1_threshold,cdm_cassette2_threshold,cdm_cassette3_threshold,cdm_cassette4_threshold,ccdm_cassette1_threshold,ccdm_cassette2_threshold,ccdm_cassette3_threshold,ccdm_cassette4_threshold,note_set_type_id,ccdm_cassette5_capacity,ccdm_cassette5_threshold,startup_sleep_interval,debug_level,purge1_threshold,is_purge1_threshold_selected,purge2_threshold,is_purge2_threshold_selected,purge3_threshold,is_purge3_threshold_selected,purge4_threshold,is_purge4_threshold_selected,purge5_threshold,is_purge5_threshold_selected,purge6_threshold,is_purge6_threshold_selected,purge7_threshold,is_purge7_threshold_selected,retry_count_conf_upload,TCPTimeout,SleepInterval,Type1MinimumNotes,Type2MinimumNotes,Type3MinimumNotes,Type4MinimumNotes,Type5MinimumNotes,Type6MinimumNotes,Type7MinimumNotes,allowed_inactivity_period,description,cheque_allowed_inactivity_period,bna_allowed_inactivity_period,out_of_cash_threshold,longitude,latitude,is_swap_default_replenishment,message_processor_id,type1_min_notes_threshold,type2_min_notes_threshold,type3_min_notes_threshold,type4_min_notes_threshold,type1_min_notes_threshold_value,type2_min_notes_threshold_value,type3_min_notes_threshold_value,type4_min_notes_threshold_value,bna_allowed_inactivity_period_normal_days,bna_allowed_inactivity_period_salary_days,cheque_allowed_inactivity_period_normal_days,cheque_allowed_inactivity_period_salary_days,cit_id,is_recycler,last_ping_status,last_ping_executed_at,last_telnet_status,last_telnet_executed_at,assigned_server,is_edited,atm_streaming_heartbeat_received_at,atm_on_demand_heartbeat_received_at from Atm ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new AtmReader(cmd.ExecuteReader(), conn);
        }

        static public AtmReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Core));
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

        public static Atm LoadAtmByPk(long aTM_id)
        {
            return LoadAtm("ATM_id=" + aTM_id);
        }

        public static Atm LoadAtmByPk(long aTM_id, IDbConnection conn)
        {
            return LoadAtm(" ATM_id=" + aTM_id, conn);
        }

        public void Save()
        {
            if (aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || max_notes_per_cassetteChanged || min_operating_balanceChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_conf_uploadChanged || tCPTimeoutChanged || sleepIntervalChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || allowed_inactivity_periodChanged || descriptionChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || longitudeChanged || latitudeChanged || is_swap_default_replenishmentChanged || message_processor_idChanged || type1_min_notes_thresholdChanged || type2_min_notes_thresholdChanged || type3_min_notes_thresholdChanged || type4_min_notes_thresholdChanged || type1_min_notes_threshold_valueChanged || type2_min_notes_threshold_valueChanged || type3_min_notes_threshold_valueChanged || type4_min_notes_threshold_valueChanged || bna_allowed_inactivity_period_normal_daysChanged || bna_allowed_inactivity_period_salary_daysChanged || cheque_allowed_inactivity_period_normal_daysChanged || cheque_allowed_inactivity_period_salary_daysChanged || cit_idChanged || is_recyclerChanged || last_ping_statusChanged || last_ping_executed_atChanged || last_telnet_statusChanged || last_telnet_executed_atChanged || assigned_serverChanged || is_editedChanged || atm_streaming_heartbeat_received_atChanged || atm_on_demand_heartbeat_received_atChanged)
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
            if (aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || max_notes_per_cassetteChanged || min_operating_balanceChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_conf_uploadChanged || tCPTimeoutChanged || sleepIntervalChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || allowed_inactivity_periodChanged || descriptionChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || longitudeChanged || latitudeChanged || is_swap_default_replenishmentChanged || message_processor_idChanged || type1_min_notes_thresholdChanged || type2_min_notes_thresholdChanged || type3_min_notes_thresholdChanged || type4_min_notes_thresholdChanged || type1_min_notes_threshold_valueChanged || type2_min_notes_threshold_valueChanged || type3_min_notes_threshold_valueChanged || type4_min_notes_threshold_valueChanged || bna_allowed_inactivity_period_normal_daysChanged || bna_allowed_inactivity_period_salary_daysChanged || cheque_allowed_inactivity_period_normal_daysChanged || cheque_allowed_inactivity_period_salary_daysChanged || cit_idChanged || is_recyclerChanged || last_ping_statusChanged || last_ping_executed_atChanged || last_telnet_statusChanged || last_telnet_executed_atChanged || assigned_serverChanged || is_editedChanged || atm_streaming_heartbeat_received_atChanged || atm_on_demand_heartbeat_received_atChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Atm(ATM_id,last_status_reply,region_id,title,IP,port,modified_by,created_by,is_active,creation_time,atm_type,cassette1_capacity,cassette1_denomination,cassette2_capacity,cassette2_denomination,cassette3_denomination,cassette3_capacity,cassette4_denomination,cassette4_capacity,cassette5_denomination,cassette5_capacity,cassette6_denomination,cassette6_capacity,cassette7_denomination,cassette7_capacity,is_healthy,location,address1,address2,city,country,max_notes_per_cassette,min_operating_balance,is_atm,is_cdm,is_ccdm,cdm_cassette1_capacity,cdm_cassette2_capacity,cdm_cassette3_capacity,cdm_cassette4_capacity,ccdm_cassette1_capacity,ccdm_cassette2_capacity,ccdm_cassette3_capacity,ccdm_cassette4_capacity,cdm_cassette1_threshold,cdm_cassette2_threshold,cdm_cassette3_threshold,cdm_cassette4_threshold,ccdm_cassette1_threshold,ccdm_cassette2_threshold,ccdm_cassette3_threshold,ccdm_cassette4_threshold,note_set_type_id,ccdm_cassette5_capacity,ccdm_cassette5_threshold,startup_sleep_interval,debug_level,purge1_threshold,is_purge1_threshold_selected,purge2_threshold,is_purge2_threshold_selected,purge3_threshold,is_purge3_threshold_selected,purge4_threshold,is_purge4_threshold_selected,purge5_threshold,is_purge5_threshold_selected,purge6_threshold,is_purge6_threshold_selected,purge7_threshold,is_purge7_threshold_selected,retry_count_conf_upload,TCPTimeout,SleepInterval,Type1MinimumNotes,Type2MinimumNotes,Type3MinimumNotes,Type4MinimumNotes,Type5MinimumNotes,Type6MinimumNotes,Type7MinimumNotes,allowed_inactivity_period,description,cheque_allowed_inactivity_period,bna_allowed_inactivity_period,out_of_cash_threshold,longitude,latitude,is_swap_default_replenishment,message_processor_id,type1_min_notes_threshold,type2_min_notes_threshold,type3_min_notes_threshold,type4_min_notes_threshold,type1_min_notes_threshold_value,type2_min_notes_threshold_value,type3_min_notes_threshold_value,type4_min_notes_threshold_value,bna_allowed_inactivity_period_normal_days,bna_allowed_inactivity_period_salary_days,cheque_allowed_inactivity_period_normal_days,cheque_allowed_inactivity_period_salary_days,cit_id,is_recycler,last_ping_status,last_ping_executed_at,last_telnet_status,last_telnet_executed_at,assigned_server,is_edited,atm_streaming_heartbeat_received_at,atm_on_demand_heartbeat_received_at) values(");
                    lock (ConnectionFactory.connectionStringCore)
                    {
                        this.aTM_id = ConnectionFactory.GetNextId(DatabaseName.Core);
                        qry.Append(this.aTM_id);
                    }
                    qry.Append(",");
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
                    qry.Append(is_healthyDbString + ",");
                    qry.Append(locationDbString + ",");
                    qry.Append(address1DbString + ",");
                    qry.Append(address2DbString + ",");
                    qry.Append(cityDbString + ",");
                    qry.Append(countryDbString + ",");
                    qry.Append(max_notes_per_cassetteDbString + ",");
                    qry.Append(min_operating_balanceDbString + ",");
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
                    qry.Append(retry_count_conf_uploadDbString + ",");
                    qry.Append(tCPTimeoutDbString + ",");
                    qry.Append(sleepIntervalDbString + ",");
                    qry.Append(type1MinimumNotesDbString + ",");
                    qry.Append(type2MinimumNotesDbString + ",");
                    qry.Append(type3MinimumNotesDbString + ",");
                    qry.Append(type4MinimumNotesDbString + ",");
                    qry.Append(type5MinimumNotesDbString + ",");
                    qry.Append(type6MinimumNotesDbString + ",");
                    qry.Append(type7MinimumNotesDbString + ",");
                    qry.Append(allowed_inactivity_periodDbString + ",");
                    qry.Append(descriptionDbString + ",");
                    qry.Append(cheque_allowed_inactivity_periodDbString + ",");
                    qry.Append(bna_allowed_inactivity_periodDbString + ",");
                    qry.Append(out_of_cash_thresholdDbString + ",");
                    qry.Append(longitudeDbString + ",");
                    qry.Append(latitudeDbString + ",");
                    qry.Append(is_swap_default_replenishmentDbString + ",");
                    qry.Append(message_processor_idDbString + ",");
                    qry.Append(type1_min_notes_thresholdDbString + ",");
                    qry.Append(type2_min_notes_thresholdDbString + ",");
                    qry.Append(type3_min_notes_thresholdDbString + ",");
                    qry.Append(type4_min_notes_thresholdDbString + ",");
                    qry.Append(type1_min_notes_threshold_valueDbString + ",");
                    qry.Append(type2_min_notes_threshold_valueDbString + ",");
                    qry.Append(type3_min_notes_threshold_valueDbString + ",");
                    qry.Append(type4_min_notes_threshold_valueDbString + ",");
                    qry.Append(bna_allowed_inactivity_period_normal_daysDbString + ",");
                    qry.Append(bna_allowed_inactivity_period_salary_daysDbString + ",");
                    qry.Append(cheque_allowed_inactivity_period_normal_daysDbString + ",");
                    qry.Append(cheque_allowed_inactivity_period_salary_daysDbString + ",");
                    qry.Append(cit_idDbString + ",");
                    qry.Append(is_recyclerDbString + ",");
                    qry.Append(last_ping_statusDbString + ",");
                    qry.Append(last_ping_executed_atDbString + ",");
                    qry.Append(last_telnet_statusDbString + ",");
                    qry.Append(last_telnet_executed_atDbString + ",");
                    qry.Append(assigned_serverDbString + ",");
                    qry.Append(is_editedDbString + ",");
                    qry.Append(atm_streaming_heartbeat_received_atDbString + ",");
                    qry.Append(atm_on_demand_heartbeat_received_atDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(aTM_idChanged || last_status_replyChanged || region_idChanged || titleChanged || iPChanged || portChanged || modified_byChanged || created_byChanged || is_activeChanged || creation_timeChanged || atm_typeChanged || cassette1_capacityChanged || cassette1_denominationChanged || cassette2_capacityChanged || cassette2_denominationChanged || cassette3_denominationChanged || cassette3_capacityChanged || cassette4_denominationChanged || cassette4_capacityChanged || cassette5_denominationChanged || cassette5_capacityChanged || cassette6_denominationChanged || cassette6_capacityChanged || cassette7_denominationChanged || cassette7_capacityChanged || is_healthyChanged || locationChanged || address1Changed || address2Changed || cityChanged || countryChanged || max_notes_per_cassetteChanged || min_operating_balanceChanged || is_atmChanged || is_cdmChanged || is_ccdmChanged || cdm_cassette1_capacityChanged || cdm_cassette2_capacityChanged || cdm_cassette3_capacityChanged || cdm_cassette4_capacityChanged || ccdm_cassette1_capacityChanged || ccdm_cassette2_capacityChanged || ccdm_cassette3_capacityChanged || ccdm_cassette4_capacityChanged || cdm_cassette1_thresholdChanged || cdm_cassette2_thresholdChanged || cdm_cassette3_thresholdChanged || cdm_cassette4_thresholdChanged || ccdm_cassette1_thresholdChanged || ccdm_cassette2_thresholdChanged || ccdm_cassette3_thresholdChanged || ccdm_cassette4_thresholdChanged || note_set_type_idChanged || ccdm_cassette5_capacityChanged || ccdm_cassette5_thresholdChanged || startup_sleep_intervalChanged || debug_levelChanged || purge1_thresholdChanged || is_purge1_threshold_selectedChanged || purge2_thresholdChanged || is_purge2_threshold_selectedChanged || purge3_thresholdChanged || is_purge3_threshold_selectedChanged || purge4_thresholdChanged || is_purge4_threshold_selectedChanged || purge5_thresholdChanged || is_purge5_threshold_selectedChanged || purge6_thresholdChanged || is_purge6_threshold_selectedChanged || purge7_thresholdChanged || is_purge7_threshold_selectedChanged || retry_count_conf_uploadChanged || tCPTimeoutChanged || sleepIntervalChanged || type1MinimumNotesChanged || type2MinimumNotesChanged || type3MinimumNotesChanged || type4MinimumNotesChanged || type5MinimumNotesChanged || type6MinimumNotesChanged || type7MinimumNotesChanged || allowed_inactivity_periodChanged || descriptionChanged || cheque_allowed_inactivity_periodChanged || bna_allowed_inactivity_periodChanged || out_of_cash_thresholdChanged || longitudeChanged || latitudeChanged || is_swap_default_replenishmentChanged || message_processor_idChanged || type1_min_notes_thresholdChanged || type2_min_notes_thresholdChanged || type3_min_notes_thresholdChanged || type4_min_notes_thresholdChanged || type1_min_notes_threshold_valueChanged || type2_min_notes_threshold_valueChanged || type3_min_notes_threshold_valueChanged || type4_min_notes_threshold_valueChanged || bna_allowed_inactivity_period_normal_daysChanged || bna_allowed_inactivity_period_salary_daysChanged || cheque_allowed_inactivity_period_normal_daysChanged || cheque_allowed_inactivity_period_salary_daysChanged || cit_idChanged || is_recyclerChanged || last_ping_statusChanged || last_ping_executed_atChanged || last_telnet_statusChanged || last_telnet_executed_atChanged || assigned_serverChanged || is_editedChanged || atm_streaming_heartbeat_received_atChanged || atm_on_demand_heartbeat_received_atChanged))
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

                    if (max_notes_per_cassetteChanged)
                    {
                        qry.Append("max_notes_per_cassette =" + max_notes_per_cassetteDbString);
                        qry.Append(",");
                    }

                    if (min_operating_balanceChanged)
                    {
                        qry.Append("min_operating_balance =" + min_operating_balanceDbString);
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

                    if (retry_count_conf_uploadChanged)
                    {
                        qry.Append("retry_count_conf_upload =" + retry_count_conf_uploadDbString);
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

                    if (allowed_inactivity_periodChanged)
                    {
                        qry.Append("allowed_inactivity_period =" + allowed_inactivity_periodDbString);
                        qry.Append(",");
                    }

                    if (descriptionChanged)
                    {
                        qry.Append("description =" + descriptionDbString);
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

                    if (cit_idChanged)
                    {
                        qry.Append("cit_id =" + cit_idDbString);
                        qry.Append(",");
                    }

                    if (is_recyclerChanged)
                    {
                        qry.Append("is_recycler =" + is_recyclerDbString);
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

                    if (assigned_serverChanged)
                    {
                        qry.Append("assigned_server =" + assigned_serverDbString);
                        qry.Append(",");
                    }

                    if (is_editedChanged)
                    {
                        qry.Append("is_edited =" + is_editedDbString);
                        qry.Append(",");
                    }

                    if (atm_streaming_heartbeat_received_atChanged)
                    {
                        qry.Append("atm_streaming_heartbeat_received_at =" + atm_streaming_heartbeat_received_atDbString);
                        qry.Append(",");
                    }

                    if (atm_on_demand_heartbeat_received_atChanged)
                    {
                        qry.Append("atm_on_demand_heartbeat_received_at =" + atm_on_demand_heartbeat_received_atDbString);
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
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Core));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Atm whereATM_id= " + aTM_id;
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
            ConnectionFactory.ExecuteQuery("delete Atm where " + where,DatabaseName.Core);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            ATM_id = 0,
            last_status_reply = 1,
            region_id = 2,
            title = 3,
            IP = 4,
            port = 5,
            modified_by = 6,
            created_by = 7,
            is_active = 8,
            creation_time = 9,
            atm_type = 10,
            cassette1_capacity = 11,
            cassette1_denomination = 12,
            cassette2_capacity = 13,
            cassette2_denomination = 14,
            cassette3_denomination = 15,
            cassette3_capacity = 16,
            cassette4_denomination = 17,
            cassette4_capacity = 18,
            cassette5_denomination = 19,
            cassette5_capacity = 20,
            cassette6_denomination = 21,
            cassette6_capacity = 22,
            cassette7_denomination = 23,
            cassette7_capacity = 24,
            is_healthy = 25,
            location = 26,
            address1 = 27,
            address2 = 28,
            city = 29,
            country = 30,
            max_notes_per_cassette = 31,
            min_operating_balance = 32,
            is_atm = 33,
            is_cdm = 34,
            is_ccdm = 35,
            cdm_cassette1_capacity = 36,
            cdm_cassette2_capacity = 37,
            cdm_cassette3_capacity = 38,
            cdm_cassette4_capacity = 39,
            ccdm_cassette1_capacity = 40,
            ccdm_cassette2_capacity = 41,
            ccdm_cassette3_capacity = 42,
            ccdm_cassette4_capacity = 43,
            cdm_cassette1_threshold = 44,
            cdm_cassette2_threshold = 45,
            cdm_cassette3_threshold = 46,
            cdm_cassette4_threshold = 47,
            ccdm_cassette1_threshold = 48,
            ccdm_cassette2_threshold = 49,
            ccdm_cassette3_threshold = 50,
            ccdm_cassette4_threshold = 51,
            note_set_type_id = 52,
            ccdm_cassette5_capacity = 53,
            ccdm_cassette5_threshold = 54,
            startup_sleep_interval = 55,
            debug_level = 56,
            purge1_threshold = 57,
            is_purge1_threshold_selected = 58,
            purge2_threshold = 59,
            is_purge2_threshold_selected = 60,
            purge3_threshold = 61,
            is_purge3_threshold_selected = 62,
            purge4_threshold = 63,
            is_purge4_threshold_selected = 64,
            purge5_threshold = 65,
            is_purge5_threshold_selected = 66,
            purge6_threshold = 67,
            is_purge6_threshold_selected = 68,
            purge7_threshold = 69,
            is_purge7_threshold_selected = 70,
            retry_count_conf_upload = 71,
            TCPTimeout = 72,
            SleepInterval = 73,
            Type1MinimumNotes = 74,
            Type2MinimumNotes = 75,
            Type3MinimumNotes = 76,
            Type4MinimumNotes = 77,
            Type5MinimumNotes = 78,
            Type6MinimumNotes = 79,
            Type7MinimumNotes = 80,
            allowed_inactivity_period = 81,
            description = 82,
            cheque_allowed_inactivity_period = 83,
            bna_allowed_inactivity_period = 84,
            out_of_cash_threshold = 85,
            longitude = 86,
            latitude = 87,
            is_swap_default_replenishment = 88,
            message_processor_id = 89,
            type1_min_notes_threshold = 90,
            type2_min_notes_threshold = 91,
            type3_min_notes_threshold = 92,
            type4_min_notes_threshold = 93,
            type1_min_notes_threshold_value = 94,
            type2_min_notes_threshold_value = 95,
            type3_min_notes_threshold_value = 96,
            type4_min_notes_threshold_value = 97,
            bna_allowed_inactivity_period_normal_days = 98,
            bna_allowed_inactivity_period_salary_days = 99,
            cheque_allowed_inactivity_period_normal_days = 100,
            cheque_allowed_inactivity_period_salary_days = 101,
            cit_id = 102,
            is_recycler = 103,
            last_ping_status = 104,
            last_ping_executed_at = 105,
            last_telnet_status = 106,
            last_telnet_executed_at = 107,
            assigned_server = 108,
            is_edited = 109,
            atm_streaming_heartbeat_received_at = 110,
            atm_on_demand_heartbeat_received_at = 111
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
                Row["aTM_id"] = ConnectionFactory.GetNextId(DatabaseName.Core);
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
                Row["is_healthy"] = tran.IsHealthy;
                Row["location"] = tran.Location;
                Row["address1"] = tran.Address1;
                Row["address2"] = tran.Address2;
                Row["city"] = tran.City;
                Row["country"] = tran.Country;
                Row["max_notes_per_cassette"] = tran.MaxNotesPerCassette;
                Row["min_operating_balance"] = tran.MinOperatingBalance;
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
                Row["retry_count_conf_upload"] = tran.RetryCountConfUpload;
                Row["tCPTimeout"] = tran.TCPTimeout;
                Row["sleepInterval"] = tran.SleepInterval;
                Row["type1MinimumNotes"] = tran.Type1MinimumNotes;
                Row["type2MinimumNotes"] = tran.Type2MinimumNotes;
                Row["type3MinimumNotes"] = tran.Type3MinimumNotes;
                Row["type4MinimumNotes"] = tran.Type4MinimumNotes;
                Row["type5MinimumNotes"] = tran.Type5MinimumNotes;
                Row["type6MinimumNotes"] = tran.Type6MinimumNotes;
                Row["type7MinimumNotes"] = tran.Type7MinimumNotes;
                Row["allowed_inactivity_period"] = tran.AllowedInactivityPeriod;
                Row["description"] = tran.Description;
                Row["cheque_allowed_inactivity_period"] = tran.ChequeAllowedInactivityPeriod;
                Row["bna_allowed_inactivity_period"] = tran.BnaAllowedInactivityPeriod;
                Row["out_of_cash_threshold"] = tran.OutOfCashThreshold;
                Row["longitude"] = tran.Longitude;
                Row["latitude"] = tran.Latitude;
                Row["is_swap_default_replenishment"] = tran.IsSwapDefaultReplenishment;
                Row["message_processor_id"] = tran.MessageProcessorId;
                Row["type1_min_notes_threshold"] = tran.Type1MinNotesThreshold;
                Row["type2_min_notes_threshold"] = tran.Type2MinNotesThreshold;
                Row["type3_min_notes_threshold"] = tran.Type3MinNotesThreshold;
                Row["type4_min_notes_threshold"] = tran.Type4MinNotesThreshold;
                Row["type1_min_notes_threshold_value"] = tran.Type1MinNotesThresholdValue;
                Row["type2_min_notes_threshold_value"] = tran.Type2MinNotesThresholdValue;
                Row["type3_min_notes_threshold_value"] = tran.Type3MinNotesThresholdValue;
                Row["type4_min_notes_threshold_value"] = tran.Type4MinNotesThresholdValue;
                Row["bna_allowed_inactivity_period_normal_days"] = tran.BnaAllowedInactivityPeriodNormalDays;
                Row["bna_allowed_inactivity_period_salary_days"] = tran.BnaAllowedInactivityPeriodSalaryDays;
                Row["cheque_allowed_inactivity_period_normal_days"] = tran.ChequeAllowedInactivityPeriodNormalDays;
                Row["cheque_allowed_inactivity_period_salary_days"] = tran.ChequeAllowedInactivityPeriodSalaryDays;
                Row["cit_id"] = tran.CitId;
                Row["is_recycler"] = tran.IsRecycler;
                Row["last_ping_status"] = tran.LastPingStatus;
                Row["last_ping_executed_at"] = tran.LastPingExecutedAt;
                Row["last_telnet_status"] = tran.LastTelnetStatus;
                Row["last_telnet_executed_at"] = tran.LastTelnetExecutedAt;
                Row["assigned_server"] = tran.AssignedServer;
                Row["is_edited"] = tran.IsEdited;
                Row["atm_streaming_heartbeat_received_at"] = tran.AtmStreamingHeartbeatReceivedAt;
                Row["atm_on_demand_heartbeat_received_at"] = tran.AtmOnDemandHeartbeatReceivedAt;
                dt.Rows.Add(Row);
            }
        }
    }
}

