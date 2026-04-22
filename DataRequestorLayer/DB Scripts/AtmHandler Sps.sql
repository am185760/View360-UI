USE [Core]
GO
/****** Object:  StoredProcedure [dbo].[UpdateATMInfoInCore]    Script Date: 6/19/2023 11:45:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdateEditedATMInfoInCore] 
@AtmsID varchar(max),
@ServerNum int

AS
BEGIN
	SET NOCOUNT ON;
	declare @sql varchar(max);
	set @sql = N'update atm set is_edited = 0 where ATM_id in ('+ @AtmsID +')';
	Exec(@sql);
	select @@ROWCOUNT;
END
go
create PROCEDURE [dbo].[DeleteAtmInfo] 
@AtmsIds varchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	declare @sql varchar(max);
	set @sql = N'delete from atm where ATM_id in ('+ @AtmsIds +')';
	Exec(@sql)
	select @@ROWCOUNT;
END

go

alter PROCEDURE [dbo].[GetAllAtms] 
AS
BEGIN
	SET NOCOUNT ON;
	declare @sql varchar(max);
	set @sql = N'select * from atm ';
	Exec(@sql);
	select @@ROWCOUNT;
END


go

ALTER PROCEDURE [dbo].[GetEditedAtms] 
@ServerNum int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from atm where is_edited = 1 AND assigned_server = @ServerNum;
END


go

alter procedure [dbo].[UpdateAtmsInfo]
@AtmsInfo ATM_table_type  READONLY
 as
 update e set 
 e.last_status_reply=d.last_status_reply,
 e.region_id=d.region_id,
 e.title=d.title,
 e.IP=d.IP,
 e.port=d.port,
 e.created_by=d.created_by,
 e.is_active=d.is_active,
 e.creation_time= d.creation_time,
 e.cassette1_capacity=d.cassette1_capacity,
 e.cassette1_denomination=d.cassette1_denomination,
 e.cassette2_capacity=d.cassette2_capacity,
 e.cassette2_denomination=d.cassette2_denomination,
 e.cassette3_denomination=d.cassette3_denomination,
 e.cassette3_capacity=d.cassette3_capacity,
 e.cassette4_denomination=d.cassette4_denomination,
 e.cassette4_capacity=d.cassette4_capacity,
 e.cassette5_denomination=d.cassette5_denomination,
 e.cassette5_capacity=d.cassette5_capacity,
 e.cassette6_denomination=d.cassette6_denomination,
 e.cassette6_capacity=d.cassette6_capacity,
 e.cassette7_denomination=d.cassette7_denomination,
 e.cassette7_capacity=d.cassette7_capacity,
 e.is_healthy=d.is_healthy,
 e.location=d.location,
 e.address1=d.address1,
 e.address2=d.address2,
 e.city=d.city,
 e.country = d.country,
 e.max_notes_per_cassette = d.max_notes_per_cassette,
e.min_operating_balance = d.min_operating_balance,
e.is_atm = d.is_atm,
e.is_cdm = d.is_cdm,
e.is_ccdm = d.is_ccdm,
e.cdm_cassette1_capacity = d.cdm_cassette1_capacity,
e.cdm_cassette2_capacity = d.cdm_cassette2_capacity,
e.cdm_cassette3_capacity = d.cdm_cassette3_capacity,
e.cdm_cassette4_capacity = d.cdm_cassette4_capacity,
e.ccdm_cassette1_capacity = d.ccdm_cassette1_capacity,
e.ccdm_cassette2_capacity = d.ccdm_cassette2_capacity,
e.ccdm_cassette3_capacity = d.ccdm_cassette3_capacity,
e.ccdm_cassette4_capacity = d.ccdm_cassette4_capacity,
e.cdm_cassette1_threshold = d.cdm_cassette1_threshold,
e.cdm_cassette2_threshold = d.cdm_cassette2_threshold,
e.cdm_cassette3_threshold = d.cdm_cassette3_threshold,
e.cdm_cassette4_threshold = d.cdm_cassette4_threshold,
e.ccdm_cassette1_threshold = d.ccdm_cassette1_threshold,
e.ccdm_cassette2_threshold = d.ccdm_cassette2_threshold,
e.ccdm_cassette3_threshold = d.ccdm_cassette3_threshold,
e.ccdm_cassette4_threshold = d.ccdm_cassette4_threshold,
e.note_set_type_id = d.note_set_type_id,
e.ccdm_cassette5_capacity = d.ccdm_cassette5_capacity,
e.ccdm_cassette5_threshold = d.ccdm_cassette5_threshold,
e.startup_sleep_interval = d.startup_sleep_interval,
e.debug_level = d.debug_level,
e.purge1_threshold = d.purge1_threshold,
e.is_purge1_threshold_selected = d.is_purge1_threshold_selected,
e.purge2_threshold = d.purge2_threshold,
e.is_purge2_threshold_selected = d.is_purge2_threshold_selected,
e.purge3_threshold = d.purge3_threshold,
e.is_purge3_threshold_selected = d.is_purge3_threshold_selected,
e.purge4_threshold = d.purge4_threshold,
e.is_purge4_threshold_selected = d.is_purge4_threshold_selected,
e.purge5_threshold = d.purge5_threshold,
e.is_purge5_threshold_selected = d.is_purge5_threshold_selected,
e.purge6_threshold = d.purge6_threshold,
e.is_purge6_threshold_selected = d.is_purge6_threshold_selected,
e.purge7_threshold = d.purge7_threshold,
e.retry_count_conf_upload = d.retry_count_conf_upload,
e.TCPTimeout = d.TCPTimeout,
e.SleepInterval = d.SleepInterval,
e.Type1MinimumNotes = d.Type1MinimumNotes,
e.Type2MinimumNotes = d.Type2MinimumNotes,
e.Type3MinimumNotes = d.Type3MinimumNotes,
e.Type4MinimumNotes = d.Type4MinimumNotes,
e.Type5MinimumNotes = d.Type5MinimumNotes,
e.Type6MinimumNotes = d.Type6MinimumNotes,
e.Type7MinimumNotes = d.Type7MinimumNotes,
e.allowed_inactivity_period = d.allowed_inactivity_period,
e.description = d.description,
e.cheque_allowed_inactivity_period = d.cheque_allowed_inactivity_period,
e.bna_allowed_inactivity_period = d.bna_allowed_inactivity_period,
e.out_of_cash_threshold = d.out_of_cash_threshold,
e.longitude = d.longitude,
e.latitude = d.latitude,
e.is_edited = 0,
e.is_swap_default_replenishment = d.is_swap_default_replenishment,
e.message_processor_id = d.message_processor_id,
e.type1_min_notes_threshold = d.type1_min_notes_threshold,
e.type2_min_notes_threshold = d.type2_min_notes_threshold,
e.type3_min_notes_threshold = d.type3_min_notes_threshold,
e.type4_min_notes_threshold = d.type4_min_notes_threshold,
e.type1_min_notes_threshold_value = d.type1_min_notes_threshold_value,
e.type2_min_notes_threshold_value = d.type2_min_notes_threshold_value,
e.type3_min_notes_threshold_value = d.type3_min_notes_threshold_value,
e.type4_min_notes_threshold_value = d.type4_min_notes_threshold_value,
e.bna_allowed_inactivity_period_normal_days = d.bna_allowed_inactivity_period_normal_days,
e.bna_allowed_inactivity_period_salary_days = d.bna_allowed_inactivity_period_salary_days,
e.cheque_allowed_inactivity_period_normal_days = d.cheque_allowed_inactivity_period_normal_days,
e.cit_id = d.cit_id,
e.is_recycler = d.is_recycler,
e.last_ping_status = d.last_ping_status,
e.last_ping_executed_at = d.last_ping_executed_at,
e.last_telnet_status = d.last_telnet_status,
e.last_telnet_executed_at = d.last_telnet_executed_at,
e.assigned_server = d.assigned_server
 from atm e,@AtmsInfo d
 where e.ATM_id=d.ATM_id 
